using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{

    public partial class FrmMedicineAcceptance : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public string m_strStorageID;
        public string m_strStorageName;
        public int m_intFindType;
        /// <summary>
        /// 打印报表
        /// </summary>
        public DataTable m_dtbPrint = new DataTable();
        /// <summary>
        /// 报表名称
        /// </summary>
        public string m_strReportName = string.Empty;

        public FrmMedicineAcceptance()
        {
            InitializeComponent();
            m_dtpBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            m_dtpEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            this.m_dwcData.LibraryList = clsPublic.PBLPath;
        }
        
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineAcceptance();
            objController.Set_GUI_Apperance(this);
        }
        
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strFindType">查询类型　０：汇总，１：明细</param>
        /// <param name="p_strReportName">报表名称</param>
        public void ShowThis(string p_strStorageID, string p_strFindType,string p_strReportName)
        {
            m_strStorageID = p_strStorageID;
            m_strReportName = p_strReportName; 
            m_intFindType = Convert.ToInt16(p_strFindType);
            ((clsCtl_MedicineAcceptance)objController).m_mthGetStoreRoomName(out m_strStorageName);
            if (m_intFindType == 0)
            {
                this.Text = "中标药品入库分类汇总表(" + m_strStorageName + ')';
                this.btnToExcel.Visible = false;
            }
            else
            {
                this.Text = "中标药品入库分类明细表(" + m_strStorageName + ')';
            }
            this.Show();
        }

        #region 窗体事件
        private void FrmMedicineAcceptance_Load(object sender, EventArgs e)
        {
            
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            if (m_intFindType == 0)
            {
                ((clsCtl_MedicineAcceptance)objController).m_mthMedicineAcceptance(m_strReportName);
            }
            else
            {
                ((clsCtl_MedicineAcceptance)objController).m_lngGetAcceptanceDetal(m_strReportName); 
            }
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(m_dwcData, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
              

        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("药品代码", typeof(System.String));
            dt.Columns.Add("药品名称", typeof(System.String));
            dt.Columns.Add("规格", typeof(System.String));
            dt.Columns.Add("剂型", typeof(System.String));
            dt.Columns.Add("单位", typeof(System.String));
            dt.Columns.Add("数量", typeof(System.Double));
            dt.Columns.Add("买入金额", typeof(System.Double));
            dt.Columns.Add("零售金额", typeof(System.Double));
            dt.Columns.Add("国家限价金额", typeof(System.Double));
            dt.Columns.Add("最高零售金额", typeof(System.Double));
            dt.Columns.Add("供货单位", typeof(System.String));
            if (m_dtbPrint.Rows.Count > 0)
            {                
                double dblAmount = 0;
                double dblCallprice = 0;
                double dblRetailprice = 0;
                double dblLimitunitprice = 0;
                double dblTopprice = 0;
                for (int i1 = 0; i1 < m_dtbPrint.Rows.Count; i1++)
                {                    
                    DataRow row = dt.NewRow();
                    row["药品代码"] = m_dtbPrint.Rows[i1]["assistcode_chr"];
                    row["药品名称"] = m_dtbPrint.Rows[i1]["medicinename_vch"];
                    row["规格"] = m_dtbPrint.Rows[i1]["medspec_vchr"];
                    row["剂型"] = m_dtbPrint.Rows[i1]["medicinepreptypename_vchr"];
                    row["单位"] = m_dtbPrint.Rows[i1]["opunit_chr"];

                    double.TryParse(m_dtbPrint.Rows[i1]["netamount_int"].ToString(), out dblAmount);
                    double.TryParse(m_dtbPrint.Rows[i1]["callprice_int"].ToString(), out dblCallprice);
                    double.TryParse(m_dtbPrint.Rows[i1]["retailprice_int"].ToString(), out dblRetailprice);
                    double.TryParse(m_dtbPrint.Rows[i1]["limitunitprice_mny"].ToString(), out dblLimitunitprice);
                    double.TryParse(m_dtbPrint.Rows[i1]["topprice"].ToString(), out dblTopprice);

                    row["数量"] = dblAmount;
                    row["买入金额"] = dblCallprice * dblAmount;
                    row["零售金额"] = dblRetailprice * dblAmount;
                    row["国家限价金额"] = dblLimitunitprice * dblAmount;
                    row["最高零售金额"] = dblTopprice * dblAmount;
                    row["供货单位"] = m_dtbPrint.Rows[i1]["vendorname_vchr"];
                    dt.Rows.Add(row);
                }
            }
            ((clsCtl_MedicineAcceptance)this.objController).m_mthOutExcel(dt);
        }
        #endregion
    }
}