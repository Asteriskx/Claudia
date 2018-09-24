using CefSharp;
using CefSharp.Handler;
using Newtonsoft.Json;
using System.Text;

namespace Claudia.SoundCloud.Helper
{
	public class CliendIdRequestHandler : DefaultRequestHandler
	{
		public string ClientId { get; set; }

		public CliendIdRequestHandler() : base() { }

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
	}
}
