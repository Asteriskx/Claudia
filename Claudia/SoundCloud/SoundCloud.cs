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
		
		#region Like's Properties

		public List<SCFavoriteObjects> Likes { get; private set; } = new List<SCFavoriteObjects>();
		public List<string> NextHrefList { get; private set; } = new List<string>();
		private bool _IsNextHref { get; set; } = false;
		public int TrackNum { get; set; } = 0;

		#endregion Like's Properties

		#region PlayList's Properties

		public List<SCPlayListObjects> Playlists { get; private set; } = new List<SCPlayListObjects>();
		public Dictionary<string, string> PostData { get; set; }
		public int TabIdx { get; set; } = 0;
		public int ListTrackIdx { get; set; } = 0;
		public string ArtworkUrl { get; set; }

		#endregion PlayList's Properties

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
		private async Task<string> _GetLoginUserAsync()
		{
			var connection = this.SCCredentials.GetRequestMessage(RequestType.LoginUser);
			var response = await this.Client.SendAsync(connection);
			return await response.Content.ReadAsStringAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetLoginUserNameAsync()
		{
			var userData = await _GetLoginUserAsync();
			return JsonConvert.DeserializeObject<SCLoginUser>(userData).UserName;
		}

		/// <summary>
		/// ログインユーザの公式リンク先を取得します。
		/// </summary>
		/// <returns> ログインユーザのリンク URL </returns>
		public async Task<string> GetProfileUrlAsync()
		{
			var userData = await _GetLoginUserAsync();
			return JsonConvert.DeserializeObject<SCLoginUser>(userData).PermalinkUrl;
		}

		/// <summary>
		/// ログインユーザのアバター画像 URL を非同期にて取得します。
		/// </summary>
		/// <returns> ログインユーザのアバター画像 URL </returns>
		public async Task<string> GetLoginAvaterImageUrlAsync()
		{
			var userData = await _GetLoginUserAsync();
			userData = userData.Replace("large", "t500x500");

			return JsonConvert.DeserializeObject<SCLoginUser>(userData).AvatarUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task GetStreamAsync() { }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task GetPlayListAsync()
		{
			var connection = this.SCCredentials.GetRequestMessage(RequestType.PlayList);
			var response = await this.Client.SendAsync(connection);
			var resString = await response.Content.ReadAsStringAsync();
			resString = resString.Replace("large", "t500x500");

			var data = JsonConvert.DeserializeObject<List<SCPlayListObjects>>(resString);
			this.Playlists.AddRange(data);
		}

		/// <summary>
		/// Like's に登録されている曲を非同期で取得します。
		/// </summary>
		public async Task GetFavoriteSongsListAsync()
		{
			var idx = 0;
			while (true)
			{
				var connection = this.SCCredentials.GetRequestMessage(RequestType.Likes);

				// next_href(次 Like's Track 群へのアクセスリンク) の有無をチェック
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
