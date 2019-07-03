using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.gui.LIS;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_ShowReports ��ժҪ˵����
	/// </summary>
	public class clsDcl_ShowReports:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_ShowReports()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ���ؽڵ�
		public long m_mthLoadNodes(string strPatientID,out clsReports_VO[] objArr)
		{
			objArr=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthLoadNodes(objPrincipal,strPatientID,out objArr);
			objSvc.Dispose();
			return  lngRes;
			
		}
		#endregion
		#region ��ȡ�ĵ�ͼ��Ϣ����ӡ
		public long m_mthGetCARDIOGRAMInfo(string ID,out clsRIS_CardiogramReport_VO m_objItem)
		{
		m_objItem=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetCARDIOGRAMInfo(objPrincipal,ID,out m_objItem);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡ��̬�ĵ�ͼ��Ϣ
		public long m_mthGetDCARDIOGRAMInfo(string ID,out clsRIS_DCardiogramReport_VO m_objItem)
		{
			m_objItem=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetDCARDIOGRAMInfo(objPrincipal,ID,out m_objItem);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡTCD��Ϣ
		public long m_mthGetTCDInfo(string ID,out clsRIS_TCD_REPORT_VO m_objItem)
		{
			m_objItem=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetTCDInfo(objPrincipal,ID,out m_objItem);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡEEG��Ϣ
		public long m_mthGetEEGInfo(string ID,out clsRIS_EEG_REPORT_VO m_objItem)
		{
			m_objItem=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetEEGInfo(objPrincipal,ID,out m_objItem);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡPacs��Ϣ
		public long m_mthGetPacsInfo(string ID,out clsImageReportPrintValue m_objItem)
		{
			m_objItem=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
						long lngRes= objSvc.m_mthGetPacsInfo(objPrincipal,ID,out m_objItem);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ����report_group_id��application_id_chr��ѯ���浥�����Ϣ ���� 2004.06.04
		/// <summary>
		/// ����report_group_id��application_id_chr��ѯ���浥�����Ϣ
		/// </summary>
		/// <param name="p_strReportGroupID">������ID</param>
		/// <param name="p_strApplID">���뵥ID</param>
		/// <param name="p_blnConfirmed">�Ƿ����</param>
		/// <param name="p_dtbReportInfo">���ر��浥�����Ϣ</param>
		/// <returns></returns>
		public long m_lngGetReportPrintInfo(string p_strReportGroupID,string p_strApplID,bool p_blnConfirmed,out clsPrintValuePara p_objPrintContent)
		{
			p_objPrintContent = null;
			long lngRes = 0;
			DataTable dtbReportInfo = null;
			DataTable dtbCheckResult = null;
			com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetReportInfoByReportGroupIDAndApplicationID(objPrincipal,p_strReportGroupID,p_strApplID,p_blnConfirmed,out dtbReportInfo);
			if(lngRes >0)
			{
				lngRes = 0;
				lngRes = objSvc.m_lngGetCheckResultByReportGroupIDAndApplicationID(objPrincipal,p_strApplID,p_strReportGroupID,p_blnConfirmed,out dtbCheckResult);
			}
			if(lngRes >0)
			{
				p_objPrintContent = new clsPrintValuePara();
				p_objPrintContent.m_dtbBaseInfo = dtbReportInfo;
				p_objPrintContent.m_dtbResult = dtbCheckResult;
			}
						objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ���Ҳ�����Ϣ
		public long m_mthFindPatientInfo(int intType,string strID,out DataTable dt)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthFindPatientInfo(objPrincipal,intType,strID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ����סԺ�Ų��Ҳ���ID
		public string m_mthFindPatientIDByInHospitalNo(string strInHospitalNo)
		{
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			string  lngRes= objSvc.m_mthFindPatientIDByInHospitalNo(objPrincipal,strInHospitalNo);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡ������Ϣ
		public long m_mthGetCaseHistoryInfo(string ID,out DataTable dt)
		{
			dt =null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetCaseHistoryInfo(ID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡ������Ϣ2
		public long m_mthGetCaseHistoryInfo3(string ID,out DataTable dt)
		{
			dt =null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetCaseHistoryInfo3(ID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡ������Ϣ2
		public long m_mthGetCaseHistoryInfo2(string ID,out DataTable dt)
		{
			dt =null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetCaseHistoryInfo2(ID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ��ȡ������Ϣ
		public long m_mthGetRecipeInfo(string ID,out DataTable dt)
		{
			dt =null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetRecipeInfo(ID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion
		#region ���ݲ�����ȡ�ô�����Ϣ
		public long m_mthGetRecipeInfoByCaseHistoryID(string strCaseHistoryID,out DataTable dt)
		{
			dt =null;
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetRecipeInfoByCaseHistoryID(strCaseHistoryID,out dt);
			objSvc.Dispose();
			return  lngRes;
		}
		#endregion

        #region m_mthGetRecipeGroup
        /// <summary>
        /// m_mthGetRecipeGroup
        /// </summary>
        /// <param name="strRecipeIndex"></param>
        /// <param name="IDArr"></param>
        /// <returns></returns>
        public long m_mthGetRecipeGroup(string strRecipeIndex,out string[] IDArr)
		{
			com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
			long lngRes= objSvc.m_mthGetRecipeGroup(strRecipeIndex,out IDArr);
			objSvc.Dispose();
			return  lngRes;
        }
        #endregion

        #region ����סԺ�Ż�ȡ����ID
        /// <summary>
        /// ����סԺ�Ż�ȡ����ID
        /// </summary>
        /// <param name="p_strInpatientID"></param>
        /// <param name="strPatientName"></param>
        /// <returns></returns>
        public string m_strGetPatientIDByInNo(string p_strInpatientID, out string strPatientName)
        {
            string strPatID = string.Empty;
            com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
            long lngRes = objSvc.m_lngGetPatientIDByInNo(p_strInpatientID, out strPatID, out strPatientName);
            objSvc.Dispose();
            return strPatID;
        }
        #endregion

        #region ��ȡ��PACS��ͼ
        /// <summary>
        /// ��ȡ��PACS��ͼ
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public DataTable GetNewPacsView(string cardNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
            DataTable dt = objSvc.GetNewPacsView(cardNo);
            objSvc.Dispose();
            return dt;
        }
        #endregion
        
        #region ��ȡ�²������뵥��
        /// <summary>
        /// ��ȡ�²������뵥��
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string GetNewBLAppId(string cardNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
            string appId = objSvc.GetNewBLAppId(cardNo);
            objSvc.Dispose();
            return appId;
        }
        #endregion

        #region ��ȡ�²�����ͼ
        /// <summary>
        /// ��ȡ�²�����ͼ
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public DataTable GetNewBLView(string appId)
        {
            com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsShowReportsSvc));
            DataTable dt = objSvc.GetNewBLView(appId);
            objSvc.Dispose();
            return dt;
        }
        #endregion

    }
}
