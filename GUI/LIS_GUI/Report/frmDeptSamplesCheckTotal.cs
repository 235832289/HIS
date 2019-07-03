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
    public partial class frmDeptSamplesCheckTotal : Form
    {

        private ReportDocument m_rdSamplesCheckTotal = new ReportDocument();
        public frmDeptSamplesCheckTotal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 统计
        /// </summary>
        private void btnSamplesCheckTotal_Click(object sender, EventArgs e)
        {
            string strDateFrom=this.dtpDateFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string strDateTo = this.dtpDateTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            //this.Cursor = Cursors.WaitCursor;
            DataTable m_dtbSamplesCheckTotal=new DataTable();

            clsController_SamplesCheckTotal objSamples = new clsController_SamplesCheckTotal();
            long lngRes = objSamples.m_lngGetSamplesCheckTotal(out m_dtbSamplesCheckTotal, strDateFrom, strDateTo);
           
                
            if (lngRes > 0 && m_dtbSamplesCheckTotal != null && m_dtbSamplesCheckTotal.Rows.Count > 0)
            {
                string strReportPath = @"lis_reports\CryDeptSamplesCheckTotal.rpt";
                m_mthBindDataToReport(m_rdSamplesCheckTotal, strReportPath,m_dtbSamplesCheckTotal);

                //设置时间域
                this.m_rdSamplesCheckTotal.SetParameterValue(0, strDateFrom.Substring(0,10));
                this.m_rdSamplesCheckTotal.SetParameterValue(1,strDateTo.Substring(0,10));
                
                //显示报表
                this.crvSamplesCheckTotal.ReportSource = m_rdSamplesCheckTotal;
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
        private void m_mthBindDataToReport(ReportDocument p_rdTarget,string p_strReportPath,DataTable p_dtbReportSource)
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
        /// 关闭ReportDocument文件
        /// </summary>
        private void frmDeptSamplesCheckTotal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_rdSamplesCheckTotal != null)
                m_rdSamplesCheckTotal.Close();
        }

    }
}