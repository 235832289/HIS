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
    public partial class frmOrderNurseConfirm : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {        

        public frmOrderNurseConfirm()
        {
            InitializeComponent();
            
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderNurseConfirm();
            objController.Set_GUI_Apperance(this);
        }

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
            ((clsCtl_OrderNurseConfirm)this.objController).m_txtAreaInitListView(lvwList);		
		}

		private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
            ((clsCtl_OrderNurseConfirm)this.objController).m_txtAreaFindItem(strFindCode, lvwList);	
		}

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            
            ((clsCtl_OrderNurseConfirm)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion

        private void frmOrderNurseConfirm_Load(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).SetSPECORDERCATE();  
            ((clsCtl_OrderNurseConfirm)this.objController).LoadTheOrderCate();
            ((clsCtl_OrderNurseConfirm)this.objController).GetTheControl();
            ((clsCtl_OrderNurseConfirm)this.objController).IniTheForm();
            
            //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(CheckTheChanged));
            //thread.IsBackground = true;
            //thread.Start();

            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void m_dtvOrderList_CurrentCellChanged(object sender, EventArgs e)
        {
            
            ((clsCtl_OrderNurseConfirm)this.objController).OrderListSelect();
        }

        private void m_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).SelectAll();
        }

        private void m_rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdoAll.Checked)
            {
                ((clsCtl_OrderNurseConfirm)this.objController).LoadTheDate();
                
            }
        }

        private void m_rdoNOT_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdoNOT.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_OrderNurseConfirm)this.objController).LoadTheDate();
                this.Cursor = Cursors.Default;
            }
        }

        private void m_rdoYET_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdoYET.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_OrderNurseConfirm)this.objController).LoadTheDate();
                this.Cursor = Cursors.Default;
            }
        }

        private void m_dtvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //((clsCtl_OrderNurseConfirm)this.objController).ChangeTheSelectState(e.RowIndex);
            string m_strCumnName = this.m_dtvOrderList.Columns[e.ColumnIndex].Name;
            if (m_strCumnName.Equals("dtv_ENTRUST"))
            {
                DataGridViewCell cell1 = this.m_dtvOrderList[e.ColumnIndex, e.RowIndex];
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_dtvOrderList.Rows[e.RowIndex].Tag;
                //是否为子医嘱
                bool m_blSon=false;
                ((clsCtl_OrderNurseConfirm)this.objController).m_TestORDERIDIsSon(order,out m_blSon);
                if (m_blSon == true)
                {
                    MessageBox.Show("请单独选择父医嘱进行嘱托修改操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*<==================================*/
                if (order.m_intStatus == 1)
                {
                    cell1.ReadOnly = false;
                }
            }
            else if (m_strCumnName.Equals("ATTACHTIMES_INT"))
            {
                DataGridViewCell cell1 = this.m_dtvOrderList[e.ColumnIndex, e.RowIndex];
                clsBIHCanExecOrder order = (clsBIHCanExecOrder)this.m_dtvOrderList.Rows[e.RowIndex].Tag;
                //是否为子医嘱
                bool m_blSon = false;
                ((clsCtl_OrderNurseConfirm)this.objController).m_TestORDERIDIsSon(order, out m_blSon);
                //医嘱类型
                clsT_aid_bih_ordercate_VO p_objItem = null;
                if (((clsCtl_OrderNurseConfirm)this.objController).m_htOrderCate.Contains(order.m_strOrderDicCateID))
                {
                    p_objItem = (clsT_aid_bih_ordercate_VO)((clsCtl_OrderNurseConfirm)this.objController).m_htOrderCate[order.m_strOrderDicCateID];
                }
                if (p_objItem != null)
                {
                    if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1 )//末执行及首次执行的才显示补次及补次的合计量


                    {
                      
                    }
                    else
                    {
                        MessageBox.Show("当前医嘱类型为非补次类型!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("当前医嘱类型为非补次类型!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    return;
                }
                if (m_blSon == true||order.m_intExecuteType!=1)
                {
                    if (m_blSon == true)
                    {
                        MessageBox.Show("请单独选择长嘱的父医嘱进行补次操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (order.m_intExecuteType != 1)
                    {
                        MessageBox.Show("非长期医嘱不能进行补次操作!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    }

                    return;
                }
                /*<==================================*/
                if (order.m_intStatus == 1)
                {
                    cell1.ReadOnly = false;
                }
            }
            
        }

        private void m_cmdToCommit_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            if (((clsCtl_OrderNurseConfirm)this.objController).SelectTheOrderFromPerson() == false)
            {
                return;
            }
            else
            {
                ((clsCtl_OrderNurseConfirm)this.objController).UpdateBihOrderConfirmer();
            }

            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void m_cmdRedraw_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            if (((clsCtl_OrderNurseConfirm)this.objController).SelectTheOrderFromPerson() == false)
            {
                return;
            }
            else
            {
                ((clsCtl_OrderNurseConfirm)this.objController).UpdateBihOrderRedraw();
            }
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void m_cmdBack_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            ((clsCtl_OrderNurseConfirm)this.objController).UpdateBihOrderBack();
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            ((clsCtl_OrderNurseConfirm)this.objController).AddNewChargeItem();
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            ((clsCtl_OrderNurseConfirm)this.objController).ChargeItemChanged();
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            ((clsCtl_OrderNurseConfirm)this.objController).DeleItemChanged();
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void m_dtvChangeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_cmdChargeModify.Enabled == true)
            {
                ((clsCtl_OrderNurseConfirm)this.objController).ChargeItemChanged();
            }
        }

        private void m_dtvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ((clsCtl_OrderNurseConfirm)this.objController).ChangeTheSelectState(e.RowIndex);
            }
        }

        public void frmOrderNurseConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            #region 快捷键



            switch (e.KeyCode)
            {
                case Keys.Escape:
                    m_cmdExit_Click(null, null);
                    break;
                case Keys.F1:
                     if (m_cmdToCommit.Enabled == true)
                    {
                        m_cmdToCommit_Click(null, null);
                    }
                    break;
                case Keys.F2:
                    if (m_cmdRedraw.Enabled == true)
                    {
                        m_cmdRedraw_Click(null, null);
                    }
                    break;
                case Keys.F3:
                    m_cmdBack_Click(null, null);
                    break;
                case Keys.F4:
                    cmdRefurbish_Click(null, null);
                    break;
                case Keys.F5:
                    m_cmdEditFeel_Click(null, null);
                    break;
                case Keys.F6:
                    m_cmdToExecute_Click(null, null);
                    break;
                case Keys.F8:
                    m_txtArea_DoubleClick(null, null);
                    break;
                case Keys.F9:
                   
                    ((clsCtl_OrderNurseConfirm)this.objController).m_cmdBedIdKeySelect();
                    break;

            }
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        buttonXP1_Click(null, null);
                        break;
                    case Keys.C:
                        buttonXP2_Click(null, null);
                        break;
                    case Keys.X:
                        buttonXP3_Click(null, null);
                        break;

                }
            }
            #endregion
        }

        private void m_dtvOrderList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //((clsCtl_OrderNurseConfirm)this.objController).LoadTheDate2(e.ColumnIndex);
            
        }

        private void CheckTheChanged(object obj)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).CheckTheChanged();
           
        }

        public void cmdRefurbish_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_OrderNurseConfirm)this.objController).LoadTheDate();
            this.Cursor = Cursors.Default;
            //((clsCtl_OrderNurseConfirm)this.objController).refreshTheDataByBed(true);
            m_chkSelectAll.Checked = true;
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        #region 床位号事件







        private void m_txtBedNo2_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_txtBedNo2FindItem(strFindCode, lvwList);
        }



        private void m_txtBedNo2_m_evtInitListView(ListView lvwList)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_txtBedNo2InitListView(lvwList);


        }

        private void m_txtBedNo2_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_txtBedNo2SelectItem(lviSelected);


        }
        #endregion

        private void m_cboCode_SelectedValueChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_cboCode_SelectedValueChanged();
        }

        private void m_btnBedList_Click(object sender, EventArgs e)
        {
            m_txtBedNo2.Focus();
            m_txtBedNo2_DoubleClick(null, null);
        }
        string oldBedNoValue = "";
        private void m_txtBedNo2_DoubleClick(object sender, EventArgs e)
        {
            oldBedNoValue = m_txtBedNo2.Text;
            m_txtBedNo2.Text = "";
            SendKeys.Send("{ENTER}");
        }
       
        private void m_cmdEditFeel_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            ((clsCtl_OrderNurseConfirm)this.objController).EditFeel();
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

        private void m_cmdPrintFeel_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).PrintFeel();
        }      

        private void m_timerMessage_Tick(object sender, EventArgs e)
        {
            this.m_timerMessage.Stop();
            ((clsCtl_OrderNurseConfirm)this.objController).MessageList();
            this.m_timerMessage.Start();
        }

        private void m_chkNeedFeel_CheckedChanged(object sender, EventArgs e)
        {
            cmdRefurbish_Click(null, null);
        }

        private void m_cmdToExecute_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_cmdTurnToExecute();
          
        }

        private void m_dtvOrderList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string m_strCumnName = this.m_dtvOrderList.Columns[e.ColumnIndex].Name;
            if (m_strCumnName.Equals("dtv_ENTRUST"))
            {
                DataGridViewRow row1 = this.m_dtvOrderList.Rows[e.RowIndex];
                DataGridViewCell cell1 = this.m_dtvOrderList[e.ColumnIndex, e.RowIndex];
                clsBIHCanExecOrder order1 = (clsBIHCanExecOrder)row1.Tag;
                if (cell1.Value != null&&!order1.m_strEntrust.ToString().Equals(cell1.Value.ToString()))
                {
                    order1.m_strEntrust = cell1.Value.ToString();
                    ((clsCtl_OrderNurseConfirm)this.objController).m_SaveTheEntrust(order1);
                    ((clsCtl_OrderNurseConfirm)this.objController).RefreshTheOrderListData(order1);
                }
                cell1.ReadOnly = true;
            }
            else if (m_strCumnName.Equals("ATTACHTIMES_INT"))
            {
                DataGridViewRow row1 = this.m_dtvOrderList.Rows[e.RowIndex];
                DataGridViewCell cell1 = this.m_dtvOrderList[e.ColumnIndex, e.RowIndex];
                clsBIHCanExecOrder order1 = (clsBIHCanExecOrder)row1.Tag;
                int m_intATTACHTIMES_INT = 0;
                try
                {
                    m_intATTACHTIMES_INT = int.Parse(cell1.Value.ToString());
                }
                catch
                {
                    cell1.Value = order1.m_intATTACHTIMES_INT;
                }
                if (cell1.Value != null && !order1.m_intATTACHTIMES_INT.ToString().Equals(cell1.Value.ToString()))
                {
                    order1.m_intATTACHTIMES_INT = m_intATTACHTIMES_INT;
                    ((clsCtl_OrderNurseConfirm)this.objController).m_SaveTheATTACHTIMES_INT(order1);
                    ((clsCtl_OrderNurseConfirm)this.objController).RefreshTheOrderListData(order1);
                   
                }
                cell1.ReadOnly = true;
            }
        }

        private void m_btnPatientCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
            ((clsCtl_OrderNurseConfirm)this.objController).setTheCurrentPatient();
            m_ctlPatient.m_blInputEnable = false;
            m_ctlPatient.m_btnAddBills_Click(null, null);
            ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
        }

       

        private void m_ctMenuList_Opening(object sender, CancelEventArgs e)
        {
            m_ItemRedrawback.Enabled = false;
            m_ItemCommit.Enabled = false;
            //对当前的项目进行选择处理
            if (m_rdoNOT.Checked)
            {
                ((clsCtl_OrderNurseConfirm)this.objController).TheSelectedItemForDrawBack();
                if (((clsCtl_OrderNurseConfirm)this.objController).GetTheCommitSelectItemCount())
                {
                    m_ItemCommit.Enabled = true;
                }
            }
            else if (m_rdoYET.Checked)
            {
                ((clsCtl_OrderNurseConfirm)this.objController).TheSelectedItemForDrawBack();
                if (((clsCtl_OrderNurseConfirm)this.objController).GetTheRedrawSelectItemCount())
                {
                    m_ItemRedrawback.Enabled = true;
                }
            }
            
           
            
           
        }

        private void m_ItemRedrawback_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要撤消审核选中的当前医嘱吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
                ((clsCtl_OrderNurseConfirm)this.objController).ClearTheChecked();
                ((clsCtl_OrderNurseConfirm)this.objController).SelectItemToChecked();
                ((clsCtl_OrderNurseConfirm)this.objController).UpdateBihOrderRedraw();
                ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
            }
        }

        private void m_ItemCommit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要审核转抄选中的当前医嘱吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // 转移焦点,接收datagridview里的值
                this.m_dtvOrderList.EndEdit();
                this.m_dtvChangeList.Focus();
                ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(false);
                ((clsCtl_OrderNurseConfirm)this.objController).ClearTheChecked();
                ((clsCtl_OrderNurseConfirm)this.objController).SelectItemToChecked();
                ((clsCtl_OrderNurseConfirm)this.objController).UpdateBihOrderConfirmer();
               
                ((clsCtl_OrderNurseConfirm)this.objController).m_mthReSetTimer(((clsCtl_OrderNurseConfirm)this.objController).m_blNeedMessageAlert);
            }
            
        }

        private void m_txtArea_DoubleClick(object sender, EventArgs e)
        {
            m_txtArea.Text = "";
            m_txtArea.Focus();
            SendKeys.Send("{ENTER}");
        }




       

      
      
       

      
       

      
       
    }
}