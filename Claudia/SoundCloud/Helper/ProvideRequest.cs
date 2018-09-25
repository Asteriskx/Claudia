using System.Net.Http;
using System.Threading.Tasks;

namespace Claudia.SoundCloud.Helper
{
	/// <summary>
	/// 
	/// </summary>
	public static class ProvideRequest
	{
		private static readonly string _BaseUrl = "http://api.soundcloud.com";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="type"></param>
		/// <param name="endPoint"></param>
		/// <returns></returns>
		public static Task<HttpRequestMessage> CreateRequest(string token, HttpMethod type, string endPoint)
		{
			return new Task<HttpRequestMessage>(() =>
			{
				var req = default(HttpRequestMessage);

				if (!string.IsNullOrEmpty(endPoint))
					req = new HttpRequestMessage(type, _BaseUrl + endPoint);

				req.Headers.Add("Authorization", $"OAuth {token}");
				return req;
			});
		}
	}
}
