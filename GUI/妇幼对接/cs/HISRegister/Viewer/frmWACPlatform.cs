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
    /// 妇幼信息平台
    /// </summary>
    public partial class frmWACPlatform : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmWACPlatform()
        {
            InitializeComponent();
        }
        #endregion

        #region override

        ctl_WACPlatform ControllerWACP { get; set; }

        /// <summary>
        /// CreateController
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.ctl_WACPlatform();
            objController.Set_GUI_Apperance(this);
            ControllerWACP = this.objController as ctl_WACPlatform;
        }
        #endregion

        #region 事件

        private void frmWACPlatform_Load(object sender, EventArgs e)
        {
            ControllerWACP.Init();
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControllerWACP.FindPatient();
            }
        }

        private void tsbRecord_Click(object sender, EventArgs e)
        {
            ControllerWACP.Record();
        }

        private void tsbMeas_Click(object sender, EventArgs e)
        {
            ControllerWACP.Measurement();
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            ControllerWACP.Query();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            ControllerWACP.Print();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

    }
}
