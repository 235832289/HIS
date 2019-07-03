using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlReckoningReport 的摘要说明。
	/// </summary>
	public class clsControlReckoningReport_Month:com.digitalwave.GUI_Base.clsController_Base
	{
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_rptRpt;
		clsDcl_ReckoningReport clsDomain;
		string str_firstDate,str_lasttDate;
		public clsControlReckoningReport_Month()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_rptRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			clsDomain = new clsDcl_ReckoningReport();
			
		}
		
		#region 设置窗体对象	张国良	 2004-9-9
		com.digitalwave.iCare.gui.HIS.frmReckoningReport_month m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmReckoningReport_month)frmMDI_Child_Base_in;

			
		}
		#endregion

		#region 报表数据  张国良	 2004-9-14
		public  void m_mthFindByDateReport()
		{
			str_firstDate=m_objViewer.m_daFinDate.Value.ToShortDateString();
			str_lasttDate=m_objViewer.m_daFinDateLast.Value.ToShortDateString();
			

			m_rptRpt.Load("Report\\AllOPREMP_month.rpt");
			DataTable m_dtRpt = new DataTable();
			DataTable m_dtRptDitial = new DataTable();
			long lngRes;
			lngRes =clsDomain.m_lngChargeMnothReport(str_firstDate,str_lasttDate,out m_dtRpt);
			if(lngRes>=1)
			{
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text =this.m_objComInfo.m_strGetHospitalTitle()+"收费处月结算表";
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["dateArear"]).Text ="统计日期: "+str_firstDate+" 至  " + str_lasttDate;
				m_rptRpt.SetDataSource(m_dtRpt);
				m_rptRpt.Refresh();
				m_objViewer.cryReportViewer.ReportSource=m_rptRpt;
			}				
		}
		#endregion
	}
}
