using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmCheckQuection : Form
    {
        public frmCheckQuection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 0-默认结帐方式 1-指定时间结帐方式
        /// </summary>
        public int intCheckFlag = 0;
        /// <summary>
        /// 结帐时间
        /// </summary>
        public string strCheckDate = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

        private void frmCheckQuection_Load(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true;
            intCheckFlag = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.intCheckFlag = 0;
                this.mdeCheckDate.Enabled = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.mdeCheckDate.Enabled = true;
                this.intCheckFlag = 1;
                this.mdeCheckDate.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                if (this.mdeCheckDate.Text == string.Empty)
                {
                    MessageBox.Show(this, "iCare温馨提示", "结帐在指定时间前，日期不能为空", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    try
                    {
                        DateTime d = Convert.ToDateTime(this.mdeCheckDate.Value);
                        strCheckDate = d.ToString("yyyy-MM-dd HH:mm:59");
                    }
                    catch (Exception objEx)
                    {
                        MessageBox.Show(objEx.Message);
                        return;
                    }
                }
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}