using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsControlOPDoctorWorkLoadNew : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlOPDoctorWorkLoadNew()
        {
            m_objDomain = new clsdomiandoctorworkflow();
        }
        private Transaction m_objTransation;
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmDocotorWorkLoadNew m_objViewer;
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
            this.m_objViewer.m_cboDept.Item.Add("全院", "-1");
            this.m_objViewer.m_cboDept.Item.Add("大院", "0");
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
            string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "门诊医生工作量统计报表(" + this.m_objViewer.m_cboStatType.Text + ")";
            string strSQL = @"SELECT a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,
       a.tolfee_mny, b.zfs, c.ffs
  FROM (SELECT   a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr, SUM (c.tolfee_mny) tolfee_mny
            FROM t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (SELECT   b.itemcatid_chr,a.doctorid_chr, e.empno_chr, e.lastname_vchr as doctorname_chr,
                           SUM (b.tolfee_mny) tolfee_mny
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, T_BSE_DEPTEMP r, T_bse_DeptDesc d
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
                                          from T_BSE_DEPTEMP r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     WHERE a.seqid_chr = b.seqid_chr(+)
                       AND a.doctorid_chr = e.empid_chr(+)
                       [Replace] 
                       AND a.balance_dat
                              BETWEEN TO_DATE ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                        and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                  GROUP BY b.itemcatid_chr,a.doctorid_chr, e.empno_chr, e.lastname_vchr) c
           WHERE a.groupid_chr = b.groupid_chr
             AND b.typeid_chr = c.itemcatid_chr
             AND a.rptid_chr = '0005'
             AND b.rptid_chr = '0005'
        GROUP BY a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr
        ORDER BY a.groupid_chr) a,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS zfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 1
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
             and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) b,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS ffs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 2
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
            and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) c
 WHERE a.doctorid_chr = b.doctorid_chr(+) AND a.doctorid_chr = c.doctorid_chr(+)
union all 
SELECT a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,
       a.tolfee_mny, b.zfs, c.ffs
  FROM (SELECT  '9999'as groupid_chr, '让利费' as groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr, SUM (c.tolfee_mny) tolfee_mny
            FROM 
                 (SELECT   a.doctorid_chr, e.empno_chr, e.lastname_vchr as doctorname_chr,
                           SUM (a.TOTALDIFFCOST_MNY)*(-1) tolfee_mny
                      FROM t_opr_outpatientrecipeinv a,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, T_BSE_DEPTEMP r, T_bse_DeptDesc d
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
                                          from T_BSE_DEPTEMP r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     WHERE a.doctorid_chr = e.empid_chr(+)
                       [Replace] 
                       AND a.balance_dat
                              BETWEEN TO_DATE ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                        and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                  GROUP BY a.doctorid_chr, e.empno_chr, e.lastname_vchr) c
        GROUP BY c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr) a,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS zfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 1
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
             and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) b,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS ffs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 2
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
            and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) c
 WHERE a.doctorid_chr = b.doctorid_chr(+) AND a.doctorid_chr = c.doctorid_chr(+)";
            if (this.m_objViewer.m_strStatDocotr != string.Empty)
            {
                strSQL = @"SELECT a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,
       a.tolfee_mny, b.zfs, c.ffs
  FROM (SELECT   a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr, SUM (c.tolfee_mny) tolfee_mny
            FROM t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (SELECT   b.itemcatid_chr,a.doctorid_chr, e.empno_chr,e.lastname_vchr as doctorname_chr,
                           SUM (b.tolfee_mny) tolfee_mny
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, T_BSE_DEPTEMP r, T_bse_DeptDesc d
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
                                          from T_BSE_DEPTEMP r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     WHERE a.seqid_chr = b.seqid_chr(+)
                       AND a.doctorid_chr = e.empid_chr(+)
                       and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
                       [Replace] 
                       AND a.balance_dat
                              BETWEEN TO_DATE ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                        and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                  GROUP BY b.itemcatid_chr,a.doctorid_chr, e.empno_chr, e.lastname_vchr) c
           WHERE a.groupid_chr = b.groupid_chr
             AND b.typeid_chr = c.itemcatid_chr
             AND a.rptid_chr = '0005'
             AND b.rptid_chr = '0005'
        GROUP BY a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr
        ORDER BY a.groupid_chr) a,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS zfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 1
             and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
             and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) b,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS ffs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 2
             and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
             and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) c
 WHERE a.doctorid_chr = b.doctorid_chr(+) AND a.doctorid_chr = c.doctorid_chr(+)
