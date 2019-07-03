using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmAccountPeriodReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public DataTable dtb = new DataTable();
        public string strBeginDate;
        public string strEndDate;
        public string strStorageName;
        public string strTitel;

        public frmAccountPeriodReport()
        {
            InitializeComponent();
            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            datWindow.DataWindowObject = "account_cs";
        }

        private void frmAccountPeriodReport_Load(object sender, EventArgs e)
        {
            datWindow.Modify("t_titel.text='" + strTitel + "库存金额统计表(" + strStorageName + ")'");
            datWindow.Modify("t_begindate.text='" + strBeginDate + "'");
            datWindow.Modify("t_enddate.text='" + strEndDate + "'");
            datWindow.SetRedrawOff();
            datWindow.Retrieve(dtb);
            datWindow.SetRedrawOn();
            datWindow.Refresh();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}