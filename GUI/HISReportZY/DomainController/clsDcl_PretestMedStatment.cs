using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS.Report;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_PretestMedStatment : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_PretestMedStatment()
        {

        }

        #region 预发药汇总
        /// <summary>
        /// 预发药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPretestMedStatment(string dteStart, string dteEnd, string deptStr, string orderType, string medName, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetPretestMedStatment(dteStart, dteEnd, deptStr, orderType, medName, out dtbResult);
            }
        }
        #endregion

        #region 预发药冲减
        /// <summary>
        /// 预发药冲减
        /// </summary>
        /// <param name="putmeddetailId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetRePretestMedStat(string putmeddetailId, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetRePretestMedStat(putmeddetailId, out dtbResult);
            }
        }
        #endregion
    }
}
