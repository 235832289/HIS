using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmOrderExecedPatientList : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmOrderExecedPatientList()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderExecedPatientList();
            objController.Set_GUI_Apperance(this);
        }

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_OrderExecedPatientList)this.objController).m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_OrderExecedPatientList)this.objController).m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            ((clsCtl_OrderExecedPatientList)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion

        public void m_cmdToCommit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_OrderExecedPatientList)this.objController).sendTheBill();
            this.Cursor = Cursors.Default;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 批量执行发送(医嘱执行界面调用）
        /// </summary>
        public void sendTheAllBill()
        {
            ((clsCtl_OrderExecedPatientList)this.objController).sendTheAllBill();
        }
        private void buttonXP2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        public void frmOrderExecedPatientList_Load(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecedPatientList)this.objController).IniTheForm();
        }

        private void m_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecedPatientList)this.objController).SelectAll();
        }

        private void m_dtvPersonList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void m_dtvPersonList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtl_OrderExecedPatientList)this.objController).ChangeTheSelectState(e.RowIndex,e.ColumnIndex);
     
        }
    }
}