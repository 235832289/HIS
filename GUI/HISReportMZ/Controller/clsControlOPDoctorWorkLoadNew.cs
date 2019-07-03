using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsControlOPDoctorWorkLoadNew : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlOPDoctorWorkLoadNew()
        {
            m_objDomain=new clsdomiandoctorworkflow ();
        }
        private Transaction m_objTransation;
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmDocotorWorkLoadNew m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDocotorWorkLoadNew)frmMDI_Child_Base_in;
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
        clsdomiandoctorworkflow m_objDomain;
        public void m_mthFillDept()
        {
            DataTable m_objDeptTable = new DataTable();
            long lngRes = -1;
            lngRes = m_objDomain.m_lngGetOPDeptInfo(out m_objDeptTable);
            this.m_objViewer.m_cboDept.Item.Add("全部", "-1");
            if (lngRes > 0 && m_objDeptTable.Rows.Count > 0)
            {

                for (int i = 0; i < m_objDeptTable.Rows.Count; i++)
                {
                    this.m_objViewer.m_cboDept.Item.Add(m_objDeptTable.Rows[i]["deptname_vchr"].ToString(), m_objDeptTable.Rows[i]["deptid_chr"].ToString());
                }
            }
            this.m_objViewer.m_cboDept.SelectedIndex = 0;
        }
        public void m_mthBeginStat()
        {
            string strStatTime = "统计时间:" + this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEndTime.Value.ToShortDateString();
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEndTime.Value.ToShortDateString() + " 23:59:59";
            string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + this.m_objViewer.StrReportName + "(" + this.m_objViewer.m_cboStatType.Text + ")";
            string strSQL = @"select a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,a.groupname_vchr,
       a.tolfee_mny, b.zfs, b.ffs
  from (select   a.groupid_chr, a.groupname_chr, c.empno_chr,c.diagdr_chr,
                 c.doctorname_chr, sum (c.tolfee_mny) tolfee_mny,nvl(c.groupid, '<未定义>') as groupid,c.groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr,c.diagdr_chr, e.empno_chr, e.lastname_vchr as doctorname_chr,
                 
                 nvl(a.groupid_chr,'<未定义>') as groupid,d.groupname_vchr,
                 
                           sum (b.tolfee_mny) tolfee_mny 
                      from t_opr_charge a,
                           t_opr_reciperelation f,
                           t_opr_outpatientrecipesumde b,
                           t_opr_outpatientrecipe c,
                           t_bse_groupdesc d,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                 where r.deptid_chr = d.deptid_chr
                                   and e.empid_chr = r.empid_chr
                                   and r.default_dept_int = 1
                                union all
                                select e2.empid_chr,
                                       e2.empno_chr,
                                       e2.lastname_vchr,
                                       '' deptid_chr,
                                       '' code_vchr,
                                       '' deptname_vchr
                                  from t_bse_employee e2
                                 where not exists (select ''
                                          from t_bse_deptemp r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.chargeno_chr = f.chargeno_chr(+)
                       and c.outpatrecipeid_chr = f.outpatrecipeid_chr
                       and a.recflag_int = 1
                       and c.diagdr_chr = e.empid_chr(+)
                       
                       and a.groupid_chr = c.groupid_chr(+)
                       and a.groupid_chr = d.groupid_chr(+)
                       
                       and a.recdate_dat
                             between to_date ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   and to_date ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                  group by b.itemcatid_chr,c.diagdr_chr, e.empno_chr, e.lastname_vchr,a.groupid_chr,d.groupname_vchr) c
           where a.groupid_chr = b.groupid_chr
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0005'
             and b.rptid_chr = '0005'
        group by a.groupid_chr, a.groupname_chr, c.empno_chr,c.diagdr_chr,
                 c.doctorname_chr,c.groupid,c.groupname_vchr
        order by a.groupid_chr) a,
          
       (select   c.diagdr_chr,nvl(a.groupid_chr, '<未定义>') as groupid_chr,
                 sum(decode(c.recipeflag_int,1,case a.status_int
                           when 1
                              then 1
                           when 3
                              then 1
                           when 2
                              then -1
                        end
                       ,0)) as zfs,
                       sum(decode(c.recipeflag_int,2,case a.status_int
                           when 1
                              then 1
                           when 3
                              then 1
                           when 2
                              then -1
                        end
                       ,0)) as ffs
            from t_opr_outpatientrecipeinv a,
                 t_opr_chargedefinv b,
                 t_opr_charge d,
                 t_opr_reciperelation f,
                 t_opr_outpatientrecipe c
where a.invoiceno_vchr = b.invoiceno_vchr
and d.chargeno_chr = b.chargeno_chr
and d.chargeno_chr = f.chargeno_chr
and c.outpatrecipeid_chr = f.outpatrecipeid_chr
             and d.recdate_dat  between to_date ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   and to_date ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        group by c.diagdr_chr,a.groupid_chr) b
 where a.diagdr_chr = b.diagdr_chr(+) and a.groupid = b.groupid_chr";
           if (this.m_objViewer.m_strStatDocotr != string.Empty)
           {
               strSQL = @"select a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,a.groupname_vchr,
       a.tolfee_mny, b.zfs, b.ffs
  from (select   a.groupid_chr, a.groupname_chr, c.empno_chr,c.diagdr_chr,
                 c.doctorname_chr, sum (c.tolfee_mny) tolfee_mny,nvl(c.groupid, '<未定义>') as groupid,c.groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr,c.diagdr_chr, e.empno_chr, e.lastname_vchr as doctorname_chr,
                 
                 nvl(a.groupid_chr,'<未定义>') as groupid,d.groupname_vchr,
                 
                           sum (b.tolfee_mny) tolfee_mny 
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b,
                           t_opr_reciperelation f,
                           t_opr_outpatientrecipe c,
                           t_bse_groupdesc d,
                           
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                 where r.deptid_chr = d.deptid_chr
                                   and e.empid_chr = r.empid_chr
                                   and r.default_dept_int = 1
                                union all
                                select e2.empid_chr,
                                       e2.empno_chr,
                                       e2.lastname_vchr,
                                       '' deptid_chr,
                                       '' code_vchr,
                                       '' deptname_vchr
                                  from t_bse_employee e2
                                 where not exists (select ''
                                          from t_bse_deptemp r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recflag_int = 1
                       and a.chargeno_chr = f.chargeno_chr(+)
                       and c.outpatrecipeid_chr = f.outpatrecipeid_chr
                       and c.diagdr_chr = e.empid_chr(+)
                       
                       and a.groupid_chr = c.groupid_chr(+)
                       and a.groupid_chr = d.groupid_chr(+)
                       and c.diagdr_chr in (" + this.m_objViewer.m_strStatDocotr + @")
                       and a.recdate_dat
                            between to_date ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   and to_date ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                  group by b.itemcatid_chr,c.diagdr_chr, e.empno_chr, e.lastname_vchr,a.groupid_chr,d.groupname_vchr) c
           where a.groupid_chr = b.groupid_chr
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0005'
             and b.rptid_chr = '0005'
        group by a.groupid_chr, a.groupname_chr, c.empno_chr,c.diagdr_chr,
                 c.doctorname_chr,c.groupid,c.groupname_vchr
        order by a.groupid_chr) a,
          
       (select   c.diagdr_chr,nvl(a.groupid_chr, '<未定义>') as groupid_chr,
                 sum(decode(c.recipeflag_int,1,case a.status_int
                           when 1
                              then 1
                           when 3
                              then 1
                           when 2
                              then -1
                        end
                       ,0)) as zfs,
                       sum(decode(c.recipeflag_int,2,case a.status_int
                           when 1
                              then 1
                           when 3
                              then 1
                           when 2
                              then -1
                        end
                       ,0)) as ffs
            from t_opr_outpatientrecipeinv a,
                 t_opr_chargedefinv b,
                 t_opr_charge d,
                 t_opr_reciperelation f,
                 t_opr_outpatientrecipe c
where a.invoiceno_vchr = b.invoiceno_vchr
and d.chargeno_chr = b.chargeno_chr
and d.chargeno_chr = f.chargeno_chr
and c.outpatrecipeid_chr = f.outpatrecipeid_chr
             and c.diagdr_chr in (" + this.m_objViewer.m_strStatDocotr + @")
             and d.recdate_dat between to_date ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   and to_date ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        group by c.diagdr_chr,a.groupid_chr) b
 where a.diagdr_chr = b.diagdr_chr(+) and a.groupid = b.groupid_chr";
           }
           if (this.m_objViewer.groupid != string.Empty)
           {
               strSQL = @"select a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,a.groupname_vchr,
       a.tolfee_mny, b.zfs, b.ffs
  from (select   a.groupid_chr, a.groupname_chr, c.empno_chr,c.diagdr_chr,
                 c.doctorname_chr, sum (c.tolfee_mny) tolfee_mny,nvl(c.groupid, '<未定义>') as groupid,c.groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr,c.diagdr_chr, e.empno_chr, e.lastname_vchr as doctorname_chr,
                 
                 nvl(a.groupid_chr,'<未定义>') as groupid,d.groupname_vchr,
                 
                           sum (b.tolfee_mny) tolfee_mny 
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b,
                           t_opr_reciperelation f,
                           t_opr_outpatientrecipe c,
                           t_bse_groupdesc d,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                 where r.deptid_chr = d.deptid_chr
                                   and e.empid_chr = r.empid_chr
                                   and r.default_dept_int = 1
                                union all
                                select e2.empid_chr,
                                       e2.empno_chr,
                                       e2.lastname_vchr,
                                       '' deptid_chr,
                                       '' code_vchr,
                                       '' deptname_vchr
                                  from t_bse_employee e2
                                 where not exists (select ''
                                          from t_bse_deptemp r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recflag_int = 1
                       and a.chargeno_chr = f.chargeno_chr(+)
                       and c.outpatrecipeid_chr = f.outpatrecipeid_chr
                       and c.diagdr_chr = e.empid_chr(+)                       
                       and a.groupid_chr = c.groupid_chr(+)
                       and a.groupid_chr = d.groupid_chr(+)
                       and a.groupid_chr in (" + this.m_objViewer.groupid + @")
                       and a.recdate_dat
                            between to_date ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   and to_date ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                  group by b.itemcatid_chr,c.diagdr_chr, e.empno_chr, e.lastname_vchr,a.groupid_chr,d.groupname_vchr) c
           where a.groupid_chr = b.groupid_chr
             and b.typeid_chr = c.itemcatid_chr
             and a.rptid_chr = '0005'
             and b.rptid_chr = '0005'
        group by a.groupid_chr, a.groupname_chr, c.empno_chr,c.diagdr_chr,
                 c.doctorname_chr,c.groupid,c.groupname_vchr
        order by a.groupid_chr) a,
          
        (select   c.diagdr_chr,nvl(a.groupid_chr, '<未定义>') as groupid_chr,
                 sum(decode(c.recipeflag_int,1,case a.status_int
                           when 1
                              then 1
                           when 3
                              then 1
                           when 2
                              then -1
                        end
                       ,0)) as zfs,
                       sum(decode(c.recipeflag_int,2,case a.status_int
                           when 1
                              then 1
                           when 3
                              then 1
                           when 2
                              then -1
                        end
                       ,0)) as ffs
            from t_opr_outpatientrecipeinv a,
                 t_opr_chargedefinv b,
                 t_opr_charge d,
                 t_opr_reciperelation f,
                 t_opr_outpatientrecipe c
where a.invoiceno_vchr = b.invoiceno_vchr
and d.chargeno_chr = b.chargeno_chr
and d.chargeno_chr = f.chargeno_chr
and c.outpatrecipeid_chr = f.outpatrecipeid_chr
             and a.groupid_chr in (" + this.m_objViewer.groupid + @")
             and d.recdate_dat between to_date ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   and to_date ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        group by c.diagdr_chr,a.groupid_chr) b
 where a.diagdr_chr = b.diagdr_chr(+) and a.groupid = b.groupid_chr";
           }
           if (this.m_objViewer.m_cboStatType.SelectedIndex == 0)
           {
               strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
           }

                this.m_objViewer.m_dwShow.DataWindowObject = null;
                this.m_objViewer.m_dwShow.DataWindowObject = "d_opdoctorworkloadnewagain";
                this.m_objViewer.m_dwShow.Modify("t_stattime.text = '" + strStatTime + "'");
                this.m_objViewer.m_dwShow.Modify("t_title.text = '" + m_strTitle + "'");
                this.m_objViewer.m_dwShow.PrintProperties.Preview = false;
                this.m_objViewer.m_dwShow.SetTransaction(this.m_objTransation);
                this.m_objViewer.m_dwShow.SetRedrawOff();
                this.m_objViewer.m_dwShow.SetSqlSelect(strSQL);
                this.m_objViewer.m_dwShow.Retrieve();
                this.m_objViewer.m_dwShow.CalculateGroups();
                this.m_objViewer.m_dwShow.Refresh();
                this.m_objViewer.m_dwShow.SetRedrawOn();
                this.m_objViewer.m_dwShow.Refresh();
                com.digitalwave.Utility.clsLogText logtxt = new com.digitalwave.Utility.clsLogText();
                logtxt.Log2File("d:\\code\\log.txt", strSQL);

                this.m_objViewer.groupid = string.Empty;
                this.m_objViewer.m_strStatDocotr = string.Empty;
        }
        public void m_mthBeginStatByDept()
        {
            string strStatTime = "统计时间:" + this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEndTime.Value.ToShortDateString();
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEndTime.Value.ToShortDateString() + " 23:59:59";
            string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "门诊医生工作量统计报表(" + this.m_objViewer.m_cboStatType.Text + ")";
            string strSQL = @"select c.deptid_chr,c.deptname_chr,a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a,
                   t_opr_outpatientrecipesumde b
             where a.seqid_chr = b.seqid_chr(+)
               and a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
          group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
order by c.deptname_chr,a.groupname_chr";
            if (this.m_objViewer.m_cboDept.SelectItemValue != "-1")
            {
                strSQL = @"select c.deptid_chr,c.deptname_chr,a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a,
                   t_opr_outpatientrecipesumde b
             where a.seqid_chr = b.seqid_chr(+)
               and a.deptid_chr='" + this.m_objViewer.m_cboDept.SelectItemValue + @"'
               and a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
          group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
order by c.deptname_chr,a.groupname_chr";
            }
            if (this.m_objViewer.m_cboStatType.SelectedIndex == 0)
            {
                strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
            }

            this.m_objViewer.m_dwShow.DataWindowObject = null;
            this.m_objViewer.m_dwShow.DataWindowObject = "d_op_docotorworkbydept";
            this.m_objViewer.m_dwShow.Modify("t_stattime.text = '" + strStatTime + "'");
            this.m_objViewer.m_dwShow.Modify("t_title.text = '" + m_strTitle + "'");
            this.m_objViewer.m_dwShow.PrintProperties.Preview = false;
            this.m_objViewer.m_dwShow.SetTransaction(this.m_objTransation);
            this.m_objViewer.m_dwShow.SetRedrawOff();
            this.m_objViewer.m_dwShow.SetSqlSelect(strSQL);
            this.m_objViewer.m_dwShow.Retrieve();
            this.m_objViewer.m_dwShow.CalculateGroups();
            this.m_objViewer.m_dwShow.Refresh();
            this.m_objViewer.m_dwShow.SetRedrawOn();
            this.m_objViewer.m_dwShow.Refresh();
            com.digitalwave.Utility.clsLogText logtxt = new com.digitalwave.Utility.clsLogText();
            logtxt.Log2File("d:\\code\\log.txt", strSQL);

        }
    }
}
