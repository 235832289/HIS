using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 自动接收通知单据设置
    /// </summary>
    public class clsDcl_OutOrInStorageDeptSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_mthGetOutOrInStoreDept(bool p_blnIsDrugStore, out DataTable p_dtbOutOrInStore)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
            lngRes = objSvc.m_mthGetOutOrInStoreDept(p_blnIsDrugStore, out p_dtbOutOrInStore);
            return lngRes;
        }

        internal long m_mthGetStoreName(bool p_blnIsDrugStore, out DataTable p_dtbStoreName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
            lngRes = objSvc.m_mthGetStoreName(p_blnIsDrugStore, out p_dtbStoreName);
            return lngRes;
        }

        internal long m_mthSearchDept(string strStoreid, out DataTable dtDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
            lngRes = objSvc.m_mthSearchDept(strStoreid, out dtDept);
            return lngRes;
        }

        internal long m_lngSaveData(string p_strStoreid, clsOutOrInStorageDeptSet[] p_objDeptArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsExportdeptSetSVC));
            lngRes = objSvc.m_lngSaveData(objPrincipal, p_strStoreid, p_objDeptArr);
            return lngRes;
        }
    }
}
