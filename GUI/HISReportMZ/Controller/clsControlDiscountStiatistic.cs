using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sybase.DataWindow;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
    class clsControlDiscountStiatistic:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数,变量定义
        public frmDiscountStatistic m_objViewer;
        public clsDomainDiscountStatistic m_objDomain;
        private Transaction m_objTransation;
        public clsControlDiscountStiatistic()
        {
            this.m_objDomain = new clsDomainDiscountStatistic();
        }
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDiscountStatistic)frmMDI_Child_Base_in;

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

        #region 取项目列表
        /// <summary>
        /// 取项目列表
        /// </summary>
        /// <returns></returns>
        public int m_GetItem()
        {
            DataTable dt = new DataTable();
            //frmItem objItem = new frmItem();
            string strItem = m_objViewer.txtID.Text.ToUpper().Trim();
            this.m_objDomain.m_GetItem(strItem, out dt);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("抱歉，没有找到对应的项目记录!", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            if (dt.Rows.Count == 1)
            {
                //change 2007.5.8 zhu.w.t
                //m_objViewer.txt_Item.Text = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
                //==================================================================>>
                m_objViewer.txtID.Text = dt.Rows[0]["ITEMCODE_VCHR"].ToString().Trim();
                m_objViewer.txtID.Tag = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
                //m_strItemName = dt.Rows[0]["ITEMCODE_VCHR"].ToString().Trim();
                //<<=================================================================
                m_objViewer.lbID.Text = dt.Rows[0]["ITEMNAME_VCHR"].ToString().Trim();
                return 1;
            }
            else
            {
                frmItem frmItem_view = new frmItem();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    ListViewItem li = new ListViewItem();
                    li.SubItems.Clear();
                    //change 2007.5.8 zhu.w.t
                    //li.SubItems[0].Text = dr["ITEMID_CHR"].ToString();
                    //================================================>>
                    li.SubItems[0].Text = dr["ITEMCODE_VCHR"].ToString();
                    //<<================================================
                    li.SubItems.Add(dr["ITEMNAME_VCHR"].ToString());
                    li.Tag = dr;
                    frmItem_view.m_lsvList.Items.Add(li);
                }

                if (frmItem_view.ShowDialog() == DialogResult.OK)
                {
                    //change 2007.5.8 zhu.w.t
                    //string itemcode = frmItem_view.ItemCode;
                    //=================>>
                    string itemcode = frmItem_view.ItemCode_Vchr;
                    m_objViewer.txtID.Tag = frmItem_view.ItemCode;
                    //<<=====================
                    string itemname = frmItem_view.ItemName;
                    m_objViewer.txtID.Text = itemcode;
                    m_objViewer.lbID.Text = itemname;
                    // MessageBox.Show(itemcode + "  " + itemname);
                }
                else
                {
                    m_objViewer.txtID.Clear();
                    m_objViewer.lbID.Text = string.Empty;
                }

                frmItem_view.Dispose();
            }
            return 1;
        }
        #endregion
        public void m_thBeginStat()
        {
            string strStatTime = "统计时间:" + this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEndTime.Value.ToShortDateString();
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEndTime.Value.ToShortDateString() + " 23:59:59";
            string m_strTitle = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle() + this.m_objViewer.StrReportName + "(" + this.m_objViewer.m_cboStatType.Text + ")";
            string strSQL = @"select b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs,a.tolprice_mny, f.discountmny
                              from t_opr_oprecipeitemde a,
                                   t_bse_chargeitemextype b,
                                   t_bse_chargeitem c,
                                   (select   a.doctorid_chr, a.outpatrecipeid_chr,
                                             sum (case a.status_int
                                                             when 1
                                                                then 1
                                                             when 3
                                                                then 1
                                                             when 2
                                                                then -1
                                                          end
                                                 ) as zfs
                                        from t_opr_outpatientrecipeinv a,
                                             t_opr_reciperelation b,
                                             t_opr_outpatientrecipe c
                                       where a.outpatrecipeid_chr = b.seqid
                                         and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                         and a.balance_dat between to_date ('" + beginDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                                           and to_date ('" + endDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                    group by a.doctorid_chr, a.outpatrecipeid_chr) d,
                                  (select e.empid_chr,e.lastname_vchr,d.deptname_vchr
                                    from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                    where r.deptid_chr = d.deptid_chr
                                    and e.empid_chr = r.empid_chr
                                    and r.default_dept_int = 1
                                            union all
                                            select e2.empid_chr,
                                            e2.lastname_vchr,
                                            '' deptname_vchr
                                            from t_bse_employee e2
                                            where not exists (select ''
                                                                      from t_bse_deptemp r2
                                                                     where r2.empid_chr = e2.empid_chr
                                                                       and r2.default_dept_int = 1)) e,
                            
 							(select a.outpatrecipeid_chr,a.itemid_chr,
							(a.price_mny - a.tolprice_mny)+a.tolprice_mny*(1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec > 0
							and a.qty_dec < 1
							and a.discount_dec > 0
							and a.discount_dec <= 1
							union all
							select a.outpatrecipeid_chr,a.itemid_chr,
							a.tolprice_mny * (1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec >= 1 and a.discount_dec >= 0 and a.discount_dec < 1) f

                             where (a.discount_dec < 1 or a.qty_dec <1) and b.flag_int = 2
                               and a.outpatrecipeid_chr = f.outpatrecipeid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and b.typeid_chr = c.itemopinvtype_chr
                               and a.itemid_chr = c.itemid_chr
                               and a.itemid_chr = f.itemid_chr
                               and d.doctorid_chr = e.empid_chr
                               group by b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs, a.tolprice_mny,  f.discountmny";
            if (this.m_objViewer.txtID.Text != string.Empty)
            {
                strSQL = @"select b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs,a.tolprice_mny,  f.discountmny
                              from t_opr_oprecipeitemde a,
                                   t_bse_chargeitemextype b,
                                   t_bse_chargeitem c,
                                   (select   a.doctorid_chr, a.outpatrecipeid_chr,
                                             sum (case a.status_int
                                                             when 1
                                                                then 1
                                                             when 3
                                                                then 1
                                                             when 2
                                                                then -1
                                                          end
                                                 ) as zfs
                                        from t_opr_outpatientrecipeinv a,
                                             t_opr_reciperelation b,
                                             t_opr_outpatientrecipe c
                                       where a.outpatrecipeid_chr = b.seqid
                                         and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                         and a.balance_dat between to_date ('" + beginDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                                           and to_date ('" + endDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                    group by a.doctorid_chr, a.outpatrecipeid_chr) d,
                                  (select e.empid_chr,e.lastname_vchr,d.deptname_vchr
                                    from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                    where r.deptid_chr = d.deptid_chr
                                    and e.empid_chr = r.empid_chr
                                    and r.default_dept_int = 1
                                            union all
                                            select e2.empid_chr,
                                            e2.lastname_vchr,
                                            '' deptname_vchr
                                            from t_bse_employee e2
                                            where not exists (select ''
                                                                      from t_bse_deptemp r2
                                                                     where r2.empid_chr = e2.empid_chr
                                                                       and r2.default_dept_int = 1)) e,
                            
 							(select a.outpatrecipeid_chr,a.itemid_chr,
							(a.price_mny - a.tolprice_mny)+a.tolprice_mny*(1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec > 0
							and a.qty_dec < 1
							and a.discount_dec > 0
							and a.discount_dec <= 1
							union all
							select a.outpatrecipeid_chr,a.itemid_chr,
							a.tolprice_mny * (1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec >= 1 and a.discount_dec >= 0 and a.discount_dec < 1) f

                             where (a.discount_dec < 1 or a.qty_dec <1) and b.flag_int = 2
                               and c.itemcode_vchr = '" + this.m_objViewer.txtID.Text.Trim() + @"'
                               and a.outpatrecipeid_chr = f.outpatrecipeid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and b.typeid_chr = c.itemopinvtype_chr
                               and a.itemid_chr = c.itemid_chr
                               and a.itemid_chr = f.itemid_chr
                               and d.doctorid_chr = e.empid_chr
                               group by b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs, a.tolprice_mny,  f.discountmny";
            }
            else
            {
                if (this.m_objViewer.m_strStatDocotr != string.Empty)
                {
                    strSQL = @"select b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs,a.tolprice_mny,  f.discountmny
                              from t_opr_oprecipeitemde a,
                                   t_bse_chargeitemextype b,
                                   t_bse_chargeitem c,
                                   (select   a.doctorid_chr, a.outpatrecipeid_chr,
                                             sum (case a.status_int
                                                             when 1
                                                                then 1
                                                             when 3
                                                                then 1
                                                             when 2
                                                                then -1
                                                          end
                                                 ) as zfs
                                        from t_opr_outpatientrecipeinv a,
                                             t_opr_reciperelation b,
                                             t_opr_outpatientrecipe c
                                       where a.outpatrecipeid_chr = b.seqid
                                         and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                         and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
                                         and a.balance_dat between to_date ('" + beginDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                                           and to_date ('" + endDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                    group by a.doctorid_chr, a.outpatrecipeid_chr) d,
                                  (select e.empid_chr,e.lastname_vchr,d.deptname_vchr
                                    from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                    where r.deptid_chr = d.deptid_chr
                                    and e.empid_chr = r.empid_chr
                                    and r.default_dept_int = 1
                                            union all
                                            select e2.empid_chr,
                                            e2.lastname_vchr,
                                            '' deptname_vchr
                                            from t_bse_employee e2
                                            where not exists (select ''
                                                                      from t_bse_deptemp r2
                                                                     where r2.empid_chr = e2.empid_chr
                                                                       and r2.default_dept_int = 1)) e,

 							(select a.outpatrecipeid_chr,a.itemid_chr,
							(a.price_mny - a.tolprice_mny)+a.tolprice_mny*(1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec > 0
							and a.qty_dec < 1
							and a.discount_dec > 0
							and a.discount_dec <= 1
							union all
							select a.outpatrecipeid_chr,a.itemid_chr,
							a.tolprice_mny * (1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec >= 1 and a.discount_dec >= 0 and a.discount_dec < 1) f

                             where (a.discount_dec < 1 or a.qty_dec <1) and b.flag_int = 2
                               and a.outpatrecipeid_chr = f.outpatrecipeid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and b.typeid_chr = c.itemopinvtype_chr
                               and a.itemid_chr = c.itemid_chr
                               and a.itemid_chr = f.itemid_chr
                               and d.doctorid_chr = e.empid_chr
                               group by b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs, a.tolprice_mny, f.discountmny";
                }
                if (this.m_objViewer.m_strDepart != string.Empty)
                {
                    strSQL = @"select b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs,a.tolprice_mny,  f.discountmny
                              from t_opr_oprecipeitemde a,
                                   t_bse_chargeitemextype b,
                                   t_bse_chargeitem c,
                                   (select   a.doctorid_chr, a.outpatrecipeid_chr,a.deptid_chr,
                                             sum (case a.status_int
                                                             when 1
                                                                then 1
                                                             when 3
                                                                then 1
                                                             when 2
                                                                then -1
                                                          end
                                                 ) as zfs
                                        from t_opr_outpatientrecipeinv a,
                                             t_opr_reciperelation b,
                                             t_opr_outpatientrecipe c
                                       where a.outpatrecipeid_chr = b.seqid
                                         and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                         and a.balance_dat between to_date ('" + beginDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                                           and to_date ('" + endDate + @"',
                                                                        'yyyy-mm-dd hh24:mi:ss'
                                                                       )
                                    group by a.doctorid_chr, a.outpatrecipeid_chr,a.deptid_chr) d,
                                  (select e.empid_chr,e.lastname_vchr,d.deptid_chr,d.deptname_vchr
                                    from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                    where r.deptid_chr = d.deptid_chr
                                    and e.empid_chr = r.empid_chr
                                    and r.default_dept_int = 1
                                            union all
                                            select e2.empid_chr,
                                            e2.lastname_vchr,
                                            '' deptid_chr,
                                            '' deptname_vchr
                                            from t_bse_employee e2
                                            where not exists (select ''
                                                                      from t_bse_deptemp r2
                                                                     where r2.empid_chr = e2.empid_chr
                                                                       and r2.default_dept_int = 1)) e,

 							(select a.outpatrecipeid_chr,a.itemid_chr,
							(a.price_mny - a.tolprice_mny)+a.tolprice_mny*(1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec > 0
							and a.qty_dec < 1
							and a.discount_dec > 0
							and a.discount_dec <= 1
							union all
							select a.outpatrecipeid_chr,a.itemid_chr,
							a.tolprice_mny * (1 - a.discount_dec) as discountmny
							from t_opr_oprecipeitemde a
							where a.qty_dec >= 1 and a.discount_dec >= 0 and a.discount_dec < 1) f

                             where (a.discount_dec < 1 or a.qty_dec <1) and b.flag_int = 2
                               and d.deptid_chr= e.deptid_chr
                               and d.deptid_chr in(" + this.m_objViewer.m_strDepart + @")
                               and a.outpatrecipeid_chr = f.outpatrecipeid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and b.typeid_chr = c.itemopinvtype_chr
                               and a.itemid_chr = c.itemid_chr
                               and a.itemid_chr = f.itemid_chr
                               and d.doctorid_chr = e.empid_chr
                               group by b.typename_vchr,e.deptname_vchr,e.lastname_vchr,c.itemcode_vchr, c.itemname_vchr,
                            d.zfs, a.tolprice_mny, f.discountmny";
                }
            }
            if (this.m_objViewer.m_cboStatType.SelectedIndex == 0)
            {
                strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
            }

            this.m_objViewer.dtwindow.DataWindowObject = null;
            this.m_objViewer.dtwindow.DataWindowObject = "d_opdiscountstatistic";
            this.m_objViewer.dtwindow.Modify("t_6.text = '" + strStatTime + "'");
            this.m_objViewer.dtwindow.Modify("t_title.text = '" + m_strTitle + "'");
            this.m_objViewer.dtwindow.PrintProperties.Preview = false;
            this.m_objViewer.dtwindow.SetTransaction(this.m_objTransation);
            this.m_objViewer.dtwindow.SetRedrawOff();
            this.m_objViewer.dtwindow.SetSqlSelect(strSQL);
            this.m_objViewer.dtwindow.Retrieve();
            this.m_objViewer.dtwindow.CalculateGroups();
            this.m_objViewer.dtwindow.Refresh();
            this.m_objViewer.dtwindow.SetRedrawOn();
            this.m_objViewer.dtwindow.Refresh();
            com.digitalwave.Utility.clsLogText logtxt = new com.digitalwave.Utility.clsLogText();
            logtxt.Log2File("d:\\code\\log.txt", strSQL);

            this.m_objViewer.m_strDepart= string.Empty;
            this.m_objViewer.m_strStatDocotr = string.Empty;
            this.m_objViewer.txtID.Text = string.Empty;
            this.m_objViewer.lbID.Text = string.Empty;
        }
        public void m_GetDepartInfo(ref DataTable dtResult)
        {
            this.m_objDomain.m_lngGetDepartInfo(ref dtResult);
        }

        //#region 广医经济收入统计报表（开单科室以及医生身份）2007-11-15
//        public long m_lngDeptEarningCollect(string p_RptID, string p_BeginTime, string p_EndTime, ref DataTable dtResult)
//        {
//            long lngRes = 0;
//            string strStatTime = "统计时间:" + this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEndTime.Value.ToShortDateString();
//            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
//            string endDate = this.m_objViewer.m_datEndTime.Value.ToShortDateString() + " 23:59:59";
//            string m_strTitle = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle() + "门诊打折项目统计报表(" + this.m_objViewer.m_cboStatType.Text + ")";
//            string strSQL = @"select   a.groupid_chr, a.groupname_chr, a.tolfee_mny, a.deptname_vchr,
//         a.lastname_vchr, a.employeeidentity_int,a.zfs,a.type_vchr,
//         b.tolfee_type_mny
//    from (select   a.groupid_chr, a.groupname_chr, a.type_vchr,
//                   a.diagdept_chr, a.deptname_vchr, a.tolfee_mny, b.zfs,
//                   b.empid_chr, b.lastname_vchr, b.employeeidentity_int
//              from (select   a.groupid_chr, a.groupname_chr, a.type_vchr,
//                             h.diagdept_chr, e1.deptname_vchr, a1.empid_chr,
//                             a1.lastname_vchr,
//                             sum (c.tolfee_mny) as tolfee_mny
//                        from t_aid_rpt_gop_def a,
//                             t_aid_rpt_gop_rla b,
//                             t_opr_outpatientrecipesumde c,
//                             t_bse_chargeitemextype d,
//                             t_bse_employee a1,
//                             t_bse_deptemp b1,
//                             t_bse_deptdesc e1,
//                             t_opr_charge f,
//                             t_opr_reciperelation g,
//                             t_opr_outpatientrecipe h
//                       where a.groupid_chr = b.groupid_chr
//                         and b.typeid_chr = c.itemcatid_chr
//                         and c.itemcatid_chr = d.typeid_chr
//                         and c.chargeno_chr = f.chargeno_chr
//                         and e1.deptid_chr = b1.deptid_chr
//                         and a1.empid_chr = b1.empid_chr
//                         and f.chargeno_chr = g.chargeno_chr
//                         and h.outpatrecipeid_chr = g.outpatrecipeid_chr
//                         and h.diagdept_chr = e1.deptid_chr(+)
//                         and h.diagdr_chr = a1.empid_chr(+)
//                         and a.rptid_chr = '0001'
//                         and b.rptid_chr = '0001'
//                         and d.flag_int = 1
//                         and f.recdate_dat
//                                between to_date ('2007-10-01 00:00:00',
//                                                 'yyyy-mm-dd hh24:mi:ss'
//                                                )
//                                    and to_date ('2007-10-19 23:59:59',
//                                                 'yyyy-mm-dd hh24:mi:ss'
//                                                )
//                    group by a.groupid_chr,
//                             a.groupname_chr,
//                             a.type_vchr,
//                             h.diagdept_chr,
//                             e1.deptname_vchr,
//                             a1.empid_chr,
//                             a1.lastname_vchr) a,
//                   (select   e1.deptid_chr, e1.deptname_vchr, a.empid_chr,
//                             a.lastname_vchr,
//                             sum (decode (h.recipeflag_int,
//                                          1, case f.status_int
//                                             when 1
//                                                then 1
//                                             when 2
//                                                then -1
//                                          end,
//                                          0
//                                         )
//                                 ) as zfs,
//                             decode (a.employeeidentity_int,
//                                     '6', '退休',
//                                     '在职'
//                                    ) as employeeidentity_int
//                        from t_bse_employee a,
//                             t_bse_deptemp b,
//                             t_bse_deptdesc e1,
//                             t_opr_charge f,
//                             t_opr_reciperelation g,
//                             t_opr_outpatientrecipe h
//                       where e1.deptid_chr = b.deptid_chr
//                         and a.empid_chr = b.empid_chr
//                         and f.deptid_chr = e1.deptid_chr
//                         and f.chargeno_chr = g.chargeno_chr
//                         and h.outpatrecipeid_chr = g.outpatrecipeid_chr
//                         and h.diagdept_chr = e1.deptid_chr(+)
//                         and h.diagdr_chr = a.empid_chr(+)
//                         and f.recdate_dat
//                                between to_date ('2007-10-01 00:00:00',
//                                                 'yyyy-mm-dd hh24:mi:ss'
//                                                )
//                                    and to_date ('2007-10-19 23:59:59',
//                                                 'yyyy-mm-dd hh24:mi:ss'
//                                                )
//                    group by e1.deptid_chr,
//                             e1.deptname_vchr,
//                             a.empid_chr,
//                             a.lastname_vchr,
//                             employeeidentity_int) b
//             where a.empid_chr = b.empid_chr
//          group by a.groupid_chr,
//                   a.groupname_chr,
//                   a.type_vchr,
//                   a.diagdept_chr,
//                   a.deptname_vchr,
//                   a.tolfee_mny,
//                   b.zfs,
//                   b.empid_chr,
//                   b.lastname_vchr,
//                   b.employeeidentity_int) a,
//                   
//         (select    b.diagdept_chr, b.deptname_vchr, b.empid_chr,
//                   b.lastname_vchr,b.type_vchr, sum (b.tolfee_mny) as tolfee_type_mny
//              from (select   a.groupid_chr, a.groupname_chr, a.type_vchr,
//                             a.diagdept_chr, a.deptname_vchr, a.tolfee_mny,
//                             b.zfs, b.empid_chr, b.lastname_vchr,
//                             b.employeeidentity_int
//                        from (select   a.groupid_chr, a.groupname_chr,
//                                       a.type_vchr, h.diagdept_chr,
//                                       e1.deptname_vchr, a1.empid_chr,
//                                       a1.lastname_vchr,
//                                       sum (c.tolfee_mny) as tolfee_mny
//                                  from t_aid_rpt_gop_def a,
//                                       t_aid_rpt_gop_rla b,
//                                       t_opr_outpatientrecipesumde c,
//                                       t_bse_chargeitemextype d,
//                                       t_bse_employee a1,
//                                       t_bse_deptemp b1,
//                                       t_bse_deptdesc e1,
//                                       t_opr_charge f,
//                                       t_opr_reciperelation g,
//                                       t_opr_outpatientrecipe h
//                                 where a.groupid_chr = b.groupid_chr
//                                   and b.typeid_chr = c.itemcatid_chr
//                                   and c.itemcatid_chr = d.typeid_chr
//                                   and c.chargeno_chr = f.chargeno_chr
//                                   and e1.deptid_chr = b1.deptid_chr
//                                   and a1.empid_chr = b1.empid_chr
//                                   and f.chargeno_chr = g.chargeno_chr
//                                   and h.outpatrecipeid_chr =
//                                                          g.outpatrecipeid_chr
//                                   and h.diagdept_chr = e1.deptid_chr(+)
//                                   and h.diagdr_chr = a1.empid_chr(+)
//                                   and a.rptid_chr = '0001'
//                                   and b.rptid_chr = '0001'
//                                   and d.flag_int = 1
//                                   and f.recdate_dat
//                                          between to_date
//                                                      ('2007-10-01 00:00:00',
//                                                       'yyyy-mm-dd hh24:mi:ss'
//                                                      )
//                                              and to_date
//                                                      ('2007-10-19 23:59:59',
//                                                       'yyyy-mm-dd hh24:mi:ss'
//                                                      )
//                              group by a.groupid_chr,
//                                       a.groupname_chr,
//                                       a.type_vchr,
//                                       h.diagdept_chr,
//                                       e1.deptname_vchr,
//                                       a1.empid_chr,
//                                       a1.lastname_vchr) a,
//                             (select   e1.deptid_chr, e1.deptname_vchr,
//                                       a.empid_chr, a.lastname_vchr,
//                                       sum (decode (h.recipeflag_int,
//                                                    1, case f.status_int
//                                                       when 1
//                                                          then 1
//                                                       when 2
//                                                          then -1
//                                                    end,
//                                                    0
//                                                   )
//                                           ) as zfs,
//                                       decode (a.employeeidentity_int,
//                                               '6', '退休',
//                                               '在职'
//                                              ) as employeeidentity_int
//                                  from t_bse_employee a,
//                                       t_bse_deptemp b,
//                                       t_bse_deptdesc e1,
//                                       t_opr_charge f,
//                                       t_opr_reciperelation g,
//                                       t_opr_outpatientrecipe h
//                                 where e1.deptid_chr = b.deptid_chr
//                                   and a.empid_chr = b.empid_chr
//                                   and f.deptid_chr = e1.deptid_chr
//                                   and f.chargeno_chr = g.chargeno_chr
//                                   and h.outpatrecipeid_chr =
//                                                          g.outpatrecipeid_chr
//                                   and h.diagdept_chr = e1.deptid_chr(+)
//                                   and h.diagdr_chr = a.empid_chr(+)
//                                   and f.recdate_dat
//                                          between to_date
//                                                      ('2007-10-01 00:00:00',
//                                                       'yyyy-mm-dd hh24:mi:ss'
//                                                      )
//                                              and to_date
//                                                      ('2007-10-19 23:59:59',
//                                                       'yyyy-mm-dd hh24:mi:ss'
//                                                      )
//                              group by e1.deptid_chr,
//                                       e1.deptname_vchr,
//                                       a.empid_chr,
//                                       a.lastname_vchr,
//                                       employeeidentity_int) b
//                       where a.empid_chr = b.empid_chr
//                    group by a.groupid_chr,
//                             a.groupname_chr,
//                             a.type_vchr,
//                             a.diagdept_chr,
//                             a.deptname_vchr,
//                             a.tolfee_mny,
//                             b.zfs,
//                             b.empid_chr,
//                             b.lastname_vchr,
//                             b.employeeidentity_int) b
//          group by 
//                   b.diagdept_chr,
//                   b.deptname_vchr,
//                   b.empid_chr,
//                   b.lastname_vchr,b.type_vchr) b
//   where  a.empid_chr = b.empid_chr and a.type_vchr = b.type_vchr
//group by a.groupid_chr,
//         a.groupname_chr,
//         a.tolfee_mny,
//         a.deptname_vchr,
//         a.lastname_vchr,
//         a.employeeidentity_int,
//         a.zfs,
//         a.type_vchr,
//         b.tolfee_type_mny
//";
//            //com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
//            IDataParameter[] objDPArr = null;
//            objDPArr[0].Value = p_BeginTime + "00:00:00";
//            objDPArr[1].Value = p_BeginTime + "23:59:59";
//        }
//        #endregion
    }
}
