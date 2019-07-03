using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.HIS;
using System.Text;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTreatRecipeInfoSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region oldCode
//        #region 获取药房名称
//        /// <summary>
//        /// 1.获取药房名称
//        /// </summary>
//        /// <param name="m_dtbReport"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetMedicineName(out DataTable m_dtbReport)
//        {
//            long lngRes = -1;
//            m_dtbReport = new DataTable();

//            string strSql = @"select t1.medstoreid_chr,
//                                     t1.medstorename_vchr
//                                from t_bse_medstore t1";
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_dtbReport);

//                objHRPSvc.Dispose();
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 获取配药员工
//        /// <summary>
//        /// 1.获取配药员工
//        /// </summary>
//        /// <param name="m_dtbReport"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetTreatEmp(string strMedNameid, out DataTable m_objResult)
//        {
//            long lngRes = -1;
//            m_objResult = new DataTable();
//            StringBuilder strSql = new StringBuilder("");

//            try
//            {
//                strSql.Append(@"select distinct t3.empno_chr,
//                                      t3.lastname_vchr,
//                                      t3.empid_chr
//                                 from t_bse_employee t3,
//                                      t_bse_deptemp t2,
//                                      t_bse_deptdesc t1,
//                                      t_bse_medstore t
//                                where t.deptid_chr=t1.deptid_chr
//                                  and t1.deptid_chr=t2.deptid_chr
//                                  and t2.empid_chr=t3.empid_chr");

////                if (strMedNameid == "10000")
////                {
////                    strSql.Append(@" order by t3.empno_chr");
////                }
////                else
////                {
////                    strSql.Append(@" and t.medstoreid_chr=?
////                                order by t3.empno_chr");
////                }
//                if (strMedNameid != "10000")
//                {
//                    strSql.Append(@" and t.medstoreid_chr=?");
//                }

//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                IDataParameter[] objDPArr = null;

//                if (strMedNameid == "10000")
//                {
//                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql.ToString(), ref m_objResult);
//                }
//                else
//                {
//                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
//                    objDPArr[0].Value = strMedNameid;
//                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql.ToString(), ref m_objResult, objDPArr);
//                }

//                objHRPSvc.Dispose();

//                DataView dv = new DataView(m_objResult);
//                dv.Sort = "empno_chr";
//                m_objResult = dv.ToTable();
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 获取配药员工列表
//        /// <summary>
//        /// 获取配药员工列表
//        /// </summary>
//        /// <param name="strBeginDat"></param>
//        /// <param name="strEndDat"></param>
//        /// <param name="strMedicineName"></param>
//        /// <param name="strTreatEmp"></param>
//        /// <param name="m_dtbResult"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetTreatEmpInfo(string p_strCartNo, string p_strPatientName, string  p_strInvoiceNo, string strBeginDat, string strEndDat, string strMedicineName, string strTreatEmp, out DataTable m_dtbResult)
//        {
//            long lngRes = -1;
//            m_dtbResult = new DataTable();
//            string strSql = "";
//            if (strMedicineName == "10000")
//            {
//                if (strTreatEmp == "10000")
//                {
//                    strSql = @"select t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
//                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
//                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
//                                      t9.lastname_vchr as diagdrname,
//                                      t11.deptname_vchr as diagdeptname,
//                                      t6.lastname_vchr as sendempname,
//                                      t4.medstorename_vchr,
//                                      t7.windowname_vchr as treatwinname,
//                                      t8.windowname_vchr as sendwinname,
//                                      b.patientcardid_chr,
//                                      a.lastname_vchr as patientname,
//                                      c.invoiceno_vchr
//                                 from t_opr_recipesend t1,
//                                      t_bse_employee t3,
//                                      t_opr_recipesendentry t2,
//                                      t_opr_outpatientrecipe t5,
//                                      t_bse_employee t6,
//                                      t_bse_medstore t4,
//                                      t_bse_medstorewin t7, 
//                                      t_bse_medstorewin t8,
//                                      t_bse_employee t9,
//                                      t_bse_deptdesc t,
//                                      t_bse_deptdesc t11,
//                                      t_bse_deptemp t10,
//                                      t_bse_patient a,
//                                      t_bse_patientcard b,
//                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
//                                         from (select  max (seqid_chr) as seqid_chr
//                                         from t_opr_outpatientrecipeinv
//                                        where recorddate_dat between ? and ?
//                                     group by outpatrecipeid_chr) e,
//                                              t_opr_outpatientrecipeinv f
//                                        where e.seqid_chr = f.seqid_chr) c,
//                                      t_bse_medstore d
//                                where t1.treatemp_chr=t3.empid_chr(+)
//                                  and t3.empid_chr=t10.empid_chr(+)
//                                  and t10.deptid_chr=t.deptid_chr(+)
//                                  and t.deptid_chr=d.deptid_chr
//                                  and t1.sid_int=t2.sid_int
//                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
//                                  and t5.diagdr_chr=t9.empid_chr(+)
//                                  and t5.diagdept_chr=t11.deptid_chr(+)
//                                  and t1.sendemp_chr=t6.empid_chr(+)
//                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
//                                  and t1.windowid_chr=t7.windowid_chr(+)
//                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
//                                  and t1.patientid_chr=a.patientid_chr(+)
//                                  and a.patientid_chr=b.patientid_chr(+)
//                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
//                                  and t1.treatdate_dat between ? and ?";
//                }
//                else
//                {
//                    strSql = @"select t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
//                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
//                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
//                                      t9.lastname_vchr as diagdrname,
//                                      t11.deptname_vchr as diagdeptname,
//                                      t6.lastname_vchr as sendempname,
//                                      t4.medstorename_vchr,
//                                      t7.windowname_vchr as treatwinname,
//                                      t8.windowname_vchr as sendwinname,
//                                      b.patientcardid_chr,
//                                      a.lastname_vchr as patientname,
//                                      c.invoiceno_vchr
//                                 from t_opr_recipesend t1,
//                                      t_bse_employee t3,
//                                      t_opr_recipesendentry t2,
//                                      t_opr_outpatientrecipe t5,
//                                      t_bse_employee t6,
//                                      t_bse_medstore t4,
//                                      t_bse_medstorewin t7, 
//                                      t_bse_medstorewin t8,
//                                      t_bse_employee t9,
//                                      t_bse_deptdesc t,
//                                      t_bse_deptdesc t11,
//                                      t_bse_deptemp t10,
//                                      t_bse_patient a,
//                                      t_bse_patientcard b,
//                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
//                                         from (select  max (seqid_chr) as seqid_chr
//                                         from t_opr_outpatientrecipeinv
//                                        where recorddate_dat between ? and ?
//                                     group by outpatrecipeid_chr) e,
//                                              t_opr_outpatientrecipeinv f
//                                        where e.seqid_chr = f.seqid_chr) c,
//                                      t_bse_medstore d
//                                where t1.treatemp_chr=t3.empid_chr(+)
//                                  and t3.empid_chr=t10.empid_chr(+)
//                                  and t10.deptid_chr=t.deptid_chr(+)
//                                  and t.deptid_chr=d.deptid_chr
//                                  and t1.sid_int=t2.sid_int
//                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
//                                  and t5.diagdr_chr=t9.empid_chr(+)
//                                  and t5.diagdept_chr=t11.deptid_chr(+)
//                                  and t1.sendemp_chr=t6.empid_chr(+)
//                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
//                                  and t1.windowid_chr=t7.windowid_chr(+)
//                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
//                                  and t1.patientid_chr=a.patientid_chr(+)
//                                  and a.patientid_chr=b.patientid_chr(+)
//                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
//                                  and t3.empid_chr=?
//                                  and t1.treatdate_dat between ? and ?";
//                }

//                try
//                {
//                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                    System.Data.IDataParameter[] arrParams = null;
//                    int iCount = 0;
//                    int n = -1;
//                    if (strTreatEmp == "10000")
//                    {
//                        iCount = 4;
//                        if (!string.IsNullOrEmpty(p_strCartNo))
//                        {
//                            strSql += @" and b.patientcardid_chr=?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strPatientName))
//                        {
//                            strSql += @" and a.lastname_vchr like ?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
//                        {
//                            strSql += @" and c.invoiceno_vchr=?";
//                            iCount++;
//                        }
//                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        if (iCount == 5)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                            }
//                            else
//                            {
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                        }
//                        else if (iCount == 6)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                            else
//                            {
//                                arrParams[++n].Value = p_strPatientName + "%";
//                                arrParams[++n].Value = p_strInvoiceNo;
//                            }
//                        }
//                        else if (iCount == 7)
//                        {
//                            arrParams[++n].Value = p_strCartNo;
//                            arrParams[++n].Value = p_strPatientName + "%";
//                            arrParams[++n].Value = p_strInvoiceNo;
//                        }
//                    }
//                    else
//                    {
//                        iCount = 5;
//                        if (!string.IsNullOrEmpty(p_strCartNo))
//                        {
//                            strSql += @" and b.patientcardid_chr=?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strPatientName))
//                        {
//                            strSql += @" and a.lastname_vchr like ?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
//                        {
//                            strSql += @" and c.invoiceno_vchr=?";
//                            iCount++;
//                        }
//                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        arrParams[++n].Value = strTreatEmp;
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        if (iCount == 6)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                            }
//                            else
//                            {
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                        }
//                        else if (iCount == 7)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                            else
//                            {
//                                arrParams[++n].Value = p_strPatientName + "%";
//                                arrParams[++n].Value = p_strInvoiceNo;
//                            }
//                        }
//                        else if (iCount == 8)
//                        {
//                            arrParams[++n].Value = p_strCartNo;
//                            arrParams[++n].Value = p_strPatientName + "%";
//                            arrParams[++n].Value = p_strInvoiceNo;
//                        }
//                    }

