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
		private List<SCFavoriteObjects> _Likes { get; set; } = new List<SCFavoriteObjects>();

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
			var settings = Properties.Settings.Default;
			var clientId = (string)settings["ClientId"] ?? string.Empty;
			var token = (string)settings["Token"] ?? string.Empty;

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(token))
			{
				this._ClientId = (string)settings["ClientId"];
				this._Token = (string)settings["Token"];

				this.statusLbl.Text = $"Login: No - Token: Acquired...";
				this.LoginButton.Enabled = false;
				this._SCUsers = new SCUsers(this._Token, this._ClientId, HttpMethod.Get);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginButton_Click(object sender, EventArgs e)
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

					this.LoginButton.Enabled = false;
					this.statusLbl.Text = $"Login: Yes - Token: Acquired...";
					this._SCUsers = new SCUsers(this._Token, this._ClientId, HttpMethod.Get);
				}
			}
		}

		private async void LikesButton_Click(object sender, EventArgs e)
		{
			await this.GetFavoriteSongsListAsync();
			await this.DefaultViewAlbumListAsync();

			var track = this._Likes[this.Count];
			var nextTrack = this._Likes[this.Count + 1];

			this.art1.ImageLocation = track.ArtworkUrl ?? string.Empty;
			this.NextAlbumArt.ImageLocation = nextTrack.ArtworkUrl ?? string.Empty;
			this.NextTrack.Text = nextTrack.Title;

			var data = this._Likes.Where(x => x.StreamUrl != null).ToArray();
			foreach (var item in data.Select((value, idx) => new { value, idx }))
			{
				var url = $"{item.value.StreamUrl}?client_id={this._ClientId}";
				Console.WriteLine($"TrackInfo[{item.idx}] : {item.value.Title} - {url}");
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
				var track = this._Likes[this.Count];

				this.nowState = State.Playing;
				this._IsPlay = true;

				this.barArt.ImageLocation = track.ArtworkUrl ?? string.Empty;
				this.barTrackInfo.Text = $"{track.Title} - {track.User.UserName}";
				this.TrackDuration.Text = this.GetCurrentTrackDuration(track.Duration);
				this.PlayButton.Image = Properties.Resources.pause;

				this._StartStreaming(track);
			}
			else
			{
				this.nowState = State.Playpause;
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
			this._ArtworkLists(this.Count);
			this._NextTrackInfo(this.Count);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextButton_Click(object sender, EventArgs e)
		{
			this.Count++;
			this._ArtworkLists(this.Count);
			this._NextTrackInfo(this.Count);
		}

		#region Artwork ClickEvents

		private void art1_Click(object sender, EventArgs e) { }
		private void art2_Click(object sender, EventArgs e) => this._ArtworkLists(2);
		private void art3_Click(object sender, EventArgs e) => this._ArtworkLists(3);
		private void art4_Click(object sender, EventArgs e) => this._ArtworkLists(4);
		private void art5_Click(object sender, EventArgs e) => this._ArtworkLists(5);
		private void art6_Click(object sender, EventArgs e) => this._ArtworkLists(6);
		private void art7_Click(object sender, EventArgs e) => this._ArtworkLists(7);
		private void art8_Click(object sender, EventArgs e) => this._ArtworkLists(8);
		private void art9_Click(object sender, EventArgs e) => this._ArtworkLists(9);
		private void art10_Click(object sender, EventArgs e) => this._ArtworkLists(10);
		private void art11_Click(object sender, EventArgs e) => this._ArtworkLists(11);
		private void art12_Click(object sender, EventArgs e) => this._ArtworkLists(12);
		private void art13_Click(object sender, EventArgs e) => this._ArtworkLists(13);
		private void art14_Click(object sender, EventArgs e) => this._ArtworkLists(14);
		private void art15_Click(object sender, EventArgs e) => this._ArtworkLists(15);
		private void art16_Click(object sender, EventArgs e) => this._ArtworkLists(16);
		private void art17_Click(object sender, EventArgs e) => this._ArtworkLists(17);
		private void art18_Click(object sender, EventArgs e) => this._ArtworkLists(18);
		private void art19_Click(object sender, EventArgs e) => this._ArtworkLists(19);
		private void art20_Click(object sender, EventArgs e) => this._ArtworkLists(20);
		private void art21_Click(object sender, EventArgs e) => this._ArtworkLists(21);
		private void art22_Click(object sender, EventArgs e) => this._ArtworkLists(22);
		private void art23_Click(object sender, EventArgs e) => this._ArtworkLists(23);
		private void art24_Click(object sender, EventArgs e) => this._ArtworkLists(24);
		private void art25_Click(object sender, EventArgs e) => this._ArtworkLists(25);
		private void art26_Click(object sender, EventArgs e) => this._ArtworkLists(26);
		private void art27_Click(object sender, EventArgs e) => this._ArtworkLists(27);
		private void art28_Click(object sender, EventArgs e) => this._ArtworkLists(28);

		#endregion Artwork ClickEvents

		#endregion Event Methods

		#region Private Methods

		/// <summary>
		/// Claudia メイン画面のアルバムアート一覧
		/// </summary>
		/// <returns></returns>
		private async Task DefaultViewAlbumListAsync()
		{
			this.art2.ImageLocation = this._Likes[2].ArtworkUrl ?? string.Empty;
			this.art3.ImageLocation = this._Likes[3].ArtworkUrl ?? string.Empty;
			this.art4.ImageLocation = this._Likes[4].ArtworkUrl ?? string.Empty;
			this.art5.ImageLocation = this._Likes[5].ArtworkUrl ?? string.Empty;
			this.art6.ImageLocation = this._Likes[6].ArtworkUrl ?? string.Empty;
			this.art7.ImageLocation = this._Likes[7].ArtworkUrl ?? string.Empty;
			this.art8.ImageLocation = this._Likes[8].ArtworkUrl ?? string.Empty;
			this.art9.ImageLocation = this._Likes[9].ArtworkUrl ?? string.Empty;
			this.art10.ImageLocation = this._Likes[10].ArtworkUrl ?? string.Empty;
			this.art11.ImageLocation = this._Likes[11].ArtworkUrl ?? string.Empty;
			this.art12.ImageLocation = this._Likes[12].ArtworkUrl ?? string.Empty;
			this.art13.ImageLocation = this._Likes[13].ArtworkUrl ?? string.Empty;
			this.art14.ImageLocation = this._Likes[14].ArtworkUrl ?? string.Empty;
			this.art15.ImageLocation = this._Likes[15].ArtworkUrl ?? string.Empty;
			this.art16.ImageLocation = this._Likes[16].ArtworkUrl ?? string.Empty;
			this.art17.ImageLocation = this._Likes[17].ArtworkUrl ?? string.Empty;
			this.art18.ImageLocation = this._Likes[18].ArtworkUrl ?? string.Empty;
			this.art19.ImageLocation = this._Likes[19].ArtworkUrl ?? string.Empty;
			this.art20.ImageLocation = this._Likes[20].ArtworkUrl ?? string.Empty;
			this.art21.ImageLocation = this._Likes[21].ArtworkUrl ?? string.Empty;
			this.art20.ImageLocation = this._Likes[20].ArtworkUrl ?? string.Empty;
			this.art21.ImageLocation = this._Likes[21].ArtworkUrl ?? string.Empty;
			this.art22.ImageLocation = this._Likes[22].ArtworkUrl ?? string.Empty;
			this.art23.ImageLocation = this._Likes[23].ArtworkUrl ?? string.Empty;
			this.art24.ImageLocation = this._Likes[24].ArtworkUrl ?? string.Empty;
			this.art25.ImageLocation = this._Likes[25].ArtworkUrl ?? string.Empty;
			this.art26.ImageLocation = this._Likes[26].ArtworkUrl ?? string.Empty;
			this.art27.ImageLocation = this._Likes[27].ArtworkUrl ?? string.Empty;
			this.art28.ImageLocation = this._Likes[28].ArtworkUrl ?? string.Empty;
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
			this._Likes.AddRange(pagenation.Collection);

			// TODO : 次取得
			var nextUrl = pagenation.NextHref;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		private void _ArtworkLists(int position)
		{
			var track = this._Likes[position];
			this.SelectArt.ImageLocation = track.ArtworkUrl ?? string.Empty;
			this.SelectTrack.Text = track.Title;

			this.barArt.ImageLocation = track.ArtworkUrl ?? string.Empty;
			this.barTrackInfo.Text = $"{track.Title} - {track.User.UserName}";
			this.TrackDuration.Text = this.GetCurrentTrackDuration(track.Duration);

			this._StartStreaming(track);
		}

		private void _NextTrackInfo(int position)
		{
			var nextTrack = this._Likes[position + 1];
			this.NextAlbumArt.ImageLocation = nextTrack.ArtworkUrl ?? string.Empty;
			this.NextTrack.Text = nextTrack.Title;
		}

		private void _StartStreaming(SCFavoriteObjects track)
		{
			Process.Start(_Properties.AimpProcessPath, $"{track.Uri}/stream?client_id={this._ClientId}");
			Console.WriteLine($"play is = {track.Title} - {track.Uri}/stream?client_id={this._ClientId}");
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

		#endregion Private Methods
	}
}
