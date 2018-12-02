using Claudia.SoundCloud.EndPoints;
using Claudia.Utility;
using Legato;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
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
		private AimpProperties _Properties { get; set; } = new AimpProperties();
		private AimpCommands _Commands { get; set; } = new AimpCommands();
		private WindowsMediaPlayer _WMP { get; set; } = new WindowsMediaPlayer();
		private SoundCloud.SoundCloud _SoundCloud { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private int _Count { get; set; } = 0;
		private bool _IsPlay { get; set; } = false;
		private System.Timers.Timer _Timer { get; set; } = new System.Timers.Timer(1000);

		/// <summary>
		/// 
		/// </summary>
		private bool _IsAIMP4Checked { get; set; } = false;
		private bool _IsWMPChecked { get; set; } = false;
		private bool _IsMusicBeeChecked { get; set; } = false;

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
			var player = new SelectPlayerForm(this._IsAIMP4Checked, this._IsWMPChecked, this._IsMusicBeeChecked);
			if (player.ShowDialog() == DialogResult.OK)
			{
				this._IsAIMP4Checked = player.IsAIMP4Checked;
				this._IsWMPChecked = player.IsWMPChecked;
				this._IsMusicBeeChecked = player.IsMusicBeeChecked;
			}

			var settings = Properties.Settings.Default;
			var clientId = (string)settings["ClientId"] ?? string.Empty;
			var token = (string)settings["Token"] ?? string.Empty;

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(token))
			{
				this.statusLbl.Text = $"Login: No - Token: Acquired...";
				this.LoginButton.Enabled = false;
				this._SoundCloud = new SoundCloud.SoundCloud(token, clientId, HttpMethod.Get);
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
				var track = this._SoundCloud.Likes[this._Count];
				var artUrl = track.ArtworkUrl;
				var title = track.Title;
				var artist = track.User.UserName;
				var duration = Common.GetCurrentTrackPosition(track.Duration);

				new MiniForm(this, artUrl, title, artist, duration).Show();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this._Properties.IsRunning) this._Commands.Close();
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
					settings["ClientId"] = form.ClientId;
					settings["Token"] = form.Token;
					settings.Save();

					this.LoginButton.Enabled = false;
					this.statusLbl.Text = $"Login: Yes - Token: Acquired...";
					this._SoundCloud = new SoundCloud.SoundCloud(form.Token, form.ClientId, HttpMethod.Get);
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
		private void StreamButton_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayListsButton_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LikesButton_Click(object sender, EventArgs e)
		{
			await this._SoundCloud.GetFavoriteSongsListAsync();
			await this._CreateArtworksAsync();
			await this._DefaultViewAlbumListAsync(this._SoundCloud.Likes.Count);

			var track = this._SoundCloud.Likes[this._Count];
			var nextTrack = this._SoundCloud.Likes[this._Count + 1];

			this.NextAlbumArt.Image = Common.LoadImageFromUrl(nextTrack.ArtworkUrl) ?? Properties.Resources.none;
			this.NextTrack.Text = nextTrack.Title;

			var data = this._SoundCloud.Likes.Where(x => x.StreamUrl != null).ToArray();
			for (int i = 0; i < data.Length; i++)
			{
				var url = $"{data[i].StreamUrl}?client_id={this._SoundCloud.ClientId}";
				Console.WriteLine($"TrackInfo[{i}] : {data[i].Title} - {url}");
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
				var track = this._SoundCloud.Likes[this._Count];
				this._IsPlay = true;

				this.barArt.Image = Common.LoadImageFromUrl(track.ArtworkUrl) ?? Properties.Resources.none;
				this.barTrackInfo.Text = $"{track.Title} - {track.User.UserName}";
				this.TrackDuration.Text = Common.GetCurrentTrackPosition(track.Duration);
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


		//private async void Twitter_ButtonClick(object sender, EventArgs e)
		//{
		//	var track = this._SoundCloud.Likes[this._Count];

		//	var tw = new StringBuilder();
		//	tw.Append($"🎵 {track.Title}\r\n");
		//	tw.Append($"🎙 {track.User.UserName}\r\n");
		//	tw.Append("💿 Likes\r\n");
		//	tw.Append("#nowplaying #Claudia");

		//	var image = Common.LoadImageFromUrl(track.ArtworkUrl);
		//	await this._Twitter.UpdateWithTextAsync(tw.ToString());
		//}

		private void VolumeBar_Scroll(object sender, EventArgs e)
		{
			this._WMP.settings.volume = this.VolumeBar.Value;
		}

		#endregion Event Methods

		#region Private Methods

		/// <summary>
		/// Claudia メイン画面のアルバムアート一覧
		/// </summary>
		/// <returns></returns>
		private async Task _DefaultViewAlbumListAsync(int count)
		{
			await Task.Run(() =>
			{
				foreach (var i in  Enumerable.Range(0, this._SoundCloud.Likes.Count))
				{
					var artwork = (PictureBox)this.artPanel.Controls[$"art{i + 1}"];
					artwork.Image = Common.LoadImageFromUrl(this._SoundCloud.Likes[i].ArtworkUrl) ?? Properties.Resources.none;
				}
			});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private async Task _CreateArtworksAsync()
		{
			this.Invoke((MethodInvoker)(() =>
			{
				foreach (var i in Enumerable.Range(0, this._SoundCloud.Likes.Count))
				{
					var pictureBox = new PictureBox
					{
						Name = $"art{i + 1}",
						Size = new Size(135, 134),
						SizeMode = PictureBoxSizeMode.Zoom,
					};

					pictureBox.Click += (s, ev) =>
					{
						this._ArtworkLists(i);
						this._Count = i;
					};

					this.artPanel.Controls.Add(pictureBox);
				}
			}));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		private void _ArtworkLists(int position)
		{
			this._UpdateCurrentPosition();

			var track = this._SoundCloud.Likes[position];
			this.SelectArt.ImageLocation = track.ArtworkUrl ?? string.Empty;
			this.SelectTrack.Text = track.Title;

			this.barArt.Image = Common.LoadImageFromUrl(track.ArtworkUrl) ?? Properties.Resources.none;
			this.barTrackInfo.Text = $"{track.Title} - {track.User.UserName}";
			this.TrackDuration.Text = Common.GetCurrentTrackPosition(track.Duration);

			this._StartStreaming(track);
		}

		/// <summary>
		/// 
		/// </summary>
		private void _UpdateCurrentPosition()
		{
			if (this._WMP != null)
			{
				this._Timer.Elapsed += (s, ev) =>
					this.Invoke((MethodInvoker)(() => this.TrackDuration.Text = this._WMP.controls.currentPositionString));
			}

			this._Timer.Start();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		private void _NextTrackInfo(int position)
		{
			var nextTrack = this._SoundCloud.Likes[position + 1];
			this.NextAlbumArt.Image = Common.LoadImageFromUrl(nextTrack.ArtworkUrl) ?? Properties.Resources.none;
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
				Process.Start(_Properties.AimpProcessPath, $"{track.Uri}/stream?client_id={this._SoundCloud.ClientId}");
			}
			else if (this._IsWMPChecked)
			{
				this._WMP.URL = $"{track.Uri}/stream?client_id={this._SoundCloud.ClientId}";
				this._WMP.controls.play();
			}
			else
			{
				// TODO : MusicBee
			}

			Console.WriteLine($"play is = {track.Title} - {track.Uri}/stream?client_id={this._SoundCloud.ClientId}");
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

		#endregion Private Methods
	}
}
