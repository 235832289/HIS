using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clcDcl_CurmedStatment : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clcDcl_CurmedStatment()
        {

        }

        #region 疗程用药汇总
        /// <summary>
        /// 疗程用药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetCureMedStatment(string dteStart, string dteEnd, string deptStr, string medName, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetCureMedStatment(dteStart, dteEnd, deptStr, medName, out dtbResult);
            }
        }
        #endregion

    }
}