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
        #region 根据条件组合查询工作量报表数据 童华 2004.06.22
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

        //		#region 查询标本的报告单信息 童华 2004.05.14
        //		public long m_lngGetAllReportInfo(string strFromDat,string strToDat,string strDeviceID,string strSampleFrom,string strSampleTo,string strPatientType,string strDept,string strPatientCardID,string strPatientName,out com.digitalwave.iCare.ValueObject.clsBatchReport_VO[] objBatchReportList)
        //		{
        //			long lngRes = 0;
        //			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objCheckResultSvc = (com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
        //			lngRes = objCheckResultSvc.m_lngGetAllReportInfo(objPrincipal,strFromDat,strToDat,strDeviceID,strSampleFrom,strSampleTo,strPatientType,strDept,strPatientCardID,strPatientName,out objBatchReportList);
        ////			objCheckResultSvc.Dispose();
        //			return lngRes;
        //		}
        //		#endregion

        #region 查询所有的科室类别信息 童华 2004.05.13
        public long m_lngGetDeptInfo(out com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDepartmentVOList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.DepartmentSvc.clsDeptSvc objDeptSvc = (com.digitalwave.iCare.middletier.DepartmentSvc.clsDeptSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DepartmentSvc.clsDeptSvc));
            lngRes = objDeptSvc.m_lngGetDeptInfo(objPrincipal, out objDepartmentVOList);
            //			objDeptSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查询所有的病人类型信息 童华 2004.05.13
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

        #region 查询某一检验单组或自定义组下的所有基本组信息 童华 2004.05.12
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

        #region 根据组合类别查询相关的组合信息 童华 2004.05.11
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

        #region 判断t_opr_lis_application_detail的某一检验组下的所有样本的标志位状态，并且设置t_opr_lis_application_detail的标志位 童华 2004.04.26
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSampleID">当前样本的ID号</param>
        /// <param name="strApplFormNo">当前样本所属的申请单号</param>
        /// <param name="strApplID">当前样本所属的申请单ID号</param>
        /// <param name="strSampleStatus">当前样本的状态</param>
        /// <param name="strSetApplDetailStatus">设置t_opr_lis_application_detail的状态</param>
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

        #region 设置t_opr_lis_application_detail的标志位 童华 2004.04.26
        public long m_lngSetStatusToConfirmByApplicationIDAndGroupID(string strGroupID, string strApplID, string strSetApplDetailStatus)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objApplSvc.m_lngSetStatusToConfirmByApplicationIDAndGroupID(p_objPrincipal, strGroupID, strApplID, strSetApplDetailStatus);
            return lngRes;
        }
        #endregion

        #region 设置标本的状态 童华 2004.04.26
        /// <summary>
        /// 设置标本的状态
        /// </summary>
        /// <param name="strSampleID">标本的ID号</param>
        /// <param name="strSampleStatus">标本设置后的状态值</param>
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

        #region 查询所有未采集的申请单信息 童华 2004.04.26
        public long m_lngGetAllNoCollectedByApplDat(string strFromDat, string strToDat, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngGetAllNoCollectSampleByApplDat(p_objPrincipal, strFromDat, strToDat, out dtbApplInfo);
            return lngRes;
        }
        #endregion

        #region 查询所有已采集的申请单信息 童华 2004.04.26
        public long m_lngGetAllCollectedByApplDat(string strFromDat, string strToDat, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngGetAllCollectedApplInfoByApplDat(p_objPrincipal, strFromDat, strToDat, out dtbApplInfo);
            return lngRes;
        }
        #endregion

        #region 查询所有申请单信息 童华 2004.04.26
        public long m_lngGetAllApplInfoByApplDat(string strFromDat, string strToDat, out DataTable dtbApplInfo)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objApplSvc.m_lngGetAllSendApplInfoByApplDat(p_objPrincipal, strFromDat, strToDat, out dtbApplInfo);
            return lngRes;
        }
        #endregion

        #region 根据检验申请表号和检验组（第一层）查询已经采集的各标本数量 童华 2004.04.26
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

        #region 根据GroupID查询该检验组需要的样本信息 童华 2004.04.26
        public long m_lngGetSampleCountInfoByGroupID(string strGroupID, out DataTable dtbGroupSampleCount)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
            lngRes = objCheckGroupSvc.m_lngGetSampleTypeInfo(p_objPrincipal, strGroupID, out dtbGroupSampleCount);
            return lngRes;
        }
        #endregion

        #region 根据诊疗卡号查询申请单信息 童华 2004.04.26
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
