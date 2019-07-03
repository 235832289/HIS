using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmChooseCaseHistory.
	/// </summary>
	public class frmChooseCaseHistory : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox m_gpbChooseCase;
		private System.Windows.Forms.Button m_cmdOK;
		private System.Windows.Forms.RadioButton m_rdbChooseObstetrics;
		private System.Windows.Forms.RadioButton m_rdbChooseGyne;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private bool m_blnChooseResult = true;

		public frmChooseCaseHistory()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChooseCaseHistory));
			this.m_gpbChooseCase = new System.Windows.Forms.GroupBox();
			this.m_rdbChooseObstetrics = new System.Windows.Forms.RadioButton();
			this.m_rdbChooseGyne = new System.Windows.Forms.RadioButton();
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.m_gpbChooseCase.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gpbChooseCase
			// 
			this.m_gpbChooseCase.Controls.AddRange(new System.Windows.Forms.Control[] {
																						  this.m_rdbChooseObstetrics,
																						  this.m_rdbChooseGyne});
			this.m_gpbChooseCase.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_gpbChooseCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_gpbChooseCase.Name = "m_gpbChooseCase";
			this.m_gpbChooseCase.Size = new System.Drawing.Size(120, 103);
			this.m_gpbChooseCase.TabIndex = 0;
			this.m_gpbChooseCase.TabStop = false;
			// 
			// m_rdbChooseObstetrics
			// 
			this.m_rdbChooseObstetrics.Checked = true;
			this.m_rdbChooseObstetrics.Location = new System.Drawing.Point(16, 28);
			this.m_rdbChooseObstetrics.Name = "m_rdbChooseObstetrics";
			this.m_rdbChooseObstetrics.Size = new System.Drawing.Size(92, 24);
			this.m_rdbChooseObstetrics.TabIndex = 0;
			this.m_rdbChooseObstetrics.TabStop = true;
			this.m_rdbChooseObstetrics.Text = "产科病历";
			// 
			// m_rdbChooseGyne
			// 
			this.m_rdbChooseGyne.Location = new System.Drawing.Point(16, 64);
			this.m_rdbChooseGyne.Name = "m_rdbChooseGyne";
			this.m_rdbChooseGyne.Size = new System.Drawing.Size(92, 24);
			this.m_rdbChooseGyne.TabIndex = 0;
			this.m_rdbChooseGyne.Text = "妇科病历";
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Location = new System.Drawing.Point(128, 64);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(68, 32);
			this.m_cmdOK.TabIndex = 1;
			this.m_cmdOK.Text = "确 定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// frmChooseCaseHistory
			// 
			this.AcceptButton = this.m_cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(206, 103);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_gpbChooseCase,
																		  this.m_cmdOK});
			this.Font = new System.Drawing.Font("SimSun", 12F);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChooseCaseHistory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "请选择专科病历";
			this.TopMost = true;
			this.m_gpbChooseCase.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public bool m_BlnChooseResult
		{
			get{ return m_blnChooseResult;}
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			m_blnChooseResult = m_rdbChooseObstetrics.Checked;
		}
	}
}
