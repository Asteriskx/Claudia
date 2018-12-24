using Claudia.SoundCloud.EndPoints;
using Claudia.SoundCloud.EndPoints.Tracks;
using Claudia.SoundCloud.EndPoints.Users;
using System;
using System.Windows.Forms;

namespace Claudia.Utility
{
	public class NotifyMessage<T>
	{
		private NotifyIcon _Icon { get; set; } = new NotifyIcon { Visible = true, Icon = Properties.Resources.icon };

		public NotifyMessage(T track) 
		{
			var os = Environment.OSVersion;

			if (track is SCFavoriteObjects)
			{
				var t = (SCFavoriteObjects)(object)track;
				if (os.Version.Major >= 6 && os.Version.Minor >= 2)
				{
					this._Icon.BalloonTipTitle = $"Claudia NowPlaying\r\n";
					this._Icon.BalloonTipText = $"{t.Title}\r\n{t.User.UserName}";
				}
				else
				{
					this._Icon.BalloonTipTitle = $"Claudia NowPlaying";
					this._Icon.BalloonTipText = $"{t.Title} - {t.User.UserName}\r\n";
				}
			}
			else if (track is Track)
			{
				var t = (Track)(object)track;
				if (os.Version.Major >= 6 && os.Version.Minor >= 2)
				{
					this._Icon.BalloonTipTitle = $"Claudia NowPlaying\r\n";
					this._Icon.BalloonTipText = $"{t.Title}\r\n{t.User.UserName}";
				}
				else
				{
					this._Icon.BalloonTipTitle = $"Claudia NowPlaying";
					this._Icon.BalloonTipText = $"{t.Title} - {t.User.UserName}\r\n";
				}
			}

			this._Icon.ShowBalloonTip(3000);
		}
	}
}
