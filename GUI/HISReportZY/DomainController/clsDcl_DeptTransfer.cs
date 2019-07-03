using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_DeptTransfer : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 病人（来源）住院查询
        /// <summary>
        ///  病人（来源）住院查询 
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_strOutStartDate"></param>
        /// <param name="p_strOutEndDate"></param>
        /// <param name="p_dtbReulst"></param>
        /// <returns></returns>
        public long m_lngGetCollectorReport_PatientSource(string p_strStartDate, string p_strEndDate, string p_strOutStartDate, string p_strOutEndDate, out  DataTable p_dtbReulst)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc = (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));
            long lngRes = objSvc.m_lngGetCollectorReport_PatientSource(p_strStartDate, p_strEndDate, p_strOutStartDate, p_strOutEndDate, out p_dtbReulst);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;    
        }
        #endregion
    }
}
