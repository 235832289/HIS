using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SpireLamella
{
    public partial class frmSpireLamella : Form
    {
        public frmSpireLamella(EntitySpireLamella _SpireVo)
        {
            InitializeComponent();
            if (!DesignMode) this.SpireVo = _SpireVo;
        }

        EntitySpireLamella SpireVo { get; set; }
        List<string> Printers { get; set; }

        private void frmSpireLamella_Load(object sender, EventArgs e)
        {
            this.lblIpNo.Text = this.SpireVo.IpNo;
            this.lblBedNo.Text = this.SpireVo.BedNo;
            this.lblPatName.Text = this.SpireVo.PatName;
            this.lblSex.Text = this.SpireVo.Sex;
            this.lblDeptName.Text = this.SpireVo.DeptName;
            this.txtOper.Text = this.SpireVo.Oper;
            this.txtCheck.Text = this.SpireVo.Check;
            if (!string.IsNullOrEmpty(this.SpireVo.Birthday))
            {
                this.rdoNo.Checked = true;
                string age = (new com.digitalwave.iCare.ValueObject.clsBrithdayToAge()).m_strGetAge(Convert.ToDateTime(this.SpireVo.Birthday));
                string age1 = age.TrimEnd('岁');
                if (Microsoft.VisualBasic.Information.IsNumeric(age1))
                {
                    if (Convert.ToInt32(age1) > 12) this.rdoYes.Checked = true;
                }
                this.lblAge.Text = age;
            }
            Printers = new List<string>();
            foreach (string prt in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                Printers.Add(prt);
            }
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string printerName = this.rdoYes.Checked ? "成人腕带" : "儿童腕带";
            System.Drawing.Printing.PaperSize ps = this.rdoYes.Checked ? (new System.Drawing.Printing.PaperSize(printerName, 138, 1003)) : (new System.Drawing.Printing.PaperSize(printerName, 118, 762));
            this.printDocument.DefaultPageSettings.PaperSize = ps;
            if (Printers.IndexOf(printerName) >= 0) this.printDocument.PrinterSettings.PrinterName = printerName;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float currY = 27;
            float diff = 0;
            BarCode128 bar128 = new BarCode128();
            Image barCode = null;
            if (this.rdoYes.Checked)
            {
                barCode = bar128.EncodeBarcode(this.lblIpNo.Text, 100, 30, false);
                e.Graphics.DrawImage(barCode, 35, 580);
                e.Graphics.TranslateTransform(0.0F, 850.0F);
                currY = 27;
                diff = 23;
            }
            else
            {
                barCode = bar128.EncodeBarcode(this.lblIpNo.Text, 85, 23, false);
                e.Graphics.DrawImage(barCode, 28, 413);
                e.Graphics.TranslateTransform(0.0F, 650.0F);
                currY = 30;
                diff = 18;
            }
            bar128 = null;
            e.Graphics.RotateTransform(-90.0F);

            System.Drawing.Font TextFont = new Font("宋体", 9);
            System.Drawing.Font TextWideFont = new Font("宋体", 9, FontStyle.Bold);

            float currX = 20;
            e.Graphics.DrawString("姓名:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("姓名:", TextFont).Width + 2;
            e.Graphics.DrawString(this.lblPatName.Text, TextWideFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(this.lblPatName.Text, TextWideFont).Width + 5;
            e.Graphics.DrawString("住院号:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("住院号:", TextFont).Width + 2;
            e.Graphics.DrawString(this.lblIpNo.Text, TextFont, Brushes.Black, currX, currY);

            currX = 20;
            currY += diff;
            e.Graphics.DrawString("床号:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("床号:", TextFont).Width + 2;
            e.Graphics.DrawString(this.lblBedNo.Text, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(this.lblBedNo.Text, TextFont).Width + 10;
            e.Graphics.DrawString("性别:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("性别:", TextFont).Width;//+ 2;
            e.Graphics.DrawString(this.lblSex.Text, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(this.lblSex.Text, TextFont).Width + 2;
            e.Graphics.DrawString("年龄:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("年龄:", TextFont).Width;// +2;
            int pos=0;
            string age = this.lblAge.Text;
            if (age.Contains("月") && age.Contains("天"))
            {
                pos = age.IndexOf("月");
                string age1 = age.Substring(0, pos + 1);
                string age2 = age.Substring(pos + 1);
                e.Graphics.DrawString(age1, TextFont, Brushes.Black, currX, currY);
                e.Graphics.DrawString(age2, TextFont, Brushes.Black, currX, currY + diff);
            }
            else if (age.Contains("岁") && age.Contains("月"))
            {
                pos = age.IndexOf("岁");
                string age1 = age.Substring(0, pos + 1);
                string age2 = age.Substring(pos + 1);
                e.Graphics.DrawString(age1, TextFont, Brushes.Black, currX, currY);
                e.Graphics.DrawString(age2, TextFont, Brushes.Black, currX, currY + diff);
            }
            else
            {
                e.Graphics.DrawString(age, TextFont, Brushes.Black, currX, currY);
            }
            currX = 20;
            currY += diff;
            e.Graphics.DrawString("科室:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("科室:", TextFont).Width + 2;
            e.Graphics.DrawString(this.lblDeptName.Text, TextFont, Brushes.Black, currX, currY);
            if (this.cboGlGm.Text != string.Empty)
            {
                currX += e.Graphics.MeasureString(this.lblDeptName.Text, TextFont).Width + 20;
                e.Graphics.DrawString(this.cboGlGm.Text, TextFont, Brushes.Black, currX, currY);
            }
            currX = 20;
            currY += diff;
            e.Graphics.DrawString("佩戴:", TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString("佩戴:", TextFont).Width + 2;
            e.Graphics.DrawString(this.txtOper.Text, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(this.txtOper.Text, TextFont).Width + 10;
            //e.Graphics.DrawString("核对:", TextFont, Brushes.Black, currX, currY);
            //currX += e.Graphics.MeasureString("核对:", TextFont).Width + 2;
            e.Graphics.DrawString(this.txtCheck.Text, TextFont, Brushes.Black, currX, currY);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.printDocument.Print();

            //PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            //printPreviewDialog.Document = this.printDocument;
            //printPreviewDialog.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class EntitySpireLamella
    {
        public string IpNo { get; set; }
        public string BedNo { get; set; }
        public string PatName { get; set; }
        public string Sex { get; set; }
        public string DeptName { get; set; }
        public string Oper { get; set; }
        public string Check { get; set; }
        public string Birthday { get; set; }
    }
}
