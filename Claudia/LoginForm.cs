using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;

using Newtonsoft.Json;
using Claudia.SoundCloud.Helper;
using System.Text;
using System.Windows.Forms;

namespace Claudia
{
	public partial class LoginForm : Form
	{
		private CookieVisitor _Visitor { get; set; } = new CookieVisitor();
		private ChromiumWebBrowser Browser { get; set; }
		private CliendIdRequestHandler _CliendIdRequestHandler { get; set; } = new CliendIdRequestHandler();

		private Timer _Timer { get; set; } = new Timer();

		public string ClientId { get; private set; }
		public string Token { get; private set; }

		public LoginForm()
		{
			this.InitializeComponent();

			this.Browser = new ChromiumWebBrowser("https://soundcloud.com/signin/")
			{
				RequestHandler = this._CliendIdRequestHandler
			};
			this.panel1.Controls.Add(this.Browser);
		}

		private void LoginForm_Load(object sender, System.EventArgs e)
		{
			this._Timer.Interval = 1000;
			this._Timer.Stop();

			this._Timer.Tick += async (s, ee) =>
			{
				this._Timer.Stop();
				this.Browser.GetCookieManager().VisitUrlCookies("https://soundcloud.com/signin/", false, this._Visitor);

				await this._Visitor.WaitComplete();

				if (this._Visitor.AllCookies.ContainsKey("oauth_token"))
				{
					this.ClientId = this._CliendIdRequestHandler.ClientId;
					this.Token = this._Visitor["oauth_token"].Value;
					this.DialogResult = DialogResult.OK;
					this.Close();
					//Cef.Shutdown();
					return;
				}

				this._Timer.Start();
			};

			this._Timer.Start();
		}
	}

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
