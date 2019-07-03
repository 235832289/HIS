using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPayReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmPayReport()
        {
            InitializeComponent();
        }
        
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			this.objController =new clsControlPayReport();
			this.objController.Set_GUI_Apperance(this);
		}
        private void m_btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            ctlprintShow2.setDocument = printDocument1;
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsControlPayReport)this.objController).m_mthBeiginPrint();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsControlPayReport)this.objController).m_mthPrintPage(e);
        }

        private void frmPayReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ctlprintShow2.setDocument = printDocument1;
        }
    }
}


