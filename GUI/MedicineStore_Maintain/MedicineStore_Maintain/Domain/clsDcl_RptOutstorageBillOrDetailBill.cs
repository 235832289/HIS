using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 出库单据/出库单据明细表
    /// </summary>
    public class clsDcl_RptOutstorageBillOrDetailBill : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 供货商缓存表
        /// <summary>
        /// 供货商缓存表
        /// </summary>
        /// <param name="m_objVendorTable"></param>
        internal long m_mthGetVendorTable(int intDsOrMs, out DataTable m_objVendorTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBillSVC));
            lngRes = objSvc.m_mthGetVendorInfo(intDsOrMs, out m_objVendorTable);
            return lngRes;
        }
        #endregion

        #region 出库类别
        /// <summary>
        /// 出库类别
        /// </summary>
        /// <param name="m_objTable"></param>
        internal long m_mthGetOutstorageType(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_mthGetOutstorageType(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 出库单据明细表
        /// <summary>
        /// 出库单据明细表
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strTypeid"></param>
        /// <param name="m_strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_lngGetOutstorageDetailBillInfo(int intDsOrMs, DateTime p_dtBegin, DateTime p_dtEnd, string m_strTypeid, string m_strVendorid, string m_strStorageid, out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_lngGetOutstorageDetailBillInfo(intDsOrMs, p_dtBegin.ToShortDateString(), p_dtEnd.ToShortDateString(), m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
            return lngRes;
        }
        #endregion

        #region 出库单据
        /// <summary>
        /// 出库单据
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strTypeid"></param>
        /// <param name="m_strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_lngGetOutstorageBillInfo(int intDsOrMs, DateTime p_dtBegin, DateTime p_dtEnd, string m_strTypeid, string m_strVendorid, string m_strStorageid, out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportOutStorageBillSVC));
            lngRes = objSvc.m_lngGetOutstorageBillInfo(intDsOrMs, p_dtBegin.ToShortDateString(), p_dtEnd.ToShortDateString(), m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
            return lngRes;
        }
        #endregion

        #region 库名
        /// <summary>
        /// 库名
        /// </summary>
        /// <param name="intDsOrMs"></param>
        /// <param name="m_dtStorageName"></param>
        /// <returns></returns>
        internal long m_mthGetStorageName(int intDsOrMs, out DataTable m_dtStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBillSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBillSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBillSVC));
            lngRes = objSvc.m_mthGetStorageName(intDsOrMs, out m_dtStorageName);
            return lngRes;
        }
        #endregion
    }
}
