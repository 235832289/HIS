using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
     public class clsDcl_ExportdeptSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
         internal long m_lngGetExportdeptAll(out DataTable p_dtbData)
         {
             long lngRes = 0;
             com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                 (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
             lngRes = objSvc.m_lngGetExportdeptAll(out p_dtbData);
             return lngRes;
         }

         internal long m_lngGetExportdept(out DataTable p_dtbData)
         {
             long lngRes = 0;
             com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                 (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
             lngRes = objSvc.m_lngGetExportdept(out p_dtbData);
             return lngRes;
         }

         internal long m_lngSaverExportdept(clsMS_ExportDept[] p_ExportDept)
         {
             long lngRes = 0;
             com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                 (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
             lngRes = objSvc.m_lngSaverExportdept(objPrincipal, p_ExportDept);
             return lngRes;


         }
         
    }
}
