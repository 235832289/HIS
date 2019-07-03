using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预交金日结界面   
    /// </summary>
    public partial class frmPrepayCheckout : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        internal int m_showType = 0;

        public frmPrepayCheckout()
        {
            InitializeComponent();
        }
        internal string str_parmval = "0";
        public void ShowWith(string p_showType)
        {
            str_parmval = p_showType;

            this.m_showType = int.Parse(p_showType);
            string[] strArr = p_showType.Split('★');
            if (strArr.Length >= 1)
            {

                this.m_showType = int.Parse(strArr[0]);
            }
                        
            this.Show();
        }

        /// <summary>
        /// 设置控制器对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtlPrepayCheckout();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmPrepayCheckout_Load(object sender, EventArgs e)
        {
            if (this.m_showType == 0)
            {
                ((clsCtlPrepayCheckout)this.objController).GetDisCheckoutPrepayInfo();

                this.m_ctlprintShow.IsShowClose = false;
                this.m_ctlprintShow.setDocument = m_prepayPrintDocument;

                ((clsCtlPrepayCheckout)this.objController).GetCheckoutPrepayHis();
            }
            else
            {
                this.m_buttonCheckout.Enabled = false;
                this.m_buttonRemark.Enabled = false;

                this.m_lbCode.Visible = true;
                this.m_txtCode.Visible = true;

            }
        }

        private void m_prepayPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsCtlPrepayCheckout)this.objController).SetPrintPage(e);
        }

        private void m_buttonBuild_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.m_starDate.Value.ToString("yyyy-MM-dd"), this.m_endDate.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }  
  
            
            ((clsCtlPrepayCheckout)this.objController).GetDisCheckoutPrepayInfo();

            ((clsCtlPrepayCheckout)this.objController).GetCheckoutPrepayHis();
        }

        private void m_buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_buttonCheckout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("注意：结帐后不能修改数据，是否要结帐？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ((clsCtlPrepayCheckout)this.objController).CheckoutPrepayData();
            }
        }

        private void m_HisDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string balanceId;
            balanceId = this.m_HisDataGridView.Rows[e.RowIndex].Cells["BALANCEID_VCHR"].Value.ToString();
            if (balanceId != "" && balanceId != null)
            {
                ((clsCtlPrepayCheckout)this.objController).GetCheckoutPrepayInfoByBalanceId(balanceId);
            }
        }

        private void m_starDate_ValueChanged(object sender, EventArgs e)
        {
            ((clsCtlPrepayCheckout)this.objController).GetCheckoutPrepayHis();
        }

        private void m_endDate_ValueChanged(object sender, EventArgs e)
        {
            ((clsCtlPrepayCheckout)this.objController).GetCheckoutPrepayHis();
        }

        private void m_buttonPrint_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.common.frmSelectPrinter selectPrinter = new com.digitalwave.iCare.common.frmSelectPrinter();
            if (selectPrinter.ShowDialog() == DialogResult.OK)
            {
                m_prepayPrintDocument.PrinterSettings.PrinterName = selectPrinter.PrinterName;
               
            }
            else
            {
                return;
            }
            try
            {

                m_prepayPrintDocument.Print();
            }
            catch
            {
                MessageBox.Show("因为打印机没有设置打印所需的纸张，导致打印失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void m_ctlprintShow_Click(object sender, EventArgs e)
        {
           
        }

        private void m_buttonRemark_Click(object sender, EventArgs e)
        {
            ((clsCtlPrepayCheckout)this.objController).SetBalanceRemark();
        }

        private void m_prepayPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            #region 设置打印
            this.m_prepayPrintDocument.DefaultPageSettings.Landscape = false;
            foreach (System.Drawing.Printing.PaperSize ps in this.m_prepayPrintDocument.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName == "A4")
                {
                    this.m_prepayPrintDocument.DefaultPageSettings.PaperSize = ps;
                    break;
                }
            }
            #endregion
        }

        private void m_cmdDetail_Click(object sender, EventArgs e)
        {
            ((clsCtlPrepayCheckout)this.objController).ShowDetail();
        }

    }
}