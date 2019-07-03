using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmAnimalculeCheckTotal : Form
    {
        private ReportDocument rdAnimalculeCheckTotal = new ReportDocument();

        public frmAnimalculeCheckTotal()
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

        private void frmAnimalculeCheckTotal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rdAnimalculeCheckTotal != null)
                rdAnimalculeCheckTotal.Close();
        }

        private void frmAnimalculeCheckTotal_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        /// <summary>
        /// 数据初使化
        /// </summary>
        private void InitForm()
        {
            clsController_SamplesCheckTotal objAnimalculeCheckTotal = new clsController_SamplesCheckTotal();
            DataTable dtbSamples = objAnimalculeCheckTotal.m_dtbGetSamplesList();
            DataTable dtbDepts = objAnimalculeCheckTotal.m_dtbGetDeptList();
            foreach (DataRow row in dtbSamples.Rows)
            {
                clbSamples.Items.Add(row["sample_type_desc_vchr"].ToString());
            }
            foreach (DataRow row in dtbDepts.Rows)
            {
                clbPatientArea.Items.Add(row["DEPTNAME_VCHR"].ToString());
            }

            chkArea.Checked = true;
            chkSample.Checked = true;
            CheckedAllCheckedBox(clbSamples, CheckState.Checked);
            CheckedAllCheckedBox(clbPatientArea, CheckState.Checked);
            clbSamples.Enabled = false;
            clbPatientArea.Enabled = false;
        }

        #region 查询相关
        /// <summary>
        /// 查找按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string strDateFrom = this.dtpDateFrom.Value.ToString("yyyy-MM-dd 00:00:00");
            string strDateTo = this.dtpDateTo.Value.ToString("yyyy-MM-dd 23:59:59");

            //this.Cursor = Cursors.WaitCursor;
            DataTable m_dtbOccurRate = new DataTable();

            clsController_SamplesCheckTotal objAnimalculeCheckTotal = new clsController_SamplesCheckTotal();
            long lngRes = objAnimalculeCheckTotal.m_lngGetAnimalculeCheckTotoal(out m_dtbOccurRate, strDateFrom, strDateTo, GetCheckList(clbSamples), GetCheckList(clbPatientArea));


            if (lngRes > 0 && m_dtbOccurRate != null && m_dtbOccurRate.Rows.Count > 0)
            {
                string strReportPath = @"lis_reports\cryAnimalculeCheckTotal.rpt";
                m_mthBindDataToReport(rdAnimalculeCheckTotal, strReportPath, m_dtbOccurRate);

                //传值给报表

                this.rdAnimalculeCheckTotal.SetParameterValue(0, GetCheckedItemString(clbSamples));
                this.rdAnimalculeCheckTotal.SetParameterValue(1, GetCheckedItemString(clbPatientArea));
                this.rdAnimalculeCheckTotal.SetParameterValue(2, strDateFrom.Substring(0, 10));
                this.rdAnimalculeCheckTotal.SetParameterValue(3, strDateTo.Substring(0, 10));

                //显示报表
                this.crvAnimalCuleCheckTotal.ReportSource = rdAnimalculeCheckTotal;
            }
            else
            {
                MessageBox.Show("没有符合条件的记录！");
                return;
            }
        }

        /// <summary>
        /// 传给报表的参数值。
        /// CheckListBox中选中的值的集合
        /// </summary>
        /// <param name="listBox"></param>
        /// <returns></returns>
        private string GetCheckedItemString(CheckedListBox listBox)
        {
            if (!listBox.Enabled)
                return "全部";

            StringBuilder sb = new StringBuilder();
            foreach (object checkedItem in listBox.CheckedItems)
            {
                sb.Append(checkedItem.ToString() + "、");
            }
            //去除最后一个'、'
            sb.Replace('、', ' ', sb.ToString().Length - 2, 2);
            return sb.ToString();
        }

        /// <summary>
        /// CheckListBox的全选或者全不选
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="checkState">状态：选择、不选择</param>
        private void CheckedAllCheckedBox(CheckedListBox listBox, CheckState checkState)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemCheckState(i, checkState);
            }
        }

        /// <summary>
        /// 获取CheckListBox中被选择的集合
        /// </summary>
        /// <param name="listBox"></param>
        /// <returns></returns>
        private ArrayList GetCheckList(CheckedListBox listBox)
        {
            ArrayList checkList = new ArrayList();
            if (listBox.Enabled)
            {
                foreach (object obj in listBox.CheckedItems)
                {
                    checkList.Add(obj.ToString());
                }
            }
            return checkList;
        }

        /// <summary>
        /// 标本选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSample_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSample.Checked)
            {
                CheckedAllCheckedBox(clbSamples, CheckState.Checked);
                clbSamples.Enabled = false;
            }
            else
            {
                clbSamples.Enabled = true;
                CheckedAllCheckedBox(clbSamples, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// 病区选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArea.Checked)
            {
                CheckedAllCheckedBox(clbPatientArea, CheckState.Checked);
                clbPatientArea.Enabled = false;
            }
            else
            {
                clbPatientArea.Enabled = true;
                CheckedAllCheckedBox(clbPatientArea, CheckState.Unchecked);
            }
        } 
        #endregion
    }
}