using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 供药单位供药明细
    /// </summary>
    class clsDcl_VendorSupplyDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        /// <summary>
        /// 供药单位供药明细
        /// </summary>
        public clsDcl_VendorSupplyDetail()
        {
        }

        #region 查询供药单位供药明细
        /// <summary>
        /// 查询供药单位供药明细
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="p_strVendorID">供药单位ID</param>
        /// <param name="p_intMedicineSetID">药品类型</param>
        /// <param name="p_dtbData">药品入库明细</param>
        /// <returns></returns>
        internal long m_lngStatistics(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsVendorSupplyDetaiSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsVendorSupplyDetaiSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsVendorSupplyDetaiSVC));
            lngRes = objSvc.m_lngStatistics(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strVendorID, p_intMedicineSetID, out p_dtbData);
            return lngRes;
        }
        #endregion

        #region  获得仓库名称
        /// <summary>
        /// 获得仓库名称
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名称</param>
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

        #region 获得供应商
        /// <summary>
        /// 获得供应商
        /// </summary>
        /// <param name="p_dtbVendor">供应商</param>
        /// <returns></returns>
        internal long m_lngGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetVendor(objPrincipal, out p_dtbVendor);
            return lngRes;
        }
        #endregion
    }
}
