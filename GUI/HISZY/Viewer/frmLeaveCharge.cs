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
    /// 出院结算UI
    /// </summary>
    public partial class frmLeaveCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmLeaveCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_LeaveCharge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 发票号检查失败直接退出标志
        /// </summary>
        private bool noopen = false;

        /// <summary>
        /// 当前收费员.发票号
        /// </summary>
        internal string InvoNo { get; set; }

        private void frmLeaveCharge_Load(object sender, EventArgs e)
        {
            #region 读出发票号
            bool b = false;
            string invono = clsPublic.m_strGetCurrInvoiceNo(this.LoginInfo.m_strEmpID, 1);
            frmIPInvoiceinput fo = new frmIPInvoiceinput();
            fo.txtInvono.Text = invono;
            this.Visible = false;
            this.timerInvo.Enabled = false;
            if (fo.ShowDialog() == DialogResult.Cancel)
            {
                b = true;
            }
            else
            {
                #region 发票号检验 
                invono = fo.txtInvono.Text.Trim();
                if (!clsPublic.m_blnCheckInvoExpression(invono))
                {
                    MessageBox.Show("输入的发票号不符合规定的发票号规则，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b = true;
                }
                if (clsPublic.m_blnCheckInvoIsUsed(invono))
                {
                    MessageBox.Show("输入的发票号已经被使用，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b = true;
                }
                #endregion
            }

            if (b)
            {
                noopen = true;
                this.timerInvo.Enabled = true;
                this.timerInvo.Interval = 3000;
                return;
            }
            else
            {
                this.InvoNo = invono;
                this.timerInvo.Enabled = true;
                this.timerInvo.Interval = 1000;
                this.Cursor = Cursors.WaitCursor;
            }
            #endregion

            clsPublic.SuspendLayout(ucPatientInfo.Handle);
            this.ucPatientInfo.Status = 8;

            //if (clsPublic.m_strGetSysparm("1000") == "001")
            //{
            //    this.btnYb.Visible = true;
            //}
            //else
            //{
                  this.btnYb.Visible = false;
            //}
            this.dtgDetail.AutoGenerateColumns = false;
            ((clsCtl_LeaveCharge)this.objController).m_mthInt();
            this.timer.Enabled = true;
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            { 
                ((clsCtl_LeaveCharge)this.objController).m_mthShowAllFeeDetail(this.ucPatientInfo.RegisterID);               
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthFind();
        }

        private void frmLeaveCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthShortCut(e);
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {                
                ((clsCtl_LeaveCharge)this.objController).m_mthShowAllFeeDetail(this.ucPatientInfo.RegisterID);                
            }
        }
              
        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthCharge();
        }              

        private void btnRepeatPrt_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthRepeatPrt();
        }

        private void btnRefundment_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthRefundment();
        }

        private void btnYb_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthDownLoadYBData();
        }

        private void dtgDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthSetRowColor();
        }

        private void btnYBCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthYBPrintBillDet();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            clsPublic.ResumeLayout(ucPatientInfo.Handle);
            ucPatientInfo.Invalidate();
            ucPatientInfo.Refresh();
        }

        private void timerInvo_Tick(object sender, EventArgs e)
        {
            if (noopen)
            {
                foreach (Form f in this.MdiParent.MdiChildren)
                {
                    f.WindowState = FormWindowState.Maximized;
                }
                this.MdiParent.Refresh();
                this.Close();
            }
            else
            {
                this.timerInvo.Enabled = false;
                this.Visible = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}