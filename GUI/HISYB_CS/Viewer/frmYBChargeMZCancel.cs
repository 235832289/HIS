using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBChargeMZCancel : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBChargeMZCancel()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBChargeMZCancel();
            objController.Set_GUI_Apperance(this);
        }

        private void txtfph_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string val = this.txtfph.Text.Trim();

                if (val == "")
                {
                    this.txtfph.Tag = "";
                    return;
                }
                else
                {
                    this.txtfph.Tag = val;
                }
                ((clsCtl_YBChargeMZCancel)this.objController).m_mthGetYBInfo();
            }
        }

        private void btnRetun_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_YBChargeMZCancel)this.objController).m_lngYBChargeCancel();
            if (lngRes > 0)
            {
                MessageBox.Show("取消医保结算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}