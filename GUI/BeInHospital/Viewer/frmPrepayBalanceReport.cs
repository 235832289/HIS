using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPrepayBalanceReport : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmPrepayBalanceReport()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlPrepayBalanceReport();
            objController.Set_GUI_Apperance(this);
        }

        private void frmPrepayReportMonth_Load(object sender, EventArgs e)
        {
            dwResult.LibraryList = clsPublic.PBLPath;
            dwResult.DataWindowObject = "d_prepaybalancereport";
            dwResult.InsertRow(0);
            dwResult.Modify("t_1.text='全院预交日结报表 '");
            dwResult.Modify("t_printdate.text='" + DateTime.Today.ToShortDateString() + "'");
        }

        private void m_buttunQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtlPrepayBalanceReport)this.objController).GetBalanceInfo();
            this.Cursor = Cursors.Default;
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void m_buttonPrint_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(dwResult);
        }
    }
}