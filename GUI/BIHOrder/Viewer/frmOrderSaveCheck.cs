using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
    ///  医嘱上限判断	界面表示层
	/// 作者：  
	/// 创建时间： 2006-4-6
	/// </summary>
    public partial class frmOrderSaveCheck : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 待验证的诊疗项目
        /// </summary>
        public DataTable m_dtTable = new DataTable();
        public string m_strMessage = "";

        public frmOrderSaveCheck()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderSaveCheck();
            objController.Set_GUI_Apperance(this);
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            ((clsCtl_OrderSaveCheck)this.objController).ConfirmMaxValue();
            
           
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmOrderSaveCheck_Load(object sender, EventArgs e)
        {
            string m_strtip = "";
            m_strtip = "提示：当前列表中的项目费额过大　\r\n需有更高一级权限的用户核对!";
            this.m_txtBackReason.Text = m_strtip;
            this.m_lbltip.Text = this.m_strMessage;
            ((clsCtl_OrderSaveCheck)this.objController).LoadtoList();
            
            m_txtEMPNO_CHR.Focus();
          

        }

        private void frmOrderSaveCheck_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    m_cmdCancel_Click(sender, e);
                    break;
                case Keys.F1:
                    m_cmdOK_Click(sender, e);
                    break;
            

            }
        }

       

       
       
        private void m_txtEMPNO_CHR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void m_txtPSW_CHR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void m_txtEMPNO_CHR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}