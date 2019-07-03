using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Text.RegularExpressions;
namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 采购入库
    /// </summary>
    public partial class frmPurchase_Detail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 是否刚显示完药品查询(跳转控制时用)
        /// </summary>
        private bool m_blnIsAfterShowMedicineInfo = false;
        /// <summary>
        /// 单据类型 "1入库2退药出库3盘盈入库"
        /// </summary>
        internal int m_intFormType = 1;
        /// <summary>
        /// 入库类型 "1采购入库、2生产入库、3即出即入"
        /// </summary>
        internal int m_intInstorageType = 1;
        /// <summary>
        /// 录入药品信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        /// 是否显示包装/基本单位换算
        /// </summary>
        private bool m_blnIsShowUnitConversion = false;
        /// <summary>
        /// 获取是否显示中标验货信息
        /// </summary>
        private bool m_blnIsShowAcceptanceCheck = false;
        /// <summary>
        /// 入库主表序列
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 当前选中的数据行
        /// </summary>
        internal DataRow m_drSelectedRow = null;
        /// <summary>
        /// 已添加的药品是否有毒麻药品
        /// </summary>
        internal bool m_blnAddedRowsHasPoisonOrChlorpromazine = false;
        /// <summary>
        /// 当前将要添加的药品是否是毒麻药品
        /// </summary>
        internal bool m_blnCurrenIsPoisonOrChlorpromazine = false;
        /// <summary>
        /// 是否弹出MessageBox(对控件的Leave事件作控制)
        /// </summary>
        internal bool IsShowBox = false;
        /// <summary>
        /// 生成零售价方法
        /// 0,不做任何处理　1,取药品字典表数据　2,购入价×(1+毛利率)
        /// </summary>
        internal int m_intRetailMethod = 0;
        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// 是否已审核
        /// </summary>
        internal bool m_blnHasCommit = false;
        /// <summary>
        /// 是否可修改毛利率 0:否  1:是
        /// </summary>
        public int iGrossType = 0;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// 保存后是否添加出库记录

        /// </summary>
        public bool m_bolAddOutMedicineInfo;
        /// <summary>
        /// 药品中的批号,有效期录入控制

        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;

        /// <summary>
        /// 是否已调价
        /// </summary>
        public bool bolAdjustrice;

        /// <summary>
        /// 入库数量
        /// </summary>
        public double dblOldScalar;

          /// <summary>
        /// 入库零售价
        /// </summary>
        public double dblOldRetailUnitPrice;

        /// <summary>
        /// 是否显示国家限价 0:否 1:是
        /// </summary>
        public int iLimitunitPrice;
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是
        /// </summary>
        public int m_intCanModifyMakeDate;
        /// <summary>
        /// 自动审核后单据是否允许修改','0，否 1,是'
        /// </summary>
        public int m_intCanModifyAutoExam;
        #endregion

        #region 构造函数

        /// <summary>
        /// 采购入库
        /// </summary>
        private frmPurchase_Detail()
        {
            InitializeComponent();
            
            m_dtpInComeDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpInComeDate.Tag = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            m_txtInvoiceDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_txtInEffectDate.Text = DateTime.Now.AddYears(2).ToString("yyyy年MM月dd日");
            m_txtProduceDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_txtProviderName.Focus();
            m_dgvMedicineDetail.AutoGenerateColumns = false;
            m_mthInitTable();
            m_txtMakeBillPerson.Tag = LoginInfo.m_strEmpID;
            m_txtMakeBillPerson.Text = LoginInfo.m_strEmpName;

            m_mthInitJumpControls();
            DataTable m_dtbVendor = new DataTable();          

        }

        /// <summary>
        /// 采购入库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intFormType">单据类型 "1入库2退药出库3盘盈入库"</param>
        /// <param name="p_intInstorageType">入库类型 "1采购入库、2生产入库、3即出即入"</param>
        public frmPurchase_Detail(string p_strStorageID, int p_intFormType, int p_intInstorageType)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_intFormType = p_intFormType;
            m_intInstorageType = p_intInstorageType;
            m_bgwGetMedicinInfo.RunWorkerAsync();
            ((clsCtl_Purchase_Detail)objController).m_mthGetLatestEmpInfo();
            ((clsCtl_Purchase_Detail)objController).m_mthGetIsShowUnitConviersionSetting(out m_blnIsShowUnitConversion);
            ((clsCtl_Purchase_Detail)objController).m_mthGetIsShowAcceptanceCheck(out m_blnIsShowAcceptanceCheck);
            ((clsCtl_Purchase_Detail)objController).m_mthGetRetailMethod(out m_intRetailMethod);
            ((clsCtl_Purchase_Detail)objController).m_mthGetCommitFlow(out m_intCommitFolow);
            ((clsCtl_Purchase_Detail)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            ((clsCtl_Purchase_Detail)objController).m_lngGetCanModifyMakeDate(out m_intCanModifyMakeDate);
            ((clsCtl_Purchase_Detail)objController).m_lngGetCanModifyAutoExam(out m_intCanModifyAutoExam);
            

            if (p_intInstorageType == 3)
            {
                m_bolAddOutMedicineInfo = true;
                DataTable dtbVendorExp = null;
                ((clsCtl_Purchase_Detail)objController).m_mthGetExportDept(out dtbVendorExp);
                m_txtExportDept.m_mthInitDeptData(dtbVendorExp);
            }

        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intFormType">单据类型 "1入库2退药出库3盘盈入库"</param>
        /// <param name="p_intInstorageType">入库类型 "1采购入库、2生产入库、3即出即入"</param>
        /// <param name="p_objISVO">入库主表内容</param>
        /// <param name="p_objDetailArr">入库子表内容</param>
        /// <param name="p_intSelectedSubRow">选中子表行</param>
        public frmPurchase_Detail(string p_strStorageID, int p_intFormType, int p_intInstorageType, clsMS_InStorage_VO p_objISVO, clsMS_InStorageDetail_VO[] p_objDetailArr, int p_intSelectedSubRow)
            : this(p_strStorageID, p_intFormType, p_intInstorageType)
        {
            ((clsCtl_Purchase_Detail)objController).m_mthSetMedicineDetailToUI(p_objISVO, p_objDetailArr, p_intSelectedSubRow);



        }
        #endregion

        #region 事件
        private void m_bgwGetMedicinInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_Purchase_Detail)objController).m_mthGetMedicineInfo();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            
         
            if (m_dtbMedicineInfo != null && panel1.Enabled)
            {
                DataTable dtbNew = m_dtbMedicineInfo.GetChanges(DataRowState.Added);
                DataTable dtbModify = m_dtbMedicineInfo.GetChanges(DataRowState.Modified);

                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbModify != null && dtbModify.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定退出?", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            
            this.Close();          
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            //20090707:在保存前重新检查单据状态，防止导致重复审核单据。
            if (m_txtIncomeBillNumber.Text.Trim().Length > 0)
            {
                int intStatusTemp = 0;
                ((clsCtl_Purchase_Detail)objController).m_lngCheckStatus(m_lngMainSEQ, out intStatusTemp);
                if (intStatusTemp != 1)
                {
                    MessageBox.Show("此入库单状态已被修改，请关闭此单据并重新加载", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            long lngRes = ((clsCtl_Purchase_Detail)objController).m_lngSaveInStorage();

            if (lngRes > 0)
            {
                if (m_intCanModifyMakeDate == 0)
                    m_dtpInComeDate.Enabled = false;
                DialogResult drResult = MessageBox.Show("是否打印当前窗体记录?", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    ((clsCtl_Purchase_Detail)objController).m_mthPrintDirect();
                }
                else
                {
                    m_txtMedicineCode.Focus();
                }                
            }            
        }

        private void m_cmdInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_Purchase_Detail)objController).m_mthClearMedicinInfo();
            m_txtMedicineCode.Focus();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            //20090707:在保存前重新检查单据状态，防止导致重复审核单据。
            if (m_txtIncomeBillNumber.Text.Trim().Length > 0)
            {
                int intStatusTemp = 0;
                ((clsCtl_Purchase_Detail)objController).m_lngCheckStatus(m_lngMainSEQ, out intStatusTemp);
                if (intStatusTemp != 1)
                {
                    MessageBox.Show("此入库单已审核，不能删除，请关闭此单据并重新加载", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult drResult = MessageBox.Show("是否删除选定记录?","药品入库",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            ((clsCtl_Purchase_Detail)objController).m_mthDeleteInStorageDetail();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_Purchase_Detail)objController).m_purchasePrint();
        }

        private void m_cmdNextBill_Click(object sender, EventArgs e)
        {
            if (m_dtbMedicineInfo != null && panel1.Enabled)
            {
                DataTable dtbNew = m_dtbMedicineInfo.GetChanges(DataRowState.Added);
                DataTable dtbModify = m_dtbMedicineInfo.GetChanges(DataRowState.Modified);

                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbModify != null && dtbModify.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定清空并书写下一张单?", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            ((clsCtl_Purchase_Detail)objController).m_mthClearMainInfo();
            ((clsCtl_Purchase_Detail)objController).m_mthClearMedicinInfo();
            m_dtbMedicineInfo.Rows.Clear();
            m_txtProviderName.Focus();
            if (m_intCanModifyMakeDate == 0)
                m_dtpInComeDate.Enabled = false;
            
        }

        private void m_cmdAddToList_Click(object sender, EventArgs e)
        {
            decimal decBuyInUnitPrice = 0;
            decimal.TryParse(this.m_txtBuyInUnitPrice.Text, out decBuyInUnitPrice);
            if (decBuyInUnitPrice <= 0)
            {
                IsShowBox = true;
                MessageBox.Show("购入单价必须大于零", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtBuyInUnitPrice.Focus();
                IsShowBox = false;
                return;
            }

            ((clsCtl_Purchase_Detail)objController).m_lngAddDataToList();
            ((clsCtl_Purchase_Detail)objController).m_mthGetAllMoney();
            m_drSelectedRow = null;
        }

        private void m_txtPurchasePerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ((clsCtl_Purchase_Detail)objController).m_mthSetEmpToList(m_txtPurchasePerson.Text, m_txtPurchasePerson);
            }
        }

        private void m_txtStroehouseManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_Purchase_Detail)objController).m_mthSetEmpToList(m_txtStroehouseManager.Text, m_txtStroehouseManager);
            }
        }

        private void m_txtAccountant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_Purchase_Detail)objController).m_mthSetEmpToList(m_txtAccountant.Text, m_txtAccountant);
            }
        }

        private void m_txtProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_Purchase_Detail)objController).m_mthShowVendor(m_txtProviderName.Text);
            }
        }

        private void m_dtpInComeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //m_txtPurchasePerson.Focus();
                m_txtStroehouseManager.Focus();
            }
        }

        private void panel4_Enter(object sender, EventArgs e)
        {
            if (m_blnIsAfterShowMedicineInfo)
            {
                m_blnIsAfterShowMedicineInfo = false;
                return;
            }
            m_txtMedicineCode.Focus();
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_blnIsAfterShowMedicineInfo = true;
                ((clsCtl_Purchase_Detail)objController).m_mthShowQueryMedicineForm(m_txtMedicineCode.Text);
            }
        }

        private void m_txtProducer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_blnIsAfterShowMedicineInfo = true;
                 ((clsCtl_Purchase_Detail)objController).m_mthShowManufacturer(m_txtProducer.Text);
            }
        }

        private void m_lklAcceptanceCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            long lngRes = ((clsCtl_Purchase_Detail)objController).m_lngShowAcceptanceCheck();
            if (lngRes > 0)
            {
                m_cmdAddToList.Focus();
            }
        }

        private void m_lklAcceptanceCheck_Enter(object sender, EventArgs e)
        {

            if (m_blnIsShowAcceptanceCheck)
            {
                m_lklAcceptanceCheck_LinkClicked(null, null);
            }
            else
            {
                m_txtBuyInUnitPrice.Focus();
            }

        }

        private void m_lklPackUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_blnIsAfterShowMedicineInfo = true;
            long lngRes = ((clsCtl_Purchase_Detail)objController).m_lngShowPackConversion();
            if (lngRes > 0)
            {
                if (m_clsTypeVisVO != null && m_clsTypeVisVO.m_intLotno == 0)
                {
                    m_txtBuyInUnitPrice.Focus();
                }
                else
                {
                    m_txtBatchNumber.Focus();
                }
            }            
        }

        private void m_txtScalar_Leave(object sender, EventArgs e)
        {
            if (m_txtScalar.Text.Trim() == "") m_txtScalar.Text = "0";
            if (bolAdjustrice && Convert.ToDouble(m_txtScalar.Text) != dblOldScalar)
            {
                m_txtScalar.Text = dblOldScalar.ToString();
                MessageBox.Show("该药品已调价,不能修改出库数量！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                //m_txtScalar.Focus();
                return;
            }
            if (IsShowBox)
            {
                return;
            }
            if (((clsCtl_Purchase_Detail)objController).m_lngCheckAmount() < 0)
            {
                return;
            }

            double dblScalar = 0d;
            if (double.TryParse(m_txtScalar.Text, out dblScalar))
            {
                m_txtScalar.Text = dblScalar.ToString("0.00");
            }

            m_txtRetailUnitPrice_Leave(null, null);
            m_txtBuyInUnitPrice_Leave(null, null);
            m_txtWholeSaleUnitPrice_Leave(null, null);
            m_txtRetailUnitPrice_Leave(null, null);
        }

        private void m_txtBuyInUnitPrice_Leave(object sender, EventArgs e)
        {
            if (IsShowBox)
            {
                return;
            }
            decimal dcmPrice = 0m;
            if (decimal.TryParse(m_txtBuyInUnitPrice.Text, out dcmPrice))
            {
                m_txtBuyInUnitPrice.Text = dcmPrice.ToString("0.0000");
                ((clsCtl_Purchase_Detail)objController).m_mthSetRetailPrice(dcmPrice);
            }

            decimal dcmRetailUnitPrice = 0m;
            if (decimal.TryParse(m_txtRetailUnitPrice.Text, out dcmRetailUnitPrice))
            {
                m_txtBalance.Text = (dcmRetailUnitPrice - dcmPrice).ToString("0.0000");
            }

            if (!string.IsNullOrEmpty(m_txtBuyInUnitPrice.Text) && !string.IsNullOrEmpty(m_txtScalar.Text))
            {
                ((clsCtl_Purchase_Detail)objController).m_mthSetBuyInMomey(sender);
            }            
        }

        private void m_txtWholeSaleUnitPrice_Leave(object sender, EventArgs e)
        {
            if (IsShowBox)
            {
                return;
            }
            decimal dcmPrice = 0m;
            if (decimal.TryParse(m_txtWholeSaleUnitPrice.Text, out dcmPrice))
            {
                m_txtWholeSaleUnitPrice.Text = dcmPrice.ToString("0.0000");
            }

            if (!string.IsNullOrEmpty(m_txtWholeSaleUnitPrice.Text) && !string.IsNullOrEmpty(m_txtScalar.Text))
            {
                ((clsCtl_Purchase_Detail)objController).m_mthSetWholeSaleMoney();
            }
        }

        private void m_txtWholeSaleUnitPrice_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtWholeSaleUnitPrice.Text))
            {
                m_txtWholeSaleUnitPrice.Text = m_txtBuyInUnitPrice.Text;
            }
        }

        private void m_txtRetailUnitPrice_Leave(object sender, EventArgs e)
        {
            if (m_txtRetailUnitPrice.Text.Trim() == "") m_txtRetailUnitPrice.Text = "0";
            if (bolAdjustrice && Convert.ToDouble(m_txtRetailUnitPrice.Text) != dblOldRetailUnitPrice)
            {
                m_txtRetailUnitPrice.Text = dblOldRetailUnitPrice.ToString();
                MessageBox.Show("该药品已调价,不能修改零售价！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //m_txtRetailUnitPrice.Focus();
                return;
            }

//            if (iLimitunitPrice == 1 && m_txtRetailUnitPrice.Text.Trim() != "" && Convert.ToDouble(m_txtLastBuyInUnitPrice.Text) > 0 &&
//Convert.ToDouble(m_txtRetailUnitPrice.Text) > Convert.ToDouble(m_txtLastBuyInUnitPrice.Text))
//            {
//                DialogResult drResultQ = MessageBox.Show("当前零售单价大于国家限价,是否继续？", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//                if (drResultQ == DialogResult.No)
//                {
//                    m_txtRetailUnitPrice.Focus();
//                    return;
//                }

//            }

            if (IsShowBox)
            {
                return;
            }


            decimal dcmPrice = 0m;
            if (decimal.TryParse(m_txtRetailUnitPrice.Text, out dcmPrice))
            {
                m_txtRetailUnitPrice.Text = dcmPrice.ToString("0.0000");
            }

            decimal dcmBuy = 0m;
            if (decimal.TryParse(m_txtBuyInUnitPrice.Text, out dcmBuy))
            {
                m_txtBalance.Text = (dcmPrice - dcmBuy).ToString("0.0000");
            }

            if (!string.IsNullOrEmpty(m_txtRetailUnitPrice.Text) && !string.IsNullOrEmpty(m_txtScalar.Text))
            {
                ((clsCtl_Purchase_Detail)objController).m_mthSetRetailMoney();
            }

        }

        private void m_txtInvoiceDate_Enter(object sender, EventArgs e)
        {
            m_txtInvoiceDate.SelectionStart = 0;
        }

        private void m_txtInEffectDate_Enter(object sender, EventArgs e)
        {
           m_txtInEffectDate.SelectionStart = 0;
        }

        private void m_dgvMedicineDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                m_drSelectedRow = m_dtbMedicineInfo.Rows[e.RowIndex];
                ((clsCtl_Purchase_Detail)objController).m_mthSetDataToUIForUpdate();
            }            
        }

        private void m_dtpInComeDate_Leave(object sender, EventArgs e)
        {
            if (m_txtPurchasePerson.Tag == null)
            {
                m_txtPurchasePerson.Focus();
                return;
            }
            if (m_txtStroehouseManager.Tag == null)
            {
                m_txtStroehouseManager.Focus();
                return;
            }
            if (m_txtAccountant.Tag == null)
            {
                m_txtAccountant.Focus();
                return;
            }
            m_txtProvidBillNo.Focus();
        }

        private void m_txtScalar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_txtMedicineCode.Tag == null)
                {
                    return;
                }
                if (m_blnIsShowUnitConversion)
                {
                    m_lklPackUnit_LinkClicked(null, null);
                }
                else
                {
                    //if (m_clsTypeVisVO != null && m_clsTypeVisVO.m_intLotno == 0)
                    //{
                    //    m_txtBuyInUnitPrice.Focus();
                    //}
                    //else
                    //{
                    m_txtBatchNumber.Focus();
                    //}
                }
            }
        }

        private void m_txtBatchNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(m_txtBatchNumber.Text) && m_clsTypeVisVO.m_intLotno == 1)
                {
                    MessageBox.Show("请先填写药品批号","药品入库",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    m_txtBatchNumber.Focus();
                    return;
                }
                m_txtInEffectDate.Focus();
            }
        }
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_Purchase_Detail();
            objController.Set_GUI_Apperance(this);
        }        
        
        /// <summary>
        /// 控件跳转及活动背景色
        /// </summary>
        private void m_mthInitJumpControls()
        { 
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthJumpControl(this, new Control[] {
                m_txtProvidBillNo,m_txtRemark,m_txtInvoiceNumber,m_txtInvoiceDate,m_txtProduceDate}, Keys.Enter, false);

            //是否显示批发价

            int m_intShowWholePrice;
            ((clsCtl_Purchase_Detail)objController).m_lngGetShowWholePrice(out m_intShowWholePrice);
            if (m_intShowWholePrice == 0)
            {
                clsCtl_Public objCtl1 = new clsCtl_Public();
                objCtl1.m_mthJumpControl(this, new Control[] {
                m_txtBuyInUnitPrice, m_txtRetailUnitPrice,m_txtProducer}, Keys.Enter, false);
            }
            else
            {
                clsCtl_Public objCtl1 = new clsCtl_Public();
                objCtl1.m_mthJumpControl(this, new Control[] {
                m_txtBuyInUnitPrice, m_txtWholeSaleUnitPrice,m_txtRetailUnitPrice,m_txtProducer}, Keys.Enter, false);
            }

            objCtl.m_mthSetControlHighLight(this, Color.Moccasin);
            objCtl.m_mthSelectAllText(this);
        }

        /// <summary>
        /// 初始化药品信息表
        /// </summary>
        private void m_mthInitTable()
        {
            m_dtbMedicineInfo = ((clsCtl_Purchase_Detail)objController).m_dtbInitTable();
            m_dgvMedicineDetail.DataSource = m_dtbMedicineInfo;
            ((clsCtl_Purchase_Detail)objController).m_mthGetAllMoney();
        } 
        #endregion

        private void frmPurchase_Detail_Load(object sender, EventArgs e)
        {
            ((clsCtl_Purchase_Detail)objController).m_mthLoad();
            if (m_intCanModifyMakeDate == 0)
                m_dtpInComeDate.Enabled = false;
             
        }

        private void m_txtInEffectDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtBuyInUnitPrice.Focus();
            }
        }

        private void m_txtGrossProfitRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdAddToList.Focus();
            }

        }

        private void m_txtGrossProfitRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == '\r' || e.KeyChar == '\b'))
            {
                MessageBox.Show("抱歉,此处只能输入数字!", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_txtGrossProfitRate.Focus();
                e.Handled = true;
            }
        }

        private void m_txtGrossProfitRate_Leave(object sender, EventArgs e)
        {
            if (m_intRetailMethod == 2)
            {
                if (m_txtGrossProfitRate.Text.Trim() == "") m_txtGrossProfitRate.Text = "0";
                try
                {
                    //毛利率计算


                    decimal dcmRetail = 0m;
                    if (iGrossType == 1)
                    {
                        dcmRetail = Convert.ToDecimal(m_txtBuyInUnitPrice.Text) * (1 + Convert.ToDecimal(m_txtGrossProfitRate.Text) / 100);
                        m_txtRetailUnitPrice.Text = dcmRetail.ToString("0.0000");

                        dcmRetail = Convert.ToDecimal(m_txtScalar.Text) * Convert.ToDecimal(m_txtRetailUnitPrice.Text);
                        m_txtRetailMoney.Text = dcmRetail.ToString("0.0000");
                    }
                }
                finally { };
            }
        }

        private void m_txtExportDept_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void m_txtMakeBillPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtRemark.Focus();
            }
        }

        private void m_txtReceiveDept_FocusNextControl(object sender, EventArgs e)
        {
            m_txtMedicineCode.Focus();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_txtInEffectDate_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void m_dgvMedicineDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvMedicineDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = m_dgvMedicineDetail.Rows[e.RowIndex];
            if (dgr.Cells[15].Value.ToString() == "1")
            {
                dgr.Cells[15].Value = "是";
            }
            if (dgr.Cells[15].Value.ToString() == "0")
            {
                dgr.Cells[15].Value = "否";
            }
        }

        private void m_txtRetailUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (iLimitunitPrice == 1)
            {
                if (m_txtRetailUnitPrice == null)
                {
                    return;
                }
                if (m_txtLastBuyInUnitPrice.Text.Trim() == "")
                {
                    m_txtLastBuyInUnitPrice.Text = "0.00";
                    return;
                }
            }

        }

        private void m_txtRetailUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_txtLastBuyInUnitPrice.Text.Trim() == "")
                    m_txtLastBuyInUnitPrice.Text = "0";
                if (m_txtRetailUnitPrice.Text.Trim() == "")
                    m_txtRetailUnitPrice.Text = "0";
                if (m_txtLastBuyInUnitPrice.Text.Trim() == "")
                    m_txtLastBuyInUnitPrice.Text = "0";

                if (Convert.ToDouble(m_txtLastBuyInUnitPrice.Text) > 0 && m_txtRetailUnitPrice.Text.Trim() != "" &&
Convert.ToDouble(m_txtRetailUnitPrice.Text) > Convert.ToDouble(m_txtLastBuyInUnitPrice.Text))
                {
                    MessageBox.Show("当前零售单价大于国家限价!", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txtProducer.Focus();
                }
            }
        }

        private void panel1_EnabledChanged(object sender, EventArgs e)
        {
            panel2.Enabled = panel1.Enabled;
            panel4.Enabled = panel1.Enabled;
        }

        private void m_txtBuyInUnitPrice_TextChanged(object sender, EventArgs e)
        {
            //if (m_txtWholeSaleUnitPrice.Text == "")
                m_txtWholeSaleUnitPrice.Text = m_txtBuyInUnitPrice.Text;
        }

        private void m_txtBuyInMomey_TextChanged(object sender, EventArgs e)
        {
            //if(m_txtWholeSaleMoney.Text == "")
                m_txtWholeSaleMoney.Text = m_txtBuyInMomey.Text;
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            ((clsCtl_Purchase_Detail)objController).m_mthClearMedicinInfo();
            this.m_txtMedicineCode.Focus();
        }

        private void m_txtProduceDate_Enter(object sender, EventArgs e)
        {
            this.m_txtProduceDate.Focus();
            m_txtProduceDate.SelectionStart = 0;
            m_txtProduceDate.SelectionLength = 4;
        }

        private void m_txtInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {　
                this.m_txtProduceDate.Focus();
            }
        }

        private void m_txtProduceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_cmdAddToList.Focus();
            }
        }

        private void m_txtProduceDate_Enter_1(object sender, EventArgs e)
        {
            this.m_txtProduceDate.SelectionStart = 0;
        }

        //private void m_txtInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.m_cmdAddToList.Focus();
        //    }
        //}

        //private void m_txtInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.m_cmdAddToList.Focus();
        //    }
        //}

        //private void m_txtRemark_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.m_txtMedicineCode.Focus();
        //    }
        //}
    }
}