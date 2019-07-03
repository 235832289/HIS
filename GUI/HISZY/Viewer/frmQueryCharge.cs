using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 期帐查询UI
    /// </summary>
    public partial class frmQueryCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 初始化时标志
        /// </summary>
        internal bool isInint = false;
        /// <summary>
        /// 初始化时标志
        /// </summary>
        internal bool isInitInvo = false;
        /// <summary>
        /// 日期控件是否拥有焦点
        /// </summary>
        internal bool RqIsFocused = false;

        /// <summary>
        /// 构造
        /// </summary>
        public frmQueryCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_QueryCharge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMidCharge_Load(object sender, EventArgs e)
        {
            isInint = true;
            isInitInvo = true;
            clsPublic.SuspendLayout(ucPatientInfo.Handle);
            ((clsCtl_QueryCharge)this.objController).m_mthInit();
            this.timer.Enabled = true;
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthClear();
                ((clsCtl_QueryCharge)this.objController).m_mthQueryCharge();
                ((clsCtl_QueryCharge)this.objController).m_mthShowDayAccounts();
                ((clsCtl_QueryCharge)this.objController).m_mthShowInvoice();
            }
        }

        private void frmQueryCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出该窗口？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            //设置快捷信息
            clsPublic.SetShortCutInfo(this.MdiParent, 4, "");
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthClear();
                ((clsCtl_QueryCharge)this.objController).m_mthQueryCharge();
                ((clsCtl_QueryCharge)this.objController).m_mthShowDayAccounts();
                ((clsCtl_QueryCharge)this.objController).m_mthShowInvoice();
            }
        }

        private void llbl1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(1);
        }

        private void llbl2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(2);
        }

        private void llbl3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(3);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(3);
        }

        private void frmQueryCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthShortCut(e);
        }

        private void llbl4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(4);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSelectTabpage(4);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthFind();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthFind();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthQueryCharge();
        }

        private void lvCat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvCat1.SelectedItems.Count > 0)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthFilter(1);
            }
        }

        private void lvCat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvCat2.SelectedItems.Count > 0)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthFilter(2);
            }
        }

        private void lvCat2_Click(object sender, EventArgs e)
        {
            if (this.lvCat2.Items.Count == 1 && this.lvCat2.SelectedItems.Count > 0)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthFilter(2);
            }
        }

        private void btnAllDetail_Click(object sender, EventArgs e)
        {
            this.txtAREAID.Value = "00";
            this.txtAREAID.Text = "全院科室";
            ((clsCtl_QueryCharge)this.objController).m_mthQueryCharge();
        }

        private void btnOrgSort_Click(object sender, EventArgs e)
        {
            if (((clsCtl_QueryCharge)this.objController).dvSource.Count > 0)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthFillData(((clsCtl_QueryCharge)this.objController).dvSource, ((clsCtl_QueryCharge)this.objController).OrgSortStr);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSort();
        }

        private void dtItem_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthShowSelectedMoney();
        }

        private void btnItemSum_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthItemSum();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInint)
            {
                return;
            }

            ((clsCtl_QueryCharge)this.objController).m_mthSelectBill(this.cboType.SelectedIndex);
        }

        private void btnPurview_Click(object sender, EventArgs e)
        {
            this.dw1.PrintProperties.ShowPreviewRulers = !this.dw1.PrintProperties.ShowPreviewRulers;
            this.dw1.PrintProperties.Preview = !this.dw1.PrintProperties.Preview;
        }

        private void btnSelect3_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthShowBill();
        }

        private void btnPrint3_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dw1, true);
        }

        private void btnExport3_Click(object sender, EventArgs e)
        {
            if (this.dw1.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dw1, null);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 2 && this.isInint)
            {
                isInint = false;
                this.cboType.SelectedIndex = 0;
            }
            else if (this.tabControl1.SelectedIndex == 3 && this.isInitInvo)
            {
                isInitInvo = false;
                int isOpen = clsPublic.m_intGetSysParm("1145");
                if (isOpen == 0)
                {
                    this.dw2.DataWindowObject = "d_invoice";
                }
                else
                {
                    this.dw2.LibraryList = Application.StartupPath + @"\pb_Invioce.pbl";
                    this.dw2.DataWindowObject = "d_invoice_gd";
                }
                if (((clsCtl_QueryCharge)this.objController).intDiffCostOn == 1)
                {
                    this.dw2.LibraryList = Application.StartupPath + @"\pb_Invioce.pbl";
                    this.dw2.DataWindowObject = "d_invoice_gd_diff";
                }
                this.dw2.InsertRow(0);
            }
        }

        private void dteRq_Enter(object sender, EventArgs e)
        {
            this.RqIsFocused = true;
        }

        private void dteRq_Leave(object sender, EventArgs e)
        {
            this.RqIsFocused = false;
        }

        private void tv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string DayAccountID = e.Node.Tag.ToString();

            if (DayAccountID.Trim() == "" || DayAccountID.ToLower() == "root")
            {
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_QueryCharge)this.objController).m_mthShowDayAcctDet(DayAccountID);
                this.Cursor = Cursors.Default;
            }
        }

        private void tv2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                return;
            }
            else
            {
                DataRowView drv = e.Node.Tag as DataRowView;
                ((clsCtl_QueryCharge)this.objController).m_mthShowInvoDet(drv);
            }
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintInvoice();
        }

        private void buttonXP4_Click(object sender, EventArgs e)
        {
            this.dw2.PrintProperties.ShowPreviewRulers = !this.dw2.PrintProperties.ShowPreviewRulers;
            this.dw2.PrintProperties.Preview = !this.dw2.PrintProperties.Preview;
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(this.btnPrint1, new Point(this.btnPrint1.Width, this.btnPrint1.Height));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthExportBillDet();
        }

        private void btnPatchDayAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPatchDayAccount();
        }

        private void btnInvoDet_Click(object sender, EventArgs e)
        {
            if (this.btnInvoDet.Tag != null && this.btnInvoDet.Tag.ToString().Trim() != "")
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_QueryCharge)this.objController).m_mthShowInvoiceEntry(this.btnInvoDet.Tag.ToString().Trim());
                this.Cursor = Cursors.Default;
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintBillCat();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintBillDet();
        }

        private void btnYBDbf_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthCreateDBF();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintAreaRefundmentBill(1);
        }

        private void dteRq1_Enter(object sender, EventArgs e)
        {
            this.RqIsFocused = true;
        }

        private void dteRq1_Leave(object sender, EventArgs e)
        {
            this.RqIsFocused = false;
        }

        private void dteRq2_Enter(object sender, EventArgs e)
        {
            this.RqIsFocused = true;
        }

        private void dteRq2_Leave(object sender, EventArgs e)
        {
            this.RqIsFocused = false;
        }

        private void btnSbBill_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(this.btnSbBill, new Point(this.btnSbBill.Width - 125, this.btnSbBill.Height));
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintSbBill_CS(0);
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintSbBill_CS(1);
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintSbBill_CS(2);
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthRefundment();
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintAreaRefundmentBill(1);
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthPrintAreaRefundmentBill(2);
        }

        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthFindItem();
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthDiagItem();
        }

        private void dtItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (this.dtItem.SelectedRows.Count > 0)
            {
                ((clsCtl_QueryCharge)this.objController).m_mthShowDiagItemTip(((DataRowView)this.dtItem.SelectedRows[0].DataBoundItem).Row);
            }
        }

        private void dtItem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthSetRowColor();
        }

        private void 修改适应症ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthChangeSFLB();
        }

        private void 医保费用结算单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).m_mthYBPrintBillDet();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            clsPublic.ResumeLayout(ucPatientInfo.Handle);
            ucPatientInfo.Invalidate();
            ucPatientInfo.Refresh();
        }

        private void llblFeeCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_QueryCharge)this.objController).SetPatFeeCheck();
        }

    }
}