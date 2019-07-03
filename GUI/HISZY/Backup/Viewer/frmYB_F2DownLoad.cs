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
    /// 2006年度医保病人处理UI
    /// </summary>
    public partial class frmYB_F2DownLoad : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmYB_F2DownLoad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 1 下载 2 删除 3 上传
        /// </summary>
        internal int DoType = 0;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rdoDownLoad.Checked)
            {
                this.DoType = 1;
            }
            else if (rdoDel.Checked)
            {
                this.DoType = 2;
            }
            else if (rdoUpLoad.Checked)
            {
                this.DoType = 3;
            }
            else
            {
                MessageBox.Show("请选择操作类型.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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