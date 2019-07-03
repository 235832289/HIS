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
    /// 住院进出转 -- 中间层
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBIHTransferSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        // 入院登记
        #region	从数据库获取数据(用于数据量小)
        /// <summary>
        /// 从数据库获取数据(用于数据量小)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSQL"></param>
        /// <param name="p_dtbRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSQL, out DataTable p_dtbRecord)
        {
            p_dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetInHosPatienList");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(p_strSQL, ref p_dtbRecord);
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

        #region 获得辅助字典信息
        /// <summary>
        /// 获得辅助字典信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intCat">辅助字典类别</param>
        /// <param name="p_objResultArr">辅助字典信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAID_DICTArr(System.Security.Principal.IPrincipal p_objPrincipal, int p_intCat, out clsAIDDICT_VO[] p_objResultArr)
        {
            p_objResultArr = new clsAIDDICT_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.common.clsCommonInfoSvc", "m_lngGetAID_DICTArr");
            //objPrivilege.Dispose();
            if (lngRes < 0)
            {
                return -1;
            }
            string strTemp = "";
            if (clsHRPTableService.bytDatabase_Selector == 2)
            {
                strTemp = " TO_NUMBER(DICTID_CHR) ";
            }
            else
            {
                strTemp = " cast(DICTID_CHR as int) ";
            }
            string strSQL = @"SELECT  A.JXCODE_CHR , A.WBCODE_CHR , A.PYCODE_CHR , A.DICTNAME_VCHR , A.DICTID_CHR
				, A.DICTKIND_CHR , A.DICTSEQID_CHR,A.DICTDEFINECODE_VCHR FROM  T_AID_DICT A WHERE  DICTID_CHR != '0'" +
                " AND DICTKIND_CHR = '" + p_intCat + "' ORDER BY " + strTemp;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsAIDDICT_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsAIDDICT_VO();
                        p_objResultArr[i1].m_strJXCODE_CHR = dtbResult.Rows[i1]["JXCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strWBCODE_CHR = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPYCODE_CHR = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDICTNAME_VCHR = dtbResult.Rows[i1]["DICTNAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDICTID_CHR = dtbResult.Rows[i1]["DICTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDICTKIND_CHR = dtbResult.Rows[i1]["DICTKIND_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDICTSEQID_CHR = dtbResult.Rows[i1]["DICTSEQID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDICTDEFINECODE_VCHR = dtbResult.Rows[i1]["DICTDEFINECODE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCodeAndName = p_objResultArr[i1].m_strDICTDEFINECODE_VCHR + "-" + p_objResultArr[i1].m_strDICTNAME_VCHR;
                    }
                }
                //objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                //objHRPSvc.Dispose();
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据诊疗卡号或住院号获取病人ID
        /// <summary>
        /// 根据诊疗卡号或住院号获取病人ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intFindType">查找标识:0-诊疗卡号,1-住院号</param>
        /// <param name="p_strFindText">查找本文</param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientIDByCarIDOrInPatientID(System.Security.Principal.IPrincipal p_objPrincipal, int p_intFindType, string p_strFindText, out string p_strPatientID)
        {
            p_strPatientID = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetPatientIDByCarIDOrInPatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            try
            {
                DataTable p_dtbResult = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                if (p_intFindType == 0 || p_intFindType == 2)
                {
                    strSQL = @"SELECT patientid_chr
  FROM t_bse_patientcard
 WHERE patientcardid_chr = ? and status_int > 0";
                }
                else
                {
                    strSQL = @"SELECT MAX (t1.patientid_chr) AS patientid_chr
  FROM t_opr_bih_register t1
 WHERE t1.inpatientid_chr = ? AND t1.status_int = 1";
                }
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strFindText;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && p_dtbResult.Rows.Count > 0)
                {
                    p_strPatientID = p_dtbResult.Rows[0]["patientid_chr"].ToString().Trim();
                }
                else
                {
                    lngRes = -1;
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

        #region 根据病人ID和入院类型获取在院记录数和入院次数
        /// <summary>
        /// 根据病人ID和入院类型获取在院记录数和入院次数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_intInType">入院类型:1-正式,2-留观</param>
        /// <param name="p_objResult">病人最近一次住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestInHospitalInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, int p_intInType, out clsBIHpatientVO p_objResult)
        {
            p_objResult = new clsBIHpatientVO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetLatestInHospitalInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.incount, b.inpatientcount_int, b.inpatientid_chr
                              FROM (SELECT COUNT (t1.registerid_chr) incount
                                      FROM t_opr_bih_register t1
                                     WHERE t1.patientid_chr = ?
                                       AND t1.status_int = 1
                                       AND t1.pstatus_int <> 3) a,
                                   (SELECT MAX (t2.inpatientcount_int) + 1 AS inpatientcount_int,
                                           MAX (t2.inpatientid_chr) AS inpatientid_chr
                                      FROM t_opr_bih_register t2
                                     WHERE t2.patientid_chr = ?
                                       AND t2.status_int = 1
                                       AND t2.inpatientnotype_int = ?) b";
            try
            {
                DataTable p_dtbResult = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strPatientID;
                objLisAddItemRefArr[1].Value = p_strPatientID;
                objLisAddItemRefArr[2].Value = p_intInType;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && p_dtbResult.Rows.Count > 0)
                {
                    DataRow dr = p_dtbResult.Rows[0];
                    p_objResult.m_strPSTATUS_INT = dr["incount"].ToString().Trim();
                    p_objResult.m_strINPATIENTCOUNT_INT = dr["inpatientcount_int"].ToString().Trim();
                    p_objResult.m_strINPATIENTID_CHR = dr["inpatientid_chr"].ToString().Trim();
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

        #region 根据病人ID从病人表获取病人基本信息
        /// <summary>
        /// 根据病人ID从病人表获取病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientid_chr">病人ID</param>
        /// <param name="p_objResult">人基本信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientInfoByPatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientid_chr, out clsPatient_VO p_objResult)
        {
            p_objResult = new clsPatient_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetPatientInfoByPatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.patientid_chr,
                                a.inpatientid_chr,
                                a.lastname_vchr,
                                a.idcard_chr,
                                a.married_chr,
                                a.birthplace_vchr,
                                a.homeaddress_vchr,  
                                a.sex_chr,
                                a.nationality_vchr,
                                a.firstname_vchr,
                                a.birth_dat,
                                a.race_vchr,
                                a.nativeplace_vchr,
                                a.occupation_vchr,
                                a.name_vchr,
                                a.homephone_vchr,
                                a.officephone_vchr,
                                a.insuranceid_vchr,
                                a.mobile_chr,
                                a.employer_vchr,
                                a.officeaddress_vchr,
                                a.officepc_vchr,
                                a.homepc_chr,
                                a.email_vchr,
                                a.contactpersonfirstname_vchr,
                                a.contactpersonlastname_vchr,
                                a.inpatienttempid_vchr,
                                a.extendid_vchr,
                                a.difficulty_vchr,
                                a.allergicdesc_vchr,
                                a.ifallergic_int,
                                a.bloodtype_chr,
                                a.govcard_chr,
                                a.optimes_int,
                                a.paytypeid_chr,
                                a.modify_dat,
                                a.operatorid_chr,
                                a.deactivate_dat,
                                a.status_int,
                                a.isemployee_int,
                                a.firstdate_dat,
                                a.patientrelation_vchr,
                                a.contactpersonpc_chr,
                                a.contactpersonphone_vchr,
                                a.contactpersonaddress_vchr,
                                a.consigneeaddr      
                            from t_bse_patient a
                            where a.patientid_chr = '" + p_strPatientid_chr + "'";

            //            string strSQL = @"SELECT a.*
            //           FROM t_bse_patient a
            //          WHERE a.patientid_chr = '" + p_strPatientid_chr + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
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
                    p_objResult.m_strINPATIENTTEMPID_VCHR = dtbResult.Rows[0]["INPATIENTTEMPID_VCHR"].ToString().Trim();
                    p_objResult.ConsigneeAddr = dtbResult.Rows[0]["consigneeaddr"].ToString();

                    strSQL = @"select b.insuredtotalmoney_mny, b.insuredpaymoney_mny, b.insuredpaytime_int, 
                                      b.insuredpayscale_dec, b.birthplace_vchr, b.residenceplace_vchr  
                                 from t_opr_bih_register a, 
                                      t_opr_bih_registerdetail b 
                                where a.registerid_chr = b.registerid_chr 
                                  and a.patientid_chr = '" + p_strPatientid_chr + "' order by  a.registerid_chr desc";

                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                    if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    {
                        p_objResult.m_decInsuredMoney = Convert.ToDecimal(dtbResult.Rows[0]["insuredtotalmoney_mny"].ToString());
                        p_objResult.m_decInsuredPayTime = Convert.ToDecimal(dtbResult.Rows[0]["insuredpaytime_int"].ToString());
                        p_objResult.m_decInsuredPayMoney = Convert.ToDecimal(dtbResult.Rows[0]["insuredpaymoney_mny"].ToString());
                        p_objResult.m_strBIRTHPLACE_VCHR = dtbResult.Rows[0]["birthplace_vchr"].ToString();
                        p_objResult.m_strResidencePlace = dtbResult.Rows[0]["residenceplace_vchr"].ToString();
                    }
                    else
                    {
                        p_objResult.m_decInsuredMoney = 0;
                        p_objResult.m_decInsuredPayTime = 0;
                        p_objResult.m_decInsuredPayMoney = 0;

                        p_objResult.m_strBIRTHPLACE_VCHR = "";
                        p_objResult.m_strResidencePlace = "";
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
        /// 根据病人登记ID获取病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientINfoByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsPatient_VO p_objResult)
        {
            p_objResult = new clsPatient_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetPatientInfoByPatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.patientid_chr,
                                       a.inpatientid_chr,
                                       a.lastname_vchr,
                                       a.idcard_chr,
                                       a.married_chr,
                                       a.birthplace_vchr,
                                       a.homeaddress_vchr,
                                       a.sex_chr,
                                       a.nationality_vchr,
                                       a.firstname_vchr,
                                       a.birth_dat,
                                       a.race_vchr,
                                       a.nativeplace_vchr,
                                       a.occupation_vchr,
                                       a.name_vchr,
                                       a.homephone_vchr,
                                       a.officephone_vchr,
                                       a.insuranceid_vchr,
                                       a.mobile_chr,
                                       a.employer_vchr,
                                       a.officeaddress_vchr,
                                       a.officepc_vchr,
                                       a.homepc_chr,
                                       a.email_vchr,
                                       a.contactpersonfirstname_vchr,
                                       a.contactpersonlastname_vchr,
                                       a.inpatienttempid_vchr,
                                       a.extendid_vchr,
                                       a.difficulty_vchr,
                                       a.allergicdesc_vchr,
                                       a.ifallergic_int,
                                       a.bloodtype_chr,
                                       a.govcard_chr,
                                       a.optimes_int,
                                       a.paytypeid_chr,
                                       a.modify_dat,
                                       a.operatorid_chr,
                                       a.deactivate_dat,
                                       a.status_int,
                                       a.isemployee_int,
                                       a.firstdate_dat,
                                       a.patientrelation_vchr,
                                       a.contactpersonpc_chr,
                                       a.contactpersonphone_vchr,
                                       a.contactpersonaddress_vchr,
                                       a.patientsources_vchr,
                                       a.consigneeaddr 
                                  from t_opr_bih_register b, t_bse_patient a
                                 where b.patientid_chr = a.patientid_chr
                                   and b.registerid_chr = ? ";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] parmArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out parmArr);
                parmArr[0].Value = p_strRegisterID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, parmArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
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
                    p_objResult.m_strPatientSource = dtbResult.Rows[0]["PATIENTSOURCES_VCHR"].ToString().Trim();//2010/8/25 添加 陈世春
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
                    p_objResult.m_strINPATIENTTEMPID_VCHR = dtbResult.Rows[0]["INPATIENTTEMPID_VCHR"].ToString().Trim();
                    p_objResult.ConsigneeAddr = dtbResult.Rows[0]["consigneeaddr"].ToString();

                    strSQL = @"select b.insuredtotalmoney_mny,
                                       b.insuredpaymoney_mny,
                                       b.insuredpaytime_int,
                                       b.insuredpayscale_dec,
                                       b.birthplace_vchr,
                                       b.residenceplace_vchr
                                  from t_opr_bih_register a, t_opr_bih_registerdetail b
                                 where a.registerid_chr = b.registerid_chr
                                   and a.registerid_chr = ?
                                 order by a.registerid_chr desc";
                    objHRPSvc.CreateDatabaseParameter(1, out parmArr);
                    parmArr[0].Value = p_strRegisterID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, parmArr);

                    if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    {
                        p_objResult.m_decInsuredMoney = Convert.ToDecimal(dtbResult.Rows[0]["insuredtotalmoney_mny"].ToString());
                        p_objResult.m_decInsuredPayTime = Convert.ToDecimal(dtbResult.Rows[0]["insuredpaytime_int"].ToString());
                        p_objResult.m_decInsuredPayMoney = Convert.ToDecimal(dtbResult.Rows[0]["insuredpaymoney_mny"].ToString());
                        p_objResult.m_strBIRTHPLACE_VCHR = dtbResult.Rows[0]["birthplace_vchr"].ToString();
                        p_objResult.m_strResidencePlace = dtbResult.Rows[0]["residenceplace_vchr"].ToString();
                    }
                    else
                    {
                        p_objResult.m_decInsuredMoney = 0;
                        p_objResult.m_decInsuredPayTime = 0;
                        p_objResult.m_decInsuredPayMoney = 0;

                        p_objResult.m_strBIRTHPLACE_VCHR = "";
                        p_objResult.m_strResidencePlace = "";
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

        #region 根据入院登记ID获取病人住院信息
        /// <summary>
        /// 根据入院登记ID获取病人住院信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">病人住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBIHPatientInfoByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHpatientVO p_objResult)
        {
            p_objResult = new clsBIHpatientVO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBIHPatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   t1.registerid_chr, t1.patientid_chr, t1.inpatientid_chr, t1.status_int,
                                       t1.pstatus_int, t1.inpatientcount_int, t1.icd10diagtext_vchr,
                                       t1.inpatient_dat, t1.inpatientnotype_int, t4.flgname_vchr AS status,
                                       t5.flgname_vchr AS pstatus, t2.name_vchr, t2.birth_dat, t2.sex_chr,
                                       t1.areaid_chr, t3.deptname_vchr AS areaname, t6.code_chr,
                                       t7.patientcardid_chr, t1.type_int, t1.casedoctor_chr,
                                       t8.lastname_vchr AS doctorname, t1.diagnoseid_chr, t1.diagnose_vchr,
                                       t1.icd10diagid_vchr, t2.idcard_chr, t2.homephone_vchr,
                                       t2.insuranceid_vchr, t1.paytypeid_chr, t9.paytypename_vchr,
                                       t9.internalflag_int, hr.HISINPATIENTDATE
                                  FROM t_opr_bih_register t1,
                                       t_opr_bih_registerdetail t2,
                                       t_bse_deptdesc t3,
                                       t_sys_flg_table t4,
                                       t_sys_flg_table t5,
                                       t_bse_bed t6,
                                       t_bse_patientcard t7,
                                       t_bse_employee t8,
                                       t_bse_patientpaytype t9,
                                       T_BSE_HISEMR_RELATION hr
                                 WHERE 
                                        hr.REGISTERID_CHR = t1.registerid_chr
                                   AND t4.tablename_vchr = 't_opr_bih_register'
                                   AND t4.columnname_vchr = 'STATE_INT'
                                   AND t5.tablename_vchr = 't_opr_bih_register'
                                   AND t5.columnname_vchr = 'PSTATUS_INT'
                                   AND t1.state_int = t4.flg_int
                                   AND t1.pstatus_int = t5.flg_int
                                   AND t1.registerid_chr = t2.registerid_chr
                                   AND t1.areaid_chr = t3.deptid_chr(+)
                                   AND t1.bedid_chr = t6.bedid_chr(+)
                                   AND t1.patientid_chr = t7.patientid_chr(+)
                                   AND t1.casedoctor_chr = t8.empid_chr(+)
                                   AND t1.paytypeid_chr = t9.paytypeid_chr(+)
                                   AND t1.registerid_chr = ? ";
            try
            {
                DataTable dtbResult = new DataTable();
                //com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                System.Data.IDataParameter[] objParameterArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objParameterArr);
                objParameterArr[0].Value = p_strRegisterID;


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParameterArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsBIHpatientVO();
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strINPATIENTID_CHR = dtbResult.Rows[0]["INPATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strSTATUS_INT = dtbResult.Rows[0]["STATUS_INT"].ToString().Trim();
                    p_objResult.m_strPSTATUS_INT = dtbResult.Rows[0]["PSTATUS_INT"].ToString().Trim();
                    p_objResult.m_strINPATIENTCOUNT_INT = dtbResult.Rows[0]["INPATIENTCOUNT_INT"].ToString().Trim();
                    p_objResult.m_strICD10DIAGTEXT_VCHR = dtbResult.Rows[0]["ICD10DIAGTEXT_VCHR"].ToString().Trim();
                    p_objResult.m_strSTATUS = dtbResult.Rows[0]["STATUS"].ToString().Trim();
                    p_objResult.m_strPSTATUS = dtbResult.Rows[0]["PSTATUS"].ToString().Trim();
                    p_objResult.m_strINPATIENT_DAT = dtbResult.Rows[0]["inpatient_dat"].ToString().Trim();
                    p_objResult.m_strINPATIENTNOTYPE_INT = dtbResult.Rows[0]["inpatientnotype_int"].ToString().Trim();
                    p_objResult.m_strNAME_VCHR = dtbResult.Rows[0]["NAME_VCHR"].ToString().Trim();
                    p_objResult.m_strBIRTH_DAT = dtbResult.Rows[0]["BIRTH_DAT"].ToString().Trim();
                    p_objResult.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    p_objResult.m_strAREAID = dtbResult.Rows[0]["AREAID_CHR"].ToString().Trim();
                    p_objResult.m_strAREANAME = dtbResult.Rows[0]["AREANAME"].ToString().Trim();
                    p_objResult.m_strCODE_CHR = dtbResult.Rows[0]["CODE_CHR"].ToString().Trim();
                    p_objResult.m_strPATIENTCARDID_CHR = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
                    p_objResult.m_strTYPE_INT = dtbResult.Rows[0]["TYPE_INT"].ToString().Trim();
                    p_objResult.m_strCASEDOCTOR_CHR = dtbResult.Rows[0]["CASEDOCTOR_CHR"].ToString().Trim();
                    p_objResult.m_strDOCTORNAME = dtbResult.Rows[0]["DOCTORNAME"].ToString().Trim();
                    p_objResult.m_strDIAGNOSEID_CHR = dtbResult.Rows[0]["DIAGNOSEID_CHR"].ToString().Trim();
                    p_objResult.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString().Trim();
                    p_objResult.m_strICD10DIAGID_VCHR = dtbResult.Rows[0]["ICD10DIAGID_VCHR"].ToString().Trim();
                    p_objResult.m_strIDCARD_CHR = dtbResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
                    p_objResult.m_strHOMEPHONE_VCHR = dtbResult.Rows[0]["HOMEPHONE_VCHR"].ToString().Trim();
                    p_objResult.m_strINSURANCEID_VCHR = dtbResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    p_objResult.m_strPAYTYPEID_CHR = dtbResult.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    p_objResult.m_strPAYTYPENAME_VCHR = dtbResult.Rows[0]["PAYTYPENAME_VCHR"].ToString().Trim();
                    p_objResult.m_strINTERNALFLAG_INT = dtbResult.Rows[0]["INTERNALFLAG_INT"].ToString().Trim();
                    p_objResult.m_strInAreaDate = dtbResult.Rows[0]["HISINPATIENTDATE"].ToString().Trim();
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

        #region 根据入院登记ID获取病人住院信息和收费信息
        /// <summary>
        /// 根据入院登记ID获取病人住院信息和收费信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">病人住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBIHPatientInfoAndCharge(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsBIHpatientVO p_objResult)
        {
            p_objResult = new clsBIHpatientVO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBIHPatientInfoAndCharge");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                lngRes = m_lngGetBIHPatientInfoByRegID(p_objPrincipal, p_strRegisterID, out p_objResult);
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //获取金余额
                string strSQL = @"select sum (t1.money_dec) as summoney
                      from t_opr_bih_prepay t1
                     where t1.registerid_chr = '" + p_strRegisterID + @"'
                       and t1.isclear_int = 0
                       and t1.status_int = 1";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strBalance = dtbResult.Rows[0]["summoney"].ToString().Trim();
                }
                // 获取未清费用 
                strSQL = @"select sum (t1.amount_dec * t1.unitprice_dec) as sumcharge
                              from t_opr_bih_patientcharge t1
                             where t1.registerid_chr = '" + p_strRegisterID + @"'
                               and t1.status_int = 1
                               and (t1.pstatus_int = 1 or t1.pstatus_int = 2)";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strUnclearCharge = dtbResult.Rows[0]["sumcharge"].ToString().Trim();
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

        #region  病人资料登记
        /// <summary>
        /// 病人资料登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">病人资料VO</param>
        /// <param name="p_strRecordID">病人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPatientBaseInfoRegist(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO p_objRecord, out string p_strRecordID)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngPatientBaseInfoRegist");
            if (lngRes < 0)
            {
                return -1;
            }
            DateTime m_DateTime = DateTime.Now;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                // 1.增加病人索引记录
                string strSQL = @"INSERT INTO t_bse_patientidx
            (patientid_chr, inpatientid_chr, idcard_chr, homeaddress_vchr,
             sex_chr, birth_dat, name_vchr, homephone_vchr, insuranceid_vchr,
             difficulty_vchr, govcard_chr
            )
     VALUES (?, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?
            )";

                objHRPSvc.m_lngGenerateNewID("T_BSE_PATIENTIDX", "PATIENTID_CHR", out p_strRecordID);
                p_objRecord.m_strPATIENTID_CHR = p_strRecordID;
                objHRPSvc.CreateDatabaseParameter(11, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strIDCARD_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strHOMEADDRESS_VCHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strSEX_CHR;
                objLisAddItemRefArr[5].Value = DateTime.Parse(p_objRecord.m_strBIRTH_DAT);
                objLisAddItemRefArr[6].Value = p_objRecord.m_strNAME_VCHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strHOMEPHONE_VCHR;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strINSURANCEID_VCHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strDIFFICULTY_VCHR;
                objLisAddItemRefArr[10].Value = p_objRecord.m_strGOVCARD_CHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes < 1)
                {
                    throw new Exception("增加病人索引记录失败！");
                }

                //2.增加病人基本信息 
                strSQL = @"INSERT INTO t_bse_patient
            (patientid_chr, inpatientid_chr, lastname_vchr, idcard_chr,
             married_chr, birthplace_vchr, homeaddress_vchr, sex_chr,
             nationality_vchr, firstname_vchr, birth_dat, race_vchr,
             nativeplace_vchr, occupation_vchr, name_vchr, homephone_vchr,
             officephone_vchr, insuranceid_vchr, mobile_chr,
             officeaddress_vchr, employer_vchr, officepc_vchr, homepc_chr,
             email_vchr, contactpersonfirstname_vchr,
             contactpersonlastname_vchr, contactpersonaddress_vchr,
             contactpersonphone_vchr, contactpersonpc_chr,
             patientrelation_vchr, firstdate_dat, isemployee_int, status_int,
             deactivate_dat, operatorid_chr, modify_dat, paytypeid_chr,
             govcard_chr, bloodtype_chr, ifallergic_int, allergicdesc_vchr,
             difficulty_vchr, inpatienttempid_vchr, patientsources_vchr, consigneeaddr 
            )
     VALUES (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?,
             ?, ?,
             ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ? 
            )";
                objHRPSvc.CreateDatabaseParameter(45, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strLASTNAME_VCHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strIDCARD_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strMARRIED_CHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strBIRTHPLACE_VCHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strHOMEADDRESS_VCHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strSEX_CHR;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strNATIONALITY_VCHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strNAME_VCHR;
                objLisAddItemRefArr[10].Value = DateTime.Parse(p_objRecord.m_strBIRTH_DAT);
                objLisAddItemRefArr[11].Value = p_objRecord.m_strRACE_VCHR;
                objLisAddItemRefArr[12].Value = p_objRecord.m_strNATIVEPLACE_VCHR;
                objLisAddItemRefArr[13].Value = p_objRecord.m_strOCCUPATION_VCHR;
                objLisAddItemRefArr[14].Value = p_objRecord.m_strNAME_VCHR;
                objLisAddItemRefArr[15].Value = p_objRecord.m_strHOMEPHONE_VCHR;
                objLisAddItemRefArr[16].Value = p_objRecord.m_strOFFICEPHONE_VCHR;
                objLisAddItemRefArr[17].Value = p_objRecord.m_strINSURANCEID_VCHR;
                objLisAddItemRefArr[18].Value = p_objRecord.m_strMOBILE_CHR;
                objLisAddItemRefArr[19].Value = p_objRecord.m_strOFFICEADDRESS_VCHR;
                objLisAddItemRefArr[20].Value = p_objRecord.m_strEMPLOYER_VCHR;
                objLisAddItemRefArr[21].Value = p_objRecord.m_strOFFICEPC_VCHR;
                objLisAddItemRefArr[22].Value = p_objRecord.m_strHOMEPC_CHR;
                objLisAddItemRefArr[23].Value = p_objRecord.m_strEMAIL_VCHR;
                objLisAddItemRefArr[24].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR; //p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strCONTACTPERSONADDRESS_VCHR;
                objLisAddItemRefArr[27].Value = p_objRecord.m_strCONTACTPERSONPHONE_VCHR;
                objLisAddItemRefArr[28].Value = p_objRecord.m_strCONTACTPERSONPC_CHR;
                objLisAddItemRefArr[29].Value = p_objRecord.m_strPATIENTRELATION_VCHR;
                objLisAddItemRefArr[30].Value = m_DateTime;
                objLisAddItemRefArr[31].Value = p_objRecord.m_intISEMPLOYEE_INT;
                objLisAddItemRefArr[32].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[33].Value = null;
                objLisAddItemRefArr[34].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[35].Value = m_DateTime;
                objLisAddItemRefArr[36].Value = p_objRecord.m_strPAYTYPEID_CHR;
                objLisAddItemRefArr[37].Value = p_objRecord.m_strGOVCARD_CHR;
                objLisAddItemRefArr[38].Value = p_objRecord.m_strBLOODTYPE_CHR;
                objLisAddItemRefArr[39].Value = p_objRecord.m_intIFALLERGIC_INT;
                objLisAddItemRefArr[40].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[41].Value = p_objRecord.m_strDIFFICULTY_VCHR;
                objLisAddItemRefArr[42].Value = p_objRecord.m_strINPATIENTTEMPID_VCHR;
                objLisAddItemRefArr[43].Value = p_objRecord.m_strPatientSource;
                objLisAddItemRefArr[44].Value = p_objRecord.ConsigneeAddr;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes < 1)
                {
                    throw new Exception("增加病人基本信息失败！");
                }

                // 3.生成病人诊疗卡号
                string CardId;
                //lngRes = objHRPSvc.lngGenerateID(10, "PATIENTCARDID_CHR", "T_BSE_PATIENTCARD", out CardId);
                lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_PATIENTCARD", "PATIENTCARDID_CHR", out CardId);
                strSQL = @"INSERT INTO t_bse_patientcard
            (patientcardid_chr, patientid_chr, issue_date, status_int
            )
     VALUES (?, ?, ?, ?
            )";
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = CardId;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[2].Value = m_DateTime;
                objLisAddItemRefArr[3].Value = 3;  //自动获取卡号
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes < 1)
                {
                    throw new Exception("卡号已经被占用！");
                }

                // 4.增加病人身份对应表记录
                strSQL = @"INSERT INTO t_bse_patientidentityno
            (patientid_chr, paytypeid_chr, idno_vchr
            )
     VALUES (?, ?, ?
            )";
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strPAYTYPEID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strINSURANCEID_VCHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes < 1)
                {
                    throw new Exception("增加病人身份对应表记录失败！");
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            //消息处理
            com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
            try
            {
                lngRes = objMsgUpdate.AddMsg("10001", 1, p_objRecord.m_strPATIENTID_CHR);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -1;
            }
            finally
            {
                objMsgUpdate.Dispose();
                objMsgUpdate = null;
            }
            if (lngRes < 0)
            {
                ContextUtil.SetAbort();
            }

            return lngRes;
        }
        #endregion

        #region 病人入院登记

        #region 入院登记主方法
        /// <summary>
        /// 入院登记主方法
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objParaVo">参数VO</param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="p_objPay">预交金信息</param>
        /// <param name="objBIHVO">病人住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPatientRegister(System.Security.Principal.IPrincipal p_objPrincipal, clsRegisterParameterVO p_objParaVo, clsPatient_VO objPatientVO, clsT_opr_bih_prepay_VO p_objPay, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngPatientRegister");
            if (lngRes < 0)
            {
                return -1;
            }
            if (objBIHVO.m_strINPATIENTID_CHR == "")
            {
                return -2;
            }

            // 1.判断当前病人是否在院与获取入院次数
            clsBIHpatientVO p_objBIHpatientVO;
            lngRes = m_lngGetLatestInHospitalInfo(p_objPrincipal, objBIHVO.m_strPATIENTID_CHR, objBIHVO.m_intINPATIENTNOTYPE_INT, out p_objBIHpatientVO);
            if (lngRes > 0)
            {
                if (Convert.ToInt16(p_objBIHpatientVO.m_strPSTATUS_INT) > 0)
                {
                    return -3;  //该病人已经入院
                }
                else if (p_objBIHpatientVO.m_strINPATIENTCOUNT_INT != "")
                {
                    objBIHVO.m_intINPATIENTCOUNT_INT = Convert.ToInt16(p_objBIHpatientVO.m_strINPATIENTCOUNT_INT);
                }
                else
                {
                    objBIHVO.m_intINPATIENTCOUNT_INT = 1;
                }
            }

            if (p_objParaVo.m_intIsNewPatient == 1) // 新病人(没有基本资料)
            {
                // 病人资料登记(相当于门诊病人资料登记)
                string p_strPatientID;
                m_lngPatientBaseInfoRegist(p_objPrincipal, objPatientVO, out p_strPatientID);
                objBIHVO.m_strPATIENTID_CHR = p_strPatientID;
            }
            else //旧病人(已有基本资料)
            {
                // 2、修改病人基本资料
                lngRes = m_lngModifyPatientInfo(p_objPrincipal, objPatientVO);
                if (lngRes < 1)
                {
                    throw new Exception("修改病人基本资料失败！");
                }

                lngRes = m_lngModifyPatientIdx(p_objPrincipal, objPatientVO);
                if (lngRes < 1)
                {
                    throw new Exception("修改病人基本资料失败！");
                }
            }

            // 3、新增入院登记记录
            objBIHVO.m_strMODIFY_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strRegisterID = "";
            if (p_objParaVo.m_intFlag == 1)
            {
                lngRes = m_lngAddNewRegisterByInpatientID(p_objPrincipal, out strRegisterID, objBIHVO);
                if (lngRes < 1)
                {
                    throw new Exception("0"); //新增入院登记记录时失败,可能住院已被占用！
                }
            }
            else
            {
                lngRes = m_lngAddNewRegister(p_objPrincipal, out strRegisterID, objBIHVO);
                if (lngRes < 1)
                {
                    throw new Exception("增新增入院登记记录时失败！");
                }
            }
            objBIHVO.m_strREGISTERID_CHR = strRegisterID;
            objPatientVO.m_strPATIENTID_CHR = strRegisterID;
            p_objPay.m_strREGISTERID_CHR = strRegisterID;

            // 4、新增入院登记病人基本信息
            lngRes = m_lngAddRegisterDetail(p_objPrincipal, objPatientVO);
            if (lngRes < 1)
            {
                throw new Exception("新增入院登记病人基本信息时失败！");
            }

            // 5、新增住院号关系记录
            lngRes = m_lngAddNewHisEmrRrelation(p_objPrincipal, objBIHVO);
            if (lngRes < 1)
            {
                throw new Exception("新增住院号关系记录时失败！");
            }

            // 6、增加调转信息
            clsT_Opr_Bih_Transfer_VO objTransferVO;
            m_mthCreatTransferVO(objBIHVO, out objTransferVO);
            lngRes = m_lngAddTransFast(p_objPrincipal, objTransferVO);
            if (lngRes < 1)
            {
                throw new Exception("增加调转信息失败！");
            }

            // 7、新增预交金
            if (p_objPay.m_dblMONEY_DEC > 0)
            {
                string p_strPrePayID;
                lngRes = m_lngAddNewPrePay(p_objPrincipal, p_objPay, out p_strPrePayID);
                objBIHVO.m_strBEDID_CHR = p_strPrePayID;
                if (lngRes < 1)
                {
                    throw new Exception("新增预交金失败！");
                }
            }

            // 8、修改最大住院号
            if (p_objParaVo.m_intFlag == 1)
            {
                clsBeINpatientNOSvc m_objInNoSvc = new clsBeINpatientNOSvc();
                lngRes = m_objInNoSvc.m_lngAddBigIDTableMax(p_objPrincipal, objBIHVO.m_intINPATIENTNOTYPE_INT, p_objParaVo.m_strHeardFlag, objBIHVO.m_strINPATIENTID_CHR, p_objParaVo.m_intSourse);
                if (lngRes < 1)
                {
                    throw new Exception("修改最大住院号失败！");
                }
            }

            //9、新增病情记录
            lngRes = AddNewPatientState(p_objPrincipal, objBIHVO);
            if (lngRes < 1)
            {
                throw new Exception("新增病情记录失败！");
            }

            return lngRes;
        }
        #endregion

        #region  2.修改病人基本信息
        /// <summary>
        /// 2.修改病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyPatientInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyPatientInfo");
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
       patientsources_vchr=?,
       consigneeaddr = ? 
 WHERE patientid_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(43, out objLisAddItemRefArr);
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
                objLisAddItemRefArr[24].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR; // p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
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
                objLisAddItemRefArr[40].Value = p_objRecord.m_strPatientSource;
                objLisAddItemRefArr[41].Value = p_objRecord.ConsigneeAddr;
                objLisAddItemRefArr[42].Value = p_objRecord.m_strPATIENTID_CHR;

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

        #region 3.新增入院登记
        /// <summary>
        /// 3.新增入院登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">入院登记ID</param>
        /// <param name="p_objRecord">住院信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewRegister(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsT_Opr_Bih_Register_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewRegister");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            lngRes = objHRPSvc.m_lngGenerateNewID("T_Opr_Bih_Register", "registerid_chr", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"INSERT INTO t_opr_bih_register
            (registerid_chr, modify_dat, patientid_chr, isbooking_int,
             inpatientid_chr, inpatient_dat, deptid_chr, areaid_chr,
             bedid_chr, type_int, diagnose_vchr, limitrate_mny,
             inpatientcount_int, state_int, status_int, operatorid_chr,
             pstatus_int, casedoctor_chr, des_vchr, inpatientnotype_int,
             mzdoctor_chr, mzdiagnose_vchr, diagnoseid_chr, icd10diagid_vchr,
             icd10diagtext_vchr, clinicsayprepay, paytypeid_chr, CASEDOCTORDEPT_CHR
            )
     VALUES (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(28, out objLisAddItemRefArr);
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
                objLisAddItemRefArr[27].Value = p_objRecord.m_strCaseDoctorDept;

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

        #region 3.新住院号病人入院登记
        /// <summary>
        /// 3.新住院号病人入院登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">流水号 [out 参数]</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewRegisterByInpatientID(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsT_Opr_Bih_Register_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewRegisterByInpatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            lngRes = objHRPSvc.m_lngGenerateNewID("T_Opr_Bih_Register", "registerid_chr", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"INSERT INTO t_opr_bih_register
            (registerid_chr, modify_dat, patientid_chr, isbooking_int,
             inpatientid_chr, inpatient_dat, deptid_chr, areaid_chr,
             bedid_chr, type_int, diagnose_vchr, limitrate_mny,
             inpatientcount_int, state_int, status_int, operatorid_chr,
             pstatus_int, casedoctor_chr, des_vchr, inpatientnotype_int,
             mzdoctor_chr, mzdiagnose_vchr, diagnoseid_chr, icd10diagid_vchr,
             icd10diagtext_vchr, clinicsayprepay, paytypeid_chr, CASEDOCTORDEPT_CHR,
             relateregisterid_chr, bornnum_int, isshunchan)
     SELECT ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?
     FROM DUAL
    WHERE NOT EXISTS (
                     SELECT 2
                       FROM t_opr_bih_register t1
                      WHERE t1.status_int = 1
                            AND t1.inpatientid_chr = ?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(32, out objLisAddItemRefArr);
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
                objLisAddItemRefArr[23].Value = p_objRecord.m_strDIAGNOSE_VCHR;

                objLisAddItemRefArr[24].Value = p_objRecord.m_strICD10DIAGTEXT_VCHR;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCLINICSAYPREPAY;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strPAYTYPEID_CHR;
                objLisAddItemRefArr[27].Value = p_objRecord.m_strCaseDoctorDept;

                objLisAddItemRefArr[28].Value = p_objRecord.m_strRELATEREGISTERID_CHR;
                objLisAddItemRefArr[29].Value = p_objRecord.m_intBORNNUM_INT;

                objLisAddItemRefArr[30].Value = p_objRecord.m_intIsShunchan;//是否顺产CS-472 (ID:13261)

                objLisAddItemRefArr[31].Value = p_objRecord.m_strINPATIENTID_CHR;

                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);


                #region NewEMR.Itf
                DataTable dt = null;
                string Sql = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = '6666' and t.status_int = 1";
                objHRPSvc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null && dt.Rows.Count > 0 && 1 != 1)  // 2018-01-15 暂停使用
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

        #region 4.新增入院登记病人基本信息
        /// <summary>
        /// 4.新增入院登记病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">病人基本信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddRegisterDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddRegisterDetail");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"INSERT INTO t_opr_bih_registerdetail a
            (a.registerid_chr, a.lastname_vchr, a.idcard_chr, a.married_chr,
             a.birthplace_vchr, a.homeaddress_vchr, a.sex_chr,
             a.nationality_vchr, a.firstname_vchr, a.birth_dat, a.race_vchr,
             a.nativeplace_vchr, a.occupation_vchr, a.name_vchr,
             a.homephone_vchr, a.officephone_vchr, a.insuranceid_vchr,
             a.mobile_chr, a.officeaddress_vchr, a.employer_vchr,
             a.officepc_vchr, a.homepc_chr, a.email_vchr,
             a.contactpersonfirstname_vchr, a.contactpersonlastname_vchr,
             a.contactpersonaddress_vchr, a.contactpersonphone_vchr,
             a.contactpersonpc_chr, a.patientrelation_vchr, a.firstdate_dat,
             a.isemployee_int, a.status_int, a.operatorid_chr, a.modify_dat,
             a.govcard_chr, a.bloodtype_chr, a.ifallergic_int, a.allergicdesc_vchr, 
             a.insuredtotalmoney_mny, a.insuredpaytime_int, a.insuredpaymoney_mny, a.residenceplace_vchr, a.consigneeaddr   
            )
     VALUES (?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?,
             ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?, ?  
            )";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(43, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strLASTNAME_VCHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strIDCARD_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strMARRIED_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strBIRTHPLACE_VCHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strHOMEADDRESS_VCHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strSEX_CHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strNATIONALITY_VCHR;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strFIRSTNAME_VCHR;
                objLisAddItemRefArr[9].Value = Convert.ToDateTime(p_objRecord.m_strBIRTH_DAT);
                objLisAddItemRefArr[10].Value = p_objRecord.m_strRACE_VCHR;
                objLisAddItemRefArr[11].Value = p_objRecord.m_strNATIVEPLACE_VCHR;
                objLisAddItemRefArr[12].Value = p_objRecord.m_strOCCUPATION_VCHR;
                objLisAddItemRefArr[13].Value = p_objRecord.m_strNAME_VCHR;
                objLisAddItemRefArr[14].Value = p_objRecord.m_strHOMEPHONE_VCHR;
                objLisAddItemRefArr[15].Value = p_objRecord.m_strOFFICEPHONE_VCHR;
                objLisAddItemRefArr[16].Value = p_objRecord.m_strINSURANCEID_VCHR;
                objLisAddItemRefArr[17].Value = p_objRecord.m_strMOBILE_CHR;
                objLisAddItemRefArr[18].Value = p_objRecord.m_strOFFICEADDRESS_VCHR;
                objLisAddItemRefArr[19].Value = p_objRecord.m_strEMPLOYER_VCHR;
                objLisAddItemRefArr[20].Value = p_objRecord.m_strOFFICEPC_VCHR;
                objLisAddItemRefArr[21].Value = p_objRecord.m_strHOMEPC_CHR;
                objLisAddItemRefArr[22].Value = p_objRecord.m_strEMAIL_VCHR;
                objLisAddItemRefArr[23].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR;
                objLisAddItemRefArr[24].Value = p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCONTACTPERSONADDRESS_VCHR;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strCONTACTPERSONPHONE_VCHR;
                objLisAddItemRefArr[27].Value = p_objRecord.m_strCONTACTPERSONPC_CHR;
                objLisAddItemRefArr[28].Value = p_objRecord.m_strPATIENTRELATION_VCHR;
                objLisAddItemRefArr[29].Value = Convert.ToDateTime(p_objRecord.m_strFIRSTDATE_DAT);
                objLisAddItemRefArr[30].Value = p_objRecord.m_intISEMPLOYEE_INT;
                objLisAddItemRefArr[31].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[32].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[33].Value = Convert.ToDateTime(p_objRecord.m_strMODIFY_DAT);
                objLisAddItemRefArr[34].Value = p_objRecord.m_strGOVCARD_CHR;
                objLisAddItemRefArr[35].Value = p_objRecord.m_strBLOODTYPE_CHR;
                objLisAddItemRefArr[36].Value = p_objRecord.m_intIFALLERGIC_INT;
                objLisAddItemRefArr[37].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[38].Value = p_objRecord.m_decInsuredMoney;
                objLisAddItemRefArr[39].Value = p_objRecord.m_decInsuredPayTime;
                objLisAddItemRefArr[40].Value = p_objRecord.m_decInsuredPayMoney;
                objLisAddItemRefArr[41].Value = p_objRecord.m_strResidencePlace;
                objLisAddItemRefArr[42].Value = p_objRecord.ConsigneeAddr;

                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 5.新增住院号关系记录
        /// <summary>
        /// 5.新增住院号关系记录 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">住院信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewHisEmrRrelation(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Register_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc", "m_lngAddNewHisEmrRrelation");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"INSERT INTO t_bse_hisemr_relation
            (registerid_chr, emrinpatientid, emrinpatientdate,
             hisinpatientid_chr, hisinpatientdate, operatorid_chr, operat_dat
            )
     VALUES (?, ?, ?,
             ?, ?, ?, ?
            )";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;//p_objRecord.m_strPREPAYID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[2].Value = Convert.ToDateTime(p_objRecord.m_strMODIFY_DAT);
                objLisAddItemRefArr[3].Value = p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[4].Value = Convert.ToDateTime(p_objRecord.m_strINPATIENT_DAT);
                objLisAddItemRefArr[5].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[6].Value = Convert.ToDateTime(strDateTime);
                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 6.新增调转记录
        /// <summary>
        /// 生成调转VO
        /// </summary>
        /// <param name="objBIHVO">住院信息VO</param>
        /// <param name="objPatientVO">调转VO</param>
        [AutoComplete]
        public void m_mthCreatTransferVO(clsT_Opr_Bih_Register_VO objBIHVO, out clsT_Opr_Bih_Transfer_VO objPatientVO)
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
        /// <summary>
        /// 6.新增调转记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddTransFast(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            string p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewBinTransfer");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //lngRes = 0;
            //lngRes = objHRPSvc.m_lngGenerateNewID("t_opr_bih_transfer", "transferid_chr", 12, out p_strRecordID);

            p_strRecordID = GetNextSeq("seq_opr_bih_transfer");
            p_strRecordID = p_strRecordID.PadLeft(12, '0');

            if (lngRes < 0)
                return lngRes;

            string strSQL = @"INSERT INTO t_opr_bih_transfer
            (transferid_chr, sourcedeptid_chr, sourceareaid_chr,
             sourcebedid_chr, targetdeptid_chr, targetareaid_chr,
             targetbedid_chr, type_int, des_vchr, operatorid_chr,
             registerid_chr, modify_dat
            )
     VALUES (?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?
            )";
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
                objLisAddItemRefArr[11].Value = DateTime.Now;
                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 7.新增预交金收费
        /// <summary>
        /// 7.新增预交金收费
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewPrePay(System.Security.Principal.IPrincipal p_objPrincipal, clsT_opr_bih_prepay_VO p_objRecord, out string p_strRecordID)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc", "m_lngAddNewPrePay");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGenerateID(12, "PREPAYID_CHR", "T_opr_bih_prepay", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;

            p_strRecordID = GetNextSeq("seq_prepayid");
            p_strRecordID = p_strRecordID.PadLeft(12, '0');

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"INSERT INTO t_opr_bih_prepay
            (prepayid_chr, patientid_chr, registerid_chr, liner_int,
             paytype_int, cuycate_int, money_dec, prepayinv_vchr, areaid_chr,
             des_vchr, creatorid_chr, create_dat, status_int, isclear_int,
             pressno_vchr, uptype_int, patientname_chr, areaname_vchr,
             balanceflag_int
            )
     VALUES (?, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(19, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;//p_objRecord.m_strPREPAYID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_intLINER_INT;
                objLisAddItemRefArr[4].Value = p_objRecord.m_intPAYTYPE_INT;
                objLisAddItemRefArr[5].Value = p_objRecord.m_intCUYCATE_INT;
                objLisAddItemRefArr[6].Value = p_objRecord.m_dblMONEY_DEC;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strPREPAYINV_VCHR;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strAREAID_CHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strDES_VCHR;
                objLisAddItemRefArr[10].Value = p_objRecord.m_strCREATORID_CHR;
                objLisAddItemRefArr[11].Value = DateTime.Parse(strDateTime);//DateTime.Parse(p_objRecord.m_strCREATE_DAT);
                objLisAddItemRefArr[12].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[13].Value = p_objRecord.m_intISCLEAR_INT;
                objLisAddItemRefArr[14].Value = p_objRecord.m_strPRESSNO_VCHR;
                objLisAddItemRefArr[15].Value = p_objRecord.m_intUPTYPE_INT;
                objLisAddItemRefArr[16].Value = p_objRecord.m_strPatientName;
                objLisAddItemRefArr[17].Value = p_objRecord.m_strAreaName;
                objLisAddItemRefArr[18].Value = p_objRecord.m_intBALANCEFLAG_INT;
                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 9.新增病情记录
        /// <summary>
        /// 新增病情记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">住院信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long AddNewPatientState(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Register_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc", "m_lngAddNewHisEmrRrelation");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"INSERT INTO T_OPR_BIH_PATIENTSTATE
                                        (SEQID_INT, REGISTERID_CHR, STATE_INT, ACTIVE_DAT, OPERATORID_CHR )
                                 VALUES (SEQ_PATIENTSTATE.nextval, ?, ?, sysdate, ? )";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;//p_objRecord.m_strPREPAYID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_intSTATE_INT;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strOPERATORID_CHR;

                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 婴儿入院登记
        /// <summary>
        /// 婴儿入院登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="objBIHVO">病人住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBabyRegister(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngBabyRegister");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                string newPatientId = string.Empty;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService svc = new clsHRPTableService();
                svc.m_lngGenerateNewID("T_BSE_PATIENTIDX", "PATIENTID_CHR", out newPatientId);
                objBIHVO.m_strPATIENTID_CHR = newPatientId;

                // 1、新增入院登记记录
                objBIHVO.m_strMODIFY_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objBIHVO.m_strINAREADATE_DAT = objBIHVO.m_strMODIFY_DAT;
                objBIHVO.m_strINPATIENT_DAT = objBIHVO.m_strMODIFY_DAT;
                string strRegisterID = "";
                lngRes = m_lngAddNewRegisterByInpatientID(p_objPrincipal, out strRegisterID, objBIHVO);
                if (lngRes < 1)
                {
                    return -3; //新增入院登记记录时失败,可能住院已被占用！
                }

                objBIHVO.m_strREGISTERID_CHR = strRegisterID;
                objPatientVO.m_strPATIENTID_CHR = strRegisterID;
                //objPatientVO.strMaritalStatus = "";
                objPatientVO.m_strIDCARD_CHR = "";
                objPatientVO.m_strMARRIED_CHR = "";
                objPatientVO.m_strPATIENTRELATION_VCHR = "";


                // 2、新增入院登记病人基本信息
                lngRes = m_lngAddRegisterDetail(p_objPrincipal, objPatientVO);
                if (lngRes < 1)
                {
                    throw new Exception("新增入院登记病人基本信息时失败！");
                }

                // 3、新增住院号关系记录
                lngRes = m_lngAddNewHisEmrRrelation(p_objPrincipal, objBIHVO);
                if (lngRes < 1)
                {
                    throw new Exception("新增住院号关系记录时失败！");
                }

                // 4、增加调转信息
                clsT_Opr_Bih_Transfer_VO objTransferVO;
                m_mthCreatTransferVO(objBIHVO, out objTransferVO);
                lngRes = m_lngAddTransFast(p_objPrincipal, objTransferVO);
                if (lngRes < 1)
                {
                    throw new Exception("增加调转信息失败！");
                }

                #region 2018-01-15.补充基础信息 4张表
                string Sql = string.Empty;
                int n = -1;
                IDataParameter[] parm = null;
                objPatientVO.m_strPATIENTID_CHR = newPatientId;

                Sql = @"insert into t_bse_patientidx
                              (patientid_chr,
                               inpatientid_chr,
                               idcard_chr,
                               homeaddress_vchr,
                               sex_chr,
                               birth_dat,
                               name_vchr)
                            values
                              (?, ?, ?, ?, ?, ?, ?)";
                n = -1;
                svc.CreateDatabaseParameter(7, out parm);
                parm[++n].Value = objPatientVO.m_strPATIENTID_CHR;
                parm[++n].Value = objPatientVO.m_strINPATIENTID_CHR;
                parm[++n].Value = objPatientVO.m_strIDCARD_CHR;
                parm[++n].Value = objPatientVO.m_strHOMEADDRESS_VCHR;
                parm[++n].Value = objPatientVO.m_strSEX_CHR;
                parm[++n].Value = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT);
                parm[++n].Value = objPatientVO.m_strLASTNAME_VCHR;
                svc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                Sql = @"insert into t_bse_patient
                          (patientid_chr,
                           lastname_vchr,
                           sex_chr,
                           birth_dat,
                           nationality_vchr,
                           nativeplace_vchr,
                           birthplace_vchr,
                           idcard_chr,
                           occupation_vchr,
                           homeaddress_vchr,
                           homephone_vchr,
                           contactpersonfirstname_vchr,
                           contactpersonphone_vchr,
                           contactpersonaddress_vchr,
                           status_int,
                           firstname_vchr,
                           isemployee_int,
                           modify_dat)
                        values
                          (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
                           ?, ?, ?, ?, ?, ?, ?, ?)";

                n = -1;
                svc.CreateDatabaseParameter(18, out parm);
                parm[++n].Value = objPatientVO.m_strPATIENTID_CHR;
                parm[++n].Value = objPatientVO.m_strLASTNAME_VCHR;
                parm[++n].Value = objPatientVO.m_strSEX_CHR;
                parm[++n].Value = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT);
                parm[++n].Value = objPatientVO.m_strNATIONALITY_VCHR;
                parm[++n].Value = objPatientVO.m_strNATIVEPLACE_VCHR;
                parm[++n].Value = objPatientVO.m_strBIRTHPLACE_VCHR;
                parm[++n].Value = objPatientVO.m_strIDCARD_CHR;
                parm[++n].Value = objPatientVO.m_strOCCUPATION_VCHR;
                parm[++n].Value = objPatientVO.m_strHOMEADDRESS_VCHR;
                parm[++n].Value = objPatientVO.m_strHOMEPHONE_VCHR;
                parm[++n].Value = objPatientVO.m_strCONTACTPERSONLASTNAME_VCHR;
                parm[++n].Value = objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
                parm[++n].Value = objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
                parm[++n].Value = 1;
                parm[++n].Value = objPatientVO.m_strLASTNAME_VCHR;
                parm[++n].Value = 0;
                parm[++n].Value = DateTime.Now;
                svc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                string cardNo = string.Empty;
                svc.m_lngGenerateNewID("T_BSE_PATIENTCARD", "PATIENTCARDID_CHR", out cardNo);
                Sql = @"insert into t_bse_patientcard
                          (patientcardid_chr, patientid_chr, issue_date, status_int)
                        values
                          (?, ?, ?, ?)";
                n = -1;
                svc.CreateDatabaseParameter(4, out parm);
                parm[++n].Value = cardNo;
                parm[++n].Value = objPatientVO.m_strPATIENTID_CHR;
                parm[++n].Value = DateTime.Now;
                parm[++n].Value = 3;    // 自动获取卡号
                svc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                Sql = @"insert into t_bse_patientidentityno
                          (patientid_chr, paytypeid_chr, idno_vchr)
                        values
                          (?, ?, ?)";

                n = -1;
                svc.CreateDatabaseParameter(3, out parm);
                parm[++n].Value = objPatientVO.m_strPATIENTID_CHR;
                parm[++n].Value = "0001";
                parm[++n].Value = string.Empty;
                svc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                #endregion
            }
            catch (Exception ex)
            {
                string strTmp = ex.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }
            return lngRes;
        }
        #endregion

        #region 修改婴儿入院登记
        /// <summary>
        /// 修改婴儿入院登记
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="objBIHVO">病人住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangeBabyRegister(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            string strSQL = string.Empty;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngChangeBabyRegister");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objBIHDataParam = null;
            IDataParameter[] objPatientDataParam = null;
            objHRPSvc.CreateDatabaseParameter(3, out objBIHDataParam);
            objHRPSvc.CreateDatabaseParameter(7, out objPatientDataParam);
            try
            {
                // 1、修改入院登记记录            
                strSQL = @"update t_opr_bih_register 
                              set paytypeid_chr = ?, isshunchan = ?
                           where registerid_chr = ?";
                //objBIHDataParam[0].Value = objBIHVO.m_intBORNNUM_INT;
                objBIHDataParam[0].Value = objBIHVO.m_strPAYTYPEID_CHR;
                objBIHDataParam[1].Value = objBIHVO.m_intIsShunchan;
                objBIHDataParam[2].Value = objBIHVO.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objBIHDataParam);

                // 2、修改入院登记病人基本信息
                strSQL = @"update t_opr_bih_registerdetail 
                              set lastname_vchr = ?,
                                  firstname_vchr = ?,
                                  name_vchr = ?,
                                  sex_chr = ?,
                                  birth_dat = ?,
                                  modify_dat = ?
                           where registerid_chr = ?";

                objPatientDataParam[0].Value = objPatientVO.m_strLASTNAME_VCHR;
                objPatientDataParam[1].Value = objPatientVO.m_strFIRSTNAME_VCHR;
                objPatientDataParam[2].Value = objPatientVO.m_strNAME_VCHR;
                objPatientDataParam[3].Value = objPatientVO.m_strSEX_CHR;
                objPatientDataParam[4].Value = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT);
                objPatientDataParam[4].DbType = DbType.Date;
                objPatientDataParam[5].Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                objPatientDataParam[5].DbType = DbType.Date;
                objPatientDataParam[6].Value = objBIHVO.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objPatientDataParam);
            }

            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion


        #region 撤消入院
        /// <summary>
        /// 撤消入院
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">病人住院信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCancleBeInHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsBIHpatientVO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngCancleBeInHospital");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                // 1.修改入院登记信息
                strSQL = @"UPDATE t_opr_bih_register t1
                           SET inpatientid_chr = ?,
                               status_int = -1,
                               des_vchr = ?,
                               CANCELERID_CHR = ?,
                               CANCEL_DAT = sysdate
                          WHERE registerid_chr = ? AND
                                t1.pstatus_int <> 3 AND
                                t1.status_int = 1";
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = "*" + p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strRemark;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strOpearID;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strREGISTERID_CHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes < 1)
                {
                    throw new Exception("修改住院登记信息失败(可能该病人已经出院)！");
                }

                // 2.修改床位表(如果在床的话)
                strSQL = @"UPDATE t_bse_bed t1
                           SET t1.status_int = 1,
                               t1.bihregisterid_chr = NULL
                           WHERE t1.bihregisterid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);

                // 3.撤消包床(如果存在包床的话)
                m_lngCancelWrapBed(p_objPrincipal, p_objRecord.m_strREGISTERID_CHR);

                // 4.修改住院号关系表 
                strSQL = @"UPDATE t_bse_hisemr_relation
                           SET hisinpatientid_chr = ?,
                               operatorid_chr = ?,
                               operat_dat = ?
                           WHERE registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = "*" + p_objRecord.m_strINPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strOpearID;
                objLisAddItemRefArr[2].Value = DateTime.Now;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strREGISTERID_CHR;
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes < 1)
                {
                    throw new Exception("修改住院号关系表失败！");
                }

                if (p_objRecord.m_strINPATIENTCOUNT_INT == "1")
                {
                    strSQL = @"select t.relateregisterid_chr
  from t_opr_bih_register t
 where t.registerid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                    DataTable dtbTemp = new DataTable();
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objLisAddItemRefArr);
                    if (lngRes > 0 && dtbTemp.Rows.Count > 0)
                    {
                        if (dtbTemp.Rows[0]["relateregisterid_chr"] == DBNull.Value)
                        {
                            // 5.同步病人基本信息表住院号
                            if (p_objRecord.m_strINPATIENTNOTYPE_INT == "1")
                            {
                                strSQL = @"UPDATE t_bse_patient
                                   SET inpatientid_chr = NULL
                                   WHERE patientid_chr = ?";
                            }
                            else
                            {
                                strSQL = @"UPDATE t_bse_patient
                                   SET inpatienttempid_vchr = NULL
                                   WHERE patientid_chr = ?";
                            }
                            objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                            //Please change the datetime and reocrdid 
                            objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                            objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                            if (lngRes < 1)
                            {
                                throw new Exception("同步病人基本信息表住院号失败！");
                            }
                            else
                            {
                                //消息处理
                                com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
                                try
                                {
                                    lngRes = objMsgUpdate.AddMsg("10001", 2, p_objRecord.m_strPATIENTID_CHR);
                                }
                                catch (Exception objEx)
                                {
                                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                                    bool blnRes = objLogger.LogError(objEx);
                                    lngRes = -1;
                                }
                                finally
                                {
                                    objMsgUpdate.Dispose();
                                    objMsgUpdate = null;
                                }
                                if (lngRes < 0)
                                {
                                    ContextUtil.SetAbort();
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("同步病人基本信息表住院号失败！");
                    }



                    // 6.首次入院则需退回住院号
                    clsBeINpatientNOSvc m_objInNoSvc = new clsBeINpatientNOSvc();
                    lngRes = m_objInNoSvc.m_lngAddBigIDTableHis(p_objPrincipal, Convert.ToInt16(p_objRecord.m_strINPATIENTNOTYPE_INT), p_objRecord.m_strINPATIENTID_CHR);
                }
                if (lngRes < 1)
                {
                    throw new Exception("处理住院号信息失败！");
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

        #region 获取住院收费类别
        /// <summary>
        /// 获取住院收费类别
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_GetBIHPatientType(System.Security.Principal.IPrincipal p_objPrincipal, out com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[] p_objResultArr)
        {
            p_objResultArr = new clsPatientPayTypeVO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_GetBIHPatientType");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   paytypeid_chr, paytypename_vchr, payflag_dec, bihlimitrate_dec,
         internalflag_int
    FROM t_bse_patientpaytype
   WHERE payflag_dec != 1 AND isusing_num != 0
ORDER BY paytypeid_chr";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsPatientPayTypeVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsPatientPayTypeVO();
                        p_objResultArr[i1].m_strPAYTYPEID_CHR = dtbResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPAYTYPENAME_VCHR = p_objResultArr[i1].m_strPAYTYPEID_CHR + "-" + dtbResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["PAYFLAG_DEC"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_intPAYFLAG_DEC = Convert.ToInt16(dtbResult.Rows[i1]["PAYFLAG_DEC"]);
                        }
                        if (dtbResult.Rows[i1]["BIHLIMITRATE_DEC"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_dblRECIPELIMIT_DEC = Convert.ToDouble(dtbResult.Rows[i1]["BIHLIMITRATE_DEC"]);
                        }
                        if (dtbResult.Rows[i1]["internalflag_int"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_intINTERNALFLAG_INT = Convert.ToInt16(dtbResult.Rows[i1]["internalflag_int"]);
                        }
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

        #region 获取病人身份类别
        /// <summary>
        /// 获取病人身份类别
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr">人身份类别</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_GetPatientType(System.Security.Principal.IPrincipal p_objPrincipal, out com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[] p_objResultArr)
        {
            p_objResultArr = new clsPatientPayTypeVO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_GetPatientType");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   paytypeid_chr, paytypename_vchr, payflag_dec, bihlimitrate_dec,
         internalflag_int
    FROM t_bse_patientpaytype
   WHERE payflag_dec != 2 AND isusing_num != 0
ORDER BY paytypeid_chr";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsPatientPayTypeVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsPatientPayTypeVO();
                        p_objResultArr[i1].m_strPAYTYPEID_CHR = dtbResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPAYTYPENAME_VCHR = p_objResultArr[i1].m_strPAYTYPEID_CHR + "-" + dtbResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["PAYFLAG_DEC"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_intPAYFLAG_DEC = Convert.ToInt16(dtbResult.Rows[i1]["PAYFLAG_DEC"]);
                        }
                        if (dtbResult.Rows[i1]["BIHLIMITRATE_DEC"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_dblRECIPELIMIT_DEC = Convert.ToDouble(dtbResult.Rows[i1]["BIHLIMITRATE_DEC"]);
                        }
                        if (dtbResult.Rows[i1]["internalflag_int"] != DBNull.Value)
                        {
                            p_objResultArr[i1].m_intINTERNALFLAG_INT = Convert.ToInt16(dtbResult.Rows[i1]["internalflag_int"]);
                        }
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

        #region 根据入院登记ID获取病人入院登记信息
        /// <summary>
        /// 根据入院登记ID获取病人入院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">根据入院登记ID</param>
        /// <param name="p_objResult">院登记信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisterInfoByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            p_objResult = new clsT_Opr_Bih_Register_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGet");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.registerid_chr, a.modify_dat, a.patientid_chr, a.isbooking_int,
                                   a.inpatientid_chr, a.inpatient_dat, a.deptid_chr, a.areaid_chr,
                                   a.bedid_chr, a.type_int, a.diagnose_vchr, a.limitrate_mny,
                                   a.inpatientcount_int, a.state_int, a.status_int, a.operatorid_chr,
                                   a.pstatus_int, a.casedoctor_chr, a.inpatientnotype_int, a.des_vchr,
                                   a.mzdoctor_chr, a.mzdiagnose_vchr, a.diagnoseid_chr, a.inareadate_dat,
                                   a.icd10diagid_vchr, a.icd10diagtext_vchr, a.isfromclinic,
                                   a.clinicsayprepay, a.paytypeid_chr,
                                   a.relateregisterid_chr, a.bornnum_int
                              FROM t_opr_bih_register a
                             WHERE a.registerid_chr = '" + p_strRegisterID + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    p_objResult.m_strMODIFY_DAT = dtbResult.Rows[0]["MODIFY_DAT"].ToString().Trim();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["ISBOOKING_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intISBOOKING_INT = Convert.ToInt16(dtbResult.Rows[0]["ISBOOKING_INT"]);
                    }
                    p_objResult.m_strINPATIENTID_CHR = dtbResult.Rows[0]["INPATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strINPATIENT_DAT = dtbResult.Rows[0]["INPATIENT_DAT"].ToString().Trim();
                    p_objResult.m_strDEPTID_CHR = dtbResult.Rows[0]["DEPTID_CHR"].ToString().Trim();
                    p_objResult.m_strAREAID_CHR = dtbResult.Rows[0]["AREAID_CHR"].ToString().Trim();
                    p_objResult.m_strBEDID_CHR = dtbResult.Rows[0]["BEDID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["TYPE_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intTYPE_INT = Convert.ToInt16(dtbResult.Rows[0]["TYPE_INT"]);
                    }
                    p_objResult.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["LIMITRATE_MNY"] != DBNull.Value)
                    {
                        p_objResult.m_dblLIMITRATE_MNY = Convert.ToDouble(dtbResult.Rows[0]["LIMITRATE_MNY"]);
                    }
                    if (dtbResult.Rows[0]["INPATIENTCOUNT_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intINPATIENTCOUNT_INT = Convert.ToInt16(dtbResult.Rows[0]["INPATIENTCOUNT_INT"]);
                    }
                    if (dtbResult.Rows[0]["STATE_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intSTATE_INT = Convert.ToInt16(dtbResult.Rows[0]["STATE_INT"]);
                    }
                    if (dtbResult.Rows[0]["STATUS_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intSTATUS_INT = Convert.ToInt16(dtbResult.Rows[0]["STATUS_INT"]);
                    }
                    p_objResult.m_strOPERATORID_CHR = dtbResult.Rows[0]["OPERATORID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["PSTATUS_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intPSTATUS_INT = Convert.ToInt16(dtbResult.Rows[0]["PSTATUS_INT"]);
                    }
                    p_objResult.m_strCASEDOCTOR_CHR = dtbResult.Rows[0]["CASEDOCTOR_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["INPATIENTNOTYPE_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intINPATIENTNOTYPE_INT = Convert.ToInt16(dtbResult.Rows[0]["INPATIENTNOTYPE_INT"]);
                    }
                    p_objResult.DES_VCHR = dtbResult.Rows[0]["DES_VCHR"].ToString().Trim();
                    p_objResult.m_strMZDOCTOR_CHR = dtbResult.Rows[0]["MZDOCTOR_CHR"].ToString().Trim();
                    p_objResult.m_strMZDIAGNOSE_VCHR = dtbResult.Rows[0]["MZDIAGNOSE_VCHR"].ToString().Trim();
                    p_objResult.m_strDIAGNOSEID_CHR = dtbResult.Rows[0]["DIAGNOSEID_CHR"].ToString().Trim();
                    p_objResult.m_strINAREADATE_DAT = dtbResult.Rows[0]["INAREADATE_DAT"].ToString().Trim();
                    p_objResult.m_strICD10DIAGID_VCHR = dtbResult.Rows[0]["ICD10DIAGID_VCHR"].ToString().Trim();
                    p_objResult.m_strICD10DIAGTEXT_VCHR = dtbResult.Rows[0]["ICD10DIAGTEXT_VCHR"].ToString().Trim();
                    p_objResult.m_intISFROMCLINIC = dtbResult.Rows[0]["ISFROMCLINIC"].ToString().Trim();
                    p_objResult.m_strCLINICSAYPREPAY = dtbResult.Rows[0]["CLINICSAYPREPAY"].ToString().Trim();
                    p_objResult.m_strPAYTYPEID_CHR = dtbResult.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    p_objResult.m_strRELATEREGISTERID_CHR = dtbResult.Rows[0]["RELATEREGISTERID_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["BORNNUM_INT"] != DBNull.Value)
                    {
                        p_objResult.m_intBORNNUM_INT = Convert.ToInt16(dtbResult.Rows[0]["BORNNUM_INT"]);
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

        #region 根据关联入院登记ID获取婴儿入院登记信息
        /// <summary>
        /// 根据关联入院登记ID获取婴儿入院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">根据入院登记ID</param>
        /// <param name="p_objResult">院登记信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBabyRegisterInfoByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRelateRegisterID, int p_intBornNum, out DataTable dtbBabyInfo)
        {
            long lngRes = 0;
            dtbBabyInfo = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBabyRegisterInfoByID");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select
                                a.registerid_chr,a.isshunchan,
                                a.paytypeid_chr,
                                b.lastname_vchr,
                                b.sex_chr,
                                b.birth_dat
                              from t_opr_bih_register a,
                                   t_opr_bih_registerdetail b
                              where a.registerid_chr = b.registerid_chr
                                and a.relateregisterid_chr = ?
                                and a.bornnum_int = ?";
            try
            {
                IDataParameter[] objValueParam = null;
                objHRPSvc.CreateDatabaseParameter(2, out objValueParam);
                objValueParam[0].Value = p_strRelateRegisterID;
                objValueParam[1].Value = p_intBornNum;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbBabyInfo, objValueParam);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据关联入院登记ID获取婴儿胎次
        /// <summary>
        /// 根据关联入院登记ID获取婴儿胎次
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">根据入院登记ID</param>
        /// <param name="p_objResult">院登记信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBabyBornNumByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRelateRegisterID, ref int p_intBornNum)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBabyBornNumByID");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select 
                                 count(t.bornnum_int) bornnum_int from t_opr_bih_register t
                               where t.relateregisterid_chr = ?";
            try
            {
                IDataParameter[] objValueParam = null;
                objHRPSvc.CreateDatabaseParameter(1, out objValueParam);
                objValueParam[0].Value = p_strRelateRegisterID;
                DataTable dtbBabyInfo = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbBabyInfo, objValueParam);
                if (lngRes > 0)
                {
                    if (dtbBabyInfo.Rows.Count > 0)
                    {
                        p_intBornNum = Convert.ToInt32(dtbBabyInfo.Rows[0]["bornnum_int"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRelateRegisterID"></param>
        /// <param name="arrBornNum"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBabyBornNumByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRelateRegisterID, ref ArrayList arrBornNum)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBabyBornNumByID");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @" select   count (t.bornnum_int) bornnum_int, t.bornnum_int as bornnum
                                        from t_opr_bih_register t
                                       where t.relateregisterid_chr = ?
                                    group by t.bornnum_int ";
            try
            {
                IDataParameter[] objValueParam = null;
                objHRPSvc.CreateDatabaseParameter(1, out objValueParam);
                objValueParam[0].Value = p_strRelateRegisterID;
                DataTable dtbBabyInfo = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbBabyInfo, objValueParam);

                if (lngRes > 0)
                {
                    for (int i1 = 0; i1 < dtbBabyInfo.Rows.Count; i1++)
                    {
                        arrBornNum.Add(dtbBabyInfo.Rows[i1]["bornnum"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }

        #endregion


        #region 根据ID号获取住院系统设置
        /// <summary>
        /// 根据ID号获取住院系统设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSetingID">系统设置ID号</param>
        /// <param name="p_intSetstatus">状态</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSetingByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSetingID, out int p_intSetstatus)
        {
            p_intSetstatus = -1;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetSetingByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT t1.setstatus_int
  FROM t_sys_setting t1
 WHERE t1.setid_chr = '" + p_strSetingID + "' and t1.moduleid_chr = '0010'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (dtbResult.Rows[0]["setstatus_int"] != DBNull.Value)
                    {
                        p_intSetstatus = Convert.ToInt16(dtbResult.Rows[0]["setstatus_int"]);
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


        // 修改入院登记资料
        #region 根据病人ID获取病人入院登记信息(用于修改登记资料)
        /// <summary>
        /// 根据病人ID获取病人入院登记信息(用于修改登记资料)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_objResult">入院登记信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisterInfoByPatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            p_objResult = new clsT_Opr_Bih_Register_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetRegisterInfoByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select   t1.registerid_chr, t1.inpatientnotype_int, t1.inpatientid_chr,
                                       t1.inpatient_dat, t1.type_int, t1.areaid_chr,
                                       t2.deptname_vchr AS areaname, t4.code_chr, t1.mzdoctor_chr,
                                       t3.lastname_vchr AS mzdoctormane, t1.state_int, t1.limitrate_mny,
                                       t1.mzdiagnose_vchr, t1.des_vchr, t1.pstatus_int, t1.paytypeid_chr,
                                       inpatientcount_int
                                  from t_opr_bih_register t1,
                                       t_bse_deptdesc t2,
                                       t_bse_employee t3,
                                       t_bse_bed t4
    
                                       --(select * from t_opr_bih_patientstate where active_int = 1) t5
                                 where t1.areaid_chr = t2.deptid_chr(+) and
                                    t1.mzdoctor_chr = t3.empid_chr(+) and
                                    t1.bedid_chr = t4.bedid_chr(+) and
                                  -- t1.registerid_chr = t5.registerid_chr(+) and
                                  -- t5.active_int = 1 and
                                    t1.pstatus_int <> 3 and
                                    t1.status_int = 1 and
                                    t1.patientid_chr = ? ";
            try
            {
                DataTable dtbResult = new DataTable();

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strPatientID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["registerid_chr"].ToString().Trim();
                    p_objResult.m_intINPATIENTNOTYPE_INT = Convert.ToInt16(dtbResult.Rows[0]["inpatientnotype_int"]);
                    p_objResult.m_strINPATIENTID_CHR = dtbResult.Rows[0]["inpatientid_chr"].ToString().Trim();
                    p_objResult.m_strINPATIENT_DAT = dtbResult.Rows[0]["inpatient_dat"].ToString().Trim();
                    p_objResult.m_intTYPE_INT = Convert.ToInt16(dtbResult.Rows[0]["type_int"]);
                    p_objResult.m_strAREAID_CHR = dtbResult.Rows[0]["areaid_chr"].ToString().Trim();
                    p_objResult.m_strAreaName = dtbResult.Rows[0]["areaname"].ToString().Trim();
                    p_objResult.m_strBedNo = dtbResult.Rows[0]["code_chr"].ToString().Trim();
                    p_objResult.m_strMZDOCTOR_CHR = dtbResult.Rows[0]["mzdoctor_chr"].ToString().Trim();
                    p_objResult.m_stroutdoctorname = dtbResult.Rows[0]["mzdoctormane"].ToString().Trim();

                    if (dtbResult.Rows[0]["state_int"] != DBNull.Value)
                    {
                        p_objResult.m_intSTATE_INT = Convert.ToInt16(dtbResult.Rows[0]["state_int"]);
                    }

                    if (dtbResult.Rows[0]["limitrate_mny"] != DBNull.Value)
                    {
                        p_objResult.m_dblLIMITRATE_MNY = Convert.ToDouble(dtbResult.Rows[0]["limitrate_mny"]);
                    }
                    p_objResult.m_strMZDIAGNOSE_VCHR = dtbResult.Rows[0]["mzdiagnose_vchr"].ToString().Trim();
                    p_objResult.DES_VCHR = dtbResult.Rows[0]["des_vchr"].ToString().Trim();
                    p_objResult.m_intPSTATUS_INT = Convert.ToInt16(dtbResult.Rows[0]["pstatus_int"]);
                    p_objResult.m_strPAYTYPEID_CHR = dtbResult.Rows[0]["paytypeid_chr"].ToString().Trim();
                    p_objResult.m_intINPATIENTCOUNT_INT = Convert.ToInt16(dtbResult.Rows[0]["inpatientcount_int"]);
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
        /// 根据入院登号获取病人入院登记信息(用于修改登记资料)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisterInfoByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out clsT_Opr_Bih_Register_VO p_objRegisterVo)
        {
            p_objRegisterVo = new clsT_Opr_Bih_Register_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetRegisterInfoByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select t1.registerid_chr,
                                       t1.inpatientnotype_int,
                                       t1.inpatientid_chr,
                                       t1.inpatient_dat,
                                       t1.type_int,
                                       t1.areaid_chr,
                                       t2.deptname_vchr as areaname,
                                       t4.code_chr,
                                       t1.mzdoctor_chr,
                                       t3.lastname_vchr as mzdoctormane,
                                       t1.state_int,
                                       t1.limitrate_mny,
                                       t1.mzdiagnose_vchr,
                                       t1.des_vchr,
                                       t1.pstatus_int,
                                       t1.paytypeid_chr,
                                       inpatientcount_int
                                  from t_opr_bih_register t1,
                                       t_bse_deptdesc     t2,
                                       t_bse_employee     t3,
                                       t_bse_bed          t4
                                 where t1.areaid_chr = t2.deptid_chr(+)
                                   and t1.mzdoctor_chr = t3.empid_chr(+)
                                   and t1.bedid_chr = t4.bedid_chr(+)
                                   and t1.status_int = 1
                                   and t1.registerid_chr = ? ";
            try
            {
                DataTable dtbResult = new DataTable();

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] ParmArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParmArr);
                ParmArr[0].Value = p_strRegisterID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParmArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                DataRow oneRow = null;
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    oneRow = dtbResult.Rows[0];

                    p_objRegisterVo.m_strREGISTERID_CHR = oneRow["registerid_chr"].ToString().Trim();
                    p_objRegisterVo.m_intINPATIENTNOTYPE_INT = Convert.ToInt16(oneRow["inpatientnotype_int"]);
                    p_objRegisterVo.m_strINPATIENTID_CHR = oneRow["inpatientid_chr"].ToString().Trim();
                    p_objRegisterVo.m_strINPATIENT_DAT = oneRow["inpatient_dat"].ToString().Trim();
                    p_objRegisterVo.m_intTYPE_INT = Convert.ToInt16(oneRow["type_int"]);
                    p_objRegisterVo.m_strAREAID_CHR = oneRow["areaid_chr"].ToString().Trim();
                    p_objRegisterVo.m_strAreaName = oneRow["areaname"].ToString().Trim();
                    p_objRegisterVo.m_strBedNo = oneRow["code_chr"].ToString().Trim();
                    p_objRegisterVo.m_strMZDOCTOR_CHR = oneRow["mzdoctor_chr"].ToString().Trim();
                    p_objRegisterVo.m_stroutdoctorname = oneRow["mzdoctormane"].ToString().Trim();

                    if (dtbResult.Rows[0]["state_int"] != DBNull.Value)
                    {
                        p_objRegisterVo.m_intSTATE_INT = Convert.ToInt16(oneRow["state_int"]);
                    }

                    if (dtbResult.Rows[0]["limitrate_mny"] != DBNull.Value)
                    {
                        p_objRegisterVo.m_dblLIMITRATE_MNY = Convert.ToDouble(oneRow["limitrate_mny"]);
                    }
                    p_objRegisterVo.m_strMZDIAGNOSE_VCHR = oneRow["mzdiagnose_vchr"].ToString().Trim();
                    p_objRegisterVo.DES_VCHR = oneRow["des_vchr"].ToString().Trim();
                    p_objRegisterVo.m_intPSTATUS_INT = Convert.ToInt16(oneRow["pstatus_int"]);
                    p_objRegisterVo.m_strPAYTYPEID_CHR = oneRow["paytypeid_chr"].ToString().Trim();
                    p_objRegisterVo.m_intINPATIENTCOUNT_INT = Convert.ToInt16(oneRow["inpatientcount_int"]);
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

        #region 修改入院登记资料
        /// <summary>
        /// 修改入院登记资料
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intFlag">操作标识:0-不用修改调转表,1-需修改调转表</param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="p_objRegisterVO">入院登记信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngEditRegister(System.Security.Principal.IPrincipal p_objPrincipal, int p_intFlag, clsPatient_VO p_objPatientVO, clsT_Opr_Bih_Register_VO p_objRegisterVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngEditRegister");
            if (lngRes < 0)
            {
                return -1;
            }

            string Sql = string.Empty;
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();

            // 检验判断-如果存在已发报告，则不允许修改 (2019-05-29)
            Sql = @"select 1 from t_opr_lis_sample a where a.patientid_chr = '{0}' and a.patient_inhospitalno_chr = '{1}' and a.status_int = 6";
            svc.lngGetDataTableWithoutParameters(string.Format(Sql, p_objPatientVO.m_strPATIENTID_CHR, p_objPatientVO.m_strINPATIENTID_CHR), ref dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                (new clsLogText()).LogError(string.Format("住院号 = {0} 检验报告已出，不允许修改病人基本资料。", p_objPatientVO.m_strINPATIENTID_CHR));
                return -1;
            }

            // 1、修改病人基本资料
            p_objPatientVO.m_strMODIFY_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lngRes = m_lngModifyPatientInfo(p_objPrincipal, p_objPatientVO);
            if (lngRes < 1)
            {
                throw new Exception("修改病人基本资料失败！");
            }

            //修改T_BSE_PATIENTIDX
            lngRes = m_lngModifyPatientIdx(p_objPrincipal, p_objPatientVO);
            if (lngRes < 1)
            {
                throw new Exception("修改病人T_BSE_PATIENTIDX表失败！");
            }

            // 2、修改住院登记病人基本信息
            lngRes = m_lngModifyRegisterDetial(p_objPrincipal, p_objRegisterVO.m_strREGISTERID_CHR, p_objPatientVO);
            if (lngRes < 1)
            {
                throw new Exception("修改住院登记病人基本信息失败！");
            }
            try
            {
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                // 3.修改入院登记表

                #region 生成修改痕迹
                clsRecordMark_VO Markvo = new clsRecordMark_VO();
                clsRecordMark recordMark = new clsRecordMark();
                string strSQLUpdate_Temp = "UPDATE T_OPR_BIH_REGISTER ";
                strSQLUpdate_Temp += "SET TYPE_INT = " + p_objRegisterVO.m_intTYPE_INT.ToString() + ",";
                strSQLUpdate_Temp += "AREAID_CHR = '" + p_objRegisterVO.m_strAREAID_CHR + "',";
                strSQLUpdate_Temp += "MZDOCTOR_CHR = '" + p_objRegisterVO.m_strMZDOCTOR_CHR + "',";
                strSQLUpdate_Temp += "STATE_INT = " + p_objRegisterVO.m_intSTATE_INT.ToString() + ",";
                strSQLUpdate_Temp += "LIMITRATE_MNY = " + p_objRegisterVO.m_dblLIMITRATE_MNY.ToString() + ",";
                strSQLUpdate_Temp += "MZDIAGNOSE_VCHR = '" + p_objRegisterVO.m_strMZDIAGNOSE_VCHR + "',";
                strSQLUpdate_Temp += "DES_VCHR = '" + p_objRegisterVO.DES_VCHR + "',";
                strSQLUpdate_Temp += "PAYTYPEID_CHR = '" + p_objRegisterVO.m_strPAYTYPEID_CHR + "',";
                strSQLUpdate_Temp += "INPATIENT_DAT = TO_DATE ('" + p_objRegisterVO.m_strINPATIENT_DAT + "','YYYY-MM-DD HH24:MI:SS')";
                strSQLUpdate_Temp += "WHERE REGISTERID_CHR = '" + p_objRegisterVO.m_strREGISTERID_CHR + "'";

                Markvo.m_strOPERATORID_CHR = p_objRegisterVO.m_strOPERATORID_CHR;
                Markvo.m_strTABLESEQID_CHR = "1";
                Markvo.m_strRECORDDETAIL_VCHR = strSQLUpdate_Temp;
                recordMark.m_mthAddNewRecord(Markvo);
                #endregion

                string strSQL = @"UPDATE t_opr_bih_register t1
                                   SET t1.inpatient_dat = ?,
                                       t1.type_int = ?,
                                       t1.areaid_chr = ?,
                                       t1.mzdoctor_chr = ?,
                                       t1.state_int = ?,
                                       t1.limitrate_mny = ?,
                                       t1.mzdiagnose_vchr = ?,
                                       t1.des_vchr = ?,
                                       t1.paytypeid_chr = ?, 
                                       t1.CASEDOCTORDEPT_CHR = ?
                                 WHERE t1.registerid_chr = ?";
                svc.CreateDatabaseParameter(11, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = Convert.ToDateTime(p_objRegisterVO.m_strINPATIENT_DAT);
                objLisAddItemRefArr[1].Value = p_objRegisterVO.m_intTYPE_INT;
                objLisAddItemRefArr[2].Value = p_objRegisterVO.m_strAREAID_CHR;
                objLisAddItemRefArr[3].Value = p_objRegisterVO.m_strMZDOCTOR_CHR;
                objLisAddItemRefArr[4].Value = p_objRegisterVO.m_intSTATE_INT;
                objLisAddItemRefArr[5].Value = p_objRegisterVO.m_dblLIMITRATE_MNY;
                objLisAddItemRefArr[6].Value = p_objRegisterVO.m_strMZDIAGNOSE_VCHR;
                objLisAddItemRefArr[7].Value = p_objRegisterVO.DES_VCHR;
                objLisAddItemRefArr[8].Value = p_objRegisterVO.m_strPAYTYPEID_CHR;
                objLisAddItemRefArr[9].Value = p_objRegisterVO.m_strCaseDoctorDept;
                objLisAddItemRefArr[10].Value = p_objRegisterVO.m_strREGISTERID_CHR;
                lngRes = svc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改入院登记表失败！");
                }

                // 4.院登记与电子病历关联表
                /*                
                                strSQL = @"UPDATE t_bse_hisemr_relation a
                                               SET a.hisinpatientdate = ?,
                                                   a.operatorid_chr = ?,
                                                   a.operat_dat = ?
                                             WHERE a.registerid_chr = ?";
                                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                                //Please change the datetime and reocrdid 
                                objLisAddItemRefArr[0].Value = Convert.ToDateTime(p_objRegisterVO.m_strINPATIENT_DAT);
                                objLisAddItemRefArr[1].Value = p_objRegisterVO.m_strOPERATORID_CHR;
                                objLisAddItemRefArr[2].Value = DateTime.Now;
                                objLisAddItemRefArr[3].Value = p_objRegisterVO.m_strREGISTERID_CHR;
                                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                                if (lngRef < 1)
                                {
                                    throw new Exception("院登记与电子病历关联失败！");
                                }
                */
                // 5.修改调转表
                if (p_intFlag == 1)
                {
                    strSQL = @"UPDATE t_opr_bih_transfer
                                   SET targetareaid_chr = ?,
                                       operatorid_chr = ?
                                 WHERE registerid_chr = ? AND type_int = 5";
                    svc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    //Please change the datetime and reocrdid 
                    objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strAREAID_CHR;
                    objLisAddItemRefArr[1].Value = p_objRegisterVO.m_strOPERATORID_CHR;
                    objLisAddItemRefArr[2].Value = p_objRegisterVO.m_strREGISTERID_CHR;
                    lngRes = svc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                    if (lngRef < 1)
                    {
                        throw new Exception("修改调转表失败！");
                    }
                }

                // 6.修改病情表
                if (p_objRegisterVO.m_intSTATE_INT != 0)
                {
                    lngRes = ModifyPatientState(p_objPrincipal, p_objRegisterVO);
                    if (lngRes < 1)
                    {
                        throw new Exception("修改病情资料失败！");
                    }
                }

                //茶山要求修改病人基本信息时，检验、检查申请单同步更新
                clsBrithdayToAge temp = new clsBrithdayToAge();
                String strAge = temp.m_strGetAge(p_objPatientVO.m_strBIRTH_DAT); //获取年龄
                //if(strAge.Length>10)
                //{
                //    strAge = strAge.Substring(10);
                //}

                //修改检验申请单
                strSQL = @"update t_opr_lis_application
                           set patient_name_vchr = ?, sex_chr = ?, age_chr = ?, modify_dat = ?
                         where pstatus_int = 2
                           and patientid_chr = ?
                           and patient_inhospitalno_chr = ?";
                svc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objPatientVO.m_strLASTNAME_VCHR;//姓名
                objLisAddItemRefArr[1].Value = p_objPatientVO.m_strSEX_CHR;
                objLisAddItemRefArr[2].Value = strAge;
                objLisAddItemRefArr[3].Value = Convert.ToDateTime(p_objPatientVO.m_strMODIFY_DAT);//修改时间
                objLisAddItemRefArr[4].Value = p_objPatientVO.m_strPATIENTID_CHR;//patientid_chr
                objLisAddItemRefArr[5].Value = p_objPatientVO.m_strINPATIENTID_CHR;//住院号
                lngRes = svc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                //if (lngRef < 1)
                //{
                //    throw new Exception("修改修改检验申请单失败！");
                //}

                //修改检验标本表
                strSQL = @"update t_opr_lis_sample
                           set patient_name_vchr = ?, sex_chr = ?, age_chr = ?, modify_dat = ?
                         where patientid_chr = ?
                           and patient_inhospitalno_chr = ?";
                svc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objPatientVO.m_strLASTNAME_VCHR;//姓名
                objLisAddItemRefArr[1].Value = p_objPatientVO.m_strSEX_CHR;
                objLisAddItemRefArr[2].Value = strAge;
                objLisAddItemRefArr[3].Value = Convert.ToDateTime(p_objPatientVO.m_strMODIFY_DAT);//修改时间
                objLisAddItemRefArr[4].Value = p_objPatientVO.m_strPATIENTID_CHR;//patientid_chr
                objLisAddItemRefArr[5].Value = p_objPatientVO.m_strINPATIENTID_CHR;//住院号
                lngRes = svc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);

                //修改检查申请单
                strSQL = @"update ar_common_apply
                               set name = ?, sex = ?, age = ?, tel = ?, address = ?
                             where status_int <> 2
                               and bihno = ?";
                svc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objPatientVO.m_strLASTNAME_VCHR;//姓名
                objLisAddItemRefArr[1].Value = p_objPatientVO.m_strSEX_CHR;
                objLisAddItemRefArr[2].Value = strAge;
                objLisAddItemRefArr[3].Value = p_objPatientVO.m_strHOMEPHONE_VCHR;//联系电话
                objLisAddItemRefArr[4].Value = p_objPatientVO.m_strHOMEADDRESS_VCHR;//地址
                objLisAddItemRefArr[5].Value = p_objPatientVO.m_strINPATIENTID_CHR;//住院号
                lngRes = svc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                //if (lngRef < 1)
                //{
                //    throw new Exception("修改修改检查申请单失败！");
                //}


                #region NewEMR.Itf 
                Sql = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = '6666' and t.status_int = 1";
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int val = 0;
                    int.TryParse(dt.Rows[0][0].ToString(), out val);
                    if (val == 1)
                    {
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register
                                   set areaid_int = ? 
                                 where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(2, out parm);
                        parm[0].Value = Convert.ToDecimal(p_objRegisterVO.m_strAREAID_CHR);
                        parm[1].Value = Convert.ToDecimal(p_objRegisterVO.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
                    }
                }
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

        private long m_lngModifyPatientIdx(System.Security.Principal.IPrincipal p_objPrincipal, clsPatient_VO p_objPatientVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyPatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"UPDATE T_BSE_PATIENTIDX
                               SET HOMEADDRESS_VCHR = ?,
                                   SEX_CHR = ?,
                                   BIRTH_DAT = ?,
                                   NAME_VCHR = ?,
                                   HOMEPHONE_VCHR = ?,
                                   INSURANCEID_VCHR = ?,
                                   GOVCARD_CHR = ?
                             WHERE PATIENTID_CHR = ? ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objPatientVO.m_strHOMEADDRESS_VCHR;
                objLisAddItemRefArr[1].Value = p_objPatientVO.m_strSEX_CHR;
                objLisAddItemRefArr[2].Value = Convert.ToDateTime(p_objPatientVO.m_strBIRTH_DAT);
                objLisAddItemRefArr[3].Value = p_objPatientVO.m_strLASTNAME_VCHR;
                objLisAddItemRefArr[4].Value = p_objPatientVO.m_strHOMEPHONE_VCHR;
                objLisAddItemRefArr[5].Value = p_objPatientVO.m_strINSURANCEID_VCHR;
                objLisAddItemRefArr[6].Value = p_objPatientVO.m_strGOVCARD_CHR;
                objLisAddItemRefArr[7].Value = p_objPatientVO.m_strPATIENTID_CHR;

                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            //消息处理
            com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
            try
            {
                lngRes = objMsgUpdate.AddMsg("10001", 2, p_objPatientVO.m_strPATIENTID_CHR);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -1;
            }
            finally
            {
                objMsgUpdate.Dispose();
                objMsgUpdate = null;
            }
            if (lngRes < 0)
            {
                ContextUtil.SetAbort();
            }
            return lngRes;
        }

        #region 修改病情表
        /// <summary>
        /// 修改病情表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRegisterVO"></param>
        /// <returns></returns>
        private long ModifyPatientState(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Register_VO p_objRegisterVO)
        {
            DataTable dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "ModifyPatientState");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select REGISTERID_CHR from T_OPR_BIH_PATIENTSTATE where ACTIVE_INT = 1 and REGISTERID_CHR = ? and STATE_INT = ? ";

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRegisterVO.m_intSTATE_INT;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbRecord, objLisAddItemRefArr);
                if (lngRes > 0 && dtbRecord.Rows.Count > 0)
                {
                    //没有修改病情，则不用改变数据
                    return 1;
                }

                //更新旧记录
                strSQL = @"update T_OPR_BIH_PATIENTSTATE set ACTIVE_INT = 0 where REGISTERID_CHR = ? and ACTIVE_INT = 1 ";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strREGISTERID_CHR;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);

                //插入新记录
                lngRes = AddNewPatientState(p_objPrincipal, p_objRegisterVO);

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

        #region 修改护理饮食表
        /// <summary>
        /// 修改护理饮食表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strType"> 类型 1-护理等级 2-饮食状态</param>
        /// <param name="p_objRegisterVO"></param>
        /// <returns></returns>
        private long ModifyPatientNurse(System.Security.Principal.IPrincipal p_objPrincipal, string p_strType, clsT_Opr_Bih_Register_VO p_objRegisterVO)
        {
            DataTable dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "ModifyPatientState");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select REGISTERID_CHR from T_OPR_BIH_PATIENTNURSE 
                                  where ACTIVE_INT = 1 and 
                                        ORDERDICID_CHR = ? and 
                                        TYPE_INT = ? and 
                                        REGISTERID_CHR = ? ";

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                if (p_strType == "1")
                {
                    objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strNurseOrderdic;
                }
                else
                {
                    objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strEatOrderdic;
                }
                objLisAddItemRefArr[1].Value = p_strType;
                objLisAddItemRefArr[2].Value = p_objRegisterVO.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbRecord, objLisAddItemRefArr);
                if (lngRes > 0 && dtbRecord.Rows.Count > 0)
                {
                    //没有修改，则不用改变数据
                    return 1;
                }

                //更新旧记录
                strSQL = @"update T_OPR_BIH_PATIENTNURSE set ACTIVE_INT = 0 
                            where REGISTERID_CHR = ? and 
                                  TYPE_INT = ? and
                                  ACTIVE_INT = 1 ";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_strType;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);

                //插入新记录
                lngRes = AddNewPatientNurse(p_objPrincipal, p_strType, p_objRegisterVO);

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

        private long AddNewPatientNurse(System.Security.Principal.IPrincipal p_objPrincipal, string p_strType, clsT_Opr_Bih_Register_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "AddNewPatientNurse");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"INSERT INTO T_OPR_BIH_PATIENTNURSE
                                        (SEQID_INT, REGISTERID_CHR, TYPE_INT, ORDERDICID_CHR, ACTIVE_DAT, OPERATORID_CHR )
                                 VALUES (SEQ_PATIENTSTATE.nextval, ?, ?, ?, sysdate, ? )";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_strType;
                if (p_strType == "1")
                {
                    objLisAddItemRefArr[2].Value = p_objRecord.m_strNurseOrderdic;
                }
                else
                {
                    objLisAddItemRefArr[2].Value = p_objRecord.m_strEatOrderdic;
                }

                objLisAddItemRefArr[3].Value = p_objRecord.m_strOPERATORID_CHR;

                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region  修改住院登记病人基本信息
        /// <summary>
        /// 修改住院登记病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objRecord">病人基本信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyRegisterDetial(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, clsPatient_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifyPatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }
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
                                   govcard_chr = ?,
                                   bloodtype_chr = ?,
                                   ifallergic_int = ?,
                                   allergicdesc_vchr = ?,
                                   insuredtotalmoney_mny = ?,
                                   insuredpaymoney_mny = ?, 
                                   insuredpaytime_int = ?,
                                   residenceplace_vchr = ?,
                                   consigneeaddr = ?   
                             WHERE registerid_chr = ? ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(43, out objLisAddItemRefArr);
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
                objLisAddItemRefArr[17].Value = p_objRecord.m_strOFFICEADDRESS_VCHR;
                objLisAddItemRefArr[18].Value = p_objRecord.m_strEMPLOYER_VCHR;
                objLisAddItemRefArr[19].Value = p_objRecord.m_strOFFICEPC_VCHR;
                objLisAddItemRefArr[20].Value = p_objRecord.m_strHOMEPC_CHR;
                objLisAddItemRefArr[21].Value = p_objRecord.m_strEMAIL_VCHR;
                objLisAddItemRefArr[22].Value = p_objRecord.m_strCONTACTPERSONFIRSTNAME_VCHR;
                objLisAddItemRefArr[23].Value = p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
                objLisAddItemRefArr[24].Value = p_objRecord.m_strCONTACTPERSONADDRESS_VCHR;
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCONTACTPERSONPHONE_VCHR;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strCONTACTPERSONPC_CHR;
                objLisAddItemRefArr[27].Value = p_objRecord.m_strPATIENTRELATION_VCHR;
                objLisAddItemRefArr[28].Value = Convert.ToDateTime(p_objRecord.m_strFIRSTDATE_DAT);
                objLisAddItemRefArr[29].Value = p_objRecord.m_intISEMPLOYEE_INT;
                objLisAddItemRefArr[30].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[31].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[32].Value = Convert.ToDateTime(p_objRecord.m_strMODIFY_DAT);
                objLisAddItemRefArr[33].Value = p_objRecord.m_strGOVCARD_CHR;
                objLisAddItemRefArr[34].Value = p_objRecord.m_strBLOODTYPE_CHR;
                objLisAddItemRefArr[35].Value = p_objRecord.m_intIFALLERGIC_INT;
                objLisAddItemRefArr[36].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[37].Value = p_objRecord.m_decInsuredMoney;
                objLisAddItemRefArr[38].Value = p_objRecord.m_decInsuredPayMoney;
                objLisAddItemRefArr[39].Value = p_objRecord.m_decInsuredPayTime;
                objLisAddItemRefArr[40].Value = p_objRecord.m_strResidencePlace;
                //objLisAddItemRefArr[40].Value = p_objRecord.m_decInsuredPayScale;
                objLisAddItemRefArr[41].Value = p_objRecord.ConsigneeAddr;
                objLisAddItemRefArr[42].Value = p_strRegisterID;


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

        // 床位管理
        #region 增加床位
        /// <summary>
        /// 增加床位
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">床位ID</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewBed(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsT_Bse_Bed_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngAddNewBed");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_BED", "BEDID_CHR", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"INSERT INTO t_bse_bed
                                        (bedid_chr, areaid_chr, code_chr, status_int, rate_mny, sex_int,
                                         category_int, airrate_mny, chargeitemid_chr, airchargeitemid_chr
                                        )
                                 VALUES (?, ?, ?, ?, ?, ?,
                                         ?, ?, ?, ?
                                        )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(10, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;//流水号
                objLisAddItemRefArr[1].Value = p_objRecord.m_strAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strCODE_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[4].Value = p_objRecord.m_dblRATE_MNY;
                objLisAddItemRefArr[5].Value = p_objRecord.m_intSEX_INT;
                objLisAddItemRefArr[6].Value = p_objRecord.m_intCATEGORY_INT;
                objLisAddItemRefArr[7].Value = p_objRecord.m_dblAIRRATE_MNY;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strCHARGEITEMID_CHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_str_AIRCHARGEITEMID_CHR;
                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 根据床位ID修改床位信息
        /// <summary>
        /// 根据床位ID修改床位信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">床位ID</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModefyBedByID(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Bse_Bed_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngModefyBedByID");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"UPDATE t_bse_bed
   SET code_chr = ?,
       sex_int = ?,
       category_int = ?,
       rate_mny = ?,
       airrate_mny = ?,
       chargeitemid_chr = ?,
       airchargeitemid_chr = ?
 WHERE bedid_chr = ?";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strCODE_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_intSEX_INT;
                objLisAddItemRefArr[2].Value = p_objRecord.m_intCATEGORY_INT;
                objLisAddItemRefArr[3].Value = p_objRecord.m_dblRATE_MNY;
                objLisAddItemRefArr[4].Value = p_objRecord.m_dblAIRRATE_MNY;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strCHARGEITEMID_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_str_AIRCHARGEITEMID_CHR;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strBEDID_CHR;
                //修改记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 根据床位ID删除床位
        /// <summary>
        ///  根据床位ID删除床位
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_Bedid_chr">流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteBedInfoByByBedID(System.Security.Principal.IPrincipal p_objPrincipal, string p_Bedid_chr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc", "m_lngDeleteBedInfoByByBedID");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"DELETE FROM t_bse_bed
      WHERE bedid_chr = ? AND status_int = 1";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_Bedid_chr;

                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 判断新增床号已经存在
        /// <summary>
        /// 判断新增床号已经存在
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_strBedCode">床号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckBedCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, string p_strBedID, string p_strBedCode)
        {
            DataTable p_dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngCheckBedCode");
            if (lngRes < 0)
            {
                return -1;
            }
            p_strBedCode = p_strBedCode.Replace("'", "''");
            string strSQL = @"SELECT COUNT (t1.bedid_chr) bednum
                              FROM t_bse_bed t1
                             WHERE  t1.STATUS_INT <> 5 and t1.areaid_chr = ? AND t1.bedid_chr <> ? and t1.code_chr = ? ";

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strAreaID;
                objLisAddItemRefArr[1].Value = p_strBedID;
                objLisAddItemRefArr[2].Value = p_strBedCode;

                objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbRecord, objLisAddItemRefArr);
                lngRes = Convert.ToInt16(p_dtbRecord.Rows[0]["bednum"]);
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

        #region 获取员工有权限使用的病区信息列表
        /// <summary>
        /// 获取有权限使用的病区信息列表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">有权限使用的病区ID</param>
        /// <param name="p_objResultArr">有权限使用的病区信息列表ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAreaList(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, out clsAreaInfoVO[] p_objResultArr)
        {
            p_objResultArr = new clsAreaInfoVO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAreaList");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL = @"SELECT COUNT (t1.empid_chr) counts
  FROM t_bse_deptemp t1, t_bse_deptdesc t2
 WHERE t1.empid_chr = '" + p_strEmpID + @"'
   AND t2.status_int = 1
   AND t1.deptid_chr = t2.deptid_chr
   AND (t2.deptid_chr = '0000001' OR t2.deptname_vchr = '全院')";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                if (Convert.ToInt16(dtbResult.Rows[0][0]) > 0)
                {
                    strSQL = @"SELECT   t1.deptid_chr, t1.deptname_vchr, t1.pycode_chr, t1.code_vchr,
         t2.deptid_chr AS parentdeptid, t2.deptname_vchr AS parentdeptname
    FROM t_bse_deptdesc t1, t_bse_deptdesc t2
   WHERE t1.attributeid = '0000003'
     AND t1.status_int = 1
     AND t1.parentid = t2.deptid_chr
ORDER BY t1.code_vchr";
                }
                else
                {
                    strSQL = @"SELECT   t2.deptid_chr, t2.deptname_vchr, t2.pycode_chr, t2.code_vchr,
         t3.deptid_chr AS parentdeptid, t3.deptname_vchr AS parentdeptname
    FROM t_bse_deptemp t1, t_bse_deptdesc t2, t_bse_deptdesc t3
   WHERE t2.attributeid = '0000003'
     AND t2.status_int = 1
     AND t1.empid_chr = '" + p_strEmpID + @"'
     AND t1.deptid_chr = t2.deptid_chr
     AND t2.parentid = t3.deptid_chr
ORDER BY t2.code_vchr";
                }
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsAreaInfoVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsAreaInfoVO();
                        p_objResultArr[i1].m_strDEPTID_CHR = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDEPTNAME_VCHR = dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPYCODE_CHR = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCODE_VCHR = dtbResult.Rows[i1]["CODE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPARENTDEPTID = dtbResult.Rows[i1]["PARENTDEPTID"].ToString().Trim();
                        p_objResultArr[i1].m_strPARENTDEPTNAME = dtbResult.Rows[i1]["PARENTDEPTNAME"].ToString().Trim();
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

        #region 根据病区ID查询详细床位信息
        /// <summary>
        /// 根据病区ID查询详细床位信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_objResultArr">详细床位信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBedInfoByArearID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, out clsBedManageVO[] p_objResultArr)
        {
            p_objResultArr = new clsBedManageVO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBedInfoByArearID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   a.bedid_chr, a.code_chr, a.status_int, t3.flgname_vchr statusname,
                                     t1.flgname_vchr AS categoryname, t2.flgname_vchr AS sexname,
                                     b.registerid_chr, b.inpatientid_chr, d.name_vchr, d.sex_chr,
                                     d.birth_dat, b.inpatient_dat, c.lastname_vchr AS maindoc,
                                     b.icd10diagtext_vchr, e.paytypename_vchr AS paytypename_vchr,
                                     e.internalflag_int, b.paytypeid_chr, b.state_int, b.pstatus_int,
                                     b.diagnoseid_chr, f.itemname_vchr AS itemname_vchr, f.Itemprice_Mny as rate_mny,
                                     (SELECT h.name_chr AS eatdiccate
                                        FROM t_bse_bih_orderdic h,
                                             T_OPR_BIH_PATIENTNURSE i
                                       WHERE h.orderdicid_chr = i.orderdicid_chr
                                         AND i.TYPE_INT = 2
                                         AND i.ACTIVE_INT = 1
                                         AND i.registerid_chr = b.registerid_chr) eatdiccate,
                                     (SELECT h.name_chr AS eatdiccate
                                        FROM t_bse_bih_orderdic h,
                                             T_OPR_BIH_PATIENTNURSE i
                                       WHERE h.orderdicid_chr = i.orderdicid_chr
                                         AND i.TYPE_INT = 1
                                         AND i.ACTIVE_INT = 1
                                         AND i.registerid_chr = b.registerid_chr) nursecate,
                                     g.itemname_vchr AS airchargeitem, g.itemprice_mny as airrate_mny,
                                     t5.code_chr AS wrapbed
                                FROM t_bse_bed a,
                                     t_opr_bih_register b,
                                     t_bse_employee c,
                                     t_opr_bih_registerdetail d,
                                     t_bse_patientpaytype e,
                                     t_bse_chargeitem f,
                                     t_bse_chargeitem g,
                                     t_opr_bih_wrapbed t4,
                                     t_bse_bed t5,
                                     t_sys_flg_table t1,
                                     t_sys_flg_table t2,
                                     t_sys_flg_table t3
                               WHERE a.areaid_chr = '" + p_strAreaID + @"'
                                 AND a.status_int <> 5
                                 and a.category_int <>3 
                                 AND a.bihregisterid_chr = b.registerid_chr(+)
                                 AND b.casedoctor_chr = c.empid_chr(+)
                                 AND b.registerid_chr = d.registerid_chr(+)
                                 AND b.paytypeid_chr = e.paytypeid_chr(+)
                                 AND a.chargeitemid_chr = f.itemid_chr(+)
                                 AND a.airchargeitemid_chr = g.itemid_chr(+)
                                 AND a.bedid_chr = t4.bedid_chr(+)
                                 AND t4.registerid_chr = t5.bihregisterid_chr(+)
                                 AND a.category_int = t1.flg_int
                                 AND a.sex_int = t2.flg_int
                                 AND a.status_int = t3.flg_int
                                 AND t1.tablename_vchr = 't_bse_bed'
                                 AND t1.columnname_vchr = 'CATEGORY_INT'
                                 AND t2.tablename_vchr = 't_bse_bed'
                                 AND t2.columnname_vchr = 'SEX_INT'
                                 AND t3.tablename_vchr = 't_bse_bed'
                                 AND t3.columnname_vchr = 'STATUS_INT'
                            ORDER BY  a.BED_NO,
                                      a.code_chr";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsBedManageVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsBedManageVO();
                        p_objResultArr[i1].m_strBEDID_CHR = dtbResult.Rows[i1]["BEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCODE_CHR = dtbResult.Rows[i1]["CODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSTATUS_INT = dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strSTATUSNAME = dtbResult.Rows[i1]["STATUSNAME"].ToString().Trim();
                        p_objResultArr[i1].m_strCATEGORYNAME = dtbResult.Rows[i1]["CATEGORYNAME"].ToString().Trim();
                        p_objResultArr[i1].m_strSEXNAME = dtbResult.Rows[i1]["SEXNAME"].ToString().Trim();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strINPATIENTID_CHR = dtbResult.Rows[i1]["INPATIENTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strNAME_VCHR = dtbResult.Rows[i1]["NAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSEX_CHR = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strBIRTH_DAT = dtbResult.Rows[i1]["BIRTH_DAT"].ToString().Trim();
                        p_objResultArr[i1].m_strINPATIENT_DAT = dtbResult.Rows[i1]["INPATIENT_DAT"].ToString().Trim();
                        p_objResultArr[i1].m_strMAINDOC = dtbResult.Rows[i1]["MAINDOC"].ToString().Trim();
                        p_objResultArr[i1].m_strICD10DIAGTEXT_VCHR = dtbResult.Rows[i1]["ICD10DIAGTEXT_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPAYTYPENAME_VCHR = dtbResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strINTERNALFLAG_INT = dtbResult.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strPAYTYPEID_CHR = dtbResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSTATE_INT = dtbResult.Rows[i1]["STATE_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strPSTATUS_INT = dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strDIAGNOSEID_CHR = dtbResult.Rows[i1]["DIAGNOSEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strITEMNAME_VCHR = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strRATE_MNY = dtbResult.Rows[i1]["RATE_MNY"].ToString().Trim();
                        p_objResultArr[i1].m_strEATDICCATE = dtbResult.Rows[i1]["EATDICCATE"].ToString().Trim();
                        p_objResultArr[i1].m_strNURSECATE = dtbResult.Rows[i1]["NURSECATE"].ToString().Trim();
                        p_objResultArr[i1].m_strAIRCHARGEITEM = dtbResult.Rows[i1]["AIRCHARGEITEM"].ToString().Trim();
                        p_objResultArr[i1].m_strAIRRATE_MNY = dtbResult.Rows[i1]["AIRRATE_MNY"].ToString().Trim();
                        p_objResultArr[i1].m_strWRAPBED = dtbResult.Rows[i1]["WRAPBED"].ToString().Trim();
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

        #region 查询病区转入未接收病人
        /// <summary>
        /// 查询病区转入未接收病人
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTurnInNA(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "m_lngGetTurnInNA");
            if (lngRes < 0)
            {
                return -1;
            }
            string SQL = @"SELECT a.registerid_chr, a.inpatient_dat, a.inpatientid_chr,
                                  a.icd10diagtext_vchr, a.state_int, c.flgname_vchr AS status,
                                  d.name_vchr, d.birth_dat, d.sex_chr, e.deptname_vchr AS areaname,
                                  b.des_vchr, b.modify_dat,b.type_int,f.HISINPATIENTDATE,
                                  (SELECT h.name_chr AS eatdiccate
                                    FROM t_bse_bih_orderdic h,
                                         t_opr_bih_order i,
                                         t_bse_bih_specordercate j
                                       WHERE h.orderdicid_chr = i.orderdicid_chr
                                         AND h.ordercateid_chr = j.nursecate
                                         AND i.status_int = 2
                                         AND ROWNUM = 1
                                         AND a.registerid_chr = i.registerid_chr) nursecate
                             FROM t_opr_bih_register a,
                                  t_opr_bih_transfer b,
                                  t_sys_flg_table c,
                                  t_opr_bih_registerdetail d,
                                  t_bse_deptdesc e,
                                  t_bse_hisemr_relation f 
                            
                               --   (select * from t_opr_bih_patientstate where ACTIVE_INT = 1) g
                            WHERE a.registerid_chr = b.registerid_chr AND 
                                  a.registerid_chr = d.registerid_chr AND 
                                  a.registerid_chr = f.registerid_chr AND 
                                  b.sourceareaid_chr = e.deptid_chr(+) AND
                                 -- a.registerid_chr = g.registerid_chr(+) and
                                 -- g.ACTIVE_INT = 1 and
                                  a.state_int = c.flg_int AND
                                  c.tablename_vchr = 't_opr_bih_register' AND 
                                  c.columnname_vchr = 'STATE_INT'  AND
                                  a.pstatus_int = 0 AND
                                  a.status_int = 1 AND
                                  b.type_int IN (3, 4, 5) AND
                                  b.targetbedid_chr IS NULL AND
                                  a.areaid_chr = '" + p_strAreaID + @"'
                         ORDER BY a.modify_dat";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref p_dtbResult);
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

        #region 查询病区转入已接收病人
        /// <summary>
        /// 查询病区转入已接收病人
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTurnInA(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetTurnInA");
            if (lngRes < 0)
            {
                return -1;
            }
            string SQL = @"SELECT   a.registerid_chr, a.inpatient_dat, a.inpatientid_chr,
         a.icd10diagtext_vchr, c.flgname_vchr AS status, d.name_vchr,
         d.birth_dat, d.sex_chr, e.deptname_vchr AS areaname
    FROM t_opr_bih_register a,
         t_opr_bih_transfer b,
         t_sys_flg_table c,
         t_opr_bih_registerdetail d,
         t_bse_deptdesc e
   WHERE a.areaid_chr = '" + p_strAreaID + @"'
     AND a.pstatus_int = 1
     AND a.status_int = 1
     AND b.type_int IN (3, 5)
     AND b.targetbedid_chr IS NOT NULL
     AND TRUNC (b.modify_dat) = TRUNC (SYSDATE)
     AND a.registerid_chr = b.registerid_chr
     AND a.registerid_chr = d.registerid_chr
     AND b.sourceareaid_chr = e.deptid_chr(+)
     AND a.state_int = c.flg_int
     AND c.tablename_vchr = 't_opr_bih_register'
     AND c.columnname_vchr = 'STATE_INT'
ORDER BY a.modify_dat";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref p_dtbResult);
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

        #region 查询病区转出未接收病人
        /// <summary>
        /// 查询病区转出未接收病人
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_objResultArr">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTurnOutNA(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, out clsTransferVO[] p_objResultArr)
        {
            p_objResultArr = new clsTransferVO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetTurnOutNA");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   a.registerid_chr, a.inpatient_dat, a.inpatientid_chr,
         a.icd10diagtext_vchr, c.flgname_vchr AS status, d.name_vchr,
         d.birth_dat, d.sex_chr, e.deptname_vchr AS areaname,
         b.sourcebedid_chr, b.transferid_chr
    FROM t_opr_bih_register a,
         t_opr_bih_transfer b,
         t_sys_flg_table c,
         t_opr_bih_registerdetail d,
         t_bse_deptdesc e
   WHERE a.pstatus_int = 0
     AND a.status_int = 1
     AND b.type_int = 3
     AND b.sourceareaid_chr = '" + p_strAreaID + @"'
     AND b.targetbedid_chr IS NULL
     AND a.registerid_chr = b.registerid_chr
     AND a.registerid_chr = d.registerid_chr
     AND b.targetareaid_chr = e.deptid_chr(+)
     AND a.status_int = c.flg_int
     AND c.tablename_vchr = 't_opr_bih_register'
     AND c.columnname_vchr = 'STATE_INT'
ORDER BY a.modify_dat";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsTransferVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsTransferVO();
                        p_objResultArr[i1].m_strREGISTERID_CHR = dtbResult.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strINPATIENT_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["INPATIENT_DAT"]).ToString("yyyy-MM-dd HH:mm");
                        p_objResultArr[i1].m_strINPATIENTID_CHR = dtbResult.Rows[i1]["INPATIENTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strICD10DIAGTEXT_VCHR = dtbResult.Rows[i1]["ICD10DIAGTEXT_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSTATUS = dtbResult.Rows[i1]["STATUS"].ToString().Trim();
                        p_objResultArr[i1].m_strNAME_VCHR = dtbResult.Rows[i1]["NAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strBIRTH_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["BIRTH_DAT"]).ToString("yyyy-MM-dd HH:mm:ss");
                        p_objResultArr[i1].m_strSEX_CHR = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAREANAME = dtbResult.Rows[i1]["AREANAME"].ToString().Trim();
                        p_objResultArr[i1].m_strSOURCEBEDID_CHR = dtbResult.Rows[i1]["SOURCEBEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strTRANSFERID_CHR = dtbResult.Rows[i1]["TRANSFERID_CHR"].ToString().Trim();
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

        #region 查询病区转出已接收病人
        /// <summary>
        /// 查询病区转出已接收病人
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTurnOutA(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetTurnOutA");
            if (lngRes < 0)
            {
                return -1;
            }
            string SQL = @"SELECT   a.registerid_chr, a.inpatient_dat, a.inpatientid_chr,
                                     a.icd10diagtext_vchr, c.flgname_vchr AS status, d.name_vchr,
                                     d.birth_dat, d.sex_chr, e.deptname_vchr AS areaname
                                FROM t_opr_bih_register a,
                                     t_opr_bih_transfer b,
                                     t_sys_flg_table c,
                                     t_opr_bih_registerdetail d,
                                     t_bse_deptdesc e
                               WHERE a.pstatus_int = 1
                                 AND a.status_int = 1
                                 AND b.type_int = 3
                                 AND b.sourceareaid_chr = '" + p_strAreaID + @"'
                                 AND b.targetbedid_chr IS NOT NULL
                                 AND TRUNC (b.modify_dat) = TRUNC (SYSDATE)
                                 AND a.registerid_chr = b.registerid_chr
                                 AND a.registerid_chr = d.registerid_chr
                                 AND b.targetareaid_chr = e.deptid_chr(+)
                                 AND a.status_int = c.flg_int
                                 AND c.tablename_vchr = 't_opr_bih_register'
                                 AND c.columnname_vchr = 'STATE_INT'
                            ORDER BY a.modify_dat";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref p_dtbResult);
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

        #region 获取除当前病区外全院未安排床位的病人
        /// <summary>
        /// 获取除当前病区外全院未安排床位的病人
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllUnArrangeBedPatient(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaID, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAllUnArrangeBedPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            string SQL = @"SELECT   a.registerid_chr, a.inpatient_dat, a.inpatientid_chr,
         a.icd10diagtext_vchr, g.state_int, c.flgname_vchr AS status,
         d.name_vchr, d.birth_dat, d.sex_chr, e.deptname_vchr AS areaname,
         b.des_vchr, b.modify_dat,b.type_int,f.HISINPATIENTDATE,
         (SELECT h.name_chr AS eatdiccate
            FROM t_bse_bih_orderdic h,
                 t_opr_bih_order i,
                 t_bse_bih_specordercate j
           WHERE h.orderdicid_chr = i.orderdicid_chr
             AND h.ordercateid_chr = j.nursecate
             AND i.status_int = 2
             AND ROWNUM = 1
             AND i.registerid_chr = b.registerid_chr) nursecate
    FROM t_opr_bih_register a,
         t_opr_bih_transfer b,
         t_sys_flg_table c,
         t_opr_bih_registerdetail d,
         t_bse_deptdesc e,
         t_bse_hisemr_relation f,
         --t_opr_bih_patientstate g
         (select * from t_opr_bih_patientstate where ACTIVE_INT = 1) g
   WHERE a.areaid_chr <> '" + p_strAreaID + @"'
     AND a.pstatus_int = 0
     AND a.status_int = 1
     AND b.type_int IN (3, 4, 5)
     AND b.targetbedid_chr IS NULL
     AND a.registerid_chr = b.registerid_chr
     AND a.registerid_chr = d.registerid_chr
     AND a.registerid_chr = f.registerid_chr  
     AND b.targetareaid_chr = e.deptid_chr(+)
     AND a.registerid_chr = g.registerid_chr(+) 
      --g.ACTIVE_INT = 1 
     AND a.state_int = c.flg_int
     AND c.tablename_vchr = 't_opr_bih_register'
     AND c.columnname_vchr = 'STATE_INT'
ORDER BY b.targetareaid_chr, a.modify_dat";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref p_dtbResult);
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

        #region 安排床位
        /// <summary>
        /// 安排床位
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngArrangeBed(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngArrangeBed");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //修改床位表
            string strSQL = @"UPDATE t_bse_bed t1
                               SET t1.status_int = 2,
                                   t1.bihregisterid_chr = ?
                             WHERE (t1.status_int = 1 or t1.status_int = 6) AND t1.bedid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETBEDID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("床位被占用！");
                }

                //修改调转表
                strSQL = @"UPDATE t_opr_bih_transfer
                               SET targetdeptid_chr = ?,
                                   targetareaid_chr = ?,
                                   targetbedid_chr = ?,
                                   operatorid_chr = ?,
                                   modify_dat = ?
                             WHERE registerid_chr = ?
                               AND type_int IN (3, 4, 5)
                               AND targetbedid_chr IS NULL";
                objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTARGETDEPTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTARGETBEDID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[4].Value = Convert.ToDateTime(strDateTime);
                objLisAddItemRefArr[5].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("可能已经安排床位！");
                }

                //修改入院登记表
                strSQL = @"UPDATE t_opr_bih_register
                           SET deptid_chr = ?,
                               areaid_chr = ?,
                               bedid_chr = ?,
                               pstatus_int = 1,
                               operatorid_chr = ?,
                               casedoctor_chr = ?,
                               inareadate_dat = ?
                            WHERE status_int = 1 AND pstatus_int = 0 AND registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTARGETDEPTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTARGETBEDID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strDES_VCHR;
                objLisAddItemRefArr[5].Value = Convert.ToDateTime(strDateTime);
                objLisAddItemRefArr[6].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该病人可能已经安排床位！");
                }


                //修改入病区时间 
                strSQL = @"UPDATE t_bse_hisemr_relation
                           SET HISINPATIENTDATE = ?
                            WHERE REGISTERID_CHR = ?";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid
                objLisAddItemRefArr[0].Value = Convert.ToDateTime(p_objRecord.m_strHisInpatientDate);
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改入病区时间失败！");
                }

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register
                                   set deptid_int = ?,
                                       areaid_int = ?,
                                       bedid_int  = ?,
                                       status_int = ?,
                                       doctid_int = ?,
                                       indate_dat = ?
                                 where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(7, out parm);
                        parm[0].Value = Convert.ToDecimal(p_objRecord.m_strTARGETDEPTID_CHR);
                        parm[1].Value = Convert.ToDecimal(p_objRecord.m_strTARGETAREAID_CHR);
                        parm[2].Value = Convert.ToDecimal(p_objRecord.m_strTARGETBEDID_CHR);
                        parm[3].Value = 1;
                        parm[4].Value = Convert.ToDecimal(p_objRecord.m_strOPERATORID_CHR);
                        parm[5].Value = Convert.ToDateTime(strDateTime);
                        parm[6].Value = Convert.ToDecimal(p_objRecord.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
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

        #region 安排床位 (新)
        /// <summary>
        /// 安排床位
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngArrangeBed(System.Security.Principal.IPrincipal p_objPrincipal,
                clsT_Opr_Bih_Transfer_VO p_objRecord,
                clsT_Opr_Bih_Register_VO p_objRegisterVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngArrangeBed");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //修改床位表
            string strSQL = @"UPDATE t_bse_bed t1
                               SET t1.status_int = 2,
                                   t1.bihregisterid_chr = ?
                             WHERE (t1.status_int = 1 or t1.status_int = 6) AND t1.bedid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETBEDID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("床位被占用！");
                }

                //根据医生Id取专业组信息
                DataTable dtGroup;
                string strGroupId = "";
                lngRes = GetGroupbyEmpID(p_objRegisterVO.m_strCASEDOCTOR_CHR, out dtGroup);
                if (lngRes > 0 && dtGroup.Rows.Count > 0)
                {
                    strGroupId = dtGroup.Rows[0]["GROUPID_CHR"].ToString();
                }

                //修改调转表
                strSQL = @"UPDATE t_opr_bih_transfer
                               SET targetdeptid_chr = ?,
                                   targetareaid_chr = ?,
                                   targetbedid_chr = ?,
                                   operatorid_chr = ?,
                                   modify_dat = ?,
                                   DOCTORID_CHR = ?,
                                   DOCTORGROUPID_CHR = ?
                             WHERE registerid_chr = ?
                               AND type_int IN (3, 4, 5)
                               AND targetbedid_chr IS NULL";
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTARGETDEPTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTARGETBEDID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[4].Value = Convert.ToDateTime(strDateTime);
                objLisAddItemRefArr[5].Value = p_objRegisterVO.m_strCASEDOCTOR_CHR;
                objLisAddItemRefArr[6].Value = strGroupId;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("可能已经安排床位！");
                }

                //修改入院登记表
                strSQL = @"UPDATE t_opr_bih_register
                           SET deptid_chr = ?,
                               areaid_chr = ?,
                               bedid_chr = ?,
                               pstatus_int = 1,
                               operatorid_chr = ?,
                               casedoctor_chr = ?,
                               inareadate_dat = ?,
                               STATE_INT = ?,
                               NURSING_CLASS = ?
                            WHERE status_int = 1 AND pstatus_int = 0 AND registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(9, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTARGETDEPTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTARGETBEDID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[4].Value = p_objRegisterVO.m_strCASEDOCTOR_CHR;
                //objLisAddItemRefArr[5].Value = Convert.ToDateTime(strDateTime);
                objLisAddItemRefArr[5].Value = Convert.ToDateTime(p_objRecord.m_strHisInpatientDate);
                objLisAddItemRefArr[6].Value = p_objRegisterVO.m_intSTATE_INT;
                objLisAddItemRefArr[7].Value = p_objRegisterVO.m_intNursingClass;
                objLisAddItemRefArr[8].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该病人可能已经安排床位！");
                }

                //修改主治医生为空字段
                strSQL = @"update  t_opr_bih_patientcharge a
                               set a.doctorid_chr = ?, a.doctor_vchr = ?
                             where a.doctorid_chr is null
                               and a.registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_objRegisterVO.m_strCASEDOCTOR_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strDES_VCHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strREGISTERID_CHR;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);


                //修改入病区时间 
                strSQL = @"UPDATE t_bse_hisemr_relation
                           SET HISINPATIENTDATE = ?
                            WHERE REGISTERID_CHR = ?";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid
                objLisAddItemRefArr[0].Value = Convert.ToDateTime(p_objRecord.m_strHisInpatientDate);
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改入病区时间失败！");
                }

                //修改病情记录
                if (p_objRegisterVO.m_intSTATE_INT != 0)
                {
                    lngRes = ModifyPatientState(p_objPrincipal, p_objRegisterVO);
                    if (lngRef < 1)
                    {
                        throw new Exception("修改病情记录失败！");
                    }
                }

                // 修改护理信息
                if (p_objRegisterVO.m_strNurseOrderdic != null && p_objRegisterVO.m_strNurseOrderdic != "")
                {
                    lngRes = ModifyPatientNurse(p_objPrincipal, "1", p_objRegisterVO);
                    if (lngRes < 1)
                    {
                        throw new Exception("修改护理信息失败！");
                    }
                }

                // 修改饮食信息
                if (p_objRegisterVO.m_strEatOrderdic != null && p_objRegisterVO.m_strEatOrderdic != "")
                {
                    lngRes = ModifyPatientNurse(p_objPrincipal, "2", p_objRegisterVO);
                    if (lngRes < 1)
                    {
                        throw new Exception("修改饮食信息失败！");
                    }
                }

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register
                                   set deptid_int = ?,
                                       areaid_int = ?,
                                       bedid_int  = ?,
                                       status_int = ?,
                                       doctid_int = ?,
                                       indate_dat = ?
                                 where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(7, out parm);
                        parm[0].Value = Convert.ToDecimal(p_objRecord.m_strTARGETDEPTID_CHR);
                        parm[1].Value = Convert.ToDecimal(p_objRecord.m_strTARGETAREAID_CHR);
                        parm[2].Value = Convert.ToDecimal(p_objRecord.m_strTARGETBEDID_CHR);
                        parm[3].Value = 1;
                        parm[4].Value = Convert.ToDecimal(p_objRegisterVO.m_strCASEDOCTOR_CHR);
                        parm[5].Value = Convert.ToDateTime(p_objRecord.m_strHisInpatientDate);
                        parm[6].Value = Convert.ToDecimal(p_objRecord.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
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

        #region 根据病区ID和床位状态获取病区床位简短信息
        /// <summary>
        /// 根据病区ID和床位状态获取病区床位简短信息
        /// </summary>
        /// <param name="p_objPrincipal">病区ID</param>
        /// <param name="p_strAreaid_chr"></param>
        /// <param name="p_strStatus">1=空床;2=占床;3=预约占床;4=包房占床</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBedShortInfoByAreaID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAreaid_chr, string p_strStatus, out clsT_Bse_Bed_VO[] p_objResultArr)
        {

            p_objResultArr = new clsT_Bse_Bed_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngGetBedShortInfoByAreaID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT   t1.bedid_chr, t1.code_chr, t2.flgname_vchr AS sexname
    FROM t_bse_bed t1, t_sys_flg_table t2
   WHERE t1.areaid_chr = '" + p_strAreaid_chr + @"'
     AND t1.status_int IN (" + p_strStatus + @")
     AND t2.tablename_vchr = 't_bse_bed'
     AND t2.columnseq_int = 5
     AND t1.sex_int = t2.flg_int
ORDER BY t1.code_chr";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_Bse_Bed_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_Bse_Bed_VO();
                        p_objResultArr[i1].m_strBEDID_CHR = dtbResult.Rows[i1]["BEDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCODE_CHR = dtbResult.Rows[i1]["CODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSexName = dtbResult.Rows[i1]["sexname"].ToString().Trim();
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

        #region 根据床位ID获取床位信息
        /// <summary>
        /// 根据床位ID获取床位信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_objResult">位信息VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBedInfoByBedID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBedID, out clsT_Bse_Bed_VO p_objResult)
        {

            p_objResult = new clsT_Bse_Bed_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngGetBedInfoByBedID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT t1.bedid_chr, t1.areaid_chr, t1.code_chr, t1.status_int, t1.rate_mny,
       t1.sex_int, t1.category_int, t1.airrate_mny, t1.chargeitemid_chr,
       t1.airchargeitemid_chr, t2.deptname_vchr AS areaname,
       t3.flgname_vchr AS statusname, t4.flgname_vchr AS sexname,
       t5.flgname_vchr AS categoryname, t6.itemname_vchr AS bedchargename,
       t7.itemname_vchr AS airchanrgename
  FROM t_bse_bed t1,
       t_bse_deptdesc t2,
       t_sys_flg_table t3,
       t_sys_flg_table t4,
       t_sys_flg_table t5,
       t_bse_chargeitem t6,
       t_bse_chargeitem t7
 WHERE t1.bedid_chr = ?
   AND t1.areaid_chr = t2.deptid_chr
   AND t3.tablename_vchr = 't_bse_bed'
   AND t3.columnseq_int = 3
   AND t4.tablename_vchr = 't_bse_bed'
   AND t4.columnseq_int = 5
   AND t5.tablename_vchr = 't_bse_bed'
   AND t5.columnseq_int = 6
   AND t1.status_int = t3.flg_int
   AND t1.sex_int = t4.flg_int
   AND t1.category_int = t5.flg_int
   AND t1.chargeitemid_chr = t6.itemid_chr(+)
   AND t1.airchargeitemid_chr = t7.itemid_chr(+)";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strBedID;

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strBEDID_CHR = dtbResult.Rows[0]["BEDID_CHR"].ToString().Trim();
                    p_objResult.m_strAREAID_CHR = dtbResult.Rows[0]["AREAID_CHR"].ToString().Trim();
                    p_objResult.m_strCODE_CHR = dtbResult.Rows[0]["CODE_CHR"].ToString().Trim();
                    p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
                    p_objResult.m_dblRATE_MNY = Convert.ToDouble(dtbResult.Rows[0]["RATE_MNY"].ToString());
                    p_objResult.m_intSEX_INT = Convert.ToInt32(dtbResult.Rows[0]["SEX_INT"].ToString().Trim());
                    p_objResult.m_intCATEGORY_INT = Convert.ToInt32(dtbResult.Rows[0]["CATEGORY_INT"].ToString().Trim());
                    p_objResult.m_dblAIRRATE_MNY = Convert.ToDouble(dtbResult.Rows[0]["AIRRATE_MNY"].ToString());
                    p_objResult.m_str_AIRCHARGEITEMID_CHR = dtbResult.Rows[0]["AIRCHARGEITEMID_CHR"].ToString().Trim();
                    p_objResult.m_strCHARGEITEMID_CHR = dtbResult.Rows[0]["CHARGEITEMID_CHR"].ToString().Trim();
                    // 病区名称	[非字段]
                    p_objResult.m_strAreaName = dtbResult.Rows[0]["AreaName"].ToString().Trim();
                    // 占床状态	[非字段]	{1=空床;2=占床;3=预约占床;4=包房占床}
                    p_objResult.m_strStatusName = dtbResult.Rows[0]["StatusName"].ToString().Trim();
                    // 状态	[非字段]	{1=开放;2=加床;3=虚床}
                    p_objResult.m_strCategoryName = dtbResult.Rows[0]["CategoryName"].ToString().Trim();
                    // 性别	[非字段]	{男女床(1-男,2-女,3-不限)}
                    p_objResult.m_strSexName = dtbResult.Rows[0]["SexName"].ToString().Trim();
                    p_objResult.m_strBedchargeName = dtbResult.Rows[0]["bedchargename"].ToString().Trim();
                    p_objResult.m_strAirChanrgeName = dtbResult.Rows[0]["airchanrgename"].ToString().Trim();

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

        #region 查找入院诊断(ICD10)信息
        /// <summary>
        /// 查找入院诊断(ICD10)信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFind">姓名</param>
        /// <param name="p_dtbRecord">结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindICD10(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFind, out DataTable p_dtbRecord)
        {
            p_dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngFindICD10");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   icdcode_chr, icdname_vchr
    FROM t_aid_icd10 t1
   WHERE icdcode_chr LIKE ? OR icdname_vchr LIKE ?
ORDER BY icdcode_chr";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strFind + "%";
                objLisAddItemRefArr[1].Value = p_strFind + "%";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbRecord, objLisAddItemRefArr);
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

        #region 设置主治医生和诊断(在床位编辑时用到)
        /// <summary>
        /// 设置主治医生和诊断(在床位编辑时用到)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyRegInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Register_VO objPatientVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "m_lngModifyRegInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQLUpdate = @"UPDATE t_opr_bih_register
                                   SET casedoctor_chr = ?,
                                       diagnoseid_chr = ?,
                                       diagnose_vchr = ?,
                                       icd10diagid_vchr = ?,
                                       icd10diagtext_vchr = ?,
                                       STATE_INT = ?,
                                       NURSING_CLASS = ?
                                 WHERE registerid_chr = ?";

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = objPatientVO.m_strCASEDOCTOR_CHR;
                objLisAddItemRefArr[1].Value = objPatientVO.m_strDIAGNOSEID_CHR;
                objLisAddItemRefArr[2].Value = objPatientVO.m_strDIAGNOSE_VCHR;
                objLisAddItemRefArr[3].Value = objPatientVO.m_strICD10DIAGID_VCHR;
                objLisAddItemRefArr[4].Value = objPatientVO.m_strICD10DIAGTEXT_VCHR;
                objLisAddItemRefArr[5].Value = objPatientVO.m_intSTATE_INT;
                objLisAddItemRefArr[6].Value = objPatientVO.m_intNursingClass;
                objLisAddItemRefArr[7].Value = objPatientVO.m_strREGISTERID_CHR;
                //修改记录

                #region 修改痕迹保留
                //clsRecordMark_VO Markvo = new clsRecordMark_VO();
                //clsRecordMark recordMark = new clsRecordMark();
                //string strSQLUpdate_Temp = "UPDATE  T_OPR_BIH_REGISTER SET ";
                //strSQLUpdate_Temp += " CASEDOCTOR_CHR = '" + objPatientVO.m_strCASEDOCTOR_CHR + "'";
                //strSQLUpdate_Temp += " , DIAGNOSEID_CHR = '" + objPatientVO.m_strDIAGNOSEID_CHR + "' ";
                //strSQLUpdate_Temp += " , DIAGNOSE_VCHR = '" + objPatientVO.m_strDIAGNOSE_VCHR + "' ";
                //strSQLUpdate_Temp += " , ICD10DIAGID_VCHR = '" + objPatientVO.m_strICD10DIAGID_VCHR + "' ";
                //strSQLUpdate_Temp += " , ICD10DIAGTEXT_VCHR = '" + objPatientVO.m_strICD10DIAGTEXT_VCHR + "' ";
                //strSQLUpdate_Temp += "  WHERE REGISTERID_CHR = '" + objPatientVO.m_strREGISTERID_CHR + "'";
                //Markvo.m_strOPERATORID_CHR = objPatientVO.m_strOPERATORID_CHR;
                //Markvo.m_strTABLESEQID_CHR = "1";
                //Markvo.m_strRECORDDETAIL_VCHR = strSQLUpdate_Temp;
                //recordMark.m_mthAddNewRecord(Markvo);
                #endregion

                objHRPSvc.lngExecuteParameterSQL(strSQLUpdate, ref lngRes, objLisAddItemRefArr);

                //修改入病区时间 
                string strSQL = @"UPDATE t_bse_hisemr_relation
                           SET HISINPATIENTDATE = ?
                            WHERE REGISTERID_CHR = ?";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid
                objLisAddItemRefArr[0].Value = Convert.ToDateTime(objPatientVO.m_strINAREADATE_DAT);
                objLisAddItemRefArr[1].Value = objPatientVO.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);


                //修改病情记录
                if (objPatientVO.m_intSTATE_INT != 0)
                {
                    lngRes = ModifyPatientState(p_objPrincipal, objPatientVO);
                    if (lngRes < 1)
                    {
                        throw new Exception("修改病情记录失败！");
                    }
                }

                // 修改护理信息
                if (objPatientVO.m_strNurseOrderdic != null && objPatientVO.m_strNurseOrderdic != "")
                {
                    lngRes = ModifyPatientNurse(p_objPrincipal, "1", objPatientVO);
                    if (lngRes < 1)
                    {
                        throw new Exception("修改护理信息失败！");
                    }
                }

                // 修改饮食信息
                if (objPatientVO.m_strEatOrderdic != null && objPatientVO.m_strEatOrderdic != "")
                {
                    lngRes = ModifyPatientNurse(p_objPrincipal, "2", objPatientVO);
                    if (lngRes < 1)
                    {
                        throw new Exception("修改饮食信息失败！");
                    }
                }

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register set doctid_int = ?, indiagnosis_vchr = ? where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(3, out parm);
                        parm[0].Value = Convert.ToDecimal(objPatientVO.m_strCASEDOCTOR_CHR);
                        parm[1].Value = objPatientVO.m_strDIAGNOSE_VCHR;
                        parm[2].Value = Convert.ToDecimal(objPatientVO.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
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

        #region 转病区
        /// <summary>
        /// 转病区
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngTurnOut(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngTurnOut");
            if (lngRes < 0)
            {
                return -1;
            }
            p_objRecord.m_strMODIFY_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 1.修改床位表
            string strSQL = @"UPDATE t_bse_bed t1
                               SET t1.status_int = 1,
                                   t1.bihregisterid_chr = NULL
                             WHERE t1.status_int = 2
                               AND t1.bedid_chr = ?
                               AND t1.bihregisterid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strSOURCEBEDID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("可能已经转出！");
                }

                // 2.增加周转记录
                lngRes = m_lngAddTransFast(p_objPrincipal, p_objRecord);
                if (lngRes < 1)
                {
                    throw new Exception("增加调转记录出错！");
                }

                // 3.修改入院登记表
                strSQL = @"UPDATE t_opr_bih_register t1
                           SET t1.deptid_chr = ?,
                               t1.areaid_chr = ?,
                               t1.bedid_chr = NULL,
                               t1.pstatus_int = 0,
                               t1.operatorid_chr = ?
                         WHERE t1.status_int = 1
                           AND t1.registerid_chr = ?
                           AND t1.deptid_chr = ?
                           AND t1.areaid_chr = ?
                           AND t1.pstatus_int NOT IN (0, 3)";

                string strParentId;
                GetParentIdByDeptId(p_objPrincipal, p_objRecord.m_strTARGETAREAID_CHR, out strParentId);
                p_objRecord.m_strTARGETDEPTID_CHR = strParentId;

                objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTARGETDEPTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strSOURCEDEPTID_CHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strSOURCEAREAID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改入院登记表失败！");
                }

                // 4.撤消包床(如果存在包床的话)
                m_lngCancelWrapBed(p_objPrincipal, p_objRecord.m_strREGISTERID_CHR);
                objHRPSvc.Dispose();

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register
                                   set deptid_int = ?, areaid_int = ?, bedid_int = ?, status_int = ?
                                 where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(5, out parm);
                        parm[0].Value = Convert.ToDecimal(p_objRecord.m_strTARGETDEPTID_CHR);
                        parm[1].Value = Convert.ToDecimal(p_objRecord.m_strTARGETAREAID_CHR);
                        parm[2].Value = null;
                        parm[3].Value = 0;
                        parm[4].Value = Convert.ToDecimal(p_objRecord.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
                    }
                }
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
        #endregion

        #region 撤消转区
        /// <summary>
        /// 撤消转区
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">调转信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnDoTurnOut(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngUnDoTurnOut");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                // 1.修改入院登记表
                string strSQL = @"UPDATE t_opr_bih_register
   SET deptid_chr = ?,
       areaid_chr = ?,
       bedid_chr = ?,
       pstatus_int = 1,
       operatorid_chr = ?
 WHERE status_int = 1 AND pstatus_int = 0 AND registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strSOURCEDEPTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strSOURCEAREAID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTARGETBEDID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该病人已经被转入病区接收！");
                }

                // 2.修改床位表
                strSQL = @"UPDATE t_bse_bed t1
   SET t1.status_int = 2,
       t1.bihregisterid_chr = ?
 WHERE t1.status_int = 1 AND t1.bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETBEDID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该床位已被占用！");
                }

                // 3.删除转区记录
                strSQL = @"DELETE      t_opr_bih_transfer
      WHERE transferid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTRANSFERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("删除转区记录失败！");
                }

                // 4.如果床位不是原床位,则新增一条转床记录
                if (p_objRecord.m_strSOURCEBEDID_CHR != p_objRecord.m_strTARGETBEDID_CHR)
                {
                    lngRes = m_lngAddTransFast(p_objPrincipal, p_objRecord);
                    if (lngRes < 1)
                    {
                        throw new Exception("新增转床记录失败！");
                    }
                }
                objHRPSvc.Dispose();

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register
                                   set deptid_int = ?, areaid_int = ?, bedid_int = ?, status_int = ?
                                 where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(5, out parm);
                        parm[0].Value = Convert.ToDecimal(p_objRecord.m_strSOURCEDEPTID_CHR);
                        parm[1].Value = Convert.ToDecimal(p_objRecord.m_strSOURCEAREAID_CHR);
                        parm[2].Value = Convert.ToDecimal(p_objRecord.m_strTARGETBEDID_CHR);
                        parm[3].Value = 1;
                        parm[4].Value = Convert.ToDecimal(p_objRecord.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
                    }
                }
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
        #endregion

        #region 转床
        /// <summary>
        /// 转床
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngTurnBed(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngTurnBed");
            if (lngRes < 0)
            {
                return -1;
            }
            p_objRecord.m_strMODIFY_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 1.空出旧床位
            string strSQL = @"UPDATE t_bse_bed t1
                               SET t1.status_int = 1,
                                   t1.bihregisterid_chr = NULL
                             WHERE t1.status_int = 2
                               AND t1.bedid_chr = ?
                               AND t1.bihregisterid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strSOURCEBEDID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("可能已经转出！");
                }

                // 2.安排新床位
                strSQL = @"UPDATE t_bse_bed t1
   SET t1.status_int = 2,
       t1.bihregisterid_chr = ?
 WHERE (t1.status_int = 1 or t1.status_int = 6) AND t1.bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTARGETBEDID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("床位被占用！");
                }

                // 3.增加调转记录

                lngRes = m_lngAddTransFast(p_objPrincipal, p_objRecord);
                if (lngRes < 1)
                {
                    throw new Exception("增加调转记录失败！");
                }

                // 4.修改入院登记表
                strSQL = @"UPDATE t_opr_bih_register t1
   SET t1.bedid_chr = ?,
       t1.operatorid_chr = ?
 WHERE t1.status_int = 1
   AND t1.registerid_chr = ?
   AND t1.bedid_chr = ?
   AND t1.areaid_chr = ?
   AND t1.pstatus_int NOT IN (0, 3)";
                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTARGETBEDID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strSOURCEBEDID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strSOURCEAREAID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改入院登记信息失败！");
                }
                objHRPSvc.Dispose();

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register set bedid_int = ? where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(2, out parm);
                        parm[0].Value = Convert.ToDecimal(p_objRecord.m_strTARGETBEDID_CHR);
                        parm[1].Value = Convert.ToDecimal(p_objRecord.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                    }
                }
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
        #endregion

        #region 包床
        /// <summary>
        /// 包床
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_strOperateID">操作员ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngWarpBed(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, string p_strBedID, string p_strOperateID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngWarpBed");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                // 1.新增包床记录
                string strSQL = @"INSERT INTO t_opr_bih_wrapbed
            (seq_int, registerid_chr, bedid_chr
            )
     VALUES (seq_t_opr_bih_wrapbed.NEXTVAL, ?, ?
            )";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;
                objLisAddItemRefArr[1].Value = p_strBedID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("新增包床记录失败！");
                }

                // 2.新增包床历史记录
                strSQL = @"INSERT INTO t_opr_bih_warpbedhistory
            (seq_int, registerid_chr, bedid_chr,
             start_dat, startoperatorid_chr
            )
     VALUES (seq_t_opr_bih_warpbedhistory.NEXTVAL, ?, ?,
             ?, ?
            )";
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;
                objLisAddItemRefArr[1].Value = p_strBedID;
                objLisAddItemRefArr[2].Value = DateTime.Now;
                objLisAddItemRefArr[3].Value = p_strOperateID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("新增包床历史记录失败！");
                }

                // 3.修改床位表
                strSQL = @"UPDATE t_bse_bed
   SET status_int = 4
 WHERE status_int = 1 AND bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strBedID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("床位被占用！");
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

        #region 撤消包床
        /// <summary>
        /// 撤消包床
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_strOperateID">操作人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUndoWarpBed(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBedID, string p_strOperateID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngUndoWarpBed");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                // 1.删除包床记录
                string strSQL = @"DELETE FROM t_opr_bih_wrapbed
      WHERE bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strBedID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("删除包床记录失败！该病人可能已经撤消包床");
                }

                // 2.修改包床历史记录
                strSQL = @"UPDATE t_opr_bih_warpbedhistory
                               SET end_dat = ?,
                                   endoperatorid_chr = ?
                             WHERE bedid_chr = ? AND endoperatorid_chr IS NULL";
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = DateTime.Now;
                objLisAddItemRefArr[1].Value = p_strOperateID;
                objLisAddItemRefArr[2].Value = p_strBedID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改包床历史记录失败！该病人可能已经撤消包床");
                }

                // 3.修改床位表
                strSQL = @"UPDATE t_bse_bed
   SET status_int = 1
 WHERE status_int = 4 AND bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strBedID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("修改床位表失败！该病人可能已经撤消包床");
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

        #region 请假
        /// <summary>
        /// 请假
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">请假VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHoliday(System.Security.Principal.IPrincipal p_objPrincipal, clsHolidayRecord_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngHoliday");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                // 1.新增请假记录
                string strSQL = @"INSERT INTO t_opr_bih_holidayrecord
            (seqid_int, registerid_chr,
             create_dat, creatorid_chr,
             start_dat, holidays_int, status_int
            )
     VALUES (seq_t_opr_bih_holidayrecord.NEXTVAL, ?,
             ?, ?,
             ?, ?, ?
            )";
                objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = DateTime.Now;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strCREATORID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_datSTART_DAT;
                objLisAddItemRefArr[4].Value = p_objRecord.m_intHOLIDAYS_INT;
                objLisAddItemRefArr[5].Value = p_objRecord.m_intSTATUS_INT;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("新增请假记录失败！");
                }

                // 2.修改入院登记表
                strSQL = @"UPDATE t_opr_bih_register
   SET pstatus_int = 4,
       operatorid_chr = ?
 WHERE pstatus_int = 1 AND registerid_chr = ? AND bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strCREATORID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strBedID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该病人不符合请假条件,修改入院登记表失败！");
                }

                // 3.撤消包床(如果存在包床的话)
                m_lngCancelWrapBed(p_objPrincipal, p_objRecord.m_strREGISTERID_CHR);
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

        #region 撤消请假
        /// <summary>
        /// 撤消请假
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">请假VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUndoHoliday(System.Security.Principal.IPrincipal p_objPrincipal, clsHolidayRecord_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngUndoHoliday");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRef = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                // 1.修改请假记录
                string strSQL = @"UPDATE t_opr_bih_holidayrecord
   SET status_int = ?,
       cancel_dat = ?,
       cancelerid_chr = ?
 WHERE status_int = 1 AND registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[1].Value = DateTime.Now;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strCANCELERID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strREGISTERID_CHR;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该病人不符合撤消请假条件,修改请假记录失败！");
                }

                // 2.修改入院登记表
                strSQL = @"UPDATE t_opr_bih_register
   SET pstatus_int = 1,
       operatorid_chr = ?
 WHERE pstatus_int = 4 AND registerid_chr = ? AND bedid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strCANCELERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strBedID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRef, objLisAddItemRefArr);
                if (lngRef < 1)
                {
                    throw new Exception("该病人不符合撤消请假条件,修改入院登记表失败！");
                }
                objHRPSvc.Dispose();

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
                        // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                        Sql = @"update t_ip_register set status_int = ? where registerid_int = ?";

                        clsHRPTableService emrSvc = new clsHRPTableService();
                        emrSvc.m_mthSetDataBase_Selector(1, 19);
                        System.Data.IDataParameter[] parm = null;
                        emrSvc.CreateDatabaseParameter(2, out parm);
                        parm[0].Value = 1;
                        parm[1].Value = Convert.ToDecimal(p_objRecord.m_strREGISTERID_CHR);
                        emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);

                    }
                }
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
        #endregion

        #region 根据入院登记ID撤消病人的包床
        /// <summary>
        /// 根据入院登记ID撤消病人的包床
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCancelWrapBed(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngCancelWrapBed");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                string strSQL = @"UPDATE t_bse_bed t1
                                   SET t1.status_int = 1,
                                       t1.bihregisterid_chr = NULL
                                 WHERE t1.status_int = 4
                                   AND EXISTS (
                                          SELECT 1
                                            FROM t_opr_bih_wrapbed t2
                                           WHERE t2.bedid_chr = t1.bedid_chr
                                             AND t2.registerid_chr = ?)";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);

                strSQL = @"DELETE      t_opr_bih_wrapbed t1
      WHERE t1.registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 根据病人姓名、性别查找历史信息
        /// <summary>
        ///根据病人姓名、性别查找历史信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="name">病人姓名/param>
        /// <param name="sex">性别</param>
        /// <param name="dt">性别</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetHisPatientByName(System.Security.Principal.IPrincipal p_objPrincipal, string name, string sex, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetRegisterInfoByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.registerid_chr, a.patientid_chr, a.inpatientid_chr, a.pstatus_int, a.inpatientcount_int, a.feestatus_int, 
                                   b.lastname_vchr, b.sex_chr, b.birth_dat, to_char(b.birth_dat, 'yyyy/mm/dd') as cssj,
                                   b.idcard_chr, to_char(a.inpatient_dat, 'yyyy/mm/dd hh24:mi:ss') as rysj, e.deptname_vchr, d.code_chr,
                                   to_char(c.modify_dat, 'yyyy/mm/dd hh24:mi:ss') as cysj, a.inpatientnotype_int, b.homeaddress_vchr, b.employer_vchr, f.patientcardid_chr   
                              from t_opr_bih_register a,
                                   t_opr_bih_registerdetail b,
                                   t_opr_bih_leave c,
                                   t_bse_bed d,
                                   t_bse_deptdesc e,
                                   t_bse_patientcard f    
                             where a.registerid_chr = d.bihregisterid_chr(+) and
                                   a.bedid_chr = d.bedid_chr(+) and
                                   d.areaid_chr = e.deptid_chr(+) and
                                   a.registerid_chr = b.registerid_chr and
                                   a.patientid_chr = f.patientid_chr and                     
                                   a.registerid_chr = c.registerid_chr and
                                   not exists (select g.inpatientid_chr from t_opr_bih_register g where a.inpatientid_chr =g.inpatientid_chr and g.PSTATUS_INT <>3) and
								   a.status_int = 1 and                               
								   c.status_int = 1 and
								   b.lastname_vchr = '" + name + @"' and 
								   b.sex_chr = '" + sex + @"' and
								   a.inpatientnotype_int = 1  
                           order by a.patientid_chr, a.inpatient_dat";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
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


        #region 根据入院登记ID判断病人是否存在转区或出院记录
        /// <summary>
        /// 根据入院登记ID判断病人是否存在转区或出院记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long CheckTranOrOut(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID)
        {
            DataTable p_dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "CheckTranOrOut");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT COUNT (TRANSFERID_CHR) rowcount
                              FROM T_OPR_BIH_TRANSFER
                             WHERE  TYPE_INT not in(1,2,5) and REGISTERID_CHR = ? ";

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;

                objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbRecord, objLisAddItemRefArr);
                lngRes = Convert.ToInt16(p_dtbRecord.Rows[0]["rowcount"].ToString());
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

        #region 根据入院登记ID获取病人最早的医嘱时间
        /// <summary>
        /// 根据入院登记ID获取病人最早的医嘱时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_strFirstOrderDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetFirstOrderDateByRegId(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out string p_strFirstOrderDate)
        {
            p_strFirstOrderDate = "";
            DataTable p_dtbRecord = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "GetFirstOrderDateByRegId");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT min(CREATEDATE_DAT) CREATEDATE_DAT
                              FROM T_OPR_BIH_ORDER
                             WHERE REGISTERID_CHR = ? ";

            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;

                objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbRecord, objLisAddItemRefArr);
                p_strFirstOrderDate = p_dtbRecord.Rows[0]["CREATEDATE_DAT"].ToString();
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

        #region 根据入院登记ID获取病人有效的病情信息
        /// <summary>
        /// 根据入院登记ID获取病人病情信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">病情信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientStateByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBIHPatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select STATE_INT from T_OPR_BIH_PATIENTSTATE where ACTIVE_INT = 1 and REGISTERID_CHR = ? ";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);


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

        #region 根据入院登记ID获取病人有效饮食护理信息
        /// <summary>
        /// 根据入院登记ID获取病人有效饮食护理信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">饮食护理信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPatientNurseByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "GetPatientEatByRegID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.SEQID_INT, a.REGISTERID_CHR, a.TYPE_INT, a.ORDERDICID_CHR, b.NAME_CHR 
                              from T_OPR_BIH_PATIENTNURSE a,
                                   T_BSE_BIH_ORDERDIC b 
                              where 
                                   a.ORDERDICID_CHR = b.ORDERDICID_CHR and
                                   a.ACTIVE_INT = 1 and 
                                   a.REGISTERID_CHR = ? ";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);


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

        #region 根据员工ID获取默认的科室
        /// <summary>
        /// 根据员工ID获取默认的科室
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtResult">默认科室信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetDeptByEmpID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "GetDeptByEmpID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.empid_chr, a.deptid_chr, a.default_dept_int
                                from t_bse_deptemp a
                                where a.default_dept_int = 1 
                                and a.empid_chr = ?";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strEmpID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    if (p_dtResult.Rows.Count == 0)
                    {
                        strSQL = @"select a.empid_chr, a.deptid_chr, a.default_dept_int
                                     from t_bse_deptemp a
                                    where rownum = 1 and a.empid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strEmpID;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);
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

        #region 根据病区Id获取父级部门ID
        /// <summary>
        /// 根据病区Id获取父级部门ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strParentId">父级部门ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetParentIdByDeptId(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, out string p_strParentId)
        {
            p_strParentId = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "GetDeptByEmpID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.PARENTID
                              from t_bse_deptdesc a
                              where 
                                   a.STATUS_INT = 1 and 
                                   a.DEPTID_CHR = ? ";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strDeptID;

                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    p_strParentId = dtResult.Rows[0]["PARENTID"].ToString().Trim();
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

        #region 获取序列的下一个值
        /// <summary>
        /// 获取序列的下一个值
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        private string GetNextSeq(string p_seqName)
        {
            long lngRes = 0;

            string strSQL;
            strSQL = @"SELECT " + p_seqName + ".NEXTVAL FROM dual";

            System.Data.DataTable dtbResult = new System.Data.DataTable();

            string newSeq = "0";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null)
                {
                    newSeq = dtbResult.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return newSeq;
        }
        #endregion

        #region 根据员工ID获取医院专业组信息
        /// <summary>
        /// 根据员工ID获取医院专业组信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtResult">医院专业组信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long GetGroupbyEmpID(string p_strEmpID, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "GetDeptByEmpID");
            //if (lngRes < 0)
            //{
            //    return -1;
            //}

            string strSQL = @"select t.empid_chr, t.groupid_chr
                                from t_bse_groupemp t
                               where t.begin_dat < sysdate
                                 and (t.end_dat > sysdate or t.end_dat is null)
                                 and t.empid_chr = ? ";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strEmpID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);


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

        #region 根据病人ID获取出院病人入院登记信息
        /// <summary>
        /// 根据病人ID获取出院病人入院登记信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strPStatus">病人状态</param>
        /// <param name="p_objResult">入院登记信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisterInfoByPatientID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, string p_strPStatus, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            p_objResult = new clsT_Opr_Bih_Register_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetRegisterInfoByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   t1.registerid_chr, t1.inpatientnotype_int, t1.inpatientid_chr,
                                       t1.inpatient_dat, t1.type_int, t1.areaid_chr,
                                       t2.deptname_vchr AS areaname, t4.code_chr, t1.mzdoctor_chr,
                                       t3.lastname_vchr AS mzdoctormane, t1.state_int, t1.limitrate_mny,
                                       t1.mzdiagnose_vchr, t1.des_vchr, t1.pstatus_int, t1.paytypeid_chr,
                                       inpatientcount_int
                                  FROM t_opr_bih_register t1,
                                       t_bse_deptdesc t2,
                                       t_bse_employee t3,
                                       t_bse_bed t4
    
                                       --(select * from T_OPR_BIH_PATIENTSTATE where ACTIVE_INT = 1) t5
                                 WHERE t1.areaid_chr = t2.deptid_chr(+) AND
                                    t1.mzdoctor_chr = t3.empid_chr(+) AND
                                    t1.bedid_chr = t4.bedid_chr(+) AND
                                  -- t1.registerid_chr = t5.registerid_chr(+) AND
                                  -- t5.ACTIVE_INT = 1 AND
                                    t1.pstatus_int = 3 AND
                                    t1.status_int = 1 AND
                                    t1.patientid_chr = ? ";
            try
            {
                DataTable dtbResult = new DataTable();

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strPatientID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["registerid_chr"].ToString().Trim();
                    p_objResult.m_intINPATIENTNOTYPE_INT = Convert.ToInt16(dtbResult.Rows[0]["inpatientnotype_int"]);
                    p_objResult.m_strINPATIENTID_CHR = dtbResult.Rows[0]["inpatientid_chr"].ToString().Trim();
                    p_objResult.m_strINPATIENT_DAT = dtbResult.Rows[0]["inpatient_dat"].ToString().Trim();
                    p_objResult.m_intTYPE_INT = Convert.ToInt16(dtbResult.Rows[0]["type_int"]);
                    p_objResult.m_strAREAID_CHR = dtbResult.Rows[0]["areaid_chr"].ToString().Trim();
                    p_objResult.m_strAreaName = dtbResult.Rows[0]["areaname"].ToString().Trim();
                    p_objResult.m_strBedNo = dtbResult.Rows[0]["code_chr"].ToString().Trim();
                    p_objResult.m_strMZDOCTOR_CHR = dtbResult.Rows[0]["mzdoctor_chr"].ToString().Trim();
                    p_objResult.m_stroutdoctorname = dtbResult.Rows[0]["mzdoctormane"].ToString().Trim();

                    if (dtbResult.Rows[0]["state_int"] != DBNull.Value)
                    {
                        p_objResult.m_intSTATE_INT = Convert.ToInt16(dtbResult.Rows[0]["state_int"]);
                    }

                    if (dtbResult.Rows[0]["limitrate_mny"] != DBNull.Value)
                    {
                        p_objResult.m_dblLIMITRATE_MNY = Convert.ToDouble(dtbResult.Rows[0]["limitrate_mny"]);
                    }
                    p_objResult.m_strMZDIAGNOSE_VCHR = dtbResult.Rows[0]["mzdiagnose_vchr"].ToString().Trim();
                    p_objResult.DES_VCHR = dtbResult.Rows[0]["des_vchr"].ToString().Trim();
                    p_objResult.m_intPSTATUS_INT = Convert.ToInt16(dtbResult.Rows[0]["pstatus_int"]);
                    p_objResult.m_strPAYTYPEID_CHR = dtbResult.Rows[0]["paytypeid_chr"].ToString().Trim();
                    p_objResult.m_intINPATIENTCOUNT_INT = Convert.ToInt16(dtbResult.Rows[0]["inpatientcount_int"]);
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


        //////////////////////////////////////////////////
        //转出时对包床进行操作 2007.09.03 谢云杰添加
        /////////////////////////////////////////////////

        #region 检查病人转出时还是否存在包床
        /// <summary>
        /// 检查病人转出时还是否存在包床
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="intRowCount"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWarpBedByRegID(string p_strRegisterID, ref int intRowCount)
        {
            string strSQL = "select a.seq_int from t_opr_bih_wrapbed a where a.registerid_chr= ? ";
            long lngRes = -1;
            DataTable dtValues = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] Param = null;
                objHRPSvc.CreateDatabaseParameter(1, out Param);
                Param[0].Value = p_strRegisterID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValues, Param);

                if (lngRes > 0 && dtValues != null)
                {
                    intRowCount = dtValues.Rows.Count;
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

        #region 撤消病人的所有包床
        /// <summary>
        /// 撤消病人的所有包床
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strOperateID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUndoWarpBedByRegID(string p_strRegisterID, string p_strOperateID)
        {
            long lngRes = -1;
            long lngAfterEffect = 0;
            string strSQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] Param = null;
                strSQL = @"update t_opr_bih_warpbedhistory set end_dat = ?, endoperatorid_chr = ? where registerid_chr = ? and endoperatorid_chr is null";
                objHRPSvc.CreateDatabaseParameter(3, out Param);
                Param[0].Value = DateTime.Now;
                Param[1].Value = p_strOperateID;
                Param[2].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAfterEffect, Param);

                strSQL = @"update t_bse_bed t1
                              set t1.status_int = 1,
                                  t1.bihregisterid_chr = null
                            where t1.status_int = 4
                              and t1.bedid_chr in (select t2.bedid_chr
                                                 from t_opr_bih_wrapbed t2
                                                where t2.registerid_chr = ?)";
                objHRPSvc.CreateDatabaseParameter(1, out Param);
                Param[0].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAfterEffect, Param);

                strSQL = @"delete from t_opr_bih_wrapbed a where a.registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out Param);
                Param[0].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAfterEffect, Param);

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


        #region 获取病人在门诊未交费处方
        /// <summary>
        /// 获取病人在门诊未交费处方
        /// </summary>
        /// <param name="p_strPaitneNo">住院号或诊疗号</param>
        /// <param name="p_intType">1为住院号,2为诊疗号查询</param>
        /// <param name="p_lstRecipeNoPay_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientRecipeNopay(string p_strPaitneNo, int p_intType, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            long lngRes = 0;
            string strSQL = "";
            p_lstRecipeNoPay_VO = new System.Collections.Generic.List<clsRecipeNoPay_VO>();
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] parmArr = null;
            try
            {
                //1为住院号查询
                if (p_intType == 1)
                {
                    strSQL = @"select t1.outpatrecipeid_chr,
       t1.patientid_chr,
       t1.createdate_dat,
       t1.registerid_chr,
       t1.diagdr_chr,
       t1.diagdept_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.recipeflag_int,
       t1.pstauts_int,
       t1.outpatrecipeno_vchr,
       t1.casehisid_chr,
       t2.inpatientid_chr,
       t2.lastname_vchr,
       t2.sex_chr
  from t_opr_outpatientrecipe t1, t_bse_patient t2
 where t2.patientid_chr = t1.patientid_chr
   and t1.pstauts_int = 4
   and t2.inpatientid_chr = ?";
                }
                //2为诊疗号查询
                else if (p_intType == 2)
                {
                    strSQL = @"select t1.outpatrecipeid_chr,
       t1.patientid_chr,
       t1.createdate_dat,
       t1.registerid_chr,
       t1.diagdr_chr,
       t1.diagdept_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.recipeflag_int,
       t1.pstauts_int,
       t1.outpatrecipeno_vchr,
       t1.casehisid_chr,
       t2.inpatientid_chr,
       t2.lastname_vchr,
       t2.sex_chr

  from t_opr_outpatientrecipe t1, t_bse_patient t2, t_bse_patientcard t3
 where t2.patientid_chr = t1.patientid_chr
   and t2.patientid_chr = t3.patientid_chr
   and t1.pstauts_int = 4
   and t3.patientcardid_chr =?";


                }
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out parmArr);
                parmArr[0].Value = p_strPaitneNo;
                DataTable m_dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbResult, parmArr);
                if (lngRes > 0 && m_dtbResult.Rows.Count > 0)
                {
                    int intRowCount = m_dtbResult.Rows.Count;
                    DataRow drResult = null;
                    for (int i = 0; i < intRowCount; i++)
                    {
                        drResult = m_dtbResult.Rows[i];
                        clsRecipeNoPay_VO objTempVO = new clsRecipeNoPay_VO();
                        objTempVO.m_strRecipeid = drResult["outpatrecipeid_chr"].ToString();
                        objTempVO.m_strPatientid_chr = drResult["patientid_chr"].ToString();
                        objTempVO.m_dtmCreatedate = DateTime.Parse(drResult["createdate_dat"].ToString());
                        objTempVO.m_strRegisterid = drResult["registerid_chr"].ToString().Trim();
                        objTempVO.m_strDiagdr = drResult["diagdr_chr"].ToString();
                        objTempVO.m_strDiagdept = drResult["diagdept_chr"].ToString();
                        objTempVO.m_strRecordemp = drResult["recordemp_chr"].ToString();
                        objTempVO.m_dtmRecorddate = DateTime.Parse(drResult["recorddate_dat"].ToString());
                        objTempVO.m_intRecipeflag = int.Parse(drResult["recipeflag_int"].ToString().Trim());
                        objTempVO.m_intPstatus = int.Parse(drResult["pstauts_int"].ToString().Trim());
                        objTempVO.m_strOutpatrecipeno = drResult["outpatrecipeno_vchr"].ToString();
                        objTempVO.m_strCasehisid = drResult["casehisid_chr"].ToString();
                        objTempVO.m_strInpatientid = drResult["inpatientid_chr"].ToString();
                        objTempVO.m_strName = drResult["lastname_vchr"].ToString();
                        objTempVO.m_strSex = drResult["sex_chr"].ToString();
                        p_lstRecipeNoPay_VO.Add(objTempVO);
                    }
                    m_dtbResult.Dispose();
                    m_dtbResult = null;
                }

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

                parmArr = null;
                strSQL = null;
            }
            return lngRes;

        }
        #endregion

        #region 查询未交费用处方表信息
        /// <summary>
        /// 查询未交费用处方表信息
        /// </summary>
        /// <param name="p_strPaitneNo">住院号或诊疗号</param>
        /// <param name="p_intType">1为住院号,2为诊疗号查询</param>
        /// <param name="p_lstRecipeNoPay_VO">返回VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientRecipeNopayZY(string p_strPaitneNo, int p_intType, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            long lngRes = 0;
            string strSQL = "";
            p_lstRecipeNoPay_VO = new System.Collections.Generic.List<clsRecipeNoPay_VO>();
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] parmArr = null;
            try
            {
                //1为住院号查询
                if (p_intType == 1)
                {
                    strSQL = @"select t1.outpatrecipeid_chr,
       t1.patientid_chr,
       t1.createdate_dat,
       t1.registerid_chr,
       t1.diagdr_chr,
       t1.diagdept_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.recipeflag_int,
       t1.pstatus_int,
       t1.outpatrecipeno_vchr,
       t1.casehisid_chr,
       t2.inpatientid_chr,
       t2.lastname_vchr,
       t2.sex_chr
  from t_opr_bih_recipenopay t1, t_bse_patient t2
 where t2.patientid_chr = t1.patientid_chr
   and t1.pstatus_int = 4
   and t2.inpatientid_chr =?";
                }
                //2为诊疗号查询
                else if (p_intType == 2)
                {
                    strSQL = @"select t1.outpatrecipeid_chr,
       t1.patientid_chr,
       t1.createdate_dat,
       t1.registerid_chr,
       t1.diagdr_chr,
       t1.diagdept_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.recipeflag_int,
       t1.pstatus_int,
       t1.outpatrecipeno_vchr,
       t1.casehisid_chr,
       t2.inpatientid_chr,
       t2.lastname_vchr,
       t2.sex_chr

  from t_opr_bih_recipenopay t1, t_bse_patient t2, t_bse_patientcard t3
 where t2.patientid_chr = t1.patientid_chr
   and t2.patientid_chr = t3.patientid_chr
   and t1.pstatus_int = 4
   and t3.patientcardid_chr =?";


                }
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out parmArr);
                parmArr[0].Value = p_strPaitneNo;
                DataTable m_dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbResult, parmArr);
                if (lngRes > 0 && m_dtbResult.Rows.Count > 0)
                {
                    int intRowCount = m_dtbResult.Rows.Count;
                    DataRow drResult = null;
                    for (int i = 0; i < intRowCount; i++)
                    {
                        drResult = m_dtbResult.Rows[i];
                        clsRecipeNoPay_VO objTempVO = new clsRecipeNoPay_VO();
                        objTempVO.m_strRecipeid = drResult["outpatrecipeid_chr"].ToString();
                        objTempVO.m_strPatientid_chr = drResult["patientid_chr"].ToString();
                        objTempVO.m_dtmCreatedate = DateTime.Parse(drResult["createdate_dat"].ToString());
                        objTempVO.m_strRegisterid = drResult["registerid_chr"].ToString().Trim();
                        objTempVO.m_strDiagdr = drResult["diagdr_chr"].ToString();
                        objTempVO.m_strDiagdept = drResult["diagdept_chr"].ToString();
                        objTempVO.m_strRecordemp = drResult["recordemp_chr"].ToString();
                        objTempVO.m_dtmRecorddate = DateTime.Parse(drResult["recorddate_dat"].ToString());
                        objTempVO.m_intRecipeflag = int.Parse(drResult["recipeflag_int"].ToString().Trim());
                        objTempVO.m_intPstatus = int.Parse(drResult["pstatus_int"].ToString().Trim());
                        objTempVO.m_strOutpatrecipeno = drResult["outpatrecipeno_vchr"].ToString();
                        objTempVO.m_strCasehisid = drResult["casehisid_chr"].ToString();
                        objTempVO.m_strInpatientid = drResult["inpatientid_chr"].ToString();
                        objTempVO.m_strName = drResult["lastname_vchr"].ToString();
                        objTempVO.m_strSex = drResult["sex_chr"].ToString();
                        p_lstRecipeNoPay_VO.Add(objTempVO);
                    }
                    m_dtbResult.Dispose();
                    m_dtbResult = null;
                }

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

                parmArr = null;
                strSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 关联未交费用处方号到住院信息表里
        /// <summary>
        /// 关联未交费用处方号到住院信息表里
        /// </summary>
        /// <param name="p_lstRecipeNoPay_VO">需关联的数据VO LIST</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertPatientNopayRecipeZY(System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            long lngRes = 0;
            long lngf = 0;
            string strSQL = @"insert into t_opr_bih_recipenopay
  (sedid,
   outpatrecipeid_chr,
   patientid_chr,
   createdate_dat,
   registerid_chr,
   diagdr_chr,
   diagdept_chr,
   recordemp_chr,
   recorddate_dat,
   recipeflag_int,
   pstatus_int,
   outpatrecipeno_vchr,
   casehisid_chr,
   inpatientid_chr)