union all 
SELECT a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,
       a.tolfee_mny, b.zfs, c.ffs
  FROM (SELECT  '9999'as groupid_chr, '让利费' as groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr, SUM (c.tolfee_mny)*(-1) tolfee_mny
            FROM  (SELECT  b.itemcatid_chr, a.doctorid_chr, e.empno_chr,e.lastname_vchr as doctorname_chr,
                           SUM (b.tolfee_mny) tolfee_mny
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b, 
                           (select e.empid_chr,
                                       e.empno_chr,
                                       e.lastname_vchr,
                                       r.deptid_chr,
                                       d.code_vchr,
                                       d.deptname_vchr
                                  from t_bse_employee e, T_BSE_DEPTEMP r, T_bse_DeptDesc d
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
                                          from T_BSE_DEPTEMP r2
                                         where r2.empid_chr = e2.empid_chr
                                           and r2.default_dept_int = 1)) e
                     WHERE a.doctorid_chr = e.empid_chr(+)
                       and a.seqid_chr = b.seqid_chr(+)  
                       and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
                       [Replace] 
                       AND a.balance_dat
                              BETWEEN TO_DATE ('" + beginDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE ('" + endDate + @"',
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                        and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                  GROUP BY b.itemcatid_chr, a.doctorid_chr, e.empno_chr, e.lastname_vchr) c
        GROUP BY c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr) a,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS zfs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 1
             and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
             and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) b,
       (SELECT   a.doctorid_chr,
                 sum(CASE a.status_int
                           WHEN 1
                              THEN 1
                           WHEN 3
                              THEN 1
                           WHEN 2
                              THEN -1
                        END
                       ) AS ffs
            FROM t_opr_outpatientrecipeinv a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c
           WHERE a.outpatrecipeid_chr = b.seqid
             AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
             AND c.recipeflag_int = 2
             and a.doctorid_chr in (" + this.m_objViewer.m_strStatDocotr + @")
             [Replace] 
             AND a.balance_dat BETWEEN TO_DATE ('" + beginDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE ('" + endDate + @"',
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
             and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
        GROUP BY a.doctorid_chr) c
 WHERE a.doctorid_chr = b.doctorid_chr(+) AND a.doctorid_chr = c.doctorid_chr(+)";
            }
            if (this.m_objViewer.m_cboStatType.SelectedIndex == 0)
            {
                strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
            }
            if (this.m_objViewer.chkdy.Checked)
            {
                strSQL = strSQL.Replace("[Replace]", this.m_objViewer.FySFCdeptid);
            }
            else
            {
                strSQL = strSQL.Replace("[Replace]", " ");
            }

            this.m_objViewer.m_dwShow.DataWindowObject = null;
            this.m_objViewer.m_dwShow.DataWindowObject = "d_opdoctorworkloadnew";
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
               and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
          group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
union all 
select c.deptid_chr,c.deptname_chr,'让利费'as groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from (select '9999'as itemcatid_chr, sum (a.TOTALDIFFCOST_MNY)*(-1) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a
             where a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
          group by a.deptid_chr,a.deptname_chr) c
