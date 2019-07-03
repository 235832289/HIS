using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// 药房请领
    /// </summary>
    public class clsDcl_AskForMedicine : com.digitalwave.GUI_Base.clsDomainController_Base
    {   
        /// <summary>
        /// 获取领药部门信息
        /// </summary>
        /// <param name="m_dtDept"></param>
        /// <returns></returns>
        public long m_lngGetApplyDept(out DataTable m_dtDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetApplyDept(objPrincipal, out m_dtDept);
            return lngRes;
        }
        /// <summary>
        /// 获取出库部门信息
        /// </summary>
        /// <param name="m_dtExportDept"></param>
        /// <returns></returns>
        public long m_lngGetExportDept(out DataTable m_dtExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetExportDept(objPrincipal, out m_dtExportDept);
            return lngRes;
        }
        /// <summary>
        /// 获取药房请领主表信息
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptID"></param>
        /// <param name="m_strExpDeptID"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_strMedName"></param>
        /// <param name="m_strAskid"></param>
        /// <param name="m_dtAskInfo"></param>
        /// <returns></returns>
        public long m_lngGetAskInfo(string m_strBeginDate, string m_strEndDate, string m_strAskDeptID, string m_strExpDeptID, int m_intStatus, string m_strMedName, string m_strAskid, out DataTable m_dtAskInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskInfo(objPrincipal, m_strBeginDate, m_strEndDate,m_strAskDeptID,m_strExpDeptID,m_intStatus,m_strMedName,m_strAskid, out m_dtAskInfo);
            return lngRes;
        }
        #region  根据请领部门id获取药房某段时间内请领主表信息
        /// <summary>
        /// 根据请领部门id获取药房某段时间内请领主表信息
        /// </summary>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_strAskDeptid"></param>
        /// <param name="m_dtAskInfo"></param>
        /// <param name="m_dtOutStorage"></param>
        /// <returns></returns>
        public long m_lngGetAskInfo(string m_strBeginTime, string m_strEndTime,string m_strAskDeptid,string m_strStorageid, out DataTable m_dtAskInfo,out DataTable m_dtOutStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskInfo(objPrincipal, m_strBeginTime, m_strEndTime,m_strAskDeptid,m_strStorageid, out m_dtAskInfo, out m_dtOutStorage);
            return lngRes;
        }
        #endregion
        /// <summary>
        /// 根据主表流水号获取明细表信息
        /// </summary>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="m_dtAskDetail"></param>
        /// <returns></returns>
        public long m_lngGetAskDetailInfoByid(bool p_blnIsHospital,long m_lngSeqid, out DataTable m_dtAskDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskDetailInfoByid(objPrincipal,p_blnIsHospital, m_lngSeqid, out m_dtAskDetail);
            return lngRes;
        }
        /// <summary>
        /// 作废请领主表单据的状态
        /// </summary>
        /// <param name="lngArr"></param>
        /// <returns></returns>
        public long m_lngDeleAskInfo(long[] lngArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngDeleAskInfo(objPrincipal, lngArr);
            return lngRes;
        }
        /// <summary>
        /// 提交请领主表信息
        /// </summary>
        /// <param name="voArr"></param>
        /// <returns></returns>
        public long m_lngCommiteAskInfo(clsDS_Ask_VO[] voArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngCommiteAskInfo(objPrincipal, voArr);
            return lngRes;
        }
        /// <summary>
        /// 审核请领主表信息
        /// </summary>
        /// <param name="lngArr"></param>
        /// <param name="m_intType">状态值: 3、药库审核4、药房审核 </param>
        /// <returns></returns>
        public long m_lngExamAskInfo(long[] lngArr,int m_intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngExamAskInfo(objPrincipal, lngArr, m_intType);
            return lngRes;
        }
        /// <summary>
        /// 审核请领主表信息
        /// </summary>
        /// <param name="lngSeqid"></param>
        /// <param name="m_intType">状态值: 3、药库审核4、药房审核 </param>
        /// <param name="p_strInstoreId">入库单号 </param>
        /// <returns></returns>
        public long m_lngExamAskInfo(long lngSeqid, int m_intType,string p_strInstoreId)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngExamAskInfo(objPrincipal, lngSeqid, m_intType,p_strInstoreId);
            return lngRes;
        }
        /// <summary>
        /// 入帐请领主表单据
        /// </summary>
        /// <param name="lngArr"></param>
        /// <param name="m_intType">状态值: 5-入帐  </param>
        /// <returns></returns>
        public long m_lngInAccountAskInfo( long lngSeqid, string m_strInAccounterid, string m_strChittyid, string m_strDrugStoreid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngInAccountAskInfo(objPrincipal, lngSeqid, m_strInAccounterid, m_strChittyid, m_strDrugStoreid);
            return lngRes;
        }
        /// <summary>
        /// 退审请领主表单据的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngArr"></param>
        /// <returns></returns>
        public long m_lngUnExamAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, long[] lngArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngUnExamAskInfo(objPrincipal, lngArr);
            return lngRes;
        }
        #region 获取药房请领主表信息和相对应药库出库主表信息
        /// <summary>
        /// 获取药房请领主表信息
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptID"></param>
        /// <param name="m_strExpDeptID">出库部门</param>
        /// <param name="m_intStatus">-1:全部状态 状态 0、作废、1、新制   2、提交 3、药库审核4、药房审核</param>
        /// <param name="m_strMedName"></param>
        /// <param name="m_strAskid"></param>
        /// <param name="m_dtAskMainInfo"></param>
        /// <param name="m_dtOutStorageMainInfo"></param>
        /// <returns></returns>
        public long m_lngGetAskInfoAndOutStorageInfo(string m_strBeginDate, string m_strEndDate, string m_strAskDeptID, string m_strExpDeptID, int m_intStatus, string m_strMedName, string m_strAskid,int p_intBillType, out DataTable m_dtAskMainInfo, out DataTable m_dtOutStorageMainInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskInfoAndOutStorageInfo(objPrincipal,  m_strBeginDate,  m_strEndDate,  m_strAskDeptID,  m_strExpDeptID,  m_intStatus,  m_strMedName,  m_strAskid,p_intBillType, out  m_dtAskMainInfo, out  m_dtOutStorageMainInfo);
            return lngRes;
        }
        #endregion 

        #region 获取出库单金额记录
        /// <summary>
        /// 获取金额记录
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptid"></param>
        /// <param name="m_strExportDeptid"></param>
        /// <param name="m_dtOutstorage"></param>
        /// <returns></returns>
        public long m_lngGetAllMoney(string m_strBeginDate, string m_strEndDate, string m_strAskDeptid, string m_strExportDeptid, out DataTable m_dtOutstorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAllMoney( m_strBeginDate, m_strEndDate, m_strAskDeptid, m_strExportDeptid, out m_dtOutstorage);
            return lngRes;
        }
        #endregion 


        /// <summary>
        /// 获取金额记录
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptID"></param>
        /// <param name="m_strExpDeptID"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_strMedName"></param>
        /// <param name="m_strAskid"></param>
        /// <param name="m_dtOutStorageMainInfo"></param>
        /// <returns></returns>
        public long m_lngGetAllMoney(string m_strBeginDate, string m_strEndDate,
                             string m_strAskDeptID, string m_strExpDeptID, int m_intStatus, string m_strMedName, string m_strAskid,
                             out DataTable m_dtOutStorageMainInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAllMoney(m_strBeginDate, m_strEndDate, m_strAskDeptID, m_strExpDeptID, m_intStatus, m_strMedName, m_strAskid, out m_dtOutStorageMainInfo);
            return lngRes;
        }


        internal long m_lngGetOutBillNo(long p_lngSeqid, out string p_strOutputOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetOutBillNo(objPrincipal,p_lngSeqid, out p_strOutputOrder);
            return lngRes;
        }

        /// <summary>
        /// 获取请领单的状态。
        /// </summary>
        /// <param name="p_lngAskSeqid"></param>
        /// <param name="p_strStatus"></param>
        /// <returns></returns>
        internal long m_lngGetAskStatus(long p_lngAskSeqid, out string p_strStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskStatus(objPrincipal, p_lngAskSeqid, out p_strStatus);
            return lngRes;
        }

        /// <summary>
        /// 请领单零售金额
        /// </summary>
        /// <param name="p_intSeriesID"></param>
        /// <param name="p_dblSummoney"></param>
        /// <returns></returns>
        internal long m_lngGetAskMoney(long p_intSeriesID, out double p_dblSummoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskMoney(objPrincipal, p_intSeriesID, out p_dblSummoney);
            return lngRes;
        }

        /// <summary>
        /// 出库单零售金额
        /// </summary>
        /// <param name="p_intSeriesID"></param>
        /// <param name="p_dblSummoney"></param>
        /// <returns></returns>
        internal long m_lngGetOutMoney(long p_intSeriesID, out double p_dblSummoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetOutMoney(objPrincipal, p_intSeriesID, out p_dblSummoney);
            return lngRes;
        }

        /// <summary>
        /// 检查是否住院药房使用
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <returns></returns>
        internal long m_lngCheckIsHospital(string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngCheckIsHospital(objPrincipal, p_strDrugStoreID, out p_blnIsHospital);
            return lngRes;
        }

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：3为药房请领单</param>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(int p_intType, long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_intType, p_lngSeq, out m_intStatus);
            return lngRes;
        }
        #endregion

        #region 获取出库单报表类型
        /// <summary>
        /// 获取出库单报表类型
        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5015", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 获取子表内容(报表打印)
        /// <summary>
        /// 获取子表内容(报表打印)
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailReport(long p_lngMainSEQ, int intType, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailReport(objPrincipal, p_lngMainSEQ, intType, out p_dtbValue,"");
            return lngRes;
        }
        #endregion
    }
}
