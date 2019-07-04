using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public partial class frmHisMZReportTo : Form
    {
        public frmHisMZReportTo()
        {
            InitializeComponent();
            m_dgvClinic.AutoGenerateColumns = false;
            m_padBar.m_DgvGridView = m_dgvClinic;
            m_padBar.m_IntPageSize = 20;
        }

        /// <summary>
        /// Âß¼­¿ØÖÆÀà
        /// </summary>
        private clsCtl_HisMZReportTo objController;

        private void m_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void frmHisMZReportTo_Load(object sender, System.EventArgs e)
        {
            objController = new clsCtl_HisMZReportTo();
            objController.m_objViewer = this;
        }

        private void m_btnReport_Click(object sender, EventArgs e)
        {
            ((clsCtl_HisMZReportTo)objController).m_mthReport();
        }

        private void m_btnSetConnection_Click(object sender, EventArgs e)
        {
            ((clsCtl_HisMZReportTo)objController).m_mthSetConnection();
        }

        private void m_btnQuery1_Click(object sender, EventArgs e)
        {
            ((clsCtl_HisMZReportTo)objController).m_mthClinicQuery();
        }
    }
}