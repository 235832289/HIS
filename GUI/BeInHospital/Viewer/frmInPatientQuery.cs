using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmInPatientQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 
        /// </summary>
        public frmInPatientQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_InPatientQuery();
            objController.Set_GUI_Apperance(this);
        }

        private void frmInPatientQuery_Load(object sender, EventArgs e)
        {
            //初始化下拉框
            ((clsCtl_InPatientQuery)this.objController).InitializationComboBox();
            txtINPatient1.Focus();
           
        }

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion
        #region 载入门诊医生信息
        private void m_txtPatientDoctor_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtPatientDoctorFindItem(strFindCode, lvwList);
        }

        private void m_txtPatientDoctor_m_evtInitListView(ListView lvwList)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtPatientDoctorInitListView(lvwList);
        }

        private void m_txtPatientDoctor_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtPatientDoctorSelectItem(lviSelected);
        }
        #endregion

        private void m_cbInPatientDate_CheckedChanged(object sender, EventArgs e)
        {
            this.m_dtpBeginDate.Enabled = this.m_cbInPatientDate.Checked;
            this.m_dtpEndDate.Enabled = this.m_cbInPatientDate.Checked;
        }

        #region 特注信息
        private void m_txtSPECREMARK_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtSPECREMARKFindItem(strFindCode, lvwList);
        }

        private void m_txtSPECREMARK_m_evtInitListView(ListView lvwList)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtSPECREMARKInitListView(lvwList);
        }

        private void cm_txtSPECREMARK_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            ((clsCtl_InPatientQuery)this.objController).m_txtSPECREMARKSelectItem(lviSelected);
        }
        #endregion

       

        public void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_InPatientQuery)this.objController).m_lngGetPatientByCondition();
            txtINPatient1.Focus();
        }

        private void m_txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            ((clsCtl_InPatientQuery)this.objController).IniAllControl();
            txtINPatient1.Focus();
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            ((clsCtl_InPatientQuery)this.objController).m_lngGetPatientByCondition();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            ((clsCtl_InPatientQuery)this.objController).ViewTheDataWindow();
        }

        private void frmInPatientQuery_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                #region 快捷键
                case Keys.Escape:
                    buttonXP3_Click(null, null);
                    break;
               
                #endregion
            }
            if (e.Modifiers == Keys.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.F:
                        m_cmdQuery_Click(null, null);
                        break;
                    case Keys.C:
                        m_cmdClear_Click(null, null);
                        break;
                    case Keys.P:
                        m_cmdCancel_Click(null, null);
                        break;

                }
            }
        }

        private void txtINPatient1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(txtINPatient1.Name);
            }
        }

        private void txtPatientName1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(txtPatientName1.Name);
            }
        }

        private void m_cboSTATE_INT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(m_cboSTATE_INT2.Name);
            }
        }

        private void m_cboPSTATUS_INT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(m_cboPSTATUS_INT.Name);
            }
        }

        private void cobPaytypeid2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(cobPaytypeid2.Name);
            }
        }

        private void m_cbInPatientDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(m_cbInPatientDate.Name);
            }
        }

        private void m_dtpBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(m_dtpBeginDate.Name);
            }
        }

        private void m_dtpEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InPatientQuery)this.objController).setTheControlOrder(m_dtpEndDate.Name);
            }
        }
    }
}