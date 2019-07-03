using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Collections;
using System.Data;
using System.Text;
using System.IO;
namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    /// <summary>
    /// clsRegisterSvc 的摘要说明。
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRegisterSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsRegisterSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 查出能否做一些系统设置的操作
        [AutoComplete]
        public bool m_mthIsCanDo(string p_flag)
        {
            bool ret = false;
            string strSQL = @"select a.setid_chr, a.setname_vchr, a.setdesc_vchr, a.setstatus_int,
       a.moduleid_chr
  from t_sys_setting a
 where a.setid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dt = new DataTable();
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = p_flag;
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "1")
                    {
                        ret = true;
                    }
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

        #region 查询病人信息
        [AutoComplete]
        public long m_lngFindPatient(System.Security.Principal.IPrincipal p_objPrincipal, string strName, string Sex, string brith, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngFindPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strwhere = "";
            if (Sex != "")
            {
                strwhere = " and a.SEX_CHR='" + Sex + "'";
            }

            string strSQL = @"select b.PATIENTCARDID_CHR,a.LASTNAME_VCHR,a.SEX_CHR,a.BIRTH_DAT,a.HOMEADDRESS_VCHR,a.HOMEPHONE_VCHR,a.IDCARD_CHR  from t_bse_patient a,t_bse_patientcard b where  a.LASTNAME_VCHR like '" + strName + "%' and a.PATIENTID_CHR=b.PATIENTID_CHR  and b.STATUS_INT!=0" + strwhere;
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
            return lngRes;
        }
        #endregion

        #region 病人信息登记事务
        [AutoComplete]
        public long m_lngPatientAffair(System.Security.Principal.IPrincipal p_objPrincipal, com.digitalwave.iCare.ValueObject.clsclsPatientIdxVO objPatienIdxVO, com.digitalwave.iCare.ValueObject.clsPatient_VO objPatienVO, com.digitalwave.iCare.ValueObject.clsPatientCardVO objPatienCardVO, out string cardId, out string patientID)
        {


            //病人索引表
            long lngRes = 0;
            lngRes = m_lngAddNewPatientIdx(p_objPrincipal, out objPatienIdxVO.m_strPATIENTID_CHR, objPatienIdxVO);
            objPatienVO.m_strPATIENTID_CHR = objPatienIdxVO.m_strPATIENTID_CHR;

            //病人信息表

            lngRes = m_lngAddNewPatient(p_objPrincipal, out objPatienVO.m_strPATIENTID_CHR, objPatienVO);
            patientID = objPatienVO.m_strPATIENTID_CHR;
            objPatienCardVO.m_strPATIENTID_CHR = objPatienVO.m_strPATIENTID_CHR;

            //病人卡号表

            lngRes = m_lngAddNewPatientCard(p_objPrincipal, out cardId, objPatienCardVO);
            if (lngRes == -2)
            {
                throw new Exception("卡号已经被占用！");
            }
            return lngRes;
        }
        #endregion
        #region 增加病人基本资料索引表 zlc 2004 - 7-21
        /// <summary>
        /// 增加病人基本资料索引表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewPatientIdx(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsclsPatientIdxVO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_PATIENTIDX", "PATIENTID_CHR", out p_strRecordID);
            //if (lngRes < 0)
            //    return lngRes;

            //序列ID               
            DataTable dt1 = new DataTable();
            string SQL = @"select lpad (seq_patientidxid.nextval, 10, '0')
  from dual";
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt1);
            if (lngRes > 0)
            {
                p_strRecordID = dt1.Rows[0][0].ToString();
            }

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"insert into t_bse_patientidx
            (patientid_chr, inpatientid_chr, idcard_chr, homeaddress_vchr,
             sex_chr, birth_dat, name_vchr, homephone_vchr, insuranceid_vchr,
             difficulty_vchr, govcard_chr
            )
     values (?, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(11, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;
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
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region 增加病人基本资料 zlc 2004-7-21
        /// <summary>
        /// 增加病人基本资料
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewPatient(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsPatient_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = p_objRecord.m_strPATIENTID_CHR;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            long lngRecEff = -1;
            #region iCare增加病人
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //			lngRes = objHRPSvc.lngGenerateID(10,"PATIENTID_CHR","T_BSE_PATIENT",out p_strRecordID);
            //			if(lngRes < 0)
            //				return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_BSE_PATIENT (PATIENTID_CHR,INPATIENTID_CHR,LASTNAME_VCHR,IDCARD_CHR,MARRIED_CHR,BIRTHPLACE_VCHR,HOMEADDRESS_VCHR,SEX_CHR,NATIONALITY_VCHR,FIRSTNAME_VCHR,BIRTH_DAT,RACE_VCHR,NATIVEPLACE_VCHR,OCCUPATION_VCHR,NAME_VCHR,HOMEPHONE_VCHR,OFFICEPHONE_VCHR,INSURANCEID_VCHR,MOBILE_CHR,OFFICEADDRESS_VCHR,EMPLOYER_VCHR,OFFICEPC_VCHR,HOMEPC_CHR,EMAIL_VCHR,CONTACTPERSONFIRSTNAME_VCHR,CONTACTPERSONLASTNAME_VCHR,CONTACTPERSONADDRESS_VCHR,CONTACTPERSONPHONE_VCHR,CONTACTPERSONPC_CHR,PATIENTRELATION_VCHR,FIRSTDATE_DAT,ISEMPLOYEE_INT,STATUS_INT,DEACTIVATE_DAT,OPERATORID_CHR,MODIFY_DAT,PAYTYPEID_CHR,GOVCARD_CHR,BLOODTYPE_CHR,IFALLERGIC_INT,ALLERGICDESC_VCHR,DIFFICULTY_VCHR) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(42, out objLisAddItemRefArr);
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
                objLisAddItemRefArr[25].Value = p_objRecord.m_strCONTACTPERSONLASTNAME_VCHR;
                objLisAddItemRefArr[26].Value = p_objRecord.m_strCONTACTPERSONADDRESS_VCHR;
                objLisAddItemRefArr[27].Value = p_objRecord.m_strCONTACTPERSONPHONE_VCHR;
                objLisAddItemRefArr[28].Value = p_objRecord.m_strCONTACTPERSONPC_CHR;
                objLisAddItemRefArr[29].Value = p_objRecord.m_strPATIENTRELATION_VCHR;
                objLisAddItemRefArr[30].Value = DateTime.Parse(p_objRecord.m_strFIRSTDATE_DAT);
                objLisAddItemRefArr[31].Value = p_objRecord.m_intISEMPLOYEE_INT;
                objLisAddItemRefArr[32].Value = p_objRecord.m_intSTATUS_INT;
                try
                {
                    objLisAddItemRefArr[33].Value = DateTime.Parse(p_objRecord.m_strDEACTIVATE_DAT);
                }
                catch
                {
                    objLisAddItemRefArr[33].Value = null;
                }
                objLisAddItemRefArr[34].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[35].Value = DateTime.Parse(p_objRecord.m_strMODIFY_DAT);
                objLisAddItemRefArr[36].Value = p_objRecord.m_strPAYTYPEID_CHR;

                objLisAddItemRefArr[37].Value = p_objRecord.m_strGOVCARD_CHR;
                objLisAddItemRefArr[38].Value = p_objRecord.m_strBLOODTYPE_CHR;
                objLisAddItemRefArr[39].Value = p_objRecord.m_intIFALLERGIC_INT;
                objLisAddItemRefArr[40].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[41].Value = p_objRecord.m_strDIFFICULTY_VCHR;

                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region  增加病人卡记录 zlc -7-21
        /// <summary>
        /// 增加病人卡记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">返回病人卡号</param>
        /// <param name="p_objRecord">号信息</param>
        /// <returns>返回-2输入的病人卡号已经被占用</returns>
        [AutoComplete]
        public long m_lngAddNewPatientCard(System.Security.Principal.IPrincipal p_objPrincipal, out string CardId, clsPatientCardVO p_objRecord)
        {
            long lngRes = 0;
            if (p_objRecord.m_intSTATUS_INT == 3)
                CardId = null;
            else
                CardId = p_objRecord.m_strPATIENTCARDID_CHR;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewPatientCard");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "";
            if (p_objRecord.m_intSTATUS_INT == 3)
            {
                lngRes = objHRPSvc.lngGenerateID(10, "PATIENTCARDID_CHR", "T_BSE_PATIENTCARD", out CardId);
                if (lngRes < 0)
                    return lngRes;
                if (Convert.ToInt64(CardId) < 8000000000)
                    CardId = "8000000000";
            }
            else
            {
                strSQL = @"select patientcardid_chr
                           from t_bse_patientcard
                           where patientcardid_chr = ? and status_int != 0";
                DataTable dt = new DataTable();
                try
                {
                    System.Data.IDataParameter[] param = null;
                    objHRPSvc.CreateDatabaseParameter(1, out param);
                    param[0].Value = CardId;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);


                }
                if (dt.Rows.Count > 0)
                {
                    return -2;
                }


            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strSQL = @"insert into t_bse_patientcard
            (patientcardid_chr, patientid_chr, issue_date, status_int
            )
             values (?, ?, ?, ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = CardId;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[2].Value = DateTime.Parse(strDateTime);
                objLisAddItemRefArr[3].Value = p_objRecord.m_intSTATUS_INT;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region 增加一个挂号
        /// <summary>
        /// 增加一个挂号
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="objResult"></param>
        /// <param name="strID"></param>
        /// <param name="strNo"></param>
        /// <param name="strOrderNo"></param>
        /// <param name="strRegCount"></param>
        /// <returns>返回-2保存失败输入的病人卡号已经被占用</returns>
        [AutoComplete]
        public long m_lngAddNewPatientRegister(System.Security.Principal.IPrincipal objPri, clsPatientRegister_VO objResult,
            out string strID, out string strNo, out string strOrderNo, out string strRegCount, clsPatient_VO clsPatientvo, int isNewPatient, string strCardID, out string outCardID, clsPatientDetail_VO[] PatientDetail_VO, string paytypeid, string patientidentityno)
        {
            long lngRes = 0;
            strID = "";
            strNo = "";
            strOrderNo = "";
            strRegCount = "0";
            outCardID = "";
            string CardID = "";
            string PatientID = "";

            //权限类
            //clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            /*lngRes = objPrivilege.m_lngCheckCallPrivilege(objPri,"com.digitalwave.iCare.middletier.HIS.clsRegisterSvc","m_lngAddNewPatientRegister");
            if(lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            */

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
            string strSQL = "";
            #region 如果是新病人则登记病人信息
            if (isNewPatient == 1)
            {
                clsclsPatientIdxVO p_objRecord = new clsclsPatientIdxVO();
                p_objRecord.m_strBIRTH_DAT = clsPatientvo.strBirthDate;
                p_objRecord.m_strDIFFICULTY_VCHR = clsPatientvo.m_strDIFFICULTY_VCHR;
                p_objRecord.m_strGOVCARD_CHR = clsPatientvo.m_strGOVCARD_CHR;
                p_objRecord.m_strHOMEADDRESS_VCHR = clsPatientvo.m_strHOMEADDRESS_VCHR;
                p_objRecord.m_strHOMEPHONE_VCHR = clsPatientvo.m_strHOMEPHONE_VCHR;
                p_objRecord.m_strINSURANCEID_VCHR = clsPatientvo.m_strINSURANCEID_VCHR;
                p_objRecord.m_strNAME_VCHR = clsPatientvo.m_strLASTNAME_VCHR;
                p_objRecord.m_strSEX_CHR = clsPatientvo.m_strSEX_CHR;
                clsPatientCardVO CardVO = new clsPatientCardVO();
                CardVO.m_strISSUE_DATE = clsPatientvo.m_strFIRSTDATE_DAT;

                if (strCardID == "")
                {
                    CardVO.m_intSTATUS_INT = 3;
                }
                else
                {
                    CardVO.m_strPATIENTCARDID_CHR = strCardID;
                    CardVO.m_intSTATUS_INT = 1;
                }
                try
                {
                    lngRes = m_lngPatientAffair(objPri, p_objRecord, clsPatientvo, CardVO, out CardID, out PatientID);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                    return lngRes;
                }
                objResult.m_objPatientCard.m_strCardID = CardID;
                objResult.m_strPatient = PatientID;
            }
            else //修改病人公费、医保、特困号信息
            {
                if (clsPatientvo.m_intERNALFLAG_INT != 0)
                {
                    switch (clsPatientvo.m_intERNALFLAG_INT)
                    {
                        case 1:
                            strSQL = @"update T_BSE_PATIENT set GOVCARD_CHR='" + clsPatientvo.m_strGOVCARD_CHR + "' where PATIENTID_CHR='" + objResult.m_strPatient + "'";
                            break;
                        case 2:
                            strSQL = @"update T_BSE_PATIENT set INSURANCEID_VCHR='" + clsPatientvo.m_strINSURANCEID_VCHR + "' where PATIENTID_CHR='" + objResult.m_strPatient + "'";
                            break;
                        case 3:
                            strSQL = @"update T_BSE_PATIENT set DIFFICULTY_VCHR='" + clsPatientvo.m_strDIFFICULTY_VCHR + "' where PATIENTID_CHR='" + objResult.m_strPatient + "'";
                            break;
                    }
                    try
                    {
                        objSvc.DoExcute(strSQL);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }

                }
            }

            //处理患者身份对应号表    
            if (paytypeid != "")
            {
                if (patientidentityno.Trim() == "")
                {
                    patientidentityno = " ";
                }

                strSQL = "delete from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ? ";
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = objResult.m_strPatient;
                paramArr[1].Value = paytypeid;
                long lngRecordsAffected = -1;
                lngRes = objSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

                strSQL = @"insert into t_bse_patientidentityno(patientid_chr, paytypeid_chr, idno_vchr)
                                                values (?,?,?)";
                paramArr = null;
                objSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = objResult.m_strPatient;
                paramArr[1].Value = paytypeid;
                paramArr[2].Value = patientidentityno;

                lngRecordsAffected = -1;
                lngRes = objSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
            }
            #endregion

            outCardID = objResult.m_objPatientCard.m_strCardID;
            DataTable dt = new DataTable();
            #region

            //挂号流水号
            string p_strREGISTERNO = "";
            strSQL = @"SELECT MAX (registerno_chr) as  registerno
                     FROM t_opr_patientregister 
                     WHERE registerdate_dat = to_date('" + objResult.m_strRegisterDate + "','yyyy-MM-dd')";
            try
            {
                objSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["registerno"] != System.DBNull.Value)
                {
                    long dblregisterno = Convert.ToInt64(dt.Rows[0]["registerno"].ToString().Trim()) + 1;
                    p_strREGISTERNO = dblregisterno.ToString();
                }
                else
                {
                    p_strREGISTERNO = DateTime.Parse(objResult.m_strRegisterDate).Year.ToString() + DateTime.Parse(objResult.m_strRegisterDate).Month.ToString("00") + DateTime.Parse(objResult.m_strRegisterDate).Date.ToString("00") + "00001";
                }
            }
            else
            {
                p_strREGISTERNO = DateTime.Parse(objResult.m_strRegisterDate).Year.ToString() + DateTime.Parse(objResult.m_strRegisterDate).Month.ToString("00") + DateTime.Parse(objResult.m_strRegisterDate).Date.ToString("00") + "00001";
            }

            #region 写入挂号表数据
            string p_strREGISTERID = "";
            if (objResult.m_objPatientCard.m_strCardID == "")
            {
                System.IO.File.Copy(@"D:\code\log.txt", @"C:\log.txt", true);
                throw new Exception(@"挂号系统出现严重的错误，请把'D:\code\log.txt'文件保存并发给实施人员处理！！");
            }
            //lngRes = objSvc.m_lngGenerateNewID("t_opr_patientregister", "REGISTERID_CHR", out p_strREGISTERID);
            strSQL = @"select seq_oppateintregister.nextval
                       from dual";
            DataTable m_objtempTabled = new DataTable();
            try
            {
 
                lngRes=objSvc.DoGetDataTable(strSQL, ref m_objtempTabled);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (m_objtempTabled.Rows.Count > 0)
            {
                p_strREGISTERID = m_objtempTabled.Rows[0][0].ToString();
            }
            strSQL = @"insert into t_opr_patientregister
            (registerid_chr, patientcardid_chr, registerdate_dat,
             diagdept_chr, diagdoctor_chr, registeremp_chr, pstatus_int,
             registertypeid_chr, paytypeid_chr, registerno_chr, flag_int,
             planperiod_chr, patientid_chr, paytype_int, invno_chr,
             bespeakdate_dat, datespace
            )
            values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?
            )";

            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(17, out paramArr);
                paramArr[0].Value = p_strREGISTERID;
                paramArr[1].Value = objResult.m_objPatientCard.m_strCardID;
                paramArr[2].Value = objResult.m_strRegisterDate;
                paramArr[3].Value = objResult.m_objDiagDept.strDeptID;
                paramArr[4].Value = objResult.m_objDiagDoctor.strEmpID;
                paramArr[5].Value = objResult.m_objRegisterEmp.strEmpID;
                paramArr[6].Value = objResult.m_intPStatus;
                paramArr[7].Value = objResult.m_strRegisterType.m_strRegisterTypeID;
                paramArr[8].Value = objResult.m_strPayType.m_strPayTypeID;

                paramArr[9].Value = p_strREGISTERNO;
                paramArr[10].Value = objResult.m_intFlag;
                paramArr[11].Value = objResult.m_strPiod;
                paramArr[12].Value = objResult.m_strPatient;
                paramArr[13].Value = objResult.m_decRegisterPay;
                paramArr[14].Value = objResult.strINVNO_CHR;
                paramArr[15].Value = objResult.strbespeakDate;
                paramArr[16].Value = objResult.strbespeak;
                long lngRecordsAffected = -1;
                lngRes = objSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            #endregion

            #region 修改相关表的数据
            string date = "";
            if (objResult.m_intFlag == "2")
            {
                date = objResult.strbespeakDate;

            }
            else
            {
                date = objResult.m_strRegisterDate;
            }
            strSQL = @"update t_opr_opdoctorplan
   set optimes_int = nvl (optimes_int, 0) + 1
 where opdcotor_chr = ?
   and plandate_dat = to_date (?, 'yyyy-MM-dd')
   and planperiod_chr = ?";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = objResult.m_objDiagDoctor.strEmpID;
                paramArr[1].Value = date;
                paramArr[2].Value = objResult.m_strPiod;
                long lngRecordsAffected = -1;
                lngRes = objSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            strSQL = @"update t_bse_patient
   set optimes_int = nvl (optimes_int, 0) + 1
 where patientid_chr = ?";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = objResult.m_strPatient;
                long lngRecordsAffected = -1;
                lngRes = objSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            #endregion

            strSQL = @"select count (*) as totmunber
                       from t_opr_opdoctorplan
                       where opdcotor_chr = ?
                       and plandate_dat = to_date (?, 'yyyy-MM-dd')
                       and planperiod_chr = ?";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(3, out paramArr);
                if (objResult.m_objDiagDoctor.strEmpID != null)
                {
                    paramArr[0].Value = objResult.m_objDiagDoctor.strEmpID;
                }
                else
                {
                    paramArr[0].Value = string.Empty;
                }
                paramArr[1].Value = date;
                paramArr[2].Value = objResult.m_strPiod;
                lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
               // lngRes = objSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            int intregistercount = 0;
            if (double.Parse(dt.Rows[0]["totMunber"].ToString()) > 0)
            {
                strSQL = @"select to_char (nvl (optimes_int, 0)) as registercount
                           from t_opr_opdoctorplan
                           where opdcotor_chr = ?
                           and plandate_dat = to_date (?, 'yyyy-MM-dd')
                           and planperiod_chr = ?";
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    objSvc.CreateDatabaseParameter(3, out paramArr);
                    paramArr[0].Value = objResult.m_objDiagDoctor.strEmpID;
                    paramArr[1].Value = date;
                    paramArr[2].Value = objResult.m_strPiod;
                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (dt.Rows.Count > 0)
                {
                    intregistercount = int.Parse(dt.Rows[0]["registercount"].ToString());
                }
            }
            //获取候诊ID号
            string strWaitID = "";
            //objSvc.m_lngGenerateNewID("t_opr_waitdiaglist", "waitdiaglistid_chr", out strWaitID);

            //序列ID               
            DataTable dt1 = new DataTable();
            string SQL = @"select lpad (seq_waitdiaglistid.nextval, 18, '0')
  from dual";
            lngRes = objSvc.lngGetDataTableWithoutParameters(SQL, ref dt1);
            if (lngRes > 0)
            {
                strWaitID = dt1.Rows[0][0].ToString();
            }

            //获取候诊号
            int strWaitNO = 1;
//            if (objResult.m_objDiagDoctor.strEmpID != null && objResult.m_objDiagDoctor.strEmpID != "")
//            {
//                strSQL = @"select max (order_int) as waitno
//   from t_opr_waitdiaglist
//   where waitdiagdr_chr = ?
//   and registerdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
//                try
//                {
//                    System.Data.IDataParameter[] paramArr = null;
//                    objSvc.CreateDatabaseParameter(2, out paramArr);
//                    paramArr[0].Value = objResult.m_objDiagDoctor.strEmpID;
//                    paramArr[1].Value = objResult.m_strRegisterDate;

//                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
//                    // lngRes = objSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
//                }
//                catch (Exception objEx)
//                {
//                    string strTmp = objEx.Message;
//                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }
//            }
//            else
            //{
//                strSQL = @"select max (order_int) as waitno
//              from t_opr_waitdiaglist
//             where waitdiagdept_chr = ?
//               and pstatus_int = 1
//               and registerdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
                strSQL = @"select max (order_int) as waitno
              from t_opr_waitdiaglist
             where waitdiagdept_chr = ?
               and registerdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    objSvc.CreateDatabaseParameter(2, out paramArr);
                    paramArr[0].Value = objResult.m_objDiagDept.strDeptID;
                    paramArr[1].Value = date;

                    lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
                    // lngRes = objSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            //}
//            strSQL = @"select substr (to_char (seq_waitlistno.nextval), -4)
//                       from dual";
  
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["waitNO"] != System.DBNull.Value && dt.Rows[0]["waitNO"].ToString() != "0" && dt.Rows[0]["waitNO"].ToString() != "")
                {
                    strWaitNO = int.Parse(dt.Rows[0]["waitNO"].ToString()) + 1;

                }
                else
                {
                    strWaitNO = 1;
                }
                //strWaitNO = Convert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                strWaitNO = 1;
            }
            strSQL = @"insert into t_opr_waitdiaglist
            (waitdiaglistid_chr, registerid_chr, waitdiagdept_chr,
             waitdiagdr_chr, order_int, registerdate_dat, pstatus_int,
             registerop_vchr
            )
     values (?, ?, ?,
             ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?,
             ?
            )";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(8, out paramArr);
                paramArr[0].Value = strWaitID;
                paramArr[1].Value = p_strREGISTERID;
                paramArr[2].Value = objResult.m_objDiagDept.strDeptID;
                paramArr[3].Value = objResult.m_objDiagDoctor.strEmpID;
                paramArr[4].Value = strWaitNO;
                paramArr[5].Value = date;
                paramArr[6].Value = 1;
                paramArr[7].Value = objResult.m_strPiod;
                long lngRecordsAffected = -1;
                lngRes = objSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            strID = p_strREGISTERID;
            strNo = p_strREGISTERNO;
            strOrderNo = strWaitNO.ToString();
            strRegCount = intregistercount.ToString();
            #endregion
            m_lngAddNewRegDetail(objPri, PatientDetail_VO, strID);
            //if (objResult.m_strPatient != "" && objResult.m_strPayType.m_strPayTypeID != "" )
            //{
            //    lngRes = m_lngAddPatientIdTypeIdNo(objPri, objResult.m_strPatient, objResult.m_strPayType.m_strPayTypeID, objResult.m_strPayType.m_strPayTypeNo);
            //}
            return lngRes;
        }
        #region 增加挂号明细
        [AutoComplete]
        public long m_lngAddNewRegDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsPatientDetail_VO p_objRecord)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewRegDetail");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL =@"insert into t_opr_patientregdetail
            (registerid_chr, chargeid_chr, payment_mny, discount_dec
            )
     values (?, ?, ?, ?
            )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strCHARGEID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_dblPAYMENT_MNY;
                objLisAddItemRefArr[3].Value = p_objRecord.m_fltDISCOUNT_DEC;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region 增加挂号明细
        [AutoComplete]
        public long m_lngAddNewRegDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsPatientDetail_VO[] p_objRecord, string strID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewRegDetail");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL;
            for (int i1 = 0; i1 < p_objRecord.Length; i1++)
            {
                strSQL =@"insert into t_opr_patientregdetail
            (registerid_chr, chargeid_chr, payment_mny, discount_dec
            )
     values (?, ?, ?, ?
            )
";
                try
                {
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                    //Please change the datetime and reocrdid 
                    objLisAddItemRefArr[0].Value = strID;
                    objLisAddItemRefArr[1].Value = p_objRecord[i1].m_strCHARGEID_CHR;
                    objLisAddItemRefArr[2].Value = p_objRecord[i1].m_dblPAYMENT_MNY;
                    objLisAddItemRefArr[3].Value = p_objRecord[i1].m_fltDISCOUNT_DEC;
                    long lngRecEff = -1;
                    //往表增加记录
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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
        #endregion

        #region 修改挂号明细
        [AutoComplete]
        public long m_lngModifyRegDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsPatientDetail_VO p_objRecord)
        {
            DataTable dtRegister = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngModifyRegDetail");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select a.registerid_chr, a.chargeid_chr, a.chargename_chr, a.payment_mny,
       a.discount_dec
  from v_opr_patientregdetail a
 where registerid_chr = ? and a.chargeid_chr = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();


            System.Data.IDataParameter[] paramArr = null;
            HRPSvc.CreateDatabaseParameter(2, out paramArr);
            paramArr[0].Value = p_objRecord.m_strREGISTERID_CHR;
            paramArr[1].Value = p_objRecord.m_strCHARGEID_CHR;

            lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRegister, paramArr);
            if (dtRegister.Rows.Count > 0)
            {
                try
                {
                    strSQL = @"update t_opr_patientregdetail a
   set payment_mny = ?,
       discount_dec = ?
 where registerid_chr = ? and a.chargeid_chr = ?";

                    paramArr = null;
                    HRPSvc.CreateDatabaseParameter(4, out paramArr);
                    paramArr[0].Value = p_objRecord.m_dblPAYMENT_MNY.ToString();
                    paramArr[1].Value = p_objRecord.m_fltDISCOUNT_DEC;
                    paramArr[2].Value = p_objRecord.m_strREGISTERID_CHR;
                    paramArr[3].Value = p_objRecord.m_strCHARGEID_CHR;

                    lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRegister, paramArr);
                }
                catch (Exception e)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    objLogger.LogError(e);
                }
            }
            else
            {
                lngRes = m_lngAddNewRegDetail(p_objPrincipal, p_objRecord);
            }

            return lngRes;
        }
        #endregion

        #region 修改挂号记录
        /// <summary>
        /// 修改挂号记录（一般只能修改科室、医生、挂号类别、费用）
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDoUpdPatientRegisterByID(System.Security.Principal.IPrincipal objPri, clsPatientRegister_VO objResult)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngDoUpdPatientRegisterByID");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string strSQL = @"update t_opr_patientregister a
   set a.paytypeid_chr = ?,
       a.patientcardid_chr = ?,
       a.patientid_chr = ?
 where registerid_chr = ?";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                HRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = objResult.m_strPayType.m_strPayTypeID;
                paramArr[1].Value = objResult.m_objPatientCard.m_strCardID;
                paramArr[2].Value = objResult.m_strPatient;
                paramArr[3].Value = objResult.m_strRegisterID;
                long lngRecordsAffected = -1;
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = "P_OPR_MARKREG";
            clsSQLParamDefinitionVO[] objParameter = new clsSQLParamDefinitionVO[5];
            for (int i = 0; i < objParameter.Length; i++)
                objParameter[i] = new clsSQLParamDefinitionVO();
            objParameter[0].objParameter_Value = objResult.m_strRegisterID;
            objParameter[1].objParameter_Value = objResult.m_objRegisterEmp.strEmpID;
            objParameter[2].objParameter_Value = 2;
            objParameter[3].objParameter_Value = objResult.m_strRegisterDate;

            objParameter[0].strParameter_Type = "Varchar2";
            objParameter[1].strParameter_Type = "Varchar2";
            objParameter[2].strParameter_Type = "Int32";
            objParameter[3].strParameter_Type = "Varchar2";
            objParameter[4].strParameter_Type = "Int32";
            objParameter[4].strParameter_Direction = "Output";

            try
            {
                lngRes = HRPSvc.lngExecuteParameterProc(strSQL, objParameter);
                string strReturn = objParameter[4].objParameter_Value.ToString().Trim();
                if (strReturn == "-1")
                {
                    return 0;
                }
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更新过程状态
        /// <summary>
        /// 更改当前记录所处的状态 1-候诊 2-就诊 3-取消
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strStatus"></param>
        /// <param name="strRegID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdatePStatus(System.Security.Principal.IPrincipal objPri, string strStatus, string strRegID)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngDoUpdPatientRegisterByID");
            if (lngRes < 0)
                return lngRes;

            string strSQL =@"update t_opr_patientregister
   set pstatus_int = ?
 where registerid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                HRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strStatus;
                paramArr[1].Value = strRegID;
                long lngRecordsAffected = -1;
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 更新挂号记录状态（退号）
        /// <summary>
        /// 更新挂号记录状态（退号）
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strStatus"></param>
        /// <param name="strRegID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDropRegister(System.Security.Principal.IPrincipal objPri, string strReturnEmp, string strRegID)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngDoUpdPatientRegisterByID");
            if (lngRes < 0)
                return lngRes;
            //退号时置标志为3
            string strSQL = @"update t_opr_patientregister
   set flag_int = 3,
       returnemp_chr = ?,
       returndate_dat = sysdate
 where registerid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                HRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strReturnEmp;
                paramArr[1].Value = strRegID;
                long lngRecordsAffected = -1;
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 查询病人记录
        /// <summary>
        /// 查询病人记录
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="CardID"></param>
        /// <param name="clsResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatByCardID(System.Security.Principal.IPrincipal objPri, string CardID, out clsPatient_VO clsResult, string registerDate, out string DepName, out string doctorName, out string reCorddate)
        {
            DepName = null;
            doctorName = null;
            reCorddate = null;
            clsResult = new clsPatient_VO();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPatByCardID");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"select a.govcard_chr, a.difficulty_vchr, a.insuranceid_vchr, a.birth_dat,
       a.name_vchr, a.patientid_chr, a.sex_chr, a.paytypeid_chr, a.idcard_chr,
       a.insuranceid_vchr, a.optimes_int, c.paytypename_vchr,
       c.internalflag_int
  from t_bse_patient a, t_bse_patientcard b, t_bse_patientpaytype c
 where a.patientid_chr = b.patientid_chr
   and b.patientcardid_chr = ?
   and a.paytypeid_chr = c.paytypeid_chr(+)
   and b.status_int <> 0 ";
            DataTable dtResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                HRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = CardID;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);

                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    clsResult.m_strGOVCARD_CHR = dtResult.Rows[0]["GOVCARD_CHR"].ToString().Trim();
                    clsResult.m_strDIFFICULTY_VCHR = dtResult.Rows[0]["DIFFICULTY_VCHR"].ToString().Trim();
                    clsResult.strInsuranceID = dtResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    clsResult.strBirthDate = dtResult.Rows[0]["BIRTH_DAT"].ToString().Trim();
                    clsResult.strName = dtResult.Rows[0]["NAME_VCHR"].ToString().Trim();
                    clsResult.strPatientCardID = CardID;
                    clsResult.strPatientID = dtResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    clsResult.strSex = dtResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    clsResult.objPatType = new clsPatientType_VO();
                    clsResult.objPatType.m_strPayTypeID = dtResult.Rows[0]["PAYTYPEID_CHR"].ToString().Trim();
                    clsResult.objPatType.m_strPayTypeName = dtResult.Rows[0]["paytypename_vchr"].ToString().Trim();
                    clsResult.strID_Card = dtResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
                    clsResult.m_intERNALFLAG_INT = Convert.ToInt16(dtResult.Rows[0]["INTERNALFLAG_INT"].ToString().Trim());
                    clsResult.strInsuranceID = dtResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    if (dtResult.Rows[0]["OPTIMES_INT"] == Convert.DBNull)
                    {
                        clsResult.m_strOPTIMES_INT = "0";
                    }
                    else
                    {
                        clsResult.m_strOPTIMES_INT = dtResult.Rows[0]["OPTIMES_INT"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select a.recorddate_dat, a.registerid_chr, b.deptname_vchr, c.lastname_vchr
  from t_opr_patientregister a, t_bse_deptdesc b, t_bse_employee c
 where a.registerdate_dat = to_date (?, 'yyyy-MM-dd')
   and a.patientcardid_chr = ?
   and a.diagdept_chr = b.deptid_chr(+)
   and a.diagdoctor_chr = c.empid_chr(+)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                HRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = registerDate;
                objLisAddItemRefArr[1].Value = CardID;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dtResult.Rows.Count > 0)
            {
                if (dtResult.Rows[0]["REGISTERID_CHR"] != System.DBNull.Value)
                {
                    if (dtResult.Rows[0]["DEPTNAME_VCHR"] != System.DBNull.Value)
                        DepName = dtResult.Rows[0]["DEPTNAME_VCHR"].ToString();
                    else
                        DepName = "没有科室";
                    if (dtResult.Rows[0]["LASTNAME_VCHR"] != System.DBNull.Value)
                        doctorName = dtResult.Rows[0]["LASTNAME_VCHR"].ToString();
                    else
                        doctorName = "没有医生";
                    reCorddate = dtResult.Rows[0]["RECORDDATE_DAT"].ToString();
                }
            }
            return lngRes;
        }
        #endregion

        #region 查询找挂号类型状态
        /// <summary>
        /// 查询找挂号类型状态
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strTypeid"></param>
        /// <param name="command">返回挂号费用的状态信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindType(System.Security.Principal.IPrincipal objPri, string strTypeid, out string command)
        {
            command = "";
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngFindType");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select isdoctor_num
                              from t_bse_registertype
                              where registertypename_vchr = ?";
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] param = null;
                HRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strTypeid;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    command = dtResult.Rows[0]["ISDOCTOR_NUM"].ToString();
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

        #region 查询病人类型
        [AutoComplete]
        public long m_lngGetPatType(System.Security.Principal.IPrincipal objPri, out clsPatientType_VO[] clsResult)
        {
            clsResult = new clsPatientType_VO[0];
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPatType");
            if (lngRes < 0)
                return lngRes;

            string strSQL = "";

            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();

                bool b = false;
                strSQL = @"select a.setid_chr, a.setname_vchr, a.setdesc_vchr, a.setstatus_int,
       a.moduleid_chr
  from t_sys_setting a
 where a.setid_chr = '0063'";
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                if (dtResult.Rows.Count > 0)
                {
                    b = dtResult.Rows[0]["setstatus_int"].ToString().Trim() == "1";
                }

                if (b)
                {
                    Hashtable has = new Hashtable();
                    has.Add("monday", "1");
                    has.Add("tuesday", "2");
                    has.Add("wednesday", "3");
                    has.Add("thursday", "4");
                    has.Add("friday", "5");
                    has.Add("saturday", "6");
                    has.Add("sunday", "7");

                    b = false;

                    string NowWeekNo = has[DateTime.Now.DayOfWeek.ToString().ToLower()].ToString();

                    strSQL = "select * from t_opr_ybtimespan where weekno_int = " + NowWeekNo;
                    lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                    if (dtResult.Rows.Count == 1)
                    {
                        string TimeSpan = dtResult.Rows[0]["timespan_vchr"].ToString().Trim();

                        DateTime dte1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + TimeSpan.Substring(0, 5) + ":01");
                        DateTime dte2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + TimeSpan.Substring(6) + ":59");

                        if (DateTime.Now >= dte1 && DateTime.Now <= dte2)
                        {
                            b = true;
                        }
                    }
                }

                if (b)
                {
                    strSQL = @"select paytypeid_chr, paytypename_vchr, payflag_dec, paytypeno_vchr
                                 from t_bse_patientpaytype
                                where isusing_num = 1 and payflag_dec <> 2
                                      and paytypename_vchr <> '特定医保'
                             order by paytypeno_vchr";
                }
                else
                {
                    strSQL = @"select paytypeid_chr, paytypename_vchr, payflag_dec, paytypeno_vchr
                                 from t_bse_patientpaytype
                                where isusing_num = 1 and payflag_dec <> 2
                             order by paytypeno_vchr";
                }

                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                HRPSvc.Dispose();
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    clsResult = new clsPatientType_VO[dtResult.Rows.Count];
                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        clsResult[i1] = new clsPatientType_VO();
                        clsResult[i1].m_strPayTypeID = dtResult.Rows[i1]["paytypeid_chr"].ToString().Trim();
                        clsResult[i1].m_strPayTypeName = dtResult.Rows[i1]["paytypename_vchr"].ToString().Trim();
                        clsResult[i1].m_strPayTypeNo = dtResult.Rows[i1]["paytypeno_vchr"].ToString().Trim();
                        if (dtResult.Rows[i1]["payflag_dec"] != System.DBNull.Value)
                            clsResult[i1].m_decDiscount = decimal.Parse(dtResult.Rows[i1]["payflag_dec"].ToString().Trim());
                        else
                            clsResult[i1].m_decDiscount = 0;
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

        #region 重新获取当前挂号记录 zlc
        [AutoComplete]
        public long m_lngGetCurRegisterByID(System.Security.Principal.IPrincipal objPri, string strRegisterID, out DataTable dtbSource)
        {
            //DataTable dt = new DataTable();
            dtbSource = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngDoUpdPatientRegisterByID");
            if (lngRes < 0)
                return lngRes;
            string strsql = @"select distinct a.registerid_chr, a.patientcardid_chr, a.registerdate_dat,
                                     a.diagdept_chr, a.diagdoctor_chr, a.registeremp_chr,
                                     a.pstatus_int, a.registertypeid_chr, a.paytypeid_chr,
                                     a.registerno_chr, a.flag_int, a.returnemp_chr,
                                     a.returndate_dat, a.recorddate_dat, a.planperiod_chr,
                                     a.patientid_chr, a.paytype_int, a.balance_dat, a.invno_chr,
                                     a.balanceemp_chr, a.bespeakdate_dat, a.datespace,
                                     a.confirmemp_chr, a.confirmdate_dat, a.takedoctor_chr,
                                     b.order_int, c.opaddress_vchr, c.planperiod_chr,
                                     d.registertypename_vchr, f.name_vchr,
                                     a.diagpay_mny + a.registerpay_mny as payinall_mny,
                                     g.deptname_vchr
                                from t_opr_patientregister a inner join t_opr_waitdiaglist b on a.registerid_chr =
                                                                                                  b.registerid_chr
                                     inner join t_opr_opdoctorplan c on a.diagdoctor_chr =
                                                                                     c.opdcotor_chr
                                     inner join t_bse_registertype d on a.registertypeid_chr =
                                                                               d.registertypeid_chr
                                     inner join t_bse_patientcard e on a.patientcardid_chr =
                                                                               e.patientcardid_chr
                                     inner join t_bse_patientidx f on e.patientid_chr =
                                                                                    f.patientid_chr
                                     inner join t_bse_deptdesc g on a.diagdept_chr = g.deptid_chr
                               where a.registerid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                HRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strRegisterID;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strsql, ref dtbSource, objParamArr);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            //dtbSource = dt;

            return lngRes;
        }
        #endregion

        #region 重新获取当前挂号记录 zlc
        [AutoComplete]
        public long m_lngGetCurRegisterByNo(System.Security.Principal.IPrincipal objPri, string strRegisterID, string strDate, out clsPatientRegister_VO objreg)
        {
            //DataTable dt = new DataTable();

            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngDoUpdPatientRegisterByID");
            objreg = new clsPatientRegister_VO();
            if (lngRes < 0)
                return lngRes;
            string strsql = @"SELECT
   A.REGID , A.CARDID , A.REGDATE , A.DEPTID , A.DOCID
 , A.REGEMP , A.PSTATUS , A.REGTYPEID , A.PATTYPEID , A.REGNO
 , A.FLAG , A.DROPEMP , A.DROPDATE , A.RECORDDATE , A.PATTYPENAME
 , A.REGTYPENAME , A.NAME , A.SEX , A.BIRTH , A.PATID
 , A.DEPTNAME , A.DOCNAME , A.AGE ,  A.PLANPERIOD
 , A.STARTTIME , A.ENDTIME , A.OPADDRESS , A.EMPNO , A.ORDERNO
FROM
   ICARE.VW_OPREGISTER A  where a.REGNO =? and a.REGDATE >= to_date(?,'yyyy-mm-dd') " + " and a.FLAG<>3";
            DataTable dtbSource = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                HRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strRegisterID;
                paramArr[1].Value = strDate;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strsql, ref dtbSource, paramArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }


            objreg.m_objPatientCard = new clsPatientCard_VO();
            objreg.m_clsPatientVO = new clsPatientVO();
            objreg.m_strPayType = new clsPatientType_VO();
            objreg.m_clsOPDoctorPlanVO = new clsOPDoctorPlan_VO();
            objreg.m_strRegisterType = new clsRegisterType_VO();
            objreg.m_objDiagDept = new clsDepartmentVO();
            objreg.m_objDiagDoctor = new clsEmployeeVO();
            objreg.m_objRegisterEmp = new clsEmployeeVO();
            if (dtbSource.Rows.Count == 1)
            {
                objreg.m_objPatientCard.m_strCardID = dtbSource.Rows[0]["CARDID"].ToString();
                objreg.m_strRegisterID = dtbSource.Rows[0]["REGID"].ToString();
                objreg.m_clsPatientVO.strName = dtbSource.Rows[0]["NAME"].ToString();
                objreg.m_strPatient = dtbSource.Rows[0]["PATID"].ToString();
                objreg.m_clsPatientVO.strSex = dtbSource.Rows[0]["SEX"].ToString();
                objreg.m_clsPatientVO.strBirthDate = dtbSource.Rows[0]["BIRTH"].ToString();

                objreg.m_strPayType.m_strPayTypeName = dtbSource.Rows[0]["PATTYPENAME"].ToString();
                objreg.m_strPayType.m_strPayTypeID = dtbSource.Rows[0]["PATTYPEID"].ToString();

                objreg.m_objDiagDept.strDeptName = dtbSource.Rows[0]["DEPTNAME"].ToString();
                objreg.m_objDiagDept.strDeptID = dtbSource.Rows[0]["DEPTID"].ToString();
                objreg.m_strRegisterType.m_strRegisterTypeName = dtbSource.Rows[0]["REGTYPENAME"].ToString();
                objreg.m_strRegisterType.m_strRegisterTypeID = dtbSource.Rows[0]["REGTYPEID"].ToString();
                objreg.m_objDiagDoctor.strFirstName = dtbSource.Rows[0]["DOCNAME"].ToString();
                objreg.m_objDiagDoctor.strEmpID = dtbSource.Rows[0]["DOCID"].ToString();
                objreg.m_objRegisterEmp.strEmpNO = dtbSource.Rows[0]["EMPNO"].ToString();

                objreg.m_clsOPDoctorPlanVO.m_strStartTime = dtbSource.Rows[0]["STARTTIME"].ToString();
                objreg.m_clsOPDoctorPlanVO.m_strEndTime = dtbSource.Rows[0]["ENDTIME"].ToString();
                objreg.m_clsOPDoctorPlanVO.m_strOPAddress = dtbSource.Rows[0]["OPADDRESS"].ToString();
                objreg.m_strPiod = dtbSource.Rows[0]["PLANPERIOD"].ToString();
            }
            else
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 返回当前医生已接诊病人数
        [AutoComplete]
        public long m_lngGetDocTakeCount(System.Security.Principal.IPrincipal objPri,
            string strDocID, string strRegDate, out int p_Count)
        {
            p_Count = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetDocTakeCount");
            if (lngRes < 0)
                return lngRes;

            string strSQL = "select count(order_int) from t_opr_waitdiaglist " +
                " where waitdiagdr_chr=? " +
                " And registerdate_dat=?  ";
            System.DateTime RegDate = Convert.ToDateTime(strRegDate).Date;
            System.Data.IDataParameter[] objPar = clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[] { strDocID, RegDate });
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objPar);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    if (dtResult.Rows[0][0].ToString().Trim() != "")
                        p_Count = int.Parse(dtResult.Rows[0][0].ToString().Trim());
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 日期查询挂号
        /// <summary>
        /// 按日期查询挂号信息
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="dtRegister">输出一个表</param>
        /// <param name="firstdate">开始日期</param>
        /// <param name="lastdate">截止日期</param>
        /// <returns>长整型</returns>
        [AutoComplete]
        public long m_lngQulRegByDate(System.Security.Principal.IPrincipal objPri, out DataTable dtRegister, string firstdate, string lastdate)
        {
            dtRegister = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegByDate");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"SELECT distinct
   A.REGID , A.CARDID , A.REGNO , A.ORDERNO,A.REGTYPENAME , A.NAME , A.SEX , A.BIRTH ,case when a.paytype=0 then '现金' when a.paytype=1 then '记帐'  when a.paytype=2 then '支票' end as paytype, A.REGDATE , A.DEPTID , A.DOCID ,A.DEPTNAME , A.DOCNAME
 , A.REGEMP , case when A.PSTATUS=1 then '候诊' when A.PSTATUS=2 then '就诊'  when A.PSTATUS=3 then '取消' when A.PSTATUS=4 then '结帐' end as PSTATUS , A.REGTYPEID , A.PATTYPEID
 , case when A.FLAG=1 then '正常' when A.FLAG=2 then '预约'  when A.FLAG=3 then '退号' when A.FLAG=4 then '还原' end as FLAG , A.REEMPNO , A.DROPDATE , A.RECORDDATE ,
 A.PATTYPENAME
 ,  A.PATID
 ,  A.AGE ,  A.PLANPERIOD
 , A.STARTTIME , A.ENDTIME , A.ADDRESS , A.EMPNO ,a.ghmoney,a.kbmoney,a.gbmoney
FROM
   ICARE.VW_OPREGISTER A where a.REGDATE>=to_date('" + firstdate + "','yyyy-MM-dd') and a.REGDATE<=to_date('" + lastdate + "','yyyy-MM-dd') order by REGNO";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtRegister);
            HRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 历史查询
        [AutoComplete]
        public long m_lngGetHistorRegister(System.Security.Principal.IPrincipal p_objPrincipal, string startDate, string endDate, string checkMan, out DataTable dt)
        {
            dt = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetHistorRegister");
            if (lngRes < 0) //没有使用的权限distinct
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            strSQL = @"select distinct BALANCE_DAT  from T_OPR_PATIENTREGISTER where BALANCE_DAT between to_date('" + startDate + "','yyyy-MM-dd') and to_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') and BALANCEEMP_CHR='" + checkMan + "' order by BALANCE_DAT";
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
            return lngRes;

        }
        #endregion

        #region 日期查询挂号(新）
        /// <summary>
        /// 日期查询挂号(新）
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="dtRegister">输出一个表</param>
        /// <param name="firstdate">开始日期</param>
        /// <param name="lastdate">截止日期</param>
        /// <param name="EmpID">挂号员ID</param>
        /// <param name="Scope">0 收费处 1 挂号员</param>
        /// <returns>长整型</returns>
        [AutoComplete]
        public long m_lngQulRegByDateNew(System.Security.Principal.IPrincipal objPri, out DataTable dtRegister, string firstdate, string lastdate, string EmpID, string Scope)
        {
            dtRegister = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegByDateNew");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"select a.registerid_chr, a.patientcardid_chr, a.invno_chr, a.registerno_chr,
       e.order_int, c.registertypename_vchr, d.name_vchr, d.sex_chr,
       decode (a.paytype_int, 0, '现金', 1, '记帐', 2, '支票') as paytype,
       a.registerdate_dat,
       decode (a.flag_int,
               2, to_char (a.bespeakdate_dat, 'yyyy-MM-dd') || a.datespace,
               ''
              ) as bespeakdate_dat,
       f.deptname_vchr, g.lastname_vchr,
       decode (a.balance_dat, null, '未结账', '结帐') as pstatus,
       decode (a.flag_int,
               1, '正常',
               2, '预约',
               3, '退号',
               4, '还原'
              ) as flag, m.empno_chr as reempno, a.returndate_dat,
       a.recorddate_dat, b.paytypename_vchr, k.address_vchr, i.empno_chr,
       (select payment_mny * discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '001') as ghmoney,
       (select payment_mny * discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '002') as kbmoney,
       (select discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '001') as ghdiscount,
       (select discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '002') as kbdiscount,
       nvl ((select p.payment_mny * discount_dec
               from t_opr_patientregdetail p
              where p.registerid_chr = a.registerid_chr
                and p.chargeid_chr = '003'),
            0
           ) as gbmoney,
       nvl ((select discount_dec
               from t_opr_patientregdetail p
              where p.registerid_chr = a.registerid_chr
                and p.chargeid_chr = '003'),
            0
           ) as gbdiscount
  from t_opr_patientregister a,
       t_bse_patientpaytype b,
       t_bse_registertype c,
       t_opr_waitdiaglist e,
       t_bse_patientidx d,
       t_bse_deptdesc f,
       t_bse_employee g,
       t_bse_employee i,
       t_bse_employee m,
       t_bse_deptdesc k
 where a.paytypeid_chr = b.paytypeid_chr
   and a.registertypeid_chr = c.registertypeid_chr
   and a.registerid_chr=e.registerid_chr(+)
   and a.patientid_chr = d.patientid_chr
   and a.diagdept_chr = f.deptid_chr(+)
   and a.diagdoctor_chr = g.empid_chr(+)
   and a.registeremp_chr = i.empid_chr(+)
   and a.returnemp_chr = m.empid_chr(+)
   and a.diagdept_chr = k.deptid_chr(+)
   and a.registerdate_dat >= to_date (?, 'yyyy-MM-dd')
   and a.registerdate_dat <= to_date (?, 'yyyy-MM-dd')";

            if (Scope == "1")
            {
                strSQL = @"select a.registerid_chr, a.patientcardid_chr, a.invno_chr, a.registerno_chr,
       e.order_int, c.registertypename_vchr, d.name_vchr, d.sex_chr,
       decode (a.paytype_int, 0, '现金', 1, '记帐', 2, '支票') as paytype,
       a.registerdate_dat,
       decode (a.flag_int,
               2, to_char (a.bespeakdate_dat, 'yyyy-MM-dd') || a.datespace,
               ''
              ) as bespeakdate_dat,
       f.deptname_vchr, g.lastname_vchr,
       decode (a.balance_dat, null, '未结账', '结帐') as pstatus,
       decode (a.flag_int,
               1, '正常',
               2, '预约',
               3, '退号',
               4, '还原'
              ) as flag, m.empno_chr as reempno, a.returndate_dat,
       a.recorddate_dat, b.paytypename_vchr, k.address_vchr, i.empno_chr,
       (select payment_mny * discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '001') as ghmoney,
       (select payment_mny * discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '002') as kbmoney,
       (select discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '001') as ghdiscount,
       (select discount_dec
          from t_opr_patientregdetail p
         where p.registerid_chr = a.registerid_chr
           and p.chargeid_chr = '002') as kbdiscount,
       nvl ((select p.payment_mny * discount_dec
               from t_opr_patientregdetail p
              where p.registerid_chr = a.registerid_chr
                and p.chargeid_chr = '003'),
            0
           ) as gbmoney,
       nvl ((select discount_dec
               from t_opr_patientregdetail p
              where p.registerid_chr = a.registerid_chr
                and p.chargeid_chr = '003'),
            0
           ) as gbdiscount
  from t_opr_patientregister a,
       t_bse_patientpaytype b,
       t_bse_registertype c,
       t_opr_waitdiaglist e,
       t_bse_patientidx d,
       t_bse_deptdesc f,
       t_bse_employee g,
       t_bse_employee i,
       t_bse_employee m,
       t_bse_deptdesc k
 where a.paytypeid_chr = b.paytypeid_chr
   and a.registertypeid_chr = c.registertypeid_chr
   and a.registerid_chr = e.registerid_chr(+)
   and a.patientid_chr = d.patientid_chr
   and a.diagdept_chr = f.deptid_chr(+)
   and a.diagdoctor_chr = g.empid_chr(+)
   and a.registeremp_chr = i.empid_chr(+)
   and a.returnemp_chr = m.empid_chr(+)
   and a.diagdept_chr = k.deptid_chr(+)
   and a.registerdate_dat >= to_date (?, 'yyyy-MM-dd')
   and a.registerdate_dat <= to_date (?, 'yyyy-MM-dd')
   and (a.registeremp_chr = ? or a.returnemp_chr = ?)";
                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] param = null;
                    HRPSvc.CreateDatabaseParameter(4, out param);
                    param[0].Value = firstdate;
                    param[1].Value = lastdate;
                    param[2].Value = EmpID;
                    param[3].Value = EmpID;
                    lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRegister, param);
                    HRPSvc.Dispose();
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
                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] param = null;
                    HRPSvc.CreateDatabaseParameter(2, out param);
                    param[0].Value = firstdate;
                    param[1].Value = lastdate;
                    lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRegister, param);
                    HRPSvc.Dispose();
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

        #region 按字段查询挂号(新）
        /// <summary>
        /// 按字段查询挂号(新）
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="m_strArr"></param>
        /// <param name="dt"></param>
        /// <returns>长整型</returns>
        [AutoComplete]
        public long m_lngQulRegByFieldNew(System.Security.Principal.IPrincipal objPri, string[] m_strArr, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegByFieldNew");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"SELECT a.registerid_chr, a.patientcardid_chr, a.invno_chr, a.registerno_chr, j.order_int,c.registertypename_vchr, d.name_vchr,d.sex_chr,CASE
          WHEN a.paytype_int = 0
             THEN '现金'
          WHEN a.paytype_int = 1
             THEN '记帐'
          WHEN a.paytype_int = 2
             THEN '支票'
       END AS paytype,a.registerdate_dat,
       CASE
          WHEN a.flag_int = 2
             THEN    TO_CHAR (a.bespeakdate_dat,
                              'yyyy-MM-dd'
                             )
                  || a.datespace
          ELSE ''
       END AS bespeakdate_dat, f.deptname_vchr,g.lastname_vchr, CASE
          WHEN a.balance_dat IS NULL
             THEN '未结账'
          WHEN a.balance_dat IS NOT NULL
             THEN '结帐'
       END AS pstatus,
       CASE
          WHEN a.flag_int = 1
             THEN '正常'
          WHEN a.flag_int = 2
             THEN '预约'
          WHEN a.flag_int = 3
             THEN '退号'
          WHEN a.flag_int = 4
             THEN '还原'
       END AS flag, m.empno_chr AS reempno,a.returndate_dat,a.recorddate_dat, b.paytypename_vchr, k.address_vchr,i.empno_chr,

       (SELECT payment_mny * discount_dec
          FROM t_opr_patientregdetail p
         WHERE p.registerid_chr = a.registerid_chr
           AND p.chargeid_chr = '001') AS ghmoney,
       (SELECT payment_mny * discount_dec
          FROM t_opr_patientregdetail p
         WHERE p.registerid_chr = a.registerid_chr
           AND p.chargeid_chr = '002') AS kbmoney,
       (SELECT discount_dec
          FROM t_opr_patientregdetail p
         WHERE p.registerid_chr = a.registerid_chr
           AND p.chargeid_chr = '001') AS ghdiscount,
       (SELECT discount_dec
          FROM t_opr_patientregdetail p
         WHERE p.registerid_chr = a.registerid_chr
           AND p.chargeid_chr = '002') AS kbdiscount,
                       nvl((SELECT p.payment_mny * discount_dec
          FROM t_opr_patientregdetail p
         WHERE p.registerid_chr = a.registerid_chr
           AND p.chargeid_chr = '003'),0) AS gbmoney,

       nvl((SELECT discount_dec
          FROM t_opr_patientregdetail p
         WHERE p.registerid_chr = a.registerid_chr
           AND p.chargeid_chr = '003'),0) AS gbdiscount
  FROM t_opr_patientregister a,
       t_bse_patientpaytype b,
       t_bse_registertype c,
       t_bse_patientcard e,
       t_bse_patientidx d,
       t_bse_deptdesc f,
       t_bse_employee g,
       t_bse_employee i,
       t_bse_employee m,
       t_bse_deptdesc k,
       t_opr_waitdiaglist j
 WHERE a.paytypeid_chr = b.paytypeid_chr
   AND a.registertypeid_chr = c.registertypeid_chr
   AND a.patientcardid_chr = e.patientcardid_chr
   AND a.patientid_chr = d.patientid_chr
   AND a.diagdept_chr = f.deptid_chr(+)
   AND a.diagdoctor_chr = g.empid_chr(+)
   AND a.registeremp_chr = i.empid_chr(+)
   AND a.returnemp_chr = m.empid_chr(+)
   AND a.diagdept_chr = k.deptid_chr(+)
   AND a.registerid_chr = j.registerid_chr(+)";
            try
            {

                int m_intStatus = -1;

                switch (m_strArr[0].Trim())
                {
                    case "诊疗卡号": strSQL += "and a.patientcardid_chr='" + m_strArr[1].Trim() + "'"; break;
                    case "发票号": strSQL += "and a.invno_chr='" + m_strArr[1].Trim() + "'"; break;
                    case "流水号": strSQL += "and a.registerno_chr='" + m_strArr[1].Trim() + "'"; break;
                    case "挂号类型": strSQL += "and c.registertypename_vchr='" + m_strArr[1].Trim() + "'"; break;
                    case "病人名称": strSQL += "and d.name_vchr='" + m_strArr[1].Trim() + "'"; break;
                    case "挂号日期": strSQL += "and a.registerdate_dat=to_date('" + m_strArr[1].Trim() + "','yyyy-mm-dd')"; break;
                    case "预约日期": strSQL += "and a.bespeakdate_dat=to_date('" + m_strArr[1].Trim() + "','yyyy-mm-dd') and a.flag_int = 2"; break;

                    case "科室名称": strSQL += "and f.deptname_vchr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "医生名称": strSQL += "and g.lastname_vchr='" + m_strArr[1].Trim() + "'"; break;
                    case "过程状态":
                        if (m_strArr[1].Trim() == "未结帐")
                        {
                            strSQL += "and a.balance_dat is null";
                        }
                        else if (m_strArr[1].Trim() == "结帐")
                        {
                            strSQL += "and a.balance_dat is not null";
                        }
                        break;
                    case "挂号状态":
                        if (m_strArr[1].Trim() == "正常")
                        {
                            m_intStatus = 1;
                        }
                        else if (m_strArr[1].Trim() == "预约")
                        {
                            m_intStatus = 2;
                        }
                        else if (m_strArr[1].Trim() == "退号")
                        {
                            m_intStatus = 3;
                        }
                        else if (m_strArr[1].Trim() == "还原")
                        {
                            m_intStatus = 4;
                        }
                        strSQL += "and a.flag_int=" + m_intStatus + ""; break;
                    case "退号人工号": strSQL += "and m.empno_chr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "退号日期": strSQL += "and a.returndate_dat=to_date('" + m_strArr[1] + "','yyyy-mm-dd hh24:mi:ss')"; break;
                    case "记录日期": strSQL += "and a.recorddate_dat=to_date('" + m_strArr[1] + "','yyyy-mm-dd hh24:mi:ss')"; break;
                    case "病人身份": strSQL += "and b.paytypename_vchr='" + m_strArr[1].Trim() + "'"; break;
                    case "挂号人工号": strSQL += "and i.empno_chr='" + m_strArr[1].Trim() + "'"; break;
                    default: break;

                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();

                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
        #region 检查挂号员在当天是否结过帐
        [AutoComplete]
        public long m_lngCheckEnd(System.Security.Principal.IPrincipal p_objPrincipal, string strID, string strDate)
        {
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckEnd");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = "select REGISTERID_CHR from t_opr_patientregister where BALANCEEMP_CHR='" + strID + "' and BALANCE_DAT>=To_Date('" + strDate + "','yyyy-mm-dd')";
            DataTable bt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref bt);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (bt.Rows.Count > 0)
            {
                return 3;
            }
            return lngRes;

        }



        #endregion

        #region 任意字段查询挂号
        /// <summary>
        /// 任意字段查询挂号单
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="dtRegister">返回表</param>
        /// <param name="strFeild">列名</param>
        /// <param name="strValue">列值</param>
        /// <param name="Option">是否精确0-模糊 1-精确</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQulRegByCol(System.Security.Principal.IPrincipal objPri, out DataTable dtRegister, string strFeild, string strValue, string Option)
        {
            dtRegister = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegByDate");
            if (lngRes < 0)
                return lngRes;
            string strSQL;
            if (Option == "1")
            {
                strSQL = @"SELECT distinct
   A.REGID , A.CARDID , A.REGDATE , A.DEPTID , A.DOCID ,A.DEPTNAME , A.DOCNAME
 , A.REGEMP , case when A.PSTATUS=1 then '候诊' when A.PSTATUS=2 then '就诊'  when A.PSTATUS=3 then '取消' when A.PSTATUS=4 then '结帐' end as PSTATUS , A.REGTYPEID , A.PATTYPEID , A.REGNO
 , case when A.FLAG=1 then '正常' when A.FLAG=2 then '预约'  when A.FLAG=3 then '退号' end as FLAG , A.DROPDATE , A.RECORDDATE ,
case when a.paytype=0 then '自费' when a.paytype=1 then '记帐'  when a.paytype=2 then '支票' end as paytype, A.PATTYPENAME
 , A.REGTYPENAME , A.NAME , A.SEX , A.BIRTH , A.PATID
 ,  A.AGE ,  A.PLANPERIOD
 , A.STARTTIME , A.ENDTIME , A.ADDRESS , A.EMPNO , A.ORDERNO
FROM
   ICARE.VW_OPREGISTER A where a." + strFeild + "='" + strValue + "' and a.regdate >=trunc(sysdate) and a.regdate < trunc(sysdate + 1) ";
            }
            else
            {
                strSQL = @"SELECT distinct
   A.REGID , A.CARDID , A.REGDATE , A.DEPTID , A.DOCID ,A.DEPTNAME , A.DOCNAME
 , A.REGEMP , case when A.PSTATUS=1 then '候诊' when A.PSTATUS=2 then '就诊'  when A.PSTATUS=3 then '取消' when A.PSTATUS=4 then '结帐' end as PSTATUS , A.REGTYPEID , A.PATTYPEID , A.REGNO
 , case when A.FLAG=1 then '正常' when A.FLAG=2 then '预约'  when A.FLAG=3 then '退号' end as FLAG , A.DROPDATE , A.RECORDDATE ,
case when a.paytype=0 then '自费' when a.paytype=1 then '记帐'  when a.paytype=2 then '支票' end as paytype, A.PATTYPENAME
 , A.REGTYPENAME , A.NAME , A.SEX , A.BIRTH , A.PATID
 ,  A.AGE ,  A.PLANPERIOD
 , A.STARTTIME , A.ENDTIME , A.ADDRESS , A.EMPNO , A.ORDERNO
FROM
   ICARE.VW_OPREGISTER A where a." + strFeild + "like '%" + strValue + "'%";
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtRegister);

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

        #region 查询挂号费用(挂号模块使用)
        /// <summary>
        /// 查询挂号费用
        /// <param name="objPri"></param>
        /// <param name="strRegisterID">挂号ID</param>
        /// <param name="dtRegister">返回表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQulRegDetailByID(System.Security.Principal.IPrincipal objPri, string strRegisterID, out DataTable dtRegister)
        {
            dtRegister = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegDetailByID");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"SELECT
   A.REGISTERID_CHR , A.CHARGEID_CHR , A.CHARGENAME_CHR , A.PAYMENT_MNY , A.DISCOUNT_DEC,a.MEMO_VCHR
FROM
   V_OPR_PATIENTREGDETAIL A where REGISTERID_CHR='" + strRegisterID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtRegister);

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


        #region 查询挂号费用(查询模块使用）
        /// <summary>
        /// 查询挂号费用(查询模块使用）
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strRegisterID">挂号ID</param>
        /// <param name="dtRegister">返回表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQulRegDetailByIDFind(System.Security.Principal.IPrincipal objPri, string strRegisterID, out DataTable dtRegister)
        {
            dtRegister = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegDetailByIDFind");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"SELECT
   A.REGISTERID_CHR , A.CHARGEID_CHR , A.CHARGENAME_CHR , A.PAYMENT_MNY , A.DISCOUNT_DEC,a.MEMO_VCHR
FROM
   V_OPR_PATIENTREGDETAIL A where REGISTERID_CHR='" + strRegisterID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtRegister);
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

        #region 退号
        /// <summary>
        /// 退号
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strRegisterID"></param>
        /// <param name="strRturnRegEmpno"></param>
        /// <param name="strReturndate"></param>
        /// <param name="newID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCancelReg(System.Security.Principal.IPrincipal objPri, string strRegisterID, string strRturnRegEmpno, string strReturndate, string ConfirmID, out string newID)
        {
            newID = "";
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulRegByDate");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string strSQL = @"select registerid_chr, patientcardid_chr, registerdate_dat, diagdept_chr,
                                    diagdoctor_chr, registeremp_chr, pstatus_int, registertypeid_chr,
                                    paytypeid_chr, registerno_chr, flag_int, returnemp_chr, returndate_dat,
                                    recorddate_dat, planperiod_chr, patientid_chr, paytype_int,
                                    balance_dat, invno_chr, balanceemp_chr, bespeakdate_dat, datespace,
                                    confirmemp_chr, confirmdate_dat, takedoctor_chr
                               from t_opr_patientregister
                              where registerid_chr = ?";
            DataTable m_dtgRegister = new DataTable();
            IDataParameter[] objParamArr = null;
            try
            {                
                HRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strRegisterID;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtgRegister, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"update t_opr_waitdiaglist
                          set pstatus_int = 2
                        where registerid_chr = ?";
            try
            {
                objParamArr = null;
                HRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strRegisterID;
                long lngRecff = -1;
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecff, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            newID = null;
            // HRPSvc.m_lngGenerateNewID("t_opr_patientregister", "REGISTERID_CHR", out newID);
            strSQL = @"select seq_oppateintregister.nextval
                         from dual";
            DataTable m_objtempTabled = new DataTable();
            try
            {

                lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_objtempTabled);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (m_objtempTabled.Rows.Count > 0)
            {
                newID = m_objtempTabled.Rows[0][0].ToString();
            }
            string DateNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (m_dtgRegister.Rows[0]["PSTATUS_INT"].ToString().Trim() == "4")
                m_dtgRegister.Rows[0]["PSTATUS_INT"] = "3";
            if (lngRes > 0 && m_dtgRegister.Rows.Count > 0)
            {
                strSQL = @"insert into t_opr_patientregister(REGISTERID_CHR,PATIENTCARDID_CHR,REGISTERDATE_DAT,DIAGDEPT_CHR,DIAGDOCTOR_CHR,REGISTEREMP_CHR,PSTATUS_INT,REGISTERTYPEID_CHR,PAYTYPEID_CHR,REGISTERNO_CHR,FLAG_INT,RETURNEMP_CHR,RETURNDATE_DAT,RECORDDATE_DAT,PLANPERIOD_CHR,PATIENTID_CHR,PAYTYPE_INT,INVNO_CHR, confirmemp_chr, confirmdate_dat)
                values(?,?,To_Date(?,'yyyy-mm-dd hh24:mi:ss'),?,?,?,?,?,?,?,3,?,To_Date(?,'yyyy-mm-dd hh24:mi:ss'),To_Date(?,'yyyy-mm-dd hh24:mi:ss'),?,?,?,?,?, sysdate)";
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(18, out paramArr);
                    paramArr[0].Value = newID;
                    paramArr[1].Value = m_dtgRegister.Rows[0]["PATIENTCARDID_CHR"].ToString();
                    paramArr[2].Value = m_dtgRegister.Rows[0]["REGISTERDATE_DAT"].ToString();
                    paramArr[3].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
                    paramArr[4].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString();
                    paramArr[5].Value = m_dtgRegister.Rows[0]["REGISTEREMP_CHR"].ToString();
                    paramArr[6].Value = m_dtgRegister.Rows[0]["PSTATUS_INT"].ToString();
                    paramArr[7].Value = m_dtgRegister.Rows[0]["REGISTERTYPEID_CHR"].ToString();
                    paramArr[8].Value = m_dtgRegister.Rows[0]["PAYTYPEID_CHR"].ToString();
                    paramArr[9].Value = m_dtgRegister.Rows[0]["REGISTERNO_CHR"].ToString();
                    paramArr[10].Value = strRturnRegEmpno;
                    paramArr[11].Value = strReturndate;
                    paramArr[12].Value = DateNow;
                    paramArr[13].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString();
                    paramArr[14].Value = m_dtgRegister.Rows[0]["PATIENTID_CHR"].ToString();
                    paramArr[15].Value = m_dtgRegister.Rows[0]["PAYTYPE_INT"].ToString();
                    paramArr[16].Value = m_dtgRegister.Rows[0]["INVNO_CHR"].ToString();
                    paramArr[17].Value = ConfirmID;
                    long lngRecordsAffected = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                DataTable m_dtgRegisterTail = new DataTable();
                strSQL = @"select registerid_chr, chargeid_chr, payment_mny, discount_dec
                             from t_opr_patientregdetail
                            where registerid_chr = ?";
                try
                {
                    objParamArr = null;
                    HRPSvc.CreateDatabaseParameter(1, out objParamArr);
                    objParamArr[0].Value = strRegisterID;
                    ((Oracle.DataAccess.Client.OracleParameter)objParamArr[0]).OracleDbType = Oracle.DataAccess.Client.OracleDbType.Char;
                
                    lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtgRegisterTail, objParamArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                int count = m_dtgRegisterTail.Rows.Count;
                strSQL = @"insert into t_opr_patientregdetail
            (registerid_chr, chargeid_chr, payment_mny, discount_dec
            )
             values (?, ?, ?, ?
            )";
                for (int i1 = 0; i1 < count; i1++)
                {

                    System.Data.IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(4, out paramArr);
                    paramArr[0].Value = newID;
                    paramArr[1].Value = m_dtgRegisterTail.Rows[i1]["CHARGEID_CHR"].ToString();
                    paramArr[2].Value = "-"+m_dtgRegisterTail.Rows[i1]["PAYMENT_MNY"].ToString();
                    paramArr[3].Value = m_dtgRegisterTail.Rows[i1]["DISCOUNT_DEC"].ToString();


                    try
                    {
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
                strSQL = @"update t_aid_table_sequence_id set MAX_SEQUENCE_ID_CHR='" + newID + "' where TABLE_NAME_VCHR='t_opr_patientregister'";
                try
                {
                    objParamArr = null;
                    HRPSvc.CreateDatabaseParameter(1, out objParamArr);
                    objParamArr[0].Value = newID;
                    long lngRecff = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecff, objParamArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
                return 0;
            strSQL = "P_OPR_MARKREG";
            clsSQLParamDefinitionVO[] objParameter = new clsSQLParamDefinitionVO[5];
            for (int i = 0; i < objParameter.Length; i++)
                objParameter[i] = new clsSQLParamDefinitionVO();
            objParameter[0].objParameter_Value = newID;
            objParameter[1].objParameter_Value = strRturnRegEmpno;
            objParameter[2].objParameter_Value = 0;
            objParameter[3].objParameter_Value = strReturndate;
            objParameter[0].strParameter_Type = "Varchar2";
            objParameter[1].strParameter_Type = "Varchar2";
            objParameter[2].strParameter_Type = "Int32";
            objParameter[3].strParameter_Type = "Varchar2";
            objParameter[4].strParameter_Type = "Int32";
            objParameter[4].strParameter_Direction = "Output";

            try
            {
                lngRes = HRPSvc.lngExecuteParameterProc(strSQL, objParameter);
                string strReturn = objParameter[4].objParameter_Value.ToString().Trim();
                if (strReturn == "-1")
                {
                    return 0;
                }
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取退号的状态
        /// <summary>
        /// 获取退号的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strSetStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSetStatus(System.Security.Principal.IPrincipal p_objPrincipal, out int strSetStatus)
        {
            strSetStatus = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetSetStatus");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select setstatus_int
  from t_sys_setting
 where setid_chr = '0001'";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
                strSetStatus = int.Parse(dt.Rows[0][0].ToString());
            else
                strSetStatus = -1;
            return lngRes;

        }
        #endregion

        #region 还原退号
        /// <summary>
        /// 还原退号
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strRegisterID"></param>
        /// <param name="strResetRegEmpno"></param>
        /// <param name="strResetRegdate"></param>
        /// <param name="newID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngResetReg(System.Security.Principal.IPrincipal objPri, string strRegisterID, string strResetRegEmpno, string strResetRegdate, out string newID, out int waitNO)
        {
            newID = "";
            waitNO = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngResetReg");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string strSQL = @"select a.registerid_chr, a.patientcardid_chr, a.registerdate_dat,
       a.diagdept_chr, a.diagdoctor_chr, a.registeremp_chr, a.pstatus_int,
       a.registertypeid_chr, a.paytypeid_chr, a.registerno_chr, a.flag_int,
       a.returnemp_chr, a.returndate_dat, a.recorddate_dat, a.planperiod_chr,
       a.patientid_chr, a.paytype_int, a.balance_dat, a.invno_chr,
       a.balanceemp_chr, a.bespeakdate_dat, a.datespace, a.confirmemp_chr,
       a.confirmdate_dat
       from t_opr_patientregister a
       where a.registerid_chr = ?";
            DataTable m_dtgRegister = new DataTable();
            try
            {
                System.Data.IDataParameter[] param = null;
                HRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strRegisterID;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtgRegister, param);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            newID = null;

            strSQL = @"select seq_oppateintregister.nextval
                       from dual";
            DataTable m_objtempTabled = new DataTable();
            try
            {

                lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_objtempTabled);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (m_objtempTabled.Rows.Count > 0)
            {
                newID = m_objtempTabled.Rows[0][0].ToString();
            }
            string DateNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (lngRes > 0 && m_dtgRegister.Rows.Count > 0)
            {
                strSQL = @"insert into t_opr_patientregister
            (registerid_chr, patientcardid_chr, registerdate_dat,
             diagdept_chr, diagdoctor_chr, registeremp_chr, pstatus_int,
             registertypeid_chr, paytypeid_chr, registerno_chr, flag_int,
             recorddate_dat, planperiod_chr, patientid_chr, paytype_int,
             invno_chr, returnemp_chr, returndate_dat
            )
            values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
             ?, ?, ?, 1,
             ?, ?, ?, 4,
             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?,
             ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss')
            )";
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(16, out paramArr);
                    paramArr[0].Value = newID;
                    paramArr[1].Value = m_dtgRegister.Rows[0]["PATIENTCARDID_CHR"].ToString();
                    paramArr[2].Value = m_dtgRegister.Rows[0]["REGISTERDATE_DAT"].ToString();
                    paramArr[3].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
                    paramArr[4].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString();
                    paramArr[5].Value = m_dtgRegister.Rows[0]["REGISTEREMP_CHR"].ToString();
                    paramArr[6].Value = m_dtgRegister.Rows[0]["REGISTERTYPEID_CHR"].ToString();
                    paramArr[7].Value = m_dtgRegister.Rows[0]["PAYTYPEID_CHR"].ToString();
                    paramArr[8].Value = m_dtgRegister.Rows[0]["REGISTERNO_CHR"].ToString();
                    paramArr[9].Value = DateNow;
                    paramArr[10].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString();
                    paramArr[11].Value = m_dtgRegister.Rows[0]["PATIENTID_CHR"].ToString();
                    paramArr[12].Value = m_dtgRegister.Rows[0]["PAYTYPE_INT"].ToString();
                    paramArr[13].Value = m_dtgRegister.Rows[0]["INVNO_CHR"].ToString();
                    paramArr[14].Value = strResetRegEmpno;
                    paramArr[15].Value = strResetRegdate;
                    long lngRecordsAffected = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                string newWaitID = null;
//                strSQL = @"select max (to_number (waitdiaglistid_chr)) + 1
//                           from t_opr_waitdiaglist";
                strSQL = @"select lpad (seq_waitdiaglistid.nextval, 18, '0')
  from dual";
                DataTable m_objTable = new DataTable();
                try
                {
                    lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_objTable);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                newWaitID = m_objTable.Rows[0][0].ToString();

                //if (m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString() == null || m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString() == "")
                //{
//                    strSQL = @"select count (*)
//  from t_opr_waitdiaglist
// where pstatus_int = 1
//   and waitdiagdept_chr = ?
//   and registerdate_dat = to_date (?, 'yyyy-MM-dd')";
                    strSQL = @"select count (*)
  from t_opr_waitdiaglist
 where  waitdiagdept_chr = ?
   and registerdate_dat = to_date (?, 'yyyy-MM-dd')";
//                    strSQL = @"select substr (to_char (seq_waitlistno.nextval), -4)
//                               from dual";
                    DataTable maxwait = new DataTable();
                    try
                    {
                        System.Data.IDataParameter[] param = null;
                        HRPSvc.CreateDatabaseParameter(2, out param);
                        param[0].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
                        param[1].Value = strResetRegdate;
                        lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref maxwait, param);
                        //lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref maxwait);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                    if (maxwait.Rows.Count > 0)
                    {
                        waitNO = Convert.ToInt32(maxwait.Rows[0][0]) + 1;
                        strSQL = @"insert into t_opr_waitdiaglist
            (waitdiaglistid_chr, registerid_chr, waitdiagdept_chr, order_int,
             registerdate_dat, pstatus_int, registerop_vchr
            )
     values (?, ?, ?, ?,
             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), 1, ?
            )";

                        System.Data.IDataParameter[] paramArr = null;
                        HRPSvc.CreateDatabaseParameter(6, out paramArr);
                        paramArr[0].Value = newWaitID;
                        paramArr[1].Value = newID;
                        paramArr[2].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
                        paramArr[3].Value = waitNO.ToString();
                        paramArr[4].Value = strResetRegdate;
                        paramArr[5].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString().Trim();
                        long lngRecordsAffected = -1;

                        try
                        {
                            lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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
                        strSQL = @"insert into t_opr_waitdiaglist
            (waitdiaglistid_chr, registerid_chr, waitdiagdept_chr, order_int,
             registerdate_dat, pstatus_int, registerop_vchr
            )
     values (?, ?, ?, 1,
             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), 1, ?
            )";

                        System.Data.IDataParameter[] paramArr = null;
                        HRPSvc.CreateDatabaseParameter(5, out paramArr);
                        paramArr[0].Value = newWaitID;
                        paramArr[1].Value = newID;
                        paramArr[2].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
                        paramArr[3].Value = strResetRegdate;
                        paramArr[4].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString().Trim();

                        long lngRecordsAffected = -1;

                        try
                        {
                            lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                    }

                //}
//                else
//                {
////                    strSQL = @"select count (*)
////                          from t_opr_waitdiaglist
////                           where pstatus_int = 1
////                           and waitdiagdept_chr = ?
////                           and waitdiagdr_chr = ?
////                          and registerdate_dat = to_date (?, 'yyyy-MM-dd')";
////                strSQL = @"select substr (to_char (seq_waitlistno.nextval), -4)
////                       from dual";
//                    strSQL = @"select count (*)
//                           from t_opr_waitdiaglist
//                           where waitdiagdept_chr = ?
//                           and waitdiagdr_chr = ?
//                           and registerdate_dat = to_date (?, 'yyyy-MM-dd')";
//                    DataTable maxwait = new DataTable();
//                    try
//                    {

//                        System.Data.IDataParameter[] param = null;
//                        HRPSvc.CreateDatabaseParameter(3, out param);
//                        param[0].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
//                        param[1].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString().Trim();
//                        param[2].Value = strResetRegdate;
//                        lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref maxwait, param);
//                       // lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref maxwait);
//                    }
//                    catch (Exception objEx)
//                    {
//                        string strTmp = objEx.Message;
//                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                        bool blnRes = objLogger.LogError(objEx);
//                    }
//                    if (maxwait.Rows.Count>0)
//                    {
//                        waitNO = Convert.ToInt32(maxwait.Rows[0][0])+1;
//                        strSQL = @"insert into t_opr_waitdiaglist
//            (waitdiaglistid_chr, registerid_chr, waitdiagdept_chr, order_int,
//             registerdate_dat, pstatus_int, registerop_vchr, waitdiagdr_chr
//            )
//     values (?, ?, ?, ?,
//             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), 1, ?, ?
//            )";

//                        System.Data.IDataParameter[] paramArr = null;
//                        HRPSvc.CreateDatabaseParameter(7, out paramArr);
//                        paramArr[0].Value = newWaitID;
//                        paramArr[1].Value = newID;
//                        paramArr[2].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
//                        paramArr[3].Value = waitNO.ToString();
//                        paramArr[4].Value = strResetRegdate;
//                        paramArr[5].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString().Trim();
//                        paramArr[6].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString().Trim();


//                        long lngRecordsAffected = -1;

//                        try
//                        {
//                            lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
//                        }
//                        catch (Exception objEx)
//                        {
//                            string strTmp = objEx.Message;
//                            com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                            bool blnRes = objLogger.LogError(objEx);
//                        }

//                    }
//                    else
//                    {
//                        strSQL = @"insert into t_opr_waitdiaglist
//            (waitdiaglistid_chr, registerid_chr, waitdiagdept_chr, order_int,
//             registerdate_dat, pstatus_int, registerop_vchr, waitdiagdr_chr
//            )
//     values (?, ?, ?, 1,
//             to_date (?, 'yyyy-mm-dd hh24:mi:ss'), 1, ?, ?
//            )";

//                        System.Data.IDataParameter[] paramArr = null;
//                        HRPSvc.CreateDatabaseParameter(6, out paramArr);
//                        paramArr[0].Value = newWaitID;
//                        paramArr[1].Value = newID;
//                        paramArr[2].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();

//                        paramArr[3].Value = strResetRegdate;
//                        paramArr[4].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString().Trim();
//                        paramArr[5].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString().Trim();


//                        long lngRecordsAffected = -1;

//                        try
//                        {
//                            lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
//                        }
//                        catch (Exception objEx)
//                        {
//                            string strTmp = objEx.Message;
//                            com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                            bool blnRes = objLogger.LogError(objEx);
//                        }

//                    }


//                }
                DataTable m_dtgRegisterTail = new DataTable();
                strSQL = @"select a.registerid_chr, a.chargeid_chr, a.payment_mny, a.discount_dec
                           from t_opr_patientregdetail a
                           where a.registerid_chr = ?";
                try
                {
                    System.Data.IDataParameter[] param = null;
                    HRPSvc.CreateDatabaseParameter(1, out param);
                    param[0].Value = strRegisterID;
                    ((Oracle.DataAccess.Client.OracleParameter)param[0]).OracleDbType = Oracle.DataAccess.Client.OracleDbType.Char;
                    lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtgRegisterTail, param);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                for (int i1 = 0; i1 < m_dtgRegisterTail.Rows.Count; i1++)
                {
                    strSQL = @"insert into t_opr_patientregdetail
            (registerid_chr, chargeid_chr, payment_mny, discount_dec
            )
            values (?, ?, ?, ?
            )";
                    try
                    {
                        System.Data.IDataParameter[] param = null;
                        HRPSvc.CreateDatabaseParameter(4, out param);
                        param[0].Value = newID;
                        param[1].Value = m_dtgRegisterTail.Rows[i1]["CHARGEID_CHR"].ToString();
                        param[2].Value = Math.Abs(Convert.ToDecimal( m_dtgRegisterTail.Rows[i1]["PAYMENT_MNY"].ToString()));
                        param[3].Value = m_dtgRegisterTail.Rows[i1]["DISCOUNT_DEC"].ToString();
                        long lngAffected = -1;
                        lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, param);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }

                }
                strSQL = @"update t_aid_table_sequence_id
   set max_sequence_id_chr =?
 where table_name_vchr = 't_opr_patientregister'";
                try
                {
                    System.Data.IDataParameter[] param = null;
                    HRPSvc.CreateDatabaseParameter(1, out param);
                    param[0].Value = newID;
                    long lngAffected = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, param);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            strSQL = "P_OPR_MARKREG";
            clsSQLParamDefinitionVO[] objParameter = new clsSQLParamDefinitionVO[5];
            for (int i = 0; i < objParameter.Length; i++)
                objParameter[i] = new clsSQLParamDefinitionVO();
            objParameter[0].objParameter_Value = strRegisterID;
            objParameter[1].objParameter_Value = strResetRegEmpno;
            objParameter[2].objParameter_Value = 1;
            objParameter[3].objParameter_Value = strResetRegdate;

            objParameter[0].strParameter_Type = "Varchar2";
            objParameter[1].strParameter_Type = "Varchar2";
            objParameter[2].strParameter_Type = "Int32";
            objParameter[3].strParameter_Type = "Varchar2";
            objParameter[4].strParameter_Type = "Int32";
            objParameter[4].strParameter_Direction = "Output";

            try
            {
                lngRes = HRPSvc.lngExecuteParameterProc(strSQL, objParameter);
                string strReturn = objParameter[4].objParameter_Value.ToString().Trim();
                if (strReturn == "-1")
                {
                    return 0;
                }
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 检查该挂号是否开过处方或结帐
        /// <summary>
        /// 检查该挂号是否开过处方或结帐
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="registerID"></param>
        /// <param name="isReMoney"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckRegister(System.Security.Principal.IPrincipal p_objPrincipal, string registerID, out bool isReMoney, out string outint)
        {
            outint = "-1";
            isReMoney = false;
            //检查是否有使用些函数的权限
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckRegister");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string strSQL = @"select setstatus_int from t_sys_setting where setid_chr='0003'";
            DataTable bt2 = new DataTable();
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref bt2);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            if (bt2.Rows.Count > 0)
            {
                outint = bt2.Rows[0]["setstatus_int"].ToString();
            }
            DataTable bt = new DataTable();
            strSQL = @"select OUTPATRECIPEID_CHR from t_opr_outpatientrecipe where REGISTERID_CHR='" + registerID + "'";
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref bt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            if (bt2.Rows.Count == 0 || bt2.Rows[0]["setstatus_int"].ToString() == "0")
            {
                if (bt.Rows.Count > 0)
                {
                    isReMoney = true;
                    return lngRes;
                }
                else
                {
                    isReMoney = false;
                    return lngRes;
                }
            }
            else
            {
                DataTable bt1 = new DataTable();
                for (int i1 = 0; i1 < bt.Rows.Count; i1++)
                {
                    strSQL = @"select INVOICENO_VCHR from t_opr_outpatientrecipeinv where OUTPATRECIPEID_CHR='" + bt.Rows[i1]["OUTPATRECIPEID_CHR"].ToString().Trim() + "'";
                    try
                    {
                        lngRes = HRPSvc.DoGetDataTable(strSQL, ref bt1);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp1 = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                        bool blnRes1 = objLogger1.LogError(objEx);
                    }
                    if (lngRes == 0)
                    {
                        return lngRes;
                    }
                    if (bt1.Rows.Count > 0)
                    {
                        isReMoney = true;
                        return lngRes;
                    }
                }
            }
            isReMoney = false;
            return lngRes;
        }
        #endregion

        #region 退卡系统
        #region 根据日期返回己发卡信息
        /// <summary>
        /// 根据日期返回己发卡信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCarData(System.Security.Principal.IPrincipal p_objPrincipal, string startDate, string endDate, out DataTable dt, string strCardID, string strName)
        {
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCarData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select a.PATIENTCARDID_CHR,a.PATIENTID_CHR,Case when a.STATUS_INT=0 then '已退卡' when a.STATUS_INT<>0 then '正常' end as status,b.LASTNAME_VCHR  from t_bse_patientcard a,t_bse_patient b where a.PATIENTID_CHR=b.PATIENTID_CHR";
            if (startDate != null)
            {
                strSQL += @" and ISSUE_DATE between  To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and  To_Date('" + endDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')";
            }
            if (strCardID != null)
            {
                strSQL += @" and a.PATIENTCARDID_CHR='" + strCardID + "'";
            }
            if (strName != null)
            {
                strSQL += @" and b.LASTNAME_VCHR like '" + strName + "'";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 退卡
        [AutoComplete]
        public long m_lngReturnCar(System.Security.Principal.IPrincipal p_objPrincipal, string CarID, string patientNO)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCarData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"update t_bse_patientcard set STATUS_INT=0 where PATIENTCARDID_CHR='" + CarID + "' and PATIENTID_CHR='" + patientNO + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 修改卡号
        [AutoComplete]
        public long m_lngUpdateCar(System.Security.Principal.IPrincipal p_objPrincipal, string CarID, string patientNO, string strEmpID, string oldCardID)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngUpdateCar");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = @"update t_bse_patientcard set PATIENTCARDID_CHR='" + CarID + "'  where PATIENTID_CHR='" + patientNO + "'";
            #region 写入痕迹记录
            clsRecordMark_VO Markvo = new clsRecordMark_VO();
            clsRecordMark recordMark = new clsRecordMark();
            Markvo.m_strOPERATORID_CHR = strEmpID;
            Markvo.m_strTABLESEQID_CHR = "1";
            Markvo.m_strRECORDDETAIL_VCHR = strSQL;
            recordMark.m_mthAddNewRecord(Markvo);
            #endregion
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }

            strSQL = @"update ar_content set CONTROLID='" + CarID + "'  where CTL_CONTENT='m_txtCardID' and ctl_content='" + oldCardID + "'";
            //			#region 写入痕迹记录
            //			Markvo.m_strOPERATORID_CHR=strEmpID;
            //			Markvo.m_strTABLESEQID_CHR="1";
            //			Markvo.m_strRECORDDETAIL_VCHR=strSQL;
            //			recordMark.m_mthAddNewRecord(Markvo);
            //			#endregion
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"update ar_common_apply  set CARDNO='" + CarID + "'  where CARDNO='" + oldCardID + "'";
            //			#region 写入痕迹记录
            //			Markvo.m_strOPERATORID_CHR=strEmpID;
            //			Markvo.m_strTABLESEQID_CHR="1";
            //			Markvo.m_strRECORDDETAIL_VCHR=strSQL;
            //			recordMark.m_mthAddNewRecord(Markvo);
            //			#endregion
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"update t_opr_pacs_booking_order  set PATIENT_NO_CHR='" + CarID + "'  where PATIENT_NO_CHR='" + oldCardID + "'";
            //			#region 写入痕迹记录
            //			Markvo.m_strOPERATORID_CHR=strEmpID;
            //			Markvo.m_strTABLESEQID_CHR="1";
            //			Markvo.m_strRECORDDETAIL_VCHR=strSQL;
            //			recordMark.m_mthAddNewRecord(Markvo);
            //			#endregion
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @" update t_opr_patientregister set PATIENTCARDID_CHR='" + CarID + "'  where PATIENTID_CHR='" + patientNO + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 判断新的卡号是否存在
        /// <summary>
        /// 判断新的卡号是否存在
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="CarID"></param>
        /// <returns>返回3存在</returns>
        [AutoComplete]
        public long m_lngCheckCarID(System.Security.Principal.IPrincipal p_objPrincipal, string CarID)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckCarID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select patientcardid_chr, patientid_chr, issue_date, status_int
                                from t_bse_patientcard
                               where patientcardid_chr = ? and status_int != 0";
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = CarID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
                objHRPSvc.Dispose();
                if (dtResult.Rows.Count > 0 && dtResult.Rows[0]["PATIENTCARDID_CHR"].ToString() == CarID)
                {
                    lngRes = 3;
                    return lngRes;
                }
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #endregion

        #region  挂号结帐报表
        /// <summary>
        ///  挂号结帐报表
        ///  备注：没使用(2007-09-27)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPlan"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckOutRep(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtSource, string date, out DataTable dtSourceDetail, out string regNo)
        {
            long lngRes = 0;
            dtSource = new DataTable();
            dtSourceDetail = new DataTable();
            regNo = "";
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngDoUpdWeekPlanByID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            //			string strSQL = @"select * from V_CHECKOUTREGREPORD order by paytypeid_chr" ;
            string strSQL = @"select * from (select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as regcount,
'现' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat = to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.flag_int = 3 and pstatus_int<>4
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a

union all

select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as regcount,
'记' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.flag_int = 3 and pstatus_int<>4 
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat<= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a

union all

select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as regcount,
'支' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.flag_int = 3 and pstatus_int<>4
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat<= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a) f order by f.paytypename_vchr";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtSource);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            try
            {
                strSQL = "select min(registerno_chr) as minRegNo,max(registerno_chr) as maxRegNo from t_opr_patientregister where registerdate_dat = to_date('" + date + @"','yyyy_MM_dd')";
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtSourceDetail);
                if (dtSourceDetail.Rows.Count > 0)
                {
                    regNo = dtSourceDetail.Rows[0][0].ToString() + "-" + dtSourceDetail.Rows[0][1].ToString();
                    dtSourceDetail.Clear();
                }
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }

            try
            {
                strSQL = @"select a.registerno_chr,d.NAME_VCHR,b.paytypename_vchr,
      case  when a.paytype_int=0 then '现金'
      when a.paytype_int = 1 then '记帐'
      when a.paytype_int = 2 then '支票'
      else ''
      end as paytype_int,
      (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='001') as rcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='002') as dcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='003') as gcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='004') as ccharge,
        c.LASTNAME_VCHR,a.registerdate_dat
from t_opr_patientregister a,t_bse_patientpaytype b,T_BSE_EMPLOYEE c,T_BSE_PATIENTIDX d

where a.paytypeid_chr = b.paytypeid_chr
      and a.RETURNEMP_CHR = c.empid_chr(+)
      and a.patientid_chr = d.patientid_chr
      and a.registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
	  and a.flag_int = 3";
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtSourceDetail);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 挂号结帐报表（新）
        /// <summary>
        /// 挂号结帐报表（新）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtTolSource">返回有效数据</param>
        /// <param name="date">结帐日期</param>
        /// <param name="strempno">结帐人ID</param>
        /// <param name="dtRestoreDetail">返回退号数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngEndReport(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtTolSource, string date, string strempno, out DataTable dtRestoreDetail)
        {
            long lngRes = 0;
            dtRestoreDetail = new DataTable();
            dtTolSource = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngEndReport");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            IDataParameter[] objParamArr = null;
            //string strSQL = "select a.REGISTERID_CHR,a.REGISTERDATE_DAT,a.FLAG_INT,a.REGISTERNO_CHR,a.INVNO_CHR,g.LASTNAME_VCHR as PatientName,f.PAYTYPENAME_VCHR,c.LASTNAME_VCHR,e.DEPTNAME_VCHR," +
            //    "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
            //    "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='001') as rcharge," +
            //    "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
            //    "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='002') as dcharge, " +
            //    "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
            //    "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='003') as gcharge," +
            //    "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
            //    "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='004') as ccharge ,  " +
            //    "a.RECORDDATE_DAT" +
            //    " from t_opr_patientregister a,t_bse_patientpaytype b,T_BSE_EMPLOYEE c,t_bse_patient g,t_bse_patientpaytype f,T_BSE_PATIENTIDX d,T_BSE_DEPTDESC e 	" +
            //    "where a.paytypeid_chr = b.paytypeid_chr " +
            //    "and a.DIAGDOCTOR_CHR = c.empid_chr(+) " +
            //    "and a.patientid_chr = d.patientid_chr " +
            //    " and a.DIAGDEPT_CHR = e.DEPTID_CHR " +
            //    " and a.PATIENTID_CHR = g.PATIENTID_CHR " +
            //    " and a.PAYTYPEID_CHR = f.PAYTYPEID_CHR " +
            //    " AND (a.REGISTEREMP_CHR='" + strempno + "' and a.REGISTERDATE_DAT<=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss') and flag_int<=2 or a.RETURNEMP_CHR='" + strempno + "' and a.RETURNDATE_DAT<=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss') and flag_int=4)" +
            //    " and BALANCE_DAT is null ";

            string strSQL = @"select a.registerid_chr, a.registerdate_dat, a.flag_int, a.registerno_chr,
                                     a.invno_chr, g.lastname_vchr as patientname, f.paytypename_vchr,
                                     c.lastname_vchr, e.deptname_vchr,
                                     (select payment_mny * discount_dec
                                        from t_opr_patientregdetail d
                                       where d.registerid_chr = a.registerid_chr
                                         and d.chargeid_chr = '001') as rcharge,
                                     (select payment_mny * discount_dec
                                        from t_opr_patientregdetail d
                                       where d.registerid_chr = a.registerid_chr
                                         and d.chargeid_chr = '002') as dcharge,
                                     (select payment_mny * discount_dec
                                        from t_opr_patientregdetail d
                                       where d.registerid_chr = a.registerid_chr
                                         and d.chargeid_chr = '003') as gcharge,
                                     (select payment_mny * discount_dec
                                        from t_opr_patientregdetail d
                                       where d.registerid_chr = a.registerid_chr
                                         and d.chargeid_chr = '004') as ccharge,
                                     a.recorddate_dat
                                from t_opr_patientregister a,
                                     t_bse_patientpaytype b,
                                     t_bse_employee c,
                                     t_bse_patient g,
                                     t_bse_patientpaytype f,
                                     t_bse_patientidx d,
                                     t_bse_deptdesc e
                               where a.paytypeid_chr = b.paytypeid_chr
                                 and a.diagdoctor_chr = c.empid_chr(+)
                                 and a.patientid_chr = d.patientid_chr
                                 and a.diagdept_chr = e.deptid_chr
                                 and a.patientid_chr = g.patientid_chr
                                 and a.paytypeid_chr = f.paytypeid_chr
                                 and (       a.registeremp_chr = ?
                                         and a.registerdate_dat <= to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                         and flag_int <= 2
                                      or     a.returnemp_chr = ?
                                         and a.returndate_dat <= to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                         and flag_int = 4
                                     )
                                 and balance_dat is null";
            try
            {
                HRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = strempno;
                objParamArr[1].Value = date;
                objParamArr[2].Value = strempno;
                objParamArr[3].Value = date;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTolSource, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            strSQL = @"select a.registerid_chr, a.registerdate_dat, a.registerno_chr, a.invno_chr,
                              g.lastname_vchr as patientname, f.paytypename_vchr, c.lastname_vchr,
                              e.deptname_vchr,
                              (select payment_mny * discount_dec
                                 from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                              (select payment_mny * discount_dec
                                 from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                              (select payment_mny * discount_dec
                                 from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                              (select payment_mny * discount_dec
                                 from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                              a.recorddate_dat
                         from t_opr_patientregister a,
                              t_bse_patientpaytype b,
                              t_bse_employee c,
                              t_bse_patient g,
                              t_bse_patientpaytype f,
                              t_bse_patientidx d,
                              t_bse_deptdesc e
                        where a.paytypeid_chr = b.paytypeid_chr
                          and a.registeremp_chr = c.empid_chr(+)
                          and a.patientid_chr = d.patientid_chr
                          and a.diagdept_chr = e.deptid_chr
                          and a.patientid_chr = g.patientid_chr
                          and a.paytypeid_chr = f.paytypeid_chr
                          and a.returnemp_chr = ?
                          and balance_dat is null
                          and a.flag_int = 3
                          and a.returndate_dat <= to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
            try
            {
                objParamArr = null;
                HRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strempno;
                objParamArr[1].Value = date;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRestoreDetail, objParamArr);
                HRPSvc.Dispose();
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

        #region 挂号历史结帐报表数据（新）
        /// <summary>
        /// 挂号历史结帐报表数据（新）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtTolSource">返回有效数据</param>
        /// <param name="date">结帐日期</param>
        /// <param name="strempno">结帐人ID</param>
        /// <param name="dtRestoreDetail">返回退号数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHistoryReport(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtTolSource, string date, string strempno, out DataTable dtRestoreDetail)
        {
            long lngRes = 0;
            dtRestoreDetail = new DataTable();
            dtTolSource = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngEndReport");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string strSQL = "select a.REGISTERID_CHR,a.REGISTERDATE_DAT,a.FLAG_INT,a.REGISTERNO_CHR,a.INVNO_CHR,g.LASTNAME_VCHR as PatientName,f.PAYTYPENAME_VCHR,c.LASTNAME_VCHR,e.DEPTNAME_VCHR," +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='001') as rcharge," +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='002') as dcharge, " +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='003') as gcharge," +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='004') as ccharge ,  " +
                "a.RECORDDATE_DAT, to_char(a.RECORDDATE_DAT, 'yyyy-mm-dd hh24:mi:ss') as invodate " +
                " from t_opr_patientregister a,t_bse_patientpaytype b,T_BSE_EMPLOYEE c,t_bse_patient g,t_bse_patientpaytype f,T_BSE_PATIENTIDX d,T_BSE_DEPTDESC e 	" +
                "where a.paytypeid_chr = b.paytypeid_chr " +
                "and a.DIAGDOCTOR_CHR = c.empid_chr(+) " +
                "and a.patientid_chr = d.patientid_chr " +
                " and a.DIAGDEPT_CHR = e.DEPTID_CHR " +
                " and a.PATIENTID_CHR = g.PATIENTID_CHR " +
                " and a.PAYTYPEID_CHR = f.PAYTYPEID_CHR " +
                "and  FLAG_INT<>3 " +
                " AND a.BALANCEEMP_CHR='" + strempno + "'" +
                "and a.BALANCE_DAT=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss')  order by a.INVNO_CHR";
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref dtTolSource);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            strSQL = "select a.REGISTERID_CHR,a.REGISTERDATE_DAT,a.REGISTERNO_CHR,a.INVNO_CHR,g.LASTNAME_VCHR as PatientName,f.PAYTYPENAME_VCHR,c.LASTNAME_VCHR,e.DEPTNAME_VCHR," +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='001') as rcharge," +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='002') as dcharge, " +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='003') as gcharge," +
                "(select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d " +
                "where d.registerid_chr = a.registerid_chr and d.chargeid_chr='004') as ccharge ,  " +
                "a.RECORDDATE_DAT" +
                " from t_opr_patientregister a,t_bse_patientpaytype b,T_BSE_EMPLOYEE c,t_bse_patient g,t_bse_patientpaytype f,T_BSE_PATIENTIDX d,T_BSE_DEPTDESC e 	" +
                "where a.paytypeid_chr = b.paytypeid_chr " +
                "and a.REGISTEREMP_CHR = c.empid_chr(+) " +
                "and a.patientid_chr = d.patientid_chr " +
                " and a.DIAGDEPT_CHR = e.DEPTID_CHR " +
                " and a.PATIENTID_CHR = g.PATIENTID_CHR " +
                " and a.PAYTYPEID_CHR = f.PAYTYPEID_CHR " +
                " AND a.BALANCEEMP_CHR='" + strempno + "'" +
                "and  a.FLAG_INT=3 " +
                "and a.BALANCE_DAT=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss')";
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref dtRestoreDetail);
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
        /// 获取所有的收费员数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtCheckMan"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckMan(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtCheckMan)
        {
            dtCheckMan = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCheckMan");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select distinct a.BALANCEEMP_CHR,b.lastname_vchr from T_OPR_PATIENTREGISTER a,t_bse_employee b where a.BALANCEEMP_CHR=b.empid_chr and a.BALANCEEMP_CHR is not null";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckMan);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;

        }
        #endregion


        #region 收费处挂号发票月统计报表(新)
        [AutoComplete]
        public long m_lngGetRegisterStatData(
            System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strOperatorId,
            string p_strStartDate,
            string p_strEndDate,
            out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetRegisterStatData");
            if (lngRes < 0)//没有使用权限
            {
                return -1;
            }

            String strSQL = string.Empty;



//            StringBuilder strSQL = new StringBuilder(@"select a.registerid_chr,
//                                                        a.invno_chr,
//                                                        a.flag_int,
//                                                        c.chargeid_chr,
//                                                        d.chargename_chr,
//                                                        c.payment_mny,
//                                                        c.discount_dec,
//                                                        b.empid_chr,
//                                                        b.empno_chr,
//                                                        b.lastname_vchr
//                                                      from t_opr_patientregister    a,
//                                                           t_bse_employee           b,
//                                                           t_opr_patientregdetail   c,
//                                                           t_bse_registerchargetype d
//                                                      where a.balanceemp_chr = b.empid_chr
//                                                        and a.registerid_chr = c.registerid_chr
//                                                        and c.chargeid_chr = d.chargeid_chr
//                                                   --     and a.pstatus_int = 4
//                                                   --     and a.flag_int in (1, 3, 4)
//                                                        and a.balance_dat >= ? 
//                                                        and a.balance_dat <= ?");

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objParamerArr = null;

            try
            {
                if (p_strOperatorId.Trim().Length > 0)
                {
                     strSQL = @"
                        select a.registerid_chr,
                               a.invno_chr,
                               a.flag_int,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as cpayment_mny,

                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                               a.registeremp_chr as empid_chr,
                               b.lastname_vchr
                        from t_opr_patientregister    a,
                             t_bse_employee           b
                        where a.registeremp_chr = b.empid_chr(+)
                          and a.balanceemp_chr is not null
                          and a.returnemp_chr is null 
                          and a.registeremp_chr = ?    
                          and a.balance_dat >= ?
                          and a.balance_dat <= ?

                     union all

                        select a.registerid_chr,
                               a.invno_chr,
                               a.flag_int,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as cpayment_mny,

                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                               a.returnemp_chr as empid_chr,
                               b.lastname_vchr
                        from t_opr_patientregister    a,
                             t_bse_employee           b
                        where a.returnemp_chr = b.empid_chr(+)
                          and a.balanceemp_chr is not null
                          and a.returnemp_chr is not null    
                          and a.returnemp_chr = ?
                          and a.balance_dat >= ?
                          and a.balance_dat <= ?
                    order by invno_chr asc";

                    objHRPSvc.CreateDatabaseParameter(6, out objParamerArr);

                    objParamerArr[0].Value = p_strOperatorId;
                    objParamerArr[1].DbType = DbType.Date;
                    objParamerArr[1].Value = Convert.ToDateTime(p_strStartDate);
                    objParamerArr[2].DbType = DbType.Date;
                    objParamerArr[2].Value = Convert.ToDateTime(p_strEndDate);

                    objParamerArr[3].Value = p_strOperatorId;
                    objParamerArr[4].DbType = DbType.Date;
                    objParamerArr[4].Value = Convert.ToDateTime(p_strStartDate);
                    objParamerArr[5].DbType = DbType.Date;
                    objParamerArr[5].Value = Convert.ToDateTime(p_strEndDate);


                }
                else
                {
                     strSQL = @"
                        select a.registerid_chr,
                               a.invno_chr,
                               a.flag_int,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as cpayment_mny,

                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                               a.registeremp_chr as empid_chr,
                               b.lastname_vchr
                       from t_opr_patientregister    a,
                            t_bse_employee           b
                       where a.registeremp_chr = b.empid_chr(+)
                         and a.balanceemp_chr is not null
                         and a.returnemp_chr is null     
                         and a.balance_dat >= ?
                         and a.balance_dat <= ?

                     union all

                      select a.registerid_chr,
                             a.invno_chr,
                             a.flag_int,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '001') as rpayment_mny,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '002') as dpayment_mny,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '003') as gpayment_mny,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '004') as cpayment_mny,

                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '001') as rcharge,
                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '002') as dcharge,
                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '003') as gcharge,
                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '004') as ccharge,
                             a.returnemp_chr as empid_chr,
                             b.lastname_vchr
                        from t_opr_patientregister    a,
                             t_bse_employee           b
                        where a.returnemp_chr = b.empid_chr(+)
                          and a.balanceemp_chr is not null
                          and a.returnemp_chr is not null     
                          and a.balance_dat >= ?
                          and a.balance_dat <= ?
                        order by invno_chr asc";

                    objHRPSvc.CreateDatabaseParameter(4, out objParamerArr);

                    objParamerArr[0].DbType = DbType.Date;
                    objParamerArr[0].Value = Convert.ToDateTime(p_strStartDate);
                    objParamerArr[1].DbType = DbType.Date;
                    objParamerArr[1].Value = Convert.ToDateTime(p_strEndDate);
                    objParamerArr[2].DbType = DbType.Date;
                    objParamerArr[2].Value = Convert.ToDateTime(p_strStartDate);
                    objParamerArr[3].DbType = DbType.Date;
                    objParamerArr[3].Value = Convert.ToDateTime(p_strEndDate);
                }


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamerArr);
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


        #region 根据操作员Id和日期查找门诊重打挂号发票信息
        /// <summary>
        /// 根据操作员Id和日期查找门诊重打挂号发票信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetRegisterBillReprintByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strOperatorId,
                                                 string p_strStartDate,
                                                 string p_strEndDate,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "GetRegisterBillReprintByDate");
            if (lngRes < 0)
            {
                return -1;
            }
            StringBuilder strSQL = new StringBuilder(@"
                            select a.sourceinvono_vchr,
                                   a.repprninvono_vchr,
                                   a.printemp_chr
                            from t_opr_invoicerepeatprint a,t_opr_patientregister b
                            where a.sourceinvono_vchr = b.invno_chr
                              and a.type_chr = 2
                              and a.printstatus_int = 0
                              and b.balanceemp_chr is not null
                              and b.returnemp_chr is null      
                              and b.balance_dat >= ?
                              and b.balance_dat <= ?");

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objParamerArr = null;
            IDataParameter[] tmp_objParamerArr = null;
            objHRPSvc.CreateDatabaseParameter(3, out tmp_objParamerArr);
            int m_intParamCount = 2;
            tmp_objParamerArr[0].DbType = DbType.Date;
            tmp_objParamerArr[0].Value = Convert.ToDateTime(p_strStartDate);
            tmp_objParamerArr[1].DbType = DbType.Date;
            tmp_objParamerArr[1].Value = Convert.ToDateTime(p_strEndDate);

            try
            {
                if (p_strOperatorId.Trim().Length > 0)
                {
                    strSQL.Append(@" and a.printemp_chr = ?");
                    ++m_intParamCount;
                    tmp_objParamerArr[m_intParamCount - 1].Value = p_strOperatorId;
                }

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamerArr);
                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objParamerArr[i1].Value = tmp_objParamerArr[i1].Value;
                    objParamerArr[i1].DbType = tmp_objParamerArr[i1].DbType;
                }


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtResult, objParamerArr);
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
        #endregion //根据操作员Id和日期查找门诊重打发票信息


        #endregion //收费处挂号发票月统计报表(新)
        /// <summary>
        /// 通过发票段统计发票数据
        /// by huafeng.xiao
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisterStatDataByInvoArr(
            System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strOperatorId,
            string p_strStartDate,
            string p_strEndDate,
            out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetRegisterStatDataByInvoArr");
            if (lngRes < 0)//没有使用权限
            {
                return -1;
            }

            String strSQL = string.Empty;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objParamerArr = null;

            try
            {
                if (p_strOperatorId.Trim().Length > 0)
                {
                    strSQL = @"
                        select a.registerid_chr,
                               a.invno_chr,
                               a.flag_int,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as cpayment_mny,

                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                               a.registeremp_chr as empid_chr,
                               b.lastname_vchr
                        from t_opr_patientregister    a,
                             t_bse_employee           b
                        where a.registeremp_chr = b.empid_chr(+)
                          and a.balanceemp_chr is not null
                          and a.returnemp_chr is null 
                          and a.registeremp_chr = ?    
                          and a.invno_chr between ? and ?

                     union all

                        select a.registerid_chr,
                               a.invno_chr,
                               a.flag_int,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as cpayment_mny,

                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                               a.returnemp_chr as empid_chr,
                               b.lastname_vchr
                        from t_opr_patientregister    a,
                             t_bse_employee           b
                        where a.returnemp_chr = b.empid_chr(+)
                          and a.balanceemp_chr is not null
                          and a.returnemp_chr is not null    
                          and a.returnemp_chr = ?
                          and a.invno_chr between ? and ?
                    order by invno_chr asc";

                    objHRPSvc.CreateDatabaseParameter(6, out objParamerArr);

                    objParamerArr[0].Value = p_strOperatorId;
                    objParamerArr[1].DbType = DbType.String;
                    objParamerArr[1].Value = p_strStartDate;
                    objParamerArr[2].DbType = DbType.String;
                    objParamerArr[2].Value = p_strEndDate;

                    objParamerArr[3].Value = p_strOperatorId;
                    objParamerArr[4].DbType = DbType.String;
                    objParamerArr[4].Value = p_strStartDate;
                    objParamerArr[5].DbType = DbType.String;
                    objParamerArr[5].Value = p_strEndDate;


                }
                else
                {
                    strSQL = @"
                        select a.registerid_chr,
                               a.invno_chr,
                               a.flag_int,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gpayment_mny,
                               (select payment_mny 
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as cpayment_mny,

                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '001') as rcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '002') as dcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '003') as gcharge,
                               (select payment_mny * discount_dec
                                from t_opr_patientregdetail d
                                where d.registerid_chr = a.registerid_chr
                                  and d.chargeid_chr = '004') as ccharge,
                               a.registeremp_chr as empid_chr,
                               b.lastname_vchr
                       from t_opr_patientregister    a,
                            t_bse_employee           b
                       where a.registeremp_chr = b.empid_chr(+)
                         and a.balanceemp_chr is not null
                         and a.returnemp_chr is null     
                         and a.invno_chr between ? and ?

                     union all

                      select a.registerid_chr,
                             a.invno_chr,
                             a.flag_int,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '001') as rpayment_mny,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '002') as dpayment_mny,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '003') as gpayment_mny,
                             (select payment_mny 
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '004') as cpayment_mny,

                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '001') as rcharge,
                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '002') as dcharge,
                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '003') as gcharge,
                             (select payment_mny * discount_dec
                              from t_opr_patientregdetail d
                              where d.registerid_chr = a.registerid_chr
                                and d.chargeid_chr = '004') as ccharge,
                             a.returnemp_chr as empid_chr,
                             b.lastname_vchr
                        from t_opr_patientregister    a,
                             t_bse_employee           b
                        where a.returnemp_chr = b.empid_chr(+)
                          and a.balanceemp_chr is not null
                          and a.returnemp_chr is not null     
                          and a.invno_chr between ? and ?
                        order by invno_chr asc";

                    objHRPSvc.CreateDatabaseParameter(4, out objParamerArr);

                    objParamerArr[0].DbType = DbType.String;
                    objParamerArr[0].Value = p_strStartDate;
                    objParamerArr[1].DbType = DbType.String;
                    objParamerArr[1].Value = p_strEndDate;
                    objParamerArr[2].DbType = DbType.String;
                    objParamerArr[2].Value = p_strStartDate;
                    objParamerArr[3].DbType = DbType.String;
                    objParamerArr[3].Value = p_strEndDate;
                }


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamerArr);
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
        /// 根据操作员Id和发票段查找门诊重打挂号发票信息
        /// by huafeng.xiao
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetRegisterBillReprintByInvoArr(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strOperatorId,
                                                 string p_strStartDate,
                                                 string p_strEndDate,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "GetRegisterBillReprintByInvoArr");
            if (lngRes < 0)
            {
                return -1;
            }
            StringBuilder strSQL = new StringBuilder(@"
                            select a.sourceinvono_vchr,
                                   a.repprninvono_vchr,
                                   a.printemp_chr
                            from t_opr_invoicerepeatprint a,t_opr_patientregister b
                            where a.sourceinvono_vchr = b.invno_chr
                              and a.type_chr = 2
                              and a.printstatus_int = 0
                              and b.balanceemp_chr is not null
                              and b.returnemp_chr is null      
                              and b.invno_chr between ? and ?");

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objParamerArr = null;
            IDataParameter[] tmp_objParamerArr = null;
            objHRPSvc.CreateDatabaseParameter(3, out tmp_objParamerArr);
            int m_intParamCount = 2;
            tmp_objParamerArr[0].DbType = DbType.String;
            tmp_objParamerArr[0].Value = p_strStartDate;
            tmp_objParamerArr[1].DbType = DbType.String;
            tmp_objParamerArr[1].Value = p_strEndDate;

            try
            {
                if (p_strOperatorId.Trim().Length > 0)
                {
                    strSQL.Append(@" and a.printemp_chr = ?");
                    ++m_intParamCount;
                    tmp_objParamerArr[m_intParamCount - 1].Value = p_strOperatorId;
                }

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamerArr);
                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objParamerArr[i1].Value = tmp_objParamerArr[i1].Value;
                    objParamerArr[i1].DbType = tmp_objParamerArr[i1].DbType;
                }


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtResult, objParamerArr);
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
        /// 获取科室信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_dtDept, string strINTERNALFLAG)
        {
            m_dtDept = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetDeptInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL=string.Empty;
            if (strINTERNALFLAG == "-1")
            {
                strSQL = @"SELECT DISTINCT (b.deptid_chr), b.deptname_vchr
           FROM t_opr_outpatientrecipeinv a,
                t_bse_deptdesc b,
                t_bse_deptemp c,
                t_bse_employee d
          WHERE a.balanceemp_chr = d.empid_chr
            AND b.deptid_chr = c.deptid_chr
            AND c.empid_chr = d.empid_chr
       ORDER BY b.deptname_vchr";
            }
            else
            {
                strSQL = @"SELECT DISTINCT (b.deptid_chr), b.deptname_vchr
           FROM t_opr_outpatientrecipeinv a,
                t_bse_deptdesc b,
                t_bse_deptemp c,
                t_bse_employee d
          WHERE a.balanceemp_chr = d.empid_chr
            AND b.deptid_chr = c.deptid_chr
            AND c.empid_chr = d.empid_chr and a.INTERNALFLAG_INT="+strINTERNALFLAG+@"
       ORDER BY b.deptname_vchr ";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref m_dtDept);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;

        }
        #region 获取挂号类型的状态
        /// <summary>
        /// 获取挂号类型的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strTypeID"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatTypeFLAG(System.Security.Principal.IPrincipal p_objPrincipal, string strTypeID, out int intType)
        {
            intType = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPatTypeFLAG");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select INTERNALFLAG_INT from t_bse_patientpaytype where PAYTYPEID_CHR='" + strTypeID + "'";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
                intType = int.Parse(dt.Rows[0][0].ToString());
            else
                intType = -1;
            return lngRes;

        }
        #endregion

        #region 检查发票号
        /// <summary>
        /// 检查发票号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strNO"></param>
        /// <param name="dt">返回占用该发票号的数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckNO(System.Security.Principal.IPrincipal p_objPrincipal, string strNO, out DataTable dt)
        {
            long lngRes = 0;
            dt = null;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckNO");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = @"select a.REGISTERID_CHR,
                                     a.REGISTERDATE_DAT,
                                     b.EMPNO_CHR 
                                from t_opr_patientregister a,
                                     t_bse_employee b 
                               where a.INVNO_CHR = '" + strNO.Trim() + @"' 
                                 and a.REGISTEREMP_CHR = b.EMPID_CHR 
                            union all
                              select '' as registerid_chr,
                                     c.printdate_dat as registerdate_dat,
                                     d.empno_chr 
                                from t_opr_invoicerepeatprint c, 
                                     t_bse_employee d
                               where c.type_chr = '2' 
                                 and c.repprninvono_vchr = '" + strNO.Trim() + @"' 
                                 and c.printemp_chr = d.empid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);

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

        #region 获取指定挂号员的发票信息(未结、已结)
        /// <summary>
        /// 获取指定挂号员的发票信息(未结、已结)
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="BalDate"></param>
        /// <param name="Flag">0 未结 1 已结</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRegisterInvoInfo(string EmpID, string BalDate, int Flag, out DataTable dt)
        {
            long lngRes = 0;

            dt = new DataTable();

            string SQL = "";

            if (Flag == 0)
            {
                SQL = @"select a.invno_chr as invono, a.flag_int as flag 
                          from t_opr_patientregister a
                         where (a.flag_int = 1 or a.flag_int = 2) 
                           and a.balance_dat is null 
                           and a.registeremp_chr = '" + EmpID + @"' 
                           and a.registerdate_dat <= to_date('" + BalDate + @"', 'yyyy-mm-dd hh24:mi:ss') 
 
                        union all 
                        
                        select a.invno_chr as invono, a.flag_int as flag 
                          from t_opr_patientregister a
                         where (a.flag_int = 3 or a.flag_int = 4) 
                           and a.balance_dat is null 
                           and a.returnemp_chr = '" + EmpID + @"' 
                           and a.returndate_dat <= to_date('" + BalDate + @"', 'yyyy-mm-dd hh24:mi:ss') 

                        union all 

                        select a.repprninvono_vchr, 9 as flag  
                          from t_opr_invoicerepeatprint a,
                               t_opr_patientregister b 
                         where a.seqid_chr = b.registerid_chr 
                           and a.type_chr = '2'  
                           and b.balance_dat is null 
                           and a.printemp_chr = '" + EmpID + @"' 
                           and b.registerdate_dat <= to_date('" + BalDate + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            else if (Flag == 1)
            {
                SQL = @"select a.invno_chr as invono, a.flag_int as flag 
                          from t_opr_patientregister a
                         where a.balanceemp_chr = '" + EmpID + @"' 
                           and a.balance_dat = to_date('" + BalDate + @"', 'yyyy-mm-dd hh24:mi:ss')                        

                        union all 

                        select a.repprninvono_vchr, 9 as flag  
                          from t_opr_invoicerepeatprint a,
                               t_opr_patientregister b 
                         where a.seqid_chr = b.registerid_chr 
                           and a.type_chr = '2' 
                           and b.balance_dat is not null 
                           and a.printemp_chr = '" + EmpID + @"' 
                           and b.balance_dat = to_date('" + BalDate + "', 'yyyy-mm-dd hh24:mi:ss')";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region  挂号员挂号结帐报表
        /// <summary>
        ///  挂号员挂号结帐报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPlan"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckOutRegP(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtSource, string date, string strempno, out DataTable dtSourceDetail, out string regNo)
        {
            long lngRes = 0;
            dtSource = new DataTable();
            dtSourceDetail = new DataTable();
            regNo = "";
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngDoUpdWeekPlanByID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            //			string strSQL = @"select * from V_CHECKOUTREGREPORD order by paytypeid_chr" ;select * from (
            string strSQL = @"select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + strempno + @"'  and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as regcount,
'现' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and  
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + strempno + @"' and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + strempno + @"' and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + strempno + @"' and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + strempno + @"' and pstatus_int<>4 and FLAG_INT<>3
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.flag_int = 3 and b.RETURNEMP_CHR='" + strempno + @"' and pstatus_int<>4
 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + strempno + @"' and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + strempno + @"' and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + strempno + @"' and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + strempno + @"' and pstatus_int<>4
and b.flag_int = 3 and registerdate_dat <= to_date('" + date + @"','yyyy_MM_dd')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a";

            //union all
            //
            //select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
            //b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')) as regcount,
            //'支' as paytype,nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,
            //
            //(select count(*) from t_opr_patientregister b where
            // b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.flag_int = 3 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')) as rregcount,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney
            //
            //from t_bse_patientpaytype a
            //
            //union all
            //
            //select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
            //b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')) as regcount,
            //'记' as paytype,nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='"+strempno+@"' and pstatus_int<>4 and FLAG_INT<>3
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,
            //
            //(select count(*) from t_opr_patientregister b where
            // b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.flag_int = 3 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            // and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')) as rregcount,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,
            //
            //nvl((
            //select sum(c.payment_mny*c.discount_dec) as money from
            //t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
            //c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='"+strempno+@"' and pstatus_int<>4
            //and b.flag_int = 3 and registerdate_dat <= to_date('"+date+@"','yyyy_MM_dd')
            //group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney
            //
            //from t_bse_patientpaytype a) f order by f.paytypename_vchr";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtSource);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            regNo = "";
            try
            {
                strSQL = "select min(registerno_chr) as minRegNo,max(registerno_chr) as maxRegNo from t_opr_patientregister where registerdate_dat <= to_date(?,'yyyy_MM_dd')  and REGISTEREMP_CHR=? and pstatus_int<>4";


                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = date;
                paramArr[1].Value = strempno;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtSourceDetail, paramArr);

                if (dtSourceDetail.Rows.Count > 0)
                {
                    regNo = dtSourceDetail.Rows[0][0].ToString() + "-" + dtSourceDetail.Rows[0][1].ToString();
                    dtSourceDetail.Clear();
                }
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }

            try
            {
                strSQL = @"select a.registerno_chr,d.NAME_VCHR,b.paytypename_vchr,
      case  when a.paytype_int=0 then '现金'
      when a.paytype_int = 1 then '记帐'
      when a.paytype_int = 2 then '支票'
      else ''
      end as paytype_int,
      (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='001') as rcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='002') as dcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='003') as gcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='004') as ccharge,
        c.LASTNAME_VCHR,a.registerdate_dat
from t_opr_patientregister a,t_bse_patientpaytype b,T_BSE_EMPLOYEE c,T_BSE_PATIENTIDX d

where a.paytypeid_chr = b.paytypeid_chr
      and a.RETURNEMP_CHR = c.empid_chr(+)
      and a.patientid_chr = d.patientid_chr(+)
      and a.registerdate_dat <= to_date(?,'yyyy_MM_dd') and a.pstatus_int<>4
	  and a.flag_int = 3 and a.RETURNEMP_CHR=?";


                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = date;
                paramArr[1].Value = strempno;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtSourceDetail, paramArr);

            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 挂号结帐(新)
        /// <summary>
        /// 挂号结帐(新)
        /// </summary>
        /// <param name="OperID">收款员ID</param>
        /// <param name="CheckDate">结帐时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckOut(string OperID, out string CheckDate)
        {
            long lngRes = 0;
            string strSQl = "";
            CheckDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");        
            
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;

                strSQl = @"update t_opr_patientregister 
                              set balance_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss'), 
                                  balanceemp_chr = ?
                            where balance_dat is null 
                              and (registeremp_chr = ? or returnemp_chr = ?)";

                objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = CheckDate;
                paramArr[1].Value = OperID;
                paramArr[2].Value = OperID;
                paramArr[3].Value = OperID;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQl, ref lngRecordsAffected, paramArr);
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

        #region 挂号结帐(旧,停用)
        /// <summary>
        /// 挂号结帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="checkoutdate">结帐日期</param>
        /// <param name="checkoutempid">结账人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckOut(System.Security.Principal.IPrincipal p_objPrincipal, string checkoutdate, string checkoutempid, DataTable dtTolSource, DataTable dtRestoreDetail1)
        {
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckOut");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQl = "";
            if (dtTolSource.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtTolSource.Rows.Count; i1++)
                {
                    strSQl = @"update T_OPR_PATIENTREGISTER set BALANCE_DAT=To_Date(?,'yyyy-mm-dd hh24:mi:ss'),BALANCEEMP_CHR=? where REGISTERID_CHR=?";
                    try
                    {
                        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                        paramArr[0].Value = checkoutdate;
                        paramArr[1].Value = checkoutempid;
                        paramArr[2].Value = dtTolSource.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        long lngRecordsAffected = -1;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQl, ref lngRecordsAffected, paramArr);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }

                }
            }
            //			string strSQL="update T_OPR_PATIENTREGISTER  set PSTATUS_INT = 4,BALANCE_DAT=To_Date('"+checkoutdate+"','yyyy-mm-dd hh24:mi:ss')"+ "  where REGISTEREMP_CHR='"+checkoutempid+"'  and PSTATUS_INT<>4 and FLAG_INT<>3";

            //			strSQL="update T_OPR_PATIENTREGISTER  set PSTATUS_INT = 4,BALANCE_DAT=To_Date('"+checkoutdate+"','yyyy-mm-dd hh24:mi:ss')"+ "  where RETURNEMP_CHR='"+checkoutempid+"'  and PSTATUS_INT<>4 and FLAG_INT=3";

            if (dtRestoreDetail1.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtRestoreDetail1.Rows.Count; i1++)
                {
                    strSQl = @"update T_OPR_PATIENTREGISTER set BALANCE_DAT=To_Date(?,'yyyy-mm-dd hh24:mi:ss'),BALANCEEMP_CHR=? where REGISTERID_CHR=? ";
                    try
                    {
                        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                        paramArr[0].Value = checkoutdate;
                        paramArr[1].Value = checkoutempid;
                        paramArr[2].Value = dtRestoreDetail1.Rows[i1]["REGISTERID_CHR"].ToString().Trim();
                        long lngRecordsAffected = -1;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQl, ref lngRecordsAffected, paramArr);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }

                }
            }

            return lngRes;
        }
        #endregion

        #region 获取默认的打印状态
        /// <summary>
        /// 获取默认的打印状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID"></param>
        /// <param name="STATUSINT">0,默认打印，1,不打印” -2，没有设置默认值 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPrint(System.Security.Principal.IPrincipal p_objPrincipal, string strID, out int STATUSINT)
        {
            STATUSINT = -2;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngPrint");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select setstatus_int
  from t_sys_setting
 where setid_chr = ?";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            if (lngRes == 1 && dt.Rows.Count > 0)
                STATUSINT = int.Parse(dt.Rows[0][0].ToString());
            return lngRes;
        }
        #endregion

        #region  挂号员挂号结帐历史数据
        /// <summary>
        ///  挂号员挂号结帐历史数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPlan"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckOutH(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtSource, string CHECKOUTDATE, string CHECKOUTREGID, out DataTable dtSourceDetail)
        {
            long lngRes = 0;
            dtSource = new DataTable();
            dtSourceDetail = new DataTable();
            //	regNo = "";
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngDoUpdWeekPlanByID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            //			string strSQL = @"select * from V_CHECKOUTREGREPORD order by paytypeid_chr" ;
            string strSQL = @"select * from (select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"'  and pstatus_int=4 and FLAG_INT<>3
 and REGISTERID_CHR in(select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"') ) as regcount,
'现' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.flag_int = 3 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR  in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 0 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a

union all

select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')) as regcount,
'记' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.flag_int = 3 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 1 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a

union all

select a.paytypename_vchr,(select count(*) from t_opr_patientregister b where
b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and flag_int <>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')) as regcount,
'支' as paytype,nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as regmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as curemoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as materialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.REGISTEREMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 and FLAG_INT<>3
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and REGISTEREMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as cardmoney,

(select count(*) from t_opr_patientregister b where
 b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.flag_int = 3 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')) as rregcount,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '001' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4 
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rregmoney,
nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '002' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcuremoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '003' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rmaterialmoney,

nvl((
select sum(c.payment_mny*c.discount_dec) as money from
t_opr_patientregister b,t_opr_patientregdetail c where b.registerid_chr=c.registerid_chr and
c.chargeid_chr = '004' and b.paytypeid_chr = a.paytypeid_chr and b.paytype_int = 2 and b.RETURNEMP_CHR='" + CHECKOUTREGID + @"' and pstatus_int=4
and b.flag_int = 3 and b.REGISTERID_CHR in (select REGISTERID_CHR from t_opr_patientregister where BALANCE_DAT=To_Date('" + CHECKOUTDATE + "','yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR='" + CHECKOUTREGID + @"')
group by b.paytypeid_chr,b.paytypeid_chr),0) as rcardmoney

from t_bse_patientpaytype a) f order by f.paytypename_vchr";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtSource);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            try
            {
                strSQL = @"select a.registerno_chr,d.NAME_VCHR,b.paytypename_vchr,
      case  when a.paytype_int=0 then '现金'
      when a.paytype_int = 1 then '记帐'
      when a.paytype_int = 2 then '支票'
      else ''
      end as paytype_int,
      (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='001') as rcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='002') as dcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='003') as gcharge,
        (select PAYMENT_MNY*DISCOUNT_DEC from t_opr_patientregdetail d
        where d.registerid_chr = a.registerid_chr and d.chargeid_chr='004') as ccharge,
        c.LASTNAME_VCHR,a.registerdate_dat
from t_opr_patientregister a,t_bse_patientpaytype b,T_BSE_EMPLOYEE c,T_BSE_PATIENTIDX d

where a.paytypeid_chr = b.paytypeid_chr
      and a.RETURNEMP_CHR = c.empid_chr(+)
      and a.patientid_chr = d.patientid_chr(+)
      and registerno_chr in (select REGISTERNO_CHR from t_opr_patientregister where BALANCE_DAT=To_Date(?,'yyyy-mm-dd hh24:mi:ss') and RETURNEMP_CHR=? ) 
	  and a.flag_int = 3 and a.pstatus_int=4 and a.RETURNEMP_CHR=? ";

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = CHECKOUTDATE;
                paramArr[1].Value = CHECKOUTREGID;
                paramArr[2].Value = CHECKOUTREGID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtSourceDetail, paramArr);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 收费结算日报表
        /// <summary>
        /// 收费结算日报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="OPREMPID"></param>
        /// <param name="strDate"></param>
        /// <param name="dtPayType"></param>
        /// <param name="dtRecipesumde"></param>
        /// <param name="dtCheckOut"></param>
        /// <param name="dtRecipeinv"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutData(System.Security.Principal.IPrincipal p_objPrincipal, string OPREMPID, string strDate, out DataTable dtPayType, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            dtPayType = null;
            dtCheckOut = null;
            dtRecipeinv = null;
            dtRecipesumde = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
//            strSQL = @"SELECT   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.status_int,
//                     a.seqid_chr, a.balanceemp_chr, a.paytypeid_chr,
//                     b.tolfee_mny, b.itemcatid_chr, c.internalflag_int, a.acctsum_mny,
//                     a.sbsum_mny, a.totalsum_mny,a.paytype_int
//                FROM t_opr_outpatientrecipeinv a,
//                     t_opr_outpatientrecipesumde b,
//                     t_bse_patientpaytype c
//               WHERE a.invoiceno_vchr = b.invoiceno_vchr
//                 AND a.seqid_chr = b.seqid_chr
//                 AND a.balanceflag_int = 0
//                 AND a.paytypeid_chr = c.paytypeid_chr
//                 AND a.recorddate_dat <
//                                   TO_DATE (?, 'yyyy-mm-dd HH24:mi:ss')
//                 AND a.recordemp_chr =?    
//            ORDER BY a.invoiceno_vchr, a.seqid_chr";

            try
            {
                #region 统计核算分类信息
                strSQL = @"select a.chargeno_chr, b.itemcatid_chr, b.tolfee_mny
                             from t_opr_charge a, t_opr_outpatientrecipesumde b
                            where a.chargeno_chr = b.chargeno_chr
                              and a.recflag_int = 0
                              and a.operdate_dat < to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and a.operemp_chr = ?
                         order by a.chargeno_chr";

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = OPREMPID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipesumde, paramArr);
                #endregion

                #region 统计不同支付方式信息
                strSQL = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                  a.acctsum_mny, a.operemp_chr as opremp_chr,
                                  a.operdate_dat as recorddate_dat, a.status_int, b.internalflag_int,
                                  c.paytype_int
                             from t_opr_charge a,
                                  t_bse_patientpaytype b,
                                  t_opr_payment c                                  
                            where a.paytypeid_chr = b.paytypeid_chr(+)
                              and a.chargeno_chr = c.chargeno_vchr                              
                              and a.recflag_int = 0
                              and a.operdate_dat < to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and a.operemp_chr = ?
                         order by a.chargeno_chr";

                paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = OPREMPID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);
                #endregion

                #region 统计所有发票信息
                strSQL = @"select a.chargeno_chr, c.invoiceno_vchr, c.recorddate_dat, c.opremp_chr,
                                  c.status_int, c.seqid_chr, c.balanceemp_chr, c.paytypeid_chr,
                                  c.acctsum_mny, c.sbsum_mny, c.totalsum_mny, c.paytype_int
                             from t_opr_charge a, t_opr_chargedefinv b, t_opr_outpatientrecipeinv c
                            where a.chargeno_chr = b.chargeno_chr
                              and b.invoiceno_vchr = c.invoiceno_vchr
                              and c.balanceflag_int = 0
                              and c.recorddate_dat < to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and c.recordemp_chr = ?
                         order by c.invoiceno_vchr, c.seqid_chr";

                paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = OPREMPID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipeinv, paramArr);
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

        /// <summary>
        /// 收费结算日报表(未结账的发票信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strDate"></param>
        /// <param name="dtCheckOut"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckOutData(System.Security.Principal.IPrincipal p_objPrincipal, string OPREMPID, string strDate, string strRptId, out DataTable dtCheckOut, out DataTable dtDiffSum)
        {
            if (strRptId == null || strRptId == "")
            {
                throw new Exception("报表的Id号为空，请从功能菜单传入报表Id号。");
            }
            dtDiffSum = new DataTable();
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //string strSQL = @"Select * From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
            //try
            //{
            //    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            //}
            //catch (Exception objEx)
            //{
            //    string strTmp = objEx.Message;
            //    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
            //    bool blnRes = objLogger.LogError(objEx);
            //}
            string strSQL = @"SELECT a.invoiceno_vchr,
                                       a.recorddate_dat,
                                       a.opremp_chr,
                                       a.status_int,
                                       a.seqid_chr,
                                       a.balanceemp_chr,
                                       a.paytypeid_chr,
                                       a.acctsum_mny,
                                       a.sbsum_mny,
                                       a.totalsum_mny,a.totaldiffcost_mny,
                                       a.paytype_int,
                                       f.internalflag_int,
                                       b.itemcatid_chr,
                                       b.tolfee_mny,
                                       e.groupid_chr,
                                       e.groupname_chr, nvl(a.Totaldiffcost_Mny,0) diffPriceSum
                                  FROM t_opr_outpatientrecipeinv   a,
                                       t_opr_outpatientrecipesumde b,
                                       t_bse_patientpaytype f,
                                       (select c.typeid_chr, d.groupid_chr, d.groupname_chr from t_aid_rpt_gop_rla           c,
                                                     t_aid_rpt_gop_def           d
                                                     where  D.GROUPID_CHR = C.GROUPID_CHR 
                                                           AND D.RPTID_CHR = C.RPTID_CHR
                                                           AND d.rptid_chr = ?) e
                                 WHERE a.invoiceno_vchr = b.invoiceno_vchr
                                   AND a.seqid_chr = b.seqid_chr
                                   AND b.itemcatid_chr = e.TYPEID_CHR(+)
                                   AND A.PAYTYPEID_CHR = F.PAYTYPEID_CHR
                                   AND a.balanceflag_int = 0
                                   AND a.recorddate_dat < TO_DATE(?, 'yyyy-mm-dd HH24:mi:ss')
                                   AND a.recordemp_chr = ?
                                   and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                                 ORDER BY a.INVOICENO_VCHR,a.seqid_chr";

            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = strRptId;
                paramArr[1].Value = strDate;
                paramArr[2].Value = OPREMPID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);
                if (dtCheckOut != null && dtCheckOut.Rows.Count > 0)
                {
                    DataView dv = dtCheckOut.DefaultView;
                    dtDiffSum = dv.ToTable(true, new string[] { "invoiceno_vchr", "diffPriceSum" });
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
        /// 根据指定的条件查询已日结报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="intMode">1按结算时间，0按发票时间</param>
        /// <param name="OPREMPID">收费员ID</param>
        /// <param name="strStartDate">开始时间</param>
        /// <param name="strEndDate">结束时间</param>
        /// <param name="strRptId">报表字段分类</param>
        /// <param name="dtCheckOut"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckOutData(System.Security.Principal.IPrincipal p_objPrincipal,int intMode, string OPREMPID, string strStartDate,string strEndDate, string strRptId, out DataTable dtCheckOut,out DataTable dtDiffSum)
        {
            if (strRptId == null || strRptId == "")
            {
                throw new Exception("报表的Id号为空，请从功能菜单传入报表Id号。");
            }
            dtDiffSum = new DataTable();
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT a.invoiceno_vchr,
                                       a.recorddate_dat,
                                       a.opremp_chr,
                                       a.status_int,
                                       a.seqid_chr,
                                       a.balanceemp_chr,
                                       a.paytypeid_chr,
                                       a.acctsum_mny,
                                       a.sbsum_mny,
                                       a.totalsum_mny,
                                       a.paytype_int,
                                       f.internalflag_int,
                                       b.itemcatid_chr,
                                       b.tolfee_mny,
                                       e.groupid_chr,
                                       e.groupname_chr
                                  FROM t_opr_outpatientrecipeinv   a,
                                       t_opr_outpatientrecipesumde b,
                                       t_bse_patientpaytype f,
                                       (select c.typeid_chr, d.groupid_chr, d.groupname_chr from t_aid_rpt_gop_rla           c,
                                                     t_aid_rpt_gop_def           d
                                                     where  D.GROUPID_CHR = C.GROUPID_CHR 
                                                           AND D.RPTID_CHR = C.RPTID_CHR
                                                           AND d.rptid_chr = ?) e
                                 WHERE a.invoiceno_vchr = b.invoiceno_vchr
                                   AND a.seqid_chr = b.seqid_chr
                                   AND b.itemcatid_chr = e.TYPEID_CHR(+)
                                   AND A.PAYTYPEID_CHR = F.PAYTYPEID_CHR
                                   AND a.{date} between TO_DATE(?, 'yyyy-mm-dd HH24:mi:ss') and TO_DATE(?, 'yyyy-mm-dd HH24:mi:ss')
                                   {emp}
                                   and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                                 ORDER BY a.INVOICENO_VCHR,a.seqid_chr";

            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter((OPREMPID=="1000"?3:4), out paramArr);
                paramArr[0].Value = strRptId;
                paramArr[1].Value = strStartDate;
                paramArr[2].Value = strEndDate;
                if (OPREMPID != "1000")
                {
                    paramArr[3].Value = OPREMPID;
                    strSQL = strSQL.Replace("{emp}", "AND a.OPREMP_CHR='" + OPREMPID + "'");
                }
                else
                {
                    strSQL = strSQL.Replace("{emp}", "");
                }
                if (intMode == 0)
                {
                    strSQL = strSQL.Replace("{date}", "recorddate_dat");
                }
                else
                {
                    strSQL = strSQL.Replace("{date}", "balance_dat");
                }
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);

                strSQL = @"select sum( a.tolfee_mny) diffPriceSum
  from t_opr_outpatientrecipeinvde a, t_bse_chargeitemextype b
 where a.invoiceno_vchr in([strTemp])
   and a.itemcatid_chr = b.typeid_chr
   and b.typeid_chr = '0022'
   and b.flag_int = 2";
                if (dtCheckOut.Rows.Count > 0)
                {
                    string strTemp = string.Empty;
                    string[] arr = new string[dtCheckOut.Rows.Count];
                    for (int i = 0; i < dtCheckOut.Rows.Count; i++)
                    {
                        arr[i] = dtCheckOut.Rows[i]["invoiceno_vchr"].ToString();
                    }
                    strTemp = "'" + string.Join("','", arr) + "'";
                    strSQL = strSQL.Replace("[strTemp]", strTemp);
                    objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtDiffSum); 
                }
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

        #region 获取所有的员工信息
        /// <summary>
        /// 获取所有的员工信息
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllEmployee(out DataTable p_dtResult)
        {
            p_dtResult = null;
            string strSQL = null;
            long lngRes = 0;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select empid_chr, empno_chr, pycode_chr, lastname_vchr as doctorname
                              from t_bse_employee
                             where status_int = 1
                             order by empno_chr";
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);

            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, false);
            }
            finally
            {
                strSQL = null;
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取未日结人员
        /// <summary>
        /// 获取未日结人员
        /// </summary>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbNoBalanceList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeNoBalanceEmpList(string p_strEndDate, out DataTable p_dtbNoBalanceList)
        {
            long lngRes = 0;
            p_dtbNoBalanceList = null;

            string SQL = "";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objDPArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();

                SQL = @"select distinct tt.operemp_chr, tt.operdate_dat
  from (select t.operemp_chr, trunc(t.operdate_dat) as operdate_dat
          from t_opr_bih_charge t
         where t.recflag_int = 0
           and t.recdate_dat is null
           and t.operdate_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')
        union all
        select t.creatorid_chr as operemp_chr,
               trunc(t.create_dat) as operdate_dat
          from t_opr_bih_prepay t
         where t.balanceflag_int = 0
           and t.create_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')
        
        union all
        select a.printemp_chr as operemp_chr,
               trunc(a.printdate_dat) as operdate_dat
          from t_opr_bih_billrepeatprint a
         where a.recdate_dat is null
           and a.printdate_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')) tt";
                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strEndDate;
                objDPArr[1].Value = p_strEndDate;
                objDPArr[2].Value = p_strEndDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref p_dtbNoBalanceList, objDPArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc = null;
            }

            return lngRes;
        }
        #endregion

         /// <summary>
         /// 根据传入条件获取已结帐数据信息
         /// </summary>
         /// <param name="p_objPrincipal"></param>
         /// <param name="m_intStatDateType"></param>
         /// <param name="m_strCheckManID"></param>
         /// <param name="m_strBalanceDeptID"></param>
         /// <param name="m_strBeginTime"></param>
         /// <param name="m_strEndTime"></param>
         /// <param name="strRptId"></param>
         /// <param name="fysfcdeptidARR"></param>
         /// <param name="m_dtCheckOutData"></param>
         /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckedOutDataByCondition(System.Security.Principal.IPrincipal p_objPrincipal,int m_intStatDateType, string m_strCheckManID,string m_strBalanceDeptID, string m_strBeginTime,string m_strEndTime, string strRptId,ArrayList fysfcdeptidARR, out DataTable m_dtCheckOutData,out DataTable dtTemp)
        {

            m_dtCheckOutData = null;
            dtTemp = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCheckedOutDataByCondition");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.status_int,
         a.seqid_chr, a.balanceemp_chr, a.paytypeid_chr, a.acctsum_mny,
         a.sbsum_mny, a.totalsum_mny, a.paytype_int, f.internalflag_int,
         b.itemcatid_chr, b.tolfee_mny, e.groupid_chr, e.groupname_chr,a.totaldiffcost_mny
    from t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype f,
         (select c.typeid_chr, d.groupid_chr, d.groupname_chr
            from t_aid_rpt_gop_rla c, t_aid_rpt_gop_def d
           where d.groupid_chr = c.groupid_chr
             and d.rptid_chr = c.rptid_chr
             and d.rptid_chr = ?) e
   where a.invoiceno_vchr = b.invoiceno_vchr
     and a.seqid_chr = b.seqid_chr
     and b.itemcatid_chr = e.typeid_chr(+)
     and a.paytypeid_chr = f.paytypeid_chr
     and ( a.isvouchers_int < 2 or a.isvouchers_int is null)
     and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                           and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
order by a.invoiceno_vchr, a.seqid_chr";

            string SubStr = "";
            if (fysfcdeptidARR != null && fysfcdeptidARR.Count > 0)
            {
                string str = "";
                for (int i = 0; i < fysfcdeptidARR.Count; i++)
                {
                    str += " '" + fysfcdeptidARR[i].ToString() + "',";
                }
                str = str.Trim();

                SubStr = "and a.chargedeptid_chr not in (" + str.Substring(0, str.Length - 1) + ")";
            }

            if (m_strCheckManID.Trim() == "1000"&& m_strBalanceDeptID.Trim()=="1000")
            {
                if (m_intStatDateType == 0)
                {
                    strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
                }
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                    paramArr[0].Value = strRptId;
                    paramArr[1].Value = m_strBeginTime;
                    paramArr[2].Value = m_strEndTime;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtCheckOutData, paramArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else if(m_strCheckManID.Trim() == "1000"&& m_strBalanceDeptID.Trim()!="1000")
            {
                strSQL = @"select a.invoiceno_vchr,
       a.recorddate_dat,
       a.opremp_chr,
       a.status_int,
       a.seqid_chr,
       a.balanceemp_chr,
       a.paytypeid_chr,
       a.acctsum_mny,
       a.sbsum_mny,
       a.totalsum_mny,
       a.paytype_int,
       f.internalflag_int,
       b.itemcatid_chr,
       b.tolfee_mny,
       e.groupid_chr,
       e.groupname_chr,a.totaldiffcost_mny
  from t_opr_outpatientrecipeinv a,
       t_opr_outpatientrecipesumde b,
       t_bse_patientpaytype f,
       (select c.typeid_chr, d.groupid_chr, d.groupname_chr
          from t_aid_rpt_gop_rla c, t_aid_rpt_gop_def d
         where d.groupid_chr = c.groupid_chr
           and d.rptid_chr = c.rptid_chr
           and d.rptid_chr = ?) e
 where a.invoiceno_vchr = b.invoiceno_vchr
   and a.seqid_chr = b.seqid_chr
   and b.itemcatid_chr = e.typeid_chr(+)
   and a.paytypeid_chr = f.paytypeid_chr
   and a.chargedeptid_chr=?
   and ( a.isvouchers_int < 2 or a.isvouchers_int is null)
   and a.balance_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
 order by a.invoiceno_vchr, a.seqid_chr
";
                if (m_intStatDateType == 0)
                {
                    strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
                }
                try
                {
                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                    paramArr[0].Value = strRptId;
                    paramArr[1].Value = m_strBalanceDeptID;
                    paramArr[2].Value = m_strBeginTime;
                    paramArr[3].Value = m_strEndTime;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtCheckOutData, paramArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else if (m_strCheckManID.Trim() != "1000" && m_strBalanceDeptID.Trim() == "1000")
            {

                if (m_strCheckManID.Trim() == "2000")
                {
                    strSQL = @"select   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.status_int,
         a.seqid_chr, a.balanceemp_chr, a.paytypeid_chr, a.acctsum_mny,
         a.sbsum_mny, a.totalsum_mny, a.paytype_int, f.internalflag_int,
         b.itemcatid_chr, b.tolfee_mny, e.groupid_chr, e.groupname_chr,a.totaldiffcost_mny
    from t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype f,
         (select c.typeid_chr, d.groupid_chr, d.groupname_chr
            from t_aid_rpt_gop_rla c, t_aid_rpt_gop_def d
           where d.groupid_chr = c.groupid_chr
             and d.rptid_chr = c.rptid_chr
             and d.rptid_chr = ?) e
   where a.invoiceno_vchr = b.invoiceno_vchr
     and a.seqid_chr = b.seqid_chr
     and b.itemcatid_chr = e.typeid_chr(+)
     and a.paytypeid_chr = f.paytypeid_chr
     [condition]
     and (a.isvouchers_int < 2 or a.isvouchers_int is null)
     and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                           and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
order by a.invoiceno_vchr, a.seqid_chr";
                    if (m_intStatDateType == 0)
                    {
                        strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
                    }

                    strSQL = strSQL.Replace("[condition]", SubStr);

                    try
                    {
                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                        paramArr[0].Value = strRptId;
                        paramArr[1].Value = m_strBeginTime;
                        paramArr[2].Value = m_strEndTime;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtCheckOutData, paramArr);

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
                     strSQL = @"select   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.status_int,
             a.seqid_chr, a.balanceemp_chr, a.paytypeid_chr, a.acctsum_mny,
             a.sbsum_mny, a.totalsum_mny, a.paytype_int, f.internalflag_int,
             b.itemcatid_chr, b.tolfee_mny, e.groupid_chr, e.groupname_chr,a.totaldiffcost_mny
        from t_opr_outpatientrecipeinv a,
             t_opr_outpatientrecipesumde b,
             t_bse_patientpaytype f,
             (select c.typeid_chr, d.groupid_chr, d.groupname_chr
                from t_aid_rpt_gop_rla c, t_aid_rpt_gop_def d
               where d.groupid_chr = c.groupid_chr
                 and d.rptid_chr = c.rptid_chr
                 and d.rptid_chr = ?) e
       where a.invoiceno_vchr = b.invoiceno_vchr
         and a.seqid_chr = b.seqid_chr
         and b.itemcatid_chr = e.typeid_chr(+)
         and a.paytypeid_chr = f.paytypeid_chr
         and a.balanceemp_chr=?
         and ( a.isvouchers_int < 2 or a.isvouchers_int is null)
         and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                               and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
    order by a.invoiceno_vchr, a.seqid_chr";
                    if (m_intStatDateType == 0)
                    {
                        strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
                    }
                    
                    try
                    {
                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                        paramArr[0].Value = strRptId;
                        paramArr[1].Value = m_strCheckManID;
                        paramArr[2].Value = m_strBeginTime;
                        paramArr[3].Value = m_strEndTime;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtCheckOutData, paramArr);

                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
                               
            }
            else
            {

                if (m_strCheckManID.Trim() == "2000")
                {
                    strSQL = @"select a.invoiceno_vchr,a.recorddate_dat,a.opremp_chr,a.status_int,
        a.seqid_chr,a.balanceemp_chr,a.paytypeid_chr,a.acctsum_mny, a.sbsum_mny,
         a.totalsum_mny,a.paytype_int, f.internalflag_int,
        b.itemcatid_chr, b.tolfee_mny, e.groupid_chr, e.groupname_chr,a.totaldiffcost_mny
          from t_opr_outpatientrecipeinv a,
               t_opr_outpatientrecipesumde b,
               t_bse_patientpaytype f,
               (select c.typeid_chr, d.groupid_chr, d.groupname_chr
                  from t_aid_rpt_gop_rla c, t_aid_rpt_gop_def d
                 where d.groupid_chr = c.groupid_chr
                   and d.rptid_chr = c.rptid_chr
                   and d.rptid_chr = ?) e
         where a.invoiceno_vchr = b.invoiceno_vchr
           and a.seqid_chr = b.seqid_chr
           and b.itemcatid_chr = e.typeid_chr(+)
           and a.paytypeid_chr = f.paytypeid_chr
           and a.chargedeptid_chr=?
           [condition]
           and ( a.isvouchers_int < 2 or a.isvouchers_int is null)
           and a.balance_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss')
         order by a.invoiceno_vchr, a.seqid_chr";

                        if (m_intStatDateType == 0)
                        {
                            strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
                        }


                    strSQL = strSQL.Replace("[condition]", SubStr);

                    try
                    {
                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                        paramArr[0].Value = strRptId;
                        paramArr[1].Value = m_strBalanceDeptID;
                        paramArr[2].Value = m_strBeginTime;
                        paramArr[3].Value = m_strEndTime;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtCheckOutData, paramArr);

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
                     strSQL = @"select a.invoiceno_vchr,a.recorddate_dat,a.opremp_chr,a.status_int,
        a.seqid_chr,a.balanceemp_chr,a.paytypeid_chr,a.acctsum_mny, a.sbsum_mny,
         a.totalsum_mny,a.paytype_int, f.internalflag_int,
        b.itemcatid_chr, b.tolfee_mny, e.groupid_chr, e.groupname_chr,a.totaldiffcost_mny
          from t_opr_outpatientrecipeinv a,
               t_opr_outpatientrecipesumde b,
               t_bse_patientpaytype f,
               (select c.typeid_chr, d.groupid_chr, d.groupname_chr
                  from t_aid_rpt_gop_rla c, t_aid_rpt_gop_def d
                 where d.groupid_chr = c.groupid_chr
                   and d.rptid_chr = c.rptid_chr
                   and d.rptid_chr = ?) e
         where a.invoiceno_vchr = b.invoiceno_vchr
           and a.seqid_chr = b.seqid_chr
           and b.itemcatid_chr = e.typeid_chr(+)
           and a.paytypeid_chr = f.paytypeid_chr
           and a.balanceemp_chr = ?
           and a.chargedeptid_chr=?
           and ( a.isvouchers_int < 2 or a.isvouchers_int is null)
           and a.balance_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss')
         order by a.invoiceno_vchr, a.seqid_chr";
                        if (m_intStatDateType == 0)
                        {
                            strSQL = strSQL.Replace("balance_dat", "recorddate_dat");
                        }
                                           
                        try
                        {
                            System.Data.IDataParameter[] paramArr = null;
                            objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                            paramArr[0].Value = strRptId;
                            paramArr[1].Value = m_strCheckManID;
                            paramArr[2].Value = m_strBalanceDeptID;
                            paramArr[3].Value = m_strBeginTime;
                            paramArr[4].Value = m_strEndTime;
                            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtCheckOutData, paramArr);

                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                }
                

            }
            if (m_dtCheckOutData != null && m_dtCheckOutData.Rows.Count > 0)
            {
                DataView dv = m_dtCheckOutData.DefaultView;
                dtTemp = dv.ToTable(true, new string[] { "invoiceno_vchr", "totaldiffcost_mny" });
               // dtTemp = dtSource.DefaultView.ToTable(true, new string[] { "invoiceno_vchr", "totaldiffcost_mny" });
//                DataTable dtSSS = new DataTable();
//                DataSet ds = this.SplitDataTable(dtSourceTwo, 900);
//                foreach (DataTable dtTT in ds.Tables)
//                {
//                    string strSql = @"select sum( a.totaldiffcost_mny) diffPriceSum
//                                      from t_opr_outpatientrecipeinv a
//                                     where a.invoiceno_vchr in( [strTemp])";
//                    string strTemp = string.Empty;
//                    string[] arr = new string[dtTT.Rows.Count];
//                    for (int i = 0; i < dtTT.Rows.Count; i++)
//                    {
//                        arr[i] = dtTT.Rows[i]["invoiceno_vchr"].ToString();
//                    }
//                    dtSSS = new DataTable();
//                    strTemp = "'" + string.Join("','", arr) + "'";
//                    strSql = strSql.Replace("[strTemp]", strTemp);
//                    objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref dtSSS);
//                    if (dtSSS.Rows.Count > 0)
//                    {
//                        dtTemp.Merge(dtSSS);
//                    }
//                }
            }
            return lngRes;
        }

        #region 分解数据表
        /// <summary>
        /// 分解数据表
        /// </summary>
        /// <param name="originalTab">需要分解的表</param>
        /// <param name="rowsNum">每个表包含的数据量</param>
        /// <returns></returns>
        private DataSet SplitDataTable(DataTable originalTab, int rowsNum)
        {
            //获取所需创建的表数量
            int tableNum = originalTab.Rows.Count / rowsNum + 1;
            //获取数据余数
            int remainder = originalTab.Rows.Count % rowsNum;
            DataSet ds = new DataSet();
            //如果只需要创建1个表，直接将原始表存入DataSet
            if (tableNum == 0)
            {
                ds.Tables.Add(originalTab);
            }
            else
            {
                DataTable[] tableSlice = new DataTable[tableNum];
                //Save orginal columns into new table.            
                for (int c = 0; c < tableNum; c++)
                {
                    tableSlice[c] = new DataTable();
                    foreach (DataColumn dc in originalTab.Columns)
                    {
                        tableSlice[c].Columns.Add(dc.ColumnName, dc.DataType);
                    }
                }
                //Import Rows
                for (int i = 0; i < tableNum; i++)
                {
                    // if the current table is not the last one
                    if (i != tableNum - 1)
                    {
                        for (int j = i * rowsNum; j < ((i + 1) * rowsNum); j++)
                        {
                            tableSlice[i].ImportRow(originalTab.Rows[j]);
                        }
                    }
                    else
                    {
                        for (int k = i * rowsNum; k < originalTab.Rows.Count; k++)
                        {
                            tableSlice[i].ImportRow(originalTab.Rows[k]);
                        }
                    }
                }
                //add all tables into a dataset                
                foreach (DataTable dt in tableSlice)
                {
                    ds.Tables.Add(dt);
                }
            }
            return ds;
        }
        #endregion

        #region 结帐(旧,停用)
        [AutoComplete]
        public long m_lngCheckData(System.Security.Principal.IPrincipal p_objPrincipal, DataTable dt, string CheckName, string CheckDate)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            if (dt.Rows.Count > 0)
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    strSQL = @"update t_opr_outpatientrecipeinv set BALANCEEMP_CHR=?,BALANCE_DAT=to_date(?,'yyyy-mm-dd HH24:mi:ss'),BALANCEFLAG_INT=1 where INVOICENO_VCHR=? and SEQID_CHR=? and RECORDEMP_CHR=? ";
                    try
                    {

                        System.Data.IDataParameter[] paramArr = null;
                        objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                        paramArr[0].Value = CheckName;
                        paramArr[1].Value = CheckDate;
                        paramArr[2].Value = dt.Rows[i1]["INVOICENO_VCHR"].ToString();
                        paramArr[3].Value = dt.Rows[i1]["SEQID_CHR"].ToString();
                        paramArr[4].Value = CheckName;
                        long lngRecordsAffected = -1;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }

            }
            return lngRes;
        }
        #endregion

        #region 结帐(新)
        /// <summary>
        /// 结帐(新)
        /// </summary>
        /// <param name="OperID">收款员ID</param>
        /// <param name="CheckDate">日结时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckData(string OperID, out string CheckDate)
        {            
            long lngRes = 0;            
            string strSQL = "";

            CheckDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            strSQL = @"update t_opr_outpatientrecipeinv 
                          set balanceemp_chr = ?, 
                              balance_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss'), 
                              balanceflag_int = 1 
                        where balanceflag_int = 0
                          and recordemp_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = OperID;
                paramArr[1].Value = CheckDate;
                paramArr[2].Value = OperID;
                
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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
        /// 指定日期前结帐
        /// </summary>
        /// <param name="OperID">收款员ID</param>
        /// <param name="strIdentCheckDate">指定日期</param>
        /// <param name="CheckDate">日结时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckDataByDate(string OperID, string strIdentCheckDate, out string CheckDate)
        {
            long lngRes = 0;
            string strSQL = "";

            CheckDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            strSQL = @"update t_opr_outpatientrecipeinv 
                          set balanceemp_chr = ?, 
                              balance_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss'), 
                              balanceflag_int = 1 
                        where balanceflag_int = 0
                          and recordemp_chr = ?
                          and recorddate_dat < to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = OperID;
                paramArr[1].Value = CheckDate;
                paramArr[2].Value = OperID;
                paramArr[3].Value = strIdentCheckDate;

                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 历史查询
        [AutoComplete]
        public long m_lngGetHistor(System.Security.Principal.IPrincipal p_objPrincipal, string startDate, string endDate, string checkMan, out DataTable dt)
        {
            dt = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngCheckData");
            if (lngRes < 0) //没有使用的权限distinct
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            strSQL = @"select distinct BALANCE_DAT from t_opr_outpatientrecipeinv where BALANCE_DAT between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') and BALANCEEMP_CHR=? and BALANCEFLAG_INT=1 order by BALANCE_DAT";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = startDate + " 00:00:00";
                paramArr[1].Value = endDate + " 23:59:59";
                paramArr[2].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }

        #region 历史记录数据
        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutDatahistory(System.Security.Principal.IPrincipal p_objPrincipal, string strDate, string BALANCEEMP, out DataTable dtPayType, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            dtPayType = null;
            dtCheckOut = null;
            dtRecipesumde = null;
            dtRecipeinv = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

//            strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT,a.OPREMP_CHR, a.SEQID_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
//                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
//                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.BALANCEFLAG_INT=1 and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+) and a.BALANCE_DAT=To_Date('" + strDate + "','yyyy-mm-dd HH24:mi:ss') and BALANCEEMP_CHR='" + BALANCEEMP + "'  order by a.INVOICENO_VCHR,a.SEQID_CHR";
            try
            {
                #region 统计核算分类信息
                strSQL = @"select  a.chargeno_chr, b.itemcatid_chr, b.tolfee_mny
                            from t_opr_charge a, t_opr_outpatientrecipesumde b
                            where a.chargeno_chr = b.chargeno_chr
                              and a.recflag_int = 1
                              and a.recdate_dat = to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and a.recemp_chr = ?
                         order by a.chargeno_chr";

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = BALANCEEMP;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipesumde, paramArr);
                #endregion

                #region 统计不同支付方式信息
                strSQL = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                  a.acctsum_mny, a.operemp_chr as opremp_chr,
                                  a.operdate_dat as recorddate_dat, a.status_int, b.internalflag_int,
                                  c.paytype_int
                             from t_opr_charge a,
                                  t_bse_patientpaytype b,
                                  t_opr_payment c
                            where a.paytypeid_chr = b.paytypeid_chr(+)
                              and a.chargeno_chr = c.chargeno_vchr                              
                              and a.recflag_int = 1
                              and a.recdate_dat = to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and a.recemp_chr = ?
                         order by a.chargeno_chr";

                paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = BALANCEEMP;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);
                #endregion

                #region 统计所有发票信息
                strSQL = @"select a.chargeno_chr, c.invoiceno_vchr, c.recorddate_dat, c.opremp_chr,
                                  c.status_int, c.seqid_chr, c.balanceemp_chr, c.paytypeid_chr,
                                  c.acctsum_mny, c.sbsum_mny, c.totalsum_mny, c.paytype_int
                             from t_opr_charge a, t_opr_chargedefinv b, t_opr_outpatientrecipeinv c
                            where a.chargeno_chr = b.chargeno_chr
                              and b.invoiceno_vchr = c.invoiceno_vchr
                              and c.balanceflag_int = 1
                              and c.balance_dat = to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and c.balanceemp_chr = ?
                         order by c.invoiceno_vchr, c.seqid_chr";

                paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = BALANCEEMP;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipeinv, paramArr);
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

        #region 获取日结发票全部信息
        /// <summary>
        /// 获取日结发票全部信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strCheckDate"></param>
        /// <param name="strCheckManID"></param>
        /// <param name="dtbAllRecipeinv"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllRecipeinvInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strCheckDate, string strCheckManID, out DataTable dtbAllRecipeinv)
        {            
            dtbAllRecipeinv = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetAllRecipeinvInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select a.invoiceno_vchr, a.acctsum_mny, a.sbsum_mny, a.opremp_chr,
                                     a.recorddate_dat, a.status_int, a.seqid_chr, a.balanceemp_chr,
                                     a.totalsum_mny, a.paytypeid_chr, d.itemcatid_chr, d.tolfee_mny,
                                     e.paytype_int, f.internalflag_int
                                from t_opr_outpatientrecipeinv a,
                                     t_opr_chargedefinv b,
                                     t_opr_charge c,
                                     t_opr_outpatientrecipesumde d,
                                     t_opr_payment e,
                                     t_bse_patientpaytype f
                               where a.invoiceno_vchr = b.invoiceno_vchr
                                 and a.paytypeid_chr = f.paytypeid_chr(+)
                                 and a.balanceflag_int = 1
                                 and a.balance_dat = to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                                 and a.balanceemp_chr = ?
                                 and b.chargeno_chr = c.chargeno_chr
                                 and c.chargeno_chr = d.chargeno_chr
                                 and c.chargeno_chr = e.chargeno_vchr
                            order by a.invoiceno_vchr, a.seqid_chr";
            try
            {
                System.Data.IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strCheckDate;
                objParamArr[1].Value = strCheckManID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbAllRecipeinv, objParamArr);
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

        [AutoComplete]
        public long GetCheckOutHistory(System.Security.Principal.IPrincipal p_objPrincipal, string strDate, string BALANCEEMP, string strRptId, out DataTable dtCheckOut, out DataTable dtTemp)
        {
            if (strRptId == null || strRptId == "")
            {
                throw new Exception("报表的Id号为空，请从功能菜单传入报表Id号。");
            }
            dtTemp = new DataTable();
            //dtPayType = null;
            dtCheckOut = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "GetCheckOutHistory");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL;

            strSQL = @"SELECT a.invoiceno_vchr,
                           a.recorddate_dat,
                           a.opremp_chr,
                           a.status_int,
                           a.seqid_chr,
                           a.balanceemp_chr,
                           a.paytypeid_chr,
                           a.acctsum_mny,
                           a.sbsum_mny,
                           a.totalsum_mny,
                           a.paytype_int,
                           f.internalflag_int,
                           b.itemcatid_chr,
                           b.tolfee_mny,
                           e.groupid_chr,
                           e.groupname_chr, nvl(a.Totaldiffcost_Mny,0) diffPriceSum
                      FROM t_opr_outpatientrecipeinv   a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_patientpaytype f,
                           (select c.typeid_chr, d.groupid_chr, d.groupname_chr 
                                    from t_aid_rpt_gop_rla           c,
                                         t_aid_rpt_gop_def           d
                                 where  D.GROUPID_CHR = C.GROUPID_CHR 
                                       AND D.RPTID_CHR = C.RPTID_CHR
                                       AND d.rptid_chr = ?) e
                     WHERE a.invoiceno_vchr = b.invoiceno_vchr
                       AND a.seqid_chr = b.seqid_chr
                       AND b.itemcatid_chr = e.TYPEID_CHR(+)
                       AND A.PAYTYPEID_CHR = F.PAYTYPEID_CHR(+)
                       AND a.balanceflag_int = 1
                       and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                       AND a.balance_dat = TO_DATE(?, 'yyyy-mm-dd HH24:mi:ss')
                       AND a.balanceemp_chr = ?
                     order by a.INVOICENO_VCHR, a.SEQID_CHR";
            try
            {

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = strRptId;
                paramArr[1].Value = strDate;
                paramArr[2].Value = BALANCEEMP;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);
                com.digitalwave.Utility.clsLogText objLogg = new clsLogText();
                objLogg.LogError("1 " + strRptId + "2 " + strDate + " 3" + BALANCEEMP);
                if (dtCheckOut != null && dtCheckOut.Rows.Count > 0)
                {
                    DataView dv = dtCheckOut.DefaultView;
                    dtTemp = dv.ToTable(true, new string[] { "invoiceno_vchr", "diffPriceSum" });
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

        #endregion

        #region 获取收费员的当前未结帐的收费记录
        [AutoComplete]
        public long m_lngGetOneDayData(System.Security.Principal.IPrincipal p_objPrincipal, string OPREMPID, string strDate, out DataTable dtCheckOut)
        {
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限,b.TOLFEE_MNY,b.ITEMCATID_CHR  T_OPR_OUTPATIENTRECIPESUMDE b,a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select a.INVOICENO_VCHR, a.SEQID_CHR,a.RECORDDATE_DAT,a.OPREMP_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
                    where   a.BALANCEFLAG_INT=0 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.RECORDDATE_DAT<= To_Date('" + strDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') and OPREMP_CHR='" + OPREMPID + "'  order by a.INVOICENO_VCHR";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOut);
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

        #region 获得所有结帐员数据
        [AutoComplete]
        public long m_lngGetCheckMan(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtEmpAll, string strINTERNALFLAG)
        {
            dtEmpAll = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (strINTERNALFLAG == "-1")
            {
                strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1 and a.BALANCEEMP_CHR=b.EMPID_CHR ";
            }
            else
            {
                strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1  and a.BALANCEEMP_CHR=b.EMPID_CHR and a.INTERNALFLAG_INT=" + strINTERNALFLAG;
            }
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtEmpAll);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #region 获取收费员所在部门
        [AutoComplete]
        public long m_lngGetRegdept(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtdept, string strEmpId)
        {
            string strSQL = "";
            long lngRes=0;
            dtdept = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;

                strSQL = @"select c.deptid_chr, c.deptname_vchr  from t_bse_employee a, t_bse_deptemp b, t_bse_deptdesc c "
                  + " where a.empid_chr = b.empid_chr  and b.deptid_chr = c.deptid_chr  and a.empid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = strEmpId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtdept, paramArr);
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
        /// 获取所有收款员
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtEmp"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllCheckMan(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtEmp)        
        {
            dtEmp = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.Reports", "m_lngGetAllCheckMan");
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = 0;
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            strSQL = @"select distinct(b.empno_chr), b.lastname_vchr, a.balanceemp_chr
  from t_opr_outpatientrecipeinv a, t_bse_employee b
 where a.balanceemp_chr = b.empid_chr order by b.empno_chr";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtEmp);
                if (lngRes > 0 && dtEmp.Rows.Count > 0)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("工 号", typeof(System.String));
                    dtTemp.Columns.Add("姓      名", typeof(System.String));
                    dtTemp.Columns.Add("员工ID", typeof(System.String));
                    dtTemp.BeginLoadData();
                    for (int i1 = 0; i1 < dtEmp.Rows.Count; i1++)
                    {
                        dtTemp.LoadDataRow(dtEmp.Rows[i1].ItemArray, true);
                    }
                    dtTemp.EndLoadData();
                    dtTemp.AcceptChanges();
                    dtEmp = dtTemp;
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

        #region 收费日查询报表

        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutBetWeenDay(System.Security.Principal.IPrincipal p_objPrincipal, string strBeginDate, string strEndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtRecipesumde, out DataTable dtPayment, out DataTable dtEmp, string strINTERNALFLAG, string strCheckManName)
        {
            dtEmp = null;
            dtPayType = null;
            dtCheckOut = null;
            dtRecipesumde = null;
            dtPayment = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutBetWeenDay");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select   typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int,
                              govtopcharge_mny, emrcat_vchr
                              from t_bse_chargeitemextype
                              where flag_int = '1'
                              order by sortcode_int";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

//            strSQL = @"select a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.seqid_chr,
//                              a.status_int, a.balanceemp_chr, d.paytype_int, a.paytypeid_chr,
//                              b.tolfee_mny, b.itemcatid_chr, c.internalflag_int, a.acctsum_mny,
//                              a.sbsum_mny, a.totalsum_mny
//                         from t_opr_outpatientrecipeinv a,
//                              t_opr_outpatientrecipesumde b,
//                              t_bse_patientpaytype c,
//                              t_opr_payment d
//                        where a.invoiceno_vchr = b.invoiceno_vchr
//                          and a.seqid_chr = b.seqid_chr
//                          and a.balanceflag_int = 1
//                          and a.paytypeid_chr = c.paytypeid_chr(+)
//                          and d.chargeno_vchr = a.seqid_chr
//                          and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                                and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";

            string strSQL1, strSQL2, strSQL3;

            #region SQL
            //统计核算分类信息
            strSQL1 = @"select a.chargeno_chr, b.itemcatid_chr, b.tolfee_mny
                         from t_opr_charge a, t_opr_outpatientrecipesumde b
                        where a.chargeno_chr = b.chargeno_chr
                          and a.recflag_int = 1
                          and a.recdate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";


            //统计不同支付方式信息
            strSQL2 = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                  a.acctsum_mny, a.operemp_chr as opremp_chr, a.recemp_chr as balanceemp_chr,
                                  a.operdate_dat as recorddate_dat, a.status_int, b.internalflag_int,
                                  c.paytype_int
                             from t_opr_charge a,
                                  t_bse_patientpaytype b,
                                  t_opr_payment c                                  
                            where a.paytypeid_chr = b.paytypeid_chr(+)
                              and a.chargeno_chr = c.chargeno_vchr                              
                              and a.recflag_int = 1
                              and a.recdate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                     and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
           

            //统计所有发票信息
            strSQL3 = @"select a.chargeno_chr, c.invoiceno_vchr, c.recorddate_dat, c.opremp_chr,
                                  c.status_int, c.seqid_chr, c.balanceemp_chr, c.paytypeid_chr,
                                  c.acctsum_mny, c.sbsum_mny, c.totalsum_mny, c.paytype_int
                             from t_opr_charge a, t_opr_chargedefinv b, t_opr_outpatientrecipeinv c
                            where a.chargeno_chr = b.chargeno_chr
                              and b.invoiceno_vchr = c.invoiceno_vchr
                              and c.balanceflag_int = 1
                              and c.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                       and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";          
            #endregion

            IDataParameter[] objParamArr = null;

            string SqlWhere = "";
            //SqlWhere = @" and a.BALANCEEMP_CHR='" + strCheckManName + "'";
            SqlWhere = @" and a.recemp_chr = ? ";
            try
            {
                if (strINTERNALFLAG == "-1")
                {
                    //                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT,a.OPREMP_CHR, a.SEQID_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,d.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    //                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c,t_opr_payment d
                    //                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+)  AND d.chargeno_vchr = a.seqid_chr and a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') " + SqlWhere + " order by a.INVOICENO_VCHR,a.SEQID_CHR";                
                    if (strCheckManName != null)
                    {
                        strSQL1 += SqlWhere + " order by a.chargeno_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        objParamArr[2].Value = strCheckManName;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtRecipesumde, objParamArr);

                        strSQL2 += SqlWhere + " order by a.chargeno_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        objParamArr[2].Value = strCheckManName;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref dtPayment, objParamArr);

                        strSQL3 += SqlWhere + " order by c.invoiceno_vchr, c.seqid_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        objParamArr[2].Value = strCheckManName;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL3, ref dtCheckOut, objParamArr);
                    }
                    else
                    {
                        strSQL1 += " order by a.chargeno_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtRecipesumde, objParamArr);

                        strSQL2 += " order by a.chargeno_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref dtPayment, objParamArr);

                        strSQL3 += " order by c.invoiceno_vchr, c.seqid_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL3, ref dtCheckOut, objParamArr);
                    }
                }
                else
                {
                    //                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT,a.OPREMP_CHR, a.SEQID_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,d.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    //                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c,t_opr_payment d
                    //                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and  a.BALANCEFLAG_INT=1 AND d.chargeno_vchr = a.seqid_chr and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+) and a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') " + SqlWhere + " and a.INTERNALFLAG_INT=" + strINTERNALFLAG + " order by a.INVOICENO_VCHR,a.SEQID_CHR";
                    if (strCheckManName != null)
                    {
                        strSQL3 += SqlWhere + " and c.internalflag_int = ? order by c.invoiceno_vchr,a.seqid_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        objParamArr[2].Value = strCheckManName;
                        objParamArr[3].Value = strINTERNALFLAG;
                    }
                    else
                    {
                        strSQL3 += " and a.internalflag_int = ? order by a.invoiceno_vchr,a.seqid_chr";
                        objParamArr = null;
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = strBeginDate + " 00:00:00";
                        objParamArr[1].Value = strEndDate + " 23:59:59";
                        objParamArr[2].Value = strINTERNALFLAG;
                    }
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL3, ref dtCheckOut, objParamArr);
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (strCheckManName == null)
            {
                IDataParameter[] ParamArr = null;
                if (strINTERNALFLAG == "-1")
                {
                    //strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1 and a.BALANCEEMP_CHR=b.EMPID_CHR and a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') ";
                    strSQL = @"select distinct a.balanceemp_chr, b.lastname_vchr
                                 from t_opr_outpatientrecipeinv a, t_bse_employee b
                                where balanceflag_int = 1
                                  and a.balanceemp_chr = b.empid_chr
                                  and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = strBeginDate + " 00:00:00";
                    ParamArr[1].Value = strEndDate + " 23:59:59";
                }
                else
                {
                    //strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1 and a.BALANCEEMP_CHR=b.EMPID_CHR and a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')  and a.INTERNALFLAG_INT=" + strINTERNALFLAG;
                    strSQL = @"select distinct a.balanceemp_chr, b.lastname_vchr
                                 from t_opr_outpatientrecipeinv a, t_bse_employee b
                                where balanceflag_int = 1
                                  and a.balanceemp_chr = b.empid_chr
                                  and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and a.internalflag_int = ?";
                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = strBeginDate + " 00:00:00";
                    ParamArr[1].Value = strEndDate + " 23:59:59";
                    ParamArr[2].Value = strINTERNALFLAG;
                }
                try
                {

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtEmp, ParamArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }

            objHRPSvc.Dispose();
            return lngRes;
        }

        #endregion
        #region 收费科室日查询报表

        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutBetOfDept(System.Security.Principal.IPrincipal p_objPrincipal, string strBeginDate, string strEndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtEmp, string strINTERNALFLAG, string strDeptID)
        {
            dtEmp = null;
            dtPayType = null;
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutBetOfDept");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (strINTERNALFLAG == "-1")
            {
                strSQL = @"SELECT   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.seqid_chr,
         a.status_int, a.balanceemp_chr, d.paytype_int, a.paytypeid_chr,
         b.tolfee_mny, b.itemcatid_chr, c.internalflag_int, a.acctsum_mny,
         a.sbsum_mny, a.totalsum_mny
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c,
         t_opr_payment d,
         t_bse_deptdesc e,
         t_bse_employee f,
         t_bse_deptemp g
   WHERE a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.balanceflag_int = 1
     AND a.paytypeid_chr = c.paytypeid_chr(+)
     AND d.chargeno_vchr = a.seqid_chr
     AND a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + @" 23:59:59','yyyy-mm-dd hh24:mi:ss') 
     and a.balanceemp_chr=f.empid_chr
     and f.empid_chr=g.empid_chr
     and g.deptid_chr=e.deptid_chr
     and e.deptid_chr='" + strDeptID + @"'
ORDER BY a.invoiceno_vchr, a.seqid_chr";
            }
            else
            {
                strSQL = @"SELECT   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.seqid_chr,
         a.status_int, a.balanceemp_chr, d.paytype_int, a.paytypeid_chr,
         b.tolfee_mny, b.itemcatid_chr, c.internalflag_int, a.acctsum_mny,
         a.sbsum_mny, a.totalsum_mny
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c,
         t_opr_payment d,
         t_bse_deptdesc e,
         t_bse_employee f,
         t_bse_deptemp g
   WHERE a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.balanceflag_int = 1
     AND a.paytypeid_chr = c.paytypeid_chr(+)
     AND d.chargeno_vchr = a.seqid_chr
     AND a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + @" 23:59:59','yyyy-mm-dd hh24:mi:ss') 
     and a.INTERNALFLAG_INT=" + strINTERNALFLAG + @"
     and a.balanceemp_chr=f.empid_chr
     and f.empid_chr=g.empid_chr
     and g.deptid_chr=e.deptid_chr
     and e.deptid_chr='" + strDeptID + @"'
ORDER BY a.invoiceno_vchr, a.seqid_chr";
            }
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOut);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (strINTERNALFLAG == "-1")
            {
                strSQL = @"SELECT DISTINCT a.balanceemp_chr, b.lastname_vchr
           FROM t_opr_outpatientrecipeinv a,
                t_bse_employee b,
                t_bse_deptdesc c,
                t_bse_deptemp d
          WHERE balanceflag_int = 1
            AND a.balanceemp_chr = b.empid_chr
            AND c.deptid_chr = d.deptid_chr
            AND b.empid_chr = d.empid_chr
            AND c.deptid_chr = '" + strDeptID + @"'
            AND a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') ";
            }
            else
            {
                strSQL = @"SELECT DISTINCT a.balanceemp_chr, b.lastname_vchr
           FROM t_opr_outpatientrecipeinv a,
                t_bse_employee b,
                t_bse_deptdesc c,
                t_bse_deptemp d
          WHERE balanceflag_int = 1
            AND a.balanceemp_chr = b.empid_chr
            AND c.deptid_chr = d.deptid_chr
            AND b.empid_chr = d.empid_chr
            AND c.deptid_chr = '" + strDeptID + @"'
            AND a.BALANCE_DAT between to_date('" + strBeginDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + strEndDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') and a.INTERNALFLAG_INT=" + strINTERNALFLAG;
            }
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtEmp);
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
       
        #region 收费月查询报表

        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutBetWeenDate(System.Security.Principal.IPrincipal p_objPrincipal, string startDate, string EndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtEmp, string strINTERNALFLAG, string strCheckManName)
        {
            dtEmp = null;
            dtPayType = null;
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutBetWeenDate");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            string SqlWhere = "";
            if (strCheckManName != null)
            {
                SqlWhere = @" and a.BALANCEEMP_CHR='" + strCheckManName + "'";
            }
            if (strINTERNALFLAG == "-1")
            {
                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT, a.SEQID_CHR,a.OPREMP_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+) and a.BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') order by a.INVOICENO_VCHR,a.SEQID_CHR";
            }
            else
            {
                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT, a.SEQID_CHR,a.OPREMP_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+) and a.BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') and a.INTERNALFLAG_INT=" + strINTERNALFLAG + "  order by a.INVOICENO_VCHR,a.SEQID_CHR";
            }
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOut);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (strCheckManName == null)
            {
                if (strINTERNALFLAG == "-1")
                {
                    strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1 and BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') and a.BALANCEEMP_CHR=b.EMPID_CHR";
                }
                else
                {
                    strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1 and BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') and a.BALANCEEMP_CHR=b.EMPID_CHR and a.INTERNALFLAG_INT=" + strINTERNALFLAG;
                }
                try
                {

                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtEmp);
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

        #region 按病人类型统计报表

        #region 按病人类型统计报表
        /// <summary>
        /// 按病人类型统计报表
        /// </summary>
        /// <param name="p_objPrincipal">开始时间</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="dtPayType">返回收费类型</param>
        /// <param name="dtCheckOut">返回收费数据</param>
        /// <param name="dtCheckOutDe">返回收费明细数据表</param>
        /// <param name="dtEmp">返回收费员列表</param>
        /// <param name="isOne">传入收费员ID，ALL全部统计</param>
        /// <param name="isfull">指是否把慢病及红会的数据分开统计-1-统计慢病及红会数据(医保），0-单独统计慢病数据(医保），1-单独统计红会数据(医保）.2-统计慢病及红会数据（公费），3-单独统计慢病数据（公费），4-单独统计红会数据（公费）。5-统计慢病及红会数据（自费），6-单独统计慢病数据（自费），7-单独统计红会数据（自费）。8-统计慢病及红会数据（其它），9-单独统计慢病数据（其它），10-单独统计红会数据（其它）</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetIatrical(System.Security.Principal.IPrincipal p_objPrincipal, string startDate, string EndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtCheckOutDe, out DataTable dtEmp, string isOne, string isfull)
        {
            dtPayType = null;
            dtCheckOut = null;
            dtCheckOutDe = null;
            dtEmp = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetIatrical");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            string strcondition = " ";
            string strFLAG = "";
            if (isOne == "All")
            {
                switch (isfull)
                {
                    case "-1":
                        strcondition = @" ";
                        strFLAG = " and c.INTERNALFLAG_INT=2";
                        break;
                    case "0":
                        strcondition = @" and a.INTERNALFLAG_INT=1";
                        strFLAG = " and c.INTERNALFLAG_INT=2";
                        break;
                    case "1":
                        strcondition = @" and a.INTERNALFLAG_INT=0";
                        strFLAG = " and c.INTERNALFLAG_INT=2";
                        break;

                    case "2":
                        strcondition = @" ";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "3":
                        strcondition = @" and a.INTERNALFLAG_INT=1";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "4":
                        strcondition = @" and a.INTERNALFLAG_INT=0";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;

                    case "11":
                        strcondition = @" ";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "12":
                        strcondition = @" and a.INTERNALFLAG_INT=1";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "13":
                        strcondition = @" and a.INTERNALFLAG_INT=0";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;

                    case "5":
                        strcondition = @" ";
                        break;
                    case "6":
                        strcondition = @" and a.INTERNALFLAG_INT=1";
                        break;
                    case "7":
                        strcondition = @" and a.INTERNALFLAG_INT=0";
                        break;

                    case "8":
                        strcondition = @" ";
                        strFLAG = " and c.INTERNALFLAG_INT>2";
                        break;
                    case "9":
                        strcondition = @" and a.INTERNALFLAG_INT=1";
                        strFLAG = " and c.INTERNALFLAG_INT>2";
                        break;
                    case "10":
                        strcondition = @" and a.INTERNALFLAG_INT=0";
                        strFLAG = " and c.INTERNALFLAG_INT>2";
                        break;


                    case "14":
                        strcondition = @" ";
                        strFLAG = " and (a.PAYTYPE_INT=1 or c.INTERNALFLAG_INT=2)";
                        break;
                    case "15":
                        strcondition = @" and a.INTERNALFLAG_INT=1";
                        strFLAG = " and (a.PAYTYPE_INT=1 or c.INTERNALFLAG_INT=2)";
                        break;
                    case "16":
                        strcondition = @" and a.INTERNALFLAG_INT=0";
                        strFLAG = " and (a.PAYTYPE_INT=1 or c.INTERNALFLAG_INT=2)";
                        break;
                }
            }
            else
            {
                switch (isfull)
                {
                    case "-1":
                        strcondition = @" and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=2";
                        break;
                    case "0":
                        strcondition = @" and a.INTERNALFLAG_INT=1 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = "2";
                        break;
                    case "1":
                        strcondition = @" and a.INTERNALFLAG_INT=0 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=2";
                        break;

                    case "2":
                        strcondition = @" and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "3":
                        strcondition = @" and a.INTERNALFLAG_INT=1 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "4":
                        strcondition = @" and a.INTERNALFLAG_INT=0 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;

                    case "11":
                        strcondition = @" and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "12":
                        strcondition = @" and a.INTERNALFLAG_INT=1 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;
                    case "13":
                        strcondition = @" and a.INTERNALFLAG_INT=0 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT=1";
                        break;

                    case "5":
                        strcondition = @" and a.BALANCEEMP_CHR='" + isOne + "'";
                        break;
                    case "6":
                        strcondition = @" and a.INTERNALFLAG_INT=1 and a.BALANCEEMP_CHR='" + isOne + "'";
                        break;
                    case "7":
                        strcondition = @" and a.INTERNALFLAG_INT=0 and a.BALANCEEMP_CHR='" + isOne + "'";
                        break;

                    case "8":
                        strcondition = @" and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT>2";
                        break;
                    case "9":
                        strcondition = @" and a.INTERNALFLAG_INT=1 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT>2";
                        break;
                    case "10":
                        strcondition = @" and a.INTERNALFLAG_INT=0 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and c.INTERNALFLAG_INT>2";
                        break;


                    case "14":
                        strcondition = @" and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and (a.PAYTYPE_INT=1 or c.INTERNALFLAG_INT=2)";
                        break;
                    case "15":
                        strcondition = @" and a.INTERNALFLAG_INT=1 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and (a.PAYTYPE_INT=1 or c.INTERNALFLAG_INT=2)";
                        break;
                    case "16":
                        strcondition = @" and a.INTERNALFLAG_INT=0 and a.BALANCEEMP_CHR='" + isOne + "'";
                        strFLAG = " and (a.PAYTYPE_INT=1 or c.INTERNALFLAG_INT=2)";
                        break;
                }
            }
            if (isfull == "5" || isfull == "6" || isfull == "7")
            {
                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT, a.SEQID_CHR,a.OPREMP_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,c.INTERNALFLAG_INT,a.SBSUM_MNY,case when c.INTERNALFLAG_INT!=0 then a.SBSUM_MNY when c.INTERNALFLAG_INT=0 then a.TOTALSUM_MNY end as TOTALSUM_MNY,c.INTERNALFLAG_INT
                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')" + strcondition + " and c.INTERNALFLAG_INT!=1   order by a.INVOICENO_VCHR";
                try
                {

                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOut);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR as ITEMOPCALCTYPE_CHR,b.SBSUM_MNY as TOLPRICE_MNY ,b.TOLFEE_MNY,a.STATUS_INT as PSTAUTS_INT,c.INTERNALFLAG_INT
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')" + strcondition + " and c.INTERNALFLAG_INT!=1 order by a.INVOICENO_VCHR";
                try
                {

                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOutDe);
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
                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT, a.SEQID_CHR,a.OPREMP_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY,c.INTERNALFLAG_INT
                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')" + strFLAG + strcondition + "  order by a.INVOICENO_VCHR";
                try
                {

                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOut);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

                strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR as ITEMOPCALCTYPE_CHR,b.SBSUM_MNY as TOLPRICE_MNY,b.TOLFEE_MNY,a.STATUS_INT as PSTAUTS_INT,c.INTERNALFLAG_INT
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')" + strFLAG + strcondition + "   order by a.INVOICENO_VCHR";
                try
                {

                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOutDe);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }

            strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b,t_bse_patientpaytype c where BALANCEFLAG_INT=1 and BALANCE_DAT between To_Date('" + startDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + EndDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') and a.BALANCEEMP_CHR=b.EMPID_CHR and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR" + strFLAG + strcondition;
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtEmp);
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

        #region 返回所有有结帐的收费员名称
        [AutoComplete]
        public long m_lngReturnAllBALANCEEMP(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt)
        {
            dt = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngReturnAllBALANCEEMP");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b,t_bse_patientpaytype c where BALANCEFLAG_INT=1 and a.BALANCEEMP_CHR=b.EMPID_CHR and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=2 ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
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

        #region 公费统计表
        [AutoComplete]
        public long m_lngGetPublicMoney(System.Security.Principal.IPrincipal p_objPrincipal, string startDate, string endDate, out DataTable dt)
        {
            dt = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPublicMoney");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select  a.INVDATE_DAT,a.PAYTYPEID_CHR,a.PATIENTID_CHR,b.GOVCARD_CHR,d.INVOICENO_VCHR,c.PAYTYPENAME_VCHR,c.CHARGEPERCENT_DEC,d.ITEMCATID_CHR,d.TOLFEE_MNY  from T_OPR_OUTPATIENTRECIPEINV a,T_BSE_PATIENTPAYTYPE c,T_BSE_PATIENT b,T_OPR_OUTPATIENTRECIPEINVDE d  where  a.INVDATE_DAT between to_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') and to_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and c.INTERNALFLAG_INT=1 and a.PATIENTID_CHR=b.PATIENTID_CHR and a.INVOICENO_VCHR=d.INVOICENO_VCHR and a.SEQID_CHR=d.SEQID_CHR and b.GOVCARD_CHR is not null order by GOVCARD_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }

        #region 获取报表的配置信息

        [AutoComplete]
        public long m_lngGetGopRla(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt)
        {
            dt = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetGopRla");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select rptid_chr, groupid_chr, typeid_chr, flag_int
                                from t_aid_rpt_gop_rla
                               where flag_int = '2'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #endregion

        #region 收费员日结报表分开打印
        /// <summary>
        /// 收费员日结报表分开打印
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="CheckDate">结帐日期</param>
        /// <param name="checkMan">结帐人</param>
        /// <param name="dt1">现金日结报表</param>
        /// <param name="dtDe1">现金日结报表(明细)</param>
        /// <param name="dt2">医保及刷卡日结报表</param>
        ///  <param name="dtDe2">医保及刷卡日结报表(明细)</param>
        /// <param name="dt3">公费日结报表</param>
        /// <param name="dtDe3">公费日结报表(明细)</param>
        /// <param name="dt4">其它日结报表</param>
        /// <param name="dtDe4">其它日结报表(明细)</param>
        /// <param name="dtType">收费类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDataAllOfStat(System.Security.Principal.IPrincipal p_objPrincipal, string CheckDate, string checkMan, out DataTable dt1, out DataTable dtDe1, out DataTable dt2, out DataTable dtDe2, out DataTable dt3, out DataTable dtDe3, out DataTable dt4, out DataTable dtDe4, out DataTable dtType)
        {
            dt1 = null;
            dtDe1 = null;
            dt2 = null;
            dtDe2 = null;
            dt3 = null;
            dtDe3 = null;
            dt4 = null;
            dtDe4 = null;
            dtType = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetDataAllOfStat");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string OtherWhere = @"  and a.balance_dat=to_date(?,'yyyy-mm-dd hh24:mi:ss') and a.balanceemp_chr=?";
            string strSQL = @" select min (a.recorddate_dat) as minrecorddate_dat,
                                     max (a.recorddate_dat) as maxrecorddate_dat,
                                     sum (a.sbsum_mny) as totalmoney
                                    from t_opr_outpatientrecipeinv a,
                                         t_opr_chargedefinv b,
                                         t_opr_charge c,
                                         t_opr_payment d
                                   where a.invoiceno_vchr = b.invoiceno_vchr
                                     and b.chargeno_chr = c.chargeno_chr
                                     and c.chargeno_chr = d.chargeno_vchr
                                     and a.balanceflag_int = 1
                                     and d.paytype_int = 0" + OtherWhere;


            IDataParameter[] objParamArr = null;
            try
            {                
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt1, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select b.chargeno_chr as invoiceno_vchr, b.itemcatid_chr, b.tolfee_mny,
                              b.sbsum_mny, c.paytypeid_chr, d.paytype_int
                         from t_opr_charge a,
                              t_opr_outpatientrecipesumde b,
                              t_bse_patientpaytype c,
                              t_opr_payment d
                        where a.recflag_int = 1
                          and a.chargeno_chr = b.chargeno_chr
                          and a.paytypeid_chr = c.paytypeid_chr(+)
                          and b.chargeno_chr = d.chargeno_vchr
                          and d.paytype_int = 0
                          and a.recdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                          and a.recemp_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDe1,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
//            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
//       MAX (recorddate_dat) AS maxrecorddate_dat, sum(sbsum_mny1) as totalmoney from (SELECT a.recorddate_dat, '' AS acctsum_mny1, sbsum_mny AS sbsum_mny1,a.paytype_int
//  FROM t_opr_outpatientrecipeinv a
// WHERE a.balanceflag_int = 1 AND a.paytype_int = 1" + OtherWhere + "UNION ALL SELECT a.recorddate_dat, '' AS acctsum_mny1, a.acctsum_mny AS sbsum_mny1,a.paytype_int FROM t_opr_outpatientrecipeinv a, t_bse_patientpaytype c WHERE a.paytypeid_chr = c.paytypeid_chr AND c.internalflag_int = 2" + OtherWhere + ") ";
            strSQL = @"select min (recorddate_dat) as minrecorddate_dat,
                              max (recorddate_dat) as maxrecorddate_dat,
                              sum (sbsum_mny1) as totalmoney
                         from (select a.recorddate_dat, '' as acctsum_mny1,
                                      a.sbsum_mny as sbsum_mny1, d.paytype_int
                                 from t_opr_outpatientrecipeinv a,
                                      t_opr_chargedefinv b,
                                      t_opr_charge c,
                                      t_opr_payment d
                                where a.balanceflag_int = 1
                                  and a.invoiceno_vchr = b.invoiceno_vchr
                                  and b.chargeno_chr = c.chargeno_chr
                                  and c.chargeno_chr=d.chargeno_vchr
                                  and d.paytype_int = 1" + OtherWhere +
                            @" union all
                               select a.recorddate_dat, '' as acctsum_mny1,
                                      a.acctsum_mny as sbsum_mny1, e.paytype_int
                                 from t_opr_outpatientrecipeinv a,
                                      t_opr_chargedefinv b,
                                      t_opr_charge c,
                                      t_bse_patientpaytype d,
                                      t_opr_payment e
                                where a.invoiceno_vchr = b.invoiceno_vchr
                                  and b.chargeno_chr = c.chargeno_chr
                                  and c.chargeno_chr = e.chargeno_vchr
                                  and a.paytypeid_chr=d.paytypeid_chr(+)
                                  and d.internalflag_int = 2" + OtherWhere + ")";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                objParamArr[2].Value = CheckDate;
                objParamArr[3].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt2,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
//            strSQL = @"SELECT invoiceno_vchr, paytype_int, itemcatid_chr,
//       sbsum_mny1 AS sbsum_mny, tolfee_mny
//  FROM (SELECT a.invoiceno_vchr, a.paytype_int, b.itemcatid_chr,
//               b.sbsum_mny AS sbsum_mny1, b.tolfee_mny
//          FROM t_opr_outpatientrecipeinv a, t_opr_outpatientrecipesumde b
//         WHERE a.balanceflag_int = 1
//           AND a.paytype_int = 1
//           AND a.invoiceno_vchr = b.invoiceno_vchr
//           AND a.seqid_chr = b.seqid_chr" + OtherWhere + " UNION ALL  SELECT a.invoiceno_vchr, a.paytype_int, b.itemcatid_chr,(b.tolfee_mny - b.sbsum_mny) AS sbsum_mny1, b.tolfee_mny FROM t_opr_outpatientrecipeinv a,t_opr_outpatientrecipesumde b,t_bse_patientpaytype c WHERE a.balanceflag_int = 1  AND a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and  a.invoiceno_vchr = b.invoiceno_vchr AND a.seqid_chr = b.seqid_chr AND c.internalflag_int = 2" + OtherWhere + ")";

            strSQL = @"select invoiceno_vchr, paytype_int, itemcatid_chr, sbsum_mny1 as sbsum_mny,
                              tolfee_mny
                         from (select a.invoiceno_vchr, a.paytype_int, d.itemcatid_chr,
                                      d.sbsum_mny as sbsum_mny1, d.tolfee_mny
                                 from t_opr_outpatientrecipeinv a,
                                      t_opr_chargedefinv b,
                                      t_opr_charge c,
                                      t_opr_outpatientrecipesumde d,
                                      t_opr_payment e
                                where a.balanceflag_int = 1
                                  and a.invoiceno_vchr = b.invoiceno_vchr
                                  and b.chargeno_chr = c.chargeno_chr
                                  and c.chargeno_chr = d.chargeno_chr
                                  and c.chargeno_chr = e.chargeno_vchr
                                  and e.paytype_int = 1" + OtherWhere +
                               @"union all
                               select a.invoiceno_vchr, a.paytype_int, d.itemcatid_chr,
                                      (d.tolfee_mny - d.sbsum_mny) as sbsum_mny1, d.tolfee_mny
                                 from t_opr_outpatientrecipeinv a,
                                      t_opr_chargedefinv b,
                                      t_opr_charge c,
                                      t_opr_outpatientrecipesumde d,
                                      t_bse_patientpaytype e
                                where a.balanceflag_int = 1
                                  and a.invoiceno_vchr = b.invoiceno_vchr
                                  and a.paytypeid_chr = e.paytypeid_chr
                                  and b.chargeno_chr = c.chargeno_chr
                                  and b.chargeno_chr = d.chargeno_chr
                                  and e.internalflag_int = 2" + OtherWhere + ")";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                objParamArr[2].Value = CheckDate;
                objParamArr[3].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDe2,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
//            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
//       MAX (recorddate_dat) AS maxrecorddate_dat, sum(a.ACCTSUM_MNY) as totalmoney
//                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
//                    where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and c.INTERNALFLAG_INT=1" + OtherWhere;
            strSQL = @"select min (recorddate_dat) as minrecorddate_dat,
                              max (recorddate_dat) as maxrecorddate_dat,
                              sum (a.acctsum_mny) as totalmoney
                         from t_opr_outpatientrecipeinv a,
                              t_opr_chargedefinv b,
                              t_opr_charge c,
                              t_bse_patientpaytype d
                        where a.balanceflag_int = 1
                          and a.invoiceno_vchr = b.invoiceno_vchr
                          and b.chargeno_chr = c.chargeno_chr
                          and c.paytypeid_chr = d.paytypeid_chr
                          and d.internalflag_int = 1" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt3,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
//            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
//       MAX (recorddate_dat) AS maxrecorddate_dat, sum(a.ACCTSUM_MNY) as totalmoney
//                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
//                    where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and c.INTERNALFLAG_INT=1" + OtherWhere;
            strSQL = @"select a.chargeno_chr as invoiceno_vchr, c.itemcatid_chr,
                              (c.tolfee_mny - c.sbsum_mny) as sbsum_mny, c.tolfee_mny, e.paytype_int
                         from t_opr_charge a,
                              t_opr_chargedefinv b,
                              t_opr_outpatientrecipesumde c,
                              t_bse_patientpaytype d,
                              t_opr_payment e
                        where a.recflag_int = 1
                          and a.paytypeid_chr = d.paytypeid_chr(+)
                          and a.chargeno_chr = b.chargeno_chr
                          and a.chargeno_chr = c.chargeno_chr
                          and a.chargeno_chr = e.chargeno_vchr
                          and d.internalflag_int = 1
                          and a.recdate_dat = to_date (? , 'yyyy-mm-dd hh24:mi:ss')
                          and a.recemp_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDe3,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
//            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
//       MAX (recorddate_dat) AS maxrecorddate_dat, sum(a.ACCTSUM_MNY) as totalmoney
//                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
//                    where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT>2" + OtherWhere;
            strSQL = @"select min (recorddate_dat) as minrecorddate_dat,
                              max (recorddate_dat) as maxrecorddate_dat,
                              sum (a.acctsum_mny) as totalmoney
                         from t_opr_outpatientrecipeinv a,
                              t_opr_chargedefinv b,
                              t_opr_charge c,
                              t_bse_patientpaytype d
                        where a.balanceflag_int = 1
                          and a.invoiceno_vchr = b.invoiceno_vchr
                          and b.chargeno_chr = c.chargeno_chr
                          and c.paytypeid_chr = d.paytypeid_chr
                          and d.internalflag_int > 2" + OtherWhere;
           try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt4,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
//            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
//                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
//                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT>2 " + OtherWhere;
            strSQL = @"select a.chargeno_chr as invoiceno_vchr, c.itemcatid_chr,
                              (c.tolfee_mny - c.sbsum_mny) as sbsum_mny, c.tolfee_mny, e.paytype_int
                         from t_opr_charge a,
                              t_opr_chargedefinv b,
                              t_opr_outpatientrecipesumde c,
                              t_bse_patientpaytype d,
                              t_opr_payment e
                        where a.recflag_int = 1
                          and a.paytypeid_chr = d.paytypeid_chr(+)
                          and a.chargeno_chr = b.chargeno_chr
                          and a.chargeno_chr = c.chargeno_chr
                          and a.chargeno_chr = e.chargeno_vchr
                          and d.internalflag_int > 2
                          and a.recdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                          and a.recemp_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = CheckDate;
                objParamArr[1].Value = checkMan;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDe4,objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int,
                              govtopcharge_mny, emrcat_vchr
                        from t_bse_chargeitemextype
                       where flag_int = '1'
                    order by sortcode_int";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtType);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }            
            return lngRes;
        }

        #endregion

        [AutoComplete]
        public long m_lngGetIsUsing(System.Security.Principal.IPrincipal p_objPrincipal, string feild, string valueid)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulHistory");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select count(*) from t_opr_patientregdetail where " + feild + "='" + valueid + "'";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            lngRes = long.Parse(dt.Rows[0][0].ToString());
            return lngRes;
        }
        [AutoComplete]
        public long m_lngGetIsUsingChargeType(System.Security.Principal.IPrincipal p_objPrincipal, string feild, string valueid)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetIsUsingChargeType");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select count(*) from t_opr_patientregister where " + feild + "='" + valueid + "'";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            lngRes = long.Parse(dt.Rows[0][0].ToString());
            return lngRes;
        }
        [AutoComplete]
        public long m_blDeleteDetail(System.Security.Principal.IPrincipal p_objPrincipal, string feild, string valueid)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulHistory");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"delete from t_bse_registerdetail where " + feild + "='" + valueid + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }
        [AutoComplete]
        public long m_lngGetRegisterdetail(System.Security.Principal.IPrincipal p_objPrincipal)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulHistory");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"insert into t_bse_registerdetail
                                 select distinct e.registertypeid_chr, e.chargeid_chr, e.paytypeid_chr,
                                                 e.pay, e.dis
                                            from (select a.registertypeid_chr, b.chargeid_chr,
                                                         c.paytypeid_chr, 0 as pay, 1 as dis
                                                    from t_bse_registertype a cross join t_bse_registerchargetype b
                                                         cross join t_bse_patientpaytype c
                                                         ) e,
                                                 t_bse_registerdetail d
                                           where e.registertypeid_chr = d.registertypeid_chr(+)
                                             and e.chargeid_chr = d.chargeid_chr(+)
                                             and e.paytypeid_chr = d.paytypeid_chr(+)
                                             and d.registertypeid_chr is null
                                             and d.chargeid_chr is null
                                             and d.paytypeid_chr is null";
            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            return lngRes;
        }



        #region 查询历史数据 张国良   2004-9-9
        /// <summary>
        /// 查询历史数据 张国良   2004-9-9
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="checkoutEmpNo"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="strempno"></param>
        /// <param name="objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQulHistory(System.Security.Principal.IPrincipal p_objPrincipal, string checkoutEmpNo, string fromDate, string toDate, out clscheckoutreg_VO[] objResult)
        {

            objResult = new clscheckoutreg_VO[0];
            long lngRes = 0;

            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulHistory");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "SELECT  distinct balance_dat FROM t_opr_patientregister WHERE  balance_dat BETWEEN TO_DATE ('" + fromDate + "', 'yyyy-MM-dd') " +
"AND TO_DATE ('" + toDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') and BALANCEEMP_CHR='" + checkoutEmpNo + "' GROUP BY balance_dat";
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    objResult = new clscheckoutreg_VO[dtResult.Rows.Count];
                    for (int i1 = 0; i1 < objResult.Length; i1++)
                    {
                        objResult[i1] = new clscheckoutreg_VO();
                        objResult[i1].m_strCHECKOUTDATE_DAT = dtResult.Rows[i1]["balance_dat"].ToString().Trim();
                        objResult[i1].m_strMINREGNO_CHR = dtResult.Rows[i1]["rowsCount"].ToString().Trim();
                    }
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        #endregion

        #region 历史数据明细 张国良   2004-9-9
        /// <summary>
        /// 查询历史数据 张国良   2004-9-9
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="checkoutEmpNo"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="strempno"></param>
        /// <param name="objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQulHistoryDetial(System.Security.Principal.IPrincipal p_objPrincipal, string checkoutEmpNo, string findDate, out System.Data.DataTable p_datCheckoutDetial)
        {

            p_datCheckoutDetial = new DataTable();
            long lngRes = 0;

            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngQulHistoryDetial");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "SELECT   registerid_chr " +
                "FROM t_opr_patientregister " +
                "WHERE registeremp_chr = '" + checkoutEmpNo + "' " +
                "AND pstatus_int = 4 " +
                "AND balance_dat = TO_DATE('" + findDate + "', 'yyyy-mm-dd hh24:mi:ss') ";


            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_datCheckoutDetial);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        #endregion

        #region 门诊挂号报表 张国良   2004-9-9
        /// <summary>
        /// 门诊挂号报表 张国良   2004-9-9
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="firstdate">开始日期</param>
        /// <param name="lastdate">结束日期</param>
        /// <param name="p_tabReport">数据表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindByDateReport(System.Security.Principal.IPrincipal p_objPrincipal, string firstdate, string lastdate, out System.Data.DataTable p_tabReport)
        {

            p_tabReport = new DataTable();

            long lngRes = 0;

            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngFindByDateReport");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select   a.registerid_chr, a.registerdate_dat, a.diagdoctor_chr,
         c.lastname_vchr, a.diagdept_chr, e.deptname_vchr,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '001') as rcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '002') as dcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '003') as gcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '004') as ccharge,
         a.recorddate_dat, a.flag_int
    from t_opr_patientregister a, t_bse_employee c, t_bse_deptdesc e
   where a.diagdoctor_chr = c.empid_chr(+)
     and a.diagdept_chr = e.deptid_chr
     and a.balanceemp_chr is not null
     and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                           and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
order by a.diagdept_chr
";

            try
            {

    

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = firstdate + " 00:00:00";
                objLisAddItemRefArr[1].Value = lastdate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_tabReport, objLisAddItemRefArr);
                objHRPSvc.Dispose();


            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        #endregion

        #region 挂号员日报表 张国良   2004-9-9
        /// <summary>
        /// 挂号员日报表 张国良   2004-9-9
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="firstdate">查询开始日期</param>
        /// <param name="lastdate">查询结束日期</param>
        /// <param name="p_tabReport">数据表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindByDateReport2(System.Security.Principal.IPrincipal p_objPrincipal, string firstdate, string lastdate, out System.Data.DataTable p_tabReport)
        {

            p_tabReport = new DataTable();

            long lngRes = 0;

            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngFindByDateReport2");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select   a.registerid_chr, a.registeremp_chr as empid, c.lastname_vchr,
         a.registerdate_dat, e.deptname_vchr,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '001') as rcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '002') as dcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '003') as gcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '004') as ccharge,
         a.recorddate_dat, a.flag_int
    from t_opr_patientregister a, t_bse_employee c, t_bse_deptdesc e
   where a.registeremp_chr = c.empid_chr(+)
     and a.diagdept_chr = e.deptid_chr
     and a.balanceemp_chr is not null
     and a.returnemp_chr is null
     and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
union all
select   a.registerid_chr, a.returnemp_chr as empid, c.lastname_vchr,
         a.registerdate_dat, e.deptname_vchr,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '001') as rcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '002') as dcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '003') as gcharge,
         (select payment_mny * discount_dec
            from t_opr_patientregdetail d
           where d.registerid_chr = a.registerid_chr
             and d.chargeid_chr = '004') as ccharge,
         a.recorddate_dat, a.flag_int
    from t_opr_patientregister a, t_bse_employee c, t_bse_deptdesc e
   where a.returnemp_chr = c.empid_chr(+)
     and a.diagdept_chr = e.deptid_chr
     and a.balanceemp_chr is not null
     and a.returnemp_chr is not null
     and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
order by empid
";


            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = firstdate + " 00:00:00";
                objLisAddItemRefArr[1].Value = lastdate + " 23:59:59";
                objLisAddItemRefArr[2].Value = firstdate + " 00:00:00";
                objLisAddItemRefArr[3].Value = lastdate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_tabReport, objLisAddItemRefArr);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        #endregion

        #region 门诊人次日报表 张国良   2005-03-2
        [AutoComplete]
        public long m_lngDepIncomerpt(System.Security.Principal.IPrincipal p_objPrincipal, string firstdate, string lastdate, out System.Data.DataTable p_tabReport, out System.Data.DataTable depDt)
        {

            p_tabReport = new DataTable();
            depDt = new DataTable();
            long lngRes = 0;

            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngDepIncomerpt");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select t2.deptid_chr, t2.deptname_vchr, t2.parentid, t1.flag_int,
       t1.planperiod_chr, t1.registertypeid_chr,
       t3.deptname_vchr as parentname_vchr, t3.code_vchr
  from t_opr_patientregister t1, t_bse_deptdesc t2, t_bse_deptdesc t3
 where t1.balanceemp_chr is not null
   and t1.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                          and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
   and t1.diagdept_chr = t2.deptid_chr(+)
   and t2.parentid = t3.deptid_chr(+)";

            try
            {

    

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = firstdate + " 00:00:00";
                objLisAddItemRefArr[1].Value = lastdate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_tabReport, objLisAddItemRefArr);
                objHRPSvc.Dispose();


            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"SELECT   distinct(t2.deptid_chr),t2.deptname_vchr, 
         t4.ordercode_vchr,t3.deptname_vchr AS parentname_vchr, t3.code_vchr
    FROM t_opr_patientregister t1,
         t_bse_deptdesc t2,
         t_bse_deptdesc t3,
         t_opr_rptorder t4 where  t1.balanceemp_chr IS NOT NULL and t1.registerdate_dat  BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')AND TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss') AND t1.diagdept_chr = t2.deptid_chr(+)
     AND t2.deptid_chr = t4.deptid_chr(+)
     AND t2.parentid = t3.deptid_chr(+)
ORDER BY t4.ordercode_vchr";

            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = firstdate + " 00:00:00";
                objLisAddItemRefArr[1].Value = lastdate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref depDt, objLisAddItemRefArr);
                objHRPSvc.Dispose();


            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        [AutoComplete]
        public long m_lngSelectAllRptorder(out System.Data.DataTable p_tabReport)
        {
            p_tabReport = new DataTable();
            long lngRes = 0;
            //权限类
            string strSQL = @"SELECT a.deptid_chr, a.deptname_vchr, a.parentid,
       b.ordercode_vchr AS shortno_chr
  FROM t_bse_deptdesc a, t_opr_rptorder b
 WHERE a.deptid_chr = b.deptid_chr(+) order by b.ordercode_vchr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_tabReport);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        [AutoComplete]
        public long m_lngInsertAllRptorder(string[] p_IdArr)
        {
            long lngRes = 0;
            //权限类
            string strSQL = @"delete from t_opr_rptorder ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                string Sql = "";
                for (int i = 0; i < p_IdArr.Length; i++)
                {
                    Sql = "insert into t_opr_rptorder(DEPTID_CHR,ORDERCODE_VCHR) values('" + p_IdArr[i] + "','" + i.ToString().PadLeft(10, '0') + "')";
                    lngRes = objHRPSvc.DoExcute(Sql);
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }
        #endregion

        #region 获取数据库信息(门诊科室挂号输入数据)
        // 注意：要显示的数据字段名必须与数据集dataset的字段名相同
        /// <summary>
        ///  获取数据库信息(门诊科室挂号输入数据)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtpStartDate">yyyy-mm-dd</param>
        /// <param name="p_dtpEndDate">yyyy-mm-dd</param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>

        [AutoComplete]
        public long m_lngGetRegReportPicture(System.Security.Principal.IPrincipal p_objPrincipal, string p_dtpStartDate, string p_dtpEndDate, out  DataTable p_outDatatable)
        {
            long lngRes = 0;
            p_outDatatable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetRegReportPicture");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            string strSQL = @"select t1.deptname_vchr as deptname, sum(t1.payment) as payment,chargename 
         from(
         SELECT  e.deptname_vchr , SUM (f.payment_mny*f.discount_dec) AS payment,g.chargename_chr AS chargename
         FROM t_opr_patientregister a,
              t_bse_patientpaytype b,
			  t_bse_employee c,
			  t_bse_patientidx d,
			  t_bse_deptdesc e,
			  t_opr_patientregdetail f,
			  t_bse_registerchargetype g
		WHERE a.paytypeid_chr = b.paytypeid_chr(+)
				AND a.registeremp_chr = c.empid_chr(+) 
			AND a.patientid_chr = d.patientid_chr(+)
			AND a.diagdept_chr = e.deptid_chr
			AND a.registerid_chr = f.registerid_chr(+)
			AND f.chargeid_chr = g.chargeid_chr
            AND a.balanceemp_chr IS NOT NULL 
			and a.flag_int<>3 AND a.registerdate_dat BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss' )AND TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss') GROUP BY e.deptname_vchr, g.chargename_chr
			UNION
			SELECT  e.deptname_vchr , SUM (-f.payment_mny*f.discount_dec) AS payment,g.chargename_chr AS chargename
         FROM t_opr_patientregister a,
              t_bse_patientpaytype b,
			  t_bse_employee c,
			  t_bse_patientidx d,
			  t_bse_deptdesc e,
			  t_opr_patientregdetail f,
			  t_bse_registerchargetype g
		WHERE a.paytypeid_chr = b.paytypeid_chr(+)
			AND a.registeremp_chr = c.empid_chr(+) 
			AND a.patientid_chr = d.patientid_chr(+)
			AND a.diagdept_chr = e.deptid_chr
			AND a.registerid_chr = f.registerid_chr(+)
			AND f.chargeid_chr = g.chargeid_chr
            AND a.balanceemp_chr IS NOT NULL 
			and a.flag_int=3 AND a.registerdate_dat BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss' ) AND TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss') GROUP BY e.deptname_vchr, g.chargename_chr) t1
			GROUP BY t1.deptname_vchr, t1.chargename  order by  payment";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_dtpStartDate + " 00:00:00";
                objLisAddItemRefArr[1].Value = p_dtpEndDate + " 23:59:59";
                objLisAddItemRefArr[2].Value = p_dtpStartDate + " 00:00:00";
                objLisAddItemRefArr[3].Value = p_dtpEndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_outDatatable, objLisAddItemRefArr);
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
        [AutoComplete]
        #region 获取数据库信息(门诊医生挂号输入数据)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtpStartDate">yyyy-mm-dd</param>
        /// <param name="p_dtpEndDate">yyyy-mm-dd</param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>
        // 注意：要显示的数据字段名必须与数据集dataset的字段名相同

        public long m_lngGetRegReportDoctPicture(System.Security.Principal.IPrincipal p_objPrincipal, string p_dtpStartDate, string p_dtpEndDate, out  DataTable p_outDatatable)
        {
            long lngRes = 0;
            p_outDatatable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetRegReportDoctPicture");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            string strSQL = @"select t1.lastname_vchr, sum(t1.payment) as payment,chargename 
         from(
         SELECT  c.lastname_vchr , SUM(f.payment_mny*f.discount_dec) AS payment,g.chargename_chr AS chargename
         FROM t_opr_patientregister a,
              t_bse_patientpaytype b,
			  t_bse_employee c,
			  t_bse_patientidx d,
			  t_bse_deptdesc e,
			  t_opr_patientregdetail f,
			  t_bse_registerchargetype g
		WHERE a.paytypeid_chr = b.paytypeid_chr(+)
			AND a.DIAGDOCTOR_CHR = c.empid_chr
			AND a.patientid_chr = d.patientid_chr(+)
			AND a.diagdept_chr = e.deptid_chr(+)
			AND a.registerid_chr = f.registerid_chr(+)
			AND f.chargeid_chr = g.chargeid_chr
　　　　　　AND a.balanceemp_chr IS NOT NULL
			and a.flag_int<>3 AND a.registerdate_dat BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss' ) AND TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')
            GROUP BY c.lastname_vchr, g.chargename_chr
			UNION
			SELECT c.lastname_vchr, SUM (-f.payment_mny*f.discount_dec) AS payment,g.chargename_chr AS chargename
         FROM t_opr_patientregister a,
              t_bse_patientpaytype b,
			  t_bse_employee c,
			  t_bse_patientidx d,
			  t_bse_deptdesc e,
			  t_opr_patientregdetail f,
			  t_bse_registerchargetype g
		WHERE a.paytypeid_chr = b.paytypeid_chr(+)
			AND a.DIAGDOCTOR_CHR = c.empid_chr
			AND a.patientid_chr = d.patientid_chr(+)
			AND a.diagdept_chr = e.deptid_chr(+)
			AND a.registerid_chr = f.registerid_chr(+)
			AND f.chargeid_chr = g.chargeid_chr
　　　　　　AND a.balanceemp_chr IS NOT NULL
			and a.flag_int=3 AND a.registerdate_dat BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss' )AND TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')
            GROUP BY c.lastname_vchr, g.chargename_chr) t1
		    GROUP BY t1.lastname_vchr, t1.chargename  order by  payment";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_dtpStartDate + " 00:00:00";
                objLisAddItemRefArr[1].Value = p_dtpEndDate + " 23:59:59";
                objLisAddItemRefArr[2].Value = p_dtpStartDate + " 00:00:00";
                objLisAddItemRefArr[3].Value = p_dtpEndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_outDatatable, objLisAddItemRefArr);
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

        #region 发票管理

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNew(System.Security.Principal.IPrincipal objPri, DataRow dtRow, out string newID)
        {
            newID = null;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngAddNew");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            newID = HRPSvc.m_strGetNewID("t_opr_reginvman", "APPID_CHR", 10);
            string strSQL = @"insert into t_opr_reginvman(APPID_CHR,INVOICENOFROM_VCHR,INVOICENOTO_VCHR,APPLY_DAT,APPUSERID_CHR,OPERATORID_CHR,STATUS_INT)values('" + newID + "','" + dtRow["INVOICENOFROM_VCHR"].ToString().Trim() + "','" + dtRow["INVOICENOTO_VCHR"].ToString().Trim() + "',To_Date('" + dtRow["APPLY_DAT"].ToString().Trim() + "','yyyy-mm-dd hh24:mi:ss'),'" + dtRow["APPUSERID_CHR"].ToString().Trim() + "','" + dtRow["OPERATORID_CHR"].ToString().Trim() + "',0)";
            try
            {
                lngRes = HRPSvc.DoExcute(strSQL);
                HRPSvc.Dispose();
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

        #region 作废发票
        /// <summary>
        /// 作废发票
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCancel(System.Security.Principal.IPrincipal objPri, string strID, string acctID, DateTime AccDate)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngAddNew");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string newID = HRPSvc.m_strGetNewID("t_opr_reginvman", "APPID_CHR", 10);
            string strSQL = @"update t_opr_reginvman set STATUS_INT=1,CANCELUSERID_CHR='" + acctID + "',CANCEL_DAT=To_Date('" + AccDate + "','yyyy-mm-dd hh24:mi:ss') where APPID_CHR='" + strID + "'";
            try
            {
                lngRes = HRPSvc.DoExcute(strSQL);
                HRPSvc.Dispose();
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

        #region 获取所有的发票数据
        /// <summary>
        /// 获取所有的发票数据
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="dt">返回所有的数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllData(System.Security.Principal.IPrincipal objPri, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngAddNew");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string newID = HRPSvc.m_strGetNewID("t_opr_reginvman", "APPID_CHR", 10);
            string strSQL = @"select a.appid_chr, a.invoicenofrom_vchr, a.invoicenoto_vchr, a.apply_dat,
                                     a.appuserid_chr, a.operatorid_chr, a.canceluserid_chr, a.status_int,
                                     a.cancel_dat,
                                     case
                                        when a.status_int = 0
                                           then '正常'
                                        when a.status_int = 1
                                           then '作废'
                                     end as statustype,
                                     b.lastname_vchr as appusername, b.empno_chr,
                                     c.lastname_vchr as operatorname, d.lastname_vchr as cancelname
                                from t_opr_reginvman a, t_bse_employee b, t_bse_employee c,
                                     t_bse_employee d
                               where a.appuserid_chr = b.empid_chr
                                 and a.operatorid_chr = c.empid_chr(+)
                                 and a.canceluserid_chr = d.empid_chr(+)";
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref dt);
                HRPSvc.Dispose();
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

        #region 根据工号查找员工
        /// <summary>
        /// 根据工号查找员工
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strNO"></param>
        /// <param name="dtEmp"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngfindEmp(System.Security.Principal.IPrincipal objPri, string strNO, out DataTable dtEmp)
        {
            dtEmp = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngfindEmp");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            string strSQL = @"select EMPID_CHR,lastname_vchr from t_bse_employee where EMPNO_CHR='" + strNO + "'";
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref dtEmp);
                HRPSvc.Dispose();
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

        #region 病人身份与证件号信息获取与更新(患者身份对应号表)
        /// <summary>
        /// 根据病人ID号与患者身份类型找出证件号(患者身份对应号表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPATIENTID_CHR">患者编号</param>
        /// <param name="p_strPAYTYPEID_CHR">患者身份类型</param>
        /// <param name="p_strNo">身份类型对应号码</param>
        /// <param name="p_strResultPAYTYPEID_CHR">身份名称</param>
        /// <param name="p_strPAYTYPENAME_VCHR"></param>
        /// <param name="p_strINTERNALFLAG_INT">0-普通 1-公费 2-医保 3-特困 （内部使用，用于区分）</param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindNoByPatientIdAndTypeId(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPATIENTID_CHR, string p_strPAYTYPEID_CHR,
            out string p_strNo,
            out string p_strResultPAYTYPEID_CHR,
            out string p_strPAYTYPENAME_VCHR,
            out string p_strINTERNALFLAG_INT
            )
        {
            long lngRes = 0;
            p_strNo = "";
            p_strResultPAYTYPEID_CHR = "";
            p_strPAYTYPENAME_VCHR = "";
            p_strINTERNALFLAG_INT = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngFindNoByPatientIdAndTypeId");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "SELECT   A.PATIENTID_CHR,A.PAYTYPEID_CHR,A.IDNO_VCHR,B.PAYTYPENAME_VCHR ,B.INTERNALFLAG_INT  from t_bse_patientidentityno A ,t_bse_patientpaytype B where A.PAYTYPEID_CHR = B.PAYTYPEID_CHR   and A.PATIENTID_CHR='" + p_strPATIENTID_CHR + "' ";//
            if (p_strPAYTYPEID_CHR != "")
            {
                strSQL += " and  a.PAYTYPEID_CHR='" + p_strPAYTYPEID_CHR + "' ";
            }
            strSQL += " order by  a.PAYTYPEID_CHR asc";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable objdatCheckoutDetial = null;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref objdatCheckoutDetial);
                if (lngRes > 0)
                {
                    if (objdatCheckoutDetial.Rows.Count > 0)
                    {
                        p_strNo = objdatCheckoutDetial.Rows[0]["IDNO_VCHR"].ToString();
                        p_strResultPAYTYPEID_CHR = objdatCheckoutDetial.Rows[0]["PAYTYPEID_CHR"].ToString();
                        p_strPAYTYPENAME_VCHR = objdatCheckoutDetial.Rows[0]["PAYTYPENAME_VCHR"].ToString();
                        p_strINTERNALFLAG_INT = objdatCheckoutDetial.Rows[0]["INTERNALFLAG_INT"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 增加病人身份与证件号(患者身份对应号表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPATIENTID_CHR"></param>
        /// <param name="p_strPAYTYPEID_CHR"></param>
        /// <param name="p_strNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddPatientIdTypeIdNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPATIENTID_CHR, string p_strPAYTYPEID_CHR, string p_strNo)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngAddPatientIdTypeIdNo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"insert into t_bse_patientidentityno( PATIENTID_CHR,PAYTYPEID_CHR,IDNO_VCHR) values ('" + p_strPATIENTID_CHR.Trim().PadLeft(10, '0') + "','" + p_strPAYTYPEID_CHR + "','" + p_strNo.Trim() + "') ";
            string strNo;
            string strPayTypeid;
            string strName;
            string strFlag;
            bool blnHas = false;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //string strSQL0 = "update t_bse_patientidentityno set iscurrentuse_chr = '0' where PATIENTID_CHR = '" + p_strPATIENTID_CHR + "' ";
                //lngRes = objHRPSvc.DoExcute(strSQL0);

                string strSQLFind = @"SELECT   A.PATIENTID_CHR,A.PAYTYPEID_CHR,A.IDNO_VCHR,B.PAYTYPENAME_VCHR ,B.INTERNALFLAG_INT  from t_bse_patientidentityno A ,t_bse_patientpaytype B where A.PAYTYPEID_CHR = B.PAYTYPEID_CHR   and A.PATIENTID_CHR='" + p_strPATIENTID_CHR.Trim().PadLeft(10, '0') + "'  and  a.PAYTYPEID_CHR='" + p_strPAYTYPEID_CHR + "' ";
                DataTable dt = new DataTable();
                lngRes = objHRPSvc.DoGetDataTable(strSQLFind, ref dt);
                if (lngRes < 0)
                {
                    return -1;
                }
                if (dt.Rows.Count > 0)
                {
                    blnHas = true;
                }
                if (blnHas)
                {
                    string strSQLUpdate = @"update t_bse_patientidentityno set IDNO_VCHR='" + p_strNo + "'  where PATIENTID_CHR = '" + p_strPATIENTID_CHR.Trim().PadLeft(10, '0') + "' and PAYTYPEID_CHR='" + p_strPAYTYPEID_CHR + "'";
                    lngRes = objHRPSvc.DoExcute(strSQLUpdate);
                }
                else
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 更新病人身份与证件号(患者身份对应号表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPATIENTID_CHR"></param>
        /// <param name="p_strPAYTYPEID_CHR"></param>
        /// <param name="p_strNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdatePatientIdTypeIdNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPATIENTID_CHR, string p_strPAYTYPEID_CHR, string p_strNo)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngUpdatePatientIdTypeIdNo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "update t_bse_patientidentityno set IDNO_VCHR='" + p_strNo + "'    where PATIENTID_CHR = '" + p_strPATIENTID_CHR + "' and PAYTYPEID_CHR='" + p_strPAYTYPEID_CHR + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 门诊挂号收费打印处方笺
        /// <summary>
        /// 门诊挂号收费打印处方笺
        /// baojian.mo add in 2008-01-13
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strREGISTERNO"></param>
        /// <param name="strRegisterDate"></param>
        /// <param name="objRecipe"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strREGISTERNO, string strRegisterDate, out com.digitalwave.iCare.ValueObject.clsRegisterRecipe_VO objRecipe)
        {
            long lngRes = 0;
            objRecipe = null;
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc", "m_lngGetRecipeInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = 0;
            DataTable dt = new DataTable();
            objRecipe = new com.digitalwave.iCare.ValueObject.clsRegisterRecipe_VO();
            string strRegisterID="";//挂号ID
            string strSQL = @"select a.registerid_chr, a.patientcardid_chr, a.registerdate_dat,
                                     a.paytypeid_chr, a.registerno_chr, b.lastname_vchr, b.homeaddress_vchr,
                                     b.sex_chr, b.birth_dat, b.insuranceid_vchr, b.govcard_chr,
                                     b.difficulty_vchr, c.deptname_vchr, e.order_int, d.paytypename_vchr,
                                     f.internalflag_int, g.lastname_vchr as empname_chr
                                from t_opr_patientregister a,
                                     t_bse_patient b,
                                     t_bse_deptdesc c,
                                     t_bse_patientpaytype d,
                                     t_opr_waitdiaglist e,
                                     t_bse_patientpaytype f,
                                     t_bse_employee g
                               where a.patientid_chr = b.patientid_chr
                                 and a.diagdept_chr = c.deptid_chr
                                 and a.paytypeid_chr = d.paytypeid_chr
                                 and a.registerid_chr = e.registerid_chr
                                 and a.paytypeid_chr = f.paytypeid_chr(+)
                                 and a.registeremp_chr = g.empid_chr
                                 and a.registerno_chr = ?
                                 and trunc (a.registerdate_dat) = trunc (to_date (?, 'yyyy-mm-dd hh24:mi:ss'))";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strREGISTERNO;
                objParamArr[1].Value = strRegisterDate;
                lngRes =objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
                DataRow dr = null;
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    dr=dt.Rows[0];
                    strRegisterID = dr["registerid_chr"].ToString();
                    objRecipe.m_intERNALFLAG_INT = dr["internalflag_int"].ToString();
                    objRecipe.m_strAddress = dr["homeaddress_vchr"].ToString();
                    com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = new com.digitalwave.iCare.middletier.HIS.clsHisBase();
                    int nowTime=HisBase.s_GetServerDate().Year;
                    DateTime birthDate = Convert.ToDateTime(dr["birth_dat"].ToString());
                    objRecipe.m_strAge = Convert.ToString(nowTime - birthDate.Year);
                    objRecipe.m_strCardid = dr["patientcardid_chr"].ToString();
                    objRecipe.m_strDeptName = dr["deptname_vchr"].ToString();
                    objRecipe.m_strGOVCARD_CHR = dr["govcard_chr"].ToString();
                    objRecipe.m_strInSurancdID = dr["insuranceid_vchr"].ToString();
                    objRecipe.m_strPatientName = dr["lastname_vchr"].ToString();
                    objRecipe.m_strPayTypeName = dr["paytypename_vchr"].ToString();
                    objRecipe.m_strRegisterDate = dr["registerdate_dat"].ToString();
                    objRecipe.m_strSex = dr["sex_chr"].ToString();
                    objRecipe.m_strWainno = dr["order_int"].ToString();
                    objRecipe.m_strEmpName = dr["empname_chr"].ToString();
                }
                else
                {
                    return 0;
                }
                if (!string.IsNullOrEmpty(strRegisterID))
                {
                    strSQL = @"select registerid_chr, chargeid_chr, payment_mny, discount_dec
                                 from t_opr_patientregdetail
                                where registerid_chr = ?";
                    dt = null;
                    objParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                    objParamArr[0].Value = strRegisterID.PadRight(18, ' ');
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
                    objHRPSvc.Dispose();
                    if (lngRes > 0 && dt.Rows.Count > 0)
                    {
                        string strMny="";
                        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                        {
                            dr = dt.Rows[i1];
                            strMny = Convert.ToString(Double.Parse(dr["payment_mny"].ToString()) * float.Parse(dr["discount_dec"].ToString()));
                            if (dr["chargeid_chr"].ToString().Trim() == "001")
                            { objRecipe.m_decRegisterPay += decimal.Parse(strMny); }
                            else if (dr["chargeid_chr"].ToString().Trim() == "002")
                            { objRecipe.m_decDiagPay += decimal.Parse(strMny); }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 收费结算日报表
        /// <summary>
        /// 收费结算日报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strDate"></param>
        /// <param name="dtPayType"></param>
        /// <param name="dtCheckOut"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutData(System.Security.Principal.IPrincipal p_objPrincipal, string OPREMPID, string strDate, out DataTable dtPayType, out DataTable dtCheckOut)
        {
            dtPayType = null;
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"SELECT   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.status_int,
         a.seqid_chr, a.balanceemp_chr, a.paytypeid_chr,
         b.tolfee_mny, b.itemcatid_chr, c.internalflag_int, a.acctsum_mny,
         a.sbsum_mny, a.totalsum_mny,a.paytype_int
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c
   WHERE a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.balanceflag_int = 0
     AND a.paytypeid_chr = c.paytypeid_chr
     AND a.recorddate_dat <
                       TO_DATE (?, 'yyyy-mm-dd HH24:mi:ss')
     AND a.recordemp_chr =?    
ORDER BY a.invoiceno_vchr, a.seqid_chr";

            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strDate;
                paramArr[1].Value = OPREMPID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);

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

        #region 历史记录数据
        /// <summary>
        /// 历史记录数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strDate"></param>
        /// <param name="BALANCEEMP"></param>
        /// <param name="dtPayType"></param>
        /// <param name="dtCheckOut"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutDatahistory(System.Security.Principal.IPrincipal p_objPrincipal, string strDate, string BALANCEEMP, out DataTable dtPayType, out DataTable dtCheckOut)
        {
            dtPayType = null;
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT typeid_chr, typename_vchr, flag_int, usercode_chr,
                                       sortcode_int, govtopcharge_mny, emrcat_vchr
                                  FROM t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtPayType);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT,a.OPREMP_CHR, a.SEQID_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,a.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.BALANCEFLAG_INT=1 and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+) and a.BALANCE_DAT=To_Date('" + strDate + "','yyyy-mm-dd HH24:mi:ss') and BALANCEEMP_CHR='" + BALANCEEMP + "'  order by a.INVOICENO_VCHR,a.SEQID_CHR";
            try
            {

                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtCheckOut);
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

        #region 收费员结算日报表(广医三院)
        /// <summary>
        /// 收费员结算日报表(广医三院)
        /// </summary>
        /// <param name="objPrincipal"></param>
        /// <param name="RptID">报表ID(取t_aid_rpt_def表)</param>
        /// <param name="RptType">0-收费员日 1-收费处日</param>
        /// <param name="intRecFlag">0-未结 1-已结</param>
        /// <param name="OPREMPID"></param>
        /// <param name="strDate"></param>
        /// <param name="dtRecipesumde"></param>
        /// <param name="dtCheckOut"></param>
        /// <param name="dtRecipeinv"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckOutOfData(System.Security.Principal.IPrincipal objPrincipal, string RptID, int RptType, int intRecFlag, string OPREMPID, string[] strDate, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            long lngRes = 0;
            dtRecipesumde = null;
            dtCheckOut = null;
            dtRecipeinv = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCheckOutOfData");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = 0;
            string strSQL = "";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (RptType == 0)
                {
                    #region 统计核算分类信息
                    strSQL = @"select a.groupname_chr as typename_vchr,
                                      sum (c.tolfee) as tolfee
                                 from t_aid_rpt_gop_def a,
                                      t_aid_rpt_gop_rla b,
                                      (select f.itemcatid_chr, sum (f.tolfee_mny) as tolfee
                                         from t_opr_charge d, t_opr_outpatientrecipesumde f
                                        where d.chargeno_chr = f.chargeno_chr
                                          and d.recflag_int = 0
                                          and d.operdate_dat < to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                          and d.operemp_chr = ?
                                     group by f.itemcatid_chr) c
                               where a.groupid_chr = b.groupid_chr(+)
                                 and b.typeid_chr = c.itemcatid_chr(+)
                                 and a.rptid_chr = ?
                                 and b.rptid_chr = ?
                                 and tolfee <> 0
                            group by a.groupname_chr";
                    objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                    objParamArr[0].Value = strDate[0];
                    objParamArr[1].Value = OPREMPID;
                    objParamArr[2].Value = RptID;
                    objParamArr[3].Value = RptID;
                    objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipesumde, objParamArr);
                    #endregion

                    #region 统计不同支付方式信息
                    strSQL = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                      a.acctsum_mny, a.operemp_chr as opremp_chr,
                                      a.operdate_dat as recorddate_dat, a.type_int, a.status_int,
                                      b.paytypeid_chr, b.paytypeno_vchr, b.internalflag_int, c.paytype_int,
                                      (c.paysum_mny - c.refusum_mny) as sbmoney
                                 from t_opr_charge a, t_bse_patientpaytype b, t_opr_payment c
                                where a.paytypeid_chr = b.paytypeid_chr(+)
                                  and a.chargeno_chr = c.chargeno_vchr
                                  and a.recflag_int = 0
                                  and a.operdate_dat < to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and a.operemp_chr = ?
                             order by a.chargeno_chr";
                    objParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                    objParamArr[0].Value = strDate[0];
                    objParamArr[1].Value = OPREMPID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, objParamArr);
                    #endregion

                    #region 统计所有发票信息
                    strSQL = @"select a.chargeno_chr, a.patientid_chr, a.paytypeid_chr,
                                      a.totalsum_mny, a.sbsum_mny, a.acctsum_mny, a.hospitalacctsum_mny,
                                      a.operemp_chr, a.operdate_dat, a.recflag_int, a.recemp_chr,
                                      a.recdate_dat, a.type_int, a.status_int, a.doctorid_chr,
                                      a.deptid_chr, a.groupid_chr, a.note_vchr, b.invoiceno_vchr
                                 from t_opr_charge a, t_opr_chargedefinv b
                                where a.chargeno_chr = b.chargeno_chr
                                  and a.status_int = 1
                                  and a.recflag_int = 0
                                  and a.operdate_dat < to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and a.operemp_chr = ?
                             order by a.operdate_dat, a.chargeno_chr, b.invoiceno_vchr";
                    objParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                    objParamArr[0].Value = strDate[0];
                    objParamArr[1].Value = OPREMPID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipeinv, objParamArr);
                    #endregion
                }
                else//收费处日结(未结)
                {
                    #region 统计核算分类信息
                    #region 生成SQL语句
                    ArrayList arrSubSql = new ArrayList();
                    ArrayList arrParm = new ArrayList();
                    string strSub = "";
                    //日结标志
                    strSub = @"
                                          and d.recflag_int = ?";
                    arrSubSql.Add(strSub);
                    arrParm.Add(intRecFlag);
                    //时间段
                    strSub = @"
                                          and d.operdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                              to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                    arrSubSql.Add(strSub);
                    arrParm.Add(strDate[0]);
                    arrParm.Add(strDate[1]);
                    //日结员
                    if (!string.IsNullOrEmpty(OPREMPID))
                    {
                        strSub = @"
                                          and d.operemp_chr = ?";
                        arrSubSql.Add(strSub);
                        arrParm.Add(OPREMPID);
                    }
                    //报表ID
                    strSub = @"
                                     group by f.itemcatid_chr) c
                               where a.groupid_chr = b.groupid_chr(+)
                                 and b.typeid_chr = c.itemcatid_chr(+)
                                 and a.rptid_chr = ?";
                    arrSubSql.Add(strSub);
                    arrParm.Add(RptID);
                    strSub = @"
                                 and b.rptid_chr = ?
                                 and tolfee <> 0
                            group by a.groupname_chr";
                    arrSubSql.Add(strSub);
                    arrParm.Add(RptID);
                    #endregion

                    strSQL = @"select a.groupname_chr as typename_vchr,
                                      sum (c.tolfee) as tolfee, '' as note
                                 from t_aid_rpt_gop_def a,
                                      t_aid_rpt_gop_rla b,
                                      (select f.itemcatid_chr, sum (f.tolfee_mny) as tolfee
                                         from t_opr_charge d, t_opr_outpatientrecipesumde f
                                        where d.chargeno_chr = f.chargeno_chr";

                    foreach (string s in arrSubSql)
                        strSQL += s;

                    objHRPSvc.CreateDatabaseParameter(arrParm.Count, out objParamArr);
                    for (int i1 = 0; i1 < arrParm.Count; i1++)
                        objParamArr[i1].Value = arrParm[i1];
                    objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipesumde, objParamArr);
                    #endregion

                    #region 统计不同支付方式信息
                    #region 生成SQL语句
                    arrSubSql = new ArrayList();
                    arrParm = new ArrayList();
                    //日结标志
                    strSub = @"
                                  and a.recflag_int = ?";
                    arrSubSql.Add(strSub);
                    arrParm.Add(intRecFlag);
                    //时间段
                    strSub = @"
                                  and a.operdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                              to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                    arrSubSql.Add(strSub);
                    arrParm.Add(strDate[0]);
                    arrParm.Add(strDate[1]);
                    //日结员
                    if (!string.IsNullOrEmpty(OPREMPID))
                    {
                        strSub = @"
                                  and a.operemp_chr = ?";
                        arrSubSql.Add(strSub);
                        arrParm.Add(OPREMPID);
                    }
                    #endregion
                    strSQL = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                      a.acctsum_mny, a.operemp_chr as opremp_chr,
                                      a.operdate_dat as recorddate_dat, a.type_int, a.status_int,
                                      b.paytypeid_chr, b.paytypeno_vchr, b.internalflag_int, c.paytype_int,
                                      (c.paysum_mny - c.refusum_mny) as sbmoney
                                 from t_opr_charge a, t_bse_patientpaytype b, t_opr_payment c
                                where a.paytypeid_chr = b.paytypeid_chr(+)
                                  and a.chargeno_chr = c.chargeno_vchr";
                    foreach (string s in arrSubSql)
                        strSQL += s;

                    strSQL += @"
                         order by a.chargeno_chr";
                    objParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(arrParm.Count, out objParamArr);
                    for (int i2 = 0; i2 < arrParm.Count; i2++)
                        objParamArr[i2].Value = arrParm[i2];
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, objParamArr);

                    #region 自定义一个DataTable
                    DataTable dtTmp = new DataTable();
                    dtTmp.Columns.Add("paytype");
                    dtTmp.Columns.Add("totalmny");
                    dtTmp.Columns.Add("note");
                    DataRow dr1 = dtTmp.NewRow();
                    dr1["paytype"] = "记帐";
                    dr1["totalmny"] = "0.00";
                    dr1["note"] = "";
                    DataRow dr2 = dtTmp.NewRow();
                    dr2["paytype"] = "铁路垫支";
                    dr2["totalmny"] = "0.00";
                    dr2["note"] = "";
                    DataRow dr3 = dtTmp.NewRow();
                    dr3["paytype"] = "汇款存款";
                    dr3["totalmny"] = "0.00";
                    dr3["note"] = "";
                    DataRow dr4 = dtTmp.NewRow();
                    dr4["paytype"] = "现金";
                    dr4["totalmny"] = "0.00";
                    dr4["note"] = "";
                    DataRow dr5 = dtTmp.NewRow();
                    dr5["paytype"] = "银联POS";
                    dr5["totalmny"] = "0.00";
                    dr5["note"] = "";
                    DataRow dr6 = dtTmp.NewRow();
                    dr6["paytype"] = "支票";
                    dr6["totalmny"] = "0.00";
                    dr6["note"] = "";
                    if (dtCheckOut.Rows.Count > 0)
                    {
                        DataRow dr = null;
                        for (int i1 = 0; i1 < dtCheckOut.Rows.Count; i1++)
                        {
                            dr = dtCheckOut.Rows[i1];
                            switch (dr["paytype_int"].ToString().Trim())
                            {
                                case "0":
                                    dr4["totalmny"] = Convert.ToDouble(dr4["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "1":
                                    dr5["totalmny"] = Convert.ToDouble(dr5["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "2":
                                    dr6["totalmny"] = Convert.ToDouble(dr6["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "3":
                                    dr2["totalmny"] = Convert.ToDouble(dr2["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "4":
                                    dr3["totalmny"] = Convert.ToDouble(dr3["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                            }
                            if (i1 == 0)
                            {
                                dr1["totalmny"] = Convert.ToDouble(dr1["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["acctsum_mny"].ToString());
                            }
                            else
                            {
                                if (dr["chargeno_chr"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["chargeno_chr"].ToString().Trim())
                                { }
                                else
                                {
                                    dr1["totalmny"] = Convert.ToDouble(dr1["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["acctsum_mny"].ToString());
                                }
                            }
                        }
                    }
                    dr1["totalmny"] = Convert.ToDouble(dr1["totalmny"]).ToString("F2");
                    dr2["totalmny"] = Convert.ToDouble(dr2["totalmny"]).ToString("F2");
                    dr3["totalmny"] = Convert.ToDouble(dr3["totalmny"]).ToString("F2");
                    dr4["totalmny"] = Convert.ToDouble(dr4["totalmny"]).ToString("F2");
                    dr5["totalmny"] = Convert.ToDouble(dr5["totalmny"]).ToString("F2");
                    dr6["totalmny"] = Convert.ToDouble(dr6["totalmny"]).ToString("F2");
                    dtTmp.Rows.Add(dr1);
                    dtTmp.Rows.Add(dr2);
                    dtTmp.Rows.Add(dr3);
                    dtTmp.Rows.Add(dr4);
                    dtTmp.Rows.Add(dr5);
                    dtTmp.Rows.Add(dr6);
                    dtTmp.AcceptChanges();
                    dtCheckOut = dtTmp;
                    #endregion
                    #endregion

                    #region 统计所有发票信息
                    dtRecipeinv = new DataTable();
                    #endregion
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion        

        #region 广医三院日结历史数据查询
        /// <summary>
        /// 广医三院日结历史数据查询
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="RptID"></param>
        /// <param name="RptType"></param>
        /// <param name="strDateArr"></param>
        /// <param name="BALANCEEMP"></param>
        /// <param name="dtRecipesumde"></param>
        /// <param name="dtCheckOut"></param>
        /// <param name="dtRecipeinv"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutDatahistory(System.Security.Principal.IPrincipal p_objPrincipal, string RptID, int RptType, string[] strDateArr, string BALANCEEMP, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            dtCheckOut = null;
            dtRecipesumde = null;
            dtRecipeinv = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutDatahistory");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "";
            try
            {
                if (RptType == 0)
                {
                    #region 统计核算分类信息
                    strSQL = @"select a.groupname_chr as typename_vchr, sum(c.tolfee) as tolfee
                                 from t_aid_rpt_gop_def a,
                                      t_aid_rpt_gop_rla b,
                                      (select f.itemcatid_chr, sum(f.tolfee_mny) as tolfee
                                         from t_opr_charge d, t_opr_outpatientrecipesumde f
                                        where d.chargeno_chr = f.chargeno_chr
                                          and d.recflag_int = 1
                                          and d.recdate_dat = to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                                          and d.recemp_chr = ?
                                        group by f.itemcatid_chr) c
                                where a.groupid_chr = b.groupid_chr(+)
                                  and b.typeid_chr = c.itemcatid_chr(+)
                                  and a.rptid_chr = ?
                                  and b.rptid_chr = ?
                                  and tolfee <> 0
                                group by a.groupid_chr, a.groupname_chr
                                order by a.groupid_chr";

                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                    paramArr[0].Value = strDateArr[0];
                    paramArr[1].Value = BALANCEEMP;
                    paramArr[2].Value = RptID;
                    paramArr[3].Value = RptID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipesumde, paramArr);
                    #endregion

                    #region 统计不同支付方式信息
                    strSQL = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                  a.acctsum_mny, a.operemp_chr as opremp_chr,
                                  a.operdate_dat as recorddate_dat, a.type_int, a.status_int,
                                  b.paytypeid_chr, b.paytypeno_vchr, b.internalflag_int, c.paytype_int,
                                  (c.paysum_mny - c.refusum_mny) as sbmoney
                             from t_opr_charge a, t_bse_patientpaytype b, t_opr_payment c
                            where a.paytypeid_chr = b.paytypeid_chr(+)
                              and a.chargeno_chr = c.chargeno_vchr
                              and a.recflag_int = 1
                              and a.recdate_dat = to_date (?, 'yyyy-mm-dd HH24:mi:ss')
                              and a.recemp_chr = ?
                         order by a.chargeno_chr";

                    paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                    paramArr[0].Value = strDateArr[0];
                    paramArr[1].Value = BALANCEEMP;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);
                    #endregion

                    #region 统计所有发票信息
                    strSQL = @"select a.chargeno_chr, a.patientid_chr, a.paytypeid_chr,
                                  a.totalsum_mny, a.sbsum_mny, a.acctsum_mny, a.hospitalacctsum_mny,
                                  a.operemp_chr, a.operdate_dat, a.recflag_int, a.recemp_chr,
                                  a.recdate_dat, a.type_int, a.status_int, a.doctorid_chr,
                                  a.deptid_chr, a.groupid_chr, a.note_vchr, b.invoiceno_vchr
                             from t_opr_charge a, t_opr_chargedefinv b
                            where a.chargeno_chr = b.chargeno_chr     
                              and a.recflag_int = 1     
                              and a.recdate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                              and a.recemp_chr = ?
                         order by a.operdate_dat, a.chargeno_chr, b.invoiceno_vchr";

                    paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                    paramArr[0].Value = strDateArr[0];
                    paramArr[1].Value = BALANCEEMP;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipeinv, paramArr);
                    #endregion
                }
                else //收费处日结历史
                {
                    string strSub1 = "";
                    string strSub2 = "";
                    #region 统计核算分类信息
                    strSQL = @"select a.groupname_chr as typename_vchr, sum(c.tolfee) as tolfee, '' as note
                                 from t_aid_rpt_gop_def a,
                                      t_aid_rpt_gop_rla b,
                                      (select f.itemcatid_chr, sum(f.tolfee_mny) as tolfee
                                         from t_opr_charge d, t_opr_outpatientrecipesumde f
                                        where d.chargeno_chr = f.chargeno_chr
                                          and d.recflag_int = 1
                                          and d.recdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                              to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                    strSub2 = @"
                                        group by f.itemcatid_chr) c
                                where a.groupid_chr = b.groupid_chr(+)
                                  and b.typeid_chr = c.itemcatid_chr(+)
                                  and a.rptid_chr = ?
                                  and b.rptid_chr = ?
                                  and tolfee <> 0
                                group by a.groupid_chr, a.groupname_chr
                                order by a.groupid_chr";

                    System.Data.IDataParameter[] paramArr = null;
                    if (string.IsNullOrEmpty(BALANCEEMP))
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                        paramArr[0].Value = strDateArr[0];
                        paramArr[1].Value = strDateArr[1];
                        paramArr[2].Value = RptID;
                        paramArr[3].Value = RptID;
                    }
                    else
                    {
                        strSub1 = @"
                                              and d.recemp_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                        paramArr[0].Value = strDateArr[0];
                        paramArr[1].Value = strDateArr[1];
                        paramArr[2].Value = BALANCEEMP;
                        paramArr[3].Value = RptID;
                        paramArr[4].Value = RptID;
                    }
                    strSQL = strSQL + strSub1 + strSub2;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtRecipesumde, paramArr);
                    #endregion

                    #region 统计不同支付方式信息
                    strSQL = @"select a.chargeno_chr, a.paytypeid_chr, a.totalsum_mny, a.sbsum_mny,
                                  a.acctsum_mny, a.operemp_chr as opremp_chr,
                                  a.operdate_dat as recorddate_dat, a.type_int, a.status_int,
                                  b.paytypeid_chr, b.paytypeno_vchr, b.internalflag_int, c.paytype_int,
                                  (c.paysum_mny - c.refusum_mny) as sbmoney
                             from t_opr_charge a, t_bse_patientpaytype b, t_opr_payment c
                            where a.paytypeid_chr = b.paytypeid_chr(+)
                              and a.chargeno_chr = c.chargeno_vchr
                              and a.recflag_int = 1
                              and a.recdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                              to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                    strSub2 = @"
                         order by a.chargeno_chr";

                    paramArr = null;
                    if (string.IsNullOrEmpty(BALANCEEMP))
                    {
                        objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                        paramArr[0].Value = strDateArr[0];
                        paramArr[1].Value = strDateArr[1];
                    }
                    else
                    {
                        strSub1 = @"
                              and a.recemp_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                        paramArr[0].Value = strDateArr[0];
                        paramArr[1].Value = strDateArr[1];
                        paramArr[2].Value = BALANCEEMP;
                    }
                    strSQL = strSQL + strSub1 + strSub2;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, paramArr);

                    #region 自定义一个DataTable
                    DataTable dtTmp = new DataTable();
                    dtTmp.Columns.Add("paytype");
                    dtTmp.Columns.Add("totalmny");
                    dtTmp.Columns.Add("note");
                    DataRow dr1 = dtTmp.NewRow();
                    dr1["paytype"] = "记帐";
                    dr1["totalmny"] = "0.00";
                    dr1["note"] = "";
                    DataRow dr2 = dtTmp.NewRow();
                    dr2["paytype"] = "铁路垫支";
                    dr2["totalmny"] = "0.00";
                    dr2["note"] = "";
                    DataRow dr3 = dtTmp.NewRow();
                    dr3["paytype"] = "汇款存款";
                    dr3["totalmny"] = "0.00";
                    dr3["note"] = "";
                    DataRow dr4 = dtTmp.NewRow();
                    dr4["paytype"] = "现金";
                    dr4["totalmny"] = "0.00";
                    dr4["note"] = "";
                    DataRow dr5 = dtTmp.NewRow();
                    dr5["paytype"] = "银联POS";
                    dr5["totalmny"] = "0.00";
                    dr5["note"] = "";
                    DataRow dr6 = dtTmp.NewRow();
                    dr6["paytype"] = "支票";
                    dr6["totalmny"] = "0.00";
                    dr6["note"] = "";
                    if (dtCheckOut.Rows.Count > 0)
                    {
                        DataRow dr = null;
                        for (int i1 = 0; i1 < dtCheckOut.Rows.Count; i1++)
                        {
                            dr = dtCheckOut.Rows[i1];
                            switch (dr["paytype_int"].ToString().Trim())
                            {
                                case "0":
                                    dr4["totalmny"] = Convert.ToDouble(dr4["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "1":
                                    dr5["totalmny"] = Convert.ToDouble(dr5["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "2":
                                    dr6["totalmny"] = Convert.ToDouble(dr6["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "3":
                                    dr2["totalmny"] = Convert.ToDouble(dr2["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                                case "4":
                                    dr3["totalmny"] = Convert.ToDouble(dr3["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["sbmoney"].ToString());
                                    break;
                            }
                            if (i1 == 0)
                            {
                                dr1["totalmny"] = Convert.ToDouble(dr1["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["acctsum_mny"].ToString());
                            }
                            else
                            {
                                if (dr["chargeno_chr"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["chargeno_chr"].ToString().Trim())
                                { }
                                else
                                {
                                    dr1["totalmny"] = Convert.ToDouble(dr1["totalmny"].ToString().Trim()) + Convert.ToDouble(dr["acctsum_mny"].ToString());
                                }
                            }
                        }
                    }
                    dr1["totalmny"] = Convert.ToDouble(dr1["totalmny"]).ToString("F2");
                    dr2["totalmny"] = Convert.ToDouble(dr2["totalmny"]).ToString("F2");
                    dr3["totalmny"] = Convert.ToDouble(dr3["totalmny"]).ToString("F2");
                    dr4["totalmny"] = Convert.ToDouble(dr4["totalmny"]).ToString("F2");
                    dr5["totalmny"] = Convert.ToDouble(dr5["totalmny"]).ToString("F2");
                    dr6["totalmny"] = Convert.ToDouble(dr6["totalmny"]).ToString("F2");
                    dtTmp.Rows.Add(dr1);
                    dtTmp.Rows.Add(dr2);
                    dtTmp.Rows.Add(dr3);
                    dtTmp.Rows.Add(dr4);
                    dtTmp.Rows.Add(dr5);
                    dtTmp.Rows.Add(dr6);
                    dtTmp.AcceptChanges();
                    dtCheckOut = dtTmp;
                    #endregion
                    #endregion

                    #region 统计所有发票信息
                    dtRecipeinv = new DataTable();
                    #endregion
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

        #region 获取门诊业务收入数据
        /// <summary>
        /// 获取门诊业务收入数据
        /// baojian.mo add in 2008.02.28
        /// </summary>
        /// <param name="isConfirmFlag">0-未审核 1-已审核</param>
        /// <param name="objInvRecArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInvoRecData(int isConfirmFlag, string strDateFrom, string strDateTo, string strConfirmManID, out com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[] objInvRecArr)
        {
            long lngRes = 0;
            objInvRecArr = null;
            string strSQL = "";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                DataTable dtResult = new DataTable();
                if (isConfirmFlag == 1)
                {
                    strSQL = @"select receiptno_vchr, receiptsum_dec, receiptinvono_vchr, collectername_vchr,
       collectdate_chr, operid_chr, opername_vchr, operdate_dat, collecterid_chr
  from t_opr_invoicereceipt
 where collectdate_chr between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                           and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
   and operid_chr = ? order by collectdate_chr";                    
                }
                else 
                {
                    strSQL = @"select a.invoiceno_vchr as receiptno_vchr ,a.balance_dat as collectdate_chr, a.totalsum_mny as receiptsum_dec
  from t_opr_outpatientrecipeinv a
 where a.balanceflag_int = 1
   and a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                         and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
   and a.receiptno_vchr is null
   and a.balanceemp_chr = ? order by a.balance_dat, a.invoiceno_vchr";                    
                }
                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = strDateFrom;
                objDPArr[1].Value = strDateTo;
                objDPArr[2].Value = strConfirmManID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    ArrayList arr = new ArrayList();
                    DataRow dr = null;
                    com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo = null;
                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        dr = dtResult.Rows[i1];
                        objReceiptVo = new clsInvoceRecBill_VO();
                        objReceiptVo.strReceiptNo = dr["receiptno_vchr"].ToString();
                        objReceiptVo.strCollectDate = dr["collectdate_chr"].ToString();
                        objReceiptVo.decReceiptSum = Convert.ToDecimal(dr["receiptsum_dec"].ToString());
                        if (isConfirmFlag == 1)
                        {                            
                            objReceiptVo.strReceiptInvoNO = dr["receiptinvono_vchr"].ToString();
                            objReceiptVo.strCollecterName = dr["collectername_vchr"].ToString();
                            objReceiptVo.strCollecterID = dr["collecterid_chr"].ToString();
                            objReceiptVo.strOperID = dr["operid_chr"].ToString();
                            objReceiptVo.strOperName = dr["opername_vchr"].ToString();
                            objReceiptVo.strOperDate = dr["operdate_dat"].ToString();
                        }
                        arr.Add(objReceiptVo);
                    }
                    objInvRecArr = (com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[])arr.ToArray(typeof(com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO));
                }                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 审核记录
        /// <summary>
        /// 审核记录
        /// </summary>
        /// <param name="arrConDate"></param>
        /// <param name="objReceiptVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngConfirmRecord(System.Collections.ArrayList arrConDate, com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"select receiptno_vchr
  from t_opr_invoicereceipt
 where receiptno_vchr = ?";
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                DataTable dt = new DataTable();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = objReceiptVo.strReceiptNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    return -2;
                }

                strSQL = @"update t_opr_outpatientrecipeinv
   set receiptno_vchr = ?
 where balance_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss')
   and balanceflag_int = 1
   and balanceemp_chr = ?";

                int n = 0;

                DbType[] dbTypes = new DbType[] { 
                        DbType.String,DbType.String,DbType.String
                };

                object[][] objValues = new object[3][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[arrConDate.Count];

                }
                for (int k1 = 0; k1 < arrConDate.Count; k1++)
                {
                    n = -1;
                    objValues[++n][k1] = objReceiptVo.strReceiptNo;
                    objValues[++n][k1] = arrConDate[k1].ToString();
                    objValues[++n][k1] = objReceiptVo.strCollecterID;
                }

                if (arrConDate.Count > 0)
                {
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }

                lngRes = 0;
                if (objReceiptVo != null)
                {
                    strSQL = @"insert into t_opr_invoicereceipt
            (receiptno_vchr, receiptsum_dec, receiptinvono_vchr,
             collectername_vchr, collectdate_chr, operid_chr, opername_vchr,
             operdate_dat, collecterid_chr)
     values (?, ?, ?, ?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?)";
                    objDPArr = null;
                    objHRPSvc.CreateDatabaseParameter(9, out objDPArr);
                    objDPArr[0].Value = objReceiptVo.strReceiptNo;
                    objDPArr[1].Value = objReceiptVo.decReceiptSum;
                    objDPArr[2].Value = objReceiptVo.strReceiptInvoNO;
                    objDPArr[3].Value = objReceiptVo.strCollecterName;
                    objDPArr[4].Value = objReceiptVo.strCollectDate;
                    objDPArr[5].Value = objReceiptVo.strOperID;
                    objDPArr[6].Value = objReceiptVo.strOperName;
                    objDPArr[7].Value = objReceiptVo.strOperDate;
                    objDPArr[8].Value = objReceiptVo.strCollecterID;
                    long lngReceff = -1;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngReceff, objDPArr);
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

         #region 修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="p_strInvoRecNO"></param>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyRecord(string strInvoRecNO, com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objVO)
        {
            long lngRes = 0;
            long lngReceff = -1;
            DataTable dt = null;
            string strSQL = @"select invoiceno_vchr from t_opr_outpatientrecipeinv where receiptno_vchr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                dt = new DataTable();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = objVO.strReceiptNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    return 2;
                }
                if (lngRes <= 0)
                    return lngRes;

                strSQL = @"update t_opr_outpatientrecipeinv
   set receiptno_vchr = ?
 where receiptno_vchr = ?";
                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = objVO.strReceiptNo;
                objDPArr[1].Value = strInvoRecNO;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngReceff, objDPArr);
                if (lngRes <= 0)
                    return lngRes;

                strSQL = @"select receiptno_vchr
  from t_opr_invoicereceipt
 where receiptno_vchr = ?";
                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = objVO.strReceiptNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    return 2;
                }
                if (lngRes <= 0)
                    return lngRes;

                strSQL = @"update t_opr_invoicereceipt
   set receiptno_vchr = ?,
       receiptsum_dec = ?,
       receiptinvono_vchr = ?,
       collectername_vchr = ?,
       collectdate_chr = to_date(?, 'yyyy-mm-dd hh24:mi:ss'),
       operid_chr = ?,
       opername_vchr = ?,
       operdate_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss'),
       collecterid_chr = ?
 where receiptno_vchr = ?";
                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(10, out objDPArr);
                objDPArr[0].Value = objVO.strReceiptNo;
                objDPArr[1].Value = objVO.decReceiptSum;
                objDPArr[2].Value = objVO.strReceiptInvoNO;
                objDPArr[3].Value = objVO.strCollecterName;
                objDPArr[4].Value = objVO.strCollectDate;
                objDPArr[5].Value = objVO.strOperID;
                objDPArr[6].Value = objVO.strOperName;
                objDPArr[7].Value = objVO.strOperDate;
                objDPArr[8].Value = objVO.strCollecterID;
                objDPArr[9].Value = strInvoRecNO;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngReceff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据选择的科室ID重新加载收费员
        [AutoComplete]
        public long m_lngGetCheckManByDeptId(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt, string strdeptId)
        {
            string strSQL = "";
            long lngRes = 0;
            dt = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                if (strdeptId != "1000")
                {
                    strSQL = @"select distinct a.BALANCEEMP_CHR, b.LASTNAME_VCHR
  from t_opr_outpatientrecipeinv a, t_bse_employee b,t_bse_deptemp c,t_bse_deptdesc d
 where BALANCEFLAG_INT = 1
   and a.BALANCEEMP_CHR = b.EMPID_CHR
   and b.empid_chr=c.empid_chr
   and c.deptid_chr=d.deptid_chr
   and d.deptid_chr=?";
                    objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                    paramArr[0].Value = strdeptId;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
                }
                else if (strdeptId == "1000")
                {
                    strSQL = @"select distinct a.BALANCEEMP_CHR, b.LASTNAME_VCHR
  from t_opr_outpatientrecipeinv a, t_bse_employee b
 where BALANCEFLAG_INT = 1
   and a.BALANCEEMP_CHR = b.EMPID_CHR";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
    }
    public class clsGetPatientType
    {
        public clsGetPatientType()
        {
        }
        /// <summary>
        /// 获得病人类型信息
        /// </summary>
        /// <param name="strPatientType">病人类型</param>
        [AutoComplete]
        public long m_mthGetPatientInfo(string strPatientType, out int intPatientType)
        {
            long lngRes = 0;
            intPatientType = 0;
            System.Data.DataTable dtbResult = null;

            string strSQL = @"SELECT PAYFLAG_DEC FROM t_bse_patientpaytype  WHERE PAYTYPEID_CHR = '" + strPatientType.Trim() + "'";

            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {

                    try
                    {
                        intPatientType = Convert.ToInt16(dtbResult.Rows[0]["PAYFLAG_DEC"].ToString().Trim());
                    }
                    catch
                    {
                        intPatientType = 0;
                    }
                }
                else
                {
                    intPatientType = 0;
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
    }
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsConcertreCipeSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsConcertreCipeSvc() { }

        #region 新增协定处方
        [AutoComplete]
        public long m_lngAddNewConcertreCipe(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsConcertrectpe_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewConcertreCipe");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGenerateID(10, "RECIPEID_CHR", "T_AID_CONCERTRECIPE", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_AID_CONCERTRECIPE (RECIPEID_CHR,RECIPENAME_CHR,PRIVILEGE_INT,USERCODE_CHR,WBCODE_CHR,PYCODE_CHR,STATUS_INT,CREATERID_CHR) VALUES (?,?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strRECIPEID_CHR = p_strRecordID;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strRECIPENAME_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_intPRIVILEGE_INT;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strUSERCODE_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strWBCODE_CHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strPYCODE_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[7].Value = p_objRecord.m_strCREATERID_CHR;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

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

        #region 新增协定处方明细
        [AutoComplete]
        public long m_lngAddNewConcertreCipeDetail(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsConcertrecipeDetail_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewConcertreCipeDetail");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGenerateID(10, "DETAILID_CHR", "T_AID_CONCERTRECIPEDETAIL", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_AID_CONCERTRECIPEDETAIL (RECIPEID_CHR,DETAILID_CHR,ITEMID_CHR,QTY_DEC,DOSETYPE_CHR,FREQID_CHR) VALUES (?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strRECIPEID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strDETAILID_CHR = p_strRecordID;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strITEMID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strQTY_DEC;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strUsageID;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strFrequencyID;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

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
        #region 检查助记码是否使用
        /// <summary>
        /// 检查助记码是否使用
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID">如是ID 不为空就是修改时使用</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthCheckCodeIsUsed(System.Security.Principal.IPrincipal p_objPrincipal, string strCode, string strID, string strFLAG)
        {
            long lngRes = 0;



            string strSQL = @"SELECT USERCODE_CHR FROM T_AID_CONCERTRECIPE where USERCODE_CHR ='" + strCode + "' and STATUS_INT =1 and FLAG_INT=" + strFLAG;
            if (strID.Trim() != "")
            {
                strSQL += " and  RECIPEID_CHR <>'" + strID + "'";
            }

            try
            {
                DataTable dt = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                if (lngRes > 0)
                {
                    if (dt.Rows.Count > 0 && dt.Rows[0]["USERCODE_CHR"].ToString().Trim() == strCode.Trim())
                    {
                        lngRes = 3;
                    }
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
        #region 新增可用部门
        [AutoComplete]
        public long m_lngAddNewConcertreCipeDept(System.Security.Principal.IPrincipal p_objPrincipal, clsConcertrecipeDept_VO p_objRecord)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewConcertreCipeDept");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_AID_CONCERTRECIPEDEPT (RECIPEID_CHR,DEPTID_CHR) VALUES (?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strRECIPEID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strDEPTID_CHR;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

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

        #region 修改协定处方
        [AutoComplete]
        public long m_lngConcertreCipeModify(System.Security.Principal.IPrincipal p_objPrincipal, clsConcertrectpe_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeModify");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update  T_AID_CONCERTRECIPE
				set 
RECIPENAME_CHR='" + p_objRecord.m_strRECIPENAME_CHR + @"',
PRIVILEGE_INT='" + p_objRecord.m_intPRIVILEGE_INT.ToString() + @"',
USERCODE_CHR='" + p_objRecord.m_strUSERCODE_CHR + @"',
WBCODE_CHR='" + p_objRecord.m_strWBCODE_CHR + @"',
PYCODE_CHR='" + p_objRecord.m_strPYCODE_CHR + @"',
STATUS_INT='" + p_objRecord.m_intSTATUS_INT.ToString() + @"',
CREATERID_CHR='" + p_objRecord.m_strCREATERID_CHR + "' where RECIPEID_CHR='" + p_objRecord.m_strRECIPEID_CHR + "'"
 ;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 修改处方明细
        [AutoComplete]
        public long m_lngConcertreCipeDetailModify(System.Security.Principal.IPrincipal p_objPrincipal, clsConcertrecipeDetail_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeDetailModify");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update T_AID_CONCERTRECIPEDETAIL
				set
ITEMID_CHR='" + p_objRecord.m_strITEMID_CHR + @"',
QTY_DEC='" + p_objRecord.m_strQTY_DEC + @"', 
DOSETYPE_CHR='" + p_objRecord.m_strUsageID + @"', 
FREQID_CHR='" + p_objRecord.m_strFrequencyID + @"' 
 where RECIPEID_CHR ='" + p_objRecord.m_strRECIPEID_CHR + "' and DETAILID_CHR='" + p_objRecord.m_strDETAILID_CHR + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 删除处方
        [AutoComplete]
        public long m_lngDeleteConcertrecipe(System.Security.Principal.IPrincipal p_objPrincipal, clsConcertrectpe_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngDeleteConcertrecipe");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "delete from T_AID_CONCERTRECIPE where RECIPEID_CHR ='" + p_objRecord.m_strRECIPEID_CHR + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 删除处方明细
        [AutoComplete]
        public long m_lngDeleteConcertrecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsConcertrecipeDetail_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngDeleteConcertrecipeDetail");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "delete from T_AID_CONCERTRECIPEDETAIL where RECIPEID_CHR ='" + p_objRecord.m_strRECIPEID_CHR + "' and DETAILID_CHR='" + p_objRecord.m_strDETAILID_CHR + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 删除处方部门
        [AutoComplete]
        public long m_lngDeleteConcertrecipeDept(System.Security.Principal.IPrincipal p_objPrincipal, clsConcertrecipeDept_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngDeleteConcertrecipeDept");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "delete from T_AID_CONCERTRECIPEDEPT where RECIPEID_CHR='" + p_objRecord.m_strRECIPEID_CHR + "' and DEPTID_CHR ='" + p_objRecord.m_strDEPTID_CHR + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 协处方系统(新)
        #region 根据员工ID取出处方
        [AutoComplete]
        public long m_lngGetConcertreCipeByEmpIDOutTB(System.Security.Principal.IPrincipal p_objPrincipal, string CREATERID, string strEmptID, out DataTable dtbResult, int intFLAG, bool IsPublic)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeByEmpIDOutTB");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select A.RECIPEID_CHR,A.RECIPENAME_CHR,a.DISEASENAME_VCHR,case when A.PRIVILEGE_INT=0 then '公用' when A.PRIVILEGE_INT=1 then '私用' when A.PRIVILEGE_INT=2 then '科室' end as strPRIVILEGE,A.USERCODE_CHR,A.WBCODE_CHR,A.PYCODE_CHR,A.CREATERID_CHR,b.LASTNAME_VCHR from T_AID_CONCERTRECIPE A,T_BSE_EMPLOYEE b where a.CREATERID_CHR=b.EMPID_CHR  and A.PRIVILEGE_INT =1 and
 A.CREATERID_CHR ='" + strEmptID + @"' and A.STATUS_INT =1 and a.FLAG_INT=" + intFLAG.ToString();
            if (IsPublic == true)
            {
                strSQL += @" union select A.RECIPEID_CHR,A.RECIPENAME_CHR,a.DISEASENAME_VCHR,case when A.PRIVILEGE_INT=0 then '公用' when A.PRIVILEGE_INT=1 then '私用' when A.PRIVILEGE_INT=2 then '科室' end as strPRIVILEGE,A.USERCODE_CHR,A.WBCODE_CHR,A.PYCODE_CHR,A.CREATERID_CHR,b.LASTNAME_VCHR from T_AID_CONCERTRECIPE A ,T_BSE_EMPLOYEE b WHERE a.CREATERID_CHR=b.EMPID_CHR and A.PRIVILEGE_INT =0 and A.STATUS_INT =1 and a.FLAG_INT=" + intFLAG.ToString() + @"  
 union
 select AA.RECIPEID_CHR,AA.RECIPENAME_CHR,AA.DISEASENAME_VCHR,case when AA.PRIVILEGE_INT=0 then '公用' when AA.PRIVILEGE_INT=1 then '私用' when AA.PRIVILEGE_INT=2 then '科室' end as strPRIVILEGE,AA.USERCODE_CHR,AA.WBCODE_CHR,AA.PYCODE_CHR,AA.CREATERID_CHR,CC.LASTNAME_VCHR from T_AID_CONCERTRECIPE AA,
 ( select A.recipeid_chr from T_AID_CONCERTRECIPEDEPT A where  A.deptid_chr
 in (select DEPTID_CHR from T_BSE_DEPTEMP where EMPID_CHR ='" + strEmptID + @"')) BB,T_BSE_EMPLOYEE CC
  where AA.RECIPEID_CHR =BB.RECIPEID_CHR and aa.CREATERID_CHR=cc.EMPID_CHR and AA.PRIVILEGE_INT =2 
  and AA.STATUS_INT =1 and AA.FLAG_INT=" + intFLAG.ToString() + @"
  union 
select AA.RECIPEID_CHR,AA.RECIPENAME_CHR,AA.DISEASENAME_VCHR,case when AA.PRIVILEGE_INT=0 
 then '公用' when AA.PRIVILEGE_INT=1 then '私用' when AA.PRIVILEGE_INT=2 
 then '科室' end as strPRIVILEGE,AA.USERCODE_CHR,AA.WBCODE_CHR,AA.PYCODE_CHR,
 AA.CREATERID_CHR,CC.LASTNAME_VCHR from T_AID_CONCERTRECIPE AA,T_BSE_EMPLOYEE CC
 where AA.CREATERID_CHR='" + CREATERID + "'and  aa.CREATERID_CHR=cc.EMPID_CHR and AA.PRIVILEGE_INT =2 and AA.STATUS_INT =1 and AA.FLAG_INT=" + intFLAG.ToString() + @" order by USERCODE_CHR";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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


        #region 获取频率的次数及天数
        /// <summary>
        /// 获取频率的次数及天数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strResult"></param>
        /// <param name="strFREQID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDayAndTime(System.Security.Principal.IPrincipal p_objPrincipal, out string strResult, out string strResult1, string strFREQID)
        {
            strResult1 = null;
            strResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeByEmpIDOutTB");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"Select TIMES_INT,DAYS_INT   From t_aid_recipefreq where FREQID_CHR='" + strFREQID + "'";
            DataTable dtbResult = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dtbResult.Rows.Count > 0)
            {
                strResult = dtbResult.Rows[0]["TIMES_INT"].ToString();
                strResult1 = dtbResult.Rows[0]["DAYS_INT"].ToString();
            }
            return lngRes;
        }
        #endregion

        #region 获取检查部位及检验样本
        /// <summary>
        /// 获取检查部位及检验样本
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="P_dtPark"></param>
        /// <param name="strItemId"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPart(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable P_dtPark, out string ParkName, out string ParkID, string strItemId, string strType)
        {
            P_dtPark = new DataTable();
            ParkName = "";
            ParkID = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetPart");
            if (lngRes < 0)
            {
                return -1;
            }
            DataTable dt = new DataTable();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (strType == "0")//检验样本
            {
                strSQL = "select g.sample_type_id_chr,h.sample_type_desc_vchr from 	t_aid_lis_apply_unit g,t_aid_lis_sampletype h where g.APPLY_UNIT_ID_CHR='" + strItemId + "' and g.sample_type_id_chr = h.sample_type_id_chr";

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
                if (dt.Rows.Count > 0)
                {
                    ParkName = dt.Rows[0]["sample_type_desc_vchr"].ToString();
                }
                strSQL = @"select SAMPLE_TYPE_DESC_VCHR,PYCODE_CHR,WBCODE_CHR,SAMPLE_TYPE_ID_CHR  from t_aid_lis_sampletype";
                try
                {
                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref P_dtPark);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (dt.Rows.Count > 0)
                {
                    ParkName = dt.Rows[0]["sample_type_desc_vchr"].ToString();
                    ParkID = dt.Rows[0]["sample_type_id_chr"].ToString();
                }
            }
            else//检查部位
            {
                strSQL = @"select ASSISTCODE_CHR,PARTNAME,PARTID from ar_apply_partlist";
                try
                {
                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref P_dtPark);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (dt.Rows.Count > 0)
                {
                    ParkName = dt.Rows[0]["sample_type_desc_vchr"].ToString();
                }
            }

            return lngRes;
        }

        #endregion

        #region 根据处方ID取出处方明细
        [AutoComplete]
        public long m_lngGetConcertreCipeDetailByIDOutTb(System.Security.Principal.IPrincipal p_objPrincipal, string strID, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeDetailByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.recipeid_chr, a.detailid_chr, a.itemid_chr, a.qty_dec,
                                     a.freqid_chr, a.dosetype_chr, a.dosageqty_dec, a.days_int,
                                     a.rowno_chr, a.partortype_vchr, a.flag_int, a.partortypename_vchr,
                                     a.sort_int,
                                     case
                                        when a.flag_int is null or a.flag_int = 2
                                           then ''
                                        when a.flag_int = 0
                                           then (select f.sample_type_desc_vchr
                                                   from t_aid_lis_sampletype f
                                                  where a.partortype_vchr =
                                                              f.sample_type_id_chr)
                                        else (select k.partname
                                                from ar_apply_partlist k
                                               where a.partortype_vchr = k.partid)
                                     end as partortypename_vchr,
                                     b.itemname_vchr,
                                     (select k.typename_vchr
                                        from t_bse_chargeitemextype k
                                       where k.typeid_chr = b.itemopinvtype_chr
                                         and flag_int = 2) as itemtype,
                                     b.itemspec_vchr,
                                     case
                                        when b.opchargeflg_int = 1
                                           then b.itemipunit_chr
                                        when b.opchargeflg_int = 0
                                           then b.itemopunit_chr
                                     end as itemopunit_chr,
                                     case
                                        when b.opchargeflg_int = 1
                                           then round (b.itemprice_mny / b.packqty_dec,
                                                       4
                                                      )
                                        when b.opchargeflg_int = 0
                                           then b.itemprice_mny
                                     end as itemprice_mny,
                                     b.dosageunit_chr, d.usagename_vchr, e.freqname_chr,
                                     e.days_int as daytag, f.noqtyflag_int, f.medicineid_chr,
                                     b.dosage_dec
                                from t_aid_concertrecipedetail a,
                                     t_bse_chargeitem b,
                                     t_aid_concertrecipe c,
                                     t_bse_usagetype d,
                                     t_aid_recipefreq e,
                                     t_bse_medicine f
                               where a.dosetype_chr = d.usageid_chr(+)
                                 and a.freqid_chr = e.freqid_chr(+)
                                 and a.itemid_chr = b.itemid_chr
                                 and a.recipeid_chr = c.recipeid_chr
                                 and trim (b.itemsrcid_vchr) = trim (f.medicineid_chr(+))
                                 and c.recipeid_chr = ?
                            order by a.sort_int";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
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

        #region 获取所有的项目数据
        [AutoComplete]
        public long m_mthFindMedicine(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt, string strType)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindMedicineByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            if (strType != null)
                strSQL = @"SELECT   itemid_chr, h.partname as partortypename_vchr, a.ITEMCHECKTYPE_CHR,a.itemsrcid_vchr, a.dosage_dec,
         a.dosageunit_chr,
         (SELECT k.typename_vchr
            FROM t_bse_chargeitemextype k
           WHERE k.typeid_chr = a.itemopinvtype_chr
             AND flag_int = 2) AS itemtype,
         a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
         a.itemwbcode_chr, a.itempycode_chr,
         CASE
            WHEN a.opchargeflg_int = 1
               THEN ROUND (a.itemprice_mny / a.packqty_dec, 4)
            WHEN a.opchargeflg_int = 0
               THEN a.itemprice_mny
         END AS submoney,
         CASE
            WHEN a.opchargeflg_int = 1
               THEN a.itemipunit_chr
            WHEN a.opchargeflg_int = 0
               THEN a.itemopunit_chr
         END AS itemopunit_chr,
         a.itemopunit_chr AS itemopunit, a.itemprice_mny, a.isrich_int,
         (SELECT precent_dec
            FROM t_aid_inschargeitem g
           WHERE g.itemid_chr = a.itemid_chr
             AND g.copayid_chr = '" + strType + @"') AS precent,
         a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int,
         a.itemcode_vchr, a.itemopcalctype_chr, b.noqtyflag_int,
         b.medicineid_chr, a.itemipunit_chr, a.opchargeflg_int, a.usageid_chr,
         c.usagename_vchr, d.groupid_chr
    FROM t_bse_chargeitem a,
         (SELECT groupid_chr, catid_chr
            FROM t_bse_chargecatmap
           WHERE internalflag_int = 0) d,
         t_bse_medicine b,
         t_bse_usagetype c,
         ar_apply_partlist h
   WHERE a.ifstop_int = 0
     AND a.itemopinvtype_chr = d.catid_chr(+)
     AND a.itemsrcid_vchr = b.medicineid_chr(+)
     AND a.usageid_chr = c.usageid_chr(+)
     AND a.itemchecktype_chr = h.partid(+)
ORDER BY itemcode_vchr";
            else
                strSQL = @"SELECT   itemid_chr, h.partname, a.itemsrcid_vchr, a.dosage_dec,
         a.dosageunit_chr,
         (SELECT k.typename_vchr
            FROM t_bse_chargeitemextype k
           WHERE k.typeid_chr = a.itemopinvtype_chr
             AND flag_int = 2) AS itemtype,
         a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
         a.itemwbcode_chr, a.itempycode_chr,
         CASE
            WHEN a.opchargeflg_int = 1
               THEN ROUND (a.itemprice_mny / a.packqty_dec, 4)
            WHEN a.opchargeflg_int = 0
               THEN a.itemprice_mny
         END AS submoney,
         CASE
            WHEN a.opchargeflg_int = 1
               THEN a.itemipunit_chr
            WHEN a.opchargeflg_int = 0
               THEN a.itemopunit_chr
         END AS itemopunit_chr,
         a.itemopunit_chr AS itemopunit, a.itemprice_mny, a.isrich_int,
         a.itemopinvtype_chr, a.itemcatid_chr, a.selfdefine_int,
         a.itemcode_vchr, a.itemopcalctype_chr, b.noqtyflag_int,
         b.medicineid_chr, a.itemipunit_chr, a.opchargeflg_int, a.usageid_chr,
         c.usagename_vchr, d.groupid_chr
    FROM t_bse_chargeitem a,
         (SELECT groupid_chr, catid_chr
            FROM t_bse_chargecatmap
           WHERE internalflag_int = 0) d,
         t_bse_medicine b,
         t_bse_usagetype c,
         ar_apply_partlist h
   WHERE a.ifstop_int = 0
     AND a.itemopinvtype_chr = d.catid_chr(+)
     AND a.itemsrcid_vchr = b.medicineid_chr(+)
     AND a.usageid_chr = c.usageid_chr(+)
     AND a.itemchecktype_chr = h.partid(+)
ORDER BY itemcode_vchr";
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
        #endregion

        #region 取出处方所属的部门
        [AutoComplete]
        public long m_lngGetDeptByConcertreCipeID(System.Security.Principal.IPrincipal p_objPrincipal, string strReciptID, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeDeptByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.recipeid_chr, a.deptid_chr, c.deptname_vchr
                                from t_aid_concertrecipedept a, t_aid_concertrecipe b, t_bse_deptdesc c
                               where a.deptid_chr = c.deptid_chr
                                 and a.recipeid_chr = b.recipeid_chr
                                 and b.recipeid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out  objParamArr);
                objParamArr[0].Value = strReciptID;
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

        #region 查找用法
        [AutoComplete]
        public long m_mthFindUsage(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindWMedicineByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select usageid_chr, usagename_vchr, usercode_chr, pycode_vchr, wbcode_vchr,
                                     scope_int, putmed_int, test_int, opusagedesc
                                from t_bse_usagetype
                            order by usercode_chr";
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

        #region 查找频率
        [AutoComplete]
        public long m_mthFindFrequency(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindWMedicineByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select FREQID_CHR,FREQNAME_CHR,USERCODE_CHR,DAYS_INT  from T_AID_RECIPEFREQ order by USERCODE_CHR";
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

        #region 查找自付比例
        [AutoComplete]
        public long m_longPrecent(System.Security.Principal.IPrincipal p_objPrincipal, DataTable dt, out DataTable dt1, string payType)
        {
            dt1 = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_longPrecent");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL;
            for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            {
                strSQL = @"select PRECENT_DEC  from T_AID_INSCHARGEITEM 
where itemid_chr='" + dt.Rows[i1]["ITEMID_CHR"].ToString() + "' and COPAYID_CHR='" + payType + "'";
                DataTable dt3 = new DataTable();
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt3);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                if (dt3.Rows.Count > 0)
                {
                    dt.Rows[i1]["precent"] = dt3.Rows[0][0].ToString() + "%";
                }
                else
                {
                    dt.Rows[i1]["precent"] = "100%";
                }
            }
            dt1 = dt;
            return lngRes;
        }
        #endregion

        #endregion

        #region  获得所有部门信息
        /// <summary>
        ///  获得所有部门信息
        /// </summary>
        [AutoComplete]
        public long m_lngGetDept(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngGetDept");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                string strSQL = @"select SHORTNO_CHR,DEPTNAME_VCHR,PYCODE_CHR,WBCODE_CHR,DEPTID_CHR from T_BSE_DEPTDESC where CATEGORY_INT=0 and (ATTRIBUTEID = '0000002' or ATTRIBUTEID ='0000001') and DEPTNAME_VCHR <> '所有' and INPATIENTOROUTPATIENT_INT = 0  order by SHORTNO_CHR";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes < 0)
                    return lngRes;
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

        #region  获取科室 列表

        [AutoComplete]
        public long m_lngGetDeptList(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbResult)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngGetOPDeptListByDate");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = @"select SHORTNO_CHR,DEPTNAME_VCHR,PYCODE_CHR,WBCODE_CHR,DEPTID_CHR from T_BSE_DEPTDESC where (ATTRIBUTEID = '0000002' or ATTRIBUTEID ='0000001') and DEPTNAME_VCHR <> '所有' order by SHORTNO_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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

        #region 新增协定处方
        /// <summary>
        /// 新增协定处方
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID">记录人ID</param>
        /// <param name="bt">处方信息</param>
        /// <param name="btDe">处方明细表</param>
        /// <param name="btDetp">部门信息表</param>
        /// <param name="isDetp">是否所属部门1-是，0-不是</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewConcertre(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, DataTable dtSoure, DataTable btDe, DataTable btDetp, string isDetp, int intFLAG)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewConcertre");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;

            DataRow bt = dtSoure.Rows[0];

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            p_strRecordID = objHRPSvc.m_strGetNewID("T_AID_CONCERTRECIPE", "RECIPEID_CHR", 10);
            string strSQL = "INSERT INTO T_AID_CONCERTRECIPE (RECIPEID_CHR,RECIPENAME_CHR,PRIVILEGE_INT,USERCODE_CHR,PYCODE_CHR,WBCODE_CHR,STATUS_INT,CREATERID_CHR,FLAG_INT,DISEASENAME_VCHR) VALUES ('" + p_strRecordID + "','" + bt["RECIPENAME_CHR"].ToString() + "'," + bt["strPRIVILEGE"].ToString() + ",'" + bt["USERCODE_CHR"].ToString() + "','" + bt["PYCODE_CHR"].ToString() + "','" + bt["WBCODE_CHR"].ToString() + "',1,'" + bt["CREATERID_CHR"].ToString() + "'," + intFLAG.ToString() + ",'" + bt["DISEASENAME_VCHR"].ToString() + "')";
            //往表增加记录
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

            if (lngRes == 1)
            {
                if (isDetp == "1" && btDetp.Rows.Count > 0)
                {
                    for (int f2 = 0; f2 < btDetp.Rows.Count; f2++)
                    {
                        if (btDetp.Rows[f2]["DEPTID_CHR"].ToString().Trim() != "")
                        {
                            strSQL = @"insert into T_AID_CONCERTRECIPEDEPT(RECIPEID_CHR,DEPTID_CHR) VALUES('" + p_strRecordID + "','" + btDetp.Rows[f2]["DEPTID_CHR"].ToString() + "')";
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
                        }
                    }
                }

                for (int i1 = 0; i1 < btDe.Rows.Count; i1++)
                {
                    string newID = "";
                    objHRPSvc.lngGenerateID(10, "DETAILID_CHR", "T_AID_CONCERTRECIPEDETAIL", out newID);
                    strSQL = "INSERT INTO T_AID_CONCERTRECIPEDETAIL (RECIPEID_CHR,DETAILID_CHR,ITEMID_CHR,QTY_DEC,DOSETYPE_CHR,FREQID_CHR,DOSAGEQTY_DEC,DAYS_INT,ROWNO_CHR,PARTORTYPE_VCHR,FLAG_INT,PARTORTYPENAME_VCHR,sort_int) VALUES ('" + p_strRecordID + "','" + newID + "','" + btDe.Rows[i1]["ITEMID_CHR"].ToString() + "'," + btDe.Rows[i1]["QTY_DEC"].ToString() + ",'" + btDe.Rows[i1]["DOSETYPE_CHR"].ToString() + "','" + btDe.Rows[i1]["FREQID_CHR"].ToString() + "'," + btDe.Rows[i1]["DOSAGEQTY_DEC"].ToString() + "," + btDe.Rows[i1]["DAYS_INT"].ToString() + ",'" + btDe.Rows[i1]["ROWNO_CHR"].ToString() + "','" + btDe.Rows[i1]["PARTORTYPE_VCHR"].ToString() + "'," + btDe.Rows[i1]["FLAG_INT"].ToString() + ",'" + btDe.Rows[i1]["PARTORTYPENAME_VCHR"].ToString() + "'," + btDe.Rows[i1]["sort_int"] + ")";
                    //往表增加记录
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

                }

            }
            return lngRes;
        }
        #endregion

        #region 删除处方
        [AutoComplete]
        public long m_lngDeleteConcertrecipeAndDe(System.Security.Principal.IPrincipal p_objPrincipal, string RecID, string RecIDDe, string DetailID, string strItem, string strFlag)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngDeleteConcertrecipe");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (RecID.Trim() != "")
            {
                strSQL = "delete from T_AID_CONCERTRECIPE where RECIPEID_CHR ='" + RecID + "'";

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
                if (lngRes == 1)
                {
                    strSQL = "delete from T_AID_CONCERTRECIPEDETAIL where RECIPEID_CHR ='" + RecID + "'";

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
                }
                else
                {

                }
                if (RecID == "2")
                {
                    strSQL = "delete from T_AID_CONCERTRECIPEDEPT where RECIPEID_CHR ='" + RecID + "'";
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
                }
            }
            if (RecIDDe.Trim() != "")
            {
                if (strItem == null)
                {
                    strSQL = "delete from T_AID_CONCERTRECIPEDETAIL where RECIPEID_CHR ='" + RecIDDe + "' and DETAILID_CHR='" + DetailID + "'";
                }
                else
                {
                    strSQL = "delete from T_AID_CONCERTRECIPEDETAIL where ITEMID_CHR ='" + strItem + "' and recipeid_chr IN (SELECT recipeid_chr FROM t_aid_concertrecipe WHERE flag_int =" + strFlag + ")";
                }
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
            }

            return lngRes;
        }
        #endregion

        #region 修改处方明细
        /// <summary>
        /// 修改处方明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID">处方ID</param>
        /// <param name="dtRow">新的明细数据</param>
        /// <param name="oldITEMID">旧的明细项目ID，如= null修改单条记录，！=NULL所有修改处方名细中相同项目的数据 </param>
        /// <param name="strFLAG">标志 0－协定处方 1－收费组合</param>
        /// <param name="blIsPublic">是否有公用权限</param>
        /// <param name="CREATERID">创建人</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngConcertreCipeDetailModifyDe(System.Security.Principal.IPrincipal p_objPrincipal, string strID, DataTable dtSoure, string oldITEMID, string strFLAG, bool blIsPublic, string CREATERID, int m_intSort)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeDetailModify");
            if (lngRes < 0)
            {
                return -1;
            }

            DataRow dtRow = dtSoure.Rows[0];

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strwhere = " RECIPEID_CHR ='" + strID + "' and DETAILID_CHR='" + dtRow["DETAILID_CHR"].ToString() + "'";
            string strSQL = "";
            string strSQL1 = "";
            if (oldITEMID == null)
            {
                strSQL = @"update T_AID_CONCERTRECIPEDETAIL
				set
ITEMID_CHR='" + dtRow["ITEMID_CHR"].ToString() + @"',
QTY_DEC='" + dtRow["QTY_DEC"].ToString() + @"', 
DOSAGEQTY_DEC=" + dtRow["DOSAGEQTY_DEC"].ToString() + @", 
DOSETYPE_CHR='" + dtRow["DOSETYPE_CHR"].ToString() + @"', 
FREQID_CHR='" + dtRow["FREQID_CHR"].ToString() + @"', 
DAYS_INT=" + dtRow["DAYS_INT"].ToString() + @",
ROWNO_CHR='" + dtRow["ROWNO_CHR"].ToString() + @"',FLAG_INT=" + dtRow["FLAG_INT"].ToString() + ",PARTORTYPE_VCHR='" + dtRow["PARTORTYPE_VCHR"].ToString() + "',PARTORTYPENAME_VCHR='" + dtRow["PARTORTYPENAME_VCHR"].ToString() + "',sort_int=" + m_intSort + "  where " + strwhere;
            }
            else
            {

                strSQL1 = @"update T_AID_CONCERTRECIPEDETAIL
				set
ITEMID_CHR='" + dtRow["ITEMID_CHR"].ToString() + @"',
QTY_DEC='" + dtRow["QTY_DEC"].ToString() + @"', 
DOSAGEQTY_DEC=" + dtRow["DOSAGEQTY_DEC"].ToString() + @", 
DOSETYPE_CHR='" + dtRow["DOSETYPE_CHR"].ToString() + @"', 
FREQID_CHR='" + dtRow["FREQID_CHR"].ToString() + @"', 
DAYS_INT=" + dtRow["DAYS_INT"].ToString() + @",
ROWNO_CHR='" + dtRow["ROWNO_CHR"].ToString() + @"' ,FLAG_INT=" + dtRow["FLAG_INT"].ToString() + ",PARTORTYPE_VCHR='" + dtRow["PARTORTYPE_VCHR"].ToString() + "',PARTORTYPENAME_VCHR='" + dtRow["PARTORTYPENAME_VCHR"].ToString() + "',sort_int=" + m_intSort + "   where " + strwhere;
                if (blIsPublic)
                {
                    strwhere = "  ITEMID_CHR ='" + oldITEMID + "' and RECIPEID_CHR in (select  RECIPEID_CHR from t_aid_concertrecipe where FLAG_INT=" + strFLAG + ")";

                }
                else
                {
                    strwhere = "  ITEMID_CHR ='" + oldITEMID + "' and RECIPEID_CHR in (select  RECIPEID_CHR from t_aid_concertrecipe where FLAG_INT=" + strFLAG + " and CREATERID_CHR='" + CREATERID + "')";
                }
                strSQL = @"update T_AID_CONCERTRECIPEDETAIL
				set ITEMID_CHR='" + dtRow["ITEMID_CHR"].ToString() + @"' ,sort_int=" + m_intSort + "  where " + strwhere;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL1);
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 修改协定处方
        [AutoComplete]
        public long m_lngConcertreModify(System.Security.Principal.IPrincipal p_objPrincipal, DataTable dtSource, DataTable Deptbt)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeModify");
            if (lngRes < 0)
            {
                return -1;
            }
            //change 2007.5.9 zhu.w.t
            //DataRow ModifiyRow = dtSource.Rows[0];
            //========================================>>
            int intRowNum = dtSource.Rows.Count;
            DataRow ModifiyRow = dtSource.Rows[intRowNum - 1];
            /*<<========================================*/

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update  T_AID_CONCERTRECIPE
				set 
RECIPENAME_CHR='" + ModifiyRow["RECIPENAME_CHR"].ToString() + @"',
PRIVILEGE_INT='" + ModifiyRow["strPRIVILEGE"].ToString() + @"',
USERCODE_CHR='" + ModifiyRow["USERCODE_CHR"].ToString() + @"',
WBCODE_CHR='" + ModifiyRow["WBCODE_CHR"].ToString() + @"',
PYCODE_CHR='" + ModifiyRow["PYCODE_CHR"].ToString() + @"',
CREATERID_CHR='" + ModifiyRow["CREATERID_CHR"].ToString() + "',DISEASENAME_VCHR='" + ModifiyRow["DISEASENAME_VCHR"].ToString() + "'  where RECIPEID_CHR='" + ModifiyRow["RECIPEID_CHR"].ToString() + "'"
                ;
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
            strSQL = @"delete T_AID_CONCERTRECIPEDEPT where RECIPEID_CHR='" + ModifiyRow["RECIPEID_CHR"].ToString() + "'";
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
            if (Deptbt != null && Deptbt.Rows.Count > 0)
            {
                for (int f2 = 0; f2 < Deptbt.Rows.Count; f2++)
                {
                    if (Deptbt.Rows[f2]["DEPTID_CHR"].ToString().Trim() != "")
                    {
                        strSQL = @"insert into T_AID_CONCERTRECIPEDEPT(RECIPEID_CHR,DEPTID_CHR) VALUES('" + ModifiyRow["RECIPEID_CHR"].ToString() + "','" + Deptbt.Rows[f2]["DEPTID_CHR"].ToString() + "')";
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
                    }
                }

            }
            return lngRes;
        }
        #endregion

        #region 新增明细
        [AutoComplete]
        public long m_lngConcertreCipeDetailAddNEWDe(System.Security.Principal.IPrincipal p_objPrincipal, string strID, DataTable dtSource, int m_intSort)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeDetailAddNEWDe");
            if (lngRes < 0)
            {
                return -1;
            }

            DataRow btDe = dtSource.Rows[0];

            string newID;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            objHRPSvc.lngGenerateID(10, "DETAILID_CHR", "T_AID_CONCERTRECIPEDETAIL", out newID); ;
            string strSQL = "INSERT INTO T_AID_CONCERTRECIPEDETAIL (RECIPEID_CHR,DETAILID_CHR,ITEMID_CHR,QTY_DEC,DOSETYPE_CHR,FREQID_CHR,DOSAGEQTY_DEC,ROWNO_CHR,DAYS_INT,PARTORTYPE_VCHR,FLAG_INT,PARTORTYPENAME_VCHR,sort_int) VALUES ('" + strID + "','" + newID + "','" + btDe["ITEMID_CHR"].ToString() + "'," + btDe["QTY_DEC"].ToString() + ",'" + btDe["DOSETYPE_CHR"].ToString() + "','" + btDe["FREQID_CHR"].ToString() + "'," + btDe["DOSAGEQTY_DEC"].ToString() + ",'" + btDe["ROWNO_CHR"].ToString() + "'," + btDe["DAYS_INT"].ToString() + ",'" + btDe["PARTORTYPE_VCHR"].ToString() + "'," + btDe["FLAG_INT"].ToString() + ",'" + btDe["PARTORTYPENAME_VCHR"].ToString() + "'," + m_intSort + ")";
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
            return lngRes;
        }
        #endregion


        //		#endregion

        #region 病人类型收费项目维护

        #region 获得所有的病人类型
        /// <summary>
        /// 获得所有的病人类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="btPatientPayType"></param>
        [AutoComplete]
        public long m_lngGetAllPatientPayType(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable btPatientPayType)
        {
            long lngRes = 0;
            btPatientPayType = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetAllPatientPayType");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select PAYTYPENO_VCHR,PAYTYPENAME_VCHR,case when ISUSING_NUM=0 then '停用' when ISUSING_NUM=1 then '正常' end as strISUSING,MEMO_VCHR,PAYTYPEID_CHR from t_bse_patientpaytype order by PAYTYPENO_VCHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref btPatientPayType);
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

        #region 增加项目明细
        /// <summary>
        /// 增加项目明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strPayTypeID"></param>
        /// <param name="strItemId"></param>
        /// <param name="intQty"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewItem(System.Security.Principal.IPrincipal p_objPrincipal, string strPayTypeID, string strItemId, int intQty, int REGISTER, int RECIPEFLAG, int EXPERT)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewItem");
            if (lngRes < 0)
            {
                return -1;
            }
            if (lngRes < 0)
                return lngRes;
            string strSQL = "INSERT INTO t_aid_chargepaytype(PAYTYPEID_CHR,ITEMID_CHR,QTY_DEC,REGISTER_INT,RECIPEFLAG_INT,EXPERT_INT) VALUES ('" + strPayTypeID + "','" + strItemId + "'," + intQty + "," + REGISTER + "," + RECIPEFLAG + "," + EXPERT + ")";
            //往表增加记录
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);

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

        #region 删除项目
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strPayTypeID"></param>
        /// <param name="strItemId"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleItem(System.Security.Principal.IPrincipal p_objPrincipal, string strPayTypeID, string strItemId)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewItem");
            if (lngRes < 0)
            {
                return -1;
            }
            if (lngRes < 0)
                return lngRes;
            string strSQL = "Delete t_aid_chargepaytype where PAYTYPEID_CHR='" + strPayTypeID + "' and ITEMID_CHR='" + strItemId + "'";
            //往表增加记录
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 修改项目数据
        /// <summary>
        ///修改项目数据 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strPayTypeID"></param>
        /// <param name="strOldItemId"></param>
        /// <param name="strItemId"></param>
        /// <param name="intQty"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyItem(System.Security.Principal.IPrincipal p_objPrincipal, string strPayTypeID, string strOldItemId, string strItemId, int intQty, int REGISTER, int RECIPEFLAG, int EXPERT)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNewItem");
            if (lngRes < 0)
            {
                return -1;
            }
            if (lngRes < 0)
                return lngRes;
            string strSQL = "update  t_aid_chargepaytype set ITEMID_CHR='" + strItemId + "',QTY_DEC=" + intQty + ",REGISTER_INT=" + REGISTER + ",RECIPEFLAG_INT=" + RECIPEFLAG + ",EXPERT_INT=" + EXPERT + " where PAYTYPEID_CHR='" + strPayTypeID + "' and ITEMID_CHR='" + strOldItemId + "'";
            //修改项目数据
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 根据病人类型ID获取项目数据
        /// <summary>
        /// 根据病人类型ID获取项目数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strPayTypeID"></param>
        /// <param name="bt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetItemByPayID(System.Security.Principal.IPrincipal p_objPrincipal, string strPayTypeID, out DataTable bt)
        {
            long lngRes = 0;
            bt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetItemByPayID");
            if (lngRes < 0)
            {
                return -1;
            }
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select a.paytypeid_chr, a.itemid_chr, a.qty_dec, a.register_int,
                                     a.recipeflag_int, a.expert_int, b.itemname_vchr, b.itemcode_vchr,
                                     b.itemopunit_chr, b.itemspec_vchr, b.itemprice_mny,
                                     case
                                        when b.isrich_int = 1
                                           then '是'
                                        when b.isrich_int = 0
                                           then '否'
                                     end as strisrich,
                                     case
                                        when b.itemcatid_chr = '0002'
                                           then '中药'
                                        when b.itemcatid_chr = '0003'
                                           then '检验'
                                        when b.itemcatid_chr = '0004'
                                           then '治疗'
                                        when b.itemcatid_chr = '0005'
                                           then '其它'
                                        when b.itemcatid_chr = '0006'
                                           then '手术'
                                        when b.itemcatid_chr = '0001'
                                           then '西药'
                                     end as itemtype,
                                     case
                                        when register_int = 0
                                           then '全部'
                                        when register_int = 1
                                           then '已挂号'
                                        else '未挂号'
                                     end as register,
                                     case
                                        when recipeflag_int = 0
                                           then '全部'
                                        when recipeflag_int = 1
                                           then '正方'
                                        else '副方'
                                     end as recipeflag,
                                     case
                                        when expert_int = 0
                                           then '全部'
                                        when expert_int = 1
                                           then '专家'
                                        else '普通'
                                     end as expert
                                from t_aid_chargepaytype a, t_bse_chargeitem b
                               where a.paytypeid_chr = ? and a.itemid_chr = b.itemid_chr";
            //往表增加记录
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strPayTypeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref bt, objParamArr);
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

        #region  检查当前登陆的用户是否有编辑公用处方的权限
        /// <summary>
        /// 检查当前登陆的用户是否有编辑公用处方的权限
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strID">用户ID</param>
        /// <param name="isPublic">false-没有权限,true-有权限</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPublic(System.Security.Principal.IPrincipal p_objPrincipal, string strID, out bool isPublic)
        {
            isPublic = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetPublic");
            if (lngRes < 0)
            {
                return -1;
            }
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select b.roleid_chr, b.name_vchr, b.desc_vchr, b.deptid_chr
                                from t_sys_emprolemap a, t_sys_role b
                               where a.roleid_chr = b.roleid_chr
                                 and a.empid_chr = ?
                                 and b.name_vchr = '编辑公用协定处方'";
            DataTable bt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref bt, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (bt.Rows.Count > 0 && bt.Rows[0]["NAME_VCHR"].ToString() == "编辑公用协定处方")
            {
                isPublic = true;
            }
            return lngRes;
        }
        #endregion

        #region 根据员工ID取出处方
        [AutoComplete]
        public long m_lngGetConcertreCipeByEmpID(System.Security.Principal.IPrincipal p_objPrincipal, string strEmptID, out clsConcertrectpe_VO[] p_objResultArr)
        {
            p_objResultArr = new clsConcertrectpe_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeByEmpID");
            if (lngRes < 0)
            {
                return -1;
            }
            //			string strSQL = @"SELECT a.*,b.LASTNAME_VCHR FROM T_AID_CONCERTRECIPE a,T_BSE_EMPLOYEE b WHERE a.CREATERID_CHR=b.EMPID_CHR and a.CREATERID_CHR='"+strEmptID+@"'
            //								union all
            //								select a.*,d.LASTNAME_VCHR from T_AID_CONCERTRECIPE a,T_AID_CONCERTRECIPEDEPT b,T_BSE_DEPTEMP c,T_BSE_EMPLOYEE d
            //								where a.RECIPEID_CHR=b.RECIPEID_CHR(+) and b.DEPTID_CHR=c.DEPTID_CHR(+) and c.EMPID_CHR='"+strEmptID+"' and c.EMPID_CHR=d.EMPID_CHR(+)";
            string strSQL = @"select a.recipeid_chr, a.recipename_chr, a.privilege_int, a.usercode_chr,
                                     a.wbcode_chr, a.pycode_chr, a.status_int, a.createrid_chr, a.flag_int,
                                     a.diseasename_vchr, b.lastname_vchr
                                from t_aid_concertrecipe a, t_bse_employee b
                               where a.createrid_chr = b.empid_chr
                                 and a.privilege_int = 0
                                 and a.status_int = 1
                              union
                              select a.recipeid_chr, a.recipename_chr, a.privilege_int, a.usercode_chr,
                                     a.wbcode_chr, a.pycode_chr, a.status_int, a.createrid_chr, a.flag_int,
                                     a.diseasename_vchr, b.lastname_vchr
                                from t_aid_concertrecipe a, t_bse_employee b
                               where a.createrid_chr = b.empid_chr
                                 and a.privilege_int = 1
                                 and a.createrid_chr = ?
                                 and a.status_int = 1
                              union
                              select aa.recipeid_chr, aa.recipename_chr, aa.privilege_int, aa.usercode_chr,
                                     aa.wbcode_chr, aa.pycode_chr, aa.status_int, aa.createrid_chr,
                                     aa.flag_int, aa.diseasename_vchr, cc.lastname_vchr
                                from t_aid_concertrecipe aa,
                                     (select a.recipeid_chr
                                        from t_aid_concertrecipedept a
                                       where a.deptid_chr in (select deptid_chr
                                                                from t_bse_deptemp
                                                               where empid_chr = ?)) bb,
                                     t_bse_employee cc
                               where aa.recipeid_chr(+) = bb.recipeid_chr
                                 and aa.createrid_chr = cc.empid_chr
                                 and aa.privilege_int = 2
                                 and aa.status_int = 1";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strEmptID;
                objParamArr[1].Value = strEmptID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsConcertrectpe_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsConcertrectpe_VO();
                        p_objResultArr[i1].m_strRECIPEID_CHR = dtbResult.Rows[i1]["RECIPEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strRECIPENAME_CHR = dtbResult.Rows[i1]["RECIPENAME_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intPRIVILEGE_INT = Convert.ToInt32(dtbResult.Rows[i1]["PRIVILEGE_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strUSERCODE_CHR = dtbResult.Rows[i1]["USERCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strWBCODE_CHR = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPYCODE_CHR = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strCREATERID_CHR = dtbResult.Rows[i1]["CREATERID_CHR"].ToString().Trim();
                        p_objResultArr[i1].clsEmployee_VO.m_strLASTNAME_VCHR = dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString().Trim();
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

        #region 根据处方ID取出处方明细
        [AutoComplete]
        public long m_lngGetConcertreCipeDetailByID(System.Security.Principal.IPrincipal p_objPrincipal, string strID, out clsConcertrecipeDetail_VO[] p_objResultArr)
        {
            p_objResultArr = new clsConcertrecipeDetail_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeDetailByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.recipeid_chr, a.detailid_chr, a.itemid_chr, a.qty_dec, a.freqid_chr,
                                     a.dosetype_chr, a.dosageqty_dec, a.days_int, a.rowno_chr,
                                     a.partortype_vchr, a.flag_int, a.partortypename_vchr, a.sort_int,
                                     b.itemname_vchr, b.itemcatid_chr, b.itemspec_vchr, b.itemopunit_chr,
                                     b.itemprice_mny, d.usagename_vchr, e.freqname_chr
                                from t_aid_concertrecipedetail a,
                                     t_bse_chargeitem b,
                                     t_aid_concertrecipe c,
                                     t_bse_usagetype d,
                                     t_aid_recipefreq e
                               where a.dosetype_chr = d.usageid_chr(+)
                                 and a.freqid_chr = e.freqid_chr(+)
                                 and a.itemid_chr = b.itemid_chr
                                 and a.recipeid_chr = c.recipeid_chr
                                 and c.createrid_chr = ?";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult,objParamArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsConcertrecipeDetail_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsConcertrecipeDetail_VO();
                        p_objResultArr[i1].m_strRECIPEID_CHR = dtbResult.Rows[i1]["RECIPEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDETAILID_CHR = dtbResult.Rows[i1]["DETAILID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strITEMID_CHR = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strQTY_DEC = dtbResult.Rows[i1]["QTY_DEC"].ToString().Trim();
                        p_objResultArr[i1].m_strUsageID = dtbResult.Rows[i1]["DOSETYPE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strUsageName = dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strFrequencyID = dtbResult.Rows[i1]["FREQID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strFrequencyName = dtbResult.Rows[i1]["FREQNAME_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_clsChargeItem_VO.m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_clsChargeItem_VO.m_strINSURANCEID_CHR = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_clsChargeItem_VO.m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_clsChargeItem_VO.m_strItemCode = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_clsChargeItem_VO.m_fltItemPrice = float.Parse(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
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

        #region 取出部门处方
        [AutoComplete]
        public long m_lngGetConcertreCipeDeptByID(System.Security.Principal.IPrincipal p_objPrincipal, string strReciptID, out clsConcertrecipeDept_VO[] p_objResultArr)
        {
            p_objResultArr = new clsConcertrecipeDept_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetConcertreCipeDeptByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.recipeid_chr, deptid_chr, c.deptname_vchr
                                from t_aid_concertrecipedept a, t_aid_concertrecipe b, t_bse_deptdesc c
                               where a.deptid_chr = c.deptid_chr
                                 and a.recipeid_chr = b.recipeid_chr
                                 and b.createrid_chr = ?";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strReciptID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsConcertrecipeDept_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsConcertrecipeDept_VO();
                        p_objResultArr[i1].m_strRECIPEID_CHR = dtbResult.Rows[i1]["RECIPEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDEPTID_CHR = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_clsDepart_VO.m_strDEPTNAME_VCHR = dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
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

    }
    /// <summary>
    /// 发票查询系统
    /// </summary>
    public class clsChargeCheckSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsChargeCheckSvc()
        {
        }

        #region 查询发票数据
        /// <summary>
        /// 根据时间段获取发票数据
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strDateStart"></param>
        /// <param name="strDateEnd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByDate(System.Security.Principal.IPrincipal objPri, string strDateStart, string strDateEnd, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByDate");
            if (lngRes < 0)
                return lngRes;
            //string strSQL = @"select d.PATIENTCARDID_CHR,a.INVOICENO_VCHR ,a.SEQID_CHR,c.PAYTYPENAME_VCHR as internalType,a.PATIENTNAME_CHR,b.SEX_CHR,case when a.PAYTYPE_INT=0 then '现金' when a.PAYTYPE_INT=1 then '银行卡' when a.PAYTYPE_INT=2 then '支票' when a.PAYTYPE_INT=3 then 'IC卡'  end as PAYTYPEName,a.INVDATE_DAT,case when a.STATUS_INT=1 then '正常' when a.STATUS_INT=2 then '退票' when a.STATUS_INT=3 then '恢复' end as STATUSNAME, a.DEPTNAME_CHR,h.LASTNAME_VCHR as DOCTORNAME_CHR,case when a.BALANCEFLAG_INT=0 then '未结帐 ' when a.BALANCEFLAG_INT=1 then '已结帐' end as BALANCEName,a.RECORDDATE_DAT,e.EMPNO_CHR as OPREMP_CHR,f.EMPNO_CHR as BALANCEEMP_CHR,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY ,a.OUTPATRECIPEID_CHR,a.SEQID_CHR ,b.employer_vchr from t_opr_outpatientrecipeinv a ,T_BSE_PATIENT b,t_bse_patientpaytype c,T_BSE_PATIENTCARD d,t_bse_employee e,t_bse_employee f ,t_bse_employee h where a.RECORDDATE_DAT  between to_date('" + strDateStart + " 00:00:00'" + ",'yyyy-mm-dd hh24:mi:ss') and to_date('" + strDateEnd + " 23:59:59'" + ",'yyyy-mm-dd hh24:mi:ss') and a.PATIENTID_CHR=b.PATIENTID_CHR and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.PATIENTID_CHR=d.PATIENTID_CHR and a.OPREMP_CHR=e.EMPID_CHR and a.BALANCEEMP_CHR=f.EMPID_CHR(+) and a.DOCTORID_CHR=h.EMPID_CHR";
            string strSQL = @"select d.patientcardid_chr, a.invoiceno_vchr, a.seqid_chr,
                                     c.paytypename_vchr as internaltype, a.patientname_chr, b.sex_chr,
                                     case
                                        when a.paytype_int = 0
                                          then '现金'
                                        when a.paytype_int = 1
                                           then '银行卡'
                                        when a.paytype_int = 2
                                           then '支票'
                                        when a.paytype_int = 3
                                           then 'IC卡'
                                     end as paytypename,
                                     a.invdate_dat,
                                     case
                                        when a.status_int = 1
                                           then '正常'
                                        when a.status_int = 2
                                           then '退票'
                                        when a.status_int = 3
                                           then '恢复'
                                     end as statusname,
                                     a.deptname_chr, h.lastname_vchr as doctorname_chr,
                                     case
                                        when a.balanceflag_int = 0
                                           then '未结帐 '
                                        when a.balanceflag_int = 1
                                           then '已结帐'
                                     end as balancename,
                                     a.recorddate_dat, e.empno_chr as opremp_chr,
                                     f.empno_chr as balanceemp_chr, a.acctsum_mny, a.sbsum_mny,
                                     a.totalsum_mny, a.outpatrecipeid_chr, a.seqid_chr, b.employer_vchr
                                from t_opr_outpatientrecipeinv a,
                                     t_bse_patient b,
                                     t_bse_patientpaytype c,
                                     t_bse_patientcard d,
                                     t_bse_employee e,
                                     t_bse_employee f,
                                     t_bse_employee h
                               where a.recorddate_dat between to_date (?,
                                                                       'yyyy-mm-dd hh24:mi:ss'
                                                                      )
                                                          and to_date (?,
                                                                       'yyyy-mm-dd hh24:mi:ss'
                                                                      )
                                 and a.patientid_chr = b.patientid_chr
                                 and a.paytypeid_chr = c.paytypeid_chr
                                 and a.patientid_chr = d.patientid_chr
                                 and a.opremp_chr = e.empid_chr
                                 and a.balanceemp_chr = f.empid_chr(+)
                                 and a.doctorid_chr = h.empid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                HRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strDateStart + " 00:00:00";
                objParamArr[1].Value = strDateEnd + " 23:59:59";
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
                HRPSvc.Dispose();
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
        /// 根据查找字段跟查询内容获取发票数据  add by liuyingrui
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="m_strArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByCondition(System.Security.Principal.IPrincipal objPri, string[] m_strArr, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByCondition");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select d.PATIENTCARDID_CHR,a.INVOICENO_VCHR ,a.SEQID_CHR,c.PAYTYPENAME_VCHR as internalType,a.PATIENTNAME_CHR,b.SEX_CHR,case when a.PAYTYPE_INT=0 then '现金' 
                            when a.PAYTYPE_INT=1 then '银行卡' when a.PAYTYPE_INT=2 then '支票' when a.PAYTYPE_INT=3 then 'IC卡'  end as PAYTYPEName,a.INVDATE_DAT,case when a.STATUS_INT=1 then '正常' when a.STATUS_INT=2 then '退票' 
                           when a.STATUS_INT=3 then '恢复' end as STATUSNAME, a.DEPTNAME_CHR,h.LASTNAME_VCHR as DOCTORNAME_CHR,case when a.BALANCEFLAG_INT=0 then '未结帐 ' 
                           when a.BALANCEFLAG_INT=1 then '已结帐' end as BALANCEName,a.RECORDDATE_DAT,e.EMPNO_CHR as OPREMP_CHR,f.EMPNO_CHR as BALANCEEMP_CHR,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY ,a.OUTPATRECIPEID_CHR,a.SEQID_CHR ,b.employer_vchr  from t_opr_outpatientrecipeinv a ,T_BSE_PATIENT b,t_bse_patientpaytype c,T_BSE_PATIENTCARD d,t_bse_employee e,t_bse_employee f ,t_bse_employee h 
                where a.PATIENTID_CHR=b.PATIENTID_CHR and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and a.PATIENTID_CHR=d.PATIENTID_CHR and a.OPREMP_CHR=e.EMPID_CHR and a.BALANCEEMP_CHR=f.EMPID_CHR(+) and a.DOCTORID_CHR=h.EMPID_CHR ";
            try
            {

                int m_intStatus = -1;
                switch (m_strArr[0].Trim())
                {
                    case "诊疗卡号": strSQL += "and d.PATIENTCARDID_CHR='" + m_strArr[1].Trim() + "'"; break;
                    case "发票编号": strSQL += "and a.INVOICENO_VCHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "病人身份": strSQL += "and c.PAYTYPENAME_VCHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "病人名称": strSQL += "and a.PATIENTNAME_CHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "支付类型":
                        if (m_strArr[1].Trim() == "现金")
                        {
                            m_intStatus = 0;
                        }
                        else if (m_strArr[1].Trim() == "银行卡")
                        {
                            m_intStatus = 1;
                        }
                        else if (m_strArr[1].Trim() == "支票")
                        {
                            m_intStatus = 2;
                        }
                        else if (m_strArr[1].Trim() == "IC卡")
                        {
                            m_intStatus = 3;
                        }
                        strSQL += "and a.PAYTYPE_INT=" + m_intStatus + ""; break;
                    case "发票日期": strSQL += "and a.INVDATE_DAT=to_date('" + m_strArr[1].Trim() + "','yyyy-mm-dd hh24:mi:ss')"; break;
                    case "发票状态":
                        if (m_strArr[1].Trim() == "正常")
                        {
                            m_intStatus = 1;
                        }
                        else if (m_strArr[1].Trim() == "退票")
                        {
                            m_intStatus = 2;
                        }
                        else if (m_strArr[1].Trim() == "恢复")
                        {
                            m_intStatus = 3;
                        }
                        strSQL += "and a.STATUS_INT=" + m_intStatus + ""; break;
                    case "科室名称": strSQL += "and a.DEPTNAME_CHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "医生名称": strSQL += "and h.LASTNAME_VCHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "缴费状态":
                        if (m_strArr[1].Trim() == "未结帐")
                        {
                            m_intStatus = 0;
                        }
                        else if (m_strArr[1].Trim() == "已结帐")
                        {
                            m_intStatus = 1;
                        }
                        strSQL += "and a.BALANCEFLAG_INT=" + m_intStatus + ""; break;
                    case "收费员": strSQL += "and e.EMPNO_CHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "结帐员": strSQL += "and f.EMPNO_CHR like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "记录时间": strSQL += "and a.RECORDDATE_DAT between to_date('" + m_strArr[1] + " 00:00:00'" + ",'yyyy-mm-dd hh24:mi:ss') and to_date('" + m_strArr[1] + " 23:59:59'" + ",'yyyy-mm-dd hh24:mi:ss') "; break;
                    default: break;

                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();

                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
        /// 根据查找字段跟查询内容已经操作员(收费员ID)获取发票数据  add by liuyingrui
        /// 启用方法 (2007-09-27)  modify by baojian.mo
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="m_strArr"></param>
        /// <param name="m_strEmpID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByEmpID(System.Security.Principal.IPrincipal objPri, string[] m_strArr, string m_strEmpID, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByEmpID");
            if (lngRes < 0)
                return lngRes;
//            string strSQL = @"select d.PATIENTCARDID_CHR,a.INVOICENO_VCHR ,a.SEQID_CHR,
//                                     c.PAYTYPENAME_VCHR as internalType,a.PATIENTNAME_CHR,
//                                     b.SEX_CHR,case when a.PAYTYPE_INT=0 then '现金' when a.PAYTYPE_INT=1 then '银行卡' when a.PAYTYPE_INT=2 then '支票' when a.PAYTYPE_INT=3 then 'IC卡'  end as PAYTYPEName,
//                                     a.INVDATE_DAT,case when a.STATUS_INT=1 then '正常' when a.STATUS_INT=2 then '退票' when a.STATUS_INT=3 then '恢复' end as STATUSNAME, 
//                                     a.DEPTNAME_CHR,h.LASTNAME_VCHR as DOCTORNAME_CHR,case when a.BALANCEFLAG_INT=0 then '未结帐 ' when a.BALANCEFLAG_INT=1 then '已结帐' end as BALANCEName,
//                                     a.RECORDDATE_DAT,e.EMPNO_CHR as OPREMP_CHR,f.EMPNO_CHR as BALANCEEMP_CHR,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY ,a.OUTPATRECIPEID_CHR,a.SEQID_CHR ,b.employer_vchr
//                                from t_opr_outpatientrecipeinv a,
//                                     T_BSE_PATIENT b,
//                                     t_bse_patientpaytype c,
//                                     T_BSE_PATIENTCARD d,
//                                     t_bse_employee e,
//                                     t_bse_employee f,
//                                     t_bse_employee h 
//                               where a.PATIENTID_CHR = b.PATIENTID_CHR
//                                 and a.PAYTYPEID_CHR = c.PAYTYPEID_CHR
//                                 and a.PATIENTID_CHR = d.PATIENTID_CHR
//                                 and a.OPREMP_CHR = e.EMPID_CHR
//                                 and a.BALANCEEMP_CHR = f.EMPID_CHR(+)
//                                 and a.DOCTORID_CHR = h.EMPID_CHR 
//                                 and (a.opremp_chr = '" + m_strEmpID + "' or a.recordemp_chr = '" + m_strEmpID + @"') ";
            string strSQL=@"select d.patientcardid_chr, a.invoiceno_vchr, a.seqid_chr,
                                   c.paytypename_vchr as internaltype, a.patientname_chr, b.sex_chr,
                                   case
                                      when a.paytype_int = 0
                                         then '现金'
                                      when a.paytype_int = 1
                                         then '银行卡'
                                      when a.paytype_int = 2
                                         then '支票'
                                      when a.paytype_int = 3
                                         then 'IC卡'
                                   end as paytypename,
                                   a.invdate_dat,
                                   case
                                      when a.status_int = 1
                                         then '正常'
                                      when a.status_int = 2
                                         then '退票'
                                      when a.status_int = 3
                                         then '恢复'
                                   end as statusname,
                                   a.deptname_chr, h.lastname_vchr as doctorname_chr,
                                   case
                                      when a.balanceflag_int = 0
                                         then '未结帐 '
                                      when a.balanceflag_int = 1
                                         then '已结帐'
                                   end as balancename,
                                   a.recorddate_dat, e.empno_chr as opremp_chr,
                                   f.empno_chr as balanceemp_chr, a.acctsum_mny, a.sbsum_mny,
                                   a.totalsum_mny, a.outpatrecipeid_chr, a.seqid_chr, b.employer_vchr
                              from t_opr_outpatientrecipeinv a,
                                   t_bse_patient b,
                                   t_bse_patientpaytype c,
                                   t_bse_patientcard d,
                                   t_bse_employee e,
                                   t_bse_employee f,
                                   t_bse_employee h
                             where a.patientid_chr = b.patientid_chr
                               and a.paytypeid_chr = c.paytypeid_chr
                               and a.patientid_chr = d.patientid_chr
                               and a.opremp_chr = e.empid_chr
                               and a.balanceemp_chr = f.empid_chr(+)
                               and a.doctorid_chr = h.empid_chr
                               and (   a.opremp_chr = ?
                                    or a.recordemp_chr = ?
                                   ) ";

            try
            {                
                ArrayList arrParam = new ArrayList();
                arrParam.Add(m_strEmpID);
                arrParam.Add(m_strEmpID);
                int m_intStatus = -1;
                switch (m_strArr[0].Trim())
                {
                    case "诊疗卡号": strSQL += "and d.PATIENTCARDID_CHR= ?"; arrParam.Add(m_strArr[1].Trim()); break;
                    case "发票编号": strSQL += "and a.INVOICENO_VCHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "病人身份": strSQL += "and c.PAYTYPENAME_VCHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "病人名称": strSQL += "and a.PATIENTNAME_CHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "支付类型":
                        if (m_strArr[1].Trim() == "现金")
                        {
                            m_intStatus = 0;
                        }
                        else if (m_strArr[1].Trim() == "银行卡")
                        {
                            m_intStatus = 1;
                        }
                        else if (m_strArr[1].Trim() == "支票")
                        {
                            m_intStatus = 2;
                        }
                        else if (m_strArr[1].Trim() == "IC卡")
                        {
                            m_intStatus = 3;
                        }
                        strSQL += "and a.PAYTYPE_INT=? "; arrParam.Add(m_intStatus); break;
                    case "发票日期": strSQL += "and a.INVDATE_DAT=to_date(?,'yyyy-mm-dd hh24:mi:ss')"; arrParam.Add(m_strArr[1].Trim()); break;
                    case "发票状态":
                        if (m_strArr[1].Trim() == "正常")
                        {
                            m_intStatus = 1;
                        }
                        else if (m_strArr[1].Trim() == "退票")
                        {
                            m_intStatus = 2;
                        }
                        else if (m_strArr[1].Trim() == "恢复")
                        {
                            m_intStatus = 3;
                        }
                        strSQL += "and a.STATUS_INT=?"; arrParam.Add(m_intStatus); break;
                    case "科室名称": strSQL += "and a.DEPTNAME_CHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "医生名称": strSQL += "and h.LASTNAME_VCHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "缴费状态":
                        if (m_strArr[1].Trim() == "未结帐")
                        {
                            m_intStatus = 0;
                        }
                        else if (m_strArr[1].Trim() == "已结帐")
                        {
                            m_intStatus = 1;
                        }
                        strSQL += "and a.BALANCEFLAG_INT=?"; arrParam.Add(m_intStatus); break;
                    case "收费员": strSQL += "and e.EMPNO_CHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "结帐员": strSQL += "and f.EMPNO_CHR like ?"; arrParam.Add("%" + m_strArr[1].Trim() + "%"); break;
                    case "记录时间": strSQL += "and a.RECORDDATE_DAT between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') "; arrParam.Add(m_strArr[1] + " 00:00:00"); arrParam.Add(m_strArr[1] + " 23:59:59"); break;
                    default: break;

                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr=null;
                HRPSvc.CreateDatabaseParameter(arrParam.Count, out objParamArr);
                for (int i2 = 0; i2 < arrParam.Count; i2++)
                {
                    objParamArr[i2].Value = arrParam[i2];
                }

                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
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
        /// 根据操作员(收费员)ID及时间段查询发票信息
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="empid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByempid(System.Security.Principal.IPrincipal objPri, string strDateStart, string strDateEnd, string empid, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByempid");
            if (lngRes < 0)
            {
                return lngRes;
            }

//            string strSQL = @"select d.PATIENTCARDID_CHR,a.INVOICENO_VCHR ,a.SEQID_CHR,
//                                     c.PAYTYPENAME_VCHR as internalType,a.PATIENTNAME_CHR,
//                                     b.SEX_CHR,case when a.PAYTYPE_INT=0 then '现金' when a.PAYTYPE_INT=1 then '银行卡' when a.PAYTYPE_INT=2 then '支票' when a.PAYTYPE_INT=3 then 'IC卡'  end as PAYTYPEName,
//                                     a.INVDATE_DAT,case when a.STATUS_INT=1 then '正常' when a.STATUS_INT=2 then '退票' when a.STATUS_INT=3 then '恢复' end as STATUSNAME, 
//                                     a.DEPTNAME_CHR,h.LASTNAME_VCHR as DOCTORNAME_CHR,case when a.BALANCEFLAG_INT=0 then '未结帐 ' when a.BALANCEFLAG_INT=1 then '已结帐' end as BALANCEName,
//                                     a.RECORDDATE_DAT,e.EMPNO_CHR as OPREMP_CHR,f.EMPNO_CHR as BALANCEEMP_CHR,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY ,a.OUTPATRECIPEID_CHR,a.SEQID_CHR ,b.employer_vchr
//                                from t_opr_outpatientrecipeinv a,
//                                     T_BSE_PATIENT b,
//                                     t_bse_patientpaytype c,
//                                     T_BSE_PATIENTCARD d,
//                                     t_bse_employee e,
//                                     t_bse_employee f,
//                                     t_bse_employee h 
//                               where a.PATIENTID_CHR = b.PATIENTID_CHR
//                                 and a.PAYTYPEID_CHR = c.PAYTYPEID_CHR
//                                 and a.PATIENTID_CHR = d.PATIENTID_CHR
//                                 and a.OPREMP_CHR = e.EMPID_CHR
//                                 and a.BALANCEEMP_CHR = f.EMPID_CHR(+)
//                                 and a.DOCTORID_CHR = h.EMPID_CHR 
//                                 and (a.opremp_chr = '" + empid + "' or a.recordemp_chr = '" + empid + @"')
//                                 and a.RECORDDATE_DAT between to_date('" + strDateStart + " 00:00:00'" + ",'yyyy-mm-dd hh24:mi:ss') and to_date('" + strDateEnd + " 23:59:59'" + ",'yyyy-mm-dd hh24:mi:ss')";
            string strSQL = @"select d.patientcardid_chr, a.invoiceno_vchr, a.seqid_chr,
                                     c.paytypename_vchr as internaltype, a.patientname_chr, b.sex_chr,
                                     case
                                        when a.paytype_int = 0
                                           then '现金'
                                        when a.paytype_int = 1
                                           then '银行卡'
                                        when a.paytype_int = 2
                                           then '支票'
                                         when a.paytype_int = 3
                                           then 'IC卡'
                                     end as paytypename,
                                     a.invdate_dat,
                                     case
                                        when a.status_int = 1
                                           then '正常'
                                        when a.status_int = 2
                                           then '退票'
                                        when a.status_int = 3
                                           then '恢复'
                                     end as statusname,
                                     a.deptname_chr, h.lastname_vchr as doctorname_chr,
                                     case
                                        when a.balanceflag_int = 0
                                           then '未结帐 '
                                        when a.balanceflag_int = 1
                                           then '已结帐'
                                     end as balancename,
                                     a.recorddate_dat, e.empno_chr as opremp_chr,
                                     f.empno_chr as balanceemp_chr, a.acctsum_mny, a.sbsum_mny,
                                     a.totalsum_mny, a.outpatrecipeid_chr, a.seqid_chr, b.employer_vchr
                                from t_opr_outpatientrecipeinv a,
                                     t_bse_patient b,
                                     t_bse_patientpaytype c,
                                     t_bse_patientcard d,
                                     t_bse_employee e,
                                     t_bse_employee f,
                                     t_bse_employee h
                               where a.patientid_chr = b.patientid_chr
                                 and a.paytypeid_chr = c.paytypeid_chr
                                 and a.patientid_chr = d.patientid_chr
                                 and a.opremp_chr = e.empid_chr
                                 and a.balanceemp_chr = f.empid_chr(+)
                                 and a.doctorid_chr = h.empid_chr
                                 and (a.opremp_chr = ? or a.recordemp_chr = ?)
                                 and a.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                          and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                HRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = empid;
                objParamArr[1].Value = empid;
                objParamArr[2].Value = strDateStart + " 00:00:00";
                objParamArr[3].Value = strDateEnd + " 23:59:59";
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
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

        #region 修改发票的收费类型
        #region 新增明细
        [AutoComplete]
        public long m_lngModifiyType(System.Security.Principal.IPrincipal p_objPrincipal, string strType, string strINVOICENO, string strSEQID, string modifiyMan)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngModifiyType");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "update t_opr_outpatientrecipeinv set PAYTYPE_INT=" + strType + " where INVOICENO_VCHR='" + strINVOICENO + "' and SEQID_CHR='" + strSEQID + "'";
            try
            {
                #region 写入痕迹记录
                clsRecordMark_VO Markvo = new clsRecordMark_VO();
                clsRecordMark recordMark = new clsRecordMark();
                Markvo.m_strOPERATORID_CHR = modifiyMan;
                Markvo.m_strTABLESEQID_CHR = "1";
                Markvo.m_strRECORDDETAIL_VCHR = strSQL;
                recordMark.m_mthAddNewRecord(Markvo);
                #endregion
                lngRes = objHRPSvc.DoExcute(strSQL);

                strSQL = "update t_opr_payment set paytype_int = " + strType + " where chargeno_vchr = '" + strSEQID + "'";
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 获取配置信息
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="blIS">当配置 0--否 1--是时，false 否，true 是；当配置 1--否 0--是时，false 是，true 否</param>
        /// <param name="strsetid">配置ID号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCollocate(System.Security.Principal.IPrincipal p_objPrincipal, out bool blIS, string strsetid)
        {
            long lngRes = 0;
            blIS = false;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetCollocate");
            if (lngRes < 0)
            {
                return -1;
            }
           // com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select setstatus_int
                              from t_sys_setting
                              where setid_chr = ?";
            DataTable dt = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = strsetid;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString()) == 1)
            {
                blIS = true;
            }
            return lngRes;
        }

        #endregion
        /// <summary>
        /// 根据处方号获取处方明细
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="recipeNO">处方号</param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeDate(System.Security.Principal.IPrincipal objPri, string recipeNO, out DataTable dt,out DataTable m_objAccountTable)
        {
            dt = new DataTable();
            m_objAccountTable = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetRecipeDate");
            if (lngRes < 0)
                return lngRes;            
            DataTable dtTemp = new DataTable();
            IDataParameter[] objParamArr = null;

            #region 表1
            string strSQLNew = @"select d.itemcode_vchr, d.itemopcode_chr, d.name, d.dec, d.count, d.price,
                                        d.pdcarea_vchr, d.uint, c.doctorname_chr, c.sbsum_mny, c.acctsum_mny,
                                        e.lastname_vchr
                                   from t_opr_outpatientrecipeinv c,
                                        (select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                                a.unitid_chr uint, a.itemspec_vchr dec, a.tolqty_dec count,
                                                b.pdcarea_vchr, a.unitprice_mny price, b.itemcode_vchr,
                                                b.itemopcode_chr
                                           from t_opr_outpatientpwmrecipede a, t_bse_chargeitem b
                                          where a.itemid_chr = b.itemid_chr(+)) d,
                                        t_bse_employee e
                                  where c.opremp_chr = e.empid_chr(+) and c.outpatrecipeid_chr = d.id(+)
                                        and c.seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = recipeNO;
                objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dtTemp, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            dt = dtTemp.Clone();
            dt.BeginLoadData();
            for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
            {
                dt.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
            }
            dt.EndLoadData();                    
            #endregion            

            #region 表2
            strSQLNew = @"select d.itemcode_vchr, d.itemopcode_chr, d.name, d.dec, d.count, d.price,
                                 d.pdcarea_vchr, d.uint, c.doctorname_chr, c.sbsum_mny, c.acctsum_mny,
                                 e.lastname_vchr
                            from t_opr_outpatientrecipeinv c,
                                 (select a.outpatrecipeid_chr id, b.itemname_vchr name,
                                         a.unitid_chr uint, a.itemspec_vchr dec,
                                         a.qty_dec * a.times_int count, b.pdcarea_vchr,
                                         a.unitprice_mny price, b.itemcode_vchr, b.itemopcode_chr
                                    from t_opr_outpatientcmrecipede a, t_bse_chargeitem b
                                   where a.itemid_chr = b.itemid_chr(+)) d,
                                 t_bse_employee e
                           where c.opremp_chr = e.empid_chr(+) and c.outpatrecipeid_chr = d.id(+)
                                 and c.seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = recipeNO;
                objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dtTemp, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            dt.BeginLoadData();
            for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
            {
                dt.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
            }
            dt.EndLoadData();            
            #endregion

            #region 表3
            strSQLNew = @"select d.itemcode_vchr, d.itemopcode_chr, d.name, d.dec, d.count, d.price,
                                 d.pdcarea_vchr, d.uint, c.doctorname_chr, c.sbsum_mny, c.acctsum_mny,
                                 e.lastname_vchr
                            from t_opr_outpatientrecipeinv c,
                                 (select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                         b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                         b.pdcarea_vchr, a.price_mny price, b.itemcode_vchr,
                                         b.itemopcode_chr
                                    from t_opr_outpatientchkrecipede a, t_bse_chargeitem b
                                   where a.itemid_chr = b.itemid_chr(+)) d,
                                 t_bse_employee e
                           where c.opremp_chr = e.empid_chr(+) and c.outpatrecipeid_chr = d.id(+)
                                 and c.seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = recipeNO;
                objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dtTemp, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            dt.BeginLoadData();
            for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
            {
                dt.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
            }
            dt.EndLoadData();            
            #endregion

            #region 表4
            strSQLNew = @"select d.itemcode_vchr, d.itemopcode_chr, d.name, d.dec, d.count, d.price,
                                 d.pdcarea_vchr, d.uint, c.doctorname_chr, c.sbsum_mny, c.acctsum_mny,
                                 e.lastname_vchr
                            from t_opr_outpatientrecipeinv c,
                                 (select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                         b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                         b.pdcarea_vchr, a.price_mny price, b.itemcode_vchr,
                                         b.itemopcode_chr
                                    from t_opr_outpatienttestrecipede a, t_bse_chargeitem b
                                   where a.itemid_chr = b.itemid_chr(+)) d,
                                 t_bse_employee e
                           where c.opremp_chr = e.empid_chr(+) and c.outpatrecipeid_chr = d.id(+)
                                 and c.seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = recipeNO;
                objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dtTemp, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            dt.BeginLoadData();
            for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
            {
                dt.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
            }
            dt.EndLoadData();            
            #endregion

            #region 表5
            strSQLNew = @"select d.itemcode_vchr, d.itemopcode_chr, d.name, d.dec, d.count, d.price,
                                 d.pdcarea_vchr, d.uint, c.doctorname_chr, c.sbsum_mny, c.acctsum_mny,
                                 e.lastname_vchr
                            from t_opr_outpatientrecipeinv c,
                                 (select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                         b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                         b.pdcarea_vchr, a.price_mny price, b.itemcode_vchr,
                                         b.itemopcode_chr
                                    from t_opr_outpatientopsrecipede a, t_bse_chargeitem b
                                   where a.itemid_chr = b.itemid_chr(+)) d,
                                 t_bse_employee e
                           where c.opremp_chr = e.empid_chr(+) and c.outpatrecipeid_chr = d.id(+)
                                 and c.seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = recipeNO;
                objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dtTemp, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            dt.BeginLoadData();
            for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
            {
                dt.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
            }
            dt.EndLoadData();
            #endregion

            #region 表6
            strSQLNew = @"select d.itemcode_vchr, d.itemopcode_chr, d.name, d.dec, d.count, d.price,
                                 d.pdcarea_vchr, d.uint, c.doctorname_chr, c.sbsum_mny, c.acctsum_mny,
                                 e.lastname_vchr
                            from t_opr_outpatientrecipeinv c,
                                 (select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                         a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                         b.pdcarea_vchr, a.unitprice_mny price, b.itemcode_vchr,
                                         b.itemopcode_chr
                                    from t_opr_outpatientothrecipede a, t_bse_chargeitem b
                                   where a.itemid_chr = b.itemid_chr(+)) d,
                                 t_bse_employee e
                           where c.opremp_chr = e.empid_chr(+) and c.outpatrecipeid_chr = d.id(+)
                                 and c.seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = recipeNO;
                objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dtTemp, objParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            dt.BeginLoadData();
            for (int i1 = 0; i1 < dtTemp.Rows.Count; i1++)
            {
                dt.LoadDataRow(dtTemp.Rows[i1].ItemArray, true);
            }
            dt.EndLoadData();
            dt.AcceptChanges();
            for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i1]["itemcode_vchr"].ToString()))
                {
                    dt.Rows[i1].Delete();
                    i1--;
                    dt.AcceptChanges();
                }
            }
            dt.AcceptChanges();
            #endregion

//            string strSQLNew = @"SELECT d.itemcode_vchr,d.itemopcode_chr, d.NAME, d.DEC, d.COUNT, d.price, d.pdcarea_vchr, d.uint,
//       c.doctorname_chr, c.sbsum_mny, c.acctsum_mny, e.lastname_vchr
//       FROM t_opr_outpatientrecipeinv c,
//       (SELECT a.outpatrecipeid_chr ID, a.itemname_vchr NAME,
//               a.unitid_chr uint, a.itemspec_vchr DEC, a.tolqty_dec COUNT,
//               b.pdcarea_vchr, a.unitprice_mny price,b.itemcode_vchr,b.itemopcode_chr
//          FROM t_opr_outpatientpwmrecipede a, t_bse_chargeitem b
//         WHERE a.itemid_chr = b.itemid_chr(+)
//        UNION ALL
//        SELECT a.outpatrecipeid_chr ID, b.itemname_vchr NAME,
//               a.unitid_chr uint, a.itemspec_vchr DEC,
//               a.qty_dec * a.times_int COUNT, b.pdcarea_vchr,
//               a.unitprice_mny price,b.itemcode_vchr,b.itemopcode_chr
//          FROM t_opr_outpatientcmrecipede a, t_bse_chargeitem b
//         WHERE a.itemid_chr = b.itemid_chr(+)
//        UNION ALL
//        SELECT a.outpatrecipeid_chr ID, a.itemname_vchr NAME,
//               b.itemunit_chr uint, a.itemspec_vchr DEC, a.qty_dec COUNT,
//               b.pdcarea_vchr, a.price_mny price,b.itemcode_vchr,b.itemopcode_chr
//          FROM t_opr_outpatientchkrecipede a, t_bse_chargeitem b
//         WHERE a.itemid_chr = b.itemid_chr(+)
//        UNION ALL
//        SELECT a.outpatrecipeid_chr ID, a.itemname_vchr NAME,
//               b.itemunit_chr uint, a.itemspec_vchr DEC, a.qty_dec COUNT,
//               b.pdcarea_vchr, a.price_mny price,b.itemcode_vchr,b.itemopcode_chr
//          FROM t_opr_outpatienttestrecipede a, t_bse_chargeitem b
//         WHERE a.itemid_chr = b.itemid_chr(+)
//        UNION ALL
//        SELECT a.outpatrecipeid_chr ID, a.itemname_vchr NAME,
//               b.itemunit_chr uint, a.itemspec_vchr DEC, a.qty_dec COUNT,
//               b.pdcarea_vchr, a.price_mny price,b.itemcode_vchr,b.itemopcode_chr
//          FROM t_opr_outpatientopsrecipede a, t_bse_chargeitem b
//         WHERE a.itemid_chr = b.itemid_chr(+)
//        UNION ALL
//        SELECT a.outpatrecipeid_chr ID, a.itemname_vchr NAME,
//               a.unitid_chr uint, a.itemspec_vchr DEC, a.qty_dec COUNT,
//               b.pdcarea_vchr, a.unitprice_mny price,b.itemcode_vchr,b.itemopcode_chr
//          FROM t_opr_outpatientothrecipede a, t_bse_chargeitem b
//         WHERE a.itemid_chr = b.itemid_chr(+)) d,
//       t_bse_employee e
//   WHERE c.opremp_chr = e.empid_chr(+)
//   AND c.outpatrecipeid_chr = d.ID(+)
//   AND c.seqid_chr = ? ";
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                IDataParameter[] ParamArr = null;
//                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
//                ParamArr[0].Value = recipeNO;
//                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dt, ParamArr);
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);

//            }
            strSQLNew = @"select a.itemid_chr as itemcatid_chr, a.tolprice_mny as tolfee_mny,
                                 a.discount_dec * a.tolprice_mny as sbsum_mny,
                                 b.itemname_vchr as typename_vchr
                            from t_opr_oprecipeitemde a, t_bse_chargeitem b,
                                 t_opr_outpatientrecipeinv c
                           where c.seqid_chr = ?
                             and a.itemid_chr = b.itemid_chr
                             and a.outpatrecipeid_chr = c.outpatrecipeid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = recipeNO;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref m_objAccountTable, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            return lngRes;
        }

        #region 获取病人证号信息
        /// <summary>
        /// 获取病人证号信息
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="recipeNO">处方号</param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPatientCertificateInfo(System.Security.Principal.IPrincipal objPri, string strID, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByDate");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"SELECT   DECODE (b.internalflag_int,
               5, c.insuranceid_vchr,
               2, c.insuranceid_vchr,
               3, c.difficulty_vchr,
               ''
              ) as CertificateNo
  FROM t_opr_outpatientrecipeinv a, t_bse_patientpaytype b, t_bse_patient c
 WHERE a.paytypeid_chr = b.paytypeid_chr
   AND a.patientid_chr = c.patientid_chr(+)
   AND b.internalflag_int > 0
   and a.seqid_chr ='" + strID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
        /// 根据时间段获取发票数据
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strDateStart"></param>
        /// <param name="strDateEnd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByDate1(System.Security.Principal.IPrincipal objPri, string strDateStart, string strDateEnd, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByDate");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select d.patientcardid_chr, a.invoiceno_vchr, a.outpatrecipeid_chr,
                                     c.paytypename_vchr as internaltype, a.patientname_chr, b.sex_chr,
                                     case
                                        when a.paytype_int = 0
                                           then '现金'
                                        when a.paytype_int = 1
                                           then '刷卡'
                                        when a.paytype_int = 3
                                           then '支票'
                                     end as paytypename,
                                     a.invdate_dat, a.deptname_chr, h.lastname_vchr as doctorname_chr,
                                     e.empno_chr as opremp_chr, a.acctsum_mny, a.sbsum_mny, a.totalsum_mny,
                                     case
                                        when c.internalflag_int = 0
                                           then '自费'
                                        when c.internalflag_int = 1
                                           then '公费'
                                        when c.internalflag_int = 2
                                           then '医保'
                                        when c.internalflag_int > 2
                                           then '其它'
                                     end as patientype
                                from t_opr_outpatientrecipeinv a,
                                     t_bse_patient b,
                                     t_bse_patientpaytype c,
                                     t_bse_patientcard d,
                                     t_bse_employee e,
                                     t_bse_employee h
                               where a.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                          and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                 and a.patientid_chr = b.patientid_chr
                                 and a.paytypeid_chr = c.paytypeid_chr
                                 and a.patientid_chr = d.patientid_chr
                                 and a.opremp_chr = e.empid_chr
                                 and a.doctorid_chr = h.empid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                HRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strDateStart + " 00:00:00";
                objParamArr[1].Value = strDateEnd + " 23:59:59";
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            return lngRes;
        }

        #region 根据内部序号获取发票主记录信息
        /// <summary>
        /// 根据内部序号获取发票主记录信息
        /// </summary>
        /// <param name="seqid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByseqid(string seqid, out DataTable dtRecord)
        {
            long lngRes = 0;
            string SQL = @"select invoiceno_vchr, outpatrecipeid_chr, invdate_dat, acctsum_mny,
                                  sbsum_mny, opremp_chr, recordemp_chr, recorddate_dat, status_int,
                                  seqid_chr, balanceemp_chr, balance_dat, balanceflag_int, totalsum_mny,
                                  paytype_int, patientid_chr, patientname_chr, deptid_chr, deptname_chr,
                                  doctorid_chr, doctorname_chr, confirmemp_chr, paytypeid_chr,
                                  internalflag_int, baseseqid_chr, groupid_chr, confirmdeptid_chr,
                                  split_int
                             from t_opr_outpatientrecipeinv
                            where seqid_chr = ?";

            dtRecord = new DataTable();

            try
            {
                clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParaArr = null;
                HRPSvc.CreateDatabaseParameter(1, out objParaArr);
                objParaArr[0].Value = seqid;
                lngRes = HRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, objParaArr);
                HRPSvc.Dispose();
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
        /// 获取发票分类明细
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strINVOICENO"></param>
        /// <param name="strSEQID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeDe(System.Security.Principal.IPrincipal objPri, string strINVOICENO, string strSEQID, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeDe");
            if (lngRes < 0)
                return lngRes;
            //string strSQL = @"select b.TYPENAME_VCHR,a.TOLFEE_MNY from T_OPR_OUTPATIENTRECIPEINVDE a,t_bse_chargeitemextype b where a.INVOICENO_VCHR='" + strINVOICENO + "' and a.SEQID_CHR='" + strSEQID + "' and a.ITEMCATID_CHR=b.TYPEID_CHR and b.FLAG_INT=2";
            string strSQL = @"select b.typename_vchr, a.tolfee_mny
                                from t_opr_outpatientrecipeinvde a, t_bse_chargeitemextype b
                               where a.invoiceno_vchr = ?
                                 and a.seqid_chr = ?
                                 and a.itemcatid_chr = b.typeid_chr
                                 and b.flag_int = 2";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                HRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strINVOICENO;
                objParamArr[1].Value = strSEQID;
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            return lngRes;
        }
    }



    /// <summary>
    /// 控制收费优惠 2004-8-6 黄国平
    /// </summary>
    public class clsRegisterDetailSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsRegisterDetailSvc()
        { }
        /// <summary>
        /// 返回数据的函数
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngLoadData(System.Security.Principal.IPrincipal objPri, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngLoadData");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"select a.registertypeid_chr, a.chargeid_chr, a.paytypeid_chr, a.payment_mny,
                                     a.discount_dec, b.registertypename_vchr, c.chargename_chr,
                                     d.paytypename_vchr
                                from t_bse_registerdetail a,
                                     t_bse_registertype b,
                                     t_bse_registerchargetype c,
                                     t_bse_patientpaytype d
                               where a.registertypeid_chr = b.registertypeid_chr(+)
                                 and a.chargeid_chr = c.chargeid_chr(+)
                                 and a.paytypeid_chr = d.paytypeid_chr
                                 and b.isusing_num = 1
                                 and c.isusing_num = 1
                                 and d.isusing_num = 1
                            order by a.registertypeid_chr, a.chargeid_chr, a.paytypeid_chr";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            HRPSvc.Dispose();
            return lngRes;

        }
        [AutoComplete]
        public long m_lngSave(System.Security.Principal.IPrincipal objPri, string ID1, string ID2, string ID3, string PAYMENT_MNY, string DISCOUNT_DEC)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngSave");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"update t_bse_registerdetail
                                 set payment_mny = ?,
                                     discount_dec = ?
                               where registertypeid_chr = ? and chargeid_chr = ? and paytypeid_chr = ?";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            IDataParameter[] objParamArr = null;
            HRPSvc.CreateDatabaseParameter(5, out objParamArr);
            objParamArr[0].Value = PAYMENT_MNY;
            objParamArr[1].Value = DISCOUNT_DEC;
            objParamArr[2].Value = ID1;
            objParamArr[3].Value = ID2;
            objParamArr[4].Value = ID3;
            long lngRecff = -1;
            lngRes = HRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecff,objParamArr);
            HRPSvc.Dispose();
            return lngRes;
        }
    }
}
