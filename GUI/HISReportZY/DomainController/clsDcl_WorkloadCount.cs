using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS.Report;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_WorkloadCount : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_WorkloadCount() { }

        #region 检验科工作人员工作量统计分析表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="categoryId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long GetWorkLoadCount(string dteStart, string dteEnd, string categoryId, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetWorkLoadCount(dteStart, dteEnd,categoryId, out dtbResult);
            }
        }
        #endregion

        #region 获取专业组
        /// <summary>
        /// 获取专业组
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public void lngGetAllCheckSpec(out DataTable dtbResult)
        {
            dtbResult = null;

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                dtbResult = svc.GetGategoryType();
            }
        }
        #endregion
    }
}
