using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmRptCriticalExecute : Form
    {
        public frmRptCriticalExecute()
        {
            InitializeComponent();
        }

        #region 实体
        public class EntityCriticalExecute
        {
            public string checkitemName { get; set; }
            public string recordDeptname { get; set; }
            public long reportCount { get; set; }
            public long alreadyReport { get; set; }
            public string per { get; set; }
            public string appdeptName { get; set; }
        }
        #endregion


        private void frmRptCriticalExecute_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_criticalrepot_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            bool flg = false;
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                dwRep.Reset();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetCriticalExecute(BeginDate, EndDate);
                List<EntityCriticalExecute> data = new List<EntityCriticalExecute>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dwRep.SetRedrawOff();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string checkitemname = dr["checkitemname"].ToString();
                        string appdeptname = dr["appdeptname"].ToString();
                        string recorddeptname = dr["recorddeptid"].ToString();
                        if (dwRep.RowCount > 0)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                if (appdeptname == data[i].appdeptName && checkitemname == data[i].checkitemName)
                                {

                                    flg = true;
                                    break;
                                }
                            }
                        }

                        if (!flg)
                        {
                            EntityCriticalExecute vo = new EntityCriticalExecute();
                            vo.checkitemName = checkitemname;
                            vo.appdeptName = appdeptname;
                            vo.recordDeptname = recorddeptname;
                            vo.reportCount = dt.Select("checkitemname = '" + checkitemname + "' and appdeptname = '" + appdeptname + "'").Length;
                            vo.alreadyReport = dt.Select("checkitemname = '" + checkitemname + "' and appdeptname = '" + appdeptname + "' and (status = 1 or status = 0)").Length;

                            if (vo.reportCount > 0 && vo.alreadyReport > 0)
                                vo.per = Math.Round(((double)(vo.alreadyReport) / (double)(vo.reportCount)) * 100, 1).ToString() + "%";
                            else
                                vo.per = " ";

                            data.Add(vo);
                        }
                    }

                    if (data != null && data.Count > 0)
                    {
                        int row = 0;
                        dwRep.SetRedrawOff();
                        for (int i = 0; i < data.Count; i++)
                        {
                            row = dwRep.InsertRow(0);
                            dwRep.SetItemString(row, "checkitemname", data[i].checkitemName);
                            dwRep.SetItemString(row, "recorddeptname", data[i].recordDeptname);
                            dwRep.SetItemString(row, "reportconut", data[i].reportCount.ToString());
                            dwRep.SetItemString(row, "alreadyreport", data[i].alreadyReport.ToString());
                            dwRep.SetItemString(row, "per", data[i].per);
                            dwRep.SetItemString(row, "appdeptname", data[i].appdeptName);
                        }
                        dwRep.SetRedrawOn();
                    }
                    else
                    {
                        dwRep.InsertRow(0);
                    }
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
    }
}