//                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbResult, arrParams);

//                    objHRPSvc.Dispose();
//                }
//                catch (Exception objEx)
//                {
//                    string strTmp = objEx.Message;
//                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }
//            }
//            else
//            {
//                if (strTreatEmp == "10000")
//                {
//                    strSql = @"select t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
//                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
//                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
//                                      t9.lastname_vchr as diagdrname,
//                                      t11.deptname_vchr as diagdeptname,
//                                      t6.lastname_vchr as sendempname,
//                                      t4.medstorename_vchr,
//                                      t7.windowname_vchr as treatwinname,
//                                      t8.windowname_vchr as sendwinname,
//                                      b.patientcardid_chr,
//                                      a.lastname_vchr as patientname,
//                                      c.invoiceno_vchr
//                                 from t_opr_recipesend t1,
//                                      t_bse_employee t3,
//                                      t_opr_recipesendentry t2,
//                                      t_opr_outpatientrecipe t5,
//                                      t_bse_employee t6,
//                                      t_bse_medstore t4,
//                                      t_bse_medstorewin t7, 
//                                      t_bse_medstorewin t8,
//                                      t_bse_employee t9,
//                                      t_bse_deptdesc t,
//                                      t_bse_deptdesc t11,
//                                      t_bse_deptemp t10,
//                                      t_bse_patient a,
//                                      t_bse_patientcard b,
//                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
//                                         from (select  max (seqid_chr) as seqid_chr
//                                         from t_opr_outpatientrecipeinv
//                                        where recorddate_dat between ? and ?
//                                     group by outpatrecipeid_chr) e,
//                                              t_opr_outpatientrecipeinv f
//                                        where e.seqid_chr = f.seqid_chr) c,
//                                      t_bse_medstore d
//                                where t1.treatemp_chr=t3.empid_chr(+)
//                                  and t3.empid_chr=t10.empid_chr(+)
//                                  and t10.deptid_chr=t.deptid_chr(+)
//                                  and t.deptid_chr=d.deptid_chr
//                                  and t1.sid_int=t2.sid_int
//                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
//                                  and t5.diagdr_chr=t9.empid_chr(+)
//                                  and t5.diagdept_chr=t11.deptid_chr(+)
//                                  and t1.sendemp_chr=t6.empid_chr(+)
//                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
//                                  and t1.windowid_chr=t7.windowid_chr(+)
//                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
//                                  and t1.patientid_chr=a.patientid_chr(+)
//                                  and a.patientid_chr=b.patientid_chr(+)
//                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
//                                  and t1.medstoreid_chr=?
//                                  and t1.treatdate_dat between ? and ?";
//                }
//                else
//                {
//                    strSql = @"select t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
//                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
//                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
//                                      t9.lastname_vchr as diagdrname,
//                                      t11.deptname_vchr as diagdeptname,
//                                      t6.lastname_vchr as sendempname,
//                                      t4.medstorename_vchr,
//                                      t7.windowname_vchr as treatwinname,
//                                      t8.windowname_vchr as sendwinname,
//                                      b.patientcardid_chr,
//                                      a.lastname_vchr as patientname,
//                                      c.invoiceno_vchr
//                                 from t_opr_recipesend t1,
//                                      t_bse_employee t3,
//                                      t_opr_recipesendentry t2,
//                                      t_opr_outpatientrecipe t5,
//                                      t_bse_employee t6,
//                                      t_bse_medstore t4,
//                                      t_bse_medstorewin t7, 
//                                      t_bse_medstorewin t8,
//                                      t_bse_employee t9,
//                                      t_bse_deptdesc t,
//                                      t_bse_deptdesc t11,
//                                      t_bse_deptemp t10,
//                                      t_bse_patient a,
//                                      t_bse_patientcard b,
//                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
//                                         from (select  max (seqid_chr) as seqid_chr
//                                         from t_opr_outpatientrecipeinv
//                                        where recorddate_dat between ? and ?
//                                     group by outpatrecipeid_chr) e,
//                                              t_opr_outpatientrecipeinv f
//                                        where e.seqid_chr = f.seqid_chr) c,
//                                      t_bse_medstore d
//                                where t1.treatemp_chr=t3.empid_chr(+)
//                                  and t3.empid_chr=t10.empid_chr(+)
//                                  and t10.deptid_chr=t.deptid_chr(+)
//                                  and t.deptid_chr=d.deptid_chr
//                                  and t1.sid_int=t2.sid_int
//                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
//                                  and t5.diagdr_chr=t9.empid_chr(+)
//                                  and t5.diagdept_chr=t11.deptid_chr(+)
//                                  and t1.sendemp_chr=t6.empid_chr(+)
//                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
//                                  and t1.windowid_chr=t7.windowid_chr(+)
//                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
//                                  and t1.patientid_chr=a.patientid_chr(+)
//                                  and a.patientid_chr=b.patientid_chr(+)
//                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
//                                  and t1.medstoreid_chr=? 
//                                  and t3.empid_chr=?
//                                  and t1.treatdate_dat between ? and ?";
//                }

//                try
//                {
//                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                    System.Data.IDataParameter[] arrParams = null;
//                    int iCount = 0;
//                    int n = -1;
//                    if (strTreatEmp == "10000")
//                    {
//                        iCount = 5;
//                        if (!string.IsNullOrEmpty(p_strCartNo))
//                        {
//                            strSql += @" and b.patientcardid_chr=?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strPatientName))
//                        {
//                            strSql += @" and a.lastname_vchr like ?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
//                        {
//                            strSql += @" and c.invoiceno_vchr=?";
//                            iCount++;
//                        }
//                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        arrParams[++n].Value = strMedicineName;
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        if (iCount == 6)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                            }
//                            else
//                            {
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                        }
//                        else if (iCount == 7)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                            else
//                            {
//                                arrParams[++n].Value = p_strPatientName + "%";
//                                arrParams[++n].Value = p_strInvoiceNo;
//                            }
//                        }
//                        else if (iCount == 8)
//                        {
//                            arrParams[++n].Value = p_strCartNo;
//                            arrParams[++n].Value = p_strPatientName + "%";
//                            arrParams[++n].Value = p_strInvoiceNo;
//                        }
//                    }
//                    else
//                    {
//                        iCount = 6;
//                        if (!string.IsNullOrEmpty(p_strCartNo))
//                        {
//                            strSql += @" and b.patientcardid_chr=?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strPatientName))
//                        {
//                            strSql += @" and a.lastname_vchr like ?";
//                            iCount++;
//                        }
//                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
//                        {
//                            strSql += @" and c.invoiceno_vchr=?";
//                            iCount++;
//                        }
//                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        arrParams[++n].Value = strMedicineName;
//                        arrParams[++n].Value = strTreatEmp;
//                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
//                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
//                        if (iCount == 7)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                            }
//                            else
//                            {
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                        }
//                        else if (iCount == 8)
//                        {
//                            if (!string.IsNullOrEmpty(p_strCartNo))
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                                if (!string.IsNullOrEmpty(p_strPatientName))
//                                {
//                                    arrParams[++n].Value = p_strPatientName + "%";
//                                }
//                                else
//                                {
//                                    arrParams[++n].Value = p_strInvoiceNo;
//                                }
//                            }
//                            else
//                            {
//                                arrParams[++n].Value = p_strCartNo;
//                                arrParams[++n].Value = p_strPatientName + "%";
//                            }
//                        }
//                        else if (iCount == 9)
//                        {
//                            arrParams[++n].Value = p_strCartNo;
//                            arrParams[++n].Value = p_strPatientName + "%";
//                            arrParams[++n].Value = p_strInvoiceNo;
//                        }
//                    }

//                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbResult, arrParams);

//                    objHRPSvc.Dispose();

//                    DataView dv = new DataView(m_dtbResult);
//                    dv.Sort = "empno_chr";
//                    m_dtbResult = dv.ToTable();
//                }
//                catch (Exception objEx)
//                {
//                    string strTmp = objEx.Message;
//                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 处方明细信息表

//        /// <summary>
//        /// 1.处方明细信息表

//        /// </summary>
//        /// <param name="m_dtbReport"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetDetailInfo(string strsid_int, string strmedstoreid_chr, out DataTable m_dtbDetail)
//        {
//            long lngRes = -1;
            
