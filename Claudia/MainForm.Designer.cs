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
			this.AccessButton = new System.Windows.Forms.Button();
			this.tokenInfo = new System.Windows.Forms.Label();
			this.loginInfo = new System.Windows.Forms.Label();
			this.loginButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ResultView = new System.Windows.Forms.ListView();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AccessButton);
			this.groupBox1.Controls.Add(this.tokenInfo);
			this.groupBox1.Controls.Add(this.loginInfo);
			this.groupBox1.Controls.Add(this.loginButton);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.ForeColor = System.Drawing.Color.Blue;
			this.groupBox1.Location = new System.Drawing.Point(12, 507);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(714, 98);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "各種ステータス";
			// 
			// AccessButton
			// 
			this.AccessButton.Location = new System.Drawing.Point(554, 59);
			this.AccessButton.Name = "AccessButton";
			this.AccessButton.Size = new System.Drawing.Size(154, 31);
			this.AccessButton.TabIndex = 5;
			this.AccessButton.Text = "曲情報取得";
			this.AccessButton.UseVisualStyleBackColor = true;
			this.AccessButton.Click += new System.EventHandler(this.AccessButton_Click);
			// 
			// tokenInfo
			// 
			this.tokenInfo.AutoSize = true;
			this.tokenInfo.Location = new System.Drawing.Point(142, 59);
			this.tokenInfo.Name = "tokenInfo";
			this.tokenInfo.Size = new System.Drawing.Size(188, 18);
			this.tokenInfo.TabIndex = 4;
			this.tokenInfo.Text = "トークン取得状況を表示します。";
			// 
			// loginInfo
			// 
			this.loginInfo.AutoSize = true;
			this.loginInfo.Location = new System.Drawing.Point(144, 32);
			this.loginInfo.Name = "loginInfo";
			this.loginInfo.Size = new System.Drawing.Size(164, 18);
			this.loginInfo.TabIndex = 3;
			this.loginInfo.Text = "ログイン情報を表示します。";
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(394, 59);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(154, 31);
			this.loginButton.TabIndex = 2;
			this.loginButton.Text = "ログイン";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "トークン取得状況：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "ログイン状況：";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(27, 18);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(300, 300);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ResultView);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.pictureBox1);
			this.groupBox2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox2.ForeColor = System.Drawing.Color.Blue;
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(708, 489);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "曲情報";
			// 
			// ResultView
			// 
			this.ResultView.Location = new System.Drawing.Point(27, 324);
			this.ResultView.Name = "ResultView";
			this.ResultView.Size = new System.Drawing.Size(644, 159);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 617);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

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
	}
}