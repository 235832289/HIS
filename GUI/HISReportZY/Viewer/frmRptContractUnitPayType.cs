using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace com.digitalwave.iCare.gui.HIS.Reports 
{
    public partial class frmRptContractUnitPayType : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmRptContractUnitPayType()
        {
            InitializeComponent();

        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_RptContractUnitPayType();
            objController.Set_GUI_Apperance(this);
        }

        private void m_cmdSelect_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptContractUnitPayType)this.objController).m_mthSelect();
        }

        private void frmRptContractUnitPayType_Load(object sender, EventArgs e)
        {
            this.m_dwreport.LibraryList = clsPublic.PBLPath;
            this.m_dwreport.DataWindowObject = "d_bih_contractunitreport";
            this.m_dwreport.Modify("t_hospitalname.text='" + ((clsCtl_RptContractUnitPayType)this.objController).strHospitalName + "'");
            this.m_dwreport.Refresh();
        }

        private void m_cmdExeport_Click(object sender, EventArgs e)
        {
            if (this.m_dwreport.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.m_dwreport, null);
            }
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.m_dwreport, true);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}