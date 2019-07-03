using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 全院预交金结算报表业务控制层
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-21
    /// </summary>
    class clsDclPrepayBalanceReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDclPrepayBalanceReport()
        {
            //
        }

        #region 根据日期查询预收款结算信息
        /// <summary>
        /// 根据日期查询预收款结算信息
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetPrepayBalanceInfoByDate(string p_strStartDate, string p_strEndDate, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetPrepayBalanceInfoByDate(p_objPrincipal, p_strStartDate, p_strEndDate, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据日期查询预收款结算备注信息
        /// <summary>
        /// 根据日期查询预收款结算备注信息
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetPrepayBalanceRemarkByDate(string p_strStartDate, string p_strEndDate, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetPrepayBalanceRemarkByDate(p_objPrincipal, p_strStartDate, p_strEndDate, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

    }
}
