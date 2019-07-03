using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmAidChooseDepart : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmDiscountStatistic objDiscountStatistic;
        public frmAidChooseDepart()
        {
            InitializeComponent();
        }
        private string m_departID;
        public string DepartID
        {
            get { return this.m_departID; }
        }

        private void frmAidChooseDepart_Load(object sender, EventArgs e)
        {
            if (this.objDiscountStatistic != null)
            {
                this.dtDepart.DataSource = this.objDiscountStatistic.dtResult.DefaultView;
            }
            this.txtVal.Focus();
        }

        private void txtVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int count = this.dtDepart.Rows.Count;
                string value = this.txtVal.Text.Trim();
                if (value == "")
                {
                    return;
                }
                for (int i1 = 0; i1 < count; i1++)
                {
                    if (this.dtDepart.Rows[i1].Cells["colNO"].Value.ToString().Contains(value) || this.dtDepart.Rows[i1].Cells["colName"].Value.ToString().Contains(value))
                    {
                        this.dtDepart.CurrentCell = this.dtDepart.Rows[i1].Cells[0];
                        this.dtDepart.Focus();
                        break;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int count = this.dtDepart.Rows.Count;
            for (int i1 = 0; i1 < count; i1++)
            {
                if (this.dtDepart.Rows[i1].Cells["colZt"].Value != null)
                {
                    if (this.dtDepart.Rows[i1].Cells["colZt"].Value.ToString().Trim() == "T")
                    {
                        this.m_departID += "'" + this.dtDepart.Rows[i1].Cells["colNo"].Value.ToString() + "',";
                    }
                }
            }

            if (m_departID == "" || m_departID == null)
            {
                MessageBox.Show("请从列表中选择统计的科室名!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.m_departID = this.m_departID.Substring(0, m_departID.Length - 1);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAidChooseDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}