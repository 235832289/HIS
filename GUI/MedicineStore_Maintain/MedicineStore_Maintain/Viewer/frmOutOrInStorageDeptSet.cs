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
    /// 自动接收通知单据设置
    /// </summary>
    public partial class frmOutOrInStorageDeptSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 是否是药房使用，1－药房 2－药库
        /// </summary>
        internal bool m_blnIsDrugStore = false;
        private int m_intMsOrDs = 1;

        public void m_mthShow(string p_strMsOrDs)
        {
            m_intMsOrDs = Convert.ToInt32(p_strMsOrDs);
            if (m_intMsOrDs == 1)
            {
                m_blnIsDrugStore = true;
            }
            
            ((clsCtl_OutOrInStorageDeptSet)objController).m_mthGetStorageName();
            
            this.Show();
        }

        public frmOutOrInStorageDeptSet()
        {
            InitializeComponent();
            this.m_dgvOutOrInStorageDept.AutoGenerateColumns = false;
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_OutOrInStorageDeptSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmOutOrInStorageDeptSet_Load(object sender, EventArgs e)
        {
            ((clsCtl_OutOrInStorageDeptSet)objController).m_mthGetOutOrInStoreDept();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (this.m_cboStorageName.Text.Trim() == "")
                return;
            ((clsCtl_OutOrInStorageDeptSet)objController).m_mthSaveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_cboStorageName_SelectedIndexChanged(null, null);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_lblSelected_Click(object sender, EventArgs e)
        {
            if (this.m_dgvOutOrInStorageDept.Rows.Count > 0)
            {
                //this.m_dgvOutOrInStorageDept.CurrentCell = this.m_dgvOutOrInStorageDept.Rows[0].Cells["m_dgvtxtNo"];
                if (this.m_lblSelected.Text == "全选")
                {
                    this.m_lblSelected.Text = "反选";
                    for (int iOr = 0; iOr < this.m_dgvOutOrInStorageDept.Rows.Count; iOr++)
                    {
                        this.m_dgvOutOrInStorageDept.Rows[iOr].Cells[0].Value = "T";
                    }
                }
                else if (this.m_lblSelected.Text == "反选")
                {
                    this.m_lblSelected.Text = "全选";
                    for (int jOr = 0; jOr < m_dgvOutOrInStorageDept.Rows.Count; jOr++)
                    {
                        m_dgvOutOrInStorageDept.Rows[jOr].Cells[0].Value = "F";
                    }
                }
            }
        }

        private void m_cboStorageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_OutOrInStorageDeptSet)objController).m_mthSearchInfo();
        }

        private void m_lblSelected_MouseEnter(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = Color.Maroon;
            this.Cursor = Cursors.Hand;
        }

        private void m_lblSelected_MouseLeave(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = SystemColors.MenuHighlight;
            this.Cursor = Cursors.Default;
        }

        private void m_txtQuery_TextChanged(object sender, EventArgs e)
        {
            DataGridViewCell dgvcSelect = ((clsCtl_OutOrInStorageDeptSet)objController).m_dgvcSelect(m_dgvOutOrInStorageDept, m_txtQuery.Text);
            if (dgvcSelect != null)
            {
                m_dgvOutOrInStorageDept.CurrentCell = m_dgvOutOrInStorageDept.Rows[dgvcSelect.RowIndex].Cells[3];
                m_dgvOutOrInStorageDept.Rows[dgvcSelect.RowIndex].Selected = true;
            }
            else
            {
                m_dgvOutOrInStorageDept.Rows[m_dgvOutOrInStorageDept.CurrentCell.RowIndex].Selected = false;
            }
        }
    }
}