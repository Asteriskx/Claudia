using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace Claudia.Utility
{
	public static class Common
	{
		/// <summary>
		/// 再生している曲の長さを取得します。
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		public static string GetCurrentTrackPositionToStr(int position)
		{
			var totalSec = position / 1000;
			var min = totalSec / 60;
			var sec = totalSec % 60;
			return $"{min:D2}:{sec:D2}";
		}

		/// <summary>
		/// 再生している曲の長さを取得します。
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		public static int GetCurrentTrackPositionToInt(int position)
		{
			return (position / 1000);
		}

		/// <summary>
		/// 指定された URL 画像を Image として取得します。
		/// </summary>
		/// <param name="url">画像データのURL</param>
		/// <returns>画像データ</returns>
		public static Image LoadImageFromUrl(string url)
		{
			using (var ms = new MemoryStream())
			{
				if (url == null || url.Trim().Length <= 0) return null;

				var req = WebRequest.Create(url);
				var reader = new BinaryReader(req.GetResponse().GetResponseStream());

				for (;;)
				{
					var buff = new byte[0xFF];
					var readBytes = reader.Read(buff, 0, 0xFF);

					if (readBytes <= 0) break;

					ms.Write(buff, 0, readBytes);
				}

				return new Bitmap(ms);
			}
		}

		/// <summary>
		/// フォームに配置されているコントロールを名前で検索します。
		/// </summary>
		/// <param name="form">コントロールを探すフォーム</param>
		/// <param name="name">コントロール（フィールド）の名前</param>
		/// <returns>見つかった時は、コントロールのオブジェクト。見つからなかった時は、null を返却します。</returns>
		public static object FindControl(Form form, string name)
		{
			Type t = form.GetType();
			FieldInfo info = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			return info?.GetValue(form);
		}
	}
}
