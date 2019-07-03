using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmLimitTimeMaitain : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmLimitTimeMaitain()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsCtl_LimitTimeMaitain m_objController;
        public string DeptIdArr = string.Empty;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.clsCtl_LimitTimeMaitain();
            this.m_objController.Set_GUI_Apperance(this);
        }

        #endregion

        private void frmLimitTimeMaitain_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInit();
        }

        private void txtNormal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void txtEmergency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void txtLimitTime_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void txtLimitTime_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void txtLimitTime_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_objController.m_mthSaveLimitTime();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            m_objController.m_mthDeletLimitTime();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            m_objController.m_mthGetCheckItemByName();
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_objController.m_mthListCheckItem();
        }

        private void dgvItem_Click(object sender, EventArgs e)
        {
            m_objController.m_mthGetLimitTime();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            m_objController.clear();
        }

        private void btnCpy_Click(object sender, EventArgs e)
        {
            string applyunitid = string.Empty;
            if (this.dgvItem.Rows.Count > 0)
            {
                applyunitid = this.dgvItem.CurrentRow.Cells["项目编码"].Value.ToString();
            }

            if (!string.IsNullOrEmpty(applyunitid))
            {
                frmLimitTimeCpy frm = new frmLimitTimeCpy(applyunitid);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一个项目 ！");
            }
        }

    }
}
