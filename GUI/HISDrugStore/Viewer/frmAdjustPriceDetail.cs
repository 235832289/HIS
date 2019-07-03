using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    ///  药房药品调价界面
    /// </summary>
    public partial class frmAdjustPriceDetail  : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmAdjustPriceDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置窗体控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_AdjustmentDetail();
            objController.Set_GUI_Apperance(this);
        }
        #region 全局变量
        /// <summary>
        /// 药房ID
        /// </summary>
        internal string m_strDrugStoreid = string.Empty;
        /// <summary>
        /// 药品调价明细
        /// </summary>
        internal DataTable m_dtbAdjustPrice = null;
        /// <summary>
        /// 同一药品是否分批号调价
        /// </summary>
        internal bool m_blnIsDiffLotNO = false;
        /// <summary>
        /// 药库调价是否同时调整药房价格
        /// </summary>
        internal bool m_blnIsAdjustDrugstore = false;
        /// <summary>
        /// 药品基本字典
        /// </summary>
        internal DataTable m_dtMedicine = null;
        /// <summary>
        /// 保存是否立即审核(0-保存 1-保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;
        #endregion
        #region 构造函数
        /// <summary>
        /// 药品调价
        /// </summary>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_dtbMedicineDict">药品基本字典</param>
        public frmAdjustPriceDetail(string p_strStorageID, DataTable p_dtbMedicineDict)
        {
            InitializeComponent();

            m_dgvAdjustPrice.AutoGenerateColumns = false;
            m_strDrugStoreid = p_strStorageID;
            m_dtMedicine = p_dtbMedicineDict;
            m_txtMan.Text = LoginInfo.m_strEmpName;
            m_txtMan.Tag = LoginInfo.m_strEmpID;

            ((clsCtl_AdjustmentDetail)objController).m_mthInitDataTable();
            ((clsCtl_AdjustmentDetail)objController).m_mthGetCommitFlow(out m_intCommitFolow);
            ((clsCtl_AdjustmentDetail)objController).m_mthGetAdjustPriceSetting();
            if (!m_blnIsDiffLotNO)
            {
                m_dgvtxtProduceNumber.Visible = false;
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
        public frmAdjustPriceDetail(string p_strStorageID, DataTable p_dtbMedicineDict, clsDS_Adjustment_VO p_objMain, clsDS_Adjustment_Detail[] p_objSubArr)
            : this(p_strStorageID, p_dtbMedicineDict)
        {
            ((clsCtl_AdjustmentDetail)objController).m_mthSetDataToUI(p_objMain, p_objSubArr);
        }
        #endregion
        private void frmAdjustPriceDetail_Load(object sender, EventArgs e)
        {
            this.m_datMakeDate.Focus();
            if (m_dgvAdjustPrice.Rows.Count == 0)
            {
                ((clsCtl_AdjustmentDetail)objController).m_mthInsertNewMedicineData();
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_AdjustmentDetail)objController).m_mthPrint();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            if (m_dtbAdjustPrice != null)
            {
                DataRow[] drUnSave = m_dtbAdjustPrice.Select("seriesid_int is null and medicineid_chr is not null");
                if (drUnSave != null && drUnSave.Length > 0)
                {
                    DialogResult drResult = MessageBox.Show("存在未保存记录，是否保存？", "门诊药房药品调价", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (drResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (drResult == DialogResult.Yes)
                    {
                        long lngRes = ((clsCtl_AdjustmentDetail)objController).m_lngSaveMedicine();
                        if (lngRes > 0)
                        {
                            MessageBox.Show("保存成功", "门诊药房药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (lngRes <= 0)
                        {
                            MessageBox.Show("保存失败", "门诊药房药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            this.Close();
        }

        private void m_btnNext_Click(object sender, EventArgs e)
        {
            if (m_dtbAdjustPrice != null)
            {
                DataRow[] drUnSave = m_dtbAdjustPrice.Select("seriesid_int is null and medicineid_chr is not null");
                if (drUnSave != null && drUnSave.Length > 0)
                {
                    DialogResult drResult = MessageBox.Show("存在未保存记录，是否忽略并写下一张单？", "门诊药房药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            ((clsCtl_AdjustmentDetail)objController).m_mthClear();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (m_dgvAdjustPrice.CurrentCell != null)
            {
                DataRow drCurrent = ((DataRowView)m_dgvAdjustPrice.Rows[m_dgvAdjustPrice.CurrentCell.RowIndex].DataBoundItem).Row;
                if (drCurrent != null && drCurrent["medicineid_chr"] != DBNull.Value)
                {
                    DialogResult drResult = MessageBox.Show("确定删除选定记录？", "门诊药房药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_AdjustmentDetail)objController).m_lngSaveMedicine();
            if (lngRes > 0)
            {
                MessageBox.Show("保存成功", "门诊药房药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lngRes < 0)
            {
                MessageBox.Show("保存失败", "门诊药房药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_AdjustmentDetail)objController).m_mthInsertNewMedicineData();
        }

        private void m_txtMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AdjustmentDetail)objController).m_mthSetEmpToList(m_txtMan.Text, m_txtMan);
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

        private void m_txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AdjustmentDetail)objController).m_mthJumpToNewRow();
            }
        }

        private void m_dgvAdjustPrice_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvAdjustPrice.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                ((clsCtl_AdjustmentDetail)objController).m_mthShowQueryMedicineForm(strFilter, m_dtMedicine);
                //m_dgvAdjustPrice.Focus();
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 9)
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

        private void m_dgvAdjustPrice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
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
                            MessageBox.Show("药品单价不能小于零", "门诊药房药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            m_dgvAdjustPrice.Focus();
                        }
                        else
                        {
                            if (!m_blnIsDiffLotNO)
                            {
                                ((clsCtl_AdjustmentDetail)objController).m_mthSetSameLotNOPrice(drCurrent);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("药品单价不能为空且只能为数字", "门诊药房药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}