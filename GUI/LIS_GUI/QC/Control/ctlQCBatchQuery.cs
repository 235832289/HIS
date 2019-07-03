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
    public partial class ctlQCBatchQuery : UserControl
    {

        public class QuerySucceedEventArgs : System.EventArgs
        {
            private clsLisQCBatchVO[] m_objResult;
            public clsLisQCBatchVO[] Result
            {
                get
                {
                    return m_objResult;
                }
            }
            public QuerySucceedEventArgs(clsLisQCBatchVO[] p_objResult)
            {
                this.m_objResult = p_objResult;
            }
        }
        public delegate void QuerySucceedEventHandler(object sender, QuerySucceedEventArgs e);
        public event QuerySucceedEventHandler QuerySucceed;

        public ctlQCBatchQuery()
        {
            InitializeComponent();
        }

        private void m_cmdCheckItemSelect_Click(object sender, EventArgs e)
        {
            frmCheckItemSelector frm = new frmCheckItemSelector();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.SelectedCheckItem != null)
                {
                    this.m_txtQCCheckItem.Text = frm.SelectedCheckItem.strName;
                    this.m_txtQCCheckItem.Tag = frm.SelectedCheckItem.strID;
                }
            }
        }

        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdQuery.Enabled = false;

            clsLisQCBatchSchVO objSch = new clsLisQCBatchSchVO();

            try { objSch.m_intQCBatchSeq = int.Parse(this.m_txtQCBatchSeq.Text); }
            catch { objSch.m_intQCBatchSeq = -1; }

            objSch.m_intWorkGroupSeq = this.m_cboWorkGroup.Value;

            if (this.m_txtQCCheckItem.Tag != null)
                objSch.m_strQCCheckItem = this.m_txtQCCheckItem.Tag.ToString();

            if (this.m_chkDeviceSeleted.Checked && this.m_cboDevice.SelectedValue != null)
            {
                objSch.m_strQCDevice = this.m_cboDevice.SelectedValue.ToString();
            }

            if (this.m_chkQCDateSelected.Checked)
            {
                string strMM = this.m_dtpQCDate.Value.ToString("yyyy-MM");
                string strMaxDay = DateTime.DaysInMonth(this.m_dtpQCDate.Value.Year, this.m_dtpQCDate.Value.Month).ToString();
                objSch.m_datQueryBegin = DateTime.Parse(strMM + "-01 00:00:00");
                objSch.m_datQueryEnd = DateTime.Parse(strMM + "-" + strMaxDay + " 23:59:59");
            }

            clsLisQCBatchVO[] objRecordArr = null;

            long lngRes = clsSchQCBatchSmp.s_object.m_lngFindQCBatchCombinatorial(objSch, out objRecordArr);

            if (lngRes <= 0)
            {
                clsCommonDialog.m_mthShowDBError();
            }
            else
            {
                if (objRecordArr == null || objRecordArr.Length == 0)
                {
                    clsCommonDialog.m_mthShowNoAccordantResult();
                }
                else
                {
                    m_mthQueryReset();
                    if (this.QuerySucceed != null)
                        QuerySucceed(this, new QuerySucceedEventArgs(objRecordArr));
                }
            }

            this.m_cmdQuery.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_mthQueryReset()
        {
            this.m_txtQCBatchSeq.Clear();
            this.m_cboDevice.Enabled = false;
            this.m_chkDeviceSeleted.Checked = false;
            this.m_cboWorkGroup.Value = -1;
            this.m_txtQCCheckItem.Clear();
            this.m_txtQCCheckItem.Tag = null;
            this.m_dtpQCDate.Enabled = false;
            m_chkQCDateSelected.Checked = true;
        }

        private void m_chkQCDateSelected_CheckedChanged(object sender, EventArgs e)
        {
            this.m_dtpQCDate.Enabled = m_chkQCDateSelected.Checked;
        }

        private void m_chkDeviceSeleted_CheckedChanged(object sender, EventArgs e)
        {
            this.m_cboDevice.Enabled = this.m_chkDeviceSeleted.Checked;
        }

        private void ctlQCBatchQuery_Load(object sender, EventArgs e)
        {
            this.m_dtpQCDate.Value = DateTime.Now;
            m_chkQCDateSelected.Checked = true;
        }
    }
}
