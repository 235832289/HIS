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
    public partial class frmAreaPutMedList : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public string m_strAreaID = "";
        public frmAreaPutMedList()
        {
            InitializeComponent();
        }

        public frmAreaPutMedList(string AreaID)
        {
            m_strAreaID = AreaID;
            InitializeComponent();
        }

        private void frmAreaPutMedList_Load(object sender, EventArgs e)
        {
            ((clsCtl_AreaPutMedList)this.objController).IniTheForm();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_AreaPutMedList();
            objController.Set_GUI_Apperance(this);
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdClearComfirm_Click(object sender, EventArgs e)
        {
            ((clsCtl_AreaPutMedList)this.objController).ClearComfirm();
        }

        private void m_cmdSetAreaComfirm_Click(object sender, EventArgs e)
        {
            ((clsCtl_AreaPutMedList)this.objController).SetAreaComfirm();
        }

        private void frmAreaPutMedList_KeyDown(object sender, KeyEventArgs e)
        {
            #region 快捷键
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    buttonXP2_Click(null, null);
                    break;
            }
          
            #endregion
        }
    }
}