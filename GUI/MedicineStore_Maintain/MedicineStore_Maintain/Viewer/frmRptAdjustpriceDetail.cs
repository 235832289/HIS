using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品调价情况一览表
    /// </summary>
    public partial class frmRptAdjustpriceDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        private DataTable m_dtResult;
        /// <summary>
        /// 0-药房;1-药库
        /// </summary>
        private int intDsOrMs=0;
        internal int m_intMakeFilm = 0;
        #endregion

        #region 药房/药库窗体显示
        ///// <summary>
        ///// 药房/药库窗体显示
        ///// </summary>
        ///// <param name="p_strDsOrMs">0-药房;1-药库</param>
        //public void m_mthShow(string p_strDsOrMs)
        //{
        //    intDsOrMs = Convert.ToInt32(p_strDsOrMs);
        //    if (intDsOrMs == 0)
        //        this.Text = "药房药品调价情况一览表";
        //    else if (intDsOrMs == 1)
        //        this.Text = "药库药品调价情况一览表";
        //    this.Show();
        //}

        /// <summary>
        /// 药房/药库窗体显示
        /// </summary>
        /// <param name="p_strDsOrMs">0-药房;1-药库</param>
        /// <param name="p_strMakeFilm">1为造影剂专用</param>
        public void m_mthShow(string p_strDsOrMs,string p_strMakeFilm)
        {
            intDsOrMs = Convert.ToInt32(p_strDsOrMs);
            m_intMakeFilm = Convert.ToInt32(p_strMakeFilm);
            if (intDsOrMs == 0)
            {
                if (m_intMakeFilm == 0)
                {
                    this.Text = "药房药品调价情况一览表";
                }
                else
                {
                    this.Text = "药房药品调价情况一览表(造影剂)";
                }
            }
            else if (intDsOrMs == 1)
            {
                if (m_intMakeFilm == 0)
                {
                    this.Text = "药库药品调价情况一览表";
                }
                else
                {
                    this.Text = "药库药品调价情况一览表(造影剂)";
                }
            }
            this.Show();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsCtl_RptAdjustpriceDetail();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptAdjustpriceDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptAdjustpriceDetail_Load(object sender, EventArgs e)
        {
            //if (intDsOrMs == 0)
            //{
            //    this.Text += "(药房)";
            //}
            //else 
            //{
            //    this.Text += "(药库)";
            //}
            this.m_dgvMedicine.AutoGenerateColumns = false;
            this.m_dtpBeginDat.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpEndDat.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            ((clsCtl_RptAdjustpriceDetail)objController).m_mthGetMedicineType(out m_dtResult);
            ((clsCtl_RptAdjustpriceDetail)objController).m_mthInitdw();
            
            if (m_dtResult!=null&&m_dtResult.Rows.Count>0)
            {
                this.m_cboMedicineType.Items.Clear();

                this.m_cboMedicineType.Item.Add("全部", "000");

                for (int i1 = 0; i1 < m_dtResult.Rows.Count; i1++)
                {
                    this.m_cboMedicineType.Item.Add(m_dtResult.Rows[i1]["medicinetypename_vchr"].ToString(), m_dtResult.Rows[i1]["medicinetypeid_chr"].ToString());
                }

                this.m_cboMedicineType.SelectedIndex = 0;
            }
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpriceDetail)objController).m_mthSelectAdjustData(intDsOrMs);
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpriceDetail)objController).m_mthExploreData();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpriceDetail)objController).m_mthPrint();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        { 
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.dw);
        }
        #endregion

        #region 方法
        private void m_mthEnterToTab(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }
        #endregion

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ((clsCtl_RptAdjustpriceDetail)objController).m_mthShowMedName(this.m_txtMedicineName.Text.Trim());
            }
        }
    }
}