using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class PerpayBalanceRemark : Form
    {
        private string m_remark;

        public string BalanceRemark
        {
            get { return m_remark; }
            set { m_remark = value; }
        }
  
        public PerpayBalanceRemark()
        {
            InitializeComponent();
        }

        private void PerpayBalanceRemark_Load(object sender, EventArgs e)
        {
            
        }

        private void m_buttonConfirm_Click(object sender, EventArgs e)
        {
           
            this.m_remark = m_rtpRemark.Text;
            this.DialogResult = DialogResult.OK;
            this.Hide();

        }

        private void m_buttonCancel_Click(object sender, EventArgs e)
        {
            this.m_remark = "";
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }


    }
}