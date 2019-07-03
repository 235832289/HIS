using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmStopOrderConfirm : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {

        internal string m_strRegisterID = "";
        public bool m_blStopControl = false;
        public bool m_blDeableMedControl = false;
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 住院基本配置表VO
        /// </summary>
        public clsSPECORDERCATE m_objSpecateVo;

        public frmStopOrderConfirm(string m_RegisterID)
        {
            InitializeComponent();
            m_strRegisterID = m_RegisterID;
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_StopOrderConfirm();
            objController.Set_GUI_Apperance(this);
        }

        private void frmStopOrderConfirm_Load(object sender, EventArgs e)
        {
            ((clsCtl_StopOrderConfirm)this.objController).LoadTheOrders(m_strRegisterID);
            
        }

        private void m_cmdRedraw_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdToCommit_Click(object sender, EventArgs e)
        {

        }

        private void m_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_dtvOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_StopOrderConfirm)this.objController).OrderListSelect();
        }

        private void m_cmdStop_Click(object sender, EventArgs e)
        {
            ((clsCtl_StopOrderConfirm)this.objController).OrderStop();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_StopOrderConfirm)this.objController).OrderDelete();
        }

        private void frmStopOrderConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            #region 快捷键



            switch (e.KeyCode)
            {
                case Keys.Escape:
                    m_cmdClose_Click(null, null);
                    break;
                case Keys.F5:
                    m_cmdStop_Click(null, null);
                    break;
                case Keys.F6:
                    m_btnDelete_Click(null, null);
                    break;
             
            }
           
            #endregion
        }

      
      
       

      
       
    }
}