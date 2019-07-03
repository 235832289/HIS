using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NullableDateControls;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmReport_DoctorEarning : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmReport_DoctorEarning()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_Report_DoctorEarning();
            objController.Set_GUI_Apperance(this);
        }

        private void frmReport_DoctorEarning_Load(object sender, EventArgs e)
        {
            m_dtpBeginDat.Value = DateTime.Now;
            m_dtpEndDat.Value = DateTime.Now;
            dw_doctorearning.LibraryList= Application.StartupPath + "\\PB_OP.pbl";
        }

        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在检索数据，请稍候...");
                ((clsCtl_Report_DoctorEarning)this.objController).m_mthSelectDoctorEarning();
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dw_doctorearning, true);
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            this.dw_doctorearning.PrintProperties.Preview = !this.dw_doctorearning.PrintProperties.Preview;
        }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out   int ID);   
        private void buttonXP3_Click(object sender, EventArgs e)
        {
            if (this.dw_doctorearning.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();
                int m_intColumnCount = this.dw_doctorearning.ColumnCount;
                if (FD.FileName.Trim() != "")
                {
                    this.dw_doctorearning.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                    string m_strTemp;
                    string m_strText;
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook wb = null;

                    object missing = System.Reflection.Missing.Value;

                    wb = excel.Workbooks.Open(FD.FileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                    excel.Visible = false;
                    for (int i = 1; i <= m_intColumnCount; i++)
                    {
                        m_strTemp = this.dw_doctorearning.Describe("#" + i.ToString() + ".name");
                        m_strTemp += "_t.text";
                        m_strText = this.dw_doctorearning.Describe(m_strTemp);
                        excel.Cells[1, i] = m_strText;
                    }
                    wb.Save();
                    excel.Quit();
                    IntPtr t = new IntPtr(excel.Hwnd);
                    int k = 0;
                    GetWindowThreadProcessId(t, out   k);
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                    p.Kill(); 
                }
            }
        }

    }
}