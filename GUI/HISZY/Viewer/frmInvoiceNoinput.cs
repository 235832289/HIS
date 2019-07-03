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
    /// 发票号输入UI
    /// </summary>
    public partial class frmInvoiceNoinput : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmInvoiceNoinput()
        {
            InitializeComponent();
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (this.m_blnCheck(this.txtInvono.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmInvoiceNoinput_Load(object sender, EventArgs e)
        {
            this.txtInvono.Focus();
            this.txtInvono.Select(0, 0);
        }

        private void frmInvoiceNoinput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtInvono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_blnCheck(this.txtInvono.Text.Trim()))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// 发票号有效性检查
        /// </summary>
        /// <param name="invono">当前发票号</param>
        /// <returns>true 通过</returns>
        private bool m_blnCheck(string invono)
        {            
            if (!clsPublic.m_blnCheckInvoExpression(invono))
            {
                MessageBox.Show("输入的发票号不符合规定的发票号规则，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (clsPublic.m_blnCheckInvoIsUsed(invono))
            {
                MessageBox.Show("输入的发票号已经被使用，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}