using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class DotorComfirmBox : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        clsCtl_OrderSaveCheck clsCtl_confirm;
        public string empid_chr="";
        public string lastname_vchr = "";
          
        public DotorComfirmBox()
        {
            InitializeComponent();
            clsCtl_confirm = new clsCtl_OrderSaveCheck();
        }
        public override void CreateController()
        {
        //    this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderSaveCheck();
        //    objController.Set_GUI_Apperance(this);
        }
        private void cmdSaveBihRegister_Click(object sender, EventArgs e)
        {
            string EMPNO_CHR="";
            string PSW_CHR="";
            EMPNO_CHR = this.m_txtName.Text.Trim();
            PSW_CHR = this.m_txtPassword.Text.Trim();
            DataTable dtbResult;
            if (clsCtl_confirm.ConfirmPassWork(EMPNO_CHR, PSW_CHR,out dtbResult) == true)
            {
                if(dtbResult.Rows.Count<=0)
                { 
                MessageBox.Show("确认失败，当前工号/密码不对！");
                this.m_txtPassword.Focus();
                    return;
                }
                empid_chr=dtbResult.Rows[0]["empid_chr"].ToString().Trim();
                lastname_vchr = dtbResult.Rows[0]["lastname_vchr"].ToString().Trim();
                this.DialogResult = DialogResult.OK;

                //this.Hide();
            }
            else
            {
                MessageBox.Show("确认失败，当前工号/密码不对！");
                this.m_txtPassword.Focus();
            }
            
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_txtName.Text.ToString().Trim().Equals(""))
                {
                    this.m_txtName.Focus();
                }
                else
                {
                    this.m_txtPassword.Focus();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmdSaveBihRegister.Focus();
            }
        }

        private void DotorComfirmBox_Load(object sender, EventArgs e)
        {
           this.m_txtName.Focus();
           SendKeys.Send("{Enter}");
        }

        private void DotorComfirmBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    buttonXP1_Click(null, null);
                    break;
            }
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        cmdSaveBihRegister_Click(null, null);
                        break;
                }
                      
            }
        }
    }
}