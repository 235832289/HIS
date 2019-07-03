using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmRptAdjustPrice : Form
    {
        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public frmRptAdjustPrice()
        {
            InitializeComponent();
        }
        #endregion

        #region 属性.变量

        static clsLogText log = null;
        static string strFileName = string.Empty;
        Transaction pbTrans = null;

        #endregion

        #region 方法

        #region SetTrans
        /// <summary>
        /// SetTrans
        /// </summary>
        void SetTrans()
        {
            string ServerName = string.Empty;
            string UserID = string.Empty;
            string Pwd = string.Empty;
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);
            pbTrans = new Transaction();
            pbTrans.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;
            pbTrans.ServerName = ServerName;
            pbTrans.UserId = UserID;
            pbTrans.Password = Pwd;
            pbTrans.AutoCommit = true;
            pbTrans.Connect();
        }
        #endregion

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.dwRep.DataWindowObject = null;
            this.dwRep.LibraryList = Application.StartupPath + "\\pbreport.pbl";
            this.dwRep.DataWindowObject = "d_rpt_adjustprice";
            this.dwRep.SetTransaction(pbTrans);
        }
        #endregion

        #region Stat
        /// <summary>
        /// Stat
        /// </summary>
        void Stat()
        {
            Init();
            string beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string endDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            string effectDate = this.dteEffect.Value.ToString("yyyy-MM-dd");
            List<DataTable> dtData = new List<DataTable>();

            if (Convert.ToDateTime(beginDate + " 00:00:01") > Convert.ToDateTime(endDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            beginDate += " 00:00:00";
            endDate += " 23:59:59";
            effectDate += " 00:00:00";

            try
            {
                clsPublic.PlayAvi("请稍候...");
                dwRep.Modify("t_date.text = '统计时间: " + beginDate + " - " + endDate + "'");

                #region 构造表
                DataTable dtPrice = new DataTable();
                dtPrice.Columns.Add("feeClass", typeof(string));
                dtPrice.Columns.Add("feeNum", typeof(decimal));
                dtPrice.Columns.Add("feeSum", typeof(decimal));
                dtPrice.Columns.Add("deptName", typeof(string));
                dtPrice.Columns.Add("deptNum", typeof(decimal));
                dtPrice.Columns.Add("deptSum", typeof(decimal));
                #endregion

                DataTable dtItem = new DataTable();
                DataTable dtCharge = new DataTable();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                svc.GetAdjustPrice(beginDate, endDate, effectDate, out dtItem, out dtCharge);

                if (dtItem != null && dtItem.Rows.Count > 0 && dtCharge != null && dtCharge.Rows.Count > 0)
                {
                    #region compute
                    string childClassName = "儿童项目上调30%";
                    string mateClassName = "取消300元以下耗材加成";
                    string calcClassName = string.Empty;
                    string itemId = string.Empty;
                    string ischildprice = string.Empty;
                    string deptName = string.Empty;
                    string catId = string.Empty;
                    string medTypeId = string.Empty;
                    decimal prePrice = 0;
                    decimal curPrice = 0;
                    decimal qty = 0;
                    decimal total = 0;
                    string birthday = string.Empty;
                    string recordDate = string.Empty;
                    DataView dv = new DataView(dtCharge);
                    object[] objs = new object[4];
                    DataRow[] drr = null;
                    DataRow drPrice = null;
                    foreach (DataRow dr in dtItem.Rows)
                    {
                        itemId = dr["itemid"].ToString();
                        ischildprice = dr["ischildprice"].ToString();
                        //beginDate = dr["begindate"].ToString();
                        //endDate = dr["enddate"].ToString();
                        prePrice = clsPublic.ConvertObjToDecimal(dr["preprice"].ToString());
                        curPrice = clsPublic.ConvertObjToDecimal(dr["curprice"].ToString());
                        objs[0] = itemId;
                        objs[1] = curPrice;
                        objs[2] = beginDate;
                        objs[3] = endDate;
                        dv.RowFilter = string.Format("itemid = '{0}' and (recdate >= '{2}' and recdate <= '{3}')", objs);
                        if (dv.Count > 0)
                        {
                            foreach (DataRowView drv in dv)
                            {
                                catId = drv["catid"].ToString();
                                medTypeId = drv["medtypeid"].ToString();
                                deptName = drv["deptname"].ToString().Trim();
                                calcClassName = drv["calctypename"].ToString();
                                qty = clsPublic.ConvertObjToDecimal(drv["qty"]);
                                total = clsPublic.Round((curPrice - prePrice) * qty, 2);
                                recordDate = drv["recdate"].ToString();
                                birthday = Convert.ToDateTime(drv["birth_dat"].ToString()).ToString("yyyy-MM-dd");
                                bool isChild = IsChild(Convert.ToDateTime(Convert.ToDateTime(birthday).ToString("yyyy-MM-dd")));

                                // 儿童价格
                                if (dr["ischildprice"].ToString() == "1" && isChild && Convert.ToDateTime(recordDate) >= Convert.ToDateTime("2019-03-01 00:00:00"))
                                {
                                    drr = dtPrice.Select(string.Format("feeClass = '{0}' and deptName = '{1}'", childClassName, deptName));
                                    prePrice = clsPublic.ConvertObjToDecimal(drv["price"].ToString()) / clsPublic.ConvertObjToDecimal(1.3);
                                    curPrice = clsPublic.ConvertObjToDecimal(drv["price"].ToString());
                                    total = clsPublic.Round((curPrice - prePrice) * qty, 2);

                                    if (drr != null && drr.Length > 0)
                                    {
                                        drr[0]["deptNum"] = clsPublic.ConvertObjToDecimal(drr[0]["deptNum"]) + qty;
                                        drr[0]["deptSum"] = clsPublic.ConvertObjToDecimal(drr[0]["deptSum"]) + total;
                                    }
                                    else
                                    {
                                        drPrice = dtPrice.NewRow();
                                        drPrice["feeClass"] = childClassName;
                                        drPrice["deptName"] = deptName;
                                        drPrice["deptNum"] = qty;
                                        drPrice["deptSum"] = Convert.ToDouble(total) ;
                                        dtPrice.LoadDataRow(drPrice.ItemArray, true);
                                    }
                                }
                                else
                                {
                                    //if ((catId == "2" || catId == "4" || catId == "8") && curPrice < 300)     // 300元以下耗材
                                    if (medTypeId == "8" && curPrice < 300)                                   // 300元以下耗材
                                    {
                                        total = clsPublic.Round((curPrice / 1.1m) * 0.1m * qty, 2);           // 加成 10%
                                        drr = dtPrice.Select(string.Format("feeClass = '{0}' and deptName = '{1}'", mateClassName, deptName));
                                        if (drr != null && drr.Length > 0)
                                        {
                                            drr[0]["deptNum"] = clsPublic.ConvertObjToDecimal(drr[0]["deptNum"]) + qty;
                                            drr[0]["deptSum"] = clsPublic.ConvertObjToDecimal(drr[0]["deptSum"]) + total;
                                        }
                                        else
                                        {
                                            drPrice = dtPrice.NewRow();
                                            drPrice["feeClass"] = mateClassName;
                                            drPrice["deptName"] = deptName;
                                            drPrice["deptNum"] = qty;
                                            drPrice["deptSum"] = total;
                                            dtPrice.LoadDataRow(drPrice.ItemArray, true);
                                        }
                                    }
                                    else
                                    {
                                        drr = dtPrice.Select(string.Format("feeClass = '{0}' and deptName = '{1}'", calcClassName, deptName));
                                        if (drr != null && drr.Length > 0)
                                        {
                                            drr[0]["deptNum"] = clsPublic.ConvertObjToDecimal(drr[0]["deptNum"]) + qty;
                                            drr[0]["deptSum"] = clsPublic.ConvertObjToDecimal(drr[0]["deptSum"]) + total;
                                        }
                                        else
                                        {
                                            drPrice = dtPrice.NewRow();
                                            drPrice["feeClass"] = calcClassName;
                                            drPrice["deptName"] = deptName;
                                            drPrice["deptNum"] = qty;
                                            drPrice["deptSum"] = total;
                                            dtPrice.LoadDataRow(drPrice.ItemArray, true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region sum

                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                    {
                        Dictionary<string, decimal> dicFeeNum = new Dictionary<string, decimal>();
                        Dictionary<string, decimal> dicFeeSum = new Dictionary<string, decimal>();
                        foreach (DataRow dr in dtPrice.Rows)
                        {
                            calcClassName = dr["feeClass"].ToString();
                            if (dicFeeNum.ContainsKey(calcClassName))
                            {
                                dicFeeNum[calcClassName] += clsPublic.ConvertObjToDecimal(dr["deptNum"]);
                                dicFeeSum[calcClassName] += clsPublic.ConvertObjToDecimal(dr["deptSum"]);
                            }
                            else
                            {
                                dicFeeNum.Add(calcClassName, clsPublic.ConvertObjToDecimal(dr["deptNum"]));
                                dicFeeSum.Add(calcClassName, clsPublic.ConvertObjToDecimal(dr["deptSum"]));
                            }
                        }
                        foreach (DataRow dr in dtPrice.Rows)
                        {
                            calcClassName = dr["feeClass"].ToString();
                            dr["feeNum"] = dicFeeNum[calcClassName];
                            dr["feeSum"] = dicFeeSum[calcClassName];
                        }
                    }
                    #endregion
                }
                if (dtPrice != null && dtPrice.Rows.Count > 0)
                {
                    svc.SaveAdjustPrice(dtPrice);
                }
                svc = null;

                dwRep.SetSqlSelect(@"select feeClass, feeNum, feeSum, deptName, deptSum from t_rpt_adjustprice");
                //dwRep.SetRedrawOff();
                dwRep.Retrieve();
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


        #region IsChild
        /// <summary>
        /// IsChild
        /// </summary>
        /// <param name="dtmBirth"></param>
        /// <returns></returns>
        bool IsChild(DateTime dtmBirth)
        {
            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtmBirth = Convert.ToDateTime(dtmBirth.ToString("yyyy-MM-dd"));
            // 年、月、日
            int year, month, day;

            //计算：天
            day = dtmNow.Day - dtmBirth.Day;
            if (day < 0)
            {
                day += System.DateTime.DaysInMonth(dtmBirth.Year, dtmBirth.Month);
                dtmBirth = dtmBirth.AddMonths(1);
            }
            //计算：月
            month = dtmNow.Month - dtmBirth.Month;
            if (month < 0)
            {
                month += 12;
                dtmBirth = dtmBirth.AddYears(1);
            }
            //计算：年
            year = dtmNow.Year - dtmBirth.Year;

            if ((year > 6) || (year == 6 && (month > 0 || day > 0)))
                return false;
            else
                return true;
        }
        #endregion

        #endregion

        #region 事件

        private void frmRptAdjustPrice_Load(object sender, EventArgs e)
        {
            this.SetTrans();
            this.Init();
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            log = new clsLogText();
            strFileName = Application.StartupPath + "\\log" + "\\log.txt";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Stat();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            #region export
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
            #endregion
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
