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
    class clsCtlCheckOutOfDayNewAuto : com.digitalwave.GUI_Base.clsController_Base
    {
        public string[] m_strInvoArr = null;
        DataTable dtCheckOut = new DataTable();
        DataTable dtPayType = new DataTable();
        clsDomainControl_RegisterAuto m_objDomain = new clsDomainControl_RegisterAuto();
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
        string hospitalNo = "";
        /// <summary>
        /// 医保身份id
        /// </summary>
        public System.Collections.Generic.List<string> lstYbPayTypeid = null;
        /// <summary>
        /// 茶山特殊门诊身份id
        /// </summary>
        public System.Collections.Generic.List<string> lstSpecialOpTypeid = null;
        /// <summary>
        /// 茶山特殊门诊退休养老身份id
        /// </summary>
        public System.Collections.Generic.List<string> lstSpecOpRetiredid = null;

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmCheckOutOfDayNewAuto m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCheckOutOfDayNewAuto)frmMDI_Child_Base_in;
        }
        #endregion

        internal void GetData()
        {
            if (this.m_objViewer.m_rptId == null || this.m_objViewer.m_rptId == "")
            {
                MessageBox.Show("报表的Id号为空，请从功能菜单传入报表Id号。");
                return;
            }
            
            strCheckManID = this.m_objViewer.LoginInfo.m_strEmpID;
            hospitalNo = this.m_objComInfo.m_mthGetHospitalNo();
            string strPatientPayTypeID = string.Empty;

            arrReList.Clear();
            SaveINVOICENO.Clear();
            this.dtCheckOut = null;

            if (intcomand == 0)
            {
                com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
                string checkDate = HisBase.s_GetServerDate().ToString();
                m_objDomain.GetCheckOutData(strCheckManID, checkDate, this.m_objViewer.m_rptId, out dtCheckOut);
                m_objDomain.m_mthGetbalancerepeatinvoinfo(strCheckManID, checkDate, out this.m_strInvoArr, intcomand);
                strCheckDate = checkDate;
                this.m_objViewer.btnPrint.Enabled = false;
            }
            else
            {
                strCheckDate = this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.CurrentCell.RowNumber, 0].ToString();
                string BALANCEEMP = this.m_objViewer.LoginInfo.m_strEmpID;
                m_objDomain.GetCheckOutHistory(strCheckDate, strCheckManID, this.m_objViewer.m_rptId, out dtCheckOut);
                m_objDomain.m_mthGetbalancerepeatinvoinfo(strCheckManID, strCheckDate, out this.m_strInvoArr, intcomand);
                this.m_objViewer.btnCheck.Enabled = false;
                this.m_objViewer.btnPrint.Enabled = true;
            }

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
            dtStatistics.Columns.Add("社保预计费记账");
            dtStatistics.Columns.Add("特定门诊记账");
            dtStatistics.Columns.Add("门诊社保记账");
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
            StatisticsRow["社保预计费记账"] = 0;
            StatisticsRow["特定门诊记账"] = 0;
            StatisticsRow["门诊社保记账"] = 0;
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
                            StatisticsRow["开票数"] = Convert.ToInt16(StatisticsRow["开票数"].ToString()) + 1;
                            StatisticsRow["开票金额"] = Convert.ToDouble(StatisticsRow["开票金额"].ToString()) + Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["开票数"] = Convert.ToInt16(StatisticsRow["开票数"].ToString()) + 1;
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
                            StatisticsRow["退票数"] = Convert.ToInt16(StatisticsRow["退票数"].ToString()) + 1;
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
                                StatisticsRow["退票数"] = Convert.ToInt16(StatisticsRow["退票数"].ToString()) + 1;
                                StatisticsRow["退票金额合计"] = Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()) - Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
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
                            StatisticsRow["恢复票数"] = Convert.ToInt16(StatisticsRow["恢复票数"].ToString()) + 1;
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
                                StatisticsRow["恢复票数"] = Convert.ToInt16(StatisticsRow["恢复票数"].ToString()) + 1;
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
                            StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["支票金额合计"] = Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                            }
                        }

                    }
                    //------------------

                    //社保预计费记账
                    #region 社保预计费记账
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() == "4")//社保预计费
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["社保预计费记账"] = Convert.ToDouble(StatisticsRow["社保预计费记账"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["社保预计费记账"] = Convert.ToDouble(StatisticsRow["社保预计费记账"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }

                        //自负现金要加到 "实收现金"
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
                    #endregion
                    //------------------

                    strPatientPayTypeID = dtCheckOut.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                    //特定门诊记账
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() != "4" && (lstSpecialOpTypeid.Contains(dtCheckOut.Rows[i1]["paytypeid_chr"].ToString().Trim()) || lstSpecOpRetiredid.Contains(dtCheckOut.Rows[i1]["paytypeid_chr"].ToString().Trim())))
                    {
                        if (i1 == 0)
                        {
                            string strTemp = StatisticsRow["特定门诊记账"].ToString().Trim();
                            StatisticsRow["特定门诊记账"] = Convert.ToDouble(StatisticsRow["特定门诊记账"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                string strTemp = StatisticsRow["特定门诊记账"].ToString().Trim();
                                StatisticsRow["特定门诊记账"] = Convert.ToDouble(StatisticsRow["特定门诊记账"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }
                    //------------------

                    //门诊社保记账
                    if (dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim() != "4" && lstYbPayTypeid.Contains(dtCheckOut.Rows[i1]["paytypeid_chr"].ToString().Trim()) && !lstSpecialOpTypeid.Contains(dtCheckOut.Rows[i1]["paytypeid_chr"].ToString().Trim()) && !lstSpecOpRetiredid.Contains(dtCheckOut.Rows[i1]["paytypeid_chr"].ToString().Trim()))
                    {
                        if (i1 == 0)
                        {
                            StatisticsRow["门诊社保记账"] = Convert.ToDouble(StatisticsRow["门诊社保记账"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                string strTemp = StatisticsRow["门诊社保记账"].ToString().Trim();
                                StatisticsRow["门诊社保记账"] = Convert.ToDouble(StatisticsRow["门诊社保记账"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
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
            
            int row;

            #region 有效发票明细
            row = this.m_objViewer.m_dwShow.InsertRow(0);
            this.m_objViewer.m_dwShow.SetItemString(row, "row_head", "起止发票号码：");
            string startNo = "";
            string invoiceNo = "";
            int invoiceCount = 0; //发票张数

            if (this.arrList != null && this.arrList.Count > 0)
            {
                startNo = this.arrList[0].ToString();
                
                string strTemp;
                //int ivcountTemp = 0; //记录数,指示换行
                decimal partsum = 0; //分段发票合计金额
                DataRow[] drPartArr = null;

                for (int i = 0; i < this.arrList.Count; i++)
                {
                    invoiceCount++;
                    strTemp = this.arrList[i].ToString();
                    drPartArr = dtCheckOut.Select("invoiceno_vchr = '" + strTemp + "'");
                    if (drPartArr.Length > 0)
                        partsum += clsPublic.ConvertObjToDecimal(drPartArr[0]["totalsum_mny"]);

                    if (strTemp == ",")
                    {
                        //ivcountTemp++;
                        //if (ivcountTemp == 2)
                        //{
                        //    invoiceNo += startNo + " - " + this.arrList[i - 1].ToString() + "(" + partsum + ") \r";
                        //    ivcountTemp = 0;
                        //}
                        //else
                        //{
                        invoiceNo += startNo + " - " + this.arrList[i - 1].ToString() + "(￥" + partsum + "), ";
                        //}
                        partsum = 0; //输出后清零
                        invoiceCount--;

                        if (i != this.arrList.Count - 1)
                        {
                            startNo = this.arrList[i + 1].ToString();
                        }
                    }
                    else if (i == this.arrList.Count - 1)
                    {
                        invoiceNo += startNo + " - " + this.arrList[i].ToString() + "(￥" + partsum + ")";
                    }
                }

                this.m_objViewer.m_dwShow.SetItemString(row, "invoice_no", invoiceNo);
                this.m_objViewer.m_dwShow.SetItemString(row, "invoice_count", "张数：" + invoiceCount.ToString());
             
            }
            #endregion 

            this.m_objViewer.m_dwShow.Modify("sum_total.text = '￥" + StatisticsRow["开票金额"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_reimbursement.text = '￥" + StatisticsRow["退票金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_recover.text = '￥" + StatisticsRow["恢复金额合计"].ToString()+ "'");
            this.m_objViewer.m_dwShow.Modify("sum_real.text = '￥" + StatisticsRow["实收金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("count_real.text = '" + StatisticsRow["有效票数"].ToString() + "'");
            
            float tolMoney = float.Parse(StatisticsRow["实收金额合计"].ToString());
            string strMoney = clsMain.CurrencyToString(Math.Abs(tolMoney));
            this.m_objViewer.m_dwShow.Modify("sum_realupper.text = '" + strMoney + "'");

            double acctSum = Convert.ToDouble(StatisticsRow["公费记账金额"].ToString())
                             + Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString())
                             + Convert.ToDouble(StatisticsRow["特困记帐"].ToString())
                             + Convert.ToDouble(StatisticsRow["离休记帐"].ToString())
                             + Convert.ToDouble(StatisticsRow["本院记帐"].ToString());
                             //+ Convert.ToDouble(StatisticsRow["其它金额合计"].ToString());

            this.m_objViewer.m_dwShow.Modify("sum_cash.text = '￥" + StatisticsRow["实收现金合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_ic.text = '￥" + StatisticsRow["IC卡金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_bankcard.text = '￥" + StatisticsRow["刷卡金额合计"].ToString() + "'");
            //this.m_objViewer.m_dwShow.Modify("sum_acct.text = '￥" + acctSum.ToString("0.00") + "'");
            //this.m_objViewer.m_dwShow.Modify("sum_acctspes.text = '￥" + StatisticsRow["医保记账金额"].ToString() + "'");
            //this.m_objViewer.m_dwShow.Modify("sum_other.text = '￥" + StatisticsRow["支票金额合计"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("sum_acct.text = '￥" + StatisticsRow["社保预计费记账"].ToString() + "'");
            //this.m_objViewer.m_dwShow.Modify("sum_acctspes.text = '￥" + StatisticsRow["特定门诊记账"].ToString() + "'");
            //把特定门诊记账金额统计到门诊社保记账，2010-01-18茶山要求。
            this.m_objViewer.m_dwShow.Modify("sum_acctspes.text = '￥" + 0 + "'");
            double dblTempSum_Other = Convert.ToDouble(StatisticsRow["门诊社保记账"].ToString().Trim()) + Convert.ToDouble(StatisticsRow["特定门诊记账"].ToString().Trim());
            this.m_objViewer.m_dwShow.Modify("sum_other.text = '￥" + dblTempSum_Other.ToString() + "'");

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
            this.m_objViewer.m_dwShow.Modify("t_reimbursementinv.text = '" + temp + "'");

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
            this.m_objViewer.m_dwShow.Modify("t_recoverinv.text = '" + temp + "'");

            this.m_objViewer.m_dwShow.Modify("count_reimbursement.text = '" + StatisticsRow["退票数"].ToString() + "'");
            this.m_objViewer.m_dwShow.Modify("count_recover.text = '" + StatisticsRow["恢复票数"].ToString() + "'");

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
            this.m_objViewer.m_dwShow.Modify("count_reprint.text = '" + countTemp + "'");
            this.m_objViewer.m_dwShow.Modify("t_reprintinv.text = '" + temp + "'");

            this.m_objViewer.m_dwShow.Modify("t_yyname.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
            this.m_objViewer.m_dwShow.Modify("t_date.text = '" + Convert.ToDateTime(this.strCheckDate).ToShortDateString() + "'");
            this.m_objViewer.m_dwShow.Modify("t_dept.text = '" + this.m_objViewer.LoginInfo.m_strdepartmentName + "'");
            this.m_objViewer.m_dwShow.Modify("t_operator.text = '" + this.m_objViewer.LoginInfo.m_strEmpName + "'");

            #region 填充收费类型数据
            if (dtCheckOut.Rows.Count > 0)
            {
                DataView dv = new DataView(dtCheckOut);
                string code;
                string name;
                double tempMoney;

                for (int i1 = 1; i1 < 13; i1++)
                {
                    code = i1.ToString().PadLeft(4,'0');
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

        #region 结帐
        string checkDate;
        internal void CheckData()
        {
            long l = this.m_objDomain.m_lngCheckData(this.m_objViewer.LoginInfo.m_strEmpID, out checkDate);
            if (l > 0)
            {
                this.m_objViewer.ctlDgFind.m_mthAppendRow(); 
                int intRowIndex = m_objViewer.ctlDgFind.RowCount - 1;
                this.m_objViewer.ctlDgFind[intRowIndex, 0] = checkDate;
                //this.m_objViewer.ctlprintShow2.setDocument = this.m_objViewer.printDocument1;
                this.m_objViewer.ctlDgFind.m_mthSelectARow(intRowIndex);
                this.m_objViewer.btnCheck.Enabled = false;
                this.m_objViewer.btnPrint.Enabled = true;
                //选择最后有结账记录
                this.m_objViewer.ctlDgFind.CurrentCell = new DataGridCell(intRowIndex, 0);
            }
        }
        #endregion

        internal void dgSelect()
        {
            this.intcomand = 1;
            GetData();
        }
        
        #region 查找数据
		DataTable dthistory=new DataTable();
        internal void FindHistory()
        {
			string startDate=this.m_objViewer.starDate.Value.ToShortDateString();
			string endDate=this.m_objViewer.EndDate.Value.ToShortDateString();
			string checkMan;
			
		    checkMan=this.m_objViewer.LoginInfo.m_strEmpID;
			
			long lngRes = this.m_objDomain.m_lngGetHistory(startDate,endDate,checkMan,out dthistory);
			this.m_objViewer.ctlDgFind.m_mthDeleteAllRow();
			if(lngRes==1)
			{
				for(int i1=0;i1<dthistory.Rows.Count;i1++)
				{
					this.m_objViewer.ctlDgFind.m_mthAppendRow();
					this.m_objViewer.ctlDgFind[i1,0]=dthistory.Rows[i1]["BALANCE_DAT"].ToString();
				}
				this.m_objViewer.ctlDgFind.CurrentCell=new DataGridCell(0,0);
				this.m_objViewer.ctlDgFind.m_mthSelectARow(0);
			}

		}
		#endregion

        internal void Reset()
        {
            this.m_objViewer.m_dwShow.Modify("datawindow.print.preview=yes datawindow.print.preview.rulers=yes");
            this.intcomand = 0;
            GetData();
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        public void m_mthGetParameters()
        {
            Hashtable hasParamValue = null;
            string[] strParamKeyArr = new string[] { "0001", "0069", "0073" };
            com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc));
            objSvc.m_lngGetSysparm(strParamKeyArr, out hasParamValue);
            string[] strTypeid = null;
            if (hasParamValue.ContainsKey("0001"))
            {
                strTypeid = hasParamValue["0001"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (strTypeid == null || strTypeid.Length == 0)
                {
                    lstYbPayTypeid = new System.Collections.Generic.List<string>();
                }
                else
                {
                    lstYbPayTypeid = new System.Collections.Generic.List<string>(strTypeid);
                }
            }
            if (hasParamValue.ContainsKey("0069"))
            {
                strTypeid = hasParamValue["0069"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (strTypeid == null || strTypeid.Length == 0)
                {
                    lstSpecialOpTypeid = new System.Collections.Generic.List<string>();
                }
                else
                {
                    lstSpecialOpTypeid = new System.Collections.Generic.List<string>(strTypeid);
                }
            }
            if (hasParamValue.ContainsKey("0073"))
            {
                strTypeid = hasParamValue["0073"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (strTypeid == null || strTypeid.Length == 0)
                {
                    lstSpecOpRetiredid = new System.Collections.Generic.List<string>();
                }
                else
                {
                    lstSpecOpRetiredid = new System.Collections.Generic.List<string>(strTypeid);
                }
            }
        }
    }
}
