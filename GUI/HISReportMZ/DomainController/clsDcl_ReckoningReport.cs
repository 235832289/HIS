using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsDcl_ReckoningReport 的摘要说明。
	/// </summary>
	public class clsDcl_ReckoningReport:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_ReckoningReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 报表数据  张国良  2005-1-5
		public long m_lngFindByDateReport(int p_intSelectedIndex,string p_strName,string p_strFind,out System.Data.DataTable p_tabReport, out System.Data.DataTable p_tabReportdetial)
		{
            com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport));
			long lngRes = objSvc.m_lngFindByDateReport(objPrincipal,p_intSelectedIndex,p_strName,p_strFind,out p_tabReport,out p_tabReportdetial);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 收费处月结报表数据  张国良  2005-1-5
		public long m_lngChargeMnothReport(string p_strFind,string p_strFindLast,out System.Data.DataTable p_tabReport)
		{
            com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport));
			long lngRes = objSvc.m_lngChargeMnothReport(objPrincipal,p_strFind,p_strFindLast,out p_tabReport);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 打印报表  张国良  2004-12-28
		public long m_lngUpBALANCEFLAG(string p_strNameId,string p_strFindDate)
		{
            com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport));
			long lngRes = objSvc.m_lngUpBALANCEFLAG(objPrincipal,p_strNameId,p_strFindDate);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 医保报表  张国良  2005-1-5
		public long m_lngMeditionProtectReport(string p_strFindDate,string p_strFindDateLast,string type,out System.Data.DataTable p_tabReport)
		{
            com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport));
			long lngRes = objSvc.m_lngMeditionProtectReport(objPrincipal,p_strFindDate,p_strFindDateLast,type,out p_tabReport);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 医保报表  张国良  2004-12-31
		public long m_lngPublicPayReport(int p_intFindType ,string p_strPatienName,string p_strFindDate,string p_strToDate,out System.Data.DataTable p_tabReport)
		{
            com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReckoningReport));
			long lngRes = objSvc.m_lngPublicPayReport(objPrincipal,p_intFindType,p_strPatienName,p_strFindDate,p_strToDate,out p_tabReport);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 查找病人信息
		public long m_mthFindPatientInfo(int intType,string strID,out DataTable dt)
		{
			dt=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsShowReportsSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsShowReportsSvc));
			long lngRes= objSvc.m_mthFindPatientInfo(objPrincipal,intType,strID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
	}
}
