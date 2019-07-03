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
     
    public partial class frmPurchase_DetailReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public DetalReportVal Drv;
        public frmPurchase_DetailReport()
        {
            InitializeComponent();

            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            
        }
 
        private void frmPurchase_DetailReport_Load(object sender, EventArgs e)
        {
            m_mthSetDataToReport();
            datWindow.PrintProperties.Preview = true;
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            //datWindow.Print();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 设置数据至报表
        /// </summary>
        private void m_mthSetDataToReport()
        {
            this.objController = new clsCtl_Purchase_Detail();

            datWindow.Modify("m_txtProviderName.text='" + Drv.ProviderName + "'");
            datWindow.Modify("m_txtIncomeBillNumber.text='" + Drv.IncomeBillNumber + "'");
            //datWindow.Modify("m_txtInvoiceNumber.text='" + Drv.InvoiceNumber + "'");
            datWindow.Modify("m_dtpInComeDate.text='" + Drv.InComeDate + "'");
            datWindow.Modify("m_txtProvidBillNo.text='" + Drv.ProvidBillNo + "'");
            datWindow.Modify("m_txtInvoiceDate.text='" + Drv.InvoiceDate + "'");
            datWindow.Modify("m_txtPurchasePerson.text='" + Drv.PurchasePerson + "'");
            datWindow.Modify("m_txtMakeBillPerson.text='" + Drv.MakeBillPerson + "'");
            datWindow.Modify("m_txtStroehouseManager.text='" + Drv.StroehouseManager + "'");
            datWindow.Modify("m_txtAccountant.text='" + Drv.Accountant + "'");
            datWindow.Modify("m_txtRemark.text='" + Drv.Remark + "'");
            datWindow.Modify("m_StorageName.text='" + Drv.StorageName + "'");
            datWindow.Modify("t_mone.text='" + Drv.strBigWrith + "'");

            if (datWindow.DataWindowObject == "purchase_detailreport_cs")
            {
                datWindow.Modify("t_tile.text = '" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "入库单(" + Drv.StorageName + ")'");
            }
            else if (datWindow.DataWindowObject == "purchase_detailreport_ts")
            {
                datWindow.Modify("t_tile.text = '" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "入库验收单'");
            }
            else
            {
                datWindow.Modify("t_tile.text = '" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "采购入库单" + "'");
            }
            int m_intShow;
            clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
            m_objDon.m_lngGetIfShowInfo(out m_intShow);
            //((clsDcl_Purchase_DetailReport)m_objDomain).m_lngGetIfShowInfo(out m_blnShow);
            if (m_intShow == 0)
                datWindow.Modify("t_info.text=''");  
            datWindow.SetRedrawOff();
            datWindow.Retrieve(Drv.p_dtbVal);
            datWindow.CalculateGroups();
            datWindow.Refresh();
            datWindow.SetRedrawOn();
        }
    }
}