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
    public partial class frmReport_Treat : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmReport_Treat()
        {
            InitializeComponent();
        }


        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_BihReport();
             objController.Set_GUI_Apperance(this);
        }

        private void frmReport_Treat_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DWPrintPreview printPreview = new DWPrintPreview(dw_1);
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((clsCtl_BihReport)this.objController).LoadData();
        }
    }
}