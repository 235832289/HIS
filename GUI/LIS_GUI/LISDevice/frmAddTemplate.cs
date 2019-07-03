using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmAddTemplate : Form
    {
        private string m_strTemplateName;

        public string TemplateName
        {
            get { return m_strTemplateName; }
            set { m_strTemplateName = value; }
        }

        public frmAddTemplate()
        {
            InitializeComponent();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_txtTemplateName.Text))
            {
                MessageBox.Show("请输入模板名称！");
                return;
            }
            this.m_strTemplateName = this.m_txtTemplateName.Text;
        }
    }
}