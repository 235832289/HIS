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
    /// 药品内退调用出库单类
    /// </summary>
    public partial class frmCallOutStorageBill : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 字段
        private bool m_blnDataAvail = true;
        /// <summary>
        /// 下一个获得焦点的控件
        /// </summary>
        Control m_ctlNext = null;
        /// <summary>
        /// 参与跳转的控件数组

        /// </summary>
        private Control[] m_ctlControls = null;
        /// <summary>
        /// 控件激活标志

        /// </summary>
        private bool m_CtlActivate = false;

        /// <summary>
        /// 出库单查询参数

        /// </summary>
        private clsMs_MedicineWithdrawOutStorageQueryCondition_VO m_value_Param;


        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;

        /// <summary>
        /// 仓库名称
        /// </summary>
        string m_strStoreRoomName = string.Empty;

        /// <summary>
        /// 退药单位ID
        /// </summary>
        private string m_strWithdrawDeptID = string.Empty;

        /// <summary>
        /// 退药单位名称

        /// </summary>
        private string m_strWithdrawDept = string.Empty;

        /// <summary>
        ///  药典查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        /// <summary>
        /// 药品基本信息
        /// </summary>
        private clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();

        /// <summary>
        /// 药典数据表

        /// </summary>
        internal DataTable m_dtbMedicinDict = null;

        /// <summary>
        /// 药品出库主表
        /// </summary>
        private DataTable m_dtbOutStorageMain = null;

        /// <summary>
        /// 药品出库明细表

        /// </summary>
        private DataTable m_dtbOutStorageDetail = null;

        /// <summary>
        /// 药品内退明细表

        /// </summary>
        private DataTable m_dtbMedicineCancelDetail = null;

        internal readonly int m_intMedicineCodeColIndex = 3;
        internal readonly int m_intAmountColIndex = 7;

        #endregion 字段

        #region 属性

        /// <summary>
        /// 退药单位ID属性

        /// </summary>
        public string WithdrawDept
        {
            get
            {
                return m_strWithdrawDept;
            }
            set
            {
                m_strWithdrawDept = value;
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

        #endregion 属性


        #region 构造函数


        /// <summary>
        /// 构造函数

        /// </summary>
        public frmCallOutStorageBill()
        {
            InitializeComponent();
            m_dtpSearchBeginDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;
            //m_objMedicineWithdrawCtl = new clsCtl_InMedicineWithdraw();


            m_objMedicineBase.m_strMedicineID = string.Empty;
            m_objMedicineBase.m_strAssistCode = string.Empty;
            m_objMedicineBase.m_strMedicineName = string.Empty;
            m_objMedicineBase.m_strMedSpec = string.Empty;

            m_ctlControls = new Control[] {
                m_dtpSearchEndDate,
                m_txtOutStorageBillNo,
                m_cboOutStorageType,
                m_txtMedicineName,
                m_txtLotNo};
            m_mthSetNextControl(ref m_ctlControls);

            m_mthSetControlHighLight();
        }

        /// <summary>
        /// 带参构造函数

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strWithdrawDept">内退单位ID</param>
        public frmCallOutStorageBill(string p_strStorageID, string p_strStoreRoomName,string p_strWithdrawDeptID, string p_strWithdrawDept, ref DataTable p_dtbDetail)
            : this()
        {
            m_strWithdrawDeptID = p_strWithdrawDeptID;
            WithdrawDept = p_strWithdrawDept;
            StorageID = p_strStorageID;
            StoreRoomName = p_strStoreRoomName;
            m_dtbMedicineCancelDetail = p_dtbDetail;
            if (!string.IsNullOrEmpty(p_strStoreRoomName))
            {
                this.Text += " (药库：" + p_strStoreRoomName + "  内退单位：" + m_strWithdrawDept + " ) ";
            }

        }

        #endregion 构造函数


        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicWithdrawCallOutStorage();
            objController.Set_GUI_Apperance(this);
        }


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
                if ((m_ctlControls[ctlIndex].Name == "m_txtMedicineName"))
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

        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(panel1, Color.Moccasin);
            objCtl.m_mthSelectAllText(panel1);
        }


        /// <summary>
        /// 在药品框中按回车键后，显示药典查询窗口

        /// </summary>
        private void m_mthPopupWindow()
        {
            long lngRes = 0;
            if (StorageID.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();

            ////调用Com+服务端

            //m_dtbMedicinDict = null;
            //lngRes = objDomain.m_lngGetBaseMedicine(m_txtMedicineName.Text.Trim(), StorageID, out  m_dtbMedicinDict);

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
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);

            }

            m_ctlQueryMedicint.Visible = true;

            int X = panel1.Location.X + m_txtMedicineName.Location.X;
            int Y = panel1.Location.Y + m_txtMedicineName.Location.Y + m_txtMedicineName.Height;


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

            m_txtLotNo.Focus();
        }

        /// <summary>
        /// 获取出库主表数据
        /// </summary>
        public void m_mthGetOutStorageData()
        {
            long lngRes = 0;

            m_dtbOutStorageMain = null;
            m_dtbOutStorageDetail = null;
            m_dgvMainInfo.DataSource = "";
            m_dgvSubInfo.DataSource = "";
            if (m_value_Param == null)
                m_value_Param = new clsMs_MedicineWithdrawOutStorageQueryCondition_VO();


            m_value_Param.m_strQueryBeginDate = string.Empty;
            m_value_Param.m_strQueryEndDate = string.Empty;
            m_value_Param.m_strStorageID = string.Empty;
            m_value_Param.m_strOutStorageID = string.Empty;
            m_value_Param.m_intOutStorageType = 0;
            m_value_Param.m_strMedicineID = string.Empty;
            m_value_Param.m_strLotNo = string.Empty;


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
            //出库单号
            m_value_Param.m_strOutStorageID = m_txtOutStorageBillNo.Text.Trim();
            //药品批号
            m_value_Param.m_strLotNo = m_txtLotNo.Text.Trim();
            //药品代码
            if (m_txtMedicineName.Text.Trim().Length == 0)
                m_value_Param.m_strMedicineID = string.Empty;
            else
                m_value_Param.m_strMedicineID = m_objMedicineBase.m_strMedicineID;
            //出库类型
            if (m_cboOutStorageType.Text.Trim() == "全部")
                m_value_Param.m_intOutStorageType = 0;
            else
            {
                if (m_cboOutStorageType.Text.Trim() == "领药出库")
                    m_value_Param.m_intOutStorageType = 1;
                else if (m_cboOutStorageType.Text.Trim() == "销售出库")
                    m_value_Param.m_intOutStorageType = 2;
                else
                    m_value_Param.m_intOutStorageType = -1;
            }
            //单据类型
            m_value_Param.m_intFormType = 1;
            //单据状态

            m_value_Param.m_intStatus = 2;
            //出库部门
            m_value_Param.m_strASKDEPT_CHR = m_strWithdrawDeptID;

            //lngRes = m_objMedicineWithdrawCtl.m_mthGetOutStorageMainData(ref m_value_Param, out m_dtbOutStorageMain);
            lngRes = ((clsCtl_MedicWithdrawCallOutStorage)objController).m_mthGetOutStorageMainData(ref m_value_Param, out m_dtbOutStorageMain);
            if (lngRes > 0)
            {
                m_dgvMainInfo.DataSource = m_dtbOutStorageMain;
            }

        }

        /// <summary>
        /// 获取出库明细数据
        /// </summary>
        private void m_mthGetOutStorageDetailDate()
        {
            long lngRes = 0;
            if ((m_dtbOutStorageMain != null) && (m_dtbOutStorageMain.Rows.Count > 0))
            {
                int m_intSn = 0;
                int m_intRowIndex = 0;
                clsMs_OutStorageDetailQueryCondition_VO objvalue_Param = new clsMs_OutStorageDetailQueryCondition_VO();
                m_dtbOutStorageDetail = null;
                //m_dgvSubInfo.DataSource = "";
                m_intRowIndex = m_dgvMainInfo.CurrentRow.Index;
                objvalue_Param.m_strStorageID = m_strStorageID;
                int.TryParse(m_dtbOutStorageMain.Rows[m_intRowIndex]["SERIESID_INT"].ToString(), out objvalue_Param.m_intSERIESID2_INT);
                objvalue_Param.m_strOutStorageID = m_dtbOutStorageMain.Rows[m_intRowIndex]["OUTSTORAGEID_VCHR"].ToString();
                objvalue_Param.m_intStatus = 1;

                lngRes = ((clsCtl_MedicWithdrawCallOutStorage)objController).m_mthGetOutStorageDetailData(ref objvalue_Param, ref m_dtbMedicineCancelDetail, out m_dtbOutStorageDetail);
                if (lngRes > 0)
                {
                    m_dgvSubInfo.DataSource = m_dtbOutStorageDetail;
                    DataRow m_dtbRow = null;
                    for (int i1 = 0; i1 < m_dtbOutStorageDetail.Rows.Count; i1++)
                    {
                        m_dtbRow = m_dtbOutStorageDetail.Rows[i1];
                        if (Convert.ToDecimal(m_dtbRow["AvailAmount"].ToString()) <= 0)
                        {
                            for (int j1 = 0; j1 < m_dgvSubInfo.ColumnCount; j1++)
                            {
                                m_dgvSubInfo.Rows[i1].Cells[j1].Style.ForeColor = Color.Red;
                                m_dgvSubInfo.Rows[i1].Cells[j1].Style.SelectionForeColor = Color.Red;
                            }
                            m_dgvSubInfo.Rows[i1].Cells[0].ReadOnly = true;
                            m_dgvSubInfo.Rows[i1].Cells[m_intAmountColIndex].ReadOnly = true;
                        }

                    }//for
                    if(m_dgvSubInfo.Rows.Count > 0)
                    m_dgvSubInfo.CurrentCell = m_dgvSubInfo[7, 0];

                }
            }

        }

        /// <summary>
        /// 选入已选中的记录

        /// </summary>
        public void m_mthCall()
        {
            if ((m_dtbOutStorageDetail != null) && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                DataRow m_dtbCancelDetailRow = null;
                DataRow m_dtbOutStorageDetailRow = null;
                DataRow m_dtbRow = null;
                decimal m_decOutStorageAvailAmount = 0;
                decimal m_decCancelAvailAmount = 0;
                decimal m_decAvailAmount = 0;
                decimal m_decCallPrice = 0;
                decimal m_decRetailPrice = 0;
                decimal m_decWholesalePrice = 0;
                bool blnNewRow = false;
                int j1 = 0;
                for (int i1 = 0; i1 < m_dtbOutStorageDetail.Rows.Count; i1++)
                {
                    if (Convert.ToBoolean(m_dgvSubInfo.Rows[i1].Cells[0].Value))
                    {
                        m_dtbOutStorageDetailRow = m_dtbOutStorageDetail.Rows[i1];
                        blnNewRow = true;
                        for (j1 = 0; j1 < m_dtbMedicineCancelDetail.Rows.Count; j1++)
                        {
                            m_dtbCancelDetailRow = m_dtbMedicineCancelDetail.Rows[j1];
                            if ((m_dtbCancelDetailRow["MEDICINEID_CHR"].ToString().Trim() == m_dtbOutStorageDetailRow["MEDICINEID_CHR"].ToString())
                               && (m_dtbCancelDetailRow["LOTNO_VCHR"].ToString().Trim() == m_dtbOutStorageDetailRow["LOTNO_VCHR"].ToString())
                               && (m_dtbCancelDetailRow["OUTSTORAGEID_VCHR"].ToString().Trim() == m_dtbOutStorageDetailRow["OUTSTORAGEID_VCHR"].ToString()))
                            {
                                break;
                            }
                        }

                        if (j1 == m_dtbMedicineCancelDetail.Rows.Count)
                        {
                            for (j1 = 0; j1 < m_dtbMedicineCancelDetail.Rows.Count; j1++)
                            {
                                m_dtbCancelDetailRow = m_dtbMedicineCancelDetail.Rows[j1];
                                if ((m_dtbCancelDetailRow["MEDICINEID_CHR"].ToString().Trim() == m_dtbOutStorageDetailRow["MEDICINEID_CHR"].ToString())
                                   && (m_dtbCancelDetailRow["LOTNO_VCHR"].ToString().Trim() == ""))
                                {
                                    break;
                                }
                            }
                            if (j1 == m_dtbMedicineCancelDetail.Rows.Count)
                            {
                                m_dtbRow = m_dtbMedicineCancelDetail.NewRow();
                                blnNewRow = true;
                            }
                            else
                            {
                                m_dtbRow = m_dtbMedicineCancelDetail.Rows[j1];
                                blnNewRow = false;
                            }


                            if (m_dtbMedicineCancelDetail != null)
                            {
                                if (blnNewRow)
                                    m_dtbRow["SortNum"] = m_dtbMedicineCancelDetail.Rows.Count + 1;
                            }
                            else
                                m_dtbRow["SortNum"] = 1;

                            decimal.TryParse(m_dtbOutStorageDetail.Rows[i1]["AvailAmount"].ToString(), out  m_decAvailAmount);

                            decimal.TryParse(m_dtbOutStorageDetail.Rows[i1]["CALLPRICE_INT"].ToString(), out m_decCallPrice);
                            decimal.TryParse(m_dtbOutStorageDetail.Rows[i1]["RETAILPRICE_INT"].ToString(), out m_decRetailPrice);
                            decimal.TryParse(m_dtbOutStorageDetail.Rows[i1]["WHOLESALEPRICE_INT"].ToString(), out m_decWholesalePrice);

                            m_dtbRow["MEDICINEID_CHR"] = m_dtbOutStorageDetail.Rows[i1]["MEDICINEID_CHR"];
                            m_dtbRow["ASSISTCODE_CHR"] = m_dtbOutStorageDetail.Rows[i1]["ASSISTCODE_CHR"];
                            m_dtbRow["MEDICINENAME_VCH"] = m_dtbOutStorageDetail.Rows[i1]["medicinename_vchr"];
                            m_dtbRow["MEDSPEC_VCHR"] = m_dtbOutStorageDetail.Rows[i1]["MEDSPEC_VCHR"];
                            m_dtbRow["LOTNO_VCHR"] = m_dtbOutStorageDetail.Rows[i1]["LOTNO_VCHR"];
                            m_dtbRow["AVAILAGROSS_INT"] = m_dtbOutStorageDetail.Rows[i1]["AVAILAGROSS_INT"];
                            m_dtbRow["NETAMOUNT_INT"] = m_dtbOutStorageDetail.Rows[i1]["NETAMOUNT_INT"];
                            m_dtbRow["CancelAmount"] = m_dtbOutStorageDetail.Rows[i1]["ReturnAmount"];
                            m_dtbRow["AvailAmount"] = m_dtbOutStorageDetail.Rows[i1]["AvailAmount"];//可退数量
                            m_dtbRow["AMOUNT"] = m_dtbOutStorageDetail.Rows[i1]["Amount"];//退药数量

                            m_dtbRow["OPUNIT_CHR"] = m_dtbOutStorageDetail.Rows[i1]["OPUNIT_CHR"];
                            m_dtbRow["CALLPRICE_INT"] = m_dtbOutStorageDetail.Rows[i1]["CALLPRICE_INT"];
                            m_dtbRow["CallSum"] = m_decAvailAmount * m_decCallPrice;
                            m_dtbRow["RetailSum"] = m_decAvailAmount * m_decRetailPrice;
                            m_dtbRow["RETAILPRICE_INT"] = m_dtbOutStorageDetail.Rows[i1]["RETAILPRICE_INT"];
                            m_dtbRow["withdrawsum"] = Convert.ToDecimal(m_dtbOutStorageDetail.Rows[i1]["Amount"].ToString()) * m_decCallPrice;

                            m_dtbRow["WHOLESALEPRICE_INT"] = m_dtbOutStorageDetail.Rows[i1]["WHOLESALEPRICE_INT"];
                            m_dtbRow["INSTORAGEID_VCHR"] = m_dtbOutStorageDetail.Rows[i1]["INSTORAGEID_VCHR"];
                            m_dtbRow["OUTSTORAGEID_VCHR"] = m_dtbOutStorageMain.Rows[m_dgvMainInfo.CurrentRow.Index]["OUTSTORAGEID_VCHR"];
                            m_dtbRow["PRODUCTORID_CHR"] = m_dtbOutStorageDetail.Rows[i1]["productorid_chr"];
                            m_dtbRow["VALIDPERIOD_DAT"] = m_dtbOutStorageDetail.Rows[i1]["validperiod_dat"];//有效期

                            m_dtbRow["RUTURNNUM_INT"] = m_dtbOutStorageDetail.Rows[i1]["ReturnNum"];//内退次数
                            //m_dtbRow["PACKCONVERT_INT"] = m_dtbOutStorageDetail.Rows[i1][""];
                            //m_dtbRow["PACKAMOUNT"] = m_dtbOutStorageDetail.Rows[i1][""];
                            //m_dtbRow["PACKUNIT_VCHR"] = m_dtbOutStorageDetail.Rows[i1][""];
                            //m_dtbRow["PACKCALLPRICE_INT"] = m_dtbOutStorageDetail.Rows[i1][""];
                            if (blnNewRow)
                            {
                                m_dtbMedicineCancelDetail.Rows.Add(m_dtbRow);


                            }

                        }

                    }//if

                }//for

            }
        }


        #endregion 方法

        #region 事件

        /// <summary>
        /// 查询按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdOutStorageBill_Click(object sender, EventArgs e)
        {
            m_lblSelectAll.Text = "全选";

            if ((m_dtbOutStorageMain != null)
                && (m_dtbOutStorageMain.Rows.Count > 0))
            {
                m_dtbOutStorageMain.Rows.Clear();
            }

            if((m_dtbOutStorageDetail != null)
                && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                m_dtbOutStorageDetail.Rows.Clear();
            }

            m_mthGetOutStorageData();
            if ((m_dtbOutStorageMain != null) && (m_dtbOutStorageMain.Rows.Count > 0))
            {
                m_mthGetOutStorageDetailDate();
                m_dgvMainInfo.Focus();
                if ((m_dtbOutStorageDetail != null) && (m_dtbOutStorageDetail.Rows.Count > 0))
                {
                    //m_dtbOutStorageDetail.PrimaryKey = new DataColumn[] { m_dtbOutStorageDetail.Columns["MEDICINEID_CHR"], m_dtbOutStorageDetail.Columns["LOTNO_VCHR"] };

                    m_dgvSubInfo.CurrentCell = m_dgvSubInfo[m_intAmountColIndex, 0];
                }
            }
        }

        /// <summary>
        /// 退出按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 选入按钮Click事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdCallMedicine_Click(object sender, EventArgs e)
        {
            m_mthCall();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// 出库单主表Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dgvMainInfo_Click(object sender, EventArgs e)
        {
            if ((m_dtbOutStorageDetail != null)
                && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                m_dtbOutStorageDetail.Rows.Clear();
            }

            if ((m_dtbOutStorageMain != null) && (m_dtbOutStorageMain.Rows.Count > 0))
                m_mthGetOutStorageDetailDate();
        }




        /// <summary>
        /// 窗体的Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCallOutStorageBill_Load(object sender, EventArgs e)
        {
            if (m_cboOutStorageType.Items.Count > 0)
            {
                m_cboOutStorageType.SelectedIndex = 0;
            }
            m_dtpSearchBeginDate.Focus();
        }

        /// <summary>
        /// 出库开始日期的Enter事件
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
        /// 出库开始日期的KeyDown事件
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
        /// 出库结束日期的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dtpSearchEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 出库单文本框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtOutStorageBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 出库类型组合框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cboOutStorageType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 批号文本框的KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                m_ctlNext.Focus();
            }

        }

        /// <summary>
        /// 全选事件

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvSubInfo.Rows.Count > 0)
            {
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
                    {
                        DataRow m_dtbRow = null;
                        m_dtbRow = m_dtbOutStorageDetail.Rows[iRow];
                        if (Convert.ToDecimal(m_dtbRow["AvailAmount"].ToString()) == 0)
                        {
                            m_dgvSubInfo.Rows[iRow].Cells[0].ReadOnly = true;
                            m_dgvSubInfo.Rows[iRow].Cells[0].Value = false;
                        }
                        else
                        {
                            if (Convert.ToDecimal(m_dtbRow["AMOUNT"].ToString()) == 0)
                            {
                                m_dgvSubInfo.Rows[iRow].Cells[0].Value = false;
                            }
                            else
                            {
                                m_dgvSubInfo.Rows[iRow].Cells[0].ReadOnly = false;
                                m_dgvSubInfo.Rows[iRow].Cells[0].Value = true;
                            }
                        }


                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
                    {
                        m_dgvSubInfo.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }
        }

        /// <summary>
        /// 明细表DataGridView的CellClick事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dgvSubInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((m_dgvSubInfo.Rows.Count > 0) && (m_dgvSubInfo.CurrentCell.ColumnIndex == 0))
            {
                m_lngCheckValue();
            }
        }

        private long m_lngCheckValue()
        {
            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal decAmount = 0;
            if (m_dgvSubInfo.Rows.Count > 0) 
            {
                int m_intRowIndex = m_dgvSubInfo.CurrentRow.Index;
                m_dtbRow = m_dtbOutStorageDetail.Rows[m_intRowIndex];

                decimal.TryParse(m_dtbRow["AvailAmount"].ToString(), out m_decAvailAmount);
                decimal.TryParse(m_dtbRow["Amount"].ToString(), out decAmount);
                if (decAmount <= 0)
                {
                    m_dgvSubInfo.CurrentRow.Cells[0].Value = false;
                }

                if (m_decAvailAmount <= 0)
                {
                    m_dgvSubInfo.CurrentRow.Cells[0].Value = false;
                    MessageBox.Show("退药数量不足！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                    return 1;
            }//if
            else
                return  -1;
        }


        #endregion 事件

        private void m_dgvSubInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //m_mthCheckAmount();
        }


        private void frmCallOutStorageBill_Shown(object sender, EventArgs e)
        {
            clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();

            //调用Com+服务端

            m_dtbMedicinDict = null;
            long  lngRes = objDomain.m_lngGetBaseMedicine("", StorageID, out  m_dtbMedicinDict);
        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthPopupWindow();
            }
        }

        private void m_dgvSubInfo_DoubleClick(object sender, EventArgs e)
        {
            if (m_dgvSubInfo.RowCount > 0)
            {
                long lngRes = m_lngCheckValue();
                if (lngRes > 0)
                {
                    m_dgvSubInfo.CurrentRow.Cells[0].Value = true;
                    m_mthCall();
                }
            }
        }

        private void m_dgvSubInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == m_intAmountColIndex)
            //{

            //    long lngRes = m_mthCheckAmount();
            //    if (lngRes < 0)
            //    {
            //        //m_dgvSubInfo.CancelEdit();
            //        m_dgvSubInfo[e.ColumnIndex,e.RowIndex].Value = 0;
            //        MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }


        private void m_dgvSubInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal m_decNetAvailAmount = 0;
            bool m_blnChkFlag = false;

            CancelJump = true;
            if (CurrentCell.ColumnIndex == m_intAmountColIndex)
            {
                m_dgvSubInfo.EndEdit();

                if (m_dgvSubInfo.Rows.Count > 0)
                {
                    int m_intRowIndex = m_dgvSubInfo.CurrentRow.Index;
                    m_dtbRow = m_dtbOutStorageDetail.Rows[m_intRowIndex];
                    //m_dgvSubInfo.EndEdit();

                    decimal.TryParse(m_dtbRow["AvailAmount"].ToString(), out m_decAvailAmount);
                    decimal.TryParse(m_dtbRow["Amount"].ToString(), out m_decNetAvailAmount);
                    if (m_decNetAvailAmount > m_decAvailAmount)
                    {
                        m_dgvSubInfo.CancelEdit();
                        //m_dgvMainInfo.CurrentCell.Value = 0;
                        //m_dgvMainInfo.EndEdit();
                        MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //m_dgvSubInfo.CurrentRow.Cells[0].Value = false;
                        m_dgvSubInfo.CurrentCell = m_dgvSubInfo[m_intAmountColIndex, m_dgvSubInfo.CurrentRow.Index];
                        m_dgvSubInfo.Focus();
                    }
                    else
                    {
                        if (m_decNetAvailAmount == 0)
                        {
                            m_dgvSubInfo.CurrentRow.Cells[0].Value = false;
                        }
                        else
                        {
                            m_dgvSubInfo.CurrentRow.Cells[0].Value = true;
                        }
                        m_dgvMainInfo.EndEdit();
                        m_mthCall();
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                }//if

            }
            else
            {
                m_mthCall();
                this.Close();
                this.DialogResult = DialogResult.OK;

            }

        }

        private long m_mthCheckAmount()
        {
            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal m_decNetAvailAmount = 0;
            bool m_blnChkFlag = false;

            //if (m_dgvSubInfo.Rows.Count > 0)
            if ((m_dtbOutStorageDetail != null) && ( m_dtbOutStorageDetail.Rows.Count > 0))
            {
                int m_intRowIndex = m_dgvSubInfo.CurrentRow.Index;
                m_dtbRow = m_dtbOutStorageDetail.Rows[m_intRowIndex];
                //m_dgvSubInfo.EndEdit();

                decimal.TryParse(m_dtbRow["AvailAmount"].ToString(), out m_decAvailAmount);
                decimal.TryParse(m_dtbRow["Amount"].ToString(), out m_decNetAvailAmount);
                if (m_decNetAvailAmount > m_decAvailAmount)
                {
                    m_blnDataAvail = false;
                    return -1;
                }
                else
                {
                    m_blnDataAvail = true;
                    if (m_decNetAvailAmount == 0)
                    {
                        m_dgvSubInfo.CurrentRow.Cells[0].Value = false;
                    }
                    else
                    {
                        m_dgvSubInfo.CurrentRow.Cells[0].Value = true;
                    }
                    return 1;

                }
            }//if
            return -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmOutStorageBillFind_MedicineInnerWithdraw frmFind = new frmOutStorageBillFind_MedicineInnerWithdraw(m_strStorageID);
            frmFind.m_mthShowFrmFind(ref m_dgvSubInfo);
            m_dgvSubInfo.Focus();


        }

        private void m_dgvMainInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Up) || (e.KeyData == Keys.Down))
            {
                if ((m_dtbOutStorageMain != null) && (m_dtbOutStorageMain.Rows.Count > 0))
                    m_mthGetOutStorageDetailDate();
            }

            else if (e.KeyData == Keys.Tab)
            {
                if (m_dgvSubInfo.RowCount > 0)
                {
                    m_dgvSubInfo.Focus();
                }
            }

        }

        private void m_dgvSubInfo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal m_decNetAvailAmount = 0;

            m_dgvSubInfo.EndEdit();

            if (e.ColumnIndex == m_intAmountColIndex)
            {
                long lngRes = m_mthCheckAmount();
                if (lngRes < 0)
                {
                    m_dgvSubInfo.CancelEdit();
                    //m_dgvSubInfo.CurrentCell.Value = 0;
                    //m_dgvSubInfo.EndEdit();
                    e.Cancel = true;
                    m_dgvSubInfo[e.ColumnIndex, e.RowIndex].Value = 0;
                    MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //m_dgvSubInfo.CurrentCell = m_dgvSubInfo[8, e.RowIndex];
                    m_dgvSubInfo.Focus();
                }
            }

        }

        private void m_dgvSubInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }

}