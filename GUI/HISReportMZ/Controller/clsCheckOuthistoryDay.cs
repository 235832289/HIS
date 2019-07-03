using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// frmCheckOuthistoryDay 的摘要说明。
    /// </summary>
    public class clsCheckOuthistoryDay : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCheckOuthistoryDay()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            HospitalTitle = this.m_objComInfo.m_strGetHospitalTitle();
        }
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmCheckOutHistoryDay m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCheckOutHistoryDay)frmMDI_Child_Base_in;
        }
        #endregion

        private DataTable dtCheckOut = new DataTable();
        private DataTable dtPayType = new DataTable();
        private DataTable dtRecipesumde = new DataTable();
        private DataTable dtPayment = new DataTable();
        public DataTable dtStatistics;//统计表
        clsDomainControl_Register Domain = new clsDomainControl_Register();
        private string strBeginDate, strEndDate;
        internal string HospitalTitle = "";
        public void getData(string INTERNALFLAG, string checkOutName)
        {
            currRow = 0;
            totailNuber = 0;
            DataTable dtEmp = null;
            //strDate = this.m_objViewer.m_CheckOuDate.Value.ToShortDateString();
            strBeginDate = this.m_objViewer.m_CheckOuDate.Value.ToString("yyyy-MM-dd");
            strEndDate = this.m_objViewer.m_CheckOuDate2.Value.ToString("yyyy-MM-dd");
            if (this.m_objViewer.strDeptFlag == "0")
            {
                Domain.m_lngGetPayTypeAndCheckOutBetWeenDay(strBeginDate, strEndDate, out dtPayType, out dtCheckOut,out dtRecipesumde,out dtPayment, out dtEmp, INTERNALFLAG, checkOutName);
            }
            else if (this.m_objViewer.strDeptFlag == "1")
            {
                Domain.m_lngGetPayTypeAndCheckOutBetofDept(strBeginDate, strEndDate, out dtPayType, out dtCheckOut, out dtEmp, INTERNALFLAG, checkOutName);
            }
            #region 生成一个统计表
            dtStatistics = new DataTable();
            dtStatistics.Columns.Add("缴款人");
            dtStatistics.Columns.Add("开票数");
            dtStatistics.Columns.Add("开票金额");
            dtStatistics.Columns.Add("退票数");
            dtStatistics.Columns.Add("退票金额");
            dtStatistics.Columns.Add("恢复票数");
            dtStatistics.Columns.Add("恢复金额");
            dtStatistics.Columns.Add("有效票数");
            dtStatistics.Columns.Add("实收金额");
            dtStatistics.Columns.Add("实收现金");
            dtStatistics.Columns.Add("刷卡金额");
            dtStatistics.Columns.Add("支票金额");
            dtStatistics.Columns.Add("医保记账");
            dtStatistics.Columns.Add("公费记账");
            dtStatistics.Columns.Add("医保人次");
            dtStatistics.Columns.Add("公费人次");
            dtStatistics.Columns.Add("自费人次");
            dtStatistics.Columns.Add("其它记帐金额");

            dtStatistics.Columns.Add("其它金额合计");
            dtStatistics.Columns.Add("IC卡金额合计");
            dtStatistics.Columns.Add("特困记帐");
            dtStatistics.Columns.Add("离休记帐");
            dtStatistics.Columns.Add("本院记帐");
            dtStatistics.Columns.Add("门诊合作医疗记帐");
            #endregion

            #region 统计各种收费类型的金额
            dtPayType.Columns.Add("tolMoney");
            if (dtRecipesumde.Rows.Count >= 0)
            {
                for (int i1 = 0; i1 < dtPayType.Rows.Count; i1++)
                {
                    Double tolMoney = 0;
                    for (int f2 = 0; f2 < dtRecipesumde.Rows.Count; f2++)
                    {
                        if (dtRecipesumde.Rows[f2]["itemcatid_chr"].ToString().Trim() == dtPayType.Rows[i1]["typeid_chr"].ToString().Trim())
                        {
                            tolMoney += Convert.ToDouble(dtRecipesumde.Rows[f2]["tolfee_mny"].ToString().Trim());
                        }
                    }
                    dtPayType.Rows[i1]["tolMoney"] = tolMoney.ToString("0.00");
                }
            }
            #endregion

            #region 统计数据
            if (dtEmp == null)
            {
                dtEmp = new DataTable();
                dtEmp.Columns.Add("BALANCEEMP_CHR");
                dtEmp.Columns.Add("LASTNAME_VCHR");
                if (this.m_objViewer.m_cboCheckMan.SelectItemText != "全部")
                {
                    DataRow newRow = dtEmp.NewRow();
                    newRow["BALANCEEMP_CHR"] = this.m_objViewer.m_cboCheckMan.SelectItemValue.ToString();
                    newRow["LASTNAME_VCHR"] = this.m_objViewer.m_cboCheckMan.SelectItemText.ToString();
                    dtEmp.Rows.Add(newRow);
                }
            }
            DataRow AddRow = dtEmp.NewRow();
            AddRow["LASTNAME_VCHR"] = "全部合计";
            dtEmp.Rows.Add(AddRow);
            for (int f2 = 0; f2 < dtEmp.Rows.Count; f2++)
            {
                DataRow StatisticsRow = dtStatistics.NewRow();
                StatisticsRow["缴款人"] = dtEmp.Rows[f2]["LASTNAME_VCHR"].ToString();
                StatisticsRow["开票数"] = 0;
                StatisticsRow["开票金额"] = 0.00;
                StatisticsRow["退票数"] = 0;
                StatisticsRow["退票金额"] = 0.00;
                StatisticsRow["恢复票数"] = 0;
                StatisticsRow["恢复金额"] = 0.00;
                StatisticsRow["有效票数"] = 0;
                StatisticsRow["实收金额"] = 0.00;
                StatisticsRow["实收现金"] = 0.00;
                StatisticsRow["刷卡金额"] = 0.00;
                StatisticsRow["支票金额"] = 0.00;
                StatisticsRow["医保记账"] = 0.00;
                StatisticsRow["公费记账"] = 0.00;
                StatisticsRow["其它记帐金额"] = 0.00;
                StatisticsRow["医保人次"] = 0;
                StatisticsRow["公费人次"] = 0;
                StatisticsRow["自费人次"] = 0;
                StatisticsRow["其它金额合计"] = 0;
                StatisticsRow["IC卡金额合计"] = 0;
                StatisticsRow["特困记帐"] = 0;
                StatisticsRow["离休记帐"] = 0;
                StatisticsRow["本院记帐"] = 0;
                StatisticsRow["门诊合作医疗记帐"] = 0;
                DateTime startDateTime = new DateTime();
                DateTime endDateTime = new DateTime();
                if (dtEmp.Rows[f2]["LASTNAME_VCHR"].ToString() != "全部合计")
                {
                    #region 统计有关发票的信息
                    if (dtCheckOut.Rows.Count > 0)
                    {
                        for (int i1 = 0; i1 < dtCheckOut.Rows.Count; i1++)
                        {
                            //-------------------



                            //统计开票数,开票金额
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "1" && dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                                }
                                else
                                {
                                    if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    {
                                    }
                                    else
                                    {
                                        StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                                    }
                                }
                                StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["totalsum_mny"].ToString());
                            }
                            //-------------------------------


                            //退票数,退票金额合计,所有的退票号
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2" && dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                                }
                                else
                                {
                                    if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    {

                                    }
                                    else
                                    {
                                        StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                                    }
                                }
                                StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["totalsum_mny"].ToString());

                            }
                            //--------------------


                            //恢复票数,恢复金额合计
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "3" && dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                                }
                                else
                                {
                                    if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    {

                                    }
                                    else
                                    {
                                        StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                                    }
                                }

                                StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["totalsum_mny"].ToString());
                            }
                            //-----------------
                        }
                    }

                    #endregion


                    #region 统计各种支付方式和支付类型

                    if (dtPayment.Rows.Count > 0)
                    {

                        for (int i1 = 0; i1 < dtPayment.Rows.Count; i1++)
                        {
                            ////-------------------



                            ////统计开票数,开票金额
                            //if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "1" && dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            //{
                            //    if (i1 == 0)
                            //    {
                            //        StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                            //        //StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            //        {
                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                            //            // StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //        }
                            //    }
                            //    StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["tolfee_mny"].ToString());
                            //}
                            ////-------------------------------


                            #region 特困记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "3" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion

                            #region 门诊合作医疗记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "6" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion
                            #region 离休记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "4" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion

                            #region 本院记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "5" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion

                            #region IC卡支付

                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "3" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }

                            #endregion

                            #region 其它金额合计

                            ////佛二：其它支付－>其他记帐
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "0" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            //if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="0"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="3"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5"&&dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim()==dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            //{
                            //    if(i1==0)
                            //    {
                            //        StatisticsRow["其它金额合计"]=Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
                            //        {

                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["其它金额合计"]=Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            //        }
                            //    }

                            //}

                            #endregion



                            ////退票数,退票金额合计,所有的退票号
                            //if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2" && dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            //{
                            //    if (i1 == 0)
                            //    {
                            //        StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                            //        //StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            //        {

                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                            //            //StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //        }
                            //    }
                            //    StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["tolfee_mny"].ToString());

                            //}
                            ////--------------------


                            ////恢复票数,恢复金额合计
                            //if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "3" && dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            //{
                            //    if (i1 == 0)
                            //    {
                            //        StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                            //        // StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            //        {

                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                            //            // StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //        }
                            //    }

                            //    StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["tolfee_mny"].ToString());
                            //}
                            ////-----------------



                            //统计现金合计
                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "0" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["实收现金"] = Convert.ToDouble(StatisticsRow["实收现金"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["实收现金"] = Convert.ToDouble(StatisticsRow["实收现金"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            //-----------------



                            //刷卡合计
                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "1" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["刷卡金额"] = Convert.ToDouble(StatisticsRow["刷卡金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["刷卡金额"] = Convert.ToDouble(StatisticsRow["刷卡金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            //--------------

                            //支票
                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "2" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["支票金额"] = Convert.ToDouble(StatisticsRow["支票金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["支票金额"] = Convert.ToDouble(StatisticsRow["支票金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            //-----------------


                            //医保记账金额及人次
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "2" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) + 1;
                                    StatisticsRow["医保记账"] = Convert.ToDouble(StatisticsRow["医保记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) + 1;
                                    StatisticsRow["医保记账"] = Convert.ToDouble(StatisticsRow["医保记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }


                            }
                            //-----------------


                            //公费记账金额及人次
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "1" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) + 1;
                                    StatisticsRow["公费记账"] = Convert.ToDouble(StatisticsRow["公费记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) + 1;
                                    StatisticsRow["公费记账"] = Convert.ToDouble(StatisticsRow["公费记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }



                            }
                            //-------------------


                            //其它记帐金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "1" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "2" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "3" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "4" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "5" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "6")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }



                            }
                            //-------------------

                            //自费上缴金额及人次
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "0" && dtPayment.Rows[i1]["BALANCEEMP_CHR"].ToString().Trim() == dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString().Trim())
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) + 1;
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) + 1;
                                    //}
                                }

                            }

                        }
                    }

                    #endregion
                }
                else
                {
                    #region 统计有关发票的信息(合计)
                    for (int i1 = 0; i1 < dtCheckOut.Rows.Count; i1++)
                    {
                        //-----------------

                        //统计开票数,开票金额
                        if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "1")
                        {
                            if (i1 == 0)
                            {
                                StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                                // StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                {

                                }
                                else
                                {
                                    StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                                    // StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                            }
                            StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["totalsum_mny"].ToString());

                        }
                        //--------------------


                        //退票数,退票金额合计,所有的退票号
                        if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                        {
                            if (i1 == 0)
                            {
                                StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                                //StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                {

                                }
                                else
                                {
                                    StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                                    // StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                            }
                            StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["totalsum_mny"].ToString());

                        }
                        //------------------


                        //恢复票数,恢复金额合计
                        if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "3")
                        {
                            if (i1 == 0)
                            {
                                StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                                //StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                {

                                }
                                else
                                {
                                    StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                                    //  StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                            }
                            StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["totalsum_mny"].ToString());

                        }
                    }
                    #endregion


                    #region 统计各种支付方式和支付类型(合计)
                    if (dtPayment.Rows.Count > 0)
                    {
                        for (int i1 = 0; i1 < dtPayment.Rows.Count; i1++)
                        {
                            ////-----------------

                            ////统计开票数,开票金额
                            //if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "1")
                            //{
                            //    if (i1 == 0)
                            //    {
                            //        StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                            //        // StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            //        {

                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                            //            // StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //        }
                            //    }
                            //    StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["tolfee_mny"].ToString());

                            //}
                            ////--------------------


                            ////退票数,退票金额合计,所有的退票号
                            //if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            //{
                            //    if (i1 == 0)
                            //    {
                            //        StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                            //        //StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            //        {

                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                            //            // StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //        }
                            //    }
                            //    StatisticsRow["退票金额"] = Convert.ToDouble(StatisticsRow["退票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["tolfee_mny"].ToString());

                            //}
                            ////------------------


                            ////恢复票数,恢复金额合计
                            //if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "3")
                            //{
                            //    if (i1 == 0)
                            //    {
                            //        StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                            //        //StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //    }
                            //    else
                            //    {
                            //        if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            //        {

                            //        }
                            //        else
                            //        {
                            //            StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                            //            //  StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            //        }
                            //    }
                            //    StatisticsRow["恢复金额"] = Convert.ToDouble(StatisticsRow["恢复金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["tolfee_mny"].ToString());

                            //}
                            ////-----------------


                            //统计现金合计
                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "0")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["实收现金"] = Convert.ToDouble(StatisticsRow["实收现金"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["实收现金"] = Convert.ToDouble(StatisticsRow["实收现金"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            //--------------------


                            //刷卡合计
                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "1")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["刷卡金额"] = Convert.ToDouble(StatisticsRow["刷卡金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["刷卡金额"] = Convert.ToDouble(StatisticsRow["刷卡金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            //----------------------


                            //支票
                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "2")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["支票金额"] = Convert.ToDouble(StatisticsRow["支票金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["支票金额"] = Convert.ToDouble(StatisticsRow["支票金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            //---------------------------


                            #region 门诊合作医疗记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "6")
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion
                            //医保记账金额及人次
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "2")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) + 1;
                                    StatisticsRow["医保记账"] = Convert.ToDouble(StatisticsRow["医保记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) + 1;
                                    StatisticsRow["医保记账"] = Convert.ToDouble(StatisticsRow["医保记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }


                            }
                            //--------------------


                            //公费记账金额及人次
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "1")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) + 1;
                                    StatisticsRow["公费记账"] = Convert.ToDouble(StatisticsRow["公费记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) + 1;
                                    StatisticsRow["公费记账"] = Convert.ToDouble(StatisticsRow["公费记账"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }



                            }

                            //--------------------


                            //其它记帐金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "1" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "2" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "3" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "4" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "5" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "6")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }



                            }

                            //-----------------------


                            //自费上缴金额及人次
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "0")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) + 1;
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) + 1;
                                    //}
                                }
                            }
                            #region 特困记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "3")
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion

                            #region 离休记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "4")
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion

                            #region 本院记账金额
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "5")
                            {
                                if (i1 == 0)
                                {

                                    StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());

                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{

                                    StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    //}
                                }
                            }

                            #endregion

                            #region IC卡支付

                            if (dtPayment.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "3")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }

                            #endregion

                            #region 其它金额合计
                            if (dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "0" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "1" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "2" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "3" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "4" && dtPayment.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "5")
                            {
                                if (i1 == 0)
                                {
                                    StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    //if (dtPayment.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtPayment.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim())
                                    //{

                                    //}
                                    //else
                                    //{
                                    StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtPayment.Rows[i1]["SBSUM_MNY"].ToString());
                                    //}
                                }

                            }
                            #endregion
                        }
                    }
                    #endregion
                }
                int intAvailability = Convert.ToInt32(StatisticsRow["开票数"].ToString().Trim()) - Convert.ToInt32(StatisticsRow["退票数"].ToString().Trim()) + Convert.ToInt32(StatisticsRow["恢复票数"].ToString().Trim());
                Double AvailabilityMoney = Convert.ToDouble(StatisticsRow["开票金额"].ToString().Trim()) + Convert.ToDouble(StatisticsRow["退票金额"].ToString().Trim()) + Convert.ToDouble(StatisticsRow["恢复金额"].ToString().Trim());
                StatisticsRow["有效票数"] = intAvailability.ToString();
                StatisticsRow["实收金额"] = AvailabilityMoney.ToString();
                dtStatistics.Rows.Add(StatisticsRow);

            }
            #endregion
        }

        public void printPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 变量
            float PageWidth = e.PageBounds.Width;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高度
            float curRowY = 0;//当前行的Y坐标
            float curRowX = 0;//当前行的X坐标
            System.Drawing.Font m_fntTitle = new Font("宋体", 18);//标题使用的字体
            System.Drawing.Font TextFont = new Font("宋体", 11);//文字使用的字体
            System.Drawing.Font TextFontBold = new Font("宋体", 11, System.Drawing.FontStyle.Bold);//文字使用的字体(加粗）
            const float RowHight = 25F;//项的高度
            const float LeftWith = 30F;//左右宿进的长度
            const float Uphight = 15F;//上下宿进的长度
            const float fontHight = 7;//字在表格中显示的位置
            float SaveStartHight = 0;
            #endregion

            #region 头部
            Pen penLine = new Pen(Brushes.Black, 1);
            curRowY = RowHight + Uphight + 10;
            curRowX += LeftWith;

            SizeF tilWith = e.Graphics.MeasureString(HospitalTitle + "收费处日结报表", m_fntTitle);
            e.Graphics.DrawString(HospitalTitle + "收费处日结报表", m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);
            e.Graphics.DrawString("结帐日期：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("结帐日期：", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(Convert.ToDateTime(strBeginDate).ToString("yyyy年MM月dd日") + "~" + Convert.ToDateTime(strEndDate).ToString("yyyy年MM月dd日"), TextFont, Brushes.Black, curRowX, curRowY);
            if (this.m_objViewer.strDeptFlag == "1")
            {
                tilWith = e.Graphics.MeasureString("统计科室:" + this.m_objViewer.m_cboCheckMan.SelectItemText, TextFont);
                e.Graphics.DrawString("统计科室:" + this.m_objViewer.m_cboCheckMan.SelectItemText, TextFont, Brushes.Black, (e.PageBounds.Width - tilWith.Width) / 2, curRowY);
            }
            e.Graphics.DrawString("打印日期：", TextFont, Brushes.Black, PageWidth - 250, curRowY);
            tilWith = e.Graphics.MeasureString("打印日期：", TextFont);
            string NowDate = DateTime.Now.ToString("yyyy年MM月dd日");
            e.Graphics.DrawString(NowDate, TextFont, Brushes.Black, PageWidth - 250 + tilWith.Width, curRowY);
            #endregion
            curRowX = LeftWith;
            curRowY += 18;

            #region 画表格
            float X1 = 0;
            float X2 = 0;
            float X3 = 0;
            float X4 = 0;
            float X5 = 0;
            float X6 = 0;
            float X7 = 0;
            float X8 = 0;
            for (int i1 = 0; i1 < dtStatistics.Rows.Count; i1++)
            {
                if (i1 == 0)
                {
                    SaveStartHight = curRowY;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
                    e.Graphics.DrawString("缴 款 人", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("，，，，，", TextFont);
                    curRowX += tilWith.Width;
                    X1 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    curRowX += 2;
                    e.Graphics.DrawString("开  票  数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("开  票  数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X2 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("开 票 金 额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("开 票 金 额", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X3 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("退票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("退票数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X4 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);


                    e.Graphics.DrawString("退票金额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("退票金额", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X5 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("恢复票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("恢复票数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X6 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("恢复金额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("恢复金额", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X7 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("有效票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("有效票数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X8 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("     实 收 金 额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("     实 收 金 额", TextFont);
                }

                if (i1 == dtStatistics.Rows.Count - 1)
                {
                    curRowY += RowHight;
                    curRowX = LeftWith;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight, PageWidth - LeftWith, curRowY + RowHight);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 2, PageWidth - LeftWith, curRowY + RowHight * 2);

                    e.Graphics.DrawString(dtStatistics.Rows[i1]["缴款人"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("实收现金", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("人次统计", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX = X1;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["开票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收现金"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    //					e.Graphics.DrawString(dtStatistics.Rows[i1]["医保记账"].ToString().Trim()+"元",TextFontBold,Brushes.Black,curRowX,curRowY+RowHight*2+fontHight);
                    curRowX += 2;
                    e.Graphics.DrawString("医保人次：", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    tilWith = e.Graphics.MeasureString("医保人次：", TextFontBold);
                    curRowX += tilWith.Width;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["医保人次"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    curRowX += 100;
                    e.Graphics.DrawString("公费人次：", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    tilWith = e.Graphics.MeasureString("公费人次：", TextFontBold);
                    curRowX += tilWith.Width;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["公费人次"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX += 100;
                    e.Graphics.DrawString("自费人次：", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    tilWith = e.Graphics.MeasureString("自费人次：", TextFontBold);
                    curRowX += tilWith.Width;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["自费人次"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    curRowX = X2;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["开票金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("刷 卡 金 额", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X3;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["退票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["刷卡金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X4;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["退票金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("支票金额", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X5;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["支票金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X6;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["恢复金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    curRowX = X7;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["有效票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);

                    curRowX = X8;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);
                    e.Graphics.DrawString("公费记帐", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    tilWith = e.Graphics.MeasureString("公费记帐 ", TextFont);
                    e.Graphics.DrawLine(penLine, curRowX + tilWith.Width, curRowY + RowHight, curRowX + tilWith.Width, curRowY + RowHight * 2);
                    //					e.Graphics.DrawString(dtStatistics.Rows[i1]["公费记账"].ToString().Trim()+"元",TextFontBold,Brushes.Black,curRowX+tilWith.Width+2,curRowY+RowHight+fontHight);
                    curRowX += 40;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);

                    curRowY += RowHight * 3;
                    e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);

                }
                else
                {
                    curRowY += RowHight;
                    curRowX = LeftWith;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight, PageWidth - LeftWith, curRowY + RowHight);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 2, PageWidth - LeftWith, curRowY + RowHight * 2);

                    e.Graphics.DrawString(dtStatistics.Rows[i1]["缴款人"].ToString().Trim(), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("实收现金", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X1;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["开票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收现金"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X2;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["开票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("刷 卡 金 额", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X3;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["退票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["刷卡金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X4;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["退票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("支票金额", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X5;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["支票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X6;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["恢复金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("医保记帐", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X7;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["有效票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["医保记账"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    curRowX = X8;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 2);
                    e.Graphics.DrawString("公费记帐", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    tilWith = e.Graphics.MeasureString("公费记帐 ", TextFont);
                    e.Graphics.DrawLine(penLine, curRowX + tilWith.Width, curRowY + RowHight, curRowX + tilWith.Width, curRowY + RowHight * 2);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["公费记账"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX + tilWith.Width + 2, curRowY + RowHight + fontHight);
                    curRowX += 40;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    curRowY += RowHight * 2;
                }

            }
            #region 填充收费类型数据
            if (dtPayType.Rows.Count > 0)
            {
                curRowY += RowHight;
                e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);
                curRowY += 7;
                float tmpWith = LeftWith + 2;
                for (int f2 = 0; f2 < dtPayType.Rows.Count; f2++)
                {
                    if (f2 % 5 == 0 && f2 != 0)
                    {
                        tmpWith = LeftWith + 2;
                        curRowY += RowHight + 5;
                    }
                    tilWith = e.Graphics.MeasureString("打印日期", TextFont);
                    if (dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length > 4)
                    {
                        string star = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0, 4);
                        string end = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
                        e.Graphics.DrawString(star, TextFont, Brushes.Black, tmpWith, curRowY - 5);
                        e.Graphics.DrawString(end + "：", TextFont, Brushes.Black, tmpWith, curRowY + 10);
                        e.Graphics.DrawString("￥" + Convert.ToDouble(dtPayType.Rows[f2]["tolMoney"].ToString()).ToString("0.00") + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                    }
                    else
                    {
                        e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim() + "：", TextFont, Brushes.Black, tmpWith, curRowY);
                        e.Graphics.DrawString("￥" + Convert.ToDouble(dtPayType.Rows[f2]["tolMoney"].ToString()).ToString("0.00") + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                    }
                    tmpWith += 146;
                }
            }
            curRowY += RowHight;
            curRowX = LeftWith;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
            curRowX += 2;
            curRowY += 7;
            e.Graphics.DrawString("统计人：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("统计人： ", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName, TextFont, Brushes.Black, curRowX, curRowY);
            curRowX += 200;
            e.Graphics.DrawString("审核人：", TextFont, Brushes.Black, curRowX, curRowY);
            curRowX += 200;
            e.Graphics.DrawString("出纳：", TextFont, Brushes.Black, curRowX, curRowY);
            curRowY += RowHight - 7;
            e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);

            e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
            e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
            #endregion

            #endregion

        }
        public void printPageMB(System.Drawing.Printing.PrintPageEventArgs e, string INTERNALFLAG)
        {
            #region 变量
            float PageWidth = e.PageBounds.Width;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高度
            float curRowY = 0;//当前行的Y坐标
            float curRowX = 0;//当前行的X坐标
            System.Drawing.Font m_fntTitle = new Font("宋体", 15);//标题使用的字体
            System.Drawing.Font TextFont = new Font("宋体", 11);//文字使用的字体
            System.Drawing.Font TextFontBold = new Font("宋体", 11, System.Drawing.FontStyle.Bold);//文字使用的字体(加粗）
            const float RowHight = 25F;//项的高度
            const float LeftWith = 30F;//左右宿进的长度
            const float Uphight = 15F;//上下宿进的长度
            const float fontHight = 7;//字在表格中显示的位置
            float SaveStartHight = 0;
            #endregion

            #region 头部
            Pen penLine = new Pen(Brushes.Black, 1);
            curRowY = RowHight + Uphight + 10;
            curRowX += LeftWith;
            SizeF tilWith = e.Graphics.MeasureString(HospitalTitle + "收费处日结报表", m_fntTitle);
            if (INTERNALFLAG == "-1")
            {
                e.Graphics.DrawString(HospitalTitle + "收费处日结报表", m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);
            }
            else if (INTERNALFLAG == "0")
            {
                e.Graphics.DrawString(HospitalTitle + "收费处日结报表（慢病）", m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);
            }
            else
            {
                e.Graphics.DrawString(HospitalTitle + "收费处日结报表（红会）", m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);
            }
            e.Graphics.DrawString("结帐日期：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("结帐日期：", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(Convert.ToDateTime(strBeginDate).ToString("yyyy年MM月dd日") + "~" + Convert.ToDateTime(strEndDate).ToString("yyyy年MM月dd日"), TextFont, Brushes.Black, curRowX, curRowY);
            if (this.m_objViewer.strDeptFlag == "1")
            {
                tilWith = e.Graphics.MeasureString("统计科室:" + this.m_objViewer.m_cboCheckMan.SelectItemText, TextFont);
                e.Graphics.DrawString("统计科室:" + this.m_objViewer.m_cboCheckMan.SelectItemText, TextFont, Brushes.Black, (e.PageBounds.Width - tilWith.Width) / 2, curRowY);
            }
            e.Graphics.DrawString("打印日期：", TextFont, Brushes.Black, PageWidth - 250, curRowY);
            tilWith = e.Graphics.MeasureString("打印日期：", TextFont);
            string NowDate = DateTime.Now.ToString("yyyy年MM月dd日");
            e.Graphics.DrawString(NowDate, TextFont, Brushes.Black, PageWidth - 250 + tilWith.Width, curRowY);
            #endregion
            curRowX = LeftWith;
            curRowY += 18;

            #region 画表格
            float X1 = 0;
            float X2 = 0;
            float X3 = 0;
            float X4 = 0;
            float X5 = 0;
            float X6 = 0;
            float X7 = 0;
            float X8 = 0;
            for (int i1 = 0; i1 < dtStatistics.Rows.Count; i1++)
            {
                if (i1 == 0)
                {
                    SaveStartHight = curRowY;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
                    e.Graphics.DrawString("缴 款 人", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("，，，，，", TextFont);
                    curRowX += tilWith.Width;
                    X1 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    curRowX += 2;
                    e.Graphics.DrawString("开  票  数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("开  票  数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X2 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("开 票 金 额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("开 票 金 额", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X3 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("退 票 数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("退 票 数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X4 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);


                    e.Graphics.DrawString("退 票 金 额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("退 票 金 额", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X5 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("恢复票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("恢复票数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X6 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString(" 恢复金额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString(" 恢复金额", TextFont);
                    curRowX += 15 + tilWith.Width;
                    X7 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString("有效票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString("有效票数", TextFont);
                    curRowX += 2 + tilWith.Width;
                    X8 = curRowX;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    e.Graphics.DrawString(" 实 收 金 额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    tilWith = e.Graphics.MeasureString(" 实 收 金 额", TextFont);
                }

                if (i1 == dtStatistics.Rows.Count - 1)
                {
                    curRowY += RowHight;
                    curRowX = LeftWith;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight, PageWidth - LeftWith, curRowY + RowHight);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 2, PageWidth - LeftWith, curRowY + RowHight * 2);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 3, PageWidth - LeftWith, curRowY + RowHight * 3);

                    e.Graphics.DrawString(dtStatistics.Rows[i1]["缴款人"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("实收现金", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("医保记帐", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    e.Graphics.DrawString("人次统计", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
                    curRowX = X1;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 4);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["开票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收现金"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["医保记账"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);



                    curRowX += 2;
                    e.Graphics.DrawString("医保人次：", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
                    tilWith = e.Graphics.MeasureString("医保人次：", TextFontBold);
                    curRowX += tilWith.Width;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["医保人次"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
                    curRowX += 100;
                    e.Graphics.DrawString("公费人次：", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
                    tilWith = e.Graphics.MeasureString("公费人次：", TextFontBold);
                    curRowX += tilWith.Width;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["公费人次"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);

                    curRowX += 100;
                    e.Graphics.DrawString("自费人次：", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
                    tilWith = e.Graphics.MeasureString("自费人次：", TextFontBold);
                    curRowX += tilWith.Width;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["自费人次"].ToString().Trim(), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
                    curRowX = X2;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);



                    curRowX = X2;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["开票金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);


                    curRowX = X3;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["退票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("刷卡金额", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("公费记帐", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX = X4;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["退票金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["刷卡金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["公费记账"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX = X5;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);


                    curRowX = X6;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["恢复金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("支票金额", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("其它记帐", TextFontBold, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);


                    curRowX = X7;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["有效票数"].ToString().Trim() + "张", TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["支票金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight + RowHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["其它记帐金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight + RowHight * 2);
                    curRowX = X8;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收金额"].ToString()).ToString("0.00"), TextFontBold, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);
                    curRowY += RowHight * 4;
                    e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);

                }
                else
                {
                    curRowY += RowHight;
                    curRowX = LeftWith;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight, PageWidth - LeftWith, curRowY + RowHight);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 2, PageWidth - LeftWith, curRowY + RowHight * 2);
                    e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 3, PageWidth - LeftWith, curRowY + RowHight * 3);
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["缴款人"].ToString().Trim(), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("实收现金", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    //					e.Graphics.DrawString("公费记帐",TextFont,Brushes.Black,curRowX,curRowY+RowHight*2+fontHight);
                    e.Graphics.DrawString("医保记帐", TextFont, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    curRowX = X1;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["开票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收现金"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["医保记账"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX = X2;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["开票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    curRowX = X3;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["退票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("刷卡金额", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("公费记帐", TextFont, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);


                    curRowX = X4;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["退票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["刷卡金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["公费记账"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
                    //					e.Graphics.DrawString("支票金额",TextFont,Brushes.Black,curRowX,curRowY+RowHight+fontHight);
                    curRowX = X5;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);

                    curRowX = X6;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["恢复金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("支票金额", TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("其它记帐", TextFont, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX = X7;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

                    curRowX += 2;
                    e.Graphics.DrawString(dtStatistics.Rows[i1]["有效票数"].ToString().Trim() + "张", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["支票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["其它记帐金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

                    curRowX = X8;
                    e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);
                    //					e.Graphics.DrawString("公费记帐",TextFont,Brushes.Black,curRowX,curRowY+RowHight+fontHight);
                    //					tilWith= e.Graphics.MeasureString("公费记帐 ",TextFont);
                    e.Graphics.DrawLine(penLine, curRowX + tilWith.Width, curRowY + RowHight, curRowX + tilWith.Width, curRowY + RowHight);
                    //					curRowX+=40;
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, curRowX, curRowY + fontHight);
                    curRowY += RowHight * 3;
                }

            }
            #region 填充收费类型数据
            if (dtPayType.Rows.Count > 0)
            {
                curRowY += RowHight;
                e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);
                curRowY += 7;
                float tmpWith = LeftWith + 2;
                for (int f2 = 0; f2 < dtPayType.Rows.Count; f2++)
                {
                    if (f2 % 5 == 0 && f2 != 0)
                    {
                        tmpWith = LeftWith + 2;
                        curRowY += RowHight + 5;
                    }
                    tilWith = e.Graphics.MeasureString("打印日期", TextFont);
                    if (dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length > 4)
                    {
                        string star = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0, 4);
                        string end = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
                        e.Graphics.DrawString(star, TextFont, Brushes.Black, tmpWith, curRowY - 5);
                        e.Graphics.DrawString(end + "：", TextFont, Brushes.Black, tmpWith, curRowY + 10);
                        e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                    }
                    else
                    {
                        e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim() + "：", TextFont, Brushes.Black, tmpWith, curRowY);
                        e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                    }
                    tmpWith += 146;
                }
            }
            curRowY += RowHight;
            curRowX = LeftWith;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
            curRowX += 2;
            curRowY += 7;
            e.Graphics.DrawString("统计人：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("统计人： ", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName, TextFont, Brushes.Black, curRowX, curRowY);
            curRowX += 200;
            e.Graphics.DrawString("审核人：", TextFont, Brushes.Black, curRowX, curRowY);
            curRowX += 200;
            e.Graphics.DrawString("出纳：", TextFont, Brushes.Black, curRowX, curRowY);
            curRowY += RowHight - 7;
            e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);

            e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
            e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
            #endregion

            #endregion

        }

        #region 公共变量
        Pen penLine = new Pen(Brushes.Black, 1);
        System.Drawing.Font m_fntTitle = new Font("宋体", 15);//标题使用的字体
        System.Drawing.Font TextFont = new Font("宋体", 11);//文字使用的字体
        System.Drawing.Font TextFontBold = new Font("宋体", 11, System.Drawing.FontStyle.Bold);//文字使用的字体(加粗）
        float curRowY = 0;//当前行的Y坐标
        float curRowX = 0;//当前行的X坐标

        const float RowHight = 25F;//项的高度
        const float LeftWith = 30F;//左右宿进的长度
        const float Uphight = 15F;//上下宿进的长度
        const float fontHight = 7;//字在表格中显示的位置
        SizeF tilWith;
        float SaveStartHight = 0;
        float X1 = 0;
        float X2 = 0;
        float X3 = 0;
        float X4 = 0;
        float X5 = 0;
        float X6 = 0;
        float X7 = 0;
        float X8 = 0;
        /// <summary>
        /// 页号
        /// </summary>
        int totailNuber = 0;
        /// <summary>
        /// 当前行号
        /// </summary>
        int currRow = 0;
        #endregion
        public void printPageLJ(System.Drawing.Printing.PrintPageEventArgs e, string strINTERNALFLAG)
        {
            float PageWidth = e.PageBounds.Width - 2;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高
            if (totailNuber == 0)
            {
                m_mthPrintTitle(e, PageWidth, ref X1, ref X2, ref X3, ref X4, ref X5, ref X6, ref X7, ref X8);
            }
            bool blnFirst = true;
            for (int i1 = currRow; i1 < dtStatistics.Rows.Count; i1++)
            {
                #region alter at 2006-4-25 14:03
                if (curRowY + 38 + RowHight * 2 > PageHight - 20)
                {
                    totailNuber++;
                    e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
                    e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
                    curRowY = SaveStartHight - RowHight;
                    e.HasMorePages = true;
                    return;
                }
                #endregion
                if (blnFirst)
                {
                    curRowY += RowHight;
                    blnFirst = false;
                }
                else
                {
                    curRowY += RowHight / 2F;
                }
                curRowX = LeftWith;

                if (i1 == dtStatistics.Rows.Count - 1)
                {
                    m_mthPrintBabyLJ(e, PageWidth, X1, X2, X3, X4, X5, X6, X7, X8, i1, TextFontBold);
                }
                else
                {
                    m_mthPrintBabyLJ(e, PageWidth, X1, X2, X3, X4, X5, X6, X7, X8, i1, TextFont);
                }
                currRow = i1 + 1;

                #region alter at 2006-4-25 14:03
                //if(curRowY+18+RowHight*2>PageHight-20)
                //{
                //    totailNuber++;
                //    e.Graphics.DrawLine(penLine,LeftWith,SaveStartHight,LeftWith,curRowY);
                //    e.Graphics.DrawLine(penLine,PageWidth-LeftWith,SaveStartHight,PageWidth-LeftWith,curRowY);
                //    curRowY=SaveStartHight-RowHight;
                //    e.HasMorePages=true;
                //    return;
                //}
                #endregion
            }
            if (curRowY + 38 + RowHight * 13 > PageHight - 20)
            {
                totailNuber++;
                e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
                e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
                curRowY = SaveStartHight - RowHight;
                e.HasMorePages = true;
                return;
            }
            m_mthPrintEnd(e, PageWidth);

        }
        public void printPageFS(System.Drawing.Printing.PrintPageEventArgs e, string strINTERNALFLAG)
        {
            float PageWidth = e.PageBounds.Width - 2;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高
            if (totailNuber == 0)
            {
                m_mthPrintTitle(e, PageWidth, ref X1, ref X2, ref X3, ref X4, ref X5, ref X6, ref X7, ref X8);
            }
            bool blnFirst = true;
            for (int i1 = currRow; i1 < dtStatistics.Rows.Count; i1++)
            {
                #region alter at 2006-4-25 14:03
                if (curRowY + 18 + RowHight * 2 > PageHight - 20)
                {
                    totailNuber++;
                    e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
                    e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
                    curRowY = SaveStartHight - RowHight;
                    e.HasMorePages = true;
                    return;
                }
                #endregion
                if (blnFirst)
                {
                    curRowY += RowHight;
                    blnFirst = false;
                }
                else
                {
                    curRowY += RowHight / 2F;
                }
                curRowX = LeftWith;

                if (i1 == dtStatistics.Rows.Count - 1)
                {
                    m_mthPrintBaby(e, PageWidth, X1, X2, X3, X4, X5, X6, X7, X8, i1, TextFontBold);
                }
                else
                {
                    m_mthPrintBaby(e, PageWidth, X1, X2, X3, X4, X5, X6, X7, X8, i1, TextFont);
                }
                currRow = i1 + 1;

                #region alter at 2006-4-25 14:03
                //if(curRowY+18+RowHight*2>PageHight-20)
                //{
                //    totailNuber++;
                //    e.Graphics.DrawLine(penLine,LeftWith,SaveStartHight,LeftWith,curRowY);
                //    e.Graphics.DrawLine(penLine,PageWidth-LeftWith,SaveStartHight,PageWidth-LeftWith,curRowY);
                //    curRowY=SaveStartHight-RowHight;
                //    e.HasMorePages=true;
                //    return;
                //}
                #endregion
            }
            if (curRowY + 18 + RowHight * 13 > PageHight - 20)
            {
                totailNuber++;
                e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
                e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
                curRowY = SaveStartHight - RowHight;
                e.HasMorePages = true;
                return;
            }
            m_mthPrintEnd(e, PageWidth);

        }

        #region 打印头部
        private void m_mthPrintTitle(System.Drawing.Printing.PrintPageEventArgs e, float PageWidth, ref float X1, ref float X2, ref float X3, ref float X4, ref float X5, ref float X6, ref float X7, ref float X8)
        {
            curRowY = RowHight + Uphight + 10;
            curRowX = LeftWith;
            SizeF tilWith = e.Graphics.MeasureString(HospitalTitle + "收费处日结报表", m_fntTitle);
            e.Graphics.DrawString(HospitalTitle + "收费处日结报表", m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);
            e.Graphics.DrawString("结帐日期：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("结帐日期：", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(this.m_objViewer.m_CheckOuDate.Value.ToString("yyyy年MM月dd日") + "~" + this.m_objViewer.m_CheckOuDate2.Value.ToString("yyyy年MM月dd日"), TextFont, Brushes.Black, curRowX, curRowY);
            if (this.m_objViewer.strDeptFlag == "1")
            {
                tilWith = e.Graphics.MeasureString("统计科室:" + this.m_objViewer.m_cboCheckMan.SelectItemText, TextFont);
                e.Graphics.DrawString("统计科室:" + this.m_objViewer.m_cboCheckMan.SelectItemText, TextFont, Brushes.Black, (e.PageBounds.Width - tilWith.Width) / 2, curRowY);
            }
            e.Graphics.DrawString("打印日期：", TextFont, Brushes.Black, PageWidth - 250, curRowY);
            tilWith = e.Graphics.MeasureString("打印日期：", TextFont);
            string NowDate = DateTime.Now.ToString("yyyy年MM月dd日");
            e.Graphics.DrawString(NowDate, TextFont, Brushes.Black, PageWidth - 250 + tilWith.Width, curRowY);

            curRowX = LeftWith;
            curRowY += 18;

            SaveStartHight = curRowY;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
            e.Graphics.DrawString("缴 款 人", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString("，，，，，", TextFont);
            curRowX += tilWith.Width;
            X1 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);
            curRowX += 2;
            e.Graphics.DrawString("开  票  数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString("开  票  数", TextFont);
            curRowX += 2 + tilWith.Width;
            X2 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

            e.Graphics.DrawString("  开 票 金 额  ", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString("  开 票 金   额  ", TextFont);
            curRowX += 2 + tilWith.Width;
            X3 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

            e.Graphics.DrawString("退票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString("退票数", TextFont);
            curRowX += 2 + tilWith.Width;
            X4 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);


            e.Graphics.DrawString(" 退票金额 ", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString(" 退票金额 ", TextFont);
            curRowX += 2 + tilWith.Width;
            X5 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

            e.Graphics.DrawString("恢复票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString("恢复票数", TextFont);
            curRowX += 2 + tilWith.Width;
            X6 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

            e.Graphics.DrawString(" 恢复金额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString(" 恢复金额", TextFont);
            curRowX += 15 + tilWith.Width;
            X7 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

            e.Graphics.DrawString("有效票数", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString("有效票数", TextFont);
            curRowX += 2 + tilWith.Width;
            X8 = curRowX;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight);

            e.Graphics.DrawString(" 实 收 金 额", TextFont, Brushes.Black, curRowX, curRowY + fontHight);
            tilWith = e.Graphics.MeasureString(" 实 收 金 额", TextFont);
        }
        #endregion
        #region 打印LJ内容
        private void m_mthPrintBabyLJ(System.Drawing.Printing.PrintPageEventArgs e, float PageWidth, float X1, float X2, float X3, float X4, float X5, float X6, float X7, float X8, int i1, System.Drawing.Font font)
        {
            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight, PageWidth - LeftWith, curRowY + RowHight);
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 2, PageWidth - LeftWith, curRowY + RowHight * 2);
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 3, PageWidth - LeftWith, curRowY + RowHight * 3);
            e.Graphics.DrawString(dtStatistics.Rows[i1]["缴款人"].ToString().Trim(), font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("实收现金", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("公费记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            curRowX = X1;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);
            curRowX += 2;
            if (dtStatistics.Rows[i1]["开票数"].ToString().Trim() != "0")
            {
                e.Graphics.DrawString(dtStatistics.Rows[i1]["开票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (dtStatistics.Rows[i1]["实收现金"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收现金"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["公费记账"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["公费记账"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            }

            curRowX = X2;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["开票金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("IC卡", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("特困", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            if (dtStatistics.Rows[i1]["IC卡金额合计"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["IC卡金额合计"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["特困记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["特困记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight * 2 + fontHight);
            }

            e.Graphics.DrawLine(penLine, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight * 3);

            curRowX = X3;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["退票数"].ToString().Trim() != "0")
                e.Graphics.DrawString(dtStatistics.Rows[i1]["退票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("银行卡", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("离  休", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            curRowX = X4;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["退票金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + "-" + Math.Abs(Convert.ToDouble(dtStatistics.Rows[i1]["退票金额"].ToString())).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (dtStatistics.Rows[i1]["刷卡金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["刷卡金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["离休记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["离休记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            }
   
            curRowX = X5;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() != "0")
                e.Graphics.DrawString(dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("支票支付", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("本院记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

            curRowX = X6;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["恢复金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["恢复金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (dtStatistics.Rows[i1]["支票金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["支票金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["本院记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["本院记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            }
            curRowX = X7;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["有效票数"].ToString().Trim() != "0")
                e.Graphics.DrawString(dtStatistics.Rows[i1]["有效票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);

            e.Graphics.DrawString("其它记帐", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);

            e.Graphics.DrawString("医保记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

            curRowX = X8;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            e.Graphics.DrawLine(penLine, curRowX + tilWith.Width, curRowY + RowHight, curRowX + tilWith.Width, curRowY + RowHight);

            if (dtStatistics.Rows[i1]["实收金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (i1 == dtStatistics.Rows.Count - 1)
            {
                if (dtStatistics.Rows[i1]["其它记帐金额"].ToString() != "0")
                {
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["其它记帐金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                }
            }
            else
            {
                if (dtStatistics.Rows[i1]["其它金额合计"].ToString() != "0")
                {
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["其它金额合计"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                }
            }
            double hj = Convert.ToDouble(dtStatistics.Rows[i1]["医保记账"].ToString());
            if (hj.ToString() != "0")
            {
                e.Graphics.DrawString("￥" + hj.ToString("0.00"), font, Brushes.Black, curRowX, curRowY + 2 * RowHight + fontHight);
            }
            curRowX = LeftWith;
            e.Graphics.DrawString("合作记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
            curRowX = X1;
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 3, curRowX, curRowY + RowHight * 4);
            e.Graphics.DrawLine(penLine, LeftWith, curRowY + RowHight * 4, PageWidth - LeftWith, curRowY + RowHight * 4);
            curRowX += 2;
            if (dtStatistics.Rows[i1]["门诊合作医疗记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["门诊合作医疗记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 3 + fontHight);
            }
            curRowY += RowHight * 4;
        }
        #endregion
        #region 打印内容
        private void m_mthPrintBaby(System.Drawing.Printing.PrintPageEventArgs e, float PageWidth, float X1, float X2, float X3, float X4, float X5, float X6, float X7, float X8, int i1, System.Drawing.Font font)
        {
            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight, PageWidth - LeftWith, curRowY + RowHight);
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 2, PageWidth - LeftWith, curRowY + RowHight * 2);
            e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 3, PageWidth - LeftWith, curRowY + RowHight * 3);
            e.Graphics.DrawString(dtStatistics.Rows[i1]["缴款人"].ToString().Trim(), font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("实收现金", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            //					e.Graphics.DrawString("公费记帐",font,Brushes.Black,curRowX,curRowY+RowHight*2+fontHight);
            e.Graphics.DrawString("公费记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            curRowX = X1;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["开票数"].ToString().Trim() != "0")
            {
                e.Graphics.DrawString(dtStatistics.Rows[i1]["开票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (dtStatistics.Rows[i1]["实收现金"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收现金"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["公费记账"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["公费记账"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            }

            curRowX = X2;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["开票金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("IC卡", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("特困", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            if (dtStatistics.Rows[i1]["IC卡金额合计"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["IC卡金额合计"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["特困记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["特困记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight * 2 + fontHight);
            }

            e.Graphics.DrawLine(penLine, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight, curRowX + e.Graphics.MeasureString("特困", font).Width, curRowY + RowHight * 3);

            curRowX = X3;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["退票数"].ToString().Trim() != "0")
                e.Graphics.DrawString(dtStatistics.Rows[i1]["退票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("银行卡", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("离  休", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            curRowX = X4;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["退票金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + "-" + Math.Abs(Convert.ToDouble(dtStatistics.Rows[i1]["退票金额"].ToString())).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (dtStatistics.Rows[i1]["刷卡金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["刷卡金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["离休记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["离休记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            }
            //					e.Graphics.DrawString("支票金额",font,Brushes.Black,curRowX,curRowY+RowHight+fontHight);
            curRowX = X5;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() != "0")
                e.Graphics.DrawString(dtStatistics.Rows[i1]["恢复票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            e.Graphics.DrawString("支票支付", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            e.Graphics.DrawString("本院记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

            curRowX = X6;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["恢复金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["恢复金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (dtStatistics.Rows[i1]["支票金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["支票金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            }
            if (dtStatistics.Rows[i1]["本院记帐"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["本院记帐"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);
            }
            curRowX = X7;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);

            curRowX += 2;
            if (dtStatistics.Rows[i1]["有效票数"].ToString().Trim() != "0")
                e.Graphics.DrawString(dtStatistics.Rows[i1]["有效票数"].ToString().Trim() + "张", font, Brushes.Black, curRowX, curRowY + fontHight);
            //佛二：其它支付->其它记帐
            e.Graphics.DrawString("其它记帐", font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
            //e.Graphics.DrawString("其它支付",font,Brushes.Black,curRowX,curRowY+RowHight+fontHight);

           // System.Drawing.Font ybfont = new Font("宋体", 9, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString("医保记帐", font, Brushes.Black, curRowX, curRowY + RowHight * 2 + fontHight);

            curRowX = X8;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, curRowX, curRowY + RowHight * 3);
            //					e.Graphics.DrawString("公费记帐",font,Brushes.Black,curRowX,curRowY+RowHight+fontHight);
            //					tilWith= e.Graphics.MeasureString("公费记帐 ",font);
            e.Graphics.DrawLine(penLine, curRowX + tilWith.Width, curRowY + RowHight, curRowX + tilWith.Width, curRowY + RowHight);
            //					curRowX+=40;
            if (dtStatistics.Rows[i1]["实收金额"].ToString() != "0")
            {
                e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["实收金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + fontHight);
            }
            if (i1 == dtStatistics.Rows.Count-1)
            {
                if (dtStatistics.Rows[i1]["其它记帐金额"].ToString() != "0")
                {
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["其它记帐金额"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                }
            }
            else
            {
                if (dtStatistics.Rows[i1]["其它金额合计"].ToString() != "0")
                {
                    e.Graphics.DrawString("￥" + Convert.ToDouble(dtStatistics.Rows[i1]["其它金额合计"].ToString()).ToString("0.00"), font, Brushes.Black, curRowX, curRowY + RowHight + fontHight);
                }
            }

            ////佛二将医保记账打印到其他记帐
            //double hj = Convert.ToDouble(dtStatistics.Rows[i1]["其它记帐金额"].ToString()) + Convert.ToDouble(dtStatistics.Rows[i1]["医保记账"].ToString());
            //佛二将其他记帐改为医保记账(特病医保)
            double hj = Convert.ToDouble(dtStatistics.Rows[i1]["医保记账"].ToString());
            if (hj.ToString() != "0")
            {
                e.Graphics.DrawString("￥" + hj.ToString("0.00"), font, Brushes.Black, curRowX, curRowY + 2 * RowHight + fontHight);
            }
            curRowY += RowHight * 3;
        }
        #endregion

        #region 打印收费类型数据
        private void m_mthPrintEnd(System.Drawing.Printing.PrintPageEventArgs e, float PageWidth)
        {
            if (dtPayType.Rows.Count > 0)
            {
                curRowY += RowHight;
                e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);
                curRowY += 7;
                float tmpWith = LeftWith + 2;
                for (int f2 = 0; f2 < dtPayType.Rows.Count; f2++)
                {
                    if (f2 % 5 == 0 && f2 != 0)
                    {
                        tmpWith = LeftWith + 2;
                        curRowY += RowHight + 5;
                    }
                    tilWith = e.Graphics.MeasureString("打印日期", TextFont);
                    if (dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length > 4)
                    {
                        string star = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0, 4);
                        string end = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
                        e.Graphics.DrawString(star, TextFont, Brushes.Black, tmpWith, curRowY - 5);
                        e.Graphics.DrawString(end + "：", TextFont, Brushes.Black, tmpWith, curRowY + 10);
                        if (dtPayType.Rows[f2]["tolMoney"].ToString() != "0.00")
                            e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                    }
                    else
                    {
                        e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim() + "：", TextFont, Brushes.Black, tmpWith, curRowY);
                        if (dtPayType.Rows[f2]["tolMoney"].ToString() != "0.00")
                            e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                    }
                    tmpWith += 146;
                }
            }
            curRowY += RowHight;
            curRowX = LeftWith;
            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - LeftWith, curRowY);
            curRowX += 2;
            curRowY += 7;
            e.Graphics.DrawString("统计人：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("统计人： ", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName, TextFont, Brushes.Black, curRowX, curRowY);
            curRowX += 200;
            e.Graphics.DrawString("审核人：", TextFont, Brushes.Black, curRowX, curRowY);
            curRowX += 200;
            e.Graphics.DrawString("出纳：", TextFont, Brushes.Black, curRowX, curRowY);
            curRowY += RowHight - 7;
            e.Graphics.DrawLine(penLine, LeftWith, curRowY, PageWidth - LeftWith, curRowY);

            e.Graphics.DrawLine(penLine, LeftWith, SaveStartHight, LeftWith, curRowY);
            e.Graphics.DrawLine(penLine, PageWidth - LeftWith, SaveStartHight, PageWidth - LeftWith, curRowY);
        }

        #endregion
    }
}
