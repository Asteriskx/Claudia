namespace Claudia
{
	partial class SelectPlayerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPlayerForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.CheckBoxMB = new System.Windows.Forms.CheckBox();
			this.CheckBoxWMP = new System.Windows.Forms.CheckBox();
			this.CheckBoxAIMP4 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.OKButton);
			this.groupBox1.Controls.Add(this.CheckBoxMB);
			this.groupBox1.Controls.Add(this.CheckBoxWMP);
			this.groupBox1.Controls.Add(this.CheckBoxAIMP4);
			this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 121);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SelectPlayer";
			// 
			// OKButton
			// 
			this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OKButton.ForeColor = System.Drawing.Color.White;
			this.OKButton.Location = new System.Drawing.Point(284, 85);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 6;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// CheckBoxMB
			// 
			this.CheckBoxMB.AutoSize = true;
			this.CheckBoxMB.Location = new System.Drawing.Point(27, 86);
			this.CheckBoxMB.Name = "CheckBoxMB";
			this.CheckBoxMB.Size = new System.Drawing.Size(181, 22);
			this.CheckBoxMB.TabIndex = 4;
			this.CheckBoxMB.Text = "MusicBee (Coming soon...)";
			this.CheckBoxMB.UseVisualStyleBackColor = true;
			// 
			// CheckBoxWMP
			// 
			this.CheckBoxWMP.AutoSize = true;
			this.CheckBoxWMP.Location = new System.Drawing.Point(27, 58);
			this.CheckBoxWMP.Name = "CheckBoxWMP";
			this.CheckBoxWMP.Size = new System.Drawing.Size(157, 22);
			this.CheckBoxWMP.TabIndex = 3;
			this.CheckBoxWMP.Text = "Windows Media Player";
			this.CheckBoxWMP.UseVisualStyleBackColor = true;
			// 
			// CheckBoxAIMP4
			// 
			this.CheckBoxAIMP4.AutoSize = true;
			this.CheckBoxAIMP4.Location = new System.Drawing.Point(27, 30);
			this.CheckBoxAIMP4.Name = "CheckBoxAIMP4";
			this.CheckBoxAIMP4.Size = new System.Drawing.Size(64, 22);
			this.CheckBoxAIMP4.TabIndex = 2;
			this.CheckBoxAIMP4.Text = "AIMP4";
			this.CheckBoxAIMP4.UseVisualStyleBackColor = true;
			// 
			// SelectPlayerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(401, 147);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SelectPlayerForm";
			this.Text = "Claudia - Player Select-";
			this.Load += new System.EventHandler(this.SelectPlayerForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.CheckBox CheckBoxMB;
		private System.Windows.Forms.CheckBox CheckBoxWMP;
		private System.Windows.Forms.CheckBox CheckBoxAIMP4;
	}
}