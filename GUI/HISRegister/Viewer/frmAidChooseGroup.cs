using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmAidChooseGroup : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal frmDocotorWorkLoadNew obj;
        private string m_groupID;
        public string GroupID
        {
            get { return this.m_groupID; }
        }
        public frmAidChooseGroup()
        {
            InitializeComponent();
        }

        private void frmAidChooseGroup_Load(object sender, EventArgs e)
        {
            this.dtGroup.DataSource = obj.dtResult.DefaultView;
            this.txtVal.Focus();
        }
       
        private void txtVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int count = this.dtGroup.Rows.Count;
                string value = this.txtVal.Text.Trim();
                if (value == "")
                {
                    return;
                }
                for (int i1 = 0; i1 < count; i1++)
                {
                    if (this.dtGroup.Rows[i1].Cells["colNO"].Value.ToString().Contains(value) || this.dtGroup.Rows[i1].Cells["colName"].Value.ToString().Contains(value))
                    {
                        this.dtGroup.CurrentCell = this.dtGroup.Rows[i1].Cells[0];
                        this.dtGroup.Focus();
                        break;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int count = this.dtGroup.Rows.Count;
            for (int i1 = 0; i1 < count; i1++)
            {
                if (this.dtGroup.Rows[i1].Cells["colZt"].Value != null)
                {
                    if (this.dtGroup.Rows[i1].Cells["colZt"].Value.ToString().Trim() == "T")
                    {
                        this.m_groupID +="'"+this.dtGroup.Rows[i1].Cells["colNo"].Value.ToString()+"',";
                    }
                }
            }

            if (m_groupID == "")
            {
                MessageBox.Show("请从列表中选择统计专家组!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.m_groupID = this.m_groupID.Substring(0, m_groupID.Length - 1);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmAidChooseGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}