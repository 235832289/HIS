using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsDcl_RptGoWayStorageStat : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        /// <summary>
        /// 获取库房名称
        /// </summary>
        /// <param name="p_intMsOrDs"></param>
        /// <param name="p_dtbMedName"></param>
        /// <returns></returns>
        internal long m_mthGetMsOrDsName(int p_intMsOrDs, out DataTable p_dtbMedName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_mthGetStorageName(p_intMsOrDs, out p_dtbMedName);
            return lngRes;
        }

        /// <summary>
        /// 药品类型
        /// </summary>
        /// <param name="dtMedType"></param>
        /// <returns></returns>
        internal long m_lngGetMedicineType(out DataTable dtMedType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC));
            lngRes = objSvc.m_mthGetMedicineType(out dtMedType);
            return lngRes;
        }

        #region 获取领用部门
        /// <summary>
        /// 获取领用部门
        /// </summary>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        internal long m_lngGetExportDept(out DataTable p_dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_mthGetExportDept(objPrincipal, out p_dtbExportDept);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 药品去向汇总统计数据(药房)
        /// </summary>
        /// <param name="dtmBegin"></param>
        /// <param name="dtmEnd"></param>
        /// <param name="strMedStorageid"></param>
        /// <param name="strMedTypeid"></param>
        /// <param name="strDeptid"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        internal long m_mthSearchData(bool blnIsDrugStore, DateTime dtmBegin, DateTime dtmEnd, string strMedStorageid, string strMedTypeid, string strDeptid, out DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC));
            lngRes = objSvc.m_mthSearchData(blnIsDrugStore, dtmBegin, dtmEnd, strMedStorageid, strMedTypeid, strDeptid, out dtResult);
            return lngRes;
        }     

        #region 获取领用部门
        /// <summary>
        /// 获取领用部门
        /// </summary>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        internal long m_lngGetExportDeptForDrugStore(out DataTable p_dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetExportDeptForDrugStore(objPrincipal, out p_dtbExportDept);
            return lngRes;
        }
        #endregion
    }
}
