using Claudia.Interop;
using Claudia.SoundCloud.EndPoints;
using Claudia.Utility;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
		
		private WindowsMediaPlayer _Wmp { get; set; } = new WindowsMediaPlayer();

		/// <summary>
		/// 
		/// </summary>
		public SoundCloud.SoundCloud SoundCloud { get; set; }
		private ClaudiaCommands _Commands { get; set; }
		private ClaudiaProperties _Properties { get; set; }
		private ClaudiaObserver _Observer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private MiniForm _NowPlaying { get; set; }
		private bool _IsGetLikes { get; set; } = false;

		#region Twitter

		private static readonly string _ck = "ck";
		private static readonly string _cs = "cs";
		private static readonly string _at = "at";
		private static readonly string _ats = "ats";

		private Twist.Twitter _Twitter { get; set; } = new Twist.Twitter(_ck, _cs, _at, _ats, new HttpClient(new HttpClientHandler()));

		#endregion Twitter

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
		private async void MainForm_Load(object sender, EventArgs e)
		{
			this._Properties = new ClaudiaProperties(this._Wmp);
			this._Observer = new ClaudiaObserver(this, this._Wmp);
			this._Commands = new ClaudiaCommands(this._Wmp, this._Properties, this._Observer);

			this._Observer.PositionPropertyChanged += _PositionPropertyChanged;
			this._Observer.CurrentTrackChanged += _CurrentTrackChanged;
			this._Observer.Initialize();

			this.DoubleBuffered = true;
			this._Wmp.settings.autoStart = true;
			this._Wmp.settings.volume = 20;
			this.VolumeValue.Text = $"{this._Wmp.settings.volume}%";

			var settings = Properties.Settings.Default;
			var clientId = (string)settings["ClientId"] ?? string.Empty;
			var token = (string)settings["Token"] ?? string.Empty;

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(token))
			{
				this.SoundCloud = new SoundCloud.SoundCloud(token, clientId, HttpMethod.Get);

				var url = await this.SoundCloud.GetLoginAvaterImageUrlAsync();
				this.LoginButton.BackgroundImage = Common.LoadImageFromUrl(url);
				this.LoginButton.Image = null;
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
				this._NowPlaying.Show();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._Observer.Dispose();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LoginButton_Click(object sender, EventArgs e)
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

					this.SoundCloud = new SoundCloud.SoundCloud(form.Token, form.ClientId, HttpMethod.Get);

					var url = await this.SoundCloud.GetLoginAvaterImageUrlAsync();
					this.LoginButton.BackgroundImage = Common.LoadImageFromUrl(url);
					this.LoginButton.Image = null;
				}
			}
			else
			{
				var profileUrl = await this.SoundCloud.GetProfileUrlAsync();
				Process.Start(profileUrl);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StreamButton_Click(object sender, EventArgs e) 
		{
			MessageBox.Show("Stream is Coming soon...", "Stream is Unimplemented!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayListsButton_Click(object sender, EventArgs e) 
		{
			MessageBox.Show("PlayList is Coming soon...", "PlayList is Unimplemented!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LikesButton_Click(object sender, EventArgs e)
		{
			// 現状は初回押下時のみ動作
			if (!this._IsGetLikes)
			{
				this._IsGetLikes = true;
				await this.SoundCloud.GetFavoriteSongsListAsync();
				await this._CreateArtworksAsync();
				await this._DefaultViewAlbumListAsync();

				var track = this.SoundCloud.Likes[this.SoundCloud.TrackNum];
				var nextTrack = this.SoundCloud.Likes[this.SoundCloud.TrackNum + 1];

				this.NextAlbumArt.Image = Common.LoadImageFromUrl(nextTrack.ArtworkUrl) ?? Properties.Resources.none;
				this.NextTrack.Text = nextTrack.Title;

				var data = this.SoundCloud.Likes.Where(x => x.StreamUrl != null).ToArray();
				for (int i = 0; i < data.Length; i++)
				{
					var url = $"{data[i].StreamUrl}?client_id={this.SoundCloud.ClientId}";
					Console.WriteLine($"TrackInfo[{i}] : {data[i].Title} - {url}");
				}

			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void PostButton_Click(object sender, EventArgs e)
		{
			var track = this.SoundCloud.Likes[this.SoundCloud.TrackNum];

			var tw = new StringBuilder();
			tw.Append($"🎵 {track.Title}\r\n");
			tw.Append($"🎙 {track.User.UserName}\r\n");
			tw.Append("💿 Likes\r\n");
			tw.Append("#nowplaying #Claudia #SoundCloud");

			using (var client = new WebClient())
			using (var stream = new MemoryStream(client.DownloadData(track.ArtworkUrl)))
				await _Twitter.UpdateWithMediaAsync(tw.ToString(), stream);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayButton_Click(object sender, EventArgs e)
		{
			if (!this._Properties.IsPlaying)
			{
				this._Properties.IsPlaying = true;

				var track = this.SoundCloud.Likes[this.SoundCloud.TrackNum];
				this.CurrentArtwork.Image = Common.LoadImageFromUrl(track.ArtworkUrl) ?? Properties.Resources.none;
				this.CurrentTrack.Text = $"{track.Title} - {track.User.UserName}";
				this.TrackDuration.Text = Common.GetCurrentTrackPositionToStr(track.Duration);
				this.PlayButton.Image = Properties.Resources.pause;

				this._Commands.Play(this.SoundCloud, track);
			}
			else
			{
				this._Commands.Pause();
				this.PlayButton.Image = Properties.Resources.play;
				this._Properties.IsPlaying = false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrevButton_Click(object sender, EventArgs e)
		{
			this.SoundCloud.TrackNum--;
			this._UpdateTrackInfo(this.SoundCloud.TrackNum);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextButton_Click(object sender, EventArgs e)
		{
			this.SoundCloud.TrackNum++;
			this._UpdateTrackInfo(this.SoundCloud.TrackNum);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void VolumeBar_Scroll(object sender, EventArgs e)
		{
			this._Properties.WmpVolume = this.VolumeBar.Value;
			this.VolumeValue.Text = $"{this.VolumeBar.Value}%";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CurrentPosition_Scroll(object sender, EventArgs e) { }

		#endregion Event Methods

		#region Private Methods

		/// <summary>
		/// Claudia メイン画面のアルバムアート一覧
		/// </summary>
		/// <returns></returns>
		private async Task _DefaultViewAlbumListAsync()
		{
			await Task.Run(() =>
			{
				foreach (var i in Enumerable.Range(0, this.SoundCloud.Likes.Count))
				{
					var artwork = (PictureBox)this.artPanel.Controls[$"art{i + 1}"];
					artwork.Image = Common.LoadImageFromUrl(this.SoundCloud.Likes[i].ArtworkUrl) ?? Properties.Resources.none;
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
				foreach (var i in Enumerable.Range(0, this.SoundCloud.Likes.Count))
				{
					var pictureBox = new PictureBox
					{
						Name = $"art{i + 1}",
						Size = new Size(135, 135),
						SizeMode = PictureBoxSizeMode.Zoom
					};

					pictureBox.Click += (s, ev) =>
					{
						this.SoundCloud.TrackNum = i;
						this._UpdateTrackInfo(this.SoundCloud.TrackNum);
					};

					this.artPanel.Controls.Add(pictureBox);
				}
			}));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idx"></param>
		private void _UpdateTrackInfo(int idx)
		{
			var track = this.SoundCloud.Likes[idx];
			var artUrl = Common.LoadImageFromUrl(track.ArtworkUrl);
			var duration = Common.GetCurrentTrackPositionToStr(track.Duration);

			this.CurrentArtwork.Image = artUrl ?? Properties.Resources.none;
			this.CurrentTrack.Text = $"{track.Title} ({duration})";
			this.CurrentArtist.Text = track.User.UserName;
			this.CurrentInfo.Text = $"Genre : {track.Genre ?? "-"} / Bpm : {track.Bpm ?? "-"} / LikesCount : {track.LikesCount}";
			this.TrackDuration.Text = duration;

			this._NowPlaying = new MiniForm(this, track.ArtworkUrl, track.Title, track.User.UserName, duration);

			var nextTrack = this.SoundCloud.Likes[idx + 1];
			this.NextAlbumArt.Image = Common.LoadImageFromUrl(nextTrack.ArtworkUrl) ?? Properties.Resources.none;
			this.NextTrack.Text = nextTrack.Title;
			this.NextArtist.Text = nextTrack.User.UserName;

			this.CurrentPosition.Maximum = Common.GetCurrentTrackPositionToInt(track.Duration);
			this._Commands.Play(this.SoundCloud, track);
			this.PlayButton.Image = Properties.Resources.pause;
		}

		/// <summary>
		/// 
		/// </summary>
		private void _PositionPropertyChanged() =>
			this.TrackDuration.Text = this._Wmp.controls.currentPositionString;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="track"></param>
		private void _CurrentTrackChanged<T>(T track) where T : SCFavoriteObjects
		{
			var os = Environment.OSVersion;
			this.notifyIcon.Icon = Properties.Resources.icon;

			var duration = Common.GetCurrentTrackPositionToStr(track.Duration);
			this._NowPlaying = new MiniForm(this, track.ArtworkUrl, track.Title, track.User.UserName, duration);

			if (os.Version.Major >= 6 && os.Version.Minor >= 2)
			{
				this.notifyIcon.BalloonTipTitle = $"Claudia NowPlaying\r\n";
				this.notifyIcon.BalloonTipText = $"{track.Title}\r\n{track.User.UserName}";
			}
			else
			{
				this.notifyIcon.BalloonTipTitle = $"Claudia NowPlaying";
				this.notifyIcon.BalloonTipText = $"{track.Title} - {track.User.UserName}\r\n";
			}

			this.notifyIcon.ShowBalloonTip(3000);
		}

		#endregion Private Methods
	}
}