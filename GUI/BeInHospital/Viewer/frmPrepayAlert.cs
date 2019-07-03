using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPrepayAlert : Form
    {
        /// <summary>
        /// 预交金提示
        /// </summary>
        /// <param name="p_strPayType">支付类型</param>
        /// <param name="p_strPrepay">大写金额</param>
        public frmPrepayAlert(string p_strPayType ,string p_strPrepay)
        {
            InitializeComponent();
            m_txtPayType.Text = p_strPayType;
            m_txtPrepay.Text = p_strPrepay;
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void m_cmdReSet_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void frmPrepayAlert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}