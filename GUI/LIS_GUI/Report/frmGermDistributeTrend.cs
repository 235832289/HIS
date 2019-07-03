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
    public partial class frmGermDistributeTrend : Form
    {
        private ReportDocument m_rdGermDistributeTrend = new ReportDocument();

        public frmGermDistributeTrend()
        {
            InitializeComponent();
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

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strDateFrom = this.dtpDateFrom.Value.ToString("yyyy-MM-dd 00:00:00");
            string strDateTo = this.dtpDateTo.Value.ToString("yyyy-MM-dd 23:59:59");

            //this.Cursor = Cursors.WaitCursor;
            DataTable m_dtbOccurRate = new DataTable();

            clsController_SamplesCheckTotal objGermDistributeTrend = new clsController_SamplesCheckTotal();
            long lngRes = objGermDistributeTrend.m_lngGetGermDistributeTrend(out m_dtbOccurRate, strDateFrom, strDateTo);


            if (lngRes > 0 && m_dtbOccurRate != null && m_dtbOccurRate.Rows.Count > 0)
            {
                string strReportPath = @"lis_reports\cryGermDistributeTrend.rpt";
                m_mthBindDataToReport(m_rdGermDistributeTrend, strReportPath, m_dtbOccurRate);

                //设置时间域
                this.m_rdGermDistributeTrend.SetParameterValue(0, strDateFrom.Substring(0, 7));
                this.m_rdGermDistributeTrend.SetParameterValue(1, strDateTo.Substring(0, 7));

                //显示报表
                this.crvGermDistributeTrend.ReportSource = m_rdGermDistributeTrend;
            }
            else
            {
                MessageBox.Show("没有符合条件的记录！");
                return;
            }
        }

        /// <summary>
        /// 释放报表
        /// </summary>
        private void frmGermDistributeTrend_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_rdGermDistributeTrend != null)
                m_rdGermDistributeTrend.Close();
        }

        private void frmGermDistributeTrend_Load(object sender, EventArgs e)
        {
            dtpDateFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDateTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month));
        }
    }
}