using CefSharp;
using CefSharp.WinForms;

using Claudia.SoundCloud.Helper;
using System.Windows.Forms;

namespace Claudia
{
	/// <summary>
	/// LoginForm - for SoundCloud.
	/// </summary>
	public partial class LoginForm : Form
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		private CookieVisitor _Visitor { get; set; } = new CookieVisitor();

		/// <summary>
		/// 
		/// </summary>
		private ChromiumWebBrowser _Browser { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private CliendIdRequestHandler _CliendIdRequestHandler { get; set; } = new CliendIdRequestHandler();

		/// <summary>
		/// 
		/// </summary>
		private Timer _Timer { get; set; } = new Timer();

		/// <summary>
		/// 
		/// </summary>
		public string ClientId { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public string Token { get; private set; }

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		public LoginForm()
		{
			this.InitializeComponent();

			this._Browser = new ChromiumWebBrowser("https://soundcloud.com/signin/")
			{
				RequestHandler = this._CliendIdRequestHandler
			};
			this.panel1.Controls.Add(this._Browser);
		}

		#endregion Constructor

		#region Event Method

		/// <summary>
		/// Load Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginForm_Load(object sender, System.EventArgs e)
		{
			this._Timer.Interval = 1000;
			this._Timer.Stop();

			this._Timer.Tick += async (s, ee) =>
			{
				this._Timer.Stop();
				this._Browser.GetCookieManager().VisitUrlCookies("https://soundcloud.com/signin/", false, this._Visitor);

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

		#endregion Event Methods
	}
}
