using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Claudia.SoundCloud;
using Claudia.SoundCloud.Urls;
using Claudia.Utility;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Claudia
{
	public partial class MainForm : Form
	{
		private string ClientId { get; set; } = string.Empty;
		private string Token { get; set; } = string.Empty;
		private HttpClient Client { get; set; } = new HttpClient();
		private List<SCFavorite> Favorite { get; set; } = new List<SCFavorite>();

		public MainForm()
		{
			this.InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this._InitializeResultView();
		}

		private async void AccessButton_Click(object sender, EventArgs e)
		{
			await this.GetTracks();
			this.pictureBox1.ImageLocation = this.Favorite[0].ArtworkUrl ?? string.Empty;
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.Token))
			{
				var form = new LoginForm();
				if (form.ShowDialog() == DialogResult.OK)
				{
					this.ClientId = form.ClientId;
					this.Token = form.Token;
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
		}

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

		private async Task GetTracks()
		{
			var t = this.Token.Split('-');
			var userId = t[2];
			var req = new HttpRequestMessage(HttpMethod.Get, $"{EndPoints.Users}{userId}/favorites");
			req.Headers.Add("Authorization", $"OAuth {this.Token}");

			var response = await this.Client.SendAsync(req);
			var resString = await response.Content.ReadAsStringAsync();

			this.Favorite = JsonConvert.DeserializeObject<List<SCFavorite>>(resString);

			//foreach (var f in fav)
			//{
			//	Console.WriteLine(f.Title);
			//	Console.WriteLine(f.Uri);
			//	Console.WriteLine(f.ArtworkUrl);
			//	Console.WriteLine(f.Genre);
			//	Console.WriteLine(f.LikesCount);
			//	this.ArtworkUrl = f.ArtworkUrl;
			//}
		}
	}
}
