using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDomainController_PmpctStat : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainController_PmpctStat()
        {

        }

        #region 免费母婴阻断检测工作情况记录
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPmpcStat(string dteStart, string dteEnd, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetPmpctStat(dteStart, dteEnd, out dtbResult);

            return lngRes;
        }
        #endregion


        #region 免费母婴阻断阳性结果汇总
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPmpcDetail(string dteStart, string dteEnd, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetPmpctDetail(dteStart, dteEnd, out dtbResult);

            return lngRes;
        }
        #endregion
    }
}
