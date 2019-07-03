using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 出院带药处方打印
    /// </summary>
    public partial class frmChooseRecipe : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="_patVo"></param>
        public frmChooseRecipe(clsBIHPatientInfo _patVo, DataTable _dtMed)
        {
            InitializeComponent();
            patVo = _patVo;
            dtMed = _dtMed;
        }
        #endregion

        #region 变量

        clsBIHPatientInfo patVo { get; set; }

        DataTable dtMed { get; set; }

        internal System.Drawing.Printing.PrintDocument printDoc = null;

        #endregion

        #region 事件

        private void frmChooseRecipe_Load(object sender, EventArgs e)
        {
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printDoc.BeginPrint += printDoc_BeginPrint;
            this.printDoc.PrintPage += printDoc_PrintPage;

            List<CheckBox> lstChk = new List<CheckBox>();
            DataRow[] drr = null;
            drr = dtMed.Select("medicinetypeid_chr = '2'");
            if (drr != null && drr.Length > 0)
            {
                this.chk1.Enabled = true;
                lstChk.Add(this.chk1);
            }
            drr = dtMed.Select("medicinetypeid_chr = '1'");
            if (drr != null && drr.Length > 0)
            {
                this.chk2.Enabled = true;
                lstChk.Add(this.chk2);
                string recipeNo = string.Empty;
                List<string> lstRecipeNo = new List<string>();
                foreach (DataRow dr in drr)
                {
                    recipeNo = dr["recipeno_int"].ToString();
                    if (lstRecipeNo.IndexOf(recipeNo) < 0)
                    {
                        lstRecipeNo.Add(recipeNo);
                        this.cboZyRecipeNo.Items.Add(recipeNo);
                    }
                }
                this.cboZyRecipeNo.Text = lstRecipeNo[0];
            }
            drr = dtMed.Select("ispoison_chr = '1'");
            if (drr != null && drr.Length > 0)
            {
                this.chk3.Enabled = true;
                lstChk.Add(this.chk3);
            }
            drr = dtMed.Select("isanaesthesia_chr = '1'");
            if (drr != null && drr.Length > 0)
            {
                this.chk4.Enabled = true;
                lstChk.Add(this.chk4);
            }
            drr = dtMed.Select("ischlorpromazine_chr = '1'");
            if (drr != null && drr.Length > 0)
            {
                this.chk5.Enabled = true;
                lstChk.Add(this.chk5);
            }
            drr = dtMed.Select("ischlorpromazine2_chr = '1'");
            if (drr != null && drr.Length > 0)
            {
                this.chk6.Enabled = true;
                lstChk.Add(this.chk6);
            }
            if (this.patVo.m_intAge < 12)
            {
                this.chk7.Checked = true;
                lstChk.Add(this.chk7);
            }
            if (lstChk.Count > 0)
            {
                lstChk[0].Checked = true;
                if (this.cboZyRecipeNo.Items.Count > 1)
                {
                }
                else
                {
                    btnPrintOrder_Click(null, null);
                    if (lstChk.Count == 1) this.Close();
                }
            }
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk1.Checked)
            {
                this.chk2.Checked = false;
                this.chk3.Checked = false;
                this.chk4.Checked = false;
                this.chk5.Checked = false;
                this.chk6.Checked = false;
                this.chk7.Checked = false;
            }
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk2.Checked)
            {
                this.chk1.Checked = false;
                this.chk3.Checked = false;
                this.chk4.Checked = false;
                this.chk5.Checked = false;
                this.chk6.Checked = false;
                this.chk7.Checked = false;
            }
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk3.Checked)
            {
                this.chk1.Checked = false;
                this.chk2.Checked = false;
                this.chk4.Checked = false;
                this.chk5.Checked = false;
                this.chk6.Checked = false;
                this.chk7.Checked = false;
            }
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk4.Checked)
            {
                this.chk1.Checked = false;
                this.chk2.Checked = false;
                this.chk3.Checked = false;
                this.chk5.Checked = false;
                this.chk6.Checked = false;
                this.chk7.Checked = false;
            }
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk5.Checked)
            {
                this.chk1.Checked = false;
                this.chk2.Checked = false;
                this.chk3.Checked = false;
                this.chk4.Checked = false;
                this.chk6.Checked = false;
                this.chk7.Checked = false;
            }
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk6.Checked)
            {
                this.chk1.Checked = false;
                this.chk2.Checked = false;
                this.chk3.Checked = false;
                this.chk4.Checked = false;
                this.chk5.Checked = false;
                this.chk7.Checked = false;
            }
        }

        private void chk7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk7.Checked)
            {
                this.chk1.Checked = false;
                this.chk2.Checked = false;
                this.chk3.Checked = false;
                this.chk4.Checked = false;
                this.chk5.Checked = false;
                this.chk6.Checked = false;
            }
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            this.PrintRecipe();
        }

        private void frmChooseRecipe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 打印带药处方
        /// <summary>
        /// 打印带药处方
        /// </summary>
        internal void PrintRecipe()
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (item.Contains("出院带药"))
                {
                    this.printDoc.PrinterSettings.PrinterName = item;
                    break;
                }
            }
            ppd.Document = this.printDoc;
            ppd.PrintPreviewControl.AutoZoom = true;
            ((Form)ppd).Size = new Size(1024, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);
            ((Form)ppd).StartPosition = FormStartPosition.CenterScreen;
            ppd.ShowDialog();
        }

        com.digitalwave.iCare.middletier.HI.clsFoShanSendMedicinePrint ReportPrint = null;

        private void printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ReportPrint = new com.digitalwave.iCare.middletier.HI.clsFoShanSendMedicinePrint();
            ReportPrint.PrintRecipeVOInfo = PrintRecipeData();
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (ReportPrint == null || ReportPrint.PrintRecipeVOInfo == null) return;
            ReportPrint.DrawObject = e;
            ReportPrint.m_mthBegionPrint("1");
        }

        /// <summary>
        /// 打印带药处方
        /// </summary>
        /// <returns></returns>
        public clsOutpatientPrintRecipe_VO PrintRecipeData()
        {
            string registerId = patVo.m_strRegisterID;
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable dtPat = svc.GetOutPatient(patVo.m_strPatientID);
            int rowNo = 0;
            decimal totalMny = 0;
            DataView dvMed = new DataView(dtMed);
            clsOutpatientPrintRecipe_VO vo = null;
            clsOutpatientPrintRecipeDetail_VO subItem = null;

            #region 主信息

            DataRow drPat = dtPat.Rows[0];
            vo = new clsOutpatientPrintRecipe_VO();
            vo.stroutpatrecipeMoney = "";
            vo.m_strMatCost = "";
            vo.m_strTimes = "";
            vo.m_strHerbalmedicineUsage = "";
            vo.strCheckName = "";
            vo.strDosageName = "";
            vo.strMedMoney = "";
            vo.strInvoiceNO = "/";
            vo.m_strPhotoNo = patVo.m_strHOMEPHONE_VCHR;
            vo.m_strAge = patVo.m_strAge;
            vo.m_strIDcardno = drPat["idcard_chr"].ToString();
            vo.strCheckOutName = "";
            vo.m_strCardID = patVo.m_strInHospitalNo;   // 住院号
            vo.m_strRecipePrice = "";
            vo.m_strPatientType = patVo.m_strPayTypeName;
            vo.m_strPrintDate = DateTime.Now.ToShortDateString();
            vo.m_strRecipeID = "00000000" + DateTime.Now.ToString("yyMMddHHmm");
            vo.m_strSerNO = "";
            vo.m_intRecipeCount = 1;

            vo.m_strRecipeDate = "";
            vo.m_strSex = patVo.m_strSex;
            vo.m_strPatientName = patVo.m_strPatientName;
            vo.m_strdiagnose = patVo.m_strDiagnose;
            vo.m_strAddress = drPat["homeaddress_vchr"].ToString();
            vo.m_strHospitalName = "";
            vo.m_strGOVCARD = drPat["govcard_chr"].ToString();
            vo.m_strDiagDrName = patVo.m_strDOCTOR_VCHR;
            vo.m_strDiagDeptID = patVo.m_strDeptName + "(" + patVo.m_strBedName + "床)";
            vo.m_strINSURANCEID = drPat["insuranceid_vchr"].ToString();
            vo.objPRDArr = new System.Collections.ArrayList();
            vo.strSendMedStorage = "";
            vo.m_strSendMedWindow = "";
            vo.strOutpatrecipeNO = registerId;
            vo.objPRDArr2 = new System.Collections.ArrayList();
            vo.objPRDArr3 = new System.Collections.ArrayList();
            vo.objTreatArr = new ArrayList();

            #endregion

            bool isCM = false;
            if (this.chk1.Checked)
            {
                vo.m_strRectype = "普通";
                dvMed.RowFilter = "medicinetypeid_chr = '2'";
            }
            else if (this.chk2.Checked)
            {
                isCM = true;
                vo.m_strRectype = "中药";
                dvMed.RowFilter = "medicinetypeid_chr = '1' and recipeno_int = " + this.cboZyRecipeNo.Text;
            }
            else if (this.chk3.Checked)
            {
                vo.m_strRectype = "易制毒";
                dvMed.RowFilter = "ispoison_chr = '1'";
            }
            else if (this.chk4.Checked)
            {
                vo.m_strRectype = "麻醉";
                dvMed.RowFilter = "isanaesthesia_chr = '1'";
            }
            else if (this.chk5.Checked)
            {
                vo.m_strRectype = "精神一类";
                dvMed.RowFilter = "ischlorpromazine_chr = '1'";
            }
            else if (this.chk6.Checked)
            {
                vo.m_strRectype = "精神二类";
                dvMed.RowFilter = "ischlorpromazine2_chr = '1'";
            }
            else if (this.chk7.Checked)
            {
                vo.m_strRectype = "儿科";
                dvMed.RowFilter = "medicinetypeid_chr = '2'";
            }

            if (dvMed.Count > 0)
            {
                // 出院带药: 存在别医师代替管床医师开药情况，处方上医师需改用"开单医师(提交人)" 。
                if (dvMed[0]["poster_chr"] != DBNull.Value && dvMed[0]["poster_chr"].ToString().Trim() != string.Empty)
                {
                    patVo.m_strDOCTOR_VCHR = dvMed[0]["poster_chr"].ToString().Trim();
                }
            }

            #region 西药

            if (isCM == false)
            {               
                vo.m_strRecipeDate = Convert.ToDateTime(dvMed[0]["postdate_dat"].ToString()).ToString("yyyy-MM-dd");
                vo.strSendMedStorage = "中心药房";
                rowNo = 0;
                totalMny = 0;
                for (int i = 0; i < dvMed.Count; i++)
                {
                    DataRowView drv = dvMed[i];
                    subItem = new clsOutpatientPrintRecipeDetail_VO();
                    // 西药
                    subItem.m_strDosageUnit = drv["dosageunit_chr"].ToString();
                    subItem.m_strChargeName = drv["medicinename_vchr"].ToString();
                    subItem.m_strMEDNORMALNAME = drv["mednormalname_vchr"].ToString();
                    subItem.m_strCount = drv["get_dec"].ToString();
                    subItem.m_strDays = drv["outgetmeddays_int"].ToString();
                    subItem.m_strDosage = drv["dosage_dec"].ToString();
                    subItem.m_strFrequency = drv["execfreqname_chr"].ToString().Trim();
                    subItem.m_strSpec = drv["spec_vchr"].ToString();
                    subItem.m_strSumPrice = drv["totalmny"].ToString();
                    subItem.m_strUnit = drv["getunit_chr"].ToString().Trim();
                    subItem.m_strUsage = drv["dosetypename_chr"].ToString().Trim();//drv["opusagedesc"].ToString() + " " + drv["opfredesc_vchr"].ToString();
                    if (i == 0)
                    {
                        subItem.m_strRowNo = Convert.ToString(++rowNo);
                    }
                    else
                    {
                        if (drv["parentid_chr"] != DBNull.Value && drv["parentid_chr"].ToString() == dvMed[i - 1]["orderid_chr"].ToString())
                        {
                            subItem.m_strRowNo = rowNo.ToString();
                        }
                        else
                        {
                            subItem.m_strRowNo = Convert.ToString(++rowNo);
                        }
                    }
                    subItem.m_strFreqDays = drv["days_int"].ToString();
                    subItem.m_strFreqTimes = drv["times_int"].ToString();
                    subItem.m_strBasicDosage = subItem.m_strDosage;
                    subItem.m_strOPFreqDesc = drv["opfredesc_vchr"].ToString();
                    subItem.m_strOPUsageDesc = drv["opusagedesc"].ToString();
                    subItem.m_strItemIPUnit_chr = drv["dosageunit_chr"].ToString();
                    subItem.m_intPuted = 1;
                    vo.objPRDArr.Add(subItem);
                    totalMny += clsPublic.ConvertObjToDecimal(subItem.m_strSumPrice);
                }
                vo.stroutpatrecipeMoney = totalMny.ToString();
                vo.strMedMoney = totalMny.ToString();
                vo.m_strRecipePrice = totalMny.ToString();
            }
            #endregion

            #region 中药
            vo.objPRDArr2 = new System.Collections.ArrayList();
            vo.objPRDArr3 = new System.Collections.ArrayList();
            vo.objTreatArr = new ArrayList();

            if (isCM)
            {
                vo.m_strRecipeDate = Convert.ToDateTime(dvMed[0]["postdate_dat"].ToString()).ToString("yyyy-MM-dd");
                vo.strSendMedStorage = "门诊药房";
                rowNo = 0;
                totalMny = 0;
                int fs = 0;
                foreach (DataRowView drv in dvMed)
                {
                    subItem = new clsOutpatientPrintRecipeDetail_VO();
                    // 中药
                    subItem.m_strChargeName = drv["medicinename_vchr"].ToString();
                    subItem.m_strMEDNORMALNAME = drv["mednormalname_vchr"].ToString();
                    subItem.m_strCount = drv["get_dec"].ToString();
                    subItem.m_strDays = drv["outgetmeddays_int"].ToString();
                    subItem.m_strDosage = drv["dosage_dec"].ToString();
                    subItem.m_strFrequency = drv["execfreqname_chr"].ToString();
                    subItem.m_strSpec = drv["spec_vchr"].ToString();
                    subItem.m_strSumPrice = drv["totalmny"].ToString();
                    subItem.m_strUnit = drv["getunit_chr"].ToString();
                    subItem.m_strUsage = drv["dosetypename_chr"].ToString().Trim(); //drv["opusagedesc"].ToString() + " " + drv["opfredesc_vchr"].ToString();
                    //subItem.m_strUsageDetail = drv["dosetypename_chr"].ToString();
                    subItem.m_strBasicDosage = subItem.m_strDosage;
                    subItem.m_strOPFreqDesc = drv["opfredesc_vchr"].ToString();
                    subItem.m_strOPUsageDesc = drv["opusagedesc"].ToString();
                    subItem.m_strItemIPUnit_chr = drv["dosageunit_chr"].ToString();
                    if (drv["remark_vchr"] != DBNull.Value && !string.IsNullOrEmpty(drv["remark_vchr"].ToString()))
                    {
                        subItem.m_strUsage = drv["remark_vchr"].ToString().Trim();
                    }
                    subItem.m_intPuted = 1;
                    vo.objPRDArr2.Add(subItem);
                    totalMny += clsPublic.ConvertObjToDecimal(subItem.m_strSumPrice);
                    if (fs == 0 && Convert.ToDecimal(drv["dosage_dec"].ToString()) > 0)
                    {
                        fs = Convert.ToInt32(Convert.ToDecimal(drv["get_dec"].ToString()) / Convert.ToDecimal(drv["dosage_dec"].ToString()));
                    }
                }
                vo.stroutpatrecipeMoney = totalMny.ToString();
                vo.strMedMoney = totalMny.ToString();
                vo.m_strRecipePrice = totalMny.ToString();
                vo.m_strTimes = (fs > 0 ? fs.ToString() : "");
            }
            #endregion

            return vo;
        }
        #endregion

    }
}
