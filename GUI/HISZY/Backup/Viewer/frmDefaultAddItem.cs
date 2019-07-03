using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 门诊默认带出收费项目维护窗口
    /// </summary>
    public partial class frmDefaultAddItem : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmDefaultAddItem()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 当前行号
        /// </summary>
        internal int CurrRow = -1;
        /// <summary>
        /// 当前选中身份(费别)
        /// </summary>
        internal string PayTypeID = "";
        /// <summary>
        /// 当前项目行号
        /// </summary>
        internal int CurrItemRow = -1;
        #endregion
        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_DefaultAddItem();
            objController.Set_GUI_Apperance(this);
        }

        private void frmDefaultAddItem_Load(object sender, EventArgs e)
        {
            ((clsCtl_DefaultAddItem)this.objController).m_mthInit();
            this.dtgPayType_CellClick(0);
        }       

        private void btnNew_Click(object sender, EventArgs e)
        {          
            ((clsCtl_DefaultAddItem)this.objController).m_mthNew();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ((clsCtl_DefaultAddItem)this.objController).m_mthAddItem();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dtgItem.Rows.Count == 0)
            {
                return;
            }

            bool b = false;
            for (int i = this.dtgItem.Rows.Count - 1; i >= 0; i--)
            {
                if (this.dtgItem.Rows[i].Selected)
                {
                    this.dtgItem.Rows.RemoveAt(i);
                    b = true;
                    break;
                }
            }

            if (b)
            {
                MessageBox.Show("删除后请按【保存】按钮，将删除信息实际提交到数据库。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_DefaultAddItem)this.objController).m_blnSave();
        }       

        private void dtgPayType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgPayType_CellClick(e.RowIndex);
        }

        private void dtgPayType_CellClick(int RowIndex)
        {
            if (RowIndex < 0)
            {
                return;
            }

            CurrRow = RowIndex;
            this.PayTypeID = "";

            string PayTypeName = this.dtgPayType.Rows[CurrRow].Cells["sfmc"].Value.ToString().Trim();
            this.lblPayTypeName.Text = PayTypeName;

            if (this.dtgPayType.Rows[CurrRow].Cells["zt"].Value.ToString().Trim() == "停用")
            {
                ((clsCtl_DefaultAddItem)this.objController).m_mthClear();
                this.btnSave.Tag = "";
                this.dtgItem.Rows.Clear();
                return;
            }

            this.PayTypeID = this.dtgPayType.Rows[CurrRow].Cells["fyid"].Value.ToString().Trim();
            ((clsCtl_DefaultAddItem)this.objController).m_mthGetHistoryItem();
        }

        private void dtgPayType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_DefaultAddItem)this.objController).m_mthFindChargeItem(this.txtItemName.Text.Trim());
            }
        }

        private void lsvItem_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_DefaultAddItem)this.objController).m_mthSelectItem();
        }

        private void lsvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_DefaultAddItem)this.objController).m_mthSelectItem();
            }
        }

        private void lsvItem_Leave(object sender, EventArgs e)
        {
            this.panelItem.Height = 0;
        }

        private void mskAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboRegStatus.Focus();
            }
        }

        private void cboRegStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboRecipeType.Focus();
            }
        }

        private void cboRecipeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboDuty.Focus();
            }
        }

        private void cboDuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.mskBeginTime.Focus();
            }
        }

        private void mskBeginTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.mskEndTime.Focus();
            }
        }

        private void mskEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDept.Focus();
            }
        }

        private void dtgItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgItem.Rows.Count == 0)
            {
                return;
            }
                       
        }       

        private void dtgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ((clsCtl_DefaultAddItem)this.objController).m_mthModify(e.RowIndex);
            }
        }

        private void frmDefaultAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.panelItem.Height > 0)
                {
                    this.panelItem.Height = 0;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_DefaultAddItem)this.objController).m_mthSearchDept(txtDept.Text.Trim());
                this.dgvDept.Visible = true;
                this.dgvDept.BringToFront();
                this.dgvDept.Focus();
            }
        }

        private void dgvDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDept.Tag = dgvDept.SelectedRows[0].Cells["colID"].Value.ToString();
                this.txtDept.Text = dgvDept.SelectedRows[0].Cells["colDeptName"].Value.ToString();
                dgvDept.Visible = false;
                this.btnAdd.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                dgvDept.Visible = false;
            }
        }

        private void dgvDept_Leave(object sender, EventArgs e)
        {
            dgvDept.Visible = false;
        }       
    }
}