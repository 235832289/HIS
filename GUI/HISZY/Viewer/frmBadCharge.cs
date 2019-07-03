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
    /// 呆帐结算UI
    /// </summary>
    public partial class frmBadCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmBadCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BadCharge();
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

        private void frmBadCharge_Load(object sender, EventArgs e)
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
            this.timer.Enabled = true;
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                if (this.cboDeptClass.SelectedIndex == 0)
                {
                    ((clsCtl_BadCharge)this.objController).m_blnChargePatch();
                    ((clsCtl_BadCharge)this.objController).m_mthShowFeeCat(this.ucPatientInfo.RegisterID, 1);
                }
                else
                {
                    this.cboDeptClass.SelectedIndex = 0;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthFind();
        }

        private void frmBadCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthShortCut(e);
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                if (this.cboDeptClass.SelectedIndex == 0)
                {
                    ((clsCtl_BadCharge)this.objController).m_blnChargePatch();
                    ((clsCtl_BadCharge)this.objController).m_mthShowFeeCat(this.ucPatientInfo.RegisterID, 1);
                }
                else
                {
                    this.cboDeptClass.SelectedIndex = 0;
                }
            }
        }
              
        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthCharge();            
        }

        private void cboDeptClass_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (this.ucPatientInfo.RegisterID.Trim() != "")
            {
                ((clsCtl_BadCharge)this.objController).m_mthShowFeeCat(this.ucPatientInfo.RegisterID, this.cboDeptClass.SelectedIndex + 1);
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthCompute();
        }

        private void btnRepeatPrt_Click(object sender, EventArgs e)
        {
            string RegID = this.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRepeatPrt finvoprt = new frmInvoiceRepeatPrt(RegID);
            finvoprt.ShowDialog();
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