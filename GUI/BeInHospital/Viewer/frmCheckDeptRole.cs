using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmCheckDeptRole : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmCheckDeptRole()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlCheckDeptRole();
            objController.Set_GUI_Apperance(this);
        }

        private void frmCheckDeptRole_Load(object sender, EventArgs e)
        {
            ((clsCtlCheckDeptRole)this.objController).LoadData();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            ((clsCtlCheckDeptRole)this.objController).AddCheckDeptRole();
        }

        private void m_lsvRole_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ((clsCtlCheckDeptRole)this.objController).FillCheckDeptRole();
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            ((clsCtlCheckDeptRole)this.objController).RemoveCheckDeptRole();
        }

        private void m_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}