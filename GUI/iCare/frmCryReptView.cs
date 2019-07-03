using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace iCare
{
	/// <summary>
	/// Summary description for frmCryReptView.
	/// </summary>
	public class frmCryReptView : iCare.iCareBaseForm.frmBaseForm
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer m_crvRept;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		TextObject txtobjA,txtobjB;
		public frmCryReptView(ReportDocument p_rpdRept)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			try
			{
				txtobjA = (TextObject)(p_rpdRept.ReportDefinition.ReportObjects["txtObjTitleA"]);
			}
			catch{txtobjA = null;}
			try
			{
				txtobjB = (TextObject)(p_rpdRept.ReportDefinition.ReportObjects["txtObjTitleB"]);
			}
			catch{txtobjB = null;}
			if(txtobjA != null)
				txtobjA.Text = clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle;
			if(txtobjB != null)
				txtobjB.Text = clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle;
			m_crvRept.ReportSource = p_rpdRept;
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
			this.m_crvRept = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// m_crvRept
			// 
			this.m_crvRept.ActiveViewIndex = -1;
			this.m_crvRept.DisplayGroupTree = false;
			this.m_crvRept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_crvRept.Name = "m_crvRept";
			this.m_crvRept.ReportSource = null;
			this.m_crvRept.ShowCloseButton = false;
			this.m_crvRept.ShowExportButton = false;
			this.m_crvRept.ShowGroupTreeButton = false;
			this.m_crvRept.Size = new System.Drawing.Size(1016, 729);
			this.m_crvRept.TabIndex = 0;
			// 
			// frmCryReptView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(1016, 729);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_crvRept});
			this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "frmCryReptView";
			this.Text = "±®±Ì¥Ú”°";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion
	}
}
