using System;
using System.Collections.Generic;
using System.Text;
using iCare_GL_Report;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    class clscontrolGLReport : com.digitalwave.GUI_Base.clsController_Base
    {
        public void ShowMZDoctor(string strURL, string strProject,string strReportName)
        {
            iCare_GL_Report_manage frm_report = new iCare_GL_Report_manage(strURL, strProject, strReportName);
            frm_report.Show();
        }
    }
}
