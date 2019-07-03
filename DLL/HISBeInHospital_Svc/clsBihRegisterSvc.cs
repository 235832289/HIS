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
    /// 创建时间： 2004-09-03
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBihRegisterSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造函数
        public clsBihRegisterSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        //T_OPR_BIH_REGISTER(住院登记)
        #region 增加住院登记
        /// <summary>
        /// 增加住院登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">流水号 [out 参数]</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewBihRegister(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsT_Opr_Bih_Register_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewBihRegister");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            lngRes = objHRPSvc.m_lngGenerateNewID("T_Opr_Bih_Register", "registerid_chr", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            //			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"INSERT INTO t_opr_bih_register
            (registerid_chr, modify_dat, patientid_chr, isbooking_int,
             inpatientid_chr, inpatient_dat, deptid_chr, areaid_chr,
             bedid_chr, type_int, diagnose_vchr, limitrate_mny,
             inpatientcount_int, state_int, status_int, operatorid_chr,
             pstatus_int, casedoctor_chr, des_vchr, inpatientnotype_int,
             mzdoctor_chr, mzdiagnose_vchr, diagnoseid_chr, icd10diagid_vchr,
             icd10diagtext_vchr, clinicsayprepay, paytypeid_chr
            )
     VALUES (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(27, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;
                objLisAddItemRefArr[1].Value = DateTime.Parse(p_objRecord.m_strMODIFY_DAT);
                objLisAddItemRefArr[2].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_intISBOOKING_INT;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[5].Value = DateTime.Parse(p_objRecord.m_strINPATIENT_DAT);
                objLisAddItemRefArr[6].Value = p_objRecord.m_strDEPTID_CHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strAREAID_CHR;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strBEDID_CHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_intTYPE_INT;
                objLisAddItemRefArr[10].Value = p_objRecord.m_strDIAGNOSE_VCHR;
                objLisAddItemRefArr[11].Value = p_objRecord.m_dblLIMITRATE_MNY;
                objLisAddItemRefArr[12].Value = p_objRecord.m_intINPATIENTCOUNT_INT;
                objLisAddItemRefArr[13].Value = p_objRecord.m_intSTATE_INT;
                objLisAddItemRefArr[14].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[15].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[16].Value = p_objRecord.m_intPSTATUS_INT;
                objLisAddItemRefArr[17].Value = p_objRecord.m_strCASEDOCTOR_CHR;
                objLisAddItemRefArr[18].Value = p_objRecord.DES_VCHR;
                objLisAddItemRefArr[19].Value = p_objRecord.m_intINPATIENTNOTYPE_INT;
                objLisAddItemRefArr[20].Value = p_objRecord.m_strMZDOCTOR_CHR;
                objLisAddItemRefArr[21].Value = p_objRecord.m_strMZDIAGNOSE_VCHR;
                objLisAddItemRefArr[22].Value = p_objRecord.m_strDIAGNOSEID_CHR;
                objLisAddItemRefArr[23].Value = p_objRecord.m_strICD10DIAGID_VCHR;
                objLisAddItemRefArr[24].Value = p_objRecord.m_strICD10DIAGTEXT_VCHR;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCLINICSAYPREPAY;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strPAYTYPEID_CHR;

                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);

                #region NewEMR.Itf
                DataTable dt = null;
                string Sql = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = '6666' and t.status_int = 1";
                objHRPSvc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int val = 0;
                    int.TryParse(dt.Rows[0][0].ToString(), out val);
                    if (val == 1)
                    {
                        Sql = @"select t.* from t_bse_patient t where t.patientid_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                        objHRPSvc.lngGetDataTableWithParameters(Sql, ref dt, objLisAddItemRefArr);

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;

                        Sql = @"delete from t_bse_patient where patientid_vchr = ?";
                        emrSvc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = p_objRecord.m_strPATIENTID_CHR;
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                        Sql = @"insert into t_bse_patient
                                  (patientid_vchr,
                                   patientname_vchr,
                                   sex_vchr,
                                   birthday_dat,
                                   nationality_vchr,
                                   nativeplace_vchr,
                                   birthplace_vchr,
                                   idcard_vchr,
                                   occupation_vchr,
                                   homeaddr_vchr,
                                   hometel_vchr,
                                   contactname_vchr,
                                   contacttel_vchr,
                                   contactaddr_vchr,
                                   contactrelation_vchr,
                                   status_int,
                                   operdate_dat,
                                   householdregaddr_vchr)
                                values
                                  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                        DataRow drPat = dt.Rows[0];
                        int n = -1;
                        parm = null;
                        emrSvc.CreateDatabaseParameter(18, out parm);
                        parm[++n].Value = drPat["patientid_chr"].ToString();
                        parm[++n].Value = drPat["lastname_vchr"].ToString();
                        parm[++n].Value = drPat["sex_chr"].ToString();
                        if (drPat["birth_dat"] == DBNull.Value)
                            parm[++n].Value = null;
                        else
                            parm[++n].Value = Convert.ToDateTime(drPat["birth_dat"].ToString());
                        parm[++n].Value = drPat["nationality_vchr"].ToString();
                        parm[++n].Value = drPat["nativeplace_vchr"].ToString();
                        parm[++n].Value = drPat["birthplace_vchr"].ToString();
                        parm[++n].Value = drPat["idcard_chr"].ToString();
                        parm[++n].Value = drPat["occupation_vchr"].ToString();
                        parm[++n].Value = drPat["homeaddress_vchr"].ToString();
                        parm[++n].Value = drPat["homephone_vchr"].ToString();
                        parm[++n].Value = drPat["contactpersonlastname_vchr"].ToString();
                        parm[++n].Value = drPat["contactpersonphone_vchr"].ToString();
                        parm[++n].Value = drPat["contactpersonaddress_vchr"].ToString();
                        parm[++n].Value = drPat["contactpersonpc_chr"].ToString();
                        parm[++n].Value = 1;
                        parm[++n].Value = DateTime.Parse(p_objRecord.m_strMODIFY_DAT);
                        parm[++n].Value = "";
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                        Sql = @"insert into t_ip_register
                                      (registerid_int,
                                       registerdate_dat,
                                       indate_dat,
                                       patientid_vchr,
                                       patientipno_vchr,
                                       iptimes_int,
                                       areaid_int,
                                       deptid_int,
                                       doctid_int,
                                       paytype_vchr,
                                       indiagnosis_vchr,
                                       outdiagnosis_vchr,
                                       outtype_int,
                                       outdate_dat,
                                       inoperid_int,
                                       outoperid_int,
                                       status_int)
                                    values
                                      (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                        n = -1;
                        parm = null;
                        emrSvc.CreateDatabaseParameter(17, out parm);
                        parm[++n].Value = Convert.ToDecimal(p_strRecordID);
                        parm[++n].Value = DateTime.Parse(p_objRecord.m_strMODIFY_DAT);
                        parm[++n].Value = null;
                        parm[++n].Value = p_objRecord.m_strPATIENTID_CHR;
                        parm[++n].Value = p_objRecord.m_strINPATIENTID_CHR;
                        parm[++n].Value = p_objRecord.m_intINPATIENTCOUNT_INT;
                        if (string.IsNullOrEmpty(p_objRecord.m_strAREAID_CHR))
                            parm[++n].Value = null;
                        else
                            parm[++n].Value = Convert.ToDecimal(p_objRecord.m_strAREAID_CHR);
                        if (string.IsNullOrEmpty(p_objRecord.m_strDEPTID_CHR))
                            parm[++n].Value = null;
                        else
                            parm[++n].Value = Convert.ToDecimal(p_objRecord.m_strDEPTID_CHR);
                        if (string.IsNullOrEmpty(p_objRecord.m_strCASEDOCTOR_CHR))
                            parm[++n].Value = null;
                        else
                            parm[++n].Value = Convert.ToDecimal(p_objRecord.m_strCASEDOCTOR_CHR);
                        parm[++n].Value = p_objRecord.m_strPAYTYPEID_CHR;
                        parm[++n].Value = p_objRecord.m_strMZDIAGNOSE_VCHR;
                        parm[++n].Value = null;
                        parm[++n].Value = null;
                        parm[++n].Value = null;
                        if (string.IsNullOrEmpty(p_objRecord.m_strOPERATORID_CHR))
                            parm[++n].Value = null;
                        else
                            parm[++n].Value = Convert.ToDecimal(p_objRecord.m_strOPERATORID_CHR);
                        parm[++n].Value = null;
                        parm[++n].Value = 1;
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
                        emrSvc.Dispose();
                    }
                }
                #endregion
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
        #region 查询
        /// <summary>
        /// 查询所有的住院登记［有效的］
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllBihRegisterInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
        {
            //{status_int 状态：-1历史、0无效、1有效}	
            return m_lngGetBihRegisterInfo(p_objPrincipal, " status_int = 1 ", out p_objResultArr);
        }
        /// <summary>
        /// 根据住院号 查询住院登记　[有效的记录]
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBinRegisterByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
        {
            string strQueryCondition = " status_int = '1' AND ";
            strQueryCondition += " Inpatientid_chr = '" + p_strInpatientid_chr.Trim() + "'";
            return m_lngGetBihRegisterInfo(p_objPrincipal, strQueryCondition, out p_objResultArr);
        }

        /// <summary>
        /// 根据住院流水号 查询住院登记　[有效的记录]
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">住院流水号 </param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBinRegisterByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            p_objResult = new clsT_Opr_Bih_Register_VO();

            clsT_Opr_Bih_Register_VO[] p_objResultArr;
            string strQueryCondition = " status_int = '1' AND ";
            strQueryCondition += " registerid_chr = '" + p_strRegisterid_chr.Trim() + "'";
            long lngReturn = m_lngGetBihRegisterInfo(p_objPrincipal, strQueryCondition, out p_objResultArr);
            if (lngReturn > 0 && p_objResultArr.Length > 0)
                p_objResult = p_objResultArr[0];
            return lngReturn;
        }

        /// <summary>
        /// 获取住院号的最近一次[有效的]住院登记流水号，没有则获取为空串
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="p_strRegisterid_chr">住院登记流水号 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisteridByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, out string p_strRegisterid_chr)
        {
            p_strRegisterid_chr = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetRegisteridByInpatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            //查询条件：  确保查询SQL可以执行。	  	 
            //string strSQL = @"SELECT * FROM T_Opr_Bih_Register WHERE status_int = 1 And Inpatientid_chr = '" + p_strInpatientid_chr + "' ORDER BY modify_dat DESC";
            string strSQL = @"SELECT * FROM T_Opr_Bih_Register WHERE status_int = 1 And Inpatientid_chr = '" + p_strInpatientid_chr + "' ORDER BY inpatient_dat DESC";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_strRegisterid_chr = dtbResult.Rows[0]["registerid_chr"].ToString();
                }
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
        /// 获取住院号的最近一次[有效的]住院登记流水号，没有则获取为空串
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="p_strRegisterid_chr">住院登记流水号 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisteridByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, out string[] p_strRegisteridArr)
        {
            p_strRegisteridArr = new string[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetRegisteridByInpatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            //查询条件：  确保查询SQL可以执行。
            string strCheckCount = @"SELECT Count(*) as c FROM T_Opr_Bih_Register WHERE status_int = 1 And Inpatientid_chr = '" + p_strInpatientid_chr + "' ORDER BY inpatient_dat";
            string strSQL = @"SELECT * FROM T_Opr_Bih_Register WHERE status_int = 1 And Inpatientid_chr = '" + p_strInpatientid_chr + "' ORDER BY inpatient_dat";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strCheckCount, ref dtbResult);
                if (lngRes > 0 && int.Parse(dtbResult.Rows[0]["c"].ToString()) < 1)
                {
                    return lngRes;
                }
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_strRegisteridArr = new string[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_strRegisteridArr[i] = dtbResult.Rows[i]["registerid_chr"].ToString();
                    }
                }
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
        /// 按条件——住院登记查询
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition">查询条件</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihRegisterInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBihRegisterInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT   a.*, (SELECT deptname_vchr
                 FROM t_bse_deptdesc
                WHERE deptid_chr = a.deptid_chr) deptname,
         (SELECT deptname_vchr
            FROM t_bse_deptdesc
           WHERE deptid_chr = a.areaid_chr) areaname,
         (SELECT code_chr
            FROM t_bse_bed
           WHERE bedid_chr = a.bedid_chr) bedno,
         (SELECT lastname_vchr
            FROM t_bse_employee
           WHERE RTRIM (LTRIM (empid_chr)) =
                                RTRIM (LTRIM (a.operatorid_chr)))
                                                                 operatorname,
         (SELECT lastname_vchr
            FROM t_bse_employee
           WHERE RTRIM (LTRIM (empid_chr)) =
                                  RTRIM (LTRIM (a.casedoctor_chr)))
                                                                   doctorname,
         (SELECT lastname_vchr
            FROM t_bse_employee
           WHERE RTRIM (LTRIM (empid_chr)) =
                                 RTRIM (LTRIM (a.mzdoctor_chr)))
                                                                outdoctorname,
         b.flgname_vchr AS typename, c.flgname_vchr AS pstatusname
    FROM t_opr_bih_register a, t_sys_flg_table b, t_sys_flg_table c
   WHERE a.type_int = b.flg_int
     AND a.pstatus_int = c.flg_int
     AND b.tablename_vchr = 't_opr_bih_register'
     AND b.columnseq_int = 9
     AND c.tablename_vchr = 't_opr_bih_register'
     AND c.columnseq_int = 16
     ";

            /* @update by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */

            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT a.*,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.deptid_chr) DeptName 
	,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.areaid_chr) AreaName 
		,(select code_chr from t_bse_bed where bedid_chr=a.bedid_chr) BedNo 
		,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE Rtrim(LTRIM(empid_chr)) =Rtrim(LTRIM(a.operatorid_chr))) OPERATORNAME 
		,(select LastName_vchr from T_BSE_EMPLOYEE where Rtrim(LTRIM(empid_chr)) = Rtrim(LTRIM(a.CASEDOCTOR_CHR))) doctorname
		,(select LastName_vchr from T_BSE_EMPLOYEE where Rtrim(LTRIM(empid_chr))= Rtrim(LTRIM(a.MZDOCTOR_CHR))) outdoctorname,
		--,decode(type_int,1,'门诊',2,'急诊',3,'他院转入',4,'他科转入','') TypeName 
		--,decode(pstatus_int,0,'未上床',1,'已上床',2,'预出院',3,'实际出院','') PstatusName 
               (CASE type_int when 1 then '门诊' when 2 then '急诊' when 3 then '他院转入' when 4 then '他科转入' else '' end) TypeName,
	       (CASE pstatus_int when 0 then '未上床' when 1 then '已上床' when 2 then '预出院' when 3 then '实际出院' else '' end) PstatusName 
	     FROM t_opr_bih_register a ";
            }
            /* <<======================================= */


            if (p_strQueryCondition != string.Empty)
            {
                strSQL += " AND  " + p_strQueryCondition;
            }
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Register_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Register_VO();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strPATIENTID_CHR = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["ISBOOKING_INT"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_intISBOOKING_INT = Convert.ToInt32(dtbResult.Rows[i1]["ISBOOKING_INT"].ToString().Trim());
                        }
                        p_objResultArr[i1].m_strINPATIENTID_CHR = dtbResult.Rows[i1]["INPATIENTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strINPATIENT_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["INPATIENT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strDEPTID_CHR = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAREAID_CHR = dtbResult.Rows[i1]["AREAID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strBEDID_CHR = dtbResult.Rows[i1]["BEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intTYPE_INT = Convert.ToInt32(dtbResult.Rows[i1]["TYPE_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strDIAGNOSE_VCHR = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["LIMITRATE_MNY"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_dblLIMITRATE_MNY = Convert.ToDouble(dtbResult.Rows[i1]["LIMITRATE_MNY"].ToString().Trim());
                        }
                        p_objResultArr[i1].m_intINPATIENTCOUNT_INT = Convert.ToInt16(dtbResult.Rows[i1]["INPATIENTCOUNT_INT"].ToString().Trim());
                        p_objResultArr[i1].m_intSTATE_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATE_INT"].ToString().Trim());
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intPSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
                        // 入院科室名称 [非字段]
                        p_objResultArr[i1].m_strDeptName = dtbResult.Rows[i1]["DeptName"].ToString().Trim();
                        // 入院病区名称 [非字段]
                        if (dtbResult.Rows[i1]["AreaName"] != null)
                        {
                            p_objResultArr[i1].m_strAreaName = dtbResult.Rows[i1]["AreaName"].ToString().Trim();
                        }
                        // 入院床号 [非字段]
                        if (dtbResult.Rows[i1]["BedNo"] != null)
                        {
                            p_objResultArr[i1].m_strBedNo = dtbResult.Rows[i1]["BedNo"].ToString().Trim();
                        }
                        // 操作人名称 [非字段]
                        p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OperatorName"].ToString().Trim();
                        // 入院方式名称	[非字段]	{1=门诊;2=急诊;3=他院转入}
                        p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        // 状态标志	[非字段] {0=未上床;1=已上床;2=预出院;3=实际出院}
                        p_objResultArr[i1].m_strPstatusName = dtbResult.Rows[i1]["PstatusName"].ToString().Trim();
                        p_objResultArr[i1].m_strCASEDOCTOR_CHR = dtbResult.Rows[i1]["CASEDOCTOR_CHR"].ToString().Trim();
                        //门诊医生
                        p_objResultArr[i1].m_strMZDOCTOR_CHR = dtbResult.Rows[i1]["MZDOCTOR_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_stroutdoctorname = dtbResult.Rows[i1]["outdoctorname"].ToString().Trim();
                        //门诊诊断
                        p_objResultArr[i1].m_strMZDIAGNOSE_VCHR = dtbResult.Rows[i1]["MZDIAGNOSE_VCHR"].ToString().Trim();

                        #region 备注 入院诊断(ICD10)	glzhang	2005.08.10
                        p_objResultArr[i1].m_strDIAGNOSEID_CHR = dtbResult.Rows[i1]["DIAGNOSEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].DES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strICD10DIAGID_VCHR = dtbResult.Rows[i1]["ICD10DIAGID_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strICD10DIAGTEXT_VCHR = dtbResult.Rows[i1]["ICD10DIAGTEXT_VCHR"].ToString().Trim();
                        #endregion
                        //门诊建议预交金
                        p_objResultArr[i1].m_strCLINICSAYPREPAY = dtbResult.Rows[i1]["CLINICSAYPREPAY"].ToString().Trim();
                        try
                        {
                            p_objResultArr[i1].m_intINPATIENTNOTYPE_INT = int.Parse(dtbResult.Rows[i1]["INPATIENTNOTYPE_INT"].ToString());
                        }
                        catch
                        {
                            p_objResultArr[i1].m_intINPATIENTNOTYPE_INT = -1;
                        }
                        p_objResultArr[i1].m_strdoctname = dtbResult.Rows[i1]["doctorname"].ToString().Trim();

                        p_objResultArr[i1].m_strOutDiagnose = dtbResult.Rows[i1]["OUTDIAGNOSE_VCHR"].ToString().Trim();

                        p_objResultArr[i1].m_intDiseaseType = int.Parse(dtbResult.Rows[i1]["diseasetype_int"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #region	编写根据"病人id"调历次入院记录的方法接口	glzhang	2005.08.2
        /// <summary>
        /// 编写根据"病人id"调历次入院记录的方法接口	glzhang	2005.08.2
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatienID">病人id</param>
        /// <param name="p_DtbResult">结果集:"病人登记号id","入院时间"</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBeInHospitalInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatienID, out DataTable p_DtbResult)
        {
            p_DtbResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBeInHospitalInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT REGISTERID_CHR,INPATIENT_DAT
							FROM t_opr_bih_register t1
							WHERE t1.patientid_chr = '" + p_strPatienID + "' " +
                            "order by INPATIENT_DAT";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_DtbResult);
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

        #region 通过registerid得到病人信息
        /// <summary>
        /// 通过registerid得到病人信息
        /// </summary>
        /// <param name="registerid"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientInfobyRegisterID(string registerid, ref DataTable dtResult)
        {
            long lngRes = 0;
            string strSQL = @"select a.lastname_vchr, a.sex_chr, a.birth_dat, b.deptname_vchr, c.code_chr,
                                   d.inpatientid_chr
                              from t_opr_bih_registerdetail a,
                                   t_bse_deptdesc b,
                                   t_bse_bed c,
                                   t_opr_bih_register d
                             where d.registerid_chr = a.registerid_chr
                               and d.areaid_chr = b.deptid_chr(+)
                               and d.bedid_chr = c.bedid_chr
                               and d.registerid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = registerid;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
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
        #region 修改
        #region  修改——修改住院登记的记录状态｛-1历史、0无效、1有效｝
        /// <summary>
        /// 修改住院登记的记录状态｛-1历史、0无效、1有效｝
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">住院号</param>
        /// <param name="p_intStatus_int">状态｛-1历史、0无效、1有效｝</param>
        /// <param name="p_strOPERATORID_CHR">操作人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihRegisterByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, int p_intStatus_int, string p_strOPERATORID_CHR)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihRegisterByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Register SET ";
            strSQLUpdate += " Status_int =" + p_intStatus_int.ToString();
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
            strSQLUpdate += " ,MODIFY_DAT = SYSDATE ";
            strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr.Trim() + "'";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQLUpdate = "UPDATE  T_Opr_Bih_Register SET ";
                strSQLUpdate += " Status_int =" + p_intStatus_int.ToString();
                strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
                strSQLUpdate += " ,MODIFY_DAT = GETDATE() ";
                strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr.Trim() + "'";

            }
            /* <<======================================= */

            return m_lngModifyBihRegisterInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region  修改在院状态{0=未上床;1=已上床;2=预出院;3=实际出院}
        /// <summary>
        /// 修改住院登记的状态{0=未上床;1=已上床;2=预出院;3=实际出院}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">住院号</param>
        /// <param name="p_intPSTATUS_INT">状态{0=未上床;1=已上床;2=预出院;3=实际出院}</param>
        /// <param name="p_strOPERATORID_CHR">操作人</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihRegisterPSTATUS_INTByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, int p_intPSTATUS_INT, string p_strOPERATORID_CHR, string ModifyDate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihRegisterPSTATUS_INTByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Register SET ";
            strSQLUpdate += " PSTATUS_INT =" + p_intPSTATUS_INT.ToString();
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
            strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr.Trim() + "'";

            return m_lngModifyBihRegisterInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region 修改——入院科室、入院病区、病床号、在院状态
        /// <summary>
        /// 修改——入院科室、入院病区、病床号、在院状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">流水号</param>
        /// <param name="p_strDEPTID_CHR">入院科室</param>
        /// <param name="p_strAREAID_CHR">入院病区</param>
        /// <param name="p_strBEDID_CHR">病床</param>
        /// <param name="intPSTATUS_INT">{0=未上床;1=已上床;2=预出院;3=实际出院}</param>
        /// <param name="p_strOPERATORID_CHR">操作人</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBedInfoByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, string p_strDEPTID_CHR, string p_strAREAID_CHR, string p_strBEDID_CHR, int intPSTATUS_INT, string p_strOPERATORID_CHR, string p_strModifyDate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihRegisterByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Register SET ";
            strSQLUpdate += "  DEPTID_CHR ='" + p_strDEPTID_CHR + "' ";
            strSQLUpdate += " ,AREAID_CHR ='" + p_strAREAID_CHR + "' ";
            strSQLUpdate += " ,BEDID_CHR ='" + p_strBEDID_CHR + "' ";
            strSQLUpdate += " ,PSTATUS_INT =" + intPSTATUS_INT + " ";
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR + "' ";
            strSQLUpdate += " ,MODIFY_DAT = TO_DATE('" + p_strModifyDate + "','YYYY-MM-DD HH24:MI:SS') ";
            strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr + "'";

            /* @update by wjqin (05-11-28)
                         * 添加SQL SERVER的strSQl版本语名
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQLUpdate = "UPDATE  T_Opr_Bih_Register SET ";
                strSQLUpdate += "  DEPTID_CHR ='" + p_strDEPTID_CHR + "' ";
                strSQLUpdate += " ,AREAID_CHR ='" + p_strAREAID_CHR + "' ";
                strSQLUpdate += " ,BEDID_CHR ='" + p_strBEDID_CHR + "' ";
                strSQLUpdate += " ,PSTATUS_INT =" + intPSTATUS_INT + " ";
                strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR + "' ";
                strSQLUpdate += " ,MODIFY_DAT = CONVERT(DATETIME,'" + p_strModifyDate + "') ";
                strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr + "'";
            }
            /* <<======================================= */

            return m_lngModifyBihRegisterInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region 修改——入院科室、入院病区、病床号、在院状态
        /// <summary>
        /// 修改——入院科室、入院病区、病床号、在院状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">流水号</param>
        /// <param name="p_strDEPTID_CHR">入院科室</param>
        /// <param name="p_strAREAID_CHR">入院病区</param>
        /// <param name="p_strBEDID_CHR">病床</param>
        /// <param name="intPSTATUS_INT">{0=未上床;1=已上床;2=预出院;3=实际出院}</param>
        /// <param name="p_strOPERATORID_CHR">操作人</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBedInfoByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, string p_strDEPTID_CHR, string p_strAREAID_CHR, string p_strBEDID_CHR, int intPSTATUS_INT, string p_strOPERATORID_CHR, string p_strModifyDate, string p_strCASEDOCTOR_CHR)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihRegisterByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Register SET ";
            strSQLUpdate += "  DEPTID_CHR ='" + p_strDEPTID_CHR + "' ";
            strSQLUpdate += " ,AREAID_CHR ='" + p_strAREAID_CHR + "' ";
            strSQLUpdate += " ,BEDID_CHR ='" + p_strBEDID_CHR + "' ";
            strSQLUpdate += " ,PSTATUS_INT =" + intPSTATUS_INT + " ";
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR + "' ";
            strSQLUpdate += " ,MODIFY_DAT = TO_DATE('" + p_strModifyDate + "','YYYY-MM-DD HH24:MI:SS') ";
            strSQLUpdate += " ,CASEDOCTOR_CHR ='" + p_strCASEDOCTOR_CHR + "' ";
            strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr + "'";

            return m_lngModifyBihRegisterInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region 修改住院登记信息 add by wjqin(06-06-21)
        /// <summary>
        /// 修改住院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">流水号</param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihRegisterInfoByVo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, clsT_Opr_Bih_Register_VO objPatientVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyBihRegisterInfoByVo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQLUpdate = "UPDATE  T_OPR_BIH_REGISTER SET ";
            strSQLUpdate += "   PATIENTID_CHR = '" + objPatientVO.m_strPATIENTID_CHR.Trim() + "' ";
            strSQLUpdate += " , ISBOOKING_INT = " + objPatientVO.m_intISBOOKING_INT.ToString() + " ";
            strSQLUpdate += " , INPATIENTID_CHR = '" + objPatientVO.m_strINPATIENTID_CHR.Trim() + "' ";
            //strSQLUpdate += " , DEPTID_CHR = '" + objPatientVO.m_strDEPTID_CHR.Trim()  + "' ";
            strSQLUpdate += "   ,PAYTYPEID_CHR='" + objPatientVO.m_strPAYTYPEID_CHR + "'";
            strSQLUpdate += " , AREAID_CHR = '" + objPatientVO.m_strAREAID_CHR.Trim() + "' ";
            strSQLUpdate += " , BEDID_CHR = '" + objPatientVO.m_strBEDID_CHR.Trim() + "' ";
            strSQLUpdate += " , CASEDOCTOR_CHR = '" + objPatientVO.m_strCASEDOCTOR_CHR.Trim() + "' ";
            strSQLUpdate += " , TYPE_INT = '" + objPatientVO.m_intTYPE_INT.ToString() + "' ";
            strSQLUpdate += " , DIAGNOSE_VCHR = '" + objPatientVO.m_strDIAGNOSE_VCHR.Trim() + "' ";
            strSQLUpdate += " , LIMITRATE_MNY = " + objPatientVO.m_dblLIMITRATE_MNY.ToString() + " ";
            strSQLUpdate += " , INPATIENTCOUNT_INT = " + objPatientVO.m_intINPATIENTCOUNT_INT.ToString() + " ";
            strSQLUpdate += " , STATE_INT = " + objPatientVO.m_intSTATE_INT.ToString() + " ";
            strSQLUpdate += " , STATUS_INT = " + objPatientVO.m_intSTATUS_INT.ToString() + " ";
            strSQLUpdate += " , PSTATUS_INT = " + objPatientVO.m_intPSTATUS_INT.ToString() + " ";
            strSQLUpdate += " , OPERATORID_CHR = '" + objPatientVO.m_strOPERATORID_CHR.Trim() + "' ";
            strSQLUpdate += " , INPATIENTNOTYPE_INT = " + objPatientVO.m_intINPATIENTNOTYPE_INT + "";
            strSQLUpdate += " , DES_VCHR = '" + objPatientVO.DES_VCHR.Trim() + "' ";
            strSQLUpdate += " , MZDOCTOR_CHR = '" + objPatientVO.m_strMZDOCTOR_CHR.Trim() + "' ";
            strSQLUpdate += " , MZDIAGNOSE_VCHR = '" + objPatientVO.m_strMZDIAGNOSE_VCHR.Trim() + "' ";
            strSQLUpdate += " , DIAGNOSEID_CHR = '" + objPatientVO.m_strDIAGNOSEID_CHR.Trim() + "' ";
            strSQLUpdate += " , ICD10DIAGID_VCHR = '" + objPatientVO.m_strICD10DIAGID_VCHR.Trim() + "' ";
            strSQLUpdate += " , ICD10DIAGTEXT_VCHR = '" + objPatientVO.m_strICD10DIAGTEXT_VCHR.Trim() + "' ";

            if (objPatientVO.m_strCLINICSAYPREPAY != null && objPatientVO.m_strCLINICSAYPREPAY != "")
            {
                strSQLUpdate += " , CLINICSAYPREPAY = '" + objPatientVO.m_strCLINICSAYPREPAY.Trim() + "' ";
            }
            //strSQLUpdate += " , MODIFY_DAT = SYSDATE ";
            strSQLUpdate += " , INPATIENT_DAT = TO_DATE('" + objPatientVO.m_strINPATIENT_DAT.Trim() + "', 'YYYY-MM-DD HH24:MI:SS') ";
            strSQLUpdate += "  WHERE REGISTERID_CHR = '" + p_strRegisterid_chr.Trim() + "'";

            clsRecordMark_VO Markvo = new clsRecordMark_VO();
            clsRecordMark recordMark = new clsRecordMark();
            Markvo.m_strOPERATORID_CHR = objPatientVO.m_strOPERATORID_CHR;
            Markvo.m_strTABLESEQID_CHR = "1";
            Markvo.m_strRECORDDETAIL_VCHR = strSQLUpdate;
            recordMark.m_mthAddNewRecord(Markvo);
            return m_lngModifyBihRegisterInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region 修改住院登记信息
        /// <summary>
        /// 修改住院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">流水号</param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihRegisterInfoByVo(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Register_VO objPatientVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyBihRegisterInfoByVo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQLUpdate = "UPDATE  T_OPR_BIH_REGISTER SET ";
            strSQLUpdate += "  DEPTID_CHR = '" + objPatientVO.m_strDEPTID_CHR.Trim() + "' ";
            strSQLUpdate += " , AREAID_CHR = '" + objPatientVO.m_strAREAID_CHR.Trim() + "' ";
            strSQLUpdate += " , BEDID_CHR = '" + objPatientVO.m_strBEDID_CHR.Trim() + "' ";
            strSQLUpdate += " , PSTATUS_INT = " + objPatientVO.m_intPSTATUS_INT.ToString() + " ";
            strSQLUpdate += " , MODIFY_DAT = to_date('" + objPatientVO.m_strMODIFY_DAT + "','YYYY-MM-DD HH24:MI:SS') ";
            strSQLUpdate += "  WHERE REGISTERID_CHR = '" + objPatientVO.m_strREGISTERID_CHR.Trim() + "'";

            return m_lngModifyBihRegisterInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion

        #region 修改住院信息(在床位编辑时用到)	glzhang	2005.08.19
        /// <summary>
        /// 修改住院信息(在床位编辑时用到)	glzhang	2005.08.19
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">流水号</param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBedInfoByVo(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Register_VO objPatientVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyBedInfoByVo");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQLUpdate = "UPDATE  T_OPR_BIH_REGISTER SET ";
            strSQLUpdate += " CASEDOCTOR_CHR = ?";
            strSQLUpdate += " , DIAGNOSEID_CHR = ? ";
            strSQLUpdate += " , DIAGNOSE_VCHR = ? ";
            strSQLUpdate += " , ICD10DIAGID_VCHR = ? ";
            strSQLUpdate += " , ICD10DIAGTEXT_VCHR = ? ";
            strSQLUpdate += " , MODIFY_DAT = ? ";
            strSQLUpdate += "  WHERE REGISTERID_CHR = ?";
            //修改痕迹保留
            clsRecordMark_VO Markvo = new clsRecordMark_VO();
            clsRecordMark recordMark = new clsRecordMark();

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = objPatientVO.m_strCASEDOCTOR_CHR;
                objLisAddItemRefArr[1].Value = objPatientVO.m_strDIAGNOSEID_CHR;
                objLisAddItemRefArr[2].Value = objPatientVO.m_strDIAGNOSE_VCHR;
                objLisAddItemRefArr[3].Value = objPatientVO.m_strICD10DIAGID_VCHR;
                objLisAddItemRefArr[4].Value = objPatientVO.m_strICD10DIAGTEXT_VCHR;
                objLisAddItemRefArr[5].Value = Convert.ToDateTime(objPatientVO.m_strMODIFY_DAT);
                objLisAddItemRefArr[6].Value = objPatientVO.m_strREGISTERID_CHR;
                long lngRecEff = -1;
                //修改记录

                #region 修改痕迹保留
                string strSQLUpdate_Temp = "UPDATE  T_OPR_BIH_REGISTER SET ";
                strSQLUpdate_Temp += " CASEDOCTOR_CHR = '" + objPatientVO.m_strCASEDOCTOR_CHR + "'";
                strSQLUpdate_Temp += " , DIAGNOSEID_CHR = '" + objPatientVO.m_strDIAGNOSEID_CHR + "' ";
                strSQLUpdate_Temp += " , DIAGNOSE_VCHR = '" + objPatientVO.m_strDIAGNOSE_VCHR + "' ";
                strSQLUpdate_Temp += " , ICD10DIAGID_VCHR = '" + objPatientVO.m_strICD10DIAGID_VCHR + "' ";
                strSQLUpdate_Temp += " , ICD10DIAGTEXT_VCHR = '" + objPatientVO.m_strICD10DIAGTEXT_VCHR + "' ";
                strSQLUpdate_Temp += " , MODIFY_DAT = TO_DATE ('" + objPatientVO.m_strMODIFY_DAT + "', 'yyyy-mm-dd hh24:mi:ss') ";
                strSQLUpdate_Temp += "  WHERE REGISTERID_CHR = '" + objPatientVO.m_strREGISTERID_CHR + "'";
                Markvo.m_strOPERATORID_CHR = objPatientVO.m_strOPERATORID_CHR;
                Markvo.m_strTABLESEQID_CHR = "1";
                Markvo.m_strRECORDDETAIL_VCHR = strSQLUpdate_Temp;
                recordMark.m_mthAddNewRecord(Markvo);
                #endregion

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQLUpdate, ref lngRecEff, objLisAddItemRefArr);
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

        #region 按SQL——修改住院登记信息
        /// <summary>
        /// 按SQL——修改住院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSQLUpdate">Update的SQL语句</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihRegisterInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSQLUpdate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihRegisterInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.DoExcute(p_strSQLUpdate);
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
        #endregion
        #region 验证
        #region 验证住院号是否存在
        /// <summary>
        /// 验证住院号是否存在[有效]登记记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="IsRegisterd">是否登记 [out 参赛]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsRegisterdByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, out bool IsRegisterd)
        {
            IsRegisterd = false;
            string strRegisterid_chr = "";
            long lngReturn = m_lngGetRegisteridByInpatientID(p_objPrincipal, p_strInpatientid_chr, out strRegisterid_chr);
            if (lngReturn > 0 && strRegisterid_chr != string.Empty)
            {
                IsRegisterd = true;
            }
            return lngReturn;
        }
        #endregion
        #endregion
        #region 生成住院号
        /// <summary>
        /// 生成住院号 {原则上是4位年+2位月+2位日+4位数字 例如: 200409060000}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号 [out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 注意:
        ///		原则上是2位年+2位月+2位日+4位数字 
        ///		例如:0409060000
        ///		如果一天超过10000个入院则返回空.
        /// </remarks>
        [AutoComplete]
        public long m_lngGetInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strInpatientid_chr)
        {
            p_strInpatientid_chr = "";

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetInpatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            //查询最近的最大的住院号
            string strInpatientid_chr = "";
            string strSQL = @"
					SELECT count(*) as c,max(TO_NUMBER (t_opr_bih_register.inpatientid_chr)) +1 as Inpatientid_chr
					FROM t_opr_bih_register
					WHERE (status_int = 1 OR status_int = 2) and length(trim(inpatientid_chr)) = 8";


            /* @update by wjqin (05-11-24)
             * 添加SQL SERVER的strSQl版本语名
             */

            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                clsHRPTableService HRS = new clsHRPTableService();
                int newid = 0;
                long lngRes2 = HRS.m_lngGenerateNewID("t_opr_bih_register", "inpatientid_chr", out newid);
                if (lngRes2 > 0)
                {
                    strSQL = @"SELECT count(*) as c," + newid + @" as Inpatientid_chr
					FROM t_opr_bih_register
					WHERE (status_int = 1 OR status_int = 2) and len(Ltrim(Rtrim(inpatientid_chr))) = 8";
                }
            }
            /* <<======================================= */


            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && Convert.ToInt32(dtbResult.Rows[0]["c"].ToString()) > 0)
                {
                    strInpatientid_chr = dtbResult.Rows[0]["Inpatientid_chr"].ToString().PadLeft(8, '0');
                    strInpatientid_chr = strInpatientid_chr;
                }
                else
                {
                    strInpatientid_chr = "00000001";
                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            p_strInpatientid_chr = strInpatientid_chr;
            return lngRes;
        }
        /// <summary>
        /// 生成住院号末尾4位数字,失败返回空.
        /// </summary>
        /// <param name="strEnd4"></param>
        /// <returns></returns>
        [AutoComplete]
        public string GetEnd4ForInpatientID(string strEnd4)
        {
            int intTem = 0;
            intTem = Int32.Parse(strEnd4) + 1;
            if (intTem >= 10000)
            {
                return "";
            }
            string strTem = intTem.ToString().Trim();
            while (strTem.Length < 4)
            {
                strTem = "0" + strTem;
            }
            return strTem;
        }
        #endregion
        #region 验证住院号是否存在
        public bool IsExistInptientID(string InpatientID)
        {
            bool IsExist = false;
            string strSQL = "select Count(*) as c from t_opr_bih_register where Inpatientid_chr = '" + InpatientID + "'";
            try
            {
                long lngRes = 0;
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && Convert.ToInt32(dtbResult.Rows[0]["c"].ToString()) > 0)
                {
                    IsExist = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return IsExist;
        }
        #endregion

        #region	根据住院号获取病人列表	glzhang	2005.08.5
        /// <summary>
        /// 根据住院号获取病人列表	glzhang	2005.08.5
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFind">查询字符串</param>
        /// <param name="p_dtbResult">结果集</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInHosPatienList(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFind, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetInHosPatienList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT DISTINCT TRIM (t1.inpatientid_chr) AS inpatientid_chr,
                t2.lastname_vchr,t2.SEX_CHR,t2.BIRTHPLACE_VCHR
           FROM t_opr_bih_register t1, t_bse_patient t2
          WHERE t1.patientid_chr = t2.patientid_chr(+)
            AND t1.status_int = 1
            AND (   t1.inpatientid_chr LIKE '" + p_strFind + @"%'
                 OR t2.lastname_vchr LIKE '" + p_strFind + @"%'
                )
       ORDER BY TRIM (t1.inpatientid_chr), inpatientid_chr";


            /* @update by wjqin (05-11-24)
             * 添加SQL SERVER的strSQl版本语句
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT DISTINCT LTRIM(RTRIM (t1.inpatientid_chr)) AS inpatientid_chr,
                t2.lastname_vchr,,t2.SEX_CHR,t2.BIRTHPLACE_VCHR
           FROM t_opr_bih_register t1 LEFT JOIN t_bse_patient t2 ON t1.patientid_chr = t2.patientid_chr 
            WHERE t1.status_int = 1
            AND (   t1.inpatientid_chr LIKE  '" + p_strFind + @"%'
                 OR t2.lastname_vchr LIKE  '" + p_strFind + @"%'
                )
       ORDER BY LTRIM(RTRIM (t1.inpatientid_chr)) ";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        #region 撤消入院	glzhang	2005.08.30
        /// <summary>
        /// 撤消入院	glzhang	2005.08.30 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">住院登记ID</param>
        /// <param name="p_strPatitenID">病人ID</param>
        /// <param name="p_strInPatitenID">住院号</param>
        /// <param name="p_strInDate">入院日期</param>
        /// <param name="p_strIntStat">住院次数</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyCancelPatient(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, string p_strPatitenID, string p_strInPatitenID, string p_strInDate, int p_intStatus)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyCancelPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQLdelete = @"DELETE      t_opr_bih_register 
      WHERE registerid_chr = '" + p_strRegisterID + "'";

            string strSQLdelete2 = @"DELETE      t_opr_bih_transfer 
      WHERE REGISTERID_CHR =  '" + p_strRegisterID + "'";

            string strSQLdelete3 = @"DELETE      inpatientdateinfo 
      WHERE inpatientid = '" + p_strInPatitenID + @"'
        AND inpatientdate =
                       TO_DATE ('" + p_strInDate + "', 'yyyy-mm-dd hh24:mi:ss')";

            /* @update by wjqin (05-11-28)
                                     * 添加SQL SERVER的strSQl版本语名
                                     */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQLdelete3 = @"DELETE      inpatientdateinfo 
      WHERE inpatientid = '" + p_strInPatitenID + @"'
        AND CONVERT(DATETIME,inpatientdate) = CONVERT(DATETIME,'" + p_strInDate + "')";

            }
            /* <<======================================= */

            string strSQLdelete4 = @"DELETE      PatientBaseInfo 
      WHERE InPatientID = '" + p_strInPatitenID + "'";

            string strSQLUpdate = @"UPDATE t_bse_patient 
   SET inpatientid_chr = ''
 WHERE patientid_chr = '" + p_strPatitenID + "'";
            //用于判断是否是从门诊转入
            string strSQL = @"SELECT t1.registerid_chr
  FROM t_opr_bih_register t1
 WHERE t1.isfromclinic = 1 AND t1.registerid_chr = '" + p_strRegisterID + "'";
            //修改入院登记表
            string strUpRegSQL = @"UPDATE t_opr_bih_register t1
   SET t1.status_int = 2,
       t1.modify_dat = SYSDATE
 WHERE t1.registerid_chr = '" + p_strRegisterID + "'";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strUpRegSQL = @"UPDATE t_opr_bih_register t1
   SET t1.status_int = 2,
       t1.modify_dat = GETDATE()
 WHERE t1.registerid_chr = '" + p_strRegisterID + "'";
            }
            /* <<======================================= */

            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count == 1) //门诊转入病人
                {
                    //修改病人信息表住院号空
                    if (p_intStatus == 0)
                    {
                        lngRes = objHRPSvc.DoExcute(strSQLUpdate);
                    }
                    //修改入院登记表
                    lngRes = objHRPSvc.DoExcute(strUpRegSQL);
                    //删除调转表
                    lngRes = objHRPSvc.DoExcute(strSQLdelete2);
                }
                else //非门诊转入病人
                {
                    //删除记录
                    lngRes = objHRPSvc.DoExcute(strSQLdelete);
                    lngRes = objHRPSvc.DoExcute(strSQLdelete2);
                    lngRes = objHRPSvc.DoExcute(strSQLdelete3);
                    if (p_intStatus == 0)
                    {
                        lngRes = objHRPSvc.DoExcute(strSQLdelete4);
                        //修改病人信息表住院号空
                        lngRes = objHRPSvc.DoExcute(strSQLUpdate);
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

        #region 根据住院号获取病人基本信息和最近的住院信息 glzhang	2005.09.22
        /// <summary>
        /// 根据住院号获取病人基本信息和最近的住院信息 glzhang	2005.09.22
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientID">病人住院号</param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="p_objResult">病人住院信息</param>
        /// <returns></returns>
        public long m_lngFindPatientInfoByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientID, out clsPatient_VO objPatientVO, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            long lngRes = 0;
            string p_strRegisterid_chr = "";
            objPatientVO = new clsPatient_VO();
            clsPatient_VO[] p_objResultArr;
            clsPatientSvc m_patientSvc = new clsPatientSvc();
            lngRes = m_patientSvc.m_lngGetPatientInfoByInpatientID(p_objPrincipal, p_strInpatientID, out p_objResultArr);
            if (lngRes > 0 && p_objResultArr != null && p_objResultArr.Length > 0)
            {
                objPatientVO = p_objResultArr[0];
            }
            lngRes = m_lngGetRegisteridByInpatientID(p_objPrincipal, p_strInpatientID, out p_strRegisterid_chr);
            lngRes = m_lngGetBinRegisterByRegisterID(p_objPrincipal, p_strRegisterid_chr, out p_objResult);
            return lngRes;
        }
        #endregion

        #region 根据病人ID获取病人12小时内的门诊诊断 glzhang	2005.09.29
        /// <summary>
        /// 根据病人ID获取病人12小时内的门诊诊断 glzhang	2005.09.29
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strDiag">门诊诊断</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindDiagByPatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, out string p_strDiag)
        {
            p_strDiag = "";
            DataTable p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetInHosPatienList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   t1.casehisid_chr, t1.patientid_chr, t1.diag_vchr
    FROM t_opr_outpatientcasehis t1
   WHERE ROUND ((SYSDATE - modifydate_dat) * 24, 1) <= 12
     AND t1.patientid_chr = '" + p_strPatientID + @"'
ORDER BY t1.casehisid_chr DESC";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT   t1.casehisid_chr, t1.patientid_chr, t1.diag_vchr
    FROM t_opr_outpatientcasehis t1
  WHERE ROUND (datediff(day,modifydate_dat,getdate()) * 24, 1) <= 12
    AND t1.patientid_chr =  '" + p_strPatientID + @"'
ORDER BY t1.casehisid_chr DESC";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
                if (p_dtbResult.Rows.Count > 0)
                {
                    p_strDiag = p_dtbResult.Rows[0]["diag_vchr"].ToString();
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

        #region	获取门诊转入病人信息	glzhang	2005.10.10
        /// <summary>
        /// 获取门诊转入病人信息	glzhang	2005.10.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbResult">结果集</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTurnInPatienList(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetTurnInPatienList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   t2.patientid_chr, t1.registerid_chr, t6.patientcardid_chr,
         TRIM (t1.inpatientid_chr) AS inpatientid_chr, t1.areaid_chr,
         t3.deptname_vchr, t2.lastname_vchr AS patientname, t2.sex_chr,
         DECODE (t1.state_int, 1, '危', 2, '急', 3, '普通', '') state_int,
         t4.paytypename_vchr, t5.lastname_vchr AS doctername, t1.modify_dat
    FROM t_opr_bih_register t1,
         t_bse_patient t2,
         t_bse_deptdesc t3,
         t_bse_patientpaytype t4,
         t_bse_employee t5,
         t_bse_patientcard t6
   WHERE t1.status_int = 2
     AND t1.patientid_chr = t2.patientid_chr(+)
     AND t1.areaid_chr = t3.deptid_chr(+)
     AND t2.paytypeid_chr = t4.paytypeid_chr(+)
     AND t1.mzdoctor_chr = t5.empid_chr(+)
     AND t2.patientid_chr = t6.patientid_chr(+)
ORDER BY t1.areaid_chr, t1.modify_dat DESC";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT   t2.patientid_chr, t1.registerid_chr, t6.patientcardid_chr,
         LTRIM(RTRIM (t1.inpatientid_chr)) AS inpatientid_chr, t1.areaid_chr,
         t3.deptname_vchr, t2.lastname_vchr AS patientname, t2.sex_chr,
        -- DECODE (t1.state_int, 1, '危', 2, '急', 3, '普通', '') state_int,
         (CASE t1.state_int WHEN 1 THEN '危' WHEN 2 THEN '急' WHEN 3 THEN '普通' ELSE '' END) state_int,
         t4.paytypename_vchr, t5.lastname_vchr AS doctername, t1.modify_dat
    FROM t_opr_bih_register t1 
        left join t_bse_patient t2 on t1.patientid_chr = t2.patientid_chr
        left join  t_bse_deptdesc t3 on t1.areaid_chr = t3.deptid_chr 
        left join  t_bse_patientpaytype t4 on t2.paytypeid_chr = t4.paytypeid_chr 
        left join  t_bse_employee t5 on t1.mzdoctor_chr = t5.empid_chr
        left join t_bse_patientcard t6 on t2.patientid_chr = t6.patientid_chr
   WHERE t1.status_int = 2
ORDER BY t1.areaid_chr, t1.modify_dat DESC";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        #region 门诊转入病人入院	glzhang	200.10.10
        /// <summary>
        /// 门诊转入病人入院	glzhang	200.10.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPatientTurnIn(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, string p_strArearID, string p_strOperatorID, string p_strInPatientID)
        {
            long lngRes = 0;
            string p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngPatientTurnIn");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            lngRes = 0;
            lngRes = objHRPSvc.lngGenerateID(12, "transferid_chr", "t_opr_bih_transfer", out p_strRecordID);
            if (lngRes < 0)
            {
                return lngRes;
            }
            if (p_strInPatientID == "")
            {
                m_lngGetInpatientID(p_objPrincipal, out p_strInPatientID);
            }
            string strNow = System.DateTime.Now.ToString();
            //修改入院登记表
            string strSQL = @"UPDATE t_opr_bih_register t1
   SET t1.status_int = 1,t1.inpatientid_chr = '" + p_strInPatientID + @"',t1.isfromclinic = 1,
       t1.modify_dat =
                      TO_DATE ('" + strNow + @"', 'yyyy-mm-dd HH24:mi:ss')
 WHERE t1.registerid_chr = '" + p_strRegisterID + "'";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"UPDATE t_opr_bih_register 
   SET t_opr_bih_register.status_int = 1,t_opr_bih_register.inpatientid_chr = '" + p_strInPatientID + @"',t_opr_bih_register.isfromclinic = 1,
       t_opr_bih_register.modify_dat =
                      --TO_DATE ('" + strNow + @"', 'yyyy-mm-dd HH24:mi:ss')
                        CONVERT(DATETIME,'" + strNow + @"',20)
 WHERE t_opr_bih_register.registerid_chr = '" + p_strRegisterID + "'";
            }
            /* <<======================================= */
            //病人调转表增加记录
            string strSQL2 = @"INSERT INTO t_opr_bih_transfer
            (transferid_chr, targetareaid_chr, type_int, operatorid_chr,
             registerid_chr, modify_dat
            )
     VALUES ('" + p_strRecordID + @"', '" + p_strArearID + @"', 5, '" + p_strOperatorID + @"',
             '" + p_strRegisterID + @"', TO_DATE ('" + strNow + @"', 'yyyy-mm-dd HH24:mi:ss')
            )";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL2 = @"INSERT INTO t_opr_bih_transfer
            (transferid_chr, targetareaid_chr, type_int, operatorid_chr,
             registerid_chr, modify_dat
            )
     VALUES ('" + p_strRecordID + @"', '" + p_strArearID + @"', 5, '" + p_strOperatorID + @"',
             '" + p_strRegisterID + @"', CONVERT(DATETIME,'" + strNow + @"',20)
            )";

            }
            /* <<======================================= */
            //修改病人信息表住院号
            string strSQL3 = @"UPDATE t_bse_patient
   SET inpatientid_chr = '" + p_strInPatientID + @"'
 WHERE patientid_chr = (SELECT t1.patientid_chr
                          FROM t_opr_bih_register t1
                         WHERE t1.registerid_chr = '" + p_strRegisterID + "')";
            try
            {
                lngRes = objHRPSvc.DoExcute(strSQL);
                lngRes = objHRPSvc.DoExcute(strSQL2);
                lngRes = objHRPSvc.DoExcute(strSQL3);
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

        #region	根据病人ID获取病人是否有在院信息,供门诊入院登记卡使用	glzhang	2005.10.10
        /// <summary>
        /// 根据病人ID获取病人在院信息,供门诊入院登记卡使用	glzhang	2005.10.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_intFlag">标志:0=在院和门诊转入的病人信息,供门诊入院登记卡使用;1=在院和门诊转入的病人信息,入院时使用</param>
        /// <param name="p_dtbResult">结果集</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientInHospitalInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, int p_intFlag, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetPatientInHospitalInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT t1.registerid_chr
  FROM t_opr_bih_register t1
 WHERE t1.patientid_chr = '" + p_strPatientID + "'";
            if (p_intFlag == 0)
            {
                strSQL += " AND (t1.status_int = 2 OR t1.pstatus_int <> 3)";
            }
            if (p_intFlag == 1)
            {
                strSQL += " AND t1.status_int <> 2 AND t1.pstatus_int <> 3";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        #region 修改病人住院号 glzhag	glzhang 2006.01.20
        /// <summary>
        /// 修改病人住院号 glzhag	glzhang 2006.01.20
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOldInPatientID">旧住院号</param>
        /// <param name="p_strNewInPatientID">新住院号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyInPatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOldInPatientID, string p_strNewInPatientID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyInPatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQLUpdate1 = @"UPDATE t_bse_patient t1
   SET t1.inpatientid_chr = '" + p_strNewInPatientID + @"'
 WHERE t1.inpatientid_chr = '" + p_strOldInPatientID + "'";

            string strSQLUpdate2 = @"UPDATE t_opr_bih_register t1
   SET t1.inpatientid_chr = '" + p_strNewInPatientID + @"'
 WHERE t1.inpatientid_chr = '" + p_strOldInPatientID + "'";

            string strSQLUpdate3 = @"UPDATE indeptinfo t1
   SET t1.inpatientid = '" + p_strNewInPatientID + @"'
 WHERE t1.inpatientid = '" + p_strOldInPatientID + "'";

            string strSQLUpdate4 = @"UPDATE inpatientdateinfo t1
   SET t1.inpatientid = '" + p_strNewInPatientID + @"'
 WHERE t1.inpatientid = '" + p_strOldInPatientID + "'";

            string strSQLUpdate5 = @"UPDATE patientbaseinfo t1
   SET t1.inpatientid = '" + p_strNewInPatientID + @"'
 WHERE t1.inpatientid ='" + p_strOldInPatientID + "'";

            try
            {
                //修改病人信息表住院号空
                lngRes = objHRPSvc.DoExcute(strSQLUpdate1);
                lngRes = objHRPSvc.DoExcute(strSQLUpdate2);
                lngRes = objHRPSvc.DoExcute(strSQLUpdate3);
                lngRes = objHRPSvc.DoExcute(strSQLUpdate4);
                lngRes = objHRPSvc.DoExcute(strSQLUpdate5);
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

        #region	获取预交金余额	glzhang	2005.03.06
        /// <summary>
        /// 获取预交金余额	glzhang	2005.03.06
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegsterID">入院登记ID</param>
        /// <param name="p_dtbResult">结果集</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepayMoney(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegsterID, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetTurnInPatienList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT SUM (t1.money_dec) sum_money
  FROM t_opr_bih_prepay t1
 WHERE t1.registerid_chr = '" + p_strRegsterID + @"'
   AND t1.status_int = 1
   AND t1.isclear_int = 0";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        //T_Opr_Bih_Leave(出院记录)
        #region 增加
        /// <summary>
        /// 出院---增加出院记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">流水号[200409010001]</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewBihLeave(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsT_Opr_Bih_Leave_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewBihLeave");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            lngRes = objHRPSvc.lngGenerateID(12, "leaveid_chr", "T_Opr_Bih_Leave", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_Opr_Bih_Leave (LEAVEID_CHR,REGISTERID_CHR,TYPE_INT,OUTDEPTID_CHR,DES_VCHR,OUTAREAID_CHR,STATUS_INT,MODIFY_DAT,OUTBEDID_CHR,OPERATORID_CHR,PSTATUS_INT) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(11, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTYPE_INT;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOUTDEPTID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strDES_VCHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strOUTAREAID_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[7].Value = DateTime.Parse(strDateTime);
                objLisAddItemRefArr[8].Value = p_objRecord.m_strOUTBEDID_CHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[10].Value = p_objRecord.m_intPSTATUS_INT;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
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
        #region 查找
        /// <summary>
        /// 查询所有的出院记录［有效的］
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllBihLeaveInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
        {
            //{status_int 状态：-1历史、0无效、1有效}	
            return m_lngGetBihLeaveInfo(p_objPrincipal, " status_int = '1' ", out p_objResultArr);
        }
        /// <summary>
        /// 根据入院登记流水号查询有效的出院登记记录 {原则上只有一个有效的记录}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBinLeaveByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
        {
            string strQueryCondition = " status_int = '1' AND ";
            strQueryCondition += " registerid_chr = '" + p_strRegisterid_chr.Trim() + "'";
            return m_lngGetBihLeaveInfo(p_objPrincipal, strQueryCondition, out p_objResultArr);
        }
        /// <summary>
        /// 按条件——出院记录查询
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition">查询条件</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihLeaveInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBihLeaveInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "";
            strSQL += " SELECT a.*";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outdeptid_chr) OutDeptName ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outareaid_chr) OutAreaName ";
            strSQL += "     ,(select code_chr from t_bse_bed where bedid_chr=a.outbedid_chr) OutBedNo ";
            strSQL += "     ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.operatorid_chr)) OPERATORNAME ";
            strSQL += "     ,a.TYPE_INT TypeName ";
            strSQL += "     ,decode(a.PSTATUS_INT,0,'预出院',1,'实际出院','') PStatusName ";
            strSQL += " FROM t_opr_bih_leave a";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT a.*
		     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outdeptid_chr) OutDeptName 
		   ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outareaid_chr) OutAreaName 
		,(select code_chr from t_bse_bed where bedid_chr=a.outbedid_chr) OutBedNo 
		  ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE LTRIM(RTRIM(empid_chr)) =Ltrim(RTRIM(a.operatorid_chr))) OPERATORNAME 
		 ,a.TYPE_INT TypeName 
		-- ,decode(a.PSTATUS_INT,0,'预出院',1,'实际出院','') PStatusName 
                ,(CASE  a.PSTATUS_INT WHEN 0 THEN '预出院' WHEN 1 THEN '实际出院' ELSE '' END) PStatusName 
		FROM t_opr_bih_leave a";
            }
            /* <<======================================= */
            //病人调转表增加记录


            if (p_strQueryCondition != string.Empty)
            {
                strSQL += " WHERE " + p_strQueryCondition;
            }
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Leave_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Leave_VO();
                        p_objResultArr[i1].m_strLEAVEID_CHR = dtbResult.Rows[i1]["LEAVEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strTYPE_INT = dtbResult.Rows[i1]["TYPE_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strOUTDEPTID_CHR = dtbResult.Rows[i1]["OUTDEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strOUTAREAID_CHR = dtbResult.Rows[i1]["OUTAREAID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strOUTBEDID_CHR = dtbResult.Rows[i1]["OUTBEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Int32.Parse(dtbResult.Rows[i1]["STATUS_INT"].ToString());
                        p_objResultArr[i1].m_intPSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
                        //非字段
                        p_objResultArr[i1].m_strOutDeptName = dtbResult.Rows[i1]["OutDeptName"].ToString().Trim();
                        p_objResultArr[i1].m_strOutAreaName = dtbResult.Rows[i1]["OutAreaName"].ToString().Trim();
                        p_objResultArr[i1].m_strOutBedNo = dtbResult.Rows[i1]["OutBedNo"].ToString().Trim();
                        p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OperatorName"].ToString().Trim();
                        p_objResultArr[i1].m_strPStatusName = dtbResult.Rows[i1]["PStatusName"].ToString().Trim();

                    }
                }
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
        #region 修改 | 删除
        #region  修改记录状态｛-1历史、0无效、1有效｝	根据入院登记流水号
        /// <summary>
        /// 修改出院的记录状态｛-1历史、0无效、1有效｝
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_intStatus_int">状态｛-1历史、0无效、1有效｝</param>
        /// <param name="p_strOPERATORID_CHR">操作人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihLeaveByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, int p_intStatus_int, string p_strOPERATORID_CHR)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihLeaveByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Leave SET ";
            strSQLUpdate += " Status_int =" + p_intStatus_int.ToString();
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
            strSQLUpdate += " ,MODIFY_DAT = SYSDATE ";
            strSQLUpdate += " WHERE registerid_chr = '" + p_strRegisterid_chr.Trim() + "'";

            return m_lngModifyBihLeaveInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region  修改记录状态｛-1历史、0无效、1有效｝	根据出院流水号
        /// <summary>
        /// 修改出院的记录状态｛-1历史、0无效、1有效｝	根据流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">出院流水号</param>
        /// <param name="p_intStatus_int">状态｛-1历史、0无效、1有效｝</param>
        /// <param name="p_strOPERATORID_CHR">操作人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihLeaveSTATUS_INTByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, int p_intStatus_int, string p_strOPERATORID_CHR)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihLeaveSTATUS_INTByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Leave SET ";
            strSQLUpdate += " Status_int =" + p_intStatus_int.ToString();
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
            strSQLUpdate += " ,MODIFY_DAT = SYSDATE ";
            strSQLUpdate += " WHERE LEAVEID_CHR = '" + p_strID.Trim() + "'";
            /* @update by wjqin (05-11-28)
                                     * 添加SQL SERVER的strSQl版本语名
                                     */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQLUpdate = "UPDATE  T_Opr_Bih_Leave SET ";
                strSQLUpdate += " Status_int =" + p_intStatus_int.ToString();
                strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
                strSQLUpdate += " ,MODIFY_DAT = GETDATE() ";
                strSQLUpdate += " WHERE LEAVEID_CHR = '" + p_strID.Trim() + "'";
            }
            /* <<======================================= */
            return m_lngModifyBihLeaveInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region  修改出院状态{0=预出院;1=实际出院}	根据出院流水号
        /// <summary>
        /// 修改出院的记录状态｛-1历史、0无效、1有效｝	根据流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">出院流水号</param>
        /// <param name="p_intPSTATUS_INT">状态｛-1历史、0无效、1有效｝</param>
        /// <param name="p_strOPERATORID_CHR">操作人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihLeavePSTATUS_INTByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, int p_intPSTATUS_INT, string p_strOPERATORID_CHR)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihLeavePSTATUS_INTByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "UPDATE  T_Opr_Bih_Leave SET ";
            strSQLUpdate += " PSTATUS_INT =" + p_intPSTATUS_INT.ToString();
            strSQLUpdate += " ,OPERATORID_CHR ='" + p_strOPERATORID_CHR.Trim() + "' ";
            strSQLUpdate += " ,MODIFY_DAT = SYSDATE ";
            strSQLUpdate += " WHERE LEAVEID_CHR = '" + p_strID.Trim() + "'";

            return m_lngModifyBihLeaveInfo(p_objPrincipal, strSQLUpdate);
        }
        #endregion
        #region 按SQL——修改出院登记信息
        /// <summary>
        /// 按SQL——修改出院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSQLUpdate">Update的SQL语句</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyBihLeaveInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSQLUpdate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyBihLeaveInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.DoExcute(p_strSQLUpdate);
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
        #endregion
        #region 验证某入院流水号是否存在[有效]出院记录
        /// <summary>
        /// 验证某入院流水号是否存在[有效]出院记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="IsLeaveHospital">是否出院 [out 参赛]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsLeaveHospitalByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, out bool IsLeaveHospital)
        {
            IsLeaveHospital = false;
            clsT_Opr_Bih_Leave_VO[] p_objResultArr;
            long lngReturn = m_lngGetBinLeaveByRegisterID(p_objPrincipal, p_strRegisterid_chr, out p_objResultArr);
            if (lngReturn > 0 && p_objResultArr != null && p_objResultArr.Length > 0 && p_objResultArr[0].m_strREGISTERID_CHR != null)
            {
                IsLeaveHospital = true;
            }
            return lngReturn;
        }
        #endregion

        //综合 
        #region 获取住院号的最近一次住院的状态 [首次入院、在院、已出院]
        /// <summary>
        /// 获取住院号的最近一次住院的状态 [首次入院、在院、已出院] 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="p_intBihState">住院状态 {1-首次入院、2-在院、3-已出院} [ out 参数 ]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihState(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, out int p_intBihState)
        {
            p_intBihState = 0;
            string strRegisterid_chr = "";
            long lngReturn = m_lngGetRegisteridByInpatientID(p_objPrincipal, p_strInpatientid_chr, out strRegisterid_chr);
            if (lngReturn <= 0)
            {
                return lngReturn;	//执行错误
            }
            if (strRegisterid_chr == "")
            {
                p_intBihState = 1;	//1-首次入院
                return lngReturn;
            }

            lngReturn = m_lngGetBihStateByRegisterID(p_objPrincipal, strRegisterid_chr, out p_intBihState);
            return lngReturn;
        }
        #endregion
        #region 获取住院流水号的住院状态 [首次入院、在院、已出院]
        /// <summary>
        /// 获取住院流水号的住院状态 [首次入院、在院、已出院] 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">住院流水号</param>
        /// <param name="p_intBihState">住院状态 {1-首次入院、2-在院、3-已出院} [ out 参数 ]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihStateByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, out int p_intBihState)
        {
            p_intBihState = 0;
            bool IsLeaveHospital = false;
            if (p_strRegisterid_chr == string.Empty)
            {
                p_intBihState = 1;	//1-首次入院
                return 1;
            }
            long lngReturn = m_lngCheckIsLeaveHospitalByRegisterID(p_objPrincipal, p_strRegisterid_chr, out IsLeaveHospital);
            if (lngReturn <= 0)
            {
                return lngReturn;	//执行错误
            }
            if (IsLeaveHospital)
            {
                p_intBihState = 3;	//3-已出院
                return lngReturn;
            }
            else
            {
                p_intBihState = 2;	//2-在院
                return lngReturn;
            }
        }
        #endregion
        #region 获取某住院号的所有[有效的]出院纪录
        /// <summary>
        /// 获取某住院号的所有[有效的]出院纪录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihLeaveByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBihLeaveByInpatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.* ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outdeptid_chr) OutDeptName ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outareaid_chr) OutAreaName ";
            strSQL += "     ,(select code_chr from t_bse_bed where bedid_chr=a.outbedid_chr) OutBedNo ";
            strSQL += "     ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.operatorid_chr)) OPERATORNAME ";
            strSQL += "     ,a.TYPE_INT TypeName ";
            strSQL += "     ,decode(a.PSTATUS_INT,0,'预出院',1,'实际出院','') PStatusName ";
            strSQL += " FROM t_opr_bih_leave a ,t_opr_bih_register b ";
            strSQL += " WHERE a.STATUS_INT=1 AND a.registerid_chr=b.registerid_chr AND b.inpatientid_chr='" + p_strInpatientid_chr.Trim() + "'";
            strSQL += " Order By a.modify_dat";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT a.*  ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outdeptid_chr) OutDeptName 
			 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outareaid_chr) OutAreaName 
			  ,(select code_chr from t_bse_bed where bedid_chr=a.outbedid_chr) OutBedNo 
		    --,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.operatorid_chr)) OPERATORNAME 
                   ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE Ltrim(RTRIM(empid_chr)) =Ltrim(RTRIM(a.operatorid_chr))) OPERATORNAME 
		   ,a.TYPE_INT TypeName
		   -- ,decode(a.PSTATUS_INT,0,'预出院',1,'实际出院','') PStatusName 
                 ,(CASE a.PSTATUS_INT WHEN 0 THEN '预出院'WHEN 1 THEN '实际出院' ELSE '' END ) PStatusName 
		 FROM t_opr_bih_leave a ,t_opr_bih_register b 
		 WHERE a.STATUS_INT=1 AND a.registerid_chr=b.registerid_chr AND b.inpatientid_chr='" + p_strInpatientid_chr.Trim() + @"' Order By a.modify_dat";
            }
            /* <<======================================= */
            //病人调转表增加记录
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Leave_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Leave_VO();
                        p_objResultArr[i1].m_strLEAVEID_CHR = dtbResult.Rows[i1]["LEAVEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strTYPE_INT = dtbResult.Rows[i1]["TYPE_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strOUTDEPTID_CHR = dtbResult.Rows[i1]["OUTDEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strOUTAREAID_CHR = dtbResult.Rows[i1]["OUTAREAID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strOUTBEDID_CHR = dtbResult.Rows[i1]["OUTBEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        //非字段
                        p_objResultArr[i1].m_strOutDeptName = dtbResult.Rows[i1]["OutDeptName"].ToString().Trim();
                        p_objResultArr[i1].m_strOutAreaName = dtbResult.Rows[i1]["OutAreaName"].ToString().Trim();
                        p_objResultArr[i1].m_strOutBedNo = dtbResult.Rows[i1]["OutBedNo"].ToString().Trim();
                        p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OperatorName"].ToString().Trim();
                        p_objResultArr[i1].m_strPStatusName = dtbResult.Rows[i1]["PStatusName"].ToString().Trim();
                    }
                }
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
        #region 获取某住院号的所有调转纪录
        /// <summary>
        /// 获取某住院号的所有调转纪录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInpatientid_chr">住院号</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihTransferByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInpatientid_chr, string p_strFilter, out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBihTransferByInpatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "";
            strSQL += " SELECT ";
            strSQL += "     a.REGISTERID_CHR ";
            strSQL += "     ,a.TRANSFERID_CHR ";
            strSQL += "     ,a.SOURCEDEPTID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEDEPTID_CHR)SOURCEDEPTNAME ";
            strSQL += "     ,a.SOURCEAREAID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEAREAID_CHR)SOURCEAREANAME ";
            strSQL += "     ,a.SOURCEBEDID_CHR ";
            strSQL += "     ,(select code_chr from t_bse_bed where bedid_chr=a.sourcebedid_chr) SourceBedNo ";
            strSQL += "     ,a.TARGETDEPTID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETDEPTID_CHR)TARGETDEPTNAME ";
            strSQL += "     ,TARGETAREAID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETAREAID_CHR)TARGETAREANAME ";
            strSQL += "     ,a.TARGETBEDID_CHR ";
            strSQL += "     ,(select code_chr from t_bse_bed where bedid_chr=a.targetbedid_chr) TargetBedNo ";
            strSQL += "     ,a.TYPE_INT ";
            strSQL += "     ,DECODE(a.TYPE_INT,1,'转科',2,'调床',3,'专科+调床',4,'出院召回',5,'入院',6,'出院','') TypeName ";
            strSQL += "     ,a.DES_VCHR ";
            strSQL += "     ,a.OPERATORID_CHR ";
            strSQL += "     ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.OPERATORID_CHR))OPERATORNAME ";
            strSQL += "     ,a.MODIFY_DAT ";
            strSQL += " FROM t_opr_bih_transfer a,t_opr_bih_register b  ";
            strSQL += " WHERE a.registerid_chr=b.registerid_chr AND b.inpatientid_chr='" + p_strInpatientid_chr.Trim() + "'" + p_strFilter;
            strSQL += " Order By b.INPATIENTCOUNT_INT,a.MODIFY_DAT";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT  a.REGISTERID_CHR 
		 ,a.TRANSFERID_CHR 
		  ,a.SOURCEDEPTID_CHR 
		 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEDEPTID_CHR)SOURCEDEPTNAME 
		 ,a.SOURCEAREAID_CHR 
	 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEAREAID_CHR)SOURCEAREANAME 
		 ,a.SOURCEBEDID_CHR 
		  ,(select code_chr from t_bse_bed where bedid_chr=a.sourcebedid_chr) SourceBedNo 
		  ,a.TARGETDEPTID_CHR 
		 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETDEPTID_CHR)TARGETDEPTNAME 
		,TARGETAREAID_CHR 
	 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETAREAID_CHR)TARGETAREANAME 
		 ,a.TARGETBEDID_CHR 
		 ,(select code_chr from t_bse_bed where bedid_chr=a.targetbedid_chr) TargetBedNo 
	 ,a.TYPE_INT 
	--,DECODE(a.TYPE_INT,1,'转科',2,'调床',3,'专科+调床',4,'出院召回',5,'入院',6,'出院','') TypeName 
          ,(CASE a.TYPE_INT WHEN 1 THEN '转科' WHEN 2 THEN '调床' WHEN 3 THEN '专科+调床' WHEN 4 THEN '出院召回' WHEN 5 THEN '入院' WHEN 6 THEN '出院' ELSE '' END) TypeName 
	 ,a.DES_VCHR 
	 ,a.OPERATORID_CHR 
	,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE Ltrim(RTRIM(empid_chr)) =Ltrim(RTRIM(a.OPERATORID_CHR))) OPERATORNAME 
	,a.MODIFY_DAT 
	 FROM t_opr_bih_transfer a,t_opr_bih_register b  
	 WHERE a.registerid_chr=b.registerid_chr AND b.inpatientid_chr='" + p_strInpatientid_chr.Trim() + "'" + p_strFilter + @"
	 Order By b.INPATIENTCOUNT_INT,a.MODIFY_DAT ";
            }
            /* <<======================================= */
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Transfer_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Transfer_VO();
                        //流水号
                        p_objResultArr[i1].m_strTRANSFERID_CHR = dtbResult.Rows[i1]["TRANSFERID_CHR"].ToString().Trim();
                        //源科室id
                        p_objResultArr[i1].m_strSOURCEDEPTID_CHR = dtbResult.Rows[i1]["SOURCEDEPTID_CHR"].ToString().Trim();
                        //源科室名称
                        if (dtbResult.Rows[i1]["SOURCEDEPTNAME"] != null)
                        {
                            p_objResultArr[i1].m_strSourceDeptName = dtbResult.Rows[i1]["SOURCEDEPTNAME"].ToString().Trim();
                        }
                        //源病区id
                        p_objResultArr[i1].m_strSOURCEAREAID_CHR = dtbResult.Rows[i1]["SOURCEAREAID_CHR"].ToString().Trim();
                        //源病区名称
                        if (dtbResult.Rows[i1]["SOURCEAREANAME"] != null)
                        {
                            p_objResultArr[i1].m_strSourceAreaName = dtbResult.Rows[i1]["SOURCEAREANAME"].ToString().Trim();
                        }
                        //源病床id
                        p_objResultArr[i1].m_strSOURCEBEDID_CHR = dtbResult.Rows[i1]["SOURCEBEDID_CHR"].ToString().Trim();
                        //源床号 [非字段]
                        if (dtbResult.Rows[i1]["SourceBedNo"] != null)
                        {
                            p_objResultArr[i1].m_strSourceBedNo = dtbResult.Rows[i1]["SourceBedNo"].ToString().Trim();
                        }
                        //目标科室id
                        p_objResultArr[i1].m_strTARGETDEPTID_CHR = dtbResult.Rows[i1]["TARGETDEPTID_CHR"].ToString().Trim();
                        //目标科室名称
                        if (dtbResult.Rows[i1]["TARGETDEPTNAME"] != null)
                        {
                            p_objResultArr[i1].m_strTargetDeptName = dtbResult.Rows[i1]["TARGETDEPTNAME"].ToString().Trim();
                        }
                        //目标病区id
                        p_objResultArr[i1].m_strTARGETAREAID_CHR = dtbResult.Rows[i1]["TARGETAREAID_CHR"].ToString().Trim();
                        //目标床号 [非字段]
                        p_objResultArr[i1].m_strTargetBedNo = dtbResult.Rows[i1]["TargetBedNo"].ToString().Trim();
                        //目标病区名称
                        if (dtbResult.Rows[i1]["TARGETAREANAME"] != null)
                        {
                            p_objResultArr[i1].m_strTargetAreaName = dtbResult.Rows[i1]["TARGETAREANAME"].ToString().Trim();
                        }
                        //目标病床id
                        p_objResultArr[i1].m_strTARGETBEDID_CHR = dtbResult.Rows[i1]["TARGETBEDID_CHR"].ToString().Trim();
                        //目标床号 [非字段]
                        if (dtbResult.Rows[i1]["TargetBedNo"] != null)
                        {
                            p_objResultArr[i1].m_strTargetBedNo = dtbResult.Rows[i1]["TargetBedNo"].ToString().Trim();
                        }
                        //操作类型操作类型{1=转科;2=调床;3=转科+调床;4=出院唤回;5=入院;6=出院}
                        p_objResultArr[i1].m_intTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["TYPE_INT"].ToString());
                        //操作类型名称
                        if (dtbResult.Rows[i1]["TypeName"] != null)
                        {
                            p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        }
                        //备注
                        p_objResultArr[i1].m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        //操作人ID
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        ///操作人名称
                        if (dtbResult.Rows[i1]["OPERATORNAME"] != null)
                        {
                            p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OPERATORNAME"].ToString().Trim();
                        }
                        //入院登记流水号(200409010001)
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        //修改日期，操作日期
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                }
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
        #region 统计某科室某病区的可转入的病人信息
        /// <summary>
        /// 统计某科室某病区的可转入的病人信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">部门科室ID</param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult">[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMayGetInPatientByAreaID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, string p_strAreaID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngMayGetInPatientByAreaID");
            if (lngRes < 0)
            {
                return -1;
            }

            //{因为转出时入院登记记录也要变，所以只要查询入院登记表中的记录就行}
            //科室为空 ＋　本科室的病区为空或本病区的无病床的纪录
            string strSQL = @"SELECT t1.*, t2.sex_chr
  FROM t_opr_bih_register t1, t_bse_patient t2
 WHERE t1.status_int = 1
   AND t1.patientid_chr = t2.patientid_chr(+)
   AND t1.pstatus_int = 0
   AND t1.areaid_chr = '" + p_strAreaID + "'";


            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT t1.*, t2.sex_chr
  FROM t_opr_bih_register t1 left join  t_bse_patient t2 on t1.patientid_chr = t2.patientid_chr
 WHERE t1.status_int = 1
   
   AND t1.pstatus_int = 0
   AND t1.areaid_chr = '" + p_strAreaID + "'";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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
        #region 根据入院登记流水号获取住院信息和病人基本信息
        /// <summary>
        /// 根据入院登记流水号获取住院信息和病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInfoByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngGetInfoByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            strSQL += " select a.*,b.* ";
            strSQL += "		,TO_CHAR(SYSDATE,'YYYY')-TO_CHAR(b.birth_dat,'YYYY') As Age";
            strSQL += "		,(select deptname_vchr from t_bse_deptdesc a1 where a1.deptid_chr=a.areaid_chr) AreaName";
            strSQL += "		,(select code_chr from t_bse_bed a2 where a2.areaid_chr=a.areaid_chr and a2.bedid_chr=a.bedid_chr) BedCode";
            strSQL += "		,(select modify_dat from t_opr_bih_leave a3 where a3.registerid_chr=a.registerid_chr and a3.status_int=1) LeaveHospitalTime";
            strSQL += "		,(select sum(money_dec) from t_opr_bih_prepay a4 where a4.registerid_chr=a.registerid_chr and a4.status_int=1 and a4.isclear_int=0) PrePayMoney";
            strSQL += "		,(SELECT chearact_dat FROM (SELECT chearact_dat FROM t_opr_bih_paymoney WHERE t_opr_bih_paymoney.registerid_chr='" + p_strRegisterID.Trim() + "' ORDER BY chearact_dat desc) WHERE rownum=1) chearact_dat";//清账日期
            strSQL += " from t_opr_bih_register a,t_bse_patient b";
            strSQL += " where a.patientid_chr=b.patientid_chr";
            strSQL += "     and a.registerid_chr='" + p_strRegisterID.Trim() + "'";

            /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @" select a.*,b.*,
              CONVERT(VARCHAR(4),DATEDIFF(YEAR,b.birth_dat,GETDATE())) As Age
			,(select top 1 deptname_vchr from t_bse_deptdesc a1 where a1.deptid_chr=a.areaid_chr) AreaName
		,(select top 1 code_chr from t_bse_bed a2 where a2.areaid_chr=a.areaid_chr and a2.bedid_chr=a.bedid_chr) BedCode
		,(select top 1 modify_dat from t_opr_bih_leave a3 where a3.registerid_chr=a.registerid_chr and a3.status_int=1) LeaveHospitalTime
		,(select sum(money_dec) from t_opr_bih_prepay a4 where a4.registerid_chr=a.registerid_chr and a4.status_int=1 and a4.isclear_int=0) PrePayMoney
		,(SELECT top  1 chearact_dat from t_opr_bih_paymoney WHERE t_opr_bih_paymoney.registerid_chr='" + p_strRegisterID.Trim() + @"'  ORDER BY chearact_dat desc) chearact_dat
		
         from t_opr_bih_register a,t_bse_patient b
		 where a.patientid_chr=b.patientid_chr
	    and a.registerid_chr='" + p_strRegisterID.Trim() + "'";
            }
            /* <<======================================= */


            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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



        //T_Opr_Bih_Transfer(住院调转记录)
        #region 增加
        /// <summary>
        /// 增加住院调转记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">住院调转流水号 [out 参数]</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewBinTransfer(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewBinTransfer");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            lngRes = objHRPSvc.lngGenerateID(12, "transferid_chr", "t_opr_bih_transfer", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;

            string strDateTime = p_objRecord.m_strMODIFY_DAT;
            //			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //入院登记
            DataTable dtbResult = null;
            lngRes = 0;
            lngRes = new com.digitalwave.iCare.middletier.HIS.clsBedManageSvc().m_lngGetPatientLastestTransferInfo(null, p_objRecord.m_strREGISTERID_CHR, out dtbResult);
            string DeleteTurnOutRecord = "";
            string TransferID = "";
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                if (dtbResult.Rows[0]["SOURCEAREAID_CHR"] != System.DBNull.Value && dtbResult.Rows[0]["TARGETAREAID_CHR"] != System.DBNull.Value && dtbResult.Rows[0]["TARGETBEDID_CHR"] == System.DBNull.Value)
                {
                    TransferID = dtbResult.Rows[0]["TRANSFERID_CHR"].ToString();
                    DeleteTurnOutRecord = "delete from T_OPR_BIH_TRANSFER where TRANSFERID_CHR = '" + dtbResult.Rows[0]["TRANSFERID_CHR"].ToString() + "'";
                }
            }

            string strSQL = "INSERT INTO t_opr_bih_transfer (TRANSFERID_CHR,SOURCEDEPTID_CHR,SOURCEAREAID_CHR,SOURCEBEDID_CHR,TARGETDEPTID_CHR,TARGETAREAID_CHR,TARGETBEDID_CHR,TYPE_INT,DES_VCHR,OPERATORID_CHR,REGISTERID_CHR,MODIFY_DAT) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";

            //入院分配床位
            if (p_objRecord.m_intTYPE_INT == 5 && p_objRecord.m_strTARGETBEDID_CHR != "")
            {
                strSQL = "UPDATE t_opr_bih_transfer SET DES_VCHR = '" + p_objRecord.m_strDES_VCHR + "',TYPE_INT = 5,MODIFY_DAT = TO_DATE('" + strDateTime + "','YYYY-MM-DD hh24:mi:ss'),TARGETBEDID_CHR = '" + p_objRecord.m_strTARGETBEDID_CHR + "' WHERE REGISTERID_CHR = '" + p_objRecord.m_strREGISTERID_CHR + "' AND TYPE_INT = 5 AND TARGETBEDID_CHR IS NULL";
                /* @create by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语句
             */
                if (clsHRPTableService.bytDatabase_Selector == 0)
                {
                    strSQL = @" UPDATE t_opr_bih_transfer SET DES_VCHR = '" + p_objRecord.m_strDES_VCHR + "',OPERATORID_CHR = '" + p_objRecord.m_strOPERATORID_CHR + "',TYPE_INT = 5,MODIFY_DAT = CONVERT(DATETIME,'" + strDateTime + "',20),TARGETBEDID_CHR = '" + p_objRecord.m_strTARGETBEDID_CHR + "' WHERE REGISTERID_CHR = '" + p_objRecord.m_strREGISTERID_CHR + "' AND TYPE_INT = 5 AND TARGETBEDID_CHR IS NULL";
                }
                /* <<======================================= */
                try
                {
                    lngRes = 0;
                    lngRes = objHRPSvc.DoExcute(strSQL);
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                //				#region 病区日志统计
                //lngRes=0;
                //				lngRes = new clsBihStatQuerySvc().m_lngUpdateSickRoomLOGSTAT(p_objRecord);
                //				#endregion
            }
            //出院召回
            else if (p_objRecord.m_intTYPE_INT == 4)
            {
                strSQL = @"UPDATE t_opr_bih_transfer SET DES_VCHR = '" + p_objRecord.m_strDES_VCHR + "',OPERATORID_CHR = '" + p_objRecord.m_strOPERATORID_CHR + "',TYPE_INT = 4,MODIFY_DAT = TO_DATE('" + strDateTime + @"','YYYY-MM-DD hh24:mi:ss'),TARGETBEDID_CHR = '' WHERE TRANSFERID_CHR = (select a.TRANSFERID_CHR from t_opr_bih_transfer a ,(
                           SELECT   MAX (t_opr_bih_transfer.modify_dat) AS modify_dat,
                           t_opr_bih_transfer.registerid_chr
                           FROM t_opr_bih_transfer
                           GROUP BY t_opr_bih_transfer.registerid_chr) b
                           where a.modify_dat = b.modify_dat and a.registerid_chr = b.registerid_chr
                           and b.registerid_chr = '" + p_objRecord.m_strREGISTERID_CHR + "')";
                try
                {
                    lngRes = 0;
                    lngRes = objHRPSvc.DoExcute(strSQL);
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                //				#region 病区日志统计
                //lngRes=0;
                //				lngRes = new clsBihStatQuerySvc().m_lngUpdateSickRoomLOGSTAT(p_objRecord);
                //				#endregion
            }
            else
            {
                strSQL = "INSERT INTO t_opr_bih_transfer (TRANSFERID_CHR,SOURCEDEPTID_CHR,SOURCEAREAID_CHR,SOURCEBEDID_CHR,TARGETDEPTID_CHR,TARGETAREAID_CHR,TARGETBEDID_CHR,TYPE_INT,DES_VCHR,OPERATORID_CHR,REGISTERID_CHR,MODIFY_DAT) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                try
                {
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(12, out objLisAddItemRefArr);
                    //Please change the datetime and reocrdid 
                    objLisAddItemRefArr[0].Value = p_strRecordID;
                    objLisAddItemRefArr[1].Value = p_objRecord.m_strSOURCEDEPTID_CHR;
                    objLisAddItemRefArr[2].Value = p_objRecord.m_strSOURCEAREAID_CHR;
                    objLisAddItemRefArr[3].Value = p_objRecord.m_strSOURCEBEDID_CHR;
                    objLisAddItemRefArr[4].Value = p_objRecord.m_strTARGETDEPTID_CHR;
                    objLisAddItemRefArr[5].Value = p_objRecord.m_strTARGETAREAID_CHR;
                    objLisAddItemRefArr[6].Value = p_objRecord.m_strTARGETBEDID_CHR;
                    objLisAddItemRefArr[7].Value = p_objRecord.m_intTYPE_INT;
                    objLisAddItemRefArr[8].Value = p_objRecord.m_strDES_VCHR;
                    objLisAddItemRefArr[9].Value = p_objRecord.m_strOPERATORID_CHR;
                    objLisAddItemRefArr[10].Value = p_objRecord.m_strREGISTERID_CHR;
                    objLisAddItemRefArr[11].Value = DateTime.Parse(strDateTime);
                    long lngRecEff = -1;
                    //往表增加记录
                    if (DeleteTurnOutRecord != "")
                    {
                        lngRes = 0;
                        lngRes = objHRPSvc.DoExcute(DeleteTurnOutRecord);
                        objLisAddItemRefArr[0].Value = TransferID;
                    }
                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                //				#region 病区日志统计
                //lngRes=0;
                //				lngRes = new clsBihStatQuerySvc().m_lngUpdateSickRoomLOGSTAT(p_objRecord);
                //				#endregion
            }
            return lngRes;
        }
        #endregion
        #region 查找
        /// <summary>
        /// 根据入院登记流水号查询转床记录 {包括了ＩＤ到Ｎａｍｅ的转换}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBinTransferByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, string p_strFilter, out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngGetBinTransferByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "";
            strSQL += " SELECT ";
            strSQL += "     a.REGISTERID_CHR ";
            strSQL += "     ,a.TRANSFERID_CHR ";
            strSQL += "     ,a.SOURCEDEPTID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEDEPTID_CHR)SOURCEDEPTNAME ";
            strSQL += "     ,a.SOURCEAREAID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEAREAID_CHR)SOURCEAREANAME ";
            strSQL += "     ,a.SOURCEBEDID_CHR ";
            strSQL += "     ,(select code_chr from t_bse_bed where bedid_chr=a.sourcebedid_chr) SourceBedNo ";
            strSQL += "     ,a.TARGETDEPTID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETDEPTID_CHR)TARGETDEPTNAME ";
            strSQL += "     ,TARGETAREAID_CHR ";
            strSQL += "     ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETAREAID_CHR)TARGETAREANAME ";
            strSQL += "     ,a.TARGETBEDID_CHR ";
            strSQL += "     ,(select code_chr from t_bse_bed where bedid_chr=a.targetbedid_chr) TargetBedNo ";
            strSQL += "     ,a.TYPE_INT ";
            strSQL += "     ,DECODE(a.TYPE_INT,1,'转科',2,'调床',3,'转区',4,'出院召回',5,'入院',6,'出院','') TypeName ";
            strSQL += "     ,a.DES_VCHR ";
            strSQL += "     ,a.OPERATORID_CHR ";
            strSQL += "     ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.OPERATORID_CHR))OPERATORNAME ";
            strSQL += "     ,a.MODIFY_DAT ";
            strSQL += " FROM t_opr_bih_transfer a";
            strSQL += " WHERE a.registerid_chr = '" + p_strRegisterid_chr.Trim() + "' " + p_strFilter;
            strSQL += " Order by a.MODIFY_DAT ";
            /* @create by wjqin (05-11-25)
                         * 添加SQL SERVER的strSQl版本语句
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT  a.REGISTERID_CHR  ,a.TRANSFERID_CHR 
 ,a.SOURCEDEPTID_CHR 
  ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEDEPTID_CHR)SOURCEDEPTNAME 
 ,a.SOURCEAREAID_CHR 
 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.SOURCEAREAID_CHR)SOURCEAREANAME 
 ,a.SOURCEBEDID_CHR 
 ,(select code_chr from t_bse_bed where bedid_chr=a.sourcebedid_chr) SourceBedNo 
 ,a.TARGETDEPTID_CHR 
 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETDEPTID_CHR)TARGETDEPTNAME 
  ,TARGETAREAID_CHR 
 ,(select deptname_vchr from t_bse_deptdesc where deptid_chr=a.TARGETAREAID_CHR)TARGETAREANAME 
  ,a.TARGETBEDID_CHR 
,(select code_chr from t_bse_bed where bedid_chr=a.targetbedid_chr) TargetBedNo 
 ,a.TYPE_INT 
 --,DECODE(a.TYPE_INT,1,'转科',2,'调床',3,'转区',4,'出院召回',5,'入院',6,'出院','') TypeName 
,(CASE a.TYPE_INT WHEN 1 THEN '转科' WHEN 2 THEN '调床' WHEN 3 THEN '转区' WHEN 4 THEN '出院召回' WHEN 5 THEN '入院' WHEN 6 THEN '出院' ELSE '' END ) TypeName 
 ,a.DES_VCHR 
,a.OPERATORID_CHR 
 ,(select LastName_vchr FROM T_BSE_EMPLOYEE WHERE Ltrim(RTRIM(empid_chr)) =Ltrim(RTRIM(a.OPERATORID_CHR)))OPERATORNAME 
 ,a.MODIFY_DAT 
 FROM t_opr_bih_transfer a
 WHERE 
 a.registerid_chr = '" + p_strRegisterid_chr.Trim() + "' " + p_strFilter;
                strSQL += @" Order by a.MODIFY_DAT ";
            }
            /* <<======================================= */
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Transfer_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Transfer_VO();
                        //流水号
                        p_objResultArr[i1].m_strTRANSFERID_CHR = dtbResult.Rows[i1]["TRANSFERID_CHR"].ToString().Trim();
                        //源科室id
                        p_objResultArr[i1].m_strSOURCEDEPTID_CHR = dtbResult.Rows[i1]["SOURCEDEPTID_CHR"].ToString().Trim();
                        //源科室名称
                        if (dtbResult.Rows[i1]["SOURCEDEPTNAME"] != null)
                        {
                            p_objResultArr[i1].m_strSourceDeptName = dtbResult.Rows[i1]["SOURCEDEPTNAME"].ToString().Trim();
                        }
                        //源病区id
                        p_objResultArr[i1].m_strSOURCEAREAID_CHR = dtbResult.Rows[i1]["SOURCEAREAID_CHR"].ToString().Trim();
                        //源病区名称
                        if (dtbResult.Rows[i1]["SOURCEAREANAME"] != null)
                        {
                            p_objResultArr[i1].m_strSourceAreaName = dtbResult.Rows[i1]["SOURCEAREANAME"].ToString().Trim();
                        }
                        //源病床id
                        p_objResultArr[i1].m_strSOURCEBEDID_CHR = dtbResult.Rows[i1]["SOURCEBEDID_CHR"].ToString().Trim();
                        //源床号 [非字段]
                        if (dtbResult.Rows[i1]["SourceBedNo"] != null)
                        {
                            p_objResultArr[i1].m_strSourceBedNo = dtbResult.Rows[i1]["SourceBedNo"].ToString().Trim();
                        }
                        //目标科室id
                        p_objResultArr[i1].m_strTARGETDEPTID_CHR = dtbResult.Rows[i1]["TARGETDEPTID_CHR"].ToString().Trim();
                        //目标科室名称
                        if (dtbResult.Rows[i1]["TARGETDEPTNAME"] != null)
                        {
                            p_objResultArr[i1].m_strTargetDeptName = dtbResult.Rows[i1]["TARGETDEPTNAME"].ToString().Trim();
                        }
                        //目标病区id
                        p_objResultArr[i1].m_strTARGETAREAID_CHR = dtbResult.Rows[i1]["TARGETAREAID_CHR"].ToString().Trim();
                        //目标病区名称
                        if (dtbResult.Rows[i1]["TARGETAREANAME"] != null)
                        {
                            p_objResultArr[i1].m_strTargetAreaName = dtbResult.Rows[i1]["TARGETAREANAME"].ToString().Trim();
                        }
                        //目标病床id
                        p_objResultArr[i1].m_strTARGETBEDID_CHR = dtbResult.Rows[i1]["TARGETBEDID_CHR"].ToString().Trim();
                        //目标床号 [非字段]
                        if (dtbResult.Rows[i1]["TargetBedNo"] != null)
                        {
                            p_objResultArr[i1].m_strTargetBedNo = dtbResult.Rows[i1]["TargetBedNo"].ToString().Trim();
                        }
                        //操作类型{1=转科;2=调床;3=转科+调床;4=出院唤回;5=入院;6=出院}
                        p_objResultArr[i1].m_intTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["TYPE_INT"].ToString());
                        //操作类型名称
                        if (dtbResult.Rows[i1]["TypeName"] != null)
                        {
                            p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        }
                        //备注
                        p_objResultArr[i1].m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        //操作人ID
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        ///操作人名称
                        if (dtbResult.Rows[i1]["OPERATORNAME"] != null)
                        {
                            p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OPERATORNAME"].ToString().Trim();
                        }
                        //入院登记流水号(200409010001)
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        //修改日期，操作日期
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                }
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
        /// 根据转床流水号查询对应记录的信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strTransferID">转床流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBinTransferByTransferID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strTransferID, out clsT_Opr_Bih_Transfer_VO p_objResult)
        {
            p_objResult = new clsT_Opr_Bih_Transfer_VO();

            clsT_Opr_Bih_Transfer_VO[] p_objResultArr;
            string strQueryCondition = " transferid_chr = '" + p_strTransferID.Trim() + "'";
            long lngReturn = m_lngGetBihTransferInfo(p_objPrincipal, strQueryCondition, out p_objResultArr);
            if (lngReturn > 0 && p_objResultArr.Length > 0)
                p_objResult = p_objResultArr[0];
            return lngReturn;
        }
        /// <summary>
        /// 按条件——转床查询
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition">查询条件</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBihTransferInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBihTransferInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            //查询条件：  确保查询SQL可以执行。	  	 
            if (p_strQueryCondition.Trim() == "") p_strQueryCondition = " 1=1 ";
            string strSQL = @"SELECT * FROM t_opr_bih_transfer WHERE " + p_strQueryCondition;
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Transfer_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Transfer_VO();
                        p_objResultArr[i1].m_strTRANSFERID_CHR = dtbResult.Rows[i1]["TRANSFERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSOURCEDEPTID_CHR = dtbResult.Rows[i1]["SOURCEDEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSOURCEAREAID_CHR = dtbResult.Rows[i1]["SOURCEAREAID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSOURCEBEDID_CHR = dtbResult.Rows[i1]["SOURCEBEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strTARGETDEPTID_CHR = dtbResult.Rows[i1]["TARGETDEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strTARGETAREAID_CHR = dtbResult.Rows[i1]["TARGETAREAID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strTARGETBEDID_CHR = dtbResult.Rows[i1]["TARGETBEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intTYPE_INT = Convert.ToInt32(dtbResult.Rows[i1]["TYPE_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                }
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
        #region 根据住院登记ID查找调转纪录
        [AutoComplete]
        public long m_lngGetTransferInfoByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO p_objResult)
        {
            p_objResult = new com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGet");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.* from t_opr_bih_transfer a ,(
                              SELECT   MAX (t_opr_bih_transfer.modify_dat) AS modify_dat,
                              t_opr_bih_transfer.registerid_chr
                              FROM t_opr_bih_transfer
                              GROUP BY t_opr_bih_transfer.registerid_chr) b
                              where a.modify_dat = b.modify_dat and a.registerid_chr = b.registerid_chr
                              and b.registerid_chr = '" + p_strRegisterID + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO();
                    p_objResult.m_strTRANSFERID_CHR = dtbResult.Rows[0]["TRANSFERID_CHR"].ToString().Trim();
                    p_objResult.m_strSOURCEDEPTID_CHR = dtbResult.Rows[0]["SOURCEDEPTID_CHR"].ToString().Trim();
                    p_objResult.m_strSOURCEAREAID_CHR = dtbResult.Rows[0]["SOURCEAREAID_CHR"].ToString().Trim();
                    p_objResult.m_strSOURCEBEDID_CHR = dtbResult.Rows[0]["SOURCEBEDID_CHR"].ToString().Trim();
                    p_objResult.m_strTARGETDEPTID_CHR = dtbResult.Rows[0]["TARGETDEPTID_CHR"].ToString().Trim();
                    p_objResult.m_strTARGETAREAID_CHR = dtbResult.Rows[0]["TARGETAREAID_CHR"].ToString().Trim();
                    p_objResult.m_strTARGETBEDID_CHR = dtbResult.Rows[0]["TARGETBEDID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["TYPE_INT"] != System.DBNull.Value)
                    {
                        p_objResult.m_intTYPE_INT = Convert.ToInt32(dtbResult.Rows[0]["TYPE_INT"].ToString().Trim());
                    }
                    p_objResult.m_strDES_VCHR = dtbResult.Rows[0]["DES_VCHR"].ToString().Trim();
                    p_objResult.m_strOPERATORID_CHR = dtbResult.Rows[0]["OPERATORID_CHR"].ToString().Trim();
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["MODIFY_DAT"] != System.DBNull.Value)
                    {
                        p_objResult.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                }
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

        #region 病人住院流动记录	glzhang		2005.09.14
        /// <summary>
        /// 病人住院流动记录	glzhang		2005.09.14
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">id</param>
        /// <param name="p_strFilter">查询字符串</param>
        /// <param name="p_objResultArr">结果集</param>
        /// <param name="p_intFlag">操作标志:0=本次住院记录,历次住院记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBinTransferByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, string p_strFilter, out clsT_Opr_Bih_Transfer_VO[] p_objResultArr, int p_intFlag)
        {
            p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngGetBinTransferByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT   a.registerid_chr, a.transferid_chr, a.sourcedeptid_chr,
         s_dep.deptname_vchr sourcedeptname, a.sourceareaid_chr,
         s_area.deptname_vchr sourceareaname, a.sourcebedid_chr,
         s_bed.code_chr sourcebedno, a.targetdeptid_chr,
         t_dep.deptname_vchr targetdeptname, a.targetareaid_chr,
         t_area.deptname_vchr targetareaname, a.targetbedid_chr,
         g_bed.code_chr targetbedno, a.type_int, d.flgname_vchr AS typename,
         a.des_vchr, a.operatorid_chr, c.lastname_vchr operatorname,
         CASE
            WHEN a.type_int = 5
               THEN b.inpatient_dat
            ELSE a.modify_dat
         END AS modify_dat,
         b.inpatientcount_int
    FROM t_opr_bih_transfer a,
         t_opr_bih_register b,
         t_bse_employee c,
         t_sys_flg_table d,
         t_bse_deptdesc s_dep,
         t_bse_deptdesc s_area,
         t_bse_deptdesc t_dep,
         t_bse_deptdesc t_area,
         t_bse_bed s_bed,
         t_bse_bed g_bed
   WHERE a.registerid_chr = b.registerid_chr(+)
     AND a.operatorid_chr = c.empid_chr
     AND a.sourcedeptid_chr = s_dep.deptid_chr(+)
     AND a.sourceareaid_chr = s_area.deptid_chr(+)
     AND a.sourcebedid_chr = s_bed.bedid_chr(+)
     AND a.targetdeptid_chr = t_dep.deptid_chr(+)
     AND a.targetareaid_chr = t_area.deptid_chr(+)
     AND a.targetbedid_chr = g_bed.bedid_chr(+)
     AND a.type_int = d.flg_int
     AND d.tablename_vchr = 't_opr_bih_transfer'
     AND d.columnseq_int = 7
     " + p_strFilter;
            if (p_intFlag == 0)
            {
                strSQL += "     AND a.registerid_chr = '" + p_strRegisterid_chr + "'";
            }
            else
            {
                strSQL += "     AND b.inpatientid_chr = '" + p_strRegisterid_chr + "'";
            }
            strSQL += " ORDER BY b.inpatientcount_int, modify_dat";


            /* @create by wjqin (05-11-25)
                         * 添加SQL SERVER的strSQl版本语句
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT   a.registerid_chr, a.transferid_chr, a.sourcedeptid_chr,
         s_dep.deptname_vchr sourcedeptname, a.sourceareaid_chr,
         s_area.deptname_vchr sourceareaname, a.sourcebedid_chr,
         s_bed.code_chr sourcebedno, a.targetdeptid_chr,
         t_dep.deptname_vchr targetdeptname, a.targetareaid_chr,
         t_area.deptname_vchr targetareaname, a.targetbedid_chr,
         g_bed.code_chr targetbedno, a.type_int,
        ( CASE a.type_int WHEN 1 THEN '转科' WHEN 2 THEN '调床' WHEN 3 THEN '转区' WHEN 4 THEN  '出院召回' WHEN 5 THEN  '入院' WHEN 6 THEN  '出院' ELSE  '' END) typename,
         a.des_vchr, a.operatorid_chr, c.lastname_vchr operatorname,
         CASE
            WHEN a.type_int = 5
               THEN b.inpatient_dat
            ELSE a.modify_dat
         END AS modify_dat,
         b.inpatientcount_int
    FROM t_opr_bih_transfer a left join t_opr_bih_register b on a.registerid_chr = b.registerid_chr 
         full join  t_bse_employee c on a.operatorid_chr = c.empid_chr
         left join  t_bse_deptdesc s_dep on a.sourcedeptid_chr = s_dep.deptid_chr
         left join  t_bse_deptdesc s_area on  a.sourceareaid_chr = s_area.deptid_chr
         left join  t_bse_deptdesc t_dep on a.targetdeptid_chr = t_dep.deptid_chr
         left join  t_bse_deptdesc t_area on a.targetareaid_chr = t_area.deptid_chr
         left join  t_bse_bed      s_bed  on a.sourcebedid_chr = s_bed.bedid_chr
         left join  t_bse_bed      g_bed  on a.targetbedid_chr = g_bed.bedid_chr ";
                strSQL += p_strFilter;
                if (p_intFlag == 0)
                {
                    strSQL += "     AND a.registerid_chr = '" + p_strRegisterid_chr + "'";
                }
                else
                {
                    strSQL += "     AND b.inpatientid_chr = '" + p_strRegisterid_chr + "'";
                }
                strSQL += " ORDER BY b.inpatientcount_int, modify_dat";

            }
            /* <<======================================= */
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Opr_Bih_Transfer_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Opr_Bih_Transfer_VO();
                        //流水号
                        p_objResultArr[i1].m_strTRANSFERID_CHR = dtbResult.Rows[i1]["TRANSFERID_CHR"].ToString().Trim();
                        //源科室id
                        p_objResultArr[i1].m_strSOURCEDEPTID_CHR = dtbResult.Rows[i1]["SOURCEDEPTID_CHR"].ToString().Trim();
                        //源科室名称
                        if (dtbResult.Rows[i1]["SOURCEDEPTNAME"] != null)
                        {
                            p_objResultArr[i1].m_strSourceDeptName = dtbResult.Rows[i1]["SOURCEDEPTNAME"].ToString().Trim();
                        }
                        //源病区id
                        p_objResultArr[i1].m_strSOURCEAREAID_CHR = dtbResult.Rows[i1]["SOURCEAREAID_CHR"].ToString().Trim();
                        //源病区名称
                        if (dtbResult.Rows[i1]["SOURCEAREANAME"] != null)
                        {
                            p_objResultArr[i1].m_strSourceAreaName = dtbResult.Rows[i1]["SOURCEAREANAME"].ToString().Trim();
                        }
                        //源病床id
                        p_objResultArr[i1].m_strSOURCEBEDID_CHR = dtbResult.Rows[i1]["SOURCEBEDID_CHR"].ToString().Trim();
                        //源床号 [非字段]
                        if (dtbResult.Rows[i1]["SourceBedNo"] != null)
                        {
                            p_objResultArr[i1].m_strSourceBedNo = dtbResult.Rows[i1]["SourceBedNo"].ToString().Trim();
                        }
                        //目标科室id
                        p_objResultArr[i1].m_strTARGETDEPTID_CHR = dtbResult.Rows[i1]["TARGETDEPTID_CHR"].ToString().Trim();
                        //目标科室名称
                        if (dtbResult.Rows[i1]["TARGETDEPTNAME"] != null)
                        {
                            p_objResultArr[i1].m_strTargetDeptName = dtbResult.Rows[i1]["TARGETDEPTNAME"].ToString().Trim();
                        }
                        //目标病区id
                        p_objResultArr[i1].m_strTARGETAREAID_CHR = dtbResult.Rows[i1]["TARGETAREAID_CHR"].ToString().Trim();
                        //目标病区名称
                        if (dtbResult.Rows[i1]["TARGETAREANAME"] != null)
                        {
                            p_objResultArr[i1].m_strTargetAreaName = dtbResult.Rows[i1]["TARGETAREANAME"].ToString().Trim();
                        }
                        //目标病床id
                        p_objResultArr[i1].m_strTARGETBEDID_CHR = dtbResult.Rows[i1]["TARGETBEDID_CHR"].ToString().Trim();
                        //目标床号 [非字段]
                        if (dtbResult.Rows[i1]["TargetBedNo"] != null)
                        {
                            p_objResultArr[i1].m_strTargetBedNo = dtbResult.Rows[i1]["TargetBedNo"].ToString().Trim();
                        }
                        //操作类型{1=转科;2=调床;3=转科+调床;4=出院唤回;5=入院;6=出院}
                        p_objResultArr[i1].m_intTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["TYPE_INT"].ToString());
                        //操作类型名称
                        if (dtbResult.Rows[i1]["TypeName"] != null)
                        {
                            p_objResultArr[i1].m_strTypeName = dtbResult.Rows[i1]["TypeName"].ToString().Trim();
                        }
                        //备注
                        p_objResultArr[i1].m_strDES_VCHR = dtbResult.Rows[i1]["DES_VCHR"].ToString().Trim();
                        //操作人ID
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        ///操作人名称
                        if (dtbResult.Rows[i1]["OPERATORNAME"] != null)
                        {
                            p_objResultArr[i1].m_strOperatorName = dtbResult.Rows[i1]["OPERATORNAME"].ToString().Trim();
                        }
                        //入院登记流水号(200409010001)
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        //修改日期，操作日期
                        p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        //入院次数
                        p_objResultArr[i1].m_strINPATIENTCOUNT_INT = dtbResult.Rows[i1]["inpatientcount_int"].ToString().Trim();
                    }
                }
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

        //病人基本信息
        #region 增加
        #region 增加病人基本资料
        /// <summary>
        /// 增加病人基本资料
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">流水号</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewPatient(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsPatient_VO p_objRecord)
        {
            long lngRes = 0;
            clsPatientSvc objSvc = new clsPatientSvc();
            lngRes = objSvc.m_lngAddNewPatient(p_objPrincipal, out p_strRecordID, p_objRecord);
            return lngRes;
        }
        #endregion

        #region 增加病人基本资料索引表
        /// <summary>
        /// 增加病人基本资料索引表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">流水号</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewPatientIdx(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsclsPatientIdxVO p_objRecord)
        {
            long lngRes = 0;
            clsPatientSvc objSvc = new clsPatientSvc();
            lngRes = objSvc.m_lngAddNewPatientIndexInfo(p_objPrincipal, out p_strRecordID, p_objRecord);
            return lngRes;
        }
        #endregion
        #endregion
        #region 修改
        #region  修改病人基本信息
        /// <summary>
        /// 修改病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyPatient(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"UPDATE t_bse_patient
   SET lastname_vchr = ?,
       idcard_chr = ?,
       married_chr = ?,
       birthplace_vchr = ?,
       homeaddress_vchr = ?,
       sex_chr = ?,
       nationality_vchr = ?,
       firstname_vchr = ?,
       birth_dat = ?,
       race_vchr = ?,
       nativeplace_vchr = ?,
       occupation_vchr = ?,
       name_vchr = ?,
       homephone_vchr = ?,
       officephone_vchr = ?,
       insuranceid_vchr = ?,
       mobile_chr = ?,
       inpatientid_chr = ?,
       officeaddress_vchr = ?,
       employer_vchr = ?,
       officepc_vchr = ?,
       homepc_chr = ?,
       email_vchr = ?,
       contactpersonfirstname_vchr = ?,
       contactpersonlastname_vchr = ?,
       contactpersonaddress_vchr = ?,
       contactpersonphone_vchr = ?,
       contactpersonpc_chr = ?,
       patientrelation_vchr = ?,
       firstdate_dat = ?,
       isemployee_int = ?,
       status_int = ?,
       operatorid_chr = ?,
       modify_dat = ?,
       paytypeid_chr = ?,
       govcard_chr = ?,
       bloodtype_chr = ?,
       ifallergic_int = ?,
       allergicdesc_vchr = ?,
       inpatienttempid_vchr = ?,
       consigneeaddr = ? 
 WHERE patientid_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(42, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strLASTNAME_VCHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strIDCARD_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strMARRIED_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strBIRTHPLACE_VCHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strHOMEADDRESS_VCHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strSEX_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strNATIONALITY_VCHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strFIRSTNAME_VCHR;
                objLisAddItemRefArr[8].Value = Convert.ToDateTime(p_objRecord.m_strBIRTH_DAT);
                objLisAddItemRefArr[9].Value = p_objRecord.m_strRACE_VCHR;
                objLisAddItemRefArr[10].Value = p_objRecord.m_strNATIVEPLACE_VCHR;
                objLisAddItemRefArr[11].Value = p_objRecord.m_strOCCUPATION_VCHR;
                objLisAddItemRefArr[12].Value = p_objRecord.m_strNAME_VCHR;
                objLisAddItemRefArr[13].Value = p_objRecord.m_strHOMEPHONE_VCHR;
                objLisAddItemRefArr[14].Value = p_objRecord.m_strOFFICEPHONE_VCHR;
                objLisAddItemRefArr[15].Value = p_objRecord.m_strINSURANCEID_VCHR;
                objLisAddItemRefArr[16].Value = p_objRecord.m_strMOBILE_CHR;
                objLisAddItemRefArr[17].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[18].Value = p_objRecord.m_strOFFICEADDRESS_VCHR;
                objLisAddItemRefArr[19].Value = p_objRecord.m_strEMPLOYER_VCHR;
                objLisAddItemRefArr[20].Value = p_objRecord.m_strOFFICEPC_VCHR;
                objLisAddItemRefArr[21].Value = p_objRecord.m_strHOMEPC_CHR;
                objLisAddItemRefArr[22].Value = p_objRecord.m_strEMAIL_VCHR;
                objLisAddItemRefArr[23].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR;
                objLisAddItemRefArr[24].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR;// p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCONTACTPERSONADDRESS_VCHR;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strCONTACTPERSONPHONE_VCHR;
                objLisAddItemRefArr[27].Value = p_objRecord.m_strCONTACTPERSONPC_CHR;
                objLisAddItemRefArr[28].Value = p_objRecord.m_strPATIENTRELATION_VCHR;
                objLisAddItemRefArr[29].Value = Convert.ToDateTime(p_objRecord.m_strFIRSTDATE_DAT);
                objLisAddItemRefArr[30].Value = p_objRecord.m_intISEMPLOYEE_INT;
                objLisAddItemRefArr[31].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[32].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[33].Value = Convert.ToDateTime(p_objRecord.m_strMODIFY_DAT);
                objLisAddItemRefArr[34].Value = p_objRecord.m_strPAYTYPEID_CHR;
                objLisAddItemRefArr[35].Value = p_objRecord.m_strGOVCARD_CHR;
                objLisAddItemRefArr[36].Value = p_objRecord.m_strBLOODTYPE_CHR;
                objLisAddItemRefArr[37].Value = p_objRecord.m_intIFALLERGIC_INT;
                objLisAddItemRefArr[38].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[39].Value = p_objRecord.m_strINPATIENTTEMPID_VCHR;
                objLisAddItemRefArr[40].Value = p_objRecord.ConsigneeAddr;
                objLisAddItemRefArr[41].Value = p_objRecord.m_strPATIENTID_CHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region  修改病人基本资料索引表
        /// <summary>
        /// 修改病人基本资料索引表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyPatientIdx(System.Security.Principal.IPrincipal p_objPrincipal, clsclsPatientIdxVO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyPatientIdx");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"UPDATE t_bse_patientidx
   SET inpatientid_chr = ?,
       idcard_chr = ?,
       homeaddress_vchr = ?,
       sex_chr = ?,
       birth_dat = ?,
       name_vchr = ?,
       homephone_vchr = ?,
       insuranceid_vchr = ?
 WHERE patientid_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(9, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strIDCARD_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strHOMEADDRESS_VCHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strSEX_CHR;
                objLisAddItemRefArr[4].Value = Convert.ToDateTime(p_objRecord.m_strBIRTH_DAT);
                objLisAddItemRefArr[5].Value = p_objRecord.m_strNAME_VCHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strHOMEPHONE_VCHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strINSURANCEID_VCHR;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strPATIENTID_CHR;

                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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
        #region 获取职员名称
        /// <summary>
        /// 获取职员名称	根据流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_strName">职工名称	[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmployeeNameByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, out string p_strName)
        {
            p_strName = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngGetEmployeeNameByID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) ='" + p_strID.Trim() + "'";

            /* @create by wjqin (05-11-25)
                         * 添加SQL SERVER的strSQl版本语句
                         */
            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = "select LastName_vchr FROM T_BSE_EMPLOYEE WHERE Ltrim(Rtrim(empid_chr)) ='" + p_strID.Trim() + "'";

            }
            /* <<======================================= */

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_strName = dtbResult.Rows[0][0].ToString();
                }
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

        //下面是事务逻辑，采用事务实现。
        #region 入院登记
        /// <summary>
        /// 入院登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="intBihState">住院状态[1、首次入院；、2在院；、3、再次入院；]</param>
        /// <param name="objPatientVO">clsPatient_VO 参数</param>
        /// <param name="objBIHVO">clsT_Opr_Bih_Register_VO 参数</param>
        /// <returns></returns>
        /// <remarks>
        /// 注意：
        /// 
        ///	基本信息新增——病人编号不存在		（病人编号由系统生成）
        ///	基本信息修改——病人编号存在	
        ///		
        ///	首次入院——入院登记流水 （登记表没有记录				）
        ///	在院	——入院登记流水 （登记表有记录	  出院表没有记录）
        ///	再次入院——入院登记流水 （登记表有记录	  出院表有记录  ） 即为当前状态为出院状态。
        ///	
        ///	1、基本信息 (新增)		住院信息 (首次入院)		（住院号由系统生成）	
        ///	2、基本信息 (修改)		住院信息 (首次入院)
        ///	3、基本信息 (修改)		住院信息 (在院)
        ///	4、基本信息 (修改)		住院信息 (再次入院)
        /// </remarks>
        [AutoComplete]
        public long m_lngRegisterHospital(System.Security.Principal.IPrincipal p_objPrincipal, int intBihState, clsPatient_VO objPatientVO, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {

            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngRegisterHospital");
            if (lngReg < 0)
            {
                return -1;
            }

            clsclsPatientIdxVO objIndexVo = new clsclsPatientIdxVO();
            clsT_Opr_Bih_Transfer_VO objTransferVO = new clsT_Opr_Bih_Transfer_VO();
            clsBedManageSvc obj = new clsBedManageSvc();
            string strTem = "";
            //确定基本信息状态
            if (intBihState == 1 && (objPatientVO.m_strPATIENTID_CHR == null || objPatientVO.m_strPATIENTID_CHR == string.Empty))
            {
                #region 基本信息 (新增)
                //{1、生成新的住院号；2、获得索引Vo[clsclsPatientIdxVO][住院号赋值]；3、增加基本信息索引；4、增加基本信息[住院号、病人编号赋值]；5、增加住院登记信息；6、占床；7、增加调转信息；}
                //1、生成新的住院号；				
                lngReg = m_lngGetInpatientID(p_objPrincipal, out strTem);
                if (objPatientVO.m_strINPATIENTID_CHR != "")
                    strTem = objPatientVO.m_strINPATIENTID_CHR;

                //2、获得索引Vo[clsclsPatientIdxVO][住院号赋值]；
                if (lngReg > 0)
                {
                    BaseVoToIndexVo(objPatientVO, out objIndexVo);
                    objIndexVo.m_strINPATIENTID_CHR = strTem;
                }

                //3、增加基本信息索引； 
                if (lngReg > 0)
                {
                    strTem = "";
                    lngReg = m_lngAddNewPatientIdx(p_objPrincipal, out strTem, objIndexVo);
                }

                //4、增加基本信息[住院号、病人编号赋值]；
                if (lngReg > 0)
                {
                    objPatientVO.m_strPATIENTID_CHR = strTem;
                    objPatientVO.m_strINPATIENTID_CHR = objIndexVo.m_strINPATIENTID_CHR;
                    lngReg = m_lngAddNewPatient(p_objPrincipal, out strTem, objPatientVO);
                }

                //5、增加住院登记信息；
                if (lngReg > 0)
                {
                    objBIHVO.m_strPATIENTID_CHR = objPatientVO.m_strPATIENTID_CHR;
                    objBIHVO.m_strINPATIENTID_CHR = objIndexVo.m_strINPATIENTID_CHR;
                    objBIHVO.m_intINPATIENTCOUNT_INT += 1;
                    lngReg = m_lngAddNewBihRegister(p_objPrincipal, out strTem, objBIHVO);
                    objBIHVO.m_strREGISTERID_CHR = strTem;
                }

                //6、占床；
                if (lngReg > 0)
                {
                    if (objBIHVO.m_strBEDID_CHR != null && objBIHVO.m_strBEDID_CHR != string.Empty)
                    {
                        lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objBIHVO.m_strBEDID_CHR, 2);
                    }
                }

                //7、增加调转信息；
                FillTransfer_VO(objBIHVO, out objTransferVO);
                if (lngReg > 0)
                {
                    lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strTem, objTransferVO);
                }
                #endregion
            }
            else
            {
                #region 基本信息 (修改)
                switch (intBihState)
                {
                    case 1:
                        #region 首次入院；
                        //{1、生成新的住院号；2、获得索引Vo[clsclsPatientIdxVO][住院号赋值]；3、修改基本信息索引；4、修改基本信息[住院号赋值]；5、增加住院登记信息[住院号赋值]；6、占床；7、增加调转信息；}
                        //1、生成新的住院号；
                        lngReg = m_lngGetInpatientID(p_objPrincipal, out strTem);

                        //2、获得索引Vo[clsclsPatientIdxVO][住院号赋值]；
                        if (objPatientVO.m_strINPATIENTID_CHR != "")
                            strTem = objPatientVO.m_strINPATIENTID_CHR;
                        if (lngReg > 0)
                        {
                            BaseVoToIndexVo(objPatientVO, out objIndexVo);
                            objIndexVo.m_strINPATIENTID_CHR = strTem;
                        }

                        //3、修改基本信息索引；
                        if (lngReg > 0)
                        {
                            lngReg = m_lngModifyPatientIdx(p_objPrincipal, objIndexVo);
                        }

                        //4、修改基本信息[住院号赋值]；
                        if (lngReg > 0)
                        {
                            objPatientVO.m_strINPATIENTID_CHR = objIndexVo.m_strINPATIENTID_CHR;
                            lngReg = m_lngModifyPatient(p_objPrincipal, objPatientVO);
                        }

                        //5、增加住院登记信息[住院号赋值]；
                        if (lngReg > 0)
                        {
                            objBIHVO.m_strPATIENTID_CHR = objPatientVO.m_strPATIENTID_CHR;
                            objBIHVO.m_strINPATIENTID_CHR = objIndexVo.m_strINPATIENTID_CHR;
                            objBIHVO.m_intINPATIENTCOUNT_INT += 1;
                            lngReg = m_lngAddNewBihRegister(p_objPrincipal, out strTem, objBIHVO);
                            objBIHVO.m_strREGISTERID_CHR = strTem;
                        }

                        //6、占床；
                        if (lngReg > 0)
                        {
                            if (objBIHVO.m_strBEDID_CHR != null && objBIHVO.m_strBEDID_CHR != string.Empty)
                            {
                                lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objBIHVO.m_strBEDID_CHR, 2);
                            }
                        }

                        //7、增加调转信息；
                        FillTransfer_VO(objBIHVO, out objTransferVO);
                        if (lngReg > 0)
                        {
                            lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strTem, objTransferVO);
                        }
                        #endregion
                        break;
                    case 2:
                        #region 在院	{不能修改[入院科室、病区、床号]  注意这里没有控制，只能在表示层上处理}
                        //{1、获得索引Vo[clsclsPatientIdxVO]；2、修改基本信息索引；3、修改基本信息；4、修改住院登记信息；}
                        //1、获得索引Vo[clsclsPatientIdxVO]；
                        BaseVoToIndexVo(objPatientVO, out objIndexVo);

                        //2、修改基本信息索引；
                        lngReg = m_lngModifyPatientIdx(p_objPrincipal, objIndexVo);

                        //3、修改基本信息；
                        if (lngReg > 0)
                        {
                            lngReg = m_lngModifyPatient(p_objPrincipal, objPatientVO);
                        }

                        //4、修改住院登记信息；
                        if (lngReg > 0)
                        {
                            lngReg = m_lngModifyBihRegisterInfoByVo(p_objPrincipal, objBIHVO.m_strREGISTERID_CHR, objBIHVO);
                        }
                        //5 修改调转信息表
                        if (lngReg > 0)
                        {
                            lngReg = this.m_lngUpdateTransferInfo(objBIHVO.m_strREGISTERID_CHR);
                        }
                        #endregion
                        break;
                    case 3:
                        #region 再次入院
                        //{1、获得索引Vo[clsclsPatientIdxVO]；2、修改基本信息索引；3、修改基本信息；4、增加住院登记信息；5、占床；6、增加调转信息；}
                        //1、获得索引Vo[clsclsPatientIdxVO]；
                        BaseVoToIndexVo(objPatientVO, out objIndexVo);

                        //2、修改基本信息索引；
                        lngReg = m_lngModifyPatientIdx(p_objPrincipal, objIndexVo);

                        //3、修改基本信息；
                        if (lngReg > 0)
                        {
                            lngReg = m_lngModifyPatient(p_objPrincipal, objPatientVO);
                        }

                        //4、增加住院登记信息；
                        if (lngReg > 0)
                        {
                            objBIHVO.m_intINPATIENTCOUNT_INT += 1;
                            lngReg = m_lngAddNewBihRegister(p_objPrincipal, out strTem, objBIHVO);
                            objBIHVO.m_strREGISTERID_CHR = strTem;
                        }

                        //5、占床；
                        if (lngReg > 0)
                        {
                            if (objBIHVO.m_strBEDID_CHR != null && objBIHVO.m_strBEDID_CHR != string.Empty)
                            {
                                lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objBIHVO.m_strBEDID_CHR, 2);
                            }
                        }

                        //6、增加调转信息；
                        FillTransfer_VO(objBIHVO, out objTransferVO);
                        if (lngReg > 0)
                        {
                            lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strTem, objTransferVO);
                        }
                        #endregion
                        break;
                }
                #endregion
            }

            if (lngReg <= 0)
            {
                throw new Exception("操作失败！");
            }
            return lngReg;
        }
        /// <summary>
        /// 获得索引Vo
        /// </summary>
        /// <param name="objPatientVO">[clsPatient_VO]</param>
        /// <param name="objIndexVo">[clsclsPatientIdxVO]</param>
        [AutoComplete]
        public void BaseVoToIndexVo(clsPatient_VO objPatientVO, out clsclsPatientIdxVO objIndexVo)
        {
            objIndexVo = new clsclsPatientIdxVO();
            //病人编号
            objIndexVo.m_strPATIENTID_CHR = objPatientVO.m_strPATIENTID_CHR;
            //住院编号
            objIndexVo.m_strINPATIENTID_CHR = objPatientVO.m_strINPATIENTID_CHR;
            //身份证号
            objIndexVo.m_strIDCARD_CHR = objPatientVO.m_strIDCARD_CHR;
            //家庭住址
            objIndexVo.m_strHOMEADDRESS_VCHR = objPatientVO.m_strHOMEADDRESS_VCHR;
            //性别
            objIndexVo.m_strSEX_CHR = objPatientVO.m_strSEX_CHR;
            //出生年月
            objIndexVo.m_strBIRTH_DAT = objPatientVO.m_strBIRTH_DAT;
            //病人姓名
            objIndexVo.m_strNAME_VCHR = objPatientVO.m_strNAME_VCHR;
            //联系电话
            objIndexVo.m_strHOMEPHONE_VCHR = objPatientVO.m_strHOMEPHONE_VCHR;
            //医保编号
            objIndexVo.m_strINSURANCEID_VCHR = objPatientVO.m_strINSURANCEID_VCHR;
        }
        [AutoComplete]
        public void FillTransfer_VO(clsT_Opr_Bih_Register_VO objBIHVO, out clsT_Opr_Bih_Transfer_VO objPatientVO)
        {
            objPatientVO = new clsT_Opr_Bih_Transfer_VO();
            //操作类型{1=转科;2=调床;3=转科+调床;4=出院唤回;5=入院;6=出院}
            objPatientVO.m_intTYPE_INT = 5;
            objPatientVO.m_strDES_VCHR = null;
            objPatientVO.m_strMODIFY_DAT = objBIHVO.m_strMODIFY_DAT;
            objPatientVO.m_strOPERATORID_CHR = objBIHVO.m_strOPERATORID_CHR;
            objPatientVO.m_strREGISTERID_CHR = objBIHVO.m_strREGISTERID_CHR;
            objPatientVO.m_strSOURCEAREAID_CHR = null;
            objPatientVO.m_strSOURCEBEDID_CHR = null;
            objPatientVO.m_strSOURCEDEPTID_CHR = null;
            objPatientVO.m_strTARGETAREAID_CHR = objBIHVO.m_strAREAID_CHR;
            objPatientVO.m_strTARGETBEDID_CHR = objBIHVO.m_strBEDID_CHR;
            objPatientVO.m_strTARGETDEPTID_CHR = objBIHVO.m_strDEPTID_CHR;
            objPatientVO.m_strTRANSFERID_CHR = null;
        }
        #endregion
        #region 调转
        /// <summary>
        /// 调转
        /// {1、空出原来的床位；2、占领已转的床位；3、增加调转记录；4、修改入院登记的病床信息；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngTransferInHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO objPatientVO)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "lngTransferInHospital");
            if (lngReg < 0)
            {
                return -1;
            }
            //1、空出原来的床位；
            clsBedManageSvc obj = new clsBedManageSvc();
            if (lngReg > 0)
            {
                if (objPatientVO.m_strSOURCEBEDID_CHR != null && objPatientVO.m_strSOURCEBEDID_CHR != string.Empty && objPatientVO.m_intTYPE_INT != 3)
                {
                    lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objPatientVO.m_strSOURCEBEDID_CHR, 1);
                    if (objPatientVO.m_intTYPE_INT == 1)
                    {
                        objPatientVO.m_intTYPE_INT = 3;
                    }
                }
            }

            //2、占领已转的床位；
            if (lngReg > 0)
            {
                if (objPatientVO.m_strTARGETBEDID_CHR != null && objPatientVO.m_strTARGETBEDID_CHR != string.Empty)
                {
                    //撤小病人的包床
                    if (objPatientVO.m_intTYPE_INT != 2)
                    {
                        lngReg = new clsBedManageSvc().m_lngDelPatientOccupyBedByRegisterID(objPatientVO.m_strREGISTERID_CHR);
                    }
                    if (lngReg > 0)
                    {
                        lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objPatientVO.m_strTARGETBEDID_CHR, 2);
                    }
                }
            }

            //3、增加调转记录；
            if (lngReg > 0)
            {
                string strRecordID = "";
                lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strRecordID, objPatientVO);
                //				#region 病区日志统计
                //				lngReg = new clsBihStatQuerySvc().m_lngUpdateSickRoomLOGSTAT(objPatientVO);
                //				#endregion
            }

            //4、修改入院登记的病床信息；
            if (lngReg > 0)
            {
                //{0=未上床;1=已上床;2=预出院;3=实际出院}
                int intPSTATUS_INT = 0;
                if (objPatientVO.m_strTARGETBEDID_CHR != null && objPatientVO.m_strTARGETBEDID_CHR != string.Empty)
                {
                    intPSTATUS_INT = 1;
                }
                /* change by wjqin(06-3-6) */

                //	lngReg =m_lngModifyBedInfoByRegisterID(p_objPrincipal ,objPatientVO.m_strREGISTERID_CHR ,objPatientVO.m_strTARGETDEPTID_CHR.Trim() ,objPatientVO.m_strTARGETAREAID_CHR.Trim() ,objPatientVO.m_strTARGETBEDID_CHR.Trim() ,intPSTATUS_INT,objPatientVO.m_strOPERATORID_CHR,objPatientVO.m_strMODIFY_DAT);
                /*-------------------------------------------------------------------->*/
                lngReg = m_lngModifyBedInfoByRegisterID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strTARGETDEPTID_CHR, objPatientVO.m_strTARGETAREAID_CHR.Trim(), objPatientVO.m_strTARGETBEDID_CHR.Trim(), intPSTATUS_INT, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strMODIFY_DAT);
                /*<---------------------------------------------------------------------*/
            }

            if (lngReg <= 0)
            {
                throw new Exception("调转操作失败！");
            }
            return lngReg;
        }
        #endregion
        #region 调转
        /// <summary>
        /// 调转
        /// {1、空出原来的床位；2、占领已转的床位；3、增加调转记录；4、修改入院登记的病床信息；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngTransferInHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO objPatientVO, string p_strCASEDOCTOR_CHR)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "lngTransferInHospital");
            if (lngReg < 0)
            {
                return -1;
            }
            //1、空出原来的床位；
            clsBedManageSvc obj = new clsBedManageSvc();
            if (lngReg > 0)
            {
                //1、空出原来的床位；
                if (objPatientVO.m_strSOURCEBEDID_CHR != null && objPatientVO.m_strSOURCEBEDID_CHR != string.Empty && objPatientVO.m_intTYPE_INT != 3)
                {
                    lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objPatientVO.m_strSOURCEBEDID_CHR, 1);
                    if (objPatientVO.m_intTYPE_INT == 1)
                    {
                        objPatientVO.m_intTYPE_INT = 3;
                    }
                }
            }

            //2、占领已转的床位；
            if (lngReg > 0)
            {
                if (objPatientVO.m_strTARGETBEDID_CHR != null && objPatientVO.m_strTARGETBEDID_CHR != string.Empty)
                {
                    //撤小病人的包床
                    if (objPatientVO.m_intTYPE_INT != 2)
                    {
                        lngReg = new clsBedManageSvc().m_lngDelPatientOccupyBedByRegisterID(objPatientVO.m_strREGISTERID_CHR);
                    }
                    if (lngReg > 0)
                    {
                        lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objPatientVO.m_strTARGETBEDID_CHR, 2);
                    }
                }
            }

            //3、增加调转记录；
            if (lngReg > 0)
            {
                string strRecordID = "";
                lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strRecordID, objPatientVO);
                //				#region 病区日志统计
                //				lngReg = new clsBihStatQuerySvc().m_lngUpdateSickRoomLOGSTAT(objPatientVO);
                //				#endregion
            }

            //4、修改入院登记的病床信息；
            if (lngReg > 0)
            {
                //{0=未上床;1=已上床;2=预出院;3=实际出院}
                int intPSTATUS_INT = 0;
                if (objPatientVO.m_strTARGETBEDID_CHR != null && objPatientVO.m_strTARGETBEDID_CHR != string.Empty)
                {
                    intPSTATUS_INT = 1;
                }
                lngReg = m_lngModifyBedInfoByRegisterID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strTARGETDEPTID_CHR, objPatientVO.m_strTARGETAREAID_CHR, objPatientVO.m_strTARGETBEDID_CHR, intPSTATUS_INT, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strMODIFY_DAT, p_strCASEDOCTOR_CHR);
            }

            if (lngReg <= 0)
            {
                throw new Exception("调转操作失败！");
            }
            return lngReg;
        }
        #endregion
        #region 出院
        /// <summary>
        /// 出院
        /// {1、空出床位；2、增加一条出院记录；3、增加调转记录；4、修改入院登记在院状态；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objPrincipal"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngLeaveHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngLeaveHospital");
            if (lngReg < 0)
            {
                return -1;
            }
            //撤小病人的包床
            lngReg = new clsBedManageSvc().m_lngDelPatientOccupyBedByRegisterID(objPatientVO.m_strREGISTERID_CHR);
            if (lngReg > 0)
            {
                //1、空出床位；
                if (objPatientVO.m_intPSTATUS_INT == 1)
                {
                    clsBedManageSvc obj = new clsBedManageSvc();
                    if (objPatientVO.m_strOUTBEDID_CHR != null && objPatientVO.m_strOUTBEDID_CHR != string.Empty)
                    {
                        if (objPatientVO.m_strOUTBEDID_CHR != null && objPatientVO.m_strOUTBEDID_CHR != string.Empty)
                        {
                            lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objPatientVO.m_strOUTBEDID_CHR, 1);
                        }
                    }
                }
            }

            //2、增加一条出院记录；
            if (lngReg > 0 && objPatientVO.m_intPSTATUS_INT == 1)
            {
                string strRecordID = "";
                lngReg = m_lngAddNewBihLeave(p_objPrincipal, out strRecordID, objPatientVO);
            }

            //3、增加调转记录；
            string strTem = "";
            clsT_Opr_Bih_Transfer_VO objTransferVO = new clsT_Opr_Bih_Transfer_VO();
            FillTransfer_VO1(objPatientVO, out objTransferVO);
            objTransferVO.m_strMODIFY_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (lngReg > 0 && objPatientVO.m_intPSTATUS_INT == 1)
            {
                lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strTem, objTransferVO);
            }
            if (lngReg > 0 && objPatientVO.m_intPSTATUS_INT == 0)
            {
                objTransferVO.m_intTYPE_INT = 7;
                lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strTem, objTransferVO);
            }

            //4、修改入院登记在院状态
            if (lngReg > 0)
            {
                lngReg = m_lngModifyBihRegisterPSTATUS_INTByRegisterID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_intPSTATUS_INT + 2, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strMODIFY_DAT);
            }

            if (lngReg <= 0)
            {
                throw new Exception("出院操作失败！");
            }
            return lngReg;
        }
        [AutoComplete]
        public void FillTransfer_VO1(clsT_Opr_Bih_Leave_VO objBIHVO, out clsT_Opr_Bih_Transfer_VO objPatientVO)
        {
            objPatientVO = new clsT_Opr_Bih_Transfer_VO();
            //操作类型{1=转科;2=调床;3=转科+调床;4=出院唤回;5=入院;6=出院}
            objPatientVO.m_intTYPE_INT = 6;
            objPatientVO.m_strDES_VCHR = null;
            objPatientVO.m_strMODIFY_DAT = objBIHVO.m_strMODIFY_DAT;
            objPatientVO.m_strOPERATORID_CHR = objBIHVO.m_strOPERATORID_CHR;
            objPatientVO.m_strREGISTERID_CHR = objBIHVO.m_strREGISTERID_CHR;
            objPatientVO.m_strSOURCEAREAID_CHR = objBIHVO.m_strOUTAREAID_CHR;
            objPatientVO.m_strSOURCEBEDID_CHR = objBIHVO.m_strOUTBEDID_CHR;
            objPatientVO.m_strSOURCEDEPTID_CHR = objBIHVO.m_strOUTDEPTID_CHR;
            objPatientVO.m_strTARGETAREAID_CHR = null;
            objPatientVO.m_strTARGETBEDID_CHR = null;
            objPatientVO.m_strTARGETDEPTID_CHR = null;
            objPatientVO.m_strTRANSFERID_CHR = null;
        }
        #endregion
        #region 下床
        /// <summary>
        /// 下床
        /// {1、空出床位；2、修改入院登记记录[删除它的部门ID、病区ID、床位ID]；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objPrincipal"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDownBed(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngReg = 0;
            //			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //			lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc","m_lngLeaveHospital");
            //			if(lngReg < 0)
            //			{
            //				return -1;
            //			}
            //
            //			//1、空出床位；
            //			clsBedManageSvc obj =new clsBedManageSvc();
            //			if(objPatientVO.m_strOUTBEDID_CHR!=null && objPatientVO.m_strOUTBEDID_CHR!=string.Empty)
            //			{
            //				lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal,objPatientVO.m_strOUTBEDID_CHR,1);
            //			}
            //
            //
            //			//增加一条出院记录；
            //			if(lngReg > 0)
            //			{
            //				string strRecordID="";				 
            //				lngReg =m_lngAddNewBihLeave(p_objPrincipal,out strRecordID,objPatientVO);
            //			}
            //			
            //			if(lngReg <=0)
            //			{
            //				throw new Exception("出院操作失败！");
            //			}
            return lngReg;
        }
        #endregion
        #region 出院召回
        /// <summary>
        /// 出院召回
        /// {1、删除出院记录；2、占领新床位；3、增加住院调转记录；4、修改入院登记的病床信息；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRecallHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO objPatientVO)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngRecallHospital");
            if (lngReg < 0)
            {
                return -1;
            }

            //1、删除出院记录；
            lngReg = m_lngModifyBihLeaveByRegisterID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, 0, objPatientVO.m_strOPERATORID_CHR);

            //2、占领新床位；
            if (lngReg > 0)
            {
                if (objPatientVO.m_strTARGETBEDID_CHR != null && objPatientVO.m_strTARGETBEDID_CHR != string.Empty)
                {
                    clsBedManageSvc obj = new clsBedManageSvc();
                    lngReg = obj.m_lngModifyBedByBedID(p_objPrincipal, objPatientVO.m_strTARGETBEDID_CHR, 2);
                }
            }

            //3、增加住院调转记录；
            if (lngReg > 0)
            {
                string strRecordID = "";
                lngReg = m_lngAddNewBinTransfer(p_objPrincipal, out strRecordID, objPatientVO);
            }

            //4、修改入院登记的病床信息；
            if (lngReg > 0)
            {
                //{0=未上床;1=已上床;2=预出院;3=实际出院}
                int intPSTATUS_INT = 0;
                if (objPatientVO.m_strTARGETBEDID_CHR != null && objPatientVO.m_strTARGETBEDID_CHR != string.Empty)
                {
                    intPSTATUS_INT = 1;
                }
                lngReg = m_lngModifyBedInfoByRegisterID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strTARGETDEPTID_CHR, objPatientVO.m_strTARGETAREAID_CHR, objPatientVO.m_strTARGETBEDID_CHR, intPSTATUS_INT, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strMODIFY_DAT);
            }

            if (lngReg <= 0)
            {
                throw new Exception("出院召回操作失败！");
            }
            return lngReg;
        }
        #endregion
        #region 有条件查找住院病区
        [AutoComplete]
        public long m_lngGetAreaInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFilter, out com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] p_objResultArr)
        {
            p_objResultArr = new com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGet");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                                   inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                                   attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                                   wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                                   putmed_int
                              from t_bse_deptdesc";
            strSQL += p_strFilter + " ORDER BY CODE_VCHR";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO();
                        p_objResultArr[i1].m_strDEPTID_CHR = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["MODIFY_DAT"] != System.DBNull.Value)
                        {
                            p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strDEPTNAME_VCHR = dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["CATEGORY_INT"] != System.DBNull.Value)
                        {
                            p_objResultArr[i1].m_intCATEGORY_INT = Convert.ToInt32(dtbResult.Rows[i1]["CATEGORY_INT"].ToString().Trim());
                        }
                        if (dtbResult.Rows[i1]["INPATIENTOROUTPATIENT_INT"] != System.DBNull.Value)
                        {
                            p_objResultArr[i1].m_intINPATIENTOROUTPATIENT_INT = Convert.ToInt32(dtbResult.Rows[i1]["INPATIENTOROUTPATIENT_INT"].ToString().Trim());
                        }
                        p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strADDRESS_VCHR = dtbResult.Rows[i1]["ADDRESS_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSHORTNO_CHR = dtbResult.Rows[i1]["SHORTNO_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPYCODE_CHR = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strATTRIBUTEID = dtbResult.Rows[i1]["ATTRIBUTEID"].ToString().Trim();
                        p_objResultArr[i1].m_strPARENTID = dtbResult.Rows[i1]["PARENTID"].ToString().Trim();
                        if (dtbResult.Rows[i1]["CREATEDATE_DAT"] != System.DBNull.Value)
                        {
                            p_objResultArr[i1].m_strCREATEDATE_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CREATEDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        if (dtbResult.Rows[i1]["STATUS_INT"] != System.DBNull.Value)
                        {
                            p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        }
                        if (dtbResult.Rows[i1]["DEACTIVATE_DAT"] != System.DBNull.Value)
                        {
                            p_objResultArr[i1].m_strDEACTIVATE_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["DEACTIVATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strWBCODE_CHR = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCODE_VCHR = dtbResult.Rows[i1]["CODE_VCHR"].ToString().Trim();
                    }
                }
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
        #region 查找医嘱组套所共用部门
        [AutoComplete]
        public long m_mthGroupDepartment(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt, string strID, string strEx)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_mthGroupDepartment");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select * from T_AID_BIH_ORDERGROUPDEPARTMENT where GROUPID_CHR ='" + strID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

        //Add by jli in 2005-03-03
        #region 获取出院召回期限
        [AutoComplete]
        public long m_lnggetrecalllimitdays(System.Security.Principal.IPrincipal p_objPrincipal)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lnggetrecalllimitdays");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select leaverange_int from T_BSE_BIH_SPECORDERCATE";

            HRPService.clsHRPTableService objService = new clsHRPTableService();

            DataTable dtbres = new DataTable();

            try
            {
                lngRes = objService.DoGetDataTable(strSQL, ref dtbres);
                return int.Parse(dtbres.Rows[0]["leaverange_int"].ToString().Trim());
            }
            catch (Exception err)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(err);
                return -1;
            }
        }

        #endregion

        #region 获取最后出院日期
        [AutoComplete]
        public long m_lnggetlastleavedate(System.Security.Principal.IPrincipal p_objPrincipal, string strregisterid, out DateTime dtleave)
        {
            long lngRes = 0;
            dtleave = DateTime.Now;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lnggetlastleavedate");
            if (lngRes < 0)
            {
                return -1;
            }
            if (strregisterid == null || strregisterid.Trim() == "")
            {
                return -1;
            }
            string strSQLCount = @"select count(*) as c from t_opr_bih_register where pstatus_int=3 and inpatientid_chr='" + strregisterid.Trim() + "' order by INPATIENTCOUNT_INT desc";

            string strSQL = @"select modify_dat from t_opr_bih_register where pstatus_int=3 and inpatientid_chr='" + strregisterid.Trim() + "' order by INPATIENTCOUNT_INT desc";

            HRPService.clsHRPTableService objService = new clsHRPTableService();

            DataTable dtbres = new DataTable();

            try
            {
                lngRes = objService.DoGetDataTable(strSQLCount, ref dtbres);
                if (int.Parse(dtbres.Rows[0]["c"].ToString().Trim()) == 0)
                {
                    return -1;
                }
                lngRes = objService.DoGetDataTable(strSQL, ref dtbres);
                dtleave = DateTime.Parse(dtbres.Rows[0]["modify_dat"].ToString().Trim());
                return 0;
            }
            catch (Exception err)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(err);
                return -1;
            }
        }
        #endregion
        //Add end
        #region 查看病人出院时是否有未停的医嘱
        [AutoComplete]
        public long m_lngIshasAdvice(string p_strRegisterID, out int p_iCount)
        {
            p_iCount = 0;
            long ret = 0;
            string strSQL = @"SELECT COUNT (*) as c
  FROM t_opr_bih_order a
 WHERE ((    a.executetype_int = 1
        AND (   a.status_int = 1
             OR a.status_int = 2
             OR a.status_int = 5
            )
       )
    OR (a.executetype_int = 2 AND (a.status_int = 2 OR a.status_int = 5)))
    and a.registerid_chr = '" + p_strRegisterID + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                ret = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (ret > 0 && int.Parse(dtbResult.Rows[0]["c"].ToString()) > 0)
                {
                    p_iCount = int.Parse(dtbResult.Rows[0]["c"].ToString());
                }
                else
                {
                    ret = 0;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion
        #region 修改调转信息{病区,时间}
        public long m_lngUpdateTransferInfo(string p_strRegisterid)
        {
            long lngRes = 0;
            DataTable dtbResult = null;
            string strTransferID = "";
            lngRes = new clsBedManageSvc().m_lngGetPatientLastestTransferInfo(null, p_strRegisterid, out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                strTransferID = dtbResult.Rows[0]["TRANSFERID_CHR"].ToString();
            }
            else
            {
                return -1;
            }
            string strSQL = @"UPDATE t_opr_bih_transfer
   SET (targetareaid_chr, modify_dat) = (SELECT areaid_chr, modify_dat
                                           FROM t_opr_bih_register
                                          WHERE registerid_chr = '" + p_strRegisterid + @"')
 WHERE transferid_chr = '" + strTransferID + "'";

            /* @update by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */

            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"UPDATE t_opr_bih_transfer
SET targetareaid_chr = (SELECT  top 1 areaid_chr  FROM t_opr_bih_register  WHERE registerid_chr = '" + p_strRegisterid + @"'),
modify_dat = (SELECT  top 1 modify_dat  FROM t_opr_bih_register  WHERE registerid_chr =  '" + p_strRegisterid + @"')
WHERE transferid_chr  = '" + strTransferID + "'";
            }
            /* <<======================================= */
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPService = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPService.DoExcute(strSQL);
            }
            catch (Exception err)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(err);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 判断今天入院，今天出院的病人，是否漏收收床位费|诊金
        /// <summary>
        /// 判断是否为今天入院病人
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <param name="p_blnIsTodayPatient">[out参数] 是否对今天入院病人</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngJugeTodayPatient(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out bool p_blnIsTodayPatient)
        {
            p_blnIsTodayPatient = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderFeelByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"
						SELECT COUNT (*)
						FROM t_opr_bih_register b
						WHERE TRUNC (b.inpatient_dat) = TRUNC (SYSDATE)
							AND Trim(b.registerid_chr) = '[REGISTERID]'";

            /* @update by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */

            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT COUNT (*)
						FROM t_opr_bih_register b
						WHERE datediff(day,GETDATE(),b.inpatient_dat)= 0
							AND LTrim(RTRIM(b.registerid_chr)) = '[REGISTERID]'";
            }
            /* <<======================================= */

            strSQL = strSQL.Replace("[REGISTERID]", p_strRegisterID.Trim());
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (Int32.Parse(dtbResult.Rows[0][0].ToString()) > 0) p_blnIsTodayPatient = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = 0;
            }
            return lngRes;
        }
        /// <summary>
        /// 判断是否对今天入院，今天出院的病人，收取了床位费
        /// 注意：
        ///		返回2时，表不是今天入院的病人；{p_blnExist无效}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <param name="p_blnExist">[out参数] 是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChargeBedForTodayPatient(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out bool p_blnExist)
        {
            p_blnExist = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderFeelByID");
            if (lngRes < 0)
            {
                return -1;
            }

            //判断是否为今天入院病人
            bool blnIsTodayPatient = false;
            lngRes = m_lngJugeTodayPatient(p_objPrincipal, p_strRegisterID, out blnIsTodayPatient);
            if (!blnIsTodayPatient)
            {
                return 2;
            }

            string strSQL = @"
							SELECT COUNT (*)
							FROM t_opr_bih_patientcharge a
							WHERE TRIM (a.registerid_chr) = '[REGISTERID]'
							AND EXISTS (
									SELECT *
										FROM t_opr_bih_register b
									WHERE b.registerid_chr = a.registerid_chr
										AND TRUNC (b.inpatient_dat) = TRUNC (SYSDATE))
							AND EXISTS (SELECT *
											FROM t_bse_bih_specordercate
											WHERE TRIM (bedchargecate) = TRIM (a.invcateid_chr))";

            /* @update by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */

            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT COUNT (*)
							FROM t_opr_bih_patientcharge a
							WHERE LTRIM(RTRIM (a.registerid_chr)) = '[REGISTERID]'
							AND EXISTS (
									SELECT *
										FROM t_opr_bih_register b
									WHERE b.registerid_chr = a.registerid_chr
										AND DATEDIFF(DAY,b.inpatient_dat,GETDATE())=0)
							AND EXISTS (SELECT *
											FROM t_bse_bih_specordercate
											WHERE LTRIM(RTRIM (bedchargecate)) = LTRIM(RTRIM (a.invcateid_chr)))";
            }
            /* <<======================================= */

            strSQL = strSQL.Replace("[REGISTERID]", p_strRegisterID.Trim());
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (Int32.Parse(dtbResult.Rows[0][0].ToString()) > 0) p_blnExist = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = 0;
            }
            return lngRes;
        }
        /// <summary>
        /// 判断是否对今天入院，今天出院的病人，收取了诊金
        /// 注意：
        ///		返回2时，表不是今天入院的病人；{p_blnExist无效}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <param name="p_blnExist">[out参数] 是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChargeDiagnosisForTodayPatient(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out bool p_blnExist)
        {
            p_blnExist = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderFeelByID");
            if (lngRes < 0)
            {
                return -1;
            }

            //判断是否为今天入院病人
            bool blnIsTodayPatient = false;
            lngRes = m_lngJugeTodayPatient(p_objPrincipal, p_strRegisterID, out blnIsTodayPatient);
            if (!blnIsTodayPatient)
            {
                return 2;
            }

            string strSQL = @"
							SELECT COUNT (*)
							FROM t_opr_bih_patientcharge a
							WHERE TRIM (a.registerid_chr) = '[REGISTERID]'
							AND EXISTS (
									SELECT *
										FROM t_opr_bih_register b
									WHERE b.registerid_chr = a.registerid_chr
										AND TRUNC (b.inpatient_dat) = TRUNC (SYSDATE))
							AND EXISTS (SELECT *
											FROM t_bse_bih_specordercate
											WHERE TRIM (autochargeitemtype) = TRIM (a.chargeitemid_chr))";

            /* @update by wjqin (05-11-25)
             * 添加SQL SERVER的strSQl版本语名
             */

            if (clsHRPTableService.bytDatabase_Selector == 0)
            {
                strSQL = @"SELECT COUNT (*)
							FROM t_opr_bih_patientcharge a
							WHERE LTRIM(RTRIM (a.registerid_chr)) = '[REGISTERID]'
							AND EXISTS (
									SELECT *
										FROM t_opr_bih_register b
									WHERE b.registerid_chr = a.registerid_chr
										AND DATEDIFF(DAY,b.inpatient_dat,GETDATE())=0)
							AND EXISTS (SELECT *
											FROM t_bse_bih_specordercate
											WHERE LTRIM(RTRIM (autochargeitemtype)) = LTRIM(RTRIM (a.chargeitemid_chr)))";
            }
            /* <<======================================= */

            strSQL = strSQL.Replace("[REGISTERID]", p_strRegisterID.Trim());
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (Int32.Parse(dtbResult.Rows[0][0].ToString()) > 0) p_blnExist = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion
        #region 验证医包号是否有重号
        public long m_lngCheckInsuranceNum(string p_strInsurceNum, string p_strPatientId, out bool IsExist)
        {
            long lngRes = 0;
            IsExist = false;
            string strSQL = @"SELECT COUNT (*) as c 
  FROM t_bse_patient a
 WHERE a.insuranceid_vchr = '" + p_strInsurceNum + "' AND a.patientid_chr != '" + p_strPatientId + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPService = new clsHRPTableService();
                lngRes = objHRPService.DoGetDataTable(strSQL, ref dtbResult);
                if (lngRes > 0 && int.Parse(dtbResult.Rows[0]["c"].ToString()) > 0)
                {
                    IsExist = true;
                }
            }
            catch (Exception err)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(err);
                return -1;
            }
            return lngRes;
        }
        #endregion
        #region 根据病人ID 查出住院号和病人病人住院次数
        public long m_mthFindInhospitalTimesByID(string strID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"SELECT a.*, b.times
  FROM t_bse_patient a,
       (SELECT   COUNT (*) AS times, patientid_chr
            FROM t_opr_bih_register
           WHERE status_int = 1 AND patientid_chr = '" + strID + @"'
        GROUP BY patientid_chr) b
 WHERE a.patientid_chr = b.patientid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

        #region 修改住院基本信息(旧)
        /// <summary>
        /// 修改住院基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="intBihState"></param>
        /// <param name="objPatientVO"></param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeRegisterHospital(System.Security.Principal.IPrincipal p_objPrincipal, int intBihState, clsPatient_VO objPatientVO, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {

            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngRegisterHospital");
            if (lngReg < 0)
            {
                return -1;
            }

            clsclsPatientIdxVO objIndexVo = new clsclsPatientIdxVO();
            clsT_Opr_Bih_Transfer_VO objTransferVO = new clsT_Opr_Bih_Transfer_VO();
            clsBedManageSvc obj = new clsBedManageSvc();

            //确定基本信息状态
            #region 在院	{不能修改[入院科室、病区、床号]  注意这里没有控制，只能在表示层上处理}
            //{1、获得索引Vo[clsclsPatientIdxVO]；2、修改基本信息索引；3、修改基本信息；4、修改住院登记信息；}
            //1、获得索引Vo[clsclsPatientIdxVO]；
            BaseVoToIndexVo(objPatientVO, out objIndexVo);
            //2、修改基本信息索引；
            lngReg = m_lngModifyPatientIdx(p_objPrincipal, objIndexVo);

            //3、修改基本信息；
            if (lngReg > 0)
            {
                lngReg = m_lngModifyPatient(p_objPrincipal, objPatientVO);
            }

            //4、修改住院登记信息；
            if (lngReg > 0)
            {
                lngReg = m_lngModifyBihRegisterInfoByVo(p_objPrincipal, objBIHVO.m_strREGISTERID_CHR, objBIHVO);
            }
            //5 修改调转信息表
            if (lngReg > 0)
            {
                lngReg = this.m_lngUpdateTransferInfo(objBIHVO.m_strREGISTERID_CHR);
            }
            #endregion
            if (lngReg <= 0)
            {
                throw new Exception("操作失败！");
            }
            return lngReg;
        }
        #endregion

        #region 修改住院基本信息(新)
        /// <summary>
        /// 修改住院基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="intBihState"></param>
        /// <param name="objPatientVO"></param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeRegisterHospital2(System.Security.Principal.IPrincipal p_objPrincipal, int intBihState, clsPatient_VO objPatientVO, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {

            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngChangeRegisterHospital2");
            if (lngReg < 0)
            {
                return -1;
            }

            clsclsPatientIdxVO objIndexVo = new clsclsPatientIdxVO();
            clsT_Opr_Bih_Transfer_VO objTransferVO = new clsT_Opr_Bih_Transfer_VO();
            clsBedManageSvc obj = new clsBedManageSvc();

            //确定基本信息状态
            #region 在院	{不能修改[入院科室、病区、床号]  注意这里没有控制，只能在表示层上处理}
            //{1、获得索引Vo[clsclsPatientIdxVO]；2、修改基本信息索引；3、修改基本信息；4、修改住院登记信息；}
            //1、获得索引Vo[clsclsPatientIdxVO]；
            //BaseVoToIndexVo(objPatientVO, out objIndexVo);
            //2、修改基本信息索引；
            // lngReg = m_lngModifyPatientIdx(p_objPrincipal, objIndexVo);

            //3、修改基本信息；
            if (lngReg > 0)
            {
                lngReg = m_lngModifyPatient(p_objPrincipal, objPatientVO, objBIHVO.m_strREGISTERID_CHR);
            }

            //4、修改住院登记信息；
            if (lngReg > 0)
            {
                lngReg = m_lngModifyBihRegisterInfoByVo(p_objPrincipal, objBIHVO.m_strREGISTERID_CHR, objBIHVO);
            }
            //6.修改t_bse_hisemr_relation(电子病历同步关联表)
            if (lngReg > 0)
            {
                lngReg = m_lngModifyHisemrRelation(p_objPrincipal, objBIHVO.m_strREGISTERID_CHR, objBIHVO);

            }
            //5 修改调转信息表
            if (lngReg > 0)
            {
                lngReg = this.m_lngUpdateTransferInfo(objBIHVO.m_strREGISTERID_CHR);
            }
            #endregion
            if (lngReg <= 0)
            {
                throw new Exception("操作失败！");
            }
            return lngReg;
        }
        #endregion

        #region 获取 住院编号状态(0--自动,1--手工 
        /// <summary>
        /// 获取 住院编号状态(0--自动,1--手工）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_intISHOSNUMATUO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetISHOSNUMATUO(System.Security.Principal.IPrincipal p_objPrincipal, out int m_intISHOSNUMATUO)
        {
            m_intISHOSNUMATUO = 0;
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngGetISHOSNUMATUO");
            if (lngReg < 0)
            {
                return -1;
            }
            DataTable dtbResult = new DataTable();
            string strSQL = @"select a.ishosnumatuo from T_BSE_BIH_SPECORDERCATE a";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngReg = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngReg > 0 && dtbResult.Rows.Count > 0)
                {
                    m_intISHOSNUMATUO = int.Parse(dtbResult.Rows[0]["ishosnumatuo"].ToString());
                }
                else
                {
                    lngReg = 0;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngReg;

        }
        #endregion

        #region 根据住院登记流水号获取病人基本信息 
        /// <summary>
        /// 根据住院登记流水号获取病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strREGISTERID_CHR">病人ID</param>
        /// <param name="p_objResult">人基本信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientInfoByREGISTERID_CHR(System.Security.Principal.IPrincipal p_objPrincipal, string p_strREGISTERID_CHR, out clsPatient_VO p_objResult)
        {
            p_objResult = new clsPatient_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngGetPatientInfoByREGISTERID_CHR");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT 
            a.*,b.*
            FROM t_opr_bih_registerdetail a,t_opr_bih_register b
            where 
            a.registerid_chr=b.registerid_chr
            and a.registerid_chr=?";
            try
            {

                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strREGISTERID_CHR;
                lngRes = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    // p_objResult.strPatientCardID = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strINPATIENTID_CHR = dtbResult.Rows[0]["INPATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strLASTNAME_VCHR = dtbResult.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
                    p_objResult.m_strIDCARD_CHR = dtbResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
                    p_objResult.m_strMARRIED_CHR = dtbResult.Rows[0]["MARRIED_CHR"].ToString().Trim();
                    p_objResult.m_strBIRTHPLACE_VCHR = dtbResult.Rows[0]["BIRTHPLACE_VCHR"].ToString().Trim();
                    p_objResult.m_strHOMEADDRESS_VCHR = dtbResult.Rows[0]["HOMEADDRESS_VCHR"].ToString().Trim();
                    p_objResult.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    p_objResult.m_strNATIONALITY_VCHR = dtbResult.Rows[0]["NATIONALITY_VCHR"].ToString().Trim();
                    p_objResult.m_strFIRSTNAME_VCHR = dtbResult.Rows[0]["FIRSTNAME_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["BIRTH_DAT"] != Convert.DBNull)
                    {
                        p_objResult.m_strBIRTH_DAT = Convert.ToDateTime(dtbResult.Rows[0]["BIRTH_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objResult.m_strRACE_VCHR = dtbResult.Rows[0]["RACE_VCHR"].ToString().Trim();
                    p_objResult.m_strNATIVEPLACE_VCHR = dtbResult.Rows[0]["NATIVEPLACE_VCHR"].ToString().Trim();
                    p_objResult.m_strOCCUPATION_VCHR = dtbResult.Rows[0]["OCCUPATION_VCHR"].ToString().Trim();
                    p_objResult.m_strNAME_VCHR = dtbResult.Rows[0]["NAME_VCHR"].ToString().Trim();
                    p_objResult.m_strHOMEPHONE_VCHR = dtbResult.Rows[0]["HOMEPHONE_VCHR"].ToString().Trim();
                    p_objResult.m_strOFFICEPHONE_VCHR = dtbResult.Rows[0]["OFFICEPHONE_VCHR"].ToString().Trim();
                    p_objResult.m_strINSURANCEID_VCHR = dtbResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    p_objResult.m_strMOBILE_CHR = dtbResult.Rows[0]["MOBILE_CHR"].ToString().Trim();
                    p_objResult.m_strOFFICEADDRESS_VCHR = dtbResult.Rows[0]["OFFICEADDRESS_VCHR"].ToString().Trim();
                    p_objResult.m_strEMPLOYER_VCHR = dtbResult.Rows[0]["EMPLOYER_VCHR"].ToString().Trim();
                    p_objResult.m_strOFFICEPC_VCHR = dtbResult.Rows[0]["OFFICEPC_VCHR"].ToString().Trim();
                    p_objResult.m_strHOMEPC_CHR = dtbResult.Rows[0]["HOMEPC_CHR"].ToString().Trim();
                    p_objResult.m_strEMAIL_VCHR = dtbResult.Rows[0]["EMAIL_VCHR"].ToString().Trim();
                    p_objResult.m_strCONTACTPERSONFIRSTNAME_VCHR = dtbResult.Rows[0]["CONTACTPERSONFIRSTNAME_VCHR"].ToString().Trim();
                    p_objResult.m_strCONTACTPERSONLASTNAME_VCHR = dtbResult.Rows[0]["CONTACTPERSONLASTNAME_VCHR"].ToString().Trim();
                    p_objResult.m_strCONTACTPERSONADDRESS_VCHR = dtbResult.Rows[0]["CONTACTPERSONADDRESS_VCHR"].ToString().Trim();
                    p_objResult.m_strCONTACTPERSONPHONE_VCHR = dtbResult.Rows[0]["CONTACTPERSONPHONE_VCHR"].ToString().Trim();
                    p_objResult.m_strCONTACTPERSONPC_CHR = dtbResult.Rows[0]["CONTACTPERSONPC_CHR"].ToString().Trim();
                    p_objResult.m_strPATIENTRELATION_VCHR = dtbResult.Rows[0]["PATIENTRELATION_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["FIRSTDATE_DAT"] != Convert.DBNull)
                    {
                        p_objResult.m_strFIRSTDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["FIRSTDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    if (dtbResult.Rows[0]["ISEMPLOYEE_INT"] != Convert.DBNull)
                    {
                        p_objResult.m_intISEMPLOYEE_INT = Convert.ToInt32(dtbResult.Rows[0]["ISEMPLOYEE_INT"].ToString().Trim());
                    }
                    if (dtbResult.Rows[0]["STATUS_INT"] != Convert.DBNull)
                    {
                        p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
                    }
                    if (dtbResult.Rows[0]["DEACTIVATE_DAT"] != Convert.DBNull)
                    {
                        p_objResult.m_strDEACTIVATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["DEACTIVATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objResult.m_strOPERATORID_CHR = dtbResult.Rows[0]["OPERATORID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["MODIFY_DAT"] != Convert.DBNull)
                    {
                        p_objResult.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objResult.m_strGOVCARD_CHR = dtbResult.Rows[0]["GOVCARD_CHR"].ToString();
                    p_objResult.m_strBLOODTYPE_CHR = dtbResult.Rows[0]["BLOODTYPE_CHR"].ToString();
                    if (dtbResult.Rows[0]["IFALLERGIC_INT"] != Convert.DBNull)
                    {
                        p_objResult.m_intIFALLERGIC_INT = Convert.ToInt16(dtbResult.Rows[0]["IFALLERGIC_INT"].ToString());
                    }
                    p_objResult.m_strALLERGICDESC_VCHR = dtbResult.Rows[0]["ALLERGICDESC_VCHR"].ToString();
                    p_objResult.m_strPAYTYPEID_CHR = dtbResult.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    p_objResult.m_strDIFFICULTY_VCHR = dtbResult.Rows[0]["DIFFICULTY_VCHR"].ToString().Trim();
                    p_objResult.strInsuranceID = dtbResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    p_objResult.ConsigneeAddr = dtbResult.Rows[0]["consigneeaddr"].ToString().Trim();
                }

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

        #region  修改病人基本信息 
        /// <summary>
        /// 修改病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <param name="m_strREGISTERID_CHR"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyPatient(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO p_objRecord, string m_strREGISTERID_CHR)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"UPDATE t_opr_bih_registerdetail
   SET lastname_vchr = ?,
       idcard_chr = ?,
       married_chr = ?,
       birthplace_vchr = ?,
       homeaddress_vchr = ?,
       sex_chr = ?,
       nationality_vchr = ?,
       firstname_vchr = ?,
       birth_dat = ?,
       race_vchr = ?,
       nativeplace_vchr = ?,
       occupation_vchr = ?,
       name_vchr = ?,
       homephone_vchr = ?,
       officephone_vchr = ?,
       insuranceid_vchr = ?,
       mobile_chr = ?,
       
       officeaddress_vchr = ?,
       employer_vchr = ?,
       officepc_vchr = ?,
       homepc_chr = ?,
       email_vchr = ?,
       contactpersonfirstname_vchr = ?,
       contactpersonlastname_vchr = ?,
       contactpersonaddress_vchr = ?,
       contactpersonphone_vchr = ?,
       contactpersonpc_chr = ?,
       patientrelation_vchr = ?,
       firstdate_dat = ?,
       isemployee_int = ?,
       status_int = ?,
       operatorid_chr = ?,
       modify_dat = ?,
       --paytypeid_chr = ?,
       govcard_chr = ?,
       bloodtype_chr = ?,
       ifallergic_int = ?,
       allergicdesc_vchr = ?,
       consigneeaddr = ? 
 WHERE  registerid_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(39, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                int n = -1;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strLASTNAME_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strIDCARD_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strMARRIED_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strBIRTHPLACE_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strHOMEADDRESS_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strSEX_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strNATIONALITY_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strFIRSTNAME_VCHR;
                n++; objLisAddItemRefArr[n].Value = Convert.ToDateTime(p_objRecord.m_strBIRTH_DAT);
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strRACE_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strNATIVEPLACE_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strOCCUPATION_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strNAME_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strHOMEPHONE_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strOFFICEPHONE_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strINSURANCEID_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strMOBILE_CHR;

                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strOFFICEADDRESS_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strEMPLOYER_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strOFFICEPC_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strHOMEPC_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strEMAIL_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strCONTACTPERSONADDRESS_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strCONTACTPERSONPHONE_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strCONTACTPERSONPC_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strPATIENTRELATION_VCHR;
                n++; objLisAddItemRefArr[n].Value = Convert.ToDateTime(p_objRecord.m_strFIRSTDATE_DAT);
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_intISEMPLOYEE_INT;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_intSTATUS_INT;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strOPERATORID_CHR;
                n++; objLisAddItemRefArr[n].Value = Convert.ToDateTime(p_objRecord.m_strMODIFY_DAT);
                //n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strPAYTYPEID_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strGOVCARD_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strBLOODTYPE_CHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_intIFALLERGIC_INT;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                n++; objLisAddItemRefArr[n].Value = p_objRecord.ConsigneeAddr;

                n++; objLisAddItemRefArr[n].Value = m_strREGISTERID_CHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 修改住院登记--电子病历关联表
        /// <summary>
        /// 修改住院登记--电子病历关联表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">流水号</param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyHisemrRelation(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, clsT_Opr_Bih_Register_VO objPatientVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyHisemrRelation");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"UPDATE t_bse_hisemr_relation a
set 
a.hisinpatientdate=?,
a.operatorid_chr=?,
a.operat_dat=sysdate
   
   
 WHERE  a.registerid_chr=?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = Convert.ToDateTime(objPatientVO.m_strINPATIENT_DAT);
                objLisAddItemRefArr[1].Value = objPatientVO.m_strOPERATORID_CHR;
                objLisAddItemRefArr[2].Value = p_strRegisterid_chr;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 增加出院召回记录
        /// <summary>
        /// 增加出院召回记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        private long InsertReturnRecord(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO objPatientVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsBihRegisterSvc", "InsertReturnRecord");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO T_OPR_BIH_RETURNRECORD (SEQ_INT, REGISTERID_CHR, CREATE_DAT, CREATORID_CHR, RETURN_DAT, LEAVEID_CHR) 
                                                          VALUES (SEQ_RETURNRECORD.nextval, ?, sysdate, ?, sysdate, ?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);

                objLisAddItemRefArr[0].Value = objPatientVO.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = objPatientVO.m_strOPERATORID_CHR;
                //objLisAddItemRefArr[2].Value = objPatientVO.m_;

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
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
    }
}
