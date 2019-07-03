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
    public partial class frmRptCriticalAreaDpet : Form
    {
        public string deptStr { get; set; }
        frmCritialDeptList frm;

        public frmRptCriticalAreaDpet()
        {
            InitializeComponent();
        }

        public void getdeptstr()
        {
            if (frm != null)
                deptStr = frm.deptStr;
        }

        private void frmRptCriticalAreaDpet_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_critical_areadept_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        }

        private void btnDeptSelect_Click(object sender, EventArgs e)
        {
            frm = new frmCritialDeptList(1);
            frm.ShowDialog();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        public void Query()
        {
            List<entitySample> data = new List<entitySample>();
            string beginDate = string.Empty;
            string endDate = string.Empty;

            bool flgYG = false;
            bool flgXM = false;
            string reportdeptLast = string.Empty;
            string reportdept = string.Empty;
            string deptArea = string.Empty;
            string CheckLisId = string.Empty;
            string CheckPacsId = string.Empty;
            deptStr = string.Empty;
            int CritcalCount = 0;
            int XmCount = 0;

            int NYcount = 0; //内一区
            int NEcount = 0; //内二区
            int MWcount = 0;//泌尿外科
            int PWcount = 0;//普外科
            int SWcount = 0; //手外科
            int NWcount = 0; //脑外科
            int GWcount = 0; //骨外
            int FCKcount = 0; //妇产科
            int EKcount = 0; //儿科
            int ICUcount = 0; //ICU
            int JZcount = 0; //急诊
            int ZYcount = 0; //中医
            int MZcount = 0; //门诊
            int CriticalCount = 0;

            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            DataTable dt1 = null;
            DataTable dt2 = null;
            DataRow[] drr1 = null;
            DataRow[] drr2 = null;
            getdeptstr();
            if (!chkDeptSelect.Checked)
                deptStr = null;

            clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
            dwRep.Reset();

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetCriticalAreaDpet(BeginDate, EndDate, deptStr);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        deptArea = JudgeDeptArea(dr["code_vchr"].ToString());
                        reportdeptLast = dr["recorddeptid"].ToString();
                        if (!reportdept.Contains(reportdeptLast))
                            reportdept += (reportdeptLast + "、");


                        for (int i = 0; i < data.Count; i++)
                        {
                            if (data.Count > 0 && data[i].XM == dr["checkitemname"].ToString())
                            {
                                if (deptArea == "NY")
                                    data[i].NYcount++;
                                if (deptArea == "NE")
                                    data[i].NEcount++;
                                if (deptArea == "MW")
                                    data[i].MWcount++;
                                if (deptArea == "PW")
                                    data[i].PWcount++;
                                if (deptArea == "SW")
                                    data[i].PWcount++;
                                if (deptArea == "NW")
                                    data[i].NWcount++;
                                if (deptArea == "GW")
                                    data[i].GWcount++;
                                if (deptArea == "FCK")
                                    data[i].FCKcount++;
                                if (deptArea == "EK")
                                    data[i].EKcount++;
                                if (deptArea == "ICU")
                                    data[i].ICUcount++;
                                if (deptArea == "MZ")
                                    data[i].MZcount++;
                                if (deptArea == "JZ")
                                    data[i].JZcount++;
                                if (deptArea == "ZY")
                                    data[i].ZYcount++;
                                
                                flgXM = true;
                                break;
                            }
                        }
                        if (flgXM == false)
                        {
                            entitySample vo = new entitySample();
                            vo.XM = dr["checkitemname"].ToString();

                            if (deptArea == "NY")
                                vo.NYcount++;
                            if (deptArea == "NE")
                                vo.NEcount++;
                            if (deptArea == "MW")
                                vo.MWcount++;
                            if (deptArea == "PW")
                                vo.PWcount++;
                            if (deptArea == "SW")
                                vo.PWcount++;
                            if (deptArea == "NW")
                                vo.NWcount++;
                            if (deptArea == "GW")
                                vo.GWcount++;
                            if (deptArea == "FCK")
                                vo.FCKcount++;
                            if (deptArea == "EK")
                                vo.EKcount++;
                            if (deptArea == "ICU")
                                vo.ICUcount++;
                            if (deptArea == "MZ")
                                vo.MZcount++;
                            if (deptArea == "JZ")
                                vo.JZcount++;
                            if (deptArea == "ZY")
                                vo.ZYcount++;

                            vo.CheckId = dr["checkitemid"].ToString();
                            if (dr["applytypeid"].ToString() == "1")
                                CheckLisId += "'" + dr["checkitemid"].ToString() + "'" + ",";
                            else if (dr["applytypeid"].ToString() == "2")
                                CheckPacsId += "'" + dr["checkitemname"].ToString() + "'" + ",";

                            data.Add(vo);
                        }
                        flgXM = false;
                    }

                    CritcalCount = dt.Rows.Count;
                    if (!string.IsNullOrEmpty(CheckLisId))
                        CheckLisId = "(" + CheckLisId.TrimEnd(',') + ")";
                    if (!string.IsNullOrEmpty(CheckPacsId))
                        CheckPacsId = "(" + CheckPacsId.TrimEnd(',') + ")";

                    GetItemDataTable(ref dt1, ref dt2, deptStr,CheckLisId,CheckPacsId);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            drr1 = dt1.Select("check_item_id_chr = '" + data[i].CheckId + "'");
                            if (drr1 != null && drr1.Length > 0)
                                data[i].LisCount = drr1.Length;

                            data[i].HJcount = data[i].NYcount + data[i].NEcount + data[i].MWcount + data[i].PWcount + data[i].SWcount + data[i].NWcount +
                                            data[i].GWcount + data[i].FCKcount + data[i].EKcount + data[i].ICUcount + data[i].MZcount + data[i].JZcount + data[i].ZYcount;
                            if (data[i].LisCount <= data[i].HJcount && data[i].PacsCount <= data[i].HJcount)
                                data[i].PacsCount = data[i].HJcount;
                            else if (data[i].LisCount > 0 && data[i].HJcount > 0)
                                data[i].xmper = Math.Round(((double)data[i].HJcount / (double)data[i].LisCount) * 100, 2).ToString() + "%";
                            if (CritcalCount > 0 && data[i].HJcount > 0)
                                data[i].wjzper = Math.Round(((double)data[i].HJcount / (double)CritcalCount) * 100, 2).ToString() + "%";
                            XmCount += data[i].LisCount;
                        }
                    }
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            drr2 = dt2.Select("diagnosepart = '" + data[i].XM + "'");
                            if (drr2 != null && drr2.Length > 0)
                                data[i].PacsCount = drr2.Length;
                            
                            data[i].HJcount = data[i].NYcount + data[i].NEcount + data[i].MWcount + data[i].PWcount + data[i].SWcount + data[i].NWcount +
                                            data[i].GWcount + data[i].FCKcount + data[i].EKcount + data[i].ICUcount + data[i].MZcount + data[i].JZcount + data[i].ZYcount;
                            if (data[i].LisCount <= data[i].HJcount && data[i].PacsCount <= data[i].HJcount)
                                data[i].PacsCount = data[i].HJcount;
                            if (data[i].PacsCount > 0 && data[i].HJcount > 0)
                                data[i].xmper = Math.Round(((double)data[i].HJcount / (double)data[i].PacsCount) * 100, 2).ToString() + "%";
                            if (CritcalCount > 0 && data[i].HJcount > 0)
                                data[i].wjzper = Math.Round(((double)data[i].HJcount / (double)CritcalCount) * 100, 2).ToString() + "%";
                            XmCount += data[i].PacsCount;
                        }
                    }
                    
                    int row = 0;
                    dwRep.SetRedrawOff();

                    for (int i = 0; i < data.Count; i++)
                    {
                        row = dwRep.InsertRow(0);

                        dwRep.SetItemString(row, "checkitemname", data[i].XM.ToString());
                        dwRep.SetItemString(row, "ny", data[i].NYcount > 0 ? data[i].NYcount.ToString() : "");
                        dwRep.SetItemString(row, "ne", data[i].NEcount > 0 ? data[i].NEcount.ToString() : "");
                        dwRep.SetItemString(row, "mw", data[i].MWcount > 0 ? data[i].MWcount.ToString() : "");
                        dwRep.SetItemString(row, "pw", data[i].PWcount > 0 ? data[i].PWcount.ToString() : "");
                        dwRep.SetItemString(row, "sw", data[i].SWcount > 0 ? data[i].SWcount.ToString() : "");
                        dwRep.SetItemString(row, "nw", data[i].NWcount > 0 ? data[i].NWcount.ToString() : "");
                        dwRep.SetItemString(row, "gw", data[i].GWcount > 0 ? data[i].GWcount.ToString() : "");
                        dwRep.SetItemString(row, "fck", data[i].FCKcount > 0 ? data[i].FCKcount.ToString() : "");
                        dwRep.SetItemString(row, "ek", data[i].EKcount > 0 ? data[i].EKcount.ToString() : "");
                        dwRep.SetItemString(row, "icu", data[i].ICUcount > 0 ? data[i].ICUcount.ToString() : "");
                        dwRep.SetItemString(row, "mz", data[i].MZcount > 0 ? data[i].MZcount.ToString() : "");
                        dwRep.SetItemString(row, "jz", data[i].JZcount > 0 ? data[i].JZcount.ToString() : "");
                        dwRep.SetItemString(row, "zy", data[i].ZYcount > 0 ? data[i].ZYcount.ToString() : "");
                        dwRep.SetItemString(row, "hj", data[i].HJcount.ToString());
                        dwRep.SetItemString(row, "xms", data[i].PacsCount > 0 ? data[i].PacsCount.ToString() : data[i].LisCount.ToString());
                        dwRep.SetItemString(row, "wjzper", data[i].wjzper);
                        dwRep.SetItemString(row, "xmper", data[i].xmper);

                        NYcount += data[i].NYcount; //内一区
                        NEcount += data[i].NEcount; //内二区
                        MWcount += data[i].MWcount;//泌尿外科
                        PWcount += data[i].PWcount;//普外科
                        SWcount += data[i].SWcount; //手外科
                        NWcount += data[i].NWcount; //脑外科
                        GWcount += data[i].GWcount; //骨外
                        FCKcount += data[i].FCKcount; //妇产科
                        EKcount += data[i].EKcount; //儿科
                        ICUcount += data[i].ICUcount; //ICU
                        JZcount += data[i].JZcount; //急诊
                        ZYcount += data[i].ZYcount; //中医
                        MZcount += data[i].MZcount; //门诊
                        CriticalCount += data[i].HJcount;
                    }

                    if (CritcalCount > 0)
                    {
                        row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "checkitemname", "危急值总数");
                        dwRep.SetItemString(row, "ny", NYcount > 0 ? NYcount.ToString() : "");
                        dwRep.SetItemString(row, "ne", NEcount > 0 ? NEcount.ToString() : "");
                        dwRep.SetItemString(row, "mw", MWcount > 0 ? MWcount.ToString() : "");
                        dwRep.SetItemString(row, "pw", PWcount > 0 ? PWcount.ToString() : "");
                        dwRep.SetItemString(row, "sw", SWcount > 0 ? SWcount.ToString() : "");
                        dwRep.SetItemString(row, "nw", NWcount > 0 ? NWcount.ToString() : "");
                        dwRep.SetItemString(row, "gw", GWcount > 0 ? GWcount.ToString() : "");
                        dwRep.SetItemString(row, "fck", FCKcount > 0 ? FCKcount.ToString() : "");
                        dwRep.SetItemString(row, "ek", EKcount > 0 ? EKcount.ToString() : "");
                        dwRep.SetItemString(row, "icu", ICUcount > 0 ? ICUcount.ToString() : "");
                        dwRep.SetItemString(row, "mz", MZcount > 0 ? MZcount.ToString() : "");
                        dwRep.SetItemString(row, "jz", JZcount > 0 ? JZcount.ToString() : "");
                        dwRep.SetItemString(row, "zy", ZYcount > 0 ? ZYcount.ToString() : "");
                        dwRep.SetItemString(row, "hj", CriticalCount.ToString());
                        dwRep.SetItemString(row, "xms",XmCount>0 ? XmCount.ToString():"");
                    }

                    dwRep.SetRedrawOn();
                }
                else
                {
                    dwRep.InsertRow(0);
                }
                
                if (reportdept != string.Empty) reportdept = reportdept.TrimEnd('、');

                dwRep.Modify("t_dept.text = '" + "报告科室："+ reportdept + "'");
                dwRep.Modify("t_date.text = '" + "统计时间："+ BeginDate + " ~ " + EndDate + "'");
                data = null;
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


        private string JudgeDeptArea(string deptcode)
        {
            string deptArea = string.Empty;
            //List<string> NY = new List<string>() { "0301", "03011", "030111", "03012", "030121", 
               // "03013", "03014", "16", "16012", "16022" ,"16032", "161", "162"};
            List<string> NY = new List<string>() { "0301","03013"};
            //List<string> NE = new List<string>() { "0302", "03021", "030211", "03022", "030221", "03023", "03024", 
            //    "03025", "792"};
            List<string> NE = new List<string>() { "0302", "03024"};
            //List<string> MW = new List<string>() { "0405", "04051", "04013"};
            List<string> MW = new List<string>() { "0405", "04051"};
            //List<string> PW = new List<string>() { "0401", "04011", "04012"};
            List<string> PW = new List<string>() { "0401", "04011"};
            //List<string> SW = new List<string>() { "0408", "04081", "04082"};
            List<string> SW = new List<string>() { "0408", "04081" };
            //List<string> NW = new List<string>() { "0402", "04021", "04022"};
            List<string> NW = new List<string>() { "0402", "04021"};
            //List<string> GW = new List<string>() { "0403", "04031", "04032"};
            List<string> GW = new List<string>() { "0403", "04031"};
            //List<string> FCK = new List<string>() { "06", "0504", "0503", "05", "0501", "05011", "05012", "0502", "05021", "05022" };
            List<string> FCK = new List<string>() { "06", "0503", "05", "0501", "05011", "0502", "05021"};
            //List<string> EK = new List<string>() { "07", "0701", "0702", "071", "0711", "0712", "072"};
            List<string> EK = new List<string>() { "07", "0701", "0702", "071", "0711", "0712" };
            List<string> ICU = new List<string>() { "02", "0201" };
            List<string> MZ = new List<string>() { "1002", "0103", "40", "82", "821", "11", "822", "13", "824", "825", "829", "88021", "88031", "8804", "88032", "88022", "04032" };
            List<string> JZ = new List<string>() { "20", "823"};
            List<string> ZY = new List<string>() { "0404", "04041", "15011", "50", "50152", "502" };

            if (NY.Contains(deptcode))
                deptArea = "NY"; //内一区
            else if (NE.Contains(deptcode))
                deptArea = "NE"; //内二区
            else if (MW.Contains(deptcode))
                deptArea = "MW"; //泌尿外科
            else if (PW.Contains(deptcode))
                deptArea = "PW"; //普外科
            else if (SW.Contains(deptcode))
                deptArea = "SW"; //手外科
            else if (NW.Contains(deptcode))
                deptArea = "NW"; //脑外科
            else if (GW.Contains(deptcode))
                deptArea = "GW"; //骨外
            else if (FCK.Contains(deptcode))
                deptArea = "FCK"; //妇产科
            else if (EK.Contains(deptcode))
                deptArea = "EK"; //儿科
            else if (ICU.Contains(deptcode))
                deptArea = "ICU"; //ICU
            else if (JZ.Contains(deptcode))
                deptArea = "JZ"; //急诊
            else if (ZY.Contains(deptcode))
                deptArea = "ZY"; //中医
            else //if (MZ.Contains(deptcode))
                deptArea = "MZ"; //门诊
            
            return deptArea;
        }


        public List<string> GetYGItem()
        {
            #region
            clsHISReportZy_Supported_Svc svc;
            List<string> lstData = new List<string>();

            try
            {
                svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetYGItemType();

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

        public void GetItemDataTable(ref DataTable dt1, ref DataTable dt2, string deptStr,string CheckLisId,string CheckPacsId)
        {
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            clsHISReportZy_Supported_Svc svc;

            try
            {

                if (deptStr == "('30')")
                {
                    svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                    dt1 = svc.GetLisCheckItem(BeginDate, EndDate, CheckLisId);
                }
                else
                {
                    svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                    dt1 = svc.GetLisCheckItem(BeginDate, EndDate,CheckLisId);

                    svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                    dt2 = svc.GetPacsCheckItem(BeginDate, EndDate,CheckPacsId);
                }
            }
            finally
            {
                svc = null;
            }
        }
    }



    public class entitySample
    {
        public entitySample() { }

        public string KS { get; set; }
        public string XM { get; set; }
        public string CheckId { get; set; }
        public int NYcount { get; set; }
        public int NEcount { get; set; }
        public int MWcount { get; set; }
        public int PWcount { get; set; }
        public int NWcount { get; set; }
        public int GWcount { get; set; }
        public int FCKcount { get; set; }
        public int EKcount { get; set; }
        public int ICUcount { get; set; }
        public int MZcount { get; set; }
        public int SWcount { get; set; }
        public int JZcount { get; set; }
        public int ZYcount { get; set; }
        public int HJcount { get; set; }
        public int LisCount { get; set; }
        public int PacsCount { get; set; }
        public string wjzper { get; set; }
        public string xmper { get; set; }
    }
}
