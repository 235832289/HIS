using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using com.digitalwave.iCare.gui.LIS.Report;
using System.Text.RegularExpressions;
using Sybase.DataWindow;
using com.digitalwave.iCare.gui.HIS;
namespace com.digitalwave.iCare.gui.LIS
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

        /// <summary>
        /// 类变量
        /// </summary>
        internal int strQuery;
        private frmMicReport m_objViewer;
        string strTempName=null;
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
            m_objViewer.tabContorl.Visible=false;
            m_objViewer.m_cboCondition.Items.AddRange(new object[] { "细菌分布趋势报告", "敏感率报告","敏感率趋势报告","累计敏感性报告","累计MIC报告","细菌分布报告统计" });

            m_objManage.lngGetDeptName(out dtbResult);
            //m_objViewer.cbxDistrict.DataSource = dtbResult;
            //m_objViewer.cbxDistrict.ValueMember = "dictid_chr";
            //m_objViewer.cbxDistrict.DisplayMember = "dictname_vchr";
            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                m_objViewer.cbxDistrict.Items.Add(dtbResult.Rows[i]["dictname_vchr"].ToString());
            }

            m_objManage.lngGetSamType(out dtbResult);
            //m_objViewer.cbxSampleType.DataSource = dtbResult;
            //m_objViewer.cbxSampleType.ValueMember = "sample_type_id_chr";
            //m_objViewer.cbxSampleType.DisplayMember = "sample_type_desc_vchr";
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
            long lngRes = m_objManage.lngGetBacteriaDistribution(strTempName,dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, out dtbResult);
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
            {   DataRow dtFr;
                decimal total=0;
                decimal percentage = 0;
                int row = 0;
                m_objViewer.dwResult.SetRedrawOff();
                for (int i = 0; i< dtbResult.Rows.Count; i++)
                {
                    total += decimal.Parse(dtbResult.Rows[i][1].ToString());
                }
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    dtFr = dtbResult.Rows[intI];
                    m_objViewer.dwResult.SetItemString(row, "细菌名称", dtFr["micname"].ToString());
                    m_objViewer.dwResult.SetItemDecimal(row, "细菌株数", decimal.Parse(dtFr["miccount"].ToString()));
                    percentage = decimal.Parse(dtFr["miccount"].ToString()) / total;
                    m_objViewer.dwResult.SetItemString(row, "百分比", percentage.ToString("0.00%"));
                  
                }               

                m_objViewer.dwResult.Modify("t_datefrom.text = '(" + m_objViewer.m_dtpDatFrom.Value.ToString("yyyy-MM-dd") + "'");
                m_objViewer.dwResult.Modify("t_dateto.text = '" + m_objViewer.m_dtpDatTo.Value.ToString("yyyy-MM-dd") + ")'");

                m_objViewer.dwResult.Modify("t_samtype.text = '标本类型："+ m_objViewer.cbxSampleType.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_district.text = '病人类型：" + m_objViewer.cbxDistrict.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_sex.text = '性别：" + m_objViewer.cbxSex.Text.Trim() + "'");
                m_objViewer.dwResult.Modify("t_age.text = '年龄：" + AgeFrom+"至"+AgeTo + "'");
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
            //strTempID = m_objViewer.dgv_mic.Rows[0].Cells[0].Value.ToString();
            strTempName=m_objViewer.dgv_mic.Rows[0].Cells[1].Value.ToString();
            long lngRes = m_objManage.lngGetMicSensitive(strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, strTempAntiID, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWMicSensitive(dtbResult);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            } 
        }

        public void FillDWMicSensitive(DataTable dtbResult)
        {
            try
            {
                DataRow dtFr;
                int row = 0;
                m_objViewer.dwResult.SetRedrawOff();
                decimal dectemp = 0;
                decimal total = 0;
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    dtFr = dtbResult.Rows[intI];
                    m_objViewer.dwResult.SetItemString(row, "antiname", dtFr["antiname"].ToString());

                    total=decimal.Parse(dtFr["miccount"].ToString());
                    m_objViewer.dwResult.SetItemDecimal(row, "miccount",total );

                    dectemp = decimal.Parse(dtFr["sensitive"].ToString()) / total;
                    m_objViewer.dwResult.SetItemString(row, "sensitive", dectemp.ToString("0.00%"));

                    dectemp = decimal.Parse(dtFr["intermediary"].ToString()) / total;
                    m_objViewer.dwResult.SetItemString(row, "intermediary", dectemp.ToString("0.00%"));

                    dectemp = decimal.Parse(dtFr["resistance"].ToString()) / total;
                    m_objViewer.dwResult.SetItemString(row, "resistance", dectemp.ToString("0.00%"));
                }
                m_objViewer.dwResult.Modify("t_name.text='"+strTempName+"'");

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
           
            long lngRes = m_objManage.lngGetMicdistributionTend(strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWMicdistributionTend(dtbResult);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }
        /// <summary>
        ///填充 累计敏感性报表
        /// </summary>
        /// <param name="dtbResult"></param>
        public void FillDWMicdistributionTend(DataTable dtbResult)
        {
            try
            {
                DataRow dtFr;
                int row = 0;
                m_objViewer.dwResult.SetRedrawOff();
                decimal dectemp1 = 0;
                decimal dectemp2 = 0;
                decimal totaltemp = 0;
                decimal dectemp3 = 0;
                decimal sum = 0;
                string strTemp = null;
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    dtFr = dtbResult.Rows[intI];
                    totaltemp +=decimal.Parse(dtFr["total"].ToString());
                }
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    dtFr = dtbResult.Rows[intI];
                    sum = decimal.Parse(dtFr["total"].ToString());
                    m_objViewer.dwResult.SetItemString(row, "micname", dtFr["micname"].ToString() + "(" + sum.ToString() + ")");

                    dectemp3 = decimal.Parse(dtFr["month1"].ToString());
                    dectemp1 = dectemp3 / sum;
                    dectemp2 = dectemp3 / totaltemp;
                    strTemp = dectemp1.ToString("0.00%") + "/(" + dectemp3.ToString() + ")/" + dectemp2.ToString("0.00%");
                    m_objViewer.dwResult.SetItemString(row, "monfirst", strTemp);

                    dectemp3 = decimal.Parse(dtFr["month2"].ToString());
                    dectemp1 = dectemp3 / sum;
                    dectemp2 = dectemp3 / totaltemp;
                    strTemp = dectemp1.ToString("0.00%") + "/(" + dectemp3.ToString() + ")/" + dectemp2.ToString("0.00%");
                    m_objViewer.dwResult.SetItemString(row, "monsecond", strTemp);

                    dectemp3 = decimal.Parse(dtFr["month3"].ToString());
                    dectemp1 = dectemp3 / sum;
                    dectemp2 = dectemp3 / totaltemp;
                    strTemp = dectemp1.ToString("0.00%") + "/(" + dectemp3.ToString() + ")/" + dectemp2.ToString("0.00%");
                    m_objViewer.dwResult.SetItemString(row, "monthree", strTemp);
                }
                m_objViewer.dwResult.Modify("t_total.text='" + totaltemp.ToString() + "'");
                 
                DateTime dateTo = dtDateTo; 

                m_objViewer.dwResult.Modify("t_month1.text='" + dateTo.AddMonths(-2).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month2.text='" + dateTo.AddMonths(-1).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month3.text='" + dateTo.ToString("yyyy-MM")+"'");
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
                    m_objViewer.dwResult.SetItemString(row, "antiname", dtFr["antiname"].ToString ());
                    m_objViewer.dwResult.SetItemString(row, "month1p",result1 );
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
                m_objViewer.dwResult.Modify("t_month1.text='" + dateTo.AddMonths(-3).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month12.text='" + dateTo.AddMonths(-3).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month2.text='" + dateTo.AddMonths(-2).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month22.text='" + dateTo.AddMonths(-2).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month3.text='" + dateTo.AddMonths(-1).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month32.text='" + dateTo.AddMonths(-1).ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month4.text='" + dateTo.ToString("yyyy-MM")+"'");
                m_objViewer.dwResult.Modify("t_month42.text='" + dateTo.ToString("yyyy-MM")+"'");

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
            long lngRes = m_objManage.lngGetMicCumulative(strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, strTempAntiID, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                this.FillDWMicCumulative(dtbResult);
            }
            else
            {
                MessageBox.Show("没有相关数据。");
            }
        }

        public void FillDWMicCumulative(DataTable dtbResult)
        {
            try
            {
                DataRow dtFr;
                int row = 0;
                decimal temp = 0;
                decimal tested=0;
                decimal num = 0;
                m_objViewer.dwResult.SetRedrawOff();
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    dtFr = dtbResult.Rows[intI];

                    m_objViewer.dwResult.SetItemString(row, "antiname",dtFr["antiname"].ToString ());
                    tested=decimal.Parse (dtFr["tested"].ToString());
                    m_objViewer.dwResult.SetItemDecimal(row, "tested", tested);
                    num = decimal.Parse(dtFr["p_2"].ToString());
                    temp =num/tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_2", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_3"].ToString());
                    temp = num/tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_3", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_4"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_4", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_5"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_5", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_6"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_6", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_7"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_7", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_8"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_8", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_9"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_9", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_10"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_10", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_11"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_11", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    num += decimal.Parse(dtFr["p_12"].ToString());
                    temp = num / tested;
                    m_objViewer.dwResult.SetItemString(row, "percent_12", temp.ToString("0.00%"));
                    if (temp == 1)
                    {
                        continue;
                    }
                    m_objViewer.dwResult.SetItemString(row, "percent_13", "100%"); 
                }
                m_objViewer.dwResult.Modify("t_from.text='(" + dtDateFrom.ToString("yyyy-MM-dd") + "'");
                m_objViewer.dwResult.Modify("t_to.text='" + dtDateTo.ToString("yyyy-MM-dd") + ")'");
                m_objViewer.dwResult.Modify("t_micname.text='" + strTempName + "'");

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
            long lngRes = m_objManage.lngGetSensitiveRate(
                 strTempName, dtDateFrom, dtDateTo, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, strTempAntiID, out dtbResult);
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
            //for (i = 0; i < dtTable.Rows.Count; i++)
            //{
            //    dtrFrom = dtTable.Rows[i];
            //    for (j = 0; j < dtbResult.Columns.Count; j++)
            //    {
            //        //查找列
            //        if (dtrFrom["micname"].ToString() == dtbResult.Columns[j].ColumnName)
            //        {
            //            break;
            //        }
            //    }
            //    if (j == dtbResult.Columns.Count)
            //    {
            //        //添加列
            //        dtbResult.Columns.Add("细菌株数(" + j.ToString() + ")");
            //        dtbResult.Columns.Add(dtrFrom["micname"].ToString());
            //    }
            //}

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
        public void FillDWSensitiveRate(DataTable dtbResult)
        {
            try
            {
                DataRow dtFr;
                int row = 0;
                int i = 0, j = 0;
                int n = 0;
                int nowCount = 0;
                string tempName = null;
                decimal num = 0;
                string temp = null;
                string tt = null; ;
                decimal max = 0;
                int count = 0;      

                m_objViewer.dwResult.SetRedrawOff();

                for (i = 0; i < dtbResult.Columns.Count; i++)
                {
                    tempName = "name_" + i.ToString() + "_t.text=";
                    if (i % 2 == 0)
                    {
                        temp = tempName + "\"" + dtbResult.Columns[i].ColumnName + "\"";
                    }
                    else
                    {
                        for (int k = 0; k < dtbResult.Rows.Count; k++)
                        {
                            if (decimal.TryParse(dtbResult.Rows[k][i].ToString(), out num))
                            {
                                if (max < num)
                                    max = num;
                            }
                        }
                        temp = tempName + "\"细菌株数(" + max.ToString() + ")\"";
                    }
                    m_objViewer.dwResult.Modify(temp);
                    n = dtbResult.Columns[i].ColumnName.Length;
                    if (i % 2 == 0 && n>=6)
                    {

                        if (n > 8)
                        {
                            tt = "name_" + i.ToString() + "_t.Width= '160'";
                            m_objViewer.dwResult.Modify(tt);
                            temp = "name_" + i.ToString() + ".Width= '160'";
                            m_objViewer.dwResult.Modify(temp);
                        }
                        else
                        {
                            tt = "name_" + i.ToString() + "_t.Width= '120'";
                            m_objViewer.dwResult.Modify(tt);
                            temp = "name_" + i.ToString() + ".Width= '120'";
                            m_objViewer.dwResult.Modify(temp);
                        }
                    }
                    else
                    {
                        tt = "name_" + i.ToString() + "_t.Width= '90'";
                        m_objViewer.dwResult.Modify(tt);
                        temp = "name_" + i.ToString() + ".Width= '90'";
                        m_objViewer.dwResult.Modify(temp);
                    }

                    //显示
                    tt = "name_" + i.ToString() + "_t.visible = '1'";
                    m_objViewer.dwResult.Modify(tt);
                    temp = "name_" + i.ToString() + ".visible = '1'";
                    m_objViewer.dwResult.Modify(temp);
                  
                    count++;
                    max = 0;
                }
                
                tt = "name_0_t.Width= '150'";
                m_objViewer.dwResult.Modify(tt);
                temp = "name_0.Width= '150'";
                m_objViewer.dwResult.Modify(temp);

                nowCount = j;
                for (int intI = 0; intI < dtbResult.Rows.Count; intI++)
                {
                    row = this.m_objViewer.dwResult.InsertRow(0);
                    dtFr = dtbResult.Rows[intI];
                    for (i = 0; i < dtbResult.Columns.Count; i++)
                    {
                        temp = "name_" + i.ToString();
                        m_objViewer.dwResult.SetItemString(row, temp, dtFr[i].ToString());
                    }
                }
                if (dtbResult.Columns.Count <=3)
                {
                    //不显示
                    tt = "name_3_t.visible = '0'";
                    m_objViewer.dwResult.Modify(tt);
                    tt = "name_4_t.visible = '0'";
                    m_objViewer.dwResult.Modify(tt);
                    i = 5;
                }
                else
                {
                    i = dtbResult.Columns.Count ;
                }
                for (; i <= 110; i++)
                {
                    //不显示
                    tt = "name_" + i.ToString() + "_t.visible = '0'";
                    m_objViewer.dwResult.Modify(tt);
                    temp = "name_" + i.ToString() + ".visible = '0'";
                    m_objViewer.dwResult.Modify(temp);
                }

                temp = "(" + this.dtDateFrom.ToShortDateString();
                m_objViewer.dwResult.Modify("t_from.text='" + temp + "'");               
                m_objViewer.dwResult.Modify("t_from.visible='1'");
                temp ="至"+ this.dtDateTo.ToShortDateString()+")";
                m_objViewer.dwResult.Modify("t_to.text='" + temp + "'");
                m_objViewer.dwResult.Modify("t_to.visible='1'");

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

    }
}