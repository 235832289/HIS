using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmLeftCallBack : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        internal bool m_cancle = false;

        public frmLeftCallBack()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlLeftCallBack();
            objController.Set_GUI_Apperance(this);
        }

        private void frmLeftCallBack_Load(object sender, EventArgs e)
        {
            ((clsCtlLeftCallBack)this.objController).FindPatient();
        }

        private void m_cmdRecall_Click(object sender, EventArgs e)
        {
            ((clsCtlLeftCallBack)this.objController).LeftCallBack();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeftCallBack_Layout(object sender, LayoutEventArgs e)
        {
            if(m_cancle)
                this.Close();
            
        }

        private void m_cmdFind_Click(object sender, EventArgs e)
        {
            ((clsCtlLeftCallBack)this.objController).FindPatient();
        }

        private void frmLeftCallBack_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void m_ucPatientInfo_ZyhChanged()
        {

        }
    }
}