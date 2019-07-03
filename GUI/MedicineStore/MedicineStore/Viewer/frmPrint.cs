using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// DATAWINDOW通用打印对话窗口
    /// </summary>
    public partial class frmPrint : Form
    {
        /// <summary>
        /// 数据源对象语法

        /// </summary>
        private string DataSourceSyntax = "";
        /// <summary>
        /// 数据源对象数据状态

        /// </summary>
        private DataWindowFullState DataFullState;
        /// <summary>
        /// 打印时是否选择打印机

        /// </summary>
        private bool blnChoosePrinter = true;
        /// <summary>
        /// 只预览控件

        /// </summary>
        private ArrayList OnlyPriviewCtlArr = new ArrayList();

        /// <summary>
        /// 构造函数

        /// </summary>
        public frmPrint(DataWindowControl dw)
        {
            InitializeComponent();
            DataSourceSyntax = dw.Describe("datawindow.syntax");
            DataFullState = dw.GetFullState();
        }

        /// <summary>
        /// 构造函数

        /// </summary>
        public frmPrint(DataStore ds)
        {
            InitializeComponent();
            DataSourceSyntax = ds.Describe("datawindow.syntax");
            DataFullState = ds.GetFullState();
        }

        /// <summary>
        /// 构造函数

        /// </summary>
        public frmPrint(DataWindowControl dw, bool _blnChoosePrinter, ArrayList _OnlyPriviewCtlArr)
        {
            InitializeComponent();
            DataSourceSyntax = dw.Describe("datawindow.syntax");
            DataFullState = dw.GetFullState();
            blnChoosePrinter = _blnChoosePrinter;
            OnlyPriviewCtlArr = _OnlyPriviewCtlArr;
        }

        /// <summary>
        /// 构造函数

        /// </summary>
        public frmPrint(DataStore ds, bool _blnChoosePrinter, ArrayList _OnlyPriviewCtlArr)
        {
            InitializeComponent();
            DataSourceSyntax = ds.Describe("datawindow.syntax");
            DataFullState = ds.GetFullState();
            blnChoosePrinter = _blnChoosePrinter;
            OnlyPriviewCtlArr = _OnlyPriviewCtlArr;
        }

        private void frmPrintDialog_Load(object sender, EventArgs e)
        {
            this.dwRep.Create(DataSourceSyntax);
            this.dwRep.SetFullState(DataFullState);
            this.dwRep.CalculateGroups();
            this.dwRep.Refresh();

            for (int i = 0; i < this.OnlyPriviewCtlArr.Count; i++)
            {
                this.dwRep.Modify(this.OnlyPriviewCtlArr[i].ToString() + ".visible = '1'");
            }

            this.dwRep.Modify("datawindow.print.preview = yes");
            this.dwRep.Modify("datawindow.print.preview.rulers = yes");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            clsCtl_Public.ExportDataWindow(this.dwRep, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.OnlyPriviewCtlArr.Count; i++)
            {
                this.dwRep.Modify(this.OnlyPriviewCtlArr[i].ToString() + ".visible = '0'");
            }

            if (this.blnChoosePrinter)
            {
                clsCtl_Public clsPub = new clsCtl_Public();
                clsPub.ChoosePrintDialog(this.dwRep, true);
            }
            else
            {
                this.dwRep.Print(true);
            }

            for (int i = 0; i < this.OnlyPriviewCtlArr.Count; i++)
            {
                this.dwRep.Modify(this.OnlyPriviewCtlArr[i].ToString() + ".visible = '1'");
            }

            //this.dwRep.Modify("datawindow.print.preview = yes");
            //this.dwRep.Modify("datawindow.print.preview.rulers = yes");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnEnd_CheckedChanged(object sender, EventArgs e)
        {
            dwRep.Focus();
            if (m_btnEnd.Checked)
            {                
                SendKeys.Send("^{END}");
            }
            else
            {
                SendKeys.Send("^{HOME}");
            }
        }
    }
}