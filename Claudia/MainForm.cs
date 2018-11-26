using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Users;
using Claudia.Utility;

using Newtonsoft.Json;

using Legato;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Drawing;

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

		private Dictionary<int, Dictionary<string, string>> _FavTrack { get; set; } = new Dictionary<int, Dictionary<string, string>>();

		private int Count { get; set; } = 0;

		private enum State { Idle = 0, Playing, Playpause, Stop }
		private State nowState = State.Idle;
		private State oldState = State.Idle;

		/// <summary>
		/// 
		/// </summary>
		private AimpProperties _Properties { get; set; } = new AimpProperties();

		private AimpCommands _Commands { get; set; } = new AimpCommands();

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
			var settings = Properties.Settings.Default;
			var clientId = (string)settings["ClientId"] ?? string.Empty;
			var token = (string)settings["Token"] ?? string.Empty;

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(token))
			{
				this.loginInfo.Text = "Not Login...";
				this.tokenInfo.Text = "Token acquired...";

				this._ClientId = (string)settings["ClientId"];
				this._Token = (string)settings["Token"];

				this.loginButton.Enabled = false;
				this._SCUsers = new SCUsers(this._Token, this._ClientId, HttpMethod.Get);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void AccessButton_Click(object sender, EventArgs e)
		{
			await this.GetFavoriteSongsListAsync();

			this.pictureBox1.ImageLocation = this._Favorite[Count].ArtworkUrl ?? string.Empty;
			this.NextAlbumArt.ImageLocation = this._Favorite[Count + 1].ArtworkUrl ?? string.Empty;
			this.NextTrack.Text = this._Favorite[this.Count + 1].Title;

			var data = this._Favorite.Where(x => x.StreamUrl != null).ToArray();
			foreach (var item in data.Select((value, idx) => new { value, idx }))
			{
				var url = $"{item.value.StreamUrl}?client_id={this._ClientId}";
				this._FavTrack.Add(item.idx, new Dictionary<string, string>() { { item.value.Title, url } });
				Console.WriteLine($"TrackInfo[{item.idx}] : {item.value.Title} - {url}");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loginButton_Click(object sender, EventArgs e)
		{
			var settings = Properties.Settings.Default;
			var clientId = (string)settings["ClientId"] ?? string.Empty;
			var token = (string)settings["Token"] ?? string.Empty;

			if (string.IsNullOrEmpty(clientId) && string.IsNullOrEmpty(token))
			{
				var form = new LoginForm();
				if (form.ShowDialog() == DialogResult.OK)
				{
					this._ClientId = form.ClientId;
					this._Token = form.Token;

					settings["ClientId"] = this._ClientId;
					settings["Token"] = this._Token;
					settings.Save();

					this.loginInfo.Text = "ログイン完了";
					this.tokenInfo.Text = "トークン取得完了";
					this.loginButton.Enabled = false;

					this._SCUsers = new SCUsers(this._Token, this._ClientId, HttpMethod.Get);
				}
			}
		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			foreach (var track in this._FavTrack[Count])
			{
				Console.WriteLine($"play is = {track.Key} - {track.Value}");
				Process.Start(_Properties.AimpProcessPath, track.Value);
			}

			var trackInfo = new StringBuilder();
			trackInfo.Append($"Title : {this._Favorite[this.Count].Title}\r\n");
			trackInfo.Append($"Artist : {this._Favorite[this.Count].User.UserName}\r\n");

			var duration = this.GetCurrentTrackDuration(this._Favorite[this.Count].Duration);
			trackInfo.Append($"Duration : {duration}\r\n");

			trackInfo.Append($"Genre : {this._Favorite[this.Count].Genre}\r\n");
			this.TrackInfo.Text = trackInfo.ToString();

			nowState = State.Playing;
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			this._Commands.PlayPause();
			nowState = State.Playpause;
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			this.Count++;
			foreach (var track in this._FavTrack[this.Count])
			{
				this.pictureBox1.ImageLocation = this._Favorite[Count].ArtworkUrl ?? string.Empty;
				this.NextAlbumArt.ImageLocation = this._Favorite[Count + 1].ArtworkUrl ?? string.Empty;
				this.NextTrack.Text = this._Favorite[this.Count + 1].Title;

				Console.WriteLine($"play is = {track.Key} - {track.Value}");
				Process.Start(_Properties.AimpProcessPath, track.Value);
			}

			var trackInfo = new StringBuilder();

			trackInfo.Append($"Title : {this._Favorite[this.Count].Title}\r\n");
			trackInfo.Append($"Artist : {this._Favorite[this.Count].User.UserName}\r\n");

			var duration = this.GetCurrentTrackDuration(this._Favorite[this.Count].Duration);
			trackInfo.Append($"Duration : {duration}\r\n");

			trackInfo.Append($"Genre : {this._Favorite[this.Count].Genre}\r\n");

			this.TrackInfo.Text = trackInfo.ToString();
		}

		private void LikesButton_MouseHover(object sender, EventArgs e) => this.LikesButton.BackColor = Color.FromArgb(0, 64, 64);
		private void LikesButton_MouseLeave(object sender, EventArgs e) => this.LikesButton.BackColor = Color.Teal;

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

			var pagenation = JsonConvert.DeserializeObject<Pagenation<SCFavoriteObjects>>(resString);
			this._Favorite.AddRange(pagenation.Collection);

			// TODO : 次取得
			var nextUrl = pagenation.NextHref;

		}
		
		private string GetCurrentTrackDuration(int position)
		{
			var totalSec = position / 1000;
			var min = totalSec / 60;
			var sec = totalSec % 60;
			return $"{min:D2}:{sec:D2}";
		}

		#endregion Private Methods
	}
}
