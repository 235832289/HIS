using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmMessageForm.
	/// </summary>
	public class frmMessageForm : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label m_txtInfoTitle;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMessageForm(string p_strMessageTitle,string p_strMessageInfo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_txtInfoTitle.Text=p_strMessageTitle.Trim();
			m_txtInfo.Text=p_strMessageInfo.Trim();
			m_txtInfo.ReadOnly=true;
			cmdOK.Focus();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessageForm));
			this.cmdOK = new System.Windows.Forms.Button();
			this.m_txtInfoTitle = new System.Windows.Forms.Label();
			this.m_txtInfo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdOK.Location = new System.Drawing.Point(600, 16);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(84, 28);
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "确  定";
			// 
			// m_txtInfoTitle
			// 
			this.m_txtInfoTitle.AutoSize = true;
			this.m_txtInfoTitle.Location = new System.Drawing.Point(36, 20);
			this.m_txtInfoTitle.Name = "m_txtInfoTitle";
			this.m_txtInfoTitle.Size = new System.Drawing.Size(47, 19);
			this.m_txtInfoTitle.TabIndex = 203;
			this.m_txtInfoTitle.Text = "信息:";
			this.m_txtInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtInfo
			// 
			this.m_txtInfo.AccessibleDescription = "红细胞积压比";
			this.m_txtInfo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtInfo.BorderColor = System.Drawing.Color.White;
			this.m_txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtInfo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtInfo.ForeColor = System.Drawing.Color.White;
			this.m_txtInfo.Location = new System.Drawing.Point(36, 52);
			this.m_txtInfo.MaxLength = 32778;
			this.m_txtInfo.Multiline = true;
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.Size = new System.Drawing.Size(652, 268);
			this.m_txtInfo.TabIndex = 2;
			this.m_txtInfo.Text = "";
			// 
			// frmMessageForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(720, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdOK,
																		  this.m_txtInfoTitle,
																		  this.m_txtInfo});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMessageForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "信息";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
