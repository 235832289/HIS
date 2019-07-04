using System;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.DataCollection;

namespace com.digitalwave.iCare.middletier.CommunityInterface
{ 
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsCommunityInterface_Svc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsCommunityInterface_Svc()
        {
            // add code
        }

        #region 统计人数
        /// <summary>
        /// 统计人数
        /// </summary>
        /// <param name="p_strTime"></param>
        /// <param name="p_strInRegID"></param>
        /// <param name="p_strOutRegID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientCount(string p_strTime, out List<string> p_strInRegID, out List<string> p_strOutRegID)
        {
            DateTime dtmBegin = DateTime.Parse(p_strTime + " 00:00:00");
            DateTime dtmEnd = DateTime.Parse(p_strTime + " 23:59:59");
            long lngRes = -1;
            p_strInRegID = null;
            p_strOutRegID = null;

            try
            {
                string strSQL = @"select   distinct tr.registerid_chr 
                                      from t_opr_bih_transfer tr, t_opr_bih_register reg
                                     where tr.registerid_chr = reg.registerid_chr
                                       and tr.type_int = 5
                                       and reg.status_int = 1
                                       and (tr.modify_dat between ? and ?) ";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = dtmBegin;
                param[1].Value = dtmEnd;
                param[0].DbType = DbType.DateTime;
                param[1].DbType = DbType.DateTime; 
                DataTable dt = new DataTable();

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes < 0)
                {
                    return lngRes;
                }
                int intRowCount = dt.Rows.Count;
                if (intRowCount > 0)
                {
                    p_strInRegID = new List<string>(intRowCount);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!p_strInRegID.Contains(dr["registerid_chr"].ToString()))
                        {
                            p_strInRegID.Add(dr["registerid_chr"].ToString());
                        }
                    }
                }
                dt = null;

                strSQL = @"select distinct a.registerid_chr
  from t_opr_bih_leave a, t_opr_bih_transfer b, t_opr_bih_register reg
 where a.registerid_chr = b.registerid_chr
   and a.registerid_chr = reg.registerid_chr
   and reg.relateregisterid_chr is null
   and b.type_int = 6
   and a.status_int = 1
   and a.pstatus_int = 1
   and (a.outhospital_dat between ? and ?)
