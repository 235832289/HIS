using System;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsDomainControlHISMedxgReport ��ժҪ˵����
	/// </summary>
	public class clsDomainControlHISMedxgReport: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControlHISMedxgReport()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region �����м���������������ݱ�
		
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
