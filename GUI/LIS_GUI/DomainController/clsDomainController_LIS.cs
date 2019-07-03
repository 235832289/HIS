using System;
using System.Data;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.middletier.LIS; //LIS_SVC.dll
using com.digitalwave.iCare.middletier.PatientSvc;//PatientSvc.dll
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// Summary description for clsDomainController_LIS.
    /// </summary>
    public class clsDomainController_LIS : clsDomainController_Base
    {
        public clsDomainController_LIS()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region ����������ϲ�ѯ�������������� ͯ�� 2004.06.22
        public long m_lngGetWorkloadReportByCondition(string p_strFromDat, string p_strToDat, string p_strCheckItemID, string p_strApplEmpID,
            string p_strApplDeptID, string p_strPatientTypeID, string p_strCheckEmpID, string p_strCheckCategoryID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsQueryReportSvc));
            lngRes = objSvc.m_lngGetWorkloadReportByCondition(objPrincipal, p_strFromDat, p_strToDat, p_strCheckItemID, p_strApplEmpID, p_strApplDeptID,
                p_strCheckEmpID, p_strPatientTypeID, p_strCheckCategoryID, out dtbResult);
            //			objSvc.Dispose();
            return lngRes;
        }
        #endregion

        //		#region ��ѯ�걾�ı��浥��Ϣ ͯ�� 2004.05.14
        //		public long m_lngGetAllReportInfo(string strFromDat,string strToDat,string strDeviceID,string strSampleFrom,string strSampleTo,string strPatientType,string strDept,string strPatientCardID,string strPatientName,out com.digitalwave.iCare.ValueObject.clsBatchReport_VO[] objBatchReportList)
        //		{
        //			long lngRes = 0;
        //			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objCheckResultSvc = (com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
        //			lngRes = objCheckResultSvc.m_lngGetAllReportInfo(objPrincipal,strFromDat,strToDat,strDeviceID,strSampleFrom,strSampleTo,strPatientType,strDept,strPatientCardID,strPatientName,out objBatchReportList);
        ////			objCheckResultSvc.Dispose();
        //			return lngRes;
        //		}
        //		#endregion

        #region ��ѯ���еĿ��������Ϣ ͯ�� 2004.05.13
        public long m_lngGetDeptInfo(out com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDepartmentVOList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.DepartmentSvc.clsDeptSvc objDeptSvc = (com.digitalwave.iCare.middletier.DepartmentSvc.clsDeptSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DepartmentSvc.clsDeptSvc));
            lngRes = objDeptSvc.m_lngGetDeptInfo(objPrincipal, out objDepartmentVOList);
            //			objDeptSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ���еĲ���������Ϣ ͯ�� 2004.05.13
        public long m_lngGetPatientType(out com.digitalwave.iCare.ValueObject.clsDict_VO[] objPatientTypeList)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal objPrincipal = null;
            com.digitalwave.iCare.middletier.PatientSvc.clsPatientSvc objPatientSvc = (com.digitalwave.iCare.middletier.PatientSvc.clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.PatientSvc.clsPatientSvc));
            lngRes = objPatientSvc.m_lngGetPatientType(objPrincipal, out objPatientTypeList);
            //			objPatientSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯĳһ���鵥����Զ������µ����л�������Ϣ ͯ�� 2004.05.12
        public long m_lngQryAllBseCheckGroupBYGroupID(string strCheckGroupID, out com.digitalwave.iCare.ValueObject.clsCheckGroup_VO[] objCheckGroupVOList)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
            lngRes = objCheckGroupSvc.m_lngQryBseGroup(p_objPrincipal, strCheckGroupID, out objCheckGroupVOList);
            objCheckGroupSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region �����������ѯ��ص������Ϣ ͯ�� 2004.05.11
        public long m_lngGetCheckGroupByCheckGroupType(string strHasSubGroup, out com.digitalwave.iCare.ValueObject.clsCheckGroup_VO[] objCheckGroup)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
            lngRes = objCheckGroupSvc.m_lngGetCheckGroupByCheckGroupType(p_objPrincipal, strHasSubGroup, out objCheckGroup);
            objCheckGroupSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region �ж�t_opr_lis_application_detail��ĳһ�������µ����������ı�־λ״̬����������t_opr_lis_application_detail�ı�־λ ͯ�� 2004.04.26
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSampleID">��ǰ������ID��</param>
        /// <param name="strApplFormNo">��ǰ�������������뵥��</param>
        /// <param name="strApplID">��ǰ�������������뵥ID��</param>
        /// <param name="strSampleStatus">��ǰ������״̬</param>
        /// <param name="strSetApplDetailStatus">����t_opr_lis_application_detail��״̬</param>
        /// <returns></returns>
        public long m_lngSetApplDetailSatausBySampleSataus(string strSampleID, string strApplFormNo, string strApplID, string strSampleStatus, string strSetApplDetailStatus)
        {
            long lngRes = 0;
            DataTable dtbGroupSample = null;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc = (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
            lngRes = objSampleSvc.m_lngGetSampleStatusByGroup(p_objPrincipal, strSampleID, strApplFormNo, out dtbGroupSample);
            int count = dtbGroupSample.Rows.Count;
            if (count > 0)
            {
                bool bolRecepted = true;
                for (int i = 0; i < count; i++)
                {
                    string strStatus = dtbGroupSample.Rows[i]["status_int"].ToString().Trim();
                    if (strStatus != strSampleStatus)
                    {
                        bolRecepted = false;
                    }
                }
                if (bolRecepted)
                {
                    this.m_lngSetStatusToConfirmByApplicationIDAndGroupID(dtbGroupSample.Rows[0]["groupid_chr"].ToString().Trim(), strApplID, strSetApplDetailStatus);
                }
            }
            return lngRes;
        }
        #endregion

        #region ����t_opr_lis_application_detail�ı�־λ ͯ�� 2004.04.26
        public long m_lngSetStatusToConfirmByApplicationIDAndGroupID(string strGroupID, string strApplID, string strSetApplDetailStatus)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objApplSvc.m_lngSetStatusToConfirmByApplicationIDAndGroupID(p_objPrincipal, strGroupID, strApplID, strSetApplDetailStatus);
            return lngRes;
        }
        #endregion

        #region ���ñ걾��״̬ ͯ�� 2004.04.26
        /// <summary>
        /// ���ñ걾��״̬
        /// </summary>
        /// <param name="strSampleID">�걾��ID��</param>
        /// <param name="strSampleStatus">�걾���ú��״ֵ̬</param>
        /// <returns></returns>
        public long m_lngSetSampleStatus(string strSampleID, int intSampleStatus)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSampleSvc = (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
            lngRes = objSampleSvc.m_lngSetSampleStatusBySampleId(p_objPrincipal, strSampleID, intSampleStatus);
            return lngRes;
        }
        #endregion

        #region ��ѯ����δ�ɼ������뵥��Ϣ ͯ�� 2004.04.26
        public long m_lngGetAllNoCollectedByApplDat(string strFromDat, string strToDat, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngGetAllNoCollectSampleByApplDat(p_objPrincipal, strFromDat, strToDat, out dtbApplInfo);
            return lngRes;
        }
        #endregion

        #region ��ѯ�����Ѳɼ������뵥��Ϣ ͯ�� 2004.04.26
        public long m_lngGetAllCollectedByApplDat(string strFromDat, string strToDat, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngGetAllCollectedApplInfoByApplDat(p_objPrincipal, strFromDat, strToDat, out dtbApplInfo);
            return lngRes;
        }
        #endregion

        #region ��ѯ�������뵥��Ϣ ͯ�� 2004.04.26
        public long m_lngGetAllApplInfoByApplDat(string strFromDat, string strToDat, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngGetAllSendApplInfoByApplDat(p_objPrincipal, strFromDat, strToDat, out dtbApplInfo);
            return lngRes;
        }
        #endregion

        #region ���ݼ��������źͼ����飨��һ�㣩��ѯ�Ѿ��ɼ��ĸ��걾���� ͯ�� 2004.04.26
        public long m_lngGetGroupSampleCountByApplFormNoAndGorupID(string strApplFormNo, string strGroupID, out DataTable dtbGroupSampleCount)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            dtbGroupSampleCount = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc = (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
            lngRes = objSampleSvc.m_lngGetAllSampleCountByApplFormNoAndGroupID(p_objPrincipal, strApplFormNo, strGroupID, out dtbGroupSampleCount);
            //			objSampleSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ����GroupID��ѯ�ü�������Ҫ��������Ϣ ͯ�� 2004.04.26
        public long m_lngGetSampleCountInfoByGroupID(string strGroupID, out DataTable dtbGroupSampleCount)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
            lngRes = objCheckGroupSvc.m_lngGetSampleTypeInfo(p_objPrincipal, strGroupID, out dtbGroupSampleCount);
            return lngRes;
        }
        #endregion

        #region �������ƿ��Ų�ѯ���뵥��Ϣ ͯ�� 2004.04.26
        public long m_lngGetApplInfoByPatientCardID(string strPatientCardID, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngApplInfoByPatientCardID(p_objPrincipal, strPatientCardID, out dtbApplInfo);
            return lngRes;
        }
        #endregion

    }
}
