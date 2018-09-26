namespace Claudia.SoundCloud.EndPoints
{
	/// <summary>
	/// SoundCloud の エンドポイント一覧
	/// </summary>
	public class EndPoints
	{
		#region /connect
		#endregion /connect

		#region /oauth2/token
		#endregion /oauth2/token

		#region /users

		/// <summary>
		/// A SoundCloud user
		/// </summary>
		public class Users
		{
			private string Id { get; set; }
			public Users(string id) => this.Id = id;

			/// <summary>
			///	a user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string User { get => $"/users/{this.Id}"; }

			/// <summary>
			///	list of tracks of the user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Tracks { get => $"/users/{this.Id}/tracks"; }

			/// <summary>
			///	list of playlists (sets) of the user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Playlists { get => $"/users/{this.Id}/playlists"; }

			/// <summary>
			///	list of users who are followed by the user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Followings { get => $"/users/{this.Id}/followings"; }

			/// <summary>
			///	a user who is followed by the user
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT, DELETE. </remarks>
			public string FollowingsId { get => $"/users/{this.Id}/followings/{this.Id}"; }

			/// <summary>
			///	list of users who are following the user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Followers { get => $"/users/{this.Id}/followers"; }

			/// <summary>
			/// user who is following the user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string FollowersId { get => $"/users/{this.Id}/followers/{this.Id}"; }

			/// <summary>
			///	list of comments from this user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Comments { get => $"/users/{this.Id}/comments"; }

			/// <summary>
			///	list of tracks favorited by the user
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Favorites { get => $"/users/{this.Id}/favorites"; }

			/// <summary>
			///	track favorited by the user
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT, DELETE. </remarks>
			public string FavoritesId { get => $"/users/{this.Id}/favorites/{this.Id}"; }

			/// <summary>
			///	list of web profiles
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT, DELETE. </remarks>
			public string WebProfiles { get => $"/users/{this.Id}/web-profiles"; }
		}

		#endregion /users

		#region /tracks

		/// <summary>
		/// A SoundCloud Track
		/// </summary>
		public class Tracks
		{
			private string Id { get; set; }
			private string CommentId { get; set; }
			private string UserId { get; set; }

			public Tracks(string id, string commentId, string userId)
			{
				this.Id = id;
				this.CommentId = commentId;
				this.UserId = userId;
			}

			/// <summary>
			///	a track
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT, DELETE. </remarks>
			public string Track { get => $"/tracks/{this.Id}"; }

			/// <summary>
			///	comments for the track
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Comments { get => $"/tracks/{this.Id}/comments"; }

			/// <summary>
			///	a comment for the track
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT, DELETE. </remarks>
			public string CommentsId { get => $"/tracks/{this.Id}/comments/{this.CommentId}"; }

			/// <summary>
			///	users who favorited the track
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Favoriters { get => $"/tracks/{this.Id}/favoriters"; }

			/// <summary>
			///	a user who has favorited to the track
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string FavoritersId { get => $"/tracks/{this.Id}/favoriters/{this.UserId}"; }

			/// <summary>
			///	secret token of the track
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT. </remarks>
			public string SecretToken { get => $"/tracks/{this.Id}/secret-token"; }
		}

		#endregion /tracks

		#region /playlists

		/// <summary>
		/// A SoundCloud Set is internally called playlists due to some naming restrictions.
		/// </summary>
		public class PlayLists
		{
			private string Id { get; set; }
			public PlayLists(string id) => this.Id = id;

			/// <summary>
			///	secret token of the playlist
			/// </summary>
			/// <remarks> HttpRequest type is GET, PUT. </remarks>
			public string SecretToken { get => $"/playlists/{this.Id}/secret-token"; }
		}

		#endregion /playlists

		#region /comments
		#endregion /comments

		#region /me

		/// <summary>
		/// The /me resource allows you to get information about the authenticated user and 
		/// easily access their related subresources like tracks, followings, followers and so on.
		/// </summary>
		public class Me
		{
			private string Id { get; set; }

			public Me(string id)
			{
				this.Id = id;
				this.Users = new Users(this.Id);
			}

			/// <summary>
			/// User data.
			/// </summary>
			public Users Users { get; set; }

			/// <summary>
			/// list dashboard activities
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Activities { get => $"/me/{this.Id}/activities"; }

			/// <summary>
			/// list of connected external profiles
			/// </summary>
			/// <remarks> HttpRequest type is GET, POST. </remarks>
			public string Connections { get => $"/me/{this.Id}/connections"; }
		}

		#endregion /me

		#region /me/connections

		/// <summary>
		/// Connections represent the external profiles 
		/// (like twitter, tumblr or facebook profiles and pages) that are connected to a SoundCloud user. 
		/// The connection ids can be used to share tracks and playlists to social network.
		/// </summary>
		public class MeConnections
		{
			private string ConnectId { get; set; }
			public MeConnections(string connectId) => this.ConnectId = connectId;

			/// <summary>
			/// /me/connections
			/// </summary>
			/// <remarks> HttpRequest type is GET, POST. </remarks>
			public string Connections { get => $"/me/connections"; }

			/// <summary>
			/// /me/connections/{connection_id}
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string ConnectionsId { get => $"/me/connections/{this.ConnectId}"; }
		}

		#endregion /me/connections

		#region /me/activities

		/// <summary>
		/// The newest activities for the logged-in user
		/// </summary>
		public class MeActivities
		{
			public MeActivities() { }

			/// <summary>
			/// Recent activities
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Activities { get => $"/me/activities"; }

			/// <summary>
			/// Recent tracks from users the logged-in user follows
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Affiliated { get => $"/me/activities/tracks/affiliated"; }

			/// <summary>
			/// Recent exclusively shared tracks
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Exclusive { get => $"/me/activities/tracks/exclusive"; }

			/// <summary>
			/// Recent activities on the logged-in users tracks
			/// </summary>
			/// <remarks> HttpRequest type is GET only. </remarks>
			public string Own { get => $"/me/activities/all/own"; }
		}

		#endregion /me/activities

		#region /apps
		#endregion /apps

		#region /resolve
		#endregion /resolve

		#region /oembed
		#endregion /oembed
	}
}