group by c.deptid_chr,c.deptname_chr
";

            if (this.m_objViewer.m_cboDept.SelectItemValue == "-1")
            {
                strSQL = @"select c.deptid_chr,c.deptname_chr,a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
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
                and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
          group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
union all 
select c.deptid_chr,c.deptname_chr,'让利费'as groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from (select '9999'as itemcatid_chr, sum (a.TOTALDIFFCOST_MNY)*(-1) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a
             where a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                    and( a.isvouchers_int <> 2 or a.isvouchers_int is null)        
          group by a.deptid_chr,a.deptname_chr) c
group by c.deptid_chr,c.deptname_chr";
            }
            else if (this.m_objViewer.m_cboDept.SelectItemValue == "0")
            {
                strSQL = @"select c.deptid_chr,c.deptname_chr,a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a,
                   t_opr_outpatientrecipesumde b
             where a.seqid_chr = b.seqid_chr(+)
               " + this.m_objViewer.FySFCdeptid + @"
               and a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
          group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
union all 
select c.deptid_chr,c.deptname_chr,'让利费'as groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from (select '9999'as itemcatid_chr, sum (a.TOTALDIFFCOST_MNY)*(-1) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a
             where a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                  and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
          group by a.deptid_chr,a.deptname_chr) c
group by c.deptid_chr,c.deptname_chr";
            }
            else
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
                and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
          group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
union all 
select c.deptid_chr,c.deptname_chr,'让利费'as groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from (select '9999'as itemcatid_chr, sum (a.TOTALDIFFCOST_MNY)*(-1) tolfee_mny,a.deptid_chr,a.deptname_chr
              from t_opr_outpatientrecipeinv a
             where a.balance_dat between to_date ('" + beginDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                                     and to_date ('" + endDate + @"',
                                                  'yyyy-mm-dd hh24:mi:ss'
                                                 )
                    and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
               and a.deptid_chr='" + this.m_objViewer.m_cboDept.SelectItemValue + @"'
          group by a.deptid_chr,a.deptname_chr) c
group by c.deptid_chr,c.deptname_chr";
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

        /// <summary>
        /// 分院
        /// </summary>
        public void m_mthBeginStatSubDept()
        {
            string strStatTime = "统计时间:" + this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEndTime.Value.ToShortDateString();
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEndTime.Value.ToShortDateString() + " 23:59:59";
            string m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "门诊医生工作量统计报表(" + this.m_objViewer.m_cboStatType.Text + ")";
            string strSQL = string.Empty;

            strSQL = @"select c.deptid_chr,c.deptname_chr,a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
                        from t_aid_rpt_gop_def a,
                             t_aid_rpt_gop_rla b,
                             (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,a.deptid_chr,a.deptname_chr
                                  from t_opr_outpatientrecipeinv a,
                                       t_opr_outpatientrecipesumde b
                                 where a.seqid_chr = b.seqid_chr(+)
                                   " + this.m_objViewer.FySFCdeptid + @"
                                   and a.balance_dat between to_date ('" + beginDate + @"',
                                                                      'yyyy-mm-dd hh24:mi:ss'
                                                                     )
                                                         and to_date ('" + endDate + @"',
                                                                      'yyyy-mm-dd hh24:mi:ss'
                                                                     )
                                    and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                              group by b.itemcatid_chr,a.deptid_chr,a.deptname_chr) c
                       where a.groupid_chr = b.groupid_chr(+)
                         and b.typeid_chr = c.itemcatid_chr
                         and a.rptid_chr = '0005'
                         and b.rptid_chr = '0005'
                    group by a.groupid_chr, a.groupname_chr,c.deptid_chr,c.deptname_chr
                    union all 
                    select c.deptid_chr,c.deptname_chr,'让利费'as groupname_chr, sum (c.tolfee_mny) tolfee_mny
                        from (select '9999'as itemcatid_chr, sum (a.TOTALDIFFCOST_MNY)*(-1) tolfee_mny,a.deptid_chr,a.deptname_chr
                                  from t_opr_outpatientrecipeinv a
                                 where a.balance_dat between to_date ('" + beginDate + @"',
                                                                      'yyyy-mm-dd hh24:mi:ss'
                                                                     )
                                                         and to_date ('" + endDate + @"',
                                                                      'yyyy-mm-dd hh24:mi:ss'
                                                                     )
                                      and( a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                              group by a.deptid_chr,a.deptname_chr) c
                    group by c.deptid_chr,c.deptname_chr";

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
