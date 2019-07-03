using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 盘点药品顺序设置
    /// </summary>
    public partial class frmCheckMedicineOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品顺序设置数据源        /// </summary>
        internal DataTable m_dtbMedicineSource = null;
        /// <summary>
        /// 当前DataGridView数据源        /// </summary>
        internal DataView m_dtvCurrentView = null;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicineDict = null;
        /// <summary>
        /// 盘点药品顺序设置
        /// </summary>
        public frmCheckMedicineOrder()
        {
            InitializeComponent();
            m_dgvMedicineOrder.AutoGenerateColumns = false;

            ((clsCtl_CheckMedicineOrder)objController).m_mthInitMedicineTable(ref m_dtbMedicineSource);
            m_dtvCurrentView = new DataView(m_dtbMedicineSource);
            m_dgvMedicineOrder.DataSource = m_dtvCurrentView;
        }
        


        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            ((clsCtl_CheckMedicineOrder)objController).m_mthGetStorageName();
            ((clsCtl_CheckMedicineOrder)objController).m_mthCheckHasStoragePack();
            m_bgwGetMedicineDict.RunWorkerAsync();

            this.Show();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_CheckMedicineOrder();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_txtStoragePack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_CheckMedicineOrder)objController).m_mthShowStoragePack(m_txtStoragePack.Text);
            }            
        }

        private void m_dgvMedicineOrder_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }

            if (CurrentCell.ColumnIndex == 2)
            {
                string strFilter = string.Empty;
               // CurrentCell.EditedFormattedValue
                if (CurrentCell.EditedFormattedValue != null)
                {
                    strFilter = CurrentCell.EditedFormattedValue.ToString();
                }
                ((clsCtl_CheckMedicineOrder)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineDict);
                CancelJump = true;
            }
        }

        private void m_cmdAddNew_Click(object sender, EventArgs e)
        {
            if (m_txtStoragePack.Visible && m_txtStoragePack.Tag == null)//药库存在货架时检查
            {
                MessageBox.Show("请先选择货架","盘点药品顺序设置",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            ((clsCtl_CheckMedicineOrder)objController).m_mthInsertNewMedicineData();
        }

        #region 无货架时后台获取药品顺序数据
        private void m_bgwGetStorageData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_CheckMedicineOrder)objController).m_mthGetCheckMedicineOrderWithoutPack();
        }

        private void m_bgwGetStorageData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvCurrentView = new DataView(m_dtbMedicineSource);
            m_dgvMedicineOrder.DataSource = m_dtvCurrentView;
        } 
        #endregion

        private void frmCheckMedicineOrder_Load(object sender, EventArgs e)
        {
            if (!m_txtStoragePack.Visible)
            {
                ((clsCtl_CheckMedicineOrder)objController).m_mthGetCheckMedicineOrderWithoutPack();
                // m_bgwGetStorageData.RunWorkerAsync();
            }
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            DataTable dtbNew = m_dtbMedicineSource.GetChanges(DataRowState.Added);
            DataTable dtbEdit = m_dtbMedicineSource.GetChanges(DataRowState.Modified);
            if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
            {
                DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定退出?", "盘点药品顺序设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
            
        }

        private void m_bgwGetMedicineDict_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_CheckMedicineOrder)objController).m_mthInitMedicineInfo(ref m_dtbMedicineDict);
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_CheckMedicineOrder)objController).m_lngSaveMedicinOrder();

            if (lngRes > 0)
            {
                MessageBox.Show("保存成功", "药品盘点顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_dtbMedicineSource.AcceptChanges();

                m_dtvCurrentView = new DataView(m_dtbMedicineSource);
                m_dtvCurrentView.Sort = "checkmedicineorder_chr";
                m_dgvMedicineOrder.DataSource = m_dtvCurrentView;
            }
        }

        private void m_lblCheckAll_Click(object sender, EventArgs e)
        {
            if (m_dgvMedicineOrder.Rows.Count > 0)
            {
                if (m_lblCheckAll.Text == "全选")
                {
                    m_lblCheckAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMedicineOrder.Rows.Count; iRow++)
                    {
                        m_dgvMedicineOrder.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblCheckAll.Text == "反选")
                {
                    m_lblCheckAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMedicineOrder.Rows.Count; iRow++)
                    {
                        m_dgvMedicineOrder.Rows[iRow].Cells[0].Value = false;
                    }
                }
            } 
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            
            DialogResult drResult = MessageBox.Show("是否删除已选择的记录？", "盘点药品顺序设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (drResult == DialogResult.Yes)
             {
                 ((clsCtl_CheckMedicineOrder)objController).m_mthDeleteMedicinOrder();
             }
        }

        private void m_cmdUpToFirst_Click(object sender, EventArgs e)
        {
            ((clsCtl_CheckMedicineOrder)objController).m_mthUpToSpecifyRow(0);
        }

        private void m_cmdUp_Click(object sender, EventArgs e)
        {
            ((clsCtl_CheckMedicineOrder)objController).m_mthSelectRowUp();
        }

        private void m_cmdDown_Click(object sender, EventArgs e)
        {
            ((clsCtl_CheckMedicineOrder)objController).m_mthSelectRowDown();
        }

        private void m_cmdDownToLast_Click(object sender, EventArgs e)
        {
            int intRowsCount = m_dgvMedicineOrder.Rows.Count;
            ((clsCtl_CheckMedicineOrder)objController).m_mthDownToSpecifyRow(intRowsCount - 1);
        }

        private void m_cmdJumpToSpecRow_Click(object sender, EventArgs e)
        {
            ((clsCtl_CheckMedicineOrder)objController).m_mthJumpToSpecifyRow();
        }

        private void m_txtJumpToRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_CheckMedicineOrder)objController).m_mthJumpToSpecifyRow();
            }            
        }

        private void m_cmdBatchInput_Click(object sender, EventArgs e)
        {
            if (m_txtStoragePack.Visible && m_txtStoragePack.Tag == null)//药库存在货架时检查
            {
                MessageBox.Show("请先选择货架", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ((clsCtl_CheckMedicineOrder)objController).m_mthCheckMedicine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!m_txtStoragePack.Visible)
            {
                ((clsCtl_CheckMedicineOrder)objController).m_mthGetCheckMedicineOrderWithoutPack();
            }
            else
            {
                ((clsCtl_CheckMedicineOrder)objController).m_mthGetCheckMedicineOrder();
            }

        }




    }
}