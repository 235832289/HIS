using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品价格查询
    /// </summary>
    public partial class frmQueryMedicinePrice : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        //private DataTable m_objTable = null;
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsCtl_QueryMedicinePrice();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmQueryMedicinePrice()
        {
            InitializeComponent();
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQueryMedicinePrice_Load(object sender, EventArgs e)
        {
            this.m_dgvMedPrice.AutoGenerateColumns = false;
            this.m_dtpBeginDat.Text = clsPublic.SysDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpEndDat.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            ((clsCtl_QueryMedicinePrice)objController).m_mthInitdw();           
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            if (m_txtMedicineName.Text == "")
            {
                this.dw.Reset();
                this.dw.Refresh();
                this.dw.InsertRow(0);
                MessageBox.Show("请选择药品名称", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtMedicineName.Focus();
                //SendKeys.Send("{Enter}");
                return;
            }

            ((clsCtl_QueryMedicinePrice)objController).m_mthQuery();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.dw);
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryMedicinePrice)objController).m_mthPrint();
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryMedicinePrice)objController).m_mthExcel();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 方法
        private void m_mthEnterToTab(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {               
                ((clsCtl_QueryMedicinePrice)objController).m_mthShowMedName(this.m_txtMedicineName.Text.Trim());
            }
        }
        #endregion
    }
}