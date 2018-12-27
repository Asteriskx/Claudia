using Claudia.SoundCloud.EndPoints.Users;
using System.Net.Http;

namespace Claudia.SoundCloud
{
	/// <summary>
	/// 資格情報を管理します。
	/// </summary>
	public class Credentials
	{
		#region Properties

		protected HttpClient Client { get; set; } = new HttpClient();
		protected SCCredentials SCCredentials { get; set; }
		protected string Token { get; set; }
		public string ClientId { get; set; }

		#endregion Properties

		#region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="token"></param>
		/// <param name="clientId"></param>
		/// <param name="type"></param>
		public Credentials(string token, string clientId, HttpMethod type)
		{
			this.Token = token;
			this.ClientId = clientId;
			this.SCCredentials = new SCCredentials(token, clientId, type);
		}

		#endregion Constructor
	}
}
