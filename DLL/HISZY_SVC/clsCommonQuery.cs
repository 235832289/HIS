using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
//using Oracle.DataAccess.Client;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsCommonQuery : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        private string m_strSQL;

        #region 构造
        public clsCommonQuery()
        {
        }
        #endregion

        #region 根据用户ID获取所属角色列表
        /// <summary>
        /// 根据用户ID获取所属角色列表
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmpRole(string EmpID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.roleid_chr 
                             from t_sys_emprolemap a
                            where a.empid_chr = ?";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = EmpID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 获取身份(费别)信息
        /// <summary>
        /// 获取身份(费别)信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPayTypeInfo(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select paytypeid_chr, paytypename_vchr, memo_vchr, paylimit_mny, payflag_dec,
                                  paypercent_dec, paytypeno_vchr, isusing_num, copayid_chr,
                                  chargepercent_dec, internalflag_int, coalitionrecipeflag_int,
                                  bihlimitrate_dec
                             from t_bse_patientpaytype order by paytypeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 获取病区信息
        /// <summary>
        /// 获取病区信息
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="Flag">1 科室 2 病区</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptArea(out DataTable dt, int Flag)
        {
            long lngRes = 0;
            string SQL = "";

            if (Flag == 1)
            {
                SQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                               inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                               attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                               wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                               putmed_int
                          from t_bse_deptdesc 
                         where status_int = 1 
                           and ((inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0)
                      order by code_vchr";
            }
            else if (Flag == 2)
            {
                SQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                               inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                               attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                               wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                               putmed_int
                          from t_bse_deptdesc 
                         where status_int = 1 
                           and ((inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0)
                           and attributeid = '0000003'
                      order by code_vchr";
            }
            else if (Flag == 3)
            {
                SQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                               inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                               attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                               wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                               putmed_int
                          from t_bse_deptdesc 
                         where status_int = 1 
                           and ((inpatientoroutpatient_int = 0 or inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0)
                      order by code_vchr";
            }

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 根据病区ID获取该病区床位信息
        /// <summary>
        /// 根据病区ID获取该病区床位信息
        /// </summary>
        /// <param name="AreaID">病区ID</param>
        /// <param name="status">查询类型 0 全部 1 空床 2 占床(占床、包房) 3 预约占床 4 包房占床 5 删除 6 预出院占床</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBedinfo(string AreaID, int status, out DataTable dt)
        {
            long lngRes = 0;
            string sqlstatus = "";

            switch (status)
            {
                case 0:
                    sqlstatus = " and a.status_int <> 5 ";
                    break;
                case 1:
                    sqlstatus = " and a.status_int = 1 ";
                    break;
                case 2:
                    sqlstatus = " and (a.status_int = 2 or a.status_int = 4) ";
                    break;
                case 3:
                    sqlstatus = " and a.status_int = 3 ";
                    break;
            }

            string SQL = @"select a.areaid_chr, b.inpatientid_chr, b.inpatientcount_int, a.bedid_chr, a.code_chr, c.lastname_vchr, c.sex_chr, b.pstatus_int, 
                                  c.birth_dat, to_char(b.inpatient_dat,'yyyy/mm/dd hh24:mi:ss') as rysj, b.registerid_chr, b.patientid_chr, d.patientcardid_chr
                             from t_bse_bed a, t_opr_bih_register b, t_opr_bih_registerdetail c, t_bse_patientcard d   
                            where a.bihregisterid_chr = b.registerid_chr(+)
                              and b.registerid_chr = c.registerid_chr(+)
                              and a.bedid_chr = b.bedid_chr(+)  
                              and b.patientid_chr = d.patientid_chr(+)                            
                              and a.areaid_chr like ? " + sqlstatus + @"                               
                            order by a.code_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = AreaID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 根据病区ID和床号ID(或CODE)获取住院号
        /// <summary>
        /// 根据病区ID和床号ID(或CODE)获取住院号
        /// </summary>
        /// <param name="AreaID">病区ID</param>
        /// <param name="BedID">病床ID(或CODE)</param>        
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetZyhByAreaAndBedID(string AreaID, string BedID)
        {
            string Zyh = "";
            DataTable dt = new DataTable();

            try
            {
                string SQL = @"select a.inpatientid_chr
                                 from t_opr_bih_register a,
                                      t_bse_bed b    
                                where a.registerid_chr = b.bihregisterid_chr
                                  and a.areaid_chr = b.areaid_chr 
                                  and a.bedid_chr = b.bedid_chr                                                                     
                                  and a.areaid_chr = ? 
                                  and (a.bedid_chr = ? or b.code_chr = ?)";

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = BedID;
                ParamArr[2].Value = BedID;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    Zyh = dt.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return Zyh;
        }
        #endregion

        #region 根据住院号或诊疗卡号获取病人信息
        /// <summary>
        /// 根据住院号或诊疗卡号获取病人信息
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dt"></param>
        /// <param name="type">0 按住院号或诊疗卡号查所有病人信息 1 按住院号(按入院时间.倒序)查在院病人信息 2 按诊疗卡号查在院病人信息 3 按住院号(按出院时间.倒序)查出院病人信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientinfoByZyh(string no, out DataTable dt, int type)
        {
            long lngRes = 0;

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string SqlWhere = "";
            switch (type)
            {
                case 0:
                    SqlWhere = "and (b.inpatientid_chr = ? or d.patientcardid_chr = ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = no;
                    ParamArr[1].Value = no;

                    break;
                case 1:
                    SqlWhere = @"and (b.pstatus_int = 0 or b.pstatus_int = 1 or b.pstatus_int = 4) 
                                 and b.inpatientid_chr = ? order by b.inpatient_dat desc";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = no;

                    break;
                case 2:
                    SqlWhere = @"and (b.pstatus_int = 0 or b.pstatus_int = 1 or b.pstatus_int = 4) 
                                 and d.patientcardid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = no;

                    break;
                case 3:
                    SqlWhere = @"and (b.pstatus_int = 2 or b.pstatus_int = 3) 
                                 and b.inpatientid_chr = ? order by t1.outhospital_dat desc";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = no;

                    break;
                default:
                    SqlWhere = "and (b.inpatientid_chr = ? or d.patientcardid_chr = ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = no;
                    ParamArr[1].Value = no;

                    break;
            }

            string SQL = @"select b.areaid_chr, e.deptname_vchr, b.inpatientid_chr, b.inpatientcount_int, a.bedid_chr, a.code_chr, b.patientid_chr, 
                                  c.lastname_vchr, c.sex_chr, c.birth_dat, to_char(b.inpatient_dat,'yyyy/mm/dd hh24:mi:ss') as rysj,
                                  c.idcard_chr, c.homeaddress_vchr, b.inpatientnotype_int, b.registerid_chr, to_char(t1.outhospital_dat, 'yyyy/mm/dd hh24:mi:ss') as cysj,
                                  t2.deptname_vchr as cybq, t3.code_chr as cybc, b.pstatus_int, b.paytypeid_chr    
                             from t_bse_bed a, 
                                  (select tb1.registerid_chr, tb1.modify_dat, tb1.patientid_chr,
                                          tb1.isbooking_int, tb1.inpatientid_chr, tb1.inpatient_dat,
                                          tb1.deptid_chr, tb1.areaid_chr, tb1.bedid_chr, tb1.type_int,
                                          tb1.diagnose_vchr, tb1.limitrate_mny, tb1.inpatientcount_int,
                                          tb1.state_int, tb1.status_int, tb1.operatorid_chr, tb1.pstatus_int,
                                          tb1.casedoctor_chr, tb1.inpatientnotype_int, tb1.des_vchr,
                                          tb1.inareadate_dat, tb1.mzdoctor_chr, tb1.mzdiagnose_vchr,
                                          tb1.diagnoseid_chr, tb1.icd10diagid_vchr, tb1.icd10diagtext_vchr,
                                          tb1.isfromclinic, tb1.clinicsayprepay, tb1.paytypeid_chr,
                                          tb1.bornnum_int, tb1.relateregisterid_chr, tb1.feestatus_int,
                                          tb1.extendid_vchr, tb1.nursing_class, tb1.casedoctordept_chr,
                                          tb1.cancelerid_chr, tb1.cancel_dat, tb1.outdiagnose_vchr,
                                          tb1.insuredsum_mny
                                     from t_opr_bih_register tb1
                                    where exists (select 1
                                                    from (select max(tb2.registerid_chr) as registerid_chr
                                                            from t_opr_bih_register tb2
                                                           group by tb2.inpatientid_chr) tb2
                                                   where tb1.registerid_chr = tb2.registerid_chr)
                                  ) b, 
                                  t_opr_bih_registerdetail c, t_bse_patientcard d, t_bse_deptdesc e,
                                  (select registerid_chr, outareaid_chr, outbedid_chr, outhospital_dat from t_opr_bih_leave where status_int = 1) t1, t_bse_deptdesc t2, t_bse_bed t3   
                            where b.registerid_chr = a.bihregisterid_chr(+)
                              and b.registerid_chr = c.registerid_chr  
                              and b.bedid_chr = a.bedid_chr(+)                              
                              and b.patientid_chr = d.patientid_chr(+)
                              and b.areaid_chr = e.deptid_chr(+)
                              and b.status_int = 1                               
                              and b.registerid_chr = t1.registerid_chr(+) 
                              and t1.outareaid_chr = t2.deptid_chr(+)
                              and t1.outbedid_chr = t3.bedid_chr(+) ";

            SQL += SqlWhere;

            dt = new DataTable();

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 根据住院号或诊疗卡号获取病人信息
        /// </summary>
        /// <param name="no"></param>       
        /// <param name="dt"></param>
        /// <param name="flag">0 所有 1 在院 2 预出院 3 实际出院 4 请假 5 呆帐 8 出院结算 9 预交款、直收、补记帐</param>
        /// <param name="type">0 诊疗卡号或住院号 1 诊疗卡号  2 住院号  3 入院登记流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientinfoByNO(string no, out DataTable dt, int flag, int type)
        {
            long lngRes = 0;

            string f1 = " and (b.pstatus_int = 0 or b.pstatus_int = 1 or b.pstatus_int = 4) ";
            string f2 = " and b.pstatus_int = 2 ";
            string f3 = " and b.pstatus_int = 3 ";
            string f8 = " and (b.pstatus_int = 2 or b.pstatus_int = 3)";
            string f9 = " and (b.pstatus_int = 0 or b.pstatus_int = 1 or b.pstatus_int = 2 or b.pstatus_int = 4) ";
            string t0 = " and (b.inpatientid_chr = ? or d.patientcardid_chr = ?)";
            string t1 = " and (d.patientcardid_chr = ?)";
            string t2 = " and (b.inpatientid_chr = ?)";
            string t3 = " and (b.registerid_chr = ?)";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            if (type == 1 || type == 2 || type == 3)
            {
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = no;
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = no;
                ParamArr[1].Value = no;
            }

            string SqlWhere = "";
            switch (flag)
            {
                case 0:
                    if (type == 0)
                    {
                        SqlWhere = t0;
                    }
                    else if (type == 1)
                    {
                        SqlWhere = t1;
                    }
                    else if (type == 2)
                    {
                        SqlWhere = t2;
                    }
                    else if (type == 3)
                    {
                        SqlWhere = t3;
                    }

                    break;
                case 1:
                    if (type == 0)
                    {
                        SqlWhere = f1 + t0;
                    }
                    else if (type == 1)
                    {
                        SqlWhere = f1 + t1;
                    }
                    else if (type == 2)
                    {
                        SqlWhere = f1 + t2;
                    }
                    else if (type == 3)
                    {
                        SqlWhere = f1 + t3;
                    }
                    break;
                case 2:
                    if (type == 0)
                    {
                        SqlWhere = f2 + t0;
                    }
                    else if (type == 1)
                    {
                        SqlWhere = f2 + t1;
                    }
                    else if (type == 2)
                    {
                        SqlWhere = f2 + t2;
                    }
                    else if (type == 3)
                    {
                        SqlWhere = f2 + t3;
                    }
                    break;
                case 3:
                    if (type == 0)
                    {
                        SqlWhere = f3 + t0;
                    }
                    else if (type == 1)
                    {
                        SqlWhere = f3 + t1;
                    }
                    else if (type == 2)
                    {
                        SqlWhere = f3 + t2;
                    }
                    else if (type == 3)
                    {
                        SqlWhere = f3 + t3;
                    }
                    break;
                case 8:
                    if (type == 0)
                    {
                        SqlWhere = f8 + t0;
                    }
                    else if (type == 1)
                    {
                        SqlWhere = f8 + t1;
                    }
                    else if (type == 2)
                    {
                        SqlWhere = f8 + t2;
                    }
                    else if (type == 3)
                    {
                        SqlWhere = f8 + t3;
                    }
                    break;
                case 9:
                    if (type == 0)
                    {
                        SqlWhere = f9 + t0;
                    }
                    else if (type == 1)
                    {
                        SqlWhere = f9 + t1;
                    }
                    else if (type == 2)
                    {
                        SqlWhere = f9 + t2;
                    }
                    else if (type == 3)
                    {
                        SqlWhere = f9 + t3;
                    }
                    break;
                default:
                    SqlWhere = "and (b.inpatientid_chr = ? or d.patientcardid_chr = ?)";
                    break;
            }

            string SubTab = "";
            if (type == 3)
            {
                SubTab = @"t_opr_bih_register b, ";
            }
            else
            {
                SubTab = @"(select tb1.registerid_chr, tb1.modify_dat, tb1.patientid_chr,
                                   tb1.isbooking_int, tb1.inpatientid_chr, tb1.inpatient_dat,
                                   tb1.deptid_chr, tb1.areaid_chr, tb1.bedid_chr, tb1.type_int,
                                   tb1.diagnose_vchr, tb1.limitrate_mny, tb1.inpatientcount_int,
                                   tb1.state_int, tb1.status_int, tb1.operatorid_chr, tb1.pstatus_int,
                                   tb1.casedoctor_chr, tb1.inpatientnotype_int, tb1.des_vchr,
                                   tb1.inareadate_dat, tb1.mzdoctor_chr, tb1.mzdiagnose_vchr,
                                   tb1.diagnoseid_chr, tb1.icd10diagid_vchr, tb1.icd10diagtext_vchr,
                                   tb1.isfromclinic, tb1.clinicsayprepay, tb1.paytypeid_chr,
                                   tb1.bornnum_int, tb1.relateregisterid_chr, tb1.feestatus_int,
                                   tb1.extendid_vchr, tb1.nursing_class, tb1.casedoctordept_chr,
                                   tb1.cancelerid_chr, tb1.cancel_dat, tb1.outdiagnose_vchr,
                                   tb1.insuredsum_mny, tb1.checkstatus_int 
                             from t_opr_bih_register tb1
                            where exists (select 1
                                            from (select max(tb2.registerid_chr) as registerid_chr
                                                    from t_opr_bih_register tb2
                                                   group by tb2.inpatientid_chr) tb2
                                           where tb1.registerid_chr = tb2.registerid_chr)
                          ) b, ";
            }

            string SQL = @"select b.areaid_chr, e.deptname_vchr, b.inpatientid_chr, b.inpatientcount_int, a.bedid_chr, a.code_chr, b.patientid_chr, 
                                  c.lastname_vchr, c.sex_chr, c.birth_dat, to_char(b.inpatient_dat,'yyyy-mm-dd hh24:mi:ss') as rysj, b.pstatus_int, b.feestatus_int, 
                                  c.idcard_chr, c.homeaddress_vchr, b.inpatientnotype_int, b.registerid_chr, to_char(t1.outhospital_dat, 'yyyy-mm-dd hh24:mi:ss') as cysj,
                                  t2.deptname_vchr as cybq, t3.code_chr as cybc, d.patientcardid_chr, b.paytypeid_chr, f.paytypename_vchr, (to_date(to_char(nvl(t1.outhospital_dat, sysdate), 'yyyy-mm-dd'), 'yyyy-mm-dd') - to_date(to_char(b.inpatient_dat,'yyyy-mm-dd'), 'yyyy-mm-dd')) indays, 
                                  b.des_vchr as note, t1.diagnose_vchr, t4.remarkname_vchr, nvl(t4.chargectl_int, 0) as SpecChargeCtrl, b.casedoctor_chr as doctorid, g.lastname_vchr as doctorname, 
                                  c.insuredtotalmoney_mny, c.insuredpaymoney_mny, c.insuredpaytime_int, c.insuredpayscale_dec, t5.idno_vchr, b.insuredsum_mny as ybsum, b.checkstatus_int        
                             from t_bse_bed a, " + SubTab + @"
                                  t_opr_bih_registerdetail c, 
                                  t_bse_patientcard d, t_bse_deptdesc e, t_bse_patientpaytype f, t_bse_employee g,                                    
                                  (select registerid_chr, outareaid_chr, outbedid_chr, outhospital_dat, diagnose_vchr from t_opr_bih_leave where status_int = 1) t1, t_bse_deptdesc t2, t_bse_bed t3, 
                                  (select registerid_chr, remarkname_vchr, chargectl_int from t_opr_bih_patspecremark where status_int = 1) t4,
                                  t_bse_patientidentityno t5  
                            where b.registerid_chr = a.bihregisterid_chr[rjion] 
                              and b.registerid_chr = c.registerid_chr  
                              and b.bedid_chr = a.bedid_chr(+)                              
                              and b.patientid_chr = d.patientid_chr(+)
                              and b.areaid_chr = e.deptid_chr(+)
                              and b.status_int = 1                               
                              and b.paytypeid_chr = f.paytypeid_chr(+) 
                              and b.casedoctor_chr = g.empid_chr(+) 
                              and b.registerid_chr = t1.registerid_chr(+) 
                              and t1.outareaid_chr = t2.deptid_chr(+)
                              and t1.outbedid_chr = t3.bedid_chr(+) 
                              and b.registerid_chr = t4.registerid_chr(+) 
                              and b.patientid_chr = t5.patientid_chr(+)
                              and b.paytypeid_chr = t5.paytypeid_chr(+) ";

            SQL += SqlWhere;

            if (flag == 1)
            {
                SQL = SQL.Replace("[rjion]", "");
            }
            else
            {
                SQL = SQL.Replace("[rjion]", "(+)");
            }

            dt = new DataTable();

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 查找出院病人床号
        /// <summary>
        /// 查找出院病人床号
        /// </summary>
        /// <param name="no"></param>
        /// <param name="type"></param>
        /// <param name="p_strBedNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDedNo(string no, ref string p_strBedNo)
        {
            long lngRes = 0;

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = no;

            string strSQL = @"select b.code_chr
                                from t_opr_bih_register a, 
                                     t_bse_bed b
                               where a.bedid_chr = b.bedid_chr
                                 and a.registerid_chr = ?  and a.pstatus_int=3";
            try
            {
                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);

                if (dt.Rows.Count > 0)
                {
                    p_strBedNo = dt.Rows[0]["code_chr"].ToString();
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

        #region 通用查找窗口用
        /// <summary>
        /// 通用查找窗口用
        /// </summary>
        /// <param name="SqlWhereZY"></param>
        /// <param name="Status">0 全部 1 在院 2 预出院 3 正式出院 4 请假 8 出院结算 9 预交款类型</param>
        /// <param name="IsIncludeMZ">true 包含门诊 false 不包含门诊</param>
        /// <param name="SqlWhereMZ"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientinfo(string SqlWhereZY, int Status, bool IsIncludeMZ, string SqlWhereMZ, clsCommonQueryDate_VO CommonQueryDate_VO, out DataTable dt)
        {
            long lngRes = 0;
            string subSql = " ";

            if (Status == 1)
            {
                subSql = @" and (a.pstatus_int = 0 or a.pstatus_int = 1 or a.pstatus_int = 4) ";
            }
            else if (Status == 2)
            {
                subSql = @" and a.pstatus_int = 2";
            }
            else if (Status == 3)
            {
                subSql = @" and a.pstatus_int = 3";
            }
            else if (Status == 8)
            {
                subSql = @" and (a.pstatus_int = 2 or a.pstatus_int = 3)";
            }
            else if (Status == 9)
            {
                subSql = @" and (a.pstatus_int = 0 or a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = 4) ";
            }

            #region 处理日期类型查询
            string InDateSql = "";
            string OutDateSql = "";
            string OutSign = "(+)";
            if (CommonQueryDate_VO != null)
            {
                if (CommonQueryDate_VO.QueryType == 1 || CommonQueryDate_VO.QueryType == 3)
                {
                    InDateSql = " and (a.inpatient_dat between to_date('" + CommonQueryDate_VO.BeginDate_In + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + CommonQueryDate_VO.EndDate_In + "', 'yyyy-mm-dd hh24:mi:ss')) ";
                }

                if (CommonQueryDate_VO.QueryType == 2 || CommonQueryDate_VO.QueryType == 3)
                {
                    OutDateSql = " and (outhospital_dat between to_date('" + CommonQueryDate_VO.BeginDate_Out + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + CommonQueryDate_VO.EndDate_Out + "', 'yyyy-mm-dd hh24:mi:ss')) ";
                    OutSign = "";
                }
            }
            #endregion

            string SQL = @" select a.registerid_chr, a.patientid_chr, a.inpatientid_chr, a.pstatus_int, a.inpatientcount_int, a.feestatus_int, 
                                   b.lastname_vchr, b.sex_chr, b.birth_dat, to_char(b.birth_dat, 'yyyy/mm/dd') as cssj,
                                   b.idcard_chr, to_char(a.inpatient_dat, 'yyyy/mm/dd hh24:mi:ss') as rysj, e.deptname_vchr, d.code_chr,
                                   to_char(c.outhospital_dat, 'yyyy/mm/dd hh24:mi:ss') as cysj, a.inpatientnotype_int, b.homeaddress_vchr, b.employer_vchr, f.patientcardid_chr  
                              from t_opr_bih_register a,
                                   t_opr_bih_registerdetail b,
                                   (select registerid_chr, 
                                           outhospital_dat 
                                      from t_opr_bih_leave 
                                     where status_int = 1 " + OutDateSql + @") c,
                                   t_bse_bed d,
                                   t_bse_deptdesc e,
                                   t_bse_patientcard f
                             where a.registerid_chr = b.registerid_chr
                               and a.patientid_chr = f.patientid_chr(+)
                               and a.status_int = 1                                   
                               and a.registerid_chr = c.registerid_chr " + OutSign + @" 
                               and a.registerid_chr = d.bihregisterid_chr(+)
                               and a.bedid_chr = d.bedid_chr(+)
                               and d.areaid_chr = e.deptid_chr(+) " + SqlWhereZY + subSql + InDateSql + " order by a.patientid_chr, a.inpatient_dat";

            if (IsIncludeMZ)
            {
                SQL = "select * from (" + SQL + @") ta 
                       union all
                       select * from ( 
                                       select '' as registerid_chr, b.patientid_chr, '' as inpatientid_chr, 999 as pstatus_int, 0 as inpatientcount_int, 0 as feestatus_int,
                                              b.lastname_vchr, b.sex_chr, b.birth_dat, to_char(b.birth_dat, 'yyyy/mm/dd') as cssj,
                                              b.idcard_chr, '' as rysj, '' as deptname_vchr, '' as code_chr,
                                              '' as cysj, 0 as inpatientnotype_int, b.homeaddress_vchr, b.employer_vchr, f.patientcardid_chr  
                                         from t_bse_patient b,
                                              t_bse_patientcard f
                                        where b.patientid_chr = f.patientid_chr 
                                          and not exists (
                                                            select 1
                                                              from t_opr_bih_register tr     
                                                             where b.patientid_chr = tr.patientid_chr           
                                                         ) 
                                          and " + SqlWhereMZ + " order by b.patientid_chr) tb "; ;
            }

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 获取频率列表
        /// <summary>
        /// 获取频率列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsageInfo(out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.usageid_chr, a.usagename_vchr, a.usercode_chr, 
                                  a.scope_int, a.putmed_int, a.test_int                                                 
                             from t_bse_usagetype a
                            order by a.scope_int, a.usercode_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 获取用法带出收费项目信息
        /// <summary>
        /// 获取用法带出收费项目信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PatType">病人身份</param>
        /// <param name="ApplyAreaID">开单病区ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUsageAddItem(out DataTable dt, string PatType, string ApplyAreaID)
        {
            long lngRes = 0;

            string SQL = @"select a.usageid_chr, a.bihqty_dec as amount, c.noqtyflag_int, 
                                  b.itemid_chr, b.itemname_vchr, b.itemcode_vchr, b.itempycode_chr,
                                  b.itemwbcode_chr, b.itemsrcid_vchr, b.itemsrctype_int, b.itemspec_vchr,
                                  b.itemprice_mny, b.itemunit_chr, b.itemopunit_chr, b.itemipunit_chr,
                                  b.itemopcalctype_chr, b.itemipcalctype_chr, b.itemopinvtype_chr,
                                  b.itemipinvtype_chr, b.dosage_dec, b.dosageunit_chr, b.isgroupitem_int,
                                  b.itemcatid_chr, b.usageid_chr, b.itemopcode_chr, b.insuranceid_chr,
                                  b.selfdefine_int, b.packqty_dec, b.tradeprice_mny, b.poflag_int,
                                  b.isrich_int, b.opchargeflg_int, b.itemsrcname_vchr,
                                  b.itemsrctypename_vchr, b.itemengname_vchr, b.ifstop_int,
                                  b.pdcarea_vchr, b.ipchargeflg_int, b.insurancetype_vchr,
                                  b.apply_type_int, b.itembihctype_chr, b.defaultpart_vchr,
                                  b.itemchecktype_chr, b.itemcommname_vchr, b.ordercateid_chr,
                                  b.freqid_chr, b.inpinsurancetype_vchr, b.ordercateid1_chr,
                                  b.isselfpay_chr, b.itemprice_mny_old, b.itemprice_mny_new,
                                  b.keepuse_int, b.itemspec_vchr1,
                                  round (b.itemprice_mny / b.packqty_dec,4) as submoney,
                                  d.precent_dec, e.areaid1, e.areaid2   
                              from t_bse_chargeitemusagegroup a,
                                   t_bse_chargeitem b,
	                               t_bse_medicine c,
                                   (select itemid_chr, precent_dec from t_aid_inschargeitem where copayid_chr = ?) d, 
                                   (
                                       select a.itemid_chr, min(nvl(b.clacarea_chr, '')) as areaid1, min(nvl(c.clacarea_chr, '')) as areaid2 
                                         from t_bse_chargeitem a,
                                              (select ordercateid_chr, clacarea_chr from t_aid_bih_ocdeptdefault where createarea_chr = ?) b,
                                              t_aid_bih_ocdeptlist c,
                                              t_bse_chargeitemusagegroup d  
                                        where a.ordercateid_chr = b.ordercateid_chr(+)                                                 
                                          and a.ordercateid_chr = c.ordercateid_chr(+)
                                          and a.itemid_chr = d.itemid_chr                 
                                     group by a.itemid_chr
                                   ) e         
                             where a.itemid_chr = b.itemid_chr 
                               and b.itemsrcid_vchr = c.medicineid_chr(+) 
                               and b.itemid_chr = d.itemid_chr(+) 
                               and a.itemid_chr = e.itemid_chr   
                               and a.bihtype_int = 1 
                          order by b.itemcode_vchr ";

            dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PatType;
                ParamArr[1].Value = ApplyAreaID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 获取收费组合主信息
        /// <summary>
        /// 获取收费组合主信息
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetItemGroup(string OperID, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.recipeid_chr, a.recipename_chr, a.usercode_chr, a.pycode_chr,
                                   a.wbcode_chr, a.diseasename_vchr, a.privilege_int
                              from t_aid_concertrecipe a
                             where a.flag_int = 1 and a.privilege_int = 0 and a.status_int = 1
                            union all
                            select a.recipeid_chr, a.recipename_chr, a.usercode_chr, a.pycode_chr,
                                   a.wbcode_chr, a.diseasename_vchr, a.privilege_int
                              from t_aid_concertrecipe a
                             where a.flag_int = 1
                               and a.privilege_int = 1
                               and a.status_int = 1
                               and a.createrid_chr = ?
                            union all
                            select a.recipeid_chr, a.recipename_chr, a.usercode_chr, a.pycode_chr,
                                   a.wbcode_chr, a.diseasename_vchr, a.privilege_int 
                              from t_aid_concertrecipe a,
                                   (select a.recipeid_chr
                                      from t_aid_concertrecipedept a
                                     where exists (select 1
                                                     from t_bse_deptemp b
                                                    where a.deptid_chr = b.deptid_chr and b.empid_chr = ?)) b
                             where a.flag_int = 1
                               and a.privilege_int = 2
                               and a.status_int = 1
                               and a.recipeid_chr = b.recipeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = OperID;
                ParamArr[1].Value = OperID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 获取收费组合明细
        /// <summary>
        /// 获取收费组合明细
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PatType"></param>
        /// <param name="ApplyAreaID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetItemGroupDet(out DataTable dt, string PatType, string ApplyAreaID)
        {
            long lngRes = 0;

            string SQL = @"select a.recipeid_chr, a.qty_dec as amount, c.noqtyflag_int, 
                                  b.itemid_chr, b.itemname_vchr, b.itemcode_vchr, b.itempycode_chr,
                                  b.itemwbcode_chr, b.itemsrcid_vchr, b.itemsrctype_int, b.itemspec_vchr,
                                  b.itemprice_mny, b.itemunit_chr, b.itemopunit_chr, b.itemipunit_chr,
                                  b.itemopcalctype_chr, b.itemipcalctype_chr, b.itemopinvtype_chr,
                                  b.itemipinvtype_chr, b.dosage_dec, b.dosageunit_chr, b.isgroupitem_int,
                                  b.itemcatid_chr, b.usageid_chr, b.itemopcode_chr, b.insuranceid_chr,
                                  b.selfdefine_int, b.packqty_dec, b.tradeprice_mny, b.poflag_int,
                                  b.isrich_int, b.opchargeflg_int, b.itemsrcname_vchr,
                                  b.itemsrctypename_vchr, b.itemengname_vchr, b.ifstop_int,
                                  b.pdcarea_vchr, b.ipchargeflg_int, b.insurancetype_vchr,
                                  b.apply_type_int, b.itembihctype_chr, b.defaultpart_vchr,
                                  b.itemchecktype_chr, b.itemcommname_vchr, b.ordercateid_chr,
                                  b.freqid_chr, b.inpinsurancetype_vchr, b.ordercateid1_chr,
                                  b.isselfpay_chr, b.itemprice_mny_old, b.itemprice_mny_new,
                                  b.keepuse_int, b.itemspec_vchr1,
                                  round (b.itemprice_mny / b.packqty_dec,4) as submoney,
                                  d.precent_dec, e.areaid1, e.areaid2   
                              from t_aid_concertrecipedetail a,
                                   t_bse_chargeitem b,
	                               t_bse_medicine c,
                                   (select itemid_chr, precent_dec from t_aid_inschargeitem where copayid_chr = ?) d, 
                                   (
                                       select a.itemid_chr, min(nvl(b.clacarea_chr, '')) as areaid1, min(nvl(c.clacarea_chr, '')) as areaid2 
                                         from t_bse_chargeitem a,
                                              (select ordercateid_chr, clacarea_chr from t_aid_bih_ocdeptdefault where createarea_chr = ?) b,
                                              t_aid_bih_ocdeptlist c,
                                              t_bse_chargeitemusagegroup d  
                                        where a.ordercateid_chr = b.ordercateid_chr(+)                                                 
                                          and a.ordercateid_chr = c.ordercateid_chr(+)
                                          and a.itemid_chr = d.itemid_chr                 
                                     group by a.itemid_chr
                                   ) e         
                             where a.itemid_chr = b.itemid_chr 
                               and b.itemsrcid_vchr = c.medicineid_chr(+) 
                               and b.itemid_chr = d.itemid_chr(+) 
                               and a.itemid_chr = e.itemid_chr                                
                          order by b.itemcode_vchr ";

            dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PatType;
                ParamArr[1].Value = ApplyAreaID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 查找诊疗项目
        /// <summary>
        /// 查找诊疗项目
        /// </summary>
        /// <param name="ID"></param>        
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindOrderByID(string ID, out DataTable dt, bool isChildPrice)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @" select a.orderdicid_chr, a.name_chr, a.des_vchr, a.usercode_chr, a.wbcode_chr,
                                           a.pycode_chr, a.execdept_chr, a.ordercateid_chr, a.itemid_chr,
                                           a.nullitemdosageunit_chr, a.nullitemuseunit_chr,
                                           a.nullitemdosetypeid_chr, a.status_int, a.sampleid_vchr, a.partid_vchr,
                                           a.engname_vchr, a.commname_vchr, a.nullitemfreqid_vchr,
                                           a.nullitemuse_dec, a.lisapplyunitid_chr, a.applytypeid_chr,
                                           a.newchargetype_int, f.buyprice_dec, 
                                           e.totalmny, f.itemipinvtype_chr, f.ipnoqtyflag_int, f.ybtypename, f.itemunit, f.itemspec_vchr,f.noqtyflag_int,f.drugstoreid_chr   
                                      from t_bse_bih_orderdic a, 
                                           (
	   	                                    select a.orderdicid_chr, sum(round(b.qty_int * (case c.ipchargeflg_int when 1 then {0} else {1} end), 2)) as totalmny
		   	                                  from t_bse_bih_orderdic a,
       		                                       t_aid_bih_orderdic_charge b,
       		                                       t_bse_chargeitem c
       	                                     where a.orderdicid_chr = b.orderdicid_chr
		                                       and b.itemid_chr = c.itemid_chr 
                                               and a.status_int = 1 
		                                       and c.ifstop_int = 0	
	                                        group by a.orderdicid_chr	   
	                                       ) e,
                                           (
                                            select a.orderdicid_chr,
                                                   c.itemipinvtype_chr,
                                                   d.ipnoqtyflag_int,
                                                   --d.tradeprice_mny as buyprice_dec, 
                                                   decode(d.ipchargeflg_int,1,round (d.tradeprice_mny / d.packqty_dec,4), 0, d.tradeprice_mny) as buyprice_dec, 
                                                   e.typename_vchr as ybtypename,
                                                   (case c.ipchargeflg_int
                                                   when 1 then
                                                   c.itemipunit_chr
                                                   else
                                                   c.itemunit_chr
                                                   end) as itemunit,
                                                   c.itemspec_vchr,
                                                   '' noqtyflag_int,
                                                   '' drugstoreid_chr
                                            from t_bse_bih_orderdic a,
                                                   t_bse_chargeitem   c,
                                                   t_bse_medicine     d,
                                                   --t_ds_storage       h,
                                                   t_aid_medicaretype e
                                            where a.itemid_chr = c.itemid_chr  
                                              and trim(c.itemsrcid_vchr) = trim(d.medicineid_chr(+))      
                                              and c.inpinsurancetype_vchr = e.typeid_chr(+) 
                                              --and d.medicineid_chr=h.medicineid_chr(+)     
                                              and a.status_int = 1                                                
                                              and c.ifstop_int = 0 
                                           ) f     
                                     where a.orderdicid_chr = e.orderdicid_chr 
                                       and a.orderdicid_chr = f.orderdicid_chr                                             
                                       and ((a.orderdicid_chr like ?) or (lower(a.pycode_chr) like ?) or (lower(a.wbcode_chr) like ?)
                                            or ((lower(a.usercode_chr) like ?)) or (a.name_chr || a.commname_vchr like ?)) 
                                 order by a.usercode_chr ";

                if (isChildPrice)
                    strSQL = string.Format(strSQL, "(case c.ischildprice when 1 then round(c.itemprice_mny * " + EntityChildPrice.AddScale + " / c.packqty_dec, 4) else round(c.itemprice_mny / c.packqty_dec, 4) end)", "(case c.ischildprice when 1 then (c.itemprice_mny * " + EntityChildPrice.AddScale + ") else c.itemprice_mny end)");
                else
                    strSQL = string.Format(strSQL, "round(c.itemprice_mny / c.packqty_dec, 4)", "c.itemprice_mny");

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ParamArr[0].Value = ID.ToLower() + "%";
                ParamArr[1].Value = ID.ToLower() + "%";
                ParamArr[2].Value = ID.ToLower() + "%";
                ParamArr[3].Value = ID.ToLower() + "%";
                ParamArr[4].Value = ID.ToLower() + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据诊疗项目获取收费项目
        /// <summary>
        /// 根据诊疗项目获取收费项目
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemByOrderID(string OrderID, string PayTypeID, out DataTable dt, bool isChildPrice)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @" select c.itemid_chr, c.itemname_vchr, c.itemcode_vchr, c.itempycode_chr,
                                           c.itemwbcode_chr, c.itemsrcid_vchr, c.itemsrctype_int, c.itemspec_vchr,
                                           {0}, c.itemunit_chr, c.itemopunit_chr, c.itemipunit_chr,
                                           c.itemopcalctype_chr, c.itemipcalctype_chr, c.itemopinvtype_chr,
                                           c.itemipinvtype_chr, c.dosage_dec, c.dosageunit_chr, c.isgroupitem_int,
                                           c.itemcatid_chr, c.usageid_chr, c.itemopcode_chr, c.insuranceid_chr,
                                           c.selfdefine_int, c.packqty_dec, c.tradeprice_mny, c.poflag_int,
                                           c.isrich_int, c.opchargeflg_int, c.itemsrcname_vchr,
                                           c.itemsrctypename_vchr, c.itemengname_vchr, c.ifstop_int,
                                           c.pdcarea_vchr, c.ipchargeflg_int, c.insurancetype_vchr,
                                           c.apply_type_int, c.itembihctype_chr, c.defaultpart_vchr,
                                           c.itemchecktype_chr, c.itemcommname_vchr, c.ordercateid_chr,
                                           c.freqid_chr, c.inpinsurancetype_vchr, c.ordercateid1_chr,
                                           c.isselfpay_chr, c.itemprice_mny_old, c.itemprice_mny_new,
                                           c.keepuse_int, c.itemspec_vchr1, 
                                           c.itemname_vchr as itemname, b.qty_int as totalqty_dec, b.usescope_int, 
                                           d.precent_dec, {1}, e.putmedtype_int,
                                           decode(e.ipchargeflg_int,1,round ((e.unitprice_mny - e.tradeprice_mny) / e.packqty_dec,4),
                                                                    0,round (e.unitprice_mny - e.tradeprice_mny,4)) as diffprice_mny,e.medicinetypeid_chr, 
                                           decode(e.ipchargeflg_int,1,round (e.tradeprice_mny / e.packqty_dec,4), 0, e.tradeprice_mny) as buyprice_dec   
                                      from t_bse_bih_orderdic a,
                                           t_aid_bih_orderdic_charge b,
                                           t_bse_chargeitem c,                                         
                                           (select precent_dec, itemid_chr, copayid_chr from t_aid_inschargeitem where copayid_chr = ?) d, 
                                           t_bse_medicine e      
                                     where a.orderdicid_chr = b.orderdicid_chr 
                                       and b.itemid_chr = c.itemid_chr                                        
                                       and c.itemid_chr = d.itemid_chr(+) 
                                       and c.itemsrcid_vchr = e.medicineid_chr(+) 
                                       and a.status_int = 1   
                                       and c.ifstop_int = 0                                     
                                       and a.orderdicid_chr = ? 
                                  order by c.itemname_vchr ";

                if (isChildPrice)
                    strSQL = string.Format(strSQL, "(case c.ischildprice when 1 then (c.itemprice_mny * " + EntityChildPrice.AddScale + ") else c.itemprice_mny end) as itemprice_mny", "(case c.ischildprice when 1 then round(c.itemprice_mny * " + EntityChildPrice.AddScale + " / c.packqty_dec, 4) else round(c.itemprice_mny / c.packqty_dec, 4) end) as submoney");
                else
                    strSQL = string.Format(strSQL, "c.itemprice_mny", "round(c.itemprice_mny / c.packqty_dec, 4) as submoney");  

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PayTypeID;
                ParamArr[1].Value = OrderID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 判断诊疗项目(组合)是否允许打折
        /// <summary>
        /// 判断诊疗项目(组合)是否允许打折
        /// </summary>
        /// <param name="OrderID">诊疗项目ID</param>
        /// <param name="InvoCatArr">发票类型数组</param>
        /// <param name="SysType">系统 1 门诊 2 住院</param>
        /// <param name="ItemNums">项目个数</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckOrderDiscount(string OrderID, ArrayList InvoCatArr, int SysType, int ItemNums)
        {
            long lngRes = 0;
            bool blnRet = false;
            DataTable dt = new DataTable();

            string SubStr = "";

            if (InvoCatArr != null && InvoCatArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < InvoCatArr.Count; i++)
                {
                    if (SysType == 1)
                    {
                        str += "c.itemopinvtype_chr = '" + InvoCatArr[i].ToString() + "' or ";
                    }
                    else if (SysType == 2)
                    {
                        str += "c.itemipinvtype_chr = '" + InvoCatArr[i].ToString() + "' or ";
                    }
                }

                str = str.Trim();
                SubStr = " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            if (SysType == 1)
            {
                SubStr += " group by c.itemopinvtype_chr ";
            }
            else if (SysType == 2)
            {
                SubStr += " group by c.itemipinvtype_chr ";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @"select count(b.itemid_chr)
                                    from t_bse_bih_orderdic a,
                                         t_aid_bih_orderdic_charge b,
                                         t_bse_chargeitem c
                                    where a.orderdicid_chr = b.orderdicid_chr 
                                      and b.itemid_chr = c.itemid_chr 
                                      and a.status_int = 1    
                                      and a.orderdicid_chr = ? " + SubStr + @"                                     
                                    having count(b.itemid_chr) > ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = OrderID;
                ParamArr[1].Value = ItemNums;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    int count = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() != "0")
                        {
                            count += int.Parse(dt.Rows[i][0].ToString());
                        }
                    }
                    if (count > 0)
                    {
                        blnRet = true;
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnRet;
        }
        #endregion

        #region 获取全院当前在院病人清单
        /// <summary>
        /// 获取全院当前在院病人清单
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihPatient(out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                string SQL = @" select a.registerid_chr, a.paytypeid_chr, a.inpatientid_chr AS zyh,
                                       (b.insuredpaytime_int + 1) AS zycs, b.lastname_vchr,
                                       a.inpatientcount_int, c.deptname_vchr, d.bed_no
                                  from t_opr_bih_register a,
                                       t_opr_bih_registerdetail b,
                                       t_bse_deptdesc c,
                                       t_bse_bed d
                                 where a.registerid_chr = b.registerid_chr 
                                   and a.status_int = 1  
                                   and a.pstatus_int <> 3 
                                   and a.areaid_chr = c.deptid_chr
                                   and a.bedid_chr = d.bedid_chr";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 检查婴儿费
        /// <summary>
        /// 检查婴儿费
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckBaby(string Zyh, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @" select a.inpatientid_chr, b.lastname_vchr, b.sex_chr
                              from t_opr_bih_register a, t_opr_bih_registerdetail b
                             where a.pstatus_int <> 3
                               and a.registerid_chr = b.registerid_chr
                               and (a.inpatientid_chr <> ? and instr (a.inpatientid_chr, ?) > 0)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Zyh;
                ParamArr[1].Value = Zyh;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 根据住院号获取病人基本资料
        /// <summary>
        /// 根据住院号获取病人基本资料
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientinfoByZyh(string Zyh, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @" select a.registerid_chr, a.inpatientid_chr, 
                                   a.inpatientcount_int, b.lastname_vchr
                              from t_opr_bih_register a,
                                   t_opr_bih_registerdetail b
                             where a.registerid_chr = b.registerid_chr
                               and a.status_int = 1
                               and a.inpatientid_chr = ? 
                          order by a.inpatientcount_int ";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = Zyh;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 获取医嘱类型
        /// <summary>
        /// 获取医嘱类型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderCate(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.ordercateid_chr, a.name_chr from t_aid_bih_ordercate a order by a.orderseq_int";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 查询此病人是否用门诊处方未结费用
        /// <summary>
        ///  查询此病人是否用门诊处方未结费用
        /// </summary>
        /// <param name="p_strRegisterId">病人住院登记号</param>
        /// <param name="p_strMessage">返回病人未交费的处方号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectPatientNoPayRecipe(string p_strRegisterId, out string p_strMessage)
        {
            long lngRes = 0;
            p_strMessage = "";
            string strSQL = @"select t1.outpatrecipeid_chr
  from t_opr_bih_recipenopay t1, t_opr_bih_register t2
 where t2.inpatientid_chr = t1.inpatientid_chr
   and t1.pstatus_int = 4
   and t2.registerid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] parmArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out parmArr);
                parmArr[0].Value = p_strRegisterId;
                DataTable m_dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbResult, parmArr);
                if (lngRes > 0 && m_dtbResult.Rows.Count > 0)
                {
                    p_strMessage = "该病人此处方号未结：\n";
                    int intRowCount = m_dtbResult.Rows.Count;
                    for (int i = 0; i < intRowCount; i++)
                    {
                        p_strMessage += m_dtbResult.Rows[i]["outpatrecipeid_chr"].ToString() + ";\n";
                    }
                }
                m_dtbResult.Dispose();
                m_dtbResult = null;

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
                strSQL = null;
                parmArr = null;
            }
            return lngRes;
        }

        #endregion

        #region 检查项目是否能修改身份类别
        /// <summary>
        /// 检查项目是否能修改身份类别
        /// </summary>
        /// <param name="p_gdicItemIDs"></param>
        /// <param name="p_gdicItemIDResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckChangeSFLB(Dictionary<string, int> p_gdicItemIDs, out Dictionary<string, string> p_gdicItemIDResult)
        {
            long lngRes = -1;
            string strSQL = @"";
            int intMaxNum = 50;
            p_gdicItemIDResult = null;
            try
            {
                int n = 0;
                StringBuilder stb = new StringBuilder(15 * intMaxNum);
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dtTmp = null;
                DataTable dtResult = null;
                foreach (KeyValuePair<string, int> Pair in p_gdicItemIDs)
                {
                    n++;
                    stb.Append("'" + Pair.Key + "',");

                    if (n % intMaxNum == 0)
                    {
                        strSQL = @"select  a.itemid_chr,a.itemchargetype_vchr
                                      from t_bse_chargeitem a
                                     where a.changesflb_int = 1
                                       and a.itemid_chr in (" + stb.ToString().Trim(',') + ")";
                        stb = new StringBuilder(15 * intMaxNum);
                        n = 0;

                        objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTmp);
                        if (dtResult != null)
                        {
                            dtResult.Merge(dtTmp);
                        }
                        else
                        {
                            dtResult = dtTmp.Copy();
                        }
                    }
                }

                if (stb.Length > 0)
                {
                    strSQL = @"select  a.itemid_chr,a.itemchargetype_vchr
                                      from t_bse_chargeitem a
                                     where a.changesflb_int = 1
                                       and a.itemid_chr in (" + stb.ToString().Trim(',') + ")";
                    objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTmp);

                    if (dtResult != null)
                    {
                        dtResult.Merge(dtTmp);
                    }
                    else
                    {
                        dtResult = dtTmp.Copy();
                    }
                }
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (dtResult == null || dtResult.Rows.Count < 1)
                {
                    return lngRes;
                }

                p_gdicItemIDResult = new Dictionary<string, string>(dtResult.Rows.Count);
                foreach (DataRow dr in dtResult.Rows)
                {
                    p_gdicItemIDResult.Add(dr["itemid_chr"].ToString(), dr["itemchargetype_vchr"].ToString());
                }

                dtTmp.Dispose();
                dtResult.Dispose();
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
        /// 取得湛江身份类别
        /// </summary>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSFLB_ForZjwsy(out DataTable dtResult)
        {
            dtResult = null;
            long lngRes = -1;

            try
            {
                string strSQL = "select a.sflbbh, a.sflb from t_bse_bih_csyb_syz a";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                objHRPSvc.Dispose();
                objHRPSvc = null;
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
        /// 检查身份类别
        /// </summary>
        /// <param name="m_glstPChargeID"></param>
        /// <param name="p_gdicItemIDResult"></param>
        /// <param name="p_gdicPatchAmount"></param>
        /// <param name="p_gdicPatchList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientChargeSFLB(List<string> m_glstPChargeID, out Dictionary<string, string> p_gdicItemIDResult,
                                              out Dictionary<string, decimal> p_gdicPatchAmount,
                                              out Dictionary<string, List<string>> p_gdicPatchList)
        {
            long lngRes = -1;
            string strSQL = @"";
            int intMaxNum = 50;
            p_gdicItemIDResult = null;
            p_gdicPatchAmount = null;
            p_gdicPatchList = null;

            try
            {
                int n = 0;
                StringBuilder stb = new StringBuilder(15 * intMaxNum);
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dtTmp = null;
                DataTable dtResult = null;
                foreach (string Pair in m_glstPChargeID)
                {
                    n++;
                    stb.Append("'" + Pair.Trim() + "',");

                    if (n % intMaxNum == 0)
                    {
                        strSQL = @"select  a.itemchargetype_vchr, a.pchargeid_chr
                                      from t_opr_bih_patientcharge a
                                     where a.itemchargetype_vchr is not null
                                     and  a.pchargeid_chr in (" + stb.ToString().Trim(',') + ")";

                        stb = new StringBuilder(15 * intMaxNum);
                        n = 0;

                        objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTmp);
                        if (dtResult != null)
                        {
                            dtResult.Merge(dtTmp);
                        }
                        else
                        {
                            dtResult = dtTmp.Copy();
                        }
                    }
                }

                if (stb.Length > 0)
                {
                    strSQL = @"select  a.itemchargetype_vchr, a.pchargeid_chr
                                      from t_opr_bih_patientcharge a
                                     where a.itemchargetype_vchr is not null
                                     and  a.pchargeid_chr in (" + stb.ToString().Trim(',') + ")";
                    objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTmp);

                    if (dtResult != null)
                    {
                        dtResult.Merge(dtTmp);
                    }
                    else
                    {
                        dtResult = dtTmp.Copy();
                    }
                }

                //if(dtResult == null || dtResult.Rows.Count < 1)
                //{
                //    return lngRes;
                //}
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_gdicItemIDResult = new Dictionary<string, string>(dtResult.Rows.Count);
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        p_gdicItemIDResult.Add(dr["pchargeid_chr"].ToString(), dr["itemchargetype_vchr"].ToString());
                    }
                }
                else
                {
                    p_gdicItemIDResult = new Dictionary<string, string>();
                }

                n = 0;
                stb = new StringBuilder(15 * intMaxNum);
                dtTmp.Dispose();
                dtTmp = null;
                DataTable dtPatch = null;
                foreach (string strPcharge in m_glstPChargeID)
                {
                    n++;
                    stb.Append("'" + strPcharge + "',");
                    if (n % intMaxNum == 0)
                    {
                        strSQL = @"select  a.pchargeidorg_chr, a.pchargeid_chr, a.amount_dec
                                      from t_opr_bih_patientcharge a
                                     where a.pchargeidorg_chr in (" + stb.ToString().Trim(',') + ")";

                        stb = new StringBuilder(15 * intMaxNum);
                        n = 0;

                        objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTmp);
                        if (dtPatch != null)
                        {
                            dtPatch.Merge(dtTmp);
                        }
                        else
                        {
                            dtPatch = dtTmp.Copy();
                        }
                    }
                }

                if (stb.Length > 0)
                {
                    strSQL = @"select  a.pchargeidorg_chr, a.pchargeid_chr, a.amount_dec
                                      from t_opr_bih_patientcharge a
                                     where a.pchargeidorg_chr in (" + stb.ToString().Trim(',') + ")";
                    objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtTmp);

                    if (dtPatch != null)
                    {
                        dtPatch.Merge(dtTmp);
                    }
                    else
                    {
                        dtPatch = dtTmp.Copy();
                    }
                }

                if (dtPatch != null && dtPatch.Rows.Count > 0)
                {
                    p_gdicPatchAmount = new Dictionary<string, decimal>();
                    p_gdicPatchList = new Dictionary<string, List<string>>();
                    foreach (DataRow dr in dtPatch.Rows)
                    {
                        if (p_gdicPatchAmount.ContainsKey(dr["pchargeidorg_chr"].ToString()))
                        {
                            p_gdicPatchAmount[dr["pchargeidorg_chr"].ToString()] += Convert.ToDecimal(dr["amount_dec"]);
                            p_gdicPatchList[dr["pchargeidorg_chr"].ToString()].Add(dr["pchargeid_chr"].ToString());
                        }
                        else
                        {
                            p_gdicPatchAmount.Add(dr["pchargeidorg_chr"].ToString(), Convert.ToDecimal(dr["amount_dec"]));
                            List<string> m_glstPChargeID2 = new List<string>();
                            m_glstPChargeID2.Add(dr["pchargeid_chr"].ToString());
                            p_gdicPatchList.Add(dr["pchargeidorg_chr"].ToString(), m_glstPChargeID2);
                        }
                    }
                }

                objHRPSvc.Dispose();
                objHRPSvc = null;
                dtTmp.Dispose();
                dtResult.Dispose();
                dtPatch.Dispose();
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
        public long m_lngGetPatientPayTypeSFLBBH(string p_strPayType, out string p_strPayNo)
        {
            p_strPayNo = string.Empty;
            long lngRes = -1;

            try
            {
                string strSQL = "select a.paytypeno_vchr from t_bse_patientpaytype  a where a.paytypeid_chr = ?";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = p_strPayType;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);

                objHRPSvc.Dispose();
                objHRPSvc = null;

                p_strPayNo = dtResult.Rows[0][0].ToString();
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

        #region 项目适应症
        //        /// <summary>
        //        /// 取项目适应症
        //        /// </summary>
        //        /// <param name="strRegID"></param>
        //        /// <param name="dtResult"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetItemShiying(string strRegID,out DataTable dtResult)
        //        {
        //            long lngRes = 0;
        //            dtResult = new DataTable ();
        //            string strSQL = @"select a.amount_dec,
        //                                   a.itemchargetype_vchr,
        //                                   b.itemcode_vchr,
        //                                   b.itemname_vchr,
        //                                   a.active_dat
        //                              from t_opr_bih_patientcharge a, t_bse_chargeitem b, t_bse_shiying c
        //                             where a.chargeitemid_chr = b.itemid_chr
        //                               and b.itemcode_vchr = c.itemcode_vchr
        //                               and a.registerid_chr = ?";
        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //            IDataParameter[] paraArr = null;
        //            objHRPSvc.CreateDatabaseParameter(1, out paraArr);
        //            paraArr[0].Value = strRegID;
        //            try
        //            {
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, paraArr);
        //            }
        //            catch (Exception objEx)
        //            {
        //                string strTmp = objEx.Message;
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        #endregion

        #region 通过流水号查询手术或麻醉的补充记账记录
        /// <summary>
        /// 通过流水号查询手术或麻醉的补充记账记录
        /// </summary>
        /// <param name="p_strIpno"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryOpExtraChargeByRgno(string p_strIpno, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;

            string strSQL = @"select a.chargeitemname_chr,
       a.unit_vchr,
       a.amount_dec,
       a.invcateid_chr,
       a.totalmoney_dec,
       b.itemspec_vchr,
       c.usagename_vchr
  from t_opr_bih_patientcharge a, t_bse_chargeitem b, t_bse_usagetype c
 where a.chargeitemid_chr = b.itemid_chr
   and b.usageid_chr = c.usageid_chr(+)
   and a.orderexectype_int = 9
   and a.createarea_chr in (select s.parmvalue_vchr
                            from t_bse_sysparm s
                           where s.parmcode_chr = '4001'
                              or s.parmcode_chr = '4002')
   and a.registerid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strIpno;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, ParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 通过流水号查询手术和麻醉信息
        /// <summary>
        /// 通过流水号查询手术和麻醉信息
        /// </summary>
        /// <param name="p_strIpno"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQuerySMDetailByRgno(string p_strRgno, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;

            string strSQL1 = @"select t.operationname_chr, t.anamode_chr, t.anatime
  from t_opr_bih_requisitionmr t
 where t.status_int = 1
   and t.registerid_chr = ? ";

            string strSQL2 = @"select t.operationname_chr, t.anamode_chr, t.anatime
  from t_ana_requisition t
 where t.status_int >= 0
 and t.registerid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr1 = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr1);
                ParamArr1[0].Value = p_strRgno;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtResult, ParamArr1);
                if (p_dtResult != null && p_dtResult.Rows.Count != 0)
                {
                    return lngRes;
                }
                else
                {
                    p_dtResult = null;
                    IDataParameter[] ParamArr2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr2);
                    ParamArr2[0].Value = p_strRgno;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref p_dtResult, ParamArr2);
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更新手术申请单修改表
        /// <summary>
        /// 更新手术申请单修改表
        /// </summary>
        /// <param name="p_strRgno"></param>
        /// <param name="p_strOpreationName"></param>
        /// <param name="p_strANAName"></param>
        /// <param name="p_strANADate"></param>
        /// <param name="p_strEmployID"></param>
        /// <param name="p_strEmployName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateRequisitionMR(string p_strRgno, string p_strOpreationName, string p_strANAName, string p_strANADate, string p_strEmployID, string p_strEmployName)
        {
            long lngRes = 0;

            string strSQL1 = @"select t.registerid_chr
  from t_opr_bih_requisitionmr t
 where t.registerid_chr = ?";

            string strSQL2 = @"update t_opr_bih_requisitionmr set status_int = -1 where registerid_chr = ?";

            string strSQL3 = @"insert into t_opr_bih_requisitionmr (registerid_chr,
                                                                    operationname_chr,
                                                                    anatime,
                                                                    anamode_chr,
                                                                    empid_chr,
                                                                    lastname_vchr,
                                                                    modifydate_dat,
                                                                    status_int
                                                                   )
                                                            values
                                                              ( ?, ?, ?, ?, ?, ?, to_date( ?, 'yyyy-mm-dd hh24:mi:ss'), ?)";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr1 = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr1);
                ParamArr1[0].Value = p_strRgno;
                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtResult, ParamArr1);
                if (dtResult != null && dtResult.Rows.Count != 0)
                {
                    IDataParameter[] ParamArr2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr2);
                    ParamArr2[0].Value = p_strRgno;
                    objHRPSvc.lngExecuteParameterSQL(strSQL2, ref lngRes, ParamArr2);
                }
                IDataParameter[] ParamArr3 = null;
                objHRPSvc.CreateDatabaseParameter(8, out ParamArr3);
                ParamArr3[0].Value = p_strRgno;
                ParamArr3[1].Value = p_strOpreationName;
                ParamArr3[2].Value = p_strANADate;
                ParamArr3[3].Value = p_strANAName;
                ParamArr3[4].Value = p_strEmployID;
                ParamArr3[5].Value = p_strEmployName;
                ParamArr3[6].Value = DateTime.Now.ToString();
                ParamArr3[7].Value = 1;
                objHRPSvc.lngExecuteParameterSQL(strSQL3, ref lngRes, ParamArr3);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 通过摆药ID查询该条记录医嘱是否已收取药袋费用及医嘱开单病区
        /// <summary>
        /// 通过摆药ID查询该条记录医嘱是否已收取药袋费用及医嘱开单病区
        /// </summary>
        /// <param name="p_strPutMedDetailID"></param>
        /// <param name="p_blnIfCharge"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryIfChargeMedBag(string p_strPutMedDetailID, ref bool p_blnIfCharge, ref string p_strOrderCreateAreaID)
        {
            long lngRes = 0;

            string strSQL = @"select t.ifchargemedbag_int
                                from t_bih_opr_putmeddetail t
                               where t.putmeddetailid_chr = ?";

            string strSQL1 = @"select a.createareaid_chr
                                 from t_opr_bih_order a, t_bih_opr_putmeddetail b
                                where b.orderid_chr = a.orderid_chr
                                  and b.putmeddetailid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strPutMedDetailID;

                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
                if (dtResult != null && dtResult.Rows.Count != 0)
                {
                    int intResult = 0;
                    try
                    {
                        intResult = Convert.ToInt32(dtResult.Rows[0][0]);
                    }
                    catch { }
                    if (intResult == 1)
                    {
                        p_blnIfCharge = true;
                    }
                }

                IDataParameter[] objParamArr1 = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr1);
                objParamArr1[0].Value = p_strPutMedDetailID;

                DataTable dtResult1 = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtResult1, objParamArr1);

                if (dtResult != null && dtResult.Rows.Count != 0)
                {
                    p_strOrderCreateAreaID = dtResult1.Rows[0][0].ToString();
                }

            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion

        #region 更新摆药明细单中指定记录的药袋费用收取状态
        /// <summary>
        /// 更新摆药明细单中指定记录的药袋费用收取状态
        /// </summary>
        /// <param name="p_strPutMedDetailID"></param>
        /// <param name="p_intStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateIfChargeMedBag(string p_strPutMedDetailID, int p_intStatus)
        {
            long lngRes = 0;

            string strSQL = @"update t_bih_opr_putmeddetail
                                 set ifchargemedbag_int = ?
                               where putmeddetailid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_intStatus;
                objParamArr[1].Value = p_strPutMedDetailID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion

        #region 查询生成药袋收费记录所需的信息
        /// <summary>
        /// 查询生成药袋收费记录所需的信息
        /// </summary>
        /// <param name="p_strOrderDicID"></param>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryInfoForChargeMedBag(string p_strOrderDicID, string p_strInPatientID, ref DataTable p_dtOrderInfo, ref DataTable p_dtPatientInfo)
        {
            long lngRes = 0;

            string strSQL1 = @"select t.name_chr, t.des_vchr
                                 from t_bse_bih_orderdic t
                                where t.orderdicid_chr = ?";

            string strSQL2 = @"select a.patientid_chr,
                                      a.birth_dat, 
                                      b.registerid_chr,
                                      b.areaid_chr,
                                      a.paytypeid_chr,
                                      b.bedid_chr,
                                      b.casedoctor_chr,
                                      c.lastname_vchr
                                 from t_bse_patient a, t_opr_bih_register b, t_bse_employee c
                                where a.patientid_chr = b.patientid_chr
                                  and c.empid_chr = b.casedoctor_chr
                                  and a.inpatientid_chr = ?
                                order by b.inpatient_dat desc";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strOrderDicID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtOrderInfo, objParamArr);

                IDataParameter[] objParamArr1 = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr1);
                objParamArr1[0].Value = p_strInPatientID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref p_dtPatientInfo, objParamArr1);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion
    }
}
