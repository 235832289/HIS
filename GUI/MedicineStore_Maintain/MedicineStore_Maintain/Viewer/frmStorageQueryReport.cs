using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Controls;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmStorageQueryReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public DataTable p_dtbVal;
        public string p_titel;
        public string p_strStorageName;
        /// <summary>
        /// 报表名称
        /// </summary>
        public string m_strReportName = string.Empty;
        /// <summary>
        /// 购入金额
        /// </summary>
        internal double m_dblCallSum = 0;
        /// <summary>
        /// 零售金额
        /// </summary>
        internal double m_dblRetailSum = 0;
        public frmStorageQueryReport()
        {
            InitializeComponent();
        }
        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_StorageQueryReport();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmStorageQueryReport_Load(object sender, EventArgs e)
        {
            datWindow.LibraryList = Application.StartupPath + "\\pb_ms.pbl";            
            string m_HospitalTitle = objController.m_objComInfo.m_strGetHospitalTitle();
            DataTable m_dtbPrint = p_dtbVal.Copy();
            m_dtbPrint.Columns.Remove("STORAGERACKID_CHR");
            m_dtbPrint.Columns.Remove("CANPROVIDE");

            if (m_strReportName == "")
            {
                datWindow.DataWindowObject = "storagequery";
                datWindow.Modify("t_4.text = '" + m_HospitalTitle + "库存单(" + p_strStorageName + ")'");
                m_dtbPrint.Columns.Remove("vendorname_vchr");
                m_dtbPrint.Columns.Remove("endamount_int");
                m_dtbPrint.Columns.Remove("wholesaleprice_int");
                m_dtbPrint.Columns.Remove("callsum");
                m_dtbPrint.Columns.Remove("retailsum");
                m_dtbPrint.Columns.Remove("wholesalesum");
                m_dtbPrint.Columns.Remove("MEDICINEROOMNAME");

                //CS-461 (ID:13168)西药库存查询问题
                datWindow.Modify("t_callsum.text = '" + m_dblCallSum.ToString("F4") + "'");
                datWindow.Modify("t_retailsum.text = '" + m_dblRetailSum.ToString("F4") + "'");
            }
            else
            {
                datWindow.DataWindowObject = "storagequery_" + m_strReportName;
                datWindow.Modify("t_tile.text = '" + m_HospitalTitle + "库存单(" + p_strStorageName + ")'");

                datWindow.Modify("t_callsum.text = '" + m_dblCallSum.ToString("F4") + "'");
                datWindow.Modify("t_retailsum.text = '" + m_dblRetailSum.ToString("F4") + "'");
            }
            datWindow.SetRedrawOff();
            datWindow.Retrieve(m_dtbPrint);
            datWindow.SetRedrawOn();
            datWindow.Refresh();
        }

        
        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}