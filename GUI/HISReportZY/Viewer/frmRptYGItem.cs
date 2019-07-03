using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 院感项目统计
    /// </summary>
    public partial class frmRptYGItem : Form
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptYGItem()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体事件

        private void frmRptYGCritical_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_ygitems";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            this.dwRep.Modify("t_title.text = '" + "高危预警项目统计表" + "'");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在统计院感项目信息，请稍候...");
                dwRep.Reset();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetYGItem(BeginDate, EndDate);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int row = 0;
                    dwRep.SetRedrawOff();
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "areaName", dr["areaName"].ToString());
                        dwRep.SetItemString(row, "bedNo", dr["bedNo"].ToString());
                        dwRep.SetItemString(row, "ipNo", dr["ipNo"].ToString());
                        dwRep.SetItemString(row, "patName", dr["patName"].ToString());
                        dwRep.SetItemString(row, "sex", dr["patsex"].ToString());
                        dwRep.SetItemString(row, "age", dr["birthday"] != DBNull.Value ? clsPublic.CalcAge(Convert.ToDateTime(dr["birthday"].ToString())):"");
                        dwRep.SetItemString(row, "itemCode", dr["itemCode"].ToString());
                        dwRep.SetItemString(row, "itemName", dr["itemName"].ToString());
                        dwRep.SetItemString(row, "startDate", dr["startDate"] != DBNull.Value ? Convert.ToDateTime(dr["startDate"].ToString()).ToString("yyyy-MM-dd HH:mm") : "");
                        dwRep.SetItemString(row, "stopDate", dr["stopDate"] != DBNull.Value ? Convert.ToDateTime(dr["stopDate"].ToString()).ToString("yyyy-MM-dd HH:mm") : "");
                    }
                    dwRep.SetRedrawOn();
                }
                else
                {
                    dwRep.InsertRow(0);
                }
                dwRep.Modify("t_date.text = '" + BeginDate + " ~ " + EndDate + "'");
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsVolDatawindowToExcel[] volExcel = new clsVolDatawindowToExcel[2];

                volExcel[0] = new clsVolDatawindowToExcel(1);
                volExcel[0].m_rowheight[0] = 20;
                volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
                volExcel[0].m_HorizontalAlignment[0] = "0";
                volExcel[0].m_firstcommn[0] = "A1";
                volExcel[0].m_endcommn[0] = "ALL";

                volExcel[1] = new clsVolDatawindowToExcel(1);
                volExcel[1].m_rowheight[0] = 20;
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "ALL";

                clsPublic.ExportDataWindow(this.dwRep, volExcel);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
