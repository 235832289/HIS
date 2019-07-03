using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 质控报告管理
    /// </summary>
    public partial class ctlQCBatchReportEditorNew : UserControl
    {
        private clsQCBatchNew m_objQCBatch;

        internal clsQCBatchNew QCBatch
        {
            set
            {
                if (value != null)
                {
                    m_objQCBatch = value;
                    if (this.Created)
                    {
                        m_mthInitList();
                    }
                    m_objQCBatch.Loaded += new EventHandler(m_objQCBatch_DataLoaded);
                    m_objQCBatch.Reloaded += new EventHandler(m_objQCBatch_Reloaded);
                }
                else
                {
                    throw new System.ArgumentNullException();
                }
            }
        }

        void m_objQCBatch_Reloaded(object sender, EventArgs e)
        {
            if (this.Created)
            {
                m_mthInitList();
            }
        }

        public ctlQCBatchReportEditorNew()
        {
            InitializeComponent();
        }

        void m_objQCBatch_DataLoaded(object sender, EventArgs e)
        {
            if (this.Created)
            {
                m_mthInitList();
            }
        }

        protected override void OnCreateControl()
        {
            m_mthInitList();
        }
        
        private void m_mthInitList()
        {
            if (m_objQCBatch == null || m_objQCBatch.Count != 1)
                return;

            this.m_lsvReport.BeginUpdate();
            this.m_lsvReport.Items.Clear();
            try
            {
                List<clsLisQCReportVO> reports = this.m_objQCBatch.GetReports();
                if (reports != null)
                {
                    foreach (clsLisQCReportVO var in reports)
                    {
                        ListViewItem item = new ListViewItem();
                        m_mthListViewItemInit(var, item);
                        this.m_lsvReport.Items.Add(item);
                    }
                }
            }
            catch { }
            finally
            {
                this.m_lsvReport.EndUpdate();
            }
        }
        private void m_mthListViewItemInit(clsLisQCReportVO p_objReportVO, ListViewItem item)
        {
            item.Text = DBAssist.ToString(p_objReportVO.m_dtReport,"yyyy-MM-dd");
            if (p_objReportVO.m_enmQCControlStatus == enmQCControlStatus.Control)
            {
                item.SubItems.Add("");
            }
            else
            {
                item.SubItems.Add("▲");
            }
            item.SubItems.Add(p_objReportVO.m_strUnmatchedRule);
            item.SubItems.Add(p_objReportVO.m_strReportorName);
            item.Tag = p_objReportVO;
        }
        private void m_mthListViewItemChange(clsLisQCReportVO p_objReportVO, ListViewItem item)
        {
            item.Text = DBAssist.ToString(p_objReportVO.m_dtReport,"yyyy-MM-dd");
            if (p_objReportVO.m_enmQCControlStatus == enmQCControlStatus.Control)
            {
                item.SubItems[1].Text = "";
            }
            else
            {
                item.SubItems[1].Text = "▲";
            }
            item.SubItems[2].Text = p_objReportVO.m_strUnmatchedRule;
            item.SubItems[3].Text = p_objReportVO.m_strReportorName;
            item.Tag = p_objReportVO;
        }

        private void m_cmdNew_Click(object sender, EventArgs e)
        {
            if (m_objQCBatch == null || m_objQCBatch.Count != 1)
                return;

            m_cmdNew.Enabled = false;

            frmQCReport frm = new frmQCReport(m_objQCBatch.SeqArr[0]);
            frm.BrokenRules = m_objQCBatch.BrokenRules;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                clsLisQCReportVO var = frm.Report;
                this.m_objQCBatch.GetReports().Add(var) ;
                ListViewItem item = new ListViewItem();
                this.m_mthListViewItemInit(var, item);
                this.m_lsvReport.Items.Add(item);
                this.m_lsvReport.Focus();
                item.Selected = true;
            }

            m_cmdNew.Enabled = true;
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {

            if (this.m_lsvReport.SelectedItems.Count <= 0)
                return;

            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdDelete.Enabled = false;

            ListViewItem item = this.m_lsvReport.SelectedItems[0];
            clsLisQCReportVO obj = item.Tag as clsLisQCReportVO;
            obj.m_enmStatus = enmQCStatus.Delete;

            long lngRes = clsTmdQCReportSmp.s_object.m_lngUpdate(obj);

            if (lngRes > 0)
            {
                this.m_objQCBatch.GetReports().Remove(obj);

                int intCurrItemIdx = item.Index;
                item.Remove();

                int next = -1;
                if (this.m_lsvReport.Items.Count > intCurrItemIdx)
                    next = intCurrItemIdx;
                else if (this.m_lsvReport.Items.Count == intCurrItemIdx && intCurrItemIdx > 0)
                    next = intCurrItemIdx - 1;

                if (next != -1)
                {
                    this.m_lsvReport.Focus();
                    this.m_lsvReport.Items[next].Selected = true;
                }
                else
                {
                    
                }
            }
            else
            {
                obj.m_enmStatus = enmQCStatus.Natrural;
                clsCommonDialog.m_mthShowDBError();
            }

            Cursor.Current = Cursors.Default;
            this.m_cmdDelete.Enabled = true;
        }

        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            if (this.m_lsvReport.SelectedItems.Count > 0)
            {
                ListViewItem item = this.m_lsvReport.SelectedItems[0];
                clsLisQCReportVO temp = new clsLisQCReportVO();
                clsLisQCReportVO curr = item.Tag as clsLisQCReportVO;
                curr.m_mthCopyTo(temp);
                frmQCReport frm = new frmQCReport(temp);
                frm.BrokenRules = this.m_objQCBatch.BrokenRules;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    clsLisQCReportVO var = frm.Report;
                    var.m_mthCopyTo(curr);
                    this.m_mthListViewItemChange(curr, item);
                }
            }
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            if (this.m_lsvReport.SelectedItems.Count <= 0)
                return;
            ListViewItem item = this.m_lsvReport.SelectedItems[0];
            clsLisQCReportVO obj = item.Tag as clsLisQCReportVO;

            clsQCDailyReportToolStrategy print = new clsQCDailyReportToolStrategy(obj,this.m_objQCBatch.GetQCBatchSet()[0]);
            print.m_mthPrintPreview();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.m_lsvReport.SelectedItems.Count <= 0)
                return;
            ListViewItem item = this.m_lsvReport.SelectedItems[0];
            clsLisQCReportVO obj = item.Tag as clsLisQCReportVO;

            clsQCDailyReportToolStrategy print = new clsQCDailyReportToolStrategy(obj, this.m_objQCBatch.GetQCBatchSet()[0]);
            print.m_mthPrint();
        }

        private void m_lsvReport_ItemActivate(object sender, EventArgs e)
        {
            this.m_cmdModify_Click(this.m_lsvReport, null);
        }
    }
}
