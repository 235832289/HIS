using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    #region 获取单据、处方、摆药去向统计表
    /// <summary>
    /// 获取单据、处方、摆药去向统计表
    /// </summary>
    /// <param name="p_objPrincipal"></param>
    /// <param name="p_strDrugID">药房</param>
    /// <param name="p_dtmStartDate">开始日期</param>
    /// <param name="p_dtmEndDate">结束日期</param>
    /// <param name="p_strMedicineTypeID">药品类型</param>
    /// <param name="p_dtbResult">查询结果</param>
    /// <returns></returns>
    public class clsDcl_RptGoWayStat : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngGetGoWayStat(string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,string p_strMedicineTypeID, out DataTable p_dtbResult,out double p_dblSumMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetGoWayStat(null, p_strDrugID, p_dtmStartDate, p_dtmEndDate, p_strMedicineTypeID, out p_dtbResult,out p_dblSumMoney);
            return lngRes;
        }

        internal long m_lngGetMedicineType(out DataTable dtMedType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineType(out dtMedType);
            return lngRes;
        }

        internal long m_lngGetStoreNameByID(string p_strID, out string p_strName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreNameByID(null, p_strID,out p_strName);
            return lngRes;
        }

        internal long m_lngGetDeptIDByDrugID(string p_strId, out string p_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetDeptIDByDrugID(null, p_strId, out p_strDeptID);
            return lngRes;
        }
    }
    #endregion
}
