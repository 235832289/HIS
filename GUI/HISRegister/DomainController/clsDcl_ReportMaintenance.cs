using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_ReportMaintenance 的摘要说明。
	/// </summary>
	public class clsDcl_ReportMaintenance:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_ReportMaintenance()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public long m_mthGetReportInfo(string str,out clsReportMain_VO[] objResult)
		{
			long lngRes=0;
			objResult=null;
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthGetReportInfo(objPrincipal,str,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		public long m_mthGetGroupByID(string str,out clsReportDetail_VO[] objResult)
		{
			long lngRes=0;
			objResult=null;
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthGetGroupByID(objPrincipal,str,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		public long m_mthGetGroupDetailByID(string strReportID,string strGroupID,string strflag,out clsGroupDetail_VO[] objResult)
		{
			long lngRes=0;
			objResult=null;
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthGetGroupDetailByID(objPrincipal,strReportID,strGroupID,strflag,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#region 保存报表信息
		public long m_mthAddNewReportInfo(clsReportMain_VO obj_VO)
		{
			long lngRes=0;
			
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthAddNewReportInfo(objPrincipal,obj_VO);
			objSvc.Dispose();
			return lngRes;
		}
		public long m_mthUpdateReportInfo(string strID,clsReportMain_VO obj_VO,bool flag)
		{
			long lngRes=0;
		
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthUpdateReportInfo(objPrincipal,strID,obj_VO,flag);
			objSvc.Dispose();
			return lngRes;
		}
		public long m_mthDeleteReportByID(string strID)
		{
			long lngRes=0;
		
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthDeleteReportByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 
		public long m_mthAddNewReportInfo2(clsReportDetail_VO obj_VO)
		{
			long lngRes=0;
			
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthAddNewReportInfo2(objPrincipal,obj_VO);
			objSvc.Dispose();
			return lngRes;
		}
		public long m_mthUpdateReportInfo2(string strID,clsReportDetail_VO obj_VO,bool flag)
		{
			long lngRes=0;
		
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthUpdateReportInfo2(objPrincipal,strID,obj_VO,flag);
			objSvc.Dispose();
			return lngRes;
		}
		public long m_mthDeleteReportByID2(string strID,string strReportID)
		{
			long lngRes=0;
		
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthDeleteReportByID2(objPrincipal,strID,strReportID);
			objSvc.Dispose();
			return lngRes;
		}

		public long m_mthSaveGroupDetail(clsGroupDetail_VO[] obj_VO)
		{
			long lngRes=0;
		
			com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc));
			lngRes = objSvc.m_mthSaveGroupDetail(objPrincipal,obj_VO);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 查找收费特别类别
		public long m_mthGetCat(string strFlag,out clsChargeItemEXType_VO[] objResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngFindChargeItemEXTypeListByFlag(objPrincipal,strFlag,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
	}
}
