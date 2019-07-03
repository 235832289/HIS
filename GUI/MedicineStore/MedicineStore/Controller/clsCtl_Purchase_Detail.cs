using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.EMR_EmployeeManagerService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 采购入库
    /// </summary>
    public class clsCtl_Purchase_Detail : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_Purchase_Detail m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmPurchase_Detail m_objViewer;
        /// <summary>
        /// 查询供应商控件

        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        private ctlQueryVendor m_ctlQueryExportDept = null;
        /// <summary>
        /// 查询生产厂家控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryManufacturer = null;
        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;
        /// <summary>
        /// 供应商

        /// </summary>
        private DataTable m_dtbVendor = null;
        /// <summary>
        /// 生产厂家
        /// </summary>
        private DataTable m_dtbManufacturer = null;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 当前药品验货信息
        /// </summary>
        private clsMS_AcceptanceCheck_VO m_objCurrentACInfo = null;
        /// <summary>
        /// 当前包装/基本单位换算信息
        /// </summary>
        private clsMS_PackConversion_VO m_objCurrentPCInfo = null;
        /// <summary>
        /// 当前药品入库主表信息
        /// </summary>
        private clsMS_InStorage_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前药品类型ID
        /// </summary>
        private string m_strCurrentMedicineTypeID = string.Empty;
        /// <summary>
        /// 是否可修改毛利率 0:否  1:是

        /// </summary>
        private int iGrossType;
        /// <summary>
        /// 是否显示批发价

        /// </summary>
        private int m_intShowWholePrice;
        /// <summary>
        /// 是否可修改零售价 0:否 1:是

        /// </summary>
        private int iUnitpriceType;
        /// <summary>
        /// 保存后是否添加出库记录

        /// </summary>
        private bool bolAddOutMedicineInfo;
        /// <summary>
        /// 需要删除的药品入库明细序列(有合并药品操作时使用)
        /// </summary>
        private List<long> m_lstWantDeleteSEQ = new List<long>();
        #endregion

        #region 构造函数

        /// <summary>
        /// 采购入库
        /// </summary>
        public clsCtl_Purchase_Detail()
        {
            m_objDomain = new clsDcl_Purchase_Detail();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPurchase_Detail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化


        public void m_mthLoad()
        {
            m_objDomain.m_lngGetGrossproFitrate(out iGrossType);
            if (iGrossType == 0)
            {
                m_objViewer.m_txtGrossProfitRate.ReadOnly = true;
            }

            m_objDomain.m_lngGetUnitpriceType(out iUnitpriceType);

            if (iUnitpriceType == 0)
            {
                m_objViewer.m_txtRetailUnitPrice.ReadOnly = true;
            }

            int intShowFlag = 1;
            m_objDomain.m_lngShowLastBuyInUnitPrice(out intShowFlag);
            if (intShowFlag == 0)
            {
                m_objViewer.m_txtLastBuyInUnitPrice.Visible = false;
                m_objViewer.m_txtLastRetailUnitPrice.Visible = false;
                m_objViewer.m_txtLastWholeSaleUnitPrice.Visible = false;
                m_objViewer.m_txtAvgBuyInUnitPrice.Visible = false;
                m_objViewer.m_txtGrossProfitRate.Visible = false;

                m_objViewer.label13.Visible = false;
                m_objViewer.label17.Visible = false;
                m_objViewer.label27.Visible = false;
                m_objViewer.label28.Visible = false;
                m_objViewer.label29.Visible = false;
                m_objViewer.label32.Visible = false;
            }

            m_objViewer.iGrossType = iGrossType;
            m_objDomain.m_lngGetLimitunitPrice(out m_objViewer.iLimitunitPrice);
            if (m_objViewer.iLimitunitPrice == 1)
            {
                m_objViewer.label13.Text = "国家限价";
                m_objViewer.label17.Text = "上次购入价";
            }
            bolAddOutMedicineInfo = m_objViewer.m_bolAddOutMedicineInfo;
            if (bolAddOutMedicineInfo)
            {
                m_objViewer.m_labExportDept.Visible = true;
                m_objViewer.m_txtExportDept.Visible = true;
                //m_mthGetExportDept(out m_dtbVendor);

                m_objViewer.Text = "采购入库(即入即出)";

                m_objViewer.m_labExportDept.Text = "领用部门";
                m_objViewer.cboProcurement.Visible = false;
            }
            else
            {
                m_objViewer.m_labExportDept.Visible = true; //false;
                m_objViewer.m_txtExportDept.Visible = false;

                m_objViewer.m_labExportDept.Text = "采购途径";
                m_objViewer.cboProcurement.Visible = true;
            }
            if (m_objViewer.m_intCommitFolow == 1)
            {
                m_objViewer.panel1.Enabled = true;
            }
            //是否显示批发价            
            m_objDomain.m_lngGetShowWholePrice(out m_intShowWholePrice);
            if (m_intShowWholePrice == 0)
            {
                m_objViewer.m_txtWholeSaleUnitPrice.Visible = false;
                m_objViewer.m_txtWholeSaleMoney.Visible = false;
                m_objViewer.label19.Visible = false;
                m_objViewer.label21.Visible = false;
                m_objViewer.m_dgvMedicineDetail.Columns["m_dgvtxtWholeSalePrice"].Visible = false;
                m_objViewer.m_dgvMedicineDetail.Columns["dgvtxtWholeSaleMoney"].Visible = false;
                m_objViewer.m_txtLastWholeSaleUnitPrice.Visible = false;
                m_objViewer.label17.Visible = false;
            }
        }

        #endregion

        #region 设置员工至列表



        /// <summary>
        /// 设置员工至列表

        /// </summary>
        /// <param name="p_strSearch">搜索字符串</param>
        /// <param name="p_txtEmp">员工控件</param>
        internal void m_mthSetEmpToList(string p_strSearch, TextBox p_txtEmp)
        {
            DataTable dtbEmp = null;
            long lngRes = m_objDomain.m_lngGetEMP(p_strSearch, out dtbEmp);

            if (dtbEmp == null || dtbEmp.Rows.Count == 0)
            {
                p_txtEmp.Tag = null;
            }
            if (m_ctlEMP == null)
            {
                m_ctlEMP = new ctlQueryEmployee();
                m_objViewer.Controls.Add(m_ctlEMP);
            }
            m_ctlEMP.m_mthSetTxtBase(p_txtEmp);
            m_ctlEMP.BringToFront();
            int X = m_objViewer.panel2.Location.X + p_txtEmp.Location.X;
            int Y = m_objViewer.panel2.Location.Y + p_txtEmp.Location.Y + p_txtEmp.Size.Height;

            if ((X + m_ctlEMP.Size.Width) > m_objViewer.Size.Width)
            {
                X = m_objViewer.panel2.Location.X + p_txtEmp.Location.X - (X + m_ctlEMP.Size.Width - m_objViewer.Size.Width);
            }
            m_ctlEMP.Location = new System.Drawing.Point(X, Y);
            m_ctlEMP.ReturnInfo += new ReturnEmpInfo(m_ctlEMP_ReturnInfo);

            try
            {
                int intRowCount = dtbEmp.Rows.Count;
                DataRow drCurrent = null;
                List<ListViewItem> lstItems = new List<ListViewItem>();
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = dtbEmp.Rows[iRow];
                    ListViewItem lsi = new ListViewItem(drCurrent["EMPNO_CHR"].ToString());
                    lsi.SubItems.Add(drCurrent["LASTNAME_VCHR"].ToString());
                    lsi.Tag = drCurrent;
                    lstItems.Add(lsi);
                }
                m_ctlEMP.AddRange(lstItems.ToArray());
                if (lstItems.Count == 0)
                {
                    p_txtEmp.Tag = null;
                }
                m_ctlEMP.Visible = true;
                m_ctlEMP.Focus();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }

        private void m_ctlEMP_ReturnInfo(DataRow DR_EMP, TextBox Sender)
        {
            Sender.Tag = null;
            if (DR_EMP != null)
            {
                Sender.Tag = DR_EMP["EMPID_CHR"].ToString();
                Sender.Text = DR_EMP["LASTNAME_VCHR"].ToString();
            }

            if (Sender.Name == "m_txtPurchasePerson")
            {
                m_objViewer.m_txtStroehouseManager.Focus();
            }
            else if (Sender.Name == "m_txtStroehouseManager")
            {
                m_objViewer.m_txtAccountant.Focus();
            }
            else if (Sender.Name == "m_txtAccountant")
            {
                m_objViewer.m_txtProvidBillNo.Focus();
            }
        }
        #endregion

        #region 显示供应商查询



        /// <summary>
        /// 获取供应商信息

        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }

        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetExportDept(out p_dtbExportDept);
        }

        /// <summary>
        /// 显示供应商查询

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);

                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.panel2.Location.X + m_objViewer.m_txtProviderName.Location.X;
                int Y = m_objViewer.panel2.Location.Y + m_objViewer.m_txtProviderName.Location.Y + m_objViewer.m_txtProviderName.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProviderName.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProviderName.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProviderName.Text = MS_VO.m_strVendorName;

            if (m_objViewer.m_intCanModifyMakeDate == 1)
            {
                m_objViewer.m_dtpInComeDate.Focus();
                m_objViewer.m_dtpInComeDate.SelectionStart = 0;
                m_objViewer.m_dtpInComeDate.SelectionLength = 4;
            }
            else
            {
                if (m_objViewer.m_txtPurchasePerson.Text.ToString().Length == 0 || m_objViewer.m_txtPurchasePerson.Tag == null || m_objViewer.m_txtPurchasePerson.Tag.ToString().Length == 0)
                    m_objViewer.m_txtPurchasePerson.Focus();
                else if (m_objViewer.m_txtStroehouseManager.Text.ToString().Length == 0 || m_objViewer.m_txtStroehouseManager.Tag == null || m_objViewer.m_txtStroehouseManager.Tag.ToString().Length == 0)
                    m_objViewer.m_txtStroehouseManager.Focus();
                else if (m_objViewer.m_txtAccountant.Text.ToString().Length == 0 || m_objViewer.m_txtAccountant.Tag == null || m_objViewer.m_txtAccountant.Tag.ToString().Length == 0)
                    m_objViewer.m_txtAccountant.Focus();
                else
                    m_objViewer.m_txtProvidBillNo.Focus();
            }
        }
        #endregion

        #region 显示生产厂家查询

        /// <summary>
        /// 获取生产厂家信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetManufacturer(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetManufacturer(out p_dtbVendor);
        }
        /// <summary>
        /// 显示供应商查询


        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowManufacturer(string p_strSearchCon)
        {
            if (m_ctlQueryManufacturer == null)
            {
                m_mthGetManufacturer(out m_dtbManufacturer);
                m_ctlQueryManufacturer = new ctlQueryVendor(m_dtbManufacturer);
                m_ctlQueryManufacturer.m_blnCanInput = true;
                m_objViewer.Controls.Add(m_ctlQueryManufacturer);

                int X = m_objViewer.panel4.Location.X + m_objViewer.m_txtProducer.Location.X;
                int Y = m_objViewer.panel4.Location.Y + m_objViewer.m_txtProducer.Location.Y - m_ctlQueryManufacturer.Size.Height;

                m_ctlQueryManufacturer.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryManufacturer.ReturnInfo += new ReturnVendorInfo(QueryManufacturer_ReturnInfo);
                m_ctlQueryManufacturer.CancelResult += new VendorCancelAndReturn(m_ctlQueryManufacturer_CancelResult);
            }
            m_ctlQueryManufacturer.BringToFront();
            m_ctlQueryManufacturer.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryManufacturer.Visible = true;
            m_ctlQueryManufacturer.Focus();
        }

        internal void m_ctlQueryManufacturer_CancelResult()
        {
            if (m_objViewer.m_clsTypeVisVO.m_intValidperiod == 0)
            {
                m_objViewer.m_cmdAddToList.Focus();
            }
            else
            {
                m_objViewer.m_txtInEffectDate.Focus();
            }
        }

        internal void QueryManufacturer_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProducer.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProducer.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProducer.Text = MS_VO.m_strVendorName;

            bool blnShowCheck;
            m_objDomain.m_lngGetIsShowAcceptanceCheck(out blnShowCheck);
            if (blnShowCheck)
            {
                long lngRes = m_lngShowAcceptanceCheck();
                if (lngRes > 0)
                {
                    m_objViewer.m_cmdAddToList.Focus();
                }
            }
            else
            {
                //m_objViewer.m_txtInEffectDate.Focus();
                //m_objViewer.m_txtInEffectDate.SelectionStart = 0;

                //m_objViewer.m_cmdAddToList.Focus();
                m_objViewer.m_txtInvoiceNumber.Focus();
            }
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体



        /// <summary>
        /// 显示药品字典最小元素信息查询窗体

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {

                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict, true);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = m_objViewer.panel4.Location.X + m_objViewer.m_txtMedicineCode.Location.X;
                int Y = m_objViewer.panel4.Location.Y + m_objViewer.m_txtMedicineCode.Location.Y - m_ctlQueryMedicint.Size.Height;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            m_objViewer.m_txtMedicineCode.Focus();
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }


            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineCode;

            m_objViewer.m_txtMedicineName.Text = MS_VO.m_strMedicineName;
            m_objViewer.m_txtSpec.Text = MS_VO.m_strMedicineSpec;
            m_objViewer.m_txtUnit.Text = MS_VO.m_strMedicineUnit;
            m_objViewer.m_txtProducer.Text = MS_VO.m_strManufacturer;
            //20080704 生产厂家读取上次入库厂家
            string strProductor = string.Empty;
            m_objDomain.m_lngGetLastProductor(m_objViewer.m_strStorageID, MS_VO.m_strMedicineID, out strProductor);
            if (strProductor.Length > 0)
            {
                m_objViewer.m_txtProducer.Text = strProductor;
            }

            m_objDomain.m_lngGetMedicineTypeVisionm(MS_VO.m_strMedicineTypeID, out m_objViewer.m_clsTypeVisVO);
            //m_objViewer.m_txtLIMITUNITPRICE.Text = Convert.ToString(MS_VO.m_dbLimitunitPrice_mny);

            if (m_objViewer.m_intRetailMethod == 1)
            {
                m_objViewer.m_txtRetailUnitPrice.Text = MS_VO.m_dcmRetailPrice.ToString("0.0000");
            }
            m_objViewer.m_txtBuyInUnitPrice.Text = MS_VO.m_dcmTradePrice.ToString("0.0000");

            m_strCurrentMedicineTypeID = MS_VO.m_strMedicineTypeID;

            double dblRate = 0d;
            long lngRes = m_objDomain.m_lngGetGrossProfitRate(m_strCurrentMedicineTypeID, out dblRate);
            m_objViewer.m_txtGrossProfitRate.Text = dblRate.ToString("0.00");

            if (m_objViewer.iLimitunitPrice == 1)
            {
                m_objViewer.m_txtLastBuyInUnitPrice.Text = MS_VO.m_dbLimitunitPrice_mny.ToString("0.0000");
            }

            m_mthGetMedicinePrice();

            m_objViewer.m_txtScalar.Focus();

            m_objViewer.m_txtScalar.ReadOnly = false;
            m_objViewer.m_txtRetailUnitPrice.ReadOnly = false;

        }
        #endregion

        #region 检查数字类型控件内容是否都有效
        /// <summary>
        /// 检查数字类型控件内容是否都有效
        /// </summary>
        /// <returns></returns>
        internal bool m_blnCheckNum()
        {
            string RegexText = @"^(-?\d+)(\.\d+)?$";

            if (m_objViewer.m_txtScalar.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtScalar.Text.Trim(), RegexText))
                {
                    MessageBox.Show("药品数量必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtScalar.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtBuyInUnitPrice.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtBuyInUnitPrice.Text.Trim(), RegexText))
                {
                    MessageBox.Show("购入单价必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtBuyInUnitPrice.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtBuyInMomey.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtBuyInMomey.Text.Trim(), RegexText))
                {
                    MessageBox.Show("购入金额必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtBuyInMomey.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtWholeSaleUnitPrice.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtWholeSaleUnitPrice.Text.Trim(), RegexText))
                {
                    MessageBox.Show("批发单价必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtWholeSaleUnitPrice.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtWholeSaleMoney.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtWholeSaleMoney.Text.Trim(), RegexText))
                {
                    MessageBox.Show("批发金额必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtWholeSaleMoney.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtRetailUnitPrice.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtRetailUnitPrice.Text.Trim(), RegexText))
                {
                    MessageBox.Show("零售单价必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtRetailUnitPrice.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtRetailMoney.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtRetailMoney.Text.Trim(), RegexText))
                {
                    MessageBox.Show("零售金额必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtRetailMoney.Focus();
                    return false;
                }
            }

            if (m_objViewer.m_txtGrossProfitRate.Text.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(this.m_objViewer.m_txtGrossProfitRate.Text.Trim(), RegexText))
                {
                    MessageBox.Show("毛利率必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtGrossProfitRate.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 检查指定控件的内容是否均不为空
        /// <summary>
        /// 检查指定控件的内容是否均不为空
        /// </summary>
        /// <param name="p_ctlControls">指定控件</param>
        /// <returns></returns>
        internal bool m_blnCheckContentIsNotNull(Control[] p_ctlControls)
        {
            if (p_ctlControls == null)
            {
                return false;
            }

            for (int iCon = 0; iCon < p_ctlControls.Length; iCon++)
            {
                if (string.IsNullOrEmpty(p_ctlControls[iCon].Text))
                {
                    MessageBox.Show(p_ctlControls[iCon].AccessibleDescription + "不能为空", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (p_ctlControls[iCon].Parent == m_objViewer.panel4)
                    {
                        m_objViewer.panel4.Focus();
                    }
                    p_ctlControls[iCon].Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 添加数据至数据列表
        /// <summary>
        /// 添加数据至数据列表
        /// </summary>
        internal long m_lngAddDataToList()
        {
            if (!m_objViewer.panel1.Enabled)
            {
                MessageBox.Show("当前记录不允许修改", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (!m_blnCheckNum())
            {
                return -1;
            }

            Control[] ctlCheck = new Control[] { m_objViewer.m_txtScalar, m_objViewer.m_txtBuyInUnitPrice, m_objViewer.m_txtBuyInMomey ,
                m_objViewer.m_txtWholeSaleUnitPrice, m_objViewer.m_txtWholeSaleMoney, m_objViewer.m_txtRetailUnitPrice, m_objViewer.m_txtRetailMoney};
            if (!m_blnCheckContentIsNotNull(ctlCheck))
            {
                return -1;
            }
            DateTime datTemp;
            if (!DateTime.TryParse(m_objViewer.m_txtInEffectDate.Text, out datTemp))
            {
                MessageBox.Show("有效期不正确", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtInEffectDate.Focus();
                return -1;
            }
            // m_txtInEffectDate
            if (m_objViewer.m_clsTypeVisVO != null && (m_objViewer.m_clsTypeVisVO.m_intLotno == 1) && (m_objViewer.m_txtBatchNumber.Text.Trim() == ""))
            {
                MessageBox.Show("批号不能为空", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtBatchNumber.Focus();
                return -1;
            }


            if (m_objViewer.m_txtProviderName.Tag == null)
            {
                MessageBox.Show("供应商不能为空", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtProviderName.Focus();
                return -1;
            }

            if (m_objViewer.m_txtMedicineCode.Tag == null)
            {
                MessageBox.Show("药品代码不能为空", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtMedicineCode.Focus();
                return -1;
            }

            if (m_objViewer.m_dgvMedicineDetail.Rows.Count > 0)
            {
                if (m_objViewer.m_blnAddedRowsHasPoisonOrChlorpromazine && !m_objViewer.m_blnCurrenIsPoisonOrChlorpromazine)
                {
                    MessageBox.Show("当前药品为毒、麻类药品，不能与其它药品保存在同一入库单", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtMedicineCode.Focus();
                    return -1;

                }
                else if (!m_objViewer.m_blnAddedRowsHasPoisonOrChlorpromazine && m_objViewer.m_blnCurrenIsPoisonOrChlorpromazine)
                {
                    MessageBox.Show("当前药品为普通药品，不能与毒、麻类药品保存在同一入库单", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtMedicineCode.Focus();
                    return -1;
                }
            }

            m_objViewer.m_blnAddedRowsHasPoisonOrChlorpromazine = m_objViewer.m_blnCurrenIsPoisonOrChlorpromazine;

            if (m_objViewer.m_dgvMedicineDetail.Rows.Count > 0)
            {
                int intCurrentRow = -1;
                if (m_objViewer.m_drSelectedRow != null)//只有在修改时才需要判断是否为其本身
                {
                    intCurrentRow = m_objViewer.m_dgvMedicineDetail.CurrentCell.RowIndex;
                }
                for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineDetail.Rows.Count; iRow++)
                {
                    //同一张入库单内药品编码、批号、购入价、有效期认为是同一个药品

                    if (m_objViewer.m_dgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtLotNO"].Value.ToString() == m_objViewer.m_txtBatchNumber.Text
                        && m_objViewer.m_dgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtMedicineCode"].Value.ToString() == m_objViewer.m_txtMedicineCode.Text
                        && Convert.ToDouble(m_objViewer.m_dgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtBuyPrice"].Value) == Convert.ToDouble(m_objViewer.m_txtBuyInUnitPrice.Text)
                        && Convert.ToDateTime(m_objViewer.m_dgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtValidity"].Value) == Convert.ToDateTime(m_objViewer.m_txtInEffectDate.Text)
                        && intCurrentRow != iRow)
                    {
                        double dblOldAmount = Convert.ToDouble(m_objViewer.m_dgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtAmount"].Value);
                        double dblNowAmount = Convert.ToDouble(m_objViewer.m_txtScalar.Text);
                        DialogResult drResult = MessageBox.Show("已存在同一批号的同一药品，是否将数量添加至已录入的记录中？", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drResult == DialogResult.No)
                        {
                            return -1;
                        }
                        else
                        {
                            ((DataRowView)m_objViewer.m_dgvMedicineDetail.Rows[iRow].DataBoundItem).Row.BeginEdit();
                            ((DataRowView)m_objViewer.m_dgvMedicineDetail.Rows[iRow].DataBoundItem).Row["Amount"] = (dblOldAmount + dblNowAmount).ToString("0.00");
                            ((DataRowView)m_objViewer.m_dgvMedicineDetail.Rows[iRow].DataBoundItem).Row.EndEdit();

                            //m_objViewer.m_dgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtAmount"].Value = (dblOldAmount + dblNowAmount).ToString("0.00");
                            if (m_objViewer.m_drSelectedRow != null)//删除已合并后的行
                            {
                                long lngSeq = 0;
                                if (long.TryParse(m_objViewer.m_drSelectedRow["SERIESID_INT"].ToString(), out lngSeq))
                                {
                                    //m_objDomain.m_lngDeleteInStorage(-1, lngSeq);
                                    m_lstWantDeleteSEQ.Add(lngSeq);
                                }
                                m_objViewer.m_dtbMedicineInfo.Rows.Remove(m_objViewer.m_drSelectedRow);
                            }
                            m_mthClearMedicinInfo();
                            m_objViewer.m_txtMedicineCode.Focus();
                            return 1;
                        }
                    }
                }
            }

            if (m_objViewer.m_drSelectedRow == null)
            {
                DataRow drCurrent = m_objViewer.m_dtbMedicineInfo.NewRow();
                m_mthGetRowDataFromUI(drCurrent);

                m_objViewer.m_dtbMedicineInfo.Rows.Add(drCurrent);
                drCurrent["SortNum"] = m_objViewer.m_dtbMedicineInfo.Rows.Count;
            }
            else
            {
                m_mthGetRowDataFromUI(m_objViewer.m_drSelectedRow);
            }

            m_mthClearMedicinInfo();
            m_objViewer.m_txtMedicineCode.Focus();
            m_objViewer.bolAdjustrice = false;
            return 1;
        }

        #endregion

        #region 从界面生成数据行
        /// <summary>
        /// 从界面生成数据行
        /// </summary>
        /// <param name="drCurrent">数据行</param>
        private void m_mthGetRowDataFromUI(DataRow drCurrent)
        {
            drCurrent["MEDICINEID_CHR"] = m_objViewer.m_txtMedicineCode.Tag.ToString();
            drCurrent["MedicineCode"] = m_objViewer.m_txtMedicineCode.Text;
            drCurrent["MEDICINENAME_VCH"] = m_objViewer.m_txtMedicineName.Text;
            drCurrent["MEDSPEC_VCHR"] = m_objViewer.m_txtSpec.Text;
            drCurrent["AMOUNT"] = m_objViewer.m_txtScalar.Text;
            drCurrent["UNIT_VCHR"] = m_objViewer.m_txtUnit.Text;
            drCurrent["invoicecode_vchr"] = m_objViewer.m_txtInvoiceNumber.Text.Trim();
            drCurrent["invoicedater_dat"] = m_objViewer.m_txtInvoiceDate.Text;
            drCurrent["PRODUCEDATE_DAT"] = m_objViewer.m_txtProduceDate.Text;
            //if (m_objViewer.m_txtBatchNumber.Text.Trim() == "")
            //{
            //    drCurrent["LOTNO_VCHR"] = "UNKNOWN";
            //}
            //else
            //{
            drCurrent["LOTNO_VCHR"] = m_objViewer.m_txtBatchNumber.Text;
            //}
            drCurrent["CALLPRICE_INT"] = m_objViewer.m_txtBuyInUnitPrice.Text;
            drCurrent["INMONEY"] = m_objViewer.m_txtBuyInMomey.Text;
            drCurrent["WHOLESALEPRICE_INT"] = m_objViewer.m_txtWholeSaleUnitPrice.Text;
            drCurrent["RETAILPRICE_INT"] = m_objViewer.m_txtRetailUnitPrice.Text;
            drCurrent["SALEMONEY"] = m_objViewer.m_txtRetailMoney.Text;
            drCurrent["PRODUCTORID_CHR"] = m_objViewer.m_txtProducer.Text;
            drCurrent["VALIDPERIOD_DAT"] = m_objViewer.m_txtInEffectDate.Text;
            drCurrent["WHOLESALEMONEY"] = m_objViewer.m_txtWholeSaleMoney.Text;
            drCurrent["GROSSPROFITRATE_INT"] = m_objViewer.m_txtGrossProfitRate.Text;
            drCurrent["LIMITUNITPRICE_MNY"] = m_objViewer.m_txtLastBuyInUnitPrice.Text;
            drCurrent["medicinetypeid_chr"] = m_strCurrentMedicineTypeID;
            drCurrent["typecode_vchr"] = m_objViewer.m_intInstorageType;
            if (m_objCurrentACInfo != null)
            {
                drCurrent["ACCEPTANCE_INT"] = m_objCurrentACInfo.m_intBid;
                if (m_objCurrentACInfo.m_intBid == 1)
                {
                    drCurrent["ACCEPTANCENAME"] = "是";
                }
                else if (m_objCurrentACInfo.m_intBid == 0)
                {
                    drCurrent["ACCEPTANCENAME"] = "否";
                }
                else
                {
                    drCurrent["ACCEPTANCENAME"] = string.Empty;
                }

                drCurrent["APPROVECODE_VCHR"] = m_objCurrentACInfo.m_strApproveCode;
                drCurrent["APPARENTQUALITY_INT"] = m_objCurrentACInfo.m_intApparentQuality;
                drCurrent["PACKQUALITY_INT"] = m_objCurrentACInfo.m_intPackQuality;
                drCurrent["EXAMRUSULT_INT"] = m_objCurrentACInfo.m_intExamResult;
                drCurrent["EXAMINER"] = m_objCurrentACInfo.m_strExamerID;
                drCurrent["EXAMRUSULTNAME"] = m_objCurrentACInfo.m_strExamerName;
                drCurrent["ACCEPTANCECOMPANY_CHR"] = m_objCurrentACInfo.m_strBidCompany;
                drCurrent["ACCEPTANCECOMPANYName"] = m_objCurrentACInfo.m_strBidCompanyName;
                drCurrent["gmpflag_int"] = m_objCurrentACInfo.m_intGMPFlag;
                drCurrent["trademark_vchr"] = m_objCurrentACInfo.m_strTrademark;
            }
            if (m_objCurrentPCInfo != null)
            {
                drCurrent["PACKAMOUNT"] = m_objCurrentPCInfo.m_dblPackAmount;
                drCurrent["PACKUNIT_VCHR"] = m_objCurrentPCInfo.m_strPackUnit;
                drCurrent["PACKCALLPRICE_INT"] = m_objCurrentPCInfo.m_dcmPackPrice;
                drCurrent["PACKCONVERT_INT"] = m_objCurrentPCInfo.m_dblPackConvert;
            }
            else
            {
                //DataTable m_dtbPack;
                //((clsDcl_Purchase_Detail)m_objDomain).m_lngGetPack(m_objViewer.m_txtMedicineCode.Tag.ToString(), out m_dtbPack);
                //if (m_dtbPack.Rows.Count > 0)
                //{
                //    drCurrent["PACKAMOUNT"] = m_dtbPack.Rows[0]["packqty_dec"];
                //    drCurrent["PACKUNIT_VCHR"] = m_dtbPack.Rows[0]["ipunit_chr"];
                //    drCurrent["PACKCALLPRICE_INT"] = Convert.ToDecimal(m_dtbPack.Rows[0]["packqty_dec"])*Convert.ToDecimal(m_objViewer.m_txtScalar.Text);
                //    drCurrent["PACKCONVERT_INT"] = Convert.ToDouble(m_objViewer.m_txtBuyInUnitPrice.Text) / Convert.ToDouble(m_dtbPack.Rows[0]["packqty_dec"]);
                //}
            }
            if (m_objViewer.m_intInstorageType == 3)//20080228
            {
                DataTable m_dtbPack;
                ((clsDcl_Purchase_Detail)m_objDomain).m_lngGetPack(m_objViewer.m_txtMedicineCode.Tag.ToString(), out m_dtbPack);
                if (m_dtbPack.Rows.Count > 0)
                {
                    drCurrent["PackQty_Dec"] = m_dtbPack.Rows[0]["packqty_dec"];
                }
            }
        }
        #endregion

        #region 显示药品验收情况
        /// <summary>
        /// 显示药品验收情况
        /// </summary>
        internal long m_lngShowAcceptanceCheck()
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null)
            {
                MessageBox.Show("请先选择药品", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtMedicineCode.Focus();
                return -1;
            }
            frmAcceptanceCheck frmAC = new frmAcceptanceCheck(m_objViewer.m_txtMedicineCode.Tag.ToString(), m_dtbVendor);
            frmAC.Location = new System.Drawing.Point(m_objViewer.panel4.Location.X + m_objViewer.Location.X + m_objViewer.m_txtMedicineCode.Location.X,
                m_objViewer.panel4.Location.Y - frmAC.Size.Height + m_objViewer.Location.Y + m_objViewer.m_txtMedicineCode.Location.Y + 35);
            frmAC.FormClosed += new FormClosedEventHandler(frmAC_FormClosed);

            // 如果验收员为空,则设置最近一次的验收员为默认值.
            if (m_objCurrentACInfo != null)
            {
                if (string.IsNullOrEmpty(m_objCurrentACInfo.m_strExamerID) == false && string.IsNullOrEmpty(m_objCurrentACInfo.m_strExamerName))
                {
                    long lngRes = 0;
                    DataTable dtbEmp = null;
                    clsEMR_EmployeeManagerService objSvc = (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService));
                    lngRes = objSvc.m_lngGetEmp(m_objCurrentACInfo.m_strExamerID, out dtbEmp);
                    if (lngRes > 0)
                        m_objCurrentACInfo.m_strExamerName = dtbEmp.Rows[0][3].ToString();
                }
                else if (string.IsNullOrEmpty(m_objCurrentACInfo.m_strExamerID))
                {
                    string strExaminerID;
                    string strExaminerName;

                    m_objDomain.m_lngGetLatestExaminer(m_objViewer.m_strStorageID, out strExaminerID, out strExaminerName);
                    m_objCurrentACInfo.m_strExamerID = strExaminerID;
                    m_objCurrentACInfo.m_strExamerName = strExaminerName;
                }
            }
            else if (m_objCurrentACInfo == null)
            {
                m_objCurrentACInfo = new clsMS_AcceptanceCheck_VO();
                string strExaminerID;
                string strExaminerName;

                m_objDomain.m_lngGetLatestExaminer(m_objViewer.m_strStorageID, out strExaminerID, out strExaminerName);
                m_objCurrentACInfo.m_strExamerID = strExaminerID;
                m_objCurrentACInfo.m_strExamerName = strExaminerName;
                m_objCurrentACInfo.m_intApparentQuality = 1;
                m_objCurrentACInfo.m_intBid = 1;
                m_objCurrentACInfo.m_intExamResult = 1;
                m_objCurrentACInfo.m_intPackQuality = 1;
                m_objCurrentACInfo.m_intGMPFlag = 1;
            }
            // 设置供应商.
            if (m_objViewer.m_txtProviderName.Tag != null)
            {
                m_objCurrentACInfo.m_strBidCompany = m_objViewer.m_txtProviderName.Tag.ToString();
                m_objCurrentACInfo.m_strBidCompanyName = m_objViewer.m_txtProviderName.Text;
            }

            frmAC.m_mthSetACVOToUI(m_objCurrentACInfo);
            // frmAC.TopMost = true;
            frmAC.ShowDialog();
            return 1;
        }

        internal void frmAC_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAcceptanceCheck frmAC = sender as frmAcceptanceCheck;
            if (frmAC.DialogResult == DialogResult.OK)
            {
                m_objCurrentACInfo = frmAC.m_objACVO;
            }
            m_objViewer.m_cmdAddToList.Focus();
        }
        #endregion

        #region 清空药品信息
        /// <summary>
        /// 清空药品信息
        /// </summary>
        internal void m_mthClearMedicinInfo()
        {
            m_objViewer.m_txtMedicineCode.Clear();
            m_objViewer.m_txtMedicineCode.Tag = null;
            m_objViewer.m_txtMedicineName.Clear();
            m_objViewer.m_txtSpec.Clear();
            m_objViewer.m_txtScalar.Clear();
            m_objViewer.m_lblPackAmount.Tag = null;
            m_objViewer.m_txtUnit.Clear();
            m_objViewer.m_lblPackUnit.Tag = null;
            m_objViewer.m_txtBatchNumber.Clear();
            m_objViewer.m_lblPackSalePrice.Tag = null;
            m_objViewer.m_txtBuyInUnitPrice.Clear();
            m_objViewer.m_txtBuyInMomey.Clear();
            m_objViewer.m_txtWholeSaleUnitPrice.Clear();
            m_objViewer.m_txtWholeSaleMoney.Clear();
            m_objViewer.m_txtRetailUnitPrice.Clear();
            m_objViewer.m_txtRetailMoney.Clear();
            m_objViewer.m_txtProducer.Clear();
            m_objViewer.m_txtBalance.Clear();
            m_objCurrentACInfo = null;
            m_objCurrentPCInfo = null;

            m_objViewer.m_txtAvgBuyInUnitPrice.Clear();
            m_objViewer.m_txtLastWholeSaleUnitPrice.Clear();
            m_objViewer.m_txtLastRetailUnitPrice.Clear();
            m_objViewer.m_txtLastBuyInUnitPrice.Clear();
            m_objViewer.m_txtGrossProfitRate.Clear();

            m_strCurrentMedicineTypeID = string.Empty;
            m_objViewer.m_drSelectedRow = null;
            m_objViewer.bolAdjustrice = false;

            m_objViewer.m_txtMedicineCode.Enabled = true;
            m_objViewer.m_txtScalar.ReadOnly = false;
            m_objViewer.m_txtRetailUnitPrice.ReadOnly = false;
            m_objViewer.m_txtBuyInUnitPrice.ReadOnly = false;
            m_objViewer.m_txtInvoiceDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_objViewer.m_txtProduceDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        }
        #endregion

        #region 检查数量是否有效


        /// <summary>
        /// 检查数量是否有效

        /// </summary>
        /// <returns></returns>
        internal long m_lngCheckAmount()
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null || m_objViewer.m_txtMedicineCode.Focused)
            {
                return 1;
            }
            decimal dblScalar = 0m;

            if (string.IsNullOrEmpty(m_objViewer.m_txtScalar.Text))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("请先填写药品数量", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtScalar.Focus();
                m_objViewer.IsShowBox = false;
                return -1;
            }

            if (!decimal.TryParse(m_objViewer.m_txtScalar.Text, out dblScalar))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("药品数量必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtScalar.Focus();
                m_objViewer.IsShowBox = false;
                return -1;
            }

            //if (dblScalar <= 0)
            //{
            //    m_objViewer.IsShowBox = true;
            //    MessageBox.Show("药品数量必须大于零", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    m_objViewer.m_txtScalar.Focus();
            //    m_objViewer.IsShowBox = false;
            //    return -1;
            //}

            return 1;
        }
        #endregion

        #region 生成购入金额
        /// <summary>
        /// 生成购入金额
        /// </summary>
        internal void m_mthSetBuyInMomey(object p_objSender)
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null || m_objViewer.m_txtMedicineCode.Focused)
            {
                return;
            }
            decimal dblScalar = 0m;
            decimal dcmBuyInunitPrice = 0m;

            if (!decimal.TryParse(m_objViewer.m_txtScalar.Text, out dblScalar))
            {
                return;
            }

            if (!string.IsNullOrEmpty(m_objViewer.m_txtBuyInMomey.Text) && m_objCurrentPCInfo != null && m_objCurrentPCInfo.m_dcmPackPrice > 0 && m_objCurrentPCInfo.m_dblPackAmount > 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(m_objViewer.m_txtBuyInUnitPrice.Text))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("请先填写购入单价", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtBuyInUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            if (!decimal.TryParse(m_objViewer.m_txtBuyInUnitPrice.Text, out dcmBuyInunitPrice))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("购入单价必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtBuyInUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            if (p_objSender != null && dcmBuyInunitPrice <= 0)
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("购入单价必须大于零", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtBuyInUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            m_objViewer.m_txtBuyInMomey.Text = (dblScalar * dcmBuyInunitPrice).ToString("0.0000");
        }
        #endregion

        #region 生成批发金额
        /// <summary>
        /// 生成批发金额
        /// </summary>
        internal void m_mthSetWholeSaleMoney()
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null)
            {
                return;
            }
            decimal dblScalar = 0m;
            decimal dcmWholeSaleunitPrice = 0m;

            if (!decimal.TryParse(m_objViewer.m_txtScalar.Text, out dblScalar))
            {
                return;
            }

            if (string.IsNullOrEmpty(m_objViewer.m_txtWholeSaleUnitPrice.Text))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("请先填写批发单价", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtWholeSaleUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            if (!decimal.TryParse(m_objViewer.m_txtWholeSaleUnitPrice.Text, out dcmWholeSaleunitPrice))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("批发单价必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtWholeSaleUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            if (dcmWholeSaleunitPrice <= 0 && m_intShowWholePrice != 0)
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("批发单价必须大于零", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtWholeSaleUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            m_objViewer.m_txtWholeSaleMoney.Text = (dblScalar * dcmWholeSaleunitPrice).ToString("0.0000");
        }
        #endregion

        #region 生成零售金额
        /// <summary>
        /// 生成零售金额
        /// </summary>
        internal void m_mthSetRetailMoney()
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null)
            {
                return;
            }
            decimal dblScalar = 0m;
            decimal dcmRetailunitPrice = 0m;

            if (!decimal.TryParse(m_objViewer.m_txtScalar.Text, out dblScalar))
            {
                return;
            }

            if (string.IsNullOrEmpty(m_objViewer.m_txtRetailUnitPrice.Text))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("请先填写零售单价", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtRetailUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            if (!decimal.TryParse(m_objViewer.m_txtRetailUnitPrice.Text, out dcmRetailunitPrice))
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("零售单价必须为数字", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtRetailUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }

            if (dcmRetailunitPrice < 0)
            {
                m_objViewer.IsShowBox = true;
                MessageBox.Show("零售单价不能小于零", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtRetailUnitPrice.Focus();
                m_objViewer.IsShowBox = false;
                return;
            }
            m_objViewer.m_txtRetailMoney.Text = (dblScalar * dcmRetailunitPrice).ToString("0.0000");
        }
        #endregion

        #region 初始化药品信息表
        /// <summary>
        /// 初始化药品信息表
        /// </summary>
        /// <returns></returns>
        internal DataTable m_dtbInitTable()
        {
            DataTable dtbMedicine = new DataTable();
            dtbMedicine.Columns.AddRange(new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCH"),
                new DataColumn("MEDSPEC_VCHR"), new DataColumn("PACKAMOUNT"), new DataColumn("PACKUNIT_VCHR"),new DataColumn("PACKCALLPRICE_INT"),new DataColumn("PACKCONVERT_INT"),new DataColumn("LOTNO_VCHR"),
                new DataColumn("AMOUNT"), new DataColumn("CALLPRICE_INT"), new DataColumn("WHOLESALEPRICE_INT"), new DataColumn("RETAILPRICE_INT"), new DataColumn("VALIDPERIOD_DAT"),new DataColumn("ACCEPTANCE_INT"),
                new DataColumn("APPROVECODE_VCHR"), new DataColumn("APPARENTQUALITY_INT"), new DataColumn("PACKQUALITY_INT"), new DataColumn("EXAMRUSULT_INT"), new DataColumn("EXAMINER"), new DataColumn("PRODUCTORID_CHR"),
                new DataColumn("ACCOUNTPERIOD_INT"), new DataColumn("ACCEPTANCECOMPANY_CHR"), new DataColumn("ACCEPTANCECOMPANYname"), new DataColumn("examinername"),new DataColumn("ACCEPTANCENAME"),new DataColumn("medicinetypeid_chr"),
                new DataColumn("APPARENTQUALITYNAME"), new DataColumn("PACKQUALITYNAME"), new DataColumn("EXAMRUSULTNAME"), new DataColumn("UNIT_VCHR"), new DataColumn("INMONEY"), new DataColumn("SALEMONEY"), 
                new DataColumn("SortNum"), new DataColumn("MedicineCode"),new DataColumn("WHOLESALEMONEY"),new DataColumn("MEDICINEPREPTYPE_CHR"),new DataColumn("GROSSPROFITRATE_INT"),new DataColumn("LIMITUNITPRICE_MNY"),
                new DataColumn("invoicecode_vchr"),new DataColumn("invoicedater_dat"),new DataColumn("gmpflag_int"),new DataColumn("trademark_vchr"),new DataColumn("typecode_vchr"),new DataColumn("PRODUCEDATE_DAT"),new DataColumn("PackQty_Dec")});
            return dtbMedicine;
        }
        #endregion

        #region 获取是否显示包装/基本单位换算
        /// <summary>
        /// 获取是否显示包装/基本单位换算
        /// </summary>
        /// <param name="p_blnIsSetDefault">是否显示</param>
        /// <returns></returns>
        internal void m_mthGetIsShowUnitConviersionSetting(out bool p_blnIsSetDefault)
        {
            long lngRes = m_objDomain.m_lngGetIsShowUnitConviersionSetting(out p_blnIsSetDefault);
        }
        #endregion

        #region 获取是否显示中标验货信息
        /// <summary>
        /// 获取是否显示中标验货信息
        /// </summary>
        /// <param name="p_blnIsSetDefault">是否显示</param>
        /// <returns></returns>
        internal void m_mthGetIsShowAcceptanceCheck(out bool p_blnIsSetDefault)
        {
            long lngRes = m_objDomain.m_lngGetIsShowAcceptanceCheck(out p_blnIsSetDefault);
        }
        #endregion

        #region 获取生成零售价方式


        /// <summary>
        /// 获取生成零售价方式


        /// </summary>
        /// <param name="p_intRetailMethod">生成零售价方式</param>
        /// <returns></returns>
        internal void m_mthGetRetailMethod(out int p_intRetailMethod)
        {
            long lngRes = m_objDomain.m_lngGetRetailMethod(out p_intRetailMethod);
        }
        #endregion

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            long lngRes = m_objDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        #region 获取是否审核即入帐
        /// <summary>
        /// 获取是否审核即入帐
        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        internal void m_mthGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            long lngRes = m_objDomain.m_lngGetIsImmAccount(out p_blnIsImmAccount);
        }
        #endregion

        #region 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// </summary>
        /// <param name="m_intCanModifyMakeDate">是否允许修改</param>
        internal void m_lngGetCanModifyMakeDate(out int m_intCanModifyMakeDate)
        {
            m_objDomain.m_lngGetCanModifyMakeDate(out m_intCanModifyMakeDate);
        }
        #endregion

        #region 设置零售价


        /// <summary>
        /// 设置零售价


        /// </summary>
        /// <param name="p_dcmBuyIn">购入价</param>
        internal void m_mthSetRetailPrice(decimal p_dcmBuyIn)
        {
            if (m_objViewer.m_txtMedicineCode.Tag != null)
            {
                if (m_objViewer.m_intRetailMethod == 2)
                {
                    double dblRate = 15.00d;
                    if (string.IsNullOrEmpty(m_strCurrentMedicineTypeID) && m_objViewer.m_drSelectedRow != null)
                    {
                        m_strCurrentMedicineTypeID = m_objViewer.m_drSelectedRow["medicinetypeid_chr"].ToString();
                    }
                    long lngRes = m_objDomain.m_lngGetGrossProfitRate(m_strCurrentMedicineTypeID, out dblRate);
                    double dblRetailMoney = 0d;//(double)p_dcmBuyIn * (1 + dblRate / 100);
                    dblRetailMoney = clsCtl_Public.m_mthMathPayment(this.m_objViewer.m_strStorageID, (double)p_dcmBuyIn, dblRate);
                    m_objViewer.m_txtRetailUnitPrice.Text = dblRetailMoney.ToString("0.0000");

                    double dblAmount = 0d;
                    if (double.TryParse(m_objViewer.m_txtScalar.Text, out dblAmount))
                    {
                        m_objViewer.m_txtRetailMoney.Text = (dblRetailMoney * dblAmount).ToString("0.0000");
                    }
                }
            }
        }
        #endregion

        #region 显示包装/基本单位换算
        /// <summary>
        /// 显示包装/基本单位换算
        /// </summary>
        internal long m_lngShowPackConversion()
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null)
            {
                MessageBox.Show("请先选择药品", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtMedicineCode.Focus();
                return -1;
            }
            if (string.IsNullOrEmpty(m_objViewer.m_txtUnit.Text) && m_objViewer.m_txtMedicineCode.Tag != null)
            {
                MessageBox.Show("请先填写基本单位", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtMedicineCode.Focus();
                return -1;
            }
            frmPackConversion frmPC = null;
            if (m_objCurrentPCInfo == null)
            {
                frmPC = new frmPackConversion(m_objViewer.m_txtUnit.Text, m_objViewer.m_txtMedicineCode.Tag.ToString());
            }
            else
            {
                frmPC = new frmPackConversion(m_objCurrentPCInfo.m_strUnit, m_objViewer.m_txtMedicineCode.Tag.ToString());
            }
            frmPC.Location = new System.Drawing.Point(m_objViewer.panel4.Location.X + m_objViewer.Location.X + m_objViewer.m_txtScalar.Location.X,
                m_objViewer.panel4.Location.Y - frmPC.Size.Height + m_objViewer.Location.Y + m_objViewer.m_txtScalar.Location.Y + 35);
            frmPC.FormClosed += new FormClosedEventHandler(frmPC_FormClosed);
            frmPC.m_mthSetPCVOToUI(m_objCurrentPCInfo);
            //frmPC.TopMost = true;
            frmPC.ShowDialog();
            return 1;
        }

        private void frmPC_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPackConversion frmPC = sender as frmPackConversion;

            if (frmPC.DialogResult == DialogResult.OK)
            {
                m_objCurrentPCInfo = frmPC.m_objPC_VO;

                if (m_objCurrentPCInfo != null && m_objCurrentPCInfo.m_dblPackAmount > 0 && m_objCurrentPCInfo.m_dcmPackPrice > 0)
                {
                    m_objViewer.m_txtBuyInMomey.Text = (m_objCurrentPCInfo.m_dblPackAmount * (double)m_objCurrentPCInfo.m_dcmPackPrice).ToString("0.0000");
                }
            }
        }
        #endregion

        #region 保存当前入库信息
        /// <summary>
        /// 保存当前入库信息
        /// </summary>
        internal long m_lngSaveInStorage()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1)
            {

                if (bolAddOutMedicineInfo)
                {
                    //如果是即入即出,在此进行退审操作


                    m_mthUnCommitInOut();

                }

                if (m_objCurrentMain.m_intSTATE_INT == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品入库记录已入帐，不能修改", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品入库记录已审核，不能修改", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1 && m_objCurrentMain.m_intSTATE_INT != 0)
            {
                m_objViewer.m_blnHasCommit = true;
            }

            if (m_objViewer.m_blnHasCommit && m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT == 2 && !bolAddOutMedicineInfo)
            {
                clsDcl_Purchase objMainDomain = new clsDcl_Purchase();
                bool blnHasDone = false;
                string strOtherID = string.Empty;
                long lngCheck = objMainDomain.m_lngCheckHasDoneAfterInStorage(m_objCurrentMain.m_strINSTORAGEID_VCHR, out blnHasDone, out strOtherID);
                objMainDomain = null;

                if (blnHasDone)
                {
                    MessageBox.Show("此入库单药品已出库，不能再作修改", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            if (m_objViewer.m_dtbMedicineInfo.Rows.Count == 0)
            {
                MessageBox.Show("请先录入药品信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.panel4.Focus();
                return -1;
            }

            //if (m_objViewer.m_dtbMedicineInfo.Rows.Count == 0)
            //{
            //    MessageBox.Show("请先录入药品信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    m_objViewer.panel4.Focus();
            //    return -1;
            //}

            DateTime datOutTime;
            m_objDomain.m_mthGetAccountperiodTime(out datOutTime);
            if (Convert.ToDateTime(m_objViewer.m_dtpInComeDate.Tag) < datOutTime)
            {
                MessageBox.Show("入库日期不能小于上次帐务结转的结束日期。\r\n上次结转结束日期是：" + datOutTime.ToString("yyyy年MM月dd日"), "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_dtpInComeDate.Focus();
                return -1;
            }


            if (bolAddOutMedicineInfo && (m_objViewer.m_txtExportDept.StrItemId == "" || m_objViewer.m_txtExportDept.Text.Trim() == ""))
            {
                MessageBox.Show("请先录入领用部门", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtExportDept.Focus();
                return -1;
            }
            if (m_objViewer.m_txtMedicineCode.Tag != null)
            {
                long lngCheckSub = m_lngAddDataToList();
                if (lngCheckSub <= 0)
                {
                    return -1;
                }
                m_mthGetAllMoney();
                m_objViewer.m_drSelectedRow = null;
            }

            long lngRes = 0;
            if (m_lstWantDeleteSEQ.Count > 0)
            {
                lngRes = m_objDomain.m_lngDeleteInStorage(-1, m_lstWantDeleteSEQ.ToArray());//删除已被合并的药品

                if (lngRes <= 0)
                {
                    return -1;
                }
                m_lstWantDeleteSEQ.Clear();
            }

            long lngMainSeq = 0;//主表序列
            bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
            bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
            string strInStorageID = string.Empty;//入库单据号

            clsMS_InStorage_VO objMain = m_objGetMainISVO();

            DataTable dtbNew = m_objViewer.m_dtbMedicineInfo.GetChanges(DataRowState.Added);
            clsMS_InStorageDetail_VO[] objDetailNew = m_objGetNewDetail(dtbNew, objMain.m_strINSTORAGEID_VCHR);

            DataTable dtbModify = m_objViewer.m_dtbMedicineInfo;
            clsMS_InStorageDetail_VO[] objDetailModify = m_objGetNewDetail(dtbModify, objMain.m_strINSTORAGEID_VCHR);

            //if (dtbModify == null)
            //{
            //    dtbModify = m_objViewer.m_dtbMedicineInfo.GetChanges(DataRowState.Detached);
            //    objDetailModify = m_objGetNewDetail(dtbModify, objMain.m_strINSTORAGEID_VCHR);
            //}

            clsMS_StorageDetail[] objStDetail = null;
            clsMS_InStorageDetail_VO[] objDetailAll = null;
            if (m_objViewer.m_intCommitFolow == 1)
            {
                objDetailAll = m_objGetNewDetail(m_objViewer.m_dtbMedicineInfo, objMain.m_strINSTORAGEID_VCHR);
                objStDetail = m_objDetailVO(objDetailAll, objMain.m_strINSTORAGEID_VCHR, objMain.m_dtmINSTORAGEDATE_DAT, objMain.m_strVENDORID_CHR, objMain.m_strVENDORName);
            }
            //添加出库记录
            if (bolAddOutMedicineInfo && blnIsCommit)
            {
                clsMS_OutStorage_VO objOutMain = m_objGetOutMainISVO();
                DataRow[] drOutNew = m_objViewer.m_dtbMedicineInfo.Select("amount is not null");
                clsMS_OutStorageDetail_VO[] objDetailArr = m_objGetDetailArr(drOutNew, objMain.m_lngSERIESID_INT);
                clsMS_OutStorageDetail_VO[] m_objCurrentSubArr = null;
                lngRes = m_objDomain.m_lngSaveInStorage(objMain, ref objDetailNew, objDetailModify, objDetailAll, objStDetail, blnIsAddNew, m_objViewer.m_blnHasCommit, blnIsCommit, m_objViewer.m_blnIsImmAccount, out lngMainSeq, out strInStorageID, ref objOutMain, m_objCurrentSubArr, ref objDetailArr, false);
            }
            else
            {
                lngRes = m_objDomain.m_lngSaveInStorage(objMain, ref objDetailNew, objDetailModify, objDetailAll, objStDetail, blnIsAddNew, m_objViewer.m_blnHasCommit, blnIsCommit, m_objViewer.m_blnIsImmAccount, out lngMainSeq, out strInStorageID);
            }
            if (lngRes > -1)
            {
                m_objViewer.m_lngMainSEQ = lngMainSeq;
                objMain.m_lngSERIESID_INT = lngMainSeq;
                objMain.m_strINSTORAGEID_VCHR = strInStorageID;
                m_objViewer.m_txtIncomeBillNumber.Text = strInStorageID;
                m_objCurrentMain = objMain;

                if (m_objViewer.m_intCommitFolow == 1)
                {
                    m_objViewer.m_blnHasCommit = true;
                }

                DataRow[] drNew = m_objViewer.m_dtbMedicineInfo.Select("SERIESID_INT is null");
                if (drNew != null && drNew.Length > 0 && drNew.Length == objDetailNew.Length)
                {
                    for (int iRow = 0; iRow < drNew.Length; iRow++)
                    {
                        drNew[iRow]["SERIESID_INT"] = objDetailNew[iRow].m_lngSERIESID_INT;
                        drNew[iRow]["SERIESID2_INT"] = objDetailNew[iRow].m_lngSERIESID_INT2;
                    }
                }
                m_objViewer.m_dtbMedicineInfo.AcceptChanges();


                MessageBox.Show("保存成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (blnIsCommit && m_objViewer.m_blnIsImmAccount)
                {
                    if (m_objViewer.m_blnIsImmAccount)
                    {
                        m_objCurrentMain.m_intSTATE_INT = 3;

                        m_objViewer.panel1.Enabled = false;
                    }
                    else
                    {
                        m_objCurrentMain.m_intSTATE_INT = 2;

                        m_objViewer.panel1.Enabled = true;
                    }
                }
                return 1;
            }
            else
            {
                MessageBox.Show("保存失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// 获取主表VO
        /// </summary>
        /// <returns></returns>
        private clsMS_InStorage_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_InStorage_VO();
                m_objCurrentMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATE_INT = 1;
            }
            m_objCurrentMain.m_lngSERIESID_INT = m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strINSTORAGEID_VCHR = m_objViewer.m_txtIncomeBillNumber.Text;
            m_objCurrentMain.m_strVENDORID_CHR = m_objViewer.m_txtProviderName.Tag.ToString();
            m_objCurrentMain.m_strVENDORName = m_objViewer.m_txtProviderName.Text;
            m_objCurrentMain.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(m_objViewer.m_dtpInComeDate.Text);

            if (m_objViewer.m_txtPurchasePerson.Tag != null)
            {
                m_objCurrentMain.m_strBUYERID_CHAR = m_objViewer.m_txtPurchasePerson.Tag.ToString();
            }
            else
            {
                m_objCurrentMain.m_strBUYERID_CHAR = string.Empty;
            }

            if (m_objViewer.m_txtStroehouseManager.Tag != null)
            {
                m_objCurrentMain.m_strSTORAGERID_CHAR = m_objViewer.m_txtStroehouseManager.Tag.ToString();
            }
            else
            {
                m_objCurrentMain.m_strSTORAGERID_CHAR = string.Empty;
            }

            if (m_objViewer.m_txtAccountant.Tag != null)
            {
                m_objCurrentMain.m_strACCOUNTERID_CHAR = m_objViewer.m_txtAccountant.Tag.ToString();
            }
            else
            {
                m_objCurrentMain.m_strACCOUNTERID_CHAR = string.Empty;
            }
            m_objCurrentMain.m_strMAKERID_CHR = m_objViewer.m_txtMakeBillPerson.Tag.ToString();
            m_objCurrentMain.m_strSUPPLYCODE_VCHR = m_objViewer.m_txtProvidBillNo.Text;
            m_objCurrentMain.m_strCOMMNET_VCHR = m_objViewer.m_txtRemark.Text;
            m_objCurrentMain.m_strINVOICECODE_VCHR = m_objViewer.m_txtInvoiceNumber.Text;
            m_objCurrentMain.m_dtmINVOICEDATER_DAT = Convert.ToDateTime(m_objViewer.m_txtInvoiceDate.Text);
            m_objCurrentMain.m_intFORMTYPE_INT = m_objViewer.m_intFormType;

            m_objCurrentMain.m_intINSTORAGETYPE_INT = m_objViewer.m_intInstorageType;

            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            if (m_objViewer.m_txtExportDept.Tag != null)
            {
                m_objCurrentMain.m_strExportDept_CHR = m_objViewer.m_txtExportDept.StrItemId;
            }
            else
            {
                m_objCurrentMain.m_strExportDept_CHR = string.Empty;
            }
            m_objCurrentMain.Procurement = m_objViewer.cboProcurement.Text;
            return m_objCurrentMain;
        }

        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="p_dtbData">数据</param>
        /// <param name="p_strInStorageID"></param>
        /// <returns></returns>
        private clsMS_InStorageDetail_VO[] m_objGetNewDetail(DataTable p_dtbData, string p_strInStorageID)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            clsMS_InStorageDetail_VO[] objNewDetail = new clsMS_InStorageDetail_VO[intRowsCount];
            DataRow drCurrent = null;
            double dblTemp = 0d;
            decimal dcmTemp = 0m;
            int intTemp = 0;
            long lngTemp = 0;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                objNewDetail[iRow] = new clsMS_InStorageDetail_VO();
                drCurrent = p_dtbData.Rows[iRow];
                if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngTemp))
                {
                    objNewDetail[iRow].m_lngSERIESID_INT = lngTemp;
                }
                objNewDetail[iRow].m_intStatus = 1;
                objNewDetail[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objNewDetail[iRow].m_strMEDICINENAME_VCH = drCurrent["MEDICINENAME_VCH"].ToString();
                objNewDetail[iRow].m_strMedicineTypeID_chr = drCurrent["MEDICINETYPEID_CHR"].ToString();
                objNewDetail[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                if (double.TryParse(drCurrent["PACKAMOUNT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblPACKAMOUNT = dblTemp;
                }
                objNewDetail[iRow].m_strPACKUNIT_VCHR = drCurrent["PACKUNIT_VCHR"].ToString();
                if (decimal.TryParse(drCurrent["PACKCALLPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmPACKCALLPRICE_INT = dcmTemp;
                }
                if (double.TryParse(drCurrent["PACKCONVERT_INT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblPACKCONVERT_INT = dblTemp;
                }
                m_objDomain.m_lngGetMedicineTypeVisionm(drCurrent["MEDICINETYPEID_CHR"].ToString(), out m_objViewer.m_clsTypeVisVO);
                if ((m_objViewer.m_clsTypeVisVO != null) && (m_objViewer.m_clsTypeVisVO.m_intLotno == 0) && (drCurrent["LOTNO_VCHR"].ToString().Trim() == ""))
                {
                    objNewDetail[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objNewDetail[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                }

                if (double.TryParse(drCurrent["AMOUNT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblAMOUNT = dblTemp;
                }
                if (decimal.TryParse(drCurrent["CALLPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmCALLPRICE_INT = dcmTemp;
                }
                if (decimal.TryParse(drCurrent["WHOLESALEPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmWHOLESALEPRICE_INT = dcmTemp;
                }
                if (decimal.TryParse(drCurrent["RETAILPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmRETAILPRICE_INT = dcmTemp;
                }
                objNewDetail[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                if (Convert.ToString(drCurrent["ACCEPTANCE_INT"]) == "是" || Convert.ToString(drCurrent["ACCEPTANCE_INT"]) == "1")
                {
                    objNewDetail[iRow].m_intACCEPTANCE_INT = 1;
                }
                else
                {
                    objNewDetail[iRow].m_intACCEPTANCE_INT = 0;
                }
                objNewDetail[iRow].m_strAPPROVECODE_VCHR = drCurrent["APPROVECODE_VCHR"].ToString();
                if (int.TryParse(drCurrent["APPARENTQUALITY_INT"].ToString(), out intTemp))
                {
                    objNewDetail[iRow].m_intAPPARENTQUALITY_INT = intTemp;
                }
                else if (drCurrent["APPARENTQUALITY_INT"] == DBNull.Value)
                {
                    objNewDetail[iRow].m_intAPPARENTQUALITY_INT = 1;
                }
                if (int.TryParse(drCurrent["PACKQUALITY_INT"].ToString(), out intTemp))
                {
                    objNewDetail[iRow].m_intPACKQUALITY_INT = intTemp;
                }
                else if (drCurrent["PACKQUALITY_INT"] == DBNull.Value)
                {
                    objNewDetail[iRow].m_intPACKQUALITY_INT = 1;
                }
                if (int.TryParse(drCurrent["EXAMRUSULT_INT"].ToString(), out intTemp))
                {
                    objNewDetail[iRow].m_intEXAMRUSULT_INT = intTemp;
                }
                else if (drCurrent["EXAMRUSULT_INT"] == DBNull.Value)
                {
                    objNewDetail[iRow].m_intEXAMRUSULT_INT = 1;
                }
                objNewDetail[iRow].m_strEXAMINER = drCurrent["EXAMINER"].ToString();
                objNewDetail[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objNewDetail[iRow].m_strACCEPTANCECOMPANY_CHR = drCurrent["ACCEPTANCECOMPANY_CHR"].ToString();
                objNewDetail[iRow].m_strUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                objNewDetail[iRow].m_strInStorageID = p_strInStorageID;
                objNewDetail[iRow].m_intRUTURNNUM_INT = 0;
                //毛利率


                if (double.TryParse(drCurrent["GROSSPROFITRATE_INT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblGrossProfitRate = dblTemp;
                }
                //国家限价
                if (double.TryParse(drCurrent["LIMITUNITPRICE_MNY"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblLimitunitPrice = dblTemp;
                }

                objNewDetail[iRow].m_dtmInvoicedater_dat = DateTime.Parse(drCurrent["invoicedater_dat"].ToString() + " 00:00:00");
                objNewDetail[iRow].m_strInvoicecode_vchr = m_objViewer.m_txtInvoiceNumber.Text.Trim();
                if (drCurrent["gmpflag_int"].ToString().Length > 0)
                {
                    objNewDetail[iRow].m_intGMPFlag = int.Parse(drCurrent["gmpflag_int"].ToString());
                }
                objNewDetail[iRow].m_strTrade = drCurrent["trademark_vchr"].ToString();
                objNewDetail[iRow].m_strTYPECODE_CHR = drCurrent["typecode_vchr"].ToString();
                objNewDetail[iRow].m_dtmPRODUCEDATE_DAT = DateTime.Parse(drCurrent["PRODUCEDATE_DAT"].ToString() + " 00:00:00");

            }
            return objNewDetail;
        }
        #endregion

        #region 设置选定数据行至界面以修改


        /// <summary>
        /// 设置选定数据行至界面以修改

        /// </summary>
        internal void m_mthSetDataToUIForUpdate()
        {
            if (m_objViewer.m_drSelectedRow == null)
            {
                return;
            }


            m_objViewer.m_txtMedicineCode.Text = m_objViewer.m_drSelectedRow["MedicineCode"].ToString();
            m_objViewer.m_txtMedicineCode.Tag = m_objViewer.m_drSelectedRow["MEDICINEID_CHR"].ToString();
            m_objViewer.m_txtMedicineName.Text = m_objViewer.m_drSelectedRow["MEDICINENAME_VCH"].ToString();
            m_objViewer.m_txtSpec.Text = m_objViewer.m_drSelectedRow["MEDSPEC_VCHR"].ToString();
            m_objViewer.m_txtScalar.Text = m_objViewer.m_drSelectedRow["AMOUNT"].ToString();
            m_objViewer.m_lblPackAmount.Tag = m_objViewer.m_drSelectedRow["PACKAMOUNT"].ToString();
            m_objViewer.m_txtUnit.Text = m_objViewer.m_drSelectedRow["UNIT_VCHR"].ToString();
            m_objViewer.m_lblPackUnit.Tag = m_objViewer.m_drSelectedRow["PACKUNIT_VCHR"].ToString();

            if (m_objViewer.m_drSelectedRow["LOTNO_VCHR"].ToString().Trim() == "UNKNOWN")
            {
                m_objViewer.m_txtBatchNumber.Text = "";
            }
            else
            {
                m_objViewer.m_txtBatchNumber.Text = m_objViewer.m_drSelectedRow["LOTNO_VCHR"].ToString();
            }


            m_objViewer.m_lblPackSalePrice.Tag = m_objViewer.m_drSelectedRow["PACKCALLPRICE_INT"].ToString();

            m_objViewer.m_txtBuyInUnitPrice.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["CALLPRICE_INT"]).ToString("0.0000");
            if ((m_objViewer.m_drSelectedRow["PACKAMOUNT"] != DBNull.Value) && (Convert.ToDouble(m_objViewer.m_drSelectedRow["PACKAMOUNT"]) > 0))
            {
                Decimal sumMomey = Convert.ToDecimal(m_objViewer.m_drSelectedRow["PACKCALLPRICE_INT"]) * Convert.ToDecimal(m_objViewer.m_drSelectedRow["PACKAMOUNT"]);
                m_objViewer.m_txtBuyInMomey.Text = sumMomey.ToString("0.0000");
            }
            else
            {

                m_objViewer.m_txtBuyInMomey.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["INMONEY"]).ToString("0.0000");
            }


            m_objViewer.m_txtWholeSaleUnitPrice.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["WHOLESALEPRICE_INT"]).ToString("0.0000");
            m_objViewer.m_txtWholeSaleMoney.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["WHOLESALEMONEY"]).ToString("0.0000");
            m_objViewer.m_txtRetailUnitPrice.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["RETAILPRICE_INT"]).ToString("0.0000");
            m_objViewer.m_txtRetailMoney.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["SALEMONEY"]).ToString("0.0000");
            m_objViewer.m_txtProducer.Text = m_objViewer.m_drSelectedRow["PRODUCTORID_CHR"].ToString();
            m_objViewer.m_txtBalance.Text = (Convert.ToDecimal(m_objViewer.m_drSelectedRow["RETAILPRICE_INT"]) - Convert.ToDecimal(m_objViewer.m_drSelectedRow["CALLPRICE_INT"])).ToString("0.0000");

            m_objViewer.m_txtInEffectDate.Text = m_objViewer.m_drSelectedRow["VALIDPERIOD_DAT"].ToString();

            m_objViewer.m_txtInvoiceNumber.Text = m_objViewer.m_drSelectedRow["INVOICECODE_VCHR"].ToString();
            m_objViewer.m_txtInvoiceDate.Text = m_objViewer.m_drSelectedRow["INVOICEDATER_DAT"].ToString();
            m_objViewer.m_txtProduceDate.Text = m_objViewer.m_drSelectedRow["PRODUCEDATE_DAT"].ToString();

            m_objViewer.m_txtGrossProfitRate.Text = m_objViewer.m_drSelectedRow["GROSSPROFITRATE_INT"].ToString();

            if (m_objViewer.iLimitunitPrice == 1)
            {
                m_objViewer.m_txtLastBuyInUnitPrice.Text = Convert.ToDecimal(m_objViewer.m_drSelectedRow["LIMITUNITPRICE_MNY"]).ToString("0.0000");
            }
            m_objCurrentACInfo = new clsMS_AcceptanceCheck_VO();
            int intTemp = 0;
            //if (int.TryParse(m_objViewer.m_drSelectedRow["ACCEPTANCE_INT"].ToString(), out intTemp))
            if (Convert.ToString(m_objViewer.m_drSelectedRow["ACCEPTANCE_INT"]) == "是"
                || Convert.ToString(m_objViewer.m_drSelectedRow["ACCEPTANCE_INT"]) == "1")
            {
                m_objCurrentACInfo.m_intBid = 1;
            }
            else
            {
                m_objCurrentACInfo.m_intBid = 0;
            }
            if (int.TryParse(m_objViewer.m_drSelectedRow["APPARENTQUALITY_INT"].ToString(), out intTemp))
            {
                m_objCurrentACInfo.m_intApparentQuality = intTemp;
            }
            m_objCurrentACInfo.m_strApproveCode = m_objViewer.m_drSelectedRow["APPROVECODE_VCHR"].ToString();
            if (int.TryParse(m_objViewer.m_drSelectedRow["PACKQUALITY_INT"].ToString(), out intTemp))
            {
                m_objCurrentACInfo.m_intPackQuality = intTemp;
            }
            if (int.TryParse(m_objViewer.m_drSelectedRow["EXAMRUSULT_INT"].ToString(), out intTemp))
            {
                m_objCurrentACInfo.m_intExamResult = intTemp;
            }
            m_objCurrentACInfo.m_strExamerID = m_objViewer.m_drSelectedRow["EXAMINER"].ToString();
            m_objCurrentACInfo.m_strExamerName = m_objViewer.m_drSelectedRow["examinername"].ToString();
            m_objCurrentACInfo.m_strBidCompany = m_objViewer.m_drSelectedRow["ACCEPTANCECOMPANY_CHR"].ToString();
            m_objCurrentACInfo.m_strBidCompanyName = m_objViewer.m_drSelectedRow["ACCEPTANCECOMPANYName"].ToString();
            m_strCurrentMedicineTypeID = m_objViewer.m_drSelectedRow["MEDICINETYPEID_CHR"].ToString();

            m_objDomain.m_lngGetMedicineTypeVisionm(m_strCurrentMedicineTypeID, out m_objViewer.m_clsTypeVisVO);

            m_objCurrentPCInfo = new clsMS_PackConversion_VO();
            double dblTemp = 0d;
            decimal dcmTemp = 0m;
            if (double.TryParse(m_objViewer.m_drSelectedRow["PACKAMOUNT"].ToString(), out dblTemp))
            {
                m_objCurrentPCInfo.m_dblPackAmount = dblTemp;
            }
            m_objCurrentPCInfo.m_strPackUnit = m_objViewer.m_drSelectedRow["PACKUNIT_VCHR"].ToString();
            if (decimal.TryParse(m_objViewer.m_drSelectedRow["PACKCALLPRICE_INT"].ToString(), out dcmTemp))
            {
                m_objCurrentPCInfo.m_dcmPackPrice = dcmTemp;
            }
            if (double.TryParse(m_objViewer.m_drSelectedRow["PACKCONVERT_INT"].ToString(), out dblTemp))
            {
                m_objCurrentPCInfo.m_dblPackConvert = dblTemp;
            }
            double.TryParse(m_objViewer.m_drSelectedRow["AMOUNT"].ToString(), out m_objViewer.dblOldScalar);
            double.TryParse(m_objViewer.m_drSelectedRow["RETAILPRICE_INT"].ToString(), out m_objViewer.dblOldRetailUnitPrice);

            //判断药品是否有调价记录


            if (m_objViewer.m_drSelectedRow["SERIESID_INT"].ToString().Trim() != "")
            {
                string strLotno;

                if (m_objViewer.m_drSelectedRow["LOTNO_VCHR"].ToString().Trim() == "")
                {
                    strLotno = "UNKNOWN";
                }
                else
                {
                    strLotno = m_objViewer.m_drSelectedRow["LOTNO_VCHR"].ToString();
                }
                m_objDomain.m_mthGetAdjustrice(m_objViewer.m_drSelectedRow["MEDICINEID_CHR"].ToString(), strLotno, m_objViewer.m_txtIncomeBillNumber.Text, Convert.ToDateTime(m_objViewer.m_drSelectedRow["VALIDPERIOD_DAT"]), Convert.ToDouble(m_objViewer.m_drSelectedRow["CALLPRICE_INT"]), m_objCurrentMain.m_dtmNEWORDER_DAT, out m_objViewer.bolAdjustrice);

            }
            else
            {
                m_objViewer.bolAdjustrice = false;
            }

            //若单据中的药品已经进行调价，就不允许修改这药品零售价与数量。

            if (m_objViewer.bolAdjustrice)
            {
                m_objViewer.m_txtMedicineCode.Enabled = false;
                m_objViewer.m_txtScalar.ReadOnly = true;
                m_objViewer.m_txtRetailUnitPrice.ReadOnly = true;
                m_objViewer.m_txtBuyInUnitPrice.ReadOnly = true;
            }
            else
            {
                m_objViewer.m_txtMedicineCode.Enabled = true;
                m_objViewer.m_txtScalar.ReadOnly = false;
                m_objViewer.m_txtRetailUnitPrice.ReadOnly = false;
                m_objViewer.m_txtBuyInUnitPrice.ReadOnly = false;
            }

        }
        #endregion

        #region 删除入库明细
        /// <summary>
        /// 删除入库明细
        /// </summary>
        internal void m_mthDeleteInStorageDetail()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1)
            {
                if (m_objCurrentMain.m_intSTATE_INT == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品入库记录已入帐，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品入库记录已审核，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objViewer.bolAdjustrice)
                {
                    MessageBox.Show("该药品已有调价记录，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (m_objViewer.m_dgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }



            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1 && m_objCurrentMain.m_intSTATE_INT != 0)
            {
                m_objViewer.m_blnHasCommit = true;
            }

            if (m_objViewer.m_blnHasCommit && m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT == 2 && !bolAddOutMedicineInfo)
            {
                clsDcl_Purchase objMainDomain = new clsDcl_Purchase();
                bool blnHasDone = false;
                string strOtherID = string.Empty;
                long lngCheck = objMainDomain.m_lngCheckHasDoneAfterInStorage(m_objCurrentMain.m_strINSTORAGEID_VCHR, out blnHasDone, out strOtherID);
                objMainDomain = null;

                if (blnHasDone)
                {
                    MessageBox.Show("此入库单药品已出库，不能再作修改", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int intRowIndex = m_objViewer.m_dgvMedicineDetail.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvMedicineDetail.SelectedCells[0].OwningRow.DataBoundItem).Row;

            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {
                bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;

                clsMS_Storage objStorage = null;
                if (blnIsCommit)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                    objStorage.m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                    objStorage.m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                    objStorage.m_strOPUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                    objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    objStorage.m_strVENDORID_CHR = m_objCurrentMain.m_strVENDORID_CHR;
                }

                long lngRes = m_objDomain.m_lngDeleteSelectedMedicine(lngSEQ, m_objViewer.m_strStorageID, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), m_objCurrentMain.m_strINSTORAGEID_VCHR, Convert.ToDateTime(drCurrent["validperiod_dat"]), Convert.ToDouble(drCurrent["CALLPRICE_INT"]), blnIsCommit, objStorage);
                if (lngRes > 0)
                {
                    //if (m_objViewer.m_intCommitFolow == 1)
                    //{
                    //    m_mthUnCommit(drCurrent, intRowIndex);
                    //}                    
                    m_objViewer.m_dtbMedicineInfo.Rows.Remove(drCurrent);
                }
            }
            else
            {
                m_objViewer.m_dtbMedicineInfo.Rows.Remove(drCurrent);
            }
        }
        #endregion

        #region 清空当前入库主要信息
        /// <summary>
        /// 清空当前入库主要信息
        /// </summary>
        internal void m_mthClearMainInfo()
        {
            m_objViewer.m_txtProviderName.Clear();
            m_objViewer.m_txtProviderName.Tag = null;
            m_objViewer.m_txtIncomeBillNumber.Text = string.Empty;
            m_objViewer.m_dtpInComeDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            //m_objViewer.m_txtPurchasePerson.Clear();
            //m_objViewer.m_txtPurchasePerson.Tag = null;
            //m_objViewer.m_txtStroehouseManager.Clear();
            //m_objViewer.m_txtStroehouseManager.Tag = null;
            //m_objViewer.m_txtAccountant.Tag = null;
            //m_objViewer.m_txtAccountant.Clear();
            m_objViewer.m_blnAddedRowsHasPoisonOrChlorpromazine = false;
            m_objViewer.m_txtProvidBillNo.Clear();
            m_objViewer.m_txtRemark.Clear();
            m_objViewer.m_txtInvoiceNumber.Clear();
            m_objViewer.m_txtInvoiceDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_objViewer.m_txtProduceDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_objCurrentMain = null;
            m_objViewer.m_lblAllInMoney.Text = string.Empty;
            m_objViewer.m_lblAllRetailMoney.Text = string.Empty;
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_blnHasCommit = false;
            m_objViewer.m_lblDiffMoney.Text = string.Empty;
            m_objViewer.cboProcurement.SelectedIndex = 0;
        }
        #endregion

        #region 设置药品信息至界面(外部传入VO，以进行修改)
        /// <summary>
        /// 设置药品信息至界面(外部传入VO，以进行修改)
        /// </summary>
        /// <param name="p_objISVO">主表信息</param>
        /// <param name="p_objDetailArr">子表信息</param>
        /// <param name="p_intSelectedSubRow">选中子表行</param>
        internal void m_mthSetMedicineDetailToUI(clsMS_InStorage_VO p_objISVO, clsMS_InStorageDetail_VO[] p_objDetailArr, int p_intSelectedSubRow)
        {
            if (p_objISVO == null)
            {
                return;
            }

            string m_strBillTypeName;
            m_objDomain.m_lngGetBillTypeName(p_objISVO.m_intINSTORAGETYPE_INT, out m_strBillTypeName);
            if (m_strBillTypeName != "")
                m_objViewer.Text = m_strBillTypeName;

            #region 主表
            m_objViewer.m_lngMainSEQ = p_objISVO.m_lngSERIESID_INT;
            m_objViewer.m_txtProviderName.Text = p_objISVO.m_strVENDORName;
            m_objViewer.m_txtProviderName.Tag = p_objISVO.m_strVENDORID_CHR;

            m_objViewer.m_dtpInComeDate.Text = p_objISVO.m_dtmINSTORAGEDATE_DAT.ToString("yyyy年MM月dd日");
            if (m_objViewer.m_intCanModifyMakeDate == 0)
                m_objViewer.m_dtpInComeDate.Enabled = false;
            if (m_objViewer.m_intCommitFolow == 1 && m_objViewer.m_intCanModifyAutoExam == 0)
            {
                m_objViewer.m_cmdSave.Enabled = false;
            }
            m_objViewer.m_txtPurchasePerson.Text = p_objISVO.m_strBUYERName;
            m_objViewer.m_txtPurchasePerson.Tag = p_objISVO.m_strBUYERID_CHAR;
            m_objViewer.m_txtStroehouseManager.Text = p_objISVO.m_strSTORAGERName;
            m_objViewer.m_txtStroehouseManager.Tag = p_objISVO.m_strSTORAGERID_CHAR;
            m_objViewer.m_txtAccountant.Text = p_objISVO.m_strACCOUNTERName;
            m_objViewer.m_txtAccountant.Tag = p_objISVO.m_strACCOUNTERID_CHAR;
            m_objViewer.m_txtIncomeBillNumber.Text = p_objISVO.m_strINSTORAGEID_VCHR;
            m_objViewer.m_txtProvidBillNo.Text = p_objISVO.m_strSUPPLYCODE_VCHR;
            m_objViewer.m_txtMakeBillPerson.Text = p_objISVO.m_strMAKERName;
            m_objViewer.m_txtMakeBillPerson.Tag = p_objISVO.m_strMAKERID_CHR;
            m_objViewer.m_txtRemark.Text = p_objISVO.m_strCOMMNET_VCHR;
            m_objViewer.m_txtInvoiceNumber.Text = p_objISVO.m_strINVOICECODE_VCHR;
            m_objViewer.m_txtInvoiceDate.Text = p_objISVO.m_dtmINVOICEDATER_DAT.ToString("yyyy年MM月dd日");
            //m_objViewer.m_txtExportDept.Text = p_objISVO.m_strExportDept_CHR;
            //m_objViewer.m_txtExportDept.Tag = p_objISVO.m_strExportDeptID_CHR;
            m_objViewer.m_txtExportDept.m_mthSelectItem(p_objISVO.m_strExportDeptID_CHR.Trim());
            m_objViewer.cboProcurement.Text = p_objISVO.Procurement;
            m_objCurrentMain = p_objISVO;

            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            bool blnHasDone = false;//此单入库后是否已做其它操作


            string strOtherID = string.Empty;//其它操作的单据号

            long lngRes = objPDomain.m_lngCheckHasDoneAfterInStorage(p_objISVO.m_strINSTORAGEID_VCHR, out blnHasDone, out strOtherID);
            if (blnHasDone)
            {
                m_objViewer.panel1.Enabled = false;
            }
            else
            {
                if (p_objISVO.m_intSTATE_INT != 1)
                {
                    m_objViewer.panel1.Enabled = false;
                }

                if (m_objViewer.m_intCommitFolow == 1 && p_objISVO.m_intSTATE_INT != 0 && p_objISVO.m_intSTATE_INT != 3)
                {
                    m_objViewer.panel1.Enabled = true;
                }
            }
            #endregion

            if (p_objDetailArr == null)
            {
                return;
            }

            #region 子表
            try
            {
                m_objViewer.m_dtbMedicineInfo = m_dtbInitTable();
                m_objViewer.m_dtbMedicineInfo.BeginLoadData();
                DataRow[] drSub = new DataRow[p_objDetailArr.Length];
                for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                {
                    drSub[iRow] = m_objViewer.m_dtbMedicineInfo.NewRow();
                    drSub[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                    drSub[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT2;
                    drSub[iRow]["MEDICINEID_CHR"] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    drSub[iRow]["MEDICINENAME_VCH"] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                    drSub[iRow]["MEDSPEC_VCHR"] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    drSub[iRow]["PACKAMOUNT"] = p_objDetailArr[iRow].m_dblPACKAMOUNT;
                    drSub[iRow]["PACKUNIT_VCHR"] = p_objDetailArr[iRow].m_strPACKUNIT_VCHR;
                    drSub[iRow]["PACKCALLPRICE_INT"] = p_objDetailArr[iRow].m_dcmPACKCALLPRICE_INT;
                    drSub[iRow]["PACKCONVERT_INT"] = p_objDetailArr[iRow].m_dblPACKCONVERT_INT;
                    drSub[iRow]["LOTNO_VCHR"] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                    drSub[iRow]["AMOUNT"] = p_objDetailArr[iRow].m_dblAMOUNT;
                    drSub[iRow]["CALLPRICE_INT"] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                    drSub[iRow]["WHOLESALEPRICE_INT"] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                    drSub[iRow]["RETAILPRICE_INT"] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                    drSub[iRow]["VALIDPERIOD_DAT"] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT.ToString("yyyy年MM月dd日");
                    drSub[iRow]["ACCEPTANCE_INT"] = p_objDetailArr[iRow].m_intACCEPTANCE_INT;
                    drSub[iRow]["APPROVECODE_VCHR"] = p_objDetailArr[iRow].m_strAPPROVECODE_VCHR;
                    drSub[iRow]["APPARENTQUALITY_INT"] = p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT;
                    drSub[iRow]["PACKQUALITY_INT"] = p_objDetailArr[iRow].m_intPACKQUALITY_INT;
                    drSub[iRow]["EXAMRUSULT_INT"] = p_objDetailArr[iRow].m_intEXAMRUSULT_INT;
                    drSub[iRow]["EXAMINER"] = p_objDetailArr[iRow].m_strEXAMINER;
                    drSub[iRow]["PRODUCTORID_CHR"] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                    drSub[iRow]["ACCOUNTPERIOD_INT"] = p_objDetailArr[iRow].m_lngACCOUNTPERIOD_INT;
                    drSub[iRow]["ACCEPTANCECOMPANY_CHR"] = p_objDetailArr[iRow].m_strACCEPTANCECOMPANY_CHR;
                    drSub[iRow]["ACCEPTANCECOMPANYname"] = p_objDetailArr[iRow].m_strACCEPTANCECOMPANYName;
                    drSub[iRow]["examinername"] = p_objDetailArr[iRow].m_strEXAMINERName;
                    drSub[iRow]["invoicedater_dat"] = p_objDetailArr[iRow].m_dtmInvoicedater_dat.ToString("yyyy年MM月dd日");
                    drSub[iRow]["invoicecode_vchr"] = p_objDetailArr[iRow].m_strInvoicecode_vchr;
                    drSub[iRow]["GROSSPROFITRATE_INT"] = p_objDetailArr[iRow].m_dblGrossProfitRate;
                    drSub[iRow]["LIMITUNITPRICE_MNY"] = p_objDetailArr[iRow].m_dblLimitunitPrice;

                    if (p_objDetailArr[iRow].m_intACCEPTANCE_INT == 1)
                    {
                        drSub[iRow]["ACCEPTANCENAME"] = "是";
                    }
                    else if (p_objDetailArr[iRow].m_intACCEPTANCE_INT == 0)
                    {
                        drSub[iRow]["ACCEPTANCENAME"] = "否";
                    }
                    if (p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT == 1)
                    {
                        drSub[iRow]["APPARENTQUALITYNAME"] = "合格";
                    }
                    else if (p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT == 0)
                    {
                        drSub[iRow]["APPARENTQUALITYNAME"] = "不合格";
                    }
                    if (p_objDetailArr[iRow].m_intPACKQUALITY_INT == 1)
                    {
                        drSub[iRow]["PACKQUALITYNAME"] = "合格";
                    }
                    else if (p_objDetailArr[iRow].m_intPACKQUALITY_INT == 0)
                    {
                        drSub[iRow]["PACKQUALITYNAME"] = "不合格";
                    }
                    if (p_objDetailArr[iRow].m_intEXAMRUSULT_INT == 1)
                    {
                        drSub[iRow]["EXAMRUSULTNAME"] = "合格";
                    }
                    else if (p_objDetailArr[iRow].m_intEXAMRUSULT_INT == 0)
                    {
                        drSub[iRow]["EXAMRUSULTNAME"] = "不合格";
                    }
                    drSub[iRow]["UNIT_VCHR"] = p_objDetailArr[iRow].m_strUNIT_VCHR;
                    drSub[iRow]["INMONEY"] = (Convert.ToDouble(p_objDetailArr[iRow].m_dcmCALLPRICE_INT) * p_objDetailArr[iRow].m_dblAMOUNT).ToString("0.0000");
                    drSub[iRow]["SALEMONEY"] = (Convert.ToDouble(p_objDetailArr[iRow].m_dcmRETAILPRICE_INT) * p_objDetailArr[iRow].m_dblAMOUNT).ToString("0.0000");
                    drSub[iRow]["SortNum"] = iRow + 1;
                    drSub[iRow]["MedicineCode"] = p_objDetailArr[iRow].m_strMEDICINECode;
                    drSub[iRow]["WHOLESALEMONEY"] = (Convert.ToDouble(p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT) * p_objDetailArr[iRow].m_dblAMOUNT).ToString("0.0000");
                    drSub[iRow]["MEDICINEPREPTYPE_CHR"] = p_objDetailArr[iRow].m_strMEDICINEPREPTYPE_CHR;
                    drSub[iRow]["MEDICINETYPEID_CHR"] = p_objDetailArr[iRow].m_strMedicineTypeID_chr;
                    drSub[iRow]["typecode_vchr"] = p_objDetailArr[iRow].m_strTYPECODE_CHR;
                    drSub[iRow]["PRODUCEDATE_DAT"] = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT.ToString("yyyy年MM月dd日");

                    m_objViewer.m_dtbMedicineInfo.LoadDataRow(drSub[iRow].ItemArray, true);
                }
            }
            catch (Exception Ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(Ex);
            }
            finally
            {
                m_objViewer.m_dtbMedicineInfo.EndLoadData();
            }
            m_objViewer.m_dgvMedicineDetail.DataSource = m_objViewer.m_dtbMedicineInfo;
            m_mthGetAllMoney();

            if (p_intSelectedSubRow > 0 && m_objViewer.m_dgvMedicineDetail.Rows.Count > 0 && p_intSelectedSubRow < m_objViewer.m_dgvMedicineDetail.Rows.Count)
            {
                m_objViewer.m_dgvMedicineDetail.Rows[p_intSelectedSubRow].Selected = true;
                m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[p_intSelectedSubRow].Cells[0];
            }
            #endregion
        }
        #endregion

        #region 获取总金额


        /// <summary>
        /// 获取总金额

        /// </summary>
        internal void m_mthGetAllMoney()
        {
            if (m_objViewer.m_dtbMedicineInfo != null)
            {
                int intRowsCount = m_objViewer.m_dtbMedicineInfo.Rows.Count;
                decimal dcmAllInMoney = 0m;//购入总金额
                decimal dcmAllRetailMoney = 0m;//零售总金额
                decimal dcmDiffMoney = 0m;//批零差额


                DataRow drTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbMedicineInfo.Rows[iRow];
                    //if ((drTemp["PACKAMOUNT"] != DBNull.Value) && Convert.ToDecimal(drTemp["PACKAMOUNT"]) > 0)
                    //{
                    //    dcmAllInMoney += Convert.ToDecimal(drTemp["PACKAMOUNT"]) * Convert.ToDecimal(drTemp["PACKCALLPRICE_INT"]);
                    //}
                    //else
                    //{
                    //    dcmAllInMoney += Convert.ToDecimal(drTemp["AMOUNT"]) * Convert.ToDecimal(drTemp["CALLPRICE_INT"]);
                    //}
                    //dcmAllRetailMoney += Convert.ToDecimal(drTemp["AMOUNT"]) * Convert.ToDecimal(drTemp["RETAILPRICE_INT"]);

                    dcmAllInMoney += Convert.ToDecimal(drTemp["inmoney"]);
                    dcmAllRetailMoney += Convert.ToDecimal(drTemp["Salemoney"]);
                    dcmDiffMoney += Convert.ToDecimal(drTemp["wholesalemoney"]);
                }

                m_objViewer.m_lblAllInMoney.Text = dcmAllInMoney.ToString("0.0000");
                m_objViewer.m_lblAllRetailMoney.Text = dcmAllRetailMoney.ToString("0.0000");
                dcmDiffMoney = dcmAllRetailMoney - dcmDiffMoney;
                m_objViewer.m_lblDiffMoney.Text = dcmDiffMoney.ToString("F4");
            }
        }
        #endregion

        #region 设置默认员工
        /// <summary>
        /// 设置默认员工
        /// </summary>
        internal void m_mthGetLatestEmpInfo()
        {
            string p_strBuyerID = string.Empty;
            string p_strBuyerName = string.Empty;
            string p_strStoragerID = string.Empty;
            string p_strStoragerName = string.Empty;
            string p_strAccounterID = string.Empty;
            string p_strAccounterName = string.Empty;
            long lngRes = m_objDomain.m_lngGetLatestEmpInfo(m_objViewer.m_strStorageID, out p_strBuyerID, out p_strBuyerName, out p_strStoragerID, out p_strStoragerName, out p_strAccounterID, out p_strAccounterName);

            if (!string.IsNullOrEmpty(p_strBuyerID))
            {
                m_objViewer.m_txtPurchasePerson.Text = p_strBuyerName;
                m_objViewer.m_txtPurchasePerson.Tag = p_strBuyerID;
            }

            if (!string.IsNullOrEmpty(p_strStoragerID))
            {
                m_objViewer.m_txtStroehouseManager.Text = p_strStoragerName;
                m_objViewer.m_txtStroehouseManager.Tag = p_strStoragerID;
            }

            if (!string.IsNullOrEmpty(p_strStoragerID))
            {
                m_objViewer.m_txtAccountant.Text = p_strAccounterName;
                m_objViewer.m_txtAccountant.Tag = p_strAccounterID;
            }
        }
        #endregion

        #region 获取当前药品的价格及毛利率信息


        /// <summary>
        /// 获取当前药品的价格及毛利率信息


        /// </summary>
        internal void m_mthGetMedicinePrice()
        {
            if (m_objViewer.m_txtMedicineCode.Tag == null)
            {
                return;
            }

            decimal dcmAvgPrice = 0m;
            decimal dcmLastBuyIn = 0m;
            decimal dcmLastRetail = 0m;
            decimal dcmLastWholeSale = 0m;

            long lngRes = m_objDomain.m_lngGetLatestPrice(m_objViewer.m_txtMedicineCode.Tag.ToString(), out dcmAvgPrice, out dcmLastBuyIn, out dcmLastWholeSale, out dcmLastRetail);

            if (lngRes > 0)
            {

                m_objViewer.m_txtLastRetailUnitPrice.Text = dcmLastRetail.ToString("0.0000");

                int iType;
                m_objDomain.m_lngGetGrossproFitrate(out iType);

                if (m_objViewer.iLimitunitPrice == 0)
                {
                    m_objViewer.m_txtLastWholeSaleUnitPrice.Text = dcmLastWholeSale.ToString("0.0000");
                    m_objViewer.m_txtLastBuyInUnitPrice.Text = dcmLastBuyIn.ToString("0.0000");
                }
                if (m_objViewer.iLimitunitPrice == 1)
                {
                    m_objViewer.m_txtLastWholeSaleUnitPrice.Text = dcmLastWholeSale.ToString("0.0000");
                }

                m_objViewer.m_txtAvgBuyInUnitPrice.Text = dcmAvgPrice.ToString("0.0000");

            }
        }
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息(此方法已废弃不用)
        /// </summary>
        internal void m_mthCommitMedicine(clsMS_InStorage_VO p_objMain, clsMS_InStorageDetail_VO[] p_objSubArr)
        {

            if (p_objMain == null || p_objSubArr == null)
            {
                return;
            }

            try
            {
                long lngRes = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                DataTable dtbDetail = null;
                clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO
                //for (int iRow = 0; iRow < p_objSubArr.Length; iRow++)
                //{
                objDetailTemp = m_objDetailVO(p_objSubArr, p_objMain.m_strINSTORAGEID_VCHR, p_objMain.m_dtmINSTORAGEDATE_DAT, p_objMain.m_strVENDORID_CHR, p_objMain.m_strVENDORName);
                if (objDetailTemp != null && objDetailTemp.Length > 0)
                {
                    objDetail.AddRange(objDetailTemp);
                }
                //}

                clsMS_StorageDetail[] objAllDetail = objDetail.ToArray();//全部明细VO

                if (objAllDetail == null || objAllDetail.Length == 0)
                {
                    return;
                }

                bool blnSaveComplete = true;
                if (m_objViewer.m_blnHasCommit)
                {
                    lngRes = objSTDomain.m_lngDeleteStorageDetail(p_objMain.m_strINSTORAGEID_VCHR, p_objMain.m_dtmINSTORAGEDATE_DAT);
                    if (lngRes < 0)
                    {
                        return;
                    }
                }
                lngRes = objSTDomain.m_lngAddNewStorageDetail(objAllDetail);
                if (lngRes > 0)
                {
                    blnSaveComplete = true;
                }
                else
                {
                    blnSaveComplete = false;
                }

                if (!blnSaveComplete)
                {
                    return;
                }

                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                clsMS_Storage objStorage = null;
                bool blnHasDetail = false;//是否已存在



                for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = objAllDetail[iRow].m_strMEDICINEID_CHR;
                    objStorage.m_strMEDICINENAME_VCHR = objAllDetail[iRow].m_strMEDICINENAME_VCHR;
                    objStorage.m_strMEDSPEC_VCHR = objAllDetail[iRow].m_strMEDSPEC_VCHR;
                    objStorage.m_strOPUNIT_VCHR = objAllDetail[iRow].m_strOPUNIT_VCHR;
                    objStorage.m_dblINSTOREGROSS_INT = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dblCURRENTGROSS_NUM = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dcmCALLPRICE_INT = objAllDetail[iRow].m_dcmCALLPRICE_INT;
                    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

                    if (!hstMedicine.Contains(objAllDetail[iRow].m_strMEDICINEID_CHR))
                    {
                        long lngCurrentSeriesID = 0;
                        lngRes = objSTDomain.m_lngCheckHasStorage(objAllDetail[iRow].m_strMEDICINEID_CHR, m_objViewer.m_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

                        if (blnHasDetail)
                        {
                            if (objStorage != null)
                            {
                                lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, lngCurrentSeriesID);
                            }
                        }
                        else
                        {
                            if (objStorage != null)
                            {
                                lngRes = objSTDomain.m_lngAddNewStorage(ref objStorage);
                            }
                            hstMedicine.Add(objAllDetail[iRow].m_strMEDICINEID_CHR, lngCurrentSeriesID);
                        }
                    }
                    else
                    {
                        lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, Convert.ToInt64(hstMedicine[objAllDetail[iRow].m_strMEDICINEID_CHR]));
                    }
                }
                hstMedicine = null;

                System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                {
                    if (!hstStastic.Contains(objAllDetail[iRow].m_strMEDICINEID_CHR))
                    {
                        hstStastic.Add(objAllDetail[iRow].m_strMEDICINEID_CHR, objAllDetail[iRow].m_lngSERIESID_INT);
                        lngRes = objSTDomain.m_lngStatisticsStorage(objAllDetail[iRow].m_strMEDICINEID_CHR, m_objViewer.m_strStorageID);
                    }
                }

                if (blnSaveComplete)
                {
                    m_mthUpdateUIAfterCommit(p_objMain);
                    m_mthSetCommitUser(p_objMain);
                    m_objViewer.m_blnHasCommit = true;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }

        /// <summary>
        /// 设置审核人


        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthSetCommitUser(clsMS_InStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            clsDcl_Purchase objPur = new clsDcl_Purchase();
            long[] lngSeq = new long[] { p_objMain.m_lngSERIESID_INT };
            long lngRes = objPur.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSeq);
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthUpdateUIAfterCommit(clsMS_InStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            p_objMain.m_intSTATE_INT = 2;
        }

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_objSubArr">数据</param>
        /// <param name="p_strInID">入库单号</param>
        /// <param name="p_dtmInDate">入库日期</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_strVendorName">供应商名</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(clsMS_InStorageDetail_VO[] p_objSubArr, string p_strInID, DateTime p_dtmInDate,
            string p_strVendorID, string p_strVendorName)
        {
            if (p_objSubArr == null || p_objSubArr.Length == 0)
            {
                return null;
            }
            DateTime datTemp;
            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_objSubArr.Length];
            for (int iRow = 0; iRow < p_objSubArr.Length; iRow++)
            {
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = p_objSubArr[iRow].m_strMEDICINEID_CHR;
                objSubVO[iRow].m_strMEDICINENAME_VCHR = p_objSubArr[iRow].m_strMEDICINENAME_VCH;
                objSubVO[iRow].m_strMEDSPEC_VCHR = p_objSubArr[iRow].m_strMEDSPEC_VCHR;
                objSubVO[iRow].m_strLOTNO_VCHR = p_objSubArr[iRow].m_strLOTNO_VCHR;
                objSubVO[iRow].m_dcmRETAILPRICE_INT = p_objSubArr[iRow].m_dcmRETAILPRICE_INT;
                objSubVO[iRow].m_dcmCALLPRICE_INT = p_objSubArr[iRow].m_dcmCALLPRICE_INT;
                objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = p_objSubArr[iRow].m_dcmWHOLESALEPRICE_INT;
                objSubVO[iRow].m_dblREALGROSS_INT = p_objSubArr[iRow].m_dblAMOUNT;
                objSubVO[iRow].m_dblAVAILAGROSS_INT = p_objSubArr[iRow].m_dblAMOUNT;
                objSubVO[iRow].m_strOPUNIT_VCHR = p_objSubArr[iRow].m_strUNIT_VCHR;
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = p_objSubArr[iRow].m_dtmVALIDPERIOD_DAT;
                objSubVO[iRow].m_strPRODUCTORID_CHR = p_objSubArr[iRow].m_strPRODUCTORID_CHR;
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_strInID;
                if (p_dtmInDate == DateTime.MinValue || p_dtmInDate == new DateTime(1900, 1, 1))
                {
                    objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = p_dtmInDate;
                }
                objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                objSubVO[iRow].m_strVENDORName = p_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
                objSubVO[iRow].m_strMEDICINETYPEID_CHR = p_objSubArr[iRow].m_strMedicineTypeID_chr;
                objSubVO[iRow].m_strTYPECODE_CHR = p_objSubArr[iRow].m_strTYPECODE_CHR;
                objSubVO[iRow].m_dtmPRODUCEDATE_DAT = p_objSubArr[iRow].m_dtmPRODUCEDATE_DAT;
            }
            return objSubVO;
        }
        #endregion
        #endregion

        #region 退审


        /// <summary>
        /// 退审


        /// </summary>
        /// <param name="p_drCurrent">选定药品数据</param>
        /// <param name="p_intRowIndex">第几行数据</param>
        internal void m_mthUnCommit(DataRow p_drCurrent, int p_intRowIndex)
        {
            clsMS_Storage objStorage = new clsMS_Storage();
            objStorage.m_strMEDICINEID_CHR = p_drCurrent["MEDICINEID_CHR"].ToString();
            objStorage.m_strMEDICINENAME_VCHR = p_drCurrent["MEDICINENAME_VCH"].ToString();
            objStorage.m_strMEDSPEC_VCHR = p_drCurrent["MEDSPEC_VCHR"].ToString();
            objStorage.m_strOPUNIT_VCHR = p_drCurrent["UNIT_VCHR"].ToString();
            objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drCurrent["CALLPRICE_INT"]);
            objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            bool blnHasDetail = false;
            long lngCurrentSeriesID = 0;
            long lngRes = objSTDomain.m_lngCheckHasStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

            long lngSubSEQ = 0;
            double p_dblRealgross = 0d;
            double p_dblAvailagross = 0d;
            lngRes = objSTDomain.m_lngGetDetailSEQByIndex(m_objViewer.m_txtIncomeBillNumber.Text, objStorage.m_strMEDICINEID_CHR, p_drCurrent["LOTNO_VCHR"].ToString(), Convert.ToDateTime(p_drCurrent["validperiod_dat"]), Convert.ToDouble(p_drCurrent["CALLPRICE_INT"]), m_objViewer.m_strStorageID, out lngSubSEQ, out p_dblRealgross, out p_dblAvailagross);
            if (lngSubSEQ > 0)
            {
                objStorage.m_dblINSTOREGROSS_INT = p_dblRealgross;
                objStorage.m_dblCURRENTGROSS_NUM = p_dblRealgross;
                lngRes = objSTDomain.m_lngDeleteStorageDetail(lngSubSEQ);
            }

            objStorage.m_lngSERIESID_INT = lngCurrentSeriesID;
            lngRes = objSTDomain.m_lngModifyStorageFromUnCommit(objStorage, lngCurrentSeriesID);

            lngRes = objSTDomain.m_lngStatisticsStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID);
        }
        #endregion

        #region 获取入库明细表内容


        /// <summary>
        /// 获取入库明细表内容


        /// </summary>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal long m_lngGetInstorageDetal(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetInstorageDetal(objPrincipal, p_lngSeries2ID, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取入库明细表内容(零售金额为数值型)
        /// <summary>
        /// 获取入库明细表内容(零售金额为数值型)
        /// </summary>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal long m_lngGetInstorageDetal_money(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetInstorageDetal_money(objPrincipal, p_lngSeries2ID, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取仓库名


        /// <summary>
        /// 获取仓库名


        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <returns></returns>
        internal string m_strStoreRoomName(string p_strStoreRoomID)
        {
            string strStoreRoomName = string.Empty;
            long lngRes = m_objDomain.m_lngGetStoreRoomName(p_strStoreRoomID, out strStoreRoomName);
            return strStoreRoomName;
        }
        #endregion

        #region 打印预览窗体
        /// <summary>
        /// 打印预览窗体
        /// </summary>
        /// <returns></returns>
        internal long m_purchasePrint()
        {
            if (this.m_objViewer.m_dtbMedicineInfo.Rows.Count < 1)
            {
                MessageBox.Show("抱歉，没有数据可预览！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            frmPurchase_DetailReport frmReport = new frmPurchase_DetailReport();
            DataTable p_dtbVal = new DataTable();
            long aa = Convert.ToInt32(this.m_objViewer.m_dtbMedicineInfo.Rows[0]["seriesid2_int"].ToString());
            m_lngGetInstorageDetal_money(Convert.ToInt32(this.m_objViewer.m_dtbMedicineInfo.Rows[0]["seriesid2_int"].ToString()), out p_dtbVal);
            DetalReportVal Drv;
            //报表头信息


            Drv.p_dtbVal = p_dtbVal;

            int Prows;

            int printType;//0伦教 1佛二 2茶山,3台山
            this.m_objDomain.m_lngGetPrinType(out printType);
            //添加空行补齐（伦教）
            if (printType == 0)
            {
                //按药品ID排序
                DataView dtv = new DataView();
                dtv = Drv.p_dtbVal.DefaultView;
                dtv.Sort = "medicinecode";
                Drv.p_dtbVal = dtv.ToTable();

                //this.m_objDomain.m_lngGetPrinRow(out Prows);
                DataRow dro;
                Prows = 7;
                if (Drv.p_dtbVal.Rows.Count % Prows != 0)
                {
                    int ros = Prows - Drv.p_dtbVal.Rows.Count % Prows;
                    int valCount = Drv.p_dtbVal.Rows.Count + ros;
                    for (int i = 0; i < ros; i++)
                    {
                        dro = Drv.p_dtbVal.NewRow();
                        dro["seriesid2_int"] = i;
                        Drv.p_dtbVal.Rows.Add(dro);
                    }
                }
                frmReport.datWindow.DataWindowObject = "purchase_detailreport_lj";
            }
            else if (printType == 1)
            {
                frmReport.datWindow.DataWindowObject = "purchase_detailreport_fs";
            }
            else if (printType == 2)
            {
                Drv.p_dtbVal.Columns.Add("group_int", typeof(System.Int32));
                int intGroup = 0;
                for (int i = 0; i < Drv.p_dtbVal.Rows.Count; i++)
                {
                    if (i % 16 == 0)
                    {
                        intGroup++;
                    }
                    Drv.p_dtbVal.Rows[i]["group_int"] = intGroup;

                }
                frmReport.datWindow.DataWindowObject = "purchase_detailreport_cs";
            }
            else if (printType == 3)
            {
                frmReport.datWindow.DataWindowObject = "purchase_detailreport_ts";
            }

            Drv.ProviderName = this.m_objViewer.m_txtProviderName.Text;
            Drv.IncomeBillNumber = this.m_objViewer.m_txtIncomeBillNumber.Text;
            Drv.InvoiceNumber = this.m_objViewer.m_txtInvoiceNumber.Text;
            Drv.InComeDate = this.m_objViewer.m_dtpInComeDate.Text;
            Drv.ProvidBillNo = this.m_objViewer.m_txtProvidBillNo.Text;
            Drv.InvoiceDate = this.m_objViewer.m_txtInvoiceDate.Text;
            Drv.PurchasePerson = this.m_objViewer.m_txtPurchasePerson.Text;
            Drv.MakeBillPerson = this.m_objViewer.m_txtMakeBillPerson.Text;
            Drv.StroehouseManager = this.m_objViewer.m_txtStroehouseManager.Text;
            Drv.Accountant = this.m_objViewer.m_txtAccountant.Text;
            Drv.Remark = this.m_objViewer.m_txtRemark.Text;
            Drv.StorageName = m_strStoreRoomName(this.m_objViewer.m_strStorageID);
            Drv.strBigWrith = new Money(Convert.ToDecimal(m_objViewer.m_lblAllInMoney.Text)).ToString();
            frmReport.Drv = Drv;

            // frmReport.TopMost = true;
            frmReport.ShowDialog();
            return 1;
        }
        #endregion

        #region 直接打印
        /// <summary>
        /// 直接打印
        /// </summary>
        /// <returns></returns>
        internal long m_mthPrintDirect()
        {
            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;

            DataTable p_dtbVal = new DataTable();
            m_lngGetInstorageDetal_money(Convert.ToInt32(this.m_objViewer.m_dtbMedicineInfo.Rows[0]["seriesid2_int"].ToString()), out p_dtbVal);

            int Prows;
            int printType;
            this.m_objDomain.m_lngGetPrinType(out printType);
            //添加空行补齐（伦教）
            if (printType == 0)
            {
                //按药品ID排序
                DataView dtv = new DataView();
                dtv = p_dtbVal.DefaultView;
                dtv.Sort = "medicinecode";
                p_dtbVal = dtv.ToTable();

                this.m_objDomain.m_lngGetPrinRow(out Prows);
                DataRow dro;
                int ros = 7 - p_dtbVal.Rows.Count % 7;
                int valCount = p_dtbVal.Rows.Count + ros;
                for (int i = 0; i < ros; i++)
                {
                    dro = p_dtbVal.NewRow();
                    dro["seriesid2_int"] = i;
                    p_dtbVal.Rows.Add(dro);
                    dsData.DataWindowObject = "purchase_detailreport_lj";
                    dsData.Modify("t_tile.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "采购入库单" + "'");
                }
            }
            else if (printType == 1)
            {
                dsData.DataWindowObject = "purchase_detailreport_fs";
                dsData.Modify("t_tile.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "采购入库单" + "'");
            }
            if (printType == 2)
            {
                this.m_objDomain.m_lngGetPrinRow(out Prows);
                p_dtbVal.Columns.Add("group_int", typeof(System.Int32));
                int intGroup = 0;
                for (int i = 0; i < p_dtbVal.Rows.Count; i++)
                {
                    if (i % 16 == 0)
                    {
                        intGroup++;
                    }
                    p_dtbVal.Rows[i]["group_int"] = intGroup;

                }

                dsData.DataWindowObject = "purchase_detailreport_cs";
                decimal decBug = Convert.ToDecimal(m_objViewer.m_lblAllInMoney.Text);
                string mmm = new Money(decBug).ToString();
                dsData.Modify("t_mone.text='" + mmm + "'");
                dsData.Modify("t_tile.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "采购入库单(" + m_strStoreRoomName(this.m_objViewer.m_strStorageID) + ")'");
            }
            dsData.Modify("m_txtProviderName.text='" + this.m_objViewer.m_txtProviderName.Text + "'");
            dsData.Modify("m_txtIncomeBillNumber.text='" + this.m_objViewer.m_txtIncomeBillNumber.Text + "'");
            dsData.Modify("m_txtInvoiceNumber.text='" + this.m_objViewer.m_txtInvoiceNumber.Text + "'");
            dsData.Modify("m_dtpInComeDate.text='" + this.m_objViewer.m_dtpInComeDate.Text + "'");
            dsData.Modify("m_txtProvidBillNo.text='" + this.m_objViewer.m_txtProvidBillNo.Text + "'");
            dsData.Modify("m_txtInvoiceDate.text='" + this.m_objViewer.m_txtInvoiceDate.Text + "'");
            dsData.Modify("m_txtPurchasePerson.text='" + this.m_objViewer.m_txtPurchasePerson.Text + "'");
            dsData.Modify("m_txtMakeBillPerson.text='" + this.m_objViewer.m_txtMakeBillPerson.Text + "'");
            dsData.Modify("m_txtStroehouseManager.text='" + this.m_objViewer.m_txtStroehouseManager.Text + "'");
            dsData.Modify("m_txtAccountant.text='" + this.m_objViewer.m_txtAccountant.Text + "'");
            dsData.Modify("m_txtRemark.text='" + this.m_objViewer.m_txtRemark.Text + "'");
            dsData.Modify("m_StorageName.text='" + m_strStoreRoomName(this.m_objViewer.m_strStorageID) + "'");

            int m_intShow;
            ((clsDcl_Purchase_Detail)m_objDomain).m_lngGetIfShowInfo(out m_intShow);
            if (m_intShow == 0)
                dsData.Modify("t_info.text=''");
            dsData.Retrieve(p_dtbVal);
            dsData.CalculateGroups();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
            return 1;
        }
        #endregion

        #region 输入有效期回车后跳转控制
        public void m_mthSetEnter()
        {
            if (iGrossType == 1)
            {

            }
        }
        #endregion


        public clsMS_OutStorage_VO m_objGetOutMainISVO()
        {
            clsMS_OutStorage_VO m_objCurrentOutMain = new clsMS_OutStorage_VO();
            m_objCurrentOutMain.m_dtmASKDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            m_objCurrentOutMain.m_intSTATUS = 1;



            if (m_objViewer.m_txtExportDept.Tag != null)
            {
                m_objCurrentOutMain.m_strASKDEPT_CHR = m_objViewer.m_txtExportDept.StrItemId;
            }
            else
            {
                m_objCurrentOutMain.m_strASKDEPT_CHR = string.Empty;
            }

            m_objCurrentOutMain.m_intOutStorageTYPE_INT = 3; //即入即出
            m_objCurrentOutMain.m_intFORMTYPE_INT = 1;
            m_objCurrentOutMain.m_strASKERID_CHR = m_objViewer.m_txtMakeBillPerson.Tag.ToString();
            m_objCurrentOutMain.m_strCOMMENT_VCHR = m_objViewer.m_txtRemark.Text;
            m_objCurrentOutMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            m_objCurrentOutMain.m_dtmOutStorageDate = Convert.ToDateTime(m_objViewer.m_dtpInComeDate.Text);
            return m_objCurrentOutMain;
        }

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_drDetail">子表数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ)
        {
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }

            objDetailArr = new clsMS_OutStorageDetail_VO[p_drDetail.Length];
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                m_objDomain.m_lngGetMedicineTypeVisionm(p_drDetail[iRow]["MEDICINEID_CHR"].ToString(), out m_objViewer.m_clsTypeVisVO);
                objDetailArr[iRow] = new clsMS_OutStorageDetail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCH = p_drDetail[iRow]["medicinename_vch"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["UNIT_VCHR"].ToString();
                objDetailArr[iRow].m_dblNETAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["AMOUNT"]);

                m_objDomain.m_lngGetMedicineTypeVisionm(p_drDetail[iRow]["medicinetypeid_chr"].ToString(), out m_objViewer.m_clsTypeVisVO);
                if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && p_drDetail[iRow]["LOTNO_VCHR"].ToString().Trim() == "")
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail[iRow]["LOTNO_VCHR"].ToString();
                }

                //objDetailArr[iRow].m_strINSTORAGEID_VCHR = p_drDetail[iRow]["INSTORAGEID_VCHR"].ToString();
                objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["WHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["RETAILPRICE_INT"]);
                objDetailArr[iRow].m_strVENDORID_CHR = m_objViewer.m_txtProviderName.Tag.ToString();
                objDetailArr[iRow].m_strVendorName = m_objViewer.m_txtProviderName.Text;
                objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail[iRow]["validperiod_dat"]);
                objDetailArr[iRow].m_strProductorID_chr = p_drDetail[iRow]["PRODUCTORID_CHR"].ToString();
                objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(m_objViewer.m_dtpInComeDate.Text);
                objDetailArr[iRow].m_strMedicineTypeID_chr = p_drDetail[iRow]["medicinetypeid_chr"].ToString();
                objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail[iRow]["VALIDPERIOD_DAT"]);
                //objDetailArr[iRow].m_dblRealGross = Convert.ToDouble(p_drDetail[iRow]["realgross_int"]);
                objDetailArr[iRow].m_intStatus = 1;
                objDetailArr[iRow].m_intRETURNNUM_INT = 0;
                objDetailArr[iRow].m_decPackQty = Convert.ToDecimal(p_drDetail[iRow]["PackQty_Dec"]);
                objDetailArr[iRow].m_dtmPRODUCEDATE_DAT = Convert.ToDateTime(m_objViewer.m_txtProduceDate.Text);
            }
            return objDetailArr;
        }
        #endregion


        internal void m_mthUnCommitInOut()
        {
            long[] strSEQ = new long[1];
            string[] strInStor = new string[1];
            strSEQ[0] = m_objViewer.m_lngMainSEQ;
            strInStor[0] = m_objViewer.m_txtIncomeBillNumber.Text;

            m_objDomain.m_lngUnCommit(m_objViewer.m_strStorageID, strSEQ, strInStor);
        }


        internal void m_lngGetShowWholePrice(out int m_intShowWholePrice)
        {
            ((clsDcl_Purchase_Detail)m_objDomain).m_lngGetShowWholePrice(out m_intShowWholePrice);
        }

        #region 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// </summary>
        /// <param name="m_intCanModifyMakeDate">是否允许修改</param>
        internal void m_lngGetCanModifyAutoExam(out int m_intCanModifyAutoExam)
        {
            m_objDomain.m_lngGetCanModifyAutoExam(out m_intCanModifyAutoExam);
        }
        #endregion

        #region 检查单据状态
        /// <summary>
        /// 检查单据状态
        /// </summary>
        /// <param name="p_lngMainSEQ"></param>
        /// <param name="p_intStatusTemp"></param>
        internal void m_lngCheckStatus(long p_lngMainSEQ, out int p_intStatusTemp)
        {
            m_objDomain.m_lngCheckStatus(p_lngMainSEQ, out p_intStatusTemp);
        }
        #endregion
    }
}
