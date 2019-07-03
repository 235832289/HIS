using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// FrmShowPrint 的摘要说明。
	/// </summary>
	public class FrmShowPrint :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmShowPrint()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public void m_PrintRegister(System.Data.DataTable dtSource)
		{
			((clsControlPrint)this.objController).m_ShowRegister1(dtSource);
		}

		public void m_PrintRegister1(System.Data.DataTable dtSource)
		{
			((clsControlPrint)this.objController).m_PrintRegister1(dtSource);
		}
		public void m_ShowRegister11(System.Data.DataTable dtSource)
		{
			((clsControlPrint)this.objController).m_ShowRegister11(dtSource);
		}

		public void m_PrintRegister11(System.Data.DataTable dtSource)
		{
			((clsControlPrint)this.objController).m_PrintRegister11(dtSource);
		}
		public void m_CheckOutReg()
		{
			//((clsControlPrint)this.objController).m_CheckOutReg();
		}

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlPrint();
			objController.Set_GUI_Apperance(this);
		}

		#region 窗体代码
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowPrint));
            this.cryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cryReportViewer
            // 
            this.cryReportViewer.ActiveViewIndex = -1;
            this.cryReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryReportViewer.DisplayGroupTree = false;
            this.cryReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryReportViewer.Location = new System.Drawing.Point(0, 0);
            this.cryReportViewer.Name = "cryReportViewer";
            this.cryReportViewer.SelectionFormula = "";
            this.cryReportViewer.Size = new System.Drawing.Size(480, 413);
            this.cryReportViewer.TabIndex = 0;
            this.cryReportViewer.ViewTimeSelectionFormula = "";
            // 
            // FrmShowPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(480, 413);
            this.Controls.Add(this.cryReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShowPrint";
            this.Text = "打印预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

		}
		#endregion

		private void cryReportViewer_Load(object sender, System.EventArgs e)
		{
		
		}
		#endregion
	}
}
