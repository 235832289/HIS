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
    /// 手工滚费定制时间UI类
    /// </summary>
    public partial class frmAutoChargeDate : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmAutoChargeDate()
        {
            InitializeComponent();
        }

        private void frmAutoChargeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string fdate = "";
        /// <summary>
        /// 滚费时间
        /// </summary>
        public string FeeDate
        {
            get
            {
                return fdate;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            fdate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.DialogResult = DialogResult.OK;
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }
    }
}