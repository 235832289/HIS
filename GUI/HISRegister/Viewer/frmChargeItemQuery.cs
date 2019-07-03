using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 收费项目查询
    /// </summary>
    public partial class frmChargeItemQuery :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmChargeItemQuery()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControlChargeItemQuery();
            objController.Set_GUI_Apperance(this);
        }
        private void frmChargeItemQuery_Load(object sender, EventArgs e)
        {
            ((clsControlChargeItemQuery)this.objController).m_mthLoadData();
        }
        public string strPopedom = "";
        public void m_mthShow(string p_strPopedom)
        {

            strPopedom = p_strPopedom.Trim();
            this.Show();
        }

        internal void m_cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsControlChargeItemQuery)this.objController).m_mthFindChargeItem(this.m_cmbType.SelectItemValue.Trim(), "", "");
        }

        private void m_cmbFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsControlChargeItemQuery)this.objController).m_cmbFind_SelectedIndexChanged();
        }

        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            ((clsControlChargeItemQuery)this.objController).m_mthFindChargeItem(this.m_cmbType.SelectItemValue.Trim(), "", "");
        }

        private void m_dtgChargeItem_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            ((clsControlChargeItemQuery)this.objController).m_mthDataGridCellChange();
            
        }

        private void m_btFind_Click(object sender, EventArgs e)
        {
            this.m_txtFind.m_mthAddItem();
            if (this.m_txtFind.Items.Count > 0)
            {
                this.m_txtFind.Text = this.m_txtFind.Items[0].ToString();
            }
            ((clsControlChargeItemQuery)this.objController).m_mthFindChargeItem(this.m_cmbType.SelectItemValue.Trim(), m_cmbFind.Tag.ToString(), m_txtFind.Text);					
        }

        private void btEditDiscount_Click(object sender, EventArgs e)
        {
            if (this.btSave.Tag != null)//修改
            {
                frmSingleItemDiscount objfrm = new frmSingleItemDiscount();
                objfrm.btOK.Visible = false;
                objfrm.Text += " ─" + this.m_txtName.Text.Trim();
                objfrm.strItemID = this.btSave.Tag.ToString().Trim();
                objfrm.ShowDialog();
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            frmSUBCHARGEITEM frmshow = new frmSUBCHARGEITEM((string)this.btSave.Tag, m_txtName.Text);
            frmshow.buttonXP1.Visible = false;
            frmshow.m_cmdSynOrderDic.Visible = false;
            frmshow.m_btndeleteDetail.Visible = false;
            frmshow.ShowDialog();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            ((clsControlChargeItemQuery)this.objController).m_mthPrintChargeItem();
        }

        private void btPrice_Click(object sender, EventArgs e)
        {
            this.m_mthShowPriceInfo();
        }
        private void m_mthShowPriceInfo()
        {
            if (this.btSave.Tag == null)
            {
                return;
            }
            frmChangePriceInfo frmObj = new frmChangePriceInfo();
            frmObj.ItemCode = this.m_txtNo.Text;
            frmObj.ItemID = this.btSave.Tag.ToString();
            frmObj.ItemName = this.m_txtName.Text;
            frmObj.ItemPrice = this.m_txtPrice.Text;
            frmObj.ShowDialog();
        }

    }
}