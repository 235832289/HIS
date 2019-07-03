using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 盘点对账表
    /// </summary>
    public class clsDcl_BalanceReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {   
        #region 获取时间所属的帐务期
        /// <summary>
        /// 获取时间所属的帐务期
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmQueryDate">时间</param>
        /// <param name="p_strStorageName">帐务期</param>
        /// <returns></returns>
        internal long m_lngGetAccount(string p_strStorageID, DateTime p_dtmQueryDate, out string p_strStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));

            lngRes = objSvc.m_lngGetAccount(objPrincipal, p_strStorageID, p_dtmQueryDate, out p_strStorageName);
            return lngRes;
        }
        #endregion

        #region 获取药库盘点对账表数据
        /// <summary>
        /// 获取药库盘点对账表数据
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        internal long m_lngGetBalance(string p_strStorageID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC));

            lngRes = objSvc.m_lngGetBalance(objPrincipal, p_strStorageID, out p_dtbResult);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 取得上次结转时间
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="dtBegin"></param>
        /// <returns></returns>
        internal long m_lngGetLastBalanceTime(string p_strStorageID,out DateTime dtBegin)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC));

            lngRes = objSvc.m_lngGetLastBalanceTime(objPrincipal, p_strStorageID, out dtBegin);
            return lngRes;
        }
        
        #region 获取系统参数配置
         /// <summary>
        /// 获取系统参数配置
        /// </summary>
        /// <param name="p_strCode">配置代码</param>
        /// <param name="p_strParm">参数配置</param>
        /// <returns></returns>
        internal long m_lngGetSysParm(string p_strCode, out string p_strParm)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetSysParm(objPrincipal, p_strCode, out p_strParm);
            return lngRes;
        }
        #endregion

        #region 获取药库盘点对账表数据（分帐务期）
        /// <summary>
        /// 获取药库盘点对账表数据（分帐务期）
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        internal long m_lngGetBalanceDetail(string p_strStorageID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC));

            lngRes = objSvc.m_lngGetBalanceDetail(objPrincipal, p_strStorageID, out p_dtbResult);
            return lngRes;
        }
        #endregion


        internal long m_lngGetRoomid(out DataTable dtTemp)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC));
            lngRes = objSvc.m_lngGetRoomid(out dtTemp);
            return lngRes;
        }

        internal long m_lngGetBalanceDetailForDrugStore(string p_strStorageID, string p_strAccountID, string p_strLastAccountID,
            DateTime p_dtmStart, DateTime p_dtmEnd, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC));

            lngRes = objSvc.m_lngGetBalanceDetailForDrugStore(objPrincipal, p_strStorageID, p_strAccountID, p_strLastAccountID, p_dtmStart, p_dtmEnd, out dtbResult);
            return lngRes;
        }

        internal long m_lngGetRecipeDetail(string p_strStorageID, DateTime p_dtmStart, DateTime p_dtmEnd, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC));

            lngRes = objSvc.m_lngGetRecipeDetail(objPrincipal, p_strStorageID, p_dtmStart, p_dtmEnd, out dtbResult);
            return lngRes;
        }

        internal void m_mthGetAccountIDListForDrugStore(string p_strStorageID, out clsMS_AccountPeriodVO[] p_objAccArr)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC));

            objSvc.m_mthGetAccountIDListForDrugStore(objPrincipal, p_strStorageID, out p_objAccArr);
        }

        /// <summary>
        /// 取得单据类型
        /// </summary>
        /// <param name="p_strType"></param>
        /// <returns></returns>
        public long m_lngGetBillType(bool p_blnForDrugStore,out string p_strType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            if (p_blnForDrugStore)
                lngRes = objSvc.m_lngGetSysParaByID(objPrincipal, "8007", out p_strType);
            else
                lngRes = objSvc.m_lngGetSysParaByID(objPrincipal, "5002", out p_strType);
            return lngRes;
        }
    }
}
