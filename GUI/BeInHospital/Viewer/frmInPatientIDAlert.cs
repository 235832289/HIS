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
    /// 住院号提示框
    /// </summary>
    public partial class frmInPatientIDAlert : Form
    {
        public frmInPatientIDAlert(string p_strInpatientID)
        {
            InitializeComponent();
            m_txtInpatientID.Text = p_strInpatientID;
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void frmInPatientIDAlert_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.DialogResult = DialogResult.OK;
                    break;
                default:
                    break;
            }
        }
    }
}