using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Text;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsControlCheckOutOfDayGY : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlCheckOutOfDayGY()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCheckOutOfDayGY)frmMDI_Child_Base_in;
        }

        private frmCheckOutOfDayGY m_objViewer;
        /// <summary>
        /// 重打发票号数组
        /// </summary>
        public string[] m_strInvoArr = null;
        DataTable dtCheckOut = new DataTable();
        DataTable dtRecipesumde = new DataTable();
        DataTable dtRecipeinv = new DataTable();
        DataTable dtbAllRecipeinv = new DataTable();
        com.digitalwave.iCare.gui.HIS.Reports.clsDomainControl_Register Domain = new com.digitalwave.iCare.gui.HIS.Reports.clsDomainControl_Register();
        private DataTable dtStatistics = new DataTable();
        private DataRow StatisticsRow;
        private ArrayList SaveINVOICENO = new ArrayList();
        /// <summary>
        /// 0-未结帐1-结帐
        /// </summary>
        int intcomand = 0;
        string strCheckDate = "";
        private ArrayList arrList;
        private ArrayList arrReList = new ArrayList();
        string strCheckManID = "";

        public void dgSelect()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            intcomand = 1;
            this.previewReport();
            this.m_objViewer.Cursor = Cursors.Default;
        }

        public void Reset()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            intcomand = 0;
            this.previewReport();
            this.m_objViewer.Cursor = Cursors.Default;
        }

        public void previewReport()
        {
            this.getData();
            this.printPageGY();
        }

        private void getData()
        {
            strCheckManID = this.m_objViewer.LoginInfo.m_strEmpID;
            string[] strDateArr = new string[2];
            ArrayList arrPaytype = this.m_objViewer.PayTypeArr;
            Hashtable has = new Hashtable();
            if (arrPaytype.Count > 0)
            {
                foreach (string str in arrPaytype)
                {
                    if (!has.ContainsKey(str))
                    { has.Add(str, str); }
                }
            }
            arrReList.Clear();
            SaveINVOICENO.Clear();
            if (intcomand == 0)
            {
                com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
                string checkDate = HisBase.s_GetServerDate().ToString();
                strDateArr[0] = checkDate;
                Domain.m_lngGetCheckOutOfData("", 0, 0, strCheckManID, strDateArr, out dtRecipesumde, out dtCheckOut, out dtRecipeinv);
                strCheckDate = DateTime.Now.ToShortDateString();
                this.m_objViewer.btnPrint.Enabled = false;
                this.m_objViewer.buttonXP3.Enabled = false;
                this.m_objViewer.buttonXP2.Enabled = false;
                this.m_objViewer.buttonXP4.Enabled = false;
            }
            else
            {
                strCheckDate = this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.CurrentCell.RowNumber, 0].ToString();
                strDateArr[0] = strCheckDate;
                Domain.m_lngGetPayTypeAndCheckOutDatahistory("", 0, strDateArr, strCheckManID, out dtRecipesumde, out dtCheckOut, out dtRecipeinv);
                this.m_objViewer.btnCheck.Enabled = false;
                this.m_objViewer.btnPrint.Enabled = true;
                this.m_objViewer.buttonXP3.Enabled = false;
                this.m_objViewer.buttonXP2.Enabled = false;
                this.m_objViewer.buttonXP4.Enabled = false;
            }

            #region 生成一个统计表
            dtStatistics = new DataTable();
            dtStatistics.Columns.Add("开票数");//收据张数
            dtStatistics.Columns.Add("开票金额");//计价
            dtStatistics.Columns.Add("退票数");//退费张数
            dtStatistics.Columns.Add("退票金额合计");//退费金额
            dtStatistics.Columns.Add("有效票数");
            dtStatistics.Columns.Add("实收金额合计");//应收 & 实收
            dtStatistics.Columns.Add("实收现金合计");//现金
            dtStatistics.Columns.Add("现金退款");//现金退款
            dtStatistics.Columns.Add("刷卡金额合计");//银联POS
            dtStatistics.Columns.Add("刷卡退款");//银联POS退款
            dtStatistics.Columns.Add("支票金额合计");//支票
            dtStatistics.Columns.Add("支票退款");//支票退款
            dtStatistics.Columns.Add("医保记账金额");//铁路垫支
            dtStatistics.Columns.Add("铁路垫支退款");//铁路垫支退款
            dtStatistics.Columns.Add("汇款存款");//汇款存款
            dtStatistics.Columns.Add("汇款退款");//汇款退款
            dtStatistics.Columns.Add("开始发票号");//最小收据号
            dtStatistics.Columns.Add("结束发票号");//最大收据号
            dtStatistics.Columns.Add("第一张发票时间");//
            dtStatistics.Columns.Add("最后一张发票时间");//
            dtStatistics.Columns.Add("记帐收款");//记帐收款
            dtStatistics.Columns.Add("记帐退款");//记帐退款
            dtStatistics.Columns.Add("记帐单记帐");//无记帐单记帐
            dtStatistics.Columns.Add("无记帐单记帐");//无记帐单记帐

            dtStatistics.Columns.Add("其它金额合计");//其它收款
            dtStatistics.Columns.Add("其它退款");//其它退款
            #endregion

            #region 统计各种收费类型的金额
            if (dtRecipesumde.Rows.Count >= 0)
            {
                if (intcomand == 0)
                {
                    this.m_objViewer.btnCheck.Enabled = true;
                }
            }
            else
            {
                this.m_objViewer.btnCheck.Enabled = false;
                this.m_objViewer.btnPrint.Enabled = false;
                this.m_objViewer.buttonXP3.Enabled = false;
                this.m_objViewer.buttonXP2.Enabled = false;
            }
            #endregion

            #region 统计数据
            StatisticsRow = dtStatistics.NewRow();
            StatisticsRow["开票数"] = 0;
            StatisticsRow["开票金额"] = 0.00;
            StatisticsRow["退票数"] = 0;
            StatisticsRow["退票金额合计"] = 0.00;

            StatisticsRow["实收现金合计"] = 0.00;
            StatisticsRow["现金退款"] = 0.00;
            StatisticsRow["刷卡金额合计"] = 0.00;
            StatisticsRow["刷卡退款"] = 0.00;

            StatisticsRow["支票金额合计"] = 0.00;
            StatisticsRow["支票退款"] = 0.00;
            StatisticsRow["医保记账金额"] = 0.00;
            StatisticsRow["铁路垫支退款"] = 0.00;
            StatisticsRow["汇款存款"] = 0.00;
            StatisticsRow["汇款退款"] = 0.00;

            StatisticsRow["实收金额合计"] = 0.00;
            StatisticsRow["现金退款"] = 0.00;
            StatisticsRow["第一张发票时间"] = "";
            StatisticsRow["最后一张发票时间"] = "";
            StatisticsRow["记帐收款"] = 0.00;
            StatisticsRow["记帐退款"] = 0.00;
            StatisticsRow["记帐单记帐"] = 0.00;
            StatisticsRow["无记帐单记帐"] = 0.00;

            StatisticsRow["其它金额合计"] = 0;
            StatisticsRow["其它退款"] = 0;

            arrList = new ArrayList();
            for (int k1 = 0; k1 < dtRecipeinv.Rows.Count; k1++)
            {
                #region 统计有关发票的信息
                //计算发票的第一张和最后一张
                if (k1 == 0)
                {
                    StatisticsRow["第一张发票时间"] = Convert.ToDateTime(dtRecipeinv.Rows[0]["operdate_dat"].ToString());
                    StatisticsRow["最后一张发票时间"] = Convert.ToDateTime(dtRecipeinv.Rows[0]["operdate_dat"].ToString());
                }
                else
                {
                    if (Convert.ToDateTime(dtRecipeinv.Rows[k1]["operdate_dat"].ToString()) < Convert.ToDateTime(StatisticsRow["第一张发票时间"].ToString()))
                    { StatisticsRow["第一张发票时间"] = Convert.ToDateTime(dtRecipeinv.Rows[k1]["operdate_dat"].ToString()); }
                    if (Convert.ToDateTime(dtRecipeinv.Rows[k1]["operdate_dat"].ToString()) > Convert.ToDateTime(StatisticsRow["最后一张发票时间"].ToString()))
                    { StatisticsRow["最后一张发票时间"] = Convert.ToDateTime(dtRecipeinv.Rows[k1]["operdate_dat"].ToString()); }
                }

                //统计开票数,开票金额
                if (k1 == 0)
                {
                    StatisticsRow["开票数"] = Convert.ToInt16(StatisticsRow["开票数"].ToString()) + 1;
                    if (dtRecipeinv.Rows[k1]["type_int"].ToString().Trim() == "1")
                        StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtRecipeinv.Rows[k1]["totalsum_mny"].ToString());
                }
                else
                {
                    if (dtRecipeinv.Rows[k1]["chargeno_chr"].ToString().Trim() == dtRecipeinv.Rows[k1 - 1]["chargeno_chr"].ToString().Trim())
                    {
                        StatisticsRow["开票数"] = Convert.ToInt16(StatisticsRow["开票数"].ToString()) + 1;
                    }
                    else
                    {
                        StatisticsRow["开票数"] = Convert.ToInt16(StatisticsRow["开票数"].ToString()) + 1;
                        if (dtRecipeinv.Rows[k1]["type_int"].ToString().Trim() == "1")
                            StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtRecipeinv.Rows[k1]["totalsum_mny"].ToString());
                    }
                }


                //退票数,退票金额合计,所有的退票号                
                if (dtRecipeinv.Rows[k1]["type_int"].ToString().Trim() == "2")//退票数,退票金额合计,所有的退票号
                {
                    if (k1 == 0)
                    {
                        StatisticsRow["退票数"] = Convert.ToInt16(StatisticsRow["退票数"].ToString()) + 1;
                        StatisticsRow["退票金额合计"] = Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - Convert.ToDouble(dtRecipeinv.Rows[k1]["totalsum_mny"].ToString());
                        SaveINVOICENO.Add(dtRecipeinv.Rows[k1]["invoiceno_vchr"].ToString());
                    }
                    else
                    {
                        if (dtRecipeinv.Rows[k1]["chargeno_chr"].ToString().Trim() == dtRecipeinv.Rows[k1 - 1]["chargeno_chr"].ToString().Trim())
                        {
                            StatisticsRow["退票数"] = Convert.ToInt16(StatisticsRow["退票数"].ToString()) + 1;
                            SaveINVOICENO.Add(dtRecipeinv.Rows[k1]["invoiceno_vchr"].ToString());
                        }
                        else
                        {
                            StatisticsRow["退票数"] = Convert.ToInt16(StatisticsRow["退票数"].ToString()) + 1;
                            StatisticsRow["退票金额合计"] = Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - Convert.ToDouble(dtRecipeinv.Rows[k1]["totalsum_mny"].ToString());
                            SaveINVOICENO.Add(dtRecipeinv.Rows[k1]["invoiceno_vchr"].ToString());
                        }
                    }
                }
                #endregion
            }

            if (dtRecipeinv.Rows.Count > 0)
            {
                StatisticsRow["开始发票号"] = dtRecipeinv.Rows[0]["invoiceno_vchr"].ToString();
                StatisticsRow["结束发票号"] = dtRecipeinv.Rows[dtRecipeinv.Rows.Count - 1]["invoiceno_vchr"].ToString();
            }

            DataRow dr = null;
            for (int i1 = 0; i1 < dtCheckOut.Rows.Count; i1++)
            {
                dr = dtCheckOut.Rows[i1];
                if (dtCheckOut.Rows[i1]["type_int"].ToString().Trim() == "1")//收款
                {
                    switch (dtCheckOut.Rows[i1]["paytype_int"].ToString().Trim())
                    {
                        case "0":
                            StatisticsRow["实收现金合计"] = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "1":
                            StatisticsRow["刷卡金额合计"] = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "2":
                            StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "3":
                            StatisticsRow["医保记账金额"] = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "4":
                            StatisticsRow["汇款存款"] = Convert.ToDouble(StatisticsRow["汇款存款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        default:
                            StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                    }
                    if (i1 == 0)
                    {
                        StatisticsRow["记帐收款"] = Convert.ToDouble(StatisticsRow["记帐收款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["acctsum_mny"].ToString());
                        StatisticsRow["记帐单记帐"] = Convert.ToDouble(StatisticsRow["记帐单记帐"].ToString().Trim()) + this.dblSbmny(1, has, ref dr);
                        StatisticsRow["无记帐单记帐"] = Convert.ToDouble(StatisticsRow["无记帐单记帐"].ToString().Trim()) + this.dblSbmny(0, has, ref dr);
                    }
                    else
                    {
                        if (dtCheckOut.Rows[i1]["chargeno_chr"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["chargeno_chr"].ToString().Trim())
                        { }
                        else
                        {
                            StatisticsRow["记帐收款"] = Convert.ToDouble(StatisticsRow["记帐收款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["acctsum_mny"].ToString());
                            StatisticsRow["记帐单记帐"] = Convert.ToDouble(StatisticsRow["记帐单记帐"].ToString().Trim()) + this.dblSbmny(1, has, ref dr);
                            StatisticsRow["无记帐单记帐"] = Convert.ToDouble(StatisticsRow["无记帐单记帐"].ToString().Trim()) + this.dblSbmny(0, has, ref dr);
                        }
                    }
                }
                else//退款
                {
                    switch (dtCheckOut.Rows[i1]["paytype_int"].ToString().Trim())
                    {
                        case "0":
                            StatisticsRow["现金退款"] = Convert.ToDouble(StatisticsRow["现金退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "1":
                            StatisticsRow["刷卡退款"] = Convert.ToDouble(StatisticsRow["刷卡退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "2":
                            StatisticsRow["支票退款"] = Convert.ToDouble(StatisticsRow["支票退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "3":
                            StatisticsRow["铁路垫支退款"] = Convert.ToDouble(StatisticsRow["铁路垫支退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        case "4":
                            StatisticsRow["汇款退款"] = Convert.ToDouble(StatisticsRow["汇款退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                        default:
                            StatisticsRow["其它退款"] = Convert.ToDouble(StatisticsRow["其它退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["sbmoney"].ToString());
                            break;
                    }
                    if (i1 == 0)
                    {
                        StatisticsRow["记帐退款"] = Convert.ToDouble(StatisticsRow["记帐退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["acctsum_mny"].ToString());
                        StatisticsRow["记帐单记帐"] = Convert.ToDouble(StatisticsRow["记帐单记帐"].ToString().Trim()) + this.dblSbmny(1, has, ref dr);
                        StatisticsRow["无记帐单记帐"] = Convert.ToDouble(StatisticsRow["无记帐单记帐"].ToString().Trim()) + this.dblSbmny(0, has, ref dr);
                    }
                    else
                    {
                        if (dtCheckOut.Rows[i1]["chargeno_chr"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["chargeno_chr"].ToString().Trim())
                        { }
                        else
                        {
                            StatisticsRow["记帐退款"] = Convert.ToDouble(StatisticsRow["记帐退款"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["acctsum_mny"].ToString());
                            StatisticsRow["记帐单记帐"] = Convert.ToDouble(StatisticsRow["记帐单记帐"].ToString().Trim()) + this.dblSbmny(1, has, ref dr);
                            StatisticsRow["无记帐单记帐"] = Convert.ToDouble(StatisticsRow["无记帐单记帐"].ToString().Trim()) + this.dblSbmny(0, has, ref dr);
                        }
                    }
                }
            }

            //计算有效票数
            int intAvailability = Convert.ToInt32(StatisticsRow["开票数"].ToString().Trim()) - Convert.ToInt32(StatisticsRow["退票数"].ToString().Trim());

            //计算有效金额
            Double AvailabilityMoney = Convert.ToDouble(StatisticsRow["开票金额"].ToString().Trim()) - Convert.ToDouble(StatisticsRow["退票金额合计"].ToString().Trim());

            StatisticsRow["有效票数"] = intAvailability.ToString();
            StatisticsRow["实收金额合计"] = AvailabilityMoney.ToString();
            dtStatistics.Rows.Add(StatisticsRow);
            dtStatistics.AcceptChanges();
            #endregion
        }

        private void printPageGY()
        {
            try
            {
                this.m_objViewer.m_dwShow.Reset();
                this.m_objViewer.m_dwShow.Modify("t_datefrom.text = '" + StatisticsRow["第一张发票时间"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_dateto.text = '" + StatisticsRow["最后一张发票时间"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_checkdate.text = '" + strCheckDate + "'");
                this.m_objViewer.m_dwShow.Modify("t_sjzs.text = '" + StatisticsRow["开票数"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_zxsjh.text = '" + StatisticsRow["开始发票号"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_zdsjh.text = '" + StatisticsRow["结束发票号"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_mfzs.text = '0'");
                this.m_objViewer.m_dwShow.Modify("t_tfzs.text = '" + StatisticsRow["退票数"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_tfje.text = '" + StatisticsRow["退票金额合计"].ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_zfzs.text = '0'");
                this.m_objViewer.m_dwShow.Modify("t_jj.text = '" + strTranslate(StatisticsRow["开票金额"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_ys.text = '" + strTranslate(StatisticsRow["实收金额合计"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_ss.text = '" + strTranslate(StatisticsRow["实收金额合计"]) + "'");
                double totalmny = 0;
                this.m_objViewer.m_dwShow.Modify("t_title.text = '" + this.m_objViewer.strReportTitle + "'");
                this.m_objViewer.m_dwShow.Modify("t_jzs.text = '" + strTranslate(StatisticsRow["记帐收款"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_jzt.text = '" + strTranslate(StatisticsRow["记帐退款"]) + "'");
                Double totalTmp = Convert.ToDouble(StatisticsRow["记帐收款"].ToString()) - Math.Abs(Convert.ToDouble(StatisticsRow["记帐退款"].ToString()));
                this.m_objViewer.m_dwShow.Modify("jzdjz.text = '" + strTranslate(Convert.ToDouble(StatisticsRow["记帐单记帐"].ToString())) + "'");
                this.m_objViewer.m_dwShow.Modify("wjzdjz.text = '" + strTranslate(Convert.ToDouble(StatisticsRow["无记帐单记帐"].ToString())) + "'");
                totalmny += totalTmp;
                this.m_objViewer.m_dwShow.Modify("t_jztol.text = '" + strTranslate(totalTmp) + "'");
                this.m_objViewer.m_dwShow.Modify("t_pos.text = '" + strTranslate(StatisticsRow["刷卡金额合计"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_pot.text = '" + strTranslate(StatisticsRow["刷卡退款"]) + "'");
                totalTmp = Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString()) - Math.Abs(Convert.ToDouble(StatisticsRow["刷卡退款"].ToString()));
                totalmny += totalTmp;
                this.m_objViewer.m_dwShow.Modify("t_potol.text = '" + strTranslate(totalTmp) + "'");
                this.m_objViewer.m_dwShow.Modify("t_zps.text = '" + strTranslate(StatisticsRow["支票金额合计"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_zpt.text = '" + strTranslate(StatisticsRow["支票退款"]) + "'");
                totalTmp = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString()) - Math.Abs(Convert.ToDouble(StatisticsRow["支票退款"].ToString()));
                totalmny += totalTmp;
                this.m_objViewer.m_dwShow.Modify("t_zptol.text = '" + strTranslate(totalTmp) + "'");
                this.m_objViewer.m_dwShow.Modify("t_tls.text = '" + strTranslate(StatisticsRow["医保记账金额"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_tlt.text = '" + strTranslate(StatisticsRow["铁路垫支退款"]) + "'");
                totalTmp = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString()) - Math.Abs(Convert.ToDouble(StatisticsRow["铁路垫支退款"].ToString()));
                totalmny += totalTmp;
                this.m_objViewer.m_dwShow.Modify("t_tltol.text = '" + strTranslate(totalTmp) + "'");
                this.m_objViewer.m_dwShow.Modify("t_xjs.text = '" + strTranslate(StatisticsRow["实收现金合计"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_xjt.text = '" + strTranslate(StatisticsRow["现金退款"]) + "'");
                totalTmp = Convert.ToDouble(StatisticsRow["实收现金合计"].ToString()) - Math.Abs(Convert.ToDouble(StatisticsRow["现金退款"].ToString()));
                totalmny += totalTmp;
                this.m_objViewer.m_dwShow.Modify("t_xjtol.text = '" + strTranslate(totalTmp) + "'");
                this.m_objViewer.m_dwShow.Modify("t_hks.text = '" + strTranslate(StatisticsRow["汇款存款"]) + "'");
                this.m_objViewer.m_dwShow.Modify("t_hkt.text = '" + strTranslate(StatisticsRow["汇款退款"]) + "'");
                totalTmp = Convert.ToDouble(StatisticsRow["汇款存款"].ToString()) - Math.Abs(Convert.ToDouble(StatisticsRow["汇款退款"].ToString()));
                totalmny += totalTmp;
                this.m_objViewer.m_dwShow.Modify("t_hktol.text = '" + strTranslate(totalTmp) + "'");
                this.m_objViewer.m_dwShow.Modify("totalmny.text = '" + strTranslate(totalmny) + "'");
                Sybase.DataWindow.DataWindowChild dwchild;
                dwchild = this.m_objViewer.m_dwShow.GetChild("dw_1");
                dwchild.Retrieve(dtRecipesumde);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
        }

        #region 公共方法
        /// <summary>
        /// 为0则不显示
        /// </summary>
        /// <param name="objInput"></param>
        /// <returns></returns>
        private string strTranslate(object objInput)
        {
            string strOutput = "";
            if (objInput.ToString().Trim() == "0")
            {
                strOutput = "";
            }
            else
            {
                try
                { strOutput = Convert.ToDouble(objInput).ToString("F2"); }
                catch
                { }
            }
            return strOutput;
        }

        /// <summary>
        /// 记帐金额统计
        /// </summary>
        /// <param name="Flag">1-记帐单记帐 0-无记帐单记帐</param>
        /// <param name="has">无记帐病人身份ID</param>
        /// <param name="dr">数据源</param>
        /// <returns></returns>
        private double dblSbmny(int Flag, System.Collections.Hashtable has, ref DataRow dr)
        {
            double db=0;
            if (dr["acctsum_mny"].ToString() == string.Empty)
                return db;

            if(Flag ==1)
            {
                if (!has.ContainsKey(dr["paytypeid_chr"].ToString()))
                { db = Convert.ToDouble(dr["acctsum_mny"].ToString()); }
            }
            else
            {
                if (has.ContainsKey(dr["paytypeid_chr"].ToString()))
                { db = Convert.ToDouble(dr["acctsum_mny"].ToString()); }
            }
            return db;
        }
        #endregion

        #region 查找数据
        DataTable dthistory = new DataTable();
        public void findhistory()
        {
            string startDate = this.m_objViewer.starDate.Value.ToShortDateString();
            string endDate = this.m_objViewer.EndDate.Value.ToShortDateString();
            string checkMan = "";
            if (this.m_objViewer.isDoctorDean == false)
                checkMan = this.m_objViewer.LoginInfo.m_strEmpID;
            //else
            //{
            //    if (this.m_objViewer.m_cboCheckMan.SelectItemValue != null)
            //        checkMan = this.m_objViewer.m_cboCheckMan.SelectItemValue.ToString();
            //}
            long lngRes = Domain.m_lngGetHistory(startDate, endDate, checkMan, out dthistory);
            this.m_objViewer.ctlDgFind.m_mthDeleteAllRow();
            if (lngRes == 1)
            {
                for (int i1 = 0; i1 < dthistory.Rows.Count; i1++)
                {
                    this.m_objViewer.ctlDgFind.m_mthAppendRow();
                    this.m_objViewer.ctlDgFind[i1, 0] = dthistory.Rows[i1]["BALANCE_DAT"].ToString();
                }
                this.m_objViewer.ctlDgFind.CurrentCell = new DataGridCell(0, 0);
                this.m_objViewer.ctlDgFind.m_mthSelectARow(0);
            }

        }
        #endregion

        #region 结帐
        string checkDate;
        public void CheckData()
        {
            long l = Domain.m_lngCheckData(this.m_objViewer.LoginInfo.m_strEmpID, out checkDate);
            if (l > 0)
            {
                this.m_objViewer.ctlDgFind.m_mthAppendRow();
                this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.RowCount - 1, 0] = checkDate;
                this.m_objViewer.ctlDgFind.m_mthSelectARow(this.m_objViewer.ctlDgFind.RowCount - 1);
                this.dgSelect();
            }
        }
        #endregion
    }
}