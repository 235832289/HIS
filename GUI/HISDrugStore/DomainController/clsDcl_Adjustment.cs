using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药品调价
    /// </summary>
    public class clsDcl_Adjustment : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药品调价主表信息
        /// <summary>
        /// 获取药品调价主表信息
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmSearchBegin">搜索开始时间</param>
        /// <param name="p_dtmSearchEnd">搜索结束时间</param>
        /// <param name="p_dtbValue">药品调价主表信息</param>
        /// <returns></returns>
        internal long m_lngGetAdjustmentMain(string p_strStorageID, DateTime p_dtmSearchBegin, DateTime p_dtmSearchEnd, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngGetAdjustmentMain(objPrincipal, p_strStorageID, p_dtmSearchBegin, p_dtmSearchEnd, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取药品调价主表信息
        /// <summary>
        /// 获取药品调价主表信息
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmSearchBegin">搜索开始时间</param>
        /// <param name="p_dtmSearchEnd">搜索结束时间</param>
        /// <param name="p_dtbValue">药品调价主表信息</param>
        /// <returns></returns>
        internal long m_lngGetAdjustmentMain(string p_strStorageID, string p_strMedicineID, DateTime p_dtmSearchBegin, DateTime p_dtmSearchEnd, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngGetAdjustmentMain(objPrincipal, p_strStorageID, p_strMedicineID, p_dtmSearchBegin, p_dtmSearchEnd, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取药品调价明细
        /// <summary>
        /// 获取药品调价明细
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_dtbDetail">药品调价明细记录</param>
        /// <returns></returns>
        internal long m_lngGetAdjustmentDetail(long p_lngMainSEQ, out DataTable p_dtbDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngGetAdjustmentDetail(objPrincipal, p_lngMainSEQ, out p_dtbDetail);
            return lngRes;
        }
        #endregion

        #region 删除整条药品调价记录
        /// <summary>
        /// 删除整条药品调价记录
        /// </summary>
        /// <param name="p_lngSEQ">药品调价主表索引</param>
        /// <returns></returns>
        internal long m_lngDeleteAdjustment(long[] p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngDeleteAdjustment(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 修改药品调价记录
        /// <summary>
        /// 修改药品调价记录
        /// </summary>
        /// <param name="p_objAdjustMedicineArrWithLotNO">药品调价记录</param>
        /// <returns></returns>
        internal long m_lngModifyStoragePrice(clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArrWithLotNO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngModifyStoragePrice(objPrincipal,p_objAdjustMedicineArrWithLotNO);
            return lngRes;
        }
        #endregion

        #region 审核药品调价记录
        /// <summary>
        /// 审核药品调价记录
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <param name="p_objAdjustMedicineArrWithLotNO">药品调价记录</param>
        /// <param name="p_blnIsImmAccount">是否保存即审核</param>
        /// <param name="p_blnIsChangeBase">是否同时调整字典表零售价</param>
        /// <returns></returns>
        internal long m_lngCommitAdjustPrice(long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicine, bool p_blnIsImmAccount, bool p_blnIsChangeBase)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngCommitAdjustPrice(objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate, p_objAdjustMedicine, p_blnIsImmAccount, p_blnIsChangeBase);
            return lngRes;
        }
        #endregion

        #region 退审药品调价记录
        /// <summary>
        /// 退审药品调价记录        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_objAdjustMedicineArrWithLotNO">药品调价记录</param>
        /// <param name="p_strAdjustIDArr">调价单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strUserID">退审人ID</param>
        /// <param name="p_dtmUnCommitDate">退审时间</param>
        /// <param name="p_blnIsChangeBase">是否修改字典表</param>
        /// <returns></returns>
        internal long m_lngUnCommitAdjustPrice(long[] p_lngMainSEQ, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArrWithLotNO, string[] p_strAdjustIDArr, string p_strStorageID, string p_strUserID, DateTime p_dtmUnCommitDate, bool p_blnIsChangeBase)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngUnCommitAdjustPrice(objPrincipal, p_lngMainSEQ, p_objAdjustMedicineArrWithLotNO, p_strAdjustIDArr, p_strStorageID, p_strUserID, p_dtmUnCommitDate, p_blnIsChangeBase);
            return lngRes;
        }
        #endregion

        #region 获取金额
        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID </param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtbMoney">金额 </param>
        /// <returns></returns>
        internal long m_lngGetAllMoney(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, string p_strMedicineID, out DataTable p_dtbMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngGetAllMoney(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, p_strMedicineID, out p_dtbMoney);
            return lngRes;
        }

        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID </param>
        /// <param name="p_dtbMoney">金额 </param>
        /// <returns></returns>
        internal long m_lngGetAllMoney(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out DataTable p_dtbMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngGetAllMoney(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_dtbMoney);
            return lngRes;
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strChittyIDArr">入库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与入库单据号一一对应)</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        internal long m_lngInAccount(string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAdjustmentSVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_strChittyIDArr, p_lngMainSEQ, p_strStorageID, p_strEmpID, p_dtmAccountDate);
            return lngRes;
        }
        #endregion

        #region 获取同一药品是否分批号调价设置

        /// <summary>
        /// 获取同一药品是否分批号调价设置
        /// </summary>
        /// <param name="p_intDiffLotNO">同一药品是否分批号调价设置</param>
        /// <returns></returns>
        internal long m_lngGetIsDiffLotNO(out int p_intDiffLotNO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5009", out p_intDiffLotNO);
            return lngRes;
        }
        #endregion

        #region 获取调价是否同时调整基本表价格


        /// <summary>
        /// 获取调价是否同时调整基本表价格
        /// </summary>
        /// <param name="p_intDiffLotNO">调价是否同时调整基本表价格</param>
        /// <returns></returns>
        internal long m_lngGetIsChangeBase(out int p_intDiffLotNO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5010", out p_intDiffLotNO);
            return lngRes;
        }
        #endregion
    }
}