//            DataTable m_dtbDetail1 = new DataTable();
//            DataTable m_dtbDetail2 = new DataTable();
//            DataTable m_dtbDetail3 = new DataTable();
//            DataTable m_dtbDetail4 = new DataTable();
//            DataTable m_dtbDetail5 = new DataTable();
//            DataTable m_dtbDetail6 = new DataTable();
//            m_dtbDetail = new DataTable();

//            string strSql1 = @"select a.outpatrecipeid_chr,
//                                       a.dosageunit_chr,
//                                       a.rowno_chr,
//                                       a.itemid_chr,
//                                       a.unitid_chr,
//                                       a.tolqty_dec as qty_dec,
//                                       a.unitprice_mny as price_mny,
//                                       a.tolprice_mny,
//                                       a.medstoreid_chr,
//                                       a.usageid_chr,
//                                       a.days_int,
//                                       a.freqid_chr,
//                                       a.desc_vchr,
//                                       a.discount_dec,
//                                       a.dosage_dec,
//                                       a.itemspec_vchr,
//                                       a.qty_dec as dosageqty,
//                                       a.itemname_vchr,
//                                       b.itemopinvtype_chr,
//                                       b.itemcode_vchr,
//                                       b.itemsrcid_vchr,
//                                       b.itemsrcid_vchr as medicineid_chr,
//                                       b.dosage_dec as basicdosage,
//                                       b.itemipunit_chr,
//                                       b.packqty_dec,
//                                       f.typename_vchr,
//                                       d.putmed_int,
//                                       d.opusagedesc,
//                                       d.usagename_vchr,
//                                       e.times_int as times_int1,
//                                       e.days_int as days_int1,
//                                       e.opfredesc_vchr as freqdesc,
//                                       e.freqname_chr,
//                                       0 times_int,
//                                       0 min_qty_dec1,
//                                       0 min_qty_dec,
//                                       '' sumusage_vchr,
//                                       't_opr_outpatientpwmrecipede' as fromtable,
//                                       g.mednormalname_vchr,g.productorid_chr,
//                                       '' itemunit_vchr,
//                                       g.medicinetypeid_chr
//                                  from t_opr_recipesend            m,
//                                       t_opr_recipesendentry       n,
//                                       t_opr_outpatientpwmrecipede a,
//                                       t_bse_chargeitem            b,
//                                       t_bse_chargeitemextype      f,
//                                       t_bse_usagetype             d,
//                                       t_aid_recipefreq            e,
//                                       t_bse_medicine              g
//                                 where m.sid_int = n.sid_int
//                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//                                   and a.itemid_chr = b.itemid_chr
//                                   and a.deptmed_int = 0
//                                   and a.outpatrecipeid_chr = ?
//                                   and a.medstoreid_chr = ?
//                                   and b.itemopinvtype_chr = f.typeid_chr
//                                   and f.flag_int = 2
//                                   and a.usageid_chr = d.usageid_chr(+)
//                                   and a.freqid_chr = e.freqid_chr(+)
//                                   and b.itemsrcid_vchr = g.medicineid_chr(+)
//                                 order by a.billrowno_int, a.itemname_vchr";

