using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmGermOccurRate : Form
    {
        private ReportDocument m_rdSamplesCheckTotal = new ReportDocument();
       
        public frmGermOccurRate()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strDateFrom = this.dtpDateFrom.Value.ToShortDateString() + " 00:00:00";
            string strDateTo = this.dtpDateTo.Value.ToShortDateString() + " 23:59:59";

            //this.Cursor = Cursors.WaitCursor;
            DataTable m_dtbOccurRate = new DataTable();

            clsController_SamplesCheckTotal objGermOccurRate = new clsController_SamplesCheckTotal();
            long lngRes = objGermOccurRate.m_lngGetGermOccurRate(out m_dtbOccurRate, strDateFrom, strDateTo);


            if (lngRes > 0 && m_dtbOccurRate != null && m_dtbOccurRate.Rows.Count > 0)
            {
                string strReportPath = @"lis_reports\cryGermOccurRate.rpt";
                m_mthBindDataToReport(m_rdSamplesCheckTotal, strReportPath, m_dtbOccurRate);

                //设置时间域
                this.m_rdSamplesCheckTotal.SetParameterValue(0, strDateFrom.Substring(0, 10));
                this.m_rdSamplesCheckTotal.SetParameterValue(1, strDateTo.Substring(0, 10));

                //显示报表
                this.crvGermOccurRate.ReportSource = m_rdSamplesCheckTotal;
            }
            else
            {
                MessageBox.Show("没有符合条件的记录！");
                return;
            }
        }

        /// <summary>
        /// 绑定数据到报表文件
        /// </summary>
        /// <param name="p_rdTarget">报表</param>
        /// <param name="p_strReportPath">报表文件路径</param>
        /// <param name="p_dtbReportSource">报表数据</param>
        private void m_mthBindDataToReport(ReportDocument p_rdTarget, string p_strReportPath, DataTable p_dtbReportSource)
        {
            try
            {
                p_rdTarget.Load(p_strReportPath);
                p_rdTarget.SetDataSource(p_dtbReportSource);
            }
            catch
            {
                MessageBox.Show("加载报表失败！");
            }
        }

        private void frmGermOccurRate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_rdSamplesCheckTotal!=null)
                m_rdSamplesCheckTotal.Close();
        }

    }
}