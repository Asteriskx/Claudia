using System.Net.Http;

namespace Claudia.Services
{
	public class Twitter
	{
		private static readonly string _ck = "ck";
		private static readonly string _cs = "cs";
		private static readonly string _at = "at";
		private static readonly string _ats = "ats";

		public Twist.Twitter Twist { get; private set; } = new Twist.Twitter(_ck, _cs, _at, _ats, new HttpClient(new HttpClientHandler()));

		public Twitter() { }

	}
}
