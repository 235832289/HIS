using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品调价情况一览表
    /// </summary>
    public class clsDcl_RptAdjustpriceDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        internal long m_mthSelectAdjustData(int intDsOrMs, int p_intMakeFilm,DateTime p_dtBegin, DateTime p_dtEnd, string m_strMedicineid, string strMedNameid, out DataTable m_dtTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC));
            lngRes = objSvc.m_mthSelectAdjustData(intDsOrMs, p_intMakeFilm,p_dtBegin, p_dtEnd, m_strMedicineid, strMedNameid, out m_dtTable);
            return lngRes;
        }
        #endregion

        #region 药品类型
        /// <summary>
        /// 药品类型
        /// </summary>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        internal long m_mthGetMedicineType(out DataTable m_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRptAdjustpriceDetail_Supported_SVC));
            lngRes = objSvc.m_mthGetMedicineType(out m_dtResult);
            return lngRes;
        }
        #endregion

        #region 药品名称
        /// <summary>
        /// 药品名称
        /// </summary>
        /// <param name="p_strMedName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        internal long m_mthShowMedName(string p_strMedName, out DataTable dt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePrice_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePrice_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePrice_Supported_SVC));
            lngRes = objSvc.m_mthShowMedName(p_strMedName, out dt);
            return lngRes;
        }
        #endregion
    }
}
