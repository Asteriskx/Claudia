using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Users;
using Newtonsoft.Json;
using Legato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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

		/// <summary>
		/// 
		/// </summary>
		private Dictionary<int, Dictionary<string, string>> _FavTrack { get; set; } = new Dictionary<int, Dictionary<string, string>>();

		/// <summary>
		/// 
		/// </summary>
		private int Count { get; set; } = 0;

		/// <summary>
		/// 
		/// </summary>
		private bool _IsPlay { get; set; } = false;

		/// <summary>
		/// 
		/// </summary>
		private enum State { Idle = 0, Playing, Playpause, Stop }
		private State nowState = State.Idle;
		private State oldState = State.Idle;

		/// <summary>
		/// 
		/// </summary>
		private AimpProperties _Properties { get; set; } = new AimpProperties();

		/// <summary>
		/// 
		/// </summary>
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
				this._ClientId = (string)settings["ClientId"];
				this._Token = (string)settings["Token"];

				this.statusLbl.Text = $"Login: No - Token: Acquired...";
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
			await this.DefaultViewAlbumListAsync();

			this.art1.ImageLocation = this._Favorite[Count].ArtworkUrl ?? string.Empty;
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

					this.loginButton.Enabled = false;
					this.statusLbl.Text = $"Login: Yes - Token: Acquired...";
					this._SCUsers = new SCUsers(this._Token, this._ClientId, HttpMethod.Get);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayButton_Click(object sender, EventArgs e)
		{
			if (!this._IsPlay)
			{
				nowState = State.Playing;

				foreach (var track in this._FavTrack[Count])
				{
					Console.WriteLine($"play is = {track.Key} - {track.Value}");
					Process.Start(_Properties.AimpProcessPath, track.Value);
				}

				this.barArt.ImageLocation = this._Favorite[Count].ArtworkUrl ?? string.Empty;
				this.barTrackInfo.Text = $"{this._Favorite[Count].Title} - {this._Favorite[Count].User.UserName}";
				this.TrackDuration.Text = this.GetCurrentTrackDuration(this._Favorite[this.Count].Duration);
				this.PlayButton.Image = Properties.Resources.pause;
				this._IsPlay = true;
			}
			else
			{
				nowState = State.Playpause;
				this._Commands.PlayPause();
				this.PlayButton.Image = Properties.Resources.play;
				this._IsPlay = false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrevButton_Click(object sender, EventArgs e)
		{
			this.Count--;
			foreach (var track in this._FavTrack[this.Count])
			{
				this.art1.ImageLocation = this._Favorite[Count].ArtworkUrl ?? string.Empty;
				this.NextAlbumArt.ImageLocation = this._Favorite[Count + 1].ArtworkUrl ?? string.Empty;
				this.NextTrack.Text = this._Favorite[this.Count + 1].Title;

				Console.WriteLine($"play is = {track.Key} - {track.Value}");
				Process.Start(_Properties.AimpProcessPath, track.Value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextButton_Click(object sender, EventArgs e)
		{
			this.Count++;
			foreach (var track in this._FavTrack[this.Count])
			{
				this.art1.ImageLocation = this._Favorite[Count].ArtworkUrl ?? string.Empty;
				this.NextAlbumArt.ImageLocation = this._Favorite[Count + 1].ArtworkUrl ?? string.Empty;
				this.NextTrack.Text = this._Favorite[this.Count + 1].Title;

				Console.WriteLine($"play is = {track.Key} - {track.Value}");
				Process.Start(_Properties.AimpProcessPath, track.Value);
			}
		}

		#region Artwork ClickEvents

		private void art1_Click(object sender, EventArgs e) { }
		private void art2_Click(object sender, EventArgs e) => this.ArtworkData(2);
		private void art3_Click(object sender, EventArgs e) => this.ArtworkData(3);
		private void art4_Click(object sender, EventArgs e) => this.ArtworkData(4);
		private void art5_Click(object sender, EventArgs e) => this.ArtworkData(5);
		private void art6_Click(object sender, EventArgs e) => this.ArtworkData(6);
		private void art7_Click(object sender, EventArgs e) => this.ArtworkData(7);
		private void art8_Click(object sender, EventArgs e) => this.ArtworkData(8);
		private void art9_Click(object sender, EventArgs e) => this.ArtworkData(9);
		private void art10_Click(object sender, EventArgs e) => this.ArtworkData(10);
		private void art11_Click(object sender, EventArgs e) => this.ArtworkData(11);
		private void art12_Click(object sender, EventArgs e) => this.ArtworkData(12);
		private void art13_Click(object sender, EventArgs e) => this.ArtworkData(13);
		private void art14_Click(object sender, EventArgs e) => this.ArtworkData(14);
		private void art15_Click(object sender, EventArgs e) => this.ArtworkData(15);
		private void art16_Click(object sender, EventArgs e) => this.ArtworkData(16);
		private void art17_Click(object sender, EventArgs e) => this.ArtworkData(17);
		private void art18_Click(object sender, EventArgs e) => this.ArtworkData(18);
		private void art19_Click(object sender, EventArgs e) => this.ArtworkData(19);
		private void art20_Click(object sender, EventArgs e) => this.ArtworkData(20);
		private void art21_Click(object sender, EventArgs e) => this.ArtworkData(21);
		private void art22_Click(object sender, EventArgs e) => this.ArtworkData(22);
		private void art23_Click(object sender, EventArgs e) => this.ArtworkData(23);
		private void art24_Click(object sender, EventArgs e) => this.ArtworkData(24);
		private void art25_Click(object sender, EventArgs e) => this.ArtworkData(25);
		private void art26_Click(object sender, EventArgs e) => this.ArtworkData(26);
		private void art27_Click(object sender, EventArgs e) => this.ArtworkData(27);
		private void art28_Click(object sender, EventArgs e) => this.ArtworkData(28);

		#endregion Artwork ClickEvents

		#endregion Event Methods

		#region Public Methods

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// 取得リストビューの初期設定を行います。
		/// </summary>
		private void _InitializeResultView()
		{
			//// ヘッダ情報・ヘッダ幅
			//var data = new Dictionary<string, int>()
			//{
			//	{ "トラック名", 150 },
			//	{ "アーティスト名", 150 },
			//	{ "アルバム名", 200 },
			//	{ "再生回数", 100 },
			//	{ "お気に入り数", 100 }
			//};

			//this.ResultView.FullRowSelect = true;
			//this.ResultView.GridLines = true;
			//this.ResultView.Sorting = SortOrder.Ascending;
			//this.ResultView.View = View.Details;

			//// ヘッダ追加
			//foreach (var kvp in data)
			//{
			//	this.ResultView.Columns.Add(ColumnHeaderEx.GetColumnHeader(kvp.Key, kvp.Value));
			//}

			////// ユーザ情報反映
			////foreach (var user in this._Twitter.User)
			////{
			////	var parentItem = this.ResultView.Items.Add(user.Id);
			////	parentItem.SubItems.Add(user.ServiceName);

			////	foreach (var file in user.FileName)
			////		parentItem.SubItems.Add(file);

			////	parentItem.SubItems.Add(user.Progress);
			////	parentItem.SubItems.Add(user.Status);
			////}
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

		/// <summary>
		/// 再生している曲の長さを取得します。
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		private string GetCurrentTrackDuration(int position)
		{
			var totalSec = position / 1000;
			var min = totalSec / 60;
			var sec = totalSec % 60;
			return $"{min:D2}:{sec:D2}";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		private void ArtworkData(int position)
		{
			foreach (var track in this._FavTrack[position])
			{
				this.SelectArt.ImageLocation = this._Favorite[position].ArtworkUrl ?? string.Empty;
				this.SelectTrack.Text = this._Favorite[position].Title;

				this.barArt.ImageLocation = this._Favorite[position].ArtworkUrl ?? string.Empty;
				this.barTrackInfo.Text = $"{this._Favorite[position].Title} - {this._Favorite[position].User.UserName}";
				this.TrackDuration.Text = this.GetCurrentTrackDuration(this._Favorite[position].Duration);

				Console.WriteLine($"play is = {track.Key} - {track.Value}");
				Process.Start(_Properties.AimpProcessPath, track.Value);
			}
		}

		/// <summary>
		/// Claudia メイン画面のアルバムアート一覧
		/// </summary>
		/// <returns></returns>
		private async Task DefaultViewAlbumListAsync()
		{
			this.art2.ImageLocation = this._Favorite[2].ArtworkUrl ?? string.Empty;
			this.art3.ImageLocation = this._Favorite[3].ArtworkUrl ?? string.Empty;
			this.art4.ImageLocation = this._Favorite[4].ArtworkUrl ?? string.Empty;
			this.art5.ImageLocation = this._Favorite[5].ArtworkUrl ?? string.Empty;
			this.art6.ImageLocation = this._Favorite[6].ArtworkUrl ?? string.Empty;
			this.art7.ImageLocation = this._Favorite[7].ArtworkUrl ?? string.Empty;
			this.art8.ImageLocation = this._Favorite[8].ArtworkUrl ?? string.Empty;
			this.art9.ImageLocation = this._Favorite[9].ArtworkUrl ?? string.Empty;
			this.art10.ImageLocation = this._Favorite[10].ArtworkUrl ?? string.Empty;
			this.art11.ImageLocation = this._Favorite[11].ArtworkUrl ?? string.Empty;
			this.art12.ImageLocation = this._Favorite[12].ArtworkUrl ?? string.Empty;
			this.art13.ImageLocation = this._Favorite[13].ArtworkUrl ?? string.Empty;
			this.art14.ImageLocation = this._Favorite[14].ArtworkUrl ?? string.Empty;
			this.art15.ImageLocation = this._Favorite[15].ArtworkUrl ?? string.Empty;
			this.art16.ImageLocation = this._Favorite[16].ArtworkUrl ?? string.Empty;
			this.art17.ImageLocation = this._Favorite[17].ArtworkUrl ?? string.Empty;
			this.art18.ImageLocation = this._Favorite[18].ArtworkUrl ?? string.Empty;
			this.art19.ImageLocation = this._Favorite[19].ArtworkUrl ?? string.Empty;
			this.art20.ImageLocation = this._Favorite[20].ArtworkUrl ?? string.Empty;
			this.art21.ImageLocation = this._Favorite[21].ArtworkUrl ?? string.Empty;
			this.art20.ImageLocation = this._Favorite[20].ArtworkUrl ?? string.Empty;
			this.art21.ImageLocation = this._Favorite[21].ArtworkUrl ?? string.Empty;
			this.art22.ImageLocation = this._Favorite[22].ArtworkUrl ?? string.Empty;
			this.art23.ImageLocation = this._Favorite[23].ArtworkUrl ?? string.Empty;
			this.art24.ImageLocation = this._Favorite[24].ArtworkUrl ?? string.Empty;
			this.art25.ImageLocation = this._Favorite[25].ArtworkUrl ?? string.Empty;
			this.art26.ImageLocation = this._Favorite[26].ArtworkUrl ?? string.Empty;
			this.art27.ImageLocation = this._Favorite[27].ArtworkUrl ?? string.Empty;
			this.art28.ImageLocation = this._Favorite[28].ArtworkUrl ?? string.Empty;
		}

		#endregion Private Methods
	}
}
