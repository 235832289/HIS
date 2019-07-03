using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmCritialDeptList : Form
    {
        public string deptStr { get; set; }
        private int deptint = 0;
        public frmCritialDeptList(int deptintTmp)
        {
            deptint = deptintTmp;
            InitializeComponent();
        }

        private void frmCritialDeptList_Load(object sender, EventArgs e)
        {
            this.dgvDeptList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            try
            {
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));

                DataTable dt = svc.GetDeptList(deptint);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int index = this.dgvDeptList.Rows.Add();
                        //this.dataGridView1.Rows[index].Cells[0].Value = index.ToString();
                        this.dgvDeptList.Rows[index].Cells[1].Value = (index+1).ToString();
                        this.dgvDeptList.Rows[index].Cells[2].Value = dr["code_vchr"].ToString().Trim();
                        this.dgvDeptList.Rows[index].Cells[3].Value = dr["deptname_vchr"].ToString().Trim();
                    }
                }
             
            }
            finally
            {
            }
        }

        public void setDeptstr()
        {

            for (int i = 0; i < dgvDeptList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)dgvDeptList.Rows[i].Cells[0];  

                if (checkBox != null && ((bool)checkBox.EditingCellFormattedValue == true || 
                    (bool)checkBox.FormattedValue == true))
                {
                    if (dgvDeptList.Rows[i].Cells[2].Value.ToString() == "0")
                    {
                        deptStr = null ;
                        break;
                    }
                    else   
                        deptStr += "'" + dgvDeptList.Rows[i].Cells[2].Value.ToString() + "'" + ",";  
                }  
            }
            if(deptStr != null)
                deptStr = "(" + deptStr.Substring(0, deptStr.Length - 1) + ")";

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            setDeptstr();
            if (chkSelectAll.Checked)
                deptStr = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            deptStr = null;
            this.Close();
        }

        private void txtDeptFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvDeptList.Rows.Count; i++)
                {
                    if (txtDeptFind.Text.Trim() == dgvDeptList.Rows[i].Cells[2].Value.ToString())
                    {
                        this.dgvDeptList.CurrentCell = this.dgvDeptList.Rows[i].Cells[0];
                        break;
                    }

                    if ((dgvDeptList.Rows[i].Cells[3].Value.ToString()).IndexOf(txtDeptFind.Text.Trim()) >= 0)
                    {
                        this.dgvDeptList.CurrentCell = this.dgvDeptList.Rows[i].Cells[0];
                        break;
                    }
                }
            }
            finally
            {
 
            }
        }

        private void txtDeptFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < dgvDeptList.Rows.Count; i++)
                {
                    if (txtDeptFind.Text.Trim() == dgvDeptList.Rows[i].Cells[2].Value.ToString())
                    {
                        this.dgvDeptList.CurrentCell = this.dgvDeptList.Rows[i].Cells[0];
                        break;
                    }

                    if ((dgvDeptList.Rows[i].Cells[3].Value.ToString()).IndexOf(txtDeptFind.Text.Trim())>=0)
                    {
                        this.dgvDeptList.CurrentCell = this.dgvDeptList.Rows[i].Cells[0];
                        break;
                    }
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in this.dgvDeptList.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells[0]).Value = this.chkSelectAll.Checked; 
        }
    }
}
