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
    public partial class frmSamplePack : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmSamplePack()
        {
            InitializeComponent();
        }

        ctlSamplePack ControllerPack { get; set; }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.ctlSamplePack();
            ControllerPack = (ctlSamplePack)objController;
            this.objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 外部接口

        /// <summary>
        /// 0 体检打包; 1 住院打包
        /// </summary>
        internal decimal BizType { get; set; }

        /// <summary>
        /// 外部调用
        /// </summary>
        /// <param name="bizType"></param>
        public void Show2(string bizType)
        {
            this.BizType = Convert.ToDecimal(bizType);
            this.Show();
            if (bizType == "1")
            {
                this.Text += " - 住院打包";
            }
            else if (bizType == "0")
            {
                this.Text += " - 体检打包";
            }
            else
            {
                this.Text += " - 体检打包";
            }
        }
        #endregion

        #region 事件

        private void frmPack_Load(object sender, EventArgs e)
        {
            ControllerPack.Init();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControllerPack.AddSimple();
            }
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            ControllerPack.Query();
        }

        private void tsbNewPack_Click(object sender, EventArgs e)
        {
            ControllerPack.NewPack();
        }

        private void tsbDelSimple_Click(object sender, EventArgs e)
        {
            ControllerPack.DelSimple();
        }

        private void tsbDelAll_Click(object sender, EventArgs e)
        {
            ControllerPack.DelSimpleAll();
        }

        private void tsbTempSave_Click(object sender, EventArgs e)
        {
            ControllerPack.CompletePack(0, true);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            ControllerPack.CompletePack(1, true);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
