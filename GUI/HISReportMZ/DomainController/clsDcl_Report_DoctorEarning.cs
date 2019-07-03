using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 统计门诊挂号费及诊金报表 业务逻辑控制类
    /// </summary>
    class clsDcl_Report_DoctorEarning : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngSelectDoctorEarning(DateTime dtBeginDat, DateTime dtEndDat, out DataTable m_dtbReport)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            return objSvc.m_lngSelectDoctorEarning(dtBeginDat.ToShortDateString(), dtEndDat.ToShortDateString(), out m_dtbReport);
        }
    }
}
