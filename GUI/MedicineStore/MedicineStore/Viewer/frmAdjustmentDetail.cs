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
    /// 药品调价
    /// </summary>
    public partial class frmAdjustmentDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品调价明细
        /// </summary>
        internal DataTable m_dtbAdjustPrice = null;
        /// <summary>
        /// 同一药品是否分批号调价
        /// </summary>
        internal bool m_blnIsDiffLotNO = false;
        /// <summary>
        /// 调价的方式
        /// </summary>
        internal int m_intDiffLotNo = 0;
        /// <summary>
        /// 药库调价是否同时调整药房价格
        /// </summary>
        internal bool m_blnIsAdjustDrugstore = false;
        /// <summary>
        /// 药品基本字典
        /// </summary>
        internal DataTable m_dtbMedicineDict = null;
        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// yunjie.xie 调价是保存后即审核的 20090720
        /// </summary>
        internal int m_intCommitFolow = 1;
        /// <summary>
        /// 其它业务表单
        /// </summary>
        internal int m_intOtherBillCommitFlag = 1;
        /// <summary>
        /// 药库调价是否同时调整批发价
        /// </summary>
        internal bool m_blnShowWholeSalePrice = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品调价
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicineDict">药品基本字典</param>
        public frmAdjustmentDetail(string p_strStorageID, DataTable p_dtbMedicineDict)
        {
            InitializeComponent();

            m_dgvAdjustPrice.AutoGenerateColumns = false;
            m_dtpDate.Text = clsMedicineStoreFormFactory.CurrentDateTimeNow.ToString("yyyy年MM月dd日");

            m_strStorageID = p_strStorageID;
            m_dtbMedicineDict = p_dtbMedicineDict;
            m_txtMan.Text = LoginInfo.m_strEmpName;
            m_txtMan.Tag = LoginInfo.m_strEmpID;

            ((clsCtl_AdjustmentDetail)objController).m_mthInitDataTable();
            //((clsCtl_AdjustmentDetail)objController).m_mthGetCommitFlow(out m_intCommitFolow);yunjie.xie 调价是保存后即审核的
            ((clsCtl_AdjustmentDetail)objController).m_mthGetCommitFlow(out this.m_intOtherBillCommitFlag);
            ((clsCtl_AdjustmentDetail)objController).m_mthGetAdjustPriceSetting();
            if (this.m_intDiffLotNo == 1)
            {
                m_dgvtxtProduceNumber.Visible = false;
            }

            if (m_blnIsAdjustDrugstore)
            {
                this.m_dgvtxtBalance.Visible = false;
                this.m_dgvtxtGross.Visible = false;
                this.m_dgvtxtNewMoney.Visible = false;
                this.m_dgvtxtOldMoney.Visible = false;
                this.label1.Visible = false;
                this.label13.Visible = false;
                this.label9.Visible = false;
                this.m_lblBeforeMoney.Visible = false;
                this.m_lblAfterMoney.Visible = false;
                this.m_lblSubMoney.Visible = false;
                this.panel3.Height = 0;
            }

            if (!m_blnShowWholeSalePrice)
            {
                m_dgvAdjustPrice.Columns[11].Visible = false;
                m_dgvAdjustPrice.Columns[12].Visible = false;
                m_dgvAdjustPrice.Columns[9].Width += m_dgvAdjustPrice.Columns[9].Width;
                m_dgvAdjustPrice.Columns[10].Width += m_dgvAdjustPrice.Columns[10].Width;
            }
            m_dgvAdjustPrice.DataSource = m_dtbAdjustPrice;
        }

        /// <summary>
        /// 药品调价
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicineDict">药品基本字典</param>
        /// <param name="p_objMain">调价主记录</param>
        /// <param name="p_objSubArr">调价明细记录</param>
        public frmAdjustmentDetail(string p_strStorageID, DataTable p_dtbMedicineDict, clsMS_Adjustment_VO p_objMain, clsMS_Adjustment_Detail[] p_objSubArr)
            : this(p_strStorageID, p_dtbMedicineDict)
        {
            ((clsCtl_AdjustmentDetail)objController).m_mthSetDataToUI(p_objMain, p_objSubArr);
        }
        #endregion

        public override void CreateController()
        {
            this.objController = new clsCtl_AdjustmentDetail();
            objController.Set_GUI_Apperance(this);
        }

        #region 事件
        private void frmAdjustmentDetail_Load(object sender, EventArgs e)
        {
            //m_dtpDate.Focus();
            //m_dtpDate.Select(); 
            if (m_dgvAdjustPrice.Rows.Count == 0)
            {
                ((clsCtl_AdjustmentDetail)objController).m_mthInsertNewMedicineData();
            }
            int intPrintType = 0;
            clsDcl_AdjustmentDetail m_objDomain = new clsDcl_AdjustmentDetail();
            m_objDomain.m_lngGetPrintType(out intPrintType);
            m_objDomain = null;
            if(intPrintType==2)
            {
                this.m_cmdPrint.Enabled = false;
            }
            else
            {
                this.m_cmdPrint.Enabled = true;
            }
            //this.m_txtRemark.Focus();
            //this.m_txtRemark.SelectAll();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_AdjustmentDetail)objController).m_mthPrint();
            
            //frmAdjustmentDetailReport
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            if (m_dtbAdjustPrice != null)
            { 
                DataRow[] drUnSave = m_dtbAdjustPrice.Select("seriesid_int is null and medicineid_chr is not null");
                if (drUnSave != null && drUnSave.Length > 0)
                {
                    if (MessageBox.Show("存在未保存记录，是否退出？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            this.Close();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_AdjustmentDetail)objController).m_lngSaveMedicine();
            if (lngRes > 0)
            {
                MessageBox.Show("保存成功","药品调价",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (this.m_intCommitFolow == 1)
                {
                    this.m_cmdSave.Enabled = false;
                    this.m_cmdInsertRecord.Enabled = false;
                    this.m_cmdDelete.Enabled = false;
                }
            }
            else if (lngRes < 0)
            {
                MessageBox.Show("保存失败", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_cmdInsertRecord_Click(object sender, EventArgs e)
        {
            ((clsCtl_AdjustmentDetail)objController).m_mthInsertNewMedicineData();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (m_dgvAdjustPrice.CurrentCell != null)
            {
                DataRow drCurrent = ((DataRowView)m_dgvAdjustPrice.Rows[m_dgvAdjustPrice.CurrentCell.RowIndex].DataBoundItem).Row;
                if (drCurrent != null && drCurrent["medicineid_chr"] != DBNull.Value)
                {
                    DialogResult drResult = MessageBox.Show("确定删除选定记录？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }

                ((clsCtl_AdjustmentDetail)objController).m_mthDeleteDetail();
            }
            else
            {
                return;
            }
        }

        private void m_cmdNext_Click(object sender, EventArgs e)
        {
            if (m_dtbAdjustPrice != null)
            {
                DataRow[] drUnSave = m_dtbAdjustPrice.Select("seriesid_int is null and medicineid_chr is not null");
                if (drUnSave != null && drUnSave.Length > 0)
                {
                    DialogResult drResult = MessageBox.Show("存在未保存记录，是否忽略并写下一张单？","药品调价",MessageBoxButtons.YesNo ,MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            ((clsCtl_AdjustmentDetail)objController).m_mthClear();
            ((clsCtl_AdjustmentDetail)objController).m_mthInsertNewMedicineData();
            if (this.m_intCommitFolow == 1)
            {
                this.m_cmdSave.Enabled = true;
                this.m_cmdInsertRecord.Enabled = true;
                this.m_cmdDelete.Enabled = true;
            }
        }

        private void m_txtMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AdjustmentDetail)objController).m_mthSetEmpToList(m_txtMan.Text,m_txtMan);
            }
        }

        private void m_dgvAdjustPrice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvAdjustPrice.Rows.Count; iRow++)
            {
                m_dgvAdjustPrice.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_AdjustmentDetail)objController).m_mthGetAllMoney();
        }

        private void m_dgvAdjustPrice_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvAdjustPrice.Rows.Count; iRow++)
            {
                m_dgvAdjustPrice.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_AdjustmentDetail)objController).m_mthGetAllMoney();
        }

        private void m_dgvAdjustPrice_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvAdjustPrice.EndEdit();

            if (CurrentCell.ColumnIndex == 1)//药品代码列
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                if (m_dtbMedicineDict == null || m_dtbMedicineDict.Rows.Count == 0)
                {
                    ((clsCtl_AdjustmentDetail)objController).m_mthGetMedicineInfo();
                }
                ((clsCtl_AdjustmentDetail)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineDict);
                //m_dgvAdjustPrice.Focus();
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 6)//上次购入单价列
            {
                double m_dblInputCallInprice = 0d;
                if (double.TryParse(CurrentCell.Value.ToString(), out m_dblInputCallInprice))
                {
                    if (Convert.ToString(this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells["m_dgvtxtgrossprofitrate"].Value).Length != 0)
                    {
                        //this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[10].Value = clsCtl_Public.m_mthMathPayment(m_strStorageID, m_dblInputCallInprice, dblRate);
                        double dblRate = Convert.ToDouble(this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells["m_dgvtxtgrossprofitrate"].Value);
                        this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells["m_dgvtxtNewPrice"].Value = clsCtl_Public.m_mthMathPayment(m_strStorageID, m_dblInputCallInprice, dblRate);
                    }
                    else
                    {
                        this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[10].Value = 0;
                    }
                
                    this.m_dgvAdjustPrice.CurrentCell = this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[10];

                     CancelJump = true;
                }
                else
                {
                    CancelJump = true;
                    return;
                }
            }
            else if (CurrentCell.ColumnIndex == 10)//调后零售单价列
            {
                if (CurrentCell.Value != null)
                {
                    if (CurrentCell.Value.ToString() == this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[9].Value.ToString())
                    {
                        MessageBox.Show("请注意，调后零售单价与调前零售单价相同！", "提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        CancelJump = true;
                        this.m_dgvAdjustPrice.Focus();
                        return;
                    }
                }
                if (m_blnShowWholeSalePrice)
                    this.m_dgvAdjustPrice.CurrentCell = this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[12];
                else
                    this.m_dgvAdjustPrice.CurrentCell = this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[13];
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 12)
            { 
                if (this.m_dgvAdjustPrice.Rows.Count > 1 && this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[13].Value.ToString() == string.Empty)
                {
                    this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex].Cells[13].Value = this.m_dgvAdjustPrice.Rows[CurrentCell.RowIndex - 1].Cells[13].Value;
                }

            }
            else if (CurrentCell.ColumnIndex == 13)
            {
                CancelJump = true;
                if (CurrentCell.RowIndex == m_dgvAdjustPrice.Rows.Count - 1)
                {
                    ((clsCtl_AdjustmentDetail)objController).m_mthInsertNewMedicineData();
                }
                else
                {
                    ((clsCtl_AdjustmentDetail)objController).m_mthJumpToNewRow();
                }
            }
        }

        private void m_txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AdjustmentDetail)objController).m_mthJumpToNewRow();
            }
        }

        private void m_dgvAdjustPrice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strEx = e.Exception.Message;
        }

        private void m_dgvAdjustPrice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dgvAdjustPrice.CurrentCell != null && e.ColumnIndex == 8)
            {
                try
                {
                    double dblTemp = 0d;
                    double dblOldPrice = Convert.ToDouble(m_dgvAdjustPrice.Rows[e.RowIndex].Cells[7].Value);
                    DataRow drCurrent = ((DataRowView)m_dgvAdjustPrice.Rows[e.RowIndex].DataBoundItem).Row;
                    if (double.TryParse(m_dgvAdjustPrice.CurrentCell.Value.ToString(), out dblTemp))
                    {
                        if (dblTemp < 0)
                        {
                            MessageBox.Show("药品零售单价不能小于零", "药库调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            m_dgvAdjustPrice.Focus();
                        }
                        else
                        {
                            if (this.m_intDiffLotNo == 1)
                            {
                                ((clsCtl_AdjustmentDetail)objController).m_mthSetSameLotNOPrice(drCurrent);
                            }                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("药品零售单价不能为空且只能为数字", "药库调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_dgvAdjustPrice.Focus();
                    }
                    drCurrent.EndEdit();
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
            }
            else if (m_dgvAdjustPrice.CurrentCell != null && e.ColumnIndex == 6)
            {
                double m_dblInputCallInprice = 0d;
                if (double.TryParse(this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out m_dblInputCallInprice))
                {
                    switch (m_strStorageID)
                    {
                        case "0001":
                            if (m_dblInputCallInprice <= 10)
                            {
                                this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtNewPrice"].Value = m_dblInputCallInprice * 1.25;
                            }
                            else if (m_dblInputCallInprice > 10 && m_dblInputCallInprice <= 40)
                            {
                                this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtNewPrice"].Value = m_dblInputCallInprice * 1.15 + 1;
                            }
                            else if (m_dblInputCallInprice > 40 && m_dblInputCallInprice <= 200)
                            {
                                this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtNewPrice"].Value = m_dblInputCallInprice * 1.1 + 3;
                            }
                            else if (m_dblInputCallInprice > 200 && m_dblInputCallInprice <= 600)
                            {
                                this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtNewPrice"].Value = m_dblInputCallInprice * 1.08 + 5;
                            }
                            else if (m_dblInputCallInprice > 600 && m_dblInputCallInprice <= 2000)
                            {
                                this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtNewPrice"].Value = m_dblInputCallInprice * 1.06 + 15;
                            }
                            else
                            {
                                this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtNewPrice"].Value = m_dblInputCallInprice + 135;
                            }
                            break;
                        default:
                            this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells[10].Value = (Convert.ToDouble(this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells["m_dgvtxtgrossprofitrate"].Value) / 100 + 1) * m_dblInputCallInprice;
                            break;
                    }
                    if (m_blnShowWholeSalePrice)
                        this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells[12].Value = m_dblInputCallInprice;

                    this.m_dgvAdjustPrice.CurrentCell = this.m_dgvAdjustPrice.Rows[e.RowIndex].Cells[10];
                }
            }
            else if (m_dgvAdjustPrice.CurrentCell != null && e.ColumnIndex == 12)
            {
                try
                {
                    double dblTemp = 0d;
                    double dblOldPrice = Convert.ToDouble(m_dgvAdjustPrice.Rows[e.RowIndex].Cells[11].Value);
                    DataRow drCurrent = ((DataRowView)m_dgvAdjustPrice.Rows[e.RowIndex].DataBoundItem).Row;
                    if (double.TryParse(m_dgvAdjustPrice.CurrentCell.Value.ToString(), out dblTemp))
                    {
                        if (dblTemp < 0)
                        {
                            MessageBox.Show("药品批发单价不能小于零", "药库调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            m_dgvAdjustPrice.Focus();
                        }
                        else
                        {
                            if (this.m_intDiffLotNo == 1)
                            {
                                ((clsCtl_AdjustmentDetail)objController).m_mthSetSameLotNOPrice(drCurrent);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("药品批发单价不能为空且只能为数字", "药库调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_dgvAdjustPrice.Focus();
                    }
                    drCurrent.EndEdit();
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
            }
        }
        #endregion

        private void m_dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void frmAdjustmentDetail_Shown(object sender, EventArgs e)
        {
            m_dgvAdjustPrice.Focus();
            if (m_dgvAdjustPrice.Rows.Count > 0)
                m_dgvAdjustPrice.CurrentCell = m_dgvAdjustPrice[1, 0];
        }
    }
}　
