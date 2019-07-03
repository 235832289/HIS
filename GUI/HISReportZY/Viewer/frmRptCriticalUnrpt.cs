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
    public partial class frmRptCriticalUnrpt : Form
    {
        public string deptstr { get; set; }
        frmCritialDeptList frm;

        public frmRptCriticalUnrpt()
        {
            InitializeComponent();
        }

        private void frmRptCriticalUnrpt_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_criticalmddept_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<string> lstYGItem = new List<string>();
            bool flgYG = false;
            string recorddate = string.Empty;
            string doctadvicedate = string.Empty;
            string crvalSpan = string.Empty;
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            getdeptstr();

            if (!chkDeptSelect.Checked)
                deptstr = null;

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                dwRep.Reset();
                lstYGItem = GetYGItem();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetCriticalUnreport(BeginDate, EndDate, deptstr);//GetCriticalUnreport
                DataTable dt1 = svc.GetCrval();
                DataTable dt2 = svc.GetCrval2();
                if (dt != null && dt.Rows.Count > 0)
                {
                    int row = 0;
                    dwRep.SetRedrawOff();
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < lstYGItem.Count; i++)
                        {
                            if (dr["resultval"].ToString().Trim() == lstYGItem[i].Trim())
                            {
                                flgYG = true;
                                break;
                            }
                        }

                        if (flgYG == true)
                        {
                            flgYG = false;
                            continue;
                        }

                        if (dr["recorddate"].ToString() != "")
                            recorddate = (Convert.ToDateTime(dr["recorddate"].ToString())).ToString("yyyy-MM-dd HH:mm");
                        else
                            continue;

                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            if (dr["checkitemid"].ToString() == dr1["check_item_id_chr"].ToString())
                            {
                                crvalSpan = dr1["ALERT_VALUE_RANGE_VCHR"].ToString().Trim();
                                break;
                            }
                        }

                        if (crvalSpan == "")
                        {
                            foreach (DataRow dr2 in dt2.Rows)
                            {
                                if (dr["checkitemid"].ToString() == dr2["check_item_id_chr"].ToString())
                                {
                                    crvalSpan = dr2["ALERT_VALUE_RANGE_VCHR"].ToString().Trim();
                                    break;
                                }
                            }
                        }

                        row = dwRep.InsertRow(0);

                        dwRep.SetItemString(row, "recorddate", recorddate);
                        dwRep.SetItemString(row, "patname", dr["patname"].ToString());
                        dwRep.SetItemString(row, "bedno", dr["bedno"].ToString());
                        dwRep.SetItemString(row, "ipno", dr["ipno"].ToString());
                        dwRep.SetItemString(row, "checkitemresult", dr["checkitemname"].ToString() + "; " + dr["resultval"].ToString());
                        dwRep.SetItemString(row, "crval_span", crvalSpan);
                        dwRep.SetItemString(row, "recorddeptid", dr["recorddeptid"].ToString());
                        dwRep.SetItemString(row, "recorder", dr["recorder"].ToString());
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
                frm = null;
            }
            this.dwRep.Refresh();
        }

        public void getdeptstr()
        {
            if (frm != null)
                deptstr = frm.deptStr;
        }


        private void btnDeptSelect_Click(object sender, EventArgs e)
        {
            //0 临床科室 1 医技科室
            frm = new frmCritialDeptList(1);
            frm.ShowDialog();
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


        public List<string> GetYGItem()
        {
            #region
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
            DataTable dt = svc.GetYGItemType();

            List<string> lstData = new List<string>();

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstData.Add(dr["refDesc"].ToString());
                    }
                }
            }
            finally
            {
                svc = null;
            }

            return lstData;

            #endregion
        }
    }
}
