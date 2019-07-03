using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 
    /// </summary>
    public class clsDcl_RptAdjustpricefullloss : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药库名称
        /// <summary>
        /// 获取药库名称
        /// </summary>
        /// <param name="m_dtStorageName"></param>
        /// <returns></returns>
        internal long m_mthGetStorageName(out DataTable m_dtStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC));
            lngRes = objSvc.m_mthGetStorageName(out m_dtStorageName);
            return lngRes;
        }
        #endregion

        #region 获取药品名称
        /// <summary>
        /// 获取药品名称
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        internal long m_mthGetMedicineType(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC));
            lngRes = objSvc.m_mthGetMedicineType(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="m_strStorageid"></param>
        /// <param name="m_strTypeid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_mthSelectAdjustprice(DateTime p_dtBegin, DateTime p_dtEnd, string m_strStorageid, string m_strTypeid, string Medid, out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC));
            lngRes = objSvc.m_mthSelectAdjustprice(p_dtBegin, p_dtEnd, m_strStorageid, m_strTypeid, Medid, out m_dtResult);
            return lngRes;
        }
        #endregion

        internal long m_lngGetBaseMedicine(string p__cboStorageid, out DataTable dt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpricefullloss_Supported_SVC));
            lngRes = objSvc.m_lngGetBaseMedicine(p__cboStorageid, out dt);
            return lngRes;
        }
    }
}
