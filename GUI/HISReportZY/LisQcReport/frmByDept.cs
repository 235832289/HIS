using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmByDept : Form
    {
        public frmByDept()
        {
            InitializeComponent();
        }

        public frmByDept(ArrayList p_DeptIDArr)
        {
            InitializeComponent();
            this.LimitDeptIDArr = p_DeptIDArr;
        }

        public frmByDept(int area)
        {
            InitializeComponent();
            this.area = area;
        }

        public List<string> LstDeptID;
        public string DeptIDArr;
        public List<string> LstDeptName;
        private string deptidarr = "";
        private int area = 0;
        private ArrayList LimitDeptIDArr = new ArrayList();
        public int DeptFlag = 1;

        private void frmByDept_Load(object sender, EventArgs e)
        {
            this.LstDeptID = new List<string>();
            this.LstDeptName = new List<string>();
            //clsDcl_Charge clsDcl_Charge = new clsDcl_Charge();
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
            long num = 0;
            DataTable dataTable =  null;

            if (this.area == 1)
            {
                num = svc.GetArea(out dataTable);
            }
            else
            {
                 num = svc.GetDeptArea(out dataTable);
            }
            
            if (num > 0L)
            {
                int i = 0;
                while (i < dataTable.Rows.Count)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    if (this.LimitDeptIDArr.Count <= 0 || this.LimitDeptIDArr.IndexOf(dataRow["deptid_chr"].ToString()) >= 0)
                    {
                        string[] values = { "F", Convert.ToString(i + 1), dataRow["code_vchr"].ToString().Trim(), dataRow["deptname_vchr"].ToString().Trim() };
                        int index = this.dtDept.Rows.Add(values);
                        this.dtDept.Rows[index].Tag = dataRow;
                    }
                    i++;
                }
            }
            this.txtVal.Focus();
        }

        private void txtVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string text = this.txtVal.Text.Trim();
                if (!(text == ""))
                {
                    for (int i = 0; i < this.dtDept.Rows.Count; i++)
                    {
                        if (this.dtDept.Rows[i].Cells["colDm"].Value.ToString().Contains(text) || this.dtDept.Rows[i].Cells["colKsmc"].Value.ToString().Contains(text))
                        {
                            this.dtDept.CurrentCell = this.dtDept.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                for (int i = 0; i < this.dtDept.Rows.Count; i++)
                {
                    this.dtDept.Rows[i].Cells["colZt"].Value = "T";
                }
            }
            else
            {
                for (int i = 0; i < this.dtDept.Rows.Count; i++)
                {
                    this.dtDept.Rows[i].Cells["colZt"].Value = "F";
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.deptidarr = "";
            this.LstDeptID = new List<string>();
            for (int i = 0; i < this.dtDept.Rows.Count; i++)
            {
                if (this.dtDept.Rows[i].Cells["colZt"].Value.ToString().Trim() == "T")
                {
                    DataRow dataRow = this.dtDept.Rows[i].Tag as DataRow;
                    this.deptidarr = this.deptidarr + "'" + dataRow["deptid_chr"].ToString() + "',";
                    this.LstDeptID.Add(dataRow["deptid_chr"].ToString() + "|" + dataRow["deptname_vchr"].ToString());
                    this.LstDeptName.Add(dataRow["deptname_vchr"].ToString());
                }
            }
            if (this.deptidarr == "")
            {
                MessageBox.Show("请从列表中选择统计科室/病区。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.deptidarr = this.deptidarr.Substring(0, this.deptidarr.Length - 1);
                base.DialogResult = DialogResult.OK;
            }
            this.DeptIDArr = this.deptidarr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
