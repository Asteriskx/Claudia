using Claudia.Interop.Enum;
using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Users;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Claudia.SoundCloud
{
	/// <summary>
	/// SoundCloud 管理クラス
	/// </summary>
	public class SoundCloud : Credentials
	{
		#region Properties

		private bool _IsNextHref { get; set; } = false;
		public List<string> NextHrefList { get; private set; } = new List<string>();
		public List<SCFavoriteObjects> Likes { get; private set; } = new List<SCFavoriteObjects>();
		public int TrackNum { get; set; } = 0;

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="clientId"></param>
		/// <param name="type"></param>
		public SoundCloud(string token, string clientId, HttpMethod type) : base(token, clientId, type) { }

		#endregion Constructror

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetProfileUrlAsync()
		{
			var connection = this.SCCredentials.GetRequestMessage(RequestType.LoginUser);

			var response = await this.Client.SendAsync(connection);

			var resString = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<SCUser>(resString).PermalinkUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetLoginAvaterImageUrlAsync()
		{
			var connection = this.SCCredentials.GetRequestMessage(RequestType.LoginUser);

			var response = await this.Client.SendAsync(connection);

			var resString = await response.Content.ReadAsStringAsync();
			resString = resString.Replace("large", "t500x500");

			return JsonConvert.DeserializeObject<SCUser>(resString).AvatarUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task GetStreamAsync()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task GetPlayListAsync()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task GetFavoriteSongsListAsync()
		{
			var idx = 0;
			while (true)
			{
				var connection = this.SCCredentials.GetRequestMessage(RequestType.Likes);

				var response = (!_IsNextHref) ?
					await this.Client.SendAsync(connection) :
					await this.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, this.NextHrefList[idx - 1]));

				var resString = await response.Content.ReadAsStringAsync();
				resString = resString.Replace("large", "t500x500");

				var pagenation = JsonConvert.DeserializeObject<Pagenation<SCFavoriteObjects>>(resString);
				this.Likes.AddRange(pagenation.Collection);

				if (!string.IsNullOrEmpty(pagenation.NextHref))
				{
					this.NextHrefList.Add(pagenation.NextHref);
					this._IsNextHref = true;
				}
				else
				{
					this._IsNextHref = false;
					break;
				}

				idx++;
			}
		}

		#endregion Public Methods
	}
}
