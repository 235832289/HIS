using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 帐务期结转

    /// </summary>
    public class clsDcl_Account : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取总帐表内容

        /// <summary>
        /// 获取总帐表内容

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <returns></returns>
        internal long m_lngGetAccout(string p_strStorageID, string p_strAccountID, out clsMS_Account p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetAccout(objPrincipal, p_strStorageID, p_strAccountID, out p_objRecord);
            return lngRes;
        }
        #endregion

        #region 生成帐表
        /// <summary>
        /// 生成帐表
        /// </summary>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccount">帐务表</param>
        /// <param name="p_lngSEQArr">序列</param>
        /// <returns></returns>
        internal long m_lngGenarateAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out clsMS_Account p_objAccount, out long[] p_lngSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGenarateAccount(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_objAccount, out p_lngSEQArr);
            return lngRes;
        }
        #endregion

        #region 保存帐表
        /// <summary>
        /// 保存帐表
        /// </summary>
        /// <param name="p_objAccPe">帐务期结转内容</param>
        /// <param name="p_objAccount">帐表内容</param>
        /// <param name="p_lngMedSEQ">流水帐序列</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_lngMainSEQ">帐务期序列</param>
        /// <param name="p_lngSubSEQ">帐表序列</param>
        /// <returns></returns>
        internal long m_lngSaveAccount(clsMS_AccountPeriodVO p_objAccPe, clsMS_Account p_objAccount, long[] p_lngMedSEQ,string p_strEmpID, out string p_strAccountID, out long p_lngMainSEQ, out long p_lngSubSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngSaveAccount(objPrincipal, p_objAccPe, p_objAccount, p_lngMedSEQ,p_strEmpID,out p_strAccountID, out p_lngMainSEQ, out p_lngSubSEQ);
            return lngRes;
        }
        #endregion

        #region 检查是否有未确定入帐的记录
        /// <summary>
        /// 检查是否有未确定入帐的记录
        /// </summary>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_intSeriesIDArr">序列号</param>
        /// <returns></returns>
        internal long m_lngCheckHasUnConfirmAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out string[] p_strChittyIDArr, out Int64[] p_intSeriesIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngCheckHasUnConfirmAccount(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_strChittyIDArr, out p_intSeriesIDArr);
            return lngRes;
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intSeriesIDArr">序列号</param>
        /// <returns></returns>
        internal long m_lngSetAccount(string p_strEmpID, DateTime p_dtmAccountDate, string[] p_strChittyIDArr, string p_strStorageID,Int64[] p_intSeriesIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngSetAccount(objPrincipal, p_strEmpID, p_dtmAccountDate, p_strChittyIDArr, p_strStorageID, p_intSeriesIDArr);
            return lngRes;
        }
        #endregion

        #region 检查开帐务期内是否存在未审核的记录
        /// <summary>
        /// 检查开帐务期内是否存在未审核的记录
        /// </summary>
        /// <param name="p_dtmBeginDate">帐务期开始时间</param>
        /// <param name="p_dtmEndDate">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strHintText">存在未审核记录的单据名称(类型)</param>
        /// <returns></returns>
        internal long m_lngCheckHasUnCommitRecord(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out string p_strHintText)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngCheckHasUnCommitRecord(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, out p_strHintText);
            return lngRes;
        }
        #endregion

        #region 获取结帐间隔时间
        /// <summary>
        ///获取结帐间隔时间
        /// </summary>
        /// <param name="p_intAdjustDrugstore">获取结帐间隔时间</param>
        /// <returns></returns>
        internal long m_lngGetAccountDate(out int p_intAccountDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5017", out p_intAccountDate);
            return lngRes;
        }
        #endregion
    }
}
