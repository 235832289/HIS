using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmMK3DeviceCommunications :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 仪器通讯控制层
        /// </summary>
        clsCtl_MK3DeviceCommunications m_objController;
        internal string m_strCheckItemID = null;
        #endregion

        #region 创建控制层
        public override void CreateController()
        {
            m_objController = new clsCtl_MK3DeviceCommunications();
            m_objController.Set_GUI_Apperance(this);
            objController = m_objController;
        }
        #endregion

        #region 构造函数
        public frmMK3DeviceCommunications(string strCheckItemID)
        {
            InitializeComponent();
            m_strCheckItemID = strCheckItemID;
        }
        #endregion

        private void frmMK3DeviceCommunications_Load(object sender, EventArgs e)
        {
            m_objController.m_mthGetCheckItemCustomOrder();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_objController.m_mthOperationCheckItemCustomOrder();
        }

        private void m_blnDelete_Click(object sender, EventArgs e)
        {
            m_objController.m_mthDeleteCheckItemCustomOrder();
        }
    }
}