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
    /// 选择费别
    /// </summary>
    public partial class frmAidChoosePayType : Form
    {
        #region 变量
        /// <summary>
        /// 费别ID串(格式 '0001','0002','0003')
        /// </summary>
        private string paytypeidarr = "";
        /// <summary>
        /// 费别ID串(格式 '0001','0002','0003')
        /// </summary>
        public string PayTypeIDArr
        {
            get
            {
                return paytypeidarr;
            }
        }
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmAidChoosePayType()
        {
            InitializeComponent();            
        }

        private void frmAidChoosePayType_Load(object sender, EventArgs e)
        {
            clsDcl_Charge objCharge = new clsDcl_Charge();
            DataTable dt;
            long l = objCharge.m_lngGetPayTypeInfo(out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] sarr = new string[4];

                    sarr[0] = "F";
                    sarr[1] = Convert.ToString(i + 1);
                    sarr[2] = dr["paytypeno_vchr"].ToString().Trim();
                    sarr[3] = dr["paytypename_vchr"].ToString().Trim();

                    int row = this.dtPayType.Rows.Add(sarr);
                    this.dtPayType.Rows[row].Tag = dr;
                }
            }

            this.txtVal.Focus();
        }

        private void frmAidChoosePayType_KeyDown(object sender, KeyEventArgs e)
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
                    for (int i = 0; i < this.dtPayType.Rows.Count; i++)
                    {
                        if (this.dtPayType.Rows[i].Cells["colBh"].Value.ToString().Contains(val) || this.dtPayType.Rows[i].Cells["colMc"].Value.ToString().Contains(val))
                        {
                            this.dtPayType.CurrentCell = this.dtPayType.Rows[i].Cells[0];
                            break;
                        }
                    }                   
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            paytypeidarr = "";
            for (int i = 0; i < this.dtPayType.Rows.Count; i++)
            {
                if (this.dtPayType.Rows[i].Cells["colZt"].Value.ToString().Trim() == "T")
                {
                    DataRow dr = this.dtPayType.Rows[i].Tag as DataRow;
                    paytypeidarr += "'" + dr["paytypeid_chr"].ToString() + "',";
                }
            }

            if (paytypeidarr == "")
            {
                MessageBox.Show("请从列表中选择费别。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                paytypeidarr = paytypeidarr.Substring(0, paytypeidarr.Length - 1);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }             
    }
}