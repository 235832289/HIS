using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmLisWorkloadCount : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmLisWorkloadCount()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsCtl_WorkloadCount m_objController;
        public string DeptIdArr = string.Empty;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.clsCtl_WorkloadCount();
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion


        private void frmLisWorkloadCount_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInit();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            m_objController.m_mthGetWorkLoadCount();
        }
    }

}
