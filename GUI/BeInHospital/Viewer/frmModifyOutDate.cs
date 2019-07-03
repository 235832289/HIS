using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院信息
    /// </summary>
    public partial class frmModifyOutDate : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        internal bool m_cancle = false;

        #region 构造
        public frmModifyOutDate()
        {
            InitializeComponent();

            m_ucPatientInfo.Status = 2;
        }
        #endregion

        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlModifyOutDate();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_ucPatientInfo_ZyhChanged()
        {
            //this.m_objViewer.cmdCancle.Enabled = true;
            ((clsCtlModifyOutDate)this.objController).GetPatientPreLeaveInfo();
        }

        private void m_ucPatientInfo_CardNOChanged()
        {
            //this.m_objViewer.cmdCancle.Enabled = true;
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            ((clsCtlModifyOutDate)this.objController).SavePreLeaveInfo();
        }
    }
}