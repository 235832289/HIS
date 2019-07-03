using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.middletier.common;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品盘点
    /// </summary>
    public class clsDcl_StorageCheck : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取盘点主表信息
       /// <summary>
        /// 获取盘点主表信息
       /// </summary>
       /// <param name="p_strStarDate">查询开始时间</param>
       /// <param name="p_strEndDate">查询结束时间</param>
        /// <param name="p_strStorage">仓库ID</param>
       /// <param name="dtbStorageCheck">返回数据</param>
       /// <returns></returns>
        internal long m_lngGetStorageCheck(DateTime p_strStarDate, DateTime p_strEndDate, string p_strStorage, out DataTable dtbStorageCheck)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetStorageCheck(objPrincipal, p_strStarDate, p_strEndDate, p_strStorage, out dtbStorageCheck);
            return lngRes;
        }
        #endregion

        #region 获取盘点明细表信息
        /// <summary>
        /// 获取盘点明细表信息
        /// </summary>
        /// <param name="p_lngSeriesId">主表序列号</param>
        /// <param name="dtbStorageCheck_detail">明细表信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageCheck_detail(long p_lngSeriesId, out DataTable dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetStorageCheck_detail(objPrincipal, p_lngSeriesId, out dtbStorageCheck_detail);
            return lngRes;
        }
        #endregion

        #region 删除盘点信息

        /// <summary>
        /// 删除盘点信息
        /// </summary>
        /// <param name="p_lngSEQ">主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageCheck(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteStorageCheck(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 审核盘点
        /// <summary>
        /// 审核盘点
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_objDefCheckDetail">盘亏明细</param>
        /// <param name="p_objSufCheckDetail">盘盈明细</param>
        /// <param name="p_objStDetail">盘点药品相关库存明细</param>
        /// <param name="p_strMedicineIDArr">盘点药品ID</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strCreatorID">盘点人ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsImmAccount">是否盘点即审核</param>
        /// <returns></returns>
        internal long m_lngCommitStorageCheck(long p_lngMainSEQ, clsMS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsMS_StorageCheckDetail_VO[] p_objSufCheckDetail, clsMS_StorageDetail[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, DateTime p_dtmCommitDate,
            string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngCommitStorageCheck(objPrincipal, p_lngMainSEQ, p_objDefCheckDetail, p_objSufCheckDetail, p_objStDetail, p_strMedicineIDArr, p_strEmpID, p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID, p_blnIsImmAccount);
            return lngRes;
        } 
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strCheckID">盘点单据号</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">盘点日期</param>
        /// <param name="p_strStorage">仓库ID</param>
        /// <returns></returns>
        internal long m_lngInAccount(long p_lngMainSEQ, string p_strCheckID, string p_strEmpID, DateTime p_dtmAccountDate, string p_strStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_lngMainSEQ, p_strCheckID, p_strEmpID, p_dtmAccountDate, p_strStorage);
            return lngRes;
        } 
        #endregion
    }
}
