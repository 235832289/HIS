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
    /// 选择预交款类型弹出窗口
    /// </summary>
    public partial class frmPrePayType : Form
    {
        private string pretype = "";
        /// <summary>
        /// 预交类型： 0 正常 1 手工
        /// </summary>
        public string PreType
        {
            get
            {
                return pretype;
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public frmPrePayType()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdo1.Checked)
            {
                pretype = "0";
            }
            else if (rdo2.Checked)
            {
                pretype = "1";
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}