using Claudia.Exceptions;
using System;
using System.Net.Http;

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
		public static HttpRequestMessage CreateRequest(string token, HttpMethod type, string endPoint, string clientId, string query = null)
		{
			var req = default(HttpRequestMessage);

			try
			{
				req = (!string.IsNullOrEmpty(endPoint) && query != null) ?
					new HttpRequestMessage(type, $"{_BaseUrl}{endPoint}?client_id={clientId}&{query}") :
					new HttpRequestMessage(type, $"{_BaseUrl}{endPoint}?client_id={clientId}");

				req.Headers.Add("Authorization", $"OAuth {token}");
			}
			catch (Exception ex)
			{
				throw new ClaudiaException($"{ex.Message} - {ex.StackTrace}");
			}

			return req;
		}
	}
}
