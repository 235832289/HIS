using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.PatientSvc;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 病区催款
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDemandPayment : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 根据根据病区Id号取病区所有病人费用
        /// <summary>
        /// 根据根据病区Id号取病区所有病人费用
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="areaId">病区Id号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetFeeByAreaId(System.Security.Principal.IPrincipal p_objPrincipal, string areaId, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDemandPayment", "GetFeeByAreaId");
            if (lngRes < 0)
            {
                return -1;
            }

            string SQL = @"select a.registerid_chr, a.unitprice_dec, a.amount_dec, a.pstatus_int, c.precent_dec  
                             from t_opr_bih_patientcharge a,
                                  t_opr_bih_register b,
                                  t_aid_inschargeitem c
                            where a.registerid_chr = b.registerid_chr and
                                  a.chargeitemid_chr = c.itemid_chr and
                                  b.paytypeid_chr = c.copayid_chr and
                                  a.pstatus_int <> 0 and
                                  a.status_int = 1 and 
                                  a.chargeactive_dat is not null";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                if (areaId == "%")
                {
                    SQL += " order by b.AREAID_CHR";

                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                }
                else
                {
                    SQL += " and b.AREAID_CHR = ? order by b.AREAID_CHR";

                    System.Data.IDataParameter[] objLisAddItemRefArr;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    //Please change the datetime and reocrdid 
                    objLisAddItemRefArr[0].Value = areaId;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
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

        #region 根据根据病区Id号取病区所有病人登记信息
        /// <summary>
        /// 根据根据病区Id号取病区所有病人登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="areaId">病区Id号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientByAreaId(System.Security.Principal.IPrincipal p_objPrincipal, string areaId, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDemandPayment", "GetPatientByAreaId");
            if (lngRes < 0)
            {
                return -1;
            }
            string SQL = @"select a.registerid_chr, a.inpatientid_chr, a.des_vchr, a.pstatus_int,
                                   a.feestatus_int, a.limitrate_mny, b.code_chr, c.paytypename_vchr,
                                   d.patientcardid_chr, e.lastname_vchr, g.deptname_vchr,
                                   h.lastname_vchr casedoctor, a.insuredsum_mny,
                                   (select f.remarkname_vchr
                                      from t_opr_bih_patspecremark f
                                     where a.registerid_chr = f.registerid_chr(+)
                                           and f.status_int = 1) remarkname_vchr
                              from t_opr_bih_register a,
                                   t_bse_bed b,
                                   t_bse_patientpaytype c,
                                   t_bse_patientcard d,
                                   t_opr_bih_registerdetail e,
                                   t_bse_deptdesc g,
                                   t_bse_employee h
                             where a.bedid_chr = b.bedid_chr
                               and a.registerid_chr = e.registerid_chr
                               and a.paytypeid_chr = c.paytypeid_chr(+)
                               and a.patientid_chr = d.patientid_chr(+)
                               and a.areaid_chr = g.deptid_chr
                               and a.casedoctor_chr = h.empid_chr(+)
                               and a.status_int = 1";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                if (areaId == "%")
                {
                    SQL += " order by g.code_vchr, b.code_chr";

                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                }
                else
                {
                    SQL += " and a.areaid_chr = ? order by g.code_vchr, b.code_chr";

                    System.Data.IDataParameter[] objLisAddItemRefArr;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = areaId;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
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

        /// <summary>
        /// 根据根据病区Id号取病区所有病人登记信息
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="InHospitalFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientByAreaId(string areaId, string BeginDate, string EndDate, bool InHospitalFlag, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            if (InHospitalFlag)
            {
                SQL = @"select a.registerid_chr, a.inpatientid_chr, a.des_vchr, a.pstatus_int,
                               a.feestatus_int, a.limitrate_mny, b.code_chr, c.paytypename_vchr,
                               d.patientcardid_chr, e.lastname_vchr, g.deptname_vchr,
                               h.lastname_vchr casedoctor, a.insuredsum_mny,
                               (select f.remarkname_vchr
                                  from t_opr_bih_patspecremark f
                                 where a.registerid_chr = f.registerid_chr(+)
                                       and f.status_int = 1) remarkname_vchr
                          from t_opr_bih_register a,
                               t_bse_bed b,
                               t_bse_patientpaytype c,
                               t_bse_patientcard d,
                               t_opr_bih_registerdetail e,
                               t_bse_deptdesc g,
                               t_bse_employee h
                         where a.bedid_chr = b.bedid_chr
                           and a.registerid_chr = e.registerid_chr
                           and a.paytypeid_chr = c.paytypeid_chr(+)
                           and a.patientid_chr = d.patientid_chr(+)
                           and a.areaid_chr = g.deptid_chr
                           and a.casedoctor_chr = h.empid_chr(+)
                           and (a.pstatus_int = 0 or a.pstatus_int = 1 or a.pstatus_int = 4) 
                           and a.status_int = 1 ";
            }
            else
            {
                SQL = @"select a.registerid_chr, a.inpatientid_chr, a.des_vchr, a.pstatus_int,
                               a.feestatus_int, a.limitrate_mny, b.code_chr, c.paytypename_vchr,
                               d.patientcardid_chr, e.lastname_vchr, g.deptname_vchr,
                               h.lastname_vchr casedoctor, a.insuredsum_mny,
                               (select f.remarkname_vchr
                                  from t_opr_bih_patspecremark f
                                 where a.registerid_chr = f.registerid_chr(+)
                                       and f.status_int = 1) remarkname_vchr
                          from t_opr_bih_register a,
                               t_bse_bed b,
                               t_bse_patientpaytype c,
                               t_bse_patientcard d,
                               t_opr_bih_registerdetail e,
                               t_bse_deptdesc g,
                               t_bse_employee h,
                               t_opr_bih_leave i 
                         where a.bedid_chr = b.bedid_chr
                           and a.registerid_chr = e.registerid_chr
                           and a.registerid_chr = i.registerid_chr
                           and a.paytypeid_chr = c.paytypeid_chr(+)
                           and a.patientid_chr = d.patientid_chr(+)
                           and a.areaid_chr = g.deptid_chr
                           and a.casedoctor_chr = h.empid_chr(+)
                           and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                           and a.status_int = 1 
                           and i.status_int = 1
                           and (i.outhospital_dat between ? and ?) ";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr;

                if (InHospitalFlag)
                {
                    if (areaId == "%")
                    {
                        SQL += " order by g.code_vchr, b.code_chr";

                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                    }
                    else
                    {
                        SQL += " and a.areaid_chr = ? order by g.code_vchr, b.code_chr";
                        
                        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = areaId;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
                    }
                }
                else
                {
                    if (areaId == "%")
                    {
                        SQL += " order by g.code_vchr, b.code_chr";

                        objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                        objLisAddItemRefArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
                    }
                    else
                    {
                        SQL += " and a.areaid_chr = ? order by g.code_vchr, b.code_chr";
                        
                        objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                        objLisAddItemRefArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");
                        objLisAddItemRefArr[2].Value = areaId;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
                    }
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

        #region 根据根据病区Id号取病区所有病人预收信息
        /// <summary>
        /// 根据根据病区Id号取病区所有病人预收信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="areaId">病区Id号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPrepayByAreaId(System.Security.Principal.IPrincipal p_objPrincipal, string areaId, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDemandPayment", "GetPatientByAreaId");
            if (lngRes < 0)
            {
                return -1;
            }
            string SQL = @"select a.registerid_chr, sum(nvl(a.money_dec,0)) as balancetotal 
                                  from t_opr_bih_prepay a, t_opr_bih_register b
                                 where a.registerid_chr = b.registerid_chr and
                                      a.status_int = 1 and
                                      a.isclear_int = 0 ";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                if (areaId == "%")
                {
                    SQL += " group by a.registerid_chr";

                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                }
                else
                {
                    SQL += " and b.areaid_chr = ? group by a.registerid_chr";

                    System.Data.IDataParameter[] objLisAddItemRefArr;

                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    //Please change the datetime and reocrdid 
                    objLisAddItemRefArr[0].Value = areaId;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
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

        /// <summary>
        /// 根据根据病区Id号取病区所有病人预收信息
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="InHospitalFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPrepayByAreaId(string areaId, string BeginDate, string EndDate, bool InHospitalFlag, out DataTable dt)        
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            if (InHospitalFlag)
            {
                SQL = @"select a.registerid_chr, sum (nvl (a.money_dec, 0)) as balancetotal
                          from t_opr_bih_prepay a, t_opr_bih_register b
                         where a.registerid_chr = b.registerid_chr
                           and a.status_int = 1
                           and a.isclear_int = 0
                           and b.status_int = 1
                           and (b.pstatus_int = 0 or b.pstatus_int = 1 or b.pstatus_int = 4) ";
            }
            else
            {
                SQL = @"select a.registerid_chr, sum (nvl (a.money_dec, 0)) as balancetotal
                          from t_opr_bih_prepay a, 
                               t_opr_bih_register b,
                               t_opr_bih_leave c 
                         where a.registerid_chr = b.registerid_chr
                           and a.registerid_chr = c.registerid_chr 
                           and a.status_int = 1
                           and a.isclear_int = 0
                           and b.status_int = 1
                           and (b.pstatus_int = 2 or b.pstatus_int = 3) 
                           and c.status_int = 1 
                           and (c.outhospital_dat between ? and ?) ";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr;

                if (InHospitalFlag)
                {
                    if (areaId == "%")
                    {
                        SQL += " group by a.registerid_chr";

                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                    }
                    else
                    {
                        SQL += " and b.areaid_chr = ? group by a.registerid_chr";
                        
                        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = areaId;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
                    }
                }
                else
                {
                    if (areaId == "%")
                    {
                        SQL += " group by a.registerid_chr";

                        objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                        objLisAddItemRefArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
                    }
                    else
                    {
                        SQL += " and b.areaid_chr = ? group by a.registerid_chr";

                        objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                        objLisAddItemRefArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");
                        objLisAddItemRefArr[2].Value = areaId;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);
                    }
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

        #region 根据根据病区Id号取病区所有病人费用-已合计的
        /// <summary>
        /// 根据根据病区Id号取病区所有病人费用已合计的
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="areaId">病区Id号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetFeeByAreaIdSum(System.Security.Principal.IPrincipal p_objPrincipal, ArrayList m_arrRegisterid_chr, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            string strUnion = " union all ";
            string strSql2 = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDemandPayment", "GetFeeByAreaIdSum");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSql = @"select   a.registerid_chr, a.pstatus_int,
                                     sum (round (a.unitprice_dec * a.amount_dec, 2)) money
                                from t_opr_bih_patientcharge a
                               where a.status_int = 1 
                                 and a.chargeactive_dat is not null
                                 and a.registerid_chr in ([registerid_chr])
                            group by a.registerid_chr, a.pstatus_int";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                string registerid_chr = "";
                for (int i = 0; i < m_arrRegisterid_chr.Count; i++)
                {
                    registerid_chr += "'" + m_arrRegisterid_chr[i].ToString().Trim() + "'";
                    registerid_chr += ",";
                    if (i > 0 && i % 10 == 0)
                    {
                        registerid_chr = registerid_chr.TrimEnd(",".ToCharArray());
                        strSql2 += strSql.Replace("[registerid_chr]", registerid_chr) + strUnion;
                        registerid_chr = "";
                    }
                }
                if (!registerid_chr.Trim().Equals(""))
                {
                    registerid_chr = registerid_chr.TrimEnd(",".ToCharArray());
                    strSql2 += strSql.Replace("[registerid_chr]", registerid_chr);
                }
                strSql2 = strSql2.TrimEnd(strUnion.ToCharArray());
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql2, ref dt);

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

        #region 根据根据病区Id号取病区所有病人费用-已合计的
        /// <summary>
        /// 根据根据病区Id号取病区所有病人费用已合计的
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="areaId">病区Id号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetFeeByAreaIdSum(System.Security.Principal.IPrincipal p_objPrincipal, string areaId, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDemandPayment", "GetFeeByAreaIdSum");
            if (lngRes < 0)
            {
                return -1;
            }
          
            string SQL = @"select   a.registerid_chr, a.pstatus_int,
                                     sum (round (a.unitprice_dec * a.amount_dec, 2)) as money
                                from t_opr_bih_patientcharge a, t_opr_bih_register b
                               where b.registerid_chr = a.registerid_chr
                                 and a.status_int = 1
                                 and a.chargeactive_dat is not null
                                 and b.areaid_chr = ?
                            group by a.registerid_chr, a.pstatus_int";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] objLisAddItemRefArr;

                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = areaId;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);

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
        /// 根据根据病区Id号取病区所有病人费用已合计的
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="InHospitalFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetFeeByAreaIdSum(string areaId, string BeginDate, string EndDate, bool InHospitalFlag, out DataTable dt)        
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            if (InHospitalFlag)
            {
                SQL = @"select   a.registerid_chr, a.pstatus_int,
                                     sum (round (a.unitprice_dec * a.amount_dec, 2)) as money, sum(round(a.totaldiffcostmoney_dec, 2)) as totaldiffcostmoney_dec 
                                from t_opr_bih_patientcharge a, t_opr_bih_register b
                               where b.registerid_chr = a.registerid_chr
                                 and a.status_int = 1
                                 and a.chargeactive_dat is not null
                                 and b.status_int = 1 
                                 and (b.pstatus_int = 0 or b.pstatus_int = 1 or b.pstatus_int = 4)
                                 and b.areaid_chr = ?
                            group by a.registerid_chr, a.pstatus_int";
            }
            else
            {
                SQL = @"select   a.registerid_chr, a.pstatus_int,
                                     sum (round (a.unitprice_dec * a.amount_dec, 2)) as money, sum(round(a.totaldiffcostmoney_dec, 2)) as totaldiffcostmoney_dec  
                                from t_opr_bih_patientcharge a, 
                                     t_opr_bih_register b,
                                     t_opr_bih_leave c
                               where b.registerid_chr = a.registerid_chr
                                 and b.registerid_chr = c.registerid_chr
                                 and a.status_int = 1
                                 and a.chargeactive_dat is not null
                                 and b.status_int = 1 
                                 and c.status_int = 1 
                                 and (b.pstatus_int = 2 or b.pstatus_int = 3)
                                 and b.areaid_chr = ?
                                 and (c.outhospital_dat between ? and ?) 
                            group by a.registerid_chr, a.pstatus_int";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr;

                if (InHospitalFlag)
                {
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = areaId;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = areaId;
                    objLisAddItemRefArr[1].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                    objLisAddItemRefArr[2].Value = Convert.ToDateTime(EndDate + " 23:59:59");
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, objLisAddItemRefArr);

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
