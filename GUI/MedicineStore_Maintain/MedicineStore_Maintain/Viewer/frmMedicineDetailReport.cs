using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品明细报表
    /// </summary>
    public partial class frmMedicineDetailReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        internal string m_strLastStorageID = string.Empty;
        public DataTable m_dtbAccou = new DataTable();
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        public clsMS_AccountPeriodVO AccouVO = new clsMS_AccountPeriodVO();
        #endregion

        /// <summary>
        /// 药品明细报表
        /// </summary>
        public frmMedicineDetailReport()
        {
            InitializeComponent();

            m_lblAccountDate.Text = string.Empty;
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strReportName">报表名称</param>
        public void m_mthShow(string p_strStorageID,string p_strReportName)
        {
            m_strStorageID = p_strStorageID;
            m_bgwGetItem.RunWorkerAsync();
            m_bgwGetIDList.RunWorkerAsync();
            datWindow.LibraryList = clsPublic.PBLPath;
            datWindow.DataWindowObject = p_strReportName == "" ? "ms_account_Detail" : "ms_account_Detail_" + p_strReportName;
            this.Show();
        }

        /// <summary>
        /// 设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineDetailReport();
            objController.Set_GUI_Apperance(this);
        }

        private void m_txtMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_MedicineDetailReport)objController).m_mthShowQueryMedicineForm(m_txtMedicine.Text.Trim());
            }
        }

        private void m_bgwGetItem_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_MedicineDetailReport)objController).m_mthGetMedicineInfo();

            clsMS_MedicineTypeSetVO[] objMPVO = null;
            ((clsCtl_MedicineDetailReport)objController).m_mthGetMedicineTypeSet(out objMPVO);
            e.Result = objMPVO;
        }

        private void m_bgwGetItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clsMS_MedicineTypeSetVO[] objMPVO = e.Result as clsMS_MedicineTypeSetVO[];
            if (objMPVO != null && objMPVO.Length > 0)
            {
                m_cboMedicineType.Items.Clear();
                m_cboMedicineType.Items.AddRange(objMPVO);
            }
            m_cboMedicineType.Items.Add("全部");
        }

        private void m_cboMedicineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (m_cboMedicineType.SelectedIndex >= 0)
            {
                m_txtMedicine.Text = string.Empty;
                m_txtMedicine.Tag = null;
                
            }
        }

        private void m_lsvAccountIDList_MouseClick(object sender, MouseEventArgs e)
        {
            int lsvItemIndex = -1;
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
                lasAccouVO = (clsMS_AccountPeriodVO)m_lsvAccountIDList.Items[lsvItemIndex - 1].Tag;
                m_strLastStorageID = lasAccouVO.m_strACCOUNTID_CHR;
            }
            else
            {
                m_strLastStorageID = null;
            }
            m_txtAccountID.Text = AccouVO.m_strACCOUNTID_CHR;

            m_lblAccountDate.Text = AccouVO.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日") + " ~ " + AccouVO.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日");

            m_lblAccountDate.Visible = true;
            m_lsvAccountIDList.Visible = false;
        

        }

        private void m_lsvAccountIDList_Leave(object sender, EventArgs e)
        {
            m_lsvAccountIDList.Visible = false;
        }

        private void m_bgwGetIDList_DoWork(object sender, DoWorkEventArgs e)
        {
            clsMS_AccountPeriodVO[] objAccArr = null;
            ((clsCtl_MedicineDetailReport)objController).m_mthGetAccountIDList(out objAccArr);
            e.Result = objAccArr;
        }

        private void m_bgwGetIDList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clsMS_AccountPeriodVO[] objAccArr = e.Result as clsMS_AccountPeriodVO[];
            ((clsCtl_MedicineDetailReport)objController).m_mthSetAccountPeriodToList(objAccArr);
        }

        private void m_cmdShowAccount_Click(object sender, EventArgs e)
        {
            if (m_lsvAccountIDList.Items.Count > 0)
            {
                m_lsvAccountIDList.Visible = true;
                m_lsvAccountIDList.Focus();
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineDetailReport)objController).m_mthGetMedicineDetailReport();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
        }

        private void p_cmbToExcel_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("药品名称", typeof(System.String));
            dt.Columns.Add("期初结存数量", typeof(System.Double));
            dt.Columns.Add("期初结存购入金额", typeof(System.Double));
            dt.Columns.Add("期初结存批发金额", typeof(System.Double));
            dt.Columns.Add("期初结存零售金额", typeof(System.Double));
            dt.Columns.Add("本期收入数量", typeof(System.Double));
            dt.Columns.Add("本期收入购入金额", typeof(System.Double));
            dt.Columns.Add("本期收入批发金额", typeof(System.Double));
            dt.Columns.Add("本期收入零售金额", typeof(System.Double));
            dt.Columns.Add("本期调拨数量", typeof(System.Double));
            dt.Columns.Add("本期调拨购入金额", typeof(System.Double));
            dt.Columns.Add("本期调拨批发金额", typeof(System.Double));
            dt.Columns.Add("本期调拨零售金额", typeof(System.Double));
            dt.Columns.Add("期末结存数量", typeof(System.Double));
            dt.Columns.Add("期末结存购入金额", typeof(System.Double));
            dt.Columns.Add("期末结存批发金额", typeof(System.Double));
            dt.Columns.Add("期末结存零售金额", typeof(System.Double));
            if (m_dtbAccou.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < m_dtbAccou.Rows.Count; i1++)
                {
                    DataRow row = dt.NewRow();
                    row["药品名称"] = m_dtbAccou.Rows[i1]["medicinename_vch"];
                    row["期初结存数量"] = m_dtbAccou.Rows[i1]["m_dblBeginAmount"];
                    row["期初结存购入金额"] = m_dtbAccou.Rows[i1]["m_dblBeginCallMoney"];
                    row["期初结存批发金额"] = m_dtbAccou.Rows[i1]["m_dblBeginWholesaleMoney"];
                    row["期初结存零售金额"] = m_dtbAccou.Rows[i1]["m_dblBeginRetailMoney"];
                    row["本期收入数量"] = m_dtbAccou.Rows[i1]["m_dblInAmount"];
                    row["本期收入购入金额"] = m_dtbAccou.Rows[i1]["m_dblInCallMoney"];
                    row["本期收入批发金额"] = m_dtbAccou.Rows[i1]["m_dblInWholesaleMoney"];
                    row["本期收入零售金额"] = m_dtbAccou.Rows[i1]["m_dblInRetailMoney"];
                    row["本期调拨数量"] = m_dtbAccou.Rows[i1]["m_dblOutAmount"];
                    row["本期调拨购入金额"] = m_dtbAccou.Rows[i1]["m_dblOutCallMoney"];
                    row["本期调拨批发金额"] = m_dtbAccou.Rows[i1]["m_dblOutWholesaleMoney"];
                    row["本期调拨零售金额"] = m_dtbAccou.Rows[i1]["m_dblOutRetailMoney"];
                    row["期末结存数量"] = m_dtbAccou.Rows[i1]["m_dblEndAmount"];
                    row["期末结存购入金额"] = m_dtbAccou.Rows[i1]["m_dblEndCallMoney"];
                    row["期末结存批发金额"] = m_dtbAccou.Rows[i1]["m_dblEndWholesaleMoney"];
                    row["期末结存零售金额"] = m_dtbAccou.Rows[i1]["m_dblEndRetailMoney"];
                    dt.Rows.Add(row);
                }
            }
            ((clsCtl_MedicineDetailReport)this.objController).m_mthOutExcel(dt);
          //  ((clsCtl_MedicineDetailReport)this.objController).ExportDataGridViewToExcel(dgbAccount_detail);
            
        }

        private void frmMedicineDetailReport_Load(object sender, EventArgs e)
        {
            m_dtbAccou.Columns.Add("medicinename_vch", typeof(System.String));
            m_dtbAccou.Columns.Add("m_dblbeginwholesalemoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblbeginretailmoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblincallmoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblinwholesalemoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblinretailmoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dbloutwholesalemoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dbloutretailmoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblendwholesalemoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblendretailmoney", typeof(System.Double));

            m_dtbAccou.Columns.Add("m_dblBeginAmount", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblinAmount", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dbloutAmount", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblendAmount", typeof(System.Double));

            m_dtbAccou.Columns.Add("m_dblBeginCallMoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblOutCallMoney", typeof(System.Double));
            m_dtbAccou.Columns.Add("m_dblEndCallMoney", typeof(System.Double));
        }

        private void datWindow_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

    }
}