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
	public class clsControlDepWorkReport:com.digitalwave.GUI_Base.clsController_Base
	{
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_rptRpt;
		clsDcl_ReckoningReport clsDomain;
		Double[]  Doe_ = new Double[18];
		string str_firstDate,str_lasttDate;
		public clsControlDepWorkReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_rptRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			clsDomain = new clsDcl_ReckoningReport();
			
		}
		
		#region 设置窗体对象	张国良	 2004-9-9
		com.digitalwave.iCare.gui.HIS.frmDepWorkReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmDepWorkReport)frmMDI_Child_Base_in;

			
		}
		#endregion

		#region 报表数据  张国良	 2004-9-14
		public  void m_mthFindByDateReport()
		{
			for(int i=0;i<17;i++)
			{
				Doe_[i] =0;
			}

			str_firstDate=m_objViewer.m_daFinDate.Value.ToShortDateString();
			str_lasttDate=m_objViewer.m_daFinDateLast.Value.ToShortDateString();
			

			m_rptRpt.Load("Report\\rptDepWork.rpt");
			DataTable m_dtRpt = new DataTable();
			DataTable m_dtRptDitial = new DataTable();
			long lngRes;
			lngRes =clsDomain.m_lngChargeMnothReport(str_firstDate,str_lasttDate,out m_dtRpt);
			if(lngRes>=1)
			{
				m_rptRpt.SetDataSource(m_dtRpt);
				m_rptRpt.Refresh();
				m_objViewer.cryReportViewer.ReportSource=m_rptRpt;
			}
			
			
		}
		#endregion
	}
}
