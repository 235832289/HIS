using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 调入库单
    /// </summary>
    public class clsDcl_CallInStorageInfo : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 根据入库单据号调入库单
        /// <summary>
        /// 根据入库单据号调入库单
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dtbInInfo">入库单信息</param>
        /// <returns></returns>
        internal long m_lngCallInStorageInfoByInID(string p_strStorageID, string p_strInStorageID, string p_strVendorID, out DataTable p_dtbInInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC));
            lngRes = objSvc.m_lngCallInStorageInfoByInID(objPrincipal, p_strStorageID, p_strInStorageID,p_strVendorID, out p_dtbInInfo);
            return lngRes;
        }
        #endregion

        #region 根据药品助记码调入库单
        /// <summary>
        /// 根据药品助记码调入库单
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dtbInInfo">入库单信息</param>
        /// <returns></returns>
        internal long m_lngCallInStorageInfoByMedicineID(string p_strStorageID, string p_strMedicineID, string p_strVendorID, out DataTable p_dtbInInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC));
            lngRes = objSvc.m_lngCallInStorageInfoByMedicineID(objPrincipal, p_strStorageID, p_strMedicineID,p_strVendorID, out p_dtbInInfo);
            return lngRes;
        }
        #endregion
    }
}
