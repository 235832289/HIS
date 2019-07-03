using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.PublicMiddleTier;
using System.Text;
using System.Collections;
namespace com.digitalwave.iCare.middletier.HIS.Reports
{
	/// <summary>
	/// 门诊处方发送记录Svc
	/// Create by kong 2004-07-16
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsOPMedStoreSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsOPMedStoreSvc()
		{

		}
		#endregion

		#region 通过窗口取当前病人队列
		/// <summary>
		/// 通过窗口取当前病人队列
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="windStatus">窗体状态信息</param>
		/// <param name="strDate"></param></param>
		/// <param name="p_dtbResult"></param>
		/// <param name="dtDuty"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetPatientListByWinID(System.Security.Principal.IPrincipal p_objPrincipal,
			clsStatusWindows_VO windStatus,string strDate,out DataTable p_dtbResult,DataTable dtDuty)
		{
			long lngRes = 0;
			p_dtbResult = null;
            strDate = DateTime.Parse(strDate).ToString("yyyy-MM-dd");
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetPatientListByWinID");
			if(lngRes < 0)
			{
				return -1;
			}
			string strStatus=string.Empty;
            string strTemp = string.Empty;
            if (windStatus.statusTone == 1)
            {

                strStatus = " and (a.PSTATUS_INT=1 or a.PSTATUS_INT=2 or a.PSTATUS_INT=-1)";
                strTemp = "a.WINDOWID_CHR";
            }
            else
            {
                strStatus = " and (a.PSTATUS_INT=2 or a.PSTATUS_INT=3) and  a.SENDWINDOWID_CHR = '" + windStatus.strWindowID + "'";
                strTemp = "a.SENDWINDOWID_CHR";
            }
            DateTime _serverDate = System.DateTime.Now;
			string strUnionSun=string.Empty;
            #region whether the patient list display in other window
            if (dtDuty.Rows.Count>0)
			{
				for(int i1=0;i1<dtDuty.Rows.Count;i1++)
				{
					if(dtDuty.Rows[i1]["WORKTIME_VCHR"]!=System.DBNull.Value&&dtDuty.Rows[i1]["WORKTIME_VCHR"].ToString()!="")
					{
						bool isBteen=false;//标志当前的时间是否普通药房的上班时间
						string _split="|";
						string[] objstr=dtDuty.Rows[i1]["WORKTIME_VCHR"].ToString().Split(_split.ToCharArray());
						for(int f2=0;f2<objstr.Length;f2++)
						{
							_split="-";
							string[] objstr1=objstr[f2].Split(_split.ToCharArray());
							if(objstr1.Length==2)
							{
									string date1=_serverDate.Date.ToString("yyyy-MM-dd")+" "+objstr1[0];
									string date2=_serverDate.Date.ToString("yyyy-MM-dd")+" "+objstr1[1];
									if(_serverDate>=DateTime.Parse(date1)&&_serverDate<=DateTime.Parse(date2))
									{
										isBteen=true;
										break;
									}
							}
							if(isBteen==true)
							{
								break;
							}
						}
						if(isBteen==false)
						{
                            strUnionSun += @" union all 
         select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patientidx c,
       t_opr_patientregister d,
       t_bse_patientcard e,
       t_bse_patientpaytype f,
       (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
               c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
          from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                    from t_opr_outpatientrecipeinv
                   where recorddate_dat
                            between to_date ('" + strDate + @" 00:00:00',
                                             'yyyy-mm-dd hh24:mi:ss'
                                            )
                                and to_date ('" + strDate + @" 23:59:59',
                                             'yyyy-mm-dd hh24:mi:ss'
                                            )
                group by outpatrecipeid_chr) b,
               t_opr_outpatientrecipeinv c
         where b.seqid_chr = c.seqid_chr) j,
       t_opr_reciperelation h,
       t_bse_employee g,
       t_bse_employee k,
       t_bse_employee m,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.registerid_chr = d.registerid_chr(+)
   and b.patientid_chr = c.patientid_chr
   and b.deptmed_int = 0
   and i.outpatrecipeid_chr = h.outpatrecipeid_chr
   and h.seqid = j.outpatrecipeid_chr
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = m.empid_chr(+)
   and j.opremp_chr = k.empid_chr
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and " + strTemp +@" in (
          select windowid_chr
            from t_bse_medstorewin
           where medstoreid_chr = '" + dtDuty.Rows[i1]["DEPTID_VCHR"].ToString() + "') and a.createdate_chr = '"+strDate+"'and b.patientid_chr = e.patientid_chr(+) and b.paytypeid_chr = f.paytypeid_chr"+strStatus;
						}

					}

				}
            }
            #endregion
            if (windStatus.statusTone == 1)
            {
                string strSQL = @"select   a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
    from t_opr_recipesend a,
         t_opr_recipesendentry i,
         t_opr_outpatientrecipe b,
         t_bse_patientidx c,
         t_opr_patientregister d,
         t_bse_patientcard e,
         t_bse_patientpaytype f,
         (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
                 c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
            from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                      from t_opr_outpatientrecipeinv
                     where recorddate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                  group by outpatrecipeid_chr) b,
                 t_opr_outpatientrecipeinv c
           where b.seqid_chr = c.seqid_chr) j,
         t_opr_reciperelation h,
         t_bse_employee g,
         t_bse_employee k,
         t_bse_employee m,
         t_bse_patient p,
         t_aid_recipetype r
   where a.sid_int = i.sid_int
     and i.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.registerid_chr = d.registerid_chr(+)
     and b.patientid_chr = c.patientid_chr
     and b.deptmed_int = 0
     and i.outpatrecipeid_chr = h.outpatrecipeid_chr
     and h.seqid = j.outpatrecipeid_chr
     and a.treatemp_chr = g.empid_chr(+)
     and a.sendemp_chr = m.empid_chr(+)
     and j.opremp_chr = k.empid_chr
     and b.type_int = r.type_int(+)
     and b.patientid_chr = p.patientid_chr
     and a.createdate_chr = ?
     and b.patientid_chr = e.patientid_chr(+)
     and b.paytypeid_chr = f.paytypeid_chr
     and a.windowid_chr = ?
     and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
order by a.serno_chr desc";
                #region 本部药房转到新楼药房
                // strSQL = strSQL.Append(strStatus + strUnionSun + @"ORDER BY a.serno_chr DESC");
                if (strUnionSun != string.Empty)
                {
                    strSQL = @"select  a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
    from t_opr_recipesend a,
         t_opr_recipesendentry i,
         t_opr_outpatientrecipe b,
         t_bse_patientidx c,
         t_opr_patientregister d,
         t_bse_patientcard e,
         t_bse_patientpaytype f,
         (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
                 c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
            from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                      from t_opr_outpatientrecipeinv
                     where recorddate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                  group by outpatrecipeid_chr) b,
                 t_opr_outpatientrecipeinv c
           where b.seqid_chr = c.seqid_chr) j,
         t_opr_reciperelation h,
         t_bse_employee g,
         t_bse_employee k,
         t_bse_employee m,
         t_bse_patient p,
         t_aid_recipetype r
   where a.sid_int = i.sid_int
     and i.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.registerid_chr = d.registerid_chr(+)
     and b.patientid_chr = c.patientid_chr
     and b.deptmed_int = 0
     and i.outpatrecipeid_chr = h.outpatrecipeid_chr
     and h.seqid = j.outpatrecipeid_chr
     and a.treatemp_chr = g.empid_chr(+)
     and a.sendemp_chr = m.empid_chr(+)
     and j.opremp_chr = k.empid_chr
     and b.type_int = r.type_int(+)
     and b.patientid_chr = p.patientid_chr
     and a.createdate_chr = ?
     and b.patientid_chr = e.patientid_chr(+)
     and b.paytypeid_chr = f.paytypeid_chr
     and a.windowid_chr = ?
     and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1) " + strUnionSun+@"
     order by serno_chr desc";
                }
                #endregion
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = strDate + " 00:00:00";
                    objLisAddItemRefArr[1].Value = strDate + " 23:59:59";
                    objLisAddItemRefArr[2].Value = strDate;
                    objLisAddItemRefArr[3].Value = windStatus.strWindowID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else if(windStatus.statusTone==2)
            {
                string strSQL = @"select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
    from t_opr_recipesend a,
         t_opr_recipesendentry i,
         t_opr_outpatientrecipe b,
         t_bse_patientidx c,
         t_opr_patientregister d,
         t_bse_patientcard e,
         t_bse_patientpaytype f,
         (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
                 c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
            from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                      from t_opr_outpatientrecipeinv
                     where recorddate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                  group by outpatrecipeid_chr) b,
                 t_opr_outpatientrecipeinv c
           where b.seqid_chr = c.seqid_chr) j,
         t_opr_reciperelation h,
         t_bse_employee g,
         t_bse_employee k,
         t_bse_employee m,
         t_bse_patient p,
         t_aid_recipetype r
   where a.sid_int = i.sid_int
     and i.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.registerid_chr = d.registerid_chr(+)
     and b.patientid_chr = c.patientid_chr
     and b.deptmed_int = 0
     and i.outpatrecipeid_chr = h.outpatrecipeid_chr
     and h.seqid = j.outpatrecipeid_chr
     and a.treatemp_chr = g.empid_chr(+)
     and a.sendemp_chr = m.empid_chr(+)
     and j.opremp_chr = k.empid_chr
     and b.type_int = r.type_int(+)
     and b.patientid_chr = p.patientid_chr
     and a.createdate_chr = ?
     and b.patientid_chr = e.patientid_chr(+)
     and b.paytypeid_chr = f.paytypeid_chr
     and a.sendwindowid_chr = ?
     and (a.pstatus_int=2 or a.pstatus_int=3)
