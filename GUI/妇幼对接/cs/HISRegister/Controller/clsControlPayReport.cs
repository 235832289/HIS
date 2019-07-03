using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsControlPayReport : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlPayReport()
        {
            Domain = new clsDomainControl_Register();
            dtCheckOut = new DataTable();
            dtPayType = new DataTable();
            dtStatistics = new DataTable();
        }
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmPayReport m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPayReport)frmMDI_Child_Base_in;
        }
        #endregion
        
        public void m_mthBeiginPrint()
        {
            m_strHospital = this.m_objComInfo.m_strGetHospitalTitle();
            string m_strCheckManID = this.m_objViewer.LoginInfo.m_strEmpID;
            string m_strBeginDate = this.m_objViewer.BeginDate.Value.ToShortDateString();
            string m_strEndDate = this.m_objViewer.EndDate.Value.ToShortDateString();
            Domain.m_lngGetCheckOutHistoryData(m_strBeginDate,m_strEndDate, m_strCheckManID, out dtPayType, out dtCheckOut);
            arrList = new ArrayList();
            DataTable dt = new DataTable();
            dt.Columns.Add("OPREMP_CHR");
            dt.Columns.Add("STATUS_INT");
            dt.Columns.Add("invoiceno_vchr");
            for (int k1 = 0; k1 < dtCheckOut.Rows.Count; k1++)
            {
                DataRow newRow = dt.NewRow();
                newRow["OPREMP_CHR"] = dtCheckOut.Rows[k1]["OPREMP_CHR"];
                newRow["STATUS_INT"] = dtCheckOut.Rows[k1]["STATUS_INT"];
                newRow["invoiceno_vchr"] = dtCheckOut.Rows[k1]["invoiceno_vchr"];
                dt.Rows.Add(newRow);
            }
            for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            {
                if (dt.Rows[i1]["STATUS_INT"].ToString() == "2" || dt.Rows[i1]["STATUS_INT"].ToString() == "3")
                {
                    dt.Rows[i1].Delete();
                    i1--;
                    dt.AcceptChanges();
                }
            }
            dt.AcceptChanges();
            clsMain.m_Detach(dt, "INVOICENO_VCHR", out arrList);
            this.m_mthGetRecord(dtCheckOut, arrList, out objList);
            #region 生成一个统计表
            dtStatistics = new DataTable();
            dtStatistics.Columns.Add("开票数");
            dtStatistics.Columns.Add("开票金额");
            dtStatistics.Columns.Add("退票数");
            dtStatistics.Columns.Add("退票金额合计");
            dtStatistics.Columns.Add("恢复票数");
            dtStatistics.Columns.Add("恢复金额合计");
            dtStatistics.Columns.Add("有效票数");
            dtStatistics.Columns.Add("实收金额合计");
            dtStatistics.Columns.Add("实收现金合计");
            dtStatistics.Columns.Add("刷卡金额合计");
            dtStatistics.Columns.Add("支票金额合计");
            dtStatistics.Columns.Add("医保记账金额");
            dtStatistics.Columns.Add("公费记账金额");
            dtStatistics.Columns.Add("自费上缴金额");
          
            dtStatistics.Columns.Add("现金人次");
            dtStatistics.Columns.Add("IC卡人次");
            dtStatistics.Columns.Add("银行卡人次");
            dtStatistics.Columns.Add("支票人次");
            dtStatistics.Columns.Add("其他记帐人次");
            dtStatistics.Columns.Add("公费人次");
            dtStatistics.Columns.Add("特困人次");
            dtStatistics.Columns.Add("离休人次");
            dtStatistics.Columns.Add("本院人次");
            dtStatistics.Columns.Add("医保人次");

            dtStatistics.Columns.Add("自费及其它人次");
            dtStatistics.Columns.Add("自费人次");
            dtStatistics.Columns.Add("其它记帐金额");
            dtStatistics.Columns.Add("开始发票号");
            dtStatistics.Columns.Add("结束发票号");
            dtStatistics.Columns.Add("第一张发票时间");
            dtStatistics.Columns.Add("最后一张发票时间");

            dtStatistics.Columns.Add("其它金额合计");
            dtStatistics.Columns.Add("IC卡金额合计");
            dtStatistics.Columns.Add("特困记帐");
            dtStatistics.Columns.Add("离休记帐");
            dtStatistics.Columns.Add("本院记帐");
            dtStatistics.Columns.Add("其它记帐");
            #endregion

            #region 统计各种收费类型的金额
            dtPayType.Columns.Add("tolMoney");
            if (dtCheckOut.Rows.Count >= 0)
            {
                for (int i1 = 0; i1 < dtPayType.Rows.Count; i1++)
                {
                    Double tolMoney = 0;
                    for (int f2 = 0; f2 < dtCheckOut.Rows.Count; f2++)
                    {
                        if (dtCheckOut.Rows[f2]["ITEMCATID_CHR"].ToString().Trim() == dtPayType.Rows[i1]["TYPEID_CHR"].ToString().Trim())
                        {
                            tolMoney += Convert.ToDouble(dtCheckOut.Rows[f2]["TOLFEE_MNY"].ToString().Trim());
                        }
                    }
                    dtPayType.Rows[i1]["tolMoney"] = tolMoney.ToString("0.00");
                }
            }
            #endregion

            #region 统计数据
            StatisticsRow = dtStatistics.NewRow();
            StatisticsRow["开票数"] = 0;
            StatisticsRow["开票金额"] = 0.00;
            StatisticsRow["退票数"] = 0;
            StatisticsRow["退票金额合计"] = 0.00;
            StatisticsRow["恢复票数"] = 0;
            StatisticsRow["恢复金额合计"] = 0.00;

            StatisticsRow["实收现金合计"] = 0.00;
            StatisticsRow["刷卡金额合计"] = 0.00;

            StatisticsRow["支票金额合计"] = 0.00;
            StatisticsRow["医保记账金额"] = 0.00;
            StatisticsRow["公费记账金额"] = 0.00;
            StatisticsRow["自费上缴金额"] = 0.00;

            StatisticsRow["实收金额合计"] = 0.00;
            StatisticsRow["其它记帐金额"] = 0.00;

            StatisticsRow["现金人次"] = 0;
            StatisticsRow["IC卡人次"] = 0;
            StatisticsRow["银行卡人次"] = 0;
            StatisticsRow["支票人次"] = 0;
            StatisticsRow["其他记帐人次"] = 0;
            StatisticsRow["公费人次"] = 0;
            StatisticsRow["特困人次"] = 0;
            StatisticsRow["离休人次"] = 0;
            StatisticsRow["本院人次"] = 0;
            StatisticsRow["医保人次"] = 0;

            StatisticsRow["自费及其它人次"] = 0;
            StatisticsRow["自费人次"] = 0;
            StatisticsRow["其它金额合计"] = 0;
            StatisticsRow["IC卡金额合计"] = 0;
            StatisticsRow["特困记帐"] = 0;
            StatisticsRow["离休记帐"] = 0;
            StatisticsRow["本院记帐"] = 0;
            StatisticsRow["其它记帐"] = 0;
            StatisticsRow["第一张发票时间"] = "";
            StatisticsRow["最后一张发票时间"] = "";
            DateTime startDateTime = new DateTime();
            DateTime endDateTime = new DateTime();
            if (dtCheckOut.Rows.Count > 0)
            {
                StatisticsRow["开始发票号"] = dtCheckOut.Rows[0]["INVOICENO_VCHR"].ToString();
                StatisticsRow["结束发票号"] = dtCheckOut.Rows[dtCheckOut.Rows.Count - 1]["INVOICENO_VCHR"].ToString();
                for (int i1 = 0; i1 < dtCheckOut.Rows.Count; i1++)
                {
                    //计算发票的第一张和最后一张
                    if (i1 == 0)
                    {
                        StatisticsRow["第一张发票时间"] = Convert.ToDateTime(dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString());
                        StatisticsRow["最后一张发票时间"] = Convert.ToDateTime(dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString());
                    }
                    else
                    {
                        if (Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString()) < Convert.ToDateTime(StatisticsRow["第一张发票时间"].ToString()))
                        {
                            StatisticsRow["第一张发票时间"] = Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString());
                        }
                        if (Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString()) > Convert.ToDateTime(StatisticsRow["最后一张发票时间"].ToString()))
                        {
                            StatisticsRow["最后一张发票时间"] = Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString());
                        }
                    }

                    //-----------------------

                    //统计开票数,开票金额

                    if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "1")//统计开票数,开票金额
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                            StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["开票数"] = Convert.ToInt32(StatisticsRow["开票数"].ToString()) + 1;
                                StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            }
                        }

                    }

                    //-------------------------


                    //退票数,退票金额合计,所有的退票号
                    if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")//退票数,退票金额合计,所有的退票号
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                            StatisticsRow["退票金额合计"] = Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                           // SaveINVOICENO.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                                StatisticsRow["退票金额合计"] = Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                               // SaveINVOICENO.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
                            }

                        }

                    }

                    //--------------------------

                    //恢复票数,恢复金额合计
                    if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "3")//恢复票数,恢复金额合计
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                            StatisticsRow["恢复金额合计"] = Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["恢复票数"] = Convert.ToInt32(StatisticsRow["恢复票数"].ToString()) + 1;
                                StatisticsRow["恢复金额合计"] = Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                
                            }
                        }
                    }

                    //----------------------



                    //统计现金合计

                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "0")//统计现金合计
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["现金人次"] = Convert.ToInt32(StatisticsRow["现金人次"].ToString()) - 1;
                                StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["现金人次"] = Convert.ToInt32(StatisticsRow["现金人次"].ToString()) + 1;
                                StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["现金人次"] = Convert.ToInt32(StatisticsRow["现金人次"].ToString()) - 1;
                                    StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["现金人次"] = Convert.ToInt32(StatisticsRow["现金人次"].ToString()) + 1;
                                    StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                            }
                        }

                    }

                    //-----------------------


                    //刷卡合计
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "1")//刷卡合计
                    {
                        if (i1 == 0)
                        {

                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["银行卡人次"] = Convert.ToInt32(StatisticsRow["银行卡人次"].ToString()) - 1;
                                StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["银行卡人次"] = Convert.ToInt32(StatisticsRow["银行卡人次"].ToString()) + 1;
                                StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["银行卡人次"] = Convert.ToInt32(StatisticsRow["银行卡人次"].ToString()) - 1;
                                    StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["银行卡人次"] = Convert.ToInt32(StatisticsRow["银行卡人次"].ToString()) + 1;
                                    StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                            }
                        }

                    }

                    //---------------


                    //支票
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "2")//支票
                    {
                        if (i1 == 0)
                        {

                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["支票人次"] = Convert.ToInt32(StatisticsRow["支票人次"].ToString()) - 1;
                                StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["支票人次"] = Convert.ToInt32(StatisticsRow["支票人次"].ToString()) + 1;
                                StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                 
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {

                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["支票人次"] = Convert.ToInt32(StatisticsRow["支票人次"].ToString()) - 1;
                                    StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["支票人次"] = Convert.ToInt32(StatisticsRow["支票人次"].ToString()) + 1;
                                    StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }

                            }
                        }

                    }
                    //------------------

                    //医保记账金额及人次

                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "2")//医保记账金额及人次
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) - 1;
                                StatisticsRow["医保记账金额"] = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) + 1;
                                StatisticsRow["医保记账金额"] = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) - 1;
                                    StatisticsRow["医保记账金额"] = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["医保人次"] = Convert.ToInt32(StatisticsRow["医保人次"].ToString()) + 1;
                                    StatisticsRow["医保记账金额"] = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }
                    //-------------

                    //其它记帐金额及人次
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "0" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "1" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "2" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "3" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "4" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "5")
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["其他记帐人次"] = Convert.ToInt32(StatisticsRow["其他记帐人次"].ToString()) - 1;
                                StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["其他记帐人次"] = Convert.ToInt32(StatisticsRow["其他记帐人次"].ToString()) + 1;
                                StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["其他记帐人次"] = Convert.ToInt32(StatisticsRow["其他记帐人次"].ToString()) - 1;
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["其他记帐人次"] = Convert.ToInt32(StatisticsRow["其他记帐人次"].ToString()) + 1;
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }

                    //公费记账金额及人次
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "1")//公费记账金额及人次
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) - 1;
                                StatisticsRow["公费记账金额"] = Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) + 1;
                                StatisticsRow["公费记账金额"] = Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) - 1;
                                    StatisticsRow["公费记账金额"] = Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["公费人次"] = Convert.ToInt32(StatisticsRow["公费人次"].ToString()) + 1;
                                    StatisticsRow["公费记账金额"] = Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }

                    //-------------------

                    //自费上缴金额及人次
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "0")//自费上缴金额及人次
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) - 1;
                                StatisticsRow["自费上缴金额"] = Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) + 1;
                                StatisticsRow["自费上缴金额"] = Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                            }
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) - 1;
                                    StatisticsRow["自费上缴金额"] = Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["自费人次"] = Convert.ToInt32(StatisticsRow["自费人次"].ToString()) + 1;
                                    StatisticsRow["自费上缴金额"] = Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                            }
                        }

                    }
                    #region 特困记账金额
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "3")
                    {
                        if (i1 == 0)
                        {


                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["特困人次"] = Convert.ToInt32(StatisticsRow["特困人次"].ToString()) - 1;
                                StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["特困人次"] = Convert.ToInt32(StatisticsRow["特困人次"].ToString()) + 1;
                                StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {

                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["特困人次"] = Convert.ToInt32(StatisticsRow["特困人次"].ToString()) - 1;
                                    StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["特困人次"] = Convert.ToInt32(StatisticsRow["特困人次"].ToString()) + 1;
                                    StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }

                    #endregion

                    #region 离休记账金额
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "4")
                    {
                        if (i1 == 0)
                        {

                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["离休人次"] = Convert.ToInt32(StatisticsRow["离休人次"].ToString()) - 1;
                                StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["离休人次"] = Convert.ToInt32(StatisticsRow["离休人次"].ToString()) + 1;
                                StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {


                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["离休人次"] = Convert.ToInt32(StatisticsRow["离休人次"].ToString()) - 1;
                                    StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["离休人次"] = Convert.ToInt32(StatisticsRow["离休人次"].ToString()) + 1;
                                    StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }

                    #endregion

                    #region 本院记账金额
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "5")
                    {
                        if (i1 == 0)
                        {

                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["本院人次"] = Convert.ToInt32(StatisticsRow["本院人次"].ToString()) - 1;
                                StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["本院人次"] = Convert.ToInt32(StatisticsRow["本院人次"].ToString()) + 1;
                                StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {

                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["本院人次"] = Convert.ToInt32(StatisticsRow["本院人次"].ToString()) - 1;
                                    StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["本院人次"] = Convert.ToInt32(StatisticsRow["本院人次"].ToString()) + 1;
                                    StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }

                    #endregion

                    #region IC卡支付

                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "3")
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {
                                StatisticsRow["IC卡人次"] = Convert.ToInt32(StatisticsRow["IC卡人次"].ToString()) - 1;
                                StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                            else
                            {
                                StatisticsRow["IC卡人次"] = Convert.ToInt32(StatisticsRow["IC卡人次"].ToString()) + 1;
                                StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["IC卡人次"] = Convert.ToInt32(StatisticsRow["IC卡人次"].ToString()) - 1;
                                    StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["IC卡人次"] = Convert.ToInt32(StatisticsRow["IC卡人次"].ToString()) + 1;
                                    StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                }
                            }
                        }

                    }

                    #endregion

                    #region 其它金额合计

                    ////茶山：其它支付－>其它记帐
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "0")
                    {
                        if (i1 == 0)
                        {

                            StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }

            

                    #endregion
                }
            }

            //---------------------

            //计算有效票数
            int intAvailability = Convert.ToInt32(StatisticsRow["开票数"].ToString().Trim()) - Convert.ToInt32(StatisticsRow["退票数"].ToString().Trim()) + Convert.ToInt32(StatisticsRow["恢复票数"].ToString().Trim());

            //计算有效金额
            Double AvailabilityMoney = Convert.ToDouble(StatisticsRow["开票金额"].ToString().Trim()) - Convert.ToDouble(StatisticsRow["退票金额合计"].ToString().Trim()) + Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString().Trim());

            StatisticsRow["有效票数"] = intAvailability.ToString();
            StatisticsRow["实收金额合计"] = AvailabilityMoney.ToString();
            #endregion
        }
        #region 表格变量
        float m_fltY1;
        float m_fltY2;
        float m_fltY3;
        float m_fltY4;
        float m_fltY5;
        float m_fltY6;
        float m_fltX1;
        float m_fltX2;
        float m_fltX3;
        float m_fltX4;
        float m_fltX5;
        float m_fltX6;
        float m_fltX7;
        float m_fltX8;
        float m_fltX9;
        float m_fltX10;
        float m_fltX11;
        float m_fltX12;
        float m_fltX13;
        float m_fltX14;
        #endregion
        #region 变量
        private List<clsInvoice_Vo> objList;
        private ArrayList arrList;
        clsDomainControl_Register Domain;
        DataTable dtCheckOut;
        DataTable dtPayType;
        DataTable dtStatistics;
        string m_strHospital;
        private DataRow StatisticsRow;
        float PageWidth;//获得页面的宽度
        float PageHight;//获得页面的高度
        float curRowY = 0;//当前行的Y坐标
        float curRowX = 0;//当前行的X坐标
        System.Drawing.Font m_fntTitle = new Font("宋体", 16, FontStyle.Bold);//标题使用的字体
        System.Drawing.Font TextFont = new Font("宋体", 10);//文字使用的字体
        const float RowHight = 23F;//项的高度
        const float LeftWith = 25F;//左宿进的长度
        const float RightWith = 40F;//右宿进的长度
        #endregion
        public void m_mthPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            curRowX = LeftWith;
            curRowY = 0;
            PageWidth = e.PageBounds.Width;
            PageHight = e.PageBounds.Height;
            m_fltX1 = curRowX;
            m_fltX2=PageWidth*0.13f;
            m_fltX3=PageWidth*0.20f;
            m_fltX4=PageWidth*0.27f;
            m_fltX5=PageWidth*0.34f;
            m_fltX6=PageWidth*0.41f;
            m_fltX7=PageWidth*0.48f;
            m_fltX8=PageWidth*0.55f;
            m_fltX9=PageWidth*0.62f;
            m_fltX10=PageWidth*0.69f;
            m_fltX11=PageWidth*0.76f;
            m_fltX12=PageWidth*0.83f;
            m_fltX13=PageWidth*0.90f;
            m_fltX14 = PageWidth - RightWith;
            curRowY += 35;
            string m_strTitle = m_strHospital + "门诊" + this.m_objViewer.BeginDate.Value.ToString("yyyy年MM月dd")+"～" + this.m_objViewer.EndDate.Value.ToString("yyyy年MM月dd") + "缴款报表";
            SizeF tilWith = e.Graphics.MeasureString(m_strTitle, m_fntTitle);
            e.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, curRowY);
            curRowY += 40;
            m_fltY1 = curRowY;
            e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
            curRowY +=5;
            e.Graphics.DrawString("发票起止号码", TextFont, Brushes.Black, m_fltX1 + 5, curRowY);
            e.Graphics.DrawString("张数", TextFont, Brushes.Black, m_fltX2 + 5, curRowY);
            e.Graphics.DrawString("收入合计", TextFont, Brushes.Black, m_fltX3 + 5, curRowY);
            e.Graphics.DrawString("现金", TextFont, Brushes.Black, m_fltX4 + 5, curRowY);
            e.Graphics.DrawString("IC卡", TextFont, Brushes.Black, m_fltX5 + 5, curRowY);
            e.Graphics.DrawString("银行卡", TextFont, Brushes.Black, m_fltX6 + 5, curRowY);
            e.Graphics.DrawString("支票", TextFont, Brushes.Black, m_fltX7 + 5, curRowY);
            e.Graphics.DrawString("特定医保", TextFont, Brushes.Black, m_fltX8 + 5, curRowY);
            e.Graphics.DrawString("公费记帐", TextFont, Brushes.Black, m_fltX9 + 5, curRowY);
            e.Graphics.DrawString("特困", TextFont, Brushes.Black, m_fltX10 + 5, curRowY);
            e.Graphics.DrawString("离休", TextFont, Brushes.Black, m_fltX11 + 5, curRowY);
            e.Graphics.DrawString("本院", TextFont, Brushes.Black, m_fltX12 + 5, curRowY);
            e.Graphics.DrawString("其他记帐", TextFont, Brushes.Black, m_fltX13 + 5, curRowY);
            curRowY += 15;
            e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
            m_fltY2 = curRowY;
            curRowY += RowHight;
            #region 合计变量
            int m_intInvoiceCount=0;
            double m_dblTotalMoney = 0;
            double m_dblCash = 0;
            double m_dblICCar = 0;
            double m_dblBankCar = 0;
            double m_dblCheque = 0;
            double m_dblOtherJZ = 0;
            double m_dblGFJZ = 0;
            double m_dblTK = 0;
            double m_dblLX = 0;
            double m_dblBY = 0;
            double m_dblTDYB = 0;
            #endregion
            for (int k = 0; k < objList.Count; k++)
            {
                if (objList[k].m_strEndInvoiceNo != string.Empty)
                {
                    e.Graphics.DrawString(objList[k].m_strFirstInvoiceNo + " -> " + objList[k].m_strEndInvoiceNo, TextFont, Brushes.Black, m_fltX1 + 5, curRowY-15);
                }
                else
                {
                    e.Graphics.DrawString(objList[k].m_strFirstInvoiceNo, TextFont, Brushes.Black, m_fltX1 + 5, curRowY - 15);
                }
                e.Graphics.DrawString(objList[k].m_intInvoiceCount + " 张", TextFont, Brushes.Black, m_fltX2 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblTotalMoney.ToString("0.00"), TextFont, Brushes.Black, m_fltX3 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblCash.ToString("0.00"), TextFont, Brushes.Black, m_fltX4 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblICCar.ToString("0.00"), TextFont, Brushes.Black, m_fltX5 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblBankCar.ToString("0.00"), TextFont, Brushes.Black, m_fltX6 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblCheque.ToString("0.00"), TextFont, Brushes.Black, m_fltX7 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblTDYB.ToString("0.00"), TextFont, Brushes.Black, m_fltX8 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblGFJZ.ToString("0.00"), TextFont, Brushes.Black, m_fltX9 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblTK.ToString("0.00"), TextFont, Brushes.Black, m_fltX10 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblLX.ToString("0.00"), TextFont, Brushes.Black, m_fltX11 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblBY.ToString("0.00"), TextFont, Brushes.Black, m_fltX12 + 5, curRowY - 15);
                e.Graphics.DrawString("￥" + objList[k].m_dblOtherJZ.ToString("0.00"), TextFont, Brushes.Black, m_fltX13 + 5, curRowY - 15);
                if (k != objList.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
                    curRowY += RowHight;
                }
                m_intInvoiceCount += objList[k].m_intInvoiceCount;
                m_dblTotalMoney += objList[k].m_dblTotalMoney;
                m_dblCash += objList[k].m_dblCash;
                m_dblICCar += objList[k].m_dblICCar;
                m_dblBankCar += objList[k].m_dblBankCar;
                m_dblCheque += objList[k].m_dblCheque;
                m_dblOtherJZ += objList[k].m_dblOtherJZ;
                m_dblGFJZ += objList[k].m_dblGFJZ;
                m_dblTK += objList[k].m_dblTK;
                m_dblLX += objList[k].m_dblLX;
                m_dblBY += objList[k].m_dblBY;
                m_dblTDYB += objList[k].m_dblTDYB;

            }
            m_fltY3 = curRowY;
            e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
            curRowY += 5;
            e.Graphics.DrawString("总计:", TextFont, Brushes.Black, m_fltX1 + 5, curRowY);
            e.Graphics.DrawString(m_intInvoiceCount.ToString()+" 张", TextFont, Brushes.Black, m_fltX2 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblTotalMoney.ToString("0.00"), TextFont, Brushes.Black, m_fltX3 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblCash.ToString("0.00"), TextFont, Brushes.Black, m_fltX4 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblICCar.ToString("0.00"), TextFont, Brushes.Black, m_fltX5 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblBankCar.ToString("0.00"), TextFont, Brushes.Black, m_fltX6 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblCheque.ToString("0.00"), TextFont, Brushes.Black, m_fltX7 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblTDYB.ToString("0.00"), TextFont, Brushes.Black, m_fltX8 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblGFJZ.ToString("0.00"), TextFont, Brushes.Black, m_fltX9 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblTK.ToString("0.00"), TextFont, Brushes.Black, m_fltX10 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblLX.ToString("0.00"), TextFont, Brushes.Black, m_fltX11 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblBY.ToString("0.00"), TextFont, Brushes.Black, m_fltX12 + 5, curRowY);
            e.Graphics.DrawString("￥" + m_dblOtherJZ.ToString("0.00"), TextFont, Brushes.Black, m_fltX13 + 5, curRowY);
            curRowY += 15;
            m_fltY4 = curRowY;
            e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
            curRowY += 5;
            e.Graphics.DrawString("共有发票 " + StatisticsRow["开票数"].ToString().Trim() + " 张，有效发票 " + StatisticsRow["有效票数"].ToString() + " 张,注销发票 " + StatisticsRow["退票数"].ToString().Trim() + " 张,恢复发票 " + StatisticsRow["恢复票数"].ToString().Trim() + " 张", TextFont, Brushes.Black, m_fltX1 + 5, curRowY);
            curRowY += 20;
            float tolMoney = float.Parse(StatisticsRow["实收现金合计"].ToString());
            string strMoney = clsMain.CurrencyToString(Math.Abs(tolMoney));
            e.Graphics.DrawString("实收现金(大写):"+strMoney, TextFont, Brushes.Black, m_fltX1 + 5, curRowY);
            curRowY += 15;
            m_fltY5 = curRowY;
            e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
            curRowY += 5;

            e.Graphics.DrawString("现金人次:" + StatisticsRow["现金人次"].ToString(), TextFont, Brushes.Black, m_fltX1 + 5, curRowY);
            e.Graphics.DrawString("IC卡人次:" + StatisticsRow["IC卡人次"].ToString(), TextFont, Brushes.Black, m_fltX2, curRowY);
            e.Graphics.DrawString("银行卡人次:" + StatisticsRow["银行卡人次"].ToString(), TextFont, Brushes.Black, m_fltX3 + 35, curRowY);
            e.Graphics.DrawString("支票人次:" + StatisticsRow["支票人次"].ToString(), TextFont, Brushes.Black, m_fltX4 + 80, curRowY);
            e.Graphics.DrawString("医保人次:" + StatisticsRow["医保人次"].ToString(), TextFont, Brushes.Black, m_fltX5 + 120, curRowY);
            e.Graphics.DrawString("公费人次:" + StatisticsRow["公费人次"].ToString(), TextFont, Brushes.Black, m_fltX6 + 140, curRowY);
            e.Graphics.DrawString("特困人次:" + StatisticsRow["特困人次"].ToString(), TextFont, Brushes.Black, m_fltX7 + 160, curRowY);
            e.Graphics.DrawString("离休人次:" + StatisticsRow["离休人次"].ToString(), TextFont, Brushes.Black, m_fltX8 + 180, curRowY);
            e.Graphics.DrawString("本院人次:" + StatisticsRow["本院人次"].ToString(), TextFont, Brushes.Black, m_fltX9 + 200, curRowY);
            e.Graphics.DrawString("其他人次:" + StatisticsRow["其他记帐人次"].ToString(), TextFont, Brushes.Black, m_fltX10 +220, curRowY);
            curRowY += 15;
            e.Graphics.DrawLine(Pens.Black, curRowX, curRowY, PageWidth - RightWith, curRowY);
            m_fltY6 = curRowY;

            e.Graphics.DrawLine(Pens.Black, m_fltX1, m_fltY1, m_fltX1, m_fltY6);
            e.Graphics.DrawLine(Pens.Black, m_fltX2, m_fltY1, m_fltX2, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX3, m_fltY1, m_fltX3, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX4, m_fltY1, m_fltX4, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX5, m_fltY1, m_fltX5, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX6, m_fltY1, m_fltX6, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX7, m_fltY1, m_fltX7, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX8, m_fltY1, m_fltX8, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX9, m_fltY1, m_fltX9, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX10, m_fltY1, m_fltX10, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX11, m_fltY1, m_fltX11, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX12, m_fltY1, m_fltX12, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX13, m_fltY1, m_fltX13, m_fltY4);
            e.Graphics.DrawLine(Pens.Black, m_fltX14, m_fltY1, m_fltX14, m_fltY6);

            curRowY += 20;
            e.Graphics.DrawString("打印时间:" + DateTime.Now.ToString("yyyy年MM月dd日HH时mm分")+"              操作员姓名:"+this.m_objViewer.LoginInfo.m_strEmpName, TextFont, Brushes.Black, m_fltX1 + 5, curRowY);
            curRowY += 25;
            e.Graphics.DrawString("主管：            会计：            出纳：            制单：", TextFont, Brushes.Black, m_fltX1 + 5, curRowY);

        }
        public void m_mthGetRecord(DataTable m_objTable, ArrayList m_objArrayList, out List<clsInvoice_Vo> m_objList)
        {
            m_objList = new List<clsInvoice_Vo>();
           clsInvoice_Vo m_objTempVo = new clsInvoice_Vo();
           for (int i = 0; i < m_objArrayList.Count; i++)
           {
               if (i == 0)
               {
                   m_objTempVo.m_strFirstInvoiceNo = m_objArrayList[i].ToString();
               }
               if (m_objArrayList[i].ToString() == ",")
               {
                   m_objTempVo.m_strEndInvoiceNo = m_objArrayList[i-1].ToString();
                   m_objList.Add(m_objTempVo);
                   m_objTempVo = new clsInvoice_Vo();
                   m_objTempVo.m_strFirstInvoiceNo = m_objArrayList[i+1].ToString();
               }
               else
               {
                   if (i == m_objArrayList.Count - 1)
                   {
                       m_objTempVo.m_strEndInvoiceNo = m_objArrayList[i].ToString();
                       m_objList.Add(m_objTempVo);
                   }
                   for (int j = 0; j < m_objTable.Rows.Count; j++)
                   {
                       if (m_objTable.Rows[j]["STATUS_INT"].ToString() == "1")
                       {
                           if (j == 0 && m_objArrayList[i].ToString().Trim() == m_objTable.Rows[j]["invoiceno_vchr"].ToString().Trim())
                           {
                               m_objTempVo.m_intInvoiceCount++;
                               m_objTempVo.m_dblTotalMoney += Convert.ToDouble(m_objTable.Rows[j]["TOTALSUM_MNY"].ToString());
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "3")
                               {
                                   m_objTempVo.m_dblICCar += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "1")
                               {
                                   m_objTempVo.m_dblBankCar += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "0")
                               {
                                   m_objTempVo.m_dblCash += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "2")
                               {
                                   m_objTempVo.m_dblCheque += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "0" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "1" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "2" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "3" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "4" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "5")
                               {
                                   m_objTempVo.m_dblOtherJZ += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "1")
                               {
                                   m_objTempVo.m_dblGFJZ += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "3")
                               {
                                   m_objTempVo.m_dblTK += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "4")
                               {
                                   m_objTempVo.m_dblLX += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "5")
                               {
                                   m_objTempVo.m_dblBY += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "2")
                               {
                                   m_objTempVo.m_dblTDYB += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                           }
                           else if (j > 1 && m_objArrayList[i].ToString().Trim() == m_objTable.Rows[j]["invoiceno_vchr"].ToString().Trim() && m_objTable.Rows[j]["invoiceno_vchr"].ToString().Trim() != m_objTable.Rows[j-1]["invoiceno_vchr"].ToString().Trim())
                           {
                               m_objTempVo.m_intInvoiceCount++;
                               m_objTempVo.m_dblTotalMoney += Convert.ToDouble(m_objTable.Rows[j]["TOTALSUM_MNY"].ToString());
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "3")
                               {
                                   m_objTempVo.m_dblICCar += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "1")
                               {
                                   m_objTempVo.m_dblBankCar += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "0")
                               {
                                   m_objTempVo.m_dblCash += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["PAYTYPE_INT"].ToString().Trim() == "2")
                               {
                                   m_objTempVo.m_dblCheque += Convert.ToDouble(m_objTable.Rows[j]["SBSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "0" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "1" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "2" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "3" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "4" && m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() != "5")
                               {
                                   m_objTempVo.m_dblOtherJZ += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "1")
                               {
                                   m_objTempVo.m_dblGFJZ += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "3")
                               {
                                   m_objTempVo.m_dblTK += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "4")
                               {
                                   m_objTempVo.m_dblLX += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "5")
                               {
                                   m_objTempVo.m_dblBY += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                               if (m_objTable.Rows[j]["INTERNALFLAG_INT"].ToString().Trim() == "2")
                               {
                                   m_objTempVo.m_dblTDYB += Convert.ToDouble(m_objTable.Rows[j]["ACCTSUM_MNY"].ToString());
                               }
                           }
                       }

                   }
               }
           }
         
        }
    }
    public class clsInvoice_Vo
    {
        public string m_strFirstInvoiceNo=string.Empty;
        public string m_strEndInvoiceNo=string.Empty;
        public int m_intInvoiceCount=0;
        public double m_dblTotalMoney = 0;
        public double m_dblCash = 0;
        public double m_dblICCar = 0;
        public double m_dblBankCar = 0;
        public double m_dblCheque = 0;
        public double m_dblOtherJZ = 0;
        public double m_dblGFJZ = 0;
        public double m_dblTK = 0;
        public double m_dblLX = 0;
        public double m_dblBY = 0;
        public double m_dblTDYB = 0;

    }
}
