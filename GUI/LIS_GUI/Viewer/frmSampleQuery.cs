using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmSampleQuery : Form
    {
        public frmSampleQuery()
        {
            InitializeComponent();
        }

        public string BarCode { get; set; }

        public bool PatchPrint { get; set; }

        private void frmSampleQuery_Load(object sender, EventArgs e)
        {
            BarCode = string.Empty;
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barCode = this.txtBarCode.Text.Trim();
                if (barCode != string.Empty)
                {
                    this.BarCode = barCode;
                    if (this.PatchPrint)
                    {
                        if (!string.IsNullOrEmpty(barCode))
                        {
                            clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                            string appId = domain.GetApplicationIdByBarcode(barCode);
                            domain = null;
                            if (!string.IsNullOrEmpty(appId))
                            {
                                //生成条型码
                                string png = string.Empty;
                                clsBarcodeMaker objBarcode = new clsBarcodeMaker();
                                objBarcode.CreateBarcodeBMP(barCode, out png);
                                objBarcode = null;

                                clsSealedBIHLisApplyReportPrint printTool = new clsSealedBIHLisApplyReportPrint();
                                printTool.m_mthGetPrintContent(appId, barCode);
                                printTool.m_mthReport(0, "");
                                this.txtBarCode.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
