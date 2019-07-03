using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 选择医生
    /// </summary>
    public partial class frmAidChooseDept : Form
    {
        #region 变量
        /// <summary>
        /// 科室(病区)ID串(格式 '0001','0002','0003')
        /// </summary>
        private string deptidarr = "";
        /// <summary>
        /// 科室(病区)ID串(格式 '0001','0002','0003')
        /// </summary>
        public string DeptIDArr
        {
            get
            {
                return deptidarr;
            }
        }

        public List<string> LstDeptID
        {
            get;
            set;
        }
        public List<string> LstDeptName
        {
            get;
            set;
        }
        /// <summary>
        /// 限制级科室ID数组
        /// </summary>
        private ArrayList LimitDeptIDArr = new ArrayList();
        
        public int DeptFlag = 1;

        #endregion

        /// <summary>
        /// 构造

        /// </summary>
        public frmAidChooseDept()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造

        /// </summary>
        public frmAidChooseDept(ArrayList p_DeptIDArr)
        {
            InitializeComponent();
            LimitDeptIDArr = p_DeptIDArr;
        }

        private void frmAidChooseDept_Load(object sender, EventArgs e)
        {
            this.LstDeptID = new List<string>();
            this.LstDeptName = new List<string>();
            clsDcl_Charge objCharge = new clsDcl_Charge();
            DataTable dt;
            long l = objCharge.m_lngGetDeptArea(out dt, DeptFlag);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (LimitDeptIDArr.Count > 0)
                    {
                        if (LimitDeptIDArr.IndexOf(dr["deptid_chr"].ToString()) < 0)
                        {
                            continue;
                        }
                    }

                    string[] sarr = new string[4];

                    sarr[0] = "F";
                    sarr[1] = Convert.ToString(i + 1);
                    sarr[2] = dr["code_vchr"].ToString().Trim();
                    sarr[3] = dr["deptname_vchr"].ToString().Trim();

                    int row = this.dtDept.Rows.Add(sarr);
                    this.dtDept.Rows[row].Tag = dr;
                }
            }

            this.txtVal.Focus();
        }

        private void frmAidChooseDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string val = this.txtVal.Text.Trim();

                if (val == "")
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < this.dtDept.Rows.Count; i++)
                    {
                        if (this.dtDept.Rows[i].Cells["colDm"].Value.ToString().Contains(val) || this.dtDept.Rows[i].Cells["colKsmc"].Value.ToString().Contains(val))
                        {
                            this.dtDept.CurrentCell = this.dtDept.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            deptidarr = "";
            LstDeptID = new List<string>();
            for (int i = 0; i < this.dtDept.Rows.Count; i++)
            {
                if (this.dtDept.Rows[i].Cells["colZt"].Value.ToString().Trim() == "T")
                {
                    DataRow dr = this.dtDept.Rows[i].Tag as DataRow;
                    deptidarr += "'" + dr["deptid_chr"].ToString() + "',";
                    LstDeptID.Add(dr["deptid_chr"].ToString() + "|" + dr["deptname_vchr"].ToString());
                    LstDeptName.Add(dr["deptname_vchr"].ToString());
                }
            }

            if (deptidarr == "")
            {
                MessageBox.Show("请从列表中选择统计科室/病区。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                deptidarr = deptidarr.Substring(0, deptidarr.Length - 1);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}