using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// 帐务期结转域控制层
    /// </summary>
    public class clsDcl_AccountPeriod : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取帐务期表内容
        /// <summary>
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="m_strDrugStoreid">药房对应科室ID</param>
        /// <param name="p_dtbAccountData">帐务期表内容</param>
        /// <returns></returns>
        public long m_lngGetAccountPeriod(string m_strDrugStoreid, out DataTable p_dtbAccountData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC));
            lngRes = objSvc.m_lngGetAccountPeriod(objPrincipal, m_strDrugStoreid, out p_dtbAccountData);
            return lngRes;
        }
        #endregion

        #region 获取系统参数配置
        /// <summary>
        /// 获取系统参数配置
        /// </summary>
        /// <param name="p_strCode">配置代码</param>
        /// <param name="p_strParm">参数配置</param>
        /// <returns></returns>
        internal long m_lngGetSysParm(string p_strCode, out string p_strParm)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetSysParm(objPrincipal, p_strCode, out p_strParm);
            return lngRes;
        }
        #endregion

    
    }
}
