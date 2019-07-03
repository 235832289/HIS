using System;
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
    public partial class frmAidChooseDoct : Form
    {
        #region 变量
        /// <summary>
        /// 医生ID串(格式 '0001','0002','0003')
        /// </summary>
        private string doctidarr = "";
        /// <summary>
        /// 医生ID串(格式 '0001','0002','0003')
        /// </summary>
        public string DoctIDArr
        {
            get
            {
                return doctidarr;
            }
        }

        /// <summary>
        /// 0 全部; 1 医生; 3 抗菌药会诊专家
        /// </summary>
        public int EmpTypeId { get; set; }

        #endregion

        /// <summary>
        /// 构造

        /// </summary>
        public frmAidChooseDoct()
        {
            InitializeComponent();
        }

        private void frmAidChooseDoct_Load(object sender, EventArgs e)
        {
            long l = 0;
            clsDcl_Charge objCharge = new clsDcl_Charge();
            DataTable dt;
            if (EmpTypeId > 0)
            {
                l = objCharge.m_lngGetEmployee(out dt, EmpTypeId);
            }
            else
            {
                l = objCharge.m_lngGetEmployee(out dt);
            }
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] sarr = new string[4];

                    sarr[0] = "F";
                    sarr[1] = Convert.ToString(i + 1);
                    sarr[2] = dr["empno_chr"].ToString().Trim();
                    sarr[3] = dr["lastname_vchr"].ToString().Trim();

                    int row = this.dtDoct.Rows.Add(sarr);
                    this.dtDoct.Rows[row].Tag = dr;
                }
            }

            this.txtVal.Focus();
        }

        private void frmAidChooseDoct_KeyDown(object sender, KeyEventArgs e)
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
                    for (int i = 0; i < this.dtDoct.Rows.Count; i++)
                    {
                        if (this.dtDoct.Rows[i].Cells["colGh"].Value.ToString().Contains(val) || this.dtDoct.Rows[i].Cells["colXm"].Value.ToString().Contains(val))
                        {
                            this.dtDoct.CurrentCell = this.dtDoct.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            doctidarr = "";

            if (this.chkAll.Checked)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                for (int i = 0; i < this.dtDoct.Rows.Count; i++)
                {
                    if (this.dtDoct.Rows[i].Cells["colZt"].Value.ToString().Trim() == "T")
                    {
                        DataRow dr = this.dtDoct.Rows[i].Tag as DataRow;
                        doctidarr += "'" + dr["empid_chr"].ToString() + "',";
                    }
                }

                if (doctidarr == "")
                {
                    MessageBox.Show("请从列表中选择统计医生。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    doctidarr = doctidarr.Substring(0, doctidarr.Length - 1);
                    this.DialogResult = DialogResult.OK;
                }
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
                for (int i = 0; i < this.dtDoct.Rows.Count; i++)
                {
                    this.dtDoct.Rows[i].Cells["colZt"].Value = "T";
                }
            }
            else
            {
                for (int i = 0; i < this.dtDoct.Rows.Count; i++)
                {
                    this.dtDoct.Rows[i].Cells["colZt"].Value = "F";
                }
            }
        }
    }
}