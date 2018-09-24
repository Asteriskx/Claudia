using CefSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Claudia.SoundCloud.Helper
{
	/// <summary>
	/// Cookie 管理クラス
	/// </summary>
	public class CookieVisitor : ICookieVisitor
	{
		#region Property

		/// <summary>
		/// 
		/// </summary>
		public Dictionary<string, System.Net.Cookie> AllCookies { get; private set; } = new Dictionary<string, System.Net.Cookie>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public System.Net.Cookie this[string name] => this.AllCookies.ContainsKey(name) ? this.AllCookies[name] : null;

		/// <summary>
		/// 
		/// </summary>
		public bool IsReady { get; set; }

		#endregion Property

		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		public CookieVisitor()
		{
			this.IsReady = true;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cookie"></param>
		/// <param name="count"></param>
		/// <param name="total"></param>
		/// <param name="deleteCookie"></param>
		/// <returns></returns>
		public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
		{
			lock (this)
			{
				if (cookie.Name == null) return false;

				if (this.AllCookies.ContainsKey(cookie.Name))
				{
					this.AllCookies[cookie.Name] = new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain)
					{
						Name = cookie.Name,
						Value = cookie.Value,
						Path = cookie.Path,
						Domain = cookie.Domain
					};
				}
				else
				{
					this.AllCookies.Add(cookie.Name, new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
				}

				// fire when complete
				this.IsReady = (count == total - 1);
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public async Task WaitComplete(int timeout = 10000)
		{
			int count = 0;

			await Task.Delay(10);

			while (!this.IsReady)
			{
				await Task.Delay(10);
				count++;

				if (count > (timeout / 10))
					throw new TimeoutException();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ct"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public async Task WaitComplete(CancellationToken ct, int timeout = 10000)
		{
			int count = 0;

			while (!this.IsReady && !ct.IsCancellationRequested)
			{
				await Task.Delay(100);
				count++;

				if (count > (timeout / 100))
					throw new TimeoutException();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Dispose() { }

		#endregion Public Methods
	}
}
