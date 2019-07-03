using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmYBBillInfoMZ : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBBillInfoMZ()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBBillInfoMZ();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmYBBillInfoMZ_Load(object sender, EventArgs e)
        {
            ((clsCtl_YBBillInfoMZ)this.objController).m_mthInit();
            this.dtpStart.Value = DateTime.Now;
            this.dtpEnd.Value = DateTime.Now;
            this.cboPatientType.SelectedIndex = 0;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBBillInfoMZ)this.objController).m_mthGetBillInfoMZ();
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_YBBillInfoMZ)this.objController).m_mthGetBillInfoMZ();
            }
        }

        private void frmYBBillInfoMZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("确定要关闭该界面吗？","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}