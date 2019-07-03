using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmAdministrative : Form
    {
        public frmAdministrative()
        {
            InitializeComponent();
        }

        DataTable DataSource { get; set; }

        public string Fcode { get; set; }

        private void frmAdministrative_Load(object sender, EventArgs e)
        {
            clsDcl_YB ybDcl = new clsDcl_YB();
            DataSource = ybDcl.GetAdministrative();
            this.dgvData.DataSource = DataSource;
            ybDcl = null;
        }

        void RowSelected()
        {
            Fcode = this.dgvData.SelectedRows[0].Cells["fcode"].Value.ToString();
            if (!string.IsNullOrEmpty(Fcode))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string val = this.txtCode.Text.Trim();
                if (val == string.Empty)
                {
                    this.dgvData.DataSource = DataSource;
                }
                else
                {
                    DataView dv = new DataView(DataSource);
                    dv.RowFilter = "fcode like '%" + val + "%' or fname like '%" + val + "%'";
                    this.dgvData.DataSource = dv.ToTable();
                }
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.RowSelected();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.RowSelected();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
