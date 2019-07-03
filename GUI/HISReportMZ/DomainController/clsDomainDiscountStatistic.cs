using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDomainDiscountStatistic : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获得门诊的科室名称
        /// <summary>
        /// 获得门诊的科室名称
        /// </summary>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetDepartInfo(ref DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsDiscountStatistic objSvc =
               (com.digitalwave.iCare.middletier.HIS.Reports.clsDiscountStatistic)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDiscountStatistic));
            long lngRes = objSvc.m_lngGetDepartInfo(ref dtResult);
            return lngRes;
        }
        #endregion

        #region 获取手术类型的项目信息
        /// <summary>
        /// 获取手术类型的项目信息
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_GetItem(string ItemName, out DataTable dt)
        {
            long lngRes = 0;
            dt = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell objSvc =
                                                (com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell));
            lngRes = objSvc.GetItem(ItemName, out dt);
            return lngRes;

        }
        #endregion
    }
}
