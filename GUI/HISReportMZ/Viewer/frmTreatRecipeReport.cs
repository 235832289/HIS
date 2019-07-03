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
    /// 门诊药房配药工作量统计报表
    /// </summary>
    public partial class frmTreatRecipeReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        private DataTable m_objTable = null;
        /// <summary>
        /// 药房对应的类型：1西药；2中药，3材料
        /// </summary>
        internal int m_intMedicineType = 0;
        /// <summary>
        /// 药房ID
        /// </summary>
        internal string m_strDrugStoreID = string.Empty;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmTreatRecipeReport()
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
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_Report_TreatRecipe();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTreatRecipeReport_Load(object sender, EventArgs e)
        {
            this.m_dgvTreatRecipe.AutoGenerateColumns = false;
            this.m_dtpBegin.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpEnd.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            this.m_dwReport.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_OP.pbl";
            if (m_intMedicineType != 2)
            {
                this.m_dwReport.DataWindowObject = "d_op_treatrecipe";
            }
            else
            {
                this.m_dwReport.DataWindowObject = "d_op_treatrecipe2";
            }

            this.m_dwReport.Modify("t_title.text='" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "门诊药房配药工作量统计" + "'");
            ((clsCtl_Report_TreatRecipe)this.objController).m_mthGetTreatRecipe(out  m_objTable);
            if (m_objTable != null)
            {
                this.m_cboMedStore.Items.Clear();
                int m_intIndex = 0;
                if (m_objTable.Rows.Count > 0)
                {
                    this.m_cboMedStore.Item.Add("全部", "10000");

                    for (int i1 = 0; i1 < m_objTable.Rows.Count; i1++)
                    {
                        this.m_cboMedStore.Item.Add(m_objTable.Rows[i1]["medstorename_vchr"].ToString(), m_objTable.Rows[i1]["medstoreid_chr"].ToString());
                        if (m_objTable.Rows[i1]["medstoreid_chr"].ToString() == m_strDrugStoreID)
                        {
                            m_intIndex = i1+1;
                        }
                    }

                    this.m_cboMedStore.SelectedIndex = m_intIndex;
                }
            }
            if (m_intMedicineType != 2)
            {
                m_dgvTreatRecipe.Columns["m_dgvtxttotaltimesnum"].Visible = false;
                m_dgvTreatRecipe.Columns["m_dgvtxttotalmedicinenum"].Visible = false;
                m_dgvTreatRecipe.Columns["m_dgvtxttotalrecipenum"].Width = 340;
                m_dgvTreatRecipe.Columns["m_dgvtxttotaltreatnum"].Width = 340;
            }
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_Report_TreatRecipe)this.objController).m_mthSelectTreatRecipe();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            //m_dwReport.PrintProperties.Preview = !m_dwReport.PrintProperties.Preview;
            //m_dwReport.PrintProperties.ShowPreviewRulers = !m_dwReport.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.m_dwReport);
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_Report_TreatRecipe)this.objController).m_mthPrint();
        }

        private void m_cmdBeforeView_Click(object sender, EventArgs e)
        {
            this.m_dwReport.PrintProperties.Preview = !this.m_dwReport.PrintProperties.Preview;
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_Report_TreatRecipe)this.objController).m_mthExploreData();
        }
        #endregion

        private void m_cboMedStore_SelectedValueChanged(object sender, EventArgs e)
        {
            ((clsCtl_Report_TreatRecipe)this.objController).m_mthGetEmpData();
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        public void m_mthShow(string p_strDrugStoreID)
        {
            m_strDrugStoreID = p_strDrugStoreID;
            ((clsCtl_Report_TreatRecipe)this.objController).m_lngGetMedicineType(p_strDrugStoreID, out m_intMedicineType);
            Show();
        }
    }
}