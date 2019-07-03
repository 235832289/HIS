using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS.Report;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_KsMedStatment : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 科室用药汇总
        /// <summary>
        /// 科室用药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetKsMedStatment(string dteStart, string dteEnd, string deptStr, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetKsMedStatment(dteStart, dteEnd, deptStr, out dtbResult);
            }
        }
        #endregion
    }
}
