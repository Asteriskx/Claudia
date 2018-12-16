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

		#endregion Properties

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="property"></param>
		/// <param name="wmp"></param>
		public ClaudiaProperties(WindowsMediaPlayer wmp)
		{
			this._Wmp = wmp;
		}

		#endregion Constructor
	}
}