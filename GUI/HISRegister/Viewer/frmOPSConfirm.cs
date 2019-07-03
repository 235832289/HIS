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
    public partial class frmOPSConfirm : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private string empid = "";
        public string Empid
        {
            get
            {
                return empid;
            }
        }
        private string empno = "";
        private string empname = "";
        private string emppwd = "";
        private bool pass = false;

        public frmOPSConfirm()
        {
            InitializeComponent();
        }        

        private void frmOPSConfirm_Load(object sender, EventArgs e)
        {
            empid = this.LoginInfo.m_strEmpID;
            empno = this.LoginInfo.m_strEmpNo;
            empname = this.LoginInfo.m_strEmpName;
            
            DataTable dt = new DataTable();
            clsDcl_DoctorWorkstation objSvc = new clsDcl_DoctorWorkstation();
            long ret = objSvc.m_lngGetempinfo(out dt, empno);
            if(dt.Rows.Count == 1)
            {
                //emppwd = dt.Rows[0]["psw_chr"].ToString().Trim();
                clsSymmetricAlgorithm obj = new clsSymmetricAlgorithm();
                this.emppwd = obj.m_strDecrypt(dt.Rows[0]["psw_chr"].ToString().Trim(), clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES);
                pass = true;
            }

            this.txtGh.Text = empno;
            this.lblName.Text = "(姓名： " + empname + ")";
        }       

        private void txtGh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strempno = this.txtGh.Text.Trim();

                if (strempno == "")
                {
                    return;
                }

                DataTable dt = new DataTable();
                clsDcl_DoctorWorkstation objSvc = new clsDcl_DoctorWorkstation();
                long ret = objSvc.m_lngGetempinfo(out dt, strempno);
                if (dt.Rows.Count == 1)
                {
                    empid = dt.Rows[0]["empid_chr"].ToString();
                    empname = dt.Rows[0]["lastname_vchr"].ToString();
                    //emppwd = dt.Rows[0]["psw_chr"].ToString().Trim();
                    clsSymmetricAlgorithm obj = new clsSymmetricAlgorithm();
                    this.emppwd = obj.m_strDecrypt(dt.Rows[0]["psw_chr"].ToString().Trim(), clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES);

                    pass = true;
                    this.lblName.Text = "(姓名： " + empname + ")";
                    this.txtPwd.Focus();
                }
                else
                {
                    pass = false;
                    this.lblName.Text = "";
                    this.txtPwd.Text = "";
                    MessageBox.Show("工号输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtGh.Focus();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strPwd = this.txtPwd.Text.Trim();

            if (pass)
            {
                if (strPwd == emppwd)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("密码输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }
        }
    }
}