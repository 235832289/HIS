using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    #region 处方出库按开单科室统计
    /// <summary>
    /// 处方出库按开单科室统计
    /// </summary>
    /// <param name="p_objPrincipal"></param>
    /// <param name="p_strDrugID">药房</param>
    /// <param name="p_dtmStartDate">开始日期</param>
    /// <param name="p_dtmEndDate">结束日期</param>
    /// <param name="p_dtbResult">查询结果</param>
    /// <returns></returns>
    public class clsDcl_RecipeByDeptReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngGetRecipeByDept(string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRecipeReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRecipeReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRecipeReportSVC));
            lngRes = objSvc.m_lngGetRecipeByDept(objPrincipal, p_strDrugID, p_dtmStartDate, p_dtmEndDate, out p_dtbResult);
            return lngRes;
        }
    }
    #endregion
}
