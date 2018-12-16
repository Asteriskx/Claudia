using Legato;
using WMPLib;

namespace Claudia.Interop
{
	/// <summary>
	/// Claudia の設定値関連を管理するクラス
	/// </summary>
	public class ClaudiaProperties
	{
		#region Properties

		#region Common Property

		public bool IsPlaying { get; set; } = false;

		#endregion Common Property

		#region AIMP4 Sides

		/// <summary>
		/// 
		/// </summary>
		private AimpProperties _Properties { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsAIMP4Checked { get; set; } = false;

		/// <summary>
		/// 
		/// </summary>
		public bool IsAIMP4Running { get => (this._Properties.IsRunning) ? true : false; }

		/// <summary>
		/// 
		/// </summary>
		public int AimpVolume { set => AimpVolume = value; }

		#endregion AIMP4 Sides

		#region WMP Sides

		private WindowsMediaPlayer _Wmp { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsWMPChecked { get; set; } = false;

		/// <summary>
		/// 内蔵している Windows Media Player の起動状況を取得します。
		/// </summary>
		public bool IsWMPRunning { get => (this._Wmp != null && IsWMPChecked) ? true : false; }

		/// <summary>
		/// 内蔵している Windows Media Player の音量を設定します。
		/// </summary>
		public int WmpVolume { set => this._Wmp.settings.volume = value; }

		/// <summary>
		/// 
		/// </summary>
		public int WmpTrackPosition { get; set; }

		#endregion WMP Sides

		#region MusicBee Sides

		/// <summary>
		/// 
		/// </summary>
		public bool IsMusicBeeChecked { get; set; } = false;

		#endregion MusicBee Sides

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="property"></param>
		/// <param name="wmp"></param>
		public ClaudiaProperties(AimpProperties property, WindowsMediaPlayer wmp)
		{
			this._Properties = property;
			this._Wmp = wmp;
		}

		#endregion Constructor
	}
}