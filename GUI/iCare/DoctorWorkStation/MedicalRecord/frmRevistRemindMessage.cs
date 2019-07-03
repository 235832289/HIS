using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmRevistRemindMessage.
	/// </summary>
	public class frmRevistRemindMessage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private com.digitalwave.Utility.Controls.ctlRichTextBox m_txtRemindTips;
		private System.Windows.Forms.CheckBox m_chkNoNeedRemind;
		private System.Windows.Forms.Button m_cmdClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRevistRemindMessage(string _strRemindText)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_txtRemindTips.Text = _strRemindText;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRevistRemindMessage));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_chkNoNeedRemind = new System.Windows.Forms.CheckBox();
			this.m_cmdClose = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtRemindTips = new com.digitalwave.Utility.Controls.ctlRichTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 46);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 46);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// m_chkNoNeedRemind
			// 
			this.m_chkNoNeedRemind.Location = new System.Drawing.Point(16, 156);
			this.m_chkNoNeedRemind.Name = "m_chkNoNeedRemind";
			this.m_chkNoNeedRemind.TabIndex = 2;
			this.m_chkNoNeedRemind.Text = "不再提示";
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdClose.Location = new System.Drawing.Point(344, 152);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Size = new System.Drawing.Size(75, 28);
			this.m_cmdClose.TabIndex = 99;
			this.m_cmdClose.Text = "关  闭";
			this.m_cmdClose.Click += new System.EventHandler(this.m_cmdsave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_txtRemindTips,
																					this.pictureBox1});
			this.groupBox1.Location = new System.Drawing.Point(8, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 140);
			this.groupBox1.TabIndex = 100;
			this.groupBox1.TabStop = false;
			// 
			// m_txtRemindTips
			// 
			this.m_txtRemindTips.AccessibleDescription = "";
			this.m_txtRemindTips.AutoSize = true;
			this.m_txtRemindTips.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtRemindTips.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtRemindTips.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtRemindTips.ForeColor = System.Drawing.Color.White;
			this.m_txtRemindTips.Location = new System.Drawing.Point(80, 28);
			this.m_txtRemindTips.m_BlnPartControl = false;
			this.m_txtRemindTips.m_BlnReadOnly = true;
			this.m_txtRemindTips.m_BlnUnderLineDST = false;
			this.m_txtRemindTips.m_ClrDST = System.Drawing.Color.White;
			this.m_txtRemindTips.m_ClrOldPartInsertText = System.Drawing.Color.White;
			this.m_txtRemindTips.m_IntCanModifyTime = 0;
			this.m_txtRemindTips.m_IntPartControlLength = 0;
			this.m_txtRemindTips.m_IntPartControlStartIndex = 0;
			this.m_txtRemindTips.m_StrUserID = "";
			this.m_txtRemindTips.m_StrUserName = "";
			this.m_txtRemindTips.MaxLength = 32265;
			this.m_txtRemindTips.Name = "m_txtRemindTips";
			this.m_txtRemindTips.ReadOnly = true;
			this.m_txtRemindTips.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.m_txtRemindTips.Size = new System.Drawing.Size(332, 108);
			this.m_txtRemindTips.TabIndex = 93;
			this.m_txtRemindTips.Tag = "0";
			this.m_txtRemindTips.Text = "";
			// 
			// frmRevistRemindMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(432, 191);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1,
																		  this.m_cmdClose,
																		  this.m_chkNoNeedRemind});
			this.Font = new System.Drawing.Font("SimSun", 12F);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRevistRemindMessage";
			this.Opacity = 0.89999997615814209;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "出院病人复诊提示";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdsave_Click(object sender, System.EventArgs e)
		{
			bool blnNoNeedRemind = false;
			if(m_chkNoNeedRemind.Checked)
			{
				blnNoNeedRemind = true;
				MDIParent.m_BlnNoNeedRemind = true;
			}
			if(MDIParent.s_ObjCurrInPatientArea != null)
				new clsOutPatientRevisitDomain().m_lngSetOutDateRemindStatus(blnNoNeedRemind,MDIParent.s_ObjCurrInPatientArea.m_StrAreaID);
			this.Close();
		}

	}
}
