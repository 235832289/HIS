using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBChargeItems : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBChargeItems()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBChargeItems();
            objController.Set_GUI_Apperance(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeItems)this.objController).m_mthGetYBChargeItems();
        }

        private void frmYBChargeItems_Load(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeItems)this.objController).m_mthInit();
        }

        private void rdbAll_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeItems)this.objController).m_mthSelectAllItems();
        }

        private void rdbUnall_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeItems)this.objController).m_mthInvertSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeItems)this.objController).m_mthDeleteYBChargeItems();
        }
    }
}