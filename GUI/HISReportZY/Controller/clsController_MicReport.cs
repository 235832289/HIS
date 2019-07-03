using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;
using Sybase.DataWindow;
using com.digitalwave.iCare.gui.HIS.Reports;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsController_StatReport 的摘要说明。
    /// </summary>
    public class clsController_MicReport : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 构造函数
        public clsController_MicReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDomainController_MicReport();
        }
        #endregion

        #region 实体
        /// <summary>
        /// 细菌分布
        /// </summary>
        public class EntityBacteriaDistribution
        {
            public string xjmc { get; set; }
            public decimal xjzs { get; set; }
            public string bfb { get; set; }
        }

        /// <summary>
        /// 累计敏感性报告
        /// </summary>
        public class EntityMicSensitive
        {
            public string antiname { get; set; }
            public decimal miccount { get; set; }
            public decimal sensitive { get; set; }
            public decimal intermediary { get; set; }
            public decimal resistance { get; set; }
            public decimal total { get; set; }
        }
        #endregion

        /// <summary>
        /// 累计MIC报告 
        /// </summary>
        public class EntityMicCumulative
        {
            public string antiname { get; set; }
            public decimal total { get; set; }
            public decimal perCount_1 { get; set; }
            public decimal perCount_2 { get; set; }
            public decimal perCount_3 { get; set; }
            public decimal perCount_4 { get; set; }
            public decimal perCount_5 { get; set; }
            public decimal perCount_6 { get; set; }
            public decimal perCount_7 { get; set; }
            public decimal perCount_8 { get; set; }
            public decimal perCount_9 { get; set; }
            public decimal perCount_10 { get; set; }
            public decimal perCount_11 { get; set; }
            public decimal perCount_12 { get; set; }
        }

        /// <summary>
        /// 细菌分布趋势
        /// </summary>
        public class EntityMicdistributiontend
        {
            public string month { get; set; }
            public List<EntityMicdistribution> data;
        }

        public class EntityMicdistribution
        {
            public string antiname { get; set; }
            public string monthPer { get; set; }
            public decimal antiCount { get; set; }
            public string antiPer { get; set; }
        }

        public class EntityMic
        {
            public string antiname { get; set; }
            public decimal antiCount { get; set; }
        }


        /// <summary>
        /// 类变量
        /// </summary>
        internal int strQuery;
        private frmMicReport m_objViewer;
        string strTempName = null;
        internal string strTempAntiID = null;
        internal DateTime dtDateFrom;
        internal DateTime dtDateTo;
        internal bool IsEnglish = false;
        private clsDomainController_MicReport m_objManage;
        private Transaction m_objTransation;

        internal string SamtNo = null;
        internal string DisNo = null;
        internal string Sex = null;
        internal string AgeFrom = null;
        internal string AgeTo = null;
        internal string TestMethod = null;

        #region 设置窗体对象
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmMicReport)frmMDI_Child_Base_in;
            this.m_objTransation = new Transaction();
            string ServerName = "";
            string UserID = "";
            string Pwd = "";
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);
            m_objTransation = new Transaction();
            m_objTransation.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;
            m_objTransation.ServerName = ServerName;
            m_objTransation.UserId = UserID;
            m_objTransation.Password = Pwd;
            m_objTransation.AutoCommit = true;
            m_objTransation.Connect();
        }
        #endregion

        public void m_mthInti()
        {
            DataTable dtbResult;
            m_objViewer.tabContorl.Visible = false;
            m_objViewer.m_cboCondition.Items.AddRange(new object[] { "细菌分布趋势报告", "敏感率报告", "敏感率趋势报告", "累计敏感性报告", "累计MIC报告", "细菌分布报告统计" });

            m_objManage.lngGetDeptName(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cbxDistrict.Items.Add(dtbResult.Rows[i]["dictname_vchr"].ToString());
            }

            m_objManage.lngGetSamType(out dtbResult);

            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cbxSampleType.Items.Add(dtbResult.Rows[i]["sample_type_desc_vchr"].ToString());
            }
        }

        #region 列出所有抗生素
        /// <summary>
        /// 列出抗生素
        /// </summary>
        public void m_mthListAnti()
        {
            DataTable dtbResult;
            long lngRes = m_objManage.lngGetAllAnti(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        #region 列出所有细菌
        /// <summary>
        /// 列出细菌
        /// </summary>
        public void m_mthListMic()
        {
            DataTable dtbResult;
            long lngRes = m_objManage.lngGetAllMic(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }
        #endregion

        /// <summary>
        /// 根据文本框变化查询细菌
        /// </summary>
        public void m_mthtxtChangeQueryMic()
        {
            DataTable dtbResult;

            Regex regex = new Regex("^[A-Za-z0-9]+$");
            strTempName = m_objViewer.txtSearchName.Text.Trim();
            if (strTempName == string.Empty)
            {
                return;
            }
            IsEnglish = regex.IsMatch(strTempName);

            long lngRes = m_objManage.lngGetFuzzyQueryMic(strTempName.ToUpper(), IsEnglish, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }

        /// <summary>
        /// 根据文本框变化查询抗生素
        /// </summary>
        public void m_mthtxtChangeQueryAnti()
        {
            DataTable dtbResult;

            Regex regex = new Regex("^[A-Za-z0-9]+$");
            strTempName = m_objViewer.txtSearchName.Text.Trim();
            if (strTempName == string.Empty)
            {
                return;
            }
            IsEnglish = regex.IsMatch(strTempName);

            long lngRes = m_objManage.lngGetFuzzyQueryAnti(strTempName.ToUpper(), IsEnglish, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_objViewer.dgvItem.DataSource = dtbResult;
            }
        }

        #region 细菌分布统计报表
        /// <summary>
        /// 细菌分布统计
        /// </summary>
        public void m_mthGetBacStatstic()
        {
            DataTable dtbResult;
            if (m_objViewer.dgv_mic.Rows.Count > 1)
            {
                strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            }
            else
            {
                strTempName = null;
            }
            long lngRes = m_objManage.lngGetBacteriaDistribution(strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWBacStatstic(dtbResult);
            }
            else
            {
                MessageBox.Show("没有查到没有数据。");
            }
        }

        /// <summary>
        /// 填充DW 细菌分布统计报表
        /// </summary>
        /// <param name="intall"></param>
        /// <param name="dtRsult"></param>
        public void FillDWBacStatstic(DataTable dtbResult)
        {
            try
            {
                decimal total = 0;
                decimal percentage = 0;
                int row = 0;
                int flg = 0;
                List<EntityBacteriaDistribution> data = new List<EntityBacteriaDistribution>();

                foreach (DataRow dr in dtbResult.Rows)
                {
                    flg = 0;
                    string XJMC = dr["XJMC"].ToString().Trim();
                    if (XJMC.Contains("无"))
                        continue;

                    XJMC = XJMC.Replace("1、", "").Replace("2、", "").Replace("1.", "").Replace("2.", "");

                    if (data != null && data.Count > 0)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            if (XJMC == data[i].xjmc)
                            {
                                data[i].xjzs++;
                                flg = 1;
                                break;
                            }
                        }
                    }

                    if (flg == 0)
                    {
                        EntityBacteriaDistribution vo = new EntityBacteriaDistribution();
                        vo.xjmc = XJMC;
                        vo.xjzs = 1;
                        data.Add(vo);
                    }
                }
                for (int j = 0; j < data.Count; j++)
                    total += data[j].xjzs;

                m_objViewer.dwResult.SetRedrawOff();
                for (int intI = 0; intI < data.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    m_objViewer.dwResult.SetItemString(row, "xjmc", data[intI].xjmc);
                    m_objViewer.dwResult.SetItemString(row, "xjzs", data[intI].xjzs.ToString());
                    percentage = data[intI].xjzs / total;
                    m_objViewer.dwResult.SetItemString(row, "bfb", percentage.ToString("0.00%"));
                }

                string strDatFrom = m_objViewer.m_dtpDatFrom.Value.ToString("yyyy-MM-dd");
                string strDatTo = m_objViewer.m_dtpDatTo.Value.ToString("yyyy-MM-dd");
                m_objViewer.dwResult.Modify("t_date.text ='" + strDatFrom + " ~ " + strDatTo + "'");
                m_objViewer.dwResult.Modify("t_sampletype.text = '" + m_objViewer.cbxSampleType.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_pattype.text = '" + m_objViewer.cbxDistrict.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_sex.text = '" + m_objViewer.cbxSex.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_age.text = '" + AgeFrom + "至" + AgeTo + "'");
                //m_objViewer.dwResult.Modify("t_testmethod.text = '实验方法：" + m_objViewer.cbxTestMethod.Text.Trim() + "'"); 

                m_objViewer.dwResult.SetRedrawOn();
                m_objViewer.dwResult.Refresh();
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }
        #endregion

        #region 累计敏感性报表
        /// <summary>
        /// 累计敏感性报表
        /// </summary>
        public void m_mthGetMicSensitive()
        {
            DataTable dtbResult;
            if (m_objViewer.dgv_mic.Rows.Count < 2)
            {
                MessageBox.Show("请选择细菌！");
                return;
            }

            strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            long lngRes = m_objManage.lngGetMicSensitive(dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, TestMethod, strTempAntiID, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWMicSensitive(dtbResult, strTempName);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }

        public void FillDWMicSensitive(DataTable dtbResult, string strTempName)
        {
            try
            {
                int row = 0;
                decimal dectemp = 0;
                int flg = 0;
                List<EntityMicSensitive> data = new List<EntityMicSensitive>();
                DataRow[] drResult = dtbResult.Select("CHECK_ITEM_NAME_VCHR like '%鉴定结果%' ");
                if (drResult != null && drResult.Length > 0)
                {
                    foreach (DataRow dr in drResult)
                    {
                        string XJMC = dr["result_vchr"].ToString().Trim();
                        string BGBH = dr["BGBH"].ToString();
                        if (XJMC.Contains("无"))
                            continue;

                        DataRow[] drAnti = dtbResult.Select("BGBH = '" + BGBH + "'");
                        if (drAnti != null && drAnti.Length > 0)
                        {
                            foreach (DataRow dr2 in drAnti)
                            {
                                string antiName = dr2["CHECK_ITEM_NAME_VCHR"].ToString();
                                string antiType = dr2["result_vchr"].ToString().Trim();
                                if (string.IsNullOrEmpty(antiType))
                                    continue;
                                flg = 0;
                                if (data != null && data.Count > 0)
                                {
                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        if (antiName == data[i].antiname)
                                        {
                                            if (antiType == "敏感")
                                                data[i].sensitive++;
                                            else if (antiType == "耐药")
                                                data[i].resistance++;
                                            else if (antiType == "中介")
                                                data[i].intermediary++;
                                            data[i].total++;
                                            flg = 1;
                                            break;
                                        }
                                    }
                                }
                                if (flg == 0)
                                {
                                    EntityMicSensitive vo = new EntityMicSensitive();
                                    vo.antiname = antiName;
                                    if (antiType == "敏感")
                                        vo.sensitive = 1;
                                    else if (antiType == "耐药")
                                        vo.resistance = 1;
                                    else if (antiType == "中介")
                                        vo.intermediary = 1;
                                    vo.total = 1;
                                    data.Add(vo);
                                }
                            }
                        }
                    }
                }

                m_objViewer.dwResult.SetRedrawOff();

                for (int intI = 0; intI < data.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    m_objViewer.dwResult.SetItemString(row, "antiname", data[intI].antiname);
                    m_objViewer.dwResult.SetItemString(row, "miccount", data[intI].total.ToString());
                    dectemp = data[intI].sensitive / data[intI].total;
                    m_objViewer.dwResult.SetItemString(row, "sensitive", dectemp.ToString("0.00%"));

                    dectemp = dectemp = data[intI].intermediary / data[intI].total;
                    m_objViewer.dwResult.SetItemString(row, "intermediary", dectemp.ToString("0.00%"));

                    dectemp = dectemp = data[intI].resistance / data[intI].total;
                    m_objViewer.dwResult.SetItemString(row, "resistance", dectemp.ToString("0.00%"));
                }
                string strDatFrom = m_objViewer.m_dtpDatFrom.Value.ToString("yyyy-MM-dd");
                string strDatTo = m_objViewer.m_dtpDatTo.Value.ToString("yyyy-MM-dd");
                m_objViewer.dwResult.Modify("t_date.text ='" + strDatFrom + " ~ " + strDatTo + "'");
                m_objViewer.dwResult.Modify("t_sampletype.text = '" + m_objViewer.cbxSampleType.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_pattype.text = '" + m_objViewer.cbxDistrict.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_sex.text = '" + m_objViewer.cbxSex.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_age.text = '" + AgeFrom + "至" + AgeTo + "'");
                //m_objViewer.dwResult.Modify("t_testmethod.text = '实验方法：" + m_objViewer.cbxTestMethod.Text.Trim() + "'");  

                m_objViewer.dwResult.SetRedrawOn();
                m_objViewer.dwResult.Refresh();

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }
        #endregion

        #region 细菌分布趋势报告
        /// <summary>
        /// 细菌分布趋势报告
        /// </summary>
        public void m_mthGetMicdistributiontend()
        {
            DataTable dtbResult;
            if (m_objViewer.dgv_mic.Rows.Count > 1)
            {
                strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            }
            else
            {
                strTempName = null;
            }

            long lngRes = m_objManage.lngGetMicdistributionTend(strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, TestMethod, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWMicdistributionTend(dtbResult, dtDateFrom, dtDateTo);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }
        /// <summary>
        ///填充 分布趋势报表
        /// </summary>
        /// <param name="dtbResult"></param>
        public void FillDWMicdistributionTend(DataTable dtTable, DateTime dtDateFrom, DateTime dteDateTo)
        {
            try
            {
                int i = 0, j = 0;
                int rowCount = 0;//新表行数
                DataTable dtbResult = new DataTable();
                DataColumn dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = @"细菌名称/月份";
                dtbResult.Columns.Add(dc);
                DataRow dr = null;

                DataRow dtrFrom = null;

                int monthCuont = dtDateFrom.Month - dteDateTo.Month;

                for (int mI = 0; mI < monthCuont; mI++)
                {
                    dtbResult.Columns.Add(dtDateFrom.AddMonths(mI).ToString("yyyy-MM"));
                }

                int flgXJMC = 0;

                //向新表添加数据
                for (i = 0; i < dtTable.Rows.Count; i++)
                {
                    flgXJMC = 0;
                    dtrFrom = dtTable.Rows[i];
                    string month = Convert.ToDateTime(dtrFrom["BGSJ"]).ToString("yyyy-MM");

                    string XJMC = dr["XJMC"].ToString().Trim();
                    if (XJMC.Contains("无"))
                        continue;

                    XJMC = XJMC.Replace("1、", "").Replace("2、", "").Replace("1.", "").Replace("2.", "");

                    for (int drI = 0; drI < dtbResult.Rows.Count; drI++)
                    {
                        string nameTemp = dtbResult.Rows[drI][0].ToString();

                        if (nameTemp.Contains(XJMC))
                        {
                            flgXJMC = 1;
                        }
                    }

                    if (flgXJMC == 1)
                    {
                        for (j = 0; j < dtbResult.Columns.Count; j++)
                        {
                            if (month == dtbResult.Columns[j].ColumnName.ToString())
                            {
                                dtbResult.Rows[rowCount][j] = Convert.ToDecimal(dtbResult.Rows[rowCount][j])  + 1;
                            }
                        }
                    }
                    else
                    {
                        dr = dtbResult.NewRow();
                        XJMC = dtrFrom["XJMC"].ToString();
                        XJMC = XJMC.Replace("1、", "").Replace("2、", "").Replace("1.", "").Replace("2.", "");
                        dr[0] = XJMC;
                        dtbResult.Rows.Add(dr);
                        rowCount++;
                        for (j = 0; j < dtbResult.Columns.Count; j++)
                        {
                            if (month == dtbResult.Columns[j].ColumnName.ToString())
                            {
                                dtbResult.Rows[rowCount][j] = 1;
                            }
                        }
                    }
                }

                m_objViewer.dgvMicdistributiontend.DataSource = dtbResult;
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }

        #endregion

        #region 敏感率趋势报告
        /// <summary>
        /// 敏感率趋势报告
        /// </summary>
        public void m_mthGetSensitiveTend()
        {
            DataTable dtbResult;
            if (m_objViewer.dgv_mic.Rows.Count < 2)
            {
                MessageBox.Show("请选择细菌！");
                return;
            }
            //strTempID = m_objViewer.dgv_mic.Rows[0].Cells[0].Value.ToString();
            strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            long lngRes = m_objManage.lngGetSensitiveTend(strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, strTempAntiID, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWSensitiveTend(dtbResult);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }

        /// <summary>
        /// 填充 敏感率趋势报告
        /// </summary>
        /// <param name="dtbResult"></param>
        public void FillDWSensitiveTend(DataTable dtbResult)
        {
            try
            {
                DataRow dtFr;
                int row = 0;
                m_objViewer.dwResult.SetRedrawOff();
                decimal num = 0;
                decimal totnum = 0;
                decimal perTemp = 0;
                string result1 = null;
                string result2 = null;
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    dtFr = dtbResult.Rows[intI];

                    num = decimal.Parse(dtFr["sen1"].ToString());
                    totnum = decimal.Parse(dtFr["num1"].ToString());
                    if (totnum != 0)
                    {
                        perTemp = num / totnum;
                        result1 = perTemp.ToString("0.00%");
                        result2 = totnum.ToString();
                    }
                    else
                    {
                        result1 = "*";
                        result2 = "*";
                    }
                    m_objViewer.dwResult.SetItemString(row, "antiname", dtFr["antiname"].ToString());
                    m_objViewer.dwResult.SetItemString(row, "month1p", result1);
                    m_objViewer.dwResult.SetItemString(row, "month1num", result2);

                    num = decimal.Parse(dtFr["sen2"].ToString());
                    totnum = decimal.Parse(dtFr["num2"].ToString());
                    if (totnum != 0)
                    {
                        perTemp = num / totnum;
                        result1 = perTemp.ToString("0.00%");
                        result2 = totnum.ToString();
                    }
                    else
                    {
                        result1 = "*";
                        result2 = "*";
                    }
                    m_objViewer.dwResult.SetItemString(row, "month2p", result1);
                    m_objViewer.dwResult.SetItemString(row, "month2num", result2);

                    num = decimal.Parse(dtFr["sen3"].ToString());
                    totnum = decimal.Parse(dtFr["num3"].ToString());
                    if (totnum != 0)
                    {
                        perTemp = num / totnum;
                        result1 = perTemp.ToString("0.00%");
                        result2 = totnum.ToString();
                    }
                    else
                    {
                        result1 = "*";
                        result2 = "*";
                    }
                    m_objViewer.dwResult.SetItemString(row, "month3p", result1);
                    m_objViewer.dwResult.SetItemString(row, "month3num", result2);


                    num = decimal.Parse(dtFr["sen4"].ToString());
                    totnum = decimal.Parse(dtFr["num4"].ToString());
                    if (totnum != 0)
                    {
                        perTemp = num / totnum;
                        result1 = perTemp.ToString("0.00%");
                        result2 = totnum.ToString();
                    }
                    else
                    {
                        result1 = "*";
                        result2 = "*";
                    }
                    m_objViewer.dwResult.SetItemString(row, "month4p", result1);
                    m_objViewer.dwResult.SetItemString(row, "month4num", result2);
                }

                m_objViewer.dwResult.Modify("t_from.text='(" + dtDateFrom.ToString("yyyy-MM-dd") + "'");
                m_objViewer.dwResult.Modify("t_to.text='" + dtDateTo.ToString("yyyy-MM-dd") + ")'");
                m_objViewer.dwResult.Modify("t_antiname.text='" + strTempName + "'");

                DateTime dateTo = dtDateTo;
                m_objViewer.dwResult.Modify("t_month1.text='" + dateTo.AddMonths(-3).ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month12.text='" + dateTo.AddMonths(-3).ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month2.text='" + dateTo.AddMonths(-2).ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month22.text='" + dateTo.AddMonths(-2).ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month3.text='" + dateTo.AddMonths(-1).ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month32.text='" + dateTo.AddMonths(-1).ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month4.text='" + dateTo.ToString("yyyy-MM") + "'");
                m_objViewer.dwResult.Modify("t_month42.text='" + dateTo.ToString("yyyy-MM") + "'");

                m_objViewer.dwResult.Modify("t_samtype.text = '标本类型：" + m_objViewer.cbxSampleType.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_district.text = '病人类型：" + m_objViewer.cbxDistrict.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_sex.text = '性别：" + m_objViewer.cbxSex.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_age.text = '年龄：" + AgeFrom + "至" + AgeTo + "'");
                m_objViewer.dwResult.Modify("t_testmethod.text = '实验方法：" + m_objViewer.cbxTestMethod.Text.Trim() + "'");
                m_objViewer.dwResult.SetRedrawOn();
                m_objViewer.dwResult.Refresh();

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }
        #endregion

        #region 累计MIC报告
        /// <summary>
        /// 累计MIC报告
        /// </summary>
        public void m_mthGetMicCumulative()
        {
            DataTable dtbResult;
            if (m_objViewer.dgv_mic.Rows.Count < 2)
            {
                MessageBox.Show("请选择细菌！");
                return;
            }
            strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            long lngRes = m_objManage.lngGetMicCumulative(dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, TestMethod, strTempAntiID, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWMicCumulative(dtbResult, strTempName);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }

        public void FillDWMicCumulative(DataTable dtbResult, string strTempName)
        {
            try
            {
                int row = 0;
                int flg = 0;
                List<EntityMicCumulative> data = new List<EntityMicCumulative>();
                DataRow[] drResult = dtbResult.Select("CHECK_ITEM_NAME_VCHR like '%鉴定结果%' ");
                if (drResult != null && drResult.Length > 0)
                {
                    foreach (DataRow dr in drResult)
                    {
                        string XJMC = dr["result_vchr"].ToString().Trim();
                        string BGBH = dr["BGBH"].ToString();
                        if (XJMC.Contains("无"))
                            continue;

                        DataRow[] drAnti = dtbResult.Select("BGBH = '" + BGBH + "'");
                        if (drAnti != null && drAnti.Length > 0)
                        {
                            foreach (DataRow dr2 in drAnti)
                            {
                                string antiName = dr2["CHECK_ITEM_NAME_VCHR"].ToString();
                                string micResult = dr2["REFRANGE_VCHR"].ToString().Trim();
                                if (string.IsNullOrEmpty(micResult))
                                    continue;
                                flg = 0;
                                if (data != null && data.Count > 0)
                                {
                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        if (antiName == data[i].antiname)
                                        {
                                            if (micResult.Contains("≤0.25"))
                                                data[i].perCount_1++;
                                            else if (micResult.Contains("≤0.5"))
                                                data[i].perCount_2++;
                                            else if (micResult.Contains("≤1"))
                                                data[i].perCount_3++;
                                            else if (micResult.Contains("≤2"))
                                                data[i].perCount_4++;
                                            else if (micResult.Contains("≤4"))
                                                data[i].perCount_5++;
                                            else if (micResult.Contains("≤8"))
                                                data[i].perCount_6++;
                                            else if (micResult.Contains("≤16"))
                                                data[i].perCount_7++;
                                            else if (micResult.Contains("≤32"))
                                                data[i].perCount_8++;
                                            else if (micResult.Contains("≤64"))
                                                data[i].perCount_9++;
                                            else if (micResult.Contains("≤128"))
                                                data[i].perCount_10++;
                                            else if (micResult.Contains("≤256"))
                                                data[i].perCount_11++;
                                            else if (micResult.Contains(">256"))
                                                data[i].perCount_12++;
                                            else if (micResult.Contains(">0.25"))
                                                data[i].perCount_2++;
                                            else if (micResult.Contains(">0.5"))
                                                data[i].perCount_3++;
                                            else if (micResult.Contains(">0.5"))
                                                data[i].perCount_4++;
                                            else if (micResult.Contains(">1"))
                                                data[i].perCount_5++;
                                            else if (micResult.Contains(">2"))
                                                data[i].perCount_6++;
                                            else if (micResult.Contains(">4"))
                                                data[i].perCount_7++;
                                            else if (micResult.Contains(">8"))
                                                data[i].perCount_8++;
                                            else if (micResult.Contains(">16"))
                                                data[i].perCount_9++;
                                            else if (micResult.Contains(">32"))
                                                data[i].perCount_10++;
                                            else if (micResult.Contains(">64"))
                                                data[i].perCount_11++;
                                            else if (micResult.Contains(">128"))
                                                data[i].perCount_11++;
                                            data[i].total++;
                                            flg = 1;
                                            break;
                                        }
                                    }
                                }
                                if (flg == 0)
                                {
                                    EntityMicCumulative vo = new EntityMicCumulative();
                                    vo.antiname = antiName;
                                    if (micResult.Contains("≤0.25"))
                                        vo.perCount_1++;
                                    else if (micResult.Contains("≤0.5"))
                                        vo.perCount_2++;
                                    else if (micResult.Contains("≤1"))
                                        vo.perCount_3++;
                                    else if (micResult.Contains("≤2"))
                                        vo.perCount_4++;
                                    else if (micResult.Contains("≤4"))
                                        vo.perCount_5++;
                                    else if (micResult.Contains("≤8"))
                                        vo.perCount_6++;
                                    else if (micResult.Contains("≤16"))
                                        vo.perCount_7++;
                                    else if (micResult.Contains("≤32"))
                                        vo.perCount_8++;
                                    else if (micResult.Contains("≤64"))
                                        vo.perCount_9++;
                                    else if (micResult.Contains("≤128"))
                                        vo.perCount_10++;
                                    else if (micResult.Contains("≤256"))
                                        vo.perCount_11++;
                                    else if (micResult.Contains(">256"))
                                        vo.perCount_12++;
                                    else if (micResult.Contains(">0.25"))
                                        vo.perCount_2++;
                                    else if (micResult.Contains(">0.5"))
                                        vo.perCount_3++;
                                    else if (micResult.Contains(">0.5"))
                                        vo.perCount_4++;
                                    else if (micResult.Contains(">1"))
                                        vo.perCount_5++;
                                    else if (micResult.Contains(">2"))
                                        vo.perCount_6++;
                                    else if (micResult.Contains(">4"))
                                        vo.perCount_7++;
                                    else if (micResult.Contains(">8"))
                                        vo.perCount_8++;
                                    else if (micResult.Contains(">16"))
                                        vo.perCount_9++;
                                    else if (micResult.Contains(">32"))
                                        vo.perCount_10++;
                                    else if (micResult.Contains(">64"))
                                        vo.perCount_11++;
                                    else if (micResult.Contains(">128"))
                                        vo.perCount_11++;
                                    vo.total = 1;
                                    data.Add(vo);
                                }
                            }
                        }
                    }
                }

                decimal temp = 0;
                m_objViewer.dwResult.SetRedrawOff();
                for (int intI = 0; intI < data.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    m_objViewer.dwResult.SetItemString(row, "antiname", data[intI].antiname);
                    m_objViewer.dwResult.SetItemString(row, "count", data[intI].total.ToString());
                    if (data[intI].perCount_1 > 0)
                    {
                        temp = data[intI].perCount_1 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_1", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_2 > 0)
                    {
                        temp = data[intI].perCount_2 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_2", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_3 > 0)
                    {
                        temp = data[intI].perCount_3 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_3", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_4 > 0)
                    {
                        temp = data[intI].perCount_4 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_4", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_5 > 0)
                    {
                        temp = data[intI].perCount_5 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_5", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_6 > 0)
                    {
                        temp = data[intI].perCount_6 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_6", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_7 > 0)
                    {
                        temp = data[intI].perCount_7 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_7", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_8 > 0)
                    {
                        temp = data[intI].perCount_8 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_8", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_9 > 0)
                    {
                        temp = data[intI].perCount_9 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_9", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_10 > 0)
                    {
                        temp = data[intI].perCount_10 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_10", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_11 > 0)
                    {
                        temp = data[intI].perCount_11 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_11", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }

                    if (data[intI].perCount_12 > 0)
                    {
                        temp = data[intI].perCount_12 / data[intI].total;
                        m_objViewer.dwResult.SetItemString(row, "percent_12", temp == 1 ? "100%" : temp.ToString("0.00%"));
                    }
                }
                string strDatFrom = m_objViewer.m_dtpDatFrom.Value.ToString("yyyy-MM-dd");
                string strDatTo = m_objViewer.m_dtpDatTo.Value.ToString("yyyy-MM-dd");
                m_objViewer.dwResult.Modify("t_date.text ='" + strDatFrom + " ~ " + strDatTo + "'");
                m_objViewer.dwResult.Modify("t_sampletype.text = '" + m_objViewer.cbxSampleType.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_pattype.text = '" + m_objViewer.cbxDistrict.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_sex.text = '" + m_objViewer.cbxSex.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_age.text = '" + AgeFrom + "至" + AgeTo + "'");
                //m_objViewer.dwResult.Modify("t_testmethod.text = '实验方法：" + m_objViewer.cbxTestMethod.Text.Trim() + "'");  

                m_objViewer.dwResult.SetRedrawOn();
                m_objViewer.dwResult.Refresh();

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }
        #endregion

        #region 敏感率报告统计报表
        /// <summary>
        /// 敏感率报告统计报表
        /// </summary>
        public void m_mthGetSensitiveRate()
        {
            DataTable dtbResult;
            if (m_objViewer.dgv_mic.Rows.Count > 1)
            {
                strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            }
            else
            {
                strTempName = null;
            }

            //long lngRes = m_objManage.lngGetSensitiveRate(
            //     strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, strTempAntiID, out dtbResult);

            strTempName = m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            long lngRes = m_objManage.lngGetMicSensitive(dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, TestMethod, strTempAntiID, out dtbResult);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                DataTable dt = ChangeTable(dtbResult);
                if (dt.Columns.Count > 110)
                {
                    MessageBox.Show("查询错误：查询时间范围过长，", dt.Columns.Count.ToString());
                    return;
                }
                this.FillDWSensitiveRate(dt);

            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }

        /// <summary>
        /// 转换table的结构
        /// </summary>
        /// <param name="dtTable"></param>
        /// <returns></returns>
        public DataTable ChangeTable(DataTable dtTable)
        {
            int i = 0, j = 0;
            int count = 0;//新表行数
            decimal total = 0;
            decimal num = 0;
            decimal temp;
            DataTable dtbResult = new DataTable();
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = @"抗生素\细菌";
            dtbResult.Columns.Add(dc);
            DataRow dr = null;

            DataRow dtrFrom = null;
            DataRow dtrTo = null;

            for (i = 0; i < dtTable.Rows.Count; i++)
            {
                dtrFrom = dtTable.Rows[i];
                for (j = 0; j < dtbResult.Columns.Count; j++)
                {
                    //查找列
                    if (dtrFrom["micname"].ToString() == dtbResult.Columns[j].ColumnName)
                    {
                        break;
                    }
                }
                if (j == dtbResult.Columns.Count)
                {
                    //添加列
                    dtbResult.Columns.Add("细菌株数(" + j.ToString() + ")");
                    dtbResult.Columns.Add(dtrFrom["micname"].ToString());
                }
            }

            //新表新建一行
            dtrFrom = dtTable.Rows[0];
            dr = dtbResult.NewRow();
            dr[0] = dtrFrom["antiname"].ToString();
            dtbResult.Rows.Add(dr);
            ++count;
            //向新表添加数据
            for (i = 0; i < dtTable.Rows.Count; i++)
            {
                dtrFrom = dtTable.Rows[i];
                dtrTo = dtbResult.Rows[count - 1];
                if (dtrFrom["antiname"].ToString() == dtrTo[0].ToString())
                {
                    for (j = 0; j < dtbResult.Columns.Count; j += 2)
                    {

                        if (dtrFrom["micname"].ToString() == dtbResult.Columns[j].ColumnName.ToString())
                        {
                            if (dtrFrom["total"].ToString() != String.Empty)
                            {
                                total = decimal.Parse(dtrFrom["total"].ToString());
                                dtrTo[j - 1] = dtrFrom["total"].ToString();
                                num = decimal.Parse(dtrFrom["s_num"].ToString());
                                temp = num / total;
                                dtrTo[j] = temp.ToString("0.00%");
                            }
                            break;
                        }
                    }
                }
                else
                {
                    dr = dtbResult.NewRow();
                    dr[0] = dtrFrom["antiname"].ToString();
                    dtbResult.Rows.Add(dr);
                    count++;
                    dtrTo = dtbResult.Rows[count - 1];
                    for (j = 0; j < dtbResult.Columns.Count; j += 2)
                    {
                        if (dtrFrom["micname"].ToString() == dtbResult.Columns[j].ColumnName.ToString())
                        {
                            if (dtrFrom["total"].ToString() != String.Empty)
                            {
                                total = decimal.Parse(dtrFrom["total"].ToString());
                                dtrTo[j - 1] = dtrFrom["total"].ToString();
                                num = decimal.Parse(dtrFrom["s_num"].ToString());
                                temp = num / total;
                                dtrTo[j] = temp.ToString("0.00%");
                            }
                            break;
                        }
                    }
                }
            }

            for (i = 0; i < dtbResult.Rows.Count; i++)
            {
                for (j = 0; j < dtbResult.Columns.Count; j++)
                {
                    if (dtbResult.Rows[i][j].ToString() == String.Empty)
                    {
                        dtbResult.Rows[i][j] = "*";
                    }
                }

            }

            return dtbResult;
        }

        /// <summary>
        /// 填充DW  敏感率报告统计报表
        /// </summary>
        /// <param name="dtbResult"></param>
        public void FillDWSensitiveRate(DataTable dtTable)
        {
            try
            {
                int i = 0, j = 0;
                int rowCount = 0;//新表行数
                DataTable dtbResult = new DataTable();
                DataColumn dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = @"抗生素\细菌";
                dtbResult.Columns.Add(dc);
                DataRow dr = null;
                DataRow dtrFrom = null;

                //int monthCuont = dtDateFrom.Month - dteDateTo.Month;

                //for (int mI = 0; mI < monthCuont; mI++)
                //{
                //    dtbResult.Columns.Add(dtDateFrom.AddMonths(mI).ToString("yyyy-MM"));
                //}

                int flgXJMC = 0;
                int flgKSS = 0;

                //向新表添加数据
                for (i = 0; i < dtTable.Rows.Count; i++)
                {
                    flgXJMC = 0;
                    dtrFrom = dtTable.Rows[i];
                    string month = Convert.ToDateTime(dtrFrom["BGSJ"]).ToString("yyyy-MM");

                    string XJMC = dr["XJMC"].ToString().Trim();
                    if (XJMC.Contains("无"))
                        continue;

                    XJMC = XJMC.Replace("1、", "").Replace("2、", "").Replace("1.", "").Replace("2.", "");

                    #region 行  抗生素

                    for (int drI = 0; drI < dtbResult.Columns.Count; drI++)
                    {
            
                    }

                    if (flgKSS == 1)
                    {

                    }
                    else
                    { 


                    }

                    #endregion

                    #region   列  细菌
                    for (int dcI = 0; dcI < dtbResult.Columns.Count; dcI++)
                    {
                        string nameTemp = dtbResult.Rows[dcI][0].ToString();

                        if (nameTemp.Contains(XJMC))
                        {
                            flgXJMC = 1;
                        }
                    }

                    if (flgXJMC == 1)
                    {
                       
                    }
                    else
                    {
                        dtbResult.Columns.Add(XJMC);
                    }
                    #endregion

                    
                }

                m_objViewer.dgvMicdistributiontend.DataSource = dtbResult;
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }

        #endregion

    }
}