using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出院结算逻辑控制类
    /// </summary>
    public class clsCtl_LeaveCharge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_LeaveCharge()
        {
            objSvc = new clsDcl_Charge();
        }
        #endregion

        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Charge objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmLeaveCharge m_objViewer;

        /// <summary>
        /// 当前病人费用期帐明细
        /// </summary>
        private DataTable ChargeDt;

        /// <summary>
        /// 选择结算的费用明细
        /// </summary>
        private DataTable ChargeDtSelect;

        /// <summary>
        /// 病人门诊未结处方费用时控制出院结算与医嘱录入(医嘱录入1、2状态都为提示选择)0-关闭;1-提示选择，2-卡住
        /// </summary>
        internal int m_intParm1068 = 0;

        /// <summary>
        /// 让利启用开关
        /// </summary>
        internal int intDiffCostOn = 0;

        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmLeaveCharge)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        internal void m_mthInt()
        {
            m_intParm1068 = clsPublic.m_intGetSysParm("1068");
            intDiffCostOn = clsPublic.m_intGetSysParm("9002");
        }
        #endregion

        #region 快捷
        /// <summary>
        /// 快捷
        /// </summary>
        /// <param name="ky"></param>
        public void m_mthShortCut(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.F3:
                    this.m_mthFind();
                    break;
                case Keys.F8:
                    this.m_mthCharge();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            frmCommonFind f = new frmCommonFind("查找出院病人资料", this.m_objViewer.ucPatientInfo.Status);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthFind(f.RegisterID, 3);
                if (this.m_objViewer.ucPatientInfo.IsChanged)
                {
                    if (this.m_objViewer.ucPatientInfo.BihPatient_VO.Status == 2)
                    {
                        this.m_mthShowAllFeeDetail(this.m_objViewer.ucPatientInfo.RegisterID);
                    }
                    else if (this.m_objViewer.ucPatientInfo.BihPatient_VO.Status == 3)
                    {
                        this.m_mthShowAllFeeDetail(this.m_objViewer.ucPatientInfo.RegisterID);
                    }
                }
            }
        }
        #endregion

        #region 重置
        /// <summary>
        /// 重置
        /// </summary>
        public void m_mthReset()
        {
            this.m_objViewer.lblTotalSum.Text = "";
            this.m_objViewer.lblSbSum.Text = "";
            this.m_objViewer.lblAcctSum.Text = "";
            this.m_objViewer.lblCompleteSum.Text = "";
            this.m_objViewer.lblPay.Text = "";
            this.m_objViewer.lvInvoiceCat.Items.Clear();
            if (ChargeDtSelect != null)
            {
                ChargeDtSelect.Rows.Clear();
            }
        }
        #endregion

        #region 显示当前病人所有费用信息
        /// <summary>
        /// 显示当前病人所有费用信息
        /// </summary>
        /// <param name="RegID"></param>
        public void m_mthShowAllFeeDetail(string RegID)
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            this.m_mthReset();
            //this.m_objViewer.dtgDetail.Rows.Clear();

            DataTable dt = this.objSvc.GetPatientCheckFee(RegID);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ischeckfee"].ToString() == "1")
            { }
            else
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("病区还未对病人费用进行最终核对，不能进行结算。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.FeeStatus != 4)
            {
                #region 临时屏蔽
                //if (clsPublic.m_blnChargeContinueItem(this.m_objViewer.ucPatientInfo.RegisterID, this.m_objViewer.LoginInfo.m_strEmpID) == false)
                //{
                //    this.m_objViewer.Cursor = Cursors.Default;
                //    MessageBox.Show("数据结算异常，结算终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                #endregion
            }

            ChargeDt = null;
            long l = this.objSvc.m_lngGetChargeInfoByID(RegID, 1, out ChargeDt);

            int intParm = clsPublic.m_intGetSysParm("1119");//获取母婴合并结算开关
            #region 加载婴儿费用
            if (intParm == 1)
            {
                DataTable dtbBabyCharge = new DataTable();
                bool blnHaveBagy = this.m_blnHaveBaby(this.m_objViewer.ucPatientInfo.BihPatient_VO.RegisterID, out dtbBabyCharge);
                if (blnHaveBagy)
                {
                    ChargeDt.Merge(dtbBabyCharge);
                }
            }
            #endregion
            if (l > 0)
            {
                DataTable dtview = new DataTable();
                #region create columns
                dtview.Columns.Add("selectflag");
                dtview.Columns.Add("serno");
                dtview.Columns.Add("dayaccountno");
                dtview.Columns.Add("begindate");
                dtview.Columns.Add("invoname");
                dtview.Columns.Add("itemname");
                dtview.Columns.Add("nums");
                dtview.Columns.Add("price");
                dtview.Columns.Add("total");
                dtview.Columns.Add("scale");
                dtview.Columns.Add("facttotal");
                dtview.Columns.Add("status");
                dtview.Columns.Add("totaldiffcostmoney_dec");// 总让利金额
                dtview.Columns.Add("requiredpay");// 实付金额
                #endregion

                DataView dv = new DataView(ChargeDt);

                int rowno = 1;

                dtview.BeginLoadData();
                decimal dec_PayMny = 0;//实收
                decimal dec_DiffSum = 0;//让利
                decimal dec_SumPrice = 0;//总金额
                for (int i = 0; i < dv.Count; i++)
                {
                    DataRow dr = dv[i].Row;

                    string[] sarr = new string[14];

                    string orderno = dr["orderno_int"].ToString().Trim();
                    string createdate = Convert.ToDateTime(dr["chargeactive_dat"].ToString()).ToString("yyyyMMdd");
                    string itemid = dr["chargeitemid_chr"].ToString().Trim();
                    string price = dr["unitprice_dec"].ToString().Trim();
                    string statusid = dr["pstatus_int"].ToString();
                    decimal amount = clsPublic.ConvertObjToDecimal(dr["amount_dec"]);
                    decimal d = 0;
                    decimal totalmoney = 0;
                    decimal acctmoney = 0, dec_requiredPay = 0;
                    decimal decTotalDiffCost = 0;// 总让利金额
                    if (statusid == "3" || statusid == "4")
                    {
                        d = clsPublic.ConvertObjToDecimal(dr["totalmoney_dec"]);
                        totalmoney = d;
                        acctmoney = d - clsPublic.ConvertObjToDecimal(dr["acctmoney_dec"]);
                    }
                    else
                    {
                        d = clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dr["amount_dec"]);
                        if (d != clsPublic.ConvertObjToDecimal(dr["totalmoney_dec"]))
                        {
                            com.digitalwave.Utility.clsLogText jianjun = new com.digitalwave.Utility.clsLogText();
                            jianjun.LogError("单价*数量：" + d.ToString() + "    总金额：" + clsPublic.ConvertObjToDecimal(dr["totalmoney_dec"]).ToString());
                        }
                        totalmoney = d;
                        acctmoney = d * clsPublic.ConvertObjToDecimal(dr["precent_dec"]) / 100;
                    }
                    decTotalDiffCost = clsPublic.ConvertObjToDecimal(dr["totaldiffcostmoney_dec"]);
                    if (this.intDiffCostOn == 1)
                    {
                        dec_requiredPay = totalmoney + decTotalDiffCost;
                        sarr[12] = decTotalDiffCost.ToString("0.00");
                        sarr[13] = dec_requiredPay.ToString("0.00");
                        com.digitalwave.Utility.clsLogText jianjun = new com.digitalwave.Utility.clsLogText();
                        jianjun.LogError("总金额：" + totalmoney.ToString() + "    药品让利：" + decTotalDiffCost.ToString() + "      实付金额：" + dec_requiredPay.ToString());
                        dec_PayMny += dec_requiredPay;
                        dec_DiffSum += decTotalDiffCost;
                    }
                    #region 合并相同项
                    //for (int j = i + 1; j < dv.Count; j++)
                    //{
                    //    if (dv[j].Row["orderno_int"].ToString().Trim() == orderno &&
                    //        Convert.ToDateTime(dv[j].Row["chargeactive_dat"].ToString()).ToString("yyyyMMdd") == createdate &&
                    //        dv[j].Row["chargeitemid_chr"].ToString().Trim() == itemid &&
                    //        dv[j].Row["unitprice_dec"].ToString().Trim() == price &&
                    //        dv[j].Row["pstatus_int"].ToString() == statusid)
                    //    {
                    //        amount += clsPublic.ConvertObjToDecimal(dv[j].Row["amount_dec"]);

                    //        //费用
                    //        if (statusid == "3" || statusid == "4")
                    //        {
                    //            totalmoney += clsPublic.ConvertObjToDecimal(dv[j].Row["totalmoney_dec"]);
                    //            acctmoney += clsPublic.ConvertObjToDecimal(dv[j].Row["acctmoney_dec"]);
                    //        }
                    //        else
                    //        {
                    //            d = clsPublic.ConvertObjToDecimal(dv[j].Row["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dv[j].Row["amount_dec"]);
                    //            totalmoney += d;
                    //            acctmoney += d * clsPublic.ConvertObjToDecimal(dv[j].Row["precent_dec"]) / 100;
                    //        }

                    //        //RowArr.Add(j);
                    //        hasRowNo.Add(j.ToString(), null);
                    //    }
                    //}    
                    #endregion

                    sarr[0] = "F";
                    sarr[1] = rowno.ToString();
                    sarr[2] = orderno;
                    sarr[3] = createdate;
                    sarr[4] = dr["ipinvoname"].ToString().Trim();
                    sarr[5] = dr["chargeitemname_chr"].ToString().Trim();
                    sarr[6] = amount.ToString();
                    sarr[7] = price;
                    sarr[8] = totalmoney.ToString("0.00");
                    dec_SumPrice += totalmoney;
                    sarr[9] = dr["precent_dec"].ToString();
                    if (acctmoney > 0)
                    {
                        sarr[10] = acctmoney.ToString("0.00");
                    }
                    else
                    {
                        sarr[10] = "";
                    }

                    //状态                    
                    string statusname = "";
                    if (statusid == "0")
                    {
                        statusname = "待确认";
                    }
                    else if (statusid == "1")
                    {
                        statusname = "待结";
                    }
                    else if (statusid == "2")
                    {
                        statusname = "待清";
                    }
                    else if (statusid == "3")
                    {
                        statusname = "已清";
                    }
                    else if (statusid == "4")
                    {
                        statusname = "直收";
                    }
                    sarr[11] = statusname;

                    rowno++;
                    dtview.LoadDataRow(sarr, true);
                }
                dtview.EndLoadData();
                this.m_objViewer.dtgDetail.DataSource = dtview;
                this.m_mthSetRowColor();
                this.m_mthGetCheckType();
            }

            this.m_objViewer.Cursor = Cursors.Default;
            //获取母婴合并结算开关
            if (intParm == 0)
            {
                this.m_mthCheckBaby(this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh);
            }
        }
        #endregion

        #region 设置行颜色
        /// <summary>
        /// 设置行颜色
        /// </summary>
        public void m_mthSetRowColor()
        {
            for (int i = 0; i < this.m_objViewer.dtgDetail.Rows.Count; i++)
            {
                //颜色
                Color FCR = Color.Black;
                Color BCR = Color.White;

                string statusname = this.m_objViewer.dtgDetail.Rows[i].Cells["status"].Value.ToString().Trim();
                if (statusname == "待确认")
                {
                    FCR = Color.FromArgb(200, 0, 0);
                }
                else if (statusname == "待结")
                {
                    FCR = Color.FromArgb(200, 0, 0);
                }
                else if (statusname == "已清")
                {
                    FCR = Color.RoyalBlue;
                }
                else if (statusname == "直收")
                {
                    FCR = Color.RoyalBlue;
                }

                this.m_objViewer.dtgDetail.Rows[i].DefaultCellStyle.ForeColor = FCR;

                if (Math.IEEERemainder(Convert.ToDouble(i), 2) == 0)
                {
                    this.m_objViewer.dtgDetail.Rows[i].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }
        }
        #endregion

        #region 获取费用发票分类
        /// <summary>
        /// 获取费用发票分类
        /// </summary>        
        public void m_mthGetCheckType()
        {
            DataView dv = new DataView(ChargeDt);
            ChargeDtSelect = ChargeDt.Clone();

            foreach (DataRowView drv in dv)
            {
                ChargeDtSelect.Rows.Add(drv.Row.ItemArray);
            }
            ChargeDtSelect.AcceptChanges();

            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.Status == 2 && ChargeDtSelect.Rows.Count == 0)
            {
                MessageBox.Show("没有费用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //计算总金额、自付金额和记帐金额
            decimal decTotalSum = 0;
            decimal decSbSum = 0;
            decimal decAcctSum = 0;

            //已清金额、待清金额、待结金额、待确认金额
            decimal decCompleteSum = 0;
            decimal decWaitClearSum = 0;
            decimal decWaitChrgSum = 0;
            decimal decWaitConfSum = 0;
            // 总让利金额
            decimal decDiffCostSum = 0;
            for (int i = 0; i < ChargeDt.Rows.Count; i++)
            {
                decimal d = clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["amount_dec"]);

                if (ChargeDt.Rows[i]["pstatus_int"].ToString() == "3" || ChargeDt.Rows[i]["pstatus_int"].ToString() == "4")
                {
                    decTotalSum += clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totalmoney_dec"]);
                    d = clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totalmoney_dec"]);
                    decSbSum += clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totalmoney_dec"]) - clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["acctmoney_dec"]);
                }
                else
                {
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["precent_dec"]) / 100, 2);
                    decTotalSum += clsPublic.Round(clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totaldiffcostmoney_dec"]), 2);
                    decSbSum += clsPublic.Round(clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totaldiffcostmoney_dec"]), 2);
                }
                //是否启用让利开关 
                if (this.intDiffCostOn == 1)
                {
                    decDiffCostSum += clsPublic.Round(clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totaldiffcostmoney_dec"]), 2);
                    //decTotalSum += clsPublic.Round(clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totaldiffcostmoney_dec"]), 2);
                    //decSbSum += clsPublic.Round(clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totaldiffcostmoney_dec"]), 2);
                    d += clsPublic.Round(clsPublic.ConvertObjToDecimal(ChargeDt.Rows[i]["totaldiffcostmoney_dec"]), 2);
                }

                //费用状态 0 待确认 1 待结 2 待清 3 已清 4 直收 
                int status = int.Parse(ChargeDt.Rows[i]["pstatus_int"].ToString());
                if (status == 0)
                {
                    decWaitConfSum += clsPublic.Round(d, 2);
                }
                else if (status == 1)
                {
                    decWaitChrgSum += clsPublic.Round(d, 2);
                }
                else if (status == 2)
                {
                    decWaitClearSum += clsPublic.Round(d, 2);
                }
                else if (status == 3)
                {
                    decCompleteSum += clsPublic.Round(d, 2);
                }
            }
            decAcctSum = decTotalSum - decSbSum;

            if (decTotalSum > 0)
            {
                this.m_objViewer.lblTotalSum.Text = decTotalSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblTotalSum.Text = "";
            }
            if (decSbSum > 0)
            {
                this.m_objViewer.lblSbSum.Text = decSbSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblSbSum.Text = "";
            }
            if (decAcctSum > 0)
            {
                this.m_objViewer.lblAcctSum.Text = decAcctSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblAcctSum.Text = "";
            }
            if (decCompleteSum > 0)
            {
                this.m_objViewer.lblCompleteSum.Text = decCompleteSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblCompleteSum.Text = "";
            }
            if (decWaitClearSum > 0)
            {
                this.m_objViewer.lblPay.Text = decWaitClearSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblPay.Text = "";
            }
            if (decWaitChrgSum > 0)
            {
                this.m_objViewer.lblWaitCharge.Text = decWaitChrgSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblWaitCharge.Text = "";
            }

            //计算发票分类
            DataTable dtcat = new DataTable();
            long l = this.objSvc.m_lngGetChargeItemCat(4, out dtcat);
            string strDiffCostName = string.Empty;//药品让利发票分类名称

            if (l > 0 && dtcat.Rows.Count > 0)
            {
                ArrayList arrcat = new ArrayList();
                DataView dvcat = new DataView(ChargeDt);

                for (int i = 0; i < dtcat.Rows.Count; i++)
                {
                    string invocatid = dtcat.Rows[i]["typeid_chr"].ToString().Trim();
                    decimal invosum = 0;

                    dvcat.RowFilter = "invcateid_chr = '" + invocatid + "'";
                    foreach (DataRowView drv in dvcat)
                    {
                        invosum += clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]), 2);
                    }
                    if (string.IsNullOrEmpty(strDiffCostName) && string.Compare("3026", invocatid) == 0)
                    {
                        strDiffCostName = dtcat.Rows[i]["typename_vchr"].ToString().Trim();//获取药品让利在字典中的名称
                    }
                    if (invosum == 0)
                    {
                        continue;
                    }

                    clsInvoiceCat_VO invocat_vo = new clsInvoiceCat_VO();
                    invocat_vo.CatID = invocatid;
                    invocat_vo.CatName = dtcat.Rows[i]["typename_vchr"].ToString().Trim();
                    invocat_vo.CatSum = invosum;

                    arrcat.Add(invocat_vo);
                }
                //显示药品让利分类及值
                if (this.intDiffCostOn == 1)
                {
                    clsInvoiceCat_VO invocat_vo = new clsInvoiceCat_VO();
                    invocat_vo.CatID = "3026";
                    invocat_vo.CatName = strDiffCostName;
                    invocat_vo.CatSum = clsPublic.Round(decDiffCostSum, 2); ;

                    arrcat.Add(invocat_vo);
                }

                this.m_objViewer.lvInvoiceCat.Items.Clear();
                for (int j = 0; j < arrcat.Count; j++)
                {
                    clsInvoiceCat_VO invocat_vo = (clsInvoiceCat_VO)arrcat[j];

                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Text = invocat_vo.CatName + "\r\n" + invocat_vo.CatSum.ToString("0.00");
                    lvitem.ImageIndex = 11;
                    lvitem.Tag = invocat_vo;
                    this.m_objViewer.lvInvoiceCat.Items.Add(lvitem);
                }
            }
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        public void m_mthCharge()
        {
            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.Status == 3 && this.m_objViewer.ucPatientInfo.BihPatient_VO.FeeStatus != 4)
            {
                MessageBox.Show("该病人已办理出院结算，当前为查询状态。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (m_intParm1068 != 0)
            {
                ////////结算前判断病人在门诊是否用未交费用的处方，给出提示
                string strMessage = "";
                clsPublic.m_lngSelectPatientNoPayRecipe(this.m_objViewer.ucPatientInfo.BihPatient_VO.RegisterID, out strMessage);
                if (!string.IsNullOrEmpty(strMessage))
                {
                    if (m_intParm1068 == 1)
                    {
                        if (MessageBox.Show("是否允许结算" + strMessage, "病人门诊费用未清!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else if (m_intParm1068 == 2)
                    {
                        MessageBox.Show("不允许结算" + strMessage, "病人门诊费用未清!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //////////////////
            }
            if (ChargeDtSelect == null || ChargeDtSelect.Rows.Count == 0)
            {
                if (MessageBox.Show("该病人在住院期间没有发生任何费用，是否直接办理出院？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmReckoning f = new frmReckoning(this.m_objViewer.InvoNo);
                    if (this.m_objViewer.ucPatientInfo.BihPatient_VO.FeeStatus == 4)
                    {
                        f.ChargeType = 6;
                    }
                    else
                    {
                        f.ChargeType = 2;
                    }
                    f.ChargeDetail = null;
                    f.objPatient = this.m_objViewer.ucPatientInfo;
                    f.DayChrgType = 0;
                    f.DayAccountsArr = null;
                    f.DirectChargeOut = true;
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
                    }
                }

                return;
            }

            #region 获取帐期信息
            //结算类型 1 帐期 2 明细
            int DayChrgType = 1;

            Hashtable has = new Hashtable();
            for (int i = 0; i < ChargeDtSelect.Rows.Count; i++)
            {
                string dayid = ChargeDtSelect.Rows[i]["dayaccountid_chr"].ToString();

                if (!has.ContainsKey(dayid))
                {
                    has.Add(dayid, null);
                }
            }

            ArrayList DayaccountsNoArr = new ArrayList();
            DayaccountsNoArr.AddRange(has.Keys);

            DataView dvDayAll = new DataView(ChargeDt);
            DataView dvDaySub = new DataView(ChargeDtSelect);
            ArrayList DayAccountsArr = new ArrayList();
            for (int i = 0; i < DayaccountsNoArr.Count; i++)
            {
                string dayid = DayaccountsNoArr[i].ToString();

                clsBihDayAccounts_VO DayAccounts_VO = new clsBihDayAccounts_VO();
                DayAccounts_VO.AccountsID = dayid;
                DayAccounts_VO.ChargeEmp = this.m_objViewer.LoginInfo.m_strEmpID;

                dvDayAll.RowFilter = "dayaccountid_chr = '" + dayid + "'";
                dvDaySub.RowFilter = "dayaccountid_chr = '" + dayid + "'";

                decimal decTotalSum = 0;
                decimal decSbSum = 0;
                decimal decAcctSum = 0;

                foreach (DataRowView drv in dvDayAll)
                {
                    decimal d = clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]);
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);
                }
                decAcctSum = decTotalSum - decSbSum;

                DayAccounts_VO.TotalSum = decTotalSum;
                DayAccounts_VO.SbSum = decSbSum;
                DayAccounts_VO.AcctSum = decAcctSum;

                decTotalSum = 0;
                decSbSum = 0;
                decAcctSum = 0;

                foreach (DataRowView drv in dvDaySub)
                {
                    decimal d = clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]);
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);
                }
                decAcctSum = decTotalSum - decSbSum;

                DayAccounts_VO.ClearSbSum = decSbSum;
                DayAccounts_VO.ClearAcctSum = decAcctSum;

                DayAccountsArr.Add(DayAccounts_VO);
            }

            #endregion

            //只能结算待结、待清费用
            DataView dv = new DataView(ChargeDt);
            dv.RowFilter = "pstatus_int = 1 or pstatus_int = 2";

            DataTable dt = ChargeDt.Clone();
            foreach (DataRowView drv in dv)
            {
                dt.Rows.Add(drv.Row.ItemArray);
            }
            dt.AcceptChanges();

            frmReckoning frec = new frmReckoning(this.m_objViewer.InvoNo);
            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.FeeStatus == 4)
            {
                frec.ChargeType = 6;
            }
            else
            {
                frec.ChargeType = 2;
            }
            frec.ChargeDetail = dt;
            frec.objPatient = this.m_objViewer.ucPatientInfo;
            frec.DayChrgType = DayChrgType;
            frec.DayAccountsArr = DayAccountsArr;
            if (frec.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
        }
        #endregion

        #region 重打发票
        /// <summary>
        /// 重打发票
        /// </summary>        
        public void m_mthRepeatPrt()
        {
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRepeatPrt finvoprt = new frmInvoiceRepeatPrt(RegID);
            finvoprt.ShowDialog();
        }
        #endregion

        #region 退款
        /// <summary>
        /// 退款
        /// </summary>
        public void m_mthRefundment()
        {
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            int ChargeType = 2;
            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.FeeStatus == 6)
            {
                ChargeType = 6;
            }
            frmInvoiceRefundment finvoref = new frmInvoiceRefundment(RegID, ChargeType);
            finvoref.ShowDialog();
            if (finvoref.IsRefundment)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
        }
        #endregion

        #region 下载医保数据
        /// <summary>
        /// 下载医保数据
        /// </summary>
        public void m_mthDownLoadYBData()
        {
            if (this.m_objViewer.ucPatientInfo.RegisterID == "")
            {
                return;
            }

            #region 获取连接医保前置数据库参数
            string tmpfs = clsPublic.XMLFile;
            clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";

            //获取连接医保前置数据库参数                
            string DSN = clsPublic.m_strReadXML("FOSHAN.NO2", "DBDSN", "AnyOne");
            string UserID = clsPublic.m_strReadXML("FOSHAN.NO2", "DBUserID", "AnyOne");
            string PassWord = clsPublic.m_strReadXML("FOSHAN.NO2", "DBPassWord", "AnyOne");
            string Hospcode = clsPublic.m_strReadXML("FOSHAN.NO2", "HospitalNO", "AnyOne");
            string DB2Parm = "DSN=" + DSN + ";UID=" + UserID + ";PWD=" + PassWord;

            clsPublic.XMLFile = tmpfs;
            #endregion

            frmYB_F2DownLoad fd = new frmYB_F2DownLoad();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                int type = fd.DoType;
                if (type == 1)
                {
                    if (MessageBox.Show("住院号:" + this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh + "  姓名:" + this.m_objViewer.ucPatientInfo.BihPatient_VO.Name + "\r\n\r\n确认是否从医保前置机下载费用明细?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.m_objViewer.Cursor = Cursors.WaitCursor;
                        DataTable dt;
                        long l = this.objSvc.m_lngDownloadYBData(DB2Parm, Hospcode, this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh, this.m_objViewer.ucPatientInfo.BihPatient_VO.InsuredZycs.ToString(), out dt);
                        if (l > 0)
                        {
                            l = this.objSvc.m_lngDownloadYBData(dt);
                            if (l <= 0)
                            {
                                this.m_objViewer.Cursor = Cursors.Default;
                                MessageBox.Show("下载数据失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            this.m_objViewer.Cursor = Cursors.Default;
                            MessageBox.Show("下载数据失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else if (type == 2)
                {
                    if (MessageBox.Show("住院号:" + this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh + "  姓名:" + this.m_objViewer.ucPatientInfo.BihPatient_VO.Name + "\r\n\r\n确认是否删除?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.m_objViewer.Cursor = Cursors.WaitCursor;

                        long l = this.objSvc.m_lngDelDownloadYBData(this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh, this.m_objViewer.ucPatientInfo.BihPatient_VO.InsuredZycs);
                        if (l <= 0)
                        {
                            this.m_objViewer.Cursor = Cursors.Default;
                            MessageBox.Show("删除数据失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else if (type == 3)
                {
                    this.m_objViewer.Cursor = Cursors.WaitCursor;
                    DataTable dt;
                    long l = this.objSvc.m_lngGetDownloadYBData(this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh, this.m_objViewer.ucPatientInfo.BihPatient_VO.InsuredZycs, out dt);
                    if (l > 0)
                    {
                        l = this.objSvc.m_lngSendybdata(DB2Parm, dt);
                        if (l <= 0)
                        {
                            this.m_objViewer.Cursor = Cursors.Default;
                            MessageBox.Show("上传下载数据失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        this.m_objViewer.Cursor = Cursors.Default;
                        MessageBox.Show("获取下载数据失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                this.m_objViewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 检查婴儿费
        /// <summary>
        /// 检查婴儿费
        /// </summary>
        /// <param name="Zyh"></param>
        public void m_mthCheckBaby(string Zyh)
        {
            DataTable dt;
            long l = this.objSvc.m_lngCheckBaby(Zyh, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                string Msg = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    Msg += dr["inpatientid_chr"].ToString() + "  " + dr["lastname_vchr"].ToString() + "  " + dr["sex_chr"].ToString() + "  \r\n\r\n";
                }

                MessageBox.Show("温馨提示：\r\n\r\n" + Msg + "费用未结。", "出院结算", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        #region 判断该病人是否有婴儿关联-母亲合并结算用 by yibin.zheng 09-07-03
        /// <summary>
        /// 判断该病人是否有婴儿关联
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        public bool m_blnHaveBaby(string p_strRegisterId, out DataTable p_dtbBabyCharge)
        {
            DataTable dtbBaby = null;
            p_dtbBabyCharge = new DataTable();
            long lngRes = this.objSvc.m_lngGetBabyRegisterId(p_strRegisterId, out dtbBaby);
            if (dtbBaby.Rows.Count > 0 && lngRes > 0)
            {
                int intRowsCount = dtbBaby.Rows.Count;
                string strBabyRegisterId = "";
                for (int i = 0; i < intRowsCount; i++)
                {
                    strBabyRegisterId += "'" + dtbBaby.Rows[i]["registerid_chr"] + "',";
                }
                strBabyRegisterId = strBabyRegisterId.Remove(strBabyRegisterId.Length - 1);
                lngRes = this.objSvc.m_lngCheckBabyNoPayCharge(strBabyRegisterId, out p_dtbBabyCharge);
                if (lngRes > 0 && p_dtbBabyCharge.Rows.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region 嵌入式社保结算单打印
        /// <summary>
        /// 社保结算单打印
        /// </summary>
        public void m_mthYBPrintBillDet()
        {
            clsCtl_YBChargeZY ctlYBChargeZY = new clsCtl_YBChargeZY();
            ctlYBChargeZY.m_mthYBChang(this.m_objViewer.ucPatientInfo.RegisterID, this.m_objViewer.LoginInfo.m_strEmpNo);
        }
        #endregion
    }
}
