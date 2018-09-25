namespace Claudia.SoundCloud.EndPoints
{
	/// <summary>
	/// SoundCloud の エンドポイント一覧
	/// </summary>
	public class EndPoints
	{
		private static object id { get; set; } = string.Empty;

		#region /connect
		#endregion /connect

		#region /oauth2/token
		#endregion /oauth2/token

		#region /users

		public class Users
		{
			public string Id { get; private set; }
			public Users(string id) => this.Id = id;
			
			public string User { get { return $"/users/{this.Id}"; } }
			public string Tracks { get { return $"/users/{this.Id}/tracks"; } }
			public string Playlists { get { return $"/users/{this.Id}/playlists"; } }
			public string Followings { get { return $"/users/{this.Id}/followings"; } }
			public string FollowingsId { get { return $"/users/{this.Id}/followings/{this.Id}"; } }
			public string Followers { get { return $"/users/{this.Id}/followers"; } }
			public string FollowersId { get { return $"/users/{this.Id}/followers/{this.Id}"; } }
			public string Comments { get { return $"/users/{this.Id}/comments"; } }
			public string Favorites { get { return $"/users/{this.Id}/favorites"; } }
			public string FavoritesId { get { return $"/users/{this.Id}/favorites/{this.Id}"; } }
			public string WebProfiles { get { return $"/users/{this.Id}/web-profiles"; } }
		}

		#endregion /users

		#region /tracks
		#endregion /tracks

		#region /playlists
		#endregion /playlists

		#region /comments
		#endregion /comments

		#region /me
		#endregion /me

		#region /me/connections
		#endregion /me/connections

		#region /me/activities
		#endregion /me/activities

		#region /apps
		#endregion /apps

		#region /resolve
		#endregion /resolve

		#region /oembed
		#endregion /oembed
	}
}
