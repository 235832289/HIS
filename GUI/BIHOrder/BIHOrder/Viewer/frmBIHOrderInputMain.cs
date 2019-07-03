using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmBIHOrderInputMain : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmBIHOrderInputMain()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_BIHOrderInputMain();
            objController.Set_GUI_Apperance(this);
        }

        private void m_cmdAdd_Click(object sender, EventArgs e)
        {

        }

    }
}