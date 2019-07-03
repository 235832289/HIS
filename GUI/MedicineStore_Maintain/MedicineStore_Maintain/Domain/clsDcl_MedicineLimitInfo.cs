using System;
using System.Collections.Generic;
using System.Data ;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品上下限查询
    /// 2008.7.15 chongkun.wu
    /// </summary>
    public class clsDcl_MedicineLimitInfo:com .digitalwave.GUI_Base .clsDomainController_Base
    {
        #region
        /// <summary>
        /// 获取所有库存量低于下限的药品
        /// </summary>
        /// <returns></returns>
        public long m_lngGetMedicineInfo(string p_strStoreStyle,string p_strStoreid,ref DataTable p_dtMedicineInfo)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineLimit_Supported_SVC objSVC =
            //    (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineLimit_Supported_SVC));
            //lngRes = objSVC.m_lngGetMedicineInfo(objPrincipal, p_strStoreStyle, p_strStoreid, ref p_dtMedicineInfo);
            return lngRes;
        }
        #endregion

    }
}
