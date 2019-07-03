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
    /// 退款时选择支付类型
    /// </summary>
    public partial class frmInvoicePayMode : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmInvoicePayMode()
        {
            InitializeComponent();
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
      
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.rdo2.Checked)
            {
                cuycate = Convert.ToString(this.cbopaytype.SelectedIndex + 1);
            }
            else
            {
                cuycate = "-1";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmInvoicePayMode_Load(object sender, EventArgs e)
        {
            this.cbopaytype.Enabled = false;            
        }       

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            this.cbopaytype.Enabled = false;  
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            this.cbopaytype.Enabled = true;
            this.cbopaytype.SelectedIndex = 0;
        }
    }
}