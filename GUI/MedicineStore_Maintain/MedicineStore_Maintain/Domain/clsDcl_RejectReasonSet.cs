using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 报废原因设置
    /// </summary>
    public class clsDcl_RejectReasonSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 添加作废原因
        /// <summary>
        /// 添加作废原因
        /// </summary>
        /// <param name="p_objReason">作废原因</param>
        /// <param name="p_intReasonID">作废原因ID</param>
        /// <returns></returns>
        internal long m_lngAddNewRejectReason(clsMS_RejectReason p_objReason, out int p_intReasonID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngAddNewRejectReason(objPrincipal, p_objReason, out p_intReasonID);
            return lngRes;
        }
        #endregion

        #region 修改作废原因
        /// <summary>
        /// 修改作废原因
        /// </summary>
        /// <param name="p_objReason">作废原因</param>
        /// <returns></returns>
        internal long m_lngModifyRejectReason(clsMS_RejectReason p_objReason)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngModifyRejectReason(objPrincipal, p_objReason);
            return lngRes;
        }
        #endregion

        #region 删除选定作废原因
        /// <summary>
        /// 删除选定作废原因
        /// </summary>
        /// <param name="p_lngReasonID">作废原因ID</param>
        /// <returns></returns>
        internal long m_lngDeleteRejectReason(long[] p_lngReasonID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngDeleteRejectReason(objPrincipal, p_lngReasonID);
            return lngRes;
        }
        #endregion

        #region 更新作废原因顺序
        /// <summary>
        /// 更新作废原因顺序
        /// </summary>
        /// <param name="p_objReason">作废原因</param>
        /// <returns></returns>
        internal long m_lngUpdateReasonSort(clsMS_RejectReason[] p_objReason)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngUpdateReasonSort(objPrincipal, p_objReason);
            return lngRes;
        }
        #endregion

        #region 获取所有作废原因
        /// <summary>
        /// 获取所有作废原因
        /// </summary>
        /// <param name="p_objReason">作废原因</param>
        /// <returns></returns>
        internal long m_lngGetAllRejectReason(out clsMS_RejectReason[] p_objReason)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngGetAllRejectReason(objPrincipal, out p_objReason);
            return lngRes;
        }
        #endregion
    }
}
