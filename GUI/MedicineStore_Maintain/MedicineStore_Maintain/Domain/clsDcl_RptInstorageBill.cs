using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 入库单据报表
    /// </summary>
    public class clsDcl_RptInstorageBill : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 入库类别
        /// <summary>
        /// 入库类别
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        internal long m_lngGetInStorageType(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetInStorageType(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 缓存供货商表
        /// <summary>
        /// 缓存供货商表
        /// </summary>
        /// <param name="m_dtVendor"></param>
        /// <returns></returns>
        internal long m_mthGetVendorInfo(int intDsOrMs, out DataTable m_dtVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_mthGetVendorInfo(intDsOrMs, out m_dtVendor);
            return lngRes;
        }
        #endregion

        #region 获取入库单据数据
        /// <summary>
        /// 获取入库单据数据
        /// </summary>
        /// <param name="strstorageid"></param>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strTypeid"></param>
        /// <param name="m_strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_lngGetInstorageBillInfo(int intDsOrMs, DateTime p_dtBegin, DateTime p_dtEnd, string m_strTypeid, string m_strVendorid, string m_strStorageid, out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetInstorageBillInfo(intDsOrMs, p_dtBegin, p_dtEnd, m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
            return lngRes;
        }
        #endregion

        #region 库名
        /// <summary>
        /// 库名
        /// </summary>
        /// <param name="strDsOrMs">0-药房;1-药库</param>
        /// <param name="m_dtStorageName"></param>
        /// <returns></returns>
        internal long m_mthGetStorageName(int intDsOrMs, out DataTable m_dtStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_mthGetStorageName(intDsOrMs, out m_dtStorageName);
            return lngRes;
        }
        #endregion
    }
}
