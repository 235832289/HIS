using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmItemsCorr : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmItemsCorr()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBItemsCorr();
            objController.Set_GUI_Apperance(this);
        }

        private void frmItemsCorr_Load(object sender, EventArgs e)
        {

        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_YBItemsCorr)this.objController).m_mthDisplayItmes();
        }

        private void lstYBItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstYBItems_Validated(object sender, EventArgs e)
        {
            if (lstYBItems.FocusedItem != null)
            {
                lstYBItems.FocusedItem.BackColor = SystemColors.Highlight;
                lstYBItems.FocusedItem.ForeColor = Color.White;
            }
        }

        private void lstYBItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.ForeColor = Color.Black;
            e.Item.BackColor = SystemColors.Window;
            if (this.lstYBItems.FocusedItem != null)
            {
                lstYBItems.FocusedItem.Selected = true;
            }
        }

        private void lstHospital_Validated(object sender, EventArgs e)
        {
            if (lstHospital.FocusedItem != null)
            {
                lstHospital.FocusedItem.BackColor = SystemColors.Highlight;
                lstHospital.FocusedItem.ForeColor = Color.White;
            }
        }

        private void lstHospital_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.ForeColor = Color.Black;
            e.Item.BackColor = SystemColors.Window;
            if (this.lstHospital.FocusedItem != null)
            {
                lstHospital.FocusedItem.Selected = true;
            }
        }

        private void btnsSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBItemsCorr)this.objController).m_mthSaveData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBItemsCorr)this.objController).m_mthDelData();
        }
    }
}