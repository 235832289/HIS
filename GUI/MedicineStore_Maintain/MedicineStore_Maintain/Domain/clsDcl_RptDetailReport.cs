using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    #region 获取药品出入库帐
    
    public class clsDcl_RptDetailReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        /// <summary>
        /// 查询出入库帐
        /// </summary>
        /// <param name="p_blnIsDS">是否药房</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_blnCombine">是否单品种</param>
        /// <param name="p_strStorageID">库房ID</param>
        /// <param name="p_strMedicineID">药品ID或助记码</param>
        /// <param name="p_dtmStart">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        internal long m_lngGetMedicineDetailReport(bool p_blnIsDS,bool p_blnIsHospital,bool p_blnCombine, string p_strStorageID,string p_strMedicineID, DateTime p_dtmStartDate, DateTime p_dtmEndDate, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptSelectAllMedicine_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptSelectAllMedicine_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptSelectAllMedicine_SVC));
            lngRes = objSvc.m_lngGetMedicineDetailReport(objPrincipal, p_blnIsDS, p_blnIsHospital, p_blnCombine, p_strStorageID,p_strMedicineID, p_dtmStartDate, p_dtmEndDate, out p_dtbResult);
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
            lngRes = objSvc.m_lngGetStoreNameByID(objPrincipal, p_strID, out p_strName);
            return lngRes;
        }

        internal long m_lngGetDeptIDByDrugID(string p_strId, out string p_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBill_Supported_SVC));
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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 判断药房是否属于住院药房
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <returns></returns>
        internal long m_lngCheckIsHospital(string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckIsHospital(objPrincipal, p_strDrugStoreID, out p_blnIsHospital);
            return lngRes;
        }
    }
    #endregion
}
