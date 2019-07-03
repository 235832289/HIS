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
    /// 出库明细报表
    /// </summary>
    public partial class frmOutStorageDetailReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null; 
        #endregion

        /// <summary>
        /// 出库明细报表
        /// </summary>
        public frmOutStorageDetailReport()
        {
            InitializeComponent();

            m_dtpSearchBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strReportName">报表名称</param>
        public void m_mthShow(string p_strStorageID,string p_strReportName)
        {
            m_strStorageID = p_strStorageID;
            datWindow.DataWindowObject = p_strReportName == "" ? "ms_outstoragedetail" : "ms_outstoragedetail_" + p_strReportName;
            m_bgwGetMedicine.RunWorkerAsync();

            DataTable dtbDept = null;
            ((clsCtl_OutStorageDetailReport)objController).m_mthGetExportDept(out dtbDept);
            m_txtExportDept.m_mthInitDeptData(dtbDept);

            this.Show();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_OutStorageDetailReport();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorageDetailReport)objController).m_mthGetReport();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPring = new clsCtl_Public();
            clsPring.ChoosePrintDialog(datWindow,true);
        }

        private void m_bgwGetMedicine_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_OutStorageDetailReport)objController).m_mthGetMedicineInfo();
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_OutStorageDetailReport)objController).m_mthShowQueryMedicineForm(m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_txtExportDept_FocusNextControl(object sender, EventArgs e)
        {
            m_txtMedicineCode.Focus();
        }

        private void frmOutStorageDetailReport_Load(object sender, EventArgs e)
        {

        }
    }
}