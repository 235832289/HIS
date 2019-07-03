using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NullableDateControls;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmReport_GroupEarning : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmReport_GroupEarning()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_Report_GroupEarning();
            objController.Set_GUI_Apperance(this);
        }

        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在检索数据，请稍候...");
                ((clsCtl_Report_GroupEarning)this.objController).m_mthSelectGroupEarning();
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dw_groupearning, true);
        }

        private void frmReport_GroupEarning_Load(object sender, EventArgs e)
        {
            m_dtpBeginDat.Value = DateTime.Now;
            m_dtpEndDat.Value = DateTime.Now;
            dw_groupearning.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            this.dw_groupearning.PrintProperties.Preview = !this.dw_groupearning.PrintProperties.Preview;
        }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out   int ID);
        private void buttonXP3_Click(object sender, EventArgs e)
        {
            if (this.dw_groupearning.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();
                int m_intColumnCount = this.dw_groupearning.ColumnCount;
                if (FD.FileName.Trim() != "")
                {
                    this.dw_groupearning.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                    string m_strTemp;
                    string m_strText;
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook wb = null;

                    object missing = System.Reflection.Missing.Value;

                    wb = excel.Workbooks.Open(FD.FileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                    excel.Visible = false;
                    for (int i = 1; i <= m_intColumnCount; i++)
                    {
                        m_strTemp = this.dw_groupearning.Describe("#" + i.ToString() + ".name");
                        m_strTemp += "_t.text";
                        m_strText = this.dw_groupearning.Describe(m_strTemp);
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