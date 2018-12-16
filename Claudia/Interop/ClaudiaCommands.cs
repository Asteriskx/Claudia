using Claudia.SoundCloud.EndPoints;
using System;
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
		private WindowsMediaPlayer _Wmp { get; set; }
		private ClaudiaProperties _Properties { get; set; }
		private ClaudiaObserver _Observer { get; set; }

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wmp"></param>
		/// <param name="property"></param>
		/// <param name="observer"></param>
		public ClaudiaCommands(WindowsMediaPlayer wmp, ClaudiaProperties property, ClaudiaObserver observer)
		{
			this._Wmp = wmp;
			this._Properties = property;
			this._Observer = observer;
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
			this._Wmp.URL = $"{track.Uri}/stream?client_id={sc.ClientId}";
			this._Wmp.controls.play();

			Console.WriteLine($"play is = {track.Title} - {track.Uri}/stream?client_id={sc.ClientId}");
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Pause()
		{
			this._Wmp.controls.pause();
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
