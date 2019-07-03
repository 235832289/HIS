using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmBatchSaveReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 控制层
        /// </summary>
        clsCtl_BatchSaveReport m_objController;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmBatchSaveReport()
        {
            InitializeComponent();
        }
        #endregion

        #region 创建控制层
        /// <summary>
        /// 创建控制层
        /// </summary>
        public override void CreateController()
        {
            m_objController = new clsCtl_BatchSaveReport();
            m_objController.Set_GUI_Apperance(this);
            objController = m_objController;
        }
        #endregion

        private void m_txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtCheckNo.Clear();
                m_objController.m_mthQueryAppInfo();
            }
        }

        private void m_btnSure_Click(object sender, EventArgs e)
        {
            m_objController.m_mthAddCheckNO();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_objController.m_mthBatchSave();
        }

       
    }
}