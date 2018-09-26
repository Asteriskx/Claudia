using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Users;
using Claudia.Utility;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Claudia
{
	/// <summary>
	/// Claudia - MainForm
	/// </summary>
	public partial class MainForm : Form
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		private HttpClient _Client { get; set; } = new HttpClient();

		/// <summary>
		/// 
		/// </summary>
		private List<SCFavoriteObjects> _Favorite { get; set; } = new List<SCFavoriteObjects>();

		/// <summary>
		/// 
		/// </summary>
		private SCUsers _SCUsers { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private string _ClientId { get; set; } = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		private string _Token { get; set; } = string.Empty;

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		public MainForm() => this.InitializeComponent();

		#endregion Constructor

		#region Event Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			this._InitializeResultView();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void AccessButton_Click(object sender, EventArgs e)
		{
			await this.GetFavoriteSongsListAsync();
			this.pictureBox1.ImageLocation = this._Favorite[0].ArtworkUrl ?? string.Empty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loginButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this._Token))
			{
				var form = new LoginForm();
				if (form.ShowDialog() == DialogResult.OK)
				{
					this._ClientId = form.ClientId;
					this._Token = form.Token;
					this.loginInfo.Text = "ログイン完了";
					this.tokenInfo.Text = "トークン取得完了";
				}
			}
			else
			{
				this.loginInfo.Text = "トークンが取得されている為、ログインしませんでした。";
				this.tokenInfo.Text = "トークン取得済み。";
				Console.WriteLine("既にトークン取得完了しています。");
			}

			this._SCUsers = new SCUsers(this._Token, HttpMethod.Get);
		}

		#endregion Event Methods

		#region Public Methods

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// 取得リストビューの初期設定を行います。
		/// </summary>
		private void _InitializeResultView()
		{
			// ヘッダ情報・ヘッダ幅
			var data = new Dictionary<string, int>()
			{
				{ "トラック名", 150 },
				{ "アーティスト名", 150 },
				{ "アルバム名", 200 },
				{ "再生回数", 100 },
				{ "お気に入り数", 100 }
			};

			this.ResultView.FullRowSelect = true;
			this.ResultView.GridLines = true;
			this.ResultView.Sorting = SortOrder.Ascending;
			this.ResultView.View = View.Details;

			// ヘッダ追加
			foreach (var kvp in data)
			{
				this.ResultView.Columns.Add(ColumnHeaderEx.GetColumnHeader(kvp.Key, kvp.Value));
			}

			//// ユーザ情報反映
			//foreach (var user in this._Twitter.User)
			//{
			//	var parentItem = this.ResultView.Items.Add(user.Id);
			//	parentItem.SubItems.Add(user.ServiceName);

			//	foreach (var file in user.FileName)
			//		parentItem.SubItems.Add(file);

			//	parentItem.SubItems.Add(user.Progress);
			//	parentItem.SubItems.Add(user.Status);
			//}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private async Task GetFavoriteSongsListAsync()
		{
			var connection = this._SCUsers.GetRequestMessage();

			var response = await this._Client.SendAsync(connection);

			var resString = await response.Content.ReadAsStringAsync();
			resString = resString.Replace("large", "t500x500");

			this._Favorite = JsonConvert.DeserializeObject<List<SCFavoriteObjects>>(resString);
		}

		#endregion Private Methods
	}
}
