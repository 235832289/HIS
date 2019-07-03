using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 住院公用结帐逻辑类
    /// </summary>
    public class clsCtl_Reckoning : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmReckoning m_objViewer;
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Charge objSvc;
        /// <summary>
        /// 结算VO
        /// </summary>
        private clsBihCharge_VO objCharge_VO;
        /// <summary>
        /// 预交金处理标志 0 不作处理 1 冲帐退回 2 结余转下期
        /// 目前业务调研暂定：结算、预交分离处理 -> 冲帐则只办理退款，所以状态2【结余转下期】暂不启用        
        /// </summary>
        internal int PrePayDeal = 0;
        /// <summary>
        /// 预交金ID数组
        /// </summary>
        private ArrayList PrePayIDArr = new ArrayList();
        /// <summary>
        /// 发票分类
        /// </summary>
        private ArrayList InvoCatArr = new ArrayList();
        /// <summary>
        /// 001 佛山市 002 东莞市 003 佛山顺德区
        /// </summary>
        private string YBType = "001";
        /// <summary>
        /// 医保结算标志
        /// </summary>
        private bool YBChargeFlag = false;
        /// <summary>
        /// 医保结帐单号
        /// </summary>
        private string YBBillNO = "";
        /// <summary>
        /// (医保)医院代码
        /// </summary>
        private string Hospcode = "";
        /// <summary>
        /// (医保)DB2数据库连接参数
        /// </summary>
        private string DB2Parm = "";
        /// <summary>
        /// (医保)DBF数据文件连接参数
        /// </summary>
        private string DBFParm = "";
        /// <summary>
        /// (医保)DBF数据文件连接参数-DBQ
        /// </summary>
        private string DBQ = "";
        /// <summary>
        /// 凑整费规则 0 不凑整 1 四舍五入到角 2 凑整到角 3 凑整到元
        /// </summary>
        private string RoundingRule = "0";
        /// <summary>
        /// 凑整费代码(ID)
        /// </summary>
        private string RoundingCode = "";
        /// <summary>
        /// 医院名称
        /// </summary>
        private string HospitalName = "";
        /// <summary>
        /// 让利启用开关
        /// </summary>
        internal int intDiffCostOn = 0;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_Reckoning()
        {
            objSvc = new clsDcl_Charge();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReckoning)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            #region 获取当前收款员发票号
            if (clsPublic.m_blnCheckInvoIsUsed(this.m_objViewer.manuInputInvoNo))
            {
                this.m_objViewer.txtInvono.Text = clsPublic.m_strGetCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, 1);
            }
            else
            {
                this.m_objViewer.txtInvono.Text = this.m_objViewer.manuInputInvoNo;
            }
            #endregion

            #region 获取医院名称
            this.HospitalName = this.m_objComInfo.m_strGetHospitalTitle();
            #endregion

            #region 获取药品让利开关
            intDiffCostOn = clsPublic.m_intGetSysParm("9002");
            #endregion

            if (this.m_objViewer.ChargeType == 3)
            {
                #region 预交金
                decimal PrepayMoney = this.m_objViewer.objPatient.BalancePrepayMoney;
                if (PrepayMoney > 0)
                {
                    this.m_objViewer.lblPreMoney.Text = PrepayMoney.ToString();
                    this.m_objViewer.lblPreMoney.Tag = PrepayMoney.ToString();
                    this.m_objViewer.lblReturn.Tag = "0";

                    for (int i = 0; i < this.m_objViewer.objPatient.PrePayIDArr.Count; i++)
                    {
                        string s = this.m_objViewer.objPatient.PrePayIDArr[i].ToString();
                        string[] ss = new string[6];
                        ArrayList sarr = clsPublic.m_ArrGettoken(s, ";");
                        ss[0] = "F";
                        ss[1] = "F";
                        ss[2] = "";
                        ss[3] = sarr[1].ToString();
                        ss[4] = sarr[2].ToString();
                        ss[5] = sarr[0].ToString();

                        this.m_objViewer.dgPrePay.Rows.Add(ss);
                    }
                }
                #endregion

                #region 总金额
                objCharge_VO = new clsBihCharge_VO();

                if (PrepayMoney > 0)
                {
                    objCharge_VO.TotalSum = PrepayMoney;
                    objCharge_VO.SbSum = PrepayMoney;
                    objCharge_VO.AcctSum = 0;

                    this.PrePayDeal = 1;
                    this.m_objViewer.lblPreMoney.Text = PrepayMoney.ToString();

                    this.m_objViewer.lblTotalMoney.Text = objCharge_VO.TotalSum.ToString();
                    this.m_objViewer.lblTotalMoney.Tag = objCharge_VO.TotalSum.ToString();
                    this.m_objViewer.lblSbMoney.Text = objCharge_VO.SbSum.ToString();
                    this.m_objViewer.lblSbMoney.Tag = objCharge_VO.SbSum.ToString();

                    #region 支付方式
                    this.m_objViewer.cboPayMode1.Items.Clear();
                    this.m_objViewer.cboPayMode1.Items.Add("1.预交金");

                    this.m_objViewer.cboPayMode1.SelectedIndex = 0;
                    this.m_objViewer.chkAllSelect.Checked = true;
                    this.m_objViewer.chkAllSelect.Enabled = false;
                    #endregion

                    #region 发票分类列表
                    for (int i = 0; i < this.m_objViewer.BadChargeInvArr.Count; i++)
                    {
                        clsBihInvoiceCat_VO InvoiceCat_VO = this.m_objViewer.BadChargeInvArr[i] as clsBihInvoiceCat_VO;

                        string[] s = new string[2];
                        s[0] = InvoiceCat_VO.ItemCatName;
                        s[1] = InvoiceCat_VO.TotalSum.ToString();

                        this.m_objViewer.dgInvoiceCat.Rows.Add(s);
                    }
                    #endregion
                }
                else
                {
                    objCharge_VO.TotalSum = 0;
                    objCharge_VO.SbSum = 0;
                    objCharge_VO.AcctSum = 0;

                    this.m_objViewer.lblTotalMoney.Text = "";
                    this.m_objViewer.lblTotalMoney.Tag = "0";
                    this.m_objViewer.lblSbMoney.Text = "";
                    this.m_objViewer.lblSbMoney.Tag = "0";
                }
                this.m_objViewer.cboPayMode1.Enabled = false;
                this.m_objViewer.cboPayMode2.Visible = false;
                this.m_objViewer.txtPayMode1Money.Enabled = false;
                this.m_objViewer.txtPayMode2Money.Visible = false;

                this.m_objViewer.dgPrePay.Enabled = false;
                #endregion

                #region 医保按钮
                this.m_objViewer.btnYB.Enabled = false;
                this.m_objViewer.btnNewYB.Enabled = false;
                #endregion
            }
            else
            {
                #region 直接结算
                if (this.m_objViewer.DirectChargeOut)
                {
                    this.m_mthInitDir();
                    return;
                }
                #endregion

                #region 是否使用医保结算

                string tmpfs = clsPublic.XMLFile;
                clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";

                //顺德住院医保标志
                bool SDYBFlag = false;

                YBType = clsPublic.m_strGetSysparm("1000");

                if (YBType == "001")
                {
                    if (this.m_objViewer.ChargeType == 1 || this.m_objViewer.ChargeType == 2 || this.m_objViewer.ChargeType == 6)
                    {
                        ArrayList PayIDArr = clsPublic.m_mthGetYBPayID();
                        if (PayIDArr.IndexOf(this.m_objViewer.objPatient.BihPatient_VO.PayTypeID) >= 0)
                        {
                            this.m_objViewer.btnYB.Enabled = true;
                        }
                        else
                        {
                            this.m_objViewer.btnYB.Enabled = false;
                        }
                    }
                    else
                    {
                        this.m_objViewer.btnYB.Enabled = false;
                    }

                    //获取连接医保前置数据库参数                
                    string DSN = clsPublic.m_strReadXML("FOSHAN.NO2", "DBDSN", "AnyOne");
                    string UserID = clsPublic.m_strReadXML("FOSHAN.NO2", "DBUserID", "AnyOne");
                    string PassWord = clsPublic.m_strReadXML("FOSHAN.NO2", "DBPassWord", "AnyOne");
                    Hospcode = clsPublic.m_strReadXML("FOSHAN.NO2", "HospitalNO", "AnyOne");
                    DB2Parm = "DSN=" + DSN + ";UID=" + UserID + ";PWD=" + PassWord;
                }
                else if (YBType == "002")
                {
                    if (this.m_objViewer.ChargeType == 1 || this.m_objViewer.ChargeType == 2)
                    {
                        ArrayList PayIDArr = clsPublic.m_mthGetYBPayID();
                        if (PayIDArr.IndexOf(this.m_objViewer.objPatient.BihPatient_VO.PayTypeID) >= 0)
                        {
                            this.m_objViewer.btnYB.Enabled = true;
                            this.m_objViewer.btnNewYB.Enabled = true;
                        }
                        else
                        {
                            this.m_objViewer.btnYB.Enabled = false;
                            this.m_objViewer.btnNewYB.Enabled = false;
                        }
                    }
                    else
                    {
                        this.m_objViewer.btnYB.Enabled = true;
                        this.m_objViewer.btnNewYB.Enabled = true;
                    }

                    string DSN = clsPublic.m_strReadXML("DONGGUAN.CHASHAN", "DSN", "AnyOne");
                    DBQ = clsPublic.m_strReadXML("DONGGUAN.CHASHAN", "DBQ", "AnyOne");
                    DBFParm = DSN + DBQ;
                }
                else if (YBType == "003")
                {
                    this.m_objViewer.btnYB.Enabled = false;

                    ArrayList PayIDArr = clsPublic.m_mthGetYBPayID();
                    if (PayIDArr.IndexOf(this.m_objViewer.objPatient.BihPatient_VO.PayTypeID) >= 0)
                    {
                        SDYBFlag = true;
                    }
                }
                else if (YBType == "006")
                {
                    if (this.m_objViewer.ChargeType == 1 || this.m_objViewer.ChargeType == 2 || this.m_objViewer.ChargeType == 6)
                    {
                        ArrayList PayIDArr = clsPublic.m_mthGetYBPayID();
                        if (PayIDArr.IndexOf(this.m_objViewer.objPatient.BihPatient_VO.PayTypeID) >= 0)
                        {
                            this.m_objViewer.btnYB.Enabled = true;
                        }
                        else
                        {
                            this.m_objViewer.btnYB.Enabled = false;
                        }
                    }
                    else
                    {
                        this.m_objViewer.btnYB.Enabled = false;
                    }

                }
                else
                {
                    this.m_objViewer.btnYB.Enabled = false;
                }

                clsPublic.XMLFile = tmpfs;
                #endregion

                #region 计算总金额、自付金额和记帐金额

                objCharge_VO = new clsBihCharge_VO();

                decimal decTotalSum = 0;
                decimal decSbSum = 0;
                decimal decAcctSum = 0;
                for (int i = 0; i < this.m_objViewer.ChargeDetail.Rows.Count; i++)
                {
                    //以本次结算的自付比例更新明细合计金额和记帐金额
                    decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["amount_dec"]), 2) - clsPublic.Round(clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["chargetotalsum"]), 2);
                    if (this.intDiffCostOn == 1)
                    {
                        d = d + clsPublic.Round(clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["totaldiffcostmoney_dec"]), 2);
                    }
                    this.m_objViewer.ChargeDetail.Rows[i]["totalmoney_dec"] = clsPublic.Round(d, 2);
                    this.m_objViewer.ChargeDetail.Rows[i]["acctmoney_dec"] = clsPublic.Round(d, 2) - clsPublic.Round(d * clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["precent_dec"]) / 100, 2); ;
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["precent_dec"]) / 100, 2);
                }

                #region 判断是否符合嵌入式社保病人，不进行凑整费
                clsDcl_YB clsDclYB = new clsDcl_YB();
                bool blRes = clsDclYB.m_blGetIsYBReg(this.m_objViewer.objPatient.BihPatient_VO.RegisterID);
                decimal RoundingVal = 0;
                if (blRes == false)
                {
                    #region 凑整
                    RoundingRule = clsPublic.m_strGetSysparm("0015");
                    RoundingCode = clsPublic.m_strGetSysparm("0016");
                    if (decSbSum > 0)
                    {
                        string sbmny = decSbSum.ToString("0.00");
                        int val = int.Parse(sbmny.Substring(sbmny.Length - 1, 1));

                        if (val > 0)
                        {
                            int amount = 0;

                            if (RoundingRule == "1" && SDYBFlag == false)
                            {
                                if (val < 5)
                                {
                                    amount = -1 * val;
                                }
                                else
                                {
                                    amount = 10 - val;
                                }

                                DataTable dtItem;
                                long l = this.objSvc.m_lngFindChargeItem(RoundingCode, out dtItem, this.m_objViewer.IsChildPrice);
                                if (l > 0 && dtItem.Rows.Count > 0)
                                {
                                    DataRow dr = dtItem.Rows[0];

                                    string[] sarr = new string[this.m_objViewer.ChargeDetail.Columns.Count];
                                    int row = this.m_objViewer.ChargeDetail.Rows.Count;
                                    this.m_objViewer.ChargeDetail.Rows.Add(sarr);

                                    //凑整费
                                    RoundingVal = clsPublic.ConvertObjToDecimal(dr["itemprice_mny"]) * amount;

                                    //赋值                         
                                    this.m_objViewer.ChargeDetail.Rows[row]["patientid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.PatientID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["registerid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.RegisterID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["orderexectype_int"] = "0";
                                    this.m_objViewer.ChargeDetail.Rows[row]["clacarea_chr"] = this.m_objViewer.objPatient.BihPatient_VO.AreaID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["createarea_chr"] = this.m_objViewer.objPatient.BihPatient_VO.AreaID;

                                    this.m_objViewer.ChargeDetail.Rows[row]["calccateid_chr"] = dr["itemipcalctype_chr"].ToString();
                                    this.m_objViewer.ChargeDetail.Rows[row]["invcateid_chr"] = dr["itemipinvtype_chr"].ToString();

                                    this.m_objViewer.ChargeDetail.Rows[row]["chargeitemid_chr"] = RoundingCode;
                                    this.m_objViewer.ChargeDetail.Rows[row]["chargeitemname_chr"] = dr["itemname_vchr"].ToString().Trim();
                                    this.m_objViewer.ChargeDetail.Rows[row]["unit_vchr"] = dr["itemunit_chr"].ToString();
                                    this.m_objViewer.ChargeDetail.Rows[row]["unitprice_dec"] = dr["itemprice_mny"].ToString();
                                    this.m_objViewer.ChargeDetail.Rows[row]["amount_dec"] = amount.ToString();
                                    this.m_objViewer.ChargeDetail.Rows[row]["discount_dec"] = "100";
                                    this.m_objViewer.ChargeDetail.Rows[row]["precent_dec"] = "100";
                                    this.m_objViewer.ChargeDetail.Rows[row]["createtype_int"] = "4";
                                    this.m_objViewer.ChargeDetail.Rows[row]["creator_chr"] = this.m_objViewer.LoginInfo.m_strEmpID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["activator_chr"] = this.m_objViewer.LoginInfo.m_strEmpID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["activatetype_int"] = "1";
                                    this.m_objViewer.ChargeDetail.Rows[row]["active_dat"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                    this.m_objViewer.ChargeDetail.Rows[row]["curareaid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.AreaID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["curbedid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.BedID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["doctorid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.DoctorID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["doctor_vchr"] = this.m_objViewer.objPatient.BihPatient_VO.DoctorName;
                                    this.m_objViewer.ChargeDetail.Rows[row]["doctorgroupid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.DoctorGroupID;

                                    this.m_objViewer.ChargeDetail.Rows[row]["spec_vchr"] = dr["itemspec_vchr"].ToString();

                                    this.m_objViewer.ChargeDetail.Rows[row]["totalmoney_dec"] = RoundingVal.ToString();
                                    this.m_objViewer.ChargeDetail.Rows[row]["acctmoney_dec"] = "0";

                                    this.m_objViewer.ChargeDetail.Rows[row]["des_vchr"] = "rounding";
                                    this.m_objViewer.ChargeDetail.Rows[row]["chargedoctorid_chr"] = this.m_objViewer.objPatient.BihPatient_VO.DoctorID;
                                    this.m_objViewer.ChargeDetail.Rows[row]["chargedoctor_vchr"] = this.m_objViewer.objPatient.BihPatient_VO.DoctorName;
                                    this.m_objViewer.ChargeDetail.Rows[row]["ybcode"] = dr["insuranceid_chr"].ToString();

                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion

                decTotalSum += RoundingVal;
                decSbSum += RoundingVal;
                decAcctSum = decTotalSum - decSbSum;

                objCharge_VO.TotalSum = decTotalSum;
                objCharge_VO.SbSum = decSbSum;
                objCharge_VO.AcctSum = decAcctSum;

                this.m_objViewer.lblTotalMoney.Text = objCharge_VO.TotalSum.ToString();
                this.m_objViewer.lblTotalMoney.Tag = objCharge_VO.TotalSum.ToString();
                if (objCharge_VO.SbSum > 0)
                {
                    this.m_objViewer.lblSbMoney.Text = objCharge_VO.SbSum.ToString();
                    this.m_objViewer.lblSbMoney.Tag = objCharge_VO.SbSum.ToString();
                }
                else
                {
                    this.m_objViewer.lblSbMoney.Tag = "0";
                }
                if (objCharge_VO.AcctSum > 0)
                {
                    this.m_objViewer.lblAcctMoney.Text = objCharge_VO.AcctSum.ToString();
                    this.m_objViewer.lblAcctMoney.Tag = objCharge_VO.AcctSum.ToString();
                }
                else
                {
                    this.m_objViewer.lblAcctMoney.Tag = "0";
                }
                #endregion

                #region 获取发票分类VO
                if (this.m_intGetInvCatDet(4, out InvoCatArr) == 1)
                {
                    for (int i = 0; i < InvoCatArr.Count; i++)
                    {
                        clsBihInvoiceCat_VO InvoiceCat_VO = InvoCatArr[i] as clsBihInvoiceCat_VO;

                        string[] s = new string[2];
                        s[0] = InvoiceCat_VO.ItemCatName;
                        s[1] = InvoiceCat_VO.TotalSum.ToString();

                        this.m_objViewer.dgInvoiceCat.Rows.Add(s);
                    }
                }
                #endregion

                #region 可用预交金
                bool IsUsePrepayMny = true;
                if (this.m_objViewer.ChargeType == 4)
                {
                    string parmval = clsPublic.m_strGetSysparm("0005").ToUpper();
                    if (parmval == "" || parmval == "F")
                    {
                        IsUsePrepayMny = false;
                    }
                }
                else if (this.m_objViewer.ChargeType == 5)
                {
                    string parmval = clsPublic.m_strGetSysparm("0006").ToUpper();
                    if (parmval == "" || parmval == "F")
                    {
                        IsUsePrepayMny = false;
                    }
                }

                if (this.m_objViewer.objPatient.BalancePrepayMoney > 0 && IsUsePrepayMny)
                {
                    this.m_objViewer.lblPreMoney.Text = "";
                    this.m_objViewer.lblPreMoney.Tag = "0";
                    this.m_objViewer.lblReturn.Tag = "0";

                    for (int i = 0; i < this.m_objViewer.objPatient.PrePayIDArr.Count; i++)
                    {
                        string s = this.m_objViewer.objPatient.PrePayIDArr[i].ToString();
                        string[] ss = new string[6];
                        ArrayList sarr = clsPublic.m_ArrGettoken(s, ";");
                        ss[0] = "F";
                        ss[1] = "F";
                        ss[2] = "";
                        ss[3] = sarr[1].ToString();
                        ss[4] = sarr[2].ToString();
                        ss[5] = sarr[0].ToString();

                        this.m_objViewer.dgPrePay.Rows.Add(ss);
                    }
                }
                #endregion

                #region 支付方式
                string[] paytype = new string[7];
                paytype[0] = "1.预交金";
                paytype[1] = "2.现金";
                paytype[2] = "3.支票";
                paytype[3] = "4.银行卡";
                paytype[4] = "5.其他";
                paytype[5] = "6.微信2";
                paytype[6] = "7.支付宝";        // 线下.支付宝

                this.m_objViewer.cboPayMode1.Items.Clear();
                this.m_objViewer.cboPayMode2.Items.Clear();
                for (int i = 0; i < paytype.Length; i++)
                {
                    this.m_objViewer.cboPayMode1.Items.Add(paytype[i]);
                    //第二种支付方式除预交金
                    if (i != 0)
                    {
                        this.m_objViewer.cboPayMode2.Items.Add(paytype[i]);
                    }
                }

                this.m_objViewer.cboPayMode1.SelectedIndex = 1;
                this.m_objViewer.cboPayMode2.SelectedIndex = -1;

                this.m_objViewer.lblChangeMoney.Tag = "";

                this.m_objViewer.txtPayMode1Money.Focus();

                //出院结算
                if (this.m_objViewer.ChargeType == 2)
                {
                    this.PrePayDeal = 1;

                    this.m_objViewer.chkAllSelect.Checked = true;
                }
                #endregion
            }
        }
        #endregion

        #region 直接结算初始化
        /// <summary>
        /// 直接结算初始化
        /// </summary>
        public void m_mthInitDir()
        {
            this.m_objViewer.lblTotalMoney.Text = "";
            this.m_objViewer.lblTotalMoney.Tag = "0";
            this.m_objViewer.lblSbMoney.Text = "";
            this.m_objViewer.lblSbMoney.Tag = "0";

            this.m_objViewer.cboPayMode1.Enabled = false;
            this.m_objViewer.cboPayMode2.Visible = false;
            this.m_objViewer.txtPayMode1Money.Enabled = false;
            this.m_objViewer.txtPayMode2Money.Visible = false;

            this.m_objViewer.btnYB.Enabled = false;
            this.m_objViewer.btnNewYB.Enabled = false;

            this.m_objViewer.dgPrePay.Enabled = false;
        }
        #endregion

        #region 找零
        /// <summary>
        /// 找零
        /// </summary>
        public void m_mthChangeMoney()
        {
            if (this.m_objViewer.lblSbMoney.Tag.ToString() == "0")
            {
                this.m_objViewer.lblChangeMoney.Text = "";
                this.m_objViewer.lblChangeMoney.Tag = "PASS";

                if (clsPublic.ConvertObjToDecimal(this.m_objViewer.txtPayMode1Money.Text) > 0)
                {
                    this.m_objViewer.lblReturnAndTransfer.Text = "退    款";
                    this.m_objViewer.lblReturnAndTransfer.ForeColor = Color.MediumBlue;

                    this.m_objViewer.lblReturn.Text = "";
                    this.m_objViewer.lblReturn.Tag = "0";
                    this.m_objViewer.lblReturn.ForeColor = Color.MediumBlue;
                }
                else
                {
                    this.m_objViewer.lblReturn.Text = this.m_objViewer.txtPayMode1Money.Text;
                    this.m_objViewer.lblReturn.Tag = this.m_objViewer.txtPayMode1Money.Text;
                }
                return;
            }

            string s1 = this.m_objViewer.txtPayMode1Money.Text.Trim();
            string s2 = this.m_objViewer.txtPayMode2Money.Text.Trim();

            if (s1 == "" && s2 == "")
            {
                this.m_objViewer.txtPayMode1Money.Enabled = true;
                this.m_objViewer.txtPayMode2Money.Visible = true;

                this.m_objViewer.cboPayMode1.Enabled = true;
                this.m_objViewer.cboPayMode1.Text = "";

                this.m_objViewer.cboPayMode2.Visible = true;
                this.m_objViewer.cboPayMode2.Text = "";

                this.m_objViewer.lblReturnAndTransfer.Text = "";
                this.m_objViewer.lblReturn.Text = "";
                this.m_objViewer.lblReturn.Tag = "0";
                this.m_objViewer.lblChangeMoney.Text = "";
                this.m_objViewer.lblChangeMoney.Tag = "0";

                this.m_objViewer.cboPayMode1.Focus();
                return;
            }

            if (s1 != "")
            {
                if (this.m_objViewer.cboPayMode1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择第一种支付方式。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtPayMode1Money.Text = "";
                    this.m_objViewer.cboPayMode1.Focus();
                    return;
                }

                if (s1 == "0")
                {
                    this.m_objViewer.txtPayMode1Money.Text = "";
                    this.m_objViewer.cboPayMode1.Focus();
                    return;
                }

                if (!Microsoft.VisualBasic.Information.IsNumeric(s1))
                {
                    MessageBox.Show("第一种支付方式的金额不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtPayMode1Money.Text = "";
                    this.m_objViewer.txtPayMode1Money.Focus();
                    return;
                }

                if (this.m_objViewer.cboPayMode1.SelectedIndex == 0)
                {
                    if (PrePayDeal == 0)
                    {
                        MessageBox.Show("当前预交金设置为不作支付，请选择另外一种支付方式。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.txtPayMode1Money.Text = "";
                        this.m_objViewer.cboPayMode1.Focus();
                        return;
                    }

                    if (this.m_objViewer.lblPreMoney.Text.Trim() != "")
                    {
                        if (Convert.ToDouble(s1) > Convert.ToDouble(this.m_objViewer.lblPreMoney.Tag))
                        {
                            MessageBox.Show("输入的金额大于预交金额，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.txtPayMode1Money.Text = "";
                            this.m_objViewer.lblReturn.Text = "";
                            this.m_objViewer.lblReturn.Tag = "0";
                            return;
                        }
                        else
                        {
                            if (this.m_objViewer.ChargeType == 1 || this.m_objViewer.ChargeType == 2)
                            {
                                decimal subval = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblPreMoney.Tag) - clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag);

                                if (subval >= 0)
                                {
                                    if (Convert.ToDouble(s1) < Convert.ToDouble(this.m_objViewer.lblSbMoney.Tag))
                                    {
                                        MessageBox.Show("输入预交金金额错误-当前冲帐预交金金额大于自付金额。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.m_objViewer.lblChangeMoney.Text = "";
                                        this.m_objViewer.lblChangeMoney.Tag = null;
                                        this.m_objViewer.txtPayMode1Money.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        this.m_objViewer.lblReturnAndTransfer.Text = "退预交金";
                                        this.m_objViewer.lblReturnAndTransfer.ForeColor = Color.MediumBlue;
                                        this.m_objViewer.lblReturn.ForeColor = Color.MediumBlue;
                                    }
                                }
                                else
                                {
                                    this.m_objViewer.lblReturnAndTransfer.Text = "补缴费用";
                                    this.m_objViewer.lblReturnAndTransfer.ForeColor = Color.Red;
                                    this.m_objViewer.lblReturn.ForeColor = Color.Red;
                                }

                                if (subval != 0)
                                {
                                    subval = Math.Abs(subval);
                                    this.m_objViewer.lblReturn.Text = subval.ToString("0.00");
                                    this.m_objViewer.lblReturn.Tag = subval.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("该病人没有预交金，请选择别的支付种类。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.txtPayMode1Money.Text = "";
                        this.m_objViewer.cboPayMode1.Focus();
                        return;
                    }
                }
            }
            else
            {
                s1 = "0";
            }

            if (s2 != "")
            {
                if (s1 == "0")
                {
                    MessageBox.Show("请优先选用第一种支付方式。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtPayMode2Money.Text = "";
                    return;
                }

                if (clsPublic.ConvertObjToDecimal(s1) >= clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag))
                {
                    this.m_objViewer.txtPayMode2Money.Text = "";
                    return;
                }

                if (this.m_objViewer.cboPayMode2.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择第二种支付方式。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.cboPayMode2.Focus();
                    return;
                }

                if (this.m_objViewer.cboPayMode1.SelectedIndex == (this.m_objViewer.cboPayMode2.SelectedIndex + 1))
                {
                    this.m_objViewer.txtPayMode2Money.Text = "";
                    MessageBox.Show("第二种支付方式不能与第一种支付方式相同，请重新选择。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.cboPayMode2.Focus();
                    return;
                }

                if (s2 == "0")
                {
                    this.m_objViewer.txtPayMode2Money.Text = "";
                    this.m_objViewer.cboPayMode2.Focus();
                    return;
                }

                if (!Microsoft.VisualBasic.Information.IsNumeric(s2))
                {
                    MessageBox.Show("第二种支付方式的金额不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtPayMode2Money.Focus();
                    return;
                }
            }
            else
            {
                s2 = "0";
            }

            double money = Convert.ToDouble(s1) + Convert.ToDouble(s2) - Convert.ToDouble(this.m_objViewer.lblSbMoney.Tag.ToString());

            if (money >= 0)
            {
                bool tmpB = false;

                if (PrePayDeal != 0)
                {
                    if (this.m_objViewer.cboPayMode1.SelectedIndex != 0 && Convert.ToDouble(this.m_objViewer.lblPreMoney.Tag) > 0)
                    {
                        this.m_objViewer.lblReturnAndTransfer.Text = "退预交金";
                        this.m_objViewer.lblReturnAndTransfer.ForeColor = Color.MediumBlue;

                        this.m_objViewer.lblReturn.Text = this.m_objViewer.lblPreMoney.Text;
                        this.m_objViewer.lblReturn.Tag = this.m_objViewer.lblPreMoney.Tag;

                        tmpB = true;
                    }
                }

                if (this.m_objViewer.cboPayMode1.SelectedIndex == 0 && Convert.ToDouble(s1) > 0)
                {
                    if (Convert.ToDouble(s1) < Convert.ToDouble(this.m_objViewer.lblSbMoney.Tag.ToString()))
                    {
                        money += Convert.ToDouble(this.m_objViewer.lblPreMoney.Tag) - Convert.ToDouble(s1);
                    }
                    else
                    {
                        money = Convert.ToDouble(this.m_objViewer.lblPreMoney.Tag) + Convert.ToDouble(s2) - Convert.ToDouble(this.m_objViewer.lblSbMoney.Tag.ToString());
                    }
                }

                if (tmpB)
                {
                    money += Convert.ToDouble(this.m_objViewer.lblPreMoney.Tag);
                }

                //转预交金
                if (this.PrePayDeal == 2)
                {
                    //   money = money - Convert.ToDouble(this.m_objViewer.lblReturn.Tag);
                }

                if (money > 0)
                {
                    this.m_objViewer.lblChangeMoney.Text = money.ToString("0.00");
                    this.m_objViewer.lblChangeMoney.Tag = "PASS";
                }
                else if (money == 0)
                {
                    this.m_objViewer.lblChangeMoney.Text = "";
                    this.m_objViewer.lblChangeMoney.Tag = "PASS";
                }
            }
            else
            {
                if (this.m_objViewer.lblPreMoney.Text.Trim() == "")
                {
                    this.m_objViewer.lblReturn.Text = "";
                    this.m_objViewer.lblReturn.Tag = "0";
                }

                this.m_objViewer.lblChangeMoney.Text = "";
                this.m_objViewer.lblChangeMoney.Tag = "0";
            }
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        public void m_mthReckoning()
        {
            #region 数据校验
            if (this.m_objViewer.btnReckoning.Tag != null && this.m_objViewer.btnReckoning.Tag.ToString().Trim() != "")
            {
                MessageBox.Show("已结算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.m_objViewer.lblSbMoney.Text.Trim() != "" && this.m_objViewer.txtPayMode1Money.Text.Trim() == "" && this.m_objViewer.txtPayMode2Money.Text.Trim() == "")
            {
                return;
            }

            if (this.m_objViewer.cboPayMode1.SelectedIndex == -1)
            {
                this.m_objViewer.txtPayMode1Money.Text = "";
            }

            if (this.m_objViewer.cboPayMode2.SelectedIndex == -1)
            {
                this.m_objViewer.txtPayMode2Money.Text = "";
            }

            if (this.m_objViewer.ChargeType == 2)
            {
                int count = this.m_objViewer.dgPrePay.Rows.Count;
                if (count > 0)
                {
                    int nums = 0;
                    for (int i = 0; i < count; i++)
                    {
                        if (this.m_objViewer.dgPrePay.Rows[i].Cells["colSelectBool"].Value.ToString().Trim() == "T")
                        {
                            nums++;
                        }
                    }
                    if (nums != count)
                    {
                        if (MessageBox.Show("存在" + Convert.ToString(count - nums) + "笔预交金未冲帐，是否继续结算？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }

            //支付方式 -1 取消支付 0 全记帐 1 支付 
            int pm1 = 0;
            int pm2 = 0;
            if (this.m_objViewer.lblSbMoney.Tag != null && clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag) != 0)
            {
                if (this.m_objViewer.cboPayMode1.SelectedIndex == -1 && this.m_objViewer.cboPayMode2.SelectedIndex == -1)
                {
                    return;
                }

                if (this.PrePayIDArr != null && this.PrePayIDArr.Count > 0)
                {
                    if (this.m_objViewer.cboPayMode1.SelectedIndex != 0)
                    {
                        MessageBox.Show("由于你已经选择预交款冲帐，所以请相应使用预交款为支付方式。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                pm1 = -1;
                if (this.m_objViewer.cboPayMode1.SelectedIndex > -1)
                {
                    string s = this.m_objViewer.txtPayMode1Money.Text.Trim();
                    if (s != "")
                    {
                        if (!Microsoft.VisualBasic.Information.IsNumeric(s))
                        {
                            MessageBox.Show("第一种支付方式金额输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.txtPayMode1Money.Focus();
                            return;
                        }
                        else
                        {
                            pm1 = 1;
                        }
                    }
                }

                pm2 = -1;
                if (this.m_objViewer.cboPayMode2.SelectedIndex > -1)
                {
                    string s = this.m_objViewer.txtPayMode2Money.Text.Trim();
                    if (s != "")
                    {
                        if (!Microsoft.VisualBasic.Information.IsNumeric(s))
                        {
                            MessageBox.Show("第二种支付方式金额输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.txtPayMode2Money.Focus();
                            return;
                        }
                        else
                        {
                            pm2 = 1;
                        }
                    }
                }

                if ((this.m_objViewer.lblChangeMoney.Tag == null || this.m_objViewer.lblChangeMoney.Tag.ToString().Trim() == "0") && (PrePayDeal == 0 || PrePayDeal == 1))
                {
                    return;
                }
            }

            #endregion

            #region 检测社保病人社保没结算成功就不能做HIS结算
            if (this.objSvc.m_blnCheckYBChargeSuccessFull(this.m_objViewer.objPatient.RegisterID))
            {
                MessageBox.Show("该社保病人没有做社保结算，请先做社保结算！", "提示", MessageBoxButtons.OK);
                return;
            }
            #endregion

            #region 发票号检验
            string invono = this.m_objViewer.txtInvono.Text.Trim();
            if (!clsPublic.m_blnCheckInvoExpression(invono))
            {
                MessageBox.Show("输入的发票号不符合规定的发票号规则，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtInvono.Focus();
                this.m_objViewer.lblHint.Visible = true;
                return;
            }

            if (clsPublic.m_blnCheckInvoIsUsed(invono))
            {
                MessageBox.Show("输入的发票号已经被使用，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtInvono.Focus();
                this.m_objViewer.lblHint.Visible = true;
                return;
            }
            #endregion

            #region 生成预交金VO(转下期.暂不启用)
            string PrePayNo = "";
            bool PrePayFlag = false;
            clsBihPrePay_VO PrePay_VO = null;
            if (this.PrePayDeal == 2)
            {
                decimal prepaymoney = Convert.ToDecimal(this.m_objViewer.lblReturn.Tag);
                if (prepaymoney > 0)
                {
                    PrePayNo = clsPublic.m_strGetCurrPrepayNo();
                    if (PrePayNo == "")
                    {
                        if (!this.m_blnPrePayNoInput(ref PrePayNo))
                        {
                            return;
                        }
                    }

                    if (!clsPublic.m_blnCheckPrepayNoExpression(PrePayNo))
                    {
                        MessageBox.Show("本地当前预交金收据的编号不符合编码规则，请重新设置(与当前打印票据号相同)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!this.m_blnPrePayNoInput(ref PrePayNo))
                        {
                            return;
                        }
                    }

                    if (clsPublic.m_blnCheckPrepayNoIsUsed(PrePayNo, 0))
                    {
                        MessageBox.Show("本地当前预交金收据的编号已经被使用，请重新设置(与当前打印票据号相同)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!this.m_blnPrePayNoInput(ref PrePayNo))
                        {
                            return;
                        }
                    }

                    PrePay_VO = new clsBihPrePay_VO();
                    PrePay_VO.strPrePayInv = PrePayNo;
                    PrePay_VO.strPatientID = this.m_objViewer.objPatient.BihPatient_VO.PatientID;
                    PrePay_VO.strRegisterID = this.m_objViewer.objPatient.RegisterID;
                    PrePay_VO.decMoney = prepaymoney;
                    PrePay_VO.intPayType = 1;
                    PrePay_VO.intCuyCate = 4;
                    PrePay_VO.strAreaID = this.m_objViewer.objPatient.BihPatient_VO.AreaID;
                    PrePay_VO.strDes = "中途结算结转";
                    PrePay_VO.strCreatorID = this.m_objViewer.LoginInfo.m_strEmpID;
                    PrePay_VO.intUpType = 0;
                    PrePay_VO.strPatientName = this.m_objViewer.objPatient.lblName.Text;
                    PrePay_VO.strAreaName = this.m_objViewer.objPatient.txtArea.Text;

                    PrePayFlag = true;
                }
            }
            #endregion

            this.m_objViewer.Cursor = Cursors.WaitCursor;

            #region 生成结算VO
            clsBihCharge_VO Charge_VO = new clsBihCharge_VO();
            Charge_VO.PatientID = this.m_objViewer.objPatient.BihPatient_VO.PatientID;
            Charge_VO.CurrAreaID = this.m_objViewer.objPatient.BihPatient_VO.AreaID;
            Charge_VO.RegisterID = this.m_objViewer.objPatient.RegisterID;
            Charge_VO.PayTypeID = this.m_objViewer.objPatient.BihPatient_VO.PayTypeID;
            Charge_VO.PatientType = this.m_objViewer.objPatient.BihPatient_VO.InType;
            Charge_VO.TotalSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            Charge_VO.SbSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag.ToString());
            Charge_VO.AcctSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblAcctMoney.Tag.ToString());
            Charge_VO.OperEmp = this.m_objViewer.LoginInfo.m_strEmpID;
            Charge_VO.BillNO = YBBillNO;

            int intparm = clsPublic.m_intGetSysParm("1119");
            if (intparm == 1)
            {
                #region 母婴结算记录婴儿结算VO by yibing.zheng 09-07-04

                //母婴结算记录婴儿结算VO
                DataTable dtbBabyInfo = null;
                this.objSvc.m_lngGetBabyRegisterId(this.m_objViewer.objPatient.BihPatient_VO.RegisterID, out dtbBabyInfo);

                if (dtbBabyInfo.Rows.Count > 0)
                {
                    DataRow dr = null;
                    Charge_VO.m_objBabyInfoVo = new clsBihPatient_VO[dtbBabyInfo.Rows.Count];
                    for (int i1 = 0; i1 < dtbBabyInfo.Rows.Count; i1++)
                    {
                        dr = dtbBabyInfo.Rows[i1];

                        Charge_VO.m_objBabyInfoVo[i1] = new clsBihPatient_VO();
                        Charge_VO.m_objBabyInfoVo[i1].PatientID = dr["patientid_chr"].ToString();
                        Charge_VO.m_objBabyInfoVo[i1].RegisterID = dr["registerid_chr"].ToString();
                        Charge_VO.m_objBabyInfoVo[i1].AreaID = dr["areaid_chr"].ToString();
                        Charge_VO.m_objBabyInfoVo[i1].PayTypeID = dr["paytypeid_chr"].ToString();


                    }
                }
                #endregion
            }

            #endregion

            #region 生成结算分类VO
            //核算分类
            ArrayList ChargeCatArr = new ArrayList();
            if (this.m_intGetCalcCatDet(3, out ChargeCatArr) == -1)
            {
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }
            #endregion

            #region 生成发票VO
            clsBihInvoice_VO Invoice_VO = new clsBihInvoice_VO();
            Invoice_VO.InvoiceNo = invono;
            Invoice_VO.TotalSum = Convert.ToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            Invoice_VO.SbSum = Convert.ToDecimal(this.m_objViewer.lblSbMoney.Tag.ToString());
            Invoice_VO.AcctSum = Convert.ToDecimal(this.m_objViewer.lblAcctMoney.Tag.ToString());
            Invoice_VO.Status = 1;
            Invoice_VO.Split = 0;
            #endregion

            #region 获取发票分类VO
            if (InvoCatArr.Count == 0)
            {
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }
            #endregion

            #region 生成支付VO
            ArrayList PaymentArr = new ArrayList();
            //全记帐时登记一条0记录

            if (clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag) == 0)
            {
                clsBihPayment_VO Payment_VO = new clsBihPayment_VO();

                if (this.m_objViewer.cboPayMode1.SelectedIndex != -1)
                {
                    Payment_VO.PayType = this.m_objViewer.cboPayMode1.SelectedIndex;
                    Payment_VO.PaySum = clsPublic.ConvertObjToDecimal(this.m_objViewer.txtPayMode1Money.Text);
                }
                else
                {
                    Payment_VO.PayType = 4;
                    Payment_VO.PaySum = 0;
                }
                Payment_VO.RefuSum = Payment_VO.PaySum;

                PaymentArr.Add(Payment_VO);
            }
            else
            {
                if (pm1 == 1 && pm2 == -1)
                {
                    clsBihPayment_VO Payment1_VO = new clsBihPayment_VO();
                    Payment1_VO.PayType = this.m_objViewer.cboPayMode1.SelectedIndex;
                    Payment1_VO.PaySum = clsPublic.ConvertObjToDecimal(this.m_objViewer.txtPayMode1Money.Text);
                    Payment1_VO.RefuSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblChangeMoney.Text);
                    PaymentArr.Add(Payment1_VO);
                }
                else if (pm1 == 1 && pm2 == 1)
                {
                    clsBihPayment_VO Payment1_VO = new clsBihPayment_VO();
                    Payment1_VO.PayType = this.m_objViewer.cboPayMode1.SelectedIndex;
                    Payment1_VO.PaySum = clsPublic.ConvertObjToDecimal(this.m_objViewer.txtPayMode1Money.Text);
                    Payment1_VO.RefuSum = 0;
                    PaymentArr.Add(Payment1_VO);

                    clsBihPayment_VO Payment2_VO = new clsBihPayment_VO();
                    Payment2_VO.PayType = this.m_objViewer.cboPayMode2.SelectedIndex + 1;
                    Payment2_VO.PaySum = clsPublic.ConvertObjToDecimal(this.m_objViewer.txtPayMode2Money.Text);
                    Payment2_VO.RefuSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblChangeMoney.Text);
                    PaymentArr.Add(Payment2_VO);
                }
            }
            #endregion

            #region 获取审核信息
            clsBihConfirm_VO Confirm_VO = new clsBihConfirm_VO();
            if (this.m_objViewer.ChargeType == 5)
            {
                if (this.m_objViewer.ConfirmID.Trim() == "" || this.m_objViewer.ConfirmName.Trim() == "")
                {
                    MessageBox.Show("确认(审核人)信息不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            Confirm_VO.EmpId = this.m_objViewer.ConfirmID;
            Confirm_VO.EmpName = this.m_objViewer.ConfirmName;
            #endregion

            #region 保存
            //结算号
            string ChargeNo = "";
            long l = this.objSvc.m_lngReckoning(this.m_objViewer.ChargeDetail, this.m_objViewer.DayChrgType, this.m_objViewer.DayAccountsArr, Charge_VO, ChargeCatArr, Invoice_VO, InvoCatArr, PaymentArr, PrePayDeal, PrePayIDArr, this.m_objViewer.ChargeType, Confirm_VO, out ChargeNo);
            if (l > 0)
            {
                this.m_objViewer.btnReckoning.Tag = ChargeNo;
                //保存当前发票号                
                clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, invono, 1);
                this.m_blnSaveInvoiceNo(invono);
                //打印发票
                clsPBNetPrint.m_mthPrintInvoiceBill(ChargeNo, "", 2, this.HospitalName);
                //成功返回
                this.m_objViewer.DialogResult = DialogResult.OK;
            }
            else
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("结算失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region 获取核算分类
        /// <summary>
        /// 获取核算分类
        /// </summary>
        /// <param name="type">3 住院核算</param>
        /// <param name="objCarArr"></param>
        /// <returns></returns>
        private int m_intGetCalcCatDet(int type, out ArrayList objCarArr)
        {
            objCarArr = new ArrayList();
            string catcol = "calccateid_chr";
            DataTable dtCat = new DataTable();

            long l = this.objSvc.m_lngGetChargeItemCat(type, out dtCat);
            if (l > 0 && dtCat.Rows.Count > 0)
            {
                string catid = "";

                //创建原始分类表结构
                DataTable dtCatOrg = new DataTable();
                for (int i = 0; i < dtCat.Rows.Count; i++)
                {
                    catid = dtCat.Rows[i]["typeid_chr"].ToString().Trim();
                    dtCatOrg.Columns.Add(catid, typeof(System.Decimal));
                    dtCatOrg.Columns.Add(catid + "_SB", typeof(System.Decimal));
                }

                string deptid = "";
                Hashtable hasDept = new Hashtable();
                for (int i = 0; i < this.m_objViewer.ChargeDetail.Rows.Count; i++)
                {
                    deptid = this.m_objViewer.ChargeDetail.Rows[i]["clacarea_chr"].ToString().Trim();

                    if (deptid == "")
                    {
                        MessageBox.Show(this.m_objViewer.ChargeDetail.Rows[i]["chargeitemname_chr"].ToString() + " ---> 收费明细存在执行科室为空，结帐终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return -1;
                    }

                    if (hasDept.ContainsKey(deptid))
                    {
                        continue;
                    }

                    hasDept.Add(deptid, null);
                }

                if (hasDept.Count == 0)
                {
                    return -1;
                }

                decimal dacctcatsum = 0;

                ArrayList DeptIDArr = new ArrayList();
                DeptIDArr.AddRange(hasDept.Keys);

                DataView dv = new DataView(this.m_objViewer.ChargeDetail);

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    deptid = DeptIDArr[i].ToString();

                    dv.RowFilter = "clacarea_chr = '" + deptid + "'";

                    DataTable dt = new DataTable();
                    dt = dtCatOrg.Clone();
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dr[dt.Columns[j].ColumnName] = 0;
                    }

                    foreach (DataRowView drv in dv)
                    {
                        catid = drv[catcol].ToString().Trim();
                        if (catid == "")
                        {
                            MessageBox.Show("收费明细存在住院核算分类为空，结帐终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return -1;
                        }

                        decimal dtotal = clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]), 2) - clsPublic.ConvertObjToDecimal(drv["chargetotalsum"]);
                        decimal dsb = clsPublic.Round(dtotal * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);

                        dr[catid] = clsPublic.ConvertObjToDecimal(dr[catid]) + dtotal;
                        dr[catid + "_SB"] = clsPublic.ConvertObjToDecimal(dr[catid + "_SB"]) + dsb;
                    }

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        catid = dt.Columns[j].ColumnName;
                        if (catid.IndexOf("_SB") > 0)
                        {
                            continue;
                        }

                        clsBihChargeCat_VO ChargeCat_VO = new clsBihChargeCat_VO();
                        ChargeCat_VO.DeptID = deptid;
                        ChargeCat_VO.ItemCatID = catid;
                        ChargeCat_VO.TotalSum = clsPublic.ConvertObjToDecimal(dr[catid]);
                        ChargeCat_VO.AcctSum = clsPublic.ConvertObjToDecimal(dr[catid]) - clsPublic.ConvertObjToDecimal(dr[catid + "_SB"]);

                        dacctcatsum += ChargeCat_VO.AcctSum;

                        objCarArr.Add(ChargeCat_VO);
                    }
                }

                if (YBChargeFlag && dacctcatsum != objCharge_VO.AcctSum)
                {
                    //记帐差额补在最后一科室最后一项核算分类                        
                    ((clsBihChargeCat_VO)objCarArr[objCarArr.Count - 1]).AcctSum += objCharge_VO.AcctSum - dacctcatsum;
                }
            }
            else
            {
                return -1;
            }

            return 1;
        }
        #endregion

        #region 获取发票分类
        /// <summary>
        /// 获取发票分类
        /// </summary>
        /// <param name="type">4 住院发票</param>
        /// <param name="objCarArr"></param>
        /// <returns></returns>
        private int m_intGetInvCatDet(int type, out ArrayList objCarArr)
        {
            objCarArr = new ArrayList();

            DataView dv = new DataView(this.m_objViewer.ChargeDetail);
            DataTable dtCat = new DataTable();
            long l = this.objSvc.m_lngGetChargeItemCat(type, out dtCat);
            string strDiffCostName = string.Empty;//药品让利发票分类名称
            // 总让利金额
            decimal decDiffCostSum = 0, decDiffCost = 0;
            if (l > 0 && dtCat.Rows.Count > 0)
            {
                //分项医保合计
                decimal dacctcatsum = 0;
                //凑整分类负数调整
                bool RoundingFlag = false;
                for (int i = 0; i < dtCat.Rows.Count; i++)
                {
                    string catid = dtCat.Rows[i]["typeid_chr"].ToString().Trim();
                    string catname = dtCat.Rows[i]["typename_vchr"].ToString().Trim();

                    decimal dtotal = 0;
                    decimal dsb = 0;

                    dv.RowFilter = "invcateid_chr = '" + catid + "'";
                    foreach (DataRowView drv in dv)
                    {
                        catid = drv["invcateid_chr"].ToString().Trim();
                        if (catid == "")
                        {
                            MessageBox.Show("收费明细存在住院发票分类为空，结帐终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return -1;
                        }

                        decimal dc = clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]), 2) - clsPublic.ConvertObjToDecimal(drv["chargetotalsum"]);
                        dtotal += dc;
                        dsb += clsPublic.Round(dc * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);
                        if (this.intDiffCostOn == 1)
                        {
                            decDiffCost = clsPublic.ConvertObjToDecimal(drv["totaldiffcostmoney_dec"]);
                            decDiffCostSum += decDiffCost;
                            dtotal += decDiffCost;
                            dsb += decDiffCost;
                        }
                    }

                    if (dtotal == 0)
                    {
                        if (string.IsNullOrEmpty(strDiffCostName) && string.Compare("3026", catid) == 0)
                        {
                            strDiffCostName = dtCat.Rows[i]["typename_vchr"].ToString().Trim();//获取药品让利在字典中的名称
                        }
                        continue;
                    }
                    else if (dtotal < 0)
                    {
                        RoundingFlag = true;
                    }

                    clsBihInvoiceCat_VO InvoiceCat_VO = new clsBihInvoiceCat_VO();
                    InvoiceCat_VO.ItemCatID = catid;
                    InvoiceCat_VO.ItemCatName = catname;
                    InvoiceCat_VO.TotalSum = dtotal;
                    InvoiceCat_VO.AcctSum = dtotal - dsb;

                    dacctcatsum += InvoiceCat_VO.AcctSum;

                    objCarArr.Add(InvoiceCat_VO);
                }

                if (YBChargeFlag && dacctcatsum != objCharge_VO.AcctSum)
                {
                    //记帐差额补在最后一项发票分类                        
                    ((clsBihInvoiceCat_VO)objCarArr[objCarArr.Count - 1]).AcctSum += objCharge_VO.AcctSum - dacctcatsum;
                }
                if (this.intDiffCostOn == 1)
                {
                    clsBihInvoiceCat_VO InvoiceCat_VO = new clsBihInvoiceCat_VO();
                    InvoiceCat_VO.ItemCatID = "3026";
                    InvoiceCat_VO.ItemCatName = strDiffCostName;
                    InvoiceCat_VO.TotalSum = clsPublic.Round(decDiffCostSum, 2);
                    InvoiceCat_VO.AcctSum = 0;

                    objCarArr.Add(InvoiceCat_VO);
                }
                if (RoundingFlag)
                {
                    for (int i = 0; i < objCarArr.Count; i++)
                    {
                        clsBihInvoiceCat_VO InvoiceCat_VO1 = objCarArr[i] as clsBihInvoiceCat_VO;
                        if (InvoiceCat_VO1.TotalSum < 0)
                        {
                            for (int j = 0; j < objCarArr.Count; j++)
                            {
                                clsBihInvoiceCat_VO InvoiceCat_VO2 = objCarArr[j] as clsBihInvoiceCat_VO;
                                if (InvoiceCat_VO2.TotalSum + InvoiceCat_VO1.TotalSum > 0)
                                {
                                    InvoiceCat_VO2.TotalSum = InvoiceCat_VO2.TotalSum + InvoiceCat_VO1.TotalSum;
                                    objCarArr.RemoveAt(i);
                                    return 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return -1;
            }

            return 1;
        }
        #endregion

        #region 获得核算、发票分类明细
        /// <summary>
        /// 获得核算、发票分类明细
        /// </summary>
        /// <param name="type">3 住院核算 4 住院发票</param>
        /// <param name="objCarArr"></param>
        private int m_intGetCatdet(int type, out ArrayList objCarArr)
        {
            objCarArr = new ArrayList();

            string catcol = "";
            string msg = "";
            if (type == 3)
            {
                catcol = "calccateid_chr";
                msg = "住院核算";
            }
            else if (type == 4)
            {
                catcol = "invcateid_chr";
                msg = "住院发票";
            }

            DataTable dtCat = new DataTable();
            long l = this.objSvc.m_lngGetChargeItemCat(type, out dtCat);
            if (l > 0 && dtCat.Rows.Count > 0)
            {
                string catid = "";

                //创建原始分类表结构
                DataTable dtCatOrg = new DataTable();
                for (int i = 0; i < dtCat.Rows.Count; i++)
                {
                    catid = dtCat.Rows[i]["typeid_chr"].ToString().Trim();
                    dtCatOrg.Columns.Add(catid, typeof(System.Decimal));
                    dtCatOrg.Columns.Add(catid + "_SB", typeof(System.Decimal));
                }

                string deptid = "";
                Hashtable hasDept = new Hashtable();
                for (int i = 0; i < this.m_objViewer.ChargeDetail.Rows.Count; i++)
                {
                    deptid = this.m_objViewer.ChargeDetail.Rows[i]["clacarea_chr"].ToString().Trim();

                    if (deptid == "")
                    {
                        MessageBox.Show("收费明细存在执行科室为空，结帐终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return -1;
                    }

                    if (hasDept.ContainsKey(deptid))
                    {
                        continue;
                    }

                    hasDept.Add(deptid, null);
                }

                if (hasDept.Count == 0)
                {
                    return -1;
                }

                ArrayList DeptIDArr = new ArrayList();
                DeptIDArr.AddRange(hasDept.Keys);

                DataView dv = new DataView(this.m_objViewer.ChargeDetail);

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    deptid = DeptIDArr[i].ToString();

                    dv.RowFilter = "clacarea_chr = '" + deptid + "'";

                    DataTable dt = new DataTable();
                    dt = dtCatOrg.Clone();
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dr[dt.Columns[j].ColumnName] = 0;
                    }

                    foreach (DataRowView drv in dv)
                    {
                        catid = drv[catcol].ToString().Trim();
                        if (catid == "")
                        {
                            MessageBox.Show("收费明细存在" + msg + "分类为空，结帐终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return -1;
                        }

                        decimal dtotal = clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]), 2) - clsPublic.ConvertObjToDecimal(drv["chargetotalsum"]);
                        decimal dsb = clsPublic.Round(dtotal * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);

                        dr[catid] = clsPublic.ConvertObjToDecimal(dr[catid]) + dtotal;
                        dr[catid + "_SB"] = clsPublic.ConvertObjToDecimal(dr[catid + "_SB"]) + dsb;
                    }

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        catid = dt.Columns[j].ColumnName;
                        if (catid.IndexOf("_SB") > 0)
                        {
                            continue;
                        }
                        if (clsPublic.ConvertObjToDecimal(dr[catid]) > 0)
                        {
                            if (type == 3)
                            {
                                clsBihChargeCat_VO ChargeCat_VO = new clsBihChargeCat_VO();
                                ChargeCat_VO.DeptID = deptid;
                                ChargeCat_VO.ItemCatID = catid;
                                ChargeCat_VO.TotalSum = clsPublic.ConvertObjToDecimal(dr[catid]);
                                ChargeCat_VO.AcctSum = clsPublic.ConvertObjToDecimal(dr[catid]) - clsPublic.ConvertObjToDecimal(dr[catid + "_SB"]);

                                objCarArr.Add(ChargeCat_VO);
                            }
                            else if (type == 4)
                            {
                                clsBihInvoiceCat_VO InvoCat_VO = new clsBihInvoiceCat_VO();
                                InvoCat_VO.ItemCatID = catid;
                                InvoCat_VO.TotalSum = clsPublic.ConvertObjToDecimal(dr[catid]);
                                InvoCat_VO.AcctSum = clsPublic.ConvertObjToDecimal(dr[catid]) - clsPublic.ConvertObjToDecimal(dr[catid + "_SB"]);

                                objCarArr.Add(InvoCat_VO);
                            }
                        }
                    }
                }
            }
            else
            {
                return -1;
            }

            return 1;
        }
        #endregion

        #region 保存当前发票号
        /// <summary>
        /// 保存当前发票号
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        public bool m_blnSaveInvoiceNo(string CurrNo)
        {
            return clsPublic.m_blnWriteXML("BeInHospital", "CurrInvoiceNo", "AnyOne", CurrNo);
        }
        #endregion

        #region 输入预交金单据号
        /// <summary>
        /// 输入预交金单据号
        /// </summary>
        /// <param name="prepayno"></param>
        /// <returns></returns>
        public bool m_blnPrePayNoInput(ref string prepayno)
        {
            bool b = false;

            frmPrePayNoInput fppni = new frmPrePayNoInput();
            if (fppni.ShowDialog() == DialogResult.OK)
            {
                prepayno = fppni.NewNo;
                b = true;
            }

            return b;
        }
        #endregion

        #region 保存预交金收据号
        /// <summary>
        /// 保存预交金收据号
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        public bool m_blnSavePrePayBillNo(string CurrNo)
        {
            return clsPublic.m_blnWriteXML("BeInHospital", "CurrPrepayBillNo", "AnyOne", CurrNo);
        }
        #endregion

        #region 选择预交金冲帐
        /// <summary>
        /// 选择预交金冲帐
        /// </summary>        
        public void m_mthStrikeBal()
        {
            if (this.m_objViewer.ChargeType == 3 || this.m_objViewer.ChargeType == 6)
            {
                return;
            }

            decimal decTotal = 0;
            PrePayIDArr = null;
            PrePayIDArr = new ArrayList();
            this.PrePayDeal = 0;

            for (int i = 0; i < this.m_objViewer.dgPrePay.Rows.Count; i++)
            {
                if (this.m_objViewer.dgPrePay.Rows[i].Cells["colSelectBool"].Value.ToString().Trim() == "T")
                {
                    decimal money = clsPublic.ConvertObjToDecimal(this.m_objViewer.dgPrePay.Rows[i].Cells["colPrePayMoney"].Value);

                    decTotal += money;
                    PrePayIDArr.Add(this.m_objViewer.dgPrePay.Rows[i].Cells["colPrePayID"].Value.ToString());
                    this.PrePayDeal = 1;
                }
            }

            if (decTotal != 0)
            {
                this.m_objViewer.cboPayMode1.SelectedIndex = 0;
                this.m_objViewer.lblPreMoney.Text = decTotal.ToString();
            }
            else
            {
                this.m_objViewer.cboPayMode1.SelectedIndex = 1;
                this.m_objViewer.lblPreMoney.Text = "";
            }
            this.m_objViewer.lblPreMoney.Tag = decTotal.ToString();
        }

        /// <summary>
        /// 设置预交金为支付方式
        /// </summary>
        public void m_mthSetPrepay()
        {
            //全记帐返回
            if (this.m_objViewer.lblSbMoney.Tag.ToString() == "0")
            {
                return;
            }

            if (this.m_objViewer.ChargeType == 3 || this.m_objViewer.ChargeType == 6)
            {
                return;
            }

            this.m_objViewer.txtPayMode1Money.Text = "";
            this.m_objViewer.txtPayMode2Money.Text = "";
            //this.m_mthChangeMoney();
            this.m_mthStrikeBal();

            decimal PreMoney = 0;
            if (this.m_objViewer.lblPreMoney.Text.Trim() != "")
            {
                PreMoney = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblPreMoney.Text);
            }
            else
            {
                return;
            }

            this.m_objViewer.txtPayMode1Money.Text = PreMoney.ToString();

            if (PreMoney >= clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag))
            {
                this.m_objViewer.cboPayMode2.Visible = false;
                this.m_objViewer.txtPayMode2Money.Visible = false;
                this.m_objViewer.btnReckoning.Focus();
            }
        }

        /// <summary>
        /// 重置预交金
        /// </summary>
        public void m_mthReSetPrepay()
        {
            if (this.m_objViewer.lblPreMoney.Text.Trim() == "")
            {
                return;
            }
            else
            {
                for (int i = 0; i < this.m_objViewer.dgPrePay.Rows.Count; i++)
                {
                    this.m_objViewer.dgPrePay.Rows[i].Cells["colSelectBool"].Value = "F";
                    this.m_objViewer.dgPrePay.Rows[i].Cells["colStrikeBal"].Value = "";
                }

                this.m_mthStrikeBal();

                this.m_objViewer.chkAllSelect.Checked = false;
            }
        }

        /// <summary>
        /// 全选预交金
        /// </summary>
        public void m_mthAllSelectPrepay()
        {
            for (int i = 0; i < this.m_objViewer.dgPrePay.Rows.Count; i++)
            {
                this.m_objViewer.dgPrePay.Rows[i].Cells["colSelectBool"].Value = "T";
                this.m_objViewer.dgPrePay.Rows[i].Cells["colStrikeBal"].Value = "冲";
            }

            this.m_mthStrikeBal();

            if (clsPublic.ConvertObjToDecimal(this.m_objViewer.lblPreMoney.Tag) > 0)
            {
                this.m_objViewer.txtPayMode1Money.Text = this.m_objViewer.lblPreMoney.Tag.ToString();
            }

            decimal PreMoney = 0;
            if (this.m_objViewer.lblPreMoney.Text.Trim() != "")
            {
                PreMoney = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblPreMoney.Text);

                this.m_objViewer.txtPayMode1Money.Text = PreMoney.ToString();

                if (PreMoney >= clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag))
                {
                    this.m_objViewer.cboPayMode2.Visible = false;
                    this.m_objViewer.txtPayMode2Money.Visible = false;
                    this.m_objViewer.btnReckoning.Focus();
                }
            }
        }
        #endregion

        #region 医保结算
        /// <summary>
        /// 医保结算(统一入口)
        /// </summary>
        public void m_mthYB(bool blNewYB)
        {
            if (YBType == "001")
            {
                this.m_mthYB_F2();
            }
            else if (YBType == "002")
            {
                this.m_mthYB_CS(blNewYB);
            }
            else if (YBType == "003")
            {
            }
            else if (YBType == "006")
            {
                this.m_mthYB_TS();
            }
        }

        #region 江门台山医保结算
        /// <summary>
        /// 江门台山医保结算
        /// xiaoxia.yu add in 2007.11.30
        /// </summary>
        private void m_mthYB_TS()
        {
            long lngRes = 0;
            long lngRes1 = 0;

            //lngRes = objSvc.m_lngInsertRegisterCharge(this.m_objViewer.objPatient.BihPatient_VO.Zyh);
            //if (lngRes > 0)
            //{
            //lngRes1 = objSvc.m_lngInsertRegister(this.m_objViewer.objPatient.BihPatient_VO.Zyh);
            //}
            //if (lngRes1 > 0)
            //{
            //    MessageBox.Show("数据上传成功,请进医保系统结算!");
            //    this.m_objViewer.btnYB.Enabled = false;
            //}
            frmYB_TS fTSyb = new frmYB_TS();
            fTSyb.objPatient_VO = this.m_objViewer.objPatient.BihPatient_VO;
            string strPatNameWithInID = "";
            strPatNameWithInID = this.m_objViewer.objPatient.BihPatient_VO.Name.Trim();
            if (this.m_objViewer.objPatient.BihPatient_VO.Zyh.Trim() != "")
            {
                if (strPatNameWithInID != "")
                {
                    strPatNameWithInID += "(" + this.m_objViewer.objPatient.BihPatient_VO.Zyh.Trim() + ")";
                }
                else
                {
                    strPatNameWithInID = this.m_objViewer.objPatient.BihPatient_VO.Zyh.Trim();
                }
            }
            fTSyb.lblzyh.Text = strPatNameWithInID;
            fTSyb.lblTotal.Text = this.m_objViewer.lblTotalMoney.Text;
            if (fTSyb.ShowDialog() == DialogResult.OK)
            {
                this.m_mthReSet_F2(fTSyb.SbMny, fTSyb.dtYB);
            }
        }
        #endregion

        #region 佛二医保结算
        /// <summary>
        /// 佛二医保结算
        /// </summary>
        private void m_mthYB_F2()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;

            ArrayList objYBArr = new ArrayList();

            Hashtable HasYB = new Hashtable();

            for (int i = 0; i < this.m_objViewer.ChargeDetail.Rows.Count; i++)
            {
                if (HasYB.ContainsKey(i))
                {
                    continue;
                }

                clsYB_VO objYB = new clsYB_VO();

                string itemcode = this.m_objViewer.ChargeDetail.Rows[i]["ybcode"].ToString().Trim();
                decimal qnt = clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["amount_dec"]);
                decimal amt = clsPublic.Round(clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["amount_dec"]), 2);

                for (int j = i + 1; j < this.m_objViewer.ChargeDetail.Rows.Count; j++)
                {
                    if (this.m_objViewer.ChargeDetail.Rows[j]["ybcode"].ToString().Trim() == itemcode)
                    {
                        qnt += clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[j]["amount_dec"]);
                        amt += clsPublic.Round(clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[j]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[j]["amount_dec"]), 2);
                        HasYB.Add(j, i);
                    }
                }

                objYB.Hoscode = Hospcode;
                objYB.Billno = "";
                objYB.ZYNo = this.m_objViewer.objPatient.BihPatient_VO.Zyh;
                objYB.ZYSno = this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs;
                objYB.XMCode = itemcode;
                objYB.Asssign = "";

                if (this.m_objViewer.ChargeDetail.Rows[i]["itemname_vchr"].ToString().Trim().Length <= 15)
                {
                    objYB.XMDes = this.m_objViewer.ChargeDetail.Rows[i]["itemname_vchr"].ToString().Trim();
                }
                else
                {
                    objYB.XMDes = this.m_objViewer.ChargeDetail.Rows[i]["itemname_vchr"].ToString().Trim().Substring(0, 15);
                }

                if (this.m_objViewer.ChargeDetail.Rows[i]["unit_vchr"].ToString().Trim().Length <= 4)
                {
                    objYB.XMUnt = this.m_objViewer.ChargeDetail.Rows[i]["unit_vchr"].ToString().Trim();
                }
                else
                {
                    objYB.XMUnt = this.m_objViewer.ChargeDetail.Rows[i]["unit_vchr"].ToString().Trim().Substring(0, 4);
                }

                objYB.XMQnt = qnt;
                objYB.XMPrc = clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["unitprice_dec"]);
                objYB.XMAmt = amt;
                objYB.Trndate = DateTime.Now.ToString("yyyy-MM-dd");
                objYB.Trnflag = "F";
                objYB.Memoa = this.m_objViewer.objPatient.RegisterID + "+" + this.m_objViewer.objPatient.BihPatient_VO.Name;
                objYB.UVersion = "";

                objYBArr.Add(objYB);
            }

            if (objYBArr.Count == 0)
            {
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }

            this.m_objViewer.Cursor = Cursors.Default;
            frmYBType fYBType = new frmYBType();
            if (fYBType.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;

                if (fYBType.YBType == 2)
                {
                    this.objSvc.m_lngDelybdata(DB2Parm, this.m_objViewer.objPatient.BihPatient_VO.Zyh, this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs.ToString());

                    long l = this.objSvc.m_lngSendybdata(DB2Parm, objYBArr);
                    if (l > 0)
                    {
                        if (this.objSvc.m_blnCheckSendRes(DB2Parm, Hospcode, this.m_objViewer.objPatient.BihPatient_VO.Zyh, this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs.ToString()))
                        {
                            frmYB fYB = new frmYB(DB2Parm, Hospcode, this.m_objViewer.objPatient.BihPatient_VO.Name, this.m_objViewer.objPatient.BihPatient_VO.Zyh, this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs, this.m_objViewer.lblTotalMoney.Tag.ToString());
                            if (fYB.ShowDialog() == DialogResult.OK)
                            {
                                this.m_mthReSet_F2(fYB.SbMny, fYB.dtYB);
                            }
                        }
                        else
                        {
                            this.m_objViewer.Cursor = Cursors.Default;
                            this.objSvc.m_lngDelybdata(DB2Parm, this.m_objViewer.objPatient.BihPatient_VO.Zyh, this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs.ToString());
                            MessageBox.Show("传送医保数据失败，请再次点击【医保计算】按钮。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        this.m_objViewer.Cursor = Cursors.Default;
                        MessageBox.Show("传送医保数据失败，请再次点击【医保计算】按钮。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    this.m_objViewer.Cursor = Cursors.Default;
                }
                else if (fYBType.YBType == 3)
                {
                    frmYB fYB = new frmYB(DB2Parm, Hospcode, this.m_objViewer.objPatient.BihPatient_VO.Name, this.m_objViewer.objPatient.BihPatient_VO.Zyh, this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs, this.m_objViewer.lblTotalMoney.Tag.ToString());
                    fYB.m_mthReceive();
                    if (fYB.ShowDialog() == DialogResult.OK)
                    {
                        this.m_mthReSet_F2(fYB.SbMny, fYB.dtYB);
                    }
                }
                else if (fYBType.YBType == 4)
                {
                    this.objSvc.m_lngDelybdata(DB2Parm, this.m_objViewer.objPatient.BihPatient_VO.Zyh, this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs.ToString());
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }

            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="Sbmny">自付合计金额</param>
        /// <param name="dtYB">医保返回数据集</param>
        private void m_mthReSet_F2(decimal Sbmny, DataTable dtYB)
        {
            //设置当前为医保结算
            YBChargeFlag = true;
            //医保结帐单号
            YBBillNO = dtYB.Rows[0]["medno"].ToString().Trim();
            //总金额
            decimal totalmny = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            //记帐金额
            decimal acctmny = totalmny - Sbmny;

            objCharge_VO.SbSum = Sbmny;
            objCharge_VO.AcctSum = acctmny;

            this.m_objViewer.lblTotalMoney.Text = objCharge_VO.TotalSum.ToString();
            this.m_objViewer.lblTotalMoney.Tag = objCharge_VO.TotalSum.ToString();
            if (objCharge_VO.SbSum > 0)
            {
                this.m_objViewer.lblSbMoney.Text = objCharge_VO.SbSum.ToString();
                this.m_objViewer.lblSbMoney.Tag = objCharge_VO.SbSum.ToString();
            }
            else
            {
                this.m_objViewer.lblSbMoney.Text = "";
                this.m_objViewer.lblSbMoney.Tag = "0";
            }
            if (objCharge_VO.AcctSum > 0)
            {
                this.m_objViewer.lblAcctMoney.Text = objCharge_VO.AcctSum.ToString();
                this.m_objViewer.lblAcctMoney.Tag = objCharge_VO.AcctSum.ToString();
            }
            else
            {
                this.m_objViewer.lblAcctMoney.Text = "";
                this.m_objViewer.lblAcctMoney.Tag = "0";
            }

            #region 调整明细比例
            decimal scale = 100 - Math.Floor((acctmny / totalmny) * 100);
            decimal ybacctsum = 0;

            for (int i = 0; i < this.m_objViewer.ChargeDetail.Rows.Count; i++)
            {
                this.m_objViewer.ChargeDetail.Rows[i]["discount_dec"] = scale;
                this.m_objViewer.ChargeDetail.Rows[i]["precent_dec"] = scale;

                decimal d = clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["totalmoney_dec"]) - clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["chargetotalsum"]);
                this.m_objViewer.ChargeDetail.Rows[i]["acctmoney_dec"] = d - clsPublic.Round(d * scale / 100, 2);

                ybacctsum += clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["acctmoney_dec"]);
            }

            //记帐差额补在最后一项
            if (acctmny != ybacctsum)
            {
                int row = this.m_objViewer.ChargeDetail.Rows.Count - 1;
                this.m_objViewer.ChargeDetail.Rows[row]["acctmoney_dec"] = clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[row]["acctmoney_dec"]) + (acctmny - ybacctsum);
            }
            #endregion

            #region 调整发票分类VO
            InvoCatArr = null;
            this.m_objViewer.dgInvoiceCat.Rows.Clear();

            if (this.m_intGetInvCatDet(4, out InvoCatArr) == 1)
            {
                for (int i = 0; i < InvoCatArr.Count; i++)
                {
                    clsBihInvoiceCat_VO InvoiceCat_VO = InvoCatArr[i] as clsBihInvoiceCat_VO;

                    if (InvoiceCat_VO.TotalSum == 0)
                    {
                        continue;
                    }

                    string[] s = new string[2];
                    s[0] = InvoiceCat_VO.ItemCatName;
                    s[1] = InvoiceCat_VO.TotalSum.ToString();

                    this.m_objViewer.dgInvoiceCat.Rows.Add(s);
                }
            }
            #endregion

            this.m_objViewer.txtPayMode1Money.Text = "";
            this.m_objViewer.txtPayMode2Money.Text = "";
            this.m_mthChangeMoney();
            this.m_mthReSetPrepay();

            this.m_objViewer.cboPayMode1.Focus();
        }
        #endregion

        #region 茶山嵌入式医保结算
        /// <summary>
        /// 茶山嵌入式医保结算
        /// </summary>
        private void m_mthYB_CS(bool blNewYB)
        {
            if (blNewYB)//need modify 增加参数控制
            {
                //新接口 需引用HISYB_CS.dll
                frmYBChargeZY fYB = new frmYBChargeZY();
                fYB.m_blnDiffCostOn = this.intDiffCostOn == 1;// 让利开关
                fYB.decTotal = decimal.Parse(this.m_objViewer.lblTotalMoney.Text);
                // ChargeType结算类型：1 中途结算 2 出院结算 3 呆帐结算 4 直接收费 5 确认收费 6 呆帐补交款结算
                List<string> lstPChargeId = new List<string>();
                if (this.m_objViewer.ChargeType == 1)
                {
                    fYB.strJslx = "2";//1 出院结算 2 中途结算
                    if (this.m_objViewer.ChargeDetail != null)
                    {
                        if (this.m_objViewer.ChargeDetail.Rows.Count > 0)
                        {
                            DataRow[] drJSQSRQ = this.m_objViewer.ChargeDetail.Select("chargeactive_dat=min(chargeactive_dat)");
                            if (drJSQSRQ.Length > 0)
                            {
                                fYB.strJSQSRQ = DateTime.Parse(drJSQSRQ[0]["chargeactive_dat"].ToString()).ToString("yyyyMMdd"); //结算起始日期 
                            }
                            DataRow[] drJSZZRQ = this.m_objViewer.ChargeDetail.Select("chargeactive_dat=max(chargeactive_dat)");
                            if (drJSZZRQ.Length > 0)
                            {
                                fYB.strJSZZRQ = DateTime.Parse(drJSZZRQ[0]["chargeactive_dat"].ToString()).ToString("yyyyMMdd");//结算终止日期
                            }
                            foreach (DataRow dr1 in this.m_objViewer.ChargeDetail.Rows)
                            {
                                lstPChargeId.Add(dr1["pchargeid_chr"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    fYB.strJslx = "1";//1 出院结算 2 中途结算3 预结算
                }
                fYB.strInvNo = this.m_objViewer.txtInvono.Text.Trim();
                fYB.strEmpNo = this.m_objViewer.LoginInfo.m_strEmpNo.ToString().Trim();
                fYB.strRegisterId = this.m_objViewer.objPatient.BihPatient_VO.RegisterID.ToString().Trim();
                fYB.lstPChargeId = lstPChargeId;
                if (fYB.ShowDialog() == DialogResult.OK)
                {
                    //need modify  this.m_mthReSet_CS(fYB.decYBSub, fYB.dtYB);//该重置方法第2个参数没用，是否可以去掉，只传入医保返回的自费金额
                    DataTable dtYB = new DataTable();
                    dtYB.Columns.Add("Zyh");
                    DataRow drYB = dtYB.NewRow();
                    drYB["Zyh"] = this.m_objViewer.objPatient.BihPatient_VO.Zyh.ToString().Trim();
                    dtYB.Rows.Add(drYB);
                    this.m_mthReSet_CS(fYB.decYBSub, fYB.decTotal, dtYB, true);
                }
            }
            else
            {
                DataView dv = new DataView(this.m_objViewer.ChargeDetail);
                if (this.m_blnCreateDBF(this.m_objViewer.objPatient.BihPatient_VO.IdNo, this.m_objViewer.objPatient.BihPatient_VO.Zyh, dv, false))
                {
                    frmYB_CS fYB = new frmYB_CS();
                    fYB.lblZyh.Text = this.m_objViewer.objPatient.BihPatient_VO.Zyh;
                    fYB.lblZycs.Text = this.m_objViewer.objPatient.BihPatient_VO.InsuredZycs.ToString();
                    fYB.lblName.Text = this.m_objViewer.objPatient.BihPatient_VO.Name;
                    fYB.lblDbf.Text = "Y" + this.m_objViewer.objPatient.BihPatient_VO.Zyh.Trim() + ".dbf";
                    fYB.lblStatus.Text = "生成DBF文件成功";
                    fYB.lblTotalMoney.Text = this.m_objViewer.lblTotalMoney.Text;
                    fYB.DSN = this.DBFParm;

                    if (fYB.ShowDialog() == DialogResult.OK)
                    {
                        this.m_mthReSet_CS(fYB.SbMny, decimal.Parse(this.m_objViewer.lblTotalMoney.Text), fYB.dtYB, false);
                    }
                }
            }

        }

        /// <summary>
        /// (茶山)生成医保DBF
        /// </summary>
        /// <param name="Ybzh"></param>
        /// <param name="Zyh"></param>
        /// <param name="DV"></param>
        /// <param name="ShowMsg"></param>
        public bool m_blnCreateDBF(string Ybzh, string Zyh, DataView DV, bool ShowMsg)
        {
            if (DBFParm.Trim() == "")
            {
                string tmpfs = clsPublic.XMLFile;
                clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";
                string DSN = clsPublic.m_strReadXML("DONGGUAN.CHASHAN", "DSN", "AnyOne");
                DBQ = clsPublic.m_strReadXML("DONGGUAN.CHASHAN", "DBQ", "AnyOne");
                clsPublic.XMLFile = tmpfs;

                DBFParm = DSN + DBQ;
            }

            int no = 1;
            ArrayList objYBArr = new ArrayList();
            ArrayList RowArr = new ArrayList();

            for (int i = 0; i < DV.Count; i++)
            {
                if (RowArr.IndexOf(i) >= 0)
                {
                    continue;
                }

                DataRow dr = DV[i].Row;

                string itemid = dr["chargeitemid_chr"].ToString();
                string price = dr["unitprice_dec"].ToString();
                string shiyingzheng = dr["itemchargetype_vchr"].ToString();
                decimal amount = clsPublic.ConvertObjToDecimal(dr["amount_dec"]);
                decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dr["amount_dec"]) + clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"]), 2);

                decimal totalmoney = d;
                //if (this.intDiffCostOn == 1)//启用让利
                //    totalmoney += clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"]), 2);
                decimal sbmoney = clsPublic.Round(d * clsPublic.ConvertObjToDecimal(dr["precent_dec"]) / 100, 2);

                for (int j = i + 1; j < DV.Count; j++)
                {
                    if (DV[j].Row["chargeitemid_chr"].ToString() == itemid &&
                        DV[j].Row["unitprice_dec"].ToString() == price && DV[j].Row["itemchargetype_vchr"].ToString() == shiyingzheng)
                    {
                        amount += clsPublic.ConvertObjToDecimal(DV[j].Row["amount_dec"]);

                        d = clsPublic.Round(clsPublic.ConvertObjToDecimal(DV[j].Row["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(DV[j].Row["amount_dec"]) + clsPublic.ConvertObjToDecimal(DV[j].Row["totaldiffcostmoney_dec"]), 2);
                        //if (this.intDiffCostOn == 1)//启用让利
                        //    d += clsPublic.Round(clsPublic.ConvertObjToDecimal(DV[j].Row["totaldiffcostmoney_dec"]), 2);
                        totalmoney += d;
                        sbmoney += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(DV[j].Row["precent_dec"]) / 100, 2);

                        RowArr.Add(j);
                    }
                }

                clsCSYB_VO objCSYB = new clsCSYB_VO();

                objCSYB.Grshbzh = Ybzh;
                objCSYB.Zyh = Zyh;
                objCSYB.Xmxh = no;
                if (dr["ybcode"].ToString().Length <= 15)
                {
                    objCSYB.Xmbh = dr["ybcode"].ToString();
                }
                else
                {
                    objCSYB.Xmbh = dr["ybcode"].ToString().Substring(0, 15);
                }

                string itemname = dr["chargeitemname_chr"].ToString().Trim().Replace("-", "－");
                if (itemname.Length <= 40)
                {
                    objCSYB.Xmmc = itemname;
                }
                else
                {
                    objCSYB.Xmmc = itemname.Substring(0, 40);
                }

                if (dr["invcateid_chr"].ToString().Trim() != "")
                {
                    //取发票分类后两位
                    objCSYB.Fldm = dr["invcateid_chr"].ToString().Substring(2, 2);
                }
                else
                {
                    MessageBox.Show("项目：" + objCSYB.Xmmc + "的发票分类不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                string itemspec = dr["spec_vchr"].ToString().Trim().Replace("-", "－");
                if (itemspec.Length <= 15)
                {
                    objCSYB.Ypgg = itemspec;
                }
                else
                {
                    objCSYB.Ypgg = itemspec.Substring(0, 15);
                }

                objCSYB.Ypjx = "";
                if (this.intDiffCostOn == 1)
                {

                    decimal temp = clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"]);
                    if (temp == 0)
                    {
                        objCSYB.Jg = clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]);
                    }
                    else
                    {
                        objCSYB.Jg = clsPublic.ConvertObjToDecimal(dr["tradeprice_mny"]);
                    }
                    //objCSYB.Jg = clsPublic.ConvertObjToDecimal(dr["tradeprice_mny"]);
                    //if (objCSYB.Jg == 0)
                    //    objCSYB.Jg = clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]);
                }
                else
                    objCSYB.Jg = clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]);
                objCSYB.Mcyl = amount;
                objCSYB.Je = totalmoney;
                objCSYB.Zfbl = clsPublic.ConvertObjToDecimal(dr["precent_dec"]) / 100;
                objCSYB.Zfje = sbmoney;
                //if (clsPublic.ConvertObjToDecimal(dr["precent_dec"]) == 100)
                //{
                //    objCSYB.Czfbz = "1";
                //}
                //else
                //{
                //    objCSYB.Czfbz = "0";
                //}
                if (dr["itemchargetype_vchr"] == null || dr["itemchargetype_vchr"].ToString() == "")
                {
                    objCSYB.Czfbz = "2";
                }
                else
                {
                    objCSYB.Czfbz = dr["itemchargetype_vchr"].ToString();
                }

                objCSYB.Bz1 = dr["itemopcode_chr"].ToString().Trim();
                //暂赋空值
                objCSYB.Bz2 = "";
                objCSYB.Bz3 = "";

                objYBArr.Add(objCSYB);
                no++;
            }

            if (File.Exists(DBQ + "Y" + Zyh + ".dbf"))
            {
                File.Delete(DBQ + "Y" + Zyh + ".dbf");
            }

            long l = this.objSvc.m_lngCreateDBF(DBFParm, "Y" + Zyh, objYBArr);
            if (l > 0)
            {
                if (ShowMsg)
                {
                    MessageBox.Show("生成医保DBF文件成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("生成医保DBF文件失败。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="Sbmny">自付合计金额</param>
        /// <param name="Totalmny">合计金额</param>
        /// <param name="dtYB">医保返回数据集</param>
        /// <param name="blNewmny">是否按医保返回的金额重置总金额</param>
        private void m_mthReSet_CS(decimal decSbmny, decimal decTotalmny, DataTable dtYB, bool blNewmny)
        {
            //设置当前为医保结算
            YBChargeFlag = true;
            //医保结帐单号(用住院号代替)
            YBBillNO = dtYB.Rows[0]["Zyh"].ToString().Trim();
            //总金额
            decimal totalmny = 0;
            if (blNewmny)
            {
                totalmny = decTotalmny;
            }
            else
            {
                totalmny = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            }
            //记帐金额
            decimal acctmny = totalmny - decSbmny;

            objCharge_VO.TotalSum = totalmny;
            objCharge_VO.SbSum = decSbmny;
            objCharge_VO.AcctSum = acctmny;

            this.m_objViewer.lblTotalMoney.Text = objCharge_VO.TotalSum.ToString();
            this.m_objViewer.lblTotalMoney.Tag = objCharge_VO.TotalSum.ToString();
            if (objCharge_VO.SbSum > 0)
            {
                this.m_objViewer.lblSbMoney.Text = objCharge_VO.SbSum.ToString();
                this.m_objViewer.lblSbMoney.Tag = objCharge_VO.SbSum.ToString();
            }
            else
            {
                this.m_objViewer.lblSbMoney.Text = "";
                this.m_objViewer.lblSbMoney.Tag = "0";
            }
            if (objCharge_VO.AcctSum > 0)
            {
                this.m_objViewer.lblAcctMoney.Text = objCharge_VO.AcctSum.ToString();
                this.m_objViewer.lblAcctMoney.Tag = objCharge_VO.AcctSum.ToString();
            }
            else
            {
                this.m_objViewer.lblAcctMoney.Text = "";
                this.m_objViewer.lblAcctMoney.Tag = "0";
            }

            int row = 0;
            decimal ybacctsum = 0;
            decimal scale = 100 - Math.Floor((acctmny / totalmny) * 100);
            for (int i = 0; i < this.m_objViewer.ChargeDetail.Rows.Count; i++)
            {
                decimal d = clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["totalmoney_dec"]) - clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[i]["chargetotalsum"]);
                ybacctsum += d - clsPublic.Round(d * scale / 100, 2);

                this.m_objViewer.ChargeDetail.Rows[i]["discount_dec"] = scale;
                this.m_objViewer.ChargeDetail.Rows[i]["precent_dec"] = scale;
                this.m_objViewer.ChargeDetail.Rows[i]["acctmoney_dec"] = d - clsPublic.Round(d * scale / 100, 2);
                row = i;
            }

            //记帐差额补在最后一项
            if (ybacctsum != acctmny)
            {
                this.m_objViewer.ChargeDetail.Rows[row]["acctmoney_dec"] = clsPublic.ConvertObjToDecimal(this.m_objViewer.ChargeDetail.Rows[row]["acctmoney_dec"]) + (acctmny - ybacctsum);
            }

            #region 调整发票分类VO
            InvoCatArr = null;
            this.m_objViewer.dgInvoiceCat.Rows.Clear();

            if (this.m_intGetInvCatDet(4, out InvoCatArr) == 1)
            {
                for (int i = 0; i < InvoCatArr.Count; i++)
                {
                    clsBihInvoiceCat_VO InvoiceCat_VO = InvoCatArr[i] as clsBihInvoiceCat_VO;

                    if (InvoiceCat_VO.TotalSum == 0)
                    {
                        continue;
                    }

                    string[] s = new string[2];
                    s[0] = InvoiceCat_VO.ItemCatName;
                    s[1] = InvoiceCat_VO.TotalSum.ToString();

                    this.m_objViewer.dgInvoiceCat.Rows.Add(s);
                }
            }
            #endregion

            this.m_objViewer.txtPayMode1Money.Text = "";
            this.m_objViewer.txtPayMode2Money.Text = "";
            this.m_mthChangeMoney();
            this.m_mthReSetPrepay();

            this.m_objViewer.cboPayMode1.Focus();
        }
        #endregion
        #endregion

        #region 呆帐结算
        /// <summary>
        /// 呆帐结算
        /// </summary>
        public void m_mthBadReckoning()
        {
            #region 数据校验
            if (this.m_objViewer.btnReckoning.Tag != null && this.m_objViewer.btnReckoning.Tag.ToString().Trim() != "")
            {
                MessageBox.Show("已结算成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string invono = "";
            if (this.m_objViewer.DirectChargeFlag == false)
            {
                if (this.m_objViewer.lblSbMoney.Text.Trim() != "" && this.m_objViewer.txtPayMode1Money.Text.Trim() == "" && this.m_objViewer.txtPayMode2Money.Text.Trim() == "")
                {
                    return;
                }

                #region 发票号检验
                invono = this.m_objViewer.txtInvono.Text.Trim();
                if (!clsPublic.m_blnCheckInvoExpression(invono))
                {
                    MessageBox.Show("输入的发票号不符合规定的发票号规则，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtInvono.Focus();
                    this.m_objViewer.lblHint.Visible = true;
                    return;
                }

                if (clsPublic.m_blnCheckInvoIsUsed(invono))
                {
                    MessageBox.Show("输入的发票号已经被使用，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtInvono.Focus();
                    this.m_objViewer.lblHint.Visible = true;
                    return;
                }
                #endregion
            }
            #endregion

            this.m_objViewer.Cursor = Cursors.WaitCursor;

            #region 生成结算VO
            clsBihCharge_VO Charge_VO = new clsBihCharge_VO();
            Charge_VO.PatientID = this.m_objViewer.objPatient.BihPatient_VO.PatientID;
            Charge_VO.CurrAreaID = this.m_objViewer.objPatient.BihPatient_VO.AreaID;
            Charge_VO.RegisterID = this.m_objViewer.objPatient.RegisterID;
            Charge_VO.PayTypeID = this.m_objViewer.objPatient.BihPatient_VO.PayTypeID;
            Charge_VO.PatientType = this.m_objViewer.objPatient.BihPatient_VO.InType;
            Charge_VO.TotalSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            Charge_VO.SbSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag.ToString());
            Charge_VO.AcctSum = 0;
            Charge_VO.OperEmp = this.m_objViewer.LoginInfo.m_strEmpID;
            Charge_VO.BillNO = "";
            int intparm = clsPublic.m_intGetSysParm("1119");
            if (intparm == 1)
            {
                #region 母婴结算记录婴儿结算VO by yibing.zheng 09-07-04

                DataTable dtbBabyInfo = null;
                this.objSvc.m_lngGetBabyRegisterId(this.m_objViewer.objPatient.BihPatient_VO.RegisterID, out dtbBabyInfo);
                //记录婴儿费用
                if (dtbBabyInfo.Rows.Count > 0)
                {
                    DataRow dr = null;
                    Charge_VO.m_objBabyInfoVo = new clsBihPatient_VO[dtbBabyInfo.Rows.Count];
                    for (int i1 = 0; i1 < dtbBabyInfo.Rows.Count; i1++)
                    {
                        dr = dtbBabyInfo.Rows[i1];

                        Charge_VO.m_objBabyInfoVo[i1] = new clsBihPatient_VO();


                        Charge_VO.m_objBabyInfoVo[i1].PatientID = dr["patientid_chr"].ToString();
                        Charge_VO.m_objBabyInfoVo[i1].RegisterID = dr["registerid_chr"].ToString();
                        Charge_VO.m_objBabyInfoVo[i1].AreaID = dr["areaid_chr"].ToString();
                        Charge_VO.m_objBabyInfoVo[i1].PayTypeID = dr["paytypeid_chr"].ToString();
                    }
                }
                #endregion
            }
            #endregion

            #region 生成发票VO
            clsBihInvoice_VO Invoice_VO = new clsBihInvoice_VO();
            Invoice_VO.InvoiceNo = invono;
            Invoice_VO.TotalSum = Convert.ToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            Invoice_VO.SbSum = Convert.ToDecimal(this.m_objViewer.lblSbMoney.Tag.ToString());
            Invoice_VO.AcctSum = 0;
            Invoice_VO.Status = 1;
            Invoice_VO.Split = 0;
            #endregion

            #region 生成支付VO
            ArrayList PaymentArr = new ArrayList();
            clsBihPayment_VO Payment_VO = new clsBihPayment_VO();
            if (this.m_objViewer.DirectChargeFlag)
            {
                Payment_VO.PayType = 4;
                Payment_VO.PaySum = 0;
                Payment_VO.RefuSum = 0;
            }
            else
            {
                Payment_VO.PayType = 0;
                Payment_VO.PaySum = Convert.ToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
                Payment_VO.RefuSum = 0;
            }
            PaymentArr.Add(Payment_VO);
            #endregion

            #region 保存
            //结算号
            string ChargeNo = "";
            decimal decPrepayMny = this.m_objViewer.objPatient.BihPatient_VO.PrepayMoney;
            decimal decFactMny = this.m_objViewer.objPatient.BihPatient_VO.WaitChargeFee + this.m_objViewer.objPatient.BihPatient_VO.WaitClearFee;
            long l = this.objSvc.m_lngBadCharge(Charge_VO, this.m_objViewer.BadChargeCatArr, Invoice_VO, this.m_objViewer.BadChargeInvArr, PaymentArr, decFactMny, decPrepayMny,
                                                this.m_objViewer.BadChargeDiffValDeptID, this.m_objViewer.BadChargeDiffValCatID, !this.m_objViewer.DirectChargeFlag, out ChargeNo);
            if (l > 0)
            {
                this.m_objViewer.btnReckoning.Tag = ChargeNo;
                if (!this.m_objViewer.DirectChargeFlag)
                {
                    //保存当前发票号                
                    clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, invono, 1);
                    this.m_blnSaveInvoiceNo(invono);
                    //打印发票
                    clsPBNetPrint.m_mthPrintInvoiceBill(ChargeNo, "", 2, this.HospitalName);
                }
                //成功返回
                this.m_objViewer.DialogResult = DialogResult.OK;
            }
            else
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("结算失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region 直接结算标志(零费用)
        public void m_mthDirReckoning()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;

            #region 生成结算VO
            clsBihCharge_VO Charge_VO = new clsBihCharge_VO();
            Charge_VO.PatientID = this.m_objViewer.objPatient.BihPatient_VO.PatientID;
            Charge_VO.CurrAreaID = this.m_objViewer.objPatient.BihPatient_VO.AreaID;
            Charge_VO.RegisterID = this.m_objViewer.objPatient.RegisterID;
            Charge_VO.PayTypeID = this.m_objViewer.objPatient.BihPatient_VO.PayTypeID;
            Charge_VO.PatientType = this.m_objViewer.objPatient.BihPatient_VO.InType;
            Charge_VO.TotalSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblTotalMoney.Tag.ToString());
            Charge_VO.SbSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.lblSbMoney.Tag.ToString());
            Charge_VO.AcctSum = 0;
            Charge_VO.OperEmp = this.m_objViewer.LoginInfo.m_strEmpID;
            Charge_VO.BillNO = "";
            #endregion

            #region 保存
            //结算号
            string ChargeNo = "";

            long l = this.objSvc.m_lngReckoning(Charge_VO, out ChargeNo);

            if (l > 0)
            {
                this.m_objViewer.btnReckoning.Tag = ChargeNo;
                //成功返回
                this.m_objViewer.DialogResult = DialogResult.OK;
            }
            else
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("结算失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region Test
        /// <summary>
        /// Test
        /// </summary>
        internal void Test()
        {
            frmTest frm = new frmTest();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                decimal d1 = decimal.Parse(this.m_objViewer.lblTotalMoney.Text);
                decimal d2 = d1 - frm.SbMney;

                DataTable dtYB = new DataTable();
                dtYB.Columns.Add("Zyh");
                DataRow drYB = dtYB.NewRow();
                drYB["Zyh"] = this.m_objViewer.objPatient.BihPatient_VO.Zyh.ToString().Trim();
                dtYB.Rows.Add(drYB);
                this.m_mthReSet_CS(d2, d1, dtYB, true);
            }
        }
        #endregion
    }
}
