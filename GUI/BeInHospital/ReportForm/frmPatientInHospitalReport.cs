using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPatientInHospitalReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        clsDcl_Report m_objManage;
        /// <summary>
        /// 报表文档,用于读入水晶报表
        /// </summary>
        ReportDocument m_repotDoc;
        public frmPatientInHospitalReport()
        {
            InitializeComponent();
            m_objManage = new clsDcl_Report();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DataTable p_dtbResult;
                long lngRes = m_objManage.m_lngPatientInHospitalReport(m_dtFromTime.Value.Date, m_dtToTime.Value.AddDays(1).Date, out p_dtbResult);
                m_repotDoc = new ReportDocument();
                m_repotDoc.Load(@".\report\rptPatientInHospitalTotal.rpt");
                p_dtbResult.Columns[0].ColumnName = "strColumn0";
                p_dtbResult.Columns[1].ColumnName = "strColumn1";
                p_dtbResult.Columns[2].ColumnName = "strColumn2";
                p_dtbResult.Columns[3].ColumnName = "strColumn3";
                p_dtbResult.Columns[4].ColumnName = "decColumn0";
                p_dtbResult.Columns[5].ColumnName = "decColumn1";
                m_repotDoc.SetDataSource(p_dtbResult);
                ((TextObject)m_repotDoc.ReportDefinition.ReportObjects["m_txtDateTime"]).Text = "入院日期: " + m_dtFromTime.Value.ToShortDateString() + " 至 " + m_dtToTime.Value.ToShortDateString();
                m_crystalReportViewer.ReportSource = m_repotDoc;
            }
            catch (EvaluateException ex)
            {
                MessageBox.Show(ex.Message, "获取报表数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}