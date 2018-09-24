using Newtonsoft.Json;

namespace Claudia.SoundCloud.EndPoints
{
	/// <summary>
	/// 
	/// </summary>
	public class User
	{
		#region Properties

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("kind")]
		public string Kind { get; set; }

		[JsonProperty("permalink")]
		public string Permalink { get; set; }

		[JsonProperty("username")]
		public string UserName { get; set; }

		[JsonProperty("last_modified")]
		public string LastModified { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }

		[JsonProperty("permalink_url")]
		public string PermalinkUrl { get; set; }

		[JsonProperty("avatar_url")]
		public string AvatarUrl { get; set; }

		#endregion Properties
	}
}
