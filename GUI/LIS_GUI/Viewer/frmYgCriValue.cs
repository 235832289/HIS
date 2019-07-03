using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmYgCriValue : Form
    {
        public frmYgCriValue()
        {
            InitializeComponent();
        }

        private void frmYgCriValue_Load(object sender, EventArgs e)
        {
            bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
            DataTable dt = svc.GetCriYG();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string[] arr = new string[1];
                    arr[0] = dr["refDesc"].ToString().Trim();
                    this.dataGridView.Rows.Add(arr);
                }
                this.dataGridView.Refresh();
            }
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            this.dataGridView.Rows.Add();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.dataGridView.Rows.Remove(this.dataGridView.CurrentRow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string refDesc = string.Empty;
            List<string> lstRefDesc = new List<string>();

            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                if (this.dataGridView.Rows[i].Cells[0].Value == null) continue;
                refDesc = this.dataGridView.Rows[i].Cells[0].Value.ToString();
                if (!string.IsNullOrEmpty(refDesc) && refDesc.Trim() != string.Empty)
                {
                    lstRefDesc.Add(refDesc);
                }
            }
            bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
            int ret = svc.SaveCriYG(lstRefDesc);
            svc = null;
            if (ret > 0)
            {
                MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
