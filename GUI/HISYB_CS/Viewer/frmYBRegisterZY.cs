using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBRegisterZY : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBRegisterZY()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBRegisterZY();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 是否护士修改
        /// </summary>
        public bool IsNurseModify { get; set; }

        /// <summary>
        /// registerid
        /// </summary>
        public string strRegisterId = string.Empty;
        /// <summary>
        /// 社保标志
        /// </summary>
        public string strSBBZ = string.Empty;

        private void frmZYYBRegister_Load(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).m_mthInit();
            if (this.IsNurseModify)
            {
                this.btnKsydkjq.Visible = false;
                this.btnYBReg.Visible = false;
                this.btnYBCancelReg.Visible = false;
                this.btnClose.Visible = false;
                this.ControlBox = false;
                this.timer.Enabled = true;
            }
        }

        private void btnYBReg_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).m_mthYbReg();
        }

        private void btnYBCancelReg_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此操作无法返回，请确认是否撤销入院？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cboCYBZ.SelectedIndex = 2;
                ((clsCtl_YBRegisterZY)this.objController).m_mthYbReg();
            }
        }

        private void btnYBModifyReg_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).m_mthYbReg();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cboZYLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZYLB.SelectedIndex == 1)
            {
                this.cboZQQRQK.SelectedIndex = 0;
                this.cboZQQRQK.Enabled = false;
                this.cobRYDYZDBY.SelectedIndex = 0;
            }
            else
            {
                this.cboZQQRQK.Enabled = true;
                this.cobRYDYZDBY.SelectedIndex = 1;
            }
        }

        public void txtDept_Leave(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).m_mthFilterBed();
            ((clsCtl_YBRegisterZY)this.objController).m_mthFilterDoc();
        }

        #region 诊断

        private void lsvItemICD_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).SelectICD();
        }

        private void lsvItemICD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBRegisterZY)this.objController).SelectICD();
            }
        }

        private void lsvItemICD_Leave(object sender, EventArgs e)
        {
            this.lsvItemICD.Height = 0;
        }

        private void txtMainDiag_Enter(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).CurrDiagTxtIndex = 1;
        }

        private void txtSecDiag1_Enter(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).CurrDiagTxtIndex = 2;
        }

        private void txtSecDiag2_Enter(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).CurrDiagTxtIndex = 3;
        }

        private void txtMainDiag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBRegisterZY)this.objController).FindICD(this.txtMainDiag.Text.Trim());
            }
        }

        private void txtSecDiag1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBRegisterZY)this.objController).FindICD(this.txtSecDiag1.Text.Trim());
            }
        }

        private void txtSecDiag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBRegisterZY)this.objController).FindICD(this.txtSecDiag2.Text.Trim());
            }
        }
        private void txtMainDiag_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).FindICD(this.txtMainDiag.Text.Trim());
        }

        private void txtSecDiag1_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).FindICD(this.txtSecDiag1.Text.Trim());
        }

        private void txtSecDiag2_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).FindICD(this.txtSecDiag2.Text.Trim());
        }

        #endregion

        /// <summary>
        /// 跨省异地卡鉴权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKsydkjq_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBRegisterZY)this.objController).Ksydkjq();
        }

        private void btnCbd_Click(object sender, EventArgs e)
        {
            frmAdministrative frm = new frmAdministrative();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.txtCbdtcqbm.Text = frm.Fcode;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            ((clsCtl_YBRegisterZY)this.objController).m_mthYbReg();
        }

    }
}