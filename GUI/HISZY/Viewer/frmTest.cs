using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        public decimal SbMney { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            decimal decSb = 0;
            decimal.TryParse(this.txtSbmny.Text, out decSb);
            if (decSb == 0)
            {
                MessageBox.Show("社保优惠金额不能为 0", "提示");
                return;
            }
            this.SbMney = decSb;
            this.DialogResult = DialogResult.OK;
        }
    }
}
