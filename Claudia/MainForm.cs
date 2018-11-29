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
using System.Reflection;
using WMPLib;

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
		private int _Count { get; set; } = 0;

		/// <summary>
		/// 
		/// </summary>
		private bool _IsPlay { get; set; } = false;

		/// <summary>
		/// AIMP4
		/// </summary>
		private bool _IsAIMP4Checked { get; set; } = false;

		/// <summary>
		/// Windows Media Player
		/// </summary>
		private bool _IsWMPChecked { get; set; } = false;

		/// <summary>
		/// MusicBee
		/// </summary>
		private bool _IsMusicBeeChecked { get; set; } = false;

		/// <summary>
		/// 
		/// </summary>
		private static readonly int _ArtworkNum = 28;

		/// <summary>
		/// 
		/// </summary>
		private AimpProperties _Properties { get; set; } = new AimpProperties();

		/// <summary>
		/// 
		/// </summary>
		private AimpCommands _Commands { get; set; } = new AimpCommands();

		/// <summary>
		/// 
		/// </summary>
		private WindowsMediaPlayer _WMP { get; set; } = new WindowsMediaPlayer();

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
			foreach (var i in Enumerable.Range(0, _ArtworkNum))
			{
				var artwork = (PictureBox)_FindControlByFieldName(this, $"art{i + 1}");
				artwork.Click += (s, v) => this._ArtworkLists(i);
			}

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
		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				var track = this._Likes[this._Count];
				new MiniWindow(track.ArtworkUrl, track.Title, track.User.UserName, this.GetCurrentTrackDuration(track.Duration)).Show();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._Commands.Close();
			this._WMP.close();
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayerButton_Click(object sender, EventArgs e)
		{
			// CurrentTrack Pausing...
			if (this._IsAIMP4Checked)
			{
				this._Commands.PlayPause();
			}
			else if (this._IsWMPChecked)
			{
				this._WMP.controls.pause();
			}
			else
			{
				// TODO : MusicBee
			}

			var player = new SelectPlayerForm(this._IsAIMP4Checked, this._IsWMPChecked, this._IsMusicBeeChecked);
			if (player.ShowDialog() == DialogResult.OK)
			{
				this._IsAIMP4Checked = player.IsAIMP4Checked;
				this._IsWMPChecked = player.IsWMPChecked;
				this._IsMusicBeeChecked = player.IsMusicBeeChecked;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LikesButton_Click(object sender, EventArgs e)
		{
			await this.GetFavoriteSongsListAsync();
			await this.DefaultViewAlbumListAsync(_ArtworkNum);

			var track = this._Likes[this._Count];
			var nextTrack = this._Likes[this._Count + 1];

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
				var track = this._Likes[this._Count];
				this._IsPlay = true;

				this.barArt.ImageLocation = track.ArtworkUrl ?? string.Empty;
				this.barTrackInfo.Text = $"{track.Title} - {track.User.UserName}";
				this.TrackDuration.Text = this.GetCurrentTrackDuration(track.Duration);
				this.PlayButton.Image = Properties.Resources.pause;

				this._StartStreaming(track);
			}
			else
			{
				this._PauseStreaming();
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
			this._Count--;
			this._ArtworkLists(this._Count);
			this._NextTrackInfo(this._Count);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextButton_Click(object sender, EventArgs e)
		{
			this._Count++;
			this._ArtworkLists(this._Count);
			this._NextTrackInfo(this._Count);
		}

		#endregion Event Methods

		#region Private Methods

		/// <summary>
		/// Claudia メイン画面のアルバムアート一覧
		/// </summary>
		/// <returns></returns>
		private async Task DefaultViewAlbumListAsync(int count)
		{
			foreach (var i in Enumerable.Range(0, count))
			{
				var artwork = (PictureBox)_FindControlByFieldName(this, $"art{i + 1}");
				artwork.ImageLocation = this._Likes[i].ArtworkUrl ?? string.Empty;
			}
		}

		/// <summary>
		/// フォームに配置されているコントロールを名前で検索します
		/// </summary>
		/// <param name="form">コントロールを探すフォーム</param>
		/// <param name="name">コントロール（フィールド）の名前</param>
		/// <returns>見つかった時は、コントロールのオブジェクト。
		/// 見つからなかった時は、null </returns>
		private static object _FindControlByFieldName(Form form, string name)
		{
			Type t = form.GetType();
			FieldInfo fi = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			return fi?.GetValue(form);
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		private void _NextTrackInfo(int position)
		{
			var nextTrack = this._Likes[position + 1];
			this.NextAlbumArt.ImageLocation = nextTrack.ArtworkUrl ?? string.Empty;
			this.NextTrack.Text = nextTrack.Title;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="track"></param>
		private void _StartStreaming(SCFavoriteObjects track)
		{
			if (this._IsAIMP4Checked)
			{
				Process.Start(_Properties.AimpProcessPath, $"{track.Uri}/stream?client_id={this._ClientId}");
			}
			else if (this._IsWMPChecked)
			{
				this._WMP.URL = $"{track.Uri}/stream?client_id={this._ClientId}";
				this._WMP.controls.play();
			}
			else
			{
				// TODO : MusicBee
			}

			Console.WriteLine($"play is = {track.Title} - {track.Uri}/stream?client_id={this._ClientId}");
		}

		/// <summary>
		/// 
		/// </summary>
		private void _PauseStreaming()
		{
			if (this._IsAIMP4Checked)
			{
				this._Commands.PlayPause();
			}
			else if (this._IsWMPChecked)
			{
				this._WMP.controls.pause();
			}
			else
			{
				// TODO : MusicBee
			}
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
