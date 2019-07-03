using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmStatSampleBcak : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmStatSampleBcak()
        {
            InitializeComponent();
        }

        #region 事件
        private void frmStatSampleBcak_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_sampleback_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01" + " 00:00:01");
            this.cboPatType.Items.AddRange(new object[] { "住院", "门诊" });
            init();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Query2();
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

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            m_mthExportToExcel();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 方法

        #region Query
        /// <summary>
        /// Query
        /// </summary>
        internal void Query()
        {
            List<entitySample> data = new List<entitySample>();
            string beginDate = string.Empty;
            string endDate = string.Empty;
            string type = string.Empty;

            entitySample vo1 = new entitySample();
            vo1.KS = "内一";
            entitySample vo2 = new entitySample();
            vo2.KS = "内二";
            entitySample vo3 = new entitySample();
            vo3.KS = "妇科";
            entitySample vo4 = new entitySample();
            vo4.KS = "产科";
            entitySample vo5 = new entitySample();
            vo5.KS = "手外";
            entitySample vo6 = new entitySample();
            vo6.KS = "普外";
            entitySample vo7 = new entitySample();
            vo7.KS = "泌尿";
            entitySample vo8 = new entitySample();
            vo8.KS = "神外";
            entitySample vo9 = new entitySample();
            vo9.KS = "骨外";
            entitySample vo10 = new entitySample();
            vo10.KS = "ICU";
            entitySample vo11 = new entitySample();
            vo11.KS = "普儿";
            entitySample vo12 = new entitySample();
            vo12.KS = "NICU";
            entitySample vo13 = new entitySample();
            vo13.KS = "中医";
            entitySample vo14 = new entitySample();
            vo14.KS = "耳鼻喉+眼科";
            entitySample vo15 = new entitySample();
            vo15.KS = "消化内科";
            entitySample vo16 = new entitySample();
            vo16.KS = "急诊";
            entitySample vo17 = new entitySample();
            vo17.KS = "门诊";
            entitySample vo18 = new entitySample();
            vo18.KS = "体检科";
            entitySample vo19 = new entitySample();
            vo19.KS = "全院合计";
            entitySample vo20 = new entitySample();
            vo20.KS = "所占比例(%)";
            entitySample vo21 = new entitySample();
            vo21.KS = "发生率(%)";
            data.Add(vo1);
            data.Add(vo2);
            data.Add(vo3);
            data.Add(vo4);
            data.Add(vo5);
            data.Add(vo6);
            data.Add(vo7);
            data.Add(vo8);
            data.Add(vo9);
            data.Add(vo10);
            data.Add(vo11);
            data.Add(vo12);
            data.Add(vo13);
            data.Add(vo14);
            data.Add(vo15);
            data.Add(vo16);
            data.Add(vo17);
            data.Add(vo18);
            data.Add(vo19);
            data.Add(vo20);
            data.Add(vo21);


            beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            endDate = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");
            type = cboSampleType.Text.Trim(); 

            if (Convert.ToDateTime(beginDate + " :01") > Convert.ToDateTime(endDate + ":59"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                dwRep.Reset();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetStatSampleBack(beginDate, endDate, type,cboPatType.SelectedIndex);

                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        string deptCode = dr["code_vchr"].ToString();
                        string deptArea = JudgeDept(deptCode);

                        for (int i = 0; i < data.Count-1; i++)
                        {
                            if (deptArea == data[i].KS)
                            {
                                string reasonStr = dr["sample_back_reason_vchr"].ToString().Trim();
                                string sampleType = dr["sampletype_vchr"].ToString().Trim();

                                data[i].BBZLHJ += 1;

                                if (reasonStr.Contains("溶血"))
                                    data[i].RX += 1;
                                else if (reasonStr.Contains("标本量"))
                                    data[i].BFLBZQ += 1;
                                else if (reasonStr.Contains("凝固"))
                                    data[i].NG += 1;
                                else if (reasonStr.Contains("资料不相符"))
                                    data[i].BFZLBF += 1;
                                else if (reasonStr.Contains("取消"))
                                    data[i].QXBZ += 1;
                                else if (reasonStr.Contains("用错"))
                                    data[i].YCSG += 1;
                                else if (reasonStr.Contains("无标本"))
                                    data[i].WBB += 1;
                                else if (reasonStr.Contains("无送唐氏单"))
                                    data[i].WSTSD += 1;
                                else if (reasonStr.Contains("条码无效"))
                                    data[i].TMWX += 1;
                                else if (reasonStr.Contains("仪器故障"))
                                    data[i].YJGZ += 1;
                                else if (reasonStr.Contains("结果异常"))
                                    data[i].JGYC += 1;
                                else if (reasonStr.Contains("重复开单"))
                                    data[i].CFKD += 1;
                                else if (reasonStr.Contains("标本类型不正确"))
                                    data[i].BBLXBZQ += 1;
                                else if (reasonStr.Contains("血气标本有气泡"))
                                    data[i].XQBBYQB += 1;
                                else if (dr["sampletype_vchr"].ToString().Trim() == "痰" && reasonStr != "")
                                    data[i].TBBBJG += 1;
                                else if (reasonStr != "")
                                    data[i].QTYY += 1;

                                data[i].BHGBBHJ = data[i].RX + data[i].BFLBZQ + data[i].NG + data[i].BFZLBF + data[i].QXBZ
                                    + data[i].YCSG + data[i].WBB + data[i].TBBBJG + data[i].QTYY + data[i].WSTSD + data[i].TMWX
                                    + data[i].YJGZ + data[i].JGYC + data[i].CFKD;

                                if (sampleType == "全血" || sampleType == "血清" || sampleType == "血浆" ||
                                    sampleType == "动脉血" || sampleType == "红细胞")
                                    data[i].XBBZL += 1;
                                else
                                    data[i].FXBBZL += 1;

                                if ((sampleType == "全血" || sampleType == "血清" || sampleType == "血浆" ||
                                    sampleType == "动脉血" || sampleType == "红细胞") && !string.IsNullOrEmpty(reasonStr))
                                    data[i].XBBBHGS += 1;
                                else if (!string.IsNullOrEmpty(reasonStr))
                                    data[i].FXBBBHGS += 1;
                               
                                break;
                            }
                        }
                    }

                    for (int i = 0; i < data.Count-2; i++)
                    {
                        if (i < data.Count - 3)
                        {
                            data[data.Count - 3].RX += data[i].RX;
                            data[data.Count - 3].BFLBZQ += data[i].BFLBZQ;
                            data[data.Count - 3].NG += data[i].NG;
                            data[data.Count - 3].BFZLBF += data[i].BFZLBF;
                            data[data.Count - 3].QXBZ += data[i].QXBZ;
                            data[data.Count - 3].YCSG += data[i].YCSG;
                            data[data.Count - 3].WBB += data[i].WBB;
                            data[data.Count - 3].TBBBJG += data[i].TBBBJG;
                            data[data.Count - 3].QTYY += data[i].QTYY;
                            data[data.Count - 3].BHGBBHJ += data[i].BHGBBHJ;
                            data[data.Count - 3].XBBZL += data[i].XBBZL;
                            data[data.Count - 3].XBBBHGS += data[i].XBBBHGS;
                            data[data.Count - 3].FXBBBHGS += data[i].FXBBBHGS;
                            data[data.Count - 3].FXBBZL += data[i].FXBBZL;
                            data[data.Count - 3].BBZLHJ += data[i].BBZLHJ;

                            data[data.Count - 3].WSTSD += data[i].WSTSD;
                            data[data.Count - 3].TMWX += data[i].TMWX;
                            data[data.Count - 3].YJGZ += data[i].YJGZ;
                            data[data.Count - 3].JGYC += data[i].JGYC;
                            data[data.Count - 3].CFKD += data[i].CFKD;
                            data[data.Count - 3].BBLXBZQ += data[i].BBLXBZQ;
                            data[data.Count - 3].XQBBYQB += data[i].XQBBYQB;

                            if (data[data.Count - 3].XBBBHGS > 0 && data[data.Count - 3].XBBZL > 0)
                                data[data.Count - 3].XBBBHGL = Math.Round(((double)data[data.Count - 3].XBBBHGS / (double)data[data.Count - 3].XBBZL) * 100, 2).ToString();
                            if (data[data.Count - 3].FXBBBHGS > 0 && data[data.Count - 3].FXBBZL > 0)
                                data[data.Count - 3].FXBBBHGL = Math.Round(((double)data[data.Count - 3].FXBBBHGS / (double)data[data.Count - 3].FXBBZL) * 100, 2).ToString();
                            if (data[data.Count - 3].BHGBBHJ > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 3].SYBBBHGL = Math.Round(((double)data[data.Count - 3].BHGBBHJ / (double)data[data.Count - 3].BBZLHJ) * 100, 2).ToString();
                        }
                        else
                        {
                            if (data[data.Count - 3].RX > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].RX = Math.Round(((double)data[data.Count - 3].RX / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].BFLBZQ > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].BFLBZQ = Math.Round(((double)data[data.Count - 3].BFLBZQ / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].NG > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].NG = Math.Round(((double)data[data.Count - 3].NG / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].BFZLBF > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].BFZLBF = Math.Round(((double)data[data.Count - 3].BFZLBF / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].QXBZ > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].QXBZ = Math.Round(((double)data[data.Count - 3].QXBZ / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].YCSG > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].YCSG = Math.Round(((double)data[data.Count - 3].YCSG / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].WBB > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].WBB = Math.Round(((double)data[data.Count - 3].WBB / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].TBBBJG > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].TBBBJG = Math.Round(((double)data[data.Count - 3].TBBBJG / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].QTYY > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].QTYY = Math.Round(((double)data[data.Count - 3].QTYY / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].CFKD > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].CFKD = Math.Round(((double)data[data.Count - 3].CFKD / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].WSTSD > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].WSTSD = Math.Round(((double)data[data.Count - 3].WSTSD / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].TMWX > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].TMWX = Math.Round(((double)data[data.Count - 3].YJGZ / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].YJGZ > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].YJGZ = Math.Round(((double)data[data.Count - 3].YJGZ / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].JGYC > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].JGYC = Math.Round(((double)data[data.Count - 3].JGYC / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].BBLXBZQ > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].BBLXBZQ = Math.Round(((double)data[data.Count - 3].BBLXBZQ / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);
                            if (data[data.Count - 3].XQBBYQB > 0 && data[data.Count - 3].BHGBBHJ > 0)
                                data[data.Count - 2].XQBBYQB = Math.Round(((double)data[data.Count - 3].XQBBYQB / (double)data[data.Count - 3].BHGBBHJ) * 100, 2);


                            if (data[data.Count - 3].RX > 0 && data[data.Count - 3].XBBZL > 0)
                                data[data.Count - 1].RX = Math.Round(((double)data[data.Count - 3].RX / (double)data[data.Count - 3].XBBZL) * 100, 2);
                            if (data[data.Count - 3].BFLBZQ > 0 && data[data.Count - 3].XBBZL > 0)
                                data[data.Count - 1].BFLBZQ = Math.Round(((double)data[data.Count - 3].BFLBZQ / (double)data[data.Count - 3].XBBZL) * 100, 2);
                            if (data[data.Count - 3].NG > 0 && data[data.Count - 3].XBBZL > 0)
                                data[data.Count - 1].NG = Math.Round(((double)data[data.Count - 3].NG / (double)data[data.Count - 3].XBBZL) * 100, 2);
                            if (data[data.Count - 3].YCSG > 0 && data[data.Count - 3].XBBZL > 0)
                                data[data.Count - 1].YCSG = Math.Round(((double)data[data.Count - 3].YCSG / (double)data[data.Count - 3].XBBZL) * 100, 2);
                            if (data[data.Count - 3].BFZLBF > 0 && data[data.Count - 3].BBZLHJ > 0)
                                data[data.Count - 1].BFZLBF = Math.Round(((double)data[data.Count - 3].BFZLBF / (double)data[data.Count - 3].BBZLHJ) * 100, 2);
                            if (data[data.Count - 3].WBB > 0 && data[data.Count - 3].BBZLHJ > 0)
                                data[data.Count - 1].WBB = Math.Round(((double)data[data.Count - 3].WBB / (double)data[data.Count - 3].BBZLHJ) * 100, 2);
                            if (data[data.Count - 3].QXBZ > 0 && data[data.Count - 3].BBZLHJ > 0)
                                data[data.Count - 1].QXBZ = Math.Round(((double)data[data.Count - 3].QXBZ / (double)data[data.Count - 3].BBZLHJ) * 100, 2);
                            if (data[data.Count - 3].CFKD > 0 && data[data.Count - 3].BBZLHJ > 0)
                                data[data.Count - 1].CFKD = Math.Round(((double)data[data.Count - 3].CFKD / (double)data[data.Count - 3].BBZLHJ) * 100, 2);
                            if (data[data.Count - 3].BBLXBZQ > 0 && data[data.Count - 3].BBZLHJ > 0)
                                data[data.Count - 1].BBLXBZQ = Math.Round(((double)data[data.Count - 3].BBLXBZQ / (double)data[data.Count - 3].BBZLHJ) * 100, 2);
                            if (data[data.Count - 3].XQBBYQB > 0 && data[data.Count - 3].BBZLHJ > 0)
                                data[data.Count - 1].XQBBYQB = Math.Round(((double)data[data.Count - 3].XQBBYQB / (double)data[data.Count - 3].BBZLHJ) * 100, 2);
                        }

                        if (data[i].XBBBHGS > 0 && data[i].XBBZL > 0)
                            data[i].XBBBHGL = Math.Round(((double)data[i].XBBBHGS / (double)data[i].XBBZL) * 100, 2).ToString();

                        if (data[i].FXBBBHGS > 0 && data[i].FXBBZL > 0)
                            data[i].FXBBBHGL = Math.Round(((double)data[i].FXBBBHGS / (double)data[i].FXBBZL) * 100, 2).ToString();

                        if (data[i].BHGBBHJ > 0 && data[i].BHGBBHJ > 0)
                            data[i].SYBBBHGL = Math.Round(((double)data[i].BHGBBHJ / (double)data[i].BBZLHJ) * 100, 2).ToString();
                    }

                    int row = 0;
                    dwRep.SetRedrawOff();

                    for (int i = 0; i < data.Count; i++)
                    {
                        row = dwRep.InsertRow(0);

                        dwRep.SetItemString(row, "ks", data[i].KS );
                        dwRep.SetItemString(row, "rx", data[i].RX > 0 ? data[i].RX.ToString() : "");
                        dwRep.SetItemString(row, "bflbzq", data[i].BFLBZQ > 0 ? data[i].BFLBZQ.ToString() : "");
                        dwRep.SetItemString(row, "ng", data[i].NG > 0 ? data[i].NG.ToString() : "");
                        dwRep.SetItemString(row, "bfzlbf", data[i].BFZLBF > 0  ? data[i].BFZLBF.ToString() : "");
                        dwRep.SetItemString(row, "qxbz", data[i].QXBZ > 0 ? data[i].QXBZ.ToString() : "");
                        dwRep.SetItemString(row, "ycsg", data[i].YCSG >  0 ? data[i].YCSG.ToString()  : "");
                        dwRep.SetItemString(row, "wbb", data[i].WBB > 0 ? data[i].WBB.ToString() : "");
                        dwRep.SetItemString(row, "tbbbjg", data[i].TBBBJG > 0 ? data[i].TBBBJG.ToString() : "");

                        dwRep.SetItemString(row, "wstsd", data[i].WSTSD > 0 ? data[i].WSTSD.ToString() : "");
                        dwRep.SetItemString(row, "tmwx", data[i].TMWX > 0 ? data[i].TMWX.ToString() : "");
                        dwRep.SetItemString(row, "yjgz", data[i].YJGZ > 0 ? data[i].YJGZ.ToString() : "");
                        dwRep.SetItemString(row, "jgyc", data[i].JGYC > 0 ? data[i].JGYC.ToString() : "");
                        dwRep.SetItemString(row, "cfkd", data[i].CFKD > 0 ? data[i].CFKD.ToString() : "");

                        dwRep.SetItemString(row, "bblxbzq", data[i].BBLXBZQ > 0 ? data[i].BBLXBZQ.ToString() : "");
                        dwRep.SetItemString(row, "xqbbyqb", data[i].XQBBYQB > 0 ? data[i].XQBBYQB.ToString() : "");

                        dwRep.SetItemString(row, "qtyy", data[i].QTYY > 0 ? data[i].QTYY.ToString() : "");
                        dwRep.SetItemString(row, "bhgbbhj", data[i].BHGBBHJ > 0  ? data[i].BHGBBHJ.ToString() : "");
                        dwRep.SetItemString(row, "xbbzl", data[i].XBBZL > 0  ? data[i].XBBZL.ToString() : "");
                        dwRep.SetItemString(row, "xbbbhgl", data[i].XBBBHGS > 0 ? data[i].XBBBHGL  : "");
                        dwRep.SetItemString(row, "fxbbzl",data[i].FXBBZL > 0 ? data[i].FXBBZL.ToString() : "");
                        dwRep.SetItemString(row, "fxbbbhgl", data[i].FXBBBHGS > 0 ? data[i].FXBBBHGL : "");
                        dwRep.SetItemString(row, "bbzlhj", data[i].BBZLHJ > 0 ? data[i].BBZLHJ.ToString() : "");
                        dwRep.SetItemString(row, "sybbbhgl", data[i].BHGBBHJ > 0 ? data[i].SYBBBHGL : "");
                    }

                    dwRep.SetRedrawOn();
                }
                else
                {
                    dwRep.InsertRow(0);
                }

                dwRep.Modify("t_date.text = '" + beginDate + " ~ " + endDate + "'");
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();

        }
        #endregion

        #region Query2
        /// <summary>
        /// Query
        /// </summary>
        internal void Query2()
        {
            List<entitySample> data = new List<entitySample>();
            string beginDate = string.Empty;
            string endDate = string.Empty;
            string checkType = string.Empty;
            int patType = 0;

            beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            endDate = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");
            checkType = cboSampleType.Text.Trim();
            patType = cboPatType.SelectedIndex;
            if (patType == -1)
                patType = 0;

            if (Convert.ToDateTime(beginDate + " :01") > Convert.ToDateTime(endDate + ":59"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                this.dgvData.DataSource = null;
                DataTable dt = null;
                DataTable dtReson = null;
                DataTable dtData = new DataTable() ;

                using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
                {
                    dt = svc.GetStatSampleBack2(beginDate, endDate, checkType, patType);
                    dtReson = svc.GetStatSampleBackReson(beginDate, endDate);
                }

                if (dtReson != null && dtReson.Rows.Count > 0)
                {
                    dtData.Columns.Add("科室\\标本类型", Type.GetType("System.String"));

                    foreach (DataRow dr in dtReson.Rows)
                    {
                        dtData.Columns.Add(dr["sample_back_reason_vchr"].ToString(), Type.GetType("System.String"));
                    }

                    dtData.Columns.Add("血标本总量", Type.GetType("System.String"));
                    dtData.Columns.Add("血标本不合格数", Type.GetType("System.String"));
                    dtData.Columns.Add("血标本不合格率", Type.GetType("System.String"));
                    dtData.Columns.Add("非血标本总量", Type.GetType("System.String"));
                    dtData.Columns.Add("非血标本不合格数", Type.GetType("System.String"));
                    dtData.Columns.Add("非血标本不合格率", Type.GetType("System.String"));
                    dtData.Columns.Add("合计标本数量", Type.GetType("System.String"));
                    dtData.Columns.Add("不合格标本合计", Type.GetType("System.String"));
                    dtData.Columns.Add("所有标本不合格率", Type.GetType("System.String"));
                }

                int ksFlg = 0;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ksFlg = 0;

                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            if (dtData.Rows[i][0].ToString() == dr["deptname_vchr"].ToString())
                            {
                                string sampleType = dr["sampletype_vchr"].ToString().Trim();
                                string reasonStr = dr["sample_back_reason_vchr"].ToString().Trim();

                                if (dr["sample_back_reason_vchr"] != DBNull.Value)
                                {
                                    for (int j = 0; j < dtData.Columns.Count; j++)
                                    {
                                        if (dtData.Columns[j].ToString() == dr["sample_back_reason_vchr"].ToString())
                                        {
                                            if (dtData.Rows[i][j] != DBNull.Value)
                                                dtData.Rows[i][j] = Convert.ToDecimal(dtData.Rows[i][j]) + 1;
                                            else
                                                dtData.Rows[i][j] = 1;
                                        }
                                    }
                                }

                                if (sampleType == "全血" || sampleType == "血清" || sampleType == "血浆" ||
                                        sampleType == "动脉血" || sampleType == "红细胞")
                                {
                                    if (dtData.Rows[i]["血标本总量"] != DBNull.Value)
                                        dtData.Rows[i]["血标本总量"] = Convert.ToDecimal(dtData.Rows[i]["血标本总量"]) + 1;
                                    else
                                        dtData.Rows[i]["血标本总量"] = 1;
                                }
                                else
                                {
                                    if (dtData.Rows[i]["非血标本总量"] != DBNull.Value)
                                        dtData.Rows[i]["非血标本总量"] = Convert.ToDecimal(dtData.Rows[i]["非血标本总量"]) + 1;
                                    else
                                        dtData.Rows[i]["非血标本总量"] = 1;
                                }

                                if ((sampleType == "全血" || sampleType == "血清" || sampleType == "血浆" ||
                                    sampleType == "动脉血" || sampleType == "红细胞") && !string.IsNullOrEmpty(reasonStr))
                                {
                                    if (dtData.Rows[i]["血标本不合格数"] != DBNull.Value)
                                        dtData.Rows[i]["血标本不合格数"] = Convert.ToDecimal(dtData.Rows[i]["血标本不合格数"]) + 1;
                                    else
                                        dtData.Rows[i]["血标本不合格数"] = 1;

                                    if (dtData.Rows[i]["不合格标本合计"] != DBNull.Value)
                                        dtData.Rows[i]["不合格标本合计"] = Convert.ToDecimal(dtData.Rows[i]["不合格标本合计"]) + 1;
                                    else
                                        dtData.Rows[i]["不合格标本合计"] = 1;
                                }
                                else if (!string.IsNullOrEmpty(reasonStr))
                                {
                                    if (dtData.Rows[i]["非血标本不合格数"] != DBNull.Value)
                                        dtData.Rows[i]["非血标本不合格数"] = Convert.ToDecimal(dtData.Rows[i]["非血标本不合格数"]) + 1;
                                    else
                                        dtData.Rows[i]["非血标本不合格数"] = 1;

                                    if (dtData.Rows[i]["不合格标本合计"] != DBNull.Value)
                                        dtData.Rows[i]["不合格标本合计"] = Convert.ToDecimal(dtData.Rows[i]["不合格标本合计"]) + 1;
                                    else
                                        dtData.Rows[i]["不合格标本合计"] = 1;
                                }

                                dtData.Rows[i]["合计标本数量"] = Convert.ToDecimal(dtData.Rows[i]["合计标本数量"]) + 1;

                                if (dtData.Rows[i]["血标本不合格数"] != DBNull.Value && dtData.Rows[i]["血标本总量"] != DBNull.Value)
                                    dtData.Rows[i]["血标本不合格率"] = (Convert.ToDecimal(dtData.Rows[i]["血标本不合格数"]) / Convert.ToDecimal(dtData.Rows[i]["血标本总量"])).ToString("0.00%");

                                if (dtData.Rows[i]["非血标本不合格数"] != DBNull.Value && dtData.Rows[i]["非血标本总量"] != DBNull.Value)
                                    dtData.Rows[i]["非血标本不合格率"] = (Convert.ToDecimal(dtData.Rows[i]["非血标本不合格数"]) / Convert.ToDecimal(dtData.Rows[i]["非血标本总量"])).ToString("0.00%");


                                if (dtData.Rows[i]["不合格标本合计"] != DBNull.Value && dtData.Rows[i]["合计标本数量"] != DBNull.Value)
                                    dtData.Rows[i]["所有标本不合格率"] = (Convert.ToDecimal(dtData.Rows[i]["不合格标本合计"]) / Convert.ToDecimal(dtData.Rows[i]["合计标本数量"])).ToString("0.00%");

                                ksFlg = 1;
                            }
                        }

                        if (ksFlg == 0)
                        {
                            DataRow newRow;
                            newRow = dtData.NewRow();
                            newRow["科室\\标本类型"] = dr["deptname_vchr"];
                            string sampleType = dr["sampletype_vchr"].ToString().Trim();
                            string reasonStr = dr["sample_back_reason_vchr"].ToString().Trim();

                            if (sampleType == "全血" || sampleType == "血清" || sampleType == "血浆" ||
                                    sampleType == "动脉血" || sampleType == "红细胞")
                                newRow["血标本总量"] = 1;
                            else
                                newRow["非血标本总量"] = 1;

                            if ((sampleType == "全血" || sampleType == "血清" || sampleType == "血浆" ||
                                sampleType == "动脉血" || sampleType == "红细胞") && !string.IsNullOrEmpty(reasonStr))
                            {
                                newRow["不合格标本合计"] = 1;
                                newRow["血标本不合格数"] = 1;
                            }
                            else if (!string.IsNullOrEmpty(reasonStr))
                            {
                                newRow["不合格标本合计"] = 1;
                                newRow["非血标本不合格数"] = 1;
                            }
                            newRow["合计标本数量"] = 1;
                            
                            for (int j = 0; j < dtData.Columns.Count; j++)
                            {
                                if (dtData.Columns[j].ToString() == dr["sample_back_reason_vchr"].ToString())
                                {
                                    newRow[j] = 1;
                                }
                            }

                            newRow["合计标本数量"] =  1;

                            if (newRow["血标本不合格数"] != DBNull.Value && newRow["血标本总量"] != DBNull.Value)
                                newRow["血标本不合格率"] = (Convert.ToDecimal(newRow["血标本不合格数"]) / Convert.ToDecimal(newRow["血标本总量"])).ToString("0.00%");

                            if (newRow["非血标本不合格数"] != DBNull.Value && newRow["非血标本总量"] != DBNull.Value)
                                newRow["非血标本不合格率"] = (Convert.ToDecimal(newRow["非血标本不合格数"]) / Convert.ToDecimal(newRow["非血标本总量"])).ToString("0.00%");

                            if (newRow["不合格标本合计"] != DBNull.Value && newRow["合计标本数量"] != DBNull.Value)
                                newRow["所有标本不合格率"] = (Convert.ToDecimal(newRow["不合格标本合计"]) / Convert.ToDecimal(newRow["合计标本数量"])).ToString("0.00%");

                            dtData.Rows.Add(newRow);
                        }
                    }
                }

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    DataRow newRowHj = dtData.NewRow();
                    newRowHj["科室\\标本类型"] = "全院合计";

                    decimal hj = 0;
                    for (int colI = 1; colI < dtData.Columns.Count; colI++)
                    {
                        hj = 0;

                        if (dtData.Columns[colI].ToString().Contains("率"))
                            continue;

                        for (int rowI = 0; rowI < dtData.Rows.Count ; rowI++)
                        {
                            if (dtData.Rows[rowI][colI] != DBNull.Value)
                                hj += Convert.ToDecimal(dtData.Rows[rowI][colI]);
                            if(hj > 0)
                                newRowHj[colI] = hj;
                        }
                    }
                    dtData.Rows.Add(newRowHj);

                    DataRow newRowZb = dtData.NewRow();
                    newRowZb["科室\\标本类型"] = "所占比例";
                    for (int colI = 1; colI < dtData.Columns.Count-9; colI++)
                    {
                        hj = 0;

                        if (dtData.Columns[colI].ToString().Contains("率"))
                            continue;

                        if (dtData.Rows[dtData.Rows.Count - 1][colI] != DBNull.Value && newRowHj["不合格标本合计"] != DBNull.Value)
                        {
                            if (Convert.ToDecimal(newRowHj["不合格标本合计"]) > 0)
                                newRowZb[colI] = (Convert.ToDecimal(dtData.Rows[dtData.Rows.Count - 1][colI]) / Convert.ToDecimal(newRowHj["不合格标本合计"])).ToString("0.00%");
                        }
                            
                    }
                   
                    dtData.Rows.Add(newRowZb);
                }

                dgvData.DataSource = dtData;
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deptcode"></param>
        /// <returns></returns>
        internal string JudgeDept(string deptcode)
        {
            string deptArea = string.Empty;
            //内一
            List<string> NYQ = new List<string>() { "0301","03013"};
            //内二
            List<string> NEQ = new List<string>() { "0302", "03024"};
            //妇科
            List<string> FK = new List<string>() { "05", "0501", "05011", "06" };
            //手外科
            List<string> SW = new List<string>() { "0408", "04081"};
            //普外科
            List<string> PWK = new List<string>() { "0401", "04011" };
            //泌尿外科
            List<string> MW = new List<string>() { "0405", "04051"};
            //神经外科
            List<string> SJWK = new List<string>() { "0402", "04021"};
            //骨科
            List<string> GK = new List<string>() { "0403", "04031" };
            //ICU
            List<string> ICU = new List<string>() { "02", "0201" };
            //普儿科
            List<string> PEK = new List<string>() { "07", "0701", "071", "0711"};
            //新生儿科
            List<string> XSEK = new List<string>() { "0702", "0712" };
            //急诊科
            List<string> JZK = new List<string>() { "20", "823" };
            //体检科
            List<string> TJK = new List<string>() { "0103" };
            //耳鼻喉科
            List<string> EBHK = new List<string>() {"1101","1102"};
            //眼科
            List<string> YK = new List<string>() { "1002" ,"1001"};
            //消化内科病区
            List<string> XHNK = new List<string>() { "03031" };
            //中医科
            List<string> ZYK = new List<string>() { "0404", "04041", "15011", "50", "50152", "502" };
            //产科
            List<string> CK = new List<string>() { "0502", "05021"};
            //手术室
            List<string> SSS = new List<string>() { "2601", "26" };
            //门诊部（包括放射、B超、口腔、分诊、专科门诊）
            List<string> MZB = new List<string>() { "032", "82", "821", "821", "822", "13", "824", "825", 
                                                        "31","32","3201","3202","3205","3206","12"};
            //第二门诊
            List<string> DEMZ = new List<string>() { "8802", "88002" };
            //第三门诊
            List<string> DSMZ = new List<string>() { "8803", "88003" };
            //消毒供应室
            List<string> XDGYS = new List<string>() { "791" };
            //多功能科
            List<string> DGNK = new List<string>() { "40" };


            if (NYQ.Contains(deptcode))
                deptArea = "内一"; //内一区
            else if (NEQ.Contains(deptcode))
                deptArea = "内二"; //内二区
            else if (SJWK.Contains(deptcode))
                deptArea = "神外"; //神经外科
            else if (GK.Contains(deptcode))
                deptArea = "骨外"; //骨科
            else if (MW.Contains(deptcode))
                deptArea = "泌尿"; //泌尿外科
            else if (SW.Contains(deptcode))
                deptArea = "手外"; //手外科
            else if (PWK.Contains(deptcode))//普外科
                deptArea = "普外";
            else if (FK.Contains(deptcode))
                deptArea = "妇科"; //妇科
            else if (CK.Contains(deptcode))
                deptArea = "产科"; //产科
            else if (PEK.Contains(deptcode))
                deptArea = "普儿"; //普儿科
            else if (XSEK.Contains(deptcode))
                deptArea = "NICU"; //新生儿科
            else if (ICU.Contains(deptcode))
                deptArea = "ICU"; //重症医学科
            else if (ZYK.Contains(deptcode))
                deptArea = "中医";
            else if (EBHK.Contains(deptcode) || YK.Contains(deptcode))
                deptArea = "耳鼻喉+眼科";
            else if (XHNK.Contains(deptcode))
                deptArea = "消化内科";
            else if (JZK.Contains(deptcode))
                deptArea = "急诊"; //急诊科
            else if (TJK.Contains(deptcode))
                deptArea = "体检科"; //体检科
            else
                deptArea = "门诊"; //门诊部

            return deptArea;
        }
        #endregion

        #region init
        /// <summary>
        /// init
        /// </summary>
        public void init()
        {
            //标本类型绑定数据
            #region
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
            DataTable dt = svc.GetGategoryType();
            this.cboSampleType.Items.Add("全部");

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.cboSampleType.Items.Add(dr["CHECK_CATEGORY_DESC_VCHR"].ToString());
                    }
                }
            }
            finally
            {
                svc = null;
            }
            #endregion
        }
        #endregion

        #endregion

        #region entitySample
        /// <summary>
        /// entitySample
        /// </summary>
        public class entitySample
        {
            public entitySample() { }

            public string KS { get; set; }
            public double RX { get; set; }
            public double BFLBZQ { get; set; }
            public double NG { get; set; }
            public double BFZLBF { get; set; }
            public double QXBZ { get; set; }
            public double YCSG { get; set; }
            public double WBB { get; set; }
            public double TBBBJG { get; set; }
            public double QTYY { get; set; }
            public double BHGBBHJ { get; set; }
            public double XBBZL { get; set; }
            public double XBBBHGS { get; set; }
            public string XBBBHGL { get; set; }
            public double FXBBZL { get; set; }
            public double FXBBBHGS { get; set; }
            public string FXBBBHGL { get; set; }
            public double BBZLHJ { get; set; }
            public string SYBBBHGL { get; set; }

            public double WSTSD { get; set; }
            public double TMWX { get; set; }
            public double YJGZ { get; set; }
            public double JGYC { get; set; }
            public double CFKD { get; set; }
            public double BBLXBZQ { get; set; }
            public double XQBBYQB { get; set; }
        }
        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 
        /// </summary>
        public void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            string dteStart = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            string dteEnd = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");
            string applyUnitName = string.Empty;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";

                try
                {
                    for (int i = 0; i < this.dgvData.ColumnCount / 2; i++)
                    {
                        if (this.dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }

                    text += "检验质量统计分析表";
                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd ;
                    streamWriter.WriteLine(text);
                    text = "";

                    for (int i = 0; i < this.dgvData.ColumnCount; i++)
                    {
                        if (dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                            text += dgvData.Columns[i].HeaderText.Replace("\n", "");
                        }
                    }
                    streamWriter.WriteLine(text);
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < dgvData.Columns.Count; j++)
                        {
                            if (dgvData.Columns[j].Visible)
                            {
                                if (j > 0)
                                {
                                    stringBuilder.Append("\t");
                                }
                                stringBuilder.Append((dgvData.Rows[i].Cells[j].Value == null) ? "" : dgvData.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        streamWriter.WriteLine(stringBuilder);
                    }
                    MessageBox.Show("导出成功！", "检验质量统计分析表", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    streamWriter.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    streamWriter.Close();
                    stream.Close();
                }
            }
        }
        #endregion
    }
}
