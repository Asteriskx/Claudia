using System;
using System.Windows.Forms;

namespace Claudia
{
	public partial class MiniForm : Form
	{
		private MainForm _Parent { get; set; }
		private string _ArtworkUrl { get; set; }
		private string _Title { get; set; }
		private string _Artist { get; set; }
		private string _Duration { get; set; }

		public MiniForm(MainForm parent, string artworkUrl, string title, string artist, string duration)
		{
			InitializeComponent();

			this._Parent = parent;
			this._ArtworkUrl = artworkUrl;
			this._Title = title;
			this._Artist = artist;
			this._Duration = duration;
		}

		private void MiniWindow_Load(object sender, EventArgs e)
		{
			this.SizeChanged += (s, ev) =>
			{
				if (this.WindowState == FormWindowState.Minimized)
					this._Parent.WindowState = FormWindowState.Normal;

				this.Close();
			};

			this.Artwork.ImageLocation = this._ArtworkUrl;
			this.Title.Text = this._Title;
			this.Artist.Text = this._Artist;
			this.Duration.Text = this._Duration;
		}
	}
}
