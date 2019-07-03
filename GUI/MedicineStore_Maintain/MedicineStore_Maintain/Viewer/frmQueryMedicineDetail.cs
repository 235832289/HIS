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
    public partial class frmQueryMedicineDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DataTable m_dtbMedicint;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        public frmQueryMedicineDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strReportName">报表名称</param>
        public void ShowThis(string p_strStorageID,string p_strReportName)
        {
            m_strStorageID = p_strStorageID;
            datWindow.LibraryList = clsPublic.PBLPath;
            datWindow.DataWindowObject = p_strReportName == "" ? "querymedicinedetail" : "querymedicinedetail_" + p_strReportName;
            this.Show();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_QueryMedicineDetail();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_txtMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_QueryMedicineDetail)objController).m_mthShowQueryMedicineForm(m_txtMedicine.Text.Trim());

            }
        }

        private void frmQueryMedicineDetail_Load(object sender, EventArgs e)
        {
            m_dtpSearchBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            ((clsCtl_QueryMedicineDetail)objController).m_mthGetMedicineInfo();
           
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            if (m_txtMedicine.Text.Trim() == "")
            {
                MessageBox.Show("请先选择药品!", "药品出入库明细查询", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ((clsCtl_QueryMedicineDetail)objController).m_mthGetQueryMedicineDetail();
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_QueryMedicineDetail)objController).m_mthPrintDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("发生日期", typeof(System.DateTime));
            dt.Columns.Add("单据号", typeof(System.String));
            dt.Columns.Add("摘要", typeof(System.String));
            dt.Columns.Add("批号", typeof(System.String));
            dt.Columns.Add("买入价", typeof(System.Double));
            dt.Columns.Add("有效期", typeof(System.String));
            dt.Columns.Add("厂家", typeof(System.String));
            dt.Columns.Add("借方数量", typeof(System.Double));
            dt.Columns.Add("借方零售价", typeof(System.Double));
            dt.Columns.Add("借方金额", typeof(System.Double));
            dt.Columns.Add("贷方数量", typeof(System.Double));
            dt.Columns.Add("贷方零售价", typeof(System.Double));
            dt.Columns.Add("贷方金额", typeof(System.Double));
            dt.Columns.Add("余额数量", typeof(System.Double));
            //dt.Columns.Add("余额零售价", typeof(System.Double));
            dt.Columns.Add("余额金额", typeof(System.Double));
            if (m_dtbMedicint.Rows.Count > 0)
            {
                double dblInAmount=0;
                double dblInRetailprice=0;
                double dblOutAmount=0;
                double dblOutRetailprice=0;
                double dblAmount = 0;
                double dblRetailprice = 0; 
                
                for (int i1 = 0; i1 < m_dtbMedicint.Rows.Count; i1++)
                {

                    DataRow row = dt.NewRow();
                    DataRow dtbMedRow = m_dtbMedicint.Rows[i1];

                    double.TryParse(dtbMedRow["inAmount_int"].ToString(), out dblInAmount);
                    double.TryParse(dtbMedRow["inRetailprice_int"].ToString(), out dblInRetailprice);
                    double.TryParse(dtbMedRow["outAmount_int"].ToString(), out dblOutAmount);
                    double.TryParse(dtbMedRow["outRetailprice_int"].ToString(), out dblOutRetailprice);
                    double.TryParse(dtbMedRow["oldgross_int"].ToString(), out dblAmount);
                    double.TryParse(dtbMedRow["balance"].ToString(), out dblRetailprice);

                    row["发生日期"] = dtbMedRow["operatedate_dat"];
                    row["单据号"] = dtbMedRow["chittyid_vchr"];
                    row["摘要"] = dtbMedRow["brief_vchr"];
                    row["批号"] = dtbMedRow["lotno_vchr"];
                    row["买入价"] = dtbMedRow["callprice_int"];
                    row["有效期"] = dtbMedRow["validperiod_chr"];
                    row["厂家"] = dtbMedRow["productorid_chr"];

                    row["借方数量"] = dblInAmount;
                    row["借方零售价"] = dblInRetailprice;
                    row["借方金额"] = dblInAmount * dblInRetailprice;

                    row["贷方数量"] = dblOutAmount;
                    row["贷方零售价"] = dblOutRetailprice;
                    row["贷方金额"] = dblOutAmount * dblOutRetailprice;

                    row["余额数量"] = dblAmount;
                    //row["余额零售价"] = dblRetailprice;
                    row["余额金额"] = dtbMedRow["oldmoney"];

                    dt.Rows.Add(row);
                }
            }
            ((clsCtl_QueryMedicineDetail)this.objController).m_mthOutExcel(dt);
        }

        private void m_txtMedicine_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtMedicine.SelectAll();
        }
    }
}