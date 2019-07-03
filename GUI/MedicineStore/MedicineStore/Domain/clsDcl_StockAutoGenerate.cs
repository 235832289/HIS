using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    class clsDcl_StockAutoGenerate : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取明细数据
        internal long m_lngGetDetailForGenerate(string m_strStorageID, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngGetDetailForGenerate(objPrincipal, m_strStorageID, ref dtbResult);
            return lngRes;
        }
        #endregion
    }
}
