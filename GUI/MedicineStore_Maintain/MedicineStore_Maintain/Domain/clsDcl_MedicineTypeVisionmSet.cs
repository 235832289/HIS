using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品类型显示设置
    /// </summary>
    public class clsDcl_MedicineTypeVisionmSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngGetAllMedicineTypeVisionm(out DataTable p_objDtb)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC));
            lngRes = objSvc.m_lngGetAllMedicineTypeVisionm(objPrincipal, out p_objDtb);
            return lngRes;
        }

        internal long m_lngSaverMedicineType(clsMS_MedicineTypeVisionmSet[] objMedicineType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC));
            lngRes = objSvc.m_lngSaverMedicineType(objPrincipal, objMedicineType);
            return lngRes;
        }
    }

}
