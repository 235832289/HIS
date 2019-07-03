using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPYB : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private frmOPCharge objfrm;

        public frmOPYB()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void m_Setform(frmOPCharge f)
        {
            objfrm = f;
        }

        private void btRecieve_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            objfrm.m_mthYBRead(this.ctlDataGrid1);
            this.btnOk.Enabled = objfrm.YBFlag;
            this.pic1.Visible = true;
            if (objfrm.YBFlag)
            {
                this.lblInfo.Text = "接收成功";
            }
            else
            {
                this.lblInfo.Text = "接收失败";
            }
            this.Cursor = Cursors.Default;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmOPYB_Load(object sender, EventArgs e)
        {
            this.pic1.Visible = false;
            this.lblInfo.Visible = false;
        }

        private void btnNewNo_Click(object sender, EventArgs e)
        {
            string BillNo = "";
            if (objfrm.m_blnModifyBillNo(out BillNo))
            {
                this.lblBillNO.Text = BillNo;
            }
        }
    }
}