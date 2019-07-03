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
    public partial class frmRptCriticalClinicaldept : Form
    {
        public string deptStr { get; set; }
        frmCritialDeptList frm;

        public frmRptCriticalClinicaldept()
        {
            InitializeComponent();
        }

        private void frmRptCriticalClinicaldept_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_critical_clinicalreport_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        }

        public void getdeptstr()
        {
            if(frm != null)
                deptStr = frm.deptStr;
        }

        private void btnDeptSelect_Click(object sender, EventArgs e)
        {
            frm = new frmCritialDeptList(0);
            frm.ShowDialog();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<string> lstYGItem = new List<string>();
            bool flgYG = false;
            string  responsedateStr = string.Empty;
            string dealif = string.Empty;
            string abovetime = string.Empty;
            string crvalSpan = string.Empty;
            DateTime? responsedate = null;
            DateTime ? doctadvicedate = null;
            DateTime ? recorddate = null;
            string responsedatestr = string.Empty;
            string doctadvicedatestr = string.Empty;
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            getdeptstr();

            if (!chkDeptSelect.Checked)
                deptStr = null;

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
                DataTable dt = svc.GetCriticalClinicaldept(BeginDate, EndDate, deptStr);
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

                        crvalSpan = "";
                        recorddate = Convert.ToDateTime(dr["recorddate"].ToString());
                        if (dr["responsedate"].ToString() != "")
                        {
                            responsedate = Convert.ToDateTime(dr["responsedate"].ToString());
                            responsedateStr = (Convert.ToDateTime(dr["responsedate"].ToString())).ToString("yyyy-MM-dd HH:mm");
                        }

                        else
                        {
                            responsedate = System.DateTime.Now;
                            responsedateStr = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                            

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

                        if (dr["doctadvicedate"].ToString() != "")
                        {
                            doctadvicedate = Convert.ToDateTime(dr["doctadvicedate"].ToString());
                            doctadvicedatestr = (Convert.ToDateTime(doctadvicedate)).ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            doctadvicedate = System.DateTime.Now;
                            doctadvicedatestr = "";
                        }

                        TimeSpan tsDoctDeal = doctadvicedate.Value - recorddate.Value;
                        TimeSpan tsRespon = responsedate.Value - recorddate.Value;
                        if (tsDoctDeal.TotalMinutes > 360)
                            dealif = "否";
                        else
                            dealif = "是";
                        if (tsRespon.TotalMinutes > 10)
                            abovetime = "否";
                        else
                            abovetime = "是";

                        row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "responsedate", (Convert.ToDateTime(recorddate)).ToString("yyyy-MM-dd HH:mm"));
                        dwRep.SetItemString(row, "patname", dr["patname"].ToString());
                        dwRep.SetItemString(row, "bedno", dr["bedno"].ToString());
                        dwRep.SetItemString(row, "ipno", dr["ipno"].ToString());
                        dwRep.SetItemString(row, "checkitemresult", dr["checkitemname"].ToString() + "; " + dr["resultval"].ToString());
                        dwRep.SetItemString(row, "crval_span", crvalSpan);
                        dwRep.SetItemString(row, "recorddeptid", dr["recorddeptid"].ToString());
                        dwRep.SetItemString(row, "recorder", dr["recorder"].ToString());
                        dwRep.SetItemString(row, "appdeptname", dr["appdeptname"].ToString());
                        dwRep.SetItemString(row, "responsename", dr["responseopername"].ToString());
                        dwRep.SetItemString(row, "doctname", dr["doctname"].ToString());//dr["doctname"].ToString()
                        dwRep.SetItemString(row, "doctadvicedate", doctadvicedatestr);
                        dwRep.SetItemString(row, "dealif", dealif);
                        dwRep.SetItemString(row, "doctadvicemsg", dr["doctadvicemsg"].ToString());
                        dwRep.SetItemString(row, "abovetime", abovetime);
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
