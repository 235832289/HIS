using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品毛利率设置中间件访问类
    /// </summary>
    public class clsDcl_MedicineGrossProfitRateSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药品毛利率设置
        /// <summary>
        /// 获取药品毛利率设置
        /// </summary>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        /// <returns></returns>
        internal long m_lngGetGrossProfitRateSet(out  clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC));
            lngRes = objSvc.m_lngGetGrossProfitRateSet(objPrincipal, out p_objRateArr);
            return lngRes;
        } 
        #endregion

        #region 修改药品毛利率设置
        /// <summary>
        /// 修改药品毛利率设置
        /// </summary>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        /// <returns></returns>
        internal long m_lngModifyGrossProfitRateSet(clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC));
            lngRes = objSvc.m_lngModifyGrossProfitRateSet(objPrincipal, p_objRateArr);
            return lngRes;
        } 
        #endregion

        #region 添加药品毛利率设置
        /// <summary>
        /// 添加药品毛利率设置
        /// </summary>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        /// <returns></returns>
        internal long m_lngAddGrossProfitRateSet(clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineGrossProfitRateSetSVC));
            lngRes = objSvc.m_lngAddGrossProfitRateSet(objPrincipal, p_objRateArr);
            return lngRes;
        } 
        #endregion
    }
}
