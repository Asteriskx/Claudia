using System;
using System.Windows.Forms;

namespace Claudia
{
	/// <summary>
	/// ストリーミング再生を行う際に使用するプレイヤー管理クラス
	/// </summary>
	public partial class SelectPlayerForm : Form
	{
		#region Properties

		/// <summary>
		/// AIMP4
		/// </summary>
		public bool IsAIMP4Checked { get; private set; } = false;

		/// <summary>
		/// Windows Media Player
		/// </summary>
		public bool IsWMPChecked { get; private set; } = false;

		/// <summary>
		/// MusicBee
		/// </summary>
		public bool IsMusicBeeChecked { get; private set; } = false;

		#endregion Properties

		#region Constructor

		public SelectPlayerForm(bool aimp4, bool wmp, bool musicBee)
		{
			InitializeComponent();

			this.IsAIMP4Checked = aimp4;
			this.IsWMPChecked = wmp;
			this.IsMusicBeeChecked = musicBee;
		}

		#endregion Constructor

		#region Event Handler

		private void SelectPlayerForm_Load(object sender, EventArgs e)
		{
			if (this.IsAIMP4Checked) this.CheckBoxAIMP4.Checked = true;
			else if (this.IsWMPChecked) this.CheckBoxWMP.Checked = true;
			else if (this.IsMusicBeeChecked) this.CheckBoxMB.Checked = true;

			this.OKButton.Click += (s, v) =>
			{
				if (this.CheckBoxAIMP4.Checked)
				{
					this.IsAIMP4Checked = true;
					this.IsWMPChecked = false;
					this.IsMusicBeeChecked = false;
				}
				else if (this.CheckBoxWMP.Checked)
				{
					this.IsAIMP4Checked = false;
					this.IsWMPChecked = true;
					this.IsMusicBeeChecked = false;
				}
				else if (this.CheckBoxMB.Checked)
				{
					this.IsAIMP4Checked = false;
					this.IsWMPChecked = false;
					this.IsMusicBeeChecked = true;
				}
				else
				{
					// NOP
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			};
		}

		#endregion Event Handler
	}
}
