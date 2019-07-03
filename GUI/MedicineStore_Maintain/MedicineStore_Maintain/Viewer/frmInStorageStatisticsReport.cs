using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 入库统计报表
    /// </summary>
    public partial class frmInStorageStatisticsReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 仓库名称
        /// </summary>
        internal string m_strStorageName = string.Empty;

        /// <summary>
        /// 报表文件名称
        /// </summary>
        internal string m_strReportName = string.Empty;
        
        /// <summary>
        /// 入库统计报表
        /// </summary>
        public frmInStorageStatisticsReport()
        {
            InitializeComponent();
            m_dtpBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            m_dtpEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
           
            this.m_dwcData.LibraryList = clsPublic.PBLPath;
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_InStorageStatisticsReport();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID,string p_strReportName)
        {
            m_strStorageID = p_strStorageID;
            m_strReportName = p_strReportName;

            this.Show();
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_InStorageStatisticsReport)objController).m_mthStatistics();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InStorageStatisticsReport)objController).m_mthShowVendor(m_txtVendor.Text);
            }
        }

        private void frmInStorageStatisticsReport_Load(object sender, EventArgs e)
        {
            ((clsCtl_InStorageStatisticsReport)objController).m_mthGetMedicineTypeSet();
            ((clsCtl_InStorageStatisticsReport)objController).m_mthSetStorageNameToReport();
            ((clsCtl_InStorageStatisticsReport)objController).m_mthSetStorageNameToFrm();
            m_dwcData.DataWindowObject = m_strReportName == ""?"ms_instoragestatisticsreport":"ms_instoragestatisticsreport_" + m_strReportName;
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(m_dwcData, true);
        }

        private void m_chkStatOut_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_txtVendor_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtVendor.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            ((clsCtl_InStorageStatisticsReport)objController).m_mthGetStoreroom();
            tvRoom.Visible = true;
            tvRoom.Focus();
        }

        private void tvRoom_Leave(object sender, EventArgs e)
        {
            tvRoom.Visible = false;
        }
    }
}