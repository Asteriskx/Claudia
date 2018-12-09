using Claudia.Interop;
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

		private AimpProperties _Properties { get; set; }
		private AimpCommands _Commands { get; set; } = new AimpCommands();
		private WindowsMediaPlayer _Wmp { get; set; } = new WindowsMediaPlayer();

		/// <summary>
		/// 
		/// </summary>
		public SoundCloud.SoundCloud SoundCloud { get; set; }
		private ClaudiaCommands _CCommands { get; set; }
		private ClaudiaProperties _CProperties { get; set; }
		private ClaudiaObserver _CObserver { get; set; }

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
			this._CProperties = new ClaudiaProperties(this._Properties, this._Wmp);
			this._CObserver = new ClaudiaObserver(this, this._Properties, this._Commands, this._Wmp);
			this._CCommands = new ClaudiaCommands(this._Properties, this._Commands, this._Wmp, this._CProperties, this._CObserver);

			this._CObserver.PositionPropertyChanged += _PositionPropertyChanged;
			this._CObserver.CurrentTrackChanged += _CurrentTrackChanged;
			this._CObserver.Initialize();

			this.DoubleBuffered = true;
			this._Wmp.settings.autoStart = true;
			this._Wmp.settings.volume = 10;

			this._GetSelectPlayerProperty();

			var settings = Properties.Settings.Default;
			var clientId = (string)settings["ClientId"] ?? string.Empty;
			var token = (string)settings["Token"] ?? string.Empty;

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(token))
			{
				this.LoginButton.Enabled = false;
				this.SoundCloud = new SoundCloud.SoundCloud(token, clientId, HttpMethod.Get);
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
				var track = this.SoundCloud.Likes[this.SoundCloud.TrackNum];
				var artUrl = track.ArtworkUrl;
				var title = track.Title;
				var artist = track.User.UserName;
				var duration = Common.GetCurrentTrackPositionToStr(track.Duration);

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
			this._CObserver.Dispose();
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
					this.SoundCloud = new SoundCloud.SoundCloud(form.Token, form.ClientId, HttpMethod.Get);
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
			this._CCommands.Pause();
			this._GetSelectPlayerProperty();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StreamButton_Click(object sender, EventArgs e) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayListsButton_Click(object sender, EventArgs e) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LikesButton_Click(object sender, EventArgs e)
		{
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayButton_Click(object sender, EventArgs e)
		{
			if (!this._CProperties.IsPlaying)
			{
				var track = this.SoundCloud.Likes[this.SoundCloud.TrackNum];
				this._CProperties.IsPlaying = true;

				this.CurrentArtwork.Image = Common.LoadImageFromUrl(track.ArtworkUrl) ?? Properties.Resources.none;
				this.CurrentTrack.Text = $"{track.Title} - {track.User.UserName}";
				this.TrackDuration.Text = Common.GetCurrentTrackPositionToStr(track.Duration);
				this.PlayButton.Image = Properties.Resources.pause;

				this._CCommands.Play(this.SoundCloud, track);
			}
			else
			{
				this._CCommands.Pause();
				this.PlayButton.Image = Properties.Resources.play;
				this._CProperties.IsPlaying = false;
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
			if (this._CProperties.IsWMPChecked)
				this._CProperties.WmpVolume = this.VolumeBar.Value;
			else if (this._CProperties.IsAIMP4Running && this._CProperties.IsAIMP4Checked)
				this._CProperties.AimpVolume = this.VolumeBar.Value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CurrentPosition_Scroll(object sender, EventArgs e)
		{
			
		}

		#endregion Event Methods

		#region Private Methods

		/// <summary>
		/// ストリーミング再生を行うプレイヤーを選択し、選択状況を取得します。
		/// </summary>
		private void _GetSelectPlayerProperty()
		{
			var player = new SelectPlayerForm(false, false, false);
			if (player.ShowDialog() == DialogResult.OK)
			{
				this._CProperties.IsAIMP4Checked = player.IsAIMP4Checked;
				this._CProperties.IsWMPChecked = player.IsWMPChecked;
				this._CProperties.IsMusicBeeChecked = player.IsMusicBeeChecked;
			}
		}

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

			this.CurrentArtwork.Image = Common.LoadImageFromUrl(track.ArtworkUrl) ?? Properties.Resources.none;
			this.CurrentTrack.Text = $"{track.Title} ({Common.GetCurrentTrackPositionToStr(track.Duration)})";
			this.CurrentArtist.Text = track.User.UserName;
			this.CurrentInfo.Text = $"Genre : {track.Genre ?? "-"} / Bpm : {track.Bpm ?? "-"} / LikesCount : {track.LikesCount}";
			this.TrackDuration.Text = Common.GetCurrentTrackPositionToStr(track.Duration);

			var nextTrack = this.SoundCloud.Likes[idx + 1];
			this.NextAlbumArt.Image = Common.LoadImageFromUrl(nextTrack.ArtworkUrl) ?? Properties.Resources.none;
			this.NextTrack.Text = nextTrack.Title;
			this.NextArtist.Text = nextTrack.User.UserName;

			this.CurrentPosition.Maximum = Common.GetCurrentTrackPositionToInt(track.Duration);
			this._CCommands.Play(this.SoundCloud, track);
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