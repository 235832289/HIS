using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmHandInputReportPreferences 的摘要说明。
	/// </summary>
	public class frmHandInputReportPreferences : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		internal PinkieControls.ButtonXP m_btnConfirm;
		internal PinkieControls.ButtonXP m_btnCancel;
		internal System.Windows.Forms.CheckBox m_chkUseBatchConfirmStyle;
		internal System.Windows.Forms.CheckBox m_chkAutoPrint;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHandInputReportPreferences()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHandInputReportPreferences));
            this.m_btnConfirm = new PinkieControls.ButtonXP();
            this.m_btnCancel = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_chkUseBatchConfirmStyle = new System.Windows.Forms.CheckBox();
            this.m_chkAutoPrint = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // m_btnConfirm
            // 
            this.m_btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnConfirm.DefaultScheme = true;
            this.m_btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnConfirm.Hint = "";
            this.m_btnConfirm.Location = new System.Drawing.Point(168, 136);
            this.m_btnConfirm.Name = "m_btnConfirm";
            this.m_btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirm.Size = new System.Drawing.Size(76, 32);
            this.m_btnConfirm.TabIndex = 9;
            this.m_btnConfirm.Text = "确定";
            this.m_btnConfirm.Click += new System.EventHandler(this.m_btnConfirm_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCancel.DefaultScheme = true;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Hint = "";
            this.m_btnCancel.Location = new System.Drawing.Point(260, 136);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancel.Size = new System.Drawing.Size(76, 32);
            this.m_btnCancel.TabIndex = 10;
            this.m_btnCancel.Text = "取消";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(8, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 4);
            this.panel1.TabIndex = 11;
            // 
            // m_chkUseBatchConfirmStyle
            // 
            this.m_chkUseBatchConfirmStyle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkUseBatchConfirmStyle.Location = new System.Drawing.Point(20, 16);
            this.m_chkUseBatchConfirmStyle.Name = "m_chkUseBatchConfirmStyle";
            this.m_chkUseBatchConfirmStyle.Size = new System.Drawing.Size(128, 24);
            this.m_chkUseBatchConfirmStyle.TabIndex = 12;
            this.m_chkUseBatchConfirmStyle.Text = "使用批审核风格";
            // 
            // m_chkAutoPrint
            // 
            this.m_chkAutoPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkAutoPrint.Location = new System.Drawing.Point(20, 44);
            this.m_chkAutoPrint.Name = "m_chkAutoPrint";
            this.m_chkAutoPrint.Size = new System.Drawing.Size(128, 24);
            this.m_chkAutoPrint.TabIndex = 13;
            this.m_chkAutoPrint.Text = "审核后自动打印";
            // 
            // frmHandInputReportPreferences
            // 
            this.AcceptButton = this.m_btnConfirm;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(358, 179);
            this.Controls.Add(this.m_chkAutoPrint);
            this.Controls.Add(this.m_chkUseBatchConfirmStyle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnConfirm);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHandInputReportPreferences";
            this.ShowInTaskbar = false;
            this.Text = "整合报告用户首选项设置";
            this.Load += new System.EventHandler(this.frmHandInputReportPreferences_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_btnConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strConfigFilePath = Application.ExecutablePath + ".config";
				System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
				appConfig.Load(strConfigFilePath);

				appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"Preference_frmReportInput_BatchConfirmStyle\"]").Attributes["value"].Value = this.m_chkUseBatchConfirmStyle.Checked.ToString();
				appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"Preference_frmReportInput_AutoPrint\"]").Attributes["value"].Value = this.m_chkAutoPrint.Checked.ToString();

				appConfig.Save(strConfigFilePath);
			}
			catch(Exception ex)
			{
			}		
		}

		private void m_btnCancel_Click(object sender, System.EventArgs e)
		{
			
		}
		private void frmHandInputReportPreferences_Load(object sender, System.EventArgs e)
		{
			try
			{
				string strConfigFilePath = Application.ExecutablePath + ".config";
				System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
				appConfig.Load(strConfigFilePath);

				string strBatchConfirm = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"Preference_frmReportInput_BatchConfirmStyle\"]").Attributes["value"].Value;
				string strAutoPrint = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"Preference_frmReportInput_AutoPrint\"]").Attributes["value"].Value;

				this.m_chkUseBatchConfirmStyle.Checked = bool.Parse(strBatchConfirm);
				this.m_chkAutoPrint.Checked = bool.Parse(strAutoPrint);
			}
			catch(Exception ex)
			{
			}		
		}
	}
}
