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
    /// 输入按金单号UI
    /// </summary>
    public partial class frmPrePayNoInput : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmPrePayNoInput()
        {
            InitializeComponent();
        }

        private string newno = "";
        /// <summary>
        /// 新号
        /// </summary>
        public string NewNo
        {
            set
            {
                newno = value;
            }
            get
            {
                return newno;
            }            
        }

        /// <summary>
        /// (冲帐)支付方式
        /// </summary>
        private string cuycate = "1";
        /// <summary>
        /// (冲帐)支付方式
        /// </summary>
        public string CuyCate
        {
            get
            {
                return cuycate;
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

        private void txtNewNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newno = this.txtNewNo.Text.Trim();

            if (newno == "")
            {
                MessageBox.Show("请输入按金单据号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!clsPublic.m_blnCheckPrepayNoExpression(newno))
            {
                MessageBox.Show("本地当前预交金收据的编号不符合编码规则，请重新设置(与当前打印票据号相同)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //第二个参数暂时默认 1(正常预交), 以后根据业务需求调整。
            if (clsPublic.m_blnCheckPrepayNoIsUsed(newno, 1))
            {
                MessageBox.Show("本地当前预交金收据的编号已经被使用，请重新设置(与当前打印票据号相同)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                return;
            }

            cuycate = Convert.ToString(this.cbopaytype.SelectedIndex + 1);

            this.DialogResult = DialogResult.OK;
        }

        private void frmPrePayNoInput_Load(object sender, EventArgs e)
        {
            if (newno.Trim() != "")
            {
                this.txtNewNo.Text = newno;
            }

            this.cbopaytype.SelectedIndex = 0;
        }       
    }
}