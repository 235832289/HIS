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
    public partial class frmInMedicineCancelCallOutStorageInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 字段

        private bool m_blnDataAvail = true;
        /// <summary>
        /// 下一个获得焦点的控件
        /// </summary>
        private Control m_ctlNext = null;
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
        private DataTable m_dtbMedicinDict = null;

        /// <summary>
        /// 药品出库明细表

        /// </summary>
        internal DataTable m_dtbOutStorageDetail = null;

        /// <summary>
        /// 药品内退制单控制器

        /// </summary>
        private clsCtl_InMedicineWithdrawMakerBill m_objCtlMedicineWithdrawMakerBill = null;


        #endregion 

        #region 属性

        /// <summary>
        /// 药典数据表

        /// </summary>
        internal DataTable dtbMedicinDict
        {
            get
            {
                return m_dtbMedicinDict;
            }
            set
            {
                m_dtbMedicinDict = value;
            }
        }

        #endregion
        #region 构造函数

        public frmInMedicineCancelCallOutStorageInfo()
        {
            InitializeComponent();
            m_dgvSubInfo.AutoGenerateColumns = false;

            m_mthSetControlHighLight();

        }

        public frmInMedicineCancelCallOutStorageInfo(clsCtl_InMedicineWithdrawMakerBill p_objCtlMedicineWithdrawMakerBill,
                                                     string p_strStorageID,
                                                     string p_strStoreRoomName): this()
        {
            m_objCtlMedicineWithdrawMakerBill = p_objCtlMedicineWithdrawMakerBill;
            m_strStorageID = p_strStorageID;
            m_strStoreRoomName = p_strStoreRoomName;

        }

        #endregion

        #region 事件
        private void m_rdbInStorageID_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbOutStorageID.Checked)
            {
                m_txtOutStorageID.Enabled = true;
                m_txtMedicineCode.Enabled = false;
                m_txtLotNo.Enabled = false;
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            ((clsCtl_InMedicineWithdrawOutStorageInfo)objController).m_mthCall();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void m_rdbMedicineCode_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineCode.Checked)
            {
                m_txtOutStorageID.Enabled = false;
                m_txtMedicineCode.Enabled = true;
                m_txtLotNo.Enabled = true;
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_lblSelectAll.Text = "全选";


            if ((m_dtbOutStorageDetail != null)
                && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                m_dtbOutStorageDetail.Rows.Clear();
            }

            m_mthGetOutStorageDetailDate();

            DataRow drCurrRow = null;
            if ((m_dtbOutStorageDetail != null) && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                for (int iRow = 0; iRow < m_dtbOutStorageDetail.Rows.Count; iRow++)
                {
                    drCurrRow = m_dtbOutStorageDetail.Rows[iRow];
                    if (Convert.ToDecimal(drCurrRow["AMOUNT"].ToString()) <= 0)
                    {
                        m_dgvSubInfo.Rows[iRow].Cells[0].Value = false;
                    }
                    else
                    {
                        m_dgvSubInfo.Rows[iRow].Cells[0].Value = true;
                    }
                }

                m_dgvSubInfo.Focus();
                m_dgvSubInfo.CurrentCell = m_dgvSubInfo[8, 0];
            }
            else
            {
                m_txtMedicineCode.Focus();
            }

        }

        #endregion 

        #region 方法

        public override void CreateController()
        {
            this.objController = new clsCtl_InMedicineWithdrawOutStorageInfo();
            objController.Set_GUI_Apperance(this);
        }

        internal long SetCallOutStorageInfo(string p_strMedicineID, string p_strMedicineName,
                                             string p_strWithdrawDeptID,string p_strWithdrawDept)
        {
            m_objMedicineBase.m_strMedicineID = p_strMedicineID;
            m_txtMedicineCode.Text = p_strMedicineName;
            m_strWithdrawDeptID = p_strWithdrawDeptID;
            m_strWithdrawDept = p_strWithdrawDept;

            if (!string.IsNullOrEmpty(m_strStoreRoomName))
            {
                this.Text = "调出库单 (药库：" + m_strStoreRoomName + "  内退单位：" + m_strWithdrawDept + " ) ";
            }


            ((clsCtl_InMedicineWithdrawOutStorageInfo)objController).m_mthSetMakerBillCtrl(m_objCtlMedicineWithdrawMakerBill);
            m_mthGetOutStorageDetailDate();
            if ((m_dtbOutStorageDetail != null) && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                return 1;
            }
            else
            {
                return -1;
            }
            //this.Visible = false;
            //this.ShowDialog();
        }
        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(m_txtOutStorageID, Color.Moccasin);
            objCtl.m_mthSelectAllText(m_txtOutStorageID);

            objCtl.m_mthSetControlHighLight(m_txtMedicineCode, Color.Moccasin);
            objCtl.m_mthSelectAllText(m_txtMedicineCode);

            objCtl.m_mthSetControlHighLight(m_txtLotNo, Color.Moccasin);
            objCtl.m_mthSelectAllText(m_txtLotNo);


        }

        /// <summary>
        /// 在药品框中按回车键后，显示药典查询窗口

        /// </summary>
        private void m_mthPopupWindow(string strFilter)
        {
            long lngRes = 0;
            if (m_strStorageID.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();

            //调用Com+服务端

            //m_dtbMedicinDict = null;
            //lngRes = objDomain.m_lngGetBaseMedicine(strFilter, m_strStorageID, out  m_dtbMedicinDict);

            if (m_dtbMedicinDict != null)
            {
                m_mthShowQueryMedicineForm(strFilter);
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

            int X = m_txtMedicineCode.Location.X;
            int Y = m_txtMedicineCode.Location.Y + m_txtMedicineCode.Height;


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
                m_txtMedicineCode.Text = string.Empty;

                m_objMedicineBase.m_strMedicineID = string.Empty;
                m_objMedicineBase.m_strAssistCode = string.Empty;
                m_objMedicineBase.m_strMedicineName = string.Empty;
                m_objMedicineBase.m_strMedSpec = string.Empty;
                return;
            }
            m_txtMedicineCode.Text = MS_VO.m_strMedicineName;

            m_objMedicineBase.m_strMedicineID = MS_VO.m_strMedicineID;
            m_objMedicineBase.m_strAssistCode = MS_VO.m_strMedicineCode;
            m_objMedicineBase.m_strMedicineName = MS_VO.m_strMedicineName;
            m_objMedicineBase.m_strMedSpec = MS_VO.m_strMedicineSpec;

            m_txtLotNo.Focus();
        }

        /// <summary>
        /// 获取出库明细数据
        /// </summary>
        private void m_mthGetOutStorageDetailDate()
        {
            long lngRes = 0;

            if ((m_dtbOutStorageDetail != null) && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                m_dtbOutStorageDetail.Rows.Clear();
            }

            int m_intSn = 0;
            int m_intRowIndex = 0;
            clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param = new clsMs_MedicineWithdrawOutStorageQueryCondition_VO();
            m_dtbOutStorageDetail = null;
            //m_dgvSubInfo.DataSource = "";
            if (m_rdbOutStorageID.Checked)
            {
                objvalue_Param.m_strStorageID = m_strStorageID;
                objvalue_Param.m_strASKDEPT_CHR = m_strWithdrawDeptID;
                objvalue_Param.m_strOutStorageID = m_txtOutStorageID.Text.Trim();
                objvalue_Param.m_strMedicineID = string.Empty;
                objvalue_Param.m_strLotNo = string.Empty;
            }
            else
            {
                objvalue_Param.m_strStorageID = m_strStorageID;
                objvalue_Param.m_strASKDEPT_CHR = m_strWithdrawDeptID;
                objvalue_Param.m_strOutStorageID = string.Empty;
                objvalue_Param.m_strMedicineID = m_objMedicineBase.m_strMedicineID;
                objvalue_Param.m_strLotNo = m_txtLotNo.Text.Trim();
            }

            lngRes = ((clsCtl_InMedicineWithdrawOutStorageInfo)objController).m_mthGetOutStorageDetailData(ref objvalue_Param);
            if (lngRes > 0)
            {
                m_dgvSubInfo.DataSource = m_dtbOutStorageDetail;
                m_mthCheckAvailAmount();
            }

        }

        #endregion

        private void m_mthCheckAvailAmount()
        {
            DataRow m_dtbRow = null;
            for (int i1 = 0; i1 < m_dtbOutStorageDetail.Rows.Count; i1++)
            {
                m_dtbRow = m_dtbOutStorageDetail.Rows[i1];
                if (Convert.ToDecimal(m_dtbRow["AvailAmount"].ToString()) <= 0)
                {
                    for (int j1 = 0; j1 < m_dgvSubInfo.ColumnCount; j1++)
                    {
                        m_dgvSubInfo.Rows[i1].Cells[j1].Style.ForeColor = Color.Red;
                    }
                    m_dgvSubInfo.Rows[i1].Cells[0].ReadOnly = true;
                    m_dgvSubInfo.Rows[i1].Cells[8].ReadOnly = true;
                }
                else
                {
                    m_dgvSubInfo.Rows[i1].Cells[0].ReadOnly = false;
                    m_dgvSubInfo.Rows[i1].Cells[8].ReadOnly = false;

                }


            }//for

        }
        /// <summary>
        /// 标签m_lblSelectAll的全选事件

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
                        if (Convert.ToDecimal(m_dtbRow["AvailAmount"].ToString()) <= 0)
                        {
                            m_dgvSubInfo.Rows[iRow].Cells[0].ReadOnly = true;
                            m_dgvSubInfo.Rows[iRow].Cells[0].Value = false;
                        }
                        else
                        {
                            m_dgvSubInfo.Rows[iRow].Cells[0].ReadOnly = false;
                            m_dgvSubInfo.Rows[iRow].Cells[0].Value = true;
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


        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthPopupWindow(m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSearch.Focus();
            }
        }


        private void frmInMedicineCancelCallOutStorageInfo_Shown(object sender, EventArgs e)
        {
            m_mthCheckAvailAmount();

            if ( (m_dtbOutStorageDetail != null) && (m_dtbOutStorageDetail.Rows.Count > 0))
            {
                m_dgvSubInfo.Focus();
                m_dgvSubInfo.CurrentCell = m_dgvSubInfo[8, 0];
            }

        }

        private void m_dgvSubInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal decAmount = 0;
            if ((m_dgvSubInfo.Rows.Count > 0) && (m_dgvSubInfo.CurrentCell.ColumnIndex == 0))
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

                }
            }//if

        }

        private void m_dgvSubInfo_DoubleClick(object sender, EventArgs e)
        {
            m_lblSelectAll.Text = "全选";
            ((clsCtl_InMedicineWithdrawOutStorageInfo)objController).m_mthCall();

        }

        private void m_dgvSubInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 8)
            //{
            //    long lngRes = m_mthChkAmount();
            //    if (lngRes < 0)
            //    {
            //        m_dgvSubInfo.CancelEdit();
            //        m_dgvSubInfo.CurrentCell.Value = 0;
            //        m_dgvSubInfo.EndEdit();

            //        m_dgvSubInfo[e.ColumnIndex, e.RowIndex].Value = 0;
            //        MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }

        private void m_dgvSubInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = true;
            if (CurrentCell.ColumnIndex == 8)
            {
                m_dgvSubInfo.EndEdit();
                long lngRes = m_mthChkAmount();
                if (lngRes > 0)
                {
                    ((clsCtl_InMedicineWithdrawOutStorageInfo)objController).m_mthCall();
                    this.Close();
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    m_dgvSubInfo.CancelEdit();
                    m_dgvSubInfo.CurrentCell.Value = 0;
                    m_dgvSubInfo.EndEdit();
                    MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //m_dgvSubInfo.CurrentRow.Cells[0].Value = false;
                    m_dgvSubInfo.CurrentCell = m_dgvSubInfo[8, m_dgvSubInfo.CurrentRow.Index];
                    m_dgvSubInfo.Focus();

                }

            }
            else
            {
                ((clsCtl_InMedicineWithdrawOutStorageInfo)objController).m_mthCall();
                this.Close();
                this.DialogResult = DialogResult.OK;

            }
        }

        private long m_mthChkAmount()
        {
            DataRow m_dtbRow = null;
            decimal m_decAvailAmount = 0;
            decimal m_decNetAvailAmount = 0;
            bool m_blnChkFlag = false;

            if (m_dgvSubInfo.Rows.Count > 0)
            {
                int m_intRowIndex = m_dgvSubInfo.CurrentRow.Index;
                m_dtbRow = m_dtbOutStorageDetail.Rows[m_intRowIndex];
                //m_dgvSubInfo.EndEdit();

                decimal.TryParse(m_dtbRow["AvailAmount"].ToString(), out m_decAvailAmount);
                decimal.TryParse(m_dtbRow["Amount"].ToString(), out m_decNetAvailAmount);
                if (m_decNetAvailAmount > m_decAvailAmount)
                {
                    m_blnDataAvail = false;
                    //MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void m_dgvSubInfo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            m_dgvSubInfo.EndEdit();
            if (e.ColumnIndex == 8)
            {
                long lngRes = m_mthChkAmount();
                if (lngRes < 0)
                {
                    m_dgvSubInfo.CancelEdit();
                    m_dgvSubInfo.CurrentCell.Value = 0;
                    m_dgvSubInfo.EndEdit();
                    e.Cancel = true;
                    m_dgvSubInfo[e.ColumnIndex, e.RowIndex].Value = 0;
                    MessageBox.Show("退药数量不能大于可退数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //m_dgvSubInfo.CurrentCell = m_dgvSubInfo[8, e.RowIndex];
                    m_dgvSubInfo.Focus();
                }
            }

        }


    }
}