order by a.serno_chr desc";
                #region 本部药房转到新楼药房
                // strSQL = strSQL.Append(strStatus + strUnionSun + @"ORDER BY a.serno_chr DESC");
                if (strUnionSun != string.Empty)
                {
                    strSQL = @"select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
    from t_opr_recipesend a,
         t_opr_recipesendentry i,
         t_opr_outpatientrecipe b,
         t_bse_patientidx c,
         t_opr_patientregister d,
         t_bse_patientcard e,
         t_bse_patientpaytype f,
         (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
                 c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
            from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                      from t_opr_outpatientrecipeinv
                     where recorddate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                  group by outpatrecipeid_chr) b,
                 t_opr_outpatientrecipeinv c
           where b.seqid_chr = c.seqid_chr) j,
         t_opr_reciperelation h,
         t_bse_employee g,
         t_bse_employee k,
         t_bse_employee m,
         t_bse_patient p,
         t_aid_recipetype r
   where a.sid_int = i.sid_int
     and i.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.registerid_chr = d.registerid_chr(+)
     and b.patientid_chr = c.patientid_chr
     and b.deptmed_int = 0
     and i.outpatrecipeid_chr = h.outpatrecipeid_chr
     and h.seqid = j.outpatrecipeid_chr
     and a.treatemp_chr = g.empid_chr(+)
     and a.sendemp_chr = m.empid_chr(+)
     and j.opremp_chr = k.empid_chr
     and b.type_int = r.type_int(+)
     and b.patientid_chr = p.patientid_chr
     and a.createdate_chr = ?
     and b.patientid_chr = e.patientid_chr(+)
     and b.paytypeid_chr = f.paytypeid_chr
     and a.sendwindowid_chr = ?
     and (a.pstatus_int=2 or a.pstatus_int=3) " + strUnionSun + @"
     order by serno_chr desc";
                }
                #endregion
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = strDate + " 00:00:00";
                    objLisAddItemRefArr[1].Value = strDate + " 23:59:59";
                    objLisAddItemRefArr[2].Value = strDate;
                    objLisAddItemRefArr[3].Value = windStatus.strWindowID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }

			return lngRes;
		}
		#endregion
        #region 通过窗口取当前精神或麻醉或急诊处方类型的病人队列
        /// <summary>
        /// 通过窗口取当前精神或麻醉处方类型的病人队列
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientListByWinIDForData(System.Security.Principal.IPrincipal p_objPrincipal,
            clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            strDate = DateTime.Parse(strDate).ToString("yyyy-MM-dd");
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetPatientListByWinIDForData");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 2
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 3
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 4
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 5";
            try
            {
                if (windStatus.statusTone == 2)
                {
                    strSQL = @" select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 2
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 3
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 4
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 5";

                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = strDate ;
                objLisAddItemRefArr[1].Value = windStatus.strWindowID;
                objLisAddItemRefArr[2].Value = strDate;
                objLisAddItemRefArr[3].Value = windStatus.strWindowID;
                objLisAddItemRefArr[4].Value = strDate;
                objLisAddItemRefArr[5].Value = windStatus.strWindowID;
                objLisAddItemRefArr[6].Value = strDate;
                objLisAddItemRefArr[7].Value = windStatus.strWindowID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion
        #region 不区别发药窗口取当前病人队列
        /// <summary>
        /// 不区别发药窗口取当前病人队列
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientListNotByWinID(System.Security.Principal.IPrincipal p_objPrincipal,
            clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            strDate = DateTime.Parse(strDate).ToString("yyyy-MM-dd");
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetPatientListNotByWinID");
            if (lngRes < 0)
            {
                return -1;
            }
            clsGetServerDate getServerDate = new clsGetServerDate();
            DateTime _serverDate = getServerDate.m_GetServerDate();
            string strUnionSun = string.Empty;
            #region whether display the patient list
            if (dtDuty.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtDuty.Rows.Count; i1++)
                {
                    if (dtDuty.Rows[i1]["WORKTIME_VCHR"] != System.DBNull.Value && dtDuty.Rows[i1]["WORKTIME_VCHR"].ToString() != "")
                    {
                        bool isBteen = false;//标志当前的时间是否普通药房的上班时间
                        string _split = "|";
                        string[] objstr = dtDuty.Rows[i1]["WORKTIME_VCHR"].ToString().Split(_split.ToCharArray());
                        for (int f2 = 0; f2 < objstr.Length; f2++)
                        {
                            _split = "-";
                            string[] objstr1 = objstr[f2].Split(_split.ToCharArray());
                            if (objstr1.Length == 2)
                            {
                                string date1 = _serverDate.Date.ToString("yyyy-MM-dd") + " " + objstr1[0];
                                string date2 = _serverDate.Date.ToString("yyyy-MM-dd") + " " + objstr1[1];
                                if (_serverDate >= DateTime.Parse(date1) && _serverDate <= DateTime.Parse(date2))
                                {
                                    isBteen = true;
                                    break;
                                }
                            }
                            if (isBteen == true)
                            {
                                break;
                            }
                        }
                        if (isBteen == false)
                        {
                            strUnionSun += @"union all 
         select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patientidx c,
       t_opr_patientregister d,
       t_bse_patientcard e,
       t_bse_patientpaytype f,
       (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
               c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
          from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                    from t_opr_outpatientrecipeinv
                   where recorddate_dat
                            between to_date ('" + strDate + @" 00:00:00',
                                             'yyyy-mm-dd hh24:mi:ss'
                                            )
                                and to_date ('" + strDate + @" 23:59:59',
                                             'yyyy-mm-dd hh24:mi:ss'
                                            )
                group by outpatrecipeid_chr) b,
               t_opr_outpatientrecipeinv c
         where b.seqid_chr = c.seqid_chr) j,
       t_opr_reciperelation h,
       t_bse_employee g,
       t_bse_employee k,
       t_bse_employee m,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.registerid_chr = d.registerid_chr(+)
   and b.patientid_chr = c.patientid_chr
   and b.deptmed_int = 0
   and i.outpatrecipeid_chr = h.outpatrecipeid_chr
   and h.seqid = j.outpatrecipeid_chr
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = m.empid_chr(+)
   and j.opremp_chr = k.empid_chr
   and b.type_int = r.type_int(+)
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and b.patientid_chr = p.patientid_chr
   and a.medstoreid_chr = '" + windStatus.strStorageID+@"'
   and a.sendwindowid_chr in (
          select windowid_chr
            from t_bse_medstorewin
           where medstoreid_chr =
                           '" + dtDuty.Rows[i1]["DEPTID_VCHR"].ToString() + @"')
   and a.createdate_chr = '" + strDate + @"'
   and b.patientid_chr = e.patientid_chr(+)
   and b.paytypeid_chr = f.paytypeid_chr ";
                        }

                    }

                }
            }
            #endregion

            string strSQL = @"select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
    from t_opr_recipesend a,
         t_opr_recipesendentry i,
         t_opr_outpatientrecipe b,
         t_bse_patientidx c,
         t_opr_patientregister d,
         t_bse_patientcard e,
         t_bse_patientpaytype f,
         (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
                 c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
            from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                      from t_opr_outpatientrecipeinv
                     where recorddate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                  group by outpatrecipeid_chr) b,
                 t_opr_outpatientrecipeinv c
           where b.seqid_chr = c.seqid_chr) j,
         t_opr_reciperelation h,
         t_bse_employee g,
         t_bse_employee k,
         t_bse_employee m,
         t_bse_patient p,
         t_aid_recipetype r
   where a.sid_int = i.sid_int
     and i.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.registerid_chr = d.registerid_chr(+)
     and b.patientid_chr = c.patientid_chr
     and b.deptmed_int = 0
     and i.outpatrecipeid_chr = h.outpatrecipeid_chr
     and h.seqid = j.outpatrecipeid_chr
     and a.treatemp_chr = g.empid_chr(+)
     and a.sendemp_chr = m.empid_chr(+)
     and j.opremp_chr = k.empid_chr
     and b.type_int = r.type_int(+)
     and b.patientid_chr = p.patientid_chr
     and a.createdate_chr = ?
     and b.patientid_chr = e.patientid_chr(+)
     and a.medstoreid_chr = ?
     and b.paytypeid_chr = f.paytypeid_chr
     and (a.pstatus_int = 2 or a.pstatus_int = 3)
order by a.serno_chr desc";
            if (strUnionSun != string.Empty)
            {
                strSQL = @"select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
         a.medstoreid_chr, a.autoprint_int, a.senddate_dat as givedate_dat,
         a.sendemp_chr as giveemp_chr, a.windowid_chr, a.returndate_dat,
         a.returnemp_chr, a.injectprint_int, a.pstatus_int, a.senddate_dat,
         a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, i.outpatrecipeid_chr,
         b.type_int as recipetype_int, b.pstauts_int as breakpstatus,
         c.name_vchr, c.sex_chr, c.idcard_chr, c.birth_dat, c.patientid_chr,
         d.registerno_chr, d.registerdate_dat, e.patientcardid_chr,
         f.paytypename_vchr,f.paytypeid_chr,
         decode (f.internalflag_int,
                 0, '自费',
                 1, '公费',
                 2, '医保'
                ) as internalname,
         j.status_int, j.recorddate_dat, j.split_int, j.invoiceno_vchr,
         g.lastname_vchr, k.empno_chr as opremp_chr,
         k.lastname_vchr as checkname, m.lastname_vchr as sendname,
         p.homephone_vchr, r.typename_vchr
    from t_opr_recipesend a,
         t_opr_recipesendentry i,
         t_opr_outpatientrecipe b,
         t_bse_patientidx c,
         t_opr_patientregister d,
         t_bse_patientcard e,
         t_bse_patientpaytype f,
         (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
                 c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
            from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                      from t_opr_outpatientrecipeinv
                     where recorddate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                  group by outpatrecipeid_chr) b,
                 t_opr_outpatientrecipeinv c
           where b.seqid_chr = c.seqid_chr) j,
         t_opr_reciperelation h,
         t_bse_employee g,
         t_bse_employee k,
         t_bse_employee m,
         t_bse_patient p,
         t_aid_recipetype r
   where a.sid_int = i.sid_int
     and i.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.registerid_chr = d.registerid_chr(+)
     and b.patientid_chr = c.patientid_chr
     and b.deptmed_int = 0
     and i.outpatrecipeid_chr = h.outpatrecipeid_chr
     and h.seqid = j.outpatrecipeid_chr
     and a.treatemp_chr = g.empid_chr(+)
     and a.sendemp_chr = m.empid_chr(+)
     and j.opremp_chr = k.empid_chr
     and b.type_int = r.type_int(+)
     and b.patientid_chr = p.patientid_chr
     and a.createdate_chr = ?
     and b.patientid_chr = e.patientid_chr(+)
     and a.medstoreid_chr = ?
     and b.paytypeid_chr = f.paytypeid_chr
     and (a.pstatus_int = 2 or a.pstatus_int = 3) " + strUnionSun+@"
order by serno_chr desc";

            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = strDate + " 00:00:00";
                objLisAddItemRefArr[1].Value = strDate + " 23:59:59";
                objLisAddItemRefArr[2].Value = strDate;
                objLisAddItemRefArr[3].Value = windStatus.strStorageID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objLisAddItemRefArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion
        #region 是否自动打印发药单
        [AutoComplete]
		public long  m_mthIsAutoPrint(out bool isAuto)
		{
			isAuto=false;
			long lngRes=0;
            string strSQL = @"select setstatus_int
  from t_sys_setting
 where setid_chr = '0034'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				DataTable dt =new DataTable();
				lngRes= objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				if(lngRes >0&&dt.Rows.Count>0)
				{
					if(dt.Rows[0]["SETSTATUS_INT"].ToString().Trim()=="1")
					{
						isAuto=true;
					}
				}
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion

		#region 查找数据
		 /// <summary>
        ///  查找数据
		 /// </summary>
		 /// <param name="p_objPrincipal"></param>
		 /// <param name="p_intStatus"></param>
		 /// <param name="p_strStorageID"></param>
		 /// <param name="p_strWinID"></param>
		 /// <param name="p_strCardID"></param>
		 /// <param name="p_strPatient"></param>
		 /// <param name="p_strRegNo"></param>
		 /// <param name="p_strRegDate"></param>
		 /// <param name="p_endDate"></param>
		 /// <param name="isShowReturn"></param>
		 /// <param name="p_dtbResult"></param>
		 /// <returns></returns>
		[AutoComplete]
		public long m_lngGetPatientList(System.Security.Principal.IPrincipal p_objPrincipal,int p_intStatus,string p_strStorageID,
			string p_strWinID,string p_strCardID,string p_strPatient,string p_strRegNo,
			string p_strRegDate,string p_endDate,bool isShowReturn,out DataTable p_dtbResult)
		{
			long lngRes = 0;
			p_dtbResult = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetPatientList");
			if(lngRes < 0)
			{
				return -1;
			}

			string strWhere = "";
			if(p_strCardID.Trim() != "")
				strWhere += " AND e.patientcardid_chr = '" + p_strCardID.Trim() + "' ";
			if(p_strPatient.Trim() != "")
				strWhere += " AND c.name_vchr like '" + p_strPatient.Trim() + "%'";
			if(p_strRegNo.Trim() != "")
				strWhere += " AND d.registerno_chr like '" + p_strRegNo.Trim() + "%'";
            strWhere += " and a.MEDSTOREID_CHR  in (select  MEDSTOREID_CHR from t_bse_medstore where MEDICNETYPE_INT=(select MEDICNETYPE_INT from t_bse_medstore where MEDSTOREID_CHR='" + p_strStorageID + "')) ";
            if (p_intStatus == 1)
            {
                strWhere += " and a.PSTATUS_INT in(-1,1,2) ";
            }
            if (p_intStatus == 2)
            {
                strWhere += " and (a.PSTATUS_INT=2 or a.PSTATUS_INT=3)";
            }
			string strStatus;
			if(isShowReturn==false)
				strStatus=@" and b.PSTAUTS_INT!=-2";
			else
				strStatus=@"";
            StringBuilder strSQL = new StringBuilder(@"select a.windowid_chr, i.outpatrecipeid_chr, b.type_int as recipetype_int,
       a.pstatus_int, a.senddate_dat, a.sendemp_chr, a.treatdate_dat,
       a.treatemp_chr, c.name_vchr, d.registerno_chr, d.registerdate_dat,
       b.pstauts_int, b.pstauts_int as breakpstatus, e.patientcardid_chr,
       c.sex_chr, c.idcard_chr, r.typename_vchr, c.birth_dat,
       decode (f.internalflag_int,
               0, '自费',
               1, '公费',
               2, '医保'
              ) as internalname,
       j.invoiceno_vchr, f.paytypename_vchr,f.paytypeid_chr, j.status_int, g.lastname_vchr,
       a.autoprint_int, a.medstoreid_chr, a.returndate_dat, p.homephone_vchr,
       c.patientid_chr, j.recorddate_dat, k.empno_chr as opremp_chr,
       k.lastname_vchr as checkname, m.lastname_vchr as sendname, j.split_int,
       a.sendwindowid_chr as sendwindowid, a.senddate_dat as givedate_dat,
       a.sid_int, a.serno_chr, a.injectprint_int,
       a.sendemp_chr as giveemp_chr, a.returnemp_chr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patientidx c,
       t_opr_patientregister d,
       t_bse_patientcard e,
       t_bse_patientpaytype f,
       (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
               c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
          from (select   max (seqid_chr) as seqid_chr, outpatrecipeid_chr
                    from t_opr_outpatientrecipeinv
                   where recorddate_dat between to_date
                                                      (?,
                                                       'yyyy-mm-dd hh24:mi:ss'
                                                      )
                                            and to_date
                                                      (?,
                                                       'yyyy-mm-dd hh24:mi:ss'
                                                      )
                group by outpatrecipeid_chr) b,
               t_opr_outpatientrecipeinv c
         where b.seqid_chr = c.seqid_chr) j,
       t_opr_reciperelation h,
       t_bse_employee g,
       t_bse_employee k,
       t_bse_employee m,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.registerid_chr = d.registerid_chr(+)
   and b.patientid_chr = c.patientid_chr
   and i.outpatrecipeid_chr = h.outpatrecipeid_chr
   and h.seqid = j.outpatrecipeid_chr
   and c.patientid_chr = p.patientid_chr
   and a.treatemp_chr = g.empid_chr(+)
   and j.opremp_chr = k.empid_chr
   and a.sendemp_chr = m.empid_chr(+)
   and b.type_int = r.type_int(+)
   and j.totalsum_mny >= 0
   and to_date (a.createdate_chr, 'yyyy-mm-dd') between to_date (?,
                                                                 'yyyy-mm-dd'
                                                                )
                                                    and to_date (?,
                                                                 'yyyy-mm-dd'
                                                                )
   and b.patientid_chr = e.patientid_chr(+)
   and b.paytypeid_chr = f.paytypeid_chr ");
            strSQL = strSQL.Append(strStatus + " " + strWhere + " order by a.serno_chr desc");
			try
			{
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRegDate + " 00:00:00";
                objLisAddItemRefArr[1].Value = p_endDate + " 23:59:59";
                objLisAddItemRefArr[2].Value = p_strRegDate;
                objLisAddItemRefArr[3].Value = p_endDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objLisAddItemRefArr);
                objHRPSvc.Dispose();
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;
		}
		#endregion

		#region 配药处理
		/// <summary>
		///配药处理 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objRecord"></param>
        /// <param name="flnallyWindowsID">配药窗口ID</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDosage(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute[] p_objRecord,string flnallyWindowsID,string oldWinID,int m_intSID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddNewNurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			
			if(p_objRecord.Length>0)
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strWindowID = "";
                int waiterNO = 0;
                clsWindowsCortrol windCortrol = new clsWindowsCortrol();
                windCortrol.m_lngGetGiveWindID(p_objPrincipal, p_objRecord[0].m_strWindow, out strWindowID, out waiterNO);
                if (strWindowID == "")
                    throw (new System.Exception("还没有设置相应的发药窗口，或当前所有的发药窗口都不在工作中！"));
                //string strSQL = @"update t_opr_recipesend set PSTATUS_INT=2,SENDWINDOWID_CHR='" + strWindowID + "',  TREATDATE_DAT=to_date('" + DateTime.Now.ToString() + "','yyyy-mm-dd hh24:mi:ss'),TREATEMP_CHR='" + p_objRecord[0].m_strOPERATORID_CHR + "' where OUTPATRECIPEID_CHR='" + p_objRecord[0].m_strOUTPATRECIPEID_CHR + "' and MEDSTOREID_CHR='" + oldWinID + "'";
                string strSQL = @"update t_opr_recipesend
       set pstatus_int = 2,
       sendwindowid_chr = ?,
       treatdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
       treatemp_chr = ?
       where sid_int = ?";
				try
				{
                    System.Data.IDataParameter[] param = null;
                    objHRPSvc.CreateDatabaseParameter(4, out param);
                    param[0].Value = strWindowID;
                    param[1].Value = DateTime.Now.ToString();
                    param[2].Value = p_objRecord[0].m_strOPERATORID_CHR;
                    param[3].Value = m_intSID;
                    long lngAffected=-1;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, param);
				}
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
                 
                clsmedstorewinque p_objWind = new clsmedstorewinque();
                
                p_objWind.m_strMEDSTOREID_CHR = p_objRecord[0].m_strFrom;
                p_objWind.m_strOUTPATRECIPEID_CHR = p_objRecord[0].m_strOUTPATRECIPEID_CHR;
                p_objWind.m_strRECIPETYPE_CHR = p_objRecord[0].m_strOUTPATRECIPETYPE;

                //删除配药队列
                p_objWind.m_strWINDOWID_CHR=p_objRecord[0].m_strWindow;
                p_objWind.m_intWINDOWTYPE_INT = 1;
                windCortrol.m_lngDeleWinque(p_objPrincipal, p_objWind);
                //写入发药队列
 
                p_objWind.m_strWINDOWID_CHR = strWindowID;
                p_objWind.m_intWaitNO = waiterNO;
                p_objWind.m_intWINDOWTYPE_INT = 0;
                windCortrol.m_lngAddNewWinque(p_objPrincipal, p_objWind);

				for(int i1=0;i1<p_objRecord.Length;i1++)
				{
					lngRes=m_lngAddNewNurseexecute(p_objPrincipal,p_objRecord[i1]);
				}

			}

			return lngRes;
		}

		#endregion

		#region 退处方
		/// <summary>
        /// 退处方
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngBreak(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute[] p_objRecord,int m_intSID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddNewNurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			
			if(p_objRecord.Length>0)
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = @"update t_opr_recipesend set PSTATUS_INT=-1,RETURNDATE_DAT=to_date(?,'yyyy-mm-dd hh24:mi:ss'),RETURNEMP_CHR=? where sid_int=? and MEDSTOREID_CHR=? and WINDOWID_CHR=?";
				try
				{
                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                    paramArr[0].Value = DateTime.Now.ToString();
                    paramArr[1].Value = p_objRecord[0].m_strOPERATORID_CHR;
                    paramArr[2].Value = m_intSID;
                    paramArr[3].Value = p_objRecord[0].m_strFrom;
                    paramArr[4].Value = p_objRecord[0].m_strWindow;
                    long lngRecordsAffected = -1;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
				}
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
				for(int i1=0;i1<p_objRecord.Length;i1++)
				{
					lngRes=m_lngAddNewNurseexecute(p_objPrincipal,p_objRecord[i1]);
				}
			}
			return lngRes;
		}

		#endregion

		#region 写入执行记录
		/// <summary>
		/// 写入执行记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strRecordID"></param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddNewNurseexecute(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddNewNurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			int  p_strRecordID=0;
            //lngRes = objHRPSvc.m_lngGenerateNewID("t_opr_nurseexecute","SEQ_INT",out p_strRecordID);
            //if(lngRes < 0)
            //    return lngRes;

			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"insert into t_opr_nurseexecute
            (seq_int, business_int, tablename_vchr, outpatrecipeid_chr,
             rowno_chr, itemid_chr, exectimes_int, operatortype_int,
             operatorid_chr, exectime_dat, systime_dat, remark1_vchr,
             remark2_vchr, status_int
            )
           values (seq_nurseexecuteid.nextval, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?
            )";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(13,out objLisAddItemRefArr);
				//objLisAddItemRefArr[0].Value = p_strRecordID;
				objLisAddItemRefArr[0].Value = p_objRecord.m_intBUSINESS_INT;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strTABLENAME_VCHR;
				objLisAddItemRefArr[2].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
				objLisAddItemRefArr[3].Value = p_objRecord.m_strROWNO_CHR;
				objLisAddItemRefArr[4].Value = p_objRecord.m_strITEMID_CHR;
				objLisAddItemRefArr[5].Value = p_objRecord.m_intEXECTIMES_INT;
				objLisAddItemRefArr[6].Value = p_objRecord.m_intOPERATORTYPE_INT;
				objLisAddItemRefArr[7].Value = p_objRecord.m_strOPERATORID_CHR;
				objLisAddItemRefArr[8].Value = DateTime.Parse(strDateTime);
				objLisAddItemRefArr[9].Value = DateTime.Parse(strDateTime);
				objLisAddItemRefArr[10].Value = p_objRecord.m_strREMARK1_VCHR;
				objLisAddItemRefArr[11].Value = p_objRecord.m_strREMARK2_VCHR;
				objLisAddItemRefArr[12].Value = p_objRecord.m_intSTATUS_INT;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

        #region 查找所有的发票号（分发票）
        /// <summary>
        /// 查找所有的发票号（分发票）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strOutpatrecipeid"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_lngGetAllINVOICENO(System.Security.Principal.IPrincipal p_objPrincipal, string strOutpatrecipeid)
        {
            string strAllNO = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewNurseexecute");

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "select INVOICENO_VCHR from t_opr_outpatientrecipeinv where OUTPATRECIPEID_CHR='" + strOutpatrecipeid + "' and STATUS_INT=1";
            DataTable dt = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            {
                if (i1 == 0)
                {
                    strAllNO += dt.Rows[i1]["INVOICENO_VCHR"].ToString().Trim();
                }
                else
                {
                    strAllNO +=","+ dt.Rows[i1]["INVOICENO_VCHR"].ToString().Trim();
                }
            }
            return strAllNO;
        }
        #endregion

		#region 查找未发药病人
		/// <summary>
		/// 查找未发药病人
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strWinID">窗口号</param>
		/// <param name="p_strCardID">诊疗卡号</param>
		/// <param name="p_strPatient">病人姓名</param>
		/// <param name="p_strRegNo">流水号</param>
		/// <param name="p_strRegDate">挂号日期</param>
		/// <param name="p_dtbResult">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetPatient(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strWinID,string p_strCardID,string p_strPatient,string p_strRegNo,
			string p_strRegDate,out DataTable p_dtbResult)
		{
			long lngRes = 0;
			p_dtbResult = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetPatient");
			if(lngRes < 0)
			{
				return -1;
			}

			string strWhere = "";
			if(p_strCardID.Trim() != "")
				strWhere += " AND d.patientcardid_chr = '" + p_strCardID.Trim() + "' ";
			if(p_strPatient.Trim() != "")
				strWhere += " AND b.name_vchr like '" + p_strPatient.Trim() + "%' ";
			if(p_strRegNo.Trim() != "")
				strWhere += " AND c.registerno_chr like '" + p_strRegNo.Trim() + "%' ";
			if(p_strRegDate.Trim() != "2004-01-01")
				strWhere += " AND registerdate_dat = TO_DATE ('" + p_strRegDate.Trim() +"', 'yyyy-mm-dd') ";

			string strSQL = @"SELECT DISTINCT a.registerid_chr,a.OUTPATRECIPEID_CHR, a.patientid_chr, b.name_vchr,
										      c.registerno_chr, c.registerdate_dat
										 FROM t_opr_outpatientrecipe a,
										      t_bse_patientidx b,
											  t_opr_patientregister c,
											  t_bse_patientcard d
									    WHERE a.patientid_chr = b.patientid_chr
											  AND a.registerid_chr = c.registerid_chr
											  AND b.patientid_chr = d.patientid_chr
											  AND a.pstauts_int = 2 
											  AND a.outpatrecipeid_chr IN (
											                     SELECT h.outpatrecipeid_chr
																   FROM t_opr_recipesend g,t_opr_recipesendentry h
																  WHERE g.sid_int=h.sid_int and  g.pstatus_int = 1
																	    AND TRIM(g.windowid_chr) = '" + p_strWinID.Trim() + "') ";
			strSQL += strWhere;
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbResult);	

			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;
		}
		#endregion

		#region 通过窗口取己发药病人队列
		/// <summary>
		/// 通过窗口取当前病人队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strID">窗口号</param>
		/// <param name="p_dtbResult">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetPutOutPatientListByWinID(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strID,out DataTable p_dtbResult)
		{
			long lngRes = 0;
			p_dtbResult = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetPutOutPatientListByWinID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT DISTINCT a.registerid_chr,a.OUTPATRECIPEID_CHR, a.patientid_chr, b.name_vchr,
										      c.registerno_chr, c.registerdate_dat
										 FROM t_opr_outpatientrecipe a,
										      t_bse_patientidx b,
											  t_opr_patientregister c
									    WHERE a.patientid_chr = b.patientid_chr
											  AND a.registerid_chr = c.registerid_chr(+)
											  AND a.pstauts_int = 3
											  AND a.outpatrecipeid_chr IN (
											                       SELECT h.outpatrecipeid_chr
																   FROM t_opr_recipesend g,t_opr_recipesendentry h
																  WHERE g.sid_int=h.sid_int and  g.pstatus_int = 2
																	    AND TRIM(g.windowid_chr) = '" + p_strID.Trim() + "')";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbResult);	

			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;
		}
		#endregion

		#region 获得病人处方（状态）
		/// <summary>
		/// 获得病人处方（状态）
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strRegID">门诊处方记录ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMainRecipe(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strRegID,out clsOutpatientRecipe_VO[] p_objResultArr,DateTime date1,DateTime date2,int intptatus,string strDepID)
		{
			long lngRes = 0;
			p_objResultArr=new clsOutpatientRecipe_VO[0];
			//权限
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMainRecipe");
			if(lngRes < 0)
			{
				return -1;
			}

			DataTable dtResult=new DataTable();
            string strWhere = "";
            if (intptatus == 3)
            {
                strWhere = @" and a.CREATEDATE_DAT BETWEEN to_date('" + date1.ToShortDateString() + " 00:00:00" + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + date2.ToShortDateString() + " 23:59:59" + "','yyyy-mm-dd hh24:mi:ss') and (a.PSTAUTS_INT!=2)";
                    if (strDepID != "")
                        strWhere += @" and a.DIAGDEPT_CHR='" + strDepID+"'";
            }
            else
            {
                strWhere = @" and a.outpatrecipeid_chr='" + p_strRegID.Trim() + "'";
            }
            string strSQL = @"SELECT a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
       a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
       a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
       a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr, a.groupid_chr,
       a.type_int, a.confirm_int, a.confirmdesc_vchr, a.createtype_int,
       a.deptmed_int, b.name_vchr, c.lastname_vchr, d.DEPTNAME_VCHR,
								   e.lastname_vchr AS recordemp,f.DIAG_VCHR,h.HOMEADDRESS_VCHR,h.HOMEPHONE_VCHR,h.GOVCARD_CHR , h.DIFFICULTY_VCHR , h.INSURANCEID_VCHR,f.RECORDDATE_DAT,k.PAYTYPENAME_VCHR,
       p.diag_vchr, j.patientcardid_chr,(SELECT sum(totalsum_mny)
          FROM t_opr_outpatientrecipeinv
         WHERE outpatrecipeid_chr = '" + p_strRegID.Trim()+ @"' and totalsum_mny>0) totailmoney
							  FROM t_opr_outpatientrecipe a,
								   t_bse_patientidx b,
								   t_bse_employee c,
								   T_BSE_DEPTDESC d,
								   t_bse_employee e,
								   t_opr_outpatientcasehis f,
								   t_bse_patient h,
								   t_bse_patientPaytype  k,
                                   T_BSE_PATIENTCARD j,
                                   T_OPR_OUTPATIENTCASEHIS p
							 WHERE a.patientid_chr = b.patientid_chr(+)
							   AND a.DIAGDR_CHR = c.EMPID_CHR(+)
							   AND a.DIAGDEPT_CHR = d.DEPTID_CHR(+)
							   AND a.recordemp_chr = e.EMPID_CHR(+)
							   and a.CASEHISID_CHR=f.CASEHISID_CHR(+)
							   and a.patientid_chr=h.patientid_chr(+)
								and a.PAYTYPEID_CHR=k.PAYTYPEID_CHR(+)
                                and a.patientid_chr=j.patientid_chr(+)
                                and a.CASEHISID_CHR=p.CASEHISID_CHR(+)
							";
            strSQL += strWhere;
            			              
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);	


				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					p_objResultArr=new clsOutpatientRecipe_VO[dtResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1]=new clsOutpatientRecipe_VO();


                        p_objResultArr[i1].CONFIRM_INT = int.Parse(dtResult.Rows[i1]["CONFIRM_INT"].ToString());
						p_objResultArr[i1].strDIAG_VCHR=dtResult.Rows[i1]["DIAG_VCHR"].ToString().Trim();
						p_objResultArr[i1].strHOMEADDRESS_VCHR=dtResult.Rows[i1]["HOMEADDRESS_VCHR"].ToString().Trim();


						p_objResultArr[i1].HOMEPHONE_VCHR=dtResult.Rows[i1]["HOMEPHONE_VCHR"].ToString().Trim();
						p_objResultArr[i1].strRECORDDATE_DAT=dtResult.Rows[i1]["RECORDDATE_DAT"].ToString().Trim();
                        p_objResultArr[i1].strDIAG_VCHR = dtResult.Rows[i1]["DIAG_VCHR"].ToString().Trim();
                        

						p_objResultArr[i1].m_strOutpatRecipeID=dtResult.Rows[i1]["outpatrecipeid_chr"].ToString().Trim();
						p_objResultArr[i1].m_strOutpatRecipeNo=dtResult.Rows[i1]["outpatrecipeno_vchr"].ToString().Trim();
						p_objResultArr[i1].m_strRecordDate=dtResult.Rows[i1]["recorddate_dat"].ToString().Trim();
						p_objResultArr[i1].m_strRegisterID=dtResult.Rows[i1]["registerid_chr"].ToString().Trim();
						p_objResultArr[i1].m_strCreateDate=dtResult.Rows[i1]["createdate_dat"].ToString().Trim();
						p_objResultArr[i1].m_objRecordEmp=new clsEmployeeVO();
						p_objResultArr[i1].m_objRecordEmp.strEmpID=dtResult.Rows[i1]["recordemp_chr"].ToString().Trim();
						p_objResultArr[i1].m_objRecordEmp.strLastName = dtResult.Rows[i1]["recordemp"].ToString().Trim();
						p_objResultArr[i1].m_objPatient=new clsPatientVO();
						p_objResultArr[i1].m_objPatient.strPatientID=dtResult.Rows[i1]["patientid_chr"].ToString().Trim();
                        p_objResultArr[i1].m_objPatient.strPatientCardID = dtResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_objPatient.m_strDIFFICULTY_VCHR=dtResult.Rows[i1]["DIFFICULTY_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_objPatient.objPatType=new clsPatientType_VO();
						p_objResultArr[i1].m_objPatient.objPatType.m_strPayTypeName=dtResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_objPatient.m_strGOVCARD_CHR=dtResult.Rows[i1]["GOVCARD_CHR"].ToString().Trim();

						p_objResultArr[i1].m_objPatient.strInsuranceID=dtResult.Rows[i1]["INSURANCEID_VCHR"].ToString().Trim();



						p_objResultArr[i1].m_objPatient.strName=dtResult.Rows[i1]["name_vchr"].ToString().Trim();
						p_objResultArr[i1].m_objDiagDr=new clsEmployeeVO();
						p_objResultArr[i1].m_objDiagDr.strEmpID=dtResult.Rows[i1]["diagdr_chr"].ToString().Trim();
						p_objResultArr[i1].m_objDiagDr.strLastName=dtResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						p_objResultArr[i1].m_objDiagDept=new clsDepartmentVO();
						p_objResultArr[i1].m_objDiagDept.strDeptID=dtResult.Rows[i1]["diagdept_chr"].ToString().Trim();
						p_objResultArr[i1].m_objDiagDept.strDeptName=dtResult.Rows[i1]["deptname_vchr"].ToString().Trim();
						p_objResultArr[i1].m_intPStatus=dtResult.Rows[i1]["pstauts_int"].ToString().Trim();
						p_objResultArr[i1].stroutpatrecipeMoney=dtResult.Rows[i1]["totailmoney"].ToString().Trim();
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
				lngRes=-2;
			}
			return lngRes;
		}
		#endregion
        #region 根据序列id获得病人处方
        /// <summary>
        /// 根据序列id获得病人处方
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strSid_int"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMainRecipe(System.Security.Principal.IPrincipal p_objPrincipal,string m_strSid_int, out clsOutpatientRecipe_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsOutpatientRecipe_VO[0];
            //权限
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetMainRecipe");
            if (lngRes < 0)
            {
                return -1;
            }

            DataTable dtResult = new DataTable();
            string strSQL = @"select a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
       a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
       a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
       a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr, a.groupid_chr,
       a.type_int, a.confirm_int, a.confirmdesc_vchr, a.createtype_int,
       a.deptmed_int, b.name_vchr, c.lastname_vchr, d.deptname_vchr,
       e.lastname_vchr as recordemp, f.diag_vchr, h.homeaddress_vchr,
       h.homephone_vchr, h.govcard_chr, h.difficulty_vchr, h.insuranceid_vchr,
       f.recorddate_dat, k.paytypename_vchr, p.diag_vchr, j.patientcardid_chr,
       (select sum (totalsum_mny)
          from t_opr_outpatientrecipeinv a,
               t_opr_recipesend b,
               t_opr_recipesendentry c
         where a.outpatrecipeid_chr = c.outpatrecipeid_chr
           and b.sid_int = c.sid_int
           and b.sid_int = ?
           and totalsum_mny > 0) totailmoney
  from t_opr_recipesend m,
       t_opr_recipesendentry n,
       t_opr_outpatientrecipe a,
       t_bse_patientidx b,
       t_bse_employee c,
       t_bse_deptdesc d,
       t_bse_employee e,
       t_opr_outpatientcasehis f,
       t_bse_patient h,
       t_bse_patientpaytype k,
       t_bse_patientcard j,
       t_opr_outpatientcasehis p
 where m.sid_int = n.sid_int
   and a.outpatrecipeid_chr = n.outpatrecipeid_chr
   and a.patientid_chr = b.patientid_chr(+)
   and a.diagdr_chr = c.empid_chr(+)
   and a.diagdept_chr = d.deptid_chr(+)
   and a.recordemp_chr = e.empid_chr(+)
   and a.casehisid_chr = f.casehisid_chr(+)
   and a.patientid_chr = h.patientid_chr(+)
   and a.paytypeid_chr = k.paytypeid_chr(+)
   and a.patientid_chr = j.patientid_chr(+)
   and a.casehisid_chr = p.casehisid_chr(+)
   and m.sid_int = ?
