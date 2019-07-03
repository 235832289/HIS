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
    /// <summary>
    /// 药品内退主窗体

    /// </summary>
    public partial class frmInStorageMedicineInnerWithdraw : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 字段

        Control m_ctlNext = null;
        private Control[] m_ctlControls = null;


        public string m_strCommiter = string.Empty;
        /// <summary>
        /// 控件激活标志

        /// </summary>
        private bool m_CtlActivate = false;

        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;

        /// <summary>
        /// 仓库名称
        /// </summary>
        internal string m_strStoreRoomName = string.Empty;


        /// <summary>
        /// 药品内退查询参数
        /// </summary>
        private clsMs_InMedicineWithdrawQueryCondition_VO m_value_Param;

        /// <summary>
        /// 药品内退明细查询条件
        /// </summary>
        private clsMs_MedicineWithdrawDetailQueryCondition_VO m_objDetail_Param = null;
        /// <summary>
        ///  药典查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        /// <summary>
        /// 药品基本信息
        /// </summary>
        private clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();
        /// <summary>
        /// 药品类型
        /// </summary>
        private clsValue_MedicineType_VO[] m_objMedicineTypeArr = null;
        /// <summary>
        /// 药典数据表

        /// </summary>
        internal DataTable m_dtbMedicinDict = null;

        /// <summary>
        /// 药品内退主表
        /// </summary>
        internal DataTable m_dtbMedicineInnerWithdraw = null;

        /// <summary>
        /// 药品内退明细表

        /// </summary>
        internal DataTable m_dtbMedicineInnerWithdrawDetail = null;


        /// <summary>
        /// 是否有药库管理员权限
        /// </summary>
        internal bool m_blnIsAdmin = false;

        /// 查询出来的金额

        /// </summary>
        internal DataTable m_dtbAllMoney = null;
        /// <summary>
        /// 是否审核即入帐

        /// </summary>
        internal bool m_blnIsImmAccount = false;

        #endregion 字段

        #region 构造函数


        /// <summary>
        /// 默认构造函数

        /// </summary>
        public frmInStorageMedicineInnerWithdraw()
        {
            InitializeComponent();
            m_dtbMedicineInnerWithdrawDetail = new DataTable();
            DataColumn[] drColumns = new DataColumn[] { 
                new DataColumn("SortNum",typeof(string)),
                new DataColumn("MEDICINEID_CHR",typeof(string)), 
                new DataColumn("ASSISTCODE_CHR",typeof(string)),
                new DataColumn("MEDICINENAME_VCH",typeof(string)), 
                new DataColumn("MEDSPEC_VCHR",typeof(string)), 
                new DataColumn("LOTNO_VCHR",typeof(string)), 
                new DataColumn("AVAILAGROSS_INT",typeof(decimal)),
                new DataColumn("NETAMOUNT_INT",typeof(decimal)),
                new DataColumn("CancelAmount",typeof(decimal)), 
                new DataColumn("AvailAmount",typeof(decimal)),
                new DataColumn("AMOUNT",typeof(decimal)),
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
                new DataColumn("PACKCALLPRICE_INT",typeof(decimal)),
                new DataColumn("SERIESID_INT",typeof(decimal)),
                new DataColumn("SERIESID2_INT",typeof(decimal)),
                new DataColumn("withdrawsum",typeof(decimal)),
                new DataColumn("RUTURNNUM_INT",typeof(decimal)),
                new DataColumn("medicinetypeid_chr",typeof(string))};

            m_dtbMedicineInnerWithdrawDetail.Columns.AddRange(drColumns);

            m_dtbMedicineInnerWithdrawDetail.AcceptChanges();

            m_dtpSearchBeginDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;

            m_strCommiter = LoginInfo.m_strEmpID;

            ((clsCtl_InMedicineWithdraw)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_InMedicineWithdraw)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);


            m_ctlControls = new Control[] {
                m_dtpSearchEndDate,m_txtMakerBillPerson,
                m_cboBillState,m_txtWithdrawDept,m_txtProviderName,
                m_txtMedicineName,m_cboMedicinePrepType,m_txtBillNumber};
            //设置控件的Enter事件
            m_mthSetNextControl(ref m_ctlControls);
            //设置控件的背景色
            m_mthSetControlHighLight();
            //初始化部门数据


            DataTable dtbDept = null;
            ((clsCtl_InMedicineWithdraw)objController).m_mthGetExportDept(out dtbDept);
            m_txtWithdrawDept.m_mthInitDeptData(dtbDept);
        }

        /// <summary>
        /// 带参构造函数

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmInStorageMedicineInnerWithdraw(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_strStoreRoomName = ((clsCtl_InMedicineWithdraw)objController).m_strStoreRoomName(p_strStorageID);
            if (!string.IsNullOrEmpty(m_strStoreRoomName))
            {
                this.Text += " - " + m_strStoreRoomName;
            }

        }
        #endregion

        #region 事件

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInStorageMedicineInnerWithdraw_Load(object sender, EventArgs e)
        {
            long lngRes = 0;
            //获取药品类型
            lngRes = ((clsCtl_InMedicineWithdraw)objController).m_lngGetMedicineType(out m_objMedicineTypeArr);
            if ((lngRes > 0) && (m_objMedicineTypeArr != null))
            {
                m_cboMedicinePrepType.Items.Add("全部");
                for (int i1 = 0; i1 < m_objMedicineTypeArr.Length; i1++)
                {
                    m_cboMedicinePrepType.Items.Add(m_objMedicineTypeArr[i1].m_strMedicineTypeName);
                }
                m_cboMedicinePrepType.SelectedIndex = 0;
            }
            m_cboBillState.SelectedIndex = 0;
            int intShowInitial;
            m_lngGetShowInitial(out intShowInitial);
            if (intShowInitial == 0)
            {
                m_cmdInitialData.Visible = false;
            }
            else
            {
                m_cmdInitialData.Visible = true; ;
            }

        }
        #endregion

        #region 窗体的Shown事件
        /// <summary>
        /// 窗体的Shown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInStorageMedicineInnerWithdraw_Shown(object sender, EventArgs e)
        {
            clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();


            //初始化药品字典


            long lngRes = objDomain.m_lngGetBaseMedicine("", m_strStorageID, out  m_dtbMedicinDict);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);

            }

            m_ctlQueryMedicint.Visible = false;
            m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_mthReturnInfo);
            m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_mthCanelSelect);
            m_ctlQueryMedicint.BringToFront();

            m_mthQueryMedicineWithdrawData();
        }

        #endregion


        private void m_mthCanelSelect()
        {
            m_objMedicineBase.m_strMedicineID = string.Empty;
            m_objMedicineBase.m_strAssistCode = string.Empty;
            m_objMedicineBase.m_strMedicineName = string.Empty;
            m_objMedicineBase.m_strMedSpec = string.Empty;
            m_txtMedicineName.Text = "";
            m_txtMedicineName.Focus();
        }



        #region 退出按钮事件

        /// <summary>
        /// 退出按钮

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 制单人文本框的KeyDown事件
        /// <summary>
        /// 制单人的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param EventArgs="e"></param>
        private void m_txtMakerBillPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                ((clsCtl_InMedicineWithdraw)objController).m_mthSetEmpToList(m_txtMakerBillPerson.Text, m_txtMakerBillPerson);
            }
        }
        #endregion

        #region 药品文本框的KeyUp事件
        /// <summary>
        /// 药品文本框的KeyUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtMedicineName_KeyUp(object sender, KeyEventArgs e)
        {

        }

        #endregion

        #region 供应商文本框的KeyDown事件
        /// <summary>
        /// 供应商文本框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InMedicineWithdraw)objController).m_mthShowVendor(m_txtProviderName.Text);
            }
        }

        #endregion


        /// <summary>
        /// 制单开始日期的Enter事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dtpSearchBeginDate_Enter(object sender, EventArgs e)
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
        /// 单据状态组合框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cboBillState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 剂型组合框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cboMedicinePrepType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }
        }

        /// <summary>
        /// 单据号文本框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtBillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }
        }

        /// <summary>
        /// 开始日期的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dtpSearchBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }


        /// <summary>
        /// 查询按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_mthQueryMedicineWithdrawData();
            if (m_dgvMainInfo.RowCount > 0)
            {
                m_dgvMainInfo.Focus();
            }

        }

        private void m_mthQueryMedicineWithdrawData()
        {
            m_lblSelectAll.Text = "全选";
            if ((m_dtbMedicineInnerWithdraw != null)
                && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
            {
                m_dtbMedicineInnerWithdraw.Rows.Clear();

                m_dtbMedicineInnerWithdraw.AcceptChanges();
            }

            if ((m_dtbMedicineInnerWithdrawDetail != null)
                && (m_dtbMedicineInnerWithdrawDetail.Rows.Count > 0))
            {
                m_dtbMedicineInnerWithdrawDetail.Rows.Clear();

                m_dtbMedicineInnerWithdrawDetail.AcceptChanges();
            }

            GetMedicineInnerWithdrawData();

            if ((m_dtbMedicineInnerWithdraw != null) && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
            {
                m_mthGetDetailData();
            }

        }

        /// <summary>
        /// 药品内退主表Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dgvMainInfo_Click(object sender, EventArgs e)
        {

            if ((m_dtbMedicineInnerWithdraw != null) && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
            {
                m_mthGetDetailData();
            }
        }

        /// <summary>
        /// 制单按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdNewMake_Click(object sender, EventArgs e)
        {
            if (!m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限！不能制单", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(m_strStorageID))
            {
                MessageBox.Show("没有选择药库！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmInStorageMedicineWithdrawDetail m_objMakerBill = new frmInStorageMedicineWithdrawDetail(m_strStorageID, m_strStoreRoomName,ref m_dtbMedicineInnerWithdraw);
               
                DialogResult dlgResult = m_objMakerBill.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    m_mthQueryMedicineWithdrawData();
                    if (m_dgvMainInfo.RowCount > 0)
                    {
                        m_dgvMainInfo.Focus();
                    }
                }
            }
        }


        /// <summary>
        /// 修改按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            m_mthModifyMedicineWithdraw();

        }

        /// <summary>
        /// 删除按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_InMedicineWithdraw)objController).m_mthDeleteMedicine();
            if ((m_dtbMedicineInnerWithdraw != null) && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
            {
                m_mthGetDetailData();
            }
        }

        /// <summary>
        /// 审核按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdAuditing_Click(object sender, EventArgs e)
        {
            m_lblSelectAll.Text = "全选";
            int i1 = 0;
            for (i1 = 0; i1 < m_dgvMainInfo.Rows.Count; i1++)
            {
                if ((Convert.ToBoolean(m_dgvMainInfo.Rows[i1].Cells[0].Value) == true)
                    && (Convert.ToInt32(m_dtbMedicineInnerWithdraw.Rows[i1]["STATE_INT"]) == 1))
                {
                    break;
                }
            }

            if (i1 == m_dgvMainInfo.Rows.Count)
            {
                MessageBox.Show("请选择需审核的药品内退信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                m_cmdAuditing.Enabled = false;
                //m_pnlWaiting.Visible = true;
                Application.DoEvents();

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    ((clsCtl_InMedicineWithdraw)objController).m_mthCommitMedicine();
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
                finally
                {
                    m_cmdAuditing.Enabled = true;
                    //m_pnlWaiting.Visible = false;
                    this.Cursor = Cursors.Default;
                }
            }

        }

        /// <summary>
        /// 退审按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdExitAuditing_Click(object sender, EventArgs e)
        {
            m_lblSelectAll.Text = "全选";
            int i1 = 0;
            for (i1 = 0; i1 < m_dgvMainInfo.Rows.Count; i1++)
            {
                if ((Convert.ToBoolean(m_dgvMainInfo.Rows[i1].Cells[0].Value) == true)
                    && (Convert.ToInt32(m_dtbMedicineInnerWithdraw.Rows[i1]["STATE_INT"]) == 2))
                {
                    break;
                }
            }
            if (i1 == m_dgvMainInfo.Rows.Count)
            {
                MessageBox.Show("请选择需退审的药品内退信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    ((clsCtl_InMedicineWithdraw)objController).m_mthUnCommit();
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
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
            if (m_dgvMainInfo.Rows.Count > 0)
            {
                int m_intRowIndex = 0;
                DataRow m_dtbRow = null;
                bool m_blnChkFlag = false;
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMainInfo.Rows.Count; iRow++)
                    {
                        m_dgvMainInfo.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMainInfo.Rows.Count; iRow++)
                    {
                        m_dgvMainInfo.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }

        }

        /// <summary>
        /// 入库主表的CellValueChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dgvMainInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow m_dtbRow = null;
            //decimal m_decAvailAmount = 0;
            //decimal m_decNetAvailAmount = 0;
            //decimal m_decCallPrice = 0;
            //decimal m_decRetailPrice = 0;
            //decimal m_decWholesalePrice = 0;
            //bool m_blnChkFlag = false;

            //if ((m_dgvMainInfo.Rows.Count > 0) && (m_dgvMainInfo.CurrentCell.ColumnIndex == 0))
            //{
            //    int m_intRowIndex = m_dgvMainInfo.CurrentRow.Index;
            //    m_dtbRow = m_dtbMedicineInnerWithdraw.Rows[m_intRowIndex];
            //    bool.TryParse(m_dgvMainInfo.CurrentCell.Value.ToString(), out m_blnChkFlag);
            //    m_dtbRow["chkcommit"] = m_blnChkFlag;
            //    //m_dtbDetail.AcceptChanges();
            //}
        }

        /// <summary>
        /// 入库主表的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dgvMainInfo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// DataGridView控件m_dgvMainInfo的鼠标双击事件

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dgvMainInfo_DoubleClick(object sender, EventArgs e)
        {
            m_mthModifyMedicineWithdraw();
        }

        private void m_cmdInitialData_Click(object sender, EventArgs e)
        {
            frmInitialInStorageWithdraw frmInitial = new frmInitialInStorageWithdraw(m_strStorageID);
            frmInitial.FormClosed += new FormClosedEventHandler(frmInitial_FormClosed);
            frmInitial.ShowDialog();
        }

        private void frmInitial_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_cmdSearch_Click(null, null);
        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_mthPopupWindow();
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_InMedicineWithdraw)objController).m_mthInAccount();
        }
        #endregion 事件

        #region 方法

        public override void CreateController()
        {
            this.objController = new clsCtl_InMedicineWithdraw();
            objController.Set_GUI_Apperance(this);
        }

        #region 活动背景色

        /// <summary>
        /// 控件跳转及活动背景色
        /// </summary>
        private void m_mthInitJumpControls()
        {
            clsCtl_Public objCtl = new clsCtl_Public();

            //objCtl.m_mthJumpControl(this, new Control[] {
            //    m_dtpSearchBeginDate,m_dtpSearchEndDate,m_txtMakerBillPerson,
            //    m_cboBillState,m_txtWithdrawDept,m_txtProviderName,
            //    m_txtMedicineName,m_cboMedicinePrepType,m_txtBillNumber}, Keys.Enter, true);

            objCtl.m_mthSetControlHighLight(this, Color.Moccasin);
            objCtl.m_mthSelectAllText(this);
        }

        #endregion


        #region 设置活动控件背景高亮(m_mthSetControlHighLight)
        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(panel1, Color.Moccasin);
            objCtl.m_mthSelectAllText(panel1);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 在药品框中按回车键后，显示药典查询窗口

        /// </summary>
        private void m_mthPopupWindow()
        {
            long lngRes = 0;
            if (m_strStorageID.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();

            ////调用Com+服务端


            //lngRes = objDomain.m_lngGetBaseMedicine(m_txtMedicineName.Text.Trim(), m_strStorageID, out  m_dtbMedicinDict);

            if ((m_dtbMedicinDict != null) && (m_dtbMedicinDict.Rows.Count > 0))
            {
                m_mthShowQueryMedicineForm(m_txtMedicineName.Text.Trim());
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

            int X = panel1.Location.X + m_txtMedicineName.Location.X;
            int Y = panel1.Location.Y + m_txtMedicineName.Location.Y + m_txtMedicineName.Height;// -m_ctlQueryMedicint.Size.Height;


            m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

            m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_mthReturnInfo);

            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_mthReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                m_txtMedicineName.Text = string.Empty;

                m_objMedicineBase.m_strMedicineID = string.Empty;
                m_objMedicineBase.m_strAssistCode = string.Empty;
                m_objMedicineBase.m_strMedicineName = string.Empty;
                m_objMedicineBase.m_strMedSpec = string.Empty;
                return;
            }
            m_txtMedicineName.Text = MS_VO.m_strMedicineName;

            m_objMedicineBase.m_strMedicineID = MS_VO.m_strMedicineID;
            m_objMedicineBase.m_strAssistCode = MS_VO.m_strMedicineCode;
            m_objMedicineBase.m_strMedicineName = MS_VO.m_strMedicineName;
            m_objMedicineBase.m_strMedSpec = MS_VO.m_strMedicineSpec;

            //m_cboMedicinePrepType.Focus();
        }
        #endregion


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
                if ((m_ctlControls[ctlIndex].Name == "m_txtWithdrawDept")
                    || (m_ctlControls[ctlIndex].Name == "m_txtProviderName")
                    || (m_ctlControls[ctlIndex].Name == "m_txtMedicineName")
                    || (m_ctlControls[ctlIndex].Name == "m_txtMakerBillPerson"))
                {
                    m_CtlActivate = true;
                }
                else
                    m_CtlActivate = false;

                if (m_ctlControls[ctlIndex].Name == (sender as Control).Name)
                    break;
            }

            if (ctlIndex == m_ctlControls.Length - 1)
                m_ctlNext = m_dtpSearchBeginDate;
            else
                m_ctlNext = m_ctlControls[ctlIndex + 1];

        }
        #endregion

        #region 获取药品内退主表记录
        /// <summary>
        /// 获取药品内退主表记录
        /// </summary>
        private void GetMedicineInnerWithdrawData()
        {
            long lngRes = 0;


            if (m_value_Param == null)
                m_value_Param = new clsMs_InMedicineWithdrawQueryCondition_VO();

            m_value_Param.m_strQueryBeginDate = string.Empty;
            m_value_Param.m_strQueryEndDate = string.Empty;
            m_value_Param.m_strStorageID = string.Empty;
            m_value_Param.m_strVendorID = string.Empty;
            m_value_Param.m_strMedicineID = string.Empty;
            m_value_Param.m_strMedicineTypeID = string.Empty;
            m_value_Param.m_strInStorageID = string.Empty;
            m_value_Param.m_intFormType = 0;
            m_value_Param.m_intState = 0;
            m_value_Param.m_strMakeBillPeopleID = string.Empty;
            m_value_Param.m_strReturnDeptID = string.Empty;

            if ((m_dtpSearchBeginDate.Text.Trim().Length == 11) && (m_dtpSearchEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(m_dtpSearchBeginDate.Text)) > (Convert.ToDateTime(m_dtpSearchEndDate.Text)))
                {
                    MessageBox.Show("开始日期必须小于或等于结束日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    m_dtpSearchBeginDate.Focus();
                    return;
                }
            }

            if (m_dtpSearchBeginDate.Text.Trim().Length == 11)
            {
                string strDate = m_dtpSearchBeginDate.Text;
                m_value_Param.m_strQueryBeginDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd 00:00:00");
            }

            if (m_dtpSearchEndDate.Text.Trim().Length == 11)
            {
                string strDate = m_dtpSearchEndDate.Text;
                m_value_Param.m_strQueryEndDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd 23:59:59");
            }

            //仓库ID
            m_value_Param.m_strStorageID = m_strStorageID;
            //供应商ID
            if (m_txtProviderName.Text.Trim().Length == 0)
            {
                m_value_Param.m_strVendorID = string.Empty;
                m_txtProviderName.Tag = null;
            }
            else
            {
                if (m_txtProviderName.Tag == null)
                    m_value_Param.m_strVendorID = string.Empty;
                else
                    m_value_Param.m_strVendorID = m_txtProviderName.Tag.ToString();
            }

            //药品ID
            if (m_txtMedicineName.Text.Trim().Length == 0)
            {
                if (string.IsNullOrEmpty(m_objMedicineBase.m_strMedicineID))
                {
                    m_value_Param.m_strMedicineID = string.Empty;
                }
                else
                {
                    m_value_Param.m_strMedicineID = m_objMedicineBase.m_strMedicineID;
                    m_txtMedicineName.Text = m_objMedicineBase.m_strMedicineName;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(m_objMedicineBase.m_strMedicineID))
                {
                    m_value_Param.m_strMedicineID = string.Empty;
                    m_txtMedicineName.Text = "";
                }
                else
                {
                    m_value_Param.m_strMedicineID = m_objMedicineBase.m_strMedicineID;
                    m_txtMedicineName.Text = m_objMedicineBase.m_strMedicineName;
                }
            }
            
            //药品类型
            if (m_cboMedicinePrepType.Text.Trim() == "全部")
                m_value_Param.m_strMedicineTypeID = string.Empty;
            else
                m_value_Param.m_strMedicineTypeID = m_objMedicineTypeArr[m_cboMedicinePrepType.SelectedIndex - 1].m_strMedicineTypeID;

            //入库单号
            m_value_Param.m_strInStorageID = m_txtBillNumber.Text.Trim();

            //单据类型
            m_value_Param.m_intFormType = 2;

            //单据状态

            if (m_cboBillState.Text.Trim() == "新制")
                m_value_Param.m_intState = 1;
            else if (m_cboBillState.Text.Trim() == "审核")
                m_value_Param.m_intState = 2;
            else if (m_cboBillState.Text.Trim() == "入帐")
                m_value_Param.m_intState = 3;
            else if (m_cboBillState.Text.Trim() == "全部")
                m_value_Param.m_intState = -1;

            //制单人

            if (m_txtMakerBillPerson.Text.Trim().Length == 0)
            {
                m_value_Param.m_strMakeBillPeopleID = string.Empty;
                m_txtMakerBillPerson.Tag = null;
            }
            else
            {
                if (m_txtMakerBillPerson.Tag == null)
                    m_value_Param.m_strMakeBillPeopleID = string.Empty;
                else
                    m_value_Param.m_strMakeBillPeopleID = m_txtMakerBillPerson.Tag.ToString();

            }

            //内退部门
            if ((m_txtWithdrawDept.StrItemId.Trim().Length > 0)
                && (m_txtWithdrawDept.Text.Trim().Length > 0))
            {
                m_value_Param.m_strReturnDeptID = m_txtWithdrawDept.StrItemId;
            }
            else
            {
                m_value_Param.m_strReturnDeptID = string.Empty;
            }           


            //lngRes = m_objMedicineWithdrawCtl.m_mthGetMedicineInnerWithdrawData(ref m_value_Param, out m_dtbMedicineInnerWithdraw);
            lngRes = ((clsCtl_InMedicineWithdraw)objController).m_mthGetMedicineInnerWithdrawData(ref m_value_Param, out m_dtbMedicineInnerWithdraw);
            if (lngRes > 0)
            {
                m_dgvMainInfo.DataSource = m_dtbMedicineInnerWithdraw;

            }

        }
        #endregion 获取药品内退主表记录


        #region 获取药品内退明细数据
        /// <summary>
        /// 获取药品内退明细数据
        /// </summary>
        private void m_mthGetDetailData()
        {
            long lngRes = 0;

            if ((m_dtbMedicineInnerWithdrawDetail != null)
                && (m_dtbMedicineInnerWithdrawDetail.Rows.Count > 0))
            {
                m_dtbMedicineInnerWithdrawDetail.Rows.Clear();

                m_dtbMedicineInnerWithdrawDetail.AcceptChanges();
            }

            if (m_objDetail_Param == null)
                m_objDetail_Param = new clsMs_MedicineWithdrawDetailQueryCondition_VO ();

            if ((m_dtbMedicineInnerWithdraw != null) && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
            {
                int m_intSn = 0;
                int m_intRowIndex = 0;
                m_intRowIndex = m_dgvMainInfo.CurrentRow.Index;
                int.TryParse(m_dtbMedicineInnerWithdraw.Rows[m_intRowIndex]["SERIESID_INT"].ToString(), out m_objDetail_Param.m_intSERIESID2_INT);
                m_objDetail_Param.m_strStorageID = m_strStorageID;
                m_objDetail_Param.m_intStatus = 1;
                m_objDetail_Param.m_strInStorageID = m_dtbMedicineInnerWithdraw.Rows[m_intRowIndex]["INSTORAGEID_VCHR"].ToString();


                //lngRes = m_objMedicineWithdrawCtl.m_mthGetMedicineInnerWithdrawDetailData(ref m_objDetail_Param, ref m_dtbMedicineInnerWithdrawDetail);
                lngRes = ((clsCtl_InMedicineWithdraw)objController).m_mthGetMedicineInnerWithdrawDetailData(ref m_objDetail_Param, ref m_dtbMedicineInnerWithdrawDetail);
                if (lngRes > 0)
                {

                    m_dgvSubInfo.DataSource = m_dtbMedicineInnerWithdrawDetail;
                }
            }

        }

        #endregion 获取药品内退明细数据

        #region 修改记录
        private void m_mthModifyMedicineWithdraw()
        {
            string strStorageID = string.Empty;
            string strInStorageID = string.Empty;

            if (m_dtbMedicineInnerWithdrawDetail.Rows.Count > 0)
            {
                //if (!m_blnIsAdmin)
                //{
                //    MessageBox.Show("当前用户没有药库管理权限！不能修改", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                int intStatus = 0;                
                int intRowIndex = 0;


                bool blnIsInitialWithdraw = ((clsCtl_InMedicineWithdraw)objController).m_blnIsInitialWithdraw();
                if (blnIsInitialWithdraw)//选中表单为内退初始化单据

                {
                    clsMS_InStorage_VO objMain = null;
                    clsMS_InStorageDetail_VO[] objSubVO = null;
                    ((clsCtl_InMedicineWithdraw)objController).m_mthModifyInitialWithdraw(out objMain, out objSubVO);
                    if (objMain != null && objSubVO != null)
                    {
                        frmInitialInStorageWithdraw frmInitial = new frmInitialInStorageWithdraw(m_strStorageID, objMain, objSubVO);
                        frmInitial.FormClosed += new FormClosedEventHandler(frmInitial_FormClosed);
                        

                        int intRow = m_dgvMainInfo.CurrentRow.Index;
                        frmInitial.m_strMakName = m_dgvMainInfo.Rows[intRow].Cells["m_dgvtxtMakerName"].Value.ToString();
                        frmInitial.ShowDialog();

                    }
                }
                else
                {
                    clsMS_InStorage_VO objMain = null;
                    clsMS_InStorageDetail_VO[] objSubArr = null;
                    ((clsCtl_InMedicineWithdraw)objController).m_mthModifySelected(out objMain, out objSubArr);

                    if (objMain == null)
                    {
                        return;
                    }

                    int intSelectedSubRow = 0;
                    if ((m_dtbMedicineInnerWithdraw != null) && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
                      intSelectedSubRow = m_dgvMainInfo.CurrentRow.Index;


                    intRowIndex = m_dgvMainInfo.CurrentRow.Index;
                    string p_strReturnDept = m_dtbMedicineInnerWithdraw.Rows[intRowIndex]["deptname_vchr"].ToString();
                    string p_strReturnDeptID = m_dtbMedicineInnerWithdraw.Rows[intRowIndex]["returndept_chr"].ToString();

                    frmInStorageMedicineWithdrawDetail frmModifyMedicineWithdraw = new frmInStorageMedicineWithdrawDetail(p_strReturnDeptID, p_strReturnDept,ref m_dtbMedicineInnerWithdraw, ref m_dtbMedicineInnerWithdrawDetail, m_strStorageID, m_strStoreRoomName, objMain, objSubArr, intSelectedSubRow);

                    frmModifyMedicineWithdraw.ShowDialog();
                    m_mthGetDetailData();
                }                
            }

        }
        #endregion

        private void m_dgvMainInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Up) || (e.KeyData == Keys.Down))
            {
                if ((m_dtbMedicineInnerWithdraw != null) && (m_dtbMedicineInnerWithdraw.Rows.Count > 0))
                    m_mthGetDetailData();

            }

        }

        #endregion 方法

        #region 获取是否显示内退初始化按钮


        /// <summary>
        /// 获取是否显示内退初始化按钮

        /// </summary>
        /// limitunitprice_mny
        internal long m_lngGetShowInitial(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(null, "5023", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

    }
}