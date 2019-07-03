using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NullableDateControls;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 门诊药房发药工作量统计报表
    /// </summary>
    public partial class frmSendMedicineReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        private DataTable m_objTable = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmSendMedicineReport()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_Report_SendMedicine();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSendMedicineReport_Load(object sender, EventArgs e)
        {
            this.m_dgvSendMedicine.AutoGenerateColumns = false;
            this.m_dtpBegin.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpEnd.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            this.m_dwReport.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_OP.pbl";
            this.m_dwReport.DataWindowObject = "d_op_sendmedicine";
            this.m_dwReport.Modify("t_title.text='" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "门诊药房发药工作量统计" + "'");
            ((clsCtl_Report_SendMedicine)this.objController).m_mthGetSendMedicine(out  m_objTable);
            if (m_objTable != null)
            {
                this.m_cboMedStore.Items.Clear();

                if (m_objTable.Rows.Count > 0)
                {
                    this.m_cboMedStore.Item.Add("全部", "10000");

                    for (int i1 = 0; i1 < m_objTable.Rows.Count; i1++)
                    {
                        this.m_cboMedStore.Item.Add(m_objTable.Rows[i1]["medstorename_vchr"].ToString(), m_objTable.Rows[i1]["medstoreid_chr"].ToString());
                    }

                    this.m_cboMedStore.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_Report_SendMedicine)this.objController).m_mthSelectSendMedicine();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            //m_dwReport.PrintProperties.Preview = !m_dwReport.PrintProperties.Preview;
            //m_dwReport.PrintProperties.ShowPreviewRulers = !m_dwReport.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.m_dwReport);
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_Report_SendMedicine)this.objController).m_mthExploreData();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_Report_SendMedicine)this.objController).m_mthPrint();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void m_cboMedStore_SelectedValueChanged(object sender, EventArgs e)
        {
            ((clsCtl_Report_SendMedicine)this.objController).m_mthGetEmpData();
        }

    }
}