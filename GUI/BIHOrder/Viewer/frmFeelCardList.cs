using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;




namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmFeelCardList : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        
        public frmFeelCardList()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_FeelCardList();
            objController.Set_GUI_Apperance(this);
        }

        private void frmFeelCard_Load(object sender, EventArgs e)
        {
            m_txtArea.Text = LoginInfo.m_strInpatientAreaName;
            m_txtArea.Tag = LoginInfo.m_strInpatientAreaID;
            m_txtArea.Focus();

            ((clsCtl_FeelCardList)this.objController).LoadData();
        }

        

        private void m_cmdPrintFeel_Click(object sender, EventArgs e)
        {
            try
            {
                DWPrintPreview printPreview = new DWPrintPreview(dw_1);
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    dw_1.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    dw_1.Print(false, false);
                }
                //dw_1.PrintDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
            
        }

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_FeelCardList)this.objController).m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_FeelCardList)this.objController).m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            ((clsCtl_FeelCardList)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_FeelCardList)this.objController).m_cmdSearch();
        }

        private void dw_1_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFeelCardList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    cmdCancel_Click(null, null);
                    break;
                case Keys.F4:
                    cmdSearch_Click(null, null);
                    break;
            }
        }

      

    }
}