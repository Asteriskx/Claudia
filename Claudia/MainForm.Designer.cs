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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tokenInfo = new System.Windows.Forms.Label();
			this.loginInfo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.AccessButton = new System.Windows.Forms.Button();
			this.loginButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.StopButton = new System.Windows.Forms.Button();
			this.PlayButton = new System.Windows.Forms.Button();
			this.ResultView = new System.Windows.Forms.ListView();
			this.label7 = new System.Windows.Forms.Label();
			this.NextButton = new System.Windows.Forms.Button();
			this.TrackInfo = new System.Windows.Forms.RichTextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.StreamButton = new System.Windows.Forms.Button();
			this.PlayListsButton = new System.Windows.Forms.Button();
			this.LikesButton = new System.Windows.Forms.Button();
			this.NextAlbumArt = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.NextTrack = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NextAlbumArt)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tokenInfo);
			this.groupBox1.Controls.Add(this.loginInfo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(12, 483);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 79);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Status";
			// 
			// tokenInfo
			// 
			this.tokenInfo.AutoSize = true;
			this.tokenInfo.Location = new System.Drawing.Point(72, 48);
			this.tokenInfo.Name = "tokenInfo";
			this.tokenInfo.Size = new System.Drawing.Size(28, 18);
			this.tokenInfo.TabIndex = 4;
			this.tokenInfo.Text = "null";
			// 
			// loginInfo
			// 
			this.loginInfo.AutoSize = true;
			this.loginInfo.Location = new System.Drawing.Point(72, 21);
			this.loginInfo.Name = "loginInfo";
			this.loginInfo.Size = new System.Drawing.Size(28, 18);
			this.loginInfo.TabIndex = 3;
			this.loginInfo.Text = "null";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Token : ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login :  ";
			// 
			// AccessButton
			// 
			this.AccessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AccessButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.AccessButton.ForeColor = System.Drawing.Color.White;
			this.AccessButton.Location = new System.Drawing.Point(98, 157);
			this.AccessButton.Name = "AccessButton";
			this.AccessButton.Size = new System.Drawing.Size(85, 43);
			this.AccessButton.TabIndex = 5;
			this.AccessButton.Text = "Get";
			this.AccessButton.UseVisualStyleBackColor = true;
			this.AccessButton.Click += new System.EventHandler(this.AccessButton_Click);
			// 
			// loginButton
			// 
			this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loginButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.loginButton.ForeColor = System.Drawing.Color.White;
			this.loginButton.Location = new System.Drawing.Point(7, 157);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(85, 43);
			this.loginButton.TabIndex = 2;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(18, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(223, 211);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.TrackInfo);
			this.groupBox2.Controls.Add(this.ResultView);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.pictureBox1);
			this.groupBox2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox2.ForeColor = System.Drawing.Color.Blue;
			this.groupBox2.Location = new System.Drawing.Point(264, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1030, 610);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TrackInfo";
			// 
			// StopButton
			// 
			this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StopButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.StopButton.ForeColor = System.Drawing.Color.White;
			this.StopButton.Location = new System.Drawing.Point(98, 206);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(85, 43);
			this.StopButton.TabIndex = 11;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// PlayButton
			// 
			this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayButton.ForeColor = System.Drawing.Color.White;
			this.PlayButton.Location = new System.Drawing.Point(7, 206);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(85, 43);
			this.PlayButton.TabIndex = 10;
			this.PlayButton.Text = "Play";
			this.PlayButton.UseVisualStyleBackColor = true;
			this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
			// 
			// ResultView
			// 
			this.ResultView.Location = new System.Drawing.Point(18, 241);
			this.ResultView.Name = "ResultView";
			this.ResultView.Size = new System.Drawing.Size(1006, 363);
			this.ResultView.TabIndex = 9;
			this.ResultView.UseCompatibleStateImageBehavior = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(153, 321);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(0, 18);
			this.label7.TabIndex = 5;
			// 
			// NextButton
			// 
			this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NextButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NextButton.ForeColor = System.Drawing.Color.White;
			this.NextButton.Location = new System.Drawing.Point(7, 255);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(85, 43);
			this.NextButton.TabIndex = 12;
			this.NextButton.Text = "Next";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// TrackInfo
			// 
			this.TrackInfo.Location = new System.Drawing.Point(247, 24);
			this.TrackInfo.Name = "TrackInfo";
			this.TrackInfo.Size = new System.Drawing.Size(777, 211);
			this.TrackInfo.TabIndex = 13;
			this.TrackInfo.Text = "";
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 625);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1294, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Tomato;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.panel1.Location = new System.Drawing.Point(0, -2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(257, 50);
			this.panel1.TabIndex = 4;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.LikesButton);
			this.panel2.Controls.Add(this.NextButton);
			this.panel2.Controls.Add(this.PlayListsButton);
			this.panel2.Controls.Add(this.AccessButton);
			this.panel2.Controls.Add(this.loginButton);
			this.panel2.Controls.Add(this.StreamButton);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.PlayButton);
			this.panel2.Controls.Add(this.StopButton);
			this.panel2.Location = new System.Drawing.Point(1, 47);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(257, 575);
			this.panel2.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(89, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 28);
			this.label3.TabIndex = 0;
			this.label3.Text = "Claudia";
			// 
			// StreamButton
			// 
			this.StreamButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.StreamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StreamButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.StreamButton.ForeColor = System.Drawing.Color.White;
			this.StreamButton.Location = new System.Drawing.Point(0, 0);
			this.StreamButton.Name = "StreamButton";
			this.StreamButton.Size = new System.Drawing.Size(257, 48);
			this.StreamButton.TabIndex = 0;
			this.StreamButton.Text = "Stream";
			this.StreamButton.UseVisualStyleBackColor = false;
			// 
			// PlayListsButton
			// 
			this.PlayListsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.PlayListsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayListsButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PlayListsButton.ForeColor = System.Drawing.Color.White;
			this.PlayListsButton.Location = new System.Drawing.Point(0, 46);
			this.PlayListsButton.Name = "PlayListsButton";
			this.PlayListsButton.Size = new System.Drawing.Size(257, 48);
			this.PlayListsButton.TabIndex = 1;
			this.PlayListsButton.Text = "PlayLists";
			this.PlayListsButton.UseVisualStyleBackColor = false;
			// 
			// LikesButton
			// 
			this.LikesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LikesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LikesButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LikesButton.ForeColor = System.Drawing.Color.White;
			this.LikesButton.Location = new System.Drawing.Point(0, 92);
			this.LikesButton.Name = "LikesButton";
			this.LikesButton.Size = new System.Drawing.Size(257, 48);
			this.LikesButton.TabIndex = 2;
			this.LikesButton.Text = "Likes";
			this.LikesButton.UseVisualStyleBackColor = false;
			this.LikesButton.MouseLeave += new System.EventHandler(this.LikesButton_MouseLeave);
			this.LikesButton.MouseHover += new System.EventHandler(this.LikesButton_MouseHover);
			// 
			// NextAlbumArt
			// 
			this.NextAlbumArt.Location = new System.Drawing.Point(17, 24);
			this.NextAlbumArt.Name = "NextAlbumArt";
			this.NextAlbumArt.Size = new System.Drawing.Size(110, 110);
			this.NextAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.NextAlbumArt.TabIndex = 14;
			this.NextAlbumArt.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.NextTrack);
			this.groupBox3.Controls.Add(this.NextAlbumArt);
			this.groupBox3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.ForeColor = System.Drawing.Color.White;
			this.groupBox3.Location = new System.Drawing.Point(12, 304);
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
			this.NextTrack.Location = new System.Drawing.Point(17, 141);
			this.NextTrack.MaximumSize = new System.Drawing.Size(210, 18);
			this.NextTrack.Name = "NextTrack";
			this.NextTrack.Size = new System.Drawing.Size(107, 18);
			this.NextTrack.TabIndex = 15;
			this.NextTrack.Text = "Next TrackName";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1294, 647);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox2);
			this.Name = "MainForm";
			this.Text = "Claudia β";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NextAlbumArt)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label tokenInfo;
		private System.Windows.Forms.Label loginInfo;
		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView ResultView;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button AccessButton;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Button PlayButton;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.RichTextBox TrackInfo;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button LikesButton;
		private System.Windows.Forms.Button PlayListsButton;
		private System.Windows.Forms.Button StreamButton;
		private System.Windows.Forms.PictureBox NextAlbumArt;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label NextTrack;
	}
}