";
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = dtmBegin;
                param[1].Value = dtmEnd;
                param[0].DbType = DbType.DateTime;
                param[1].DbType = DbType.DateTime;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                intRowCount = dt.Rows.Count;
                if (intRowCount>0)
                {
                    p_strOutRegID = new List<string>(intRowCount);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!p_strOutRegID.Contains(dr["registerid_chr"].ToString()))
                        {
                            p_strOutRegID.Add(dr["registerid_chr"].ToString());
                        }
                    }
                }
                dt.Dispose();
                dt = null;
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

        /// <summary>
        /// 入院信息
        /// </summary>
        /// <param name="p_strInPatient"></param>
        /// <param name="p_glsInPatientInfor"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInpatientInfo(List<string> p_strInPatient, out List<clsHospRecordCS_Vo> p_glsInPatientInfor)
        {
            long lngRes = -1;
            p_glsInPatientInfor = null;
            System.Text.StringBuilder stbTmp = new System.Text.StringBuilder(p_strInPatient.Count * 21);
            int i1 = 0;
            for (i1 = 0; i1 < p_strInPatient.Count-1; i1++)
            {
                stbTmp.Append("'" + p_strInPatient[i1].ToString() + "',");
            }
            stbTmp.Append("'" + p_strInPatient[i1].ToString() + "'");

            string sql = @"select  b.lastname_vchr, b.sex_chr, b.race_vchr, b.homeaddress_vchr,
                                   b.officeaddress_vchr, b.homephone_vchr, b.contactpersonfirstname_vchr,
                                   b.nationality_vchr, b.married_chr, b.birth_dat, b.idcard_chr,
                                   b.insuranceid_vchr, a.inpatientid_chr, a.inpatientcount_int,
                                   a.registerid_chr, f.patientcardid_chr, e.code_chr, a.areaid_chr,
                                   d.deptname_vchr, a.casedoctor_chr, g.lastname_vchr as doctorname,
                                   a.inareadate_dat, a.icd10diagtext_vchr, a.icd10diagid_vchr,
                                   a.status_int
                              from t_opr_bih_register a, t_opr_bih_registerdetail b, t_bse_deptdesc d,
                                   t_bse_bed e, t_bse_patientcard f, t_bse_employee g
                             where a.registerid_chr = b.registerid_chr
                               and a.patientid_chr = f.patientid_chr
                               and a.casedoctor_chr = g.empid_chr
                               and a.areaid_chr = d.deptid_chr
                               and a.bedid_chr = e.bedid_chr
                               and a.status_int != 0
                               and a.registerid_chr in ( " + stbTmp.ToString().Trim() + ")";
            stbTmp = null;
            p_strInPatient = null;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dt = new DataTable();

                lngRes = objHRPSvc.DoGetDataTable(sql, ref dt);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes < 0)
                {
                    return lngRes;
                }
                p_glsInPatientInfor = new List<clsHospRecordCS_Vo>(dt.Rows.Count);

                foreach (DataRow dr in dt.Rows)
                {
                    clsHospRecordCS_Vo objNew = new clsHospRecordCS_Vo();

                    objNew.m_strName = dr["lastname_vchr"].ToString();
                    objNew.m_strSex = clsDataUpload_Svc.m_strConvertValue("sex", dr["sex_chr"].ToString(), "");
                    objNew.m_strEthnicGroup = clsDataUpload_Svc.m_strConvertValue("ethnicgroup", dr["race_vchr"].ToString(), "");
                    objNew.m_strAddress= dr["homeaddress_vchr"].ToString();

                    objNew.m_strJobTitle = dr["officeaddress_vchr"].ToString();
                    objNew.m_strPhoneNum = dr["homephone_vchr"].ToString();
                    objNew.m_strContactPerson = dr["contactpersonfirstname_vchr"].ToString();

                    //objNew.m_strNationality= dr["nationality_vchr"].ToString();
                    objNew.m_strNationality = clsDataUpload_Svc.m_strConvertValue("nationality", dr["nationality_vchr"].ToString(), "");

                    //objNew.m_strMaritalStatus = this.m_strMarryStatus(dr["married_chr"].ToString());
                    //婚姻
                    objNew.m_strMaritalStatus = clsDataUpload_Svc.m_strConvertValue("maritalstatus", dr["married_chr"].ToString(), "");
                    objNew.m_dtmBirthDay = Convert.ToDateTime(dr["birth_dat"]);
                    objNew.m_strIDNumber = dr["idcard_chr"].ToString();
                    objNew.m_strSSID = dr["insuranceid_vchr"].ToString();

                    objNew.m_strInHospNO = dr["inpatientid_chr"].ToString();
                    objNew.m_intInHospCount = int.Parse(dr["inpatientcount_int"].ToString());
                    objNew.m_strRegisterID = dr["registerid_chr"].ToString();
                    objNew.m_strClinicID = dr["patientcardid_chr"].ToString();

                    objNew.m_strBedNO = dr["code_chr"].ToString();
                    objNew.m_strInDeptCode = dr["areaid_chr"].ToString();
                    objNew.m_strInDeptName = dr["deptname_vchr"].ToString();
                    objNew.m_strMainDoctorID = dr["casedoctor_chr"].ToString();

                    objNew.m_strMainDoctorName = dr["doctorname"].ToString();
                    objNew.m_dtmInDate = Convert.ToDateTime(dr["inareadate_dat"]);
                    objNew.m_strInDiagnosName = dr["icd10diagtext_vchr"].ToString();
                    objNew.m_strInDiagnosCode = dr["icd10diagid_vchr"].ToString();

                    objNew.m_intCancel = int.Parse(dr["status_int"].ToString());
                    objNew.m_strKind = "1";
                    p_glsInPatientInfor.Add(objNew);
                } 

                dt.Dispose();
                dt = null;
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
        public long m_lngGetOutPatientInfor(string m_strRegID, out clsHospRecordCS_Vo p_objHospRecord,
                     out List<clsHospBillCS_Vo> m_glsHospBill, out List<clsHospOrderCS_Vo> m_glsHospOrder)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            DataTable dtTmp = null;
            p_objHospRecord = null;
            m_glsHospBill = null;
            m_glsHospOrder = null;

            try
            {
                #region 1. 个人信息
                strSQL = @"select  b.lastname_vchr, b.sex_chr, b.race_vchr, b.homeaddress_vchr,
                                   b.officeaddress_vchr, b.homephone_vchr, b.contactpersonfirstname_vchr,
                                   b.nationality_vchr, b.married_chr, b.birth_dat, b.idcard_chr,
                                   b.insuranceid_vchr, a.inpatientid_chr, a.inpatientcount_int,
                                   a.registerid_chr, f.patientcardid_chr, e.code_chr, a.areaid_chr,
                                   d.deptname_vchr, a.casedoctor_chr, g.lastname_vchr as doctorname,
                                   a.inareadate_dat, a.icd10diagtext_vchr, a.icd10diagid_vchr,
                                   a.status_int, td.deptname_vchr as outdeptname, ta.outareaid_chr,
                                   ta.outhospital_dat, ta.diagnose_vchr as outdiagnose,
                                   ta.ins_diagnose_vchr, ta.type_int,b.birthplace_vchr,a.inpatient_dat,a.paytypeid_chr
                              from t_opr_bih_register a,
                                   t_opr_bih_leave ta,
                                   t_opr_bih_registerdetail b,
                                   t_bse_deptdesc d,
                                   t_bse_bed e,
                                   t_bse_patientcard f,
                                   t_bse_employee g,
                                   t_bse_deptdesc td
                             where a.registerid_chr = b.registerid_chr
                               and a.registerid_chr = ta.registerid_chr
                               and ta.pstatus_int = 1
                               and ta.status_int = 1
                               and ta.outareaid_chr = td.deptid_chr
                               and a.patientid_chr = f.patientid_chr
                               and a.casedoctor_chr = g.empid_chr
                               and a.areaid_chr = d.deptid_chr
                               and a.bedid_chr = e.bedid_chr
                               and a.status_int != 0
                               and a.registerid_chr = ?";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strRegID;
                dtTmp = new DataTable();

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTmp, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                param = null;

                if (lngRes < 0 || dtTmp.Rows.Count < 1)
                {
                    return lngRes;
                }


                /////////////////////////////////////////////////////
                DataRow dr = dtTmp.Rows[0];
                p_objHospRecord = new clsHospRecordCS_Vo();

                p_objHospRecord.m_strName = dr["lastname_vchr"].ToString();
                p_objHospRecord.m_strSex = clsDataUpload_Svc.m_strConvertValue("sex", dr["sex_chr"].ToString(), "");
                p_objHospRecord.m_strEthnicGroup = clsDataUpload_Svc.m_strConvertValue("ethnicgroup", dr["race_vchr"].ToString(), "");
                p_objHospRecord.m_strAddress = dr["homeaddress_vchr"].ToString();
                if (dr["inpatient_dat"] != DBNull.Value)
                {
                    
                    p_objHospRecord.m_dtmConfirmDate = Convert.ToDateTime(dr["inpatient_dat"].ToString().Trim());
                    string m_strDateTime = p_objHospRecord.m_dtmConfirmDate.ToString("yyyy-MM-dd");
                    p_objHospRecord.m_dtmConfirmDate = Convert.ToDateTime(m_strDateTime);
                }

                p_objHospRecord.m_strJobTitle = dr["officeaddress_vchr"].ToString();
                p_objHospRecord.m_strPhoneNum = dr["homephone_vchr"].ToString();
                p_objHospRecord.m_strContactPerson = dr["contactpersonfirstname_vchr"].ToString(); 
                p_objHospRecord.m_strNationality = clsDataUpload_Svc.m_strConvertValue("nationality", dr["nationality_vchr"].ToString(), "");

                p_objHospRecord.m_strMaritalStatus = clsDataUpload_Svc.m_strConvertValue("maritalstatus", dr["married_chr"].ToString(), "");
                p_objHospRecord.m_dtmBirthDay = Convert.ToDateTime(dr["birth_dat"]);
                p_objHospRecord.m_strIDNumber = dr["idcard_chr"].ToString();
                p_objHospRecord.m_strSSID = dr["insuranceid_vchr"].ToString();

                p_objHospRecord.m_strInHospNO = dr["inpatientid_chr"].ToString();
                p_objHospRecord.m_intInHospCount = int.Parse(dr["inpatientcount_int"].ToString());
                p_objHospRecord.m_strRegisterID = dr["registerid_chr"].ToString();
                p_objHospRecord.m_strClinicID = dr["patientcardid_chr"].ToString();

                p_objHospRecord.m_strBedNO = dr["code_chr"].ToString();
                p_objHospRecord.m_strInDeptCode = dr["areaid_chr"].ToString();
                p_objHospRecord.m_strInDeptName = dr["deptname_vchr"].ToString();
                p_objHospRecord.m_strMainDoctorID = dr["casedoctor_chr"].ToString();

                p_objHospRecord.m_strMainDoctorName = dr["doctorname"].ToString();
                p_objHospRecord.m_dtmInDate = DateTime.Parse(dr["inpatient_dat"].ToString());
                p_objHospRecord.m_strInDiagnosName = dr["icd10diagtext_vchr"].ToString();
                p_objHospRecord.m_strInDiagnosCode = dr["icd10diagid_vchr"].ToString();

                p_objHospRecord.m_strOutDeptName = dr["outdeptname"].ToString();
                p_objHospRecord.m_strOutDeptCode = dr["outareaid_chr"].ToString();
                p_objHospRecord.m_dtmOutDate = Convert.ToDateTime(dr["outhospital_dat"]);
                p_objHospRecord.m_strOutDiagnosName = dr["outdiagnose"].ToString();

                p_objHospRecord.m_strOutDiagnosCode = dr["ins_diagnose_vchr"].ToString();
                p_objHospRecord.m_strStatus = dr["type_int"].ToString();//改
                p_objHospRecord.m_intCancel = int.Parse(dr["status_int"].ToString());

                TimeSpan ts = p_objHospRecord.m_dtmOutDate - p_objHospRecord.m_dtmInDate;
                p_objHospRecord.m_intHospDay = ts.Days;
                p_objHospRecord.m_strKind = clsDataUpload_Svc.m_strConvertValue("kind", dr["paytypeid_chr"].ToString(), "");// 跟身份关联

                p_objHospRecord.m_strBirthPlace = dr["BIRTHPLACE_VCHR"].ToString();
                p_objHospRecord.m_dtmInAreaTime = Convert.ToDateTime(dr["inareadate_dat"]);
                dtTmp.Dispose();
                dtTmp = null;
                //////////////////////////////////////////////////// 
                #endregion

                #region 2. 发票信息
                //2.1 主信息
//                strSQL = @"select    a.registerid_chr, c.invoiceno_vchr, a.totalsum_mny, a.sbsum_mny,
//                                     a.operdate_dat, e.typeid_chr, e.typename_vchr, a.chargeno_chr,
//                                     sum (b.totalmoney_dec) as submoney,a.paytypeid_chr
//                                from t_opr_bih_charge a,
//                                     t_opr_bih_chargeitementry b,
//                                     t_opr_bih_chargedefinv c,
//                                     t_bse_chargeitemextype e
//                               where a.chargeno_chr = c.chargeno_chr
//                                 and a.chargeno_chr = b.chargeno_chr
//                                 and b.invcateid_chr = e.typeid_chr
//                                 and e.flag_int = 4
//                                 and a.registerid_chr = ?
//                            group by a.registerid_chr,
//                                     c.invoiceno_vchr,
//                                     a.totalsum_mny,
//                                     a.sbsum_mny,
//                                     a.operdate_dat,
//                                     e.typeid_chr,
//                                     e.typename_vchr,
//                                     a.chargeno_chr
//                            order by c.invoiceno_vchr";
                strSQL = @"select b.sid_int,
       a.registerid_chr,
       c.orderid_chr,
       c.create_dat,
       c.createarea_chr,
       d.invoiceno_vchr,
       a.totalsum_mny,
       a.sbsum_mny,
       a.operdate_dat,
       g.itemcode_vchr as chargeitemid_chr,
       b.chargeitemname_chr,
       b.amount_dec,
       b.unitprice_dec,
       b.totalmoney_dec as itemmoney,
       b.createarea_chr,
       e.deptname_vchr,
       b.doctorid_chr,
       f.lastname_vchr,
       b.invcateid_chr,
       a.chargeno_chr,
       b.sid_int,
       g.itemsrcid_vchr,
       g.itemcode_vchr,
       h.drugid_chr
  from t_opr_bih_charge           a,
       t_opr_bih_chargeitementry  b,
       t_opr_bih_patientcharge    c,
       t_opr_bih_chargedefinv     d,
       t_bse_deptdesc             e,
       t_bse_employee             f,
       t_bse_chargeitem           g,
       t_bse_medidrefloadupdrugid h
 where b.chargeitemid_chr = g.itemid_chr(+)
   and a.chargeno_chr = b.chargeno_chr
   and a.chargeno_chr = d.chargeno_chr
   and a.chargeno_chr = c.paymoneyid_chr
   and b.pchargeid_chr = c.pchargeid_chr
   and b.createarea_chr = e.deptid_chr
   and b.doctorid_chr = f.empid_chr
   and g.itemsrcid_vchr = h.medicineid_chr(+)
   and a.registerid_chr = ?
 ";
                objHRPSvc = new clsHRPTableService();
                dtTmp = new DataTable();
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strRegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTmp, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                param = null;


                if (lngRes < 0 || dtTmp.Rows.Count < 1)
                {
                    return lngRes;
                }

                // 2.2 要取得开始和结束时间

                int intRowCount = dtTmp.Rows.Count;
                List<string> m_glsChargeNo = new List<string>();
                for (int i = 0; i < intRowCount; i++)
                {
                    dr = dtTmp.Rows[i];
                    if (!m_glsChargeNo.Contains(dr["chargeno_chr"].ToString()))
                    {
                        m_glsChargeNo.Add(dr["chargeno_chr"].ToString());
                    }
                }

                System.Text.StringBuilder stbTmp = new System.Text.StringBuilder(m_glsChargeNo.Count * 23);
                int i1 = 0;
                for (i1 = 0; i1 < m_glsChargeNo.Count - 1; i1++)
                {
                    stbTmp.Append("'" + m_glsChargeNo[i1].ToString() + "',");
                }
                stbTmp.Append("'" + m_glsChargeNo[i1].ToString() + "'");

                strSQL = @"select  a.chargeno_chr, max (c.chargeactive_dat) as enddate,
                                   min (c.chargeactive_dat) as begindate
                              from t_opr_bih_charge a,
                                   t_opr_bih_chargeitementry b,
                                   t_opr_bih_patientcharge c
                             where a.chargeno_chr = b.chargeno_chr
                               and b.pchargeid_chr = c.pchargeid_chr
                               and a.chargeno_chr in (" + stbTmp.ToString().Trim() + ") group by a.chargeno_chr";
                stbTmp = null;
                objHRPSvc = new clsHRPTableService();
                DataTable dtChargeNO = new DataTable();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtChargeNO);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if (lngRes < 0 || dtChargeNO.Rows.Count < 0)
                {
                    return lngRes;
                }

                Dictionary<string, List<DateTime>> m_gDicChargeDefTime = new Dictionary<string, List<DateTime>>(dtChargeNO.Rows.Count);
                List<DateTime> m_glsTime;
                for (i1 = 0; i1 < dtChargeNO.Rows.Count; i1++)
                {
                    dr = dtChargeNO.Rows[i1];
                    m_glsTime = new List<DateTime>(2);
                    m_glsTime.Add(Convert.ToDateTime(dr["begindate"]));
                    m_glsTime.Add(Convert.ToDateTime(dr["enddate"]));

                    m_gDicChargeDefTime.Add(dr["chargeno_chr"].ToString(), m_glsTime);
                }
                dtChargeNO = null;

                // 2.3 赋值
                m_glsHospBill = new List<clsHospBillCS_Vo>(intRowCount);
                for (i1 = 0; i1 < intRowCount; i1++)
                {
                    dr = dtTmp.Rows[i1];
                    clsHospBillCS_Vo objNew = new clsHospBillCS_Vo(); 

                    objNew.m_strRegisterID = dr["registerid_chr"].ToString();
                    objNew.m_strInvoNo = dr["invoiceno_vchr"].ToString();
                    objNew.m_dclInvoTotolMoney = Convert.ToDecimal(dr["totalsum_mny"]);
                    objNew.m_dclInvoFSPMoney = Convert.ToDecimal(dr["sbsum_mny"]);

                    objNew.m_dtmBeginDate = m_gDicChargeDefTime[dr["chargeno_chr"].ToString()][0];
                    objNew.m_dtmEndDate = m_gDicChargeDefTime[dr["chargeno_chr"].ToString()][1];

                    objNew.m_dtmBillDate = Convert.ToDateTime(dr["operdate_dat"]);
                    objNew.m_strKind = p_objHospRecord.m_strKind;//身份
                    //objNew.m_strFareCode = dr["typeid_chr"].ToString();
                    //objNew.m_strFareName = dr["typename_vchr"].ToString();
                    objNew.m_strFareCode = dr["itemcode_vchr"].ToString();
                    objNew.m_strFareName = dr["chargeitemname_chr"].ToString();

                    objNew.m_dclSubMoney = decimal.Parse(dr["itemmoney"].ToString());
                    objNew.m_intAmount = decimal.Parse(dr["amount_dec"].ToString());
                    objNew.m_dclPrice = decimal.Parse(dr["unitprice_dec"].ToString());
                    objNew.m_strInDeptName = dr["createarea_chr"].ToString();
                    objNew.m_strInDeptID = dr["deptname_vchr"].ToString();

                    objNew.m_strDoctorID = dr["doctorid_chr"].ToString();
                    objNew.m_strDoctorName = dr["lastname_vchr"].ToString();
                    objNew.m_strFareKind = clsDataUpload_Svc.m_strConvertValue("billkind", dr["invcateid_chr"].ToString(), "");
                    objNew.m_strSEQID = dr["sid_int"].ToString();
                    objNew.m_strOrderID = dr["orderid_chr"].ToString();
                    objNew.m_strITEMID = dr["drugid_chr"].ToString().Trim();
                    objNew.m_dtEXECUTEDATE = Convert.ToDateTime(dr["create_dat"].ToString());
                    objNew.m_strDEPCODE = dr["createarea_chr"].ToString();
                    objNew.m_strDEPNAME = dr["deptname_vchr"].ToString().Trim();
                    m_glsHospBill.Add(objNew);

                }
                #endregion

                #region 3. 个人医嘱
                strSQL = @" select a.creatorid_chr,
       a.registerid_chr,
       a.creator_chr,
       a.createareaid_chr,
       a.createareaname_vchr,
       a.recipeno_int,
       c.itemcode_vchr as chargeitemid_chr,
       b.chargeitemname_chr,
       b.spec_vchr,
       b.amount_dec,
       b.unitprice_dec,
       b.unit_vchr,
       a.createdate_dat,
       a.startdate_dat,
       a.executetype_int,
       a.orderid_chr,
       '' as kind,
       b.flag_int,
       decode(a.dosage_dec,null,b.amount_dec,a.dosage_dec) as dosage_dec,
       a.dosageunit_chr,
       a.execfreqname_chr as execfreqid_chr,
       a.dosetypeid_chr,
       a.dosetypename_chr,
       a.curareaid_chr,
       d.deptname_vchr as curareaname,
       a.stoperid_chr,
       a.stoper_chr,
       a.stopdate_dat,
       c.itemipinvtype_chr,
       e.sample_type_desc_vchr,
       f.partname,
       a.remark_vchr,
       c.itemsrcid_vchr,
       g.drugid_chr,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
  from t_opr_bih_order            a,
       t_opr_bih_orderchargedept  b,
       t_bse_chargeitem           c,
       t_bse_deptdesc             d,
       t_aid_lis_sampletype       e,
       ar_apply_partlist          f,
       t_bse_medidrefloadupdrugid g,
       t_bse_medicine m,
       t_aid_medicinepreptype n
 where a.orderid_chr = b.orderid_chr
   and b.chargeitemid_chr = c.itemid_chr
   and a.sampleid_vchr = e.sample_type_id_chr(+)
   and a.partid_vchr = f.partid(+)
   and a.curareaid_chr = d.deptid_chr
   and c.itemsrcid_vchr = g.medicineid_chr(+)
   and c.itemsrcid_vchr=m.medicineid_chr(+)
   and  m.medicinepreptype_chr = n.medicinepreptype_chr(+)
   and a.status_int in (2, 3, 6)
   and a.registerid_chr = ?
