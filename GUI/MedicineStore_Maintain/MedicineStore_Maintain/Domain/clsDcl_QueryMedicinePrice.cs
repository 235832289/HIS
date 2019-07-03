using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品价格查询
    /// </summary>
    public class clsDcl_QueryMedicinePrice : com.digitalwave.GUI_Base.clsDomainController_Base
    {
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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePriceSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePriceSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePriceSVC));
            lngRes = objSvc.m_mthShowMedName(p_strMedName, out dt);
            return lngRes;
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="strMedicineid">药品id</param>
        /// <param name="m_dtTable"></param>
        /// <returns></returns>
        internal long m_mthGetMedicine(DateTime p_dtBegin, DateTime p_dtEnd, string strMedicineid, out DataTable m_dtTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePriceSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePriceSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicinePriceSVC));
            lngRes = objSvc.m_mthGetMedicine(p_dtBegin, p_dtEnd, strMedicineid, out m_dtTable);
            return lngRes;
        }
        #endregion
    }
}
