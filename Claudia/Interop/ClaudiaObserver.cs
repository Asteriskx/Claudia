using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Tracks;
using Claudia.SoundCloud.EndPoints.Users;
using Claudia.Utility;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WMPLib;

namespace Claudia.Interop
{
	/// <summary>
	/// Claudia のイベント管理クラス
	/// </summary>
	public class ClaudiaObserver : IDisposable
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		private MainForm _Parent { get; set; }
		private WindowsMediaPlayer _Wmp { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private int _PlayCount { get; set; } = 0;
		private int _StopCount { get; set; } = 0;
		private System.Timers.Timer _PlayTimer { get; set; } = new System.Timers.Timer(2000);
		private System.Timers.Timer _UpdateTimer { get; set; } = new System.Timers.Timer(1000);

		#endregion Properties

		#region Events

		/// <summary>
		/// Position プロパティが変更された時に発生します
		/// </summary>
		public event Action PositionPropertyChanged;

		/// <summary>
		/// CurrentTrack プロパティが変更された時に発生します
		/// </summary>
		/// <remarks>
		/// 現状は、Likes に登録した曲のみが対象となっています。
		/// 今後、Stream 及び PlayList にも対応する予定です。
		/// </remarks>
		public event Action<SCFavoriteObjects> LikesCurrentTrackChanged;
		public event Action<SCPlayListObjects> PlayListCurrentTrackChanged;

		#endregion Events

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		public ClaudiaObserver(MainForm parent, WindowsMediaPlayer wmp)
		{
			this._Parent = parent;
			this._Wmp = wmp;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		public void Initialize()
		{
			this.LikesCurrentTrackChanged += _CurrentTrackChanged;
			this.PlayListCurrentTrackChanged += _CurrentTrackChanged;

			this._UpdateTimer.Elapsed += (o, e) =>
			{
				this._Parent.Invoke((MethodInvoker)(() =>
				{
					var currentPosition = (TrackBar)Common.FindControl(this._Parent, "CurrentPosition");
					currentPosition.Value = (int)this._Wmp.controls.currentPosition;
					Debug.WriteLine($"currentPositon value = {currentPosition.Value}");

					this.PositionPropertyChanged?.Invoke();
				}));
			};

			this._Wmp.PlayStateChange += (state) =>
			{
				switch ((WMPPlayState)state)
				{
					case WMPPlayState.wmppsPaused:
						{
							Console.WriteLine("state is = wmppsPaused");
							break;
						}

					case WMPPlayState.wmppsPlaying:
						{
							Console.WriteLine("state is = wmppsPlaying");
							this._UpdateTimer.Start();
							this._PlayCount++;

							if (this._PlayCount == 3)
							{
								if (this._Parent.IsGetLikes)
								{
									var track = this._Parent.SoundCloud.Likes[this._Parent.SoundCloud.TrackNum];
									LikesCurrentTrackChanged?.Invoke(track);
								}
								else if (this._Parent.IsGetPlaylists)
								{
									var track = this._Parent.SoundCloud.Playlists[this._Parent.SoundCloud.TrackNum];
									PlayListCurrentTrackChanged?.Invoke(track);
								}
								this._PlayCount = 0;
							}

							break;
						}

					case WMPPlayState.wmppsStopped:
						{
							Console.WriteLine("state is = wmppsStopped");
							this._UpdateTimer.Stop();

							var playButton = (Button)Common.FindControl(this._Parent, "PlayButton");
							playButton.Image = Properties.Resources.play;

							this._StopCount++;
							if (_StopCount == 1) this._PlayTimer.Start();

							this._PlayTimer.Elapsed += (s, ev) =>
							{
								this._Parent.Invoke((MethodInvoker)(() =>
								{
									this._PlayTimer.Stop();

									var nextButton = (Button)Common.FindControl(this._Parent, "NextButton");
									nextButton.PerformClick();

									this._StopCount = 0;
								}));
							};
							break;
						}
				}
			};
		}

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			this._UpdateTimer.Stop();
			this._PlayTimer.Stop();
			this._UpdateTimer.Dispose();
			this._PlayTimer.Dispose();
			this._Wmp.close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="track"></param>
		private void _CurrentTrackChanged<T>(T track)
		{
			if (track is SCFavoriteObjects)
				new NotifyMessage<SCFavoriteObjects>((SCFavoriteObjects)(object)track);
			else if (track is Track)
				new NotifyMessage<Track>((Track)(object)track);
		}

		#endregion Public Methods
	}
}
