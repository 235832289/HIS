using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore_Maintain;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药库报废统计报表
    /// </summary>
    public partial class frmRejectStorageReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 医院代号（lj＝伦教）
        /// </summary>
        public string p_strReportName;
        /// <summary>
        /// 药库名称
        /// </summary>
        public string p_strStorageName;
        internal DataTable dtbResult = null;
        /// <summary>
        /// 药库ID
        /// </summary>
        public string m_strStorageID = string.Empty;

        #endregion

        #region 构造函数
        /// <summary>
        /// 药库报废统计报表
        /// </summary>
        public frmRejectStorageReport()
        {
            InitializeComponent();
            txtOutStorageBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            txtOutStorageEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            this.dwOutStorageStat.LibraryList = clsPublic.PBLPath;
        }
        #endregion

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_RejectStorageReport();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="strStorageID">仓库ID</param>
        /// <param name="m_strReportName">报表文件名称</param>
        public void ShowWindow(string strStorageID,string m_strReportName)
        {            
            m_strStorageID = strStorageID;
            p_strReportName = m_strReportName;            
            this.Show();
        }
        #endregion

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        private void frmRejectStorageReport_Load(object sender, EventArgs e)
        {
            ((clsCtl_RejectStorageReport)objController).m_mthGetMedicineTypeSet();
            ((clsCtl_RejectStorageReport)objController).m_mthSetStorageNameToReport();
            ((clsCtl_RejectStorageReport)objController).m_mthSetStorageNameToFrm();
            dwOutStorageStat.DataWindowObject = "rejectstoragereport_" + p_strReportName;
            dwOutStorageStat.Modify("Destroy Column vendorname_vchr");
            dwOutStorageStat.Modify("Destroy Column vendorid_chr");
            dwOutStorageStat.PrintProperties.Prompt = true;
        }
        #endregion       

        #region 统计按钮
        /// <summary>
        /// 统计按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStat_Click(object sender, EventArgs e)
        {
            try
            {       
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_RejectStorageReport)objController).m_mthStatistics();
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
        #endregion

        #region 是否预览
        /// <summary>
        /// 是否预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {      
            dwOutStorageStat.PrintProperties.Preview = chkPreview.Checked;
            dwOutStorageStat.PrintProperties.ShowPreviewRulers = true;//显示预览标尺
            dwOutStorageStat.PrintProperties.PreviewZoom=100;//缩放比例

        }
        #endregion

        #region 打印按钮
        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                dwOutStorageStat.Print();
            }
            catch
            {
            }
        }
        #endregion

        #region 实现按回车键移动焦点
        private void txtOutStorageBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    txtOutStorageEndDate.Focus();
                    break;
            }

        }

        private void txtOutStorageEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_cboType.Focus();
                    break;
            }

        }

        private void chkPreview_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    txtOutStorageBeginDate.Focus();
                    break;
            }

        }

        #endregion       
    }
}