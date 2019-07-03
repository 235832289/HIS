using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class Form1Test : Form
    {
        public Form1Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
            DataTable dt = svc.GetCpStat1("2017-08-01", "2017-08-01");
        }
    }
}