";
           
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value =m_strSid_int;
                objLisAddItemRefArr[1].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);

                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsOutpatientRecipe_VO[dtResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsOutpatientRecipe_VO();


                        p_objResultArr[i1].CONFIRM_INT = int.Parse(dtResult.Rows[i1]["CONFIRM_INT"].ToString());
                        p_objResultArr[i1].strDIAG_VCHR = dtResult.Rows[i1]["DIAG_VCHR"].ToString().Trim();
                        p_objResultArr[i1].strHOMEADDRESS_VCHR = dtResult.Rows[i1]["HOMEADDRESS_VCHR"].ToString().Trim();


                        p_objResultArr[i1].HOMEPHONE_VCHR = dtResult.Rows[i1]["HOMEPHONE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].strRECORDDATE_DAT = dtResult.Rows[i1]["RECORDDATE_DAT"].ToString().Trim();
                        p_objResultArr[i1].strDIAG_VCHR = dtResult.Rows[i1]["DIAG_VCHR"].ToString().Trim();


                        p_objResultArr[i1].m_strOutpatRecipeID = dtResult.Rows[i1]["outpatrecipeid_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strOutpatRecipeNo = dtResult.Rows[i1]["outpatrecipeno_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strRecordDate = dtResult.Rows[i1]["recorddate_dat"].ToString().Trim();
                        p_objResultArr[i1].m_strRegisterID = dtResult.Rows[i1]["registerid_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strCreateDate = dtResult.Rows[i1]["createdate_dat"].ToString().Trim();
                        p_objResultArr[i1].m_objRecordEmp = new clsEmployeeVO();
                        p_objResultArr[i1].m_objRecordEmp.strEmpID = dtResult.Rows[i1]["recordemp_chr"].ToString().Trim();
                        p_objResultArr[i1].m_objRecordEmp.strLastName = dtResult.Rows[i1]["recordemp"].ToString().Trim();
                        p_objResultArr[i1].m_objPatient = new clsPatientVO();
                        p_objResultArr[i1].m_objPatient.strPatientID = dtResult.Rows[i1]["patientid_chr"].ToString().Trim();
                        p_objResultArr[i1].m_objPatient.strPatientCardID = dtResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_objPatient.m_strDIFFICULTY_VCHR = dtResult.Rows[i1]["DIFFICULTY_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_objPatient.objPatType = new clsPatientType_VO();
                        p_objResultArr[i1].m_objPatient.objPatType.m_strPayTypeName = dtResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_objPatient.m_strGOVCARD_CHR = dtResult.Rows[i1]["GOVCARD_CHR"].ToString().Trim();

                        p_objResultArr[i1].m_objPatient.strInsuranceID = dtResult.Rows[i1]["INSURANCEID_VCHR"].ToString().Trim();



                        p_objResultArr[i1].m_objPatient.strName = dtResult.Rows[i1]["name_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_objDiagDr = new clsEmployeeVO();
                        p_objResultArr[i1].m_objDiagDr.strEmpID = dtResult.Rows[i1]["diagdr_chr"].ToString().Trim();
                        p_objResultArr[i1].m_objDiagDr.strLastName = dtResult.Rows[i1]["lastname_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_objDiagDept = new clsDepartmentVO();
                        p_objResultArr[i1].m_objDiagDept.strDeptID = dtResult.Rows[i1]["diagdept_chr"].ToString().Trim();
                        p_objResultArr[i1].m_objDiagDept.strDeptName = dtResult.Rows[i1]["deptname_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_intPStatus = dtResult.Rows[i1]["pstauts_int"].ToString().Trim();
                        p_objResultArr[i1].stroutpatrecipeMoney = dtResult.Rows[i1]["totailmoney"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion
		#region 获取处方详细资料
		/// <summary>
		/// 获取处方详细资料
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="OUTPATRECIPEID">处方记录ID</param>
		/// <param name="dtbResult">返回数据表</param>
		/// <returns></returns>

		[AutoComplete]
		public long m_lngGetItemData(System.Security.Principal.IPrincipal p_objPrincipal,
			string OUTPATRECIPEID,out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult=new DataTable();
			//权限
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetItemData");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL=@"SELECT DISTINCT a.registerid_chr,a.OUTPATRECIPEID_CHR, a.patientid_chr, b.name_vchr,
										      c.registerno_chr, c.registerdate_dat
										 FROM t_opr_outpatientrecipe a,
										      t_bse_patientidx b,
											  t_opr_patientregister c,
											  T_BSE_DEPTDESC d,
                                              T_BSE_EMPLOYEE e,
                                              T_BSE_EMPLOYEE f
									    WHERE a.patientid_chr = b.patientid_chr
											  AND a.registerid_chr = c.registerid_chr(+)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);	

			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;

		}


		#endregion

		#region 模糊查询发药的处方队列
		/// <summary>
		/// 模糊查询发药的处方队列
		/// </summary>
		/// <param name="p_strWhere">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		private long lngGetMedRecipeListByAny(string p_strWhere,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			DataTable dtbResult = new DataTable();
			string strSQL = @"SELECT *
								FROM v_opr_medrecipesend " + p_strWhere;
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);	


				if(dtbResult != null && dtbResult.Rows.Count >0)
				{
					int intRow = dtbResult.Rows.Count;
					p_objResultArr = new clsMedRecipeSend_VO[intRow];
					for(int i=0;i<intRow;i++)
					{
						p_objResultArr[i] = new clsMedRecipeSend_VO();
						p_objResultArr[i].m_objWindow = new clsOPMedStoreWin_VO();
						p_objResultArr[i].m_objWindow.m_objMedStore = new clsMedStore_VO();
						p_objResultArr[i].m_objSendEmp = new clsEmployeeVO();
						p_objResultArr[i].m_objTreatEmp = new clsEmployeeVO();

						p_objResultArr[i].m_strOutpatRecipeID = dtbResult.Rows[i]["outpatrecipeid_chr"].ToString().Trim();
						p_objResultArr[i].m_intRecipeType = Convert.ToInt32(dtbResult.Rows[i]["recipetype_int"].ToString().Trim());
						p_objResultArr[i].m_objWindow.m_strWindowID = dtbResult.Rows[i]["windowid_chr"].ToString().Trim();
						p_objResultArr[i].m_objWindow.m_strWindowName = dtbResult.Rows[i]["windowname_vchr"].ToString().Trim();
						p_objResultArr[i].m_objWindow.m_objMedStore.m_strMedStoreID = dtbResult.Rows[i]["medstoreid_chr"].ToString().Trim();
						p_objResultArr[i].m_objWindow.m_objMedStore.m_strMedStoreName = dtbResult.Rows[i]["medstorename_vchr"].ToString().Trim();
						p_objResultArr[i].m_objWindow.m_objMedStore.m_intMedStoreType = Convert.ToInt32(dtbResult.Rows[i]["medstoretype_int"].ToString().Trim());
						p_objResultArr[i].m_objWindow.m_objMedStore.m_intMedicneType = Convert.ToInt32(dtbResult.Rows[i]["medicnetype_int"].ToString().Trim());
						p_objResultArr[i].m_intPStatus = Convert.ToInt32(dtbResult.Rows[i]["pstatus_int"].ToString().Trim());
						p_objResultArr[i].m_strSendDate = dtbResult.Rows[i]["senddate_dat"].ToString().Trim();
						p_objResultArr[i].m_objSendEmp.strEmpID = dtbResult.Rows[i]["sendemp_chr"].ToString().Trim();
						p_objResultArr[i].m_strTreatDate = dtbResult.Rows[i]["treatdate_dat"].ToString().Trim();
						p_objResultArr[i].m_objTreatEmp.strEmpID = dtbResult.Rows[i]["treatemp_chr"].ToString().Trim();
					}
				}
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;
		}
		#endregion

		#region 通过窗口ID取当前需要发药的处方队列
		/// <summary>
		/// 通过窗口ID取当前需要发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strID">窗口ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinID(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strID,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByWinID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strID.Trim() + "' AND pstatus_int = 1";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过处方ID取当前需要发药的处方队列
		/// <summary>
		/// 通过处方ID取当前需要发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strID">处方ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByOPID(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strID,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByOPID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(outpatrecipeid_chr) = '" + p_strID.Trim() + "' AND p_status_int = 1";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过窗口号和处方类型取发药的处方队列
		/// <summary>
		/// 通过窗口号和处方类型取发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strID">窗口号</param>
		/// <param name="p_intType">处方类型，1：西药，2：中药</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinAndType(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strID,int p_intType,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByType");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strID.Trim() + "' AND recipetype_int = " + p_intType.ToString() + " ";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过窗口号和处方状态取发药的处方队列
		/// <summary>
		/// 通过窗口号和处方状态取发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strID">窗口号</param>
		/// <param name="p_intStatus">处方状态，1：新建，2：已发药...</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinAndStatus(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strID,int p_intStatus,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByWinAndStatus");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strID.Trim() + "' AND pstatus_int = " + p_intStatus.ToString() + " ";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过窗口号和发送员取发药的处方队列
		/// <summary>
		/// 通过窗口号和发送员取发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strWinID">窗口号</param>
		/// <param name="p_strEmpID">发送员工号</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinAndSendEmp(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strWinID,string p_strEmpID,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByWinAndSendEmp");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strWinID.Trim() + "' AND TRIM(sendemp_chr) = '" + p_strEmpID.Trim() + "'" ;

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过窗口号和发送时间取发药的处方队列
		/// <summary>
		/// 通过窗口号和发送时间取发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strWinID">窗口号</param>
		/// <param name="p_strDate">发送时间</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinAndSendDate(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strWinID,string p_strDate,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByWinAndSendDate");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strWinID.Trim() + "' AND senddate_dat = TO_DATE( '" + p_strDate.Trim() + "','yyyy-mm-dd')";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过窗口号和处理员取发药的处方队列
		/// <summary>
		/// 通过窗口号和处理员取发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strWinID">窗口号</param>
		/// <param name="p_strEmpID">处理员工号</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinAndTreatEmp(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strWinID,string p_strEmpID,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByWinAndTreatEmp");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strWinID.Trim() + "' AND TRIM(treatemp_chr) = '" + p_strEmpID.Trim() + "";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 通过窗口号和处理时间取发药的处方队列
		/// <summary>
		/// 通过窗口号和处理时间取发药的处方队列
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strWinID">窗口号</param>
		/// <param name="p_strDate">处理时间</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedRecipeListByWinAndTreatDate(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strWinID,string p_strDate,out clsMedRecipeSend_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedRecipeSend_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetMedRecipeListByWinAndTreatDate");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @" WHERE TRIM(windowid_chr) = '" + p_strWinID.Trim() + "' AND treatdate_dat = TO_DATE( '" + p_strDate.Trim() + "','yyyy-mm-dd')";

			lngRes = lngGetMedRecipeListByAny(strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 查找收费项目的源ID
		[AutoComplete]
		public long m_lngGetID(System.Security.Principal.IPrincipal p_objPrincipal,string NewID,
			out string  oldID)
		{
			long lngRes = 0;
			oldID="";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetID");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
			string strSQL = @"select ITEMSRCID_VCHR from t_bse_chargeitem where ITEMID_CHR='"+NewID+"'";
			DataTable bt=new DataTable();
			try
			{
				lngRes=HRPSvc.DoGetDataTable(strSQL,ref bt);
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(bt.Rows.Count>0)
			{
				oldID=bt.Rows[0]["ITEMSRCID_VCHR"].ToString();
			}
			return lngRes;
		}

		#endregion

		#region 通过ID更改药品处方发送记录的状态
		/// <summary>
		/// 通过ID更改发药的处方记录的状态
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objItem">处方发送数据</param>
		///  <param name="winID">窗口ID</param>
		///  <param name="stroageID">药房ID</param>
		///  <param name="strTOLMNY">总金额</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpdateMedRecipeListByID(System.Security.Principal.IPrincipal p_objPrincipal,string winID,
			clsMedRecipeSend_VO p_objItem,DataTable dtbStorageDe,string stroageID,string strTOLMNY,clst_opr_nurseexecute[] nurseexecuteArr)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngUpdateMedRecipeListByID");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
            string strSQL = @"update t_opr_recipesend
       set autoprint_int = ?,
       pstatus_int = ?,
       finaltreateemp_chr = ?,
       sendemp_chr = ?,
       senddate_dat = SYSDATE
       where sid_int = ? and sendwindowid_chr = ?";
			try
			{
                System.Data.IDataParameter[] paramArr = null;
                HRPSvc.CreateDatabaseParameter(6, out paramArr);
                paramArr[0].Value = p_objItem.m_AUTOPRINT_INT;
                paramArr[1].Value = p_objItem.m_intPStatus;
                paramArr[2].Value = string.Empty;
                paramArr[3].Value = p_objItem.m_objSendEmp.strEmpID;
                paramArr[4].Value = p_objItem.m_intSID;
                paramArr[5].Value = winID;

                long lngRecordsAffected = -1;
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(lngRes==1)
			{
                clsmedstorewinque p_objVO = new clsmedstorewinque();
                p_objVO.m_strMEDSTOREID_CHR=nurseexecuteArr[0].m_strFrom;
                p_objVO.m_strWINDOWID_CHR = nurseexecuteArr[0].m_strWindow;
                p_objVO.m_strOUTPATRECIPEID_CHR = nurseexecuteArr[0].m_strOUTPATRECIPEID_CHR;
                p_objVO.m_intWINDOWTYPE_INT = 0;
                clsWindowsCortrol windowsctl=new clsWindowsCortrol();
                windowsctl.m_lngDeleWinque(p_objPrincipal, p_objVO);
				com.digitalwave.iCare.middletier.HIS.clsMedStorageManage mange = new clsMedStorageManage();
				DataTable dtDe=new DataTable();
				#region 向药房出库表插入数据
				string newid="";
				#region 获取财务期

                strSQL = @"select periodid_chr
                           from t_bse_period
                           where startdate_dat <=
                           to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                           and enddate_dat >=
                           to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
				DataTable dt=new DataTable();
				string priID="";
				try
				{   
                   System.Data.IDataParameter[] paramArr = null;
                   HRPSvc.CreateDatabaseParameter(2, out paramArr);
                   paramArr[0].Value = DateTime.Now.ToString();
                   paramArr[1].Value = DateTime.Now.ToString();
                   lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
				}		
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
				if(dt.Rows.Count>0)
				{
						priID=dt.Rows[0][0].ToString();
				}
				#endregion

				#region 获取出库类型

                strSQL = @"select medstoreordtypeid_chr
                           from t_aid_medstoreordtype
                           where medstoreordtype_vchr = '药房发药出库'";
				string OrdType="";
				try
				{
					lngRes=HRPSvc.DoGetDataTable(strSQL,ref dt);
				}		
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
				if(dt.Rows.Count>0)
				{
					OrdType=dt.Rows[0][0].ToString();
				}
				#endregion
                
                //HRPSvc.m_lngGenerateNewID("t_opr_medstoreord", "MEDSTOREORDID_CHR", out newid);

                //序列ID               
                DataTable dt1 = new DataTable();
                string SQL = @"select lpad (seq_medstoreordid.nextval, 18, '0')
                               from dual";
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt1);
                if (lngRes > 0)
                {
                    newid = dt1.Rows[0][0].ToString();
                }

                strSQL = @"insert into t_opr_medstoreord
            (medstoreordid_chr, medstoreid_chr, orddate_dat, tolmny_mny,
             periodid_chr, memo_vchr, creator_chr, createdate_dat, srcid_chr,
             srctype_int, medstoreordtypeid_chr, pstatus_int, outflan_int,
             aduitemp_chr, aduitdate_dat
            )
            values (?, ?, SYSDATE, ?,
             ?, '药房发药出库单', ?, SYSDATE, ?,
             1, ?, 2, 2,
             ?, SYSDATE
            )";
				try
				{
                    System.Data.IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(8, out paramArr);
                    paramArr[0].Value = newid;
                    paramArr[1].Value = stroageID;
                    paramArr[2].Value = strTOLMNY;
                    paramArr[3].Value = priID;
                    paramArr[4].Value = p_objItem.m_objTreatEmp.strEmpID;
                    paramArr[5].Value = p_objItem.m_strOutpatRecipeID;
                    paramArr[6].Value = OrdType;
                    paramArr[7].Value = p_objItem.m_objTreatEmp.strEmpID;
                    long lngRecordsAffected = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
				}		
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
				for(int i1=0;i1<dtbStorageDe.Rows.Count;i1++)
				{
					string newDeid="";
					int Row=i1+1;
                    strSQL = @"insert into t_opr_medstoreordde
            (medstoreorddeid_chr, medstoreordid_chr, medicineid_chr,
             rowno_chr, qty_dec, saleunitprice_dec, saletolprice_dec,
             unitid_chr
            )
           values (seq_medstoreorddeid18.nextval, ?, ?,
             ?, ?, ?, ?,
             ?
            )";
                    try
                    {

                        System.Data.IDataParameter[] paramArr = null;
                        HRPSvc.CreateDatabaseParameter(7, out paramArr);
                        paramArr[0].Value = newid;
                        paramArr[1].Value = dtbStorageDe.Rows[i1]["itemsrcid_vchr"].ToString().Trim();
                        paramArr[2].Value = Row.ToString("000");
                        paramArr[3].Value = dtbStorageDe.Rows[i1]["QTY_DEC"].ToString().Trim();
                        paramArr[4].Value = dtbStorageDe.Rows[i1]["PRICE_MNY"].ToString().Trim();
                        paramArr[5].Value = dtbStorageDe.Rows[i1]["TOLPRICE_MNY"].ToString().Trim();
                        paramArr[6].Value = dtbStorageDe.Rows[i1]["UNITID_CHR"].ToString().Trim();
                        long lngRecordsAffected = -1;
                        lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
				}
				#endregion
			}
			return lngRes;
		}
		#endregion

		#region 通过ID更改药品处方发送记录的状态(是否自动打印过)
		/// <summary>
		/// 通过ID更改发药的处方记录的状态(是否自动打印过)
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="arrList">处方发送数据</param>
		///  <param name="winID">窗口ID</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpdateMedRecipeListByID(System.Security.Principal.IPrincipal p_objPrincipal,string winID,System.Collections.ArrayList arrList,int m_intFlag)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngUpdateMedRecipeListByID");
			if(lngRes < 0)
			{
				return -1;
			}
			if(arrList.Count>0)
			{
				
				for(int i1=0;i1<arrList.Count;i1++)
				{
                    m_lngPrintSucc(winID, int.Parse(arrList[i1].ToString()),m_intFlag);
				}
			}
			return lngRes;
		}
		#endregion

		#region 写入已打印标志
		/// <summary>
		/// 写入已打印标志
		/// </summary>
		/// <param name="winID"></param>
		/// <param name="currOutid"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngPrintSucc(string winID,int m_intSID,int m_intFlag)
		{
			long lngRes = 0;
            string strSQL="";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
            if (m_intFlag == 0)
            {
                strSQL = @"UPDATE t_opr_recipesend
								 SET  AUTOPRINT_INT = 1
                                 WHERE sid_int=" + m_intSID + " and WINDOWID_CHR='" + winID + "'";
            }
            else
            {
                strSQL = @"UPDATE t_opr_recipesend
								 SET  AUTOPRINT_INT = 1,INJECTPRINT_INT = 1
                                 WHERE sid_int=" + m_intSID + " and WINDOWID_CHR='" + winID + "'";
            }
			
			try
			{
				lngRes=HRPSvc.DoExcute(strSQL);
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}


		#endregion

        #region 通过ID更改药品处方发送记录的状态(是否自动打印过注射单)
        /// <summary>
        /// 通过ID更改药品处方发送记录的状态(是否自动打印过注射单)
        /// </summary>
        /// <param name="p_objPrincipal">安全标识</param>
        /// <param name="arrList">处方发送数据</param>
        ///  <param name="winID">窗口ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateRecipeSendTableByID(System.Security.Principal.IPrincipal p_objPrincipal, string winID, System.Collections.ArrayList arrList)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngUpdateRecipeSendTableByID");
            if (lngRes < 0)
            {
                return -1;
            }
            if (arrList.Count > 0)
            {

                for (int i1 = 0; i1 < arrList.Count; i1++)
                {
                    m_lngPrintSuccessful(winID, int.Parse(arrList[i1].ToString()));
                }
            }
            return lngRes;
        }
        #endregion

        #region 写入已打印标志
        /// <summary>
        /// 写入已打印标志
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="currOutid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPrintSuccessful(string winID, int m_intSID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();

            string strSQL = @"UPDATE t_opr_recipesend
								 SET  INJECTPRINT_INT = 1
                                 WHERE sid_int=" + m_intSID + " and WINDOWID_CHR='" + winID + "'";

            try
            {
                lngRes = HRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }


        #endregion
		#region 把记录设为无效
		/// <summary>
		/// 把记录设为无效
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="winID"></param>
		/// <param name="outID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpdataByID(System.Security.Principal.IPrincipal p_objPrincipal,string winID,
			string outID,int m_intSID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngUpdateMedRecipeListByID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_opr_recipesend
								 SET PSTATUS_INT=3
							   WHERE sid_int="+m_intSID+" and WINDOWID_CHR='"+winID+"'";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
				lngRes=HRPSvc.DoExcute(strSQL);
				
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;
		}
		#endregion

		#region 通过ID门诊处方记录的状态
		/// <summary>
		/// 通过ID更改发药的处方记录的状态
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objItem">处方发送数据</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpdateMedCiPeByID(System.Security.Principal.IPrincipal p_objPrincipal,string winID,int m_intSID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngUpdateMedCiPeByID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_opr_recipesend
								 SET PSTATUS_INT=2  WHERE sid_int="+m_intSID+" and WINDOWID_CHR='"+winID+"'";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
				lngRes=HRPSvc.DoExcute(strSQL);
				
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			return lngRes;
		}
		#endregion

		#region//查找员工名称
		[AutoComplete]
		public long m_lngfinedata(System.Security.Principal.IPrincipal obj_Principal,string P_strID,out string p_strName,out string p_strID)
		{
			long lngRes=0;
			p_strName = null;
			p_strID=null;
            string strSQL = @"select lastname_vchr, empid_chr
  from t_bse_employee
 where empno_chr = ?";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(obj_Principal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngfinedata");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = P_strID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, param);
				if(dtbResult.Rows.Count>0)
				{
					p_strName= dtbResult.Rows[0][0].ToString().Trim();
					p_strID= dtbResult.Rows[0][1].ToString().Trim();
				}
				else
				{
					p_strName="";
					p_strID="";
				}
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}	

		#endregion

		#region//根据处方ID查找员工名称及工号
		[AutoComplete]
		public long m_lngFinaEmp(System.Security.Principal.IPrincipal obj_Principal,string p_patrecipeid,out string P_strID,out string p_strName)
		{
			long lngRes=0;
			p_strName = null;
			P_strID=null;
            string strSQL = @"select a.TREATEMP_CHR, b.LASTNAME_VCHR FROM T_OPR_RECIPESEND a,T_BSE_EMPLOYEE b,t_opr_recipesendentry c
                              WHERE a.sid_int=c.sid_int
                              c.OUTPATRECIPEID_CHR='" + p_patrecipeid + "' AND a.TREATEMP_CHR=b.EMPNO_CHR";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(obj_Principal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngFinaEmp");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				if(dtbResult.Rows.Count>0)
				{
					P_strID=dtbResult.Rows[0]["TREATEMP_CHR"].ToString().Trim();
					p_strName= dtbResult.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
				}
				else
				{
					P_strID="";
					p_strName="";
				}
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}	

		#endregion

        #region 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细及病人信息
        /// <summary>
        /// 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细及病人信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOPRecID">处方ID</param>
        /// <param name="p_strWinID">窗口ID</param>
        /// <param name="p_dtOutPatrecIp">处方信息</param>
        /// <param name="p_dtItemDe">处方明细信息</param>
        /// <param name="flag">标志位,1-发药，配药 2-门诊审核处方</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrintItem(System.Security.Principal.IPrincipal p_objPrincipal,
            int m_intSID, string p_strWinID, out DataTable p_dtOutPatrecIp, out DataTable p_dtItemDe, int flag)
        {
            long lngRes = 0;
            p_dtItemDe = new DataTable();
            p_dtOutPatrecIp = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetOPRecipeListByWinAndOpRecAndType");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.sid_int, a.serno_chr, a.sendwindowid_chr as sendwindowid,
       a.medstoreid_chr, a.injectprint_int, a.returnemp_chr, a.returndate_dat,
       a.senddate_dat as givedate_dat, a.autoprint_int,
       a.sendemp_chr as giveemp_chr, a.senddate_dat, a.sendemp_chr,
       a.treatdate_dat, a.windowid_chr, a.treatemp_chr, a.pstatus_int,
       i.outpatrecipeid_chr, b.type_int as recipetype_int,
       b.pstauts_int as breakpstatus, c.name_vchr, c.sex_chr, c.idcard_chr,
       r.typename_vchr, c.birth_dat, c.patientid_chr, d.registerno_chr,
       d.registerdate_dat, e.patientcardid_chr,
       decode (f.internalflag_int,
               0, '自费',
               1, '公费',
               2, '医保'
              ) as internalname,
       f.paytypename_vchr,f.paytypeid_chr, j.invoiceno_vchr, j.split_int, j.status_int,
       j.recorddate_dat, g.lastname_vchr, k.empno_chr as opremp_chr,
       k.lastname_vchr as checkname, m.lastname_vchr as sendname,
       p.homephone_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patientidx c,
       t_opr_patientregister d,
       t_bse_patientcard e,
       t_bse_patientpaytype f,
       (select c.recorddate_dat, c.invoiceno_vchr, c.outpatrecipeid_chr,
               c.totalsum_mny, c.opremp_chr, c.status_int, c.split_int
          from (select m.seqid_chr, m.outpatrecipeid_chr
                  from t_opr_outpatientrecipeinv m,
                       t_opr_recipesend n,
                       t_opr_recipesendentry l
                 where m.outpatrecipeid_chr = l.outpatrecipeid_chr
                   and n.sid_int = l.sid_int
                   and n.sid_int = ?) b,
               t_opr_outpatientrecipeinv c
         where b.seqid_chr = c.seqid_chr) j,
       t_opr_reciperelation h,
       t_bse_employee g,
       t_bse_employee k,
       t_bse_employee m,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.registerid_chr = d.registerid_chr(+)
   and b.patientid_chr = c.patientid_chr
   and b.deptmed_int = 0
   and i.outpatrecipeid_chr = h.outpatrecipeid_chr
   and h.seqid = j.outpatrecipeid_chr
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = m.empid_chr(+)
   and j.opremp_chr = k.empid_chr
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and b.patientid_chr = e.patientid_chr(+)
   and b.paytypeid_chr = f.paytypeid_chr
   and a.sid_int = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = m_intSID;
                paramArr[1].Value = m_intSID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtOutPatrecIp, paramArr);
              
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if(p_dtOutPatrecIp.Rows.Count>0)
            {
                m_lngGetOPRecipeListByWinAndOpRecAndType(p_objPrincipal, m_intSID, p_strWinID, out p_dtItemDe, flag);
            }
            return lngRes;
        }
        #endregion

        #region 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细
        /// <summary>
        /// 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_intsid"></param>
        /// <param name="p_strWinID"></param>
        /// <param name="p_dtItemDe"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
		[AutoComplete]
		public long m_lngGetOPRecipeListByWinAndOpRecAndType(System.Security.Principal.IPrincipal p_objPrincipal,
            int m_intsid, string p_strWinID, out DataTable p_dtItemDe, int flag)
		{
			long lngRes = 0;
            p_dtItemDe = new DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetOPRecipeListByWinAndOpRecAndType");
			if(lngRes < 0)
			{
				return -1;
			}
            string strSQL = string.Empty;
            if (flag != 3)
            {
                #region old
                //                strSQL = @"select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
//       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
//       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
//       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
//       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
//       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
//       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
//       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
//       opusagedesc, itemsrcid_vchr
//  from (select   a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr,
//                 a.itemid_chr, a.unitid_chr, a.tolqty_dec as qty_dec,
//                 a.unitprice_mny as price_mny, a.tolprice_mny,
//                 a.medstoreid_chr, a.usageid_chr, a.days_int, a.freqid_chr,
//                 d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
//                 a.dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty,
//                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
//                 e.freqname_chr, 0 times_int, 0 min_qty_dec1, 0 min_qty_dec,
//                 '' sumusage_vchr, 't_opr_outpatientpwmrecipede' as fromtable,
//                 b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
//                 g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr,
//                 e.times_int as times_int1, e.days_int as days_int1,
//                 b.dosage_dec as basicdosage, e.opfredesc_vchr as freqdesc,
//                 b.itemipunit_chr, d.putmed_int, d.opusagedesc,
//                 b.itemsrcid_vchr
//            from t_opr_recipesend m,
//                 t_opr_recipesendentry n,
//                 t_opr_outpatientpwmrecipede a,
//                 t_bse_chargeitem b,
//                 t_bse_chargeitemextype f,
//                 t_bse_usagetype d,
//                 t_aid_recipefreq e,
//                 t_bse_medicine g
//           where m.sid_int = n.sid_int
//             and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//             and a.itemid_chr = b.itemid_chr
//             and a.deptmed_int = 0
//             and m.sid_int = ?
//             and a.windowid_chr = ?
//             and b.itemopinvtype_chr = f.typeid_chr
//             and f.flag_int = 2
//             and a.usageid_chr = d.usageid_chr(+)
//             and a.freqid_chr = e.freqid_chr(+)
//             and b.itemsrcid_vchr = g.medicineid_chr(+)
//        order by a.rowno_chr, a.itemname_vchr)
//union all
//select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
//       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
//       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
//       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
//       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
//       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
//       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
//       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
//       opusagedesc, itemsrcid_vchr
//  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
//                 a.itemid_chr, a.unitid_chr,
//                 (a.qty_dec * a.times_int) as qty_dec,
//                 a.unitprice_mny as price_mny, a.tolprice_mny,
//                 a.medstoreid_chr, '' usageid_chr, 0 as days_int,
//                 '' freqid_chr, d.usagename_vchr,
//                 usagedetail_vchr as desc_vchr, b.itemopinvtype_chr,
//                 b.dosage_dec, a.itemspec_vchr, 0 as dosageqty,
//                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
//                 e.freqname_chr, a.times_int, a.min_qty_dec as min_qty_dec1,
//                 a.min_qty_dec, a.sumusage_vchr,
//                 't_opr_outpatientcmrecipede' as fromtable,
//                 b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
//                 g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr,
//                 e.times_int as times_int1, e.days_int as days_int1,
//                 b.dosage_dec as basicdosage, e.opfredesc_vchr as freqdesc,
//                 b.itemipunit_chr, d.putmed_int, d.opusagedesc,
//                 b.itemsrcid_vchr
//            from t_opr_recipesend m,
//                 t_opr_recipesendentry n,
//                 t_opr_outpatientcmrecipede a,
//                 t_bse_chargeitem b,
//                 t_bse_chargeitemextype f,
//                 t_bse_usagetype d,
//                 t_aid_recipefreq e,
//                 t_bse_medicine g
//           where m.sid_int = n.sid_int
//             and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//             and a.itemid_chr = b.itemid_chr
//             and a.deptmed_int = 0
//             and m.sid_int = ?
//             and a.windowid_chr = ?
//             and a.itemid_chr = e.freqid_chr(+)
//             and b.itemopinvtype_chr = f.typeid_chr
//             and f.flag_int = 2
//             and a.usageid_chr = d.usageid_chr(+)
//             and b.itemsrcid_vchr = g.medicineid_chr(+)
//        order by a.rowno_chr, a.itemname_vchr)
//union all
//select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
//       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
//       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
//       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
//       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
//       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
//       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
//       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
//       opusagedesc, itemsrcid_vchr
//  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
//                 a.itemid_chr, a.unitid_chr, a.qty_dec as qty_dec,
//                 a.unitprice_mny as price_mny, a.tolprice_mny,
//                 a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
//                 '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
//                 b.itemopinvtype_chr, 0 as dosage_dec, a.itemspec_vchr,
//                 a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
//                 f.typename_vchr, '' freqname_chr, 0 times_int,
//                 0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
//                 't_opr_outpatientothrecipede' as fromtable,
//                 b.itemsrcid_vchr as medicineid_chr,
//                 b.dosage_dec as discount_dec, g.mednormalname_vchr,
//                 0 type_int, a.itemunit_vchr, g.medicinetypeid_chr,
//                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
//                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
//                 b.itemsrcid_vchr
//            from t_opr_recipesend m,
//                 t_opr_recipesendentry n,
//                 t_opr_outpatientothrecipede a,
//                 t_bse_chargeitem b,
//                 t_bse_chargeitemextype f,
//                 t_bse_medicine g
//           where m.sid_int = n.sid_int
//             and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//             and a.itemid_chr = b.itemid_chr
//             and a.deptmed_int = 0
//             and m.sid_int = ?
//             and a.windowid_chr = ?
//             and b.itemopinvtype_chr = f.typeid_chr
//             and b.itemsrcid_vchr = g.medicineid_chr(+)
//        order by a.rowno_chr, a.itemname_vchr)
//union all
//select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
//       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
//       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
//       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
//       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
//       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
//       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
//       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
//       opusagedesc, itemsrcid_vchr
//  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
//                 a.itemid_chr, '' unitid_chr, a.qty_dec as qty_dec,
//                 a.price_mny as price_mny, a.tolprice_mny, a.medstoreid_chr,
//                 '' as usageid_chr, 0 as days_int, '' as freqid_chr,
//                 '' as usagename_vchr, '' as desc_vchr, b.itemopinvtype_chr,
//                 0 as dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty,
//                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
//                 '' freqname_chr, 0 times_int, 0 min_qty_dec1, 0 min_qty_dec,
//                 '' sumusage_vchr, 't_opr_outpatientchkrecipede' as fromtable,
//                 b.itemsrcid_vchr as medicineid_chr,
//                 b.dosage_dec as discount_dec, '' as mednormalname_vchr,
//                 a.itemunit_vchr, '' medicinetypeid_chr, 0 times_int1,
//                 0 days_int1, b.dosage_dec as basicdosage, '' freqdesc,
//                 b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
//                 b.itemsrcid_vchr
//            from t_opr_recipesend m,
//                 t_opr_recipesendentry n,
//                 t_opr_outpatientchkrecipede a,
//                 t_bse_chargeitem b,
//                 t_bse_chargeitemextype f
//           where m.sid_int = n.sid_int
//             and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//             and a.itemid_chr = b.itemid_chr
//             and m.sid_int = ?
//             and a.windowid_chr = ?
//             and b.itemopinvtype_chr = f.typeid_chr
//        order by a.rowno_chr, a.itemname_vchr)
//union all
//select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
//       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
//       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
//       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
//       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
//       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
//       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
//       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
//       opusagedesc, itemsrcid_vchr
//  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
//                 a.itemid_chr, '' unitid_chr, a.qty_dec as qty_dec,
//                 a.price_mny as price_mny, a.tolprice_mny, a.medstoreid_chr,
//                 '' as usageid_chr, 0 as days_int, '' as freqid_chr,
//                 '' as usagename_vchr, '' as desc_vchr, b.itemopinvtype_chr,
//                 0 as dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty,
//                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
//                 '' freqname_chr, 0 times_int, 0 min_qty_dec1, 0 min_qty_dec,
//                 '' sumusage_vchr,
//                 't_opr_outpatienttestrecipede' as fromtable,
//                 b.itemsrcid_vchr as medicineid_chr,
//                 b.dosage_dec as discount_dec, '' as mednormalname_vchr,
//                 0 type_int, a.itemunit_vchr, '' medicinetypeid_chr,
//                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
//                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
//                 b.itemsrcid_vchr
//            from t_opr_recipesend m,
//                 t_opr_recipesendentry n,
//                 t_opr_outpatienttestrecipede a,
//                 t_bse_chargeitem b,
//                 t_bse_chargeitemextype f
//           where m.sid_int = n.sid_int
//             and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//             and a.itemid_chr = b.itemid_chr
//             and m.sid_int = ?
//             and a.windowid_chr = ?
//             and b.itemopinvtype_chr = f.typeid_chr
//        order by a.rowno_chr, a.itemname_vchr)
//union all
//select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
//       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
//       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
//       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
//       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
//       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
//       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
//       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
//       opusagedesc, itemsrcid_vchr
//  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
//                 a.itemid_chr, '' unitid_chr, a.qty_dec as qty_dec,
//                 a.price_mny as price_mny, a.tolprice_mny, a.medstoreid_chr,
//                 '' as usageid_chr, 0 as days_int, '' as freqid_chr,
//                 '' as usagename_vchr, '' as desc_vchr, b.itemopinvtype_chr,
//                 0 as dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty,
//                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
//                 '' freqname_chr, 0 times_int, 0 min_qty_dec1, 0 min_qty_dec,
//                 '' sumusage_vchr, 't_opr_outpatientopsrecipede' as fromtable,
//                 b.itemsrcid_vchr as medicineid_chr,
//                 b.dosage_dec as discount_dec, '' as mednormalname_vchr,
//                 0 type_int, a.itemunit_vchr, '' medicinetypeid_chr,
//                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
//                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
//                 b.itemsrcid_vchr
//            from t_opr_recipesend m,
//                 t_opr_recipesendentry n,
//                 t_opr_outpatientopsrecipede a,
//                 t_bse_chargeitem b,
//                 t_bse_chargeitemextype f
//           where m.sid_int = n.sid_int
//             and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//             and a.itemid_chr = b.itemid_chr
//             and m.sid_int = ?
//             and a.windowid_chr = ?
//             and b.itemopinvtype_chr = f.typeid_chr
//        order by a.rowno_chr, a.itemname_vchr)
                //";
                #endregion
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                    DataTable p_dtTemp = new DataTable();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    strSQL = @"select   a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
         a.unitid_chr, a.tolqty_dec as qty_dec, a.unitprice_mny as price_mny,
         a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
         a.freqid_chr, a.desc_vchr, a.discount_dec, a.dosage_dec,
         a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
         b.itemopinvtype_chr, b.itemcode_vchr, b.itemsrcid_vchr,
         b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as basicdosage,
         b.itemipunit_chr, f.typename_vchr, d.putmed_int, d.opusagedesc,
         d.usagename_vchr, e.times_int as times_int1, e.days_int as days_int1,
         e.opfredesc_vchr as freqdesc, e.freqname_chr, 0 times_int,
         0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
         't_opr_outpatientpwmrecipede' as fromtable, g.mednormalname_vchr,
         '' itemunit_vchr, g.medicinetypeid_chr
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientpwmrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f,
         t_bse_usagetype d,
         t_aid_recipefreq e,
         t_bse_medicine g
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and a.deptmed_int = 0
     and m.sid_int = ?
     and a.windowid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
     and f.flag_int = 2
     and a.usageid_chr = d.usageid_chr(+)
     and a.freqid_chr = e.freqid_chr(+)
     and b.itemsrcid_vchr = g.medicineid_chr(+)
order by a.rowno_chr, a.itemname_vchr";
                
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strWinID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    object[] m_objItemArr;
                    p_dtItemDe = p_dtTemp.Clone();
                    DataRow m_objTempDr;
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select   a.outpatrecipeid_chr,b.dosageunit_chr,a.rowno_chr,a.itemid_chr,
         a.unitid_chr,(a.qty_dec * a.times_int) as qty_dec, a.unitprice_mny as price_mny,
          a.tolprice_mny,a.medstoreid_chr, '' usageid_chr,  0 as days_int,
          '' freqid_chr, usagedetail_vchr as desc_vchr, a.discount_dec, b.dosage_dec,
         a.itemspec_vchr,  0 as dosageqty, a.itemname_vchr,
         b.itemopinvtype_chr,b.itemcode_vchr,  b.itemsrcid_vchr,
         b.itemsrcid_vchr as medicineid_chr,  b.dosage_dec as basicdosage,
         b.itemipunit_chr,f.typename_vchr,d.putmed_int, d.opusagedesc,
         d.usagename_vchr, e.times_int as times_int1, e.days_int as days_int1,
         e.opfredesc_vchr as freqdesc,e.freqname_chr,a.times_int, 
         a.min_qty_dec as min_qty_dec1, a.min_qty_dec, a.sumusage_vchr,
          't_opr_outpatientcmrecipede' as fromtable, g.mednormalname_vchr,
         '' itemunit_vchr,g.medicinetypeid_chr
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientcmrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f,
         t_bse_usagetype d,
         t_aid_recipefreq e,
         t_bse_medicine g
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and a.deptmed_int = 0
     and m.sid_int = ?
     and a.windowid_chr = ?
     and a.itemid_chr = e.freqid_chr(+)
     and b.itemopinvtype_chr = f.typeid_chr
     and f.flag_int = 2
     and a.usageid_chr = d.usageid_chr(+)
     and b.itemsrcid_vchr = g.medicineid_chr(+)
order by a.rowno_chr, a.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strWinID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr, 
         a.unitid_chr,a.qty_dec as qty_dec, a.unitprice_mny as price_mny, 
         a.tolprice_mny,a.medstoreid_chr, '' as usageid_chr, 0 as days_int, 
         '' as freqid_chr, '' as desc_vchr, b.dosage_dec as discount_dec, 0 as dosage_dec,
         a.itemspec_vchr,a.qty_dec as dosageqty,a.itemname_vchr, 
         b.itemopinvtype_chr,b.itemcode_vchr, b.itemsrcid_vchr,
          b.itemsrcid_vchr as medicineid_chr,b.dosage_dec as basicdosage,
         b.itemipunit_chr,f.typename_vchr, 1 putmed_int,  '' opusagedesc,
         '' as usagename_vchr, 0 times_int1, 0 days_int1,
          '' freqdesc, '' freqname_chr,0 times_int,
         0 min_qty_dec1, 0 min_qty_dec,'' sumusage_vchr,
         't_opr_outpatientothrecipede' as fromtable,  g.mednormalname_vchr,
         a.itemunit_vchr,g.medicinetypeid_chr
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientothrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f,
         t_bse_medicine g
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and a.deptmed_int = 0
     and m.sid_int = ?
     and a.windowid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
     and b.itemsrcid_vchr = g.medicineid_chr(+)
order by a.rowno_chr, a.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strWinID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select   a.outpatrecipeid_chr, a.rowno_chr, a.itemid_chr, '' unitid_chr,
         a.qty_dec as qty_dec, a.price_mny as price_mny, a.itemunit_vchr,
         '' medicinetypeid_chr, 0 times_int1, 0 days_int1, a.tolprice_mny,
         a.medstoreid_chr, '' as usageid_chr, 0 as days_int, '' as freqid_chr,
         '' as usagename_vchr, '' as desc_vchr, a.itemspec_vchr,
         a.itemname_vchr, a.qty_dec as dosageqty, b.itemopinvtype_chr,
         b.dosageunit_chr, 0 as dosage_dec, b.itemcode_vchr,
         b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
         b.dosage_dec as basicdosage, '' freqdesc, b.itemipunit_chr,
         1 putmed_int, '' opusagedesc, b.itemsrcid_vchr,
         '' as mednormalname_vchr, f.typename_vchr, '' freqname_chr,
         0 times_int, 0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
         't_opr_outpatientchkrecipede' as fromtable
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientchkrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and m.sid_int = ?
     and a.windowid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
order by a.rowno_chr, a.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strWinID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select   a.outpatrecipeid_chr, a.rowno_chr, a.itemid_chr, a.itemunit_vchr,
         '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
         a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
         '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
         0 as dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty,
         a.itemname_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
         0 min_qty_dec, '' sumusage_vchr,
         't_opr_outpatienttestrecipede' as fromtable,
         b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
         b.dosageunit_chr, b.itemopinvtype_chr, '' as mednormalname_vchr,
         0 type_int, '' medicinetypeid_chr, 0 times_int1, 0 days_int1,
         b.dosage_dec as basicdosage, '' freqdesc, b.itemcode_vchr,
         b.itemipunit_chr, 1 putmed_int, '' opusagedesc, b.itemsrcid_vchr,
         f.typename_vchr
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatienttestrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and m.sid_int = ''
     and a.windowid_chr = ''
     and b.itemopinvtype_chr = f.typeid_chr
order by a.rowno_chr, a.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strWinID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select   a.outpatrecipeid_chr, a.rowno_chr, a.itemid_chr, a.itemunit_vchr,
         '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
         a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
         a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
         '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
         b.itemopinvtype_chr, 0 as dosage_dec, b.itemcode_vchr,
         '' freqname_chr, 0 times_int, 0 min_qty_dec1, 0 min_qty_dec,
         '' sumusage_vchr, 't_opr_outpatientopsrecipede' as fromtable,
         b.itemsrcid_vchr as medicineid_chr, '' as mednormalname_vchr,
         0 type_int, '' medicinetypeid_chr, 0 times_int1, 0 days_int1,
         b.dosage_dec as basicdosage, '' freqdesc, b.itemipunit_chr,
         1 putmed_int, '' opusagedesc, b.dosage_dec as discount_dec,
         b.dosageunit_chr, b.itemsrcid_vchr, f.typename_vchr
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientopsrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and m.sid_int = ?
     and a.windowid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
order by a.rowno_chr, a.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strWinID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            #region 3-审核处方
            else
            {
                strSQL = @"select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
       opusagedesc, itemsrcid_vchr
  from (select   a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr,
                 a.itemid_chr, a.unitid_chr, a.tolqty_dec as qty_dec,
                 a.unitprice_mny as price_mny, a.tolprice_mny, a.usageid_chr,
                 a.days_int, a.freqid_chr, d.usagename_vchr, a.desc_vchr,
                 b.itemopinvtype_chr, a.dosage_dec, a.itemspec_vchr,
                 a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
                 f.typename_vchr, e.freqname_chr, 0 times_int, 0 min_qty_dec1,
                 0 min_qty_dec, '' sumusage_vchr,
                 't_tmp_outpatientpwmrecipede' as fromtable,
                 b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
                 g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr,
                 e.times_int as times_int1, e.days_int as days_int1,
                 b.dosage_dec as basicdosage, e.opfredesc_vchr as freqdesc,
                 b.itemipunit_chr, d.putmed_int, d.opusagedesc,
                 b.itemsrcid_vchr
            from t_tmp_outpatientpwmrecipede a,
                 t_bse_chargeitem b,
                 t_bse_chargeitemextype f,
                 t_bse_usagetype d,
                 t_aid_recipefreq e,
                 t_bse_medicine g
           where a.itemid_chr = b.itemid_chr
             and a.deptmed_int = 0
             and a.outpatrecipeid_chr = ?
             and b.itemopinvtype_chr = f.typeid_chr
             and f.flag_int = 2
             and a.usageid_chr = d.usageid_chr(+)
             and a.freqid_chr = e.freqid_chr(+)
             and b.itemsrcid_vchr = g.medicineid_chr(+)
        order by a.rowno_chr, a.itemname_vchr)
union all
select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
       opusagedesc, itemsrcid_vchr
  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
                 a.itemid_chr, a.unitid_chr,
                 (a.qty_dec * a.times_int) as qty_dec,
                 a.unitprice_mny as price_mny, a.tolprice_mny, '' usageid_chr,
                 0 as days_int, '' freqid_chr, d.usagename_vchr,
                 usagedetail_vchr as desc_vchr, b.itemopinvtype_chr,
                 b.dosage_dec, a.itemspec_vchr, 0 as dosageqty,
                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                 e.freqname_chr, a.times_int, a.min_qty_dec as min_qty_dec1,
                 a.min_qty_dec, a.sumusage_vchr,
                 't_tmp_outpatientcmrecipede' as fromtable,
                 b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
                 g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr,
                 e.times_int as times_int1, e.days_int as days_int1,
                 b.dosage_dec as basicdosage, e.opfredesc_vchr as freqdesc,
                 b.itemipunit_chr, d.putmed_int, d.opusagedesc,
                 b.itemsrcid_vchr
            from t_tmp_outpatientcmrecipede a,
                 t_bse_chargeitem b,
                 t_bse_chargeitemextype f,
                 t_bse_usagetype d,
                 t_aid_recipefreq e,
                 t_bse_medicine g
           where a.itemid_chr = b.itemid_chr
             and a.deptmed_int = 0
             and a.outpatrecipeid_chr = ?
             and a.itemid_chr = e.freqid_chr(+)
             and b.itemopinvtype_chr = f.typeid_chr
             and f.flag_int = 2
             and a.usageid_chr = d.usageid_chr(+)
             and b.itemsrcid_vchr = g.medicineid_chr(+)
        order by a.rowno_chr, a.itemname_vchr)
union all
select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
       opusagedesc, itemsrcid_vchr
  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
                 a.itemid_chr, a.unitid_chr, a.qty_dec as qty_dec,
                 a.unitprice_mny as price_mny, a.tolprice_mny,
                 '' as usageid_chr, 0 as days_int, '' as freqid_chr,
                 '' as usagename_vchr, '' as desc_vchr, b.itemopinvtype_chr,
                 0 as dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty,
                 a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                 '' freqname_chr, 0 times_int, 0 min_qty_dec1, 0 min_qty_dec,
                 '' sumusage_vchr, 't_tmp_outpatientothrecipede' as fromtable,
                 b.itemsrcid_vchr as medicineid_chr,
                 b.dosage_dec as discount_dec, g.mednormalname_vchr,
                 0 type_int, a.itemunit_vchr, g.medicinetypeid_chr,
                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
                 b.itemsrcid_vchr
            from t_tmp_outpatientothrecipede a,
                 t_bse_chargeitem b,
                 t_bse_chargeitemextype f,
                 t_bse_medicine g
           where a.itemid_chr = b.itemid_chr
             and a.deptmed_int = 0
             and a.outpatrecipeid_chr = ?
             and b.itemopinvtype_chr = f.typeid_chr
             and b.itemsrcid_vchr = g.medicineid_chr(+)
        order by a.rowno_chr, a.itemname_vchr)
union all
select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
       opusagedesc, itemsrcid_vchr
  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
                 a.itemid_chr, '' unitid_chr, a.qty_dec as qty_dec,
                 a.price_mny as price_mny, a.tolprice_mny, '' as usageid_chr,
                 0 as days_int, '' as freqid_chr, '' as usagename_vchr,
                 '' as desc_vchr, b.itemopinvtype_chr, 0 as dosage_dec,
                 a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
                 b.itemcode_vchr, f.typename_vchr, '' freqname_chr,
                 0 times_int, 0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
                 't_tmp_outpatientchkrecipede' as fromtable,
                 b.itemsrcid_vchr as medicineid_chr,
                 b.dosage_dec as discount_dec, '' as mednormalname_vchr,
                 0 type_int, a.itemunit_vchr, '' medicinetypeid_chr,
                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
                 b.itemsrcid_vchr
            from t_tmp_outpatientchkrecipede a,
                 t_bse_chargeitem b,
                 t_bse_chargeitemextype f
           where a.itemid_chr = b.itemid_chr
             and a.outpatrecipeid_chr = ?
             and b.itemopinvtype_chr = f.typeid_chr
        order by a.rowno_chr, a.itemname_vchr)
