using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmOrderExecute : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// 病区ID－进出转调用本界面


        internal bool blnFormLoad = true;
        

        /// </summary>
        public string m_strAreaId = "";
        /// <summary>
        /// 病区名称－进出转调用本界面




        /// </summary>
        public string m_strAreaName = "";
        /// <summary>
        /// 病床ID－进出转调用本界面




        /// </summary>
        public string m_strBedId = "";
        /// <summary>
        /// 病床名称－进出转调用本界面




        /// </summary>
        public string m_strBedName = "";
        /// <summary>
        /// 欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额



        /// <summary>
        /// 提交是否需要审核


        /// </summary>
        public bool m_blNeedComfirm = false;
        /// <summary>
        /// 执行是否需要审核


        /// </summary>
        public bool m_blExeConfirm = false;
        /// <summary>
        /// '1038', '住院转抄界面是否显示审核提醒', '0-否；1-是'
        /// </summary>
        public bool m_blNeedMessageAlert = false;
        /// <summary>
        /// '1039', '住院转抄界面审核提醒显示间隔时间', '单位:秒', 10,
        /// </summary>
        public int m_intMessageOpenTime = 0;
        /// <summary>
        /// '1040', '住院转抄界面审核提醒窗体显示停留时间', '单位:秒', 5, 
        /// </summary>
        public int m_intMessageCloseTime = 0;
        /// <summary>
        /// 1018欠费病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额


        /// </summary>
        
        /// </summary>
        public decimal m_dmlMedOCMin=0;
        /// <summary>
        /// 欠费病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额




        /// </summary>
        public decimal m_dmlNoMedOCMin=0;
        /// <summary>
        /// 普通病人药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额




        /// </summary>
        public decimal m_dmlMedICMin=0;
        /// <summary>
        /// 普通病人非药品项目确认最小金额限制 0-代表不控制，大于0所代表控制的限额



        /// </summary>
        public decimal m_dmlNoMedICMin = 0;
        /// <summary>
        /// '1030', '控制护士执行模块是否允许欠费病人执行医嘱', '0-不允许(false) 1-允许(true)
        /// </summary>
        public bool m_blMoneyControl = false;
        /// <summary>
        /// '1046', '允许欠费执行时且病人将欠费时的病人费用提示开关', '0-不提示 1-提示'
        /// </summary>
        public bool m_blLessExecuteAlert = false;
        /// <summary>
        /// '1047', '医嘱执行界面是否允许自行选择医嘱执行开关', '0-不允许 1-允许'
        /// </summary>
        public bool m_blCanSelectOrder = false;
        /// <summary>
        /// '1049', '控制诊疗项目对应关联收费项目（一对多）是否摆药',  '0-不摆药 1-摆药' 
        /// </summary>
        public bool m_blPutMedicineFormDic = false;
       
        /// <summary>
        /// "4006"设置为8，则组合中检验（发票分类为检验）收费项目>8个时启用打折功能
        /// </summary>
        public int m_intLisDiscountNum = 0;
        /// <summary>
        /// 4007设置启用打折功能时，检验收费项目的打折比例。80，则打八折
        /// </summary>
        public decimal m_decLisDiscountMount = 100;
        /// <summary>
        /// 4008  0-false不打折 1-true 允许打折
        /// </summary>
        public bool m_blLisDiscount = false;
        /// <summary>
        /// 医嘱录入是否可以录入已停用的收费项目 0-否,1-是 1037
        /// </summary>
        public bool m_blStopControl = false;
        /// <summary>
        /// 医嘱录入是否可以录入缺药的收费项目 0-否，1-是 1036
        /// </summary>
        public bool m_blDeableMedControl = false;
        /// <summary>
        ///'1053', '住院医嘱录入界面是否自动提示当前病人存在停用或缺药的未停医嘱', '0-否；1-是', 1, '0010' 
        /// </summary>
        public bool m_blAutoStopAlert = false;
        /// <summary>
        /// 查开关是否已读出(由转抄界面打开)，false-没有，true-已读
        /// </summary>
        private bool m_blControl = false;

        /// <summary>
        /// 发送检验医嘱开关， false=执行时发送， true=提交时发送
        /// '1050' 检验医嘱在执行还是在提交时发送检验申请单；  0-执行时发送 1-提交时发送
        /// 2010/8/26 shichun.chen
        /// </summary>
        internal bool m_blSendLisBill = false;

        //2010/8/20
        //private frmOrderExecute objOrderExecute;

        public frmOrderExecute()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 进出转调用本界面-根据病区ID
        /// </summary>
        /// <param name="m_strAreaId_chr">病区ID</param>
        /// <param name="m_strAreaName">病区名称</param>
        public frmOrderExecute(string m_strAreaId_chr, string m_strAreaName)
        {
            InitializeComponent();
        }
        /// <summary>
        /// 进出转调用本界面-根据病区ID,病床ID
        /// </summary>
        /// <param name="m_strAreaId_chr">病区ID</param>
        /// <param name="m_strAreaName_chr">病区名称</param>
        /// <param name="m_strBedId_chr">病床ID</param>
        /// <param name="m_strBedName_chr">病床名称</param>
        public frmOrderExecute(string m_strAreaId_chr,string m_strAreaName_chr,string m_strBedId_chr,string m_strBedName_chr)
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 执行界面调出
        /// </summary>
        /// <param name="m_objSpecateVo">住院基本配置表VO</param>
        /// <param name="m_htOrderCate">医嘱类型列表</param>
        public frmOrderExecute(clsSPECORDERCATE m_objSpecateVo, Hashtable m_htOrderCate,bool Control)
        {
            InitializeComponent();
            ((clsCtl_OrderExecute)this.objController).m_objSpecateVo = m_objSpecateVo;
            ((clsCtl_OrderExecute)this.objController).m_htOrderCate = m_htOrderCate;
             m_blControl = Control;
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderExecute();
            objController.Set_GUI_Apperance(this);
        }

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_OrderExecute)this.objController).m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_OrderExecute)this.objController).m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            ((clsCtl_OrderExecute)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion

        private void m_cmdSendOrder_Click(object sender, EventArgs e)
        {
            frmOrderExecedPatientList objForm = new frmOrderExecedPatientList();
            objForm.m_txtArea.Tag = this.m_txtArea.Tag;
            objForm.m_txtArea.Text = this.m_txtArea.Text;
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                cmdRefurbish_Click(null, null);
            }
        }

        private void m_cmdAreaPutStatus_Click(object sender, EventArgs e)
        {
            bool m_blTest=true;
            if(m_txtArea.Tag==null)
            {
                
                m_blTest=false;;
            }
            else if(((string)m_txtArea.Tag).Equals(""))
            {
                m_blTest=false;
            }
            if(!m_blTest)
            {
                 MessageBox.Show("病区必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtArea.Focus();
            }
           
            frmAreaPutMedList objForm = new frmAreaPutMedList((string)m_txtArea.Tag);
            objForm.Show();
        }

        private void frmOrderExecute_Load(object sender, EventArgs e)
        {
            this.blnFormLoad = true;
            if (((clsCtl_OrderExecute)this.objController).m_objSpecateVo == null)
            {
                ((clsCtl_OrderExecute)this.objController).SetSPECORDERCATE();
            }
            if (((clsCtl_OrderExecute)this.objController).m_htOrderCate.Count <= 0)
            {
                ((clsCtl_OrderExecute)this.objController).LoadTheOrderCate();
            }
            ((clsCtl_OrderExecute)this.objController).LoadThePARMVALUE();
            if (m_blControl == false)
            {
                ((clsCtl_OrderExecute)this.objController).GetTheControl();
            }
            
            ((clsCtl_OrderExecute)this.objController).IniTheForm();
            this.blnFormLoad = false;
        }

        internal void CheckBoxView()
        {
            m_chkLong.Checked = true;
            m_chkOut.Checked = true;
            m_chkShort.Checked = true;
        }

        private void m_dtvOrderList_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).OrderListSelect();
        }

        private void m_dtvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //((clsCtl_OrderExecute)this.objController).ChangeTheSelectState(e.RowIndex);
        }

        private void m_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).SelectAll();
        }

        private void m_rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdoAll.Checked)
            {
                //if (m_cboCode.SelectedIndex == 0)
                //{
                //    ((clsCtl_OrderExecute)this.objController).LoadTheDate();
                //}
                //else
                //{
                //    ((clsCtl_OrderExecute)this.objController).LoadTheDate2();
                //}
                ((clsCtl_OrderExecute)this.objController).LoadTheDate();
            }
        }

        private void m_rdoNOT_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdoNOT.Checked)
            {
                //if (m_cboCode.SelectedIndex == 0)
                //{
                //    ((clsCtl_OrderExecute)this.objController).LoadTheDate();
                //}
                //else
                //{
                //    ((clsCtl_OrderExecute)this.objController).LoadTheDate2();
                //}
                ((clsCtl_OrderExecute)this.objController).LoadTheDate();
            }
        }

        private void m_rdoYET_CheckedChanged(object sender, EventArgs e)
        {

            if (m_rdoYET.Checked)
                {
                    //if (m_cboCode.SelectedIndex == 0)
                    //{
                    //    ((clsCtl_OrderExecute)this.objController).LoadTheDate();
                    //}
                    //else
                    //{
                    //    ((clsCtl_OrderExecute)this.objController).LoadTheDate2();
                    //}
                    ((clsCtl_OrderExecute)this.objController).LoadTheDate();

                }
        }

        #region 床位号事件






        private void m_txtBedNo2_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            ((clsCtl_OrderExecute)this.objController).m_txtBedNo2FindItem(strFindCode, lvwList);
        }



        private void m_txtBedNo2_m_evtInitListView(ListView lvwList)
        {
            ((clsCtl_OrderExecute)this.objController).m_txtBedNo2InitListView(lvwList);
           
            
        }

        private void m_txtBedNo2_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            ((clsCtl_OrderExecute)this.objController).m_txtBedNo2SelectItem(lviSelected);
           

        }
        #endregion

        private void m_txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                m_cboCode.Focus();
            }
        }

        private void m_cboCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                if (m_cboCode.SelectedIndex == 1)
                {
                    m_txtBedNo2.Focus();
                }
            }
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

        private void m_cmdToCommit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认执行当前选中的医嘱吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                if (((clsCtl_OrderExecute)this.objController).UpdateBihOrderConfirmer() == true)
                {                    
                    cmdRefurbish_Click(null, null);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).AddNewChargeItem();
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).ChargeItemChanged();
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).DeleItemChanged();
        }

        private void m_dtvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ((clsCtl_OrderExecute)this.objController).ChangeTheSelectState(e.RowIndex);
            }
        }

        private void m_dtvChangeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //((clsCtl_OrderExecute)this.objController).ChargeItemChanged();
        }

        public void cmdRefurbish_Click(object sender, EventArgs e)
        {
            //if (m_cboCode.SelectedIndex == 0)
            //{
            //    ((clsCtl_OrderExecute)this.objController).LoadTheDate();
            //}
            //else
            //{
            //    ((clsCtl_OrderExecute)this.objController).LoadTheDate2();
            //}
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_OrderExecute)this.objController).LoadTheDate();
            this.Cursor = Cursors.Default;
        }

        private void frmOrderExecute_KeyDown(object sender, KeyEventArgs e)
        {
            #region 快捷键




            switch (e.KeyCode)
            {
                case Keys.Escape:
                    m_cmdCancel_Click(null, null);
                    break;
                case Keys.F1:
                    if (m_cmdToCommit.Enabled == true)
                    {
                        m_cmdToCommit_Click(null, null);
                    }
                    break;
                case Keys.F2:
                    m_cmdToCommitAll_Click(null, null);
                    break;
                case Keys.F3:
                    //m_cmdToRedraw_Click(null, null);
                    m_cmdSendOrder_Click(null, null);
                    break;
                case Keys.F4:
                    cmdRefurbish_Click(null, null);
                    break;
                case Keys.F5:
                    m_cmdSendOrder_Click(null, null);
                    break;
               case Keys.F8:
                    m_txtArea_DoubleClick(null, null);
                    break;
                case Keys.F9:
                    ((clsCtl_OrderExecute)this.objController).m_cmdBedIdKeySelect();
                    break;  

            }
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    //case Keys.Z:
                    //    buttonXP1_Click(null, null);
                    //    break;
                    //case Keys.C:
                    //    buttonXP2_Click(null, null);
                    //    break;
                    //case Keys.X:
                    //    buttonXP3_Click(null, null);
                    //    break;
                    case Keys.S:
                        m_cmdAreaPutStatus_Click(null, null);
                        break;

                }
            }
            #endregion
        }

        private void m_cmdToRedraw_Click(object sender, EventArgs e)
        {
            if (((clsCtl_OrderExecute)this.objController).SelectTheRedrawOrderFromPerson() == false)
            {
                return;
            }
            //((clsCtl_OrderExecute)this.objController).UpdateBihOrderConfirmer();
            ((clsCtl_OrderExecute)this.objController).Redraw();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).DoWork();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).RunWorkerCompleted();
        }

     
        private void m_cboCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!((clsCtl_OrderExecute)this.objController).m_blFirstLoad)
            {
                ((clsCtl_OrderExecute)this.objController).RefreshHadDate();
            }
        }

        private void m_cmdToCommitAll_Click(object sender, EventArgs e)
        {          
            if (((clsCtl_OrderExecute)this.objController).SelectTheOrderFromPerson() == true)
            {
                UpdateBihOrderConfirmerAndSend();
            }
        }

        private void UpdateBihOrderConfirmerAndSend()
        {
            if (!(m_txtArea.Tag is string))
            {
                MessageBox.Show("请先选定科室!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtArea.Focus();
                return;
            }
            if (((string)m_txtArea.Tag).Trim().Equals(""))
            {
                MessageBox.Show("请先选定科室!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtArea.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            com.digitalwave.iCare.BIHOrder.frmExecuteOrdersProgress objFrmExecuteOrdersProgress = new frmExecuteOrdersProgress();
            ((clsCtl_OrderExecute)this.objController).objFrmExecuteOrdersProgress = objFrmExecuteOrdersProgress;

            bool m_blComfirm=((clsCtl_OrderExecute)this.objController).UpdateBihOrderConfirmer();
            objFrmExecuteOrdersProgress.Close();
            if (m_blComfirm == true)
            {
                MessageBox.Show("执行成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (m_txtArea.Tag == null||this.m_dtvOrderList.RowCount>0)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (this.m_dtvOrderList.RowCount == 0)
                {
                    this.m_dtvChangeList.Rows.Clear();
                }
                IPutMadicine madicine;
                madicine = PutMadicineFactory.GetInstance();
                // bool ifAll = madicine.IsAllPatSend((string)m_txtArea.Tag);
                bool ifAll = true;
                long lngRes=((clsCtl_OrderExecute)this.objController).IsAllPatSend((string)m_txtArea.Tag, out ifAll);
                if (lngRes>0&&ifAll)
                {
                    if (((clsCtl_OrderExecute)this.objController).m_blBihOrderCanExecute() == false)
                    {
                        string m_strAreaID = "";
                        if (this.m_txtArea.Tag != null)
                        {
                            m_strAreaID = (string)m_txtArea.Tag;
                        }
                        if (!m_strAreaID.Equals(""))
                        {
                            DataTable m_dtItem = new DataTable();
                            lngRes = ((clsCtl_OrderExecute)this.objController).m_lngFindSendArea(m_strAreaID, out m_dtItem);
                            if (lngRes > 0 && m_dtItem.Rows.Count == 0)
                            {
                                lngRes = madicine.GetAreaComplete(m_strAreaID, out m_dtItem);
                                if (m_dtItem.Rows.Count == 0)
                                {
                                    if (MessageBox.Show("病区病人全部发送完毕，是否置全区摆药标志? ", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {

                                        madicine = PutMadicineFactory.GetInstance();
                                        lngRes = madicine.SetAreaComplete(m_strAreaID, this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName);

                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;            
        }

        private void m_chkReExcute_CheckedChanged(object sender, EventArgs e)
        {
            if (!((clsCtl_OrderExecute)this.objController).m_blFirstLoad)
            {
                ((clsCtl_OrderExecute)this.objController).RefreshHadDate();
            }
           
        }

        private void m_btnPatientCharge_Click(object sender, EventArgs e)
        {
            m_ctlPatient.m_blInputEnable = false;
            m_ctlPatient.m_btnAddBills_Click(null, null);
        }

        private void m_ctMenuList_Opening(object sender, CancelEventArgs e)
        {
            this.m_ItemComfirmRun.Enabled = false;
           //对当前的项目进行选择处理
            if (m_rdoNOT.Checked)
            {
                ((clsCtl_OrderExecute)this.objController).TheSelectedItemForComfirmRun();
                if (((clsCtl_OrderExecute)this.objController).GetTheComfirmRunSelectItemCount())
                {
                    this.m_ItemComfirmRun.Enabled = true;
                }
            }
          
        }

        private void m_ItemComfirmRun_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderExecute)this.objController).ClearTheChecked();
            ((clsCtl_OrderExecute)this.objController).SelectItemToChecked();
            if (((clsCtl_OrderExecute)this.objController).m_blLessMoneyControl() == false)
            {
                return;
            }
            if (MessageBox.Show("确定要执行发选中当前选中的医嘱吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UpdateBihOrderConfirmerAndSend(); 
               
            }
        }

       
        private void m_chkLong_CheckedChanged(object sender, EventArgs e)
        {
            if (!((clsCtl_OrderExecute)this.objController).m_blFirstLoad)
            {
                ((clsCtl_OrderExecute)this.objController).RefreshHadDate();
            }
        }

        private void m_chkShort_CheckedChanged(object sender, EventArgs e)
        {
            if (!((clsCtl_OrderExecute)this.objController).m_blFirstLoad)
            {
                ((clsCtl_OrderExecute)this.objController).RefreshHadDate();
            }
        }

        private void m_chkOut_CheckedChanged(object sender, EventArgs e)
        {
            if (!((clsCtl_OrderExecute)this.objController).m_blFirstLoad)
            {
                ((clsCtl_OrderExecute)this.objController).RefreshHadDate();
            }
        }

        private void m_txtArea_DoubleClick(object sender, EventArgs e)
        {
            m_txtArea.Text = "";
            m_txtArea.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void m_cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!((clsCtl_OrderExecute)this.objController).m_blFirstLoad)
            {
                ((clsCtl_OrderExecute)this.objController).RefreshHadDate();
            }
        }


      
    }
}