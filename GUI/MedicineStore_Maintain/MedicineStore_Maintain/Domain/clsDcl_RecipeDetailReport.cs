using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    #region 获取处方药品出库药品明细表
    /// <summary>
    /// 获取处方药品出库药品明细表
    /// </summary>
    /// <param name="p_objPrincipal"></param>
    /// <param name="p_strDrugID">药房</param>
    /// <param name="p_dtmStartDate">开始日期</param>
    /// <param name="p_dtmEndDate">结束日期</param>
    /// <param name="p_dtbResult">查询结果</param>
    /// <returns></returns>
    public class clsDcl_RecipeDetailReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngGetRecipeDetailReport(string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate, string p_strMedicineID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_lngGetRecipeDetailReport(objPrincipal, p_strDrugID, p_dtmStartDate, p_dtmEndDate, p_strMedicineID, out p_dtbResult);
            return lngRes;
        }

        internal long m_lngGetMedicineType(out DataTable dtMedType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_lngGetMedicineType(out dtMedType);
            return lngRes;
        }

        internal long m_lngGetStoreNameByID(string p_strID, out string p_strName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_lngGetStoreNameByID(objPrincipal, p_strID, out p_strName);
            return lngRes;
        }

        internal long m_lngGetDeptIDByDrugID(string p_strId, out string p_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_lngGetDeptIDByDrugID(objPrincipal, p_strId, out p_strDeptID);
            return lngRes;
        }

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取基本药品信息
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_mthGetMedBaseInfo(string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfo(objPrincipal, m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }
    }
    #endregion
}
