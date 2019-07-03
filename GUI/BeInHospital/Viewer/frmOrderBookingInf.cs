using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOrderBookingInf : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        DataRowView m_drView;

        public frmOrderBookingInf()
        {
            InitializeComponent();
        }

        public frmOrderBookingInf(DataRowView p_drView)
        {
            InitializeComponent();

            this.m_drView = p_drView;
        }


        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsOrderBookingInf();
            objController.Set_GUI_Apperance(this);
        }

        private void frmBookingInf_Load(object sender, EventArgs e)
        {
           
            if (this.m_drView == null)
                return;
       
            ((clsOrderBookingInf)this.objController).initData(this.m_drView);

        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            ((clsOrderBookingInf)this.objController).UpdateOrderBooking();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_cmbStatus.SelectedIndex == 0)
            {
                this.m_dtpBookDate.Enabled = true;
                this.m_txtRemark.Enabled = true;
            }
            else
            {
                this.m_dtpBookDate.Enabled = false;
                this.m_txtRemark.Enabled = false;
            }
        }

        private void frmOrderBookingInf_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("确认退出么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
            }
        }
    }
}