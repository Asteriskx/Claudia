using Claudia.SoundCloud.Helper;
using System.Net.Http;
using System.Threading.Tasks;

namespace Claudia.SoundCloud.EndPoints.Users
{
	/// <summary>
	/// 
	/// </summary>
	public class SCUsers
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		private string _Token { get; set; } = string.Empty;

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
		public SCUsers(string token, HttpMethod type)
		{
			this._Token = token;
			this._Type = type;
			this._Users = new EndPoints.Users(this._Token.Split('-')[2]);
		}

		#endregion Constructor

		#region Private Method

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<HttpRequestMessage> GetRequestMessageAsync()
		{
			return await ProvideRequest.CreateRequest(this._Token, this._Type, this._Users.Favorites);
		}

		#endregion Private Method
	}
}