//            string strSql2 = @"select a.outpatrecipeid_chr,
//                                       b.dosageunit_chr,
//                                       a.rowno_chr,
//                                       a.itemid_chr,
//                                       a.unitid_chr,
//                                       (a.qty_dec * a.times_int) as qty_dec,
//                                       a.unitprice_mny as price_mny,
//                                       a.tolprice_mny,
//                                       a.medstoreid_chr,
//                                       '' usageid_chr,
//                                       0 as days_int,
//                                       '' freqid_chr,
//                                       usagedetail_vchr as desc_vchr,
//                                       a.discount_dec,
//                                       b.dosage_dec,
//                                       a.itemspec_vchr,
//                                       0 as dosageqty,
//                                       a.itemname_vchr,
//                                       b.itemopinvtype_chr,
//                                       b.itemcode_vchr,
//                                       b.itemsrcid_vchr,
//                                       b.itemsrcid_vchr as medicineid_chr,
//                                       b.dosage_dec as basicdosage,
//                                       b.itemipunit_chr,
//                                       b.packqty_dec,
//                                       f.typename_vchr,
//                                       d.putmed_int,
//                                       d.opusagedesc,
//                                       d.usagename_vchr,
//                                       e.times_int as times_int1,
//                                       e.days_int as days_int1,
//                                       e.opfredesc_vchr as freqdesc,
//                                       e.freqname_chr,
//                                       a.times_int,
//                                       a.min_qty_dec as min_qty_dec1,
//                                       a.min_qty_dec,
//                                       a.sumusage_vchr,
//                                       't_opr_outpatientcmrecipede' as fromtable,
//                                       g.mednormalname_vchr,g.productorid_chr,
//                                       '' itemunit_vchr,
//                                       g.medicinetypeid_chr
//                                  from t_opr_recipesend           m,
//                                       t_opr_recipesendentry      n,
//                                       t_opr_outpatientcmrecipede a,
//                                       t_bse_chargeitem           b,
//                                       t_bse_chargeitemextype     f,
//                                       t_bse_usagetype            d,
//                                       t_aid_recipefreq           e,
//                                       t_bse_medicine             g
//                                 where m.sid_int = n.sid_int
//                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//                                   and a.itemid_chr = b.itemid_chr
//                                   and a.deptmed_int = 0
//                                   and a.outpatrecipeid_chr = ?
//                                   and a.medstoreid_chr=?
//                                   and a.itemid_chr = e.freqid_chr(+)
//                                   and b.itemopinvtype_chr = f.typeid_chr
//                                   and f.flag_int = 2
//                                   and a.usageid_chr = d.usageid_chr(+)
//                                   and b.itemsrcid_vchr = g.medicineid_chr(+)
//                                 order by a.billrowno_int, a.itemname_vchr";
//            string strSql3 = @"select a.outpatrecipeid_chr,
//                                       b.dosageunit_chr,
//                                       a.rowno_chr,
//                                       a.itemid_chr,
//                                       a.unitid_chr,
//                                       a.qty_dec as qty_dec,
//                                       a.unitprice_mny as price_mny,
//                                       a.tolprice_mny,
//                                       a.medstoreid_chr,
//                                       '' as usageid_chr,
//                                       0 as days_int,
//                                       '' as freqid_chr,
//                                       '' as desc_vchr,
//                                       b.dosage_dec as discount_dec,
//                                       0 as dosage_dec,
//                                       a.itemspec_vchr,
//                                       a.qty_dec as dosageqty,
//                                       a.itemname_vchr,
//                                       b.itemopinvtype_chr,
//                                       b.itemcode_vchr,
//                                       b.itemsrcid_vchr,
//                                       b.itemsrcid_vchr as medicineid_chr,
//                                       b.dosage_dec as basicdosage,
//                                       b.itemipunit_chr,
//                                       b.packqty_dec,
//                                       f.typename_vchr,
//                                       1 putmed_int,
//                                       '' opusagedesc,
//                                       '' as usagename_vchr,
//                                       0 times_int1,
//                                       0 days_int1,
//                                       '' freqdesc,
//                                       '' freqname_chr,
//                                       0 times_int,
//                                       0 min_qty_dec1,
//                                       0 min_qty_dec,
//                                       '' sumusage_vchr,
//                                       't_opr_outpatientothrecipede' as fromtable,
//                                       g.mednormalname_vchr,g.productorid_chr,
//                                       a.itemunit_vchr,
//                                       g.medicinetypeid_chr
//                                  from t_opr_recipesend            m,
//                                       t_opr_recipesendentry       n,
//                                       t_opr_outpatientothrecipede a,
//                                       t_bse_chargeitem            b,
//                                       t_bse_chargeitemextype      f,
//                                       t_bse_medicine              g
//                                 where m.sid_int = n.sid_int
//                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//                                   and a.itemid_chr = b.itemid_chr
//                                   and a.deptmed_int = 0
//                                   and a.outpatrecipeid_chr = ?
//                                   and a.medstoreid_chr=?
//                                   and b.itemopinvtype_chr = f.typeid_chr
//                                   and b.itemsrcid_vchr = g.medicineid_chr(+)
//                                 order by a.billrowno_int, a.itemname_vchr";
//            string strSql4 = @"select a.outpatrecipeid_chr,
//                                       b.dosageunit_chr,
//                                       a.rowno_chr,
//                                       a.itemid_chr,
//                                       '' unitid_chr,
//                                       a.qty_dec as qty_dec,
//                                       a.price_mny as price_mny,
//                                       a.tolprice_mny,
//                                       a.medstoreid_chr,
//                                       '' as usageid_chr,
//                                       0 as days_int,
//                                       '' as freqid_chr,
//                                       '' as desc_vchr,
//                                       b.dosage_dec as discount_dec,
//                                       0 as dosage_dec,
//                                       a.itemspec_vchr,
//                                       a.qty_dec as dosageqty,
//                                       a.itemname_vchr,
//                                       b.itemopinvtype_chr,
//                                       b.itemcode_vchr,
//                                       b.itemsrcid_vchr,
//                                       b.itemsrcid_vchr as medicineid_chr,
//                                       b.dosage_dec as basicdosage,
//                                       b.itemipunit_chr,
//                                       b.packqty_dec,
//                                       f.typename_vchr,
//                                       1 putmed_int,
//                                       '' opusagedesc,
//                                       '' as usagename_vchr,
//                                       0 times_int1,
//                                       0 days_int1,
//                                       '' freqdesc,
//                                       '' freqname_chr,
//                                       0 times_int,
//                                       0 min_qty_dec1,
//                                       0 min_qty_dec,
//                                       '' sumusage_vchr,
//                                       't_opr_outpatientchkrecipede' as fromtable,
//                                       '' as mednormalname_vchr,''productorid_chr,
//                                       a.itemunit_vchr,
//                                       '' medicinetypeid_chr
//                                    from t_opr_recipesend m,
//                                         t_opr_recipesendentry n,
//                                         t_opr_outpatientchkrecipede a,
//                                         t_bse_chargeitem b,
//                                         t_bse_chargeitemextype f
//                                   where m.sid_int = n.sid_int
//                                     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//                                     and a.itemid_chr = b.itemid_chr
//                                     and a.outpatrecipeid_chr = ?
//                                     and a.medstoreid_chr=?
//                                     and b.itemopinvtype_chr = f.typeid_chr
//                                order by a.billrowno_int, a.itemname_vchr";
//            string strSql5 = @"select a.outpatrecipeid_chr,
//                                       b.dosageunit_chr,
//                                       a.rowno_chr,
//                                       a.itemid_chr,
//                                       '' unitid_chr,
//                                       a.qty_dec as qty_dec,
//                                       a.price_mny as price_mny,
//                                       a.tolprice_mny,
//                                       a.medstoreid_chr,
//                                       '' as usageid_chr,
//                                       0 as days_int,
//                                       '' as freqid_chr,
//                                       '' as desc_vchr,
//                                       b.dosage_dec as discount_dec,
//                                       0 as dosage_dec,
//                                       a.itemspec_vchr,
//                                       a.qty_dec as dosageqty,
//                                       a.itemname_vchr,
//                                       b.itemopinvtype_chr,
//                                       b.itemcode_vchr,
//                                       b.itemsrcid_vchr,
//                                       b.itemsrcid_vchr as medicineid_chr,
//                                       b.dosage_dec as basicdosage,
//                                       b.itemipunit_chr,
//                                       b.packqty_dec,
//                                       f.typename_vchr,
//                                       1 putmed_int,
//                                       '' opusagedesc,
//                                       '' as usagename_vchr,
//                                       0 times_int1,
//                                       0 days_int1,
//                                       '' freqdesc,
//                                       '' freqname_chr,
//                                       0 times_int,
//                                       0 min_qty_dec1,
//                                       0 min_qty_dec,
//                                       '' sumusage_vchr,
//                                       't_opr_outpatienttestrecipede' as fromtable,
//                                       '' as mednormalname_vchr,'' productorid_chr,
//                                       a.itemunit_vchr,
//                                       '' medicinetypeid_chr
//                                  from t_opr_recipesend             m,
//                                       t_opr_recipesendentry        n,
//                                       t_opr_outpatienttestrecipede a,
//                                       t_bse_chargeitem             b,
//                                       t_bse_chargeitemextype       f
//                                 where m.sid_int = n.sid_int
//                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//                                   and a.itemid_chr = b.itemid_chr
//                                   and a.outpatrecipeid_chr = ?
//                                   and a.medstoreid_chr=?
//                                   and b.itemopinvtype_chr = f.typeid_chr
//                                 order by a.billrowno_int, a.itemname_vchr";
//            string strSql6 = @"select a.outpatrecipeid_chr,
//                                       b.dosageunit_chr,
//                                       a.rowno_chr,
//                                       a.itemid_chr,
//                                       '' unitid_chr,
//                                       a.qty_dec as qty_dec,
//                                       a.price_mny as price_mny,
//                                       a.tolprice_mny,
//                                       a.medstoreid_chr,
//                                       '' as usageid_chr,
//                                       0 as days_int,
//                                       '' as freqid_chr,
//                                       '' as desc_vchr,
//                                       b.dosage_dec as discount_dec,
//                                       0 as dosage_dec,
//                                       a.itemspec_vchr,
//                                       a.qty_dec as dosageqty,
//                                       a.itemname_vchr,
//                                       b.itemopinvtype_chr,
//                                       b.itemcode_vchr,
//                                       b.itemsrcid_vchr,
//                                       b.itemsrcid_vchr as medicineid_chr,
//                                       b.dosage_dec as basicdosage,
//                                       b.itemipunit_chr,
//                                       b.packqty_dec,
//                                       f.typename_vchr,
//                                       1 putmed_int,
//                                       '' opusagedesc,
//                                       '' as usagename_vchr,
//                                       0 times_int1,
//                                       0 days_int1,
//                                       '' freqdesc,
//                                       '' freqname_chr,
//                                       0 times_int,
//                                       0 min_qty_dec1,
//                                       0 min_qty_dec,
//                                       '' sumusage_vchr,
//                                       't_opr_outpatientopsrecipede' as fromtable,
//                                       '' as mednormalname_vchr,'' productorid_chr,
//                                       a.itemunit_vchr,
//                                       '' medicinetypeid_chr
//                                  from t_opr_recipesend            m,
//                                       t_opr_recipesendentry       n,
//                                       t_opr_outpatientopsrecipede a,
//                                       t_bse_chargeitem            b,
//                                       t_bse_chargeitemextype      f
//                                 where m.sid_int = n.sid_int
//                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
//                                   and a.itemid_chr = b.itemid_chr
//                                   and a.outpatrecipeid_chr = ?
//                                   and a.medstoreid_chr=?
//                                   and b.itemopinvtype_chr = f.typeid_chr
//                                 order by a.billrowno_int, a.itemname_vchr";

//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                System.Data.IDataParameter[] arrParams1 = null;
//                int a = -1;
//                objHRPSvc.CreateDatabaseParameter(2, out arrParams1);
//                arrParams1[++a].Value = strsid_int;
//                arrParams1[++a].Value = strmedstoreid_chr;
//                objHRPSvc.lngGetDataTableWithParameters(strSql1, ref m_dtbDetail1, arrParams1);

//                System.Data.IDataParameter[] arrParams2 = null;
//                int b = -1;
//                objHRPSvc.CreateDatabaseParameter(2, out arrParams2);
//                arrParams2[++b].Value = strsid_int;
//                arrParams2[++b].Value = strmedstoreid_chr;
//                objHRPSvc.lngGetDataTableWithParameters(strSql2, ref m_dtbDetail2, arrParams2);

//                System.Data.IDataParameter[] arrParams3 = null;
//                int c = -1;
//                objHRPSvc.CreateDatabaseParameter(2, out arrParams3);
//                arrParams3[++c].Value = strsid_int;
//                arrParams3[++c].Value = strmedstoreid_chr;
//                objHRPSvc.lngGetDataTableWithParameters(strSql3, ref m_dtbDetail3, arrParams3);

//                System.Data.IDataParameter[] arrParams4 = null;
//                int d = -1;
//                objHRPSvc.CreateDatabaseParameter(2, out arrParams4);
//                arrParams4[++d].Value = strsid_int;
//                arrParams4[++d].Value = strmedstoreid_chr;
//                objHRPSvc.lngGetDataTableWithParameters(strSql4, ref m_dtbDetail4, arrParams4);

//                System.Data.IDataParameter[] arrParams5 = null;
//                int e = -1;
//                objHRPSvc.CreateDatabaseParameter(2, out arrParams5);
//                arrParams5[++e].Value = strsid_int;
//                arrParams5[++e].Value = strmedstoreid_chr;
//                objHRPSvc.lngGetDataTableWithParameters(strSql5, ref m_dtbDetail5, arrParams5);

//                System.Data.IDataParameter[] arrParams6 = null;
//                int f = -1;
//                objHRPSvc.CreateDatabaseParameter(2, out arrParams6);
//                arrParams6[++f].Value = strsid_int;
//                arrParams6[++f].Value = strmedstoreid_chr;
//                objHRPSvc.lngGetDataTableWithParameters(strSql6, ref m_dtbDetail6, arrParams6);

//                objHRPSvc.Dispose();

//                m_dtbDetail = m_dtbDetail1.Clone();
//                m_dtbDetail.BeginLoadData();
//                DataRow dr=null;
//                for (int i1 = 0; i1 < m_dtbDetail1.Rows.Count; i1++)
//                {
//                    dr=m_dtbDetail1.Rows[i1];
//                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
//                }

//                for (int i1 = 0; i1 < m_dtbDetail2.Rows.Count; i1++)
//                {
//                    dr = m_dtbDetail2.Rows[i1];
//                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
//                }

