using Claudia.SoundCloud.EndPoints;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Claudia.SoundCloud
{
	public class SoundCloud : Credentials
	{
		#region Properties

		private bool _IsNextHref { get; set; } = false;
		public List<string> NextHrefList { get; private set; } = new List<string>();
		public List<SCFavoriteObjects> Likes { get; private set; } = new List<SCFavoriteObjects>();

		#endregion Properties

		#region Constructor

		public SoundCloud(string token, string clientId, HttpMethod type) : base(token, clientId, type) { }

		#endregion Constructror

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
				var connection = this.SCUsers.GetRequestMessage();

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
	}
}
