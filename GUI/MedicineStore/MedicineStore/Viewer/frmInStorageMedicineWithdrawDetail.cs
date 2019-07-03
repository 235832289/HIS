using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmInStorageMedicineWithdrawDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        #region 字段
        /// <summary>
        /// 内退主窗体主表
        /// </summary>
        internal DataTable m_dtbMedinineMain = null;

        /// <summary>
        /// 控件跳转时下一个获得焦点的控件
        /// </summary>
        Control m_ctlNext = null;

        /// <summary>
        /// 参与控件跳转的控件
        /// </summary>
        private Control[] m_ctlControls = null;
        /// <summary>
        /// 控件激活标志
        /// </summary>
        private bool m_CtlActivate = false;

        /// <summary>
        /// 入库主表序列号
        /// </summary>
        internal long m_lngMainSEQ = 0;

        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;

        /// <summary>
        /// 是否已审核
        /// </summary>
        internal bool m_blnHasCommit = false;

        /// <summary>
        /// 是否已入帐
        /// </summary>
        internal bool m_blnHasAccount = false;

        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string m_strStoreRoomName = string.Empty;

        /// <summary>
        /// 内退单位ID
        /// </summary>
        string m_strReturnDeptID = string.Empty;
        /// <summary>
        /// 内退单位名称
        /// </summary>
        string m_strReturnDept = string.Empty;

        /// <summary>
        /// 内退明细表
        /// </summary>
        internal DataTable m_dtbDetail = null;

        internal DataTable m_dtbDetailReport = null;
        /// <summary>
        /// 药典数据表
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        ///  药典查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        /// <summary>
        /// 出库单信息窗体

        /// </summary>
        private frmInMedicineCancelCallOutStorageInfo m_frmCallOutStorageInfo = null;
        /// <summary>
        /// 是否有药库管理员权限
        /// </summary>
        //internal bool m_blnIsAdmin = false;

        internal bool m_blnCanModify = true;

        internal readonly int m_intMedicineCodeColIndex = 5;
        internal readonly int m_intAmountColIndex = 9;

        /// <summary>
        /// 保存内退数量
        /// </summary>
        internal double dblNetAmount;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;

        /// <summary>
        /// 药品中的批号,有效期录入控制

        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;


        #endregion 字段

        #region 属性


        public bool CanModify
        {
            get
            {
                return m_blnCanModify;
            }
            set
            {
                m_blnCanModify = value;
            }
        }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string StorageID
        {
            get
            {
                return m_strStorageID;
            }
            set
            {
                m_strStorageID = value;
            }
        }

        /// <summary>
        /// 药库名称
        /// </summary>
        public string StoreRoomName
        {
            get
            {
                return m_strStoreRoomName;
            }
            set
            {
                m_strStoreRoomName = value;
            }
        }

        /// <summary>
        /// 内退部门ID
        /// </summary>
        public string ReturnDeptID
        {
            get
            {
                return m_strReturnDeptID;
            }
            set
            {
                m_strReturnDeptID = value;
            }
        }


        #endregion 属性


        #region 构造函数

        /// <summary>
        /// 构造函数

        /// </summary>
        public frmInStorageMedicineWithdrawDetail()
        {
            InitializeComponent();

            m_dtbDetail = new DataTable();
            DataColumn[] drColumns = new DataColumn[] { 
                new DataColumn("SortNum"),
                new DataColumn("MEDICINEID_CHR",typeof(string)), 
                new DataColumn("ASSISTCODE_CHR",typeof(string)),
                new DataColumn("MEDICINENAME_VCH",typeof(string)), 
                new DataColumn("MEDSPEC_VCHR",typeof(string)), 
                new DataColumn("LOTNO_VCHR",typeof(string)), 
                new DataColumn("AMOUNT",typeof(decimal)),
                new DataColumn("NETAMOUNT_INT",typeof(decimal)),
                new DataColumn("CancelAmount",typeof(decimal)), 
                new DataColumn("AvailAmount",typeof(decimal)),
                new DataColumn("AVAILAGROSS_INT",typeof(decimal)),
                new DataColumn("OPUNIT_CHR",typeof(string)),
                new DataColumn("CALLPRICE_INT",typeof(decimal)), 
                new DataColumn("CallSum",typeof(decimal)), 
                new DataColumn("RETAILPRICE_INT",typeof(decimal)), 
                new DataColumn("RetailSum",typeof(decimal)),
                new DataColumn("WHOLESALEPRICE_INT",typeof(decimal)),
                new DataColumn("INSTORAGEID_VCHR",typeof(string)), 
                new DataColumn("OUTSTORAGEID_VCHR",typeof(string)),
                new DataColumn("PRODUCTORID_CHR",typeof(string)),
                new DataColumn("VALIDPERIOD_DAT",typeof(DateTime)),
                new DataColumn("PACKCONVERT_INT",typeof(decimal)), 
                new DataColumn("PACKAMOUNT",typeof(decimal)), 
                new DataColumn("PACKUNIT_VCHR",typeof(string)), 
                new DataColumn("PACKCALLPRICE_INT", typeof(decimal)),
                new DataColumn("SERIESID_INT",typeof(decimal)),
                new DataColumn("SERIESID2_INT",typeof(decimal)),
                new DataColumn("withdrawsum",typeof(decimal)),
                new DataColumn("RUTURNNUM_INT",typeof(decimal)),
                new DataColumn("medicinetypeid_chr",typeof(string))};

            m_dtbDetail.Columns.AddRange(drColumns);

            m_dtbDetail.AcceptChanges();

            m_dgvMedicineDetail.AutoGenerateColumns = false;
            m_dgvMedicineDetail.DataSource = m_dtbDetail;
            //((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            //参与跳转的控件

            m_ctlControls = new Control[] {
                m_dtpTransactDate,
                m_txtWithdrawDept,
                m_txtRemark};
            //设置控件的Enter事件
            m_mthSetNextControl(ref m_ctlControls);
            //设置活动控件的背景色
            m_mthSetControlHighLight();
            //初始化部门数据


            DataTable dtbDept = null;
            ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetExportDept(out dtbDept);
            m_txtWithdrawDept.m_mthInitDeptData(dtbDept);


            //初始化界面元素和字段
            m_mthInit();

            //zhenwei.yang添加时间
            DateTime dtDate = DateTime.Now;
            m_dtpTransactDate.Text = dtDate.ToString("yyyy年MM月dd日");
            m_dtpTransactDate.Tag = dtDate.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            //获取审核流程
            ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetCommitFlow(out m_intCommitFolow);
            ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);

        }

        /// <summary>
        /// 带参构造函数,新制单时调用
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strWithdrawDept">内退单位ID</param>
        public frmInStorageMedicineWithdrawDetail(string p_strStorageID, string p_strStoreRoomName, ref DataTable p_dtbMedicineInnerWithdraw)
            : this()
        {
            StorageID = p_strStorageID;
            StoreRoomName = p_strStoreRoomName;
            m_dtbMedinineMain = p_dtbMedicineInnerWithdraw;
            //m_strReturnDeptID = p_WithdrawDept;
            if (!string.IsNullOrEmpty(p_strStoreRoomName))
            {
                this.Text += " - " + p_strStoreRoomName;
            }


        }

        /// <summary>
        /// 带参构造函数，修改时调用

        /// </summary>
        /// <param name="p_strReturnDeptID"></param>
        /// <param name="p_strReturnDept"></param>
        /// <param name="p_dtbMedicineDetail"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strStoreRoomName"></param>
        /// <param name="p_objISVO"></param>
        /// <param name="p_objDetailArr"></param>
        /// <param name="p_intSelectedSubRow"></param>
        public frmInStorageMedicineWithdrawDetail(string p_strReturnDeptID,string p_strReturnDept,ref DataTable p_dtbMedicineMain, ref DataTable p_dtbMedicineDetail, string p_strStorageID, string p_strStoreRoomName, clsMS_InStorage_VO p_objISVO, clsMS_InStorageDetail_VO[] p_objDetailArr, int p_intSelectedSubRow)
            : this()
        {
            m_strReturnDeptID = p_strReturnDeptID;
            m_strReturnDept = p_strReturnDept;
            m_txtWithdrawDept.Text = p_strReturnDept;
            m_txtWithdrawDept.Tag = p_strReturnDeptID;

            StorageID = p_strStorageID;
            StoreRoomName = p_strStoreRoomName;

            m_dtbMedinineMain = p_dtbMedicineMain;

            if (!string.IsNullOrEmpty(p_strStoreRoomName))
            {
                this.Text += " - " + p_strStoreRoomName;
            }


            //m_frmCallOutStorageInfo = new frmInMedicineCancelCallOutStorageInfo((clsCtl_InMedicineWithdrawMakerBill)objController, m_strStorageID, m_strStoreRoomName);
            ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthSetMedicineDetailToUI(p_strReturnDept, ref p_dtbMedicineDetail, p_objISVO, p_objDetailArr, p_intSelectedSubRow);
        }
        #endregion 构造函数


        #region 事件

        #region 窗体的Shown事件
        /// <summary>
        /// 窗体的Shown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInStorageMedicineWithdrawDetail_Shown(object sender, EventArgs e)
        {
            long lngRes = 0;
            string strStorageID = string.Empty;
            string strInStorageID = string.Empty;

            if (m_blnHasCommit)
            {
                if (m_intCommitFolow == 1)
                {
                    //检查药品库存

                    lngRes = ((clsCtl_InMedicineWithdrawMakerBill)objController).m_lngCheckMedicineGross();
                    if (lngRes > 0)
                    {
                        m_cmdSave.Enabled = true;
                        m_cmdInsert.Enabled = true;
                        m_cmdDelete.Enabled = true;
                        m_cmdNextBill.Enabled = true;
                        m_cmdOutStorageBill.Enabled = true;
                        panel2.Enabled = true;
                        m_dgvMedicineDetail.ReadOnly = false;
                    }
                    else
                    {
                        m_cmdSave.Enabled = false;
                        m_cmdInsert.Enabled = false;
                        m_cmdDelete.Enabled = false;
                        m_cmdNextBill.Enabled = false;
                        m_cmdOutStorageBill.Enabled = false;
                        panel2.Enabled = false;
                        m_dgvMedicineDetail.ReadOnly = true;
                    }
                }
                else
                {
                    m_cmdSave.Enabled = false;
                    m_cmdInsert.Enabled = false;
                    m_cmdDelete.Enabled = false;
                    m_cmdNextBill.Enabled = false;
                    m_cmdOutStorageBill.Enabled = false;
                    panel2.Enabled = false;
                    m_dgvMedicineDetail.ReadOnly = true;
                }
            }
            else if (m_blnHasAccount)
            {
                m_cmdSave.Enabled = false;
                m_cmdInsert.Enabled = false;
                m_cmdDelete.Enabled = false;
                m_cmdNextBill.Enabled = false;
                m_cmdOutStorageBill.Enabled = false;
                panel2.Enabled = false;
                m_dgvMedicineDetail.ReadOnly = true;
            }
            else
            {
                m_cmdSave.Enabled = true;
                m_cmdInsert.Enabled = true;
                m_cmdDelete.Enabled = true;
                m_cmdNextBill.Enabled = true;
                m_cmdOutStorageBill.Enabled = true;
                panel2.Enabled = true;
                m_dgvMedicineDetail.ReadOnly = false;
            }


            //初始化药品字典

            clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();
            lngRes = objDomain.m_lngGetBaseMedicine("", m_strStorageID, out  m_dtbMedicinDict);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);

            }

            m_ctlQueryMedicint.Visible = false;
            m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_mthReturnInfo);
            m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_mthCanelSelect);
            m_ctlQueryMedicint.BringToFront();

            if (m_lngMainSEQ > 0)
            {
                if ((m_dtbDetail != null) && (m_dtbDetail.Rows.Count > 0))
                {
                    m_dgvMedicineDetail.Focus();
                    //m_dgvMedicineDetail.Rows[0].Cells[11].Selected = true;
                    m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intAmountColIndex, 0];

                }
            }
            else
            {
                m_txtWithdrawDept.Focus();
            }
        }

        #endregion


        /// <summary>
        /// 退出按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 出库单按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdOutStorageBill_Click(object sender, EventArgs e)
        {
            if ((m_txtWithdrawDept.StrItemId.Trim().Length > 0)
                && (m_lngMainSEQ == 0))
            {
                ReturnDeptID = m_txtWithdrawDept.StrItemId;
            }

            if (string.IsNullOrEmpty(StorageID))
            {
                MessageBox.Show("没有选择药库！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ReturnDeptID.Trim().Length == 0)
            {
                MessageBox.Show("请输入内退单位！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtWithdrawDept.Focus();
            }
            else
            {
                frmCallOutStorageBill m_objCallStorageBill = new frmCallOutStorageBill(StorageID, StoreRoomName,
                                                                                       ReturnDeptID,
                                                                                       m_txtWithdrawDept.Text, ref m_dtbDetail);

                DialogResult dlgResult = m_objCallStorageBill.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    //此处出错，因广医三院不用此界面;以后再改 20080117 by shaowei.zheng
                    if (m_dtbDetail.Rows.Count > 0)
                    {
                        m_dgvMedicineDetail.DataSource = m_dtbDetail;
                        DataRow drCurrRow = null;
                        for (int i1 = 0; i1 < m_dgvMedicineDetail.RowCount; i1++)
                        {
                            drCurrRow = m_dtbDetail.Rows[i1];
                            if ((string.IsNullOrEmpty(drCurrRow["MEDICINEID_CHR"].ToString().Trim()))
                                    || (string.IsNullOrEmpty(drCurrRow["OUTSTORAGEID_VCHR"].ToString().Trim())))
                            {
                                m_dtbDetail.Rows.Remove(drCurrRow);
                                break;
                            }
                        }

                        if (m_dtbDetail.Rows.Count > 0)
                        {
                            ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthMakeSn();
                            m_dgvMedicineDetail.Focus();
                            m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intAmountColIndex, m_dgvMedicineDetail.RowCount - 1];
                        }
                        ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAllSubMoney();

                    }//if
                }
            }
        }


        /// <summary>
        /// 删除按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            int iRow = 0;
            m_lblSelectAll.Text = "全选";
            if (m_dtbDetail.Rows.Count > 0)
            {
                for (iRow = 0; iRow < m_dtbDetail.Rows.Count; iRow++)
                {
                    if (Convert.ToBoolean(m_dgvMedicineDetail.Rows[iRow].Cells[0].Value))
                        break;
                }

            }
            if (iRow == m_dtbDetail.Rows.Count)
            {
                MessageBox.Show("请选择要删除的记录！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (m_lngMainSEQ == 0)
            {
                DataRow m_drDataRow = null;

                if (m_dtbDetail.Rows.Count > 0)
                {
                    DialogResult m_dlgResult = MessageBox.Show("是否删除选定记录？", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (m_dlgResult == DialogResult.Yes)
                    {
                        int i1 = 0;
                        int m_intRowIndex = 0;
                        //MessageBox.Show("RowCount:"+m_dtbDetail.Rows.Count.ToString());
                        while (i1 < m_dtbDetail.Rows.Count)
                        {
                            if (Convert.ToBoolean(m_dgvMedicineDetail.Rows[i1].Cells[0].Value))
                            {
                                m_intRowIndex = m_dgvMedicineDetail.Rows[i1].Index;
                                m_drDataRow = m_dtbDetail.Rows[m_intRowIndex];
                                m_drDataRow.Delete();
                                //m_dtbDetail.Rows.Remove(m_drDataRow);
                            }
                            else
                            {
                                i1++;
                            }
                        }//while 
                        //m_dtbDetail.AcceptChanges();
                        ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthMakeSn();
                        //m_dtbDetail.AcceptChanges();

                    }//if (m_dlgResult == DialogResult.Yes)
                }//if (m_dtbDetail.Rows.Count > 0)

            }//if (m_lngMainSEQ == 0)
            else
            {
                //20090721:保存、删除、审核单据时，均判断是否新制状态
                if (m_txtInnerWithdrawBillNo.Text.Length > 0)
                {
                    bool blnNewState = false;
                    clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                    clsDcl.m_lngCheckBillState(1, m_txtInnerWithdrawBillNo.Text.Trim(), out blnNewState);
                    if (!blnNewState)
                    {
                        MessageBox.Show("该内退单不是新制状态，请关闭并刷新后重试", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                DialogResult drResult = MessageBox.Show("是否删除选定记录?", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }

                DataRow drCurrRow = null;
                iRow = 0;
                //int i1 = 0;
                while (iRow < m_dtbDetail.Rows.Count)
                {
                    if (Convert.ToBoolean(m_dgvMedicineDetail.Rows[iRow].Cells[0].Value))
                    {
                        drCurrRow = m_dtbDetail.Rows[iRow];
                        if (drCurrRow.RowState == DataRowState.Added)
                        {
                            drCurrRow.Delete();
                        }
                        else
                        {
                            iRow++;
                        }
                    }
                    else
                    {
                        iRow++;
                    }

                }//while

                ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthDeleteInStorageDetail();

            }
            ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAllSubMoney();
        }

        /// <summary>
        /// 下张单按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdNextBill_Click(object sender, EventArgs e)
        {
            m_lblSelectAll.Text = "全选";
            m_mthInit();
            m_txtWithdrawDept.Focus();
        }

        /// <summary>
        /// 保存按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if((m_dtbDetail != null) && (m_dtbDetail.Rows.Count > 0))
            {
                if ((m_txtWithdrawDept.StrItemId.Trim().Length > 0)
                    && (m_lngMainSEQ == 0))
                {
                    ReturnDeptID = m_txtWithdrawDept.StrItemId;
                }

                if (ReturnDeptID.Trim().Length == 0)
                {
                    MessageBox.Show("请选择内退单位！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_txtWithdrawDept.Focus();
                }
                else
                {
                    DataRow drCurrRow = null;
                    int iRow = 0;
                    while (iRow < m_dtbDetail.Rows.Count)
                    {
                        drCurrRow = m_dtbDetail.Rows[iRow];
                        if ((drCurrRow["MEDICINEID_CHR"].ToString().Trim().Length == 0)
                            || (Convert.ToDecimal(drCurrRow["AMOUNT"].ToString()) == 0))
                        
                        {
                            m_dtbDetail.Rows.Remove(drCurrRow);
                        }
                        else
                        {
                            iRow++;
                        }

                    }

                    long lngRes = ((clsCtl_InMedicineWithdrawMakerBill)objController).m_lngSaveInStorage();
                    if (lngRes > 0)
                    {
                        m_txtInnerWithdrawBillNo.Focus();
                        //if (m_intCommitFolow == 1)
                        //{
                        //    //审核
                        //    try
                        //    {
                        //        this.Cursor = Cursors.WaitCursor;
                        //        DataRow[] drCommit = null;
                        //        ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthCommitMedicine(out drCommit);
                        //    }
                        //    catch (Exception Ex)
                        //    {
                        //        string strEx = Ex.Message;
                        //    }
                        //    finally
                        //    {
                        //        this.Cursor = Cursors.Default;
                        //    }

                        //}
                    }
                }

            }

        }


        /// <summary>
        /// 全选事件

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvMedicineDetail.Rows.Count > 0)
            {
                int m_intRowIndex = 0;
                DataRow m_dtbRow = null;
                bool m_blnChkFlag = false;
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMedicineDetail.Rows.Count; iRow++)
                    {
                        m_dgvMedicineDetail.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMedicineDetail.Rows.Count; iRow++)
                    {
                        m_dgvMedicineDetail.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }
        }

        /// <summary>
        /// 单据号文本框KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtInnerWithdrawBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 办理日期DateTimePick的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dtpTransactDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 备注文本框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if ((m_txtWithdrawDept.StrItemId.Trim().Length > 0)
                    && (m_lngMainSEQ == 0))
                {
                    ReturnDeptID = m_txtWithdrawDept.StrItemId;
                    m_strReturnDept = m_txtWithdrawDept.Text.Trim();
                }

                if (ReturnDeptID.Trim().Length == 0)
                {
                    MessageBox.Show("请输入内退单位！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_txtWithdrawDept.Focus();
                    return;
                }

                if (m_dgvMedicineDetail.RowCount > 0)
                {
                    m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intMedicineCodeColIndex, 0];
                    m_dgvMedicineDetail.Focus();
                }
                else
                    m_mthAddNewRow();

            }

        }

        /// <summary>
        /// 内退单号的Enter事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtInnerWithdrawBillNo_Enter(object sender, EventArgs e)
            {
            if (m_CtlActivate)
            {
                m_CtlActivate = false;
                m_ctlNext.Focus();
            }
            else
            {
                m_ctlNext = m_ctlControls[0];
            }

        }

        /// <summary>
        /// DataGridView的EnterKeyPress事件
        /// </summary>
        /// <param name="CurrentCell"></param>
        /// <param name="CancelJump"></param>
        private void m_dgvMedicineDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {            
            CancelJump = true;
            if (m_dgvMedicineDetail.ReadOnly) return;
            if ((m_txtWithdrawDept.StrItemId.Trim().Length > 0)
                && (m_lngMainSEQ == 0))
            {
                ReturnDeptID = m_txtWithdrawDept.StrItemId;
                m_strReturnDept = m_txtWithdrawDept.Text.Trim();
            }

            if (ReturnDeptID.Trim().Length == 0)
            {
                MessageBox.Show("请输入内退单位！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtWithdrawDept.Focus();
                return;
            }

            if (CurrentCell.ColumnIndex == m_intMedicineCodeColIndex)
            {
                if (CurrentCell == null)
                {
                    return;
                }
                m_dgvMedicineDetail.EndEdit();

                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                m_mthPopupWindow(strFilter);

                CancelJump = true;

            }
            else if (CurrentCell.ColumnIndex == m_intAmountColIndex)
            {
                if (m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
                {
                    bool bolAdjustrice;
                    DataGridViewRow dgr = m_dgvMedicineDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex];
                    ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAdjustrice(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["medicineid_chr"].ToString(), m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                    Convert.ToDateTime(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);;
                    if (bolAdjustrice)
                    {
                        //dgr.Cells[9].Value = dblNetAmount;
                        m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["NETAMOUNT_INT"] = dblNetAmount;
                        MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_dgvMedicineDetail.Focus();
                        return;
                    }
                }
                decimal decAvailAmount = 0;
                decimal decAmount = 0;
                int intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;
                DataRow drDtbRow = m_dtbDetail.Rows[intRowIndex];
                m_dgvMedicineDetail.EndEdit();
                CancelJump = true;
                decimal.TryParse(drDtbRow["AvailAmount"].ToString(), out decAvailAmount);
                decimal.TryParse(drDtbRow["Amount"].ToString(), out decAmount);
                if (decAmount > decAvailAmount)
                {
                    m_dgvMedicineDetail.CancelEdit();
                    m_dgvMedicineDetail.CurrentCell.Value = 0;
                    m_dgvMedicineDetail.EndEdit();
                    //m_dtbRow["Amount"] = m_dtbRow["AvailAmount"];
                    MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intAmountColIndex, intRowIndex];
                    m_dgvMedicineDetail.Focus();
                }

                else if (drDtbRow["LOTNO_VCHR"].ToString().Trim().Length > 0)
                    m_mthAddNewRow();
                ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAllSubMoney();
            }



        }

        /// <summary>
        /// 插入按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdInsert_Click(object sender, EventArgs e)
        {
            if ((m_txtWithdrawDept.StrItemId.Trim().Length > 0)
                && (m_lngMainSEQ == 0))
            {
                ReturnDeptID = m_txtWithdrawDept.StrItemId;
                m_strReturnDept = m_txtWithdrawDept.Text.Trim();
            }

            if (ReturnDeptID.Trim().Length == 0)
            {
                MessageBox.Show("请输入内退单位！", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtWithdrawDept.Focus();
                return;
            }

            m_mthAddNewRow();
        }


        #endregion 事件

        #region 方法

        public override void CreateController()
        {
            this.objController = new clsCtl_InMedicineWithdrawMakerBill();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 初始化

        /// </summary>
        private void m_mthInit()
        {
            DataRow m_drDataRow = null;

            DataTable m_dtbModify = null;
            m_lblBuyInSubMoney.Text = string.Empty;
            m_lblRetailSubMoney.Text = string.Empty;

            if ((m_dtbDetail != null) && (m_dtbDetail.Rows.Count > 0))
            {
                if (m_lngMainSEQ > 0)
                {
                    m_dtbModify = m_dtbDetail.GetChanges(DataRowState.Modified);
                }
                else
                {
                    m_dtbModify = m_dtbDetail.GetChanges(DataRowState.Added);
                }
                if ((m_dtbModify !=null) && (m_dtbModify.Rows.Count > 0))
                {
                    DialogResult Result = MessageBox.Show("有未保存的数据，是否保存？", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Result == DialogResult.Yes)
                    {
                        long lngRes = ((clsCtl_InMedicineWithdrawMakerBill)objController).m_lngSaveInStorage();
                    }

                }
            }

             m_lngMainSEQ = 0;

             m_txtInnerWithdrawBillNo.Text = string.Empty;

             m_txtWithdrawDept.Text = string.Empty;
             m_txtWithdrawDept.Tag = null;

             m_txtRemark.Text = string.Empty;
             m_txtInnerWithdrawBillNo.Tag = string.Empty;
             m_txtInnerWithdrawBillNo.Text = string.Empty;

             if ((m_dtbDetail != null) && (m_dtbDetail.Rows.Count > 0))
             {
                 m_dtbDetail.Rows.Clear();
             }

             panel1.Enabled = true;
        }

        #region 设置控件的Enter事件

        /// <summary>
        /// 设置下一个焦点控件

        /// </summary>
        internal void m_mthSetNextControl(ref Control[] p_ctlControls)
        {
            if (p_ctlControls == null)
            {
                return;
            }

            for (int iCtl = 0; iCtl < p_ctlControls.Length; iCtl++)
            {
                p_ctlControls[iCtl].Enter += new EventHandler(clsCtl_Public_Enter);
            }
        }

        /// <summary>
        /// 设定当前控件的下一个控件

        /// </summary>
        /// <param name="sender"></param>
        private void clsCtl_Public_Enter(object sender, EventArgs e)
        {
            int ctlIndex;
            for (ctlIndex = 0; ctlIndex < m_ctlControls.Length; ctlIndex++)
            {
                if (m_ctlControls[ctlIndex].Name == "m_txtWithdrawDept")

                {
                    m_CtlActivate = true;
                }
                else
                    m_CtlActivate = false;

                if (m_ctlControls[ctlIndex].Name == (sender as Control).Name)
                    break;
            }

            if (ctlIndex == m_ctlControls.Length - 1)
                m_ctlNext = m_txtInnerWithdrawBillNo;
            else
                m_ctlNext = m_ctlControls[ctlIndex + 1];

        }


        #endregion


        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(panel2, Color.Moccasin);
            objCtl.m_mthSelectAllText(panel2);
        }




        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 在药品框中按回车键后，显示药典查询窗口
        /// </summary>
        private void m_mthPopupWindow(string p_strFilter)
        {
            long lngRes = 0;
            if (m_strStorageID.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (m_dtbMedicinDict != null)
            {
                int intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;
                DataRow drDtbRow = m_dtbDetail.Rows[intRowIndex];
                drDtbRow["MEDICINEID_CHR"] = string.Empty;
                //drDtbRow["ASSISTCODE_CHR"] = string.Empty;
                drDtbRow["MEDICINENAME_VCH"] = string.Empty;
                drDtbRow["MEDSPEC_VCHR"] = string.Empty;
                drDtbRow["LOTNO_VCHR"] = string.Empty;

                drDtbRow["OPUNIT_CHR"] = string.Empty;

                m_mthShowQueryMedicineForm(p_strFilter.Trim());
            }
        }

        /// <summary>
        /// 显示药品字典最小元素信息查询窗体

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);

            }

            m_ctlQueryMedicint.Visible = true;
            int X = m_dgvMedicineDetail.Location.X +
                m_dgvMedicineDetail.CurrentRow.Cells[0].Size.Width +
                m_dgvMedicineDetail.CurrentRow.Cells[1].Size.Width; 

            int Y = m_dgvMedicineDetail.Location.Y + 
                m_dgvMedicineDetail.CurrentRow.Height * (m_dgvMedicineDetail.CurrentRow.Index+2)+10;


            m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

            //m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_mthReturnInfo);

            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_mthReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            DataRow drDtbRow = null;
            int intRowIndex = 0;
            if (MS_VO == null)
            {
                intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;
                drDtbRow = m_dtbDetail.Rows[intRowIndex];
                drDtbRow["MEDICINEID_CHR"] = string.Empty;
                drDtbRow["ASSISTCODE_CHR"] = string.Empty;
                drDtbRow["MEDICINENAME_VCH"] = string.Empty;
                drDtbRow["MEDSPEC_VCHR"] = string.Empty;
                drDtbRow["LOTNO_VCHR"] = string.Empty;
                drDtbRow["OPUNIT_CHR"] = string.Empty;
                return;
            }

            intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;

            DataRowView dtvTemp = null;
            bool bolAdjustrice;
            clsCtl_InMedicineWithdrawMakerBill m_objControl = new clsCtl_InMedicineWithdrawMakerBill();
            for (int iRow = 0; iRow < m_dgvMedicineDetail.Rows.Count; iRow++)
            {
                dtvTemp = m_dgvMedicineDetail.Rows[iRow].DataBoundItem as DataRowView;
                if (dtvTemp["MEDICINEID_CHR"].ToString() == MS_VO.m_strMedicineID)
                {
                    DataGridViewRow dgr = m_dgvMedicineDetail.Rows[iRow];
                    m_objControl.m_mthGetAdjustrice(dtvTemp["medicineid_chr"].ToString(),
                        dtvTemp["lotno_vchr"].ToString(), dtvTemp["instorageid_vchr"].ToString(),
                        Convert.ToDateTime(dtvTemp["VALIDPERIOD_DAT"]), Convert.ToDouble(dtvTemp["CALLPRICE_INT"]), out bolAdjustrice);
                    if (bolAdjustrice)
                    {
                        MessageBox.Show("此药品列表包含已调价记录的相同药品,因此不能选择再选择此药品！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_dgvMedicineDetail.Focus();
                        return;
                    }
                }
            }

            //for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
            //{
            //    drDtbRow = m_dtbDetail.Rows[i1];
            //    if (MS_VO.m_strMedicineID.Trim() == drDtbRow["MEDICINEID_CHR"].ToString().Trim())
            //    {
            //        MessageBox.Show("此单已有该药品");
            //        m_dtbDetail.Rows[intRowIndex]["MEDICINEID_CHR"] = string.Empty;
            //        m_dtbDetail.Rows[intRowIndex]["ASSISTCODE_CHR"] = string.Empty;
            //        m_dtbDetail.Rows[intRowIndex]["MEDICINENAME_VCH"] = string.Empty;
            //        m_dtbDetail.Rows[intRowIndex]["MEDSPEC_VCHR"] = string.Empty;
            //        m_dtbDetail.Rows[intRowIndex]["OPUNIT_CHR"] = string.Empty;

            //        m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intMedicineCodeColIndex, m_dgvMedicineDetail.CurrentRow.Index];
            //        m_dgvMedicineDetail.Focus();
            //        return;
            //    }
            //}

            drDtbRow = m_dtbDetail.Rows[intRowIndex];
            drDtbRow["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
            drDtbRow["ASSISTCODE_CHR"] = MS_VO.m_strMedicineCode;
            drDtbRow["MEDICINENAME_VCH"] = MS_VO.m_strMedicineName;
            drDtbRow["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
            drDtbRow["OPUNIT_CHR"] = MS_VO.m_strMedicineUnit;
            drDtbRow["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;

            m_frmCallOutStorageInfo = new frmInMedicineCancelCallOutStorageInfo((clsCtl_InMedicineWithdrawMakerBill)objController, m_strStorageID, m_strStoreRoomName);
            m_frmCallOutStorageInfo.dtbMedicinDict = m_dtbMedicinDict;
            long lngRes = m_frmCallOutStorageInfo.SetCallOutStorageInfo(MS_VO.m_strMedicineID, MS_VO.m_strMedicineName, ReturnDeptID, m_strReturnDept);
            if (lngRes > 0)
            {
                DialogResult dlgResult = m_frmCallOutStorageInfo.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;
                    drDtbRow = m_dtbDetail.Rows[intRowIndex];



                    ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetMedicineTypeVisionm(drDtbRow["MEDICINETYPEID_CHR"].ToString(),out m_clsTypeVisVO);

                    if (m_clsTypeVisVO != null & m_clsTypeVisVO.m_intLotno == 1 && string.IsNullOrEmpty(drDtbRow["LOTNO_VCHR"].ToString()))
                    {
                        drDtbRow["MEDICINEID_CHR"] = string.Empty;
                        //drDtbRow["ASSISTCODE_CHR"] = string.Empty;
                        drDtbRow["MEDICINENAME_VCH"] = string.Empty;
                        drDtbRow["MEDSPEC_VCHR"] = string.Empty;
                        drDtbRow["LOTNO_VCHR"] = string.Empty;
                        drDtbRow["OPUNIT_CHR"] = string.Empty;
                        m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intMedicineCodeColIndex, m_dgvMedicineDetail.CurrentRow.Index];
                    }
                    else
                    {
                        m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intAmountColIndex, m_dgvMedicineDetail.CurrentRow.Index];
                    }
                    ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAllSubMoney();
                    m_dgvMedicineDetail.EndEdit();
                    m_dgvMedicineDetail.Focus();
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    m_dtbDetail.Rows[intRowIndex]["MEDICINEID_CHR"] = string.Empty;
                    //m_dtbDetail.Rows[intRowIndex]["ASSISTCODE_CHR"] = string.Empty;
                    m_dtbDetail.Rows[intRowIndex]["MEDICINENAME_VCH"] = string.Empty;
                    m_dtbDetail.Rows[intRowIndex]["MEDSPEC_VCHR"] = string.Empty;
                    m_dtbDetail.Rows[intRowIndex]["LOTNO_VCHR"] = string.Empty;
                    m_dtbDetail.Rows[intRowIndex]["OPUNIT_CHR"] = string.Empty;

                    m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intMedicineCodeColIndex, m_dgvMedicineDetail.CurrentRow.Index];
                    m_ctlQueryMedicint.Visible = true;
                    m_ctlQueryMedicint.Focus();
                    m_ctlQueryMedicint.m_mthSetSearchText(m_dtbDetail.Rows[intRowIndex]["ASSISTCODE_CHR"].ToString());

                }

            }
            else
            {
                MessageBox.Show("该药品没有出库记录","药品内退",MessageBoxButtons.OK,MessageBoxIcon.Information);
                m_dtbDetail.Rows[intRowIndex]["MEDICINEID_CHR"] = string.Empty;
                //m_dtbDetail.Rows[intRowIndex]["ASSISTCODE_CHR"] = string.Empty;
                m_dtbDetail.Rows[intRowIndex]["MEDICINENAME_VCH"] = string.Empty;
                m_dtbDetail.Rows[intRowIndex]["MEDSPEC_VCHR"] = string.Empty;
                m_dtbDetail.Rows[intRowIndex]["LOTNO_VCHR"] = string.Empty;
                m_dtbDetail.Rows[intRowIndex]["OPUNIT_CHR"] = string.Empty;

                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                m_ctlQueryMedicint.m_mthSetSearchText(m_dtbDetail.Rows[intRowIndex]["ASSISTCODE_CHR"].ToString());

            }
        }

        private void m_mthCanelSelect()
        {
            int intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;
            DataRow drDtbRow = m_dtbDetail.Rows[intRowIndex];
            drDtbRow["MEDICINEID_CHR"] = string.Empty;
            //drDtbRow["ASSISTCODE_CHR"] = string.Empty;
            drDtbRow["MEDICINENAME_VCH"] = string.Empty;
            drDtbRow["MEDSPEC_VCHR"] = string.Empty;
            drDtbRow["LOTNO_VCHR"] = string.Empty;
            drDtbRow["OPUNIT_CHR"] = string.Empty;

            m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intMedicineCodeColIndex, m_dgvMedicineDetail.CurrentRow.Index];
            m_dgvMedicineDetail.Focus();
        }

        /// <summary>
        /// 增加新行
        /// </summary>
        private void m_mthAddNewRow()
        {
            if (m_dgvMedicineDetail.RowCount > 0)
            {
                DataRow drDtbRow = null;
                int i1 = 0;
                for (i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    drDtbRow = m_dtbDetail.Rows[i1];
                    if (drDtbRow["LOTNO_VCHR"].ToString().Trim().Length == 0)
                        break;
                }
                if (i1 == m_dtbDetail.Rows.Count)
                {
                    ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthAddNewMedicineData();
                }
                else
                {
                    m_dgvMedicineDetail.Focus();
                    m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail[m_intMedicineCodeColIndex, i1];
                }
            }
            else
            {
                ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthAddNewMedicineData();
            }

        }


        #endregion

        private void frmInStorageMedicineWithdrawDetail_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void m_dgvMedicineDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && Convert.ToDouble(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["AMOUNT"]) != dblNetAmount && m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
            {

                bool bolAdjustrice=false;
                DataGridViewRow dgr = m_dgvMedicineDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex];
                ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAdjustrice(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["medicineid_chr"].ToString(), m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                    Convert.ToDateTime(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);
                if (bolAdjustrice)
                {
                    //dgr.Cells[9].Value = dblNetAmount;
                    m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["AMOUNT"] = dblNetAmount;
                    MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_dgvMedicineDetail.Focus();
                    return;
                }
            }
            if (e.ColumnIndex == m_intMedicineCodeColIndex)
            {

                if (m_dgvMedicineDetail.CurrentCell.Value.ToString().Length == 0)
                {
                    m_dgvMedicineDetail.CancelEdit();
                }
            }
        }

        private void m_dgvMedicineDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {


            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal m_decNetAvailAmount = 0;
            decimal m_decCallPrice = 0;
            decimal m_decRetailPrice = 0;
            decimal m_decWholesalePrice = 0;
            bool m_blnChkFlag = false;
            m_dgvMedicineDetail.EndEdit();
            if ((m_dgvMedicineDetail.Rows.Count > 0) && (m_dgvMedicineDetail.CurrentCell.ColumnIndex == m_intAmountColIndex))
            {
                int m_intRowIndex = m_dgvMedicineDetail.CurrentRow.Index;
                m_dtbRow = m_dtbDetail.Rows[m_intRowIndex];

                decimal.TryParse(m_dtbRow["AvailAmount"].ToString(), out m_decAvailAmount);
                decimal.TryParse(m_dtbRow["Amount"].ToString(), out m_decNetAvailAmount);
                if (m_decNetAvailAmount > m_decAvailAmount)
                {
                    m_dgvMedicineDetail.CancelEdit();
                    m_dgvMedicineDetail.CurrentCell.Value = 0;
                    m_dgvMedicineDetail.EndEdit();
                    e.Cancel = true;
                    MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    m_dgvMedicineDetail.Focus();
                }
                else
                {
                    decimal.TryParse(m_dtbRow["Amount"].ToString(), out  m_decNetAvailAmount);

                    decimal.TryParse(m_dtbRow["CALLPRICE_INT"].ToString(), out m_decCallPrice);
                    decimal.TryParse(m_dtbRow["RETAILPRICE_INT"].ToString(), out m_decRetailPrice);
                    decimal.TryParse(m_dtbRow["WHOLESALEPRICE_INT"].ToString(), out m_decWholesalePrice);
                    m_dtbRow["CallSum"] = m_decNetAvailAmount * m_decCallPrice;
                    m_dtbRow["RetailSum"] = m_decNetAvailAmount * m_decRetailPrice;
                    ((clsCtl_InMedicineWithdrawMakerBill)objController).m_mthGetAllSubMoney();
                    //m_dtbDetail.AcceptChanges();
                }
            }//if


            if (e.ColumnIndex == m_intMedicineCodeColIndex)
            {
                if (m_dgvMedicineDetail.CurrentCell.Value.ToString().Length == 0)
                {
                    m_dgvMedicineDetail.CancelEdit();
                }
            }

        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_InMedicineWithdraw clsInwith = new clsCtl_InMedicineWithdraw();
            DataRow[] rows = m_dtbMedinineMain.Select("instorageid_vchr = '" + m_txtInnerWithdrawBillNo.Text+"'");
            if (rows == null || rows.Length == 0)
            {
                string strEMTname = LoginInfo.m_strEmpName;
                clsInwith.m_lngPring(strEMTname, m_strStoreRoomName, m_txtInnerWithdrawBillNo.Text, m_dtpTransactDate.Text, m_txtWithdrawDept.Text, m_dtbDetail, m_lblBuyInSubMoney.Text);
            }
            else
            {
                clsInwith.m_lngPring(rows[0][15].ToString(), m_strStoreRoomName, m_txtInnerWithdrawBillNo.Text, m_dtpTransactDate.Text, m_txtWithdrawDept.Text, m_dtbDetail, m_lblBuyInSubMoney.Text);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void m_dgvMedicineDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                double.TryParse(m_dtbDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["AMOUNT"].ToString(), out dblNetAmount);
            }
        }



    }
}