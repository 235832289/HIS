using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iCare
{
    public partial class frmPartogramSelected : Form
    {
        public frmPartogramSelected(string p_strMessage)
        {
            InitializeComponent();
            using (Graphics g = this.CreateGraphics())
            {
                SizeF s = g.MeasureString(p_strMessage, m_lblMessage.Font, m_lblMessage.Width);
                int intRHeight = (int)s.Height;
                if(m_lblMessage.Height < intRHeight)
                {
                    int intOffset = intRHeight-m_lblMessage.Height;
                    m_lblMessage.Height = intRHeight;
                    this.Height += intOffset;
                }
            }
            m_lblMessage.Text = p_strMessage;
        }

        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}