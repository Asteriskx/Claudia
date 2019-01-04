using Claudia.Interop;
using Claudia.Services;
using Claudia.Utility;
using System;
using System.Collections.Generic;
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
		public bool IsGetLikes { get; set; } = false;
		public bool IsGetPlaylists { get; set; } = false;

		private Twitter _Twitter { get; set; } = new Twitter();

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
			this._Commands = new ClaudiaCommands(this._Wmp, this._Properties);

			this._Observer.PositionPropertyChanged += _PositionPropertyChanged;
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
		private async void PlayListsButton_Click(object sender, EventArgs e)
		{
			this.Playlist.Visible = true;
			if (!this.IsGetPlaylists)
			{
				this.IsGetPlaylists = true;
				var data = new Dictionary<string, int>()
				{
					{ "TrackName", 600 },
					{ "Artist", 200 },
					{ "URL", 300 },
					{ "Genre", 70 },
					{ "Duration", 100 }
				};

				this.IsGetPlaylists = true;
				await this.SoundCloud.GetPlayListAsync();

				foreach (var i in Enumerable.Range(this.Playlist.TabCount + 1, this.SoundCloud.Playlists.Count - this.Playlist.TabCount))
				{
					var tab = new TabPage { Name = $"tabPage{i}", Text = $"tabPage{i}" };
					this.Playlist.TabPages.Add(tab);
				}

				foreach (var list in this.SoundCloud.Playlists.Select((value, idx) => new { value, idx }))
				{
					if (list.idx < this.SoundCloud.Playlists.Count)
					{
						var listView = new ListView
						{
							Size = new Size(1270, 550),
							FullRowSelect = true,
							GridLines = true,
							Sorting = SortOrder.None,
							View = View.Details
						};

						// ヘッダ追加
						foreach (var kvp in data)
							listView.Columns.Add(ColumnHeaderEx.GetColumnHeader(kvp.Key, kvp.Value));

						var tab = (TabPage)this.Playlist.Controls[$"tabPage{list.idx + 1}"];
						tab.Text = list.value.Title;

						foreach (var track in list.value.Tracks)
						{
							var mainItem = listView.Items.Add(track.Title);
							mainItem.SubItems.Add(track.User.UserName);
							mainItem.SubItems.Add($"{track.StreamUrl}?client_id={this.SoundCloud.ClientId}");
							mainItem.SubItems.Add(track.Genre);
							mainItem.SubItems.Add(Common.GetCurrentTrackPositionToStr(track.Duration));
						}

						listView.DoubleClick += (s, ev) =>
						{
							if (listView.SelectedItems.Count > 0)
							{
								this.SoundCloud.TabIdx = Playlist.SelectedIndex;
								this.SoundCloud.ListTrackIdx = listView.SelectedItems[0].Index;
								this.SoundCloud.ArtworkUrl = list.value.Tracks[this.SoundCloud.ListTrackIdx].ArtworkUrl;
								var item = listView.SelectedItems[0];
								this.SoundCloud.PostData = new Dictionary<string, string> { { item.Text, item.SubItems[1].Text } };
								this._UpdateTrackInfoTest(this.SoundCloud.TabIdx, this.SoundCloud.ListTrackIdx);
							}
						};

						tab.Controls.Add(listView);
					}
				}
			}

			//this.artPanel.Visible = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LikesButton_Click(object sender, EventArgs e)
		{
			// 現状は初回押下時のみ動作
			if (!this.IsGetLikes)
			{
				this.Playlist.Visible = false;
				this.IsGetLikes = true;
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
			else
			{
				if (this.IsGetLikes)
				{
					this.Playlist.Visible = false;
					this.artPanel.Visible = true;
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
			var loginUser = await this.SoundCloud.GetLoginUserNameAsync();

			if (this.IsGetLikes)
			{
				var track = this.SoundCloud.Likes[this.SoundCloud.TrackNum];
				var tw = new StringBuilder();
				tw.Append($"🎵 {track.Title}\r\n");
				tw.Append($"🎙 {track.User.UserName}\r\n");
				tw.Append($"💿 {loginUser}'s Likes\r\n");
				tw.Append("#nowplaying #Claudia #SoundCloud");

				using (var client = new WebClient())
				using (var stream = new MemoryStream(client.DownloadData(track.ArtworkUrl)))
					await _Twitter.Twist.UpdateWithMediaAsync(tw.ToString(), stream);
			}
			else if (this.IsGetPlaylists)
			{
				foreach (var kvp in this.SoundCloud.PostData)
				{
					var tw = new StringBuilder();
					tw.Append($"🎵 {kvp.Key}\r\n");
					tw.Append($"🎙 {kvp.Value}\r\n");
					tw.Append($"💿 {loginUser}'s Likes\r\n");
					tw.Append("#nowplaying #Claudia #SoundCloud");

					using (var client = new WebClient())
					using (var stream = new MemoryStream(client.DownloadData(this.SoundCloud.ArtworkUrl)))
						await _Twitter.Twist.UpdateWithMediaAsync(tw.ToString(), stream);
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
			if (this.IsGetLikes)
				this._UpdateTrackInfo(this.SoundCloud.TrackNum);
			else if (this.IsGetPlaylists) ;
			//this._UpdateTrackInfoTest(this.SoundCloud.TrackNum);
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

					// TODO : ロード進捗率の表示方法 bootstrap とかも組み合わせれれば最高かも。
					//this.Text = $"Claudia - Loading... {(i + 1 / this.SoundCloud.Likes.Count + 1) / 100}%";
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
			this.EndDuration.Text = Common.GetCurrentTrackPositionToStr(track.Duration);

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
		/// <param name="idx"></param>
		private void _UpdateTrackInfoTest(int tabIdx, int trackIdx)
		{
			var track = this.SoundCloud.Playlists[tabIdx].Tracks[trackIdx];
			var artUrl = Common.LoadImageFromUrl(track.ArtworkUrl);
			var duration = Common.GetCurrentTrackPositionToStr(track.Duration);

			this._NowPlaying = new MiniForm(this, track.ArtworkUrl, track.Title, track.User.UserName, duration);
			this.EndDuration.Text = Common.GetCurrentTrackPositionToStr(track.Duration);

			this.CurrentArtwork.Image = artUrl ?? Properties.Resources.none;
			this.CurrentTrack.Text = $"{track.Title} ({duration})";
			this.CurrentArtist.Text = track.User.UserName;
			this.CurrentInfo.Text = $"Genre : {track.Genre ?? "-"} / Bpm : {track.Bpm ?? "-"} / LikesCount : {track.LikesCount}";
			this.TrackDuration.Text = duration;

			var length = this.SoundCloud.Playlists[tabIdx].Tracks.Length - 1;
			if (trackIdx < length)
			{
				var nextTrack = this.SoundCloud.Playlists[tabIdx].Tracks[trackIdx + 1] ?? null;
				this.NextAlbumArt.Image = Common.LoadImageFromUrl(nextTrack.ArtworkUrl) ?? Properties.Resources.none;
				this.NextTrack.Text = nextTrack.Title ?? "-";
				this.NextArtist.Text = nextTrack.User.UserName ?? "-";

				this.CurrentPosition.Maximum = Common.GetCurrentTrackPositionToInt(track.Duration);
				this._Commands.Play(this.SoundCloud, track);
				this.PlayButton.Image = Properties.Resources.pause;
			}
			else
			{
				this.NextAlbumArt.Image = Properties.Resources.none;
				this.NextTrack.Text = "-";
				this.NextArtist.Text = "-";

				this.CurrentPosition.Maximum = Common.GetCurrentTrackPositionToInt(track.Duration);
				this._Commands.Play(this.SoundCloud, track);
				this.PlayButton.Image = Properties.Resources.pause;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void _PositionPropertyChanged() =>
			this.TrackDuration.Text = this._Wmp.controls.currentPositionString;

		#endregion Private Methods
	}
}