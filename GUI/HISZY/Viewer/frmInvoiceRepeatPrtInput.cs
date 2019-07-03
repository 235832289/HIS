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
    /// 发票重打号码输入UI
    /// </summary>
    public partial class frmInvoiceRepeatPrtInput : Form
    {               
        /// <summary>
        /// 构造
        /// </summary>
        public frmInvoiceRepeatPrtInput(string invono)
        {
            InitializeComponent();

            OldInvoNo = invono;
        }

        /// <summary>
        /// 原发票号
        /// </summary>
        private string OldInvoNo = "";
        /// <summary>
        /// 新发票号
        /// </summary>
        private string newno = "";
        /// <summary>
        /// 新发票号
        /// </summary>
        public string NewInvoNo
        {
            get
            {
                return newno;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrePayNoInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNewInvoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newno = this.txtNewInvoNo.Text.Trim();

            if (newno == "")
            {
                MessageBox.Show("请输入新的发票号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (newno == OldInvoNo)
            {
                MessageBox.Show("新发票号不能同于原发票号，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewInvoNo.SelectAll();
                this.txtNewInvoNo.Focus();
                return;
            }

            if (!clsPublic.m_blnCheckInvoExpression(newno))
            {
                MessageBox.Show("输入的发票号不符合规定的发票号规则，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewInvoNo.SelectAll();
                this.txtNewInvoNo.Focus();
                return;
            }

            if (clsPublic.m_blnCheckInvoIsUsed(newno))
            {
                MessageBox.Show("输入的发票号已经被使用，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewInvoNo.SelectAll();
                this.txtNewInvoNo.Focus();
                return;
            }                   

            this.DialogResult = DialogResult.OK;
        }

        private void frmInvoiceRepeatPrtInput_Load(object sender, EventArgs e)
        {
            this.lblOldInvoNo.Text = OldInvoNo;
            this.txtNewInvoNo.Focus();
        }       
    }
}