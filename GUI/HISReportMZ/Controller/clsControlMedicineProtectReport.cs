using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Data;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsControlReckoningReport 的摘要说明。
	/// </summary>
	public class clsControlMedicineProtectReport:com.digitalwave.GUI_Base.clsController_Base
	{
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_rptRpt;
		clsDcl_ReckoningReport clsDomain;
		string str_firstDate,str_lastDate;
		
		public clsControlMedicineProtectReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_rptRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			clsDomain = new clsDcl_ReckoningReport();
			
		}
		
		#region 设置窗体对象	张国良	 2004-9-9
        com.digitalwave.iCare.gui.HIS.Reports.frmMedicineProtectReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmMedicineProtectReport)frmMDI_Child_Base_in;
		}
		#endregion

		#region 报表数据  张国良	 2004-9-14
		public  void m_mthFindByDateReport()
		{          
			str_firstDate=m_objViewer.m_daFinDate.Value.ToShortDateString();
			str_lastDate=m_objViewer.m_daFinDateLast.Value.ToShortDateString();
            string strTime = "统计时间: "+str_firstDate+"至"+str_lastDate;
            //m_rptRpt.Load("Report\\rpt_medicineProtect.rpt");
			DataTable m_dtRpt = new DataTable();
            //DataTable m_dtRptDitial = new DataTable();
			long lngRes;
            string strType = clsPublic.m_strConvertSingleQuoteMark(clsPublic.m_strGetSysparm("0001"), ";").Replace(";", ",") ;
            lngRes = clsDomain.m_lngMeditionProtectReport(str_firstDate, str_lastDate, strType, out m_dtRpt);
			if(lngRes>=1)
			{
                //((TextObject)m_rptRpt.ReportDefinition.ReportObjects["acceptDate"]).Text ="就诊年月: "+Convert.ToDateTime(str_lastDate).Year+"-"+Convert.ToDateTime(str_lastDate).Month;
                ////((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle() + "医保月结算表";
                //((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = "佛山市城镇职工基本医疗便民医院（市二医院）月报表"; 
                //((TextObject)m_rptRpt.ReportDefinition.ReportObjects["unitName"]).Text = "单位名称: "+this.m_objComInfo.m_strGetHospitalTitle();
                //m_rptRpt.SetDataSource(m_dtRpt);
                //m_rptRpt.Refresh();
                //m_objViewer.cryReportViewer.ReportSource=m_rptRpt;
                this.m_objViewer.dw.SetRedrawOff();
                this.m_objViewer.dw.Retrieve(m_dtRpt);
                this.m_objViewer.dw.Modify("t_3.text='" + strTime + "'");
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();
			}
			
			
		}
		#endregion
	}
}
