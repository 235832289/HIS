using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsDcl_InitialInStorageWithdraw : com.digitalwave.GUI_Base.clsDomainController_Base
    {
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
    }
}
