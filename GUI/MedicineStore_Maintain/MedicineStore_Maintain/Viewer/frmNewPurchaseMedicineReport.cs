using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Controls;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 打印新药通知单
    /// </summary>
    public partial class frmNewPurchaseMedicineReport:Form
    {
        #region 变量
        /// <summary>
        /// 明细
        /// </summary>
        internal DataTable p_dtbVal;
        /// <summary>
        /// 仓库名称
        /// </summary>
        internal string p_strStorageName;
        /// <summary>
        /// 入库日期
        /// </summary>
        internal string p_strDate;
        #endregion 

        /// <summary>
        /// 打印新药通知单
        /// </summary>
        public frmNewPurchaseMedicineReport()
        {
            InitializeComponent();
        }

        #region 窗体事件
        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pDiag = new PrintDialog();
            pDiag.UseEXDialog = true;
            pDiag.AllowSomePages = true;
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                datWindow.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    datWindow.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
                }
                try
                {
                    datWindow.Print(true);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            pDiag = null;
        }

        private void frmNewPurchaseMedicineReport_Load(object sender, EventArgs e)
        {
            datWindow.LibraryList = Application.StartupPath + "\\pb_ms.pbl";
            DataTable m_dtbPrint = p_dtbVal.Copy();
            datWindow.DataWindowObject = "ms_newpurchasemedicine";
            datWindow.Modify("t_title.text = '新药通知单(" + p_strStorageName + ")'");
            datWindow.Modify("t_date.text = '" + p_strDate + "'");
            datWindow.SetRedrawOff();
            datWindow.Retrieve(m_dtbPrint);
            datWindow.SetRedrawOn();
            datWindow.Refresh();
        }
        #endregion 
    }
}