";
                objHRPSvc = new clsHRPTableService();
                
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strRegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTmp, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if(lngRes<0)
                {
                    return lngRes;
                }
                intRowCount = dtTmp.Rows.Count;
                m_glsHospOrder = new List<clsHospOrderCS_Vo>(intRowCount);

                for(int i = 0; i < intRowCount; i++)
                {
                    dr = dtTmp.Rows[i]; 
                    clsHospOrderCS_Vo objOrder = new clsHospOrderCS_Vo();

                    objOrder.m_strKind = p_objHospRecord.m_strKind;

                    objOrder.m_strCreatorID = dr["creatorid_chr"].ToString();
                    objOrder.m_strCreateDoctor = dr["creator_chr"].ToString();
                    objOrder.m_strCreateDeptID = dr["createareaid_chr"].ToString();
                    objOrder.m_strCreateDept = dr["createareaname_vchr"].ToString();

                    objOrder.m_strOrderID = dr["orderid_chr"].ToString();
                    objOrder.m_strChargeItemID = dr["chargeitemid_chr"].ToString();
                    objOrder.m_strChargeItemName = dr["chargeitemname_chr"].ToString();
                    objOrder.m_strSpec = dr["spec_vchr"].ToString();

                    objOrder.m_dclAmount = decimal.Parse(dr["amount_dec"].ToString());
                    objOrder.m_dclPrice = decimal.Parse(dr["unitprice_dec"].ToString());
                    objOrder.m_strUnit = dr["unit_vchr"].ToString() == "" ? "[无]" : dr["unit_vchr"].ToString();
                    objOrder.m_intGroupNo = int.Parse(dr["recipeno_int"].ToString());
                    if(dr["createdate_dat"]!=DBNull.Value)
                    {
                        objOrder.m_dtmCreateDate = DateTime.Parse(dr["createdate_dat"].ToString());
                    }

                    if(dr["startdate_dat"]!=DBNull.Value)
                    {
                        objOrder.m_dtmStartDT = DateTime.Parse(dr["startdate_dat"].ToString());
                    }

                    if(dr["stopdate_dat"] != DBNull.Value)
                    {
                        objOrder.m_dtmStopDT = DateTime.Parse(dr["stopdate_dat"].ToString());
                    }

                    if(dr["executetype_int"] != DBNull.Value)
                    {
                        objOrder.m_intOrderStauts = int.Parse(dr["executetype_int"].ToString());
                        if (dr["executetype_int"].ToString() == "1")
                        {
                            TimeSpan t = objOrder.m_dtmStopDT - objOrder.m_dtmStartDT;
                            objOrder.m_intDays = t.Days;
                        }
                        else
                        {
                            objOrder.m_intDays = 0;
                        }
                    }
                    

                    objOrder.m_strRegisterID = m_strRegID;
                    objOrder.m_intGroupNo = int.Parse(dr["recipeno_int"].ToString());
                    objOrder.m_strType = clsDataUpload_Svc.m_strConvertValue("ordertype", dr["executetype_int"].ToString(), "");
                    if (dr["flag_int"].ToString() == "0")
                    {
                        
                        if (dr["dosage_dec"] == DBNull.Value)
                        {
                            try
                            {
                                objOrder.m_dclDosageUse = Convert.ToDecimal(dr["amount_dec"]);
                            }
                            catch
                            {
                                objOrder.m_dclDosageUse = 0;
                            }
                        }
                        else
                        {
                            try
                            {
                                objOrder.m_dclDosageUse = Convert.ToDecimal(dr["dosage_dec"]);
                            }
                            catch
                            {
                                objOrder.m_dclDosageUse = 0;
                            }
                        }
                        objOrder.m_strUseUnit = dr["dosageunit_chr"].ToString();
                        objOrder.m_strFrequencyName = clsDataUpload_Svc.m_strConvertValue("Frequency", dr["execfreqid_chr"].ToString(), "");
                        objOrder.m_strUsageType = clsDataUpload_Svc.m_strConvertValue("medicineusage", dr["dosetypeid_chr"].ToString(), "");
                    }
                    objOrder.m_strINDeptID = dr["curareaid_chr"].ToString();
                    objOrder.m_strINDeptName = dr["curareaname"].ToString();
                    objOrder.m_strStopDoctor = dr["stoperid_chr"].ToString();
                    objOrder.m_strStopDoctorName = dr["stoper_chr"].ToString();

                    objOrder.m_strFarekind = clsDataUpload_Svc.m_strConvertValue("billkind", dr["itemipinvtype_chr"].ToString(), "");
                    objOrder.m_strCheckName = dr["sample_type_desc_vchr"].ToString();
                    objOrder.m_strCheckPark = dr["partname"].ToString();
                    objOrder.m_strRemark = dr["remark_vchr"].ToString();
                    objOrder.m_strITEMID = dr["drugid_chr"].ToString().Trim();
                    objOrder.m_strJXBZDM = dr["JXBZDM"].ToString().Trim();
                    //objOrder.

                    m_glsHospOrder.Add(objOrder);
                }

                dtTmp.Dispose();
                dtTmp = null;
                #endregion
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
        public long m_lngGetPatientCount(string p_strTime, out List<string> p_strOutRegID)
        {
            DateTime dtmBegin = DateTime.Parse(p_strTime + " 00:00:00");
            DateTime dtmEnd = DateTime.Parse(p_strTime + " 23:59:59");
            long lngRes = -1; 
            p_strOutRegID = null;

            try
            {
                string strSQL = @"select distinct a.registerid_chr
  from t_opr_bih_leave a, t_opr_bih_transfer b, t_opr_bih_register reg
 where a.registerid_chr = b.registerid_chr
   and a.registerid_chr = reg.registerid_chr
   and reg.relateregisterid_chr is null
   and b.type_int = 6
   and a.status_int = 1
   and a.pstatus_int=1
   and (a.outhospital_dat between ? and ?)";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null; 
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = dtmBegin;
                param[1].Value = dtmEnd;
                param[0].DbType = DbType.DateTime;
                param[1].DbType = DbType.DateTime;
                DataTable dt = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                int intRowCount = dt.Rows.Count;
                if (intRowCount > 0)
                {
                    p_strOutRegID = new List<string>(intRowCount);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!p_strOutRegID.Contains(dr["registerid_chr"].ToString()))
                        {
                            p_strOutRegID.Add(dr["registerid_chr"].ToString());
                        }
                    }
                }
                dt.Dispose();
                dt = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        private string m_strMarryStatus(string p_strText)
        {
            switch (p_strText)
            {
                case "未婚": return "1";
                default: return "2";
            }
        }

    }
}
