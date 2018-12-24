using Claudia.Exceptions;
using Claudia.Interop.Enum;
using Claudia.SoundCloud.Helper;
using System.Net.Http;

namespace Claudia.SoundCloud.EndPoints.Users
{
	/// <summary>
	/// 
	/// </summary>
	public class SCCredentials
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		private string _Token { get; set; } = string.Empty;

		private string _ClientId { get; set; } = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		private HttpMethod _Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private EndPoints.Users _Users { get; set; }

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="type"></param>
		public SCCredentials(string token, string clientId, HttpMethod type)
		{
			this._Token = token;
			this._ClientId = clientId;
			this._Type = type;
			this._Users = new EndPoints.Users(this._Token.Split('-')[2]);
		}

		#endregion Constructor

		#region Public Method

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public HttpRequestMessage GetRequestMessage(RequestType type)
		{
			switch (type)
			{
				case RequestType.LoginUser:
					return ProvideRequest.CreateRequest(this._Token, this._Type, this._Users.User, this._ClientId);

				case RequestType.Stream:
					return null;

				case RequestType.PlayList:
					return ProvideRequest.CreateRequest(this._Token, this._Type, this._Users.Playlists, this._ClientId);

				case RequestType.Likes:
					return ProvideRequest.CreateRequest(this._Token, this._Type, this._Users.Favorites, this._ClientId, "limit=200&linked_partitioning=1");

				default:
					throw new ClaudiaException("Sorry, not found RequestTypes...");
			}
		}

		#endregion Public Method
	}
}
