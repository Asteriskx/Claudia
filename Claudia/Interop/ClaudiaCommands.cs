using Claudia.SoundCloud.EndPoints;
using Legato;
using System;
using System.Diagnostics;
using WMPLib;

namespace Claudia.Interop
{
	/// <summary>
	/// Claudia コマンド管理クラス
	/// </summary>
	public class ClaudiaCommands : Commands
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		private AimpProperties _Properties { get; set; }
		private AimpCommands _Commands { get; set; }
		private WindowsMediaPlayer _Wmp { get; set; }
		private ClaudiaProperties _CProperties { get; set; }
		private ClaudiaObserver _CObserver { get; set; }

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="aimpProperty"></param>
		/// <param name="aimpCommand"></param>
		/// <param name="wmp"></param>
		/// <param name="claudiaProperty"></param>
		/// <param name="claudiaObserver"></param>
		public ClaudiaCommands(AimpProperties aimpProperty, AimpCommands aimpCommand,
			WindowsMediaPlayer wmp, ClaudiaProperties claudiaProperty, ClaudiaObserver claudiaObserver)
		{
			this._Properties = aimpProperty;
			this._Commands = aimpCommand;
			this._Wmp = wmp;
			this._CProperties = claudiaProperty;
			this._CObserver = claudiaObserver;
		}

		#endregion Constructor

		#region Public Override Methods

		/// <summary>
		/// 
		/// </summary>
		public override void Play()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="track"></param>
		public override void Play(SoundCloud.SoundCloud sc, SCFavoriteObjects track)
		{
			if (this._CProperties.IsAIMP4Checked)
			{
				Process.Start(this._Properties.AimpProcessPath, $"{track.Uri}/stream?client_id={sc.ClientId}");
			}
			else if (this._CProperties.IsWMPChecked)
			{
				this._Wmp.URL = $"{track.Uri}/stream?client_id={sc.ClientId}";
				this._Wmp.controls.play();
			}
			else
			{
				// TODO : MusicBee
			}

			Console.WriteLine($"play is = {track.Title} - {track.Uri}/stream?client_id={sc.ClientId}");
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Pause()
		{
			if (this._CProperties.IsAIMP4Checked)
			{
				this._Commands.PlayPause();
			}
			else if (this._CProperties.IsWMPChecked)
			{
				this._Wmp.controls.pause();
			}
			else
			{
				// TODO : MusicBee
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Stop()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Prev()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Next()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Forward()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Rewind()
		{
		}

		#endregion Public Override Methods
	}
}
