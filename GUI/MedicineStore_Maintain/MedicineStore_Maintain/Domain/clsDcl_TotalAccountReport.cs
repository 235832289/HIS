using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药库总帐
    /// </summary>
    public class clsDcl_TotalAccountReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取帐务期表内容
        /// <summary>
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccountData">帐务期表内容</param>
        /// <returns></returns>
        internal long m_lngGetAccountPeriod(string p_strStorageID, out clsMS_AccountPeriodVO[] p_objAccountData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetAccountPeriod(objPrincipal, p_strStorageID, out p_objAccountData);
            return lngRes;
        }
        #endregion

        #region 获取总帐报表(分类型)
        /// <summary>
        /// 获取总帐报表(分类型)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_lngEndFirstSEQ">本帐务期期末第一条SEQ</param>
        /// <param name="p_strAccountID">本帐务期ID</param>
        /// <param name="p_strLastAccountID">上一期帐务期ID(如IsNullOrEmpty则表示本次为第一期)</param>
        /// <param name="p_objAccount">总帐报表内容</param>
        /// <returns></returns>
        internal long m_lngGetTotalAccount_Divide(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, long p_lngEndFirstSEQ,string p_strAccountID,string p_strLastAccountID, out clsMS_TotalAccountVO[] p_objAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetTotalAccount_Divide(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_lngEndFirstSEQ, p_strAccountID, p_strLastAccountID, out p_objAccount);
            return lngRes;
        }
        #endregion

        #region 获取总帐报表(分类型)（未结帐）
        /// <summary>
        /// 获取总帐报表(分类型)（未结帐）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_lngEndFirstSEQ">本帐务期期末第一条SEQ</param>
        /// <param name="p_strAccountID">本帐务期ID</param>
        /// <param name="p_strLastAccountID">上一期帐务期ID(如IsNullOrEmpty则表示本次为第一期)</param>
        /// <param name="p_objAccount">总帐报表内容</param>
        /// <returns></returns>
        internal long m_lngGetTotalAccount_DivideNoAcc(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, long p_lngEndFirstSEQ, string p_strAccountID, string p_strLastAccountID, out clsMS_TotalAccountVO[] p_objAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetTotalAccount_DivideNoAcc(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_lngEndFirstSEQ, p_strAccountID, p_strLastAccountID, out p_objAccount);
            return lngRes;
        }
        #endregion

        #region 获取选定帐务期期末结转的第一条SEQ
        /// <summary>
        /// 获取选定帐务期期末结转的第一条SEQ
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngSEQ">返回所需的SEQ</param>
        /// <returns></returns>
        internal long m_lngGetEndAccountFirstSEQ(string p_strAccountID, string p_strStorageID, out long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetEndAccountFirstSEQ(objPrincipal, p_strAccountID, p_strStorageID,  out p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 获取仓库名称
        /// <summary>
        /// 获取仓库名称
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strStorageName"></param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStorageID,out string p_strStorageName)
        {
                    long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal,p_strStorageID, out p_strStorageName);

            return lngRes;
        }
        #endregion

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

    }
}
