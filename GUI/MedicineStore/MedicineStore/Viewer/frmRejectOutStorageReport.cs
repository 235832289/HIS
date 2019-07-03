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
    public partial class frmRejectOutStorageReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public DataTable dtb = new DataTable();
        public string strStorageName;
        public string m_strReportName;
        public string m_strTitle;
        public string strCheckDate;
        public string strAskerName;
        public string strFhr;
        public string strExamerName;
        public string strBag;

        public frmRejectOutStorageReport()
        {
            InitializeComponent();
            //datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            //datWindow.DataWindowObject = m_strReportName;
        }

        private void frmRejectOutStorageReport_Load(object sender, EventArgs e)
        {
            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;

            datWindow.DataWindowObject ="rejectoutstorage_" + m_strReportName;

            datWindow.Modify("t_Title.text='" + m_strTitle + "'");
            datWindow.Modify("t_strStorageName.text='" + strStorageName + "'");
            datWindow.Modify("t_RejectDate.text='" + strCheckDate + "'");
            datWindow.Modify("t_AskerName.text='" + strAskerName + "'");
            datWindow.Modify("t_ExamerName.text='" + strExamerName + "'");
            datWindow.Modify("t_bag.text='" + strBag + "'");
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
            Close();
        }
    }
}