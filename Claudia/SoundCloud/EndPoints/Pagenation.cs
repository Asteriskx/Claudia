using Newtonsoft.Json;
using System.Collections.Generic;

namespace Claudia.SoundCloud.EndPoints
{
	public class Pagenation<T>
	{
		[JsonProperty("collection")]
		public List<T> Collection { get; private set; }

		[JsonProperty("next_href")]
		public string NextHref { get; private set; }
	}
}
