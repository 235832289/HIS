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
    /// <summary>
    /// 病区检验报告单打印
    /// </summary>
    public partial class frmAreaPrint : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmAreaPrint()
        {
            InitializeComponent();
        }

        ctlAreaPrint ControllerAreaPrint { get; set; }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.ctlAreaPrint();
            ControllerAreaPrint = (ctlAreaPrint)objController;
            this.objController.Set_GUI_Apperance(this);
        }

        #endregion

        #region 事件

        private void frmAreaPrint_Load(object sender, EventArgs e)
        {
            ControllerAreaPrint.Init();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            ControllerAreaPrint.ChooseDepts();
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            ControllerAreaPrint.Query();
        }

        private void tsbiCheck_Click(object sender, EventArgs e)
        {
            ControllerAreaPrint.Choose();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            ControllerAreaPrint.Print();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
