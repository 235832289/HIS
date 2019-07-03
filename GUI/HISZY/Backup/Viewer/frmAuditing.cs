using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 通用审核窗
    /// </summary>
    public partial class frmAuditing : Form
    {
        /// <summary>
        /// 审核人ID
        /// </summary>
        private string Empid = "";
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string EmpID
        {
            get
            {
                return Empid;
            }
        }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        private string Empname = "";
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string EmpName
        {
            get
            {
                return Empname;
            }
        }

        private int intDefault = -1;
        /// <summary>
        /// 构造
        /// </summary>
        public frmAuditing()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造
        /// </summary>
        public frmAuditing(string p_strEmpNo)
        {
            InitializeComponent();
            this.txtEmpNo.Text = p_strEmpNo;
        }


        public frmAuditing(string p_strEmpNo, int DefaultFalg)
        {
            InitializeComponent();
            this.txtEmpNo.Text = p_strEmpNo;
            this.intDefault = DefaultFalg;
        }

        private void frmAuditing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string empno = this.txtEmpNo.Text.Trim();

                if (empno == "")
                {
                    return;
                }

                DataTable dt;
                clsDcl_PrePay objPre = new clsDcl_PrePay();
                long l = objPre.m_lngGetempinfo(out dt, empno);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    Empid = dt.Rows[0]["empid_chr"].ToString();
                    Empname = dt.Rows[0]["lastname_vchr"].ToString();
                    this.lblName.Text = Empname;

                    string userpwd = dt.Rows[0]["psw_chr"].ToString().Trim();
                    clsSymmetricAlgorithm objAlgorithm = new clsSymmetricAlgorithm();                 
                    this.txtPwd.Tag = objAlgorithm.m_strDecrypt(userpwd, clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES);
                    objAlgorithm = null;
                    this.txtPwd.Focus();
                }
                else
                {
                    MessageBox.Show("工号输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtEmpNo.Select();
                }                
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtPwd.Tag == null)
            {
                return;
            }

            if (this.txtPwd.Text.Trim() != this.txtPwd.Tag.ToString())
            {
                MessageBox.Show("密码输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPwd.Select();
                this.txtPwd.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmAuditing_Load(object sender, EventArgs e)
        {
            //if (this.intDefault == 2)
            if (this.txtEmpNo.Text.Trim() != "")
            {
                string empno = this.txtEmpNo.Text.Trim();

                if (empno == "")
                {
                    return;
                }

                DataTable dt;
                clsDcl_PrePay objPre = new clsDcl_PrePay();
                long l = objPre.m_lngGetempinfo(out dt, empno);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    Empid = dt.Rows[0]["empid_chr"].ToString();
                    Empname = dt.Rows[0]["lastname_vchr"].ToString();
                    this.lblName.Text = Empname;

                    string userpwd = dt.Rows[0]["psw_chr"].ToString().Trim();
                    clsSymmetricAlgorithm objAlgorithm = new clsSymmetricAlgorithm();
                    this.txtPwd.Tag = objAlgorithm.m_strDecrypt(userpwd, clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES);
                    objAlgorithm = null;
                    this.txtPwd.Focus();
                }
                else
                {
                    MessageBox.Show("工号输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
                if (this.intDefault == 2)
                {
                    this.txtEmpNo.Enabled = false;
                }
            }
            this.txtPwd.Focus();
            this.txtPwd.Select();
            //this.txtPwd.Focus();
        }
    }
}