values
  (seq_recipenopay.nextval, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)
";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] parmArr = null;
            try
            {

                int intLstCount = p_lstRecipeNoPay_VO.Count;
                DbType[] dbTypeArr = new DbType[] { DbType.String, DbType.String, DbType.Date, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime, DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.String };
                int intDBTypeLen = dbTypeArr.Length;
                object[][] objvalueArr = new object[intDBTypeLen][];
                for (int intX = 0; intX < intDBTypeLen; intX++)
                {
                    objvalueArr[intX] = new object[intLstCount];
                }
                clsRecipeNoPay_VO objRecipeNoPay_vo = null;
                int intK = 0;
                for (int intY = 0; intY < intLstCount; intY++)
                {
                    intK = 0;
                    objRecipeNoPay_vo = p_lstRecipeNoPay_VO[intY];
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strRecipeid;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strPatientid_chr;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_dtmCreatedate.Date;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strRegisterid.Trim();
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strDiagdr;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strDiagdept;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strRecordemp;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_dtmRecorddate;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_intRecipeflag;
                    objvalueArr[intK++][intY] = 4;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strOutpatrecipeno;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strCasehisid;
                    objvalueArr[intK++][intY] = objRecipeNoPay_vo.m_strInpatientid;



                }
                objRecipeNoPay_vo = null;

                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objvalueArr, dbTypeArr);
                objvalueArr = null;
                dbTypeArr = null;

                #region 无效
                //objHRPSvc = new clsHRPTableService();
                //objHRPSvc.CreateDatabaseParameter(12, out parmArr);
                //int intLstCount = p_lstRecipeNoPay_VO.Count;
                //clsRecipeNoPay_VO objRecipeNoPay_vo = null;
                //for (int i = 0; i < intLstCount;i++ )
                //{
                //    objRecipeNoPay_vo = p_lstRecipeNoPay_VO[i];
                //    parmArr[0].Value = objRecipeNoPay_vo.m_strRecipeid;
                //     parmArr[1].Value = objRecipeNoPay_vo.m_strPatientid_chr;
                //     parmArr[2].DbType = DbType.Date;
                //    parmArr[2].Value = objRecipeNoPay_vo.m_dtmCreatedate.Date;
                //    parmArr[3].Value = objRecipeNoPay_vo.m_strRegisterid.Trim();
                //    parmArr[4].Value  = objRecipeNoPay_vo.m_strDiagdr;
                //    parmArr[5].Value = objRecipeNoPay_vo.m_strDiagdept;
                //    parmArr[6].Value  = objRecipeNoPay_vo.m_strRecordemp;
                //    parmArr[7].DbType = DbType.DateTime;
                //    parmArr[7].Value  = objRecipeNoPay_vo.m_dtmRecorddate;
                //    parmArr[8].DbType = DbType.Int32;
                //     parmArr[8].Value = objRecipeNoPay_vo.m_intRecipeflag;
                //     parmArr[9].DbType = DbType.Int32;
                //     parmArr[9].Value = 4;
                //   parmArr[10].Value  = objRecipeNoPay_vo.m_strOutpatrecipeno;
                //   parmArr[11].Value = objRecipeNoPay_vo.m_strCasehisid;
                //   lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngf, parmArr);
                //}
                #endregion

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
                p_lstRecipeNoPay_VO.Clear();
                p_lstRecipeNoPay_VO = null;

            }
            return lngRes;
        }
        #endregion

        #region 重算病人门诊未交费用处方
        /// <summary>
        /// 重算病人门诊未交费用处方
        /// </summary>
        /// <param name="p_strPatientNO">住院号或诊疗号</param>
        /// <param name="p_intType">1为住院号,2为诊疗号查询</param>
        /// <param name="p_lstNoPayRecipe">处方ID</param>
        /// <param name="p_lstRecipeNoPay_VO">新的未交费处方VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReSetPatientNoPayRecipe(string p_strPatientNO, int p_intType, System.Collections.Generic.List<string> p_lstNoPayRecipe, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            long lngRes = 0;
            long lngAff = 0;
            p_lstRecipeNoPay_VO = new System.Collections.Generic.List<clsRecipeNoPay_VO>();
            System.Text.StringBuilder strbNoPayRecipeId = new System.Text.StringBuilder();
            int intCount = p_lstNoPayRecipe.Count;
            for (int i1 = 0; i1 < intCount; i1++)
            {
                strbNoPayRecipeId.Append("'");
                strbNoPayRecipeId.Append(p_lstNoPayRecipe[i1].Trim());
                strbNoPayRecipeId.Append("',");
            }
            string strNoPayRecipeId = strbNoPayRecipeId.ToString().TrimEnd(',');
            strbNoPayRecipeId = null;
            string strSQL = @"select t1.outpatrecipeid_chr
  from t_opr_outpatientrecipe t1
 where t1.pstauts_int <> 4
   and t1.outpatrecipeid_chr in ([outpatrecipeid_chr])";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] parmArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                DataTable dtbTemp = new DataTable();
                strSQL = strSQL.Replace("[outpatrecipeid_chr]", strNoPayRecipeId);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbTemp);
                if (lngRes > 0 && dtbTemp.Rows.Count > 0)
                {
                    strSQL = @"update t_opr_bih_recipenopay t
   set t.pstatus_int = 1
 where t.outpatrecipeid_chr =?
";
                    intCount = dtbTemp.Rows.Count;
                    objHRPSvc.CreateDatabaseParameter(1, out parmArr);

                    for (int i2 = 0; i2 < intCount; i2++)
                    {
                        parmArr[0].Value = dtbTemp.Rows[i2]["outpatrecipeid_chr"].ToString();
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, parmArr);



                    }

                }
                lngRes = this.m_lngGetPatientRecipeNopayZY(p_strPatientNO, p_intType, out p_lstRecipeNoPay_VO);

                dtbTemp.Dispose();
                dtbTemp = null;

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
                parmArr = null;
                strSQL = null;
                strNoPayRecipeId = null;
                p_lstNoPayRecipe.Clear();
                p_lstNoPayRecipe = null;

            }
            return lngRes;
        }
        #endregion
    }
}
