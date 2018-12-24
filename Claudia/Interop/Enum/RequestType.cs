namespace Claudia.Interop.Enum
{
	/// <summary>
	/// Claudia のリクエスト種別を定義します。
	/// </summary>
	public enum RequestType : uint
	{
		/// <summary>
		/// ログインユーザ情報
		/// </summary>
		LoginUser = 0x00,

		/// <summary>
		/// Stream
		/// </summary>
		Stream = 0x01,

		/// <summary>
		/// PlayList
		/// </summary>
		PlayList = 0x02,

		/// <summary>
		/// Likes
		/// </summary>
		Likes = 0x04,
	}
}
