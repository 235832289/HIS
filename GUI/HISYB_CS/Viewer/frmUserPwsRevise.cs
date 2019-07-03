using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmUserPwsRevise :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private int intThisPtr = 0;

        public frmUserPwsRevise()//(int intPtr)
        {
            //intThisPtr = intPtr;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lblykl.Text = "";
            lblxkl.Text = "";
            lblqrxkl.Text = "";
            string strOldPwd = this.txtpws.Text.Trim();
            string strNewPwd = this.txtNewpws.Text.Trim();
            string strNewPwd1 = this.txtCfNewpws.Text.Trim();
            bool blUserType = this.cmb_UserType.SelectedIndex==1;//判断是否住院部编号
            string strUserType="711014";//门诊部编号
            if (blUserType)
            {
                strUserType = "111014";
            }
            if (string.IsNullOrEmpty(strOldPwd))
            {
                lblykl.Text = "不能为空！";
                return;
            }
            else if (string.IsNullOrEmpty(strNewPwd))
            {
                lblxkl.Text = "不能为空！";
                return;
            }
            else if (string.IsNullOrEmpty(strNewPwd1))
            {
                lblqrxkl.Text = "不能为空！";
                return;
            }
            else if (!strNewPwd.Equals(strNewPwd1))
            {
                lblqrxkl.Text = "两次输入不一致！";
                return;
            }
            else
            {
                if (clsYBPublic_cs.m_lngUserPwsRevise(intThisPtr,strUserType, strOldPwd, strNewPwd) > 0)
                {
                    clsDcl_YB clsDclYB=new clsDcl_YB();
                    clsDclYB.m_lngHospitalUserLogin(strNewPwd, strUserType);
                    MessageBox.Show("密码修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close();
                }
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpws_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtNewpws.Focus();
            }
        }

        private void txtNewpws_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtCfNewpws.Focus();
            }
        }

        private void txtCfNewpws_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnOK.Focus();
            }
        }

    }
}