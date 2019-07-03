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
    /// 收款人日结备注UI类
    /// </summary>
    public partial class frmDayReckoningRemark : Form
    {
        /// <summary>
        /// 备注信息
        /// </summary>
        private string remarkinfo = "";
        /// <summary>
        /// 备注信息
        /// </summary>
        public string RemarkInfo
        {
            get
            {
                return remarkinfo;
            }
            set
            {
                remarkinfo = value;
            }
        }
        /// <summary>
        /// 构造
        /// </summary>
        public frmDayReckoningRemark()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            remarkinfo = this.txtRemarkInfo.Text.Trim();

            //if (remarkinfo == "")
            //{
            //    MessageBox.Show("请输入备注信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //else
            //{
                this.DialogResult = DialogResult.Yes;
            //}
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDayReckoningRemark_Load(object sender, EventArgs e)
        {
            this.txtRemarkInfo.Text = this.remarkinfo;
        }

        private void frmDayReckoningRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }      

    }
}