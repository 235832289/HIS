using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药库总帐
    /// </summary>
    public partial class frmTotalAccoutReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        internal string m_strLastStorageID = string.Empty;
        public clsMS_AccountPeriodVO AccouVO = new clsMS_AccountPeriodVO();
        /// <summary>
        /// 药库总帐
        /// </summary>
        public frmTotalAccoutReport()
        {
            InitializeComponent();
            datWindow.LibraryList = clsPublic.PBLPath;
        }
        public override void CreateController()
        {
            this.objController = new clsCtl_TotalAccountReport();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            m_bgwGetIDList.RunWorkerAsync();
            this.Show();
        }

        private void m_cmdShowAccountDate_Click(object sender, EventArgs e)
        {
            if (m_lsvAccountIDList.Items.Count > 0)
            {
                m_lsvAccountIDList.Visible = true;
                m_lsvAccountIDList.Focus();
            }
        }

        private void m_txtAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_lsvAccountIDList.Items.Count > 0)
                {
                    m_lsvAccountIDList.Visible = true;
                }
            }
        }
        private void m_lsvAccountIDList_Leave(object sender, EventArgs e)
        {
            m_lsvAccountIDList.Visible = false;
        }

        private void m_bgwGetIDList_DoWork(object sender, DoWorkEventArgs e)
        {
                clsMS_AccountPeriodVO[] objAccArr = null;
            ((clsCtl_TotalAccountReport)objController).m_mthGetAccountIDList(out objAccArr);
            e.Result = objAccArr;
        }

        private void m_bgwGetIDList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clsMS_AccountPeriodVO[] objAccArr = e.Result as clsMS_AccountPeriodVO[];
            ((clsCtl_TotalAccountReport)objController).m_mthSetAccountPeriodToList(objAccArr);
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_lsvAccountIDList_MouseUp(object sender, MouseEventArgs e)
        {
            int lsvItemIndex =-1;
            if (this.m_lsvAccountIDList.SelectedItems.Count > 0)
            {
                lsvItemIndex = this.m_lsvAccountIDList.SelectedItems[0].Index;
            }

            if (lsvItemIndex == -1)
            {
                return;
            }

            AccouVO = (clsMS_AccountPeriodVO)m_lsvAccountIDList.Items[lsvItemIndex].Tag;
            if (lsvItemIndex > 0)
            {
                clsMS_AccountPeriodVO lasAccouVO = new clsMS_AccountPeriodVO();
                lasAccouVO = (clsMS_AccountPeriodVO)m_lsvAccountIDList.Items[lsvItemIndex-1].Tag;
                m_strLastStorageID = lasAccouVO.m_strACCOUNTID_CHR;
            }
            else
            {
                m_strLastStorageID = null;
            }
            m_txtAccountID.Text = AccouVO.m_strACCOUNTID_CHR;
            m_lblAccountTime.Text = AccouVO.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss") + " ~ " + AccouVO.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_lblAccountTime.Visible = true;
            m_lsvAccountIDList.Visible = false;
            ((clsCtl_TotalAccountReport)objController).m_mthGetTotalAccount_Divide();
        }

        private void frmTotalAccoutReport_Load(object sender, EventArgs e)
        {

        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
        }
    }
}