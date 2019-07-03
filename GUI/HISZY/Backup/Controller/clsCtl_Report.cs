using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Sybase.DataWindow;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 报表控制类
    /// </summary>
    public class clsCtl_Report : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// Domain-Report
        /// </summary>
        private clsDcl_Report objReport;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string hospname = "";
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName
        {
            get
            {
                return hospname;
            }
            set
            {
                hospname = value;
            }
        }

        /// <summary>
        /// Added by: 吴汉明 2014-12-25  让利启用开关
        /// </summary>
        internal int intDiffCostOn = 0;
        /// <summary>
        /// 数据库连接参数
        /// </summary>
        private string SQLParm = "";
        /// <summary>
        /// 登录员所属科室(病区)ID列表
        /// </summary>
        internal ArrayList objDeptIDArr = new ArrayList();

        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_Report()
        {
            objReport = new clsDcl_Report();
            hospname = this.m_objComInfo.m_strGetHospitalTitle();
            this.m_mthGetSQLParm();
            //Added by: 吴汉明 2014-12-25 是否启用让利
            this.intDiffCostOn = clsPublic.m_intGetSysParm("9002");
        }
        #endregion

        #region 获取数据库连接参数
        /// <summary>
        /// 获取数据库连接参数
        /// </summary>
        public void m_mthGetSQLParm()
        {
            string tmpfs = clsPublic.XMLFile;
            clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";

            string Server = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "ServerName", "AnyOne");
            string DBname = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "DataBase", "AnyOne");
            string UserID = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "LogID", "AnyOne");
            string PassWord = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "LogPassWord", "AnyOne");

            SQLParm = "server=" + Server + ";database=" + DBname + ";uid=" + UserID + ";pwd=" + PassWord;

            clsPublic.XMLFile = tmpfs;

            #region 登录员所属科室(病区)ID列表
            clsDepartmentVO[] DeptVO;
            this.m_objComInfo.m_mthGetAllDeptArr(out DeptVO);
            if (DeptVO != null)
            {
                for (int i = 0; i < DeptVO.Length; i++)
                {
                    objDeptIDArr.Add(((clsDepartmentVO)DeptVO[i]).strDeptID);
                }
            }
            #endregion
        }
        #endregion

        #region 每日清单
        /// <summary>
        /// 每日清单
        /// </summary>
        /// <param name="RepID"></param>        
        /// <param name="ID"></param>        
        /// <param name="BillDate"></param>
        /// <param name="Type"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptEveryDayBill(string RepID, string ID, string BillDate, int Type, DataWindowControl dwRep)
        {
            DataTable dt;
            long l = this.objReport.m_lngRptEveryDayBillFee(ID, BillDate, Type, out dt);
            if (l > 0)
            {
                //获取病人ID列表
                string RegID = "";
                ArrayList RegIDArr = new ArrayList();
                decimal decDiffCost = 0, dec_Total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RegID = dt.Rows[i]["registerid_chr"].ToString();

                    if (RegIDArr.IndexOf(RegID) == -1)
                    {
                        RegIDArr.Add(RegID);
                    }
                    //decDiffCost += clsPublic.ConvertObjToDecimal(dt.Rows[i]["totaldiffcostmoney_dec"]);
                    // dec_Total += clsPublic.Round(clsPublic.ConvertObjToDecimal(dt.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dt.Rows[i]["amount_dec"]), 2);

                }

                //获取PB自定义报表列名                
                ArrayList RepColsArr = new ArrayList();

                for (int i = 1; i < dwRep.ColumnCount + 1; i++)
                {
                    RepColsArr.Add(dwRep.Describe("#" + i.ToString() + ".name"));
                }

                //获取定义表中字段-核算分类
                DataTable dtCat;
                l = this.objReport.m_lngGetCatIDByRptID(RepID, 4, out dtCat);
                if (l > 0 && dtCat.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtCat);

                    Hashtable hasCat = new Hashtable();
                    ArrayList TypeIDArr;

                    for (int j = 0; j < RepColsArr.Count; j++)
                    {
                        string CatID = RepColsArr[j].ToString();

                        //去掉第一字符(建报表默认列名第一字符为：C)
                        dv.RowFilter = "groupid_chr = '" + CatID.Substring(1) + "'";
                        if (dv.Count > 0)
                        {
                            TypeIDArr = new ArrayList();
                            foreach (DataRowView drv in dv)
                            {
                                TypeIDArr.Add(drv["typeid_chr"].ToString());
                            }

                            hasCat.Add(CatID, TypeIDArr);
                        }
                    }

                    try
                    {
                        /***生成报表***/
                        DataView dvCharge = new DataView(dt);
                        dwRep.SetRedrawOff();
                        dwRep.Reset();

                        dwRep.Modify("t_billdate.text = '" + BillDate + "'");
                        dwRep.Modify("t_printdtime.text = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                        for (int j = 0; j < RegIDArr.Count; j++)
                        {
                            RegID = RegIDArr[j].ToString();

                            int row = dwRep.InsertRow(0);

                            //基本信息
                            clsBihEveryDayBill_VO objEveryDayBill;
                            l = this.objReport.m_lngRptEveryDayBill(RegID, BillDate, out objEveryDayBill);
                            if (l > 0)
                            {
                                dwRep.SetItemString(row, "zyh", objEveryDayBill.Zyh);
                                dwRep.SetItemString(row, "name", objEveryDayBill.Name);
                                dwRep.SetItemString(row, "area", objEveryDayBill.AreaName);
                                dwRep.SetItemString(row, "bedno", objEveryDayBill.BedNO);
                                dwRep.SetItemString(row, "prepaymoney", clsPublic.ConvertObjToDecimal(objEveryDayBill.PrePayMoney).ToString("0.00"));
                                dwRep.SetItemString(row, "cleartotal", clsPublic.ConvertObjToDecimal(objEveryDayBill.ClearTotal).ToString("0.00"));
                                dwRep.SetItemString(row, "arrearagetotal", clsPublic.ConvertObjToDecimal(objEveryDayBill.ArrearageTotal).ToString("0.00"));
                                if (this.intDiffCostOn == 1)
                                {
                                    dwRep.SetItemString(row, "currdaytotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.CurrDayTotal) - objEveryDayBill.m_decDayTotalDiffCost).ToString("0.00"));
                                    dwRep.SetItemString(row, "alltotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.AllTotal) - Math.Abs(objEveryDayBill.m_decTotalDiffCost)).ToString("0.00"));
                                    dwRep.SetItemString(row, "totaldiffcost", (clsPublic.ConvertObjToDecimal(objEveryDayBill.m_decDayTotalDiffCost)).ToString("0.00"));
                                }
                                else
                                {
                                    dwRep.SetItemString(row, "currdaytotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.CurrDayTotal)).ToString("0.00"));
                                    dwRep.SetItemString(row, "alltotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.AllTotal)).ToString("0.00"));
                                }
                            }
                            else
                            {
                                clsPublic.CloseAvi();
                                dwRep.SetRedrawOn();
                                dwRep.Refresh();
                                return;
                            }

                            //费用
                            dvCharge.RowFilter = "registerid_chr = '" + RegID + "'";
                            ArrayList CatIDArr = new ArrayList();
                            CatIDArr.AddRange(hasCat.Keys);
                            for (int k = 0; k < CatIDArr.Count; k++)
                            {
                                decimal total = 0;
                                string CatID = CatIDArr[k].ToString();
                                TypeIDArr = hasCat[CatID] as ArrayList;

                                for (int k1 = 0; k1 < TypeIDArr.Count; k1++)
                                {
                                    string TypeID = TypeIDArr[k1].ToString().Trim();
                                    foreach (DataRowView drv in dvCharge)
                                    {
                                        if (drv["invcateid_chr"].ToString().Trim() == TypeID)
                                        {
                                            total += clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]);
                                        }
                                    }
                                }

                                if (total != 0)
                                {
                                    dwRep.SetItemString(row, CatID, total.ToString("0.00"));
                                }
                            }

                        }

                        if (dwRep.RowCount == 0)
                        {
                            dwRep.InsertRow(0);
                        }

                        dwRep.SetRedrawOn();
                        dwRep.Refresh();
                    }
                    catch
                    {
                        clsPublic.CloseAvi();
                        dwRep.SetRedrawOn();
                        dwRep.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// 每日清单(费用明细)
        /// </summary>
        /// <param name="ID"></param>        
        /// <param name="BillDate"></param>
        /// <param name="Type"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptEveryDayBillEntry(string ID, string BillDate, int Type, int ItemCodeType, DataWindowControl dwRep)
        {
            DataTable dt;
            long l = this.objReport.m_lngRptEveryDayBillEntry(ID, BillDate, Type, ItemCodeType, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);
                dwRep.CalculateGroups();

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }

        public DataTable m_dtGetBed(string Areaid)
        {
            if (string.IsNullOrEmpty(Areaid))
            {
                return null;
            }

            DataTable dt;

            long lngRes = this.objReport.m_lngRptGetBednoByAreaid(Areaid, out dt);
            if (lngRes < 0)
            {
                return null;
            }
            return dt;
        }

        /// <summary>
        /// 每日清单(费用明细) ---- 包含合计
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="BillDate"></param>
        /// <param name="Type"></param>
        /// <param name="ItemCodeType"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptEveryDayBillEntry2(string ID, string BillDate, int Type, int ItemCodeType, DataWindowControl dwRep)
        {
            DataTable dt;
            long l = this.objReport.m_lngRptEveryDayBillEntry(ID, BillDate, Type, ItemCodeType, out dt);
            if (l > 0)
            {
                dwRep.Reset();
                dwRep.SetRedrawOff();
                DataRow dr = null;
                Hashtable hasTmp = new Hashtable();
                int row = -1;
                decimal decTotalDiff = 0, decTotalMny = 0, decTotalDiffday = 0;
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    row = dwRep.InsertRow(0);
                    dr = dt.Rows[k];

                    dwRep.SetItemString(row, "registerid", dr["registerid_chr"].ToString());
                    dwRep.SetItemString(row, "lastname", dr["lastname_vchr"].ToString());
                    dwRep.SetItemString(row, "chargedate", dr["chargedate"].ToString());
                    dwRep.SetItemString(row, "inpatientid", dr["inpatientid_chr"].ToString());
                    dwRep.SetItemString(row, "deptname", dr["deptname_vchr"].ToString());
                    dwRep.SetItemString(row, "bedcode", dr["code_chr"].ToString());
                    dwRep.SetItemString(row, "itemname", dr["chargeitemname_chr"].ToString());
                    dwRep.SetItemString(row, "spec", dr["spec_vchr"].ToString());
                    dwRep.SetItemString(row, "unit", dr["unit_vchr"].ToString());
                    dwRep.SetItemString(row, "price", dr["unitprice_dec"].ToString());
                    dwRep.SetItemString(row, "des", dr["des_vchr"].ToString());
                    dwRep.SetItemString(row, "amount", clsPublic.ConvertObjToDecimal(dr["amount_dec"]).ToString("0.00"));
                    dwRep.SetItemString(row, "totalmoney", clsPublic.ConvertObjToDecimal(dr["totalmoney"]).ToString("0.00"));
                    if (ItemCodeType == 0)
                    {
                        dwRep.SetItemString(row, "itemcode", dr["itemopcode_chr"].ToString());
                    }
                    else
                    {
                        dwRep.SetItemString(row, "itemcode", dr["itemcode_vchr"].ToString());
                    }


                    clsBihEveryDayBill_VO objEveryDayBill;
                    if (hasTmp.ContainsKey(dr["registerid_chr"]))
                    {
                        objEveryDayBill = hasTmp[dr["registerid_chr"]] as clsBihEveryDayBill_VO;                       
                    }
                    else
                    {
                        l = this.objReport.m_lngRptEveryDayBill(dr["registerid_chr"].ToString(), BillDate, out objEveryDayBill);
                        hasTmp.Add(dr["registerid_chr"], objEveryDayBill);
                        decTotalDiffday = clsPublic.ConvertObjToDecimal(objEveryDayBill.m_decDayTotalDiffCost);
                        decTotalDiff = clsPublic.ConvertObjToDecimal(objEveryDayBill.m_decTotalDiffCost);
                        decTotalMny = clsPublic.ConvertObjToDecimal(dr["totalmoney"]);
                    }
                    //decTotalDiff += clsPublic.ConvertObjToDecimal(dr["totalmoney"]);
                    if (this.intDiffCostOn == 1)
                    {
                        dwRep.SetItemDecimal(row, "rlje", clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"].ToString()));
                        // decTotalDiff += Math.Abs(clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"].ToString()));

                        dwRep.SetItemDecimal(row, "sfje", clsPublic.ConvertObjToDecimal(dr["totalmoney"]) - Math.Abs(clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"].ToString())));
                        //dwRep.SetItemString(row, "alltotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.AllTotal) - Math.Abs(objEveryDayBill.m_decTotalDiffCost)).ToString("0.00"));
                        //dwRep.SetItemString(row, "alltotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.AllTotal) - Math.Abs(decTotalDiff)).ToString("0.00"));
                        dwRep.SetItemString(row, "alltotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.AllTotal) - Math.Abs(decTotalDiff)).ToString("0.00"));
                        //dwRep.SetItemString(row, "alldiffmny", objEveryDayBill.m_decDayTotalDiffCost.ToString());
                        dwRep.SetItemDecimal(row, "alldiffmny", decTotalDiff);
                        //dwRep.SetItemString(row, "currdaytotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.CurrDayTotal) - Math.Abs(objEveryDayBill.m_decDayTotalDiffCost)).ToString());
                        dwRep.SetItemString(row, "currdaytotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.CurrDayTotal) - Math.Abs(decTotalDiffday)).ToString());
                        //dwRep.SetItemString(row, "currdaytotal", (decTotalMny - Math.Abs(decTotalDiff)).ToString());
                    }
                    else
                    {
                        dwRep.SetItemString(row, "currdaytotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.CurrDayTotal) - Math.Abs(decTotalDiff)).ToString());
                        dwRep.SetItemString(row, "alltotal", (clsPublic.ConvertObjToDecimal(objEveryDayBill.AllTotal)).ToString("0.00"));
                    }

                    dwRep.SetItemString(row, "prepay", clsPublic.ConvertObjToDecimal(objEveryDayBill.PrePayMoney).ToString("0.00"));
                    dwRep.SetItemString(row, "cleartotal", clsPublic.ConvertObjToDecimal(objEveryDayBill.ClearTotal).ToString("0.00"));
                    dwRep.SetItemString(row, "arrearagetotal", clsPublic.ConvertObjToDecimal(objEveryDayBill.ArrearageTotal).ToString("0.00"));
                }
                //dwRep.Modify("t_totalMny.text = '" + decTotalMoney.ToString("0.00") + "'");
                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }
                dwRep.Sort();
                dwRep.CalculateGroups();
                dwRep.SetRedrawOn();
                dwRep.Refresh();
            }
        }

        #endregion

        #region 住院缴款(发票)分类报表
        /// <summary>
        /// 住院缴款(发票)分类报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RepType">0 缴款分类 1 发票分类</param>
        /// <param name="dwRep"></param>
        public void m_mthRptIncomeClass(string BeginDate, string EndDate, int RepType, DataWindowControl dwRep)
        {
            try
            {
                DataTable dtMain, dtDet;
                long l = this.objReport.m_lngRptIncomeClass(BeginDate, EndDate, RepType, 1, out dtMain, out dtDet);
                if (l > 0)
                {
                    dwRep.SetRedrawOff();
                    dwRep.Reset();
                    dwRep.Modify("t_date.text = '" + BeginDate + "～" + EndDate + "'");
                    dwRep.Modify("t_prntime.text = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    if (dtMain.Rows.Count == 0)
                    {
                        dwRep.InsertRow(0);
                        dwRep.SetRedrawOn();
                        dwRep.Refresh();
                        return;
                    }

                    #region 算比例
                    string ChargeNo = "";
                    string PayType = "";
                    decimal TotalSum = 0;
                    decimal PaySum = 0;
                    Hashtable Has = new Hashtable();

                    for (int i = 0; i < dtMain.Rows.Count; i++)
                    {
                        ChargeNo = dtMain.Rows[i]["chargeno"].ToString();
                        TotalSum = clsPublic.ConvertObjToDecimal(dtMain.Rows[i]["totalsum"]);
                        PayType = dtMain.Rows[i]["paytype"].ToString();
                        PaySum = clsPublic.ConvertObjToDecimal(dtMain.Rows[i]["paysum"]);

                        clsBihPaymentScale2_VO PaymentScale2_VO = new clsBihPaymentScale2_VO();
                        PaymentScale2_VO.PayTypeID = PayType;
                        PaymentScale2_VO.PaySum = PaySum;

                        if (Has.ContainsKey(ChargeNo))
                        {
                            ((clsBihPaymentScale1_VO)Has[ChargeNo]).PayTypeArr.Add(PaymentScale2_VO);
                        }
                        else
                        {
                            clsBihPaymentScale1_VO PaymentScale1_VO = new clsBihPaymentScale1_VO();

                            PaymentScale1_VO.ChargeNo = ChargeNo;
                            PaymentScale1_VO.TotalMny = TotalSum;
                            PaymentScale1_VO.PayTypeArr.Add(PaymentScale2_VO);

                            Has.Add(ChargeNo, PaymentScale1_VO);
                        }
                    }
                    #endregion

                    #region 生成数据

                    Hashtable hasPay = new Hashtable();

                    ArrayList PayArr = new ArrayList();
                    PayArr.AddRange(Has.Values);

                    for (int i = 0; i < PayArr.Count; i++)
                    {
                        clsBihPaymentScale1_VO PaymentScale1_VO = PayArr[i] as clsBihPaymentScale1_VO;
                        ChargeNo = PaymentScale1_VO.ChargeNo;
                        DataRow[] objdr = dtDet.Select("chargeno = '" + ChargeNo + "'");

                        ArrayList al = new ArrayList();
                        al = PaymentScale1_VO.PayTypeArr;
                        for (int j = 0; j < al.Count; j++)
                        {
                            decimal tmpsum = 0;
                            clsBihPaymentScale2_VO PaymentScale2_VO = al[j] as clsBihPaymentScale2_VO;

                            for (int k = 0; k < objdr.Length; k++)
                            {
                                string typename = objdr[k]["typename"].ToString();
                                decimal catsum = clsPublic.ConvertObjToDecimal(objdr[k]["catsum"]);
                                int Sort = int.Parse(clsPublic.ConvertObjToDecimal(objdr[k]["sortcode"]).ToString());

                                decimal d = 0;

                                if (k == (objdr.Length - 1))
                                {
                                    d = PaymentScale2_VO.PaySum - tmpsum;
                                }
                                else
                                {
                                    d = clsPublic.Round(PaymentScale2_VO.PaySum * (catsum / PaymentScale1_VO.TotalMny), 2);
                                    tmpsum += d;
                                }

                                clsBihPaymentScale2_VO objTmp = new clsBihPaymentScale2_VO();
                                objTmp.PayTypeID = PaymentScale2_VO.PayTypeID;
                                objTmp.PaySum = d;

                                if (hasPay.ContainsKey(typename))
                                {
                                    clsBihPaymentScale_VO PaymentScale_VO = hasPay[typename] as clsBihPaymentScale_VO;
                                    if (j == 0)
                                    {
                                        PaymentScale_VO.TotalMny += catsum;
                                    }

                                    bool status = false;
                                    int count = PaymentScale_VO.PayTypeArr.Count;
                                    for (int i1 = 0; i1 < count; i1++)
                                    {
                                        if (((clsBihPaymentScale2_VO)PaymentScale_VO.PayTypeArr[i1]).PayTypeID == objTmp.PayTypeID)
                                        {
                                            ((clsBihPaymentScale2_VO)PaymentScale_VO.PayTypeArr[i1]).PaySum += objTmp.PaySum;
                                            status = true;
                                            break;
                                        }
                                    }

                                    if (!status)
                                    {
                                        PaymentScale_VO.PayTypeArr.Add(objTmp);
                                    }

                                    hasPay[typename] = PaymentScale_VO;
                                }
                                else
                                {
                                    ArrayList arTmp = new ArrayList();
                                    arTmp.Add(objTmp);

                                    clsBihPaymentScale_VO PaymentScale_VO = new clsBihPaymentScale_VO();
                                    PaymentScale_VO.CatName = typename;
                                    PaymentScale_VO.TotalMny = catsum;
                                    PaymentScale_VO.PayTypeArr = arTmp;
                                    PaymentScale_VO.SortCode = Sort;

                                    hasPay.Add(typename, PaymentScale_VO);
                                }
                            }
                        }
                    }
                    #endregion

                    #region 绘制报表

                    ArrayList arPay = new ArrayList();
                    arPay.AddRange(hasPay.Values);
                    arPay.Sort(0, arPay.Count, null);

                    for (int i = 0; i < arPay.Count; i++)
                    {
                        clsBihPaymentScale_VO objPay = arPay[i] as clsBihPaymentScale_VO;

                        int row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "catname", objPay.CatName);
                        dwRep.SetItemDecimal(row, "total", objPay.TotalMny);

                        ArrayList ar = objPay.PayTypeArr;
                        for (int j = 0; j < ar.Count; j++)
                        {
                            clsBihPaymentScale2_VO PaymentScale2_VO = ar[j] as clsBihPaymentScale2_VO;

                            if (PaymentScale2_VO.PayTypeID == "#0")
                            {
                                dwRep.SetItemDecimal(row, "col0", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "#1")
                            {
                                dwRep.SetItemDecimal(row, "col1", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "#2")
                            {
                                dwRep.SetItemDecimal(row, "col2", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "#3")
                            {
                                dwRep.SetItemDecimal(row, "col3", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "#4")
                            {
                                dwRep.SetItemDecimal(row, "col4", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "&2")
                            {
                                dwRep.SetItemDecimal(row, "col5", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "&1")
                            {
                                dwRep.SetItemDecimal(row, "col6", PaymentScale2_VO.PaySum);
                            }
                            else if (PaymentScale2_VO.PayTypeID == "&3")
                            {
                                dwRep.SetItemDecimal(row, "col7", PaymentScale2_VO.PaySum);
                            }
                            else
                            {
                                dwRep.SetItemDecimal(row, "col8", PaymentScale2_VO.PaySum);
                            }
                        }
                    }

                    dwRep.SetRedrawOn();
                    dwRep.Refresh();

                    #endregion
                }

                clsPublic.CloseAvi();
            }
            catch (Exception ex)
            {
                dwRep.SetRedrawOn();
                dwRep.Refresh();
                clsPublic.CloseAvi();
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 收款员缴款报表
        /// <summary>
        /// 收款员缴款报表
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="EmpName"></param>
        /// <param name="IsRec"></param>
        /// <param name="RecTime"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptReckoningEmp(string EmpID, string EmpName, bool IsRec, string RecTime, DataWindowControl dwRep)
        {
            DataTable dtCharge;
            DataTable dtInvoice;
            DataTable dtPayment;
            DataTable dtPrepayChargeNo;
            string RemarkInfo = "";

            try
            {
                long l = this.objReport.m_lngRptReckoningEmp(EmpID, IsRec, RecTime, out dtCharge, out dtInvoice, out dtPayment, out dtPrepayChargeNo, out RemarkInfo);
                if (l > 0)
                {
                    dwRep.SetRedrawOff();
                    dwRep.Reset();
                    dwRep.InsertRow(0);

                    #region 票数、费用
                    DataView dv = new DataView(dtCharge);

                    //实收日期
                    if (IsRec)
                    {
                        dwRep.Modify("t_ssrq.text = '" + RecTime.Substring(0, 10) + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_ssrq.text = ''");
                    }

                    //发票时间
                    dv.Sort = "invotime asc";
                    if (dv.Count > 0)
                    {
                        dwRep.Modify("t_fpsj.text = '" + dv[0]["invotime"].ToString().Trim() + "～" + dv[dv.Count - 1]["invotime"].ToString().Trim() + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fpsj.text = ''");
                    }

                    int kps = 0;
                    int tps = 0;
                    decimal kpje = 0;
                    decimal tpje = 0;
                    decimal hjje = 0;
                    decimal rlje = 0;

                    foreach (DataRowView drv in dv)
                    {
                        if (drv["type_int"].ToString() == "1")
                        {
                            kps++;
                            kpje += clsPublic.ConvertObjToDecimal(drv["totalsum_mny"]);
                        }
                        else if (drv["type_int"].ToString() == "2")
                        {
                            tps++;
                            tpje += clsPublic.ConvertObjToDecimal(drv["totalsum_mny"]);
                        }
                        //自付金额
                        hjje += clsPublic.ConvertObjToDecimal(drv["totalsum_mny"]);

                        rlje += Math.Abs(clsPublic.ConvertObjToDecimal(drv["totaldiffcostmoney_dec"]));
                    }

                    //开票数、开票金额
                    if (kps > 0)
                    {
                        dwRep.Modify("t_kps.text = '" + kps.ToString() + "张'");
                        dwRep.Modify("t_kphj.text = '￥" + kpje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_kps.text = ''");
                        dwRep.Modify("t_kphj.text = ''");
                    }

                    //退票数、退票金额
                    if (tps > 0)
                    {
                        dwRep.Modify("t_tps.text = '" + tps.ToString() + "张'");
                        dwRep.Modify("t_tphj.text = '￥" + tpje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_tps.text = ''");
                        dwRep.Modify("t_tphj.text = ''");
                    }

                    //有效票数
                    if (kps - tps > 0)
                    {
                        dwRep.Modify("t_yxps.text = '" + Convert.ToString(kps - tps) + "张'");
                    }
                    else
                    {
                        dwRep.Modify("t_yxps.text = ''");
                    }

                    //合计金额                    
                    if (hjje != 0)
                    {
                        dwRep.Modify("t_hjje_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(hjje)) + "'");
                        dwRep.Modify("t_hjje_x.text = '￥" + hjje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_hjje_d.text = ''");
                        dwRep.Modify("t_hjje_x.text = ''");
                    }
                    //让利金额                    
                    if (rlje != 0)
                    {
                        dwRep.Modify("t_yprl_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(rlje)) + "'");
                        dwRep.Modify("t_yprl_x.text = '￥" + rlje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_yprl_d.text = ''");
                        dwRep.Modify("t_yprl_x.text = ''");
                    }

                    decimal yjktotal = 0;
                    decimal yjk = 0;
                    decimal xj = 0;
                    decimal zp = 0;
                    decimal yhk = 0;
                    decimal qt = 0;
                    decimal yb = 0;
                    decimal gf = 0;
                    decimal tk = 0;
                    decimal qt2 = 0;

                    for (int i = 0; i < dtPayment.Rows.Count; i++)
                    {
                        if (dtPayment.Rows[i]["paytype"].ToString() == "999")
                        {
                            yjktotal += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#0")
                        {
                            yjk += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#1")
                        {
                            xj += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#2")
                        {
                            zp += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#3")
                        {
                            yhk += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#4")
                        {
                            qt += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "&2")
                        {
                            yb += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "&1")
                        {
                            gf += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "&3")
                        {
                            tk += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else
                        {
                            qt2 += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                    }

                    //冲预付款
                    if (yjktotal != 0)
                    {
                        dwRep.Modify("t_cyfk_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(yjktotal)) + "'");
                        dwRep.Modify("t_cyfk_x.text = '￥" + yjktotal.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_cyfk_d.text = ''");
                        dwRep.Modify("t_cyfk_x.text = ''");
                    }

                    //应交合计
                    /*这时现金 = 实收现金 - 退预交款*/
                    xj = xj - (yjktotal - yjk);

                    decimal total = xj + zp + yhk + qt + yb + gf + tk + qt2;

                    if (total != 0)
                    {
                        dwRep.Modify("t_yjhj_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(total)) + "'");
                        dwRep.Modify("t_yjhj_x.text = '￥" + total.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_yjhj_d.text = ''");
                        dwRep.Modify("t_yjhj_x.text = ''");
                    }

                    //现金                                        
                    if (xj != 0)
                    {
                        dwRep.Modify("t_xj.text = '￥" + xj.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_xj.text = ''");
                    }

                    //支票                                        
                    if (zp != 0)
                    {
                        dwRep.Modify("t_zp.text = '￥" + zp.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_zp.text = ''");
                    }

                    //银行卡                                        
                    if (yhk != 0)
                    {
                        dwRep.Modify("t_yhk.text = '￥" + yhk.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_yhk.text = ''");
                    }

                    //(自付)其他                                        
                    if (qt != 0)
                    {
                        dwRep.Modify("t_qt.text = '￥" + qt.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_qt.text = ''");
                    }

                    //医保
                    if (yb != 0)
                    {
                        dwRep.Modify("t_yb.text = '￥" + yb.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_yb.text = ''");
                    }

                    //公费
                    if (gf != 0)
                    {
                        dwRep.Modify("t_gf.text = '￥" + gf.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_gf.text = ''");
                    }

                    //特困
                    if (tk != 0)
                    {
                        dwRep.Modify("t_tk.text = '￥" + tk.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_tk.text = ''");
                    }

                    //(记帐)其他
                    if (qt2 != 0)
                    {
                        dwRep.Modify("t_qt2.text = '￥" + qt2.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_qt2.text = ''");
                    }
                    #endregion

                    #region 票号
                    DataView dvInvoNo = new DataView(dtInvoice);
                    dvInvoNo.Sort = "invono asc";

                    //开票单号
                    dvInvoNo.RowFilter = "empid = '" + EmpID + "' and flag = 1";
                    string kpdh = this.m_strGetPrnInvoNo(dvInvoNo);
                    if (kpdh != "")
                    {
                        dwRep.Modify("t_kpdh.text = '" + kpdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_kpdh.text = ''");
                    }

                    //退票单号
                    dvInvoNo.RowFilter = "empid = '" + EmpID + "' and flag = 2";
                    string tpdh = this.m_strGetPrnInvoNo(dvInvoNo);
                    if (tpdh != "")
                    {
                        dwRep.Modify("t_tpdh.text = '" + tpdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_tpdh.text = ''");
                    }

                    //重打单号
                    dvInvoNo.RowFilter = "empid = '" + EmpID + "' and flag = 999";
                    string cddh = this.m_strGetPrnInvoNo(dvInvoNo);
                    if (cddh != "")
                    {
                        dwRep.Modify("t_cddh.text = '" + cddh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_cddh.text = ''");
                    }

                    //备注
                    string remarkinfo_p = "";
                    clsPublic.m_mthConvertNewLineStrLbl(RemarkInfo, 50, ref remarkinfo_p);
                    dwRep.Modify("t_bz.text = '" + remarkinfo_p + "'");

                    //交款人
                    dwRep.Modify("t_jkr.text = '" + EmpName + "'");

                    #endregion

                    dwRep.SetItemSqlString(1, "col1", EmpID);
                    dwRep.SetItemSqlString(1, "col2", RecTime);
                    dwRep.SetItemSqlString(1, "col3", RemarkInfo);

                    dwRep.SetRedrawOn();
                    dwRep.Refresh();
                }
            }
            catch (Exception ex)
            {
                dwRep.SetRedrawOn();
                dwRep.Refresh();
                clsPublic.CloseAvi();
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #region 获取打印发票号
        /// <summary>
        /// 获取打印发票号
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public string m_strGetPrnInvoNo(DataView dv)
        {
            string PrnInvoNo = "";

            if (dv.Count == 0)
            {
                return "";
            }

            Hashtable hasInvoNo = new Hashtable();
            foreach (DataRowView drv in dv)
            {
                string invono = drv["invono"].ToString().Trim();
                if (!hasInvoNo.ContainsKey(invono))
                {
                    clsBihReckoningInvoNo_VO InvoNo_VO = new clsBihReckoningInvoNo_VO();
                    InvoNo_VO.Flag = drv["flag"].ToString();
                    InvoNo_VO.InvoNo = invono;
                    hasInvoNo.Add(invono, InvoNo_VO);
                }
            }

            ArrayList InvoNoPrn = new ArrayList();
            ArrayList InvoNoArr = new ArrayList();
            InvoNoArr.AddRange(hasInvoNo.Values);
            InvoNoArr.Sort(null);

            if (InvoNoArr.Count == 1)
            {
                clsBihReckoningInvoNo_VO InvoNo_VO = InvoNoArr[0] as clsBihReckoningInvoNo_VO;
                InvoNoPrn.Add(InvoNo_VO.InvoNo);
            }
            else
            {
                int jsq = 0;
                clsBihReckoningInvoNo_VO InvoNo_VO = InvoNoArr[0] as clsBihReckoningInvoNo_VO;
                string invono = InvoNo_VO.InvoNo;
                for (int i = 1; i < InvoNoArr.Count; i++)
                {
                    clsBihReckoningInvoNo_VO InvoNo_VO1 = InvoNoArr[i - 1] as clsBihReckoningInvoNo_VO;
                    clsBihReckoningInvoNo_VO InvoNo_VO2 = InvoNoArr[i] as clsBihReckoningInvoNo_VO;

                    if (i == (InvoNoArr.Count - 1))
                    {
                        //发票号默认前2位为字母
                        if ((int.Parse(InvoNo_VO1.InvoNo.Substring(2)) + 1) == int.Parse(InvoNo_VO2.InvoNo.Substring(2)))
                        {
                            if (jsq > 0)
                            {
                                InvoNoPrn.Add(invono + "-" + InvoNo_VO2.InvoNo);
                            }
                            else
                            {
                                InvoNoPrn.Add(InvoNo_VO1.InvoNo + "-" + InvoNo_VO2.InvoNo);
                            }
                        }
                        else
                        {
                            if (jsq > 0)
                            {
                                InvoNoPrn.Add(invono + "-" + InvoNo_VO1.InvoNo);
                            }
                            else
                            {
                                InvoNoPrn.Add(invono);
                            }
                            InvoNoPrn.Add(InvoNo_VO2.InvoNo);
                        }
                    }
                    else
                    {
                        //发票号默认前2位为字母
                        if ((int.Parse(InvoNo_VO1.InvoNo.Substring(2)) + 1) == int.Parse(InvoNo_VO2.InvoNo.Substring(2)))
                        {
                            jsq++;
                            continue;
                        }
                        else
                        {
                            if (jsq > 0)
                            {
                                InvoNoPrn.Add(invono + "-" + InvoNo_VO1.InvoNo);
                            }
                            else
                            {
                                InvoNoPrn.Add(InvoNo_VO1.InvoNo);
                            }

                            jsq = 0;
                            invono = InvoNo_VO2.InvoNo;
                        }
                    }
                }
            }

            string no = "";
            for (int i = 0; i < InvoNoPrn.Count; i++)
            {
                no += InvoNoPrn[i] + "、";
            }
            if (no != "")
            {
                no = no.Substring(0, no.Length - 1);
            }

            clsPublic.m_mthConvertNewLineStrLbl(no, 66, ref PrnInvoNo);

            return PrnInvoNo;
        }
        #endregion

        #region 获取打印按金号
        /// <summary>
        /// 获取打印按金号
        /// </summary>
        /// <param name="objArr"></param>
        /// <returns></returns>
        public string m_strGetPrnPreNo(ArrayList objArr)
        {
            string PrnPreNo = "";

            if (objArr == null || objArr.Count == 0)
            {
                return "";
            }

            ArrayList PreNoPrn = new ArrayList();
            ArrayList PreNoArr = new ArrayList();

            for (int i = 0; i < objArr.Count; i++)
            {
                clsBihReckoningPreNo_VO o = new clsBihReckoningPreNo_VO();
                o.PreNo = objArr[i].ToString();
                PreNoArr.Add(o);
            }
            PreNoArr.Sort(null);

            if (PreNoArr.Count == 1)
            {
                clsBihReckoningPreNo_VO PreNo_VO = PreNoArr[0] as clsBihReckoningPreNo_VO;
                PreNoPrn.Add(PreNo_VO.PreNo);
            }
            else
            {
                int jsq = 0;
                clsBihReckoningPreNo_VO PreNo_VO = PreNoArr[0] as clsBihReckoningPreNo_VO;
                string preno = PreNo_VO.PreNo;
                for (int i = 1; i < PreNoArr.Count; i++)
                {
                    clsBihReckoningPreNo_VO PreNo_VO1 = PreNoArr[i - 1] as clsBihReckoningPreNo_VO;
                    clsBihReckoningPreNo_VO PreNo_VO2 = PreNoArr[i] as clsBihReckoningPreNo_VO;

                    if (i == (PreNoArr.Count - 1))
                    {
                        //按金全数字
                        if ((int.Parse(PreNo_VO1.PreNo) + 1) == int.Parse(PreNo_VO2.PreNo))
                        {
                            if (jsq > 0)
                            {
                                PreNoPrn.Add(preno + "-" + PreNo_VO2.PreNo);
                            }
                            else
                            {
                                PreNoPrn.Add(PreNo_VO1.PreNo + "-" + PreNo_VO2.PreNo);
                            }
                        }
                        else
                        {
                            if (jsq > 0)
                            {
                                PreNoPrn.Add(preno + "-" + PreNo_VO1.PreNo);
                            }
                            else
                            {
                                PreNoPrn.Add(preno);
                            }
                            PreNoPrn.Add(PreNo_VO2.PreNo);
                        }
                    }
                    else
                    {
                        //按金全数字
                        if ((int.Parse(PreNo_VO1.PreNo) + 1) == int.Parse(PreNo_VO2.PreNo))
                        {
                            jsq++;
                            continue;
                        }
                        else
                        {
                            if (jsq > 0)
                            {
                                PreNoPrn.Add(preno + "-" + PreNo_VO1.PreNo);
                            }
                            else
                            {
                                PreNoPrn.Add(PreNo_VO1.PreNo);
                            }

                            jsq = 0;
                            preno = PreNo_VO2.PreNo;
                        }
                    }
                }
            }

            string no = "";
            for (int i = 0; i < PreNoPrn.Count; i++)
            {
                no += PreNoPrn[i] + "、";
            }
            if (no != "")
            {
                no = no.Substring(0, no.Length - 1);
            }

            clsPublic.m_mthConvertNewLineStrLbl(no, 72, ref PrnPreNo);

            return PrnPreNo;
        }
        #endregion
        #endregion

        #region 收费处缴款报表
        /// <summary>
        /// 收费处缴款报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptReckoningDept(string BeginDate, string EndDate, DataWindowControl dwRep)
        {
            DataTable dtCharge;
            DataTable dtPayment;
            DataTable dtRemarkInfo;
            DataTable dtDiffmny;
            DataTable dtChargeno;
            try
            {
                long l = this.objReport.m_lngRptReckoningDept(BeginDate, EndDate, out dtCharge, out dtPayment, out dtRemarkInfo, out dtChargeno);
                if (l > 0)
                {
                    dwRep.SetRedrawOff();
                    dwRep.Reset();

                    //初始化                    
                    dwRep.Modify("t_sum_kps.text = ''");
                    dwRep.Modify("t_sum_kphj.text = ''");
                    dwRep.Modify("t_sum_tps.text = ''");
                    dwRep.Modify("t_sum_tphj.text = ''");
                    dwRep.Modify("t_sum_yxps.text = ''");
                    dwRep.Modify("t_sum_sjhs.text = ''");
                    dwRep.Modify("t_sum_cyfk.text = ''");
                    dwRep.Modify("t_sum_yjhj.text = ''");
                    dwRep.Modify("t_sum_xj.text = ''");
                    dwRep.Modify("t_sum_zp.text = ''");
                    dwRep.Modify("t_sum_yhk.text = ''");
                    dwRep.Modify("t_sum_qt.text = ''");
                    dwRep.Modify("t_sum_yb.text = ''");
                    dwRep.Modify("t_sum_gf.text = ''");
                    dwRep.Modify("t_sum_tk.text = ''");
                    dwRep.Modify("t_sum_qt2.text = ''");
                    dwRep.Modify("t_sum_yprl.text = ''");

                    //结帐日期
                    dwRep.Modify("t_jzrq.text = '" + BeginDate + "～" + EndDate + "'");

                    if (dtCharge.Rows.Count > 0)
                    {
                        string EmpID = "";
                        Hashtable hasEmp = new Hashtable();

                        for (int i = 0; i < dtCharge.Rows.Count; i++)
                        {
                            EmpID = dtCharge.Rows[i]["empid"].ToString().Trim();

                            if (!hasEmp.ContainsKey(EmpID))
                            {
                                hasEmp.Add(EmpID, null);
                            }
                        }

                        int sum_kps = 0;
                        int sum_tps = 0;
                        decimal sum_kpje = 0;
                        decimal sum_tpje = 0;
                        decimal sum_yjktotal = 0;
                        decimal sum_xj = 0;
                        decimal sum_zp = 0;
                        decimal sum_yhk = 0;
                        decimal sum_qt = 0;
                        decimal sum_yb = 0;
                        decimal sum_gf = 0;
                        decimal sum_tk = 0;
                        decimal sum_qt2 = 0;
                        decimal sum_ajhj = 0;
                        decimal sum_rlje = 0;
                        ArrayList EmpArr = new ArrayList();
                        EmpArr.AddRange(hasEmp.Keys);

                        for (int i = 0; i < EmpArr.Count; i++)
                        {
                            EmpID = EmpArr[i].ToString();

                            int row = dwRep.InsertRow(0);

                            DataView dvCharge = new DataView(dtCharge);
                            dvCharge.RowFilter = "empid = '" + EmpID + "'";

                            DataView dvPayment = new DataView(dtPayment);
                            dvPayment.RowFilter = "empid = '" + EmpID + "'";

                            DataView dvRemark = new DataView(dtRemarkInfo);
                            dvRemark.RowFilter = "empid = '" + EmpID + "'";

                            string EmpName = dvCharge[0]["empname"].ToString().Trim();
                            dwRep.SetItemString(row, "xm", EmpName);

                            int kps = 0;
                            int tps = 0;
                            decimal kpje = 0;
                            decimal tpje = 0;
                            decimal rlje = 0;
                            foreach (DataRowView drv in dvCharge)
                            {
                                if (drv["type_int"].ToString() == "1")
                                {
                                    kps = int.Parse(drv["invonums"].ToString());
                                    kpje = clsPublic.ConvertObjToDecimal(drv["totalsum"]);
                                    sum_kps += kps;
                                    sum_kpje += kpje;

                                    dwRep.SetItemString(row, "kps", kps.ToString() + "张");
                                    dwRep.SetItemString(row, "kphj", "￥" + kpje.ToString("###,##0.00"));
                                }
                                else if (drv["type_int"].ToString() == "2")
                                {
                                    tps = int.Parse(drv["invonums"].ToString());
                                    tpje = clsPublic.ConvertObjToDecimal(drv["totalsum"]);
                                    sum_tps += tps;
                                    sum_tpje += tpje;

                                    dwRep.SetItemString(row, "tps", tps.ToString() + "张");
                                    dwRep.SetItemString(row, "tphj", "￥" + tpje.ToString("###,##0.00"));
                                }
                            }


                            DataView dvChargeno = new DataView(dtChargeno);
                            foreach (DataRowView dr in dvChargeno)
                            {

                                string m_strChargeno = dr["chargeno_chr"].ToString();
                                long lng = this.objReport.m_lngRptTotaldiffcostmoney(m_strChargeno, EmpID, out dtDiffmny);
                                if (lng > 0)
                                {
                                    if (dtDiffmny.Rows.Count > 0)
                                    {
                                        DataView dvDiffmny = new DataView(dtDiffmny);
                                        rlje += Math.Abs(Convert.ToDecimal(dtDiffmny.Rows[0][0].ToString()));
                                    }
                                }
                            }
                            sum_rlje += rlje;
                            dwRep.SetItemString(row, "yxps", Convert.ToString(kps - tps) + "张");
                            dwRep.SetItemString(row, "sjhs", "￥" + Convert.ToDecimal(kpje + tpje).ToString("###,##0.00"));


                            decimal yjktotal = 0;
                            decimal yjk = 0;
                            decimal xj = 0;
                            decimal zp = 0;
                            decimal yhk = 0;
                            decimal qt = 0;
                            decimal yb = 0;
                            decimal gf = 0;
                            decimal tk = 0;
                            decimal qt2 = 0;
                            decimal ajhj = 0;
                            

                            foreach (DataRowView drv in dvPayment)
                            {
                                if (drv["paytype"].ToString() == "999")
                                {
                                    yjktotal = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_yjktotal += yjktotal;

                                    dwRep.SetItemString(row, "cyfk", "￥" + yjktotal.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "#0")
                                {
                                    yjk = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                }
                                else if (drv["paytype"].ToString() == "#1")
                                {
                                    xj = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                }
                                else if (drv["paytype"].ToString() == "#2")
                                {
                                    zp = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_zp += zp;

                                    dwRep.SetItemString(row, "zp", "￥" + zp.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "#3")
                                {
                                    yhk = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_yhk += yhk;

                                    dwRep.SetItemString(row, "yhk", "￥" + yhk.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "#4")
                                {
                                    qt = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_qt += qt;

                                    dwRep.SetItemString(row, "qt", "￥" + qt.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "&2")
                                {
                                    yb = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_yb += yb;

                                    dwRep.SetItemString(row, "yb", "￥" + yb.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "&1")
                                {
                                    gf = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_gf += gf;

                                    dwRep.SetItemString(row, "gf", "￥" + gf.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "&3")
                                {
                                    tk = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_tk += tk;

                                    dwRep.SetItemString(row, "tk", "￥" + tk.ToString("###,##0.00"));
                                }
                                else if (drv["paytype"].ToString() == "#999")
                                {
                                    ajhj = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_ajhj += ajhj;
                                    dwRep.SetItemString(row, "ajhj", "￥" + ajhj.ToString("###,##0.00"));
                                }
                                else
                                {
                                    qt2 = clsPublic.ConvertObjToDecimal(drv["paysum"]);
                                    sum_qt2 += qt2;

                                    dwRep.SetItemString(row, "qt2", "￥" + qt2.ToString("###,##0.00"));
                                }

                            }

                            dwRep.SetItemString(row, "yprl", "￥" + rlje.ToString("###,##0.00"));

                            xj = xj - (yjktotal - yjk);
                            sum_xj += xj;
                            dwRep.SetItemString(row, "xj", "￥" + xj.ToString("###,##0.00"));
                            dwRep.SetItemString(row, "yjhj", "￥" + Convert.ToDecimal(kpje + tpje + ajhj - yjktotal).ToString("###,##0.00"));

                            //dwRep.SetItemString(row, "yjhj", "￥" + Convert.ToDecimal(xj + zp + yhk + qt + yb + gf + tk + qt2).ToString("###,##0.00"));

                            string Remark = "";
                            string PrnRemark = "";
                            foreach (DataRowView drv in dvRemark)
                            {
                                Remark += drv["remark_vchr"].ToString().Trim();
                            }

                            clsPublic.m_mthConvertNewLineStrCol(Remark, 55, ref PrnRemark);
                            dwRep.SetItemString(row, "bz", PrnRemark);
                        }

                        dwRep.Modify("t_sum_kps.text = '" + sum_kps.ToString() + "张'");
                        dwRep.Modify("t_sum_kphj.text = '￥" + sum_kpje.ToString("###,##0.00") + "'");
                        if (sum_tps > 0)
                        {
                            dwRep.Modify("t_sum_tps.text = '" + sum_tps.ToString() + "张'");
                            dwRep.Modify("t_sum_tphj.text = '￥" + sum_tpje.ToString("###,##0.00") + "'");
                        }
                        dwRep.Modify("t_sum_yxps.text = '" + Convert.ToString(sum_kps - sum_tps) + "张'");
                        dwRep.Modify("t_sum_sjhs.text = '￥" + Convert.ToDecimal(sum_kpje + sum_tpje).ToString("###,##0.00") + "'");

                        if (sum_yjktotal != 0)
                        {
                            dwRep.Modify("t_sum_cyfk.text = '￥" + sum_yjktotal.ToString("###,##0.00") + "'");
                        }
                        dwRep.Modify("t_sum_yjhj.text = '￥" + Convert.ToDecimal(sum_xj + sum_zp + sum_yhk + sum_qt + sum_yb + sum_gf + sum_tk + sum_qt2).ToString("###,##0.00") + "'");
                        if (sum_xj != 0)
                        {
                            dwRep.Modify("t_sum_xj.text = '￥" + sum_xj.ToString("###,##0.00") + "'");
                        }
                        if (sum_zp != 0)
                        {
                            dwRep.Modify("t_sum_zp.text = '￥" + sum_zp.ToString("###,##0.00") + "'");
                        }
                        if (sum_yhk != 0)
                        {
                            dwRep.Modify("t_sum_yhk.text = '￥" + sum_yhk.ToString("###,##0.00") + "'");
                        }
                        if (sum_qt != 0)
                        {
                            dwRep.Modify("t_sum_qt.text = '￥" + sum_qt.ToString("###,##0.00") + "'");
                        }
                        if (sum_yb != 0)
                        {
                            dwRep.Modify("t_sum_yb.text = '￥" + sum_yb.ToString("###,##0.00") + "'");
                        }
                        if (sum_gf != 0)
                        {
                            dwRep.Modify("t_sum_gf.text = '￥" + sum_gf.ToString("###,##0.00") + "'");
                        }
                        if (sum_tk != 0)
                        {
                            dwRep.Modify("t_sum_tk.text = '￥" + sum_tk.ToString("###,##0.00") + "'");
                        }
                        if (sum_qt2 != 0)
                        {
                            dwRep.Modify("t_sum_qt2.text = '￥" + sum_qt2.ToString("###,##0.00") + "'");
                        }
                        if (sum_ajhj != 0)
                        {
                            dwRep.Modify("t_sum_ajhj.text='￥" + sum_ajhj.ToString("###,##0.00") + "'");
                        }
                        if (sum_rlje != 0)
                        {
                            dwRep.Modify("t_sum_yprl.text='￥" + sum_rlje.ToString("###,##0.00") + "'");
                        }
                    }
                    else
                    {
                        dwRep.InsertRow(0);
                    }

                    dwRep.SetRedrawOn();
                    dwRep.Refresh();
                }
            }
            catch (Exception ex)
            {
                dwRep.SetRedrawOn();
                dwRep.Refresh();
                clsPublic.CloseAvi();
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 期帐查询-费用明细清单
        /// <summary>
        /// 期帐查询-费用明细清单
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="DeptName"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="Type">1 打印 2 导出</param>
        /// <param name="DateScop">时间段</param>
        public void m_mthRptChargeDet(DataGridView DGV, string DeptName, string Zyh, string Name, int Type, string DateScop)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            dsRep.DataWindowObject = "d_bih_chargedet";


            dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
            dsRep.Modify("t_ksmc.text = '" + DeptName + "'");
            dsRep.Modify("t_zyh.text = '" + Zyh + "'");
            dsRep.Modify("t_xm.text = '" + Name + "'");
            dsRep.Modify("t_date.text='" + DateScop + "'");
            ArrayList RowArr = new ArrayList();

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (RowArr.IndexOf(i) >= 0)
                {
                    continue;
                }

                string areaname = DGV.Rows[i].Cells["colKdbq"].Value.ToString();
                string creatdate = DGV.Rows[i].Cells["colrq"].Value.ToString();
                string itemid = DGV.Rows[i].Cells["colxmdm"].Value.ToString().Trim();
                string price = DGV.Rows[i].Cells["coldj"].Value.ToString().Trim();
                string opername = DGV.Rows[i].Cells["collr"].Value.ToString().Trim();
                decimal amount = clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colsl"].Value);
                decimal totalmoney = clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colje"].Value);
                string spec = DGV.Rows[i].Cells["colgg"].Value.ToString().Trim();
                for (int j = i + 1; j < DGV.Rows.Count; j++)
                {
                    if (DGV.Rows[j].Cells["colKdbq"].Value.ToString().Trim() == areaname &&
                        DGV.Rows[j].Cells["colrq"].Value.ToString().Trim() == creatdate &&
                        DGV.Rows[j].Cells["colxmdm"].Value.ToString().Trim() == itemid &&
                        DGV.Rows[j].Cells["coldj"].Value.ToString().Trim() == price &&
                        DGV.Rows[j].Cells["collr"].Value.ToString().Trim() == opername)
                    {
                        amount += clsPublic.ConvertObjToDecimal(DGV.Rows[j].Cells["colsl"].Value);
                        totalmoney += clsPublic.ConvertObjToDecimal(DGV.Rows[j].Cells["colje"].Value);

                        RowArr.Add(j);
                    }
                }

                int row = dsRep.InsertRow(0);
                dsRep.SetItemString(row, "colxmdm", itemid);
                dsRep.SetItemString(row, "colkdbq", areaname);
                dsRep.SetItemString(row, "colrq", creatdate);
                dsRep.SetItemString(row, "colxmmc", DGV.Rows[i].Cells["colxmmc"].Value.ToString());
                dsRep.SetItemString(row, "colfpfl", DGV.Rows[i].Cells["colfpfl"].Value.ToString());
                dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(price));
                dsRep.SetItemDecimal(row, "colsl", amount);
                dsRep.SetItemString(row, "coldw", DGV.Rows[i].Cells["coldw"].Value.ToString());
                dsRep.SetItemDecimal(row, "colje", totalmoney);
                dsRep.SetItemString(row, "collr", opername);
                dsRep.SetItemString(row, "colgg", spec);

            }

            if (Type == 1)
            {
                clsPublic.PrintDialog(dsRep);
            }
            else if (Type == 2)
            {
                clsPublic.ExportDataStore(dsRep, null);
            }
        }
        #endregion


        #region 期帐查询-费用明细清单 CS-424 (ID:12567)
        /// <summary>
        /// 期帐查询-费用明细清单
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="DeptName"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="Type">1 打印 2 导出</param>
        /// <param name="strDate">时间:可能是时间段，也可能是天数，根据intIsNewOrder变化</strTimePeriod>
        /// <param name="strChargeType">病人身份</param>
        /// <param name="intIsNewOrder">是否用心的费用明细清单</param>
        public void m_mthRptChargeDet2(DataGridView DGV, string DeptName, string Zyh, string Name, int Type, string strDate, string strChargeType, int intIsNewOrder)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            if (intIsNewOrder == 1)
            {
                dsRep.DataWindowObject = "d_bih_chargedetnew";
            }
            else
            {
                dsRep.DataWindowObject = "d_bih_chargedet";
            }
            if (this.intDiffCostOn == 1)
                dsRep.DataWindowObject = "d_bih_chargedet_diff";

            DataTable dt = new DataTable();
            dt = dvtodt(DGV);

            DataView dvTemp = dt.DefaultView;
            dvTemp.Sort = "colfpfl asc";
            dt = dvTemp.ToTable();
            if (intIsNewOrder == 1)
            {
                #region  打印新费用明细清单  2013-10-18  yongdian.luo
                dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
                dsRep.Modify("t_ksmc.text = '" + DeptName + "'");
                dsRep.Modify("t_zyh.text = '" + Zyh + "'");
                dsRep.Modify("t_xm.text = '" + Name + "'");
                dsRep.Modify("t_jfzq.text = '" + strDate + " 天" + "'");
                dsRep.Modify("t_yblx.text = '" + strChargeType + "'");

                ArrayList arlTempArr = new ArrayList();                
                decimal dec_DiffPriceSum = 0; //总让利
                decimal dec_PayCount = 0;//总实收
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    if (arlTempArr.IndexOf(i1) > 0)
                    {
                        continue;
                    }

                    string strItemCode = dt.Rows[i1]["colxmdm"].ToString().Trim();
                    string strItemName = dt.Rows[i1]["colxmmc"].ToString().Trim();
                    string strSpaecs = dt.Rows[i1]["colgg"].ToString().Trim();
                    string strUnits = dt.Rows[i1]["coldw"].ToString().Trim();
                    decimal decPrice = clsPublic.ConvertObjToDecimal(dt.Rows[i1]["coldj"].ToString().Trim());
                    decimal decAmount = clsPublic.ConvertObjToDecimal(dt.Rows[i1]["colsl"].ToString().Trim());
                    decimal decScale = clsPublic.ConvertObjToDecimal(dt.Rows[i1]["scale"].ToString().Trim());
                    decimal decTotalmoney = clsPublic.ConvertObjToDecimal(dt.Rows[i1]["colje"].ToString().Trim());
                    decimal decTotalDiffmoney = clsPublic.ConvertObjToDecimal(dt.Rows[i1]["totaldiffcostmoney_dec"].ToString().Trim());//Added by: 吴汉明 2014-12-25总让利金额
                    decimal decFactPaymoney = clsPublic.ConvertObjToDecimal(dt.Rows[i1]["requiredpay"].ToString().Trim());//Added by: 吴汉明 2014-12-25 实付金额
                    string strSortkey = dt.Rows[i1]["colrq"].ToString();
                    dec_DiffPriceSum += clsPublic.ConvertObjToDecimal(dt.Rows[i1]["totaldiffcostmoney_dec"].ToString().Trim());
                    dec_PayCount += clsPublic.ConvertObjToDecimal(dt.Rows[i1]["requiredpay"].ToString().Trim());
                    for (int j2 = 0; j2 < dt.Rows.Count; j2++)
                    {
                        if (strItemCode == dt.Rows[j2]["colxmdm"].ToString().Trim() && decPrice == clsPublic.ConvertObjToDecimal(dt.Rows[j2]["coldj"].ToString().Trim()))
                        {
                            decAmount += clsPublic.ConvertObjToDecimal(dt.Rows[j2]["colsl"].ToString().Trim());
                            decTotalmoney += clsPublic.ConvertObjToDecimal(dt.Rows[j2]["colje"].ToString().Trim());
                            decTotalDiffmoney += clsPublic.ConvertObjToDecimal(dt.Rows[j2]["totaldiffcostmoney_dec"].ToString().Trim());
                            decFactPaymoney += clsPublic.ConvertObjToDecimal(dt.Rows[j2]["requiredpay"].ToString().Trim());
                            arlTempArr.Add(j2);
                        }
                    }

                    int row = dsRep.InsertRow(0);

                    dsRep.SetItemString(row, "colxmbm", strItemCode);
                    dsRep.SetItemString(row, "colxmmz", strItemName);
                    dsRep.SetItemString(row, "colgg", strSpaecs);
                    dsRep.SetItemString(row, "coljjdw", strUnits);
                    dsRep.SetItemDecimal(row, "coldj", decPrice);
                    dsRep.SetItemDecimal(row, "colsl", decAmount);
                    dsRep.SetItemDecimal(row, "colzf", decScale);
                    dsRep.SetItemString(row, "sortkey", strSortkey);
                    dsRep.SetItemDecimal(row, "colje", decTotalmoney);
                    if (intDiffCostOn == 1)
                    {
                        dsRep.SetItemDecimal(row, "colrlje", clsPublic.Round(decTotalDiffmoney, 2));
                        dsRep.SetItemDecimal(row, "colsfje", clsPublic.Round(decFactPaymoney, 2));
                    };
                }
                com.digitalwave.Utility.clsLogText jianjun = new com.digitalwave.Utility.clsLogText();
                jianjun.LogError("总让利:" + dec_DiffPriceSum.ToString());
                jianjun.LogError("总实收" + dec_PayCount.ToString());
                dsRep.Sort();
                #endregion
            }
            else
            {

                #region 以前的版本 2013-10-17
                dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
                dsRep.Modify("t_ksmc.text = '" + DeptName + "'");
                dsRep.Modify("t_zyh.text = '" + Zyh + "'");
                dsRep.Modify("t_xm.text = '" + Name + "'");
                dsRep.Modify("t_date.text='" + strDate + "'");



                ArrayList RowArr = new ArrayList();

                decimal dec_DiffPriceSum = 0; //总让利
                decimal dec_PayCount = 0;//总实收
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (RowArr.IndexOf(i) >= 0)
                    {
                        continue;
                    }

                    string areaname = dt.Rows[i]["colKdbq"].ToString();
                    string creatdate = dt.Rows[i]["colrq"].ToString();
                    string itemid = dt.Rows[i]["colxmdm"].ToString().Trim();
                    string price = dt.Rows[i]["coldj"].ToString().Trim();
                    string opername = dt.Rows[i]["collr"].ToString().Trim();
                    decimal amount = clsPublic.ConvertObjToDecimal(dt.Rows[i]["colsl"].ToString().Trim());
                    decimal totalmoney = clsPublic.ConvertObjToDecimal(dt.Rows[i]["colje"].ToString().Trim());
                    string spec = dt.Rows[i]["colgg"].ToString().Trim();
                    decimal decTotalDiffmoney = clsPublic.ConvertObjToDecimal(dt.Rows[i]["totaldiffcostmoney_dec"].ToString().Trim());//Added by: 吴汉明 2014-12-25总让利金额
                    decimal decFactPaymoney = clsPublic.ConvertObjToDecimal(dt.Rows[i]["requiredpay"].ToString().Trim());//Added by: 吴汉明 2014-12-25 实付金额
                    dec_DiffPriceSum += clsPublic.ConvertObjToDecimal(dt.Rows[i]["totaldiffcostmoney_dec"].ToString().Trim());
                    dec_PayCount += clsPublic.ConvertObjToDecimal(dt.Rows[i]["requiredpay"].ToString().Trim());
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        //if (dt.Rows[j]["colKdbq"].ToString().Trim() == areaname &&
                        //    dt.Rows[j]["colrq"].ToString().Trim() == creatdate &&
                        //    dt.Rows[j]["colxmdm"].ToString().Trim() == itemid &&
                        //    dt.Rows[j]["coldj"].ToString().Trim() == price &&
                        //    dt.Rows[j]["collr"].ToString().Trim() == opername)
                        // 修改条件  2013-10-18
                        if (dt.Rows[j]["colxmdm"].ToString().Trim() == itemid && dt.Rows[j]["coldj"].ToString().Trim() == price)
                        {
                            amount += clsPublic.ConvertObjToDecimal(dt.Rows[j]["colsl"].ToString().Trim());
                            totalmoney += clsPublic.ConvertObjToDecimal(dt.Rows[j]["colje"].ToString().Trim());
                            decTotalDiffmoney += clsPublic.ConvertObjToDecimal(dt.Rows[j]["totaldiffcostmoney_dec"].ToString().Trim());
                            decFactPaymoney += clsPublic.ConvertObjToDecimal(dt.Rows[j]["requiredpay"].ToString().Trim());
                            dec_DiffPriceSum += clsPublic.ConvertObjToDecimal(dt.Rows[j]["totaldiffcostmoney_dec"].ToString().Trim());
                            dec_PayCount += clsPublic.ConvertObjToDecimal(dt.Rows[j]["requiredpay"].ToString().Trim());
                            RowArr.Add(j);
                        }
                    }

                    int row = dsRep.InsertRow(0);
                    dsRep.SetItemString(row, "colxmdm", itemid);
                    dsRep.SetItemString(row, "colkdbq", areaname);
                    dsRep.SetItemString(row, "colrq", creatdate);
                    dsRep.SetItemString(row, "colxmmc", dt.Rows[i]["colxmmc"].ToString());
                    dsRep.SetItemString(row, "colfpfl", dt.Rows[i]["colfpfl"].ToString());
                    dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(price));
                    dsRep.SetItemDecimal(row, "colsl", amount);
                    dsRep.SetItemString(row, "coldw", dt.Rows[i]["coldw"].ToString());
                    dsRep.SetItemString(row, "collr", opername);
                    dsRep.SetItemString(row, "colgg", spec);
                    dsRep.SetItemDecimal(row, "colje", totalmoney);
                    if (intDiffCostOn == 1)
                    {
                        dsRep.SetItemDecimal(row, "colrlje", clsPublic.Round(decTotalDiffmoney, 2));
                        dsRep.SetItemDecimal(row, "colsfje", clsPublic.Round(decFactPaymoney, 2));
                    };

                }
                com.digitalwave.Utility.clsLogText jianjun = new com.digitalwave.Utility.clsLogText();
                jianjun.LogError("总让利:" + dec_DiffPriceSum.ToString());
                jianjun.LogError("总实收" + dec_PayCount.ToString());
                dsRep.CalculateGroups();
                #endregion
            }

            if (Type == 1)
            {
                clsPublic.PrintDialog(dsRep);
            }
            else if (Type == 2)
            {
                clsPublic.ExportDataStore(dsRep, null);
            }
        }



        /// <summary>
        /// DataGridView 转换成 DataTable
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public DataTable dvtodt(DataGridView dv)
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            for (int i = 0; i < dv.Columns.Count; i++)
            {
                dc = new DataColumn();
                dc.ColumnName = dv.Columns[i].DataPropertyName.ToString();
                dt.Columns.Add(dc);
            }
            for (int j = 0; j < dv.Rows.Count ; j++)
            {
                DataRow dr = dt.NewRow();
                for (int x = 0; x < dv.Columns.Count; x++)
                {
                    dr[x] = dv.Rows[j].Cells[x].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region 期帐查询-费用分类清单
        /// <summary>
        /// 期帐查询-费用分类清单
        /// </summary>
        /// <param name="CatArr"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="DeptName"></param>
        /// <param name="DateScope"></param>
        /// <param name="OperName"></param>
        public void m_mthRptChargeCat(ArrayList CatArr, string Zyh, string Name, string DeptName, string DateScope, string OperName)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            dsRep.DataWindowObject = "d_bih_chargecat";

            dsRep.Modify("t_zyh.text = '" + Zyh + "'");
            dsRep.Modify("t_xm.text = '" + Name + "'");
            dsRep.Modify("t_ks.text = '" + DeptName + "'");
            dsRep.Modify("t_fysj.text = '" + DateScope + "'");
            dsRep.Modify("t_dyr.text = '" + OperName + "'");
            dsRep.Modify("t_yymc.text = '" + this.hospname + "'");
            dsRep.Modify("t_dysj.text = '" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒") + "'");

            for (int i = 0; i < CatArr.Count; i++)
            {
                clsInvoiceCat_VO invocat_vo = CatArr[i] as clsInvoiceCat_VO;
                int row = dsRep.InsertRow(0);
                dsRep.SetItemString(row, "colfymc", invocat_vo.CatName);
                dsRep.SetItemDecimal(row, "colfyje", invocat_vo.CatSum);
            }

            clsPublic.PrintDialog(dsRep);
        }
        #endregion

        #region 期帐查询-费用明细汇总清单
        /// <summary>
        /// 期帐查询-费用明细汇总清单
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="DeptName"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="DateScope"></param>
        /// <param name="PrintEmp"></param>
        /// <param name="Type">1 打印 2 导出</param>
        public void m_mthRptChargeSum(DataGridView DGV, string DeptName, string Zyh, string Name, string DateScope, string PrintEmp, int Type)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            if (this.intDiffCostOn == 1)
                dsRep.DataWindowObject = "d_bih_chargesum_diff";
            else
                dsRep.DataWindowObject = "d_bih_chargesum";

            dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
            dsRep.Modify("t_ksmc.text = '" + DeptName + "'");
            dsRep.Modify("t_zyh.text = '" + Zyh + "'");
            dsRep.Modify("t_xm.text = '" + Name + "'");
            dsRep.Modify("t_tjrq.text = '" + DateScope + "'");
            dsRep.Modify("t_dyr.text = '" + PrintEmp + "'");

            DGV.Sort(DGV.Columns["colfyfl"], System.ComponentModel.ListSortDirection.Ascending);
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                int row = dsRep.InsertRow(0);
                dsRep.SetItemString(row, "colfyfl", DGV.Rows[i].Cells["colfyfl"].Value.ToString());
                dsRep.SetItemString(row, "colxmdm", DGV.Rows[i].Cells["colxmdm"].Value.ToString());
                dsRep.SetItemString(row, "colxmmc", DGV.Rows[i].Cells["colxmmc"].Value.ToString());
                dsRep.SetItemString(row, "colgg", DGV.Rows[i].Cells["colgg"].Value.ToString());
                dsRep.SetItemString(row, "coldw", DGV.Rows[i].Cells["coldw"].Value.ToString());
                dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colprice"].Value));
                dsRep.SetItemDecimal(row, "colsl", clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colsl"].Value));
                dsRep.SetItemDecimal(row, "colje", clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colje"].Value));
                if (this.intDiffCostOn == 1)
                {
                    dsRep.SetItemDecimal(row, "rlje", clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colDiffCostMny"].Value));
                    dsRep.SetItemDecimal(row, "sfje", clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colRequiredPay"].Value));
                }
            }

            if (Type == 1)
            {
                clsPublic.PrintDialog(dsRep);
            }
            else if (Type == 2)
            {
                clsPublic.ExportDataStore(dsRep, null);
            }
        }
        #endregion

        #region (茶山)费用明细自费清单
        /// <summary>
        /// (茶山)费用明细自费清单
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="DateScope"></param>
        /// <param name="PrintEmp"></param>
        /// <param name="Type">0 全部 1 自费 2 记帐</param>
        public void m_mthRptSbBill_CS(DataGridView DGV, string Zyh, string Name, string DateScope, string PrintEmp, int Type)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            dsRep.DataWindowObject = "d_bih_chargesum_cs";

            ArrayList DeptArr = new ArrayList();
            ArrayList RowArr = new ArrayList();

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (RowArr.IndexOf(i) >= 0)
                {
                    continue;
                }

                string itemid = DGV.Rows[i].Cells["colxmdm"].Value.ToString().Trim();
                string price = DGV.Rows[i].Cells["coldj"].Value.ToString().Trim();
                string scale = DGV.Rows[i].Cells["scale"].Value.ToString().Trim();
                decimal amount = clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colsl"].Value);
                decimal totalmoney = clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colje"].Value);

                if (Type == 1)
                {
                    if (scale != "100")
                    {
                        continue;
                    }
                }
                else if (Type == 2)
                {
                    if (scale == "100")
                    {
                        continue;
                    }
                }

                for (int j = i + 1; j < DGV.Rows.Count; j++)
                {
                    if (DGV.Rows[j].Cells["colxmdm"].Value.ToString().Trim() == itemid &&
                        DGV.Rows[j].Cells["coldj"].Value.ToString().Trim() == price &&
                        DGV.Rows[j].Cells["scale"].Value.ToString().Trim() == scale)
                    {
                        amount += clsPublic.ConvertObjToDecimal(DGV.Rows[j].Cells["colsl"].Value);
                        totalmoney += clsPublic.ConvertObjToDecimal(DGV.Rows[j].Cells["colje"].Value);

                        RowArr.Add(j);
                    }
                }

                if (amount == 0)
                {
                    continue;
                }

                string areaname = DGV.Rows[i].Cells["colszbq"].Value.ToString().Trim();
                if (DeptArr.IndexOf(areaname) == -1)
                {
                    DeptArr.Add(areaname);
                }

                int row = dsRep.InsertRow(0);
                dsRep.SetItemString(row, "colxmdm", DGV.Rows[i].Cells["colxmdm"].Value.ToString());
                dsRep.SetItemString(row, "colxmmc", DGV.Rows[i].Cells["colxmmc"].Value.ToString());
                dsRep.SetItemString(row, "colgg", DGV.Rows[i].Cells["colgg"].Value.ToString());
                dsRep.SetItemString(row, "coldw", DGV.Rows[i].Cells["coldw"].Value.ToString());
                dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(price));
                dsRep.SetItemDecimal(row, "colsl", amount);
                dsRep.SetItemDecimal(row, "colje", totalmoney);
                dsRep.SetItemString(row, "colzfbl", scale);
                if (scale == "100")
                {
                    dsRep.SetItemString(row, "colzfbz", "是");
                }
                else
                {
                    dsRep.SetItemString(row, "colzfbz", "否");
                }
            }

            string DeptName = "";
            for (int i = 0; i < DeptArr.Count; i++)
            {
                DeptName += DeptArr[i].ToString() + "、";
            }

            if (DeptName != "")
            {
                DeptName = DeptName.Substring(0, DeptName.Length - 1);
            }

            dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
            dsRep.Modify("t_ksmc.text = '" + DeptName + "'");
            dsRep.Modify("t_zyh.text = '" + Zyh + "'");
            dsRep.Modify("t_xm.text = '" + Name + "'");
            dsRep.Modify("t_tjrq.text = '" + DateScope + "'");
            dsRep.Modify("t_dyr.text = '" + PrintEmp + "'");

            clsPublic.PrintDialog(dsRep);
        }

        /// <summary>
        /// (茶山)费用明细自费清单
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="PrintEmp"></param>
        /// <param name="Type"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptSbBill_CS(string RegID, string PayTypeID, string Zyh, string Name, string PrintEmp, int Type, DataWindowControl dwRep)
        {
            DataTable dt;
            clsDcl_Charge objCharge = new clsDcl_Charge();
            long l = objCharge.m_lngGetPatientFeeDetByPayType(RegID, PayTypeID, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                ArrayList RowArr = new ArrayList();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (RowArr.IndexOf(i) >= 0)
                    {
                        continue;
                    }

                    string itemid = dr["itemcode_vchr"].ToString().Trim();
                    string price = dr["unitprice_dec"].ToString();
                    string scale = dr["precent_dec"].ToString();
                    decimal amount = clsPublic.ConvertObjToDecimal(dr["amount_dec"]);
                    decimal totalmoney = clsPublic.ConvertObjToDecimal(dr["totalmony"]);

                    if (Type == 1)
                    {
                        if (scale != "100")
                        {
                            continue;
                        }
                    }
                    else if (Type == 2)
                    {
                        if (scale == "100")
                        {
                            continue;
                        }
                    }

                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        DataRow dr2 = dt.Rows[j];

                        if (dr2["itemcode_vchr"].ToString().Trim() == itemid &&
                            dr2["unitprice_dec"].ToString() == price &&
                            dr2["precent_dec"].ToString() == scale)
                        {
                            amount += clsPublic.ConvertObjToDecimal(dr2["amount_dec"]);
                            totalmoney += clsPublic.ConvertObjToDecimal(dr2["totalmony"]);

                            RowArr.Add(j);
                        }
                    }

                    if (amount == 0)
                    {
                        continue;
                    }

                    int row = dwRep.InsertRow(0);
                    dwRep.SetItemString(row, "colxmdm", dr["itemcode_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "colxmmc", dr["chargeitemname_chr"].ToString().Trim());
                    dwRep.SetItemString(row, "colgg", dr["itemspec_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "coldw", dr["unit_vchr"].ToString().Trim());
                    dwRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]));
                    dwRep.SetItemDecimal(row, "colsl", amount);
                    dwRep.SetItemDecimal(row, "colje", totalmoney);
                    dwRep.SetItemString(row, "colzfbl", scale);
                    if (scale == "100")
                    {
                        dwRep.SetItemString(row, "colzfbz", "是");
                    }
                    else
                    {
                        dwRep.SetItemString(row, "colzfbz", "否");
                    }
                }

                string DeptName = "";
                string DateScope = "";
                if (dt.Rows.Count > 0)
                {
                    DeptName = dt.Rows[0]["curarea"].ToString().Trim();

                    DataView dv = new DataView(dt);
                    dv.Sort = "chargeactive_dat asc";
                    DateScope = Convert.ToDateTime(dv[0]["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd") + " ~ " + Convert.ToDateTime(dv[dv.Count - 1]["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd");
                }

                dwRep.Modify("t_ksmc.text = '" + DeptName + "'");
                dwRep.Modify("t_zyh.text = '" + Zyh + "'");
                dwRep.Modify("t_xm.text = '" + Name + "'");
                dwRep.Modify("t_tjrq.text = '" + DateScope + "'");
                dwRep.Modify("t_dyr.text = '" + PrintEmp + "'");

                dwRep.SetRedrawOn();
                dwRep.Refresh();
            }
            objCharge = null;
        }
        #endregion

        #region 期帐查询-打印病区欠费清单
        /// <summary>
        /// 期帐查询-打印病区欠费清单
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="DeptName"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="Type">1 退费单 2 普通单(清单列表)</param>
        public void m_mthRptAreaRefundmentBill(DataGridView DGV, string DeptName, string Zyh, string Name, int Type)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            dsRep.DataWindowObject = "d_bih_deptrefundmentbill";

            if (Type == 2)
            {
                dsRep.Modify("t_title.text = '费 用 明 细 清 单'");
                dsRep.Modify("t_3.visible = 0");
            }

            dsRep.Modify("t_bqmc.text = '" + DeptName + "'");
            dsRep.Modify("t_zyh.text = '" + Zyh + "'");
            dsRep.Modify("t_xm.text = '" + Name + "'");

            for (int i = 0; i < DGV.SelectedRows.Count; i++)
            {
                int row = dsRep.InsertRow(0);

                dsRep.SetItemString(row, "colrq", DGV.SelectedRows[i].Cells["colrq"].Value.ToString());
                dsRep.SetItemString(row, "colxmdm", DGV.SelectedRows[i].Cells["colxmdm"].Value.ToString());
                dsRep.SetItemString(row, "colxmmc", DGV.SelectedRows[i].Cells["colxmmc"].Value.ToString());
                dsRep.SetItemString(row, "colgg", DGV.SelectedRows[i].Cells["colgg"].Value.ToString());
                dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(DGV.SelectedRows[i].Cells["coldj"].Value));
                dsRep.SetItemDecimal(row, "colsl", clsPublic.ConvertObjToDecimal(DGV.SelectedRows[i].Cells["colsl"].Value));
                dsRep.SetItemString(row, "coldw", DGV.SelectedRows[i].Cells["coldw"].Value.ToString());
                dsRep.SetItemDecimal(row, "colje", clsPublic.ConvertObjToDecimal(DGV.SelectedRows[i].Cells["colje"].Value));
                dsRep.SetItemString(row, "colly", DGV.SelectedRows[i].Cells["colly"].Value.ToString());
            }

            clsPublic.PrintDialog(dsRep);
        }
        #endregion

        #region 发票明细
        /// <summary>
        /// 发票明细
        /// </summary>
        /// <param name="InvoiceNO">发票号</param>
        public void m_mthRptInvoiceEntry(string InvoiceNO)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            if (this.intDiffCostOn == 1)
                dsRep.DataWindowObject = "d_bih_invoice_entry_diff";
            else
                dsRep.DataWindowObject = "d_bih_invoice_entry";

            dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
            dsRep.Modify("txtinvono.text = '" + InvoiceNO + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptInvoiceEntry(InvoiceNO.ToUpper(), out dt);
            if (l > 0)
            {
                dsRep.Retrieve(dt);

                if (dsRep.RowCount == 0)
                {
                    dsRep.InsertRow(0);
                }
            }

            clsPublic.PrintDialog(dsRep);
        }

        /// <summary>
        /// 发票明细
        /// </summary>
        /// <param name="InvoiceNO">发票号</param>
        /// <param name="dwRep"></param>
        public void m_mthRptInvoiceEntry(string InvoiceNO, DataWindowControl dwRep)
        {
            dwRep.Modify("t_title.text = '" + this.HospitalName + dwRep.Describe("t_title.text") + "'");
            dwRep.Modify("txtinvono.text = '" + InvoiceNO + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptInvoiceEntry(InvoiceNO, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 住院收费员月发票报表

        #region 获取收费员
        /// <summary>
        /// 获取收费员
        /// </summary>
        /// <param name="p_dtbMan"></param>
        /// <returns></returns>
        public long m_lngGetRecEmp(out DataTable p_dtbRecEmp)
        {
            long lngRes = objReport.m_lngGetRecEmp(out p_dtbRecEmp);
            return lngRes;
        }

        #endregion //获取收费员


        #region 获取住院月发票统计数据

        /// <summary>
        /// 获取住院月发票统计数据
        /// </summary>
        /// <param name="p_opratorId"></param>
        /// <param name="p_beginDate"></param>
        /// <param name="p_endDate"></param>
        /// <param name="p_dtbStat"></param>
        /// <returns></returns>
        public long m_lngGetBIHInvoiceStatData(string p_opratorId, string p_beginDate, string p_endDate, out DataTable p_dtbStat)
        {
            long lngRes = objReport.m_lngGetBIHInvoiceStatData(p_opratorId, p_beginDate, p_endDate, out p_dtbStat);
            return lngRes;
        }

        #endregion //获取住院月发票统计数据

        #region 获取住院发票重打数据

        public long m_lngGetBillRePrintData(string p_strOperatorId,
                                            string p_strStartDate,
                                            string p_strEndDate,
                                            out DataTable p_dtbRePrint)
        {
            long lngRes = objReport.m_lngGetBillRePrintData(p_strOperatorId, p_strStartDate, p_strEndDate, out p_dtbRePrint);
            return lngRes;
        }

        #endregion //获取住院发票重打数据



        #endregion //住院收费员月发票报表

        #region 实收明细日志(发票明细)
        /// <summary>
        /// 实收明细日志(发票明细)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OperCode"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dv"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <param name="decTotalMoney"></param>
        /// <param name="decPreMoney"></param>
        public void m_mthRptInvoiceSum(string BeginDate, string EndDate, string OperCode, ArrayList DeptIDArr, DataGridView dv, out DataTable dtInvoice, out DataTable dtPayment, out decimal decTotalMoney, out decimal decPreMoney)
        {
            decTotalMoney = 0;
            decPreMoney = 0;

            long l = this.objReport.m_lngRptInvoiceSum(BeginDate, EndDate, OperCode, DeptIDArr, out dtInvoice, out dtPayment);
            if (l > 0)
            {
                dv.Rows.Clear();

                DataView dvpay = new DataView(dtPayment);

                for (int i = 0; i < dtInvoice.Rows.Count; i++)
                {
                    DataRow dr = dtInvoice.Rows[i];

                    decimal coef = 1;

                    if (dr["invostatus"].ToString() == "2")
                    {
                        coef = -1;
                    }

                    decTotalMoney += clsPublic.ConvertObjToDecimal(dr["totalsum_mny"]) * coef;
                    decPreMoney += clsPublic.ConvertObjToDecimal(dr["premoney"]) * coef;

                    string s = "";
                    string[] sarr = new string[18];
                    sarr[0] = Convert.ToString(i + 1);
                    sarr[1] = dr["opername"].ToString().Trim();
                    sarr[2] = dr["invoiceno_vchr"].ToString().Trim();
                    sarr[3] = dr["invodate"].ToString().Trim();
                    sarr[4] = dr["inpatientid_chr"].ToString().Trim();
                    sarr[5] = dr["patname"].ToString().Trim();
                    sarr[6] = dr["deptname_vchr"].ToString().Trim();
                    sarr[7] = dr["paytypename_vchr"].ToString().Trim();

                    //class_int: 1 中途结算 2 出院结算 3 呆帐结算 4 直收 5 确认收费
                    s = dr["class_int"].ToString().Trim();
                    if (s == "1")
                    {
                        s = "中途结算";
                    }
                    else if (s == "2")
                    {
                        s = "出院结算";
                    }
                    else if (s == "3")
                    {
                        s = "呆帐结算";
                    }
                    else if (s == "4")
                    {
                        s = "直收";
                    }
                    else if (s == "5")
                    {
                        s = "确认收费";
                    }
                    sarr[9] = s;

                    decimal d = clsPublic.ConvertObjToDecimal(dr["totalsum_mny"]) * coef;
                    sarr[10] = d.ToString("0.00");
                    d = clsPublic.ConvertObjToDecimal(dr["acctsum_mny"]) * coef;
                    sarr[11] = (d == 0 ? "" : d.ToString("0.00"));
                    d = clsPublic.ConvertObjToDecimal(dr["premoney"]) * coef;
                    sarr[12] = (d == 0 ? "" : d.ToString("0.00"));
                    d = clsPublic.ConvertObjToDecimal(dr["patchmoney"]);
                    sarr[13] = (d == 0 ? "" : d.ToString("0.00"));
                    sarr[14] = "";
                    sarr[15] = "";
                    sarr[16] = "";
                    sarr[17] = "";

                    s = "";

                    dvpay.RowFilter = "chargeno_chr = '" + dr["chargeno_chr"].ToString() + "'";
                    for (int j = 0; j < dvpay.Count; j++)
                    {
                        d = clsPublic.ConvertObjToDecimal(dvpay[j].Row["paymoney"]);
                        string s1 = dvpay[j].Row["paytype_int"].ToString();
                        if (s1 == "0")
                        {
                            s += " 预交金";
                        }
                        else if (s1 == "1")
                        {
                            s += " 现金";
                            sarr[14] = d.ToString("0.00");
                        }
                        else if (s1 == "2")
                        {
                            s += " 支票";
                            sarr[15] = d.ToString("0.00");
                        }
                        else if (s1 == "3")
                        {
                            s += " 银行卡";
                            sarr[16] = d.ToString("0.00");
                        }
                        else if (s1 == "4")
                        {
                            s += " 其他";
                            sarr[17] = d.ToString("0.00");
                        }
                    }
                    sarr[8] = s.Trim();

                    int row = dv.Rows.Add(sarr);
                    dv.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                    {
                        dv.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }
                }
            }
        }
        #endregion

        #region 实收明细日志(发票退票)
        /// <summary>
        /// 实收明细日志(发票退票)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OperCode"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dv"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <param name="decTotalMoney"></param>
        /// <param name="decXj"></param>
        /// <param name="decZp"></param>
        /// <param name="decYhk"></param>
        /// <param name="decQt"></param>
        public void m_mthRptInvoiceRefundment(string BeginDate, string EndDate, string OperCode, ArrayList DeptIDArr, DataGridView dv, out DataTable dtInvoice, out DataTable dtPayment, out decimal decTotalMoney, out decimal decXj, out decimal decZp, out decimal decYhk, out decimal decQt)
        {
            decTotalMoney = 0;
            decXj = 0;
            decZp = 0;
            decYhk = 0;
            decQt = 0;

            long l = this.objReport.m_lngRptInvoiceRefundment(BeginDate, EndDate, OperCode, DeptIDArr, out dtInvoice, out dtPayment);
            if (l > 0)
            {
                dv.Rows.Clear();

                DataView dvpay = new DataView(dtPayment);

                for (int i = 0; i < dtInvoice.Rows.Count; i++)
                {
                    DataRow dr = dtInvoice.Rows[i];

                    decTotalMoney += clsPublic.ConvertObjToDecimal(dr["totalsum_mny"]);

                    string s = "";
                    string[] sarr = new string[17];
                    sarr[0] = Convert.ToString(i + 1);
                    sarr[1] = dr["opername"].ToString().Trim();
                    sarr[2] = dr["invodate"].ToString().Trim();
                    sarr[3] = dr["inpatientid_chr"].ToString().Trim();
                    sarr[4] = dr["patname"].ToString().Trim();
                    sarr[5] = dr["deptname_vchr"].ToString().Trim();

                    sarr[7] = dr["invoiceno_vchr"].ToString().Trim();

                    sarr[10] = Math.Abs(clsPublic.ConvertObjToDecimal(dr["totalsum_mny"])).ToString("0.00");
                    sarr[11] = Math.Abs(clsPublic.ConvertObjToDecimal(dr["acctsum_mny"])).ToString("0.00");

                    sarr[12] = "";
                    sarr[13] = "";
                    sarr[14] = "";
                    sarr[15] = "";

                    dvpay.RowFilter = "invoiceno_vchr = '" + dr["invoiceno_vchr"].ToString() + "'";
                    for (int j = 0; j < dvpay.Count; j++)
                    {
                        decimal d = clsPublic.ConvertObjToDecimal(dvpay[j].Row["paymoney"]);
                        string s1 = dvpay[j].Row["paytype_int"].ToString();
                        if (s1 == "0")
                        {
                            s += " 预交金";
                        }
                        else if (s1 == "1")
                        {
                            s += " 现金";
                            decXj += d;
                            sarr[12] = d.ToString("0.00");
                        }
                        else if (s1 == "2")
                        {
                            s += " 支票";
                            decZp += d;
                            sarr[13] = d.ToString("0.00");
                        }
                        else if (s1 == "3")
                        {
                            s += " 银行卡";
                            decYhk += d;
                            sarr[14] = d.ToString("0.00");
                        }
                        else if (s1 == "4")
                        {
                            s += " 其他";
                            decQt += d;
                            sarr[15] = d.ToString("0.00");
                        }
                    }
                    sarr[6] = s.Trim();
                    sarr[8] = dvpay[0].Row["invodate"].ToString();
                    sarr[9] = dvpay[0].Row["lastname_vchr"].ToString();

                    int row = dv.Rows.Add(sarr);
                    dv.Rows[row].Tag = dr;

                    if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                    {
                        dv.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }
                }
            }
        }
        #endregion

        #region 科室实收报表
        /// <summary>
        /// 科室实收报表
        /// </summary>
        /// <param name="Type">1 开单科室实收 2 执行科室实收</param>
        /// <param name="RptID"></param>
        /// <param name="RptStyle">1 正常 2 横向转纵向</param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>        
        /// <returns></returns>        
        public void m_mthRptDeptIncome(int Type, string RptID, string RptStyle, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SQL = "", SubStr = "", LogTitle = "";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                if (Type == 0 || Type == 3 || Type == 4 || Type == 90)
                {
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "a.curareaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    }
                }
                else if (Type == 1 || Type == 91)
                {
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "b.createarea_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    }
                }
                else if (Type == 2 || Type == 92)
                {
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "b.deptid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    }
                }
                else if (Type == 5)
                {
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "a.createarea_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    }
                }
                else if (Type == 6)
                {
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "a.clacarea_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    }
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            if (Type == 0)
            {
                LogTitle = "全院实收(按发票时间)";

                if (RptStyle == "1")
                {
                    SQL = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                     nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                                from (select   a.curareaid_chr, sum (a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as totalsum
                                          from t_opr_bih_chargeitementry a
                                         where (a.operdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"    
                                      group by a.curareaid_chr) ta,
                                     ( select  a.curareaid_chr, tb.groupid_chr, tb.groupname_chr,
                                               sum (a.totalmoney_dec) as catsum
                                          from t_opr_bih_chargeitementry a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.operdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"    
                                      group by a.curareaid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                     t_bse_deptdesc td
                               where ta.curareaid_chr = tc.curareaid_chr
                                 and ta.totalsum <> 0
                                 and ta.curareaid_chr = td.deptid_chr(+)
                            order by td.deptname_vchr";
                }
                else if (RptStyle == "2")
                {
                    SQL = @"select   ta.groupid_chr, ta.groupname_chr, ta.totalsum, tb.curareaid_chr,
                                     tc.deptname_vchr, tb.catsum
                                from (select   tb.groupid_chr, tb.groupname_chr,
                                               sum (a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as totalsum
                                          from t_opr_bih_chargeitementry a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.operdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"    
                                      group by tb.groupid_chr, tb.groupname_chr) ta,
                                     (select   a.curareaid_chr, tb.groupid_chr,
                                               sum (a.totalmoney_dec) as catsum
                                          from t_opr_bih_chargeitementry a,
                                               (select b.groupid_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.operdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"    
                                      group by a.curareaid_chr, tb.groupid_chr) tb,
                                     t_bse_deptdesc tc
                               where ta.groupid_chr = tb.groupid_chr
                                 and tb.curareaid_chr = tc.deptid_chr(+)
                                 and ta.totalsum <> 0
                            order by ta.groupid_chr";
                }
            }
            else if (Type == 90)
            {
                LogTitle = "全院实收(按日结时间)";

                if (RptStyle == "1")
                {
                    SQL = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                     nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                                from (select   a.curareaid_chr, sum (a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as totalsum
                                          from t_opr_bih_chargeitementry a,
                                               t_opr_bih_charge b 
                                         where a.chargeno_chr = b.chargeno_chr
                                           and b.status_int = 1                                       
                                           and b.recflag_int = 1
                                           and (b.recdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @" 
                                      group by a.curareaid_chr) ta,
                                     ( select  a.curareaid_chr, tb.groupid_chr, tb.groupname_chr,
                                               sum (a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as catsum
                                          from t_opr_bih_chargeitementry a,
                                               t_opr_bih_charge b,  
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.calccateid_chr = tb.typeid_chr(+) 
                                           and a.chargeno_chr = b.chargeno_chr 
                                           and b.status_int = 1                                        
                                           and b.recflag_int = 1
                                           and (b.recdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @" 
                                      group by a.curareaid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                     t_bse_deptdesc td
                               where ta.curareaid_chr = tc.curareaid_chr
                                 and ta.totalsum <> 0
                                 and ta.curareaid_chr = td.deptid_chr(+)
                            order by td.deptname_vchr";
                }
                else if (RptStyle == "2")
                {
                    SQL = @"select   ta.groupid_chr, ta.groupname_chr, ta.totalsum, tb.curareaid_chr,
                                     tc.deptname_vchr, tb.catsum
                                from (select   tb.groupid_chr, tb.groupname_chr,
                                               sum (a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as totalsum
                                          from t_opr_bih_chargeitementry a,
                                               t_opr_bih_charge b, 
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.chargeno_chr = b.chargeno_chr
                                           and b.status_int = 1
                                           and b.recflag_int = 1
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (b.recdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"    
                                      group by tb.groupid_chr, tb.groupname_chr) ta,
                                     (select   a.curareaid_chr, tb.groupid_chr,
                                               sum (a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as catsum
                                          from t_opr_bih_chargeitementry a,
                                               t_opr_bih_charge b, 
                                               (select b.groupid_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.chargeno_chr = b.chargeno_chr
                                           and b.status_int = 1
                                           and b.recflag_int = 1
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (b.recdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"    
                                      group by a.curareaid_chr, tb.groupid_chr) tb,
                                     t_bse_deptdesc tc
                               where ta.groupid_chr = tb.groupid_chr
                                 and tb.curareaid_chr = tc.deptid_chr(+)
                                 and ta.totalsum <> 0
                            order by ta.groupid_chr";
                }
            }
            else if (Type == 1)
            {
                LogTitle = "全院开单科室实收(按发票时间)";
                SQL = @"select ta.deptid_chr as deptid, tc.deptname_vchr as deptname,
                               tb.groupid_chr as groupid, nvl(tb.groupname_chr,'未定义') as groupname,
                               sum(ta.totalsum) as cattotalsum		  	 
                          from (
                                select b.createarea_chr as deptid_chr, b.calccateid_chr, SUM (b.totalmoney_dec + nvl(b.totaldiffcostmoney_dec,0)) AS totalsum
                                  from t_opr_bih_chargeitementry b 
                                  where (b.operdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"                               
                                group by b.createarea_chr, b.calccateid_chr  
                               ) ta,   
                               (
                                select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                  from t_aid_rpt_def a,
                                       t_aid_rpt_gop_def b,
                                       t_aid_rpt_gop_rla c
                                 where a.rptid_chr = '" + RptID + @"'  
                                   and a.rptid_chr = b.rptid_chr 
                                   and b.rptid_chr = c.rptid_chr 
                                   and b.groupid_chr = c.groupid_chr(+)
                               ) tb,
                               t_bse_deptdesc tc 
                         where ta.calccateid_chr = tb.typeid_chr(+)                                          
                           and ta.deptid_chr = tc.deptid_chr(+)                                                                        
                      group by ta.deptid_chr, tc.deptname_vchr, tb.groupid_chr, tb.groupname_chr 
                      order by ta.deptid_chr ";
            }
            else if (Type == 91)
            {
                LogTitle = "全院开单科室实收(按日结时间)";
                SQL = @"select ta.deptid_chr as deptid, tc.deptname_vchr as deptname,
                           tb.groupid_chr as groupid, nvl(tb.groupname_chr,'未定义') as groupname,
                           sum(ta.totalsum) as cattotalsum		  	 
                      from (
                            select b.createarea_chr as deptid_chr, b.calccateid_chr, SUM (b.totalmoney_dec + nvl(b.totaldiffcostmoney_dec,0)) AS totalsum
                              from t_opr_bih_chargeitementry b,
                                   t_opr_bih_charge a  
                             where a.chargeno_chr = b.chargeno_chr 
                               and a.status_int = 1 
                               and a.recflag_int = 1 
                               and (a.recdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"                                 
                            group by b.createarea_chr, b.calccateid_chr  
                           ) ta,   
                           (
                            select b.groupid_chr, b.groupname_chr, c.typeid_chr
                              from t_aid_rpt_def a,
                                   t_aid_rpt_gop_def b,
                                   t_aid_rpt_gop_rla c
                             where a.rptid_chr = '" + RptID + @"'  
                               and a.rptid_chr = b.rptid_chr 
                               and b.rptid_chr = c.rptid_chr 
                               and b.groupid_chr = c.groupid_chr(+)
                           ) tb,
                           t_bse_deptdesc tc 
                     where ta.calccateid_chr = tb.typeid_chr(+)                                          
                       and ta.deptid_chr = tc.deptid_chr(+)                                                                        
                  group by ta.deptid_chr, tc.deptname_vchr, tb.groupid_chr, tb.groupname_chr 
                  order by ta.deptid_chr ";
            }
            else if (Type == 2)
            {
                LogTitle = "全院执行科室实收(按发票时间)";
                SQL = @"select b.deptid_chr as deptid, f.deptname_vchr as deptname,
                               c.groupid_chr as groupid, nvl(c.groupname_chr,'未定义') as groupname,
                               sum(b.totalsum_mny) as cattotalsum		  	 
                          from t_opr_bih_charge a,
                               t_opr_bih_chargecat b,
                               (
                                select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                  from t_aid_rpt_def a,
                                       t_aid_rpt_gop_def b,
                                       t_aid_rpt_gop_rla c
                                 where a.rptid_chr = '" + RptID + @"' 
                                   and a.rptid_chr = b.rptid_chr 
                                   and b.rptid_chr = c.rptid_chr 
                                   and b.groupid_chr = c.groupid_chr(+)
                               ) c,
                               t_bse_deptdesc f
                         where a.chargeno_chr = b.chargeno_chr                       
                           and b.itemcatid_chr = c.typeid_chr(+) 
                           and a.status_int = 1   
                           and b.deptid_chr = f.deptid_chr(+)  
                           and (a.operdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @" 
                      group by b.deptid_chr, f.deptname_vchr, c.groupid_chr, c.groupname_chr 
                      order by b.deptid_chr";
            }
            else if (Type == 92)
            {
                LogTitle = "全院执行科室实收(按日结时间)";
                SQL = @"select b.deptid_chr as deptid, f.deptname_vchr as deptname,
                               c.groupid_chr as groupid, nvl(c.groupname_chr,'未定义') as groupname,
                               sum(b.totalsum_mny) as cattotalsum		  	 
                          from t_opr_bih_charge a,
                               t_opr_bih_chargecat b,
                               (
                                select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                  from t_aid_rpt_def a,
                                       t_aid_rpt_gop_def b,
                                       t_aid_rpt_gop_rla c
                                 where a.rptid_chr = '" + RptID + @"' 
                                   and a.rptid_chr = b.rptid_chr 
                                   and b.rptid_chr = c.rptid_chr 
                                   and b.groupid_chr = c.groupid_chr(+)
                               ) c,
                               t_bse_deptdesc f
                         where a.chargeno_chr = b.chargeno_chr                       
                           and b.itemcatid_chr = c.typeid_chr(+) 
                           and a.status_int = 1  
                           and a.recflag_int = 1 
                           and b.deptid_chr = f.deptid_chr(+)  
                           and (a.recdate_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"                        
                      group by b.deptid_chr, f.deptname_vchr, c.groupid_chr, c.groupname_chr 
                      order by b.deptid_chr";
            }
            else if (Type == 3)
            {
                LogTitle = "全院业务收入";

                if (RptStyle == "1")
                {
                    SQL = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                     nvl (tc.groupname_chr, '未定义') as groupname_chr, nvl(tc.catsum,0) catsum
                                from (select   a.curareaid_chr, sum(round(a.amount_dec * a.unitprice_dec, 2) + nvl(a.totaldiffcostmoney_dec, 0)) as totalsum
                                          from t_opr_bih_patientcharge a
                                         where a.status_int = 1
                                           and a.pstatus_int <> 0 
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by a.curareaid_chr) ta,
                                     ( select  a.curareaid_chr, tb.groupid_chr, tb.groupname_chr,
                                               sum (round(a.amount_dec * a.unitprice_dec,2) + nvl(a.totaldiffcostmoney_dec,0)) as catsum
                                          from t_opr_bih_patientcharge a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.status_int = 1 
                                           and a.pstatus_int <> 0         
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by a.curareaid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                     t_bse_deptdesc td
                               where ta.curareaid_chr = tc.curareaid_chr
                                 and ta.totalsum <> 0
                                 and ta.curareaid_chr = td.deptid_chr(+)
                            order by td.deptname_vchr";
                }
                else if (RptStyle == "2")
                {
                    SQL = @"select   ta.groupid_chr, ta.groupname_chr, ta.totalsum, tb.curareaid_chr,
                                     tc.deptname_vchr, tb.catsum
                                from (select   tb.groupid_chr, tb.groupname_chr,
                                               sum (round (a.amount_dec * a.unitprice_dec, 2)) as totalsum
                                          from t_opr_bih_patientcharge a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"'
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.status_int = 1
                                           and a.pstatus_int <> 0
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by tb.groupid_chr, tb.groupname_chr) ta,
                                     (select   a.curareaid_chr, tb.groupid_chr,
                                               sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                          from t_opr_bih_patientcharge a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"'
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.status_int = 1
                                           and a.pstatus_int <> 0
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by a.curareaid_chr, tb.groupid_chr) tb,
                                     t_bse_deptdesc tc
                               where ta.groupid_chr = tb.groupid_chr
                                 and tb.curareaid_chr = tc.deptid_chr(+)
                                 and ta.totalsum <> 0
                            order by ta.groupid_chr";
                }
            }
            else if (Type == 4)
            {
                LogTitle = "全院未清费用";

                if (RptStyle == "1")
                {
                    SQL = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                     nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                                from (select   a.curareaid_chr, sum (round(a.amount_dec*a.unitprice_dec,2)) as totalsum
                                          from t_opr_bih_patientcharge a
                                         where a.status_int = 1
                                           and (a.pstatus_int = 1 or a.pstatus_int = 2) 
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"                                           
                                      group by a.curareaid_chr) ta,
                                     ( select  a.curareaid_chr, tb.groupid_chr, tb.groupname_chr,
                                               sum (round(a.amount_dec*a.unitprice_dec,2)) as catsum
                                          from t_opr_bih_patientcharge a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.status_int = 1 
                                           and (a.pstatus_int = 1 or a.pstatus_int = 2)         
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by a.curareaid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                     t_bse_deptdesc td
                               where ta.curareaid_chr = tc.curareaid_chr
                                 and ta.totalsum <> 0
                                 and ta.curareaid_chr = td.deptid_chr(+)
                            order by td.deptname_vchr";
                }
                else if (RptStyle == "2")
                {
                    SQL = @"select   ta.groupid_chr, ta.groupname_chr, ta.totalsum, tb.curareaid_chr,
                                     tc.deptname_vchr, tb.catsum
                                from (select   tb.groupid_chr, tb.groupname_chr,
                                               sum (round (a.amount_dec * a.unitprice_dec, 2)) as totalsum
                                          from t_opr_bih_patientcharge a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.status_int = 1
                                           and (a.pstatus_int = 1 or a.pstatus_int = 2)
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by tb.groupid_chr, tb.groupname_chr) ta,
                                     (select   a.curareaid_chr, tb.groupid_chr,
                                               sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                          from t_opr_bih_patientcharge a,
                                               (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                  from t_aid_rpt_def a,
                                                       t_aid_rpt_gop_def b,
                                                       t_aid_rpt_gop_rla c
                                                 where a.rptid_chr = '" + RptID + @"' 
                                                   and a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr
                                                   and b.groupid_chr = c.groupid_chr(+)) tb
                                         where a.status_int = 1
                                           and (a.pstatus_int = 1 or a.pstatus_int = 2)
                                           and a.calccateid_chr = tb.typeid_chr(+)
                                           and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                      group by a.curareaid_chr, tb.groupid_chr) tb,
                                     t_bse_deptdesc tc
                               where ta.groupid_chr = tb.groupid_chr
                                 and tb.curareaid_chr = tc.deptid_chr(+)
                                 and ta.totalsum <> 0
                            order by ta.groupid_chr";
                }
            }
            else if (Type == 5)
            {
                LogTitle = "全院开单科室业务收入";
                SQL = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                 nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                            from (select   a.createarea_chr, sum (round(a.amount_dec*a.unitprice_dec,2)) as totalsum
                                      from t_opr_bih_patientcharge a
                                     where a.status_int = 1
                                       and a.pstatus_int <> 0  
                                       and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"                                         
                                  group by a.createarea_chr) ta,
                                 ( select  a.createarea_chr, tb.groupid_chr, tb.groupname_chr,
                                           sum (round(a.amount_dec*a.unitprice_dec,2)) as catsum
                                      from t_opr_bih_patientcharge a,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '" + RptID + @"' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) tb
                                     where a.status_int = 1 
                                       and a.pstatus_int <> 0         
                                       and a.calccateid_chr = tb.typeid_chr(+)
                                       and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                  group by a.createarea_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                 t_bse_deptdesc td
                           where ta.createarea_chr = tc.createarea_chr
                             and ta.totalsum <> 0
                             and ta.createarea_chr = td.deptid_chr(+)
                        order by td.deptname_vchr";
            }
            else if (Type == 6)
            {
                LogTitle = "全院执行科室业务收入";
                SQL = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                 nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                            from (select   a.clacarea_chr, sum (round(a.amount_dec*a.unitprice_dec,2)) as totalsum
                                      from t_opr_bih_patientcharge a
                                     where a.status_int = 1
                                       and a.pstatus_int <> 0  
                                       and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                  group by a.clacarea_chr) ta,
                                 ( select  a.clacarea_chr, tb.groupid_chr, tb.groupname_chr,
                                           sum (round(a.amount_dec*a.unitprice_dec,2)) as catsum
                                      from t_opr_bih_patientcharge a,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '" + RptID + @"' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) tb
                                     where a.status_int = 1 
                                       and a.pstatus_int <> 0         
                                       and a.calccateid_chr = tb.typeid_chr(+)
                                       and (a.chargeactive_dat between to_date('" + BeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + EndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @"  
                                  group by a.clacarea_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                 t_bse_deptdesc td
                           where ta.clacarea_chr = tc.clacarea_chr
                             and ta.totalsum <> 0
                             and ta.clacarea_chr = td.deptid_chr(+)
                        order by td.deptname_vchr";
            }

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.CalculateGroups();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, SQL);
            #endregion

            #region 三层
            /***三层***
            DataTable dt;
            long l = this.objReport.m_lngRptDeptIncome(Type, RptID, BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {               
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);                                
                dwRep.SetRedrawOn();
            }
            /******/
            #endregion
        }
        #endregion

        #region 收费员工作量统计报表
        /// <summary>
        /// 收费员工作量统计报表
        /// </summary>
        /// <param name="RptType"></param>
        /// <param name="RptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptReceiverSum(int RptType, string RptID, string BeginDate, string EndDate, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SQL = "", LogTitle = "";
            if (RptType == 9)
            {
                LogTitle = "收费员工作量(按日结时间)";
                SQL = @" select  tf.lastname_vchr, tb.invonums, ta.totalsum, te.groupid_chr,
                                 nvl(te.groupname_chr, '未定义') as groupname_chr, te.catsum
                            from (select   a.operemp_chr, sum (a.totalsum_mny) as totalsum
                                      from t_opr_bih_charge a
                                     where a.status_int = 1 
                                       and a.recflag_int = 1
                                       and (to_char(a.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')  
                                  group by a.operemp_chr) ta,
                                 (select   a.operemp_chr,
                                           sum (case a.type_int
                                                   when 1
                                                      then 1
                                                   else -1
                                                end) as invonums
                                      from t_opr_bih_charge a
                                     where a.status_int = 1 
                                       and a.recflag_int = 1 
                                       and (to_char(a.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')          
                                  group by a.operemp_chr) tb,
                                 (select   tc.operemp_chr, td.groupid_chr, td.groupname_chr,
                                           sum (tc.catsum) as catsum
                                      from (select   a.operemp_chr, b.itemcatid_chr,
                                                     sum (b.totalsum_mny) as catsum
                                                from t_opr_bih_charge a, t_opr_bih_chargecat b
                                               where a.chargeno_chr = b.chargeno_chr
                                                 and a.status_int = 1 
                                                 and a.recflag_int = 1
                                                 and (to_char(a.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')    
                                            group by a.operemp_chr, b.itemcatid_chr) tc,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '" + RptID + @"' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) td
                                     where tc.itemcatid_chr = td.typeid_chr(+)
                                  group by tc.operemp_chr, td.groupid_chr, td.groupname_chr) te,
                                 t_bse_employee tf
                           where ta.operemp_chr = tb.operemp_chr
                             and ta.operemp_chr = te.operemp_chr
                             and ta.operemp_chr = tf.empid_chr(+)
                        order by tf.lastname_vchr";
            }
            else
            {
                LogTitle = "收费员工作量(按发票时间)";
                SQL = @" select  tf.lastname_vchr, tb.invonums, ta.totalsum, te.groupid_chr,
                                 nvl(te.groupname_chr, '未定义') as groupname_chr, te.catsum
                            from (select   a.operemp_chr, sum (a.totalsum_mny) as totalsum
                                      from t_opr_bih_charge a
                                     where a.status_int = 1 
                                       and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')  
                                  group by a.operemp_chr) ta,
                                 (select   a.operemp_chr,
                                           sum (case a.type_int
                                                   when 1
                                                      then 1
                                                   else -1
                                                end) as invonums
                                      from t_opr_bih_charge a
                                     where a.status_int = 1 
                                       and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')          
                                  group by a.operemp_chr) tb,
                                 (select   tc.operemp_chr, td.groupid_chr, td.groupname_chr,
                                           sum (tc.catsum) as catsum
                                      from (select   a.operemp_chr, b.itemcatid_chr,
                                                     sum (b.totalsum_mny) as catsum
                                                from t_opr_bih_charge a, t_opr_bih_chargecat b
                                               where a.chargeno_chr = b.chargeno_chr
                                                 and a.status_int = 1 
                                                 and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')    
                                            group by a.operemp_chr, b.itemcatid_chr) tc,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '" + RptID + @"' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) td
                                     where tc.itemcatid_chr = td.typeid_chr(+)
                                  group by tc.operemp_chr, td.groupid_chr, td.groupname_chr) te,
                                 t_bse_employee tf
                           where ta.operemp_chr = tb.operemp_chr
                             and ta.operemp_chr = te.operemp_chr
                             and ta.operemp_chr = tf.empid_chr(+)
                        order by tf.lastname_vchr";
            }

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, SQL);
            #endregion

            #region 三层
            #endregion
        }
        #endregion

        #region 主治医生实收报表
        /// <summary>
        /// 主治医生实收报表
        /// </summary>
        /// <param name="RptType"></param>
        /// <param name="RptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptDoctorSum(int RptType, string RptID, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SQL = "", SubStr = "", LogTitle = "";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.curareaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            if (RptType == 9)
            {
                LogTitle = "主治医生实收(按日结时间)";
                SQL = @"select   nvl(td.empno_chr,'<离职>') as empno_chr, td.lastname_vchr, ta.totalsum, tc.groupid_chr,
                             nvl(tc.groupname_chr,'未定义') as groupname_chr, tc.catsum
                        from (select   a.doctorid_chr, sum (a.totalmoney_dec) as totalsum
                                  from t_opr_bih_chargeitementry a,
                                       t_opr_bih_charge b 
                                 where a.chargeno_chr = b.chargeno_chr
                                   and b.status_int = 1 
                                   and b.recflag_int = 1
                                   and (to_char(b.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + "')" + SubStr + @"   
                              group by a.doctorid_chr) ta,
                             (select   a.doctorid_chr, tb.groupid_chr, tb.groupname_chr,
                                       sum (a.totalmoney_dec) as catsum
                                  from t_opr_bih_chargeitementry a,
                                       t_opr_bih_charge b,  
                                       (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                          from t_aid_rpt_def a,
                                               t_aid_rpt_gop_def b,
                                               t_aid_rpt_gop_rla c
                                         where a.rptid_chr = '" + RptID + @"' 
                                           and a.rptid_chr = b.rptid_chr
                                           and b.rptid_chr = c.rptid_chr
                                           and b.groupid_chr = c.groupid_chr(+)) tb
                                 where a.calccateid_chr = tb.typeid_chr(+) " + SubStr + @" 
                                   and a.chargeno_chr = b.chargeno_chr
                                   and b.status_int = 1 
                                   and b.recflag_int = 1  
                                   and (to_char(b.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')   
                              group by a.doctorid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                             t_bse_employee td
                       where ta.doctorid_chr = tc.doctorid_chr and ta.doctorid_chr = td.empid_chr(+)
                    order by td.empno_chr";
            }
            else
            {
                LogTitle = "主治医生实收(按发票时间)";
                SQL = @"select   nvl(td.empno_chr,'<离职>') as empno_chr, td.lastname_vchr, ta.totalsum, tc.groupid_chr,
                             nvl(tc.groupname_chr,'未定义') as groupname_chr, tc.catsum
                        from (select   a.doctorid_chr, sum (a.totalmoney_dec) as totalsum
                                  from t_opr_bih_chargeitementry a
                                 where (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + "')" + SubStr + @"   
                              group by a.doctorid_chr) ta,
                             (select   a.doctorid_chr, tb.groupid_chr, tb.groupname_chr,
                                       sum (a.totalmoney_dec) as catsum
                                  from t_opr_bih_chargeitementry a,
                                       (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                          from t_aid_rpt_def a,
                                               t_aid_rpt_gop_def b,
                                               t_aid_rpt_gop_rla c
                                         where a.rptid_chr = '" + RptID + @"' 
                                           and a.rptid_chr = b.rptid_chr
                                           and b.rptid_chr = c.rptid_chr
                                           and b.groupid_chr = c.groupid_chr(+)) tb
                                 where a.calccateid_chr = tb.typeid_chr(+) " + SubStr + @" 
                                   and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')   
                              group by a.doctorid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                             t_bse_employee td
                       where ta.doctorid_chr = tc.doctorid_chr and ta.doctorid_chr = td.empid_chr(+)
                    order by td.empno_chr";
            }

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, SQL);
            #endregion

            #region 三层
            #endregion
        }
        #endregion

        #region 身份实收报表
        /// <summary>
        /// 身份实收报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="SubPayType"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptPayTypeClass(string BeginDate, string EndDate, string SubPayType, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SubStr = "";
            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "c.areaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            string SQL = @"select ta.registerid_chr, c.lastname_vchr, ta.totalsum, tb.itemcatid_chr,
                                 d.typename_vchr, tb.catsum
                            from (select a.registerid_chr, sum(a.totalsum_mny) as totalsum
                                    from t_opr_bih_charge a,
                                         t_opr_bih_register c    
                                   where a.registerid_chr = c.registerid_chr 
                                     and a.status_int = 1 
                                     and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + "') " + SubPayType + SubStr + @" 
                                  group by a.registerid_chr) ta,
                                 (select a.registerid_chr, b.itemcatid_chr,
                                         sum(b.totalsum_mny) as catsum
                                    from t_opr_bih_charge a, t_opr_bih_chargecat b, t_opr_bih_register c 
                                   where a.chargeno_chr = b.chargeno_chr 
                                     and a.registerid_chr = c.registerid_chr
                                     and a.status_int = 1 
                                     and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + "') " + SubPayType + SubStr + @" 
                                  group by a.registerid_chr, b.itemcatid_chr) tb,
                                 t_opr_bih_registerdetail c,
                                 t_bse_chargeitemextype d
                           where ta.registerid_chr = tb.registerid_chr
                             and ta.registerid_chr = c.registerid_chr(+)
                             and tb.itemcatid_chr = d.typeid_chr(+)
                        order by c.lastname_vchr";

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog("身份实收", SQL);
            #endregion
        }
        #endregion

        #region 专业组实收报表
        /// <summary>
        /// 专业组实收报表
        /// </summary>
        /// <param name="RptType"></param>
        /// <param name="RptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dwRep"></param>      
        public void m_mthRptGroupIncome(int RptType, string RptID, string BeginDate, string EndDate, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SQL = "", LogTitle = ""; ;
            if (RptType == 9)
            {
                LogTitle = "专业组实收(按日结时间)";
                SQL = @"select   nvl (td.usercode_chr, '<未定义>') as groupno, nvl(td.groupname_vchr, '<未定义>') as groupname,
                                 ta.totalsum, tc.groupid_chr,
                                 nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                            from (select   a.doctorgroupid_chr, sum (a.totalmoney_dec) as totalsum
                                      from t_opr_bih_chargeitementry a,
                                           t_opr_bih_charge b  
                                     where a.chargeno_chr = b.chargeno_chr
                                       and b.status_int = 1 
                                       and b.recflag_int = 1
                                       and (to_char(b.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')   
                                  group by a.doctorgroupid_chr) ta,
                                 (select   a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr,
                                           sum (a.totalmoney_dec) as catsum
                                      from t_opr_bih_chargeitementry a,
                                           t_opr_bih_charge b, 
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '" + RptID + @"' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) tb
                                     where a.calccateid_chr = tb.typeid_chr(+)
                                       and a.chargeno_chr = b.chargeno_chr
                                       and b.status_int = 1 
                                       and b.recflag_int = 1  
                                       and (to_char(b.recdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')   
                                  group by a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                 t_bse_groupdesc td
                           where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                             and ta.doctorgroupid_chr = td.groupid_chr(+)
                        order by td.usercode_chr";
            }
            else
            {
                LogTitle = "专业组实收(按发票时间)";
                SQL = @"select   nvl (td.usercode_chr, '<未定义>') as groupno, nvl(td.groupname_vchr, '<未定义>') as groupname,
                                 ta.totalsum, tc.groupid_chr,
                                 nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                            from (select   a.doctorgroupid_chr, sum (a.totalmoney_dec) as totalsum
                                      from t_opr_bih_chargeitementry a
                                     where (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')   
                                  group by a.doctorgroupid_chr) ta,
                                 (select   a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr,
                                           sum (a.totalmoney_dec) as catsum
                                      from t_opr_bih_chargeitementry a,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '" + RptID + @"' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) tb
                                     where a.calccateid_chr = tb.typeid_chr(+)
                                       and (to_char(a.operdate_dat, 'yyyy-mm-dd') between '" + BeginDate + "' and '" + EndDate + @"')   
                                  group by a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                 t_bse_groupdesc td
                           where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                             and ta.doctorgroupid_chr = td.groupid_chr(+)
                        order by td.usercode_chr";
            }
            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, SQL);
            #endregion

            #region 三层
            #endregion
        }

        #endregion

        #region 医保结算明细报表
        /// <summary>
        /// 医保结算明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptYBEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptYBEntry(BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 已清预交金明细报表
        /// <summary>
        /// 已清预交金明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>       
        /// <param name="dwRep"></param>
        public void m_mthRptPrePayClear(string BeginDate, string EndDate, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '" + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptPrePayClear(BeginDate, EndDate, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 科室实收明细报表(停)
        /// <summary>
        /// 科室实收明细报表(停)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptDeptIncomeEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptDeptIncomeEntry(BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 科室实收明细报表(新)
        /// <summary>
        /// 科室实收明细报表(新)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="DeptName"></param>
        /// <param name="RptID"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptDeptIncomeEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, string DeptName, string RptID, DataWindowControl dwRep)
        {
            dwRep.Modify("t_ks.text = '科室: " + DeptName + "'");
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            string SQL = "", SubStr = "";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";
                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "b.curareaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            SQL = @"select   a.inpatientid_chr, b.lastname_vchr,
                             to_char (a.inpatient_dat, 'yyyy-mm-dd') as ryrq,
                             to_char (c.outhospital_dat, 'yyyy-mm-dd') as cyrq, nvl(tc.deptname_vchr, '" + DeptName + @"') as deptname_vchr,
                             ta.totalsum, tb.groupid_chr, nvl(tb.groupname_chr,'未定义') as groupname_chr, tb.catsum ,f.lastname_vchr as doctorname
                        from t_opr_bih_register a,
                             t_opr_bih_registerdetail b,
                             t_bse_employee f,
                             (select registerid_chr, outhospital_dat
                                from t_opr_bih_leave
                               where status_int = 1) c,
                             (select   a.registerid_chr, b.curareaid_chr,
                                       sum (b.totalmoney_dec) as totalsum, b.chargedoctorid_chr
                                  from t_opr_bih_charge a, t_opr_bih_chargeitementry b
                                 where a.registerid_chr = b.registerid_chr
                                   and a.chargeno_chr = b.chargeno_chr                         
                                   and a.status_int = 1
                                   and a.recflag_int = 1
                                   and (a.recdate_dat between to_date ('" + BeginDate + @" 00:00:00',
                                                                        'yyyy-mm-dd hh24:mi:ss')
                                                           and to_date ('" + EndDate + @" 23:59:59',
                                                                        'yyyy-mm-dd hh24:mi:ss')
                                       ) " + SubStr + @"
                              group by a.registerid_chr, b.curareaid_chr, b.chargedoctorid_chr) ta,
                             (select   a.registerid_chr, b.curareaid_chr, c.groupid_chr,
                                       c.groupname_chr, sum (b.totalmoney_dec) as catsum,b.chargedoctorid_chr
                                  from t_opr_bih_charge a,
                                       t_opr_bih_chargeitementry b,
                                       (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                          from t_aid_rpt_def a,
                                               t_aid_rpt_gop_def b,
                                               t_aid_rpt_gop_rla c
                                         where a.rptid_chr = '" + RptID + @"'
                                           and a.rptid_chr = b.rptid_chr
                                           and b.rptid_chr = c.rptid_chr
                                           and b.groupid_chr = c.groupid_chr(+)) c
                                 where a.registerid_chr = b.registerid_chr
                                   and a.chargeno_chr = b.chargeno_chr 
                                   and b.calccateid_chr = c.typeid_chr(+)
                                   and a.status_int = 1
                                   and a.recflag_int = 1
                                   and (a.recdate_dat between to_date ('" + BeginDate + @" 00:00:00',
                                                                        'yyyy-mm-dd hh24:mi:ss')
                                                           and to_date ('" + EndDate + @" 23:59:59',
                                                                        'yyyy-mm-dd hh24:mi:ss')
                                       ) " + SubStr + @"
                              group by a.registerid_chr,
                                       b.curareaid_chr,
                                       c.groupid_chr,
                                       c.groupname_chr,b.chargedoctorid_chr) tb,
                             (select a.registerid_chr, c.deptname_vchr
                                  from t_opr_bih_patientcharge a,
                                       (select   a.registerid_chr, max (a.pchargeid_chr) as pchargeid_chr
                                            from t_opr_bih_patientcharge a,
                                                 (select   b.registerid_chr,
                                                           min (b.pchargeid_chr) as pchargeid_chr
                                                      from t_opr_bih_patientcharge b
                                                     where b.status_int = 1
                                                       and b.chargeactive_dat is not null " + SubStr + @"                                                      
                                                       and exists (
                                                              select 1
                                                                from t_opr_bih_charge c
                                                               where c.status_int = 1
                                                                 and c.recflag_int = 1
                                                                 and (c.recdate_dat
                                                                         between to_date ('" + BeginDate + @" 00:00:00',
                                                                        'yyyy-mm-dd hh24:mi:ss')
                                                                               and to_date ('" + EndDate + @" 23:59:59',
                                                                                            'yyyy-mm-dd hh24:mi:ss')
                                                                     )
                                                                 and b.registerid_chr = c.registerid_chr)
                                                  group by b.registerid_chr) b
                                           where a.registerid_chr = b.registerid_chr
                                             and a.pchargeid_chr < b.pchargeid_chr
                                        group by a.registerid_chr) b,
                                       t_bse_deptdesc c
                                 where a.registerid_chr = b.registerid_chr
                                   and a.pchargeid_chr = b.pchargeid_chr
                                   and a.curareaid_chr = c.deptid_chr(+)) tc
                       where a.registerid_chr = b.registerid_chr
                         and a.registerid_chr = c.registerid_chr(+)
                         and a.registerid_chr = ta.registerid_chr
                         and a.registerid_chr = tb.registerid_chr
                         and a.registerid_chr = tc.registerid_chr(+)
                         and ta.chargedoctorid_chr = f.empid_chr
                    order by a.inpatientid_chr";

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.CalculateGroups();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog("科室实收明细报表", SQL);
        }
        #endregion

        #region 补记账日志报表
        /// <summary>
        /// 补记账日志报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_lngRptLogBuShou(int RptType, string OperCode, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptLogBuShou(RptType, OperCode, BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 出院结账日志报表
        /// <summary>
        /// 出院结账日志报表
        /// </summary>
        /// <param name="RptType"></param>
        /// <param name="OperCode"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_lngRptLogSettleAccount(string OperCode, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptLogSettleAccount(OperCode, BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 项目统计发生明细报表
        /// <summary>
        /// 项目统计发生明细报表
        /// </summary>
        /// <param name="CodeNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public void m_lngRptItemDetailStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptItemDetailStat(CodeNo, BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 药品消报表(按发生)
        /// <summary>
        /// 药品消报表(按发生)
        /// </summary>
        /// <param name="CodeNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public void m_lngRptDragUsedStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " - " + EndDate + "'");

            DataTable dt;
            //long l = this.objReport.m_lngRptDragUsedStat(CodeNo, BeginDate, EndDate, DeptIDArr, out dt);
            long l = this.objReport.m_lngRptDragUsedStat(CodeNo, BeginDate + " 00:00:00", EndDate + " 23:59:59", DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }
                dwRep.Sort();
                dwRep.CalculateGroups();

                dwRep.SetRedrawOn();
                dwRep.Refresh();
            }
        }
        #endregion

        #region 顺德门诊普通医保、住院医保费用明细统计
        /// <summary>
        /// 顺德门诊普通医保、住院医保费用明细统计
        /// </summary>
        /// <param name="Type">1 门诊 2 住院</param>
        /// <param name="NO"></param>
        /// <param name="dwRep"></param>
        /// <param name="dt"></param>
        public void m_mthRptSDYB(int Type, string NO, DataWindowControl dwRep, out DataTable dt)
        {
            dt = new DataTable();

            long l = this.objReport.m_lngRptSDYBFeeDetail(Type, NO, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int row = dwRep.InsertRow(0);
                    DataRow dr = dt.Rows[i];

                    dwRep.SetItemString(row, "colzlbh", dr["zlbh"].ToString());
                    dwRep.SetItemString(row, "colxmbh", dr["xmbh"].ToString());
                    dwRep.SetItemString(row, "colfldm", dr["fldm"].ToString());
                    dwRep.SetItemString(row, "colzlfs", dr["zlfs"].ToString());
                    dwRep.SetItemString(row, "colzlxm", dr["zlxm"].ToString());
                    dwRep.SetItemString(row, "colxmlx", dr["xmlx"].ToString());
                    dwRep.SetItemDecimal(row, "colxmjg", clsPublic.ConvertObjToDecimal(dr["xmjg"]));
                    dwRep.SetItemDecimal(row, "colxmsl", clsPublic.ConvertObjToDecimal(dr["xmsl"]));
                    dwRep.SetItemDecimal(row, "colzlfy", clsPublic.ConvertObjToDecimal(dr["zlfy"]));
                    dwRep.SetItemString(row, "colkssj", dr["kssj"].ToString());
                    dwRep.SetItemString(row, "coljssj", dr["jssj"].ToString());
                    dwRep.SetItemString(row, "colxm", dr["xm"].ToString());
                    dwRep.SetItemDecimal(row, "colzycs", clsPublic.ConvertObjToDecimal(dr["zycs"]));
                    dwRep.SetItemDecimal(row, "coljscs", clsPublic.ConvertObjToDecimal(dr["jscs"]));
                }
            }
        }

        /// <summary>
        /// 上传费用数据
        /// </summary>        
        /// <param name="NO"></param>
        /// <param name="dt"></param>
        public void m_mthUpLoad_SDYB(string NO, DataTable dt)
        {
            long l = this.objReport.m_lngSDZYYB(this.SQLParm, NO, dt);
            if (l > 0)
            {
                MessageBox.Show("费用数据上传成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("数据上传失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新住院号
        /// </summary>
        /// <param name="OldNo">旧号</param>
        /// <param name="NewNo">新号</param>
        public void m_mthModifyZyh_SDYB(string OldNo, string NewNo)
        {
            long l = this.objReport.m_lngSDYBModifyZyh(this.SQLParm, OldNo, NewNo);
            if (l > 0)
            {

            }
            else
            {
                MessageBox.Show("医保病人住院号失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 入院登记新增病人记录(顺德医保)
        /// </summary>
        /// <param name="Patient_VO"></param>
        /// <param name="Register_VO"></param>
        public void m_mthBihRegister_SDYB(clsPatient_VO Patient_VO, clsT_Opr_Bih_Register_VO Register_VO)
        {
            long l = this.objReport.m_lngSDYBBihRegister(this.SQLParm, Patient_VO, Register_VO);
            if (l > 0)
            {

            }
            else
            {
                MessageBox.Show("登记医保病人资料失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 住院病人阶段费用一览表
        /// <summary>
        /// 住院病人阶段费用一览表
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptPatientSum(string AreaID, DataWindowControl dwRep)
        {
            #region 两层
            string SubStr = "";
            if (AreaID != "00")
            {
                SubStr = " and a.areaid_chr = '" + AreaID + "' ";
            }

            string SQL = @"select  a.areaid_chr, a.inpatientid_chr, c.code_chr, b.lastname_vchr,
                                 tb.totalmoney, tc.clearmoney, ta.premoney,
                                 (nvl(ta.premoney,0) + nvl(tc.clearmoney,0) - nvl(tb.totalmoney,0)) as balancemoney,
                                 td.calccateid_chr, td.catname, td.catmoney
                            from t_opr_bih_register a,
                                 t_opr_bih_registerdetail b,
                                 t_bse_bed c,
                                 (select   a.registerid_chr, nvl (sum (b.money_dec), 0) as premoney
                                      from t_opr_bih_register a, t_opr_bih_prepay b
                                     where a.registerid_chr = b.registerid_chr
                                       and a.status_int = 1 
                                       and a.pstatus_int <> 3
                                       and b.status_int = 1
                                       and b.isclear_int = 0 " + SubStr + @" 
                                  group by a.registerid_chr) ta,
                                 (select   a.registerid_chr,
                                           sum (round (b.amount_dec * b.unitprice_dec, 2)
                                               ) as totalmoney
                                      from t_opr_bih_register a, t_opr_bih_patientcharge b
                                     where a.registerid_chr = b.registerid_chr
                                       and a.status_int = 1 
                                       and a.pstatus_int <> 3
                                       and b.status_int = 1 
                                       and b.chargeactive_dat is not null
                                       and b.pstatus_int <> 0 " + SubStr + @" 
                                  group by a.registerid_chr) tb,
                                 (select   a.registerid_chr,
                                           sum (round (b.amount_dec * b.unitprice_dec, 2)
                                               ) as clearmoney
                                      from t_opr_bih_register a, t_opr_bih_patientcharge b
                                     where a.registerid_chr = b.registerid_chr
                                       and a.status_int = 1  
                                       and a.pstatus_int <> 3
                                       and b.status_int = 1 
                                       and b.chargeactive_dat is not null 
                                       and (b.pstatus_int = 3 or b.pstatus_int = 4) " + SubStr + @" 
                                  group by a.registerid_chr) tc,
                                 (select   a.registerid_chr, b.calccateid_chr,
                                           nvl (c.typename_vchr, '不存在') AS catname,
                                           sum (round (b.amount_dec * b.unitprice_dec, 2))
                                                                                          as catmoney
                                      from t_opr_bih_register a,
                                           t_opr_bih_patientcharge b,
                                           (select typeid_chr, typename_vchr
                                              from t_bse_chargeitemextype
                                             where flag_int = 3) c
                                     where a.registerid_chr = b.registerid_chr
                                       and b.calccateid_chr = c.typeid_chr(+)
                                       and a.status_int = 1  
                                       and a.pstatus_int <> 3
                                       and b.status_int = 1 
                                       and b.chargeactive_dat is not null 
                                       and b.pstatus_int <> 0 " + SubStr + @" 
                                  group by a.registerid_chr, b.calccateid_chr, c.typename_vchr) td
                           where a.registerid_chr = b.registerid_chr
                             and a.bedid_chr = c.bedid_chr(+)
                             and a.status_int = 1 
                             and a.pstatus_int <> 3
                             and a.registerid_chr = ta.registerid_chr(+)
                             and a.registerid_chr = tb.registerid_chr(+)
                             and a.registerid_chr = tc.registerid_chr(+)
                             and a.registerid_chr = td.registerid_chr(+) " + SubStr + @" 
                        order by a.areaid_chr, c.code_chr";

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog("住院病人阶段费用", SQL);
            #endregion

            #region 三层
            #endregion
        }
        #endregion

        #region 住院医生绩效统计报表
        /// <summary>
        /// 住院医生绩效统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="EmpName"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="MedCatArr"></param>
        /// <param name="FeeType"></param>
        /// <param name="dwRep"></param>
        /// <param name="RptID"></param>
        /// <param name="p_objGroup"></param>
        public void m_mthRptDoctorPerformance(string BeginDate, string EndDate, string EmpName, string DoctIDArr, string MedCatArr, string KangJunArr, string JiBenArr, int FeeType,
                                              DataWindowControl dwRep, string RptID, Dictionary<string, decimal> p_objGroup)
        {
            dwRep.Modify("t_date.text = '" + BeginDate + " ~ " + EndDate + "'");
            dwRep.Modify("t_opername.text = '" + EmpName + "'");

            dwRep.SetRedrawOff();
            dwRep.Reset();

            long l = 0;
            DataTable dtDoct, dtDept, dtPersonNums, dtBedDays, dtFeeSum, dtMedSum, dtNonMedSum, dtAntiseptic, dtEssential;//, dtWesternMedicinetotal;
            Dictionary<string, decimal> m_objResult = null;

            //l = this.objReport.m_lngRptDoctorPerformance(BeginDate, EndDate, DoctIDArr, MedCatArr, out dtDoct, out dtDept, out dtPersonNums, out dtBedDays, out dtFeeSum, out dtMedSum, out dtNonMedSum);
            //1、基本资料
            l = this.objReport.m_lngRptDoctorPerformance_Doct(BeginDate, EndDate, DoctIDArr, FeeType, out dtDoct);
            //2、默认科室
            l = this.objReport.m_lngRptDoctorPerformance_Dept(BeginDate, EndDate, DoctIDArr, out dtDept);
            //3、收住人次
            l = this.objReport.m_lngRptDoctorPerformance_PersonNums(BeginDate, EndDate, DoctIDArr, out dtPersonNums);
            //4、出院人次 占床总日数
            l = this.objReport.m_lngRptDoctorPerformance_BedDays(BeginDate, EndDate, DoctIDArr, out dtBedDays);
            //5、出院者(含预出院)总费用
            l = this.objReport.m_lngRptDoctorPerformance_FeeSum(BeginDate, EndDate, DoctIDArr, FeeType, out dtFeeSum);
            //6、出院者(含预出院)药费
            l = this.objReport.m_lngRptDoctorPerformance_MedSum(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtMedSum);
            //7、出院者(含预出院)非药费
            l = this.objReport.m_lngRptDoctorPerformance_NonMedSum(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtNonMedSum);
            //8、绩效
            l = this.objReport.m_lngRptDoctorPerformance_Effects(BeginDate, EndDate, DoctIDArr, FeeType, RptID, p_objGroup, out m_objResult);
            //9、抗菌药品比例
            l = this.objReport.m_lngRptDoctorPerformance_Antiseptic(BeginDate, EndDate, DoctIDArr, KangJunArr, FeeType, out dtAntiseptic);
            //10、基本药品比例
            l = this.objReport.m_lngRptDoctorPerformance_Essential(BeginDate, EndDate, DoctIDArr, JiBenArr, FeeType, out dtEssential);
            if (l > 0)
            {
                DataView dvDept = new DataView(dtDept);
                DataView dvPersonNums = new DataView(dtPersonNums);
                DataView dvBedDays = new DataView(dtBedDays);
                DataView dvFeeSum = new DataView(dtFeeSum);
                DataView dvMedSum = new DataView(dtMedSum);
                DataView dvNonMedSum = new DataView(dtNonMedSum);
                DataView dvAntiseptic = new DataView(dtAntiseptic);
                DataView dvEssential = new DataView(dtEssential);
                // DataView dvWMedicinetotal = new DataView(dtWesternMedicinetotal);//西药费用

                string DoctID = "";
                for (int i = 0; i < dtDoct.Rows.Count; i++)
                {
                    DataRow drDoct = dtDoct.Rows[i];

                    DoctID = drDoct["doctid"].ToString();
                    string DeptName = "";
                    decimal InPersonNums = 0;
                    decimal OutPersonNums = 0;
                    decimal Days = 0;
                    decimal DayFee = 0;
                    decimal FeeSum = 0;
                    decimal MedFee = 0;
                    decimal NonMedFee = 0;

                    //科室
                    dvDept.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvDept.Count > 0)
                    {
                        DeptName = dvDept[0]["deptname_vchr"].ToString().Trim();
                    }

                    //收入院人次
                    dvPersonNums.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvPersonNums.Count == 1)
                    {
                        InPersonNums = clsPublic.ConvertObjToDecimal(dvPersonNums[0]["inpersonnums"]);
                    }

                    //出院人次 占床总日数
                    dvBedDays.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvBedDays.Count == 1)
                    {
                        OutPersonNums = clsPublic.ConvertObjToDecimal(dvBedDays[0]["outpersonnums"]);
                        Days = clsPublic.ConvertObjToDecimal(dvBedDays[0]["days"]);
                    }

                    //出院者发生总费用
                    dvFeeSum.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvFeeSum.Count == 1)
                    {
                        FeeSum = clsPublic.ConvertObjToDecimal(dvFeeSum[0]["totalsum"]);
                    }

                    //床日费用                    
                    if (Days != 0)
                    {
                        DayFee = clsPublic.Round(FeeSum / Days, 2);
                    }

                    //药品金额
                    dvMedSum.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvMedSum.Count == 1)
                    {
                        MedFee = clsPublic.ConvertObjToDecimal(dvMedSum[0]["totalsum"]);
                    }

                    //非药品金额
                    dvNonMedSum.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvNonMedSum.Count == 1)
                    {
                        NonMedFee = clsPublic.ConvertObjToDecimal(dvNonMedSum[0]["totalsum"]);
                    }

                    //药费＋医疗收入
                    decimal TotalFee = MedFee + NonMedFee;

                    //药品比例
                    decimal MedScale = 0;
                    if (TotalFee != 0)
                    {
                        MedScale = clsPublic.Round((MedFee / TotalFee) * 100, 2);
                    }
                    // 抗菌比例
                    decimal KJScale = 0;
                    dvAntiseptic.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvAntiseptic.Count == 1)
                    {
                        KJScale = clsPublic.ConvertObjToDecimal(dvAntiseptic[0]["kjyb"]);
                    }
                    // 基本比例
                    decimal JBScale = 0;
                    dvEssential.RowFilter = "doctid = '" + DoctID + "'";
                    if (dvEssential.Count == 1)
                    {
                        JBScale = clsPublic.ConvertObjToDecimal(dvEssential[0]["jbyb"]);
                    }


                    int row = dwRep.InsertRow(0);
                    dwRep.SetItemString(row, "gh", drDoct["empno_chr"].ToString().Trim());
                    dwRep.SetItemString(row, "xm", drDoct["lastname_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "ks", DeptName);
                    dwRep.SetItemDecimal(row, "sryrc", InPersonNums);
                    dwRep.SetItemDecimal(row, "cyrc", OutPersonNums);
                    dwRep.SetItemDecimal(row, "cyzzczrs", Days);
                    dwRep.SetItemDecimal(row, "cyzfszfy", FeeSum);
                    dwRep.SetItemDecimal(row, "crfy", DayFee);
                    dwRep.SetItemDecimal(row, "ypje", MedFee);
                    dwRep.SetItemDecimal(row, "ylsr", NonMedFee);
                    dwRep.SetItemString(row, "ypbl", MedScale + "%");
                    dwRep.SetItemString(row, "kjybl", KJScale + "%");
                    dwRep.SetItemString(row, "jbybl", JBScale + "%");
                    dwRep.SetItemDecimal(row, "hjje", TotalFee);
                    if (m_objResult.ContainsKey(DoctID))
                    {
                        dwRep.SetItemDecimal(row, "jx", m_objResult[DoctID]);
                    }
                }
                decimal dclWesternMedicinetotal = 0;
                decimal dclAntispetictotal = 0;
                for (int i = 0; i < dtAntiseptic.Rows.Count; i++)
                {
                    DataRow dr = dtAntiseptic.Rows[i];
                    dclAntispetictotal += clsPublic.ConvertObjToDecimal(dr["kjytotalmoney_dec"]);
                    dclWesternMedicinetotal += clsPublic.ConvertObjToDecimal(dr["xytotalmoney_dec"]);
                }


                if (dclWesternMedicinetotal > 0)
                {
                    decimal dclkjybl = clsPublic.Round((dclAntispetictotal / dclWesternMedicinetotal) * 100, 2);
                    dwRep.Modify("t_kjybl.text = '" + dclkjybl + "%" + "'");
                }
                else
                {
                    dwRep.Modify("t_kjybl.text = '" + "0.00%" + "'");
                }
                dwRep.SetRedrawOn();
                dwRep.Sort();
                dwRep.Refresh();
            }
        }
        #endregion

        #region 住院结算方式汇总报表
        /// <summary>
        /// 住院结算方式汇总报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RepType"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptChargeRecSum(string BeginDate, string EndDate, int RepType, DataWindowControl dwRep)
        {
            try
            {
                DataTable dtMain, dtDet;
                long l = this.objReport.m_lngRptIncomeClass(BeginDate, EndDate, 0, 0, out dtMain, out dtDet);
                if (l > 0)
                {
                    dwRep.SetRedrawOff();
                    dwRep.Reset();
                    dwRep.Modify("t_date.text = '" + BeginDate + "～" + EndDate + "'");

                    if (dtMain.Rows.Count == 0)
                    {
                        dwRep.InsertRow(0);
                        dwRep.SetRedrawOn();
                        dwRep.Refresh();
                        return;
                    }

                    decimal yj = 0;
                    decimal xj = 0;
                    decimal yhk = 0;
                    decimal zp = 0;
                    decimal qt1 = 0;

                    decimal yb = 0;
                    decimal gf = 0;
                    decimal tk = 0;
                    decimal qt2 = 0;

                    for (int i = 0; i < dtMain.Rows.Count; i++)
                    {
                        DataRow dr = dtMain.Rows[i];

                        switch (dr["paytype"].ToString())
                        {
                            case "#0":
                                yj += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "#1":
                                xj += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "#2":
                                zp += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "#3":
                                yhk += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "#4":
                                qt1 += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "&1":
                                gf += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "&2":
                                yb += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            case "&3":
                                tk += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                            default:
                                qt2 += clsPublic.ConvertObjToDecimal(dr["paysum"]);
                                break;
                        }
                    }

                    decimal zje = yj + xj + zp + yhk + qt1 + yb + gf + tk + qt2;

                    #region 绘制报表

                    int row = dwRep.InsertRow(0);
                    dwRep.SetItemDecimal(row, "col1", zje);
                    dwRep.SetItemDecimal(row, "col2", xj);
                    dwRep.SetItemDecimal(row, "col3", zp);
                    dwRep.SetItemDecimal(row, "col4", yhk);
                    dwRep.SetItemDecimal(row, "col5", qt1);
                    dwRep.SetItemDecimal(row, "col6", yb);
                    dwRep.SetItemDecimal(row, "col7", gf);
                    dwRep.SetItemDecimal(row, "col8", tk);
                    dwRep.SetItemDecimal(row, "col9", qt2);
                    dwRep.SetItemDecimal(row, "col10", yj);

                    dwRep.SetRedrawOn();
                    dwRep.Refresh();

                    #endregion
                }

                clsPublic.CloseAvi();
            }
            catch (Exception ex)
            {
                dwRep.SetRedrawOn();
                dwRep.Refresh();
                clsPublic.CloseAvi();
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 住院医生按科室分组实收统计报表
        /// <summary>
        /// 住院医生按科室分组实收统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RptType"></param>
        /// <param name="RptID"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptDeptDoctor(string BeginDate, string EndDate, int RptType, string RptID, string DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SQL = "", SubStr = "", LogTitle = "";
            if (DeptIDArr.Trim() != "")
            {
                SubStr = " and b.createarea_chr in (" + DeptIDArr + ")";
            }

            if (RptType == 0)
            {
                LogTitle = "住院医生按科室分组业务收入";
                SQL = @"select   ta.deptid_chr as deptid, tc.deptname_vchr as deptname,
                                 td.empno_chr as doctno, td.lastname_vchr as doctname,
                                 tb.groupid_chr as groupid,
                                 nvl (tb.groupname_chr, '未定义') as groupname,
                                 sum (ta.totalsum) as cattotalsum
                            from (select   b.createarea_chr as deptid_chr,
                                           b.chargedoctorid_chr as doctid_chr, b.calccateid_chr,
                                           sum (round (b.amount_dec * b.unitprice_dec, 2)) as totalsum
                                      from t_opr_bih_patientcharge b
                                     where b.status_int = 1
                                       and b.pstatus_int <> 0
                                       and (b.chargeactive_dat between to_date('" + BeginDate + @" 00:00:00',
                                                                               'yyyy-mm-dd hh24:mi:ss'
                                                                              )
                                                                   and to_date('" + EndDate + @" 23:59:59',                                                                            
                                                                               'yyyy-mm-dd hh24:mi:ss'
                                                                              )
                                           ) " + SubStr + @" 
                                  group by b.createarea_chr, b.chargedoctorid_chr, b.calccateid_chr) ta,
                                 (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                    from t_aid_rpt_def a, t_aid_rpt_gop_def b, t_aid_rpt_gop_rla c
                                   where a.rptid_chr = '" + RptID + @"'
                                     and a.rptid_chr = b.rptid_chr
                                     and b.rptid_chr = c.rptid_chr
                                     and b.groupid_chr = c.groupid_chr(+)) tb,
                                 t_bse_deptdesc tc,
                                 t_bse_employee td
                           where ta.calccateid_chr = tb.typeid_chr(+) and ta.deptid_chr = tc.deptid_chr(+)
                                 and ta.doctid_chr = td.empid_chr(+)
                        group by ta.deptid_chr,
                                 tc.deptname_vchr,
                                 td.empno_chr,
                                 td.lastname_vchr,
                                 tb.groupid_chr,
                                 tb.groupname_chr";

            }
            else if (RptType == 1)
            {
                LogTitle = "住院医生按科室分组实收(按发票时间)";
                SQL = @"select   ta.deptid_chr as deptid, tc.deptname_vchr as deptname,
                                 td.empno_chr as doctno, td.lastname_vchr as doctname,
                                 tb.groupid_chr as groupid,
                                 nvl (tb.groupname_chr, '未定义') as groupname,
                                 sum (ta.totalsum) as cattotalsum
                            from (select   b.createarea_chr as deptid_chr,
                                           b.chargedoctorid_chr as doctid_chr, b.calccateid_chr,
                                           sum (b.totalmoney_dec) as totalsum
                                      from t_opr_bih_chargeitementry b, t_opr_bih_charge a
                                     where a.chargeno_chr = b.chargeno_chr
                                       and a.status_int = 1             
                                       and (a.operdate_dat between to_date('" + BeginDate + @" 00:00:00',
                                                                               'yyyy-mm-dd hh24:mi:ss'
                                                                              )
                                                                   and to_date('" + EndDate + @" 23:59:59',                                                                            
                                                                               'yyyy-mm-dd hh24:mi:ss'
                                                                              )
                                           ) " + SubStr + @" 
                                  group by b.createarea_chr, b.chargedoctorid_chr, b.calccateid_chr) ta,
                                 (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                    from t_aid_rpt_def a, t_aid_rpt_gop_def b, t_aid_rpt_gop_rla c
                                   where a.rptid_chr = '" + RptID + @"'
                                     and a.rptid_chr = b.rptid_chr
                                     and b.rptid_chr = c.rptid_chr
                                     and b.groupid_chr = c.groupid_chr(+)) tb,
                                 t_bse_deptdesc tc,
                                 t_bse_employee td
                           where ta.calccateid_chr = tb.typeid_chr(+) and ta.deptid_chr = tc.deptid_chr(+)
                                 and ta.doctid_chr = td.empid_chr(+)
                        group by ta.deptid_chr,
                                 tc.deptname_vchr,
                                 td.empno_chr,
                                 td.lastname_vchr,
                                 tb.groupid_chr,
                                 tb.groupname_chr";
            }
            else if (RptType == 91)
            {
                LogTitle = "住院医生按科室分组实收(按日结时间)";
                SQL = @"select   ta.deptid_chr as deptid, tc.deptname_vchr as deptname,
                                 td.empno_chr as doctno, td.lastname_vchr as doctname,
                                 tb.groupid_chr as groupid,
                                 nvl (tb.groupname_chr, '未定义') as groupname,
                                 sum (ta.totalsum) as cattotalsum
                            from (select   b.createarea_chr as deptid_chr,
                                           b.chargedoctorid_chr as doctid_chr, b.calccateid_chr,
                                           sum (b.totalmoney_dec) as totalsum
                                      from t_opr_bih_chargeitementry b, t_opr_bih_charge a
                                     where a.chargeno_chr = b.chargeno_chr
                                       and a.status_int = 1  
                                       and a.recflag_int = 1            
                                       and (a.recdate_dat between to_date('" + BeginDate + @" 00:00:00',
                                                                               'yyyy-mm-dd hh24:mi:ss'
                                                                              )
                                                                   and to_date('" + EndDate + @" 23:59:59',                                                                            
                                                                               'yyyy-mm-dd hh24:mi:ss'
                                                                              )
                                           ) " + SubStr + @" 
                                  group by b.createarea_chr, b.chargedoctorid_chr, b.calccateid_chr) ta,
                                 (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                    from t_aid_rpt_def a, t_aid_rpt_gop_def b, t_aid_rpt_gop_rla c
                                   where a.rptid_chr = '" + RptID + @"'
                                     and a.rptid_chr = b.rptid_chr
                                     and b.rptid_chr = c.rptid_chr
                                     and b.groupid_chr = c.groupid_chr(+)) tb,
                                 t_bse_deptdesc tc,
                                 t_bse_employee td
                           where ta.calccateid_chr = tb.typeid_chr(+) and ta.deptid_chr = tc.deptid_chr(+)
                                 and ta.doctid_chr = td.empid_chr(+)
                        group by ta.deptid_chr,
                                 tc.deptname_vchr,
                                 td.empno_chr,
                                 td.lastname_vchr,
                                 tb.groupid_chr,
                                 tb.groupname_chr";
            }

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Sort();
            dwRep.CalculateGroups();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, SQL);
            #endregion
        }
        #endregion

        #region 呆帐病人欠费统计报表
        /// <summary>
        /// 呆帐病人欠费统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RptID"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptBadCharge(string BeginDate, string EndDate, string RptID, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            string SQL = "", SubStr = "";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";
                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "ta.deptid = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            SQL = @"select   ta.deptid as deptid, tc.deptname_vchr as deptname,
                             tb.groupid_chr as groupid,
                             nvl (tb.groupname_chr, '未定义') as groupname,
                             sum (ta.totalsum) as cattotalsum
                        from (select ta.curareaid_chr as deptid, ta.calccateid_chr,
                                     ta.pchargeid_chr,
                                     (ta.totalsum - nvl(tb.totalmoney_dec, 0)) as totalsum
                                from (select a.curareaid_chr, a.calccateid_chr, a.pchargeid_chr,
                                             round (a.amount_dec * a.unitprice_dec,
                                                    2) as totalsum
                                        from t_opr_bih_patientcharge a
                                       where a.status_int = 1
                                         and (a.pstatus_int = 1 or a.pstatus_int = 2)
                                         and a.chargeactive_dat is not null
                                         and a.registerid_chr in (
                                                select a.registerid_chr
                                                  from t_opr_bih_register a, t_opr_bih_leave b
                                                 where a.registerid_chr = b.registerid_chr
                                                   and a.pstatus_int = 3
                                                   and a.feestatus_int = 4
                                                   and b.status_int = 1
                                                   and (b.modify_dat
                                                           between to_date
                                                                          ('" + BeginDate + @" 00:00:00',
                                                                           'yyyy-mm-dd hh24:mi:ss'
                                                                          )
                                                               and to_date
                                                                          ('" + EndDate + @" 23:59:59',
                                                                           'yyyy-mm-dd hh24:mi:ss'
                                                                          )
                                                       ))) ta,
                                     (select a.pchargeid_chr, a.totalmoney_dec
                                        from t_opr_bih_chargeitementry a
                                       where a.registerid_chr in (
                                                select a.registerid_chr
                                                  from t_opr_bih_register a, t_opr_bih_leave b
                                                 where a.registerid_chr = b.registerid_chr
                                                   and a.pstatus_int = 3
                                                   and a.feestatus_int = 4
                                                   and b.status_int = 1
                                                   and (b.modify_dat
                                                           between to_date
                                                                          ('" + BeginDate + @" 00:00:00',
                                                                           'yyyy-mm-dd hh24:mi:ss'
                                                                          )
                                                               and to_date
                                                                          ('" + EndDate + @" 23:59:59',
                                                                           'yyyy-mm-dd hh24:mi:ss'
                                                                          )
                                                       ))) tb
                               where ta.pchargeid_chr = tb.pchargeid_chr(+)) ta,
                             (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                from t_aid_rpt_def a, t_aid_rpt_gop_def b, t_aid_rpt_gop_rla c
                               where a.rptid_chr = '" + RptID + @"'
                                 and a.rptid_chr = b.rptid_chr
                                 and b.rptid_chr = c.rptid_chr
                                 and b.groupid_chr = c.groupid_chr(+)) tb,
                             t_bse_deptdesc tc
                       where ta.calccateid_chr = tb.typeid_chr(+) and ta.deptid = tc.deptid_chr(+) " + SubStr + @" 
                    group by ta.deptid, tc.deptname_vchr, tb.groupid_chr, tb.groupname_chr
                    order by ta.deptid";

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.CalculateGroups();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog("呆帐病人欠费统计报表", SQL);
        }
        #endregion

        #region 收费组汇总报表(伦教门诊)
        /// <summary>
        /// 收费组汇总报表(伦教门诊)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptChargeGroup_LJ(string BeginDate, string EndDate, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            #region 两层
            string SQL = @" select   e.groupname_vchr as deptname_vchr, i.typename_vchr,
                                     sum (b.tolfee_mny) as totalsum
                                from t_opr_outpatientrecipeinv a,
                                     t_opr_outpatientrecipesumde b,
                                     t_bse_groupdesc e,
                                     t_bse_groupemp f,
                                     (select typeid_chr, typename_vchr
                                        from t_bse_chargeitemextype
                                       where flag_int = 1) i
                               where a.invoiceno_vchr = b.invoiceno_vchr
                                 and a.seqid_chr = b.seqid_chr
                                 and a.balanceflag_int = 1
                                 and (a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                                        and to_date ('" + EndDate + @" 23:59:59',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                     )
                                 and a.balanceemp_chr = f.empid_chr
                                 and e.groupid_chr = f.groupid_chr　
                                 and e.groupid_chr <> '0024'
                                 and b.itemcatid_chr = i.typeid_chr(+)
                            group by e.groupname_vchr, i.typeid_chr, i.typename_vchr
                            union all
                            select   e.groupname_vchr as deptname_vchr, i.typename_vchr,
                                     sum (b.tolfee_mny) as totalsum
                                from t_opr_outpatientrecipeinv a,
                                     t_opr_outpatientrecipesumde b,
                                     t_bse_groupdesc e,
                                     t_bse_groupemp f,
                                     (select typeid_chr, typename_vchr
                                        from t_bse_chargeitemextype
                                       where flag_int = 1) i
                               where a.invoiceno_vchr = b.invoiceno_vchr
                                 and a.seqid_chr = b.seqid_chr
                                 and a.balanceflag_int = 1
                                 and (a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                                        and to_date ('" + EndDate + @" 23:59:59',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                     )
                                 and a.doctorid_chr = f.empid_chr(+)
                                 and e.groupid_chr = f.groupid_chr　
                                 and b.itemcatid_chr = i.typeid_chr(+)
                                 and exists (
                                           select 1
                                             from t_bse_groupemp g
                                            where g.groupid_chr = '0024'
                                                  and g.empid_chr = a.balanceemp_chr)
                            group by e.groupname_vchr, i.typeid_chr, i.typename_vchr";

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Sort();
            dwRep.CalculateGroups();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog("收费组汇总报表(伦教门诊)", SQL);
            #endregion
        }
        #endregion

        #region 全院(门诊、住院)各核算单位实收报表
        /// <summary>
        /// 全院(门诊、住院)各核算单位实收报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="Type"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptAllDeptIncome(string BeginDate, string EndDate, int Type, DataWindowControl dwRep)
        {
            DataTable dtGroup, dtRecNums, dtMz, dtZy;

            long l = this.objReport.m_lngRptAllDeptIncome(BeginDate, EndDate, Type, out dtGroup, out dtRecNums, out dtMz, out dtZy);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Reset();
                dwRep.Modify("t_date.text = '" + BeginDate + "～" + EndDate + "'");

                string GroupID = "";
                string GroupName = "";
                decimal RecNums = 0;
                decimal MzSum = 0;
                decimal ZySum = 0;

                Hashtable hasRecNums = new Hashtable();
                for (int i = 0; i < dtRecNums.Rows.Count; i++)
                {
                    if (dtRecNums.Rows[i]["groupid_chr"].ToString().Trim() == "")
                    {
                        GroupID = "AAA";
                    }
                    else
                    {
                        GroupID = dtRecNums.Rows[i]["groupid_chr"].ToString();
                    }

                    hasRecNums.Add(GroupID, dtRecNums.Rows[i]["recnums"].ToString());
                }

                Hashtable hasMz = new Hashtable();
                for (int i = 0; i < dtMz.Rows.Count; i++)
                {
                    if (dtMz.Rows[i]["groupid_chr"].ToString().Trim() == "")
                    {
                        GroupID = "AAA";
                    }
                    else
                    {
                        GroupID = dtMz.Rows[i]["groupid_chr"].ToString();
                    }

                    hasMz.Add(GroupID, dtMz.Rows[i]["totalsum"].ToString());
                }

                Hashtable hasZy = new Hashtable();
                for (int i = 0; i < dtZy.Rows.Count; i++)
                {
                    if (dtZy.Rows[i]["groupid_chr"].ToString().Trim() == "")
                    {
                        GroupID = "AAA";
                    }
                    else
                    {
                        GroupID = dtZy.Rows[i]["groupid_chr"].ToString();
                    }

                    hasZy.Add(GroupID, dtZy.Rows[i]["totalsum"].ToString());
                }

                for (int i = 0; i < dtGroup.Rows.Count; i++)
                {
                    DataRow dr = dtGroup.Rows[i];

                    GroupID = dr["groupid_chr"].ToString();
                    GroupName = dr["groupname_vchr"].ToString();
                    RecNums = 0;
                    MzSum = 0;
                    ZySum = 0;

                    if (hasMz.ContainsKey(GroupID))
                    {
                        MzSum = clsPublic.ConvertObjToDecimal(hasMz[GroupID].ToString());
                        hasMz.Remove(GroupID);
                    }

                    if (hasRecNums.ContainsKey(GroupID))
                    {
                        RecNums = clsPublic.ConvertObjToDecimal(hasRecNums[GroupID].ToString());
                        hasRecNums.Remove(GroupID);
                    }

                    if (hasZy.ContainsKey(GroupID))
                    {
                        ZySum = clsPublic.ConvertObjToDecimal(hasZy[GroupID].ToString());
                        hasZy.Remove(GroupID);
                    }

                    if (MzSum > 0 || ZySum > 0)
                    {
                        int row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "zyzmc", GroupName);
                        dwRep.SetItemDecimal(row, "cfs", RecNums);
                        dwRep.SetItemDecimal(row, "mzsr", MzSum);
                        dwRep.SetItemDecimal(row, "zysr", ZySum);
                        dwRep.SetItemDecimal(row, "zsr", MzSum + ZySum);
                    }
                }

                if (hasMz.Count > 0)
                {
                    ArrayList MzArr = new ArrayList();
                    MzArr.AddRange(hasMz.Keys);

                    for (int k = 0; k < MzArr.Count; k++)
                    {
                        GroupID = MzArr[k].ToString();
                        MzSum = clsPublic.ConvertObjToDecimal(hasMz[GroupID].ToString());
                        RecNums = clsPublic.ConvertObjToDecimal(hasRecNums[GroupID].ToString());
                        ZySum = 0;

                        if (hasZy.ContainsKey(GroupID))
                        {
                            ZySum = clsPublic.ConvertObjToDecimal(hasZy[GroupID].ToString());
                            hasZy.Remove(GroupID);
                        }

                        int row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "zyzmc", "<未定义>");
                        dwRep.SetItemDecimal(row, "cfs", RecNums);
                        dwRep.SetItemDecimal(row, "mzsr", MzSum);
                        dwRep.SetItemDecimal(row, "zysr", ZySum);
                        dwRep.SetItemDecimal(row, "zsr", MzSum + ZySum);
                    }
                }

                if (hasZy.Count > 0)
                {
                    ArrayList ZyArr = new ArrayList();
                    ZyArr.AddRange(hasZy.Keys);

                    for (int k = 0; k < ZyArr.Count; k++)
                    {
                        ZySum = clsPublic.ConvertObjToDecimal(hasZy[GroupID].ToString());

                        int row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "zyzmc", "<未定义>");
                        dwRep.SetItemDecimal(row, "cfs", 0);
                        dwRep.SetItemDecimal(row, "mzsr", 0);
                        dwRep.SetItemDecimal(row, "zysr", ZySum);
                        dwRep.SetItemDecimal(row, "zsr", ZySum);
                    }
                }

                dwRep.SetRedrawOn();
                dwRep.Refresh();
            }
        }
        #endregion

        #region 收款员缴款报表
        /// <summary>
        /// 收款员缴款报表
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="EmpName"></param>
        /// <param name="IsRec"></param>
        /// <param name="RecTime"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptReckoningEmpUnion(string EmpID, string EmpName, bool IsRec, string RecTime, Hashtable hasRecDate1, Hashtable hasRecDate2, DataWindowControl dwRep)
        {
            DataTable dtCharge;
            DataTable dtInvoice;
            DataTable dtPayment;
            DataTable dtPrepayChargeNo;
            string RemarkInfo1 = "";

            DataTable dtPrepay;
            DataTable dtPrepayRepNo;
            string RemarkInfo2 = "";

            try
            {
                long l1 = this.objReport.m_lngRptReckoningEmp(EmpID, IsRec, RecTime, out dtCharge, out dtInvoice, out dtPayment, out dtPrepayChargeNo, out RemarkInfo1);
                long l2 = this.objReport.m_lngRptReckoningEmpPre(EmpID, IsRec, RecTime, out dtPrepay, out dtPrepayRepNo, out RemarkInfo2);
                if (l1 > 0 && l2 > 0)
                {
                    dwRep.SetRedrawOff();
                    dwRep.Reset();
                    dwRep.InsertRow(0);

                    #region 发票
                    #region 票数、费用
                    DataView dv = new DataView(dtCharge);

                    //实收日期
                    if (IsRec)
                    {
                        dwRep.Modify("t_ssrq.text = '" + RecTime.Substring(0, 10) + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_ssrq.text = ''");
                    }

                    //发票时间
                    dv.Sort = "invotime asc";
                    if (dv.Count > 0)
                    {
                        dwRep.Modify("t_fpsj.text = '" + dv[0]["invotime"].ToString().Trim() + "～" + dv[dv.Count - 1]["invotime"].ToString().Trim() + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fpsj.text = ''");
                    }

                    int kps = 0;
                    int tps = 0;
                    decimal kpje = 0;
                    decimal tpje = 0;
                    decimal hjje = 0;

                    foreach (DataRowView drv in dv)
                    {
                        if (drv["type_int"].ToString() == "1")
                        {
                            kps++;
                            kpje += clsPublic.ConvertObjToDecimal(drv["totalsum_mny"]);
                        }
                        else if (drv["type_int"].ToString() == "2")
                        {
                            tps++;
                            tpje += clsPublic.ConvertObjToDecimal(drv["totalsum_mny"]);
                        }
                        //自付金额
                        hjje += clsPublic.ConvertObjToDecimal(drv["totalsum_mny"]);
                    }

                    //开票数、开票金额
                    if (kps > 0)
                    {
                        dwRep.Modify("t_fp_kps.text = '" + kps.ToString() + "张'");
                        dwRep.Modify("t_fp_kphj.text = '￥" + kpje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_kps.text = ''");
                        dwRep.Modify("t_fp_kphj.text = ''");
                    }

                    //退票数、退票金额
                    if (tps > 0)
                    {
                        dwRep.Modify("t_fp_tps.text = '" + tps.ToString() + "张'");
                        dwRep.Modify("t_fp_tphj.text = '￥" + tpje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_tps.text = ''");
                        dwRep.Modify("t_fp_tphj.text = ''");
                    }

                    //有效票数
                    if (kps - tps > 0)
                    {
                        dwRep.Modify("t_fp_yxps.text = '" + Convert.ToString(kps - tps) + "张'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_yxps.text = ''");
                    }

                    //合计金额                    
                    if (hjje != 0)
                    {
                        dwRep.Modify("t_fp_hjje_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(hjje)) + "'");
                        dwRep.Modify("t_fp_hjje_x.text = '￥" + hjje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_hjje_d.text = ''");
                        dwRep.Modify("t_fp_hjje_x.text = ''");
                    }

                    decimal yjktotal = 0;
                    decimal yjk = 0;
                    decimal xj = 0;
                    decimal zp = 0;
                    decimal yhk = 0;
                    decimal qt = 0;
                    decimal yb = 0;
                    decimal gf = 0;
                    decimal tk = 0;
                    decimal qt2 = 0;

                    for (int i = 0; i < dtPayment.Rows.Count; i++)
                    {
                        if (dtPayment.Rows[i]["paytype"].ToString() == "999")
                        {
                            yjktotal += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#0")
                        {
                            yjk += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#1")
                        {
                            xj += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#2")
                        {
                            zp += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#3")
                        {
                            yhk += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "#4")
                        {
                            qt += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "&2")
                        {
                            yb += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "&1")
                        {
                            gf += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else if (dtPayment.Rows[i]["paytype"].ToString() == "&3")
                        {
                            tk += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                        else
                        {
                            qt2 += clsPublic.ConvertObjToDecimal(dtPayment.Rows[i]["paysum"]);
                        }
                    }

                    //冲预付款
                    if (yjktotal != 0)
                    {
                        dwRep.Modify("t_cyfk_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(yjktotal)) + "'");
                        dwRep.Modify("t_cyfk_x.text = '￥" + yjktotal.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_cyfk_d.text = ''");
                        dwRep.Modify("t_cyfk_x.text = ''");
                    }

                    //应交合计
                    /*这时现金 = 实收现金 - 退预交款*/
                    xj = xj - (yjktotal - yjk);

                    decimal total = xj + zp + yhk + qt + yb + gf + tk + qt2;

                    //现金                                        
                    if (xj != 0)
                    {
                        dwRep.Modify("t_fp_xj.text = '￥" + xj.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_xj.text = ''");
                    }

                    //支票                                        
                    if (zp != 0)
                    {
                        dwRep.Modify("t_fp_zp.text = '￥" + zp.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_zp.text = ''");
                    }

                    //银行卡                                        
                    if (yhk != 0)
                    {
                        dwRep.Modify("t_fp_yhk.text = '￥" + yhk.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_yhk.text = ''");
                    }

                    //(自付)其他                                        
                    if (qt != 0)
                    {
                        dwRep.Modify("t_fp_qt.text = '￥" + qt.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_qt.text = ''");
                    }

                    //医保
                    if (yb != 0)
                    {
                        dwRep.Modify("t_fp_yb.text = '￥" + yb.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_yb.text = ''");
                    }

                    //公费
                    if (gf != 0)
                    {
                        dwRep.Modify("t_fp_gf.text = '￥" + gf.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_gf.text = ''");
                    }

                    //特困
                    if (tk != 0)
                    {
                        dwRep.Modify("t_fp_tk.text = '￥" + tk.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_tk.text = ''");
                    }

                    //(记帐)其他
                    if (qt2 != 0)
                    {
                        dwRep.Modify("t_fp_qt2.text = '￥" + qt2.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_qt2.text = ''");
                    }
                    #endregion

                    #region 票号
                    DataView dvInvoNo = new DataView(dtInvoice);
                    dvInvoNo.Sort = "invono asc";

                    //开票单号
                    dvInvoNo.RowFilter = "empid = '" + EmpID + "' and flag = 1";
                    string kpdh = this.m_strGetPrnInvoNo(dvInvoNo);
                    if (kpdh != "")
                    {
                        dwRep.Modify("t_fp_kpdh.text = '" + kpdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_kpdh.text = ''");
                    }

                    //退票单号
                    dvInvoNo.RowFilter = "empid = '" + EmpID + "' and flag = 2";
                    string tpdh = this.m_strGetPrnInvoNo(dvInvoNo);
                    if (tpdh != "")
                    {
                        dwRep.Modify("t_fp_tpdh.text = '" + tpdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_tpdh.text = ''");
                    }

                    //重打单号
                    dvInvoNo.RowFilter = "empid = '" + EmpID + "' and flag = 999";
                    string cddh = this.m_strGetPrnInvoNo(dvInvoNo);
                    if (cddh != "")
                    {
                        dwRep.Modify("t_fp_cddh.text = '" + cddh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_fp_cddh.text = ''");
                    }

                    //备注
                    string remarkinfo_p = "";
                    clsPublic.m_mthConvertNewLineStrLbl(RemarkInfo1 + RemarkInfo2, 50, ref remarkinfo_p);
                    dwRep.Modify("t_bz.text = '" + remarkinfo_p + "'");

                    //交款人
                    dwRep.Modify("t_jkr.text = '" + EmpName + "'");

                    #endregion
                    #endregion

                    #region 按金
                    #region 票数、金额
                    int aj_kps = 0;
                    int aj_tps = 0;
                    int aj_hfs = 0;
                    decimal aj_kpje = 0;
                    decimal aj_tpje = 0;
                    decimal aj_hfje = 0;
                    decimal aj_hjje = 0;

                    decimal aj_xj = 0;
                    decimal aj_zp = 0;
                    decimal aj_yhk = 0;
                    decimal aj_qt = 0;

                    //开票单号
                    ArrayList kpnoarr = new ArrayList();
                    //退票单号
                    ArrayList tpnoarr = new ArrayList();
                    //恢复单号
                    ArrayList hfnoarr = new ArrayList();
                    //普通单号
                    ArrayList ptnoarr = new ArrayList();
                    //手工单号
                    ArrayList sgnoarr = new ArrayList();

                    #region 冲单信息

                    //冲单单号(正常)
                    ArrayList cdnoarr_zc = new ArrayList();
                    //冲单单号(呆帐)
                    ArrayList cdnoarr_dz = new ArrayList();

                    string PriorTime = "";
                    if (RecTime.Trim() != "")
                    {
                        int index = int.Parse(hasRecDate1[RecTime].ToString());
                        if (index > 0)
                        {
                            index--;
                        }
                        PriorTime = hasRecDate2[index.ToString()].ToString();
                    }
                    string LastTime = "";
                    if (hasRecDate2.Count > 0)
                    {
                        int max = hasRecDate2.Count - 1;
                        LastTime = hasRecDate2[max.ToString()].ToString();
                    }

                    for (int i = 0; i < dtPrepayChargeNo.Rows.Count; i++)
                    {
                        DataRow dr = dtPrepayChargeNo.Rows[i];
                        string operdate = dr["operdate_dat"].ToString();
                        string preno = dr["prepayinv_vchr"].ToString();

                        if (IsRec)
                        {
                            if (dr["class_int"].ToString() == "3")
                            {
                                if (Convert.ToDateTime(PriorTime) < Convert.ToDateTime(operdate) &&
                                    Convert.ToDateTime(RecTime) >= Convert.ToDateTime(operdate))
                                {
                                    cdnoarr_dz.Add(preno);
                                }
                            }
                            else
                            {
                                cdnoarr_zc.Add(preno);
                            }
                        }
                        else
                        {
                            if (dr["class_int"].ToString() == "3")
                            {
                                if (LastTime == "" || Convert.ToDateTime(operdate) > Convert.ToDateTime(LastTime))
                                {
                                    cdnoarr_dz.Add(preno);
                                }
                            }
                            else
                            {
                                cdnoarr_zc.Add(preno);
                            }
                        }
                    }

                    #endregion

                    DataView dvPrepay = new DataView(dtPrepay);
                    foreach (DataRowView drv in dvPrepay)
                    {
                        string preno = drv["prepayinv_vchr"].ToString();
                        // 1
                        if (drv["paytype_int"].ToString() == "1")
                        {
                            aj_kps++;
                            aj_kpje += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                            kpnoarr.Add(preno);
                        }
                        else if (drv["paytype_int"].ToString() == "2")
                        {
                            aj_tps++;
                            aj_tpje += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                            tpnoarr.Add(preno);
                        }
                        else if (drv["paytype_int"].ToString() == "3")
                        {
                            aj_hfs++;
                            aj_hfje += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                            hfnoarr.Add(preno);
                        }

                        // 2
                        if (drv["uptype_int"].ToString() == "0")
                        {
                            ptnoarr.Add(preno);
                        }
                        else if (drv["uptype_int"].ToString() == "1")
                        {
                            sgnoarr.Add(preno);
                        }

                        // 3
                        if (drv["cuycate_int"].ToString() == "1")
                        {
                            aj_xj += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                        }
                        else if (drv["cuycate_int"].ToString() == "2")
                        {
                            aj_zp += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                        }
                        else if (drv["cuycate_int"].ToString() == "3")
                        {
                            aj_yhk += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                        }
                        else if (drv["cuycate_int"].ToString() == "4")
                        {
                            aj_qt += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                        }

                        //合计金额
                        aj_hjje += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                    }

                    //重打单号
                    ArrayList repnoarr = new ArrayList();
                    for (int i = 0; i < dtPrepayRepNo.Rows.Count; i++)
                    {
                        repnoarr.Add(dtPrepayRepNo.Rows[i]["prepayinv_vchr"].ToString());
                    }
                    #endregion

                    #region 赋值
                    //开票数、开票金额
                    if (aj_kps > 0)
                    {
                        dwRep.Modify("t_aj_kps.text = '" + aj_kps.ToString() + "张'");
                        dwRep.Modify("t_aj_kphj.text = '￥" + aj_kpje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_kps.text = ''");
                        dwRep.Modify("t_aj_kphj.text = ''");
                    }

                    //退票数、退票金额
                    if (aj_tps > 0)
                    {
                        dwRep.Modify("t_aj_tps.text = '" + aj_tps.ToString() + "张'");
                        dwRep.Modify("t_aj_tphj.text = '￥" + aj_tpje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_tps.text = ''");
                        dwRep.Modify("t_aj_tphj.text = ''");
                    }

                    //恢复数、恢复金额
                    if (aj_hfs > 0)
                    {
                        dwRep.Modify("t_aj_hfs.text = '" + aj_hfs.ToString() + "张'");
                        dwRep.Modify("t_aj_hfhj.text = '￥" + aj_hfje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_hfs.text = ''");
                        dwRep.Modify("t_aj_hfhj.text = ''");
                    }

                    //有效票数
                    if (aj_kps - aj_tps + aj_hfs > 0)
                    {
                        dwRep.Modify("t_aj_yxps.text = '" + Convert.ToString(aj_kps - aj_tps + aj_hfs) + "张'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_yxps.text = ''");
                    }

                    //冲单数
                    if (cdnoarr_zc.Count + cdnoarr_dz.Count > 0)
                    {
                        dwRep.Modify("t_aj_cds.text = '" + Convert.ToString(cdnoarr_zc.Count + cdnoarr_dz.Count) + "张'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_cds.text = ''");
                    }

                    //合计金额                    
                    if (aj_hjje != 0)
                    {
                        dwRep.Modify("t_aj_hjje_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(aj_hjje)) + "'");
                        dwRep.Modify("t_aj_hjje_x.text = '￥" + aj_hjje.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_hjje_d.text = ''");
                        dwRep.Modify("t_aj_hjje_x.text = ''");
                    }

                    /******总合计*******/
                    total = total + aj_hjje;

                    if (total != 0)
                    {
                        dwRep.Modify("t_yjhj_d.text = '" + clsPublic.DoubleConvertToCurrency(Convert.ToDouble(total)) + "'");
                        dwRep.Modify("t_yjhj_x.text = '￥" + total.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_yjhj_d.text = ''");
                        dwRep.Modify("t_yjhj_x.text = ''");
                    }

                    //现金                                        
                    if (aj_xj != 0)
                    {
                        dwRep.Modify("t_aj_xj.text = '￥" + aj_xj.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_xj.text = ''");
                    }

                    //支票                                        
                    if (aj_zp != 0)
                    {
                        dwRep.Modify("t_aj_zp.text = '￥" + aj_zp.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_zp.text = ''");
                    }

                    //银行卡                                        
                    if (aj_yhk != 0)
                    {
                        dwRep.Modify("t_aj_yhk.text = '￥" + aj_yhk.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_yhk.text = ''");
                    }

                    //其他                                        
                    if (aj_qt != 0)
                    {
                        dwRep.Modify("t_aj_qt.text = '￥" + aj_qt.ToString("###,##0.00") + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_qt.text = ''");
                    }
                    #endregion

                    //开按金单号                  
                    string aj_kpdh = this.m_strGetPrnPreNo(kpnoarr);
                    if (aj_kpdh != "")
                    {
                        dwRep.Modify("t_aj_kpdh.text = '" + aj_kpdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_kpdh.text = ''");
                    }

                    //手工按金单号                  
                    string aj_sgdh = this.m_strGetPrnPreNo(sgnoarr);
                    if (aj_sgdh != "")
                    {
                        dwRep.Modify("t_aj_sgdh.text = '" + aj_sgdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_sgdh.text = ''");
                    }

                    //退按金单号            
                    string aj_tpdh = this.m_strGetPrnPreNo(tpnoarr);
                    if (aj_tpdh != "")
                    {
                        dwRep.Modify("t_aj_tpdh.text = '" + aj_tpdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_tpdh.text = ''");
                    }

                    //恢复按金单号           
                    string aj_hfdh = this.m_strGetPrnPreNo(hfnoarr);
                    if (aj_hfdh != "")
                    {
                        dwRep.Modify("t_aj_hfdh.text = '" + aj_hfdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_hfdh.text = ''");
                    }

                    //重打按金单号       
                    string aj_repdh = this.m_strGetPrnPreNo(repnoarr);
                    if (aj_repdh != "")
                    {
                        dwRep.Modify("t_aj_repdh.text = '" + aj_repdh + "'");
                    }
                    else
                    {
                        dwRep.Modify("t_aj_repdh.text = ''");
                    }

                    //冲按金单号       
                    string aj_cddh_zc = this.m_strGetPrnPreNo(cdnoarr_zc);
                    string aj_cddh_dz = this.m_strGetPrnPreNo(cdnoarr_dz);
                    if (aj_cddh_zc == "" && aj_cddh_dz == "")
                    {
                        dwRep.Modify("t_aj_cddh.text = ''");
                    }
                    else
                    {
                        if (aj_cddh_zc != "" && aj_cddh_dz != "")
                        {
                            dwRep.Modify("t_aj_cddh.text = '" + aj_cddh_zc + " 呆帐结算冲单:" + aj_cddh_dz + "'");
                        }
                        else if (aj_cddh_zc != "" && aj_cddh_dz == "")
                        {
                            dwRep.Modify("t_aj_cddh.text = '" + aj_cddh_zc + "'");
                        }
                        else if (aj_cddh_zc == "" && aj_cddh_dz != "")
                        {
                            dwRep.Modify("t_aj_cddh.text = '" + " 呆帐结算冲单:" + aj_cddh_dz + "'");
                        }
                    }

                    #endregion

                    dwRep.SetItemSqlString(1, "col1", EmpID);
                    dwRep.SetItemSqlString(1, "col2", RecTime);
                    dwRep.SetItemSqlString(1, "col3", RemarkInfo1 + RemarkInfo2);

                    dwRep.SetRedrawOn();
                    dwRep.Refresh();
                }
            }
            catch (Exception ex)
            {
                dwRep.SetRedrawOn();
                dwRep.Refresh();
                clsPublic.CloseAvi();
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 出院医保分类统计
        /// <summary>
        /// 出院医保分类统计
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RptID"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="DiseaseType"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptYBOutSum(string BeginDate, string EndDate, string RptID, string DeptIDArr, int DiseaseType, DataWindowControl dwRep, string strFliter)
        {
            dwRep.Modify("t_date.text = '统计时间： 从 " + BeginDate + " 到 " + EndDate + "'");

            string SQL = "", SubStr = "";
            if (DeptIDArr.Trim() != "")
            {
                SubStr = " and a.areaid_chr in (" + DeptIDArr + ")";
            }

            if (DiseaseType > 0)
            {
                SubStr += " and c.diseasetype_int = " + Convert.ToString(DiseaseType - 1);
            }

            SQL = @"select a.areaid_chr as deptid, f.deptname_vchr as deptname,
                           g.lastname_vchr as doctname, a.inpatientid_chr as zyh,
                           b.lastname_vchr as patname, c.diseasetype_int,
                           (  to_date (to_char (c.outhospital_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')
                            - to_date (to_char (a.inpatient_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')
                           ) indays,
                           c.diagnose_vchr, d.totalsum, d.acctsum, e.groupid_chr,
                           (trim (e.groupname_chr) || '及所占比例') as groupandscalename,
                           e.catsum,
                           (to_char (round (e.catsum * 100 / d.totalsum, 2)) || '%') as scaleval 
                      from t_opr_bih_register a,
                           t_opr_bih_registerdetail b,
                           t_opr_bih_leave c,
                           (select   a.registerid_chr, sum (a.totalsum_mny) as totalsum,
                                     sum (a.acctsum_mny) as acctsum
                                from t_opr_bih_charge a
                               where exists (
                                        select 1
                                          from t_opr_bih_charge b
                                         where a.registerid_chr = b.registerid_chr
                                           and b.status_int = 1
                                           and b.class_int = 2
                                           and b.billno_int is not null
                                           and (b.operdate_dat
                                                   between to_date ('" + BeginDate + @" 00:00:00',
                                                                    'yyyy-mm-dd hh24:mi:ss'
                                                                   )
                                                       and to_date ('" + EndDate + @" 23:59:59',
                                                                    'yyyy-mm-dd hh24:mi:ss'
                                                                   )
                                               ))
                                 and a.billno_int is not null
                            group by a.registerid_chr) d,
                           (select   a.registerid_chr, b.groupid_chr, b.groupname_chr,
                                     sum (a.totalsum) as catsum
                                from (select   a.registerid_chr, a.calccateid_chr,
                                               sum (a.totalmoney_dec) as totalsum
                                          from t_opr_bih_chargeitementry a
                                         where exists (
                                                  select 1
                                                    from t_opr_bih_charge b
                                                   where a.registerid_chr = b.registerid_chr
                                                     and b.status_int = 1
                                                     and b.class_int = 2
                                                     and b.billno_int is not null
                                                     and (b.operdate_dat
                                                               between to_date ('" + BeginDate + @" 00:00:00',
                                                                                'yyyy-mm-dd hh24:mi:ss'
                                                                               )
                                                                   and to_date ('" + EndDate + @" 23:59:59',
                                                                                'yyyy-mm-dd hh24:mi:ss'
                                                                               )
                                                           ))
                                      group by a.registerid_chr, a.calccateid_chr) a,
                                     (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                        from t_aid_rpt_def a,
                                             t_aid_rpt_gop_def b,
                                             t_aid_rpt_gop_rla c
                                       where a.rptid_chr = '" + RptID + @"'
                                         and a.rptid_chr = b.rptid_chr
                                         and b.rptid_chr = c.rptid_chr
                                         and b.groupid_chr = c.groupid_chr(+)) b
                               where a.calccateid_chr = b.typeid_chr(+)
                            group by a.registerid_chr, b.groupid_chr, b.groupname_chr) e,
                           t_bse_deptdesc f,
                           t_bse_employee g
                     where a.registerid_chr = b.registerid_chr
                       and a.registerid_chr = c.registerid_chr
                       and a.registerid_chr = d.registerid_chr
                       and a.registerid_chr = e.registerid_chr
                       and a.areaid_chr = f.deptid_chr(+)
                       and a.casedoctor_chr = g.empid_chr(+) " + strFliter +
                       @" and a.status_int = 1
                       and a.pstatus_int = 3
                       and c.status_int = 1
                       and d.totalsum <> 0 " + SubStr;

            dwRep.SetRedrawOff();
            dwRep.SetSqlSelect(SQL);
            dwRep.Retrieve();
            dwRep.Sort();
            dwRep.CalculateGroups();
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog("出院医保分类统计", SQL);
        }
        #endregion

        #region 获取功能科室核算实收统计数据
        /// <summary>
        /// 获取功能科室核算实收统计数据-主治医生
        /// </summary>
        /// <param name="objvalue_Param"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        internal long m_lngGetGroupInComeByArea(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = objReport.m_lngGetGroupInComeByDoctor(ref objvalue_Param, ref dtbResult);
            return lngRes;
        }

        internal void m_mthGetGroupInComeByDoctor(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, DataWindowControl dwRep, int p_intRptType, int p_intRptClass)
        {
            #region 两层
            StringBuilder sbdSQL = new StringBuilder("");
            string LogTitle = "";
            if (p_intRptType == 9)
            {
                if (p_intRptClass == 1)
                {
                    LogTitle = "功能科室专业组分类报表（主治医生）(按日结时间)";

                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.doctorgroupid_chr,'999')  as doctorgroupid_chr, 
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a, t_opr_bih_charge b
                                            where a.chargeno_chr = b.chargeno_chr
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.recdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr) ta,
                                        (select a.doctorgroupid_chr,
                                                tb.groupid_chr,
                                                tb.groupname_chr,
                                                sum(a.totalmoney_dec) as catsum
                                         from   t_opr_bih_chargeitementry a,
                                                t_opr_bih_charge b,
                                                (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                 from t_aid_rpt_def     a,
                                                      t_aid_rpt_gop_def b, 
                                                      t_aid_rpt_gop_rla c 
                                                 where a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr(+)
                                                   and b.groupid_chr = c.groupid_chr(+)
                                                   and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                            where a.chargeno_chr = b.chargeno_chr
                                                and a.calccateid_chr = tb.typeid_chr(+)
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.recdate_dat >=
                                                    to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                        t_bse_groupdesc td
                                        where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                          and ta.doctorgroupid_chr = td.groupid_chr
                                        order by td.usercode_chr asc");

                }
                else
                {

                    LogTitle = "功能科室核算实收报表（开单医生）(按日结时间)";
                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a,                                               
                                                 t_opr_bih_charge          c
                                            where a.chargeno_chr = c.chargeno_chr
                                              and c.status_int = 1
                                              and c.recflag_int = 1
                                              and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.recdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);

                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')     
                                            group by a.chargedoctorgroupid_chr) ta,
                                    (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                            nvl(tb.groupid_chr,'999') as groupid_chr,
                                            nvl(tb.groupname_chr,'999') as groupname_chr,
                                            sum(a.totalmoney_dec) as catsum
                                     from t_opr_bih_chargeitementry a,                                    
                                          t_opr_bih_charge c,
                                          (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                            from t_aid_rpt_def     a,
                                                 t_aid_rpt_gop_def b,                       
                                                 t_aid_rpt_gop_rla c
                                            where a.rptid_chr = b.rptid_chr
                                              and b.rptid_chr = c.rptid_chr(+)
                                              and b.groupid_chr = c.groupid_chr(+)
                                              and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                    where a.chargeno_chr = c.chargeno_chr
                                        and a.calccateid_chr = tb.typeid_chr(+)
                                        and c.status_int = 1
                                        and c.recflag_int = 1
                                        and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.recdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                        group by a.chargedoctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,       
                                    t_bse_groupdesc td
                                 where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                   and ta.doctorgroupid_chr = td.groupid_chr(+)
                                 order by td.usercode_chr asc");
                }
            }
            else
            {
                if (p_intRptClass == 1)
                {
                    LogTitle = "功能科室专业组分类报表（主治医生）(按发票时间)";

                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.doctorgroupid_chr,'999')  as doctorgroupid_chr, 
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a, t_opr_bih_charge b
                                            where a.chargeno_chr = b.chargeno_chr
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.operdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr) ta,
                                        (select a.doctorgroupid_chr,
                                                tb.groupid_chr,
                                                tb.groupname_chr,
                                                sum(a.totalmoney_dec) as catsum
                                         from   t_opr_bih_chargeitementry a,
                                                t_opr_bih_charge b,
                                                (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                 from t_aid_rpt_def     a,
                                                      t_aid_rpt_gop_def b, 
                                                      t_aid_rpt_gop_rla c 
                                                 where a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr(+)
                                                   and b.groupid_chr = c.groupid_chr(+)
                                                   and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                            where a.chargeno_chr = b.chargeno_chr
                                                and a.calccateid_chr = tb.typeid_chr(+)
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.operdate_dat >=
                                                    to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                        t_bse_groupdesc td
                                        where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                          and ta.doctorgroupid_chr = td.groupid_chr
                                        order by td.usercode_chr asc");

                }
                else
                {
                    LogTitle = "功能科室核算实收报表（开单医生）(按发票时间)";
                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a,                                               
                                                 t_opr_bih_charge          c
                                            where a.chargeno_chr = c.chargeno_chr
                                              and c.status_int = 1
                                              and c.recflag_int = 1
                                              and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.operdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);

                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')     
                                            group by a.chargedoctorgroupid_chr) ta,
                                    (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                            nvl(tb.groupid_chr,'999') as groupid_chr,
                                            nvl(tb.groupname_chr,'999') as groupname_chr,
                                            sum(a.totalmoney_dec) as catsum
                                     from t_opr_bih_chargeitementry a,
                                          t_opr_bih_charge c,
                                          (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                            from t_aid_rpt_def     a,
                                                 t_aid_rpt_gop_def b,                       
                                                 t_aid_rpt_gop_rla c
                                            where a.rptid_chr = b.rptid_chr
                                              and b.rptid_chr = c.rptid_chr(+)
                                              and b.groupid_chr = c.groupid_chr(+)
                                              and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                    where a.chargeno_chr = c.chargeno_chr
                                        and a.calccateid_chr = tb.typeid_chr(+)
                                        and c.status_int = 1
                                        and c.recflag_int = 1
                                        and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.operdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                        group by a.chargedoctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,       
                                    t_bse_groupdesc td
                                 where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                   and ta.doctorgroupid_chr = td.groupid_chr(+)
                                 order by td.usercode_chr asc");

                }
            }
            dwRep.SetRedrawOff();
            dwRep.Modify(@"catsum_t.text = '@groupname_chr'");
            dwRep.SetSqlSelect(sbdSQL.ToString());
            dwRep.Retrieve();
            if (dwRep.RowCount == 0)
            {
                dwRep.Modify(@"catsum_t.text = '收费类别'");
            }
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, sbdSQL.ToString());
            #endregion

        }

        /// <summary>
        /// 获取病区数据
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        internal long m_lngFindArea(string strFindCode, out clsBIHArea[] objItemArr)
        {
            long lngRes = objReport.m_lngFindArea(strFindCode, out objItemArr);
            return lngRes;
        }

        #endregion

        #region 预出院未结算病人统计报表
        /// <summary>
        /// 预出院未结算病人统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptOutNoCharge(string BeginDate, string EndDate, string p_strSections, DataWindowControl dwRep)
        {
            DataTable dtPat, dtPreSum, dtChargeSum;

            long l = this.objReport.m_lngGetOutNoChargePatientList(BeginDate, EndDate, p_strSections, out dtPat);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Reset();
                dwRep.Modify("t_date.text = ' " + BeginDate + " ～ " + EndDate + "'");

                DataRow dr;
                for (int i = 0; i < dtPat.Rows.Count; i++)
                {
                    dr = dtPat.Rows[i];

                    string RegID = dr["registerid_chr"].ToString();

                    decimal yjje0 = 0;
                    decimal yjje1 = 0;
                    l = this.objReport.m_lngGetPrepayStatusSumByRegID(RegID, out dtPreSum);
                    for (int j = 0; j < dtPreSum.Rows.Count; j++)
                    {
                        if (dtPreSum.Rows[j]["isclear_int"].ToString() == "0")
                        {
                            yjje0 += clsPublic.ConvertObjToDecimal(dtPreSum.Rows[j]["prepaysum"]);
                        }
                        else if (dtPreSum.Rows[j]["isclear_int"].ToString() == "1")
                        {
                            yjje1 += clsPublic.ConvertObjToDecimal(dtPreSum.Rows[j]["prepaysum"]);
                        }
                    }

                    decimal yqje = 0;
                    decimal dqje = 0;
                    decimal djje = 0;
                    l = this.objReport.m_lngGetPatientStatusSumByRegID(RegID, out dtChargeSum);
                    for (int j = 0; j < dtChargeSum.Rows.Count; j++)
                    {
                        if (dtChargeSum.Rows[j]["pstatus_int"].ToString() == "1")
                        {
                            djje += clsPublic.ConvertObjToDecimal(dtChargeSum.Rows[j]["totalsum"]);
                        }
                        else if (dtChargeSum.Rows[j]["pstatus_int"].ToString() == "2")
                        {
                            dqje += clsPublic.ConvertObjToDecimal(dtChargeSum.Rows[j]["totalsum"]);
                        }
                        else
                        {
                            yqje += clsPublic.ConvertObjToDecimal(dtChargeSum.Rows[j]["totalsum"]);
                        }
                    }

                    int row = dwRep.InsertRow(0);
                    dwRep.SetItemString(row, "ks", dr["deptname_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "ys", dr["doctname"].ToString().Trim());
                    dwRep.SetItemString(row, "zyh", dr["inpatientid_chr"].ToString().Trim());
                    dwRep.SetItemString(row, "xm", dr["patname"].ToString().Trim());
                    dwRep.SetItemString(row, "fbcode", dr["paytypeid_chr"].ToString().Trim());
                    dwRep.SetItemString(row, "fb", dr["paytypename_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "rysj", dr["indate"].ToString().Trim());
                    dwRep.SetItemString(row, "cysj", dr["outdate"].ToString().Trim());

                    dwRep.SetItemDecimal(row, "zfy", yqje + dqje + djje);
                    dwRep.SetItemDecimal(row, "yqfy", yqje);
                    dwRep.SetItemDecimal(row, "dqfy", dqje);
                    dwRep.SetItemDecimal(row, "djfy", djje);
                    dwRep.SetItemDecimal(row, "zyjj", yjje0 + yjje1);
                    dwRep.SetItemDecimal(row, "kyyjj", yjje0);
                    dwRep.SetItemDecimal(row, "jyje", yjje0 - dqje - djje);

                    dwRep.SetItemString(row, "tsbz", dr["remarkname_vchr"].ToString().Trim());
                }

                dwRep.SetRedrawOn();
                dwRep.Refresh();
            }
        }
        #endregion

        #region 病区工作日志
        /// <summary>
        /// 病区工作日志
        /// </summary>
        /// <param name="CurrDate"></param>
        /// <param name="YBPayTypeIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptDeptWorkLog(string CurrDate, ArrayList YBPayTypeIDArr, DataWindowControl dwRep)
        {
            long l = 0;
            dwRep.Modify("t_date.text = '" + CurrDate + "'");

            DataTable dtDept, dtInNums, dtOutNums, dtOnNums, dtFmNums;

            l = this.objReport.m_lngRptDeptWorkLog_Dept(out dtDept);
            l = this.objReport.m_lngRptDeptWorkLog_InNums(null, CurrDate, out dtInNums);
            l = this.objReport.m_lngRptDeptWorkLog_OutNums(null, CurrDate, out dtOutNums);
            l = this.objReport.m_lngRptDeptWorkLog_OnNums(null, CurrDate, out dtOnNums);
            l = this.objReport.m_lngRptDeptWorkLog_FmNums(null, CurrDate, out dtFmNums);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Reset();

                DataRow dr = null;
                for (int i = 0; i < dtDept.Rows.Count; i++)
                {
                    dr = dtDept.Rows[i];

                    string DeptID = dr["deptid_chr"].ToString().Trim();
                    string DeptName = dr["deptname_vchr"].ToString().Trim();
                    decimal BedNums = clsPublic.ConvertObjToDecimal(dr["stdbed_count_int"]);

                    decimal OnNums = 0;
                    decimal InNums = 0;
                    decimal OutNums = 0;
                    decimal YbNums = 0;
                    decimal WzNums = 0;
                    decimal FmNums = 0;

                    for (int j = 0; j < dtInNums.Rows.Count; j++)
                    {
                        dr = dtInNums.Rows[j];

                        if (dr["areaid_chr"].ToString().Trim() == DeptID)
                        {
                            InNums += clsPublic.ConvertObjToDecimal(dr["innums"]);

                            //if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                            //{
                            //    YbNums += clsPublic.ConvertObjToDecimal(dr["innums"]);
                            //}
                        }
                    }

                    for (int j = 0; j < dtOutNums.Rows.Count; j++)
                    {
                        dr = dtOutNums.Rows[j];

                        if (dr["outareaid_chr"].ToString().Trim() == DeptID)
                        {
                            OutNums += clsPublic.ConvertObjToDecimal(dr["outnums"]);

                            //if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                            //{
                            //    YbNums += clsPublic.ConvertObjToDecimal(dr["outnums"]);
                            //}
                        }
                    }

                    for (int j = 0; j < dtOnNums.Rows.Count; j++)
                    {
                        dr = dtOnNums.Rows[j];

                        if (dr["areaid_chr"].ToString().Trim() == DeptID)
                        {
                            OnNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);

                            if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                            {
                                YbNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);
                            }
                        }
                    }

                    for (int j = 0; j < dtOnNums.Rows.Count; j++)
                    {
                        dr = dtOnNums.Rows[j];

                        if (dr["areaid_chr"].ToString().Trim() == DeptID)
                        {
                            if (Convert.ToInt32(dr["state_int"].ToString()) == 1)
                            {
                                WzNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);
                            }
                        }
                    }


                    for (int j = 0; j < dtFmNums.Rows.Count; j++)
                    {
                        dr = dtFmNums.Rows[j];

                        if (dr["areaid_chr"].ToString().Trim() == DeptID)
                        {
                            FmNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);

                        }
                    }

                    int row = dwRep.InsertRow(0);
                    dwRep.SetItemString(row, "colDept", "");
                    dwRep.SetItemString(row, "colArea", DeptName);

                    dwRep.SetItemDecimal(row, "col1", OnNums);
                    dwRep.SetItemDecimal(row, "col2", InNums);
                    dwRep.SetItemDecimal(row, "col3", OutNums);
                    dwRep.SetItemDecimal(row, "col6", YbNums);
                    dwRep.SetItemDecimal(row, "col7", BedNums);
                    dwRep.SetItemDecimal(row, "col8", 0);
                    dwRep.SetItemDecimal(row, "col9", WzNums);
                    dwRep.SetItemDecimal(row, "col10", FmNums);
                }

                //dwRep.CalculateGroups();
                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 病区工作日志(明细)
        /// <summary>
        /// 病区工作日志(明细)
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="YBPayTypeIDArr"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptDeptWorkLog_Det(string AreaID, string CurrDate, ArrayList YBPayTypeIDArr, DataWindowControl dwRep)
        {
            long l = 0;

            try
            {
                dwRep.SetRedrawOff();
                dwRep.Reset();

                DataWindowChild dwChild1 = dwRep.GetChild("dw_1");
                DataWindowChild dwChild2 = dwRep.GetChild("dw_2");
                DataWindowChild dwChild3 = dwRep.GetChild("dw_3");
                DataWindowChild dwChild4 = dwRep.GetChild("dw_4");
                DataWindowChild dwChild5 = dwRep.GetChild("dw_5");

                #region 主信息
                DataTable dtYesterdayNums, dtInNums, dtTransInNums, dtTransOutNums;
                DataTable dtOutNums, dtOutDeadNums, dtOutDead24Nums, dtOnNums;

                TimeSpan ts = new TimeSpan(1, 0, 0, 0);
                DateTime dtToday = Convert.ToDateTime(CurrDate);
                DateTime dtYesterday = dtToday.Subtract(ts);

                l = this.objReport.m_lngRptDeptWorkLog_OnNums(AreaID, dtYesterday.ToString("yyyy-MM-dd"), out dtYesterdayNums);
                l = this.objReport.m_lngRptDeptWorkLog_InNums(AreaID, CurrDate, out dtInNums);
                l = this.objReport.m_lngRptDeptWorkLog_TransInNums(AreaID, CurrDate, out dtTransInNums);
                l = this.objReport.m_lngRptDeptWorkLog_TransOutNums(AreaID, CurrDate, out dtTransOutNums);
                l = this.objReport.m_lngRptDeptWorkLog_OutNums(AreaID, CurrDate, out dtOutNums);
                l = this.objReport.m_lngRptDeptWorkLog_OutDeadNums(AreaID, CurrDate, out dtOutDeadNums);
                l = this.objReport.m_lngRptDeptWorkLog_OutDead24Nums(AreaID, CurrDate, out dtOutDead24Nums);
                l = this.objReport.m_lngRptDeptWorkLog_OnNums(AreaID, CurrDate, out dtOnNums);
                if (l > 0)
                {
                    int row = dwChild1.InsertRow(0);
                    decimal YesterdayNums = 0;
                    decimal InNums = 0;
                    decimal TransInNums = 0;
                    decimal TransOutNums = 0;
                    decimal OutNums = 0;
                    decimal OutDeadNums = 0;
                    decimal OutDead24Nums = 0;
                    decimal OnNums = 0;
                    decimal YbNums = 0;

                    decimal WzNums = 0;//CS-470 (ID:13259)病区工作日志（明细）需求(病危病人)

                    DataRow dr = null;
                    for (int i = 0; i < dtYesterdayNums.Rows.Count; i++)
                    {
                        YesterdayNums += clsPublic.ConvertObjToDecimal(dtYesterdayNums.Rows[i]["onnums"]);
                    }

                    for (int i = 0; i < dtInNums.Rows.Count; i++)
                    {
                        dr = dtInNums.Rows[i];

                        InNums += clsPublic.ConvertObjToDecimal(dr["innums"]);

                        //if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                        //{
                        //    YbNums += clsPublic.ConvertObjToDecimal(dr["innums"]);
                        //}
                    }

                    for (int i = 0; i < dtTransInNums.Rows.Count; i++)
                    {
                        dr = dtTransInNums.Rows[i];

                        TransInNums += clsPublic.ConvertObjToDecimal(dr["transinnums"]);

                        //if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                        //{
                        //    YbNums += clsPublic.ConvertObjToDecimal(dr["transinnums"]);
                        //}
                    }

                    for (int i = 0; i < dtTransOutNums.Rows.Count; i++)
                    {
                        dr = dtTransOutNums.Rows[i];

                        TransOutNums += clsPublic.ConvertObjToDecimal(dr["transoutnums"]);

                        //if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                        //{
                        //    YbNums += clsPublic.ConvertObjToDecimal(dr["transoutnums"]);
                        //}
                    }

                    for (int i = 0; i < dtOutNums.Rows.Count; i++)
                    {
                        dr = dtOutNums.Rows[i];

                        OutNums += clsPublic.ConvertObjToDecimal(dr["outnums"]);

                        //if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                        //{
                        //    YbNums += clsPublic.ConvertObjToDecimal(dr["outnums"]);
                        //}
                    }

                    if (dtOutDeadNums.Rows.Count > 0)
                    {
                        OutDeadNums = clsPublic.ConvertObjToDecimal(dtOutDeadNums.Rows[0]["outdeadnums"]);
                    }

                    if (dtOutDead24Nums.Rows.Count > 0)
                    {
                        OutDead24Nums = clsPublic.ConvertObjToDecimal(dtOutDead24Nums.Rows[0]["outdead24nums"]);
                    }

                    for (int i = 0; i < dtOnNums.Rows.Count; i++)
                    {
                        dr = dtOnNums.Rows[i];

                        OnNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);

                        if (YBPayTypeIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                        {
                            YbNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);
                        }
                    }

                    for (int j = 0; j < dtOnNums.Rows.Count; j++)
                    {
                        dr = dtOnNums.Rows[j];


                        if (Convert.ToInt32(dr["state_int"].ToString()) == 1)
                        {
                            WzNums += clsPublic.ConvertObjToDecimal(dr["onnums"]);
                        }

                    }

                    dwChild1.SetItemDecimal(row, "col1", YesterdayNums);
                    dwChild1.SetItemDecimal(row, "col2", InNums);
                    dwChild1.SetItemDecimal(row, "col3", TransInNums);
                    dwChild1.SetItemDecimal(row, "col4", TransOutNums);
                    dwChild1.SetItemDecimal(row, "col5", OutNums);
                    dwChild1.SetItemDecimal(row, "col6", OutDeadNums);
                    dwChild1.SetItemDecimal(row, "col7", OutDead24Nums);
                    dwChild1.SetItemDecimal(row, "col8", OnNums);
                    dwChild1.SetItemDecimal(row, "col9", WzNums);
                    dwChild1.SetItemDecimal(row, "col10", 0);
                    dwChild1.SetItemDecimal(row, "col11", YbNums);
                }
                #endregion

                #region 入院病人清单
                DataTable dtInPatList;
                l = this.objReport.m_lngRptDeptWorkLog_InPatList(AreaID, CurrDate, out dtInPatList);
                if (l > 0 && dtInPatList != null)
                {
                    if (dtInPatList.Rows.Count == 0)
                    {
                        dwChild2.InsertRow(0);
                    }
                    else
                    {
                        dwChild2.Retrieve(dtInPatList);
                    }
                }
                #endregion

                #region 转入病人清单
                DataTable dtTransInPatList;
                l = this.objReport.m_lngRptDeptWorkLog_TransInPatList(AreaID, CurrDate, out dtTransInPatList);
                if (l > 0 && dtTransInPatList != null)
                {
                    if (dtTransInPatList.Rows.Count == 0)
                    {
                        dwChild3.InsertRow(0);
                    }
                    else
                    {
                        dwChild3.Retrieve(dtTransInPatList);
                    }
                }
                #endregion

                #region 转出病人清单
                DataTable dtTransOutPatList;
                l = this.objReport.m_lngRptDeptWorkLog_TransOutPatList(AreaID, CurrDate, out dtTransOutPatList);
                if (l > 0 && dtTransOutPatList != null)
                {
                    if (dtTransOutPatList.Rows.Count == 0)
                    {
                        dwChild4.InsertRow(0);
                    }
                    else
                    {
                        dwChild4.Retrieve(dtTransOutPatList);
                    }
                }
                #endregion

                #region 出院病人清单
                DataTable dtOutPatList;
                l = this.objReport.m_lngRptDeptWorkLog_OutPatList(AreaID, CurrDate, out dtOutPatList);
                if (l > 0 && dtOutPatList != null)
                {
                    if (dtOutPatList.Rows.Count == 0)
                    {
                        dwChild5.InsertRow(0);
                    }
                    else
                    {
                        dwChild5.Retrieve(dtOutPatList);
                    }
                }
                #endregion

                dwRep.SetRedrawOn();
            }
            catch (Exception obj)
            {
                MessageBox.Show("生成报表失败。 原因： " + obj.Message);
            }
        }
        #endregion

        public DataTable m_dtGetAllYBType()
        {
            DataTable dtResult;
            long lngRes = objReport.m_lngGetALLYBType(out dtResult);
            if (lngRes < 0 || dtResult == null)
            {
                return null;
            }
            return dtResult;
        }

        #region 每日清单 ---按类别
        /// <summary>
        /// 每日清单 ---按类别
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="BillDate"></param>
        /// <param name="Type"></param>
        /// <param name="ItemCodeType"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptEveryDayBillCate(string ID, string BillDate, int Type, int ItemCodeType, Sybase.DataWindow.DataWindowControl dwRep)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            if (this.intDiffCostOn == 1)
                dsRep.DataWindowObject = "d_bih_everydaybill_Cate_diff";
            else
                dsRep.DataWindowObject = "d_bih_everydaybill_Cate";

            DataTable dt = null;
            long l = this.objReport.m_lngRptEveryDayBillCate(ID, BillDate, Type, ItemCodeType, out dt);
            if (l > 0)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    Hashtable hasReg = new Hashtable();
                    DataView dv = dt.DefaultView;
                    dv.Sort = "calccateid_chr asc";
                    dt = dv.ToTable();
                    clsBihEveryDayBill_VO objEveryDayBill;
                    l = this.objReport.m_lngRptEveryDayBill(dt.Rows[0]["registerid_chr"].ToString(), BillDate, out objEveryDayBill);
                    dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
                    dsRep.Modify("t_ksmc.text = '" + objEveryDayBill.AreaName + "'");
                    dsRep.Modify("t_zyh.text = '" + objEveryDayBill.Zyh + "'");
                    dsRep.Modify("t_xm.text = '" + objEveryDayBill.Name + "'");
                    dsRep.Modify("t_date.text='" + BillDate + "'");
                    dsRep.Modify("t_bedno.text='" + objEveryDayBill.BedNO + "'");

                    DataRow drTemp = null;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        drTemp = dt.Rows[i];
                        string areaname = drTemp["deptname_vchr"].ToString();
                        string creatdate = drTemp["chargedate"].ToString();
                        string itemid = drTemp["chargeitemid_chr"].ToString().Trim();
                        string price = drTemp["unitprice_dec"].ToString();
                        //string opername = dt.Rows[i]["collr"].ToString().Trim();
                        decimal amount = clsPublic.ConvertObjToDecimal(drTemp["amount_dec"].ToString());
                        decimal totalmoney = clsPublic.ConvertObjToDecimal(drTemp["totalmoney"].ToString());
                        string spec = drTemp["spec_vchr"].ToString();
                        for (int j = i + 1; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["deptname_vchr"].ToString().Trim() == areaname &&
                                dt.Rows[j]["chargedate"].ToString().Trim() == creatdate &&
                                dt.Rows[j]["chargeitemid_chr"].ToString().Trim() == itemid &&
                                dt.Rows[j]["unitprice_dec"].ToString().Trim() == price)
                            {
                                amount += clsPublic.ConvertObjToDecimal(dt.Rows[j]["amount_dec"].ToString().Trim());
                                //totalmoney += clsPublic.ConvertObjToDecimal(dt.Rows[j]["totalmoney"].ToString().Trim());
                                totalmoney += clsPublic.ConvertObjToDecimal(clsPublic.ConvertObjToDecimal(dt.Rows[j]["unitprice_dec"].ToString()) * clsPublic.ConvertObjToDecimal(dt.Rows[j]["amount_dec"].ToString()));

                            }
                        }

                        int row = dsRep.InsertRow(0);
                        // dsRep.SetItemString(row, "colxmdm", itemid);
                        dsRep.SetItemString(row, "colkdbq", areaname);
                        dsRep.SetItemString(row, "colrq", creatdate);
                        dsRep.SetItemString(row, "colxmmc", drTemp["chargeitemname_chr"].ToString());
                        dsRep.SetItemString(row, "colfpfl", drTemp["typename_vchr"].ToString());
                        dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(price));
                        dsRep.SetItemDecimal(row, "colsl", amount);
                        dsRep.SetItemString(row, "coldw", drTemp["unit_vchr"].ToString());
                        dsRep.SetItemDecimal(row, "colje", totalmoney);
                        if (this.intDiffCostOn == 1)
                        {
                            dsRep.SetItemDecimal(row, "ylje", (clsPublic.ConvertObjToDecimal(drTemp["totaldiffcostmoney_dec"].ToString())));
                            dsRep.SetItemDecimal(row, "sfje", totalmoney - Math.Abs(clsPublic.ConvertObjToDecimal(drTemp["totaldiffcostmoney_dec"].ToString())));
                        }
                        //dsRep.SetItemString(row, "collr", opername);
                        dsRep.SetItemString(row, "colgg", spec);
                    }
                    dsRep.CalculateGroups();
                    //clsPublic.PrintDialog(dsRep);
                    DataWindowFullState dsState = dsRep.GetFullState();
                    dwRep.SetFullState(dsState);
                }
            }
        }
        #endregion
    }

    #region VO类
    /// <summary>
    /// 结算单支付比例
    /// </summary>    
    [Serializable]
    public class clsBihPaymentScale_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO, IComparable
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CatName = "";
        /// <summary>
        /// 金额
        /// </summary>
        public decimal TotalMny = 0;
        /// <summary>
        /// 支付类型数组
        /// </summary>
        public ArrayList PayTypeArr = new ArrayList();
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortCode = 0;

        #region IComparable 成员
        /// <summary>
        /// IComparable 成员
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is clsBihPaymentScale_VO)
            {
                return this.SortCode.CompareTo(((clsBihPaymentScale_VO)obj).SortCode);
            }
            return 0;
        }
        #endregion
    }

    /// <summary>
    /// 结算单支付比例
    /// </summary>
    [Serializable]
    public class clsBihPaymentScale1_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 结算号
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalMny = 0;
        /// <summary>
        /// 支付类型数组
        /// </summary>
        public ArrayList PayTypeArr = new ArrayList();
    }

    /// <summary>
    /// 子项
    /// </summary>
    [Serializable]
    public class clsBihPaymentScale2_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 支付类型ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal PaySum = 0;
    }

    /// <summary>
    /// 日结发票号统计VO
    /// </summary>
    [Serializable]
    public class clsBihReckoningInvoNo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO, IComparable
    {
        /// <summary>
        /// 标志
        /// </summary>
        public string Flag = "";
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoNo = "";

        #region IComparable 成员
        /// <summary>
        /// IComparable 成员
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is clsBihReckoningInvoNo_VO)
            {
                return this.InvoNo.CompareTo(((clsBihReckoningInvoNo_VO)obj).InvoNo);
            }
            return 0;
        }
        #endregion
    }

    /// <summary>
    /// 日结按金号统计VO
    /// </summary>
    [Serializable]
    public class clsBihReckoningPreNo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO, IComparable
    {
        /// <summary>
        /// 按金单号
        /// </summary>
        public string PreNo = "";

        #region IComparable 成员
        /// <summary>
        /// IComparable 成员
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is clsBihReckoningPreNo_VO)
            {
                return this.PreNo.CompareTo(((clsBihReckoningPreNo_VO)obj).PreNo);
            }
            return 0;
        }
        #endregion
    }
    #endregion
}
