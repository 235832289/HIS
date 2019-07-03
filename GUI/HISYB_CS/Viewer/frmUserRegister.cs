using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmUserRegister :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmUserRegister()
        {
            InitializeComponent();
        }


        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBUserRegister();
            objController.Set_GUI_Apperance(this);
        }

        private void frmUserRegister_Load(object sender, EventArgs e)
        {
            ((clsCtl_YBUserRegister)this.objController).m_mthInit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBUserRegister)this.objController).m_mthUserRegister(1);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_lsvDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_lsvDetail.SelectedItems.Count == 0)
                return;
            ((clsCtl_YBUserRegister)this.objController).m_mthDetailSel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBUserRegister)this.objController).m_mthSetViewInfo(null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBUserRegister)this.objController).m_mthGetDetailList();
        }
    }
}