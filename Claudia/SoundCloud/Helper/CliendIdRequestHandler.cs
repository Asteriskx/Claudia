using CefSharp;
using CefSharp.Handler;
using Newtonsoft.Json;
using System.Text;

namespace Claudia.SoundCloud.Helper
{
	/// <summary>
	/// 
	/// </summary>
	public class CliendIdRequestHandler : DefaultRequestHandler
	{
		#region Property

		/// <summary>
		/// 
		/// </summary>
		public string ClientId { get; set; }

		#endregion Property

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		public CliendIdRequestHandler() : base() { }

		#endregion Constructor

		#region Override Method

		/// <summary>
		/// 
		/// </summary>
		/// <param name="chromiumBrowser"></param>
		/// <param name="browser"></param>
		/// <param name="frame"></param>
		/// <param name="request"></param>
		/// <param name="response"></param>
		/// <returns></returns>
		public override bool OnResourceResponse(IWebBrowser chromiumBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			var ret = base.OnResourceResponse(chromiumBrowser, browser, frame, request, response);
			if (request.Url.StartsWith("https://api-v2.soundcloud.com/sign-in/password") && request.Method != "OPTIONS")
			{
				if (request.PostData.Elements.Count > 0)
				{
					var str = Encoding.UTF8.GetString(request.PostData.Elements[0].Bytes);
					dynamic json = JsonConvert.DeserializeObject(str);
					this.ClientId = json.client_id.Value;
				}
			}

			return ret;
		}

		#endregion Override Method
	}
}
