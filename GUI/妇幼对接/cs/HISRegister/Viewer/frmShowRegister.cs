using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmShowRegister : Form
    {
        public frmShowRegister()
        {
            InitializeComponent();
        }
        DataTable printDt = new DataTable();
        public DataTable GetPrintData
        {
            set
            {
                printDt = value;
            }
        }
        int _pintNuber = 0;
        public int printNuber
        {
            set
            {
                _pintNuber = value;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("宋体", 10.5F);
            Font font1 = new Font("宋体", 9F);
            Font font2 = new Font("宋体", 8F);
            e.Graphics.DrawString(printDt.Rows[0]["registertype"].ToString(), font, Brushes.Black, 59, 13);
            
            e.Graphics.DrawString(printDt.Rows[0]["txtNO"].ToString(), font, Brushes.Black, 295,13);
            e.Graphics.DrawString(printDt.Rows[0]["patienCard"].ToString(), font, Brushes.Black, 59, 29);

            e.Graphics.DrawString(printDt.Rows[0]["patientname"].ToString(), font, Brushes.Black, 118, 70);
            e.Graphics.DrawString(printDt.Rows[0]["orderno"].ToString(), font, Brushes.Black, 319, 70);

            e.Graphics.DrawString(printDt.Rows[0]["strDiagdept"].ToString(), font, Brushes.Black, 110, 100);

            e.Graphics.DrawString(printDt.Rows[0]["doctorName"].ToString(), font, Brushes.Black, 307, 100);

            e.Graphics.DrawString("￥" + printDt.Rows[0]["decimal1"].ToString() + " 元", font, Brushes.Black, 118, 136);
            e.Graphics.DrawString("￥" + printDt.Rows[0]["decimal2"].ToString() + " 元", font, Brushes.Black, 307, 136);
            e.Graphics.DrawString(printDt.Rows[0]["date"].ToString(), font, Brushes.Black, 118, 166);
            decimal tolmoney = decimal.Parse(printDt.Rows[0]["decimal1"].ToString()) + decimal.Parse(printDt.Rows[0]["decimal2"].ToString());
            e.Graphics.DrawString("合计：" + tolmoney + " 元", font, Brushes.Black, 87, 193);
            e.Graphics.DrawString("挂号员： " + printDt.Rows[0]["strEmpt"].ToString(), font, Brushes.Black, 260, 193);
            e.Graphics.DrawString("此票需盖挂号专用章，当天有效", font1, Brushes.Black, 98, 210);
            Pen linePen = new Pen(Brushes.Black, 1);
            e.Graphics.DrawLine(linePen, 346, 206, 405, 206);
            e.Graphics.DrawLine(linePen, 346, 206, 346, 242);
            e.Graphics.DrawLine(linePen, 405, 206, 405, 242);
            e.Graphics.DrawLine(linePen, 346, 242, 405, 242);
            e.Graphics.DrawString("佛山市第二", font2, Brushes.Black, 346, 208);
            e.Graphics.DrawString("人民医院", font2, Brushes.Black, 350, 218);
            e.Graphics.DrawString("收费专用章", font2, Brushes.Black, 346, 228);
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

           //WritePrinter((IntPtr)sender, new byte(chprintdata), 2, ref dwwriten);
            //printDocument1.DefaultPageSettings = PrtSetUp(printDocument1);
        }
        public PageSettings PrtSetUp(PrintDocument printDocument)
        {
            //声明返回值的PageSettings
            PageSettings ps = new PageSettings();
            //申明并实例化PageSetupDialog
            PageSetupDialog psDlg = new PageSetupDialog();
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("挂号打印", 472, 276);
            try
            {
                //相关文档及文档页面默认设置
                psDlg.Document = printDocument;
                psDlg.PageSettings = printDocument.DefaultPageSettings;
                psDlg.PageSettings.PaperSize = size;
                ps = psDlg.PageSettings;
                printDocument.DefaultPageSettings = psDlg.PageSettings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现打印错误");
            }
            finally
            {
                psDlg.Dispose();
                psDlg = null;
            }
            return ps;
        }

        private void frmShowRegister_Load(object sender, EventArgs e)
        {
            this.ctlprintShow1.IsShowClose = false;
            ctlprintShow1.setDocument = printDocument1;
        }

    }
}