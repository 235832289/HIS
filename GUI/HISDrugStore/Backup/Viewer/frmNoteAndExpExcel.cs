using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmNoteAndExpExcel : Form
    {
        public frmNoteAndExpExcel()
        {
            InitializeComponent();
        }

        private void m_btnExportToExcel_Click(object sender, EventArgs e)
        {
            clsPub.m_mthExportToExcel(this.m_dgvDetail);
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}