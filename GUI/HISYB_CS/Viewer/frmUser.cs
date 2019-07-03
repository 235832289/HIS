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
    public partial class frmUser : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtUserId.Text))
            {
                MessageBox.Show("用户名不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (string.IsNullOrEmpty(this.txtpasw.Text))
            {
                MessageBox.Show("密码不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                long lngRes=clsYBPublic_cs.m_lngUserLoin(this.txtUserId.Text, this.txtpasw.Text, false);
                if (lngRes > 0)
                {
                    MessageBox.Show("登录成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close();
                }
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpasw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            this.txtpasw.Focus();

        }
    }
}