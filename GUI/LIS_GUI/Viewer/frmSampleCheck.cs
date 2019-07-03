using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmSampleCheck : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmSampleCheck(int _bizType)
        {
            InitializeComponent();
            this.BizType = _bizType;
        }

        /// <summary>
        /// 0 体检核收; 1 住院核收
        /// </summary>
        internal int BizType { get; set; }

        ctlSampleCheck ControllerCheck { get; set; }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.ctlSampleCheck();
            ControllerCheck = (ctlSampleCheck)objController;
            this.objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 事件

        private void frmSampleCheck_Load(object sender, EventArgs e)
        {
            ControllerCheck.Init();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControllerCheck.CheckSample();
            }
        }

        #endregion
    }
}