union all
select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
       opusagedesc, itemsrcid_vchr
  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
                 a.itemid_chr, '' unitid_chr, a.qty_dec as qty_dec,
                 a.price_mny as price_mny, a.tolprice_mny, '' as usageid_chr,
                 0 as days_int, '' as freqid_chr, '' as usagename_vchr,
                 '' as desc_vchr, b.itemopinvtype_chr, 0 as dosage_dec,
                 a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
                 b.itemcode_vchr, f.typename_vchr, '' freqname_chr,
                 0 times_int, 0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
                 't_tmp_outpatienttestrecipede' as fromtable,
                 b.itemsrcid_vchr as medicineid_chr,
                 b.dosage_dec as discount_dec, '' as mednormalname_vchr,
                 0 type_int, a.itemunit_vchr, '' medicinetypeid_chr,
                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
                 b.itemsrcid_vchr
            from t_tmp_outpatienttestrecipede a,
                 t_bse_chargeitem b,
                 t_bse_chargeitemextype f
           where a.itemid_chr = b.itemid_chr
             and a.outpatrecipeid_chr = ?
             and b.itemopinvtype_chr = f.typeid_chr
        order by a.rowno_chr, a.itemname_vchr)
union all
select outpatrecipeid_chr, dosageunit_chr, rowno_chr, itemid_chr, unitid_chr,
       qty_dec, price_mny, tolprice_mny, medstoreid_chr, usageid_chr,
       days_int, freqid_chr, usagename_vchr, desc_vchr, itemopinvtype_chr,
       dosage_dec, itemspec_vchr, dosageqty, itemname_vchr, itemcode_vchr,
       typename_vchr, freqname_chr, times_int, min_qty_dec1, min_qty_dec,
       sumusage_vchr, fromtable, medicineid_chr, discount_dec,
       mednormalname_vchr, itemunit_vchr, medicinetypeid_chr, times_int1,
       days_int1, basicdosage, freqdesc, itemipunit_chr, putmed_int,
       opusagedesc, itemsrcid_vchr
  from (select   a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr,
                 a.itemid_chr, '' unitid_chr, a.qty_dec as qty_dec,
                 a.price_mny as price_mny, a.tolprice_mny, '' as usageid_chr,
                 0 as days_int, '' as freqid_chr, '' as usagename_vchr,
                 '' as desc_vchr, b.itemopinvtype_chr, 0 as dosage_dec,
                 a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
                 b.itemcode_vchr, f.typename_vchr, '' freqname_chr,
                 0 times_int, 0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
                 't_opr_outpatientopsrecipede' as fromtable,
                 b.itemsrcid_vchr as medicineid_chr,
                 b.dosage_dec as discount_dec, '' as mednormalname_vchr,
                 0 type_int, a.itemunit_vchr, '' medicinetypeid_chr,
                 0 times_int1, 0 days_int1, b.dosage_dec as basicdosage,
                 '' freqdesc, b.itemipunit_chr, 1 putmed_int, '' opusagedesc,
                 b.itemsrcid_vchr
            from t_opr_outpatientopsrecipede a,
                 t_bse_chargeitem b,
                 t_bse_chargeitemextype f
           where a.itemid_chr = b.itemid_chr
             and a.outpatrecipeid_chr = ?
             and b.itemopinvtype_chr = f.typeid_chr
        order by a.rowno_chr, a.itemname_vchr)";
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid.ToString();
                    objLisAddItemRefArr[1].Value = m_intsid.ToString();
                    objLisAddItemRefArr[2].Value = m_intsid.ToString();
                    objLisAddItemRefArr[3].Value = m_intsid.ToString();
                    objLisAddItemRefArr[4].Value = m_intsid.ToString();
                    objLisAddItemRefArr[5].Value = m_intsid.ToString();
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtItemDe, objLisAddItemRefArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            #endregion
            return lngRes;
		}
		#endregion

		#region 门诊药品发放（更改库存）
		/// <summary>
		/// 门诊药品发放（更改库存）
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strMedStoreID">药房</param>
		/// <param name="p_strWinID">窗口</param>
		/// <param name="p_strOPRecID">处方号</param>
		/// <param name="p_intType">处方类型，1：西药，2：中药</param>
		/// <param name="p_intFlag">标志，1：成功，0：失败，-1：异常</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngOPRecipeMedProvide(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strMedStoreID,string p_strWinID,string p_strOPRecID,int p_intType,out int p_intFlag)
		{
			long lngRes = 0;
			p_intFlag = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngOPRecipeMedProvide");
			if(lngRes < 0)
			{
				return -1;
			}

			try
			{
				string strProcedure = "P_OPMEDSTOREWINSEND";
				com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[5];
				
				for(int i=0;i<objParams.Length;i++)
				{
					objParams[i] = new clsSQLParamDefinitionVO();
				}
				objParams[0].objParameter_Value = p_strMedStoreID;
				objParams[0].strParameter_Type = clsOracleDbType.strVarchar2;
				objParams[0].strParameter_Name = "medstoreid";

				objParams[1].objParameter_Value = p_strWinID;
				objParams[1].strParameter_Type = clsOracleDbType.strVarchar2;
				objParams[1].strParameter_Name = "winid";

				objParams[2].objParameter_Value = p_strOPRecID;
				objParams[2].strParameter_Type = clsOracleDbType.strVarchar2;
				objParams[2].strParameter_Name = "recipeid";

				objParams[3].objParameter_Value = p_intType;
				objParams[3].strParameter_Type = clsOracleDbType.strInt32;
				objParams[3].strParameter_Name = "typeid";

				objParams[4].strParameter_Type = clsOracleDbType.strInt32;
				objParams[4].strParameter_Direction = clsDirection.strOutput;
				objParams[4].strParameter_Name = "flag";


				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngExecuteParameterProc(strProcedure,objParams);
				p_intFlag = int.Parse(objParams[4].objParameter_Value.ToString().Trim());
			}		
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 获得处方的其它收费明细
		/// <summary>
		/// 获得处方的其它收费明细
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strOUTPATRECIPEID"></param>
		/// <param name="btpatientcnkre">检验费</param>
		/// <param name="btpatientest">检查费</param>
		/// <param name="btpatienOpsre">手术费</param>
		/// <param name="btpatienothre">其它费用</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetAll(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strOUTPATRECIPEID,out DataTable btpatientcnkre,out DataTable btpatientest,out DataTable btpatienOpsre,out DataTable btpatienothre)
		{
			long lngRes = 0;
			btpatientcnkre=new DataTable();
			btpatientest=new DataTable();
			btpatienOpsre=new DataTable();
			btpatienothre=new DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc","m_lngGetAll");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL=@"select b.ITEMNAME_VCHR,a.PRICE_MNY,a.OPRDEPT_CHR,a.DISCOUNT_DEC,a.TOLPRICE_MNY from t_opr_outpatientchkrecipede a, t_bse_chargeitem b where a.ITEMID_CHR=b.ITEMID_CHR and a.OUTPATRECIPEID_CHR='"+p_strOUTPATRECIPEID+"'";
			try
			{
				lngRes=objHRPSvc.DoGetDataTable(strSQL,ref btpatientcnkre);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

			strSQL=@"select b.ITEMNAME_VCHR,a.PRICE_MNY,a.OPRDEPT_CHR,a.DISCOUNT_DEC,a.TOLPRICE_MNY from t_opr_outpatienttestrecipede a, t_bse_chargeitem b where a.ITEMID_CHR=b.ITEMID_CHR and a.OUTPATRECIPEID_CHR='"+p_strOUTPATRECIPEID+"'";
			try
			{
				lngRes=objHRPSvc.DoGetDataTable(strSQL,ref btpatientest);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			strSQL=@"select b.ITEMNAME_VCHR,a.PRICE_MNY,a.OPRDEPT_CHR,a.DISCOUNT_DEC,a.TOLPRICE_MNY from t_opr_outpatientopsrecipede a, t_bse_chargeitem b where a.ITEMID_CHR=b.ITEMID_CHR and a.OUTPATRECIPEID_CHR='"+p_strOUTPATRECIPEID+"'";
			try
			{
				lngRes=objHRPSvc.DoGetDataTable(strSQL,ref btpatienOpsre);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			strSQL=@"select b.ITEMNAME_VCHR,a.UNITID_CHR,a.UNITPRICE_MNY,a.QTY_DEC,a.DISCOUNT_DEC,a.TOLPRICE_MNY from t_opr_outpatientothrecipede a, t_bse_chargeitem b where a.ITEMID_CHR=b.ITEMID_CHR and a.OUTPATRECIPEID_CHR='"+p_strOUTPATRECIPEID+"'";
			try
			{
				lngRes=objHRPSvc.DoGetDataTable(strSQL,ref btpatienothre);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;	

		}


		#endregion

		#region 其它发药

		#region 获取所有的项目数据
		[AutoComplete]
		public long m_mthFindMedicine(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindMedicineByID");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select A.ITEMSRCID_VCHR,A.ITEMID_CHR case when A.ITEMCATID_CHR='0002' then '中药' when A.ITEMCATID_CHR='0003' then '检验' when A.ITEMCATID_CHR='0004' then '治疗' when A.ITEMCATID_CHR='0005' then '其它' when A.ITEMCATID_CHR='0006' then '手术' when A.ITEMCATID_CHR='0001' then '西药' end as ItemType,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,A.ITEMENGNAME_VCHR,A.ITEMWBCODE_CHR,A.ITEMPYCODE_CHR,case when A.OPCHARGEFLG_INT=1 then  ROUND (a.ITEMPRICE_MNY / a.PACKQTY_DEC, 4) when A.OPCHARGEFLG_INT=0 then  A.ITEMPRICE_MNY end as submoney,case when A.OPCHARGEFLG_INT=1 then A.ITEMIPUNIT_CHR when A.OPCHARGEFLG_INT=0 then A.ITEMOPUNIT_CHR end as ITEMOPUNIT_CHR,A.ITEMOPUNIT_CHR as ITEMOPUNIT,a.ITEMPRICE_MNY,a.ISRICH_INT,
A.ITEMOPINVTYPE_CHR,A.ITEMCATID_CHR,A.SELFDEFINE_INT,A.ITEMCODE_VCHR,A.ITEMOPCALCTYPE_CHR,
B.NOQTYFLAG_INT,a.itemipunit_chr,a.opchargeflg_int from t_bse_chargeitem A ,T_BSE_MEDICINE B
where  trim(A.ITEMSRCID_VCHR)=trim(B.MEDICINEID_CHR(+)) and a.IFSTOP_INT =0  order by ITEMCODE_VCHR";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 保存出库单修改库存
		/// <summary>
		/// 保存出库单修改库存
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="SaveRow"></param>
		/// <param name="SaveTableDe"></param>
		/// <returns>1-正常，2-还没有设置药房出库类型，3-没有找到相应的药品</returns>
		[AutoComplete]
		public long m_mthSaveData(System.Security.Principal.IPrincipal p_objPrincipal,DataRow SaveRow,DataTable SaveTableDe)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthSaveData");
			if(lngRes < 0)
			{
				return -1;
			}
			DataTable dt=new DataTable();
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL = @"select MEDSTOREORDTYPEID_CHR from  t_aid_medstoreordtype where MEDSTOREORDTYPE_VCHR='发药出库'";
			try
			{
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(dt.Rows.Count==0)
			{
				return 2;//还没有设置药房出库类型
			}
			else
			{
				SaveRow["MEDSTOREORDTYPEID_CHR"]=dt.Rows[0]["MEDSTOREORDTYPEID_CHR"];
			}
			//string newid=objHRPSvc.m_strGetNewID("t_opr_medstoreord","MEDSTOREORDID_CHR",18);
            
            //序列ID
            string newid = "";
            DataTable dt1 = new DataTable();
            string SQL = @"select lpad (seq_medstoreordid.nextval, 18, '0')
                           from dual";
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt1);
            if (lngRes > 0)
            {
                newid = dt1.Rows[0][0].ToString();
            }

            strSQL = @"insert into t_opr_medstoreord
            (medstoreordid_chr, medstoreid_chr, orddate_dat, tolmny_mny,
             memo_vchr, creator_chr, createdate_dat, medstoreordtypeid_chr,
             pstatus_int, outflan_int, periodid_chr, aduitemp_chr
            )
     values (?, ?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?,
             ?, ?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?,
             2, 2, ?, ?
            )";
			try
			{
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out paramArr);
                paramArr[0].Value = newid;
                paramArr[1].Value = SaveRow["MEDSTOREID_CHR"].ToString();
                paramArr[2].Value = SaveRow["ORDDATE_DAT"].ToString();
                paramArr[3].Value = SaveRow["TOLMNY_MNY"].ToString();
                paramArr[4].Value = SaveRow["MEMO_VCHR"].ToString();
                paramArr[5].Value = SaveRow["CREATOR_CHR"].ToString();
                 paramArr[6].Value = SaveRow["CREATEDATE_DAT"].ToString();
                 paramArr[7].Value = SaveRow["MEDSTOREORDTYPEID_CHR"].ToString();
                 paramArr[8].Value = SaveRow["PERIODID_CHR"].ToString();
                 paramArr[9].Value = SaveRow["ADUITEMP_CHR"].ToString();

                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(lngRes>0&&SaveTableDe.Rows.Count>0)
			{
				for(int i1=0;i1<SaveTableDe.Rows.Count;i1++)
				{

                    strSQL = @"insert into t_opr_medstoreordde
                              (medstoreorddeid_chr, medstoreordid_chr, medicineid_chr, qty_dec,
                               saleunitprice_dec, saletolprice_dec, unitid_chr
                              )
                              values (seq_medstoreorddeid18.nextval, ?, ?, ?,
                              ?, ?, ?
                              )
                              ";
					try
					{
                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(6, out paramArr);
                        paramArr[0].Value = newid;
                        paramArr[1].Value = SaveTableDe.Rows[i1]["MEDICINEID_CHR"].ToString();
                        paramArr[2].Value = SaveTableDe.Rows[i1]["QTY_DEC"].ToString();
                        paramArr[3].Value = SaveTableDe.Rows[i1]["SALEUNITPRICE_DEC"].ToString();
                        paramArr[4].Value = SaveTableDe.Rows[i1]["SALETOLPRICE_DEC"].ToString();
                        paramArr[5].Value = SaveTableDe.Rows[i1]["UNITID_CHR"].ToString();

                        long lngRecordsAffected = -1;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
						
					}		
					catch(Exception objEx)
					{
						string strTmp=objEx.Message;
						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
						bool blnRes = objLogger.LogError(objEx);
					}
					if(lngRes==0)
						ContextUtil.SetAbort();
//					#region 修改库存
//					DataTable dtDe=new DataTable();
//					strSQL=@"select AMOUNT_DEC from t_tol_medstoremedicine where MEDSTOREID_CHR='"+SaveRow["MEDSTOREID_CHR"].ToString()+"' and MEDICINEID_CHR='"+SaveTableDe.Rows[i1]["MEDICINEID_CHR"].ToString()+"'";
//					try
//					{
//						lngRes=objHRPSvc.DoGetDataTable(strSQL,ref dtDe);
//					}		
//					catch(Exception objEx)
//					{
//						string strTmp=objEx.Message;
//						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//						bool blnRes = objLogger.LogError(objEx);
//					}
//					if(dtDe.Rows.Count>0)
//					{
//						int Couns=Convert.ToInt32(dtDe.Rows[0]["AMOUNT_DEC"].ToString())-Convert.ToInt32(SaveTableDe.Rows[i1]["QTY_DEC"].ToString());
//						strSQL=@"update t_tol_medstoremedicine set AMOUNT_DEC="+Couns.ToString()+" where MEDSTOREID_CHR='"+SaveRow["MEDSTOREID_CHR"].ToString()+"' and MEDICINEID_CHR='"+SaveTableDe.Rows[i1]["MEDICINEID_CHR"].ToString()+"'"; 
//						try
//						{
//							lngRes=objHRPSvc.DoExcute(strSQL);
//						}		
//						catch(Exception objEx)
//						{
//							string strTmp=objEx.Message;
//							com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//							bool blnRes = objLogger.LogError(objEx);
//						}
//						if(lngRes==0)
//							ContextUtil.SetAbort();
//					}
//					else
//					{
//						strSQL=@"insert into t_tol_medstoremedicine(MEDSTOREID_CHR,MEDICINEID_CHR,AMOUNT_DEC) VALUES('002"+"','"+SaveTableDe.Rows[i1]["MEDICINEID_CHR"].ToString()+"',"+"-"+SaveTableDe.Rows[i1]["QTY_DEC"].ToString()+")";
//						try
//						{
//							lngRes=objHRPSvc.DoGetDataTable(strSQL,ref dtDe);
//						}		
//						catch(Exception objEx)
//						{
//							string strTmp=objEx.Message;
//							com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//							bool blnRes = objLogger.LogError(objEx);
//						}
//						if(lngRes==0)
//							ContextUtil.SetAbort();
//					}
//
//					#endregion
				}
			}
			return lngRes;
		}
		#endregion

		#endregion
		
		#region 判断发票是否有效
		[AutoComplete]
		public bool  m_blCheckOut(string strOUTPATRECIPEID)
		{
			DataTable dt=new DataTable();
			DataTable dt1=new DataTable();
            string strSQL = @"select status_int
  from t_opr_outpatientrecipeinv
 where invoiceno_vchr =? and status_int = 2";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strOUTPATRECIPEID;
               long  lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}

            string strSQL2 = @"select status_int
  from t_opr_outpatientrecipeinv
 where invoiceno_vchr =? and status_int = 3";
			try
			{
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strOUTPATRECIPEID;
               long  lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref dt1, param);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(dt.Rows.Count>0&&dt1.Rows.Count==0)
			{
				return false;
			}
			else if(dt.Rows.Count>0&&dt1.Rows.Count>0)
			{
				return true;
			}
     	 return true;

		}
		#endregion

        #region 获取处方的方号
        [AutoComplete]
        public string m_getOutpatientNO(string strOUTPATRECIPEID, string RECORDDATE, string strPATIENTID)
        {
            string strNO = "方";
            DataTable dt = new DataTable();
            string strSQL = @"select distinct (a.outpatrecipeid_chr)
           from (select b.outpatrecipeid_chr
                   from t_opr_outpatientrecipeinv a, t_opr_reciperelation b
                  where a.patientid_chr =?
                    and a.recorddate_dat =
                           to_date (?,
                                    'yyyy-mm-dd hh24:mi:ss'
                                   )
                    and a.outpatrecipeid_chr = b.seqid) a,
                t_opr_outpatientrecipe b
          where a.outpatrecipeid_chr = b.outpatrecipeid_chr
       order by a.outpatrecipeid_chr";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = strPATIENTID;
                param[1].Value = RECORDDATE;
               long  lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            {
                if (dt.Rows[i1]["OUTPATRECIPEID_CHR"].ToString() == strOUTPATRECIPEID)
                {
                    int intNo = i1 + 1;
                    strNO += intNo.ToString() + "共" + dt.Rows.Count.ToString() + "张";
                }
            }
            return strNO;

        }
        #endregion

		#region 获取急诊药房的所有指向的药房
		/// <summary>
		/// 获取急诊药房的所有指向的药房
		/// </summary>
		/// <param name="strStorageID"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		[AutoComplete]
		public long   m_longDutydt(string strStorageID,out DataTable dt)
		{
			long  lngRes=0;
			dt=new DataTable();

			int weekDay_int=0;//星期几 (1-周一\7-周日)
			clsGetServerDate getServerDate=new clsGetServerDate();
			switch(getServerDate.m_GetServerDate().DayOfWeek.ToString())
			{
				case "Monday":
					weekDay_int=1;
					break;
				case "Tuesday":
					weekDay_int=2;
					break;
				case "Wednesday":
					weekDay_int=3;
					break;
				case "Thursday":
					weekDay_int=4;
					break;
				case "Friday":
					weekDay_int=5;
					break;
				case "Saturday":
					weekDay_int=6;
					break;
				case "Sunday":
					weekDay_int=7;
					break;
			}
			string strSQL = @"select DEPTID_VCHR,WEEKDAY_INT,WORKTIME_VCHR from t_bse_deptduty where OBJECTDEPTID_VCHR='"+strStorageID+"' and TYPEID_INT=1 and WEEKDAY_INT="+weekDay_int.ToString();
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;

		}
		#endregion

        #region 审核处方处理事务
        /// <summary>
        /// 审核处方处理事务
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <param name="intStatus"></param>
        /// <param name="strCONFIRMDESC"></param>
        /// <param name="strEMPID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAuditing(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientRecipe_VO[] p_objRecord,int intStatus,string strCONFIRMDESC,string strEMPID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNew");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (p_objRecord.Length > 0)
            {
                string strSQL = "";
                for (int i1 = 0; i1 < p_objRecord.Length; i1++)
                {
                    strSQL = @"update T_OPR_OUTPATIENTRECIPE set CONFIRM_INT=" + intStatus + ",CONFIRMDESC_VCHR='" + strCONFIRMDESC + "' where OUTPATRECIPEID_CHR='" + p_objRecord[i1].m_strOutpatRecipeID + "'";
                    try
                    {
                        lngRes = objHRPSvc.DoExcute(strSQL);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                    clsOPRCONFIRMVO p_objRecord1 = new clsOPRCONFIRMVO();
                    p_objRecord1.m_intCONFRIM_INT = intStatus;
                    p_objRecord1.m_strCONFIRMDESC_VCHR = strCONFIRMDESC;
                    p_objRecord1.m_strCONFIRMEMP_CHR = strEMPID;
                    p_objRecord1.m_strOUTPATRECIPEID_CHR = p_objRecord[i1].m_strOutpatRecipeID;
                    p_objRecord1.m_strCONFIRMDATE_DAT = DateTime.Now.ToString();
                    m_lngAddNewData(p_objPrincipal, p_objRecord1);
                }
            }
            return lngRes;
        }
        #endregion

        #region 门诊处方审核记录表
        /// <summary>
        /// 门诊处方审核记录表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewData(System.Security.Principal.IPrincipal p_objPrincipal, clsOPRCONFIRMVO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNew");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_OPR_OPRCONFIRM (SEQ_INT,OUTPATRECIPEID_CHR,CONFIRMEMP_CHR,CONFIRMDATE_DAT,CONFRIM_INT,CONFIRMDESC_VCHR) VALUES (SEQ_OPRCONFIRM.nextval,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strCONFIRMEMP_CHR;
                objLisAddItemRefArr[2].Value = DateTime.Parse(p_objRecord.m_strCONFIRMDATE_DAT);
                objLisAddItemRefArr[3].Value = p_objRecord.m_intCONFRIM_INT;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strCONFIRMDESC_VCHR;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region  获取部门信息
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objDep"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPDeptList(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable objDep)
        {
            objDep = new DataTable();
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngGetOPDeptListByDate");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select CODE_VCHR,DEPTNAME_VCHR,PYCODE_CHR,WBCODE_CHR,DEPTID_CHR from T_BSE_DEPTDESC where CATEGORY_INT=0 and (ATTRIBUTEID = '0000002' or ATTRIBUTEID ='0000001') and DEPTNAME_VCHR <> '所有' and INPATIENTOROUTPATIENT_INT = 0  order by SHORTNO_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref objDep);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }


        #endregion

        #region 根据单据类别获取用法列表：0 注射单 1 输液巡视卡 2 贴瓶单 3 治疗单 4 手术单 5 输血单 6 配药 7 发药
        /// <summary>
        /// 根据单据类别获取用法列表：0 注射单 1 输液巡视卡 2 贴瓶单 3 治疗单 4 手术单 5 输血单 6 配药 7 发药
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsagebyordertypeid(string typeid, out DataTable dtRecord)
        {
            long lngRes = 0;
            dtRecord = new DataTable();

            string SQL = "select distinct usageid_chr from t_opr_setusage where trim(orderid_vchr) = '" + typeid + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion
        
        #region 根据用户工号密码获取员工名称
       /// <summary>
        /// 根据用户工号密码获取员工名称
       /// </summary>
       /// <param name="EmpNO"></param>
       /// <param name="EmpPw"></param>
       /// <param name="EmpName"></param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmpName(string EmpNO,string EmpPw,out string EmpName,out string EmpID)
        {
            EmpName = "";
            EmpID = "";
            long lngRes = 0;
            DataTable  dtRecord = new DataTable();
            string SQL = "";
            if (EmpPw == "")
            {
                SQL = @"select lastname_vchr, empid_chr
  from t_bse_employee
 where empno_chr = ? and psw_chr is null";
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] param = null;
                    objHRPSvc.CreateDatabaseParameter(1, out param);
                    param[0].Value = EmpNO;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, param);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                SQL = @"select lastname_vchr, empid_chr
  from t_bse_employee
 where empno_chr = ? and trim (psw_chr) = ?";
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] param = null;
                    objHRPSvc.CreateDatabaseParameter(2, out param);
                    param[0].Value = EmpNO;
                    param[1].Value = EmpPw;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, param);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            if (dtRecord.Rows.Count > 0)
            {
                EmpName = dtRecord.Rows[0]["LASTNAME_VCHR"].ToString();
                EmpID = dtRecord.Rows[0]["EMPID_CHR"].ToString();
            }
            return lngRes;
        }
        #endregion

        #region 查找药房数据
        /// <summary>
        /// 查找药房数据
        /// </summary>
        [AutoComplete]
        public long m_lngGetMedStoreData(System.Security.Principal.IPrincipal p_objPrincipal,string p_strWhere, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetMedStoreData");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "select * from t_bse_medstore " + p_strWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        /// <summary>
        /// 查找项目数据
        /// </summary>
        [AutoComplete]
        public long m_lngGetItemData(System.Security.Principal.IPrincipal p_objPrincipal,   out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetItemData");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT itemcode_vchr, itemname_vchr, itempycode_chr, itemwbcode_chr,
                                       itemid_chr
                                 FROM t_bse_chargeitem
                                 WHERE ifstop_int = 0 ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        /// <summary>
        /// 查找门诊药房药品发放清单报表数据
        /// </summary>
        [AutoComplete]
        public long m_lngGetMedSendItemData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRecordBeginDate, string p_strRecordEndDate, string[] p_strMedstoreIdArr, string[] p_strStatus, string p_strOrderBy, string p_strSingleItemName,out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetItemData");
            if (lngRes < 0)
            {
                return -1;
            }
            #region 组织条件
            string strTemp = "";
             if (p_strSingleItemName !="")
            {

               strTemp= " And ( td.itemname_vchr = '" + p_strSingleItemName + "')";
            }
            string strAnd = strTemp+" And (";
            for (int i = 0; i < p_strMedstoreIdArr.Length; i++)
            {
                if (i != p_strMedstoreIdArr.Length-1)
                {
                    strAnd += " tf.medstoreid_chr='" + p_strMedstoreIdArr[i].Trim() + "' OR ";
                }
                else
                {
                    strAnd += " tf.medstoreid_chr='" + p_strMedstoreIdArr[i].Trim() + "' ) ";
                }
            }
            strAnd += "And (";
            for (int i = 0; i < p_strStatus.Length; i++)
            {
                if (i != p_strStatus.Length - 1)
                {
                    strAnd += " te.pstatus_int=" + p_strStatus[i].Trim() + " OR ";
                }
                else
                {
                    strAnd += " te.pstatus_int=" + p_strStatus[i].Trim() + " ) ";
                }
            }
            strAnd += " and ta.recorddate_dat between to_date('" + p_strRecordBeginDate + " 00:00:00', 'yyyy-mm-dd hh24:mi:ss') AND to_date('" + p_strRecordEndDate + " 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";

            #endregion 

            #region sql
            StringBuilder strSQL =new StringBuilder ();
            if (p_strOrderBy != "")
            {
                strSQL =strSQL.Append(@"SELECT * FROM (");
            }
            strSQL =strSQL.Append(@" SELECT ta.outpatrecipeid_chr, ta.patientid_chr,
                                   TO_CHAR (ta.recorddate_dat, 'yyyy-mm-dd') AS recorddate_dat,
                                   ta.diagdr_chr, tb.lastname_vchr, tc.lastname_vchr AS patientname,
                                   tg.itemcode_vchr, td.itemname_vchr, td.itemspec_vchr, td.TOLQTY_DEC qty_dec,
                                   td.dosageunit_chr, td.unitprice_mny, td.tolprice_mny,
                                   th1.lastname_vchr AS treatemp_name, th2.lastname_vchr AS give_name,
                                   tf.medstoreid_chr, tf.medstorename_vchr,td.itemid_chr,td.itemid_chr strTemp1
                              FROM t_opr_outpatientrecipe ta,
                                   t_bse_employee tb,
                                   t_bse_patient tc,
                                   t_opr_outpatientpwmrecipede td,
                                   t_opr_recipesend te,
                                   t_opr_recipesendentry i,
                                   t_bse_medstore tf,
                                   t_bse_chargeitem tg,
                                   t_bse_employee th1,
                                   t_bse_employee th2
                             WHERE te.sid_int=i.sid_int
                               AND ta.outpatrecipeid_chr = td.outpatrecipeid_chr
                               AND td.outpatrecipeid_chr = i.outpatrecipeid_chr
                               AND td.itemid_chr = tg.itemid_chr(+)
                               AND td.medstoreid_chr = te.medstoreid_chr
                               AND te.medstoreid_chr = tf.medstoreid_chr(+)
                               AND (ta.pstauts_int = 2 OR ta.pstauts_int = 3)
                               AND ta.diagdr_chr = tb.empid_chr(+)
                               AND ta.patientid_chr = tc.patientid_chr(+)
                               AND te.treatemp_chr = th1.empid_chr(+)
                               AND te.sendemp_chr = th2.empid_chr(+)
                               " + strAnd+ @"
                            UNION ALL
                            SELECT ta.outpatrecipeid_chr, ta.patientid_chr,
                                   TO_CHAR (ta.recorddate_dat, 'yyyy-mm-dd') AS recorddate_dat,
                                   ta.diagdr_chr, tb.lastname_vchr, tc.lastname_vchr AS patientname,
                                   tg.itemcode_vchr, td.itemname_vchr, td.itemspec_vchr, td.qty_dec,
                                   tg.dosageunit_chr, td.unitprice_mny, td.tolprice_mny,
                                   th1.lastname_vchr AS treatemp_name, th2.lastname_vchr AS give_name,
                                   tf.medstoreid_chr, tf.medstorename_vchr,td.itemid_chr,td.itemid_chr strTemp1
                              FROM t_opr_outpatientrecipe ta,
                                   t_bse_employee tb,
                                   t_bse_patient tc,
                                   t_opr_outpatientcmrecipede td,
                                   t_opr_recipesend te,
                                   t_opr_recipesendentry i,
                                   t_bse_medstore tf,
                                   t_bse_chargeitem tg,
                                   t_bse_employee th1,
                                   t_bse_employee th2
                             WHERE te.sid_int=i.sid_int
                               AND ta.outpatrecipeid_chr = td.outpatrecipeid_chr
                               AND td.outpatrecipeid_chr = i.outpatrecipeid_chr
                               AND td.itemid_chr = tg.itemid_chr(+)
                               AND td.medstoreid_chr = te.medstoreid_chr
                               AND te.medstoreid_chr = tf.medstoreid_chr(+)
                               AND (ta.pstauts_int = 2 OR ta.pstauts_int = 3)
                               AND ta.diagdr_chr = tb.empid_chr(+)
                               AND ta.patientid_chr = tc.patientid_chr(+)
                               AND te.treatemp_chr = th1.empid_chr(+)
                               AND te.sendemp_chr = th2.empid_chr(+)
                               " + strAnd+ @"
                            UNION ALL
                            SELECT ta.outpatrecipeid_chr, ta.patientid_chr,
                                   TO_CHAR (ta.recorddate_dat, 'yyyy-mm-dd') AS recorddate_dat,
                                   ta.diagdr_chr, tb.lastname_vchr, tc.lastname_vchr AS patientname,
                                   tg.itemcode_vchr, td.itemname_vchr, td.itemspec_vchr, td.qty_dec,
                                   tg.dosageunit_chr, td.price_mny unitprice_mny, td.tolprice_mny,
                                   th1.lastname_vchr AS treatemp_name, th2.lastname_vchr AS give_name,
                                   tf.medstoreid_chr, tf.medstorename_vchr,td.itemid_chr,td.itemid_chr strTemp1
                              FROM t_opr_outpatientrecipe ta,
                                   t_bse_employee tb,
                                   t_bse_patient tc,
                                   t_opr_outpatientchkrecipede td,
                                   t_opr_recipesend te,
                                   t_opr_recipesendentry i,
                                   t_bse_medstore tf,
                                   t_bse_chargeitem tg,
                                   t_bse_employee th1,
                                   t_bse_employee th2
                             WHERE te.sid_int=i.sid_int
                               AND ta.outpatrecipeid_chr = td.outpatrecipeid_chr
                               AND td.outpatrecipeid_chr = i.outpatrecipeid_chr
                               AND td.itemid_chr = tg.itemid_chr(+)
                               AND td.medstoreid_chr = te.medstoreid_chr
                               AND te.medstoreid_chr = tf.medstoreid_chr(+)
                               AND (ta.pstauts_int = 2 OR ta.pstauts_int = 3)
                               AND ta.diagdr_chr = tb.empid_chr(+)
                               AND ta.patientid_chr = tc.patientid_chr(+)
                               AND te.treatemp_chr = th1.empid_chr(+)
                               AND te.sendemp_chr = th2.empid_chr(+)
                               " + strAnd+ @"
                            UNION ALL
                            SELECT ta.outpatrecipeid_chr, ta.patientid_chr,
                                   TO_CHAR (ta.recorddate_dat, 'yyyy-mm-dd') AS recorddate_dat,
                                   ta.diagdr_chr, tb.lastname_vchr, tc.lastname_vchr AS patientname,
                                   tg.itemcode_vchr, td.itemname_vchr, td.itemspec_vchr, td.qty_dec,
                                   td.itemunit_vchr dosageunit_chr, td.price_mny unitprice_mny,
                                   td.tolprice_mny, th1.lastname_vchr AS treatemp_name,
                                   th2.lastname_vchr AS give_name, tf.medstoreid_chr,
                                   tf.medstorename_vchr,td.itemid_chr,td.itemid_chr strTemp1
                              FROM t_opr_outpatientrecipe ta,
                                   t_bse_employee tb,
                                   t_bse_patient tc,
                                   t_opr_outpatienttestrecipede td,
                                   t_opr_recipesend te,
                                   t_opr_recipesendentry i,
                                   t_bse_medstore tf,
                                   t_bse_chargeitem tg,
                                   t_bse_employee th1,
                                   t_bse_employee th2
                             WHERE te.sid_int=i.sid_int
                               AND ta.outpatrecipeid_chr = td.outpatrecipeid_chr
                               AND td.outpatrecipeid_chr = i.outpatrecipeid_chr
                               AND td.itemid_chr = tg.itemid_chr(+)
                               AND td.medstoreid_chr = te.medstoreid_chr
                               AND te.medstoreid_chr = tf.medstoreid_chr(+)
                               AND (ta.pstauts_int = 2 OR ta.pstauts_int = 3)
                               AND ta.diagdr_chr = tb.empid_chr(+)
                               AND ta.patientid_chr = tc.patientid_chr(+)
                               AND te.treatemp_chr = th1.empid_chr(+)
                               AND te.sendemp_chr = th2.empid_chr(+)
                               " + strAnd+ @"
                            UNION ALL
                            SELECT ta.outpatrecipeid_chr, ta.patientid_chr,
                                   TO_CHAR (ta.recorddate_dat, 'yyyy-mm-dd') AS recorddate_dat,
                                   ta.diagdr_chr, tb.lastname_vchr, tc.lastname_vchr AS patientname,
                                   tg.itemcode_vchr, td.itemname_vchr, td.itemspec_vchr, td.qty_dec,
                                   td.itemunit_vchr dosageunit_chr, td.price_mny unitprice_mny,
                                   td.tolprice_mny, th1.lastname_vchr AS treatemp_name,
                                   th2.lastname_vchr AS give_name, tf.medstoreid_chr,
                                   tf.medstorename_vchr,td.itemid_chr,td.itemid_chr strTemp1
                              FROM t_opr_outpatientrecipe ta,
                                   t_bse_employee tb,
                                   t_bse_patient tc,
                                   t_opr_outpatientopsrecipede td,
                                   t_opr_recipesend te,
                                   t_opr_recipesendentry i,
                                   t_bse_medstore tf,
                                   t_bse_chargeitem tg,
                                   t_bse_employee th1,
                                   t_bse_employee th2
                             WHERE te.sid_int=i.sid_int
                               AND ta.outpatrecipeid_chr = td.outpatrecipeid_chr
                               AND td.outpatrecipeid_chr = i.outpatrecipeid_chr
                               AND td.itemid_chr = tg.itemid_chr(+)
                               AND td.medstoreid_chr = te.medstoreid_chr
                               AND te.medstoreid_chr = tf.medstoreid_chr(+)
                               AND (ta.pstauts_int = 2 OR ta.pstauts_int = 3)
                               AND ta.diagdr_chr = tb.empid_chr(+)
                               AND ta.patientid_chr = tc.patientid_chr(+)
                               AND te.treatemp_chr = th1.empid_chr(+)
                               AND te.sendemp_chr = th2.empid_chr(+)
                               " + strAnd+ @"
                            UNION ALL
                            SELECT ta.outpatrecipeid_chr, ta.patientid_chr,
                                   TO_CHAR (ta.recorddate_dat, 'yyyy-mm-dd') AS recorddate_dat,
                                   ta.diagdr_chr, tb.lastname_vchr, tc.lastname_vchr AS patientname,
                                   tg.itemcode_vchr, td.itemname_vchr, td.itemspec_vchr, td.qty_dec,
                                   td.itemunit_vchr dosageunit_chr, td.unitprice_mny unitprice_mny,
                                   td.tolprice_mny AS tolprice_mny, th1.lastname_vchr AS treatemp_name,
                                   th2.lastname_vchr AS give_name, tf.medstoreid_chr,
                                   tf.medstorename_vchr,td.itemid_chr,td.itemid_chr strTemp1
                              FROM t_opr_outpatientrecipe ta,
                                   t_bse_employee tb,
                                   t_bse_patient tc,
                                   t_opr_outpatientothrecipede td,
                                   t_opr_recipesend te,
                                   t_opr_recipesendentry i,
                                   t_bse_medstore tf,
                                   t_bse_chargeitem tg,
                                   t_bse_employee th1,
                                   t_bse_employee th2
                             WHERE te.sid_int=i.sid_int
                               AND ta.outpatrecipeid_chr = td.outpatrecipeid_chr
                               AND td.outpatrecipeid_chr = i.outpatrecipeid_chr
                               AND td.itemid_chr = tg.itemid_chr(+)
                               AND td.medstoreid_chr = te.medstoreid_chr
                               AND te.medstoreid_chr = tf.medstoreid_chr(+)
                               AND (ta.pstauts_int = 2 OR ta.pstauts_int = 3)
                               AND ta.diagdr_chr = tb.empid_chr(+)
                               AND ta.patientid_chr = tc.patientid_chr(+)
                               AND te.treatemp_chr = th1.empid_chr(+)
                               AND te.sendemp_chr = th2.empid_chr(+)
                               " + strAnd);
            if (p_strOrderBy != "")
            {
                strSQL =strSQL.Append( " ) ORDER BY "+p_strOrderBy );
            }
                #endregion

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL.ToString(), ref p_dtbResult);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion
        #region 根据部门ID和科室自编码判断是否存在该员工
        /// <summary>
        /// 根据部门ID和科室自编码判断是否存在该员工
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strDeptSelfCode"></param>
        /// <param name="m_strEMPID"></param>
        /// <param name="m_strEMPName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngJudgeEmpByIDAndCode(System.Security.Principal.IPrincipal p_objPrincipal,string m_strDeptID,string m_strDeptSelfCode,out string m_strEMPID,out string m_strEMPName)
        {
            long lngRes = 0;
            DataTable m_objTable=new DataTable();
            m_strEMPID = string.Empty;
            m_strEMPName = string.Empty;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngJudgeEmpByIDAndCode");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select a.empid_chr, a.lastname_vchr
  from t_bse_employee a, t_bse_deptemp b
 where a.empid_chr = b.empid_chr
   and b.deptid_chr = ?
   and a.deptcode_chr =? ";
            try
            {
                System.Data.IDataParameter[] objParaArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParaArr);
                objParaArr[0].Value = m_strDeptID;
                objParaArr[1].Value = m_strDeptSelfCode;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, objParaArr);
               // lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strEMPID = m_objTable.Rows[0]["empid_chr"].ToString().Trim();
                    m_strEMPName = m_objTable.Rows[0]["lastname_vchr"].ToString().Trim();
                }
             
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
            #endregion
        #region  根据工号判断是否存在着该员工
        /// <summary>
        /// 根据工号判断是否存在着该员工
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strDeptSelfCode"></param>
        /// <param name="m_strEMPID"></param>
        /// <param name="m_strEMPName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngJudgeEmpByEmpNo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strEmpNO, out string m_strEMPID, out string m_strEMPName)
        {
            long lngRes = 0;
            DataTable m_objTable = new DataTable();
            m_strEMPID = string.Empty;
            m_strEMPName = string.Empty;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngJudgeEmpByEmpNo");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select a.empid_chr, a.lastname_vchr
  from t_bse_employee a
 where a.empno_chr = ?";
            try
            {
                System.Data.IDataParameter[] objParaArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParaArr);
                objParaArr[0].Value = m_strEmpNO;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, objParaArr);
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strEMPID = m_objTable.Rows[0]["empid_chr"].ToString().Trim();
                    m_strEMPName = m_objTable.Rows[0]["lastname_vchr"].ToString().Trim();
                }

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
               #endregion
        #region  获取门诊治疗单对应的用法ID
        /// <summary>
        /// 获取门诊治疗单对应的用法ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strOrderID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsageIDByOrderID(System.Security.Principal.IPrincipal p_objPrincipal, string m_strOrderID,out DataTable m_objTable )
        {
            long lngRes = 0;
            m_objTable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetUsageIDByOrderID");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select usageid_chr
  from t_opr_setusage
 where orderid_vchr =?";
            try
            {
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strOrderID.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, param);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 根据处方号获取处方打印信息
        /// <summary>
        /// 根据处方号获取处方打印信息
        /// </summary>
        /// <param name="m_objPrintcipal"></param>
        /// <param name="strRecipedeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutpatientRecipeDetail(System.Security.Principal.IPrincipal m_objPrintcipal, string strRecipedeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            DataTable m_objTempTable = new DataTable();
            clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            IDataParameter[] ParamArr = null;
            obj_VO = null;
            string strSQL = @"select a.orderid_int, a.outpatrecipeid_chr, a.tableindex_int, a.orderque_int,
                                     a.orderdicid_chr, a.orderdicname_vchr, a.spec_vchr, a.qty_dec,
                                     a.attachid_vchr, a.sampleid_vchr, a.checkpartid_vchr, a.sbbasemny_dec,
                                     a.usageid_chr, a.pricemny_dec, a.totalmny_dec, a.attachorderid_vchr,
                                     a.attachorderbasenum_dec
                                from t_opr_outpatient_orderdic a
                               where a.outpatrecipeid_chr = ?";
            try
            {
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRecipedeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTempTable, ParamArr);
                DataTable dtbResult=new DataTable();
                DataTable dtTemp = new DataTable();

                if (lngRes > 0)
                {
                    if (m_objTempTable.Rows.Count <= 0)
                    {
                        #region 表1
                        strSQL = @"select a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          a.unitid_chr, a.tolqty_dec as qty_dec, a.unitprice_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
                                          a.freqid_chr, d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
                                          a.dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
                                          b.itemcode_vchr, f.typename_vchr, e.freqname_chr, 0 times_int,
                                          0 min_qty_dec1, '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          't_opr_outpatientpwmrecipede' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
                                          g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr
                                     from t_opr_outpatientpwmrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f,
                                          t_bse_usagetype d,
                                          t_aid_recipefreq e,
                                          t_bse_medicine g
                                    where a.itemid_chr = b.itemid_chr
                                      and a.deptmed_int = 0
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr
                                      and f.flag_int = 2
                                      and a.usageid_chr = d.usageid_chr(+)
                                      and a.freqid_chr = e.freqid_chr(+)
                                      and b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult = dtTemp.Clone();
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表2
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          a.unitid_chr, (a.qty_dec * a.times_int) as qty_dec,
                                          a.unitprice_mny as price_mny, a.tolprice_mny, a.medstoreid_chr,
                                          '' usageid_chr, 0 as days_int, '' freqid_chr, d.usagename_vchr,
                                          '' desc_vchr, b.itemopinvtype_chr, b.dosage_dec, a.itemspec_vchr,
                                          0 as dosageqty, a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                                          e.freqname_chr, a.times_int, a.min_qty_dec as min_qty_dec1,
                                          '' usagename_vchr, a.min_qty_dec, a.sumusage_vchr,
                                          't_opr_outpatientcmrecipede' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
                                          g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr
                                     from t_opr_outpatientcmrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f,
                                          t_bse_usagetype d,
                                          t_aid_recipefreq e,
                                          t_bse_medicine g
                                    where a.itemid_chr = b.itemid_chr
                                      and a.deptmed_int = 0
                                      and a.outpatrecipeid_chr = ?
                                      and a.itemid_chr = e.freqid_chr(+)
                                      and b.itemopinvtype_chr = f.typeid_chr
                                      and f.flag_int = 2
                                      and a.usageid_chr = d.usageid_chr(+)
                                      and b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表3
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          a.unitid_chr, a.qty_dec as qty_dec, a.unitprice_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
                                          '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
                                          b.itemopinvtype_chr, 0 as dosage_dec, a.itemspec_vchr,
                                          a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                          f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                          '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          't_opr_outpatientothrecipede' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
                                          g.mednormalname_vchr, a.itemunit_vchr, g.medicinetypeid_chr
                                     from t_opr_outpatientothrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f,
                                          t_bse_medicine g
                                    where a.itemid_chr = b.itemid_chr
                                      and a.deptmed_int = 0
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr
                                      and b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表4
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
                                          '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
                                          b.itemopinvtype_chr, 0 as dosage_dec, a.itemspec_vchr,
                                          a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                          f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                          '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          'T_OPR_OUTPATIENTCHKRECIPEDE' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
                                          '' as mednormalname_vchr, a.itemunit_vchr, '' medicinetypeid_chr
                                     from t_opr_outpatientchkrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f
                                    where a.itemid_chr = b.itemid_chr
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表5
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
                                          '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
                                          b.itemopinvtype_chr, 0 as dosage_dec, a.itemspec_vchr,
                                          a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                          f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                          '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          'T_OPR_OUTPATIENTTESTRECIPEDE' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
                                          '' as mednormalname_vchr, a.itemunit_vchr, '' medicinetypeid_chr
                                     from t_opr_outpatienttestrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f
                                    where a.itemid_chr = b.itemid_chr
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表6
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
                                          '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
                                          b.itemopinvtype_chr, 0 as dosage_dec, a.itemspec_vchr,
                                          a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                          f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                          '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          'T_OPR_OUTPATIENTOPSRECIPEDE' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
                                          '' as mednormalname_vchr, a.itemunit_vchr, '' medicinetypeid_chr
                                     from t_opr_outpatientopsrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f
                                    where a.itemid_chr = b.itemid_chr
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        dtbResult.AcceptChanges();
                        for (int i2 = 0; i2 < dtbResult.Rows.Count; i2++)
                        {
                            if (string.IsNullOrEmpty(dtbResult.Rows[i2]["itemcode_vchr"].ToString()))
                            {
                                dtbResult.Rows[i2].Delete();
                                i2--;
                                dtbResult.AcceptChanges();
                            }
                        }
                        dtbResult.AcceptChanges();
                        #endregion


                        //                        strSQL = @"SELECT a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       a.unitid_chr, a.tolqty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
                        //       a.freqid_chr, d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
                        //       a.dosage_dec, a.itemspec_vchr, a.qty_dec AS dosageqty, a.itemname_vchr,
                        //       b.itemcode_vchr, f.typename_vchr, e.freqname_chr, 0 times_int,
                        //       0 min_qty_dec1, '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       't_opr_outpatientpwmrecipede' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                        //       g.mednormalname_vchr, '' itemunit_vchr,
                        //       g.medicinetypeid_chr
                        //       FROM t_opr_outpatientpwmrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f,
                        //       t_bse_usagetype d,
                        //       t_aid_recipefreq e,
                        //       t_bse_medicine g
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.deptmed_int = 0
                        //       AND a.outpatrecipeid_chr = ?
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       AND f.flag_int = 2
                        //       AND a.usageid_chr = d.usageid_chr(+)
                        //       AND a.freqid_chr = e.freqid_chr(+)
                        //       AND b.itemsrcid_vchr = g.medicineid_chr(+)
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       a.unitid_chr, (a.qty_dec * a.times_int) AS qty_dec,
                        //       a.unitprice_mny AS price_mny, a.tolprice_mny, a.medstoreid_chr,
                        //       '' usageid_chr, 0 AS days_int, '' freqid_chr, d.usagename_vchr,
                        //       '' desc_vchr, b.itemopinvtype_chr, b.dosage_dec, a.itemspec_vchr,
                        //       0 AS dosageqty, a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                        //       e.freqname_chr, a.times_int, a.min_qty_dec AS min_qty_dec1,
                        //       '' usagename_vchr, a.min_qty_dec, a.sumusage_vchr,
                        //       't_opr_outpatientcmrecipede' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                        //       g.mednormalname_vchr, '' itemunit_vchr,
                        //       g.medicinetypeid_chr
                        //       FROM t_opr_outpatientcmrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f,
                        //       t_bse_usagetype d,
                        //       t_aid_recipefreq e,
                        //       t_bse_medicine g
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.deptmed_int = 0
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND a.itemid_chr = e.freqid_chr(+)
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       AND f.flag_int = 2
                        //       AND a.usageid_chr = d.usageid_chr(+)
                        //       AND b.itemsrcid_vchr = g.medicineid_chr(+)
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       a.unitid_chr, a.qty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                        //       '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                        //       b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                        //       a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                        //       f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                        //       '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       't_opr_outpatientothrecipede' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                        //       g.mednormalname_vchr,a.itemunit_vchr,
                        //       g.medicinetypeid_chr
                        //       FROM t_opr_outpatientothrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f,
                        //       t_bse_medicine g
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.deptmed_int = 0
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       AND b.itemsrcid_vchr = g.medicineid_chr(+)
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       '' unitid_chr, a.qty_dec AS qty_dec, a.price_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                        //       '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                        //       b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                        //       a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                        //       f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                        //       '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       'T_OPR_OUTPATIENTCHKRECIPEDE' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                        //       '' AS mednormalname_vchr,a.itemunit_vchr,
                        //       '' medicinetypeid_chr
                        //       FROM t_opr_outpatientchkrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       '' unitid_chr, a.qty_dec AS qty_dec, a.price_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                        //       '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                        //       b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                        //       a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                        //       f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                        //       '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       'T_OPR_OUTPATIENTTESTRECIPEDE' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                        //       '' AS mednormalname_vchr, a.itemunit_vchr,
                        //       '' medicinetypeid_chr
                        //       FROM t_opr_outpatienttestrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       '' unitid_chr, a.qty_dec AS qty_dec, a.price_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                        //       '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                        //       b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                        //       a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                        //       f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                        //       '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       'T_OPR_OUTPATIENTOPSRECIPEDE' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                        //       '' AS mednormalname_vchr, a.itemunit_vchr,
                        //       '' medicinetypeid_chr
                        //       FROM t_opr_outpatientopsrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND b.itemopinvtype_chr = f.typeid_chr";
                        //try
                        //{
                        //    DataTable dtbResult = new DataTable();
                        //   // clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                        //    ParamArr = null;
                        //    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                        //    ParamArr[0].Value = strRecipedeID;
                        //    ParamArr[1].Value = strRecipedeID;
                        //    ParamArr[2].Value = strRecipedeID;
                        //    ParamArr[3].Value = strRecipedeID;
                        //    ParamArr[4].Value = strRecipedeID;
                        //    ParamArr[5].Value = strRecipedeID;

                        //    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParamArr);

                        if (lngRes > 0 && dtbResult.Rows.Count > 0)
                        {
                            obj_VO = new clsOutpatientPrintRecipe_VO();

                            obj_VO.objinjectArr = new ArrayList();
                            obj_VO.objPRDArr = new ArrayList();
                            obj_VO.objPRDArr2 = new ArrayList();
                            decimal m_decWM = 0;
                            decimal m_decCM = 0;
                            decimal m_decOther = 0;
                            decimal m_decCheck = 0;
                            decimal m_decTest = 0;
                            decimal m_decOperation = 0;
                            for (int i = 0; i < dtbResult.Rows.Count; i++)
                            {
                                clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();

                                objtemp.m_strChargeName = dtbResult.Rows[i]["ITEMNAME_VCHR"].ToString().Trim();
                                objtemp.m_strMEDNORMALNAME = dtbResult.Rows[i]["mednormalname_vchr"].ToString().Trim();
                                objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                objtemp.m_strPrice = dtbResult.Rows[i]["PRICE_MNY"].ToString().Trim();
                                objtemp.m_strSumPrice = dtbResult.Rows[i]["TOLPRICE_MNY"].ToString().Trim();
                                objtemp.m_strUnit = dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                objtemp.m_strFrequency = dtbResult.Rows[i]["FREQNAME_CHR"].ToString().Trim();
                                objtemp.m_strDosage = dtbResult.Rows[i]["DOSAGE_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                objtemp.m_strDays = dtbResult.Rows[i]["DAYS_INT"].ToString().Trim();
                                objtemp.m_strSpec = dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim();
                                objtemp.m_strUsage = dtbResult.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
                                objtemp.m_strRowNo = dtbResult.Rows[i]["ROWNO_CHR"].ToString().Trim();
                                objtemp.m_strUsageDetail = dtbResult.Rows[i]["DESC_VCHR"].ToString().Trim();
                                objtemp.m_strInvoiceCat = dtbResult.Rows[i]["itemopinvtype_chr"].ToString().Trim();
                                obj_VO.m_strHerbalmedicineUsage = "";
                                if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientpwmrecipede")
                                {
                                    m_decWM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                    obj_VO.objPRDArr.Add(objtemp);
                                }
                                else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientcmrecipede")
                                {
                                    obj_VO.m_strHerbalmedicineUsage = dtbResult.Rows[i]["SUMUSAGE_VCHR"].ToString().Trim();
                                    obj_VO.m_strTimes = dtbResult.Rows[i]["TIMES_INT"].ToString().Trim();
                                    m_decCM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                    obj_VO.objPRDArr2.Add(objtemp);
                                }
                                else
                                {
                                    if (dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "其它" && dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "诊金")
                                    {
                                        objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                        obj_VO.objinjectArr.Add(objtemp);
                                        if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "T_OPR_OUTPATIENTCHKRECIPEDE")
                                        {
                                            m_decCheck += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        }
                                        else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "T_OPR_OUTPATIENTTESTRECIPEDE")
                                        {
                                            m_decTest += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        }
                                        else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "T_OPR_OUTPATIENTOPSRECIPEDE")
                                        {
                                            m_decOperation += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        }
                                        else
                                        {
                                            m_decOther += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        }
                                    }
                                }

                            }
                            obj_VO.m_strWMedicineCost = m_decWM.ToString("0.00");
                            obj_VO.m_strZCMedicineCost = m_decCM.ToString("0.00");
                            obj_VO.m_strCureCost = ((decimal)(m_decCheck + m_decTest + m_decOperation + m_decOther)).ToString("0.00");


                        }
                        //}
                        //catch (Exception objEx)
                        //{
                        //    string strTmp = objEx.Message;
                        //    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                        //    bool blnRes = objLogger.LogError(objEx);
                        //}

                    }
                    else
                    {
                        //                        strSQL = @"SELECT a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       a.unitid_chr, a.tolqty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
                        //       a.freqid_chr, d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
                        //       a.dosage_dec, a.itemspec_vchr, a.qty_dec AS dosageqty, a.itemname_vchr,
                        //       b.itemcode_vchr, f.typename_vchr, e.freqname_chr, 0 times_int,
                        //       0 min_qty_dec1, '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       't_opr_outpatientpwmrecipede' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                        //       g.mednormalname_vchr, '' itemunit_vchr,
                        //       g.medicinetypeid_chr
                        //       FROM t_opr_outpatientpwmrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f,
                        //       t_bse_usagetype d,
                        //       t_aid_recipefreq e,
                        //       t_bse_medicine g
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.deptmed_int = 0
                        //       AND a.outpatrecipeid_chr = ?
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       AND f.flag_int = 2
                        //       AND a.usageid_chr = d.usageid_chr(+)
                        //       AND a.freqid_chr = e.freqid_chr(+)
                        //       AND b.itemsrcid_vchr = g.medicineid_chr(+)
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       a.unitid_chr, (a.qty_dec * a.times_int) AS qty_dec,
                        //       a.unitprice_mny AS price_mny, a.tolprice_mny, a.medstoreid_chr,
                        //       '' usageid_chr, 0 AS days_int, '' freqid_chr, d.usagename_vchr,
                        //       '' desc_vchr, b.itemopinvtype_chr, b.dosage_dec, a.itemspec_vchr,
                        //       0 AS dosageqty, a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                        //       e.freqname_chr, a.times_int, a.min_qty_dec AS min_qty_dec1,
                        //       '' usagename_vchr, a.min_qty_dec, a.sumusage_vchr,
                        //       't_opr_outpatientcmrecipede' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                        //       g.mednormalname_vchr, '' itemunit_vchr,
                        //       g.medicinetypeid_chr
                        //       FROM t_opr_outpatientcmrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f,
                        //       t_bse_usagetype d,
                        //       t_aid_recipefreq e,
                        //       t_bse_medicine g
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.deptmed_int = 0
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND a.itemid_chr = e.freqid_chr(+)
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       AND f.flag_int = 2
                        //       AND a.usageid_chr = d.usageid_chr(+)
                        //       AND b.itemsrcid_vchr = g.medicineid_chr(+)
                        //       UNION ALL
                        //       SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                        //       a.unitid_chr, a.qty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                        //       a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                        //       '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                        //       b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                        //       a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                        //       f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                        //       '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                        //       't_opr_outpatientothrecipede' AS fromtable,
                        //       b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                        //       g.mednormalname_vchr,a.itemunit_vchr,
                        //       g.medicinetypeid_chr
                        //       FROM t_opr_outpatientothrecipede a,
                        //       t_bse_chargeitem b,
                        //       t_bse_chargeitemextype f,
                        //       t_bse_medicine g
                        //       WHERE a.itemid_chr = b.itemid_chr
                        //       AND a.deptmed_int = 0
                        //       AND a.outpatrecipeid_chr = ? 
                        //       AND b.itemopinvtype_chr = f.typeid_chr
                        //       AND b.itemsrcid_vchr = g.medicineid_chr(+)";

                        #region 表1
                        strSQL = @"select a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          a.unitid_chr, a.tolqty_dec as qty_dec, a.unitprice_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
                                          a.freqid_chr, d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
                                          a.dosage_dec, a.itemspec_vchr, a.qty_dec as dosageqty, a.itemname_vchr,
                                          b.itemcode_vchr, f.typename_vchr, e.freqname_chr, 0 times_int,
                                          0 min_qty_dec1, '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          't_opr_outpatientpwmrecipede' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
                                          g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr
                                     from t_opr_outpatientpwmrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f,
                                          t_bse_usagetype d,
                                          t_aid_recipefreq e,
                                          t_bse_medicine g
                                    where a.itemid_chr = b.itemid_chr
                                      and a.deptmed_int = 0
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr
                                      and f.flag_int = 2
                                      and a.usageid_chr = d.usageid_chr(+)
                                      and a.freqid_chr = e.freqid_chr(+)
                                      and b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult = dtTemp.Clone();
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表2
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          a.unitid_chr, (a.qty_dec * a.times_int) as qty_dec,
                                          a.unitprice_mny as price_mny, a.tolprice_mny, a.medstoreid_chr,
                                          '' usageid_chr, 0 as days_int, '' freqid_chr, d.usagename_vchr,
                                          '' desc_vchr, b.itemopinvtype_chr, b.dosage_dec, a.itemspec_vchr,
                                          0 as dosageqty, a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                                          e.freqname_chr, a.times_int, a.min_qty_dec as min_qty_dec1,
                                          '' usagename_vchr, a.min_qty_dec, a.sumusage_vchr,
                                          't_opr_outpatientcmrecipede' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, a.discount_dec,
                                          g.mednormalname_vchr, '' itemunit_vchr, g.medicinetypeid_chr
                                     from t_opr_outpatientcmrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f,
                                          t_bse_usagetype d,
                                          t_aid_recipefreq e,
                                          t_bse_medicine g
                                    where a.itemid_chr = b.itemid_chr
                                      and a.deptmed_int = 0
                                      and a.outpatrecipeid_chr = ?
                                      and a.itemid_chr = e.freqid_chr(+)
                                      and b.itemopinvtype_chr = f.typeid_chr
                                      and f.flag_int = 2
                                      and a.usageid_chr = d.usageid_chr(+)
                                      and b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        #endregion

                        #region 表3
                        strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                          a.unitid_chr, a.qty_dec as qty_dec, a.unitprice_mny as price_mny,
                                          a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
                                          '' as freqid_chr, '' as usagename_vchr, '' as desc_vchr,
                                          b.itemopinvtype_chr, 0 as dosage_dec, a.itemspec_vchr,
                                          a.qty_dec as dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                          f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                          '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                          't_opr_outpatientothrecipede' as fromtable,
                                          b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as discount_dec,
                                          g.mednormalname_vchr, a.itemunit_vchr, g.medicinetypeid_chr
                                     from t_opr_outpatientothrecipede a,
                                          t_bse_chargeitem b,
                                          t_bse_chargeitemextype f,
                                          t_bse_medicine g
                                    where a.itemid_chr = b.itemid_chr
                                      and a.deptmed_int = 0
                                      and a.outpatrecipeid_chr = ?
                                      and b.itemopinvtype_chr = f.typeid_chr
                                      and b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            clsHRPTableService HRPSvc = new clsHRPTableService();
                            ParamArr = null;
                            HRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                            HRPSvc.Dispose();
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                        dtbResult.BeginLoadData();
                        for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
                        {
                            dtbResult.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
                        }
                        dtbResult.EndLoadData();
                        dtbResult.AcceptChanges();
                        #endregion
                        for (int i2 = 0; i2 < dtbResult.Rows.Count; i2++)
                        {
                            if (string.IsNullOrEmpty(dtbResult.Rows[i2]["itemcode_vchr"].ToString()))
                            {
                                dtbResult.Rows[i2].Delete();
                                i2--;
                                dtbResult.AcceptChanges();
                            }
                        }
                        dtbResult.AcceptChanges();

                        //try
                        //{                            
                        //    ParamArr = null;
                        //    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        //    ParamArr[0].Value = strRecipedeID;
                        //    ParamArr[1].Value = strRecipedeID;
                        //    ParamArr[2].Value = strRecipedeID;

                        //    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParamArr);

                        if (lngRes > 0 && dtbResult.Rows.Count > 0)
                        {
                            obj_VO = new clsOutpatientPrintRecipe_VO();

                            obj_VO.objinjectArr = new ArrayList();
                            obj_VO.objPRDArr = new ArrayList();
                            obj_VO.objPRDArr2 = new ArrayList();
                            decimal m_decWM = 0;
                            decimal m_decCM = 0;
                            decimal m_decOther = 0;
                            decimal m_decCheck = 0;
                            decimal m_decTest = 0;
                            decimal m_decOperation = 0;
                            for (int i = 0; i < dtbResult.Rows.Count; i++)
                            {
                                clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();

                                objtemp.m_strChargeName = dtbResult.Rows[i]["ITEMNAME_VCHR"].ToString().Trim();
                                objtemp.m_strMEDNORMALNAME = dtbResult.Rows[i]["mednormalname_vchr"].ToString().Trim();
                                objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                objtemp.m_strPrice = dtbResult.Rows[i]["PRICE_MNY"].ToString().Trim();
                                objtemp.m_strSumPrice = dtbResult.Rows[i]["TOLPRICE_MNY"].ToString().Trim();
                                objtemp.m_strUnit = dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                objtemp.m_strFrequency = dtbResult.Rows[i]["FREQNAME_CHR"].ToString().Trim();
                                objtemp.m_strDosage = dtbResult.Rows[i]["DOSAGE_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                objtemp.m_strDays = dtbResult.Rows[i]["DAYS_INT"].ToString().Trim();
                                objtemp.m_strSpec = dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim();
                                objtemp.m_strUsage = dtbResult.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
                                objtemp.m_strRowNo = dtbResult.Rows[i]["ROWNO_CHR"].ToString().Trim();
                                objtemp.m_strUsageDetail = dtbResult.Rows[i]["DESC_VCHR"].ToString().Trim();
                                objtemp.m_strInvoiceCat = dtbResult.Rows[i]["itemopinvtype_chr"].ToString().Trim();
                                obj_VO.m_strHerbalmedicineUsage = "";
                                if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientpwmrecipede")
                                {
                                    m_decWM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                    obj_VO.objPRDArr.Add(objtemp);
                                }
                                else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientcmrecipede")
                                {
                                    obj_VO.m_strHerbalmedicineUsage = dtbResult.Rows[i]["SUMUSAGE_VCHR"].ToString().Trim();
                                    obj_VO.m_strTimes = dtbResult.Rows[i]["TIMES_INT"].ToString().Trim();
                                    m_decCM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                    obj_VO.objPRDArr2.Add(objtemp);
                                }
                                else
                                {
                                    if (dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "其它" && dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "诊金")
                                    {
                                        objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                        obj_VO.objinjectArr.Add(objtemp);
                                        m_decOther += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());

                                    }
                                }

                            }
                            for (int i = 0; i < m_objTempTable.Rows.Count; i++)
                            {
                                clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                                objtemp.m_strCount = m_objTempTable.Rows[i]["QTY_DEC"].ToString().Trim() + "次";
                                objtemp.m_strPrice = m_objTempTable.Rows[i]["PRICEMNY_DEC"].ToString().Trim();
                                objtemp.m_strSumPrice = m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim();
                                objtemp.m_strChargeName = m_objTempTable.Rows[i]["ORDERDICNAME_VCHR"].ToString().Trim();
                                obj_VO.objinjectArr.Add(objtemp);
                                if (m_objTempTable.Rows[i]["TABLEINDEX_INT"].ToString().Trim() == "3")
                                {
                                    m_decCheck += decimal.Parse(m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim());
                                }
                                else if (m_objTempTable.Rows[i]["TABLEINDEX_INT"].ToString().Trim() == "4")
                                {
                                    m_decTest += decimal.Parse(m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim());
                                }
                                else if (m_objTempTable.Rows[i]["TABLEINDEX_INT"].ToString().Trim() == "5")
                                {
                                    m_decOperation += decimal.Parse(m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim());
                                }
                            }
                            obj_VO.m_strWMedicineCost = m_decWM.ToString("0.00");
                            obj_VO.m_strZCMedicineCost = m_decCM.ToString("0.00");
                            obj_VO.m_strCureCost = ((decimal)(m_decCheck + m_decTest + m_decOperation + m_decOther)).ToString("0.00");


                        }
                        //}
                        //catch (Exception objEx)
                        //{
                        //    string strTmp = objEx.Message;
                        //    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                        //    bool blnRes = objLogger.LogError(objEx);
                        //}
                    }
                 

                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
                              a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
                              a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
                              a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr, a.groupid_chr,
                              a.type_int, a.confirm_int, a.confirmdesc_vchr, a.createtype_int,
                              a.deptmed_int, b.name_vchr, c.lastname_vchr, d.deptname_vchr,
                              b.birth_dat, e.lastname_vchr as recordemp, h.homeaddress_vchr,
                              h.sex_chr, h.idcard_chr, h.homephone_vchr, h.govcard_chr,
                              h.difficulty_vchr, h.insuranceid_vchr, k.paytypename_vchr, p.diag_vchr,
                              j.patientcardid_chr,
                              (select sum (totalsum_mny)
                                 from t_opr_outpatientrecipeinv
                                where outpatrecipeid_chr = ? and totalsum_mny > 0) totailmoney
                         from t_opr_outpatientrecipe a,
                              t_bse_patientidx b,
                              t_bse_employee c,
                              t_bse_deptdesc d,
                              t_bse_employee e,
                              t_bse_patient h,
                              t_bse_patientpaytype k,
                              t_bse_patientcard j,
                              t_opr_outpatientcasehis p
                        where a.patientid_chr = b.patientid_chr(+)
                          and a.diagdr_chr = c.empid_chr(+)
                          and a.diagdept_chr = d.deptid_chr(+)
                          and a.recordemp_chr = e.empid_chr(+)
                          and a.patientid_chr = h.patientid_chr(+)
                          and a.paytypeid_chr = k.paytypeid_chr(+)
                          and a.patientid_chr = j.patientid_chr(+)
                          and a.casehisid_chr = p.casehisid_chr(+)
                          and a.outpatrecipeid_chr = ?";

            try
            {
                DataTable dtbResult = new DataTable();
                //clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                 ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strRecipedeID;
                ParamArr[1].Value = strRecipedeID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParamArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    DateTime dteBirth = Convert.ToDateTime("1900-1-1");
                    // if (dtbResult.Rows[0]["BIRTH_DAT"] != System.DBNull.Value)
                    if (dtbResult.Rows[0]["BIRTH_DAT"].ToString().Trim() != "")
                        dteBirth = Convert.ToDateTime(dtbResult.Rows[0]["BIRTH_DAT"].ToString());

                    if (obj_VO == null)
                    {
                        obj_VO = new clsOutpatientPrintRecipe_VO();
                        obj_VO.objinjectArr = new ArrayList();
                        obj_VO.objPRDArr = new ArrayList();
                        obj_VO.objPRDArr2 = new ArrayList();
                    }
                    obj_VO.m_strAge = clsConvertDateTime.CalcAge(dteBirth);                    
                    obj_VO.m_strDiagDrName = dtbResult.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
                   // obj_VO.m_strHospitalName = "佛山第二人民医院";
                    obj_VO.m_strPatientName = dtbResult.Rows[0]["NAME_VCHR"].ToString().Trim();
                    obj_VO.m_strPhotoNo = dtbResult.Rows[0]["HOMEPHONE_VCHR"].ToString().Trim();
                    obj_VO.m_strCardID = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
                    obj_VO.m_strdiagnose = dtbResult.Rows[0]["diag_vchr"].ToString().Trim();
                    obj_VO.m_strPatientType = dtbResult.Rows[0]["PAYTYPENAME_VCHR"].ToString().Trim();
                    obj_VO.m_strDiagDeptID = dtbResult.Rows[0]["DEPTNAME_VCHR"].ToString().Trim();
                    obj_VO.m_strRecipeID = strRecipedeID;
                    obj_VO.m_strRecordEmpID = dtbResult.Rows[0]["DIAGDR_CHR"].ToString().Trim().Substring(3);//员工ID
                    obj_VO.m_strIDcardno = dtbResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["RECORDDATE_DAT"] != System.DBNull.Value)
                        obj_VO.m_strPrintDate = DateTime.Parse(dtbResult.Rows[0]["RECORDDATE_DAT"].ToString()).ToString("yyyy-MM-dd");
                    else
                        obj_VO.m_strPrintDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj_VO.m_strSex = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    obj_VO.m_strSelfPay = "";
                    obj_VO.m_strChargeUp = "";
                    obj_VO.m_strRecipePrice = "";

                    obj_VO.m_strHerbalmedicineUsage = "";
                    obj_VO.m_strAddress = dtbResult.Rows[0]["HOMEADDRESS_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["RECIPEFLAG_INT"].ToString().Trim() == "1")
                    {
                        obj_VO.m_strRecipeType = "正方";
                    }
                    else if (dtbResult.Rows[0]["RECIPEFLAG_INT"].ToString().Trim() == "2")
                    {
                        obj_VO.m_strRecipeType = "副方";
                    }
                    else
                    {
                        obj_VO.m_strRecipeType = "";
                    }
                    obj_VO.m_strGOVCARD = dtbResult.Rows[0]["GOVCARD_CHR"].ToString().Trim();
                    obj_VO.m_strINSURANCEID = dtbResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    obj_VO.m_strRegisterID = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 获取统计科室信息
        [AutoComplete]
        public long m_lngGetOPDeptInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetOPDeptInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = @"SELECT a.deptid_chr, a.deptname_vchr
  FROM t_bse_deptdesc a
  where a.category_int=0 order by a.deptname_vchr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref m_objTable);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
          #endregion
        #region 获取医生工作量信息
        [AutoComplete]
        public long m_lngGetOPDoctorWorkLoadInfo(System.Security.Principal.IPrincipal p_objPrincipal,string m_strBeginTime,string m_strEndTime,string m_strDoctorID, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetOPDoctorWorkLoadInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = @"SELECT a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,
       a.tolfee_mny, b.zfs, c.ffs
  FROM (SELECT   a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr, SUM (c.tolfee_mny) tolfee_mny
            FROM t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (SELECT   b.itemcatid_chr,a.doctorid_chr, e.empno_chr, a.doctorname_chr,
                           SUM (b.tolfee_mny) tolfee_mny
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_opr_outpatientrecipe c,
                           t_opr_reciperelation d,
                           t_bse_employee e
                     WHERE a.seqid_chr = b.seqid_chr(+)
                       AND a.balanceflag_int = 1
                       AND a.outpatrecipeid_chr = d.seqid
                       AND d.outpatrecipeid_chr = c.outpatrecipeid_chr
                       AND a.doctorid_chr = e.empid_chr(+)
                       AND a.balance_dat
                              BETWEEN TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                  GROUP BY b.itemcatid_chr,a.doctorid_chr, e.empno_chr, a.doctorname_chr) c
           WHERE a.groupid_chr = b.groupid_chr(+)
             AND b.typeid_chr = c.itemcatid_chr(+)
             AND a.rptid_chr = '0005'
             AND b.rptid_chr = '0005'
        GROUP BY a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr
        ORDER BY a.groupid_chr) a,
       (SELECT   a.doctorid_chr,
                 COUNT (CASE a.status_int
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
             AND a.balanceflag_int = 1
             AND c.recipeflag_int = 1
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) b,
       (SELECT   a.doctorid_chr,
                 COUNT (CASE a.status_int
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
             AND a.balanceflag_int = 1
             AND c.recipeflag_int = 2
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) c
 WHERE a.doctorid_chr = b.doctorid_chr AND a.doctorid_chr = c.doctorid_chr";
            if (m_strDoctorID != string.Empty)
            {
                strSQL = @"SELECT a.groupid_chr, a.groupname_chr, a.empno_chr, a.doctorname_chr,
       a.tolfee_mny, b.zfs, c.ffs
  FROM (SELECT   a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr, SUM (c.tolfee_mny) tolfee_mny
            FROM t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (SELECT   b.itemcatid_chr,a.doctorid_chr, e.empno_chr, a.doctorname_chr,
                           SUM (b.tolfee_mny) tolfee_mny
                      FROM t_opr_outpatientrecipeinv a,
                           t_opr_outpatientrecipesumde b,
                           t_opr_outpatientrecipe c,
                           t_opr_reciperelation d,
                           t_bse_employee e
                     WHERE a.seqid_chr = b.seqid_chr(+)
                       AND a.balanceflag_int = 1
                       AND a.outpatrecipeid_chr = d.seqid
                       AND d.outpatrecipeid_chr = c.outpatrecipeid_chr
                       AND a.doctorid_chr = e.empid_chr(+)
                       and a.doctorid_chr in ("+m_strDoctorID+@")
                       AND a.balance_dat
                              BETWEEN TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                                  AND TO_DATE (?,
                                               'yyyy-mm-dd hh24:mi:ss'
                                              )
                  GROUP BY b.itemcatid_chr,a.doctorid_chr, e.empno_chr, a.doctorname_chr) c
           WHERE a.groupid_chr = b.groupid_chr(+)
             AND b.typeid_chr = c.itemcatid_chr(+)
             AND a.rptid_chr = '0005'
             AND b.rptid_chr = '0005'
        GROUP BY a.groupid_chr, a.groupname_chr, c.empno_chr,c.doctorid_chr,
                 c.doctorname_chr
        ORDER BY a.groupid_chr) a,
       (SELECT   a.doctorid_chr,
                 COUNT (CASE a.status_int
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
             AND a.balanceflag_int = 1
             AND c.recipeflag_int = 1
             and a.doctorid_chr in (" + m_strDoctorID + @")
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) b,
       (SELECT   a.doctorid_chr,
                 COUNT (CASE a.status_int
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
             AND a.balanceflag_int = 1
             AND c.recipeflag_int = 2
             and a.doctorid_chr in (" + m_strDoctorID + @")
             AND a.balance_dat BETWEEN TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
                                   AND TO_DATE (?,
                                                'yyyy-mm-dd hh24:mi:ss'
                                               )
        GROUP BY a.doctorid_chr) c
 WHERE a.doctorid_chr = b.doctorid_chr AND a.doctorid_chr = c.doctorid_chr";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out paramArr);
                paramArr[0].Value = m_strBeginTime;
                paramArr[1].Value = m_strEndTime;
                paramArr[2].Value = m_strBeginTime;
                paramArr[3].Value = m_strEndTime;
                paramArr[4].Value = m_strBeginTime;
                paramArr[5].Value = m_strEndTime;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, paramArr);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
           #endregion
        #region 根据流水号id获取治疗单信息
        /// <summary>
        /// 根据流水号id获取治疗单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRecipeid"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTreatInfoByRecipeid(System.Security.Principal.IPrincipal p_objPrincipal,string m_strSid_int,out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetTreatInfoByRecipeid");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select   a.pstauts_int, a.outpatrecipeid_chr, b.itemid_chr,
         b.dosageunit_chr as unitid_chr, b.usageid_chr, b.tolqty_dec,
         b.unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, b.days_int, b.qty_dec, b.discount_dec,
         b.freqid_chr, b.itemname_vchr, b.dosageunit_chr, b.itemspec_vchr,
         h.usagename_vchr, k.freqname_chr, b.dosage_dec, m.medicineid_chr,
         m.medicinetypeid_chr, 't_opr_outpatientpwmrecipede' fromtable,
         e.lastname_vchr, h.usageid_chr as usageid,
         b.desc_vchr as itemusagedetail_vchr, b.unitid_chr as itemunit
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientrecipe a,
         t_opr_outpatientpwmrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = 2 and orderid_vchr = '3') f,
         t_bse_usagetype h,
         t_aid_recipefreq k,
         t_bse_medicine m,
         t_bse_employee e
   where m.sid_int = n.sid_int
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and b.freqid_chr = k.freqid_chr
     and b.usageid_chr = f.usageid_chr
     and b.usageid_chr = h.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and m.sid_int = ?
union all
select   a.pstauts_int, a.outpatrecipeid_chr, b.itemid_chr,
         d.dosageunit_chr as unitid_chr, d.usageid_chr, 0 as tolqty_dec,
         b.unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         h.usagename_vchr, '' as freqname_chr, d.dosage_dec, m.medicineid_chr,
         m.medicinetypeid_chr, 't_opr_outpatientpwmrecipede' fromtable,
         e.lastname_vchr, h.usageid_chr as usageid,
         '' as itemusagedetail_vchr, b.unitid_chr as itemunit
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientrecipe a,
         t_opr_outpatientcmrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = 2 and orderid_vchr = '3') f,
         t_bse_usagetype h,
         t_bse_medicine m,
         t_bse_employee e
   where m.sid_int = n.sid_int
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and b.usageid_chr = f.usageid_chr
     and b.usageid_chr = h.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and m.sid_int = ?
union all
select   a.pstauts_int, a.outpatrecipeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         't_opr_outpatientchkrecipede' fromtable, e.lastname_vchr,
         g.usageid_chr as usageid, b.itemusagedetail_vchr,
         b.itemunit_vchr as itmeunit
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientrecipe a,
         t_opr_outpatientchkrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = 2 and orderid_vchr = '3') f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e
   where m.sid_int = n.sid_int
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and m.sid_int = ?
union all
select   a.pstauts_int, a.outpatrecipeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         't_opr_outpatienttestrecipede' fromtable, e.lastname_vchr,
         b.itemunit_vchr as itemunit, g.usageid_chr as usageid,
         b.itemusagedetail_vchr
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientrecipe a,
         t_opr_outpatienttestrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = 2 and orderid_vchr = '3') f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e
   where m.sid_int = n.sid_int
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and m.sid_int = ?
union all
select   a.pstauts_int, a.outpatrecipeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         't_opr_outpatientopsrecipede' fromtable, e.lastname_vchr,
         g.usageid_chr as usageid, b.itemusagedetail_vchr,
         b.itemunit_vchr as itemunit
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientrecipe a,
         t_opr_outpatientopsrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = 2 and orderid_vchr = '3') f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e
   where m.sid_int = n.sid_int
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and m.sid_int = ?
union all
select   a.pstauts_int, a.outpatrecipeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         't_opr_outpatientothrecipede' fromtable, e.lastname_vchr,
         g.usageid_chr as usageid, '' as itemusagedetail_vchr,
         b.itemunit_vchr as itemunit
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientrecipe a,
         t_opr_outpatientothrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = 2 and orderid_vchr = '3') f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e
   where m.sid_int = n.sid_int
     and a.outpatrecipeid_chr = n.outpatrecipeid_chr
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and m.sid_int = ?
order by rowno_chr

";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataParam = null;
                objHRPSvc.CreateDatabaseParameter(6, out m_objDataParam);
                m_objDataParam[0].Value = m_strSid_int;
                m_objDataParam[1].Value = m_strSid_int;
                m_objDataParam[2].Value = m_strSid_int;
                m_objDataParam[3].Value = m_strSid_int;
                m_objDataParam[4].Value = m_strSid_int;
                m_objDataParam[5].Value = m_strSid_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable,m_objDataParam);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion
        #region 专家组处方信息
        /// <summary>
        /// 专家组处方信息
        /// </summary>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetGroupInfo(ref DataTable dtResult)
        {
            long lngRes = 0;
            string strSQL = @"select distinct a.groupid_chr, a.groupname_vchr
                               from t_bse_groupdesc a, t_opr_outpatientrecipe b
                               where a.groupid_chr = b.groupid_chr";
            try
            {
                HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
    }
}
