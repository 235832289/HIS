using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 新药明细域类
    /// </summary>
    public class clsDcl_NewPurchaseMedicine : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获得新药明细
        /// <summary>
        /// 获得新药明细
        /// </summary>
        /// <param name="p_alArr">查询条件</param>
        /// <param name="p_dtbResult">返回结果</param>
        /// <returns></returns>
        internal long m_lngGetNewPurchaseMedicine(ArrayList p_alArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsNewPurchaseMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsNewPurchaseMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsNewPurchaseMedicineSVC));
            lngRes = objSvc.m_lngGetNewPurchaseMedicine(objPrincipal, p_alArr, out p_dtbResult);
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
        internal long m_mthGetMedicineType(string p_strStorageID, out clsMS_MedicineType_VO[] p_objMTVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStorageMedicineType(objPrincipal, p_strStorageID, out p_objMTVO);
            return lngRes;
        }
        #endregion
    }
}
