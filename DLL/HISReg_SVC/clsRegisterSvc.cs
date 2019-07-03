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
namespace com.digitalwave.iCare.middletier.HIS
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
            string strSQL = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr from t_sys_setting where setid_chr ='" + p_flag + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dt = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

            if (lngRes > 0)
            {
                #region 消息处理
                com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
                try
                {
                    lngRes = objMsgUpdate.AddMsg("10001", 1, objPatienVO.m_strPATIENTID_CHR);
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
                #endregion
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
            lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_PATIENTIDX", "PATIENTID_CHR", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_BSE_PATIENTIDX (PATIENTID_CHR,INPATIENTID_CHR,IDCARD_CHR,HOMEADDRESS_VCHR,SEX_CHR,BIRTH_DAT,NAME_VCHR,HOMEPHONE_VCHR,INSURANCEID_VCHR,DIFFICULTY_VCHR,GOVCARD_CHR) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
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
                strSQL = @"select PATIENTCARDID_CHR from T_BSE_PATIENTCARD where PATIENTCARDID_CHR='" + CardId + "' and STATUS_INT!=0";
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
                if (dt.Rows.Count > 0)
                {
                    return -2;
                }


            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strSQL = "insert into T_BSE_PATIENTCARD (PATIENTCARDID_CHR,PATIENTID_CHR,ISSUE_DATE,STATUS_INT) VALUES (?,?,?,?)";
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
                    long lngRes_Msg = 0;
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
                        lngRes_Msg = objSvc.DoExcute(strSQL);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }

                    #region 消息处理
                    if (lngRes_Msg > 0)
                    {
                        com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
                        try
                        {
                            lngRes = objMsgUpdate.AddMsg("10001", 2, objResult.m_strPatient);
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
                    }
                    #endregion
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
            lngRes = objSvc.m_lngGenerateNewID("t_opr_patientregister", "registerid_chr", out p_strREGISTERID);
            strSQL = @"INSERT INTO t_opr_patientregister
                           (registerid_chr, patientcardid_chr, registerdate_dat,
                            diagdept_chr, diagdoctor_chr, registeremp_chr, pstatus_int,
                            registertypeid_chr, paytypeid_chr, registerno_chr, flag_int,
                            planperiod_chr, patientid_chr, paytype_int,INVNO_CHR,bespeakDate_DAT,DATESPACE
                           )
					VALUES (?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'),?,?,?,?,?,?,?,?,?,?,?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'),?)";

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
            strSQL = @" UPDATE t_opr_opdoctorplan
					SET optimes_int = NVL (optimes_int, 0) + 1
					WHERE opdcotor_chr = ? AND plandate_dat = to_date(?,'yyyy-MM-dd') AND planperiod_chr =?";
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

            strSQL = @" UPDATE t_bse_patient
					SET optimes_int = NVL (optimes_int, 0) + 1
					WHERE patientid_chr = '" + objResult.m_strPatient + "'";
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
            #endregion

            strSQL = @"SELECT COUNT (*) as totMunber
                        FROM t_opr_opdoctorplan
                        WHERE opdcotor_chr ='" + objResult.m_objDiagDoctor.strEmpID + @"'
                              AND plandate_dat = to_date('" + date + "','yyyy-MM-dd') AND planperiod_chr ='" + objResult.m_strPiod + "'";
            try
            {
                //System.Data.IDataParameter[] paramArr = null;
                //objSvc.CreateDatabaseParameter(3, out paramArr);
                //paramArr[0].Value = objResult.m_objDiagDoctor.strEmpID;
                //paramArr[1].Value = date;
                //paramArr[2].Value = objResult.m_strPiod;
                //lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
                lngRes = objSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);

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
                strSQL = @"SELECT TO_CHAR (NVL (optimes_int, 0)) as  registercount
                         FROM t_opr_opdoctorplan
                         WHERE opdcotor_chr =?
                              AND plandate_dat = to_date(?,'yyyy-MM-dd')
                              AND planperiod_chr =?";
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
            objSvc.m_lngGenerateNewID("t_opr_waitdiaglist", "waitdiaglistid_chr", out strWaitID);
            //获取候诊号
            int strWaitNO = 1;
            //            if (objResult.m_objDiagDoctor.strEmpID != null && objResult.m_objDiagDoctor.strEmpID != "")
            //            {
            //                strSQL = @"SELECT max(order_int) as waitNO
            //                         FROM t_opr_waitdiaglist
            //                         WHERE waitdiagdr_chr = '" + objResult.m_objDiagDoctor.strEmpID + @"'
            //                               AND PSTATUS_INT=1
            //                               AND registerdate_dat = to_date('" + objResult.m_strRegisterDate + "','yyyy-mm-dd hh24:mi:ss')";
            //            }
            //            else
            //            {
            strSQL = @"SELECT max(order_int) as waitNO
				FROM t_opr_waitdiaglist
				WHERE waitdiagdept_chr =?
					AND PSTATUS_INT=1 AND registerdate_dat = to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            //}
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = objResult.m_objDiagDept.strDeptID;
                paramArr[1].Value = date;

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
                if (dt.Rows[0]["waitNO"] != System.DBNull.Value && dt.Rows[0]["waitNO"].ToString() != "0" && dt.Rows[0]["waitNO"].ToString() != "")
                {
                    strWaitNO = int.Parse(dt.Rows[0]["waitNO"].ToString()) + 1;

                }
                else
                {
                    strWaitNO = 1;
                }
            }
            else
            {
                strWaitNO = 1;
            }
            strSQL = @"INSERT INTO t_opr_waitdiaglist
               (waitdiaglistid_chr, registerid_chr, waitdiagdept_chr,
                waitdiagdr_chr, order_int, registerdate_dat,
                pstatus_int, registerop_vchr
               )
               VALUES (?,?,?,?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'),?,?)";
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
            string strSQL = "INSERT INTO t_opr_patientregdetail (REGISTERID_CHR,CHARGEID_CHR,PAYMENT_MNY,DISCOUNT_DEC) VALUES (?,?,?,?)";
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
                strSQL = "INSERT INTO t_opr_patientregdetail (REGISTERID_CHR,CHARGEID_CHR,PAYMENT_MNY,DISCOUNT_DEC) VALUES (?,?,?,?)";
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
            string strSQL = @"SELECT
                              A.REGISTERID_CHR , A.CHARGEID_CHR , A.CHARGENAME_CHR , A.PAYMENT_MNY , A.DISCOUNT_DEC
                              FROM
                              V_OPR_PATIENTREGDETAIL A where REGISTERID_CHR=? and A.CHARGEID_CHR=?";
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
                    strSQL = @"update T_OPR_PATIENTREGDETAIL A 
				    set PAYMENT_MNY =?,DISCOUNT_DEC=? where REGISTERID_CHR=? and A.CHARGEID_CHR=?";

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
							set A.PAYTYPEID_CHR=?,
								A.PATIENTCARDID_CHR =?,
								A.PATIENTID_CHR =?							
				          Where registerid_chr=?";
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

            string strSQL = "Update t_opr_patientregister  Set pstatus_int=? Where registerid_chr=? ";
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
            string strSQL = "Update t_opr_patientregister  Set flag_int=3,returnemp_chr='" + strReturnEmp + "'," +
                " returndate_dat=sysdate Where registerid_chr='" + strRegID + "'";
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

            string strSQL = @"SELECT a.patientid_chr,
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
       a.officeaddress_vchr,
       a.employer_vchr,
       a.officepc_vchr,
       a.homepc_chr,
       a.email_vchr,
       a.contactpersonfirstname_vchr,
       a.contactpersonlastname_vchr,
       a.contactpersonaddress_vchr,
       a.contactpersonphone_vchr,
       a.contactpersonpc_chr,
       a.patientrelation_vchr,
       a.firstdate_dat,
       a.isemployee_int,
       a.status_int,
       a.deactivate_dat,
       a.operatorid_chr,
       a.modify_dat,
       a.paytypeid_chr,
       a.optimes_int,
       a.govcard_chr,
       a.bloodtype_chr,
       a.ifallergic_int,
       a.allergicdesc_vchr,
       a.difficulty_vchr,
       a.extendid_vchr,
       a.inpatienttempid_vchr,
       a.modifytime_dat,
       a.modifyman_vchr,
       a.registertime_dat,
       a.registerman_vchr,
       a.patientsources_vchr, c.paytypename_vchr,c.INTERNALFLAG_INT " +//, c.discount_dec " +
                " FROM t_bse_patient a, t_bse_patientcard b, t_bse_patientpaytype c " +
                " WHERE a.patientid_chr=b.patientid_chr And " +
                " b.patientcardid_chr = '" + CardID + "' AND a.paytypeid_chr = c.paytypeid_chr(+) and b.STATUS_INT<>0 ";
            DataTable dtResult = new DataTable();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            try
            {
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
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
            strSQL = @"select a.RECORDDATE_DAT,a.REGISTERID_CHR,b.DEPTNAME_VCHR,c.LASTNAME_VCHR   from t_opr_patientregister a,T_BSE_DEPTDESC b,t_bse_employee  c where a.REGISTERDATE_DAT=to_date('" + registerDate + "','yyyy-MM-dd')  and a.PATIENTCARDID_CHR='" + CardID + "' and a.DIAGDEPT_CHR=b.DEPTID_CHR(+) and a.DIAGDOCTOR_CHR=c.EMPID_CHR(+)";
            try
            {
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
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
            string strSQL = "SELECT ISDOCTOR_NUM FROM  T_BSE_REGISTERTYPE  where REGISTERTYPENAME_VCHR='" + strTypeid + "'";
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
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
                strSQL = "select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr from t_sys_setting where setid_chr = '0063'";
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

                    strSQL = "select weekno_int, timespan_vchr from t_opr_ybtimespan where weekno_int = " + NowWeekNo;
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
                    strSQL = "select paytypeid_chr, paytypename_vchr, memo_vchr, paylimit_mny, payflag_dec, paypercent_dec, paytypeno_vchr, isusing_num, copayid_chr, chargepercent_dec, internalflag_int, coalitionrecipeflag_int, bihlimitrate_dec from t_bse_patientpaytype where isusing_num=1 and PAYFLAG_DEC<>2 and paytypename_vchr <> '特定医保' order by PAYTYPENO_VCHR";
                }
                else
                {
                    strSQL = "select paytypeid_chr, paytypename_vchr, memo_vchr, paylimit_mny, payflag_dec, paypercent_dec, paytypeno_vchr, isusing_num, copayid_chr, chargepercent_dec, internalflag_int, coalitionrecipeflag_int, bihlimitrate_dec from t_bse_patientpaytype where isusing_num=1 and payflag_dec<>2  order by paytypeno_vchr";
                }

                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                HRPSvc.Dispose();
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    clsResult = new clsPatientType_VO[dtResult.Rows.Count];
                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        clsResult[i1] = new clsPatientType_VO();
                        clsResult[i1].m_strPayTypeID = dtResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                        clsResult[i1].m_strPayTypeName = dtResult.Rows[i1]["paytypename_vchr"].ToString().Trim();
                        clsResult[i1].m_strPayTypeNo = dtResult.Rows[i1]["paytypeno_vchr"].ToString().Trim();
                        if (dtResult.Rows[i1]["PAYFLAG_DEC"] != System.DBNull.Value)
                            clsResult[i1].m_decDiscount = decimal.Parse(dtResult.Rows[i1]["PAYFLAG_DEC"].ToString().Trim());
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
            string strsql = @"select distinct a.pstatus_int,
       a.registertypeid_chr,
       a.paytypeid_chr,
       a.registerno_chr,
       a.flag_int,
       a.returnemp_chr,
       a.returndate_dat,
       a.recorddate_dat,
       a.planperiod_chr,
       a.patientid_chr,
       a.paytype_int,
       a.balance_dat,
       a.invno_chr,
       a.balanceemp_chr,
       a.bespeakdate_dat,
       a.datespace,
       a.confirmemp_chr,
       a.confirmdate_dat,
       a.takedoctor_chr,
       a.diagdoctor_chr,
       a.diagdept_chr,
       a.registerid_chr,
       a.patientcardid_chr,
       a.registerdate_dat,
       a.registeremp_chr,b.order_int,c.opaddress_vchr,c.planperiod_chr,d.registertypename_vchr,f.name_vchr,
				a.diagpay_mny+a.registerpay_mny as payinall_mny ,g.deptname_vchr 
				from t_opr_patientregister a inner join t_opr_waitdiaglist b on a.registerid_chr=b.registerid_chr
				inner join t_opr_opdoctorplan c on a.diagdoctor_chr = c.opdcotor_chr 
				inner join t_bse_registertype d on a.registertypeid_chr = d.registertypeid_chr 
				inner join t_bse_patientcard e on a.patientcardid_chr = e.patientcardid_chr 
				inner join t_bse_patientidx f on e.patientid_chr = f.patientid_chr 
				inner join t_bse_deptdesc g on a.diagdept_chr =g.deptid_chr where a.registerid_chr = '" + strRegisterID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.DoGetDataTable(strsql, ref dtbSource);
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

            string strSQL = @"SELECT a.registerid_chr, a.patientcardid_chr, a.invno_chr, a.registerno_chr, 0 as order_int,c.registertypename_vchr, d.name_vchr,d.sex_chr,CASE
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
                                         THEN '人工挂号'
                                      WHEN a.flag_int = 2
                                         THEN '预约'
                                      WHEN a.flag_int = 3
                                         THEN '退号'
                                      WHEN a.flag_int = 4
                                         THEN '还原'
                                      WHEN a.flag_int = 5
                                         THEN '自助挂号'
                                      WHEN a.flag_int = 6
                                         THEN '自助预约挂号'
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
                                   t_bse_deptdesc k
                             WHERE a.paytypeid_chr = b.paytypeid_chr
                               AND a.registertypeid_chr = c.registertypeid_chr
                               AND a.patientcardid_chr = e.patientcardid_chr
                               AND a.patientid_chr = d.patientid_chr
                               AND a.diagdept_chr = f.deptid_chr(+)
                               AND a.diagdoctor_chr = g.empid_chr(+)
                               AND a.registeremp_chr = i.empid_chr(+)
                               AND a.returnemp_chr = m.empid_chr(+)
                               AND a.diagdept_chr = k.deptid_chr(+)                          
                               AND a.registerdate_dat >= TO_DATE ('" + firstdate + @"', 'yyyy-MM-dd')
                               AND a.registerdate_dat <= TO_DATE ('" + lastdate + @"', 'yyyy-MM-dd')";

            if (Scope == "1")
            {
                strSQL += " and (a.registeremp_chr = '" + EmpID + "' or a.returnemp_chr = '" + EmpID + "')";
            }

            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtRegister);
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
   ICARE.VW_OPREGISTER A where a." + strFeild + "='" + strValue + "' and a.regdate=to_char(sysdate)";
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
            string strSQL = @"select pstatus_int,
       registertypeid_chr,
       paytypeid_chr,
       registerno_chr,
       flag_int,
       returnemp_chr,
       returndate_dat,
       recorddate_dat,
       planperiod_chr,
       patientid_chr,
       paytype_int,
       balance_dat,
       invno_chr,
       balanceemp_chr,
       bespeakdate_dat,
       datespace,
       confirmemp_chr,
       confirmdate_dat,
       takedoctor_chr,
       diagdoctor_chr,
       diagdept_chr,
       registerid_chr,
       patientcardid_chr,
       registerdate_dat,
       registeremp_chr from t_opr_patientregister where REGISTERID_CHR='" + strRegisterID + "'";
            DataTable m_dtgRegister = new DataTable();
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_dtgRegister);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"update t_opr_waitdiaglist set PSTATUS_INT=2 where REGISTERID_CHR='" + strRegisterID + "'";
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

            newID = null;
            HRPSvc.m_lngGenerateNewID("t_opr_patientregister", "REGISTERID_CHR", out newID);
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
                strSQL = @"select  registerid_chr, chargeid_chr, payment_mny, discount_dec from t_opr_patientregdetail where REGISTERID_CHR='" + strRegisterID + "'";
                try
                {
                    lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_dtgRegisterTail);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                strSQL = @"insert into t_opr_patientregdetail(REGISTERID_CHR,CHARGEID_CHR,PAYMENT_MNY,DISCOUNT_DEC)values(?,?,?,?)";
                for (int i1 = 0; i1 < m_dtgRegisterTail.Rows.Count; i1++)
                {

                    System.Data.IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(4, out paramArr);
                    paramArr[0].Value = newID;
                    paramArr[1].Value = m_dtgRegisterTail.Rows[i1]["CHARGEID_CHR"].ToString();
                    paramArr[2].Value = m_dtgRegisterTail.Rows[i1]["PAYMENT_MNY"].ToString();
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
                    lngRes = HRPSvc.DoExcute(strSQL);
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
            string strSQL = @"select SETSTATUS_INT from t_sys_setting where SETID_CHR='0001'";
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
            string strSQL = @"select pstatus_int,
       registertypeid_chr,
       paytypeid_chr,
       registerno_chr,
       flag_int,
       returnemp_chr,
       returndate_dat,
       recorddate_dat,
       planperiod_chr,
       patientid_chr,
       paytype_int,
       balance_dat,
       invno_chr,
       balanceemp_chr,
       bespeakdate_dat,
       datespace,
       confirmemp_chr,
       confirmdate_dat,
       takedoctor_chr,
       diagdoctor_chr,
       diagdept_chr,
       registerid_chr,
       patientcardid_chr,
       registerdate_dat,
       registeremp_chr from t_opr_patientregister where REGISTERID_CHR='" + strRegisterID + "'";
            DataTable m_dtgRegister = new DataTable();
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_dtgRegister);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            newID = null;
            HRPSvc.m_lngGenerateNewID("t_opr_patientregister", "REGISTERID_CHR", out newID);
            string DateNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (lngRes > 0 && m_dtgRegister.Rows.Count > 0)
            {
                strSQL = @"insert into t_opr_patientregister(REGISTERID_CHR,PATIENTCARDID_CHR,REGISTERDATE_DAT,DIAGDEPT_CHR,DIAGDOCTOR_CHR,REGISTEREMP_CHR,PSTATUS_INT,REGISTERTYPEID_CHR,PAYTYPEID_CHR,REGISTERNO_CHR,FLAG_INT,RECORDDATE_DAT,PLANPERIOD_CHR,PATIENTID_CHR,PAYTYPE_INT,INVNO_CHR,RETURNEMP_CHR,RETURNDATE_DAT)values('" + newID + "','" + m_dtgRegister.Rows[0]["PATIENTCARDID_CHR"].ToString() + "',To_Date('" + m_dtgRegister.Rows[0]["REGISTERDATE_DAT"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString() + "','" + m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString() + "','" + m_dtgRegister.Rows[0]["REGISTEREMP_CHR"].ToString() + "',1,'" + m_dtgRegister.Rows[0]["REGISTERTYPEID_CHR"].ToString() + "','" + m_dtgRegister.Rows[0]["PAYTYPEID_CHR"].ToString() + "','" + m_dtgRegister.Rows[0]["REGISTERNO_CHR"].ToString() + "',4," + "To_Date('" + DateNow + "','yyyy-mm-dd hh24:mi:ss'),'" + m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString() + "','" + m_dtgRegister.Rows[0]["PATIENTID_CHR"].ToString() + "'," + m_dtgRegister.Rows[0]["PAYTYPE_INT"].ToString() + ",'" + m_dtgRegister.Rows[0]["INVNO_CHR"].ToString() + "','" + strResetRegEmpno + "',To_Date('" + strResetRegdate + "','yyyy-mm-dd hh24:mi:ss'))";
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
                string newWaitID = null;
                newWaitID = HRPSvc.m_strGetNewID("t_opr_waitdiaglist", "WAITDIAGLISTID_CHR", 18);
                if (m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString() == null || m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString() == "")
                {
                    strSQL = @"select COUNT(*) from t_opr_waitdiaglist where PSTATUS_INT=1 and  WAITDIAGDEPT_CHR='" + m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString() + "' and REGISTERDATE_DAT=To_Date('" + strResetRegdate + "','yyyy-MM-dd')";
                    DataTable maxwait = new DataTable();
                    try
                    {
                        lngRes = HRPSvc.DoGetDataTable(strSQL, ref maxwait);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                    if (maxwait.Rows[0][0].ToString() != "")
                    {
                        waitNO = Convert.ToInt32(maxwait.Rows[0][0].ToString()) + 1;
                        strSQL = @"insert into t_opr_waitdiaglist(WAITDIAGLISTID_CHR,REGISTERID_CHR,WAITDIAGDEPT_CHR,ORDER_INT,REGISTERDATE_DAT,PSTATUS_INT,REGISTEROP_VCHR) 
                                   values(?,?,?,?,To_Date(?,'yyyy-mm-dd hh24:mi:ss'),1,?)";

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
                        strSQL = @"insert into t_opr_waitdiaglist(WAITDIAGLISTID_CHR,REGISTERID_CHR,WAITDIAGDEPT_CHR,ORDER_INT,REGISTERDATE_DAT,PSTATUS_INT,REGISTEROP_VCHR) 
                                   values(?,?,?,1,To_Date(?,'yyyy-mm-dd hh24:mi:ss'),1,?)";

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

                }
                else
                {
                    strSQL = @"select COUNT(*) from t_opr_waitdiaglist where PSTATUS_INT=1 and  WAITDIAGDEPT_CHR='" + m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString() + "' and WAITDIAGDR_CHR='" + m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString().Trim() + "'  and REGISTERDATE_DAT=to_date('" + strResetRegdate + "','yyyy-MM-dd')";
                    DataTable maxwait = new DataTable();
                    try
                    {
                        lngRes = HRPSvc.DoGetDataTable(strSQL, ref maxwait);
                    }
                    catch (Exception objEx)
                    {
                        string strTmp = objEx.Message;
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                    if (maxwait.Rows[0][0].ToString() != "")
                    {
                        waitNO = Convert.ToInt32(maxwait.Rows[0][0].ToString()) + 1;
                        strSQL = @"insert into t_opr_waitdiaglist(WAITDIAGLISTID_CHR,REGISTERID_CHR,WAITDIAGDEPT_CHR,ORDER_INT,REGISTERDATE_DAT,PSTATUS_INT,REGISTEROP_VCHR,WAITDIAGDR_CHR) 
                       values(?,?,?,?,To_Date(?,'yyyy-mm-dd hh24:mi:ss'),1,?,?)";

                        System.Data.IDataParameter[] paramArr = null;
                        HRPSvc.CreateDatabaseParameter(7, out paramArr);
                        paramArr[0].Value = newWaitID;
                        paramArr[1].Value = newID;
                        paramArr[2].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();
                        paramArr[3].Value = waitNO.ToString();
                        paramArr[4].Value = strResetRegdate;
                        paramArr[5].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString().Trim();
                        paramArr[6].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString().Trim();


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
                        strSQL = @"insert into t_opr_waitdiaglist(WAITDIAGLISTID_CHR,REGISTERID_CHR,WAITDIAGDEPT_CHR,ORDER_INT,REGISTERDATE_DAT,PSTATUS_INT,REGISTEROP_VCHR,WAITDIAGDR_CHR) 
                        values(?,?,?,1,To_Date(?,'yyyy-mm-dd hh24:mi:ss'),1,?,?)";

                        System.Data.IDataParameter[] paramArr = null;
                        HRPSvc.CreateDatabaseParameter(6, out paramArr);
                        paramArr[0].Value = newWaitID;
                        paramArr[1].Value = newID;
                        paramArr[2].Value = m_dtgRegister.Rows[0]["DIAGDEPT_CHR"].ToString();

                        paramArr[3].Value = strResetRegdate;
                        paramArr[4].Value = m_dtgRegister.Rows[0]["PLANPERIOD_CHR"].ToString().Trim();
                        paramArr[5].Value = m_dtgRegister.Rows[0]["DIAGDOCTOR_CHR"].ToString().Trim();


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


                }
                DataTable m_dtgRegisterTail = new DataTable();
                strSQL = @"select registerid_chr, chargeid_chr, payment_mny, discount_dec from t_opr_patientregdetail where REGISTERID_CHR='" + strRegisterID + "'";
                try
                {
                    lngRes = HRPSvc.DoGetDataTable(strSQL, ref m_dtgRegisterTail);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                for (int i1 = 0; i1 < m_dtgRegisterTail.Rows.Count; i1++)
                {
                    strSQL = @"insert into t_opr_patientregdetail(REGISTERID_CHR,CHARGEID_CHR,PAYMENT_MNY,DISCOUNT_DEC)values('" + newID + "','" + m_dtgRegisterTail.Rows[i1]["CHARGEID_CHR"].ToString() + "','" + m_dtgRegisterTail.Rows[i1]["PAYMENT_MNY"].ToString() + "','" + m_dtgRegisterTail.Rows[i1]["DISCOUNT_DEC"].ToString() + "')";
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

                }
                strSQL = @"update t_aid_table_sequence_id set MAX_SEQUENCE_ID_CHR='" + newID + "' where TABLE_NAME_VCHR='t_opr_patientregister'";
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


            //消息处理
            com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
            try
            {
                lngRes = objMsgUpdate.AddMsg("10003", 2, CarID);
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

            //消息处理
            com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
            try
            {
                lngRes = objMsgUpdate.AddMsg("10002", 2, patientNO);
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
            string strSQL = @"select patientcardid_chr, patientid_chr, issue_date, status_int from  t_bse_patientcard where PATIENTCARDID_CHR='" + CarID + "' and STATUS_INT!=0";
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtResult);
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
            string strSQL = "select a.REGISTERID_CHR,a.REGISTERDATE_DAT,a.FLAG_INT,a.REGISTERNO_CHR,a.INVNO_CHR,g.LASTNAME_VCHR as PatientName,f.PAYTYPENAME_VCHR,c.LASTNAME_VCHR,e.DEPTNAME_VCHR," +
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
                "and a.DIAGDOCTOR_CHR = c.empid_chr(+) " +
                "and a.patientid_chr = d.patientid_chr " +
                " and a.DIAGDEPT_CHR = e.DEPTID_CHR " +
                " and a.PATIENTID_CHR = g.PATIENTID_CHR " +
                " and a.PAYTYPEID_CHR = f.PAYTYPEID_CHR " +
                " AND (a.REGISTEREMP_CHR='" + strempno + "' and a.REGISTERDATE_DAT<=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss') and flag_int<=2 or a.RETURNEMP_CHR='" + strempno + "' and a.RETURNDATE_DAT<=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss') and flag_int=4)" +
                " and BALANCE_DAT is null ";

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
                " AND a.RETURNEMP_CHR='" + strempno + "'" +
                " and BALANCE_DAT is null " +
                "and  a.FLAG_INT=3 " +
                "and a.returndate_dat<=To_date('" + date + "','yyyy-mm-dd hh24:mi:ss')";
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
            string strSQL = @"select SETSTATUS_INT from t_sys_setting where SETID_CHR='" + strID + "'";
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
        #region 获取已结帐记录数据
        [AutoComplete]
        public long m_lngGetCheckOutHistoryData(System.Security.Principal.IPrincipal p_objPrincipal, string m_strFirstDate, string m_strEndDate, string BALANCEEMP, out DataTable dtPayType, out DataTable dtCheckOut)
        {
            dtCheckOut = null;
            dtPayType = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCheckOutHistoryData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr from t_bse_chargeitemextype  where flag_int='1' order by sortcode_int";
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
            strSQL = @"SELECT   a.invoiceno_vchr, a.recorddate_dat, a.opremp_chr, a.seqid_chr,
         a.status_int, a.balanceemp_chr, a.paytype_int, a.paytypeid_chr,
         b.tolfee_mny, b.itemcatid_chr, c.internalflag_int, a.acctsum_mny,
         a.sbsum_mny, a.totalsum_mny
     FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c
     WHERE a.invoiceno_vchr = b.invoiceno_vchr
     AND a.balanceflag_int = 1
     AND a.seqid_chr = b.seqid_chr
     AND a.paytypeid_chr = c.paytypeid_chr(+)
     AND a.balance_dat between TO_DATE (?, 'yyyy-mm-dd HH24:mi:ss') and TO_DATE (?, 'yyyy-mm-dd HH24:mi:ss') 
     AND balanceemp_chr = ?
     ORDER BY a.invoiceno_vchr, a.seqid_chr";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strFirstDate + " 00:00:00";
                objLisAddItemRefArr[1].Value = m_strEndDate + " 23:59:59";
                objLisAddItemRefArr[2].Value = BALANCEEMP;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtCheckOut, objLisAddItemRefArr);
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
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
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

        #region 历吏记录数据
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
            string strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
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


        #endregion

        #region 收费日查询报表

        [AutoComplete]
        public long m_lngGetPayTypeAndCheckOutBetWeenDay(System.Security.Principal.IPrincipal p_objPrincipal, string strDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtEmp, string strINTERNALFLAG, string strCheckManName)
        {
            dtEmp = null;
            dtPayType = null;
            dtCheckOut = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPayTypeAndCheckOutBetWeenDay");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
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
                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT,a.OPREMP_CHR, a.SEQID_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,d.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c,t_opr_payment d
                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+)  AND d.chargeno_vchr = a.seqid_chr and a.BALANCE_DAT between To_Date('" + strDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + strDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')" + SqlWhere + " order by a.INVOICENO_VCHR,a.SEQID_CHR";
            }
            else
            {
                strSQL = @"select a.INVOICENO_VCHR,a.RECORDDATE_DAT,a.OPREMP_CHR, a.SEQID_CHR,a.STATUS_INT,a.BALANCEEMP_CHR,d.PAYTYPE_INT,a.PAYTYPEID_CHR,b.TOLFEE_MNY,b.ITEMCATID_CHR,c.INTERNALFLAG_INT,a.ACCTSUM_MNY,a.SBSUM_MNY,a.TOTALSUM_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c,t_opr_payment d
                    where a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR and  a.BALANCEFLAG_INT=1 AND d.chargeno_vchr = a.seqid_chr and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR(+) and a.BALANCE_DAT between To_Date('" + strDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + strDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')" + SqlWhere + " and a.INTERNALFLAG_INT=" + strINTERNALFLAG + " order by a.INVOICENO_VCHR,a.SEQID_CHR";
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
                    strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1 and a.BALANCEEMP_CHR=b.EMPID_CHR and a.BALANCE_DAT between To_Date('" + strDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + strDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss')";
                }
                else
                {
                    strSQL = @"select distinct a.BALANCEEMP_CHR,b.LASTNAME_VCHR from t_opr_outpatientrecipeinv a,t_bse_employee b where BALANCEFLAG_INT=1  and a.BALANCEEMP_CHR=b.EMPID_CHR and a.BALANCE_DAT between To_Date('" + strDate + " 00:00:00','yyyy-mm-dd HH24:mi:ss') and To_Date('" + strDate + " 23:59:59','yyyy-mm-dd HH24:mi:ss') and a.INTERNALFLAG_INT=" + strINTERNALFLAG;
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
            string strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
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
            string strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";
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
            string strSQL = @"select rptid_chr, groupid_chr, typeid_chr, flag_int from t_aid_rpt_gop_rla where  flag_int ='2'";
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
            string OtherWhere = @"  AND a.BALANCE_DAT=to_date('" + CheckDate + "','yyyy-mm-dd hh24:mi:ss') and a.BALANCEEMP_CHR='" + checkMan + "'";
            string strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
    FROM t_opr_outpatientrecipeinv a
   WHERE a.balanceflag_int = 1
     AND a.PAYTYPE_INT=0" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt1);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   a.invoiceno_vchr, a.paytype_int,
         b.itemcatid_chr,b.sbsum_mny,
         b.tolfee_mny
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c
   WHERE a.balanceflag_int = 1
	 and a.PAYTYPE_INT=0
     AND a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.paytypeid_chr = c.paytypeid_chr" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe1);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
       MAX (recorddate_dat) AS maxrecorddate_dat, sum(sbsum_mny1) as totalmoney from (SELECT a.recorddate_dat, '' AS acctsum_mny1, sbsum_mny AS sbsum_mny1,a.paytype_int
  FROM t_opr_outpatientrecipeinv a
 WHERE a.balanceflag_int = 1 AND a.paytype_int = 1" + OtherWhere + "UNION ALL SELECT a.recorddate_dat, '' AS acctsum_mny1, a.acctsum_mny AS sbsum_mny1,a.paytype_int FROM t_opr_outpatientrecipeinv a, t_bse_patientpaytype c WHERE a.paytypeid_chr = c.paytypeid_chr AND c.internalflag_int = 2" + OtherWhere + ") ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt2);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT invoiceno_vchr, paytype_int, itemcatid_chr,
       sbsum_mny1 AS sbsum_mny, tolfee_mny
  FROM (SELECT a.invoiceno_vchr, a.paytype_int, b.itemcatid_chr,
               b.sbsum_mny AS sbsum_mny1, b.tolfee_mny
          FROM t_opr_outpatientrecipeinv a, t_opr_outpatientrecipesumde b
         WHERE a.balanceflag_int = 1
           AND a.paytype_int = 1
           AND a.invoiceno_vchr = b.invoiceno_vchr
           AND a.seqid_chr = b.seqid_chr" + OtherWhere + " UNION ALL  SELECT a.invoiceno_vchr, a.paytype_int, b.itemcatid_chr,(b.tolfee_mny - b.sbsum_mny) AS sbsum_mny1, b.tolfee_mny FROM t_opr_outpatientrecipeinv a,t_opr_outpatientrecipesumde b,t_bse_patientpaytype c WHERE a.balanceflag_int = 1  AND a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and  a.invoiceno_vchr = b.invoiceno_vchr AND a.seqid_chr = b.seqid_chr AND c.internalflag_int = 2" + OtherWhere + ")";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe2);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
       MAX (recorddate_dat) AS maxrecorddate_dat, sum(a.ACCTSUM_MNY) as totalmoney
                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR and c.INTERNALFLAG_INT=1" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt3);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }

            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,tolfee_mny
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 AND a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe3);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select MIN (recorddate_dat) AS minrecorddate_dat,
       MAX (recorddate_dat) AS maxrecorddate_dat, sum(a.ACCTSUM_MNY) as totalmoney
                    from t_opr_outpatientrecipeinv a,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT>2" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt4);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT>2 " + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe4);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtType);
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
        #region 收费员日结报表分类收费
        /// <summary>
        ///  收费员日结报表分类收费
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="CheckDate"></param>
        /// <param name="checkMan"></param>
        /// <param name="dt1">现金支付</param>
        /// <param name="dtDe1">现金支付明细</param>
        /// <param name="dt2">IC卡</param>
        /// <param name="dtDe2">IC卡明细</param>
        /// <param name="dt3">银行卡</param>
        /// <param name="dtDe3">银行卡明细</param>
        /// <param name="dt4">支票</param>
        /// <param name="dtDe4">支票明细</param>
        /// <param name="dt5">其他记帐</param>
        /// <param name="dtDe5">其他记帐明细</param>
        /// <param name="dt6">公费记帐</param>
        /// <param name="dtDe6">公费记帐明细</param>
        /// <param name="dt7">特困</param>
        /// <param name="dtDe7">特困明细</param>
        /// <param name="dt8">离休</param>
        /// <param name="dtDe8">离休明细</param>
        /// <param name="dt9">本院</param>
        /// <param name="dtDe9">本院明细</param>
        /// <param name="dt10">特定医保记帐</param>
        /// <param name="dtDe10">特定医保记帐明细</param>
        /// <param name="dtType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckOutOfClassification(System.Security.Principal.IPrincipal p_objPrincipal, string CheckDate, string checkMan, out DataTable dt1, out DataTable dtDe1, out DataTable dt2, out DataTable dtDe2, out DataTable dt3, out DataTable dtDe3, out DataTable dt4, out DataTable dtDe4, out DataTable dt5, out DataTable dtDe5, out DataTable dt6, out DataTable dtDe6, out DataTable dt7, out DataTable dtDe7, out DataTable dt8, out DataTable dtDe8, out DataTable dt9, out DataTable dtDe9, out DataTable dt10, out DataTable dtDe10, out DataTable dtType)
        {
            dt1 = null;
            dtDe1 = null;
            dt2 = null;
            dtDe2 = null;
            dt3 = null;
            dtDe3 = null;
            dt4 = null;
            dtDe4 = null;
            dt5 = null;
            dtDe5 = null;
            dt6 = null;
            dtDe6 = null;
            dt7 = null;
            dtDe7 = null;
            dt8 = null;
            dtDe8 = null;
            dt9 = null;
            dtDe9 = null;
            dt10 = null;
            dtDe10 = null;
            dtType = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetCheckOutOfClassification");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string OtherWhere = @"  AND a.BALANCE_DAT=to_date('" + CheckDate + "','yyyy-mm-dd hh24:mi:ss') and a.BALANCEEMP_CHR='" + checkMan + "'";
            string strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
    FROM t_opr_outpatientrecipeinv a
   WHERE a.balanceflag_int = 1
     AND a.PAYTYPE_INT=0" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt1);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   a.invoiceno_vchr, a.paytype_int,
         b.itemcatid_chr,b.sbsum_mny,
         b.tolfee_mny
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c
   WHERE a.balanceflag_int = 1
	 and a.PAYTYPE_INT=0
     AND a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.paytypeid_chr = c.paytypeid_chr" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe1);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and a.INTERNALFLAG_INT=3" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt2);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=3" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe2);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
    FROM t_opr_outpatientrecipeinv a
   WHERE a.balanceflag_int = 1
     AND a.PAYTYPE_INT=1" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt3);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   a.invoiceno_vchr, a.paytype_int,
         b.itemcatid_chr,b.sbsum_mny,
         b.tolfee_mny
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c
   WHERE a.balanceflag_int = 1
	 and a.PAYTYPE_INT=1
     AND a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.paytypeid_chr = c.paytypeid_chr" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe3);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
    FROM t_opr_outpatientrecipeinv a
   WHERE a.balanceflag_int = 1
     AND a.PAYTYPE_INT=2" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt4);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   a.invoiceno_vchr, a.paytype_int,
         b.itemcatid_chr,b.sbsum_mny,
         b.tolfee_mny
    FROM t_opr_outpatientrecipeinv a,
         t_opr_outpatientrecipesumde b,
         t_bse_patientpaytype c
   WHERE a.balanceflag_int = 1
	 and a.PAYTYPE_INT=2
     AND a.invoiceno_vchr = b.invoiceno_vchr
     AND a.seqid_chr = b.seqid_chr
     AND a.paytypeid_chr = c.paytypeid_chr" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe4);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and a.INTERNALFLAG_INT>5" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt5);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT>5" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe5);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and a.INTERNALFLAG_INT=1" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt6);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=1" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe6);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and a.INTERNALFLAG_INT=3" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt7);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=3" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe7);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and a.INTERNALFLAG_INT=4" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt8);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=4" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe8);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and a.INTERNALFLAG_INT=5" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt9);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=5" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe9);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"SELECT   min(a.recorddate_dat) as minrecorddate_dat,max(a.recorddate_dat) as maxrecorddate_dat,Sum(SBSUM_MNY) as totalmoney
                       FROM t_opr_outpatientrecipeinv a
                       WHERE a.balanceflag_int = 1
                       and  a.INTERNALFLAG_INT=2" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt10);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            strSQL = @"select a.INVOICENO_VCHR,a.PAYTYPE_INT,b.ITEMCATID_CHR ,(b.TOLFEE_MNY-b.SBSUM_MNY) as SBSUM_MNY,b.TOLFEE_MNY
                    from t_opr_outpatientrecipeinv a,T_OPR_OUTPATIENTRECIPESUMDE b,t_bse_patientpaytype c
                    where  a.BALANCEFLAG_INT=1 and a.INVOICENO_VCHR=b.INVOICENO_VCHR and a.SEQID_CHR=b.SEQID_CHR  and a.PAYTYPEID_CHR=c.PAYTYPEID_CHR  and c.INTERNALFLAG_INT=2" + OtherWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtDe10);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }


            strSQL = @"Select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int, govtopcharge_mny, emrcat_vchr From t_bse_chargeitemextype  Where flag_int='1' order by SORTCODE_INT";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtType);
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
select distinct e.* from 
(select a.registertypeid_chr,b.chargeid_chr,c.paytypeid_chr,0 as pay,1 as dis
from t_bse_registertype a cross join t_bse_registerchargetype b cross join t_bse_patientpaytype c
) e , t_bse_registerdetail d
where e.registertypeid_chr=d.registertypeid_chr(+) and e.chargeid_chr=d.chargeid_chr(+)
and e.paytypeid_chr = d.paytypeid_chr(+) and d.registertypeid_chr is null
and d.chargeid_chr is null and d.paytypeid_chr is null";
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

            StringBuilder strSQL = new StringBuilder(@"select a.registerid_chr,
                                                        a.invno_chr,
                                                        a.flag_int,
                                                        c.chargeid_chr,
                                                        d.chargename_chr,
                                                        c.payment_mny,
                                                        c.discount_dec,
                                                        b.empid_chr,
                                                        b.empno_chr,
                                                        b.lastname_vchr
                                                      from t_opr_patientregister    a,
                                                           t_bse_employee           b,
                                                           t_opr_patientregdetail   c,
                                                           t_bse_registerchargetype d
                                                      where a.balanceemp_chr = b.empid_chr
                                                        and a.registerid_chr = c.registerid_chr
                                                        and c.chargeid_chr = d.chargeid_chr
                                                        and a.pstatus_int = 4
                                                        and a.flag_int in (1, 3, 4)
                                                        and a.registerdate_dat >= ? 
                                                        and a.registerdate_dat <= ?");

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
                    strSQL.Append(@" and a.balanceemp_chr = ?");
                    ++m_intParamCount;
                    tmp_objParamerArr[m_intParamCount - 1].Value = p_strOperatorId;
                    strSQL.Append(@" order by a.invno_chr asc");
                }
                else
                {
                    strSQL.Append(@" order by a.invno_chr asc");
                }

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamerArr);
                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objParamerArr[i1].Value = tmp_objParamerArr[i1].Value;
                    objParamerArr[i1].DbType = tmp_objParamerArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objParamerArr);
            }
            catch
            {
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
            StringBuilder strSQL = new StringBuilder(@"select a.sourceinvono_vchr,
                                     a.repprninvono_vchr,
                                     a.printemp_chr,
                                     a.printstatus_int,
                                     b.empid_chr,
                                     b.empno_chr,
                                     b.lastname_vchr
                             from t_opr_invoicerepeatprint a,
                                  t_bse_employee b
                             where a.printemp_chr = b.empid_chr
                               and a.type_chr = 2

                               and a.printdate_dat >= ?
                               and a.printdate_dat <= ?");

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
            string strSQL = @"SELECT a.registerid_chr, a.registerdate_dat, a.diagdoctor_chr,
       c.lastname_vchr, a.diagdept_chr, e.deptname_vchr,
       (SELECT payment_mny * discount_dec
          FROM t_opr_patientregdetail d
         WHERE d.registerid_chr = a.registerid_chr
           AND d.chargeid_chr = '001') AS rcharge,
       (SELECT payment_mny * discount_dec
          FROM t_opr_patientregdetail d
         WHERE d.registerid_chr = a.registerid_chr
           AND d.chargeid_chr = '002') AS dcharge,
       (SELECT payment_mny * discount_dec
          FROM t_opr_patientregdetail d
         WHERE d.registerid_chr = a.registerid_chr
           AND d.chargeid_chr = '003') AS gcharge,
       (SELECT payment_mny * discount_dec
          FROM t_opr_patientregdetail d
         WHERE d.registerid_chr = a.registerid_chr
           AND d.chargeid_chr = '004') AS ccharge,
       a.recorddate_dat, a.flag_int
  FROM t_opr_patientregister a, t_bse_employee c, t_bse_deptdesc e
 WHERE a.diagdoctor_chr = c.empid_chr(+)
   AND a.diagdept_chr = e.deptid_chr
   AND a.balanceemp_chr IS NOT NULL 
   AND a.registerdate_dat BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')
                         AND TO_DATE (?,
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )   order by a.diagdept_chr";

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
            string strSQL = @"SELECT   a.registerid_chr, a.registeremp_chr AS empid, c.lastname_vchr,
         a.registerdate_dat, e.deptname_vchr,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '001') AS rcharge,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '002') AS dcharge,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '003') AS gcharge,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '004') AS ccharge,
         a.recorddate_dat, a.flag_int
    FROM t_opr_patientregister a, t_bse_employee c, t_bse_deptdesc e
   WHERE a.registeremp_chr = c.empid_chr(+)
     AND a.diagdept_chr = e.deptid_chr
     AND a.balanceemp_chr IS NOT NULL
     AND a.returnemp_chr IS NULL
     AND a.registerdate_dat BETWEEN TO_DATE (?,
                                        'yyyy-mm-dd hh24:mi:ss'
                                       )
                           AND TO_DATE (?,
                                        'yyyy-mm-dd hh24:mi:ss'
                                       )
