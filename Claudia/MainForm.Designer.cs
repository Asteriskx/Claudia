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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.PlayerButton = new System.Windows.Forms.Button();
			this.LoginButton = new System.Windows.Forms.Button();
			this.LikesButton = new System.Windows.Forms.Button();
			this.PlayListsButton = new System.Windows.Forms.Button();
			this.StreamButton = new System.Windows.Forms.Button();
			this.NextTrack = new System.Windows.Forms.Label();
			this.NextAlbumArt = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.VolumeBar = new System.Windows.Forms.TrackBar();
			this.TrackDuration = new System.Windows.Forms.Label();
			this.CurrentTrack = new System.Windows.Forms.Label();
			this.PrevButton = new System.Windows.Forms.Button();
			this.PlayButton = new System.Windows.Forms.Button();
			this.NextButton = new System.Windows.Forms.Button();
			this.artPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.axWmp = new AxWMPLib.AxWindowsMediaPlayer();
			this.CurrentArtwork = new System.Windows.Forms.PictureBox();
			this.CurrentPosition = new System.Windows.Forms.TrackBar();
			this.NextArtist = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CurrentArtist = new System.Windows.Forms.Label();
			this.CurrentInfo = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NextAlbumArt)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWmp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentArtwork)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentPosition)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.panel2.Controls.Add(this.PlayerButton);
			this.panel2.Controls.Add(this.LoginButton);
			this.panel2.Controls.Add(this.LikesButton);
			this.panel2.Controls.Add(this.PlayListsButton);
			this.panel2.Controls.Add(this.StreamButton);
			this.panel2.Location = new System.Drawing.Point(0, -2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(50, 719);
			this.panel2.TabIndex = 5;
			// 
			// PlayerButton
			// 
			this.PlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.PlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayerButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayerButton.ForeColor = System.Drawing.Color.White;
			this.PlayerButton.Image = global::Claudia.Properties.Resources.player;
			this.PlayerButton.Location = new System.Drawing.Point(5, 47);
			this.PlayerButton.Name = "PlayerButton";
			this.PlayerButton.Size = new System.Drawing.Size(40, 40);
			this.PlayerButton.TabIndex = 18;
			this.PlayerButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.PlayerButton.UseVisualStyleBackColor = false;
			this.PlayerButton.Click += new System.EventHandler(this.PlayerButton_Click);
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LoginButton.ForeColor = System.Drawing.Color.White;
			this.LoginButton.Image = global::Claudia.Properties.Resources.account;
			this.LoginButton.Location = new System.Drawing.Point(5, 8);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(40, 40);
			this.LoginButton.TabIndex = 17;
			this.LoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// LikesButton
			// 
			this.LikesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LikesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LikesButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LikesButton.ForeColor = System.Drawing.Color.White;
			this.LikesButton.Image = global::Claudia.Properties.Resources.fav;
			this.LikesButton.Location = new System.Drawing.Point(5, 164);
			this.LikesButton.Name = "LikesButton";
			this.LikesButton.Size = new System.Drawing.Size(40, 40);
			this.LikesButton.TabIndex = 2;
			this.LikesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.LikesButton.UseVisualStyleBackColor = false;
			this.LikesButton.Click += new System.EventHandler(this.LikesButton_Click);
			// 
			// PlayListsButton
			// 
			this.PlayListsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.PlayListsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayListsButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayListsButton.ForeColor = System.Drawing.Color.White;
			this.PlayListsButton.Image = global::Claudia.Properties.Resources.playlist;
			this.PlayListsButton.Location = new System.Drawing.Point(5, 125);
			this.PlayListsButton.Name = "PlayListsButton";
			this.PlayListsButton.Size = new System.Drawing.Size(40, 40);
			this.PlayListsButton.TabIndex = 1;
			this.PlayListsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.PlayListsButton.UseVisualStyleBackColor = false;
			this.PlayListsButton.Click += new System.EventHandler(this.PlayListsButton_Click);
			// 
			// StreamButton
			// 
			this.StreamButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.StreamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StreamButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.StreamButton.ForeColor = System.Drawing.Color.White;
			this.StreamButton.Image = global::Claudia.Properties.Resources.stream;
			this.StreamButton.Location = new System.Drawing.Point(5, 86);
			this.StreamButton.Name = "StreamButton";
			this.StreamButton.Size = new System.Drawing.Size(40, 40);
			this.StreamButton.TabIndex = 0;
			this.StreamButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.StreamButton.UseVisualStyleBackColor = false;
			this.StreamButton.Click += new System.EventHandler(this.StreamButton_Click);
			// 
			// NextTrack
			// 
			this.NextTrack.AutoEllipsis = true;
			this.NextTrack.AutoSize = true;
			this.NextTrack.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NextTrack.ForeColor = System.Drawing.Color.White;
			this.NextTrack.Location = new System.Drawing.Point(101, 36);
			this.NextTrack.MaximumSize = new System.Drawing.Size(210, 18);
			this.NextTrack.Name = "NextTrack";
			this.NextTrack.Size = new System.Drawing.Size(107, 18);
			this.NextTrack.TabIndex = 15;
			this.NextTrack.Text = "Next TrackName";
			// 
			// NextAlbumArt
			// 
			this.NextAlbumArt.Image = global::Claudia.Properties.Resources.none;
			this.NextAlbumArt.Location = new System.Drawing.Point(14, 22);
			this.NextAlbumArt.Name = "NextAlbumArt";
			this.NextAlbumArt.Size = new System.Drawing.Size(70, 70);
			this.NextAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.NextAlbumArt.TabIndex = 14;
			this.NextAlbumArt.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel3.Controls.Add(this.CurrentPosition);
			this.panel3.Controls.Add(this.VolumeBar);
			this.panel3.Controls.Add(this.TrackDuration);
			this.panel3.Controls.Add(this.PrevButton);
			this.panel3.Controls.Add(this.PlayButton);
			this.panel3.Controls.Add(this.NextButton);
			this.panel3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.panel3.Location = new System.Drawing.Point(0, 715);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1320, 48);
			this.panel3.TabIndex = 5;
			// 
			// VolumeBar
			// 
			this.VolumeBar.Location = new System.Drawing.Point(1175, 16);
			this.VolumeBar.Maximum = 100;
			this.VolumeBar.Name = "VolumeBar";
			this.VolumeBar.Size = new System.Drawing.Size(104, 45);
			this.VolumeBar.TabIndex = 20;
			this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
			// 
			// TrackDuration
			// 
			this.TrackDuration.AutoSize = true;
			this.TrackDuration.ForeColor = System.Drawing.Color.White;
			this.TrackDuration.Location = new System.Drawing.Point(995, 16);
			this.TrackDuration.Name = "TrackDuration";
			this.TrackDuration.Size = new System.Drawing.Size(33, 18);
			this.TrackDuration.TabIndex = 19;
			this.TrackDuration.Text = "--:--";
			// 
			// CurrentTrack
			// 
			this.CurrentTrack.AutoEllipsis = true;
			this.CurrentTrack.AutoSize = true;
			this.CurrentTrack.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CurrentTrack.ForeColor = System.Drawing.Color.White;
			this.CurrentTrack.Location = new System.Drawing.Point(135, 29);
			this.CurrentTrack.MaximumSize = new System.Drawing.Size(600, 18);
			this.CurrentTrack.Name = "CurrentTrack";
			this.CurrentTrack.Size = new System.Drawing.Size(84, 18);
			this.CurrentTrack.TabIndex = 18;
			this.CurrentTrack.Text = "CurrentTrack";
			// 
			// PrevButton
			// 
			this.PrevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PrevButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PrevButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.PrevButton.Image = global::Claudia.Properties.Resources.prev;
			this.PrevButton.Location = new System.Drawing.Point(1049, 8);
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
			this.PlayButton.Location = new System.Drawing.Point(1089, 8);
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
			this.NextButton.Location = new System.Drawing.Point(1130, 8);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(35, 35);
			this.NextButton.TabIndex = 12;
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// artPanel
			// 
			this.artPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.artPanel.AutoScroll = true;
			this.artPanel.Location = new System.Drawing.Point(51, 128);
			this.artPanel.Name = "artPanel";
			this.artPanel.Size = new System.Drawing.Size(1269, 589);
			this.artPanel.TabIndex = 7;
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "notifyIcon1";
			this.notifyIcon.Visible = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel1.Controls.Add(this.CurrentInfo);
			this.panel1.Controls.Add(this.CurrentArtist);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.CurrentArtwork);
			this.panel1.Controls.Add(this.CurrentTrack);
			this.panel1.Location = new System.Drawing.Point(50, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1270, 131);
			this.panel1.TabIndex = 8;
			// 
			// axWmp
			// 
			this.axWmp.Enabled = true;
			this.axWmp.Location = new System.Drawing.Point(1140, 12);
			this.axWmp.Name = "axWmp";
			this.axWmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWmp.OcxState")));
			this.axWmp.Size = new System.Drawing.Size(125, 46);
			this.axWmp.TabIndex = 7;
			this.axWmp.Visible = false;
			// 
			// CurrentArtwork
			// 
			this.CurrentArtwork.Image = global::Claudia.Properties.Resources.none;
			this.CurrentArtwork.Location = new System.Drawing.Point(8, 11);
			this.CurrentArtwork.Name = "CurrentArtwork";
			this.CurrentArtwork.Size = new System.Drawing.Size(109, 110);
			this.CurrentArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CurrentArtwork.TabIndex = 17;
			this.CurrentArtwork.TabStop = false;
			// 
			// CurrentPosition
			// 
			this.CurrentPosition.LargeChange = 1;
			this.CurrentPosition.Location = new System.Drawing.Point(22, 16);
			this.CurrentPosition.Maximum = 100;
			this.CurrentPosition.Name = "CurrentPosition";
			this.CurrentPosition.Size = new System.Drawing.Size(967, 45);
			this.CurrentPosition.TabIndex = 21;
			this.CurrentPosition.TickStyle = System.Windows.Forms.TickStyle.None;
			this.CurrentPosition.Scroll += new System.EventHandler(this.CurrentPosition_Scroll);
			// 
			// NextArtist
			// 
			this.NextArtist.AutoEllipsis = true;
			this.NextArtist.AutoSize = true;
			this.NextArtist.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NextArtist.ForeColor = System.Drawing.Color.White;
			this.NextArtist.Location = new System.Drawing.Point(101, 60);
			this.NextArtist.MaximumSize = new System.Drawing.Size(210, 18);
			this.NextArtist.Name = "NextArtist";
			this.NextArtist.Size = new System.Drawing.Size(72, 18);
			this.NextArtist.TabIndex = 19;
			this.NextArtist.Text = "Next Artist";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.NextAlbumArt);
			this.groupBox1.Controls.Add(this.NextArtist);
			this.groupBox1.Controls.Add(this.NextTrack);
			this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(948, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(309, 105);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Next TrackInfo";
			// 
			// CurrentArtist
			// 
			this.CurrentArtist.AutoEllipsis = true;
			this.CurrentArtist.AutoSize = true;
			this.CurrentArtist.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CurrentArtist.ForeColor = System.Drawing.Color.White;
			this.CurrentArtist.Location = new System.Drawing.Point(135, 57);
			this.CurrentArtist.MaximumSize = new System.Drawing.Size(600, 18);
			this.CurrentArtist.Name = "CurrentArtist";
			this.CurrentArtist.Size = new System.Drawing.Size(84, 18);
			this.CurrentArtist.TabIndex = 21;
			this.CurrentArtist.Text = "CurrentArtist";
			// 
			// CurrentInfo
			// 
			this.CurrentInfo.AutoEllipsis = true;
			this.CurrentInfo.AutoSize = true;
			this.CurrentInfo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CurrentInfo.ForeColor = System.Drawing.Color.White;
			this.CurrentInfo.Location = new System.Drawing.Point(135, 86);
			this.CurrentInfo.MaximumSize = new System.Drawing.Size(600, 18);
			this.CurrentInfo.Name = "CurrentInfo";
			this.CurrentInfo.Size = new System.Drawing.Size(75, 18);
			this.CurrentInfo.TabIndex = 22;
			this.CurrentInfo.Text = "CurrentInfo";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1320, 763);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.axWmp);
			this.Controls.Add(this.artPanel);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Claudia";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NextAlbumArt)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWmp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentArtwork)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentPosition)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button PlayButton;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button LikesButton;
		private System.Windows.Forms.Button PlayListsButton;
		private System.Windows.Forms.Button StreamButton;
		private System.Windows.Forms.PictureBox NextAlbumArt;
		private System.Windows.Forms.Label NextTrack;
		private System.Windows.Forms.Button PrevButton;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label CurrentTrack;
		private System.Windows.Forms.Label TrackDuration;
		private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.Button PlayerButton;
		private System.Windows.Forms.FlowLayoutPanel artPanel;
		private System.Windows.Forms.TrackBar VolumeBar;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private AxWMPLib.AxWindowsMediaPlayer axWmp;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox CurrentArtwork;
		private System.Windows.Forms.TrackBar CurrentPosition;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label NextArtist;
		private System.Windows.Forms.Label CurrentInfo;
		private System.Windows.Forms.Label CurrentArtist;
	}
}