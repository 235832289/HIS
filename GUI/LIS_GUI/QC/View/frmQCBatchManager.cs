using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmQCBatchManager : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private clsQCBatch m_objCurrentBatch = new clsQCBatch();

        public frmQCBatchManager()
        {
            InitializeComponent();

            m_objCurrentBatch.LoadFailed += new clsQCBatch.DataLoadFailedEventHandler(m_objCurrentBatch_LoadFailed);
            m_objCurrentBatch.SetChanged += new EventHandler(m_objCurrentBatch_SetChanged);
            this.m_ctlQCBatchReportEditor.QCBatch = m_objCurrentBatch;
            m_ctlDataEditor.ObjBatch = this.m_objCurrentBatch;
            m_ctlChart.ObjBatch = this.m_objCurrentBatch;
        }

        #region 主体数据模型 m_objCurrentBatch
        void m_objCurrentBatch_SetChanged(object sender, EventArgs e)
        {
            if (this.m_lsvQCBatch.SelectedItems.Count > 0)
            {
                this.m_mthListViewItemChange(this.m_objCurrentBatch.GetQCBatchSet(), this.m_lsvQCBatch.SelectedItems[0]);
            }
        }

        void m_objCurrentBatch_LoadFailed(object sender, clsQCBatch.DataLoadFailedEventArgs e)
        {
            MessageBox.Show(e.FailedMessage,"iCare");
        }
        #endregion

        #region lsvQCBatch 的 item
        private void m_mthListViewItemInit(clsLisQCBatchVO var, ListViewItem item)
        {
            if (item == null || var == null)
                return;
            item.Text = var.m_strSampleLotNo;
            item.SubItems.Add(var.m_strCheckItemName);
            item.SubItems.Add(var.m_strDeviceName);
            item.SubItems.Add(var.m_strWorkGroupName);
            item.SubItems.Add(DBAssist.ToString(var.m_dtBegin,"yyyy-MM-dd"));
            item.SubItems.Add(DBAssist.ToString(var.m_dtEnd,"yyyy-MM-dd"));
            item.SubItems.Add(DBAssist.ToString(var.m_intSeq));
            item.Tag = var.m_intSeq;
        }
        private void m_mthListViewItemChange(clsLisQCBatchVO var, ListViewItem item)
        {
            if (item == null || var == null)
                return;
            item.Text = var.m_strSampleLotNo;
            item.SubItems[1].Text = var.m_strCheckItemName;
            item.SubItems[2].Text = var.m_strDeviceName;
            item.SubItems[3].Text = var.m_strWorkGroupName;
            item.SubItems[4].Text = DBAssist.ToString(var.m_dtBegin,"yyyy-MM-dd");
            item.SubItems[5].Text = DBAssist.ToString(var.m_dtEnd,"yyyy-MM-dd");
            item.SubItems[6].Text = DBAssist.ToString (var.m_intSeq);
            item.Tag = var.m_intSeq;
        }

        #endregion

        #region 查询
        private void m_ctlQCBatchQuery_QuerySucceed(object sender, ctlQCBatchQuery.QuerySucceedEventArgs e)
        {
            if (this.m_rdbReplace.Checked)
            {
                this.m_lsvQCBatch.Items.Clear();
            }
            this.m_lsvQCBatch.BeginUpdate();
            foreach (clsLisQCBatchVO var in e.Result)
            {
                ListViewItem item = new ListViewItem();
                m_mthListViewItemInit(var, item);
                this.m_lsvQCBatch.Items.Add(item);
            }
            this.m_lsvQCBatch.EndUpdate();
            this.m_tabList.SelectedTab = this.m_tabList.TabPages[0];
        }

        #endregion

        #region 质控批主体操作
        private void m_cmdNewQCBatch_Click(object sender, EventArgs e)
        {
            frmQCBatchSet frm = new frmQCBatchSet();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem();
                m_mthListViewItemInit(frm.QCBatchVO,item);
                this.m_lsvQCBatch.Items.Add(item);
                this.m_lsvQCBatch.Focus();
                item.Selected = true;
            }
        }

        private void m_cmdQCBatchSet_Click(object sender, EventArgs e)
        {
            if (this.m_objCurrentBatch.IsNull)
                return;
            frmQCBatchSet frm = new frmQCBatchSet();
            frm.QCBatchVO = this.m_objCurrentBatch.GetQCBatchSet();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.m_objCurrentBatch.UpdateSet(frm.QCBatchVO);
            }
        }

        private void m_cmdConcentrationSet_Click(object sender, EventArgs e)
        {
            if (this.m_objCurrentBatch.IsNull)
                return;
            List<clsLisQCConcentrationVO> objs = this.m_objCurrentBatch.GetConcentrations();
            int intSeq = this.m_objCurrentBatch.Seq;

            frmQCBatchConcentrationSet frm = new frmQCBatchConcentrationSet(intSeq, objs.ToArray());
            if (frm.ShowDialog() == DialogResult.OK)
                this.m_objCurrentBatch.UpdateConcentrations(frm.QCContrations);

        }

        private void m_cmdDeleteQCBatch_Click(object sender, EventArgs e)
        {
            if (this.m_objCurrentBatch.IsNull)
                return;

            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdDeleteQCBatch.Enabled = false;

            clsLisQCBatchVO obj = this.m_objCurrentBatch.GetQCBatchSet();
            obj.m_enmStatus = enmQCStatus.Delete;
            long lngRes = clsTmdQCBatchSmp.s_object.m_lngUpdate(obj);
            if (lngRes > 0)
            {
                int intCurrItemIdx = this.m_lsvQCBatch.SelectedIndices[0];
                this.m_lsvQCBatch.SelectedItems[0].Remove();

                int next = -1;
                if (this.m_lsvQCBatch.Items.Count > intCurrItemIdx)
                    next = intCurrItemIdx;
                else if (this.m_lsvQCBatch.Items.Count == intCurrItemIdx && intCurrItemIdx > 0)
                    next = intCurrItemIdx - 1;

                if (next != -1)
                {
                    this.m_lsvQCBatch.Focus();
                    this.m_lsvQCBatch.Items[next].Selected = true;
                }
                else
                {
                    this.m_objCurrentBatch.Reset();
                }
            }
            else
            {
                clsCommonDialog.m_mthShowDBError();
            }

            Cursor.Current = Cursors.Default;
            this.m_cmdDeleteQCBatch.Enabled = true;
        }

        private void m_lsvQCBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.m_lsvQCBatch.SelectedItems.Count > 0)
            {
                int intSeq = (int)this.m_lsvQCBatch.SelectedItems[0].Tag;
                this.m_objCurrentBatch.Reset();
                this.m_objCurrentBatch.Load(intSeq, this.m_ctlDateSelector.DateStart, this.m_ctlDateSelector.DateEnd);
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion
        
        private void m_ctlDateSelector_ValueChanged(object sender, EventArgs e)
        {
            this.m_objCurrentBatch.Reload(this.m_ctlDateSelector.DateStart, this.m_ctlDateSelector.DateEnd);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}