//                for (int i1 = 0; i1 < m_dtbDetail3.Rows.Count; i1++)
//                {
//                    dr = m_dtbDetail3.Rows[i1];
//                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
//                }

//                for (int i1 = 0; i1 < m_dtbDetail4.Rows.Count; i1++)
//                {
//                    dr = m_dtbDetail4.Rows[i1];
//                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
//                }

//                for (int i1 = 0; i1 < m_dtbDetail5.Rows.Count; i1++)
//                {
//                    dr = m_dtbDetail5.Rows[i1];
//                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
//                }

//                for (int i1 = 0; i1 < m_dtbDetail6.Rows.Count; i1++)
//                {
//                    dr = m_dtbDetail6.Rows[i1];
//                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
//                }
//                m_dtbDetail.EndLoadData();

//                m_dtbDetail.AcceptChanges();
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            if (m_dtbDetail.Rows.Count > 0)
//            {
//                return lngRes = 1;
//            }
//            else
//                return lngRes;
//        }
//        #endregion
        #endregion
        #region 获取药房名称
        /// <summary>
        /// 1.获取药房名称
        /// </summary>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineName(out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            string strSql = @"select t1.medstoreid_chr,
                                     t1.medstorename_vchr
                                from t_bse_medstore t1";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_dtbReport);

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

        #region 获取配药员工
        /// <summary>
        /// 1.获取配药员工
        /// </summary>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTreatEmp(string strMedNameid, out DataTable m_objResult)
        {
            long lngRes = -1;
            m_objResult = new DataTable();
            StringBuilder strSql = new StringBuilder("");

            try
            {
                strSql.Append(@"select distinct t3.empno_chr,
                                      t3.lastname_vchr,
                                      t3.empid_chr
                                 from t_bse_employee t3,
                                      t_bse_deptemp t2,
                                      t_bse_deptdesc t1,
                                      t_bse_medstore t
                                where t.deptid_chr=t1.deptid_chr
                                  and t1.deptid_chr=t2.deptid_chr
                                  and t2.empid_chr=t3.empid_chr");

                //                if (strMedNameid == "10000")
                //                {
                //                    strSql.Append(@" order by t3.empno_chr");
                //                }
                //                else
                //                {
                //                    strSql.Append(@" and t.medstoreid_chr=?
                //                                order by t3.empno_chr");
                //                }
                if (strMedNameid != "10000")
                {
                    strSql.Append(@" and t.medstoreid_chr=?");
                }

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;

                if (strMedNameid == "10000")
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql.ToString(), ref m_objResult);
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = strMedNameid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql.ToString(), ref m_objResult, objDPArr);
                }

                objHRPSvc.Dispose();

                DataView dv = new DataView(m_objResult);
                dv.Sort = "empno_chr";
                m_objResult = dv.ToTable();
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

        #region 获取配药员工列表
        /// <summary>
        /// 获取配药员工列表
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="strMedicineName"></param>
        /// <param name="strTreatEmp"></param>
        /// <param name="m_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTreatEmpInfo(string p_strCartNo, string p_strPatientName, string p_strInvoiceNo, string strBeginDat, string strEndDat, string strMedicineName, string strTreatEmp, out DataTable m_dtbResult)
        {
            long lngRes = -1;
            m_dtbResult = new DataTable();
            string strSql = "";
            if (strMedicineName == "10000")
            {
                if (strTreatEmp == "10000")
                {
                    strSql = @"select distinct t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
                                      t9.lastname_vchr as diagdrname,
                                      t11.deptname_vchr as diagdeptname,
                                      t6.lastname_vchr as sendempname,
                                      t4.medstorename_vchr,
                                      t7.windowname_vchr as treatwinname,
                                      t8.windowname_vchr as sendwinname,
                                      b.patientcardid_chr,
                                      a.lastname_vchr as patientname,
                                      c.invoiceno_vchr
                                 from t_opr_recipesend t1,
                                      t_bse_employee t3,
                                      t_opr_recipesendentry t2,
                                      t_opr_outpatientrecipe t5,
                                      t_bse_employee t6,
                                      t_bse_medstore t4,
                                      t_bse_medstorewin t7, 
                                      t_bse_medstorewin t8,
                                      t_bse_employee t9,
                                      t_bse_deptdesc t,
                                      t_bse_deptdesc t11,
                                      t_bse_deptemp t10,
                                      t_bse_patient a,
                                      t_bse_patientcard b,
                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
                                         from (select  max (seqid_chr) as seqid_chr
                                         from t_opr_outpatientrecipeinv
                                        where recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and 
                                              to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                     group by outpatrecipeid_chr) e,
                                              t_opr_outpatientrecipeinv f
                                        where e.seqid_chr = f.seqid_chr) c,
                                      t_bse_medstore d
                                where t1.treatemp_chr=t3.empid_chr(+)
                                  and t3.empid_chr=t10.empid_chr(+)
                                  and t10.deptid_chr=t.deptid_chr(+)
                                  and t.deptid_chr=d.deptid_chr
                                  and t1.sid_int=t2.sid_int
                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
                                  and t5.diagdr_chr=t9.empid_chr(+)
                                  and t5.diagdept_chr=t11.deptid_chr(+)
                                  and t1.sendemp_chr=t6.empid_chr(+)
                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
                                  and t1.windowid_chr=t7.windowid_chr(+)
                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
                                  and t1.patientid_chr=a.patientid_chr(+)
                                  and a.patientid_chr=b.patientid_chr(+)
                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
                                  and t1.treatdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and 
                                      to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                }
                else
                {
                    strSql = @"select distinct t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
                                      t9.lastname_vchr as diagdrname,
                                      t11.deptname_vchr as diagdeptname,
                                      t6.lastname_vchr as sendempname,
                                      t4.medstorename_vchr,
                                      t7.windowname_vchr as treatwinname,
                                      t8.windowname_vchr as sendwinname,
                                      b.patientcardid_chr,
                                      a.lastname_vchr as patientname,
                                      c.invoiceno_vchr
                                 from t_opr_recipesend t1,
                                      t_bse_employee t3,
                                      t_opr_recipesendentry t2,
                                      t_opr_outpatientrecipe t5,
                                      t_bse_employee t6,
                                      t_bse_medstore t4,
                                      t_bse_medstorewin t7, 
                                      t_bse_medstorewin t8,
                                      t_bse_employee t9,
                                      t_bse_deptdesc t,
                                      t_bse_deptdesc t11,
                                      t_bse_deptemp t10,
                                      t_bse_patient a,
                                      t_bse_patientcard b,
                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
                                         from (select  max (seqid_chr) as seqid_chr
                                         from t_opr_outpatientrecipeinv
                                        where recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and 
                                              to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                     group by outpatrecipeid_chr) e,
                                              t_opr_outpatientrecipeinv f
                                        where e.seqid_chr = f.seqid_chr) c,
                                      t_bse_medstore d
                                where t1.treatemp_chr=t3.empid_chr(+)
                                  and t3.empid_chr=t10.empid_chr(+)
                                  and t10.deptid_chr=t.deptid_chr(+)
                                  and t.deptid_chr=d.deptid_chr
                                  and t1.sid_int=t2.sid_int
                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
                                  and t5.diagdr_chr=t9.empid_chr(+)
                                  and t5.diagdept_chr=t11.deptid_chr(+)
                                  and t1.sendemp_chr=t6.empid_chr(+)
                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
                                  and t1.windowid_chr=t7.windowid_chr(+)
                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
                                  and t1.patientid_chr=a.patientid_chr(+)
                                  and a.patientid_chr=b.patientid_chr(+)
                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
                                  and t3.empid_chr=?
                                  and t1.treatdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and 
                                      to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                }

                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                    System.Data.IDataParameter[] arrParams = null;
                    int iCount = 0;
                    int n = -1;
                    if (strTreatEmp == "10000")
                    {
                        iCount = 4;
                        if (!string.IsNullOrEmpty(p_strCartNo))
                        {
                            strSql += @" and b.patientcardid_chr=?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strPatientName))
                        {
                            strSql += @" and a.lastname_vchr like ?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
                        {
                            strSql += @" and c.invoiceno_vchr=?";
                            iCount++;
                        }
                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
                        arrParams[++n].Value = strBeginDat + " 00:00:00";
                        arrParams[++n].Value = strEndDat + " 23:59:59";
                        arrParams[++n].Value = strBeginDat + " 00:00:00";
                        arrParams[++n].Value = strEndDat + " 23:59:59";
                        if (iCount == 5)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                        }
                        else if (iCount == 6)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                            else
                            {
                                arrParams[++n].Value = p_strPatientName + "%";
                                arrParams[++n].Value = p_strInvoiceNo;
                            }
                        }
                        else if (iCount == 7)
                        {
                            arrParams[++n].Value = p_strCartNo;
                            arrParams[++n].Value = p_strPatientName + "%";
                            arrParams[++n].Value = p_strInvoiceNo;
                        }
                    }
                    else
                    {
                        iCount = 5;
                        if (!string.IsNullOrEmpty(p_strCartNo))
                        {
                            strSql += @" and b.patientcardid_chr=?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strPatientName))
                        {
                            strSql += @" and a.lastname_vchr like ?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
                        {
                            strSql += @" and c.invoiceno_vchr=?";
                            iCount++;
                        }
                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
                        arrParams[++n].Value = strBeginDat + " 00:00:00";
                        arrParams[++n].Value = strEndDat + " 23:59:59";
                        arrParams[++n].Value = strTreatEmp;
                        arrParams[++n].Value = strBeginDat + " 00:00:00";
                        arrParams[++n].Value = strEndDat + " 23:59:59";
                        if (iCount == 6)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                        }
                        else if (iCount == 7)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                            else
                            {
                                arrParams[++n].Value = p_strPatientName + "%";
                                arrParams[++n].Value = p_strInvoiceNo;
                            }
                        }
                        else if (iCount == 8)
                        {
                            arrParams[++n].Value = p_strCartNo;
                            arrParams[++n].Value = p_strPatientName + "%";
                            arrParams[++n].Value = p_strInvoiceNo;
                        }
                    }

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbResult, arrParams);

                    objHRPSvc.Dispose();
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
                if (strTreatEmp == "10000")
                {
                    strSql = @"select distinct t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
                                      t9.lastname_vchr as diagdrname,
                                      t11.deptname_vchr as diagdeptname,
                                      t6.lastname_vchr as sendempname,
                                      t4.medstorename_vchr,
                                      t7.windowname_vchr as treatwinname,
                                      t8.windowname_vchr as sendwinname,
                                      b.patientcardid_chr,
                                      a.lastname_vchr as patientname,
                                      c.invoiceno_vchr
                                 from t_opr_recipesend t1,
                                      t_bse_employee t3,
                                      t_opr_recipesendentry t2,
                                      t_opr_outpatientrecipe t5,
                                      t_bse_employee t6,
                                      t_bse_medstore t4,
                                      t_bse_medstorewin t7, 
                                      t_bse_medstorewin t8,
                                      t_bse_employee t9,
                                      t_bse_deptdesc t,
                                      t_bse_deptdesc t11,
                                      t_bse_deptemp t10,
                                      t_bse_patient a,
                                      t_bse_patientcard b,
                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
                                         from (select  max (seqid_chr) as seqid_chr
                                         from t_opr_outpatientrecipeinv
                                        where recorddate_dat between ? and ?
                                     group by outpatrecipeid_chr) e,
                                              t_opr_outpatientrecipeinv f
                                        where e.seqid_chr = f.seqid_chr) c,
                                      t_bse_medstore d
                                where t1.treatemp_chr=t3.empid_chr(+)
                                  and t3.empid_chr=t10.empid_chr(+)
                                  and t10.deptid_chr=t.deptid_chr(+)
                                  and t.deptid_chr=d.deptid_chr
                                  and t1.sid_int=t2.sid_int
                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
                                  and t5.diagdr_chr=t9.empid_chr(+)
                                  and t5.diagdept_chr=t11.deptid_chr(+)
                                  and t1.sendemp_chr=t6.empid_chr(+)
                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
                                  and t1.windowid_chr=t7.windowid_chr(+)
                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
                                  and t1.patientid_chr=a.patientid_chr(+)
                                  and a.patientid_chr=b.patientid_chr(+)
                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
                                  and t1.medstoreid_chr=?
                                  and t1.treatdate_dat between ? and ?";
                }
                else
                {
                    strSql = @"select distinct t1.sid_int,t1.medstoreid_chr,t1.treatdate_dat,
                                      t3.empid_chr,t3.lastname_vchr as treatempname,t3.empno_chr,
                                      t5.outpatrecipeid_chr,t5.diagdr_chr,t5.diagdept_chr,
                                      t9.lastname_vchr as diagdrname,
                                      t11.deptname_vchr as diagdeptname,
                                      t6.lastname_vchr as sendempname,
                                      t4.medstorename_vchr,
                                      t7.windowname_vchr as treatwinname,
                                      t8.windowname_vchr as sendwinname,
                                      b.patientcardid_chr,
                                      a.lastname_vchr as patientname,
                                      c.invoiceno_vchr
                                 from t_opr_recipesend t1,
                                      t_bse_employee t3,
                                      t_opr_recipesendentry t2,
                                      t_opr_outpatientrecipe t5,
                                      t_bse_employee t6,
                                      t_bse_medstore t4,
                                      t_bse_medstorewin t7, 
                                      t_bse_medstorewin t8,
                                      t_bse_employee t9,
                                      t_bse_deptdesc t,
                                      t_bse_deptdesc t11,
                                      t_bse_deptemp t10,
                                      t_bse_patient a,
                                      t_bse_patientcard b,
                                      (select f.invoiceno_vchr, f.outpatrecipeid_chr
                                         from (select  max (seqid_chr) as seqid_chr
                                         from t_opr_outpatientrecipeinv
                                        where recorddate_dat between ? and ?
                                     group by outpatrecipeid_chr) e,
                                              t_opr_outpatientrecipeinv f
                                        where e.seqid_chr = f.seqid_chr) c,
                                      t_bse_medstore d
                                where t1.treatemp_chr=t3.empid_chr(+)
                                  and t3.empid_chr=t10.empid_chr(+)
                                  and t10.deptid_chr=t.deptid_chr(+)
                                  and t.deptid_chr=d.deptid_chr
                                  and t1.sid_int=t2.sid_int
                                  and t2.outpatrecipeid_chr=t5.outpatrecipeid_chr(+)
                                  and t5.diagdr_chr=t9.empid_chr(+)
                                  and t5.diagdept_chr=t11.deptid_chr(+)
                                  and t1.sendemp_chr=t6.empid_chr(+)
                                  and t1.medstoreid_chr=t4.medstoreid_chr(+)
                                  and t1.windowid_chr=t7.windowid_chr(+)
                                  and t1.sendwindowid_chr=t8.windowid_chr(+)
                                  and t1.patientid_chr=a.patientid_chr(+)
                                  and a.patientid_chr=b.patientid_chr(+)
                                  and t5.outpatrecipeid_chr=c.outpatrecipeid_chr(+)
                                  and t1.medstoreid_chr=? 
                                  and t3.empid_chr=?
                                  and t1.treatdate_dat between ? and ?";
                }

                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                    System.Data.IDataParameter[] arrParams = null;
                    int iCount = 0;
                    int n = -1;
                    if (strTreatEmp == "10000")
                    {
                        iCount = 5;
                        if (!string.IsNullOrEmpty(p_strCartNo))
                        {
                            strSql += @" and b.patientcardid_chr=?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strPatientName))
                        {
                            strSql += @" and a.lastname_vchr like ?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
                        {
                            strSql += @" and c.invoiceno_vchr=?";
                            iCount++;
                        }
                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                        arrParams[++n].Value = strMedicineName;
                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                        if (iCount == 6)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                        }
                        else if (iCount == 7)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                            else
                            {
                                arrParams[++n].Value = p_strPatientName + "%";
                                arrParams[++n].Value = p_strInvoiceNo;
                            }
                        }
                        else if (iCount == 8)
                        {
                            arrParams[++n].Value = p_strCartNo;
                            arrParams[++n].Value = p_strPatientName + "%";
                            arrParams[++n].Value = p_strInvoiceNo;
                        }
                    }
                    else
                    {
                        iCount = 6;
                        if (!string.IsNullOrEmpty(p_strCartNo))
                        {
                            strSql += @" and b.patientcardid_chr=?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strPatientName))
                        {
                            strSql += @" and a.lastname_vchr like ?";
                            iCount++;
                        }
                        if (!string.IsNullOrEmpty(p_strInvoiceNo))
                        {
                            strSql += @" and c.invoiceno_vchr=?";
                            iCount++;
                        }
                        objHRPSvc.CreateDatabaseParameter(iCount, out arrParams);
                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                        arrParams[++n].Value = strMedicineName;
                        arrParams[++n].Value = strTreatEmp;
                        arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                        arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                        if (iCount == 7)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                        }
                        else if (iCount == 8)
                        {
                            if (!string.IsNullOrEmpty(p_strCartNo))
                            {
                                arrParams[++n].Value = p_strCartNo;
                                if (!string.IsNullOrEmpty(p_strPatientName))
                                {
                                    arrParams[++n].Value = p_strPatientName + "%";
                                }
                                else
                                {
                                    arrParams[++n].Value = p_strInvoiceNo;
                                }
                            }
                            else
                            {
                                arrParams[++n].Value = p_strCartNo;
                                arrParams[++n].Value = p_strPatientName + "%";
                            }
                        }
                        else if (iCount == 9)
                        {
                            arrParams[++n].Value = p_strCartNo;
                            arrParams[++n].Value = p_strPatientName + "%";
                            arrParams[++n].Value = p_strInvoiceNo;
                        }
                    }

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbResult, arrParams);

                    objHRPSvc.Dispose();

                    DataView dv = new DataView(m_dtbResult);
                    dv.Sort = "empno_chr";
                    m_dtbResult = dv.ToTable();
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

        #region 处方明细信息表

        /// <summary>
        /// 1.处方明细信息表

        /// </summary>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDetailInfo(string strsid_int, string strmedstoreid_chr, out DataTable m_dtbDetail)
        {
            long lngRes = -1;

            DataTable m_dtbDetail1 = new DataTable();
            DataTable m_dtbDetail2 = new DataTable();
            DataTable m_dtbDetail3 = new DataTable();
            DataTable m_dtbDetail4 = new DataTable();
            DataTable m_dtbDetail5 = new DataTable();
            DataTable m_dtbDetail6 = new DataTable();
            m_dtbDetail = new DataTable();

            string strSql1 = @"select a.outpatrecipeid_chr,
                                       a.dosageunit_chr,
                                       a.rowno_chr,
                                       a.itemid_chr,
                                       a.unitid_chr,
                                       a.tolqty_dec as qty_dec,
                                       a.unitprice_mny as price_mny,
                                       a.tolprice_mny,
                                       a.medstoreid_chr,
                                       a.usageid_chr,
                                       a.days_int,
                                       a.freqid_chr,
                                       a.desc_vchr,
                                       a.discount_dec,
                                       a.dosage_dec,
                                       a.itemspec_vchr,
                                       a.qty_dec as dosageqty,
                                       a.itemname_vchr,
                                       b.itemopinvtype_chr,
                                       b.itemcode_vchr,
                                       b.itemsrcid_vchr,
                                       b.itemsrcid_vchr as medicineid_chr,
                                       b.dosage_dec as basicdosage,
                                       b.itemipunit_chr,
                                       b.packqty_dec,
                                       f.typename_vchr,
                                       d.putmed_int,
                                       d.opusagedesc,
                                       d.usagename_vchr,
                                       e.times_int as times_int1,
                                       e.days_int as days_int1,
                                       e.opfredesc_vchr as freqdesc,
                                       e.freqname_chr,
                                       0 times_int,
                                       0 min_qty_dec1,
                                       0 min_qty_dec,
                                       '' sumusage_vchr,
                                       't_opr_outpatientpwmrecipede' as fromtable,
                                       g.mednormalname_vchr,g.productorid_chr,
                                       '' itemunit_vchr,
                                       g.medicinetypeid_chr
                                  from t_opr_recipesend            m,
                                       t_opr_recipesendentry       n,
                                       t_opr_outpatientpwmrecipede a,
                                       t_bse_chargeitem            b,
                                       t_bse_chargeitemextype      f,
                                       t_bse_usagetype             d,
                                       t_aid_recipefreq            e,
                                       t_bse_medicine              g
                                 where m.sid_int = n.sid_int
                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
                                   and a.itemid_chr = b.itemid_chr
                                   and a.deptmed_int = 0
                                   and a.outpatrecipeid_chr = ?
                                   and a.medstoreid_chr = ?
                                   and b.itemopinvtype_chr = f.typeid_chr
                                   and f.flag_int = 2
                                   and a.usageid_chr = d.usageid_chr(+)
                                   and a.freqid_chr = e.freqid_chr(+)
                                   and b.itemsrcid_vchr = g.medicineid_chr(+)
                                 order by a.billrowno_int, a.itemname_vchr";

            string strSql2 = @"select a.outpatrecipeid_chr,
                                       b.dosageunit_chr,
                                       a.rowno_chr,
                                       a.itemid_chr,
                                       a.unitid_chr,
                                       (a.qty_dec * a.times_int) as qty_dec,
                                       a.unitprice_mny as price_mny,
                                       a.tolprice_mny,
                                       a.medstoreid_chr,
                                       '' usageid_chr,
                                       0 as days_int,
                                       '' freqid_chr,
                                       usagedetail_vchr as desc_vchr,
                                       a.discount_dec,
                                       b.dosage_dec,
                                       a.itemspec_vchr,
                                       0 as dosageqty,
                                       a.itemname_vchr,
                                       b.itemopinvtype_chr,
                                       b.itemcode_vchr,
                                       b.itemsrcid_vchr,
                                       b.itemsrcid_vchr as medicineid_chr,
                                       b.dosage_dec as basicdosage,
                                       b.itemipunit_chr,
                                       b.packqty_dec,
                                       f.typename_vchr,
                                       d.putmed_int,
                                       d.opusagedesc,
                                       d.usagename_vchr,
                                       e.times_int as times_int1,
                                       e.days_int as days_int1,
                                       e.opfredesc_vchr as freqdesc,
                                       e.freqname_chr,
                                       a.times_int,
                                       a.min_qty_dec as min_qty_dec1,
                                       a.min_qty_dec,
                                       a.sumusage_vchr,
                                       't_opr_outpatientcmrecipede' as fromtable,
                                       g.mednormalname_vchr,g.productorid_chr,
                                       '' itemunit_vchr,
                                       g.medicinetypeid_chr
                                  from t_opr_recipesend           m,
                                       t_opr_recipesendentry      n,
                                       t_opr_outpatientcmrecipede a,
                                       t_bse_chargeitem           b,
                                       t_bse_chargeitemextype     f,
                                       t_bse_usagetype            d,
                                       t_aid_recipefreq           e,
                                       t_bse_medicine             g
                                 where m.sid_int = n.sid_int
                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
                                   and a.itemid_chr = b.itemid_chr
                                   and a.deptmed_int = 0
                                   and a.outpatrecipeid_chr = ?
                                   and a.medstoreid_chr=?
                                   and a.itemid_chr = e.freqid_chr(+)
                                   and b.itemopinvtype_chr = f.typeid_chr
                                   and f.flag_int = 2
                                   and a.usageid_chr = d.usageid_chr(+)
                                   and b.itemsrcid_vchr = g.medicineid_chr(+)
                                 order by a.billrowno_int, a.itemname_vchr";
            string strSql3 = @"select a.outpatrecipeid_chr,
                                       b.dosageunit_chr,
                                       a.rowno_chr,
                                       a.itemid_chr,
                                       a.unitid_chr,
                                       a.qty_dec as qty_dec,
                                       a.unitprice_mny as price_mny,
                                       a.tolprice_mny,
                                       a.medstoreid_chr,
                                       '' as usageid_chr,
                                       0 as days_int,
                                       '' as freqid_chr,
                                       '' as desc_vchr,
                                       b.dosage_dec as discount_dec,
                                       0 as dosage_dec,
                                       a.itemspec_vchr,
                                       a.qty_dec as dosageqty,
                                       a.itemname_vchr,
                                       b.itemopinvtype_chr,
                                       b.itemcode_vchr,
                                       b.itemsrcid_vchr,
                                       b.itemsrcid_vchr as medicineid_chr,
                                       b.dosage_dec as basicdosage,
                                       b.itemipunit_chr,
                                       b.packqty_dec,
                                       f.typename_vchr,
                                       1 putmed_int,
                                       '' opusagedesc,
                                       '' as usagename_vchr,
                                       0 times_int1,
                                       0 days_int1,
                                       '' freqdesc,
                                       '' freqname_chr,
                                       0 times_int,
                                       0 min_qty_dec1,
                                       0 min_qty_dec,
                                       '' sumusage_vchr,
                                       't_opr_outpatientothrecipede' as fromtable,
                                       g.mednormalname_vchr,g.productorid_chr,
                                       a.itemunit_vchr,
                                       g.medicinetypeid_chr
                                  from t_opr_recipesend            m,
                                       t_opr_recipesendentry       n,
                                       t_opr_outpatientothrecipede a,
                                       t_bse_chargeitem            b,
                                       t_bse_chargeitemextype      f,
                                       t_bse_medicine              g
                                 where m.sid_int = n.sid_int
                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
                                   and a.itemid_chr = b.itemid_chr
                                   and a.deptmed_int = 0
                                   and a.outpatrecipeid_chr = ?
                                   and a.medstoreid_chr=?
                                   and b.itemopinvtype_chr = f.typeid_chr
                                   and b.itemsrcid_vchr = g.medicineid_chr(+)
                                 order by a.billrowno_int, a.itemname_vchr";
            string strSql4 = @"select a.outpatrecipeid_chr,
                                       b.dosageunit_chr,
                                       a.rowno_chr,
                                       a.itemid_chr,
                                       '' unitid_chr,
                                       a.qty_dec as qty_dec,
                                       a.price_mny as price_mny,
                                       a.tolprice_mny,
                                       a.medstoreid_chr,
                                       '' as usageid_chr,
                                       0 as days_int,
                                       '' as freqid_chr,
                                       '' as desc_vchr,
                                       b.dosage_dec as discount_dec,
                                       0 as dosage_dec,
                                       a.itemspec_vchr,
                                       a.qty_dec as dosageqty,
                                       a.itemname_vchr,
                                       b.itemopinvtype_chr,
                                       b.itemcode_vchr,
                                       b.itemsrcid_vchr,
                                       b.itemsrcid_vchr as medicineid_chr,
                                       b.dosage_dec as basicdosage,
                                       b.itemipunit_chr,
                                       b.packqty_dec,
                                       f.typename_vchr,
                                       1 putmed_int,
                                       '' opusagedesc,
                                       '' as usagename_vchr,
                                       0 times_int1,
                                       0 days_int1,
                                       '' freqdesc,
                                       '' freqname_chr,
                                       0 times_int,
                                       0 min_qty_dec1,
                                       0 min_qty_dec,
                                       '' sumusage_vchr,
                                       't_opr_outpatientchkrecipede' as fromtable,
                                       '' as mednormalname_vchr,''productorid_chr,
                                       a.itemunit_vchr,
                                       '' medicinetypeid_chr
                                    from t_opr_recipesend m,
                                         t_opr_recipesendentry n,
                                         t_opr_outpatientchkrecipede a,
                                         t_bse_chargeitem b,
                                         t_bse_chargeitemextype f
                                   where m.sid_int = n.sid_int
                                     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
                                     and a.itemid_chr = b.itemid_chr
                                     and a.outpatrecipeid_chr = ?
                                     and a.medstoreid_chr=?
                                     and b.itemopinvtype_chr = f.typeid_chr
                                order by a.billrowno_int, a.itemname_vchr";
            string strSql5 = @"select a.outpatrecipeid_chr,
                                       b.dosageunit_chr,
                                       a.rowno_chr,
                                       a.itemid_chr,
                                       '' unitid_chr,
                                       a.qty_dec as qty_dec,
                                       a.price_mny as price_mny,
                                       a.tolprice_mny,
                                       a.medstoreid_chr,
                                       '' as usageid_chr,
                                       0 as days_int,
                                       '' as freqid_chr,
                                       '' as desc_vchr,
                                       b.dosage_dec as discount_dec,
                                       0 as dosage_dec,
                                       a.itemspec_vchr,
                                       a.qty_dec as dosageqty,
                                       a.itemname_vchr,
                                       b.itemopinvtype_chr,
                                       b.itemcode_vchr,
                                       b.itemsrcid_vchr,
                                       b.itemsrcid_vchr as medicineid_chr,
                                       b.dosage_dec as basicdosage,
                                       b.itemipunit_chr,
                                       b.packqty_dec,
                                       f.typename_vchr,
                                       1 putmed_int,
                                       '' opusagedesc,
                                       '' as usagename_vchr,
                                       0 times_int1,
                                       0 days_int1,
                                       '' freqdesc,
                                       '' freqname_chr,
                                       0 times_int,
                                       0 min_qty_dec1,
                                       0 min_qty_dec,
                                       '' sumusage_vchr,
                                       't_opr_outpatienttestrecipede' as fromtable,
                                       '' as mednormalname_vchr,'' productorid_chr,
                                       a.itemunit_vchr,
                                       '' medicinetypeid_chr
                                  from t_opr_recipesend             m,
                                       t_opr_recipesendentry        n,
                                       t_opr_outpatienttestrecipede a,
                                       t_bse_chargeitem             b,
                                       t_bse_chargeitemextype       f
                                 where m.sid_int = n.sid_int
                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
                                   and a.itemid_chr = b.itemid_chr
                                   and a.outpatrecipeid_chr = ?
                                   and a.medstoreid_chr=?
                                   and b.itemopinvtype_chr = f.typeid_chr
                                 order by a.billrowno_int, a.itemname_vchr";
            string strSql6 = @"select a.outpatrecipeid_chr,
                                       b.dosageunit_chr,
                                       a.rowno_chr,
                                       a.itemid_chr,
                                       '' unitid_chr,
                                       a.qty_dec as qty_dec,
                                       a.price_mny as price_mny,
                                       a.tolprice_mny,
                                       a.medstoreid_chr,
                                       '' as usageid_chr,
                                       0 as days_int,
                                       '' as freqid_chr,
                                       '' as desc_vchr,
                                       b.dosage_dec as discount_dec,
                                       0 as dosage_dec,
                                       a.itemspec_vchr,
                                       a.qty_dec as dosageqty,
                                       a.itemname_vchr,
                                       b.itemopinvtype_chr,
                                       b.itemcode_vchr,
                                       b.itemsrcid_vchr,
                                       b.itemsrcid_vchr as medicineid_chr,
                                       b.dosage_dec as basicdosage,
                                       b.itemipunit_chr,
                                       b.packqty_dec,
                                       f.typename_vchr,
                                       1 putmed_int,
                                       '' opusagedesc,
                                       '' as usagename_vchr,
                                       0 times_int1,
                                       0 days_int1,
                                       '' freqdesc,
                                       '' freqname_chr,
                                       0 times_int,
                                       0 min_qty_dec1,
                                       0 min_qty_dec,
                                       '' sumusage_vchr,
                                       't_opr_outpatientopsrecipede' as fromtable,
                                       '' as mednormalname_vchr,'' productorid_chr,
                                       a.itemunit_vchr,
                                       '' medicinetypeid_chr
                                  from t_opr_recipesend            m,
                                       t_opr_recipesendentry       n,
                                       t_opr_outpatientopsrecipede a,
                                       t_bse_chargeitem            b,
                                       t_bse_chargeitemextype      f
                                 where m.sid_int = n.sid_int
                                   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
                                   and a.itemid_chr = b.itemid_chr
                                   and a.outpatrecipeid_chr = ?
                                   and a.medstoreid_chr=?
                                   and b.itemopinvtype_chr = f.typeid_chr
                                 order by a.billrowno_int, a.itemname_vchr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams1 = null;
                int a = -1;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams1);
                arrParams1[++a].Value = strsid_int;
                arrParams1[++a].Value = strmedstoreid_chr;
                objHRPSvc.lngGetDataTableWithParameters(strSql1, ref m_dtbDetail1, arrParams1);

                System.Data.IDataParameter[] arrParams2 = null;
                int b = -1;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams2);
                arrParams2[++b].Value = strsid_int;
                arrParams2[++b].Value = strmedstoreid_chr;
                objHRPSvc.lngGetDataTableWithParameters(strSql2, ref m_dtbDetail2, arrParams2);

                System.Data.IDataParameter[] arrParams3 = null;
                int c = -1;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams3);
                arrParams3[++c].Value = strsid_int;
                arrParams3[++c].Value = strmedstoreid_chr;
                objHRPSvc.lngGetDataTableWithParameters(strSql3, ref m_dtbDetail3, arrParams3);

                System.Data.IDataParameter[] arrParams4 = null;
                int d = -1;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams4);
                arrParams4[++d].Value = strsid_int;
                arrParams4[++d].Value = strmedstoreid_chr;
                objHRPSvc.lngGetDataTableWithParameters(strSql4, ref m_dtbDetail4, arrParams4);

                System.Data.IDataParameter[] arrParams5 = null;
                int e = -1;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams5);
                arrParams5[++e].Value = strsid_int;
                arrParams5[++e].Value = strmedstoreid_chr;
                objHRPSvc.lngGetDataTableWithParameters(strSql5, ref m_dtbDetail5, arrParams5);

                System.Data.IDataParameter[] arrParams6 = null;
                int f = -1;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams6);
                arrParams6[++f].Value = strsid_int;
                arrParams6[++f].Value = strmedstoreid_chr;
                objHRPSvc.lngGetDataTableWithParameters(strSql6, ref m_dtbDetail6, arrParams6);

                objHRPSvc.Dispose();

                m_dtbDetail = m_dtbDetail1.Clone();
                m_dtbDetail.BeginLoadData();
                DataRow dr = null;
                for (int i1 = 0; i1 < m_dtbDetail1.Rows.Count; i1++)
                {
                    dr = m_dtbDetail1.Rows[i1];
                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
                }

                for (int i1 = 0; i1 < m_dtbDetail2.Rows.Count; i1++)
                {
                    dr = m_dtbDetail2.Rows[i1];
                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
                }

                for (int i1 = 0; i1 < m_dtbDetail3.Rows.Count; i1++)
                {
                    dr = m_dtbDetail3.Rows[i1];
                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
                }

                for (int i1 = 0; i1 < m_dtbDetail4.Rows.Count; i1++)
                {
                    dr = m_dtbDetail4.Rows[i1];
                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
                }

                for (int i1 = 0; i1 < m_dtbDetail5.Rows.Count; i1++)
                {
                    dr = m_dtbDetail5.Rows[i1];
                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
                }

                for (int i1 = 0; i1 < m_dtbDetail6.Rows.Count; i1++)
                {
                    dr = m_dtbDetail6.Rows[i1];
                    m_dtbDetail.LoadDataRow(dr.ItemArray, true);
                }
                m_dtbDetail.EndLoadData();

                m_dtbDetail.AcceptChanges();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (m_dtbDetail.Rows.Count > 0)
            {
                return lngRes = 1;
            }
            else
                return lngRes;
        }
        #endregion
    }
}
