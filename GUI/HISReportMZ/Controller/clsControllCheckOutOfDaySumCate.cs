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
using System.Drawing.Printing;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsControllCheckOutOfDaySumCate : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmCheckOutOfDaySumByCate m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCheckOutOfDaySumByCate)frmMDI_Child_Base_in;
            m_strHospitalTitle = this.m_objComInfo.m_strGetHospitalTitle() + "门诊收费员分类汇总日结报表";
            hospitalNo = this.m_objComInfo.m_mthGetHospitalNo();
            m_objDomain = new clsDomainControl_Register();
        }
        #endregion
        string m_strHospitalTitle = "门诊收费员分类汇总日结报表";
        string hospitalNo = "10000";
        clsDomainControl_Register m_objDomain;
        public string[] m_strInvoArr = null;
        DataTable dtCheckOut = new DataTable();
        DataTable dtPayType = new DataTable();
        private DataTable dtStatistics = new DataTable();
        private DataRow StatisticsRow;
        private ArrayList SaveINVOICENO = new ArrayList();
        string strCheckDate = "";
        private ArrayList arrList;
        private ArrayList arrReList = new ArrayList();
        /// <summary>
        /// 生育保险身份ID
        /// </summary>
        internal string BirthPayTypeID { get; set; }

        public void m_mthBeginStat()
        {
            arrReList.Clear();
            SaveINVOICENO.Clear();
            this.dtCheckOut = null;
            string m_strBeginTime = this.m_objViewer.m_datBeginTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string m_strEndTime = this.m_objViewer.m_datEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string m_strBalanceEmpID = this.m_objViewer.m_cboCheckMan.SelectItemValue;
            string m_strBalanceDeptID = this.m_objViewer.m_cbodept.SelectItemValue;
            DataTable dtDiff = new DataTable();
            m_objDomain.m_lngGetCheckedOutDataByCondition(this.m_objViewer.m_cboStatDateType.SelectedIndex, m_strBalanceEmpID, m_strBalanceDeptID, m_strBeginTime, m_strEndTime, this.m_objViewer.m_strRPTID, this.m_objViewer.FenyuanSFCdeptIDArr, out dtCheckOut, out dtDiff);


            // strCheckDate = this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.CurrentCell.RowNumber, 0].ToString();
            // string BALANCEEMP = this.m_objViewer.LoginInfo.m_strEmpID;
            //m_objDomain.GetCheckOutHistory(strCheckDate, strCheckManID, this.m_objViewer.m_rptId, out dtCheckOut);
            //m_objDomain.m_mthGetbalancerepeatinvoinfo(strCheckManID, strCheckDate, out this.m_strInvoArr, intcomand);

            arrList = new ArrayList();
            DataView dv = new DataView(dtCheckOut);
            dv.RowFilter = "STATUS_INT = 1";
            dv.Sort = "INVOICENO_VCHR";
            clsMain.m_Detach(dv.ToTable(), "INVOICENO_VCHR", out arrList);

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
            dtStatistics.Columns.Add("医保人次");
            dtStatistics.Columns.Add("公费人次");
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
            dtStatistics.Columns.Add("药品已让利");
            dtStatistics.Columns.Add("支票");
            dtStatistics.Columns.Add("特诊卡");
            dtStatistics.Columns.Add("生育保险");
            dtStatistics.Columns.Add("微信合计");
            dtStatistics.Columns.Add("支付宝合计");
            dtStatistics.Columns.Add("微信2合计");
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

            StatisticsRow["微信合计"] = 0.00;
            StatisticsRow["支付宝合计"] = 0.00;
            StatisticsRow["微信2合计"] = 0.00;

            StatisticsRow["支票金额合计"] = 0.00;
            StatisticsRow["医保记账金额"] = 0.00;
            StatisticsRow["公费记账金额"] = 0.00;
            StatisticsRow["自费上缴金额"] = 0.00;

            StatisticsRow["实收金额合计"] = 0.00;
            StatisticsRow["其它记帐金额"] = 0.00;
            StatisticsRow["医保人次"] = 0;
            StatisticsRow["公费人次"] = 0;
            StatisticsRow["自费及其它人次"] = 0;
            StatisticsRow["自费人次"] = 0;
            StatisticsRow["其它金额合计"] = 0;
            StatisticsRow["IC卡金额合计"] = 0;
            StatisticsRow["特困记帐"] = 0;
            StatisticsRow["离休记帐"] = 0;
            StatisticsRow["本院记帐"] = 0;
            StatisticsRow["其它记帐"] = 0;
            StatisticsRow["生育保险"] = 0;
            StatisticsRow["第一张发票时间"] = "";
            StatisticsRow["最后一张发票时间"] = "";
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
                                if (!string.IsNullOrEmpty(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString()))
                                {
                                    StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString());
                                }
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
                            SaveINVOICENO.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["退票数"] = Convert.ToInt32(StatisticsRow["退票数"].ToString()) + 1;
                                if (!string.IsNullOrEmpty(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString()))
                                {
                                    StatisticsRow["退票金额合计"] = Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["退票金额合计"] = (Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - 0).ToString();
                                }
                                SaveINVOICENO.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
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
                            arrReList.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());

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
                                arrReList.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
                            }
                        }
                    }

                    //----------------------



                    //统计现金合计
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "0")//统计现金合计
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }
                    }

                    //-----------------------


                    //刷卡合计
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "1")//刷卡合计
                    {
                        if (i1 == 0)
                        {

                            //							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
                            //							    StatisticsRow["刷卡金额合计"]=Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim())-Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            //							else
                            StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }

                    }

                    //---------------


                    //支票
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "2")//支票
                    {
                        if (i1 == 0)
                        {
                            //							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
                            //							{
                            //								StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())-Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            //							}
                            //							else
                            //							{
                            StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            //							}
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                //								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
                                //								{
                                //									StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                //								}
                                //								else
                                //								{
                                StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                                //								}
                            }
                        }

                    }
                    //------------------

                    // 微信合计
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "8")
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["微信合计"] = Convert.ToDouble(StatisticsRow["微信合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["微信合计"] = Convert.ToDouble(StatisticsRow["微信合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }
                    }

                    // 支付宝合计
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "9")
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["支付宝合计"] = Convert.ToDouble(StatisticsRow["支付宝合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["支付宝合计"] = Convert.ToDouble(StatisticsRow["支付宝合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }
                    }

                    // 微信2合计
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "5")
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["微信2合计"] = Convert.ToDouble(StatisticsRow["微信2合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["微信2合计"] = Convert.ToDouble(StatisticsRow["微信2合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }
                    }

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
                    //if (this.m_objViewer.Hospital_No == "00001")
                    if (this.hospitalNo == "00001")
                    {
                        //其它记帐金额及人次

                        if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "1" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "2" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "3" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "4" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "5")
                        {
                            if (i1 == 0)
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) - 1;
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) + 1;
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
                                        StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) - 1;
                                        StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    }
                                    else
                                    {
                                        StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) - 1;
                                        StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "1" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "2" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "4" && dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() != "5")
                        {
                            if (i1 == 0)
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {
                                    StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) - 1;
                                    StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {
                                    StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) + 1;
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
                                        StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) - 1;
                                        StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    }
                                    else
                                    {
                                        StatisticsRow["自费及其它人次"] = Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString()) - 1;
                                        StatisticsRow["其它记帐金额"] = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                    }
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

                            StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {

                                StatisticsRow["特困记帐"] = Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }

                    #endregion

                    #region 离休记账金额
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "4")
                    {
                        if (i1 == 0)
                        {

                            StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {

                                StatisticsRow["离休记帐"] = Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }

                    #endregion

                    #region 本院记账金额
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "5")
                    {
                        if (i1 == 0)
                        {

                            StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {

                                StatisticsRow["本院记帐"] = Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }

                    #endregion

                    #region IC卡支付


                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "3")
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["IC卡金额合计"] = Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }

                    }

                    #endregion

                    #region 其它金额合计
                    //if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="0"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="3"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5")
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

                    ////佛二：其它支付－>其它记帐
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

                    #region 生育保险

                    if (!string.IsNullOrEmpty(BirthPayTypeID) && BirthPayTypeID == dtCheckOut.Rows[i1]["paytypeid_chr"].ToString().Trim())
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["生育保险"] = Convert.ToDouble(StatisticsRow["生育保险"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["生育保险"] = Convert.ToDouble(StatisticsRow["生育保险"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }
                    #endregion

                }
            }
            double decDiffSum = 0;
            if (dtDiff != null && dtDiff.Rows.Count > 0)
            {
                com.digitalwave.Utility.clsLogText objlog = new com.digitalwave.Utility.clsLogText();
                objlog.LogError("dtCheckOut:" + dtCheckOut.Rows.Count.ToString());
                objlog.LogError("dtDiff:" + dtDiff.Rows.Count.ToString());
                for (int i = 0; i < dtDiff.Rows.Count; i++)// (DataRow dr in dtDiff.Rows)
                {
                    if (!string.IsNullOrEmpty(dtDiff.Rows[i]["totaldiffcost_mny"].ToString()))
                    {
                        decDiffSum += Convert.ToDouble(dtDiff.Rows[i]["totaldiffcost_mny"].ToString());
                    }
                }
                StatisticsRow["药品已让利"] = decDiffSum.ToString();
            }
            else
            {
                StatisticsRow["药品已让利"] = "0";
            }

            //---------------------

            //计算有效票数
            int intAvailability = Convert.ToInt32(StatisticsRow["开票数"].ToString().Trim()) - Convert.ToInt32(StatisticsRow["退票数"].ToString().Trim()) + Convert.ToInt32(StatisticsRow["恢复票数"].ToString().Trim());

            //计算有效金额
            Double AvailabilityMoney = Convert.ToDouble(StatisticsRow["开票金额"].ToString().Trim()) - Convert.ToDouble(StatisticsRow["退票金额合计"].ToString().Trim()) + Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString().Trim());

            StatisticsRow["有效票数"] = intAvailability.ToString();
            StatisticsRow["实收金额合计"] = AvailabilityMoney.ToString();
            #endregion

            #region 设置显示数据窗口
            SetDatawindow(StatisticsRow);
            #endregion
        }
        private void SetDatawindow(DataRow StatisticsRow)
        {

            this.m_objViewer.m_dwShow.Reset();
            this.m_objViewer.m_dwShow.SetRedrawOff();

            for (int i1 = 1; i1 < 13; i1++)
            {
                this.m_objViewer.m_dwShow.Modify("sum_" + i1.ToString().PadLeft(4, '0') + ".text = ' '");

            }
            this.m_objViewer.m_dwShow.Modify("sum_total.text = '￥" + (Convert.ToDouble(StatisticsRow["开票金额"].ToString()) - Convert.ToDouble(StatisticsRow["药品已让利"].ToString())).ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_reimbursement.text = '￥" + StatisticsRow["退票金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_recover.text = '￥" + StatisticsRow["恢复金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_real.text = '￥" + (Convert.ToDouble(StatisticsRow["实收金额合计"].ToString()) - Convert.ToDouble(StatisticsRow["药品已让利"].ToString())).ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("count_real.text = '" + StatisticsRow["有效票数"].ToString() + "'");
            double tolMoney = double.Parse((Convert.ToDouble(StatisticsRow["实收金额合计"].ToString()) - Convert.ToDouble(StatisticsRow["药品已让利"].ToString())).ToString());
            string strMoney = clsMain.CurrencyToString2(Math.Abs(tolMoney));
            this.m_objViewer.m_dwShow.Modify("sum_realupper.text = '" + strMoney + "'");
            double acctSum = Convert.ToDouble(StatisticsRow["公费记账金额"].ToString())
                             + Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString())
                             + Convert.ToDouble(StatisticsRow["特困记帐"].ToString())
                             + Convert.ToDouble(StatisticsRow["离休记帐"].ToString())
                             + Convert.ToDouble(StatisticsRow["本院记帐"].ToString());

            decimal sbSum = clsPublic.ConvertObjToDecimal(StatisticsRow["医保记账金额"]);
            decimal sySum = clsPublic.ConvertObjToDecimal(StatisticsRow["生育保险"]);
            if (sbSum > sySum) sbSum = sbSum - sySum;

            this.m_objViewer.m_dwShow.Modify("sum_cash.text = '￥" + StatisticsRow["实收现金合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_ic.text = '￥" + StatisticsRow["IC卡金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_bankcard.text = '￥" + StatisticsRow["刷卡金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_acct.text = '￥" + acctSum.ToString("0.00") + "'");
            this.m_objViewer.m_dwShow.Modify("sum_acctspes.text = '￥" + sbSum.ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_other.text = '￥" + StatisticsRow["其它金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("t_diffPriceSum.text= '￥-" + StatisticsRow["药品已让利"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("t_zhipiao.text ='￥" + StatisticsRow["支票金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_sybx.text ='￥" + sySum.ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("t_wechatpay.text = '￥" + StatisticsRow["微信合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("t_alipay.text = '￥" + StatisticsRow["支付宝合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("t_wechatpay2.text = '￥" + StatisticsRow["微信2合计"].ToString() + "'");

            string temp = "";
            int countTemp = 0;
            for (int i = 0; i < SaveINVOICENO.Count; i++)
            {
                if (i != SaveINVOICENO.Count - 1)
                {
                    if (countTemp == 3)
                    {
                        temp += SaveINVOICENO[i].ToString() + ",~r";
                        countTemp = 0;
                    }
                    else
                    {
                        temp += SaveINVOICENO[i].ToString() + ",";
                        countTemp++;
                    }
                }
                else
                {
                    temp += SaveINVOICENO[i].ToString();
                }
            }
            //this.m_objViewer.m_dwShow.Modify("t_reimbursementinv.text = '" + temp + "'");

            temp = "";
            countTemp = 0;
            for (int i = 0; i < arrReList.Count; i++)
            {
                if (i != arrReList.Count - 1)
                {
                    if (countTemp == 3)
                    {
                        temp += arrReList[i].ToString() + ",~r";
                        countTemp = 0;
                    }
                    else
                    {
                        temp += arrReList[i].ToString() + ",";
                    }


                }
                else
                {
                    temp += arrReList[i].ToString();
                }
            }
            //this.m_objViewer.m_dwShow.Modify("t_recoverinv.text = '" + temp + "'");

            // this.m_objViewer.m_dwShow.Modify("count_reimbursement.text = '" + StatisticsRow["退票数"].ToString() + "'");
            // this.m_objViewer.m_dwShow.Modify("count_recover.text = '" + StatisticsRow["恢复票数"].ToString() + "'");

            temp = "";
            countTemp = 0;
            if (m_strInvoArr != null)
            {
                countTemp = m_strInvoArr.Length;
                for (int i = 0; i < countTemp; i++)
                {
                    if (i != m_strInvoArr.Length - 1)
                    {
                        temp += m_strInvoArr[i] + ",";
                    }
                    else
                    {
                        temp += m_strInvoArr[i];
                    }
                }

            }
            //this.m_objViewer.m_dwShow.Modify("count_reprint.text = '" + countTemp + "'");
            // this.m_objViewer.m_dwShow.Modify("t_reprintinv.text = '" + temp + "'");

            this.m_objViewer.m_dwShow.Modify("t_title.text = '" + this.m_strHospitalTitle + "(" + this.m_objViewer.m_cboStatDateType.Text + ")" + "'");
            string m_strStatTime = "统计时间:" + this.m_objViewer.m_datBeginTime.Value.ToShortDateString() + "至" + this.m_objViewer.m_datEndTime.Value.ToShortDateString();
            this.m_objViewer.m_dwShow.Modify("t_stattime.text = '" + m_strStatTime + "'");
            this.m_objViewer.m_dwShow.Modify("t_checkman.text = '" + "收费员：" + this.m_objViewer.m_cboCheckMan.SelectItemText + "'");

            #region 填充收费类型数据
            if (dtCheckOut.Rows.Count > 0)
            {
                DataView dv = new DataView(dtCheckOut);
                string code;
                string name;
                double tempMoney;

                for (int i1 = 1; i1 < 13; i1++)
                {
                    code = i1.ToString().PadLeft(4, '0');
                    dv.RowFilter = "groupid_chr = '" + code + "'";
                    if (dv.Count > 0)
                    {
                        tempMoney = 0;
                        name = dv[0]["groupname_chr"].ToString().Trim();
                        for (int i2 = 0; i2 < dv.Count; i2++)
                        {
                            tempMoney += Convert.ToDouble(dv[i2]["tolfee_mny"].ToString());
                        }
                        this.m_objViewer.m_dwShow.Modify("t_" + code + ".text = '" + name + "'");
                        this.m_objViewer.m_dwShow.Modify("sum_" + code + ".text = '" + tempMoney.ToString("0.00") + "'");
                    }
                    else
                    {
                        this.m_objViewer.m_dwShow.Modify("sum_" + code + ".text = ' '");
                    }
                }
            }

            #endregion
            this.m_objViewer.m_dwShow.AcceptText();
            this.m_objViewer.m_dwShow.SetRedrawOn();
            this.m_objViewer.m_dwShow.Refresh();
        }

    }
}
