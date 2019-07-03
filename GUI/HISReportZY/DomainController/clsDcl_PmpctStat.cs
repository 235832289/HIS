using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_PmpctStat : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_PmpctStat()
        {

        }

        #region 免费母婴阻断检测工作情况记录
        /// <summary>
        /// 免费母婴阻断检测工作情况记录
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPmpcStat(string dteStart, string dteEnd,string patType, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetPmpctStat(dteStart, dteEnd,patType, out dtbResult);
            }
        }
        #endregion

        #region 免费母婴阻断阳性结果汇总
        /// <summary>
        /// 免费母婴阻断阳性结果汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPmpcDetail(string dteStart, string dteEnd, string patType, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetPmpctDetail(dteStart, dteEnd, patType,  out dtbResult);
            }
        }
        #endregion
    }
}
