using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Tracks;
using System;
using System.Windows.Forms;

namespace Claudia.Utility
{
	/// <summary>
	/// 再生時に表示されるトースト/バルーン通知を管理します。
	/// </summary>
	/// <typeparam name="T"> SCFavoriteObjects or Track </typeparam>
	public class NotifyMessage<T>
	{
		#region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="track"></param>
		public NotifyMessage(T track)
		{
			using (var notifyIcon = new NotifyIcon { Visible = true, Icon = Properties.Resources.icon })
			{
				var os = Environment.OSVersion;
				if (track is SCFavoriteObjects)
				{
					var t = (SCFavoriteObjects)(object)track;
					if (os.Version.Major >= 6 && os.Version.Minor >= 2)
					{
						notifyIcon.BalloonTipTitle = $"Claudia NowPlaying\r\n";
						notifyIcon.BalloonTipText = $"{t.Title}\r\n{t.User.UserName}";
					}
					else
					{
						notifyIcon.BalloonTipTitle = $"Claudia NowPlaying";
						notifyIcon.BalloonTipText = $"{t.Title} - {t.User.UserName}\r\n";
					}
				}
				else if (track is Track)
				{
					var t = (Track)(object)track;
					if (os.Version.Major >= 6 && os.Version.Minor >= 2)
					{
						notifyIcon.BalloonTipTitle = $"Claudia NowPlaying\r\n";
						notifyIcon.BalloonTipText = $"{t.Title}\r\n{t.User.UserName}";
					}
					else
					{
						notifyIcon.BalloonTipTitle = $"Claudia NowPlaying";
						notifyIcon.BalloonTipText = $"{t.Title} - {t.User.UserName}\r\n";
					}
				}

				notifyIcon.ShowBalloonTip(3000);
			}
		}

		#endregion Constructor
	}
}
