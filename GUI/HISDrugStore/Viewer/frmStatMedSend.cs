using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmStatMedSend : Form
    {
        public string MedStoreId { get; set; }

        public frmStatMedSend(string _medStoreId)
        {
            InitializeComponent();
            MedStoreId = _medStoreId;
        }

        private void frmStatMedSend_Load(object sender, EventArgs e)
        {

        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            string startDate = this.dtmStart.Value.ToString("yyyy-MM-dd");
            string endDate = this.dtmEnd.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(startDate) > Convert.ToDateTime(endDate))
            {
                MessageBox.Show("开始时间不能大于结束时间。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtmStart.Focus();
                return;
            }
            clsDcl_Account dcl = new clsDcl_Account();
            this.dataGridView.DataSource = dcl.StatMedSend(startDate, endDate, this.MedStoreId);
            dcl = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
