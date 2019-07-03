using System;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsDomainControlHISMedxgReport 的摘要说明。
	/// </summary>
	public class clsDomainControlHISMedxgReport: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControlHISMedxgReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 调用中间件方法，返回数据表
		
		public long m_lngGetMedReport(string m_dtpStartDate,string m_dtpEndDate, out System.Data.DataTable dt )
		{
			long lngRes = 0; 
			dt = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsHISMedTypexgReportSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsHISMedTypexgReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsHISMedTypexgReportSvc));
			lngRes=objSvc.m_lngGetMedReport( m_dtpStartDate, m_dtpEndDate,out dt);
			return lngRes;
		
		}
		#endregion

	}

}
