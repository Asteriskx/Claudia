using Newtonsoft.Json;

namespace Claudia.SoundCloud.EndPoints.Users
{
	/// <summary>
	/// 
	/// </summary>
	public class SCLoginUser
	{
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

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("discogs_name")]
		public object DiscogsName { get; set; }

		[JsonProperty("myspace_name")]
		public object MyspaceName { get; set; }

		[JsonProperty("website")]
		public object Website { get; set; }

		[JsonProperty("website_title")]
		public object WebsiteTitle { get; set; }

		[JsonProperty("track_count")]
		public int TrackCount { get; set; }

		[JsonProperty("playlist_count")]
		public int PlaylistCount { get; set; }

		[JsonProperty("online")]
		public bool Online { get; set; }

		[JsonProperty("plan")]
		public string Plan { get; set; }

		[JsonProperty("public_favorites_count")]
		public int PublicFavoritesCount { get; set; }

		[JsonProperty("followers_count")]
		public int FollowersCount { get; set; }

		[JsonProperty("followings_count")]
		public int FollowingsCount { get; set; }

		[JsonProperty("subscriptions")]
		public object[] Subscriptions { get; set; }

		[JsonProperty("likes_count")]
		public int LikesCount { get; set; }

		[JsonProperty("reposts_count")]
		public int RepostsCount { get; set; }
		
		[JsonProperty("comments_count")]
		public int CommentsCount { get; set; }

		[JsonProperty("upload_seconds_left")]
		public int UploadSecondsLeft { get; set; }

		[JsonProperty("quota")]
		public Quota Quota { get; set; }

		[JsonProperty("private_tracks_count")]
		public int PrivateTracksCount { get; set; }

		[JsonProperty("private_playlists_count")]
		public int PrivatePlaylistsCount { get; set; }

		[JsonProperty("primary_email_confirmed")]
		public bool PrimaryEmailConfirmed { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }
	}

	public class Quota
	{
		[JsonProperty("unlimited_upload_quota")]
		public bool UnlimitedUploadQuota { get; set; }

		[JsonProperty("upload_seconds_used")]
		public int UploadSecondsUsed { get; set; }

		[JsonProperty("upload_seconds_left")]
		public int UploadSecondsLeft { get; set; }
	}
}

