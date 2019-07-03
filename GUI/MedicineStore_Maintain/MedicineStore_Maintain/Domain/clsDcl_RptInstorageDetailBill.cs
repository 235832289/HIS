using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 入库单据报表的明细表
    /// </summary>
    public class clsDcl_RptInstorageDetailBill : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 入库类别
        /// <summary>
        /// 入库类别
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        internal long m_mthGetInstorageName(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetInStorageType(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 供货商表
        /// <summary>
        /// 缓存供货商表
        /// </summary>
        /// <param name="p_dtVendor"></param>
        /// <returns></returns>
        internal long m_mthGetVendorName(int intDsOrMs, out DataTable p_dtVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_mthGetVendorInfo(intDsOrMs, out p_dtVendor);
            return lngRes;
        }
        #endregion

        #region 单据数据
        /// <summary>
        /// 单据数据
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strTypeid"></param>
        /// <param name="m_strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_lngGetInstorageDetailBillInfo(int intDsOrMs, DateTime p_dtBegin, DateTime p_dtEnd, string m_strTypeid, string m_strVendorid, string m_strStorageid, out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_lngGetInstorageDetailBillInfo(intDsOrMs, p_dtBegin.ToShortDateString(), p_dtEnd.ToShortDateString(), m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
            return lngRes;
        }
        #endregion

        #region 库房名称
        /// <summary>
        /// 库房名称
        /// </summary>
        /// <param name="m_dtStorageName"></param>
        /// <returns></returns>
        internal long m_mthGetStorageName(int intDsOrMs,out DataTable m_dtStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_mthGetStorageName(intDsOrMs,out m_dtStorageName);
            return lngRes;
        }
        #endregion
    }
}
