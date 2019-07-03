using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.Utility;
using Sybase.DataWindow;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmNewRptDeptIncom : Form
    {
        public frmNewRptDeptIncom()
        {
            InitializeComponent();
        }

        private ArrayList DeptIDArr = new ArrayList();
        private static clsLogText log = null;
        private static string strFileName = string.Empty;
        Transaction pbTrans = null;
        private void frmNewRptDeptIncom_Load(object sender, EventArgs e)
        {
            #region 两层事务处理，稍后改回三层。
            string ServerName = "";
            string UserID = "";
            string Pwd = "";
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);
            pbTrans = new Transaction();
            pbTrans.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;
            pbTrans.ServerName = ServerName;
            pbTrans.UserId = UserID;
            pbTrans.Password = Pwd;
            pbTrans.AutoCommit = true;
            pbTrans.Connect();
            #endregion

            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            Init();

            log = new clsLogText();
            strFileName = Application.StartupPath + "\\log" + "\\log.txt";
        }

        void Init()
        {
            this.dwRep.DataWindowObject = null;
            this.dwRep.LibraryList = Application.StartupPath + "\\pbreport.pbl";
            this.dwRep.DataWindowObject = "d_bih_deptincome_icu";
            this.dwRep.SetTransaction(pbTrans);
        }

        class EntityTrans
        {
            public string sourceDeptId { get; set; }
            public string sourceDeptName { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime? endDate { get; set; }
        }

        #region
        /// <summary>
        /// QueryDeptCharge
        /// </summary>
        public void QueryDeptCharge()
        {
            Init();
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            List<DataTable> dtData = new List<DataTable>();

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                clsPublic.PlayAvi("请稍候...");
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dtSum = svc.GetDeptChareg(BeginDate, EndDate, DeptIDArr);
                DataTable dtICU = svc.GetICUchareg(BeginDate, EndDate);
                List<DataRow> lstDelRow = new List<DataRow>();
                List<string> lstPChargeId1 = new List<string>();
                List<string> lstPChargeId2 = new List<string>();
                int rowNo = -1;
                if (dtICU != null && dtICU.Rows.Count > 0)
                {
                    foreach (DataRow dr3 in dtICU.Rows)
                    {
                        dr3["rowNo"] = ++rowNo;
                    }
                    DataRow[] drrRef = dtICU.Select("refpchargeid_chr <> ''");
                    foreach (DataRow dr3 in dtICU.Rows)
                    {
                        foreach (DataRow dr4 in drrRef)
                        {
                            if (dr3["pchargeid_chr"].ToString() == dr4["refpchargeid_chr"].ToString())
                            {
                                dr3["catsum"] = Convert.ToDecimal(dr3["catsum"]) + Convert.ToDecimal(dr4["catsum"]);
                                lstDelRow.Add(dr4);
                            }
                        }
                    }
                    foreach (DataRow dr3 in lstDelRow)
                    {
                        dtICU.Rows.Remove(dr3);
                    }
                    dtICU.AcceptChanges();

                    lstDelRow.Clear();
                    string regId = string.Empty;
                    List<string> lstRegId = new List<string>();
                    foreach (DataRow dr3 in dtICU.Rows)
                    {
                        regId = dr3["registerid_chr"].ToString();
                        if (lstRegId.IndexOf(regId) < 0) lstRegId.Add(regId);
                    }
                    decimal totalsum = 0;
                    string pchargeId = string.Empty;
                    string icuDeptCode = "0201";
                    DataRow[] drr = null;
                    DataTable dtTrans = null;
                    List<EntityTrans> lstTrans = new List<EntityTrans>();
                    foreach (string regId2 in lstRegId)
                    {
                        dtTrans = svc.GetPatTransf(regId2);
                        lstTrans.Clear();
                        EntityTrans vo = null;
                        for (int k = 0; k < dtTrans.Rows.Count; k++)
                        {
                            if (dtTrans.Rows[k]["targetareancode"].ToString() == icuDeptCode)
                            {
                                vo = new EntityTrans();
                                vo.sourceDeptId = dtTrans.Rows[k]["sourceareacode"].ToString();
                                vo.sourceDeptName = dtTrans.Rows[k]["sourceareaname"].ToString();
                                vo.beginDate = Convert.ToDateTime(dtTrans.Rows[k]["modify_dat"]);
                                if (k + 1 < dtTrans.Rows.Count)
                                {
                                    vo.endDate = Convert.ToDateTime(dtTrans.Rows[k + 1]["modify_dat"]);
                                }
                                if (string.IsNullOrEmpty(vo.sourceDeptId))
                                {
                                    vo.sourceDeptId = icuDeptCode;
                                    vo.sourceDeptName = dtTrans.Rows[k]["targetareaname"].ToString();
                                }
                                lstTrans.Add(vo);
                            }
                        }
                        foreach (EntityTrans vo2 in lstTrans)
                        {
                            DataRow[] drrIcu = null;
                            if (vo2.endDate == null)
                            {
                                drrIcu = dtICU.Select("registerid_chr = '" + regId2 + "' and chargeactive_dat >= '" + vo2.beginDate.ToString() + "'");
                            }
                            else
                            {
                                drrIcu = dtICU.Select("registerid_chr = '" + regId2 + "' and chargeactive_dat >= '" + vo2.beginDate.ToString() + "' and  chargeactive_dat <= '" + vo2.endDate.Value + "'");
                            }
                            if (drrIcu != null && drrIcu.Length > 0)
                            {
                                totalsum = 0;
                                foreach (DataRow dr2 in drrIcu)
                                {
                                    pchargeId = dr2["pchargeid_chr"].ToString();
                                    if (lstPChargeId1.IndexOf(pchargeId) < 0)
                                    {
                                        totalsum += Convert.ToDecimal(dr2["catsum"]);
                                        lstPChargeId1.Add(pchargeId);
                                        lstDelRow.Add(dr2);
                                    }
                                }
                                drr = dtSum.Select("shortno_chr = '" + vo2.sourceDeptId + "'");
                                if (drr != null && drr.Length > 0)
                                {
                                    totalsum += Convert.ToDecimal(drr[0]["totalsum"]);
                                    foreach (DataRow dr3 in drr)
                                    {
                                        dr3["totalsum"] = totalsum;
                                    }
                                    foreach (DataRow dr2 in drrIcu)
                                    {
                                        pchargeId = dr2["pchargeid_chr"].ToString();
                                        if (lstPChargeId2.IndexOf(pchargeId) < 0)
                                        {
                                            drr = dtSum.Select("shortno_chr = '" + vo2.sourceDeptId + "' and groupid_chr = '" + dr2["groupid_chr"].ToString() + "'");
                                            if (drr != null && drr.Length > 0)
                                            {
                                                drr[0]["catsum"] = Convert.ToDecimal(drr[0]["catsum"]) + Convert.ToDecimal(dr2["catsum"]);
                                            }
                                            else
                                            {
                                                dtSum.LoadDataRow(new object[6] { vo2.sourceDeptId, vo2.sourceDeptName, totalsum, dr2["groupid_chr"].ToString(), dr2["groupname_chr"].ToString(), Convert.ToDecimal(dr2["catsum"]) }, true);
                                            }
                                            lstPChargeId1.Add(pchargeId);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (DataRow dr2 in drrIcu)
                                    {
                                        pchargeId = dr2["pchargeid_chr"].ToString();
                                        if (lstPChargeId2.IndexOf(pchargeId) < 0)
                                        {
                                            dtSum.LoadDataRow(new object[6] { vo2.sourceDeptId, vo2.sourceDeptName, totalsum, dr2["groupid_chr"].ToString(), dr2["groupname_chr"].ToString(), Convert.ToDecimal(dr2["catsum"]) }, true);
                                            lstPChargeId1.Add(pchargeId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (DataRow dr3 in lstDelRow)
                    {
                        dtICU.Rows.Remove(dr3);

                    }
                    dtICU.AcceptChanges();
                    if (dtICU.Rows.Count > 0)
                    {
                        totalsum = 0;
                        foreach (DataRow dr2 in dtICU.Rows)
                        {
                            totalsum += Convert.ToDecimal(dr2["catsum"]);
                        }
                        drr = dtSum.Select("shortno_chr = '" + icuDeptCode + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            totalsum += Convert.ToDecimal(drr[0]["totalsum"]);
                            foreach (DataRow dr3 in drr)
                            {
                                dr3["totalsum"] = totalsum;
                            }
                            foreach (DataRow dr2 in dtICU.Rows)
                            {
                                drr = dtSum.Select("shortno_chr = '" + icuDeptCode + "' and groupid_chr = '" + dr2["groupid_chr"].ToString() + "'");
                                if (drr != null && drr.Length > 0)
                                {
                                    drr[0]["catsum"] = Convert.ToDecimal(drr[0]["catsum"]) + Convert.ToDecimal(dr2["catsum"]);
                                }
                                else
                                {
                                    dtSum.LoadDataRow(new object[6] { icuDeptCode, dr2["deptname_vchr"].ToString(), totalsum, dr2["groupid_chr"].ToString(), dr2["groupname_chr"].ToString(), Convert.ToDecimal(dr2["catsum"]) }, true);
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr2 in dtICU.Rows)
                            {
                                dtSum.LoadDataRow(new object[6] { icuDeptCode, dr2["deptname_vchr"].ToString(), totalsum, dr2["groupid_chr"].ToString(), dr2["groupname_chr"].ToString(), Convert.ToDecimal(dr2["catsum"]) }, true);
                            }
                        }
                    }
                }
                dtSum.AcceptChanges();

                svc.AddCharegToTable(dtSum, Convert.ToDateTime(BeginDate).ToString("yyyyMM"));
                string sql = @"select shortno_chr,
                                       deptname_vchr,
                                       totalsum,
                                       groupid_chr,
                                       groupname_chr,
                                       catsum
                                  from t_rpt_cross1";
                dwRep.SetSqlSelect(sql);
                //dwRep.SetRedrawOff();
                dwRep.Retrieve();
                dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " 00:00:00 - " + EndDate + " 23:59:59'");
                // dwRep.SetRedrawOn();
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(ex);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #region  事件
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.QueryDeptCharge();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList frmAidDeptList = new frmAidDeptList();
            if (frmAidDeptList.ShowDialog() == DialogResult.OK)
            {
                this.DeptIDArr = frmAidDeptList.DeptIDArr;
            }
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

        #region 汇总
        private void btnSum_Click(object sender, EventArgs e)
        {
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));

            DataTable dt01 = svc.GetRptCross("201701");
            DataTable dt02 = svc.GetRptCross("201702");
            DataTable dt03 = svc.GetRptCross("201703");
            DataTable dt04 = svc.GetRptCross("201704");
            DataTable dt05 = svc.GetRptCross("201705");
            DataTable dt06 = svc.GetRptCross("201706");
            DataTable dt07 = svc.GetRptCross("201707");
            DataTable dt08 = svc.GetRptCross("201708");
            DataTable dt09 = svc.GetRptCross("201709");
            DataTable dt10 = svc.GetRptCross("201710");
            DataTable dt11 = svc.GetRptCross("201711");
            DataTable dt12 = svc.GetRptCross("201712");
            DataTable dtSum = svc.GetRptCross("");

            string deptCode = string.Empty;
            List<string> lstDeptCode = new List<string>();
            decimal totalsum = 0;
            DataRow[] drr = null;
            DataRow[] drrDept = null;
            List<DataTable> lstTable = new List<DataTable>() { dt01, dt02, dt03, dt04, dt05, dt06, dt07, dt08, dt09, dt10, dt11, dt12 };
            foreach (DataTable dt in lstTable)
            {
                if (dt.Rows.Count == 0) continue;
                lstDeptCode.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    deptCode = dr["shortno_chr"].ToString();
                    if (lstDeptCode.IndexOf(deptCode) < 0) lstDeptCode.Add(deptCode);
                }

                foreach (string _deptCode in lstDeptCode)
                {
                    drrDept = dt.Select("shortno_chr = '" + _deptCode + "'");
                    totalsum = Convert.ToDecimal(drrDept[0]["totalsum"]);
                    drr = dtSum.Select("shortno_chr = '" + _deptCode + "'");
                    if (drr != null && drr.Length > 0)
                    {
                        totalsum += Convert.ToDecimal(drr[0]["totalsum"]);
                        foreach (DataRow dr2 in drr)
                        {
                            dr2["totalsum"] = totalsum;
                        }
                        foreach (DataRow dr2 in drrDept)
                        {
                            DataRow[] drrCat = dtSum.Select("shortno_chr = '" + _deptCode + "' and groupid_chr = '" + dr2["groupid_chr"].ToString() + "'");
                            if (drrCat != null && drrCat.Length > 0)
                            {
                                drrCat[0]["catsum"] = Convert.ToDecimal(drrCat[0]["catsum"]) + Convert.ToDecimal(dr2["catsum"]);
                            }
                            else
                            {
                                dtSum.LoadDataRow(new object[6] { _deptCode, dr2["deptname_vchr"].ToString(), totalsum, dr2["groupid_chr"].ToString(), dr2["groupname_chr"].ToString(), Convert.ToDecimal(dr2["catsum"]) }, true);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr2 in drrDept)
                        {
                            dtSum.LoadDataRow(new object[6] { _deptCode, dr2["deptname_vchr"].ToString(), totalsum, dr2["groupid_chr"].ToString(), dr2["groupname_chr"].ToString(), Convert.ToDecimal(dr2["catsum"]) }, true);
                        }
                    }
                }
            }

            svc.SaveCrossSum(dtSum);
            string sql = @"select shortno_chr,
                                       deptname_vchr,
                                       totalsum,
                                       groupid_chr,
                                       groupname_chr,
                                       catsum
                                  from t_rpt_cross2017";
            dwRep.SetSqlSelect(sql);
            dwRep.Retrieve();
            dwRep.Modify("t_date.text = '统计时间: " + "2017-01-01 00:00:00 - 2017-12-31 23:59:59'");


        }
        #endregion

    }
}
