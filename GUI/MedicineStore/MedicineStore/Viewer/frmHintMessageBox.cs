using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 信息提示窗体
    /// </summary>
    public partial class frmHintMessageBox : Form
    {
        /// <summary>
        /// 信息提示窗体
        /// </summary>
        /// <param name="p_strMessage">提示信息</param>
        public frmHintMessageBox(string p_strMessage)
        {
            InitializeComponent();

            m_txtMessage.Text = p_strMessage;
        }

        private void m_cmdYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void m_cmdNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}