using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 入院登记。
    /// 作者： 徐斌辉
    /// 创建时间： 2004-09-23
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBihStatQuerySvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造函数
        public clsBihStatQuerySvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        //科室|病区病人流动人员统计
        #region 统计病人数-[时间段、科室、病区]
        #region 总病人数	……有疑问？
        /// <summary>
        /// 统计病人数-[时间段、科室、病区]
        /// 总病人数	[1、这段时间段内在本病区治疗过的所有病人；2、同一个人在这段时间入过n次院算n；]--用的是修改时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strStartDateTime">起始时间</param>
        /// <param name="p_strEndDateTime">结束时间</param>
        /// <param name="p_intNumber">[Out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatPatientNumberAll(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, string p_strAreaID, string p_strStartDateTime, string p_strEndDateTime, out int p_intNumber)
        {
            long lngRes = 0;
            p_intNumber = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "m_lngStatPatientNumberAll");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select count(*) from t_opr_bih_register ";
            strSQL += " where DEPTID_CHR='" + p_strDeptID.Trim() + "' AND AREAID_CHR='" + p_strAreaID.Trim() + "' ";
            strSQL += "     And MODIFY_DAT>To_Date('" + p_strStartDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss') ";
            strSQL += "	   And MODIFY_DAT<To_Date('" + p_strEndDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss') ";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"select count(*) from t_opr_bih_register ";
                strSQL += " where DEPTID_CHR='" + p_strDeptID.Trim() + "' AND AREAID_CHR='" + p_strAreaID.Trim() + "' ";
                strSQL += "     And MODIFY_DAT>CONVERT(DATETIME,'" + p_strStartDateTime.Trim() + "') ";
                strSQL += "	   And MODIFY_DAT<CONVERT(DATETIME,'" + p_strEndDateTime.Trim() + "') ";

            }
            /* <<======================================= */
            DataTable p_dtbResult = new DataTable();
            lngRes = 0;
            lngRes = lngSelectSQL(strSQL, out p_dtbResult);
            if (lngRes > 0 && p_dtbResult.Rows.Count > 0)
                p_intNumber = Int32.Parse(p_dtbResult.Rows[0][0].ToString());

            return lngRes;
        }
        #endregion
        #region 病人数-根据病情	(病危、病重、普通)
        /// <summary>
        /// 统计病人数-[时间段、科室、病区]
        /// 病人数-根据病情	(病危、病重、普通)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strStartDateTime">起始时间</param>
        /// <param name="p_strEndDateTime">结束时间</param>
        /// <param name="intState">病情	[1、病危；2、病重；3、普通；]</param>
        /// <param name="p_intNumber">[Out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatPatientNumberByState(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, string p_strAreaID, string p_strStartDateTime, string p_strEndDateTime, int intState, out int p_intNumber)
        {
            long lngRes = 0;
            p_intNumber = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "m_lngStatPatientNumberByState");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select count(*) from t_opr_bih_register ";
            strSQL += " where DEPTID_CHR='" + p_strDeptID.Trim() + "' AND AREAID_CHR='" + p_strAreaID.Trim() + "' ";
            strSQL += "     And MODIFY_DAT>To_Date('" + p_strStartDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss') ";
            strSQL += "	   And MODIFY_DAT<To_Date('" + p_strEndDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss') ";
            strSQL += "	   AND STATE_INT=intState.ToString() ";
            /* @update by wjqin (05-11-28)
                                     * 添加SQL SERVER的strSQl版本语名
                                     */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"select count(*) from t_opr_bih_register ";
                strSQL += " where DEPTID_CHR='" + p_strDeptID.Trim() + "' AND AREAID_CHR='" + p_strAreaID.Trim() + "' ";
                strSQL += "     And MODIFY_DAT>CONVERT(DATETIME,'" + p_strStartDateTime.Trim() + "') ";
                strSQL += "	   And MODIFY_DAT<CONVERT(DATETIME,'" + p_strEndDateTime.Trim() + "') ";
                strSQL += "	   AND STATE_INT=intState.ToString() ";
            }
            /* <<======================================= */
            DataTable p_dtbResult = new DataTable();
            lngRes = 0;
            lngRes = lngSelectSQL(strSQL, out p_dtbResult);
            if (lngRes > 0 && p_dtbResult.Rows.Count > 0)
                p_intNumber = Int32.Parse(p_dtbResult.Rows[0][0].ToString());

            return lngRes;
        }
        #endregion

        #region 增加数		……有疑问？
        /// <summary>
        /// 统计病人数-[时间段、科室、病区]
        /// 增加数	[1、这段时间内新入院的在本病区治疗过的所有病人；]--用入院时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strStartDateTime">起始时间</param>
        /// <param name="p_strEndDateTime">结束时间</param>
        /// <param name="p_intNumber">[Out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatPatientNumberAdd(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, string p_strAreaID, string p_strStartDateTime, string p_strEndDateTime, out int p_intNumber)
        {
            long lngRes = 0;
            p_intNumber = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "m_lngStatPatientNumberAdd");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select count(*) from t_opr_bih_register ";
            strSQL += " where DEPTID_CHR='" + p_strDeptID.Trim() + "' AND AREAID_CHR='" + p_strAreaID.Trim() + "' ";
            strSQL += "     And INPATIENT_DAT>To_Date('" + p_strStartDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss') ";
            strSQL += "	   And INPATIENT_DAT<To_Date('" + p_strEndDateTime.Trim() + "','YYYY-MM-DD hh24:mi:ss') ";

            DataTable p_dtbResult = new DataTable();
            lngRes = 0;
            lngRes = lngSelectSQL(strSQL, out p_dtbResult);
            if (lngRes > 0 && p_dtbResult.Rows.Count > 0)
                p_intNumber = Int32.Parse(p_dtbResult.Rows[0][0].ToString());

            return lngRes;
        }
        #endregion
        #region 转入	……有疑问？
        /// <summary>
        /// 转入数	[1、这段时间内入院的；2、入院登记存在；3、调转表中存在；]
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID"></param>
        /// <param name="p_strAreaID"></param>
        /// <param name="p_strStartDateTime"></param>
        /// <param name="p_strEndDateTime"></param>
        /// <param name="p_intNumber"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatPatientNumberTurnIn(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, string p_strAreaID, string p_strStartDateTime, string p_strEndDateTime, out int p_intNumber)
        {
            p_intNumber = 0;
            return -1;
        }
        #endregion

        #region 减少数
        #endregion
        #region 出院
        #endregion
        #region 转院
        #endregion
        #region 专科
        #endregion
        #region 死亡
        #endregion
        #endregion

        #region 统计病人信息-[时间段、科室、病区]
        #region 新增危重病人
        #endregion
        #region 取消危重病人
        #endregion
        #region 抢救危重病人
        #endregion

        #region 入科病人
        #endregion
        #region 出科病人
        #endregion
        #endregion

        //全院病人流动情况统计

        //病人流动日报

        //报表：科室、病区统计报表 （科室ID、科室名称、病区名称、昨日人数、今日入院人数、今日转入人数、今日转出人数、今日出院人数、今日死亡人数、今日在院人数、今日开放床位数、统计时间）
        #region 科室、病区统计报表
        /// <summary>
        /// 科室、病区统计报表 （科室ID、科室名称、病区名称、昨日人数、今日入院人数、今日转入人数、今日转出人数、今日出院人数、今日死亡人数、今日在院人数、今日开放床位数、统计时间）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_dtFromTime">统计开始时间</param>
        /// <param name="p_dtToTime">统计结束时间</param>
        /// <param name="p_dtbResult">out 参数，返回的表（）</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRepDeptByDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, DateTime p_dtFromTime, DateTime p_dtToTime, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "m_lngRepDeptByDate");
            string strDateTime = "1900-1-1 00:00:00";
            string strEndDate = "1900-1-1 00:00:00";
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                strDateTime = p_dtFromTime.ToShortDateString() + " 00:00:00";
                strEndDate = p_dtToTime.ToShortDateString() + " 23:59:59";
            }
            catch
            {
                return -1;
            }
            /*
            #region SQL
            string strSQL = @"select ";
            strSQL +="     '" + p_strDeptID.Trim() + "' DeptID ";
            strSQL +="     ,(select deptname_vchr from t_bse_deptdesc d where deptid_chr='" + p_strDeptID.Trim() + "') DeptName ";
            strSQL +="     ,deptname_vchr AreaName ";
            //昨天在院人数
            strSQL +="     ,(select count(*) ";
            strSQL +="      from ";
            strSQL +="      (";
            strSQL +="         select distinct trim(registerid_chr) registerid_chr,trim(areaid_chr) areaid_chr from t_opr_bih_register";
            strSQL +="         where status_int=1 ";
            strSQL +="             and trunc(modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd')-1 ";
            strSQL +="         union ";
            strSQL +="         select distinct trim(registerid_chr) registerid_chr,trim(targetareaid_chr) areaid_chr ";
            strSQL +="         from t_opr_bih_transfer x ";
            strSQL +="         where ";
            strSQL +="             x.registerid_chr not in ";
            strSQL +="             (select y.registerid_chr from t_opr_bih_transfer y ";
            strSQL +="             where ";
            strSQL +="                 x.targetareaid_chr=y.sourceareaid_chr ";
            strSQL +="                 and x.modify_dat<y.modify_dat ";
            strSQL +="                 and trunc(y.modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd')-1 ";
            strSQL +="             ) ";
            strSQL +="             and trunc(x.modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd')-1 ";
            strSQL +="      ) ";
            strSQL +="      where ";
            strSQL +="         registerid_chr not in ";
            strSQL +="         (select registerid_chr from t_opr_bih_leave ";
            strSQL +="         where status_int=1 ";
            strSQL +="             and trunc(modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd')-1 ";
            strSQL +="         ) ";
            strSQL +="         and trim(areaid_chr)=t_bse_deptdesc.deptid_chr ";
            strSQL +="      )YdayNumbers ";
            //今天入院人数
            strSQL +="     ,(select distinct count(*) from ";
            strSQL +=" 	   (select distinct ";
            strSQL +=" 			trim(tt.REGISTERID_CHR) REGISTERID_CHR ";
            strSQL +=" 			,trim(tt.areaid_chr) areaid_chr ";
            strSQL +=" 			,inpatient_dat ";
            strSQL +=" 		from t_opr_bih_register, ";
            strSQL +=" 		  (select ";
            strSQL +=" 				t.REGISTERID_CHR ";
            strSQL +=" 				,(select sourceareaid_chr from t_opr_bih_transfer Tem where Tem.registerid_chr=t.registerid_chr and Tem.modify_dat=t.modify_dat) areaid_chr ";
            strSQL +=" 			from ";
            strSQL +=" 				(select REGISTERID_CHR,min(modify_dat) modify_dat from t_opr_bih_transfer group by REGISTERID_CHR) T ";
            strSQL +=" 		  )TT ";
            strSQL +=" 		where t_opr_bih_register.registerid_chr=TT.registerid_chr ";
            strSQL +=" 		union ";
            strSQL +=" 		select distinct ";
            strSQL +=" 			trim(REGISTERID_CHR) REGISTERID_CHR ";
            strSQL +=" 			,trim(areaid_chr) areaid_chr ";
            strSQL +=" 			,inpatient_dat ";
            strSQL +=" 		from t_opr_bih_register ";
            strSQL +=" 		where status_int=1 and (inpatient_dat=modify_dat or modify_dat is null) ";
            strSQL +=" 	   ) ";
            strSQL +=" 	 where ";
            strSQL +="         areaid_chr=t_bse_deptdesc.deptid_chr ";
            strSQL +="         and trunc(inpatient_dat)=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="     ) EnterHospitalNumbers ";
            //今天转入人数
            strSQL +="     ,(select count(*) from t_opr_bih_transfer ";
            strSQL +="      where  ";
            strSQL +="      targetareaid_chr=t_bse_deptdesc.deptid_chr ";
            strSQL +="      and trunc(modify_dat)=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="      ) TurninNumbers ";
            //今天转出人数
            strSQL +="     ,(select count(*) from t_opr_bih_transfer ";
            strSQL +="      where sourceareaid_chr=t_bse_deptdesc.deptid_chr ";
            strSQL +="      and trunc(modify_dat)=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="      ) TurnoutNumbers ";
            //今天出院人数
            strSQL +="     ,(select count(*) from t_opr_bih_leave ";
            strSQL +="      where  ";
            strSQL +="      status_int=1 ";
            strSQL +="      and outareaid_chr=t_bse_deptdesc.deptid_chr ";
            strSQL +="      and trunc(modify_dat)=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="      ) LeaveHospitalNumbers ";
            //今天死亡人数
            strSQL +="     ,(select count(*) from t_opr_bih_leave ";
            strSQL +="      where  ";
            strSQL +="      status_int=1 ";
            strSQL +="      and outareaid_chr=t_bse_deptdesc.deptid_chr ";
            strSQL +="      and TYPE_INT='4-死亡' ";
            strSQL +="      and trunc(modify_dat)=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="      ) DeathNumbers ";
            //今天在院人数
            strSQL +="     ,(select count(*) ";
            strSQL +="      from ";
            strSQL +="      (";
            strSQL +="         select distinct trim(registerid_chr) registerid_chr,trim(areaid_chr) areaid_chr from t_opr_bih_register";
            strSQL +="         where status_int=1 ";
            strSQL +="             and trunc(modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="         union ";
            strSQL +="         select distinct trim(registerid_chr) registerid_chr,trim(targetareaid_chr) areaid_chr ";
            strSQL +="         from t_opr_bih_transfer x ";
            strSQL +="         where ";
            strSQL +="             x.registerid_chr not in ";
            strSQL +="             (select y.registerid_chr from t_opr_bih_transfer y ";
            strSQL +="             where ";
            strSQL +="                 x.targetareaid_chr=y.sourceareaid_chr ";
            strSQL +="                 and x.modify_dat<y.modify_dat ";
            strSQL +="                 and trunc(y.modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="             ) ";
            strSQL +="             and trunc(x.modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="      ) ";
            strSQL +="      where ";
            strSQL +="         registerid_chr not in ";
            strSQL +="         (select registerid_chr from t_opr_bih_leave ";
            strSQL +="         where status_int=1 ";
            strSQL +="             and trunc(modify_dat)<=to_date('" + strDateTime + "','yyyy-mm-dd') ";
            strSQL +="         ) ";
            strSQL +="         and trim(areaid_chr)=t_bse_deptdesc.deptid_chr ";
            strSQL +="      )TodayBihNumbers ";
            //今天开放床位
            strSQL +="     ,(SELECT count(*) FROM t_bse_bed a ";
            strSQL +="      WHERE category_int=1 and areaid_chr=t_bse_deptdesc.deptid_chr ";
            strSQL +="      )OpenBedNumbers ";

            strSQL +="     ,'" + strDateTime + "' StatDateTime ";
            strSQL +=" FROM t_bse_deptdesc ";
            strSQL +=" WHERE status_int=1 and attributeid='0000003' ";
            strSQL +="		and parentid='" + p_strDeptID.Trim() + "'";
            #endregion
            */
            /*string strSQL = @" select a.YESTERDAYCOUNT,a.TODAYCOUNT,
                        (SELECT COUNT (*)
                                       AS inhospitalcount
                           FROM t_opr_bih_transfer
                          WHERE targetareaid_chr =
                                                 '[sickroomID]'
                            AND type_int = '5'
                            AND modify_dat > TO_DATE ('[statdate]','yyyy-mm-dd')) AS inhospitalcount,
                        (SELECT COUNT (*) AS incount
                           FROM t_opr_bih_transfer
                          WHERE targetareaid_chr = '[sickroomID]'
                            AND modify_dat > TO_DATE ('[statdate]','yyyy-mm-dd')
                            AND sourceareaid_chr IS NOT NULL) AS incount,
                        (SELECT COUNT (*) AS outcount
                           FROM t_opr_bih_transfer
                          WHERE sourceareaid_chr = '[sickroomID]'
                            AND modify_dat > TO_DATE ('[statdate]','yyyy-mm-dd')
                            AND targetareaid_chr IS NOT NULL) AS outcount,
                        (SELECT COUNT (*)
                                     AS outhospitalcount
                           FROM t_opr_bih_leave
                          WHERE outareaid_chr = '[sickroomID]'
                            AND status_int <> '0'
                            AND modify_dat > TO_DATE ('[statdate]','yyyy-mm-dd')) AS outhospitalcount,
                        (SELECT COUNT (*) AS deadcount
                           FROM t_opr_bih_leave
                          WHERE status_int <> '0'
                            AND outareaid_chr = '[sickroomID]'
                            AND type_int = '4'
                            AND modify_dat > TO_DATE ('[statdate]','yyyy-mm-dd')) AS deadcount,
                        (SELECT COUNT (*) AS deadin24
                           FROM t_opr_bih_leave a,
                                t_opr_bih_register b
                          WHERE a.registerid_chr = b.registerid_chr
                            AND a.type_int = '4'
                            AND (  bihpack.getdate (a.modify_dat)
                                 - bihpack.getdate (b.modify_dat)
                                ) < 1
                            AND a.outareaid_chr = '[sickroomID]'
                            AND a.modify_dat > TO_DATE ('[statdate]','yyyy-mm-dd')) AS deadcountin24
                            from T_BAL_BIH_LOGSTAT a
                            where a.AREAID_CHR = '[sickroomID]'";*/
            string strSQL = @"select (totalnum - inhospitalnum - innum + outnum + outhospitalnum
       ) as yesterdaycount,
        inhospitalnum as inhospitalcount,
       innum as incount, outnum as outcount,
       outhospitalnum as outhospitalcount, deadoutnum as deadcount,
       deadin24 as deadcountin24,totalnum as todaycount
  from (select                                                  --今日在院人数
               (select count(t1.registerid_chr)
                  from t_opr_bih_register t1
                 where not exists --不算转出、出院的病人
                 (select t2.registerid_chr, t2.type_int
                          from t_opr_bih_transfer t2
                         where t2.registerid_chr = t1.registerid_chr
                           and t2.type_int in (3, 6, 7)
                           and t2.sourceareaid_chr = '[sickroomID]'
                           and t2.modify_dat <
                               to_date('[Enddate]', 'yyyy-mm-dd hh24:mi:ss')
                        minus --转出之后又转回来的病人
                        select t3.registerid_chr, t3.type_int
                          from t_opr_bih_transfer t3
                         where t3.registerid_chr = t1.registerid_chr
                           and t3.type_int = 3
                           and t3.targetareaid_chr = '[sickroomID]'
                           and t3.modify_dat <=
                               to_date('[Enddate]', 'yyyy-mm-dd hh24:mi:ss'))
                   and t1.status_int = 1
                   and t1.inpatient_dat <
                       to_date('[Enddate]', 'yyyy-mm-dd hh24:mi:ss')
                   and t1.inpatient_dat >
                         to_date('2007-1-1 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                   and t1.areaid_chr = '[sickroomID]') AS totalnum,
               
               --今日入院人数
               (select count (distinct tr.registerid_chr)
                  from t_opr_bih_transfer tr, t_opr_bih_register reg
                 where tr.registerid_chr = reg.registerid_chr
                   and tr.type_int = 5
                   and reg.status_int = 1 
                   and tr.targetareaid_chr = '[sickroomid]'
                   and reg.inpatient_dat >=
                          to_date ('[statdate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and reg.inpatient_dat <=
                          to_date ('[Enddate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )) AS inhospitalnum,
               
               --转入人数
               (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 3
                   and targetareaid_chr = '[sickroomID]'
                   and modify_dat >
                          to_date ('[statdate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and modify_dat <=
                          to_date ('[Enddate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )) AS innum,
               
               -- 转出人数
               (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 3
                   and sourceareaid_chr = '[sickroomID]'
                   and modify_dat >
                          to_date ('[statdate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and modify_dat <
                          to_date ('[Enddate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )) AS outnum,
               
               --出院
               (select count (distinct registerid_chr)
                  from t_opr_bih_leave
                 where status_int = 1
                   and outhospital_dat >=
                          to_date ('[statdate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and outhospital_dat <=
                          to_date ('[Enddate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and  outareaid_chr = '[sickroomID]') as outhospitalnum,
               
               --出院死亡
               (select count (distinct a.registerid_chr)
                  from t_opr_bih_transfer a, t_opr_bih_leave b
                 where a.registerid_chr = b.registerid_chr
                   and a.modify_dat = b.modify_dat
                   and a.type_int = 6
                   and a.sourceareaid_chr = '[sickroomid]'
                   and b.type_int = 4
                   and a.modify_dat >=
                          to_date ('[statdate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and a.modify_dat <=
                          to_date ('[Enddate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )) AS deadoutnum,
               
               --24小时死亡
               (select count (distinct a.registerid_chr)
                  from t_opr_bih_transfer a,
                       t_opr_bih_leave b,
                       (select   max (modify_dat) as modify_dat,
                                 registerid_chr
                            from t_opr_bih_transfer
                           where (type_int = 3 or type_int = 5)
                             and targetareaid_chr = ''
                        group by registerid_chr) c
                 where a.registerid_chr = b.registerid_chr
                   and a.modify_dat = b.modify_dat
                   and a.registerid_chr = c.registerid_chr
                   and a.type_int = 6
                   and a.sourceareaid_chr = '[sickroomid]'
                   and b.type_int = 4
                   and (a.modify_dat - c.modify_dat) < 1
                   and a.modify_dat >
                          to_date ('[statdate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )
                   and a.modify_dat <=
                          to_date ('[Enddate]',
                                   'yyyy-mm-dd hh24:mi:ss'
                                  )) AS deadin24
          from t_opr_bih_transfer
         where rownum = 1)";






            /* @update by wjqin (05-11-28)
                       * 添加SQL SERVER的strSQl版本语名
                       */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"select (
                                                         --今日在院人数
                (select count (distinct registerid_chr)
                  from t_opr_bih_register
                 where pstatus_int <> 3
                   and status_int = 1
                   and areaid_chr = '[sickroomID]')
                -     (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where targetareaid_chr = '[sickroomID]'
                   and type_int = 5
                   and modify_dat >
                          convert(datetime,'[statdate]')
                   and modify_dat <
                          convert(datetime,'[Enddate]')
                                  )
                -  (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 3
                   and targetareaid_chr = '[sickroomID]'
                   and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                  ) 
             +  (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 3
                   and sourceareaid_chr = '[sickroomID]'
                    and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                 
                                  )
            +  (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 6
                   and sourceareaid_chr = '[sickroomID]'
                   and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                  )
       ) AS  yesterdaycount,
         (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where targetareaid_chr = '[sickroomID]'
                   and type_int = 5
               and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                  ) as inhospitalcount,
       (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 3
                   and targetareaid_chr = '[sickroomID]'
               and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                  )  as incount,
       (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 3
                   and sourceareaid_chr = '[sickroomID]'
                  and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                  )  as outcount,
       (select count (distinct registerid_chr)
                  from t_opr_bih_transfer
                 where type_int = 6
                   and sourceareaid_chr = '[sickroomID]'
                  and modify_dat >
                          convert (datetime,'[statdate]')
                   and modify_dat <
                          convert (datetime,'[Enddate]')
                                  )  as outhospitalcount, 
       (select count (distinct a.registerid_chr)
                  from t_opr_bih_transfer a, t_opr_bih_leave b
                 where a.registerid_chr = b.registerid_chr
                   and a.modify_dat = b.modify_dat
                   and a.type_int = 6
                   and a.sourceareaid_chr = '[sickroomID]'
                   and b.type_int = 4
                 and a.modify_dat >
                          convert (datetime,'[statdate]')
                   and a.modify_dat <
                          convert (datetime,'[Enddate]')
                                  ) as deadcount,
       (select count (distinct a.registerid_chr)
                  from t_opr_bih_transfer a,
                       t_opr_bih_leave b,
                       (select   max (modify_dat) as modify_dat,
                                 registerid_chr
                            from t_opr_bih_transfer
                           where (type_int = 3 or type_int = 5)
                             and targetareaid_chr = ''
                        group by registerid_chr) c
                 where a.registerid_chr = b.registerid_chr
                   and a.modify_dat = b.modify_dat
                   and a.registerid_chr = c.registerid_chr
                   and a.type_int = 6
                   and a.sourceareaid_chr = '[sickroomID]'
                   and b.type_int = 4
                   and a.modify_dat >
                          convert (datetime,'[statdate]')
                   and a.modify_dat <
                          convert (datetime,'[Enddate]')
                                  ) as deadcountin24,
  (select count (distinct registerid_chr)
                  from t_opr_bih_register
                 where pstatus_int <> 3
                   and status_int = 1
                   and areaid_chr = '[sickroomID]') as todaycount
 
        
          from t_opr_bih_transfer";
            }
            /* <<======================================= */







            strSQL = strSQL.Replace("[sickroomID]", p_strDeptID);
            strSQL = strSQL.Replace("[statdate]", strDateTime);
            strSQL = strSQL.Replace("[Enddate]", strEndDate);
            lngRes = 0;
            lngRes = lngSelectSQL(strSQL, out p_dtbResult);
            return lngRes;
        }
        #region 病室统计详细信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AreaID">病区ID</param>
        /// <param name="dtStatTime">统计时间</param>
        /// <param name="Type_int">0:入院1：转入2:转出3：出院</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetSickRoomLogDetail(string AreaID, System.DateTime dtStatTime, int Type_int, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strStatDate = dtStatTime.ToShortDateString() + " 00:00:00";
            string strEndDate = dtStatTime.AddDays(1).ToShortDateString() + " 00:00:00";
            string strSQL = @"";
            switch (Type_int)
            {
                case 0:
                    strSQL = @"SELECT a.inpatientid_chr,a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = targetbedid_chr) as code_chr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr and b.type_int = 5 AND b.targetareaid_chr = '[AreaID]'
   AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
   AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')";
                    /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
                    if (clsHRPTableService.bytDatabase_Selector == 0)
                    {
                        strSQL = @"SELECT a.inpatientid_chr,a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = targetbedid_chr) as code_chr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr and b.type_int = 5 AND b.targetareaid_chr = '[AreaID]'
   --AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
  -- AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')
  AND b.modify_dat>CONVERT(DATETIME,'[BeginDate]')
  AND b.modify_dat<CONVERT(DATETIME,'[EndDate]')";
                    }
                    /* <<======================================= */
                    break;
                case 1:
                    strSQL = @"SELECT a.inpatientid_chr, a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = targetbedid_chr) AS code_chr,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = b.sourceareaid_chr) AS deptname_vchr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr
   AND b.type_int = 3
   AND b.targetareaid_chr = '[AreaID]'
   AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
   AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')";
                    /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
                    if (clsHRPTableService.bytDatabase_Selector == 0)
                    {
                        strSQL = @"SELECT a.inpatientid_chr, a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = targetbedid_chr) AS code_chr,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = b.sourceareaid_chr) AS deptname_vchr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr
   AND b.type_int = 3
   AND b.targetareaid_chr = '[AreaID]'
  -- AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
 --  AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')
 AND b.modify_dat>CONVERT(DATETIME,'[BeginDate]')
   AND b.modify_dat<CONVERT(DATETIME,'[EndDate]')";
                    }
                    /* <<======================================= */
                    break;
                case 2:
                    strSQL = @"SELECT a.inpatientid_chr, a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = SOURCEBEDID_CHR) AS code_chr,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = b.targetareaid_chr) AS deptname_vchr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr
   AND b.type_int = 3
   AND b.SOURCEAREAID_CHR = '[AreaID]'
   AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
   AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')";
                    /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
                    if (clsHRPTableService.bytDatabase_Selector == 0)
                    {
                        strSQL = @"SELECT a.inpatientid_chr, a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = SOURCEBEDID_CHR) AS code_chr,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = b.targetareaid_chr) AS deptname_vchr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr
   AND b.type_int = 3
   AND b.SOURCEAREAID_CHR = '[AreaID]'
   --AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
   --AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')
   AND b.modify_dat>CONVERT(DATETIME,'[BeginDate]')
   AND b.modify_dat<CONVERT(DATETIME,'[EndDate]')";
                    }
                    /* <<======================================= */
                    break;
                case 3:
                    strSQL = @"SELECT a.inpatientid_chr, a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = sourcebedid_chr) AS code_chr,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = b.sourceareaid_chr) AS deptname_vchr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr
   AND b.type_int = 6
   AND b.sourceareaid_chr = '[AreaID]'
   AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
   AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')";
                    /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
                    if (clsHRPTableService.bytDatabase_Selector == 0)
                    {
                        strSQL = @"SELECT a.inpatientid_chr, a.lastname_vchr, a.sex_chr,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = sourcebedid_chr) AS code_chr,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = b.sourceareaid_chr) AS deptname_vchr
  FROM t_bse_patient a,
       (SELECT a.*, b.patientid_chr
          FROM t_opr_bih_transfer a, t_opr_bih_register b
         WHERE a.registerid_chr = b.registerid_chr
           AND a.modify_dat = b.modify_dat) b
 WHERE a.patientid_chr = b.patientid_chr
   AND b.type_int = 6
   AND b.sourceareaid_chr = '[AreaID]'
   --AND b.modify_dat>to_date('[BeginDate]','YYYY-MM-DD HH24:MI:SS')
   --AND b.modify_dat<to_date('[EndDate]','YYYY-MM-DD HH24:MI:SS')
   AND b.modify_dat>CONVERT(DATETIME,'[BeginDate]')
   AND b.modify_dat<CONVERT(DATETIME,'[EndDate]')";
                    }
                    /* <<======================================= */
                    break;
                case 4:
                    strSQL = @"";
                    break;
                case 5:
                    strSQL = @"";
                    break;
                default:
                    break;
            }
            if (strSQL != "")
            {
                strSQL = strSQL.Replace("[AreaID]", AreaID);
                strSQL = strSQL.Replace("[BeginDate]", strStatDate);
                strSQL = strSQL.Replace("[EndDate]", strEndDate);
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                    lngRes = 0;
                    lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                    objService.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                return lngRes;
            }
            return 0;
        }
        #endregion


        #region 病区病人欠费一览表
        [AutoComplete]
        public long m_lngGetPatientDebt(int type, string AreaID, string RegisterId, System.DateTime StatDate, string InpatientId, string PatientCardId, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT bedno, inpatientid_chr, lastname_vchr, paytype, sex_chr, birth_dat,registerid_chr,
       patientcardid_chr, inpatient_dat,
       DECODE (notclear, NULL, 0, notclear) AS notclear, money_dec,
       charge_dec, areaname,
       DECODE ((money_dec - decode(sign(notclear),null,0,notclear)),
               NULL, 0,
               (money_dec - decode(sign(notclear),null,0,notclear))
              ) AS balance,
       round(DECODE (SIGN (charge_dec),
               1, (chgofmepay_dec / charge_dec) * 100
              ),2) AS selfpaypercent
  FROM (SELECT (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = a.bedid_chr) bedno, a.inpatientid_chr,
               (SELECT deptname_vchr
                  FROM t_bse_deptdesc
                 WHERE deptid_chr = a.areaid_chr) AS areaname,
               a.inpatient_dat, a.registerid_chr, b.lastname_vchr, b.sex_chr,
               birth_dat, e.patientcardid_chr,
               (SELECT paytypename_vchr
                  FROM t_bse_patientpaytype
                 WHERE paytypeid_chr = b.paytypeid_chr) AS paytype,
               (c.charge_dec - c.clearchg_dec) AS notclear,
               DECODE (c.chgofmepay_dec,
                       NULL, 0,
                       c.chgofmepay_dec
                      ) AS chgofmepay_dec,
               DECODE (c.charge_dec, NULL, 0, c.charge_dec) AS charge_dec,
               DECODE (d.money_dec, NULL, 0, d.money_dec) money_dec
          FROM t_opr_bih_register a,
               t_bse_patient b,
               (SELECT   SUM (charge_dec) AS charge_dec,
                         SUM (chgofmepay_dec) AS chgofmepay_dec,
                         SUM (clearchg_dec) AS clearchg_dec, registerid_chr
                    FROM t_opr_bih_dayaccount
                GROUP BY registerid_chr) c,
               (SELECT a.registerid_chr, SUM (a.money_dec) AS money_dec
  FROM t_opr_bih_prepay a
 WHERE a.status_int = 1 AND ISCLEAR_INT=0
 group by a.registerid_chr) d,
               t_bse_patientcard e
         WHERE a.inpatientid_chr = b.inpatientid_chr
           AND a.registerid_chr = c.registerid_chr(+)
           AND a.registerid_chr = d.registerid_chr(+)
           AND b.patientid_chr = e.patientid_chr(+)
           AND a.pstatus_int [type]";

            /* @update by wjqin (05-11-29)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"(SELECT 
       (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = a.bedid_chr) bedno, 

  
       a.inpatientid_chr,
       b.lastname_vchr,
       (SELECT paytypename_vchr
                  FROM t_bse_patientpaytype
                 WHERE paytypeid_chr = b.paytypeid_chr) AS paytype,
        b.sex_chr,
      birth_dat,
        a.registerid_chr,
       e.patientcardid_chr,
       a.inpatient_dat,
   
       (CASE (c.charge_dec - c.clearchg_dec) WHEN  NULL THEN  0 ELSE (c.charge_dec - c.clearchg_dec) END) AS notclear, 
       money_dec,
       charge_dec, 
      (SELECT deptname_vchr
                  FROM t_bse_deptdesc
                 WHERE deptid_chr = a.areaid_chr) AS areaname,
   
      (CASE ((CASE d.money_dec WHEN  NULL THEN  0 ELSE d.money_dec END) - (CASE sign((c.charge_dec - c.clearchg_dec)) WHEN null THEN 0 ELSE (c.charge_dec - c.clearchg_dec) END)) WHEN 
               NULL THEN 0 ELSE
               (money_dec - (CASE sign((c.charge_dec - c.clearchg_dec)) WHEN null THEN 0 ELSE (c.charge_dec - c.clearchg_dec) END))
             END ) AS balance,
       round( ( CASE SIGN ((CASE c.charge_dec WHEN NULL THEN  0 ELSE c.charge_dec END)) WHEN 
               1 THEN ((CASE c.chgofmepay_dec WHEN NULL THEN  0 ELSE c.chgofmepay_dec END) / (CASE c.charge_dec WHEN NULL THEN  0 ELSE c.charge_dec END)) * 100
               END ),2) AS selfpaypercent
             
               FROM 

                t_opr_bih_register a
               FULL JOIN  t_bse_patient b ON a.inpatientid_chr = b.inpatientid_chr
               LEFT JOIN 
               (SELECT   SUM (charge_dec) AS charge_dec,
                         SUM (chgofmepay_dec) AS chgofmepay_dec,
                         SUM (clearchg_dec) AS clearchg_dec, registerid_chr
                    FROM t_opr_bih_dayaccount
                    GROUP BY registerid_chr) c ON a.registerid_chr = c.registerid_chr
               LEFT JOIN 
               ( SELECT a.registerid_chr, SUM (a.money_dec) AS money_dec
                 FROM t_opr_bih_prepay a
                 WHERE a.status_int = 1 AND ISCLEAR_INT=0
                 group by a.registerid_chr) d ON a.registerid_chr = d.registerid_chr
               LEFT JOIN 
               t_bse_patientcard e ON b.patientid_chr = e.patientid_chr 
WHERE 1=1 AND a.pstatus_int [type] ";
            }
            /* <<======================================= */
            if (type == 1)
            {
                strSQL = strSQL.Replace("[type]", "<> 3");
            }
            if (type == 0)
            {
                strSQL = strSQL.Replace("[type]", "= 3");
            }
            if (AreaID != "")
                strSQL += " AND a.AREAID_CHR = '" + AreaID + "'";
            if (RegisterId != "")
            {
                strSQL += " AND A.registerid_chr = '" + RegisterId + "'";
            }
            if (InpatientId != "")
                strSQL += " AND a.inpatientid_chr = '" + InpatientId + "'";
            if (PatientCardId != "")
                strSQL += " AND e.patientcardid_chr = '" + PatientCardId + "'";
            strSQL += " )";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        [AutoComplete]
        public long m_lngGetPatientDebt(string AreaID, string RegisterId, System.DateTime StatDate, string InpatientId, string PatientCardId, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT bedno, inpatientid_chr, lastname_vchr, paytype, sex_chr, birth_dat,registerid_chr,
       patientcardid_chr, inpatient_dat,
       DECODE (notclear, NULL, 0, notclear) AS notclear, money_dec,
       charge_dec, areaname,
       DECODE ((money_dec - decode(sign(notclear),null,0,notclear)),
               NULL, 0,
               (money_dec - decode(sign(notclear),null,0,notclear))
              ) AS balance,
       round(DECODE (SIGN (charge_dec),
               1, (chgofmepay_dec / charge_dec) * 100
              ),2) AS selfpaypercent
  FROM (SELECT (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = a.bedid_chr) bedno, a.inpatientid_chr,
               (SELECT deptname_vchr
                  FROM t_bse_deptdesc
                 WHERE deptid_chr = a.areaid_chr) AS areaname,
               a.inpatient_dat, a.registerid_chr, b.lastname_vchr, b.sex_chr,
               birth_dat, e.patientcardid_chr,
               (SELECT paytypename_vchr
                  FROM t_bse_patientpaytype
                 WHERE paytypeid_chr = b.paytypeid_chr) AS paytype,
               (c.charge_dec - c.clearchg_dec) AS notclear,
               DECODE (c.chgofmepay_dec,
                       NULL, 0,
                       c.chgofmepay_dec
                      ) AS chgofmepay_dec,
               DECODE (c.charge_dec, NULL, 0, c.charge_dec) AS charge_dec,
               DECODE (d.money_dec, NULL, 0, d.money_dec) money_dec
          FROM t_opr_bih_register a,
               t_bse_patient b,
               (SELECT   SUM (charge_dec) AS charge_dec,
                         SUM (chgofmepay_dec) AS chgofmepay_dec,
                         SUM (clearchg_dec) AS clearchg_dec, registerid_chr
                    FROM t_opr_bih_dayaccount
                GROUP BY registerid_chr) c,
               (SELECT a.registerid_chr, SUM (a.money_dec) AS money_dec
  FROM t_opr_bih_prepay a
 WHERE a.status_int = 1 AND ISCLEAR_INT=0
 group by a.registerid_chr) d,
               t_bse_patientcard e
         WHERE a.inpatientid_chr = b.inpatientid_chr
           AND a.registerid_chr = c.registerid_chr(+)
           AND a.registerid_chr = d.registerid_chr(+)
           AND b.patientid_chr = e.patientid_chr(+)";

            /* @update by wjqin (05-11-29)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"(SELECT 
      (SELECT code_chr
                  FROM t_bse_bed
                  WHERE bedid_chr = a.bedid_chr) bedno, 
       a.inpatientid_chr,
       
   b.lastname_vchr,
       (SELECT paytypename_vchr
                  FROM t_bse_patientpaytype
                 WHERE paytypeid_chr = b.paytypeid_chr) AS paytype,
 b.sex_chr,
     birth_dat,
      
 a.registerid_chr,
      
e.patientcardid_chr,
        a.inpatient_dat,
     
        (CASE  (c.charge_dec - c.clearchg_dec) WHEN  NULL THEN  0 ELSE  (c.charge_dec - c.clearchg_dec) END) AS notclear, 
         (CASE d.money_dec WHEN  NULL THEN  0 ELSE d.money_dec END) money_dec,
      (CASE c.charge_dec  WHEN  NULL THEN 0 ELSE c.charge_dec END) AS charge_dec,
        (SELECT deptname_vchr
                   FROM t_bse_deptdesc
                   WHERE deptid_chr = a.areaid_chr) AS areaname,
       
        (CASE ((CASE d.money_dec WHEN  NULL THEN  0 ELSE d.money_dec END) - (CASE sign( (c.charge_dec - c.clearchg_dec)) WHEN null THEN 0 ELSE  (c.charge_dec - c.clearchg_dec) END)) WHEN
               NULL THEN  0
               ELSE ((CASE d.money_dec WHEN  NULL THEN  0 ELSE d.money_dec END) - (CASE sign( (c.charge_dec - c.clearchg_dec)) WHEN null THEN 0 ELSE  (c.charge_dec - c.clearchg_dec) END))
              END) AS balance,
       round((CASE SIGN ((CASE c.charge_dec  WHEN  NULL THEN 0 ELSE c.charge_dec END)) WHEN 
               1 THEN ( ( CASE c.chgofmepay_dec WHEN
                       NULL THEN  0 ELSE
                       c.chgofmepay_dec END
                      ) / (CASE c.charge_dec  WHEN  NULL THEN 0 ELSE c.charge_dec END)) * 100
              END ),2) AS selfpaypercent
           
          FROM t_opr_bih_register a
               FULL JOIN  t_bse_patient b ON  a.inpatientid_chr = b.inpatientid_chr
               LEFT JOIN 
               (SELECT   SUM (charge_dec) AS charge_dec,
                         SUM (chgofmepay_dec) AS chgofmepay_dec,
                         SUM (clearchg_dec) AS clearchg_dec, registerid_chr
                 FROM t_opr_bih_dayaccount
                 GROUP BY registerid_chr) c ON a.registerid_chr = c.registerid_chr
               LEFT JOIN 
               (SELECT a.registerid_chr, SUM (a.money_dec) AS money_dec
                 FROM t_opr_bih_prepay a
                 WHERE a.status_int = 1 AND ISCLEAR_INT=0
                 group by a.registerid_chr) d ON a.registerid_chr = d.registerid_chr
                LEFT JOIN 
                t_bse_patientcard e ON b.patientid_chr = e.patientid_chr
                 
where 1=1 ";
            }
            /* <<======================================= */
            //			if(type==1)
            //			{
            //				strSQL = strSQL.Replace("[type]","<> 3");
            //			}
            //			if(type==0)
            //			{
            //				strSQL = strSQL.Replace("[type]","= 3");
            //			}
            if (AreaID != "")
                strSQL += " AND a.AREAID_CHR = '" + AreaID + "'";
            if (RegisterId != "")
            {
                strSQL += " AND A.registerid_chr = '" + RegisterId + "'";
            }
            if (InpatientId != "")
                strSQL += " AND a.inpatientid_chr = '" + InpatientId + "'";
            if (PatientCardId != "")
                strSQL += " AND e.patientcardid_chr = '" + PatientCardId + "'";
            strSQL += " )";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region 更新病室日志统计表
        [AutoComplete]
        public long m_lngUpdateSickRoomLOGSTAT(com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            string strQuery = "select * from T_BAL_BIH_LOGSTAT where AREAID_CHR = '" + p_objRecord.m_strTARGETAREAID_CHR + "'";
            DataTable dtbResult = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strQuery, ref dtbResult);
                string SQLUpdate = "";
                string SQLupdate1 = "";
                if (dtbResult.Rows.Count > 0)
                {
                    if (p_objRecord.m_strTARGETBEDID_CHR != null && p_objRecord.m_strSOURCEAREAID_CHR != null)
                    {
                        SQLUpdate = "update T_BAL_BIH_LOGSTAT set TODAYCOUNT = TODAYCOUNT+1 where AREAID_CHR = '" + p_objRecord.m_strTARGETAREAID_CHR + "'";
                        SQLupdate1 = "update T_BAL_BIH_LOGSTAT set TODAYCOUNT = TODAYCOUNT-1 where AREAID_CHR = '" + p_objRecord.m_strSOURCEAREAID_CHR + "'";

                    }
                    else if (p_objRecord.m_strTARGETBEDID_CHR != null && p_objRecord.m_strSOURCEAREAID_CHR == null)
                    {
                        SQLUpdate = "update T_BAL_BIH_LOGSTAT set TODAYCOUNT = TODAYCOUNT+1 where AREAID_CHR = '" + p_objRecord.m_strTARGETAREAID_CHR + "'";
                    }
                }
                else
                {
                    if (p_objRecord.m_strSOURCEAREAID_CHR != null)
                    {
                        SQLUpdate = "insert into T_BAL_BIH_LOGSTAT (AREAID_CHR,YESTERDAYCOUNT,TODAYCOUNT) values ('" + p_objRecord.m_strTARGETAREAID_CHR + "',0,1)";
                        SQLupdate1 = "update T_BAL_BIH_LOGSTAT set TODAYCOUNT = TODAYCOUNT-1 where AREAID_CHR = '" + p_objRecord.m_strSOURCEAREAID_CHR + "'";
                    }
                }
                lngRes = 0;
                lngRes = objService.DoExcute(SQLUpdate);
                objService.Dispose();
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
        #endregion

        #region 病人入院单统计表  liuyingrui 2006.05.08
        /// <summary>
        /// 病人入院单统计表  liuyingrui 2006.05.08
        /// </summary>
        /// <param name="dtStartTime">统计起始时间</param>
        /// <param name="dtEndTime">统计终止时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientBihStatistics(System.Security.Principal.IPrincipal p_objPrincipal, DateTime dtStartime, DateTime dtEndTime, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strStartTime = dtStartime.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndTime = dtEndTime.ToString("yyyy-MM-dd HH:mm:ss");

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "GetPatientBihStatistics");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   max(b.empno_chr) AS 医生工号, max (b.lastname_vchr)as 医生姓名,max(c.deptname_vchr) as 科室 , 
                            COUNT (*) AS  人次 
                            FROM t_opr_bih_register a, t_bse_employee b,t_bse_deptdesc c
                            WHERE a.MZDOCTOR_CHR = b.empid_chr(+) and a.casedoctordept_chr=c.deptid_chr(+)
                             and a.status_int=1
                             AND a.inpatient_dat BETWEEN TO_DATE ('" + strStartTime + @"',
                                          'YYYY-MM-DD HH24:MI:SS'
                                         )
                             AND TO_DATE ('" + strEndTime + @"',
                                          'YYYY-MM-DD HH24:MI:SS'
                                         )
                             GROUP BY a.MZDOCTOR_CHR,a.casedoctordept_chr";
            if (strSQL != "")
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                    lngRes = 0;
                    lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                    objService.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                return lngRes;

            }
            return 0;
        }
        #endregion

        #region 病人出院单统计表 2006.11.18
        /// <summary>
        /// 病人出院单统计表  2006.11.18
        /// </summary>
        /// <param name="dtStartTime">统计起始时间</param>
        /// <param name="dtEndTime">统计终止时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientLeftStatistics(System.Security.Principal.IPrincipal p_objPrincipal, DateTime dtStartime, DateTime dtEndTime, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strStartTime = dtStartime.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndTime = dtEndTime.ToString("yyyy-MM-dd HH:mm:ss");

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "GetPatientLeftStatistics");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   max(b.empno_chr) AS 医生工号, max (b.lastname_vchr)as 医生姓名,max(c.deptname_vchr) as 科室 , 
                            COUNT (*) AS  人次 
                            FROM t_opr_bih_register a, 
                                t_bse_employee b,
                                t_bse_deptdesc c,
                                t_opr_bih_transfer d
                            WHERE a.CASEDOCTOR_CHR = b.empid_chr(+) and 
                                  a.AREAID_CHR = c.deptid_chr  and
                                  a.REGISTERID_CHR = d.REGISTERID_CHR and
                                  a.status_int=1 and
                                  a.PSTATUS_INT = 3 and
                                  d.TYPE_INT = 6 
                             AND d.MODIFY_DAT BETWEEN TO_DATE ('" + strStartTime + @"',
                                          'YYYY-MM-DD HH24:MI:SS'
                                         )
                             AND TO_DATE ('" + strEndTime + @"',
                                          'YYYY-MM-DD HH24:MI:SS'
                                         )
                             GROUP BY a.casedoctor_chr,a.deptid_chr";
            if (strSQL != "")
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                    lngRes = 0;
                    lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                    objService.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                return lngRes;

            }
            return 0;
        }
        #endregion


        //add 2007-4-17
        #region 病人入院单统计表按收费类别查询  zhu 2007.4.17
        /// <summary>
        /// 病人入院单统计表按收费类别查询  zhu 2007.4.17
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtStartime">统计起始时间</param>
        /// <param name="dtEndTime"></param>
        /// <param name="strPaytypeId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientBihStatistics(System.Security.Principal.IPrincipal p_objPrincipal, DateTime dtStartime, DateTime dtEndTime, string strPaytypeId, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strStarTime = dtStartime.ToShortDateString();
            string strEndTime = dtEndTime.ToShortDateString();
            DateTime dtStart = Convert.ToDateTime(strStarTime + " 00:00:00");
            DateTime dtEnd = Convert.ToDateTime(strEndTime + " 23:59:59");

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "GetPatientBihStatistics");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"
                        select max(b.empno_chr) as 医生工号, max(b.lastname_vchr) as 医生姓名,
                                max(c.deptname_vchr) as 科室,count(*) as 人次 
                            from t_opr_bih_register a, t_bse_employee b, t_bse_deptdesc c
                           where a.mzdoctor_chr = b.empid_chr(+)
                             and a.casedoctordept_chr = c.deptid_chr(+)
                             and a.status_int = 1
                             and a.paytypeid_chr = ?
                             and a.inpatient_dat between ? and ? 
                         group by a.mzdoctor_chr,  a.casedoctordept_chr
                           order by 医生工号
                    ";
            if (strSQL != "")
            {
                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr;
                    objService.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = strPaytypeId;
                    objLisAddItemRefArr[1].Value = dtStart;
                    objLisAddItemRefArr[2].Value = dtEnd;

                    lngRes = objService.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);

                    objService.Dispose();

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                return lngRes;

            }
            return 0;
        }
        #endregion


        //add 2007-4-17
        #region 病人出院单统计表按收费类别查询  zhu 2007.4.17
        /// <summary>
        /// 病人出院单统计表按收费类别查询  zhu 2007.4.17
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtStartime">统计起始时间</param>
        /// <param name="dtEndTime"></param>
        /// <param name="strPaytypeId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientLeftStatistics(System.Security.Principal.IPrincipal p_objPrincipal, DateTime dtStartime, DateTime dtEndTime, string strPaytypeId, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strStarTime = dtStartime.ToShortDateString();
            string strEndTime = dtEndTime.ToShortDateString();
            DateTime dtStart = Convert.ToDateTime(strStarTime + " 00:00:00");
            DateTime dtEnd = Convert.ToDateTime(strEndTime + " 23:59:59");

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "GetPatientLeftStatistics");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"
                        select   max (b.empno_chr) as 医生工号, max (b.lastname_vchr) as 医生姓名,
                                 max (c.deptname_vchr) as 科室, count (*) as 人次
                            from t_opr_bih_register a,
                                 t_bse_employee b,
                                 t_bse_deptdesc c,
                                 t_opr_bih_transfer d
                           where a.casedoctor_chr = b.empid_chr(+)
                             and a.areaid_chr = c.deptid_chr
                             and a.registerid_chr = d.registerid_chr
                             and a.status_int = 1
                             and a.pstatus_int = 3
                             and a.paytypeid_chr = ?
                             and d.type_int = 6
                             and d.modify_dat between ? and ?
                        group by a.casedoctor_chr, a.deptid_chr
                    ";

            if (strSQL != "")
            {
                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr;
                    objService.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = strPaytypeId;
                    objLisAddItemRefArr[1].Value = dtStart;
                    objLisAddItemRefArr[2].Value = dtEnd;

                    lngRes = objService.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);

                    objService.Dispose();

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                return lngRes;

            }
            return 0;
        }
        #endregion


        #region 全院病室统计详细信息
        /// <summary>
        /// 全院病室统计详细信息
        /// </summary>
        /// <param name="AreaID">病区ID</param>
        /// <param name="p_dtStatTime">统计开始时间</param>
        /// <param name="p_dtToTime">统计结束时间</param>
        /// <param name="Type_int">0:入院,1：转入2:转出3：出院</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllSickRoomLogDetail(string AreaID, System.DateTime p_dtStatTime, DateTime p_dtToTime, int Type_int, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strStatDate = p_dtStatTime.ToShortDateString() + " 00:00:00";
            string strEndDate = p_dtToTime.ToShortDateString() + " 23:59:59";
            string strSQL = @"select b.inpatientid_chr, c.name_vchr, c.sex_chr,
                                       t_bed.code_chr as code_chr, t_area.deptname_vchr as deptname_vchr,
                                       s_bed.code_chr as s_code_chr, s_area.deptname_vchr as s_areaname_vchr
                                  from t_opr_bih_transfer a,
                                       t_opr_bih_register b,
                                       t_opr_bih_registerdetail c,
                                       t_bse_deptdesc s_area,
                                       t_bse_deptdesc t_area,
                                       t_bse_bed s_bed,
                                       t_bse_bed t_bed
                                 where a.registerid_chr = b.registerid_chr(+)
                                   and b.registerid_chr = c.registerid_chr(+)
                                   and a.sourceareaid_chr = s_area.deptid_chr(+)
                                   and a.sourcebedid_chr = s_bed.bedid_chr(+)
                                   and a.targetareaid_chr = t_area.deptid_chr(+)
                                   and a.targetbedid_chr = t_bed.bedid_chr(+)";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"select b.inpatientid_chr, c.lastname_vchr, c.sex_chr,
       t_bed.code_chr as code_chr, t_area.deptname_vchr as deptname_vchr,
       s_bed.code_chr as s_code_chr, s_area.deptname_vchr as s_areaname_vchr
  from t_opr_bih_transfer a left join   t_opr_bih_register b on a.registerid_chr = b.registerid_chr
       left join  t_bse_patient c on b.patientid_chr = c.patientid_chr
       left join  t_bse_deptdesc s_area on a.sourceareaid_chr = s_area.deptid_chr
       left join  t_bse_bed s_bed on a.sourcebedid_chr = s_bed.bedid_chr
       left join  t_bse_deptdesc t_area on a.targetareaid_chr = t_area.deptid_chr
       left join  t_bse_bed t_bed on a.targetbedid_chr = t_bed.bedid_chr
 
where 

   a.modify_dat 
   between convert (datetime,'" + strStatDate + @"')
                        and convert (datetime,'" + strEndDate + @"')";
            }
            /* <<======================================= */
            switch (Type_int)
            {
                case 0: //入院
                    strSQL = @"select b.inpatientid_chr,
                                       c.name_vchr,
                                       c.sex_chr,
                                       t_bed.code_chr as code_chr,
                                       t_area.deptname_vchr as deptname_vchr,
                                       b.mzdiagnose_vchr
                                  from t_opr_bih_transfer       a,
                                       t_opr_bih_register       b,
                                       t_opr_bih_registerdetail c,
                                       t_bse_deptdesc           s_area,
                                       t_bse_deptdesc           t_area,
                                       t_bse_bed                s_bed,
                                       t_bse_bed                t_bed
                                 where a.sourceareaid_chr = s_area.deptid_chr(+)
                                   and a.sourcebedid_chr = s_bed.bedid_chr(+)
                                   and a.targetareaid_chr = t_area.deptid_chr(+)
                                   and a.targetbedid_chr = t_bed.bedid_chr(+)
                                   and b.status_int = 1";
                    if (AreaID != "0" && AreaID != null)
                    {
                        strSQL += " and a.targetareaid_chr ='" + AreaID + "'";
                    }
                    strSQL += @"   and b.registerid_chr = c.registerid_chr(+)
                                   and a.registerid_chr = b.registerid_chr(+)
                                   and a.type_int = 5  
                                   and b.inpatient_dat between 
                                       to_date ('" + strStatDate + @"','yyyy-mm-dd hh24:mi:ss')and 
                                       to_date ('" + strEndDate + @"','yyyy-mm-dd hh24:mi:ss')
                                   order by a.targetareaid_chr, code_chr";
                    break;
                case 1: //转入
                    if (AreaID != "0" && AreaID != null)
                    {
                        strSQL += " and a.targetareaid_chr ='" + AreaID + "' ";
                    }
                    strSQL += @" and a.modify_dat between to_date ('" + strStatDate + @"',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                                        and to_date ('" + strEndDate + @"',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    ) and a.targetbedid_chr is not null 
								 and a.type_int = 3 
								order by a.targetareaid_chr";
                    break;
                case 2: //转出
                    if (AreaID != "0" && AreaID != null)
                    {
                        strSQL += " and a.sourceareaid_chr ='" + AreaID + "' ";
                    }
                    strSQL += " and a.modify_dat between to_date ('" + strStatDate + @"',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                                        and to_date ('" + strEndDate + @"',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )and 
                               a.type_int = 3 
                               order by a.sourceareaid_chr";
                    break;
                case 3: //出院
                    strSQL = @"select decode(a.pstatus_int,0, b.inpatientid_chr || '(预)',b.inpatientid_chr) as inpatientid_chr,
                                      c.name_vchr, c.sex_chr,
                                      decode(a.type_int, 1, '治愈出院', 2, '转院', 3, '其他', 4, '死亡','') out_type,
                                      s_bed.code_chr as s_code_chr, s_area.deptname_vchr as s_areaname_vchr
                                  from t_opr_bih_leave a,
                                       t_opr_bih_register b,
                                       t_opr_bih_registerdetail c,
                                       t_bse_deptdesc s_area,
                                       t_bse_bed s_bed
                                 where a.registerid_chr = b.registerid_chr(+)
                                   and b.registerid_chr = c.registerid_chr(+)
                                   and a.outareaid_chr = s_area.deptid_chr(+)
                                   and a.outbedid_chr = s_bed.bedid_chr(+)";

                    if (AreaID != "0" && AreaID != null)
                    {
                        strSQL += " and a.outareaid_chr ='" + AreaID + "' ";
                    }
                    strSQL += " and a.outhospital_dat between to_date ('" + strStatDate + @"',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    )
                                                        and to_date ('" + strEndDate + @"',
                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                    ) and 
                                    a.status_int = 1 
                                   order by s_area.code_vchr,code_chr";
                    break;
                default:
                    break;
            }
            if (strSQL != "")
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                    lngRes = 0;
                    lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                    objService.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                return lngRes;
            }
            return 0;
        }
        #endregion

        #region 统计全院病人流动报表
        /// <summary>
        /// 科室、病区统计报表 （科室ID、科室名称、病区名称、昨日人数、今日入院人数、今日转入人数、今日转出人数、今日出院人数、今日死亡人数、今日在院人数、今日开放床位数、统计时间）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="strDateTime">统计时间</param>
        /// <param name="p_dtbResult">out 参数，返回的表（）</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRepAllDeptByDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, string strDateTime, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc", "m_lngRepAllDeptByDate");
            string strEndDate = "1900-1-1 00:00:00";
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                strDateTime = (Convert.ToDateTime(strDateTime)).ToShortDateString() + " 00:00:00";
                strEndDate = (Convert.ToDateTime(strDateTime)).ToShortDateString() + " 23:59:59";
            }
            catch
            {
                return -1;
            }

            string strSQL = @"SELECT (totalnum - inhospitalnum + outhospitalnum
       ) AS yesterdaycount,
        inhospitalnum AS inhospitalcount,
       innum AS incount, outnum AS outcount,
       outhospitalnum AS outhospitalcount, deadoutnum AS deadcount,
       deadin24 AS deadcountin24,totalnum AS todaycount
  FROM (SELECT                                                  --今日在院人数
               (SELECT count(t1.registerid_chr)
                  FROM t_opr_bih_register t1, t_bse_patient bs
                 WHERE t1.patientid_chr = bs.patientid_chr
                 and not exists --不算转出、出院的病人
                 (select t2.registerid_chr, t2.type_int
                          from t_opr_bih_transfer t2
                         where t2.registerid_chr = t1.registerid_chr
                           and t2.type_int in (3, 6, 7)
                           and t2.modify_dat <
                               TO_DATE('[Enddate]', 'YYYY-MM-DD HH24:MI:SS'))
                   and t1.status_int = 1
                   and t1.inpatient_dat <=
                       TO_DATE('[Enddate]', 'YYYY-MM-DD HH24:MI:SS')
                   and t1.inpatient_dat >=
                         TO_DATE('2007-1-1 00:00:00', 'YYYY-MM-DD HH24:MI:SS')) AS totalnum,
               
               --今日入院人数
               (SELECT COUNT (DISTINCT tr.registerid_chr)
                  FROM t_opr_bih_transfer tr, t_opr_bih_register reg, t_bse_patient bas
                 WHERE tr.registerid_chr = reg.registerid_chr
                   AND reg.patientid_chr = bas.patientid_chr
                   AND tr.type_int = 5
                   AND reg.status_int = 1 
                   AND reg.INPATIENT_DAT >=
                          TO_DATE ('[statdate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )
                   AND reg.INPATIENT_DAT <=
                          TO_DATE ('[Enddate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )) AS inhospitalnum,
               
               --转入人数
               (SELECT COUNT (registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 3
				   AND targetbedid_chr IS NOT NULL	
                   AND modify_dat >=
                          TO_DATE ('[statdate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )
                   AND modify_dat <=
                          TO_DATE ('[Enddate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )) AS innum,
               
               -- 转出人数
               (SELECT COUNT (registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 3
                   AND modify_dat >=
                          TO_DATE ('[statdate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )
                   AND modify_dat <=
                          TO_DATE ('[Enddate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )) AS outnum,
               
               --出院
               (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_leave
                 WHERE status_int = 1
                   AND outhospital_dat >=
                          TO_DATE ('[statdate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )
                   AND outhospital_dat <=
                          TO_DATE ('[Enddate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )) AS outhospitalnum,
               
               --出院死亡
               (SELECT COUNT (DISTINCT a.registerid_chr)
                  FROM t_opr_bih_transfer a, t_opr_bih_leave b
                 WHERE a.registerid_chr = b.registerid_chr
                   AND a.modify_dat = b.modify_dat
                   AND a.type_int = 6
                   AND b.type_int = 4
                   AND a.modify_dat >=
                          TO_DATE ('[statdate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )
                   AND a.modify_dat <=
                          TO_DATE ('[Enddate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )) AS deadoutnum,
               
               --24小时死亡
               (SELECT COUNT (DISTINCT a.registerid_chr)
                  FROM t_opr_bih_transfer a,
                       t_opr_bih_leave b,
                       (SELECT   MAX (modify_dat) AS modify_dat,
                                 registerid_chr
                            FROM t_opr_bih_transfer
                           WHERE (type_int = 3 OR type_int = 5)
                             AND targetareaid_chr = ''
                        GROUP BY registerid_chr) c
                 WHERE a.registerid_chr = b.registerid_chr
                   AND a.modify_dat = b.modify_dat
                   AND a.registerid_chr = c.registerid_chr
                   AND a.type_int = 6
                   AND b.type_int = 4
                   AND (a.modify_dat - c.modify_dat) < 1
                   AND a.modify_dat >=
                          TO_DATE ('[statdate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )
                   AND a.modify_dat <=
                          TO_DATE ('[Enddate]',
                                   'YYYY-MM-DD HH24:MI:SS'
                                  )) AS deadin24
          FROM t_opr_bih_transfer
         WHERE ROWNUM = 1)";


            /* @update by wjqin (05-11-28)
                                     * 添加SQL SERVER的strSQl版本语名
                                     */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT TOP 1 ((SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_register
                 WHERE pstatus_int <> 3
                   AND status_int = 1)
         - (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 5
               
                   AND modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                 
                                  )
         + (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 6
             AND modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  ) 
       ) AS yesterdaycount,
        (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_register
                 WHERE pstatus_int <> 3
                   AND status_int = 1) AS totalnum,
               
               --今日入院人数
               (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 5
            AND modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  ) AS inhospitalcount,
            (SELECT COUNT (registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 3
				   AND targetbedid_chr IS NOT NULL	
         AND modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  
                                  )  AS incount, 
            (SELECT COUNT (registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 3
               AND modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  ) AS outcount,
        (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_transfer
                 WHERE type_int = 6
               AND modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  )  AS outhospitalcount, 
          (SELECT COUNT (DISTINCT a.registerid_chr)
                  FROM t_opr_bih_transfer a, t_opr_bih_leave b
                 WHERE a.registerid_chr = b.registerid_chr
                   AND a.modify_dat = b.modify_dat
                   AND a.type_int = 6
                   AND b.type_int = 4
               AND a.modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND a.modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  )  AS deadcount,
       (SELECT COUNT (DISTINCT a.registerid_chr)
                  FROM t_opr_bih_transfer a,
                       t_opr_bih_leave b,
                       (SELECT   MAX (modify_dat) AS modify_dat,
                                 registerid_chr
                            FROM t_opr_bih_transfer
                           WHERE (type_int = 3 OR type_int = 5)
                             AND targetareaid_chr = ''
                        GROUP BY registerid_chr) c
                 WHERE a.registerid_chr = b.registerid_chr
                   AND a.modify_dat = b.modify_dat
                   AND a.registerid_chr = c.registerid_chr
                   AND a.type_int = 6
                   AND b.type_int = 4
                   AND (a.modify_dat - c.modify_dat) < 1
             AND a.modify_dat >
                          CONVERT (DATETIME,'[statdate]')
                   AND a.modify_dat <
                          CONVERT (DATETIME,'[Enddate]')
                                  ) AS deadcountin24,
 (SELECT COUNT (DISTINCT registerid_chr)
                  FROM t_opr_bih_register
                 WHERE pstatus_int <> 3
                   AND status_int = 1) AS todaycount
  
          FROM t_opr_bih_transfer
        ";
            }
            /* <<======================================= */

            strSQL = strSQL.Replace("[statdate]", strDateTime);
            strSQL = strSQL.Replace("[Enddate]", strEndDate);
            lngRes = 0;
            lngRes = lngSelectSQL(strSQL, out p_dtbResult);
            return lngRes;
        }
        #endregion

        #region 一日清单配置表
        [AutoComplete]
        public long m_lngAddOneItem(string ItemID)
        {
            long lngRes = 0;
            string strSQL = @"insert into t_bal_config (ITEMIPINVTYPE_CHR) values ('" + ItemID + "')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoExcute(strSQL);
                objService.Dispose();
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
        #region 一日清单配置表
        [AutoComplete]
        public long m_lngDeleteOneItem(string ItemID)
        {
            long lngRes = 0;
            string strSQL = @"delete from t_bal_config where ITEMIPINVTYPE_CHR = '" + ItemID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoExcute(strSQL);
                objService.Dispose();
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
        #region 查询一日清单配置表
        [AutoComplete]
        public long m_lngGetbalConfig(out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"select * from t_bal_config";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region 住院费用一日清单病人信息
        [AutoComplete]
        public long m_lngGetPatientInfoForDailyCharge(System.DateTime p_dtStatTime, string p_strAreaID, out DataTable dtbResult)
        {
            string StatTime = p_dtStatTime.ToString();
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"select a.* ,decode(b.money,null,0,b.money) as money from (
SELECT a.*, round(DECODE (b.totalcharge, NULL, 0, b.totalcharge),2) AS totalcharge
  FROM (SELECT a.registerid_chr, a.patientid_chr, a.inpatientid_chr,
               (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = e.targetbedid_chr) AS bedno,
               c.lastname_vchr
          FROM (SELECT a.*
                  FROM t_opr_bih_transfer a,
                       (SELECT   MAX (modify_dat) AS modify_dat,
                                 registerid_chr
                            FROM t_opr_bih_transfer
                           WHERE modify_dat <
                                    TO_DATE ('" + StatTime + @"',
                                             'YYYY-MM-DD HH24:MI:SS'
                                            )
                        GROUP BY registerid_chr) b
                 WHERE a.modify_dat = b.modify_dat
                   AND a.registerid_chr = b.registerid_chr
                   ) e,
               t_opr_bih_register a,
               t_bse_patient c
         WHERE e.registerid_chr = a.registerid_chr
           AND a.patientid_chr = c.patientid_chr
           and e.TARGETAREAID_CHR = '" + p_strAreaID + @"'
           and a.PSTATUS_INT = 1) a,
       (SELECT   SUM (a.charge_dec) AS totalcharge, a.registerid_chr
            FROM t_opr_bih_dayaccount a
        where a.SQUARE_DAT < TO_DATE ('" + StatTime + @"',
                                             'YYYY-MM-DD HH24:MI:SS'
                                            ) 
        GROUP BY a.registerid_chr) b
 WHERE a.registerid_chr = b.registerid_chr(+)
 ) a, (SELECT   SUM (a.money_dec) AS money, a.registerid_chr
            FROM t_opr_bih_prepay a
        GROUP BY a.registerid_chr) b where a.registerid_chr = b.registerid_chr(+)";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"select a.* ,
       
       (CASE b.money WHEN null THEN 0 ELSE b.money END) as money 
       from (
             SELECT a.*, round((CASE b.totalcharge WHEN NULL THEN 0 ELSE b.totalcharge END),2) AS totalcharge
                 FROM (SELECT a.registerid_chr, a.patientid_chr, a.inpatientid_chr,
                       (SELECT code_chr
                         FROM t_bse_bed
                          WHERE bedid_chr = e.targetbedid_chr) AS bedno,
                                c.lastname_vchr
                  FROM (SELECT a.*
                  FROM t_opr_bih_transfer a,
                       (SELECT   MAX (modify_dat) AS modify_dat,
                                 registerid_chr
                            FROM t_opr_bih_transfer
                       
                            WHERE modify_dat <
                                    CONVERT (DATETIME,'" + StatTime + @"')
                                           
                        GROUP BY registerid_chr) b
                 WHERE a.modify_dat = b.modify_dat
                   AND a.registerid_chr = b.registerid_chr
                   ) e,
               t_opr_bih_register a,
               t_bse_patient c
         WHERE e.registerid_chr = a.registerid_chr
           AND a.patientid_chr = c.patientid_chr
           and e.TARGETAREAID_CHR = '" + p_strAreaID + @"'
           and a.PSTATUS_INT = 1) a LEFT JOIN
       (SELECT   SUM (a.charge_dec) AS totalcharge, a.registerid_chr
            FROM t_opr_bih_dayaccount a
       
where a.SQUARE_DAT < CONVERT (DATETIME,'" + StatTime + @"')
        GROUP BY a.registerid_chr) b ON a.registerid_chr = b.registerid_chr

 ) a LEFT JOIN 
 (SELECT   SUM (a.money_dec) AS money, a.registerid_chr
            FROM t_opr_bih_prepay a
        GROUP BY a.registerid_chr) b ON a.registerid_chr = b.registerid_chr      ";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region 住院费用一日清单病人信息
        [AutoComplete]
        public long m_lngGetPatientInfoForDailyCharge(System.DateTime p_dtStatTime, out DataTable dtbResult)
        {
            string StatTime = p_dtStatTime.ToString();
            dtbResult = new DataTable();
            long lngRes = 0;
            /* @update by wjqin (05-11-28)
             * 原sql语名存在语法错误
                         */
            /*@remark--------------------------------------
string strSQL =@"select a.* ,decode(b.money,null,0,b.money) as money from (
SELECT a.*, round(DECODE (b.totalcharge, NULL, 0, b.totalcharge),2)) AS totalcharge
FROM (SELECT a.registerid_chr, a.patientid_chr, a.inpatientid_chr,
  (SELECT code_chr
     FROM t_bse_bed
    WHERE bedid_chr = e.targetbedid_chr) AS bedno,
  c.lastname_vchr
FROM (SELECT a.*
     FROM t_opr_bih_transfer a,
          (SELECT   MAX (modify_dat) AS modify_dat,
                    registerid_chr
               FROM t_opr_bih_transfer
              WHERE modify_dat <
                       TO_DATE ('"+StatTime+@"',
                                'YYYY-MM-DD HH24:MI:SS'
                               )
           GROUP BY registerid_chr) b
    WHERE a.modify_dat = b.modify_dat
      AND a.registerid_chr = b.registerid_chr
      ) e,
  t_opr_bih_register a,
  t_bse_patient c
WHERE e.registerid_chr = a.registerid_chr
AND a.patientid_chr = c.patientid_chr
and a.PSTATUS_INT = 1) a,
(SELECT   SUM (a.charge_dec) AS totalcharge, a.registerid_chr
FROM t_opr_bih_dayaccount a
where a.SQUARE_DAT < TO_DATE ('"+StatTime+@"',
                                'YYYY-MM-DD HH24:MI:SS'
                               ) 
GROUP BY a.registerid_chr) b
WHERE a.registerid_chr = b.registerid_chr(+)
) a, (SELECT   SUM (a.money_dec) AS money, a.registerid_chr
FROM t_opr_bih_prepay a
GROUP BY a.registerid_chr) b where a.registerid_chr = b.registerid_chr(+)";
---------------------------------------------- */
            string strSQL = @"select a.* ,decode(b.money,null,0,b.money) as money from (
SELECT a.*, round(DECODE (b.totalcharge, NULL, 0, b.totalcharge),2) AS totalcharge
  FROM (SELECT a.registerid_chr, a.patientid_chr, a.inpatientid_chr,
               (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = e.targetbedid_chr) AS bedno,
               c.lastname_vchr
          FROM (SELECT a.*
                  FROM t_opr_bih_transfer a,
                       (SELECT   MAX (modify_dat) AS modify_dat,
                                 registerid_chr
                            FROM t_opr_bih_transfer
                           WHERE modify_dat <
                                    TO_DATE ('" + StatTime + @"',
                                             'YYYY-MM-DD HH24:MI:SS'
                                            )
                        GROUP BY registerid_chr) b
                 WHERE a.modify_dat = b.modify_dat
                   AND a.registerid_chr = b.registerid_chr
                   ) e,
               t_opr_bih_register a,
               t_bse_patient c
         WHERE e.registerid_chr = a.registerid_chr
           AND a.patientid_chr = c.patientid_chr
           and a.PSTATUS_INT = 1) a,
       (SELECT   SUM (a.charge_dec) AS totalcharge, a.registerid_chr
            FROM t_opr_bih_dayaccount a
        where a.SQUARE_DAT < TO_DATE ('" + StatTime + @"',
                                             'YYYY-MM-DD HH24:MI:SS'
                                            ) 
        GROUP BY a.registerid_chr) b
 WHERE a.registerid_chr = b.registerid_chr(+)
 ) a, (SELECT   SUM (a.money_dec) AS money, a.registerid_chr
            FROM t_opr_bih_prepay a
        GROUP BY a.registerid_chr) b where a.registerid_chr = b.registerid_chr(+)";
            /* <<======================================= */
            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"select a.* ,(CASE b.money WHEN null THEN 0 ELSE b.money END) as money from (
SELECT a.*, round((CASE b.totalcharge WHEN  NULL THEN 0 ELSE b.totalcharge END),2) AS totalcharge
  FROM (SELECT a.registerid_chr, a.patientid_chr, a.inpatientid_chr,
               (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = e.targetbedid_chr) AS bedno,
               c.lastname_vchr
          FROM (SELECT a.*
                  FROM t_opr_bih_transfer a,
                       (SELECT   MAX (modify_dat) AS modify_dat,
                                 registerid_chr
                            FROM t_opr_bih_transfer
                            
                           WHERE modify_dat <
                                    CONVERT (DATETIME,'" + StatTime + @"')
                        GROUP BY registerid_chr) b
                 WHERE a.modify_dat = b.modify_dat
                   AND a.registerid_chr = b.registerid_chr
                   ) e,
               t_opr_bih_register a,
               t_bse_patient c
         WHERE e.registerid_chr = a.registerid_chr
           AND a.patientid_chr = c.patientid_chr
           and a.PSTATUS_INT = 1) a LEFT JOIN 
       (SELECT   SUM (a.charge_dec) AS totalcharge, a.registerid_chr
            FROM t_opr_bih_dayaccount a 
           
        where a.SQUARE_DAT < CONVERT (DATETIME,'" + StatTime + @"')
                                         
        GROUP BY a.registerid_chr) b ON a.registerid_chr = b.registerid_chr
 ) a LEFT JOIN (SELECT   SUM (a.money_dec) AS money, a.registerid_chr
            FROM t_opr_bih_prepay a
        GROUP BY a.registerid_chr) b ON a.registerid_chr = b.registerid_chr";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region 住院病人一日清单费用详细信息
        [AutoComplete]
        public long m_lngGetDailyChargeInfo(string reportid, string p_strRegisterID, System.DateTime p_dtStatTime, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string BeginDate = p_dtStatTime.ToShortDateString() + " 00:00:00";
            //			string EndDate = p_dtStatTime.AddDays(1).ToShortDateString()+" 00:00:00";
            string EndDate = p_dtStatTime.ToString();
            string strSQL = @"       select max(b.groupname_chr) as typename_vchr ,sum(a.money) as money,b.groupid_chr from(
SELECT a.money, b.typename_vchr,b.TYPEID_CHR
  FROM (SELECT   round(SUM (a.unitprice_dec * a.amount_dec),2) AS money,
                 b.ITEMIPCALCTYPE_CHR
            FROM (SELECT *
                    FROM t_opr_bih_patientcharge
                   WHERE create_dat >
                            TO_DATE ('" + BeginDate + @"',
                                     'YYYY-MM-DD HH24:MI:SS'
                                    )
                     AND create_dat <
                            TO_DATE ('" + EndDate + @"',
                                     'YYYY-MM-DD HH24:MI:SS')
					 AND DAYACCOUNTID_CHR  is not null
                     AND registerid_chr = '" + p_strRegisterID + @"') a,
                 t_bse_chargeitem b
           WHERE a.chargeitemid_chr(+) = b.itemid_chr
        GROUP BY b.ITEMIPCALCTYPE_CHR) a,
       t_bse_chargeitemextype b
 WHERE a.ITEMIPCALCTYPE_CHR(+) = b.typeid_chr
 ) a,(SELECT a.groupname_chr,b.*
  FROM t_aid_rpt_gop_def a, t_aid_rpt_gop_rla b
 WHERE a.groupid_chr = b.groupid_chr and a.rptid_chr = b.rptid_chr AND a.rptid_chr = '" + reportid + @"'                       
) b where a.typeid_chr = b.typeid_chr group by b.groupid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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

        #region 通过住院登记ID获取病人欠费用信息
        [AutoComplete]
        public long m_lngGetPatientDebtByRegisterID(string p_strRegisterid_chr, out string p_strDebt)
        {
            p_strDebt = "";
            long lngRes = 0;
            string strSQL = @"SELECT Count(*) as c,SUM (charge_dec - clearchg_dec) AS debt
  FROM t_opr_bih_dayaccount
 WHERE registerid_chr = '" + p_strRegisterid_chr + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                if (lngRes > 0 && int.Parse(dtbResult.Rows[0]["c"].ToString()) > 0)
                {
                    p_strDebt = dtbResult.Rows[0]["debt"].ToString();
                }
                objService.Dispose();
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
        #region 查询报表设置
        [AutoComplete]
        public long GetDailyDebtConfig(string ReportID, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT a.rptname_chr, b.*
  FROM t_aid_rpt_def a, t_aid_rpt_gop_def b
 WHERE a.rptid_chr = b.rptid_chr and a.rptid_chr = '" + ReportID + @"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region
        [AutoComplete]
        public long m_lngGetPatientDebtDetail(string[] types, System.DateTime StatDate, System.DateTime DateEnd, string Registerid, out DataTable dtbResult)
        {
            string BeginDate = StatDate.ToShortDateString() + " 00:00:00";
            string EndDate = DateEnd.AddDays(1).ToShortDateString() + " 00:00:00";
            dtbResult = new DataTable();
            long lngRes = 0;
            //取消自定义报表
            //			string strSQL = @"SELECT *
            //  FROM (SELECT to_char(c.createdate_dat,'YYYY-MM-DD HH24:MI:SS')AS createdate_dat, b.name_vchr, d.itemname_vchr,
            //               d.itemspec_vchr, d.itemipcalctype_chr, d.pdcarea_vchr,
            //               d.itemunit_chr, d.itemprice_mny, a.amount_dec, (SELECT lastname_vchr
            //                  FROM t_bse_employee
            //                 WHERE EMPID_CHR = a.activator_chr) AS activator_chr,
            //               a.amount_dec * d.itemprice_mny AS money,a.registerid_chr,a.active_dat
            //          FROM t_opr_bih_patientcharge a,
            //               t_opr_bih_order b,
            //               t_opr_bih_orderexecute c,
            //               t_bse_chargeitem d
            //         WHERE c.orderid_chr = b.orderid_chr
            //           AND a.orderexecid_chr = c.orderexecid_chr
            //           AND a.chargeitemid_chr = d.itemid_chr) a,
            //       (SELECT a.*, b.typeid_chr
            //          FROM (SELECT a.rptname_chr, a.rptid_chr, b.groupid_chr,
            //                       b.groupname_chr
            //                  FROM t_aid_rpt_def a, t_aid_rpt_gop_def b
            //                 WHERE a.rptid_chr = b.rptid_chr AND a.rptid_chr = '0003') a,
            //               t_aid_rpt_gop_rla b
            //         WHERE a.rptid_chr = b.rptid_chr AND a.groupid_chr = b.groupid_chr) b
            // WHERE a.itemipcalctype_chr = b.typeid_chr and a.registerid_chr = '"+Registerid+"' and a.active_dat > TO_DATE ('"+BeginDate+@"',
            //                                     'YYYY-MM-DD HH24:MI:SS') and a.active_dat <  TO_DATE ('"+EndDate+@"',
            //                                     'YYYY-MM-DD HH24:MI:SS') and b.groupid_chr = '"+groupid+@"'
            //";
            string strSQL = @"SELECT a.*, b.typename_vchr
  FROM (SELECT a.amount_dec || a.unit_vchr AS amount,
               a.amount_dec * a.unitprice_dec AS money, b.itemname_vchr,
               b.itemspec_vchr, b.itemcode_vchr, b.itemipcalctype_chr
          FROM (SELECT *
                  FROM t_opr_bih_patientcharge a
                 WHERE a.registerid_chr = '" + Registerid + @"'
                   AND a.create_dat > TO_DATE ('" + BeginDate + @"', 'YYYY-MM-DD HH24:MI:SS')
                   AND a.create_dat < TO_DATE ('" + EndDate + @"', 'YYYY-MM-DD HH24:MI:SS')) a,
               t_bse_chargeitem b
         WHERE a.chargeitemid_chr = b.itemid_chr) a,
       t_bse_chargeitemextype b
 WHERE a.itemipcalctype_chr = b.typeid_chr";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT a.*, b.typename_vchr
  FROM (SELECT a.amount_dec + a.unit_vchr AS amount,
               a.amount_dec * a.unitprice_dec AS money, b.itemname_vchr,
               b.itemspec_vchr, b.itemcode_vchr, b.itemipcalctype_chr
          FROM (SELECT *
                  FROM t_opr_bih_patientcharge a
                 WHERE a.registerid_chr = '" + Registerid + @"'
                   AND a.create_dat > CONVERT (DATETIME,'" + BeginDate + @"')
                   AND a.create_dat < CONVERT (DATETIME,'" + EndDate + @"')) a,
               t_bse_chargeitem b
         WHERE a.chargeitemid_chr = b.itemid_chr) a,
       t_bse_chargeitemextype b
 WHERE a.itemipcalctype_chr = b.typeid_chr";
            }
            /* <<======================================= */
            if (types.Length > 0)
            {
                string strType = " and (1=2 ";
                for (int i = 0; i < types.Length; i++)
                {
                    strType += " or b.typeid_chr = '" + types[i] + "'";
                }
                strType += ")";
                strSQL += strType;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region 根据收费报表设置字段获取收费项目类别字段
        public long m_lngGetChargeItemTypesByConfigGroupID(string p_reportid, string p_groupid, out string[] types)
        {
            types = new string[0];
            long lngRes = 0;
            string strSQLCount = @"SELECT count(*) as c
  FROM t_aid_rpt_gop_rla a
 WHERE a.rptid_chr = '" + p_reportid + "' AND a.groupid_chr = '" + p_groupid + "'";
            string strSQL = @"SELECT *
  FROM t_aid_rpt_gop_rla a
 WHERE a.rptid_chr = '" + p_reportid + "' AND a.groupid_chr = '" + p_groupid + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQLCount, ref dtbResult);
                if (lngRes > 0)
                {
                    if (int.Parse(dtbResult.Rows[0]["c"].ToString()) == 0)
                        return -1;
                    else
                    {
                        dtbResult = new DataTable();
                        lngRes = 0;
                        lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                        if (lngRes > 0)
                        {
                            types = new string[dtbResult.Rows.Count];
                            for (int i = 0; i < dtbResult.Rows.Count; i++)
                            {
                                types[i] = dtbResult.Rows[i]["typeid_chr"].ToString();
                            }
                        }
                    }
                }
                objService.Dispose();
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
        #region
        [AutoComplete]
        public long m_lngGetPatientDebtDetail(System.DateTime StatDate, System.DateTime DateEnd, string Registerid, out DataTable dtbResult)
        {
            string BeginDate = StatDate.ToShortDateString() + " 00:00:00";
            string EndDate = DateEnd.AddDays(1).ToShortDateString() + " 00:00:00";
            dtbResult = new DataTable();
            long lngRes = 0;
            //			string strSQL = @"SELECT *
            //  FROM (SELECT to_char(c.createdate_dat,'YYYY-MM-DD HH24:MI:SS')AS createdate_dat, b.name_vchr, d.itemname_vchr,
            //               d.itemspec_vchr, d.itemipcalctype_chr, d.pdcarea_vchr,
            //               d.itemunit_chr, d.itemprice_mny, a.amount_dec, (SELECT lastname_vchr
            //                  FROM t_bse_employee
            //                 WHERE EMPID_CHR = a.activator_chr) AS activator_chr,
            //               a.amount_dec * d.itemprice_mny AS money,a.registerid_chr,a.active_dat
            //          FROM t_opr_bih_patientcharge a,
            //               t_opr_bih_order b,
            //               t_opr_bih_orderexecute c,
            //               t_bse_chargeitem d
            //         WHERE c.orderid_chr = b.orderid_chr
            //           AND a.orderexecid_chr = c.orderexecid_chr
            //           AND a.chargeitemid_chr = d.itemid_chr) a,
            //       (SELECT a.*, b.typeid_chr
            //          FROM (SELECT a.rptname_chr, a.rptid_chr, b.groupid_chr,
            //                       b.groupname_chr
            //                  FROM t_aid_rpt_def a, t_aid_rpt_gop_def b
            //                 WHERE a.rptid_chr = b.rptid_chr AND a.rptid_chr = '0003') a,
            //               t_aid_rpt_gop_rla b
            //         WHERE a.rptid_chr = b.rptid_chr AND a.groupid_chr = b.groupid_chr) b
            // WHERE a.itemipcalctype_chr = b.typeid_chr and a.registerid_chr = '"+Registerid+"' and a.active_dat > TO_DATE ('"+BeginDate+@"',
            //                                     'YYYY-MM-DD HH24:MI:SS') and a.active_dat <  TO_DATE ('"+EndDate+@"',
            //                                     'YYYY-MM-DD HH24:MI:SS')";
            string strSQL = @"SELECT a.*, b.typename_vchr
  FROM (SELECT a.amount_dec || a.unit_vchr AS amount,
               a.amount_dec * a.unitprice_dec AS money, b.itemname_vchr,
               b.itemspec_vchr, b.itemcode_vchr, b.itemipcalctype_chr
          FROM (SELECT *
                  FROM t_opr_bih_patientcharge a
                 WHERE a.registerid_chr = '" + Registerid + @"'
                   AND a.create_dat > TO_DATE ('" + BeginDate + @"', 'YYYY-MM-DD HH24:MI:SS')
                   AND a.create_dat < TO_DATE ('" + EndDate + @"', 'YYYY-MM-DD HH24:MI:SS')) a,
               t_bse_chargeitem b
         WHERE a.chargeitemid_chr = b.itemid_chr) a,
       t_bse_chargeitemextype b
 WHERE a.itemipcalctype_chr = b.typeid_chr";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT a.*, b.typename_vchr
  FROM (SELECT a.amount_dec + a.unit_vchr AS amount,
               a.amount_dec * a.unitprice_dec AS money, b.itemname_vchr,
               b.itemspec_vchr, b.itemcode_vchr, b.itemipcalctype_chr
          FROM (SELECT *
                  FROM t_opr_bih_patientcharge a
                 
                 WHERE a.registerid_chr = '" + Registerid + @"'
                 
               
                   AND a.create_dat > CONVERT (DATETIME,'" + BeginDate + @"')
                   AND a.create_dat < CONVERT (DATETIME,'" + EndDate + @"')
                   ) a,
               t_bse_chargeitem b
         WHERE a.chargeitemid_chr = b.itemid_chr) a,
       t_bse_chargeitemextype b
 WHERE a.itemipcalctype_chr = b.typeid_chr";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objService.DoGetDataTable(strSQL, ref dtbResult);
                objService.Dispose();
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
        #region  私有方法
        [AutoComplete]
        private long lngSelectSQL(string p_strSQL, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            if (p_strSQL.Trim() == "") return lngRes;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(p_strSQL, ref p_dtbResult);
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
        #region 住院医嘱执行单
        /// <summary>
        /// 查询医嘱执行单
        /// </summary>
        /// <param name="p_strArrCondition">执行单筛选条件</param>
        /// <param name="AreaID">病区ID</param>
        /// <param name="registerid">入院登记ID</param>
        /// <param name="Bed">病床ID</param>
        /// <param name="excutedate">执行时间</param>
        /// <param name="type">医嘱类型,长嘱,临嘱等</param>
        /// <param name="dtbResult">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorAdviceExute(string[] p_strArrCondition, string AreaID, string registerid, string[] Bed, string excutedate, int type, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT a.*
  FROM (SELECT a.*, b.ordercateid_chr, b.typecate
          FROM (SELECT to_char(a.recipeno_int) AS TYPE, a.name_vchr AS itemname,
                       a.orderdicid_chr,a.EXECUTORID_CHR,
                       (a.use_dec || a.useunit_chr) usecount,
                       a.execfreqname_chr AS frequency, a.dosetypename_chr AS useway,
                       a.executedate_vchr AS excutetime, b.bed,
                       b.lastname_vchr AS NAME,
                       DECODE (executetype_int,
                               1, '长嘱',
                               2, '临嘱',
                               ''
                              ) AS exetype,
                       DECODE (isrecruit_int,
                               1, '(+)',
                               2, '',
                               ''
                              ) AS recruit
                  FROM (SELECT a.*, b.name_chr
                          FROM (SELECT b.orderid_chr, b.orderdicid_chr,
                                       b.executorid_chr, b.registerid_chr,
                                       b.patientid_chr, b.executetype_int,
                                       b.recipeno_int, b.name_vchr, b.use_dec,
                                       b.useunit_chr, b.execfreqname_chr,
                                       a.executedate_vchr, b.dosetypename_chr,
                                       a.isrecruit_int
                                  FROM t_opr_bih_orderexecute a,
                                       t_opr_bih_order b
                                 WHERE a.orderid_chr = b.orderid_chr
                                   AND a.status_int = 1
                                   AND (to_date('" + excutedate + @"','YYYY-MM-DD')-to_date(to_char(a.CREATEDATE_DAT,'YYYY-MM-DD'),'YYYY-MM-DD')) = 0 --<A.executedays_int
                                   [type]
                               ) a,
                               (SELECT a.orderdicid_chr,
                                       b.usagename_vchr AS name_chr
                                  FROM t_bse_bih_orderdic a,
                                       t_bse_usagetype b
                                 WHERE a.nullitemdosetypeid_chr = b.usageid_chr(+)) b
                         WHERE a.orderdicid_chr = b.orderdicid_chr) a,
                       (SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr,
                               (SELECT code_chr
                                  FROM t_bse_bed
                                 WHERE bedid_chr = a.bedid_chr) AS bed
                          FROM t_opr_bih_register a, t_bse_patient b
                         WHERE	a.patientid_chr = b.patientid_chr
								AND a.status_int = 1
								AND b.status_int = 1
								AND (a.pstatus_int = 1 OR a.pstatus_int = 2 OR a.pstatus_int = 4)
								AND a.bedid_chr IS NOT NULL [Bed] and a.areaid_chr = '" + AreaID + @"'
                   [registerid]) b
         WHERE a.registerid_chr = b.registerid_chr) a,
       (SELECT a.orderdicid_chr, b.ordercateid_chr, b.name_chr AS typecate
          FROM t_bse_bih_orderdic a, t_aid_bih_ordercate b
         WHERE a.ordercateid_chr = b.ordercateid_chr) b
 WHERE a.orderdicid_chr = b.orderdicid_chr) a";
            for (int i = 0; i < p_strArrCondition.Length; i++)
            {
                strSQL += p_strArrCondition[i];
            }
            if (registerid != "")
            {
                strSQL = strSQL.Replace("[registerid]", " and a.registerid_chr = '" + registerid + "'");
            }
            else
            {
                strSQL = strSQL.Replace("[registerid]", "");
            }
            if (Bed.Length > 0)
            {
                string selectbed = "";
                if (Bed.Length == 1)
                {
                    selectbed = " and a.bedid_chr = '" + Bed[0].ToString().Trim() + "'";
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
                else
                {
                    string ff = "";
                    selectbed = "and ( 1=2 [ee])";
                    for (int i = 0; i < Bed.Length; i++)
                    {
                        ff += "or a.bedid_chr = '" + Bed[i].ToString().Trim() + "'";
                    }
                    selectbed = selectbed.Replace("[ee]", ff);
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
            }
            else
            {
                strSQL = strSQL.Replace("[Bed]", "");
            }
            if (1 == 1)
            {
                //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
                //				strSQL = strSQL.Replace("[type]",strType);
                string strType = " and (1=2 ";
                char[] chArr = type.ToString().PadLeft(3, '0').ToCharArray();
                for (int i = 0; i < chArr.Length; i++)
                {
                    if (i == 2)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or a.ISRECRUIT_INT = 1";
                        }
                        else
                        {
                        }
                    }
                    else if (i == 1)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 2";
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 1 and a.ISRECRUIT_INT = 0";
                        }
                        else
                        {
                        }
                    }
                }
                strType += ")";
                strSQL = strSQL.Replace("[type]", strType);
            }
            //			else
            //			{
            //				strSQL = strSQL.Replace("[type]","");
            //			}
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        #region 护理饮食报告单
        [AutoComplete]
        public long m_lngGetFoodCareReport(string p_strfoodID, string p_strCareID, string[] Bed, string excutedate, int type, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"    select * from (
    SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr as Name,
               (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = a.bedid_chr) AS bed
          FROM t_opr_bih_register a, t_bse_patient b
         WHERE	a.patientid_chr = b.patientid_chr 
				AND a.status_int = 1
				AND b.status_int = 1
				AND (a.pstatus_int = 1 OR a.pstatus_int = 2 OR a.pstatus_int = 4)
				AND a.bedid_chr IS NOT NULL [Bed] ) a,(SELECT distinct registerid_chr,
       max(DECODE (ordercateid_chr, '" + p_strfoodID + @"', name_chr)) AS food,
       max(DECODE (ordercateid_chr, '" + p_strCareID + @"', name_chr)) AS care,
                        MAX (DECODE (executetype_int,
                                     1, '长嘱',
                                     2, '临嘱',
                                     ''
                                    )
                            ) AS exetype
  FROM (SELECT b.*, a.executedate_vchr
                           FROM t_opr_bih_orderexecute a, t_opr_bih_order b
                          WHERE a.orderid_chr = b.orderid_chr
                            AND a.status_int = 1
                            AND (  TO_DATE ('" + excutedate + @"', 'YYYY-MM-DD')
                                 - TO_DATE (TO_CHAR (a.createdate_dat,
                                                     'YYYY-MM-DD'
                                                    ),
                                            'YYYY-MM-DD'
                                           )
                                ) < a.executedays_int
                            AND b.status_int = 2
                            [type]) a, t_bse_bih_orderdic b
 WHERE a.orderdicid_chr = b.orderdicid_chr AND (b.ordercateid_chr = '" + p_strfoodID + @"'
    OR b.ordercateid_chr = '" + p_strCareID + @"')
    group by a.registerid_chr) b where a.registerid_chr = b.registerid_chr";
            if (Bed.Length > 0)
            {
                string selectbed = "";
                if (Bed.Length == 1)
                {
                    selectbed = " and a.bedid_chr = '" + Bed[0].ToString().Trim() + "'";
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
                else
                {
                    string ff = "";
                    selectbed = "and ( 1=2 [ee])";
                    for (int i = 0; i < Bed.Length; i++)
                    {
                        ff += "or a.bedid_chr = '" + Bed[i].ToString().Trim() + "'";
                    }
                    selectbed = selectbed.Replace("[ee]", ff);
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
            }
            else
            {
                strSQL = strSQL.Replace("[Bed]", "");
            }
            //			if(type!=0)
            //			{
            //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
            //				strSQL = strSQL.Replace("[type]",strType);
            //			}
            //			else
            //			{
            //				strSQL = strSQL.Replace("[type]","");
            //			}
            if (1 == 1)
            {
                //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
                //				strSQL = strSQL.Replace("[type]",strType);
                string strType = " and (1=2 ";
                char[] chArr = type.ToString().PadLeft(3, '0').ToCharArray();
                for (int i = 0; i < chArr.Length; i++)
                {
                    if (i == 2)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or a.ISRECRUIT_INT = 1";
                        }
                        else
                        {
                        }
                    }
                    else if (i == 1)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 2";
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 1 and a.ISRECRUIT_INT = 0";
                        }
                        else
                        {
                        }
                    }
                }
                strType += ")";
                strSQL = strSQL.Replace("[type]", strType);
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        #region 饮食报告单
        [AutoComplete]
        public long m_lngGetFoodReport(string p_strfoodID, string p_strCareID, string[] Bed, string excutedate, int type, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT bed,name,food,execdate,b.exetype
  FROM (SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr as Name,
               (SELECT code_chr
                  FROM t_bse_bed
                 WHERE bedid_chr = a.bedid_chr) AS bed
          FROM t_opr_bih_register a, t_bse_patient b
         WHERE	a.patientid_chr = b.patientid_chr 
				AND a.status_int = 1
				AND b.status_int = 1
				AND (a.pstatus_int = 1 OR a.pstatus_int = 2 OR a.pstatus_int = 4)
				AND a.bedid_chr IS NOT NULL [Bed] ) a,
       (SELECT DISTINCT registerid_chr,
                        MAX (DECODE (ordercateid_chr,
                                     '" + p_strfoodID + @"', name_chr
                                    )) AS food,
                        MAX (DECODE (ordercateid_chr,
                                     '" + p_strCareID + @"', name_chr
                                    )) AS care,
                        MAX (executedate_vchr) AS ExecDate,
                        MAX (DECODE (executetype_int,
                                     1, '长嘱',
                                     2, '临嘱',
                                     ''
                                    )
                            ) AS exetype
                   FROM (SELECT *
                           FROM (SELECT b.*, a.executedate_vchr
                           FROM t_opr_bih_orderexecute a, t_opr_bih_order b
                          WHERE a.orderid_chr = b.orderid_chr
                            AND a.status_int = 1
                            AND (  TO_DATE ('" + excutedate + @"', 'YYYY-MM-DD')
                                 - TO_DATE (TO_CHAR (a.createdate_dat,
                                                     'YYYY-MM-DD'
                                                    ),
                                            'YYYY-MM-DD'
                                           )
                                ) < a.executedays_int
                            AND b.status_int = 2
                            [type]) a
                          WHERE a.status_int = 2) a,
                        t_bse_bih_orderdic b
                  WHERE a.orderdicid_chr = b.orderdicid_chr
                    AND (b.ordercateid_chr = '" + p_strfoodID + @"' OR b.ordercateid_chr = '" + p_strCareID + @"'
                        )
               GROUP BY a.registerid_chr) b
 WHERE a.registerid_chr = b.registerid_chr";
            if (Bed.Length > 0)
            {
                string selectbed = "";
                if (Bed.Length == 1)
                {
                    selectbed = " and a.bedid_chr = '" + Bed[0].ToString().Trim() + "'";
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
                else
                {
                    string ff = "";
                    selectbed = "and ( 1=2 [ee])";
                    for (int i = 0; i < Bed.Length; i++)
                    {
                        ff += "or a.bedid_chr = '" + Bed[i].ToString().Trim() + "'";
                    }
                    selectbed = selectbed.Replace("[ee]", ff);
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
            }
            else
            {
                strSQL = strSQL.Replace("[Bed]", "");
            }
            //			if(type!=0)
            //			{
            //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
            //				strSQL = strSQL.Replace("[type]",strType);
            //			}
            //			else
            //			{
            //				strSQL = strSQL.Replace("[type]","");
            //			}
            if (1 == 1)
            {
                //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
                //				strSQL = strSQL.Replace("[type]",strType);
                string strType = " and (1=2 ";
                char[] chArr = type.ToString().PadLeft(3, '0').ToCharArray();
                for (int i = 0; i < chArr.Length; i++)
                {
                    if (i == 2)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or a.ISRECRUIT_INT = 1";
                        }
                        else
                        {
                        }
                    }
                    else if (i == 1)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 2";
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 1 and a.ISRECRUIT_INT = 0";
                        }
                        else
                        {
                        }
                    }
                }
                strType += ")";
                strSQL = strSQL.Replace("[type]", strType);
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        #region 个人工作单
        [AutoComplete]
        public long m_lngGetPersonalWork(string EmpID, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT a.*
  FROM (SELECT a.*, b.ordercateid_chr, b.typecate
          FROM (SELECT a.recipeno_int AS TYPE, a.name_vchr AS itemname,
                       a.orderdicid_chr,a.EXECUTORID_CHR,
                       (a.use_dec || a.useunit_chr) usecount,
                       a.execfreqname_chr AS frequency, a.name_chr AS useway,
                       a.executedate_vchr AS excutetime, b.bed,
                       b.lastname_vchr AS NAME,DECODE (executetype_int,
                               1, '长嘱',
                               2, '临嘱',
                               ''
                              ) AS exetype
                  FROM (SELECT a.*, b.name_chr
                          FROM (SELECT b.orderid_chr, b.orderdicid_chr,
                                       b.executorid_chr, b.registerid_chr,
                                       b.patientid_chr, b.executetype_int,
                                       b.recipeno_int, b.name_vchr, b.use_dec,
                                       b.useunit_chr, b.execfreqname_chr,
                                       a.executedate_vchr
                                  FROM t_opr_bih_orderexecute a,
                                       t_opr_bih_order b
                                 WHERE a.orderid_chr = b.orderid_chr
                                   AND a.status_int = 1
                                                       --AND a.executedate_vchr = ''
                               ) a,
                               (SELECT a.orderdicid_chr,
                                       b.usagename_vchr AS name_chr
                                  FROM t_bse_bih_orderdic a,
                                       t_bse_usagetype b
                                 WHERE a.nullitemdosetypeid_chr = b.usageid_chr(+)) b
                         WHERE a.orderdicid_chr = b.orderdicid_chr) a,
                       (SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr,
                               (SELECT code_chr
                                  FROM t_bse_bed
                                 WHERE bedid_chr = a.bedid_chr) AS bed
                          FROM t_opr_bih_register a, t_bse_patient b
                         WHERE a.patientid_chr = b.patientid_chr
                           AND a.bedid_chr IS NOT NULL
                           AND a.areaid_chr = '0000073') b
                 WHERE a.registerid_chr = b.registerid_chr) a,
               (SELECT a.orderdicid_chr, b.ordercateid_chr,
                       b.name_chr AS typecate
                  FROM t_bse_bih_orderdic a, t_aid_bih_ordercate b
                 WHERE a.ordercateid_chr = b.ordercateid_chr) b
         WHERE a.orderdicid_chr = b.orderdicid_chr) a where a.executorid_chr = '" + EmpID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        #region 发送单
        [AutoComplete]
        public long m_lngSendreport(string AreaID, string[] Bed, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT a.recipeno_int AS ID, (a.itemcode_vchr || a.itemname) AS itemname,
       a.execfreqname_chr as useway, a.status, a.get_count as count, a.money,
       a.lastname_vchr, a.inpatientid_chr, a.bed,DECODE (executetype_int, 1, '长嘱', 2, '临嘱', '') AS exetype
  FROM (SELECT *
          FROM (SELECT a.*, b.itemcode_vchr,
                       (   TRIM (b.itemname_vchr)
                        || ' '
                        || TRIM (b.dosage_dec)
                        || '.'
                        || TRIM (b.dosageunit_chr)
                       ) AS itemname,
                       (a.get_dec || a.getunit_chr) AS get_count,
                       (a.get_dec * b.itemprice_mny) AS money
                  FROM (SELECT a.*, b.itemid_chr
                          FROM (SELECT DECODE (a.isrecruit_int,
                                               '1', '新开加',
                                               
                                               --'0', '正常',
                                               ''
                                              ) AS status,b.executetype_int,
                                       b.orderdicid_chr, b.recipeno_int,
                                       b.execfreqname_chr, b.get_dec,
                                       b.getunit_chr, b.registerid_chr
                                  FROM t_opr_bih_orderexecute a,
                                       t_opr_bih_order b
                                 WHERE a.orderid_chr = b.orderid_chr) a,
                               t_aid_bih_orderdic_charge b
                         WHERE a.orderdicid_chr = b.orderdicid_chr) a,
                       t_bse_chargeitem b
                 WHERE a.itemid_chr = b.itemid_chr) a,
               (SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr,
                       a.inpatientid_chr,
                       (SELECT code_chr
                          FROM t_bse_bed
                         WHERE bedid_chr = a.bedid_chr) AS bed
                  FROM t_opr_bih_register a, t_bse_patient b
                 WHERE	a.patientid_chr = b.patientid_chr
                        AND a.status_int = 1
                        AND b.status_int = 1
                        AND (a.pstatus_int = 1 OR a.pstatus_int = 2 OR a.pstatus_int = 4)
						AND a.bedid_chr IS NOT NULL
						AND a.areaid_chr = '" + AreaID + @"'
						[Bed]) b
         WHERE a.registerid_chr = b.registerid_chr) a";
            if (Bed.Length > 0)
            {
                string selectbed = "";
                if (Bed.Length == 1)
                {
                    selectbed = " and a.bedid_chr = '" + Bed[0].ToString().Trim() + "'";
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
                else
                {
                    string ff = "";
                    selectbed = "and ( 1=2 [ee])";
                    for (int i = 0; i < Bed.Length; i++)
                    {
                        ff += "or a.bedid_chr = '" + Bed[i].ToString().Trim() + "'";
                    }
                    selectbed = selectbed.Replace("[ee]", ff);
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
            }
            else
            {
                strSQL = strSQL.Replace("[Bed]", "");
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        [AutoComplete]
        public long m_lngSendreport(string AreaID, string registerid, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT a.recipeno_int AS ID, (a.itemcode_vchr || a.itemname) AS itemname,
       a.execfreqname_chr as useway, a.status, a.get_count as count, a.money,DECODE (executetype_int, 1, '长嘱', 2, '临嘱', '') AS exetype
  FROM (SELECT *
          FROM (SELECT a.*, b.itemcode_vchr,
                       (   TRIM (b.itemname_vchr)
                        || ' '
                        || TRIM (b.dosage_dec)
                        || '.'
                        || TRIM (b.dosageunit_chr)
                       ) AS itemname,
                       (a.get_dec || a.getunit_chr) AS get_count,
                       (a.get_dec * b.itemprice_mny) AS money
                  FROM (SELECT a.*, b.itemid_chr
                          FROM (SELECT DECODE (a.isrecruit_int,
                                               '1', '新开加',
                                               
                                               --'0', '正常',
                                               ''
                                              ) AS status,
                                       b.orderdicid_chr, b.recipeno_int,b.executetype_int,
                                       b.execfreqname_chr, b.get_dec,
                                       b.getunit_chr, b.registerid_chr
                                  FROM t_opr_bih_orderexecute a,
                                       t_opr_bih_order b
                                 WHERE a.orderid_chr = b.orderid_chr) a,
                               t_aid_bih_orderdic_charge b
                         WHERE a.orderdicid_chr = b.orderdicid_chr) a,
                       t_bse_chargeitem b
                 WHERE a.itemid_chr = b.itemid_chr) a,
               (SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr,
                       a.inpatientid_chr,
                       (SELECT code_chr
                          FROM t_bse_bed
                         WHERE bedid_chr = a.bedid_chr) AS bed
                  FROM t_opr_bih_register a, t_bse_patient b
                 WHERE	a.patientid_chr = b.patientid_chr
                        AND a.status_int = 1
                        AND b.status_int = 1
                        AND (a.pstatus_int = 1 OR a.pstatus_int = 2 OR a.pstatus_int = 4)
						AND a.bedid_chr IS NOT NULL
						AND a.areaid_chr = '" + AreaID + @"'
						AND A.registerid_chr = '" + registerid + @"') b
         WHERE a.registerid_chr = b.registerid_chr) a";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        #region 输液巡视卡
        /// <summary>
        /// 输液巡视卡
        /// </summary>
        /// <param name="p_strArrCondition">医嘱筛选条件</param>
        /// <param name="AreaID">病区ID</param>
        /// <param name="registerid">病人住院登记ID</param>
        /// <param name="dtbResult">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTransfusionData(string[] p_strArrCondition, string AreaID, string registerid, string[] Bed, string excutedate, int type, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            string strSQL = @"SELECT a.*
  FROM (SELECT a.*, b.ordercateid_chr, b.typecate
          FROM (SELECT a.recipeno_int || a.name_vchr AS itemname,
                       TO_CHAR (a.startdate_dat, 'YYYY-MM-DD') AS excudate,
                       a.orderdicid_chr, a.executorid_chr,
                       (a.use_dec || a.useunit_chr) usecount,
                       a.execfreqname_chr AS frequency, a.dosetypename_chr AS useway,
                       a.executedate_vchr AS excutetime, b.bed,
                       b.lastname_vchr AS NAME,
                       DECODE (executetype_int,
                               1, '长嘱',
                               2, '临嘱',
                               ''
                              ) AS exetype
                  FROM (SELECT b.orderid_chr, b.orderdicid_chr,
                            b.startdate_dat, b.executorid_chr,
                            b.registerid_chr, b.patientid_chr,
                            b.executetype_int, b.recipeno_int,
                            b.name_vchr, b.use_dec, b.useunit_chr,
                            b.execfreqname_chr, a.executedate_vchr,
							b.dosetypename_chr 
                        FROM t_opr_bih_orderexecute a,
                            t_opr_bih_order b
                        WHERE a.orderid_chr = b.orderid_chr
                        AND a.status_int = 1
                        AND (to_date('" + excutedate + @"','YYYY-MM-DD')-to_date(to_char(a.CREATEDATE_DAT,'YYYY-MM-DD'),'YYYY-MM-DD'))<A.executedays_int
                        [type]
						) a,
                       (SELECT a.registerid_chr, a.bedid_chr, b.lastname_vchr,
                               (SELECT code_chr
                                  FROM t_bse_bed
                                 WHERE bedid_chr = a.bedid_chr) AS bed
                          FROM t_opr_bih_register a, t_bse_patient b
                         WHERE a.patientid_chr = b.patientid_chr
                           AND a.status_int = 1
                           AND b.status_int = 1
                           AND (a.pstatus_int = 1 OR a.pstatus_int = 2 OR a.pstatus_int = 4)
                           AND a.bedid_chr IS NOT NULL
                           [Bed]
                           AND a.areaid_chr = '" + AreaID + @"'
                           [registerid]) b
                 WHERE a.registerid_chr = b.registerid_chr) a,
               (SELECT a.orderdicid_chr, b.ordercateid_chr,
                       b.name_chr AS typecate
                  FROM t_bse_bih_orderdic a, t_aid_bih_ordercate b
                 WHERE a.ordercateid_chr = b.ordercateid_chr) b
         WHERE a.orderdicid_chr = b.orderdicid_chr) a";
            for (int i = 0; i < p_strArrCondition.Length; i++)
            {
                strSQL += p_strArrCondition[i];
            }
            if (registerid != "")
            {
                strSQL = strSQL.Replace("[registerid]", " and a.registerid_chr = '" + registerid + "'");
            }
            else
            {
                strSQL = strSQL.Replace("[registerid]", "");
            }
            //			if(type!=0)
            //			{
            //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
            //				strSQL = strSQL.Replace("[type]",strType);
            //			}
            //			else
            //			{
            //				strSQL = strSQL.Replace("[type]","");
            //			}
            if (1 == 1)
            {
                //				string strType = "AND B.EXECUTETYPE_INT = "+type.ToString();
                //				strSQL = strSQL.Replace("[type]",strType);
                string strType = " and (1=2 ";
                char[] chArr = type.ToString().PadLeft(3, '0').ToCharArray();
                for (int i = 0; i < chArr.Length; i++)
                {
                    if (i == 2)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or a.ISRECRUIT_INT = 1";
                        }
                        else
                        {
                        }
                    }
                    else if (i == 1)
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 2";
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (chArr[i] == '1')
                        {
                            strType += " or b.EXECUTETYPE_INT = 1 and a.ISRECRUIT_INT = 0";
                        }
                        else
                        {
                        }
                    }
                }
                strType += ")";
                strSQL = strSQL.Replace("[type]", strType);
            }
            if (Bed.Length > 0)
            {
                string selectbed = "";
                if (Bed.Length == 1)
                {
                    selectbed = " and a.bedid_chr = '" + Bed[0].ToString().Trim() + "'";
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
                else
                {
                    string ff = "";
                    selectbed = "and ( 1=2 [ee])";
                    for (int i = 0; i < Bed.Length; i++)
                    {
                        ff += "or a.bedid_chr = '" + Bed[i].ToString().Trim() + "'";
                    }
                    selectbed = selectbed.Replace("[ee]", ff);
                    strSQL = strSQL.Replace("[Bed]", selectbed);
                }
            }
            else
            {
                strSQL = strSQL.Replace("[Bed]", "");
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
    }
}
