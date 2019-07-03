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
    /// 社保病人类型UI
    /// </summary>
    public partial class frmYBType : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmYBType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 1 旧病人(2006) 2 新病人(2007) 3 删除已传数据
        /// </summary>
        internal int YBType = 0;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rdoOld.Checked)
            {
                this.YBType = 1;
            }
            else if (rdoNew.Checked)
            {
                this.YBType = 2;
            }
            else if (rdoComplete.Checked)
            {
                this.YBType = 3;
            }
            else if (rdoDel.Checked)
            {
                this.YBType = 4;
            }
            else
            {
                MessageBox.Show("请选择社保病人类型.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}