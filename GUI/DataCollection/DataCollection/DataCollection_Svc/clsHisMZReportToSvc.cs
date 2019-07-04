using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.middletier.DataCollection
{
    #region 门诊数据上报中间件
    /// <summary>
    /// 门诊数据上报中间件
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsHisMZReportToSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 查询门诊就诊信息
        /// <summary>
        /// 查询门诊就诊信息
        /// </summary>
        /// <param name="p_strPatientCard"></param>
        /// <param name="p_strDeptId"></param>
        /// <param name="p_strDocId"></param>
        /// <param name="p_dtStart"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryClinic(string p_strPatientCardId, string p_strDeptId, string p_strDocId, DateTime p_dtStart, DateTime p_dtEnd, out DataTable p_dtbResult)
        {
            p_dtbResult = null;
            long lngRes = 0;

            StringBuilder sbSubSQL = new StringBuilder(128);
            List<string> lstParamList = new List<string>();
            if (!string.IsNullOrEmpty(p_strPatientCardId))
            {
                sbSubSQL.Append(" and a.patientcardid_chr = ? ");
                lstParamList.Add(p_strPatientCardId);
            }
            if (!string.IsNullOrEmpty(p_strDeptId))
            {
                sbSubSQL.Append(" and b.diagdept_chr = ? ");
                lstParamList.Add(p_strDeptId);
            }
            if (!string.IsNullOrEmpty(p_strDocId))
            {
                sbSubSQL.Append(" and b.diagdr_chr = ? ");
                lstParamList.Add(p_strDocId);
            }

            string strSQL = @"select '1' isreport, --是否上报
       '457226325' organcode, --机构代码（茶山人民医院代码：457226325）
       t.lastname_vchr name, --姓名
       t.sex_chr sex, --性别
       t.occupation_vchr kind, --性质（病人职业）
       t.race_vchr ethnicgroup, --民族
       t.homeaddress_vchr address, --家庭地址
       t.employer_vchr jobtitle, --工作单位
       t.contactpersonphone_vchr phonenumberhome, --联系电话
       t.contactpersonlastname_vchr contactperson, --联系人
       t.nationality_vchr nationality, --国籍
       decode(t.married_chr, '未婚', 1, '已婚', 2) maritalstatus, --婚姻状况
       t.birth_dat birthday, --出生日期
       t.idcard_chr idnumbers, --身份证号
       t.insuranceid_vchr ssid, --社保卡号
       a.patientcardid_chr clinicno, --门诊号
       a.patientcardid_chr visitno, --就诊号（同门诊号）
       b.recorddate_dat clinicdatetime, --就诊日期
       b.diagdept_chr deptcode, --就诊科室代码
       c.deptname_vchr deptname, --就诊科室名称
       b.diagdr_chr cliniciancode, --医生代码
       d.lastname_vchr clinicianname, --医生名称
       b.diagmain_vchr pv2, --主诉
       b.diagcurr_vchr pv3, --现病史
       b.bodycheck_vchr pv1, --体征(体格检查)
       b.diag_vchr diagnosisname1, --第一诊断名称
       '' diagnosiscode1, --第一诊断代码
       '' diagnosisname2, --第二诊断名称
       '' diagnosiscode2, --第二诊断代码
       '' diagnosisname3, --第三诊断名称
       '' diagnosiscode3 --第三诊断代码
  from t_bse_patient           t,
       t_bse_patientcard       a,
       t_opr_outpatientcasehis b,
       t_bse_deptdesc          c,
       t_bse_employee          d
 where t.patientid_chr = a.patientid_chr
   and a.status_int = 1
   and t.patientid_chr = b.patientid_chr
   and b.diagdept_chr = c.deptid_chr
   and b.diagdr_chr = d.empid_chr  " + sbSubSQL.ToString() + @"
   and b.recorddate_dat between ? and ? 
   and b.status_int = 1";

            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                int intParamCount = lstParamList.Count;
                IDataParameter[] objParamArr = null;
                objHRPServ.CreateDatabaseParameter(intParamCount + 2, out objParamArr);
                int intIndex = 0;
                foreach (string strParam in lstParamList)
                {
                    objParamArr[intIndex++].Value = strParam;
                }
                objParamArr[intIndex].DbType = DbType.DateTime;
                objParamArr[intIndex].Value = p_dtStart;
                ++intIndex;
                objParamArr[intIndex].DbType = DbType.DateTime;
                objParamArr[intIndex].Value = p_dtEnd;

                p_dtbResult = new DataTable();
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
                objLogger = null;
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 查询门诊就诊信息
        /// <summary>
        /// 查询门诊就诊信息 by kenny
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrOpdiagInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOpDiagInfo(DateTime datUpload, out clsOpDiagInfo_VO[] arrOpdiagInfo_VO)
        {
            long lngRes = 0;
            string strSQL = string.Empty;
            arrOpdiagInfo_VO = null;
            List<clsOpDiagInfo_VO> lstOpDiagInfo = null;
            Hashtable objHsTable = new Hashtable();
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                strSQL = @"select f.registertypeid_chr as regtypecode,  
       g.registertypename_vchr as regtypename,
       t.occupation_vchr as job,
       t.nativeplace_vchr as native_place,
       e.recorddate_dat as systemdate,     
       '457226325' organcode,
       t.lastname_vchr name,
       t.sex_chr sex,
       t.paytypeid_chr kind,
       t.race_vchr ethnicgroup,
       t.homeaddress_vchr address,
       t.employer_vchr jobtitle,
       t.contactpersonphone_vchr phonenumberhome,
       t.contactpersonlastname_vchr contactperson,
       t.nationality_vchr nationality,
       t.married_chr maritalstatus,
       t.birth_dat birthday,
       t.idcard_chr idnumbers,
       t.insuranceid_vchr ssid,
       a.patientcardid_chr clinicno,
       e.outpatrecipeid_chr visitno,
       e.recorddate_dat clinicdatetime,
       e.diagdept_chr deptcode,
       c.deptname_vchr deptname,
       e.diagdr_chr cliniciancode,
       d.lastname_vchr clinicianname,
       decode(b.parcasehisid_chr,null,b.diagmain_vchr,'') as pv2,
       b.diagcurr_vchr pv3,
       b.bodycheck_vchr pv1,
       b.diag_vchr diagnosisname1,
       '' diagnosiscode1,
       '' diagnosisname2,
       '' diagnosiscode2,
       '' diagnosisname3,
       '' diagnosiscode3,
       b.casehisid_chr
  from t_bse_patient           t,
       t_bse_patientcard       a,
       t_opr_outpatientcasehis b,
       t_bse_deptdesc          c,
       t_bse_employee          d,
       t_opr_outpatientrecipe  e,    
       t_opr_patientregister   f,    
       t_bse_registertype      g
 where t.patientid_chr = a.patientid_chr
   and e.casehisid_chr = b.casehisid_chr
   and f.registerid_chr(+) = b.registerid_chr
   and f.registertypeid_chr = g.registertypeid_chr(+)
   and a.status_int = 1
   and t.patientid_chr = b.patientid_chr
   and e.diagdept_chr = c.deptid_chr
   and e.diagdr_chr = d.empid_chr
   and b.status_int = 1
   and e.pstauts_int in (-2,-1,2,3)
   and e.recorddate_dat between
       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";


                DataTable dtbResult = null;
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                //DateTime datDown = DateTime.Now.AddDays(-1);
                DateTime datDown = datUpload;
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                if (lngRes > 0 && dtbResult != null)
                {
                    lstOpDiagInfo = new List<clsOpDiagInfo_VO>();
                    DataRow dr = null;
                    clsOpDiagInfo_VO objRecord = null;
                    strSQL = @"select  t.icdcode_vchr, t.icdname_vchr
                                  from (select rownum seqnum, a.icdcode_vchr, a.icdname_vchr
                                          from t_opr_opch_icd10 a
                                         where a.casehisid_chr = ?) t
                                 where t.seqnum in (1,2,3)";
                    DataTable dticd10 = null;
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        objRecord = new clsOpDiagInfo_VO();
                        dr = dtbResult.Rows[i1];

                        objRecord.m_strREGTYPECODE = dr["regtypecode"].ToString().Trim();
                        objRecord.m_strREGTYPENAME = dr["regtypename"].ToString().Trim();
                        objRecord.m_strJOB = dr["JOB"].ToString().Trim();
                        objRecord.m_strNATIVE_PLACE = dr["native_place"].ToString().Trim();
                        objRecord.m_strSYSTEMDATE = dr["systemdate"].ToString();

                        objRecord.m_strORGANCODE = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                        objRecord.m_strNAME = dr["name"].ToString().Trim();
                        objRecord.m_strSEX = clsDataUpload_Svc.m_strConvertValue("sex", dr["sex"].ToString().Trim(), "*");
                        objRecord.m_strKIND = clsDataUpload_Svc.m_strConvertValue("kind", dr["kind"].ToString().Trim(), "");
                        objRecord.m_strETHNICGROUP = clsDataUpload_Svc.m_strConvertValue("ethnicgroup", dr["ethnicgroup"].ToString().Trim(), "");
                        objRecord.m_strADDRESS = dr["address"].ToString().Trim();
                        objRecord.m_strJOBTITLE = dr["jobtitle"].ToString().Trim();
                        objRecord.m_strPHONENUMBERHOME = (dr["phonenumberhome"].ToString().Trim().Length > 18 ? dr["phonenumberhome"].ToString().Trim().Substring(0, 18) : dr["phonenumberhome"].ToString().Trim());
                        objRecord.m_strCONTACTPERSON = dr["contactperson"].ToString().Trim();
                        objRecord.m_strNATIONALITY = clsDataUpload_Svc.m_strConvertValue("nationality", dr["nationality"].ToString().Trim(), "");
                        //objRecord.m_strNATIONALITY = dr["nationality"].ToString().Trim();
                        //1-未婚 2-已婚
                        string strMari = clsDataUpload_Svc.m_strConvertValue("maritalstatus", dr["maritalstatus"].ToString().Trim(), "");
                        if (strMari == "")
                        {
                            //objRecord.m_intMARITALSTATUS = "";
                        }
                        else
                        {
                            objRecord.m_intMARITALSTATUS = Convert.ToInt32(strMari);
                        }

                        //objRecord.m_intMARITALSTATUS = int.Parse(dr["maritalstatus"].ToString());
                        if (dr["birthday"] != DBNull.Value)
                        {
                            objRecord.m_strBIRTHDAY = (DateTime.Parse(dr["birthday"].ToString())).ToString("yyyy-MM-dd");
                        }
                        objRecord.m_strIDNUMBERS = dr["idnumbers"].ToString().Trim();
                        objRecord.m_strSSID = dr["ssid"].ToString().Trim();
                        objRecord.m_strCLINICNO = dr["clinicno"].ToString().Trim();
                        objRecord.m_strVISITNO = dr["visitno"].ToString().Trim();
                        if (dr["clinicdatetime"] != DBNull.Value)
                        {
                            objRecord.m_strCLINICDATETIME = (DateTime.Parse(dr["clinicdatetime"].ToString())).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        objRecord.m_strDEPTCODE = (dr["deptcode"].ToString().Trim() == string.Empty ? "无" : dr["deptcode"].ToString().Trim());
                        objRecord.m_strDEPTNAME = (dr["deptname"].ToString().Trim() == string.Empty ? "无" : dr["deptname"].ToString().Trim());
                        objRecord.m_strCLINICIANCODE = (dr["cliniciancode"].ToString().Trim() == string.Empty ? "无" : dr["cliniciancode"].ToString().Trim());
                        objRecord.m_strCLINICIANNAME = (dr["clinicianname"].ToString().Trim() == string.Empty ? "无" : dr["clinicianname"].ToString().Trim());
                        objRecord.m_strPV2 = dr["pv2"].ToString().Trim();
                        objRecord.m_strPV3 = dr["pv3"].ToString().Trim();
                        objRecord.m_strPV1 = dr["pv1"].ToString().Trim();

                        objRecord.m_strDIAGNOSISNAME1 = dr["diagnosisname1"].ToString().Trim();
                        objRecord.m_strDIAGNOSISCODE1 = dr["diagnosiscode1"].ToString().Trim();
                        objRecord.m_strDIAGNOSISNAME2 = dr["diagnosisname2"].ToString().Trim();
                        objRecord.m_strDIAGNOSISCODE2 = dr["diagnosiscode2"].ToString().Trim();
                        objRecord.m_strDIAGNOSISNAME3 = dr["diagnosisname3"].ToString().Trim();
                        objRecord.m_strDIAGNOSISCODE3 = dr["diagnosiscode3"].ToString().Trim();


                        objDPArr = null;
                        objHRPSvc = new clsHRPTableService();
                        objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                        dticd10 = new DataTable();
                        objDPArr[0].Value = dr["casehisid_chr"].ToString().Trim();
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dticd10, objDPArr);

                        if (dticd10.Rows.Count > 0)
                        {
                            objRecord.m_strDIAGNOSISNAME1 = dticd10.Rows[0]["icdname_vchr"].ToString().Trim();
                            objRecord.m_strDIAGNOSISCODE1 = dticd10.Rows[0]["icdcode_vchr"].ToString().Trim();
                        }
                        if (dticd10.Rows.Count > 1)
                        {
                            objRecord.m_strDIAGNOSISNAME2 = dticd10.Rows[1]["icdname_vchr"].ToString().Trim();
                            objRecord.m_strDIAGNOSISCODE2 = dticd10.Rows[1]["icdcode_vchr"].ToString().Trim();
                        }
                        if (dticd10.Rows.Count > 2)
                        {
                            objRecord.m_strDIAGNOSISNAME3 = dticd10.Rows[2]["icdname_vchr"].ToString().Trim();
                            objRecord.m_strDIAGNOSISCODE3 = dticd10.Rows[2]["icdcode_vchr"].ToString().Trim();
                        }

                        objDPArr = null;
                        dticd10 = null;
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strCLINICNO + objRecord.m_strVISITNO + objRecord.m_strDEPTCODE + objRecord.m_strCLINICIANCODE, "");
                            lstOpDiagInfo.Add(objRecord);
                        }
                        catch { }
                    }
                    arrOpdiagInfo_VO = lstOpDiagInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 查询门诊费用信息
        /// <summary>
        /// 查询门诊费用信息 by kenny
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrOpfee_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOpfeeInfo(DateTime datUpload, out clsOpfee_VO[] arrOpfee_VO)
        {
            long lngRes = 0;
            string strSQLWM = string.Empty;
            string strSQLCM = string.Empty;
            string strSQLLIS = string.Empty;
            string strSQLTEST = string.Empty;
            string strSQLOP = string.Empty;
            string strSQLOTH = string.Empty;
            arrOpfee_VO = null;
            List<clsOpfee_VO> lstOpfee = null;
            #region sql语句
            //西药
            strSQLWM = @"select '457226325' as organcode,
       b.outpatrecipedeid_chr as clinicbill_seq,
       t.outpatrecipeid_chr as visitno,
       t.paytypeid_chr as kind,
       t.totalsum_mny as totalfare,
       t.invoiceno_vchr as billno,
       t.deptid_chr as deptcode,
       t.deptname_chr as deptname,
       t.doctorid_chr as doctcode,
       t.doctorname_chr as doctname,
       s.drugid_chr as itemid,
       m.itemcode_vchr as farecode,
       b.itemname_vchr as farename,
       t.sbsum_mny as fareselfpay,
       b.tolqty_dec as amount,
       b.unitprice_mny as price,
       b.tolprice_mny as sum,
       t.invdate_dat as billdate,
       m.itemopinvtype_chr as itemkind,
       t.status_int as flag
  from t_opr_outpatientpwmrecipede b,
       t_opr_outpatientrecipeinv   t,
       t_bse_chargeitem            m,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s
 where (t.status_int = 1 or t.status_int = 3)
    and m.itemid_chr= b.itemid_chr
    and r.medicineid_chr(+) = m.itemsrcid_vchr 
    and r.medicineid_chr = s.medicineid_chr(+) 
   and t.recorddate_dat =
       (select max(a.recorddate_dat)
          from t_opr_outpatientrecipeinv a
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr)
   and b.outpatrecipeid_chr = t.outpatrecipeid_chr
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

            //中药
            strSQLCM = @"select '457226325' as organcode,
       b.outpatrecipedeid_chr as clinicbill_seq,
       t.outpatrecipeid_chr as visitno,
       t.paytypeid_chr as kind,
       t.totalsum_mny as totalfare,
       t.invoiceno_vchr as billno,
       t.deptid_chr as deptcode,
       t.deptname_chr as deptname,
       t.doctorid_chr as doctcode,
       t.doctorname_chr as doctname,
       s.drugid_chr as itemid,
       m.itemcode_vchr as farecode,
       b.itemname_vchr as farename,
       t.sbsum_mny as fareselfpay,
       b.qty_dec as amount,
       b.unitprice_mny as price,
       b.tolprice_mny as sum,
       t.invdate_dat as billdate,
       m.itemopinvtype_chr as itemkind,
       t.status_int as flag
  from t_opr_outpatientcmrecipede b,
       t_opr_outpatientrecipeinv   t,
       t_bse_chargeitem            m,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s
 where (t.status_int = 1 or t.status_int = 3)
   and m.itemid_chr= b.itemid_chr
   and r.medicineid_chr(+) = m.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+) 
   and t.recorddate_dat =
       (select max(a.recorddate_dat)
          from t_opr_outpatientrecipeinv a
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr)
   and b.outpatrecipeid_chr = t.outpatrecipeid_chr
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

            //检验
            strSQLLIS = @"select '457226325' as organcode,
       b.outpatrecipedeid_chr as clinicbill_seq,
       t.outpatrecipeid_chr as visitno,
       t.paytypeid_chr as kind,
       t.totalsum_mny as totalfare,
       t.invoiceno_vchr as billno,
       t.deptid_chr as deptcode,
       t.deptname_chr as deptname,
       t.doctorid_chr as doctcode,
       t.doctorname_chr as doctname,
       s.drugid_chr as itemid,
       m.itemcode_vchr as farecode,
       b.itemname_vchr as farename,
       t.sbsum_mny as fareselfpay,
       b.qty_dec as amount,
       b.price_mny as price,
       b.tolprice_mny as sum,
       t.invdate_dat as billdate,
       m.itemopinvtype_chr as itemkind,
       t.status_int as flag
  from t_opr_outpatientchkrecipede b,
       t_opr_outpatientrecipeinv   t,
       t_bse_chargeitem            m,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s
 where (t.status_int = 1 or t.status_int = 3)
   and m.itemid_chr= b.itemid_chr
   and r.medicineid_chr(+) = m.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+) 
   and t.recorddate_dat =
       (select max(a.recorddate_dat)
          from t_opr_outpatientrecipeinv a
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr)
   and b.outpatrecipeid_chr = t.outpatrecipeid_chr
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

            //检查
            strSQLTEST = @"select '457226325' as organcode,
       b.outpatrecipedeid_chr as clinicbill_seq,
       t.outpatrecipeid_chr as visitno,
       t.paytypeid_chr as kind,
       t.totalsum_mny as totalfare,
       t.invoiceno_vchr as billno,
       t.deptid_chr as deptcode,
       t.deptname_chr as deptname,
       t.doctorid_chr as doctcode,
       t.doctorname_chr as doctname,
       s.drugid_chr as itemid,
       m.itemcode_vchr as farecode,
       b.itemname_vchr as farename,
       t.sbsum_mny as fareselfpay,
       b.qty_dec as amount,
       b.price_mny as price,
       b.tolprice_mny as sum,
       t.invdate_dat as billdate,
       m.itemopinvtype_chr as itemkind,
       t.status_int as flag
  from t_opr_outpatienttestrecipede b,
       t_opr_outpatientrecipeinv   t,
       t_bse_chargeitem            m,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s
 where (t.status_int = 1 or t.status_int = 3)
   and m.itemid_chr= b.itemid_chr
   and r.medicineid_chr(+) = m.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+) 
   and t.recorddate_dat =
       (select max(a.recorddate_dat)
          from t_opr_outpatientrecipeinv a
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr)
   and b.outpatrecipeid_chr = t.outpatrecipeid_chr
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

            //手术治疗
            strSQLOP = @"select '457226325' as organcode,
       b.outpatrecipedeid_chr as clinicbill_seq,
       t.outpatrecipeid_chr as visitno,
       t.paytypeid_chr as kind,
       t.totalsum_mny as totalfare,
       t.invoiceno_vchr as billno,
       t.deptid_chr as deptcode,
       t.deptname_chr as deptname,
       t.doctorid_chr as doctcode,
       t.doctorname_chr as doctname,
       s.drugid_chr as itemid,
       m.itemcode_vchr as farecode,
       b.itemname_vchr as farename,
       t.sbsum_mny as fareselfpay,
       b.qty_dec as amount,
       b.price_mny as price,
       b.tolprice_mny as sum,
       t.invdate_dat as billdate,
       m.itemopinvtype_chr as itemkind,
       t.status_int as flag
  from t_opr_outpatientopsrecipede b,
       t_opr_outpatientrecipeinv   t,
       t_bse_chargeitem            m,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s
 where (t.status_int = 1 or t.status_int = 3)
   and m.itemid_chr= b.itemid_chr
   and r.medicineid_chr(+) = m.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+) 
   and t.recorddate_dat =
       (select max(a.recorddate_dat)
          from t_opr_outpatientrecipeinv a
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr)
   and b.outpatrecipeid_chr = t.outpatrecipeid_chr
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

            //其它
            strSQLOTH = @"select '457226325' as organcode,
       b.outpatrecipedeid_chr as clinicbill_seq,
       t.outpatrecipeid_chr as visitno,
       t.paytypeid_chr as kind,
       t.totalsum_mny as totalfare,
       t.invoiceno_vchr as billno,
       t.deptid_chr as deptcode,
       t.deptname_chr as deptname,
       t.doctorid_chr as doctcode,
       t.doctorname_chr as doctname,
       s.drugid_chr as itemid,
       m.itemcode_vchr as farecode,
       b.itemname_vchr as farename,
       t.sbsum_mny as fareselfpay,
       b.qty_dec as amount,
       b.unitprice_mny as price,
       b.tolprice_mny as sum,
       t.invdate_dat as billdate,
       m.itemopinvtype_chr as itemkind,
       t.status_int as flag
  from t_opr_outpatientothrecipede b,
       t_opr_outpatientrecipeinv   t,
       t_bse_chargeitem            m,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s
 where (t.status_int = 1 or t.status_int = 3)
   and m.itemid_chr= b.itemid_chr
   and r.medicineid_chr(+) = m.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+) 
   and t.recorddate_dat =
       (select max(a.recorddate_dat)
          from t_opr_outpatientrecipeinv a
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr)
   and b.outpatrecipeid_chr = t.outpatrecipeid_chr
   and t.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
            #endregion
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {
                DataTable dtbAll = new DataTable();
                DataTable dtbResult = null;
                //DateTime datDown = DateTime.Now.AddDays(-1);
                DateTime datDown = datUpload;
                //西药
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLWM, ref dtbResult, objDPArr);
                dtbAll = dtbResult.Copy();
                //中药
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLCM, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //检验
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLLIS, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //检查
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLTEST, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //手术治疗
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLOP, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //其他
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLOTH, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);

                if (lngRes > 0 && dtbAll != null)
                {
                    DataView dv = dtbAll.DefaultView;
                    dv.Sort = "clinicbill_seq, visitno, billno,kind, itemid, farecode";
                    dtbAll = dv.ToTable();
                    lstOpfee = new List<clsOpfee_VO>();
                    DataRow dr = null;
                    clsOpfee_VO objRecord = null;
                    for (int i1 = 0; i1 < dtbAll.Rows.Count; i1++)
                    {
                        objRecord = new clsOpfee_VO();
                        dr = dtbAll.Rows[i1];

                        //objRecord.m_strCLINICBILL_SEQ = dr["clinicbill_seq"].ToString().Trim();
                        //objRecord.m_strDEPTCODE = dr["deptcode"].ToString().Trim();
                        //objRecord.m_strDEPTNAME = dr["deptname"].ToString().Trim();
                        //objRecord.m_strDOCTCODE = dr["doctcode"].ToString().Trim();
                        //objRecord.m_strDOCTNAME = dr["doctname"].ToString().Trim();
                        //objRecord.m_strITEMID = dr["itemid"].ToString().Trim();
                        //objRecord.m_strITEMKIND = dr["itemkind"].ToString().Trim();
                        //objRecord.m_strFLAG = dr["flag"].ToString().Trim();

                        objRecord.m_strORGANCODE = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                        objRecord.m_strVISITNO = dr["visitno"].ToString().Trim();
                        objRecord.m_strKIND = clsDataUpload_Svc.m_strConvertValue("kind", dr["kind"].ToString().Trim(), "*");
                        objRecord.m_decTOTALFARE = ConvertObjToDecimal(dr["totalfare"]);
                        objRecord.m_strBILLNO = dr["billno"].ToString().Trim();
                        objRecord.m_strFARECODE = dr["farecode"].ToString().Trim();
                        objRecord.m_strFARENAME = dr["farename"].ToString().Trim();
                        objRecord.m_decFARESELFPAY = ConvertObjToDecimal(dr["fareselfpay"]);
                        objRecord.m_decAMOUNT = ConvertObjToDecimal(dr["amount"]);
                        objRecord.m_decPRICE = ConvertObjToDecimal(dr["price"]);
                        objRecord.m_decSUM = ConvertObjToDecimal(dr["sum"]);
                        if (dr["billdate"] == DBNull.Value) continue;
                        objRecord.m_strBILLDATE = dr["billdate"].ToString().Trim();

                        objRecord.m_strCLINICBILL_SEQ = dr["clinicbill_seq"].ToString().Trim();
                        objRecord.m_strDEPTCODE = dr["deptcode"].ToString().Trim();
                        objRecord.m_strDEPTNAME = dr["deptname"].ToString().Trim();
                        objRecord.m_strDOCTCODE = dr["doctcode"].ToString().Trim();
                        objRecord.m_strDOCTNAME = dr["doctname"].ToString().Trim();
                        objRecord.m_strITEMID = dr["itemid"].ToString().Trim();
                        //objRecord.m_strITEMKIND = dr["itemkind"].ToString().Trim();
                        objRecord.m_strITEMKIND = clsDataUpload_Svc.m_strConvertValue("billkind", dr["itemkind"].ToString().Trim(), "99");
                        //objRecord.m_strFLAG = dr["flag"].ToString().Trim() == "0" ? "0" : "1";
                        objRecord.m_strFLAG = clsDataUpload_Svc.m_strConvertValue("zfbz", dr["flag"].ToString().Trim(), "0");
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strBILLNO + objRecord.m_strVISITNO + objRecord.m_strFARECODE + objRecord.m_strFARENAME, "");
                            lstOpfee.Add(objRecord);
                        }
                        catch { }
                        //  lstOpfee.Add(objRecord);
                    }
                    arrOpfee_VO = lstOpfee.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 查询门诊处方信息
        /// <summary>
        /// 查询门诊处方信息 by kenny
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrRecInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecInfo(DateTime datUpload, out clsRecInfo_VO[] arrRecInfo_VO)
        {
            long lngRes = 0;
            string strSQLWM = string.Empty;
            string strSQLCM = string.Empty;
            string strSQLLIS = string.Empty;
            string strSQLTEST = string.Empty;
            string strSQLOP = string.Empty;
            string strSQLOTH = string.Empty;
            arrRecInfo_VO = null;
            List<clsRecInfo_VO> lstRecInfo = null;
            #region sql语句
            //西药
            strSQLWM = @"select '457226325' as organcode,
       a.outpatrecipedeid_chr as recipe_seq,
       p.itemopinvtype_chr as itemkind,
       s.drugid_chr as itemid,
       a.tolprice_mny as itemsum,
       '' as dosagenum,
       nvl(a.rowno_chr,'0') as recipegroup,
       a.desc_vchr as usageremark,  
        
       c.lastname_vchr as name,
       c.sex_chr as sex,
       b.paytypeid_chr as kind,
       c.race_vchr as ethnicgroup,
       c.homeaddress_vchr as address,
       c.employer_vchr as jobtitle,
       c.homephone_vchr as phonenumberhome,
       c.contactpersonlastname_vchr as contactperson,
       c.nationality_vchr as nationaligy,
       c.married_chr as maritalstatus,
       c.birth_dat as birthday,
       c.idcard_chr as idnumbers,
       c.insuranceid_vchr as ssid,
       d.patientcardid_chr as clinicno,
       b.outpatrecipeid_chr as visitno,
       b.recorddate_dat as clinicdatetime,
       b.outpatrecipeid_chr as recipeid,
       '0001' as recipetype,
       b.recorddate_dat as recipedatetime,
       b.diagdr_chr as recipecliniciancode,
       e.lastname_vchr as recipeclinicianname,
       b.pstauts_int as flag,
       b.diagdept_chr as recipedeptcode,
       f.deptname_vchr as recipedeptname,
       p.itemcode_vchr as medicinecode,
       a.itemspec_vchr as medicinespec,
       a.itemname_vchr as medicinename,
       u.usageid_chr as medicineusage,
       q.freqname_chr as medicinefrequency,
       a.dosageunit_chr as medicineunit,
       a.dosage_dec as medicinedosage,
       trim(a.days_int) as medicinedays,
       a.discount_dec as medicinescale,
       a.tolqty_dec as unitnumber,
       a.unitprice_mny as unitprice,
       v.totalsum_mny as totalprice,
       v.invoiceno_vchr as billno,
       v.status_int as zfbz,
       
       '' as checksamname,
       '' as checkmethodname,
       '' as checkposition,
       b.confirmdesc_vchr as explanation,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
       from t_opr_outpatientpwmrecipede a,
            t_opr_outpatientrecipe b,
            t_bse_patient c,
            t_bse_patientcard d,
            t_bse_employee e,
            t_bse_deptdesc f,
            t_bse_usagetype u,
            t_aid_recipefreq q,
            t_opr_outpatientrecipeinv   v,
            t_bse_chargeitem            p,
            t_bse_medicine              r,
            t_bse_medidrefloadupdrugid  s,
            t_aid_medicinepreptype n
      where b.diagdr_chr = e.empid_chr(+)
        and b.diagdept_chr = f.deptid_chr(+)
        and a.usageid_chr = u.usageid_chr(+)
        and a.freqid_chr = q.freqid_chr(+)
        and a.itemid_chr = p.itemid_chr
        and r.medicineid_chr(+) = p.itemsrcid_vchr 
        and r.medicineid_chr = s.medicineid_chr(+)  
        and d.status_int > 0
        and c.patientid_chr = d.patientcardid_chr
        and b.patientid_chr = c.patientid_chr
        and a.outpatrecipeid_chr = b.outpatrecipeid_chr
        and b.pstauts_int = 2
        and b.outpatrecipeid_chr=v.outpatrecipeid_chr
        and r.medicinepreptype_chr = n.medicinepreptype_chr(+)
        and b.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                 and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
   order by b.outpatrecipeid_chr";

            //中药
            strSQLCM = @"select '457226325' as organcode,
       a.outpatrecipedeid_chr as recipe_seq,
       p.itemopinvtype_chr as itemkind,
       s.drugid_chr as itemid,
       a.tolprice_mny as itemsum,
       trim(a.times_int) as dosagenum,
       nvl(a.rowno_chr,'0') as recipegroup,
       a.usagedetail_vchr as usageremark,
       
       c.lastname_vchr as name,
       c.sex_chr as sex,
       b.paytypeid_chr as kind,
       c.race_vchr as ethnicgroup,
       c.homeaddress_vchr as address,
       c.employer_vchr as jobtitle,
       c.homephone_vchr as phonenumberhome,
       c.contactpersonlastname_vchr as contactperson,
       c.nationality_vchr as nationaligy,
       c.married_chr as maritalstatus,
       c.birth_dat as birthday,
       c.idcard_chr as idnumbers,
       c.insuranceid_vchr as ssid,
       d.patientcardid_chr as clinicno,
       b.outpatrecipeid_chr as visitno,
       b.recorddate_dat as clinicdatetime,
       b.outpatrecipeid_chr as recipeid,
       '0002' as recipetype,
       b.recorddate_dat as recipedatetime,
       b.diagdr_chr as recipecliniciancode,
       e.lastname_vchr as recipeclinicianname,
       b.pstauts_int as flag,
       b.diagdept_chr as recipedeptcode,
       f.deptname_vchr as recipedeptname,
       p.itemcode_vchr as medicinecode,
       a.itemspec_vchr as medicinespec,
       a.itemname_vchr as medicinename,
       a.sumusage_vchr as medicineusage,
       '' as medicinefrequency,
       'g' as medicineunit,
       a.min_qty_dec as medicinedosage,
       trim(a.times_int) as medicinedays,
       a.discount_dec as medicinescale,
       a.qty_dec as unitnumber,
       a.unitprice_mny as unitprice,
       v.totalsum_mny as totalprice,
       v.invoiceno_vchr as billno,
       v.status_int as zfbz,
       
       '' as checksamname,
       '' as checkmethodname,
       '' as checkposition,
       b.confirmdesc_vchr as explanation,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
       from t_opr_outpatientcmrecipede a,
            t_opr_outpatientrecipe b,
            t_bse_patient c,
            t_bse_patientcard d,
            t_bse_employee e,
            t_bse_deptdesc f,
            t_opr_outpatientrecipeinv   v,
            t_bse_chargeitem            p,
            t_bse_medicine              r,
            t_bse_medidrefloadupdrugid  s,
            t_aid_medicinepreptype n
      where b.diagdr_chr = e.empid_chr(+)
        and b.diagdept_chr = f.deptid_chr(+)
        and a.itemid_chr = p.itemid_chr
        and r.medicineid_chr(+) = p.itemsrcid_vchr 
        and r.medicineid_chr = s.medicineid_chr(+)  
        and d.status_int > 0
        and c.patientid_chr = d.patientcardid_chr
        and b.patientid_chr = c.patientid_chr
        and a.outpatrecipeid_chr = b.outpatrecipeid_chr
        and b.pstauts_int = 2
        and b.outpatrecipeid_chr=v.outpatrecipeid_chr
        and r.medicinepreptype_chr = n.medicinepreptype_chr(+)
        and b.recorddate_dat between
            to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
            to_date(?, 'yyyy-mm-dd hh24:mi:ss')
      order by b.outpatrecipeid_chr";

            //检验
            strSQLLIS = @"select '457226325' as organcode,
       a.outpatrecipedeid_chr as recipe_seq,
       p.itemopinvtype_chr as itemkind,
       s.drugid_chr as itemid,
       a.tolprice_mny as itemsum,
       '' as dosagenum,
       '0' as recipegroup,
       '' as usageremark,         

       c.lastname_vchr as name,
       c.sex_chr as sex,
       b.paytypeid_chr as kind,
       c.race_vchr as ethnicgroup,
       c.homeaddress_vchr as address,
       c.employer_vchr as jobtitle,
       c.homephone_vchr as phonenumberhome,
       c.contactpersonlastname_vchr as contactperson,
       c.nationality_vchr as nationaligy,
       c.married_chr as maritalstatus,
       c.birth_dat as birthday,
       c.idcard_chr as idnumbers,
       c.insuranceid_vchr as ssid,
       d.patientcardid_chr as clinicno,
       b.outpatrecipeid_chr as visitno,
       b.recorddate_dat as clinicdatetime,
       b.outpatrecipeid_chr as recipeid,
       '0003' as recipetype,
       b.recorddate_dat as recipedatetime,
       b.diagdr_chr as recipecliniciancode,
       e.lastname_vchr as recipeclinicianname,
       b.pstauts_int as flag,
       b.diagdept_chr as recipedeptcode,
       f.deptname_vchr as recipedeptname,
       p.itemcode_vchr as medicinecode,
       a.itemspec_vchr as medicinespec,
       a.itemname_vchr as medicinename,
       a.itemusagedetail_vchr as medicineusage,
       '' as medicinefrequency,
       a.itemunit_vchr as medicineunit,
       a.qty_dec as medicinedosage,
       '' as medicinedays,
       a.discount_dec as medicinescale,
       a.qty_dec as unitnumber,
       a.price_mny as unitprice,
       v.totalsum_mny as totalprice,
       v.invoiceno_vchr as billno,
       v.status_int as zfbz,
       
       h.sampletype_vchr as checksamname,
       '' as checkmethodname,
       '' as checkposition,
       b.confirmdesc_vchr as explanation,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
  from t_opr_outpatientchkrecipede a,
       t_opr_outpatientrecipe      b,
       t_bse_patient               c,
       t_bse_patientcard           d,
       t_bse_employee              e,
       t_bse_deptdesc              f,
       t_opr_outpatientrecipeinv   v,
       t_opr_attachrelation        g,
       t_opr_lis_sample            h,
       t_bse_chargeitem            p,
       t_bse_medicine              r,
       t_bse_medidrefloadupdrugid  s,
       t_aid_medicinepreptype n
 where b.diagdr_chr = e.empid_chr(+)
   and b.diagdept_chr = f.deptid_chr(+)
   and a.outpatrecipeid_chr = g.sourceitemid_vchr
   and g.attachid_vchr = h.application_id_chr
   and a.itemid_chr = p.itemid_chr
   and r.medicineid_chr(+) = p.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+)  
   and d.status_int > 0
   and c.patientid_chr = d.patientcardid_chr
   and b.patientid_chr = c.patientid_chr
   and a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.pstauts_int = 2
   and b.outpatrecipeid_chr = v.outpatrecipeid_chr
   and r.medicinepreptype_chr = n.medicinepreptype_chr(+)
   and b.recorddate_dat between
     to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
     to_date(?, 'yyyy-mm-dd hh24:mi:ss')
  order by b.outpatrecipeid_chr";

            //检查
            strSQLTEST = @"select '457226325' as organcode,
       a.outpatrecipedeid_chr as recipe_seq,
       p.itemopinvtype_chr as itemkind,
       s.drugid_chr as itemid,
       a.tolprice_mny as itemsum,
       '' as dosagenum,
       '0' as recipegroup,       
       '' as usageremark,  
        
       c.lastname_vchr as name,
       c.sex_chr as sex,
       b.paytypeid_chr as kind,
       c.race_vchr as ethnicgroup,
       c.homeaddress_vchr as address,
       c.employer_vchr as jobtitle,
       c.homephone_vchr as phonenumberhome,
       c.contactpersonlastname_vchr as contactperson,
       c.nationality_vchr as nationaligy,
       c.married_chr as maritalstatus,
       c.birth_dat as birthday,
       c.idcard_chr as idnumbers,
       c.insuranceid_vchr as ssid,
       d.patientcardid_chr as clinicno,
       b.outpatrecipeid_chr as visitno,
       b.recorddate_dat as clinicdatetime,
       b.outpatrecipeid_chr as recipeid,
       '0004' as recipetype,
       b.recorddate_dat as recipedatetime,
       b.diagdr_chr as recipecliniciancode,
       e.lastname_vchr as recipeclinicianname,
       b.pstauts_int as flag,
       b.diagdept_chr as recipedeptcode,
       f.deptname_vchr as recipedeptname,
       p.itemcode_vchr as medicinecode,
       a.itemspec_vchr as medicinespec,
       a.itemname_vchr as medicinename,
       a.itemusagedetail_vchr as medicineusage,
       '' as medicinefrequency,
       a.itemunit_vchr as medicineunit,
       a.qty_dec as medicinedosage,
       '' as medicinedays,
       a.discount_dec as medicinescale,
       a.qty_dec as unitnumber,
       a.price_mny as unitprice,
       v.totalsum_mny as totalprice,
       v.invoiceno_vchr as billno,
       v.status_int as zfbz,
       
       '' as checksamname,
       h.applytitle as checkmethodname,
       h.diagnosepart as checkposition,
       b.confirmdesc_vchr as explanation,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
  from t_opr_outpatienttestrecipede a,
       t_opr_outpatientrecipe       b,
       t_bse_patient                c,
       t_bse_patientcard            d,
       t_bse_employee               e,
       t_bse_deptdesc               f,
       t_opr_outpatientrecipeinv    v,
       t_opr_attachrelation         g,
       ar_common_apply              h,
       t_bse_chargeitem             p,
       t_bse_medicine               r,
       t_bse_medidrefloadupdrugid   s,
       t_aid_medicinepreptype n
 where b.diagdr_chr = e.empid_chr(+)
   and b.diagdept_chr = f.deptid_chr(+)
   and g.sourceitemid_vchr = a.outpatrecipeid_chr
   and g.attachid_vchr = h.applyid
   and p.itemid_chr = a.itemid_chr
   and r.medicineid_chr(+) = p.itemsrcid_vchr 
   and r.medicineid_chr = s.medicineid_chr(+)  
   and d.status_int > 0
   and c.patientid_chr = d.patientcardid_chr
   and b.patientid_chr = c.patientid_chr
   and a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.pstauts_int = 2
   and b.outpatrecipeid_chr = v.outpatrecipeid_chr
   and r.medicinepreptype_chr = n.medicinepreptype_chr(+)
   and b.recorddate_dat between
      to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
      to_date(?, 'yyyy-mm-dd hh24:mi:ss')
   order by b.outpatrecipeid_chr";

            //手术治疗
            strSQLOP = @"select '457226325' as organcode,
       a.outpatrecipedeid_chr as recipe_seq,
       p.itemopinvtype_chr as itemkind,
       s.drugid_chr as itemid,
       a.tolprice_mny as itemsum,
       '' as dosagenum,
       '0' as recipegroup,  
       '' as usageremark,       

       c.lastname_vchr as name,
       c.sex_chr as sex,
       b.paytypeid_chr as kind,
       c.race_vchr as ethnicgroup,
       c.homeaddress_vchr as address,
       c.employer_vchr as jobtitle,
       c.homephone_vchr as phonenumberhome,
       c.contactpersonlastname_vchr as contactperson,
       c.nationality_vchr as nationaligy,
       c.married_chr as maritalstatus,
       c.birth_dat as birthday,
       c.idcard_chr as idnumbers,
       c.insuranceid_vchr as ssid,
       d.patientcardid_chr as clinicno,
       b.outpatrecipeid_chr as visitno,
       b.recorddate_dat as clinicdatetime,
       b.outpatrecipeid_chr as recipeid,
       '0007' as recipetype,
       b.recorddate_dat as recipedatetime,
       b.diagdr_chr as recipecliniciancode,
       e.lastname_vchr as recipeclinicianname,
       b.pstauts_int as flag,
       b.diagdept_chr as recipedeptcode,
       f.deptname_vchr as recipedeptname,
       p.itemcode_vchr as medicinecode,
       a.itemspec_vchr as medicinespec,
       a.itemname_vchr as medicinename,
       a.itemusagedetail_vchr as medicineusage,
       '' as medicinefrequency,
       a.itemunit_vchr as medicineunit,
       a.qty_dec as medicinedosage,
       '' as medicinedays,
       a.discount_dec as medicinescale,
       a.qty_dec as unitnumber,
       a.price_mny as unitprice,
       v.totalsum_mny as totalprice,
       v.invoiceno_vchr as billno,
       v.status_int as zfbz,
       
       '' as checksamname,
       '' as checkmethodname,
       '' as checkposition,
       b.confirmdesc_vchr as explanation,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
       from t_opr_outpatientopsrecipede a,
            t_opr_outpatientrecipe b,
            t_bse_patient c,
            t_bse_patientcard d,
            t_bse_employee e,
            t_bse_deptdesc f,
            t_opr_outpatientrecipeinv   v,
            t_bse_chargeitem            p,
            t_bse_medicine              r,
            t_bse_medidrefloadupdrugid  s,
            t_aid_medicinepreptype n
      where b.diagdr_chr = e.empid_chr(+)
        and b.diagdept_chr = f.deptid_chr(+)
        and p.itemid_chr = a.itemid_chr
        and r.medicineid_chr(+) = p.itemsrcid_vchr 
        and r.medicineid_chr = s.medicineid_chr(+)  
        and d.status_int > 0
        and c.patientid_chr = d.patientcardid_chr
        and b.patientid_chr = c.patientid_chr
        and a.outpatrecipeid_chr = b.outpatrecipeid_chr
        and b.pstauts_int = 2
        and b.outpatrecipeid_chr=v.outpatrecipeid_chr
        and r.medicinepreptype_chr = n.medicinepreptype_chr(+)
        and b.recorddate_dat between
            to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
            to_date(?, 'yyyy-mm-dd hh24:mi:ss')
      order by b.outpatrecipeid_chr";

            //其它
            strSQLOTH = @"select '457226325' as organcode,
       a.outpatrecipedeid_chr as recipe_seq,
       p.itemopinvtype_chr as itemkind,
       s.drugid_chr as itemid,
       a.tolprice_mny as itemsum,
       '' as dosagenum,
       '0' as recipegroup, 
       '' as USAGEREMARK,      

       c.lastname_vchr as name,
       c.sex_chr as sex,
       b.paytypeid_chr as kind,
       c.race_vchr as ethnicgroup,
       c.homeaddress_vchr as address,
       c.employer_vchr as jobtitle,
       c.homephone_vchr as phonenumberhome,
       c.contactpersonlastname_vchr as contactperson,
       c.nationality_vchr as nationaligy,
       c.married_chr as maritalstatus,
       c.birth_dat as birthday,
       c.idcard_chr as idnumbers,
       c.insuranceid_vchr as ssid,
       d.patientcardid_chr as clinicno,
       b.outpatrecipeid_chr as visitno,
       b.recorddate_dat as clinicdatetime,
       b.outpatrecipeid_chr as recipeid,
       '0006' as recipetype,
       b.recorddate_dat as recipedatetime,
       b.diagdr_chr as recipecliniciancode,
       e.lastname_vchr as recipeclinicianname,
       b.pstauts_int as flag,
       b.diagdept_chr as recipedeptcode,
       f.deptname_vchr as recipedeptname,
       p.itemcode_vchr as medicinecode,
       a.itemspec_vchr as medicinespec,
       a.itemname_vchr as medicinename,
       a.itemusagedetail_vchr as medicineusage,
       '' as medicinefrequency,
       a.itemunit_vchr as medicineunit,
       a.qty_dec as medicinedosage,
       '' as medicinedays,
       a.discount_dec as medicinescale,
       a.qty_dec as unitnumber,
       a.unitprice_mny as unitprice,
       v.totalsum_mny as totalprice,
       v.invoiceno_vchr as billno,
       v.status_int as zfbz,
       
       '' as checksamname,
       '' as checkmethodname,
       '' as checkposition,
       b.confirmdesc_vchr as explanation,
       decode(n.flaga_int,1,'01',2,'02','99') as JXBZDM
        from t_opr_outpatientothrecipede a,
             t_opr_outpatientrecipe b,
             t_bse_patient c,
             t_bse_patientcard d,
             t_bse_employee e,
             t_bse_deptdesc f,
             t_opr_outpatientrecipeinv   v,
             t_bse_chargeitem            p,
             t_bse_medicine              r,
             t_bse_medidrefloadupdrugid  s,
             t_aid_medicinepreptype n
     where b.diagdr_chr = e.empid_chr(+)
       and b.diagdept_chr = f.deptid_chr(+)
       and p.itemid_chr = a.itemid_chr
       and r.medicineid_chr(+) = p.itemsrcid_vchr 
       and r.medicineid_chr = s.medicineid_chr(+)  
       and d.status_int > 0
       and c.patientid_chr = d.patientcardid_chr
       and b.patientid_chr = c.patientid_chr
       and a.outpatrecipeid_chr = b.outpatrecipeid_chr
       and b.pstauts_int = 2
        and b.outpatrecipeid_chr=v.outpatrecipeid_chr
        and r.medicinepreptype_chr = n.medicinepreptype_chr(+)
       and b.recorddate_dat between
           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
     order by b.outpatrecipeid_chr";
            #endregion
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {
                DataTable dtbAll = new DataTable();
                DataTable dtbResult = null;
                //DateTime datDown = DateTime.Now.AddDays(-1);
                DateTime datDown = datUpload;
                //西药
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLWM, ref dtbResult, objDPArr);
                dtbAll = dtbResult.Copy();
                //中药
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLCM, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //检验
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLLIS, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //检查
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLTEST, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //手术治疗
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLOP, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);
                //其他
                objDPArr = null;
                dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = datDown.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datDown.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLOTH, ref dtbResult, objDPArr);
                dtbAll.Merge(dtbResult);

                if (lngRes > 0 && dtbAll != null)
                {
                    DataView dv = dtbAll.DefaultView;
                    dv.Sort = "visitno, medicinecode, unitprice, medicineusage, medicinefrequency, medicinedays, medicinedosage";
                    dtbAll = dv.ToTable();
                    lstRecInfo = new List<clsRecInfo_VO>();
                    DataRow dr = null;
                    clsRecInfo_VO objRecord = null;
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    for (int i1 = 0; i1 < dtbAll.Rows.Count; i1++)
                    {
                        objRecord = new clsRecInfo_VO();
                        dr = dtbAll.Rows[i1];
                        objRecord.m_strORGANCODE = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                        objRecord.m_strNAME = dr["name"].ToString().Trim();
                        objRecord.m_strSEX = clsDataUpload_Svc.m_strConvertValue("sex", dr["sex"].ToString().Trim(), "*");
                        objRecord.m_strKIND = clsDataUpload_Svc.m_strConvertValue("kind", dr["kind"].ToString().Trim(), "");
                        objRecord.m_strETHNICGROUP = clsDataUpload_Svc.m_strConvertValue("ethnicgroup", dr["ethnicgroup"].ToString().Trim(), "");
                        objRecord.m_strADDRESS = dr["address"].ToString().Trim();
                        objRecord.m_strJOBTITLE = dr["jobtitle"].ToString().Trim();
                        objRecord.m_strPHONENUMBERHOME = dr["phonenumberhome"].ToString().Trim();
                        objRecord.m_strCONTACTPERSON = dr["contactperson"].ToString().Trim();
                        objRecord.m_strNATIONALITY = dr["nationaligy"].ToString().Trim();
                        objRecord.m_intMARITALSTATUS = (dr["maritalstatus"].ToString().Trim() == "已婚" ? 2 : 1);
                        objRecord.m_strBIRTHDAY = dr["birthday"].ToString().Trim();
                        objRecord.m_strIDNUMBERS = dr["idnumbers"].ToString().Trim();
                        objRecord.m_strSSID = dr["ssid"].ToString().Trim();
                        objRecord.m_strCLINICNO = dr["clinicno"].ToString().Trim();
                        objRecord.m_strVISITNO = dr["visitno"].ToString().Trim();
                        objRecord.m_strCLINICDATETIME = ConvertObjToDateTime(dr["clinicdatetime"]);
                        objRecord.m_strRecipeID = dr["recipeid"].ToString().Trim();
                        objRecord.m_intRecipeType = int.Parse(clsDataUpload_Svc.m_strConvertValue("recipetype", dr["recipetype"].ToString().Trim(), "0"));
                        objRecord.m_strRecipeDateTime = ConvertObjToDateTime(dr["recipedatetime"]);
                        objRecord.m_strRecipeClinicianCode = ConvertObjToValue(dr["recipecliniciancode"].ToString().Trim(), "*");
                        objRecord.m_strRecipeClinicianName = ConvertObjToValue(dr["recipeclinicianname"].ToString().Trim(), "*");
                        objRecord.m_intFlag = Convert.ToInt32(ConvertObjToDecimal(dr["flag"]));
                        objRecord.m_strRecipeDeptCode = ConvertObjToValue(dr["recipedeptcode"].ToString().Trim(), "*");
                        objRecord.m_strRecipeDeptName = ConvertObjToValue(dr["recipedeptname"].ToString().Trim(), "*");
                        objRecord.m_strMedicineCode = ConvertObjToValue(dr["medicinecode"].ToString().Trim(), "*");
                        objRecord.m_strMedicineSpec = ConvertObjToValue(dr["medicinespec"].ToString().Trim(), "");
                        objRecord.m_strMedicineName = ConvertObjToValue(dr["medicinename"].ToString().Trim(), "*");
                        objRecord.m_intMedicineUsage = int.Parse(clsDataUpload_Svc.m_strConvertValue("medicineusage", dr["medicineusage"].ToString().Trim(), "99"));
                        objRecord.m_strMedicineFrequency = clsDataUpload_Svc.m_strConvertValue("Frequency", dr["medicinefrequency"].ToString().Trim(), "99");
                        objRecord.m_strMedicineUnit = ConvertObjToValue(dr["medicineunit"].ToString().Trim(), "*");
                        objRecord.m_strMedicineDosage = ConvertObjToValue(dr["medicinedosage"].ToString().Trim(), "");
                        objRecord.m_strUseUnit = ConvertObjToValue(dr["medicineunit"].ToString().Trim(), "");
                        objRecord.m_strMedicineDays = ConvertObjToValue(dr["medicinedays"].ToString().Trim(), "");
                        objRecord.m_decMedicineScale = ConvertObjToDecimal(dr["medicinescale"]);
                        objRecord.m_decUnitNumber = ConvertObjToDecimal(dr["unitnumber"]);
                        objRecord.m_decUnitPrice = ConvertObjToDecimal(dr["unitprice"]);
                        objRecord.m_decTotalPrice = ConvertObjToDecimal(dr["totalprice"]);
                        // add 发票号和作废标识 by huafeng.xiao
                        objRecord.m_strBILLNO = ConvertObjToValue(dr["billno"].ToString().Trim(), "*");
                        objRecord.m_strZfbz = clsDataUpload_Svc.m_strConvertValue("zfbz", dr["zfbz"].ToString().Trim(), "0");

                        objRecord.m_strRECIPE_SEQ = dr["recipe_seq"].ToString().Trim();
                        //objRecord.m_strITEMKIND = dr["itemkind"].ToString().Trim();
                        objRecord.m_strITEMKIND = clsDataUpload_Svc.m_strConvertValue("billkind", dr["itemkind"].ToString().Trim(), "99");
                        objRecord.m_strITEMID = dr["itemid"].ToString().Trim();
                        objRecord.m_decITEMSUM = ConvertObjToDecimal(dr["itemsum"]);

                        objRecord.m_strCHECKSAMNAME = dr["checksamname"].ToString().Trim();
                        objRecord.m_strCHECKMETHODNAME = dr["checkmethodname"].ToString().Trim();
                        objRecord.m_strCHECKPOSITION = dr["checkposition"].ToString().Trim();
                        objRecord.m_strEXPLANATION = dr["explanation"].ToString().Trim();
                        objRecord.m_strRECIPEGROUP = dr["recipegroup"].ToString().Trim();
                        objRecord.m_decDOSAGENUM = ConvertObjToDecimal(dr["dosagenum"]);
                        objRecord.m_strJXBZDM = dr["JXBZDM"].ToString().Trim();

                        //int.Parse(clsDataUpload_Svc.m_strConvertValue("dosagenum", dr["dosagenum"].ToString().Trim(), "0"));
                        //dr["dosagenum"].ToString().Trim();
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strRecipeID + objRecord.m_strVISITNO + objRecord.m_strRecipeDateTime + objRecord.m_strRecipeClinicianCode + objRecord.m_strRecipeDeptCode + objRecord.m_strMedicineCode, "");
                            lstRecInfo.Add(objRecord);
                        }
                        catch { }
                        //  lstRecInfo.Add(objRecord);
                    }
                    arrRecInfo_VO = lstRecInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 查询收费标准信息
        /// <summary>
        /// 查询收费标准信息
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrChargeitem_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, DateTime datUpload, out clsChargeStandard_VO[] arrChargeitem_VO)
        {
            long lngRes = 0;
            arrChargeitem_VO = null;
            string strSQL = @"select '457226325' organcode,
d.drugid_chr as itemid_chr,
a.itemcode_vchr,
a.itemengname_vchr,
       a.itemname_vchr,
       a.itempycode_chr,
       a.itemprice_mny,
       '' as collectdate,
       a.itemspec_vchr,
       a.itemopunit_chr,
       decode(b.medicnetype_int,
              1,
              '西药',
              2,
              '中药',
              3,
              '药料',
              4,
              '中西药',
              '其他') as medtype,
      c.medicinepreptypename_vchr,
       a.itemopinvtype_chr as itemkind,
       decode(c.flaga_int, 1, '01', 2, '02', '99') as JXBZDM,
       a.ifstop_int
  from t_bse_chargeitem a, t_bse_medicine b, t_aid_medicinepreptype c,t_bse_medidrefloadupdrugid d
 where a.itemsrcid_vchr = b.medicineid_chr(+)
   and b.medicinepreptype_chr = c.medicinepreptype_chr(+)
   and b.medicineid_chr(+) = a.itemsrcid_vchr 
   and b.medicineid_chr = d.medicineid_chr(+)  
   and a.itemcatid_chr <> '-1'
   and a.itemcatid_chr is not null";
            Hashtable objHsTable = new Hashtable();
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                DataTable dtbResult = null;
                IDataParameter[] paraArr = null;
                //objHRPSvc.CreateDatabaseParameter(2, out paraArr);
                //paraArr[0].Value = p_dtmStartDate;
                //paraArr[1].Value = p_dtmEndDate;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, paraArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null)
                {
                    int intRowCount = dtbResult.Rows.Count;
                    List<clsChargeStandard_VO> objLstCs = new List<clsChargeStandard_VO>();
                    arrChargeitem_VO = new clsChargeStandard_VO[intRowCount];
                    DataRow dr = null;
                    DateTime datNow = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    decimal d = 0;
                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        dr = dtbResult.Rows[i1];
                        arrChargeitem_VO[i1] = new clsChargeStandard_VO();
                        arrChargeitem_VO[i1].m_strORGANCODE = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                        arrChargeitem_VO[i1].m_strITEMID = dr["itemid_chr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strBILLCODE = dr["itemcode_vchr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strBILLENNAME = dr["itemengname_vchr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strBILLNAME = dr["itemname_vchr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strMNEMOTECHNICS = dr["itempycode_chr"].ToString().Trim();
                        decimal.TryParse(dr["itemprice_mny"].ToString().Trim(), out d);
                        arrChargeitem_VO[i1].m_decUNITPRICE = d;
                        arrChargeitem_VO[i1].m_datCOLLECTDATE = datNow;
                        arrChargeitem_VO[i1].m_strSPEC = dr["itemspec_vchr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strUNIT = dr["itemopunit_chr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strREAGENT = dr["medicinepreptypename_vchr"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strMEDSPEC = dr["medtype"].ToString().Trim();
                        //arrChargeitem_VO[i1].m_strBILLKIND = dr["itemkind"].ToString().Trim();
                        //arrChargeitem_VO[i1].m_strFLBZ = clsDataUpload_Svc.m_strConvertValue("flbz", dr["itemcatid_chr"].ToString().Trim(), "0");
                        arrChargeitem_VO[i1].m_strBILLKIND = clsDataUpload_Svc.m_strConvertValue("billkind", dr["itemkind"].ToString().Trim(), "99");
                        arrChargeitem_VO[i1].m_strJXBZDM = dr["JXBZDM"].ToString().Trim();
                        arrChargeitem_VO[i1].m_strISDISABLE = dr["ifstop_int"].ToString().Trim();
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(arrChargeitem_VO[i1].m_strBILLCODE + arrChargeitem_VO[i1].m_strBILLNAME, "");
                            objLstCs.Add(arrChargeitem_VO[i1]);
                        }
                        catch { }
                    }
                    arrChargeitem_VO = objLstCs.ToArray();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 查询药品信息
        /// <summary>
        /// 查询药品信息
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrRecInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDrugInfo(DateTime datUpload, out clsDrugInfo_VO[] arrRecInfo_VO)
        {
            long lngRes = 0;
            arrRecInfo_VO = null;
            string strSQL = @"select i.drugid_chr as DrugID,
       g.mednormalname_vchr as GENERICNAME,
       g.medicinename_vchr as TRADENAME,
       h.medicinetypename_vchr as FORMULA,
       g.medspec_vchr as SPEC,
       g.packqty_dec as PACKINGSPEC,
       g.opunit_chr UNIT,
       g.permitno_vchr as APPROVEDNO,
       '' as BATCHNO,
       '' as PURCHASEDATE,
       e.useamount as USEAMOUNT,
       f.currentgross_num as STOREAMOUNT,
       g.pharmaid_chr as MEDSPEC
  from (select d.itemid_chr, sum(d.qty_dec) as useamount
          from (select a.itemid_chr, a.qty_dec
                  from t_opr_oprecipeitemde a, t_opr_outpatientrecipe b
                 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                   and b.recorddate_dat between
                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                   and b.pstauts_int = 2
                
                union all
                
                select c.medid_chr, c.get_dec
                  from t_bih_opr_putmeddetail c
                 where c.isput_int = 1
                   and c.pubdate_dat between
                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')) d
         group by d.itemid_chr) e,
       t_ms_storage f,
       t_bse_medicine g,
       t_aid_medicinetype h,
       t_bse_medidrefloadupdrugid i
 where e.itemid_chr = f.medicineid_chr(+)
   and e.itemid_chr = g.medicineid_chr
   and g.medicinetypeid_chr = h.medicinetypeid_chr
   and e.itemid_chr=i.medicineid_chr";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {

                DataTable dt = null;
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = datUpload.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = datUpload.ToString("yyyy-MM-dd 23:59:59");
                objDPArr[2].Value = datUpload.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[3].Value = datUpload.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                if (lngRes > 0 && dt != null)
                {
                    List<clsDrugInfo_VO> lstDrugInfo = new List<clsDrugInfo_VO>();
                    clsDrugInfo_VO objRecord = null;
                    DataRow dr = null;
                    string strDateNow = DateTime.Now.ToString("yyyy-MM-dd");
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        dr = dt.Rows[i1];
                        objRecord = new clsDrugInfo_VO();
                        objRecord.m_strDrugID = dr["drugid"].ToString().Trim();
                        objRecord.m_strGENERICNAME = ConvertObjToValue(dr["genericname"].ToString().Trim(), "*");
                        objRecord.m_strTRADENAME = ConvertObjToValue(dr["tradename"].ToString().Trim(), "*");
                        objRecord.m_strFORMULA = ConvertObjToValue(dr["formula"].ToString().Trim(), "*");
                        objRecord.m_strSPEC = ConvertObjToValue(dr["spec"].ToString().Trim(), "*");
                        objRecord.m_strPACKINGSPEC = dr["packingspec"].ToString().Trim();
                        objRecord.m_strUNIT = ConvertObjToValue(dr["unit"].ToString().Trim(), "*");
                        objRecord.m_strAPPROVEDNO = ConvertObjToValue(dr["approvedno"].ToString().Trim(), "");
                        objRecord.m_strBATCHNO = "-----";
                        objRecord.m_strPURCHASEDATE = strDateNow;
                        objRecord.m_intUSEAMOUNT = Convert.ToInt32(ConvertObjToDecimal(dr["useamount"]));
                        objRecord.m_intSTOREAMOUNT = Convert.ToInt32(ConvertObjToDecimal(dr["storeamount"]));
                        objRecord.m_strMEDSPEC = dr["medspec"].ToString().Trim();
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strDrugID, "");
                            lstDrugInfo.Add(objRecord);
                        }
                        catch { }
                       // lstDrugInfo.Add(objRecord);
                    }
                    arrRecInfo_VO = lstDrugInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 将对象转换为数字
        /// <summary>
        /// 将对象转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return Convert.ToDecimal(obj.ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 将对象转换为日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertObjToDateTime(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return obj.ToString();
                }
                else
                {
                    return "1900-01-01 00:00:00";
                }
            }
            catch
            {
                return "1900-01-01 00:00:00";
            }
        }

        /// <summary>
        /// 将字符串转换为非空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defalutval"></param>
        /// <returns></returns>
        public static string ConvertObjToValue(string str, string defalutval)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defalutval;
            }
            return str;
        }
        #endregion

        #region 查询入库信息
        /// <summary>
        /// 查询入库信息
        /// </summary>
        /// <param name="p_datForUpload"></param>
        /// <param name="p_arrInStorageInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInStorageInfo(DateTime p_datForUpload, out clsInStorageInfo_VO[] p_arrInStorageInfo_VO)
        {
            long lngRes = 0;
            p_arrInStorageInfo_VO = null;
            string strSQL = @"select '457226325' organcode,
       a.seriesid_int warehousing_seq,
       b.storageid_chr drugstoreid,
       b.instorageid_vchr warehousing_number,
       d.drugid_chr itemid,
       decode(c.ordercateid_chr, '07', 1, '09', 3, '10', 12, 99) itemkind,
       a.medicineid_chr h_drugid,
       decode(c.mednormalname_vchr,
              '',
              c.medicinename_vchr,
              c.mednormalname_vchr) genericname,
       c.medspec_vchr spec,
       e.flaga_int formula,
       a.amount input_amount,
       a.callprice_int buy_price,
       a.retailprice_int retail_price,
       a.invoicecode_vchr invoice_no,
       a.invoicedater_dat invoice_date,
       a.productorid_chr manufacturer,
       f.vendorname_vchr supply,
       a.validperiod_dat effective_date,
       a.lotno_vchr batchno,
       decode(b.formtype_int, 1, 1, 9) flag,
       a.approvecode_vchr approvedno,
       b.exam_dat input_date,
       sysdate upload_date
  from t_ms_instorage_detal a
  left join t_ms_instorage b
    on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c
    on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medidrefloadupdrugid d
    on d.medicineid_chr = a.medicineid_chr
  left join t_aid_medicinepreptype e
    on e.medicinepreptype_chr = c.medicinepreptype_chr
  left join t_bse_vendor f
    on f.vendorid_chr = b.vendorid_chr
 where b.state_int > 1 and c.medicinetypeid_chr in (1,2,6,7)
   and a.status = 1
   and a.amount > 0
   and b.exam_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {

                DataTable dt = null;
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_datForUpload.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = p_datForUpload.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                if (lngRes > 0 && dt != null)
                {
                    List<clsInStorageInfo_VO> lstInStorageInfo = new List<clsInStorageInfo_VO>();
                    clsInStorageInfo_VO objRecord = null;
                    DateTime dtmTemp = DateTime.Now;
                    DataRow dr = null;
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        dr = dt.Rows[i1];
                        objRecord = new clsInStorageInfo_VO();
                        objRecord.m_strORGANCODE = dr["ORGANCODE"].ToString().Trim();
                        objRecord.m_strWAREHOUSING_SEQ = dr["WAREHOUSING_SEQ"].ToString();
                        objRecord.m_strDRUGSTOREID = dr["DRUGSTOREID"].ToString();
                        objRecord.m_strWAREHOUSING_NUMBER = dr["WAREHOUSING_NUMBER"].ToString();
                        objRecord.m_strITEMID = ConvertObjToValue(dr["ITEMID"].ToString(), "*");
                        objRecord.m_strITEMKIND = dr["ITEMKIND"].ToString();
                        objRecord.m_strH_DRUGID = dr["H_DRUGID"].ToString();
                        objRecord.m_strGENERICNAME = dr["GENERICNAME"].ToString();
                        objRecord.m_strSPEC = dr["SPEC"].ToString();
                        if(dr["FORMULA"].ToString()  == "1")
                        {
                            objRecord.m_strFORMULA = "01";
                        }
                        else if (dr["FORMULA"].ToString() == "2")
                        {
                            objRecord.m_strFORMULA = "02";
                        }
                        else
                        {
                            objRecord.m_strFORMULA = "99";
                        }
                        objRecord.m_dblINPUT_AMOUNT = ConvertObjToDecimal(dr["INPUT_AMOUNT"]);
                        objRecord.m_dblBUY_PRICE = ConvertObjToDecimal(dr["BUY_PRICE"]);
                        objRecord.m_dblRETAIL_PRICE = ConvertObjToDecimal(dr["RETAIL_PRICE"]);
                        objRecord.m_strINVOICE_NO = dr["INVOICE_NO"].ToString();
                        DateTime.TryParse(dr["INVOICE_DATE"].ToString(), out dtmTemp);
                        if (Convert.ToDateTime(dtmTemp).ToString("yyyy-MM-dd") != "0001-01-01")
                        {
                            objRecord.m_dtmINVOICE_DATE = dtmTemp;
                        }
                        objRecord.m_strMANUFACTURER = dr["MANUFACTURER"].ToString();
                        objRecord.m_strSUPPLY = dr["SUPPLY"].ToString();
                        if (Convert.ToDateTime(dtmTemp).ToString("yyyy-MM-dd") != "0001-01-01")
                        {
                            DateTime.TryParse(dr["EFFECTIVE_DATE"].ToString(), out dtmTemp);
                        }
                        objRecord.m_dtmEFFECTIVE_DATE = dtmTemp;                        
                        objRecord.m_strBATCHNO = ConvertObjToValue(dr["BATCHNO"].ToString(), "*");
                        objRecord.m_strFLAG = dr["FLAG"].ToString();
                        objRecord.m_strAPPROVEDNO = dr["APPROVEDNO"].ToString();
                        objRecord.m_dtmINPUT_DATE = Convert.ToDateTime(dr["INPUT_DATE"]);
                        objRecord.m_dtmUPLOAD_DATE = Convert.ToDateTime(dr["UPLOAD_DATE"]);
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strWAREHOUSING_SEQ, "");
                            lstInStorageInfo.Add(objRecord);
                        }
                        catch { }
                        // lstDrugInfo.Add(objRecord);
                    }
                    p_arrInStorageInfo_VO = lstInStorageInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 查询出库信息
        /// <summary>
        /// 查询出库信息
        /// </summary>
        /// <param name="p_datForUpload"></param>
        /// <param name="p_arrOutStorageInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageInfo(DateTime p_datForUpload, out clsOutStorageInfo_VO[] p_arrOutStorageInfo_VO)
        {
            long lngRes = 0;
            p_arrOutStorageInfo_VO = null;
            string strSQL = @"select '457226325' organcode,
       a.seriesid_int operator_seq,
       b.storageid_chr drugstoreid,
       b.outstorageid_vchr shipping_no,
       c.medicineid_chr itemid,
       decode(d.ordercateid_chr, '07', 1, '09', 3, '10', 12, 99) itemkind,
       a.medicineid_chr h_drugid,
       decode(d.mednormalname_vchr,
              '',
              d.medicinename_vchr,
              d.mednormalname_vchr) genericname,
       d.medspec_vchr spec,
       e.flaga_int formula,
       a.netamount_int output_amount,
       a.callprice_int buy_price,
       a.retailprice_int retail_price,
       a.lotno_vchr batchno,
       d.productorid_chr manufacturer,
       g.vendorname_vchr supply,
       a.validperiod_dat effective_date,
       a.instorageid_vchr warehousing_number,
       b.examdate_dat shipping_date,
       decode(b.formtype, 1, 1, 4, 2, 9) flag,
       sysdate upload_date
  from t_ms_outstorage_detail a
  left join t_ms_outstorage b
    on b.seriesid_int = a.seriesid2_int
  left join t_bse_medidrefloadupdrugid c
    on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medicine d
    on d.medicineid_chr = a.medicineid_chr
  left join t_aid_medicinepreptype e
    on e.medicinepreptype_chr = d.medicinepreptype_chr  
  left join t_bse_vendor g
    on g.vendorid_chr = a.vendorid_chr
 where a.status = 1 and d.medicinetypeid_chr in (1,2,6,7)
   and b.status > 1
   and a.netamount_int > 0
   and b.examdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {

                DataTable dt = null;
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_datForUpload.ToString("yyyy-MM-dd 00:00:00");
                objDPArr[1].Value = p_datForUpload.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                if (lngRes > 0 && dt != null)
                {
                    List<clsOutStorageInfo_VO> lstOutStorageInfo = new List<clsOutStorageInfo_VO>();
                    clsOutStorageInfo_VO objRecord = null;
                    DateTime dtmTemp = DateTime.Now;
                    DataRow dr = null;
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        dr = dt.Rows[i1];
                        objRecord = new clsOutStorageInfo_VO();
                        objRecord.m_strORGANCODE = dr["ORGANCODE"].ToString().Trim();
                        objRecord.m_strOPERATOR_SEQ = dr["OPERATOR_SEQ"].ToString();
                        objRecord.m_strDRUGSTOREID = dr["DRUGSTOREID"].ToString();
                        objRecord.m_strSHIPPING_NO = dr["SHIPPING_NO"].ToString();
                        objRecord.m_strITEMID = ConvertObjToValue(dr["ITEMID"].ToString(), "*");
                        objRecord.m_strITEMKIND = dr["ITEMKIND"].ToString();
                        objRecord.m_strH_DRUGID = dr["H_DRUGID"].ToString();
                        objRecord.m_strGENERICNAME = dr["GENERICNAME"].ToString();
                        objRecord.m_strSPEC = dr["SPEC"].ToString();
                        if (dr["FORMULA"].ToString() == "1")
                        {
                            objRecord.m_strFORMULA = "01";
                        }
                        else if (dr["FORMULA"].ToString() == "2")
                        {
                            objRecord.m_strFORMULA = "02";
                        }
                        else
                        {
                            objRecord.m_strFORMULA = "99";
                        }
                        objRecord.m_dblOUTPUT_AMOUNT = ConvertObjToDecimal(dr["OUTPUT_AMOUNT"]);
                        objRecord.m_dblBUY_PRICE = ConvertObjToDecimal(dr["BUY_PRICE"]);
                        objRecord.m_dblRETAIL_PRICE = ConvertObjToDecimal(dr["RETAIL_PRICE"]);
                        objRecord.m_strBATCHNO = ConvertObjToValue(dr["BATCHNO"].ToString(), "*");
                        objRecord.m_strMANUFACTURER = dr["MANUFACTURER"].ToString();
                        objRecord.m_strSUPPLY = dr["SUPPLY"].ToString();
                        if (Convert.ToDateTime(dtmTemp).ToString("yyyy-MM-dd") != "0001-01-01")
                        {
                            DateTime.TryParse(dr["EFFECTIVE_DATE"].ToString(), out dtmTemp);
                        }
                        objRecord.m_dtmEFFECTIVE_DATE = dtmTemp;                         
                        objRecord.m_strFLAG = dr["FLAG"].ToString();
                        objRecord.m_strWAREHOUSING_NUMBER = dr["WAREHOUSING_NUMBER"].ToString();
                        objRecord.m_dtmSHIPPING_DATE = Convert.ToDateTime(dr["SHIPPING_DATE"]);
                        objRecord.m_dtmUPLOAD_DATE = Convert.ToDateTime(dr["UPLOAD_DATE"]);
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strOPERATOR_SEQ, "");
                            lstOutStorageInfo.Add(objRecord);
                        }
                        catch { }
                        // lstDrugInfo.Add(objRecord);
                    }
                    p_arrOutStorageInfo_VO = lstOutStorageInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 查询药库库存信息
        /// <summary>
        /// 查询药库库存信息
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrRecInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageInfo(DateTime datUpload, out clsStorageInfo_VO[] arrRecInfo_VO)
        {
            long lngRes = 0;
            arrRecInfo_VO = null;
            string strSQL = @"select '457226325' organcode,
       seq_ms_sunshinestorage.nextval medinf_seq,
       d.drugid_chr itemid,
       a.medicineid_chr h_drugid,
       a.storageid_chr drugstoreid,
       decode(c.medicinetypeid_chr, 1, 3, 2, 1, 6, 1, 7, 1, 99) itemkind,
       a.instorageid_vchr warehousing_number,
       decode(c.mednormalname_vchr,
              '',
              c.medicinename_vchr,
              c.mednormalname_vchr) genericname,
       c.medicinename_vchr tradename,
       e.flaga_int formula,
       a.medspec_vchr spec,
       a.opunit_vchr unit,
       c.permitno_vchr approvedno,
       a.lotno_vchr batchno,
       a.realgross_int storeamount,
       c.pharmaid_chr medspeccode,
       f.pharmaname_vchr medspec,
       a.productorid_chr manufacturer,
       g.vendorname_vchr supply,
       a.callprice_int input_price,
       a.retailprice_int retail_price,
       a.instoragedate_dat input_date,
       a.validperiod_dat effective_date,
       sysdate upload_date
  from t_ms_storage_detail a
  left join t_bse_medicine c
    on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medidrefloadupdrugid d
    on d.medicineid_chr = a.medicineid_chr
  left join t_aid_medicinepreptype e
    on e.medicinepreptype_chr = c.medicinepreptype_chr
  left join t_bse_pharmatype f
    on f.pharmaid_chr = c.pharmaid_chr
  left join t_bse_vendor g
    on g.vendorid_chr = a.vendorid_chr
 where a.status = 1 and c.medicinetypeid_chr in (1,2,6,7) and a.realgross_int>0 ";
            //20100520:陈炳坤说药品数据只上传：西药库，中药库，一类疫苗，二类疫苗，其它就不上传（入库与出库也只上传这几类）。
   //and a.instoragedate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
     //  to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {

                DataTable dt = null;
                //IDataParameter[] objDPArr = null;
                //objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                //objDPArr[0].Value = datUpload.ToString("yyyy-MM-dd 00:00:00");
                //objDPArr[1].Value = datUpload.ToString("yyyy-MM-dd 23:59:59");
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                if (lngRes > 0 && dt != null)
                {
                    List<clsStorageInfo_VO> lstDrugInfo = new List<clsStorageInfo_VO>();
                    clsStorageInfo_VO objRecord = null;
                    DataRow dr = null;
                    DateTime dtmTemp = DateTime.Now;
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        dr = dt.Rows[i1];
                        objRecord = new clsStorageInfo_VO();
                        objRecord.m_strORGANCODE = dr["organcode"].ToString();
                        objRecord.m_strMEDINF_SEQ = dr["medinf_seq"].ToString();
                        objRecord.m_strITEMID = dr["itemid"].ToString();
                        objRecord.m_strH_DRUGID = dr["h_drugid"].ToString();
                        objRecord.m_strDRUGSTOREID = ConvertObjToValue(dr["drugstoreid"].ToString(), "*");
                        objRecord.m_strITEMKIND = dr["itemkind"].ToString();
                        objRecord.m_strWAREHOUSING_NUMBER = dr["warehousing_number"].ToString();
                        objRecord.m_strGENERICNAME = dr["genericname"].ToString();
                        objRecord.m_strTRADENAME = dr["tradename"].ToString();
                        if (dr["formula"].ToString() == "1")
                        {
                            objRecord.m_strFORMULA = "01";
                        }
                        else if (dr["formula"].ToString() == "2")
                        {
                            objRecord.m_strFORMULA = "02";
                        }
                        else
                        {
                            objRecord.m_strFORMULA = "99";
                        }
                        objRecord.m_strSPEC = dr["spec"].ToString();
                        objRecord.m_strUNIT = dr["unit"].ToString();
                        objRecord.m_strAPPROVEDNO = ConvertObjToValue(dr["approvedno"].ToString(), "*");
                        objRecord.m_strBATCHNO = dr["batchno"].ToString();
                        objRecord.m_dblSTOREAMOUNT = Convert.ToInt32(ConvertObjToDecimal(dr["storeamount"]));
                        objRecord.m_strMEDSPECCODE = ConvertObjToValue(dr["medspeccode"].ToString(), "*");
                        objRecord.m_strMEDSPEC = ConvertObjToValue(dr["medspec"].ToString(), "*");
                        objRecord.m_strMANUFACTURER = ConvertObjToValue(dr["manufacturer"].ToString(), "*");
                        objRecord.m_strSUPPLY = ConvertObjToValue(dr["supply"].ToString(), "*");
                        objRecord.m_dblINPUT_PRICE = ConvertObjToDecimal(dr["input_price"]);
                        objRecord.m_dblRETAIL_PRICE = ConvertObjToDecimal(dr["retail_price"]);
                        objRecord.m_dtmINPUT_DATE = Convert.ToDateTime(dr["input_date"]);
                        DateTime.TryParse(dr["effective_date"].ToString(), out dtmTemp);
                        if (Convert.ToDateTime(dtmTemp).ToString("yyyy-MM-dd") != "0001-01-01")
                        {
                            objRecord.m_dtmEFFECTIVE_DATE = dtmTemp;
                        }
                        objRecord.m_dtmUPLOAD_DATE = Convert.ToDateTime(dr["upload_date"]);
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strMEDINF_SEQ, "");
                            lstDrugInfo.Add(objRecord);
                        }
                        catch { }
                    }
                    arrRecInfo_VO = lstDrugInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 查询项目信息
        /// <summary>
        /// 查询出库信息
        /// </summary>
        /// <param name="p_datForUpload"></param>
        /// <param name="p_arrHEALTH_ITEAM_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetItemInfo(DateTime p_datForUpload, out clsHEALTH_ITEAM_VO[] p_arrHEALTH_ITEAM_VO)
        {
            long lngRes = 0;
            p_arrHEALTH_ITEAM_VO = null;
            string strSQL = @"select   a.itemid_chr,
                                       a.itemcode_vchr,
                                       a.itemname_vchr,
                                       b.medicinename_vchr,
                                       (select distinct c.itemname_vchr
                                          from t_bse_itemalias_drug c
                                         where a.itemid_chr = c.itemid_chr
                                           and rownum = 1
                                           and c.aliasflag_int = 1) as spname,
                                       (select distinct c.itemname_vchr
                                          from t_bse_itemalias_drug c
                                         where a.itemid_chr = c.itemid_chr
                                           and rownum = 1
                                           and c.aliasflag_int = 0) as ptname,
                                       (select distinct c.itemname_vchr
                                          from t_bse_itemalias_drug c
                                         where a.itemid_chr = c.itemid_chr
                                           and rownum = 1
                                           and c.aliasflag_int = 3) as ywname,
                                       a.itempycode_chr,
                                       a.itemwbcode_chr,
                                       a.insuranceid_chr,
                                       b.insurancetype_vchr,
                                       b.medspec_vchr,
                                       b.packqty_dec,
                                       b.dosageunit_chr,
                                       '' as ylfl,
                                       decode(d.flaga_int, 1, '01', 2, '02', '99') flaga_int,
                                       a.itemipinvtype_chr,
                                       decode(b.insurancetype_vchr,
                                              '1006',
                                              '1',
                                              '1007',
                                              '1',
                                              '1008',
                                              '1',
                                              '0') insurancetype_vchr,
                                       b.tradeprice_mny,
                                       b.limitunitprice_mny,
                                       b.dosageunit_chr as dddunit,
                                       b.adultdosage_dec  as dddvalue
                                  from t_bse_chargeitem a, t_bse_medicine b, t_aid_medicinepreptype d
                                 where a.itemsrcid_vchr = b.medicineid_chr
                                   and b.medicinetypeid_chr = d.medicinepreptype_chr(+)
                                   and a.itemcatid_chr <> '-1'
                                   and a.itemcatid_chr is not null
                                   and a.ifstop_int = 0";
                                   //and a.lastchange_dat between ? and ?";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            Hashtable objHsTable = new Hashtable();
            try
            {

                DataTable dt = null;
                //IDataParameter[] objDPArr = null;
                //objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                //objDPArr[0].Value = p_datForUpload.ToString("yyyy-MM-dd 00:00:00");
                //objDPArr[1].Value = p_datForUpload.ToString("yyyy-MM-dd 23:59:59");
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                if (lngRes > 0 && dt != null)
                {
                    List<clsHEALTH_ITEAM_VO> lstItemInfo = new List<clsHEALTH_ITEAM_VO>();
                    clsHEALTH_ITEAM_VO objRecord = null;
                    DateTime dtmTemp = DateTime.Now;
                    DataRow dr = null;
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        dr = dt.Rows[i1];
                        objRecord = new clsHEALTH_ITEAM_VO();
                        objRecord.m_strID=dr["itemid_chr"].ToString().Trim();//流水号
                        objRecord.m_strITEMCODE =dr["itemcode_vchr"].ToString().Trim();//项目代码
                        objRecord.m_strITEMNAME =dr["itemname_vchr"].ToString().Trim();//项目名称
                        objRecord.m_strCHEMISTRYNAME=dr["medicinename_vchr"].ToString().Trim();//化学名
                        objRecord.m_strNAME=dr["spname"].ToString().Trim();//商品名
                        objRecord.m_strUSED_NAME =dr["ptname"].ToString().Trim();//别名
                        objRecord.m_strITEMENNAME =dr["ywname"].ToString().Trim();//项目英文
                        objRecord.m_strMNEMOTECHNICS1 =dr["itempycode_chr"].ToString().Trim();//助记码1（拼音）
                        objRecord.m_strMNEMOTECHNICS2 =dr["itemwbcode_chr"].ToString().Trim();//助记码2（五笔）
                        objRecord.m_strITEMSPEC=dr["medspec_vchr"].ToString().Trim();//规格
                        objRecord.m_strPACKAGSPEC=dr["packqty_dec"].ToString().Trim();//包装规格
                        objRecord.m_strMEASURE_UNIT=dr["dosageunit_chr"].ToString().Trim();//计量单位
                        objRecord.m_strMEDSPEC=dr["ylfl"].ToString().Trim();//药理分类代码
                        objRecord.m_strFORMULA = dr["flaga_int"].ToString().Trim();//剂型分类代码
                        objRecord.m_strITEMKIND =dr["itemipinvtype_chr"].ToString().Trim();//项目分类代码
                        objRecord.m_strMEDICINEBASE =dr["insurancetype_vchr"].ToString().Trim();//国家基本用药
                        objRecord.m_strBUY_PRICE=dr["tradeprice_mny"].ToString().Trim();//采购价格
                        objRecord.m_strRETAIL_PRICE=dr["limitunitprice_mny"].ToString().Trim();//零售限价
                        objRecord.m_strMI_SORT =dr["insurancetype_vchr"].ToString().Trim();//医保项目分类
                        objRecord.m_strMI_CODE =dr["insuranceid_chr"].ToString().Trim();//医保编号
                        //objRecord.m_strSM_MARK//药品特殊管理标志代码
                        //objRecord.m_strPRODUCTID//产品ID
                        //objRecord.m_intESELFPAY=1;
                        //objRecord.m_strESELFPAY_FLAG//纯自费标志
                        //objRecord.m_strCOUNTRYID//国家代码
                        //objRecord.m_strAREAID//省代码
                        //objRecord.m_strMACTHNAME//系统匹配名
                        //objRecord.m_strBIDFORMULA//招标剂型
                        objRecord.m_strDDDUNIT=dr["dddunit"].ToString().Trim();//DDD单位
                        //objRecord.m_strSINGLEDOSE;//单剂量
                        objRecord.m_strDDDVALUE=ConvertObjToDecimal(dr["dddvalue"].ToString().Trim());//DDD值
                        //objRecord.m_strANTIB_SUBSIDIARY//抗菌药分类
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.m_strID, "");
                            lstItemInfo.Add(objRecord);
                        }
                        catch { }
                        // lstDrugInfo.Add(objRecord);
                    }
                    p_arrHEALTH_ITEAM_VO = lstItemInfo.ToArray();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHsTable.Clear();
            }
            return lngRes;
        }
        #endregion

        #region 项目对照
        /// <summary>
        /// 获取项目对照
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="p_arrItemControl"></param>
        /// <returns></returns>
        public long m_lngGetItemControlInfo(DateTime dtStart, DateTime dtEnd, out clsItemControl_VO[] p_arrItemControl)
        {
            long lngRes = -1;
            p_arrItemControl = null;
            clsHRPTableService objHRPSvc = null;
            Hashtable objHsTable = new Hashtable();
            try
            {
                string strSQL = @"select t.hosp_itemcenterid,
                                           '457226325' as organcode,
                                           t.drugid_chr as itemid,
                                           t.itemname,
                                           t.itemspec,
                                           t.packagspec,
                                           t.assistcode_chr as h_itemcode,
                                           t.medicinename_vchr as h_itemname,
                                           t.medspec_vchr as h_itemspec
                                      from t_bse_medidrefloadupdrugid t";
                DataTable dtResult = new DataTable();
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                if (lngRes > 0 && dtResult.Rows.Count>0)
                {
                    List<clsItemControl_VO> lstItemInfo = new List<clsItemControl_VO>();
                    clsItemControl_VO objRecord = null;
                    DataRow dr = null;
                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        dr = dtResult.Rows[i1];
                        objRecord = new clsItemControl_VO();
                        objRecord.HOSP_ITEMCENTERID = dr["hosp_itemcenterid"].ToString();
                        objRecord.ORGANCODE = dr["ORGANCODE"].ToString();
                        objRecord.ITEMID = dr["ITEMID"].ToString();
                        objRecord.ITEMNAME = dr["ITEMNAME"].ToString();
                        objRecord.ITEMSPEC = dr["ITEMSPEC"].ToString();
                        objRecord.PACKAGSPEC = dr["PACKAGSPEC"].ToString();
                        objRecord.H_ITEMCODE = dr["H_ITEMCODE"].ToString();
                        objRecord.H_ITEMNAME = dr["H_ITEMNAME"].ToString();
                        if (Text_Length(dr["H_ITEMSPEC"].ToString()) > 20)
                        {
                            objRecord.H_ITEMSPEC = dr["H_ITEMSPEC"].ToString().Substring(0, 10);
                        }
                        else
                        {
                            objRecord.H_ITEMSPEC = dr["H_ITEMSPEC"].ToString();
                        }
                        //过滤重复数据
                        try
                        {
                            objHsTable.Add(objRecord.HOSP_ITEMCENTERID, "");
                            lstItemInfo.Add(objRecord);
                        }
                        catch { }
                    }
                    p_arrItemControl = lstItemInfo.ToArray();
                }

            }
            catch (Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 计算文本长度，区分中英文字符，中文算两个长度，英文算一个长度
        /// <seealso cref="Common_Function.Text_Length"/>
        /// </summary>
        /// <param name="Text">需计算长度的字符串</param>
        /// <returns>int</returns>
        public static int Text_Length(string Text)
        {
            int len = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                byte[] byte_len = Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;
                else
                    len += 1;
            }

            return len;
        }
    }
    #endregion
}
