using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBDscx : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBDscx()
        {
            InitializeComponent();  
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBDscx();
            objController.Set_GUI_Apperance(this);
        }

        private void frmYBDscx_Load(object sender, EventArgs e)
        {
            ((clsCtl_YBDscx)this.objController).m_mthInit();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBDscx)this.objController).m_mthQuery();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}