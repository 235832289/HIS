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
    /// 药房退药确认窗口
    /// </summary>
    public partial class frmReturnMedConfirm : Form
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmReturnMedConfirm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 退药控制类
        /// </summary>
        internal clsControlReturnMedicine objControllReturnMed;
        /// <summary>
        /// 确认员工id
        /// </summary>
        internal string m_strEmpid;
        private void m_btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.m_txtConfirmid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请先输入确认人员工工号！");
                return;
            }
            if (this.objControllReturnMed.m_mthJudgeExistEmp(this.m_txtConfirmid.Text.Trim(), this.m_txtPwd.Text.Trim(),ref m_strEmpid))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("不存在相对应的员工工号和密码，请确认工号和密码是否正确！");
                return;
            }
        }

        private void m_txtConfirmid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}