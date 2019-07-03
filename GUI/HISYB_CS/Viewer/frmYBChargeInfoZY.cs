using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBChargeInfoZY : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBChargeInfoZY()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBChargeInfoZY();
            objController.Set_GUI_Apperance(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeInfoZY)this.objController).m_mthQueryChargesInfo();
        }

        private void frmYBChargeInfoZY_Load(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeInfoZY)this.objController).m_mthInit();
        }

        private void lsvChargeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeInfoZY)this.objController).m_mthFillAllData();
        }

        private void txtInpatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBChargeInfoZY)this.objController).m_mthGetJZJLHbyInpatientID();
            }
        }

        private void cmbJZJLH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBChargeInfoZY)this.objController).m_mthGetJSHbyJZJLH();
            }
        }

        private void cmbJSXH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBChargeInfoZY)this.objController).m_mthQueryChargesInfo();
                this.btnQuery.Focus();
            }
        }
    }
}