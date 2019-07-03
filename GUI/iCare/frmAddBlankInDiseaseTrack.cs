using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmAddBlankInDiseaseTrack.
	/// </summary>
	public class frmAddBlankInDiseaseTrack : iCare.iCareBaseForm.frmBaseForm
	{
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private System.Windows.Forms.Label m_lblDescribe;
		public com.digitalwave.Utility.Controls.ctlComboBox m_cboLineCount;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddBlankInDiseaseTrack()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_lblDescribe.Text = "    请选择需要在所选记录之前插入的行数,一行约0.4cm。";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddBlankInDiseaseTrack));
			this.m_lblDescribe = new System.Windows.Forms.Label();
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.m_cboLineCount = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.SuspendLayout();
			// 
			// m_lblDescribe
			// 
			this.m_lblDescribe.Location = new System.Drawing.Point(20, 12);
			this.m_lblDescribe.Name = "m_lblDescribe";
			this.m_lblDescribe.Size = new System.Drawing.Size(332, 80);
			this.m_lblDescribe.TabIndex = 0;
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(180, 103);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(75, 28);
			this.m_cmdOK.TabIndex = 1;
			this.m_cmdOK.Text = "确  定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(276, 103);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(75, 28);
			this.m_cmdCancel.TabIndex = 1;
			this.m_cmdCancel.Text = "取  消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_cboLineCount
			// 
			this.m_cboLineCount.AccessibleDescription = "";
			this.m_cboLineCount.BackColor = System.Drawing.SystemColors.Control;
			this.m_cboLineCount.BorderColor = System.Drawing.Color.Black;
			this.m_cboLineCount.DropButtonBackColor = System.Drawing.SystemColors.ScrollBar;
			this.m_cboLineCount.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboLineCount.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboLineCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboLineCount.flatFont = new System.Drawing.Font("宋体", 10.5F);
			this.m_cboLineCount.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cboLineCount.ForeColor = System.Drawing.Color.White;
			this.m_cboLineCount.ListBackColor = System.Drawing.Color.White;
			this.m_cboLineCount.ListForeColor = System.Drawing.Color.Black;
			this.m_cboLineCount.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboLineCount.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboLineCount.Location = new System.Drawing.Point(16, 104);
			this.m_cboLineCount.m_BlnEnableItemEventMenu = true;
			this.m_cboLineCount.Name = "m_cboLineCount";
			this.m_cboLineCount.SelectedIndex = -1;
			this.m_cboLineCount.SelectedItem = null;
			this.m_cboLineCount.Size = new System.Drawing.Size(132, 23);
			this.m_cboLineCount.TabIndex = 112;
			this.m_cboLineCount.TextBackColor = System.Drawing.Color.White;
			this.m_cboLineCount.TextForeColor = System.Drawing.Color.Black;
			this.m_cboLineCount.DropDown += new System.EventHandler(this.m_cboLineCount_DropDown);
			this.m_cboLineCount.TextChanged += new System.EventHandler(this.m_cboLineCount_TextChanged);
			this.m_cboLineCount.SelectedValueChanged += new System.EventHandler(this.m_cboLineCount_TextChanged);
			// 
			// frmAddBlankInDiseaseTrack
			// 
			this.AcceptButton = this.m_cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.m_cmdCancel;
			this.ClientSize = new System.Drawing.Size(366, 147);
			this.Controls.Add(this.m_cboLineCount);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.m_lblDescribe);
			this.Controls.Add(this.m_cmdCancel);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddBlankInDiseaseTrack";
			this.Text = "空白行插入";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cboLineCount_DropDown(object sender, System.EventArgs e)
		{
			m_cboLineCount.ClearItem();
			for(int i=1; i<=5; i++)
			{
				m_cboLineCount.AddItem(i.ToString());
			}
		}

		private void m_cboLineCount_TextChanged(object sender, System.EventArgs e)
		{
			int intCount = 0;
			double lngHeight = 0.0;
			try
			{
				intCount = Convert.ToInt32( m_cboLineCount.Text);
			}
			catch
			{
				m_cboLineCount.Text = "0";
			}
			if (intCount == 0)
			{
				m_lblDescribe.Text = "你选择了插入0行,这将没有任何改变!";
				return;
			}
			lngHeight = intCount * 0.4;
			m_lblDescribe.Text = "    你已选择在所选记录之前插入" + intCount + "个空行,约高" + lngHeight + "cm。";
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public int m_IntLineCount
		{
			get 
			{
				try
				{
					return Convert.ToInt32( m_cboLineCount.Text);
				}
				catch
				{}
				return 0;
			}
		}
	}
}
