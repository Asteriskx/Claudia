namespace Claudia
{
	partial class MiniWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniWindow));
			this.Artwork = new System.Windows.Forms.PictureBox();
			this.Title = new System.Windows.Forms.Label();
			this.Artist = new System.Windows.Forms.Label();
			this.Duration = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Artwork)).BeginInit();
			this.SuspendLayout();
			// 
			// Artwork
			// 
			this.Artwork.Location = new System.Drawing.Point(1, 0);
			this.Artwork.Name = "Artwork";
			this.Artwork.Size = new System.Drawing.Size(120, 120);
			this.Artwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Artwork.TabIndex = 0;
			this.Artwork.TabStop = false;
			// 
			// Title
			// 
			this.Title.AutoSize = true;
			this.Title.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Title.ForeColor = System.Drawing.Color.White;
			this.Title.Location = new System.Drawing.Point(140, 21);
			this.Title.Name = "Title";
			this.Title.Size = new System.Drawing.Size(34, 18);
			this.Title.TabIndex = 1;
			this.Title.Text = "Title";
			// 
			// Artist
			// 
			this.Artist.AutoSize = true;
			this.Artist.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Artist.ForeColor = System.Drawing.Color.White;
			this.Artist.Location = new System.Drawing.Point(140, 50);
			this.Artist.Name = "Artist";
			this.Artist.Size = new System.Drawing.Size(40, 18);
			this.Artist.TabIndex = 2;
			this.Artist.Text = "Artist";
			// 
			// Duration
			// 
			this.Duration.AutoSize = true;
			this.Duration.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Duration.ForeColor = System.Drawing.Color.White;
			this.Duration.Location = new System.Drawing.Point(140, 79);
			this.Duration.Name = "Duration";
			this.Duration.Size = new System.Drawing.Size(58, 18);
			this.Duration.TabIndex = 3;
			this.Duration.Text = "Duration";
			// 
			// MiniWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(380, 120);
			this.Controls.Add(this.Duration);
			this.Controls.Add(this.Artist);
			this.Controls.Add(this.Title);
			this.Controls.Add(this.Artwork);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MiniWindow";
			this.Text = "MiniWindow";
			this.Load += new System.EventHandler(this.MiniWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.Artwork)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox Artwork;
		private System.Windows.Forms.Label Title;
		private System.Windows.Forms.Label Artist;
		private System.Windows.Forms.Label Duration;
	}
}