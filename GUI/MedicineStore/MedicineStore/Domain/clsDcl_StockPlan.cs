using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsDcl_StockPlan : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取当前员工是否有药库管理角色
        /// <summary>
        /// 获取当前员工是否有药库管理角色
        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有药库管理角色</param>
        /// <returns></returns>
        internal long m_lngCheckEmpHasRole(string p_strEmpID, out bool p_blnHasRole)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngCheckEmpHasRole(objPrincipal, p_strEmpID, "药库管理", out p_blnHasRole);
            return lngRes;
        }
        #endregion

        #region 获取仓库名
        /// <summary>
        /// 获取仓库名
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名</param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStoreRoomID, out p_strStoreRoomName);
            return lngRes;
        }
        #endregion


        #region 删除指定主表信息
        /// <summary>
        /// 删除指定主表信息
        /// </summary>
        /// <param name="p_lngSeriesID">主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteMainStockPlan(long p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngDeleteMainStockPlan(objPrincipal, p_lngSeriesID);
            return lngRes;
        }
        /// <summary>
        /// 删除指定主表信息
        /// </summary>
        /// <param name="p_lngSeriesID">主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteMainStockPlan(long[] p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngDeleteMainStockPlan(objPrincipal, p_lngSeriesID);
            return lngRes;
        }
        #endregion

        #region 获取明细表内容
        /// <summary>
        /// 获取明细表内容
        /// </summary>
        /// <param name="p_lngSeries2ID">主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal long m_lngGetStockPlanDetail(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngGetStockPlanDetail(objPrincipal, p_lngSeries2ID, out p_dtbValue);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 审核申请单
        /// </summary>
        /// <param name="lngSEQ">主表序列</param>
        /// <param name="m_strExamer">审核人</param>
        /// <param name="m_datExamDate">审核时间</param>
        /// <returns></returns>
        internal long m_lngCommitStockPlan(long lngSEQ, string m_strExamer, DateTime m_datExamDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngCommitStockPlan(objPrincipal, lngSEQ, m_strExamer, m_datExamDate);
            return lngRes;
        }

        internal long m_lngUnCommit(long[] lngSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, lngSEQArr);
            return lngRes;
        }

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strStockPlanID">单据号</param>
        /// <param name="p_strMedicinePreptype">药品剂型</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        internal long m_lngGetStockPlan(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName, string p_strStockPlanID, string p_strMedicinePreptype, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngGetStockPlan(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, p_strMedicineName, p_strVendorName, p_strStockPlanID, p_strMedicinePreptype, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取指定仓库的药品类型
        /// <summary>
        /// 获取指定仓库的药品类型
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMTVO">药品制剂类型</param>
        /// <returns></returns>
        internal long m_lngGetStorageMedicineType(string p_strStorageID, out clsMS_MedicineType_VO[] p_objMTVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStorageMedicineType(objPrincipal, p_strStorageID, out p_objMTVO);
            return lngRes;
        }
        #endregion

        #region 获取明细表内容
        /// <summary>
        /// 获取明细表内容
        /// </summary>
        /// <param name="p_lngSeries2ID">明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal long m_mthGetStockPlanDetail(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngGetStockPlanDetail(objPrincipal, p_lngSeries2ID, out p_dtbValue);
            return lngRes;
        }
        #endregion
    }
}
