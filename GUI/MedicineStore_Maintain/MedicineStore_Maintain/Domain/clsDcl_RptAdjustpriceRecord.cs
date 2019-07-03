using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品调价记录查询
    /// </summary>
    public class clsDcl_RptAdjustpriceRecord : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 库房名称
        /// <summary>
        /// 库房名称
        /// </summary>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_mthGetStorageName(int intDsOrMs, out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsReportInStorageBill_Supported_SVC));
            lngRes = objSvc.m_mthGetStorageName(intDsOrMs, out m_dtResult);
            return lngRes;
        }
        #endregion

        #region 获取数据 不用
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strStorageid"></param>
        /// <param name="m_dtTable"></param>
        /// <returns></returns>
        //internal long m_mthSelectAdjustData(int intDsOrMs, DateTime p_dtBegin, DateTime p_dtEnd, string m_strStorageid, out DataTable m_dtTable)
        //{
        //    long lngRes = 0;
        //    com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceRecord_Supported_SVC objSvc =
        //        (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceRecord_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceRecord_Supported_SVC));
        //    lngRes = objSvc.m_mthSelectAdjustData(intDsOrMs, p_dtBegin, p_dtEnd, m_strStorageid, out m_dtTable);
        //    return lngRes;
        //}
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strStorageid"></param>
        /// <param name="m_dtTable"></param>
        /// <returns></returns>
        internal long m_mthSelectAdjustData(int intDsOrMs, DateTime p_dtBegin, DateTime p_dtEnd, string p_Medid, out DataTable m_dtTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceRecord_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceRecord_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceRecord_Supported_SVC));
            lngRes = objSvc.m_mthSelectAdjustData(intDsOrMs, p_dtBegin, p_dtEnd, p_Medid, out m_dtTable);
            return lngRes;
        }
        #endregion

        internal long m_lngGetBaseMedicine(string p_strcboStoreid, out DataTable dt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC));
            lngRes = objSvc.m_lngGetBaseMedicine(p_strcboStoreid, out dt);
            return lngRes;
        }
    }
}
