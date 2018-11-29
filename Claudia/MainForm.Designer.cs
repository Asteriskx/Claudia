namespace Claudia
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.PlayerButton = new System.Windows.Forms.Button();
			this.LoginButton = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.SelectTrack = new System.Windows.Forms.Label();
			this.SelectArt = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.NextTrack = new System.Windows.Forms.Label();
			this.NextAlbumArt = new System.Windows.Forms.PictureBox();
			this.LikesButton = new System.Windows.Forms.Button();
			this.PlayListsButton = new System.Windows.Forms.Button();
			this.StreamButton = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.TrackDuration = new System.Windows.Forms.Label();
			this.barTrackInfo = new System.Windows.Forms.Label();
			this.barArt = new System.Windows.Forms.PictureBox();
			this.PrevButton = new System.Windows.Forms.Button();
			this.PlayButton = new System.Windows.Forms.Button();
			this.NextButton = new System.Windows.Forms.Button();
			this.Home = new System.Windows.Forms.Panel();
			this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.artPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SelectArt)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NextAlbumArt)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barArt)).BeginInit();
			this.Home.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel2.Controls.Add(this.PlayerButton);
			this.panel2.Controls.Add(this.LoginButton);
			this.panel2.Controls.Add(this.groupBox4);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.LikesButton);
			this.panel2.Controls.Add(this.PlayListsButton);
			this.panel2.Controls.Add(this.StreamButton);
			this.panel2.Location = new System.Drawing.Point(1, 47);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(257, 610);
			this.panel2.TabIndex = 5;
			// 
			// PlayerButton
			// 
			this.PlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.PlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayerButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayerButton.ForeColor = System.Drawing.Color.White;
			this.PlayerButton.Image = global::Claudia.Properties.Resources.player;
			this.PlayerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PlayerButton.Location = new System.Drawing.Point(0, 39);
			this.PlayerButton.Name = "PlayerButton";
			this.PlayerButton.Size = new System.Drawing.Size(257, 40);
			this.PlayerButton.TabIndex = 18;
			this.PlayerButton.Text = "SelectPlayer";
			this.PlayerButton.UseVisualStyleBackColor = false;
			this.PlayerButton.Click += new System.EventHandler(this.PlayerButton_Click);
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LoginButton.ForeColor = System.Drawing.Color.White;
			this.LoginButton.Image = global::Claudia.Properties.Resources.account;
			this.LoginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LoginButton.Location = new System.Drawing.Point(0, 0);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(257, 40);
			this.LoginButton.TabIndex = 17;
			this.LoginButton.Text = "Login";
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.SelectTrack);
			this.groupBox4.Controls.Add(this.SelectArt);
			this.groupBox4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox4.ForeColor = System.Drawing.Color.White;
			this.groupBox4.Location = new System.Drawing.Point(11, 210);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(232, 173);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Selected TrackInfo";
			// 
			// SelectTrack
			// 
			this.SelectTrack.AutoEllipsis = true;
			this.SelectTrack.AutoSize = true;
			this.SelectTrack.Location = new System.Drawing.Point(17, 141);
			this.SelectTrack.MaximumSize = new System.Drawing.Size(210, 18);
			this.SelectTrack.Name = "SelectTrack";
			this.SelectTrack.Size = new System.Drawing.Size(129, 18);
			this.SelectTrack.TabIndex = 15;
			this.SelectTrack.Text = "Selected TrackName";
			// 
			// SelectArt
			// 
			this.SelectArt.Location = new System.Drawing.Point(62, 24);
			this.SelectArt.Name = "SelectArt";
			this.SelectArt.Size = new System.Drawing.Size(110, 110);
			this.SelectArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.SelectArt.TabIndex = 14;
			this.SelectArt.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.NextTrack);
			this.groupBox3.Controls.Add(this.NextAlbumArt);
			this.groupBox3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.ForeColor = System.Drawing.Color.White;
			this.groupBox3.Location = new System.Drawing.Point(11, 399);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(232, 173);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Next TrackInfo";
			// 
			// NextTrack
			// 
			this.NextTrack.AutoEllipsis = true;
			this.NextTrack.AutoSize = true;
			this.NextTrack.Location = new System.Drawing.Point(17, 142);
			this.NextTrack.MaximumSize = new System.Drawing.Size(210, 18);
			this.NextTrack.Name = "NextTrack";
			this.NextTrack.Size = new System.Drawing.Size(107, 18);
			this.NextTrack.TabIndex = 15;
			this.NextTrack.Text = "Next TrackName";
			// 
			// NextAlbumArt
			// 
			this.NextAlbumArt.Location = new System.Drawing.Point(62, 24);
			this.NextAlbumArt.Name = "NextAlbumArt";
			this.NextAlbumArt.Size = new System.Drawing.Size(110, 110);
			this.NextAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.NextAlbumArt.TabIndex = 14;
			this.NextAlbumArt.TabStop = false;
			// 
			// LikesButton
			// 
			this.LikesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LikesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LikesButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LikesButton.ForeColor = System.Drawing.Color.White;
			this.LikesButton.Image = global::Claudia.Properties.Resources.fav;
			this.LikesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LikesButton.Location = new System.Drawing.Point(0, 156);
			this.LikesButton.Name = "LikesButton";
			this.LikesButton.Size = new System.Drawing.Size(257, 40);
			this.LikesButton.TabIndex = 2;
			this.LikesButton.Text = "Likes";
			this.LikesButton.UseVisualStyleBackColor = false;
			this.LikesButton.Click += new System.EventHandler(this.LikesButton_Click);
			// 
			// PlayListsButton
			// 
			this.PlayListsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.PlayListsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayListsButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayListsButton.ForeColor = System.Drawing.Color.White;
			this.PlayListsButton.Image = global::Claudia.Properties.Resources.playlist;
			this.PlayListsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PlayListsButton.Location = new System.Drawing.Point(0, 117);
			this.PlayListsButton.Name = "PlayListsButton";
			this.PlayListsButton.Size = new System.Drawing.Size(257, 40);
			this.PlayListsButton.TabIndex = 1;
			this.PlayListsButton.Text = "PlayLists";
			this.PlayListsButton.UseVisualStyleBackColor = false;
			// 
			// StreamButton
			// 
			this.StreamButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.StreamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StreamButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.StreamButton.ForeColor = System.Drawing.Color.White;
			this.StreamButton.Image = global::Claudia.Properties.Resources.stream;
			this.StreamButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.StreamButton.Location = new System.Drawing.Point(0, 78);
			this.StreamButton.Name = "StreamButton";
			this.StreamButton.Size = new System.Drawing.Size(257, 40);
			this.StreamButton.TabIndex = 0;
			this.StreamButton.Text = "Stream";
			this.StreamButton.UseVisualStyleBackColor = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel3.Controls.Add(this.TrackDuration);
			this.panel3.Controls.Add(this.barTrackInfo);
			this.panel3.Controls.Add(this.barArt);
			this.panel3.Controls.Add(this.PrevButton);
			this.panel3.Controls.Add(this.PlayButton);
			this.panel3.Controls.Add(this.NextButton);
			this.panel3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.panel3.Location = new System.Drawing.Point(258, -2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1034, 50);
			this.panel3.TabIndex = 5;
			// 
			// TrackDuration
			// 
			this.TrackDuration.AutoSize = true;
			this.TrackDuration.ForeColor = System.Drawing.Color.White;
			this.TrackDuration.Location = new System.Drawing.Point(838, 16);
			this.TrackDuration.Name = "TrackDuration";
			this.TrackDuration.Size = new System.Drawing.Size(33, 18);
			this.TrackDuration.TabIndex = 19;
			this.TrackDuration.Text = "--:--";
			// 
			// barTrackInfo
			// 
			this.barTrackInfo.AutoEllipsis = true;
			this.barTrackInfo.AutoSize = true;
			this.barTrackInfo.ForeColor = System.Drawing.Color.White;
			this.barTrackInfo.Location = new System.Drawing.Point(53, 16);
			this.barTrackInfo.MaximumSize = new System.Drawing.Size(600, 18);
			this.barTrackInfo.Name = "barTrackInfo";
			this.barTrackInfo.Size = new System.Drawing.Size(120, 18);
			this.barTrackInfo.TabIndex = 18;
			this.barTrackInfo.Text = "TrackName - Artist";
			// 
			// barArt
			// 
			this.barArt.Location = new System.Drawing.Point(14, 8);
			this.barArt.Name = "barArt";
			this.barArt.Size = new System.Drawing.Size(33, 35);
			this.barArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.barArt.TabIndex = 17;
			this.barArt.TabStop = false;
			// 
			// PrevButton
			// 
			this.PrevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PrevButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PrevButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.PrevButton.Image = global::Claudia.Properties.Resources.prev;
			this.PrevButton.Location = new System.Drawing.Point(902, 8);
			this.PrevButton.Name = "PrevButton";
			this.PrevButton.Size = new System.Drawing.Size(35, 35);
			this.PrevButton.TabIndex = 16;
			this.PrevButton.UseVisualStyleBackColor = true;
			this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
			// 
			// PlayButton
			// 
			this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.PlayButton.Image = global::Claudia.Properties.Resources.play;
			this.PlayButton.Location = new System.Drawing.Point(942, 8);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(35, 35);
			this.PlayButton.TabIndex = 10;
			this.PlayButton.UseVisualStyleBackColor = true;
			this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
			// 
			// NextButton
			// 
			this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NextButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.NextButton.Image = global::Claudia.Properties.Resources.next;
			this.NextButton.Location = new System.Drawing.Point(983, 8);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(35, 35);
			this.NextButton.TabIndex = 12;
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// Home
			// 
			this.Home.BackColor = System.Drawing.Color.Tomato;
			this.Home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Home.BackgroundImage")));
			this.Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Home.Controls.Add(this.axWindowsMediaPlayer);
			this.Home.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Home.Location = new System.Drawing.Point(1, -2);
			this.Home.Name = "Home";
			this.Home.Size = new System.Drawing.Size(257, 50);
			this.Home.TabIndex = 4;
			// 
			// axWindowsMediaPlayer
			// 
			this.axWindowsMediaPlayer.Enabled = true;
			this.axWindowsMediaPlayer.Location = new System.Drawing.Point(11, 16);
			this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
			this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
			this.axWindowsMediaPlayer.Size = new System.Drawing.Size(75, 23);
			this.axWindowsMediaPlayer.TabIndex = 7;
			this.axWindowsMediaPlayer.Visible = false;
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.CadetBlue;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
			this.statusStrip1.Location = new System.Drawing.Point(0, 657);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1292, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLbl
			// 
			this.statusLbl.ForeColor = System.Drawing.Color.White;
			this.statusLbl.Name = "statusLbl";
			this.statusLbl.Size = new System.Drawing.Size(39, 17);
			this.statusLbl.Text = "Ready";
			// 
			// artPanel
			// 
			this.artPanel.AutoScroll = true;
			this.artPanel.Location = new System.Drawing.Point(270, 60);
			this.artPanel.Name = "artPanel";
			this.artPanel.Size = new System.Drawing.Size(1008, 589);
			this.artPanel.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1292, 679);
			this.Controls.Add(this.artPanel);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.Home);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Claudia";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.panel2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SelectArt)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NextAlbumArt)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.barArt)).EndInit();
			this.Home.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button PlayButton;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Panel Home;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button LikesButton;
		private System.Windows.Forms.Button PlayListsButton;
		private System.Windows.Forms.Button StreamButton;
		private System.Windows.Forms.PictureBox NextAlbumArt;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label NextTrack;
		private System.Windows.Forms.Button PrevButton;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label SelectTrack;
		private System.Windows.Forms.PictureBox SelectArt;
		private System.Windows.Forms.Label barTrackInfo;
		private System.Windows.Forms.PictureBox barArt;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLbl;
		private System.Windows.Forms.Label TrackDuration;
		private System.Windows.Forms.Button LoginButton;
		private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
		private System.Windows.Forms.Button PlayerButton;
		private System.Windows.Forms.FlowLayoutPanel artPanel;
	}
}