UNION ALL
SELECT   a.registerid_chr, a.returnemp_chr AS empid, c.lastname_vchr,
         a.registerdate_dat, e.deptname_vchr,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '001') AS rcharge,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '002') AS dcharge,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '003') AS gcharge,
         (SELECT payment_mny * discount_dec
            FROM t_opr_patientregdetail d
           WHERE d.registerid_chr = a.registerid_chr
             AND d.chargeid_chr = '004') AS ccharge,
         a.recorddate_dat, a.flag_int
    FROM t_opr_patientregister a, t_bse_employee c, t_bse_deptdesc e
   WHERE a.returnemp_chr = c.empid_chr(+)
     AND a.diagdept_chr = e.deptid_chr
     AND a.balanceemp_chr IS NOT NULL
     AND a.returnemp_chr IS NOT NULL
     AND a.registerdate_dat BETWEEN TO_DATE (?,
                                        'yyyy-mm-dd hh24:mi:ss'
                                       )
                           AND TO_DATE (?,
                                        'yyyy-mm-dd hh24:mi:ss'
                                       )
ORDER BY empid";


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
            string strSQL = @"SELECT   t2.deptid_chr, t2.deptname_vchr, t2.parentid, t1.flag_int,
         t1.planperiod_chr, t1.registertypeid_chr,
         t3.deptname_vchr AS parentname_vchr, t3.code_vchr
    FROM t_opr_patientregister t1, t_bse_deptdesc t2, t_bse_deptdesc t3
   WHERE  t1.balanceemp_chr IS NOT NULL and t1.registerdate_dat  BETWEEN TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')
                            AND TO_DATE (?,
                                         'yyyy-mm-dd hh24:mi:ss'
                                        )
     AND t1.diagdept_chr = t2.deptid_chr(+)
     AND t2.parentid = t3.deptid_chr(+)";

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
            string strSQL = @"select a.appid_chr,
       a.invoicenofrom_vchr,
       a.invoicenoto_vchr,
       a.apply_dat,
       a.appuserid_chr,
       a.operatorid_chr,
       a.canceluserid_chr,
       a.status_int,
       a.cancel_dat,case when a.status_int=0 then '正常'  when a.status_int=1 then '作废' end as statustype, b.lastname_vchr as appusername,b.empno_chr,c.lastname_vchr as operatorname,d.lastname_vchr as cancelname from t_opr_reginvman a,t_bse_employee b,t_bse_employee c,t_bse_employee d where a.appuserid_chr=b.empid_chr and a.operatorid_chr=c.empid_chr(+) and a.canceluserid_chr=d.empid_chr(+)";
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
            string strSQL = @"select A.RECIPEID_CHR,A.RECIPENAME_CHR,a.DISEASENAME_VCHR,case when A.PRIVILEGE_INT=0 then '公用' when A.PRIVILEGE_INT=1 then '私用' when A.PRIVILEGE_INT=2 then '科室' end as strPRIVILEGE,A.USERCODE_CHR,A.WBCODE_CHR,A.PYCODE_CHR,A.CREATERID_CHR,b.LASTNAME_VCHR, a.PECLUSCODE, a.PECLUSNAME from T_AID_CONCERTRECIPE A,T_BSE_EMPLOYEE b where a.CREATERID_CHR=b.EMPID_CHR  and A.PRIVILEGE_INT =1 and
 A.CREATERID_CHR ='" + strEmptID + @"' and A.STATUS_INT =1 and a.FLAG_INT=" + intFLAG.ToString();
            if (IsPublic == true)
            {
                strSQL += @" union select A.RECIPEID_CHR,A.RECIPENAME_CHR,a.DISEASENAME_VCHR,case when A.PRIVILEGE_INT=0 then '公用' when A.PRIVILEGE_INT=1 then '私用' when A.PRIVILEGE_INT=2 then '科室' end as strPRIVILEGE,A.USERCODE_CHR,A.WBCODE_CHR,A.PYCODE_CHR,A.CREATERID_CHR,b.LASTNAME_VCHR, a.PECLUSCODE, a.PECLUSNAME from T_AID_CONCERTRECIPE A ,T_BSE_EMPLOYEE b WHERE a.CREATERID_CHR=b.EMPID_CHR and A.PRIVILEGE_INT =0 and A.STATUS_INT =1 and a.FLAG_INT=" + intFLAG.ToString() + @"  
 union
 select AA.RECIPEID_CHR,AA.RECIPENAME_CHR,AA.DISEASENAME_VCHR,case when AA.PRIVILEGE_INT=0 then '公用' when AA.PRIVILEGE_INT=1 then '私用' when AA.PRIVILEGE_INT=2 then '科室' end as strPRIVILEGE,AA.USERCODE_CHR,AA.WBCODE_CHR,AA.PYCODE_CHR,AA.CREATERID_CHR,CC.LASTNAME_VCHR, aa.PECLUSCODE, aa.PECLUSNAME from T_AID_CONCERTRECIPE AA,
 ( select A.recipeid_chr from T_AID_CONCERTRECIPEDEPT A where  A.deptid_chr
 in (select DEPTID_CHR from T_BSE_DEPTEMP where EMPID_CHR ='" + strEmptID + @"')) BB,T_BSE_EMPLOYEE CC
  where AA.RECIPEID_CHR =BB.RECIPEID_CHR and aa.CREATERID_CHR=cc.EMPID_CHR and AA.PRIVILEGE_INT =2 
  and AA.STATUS_INT =1 and AA.FLAG_INT=" + intFLAG.ToString() + @"
  union 
select AA.RECIPEID_CHR,AA.RECIPENAME_CHR,AA.DISEASENAME_VCHR,case when AA.PRIVILEGE_INT=0 
 then '公用' when AA.PRIVILEGE_INT=1 then '私用' when AA.PRIVILEGE_INT=2 
 then '科室' end as strPRIVILEGE,AA.USERCODE_CHR,AA.WBCODE_CHR,AA.PYCODE_CHR,
 AA.CREATERID_CHR,CC.LASTNAME_VCHR, aa.PECLUSCODE, aa.PECLUSNAME from T_AID_CONCERTRECIPE AA,T_BSE_EMPLOYEE CC
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
            string strSQL = @"SELECT a.*,case when a.FLAG_INT is null or a.FLAG_INT=2 then '' when a.FLAG_INT=0 then (select f.SAMPLE_TYPE_DESC_VCHR from t_aid_lis_sampletype f where a.PARTORTYPE_VCHR=f.SAMPLE_TYPE_ID_CHR) else (select k.PARTNAME from ar_apply_partlist k where a.PARTORTYPE_VCHR=k.PARTID) end 
  as PARTORTYPENAME_VCHR,b.ITEMNAME_VCHR,(select k.TYPENAME_VCHR from t_bse_chargeitemextype k where k.TYPEID_CHR=b.ITEMOPINVTYPE_CHR and FLAG_INT=2) as ItemType,b.ITEMSPEC_VCHR,case when b.OPCHARGEFLG_INT=1 then b.ITEMIPUNIT_CHR  when b.OPCHARGEFLG_INT=0 then b.ITEMOPUNIT_CHR end as ITEMOPUNIT_CHR,case when b.OPCHARGEFLG_INT=1 then  ROUND (b.ITEMPRICE_MNY / b.PACKQTY_DEC, 4) when b.OPCHARGEFLG_INT=0 then  b.ITEMPRICE_MNY end as ITEMPRICE_MNY ,b.DOSAGEUNIT_CHR,d.usagename_vchr,e.freqname_chr,e.DAYS_INT as daytag ,f.NOQTYFLAG_INT,f.medicineid_chr,b.DOSAGE_DEC  FROM T_AID_CONCERTRECIPEDETAIL a,T_BSE_CHARGEITEM b,T_AID_CONCERTRECIPE c ,T_BSE_USAGETYPE D,T_AID_RECIPEFREQ E,T_BSE_MEDICINE f WHERE a.dosetype_chr=d.usageid_chr(+)and a.freqid_chr=e.freqid_chr(+) and  a.ITEMID_CHR = b.ITEMID_CHR and a.RECIPEID_CHR = c.RECIPEID_CHR and trim(b.ITEMSRCID_VCHR)=trim(f.MEDICINEID_CHR(+)) and c.RECIPEID_CHR='" + strID + "' order by a.sort_int";
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
            string strSQL = @"select a.recipeid_chr,a.deptid_chr,c.deptname_vchr from t_aid_concertrecipedept a,t_aid_concertrecipe b,t_bse_deptdesc c where a.deptid_chr = c.deptid_chr and a.recipeid_chr = b.recipeid_chr and b.recipeid_chr='" + strReciptID + "'";
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
            string strSQL = @"select usageid_chr, usagename_vchr, usercode_chr, pycode_vchr, wbcode_vchr, scope_int, putmed_int, test_int, opusagedesc from t_bse_usagetype order by usercode_chr";
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
        [AutoComplete]//(datarow 换为 object[])
        public long m_lngAddNewConcertre(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, object[] bt, DataTable btDe, DataTable btDetp, string isDetp, int intFLAG)
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
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            p_strRecordID = objHRPSvc.m_strGetNewID("T_AID_CONCERTRECIPE", "RECIPEID_CHR", 10);
            //('" + p_strRecordID + "', '" + bt.GetValue(1).ToString() + "',
            // " + bt.GetValue(3).ToString() + ",
            //'" + bt.GetValue(4).ToString() + "',
            //'" + bt.GetValue(6).ToString() + "',
            //'" + bt.GetValue(5).ToString() + "', 1,
            // '" + bt.GetValue(7).ToString() + "', " + intFLAG.ToString() + ",
            //'" + bt.GetValue(2).ToString() + "'
            //)
            string strSQL = @"INSERT INTO T_AID_CONCERTRECIPE (RECIPEID_CHR,RECIPENAME_CHR,PRIVILEGE_INT,USERCODE_CHR,PYCODE_CHR,WBCODE_CHR,STATUS_INT,CREATERID_CHR,FLAG_INT,DISEASENAME_VCHR, PECLUSCODE, PECLUSNAME) 
VALUES ('" + p_strRecordID + "','" + bt.GetValue(1).ToString() + "'," + bt.GetValue(3).ToString() + ",'" + bt.GetValue(4).ToString() + "','" + bt.GetValue(6).ToString() + "','" + bt.GetValue(5).ToString() + "',1,'" + bt.GetValue(7).ToString() + "'," + intFLAG.ToString() + ",'" + bt.GetValue(2).ToString() + "','" + bt.GetValue(8).ToString() + "','" + bt.GetValue(9).ToString() + "')";
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
        public long m_lngDeleteConcertrecipeAndDe(System.Security.Principal.IPrincipal p_objPrincipal, object[] DeleRow, object[] DeleRowDe, string strItem, string strFlag)
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
            if (DeleRow != null)
            {
                strSQL = "delete from T_AID_CONCERTRECIPE where RECIPEID_CHR ='" + DeleRow.GetValue(0).ToString() + "'";

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
                    strSQL = "delete from T_AID_CONCERTRECIPEDETAIL where RECIPEID_CHR ='" + DeleRow.GetValue(0).ToString() + "'";

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
                if (DeleRow.GetValue(0).ToString() == "2")
                {
                    strSQL = "delete from T_AID_CONCERTRECIPEDEPT where RECIPEID_CHR ='" + DeleRow.GetValue(0).ToString() + "'";
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
            if (DeleRowDe != null)
            {
                if (strItem == null)
                {
                    strSQL = "delete from T_AID_CONCERTRECIPEDETAIL where RECIPEID_CHR ='" + DeleRowDe.GetValue(0).ToString() + "' and DETAILID_CHR='" + DeleRowDe.GetValue(1).ToString() + "'";
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
        public long m_lngConcertreCipeDetailModifyDe(System.Security.Principal.IPrincipal p_objPrincipal, string strID, object[] dtRow, string oldITEMID, string strFLAG, bool blIsPublic, string CREATERID, int m_intSort)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeDetailModify");
            if (lngRes < 0)
            {
                return -1;
            }
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strwhere = " RECIPEID_CHR ='" + strID + "' and DETAILID_CHR='" + dtRow.GetValue(1).ToString() + "'";
            string strSQL = "";
            string strSQL1 = "";
            if (oldITEMID == null)
            {
                strSQL = @"update T_AID_CONCERTRECIPEDETAIL
				set
ITEMID_CHR='" + dtRow.GetValue(2).ToString() + @"',
QTY_DEC='" + dtRow.GetValue(3).ToString() + @"', 
DOSAGEQTY_DEC=" + dtRow.GetValue(6).ToString() + @", 
DOSETYPE_CHR='" + dtRow.GetValue(5).ToString() + @"', 
FREQID_CHR='" + dtRow.GetValue(4).ToString() + @"', 
DAYS_INT=" + dtRow.GetValue(7).ToString() + @",
ROWNO_CHR='" + dtRow.GetValue(8).ToString() + @"',FLAG_INT=" + dtRow.GetValue(10).ToString() + ",PARTORTYPE_VCHR='" + dtRow.GetValue(9).ToString() + "',PARTORTYPENAME_VCHR='" + dtRow.GetValue(11).ToString() + "',sort_int=" + m_intSort + "  where " + strwhere;
            }
            else
            {

                strSQL1 = @"update T_AID_CONCERTRECIPEDETAIL
				set
ITEMID_CHR='" + dtRow.GetValue(2).ToString() + @"',
QTY_DEC='" + dtRow.GetValue(3).ToString() + @"', 
DOSAGEQTY_DEC=" + dtRow.GetValue(6).ToString() + @", 
DOSETYPE_CHR='" + dtRow.GetValue(5).ToString() + @"', 
FREQID_CHR='" + dtRow.GetValue(4).ToString() + @"', 
DAYS_INT=" + dtRow.GetValue(7).ToString() + @",
ROWNO_CHR='" + dtRow.GetValue(8).ToString() + @"' ,FLAG_INT=" + dtRow.GetValue(10).ToString() + ",PARTORTYPE_VCHR='" + dtRow.GetValue(9).ToString() + "',PARTORTYPENAME_VCHR='" + dtRow.GetValue(11).ToString() + "',sort_int=" + m_intSort + "   where " + strwhere;
                if (blIsPublic)
                {
                    strwhere = "  ITEMID_CHR ='" + oldITEMID + "' and RECIPEID_CHR in (select  RECIPEID_CHR from t_aid_concertrecipe where FLAG_INT=" + strFLAG + ")";

                }
                else
                {
                    strwhere = "  ITEMID_CHR ='" + oldITEMID + "' and RECIPEID_CHR in (select  RECIPEID_CHR from t_aid_concertrecipe where FLAG_INT=" + strFLAG + " and CREATERID_CHR='" + CREATERID + "')";
                }
                strSQL = @"update T_AID_CONCERTRECIPEDETAIL
				set ITEMID_CHR='" + dtRow.GetValue(2).ToString() + @"' ,sort_int=" + m_intSort + "  where " + strwhere;
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
        [AutoComplete]//(datarow 换为 object[])
        public long m_lngConcertreModify(System.Security.Principal.IPrincipal p_objPrincipal, object[] ModifiyRow, DataTable Deptbt)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeModify");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update  T_AID_CONCERTRECIPE
				set 
RECIPENAME_CHR='" + ModifiyRow.GetValue(1).ToString() + @"',
PRIVILEGE_INT='" + ModifiyRow.GetValue(3).ToString() + @"',
USERCODE_CHR='" + ModifiyRow.GetValue(4).ToString() + @"',
WBCODE_CHR='" + ModifiyRow.GetValue(5).ToString() + @"',
PYCODE_CHR='" + ModifiyRow.GetValue(6).ToString() + @"',
CREATERID_CHR='" + ModifiyRow.GetValue(7).ToString() + "',DISEASENAME_VCHR='" + ModifiyRow.GetValue(2).ToString() + @"',
PECLUSCODE = '" + ModifiyRow.GetValue(9).ToString() + "', PECLUSNAME = '" + ModifiyRow.GetValue(10).ToString() + 
                 "'  where RECIPEID_CHR='" + ModifiyRow.GetValue(0).ToString() + "'"
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
            strSQL = @"delete T_AID_CONCERTRECIPEDEPT where RECIPEID_CHR='" + ModifiyRow.GetValue(0).ToString() + "'";
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
                        strSQL = @"insert into T_AID_CONCERTRECIPEDEPT(RECIPEID_CHR,DEPTID_CHR) VALUES('" + ModifiyRow.GetValue(0).ToString() + "','" + Deptbt.Rows[f2]["DEPTID_CHR"].ToString() + "')";
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
        public long m_lngConcertreCipeDetailAddNEWDe(System.Security.Principal.IPrincipal p_objPrincipal, string strID, object[] btDe, int m_intSort)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngConcertreCipeDetailAddNEWDe");
            if (lngRes < 0)
            {
                return -1;
            }
            string newID;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            objHRPSvc.lngGenerateID(10, "DETAILID_CHR", "T_AID_CONCERTRECIPEDETAIL", out newID); ;
            string strSQL = @"INSERT INTO T_AID_CONCERTRECIPEDETAIL (RECIPEID_CHR,DETAILID_CHR,ITEMID_CHR,QTY_DEC,DOSETYPE_CHR,FREQID_CHR,DOSAGEQTY_DEC,ROWNO_CHR,DAYS_INT,PARTORTYPE_VCHR,FLAG_INT,PARTORTYPENAME_VCHR,sort_int) 
            VALUES ('" + strID + "','" + newID + "','" + btDe.GetValue(2).ToString() + "'," + btDe.GetValue(3).ToString() + ",'" + btDe.GetValue(5).ToString() + "','" + btDe.GetValue(4).ToString() + "'," + btDe.GetValue(6).ToString() + ",'" + btDe.GetValue(8).ToString() + "'," + btDe.GetValue(7).ToString() + ",'" + btDe.GetValue(9).ToString() + "'," + btDe.GetValue(10).ToString() + ",'" + btDe.GetValue(11).ToString() + "'," + m_intSort + ")";
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
            string strSQL = "select a.paytypeid_chr, a.itemid_chr, a.qty_dec, a.register_int, a.recipeflag_int, a.expert_int,b.itemname_vchr,b.itemcode_vchr,b.itemopunit_chr,b.itemspec_vchr,b.itemprice_mny,case when b.isrich_int=1 then '是' when b.isrich_int=0 then '否' end as strisrich,case when b.itemcatid_chr='0002' then '中药' when b.itemcatid_chr='0003' then '检验' when b.itemcatid_chr='0004' then '治疗' when b.itemcatid_chr='0005' then '其它' when b.itemcatid_chr='0006' then '手术' when b.itemcatid_chr='0001' then '西药' end as itemtype,case when register_int=0 then '全部' when  register_int=1 then '已挂号' else '未挂号' end as register,case when recipeflag_int=0 then '全部' when recipeflag_int=1 then '正方' else '副方' end as recipeflag,case when expert_int=0 then '全部' when expert_int=1 then '专家' else '普通' end as  expert from t_aid_chargepaytype a,t_bse_chargeitem b where a.paytypeid_chr='" + strPayTypeID + "' and a.itemid_chr=b.itemid_chr";
            //往表增加记录
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
            string strSQL = "select b.roleid_chr,b.name_vchr,b.desc_vchr,b.deptid_chr from t_sys_emprolemap a,t_sys_role b where  a.roleid_chr=b.roleid_chr and a.empid_chr='" + strID + @"' and b.NAME_VCHR='编辑公用协定处方'";
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
            string strSQL = @"select a.recipeid_chr, a.recipename_chr, a.privilege_int, a.usercode_chr, a.wbcode_chr, a.pycode_chr, a.status_int, a.createrid_chr, a.flag_int, a.diseasename_vchr,b.lastname_vchr from t_aid_concertrecipe a ,t_bse_employee b where a.createrid_chr=b.empid_chr and a.privilege_int =0 and a.status_int =1
union
select a.recipeid_chr, a.recipename_chr, a.privilege_int, a.usercode_chr, a.wbcode_chr, a.pycode_chr, a.status_int, a.createrid_chr, a.flag_int, a.diseasename_vchr,b.lastname_vchr from t_aid_concertrecipe a,t_bse_employee b where a.createrid_chr=b.empid_chr  and a.privilege_int =1 and
 a.createrid_chr ='" + strEmptID + @"' and a.status_int =1
 union
 select aa.recipeid_chr, aa.recipename_chr, aa.privilege_int, aa.usercode_chr, aa.wbcode_chr, aa.pycode_chr, aa.status_int, aa.createrid_chr, aa.flag_int, aa.diseasename_vchr,cc.lastname_vchr from t_aid_concertrecipe aa,
 ( select a.recipeid_chr from t_aid_concertrecipedept a where a.deptid_chr
 in (select deptid_chr from t_bse_deptemp where empid_chr ='" + strEmptID + @"')) bb,t_bse_employee cc
  where aa.recipeid_chr(+) =bb.recipeid_chr and aa.createrid_chr=cc.empid_chr and aa.privilege_int =2 
  and aa.status_int =1";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
            string strSQL = @"SELECT a.recipeid_chr, a.detailid_chr, a.itemid_chr, a.qty_dec, a.freqid_chr, a.dosetype_chr, a.dosageqty_dec, a.days_int, a.rowno_chr, a.partortype_vchr, a.flag_int, a.partortypename_vchr, a.sort_int,b.itemname_vchr,b.itemcatid_chr,b.itemspec_vchr,b.itemopunit_chr,b.itemprice_mny ,d.usagename_vchr,e.freqname_chr from t_aid_concertrecipedetail a,t_bse_chargeitem b,t_aid_concertrecipe c ,t_bse_usagetype d,t_aid_recipefreq e where a.dosetype_chr=d.usageid_chr(+)and a.freqid_chr=e.freqid_chr(+) and  a.itemid_chr = b.itemid_chr and a.recipeid_chr = c.recipeid_chr and c.createrid_chr='" + strID + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
            string strSQL = @"SELECT a.*,c.DEPTNAME_VCHR FROM T_AID_CONCERTRECIPEDEPT a,T_AID_CONCERTRECIPE b,T_BSE_DEPTDESC c WHERE a.DEPTID_CHR = c.DEPTID_CHR and a.RECIPEID_CHR = b.RECIPEID_CHR and b.CREATERID_CHR='" + strReciptID + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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
        public long m_lngGetChargeByDate(System.Security.Principal.IPrincipal objPri, string strDateStart, string strDateEnd, out DataTable dt, bool p_blnOnlySelectVip, bool isWechatRePrt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByDate");
            if (lngRes < 0) return lngRes;
            string strSQL = @"select d.patientcardid_chr,
                                   a.invoiceno_vchr,
                                   r.repprninvono_vchr,
                                   a.seqid_chr,
                                   c.paytypename_vchr as internaltype,
                                   a.patientname_chr,
                                   b.sex_chr,
                                   case 
                                     when a.paytype_int=0 then
                                      '现金'
                                     when a.paytype_int=1 then
                                      '银行卡'
                                     when a.paytype_int=2 then
                                      '支票'
                                     when a.paytype_int=3 then
                                      'IC卡'
                                     when a.paytype_int=5 then
                                      '微信2'
                                     when a.paytype_int=8 then
                                      '微信'
                                     when a.paytype_int=9 then
                                      '支付宝'
                                   end as paytypename,
                                   a.invdate_dat,
                                   case
                                     when a.status_int = 1 then
                                      '正常'
                                     when a.status_int = 2 then
                                      '退票'
                                     when a.status_int = 3 then
                                      '恢复'
                                   end as statusname,
                                   a.deptname_chr,
                                   h.lastname_vchr as doctorname_chr,
                                   case
                                     when a.balanceflag_int = 0 then
                                      '未结帐 '
                                     when a.balanceflag_int = 1 then
                                      '已结帐'
                                   end as balancename,
                                   a.recorddate_dat,
                                   e.empno_chr as opremp_chr,
                                   f.empno_chr as balanceemp_chr,
                                   a.acctsum_mny,
                                   a.sbsum_mny,
                                   a.totalsum_mny,
                                   a.outpatrecipeid_chr,
                                   a.seqid_chr,
                                   b.employer_vchr,                                   
                                   round(a.totaldiffcost_mny, 2),
                                   (a.totalsum_mny - a.totaldiffcost_mny) as totalpay
                              from t_opr_outpatientrecipeinv a,
                                   t_bse_patient             b,
                                   t_bse_patientpaytype      c,
                                   t_bse_patientcard         d,
                                   t_bse_employee            e,
                                   t_bse_employee            f,
                                   t_bse_employee            h,
                                   t_opr_invoicerepeatprint  r 
                             where a.recorddate_dat between to_date('{0}', 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                               and a.patientid_chr = b.patientid_chr
                               and a.paytypeid_chr = c.paytypeid_chr
                               and a.patientid_chr = d.patientid_chr
                               and a.opremp_chr = e.empid_chr
                               and a.balanceemp_chr = f.empid_chr(+)                            
                               and a.doctorid_chr = h.empid_chr
                               and a.seqid_chr = r.seqid_chr(+) 
                            ";
            if (p_blnOnlySelectVip == true)
            {
                strSQL = strSQL + " and a.isvouchers_int = 2";
            }
            if (isWechatRePrt)
            {
                string sub = @" and a.seqid_chr in 
                                (select a.seqid_chr
                                  from t_opr_outpatientrecipeinv a, t_opr_invoicerepeatprint b
                                 where a.seqid_chr = b.seqid_chr
                                   and b.type_chr = '1'
                                   and a.opremp_chr = '0000000'
                                   and (a.recorddate_dat between to_date('{0}', 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')))";
                sub = string.Format(sub, strDateStart + " 00:00:00", strDateEnd + " 23:59:59");
                strSQL += sub;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService svc = new clsHRPTableService();
                strSQL = string.Format(strSQL, strDateStart + " 00:00:00", strDateEnd + " 23:59:59");
                lngRes = svc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
            string strSQL = @"select d.patientcardid_chr,
                                       a.invoiceno_vchr,
                                       a.seqid_chr,
                                       c.paytypename_vchr as internaltype,
                                       a.patientname_chr,
                                       b.sex_chr,
                                       case 
                                         when a.paytype_int=0 then
                                          '现金'
                                         when a.paytype_int=1 then
                                          '银行卡'
                                         when a.paytype_int=2 then
                                          '支票'
                                         when a.paytype_int=3 then
                                          'IC卡'
                                         when a.paytype_int=5 then
                                          '微信2'
                                         when a.paytype_int=8 then
                                          '微信'
                                         when a.paytype_int=9 then
                                          '支付宝'
                                       end as paytypename,
                                       a.invdate_dat,
                                       case
                                         when a.status_int = 1 then
                                          '正常'
                                         when a.status_int = 2 then
                                          '退票'
                                         when a.status_int = 3 then
                                          '恢复'
                                       end as statusname,
                                       a.deptname_chr,
                                       h.lastname_vchr as doctorname_chr,
                                       case
                                         when a.balanceflag_int = 0 then
                                          '未结帐 '
                                         when a.balanceflag_int = 1 then
                                          '已结帐'
                                       end as balancename,
                                       a.recorddate_dat,
                                       e.empno_chr as opremp_chr,
                                       f.empno_chr as balanceemp_chr,
                                       a.acctsum_mny,
                                       a.sbsum_mny,
                                       a.totalsum_mny,
                                       a.outpatrecipeid_chr,
                                       a.seqid_chr,
                                       b.employer_vchr
                                  from t_opr_outpatientrecipeinv a,
                                       t_bse_patient             b,
                                       t_bse_patientpaytype      c,
                                       t_bse_patientcard         d,
                                       t_bse_employee            e,
                                       t_bse_employee            f,
                                       t_bse_employee            h
                                 where a.patientid_chr = b.patientid_chr
                                   and a.paytypeid_chr = c.paytypeid_chr
                                   and a.patientid_chr = d.patientid_chr
                                   and a.opremp_chr = e.empid_chr
                                   and a.balanceemp_chr = f.empid_chr(+)
                                   and a.doctorid_chr = h.empid_chr
                                ";
            try
            {

                int m_intStatus = -1;
                switch (m_strArr[0].Trim())
                {
                    case "诊疗卡号": strSQL += "and d.PATIENTCARDID_CHR='" + m_strArr[1].Trim() + "'"; break;
                    case "发票编号": strSQL += "and a.INVOICENO_VCHR like '%" + m_strArr[1].Trim() + "%'"; break;
                    case "病人身份": strSQL += "and c.PAYTYPENAME_VCHR like '%" + m_strArr[1].Trim() + "%'"; break;
                    case "病人名称": strSQL += "and a.PATIENTNAME_CHR like '%" + m_strArr[1].Trim() + "%'"; break;
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
                    case "科室名称": strSQL += "and a.DEPTNAME_CHR like '%" + m_strArr[1].Trim() + "%'"; break;
                    case "医生名称": strSQL += "and h.LASTNAME_VCHR like '%" + m_strArr[1].Trim() + "%'"; break;
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
                    case "收费员": strSQL += "and e.EMPNO_CHR like '%" + m_strArr[1].Trim() + "%'"; break;
                    case "结帐员": strSQL += "and f.EMPNO_CHR like '%" + m_strArr[1].Trim() + "%'"; break;
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
            string strSQL = @"select d.patientcardid_chr,a.invoiceno_vchr ,a.seqid_chr,
                                     c.paytypename_vchr as internaltype,a.patientname_chr,
                                     b.sex_chr,case when a.paytype_int=0 then '现金' when a.paytype_int=1 then '银行卡' when a.paytype_int=2 then '支票' when a.paytype_int=3 then 'IC卡' when a.paytype_int=5 then '微信2' when a.paytype_int=8 then '微信' when a.paytype_int=9 then '支付宝' end as paytypename,
                                     a.invdate_dat,case when a.status_int=1 then '正常' when a.status_int=2 then '退票' when a.status_int=3 then '恢复' end as statusname, 
                                     a.deptname_chr,h.lastname_vchr as doctorname_chr,case when a.balanceflag_int=0 then '未结帐 ' when a.balanceflag_int=1 then '已结帐' end as balancename,
                                     a.recorddate_dat,e.empno_chr as opremp_chr,f.empno_chr as balanceemp_chr,a.acctsum_mny,a.sbsum_mny,a.totalsum_mny ,a.outpatrecipeid_chr,a.seqid_chr ,b.employer_vchr,
                                     a.totaldiffcost_mny,(a.totalsum_mny-a.totaldiffcost_mny) as totalpay
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
                                 and (a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                 and (a.opremp_chr = '" + m_strEmpID + "' or a.recordemp_chr = '" + m_strEmpID + @"') ";

            try
            {

                int m_intStatus = -1;
                switch (m_strArr[0].Trim())
                {
                    case "诊疗卡号": strSQL += "and d.patientcardid_chr='" + m_strArr[1].Trim() + "'"; break;
                    case "发票编号": strSQL += "and a.invoiceno_vchr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "病人身份": strSQL += "and c.paytypename_vchr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "病人名称": strSQL += "and a.patientname_chr like'%" + m_strArr[1].Trim() + "%'"; break;
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
                        else if (m_strArr[1].Trim() == "微信2")
                        {
                            m_intStatus = 5;
                        }
                        else if (m_strArr[1].Trim() == "微信")
                        {
                            m_intStatus = 8;
                        }
                        else if (m_strArr[1].Trim() == "支付宝")
                        {
                            m_intStatus = 9;
                        }
                        strSQL += "and a.paytype_int=" + m_intStatus + ""; break;
                    case "发票日期": strSQL += "and a.invdate_dat=to_date('" + m_strArr[1].Trim() + "','yyyy-mm-dd hh24:mi:ss')"; break;
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
                        strSQL += "and a.status_int=" + m_intStatus + ""; break;
                    case "科室名称": strSQL += "and a.deptname_chr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "医生名称": strSQL += "and h.lastname_vchr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "缴费状态":
                        if (m_strArr[1].Trim() == "未结帐")
                        {
                            m_intStatus = 0;
                        }
                        else if (m_strArr[1].Trim() == "已结帐")
                        {
                            m_intStatus = 1;
                        }
                        strSQL += "and a.balanceflag_int=" + m_intStatus + ""; break;
                    case "收费员": strSQL += "and e.empno_chr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "结帐员": strSQL += "and f.empno_chr like'%" + m_strArr[1].Trim() + "%'"; break;
                    case "记录时间": strSQL += "and a.recorddate_dat between to_date('" + m_strArr[1] + " 00:00:00'" + ",'yyyy-mm-dd hh24:mi:ss') and to_date('" + m_strArr[1] + " 23:59:59'" + ",'yyyy-mm-dd hh24:mi:ss') "; break;
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
        /// 根据操作员(收费员)ID及时间段查询发票信息
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="empid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeByempid(System.Security.Principal.IPrincipal objPri, string strDateStart, string strDateEnd, string empid, out DataTable dt, bool p_blnOnlySelectVip, bool isWechatRePrt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByempid");
            if (lngRes < 0)
            {
                return lngRes;
            }

            string strSQL = @"select d.patientcardid_chr,a.invoiceno_vchr, r.repprninvono_vchr, a.seqid_chr,
                                     c.paytypename_vchr as internaltype,a.patientname_chr,
                                     b.sex_chr,case when a.paytype_int=0 then '现金' when a.paytype_int=1 then '银行卡' when a.paytype_int=2 then '支票' when a.paytype_int=3 then 'IC卡' when a.paytype_int=5 then '微信2' when a.paytype_int=8 then '微信' when a.paytype_int=9 then '支付宝' end as paytypename,
                                     a.invdate_dat,case when a.status_int=1 then '正常' when a.status_int=2 then '退票' when a.status_int=3 then '恢复' end as statusname, 
                                     a.deptname_chr,h.lastname_vchr as doctorname_chr,case when a.balanceflag_int=0 then '未结帐 ' when a.balanceflag_int=1 then '已结帐' end as balancename,
                                     a.recorddate_dat,e.empno_chr as opremp_chr,f.empno_chr as balanceemp_chr,a.acctsum_mny,a.sbsum_mny,a.totalsum_mny ,a.outpatrecipeid_chr,a.seqid_chr ,b.employer_vchr, 
                                     round(a.totaldiffcost_mny,2),(a.totalsum_mny-a.totaldiffcost_mny) as totalpay
                                from t_opr_outpatientrecipeinv a,
                                     t_bse_patient b,
                                     t_bse_patientpaytype c,
                                     t_bse_patientcard d,
                                     t_bse_employee e,
                                     t_bse_employee f,
                                     t_bse_employee h,
                                     t_opr_invoicerepeatprint r 
                               where a.patientid_chr = b.patientid_chr
                                 and a.paytypeid_chr = c.paytypeid_chr
                                 and a.patientid_chr = d.patientid_chr
                                 and a.opremp_chr = e.empid_chr
                                 and a.balanceemp_chr = f.empid_chr(+)
                                 and a.doctorid_chr = h.empid_chr 
                                 and (a.isvouchers_int <> 2 or a.isvouchers_int is null) 
                                 and a.seqid_chr = r.seqid_chr(+)
                                 and (a.opremp_chr = '" + empid + "' or a.recordemp_chr = '" + empid + @"')
                                 and a.recorddate_dat between to_date('" + strDateStart + " 00:00:00'" + ",'yyyy-mm-dd hh24:mi:ss') and to_date('" + strDateEnd + " 23:59:59'" + ",'yyyy-mm-dd hh24:mi:ss')";
            if (p_blnOnlySelectVip == true)
            {
                strSQL = strSQL + " and a.isvouchers_int = 2";
            }
            if (isWechatRePrt)
            {
                string sub = @" and a.seqid_chr in 
                                (select a.seqid_chr
                                  from t_opr_outpatientrecipeinv a, t_opr_invoicerepeatprint b
                                 where a.seqid_chr = b.seqid_chr
                                   and b.type_chr = '1'
                                   and a.opremp_chr = '0000000'
                                   and (a.recorddate_dat between to_date('{0}', 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')))";
                sub = string.Format(sub, strDateStart + " 00:00:00", strDateEnd + " 23:59:59");
                strSQL += sub;
            }

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
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select setstatus_int from t_sys_setting where  setid_chr='" + strsetid + "'";
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
            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["setstatus_int"].ToString()) == 1)
            {
                blIS = true;
            }
            return lngRes;
        }

        #endregion

        #region 获取配置信息
        /// <summary>
        /// 获取配置信息
        /// by huafeng.xiao
        /// 2009年9月15日9:31:13
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStatus">返回状态，适合多状态开关使用</param>
        /// <param name="strsetid">配置ID号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCollocateStatus(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strStatus, string strsetid)
        {
            long lngRes = 0;
            p_strStatus = string.Empty;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetCollocateStatus");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select setstatus_int from t_sys_setting where  setid_chr='" + strsetid + "'";
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
            if (dt != null && dt.Rows.Count > 0)
            {
                p_strStatus = dt.Rows[0]["setstatus_int"].ToString();
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
        public long m_lngGetRecipeDate(System.Security.Principal.IPrincipal objPri, string recipeNO, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetChargeByDate");
            if (lngRes < 0)
                return lngRes;

            #region old bak
            //            string strSQL = @"select D.NAME,D.DEC,D.COUNT,D.PRICE,d.pdcarea_vchr,d.UINT,C.DOCTORNAME_CHR,C.sbsum_mny,C.ACCTSUM_MNY,e.LASTNAME_VCHR  From t_opr_outpatientrecipeinv C,
            //				(select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME, a.UNITID_CHR   UINT,
            //				B.ITEMSPEC_VCHR DEC,A.TOLQTY_DEC COUNT,b.PDCAREA_VCHR ,A.UNITPRICE_MNY PRICE
            //				from t_opr_outpatientpwmrecipede A,t_bse_chargeitem B
            //				where A.ITEMID_CHR=B.itemid_chr(+)
            //				union all
            //				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME, a.UNITID_CHR   UINT,
            //				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.UNITPRICE_MNY PRICE
            //				from t_opr_outpatientcmrecipede A,t_bse_chargeitem B
            //				where A.ITEMID_CHR=B.itemid_chr(+)
            //				union all
            //				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,b.ITEMUNIT_CHR   UINT,
            //				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.PRICE_MNY PRICE
            //				from t_opr_outpatientchkrecipede A,t_bse_chargeitem B
            //				where A.ITEMID_CHR=B.itemid_chr(+)
            //				union all
            //				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME,b.ITEMUNIT_CHR   UINT,
            //				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.PRICE_MNY PRICE
            //				from t_opr_outpatienttestrecipede A,t_bse_chargeitem B
            //				where A.ITEMID_CHR=B.itemid_chr(+)
            //				UNION ALL
            //				SELECT a.outpatrecipeid_chr ID, b.itemname_vchr NAME,b.ITEMUNIT_CHR   UINT,
            //					b.itemspec_vchr DEC, a.qty_dec COUNT,b.PDCAREA_VCHR, a.price_mny price
            //				FROM t_opr_outpatientopsrecipede a, t_bse_chargeitem b
            //				WHERE a.itemid_chr = b.itemid_chr(+)
            //				union  all
            //				select A.OUTPATRECIPEID_CHR ID,B.itemname_vchr NAME, a.UNITID_CHR  UINT,
            //				B.ITEMSPEC_VCHR DEC,A.QTY_DEC COUNT,b.PDCAREA_VCHR ,A.UNITPRICE_MNY PRICE
            //				from t_opr_outpatientothrecipede A,t_bse_chargeitem B
            //				where A.ITEMID_CHR=B.itemid_chr(+)) D,t_bse_employee e
            //				where  c.OPREMP_CHR = e.EMPID_CHR(+) and C.OUTPATRECIPEID_CHR=D.ID(+)
            //				AND C.SEQID_CHR= '" + recipeNO + "'";
            #endregion

            #region new
            string strSQLNew = @"
                            select d.name, d.dec, d.count, d.price, d.pdcarea_vchr, d.uint,
                                   c.doctorname_chr, c.sbsum_mny, c.acctsum_mny, e.lastname_vchr,d.toldiffprice_mny
                              from t_opr_outpatientrecipeinv c,
                                   (select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                           a.unitid_chr uint, a.itemspec_vchr dec, a.tolqty_dec count,
                                           b.pdcarea_vchr, a.unitprice_mny price,a.toldiffprice_mny
                                      from t_opr_outpatientpwmrecipede a, t_bse_chargeitem b
                                     where a.itemid_chr = b.itemid_chr(+)
                                    union all
                                    select a.outpatrecipeid_chr id, b.itemname_vchr name,
                                           a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec*a.times_int count,
                                           b.pdcarea_vchr, a.unitprice_mny price,a.toldiffprice_mny
                                      from t_opr_outpatientcmrecipede a, t_bse_chargeitem b
                                     where a.itemid_chr = b.itemid_chr(+)
                                    union all
                                    select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                           b.pdcarea_vchr, a.price_mny price,0 as toldiffprice_mny
                                      from t_opr_outpatientchkrecipede a, t_bse_chargeitem b
                                     where a.itemid_chr = b.itemid_chr(+)
                                    union all
                                    select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                           b.pdcarea_vchr, a.price_mny price,0 as toldiffprice_mny
                                      from t_opr_outpatienttestrecipede a, t_bse_chargeitem b
                                     where a.itemid_chr = b.itemid_chr(+)
                                    union all
                                    select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                           b.pdcarea_vchr, a.price_mny price,0 as toldiffprice_mny
                                      from t_opr_outpatientopsrecipede a, t_bse_chargeitem b
                                     where a.itemid_chr = b.itemid_chr(+)
                                    union all
                                    select a.outpatrecipeid_chr id, a.itemname_vchr name,
                                           a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec count,
                                           b.pdcarea_vchr, a.unitprice_mny price,a.toldiffprice_mny
                                      from t_opr_outpatientothrecipede a, t_bse_chargeitem b
                                     where a.itemid_chr = b.itemid_chr(+)) d,
                                   t_bse_employee e
                             where c.opremp_chr = e.empid_chr(+)
                               and c.outpatrecipeid_chr = d.id(+)
                               and c.seqid_chr = '" + recipeNO + "'";
            #endregion

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQLNew, ref dt);
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
            string strSQL = @"select   decode (b.internalflag_int,
               5, c.insuranceid_vchr,
               2, c.insuranceid_vchr,
               3, c.difficulty_vchr,
               ''
              ) as certificateno
  from t_opr_outpatientrecipeinv a, t_bse_patientpaytype b, t_bse_patient c
 where a.paytypeid_chr = b.paytypeid_chr
   and a.patientid_chr = c.patientid_chr(+)
   and b.internalflag_int > 0
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
            string strSQL = @"select d.patientcardid_chr,a.invoiceno_vchr ,a.outpatrecipeid_chr,c.paytypename_vchr as internaltype,a.patientname_chr,b.sex_chr,case when a.paytype_int=0 then '现金' when a.paytype_int=1 then '刷卡' when a.paytype_int=3 then '支票' when a.paytype_int=5 then '微信2' when a.paytype_int=8 then '微信' when a.paytype_int=9 then '支付宝' end as paytypename,a.invdate_dat,a.deptname_chr,h.lastname_vchr as doctorname_chr,e.empno_chr as opremp_chr,a.acctsum_mny,a.sbsum_mny,a.totalsum_mny,case when c.internalflag_int=0 then '自费' when c.internalflag_int=1 then '公费' when c.internalflag_int=2 then '医保' when c.internalflag_int>2 then '其它' end as patientype  from t_opr_outpatientrecipeinv a ,t_bse_patient b,t_bse_patientpaytype c,t_bse_patientcard d,t_bse_employee e,t_bse_employee h  where a.recorddate_dat  between to_date('" + strDateStart + " 00:00:00'" + ",'yyyy-mm-dd hh24:mi:ss') and to_date('" + strDateEnd + " 23:59:59'" + ",'yyyy-mm-dd hh24:mi:ss') and a.patientid_chr=b.patientid_chr and a.paytypeid_chr=c.paytypeid_chr and a.patientid_chr=d.patientid_chr and a.opremp_chr=e.empid_chr and a.doctorid_chr=h.empid_chr";
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
            string SQL = @"select invoiceno_vchr,
       outpatrecipeid_chr,
       invdate_dat,
       acctsum_mny,
       sbsum_mny,
       opremp_chr,
       recordemp_chr,
       recorddate_dat,
       status_int,
       seqid_chr,
       balanceemp_chr,
       balance_dat,
       balanceflag_int,
       totalsum_mny,
       paytype_int,
       patientid_chr,
       patientname_chr,
       deptid_chr,
       deptname_chr,
       doctorid_chr,
       doctorname_chr,
       confirmemp_chr,
       paytypeid_chr,
       internalflag_int,
       baseseqid_chr,
       groupid_chr,
       confirmdeptid_chr,
       split_int,
       regno_chr,
       chargedeptid_chr from t_opr_outpatientrecipeinv where seqid_chr = '" + seqid + "'";

            dtRecord = new DataTable();

            try
            {
                clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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
            string strSQL = @"select b.typeid_chr,b.typename_vchr,a.tolfee_mny from t_opr_outpatientrecipeinvde a,t_bse_chargeitemextype b where a.invoiceno_vchr='" + strINVOICENO + "' and a.seqid_chr='" + strSEQID + "' and a.itemcatid_chr=b.typeid_chr and b.flag_int=2";
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
            string strSQL = @"select a.registertypeid_chr,a.chargeid_chr,a.paytypeid_chr,a.payment_mny,a.discount_dec, 
                            b.registertypename_vchr,c.chargename_chr,d.paytypename_vchr from 
							t_bse_registerdetail a, t_bse_registertype b,t_bse_registerchargetype c,
							t_bse_patientpaytype d 
							where a.registertypeid_chr=b.registertypeid_chr(+) and
							a.chargeid_chr=c.chargeid_chr(+) and
							a.paytypeid_chr=d.paytypeid_chr and b.isusing_num=1 and c.isusing_num = 1 and d.isusing_num=1 order by a.registertypeid_chr,a.chargeid_chr,a.paytypeid_chr";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            return lngRes;

        }
        [AutoComplete]
        public long m_lngSave(System.Security.Principal.IPrincipal objPri, string ID1, string ID2, string ID3, string PAYMENT_MNY, string DISCOUNT_DEC)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngSave");
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"update t_bse_registerdetail set payment_mny ='" + PAYMENT_MNY + "',discount_dec='" + DISCOUNT_DEC + @"' where
registertypeid_chr='" + ID1 + "' and chargeid_chr ='" + ID2 + "'and paytypeid_chr ='" + ID3 + "'";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
            lngRes = HRPSvc.DoExcute(strSQL);
            return lngRes;
        }
    }
}
