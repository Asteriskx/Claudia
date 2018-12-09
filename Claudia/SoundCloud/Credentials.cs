using Claudia.SoundCloud.EndPoints.Users;
using System.Net.Http;

namespace Claudia.SoundCloud
{
	public class Credentials
	{
		protected HttpClient Client { get; set; } = new HttpClient();
		protected SCUsers SCUsers { get; set; }
		protected string Token { get; set; }
		public string ClientId { get; set; }

		public Credentials(string token, string clientId, HttpMethod type) 
		{
			this.Token = token;
			this.ClientId = clientId;
			this.SCUsers = new SCUsers(token, clientId, type);
		}
	}
}
