using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Tracks;
using Claudia.SoundCloud.EndPoints.Users;

namespace Claudia.Interop
{
	/// <summary>
	/// Claudia　のプレイヤーとしての基本的な機能を定義するインターフェイス
	/// </summary>
	public abstract class Commands
	{
		/// <summary>
		/// 再生機能を提供します。
		/// </summary>
		public abstract void Play();

		/// <summary>
		/// 再生機能を提供します。
		/// </summary>
		public abstract void Play(SoundCloud.SoundCloud sc, SCFavoriteObjects track);

		/// <summary>
		/// 再生機能を提供します。
		/// </summary>
		public abstract void Play(SoundCloud.SoundCloud sc, Track track);

		/// <summary>
		/// 一時停止機能を提供します。
		/// </summary>
		public abstract void Pause();

		/// <summary>
		/// 停止機能を提供します。
		/// </summary>
		public abstract void Stop();

		/// <summary>
		/// 前曲移動機能を提供します。
		/// </summary>
		public abstract void Prev();

		/// <summary>
		/// 次曲移動機能を提供します。
		/// </summary>
		public abstract void Next();

		/// <summary>
		/// 巻き戻し機能を提供します。
		/// </summary>
		public abstract void Forward();

		/// <summary>
		/// 早送り機能を提供します。
		/// </summary>
		public abstract void Rewind();
	}
}
