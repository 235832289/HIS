using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sybase.DataWindow;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsControlGroupworkloadnew : com.digitalwave.GUI_Base.clsController_Base
    {
        private Transaction m_objTransation;
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmGroupWorkLoadReportNew m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmGroupWorkLoadReportNew)frmMDI_Child_Base_in;
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
        public void m_mthBeginStat()
        {
            string strStatTime = "统计时间:" + this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEnd.Value.ToShortDateString();
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEnd.Value.ToShortDateString() + " 23:59:59";
            string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "门诊专业组收入统计报表";
            if (this.m_objViewer.m_strStatTime == "1")
            {
                m_strTitle += "(按结算时间)";
            }
            else
            {
                m_strTitle += "(按发生时间)";
            }
            string strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balance_dat
                              between to_date ('"+beginDate+@"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('"+endDate+@"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is not null
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 '未定义组' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is null
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)
";
            if (this.m_objViewer.m_cboCheckMan.SelectItemValue != "1000" || this.m_objViewer.m_cboDept.SelectItemValue != "1000")
            {

                if (this.m_objViewer.m_cboCheckMan.SelectItemValue != "1000" && this.m_objViewer.m_cboDept.SelectItemValue == "1000")
                {

                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balanceemp_chr='"+this.m_objViewer.m_cboCheckMan.SelectItemValue+@"'
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is not null
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 '未定义组' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balanceemp_chr='" + this.m_objViewer.m_cboCheckMan.SelectItemValue + @"'
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is null
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)";
                }
                else if (this.m_objViewer.m_cboCheckMan.SelectItemValue == "1000" && this.m_objViewer.m_cboDept.SelectItemValue != "1000")
                {

                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is not null
                       and a.balanceemp_chr=f.empid_chr
                       and f.empid_chr=g.empid_chr
                       and g.deptid_chr=e.deptid_chr
                       and e.deptid_chr='"+this.m_objViewer.m_cboDept.SelectItemValue+@"'
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 '未定义组' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is null
                       and a.balanceemp_chr=f.empid_chr
                       and f.empid_chr=g.empid_chr
                       and g.deptid_chr=e.deptid_chr
                       and e.deptid_chr='" + this.m_objViewer.m_cboDept.SelectItemValue + @"'
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)";
                }
                else if (this.m_objViewer.m_cboCheckMan.SelectItemValue != "1000" && this.m_objViewer.m_cboDept.SelectItemValue != "1000")
                {

                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balanceemp_chr='" + this.m_objViewer.m_cboCheckMan.SelectItemValue + @"'
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is not null
                       and a.balanceemp_chr=f.empid_chr
                       and f.empid_chr=g.empid_chr
                       and g.deptid_chr=e.deptid_chr
                       and e.deptid_chr='" + this.m_objViewer.m_cboDept.SelectItemValue + @"'
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 '未定义组' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.seqid_chr = b.seqid_chr(+)
                       and a.balanceemp_chr='" + this.m_objViewer.m_cboCheckMan.SelectItemValue + @"'
                       and a.balance_dat
                              between to_date ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  and to_date ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                       and a.groupid_chr is null
                       and a.balanceemp_chr=f.empid_chr
                       and f.empid_chr=g.empid_chr
                       and g.deptid_chr=e.deptid_chr
                       and e.deptid_chr='" + this.m_objViewer.m_cboDept.SelectItemValue + @"'
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)";
                }
            }
            if (this.m_objViewer.m_strStatTime=="2")
            {
                strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
            }

            this.m_objViewer.m_dwShow.DataWindowObject = null;
            if (this.m_objViewer.m_strReportStyle == "2")
            {
                this.m_objViewer.m_dwShow.DataWindowObject = "d_op_groupworkloadreportnew";
            }
            else
            {
                this.m_objViewer.m_dwShow.DataWindowObject = "d_op_groupworkloadreportnew1";
            }
            this.m_objViewer.m_dwShow.Modify("t_stattime.text = '" + strStatTime + "'");
            this.m_objViewer.m_dwShow.Modify("t_title.text = '" + m_strTitle + "'");
            this.m_objViewer.m_dwShow.Modify("t_sfy.text = '" + this.m_objViewer.m_cboCheckMan.SelectItemText + "'");
            this.m_objViewer.m_dwShow.Modify("t_tjks.text = '" + this.m_objViewer.m_cboDept.SelectItemText + "'");
            this.m_objViewer.m_dwShow.PrintProperties.Preview = false;
            this.m_objViewer.m_dwShow.SetTransaction(this.m_objTransation);
            this.m_objViewer.m_dwShow.SetRedrawOff();
            this.m_objViewer.m_dwShow.SetSqlSelect(strSQL);
            this.m_objViewer.m_dwShow.Retrieve();
            this.m_objViewer.m_dwShow.CalculateGroups();
            this.m_objViewer.m_dwShow.Refresh();
            this.m_objViewer.m_dwShow.SetRedrawOn();
            this.m_objViewer.m_dwShow.Refresh();
            clsPublic.WriteSQLLog("门诊专业组收入统计报表", strSQL);
            //com.digitalwave.Utility.clsLogText logtxt = new com.digitalwave.Utility.clsLogText();
            //logtxt.Log2File("d:\\code\\log.txt", strSQL);

        }
    }
}
