using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_OPLog 的摘要说明。
	/// </summary>
	public class clsCtl_OPLog: com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_OPLog objSvc =new clsDcl_OPLog(); 
		public clsCtl_OPLog()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmOPLog m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmOPLog)frmMDI_Child_Base_in;
		}
		#endregion
		public void m_mthLogData()
		{
			string strTemp ="";
            this.m_objViewer.objReportDocument.Load(this.m_objViewer.strAppPatch + "Report\\rptOPLog.rpt");
			if(this.m_objViewer.txtDepartment.m_StrDeptID!=null&&this.m_objViewer.txtDepartment.m_StrDeptID.Trim()!=""&&this.m_objViewer.txtDepartment.Text.Trim()!="")
			{
			strTemp +=" and a.DIAGDEPT_CHR ='"+this.m_objViewer.txtDepartment.m_StrDeptID.Trim()+"'";
			}
			if(this.m_objViewer.txtReportDoctor.m_StrEmployeeID!=null&&this.m_objViewer.txtReportDoctor.m_StrEmployeeID.Trim()!=""&&this.m_objViewer.txtReportDoctor.Text.Trim()!="")
			{
				strTemp +=" and a.DIAGDR_CHR ='"+this.m_objViewer.txtReportDoctor.m_StrEmployeeID.Trim()+"'";
			}
			if(this.m_objViewer.txtDiag.Text.Trim()!="")
			{
				strTemp +=" and c.DIAG_VCHR like '%"+this.m_objViewer.txtDiag.Text.Trim()+"%'";
			}
			if(this.m_objViewer.chkCheckDate.Checked)
			{
				strTemp +=@" AND a.RECORDDATE_DAT BETWEEN TO_DATE('"+this.m_objViewer.dtpFrom.Value.ToString("yyyy-MM-dd 00:00:00")+"','yyyy-mm-dd hh24:mi:ss') "+
					" AND TO_DATE('"+this.m_objViewer.dtpTo.Value.ToString("yyyy-MM-dd 23:59:59")+@" ','yyyy-mm-dd hh24:mi:ss')";
			}
			if(strTemp==""&&this.m_objViewer.txtICD.Text.Trim()=="")
			{
				MessageBox.Show("请输入查询条件!");
				return;
			}
			DataTable dt;
			objSvc.m_mthLogData(out dt,strTemp,this.m_objViewer.txtICD.Text.Trim());
			this.m_objViewer.objReportDocument.SetDataSource(dt);
			if(this.m_objViewer.crystalReportViewer1.ReportSource ==null)
			{
				this.m_objViewer.crystalReportViewer1.ReportSource =this.m_objViewer.objReportDocument;
			}
			else
			{
				this.m_objViewer.objReportDocument.Refresh();
				this.m_objViewer.crystalReportViewer1.RefreshReport();
			}
		}
	}
}
