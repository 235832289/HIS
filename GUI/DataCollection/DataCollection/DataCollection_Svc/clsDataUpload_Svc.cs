using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.OracleClient;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace com.digitalwave.iCare.middletier.DataCollection
{
    /// <summary>
    /// 数据上传中间件函数集
    /// kenny created in 2008.10.20
    /// </summary>
    [ObjectPooling(Enabled = true)]
    [Transaction(TransactionOption.Required)]
    public class clsDataUpload_Svc : System.EnterpriseServices.ServicedComponent
    {
        public clsDataUpload_Svc()
        {
            //
            // TODO: 在此添加构造函数逻辑
            //
        }

        #region 门诊就诊信息上报
        /// <summary>
        /// 门诊就诊信息上报
        /// </summary>
        /// <param name="p_arrOpdiagInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadDiagInfo(com.digitalwave.iCare.ValueObject.clsOpDiagInfo_VO p_arrOpdiagInfo_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;

            string strSQL = string.Empty;
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();

                bool blnExists = false;

                #region 根据处方id验证记录是否存在
                strSQL = @"select 1 from hosp_clinicrecord where visitno = :1";
                OracleCommand objCommand_Query = new OracleCommand(strSQL, objConn);
                OracleParameter objParmArr_Query =  new OracleParameter("1", OracleType.VarChar, 50);
                objParmArr_Query.Value = p_arrOpdiagInfo_VO.m_strVISITNO;
                objCommand_Query.Parameters.Add(objParmArr_Query);
                OracleDataAdapter objAdapter = new OracleDataAdapter();
                objAdapter.SelectCommand = objCommand_Query;
                System.Data.DataTable dtbTemp = new System.Data.DataTable();
                objAdapter.Fill(dtbTemp);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    blnExists = true;
                }
                #endregion

                if (!blnExists)
                {
                    #region 如果不存在，insert
                    strSQL = @"insert into hosp_clinicrecord
                                     (organcode,name, sex, kind, ethnicgroup, address, jobtitle,
                                      phonenumberhome, contactperson, nationality, maritalstatus,
                                      birthday, idnumbers, ssid, clinicno,
                                      visitno, clinicdatetime, deptcode, deptname,
                                      cliniciancode, clinicianname, pv2, pv3, pv1, diagnosisname1,
                                      diagnosiscode1, diagnosisname2, diagnosiscode2, diagnosisname3,
                                      diagnosiscode3,
                                        regtypecode,regtypename,job,native_place,systemdate)
                              values (:1,:2, :3, :4, :5, :6, :7,
                                      :8, :9, :10, :11,
                                      :12, :13, :14, :15,
                                      :16, :17, :18, :19,
                                      :20, :21, :22, :23, :24, :25,
                                      :26, :27, :28, :29,
                                      :30,:31,:32,:33,:34,:35)";
                    OracleCommand objCommand = new OracleCommand(strSQL, objConn);
                    OracleParameter[] objParmArr = new OracleParameter[35];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                    objParmArr[0].Value = p_arrOpdiagInfo_VO.m_strORGANCODE;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                    objParmArr[1].Value = p_arrOpdiagInfo_VO.m_strNAME;
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 1);
                    objParmArr[2].Value = p_arrOpdiagInfo_VO.m_strSEX;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 2);
                    objParmArr[3].Value = p_arrOpdiagInfo_VO.m_strKIND;
                    objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 2);
                    objParmArr[4].Value = p_arrOpdiagInfo_VO.m_strETHNICGROUP;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                    objParmArr[5].Value = p_arrOpdiagInfo_VO.m_strADDRESS;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                    objParmArr[6].Value = p_arrOpdiagInfo_VO.m_strJOBTITLE;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 18);
                    objParmArr[7].Value = p_arrOpdiagInfo_VO.m_strPHONENUMBERHOME;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                    objParmArr[8].Value = p_arrOpdiagInfo_VO.m_strCONTACTPERSON;
                    objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 5);
                    objParmArr[9].Value = p_arrOpdiagInfo_VO.m_strNATIONALITY;
                    objParmArr[10] = new OracleParameter("11", OracleType.Number, 1);
                    objParmArr[10].Value = p_arrOpdiagInfo_VO.m_intMARITALSTATUS;
                    objParmArr[11] = new OracleParameter("12", OracleType.DateTime);
                    if (p_arrOpdiagInfo_VO.m_strBIRTHDAY != string.Empty)
                    {
                        objParmArr[11].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strBIRTHDAY);
                    }
                    else
                    {
                        objParmArr[11].Value = DBNull.Value;
                    }
                    objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 18);
                    objParmArr[12].Value = p_arrOpdiagInfo_VO.m_strIDNUMBERS;
                    objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                    objParmArr[13].Value = p_arrOpdiagInfo_VO.m_strSSID;
                    objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                    objParmArr[14].Value = p_arrOpdiagInfo_VO.m_strCLINICNO;
                    objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                    objParmArr[15].Value = p_arrOpdiagInfo_VO.m_strVISITNO;// +DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                    objParmArr[16] = new OracleParameter("17", OracleType.DateTime);
                    if (p_arrOpdiagInfo_VO.m_strCLINICDATETIME != string.Empty)
                    {
                        objParmArr[16].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strCLINICDATETIME);
                    }
                    else
                    {
                        objParmArr[16].Value = new DateTime(1900, 1, 1);
                    }
                    objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 20);
                    objParmArr[17].Value = p_arrOpdiagInfo_VO.m_strDEPTCODE;
                    objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                    objParmArr[18].Value = p_arrOpdiagInfo_VO.m_strDEPTNAME;
                    objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                    objParmArr[19].Value = p_arrOpdiagInfo_VO.m_strCLINICIANCODE;
                    objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 50);
                    objParmArr[20].Value = p_arrOpdiagInfo_VO.m_strCLINICIANNAME;
                    objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 1024);
                    objParmArr[21].Value = p_arrOpdiagInfo_VO.m_strPV2;
                    objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 1024);
                    objParmArr[22].Value = p_arrOpdiagInfo_VO.m_strPV3;
                    objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 250);
                    objParmArr[23].Value = p_arrOpdiagInfo_VO.m_strPV1;
                    objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 200);
                    if (p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME1.Length > 100)
                    {
                        objParmArr[24].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME1.Substring(0, 100);
                    }
                    else
                    {
                        objParmArr[24].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME1;
                    }

                    objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 50);
                    objParmArr[25].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISCODE1;
                    objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 200);
                    if (p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME2.Length > 100)
                    {
                        objParmArr[26].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME2.Substring(0, 100);
                    }
                    else
                    {
                        objParmArr[26].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME2;
                    }

                    objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 50);
                    objParmArr[27].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISCODE2;
                    objParmArr[28] = new OracleParameter("29", OracleType.VarChar, 200);
                    if (p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME3.Length > 100)
                    {
                        objParmArr[28].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME3.Substring(0, 100);
                    }
                    else
                    {
                        objParmArr[28].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME3;
                    }

                    objParmArr[29] = new OracleParameter("30", OracleType.VarChar, 50);
                    objParmArr[29].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISCODE3;

                    objParmArr[30] = new OracleParameter("31", OracleType.VarChar, 10);
                    objParmArr[30].Value = p_arrOpdiagInfo_VO.m_strREGTYPECODE;
                    objParmArr[31] = new OracleParameter("32", OracleType.VarChar, 100);
                    objParmArr[31].Value = p_arrOpdiagInfo_VO.m_strREGTYPENAME;
                    objParmArr[32] = new OracleParameter("33", OracleType.VarChar, 50);
                    objParmArr[32].Value = p_arrOpdiagInfo_VO.m_strJOB;
                    objParmArr[33] = new OracleParameter("34", OracleType.VarChar, 50);
                    objParmArr[33].Value = p_arrOpdiagInfo_VO.m_strNATIVE_PLACE;
                    objParmArr[34] = new OracleParameter("35", OracleType.DateTime);
                    //objParmArr[34].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strSYSTEMDATE);
                    if (p_arrOpdiagInfo_VO.m_strSYSTEMDATE != string.Empty)
                    {
                        objParmArr[34].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strSYSTEMDATE);
                    }
                    else
                    {
                        objParmArr[34].Value = new DateTime(1900, 1, 1);
                    }
                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();
                    #endregion
                }
                else
                {
                    #region 如果存在，update
                    strSQL = @"update hosp_clinicrecord
                                   set organcode       = :1,
                                       name            = :2,
                                       sex             = :3,
                                       kind            = :4,
                                       ethnicgroup     = :5,
                                       address         = :6,
                                       jobtitle        = :7,
                                       phonenumberhome = :8,
                                       contactperson   = :9,
                                       nationality     = :10,
                                       maritalstatus   = :11,
                                       birthday        = :12,
                                       idnumbers       = :13,
                                       ssid            = :14,
                                       clinicno        = :15,
                                       clinicdatetime  = :16,
                                       deptcode        = :17,
                                       deptname        = :18,
                                       cliniciancode   = :19,
                                       clinicianname   = :20,
                                       pv2             = :21,
                                       pv3             = :22,
                                       pv1             = :23,
                                       diagnosisname1  = :24,
                                       diagnosiscode1  = :25,
                                       diagnosisname2  = :26,
                                       diagnosiscode2  = :27,
                                       diagnosisname3  = :28,
                                       diagnosiscode3  = :29,
                                       regtypecode     = :30,
                                       regtypename     = :31,
                                       job             = :32,
                                       native_place    = :33,
                                       systemdate      = :34
                                 where visitno = :35 ";
                    OracleCommand objCommand = new OracleCommand(strSQL, objConn);
                    OracleParameter[] objParmArr = new OracleParameter[35];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                    objParmArr[0].Value = p_arrOpdiagInfo_VO.m_strORGANCODE;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                    objParmArr[1].Value = p_arrOpdiagInfo_VO.m_strNAME;
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 1);
                    objParmArr[2].Value = p_arrOpdiagInfo_VO.m_strSEX;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 2);
                    objParmArr[3].Value = p_arrOpdiagInfo_VO.m_strKIND;
                    objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 2);
                    objParmArr[4].Value = p_arrOpdiagInfo_VO.m_strETHNICGROUP;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                    objParmArr[5].Value = p_arrOpdiagInfo_VO.m_strADDRESS;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                    objParmArr[6].Value = p_arrOpdiagInfo_VO.m_strJOBTITLE;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 18);
                    objParmArr[7].Value = p_arrOpdiagInfo_VO.m_strPHONENUMBERHOME;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                    objParmArr[8].Value = p_arrOpdiagInfo_VO.m_strCONTACTPERSON;
                    objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 5);
                    objParmArr[9].Value = p_arrOpdiagInfo_VO.m_strNATIONALITY;
                    objParmArr[10] = new OracleParameter("11", OracleType.Number, 1);
                    objParmArr[10].Value = p_arrOpdiagInfo_VO.m_intMARITALSTATUS;
                    objParmArr[11] = new OracleParameter("12", OracleType.DateTime);
                    if (p_arrOpdiagInfo_VO.m_strBIRTHDAY != string.Empty)
                    {
                        objParmArr[11].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strBIRTHDAY);
                    }
                    else
                    {
                        objParmArr[11].Value = DBNull.Value;
                    }
                    objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 18);
                    objParmArr[12].Value = p_arrOpdiagInfo_VO.m_strIDNUMBERS;
                    objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                    objParmArr[13].Value = p_arrOpdiagInfo_VO.m_strSSID;
                    objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                    objParmArr[14].Value = p_arrOpdiagInfo_VO.m_strCLINICNO;
                    objParmArr[15] = new OracleParameter("16", OracleType.DateTime);
                    if (p_arrOpdiagInfo_VO.m_strCLINICDATETIME != string.Empty)
                    {
                        objParmArr[15].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strCLINICDATETIME);
                    }
                    else
                    {
                        objParmArr[15].Value = new DateTime(1900, 1, 1);
                    }
                    objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 20);
                    objParmArr[16].Value = p_arrOpdiagInfo_VO.m_strDEPTCODE;
                    objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                    objParmArr[17].Value = p_arrOpdiagInfo_VO.m_strDEPTNAME;
                    objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                    objParmArr[18].Value = p_arrOpdiagInfo_VO.m_strCLINICIANCODE;
                    objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                    objParmArr[19].Value = p_arrOpdiagInfo_VO.m_strCLINICIANNAME;
                    objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 1024);
                    objParmArr[20].Value = p_arrOpdiagInfo_VO.m_strPV2;
                    objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 1024);
                    objParmArr[21].Value = p_arrOpdiagInfo_VO.m_strPV3;
                    objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 250);
                    objParmArr[22].Value = p_arrOpdiagInfo_VO.m_strPV1;
                    objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 200);
                    if (p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME1.Length > 100)
                    {
                        objParmArr[23].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME1.Substring(0, 100);
                    }
                    else
                    {
                        objParmArr[23].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME1;
                    }

                    objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                    objParmArr[24].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISCODE1;
                    objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 200);
                    if (p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME2.Length > 100)
                    {
                        objParmArr[25].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME2.Substring(0, 100);
                    }
                    else
                    {
                        objParmArr[25].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME2;
                    }

                    objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 50);
                    objParmArr[26].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISCODE2;
                    objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 200);
                    if (p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME3.Length > 100)
                    {
                        objParmArr[27].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME3.Substring(0, 100);
                    }
                    else
                    {
                        objParmArr[27].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISNAME3;
                    }

                    objParmArr[28] = new OracleParameter("29", OracleType.VarChar, 50);
                    objParmArr[28].Value = p_arrOpdiagInfo_VO.m_strDIAGNOSISCODE3;

                    objParmArr[29] = new OracleParameter("30", OracleType.VarChar, 10);
                    objParmArr[29].Value = p_arrOpdiagInfo_VO.m_strREGTYPECODE;
                    objParmArr[30] = new OracleParameter("31", OracleType.VarChar, 100);
                    objParmArr[30].Value = p_arrOpdiagInfo_VO.m_strREGTYPENAME;
                    objParmArr[31] = new OracleParameter("32", OracleType.VarChar, 50);
                    objParmArr[31].Value = p_arrOpdiagInfo_VO.m_strJOB;
                    objParmArr[32] = new OracleParameter("33", OracleType.VarChar, 50);
                    objParmArr[32].Value = p_arrOpdiagInfo_VO.m_strNATIVE_PLACE;
                    objParmArr[33] = new OracleParameter("34", OracleType.DateTime);
                    //objParmArr[33].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strSYSTEMDATE);

                    if (p_arrOpdiagInfo_VO.m_strSYSTEMDATE != string.Empty)
                    {
                        objParmArr[33].Value = DateTime.Parse(p_arrOpdiagInfo_VO.m_strSYSTEMDATE);
                    }
                    else
                    {
                        objParmArr[33].Value = new DateTime(1900, 1, 1);
                    }
                    objParmArr[34] = new OracleParameter("35", OracleType.VarChar, 50);
                    objParmArr[34].Value = p_arrOpdiagInfo_VO.m_strVISITNO;

                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();
                    #endregion
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion        

        #region 门诊费用信息上报
        /// <summary>
        /// 门诊费用信息上报
        /// </summary>
        /// <param name="p_arrOpfee_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadOpfee(com.digitalwave.iCare.ValueObject.clsOpfee_VO p_arrOpfee_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;
            string strSQL = @"insert into hosp_clinicbill
                                     (organcode,visitno, kind, totalfare, billno, farecode, farename,
                                      fareselfpay, amount, price, sum, billdate,
clinicbill_seq,deptcode,deptname,doctcode,doctname,itemid,itemkind,flag)
                              values (:1,:2, :3, :4, :5, :6, :7,
                                      :8, :9, :10, :11, :12,:13,:14,:15,:16,:17,:18,:19,:20)";
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objParmArr = new OracleParameter[20];
                objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objParmArr[0].Value = p_arrOpfee_VO.m_strORGANCODE;
                objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objParmArr[1].Value = p_arrOpfee_VO.m_strVISITNO;
                objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 10);
                objParmArr[2].Value = p_arrOpfee_VO.m_strKIND;
                objParmArr[3] = new OracleParameter("4", OracleType.Number, 8);
                objParmArr[3].Value = p_arrOpfee_VO.m_decTOTALFARE;
                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                objParmArr[4].Value = p_arrOpfee_VO.m_strBILLNO;
                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                objParmArr[5].Value = p_arrOpfee_VO.m_strFARECODE;
                objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                objParmArr[6].Value = p_arrOpfee_VO.m_strFARENAME;
                objParmArr[7] = new OracleParameter("8", OracleType.Number, 8);
                objParmArr[7].Value = p_arrOpfee_VO.m_decFARESELFPAY;
                objParmArr[8] = new OracleParameter("9", OracleType.Number);
                objParmArr[8].Value = p_arrOpfee_VO.m_decAMOUNT;
                objParmArr[9] = new OracleParameter("10", OracleType.Number, 18);
                objParmArr[9].Value = p_arrOpfee_VO.m_decPRICE;
                objParmArr[10] = new OracleParameter("11", OracleType.Number, 18);
                objParmArr[10].Value = p_arrOpfee_VO.m_decSUM;
                objParmArr[11] = new OracleParameter("12", OracleType.DateTime);
                objParmArr[11].Value = DateTime.Parse(p_arrOpfee_VO.m_strBILLDATE);

                objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                objParmArr[12].Value = p_arrOpfee_VO.m_strCLINICBILL_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                objParmArr[13].Value = p_arrOpfee_VO.m_strDEPTCODE;
                objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                objParmArr[14].Value = p_arrOpfee_VO.m_strDEPTNAME;
                objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                objParmArr[15].Value = p_arrOpfee_VO.m_strDOCTCODE;
                objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                objParmArr[16].Value = p_arrOpfee_VO.m_strDOCTNAME;
                objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 20);
                objParmArr[17].Value = p_arrOpfee_VO.m_strITEMID;
                objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 4);
                objParmArr[18].Value = p_arrOpfee_VO.m_strITEMKIND;
                objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 1);
                objParmArr[19].Value = p_arrOpfee_VO.m_strFLAG;


                for (int j = 0; j < objParmArr.Length; j++)
                {
                    objCommand.Parameters.Add(objParmArr[j]);
                }
                lngRes = objCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 门诊处方信息上报
        /// <summary>
        /// 门诊处方信息上报
        /// </summary>
        /// <param name="p_arrOpfee_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadRecInfo(com.digitalwave.iCare.ValueObject.clsRecInfo_VO p_arrRecInfo_VO)
        {
            long lngRes = 0;
            bool blnExists = false;
            OracleConnection objConn = null;
            string strConnection = m_strGetDbConnection();
            objConn = new OracleConnection(strConnection);
            objConn.Open();

            string strSQL = @"insert into hosp_recipe
                                     (organcode,recipe_seq,itemkind,itemid,itemsum,checksamname,
                                      checkmethodname,checkposition,explanation
                                      ,visitno,name,kind,recipegroup,usageremark,dosagenum,
                                      clinicdatetime, recipeid, recipetype,
                                      recipedatetime, doctcode, doctname,
                                      deptcode, deptname, itemcode, itemspec,
                                      itemname, itemusage, frequency, medicineunit,
                                      useamount, useunit, medicinedays, medicinescale, itemamount,
                                      itemprice, totalprice,billno,flag,jxbzdm)
                              values (:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14,:15,
                                      :16, :17, :18,
                                      :19, :20, :21,
                                      :22, :23, :24, :25,
                                      :26, :27, :28, :29,
                                      :30, :31, :32, :33, :34,
                                      :35, :36, :37, :38,:39)";

            #region 如果存在，update
            /*string strSQL1 = @"update hosp_recipe
                               set organcode        = :1,
                               recipe_seq           = :2,
                               itemkind             = :3,
                               itemid               = :4,
                               itemsum              = :5,
                               checksamname         = :6,
                               checkmethodname      = :7,
                               checkposition        = :8,
                               explanation          = :9,
                               visitno              = :10,
                               name                 = :11,
                               kind                 = :12,
                               recipegroup          = :13,
                               usageremark          = :14,
                               dosagenum            = :15,
                               clinicdatetime       = :16,
                               recipetype           = :17,
                               recipedatetime       = :18,
                               doctcode             = :19,
                               doctname             = :20,
                               deptcode             = :21,
                               deptname             = :22,
                               itemspec             = :23,
                               itemusage            = :24,
                               frequency            = :25,
                               medicineunit         = :26,
                               useamount            = :27,
                               useunit              = :28,
                               medicinedays         = :29,
                               medicinescale        = :30,
                               itemamount           = :31,
                               itemprice            = :32,
                               totalprice           = :33,
                               flag                 = :34,
                               jxbzdm               = :35
                         where itemcode = :36 and itemname= :37 and billno = :38 and recipeid = :39 ";*/
            string strSQL1 = @"update hosp_recipe
                               set organcode        = :1,
                               itemkind             = :2,
                               itemid               = :3,
                               itemsum              = :4,
                               checksamname         = :5,
                               checkmethodname      = :6,
                               checkposition        = :7,
                               explanation          = :8,
                               visitno              = :9,
                               name                 = :10,
                               kind                 = :11,
                               recipegroup          = :12,
                               usageremark          = :13,
                               dosagenum            = :14,
                               clinicdatetime       = :15,
                               recipetype           = :16,
                               recipedatetime       = :17,
                               doctcode             = :18,
                               doctname             = :19,
                               deptcode             = :20,
                               deptname             = :21,
                               itemspec             = :22,
                               itemusage            = :23,
                               frequency            = :24,
                               medicineunit         = :25,
                               useamount            = :26,
                               useunit              = :27,
                               medicinedays         = :28,
                               medicinescale        = :29,
                               itemamount           = :30,
                               itemprice            = :31,
                               totalprice           = :32,
                               flag                 = :33,
                               jxbzdm               = :34
                         where itemcode = :35 and itemname= :36 and billno = :37 and recipeid = :38 ";


            #endregion


            try
            {

                #region 根据处方id验证记录是否存在
                string strSQL2 = @"select 1 from hosp_recipe a where a.itemcode = :1 and a.itemname = :2 and a.billno = :3 and a.recipeid = :4 ";

                OracleCommand objCommand_Query = new OracleCommand(strSQL2, objConn);
                OracleParameter[] queryParmArr = new OracleParameter[4];

                queryParmArr[0] = new OracleParameter("1", OracleType.VarChar, 18);
                queryParmArr[0].Value = p_arrRecInfo_VO.m_strMedicineCode;
                queryParmArr[1] = new OracleParameter("2", OracleType.VarChar, 200);
                queryParmArr[1].Value = p_arrRecInfo_VO.m_strMedicineName;
                queryParmArr[2] = new OracleParameter("3", OracleType.VarChar, 50);
                queryParmArr[2].Value = p_arrRecInfo_VO.m_strBILLNO;
                queryParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                queryParmArr[3].Value = p_arrRecInfo_VO.m_strRecipeID;

                for (int j = 0; j < queryParmArr.Length; j++)
                {
                    objCommand_Query.Parameters.Add(queryParmArr[j]);
                }

                OracleDataAdapter objAdapter = new OracleDataAdapter();
                objAdapter.SelectCommand = objCommand_Query;
                System.Data.DataTable dtbTemp = new System.Data.DataTable();
                objAdapter.Fill(dtbTemp);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    blnExists = true;
                }
                #endregion


                if (!blnExists)
                {
                    OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                    OracleParameter[] objParmArr = new OracleParameter[39];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 20);
                    objParmArr[0].Value = p_arrRecInfo_VO.m_strORGANCODE;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                    objParmArr[1].Value = p_arrRecInfo_VO.m_strRECIPE_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 4);
                    objParmArr[2].Value = p_arrRecInfo_VO.m_strITEMKIND;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                    objParmArr[3].Value = p_arrRecInfo_VO.m_strITEMID;
                    objParmArr[4] = new OracleParameter("5", OracleType.Number, 18);
                    objParmArr[4].Value = p_arrRecInfo_VO.m_decITEMSUM;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 100);
                    objParmArr[5].Value = p_arrRecInfo_VO.m_strCHECKSAMNAME;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 100);
                    objParmArr[6].Value = p_arrRecInfo_VO.m_strCHECKMETHODNAME;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 256);
                    objParmArr[7].Value = p_arrRecInfo_VO.m_strCHECKPOSITION;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 500);
                    objParmArr[8].Value = p_arrRecInfo_VO.m_strEXPLANATION;
                    objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 20);
                    objParmArr[9].Value = p_arrRecInfo_VO.m_strVISITNO;
                    objParmArr[10] = new OracleParameter("11", OracleType.VarChar, 50);
                    objParmArr[10].Value = p_arrRecInfo_VO.m_strNAME;
                    objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 20);
                    objParmArr[11].Value = p_arrRecInfo_VO.m_strKIND;
                    objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 10);
                    objParmArr[12].Value = p_arrRecInfo_VO.m_strRECIPEGROUP;
                    objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 100);
                    objParmArr[13].Value = p_arrRecInfo_VO.m_strUSAGEREMARK;
                    objParmArr[14] = new OracleParameter("15", OracleType.Number);
                    objParmArr[14].Value = p_arrRecInfo_VO.m_decDOSAGENUM;
                    objParmArr[15] = new OracleParameter("16", OracleType.DateTime);
                    objParmArr[15].Value = DateTime.Parse(p_arrRecInfo_VO.m_strCLINICDATETIME);
                    objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 20);
                    objParmArr[16].Value = p_arrRecInfo_VO.m_strRecipeID;
                    objParmArr[17] = new OracleParameter("18", OracleType.Number, 50);
                    objParmArr[17].Value = p_arrRecInfo_VO.m_intRecipeType;
                    objParmArr[18] = new OracleParameter("19", OracleType.DateTime);
                    objParmArr[18].Value = DateTime.Parse(p_arrRecInfo_VO.m_strRecipeDateTime);
                    objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                    objParmArr[19].Value = p_arrRecInfo_VO.m_strRecipeClinicianCode;
                    objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 50);
                    objParmArr[20].Value = p_arrRecInfo_VO.m_strRecipeClinicianName;
                    //objParmArr[21] = new OracleParameter("23", OracleType.Number);
                    //objParmArr[21].Value = p_arrRecInfo_VO.m_intFlag;
                    objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 20);
                    objParmArr[21].Value = p_arrRecInfo_VO.m_strRecipeDeptCode;
                    objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 50);
                    objParmArr[22].Value = p_arrRecInfo_VO.m_strRecipeDeptName;
                    objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 18);
                    objParmArr[23].Value = p_arrRecInfo_VO.m_strMedicineCode;
                    objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                    objParmArr[24].Value = p_arrRecInfo_VO.m_strMedicineSpec;
                    objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 200);
                    objParmArr[25].Value = p_arrRecInfo_VO.m_strMedicineName;
                    objParmArr[26] = new OracleParameter("27", OracleType.Number);
                    if (p_arrRecInfo_VO.m_intMedicineUsage == 0)
                    {
                        objParmArr[26].Value = DBNull.Value;
                    }
                    else
                    {
                        objParmArr[26].Value = p_arrRecInfo_VO.m_intMedicineUsage;
                    }
                    objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 50);
                    objParmArr[27].Value = p_arrRecInfo_VO.m_strMedicineFrequency;
                    objParmArr[28] = new OracleParameter("29", OracleType.VarChar, 18);
                    objParmArr[28].Value = p_arrRecInfo_VO.m_strMedicineUnit;
                    objParmArr[29] = new OracleParameter("30", OracleType.VarChar, 50);
                    objParmArr[29].Value = p_arrRecInfo_VO.m_strMedicineDosage;
                    objParmArr[30] = new OracleParameter("31", OracleType.VarChar, 20);
                    objParmArr[30].Value = p_arrRecInfo_VO.m_strUseUnit;
                    objParmArr[31] = new OracleParameter("32", OracleType.VarChar, 20);
                    objParmArr[31].Value = p_arrRecInfo_VO.m_strMedicineDays;
                    objParmArr[32] = new OracleParameter("33", OracleType.Number);
                    objParmArr[32].Value = p_arrRecInfo_VO.m_decMedicineScale;
                    objParmArr[33] = new OracleParameter("34", OracleType.Number);
                    objParmArr[33].Value = p_arrRecInfo_VO.m_decUnitNumber;
                    objParmArr[34] = new OracleParameter("35", OracleType.Number, 18);
                    objParmArr[34].Value = Math.Round(p_arrRecInfo_VO.m_decUnitPrice, 2);
                    objParmArr[35] = new OracleParameter("36", OracleType.Number, 18);
                    objParmArr[35].Value = Math.Round(p_arrRecInfo_VO.m_decTotalPrice, 2);
                    //添加发票号和作废标识
                    objParmArr[36] = new OracleParameter("37", OracleType.VarChar, 50);
                    objParmArr[36].Value = p_arrRecInfo_VO.m_strBILLNO;
                    objParmArr[37] = new OracleParameter("38", OracleType.VarChar, 1);
                    objParmArr[37].Value = p_arrRecInfo_VO.m_strZfbz;
                    objParmArr[38] = new OracleParameter("39", OracleType.VarChar, 2);
                    objParmArr[38].Value = p_arrRecInfo_VO.m_strJXBZDM;

                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();
                }
                else
                {
                    /*OracleCommand objCommand = new OracleCommand(strSQL1, objConn);

                    OracleParameter[] objParmArr = new OracleParameter[39];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 20);
                    objParmArr[0].Value = p_arrRecInfo_VO.m_strORGANCODE;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                    objParmArr[1].Value = p_arrRecInfo_VO.m_strRECIPE_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 4);
                    objParmArr[2].Value = p_arrRecInfo_VO.m_strITEMKIND;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                    objParmArr[3].Value = p_arrRecInfo_VO.m_strITEMID;
                    objParmArr[4] = new OracleParameter("5", OracleType.Number, 18);
                    objParmArr[4].Value = p_arrRecInfo_VO.m_decITEMSUM;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 100);
                    objParmArr[5].Value = p_arrRecInfo_VO.m_strCHECKSAMNAME;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 100);
                    objParmArr[6].Value = p_arrRecInfo_VO.m_strCHECKMETHODNAME;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 256);
                    objParmArr[7].Value = p_arrRecInfo_VO.m_strCHECKPOSITION;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 500);
                    objParmArr[8].Value = p_arrRecInfo_VO.m_strEXPLANATION;
                    objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 20);
                    objParmArr[9].Value = p_arrRecInfo_VO.m_strVISITNO;
                    objParmArr[10] = new OracleParameter("11", OracleType.VarChar, 50);
                    objParmArr[10].Value = p_arrRecInfo_VO.m_strNAME;
                    objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 20);
                    objParmArr[11].Value = p_arrRecInfo_VO.m_strKIND;
                    objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 10);
                    objParmArr[12].Value = p_arrRecInfo_VO.m_strRECIPEGROUP;
                    objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 100);
                    objParmArr[13].Value = p_arrRecInfo_VO.m_strUSAGEREMARK;
                    objParmArr[14] = new OracleParameter("15", OracleType.Number);
                    objParmArr[14].Value = p_arrRecInfo_VO.m_decDOSAGENUM;
                    objParmArr[15] = new OracleParameter("16", OracleType.DateTime);
                    objParmArr[15].Value = DateTime.Parse(p_arrRecInfo_VO.m_strCLINICDATETIME);
                    objParmArr[16] = new OracleParameter("17", OracleType.Number, 50);
                    objParmArr[16].Value = p_arrRecInfo_VO.m_intRecipeType;
                    objParmArr[17] = new OracleParameter("18", OracleType.DateTime);
                    objParmArr[17].Value = DateTime.Parse(p_arrRecInfo_VO.m_strRecipeDateTime);
                    objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                    objParmArr[18].Value = p_arrRecInfo_VO.m_strRecipeClinicianCode;
                    objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                    objParmArr[19].Value = p_arrRecInfo_VO.m_strRecipeClinicianName;
                    objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 20);
                    objParmArr[20].Value = p_arrRecInfo_VO.m_strRecipeDeptCode;
                    objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 50);
                    objParmArr[21].Value = p_arrRecInfo_VO.m_strRecipeDeptName;
                    objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 50);
                    objParmArr[22].Value = p_arrRecInfo_VO.m_strMedicineSpec;

                    objParmArr[23] = new OracleParameter("24", OracleType.Number);
                    if (p_arrRecInfo_VO.m_intMedicineUsage == 0)
                    {
                        objParmArr[23].Value = DBNull.Value;
                    }
                    else
                    {
                        objParmArr[23].Value = p_arrRecInfo_VO.m_intMedicineUsage;
                    }
                    objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                    objParmArr[24].Value = p_arrRecInfo_VO.m_strMedicineFrequency;
                    objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 18);
                    objParmArr[25].Value = p_arrRecInfo_VO.m_strMedicineUnit;
                    objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 50);
                    objParmArr[26].Value = p_arrRecInfo_VO.m_strMedicineDosage;
                    objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 20);
                    objParmArr[27].Value = p_arrRecInfo_VO.m_strUseUnit;
                    objParmArr[28] = new OracleParameter("29", OracleType.VarChar, 20);
                    objParmArr[28].Value = p_arrRecInfo_VO.m_strMedicineDays;
                    objParmArr[29] = new OracleParameter("30", OracleType.Number);
                    objParmArr[29].Value = p_arrRecInfo_VO.m_decMedicineScale;
                    objParmArr[30] = new OracleParameter("31", OracleType.Number);
                    objParmArr[30].Value = p_arrRecInfo_VO.m_decUnitNumber;
                    objParmArr[31] = new OracleParameter("32", OracleType.Number, 18);
                    objParmArr[31].Value = Math.Round(p_arrRecInfo_VO.m_decUnitPrice, 2);
                    objParmArr[32] = new OracleParameter("33", OracleType.Number, 18);
                    objParmArr[32].Value = Math.Round(p_arrRecInfo_VO.m_decTotalPrice, 2);
                    objParmArr[33] = new OracleParameter("34", OracleType.VarChar, 1);
                    objParmArr[33].Value = p_arrRecInfo_VO.m_strZfbz;
                    objParmArr[34] = new OracleParameter("35", OracleType.VarChar, 2);
                    objParmArr[34].Value = p_arrRecInfo_VO.m_strJXBZDM;

                    objParmArr[35] = new OracleParameter("36", OracleType.VarChar, 18);
                    objParmArr[35].Value = p_arrRecInfo_VO.m_strMedicineCode;
                    objParmArr[36] = new OracleParameter("37", OracleType.VarChar, 200);
                    objParmArr[36].Value = p_arrRecInfo_VO.m_strMedicineName;
                    //添加发票号和作废标识
                    objParmArr[37] = new OracleParameter("38", OracleType.VarChar, 50);
                    objParmArr[37].Value = p_arrRecInfo_VO.m_strBILLNO;
                    objParmArr[38] = new OracleParameter("39", OracleType.VarChar, 20);
                    objParmArr[38].Value = p_arrRecInfo_VO.m_strRecipeID;

                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();*/

                    OracleCommand objCommand = new OracleCommand(strSQL1, objConn);

                    OracleParameter[] objParmArr = new OracleParameter[38];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 20);
                    objParmArr[0].Value = p_arrRecInfo_VO.m_strORGANCODE;
                    //objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                    //objParmArr[1].Value = p_arrRecInfo_VO.m_strRECIPE_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 4);
                    objParmArr[1].Value = p_arrRecInfo_VO.m_strITEMKIND;
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 20);
                    objParmArr[2].Value = p_arrRecInfo_VO.m_strITEMID;
                    objParmArr[3] = new OracleParameter("4", OracleType.Number, 18);
                    objParmArr[3].Value = p_arrRecInfo_VO.m_decITEMSUM;
                    objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 100);
                    objParmArr[4].Value = p_arrRecInfo_VO.m_strCHECKSAMNAME;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 100);
                    objParmArr[5].Value = p_arrRecInfo_VO.m_strCHECKMETHODNAME;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 256);
                    objParmArr[6].Value = p_arrRecInfo_VO.m_strCHECKPOSITION;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 500);
                    objParmArr[7].Value = p_arrRecInfo_VO.m_strEXPLANATION;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 20);
                    objParmArr[8].Value = p_arrRecInfo_VO.m_strVISITNO;
                    objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 50);
                    objParmArr[9].Value = p_arrRecInfo_VO.m_strNAME;
                    objParmArr[10] = new OracleParameter("11", OracleType.VarChar, 20);
                    objParmArr[10].Value = p_arrRecInfo_VO.m_strKIND;
                    objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 10);
                    objParmArr[11].Value = p_arrRecInfo_VO.m_strRECIPEGROUP;
                    objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 100);
                    objParmArr[12].Value = p_arrRecInfo_VO.m_strUSAGEREMARK;
                    objParmArr[13] = new OracleParameter("14", OracleType.Number);
                    objParmArr[13].Value = p_arrRecInfo_VO.m_decDOSAGENUM;
                    objParmArr[14] = new OracleParameter("15", OracleType.DateTime);
                    objParmArr[14].Value = DateTime.Parse(p_arrRecInfo_VO.m_strCLINICDATETIME);
                    objParmArr[15] = new OracleParameter("16", OracleType.Number, 50);
                    objParmArr[15].Value = p_arrRecInfo_VO.m_intRecipeType;
                    objParmArr[16] = new OracleParameter("17", OracleType.DateTime);
                    objParmArr[16].Value = DateTime.Parse(p_arrRecInfo_VO.m_strRecipeDateTime);
                    objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                    objParmArr[17].Value = p_arrRecInfo_VO.m_strRecipeClinicianCode;
                    objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                    objParmArr[18].Value = p_arrRecInfo_VO.m_strRecipeClinicianName;
                    objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 20);
                    objParmArr[19].Value = p_arrRecInfo_VO.m_strRecipeDeptCode;
                    objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 50);
                    objParmArr[20].Value = p_arrRecInfo_VO.m_strRecipeDeptName;
                    objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 50);
                    objParmArr[21].Value = p_arrRecInfo_VO.m_strMedicineSpec;

                    objParmArr[22] = new OracleParameter("23", OracleType.Number);
                    if (p_arrRecInfo_VO.m_intMedicineUsage == 0)
                    {
                        objParmArr[22].Value = DBNull.Value;
                    }
                    else
                    {
                        objParmArr[22].Value = p_arrRecInfo_VO.m_intMedicineUsage;
                    }
                    objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 50);
                    objParmArr[23].Value = p_arrRecInfo_VO.m_strMedicineFrequency;
                    objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 18);
                    objParmArr[24].Value = p_arrRecInfo_VO.m_strMedicineUnit;
                    objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 50);
                    objParmArr[25].Value = p_arrRecInfo_VO.m_strMedicineDosage;
                    objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 20);
                    objParmArr[26].Value = p_arrRecInfo_VO.m_strUseUnit;
                    objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 20);
                    objParmArr[27].Value = p_arrRecInfo_VO.m_strMedicineDays;
                    objParmArr[28] = new OracleParameter("29", OracleType.Number);
                    objParmArr[28].Value = p_arrRecInfo_VO.m_decMedicineScale;
                    objParmArr[29] = new OracleParameter("30", OracleType.Number);
                    objParmArr[29].Value = p_arrRecInfo_VO.m_decUnitNumber;
                    objParmArr[30] = new OracleParameter("31", OracleType.Number, 18);
                    objParmArr[30].Value = Math.Round(p_arrRecInfo_VO.m_decUnitPrice, 2);
                    objParmArr[31] = new OracleParameter("32", OracleType.Number, 18);
                    objParmArr[31].Value = Math.Round(p_arrRecInfo_VO.m_decTotalPrice, 2);
                    objParmArr[32] = new OracleParameter("33", OracleType.VarChar, 1);
                    objParmArr[32].Value = p_arrRecInfo_VO.m_strZfbz;
                    objParmArr[33] = new OracleParameter("34", OracleType.VarChar, 2);
                    objParmArr[33].Value = p_arrRecInfo_VO.m_strJXBZDM;

                    objParmArr[34] = new OracleParameter("35", OracleType.VarChar, 18);
                    objParmArr[34].Value = p_arrRecInfo_VO.m_strMedicineCode;
                    objParmArr[35] = new OracleParameter("36", OracleType.VarChar, 200);
                    objParmArr[35].Value = p_arrRecInfo_VO.m_strMedicineName;
                    //添加发票号和作废标识
                    objParmArr[36] = new OracleParameter("37", OracleType.VarChar, 50);
                    objParmArr[36].Value = p_arrRecInfo_VO.m_strBILLNO;
                    objParmArr[37] = new OracleParameter("38", OracleType.VarChar, 20);
                    objParmArr[37].Value = p_arrRecInfo_VO.m_strRecipeID;

                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                p_arrRecInfo_VO = null;
            }
            return lngRes;
        }
        #endregion

        #region 收费标准信息上报
        /// <summary>
        /// 收费标准信息上报
        /// </summary>
        /// <param name="p_arrChargeitem_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadChargeitemInfo(com.digitalwave.iCare.ValueObject.clsChargeStandard_VO p_arrChargeitem_VO)
        {
            #region old
//            long lngRes = 0;
//            OracleConnection objConn = null;
//            string strSQL = @"insert into Hosp_Charge
//                                (billcode,
//                                 billname,
//                                 unitprice,
//                                 collectdate,
//                                 spec,
//                                 unit,
//                                 reagent,
//                                 medspec,
//                                 billkind,
//                                 flbz)
//                              values
//                                (:1, :2, :3, :4, :5, :6, :7, :8,:9,:10)";
//            try
//            {
//                string strConnection = m_strGetDbConnection();
//                objConn = new OracleConnection(strConnection);
//                objConn.Open();
//                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

//                OracleParameter[] objParmArr = new OracleParameter[10];
//                objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 20);
//                objParmArr[0].Value = p_arrChargeitem_VO.m_strBILLCODE;
//                objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 100);
//                objParmArr[1].Value = p_arrChargeitem_VO.m_strBILLNAME;
//                objParmArr[2] = new OracleParameter("3", OracleType.Number);
//                objParmArr[2].Value = p_arrChargeitem_VO.m_decUNITPRICE;
//                objParmArr[3] = new OracleParameter("4", OracleType.DateTime);
//                objParmArr[3].Value = p_arrChargeitem_VO.m_datCOLLECTDATE;
//                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
//                objParmArr[4].Value = p_arrChargeitem_VO.m_strSPEC;
//                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 20);
//                objParmArr[5].Value =( string.IsNullOrEmpty(p_arrChargeitem_VO.m_strUNIT) == true ? "无" : p_arrChargeitem_VO.m_strUNIT);
//                objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
//                objParmArr[6].Value = p_arrChargeitem_VO.m_strREAGENT;
//                objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 50);
//                objParmArr[7].Value = p_arrChargeitem_VO.m_strMEDSPEC;
//                //by huafeng.xiao
//                objParmArr[8] = new OracleParameter("9", OracleType.Number);
//                objParmArr[8].Value = p_arrChargeitem_VO.m_intBILLKIND;
//                objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 4);
//                objParmArr[9].Value = p_arrChargeitem_VO.m_strFLBZ;

//                for (int j = 0; j < objParmArr.Length; j++)
//                {
//                    objCommand.Parameters.Add(objParmArr[j]);
//                }
//                lngRes = objCommand.ExecuteNonQuery();
//            }
//            catch (Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                objLogger.LogError(objEx);
//            }
//            finally
//            {
//                objConn.Close();
//                objConn.Dispose();
//            }
//            return lngRes;
            #endregion
            long lngRes = 0;
            OracleConnection objConn = null;
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();

                string strSQL0 = @"select * from hosp_charge t where t.BILLCODE = :1";
                OracleCommand objCommand_Query = new OracleCommand(strSQL0, objConn);
                OracleParameter objParmArr_Query = new OracleParameter("1", OracleType.VarChar, 50);
                objParmArr_Query.Value = p_arrChargeitem_VO.m_strBILLCODE;
                objCommand_Query.Parameters.Add(objParmArr_Query);
                OracleDataAdapter objAdapter = new OracleDataAdapter();
                objAdapter.SelectCommand = objCommand_Query;
                System.Data.DataTable dtbTemp = new System.Data.DataTable();
                objAdapter.Fill(dtbTemp);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    strSQL0 = "delete from hosp_charge t where t.billcode = :1";
                    OracleCommand objCommand_del = new OracleCommand(strSQL0, objConn);
                    OracleParameter objParmArr_del = new OracleParameter("1", OracleType.VarChar, 50);
                    objParmArr_del.Value = p_arrChargeitem_VO.m_strBILLCODE;
                    objCommand_del.Parameters.Add(objParmArr_del);
                    lngRes = objCommand_del.ExecuteNonQuery();
                }
                string strSQL = @"insert into Hosp_Charge
                                (organcode,itemid,billcode,billenname, billname,mnemotechnics, unitprice,collectdate,spec,unit,reagent,medspec,itemkind,jxbzdm,isdisable)values(:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12, :13, :14, :15)";
            
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objParmArr = new OracleParameter[15];
                objParmArr[0] = new OracleParameter("1", OracleType.VarChar,50);
                objParmArr[0].Value = p_arrChargeitem_VO.m_strORGANCODE;
                objParmArr[1] = new OracleParameter("2", OracleType.VarChar,50);
                objParmArr[1].Value = p_arrChargeitem_VO.m_strITEMID;
                objParmArr[2] = new OracleParameter("3", OracleType.VarChar,20);
                objParmArr[2].Value = p_arrChargeitem_VO.m_strBILLCODE;
                objParmArr[3] = new OracleParameter("4", OracleType.VarChar,50);
                objParmArr[3].Value = p_arrChargeitem_VO.m_strBILLENNAME;
                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 200);
                objParmArr[4].Value = p_arrChargeitem_VO.m_strBILLNAME;
                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 20);
                objParmArr[5].Value = p_arrChargeitem_VO.m_strMNEMOTECHNICS;
                objParmArr[6] = new OracleParameter("7", OracleType.Number, 18);
                objParmArr[6].Value = p_arrChargeitem_VO.m_decUNITPRICE;
                objParmArr[7] = new OracleParameter("8", OracleType.DateTime);
                objParmArr[7].Value = p_arrChargeitem_VO.m_datCOLLECTDATE;
                objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                objParmArr[8].Value = p_arrChargeitem_VO.m_strSPEC;
                objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 20);
                objParmArr[9].Value = (string.IsNullOrEmpty(p_arrChargeitem_VO.m_strUNIT) == true ? "无" : p_arrChargeitem_VO.m_strUNIT);
                objParmArr[10] = new OracleParameter("11", OracleType.VarChar, 50);
                objParmArr[10].Value = p_arrChargeitem_VO.m_strREAGENT;
                objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 50);
                objParmArr[11].Value = p_arrChargeitem_VO.m_strMEDSPEC;
                objParmArr[12] = new OracleParameter("13", OracleType.VarChar,4);
                objParmArr[12].Value = p_arrChargeitem_VO.m_strBILLKIND;
                objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 2);
                objParmArr[13].Value = p_arrChargeitem_VO.m_strJXBZDM;
                objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 1);
                objParmArr[14].Value = p_arrChargeitem_VO.m_strISDISABLE;

               
                for (int j = 0; j < objParmArr.Length; j++)
                {
                    objCommand.Parameters.Add(objParmArr[j]);
                }
                lngRes = objCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 药品信息上报
        /// <summary>
        /// 药品信息上报
        /// </summary>
        /// <param name="p_arrDrugInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadDrugInfo(com.digitalwave.iCare.ValueObject.clsDrugInfo_VO p_arrDrugInfo_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;
            string strSQL = @"insert into emm_medinf
            (drugid, genericname, tradename, formula, spec, packingspec,
             unit, approvedno, batchno, purchasedate, useamount, storeamount,
             medspec)
     values (:1, :2, :3, :4, :5, :6,
             :7, :8, :9, :10, :11, :12,
             :13)";
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objParmArr = new OracleParameter[13];
                objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 12);
                objParmArr[0].Value = p_arrDrugInfo_VO.m_strDrugID;
                objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 100);
                objParmArr[1].Value = p_arrDrugInfo_VO.m_strGENERICNAME;
                objParmArr[2] = new OracleParameter("3", OracleType.VarChar,150);
                objParmArr[2].Value = p_arrDrugInfo_VO.m_strTRADENAME;
                objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 50);
                objParmArr[3].Value = p_arrDrugInfo_VO.m_strFORMULA;
                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                objParmArr[4].Value = p_arrDrugInfo_VO.m_strSPEC;
                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                objParmArr[5].Value = p_arrDrugInfo_VO.m_strPACKINGSPEC;
                objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                objParmArr[6].Value = p_arrDrugInfo_VO.m_strUNIT;
                objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 20);
                objParmArr[7].Value = p_arrDrugInfo_VO.m_strAPPROVEDNO;
                objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                objParmArr[8].Value = p_arrDrugInfo_VO.m_strBATCHNO;
                objParmArr[9] = new OracleParameter("10", OracleType.DateTime, 50);
                objParmArr[9].Value = DateTime.Parse(p_arrDrugInfo_VO.m_strPURCHASEDATE);
                objParmArr[10] = new OracleParameter("11", OracleType.Number);
                objParmArr[10].Value = p_arrDrugInfo_VO.m_intUSEAMOUNT;
                objParmArr[11] = new OracleParameter("12", OracleType.Number);
                objParmArr[11].Value = p_arrDrugInfo_VO.m_intSTOREAMOUNT;
                objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                objParmArr[12].Value = p_arrDrugInfo_VO.m_strMEDSPEC;

                for (int j = 0; j < objParmArr.Length; j++)
                {
                    objCommand.Parameters.Add(objParmArr[j]);
                }
                lngRes = objCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion
//周四改到此
        #region 检验数据上报
        /// <summary>
        /// 删除前置机指定日期记录 
        /// </summary>
        /// <param name="p_strStardDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelLISUpdateLoadDataByDate(string p_strStardDate, string p_strEndDate)
        {
            long lngRes = 1;
            if (string.IsNullOrEmpty(p_strStardDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            OracleConnection objConn = null;
            string strSQL = "";

            try
            {
                strSQL = @"delete hosp_assayrecordsublist t
 where observationid in
       (select a.observationid
          from hosp_assayrecord a
         where a.observationdatetime between :1 and :2)";

                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objDPArr = new OracleParameter[2];
                objDPArr[0] = new OracleParameter("1", OracleType.DateTime);
                objDPArr[0].Value = Convert.ToDateTime(p_strStardDate);
                objDPArr[1] = new OracleParameter("2", OracleType.DateTime);
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                objCommand.Parameters.AddRange(objDPArr);
                lngRes = objCommand.ExecuteNonQuery();


                strSQL = @"delete hosp_assayrecordlist t
 where observationid in
       (select a.observationid
          from hosp_assayrecord a
         where a.observationdatetime between :1 and :2)";
                objCommand.CommandText = strSQL;
                lngRes = objCommand.ExecuteNonQuery();

                strSQL = @"delete hosp_assayrecord a where a.observationdatetime between :1 and :2";
                objCommand.CommandText = strSQL;
                lngRes = objCommand.ExecuteNonQuery();
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                }


            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        /// <summary>
        /// 保存申请单记录
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertLisAppDataByDate(clsLISAppl_VO[] p_objResultArr)
        {
            long lngRes = 0;

            if (p_objResultArr == null || p_objResultArr.Length <= 0)
                return lngRes;

            OracleConnection objConn = null;
            string strSQL = "";

            try
            {
                strSQL = @"insert into hosp_assayrecord
  (organcode, 
   observationid,
   visitno,
   inhosseqno,
   kind,
   proveswatchcode,
   proveswatchname,
   provetype,
   observationdatetime,
   createobservationdatetime,
   createcliniciancode,
   createclinicianname,
   observationoptcode,
   observationoptname,
   observationway,
   observationdeptcode,
   observationdeptname,
   observationoptdeptcode,
   observationoptdeptname,
   flag)
values
  (:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12, :13, :14, :15, :16, :17, :18, :19, :20)";

                string strDept = "检验科";
                StringBuilder strDeptIDBuidle = new StringBuilder(128);
                GetPrivateProfileString("department", "检验科", "0000247", strDeptIDBuidle, 128, Application.StartupPath + "\\DataUploadSetting.ini");
                string strDeptID = strDeptIDBuidle.ToString();
                if (string.IsNullOrEmpty(strDeptID))
                {
                    strDeptID = "*";
                }
                string p_strHospitalNO = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objDPArr = new OracleParameter[20];
                objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 50);
                objDPArr[3] = new OracleParameter("4", OracleType.VarChar, 50);
                objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 10);

                objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 10);
                objDPArr[8] = new OracleParameter("9", OracleType.DateTime);
                objDPArr[9] = new OracleParameter("10", OracleType.DateTime);

                objDPArr[10] = new OracleParameter("11", OracleType.VarChar, 50);
                objDPArr[11] = new OracleParameter("12", OracleType.VarChar, 50);
                objDPArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                objDPArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                objDPArr[14] = new OracleParameter("15", OracleType.VarChar, 50);

                objDPArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                objDPArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                objDPArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                objDPArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                objDPArr[19] = new OracleParameter("20", OracleType.VarChar, 1);

                objCommand.Parameters.AddRange(objDPArr);

                clsLISAppl_VO objTemp = null;
                for (int index = 0; index < p_objResultArr.Length; index++)
                {
                    objTemp = p_objResultArr[index];
                    objDPArr[0].Value = p_strHospitalNO;
                    objDPArr[1].Value = objTemp.m_strOBSERVATIONID;
                    objDPArr[2].Value = objTemp.m_strVISITNO;
                    objDPArr[3].Value = objTemp.m_strINHOSSEQNO;
                    objDPArr[4].Value = objTemp.m_strKIND;

                    objDPArr[5].Value = objTemp.m_strPROVESWATCHCODE;
                    objDPArr[6].Value = objTemp.m_strPROVESWATCHNAME;
                    objDPArr[7].Value = string.IsNullOrEmpty(objTemp.m_strPROVETYPE) ? "*" : objTemp.m_strPROVETYPE;
                    objDPArr[8].Value = Convert.ToDateTime(objTemp.m_strOBSERVATIONDATETIM);
                    objDPArr[9].Value = Convert.ToDateTime(objTemp.m_strCREATEOBSERVATIONDATETIME);

                    objDPArr[10].Value = objTemp.m_strCREATECLINICIANCODE == "" ? "*" : objTemp.m_strCREATECLINICIANCODE;
                    objDPArr[11].Value = objTemp.m_strCREATECLINICIANNAME == "" ? "*" : objTemp.m_strCREATECLINICIANNAME;
                    objDPArr[12].Value = objTemp.m_strOBSERVATIONOPTCODE == "" ? "*" : objTemp.m_strOBSERVATIONOPTCODE;
                    objDPArr[13].Value = objTemp.m_strOBSERVATIONOPTNAME == "" ? "*" : objTemp.m_strOBSERVATIONOPTNAME;
                    objDPArr[14].Value = objTemp.m_strOBSERVATIONWAY == "" ? "*" : objTemp.m_strOBSERVATIONWAY;

                    objDPArr[15].Value = objTemp.m_strOBSERVATIONDEPTCODE == "" ? "*" : objTemp.m_strOBSERVATIONDEPTCODE;
                    objDPArr[16].Value = objTemp.m_strOBSERVATIONDEPTNAME == "" ? "*" : objTemp.m_strOBSERVATIONDEPTNAME;
                    objDPArr[17].Value = strDeptID;
                    objDPArr[18].Value = strDept;
                    objDPArr[19].Value = "0";

                    lngRes = objCommand.ExecuteNonQuery();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;

        }

        /// <summary>
        /// 保存检验明细信息
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertLisAppItemDataByDate(clsLISApplItem_VO[] p_objResultArr)
        {
            long lngRes = 0;
            if (p_objResultArr == null || p_objResultArr.Length <= 0)
                return lngRes;

            OracleConnection objConn = null;
            string strSQL = "";

            try
            {
                strSQL = @"insert into hosp_assayrecordlist
  (organcode,
   list_seq,
   recordtype,
   observationid,
   observationsubid,
   provename,
   observationsubname,
   resulttype,
   observationvalue,
   units,
   referencesrange,
   observationresultstatus,
   demo,
   apparatus,
   singularity)
values
  (:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12, :13, :14, :15)";

                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objDPArr = new OracleParameter[15];
                objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 10);
                objDPArr[3] = new OracleParameter("4", OracleType.VarChar, 50);
                objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 200);
                objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 10);

                objDPArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                objDPArr[9] = new OracleParameter("10", OracleType.VarChar, 50);
                objDPArr[10] = new OracleParameter("11", OracleType.VarChar, 256);
                objDPArr[11] = new OracleParameter("12", OracleType.VarChar, 50);
                objDPArr[12] = new OracleParameter("13", OracleType.VarChar, 256);
                objDPArr[13] = new OracleParameter("14", OracleType.VarChar, 100);
                objDPArr[14] = new OracleParameter("15", OracleType.VarChar, 256);

                objCommand.Parameters.AddRange(objDPArr);

                clsLISApplItem_VO objTemp = null;
                int intLengh = p_objResultArr.Length;
                string p_strHospitalNO = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                for (int index = 0; index < intLengh; index++)
                {
                    objTemp = p_objResultArr[index];
                    objDPArr[0].Value = p_strHospitalNO;
                    objDPArr[1].Value = objTemp.m_strLIST_SEQ;
                    objDPArr[2].Value = objTemp.m_strRECORDTYPE;
                    objDPArr[3].Value = objTemp.m_strOBSERVATIONID == "" ? "*" : objTemp.m_strOBSERVATIONID;
                    objDPArr[4].Value = objTemp.m_strOBSERVATIONSUBID == "" ? "*" : objTemp.m_strOBSERVATIONSUBID;
                    objDPArr[5].Value = string.IsNullOrEmpty(objTemp.m_strPROVENAME) ? "*" : objTemp.m_strPROVENAME;
                    objDPArr[6].Value = objTemp.m_strOBSERVATIONSUBNAME == "" ? "*" : objTemp.m_strOBSERVATIONSUBNAME;
                    objDPArr[7].Value = string.IsNullOrEmpty(objTemp.m_strRESULTTYPE) ? "99" : objTemp.m_strRESULTTYPE;
                    objDPArr[8].Value = objTemp.m_strOBSERVATIONVALUE == "" ? "*" : objTemp.m_strOBSERVATIONVALUE;
                    objDPArr[9].Value = objTemp.m_strUNITS == "" ? "*" : objTemp.m_strUNITS;
                    objDPArr[10].Value = objTemp.m_strREFERENCESRANGE == "" ? "*" : objTemp.m_strREFERENCESRANGE;
                    objDPArr[11].Value = objTemp.m_strOBSERVATIONRESULTSTATUS == "" ? "*" : objTemp.m_strOBSERVATIONRESULTSTATUS;
                    objDPArr[12].Value = objTemp.m_strDEMO == "" ? "*" : objTemp.m_strDEMO;

                    objDPArr[13].Value = string.IsNullOrEmpty(objTemp.m_strAPPARATUS) ? "*" : objTemp.m_strAPPARATUS;
                    objDPArr[14].Value = string.IsNullOrEmpty(objTemp.m_strSINGULARITY) ? "*" : objTemp.m_strSINGULARITY;

                    lngRes = objCommand.ExecuteNonQuery();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;

        }

        /// <summary>
        /// 保存检验子明细信息 
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertLisAppItemDetialDataByDate(clsLISApplDetial_VO[] p_objResultArr)
        {
            long lngRes = 0;
            if (p_objResultArr == null || p_objResultArr.Length <= 0)
                return lngRes;

            OracleConnection objConn = null;
            string strSQL = "";

            try
            {
//                strSQL = @"insert into hosp_assayrecordsublist
//  (observationid,
//   observationsub_id,
//   observationcode,
//   observationname,
//   observationvalue)
//values
//  (:1, :2, :3, :4, :5)";

//                string strConnection = m_strGetDbConnection();
//                objConn = new OracleConnection(strConnection);
//                objConn.Open();
//                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

//                OracleParameter[] objDPArr = new OracleParameter[5];
//                objDPArr[0] = new OracleParameter("1", OracleType.VarChar);
//                objDPArr[1] = new OracleParameter("2", OracleType.VarChar);
//                objDPArr[2] = new OracleParameter("3", OracleType.VarChar);
//                objDPArr[3] = new OracleParameter("4", OracleType.VarChar);
//                objDPArr[4] = new OracleParameter("5", OracleType.VarChar);

//                objCommand.Parameters.AddRange(objDPArr);

//                clsLISApplDetial_VO objTemp = null;
//                for (int index = 0; index < p_objResultArr.Length; index++)
//                {
//                    objTemp = p_objResultArr[index];
//                    objDPArr[0].Value = objTemp.m_strOBSERVATIONID;
//                    objDPArr[1].Value = objTemp.m_strOBSERVATIONSUB_ID;
//                    objDPArr[2].Value = objTemp.m_strOBSERVATIONCODE;
//                    objDPArr[3].Value = objTemp.m_strOBSERVATIONNAME == "" ? "*" : objTemp.m_strOBSERVATIONNAME;
//                    objDPArr[4].Value = objTemp.m_strOBSERVATIONVALUE == "" ? "*" : objTemp.m_strOBSERVATIONVALUE;

//                    lngRes = objCommand.ExecuteNonQuery();
//                }
                strSQL = @"insert into hosp_assayrecordsublist
  (organcode,
   sublist_seq,
   observationid,
   observationsub_id,
   observationcode,
   observationname,
   observationenname,
   observationvalue)
values
  (:1, :2, :3, :4, :5, :6, :7, :8)";

                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objDPArr = new OracleParameter[8];
                objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 9);
                objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 50);
                objDPArr[3] = new OracleParameter("4", OracleType.VarChar, 50);
                objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 200);
                objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 200);
                objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 50);


                objCommand.Parameters.AddRange(objDPArr);
                string p_strHospitalNO = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
                clsLISApplDetial_VO objTemp = null;
                for (int index = 0; index < p_objResultArr.Length; index++)
                {
                    objTemp = p_objResultArr[index];

                    objDPArr[0].Value = p_strHospitalNO;
                    objDPArr[1].Value = objTemp.m_strSUBLIST_SEQ;// +DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                    objDPArr[2].Value = objTemp.m_strOBSERVATIONID == "" ? "*" : objTemp.m_strOBSERVATIONID;
                    objDPArr[3].Value = objTemp.m_strOBSERVATIONSUB_ID == "" ? "*" : objTemp.m_strOBSERVATIONSUB_ID;
                    objDPArr[4].Value = objTemp.m_strOBSERVATIONCODE;
                    objDPArr[5].Value = objTemp.m_strOBSERVATIONNAME == "" ? "*" : objTemp.m_strOBSERVATIONNAME;
                    objDPArr[6].Value = string.IsNullOrEmpty(objTemp.m_strOBSERVATIONENNAME) ? "*" : objTemp.m_strOBSERVATIONENNAME;
                    objDPArr[7].Value = objTemp.m_strOBSERVATIONVALUE == "" ? "*" : objTemp.m_strOBSERVATIONVALUE;

                    lngRes = objCommand.ExecuteNonQuery();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;

        }

        #endregion

        #region 上报检查单数据
        /// <summary>
        /// 上传检查单数据
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertCheckRecordInfo(List<clsCheckRecord> p_lstRecord)
        {
            long lngRes = 0;
            
            OracleConnection objConn = null;
            OracleCommand objCommand = null;
            string strConnection = string.Empty;
            string strSql = string.Empty;
            string strSQLQuery = string.Empty;
            string strSQL1 = string.Empty;
            string strDh = "";

            try
            {
                strSQLQuery = @"select 1 from hosp_checkrecord where checkrecordid = :1";

                #region 如果存在，update
                strSQL1 = @"update hosp_checkrecord
                               set visitno       = :1,
                                   inhosseqno            = :2,
                                   checkrecordappdatetime             = :3,
                                   checkrecorddatetime            = :4,
                                   cliniciancode     = :5,
                                   clinicianname         = :6,
                                   clinicianappcode        = :7,
                                   clinicianappname = :8,
                                   checkrecordapparatus   = :9,
                                   checkrecordtype     = :10,
                                   checkrecordsubname   = :11,
                                   checksite        = :12,
                                   checkrecordcontent            = :13,
                                   checkrecordresult  = :14,
                                   checkrecorddeptcode        = :15,
                                   checkrecorddeptname        = :16,
                                   checkrecordappdeptcode   = :17,
                                   checkrecordappdeptname   = :18,
                                   organcode             = :19,
                                   kind             = :20,
                                   flag             = :21
                                   where checkrecordid = :22 ";

                #endregion

                strSql = @"insert into hosp_checkrecord
                                      (visitno,
                                       inhosseqno,
                                       checkrecordid,
                                       checkrecordappdatetime,
                                       checkrecorddatetime,
                                       cliniciancode,
                                       clinicianname,
                                       clinicianappcode,
                                       clinicianappname,
                                       checkrecordapparatus,
                                       checkrecordtype,
                                       checkrecordsubname,
                                       checksite,
                                       checkrecordcontent,
                                       checkrecordresult,
                                       checkrecorddeptcode,
                                       checkrecorddeptname,
                                       checkrecordappdeptcode,
                                       checkrecordappdeptname,organcode,kind,flag)
                                    values
                                      (:1, :2, :3, :4, :5,:6,:7,:8,:9,:10,:11,:12,:13,:14,:15,:16,:17,:18,:19,:20,:21,:22)";

                strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                
                //-------------------------------------------
                //添加过滤
                Dictionary<string ,string> objHsTable = new Dictionary<string ,string>();
               
                foreach(clsCheckRecord record in p_lstRecord)
                {
                    record.m_strCheckRecordID = record.m_strCheckRecordID.Trim();
                    strDh = record.m_strCheckRecordID.Trim();
                    OracleParameter[] objDPArr = null;

                    #region 根据checkrecordid验证记录是否存在
                    bool blnExists = false;
                    OracleCommand objCommand_Query = new OracleCommand(strSQLQuery, objConn);
                    OracleParameter[] queryParmArr = new OracleParameter[1];

                    queryParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                    queryParmArr[0].Value = strDh;

                    for (int j = 0; j < queryParmArr.Length; j++)
                    {
                        objCommand_Query.Parameters.Add(queryParmArr[j]);
                    }

                    OracleDataAdapter objAdapter = new OracleDataAdapter();
                    objAdapter.SelectCommand = objCommand_Query;
                    System.Data.DataTable dtbTemp = new System.Data.DataTable();
                    objAdapter.Fill(dtbTemp);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        blnExists = true;
                    }
                    #endregion

                    if (!blnExists)
                    {
                        try
                        {
                            if (objHsTable.ContainsKey(record.m_strCheckRecordID))
                            {
                                continue;
                            }
                            else
                            {
                                objHsTable.Add(record.m_strCheckRecordID, "");
                            }
                        }
                        catch
                        {
                            continue;
                        }
                        //----------------------------------------------
                        objCommand = new OracleCommand(strSql, objConn);
                        objDPArr = new OracleParameter[22];
                        objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                        objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                        objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 50);
                        objDPArr[3] = new OracleParameter("4", OracleType.DateTime);
                        objDPArr[4] = new OracleParameter("5", OracleType.DateTime);
                        objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                        objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                        objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 50);
                        objDPArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                        objDPArr[9] = new OracleParameter("10", OracleType.VarChar, 64);
                        objDPArr[10] = new OracleParameter("11", OracleType.VarChar, 50);
                        objDPArr[11] = new OracleParameter("12", OracleType.VarChar, 200);
                        objDPArr[12] = new OracleParameter("13", OracleType.VarChar, 256);
                        objDPArr[13] = new OracleParameter("14", OracleType.VarChar, 1024);
                        objDPArr[14] = new OracleParameter("15", OracleType.VarChar, 1024);
                        objDPArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                        objDPArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                        objDPArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                        objDPArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                        objDPArr[19] = new OracleParameter("20", OracleType.VarChar, 1);
                        objDPArr[20] = new OracleParameter("21", OracleType.VarChar, 50);
                        objDPArr[21] = new OracleParameter("22", OracleType.VarChar, 10);
                        objCommand.Parameters.AddRange(objDPArr);

                        objDPArr[0].Value = record.m_strVisitNo;
                        objDPArr[1].Value = record.m_strInHossSeqNo;
                        objDPArr[2].Value = record.m_strCheckRecordID;
                        objDPArr[3].Value = record.m_dtmCheckRecordAppDate;

                        objDPArr[4].Value = record.m_dtmCheckRecordDate;

                        if (objDPArr[3].Value == null)
                        {
                            objDPArr[3].Value = record.m_dtmCheckRecordDate;
                        }

                        if (objDPArr[4].Value == null)
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(record.m_strClinicianCode))
                        {
                            record.m_strClinicianCode = " ";
                        }
                        objDPArr[5].Value = record.m_strClinicianCode;
                        if (string.IsNullOrEmpty(record.m_strClinicianName))
                        {
                            record.m_strClinicianName = " ";
                        }
                        objDPArr[6].Value = record.m_strClinicianName;
                        if (string.IsNullOrEmpty(record.m_strClinicianAppCode))
                        {
                            record.m_strClinicianAppCode = " ";
                        }
                        objDPArr[7].Value = record.m_strClinicianAppCode;
                        if (string.IsNullOrEmpty(record.m_strClinicianAppName))
                        {
                            record.m_strClinicianAppName = " ";
                        }
                        objDPArr[8].Value = record.m_strClinicianAppName;
                        objDPArr[9].Value = record.m_strCheckReocrdApparatus;
                        objDPArr[10].Value = record.m_strCheckRecordType;
                        if (record.m_strCheckSite.Length > 25)
                        {
                            record.m_strCheckSite = record.m_strCheckSite.Substring(0, 25);
                        }
                        objDPArr[11].Value = record.m_strCheckRecordSubName;
                        objDPArr[12].Value = record.m_strCheckSite.Replace("+", ";");
                        if (string.IsNullOrEmpty(record.m_strCheckRecordContent))
                        {
                            record.m_strCheckRecordContent = " ";
                        }
                        objDPArr[13].Value = record.m_strCheckRecordContent;
                        if (string.IsNullOrEmpty(record.m_strCheckRecordResult))
                        {
                            record.m_strCheckRecordResult = " ";
                        }
                        objDPArr[14].Value = record.m_strCheckRecordResult;
                        if (string.IsNullOrEmpty(record.m_strCheckRecordDeptCode))
                        {
                            record.m_strCheckRecordDeptCode = " ";
                        }
                        objDPArr[15].Value = record.m_strCheckRecordDeptCode;
                        if (string.IsNullOrEmpty(record.m_strCheckRecordDeptName))
                        {
                            record.m_strCheckRecordDeptName = " ";
                        }
                        objDPArr[16].Value = record.m_strCheckRecordDeptName;
                        if (string.IsNullOrEmpty(record.m_strCheckRecordAppDeptCode))
                        {
                            objDPArr[17].Value = " ";
                        }
                        else
                        {
                            objDPArr[17].Value = record.m_strCheckRecordAppDeptCode;
                        }
                        if (string.IsNullOrEmpty(record.m_strCheckRecordAppDeptName))
                        {
                            objDPArr[18].Value = " ";
                        }
                        else
                        {
                            objDPArr[18].Value = record.m_strCheckRecordAppDeptName;
                        }
                        objDPArr[19].Value = record.m_strOrganCode;
                        if (string.IsNullOrEmpty(record.m_strKind))
                        {
                            objDPArr[20].Value = " ";
                        }
                        else
                        {
                            objDPArr[20].Value = record.m_strKind;
                        }
                        objDPArr[21].Value = record.m_strInvalid;

                        lngRes = objCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        try
                        {
                            if (objHsTable.ContainsKey(record.m_strCheckRecordID))
                            {
                                continue;
                            }
                            else
                            {
                                objHsTable.Add(record.m_strCheckRecordID, "");
                            }
                        }
                        catch
                        {
                            continue;
                        }

                        objCommand = new OracleCommand(strSQL1, objConn);
                        objDPArr = new OracleParameter[22];
                        objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                        objDPArr[0].Value = record.m_strVisitNo;

                        objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                        objDPArr[1].Value = record.m_strInHossSeqNo;
                        
                        objDPArr[2] = new OracleParameter("3", OracleType.DateTime);
                        objDPArr[2].Value = record.m_dtmCheckRecordAppDate;
                        if (objDPArr[2].Value == null)
                        {
                            objDPArr[2].Value = record.m_dtmCheckRecordDate;
                        }

                        objDPArr[3] = new OracleParameter("4", OracleType.DateTime);
                        objDPArr[3].Value = record.m_dtmCheckRecordDate;
                        if (objDPArr[3].Value == null)
                        {
                            continue;
                        }

                        objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                        if (string.IsNullOrEmpty(record.m_strClinicianCode))
                        {
                            record.m_strClinicianCode = " ";
                        }
                        objDPArr[4].Value = record.m_strClinicianCode;

                        objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                        objDPArr[5].Value = record.m_strClinicianName;

                        objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 50);
                        objDPArr[6].Value = record.m_strClinicianAppCode;
                       
                        objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 50);
                        if (string.IsNullOrEmpty(record.m_strClinicianAppName))
                        {
                            record.m_strClinicianAppName = " ";
                        }
                        objDPArr[7].Value = record.m_strClinicianAppName;

                        objDPArr[8] = new OracleParameter("9", OracleType.VarChar, 64);
                        objDPArr[8].Value = record.m_strCheckReocrdApparatus;

                        objDPArr[9] = new OracleParameter("10", OracleType.VarChar, 50);
                        objDPArr[9].Value = record.m_strCheckRecordType;

                        objDPArr[10] = new OracleParameter("11", OracleType.VarChar, 200);
                        if (record.m_strCheckSite.Length > 25)
                        {
                            record.m_strCheckSite = record.m_strCheckSite.Substring(0, 25);
                        }
                        objDPArr[10].Value = record.m_strCheckRecordSubName;

                        objDPArr[11] = new OracleParameter("12", OracleType.VarChar, 256);
                        objDPArr[11].Value = record.m_strCheckSite.Replace("+", ";");

                        objDPArr[12] = new OracleParameter("13", OracleType.VarChar, 1024);
                        if (string.IsNullOrEmpty(record.m_strCheckRecordContent))
                        {
                            record.m_strCheckRecordContent = " ";
                        }
                        objDPArr[12].Value = record.m_strCheckRecordContent;

                        objDPArr[13] = new OracleParameter("14", OracleType.VarChar, 1024);
                        if (string.IsNullOrEmpty(record.m_strCheckRecordResult))
                        {
                            record.m_strCheckRecordResult = " ";
                        }
                        objDPArr[13].Value = record.m_strCheckRecordResult;

                        objDPArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                        objDPArr[14].Value = record.m_strCheckRecordDeptCode;

                        objDPArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                        if (string.IsNullOrEmpty(record.m_strCheckRecordDeptName))
                        {
                            record.m_strCheckRecordDeptName = " ";
                        }
                        objDPArr[15].Value = record.m_strCheckRecordDeptName;

                        objDPArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                        if (string.IsNullOrEmpty(record.m_strCheckRecordAppDeptCode))
                        {
                            objDPArr[16].Value = " ";
                        }
                        else
                        {
                            objDPArr[16].Value = record.m_strCheckRecordAppDeptCode;
                        }

                        objDPArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                        if (string.IsNullOrEmpty(record.m_strCheckRecordAppDeptName))
                        {
                            objDPArr[17].Value = " ";
                        }
                        else
                        {
                            objDPArr[17].Value = record.m_strCheckRecordAppDeptName;
                        }

                        objDPArr[18] = new OracleParameter("19", OracleType.VarChar, 1);
                        objDPArr[18].Value = record.m_strOrganCode;

                        objDPArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                        if (string.IsNullOrEmpty(record.m_strKind))
                        {
                            objDPArr[19].Value = " ";
                        }
                        else
                        {
                            objDPArr[19].Value = record.m_strKind;
                        }

                        objDPArr[20] = new OracleParameter("21", OracleType.VarChar, 10);
                        objDPArr[20].Value = record.m_strInvalid;

                        objDPArr[21] = new OracleParameter("22", OracleType.VarChar, 50); //record.m_strCheckRecordID
                        objDPArr[21].Value = record.m_strCheckRecordID;

                        for (int j = 0; j < objDPArr.Length; j++)
                        {
                            objCommand.Parameters.Add(objDPArr[j]);
                        }
                        lngRes = objCommand.ExecuteNonQuery();

                        //objCommand.Parameters.AddRange(objDPArr);
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;

        }

        [AutoComplete]
        public long m_lngInsertCheckPicInfo(List<clsCheckPic> p_lstPic)
        {
            long lngRes = 0;

            OracleConnection objConn = null;
            string strSql = string.Empty;

            try
            {
                strSql = @"insert into hosp_pic
                                      (checkrecordid,
                                       organcode,
                                       picid,
                                       pictype,
                                       pic,pic_seq,systemtime,checkrecordapparatus,
                                       checksite)
                                    values
                                      (:1, :2, :3, :4, :5, seq_uploadpic.nextval, sysdate,:6,:7)";

                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSql, objConn);

                OracleParameter[] objDPArr = new OracleParameter[7];
                objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 20);
                objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 50);
                objDPArr[3] = new OracleParameter("4", OracleType.Int32);
                objDPArr[4] = new OracleParameter("5", OracleType.Blob);
                objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 64);
                objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 256);
                objCommand.Parameters.AddRange(objDPArr);


                foreach (clsCheckPic pic in p_lstPic)
                {
                    objDPArr[0].Value = pic.m_strCheckRecordID;
                    objDPArr[1].Value = pic.m_strOrganCode;
                    objDPArr[2].Value = pic.m_strPicID;
                    objDPArr[3].Value = 3;
                    objDPArr[4].Value = pic.m_bytPic;
                    objDPArr[5].Value = pic.m_strCheckRecordAppAratus;
                    objDPArr[6].Value = pic.m_strCheckSite;
                    lngRes = objCommand.ExecuteNonQuery();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;

        }

        /// <summary>
        /// 删除前置机指定日期记录 
        /// </summary>
        /// <param name="p_strStardDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelCheckInfo(string p_strStardDate, string p_strEndDate)
        {
            long lngRes = 1;
            if (string.IsNullOrEmpty(p_strStardDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            OracleConnection objConn = null;
            string strSQL = "";

            try
            {
                strSQL = @"delete hosp_pic t
 where t.checkrecordid in
       (select a.checkrecordid
          from hosp_checkrecord a
         where a.checkrecordappdatetime between :1 and :2)";

                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objDPArr = new OracleParameter[2];
                objDPArr[0] = new OracleParameter("1", OracleType.DateTime);
                objDPArr[0].Value = Convert.ToDateTime(p_strStardDate);
                objDPArr[1] = new OracleParameter("2", OracleType.DateTime);
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                objCommand.Parameters.AddRange(objDPArr);
                lngRes = objCommand.ExecuteNonQuery();

                strSQL = @"delete hosp_checkrecord a where a.checkrecordappdatetime between :1 and :2";
                objCommand.CommandText = strSQL;
                lngRes = objCommand.ExecuteNonQuery();
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                }
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 获取数据库连接字符串
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string m_strGetDbConnection()
        {
            string strConn = "Data Source={0};User ID={1};Password={2};Enlist=false";
            string m_strIniFilePath = Application.StartupPath + "\\DataUploadSetting.ini";
            if (System.IO.File.Exists(m_strIniFilePath))
            {
                StringBuilder sb1 = new StringBuilder(128);
                StringBuilder sb2 = new StringBuilder(128);
                StringBuilder sb3 = new StringBuilder(128);
                GetPrivateProfileString("DSN", "dbserver", "dgwsxx", sb1, 128, m_strIniFilePath);
                GetPrivateProfileString("DSN", "loginid", "dgwsj", sb2, 128, m_strIniFilePath);
                GetPrivateProfileString("DSN", "password", "dgwsj", sb3, 128, m_strIniFilePath);
                strConn = string.Format(strConn, sb1.ToString().Trim(), sb2.ToString().Trim(), sb3.ToString().Trim());
            }
            return strConn;
        }
        #endregion

        #region 把数据库值转换成卫生局定义的标准值
        /// <summary>
        /// 把数据库值转换成卫生局定义的标准值
        /// </summary>
        /// <param name="section">配置区域</param>
        /// <param name="key">配置key</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns></returns>
        public static string m_strConvertValue(string section, string key, string defaultvalue)
        {
            string strValue = string.Empty;
            try
            {
                string m_strIniFilePath = Application.StartupPath + "\\DataUploadSetting.ini";
                StringBuilder sb = new StringBuilder(128);
                GetPrivateProfileString(section, key, defaultvalue, sb, 128, m_strIniFilePath);
                strValue = sb.ToString().Trim();
            }
            catch
            {
                strValue = defaultvalue;
            }
            return strValue;
        }
        #endregion

        #region 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        #endregion

        #region 入库信息上报
        /// <summary>
        /// 入库信息上报
        /// </summary>
        /// <param name="p_arrInStorageInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadInStorageInfo(com.digitalwave.iCare.ValueObject.clsInStorageInfo_VO p_arrInStorageInfo_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;
            string strSQL = @"insert into hosp_warehousing
  (organcode,
   warehousing_seq,
   drugstoreid,
   warehousing_number,
   itemid,
   itemkind,
   h_drugid,
   genericname,
   spec,
   formula,
   input_amount,
   buy_price,
   retail_price,
   invoice_no,
   invoice_date,
   manufacturer,
   supply,
   effective_date,
   batchno,
   flag,
   approvedno,
   input_date,
   upload_date)
values
  (:1,
   :2,
   :3,
   :4,
   :5,
   :6,
   :7,
   :8,
   :9,
   :10,
   :11,
   :12,
   :13,
   :14,
   :15,
   :16,
   :17,
   :18,
   :19,
   :20,
   :21,
   :22,
   :23)";
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objParmArr = new OracleParameter[23];
                objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objParmArr[0].Value = p_arrInStorageInfo_VO.m_strORGANCODE;
                objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objParmArr[1].Value = p_arrInStorageInfo_VO.m_strWAREHOUSING_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 12);
                objParmArr[2].Value = p_arrInStorageInfo_VO.m_strDRUGSTOREID;
                objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                objParmArr[3].Value = p_arrInStorageInfo_VO.m_strWAREHOUSING_NUMBER;
                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                objParmArr[4].Value = p_arrInStorageInfo_VO.m_strITEMID;
                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 6);
                objParmArr[5].Value = p_arrInStorageInfo_VO.m_strITEMKIND;
                objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 12);
                objParmArr[6].Value = p_arrInStorageInfo_VO.m_strH_DRUGID;
                objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 100);
                objParmArr[7].Value = p_arrInStorageInfo_VO.m_strGENERICNAME;
                objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                objParmArr[8].Value = p_arrInStorageInfo_VO.m_strSPEC;
                objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 50);
                objParmArr[9].Value = p_arrInStorageInfo_VO.m_strFORMULA;
                objParmArr[10] = new OracleParameter("11", OracleType.Number, 15);
                objParmArr[10].Value = p_arrInStorageInfo_VO.m_dblINPUT_AMOUNT;
                objParmArr[11] = new OracleParameter("12", OracleType.Number, 15);
                objParmArr[11].Value = p_arrInStorageInfo_VO.m_dblBUY_PRICE;
                objParmArr[12] = new OracleParameter("13", OracleType.Number, 15);
                objParmArr[12].Value = p_arrInStorageInfo_VO.m_dblRETAIL_PRICE;
                objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                objParmArr[13].Value = p_arrInStorageInfo_VO.m_strINVOICE_NO;
                objParmArr[14] = new OracleParameter("15", OracleType.DateTime);
                objParmArr[14].Value = p_arrInStorageInfo_VO.m_dtmINVOICE_DATE;
                objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 70);
                objParmArr[15].Value = p_arrInStorageInfo_VO.m_strMANUFACTURER;
                objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                objParmArr[16].Value = p_arrInStorageInfo_VO.m_strSUPPLY;
                objParmArr[17] = new OracleParameter("18", OracleType.DateTime);
                objParmArr[17].Value = p_arrInStorageInfo_VO.m_dtmEFFECTIVE_DATE;
                objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                objParmArr[18].Value = p_arrInStorageInfo_VO.m_strBATCHNO;
                objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                objParmArr[19].Value = p_arrInStorageInfo_VO.m_strFLAG;
                objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 2);
                objParmArr[20].Value = p_arrInStorageInfo_VO.m_strAPPROVEDNO;
                objParmArr[21] = new OracleParameter("22", OracleType.DateTime);
                objParmArr[21].Value = p_arrInStorageInfo_VO.m_dtmINPUT_DATE;
                objParmArr[22] = new OracleParameter("23", OracleType.DateTime);
                objParmArr[22].Value = p_arrInStorageInfo_VO.m_dtmUPLOAD_DATE;

                for (int j = 0; j < objParmArr.Length; j++)
                {
                    objCommand.Parameters.Add(objParmArr[j]);
                }
                lngRes = objCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 出库信息上报
        /// <summary>
        /// 出库信息上报
        /// </summary>
        /// <param name="p_arrOutStorageInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadOutStorageInfo(com.digitalwave.iCare.ValueObject.clsOutStorageInfo_VO p_arrOutStorageInfo_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;
            string strSQL = @"insert into hosp_operator
  (organcode,
   operator_seq,
   drugstoreid,
   shipping_no,
   itemid,
   itemkind,
   h_drugid,
   genericname,
   spec,
   formula,
   output_amount,
   buy_price,
   retail_price,
   batchno,
   manufacturer,
   supply,
   effective_date,
   warehousing_number,
   shipping_date,
   flag,
   upload_date)
values
  (:1,
   :2,
   :3,
   :4,
   :5,
   :6,
   :7,
   :8,
   :9,
   :10,
   :11,
   :12,
   :13,
   :14,
   :15,
   :16,
   :17,
   :18,
   :19,
   :20,
   :21)";
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objParmArr = new OracleParameter[21];
                objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objParmArr[0].Value = p_arrOutStorageInfo_VO.m_strORGANCODE;
                objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objParmArr[1].Value = p_arrOutStorageInfo_VO.m_strOPERATOR_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 12);
                objParmArr[2].Value = p_arrOutStorageInfo_VO.m_strDRUGSTOREID;
                objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                objParmArr[3].Value = p_arrOutStorageInfo_VO.m_strSHIPPING_NO;
                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                objParmArr[4].Value = p_arrOutStorageInfo_VO.m_strITEMID;
                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 6);
                objParmArr[5].Value = p_arrOutStorageInfo_VO.m_strITEMKIND;
                objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 12);
                objParmArr[6].Value = p_arrOutStorageInfo_VO.m_strH_DRUGID;
                objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 100);
                objParmArr[7].Value = p_arrOutStorageInfo_VO.m_strGENERICNAME;
                objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                objParmArr[8].Value = p_arrOutStorageInfo_VO.m_strSPEC;
                objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 50);
                objParmArr[9].Value = p_arrOutStorageInfo_VO.m_strFORMULA;
                objParmArr[10] = new OracleParameter("11", OracleType.Number, 15);
                objParmArr[10].Value = p_arrOutStorageInfo_VO.m_dblOUTPUT_AMOUNT;
                objParmArr[11] = new OracleParameter("12", OracleType.Number, 15);
                objParmArr[11].Value = p_arrOutStorageInfo_VO.m_dblBUY_PRICE;
                objParmArr[12] = new OracleParameter("13", OracleType.Number, 15);
                objParmArr[12].Value = p_arrOutStorageInfo_VO.m_dblRETAIL_PRICE;
                objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                    objParmArr[13].Value = p_arrOutStorageInfo_VO.m_strBATCHNO;
                objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 70);
                objParmArr[14].Value = p_arrOutStorageInfo_VO.m_strMANUFACTURER;
                objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                objParmArr[15].Value = p_arrOutStorageInfo_VO.m_strSUPPLY;
                objParmArr[16] = new OracleParameter("17", OracleType.DateTime);
                objParmArr[16].Value = p_arrOutStorageInfo_VO.m_dtmEFFECTIVE_DATE;
                objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 20);
                objParmArr[17].Value = p_arrOutStorageInfo_VO.m_strWAREHOUSING_NUMBER;
                objParmArr[18] = new OracleParameter("19", OracleType.DateTime);
                objParmArr[18].Value = p_arrOutStorageInfo_VO.m_dtmSHIPPING_DATE;
                objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 2);
                objParmArr[19].Value = p_arrOutStorageInfo_VO.m_strFLAG;
                objParmArr[20] = new OracleParameter("21", OracleType.DateTime);
                objParmArr[20].Value = p_arrOutStorageInfo_VO.m_dtmUPLOAD_DATE;

                for (int j = 0; j < objParmArr.Length; j++)
                {
                    objCommand.Parameters.Add(objParmArr[j]);
                }
                lngRes = objCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 住院数据上传
        [AutoComplete]
        public long m_lngUpLoadZyData(List<clsHospRecordCS_Vo> p_glstHospRecord, 
                                      List<clsHospOrderCS_Vo> p_glstHospOrder, List<clsHospBillCS_Vo> p_glstHospBill)
        {
            long lngRes = -1;
            OracleConnection objConn = null;
            OracleCommand objCommand = null;
            OracleParameter[] objParmArr = null;
            OracleParameter[] objParmArrQuery = null;
            OracleTransaction oraTran = null;
            string p_strHospitalNO = clsDataUpload_Svc.m_strConvertValue("DSN", "hospitalcode", "457226325");
            int I1 = 0;
            int I2 = 0;
            int I3 = 0;

            try
            {
                string strSQL = @"";
                string strSQL1 = @"";
                string strSQLQuery = @"";
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();  
                oraTran = objConn.BeginTransaction();
                

                #region 病人记录信息 
                strSQL = @"insert into hosp_hospitalizationrecord
                                  (name, sex, kind, ethnicgroup, address, jobtitle, phonenumberhome,
                                   contactperson, nationality, maritalstatus, birthday, idnumbers, ssid,
                                   inhospno, inhosseqno, clinicid, patientbed, indeptcode, indeptname,
                                   maincuredocname, maincuredoccode, indate, diagnosisname1, diagnosiscode1,
                                   inhosptime, diagnosiscode2, status, outdeptcode, outdeptname, leftdate,
                                   inhospdays, organcode, birthaddes, indepttime,hospitalizationcode,hospupdate,confirmdate)
                                values
                                  (:1, :2, :3, :4, :5, :6, :7, 
                                   :8, :9, :10, :11, :12, :13, 
                                   :14, :15, :16, :17, :18, :19, 
                                   :20, :21, :22, :23, :24, 
                                   :25, :26, :27, :28, :29, :30, 
                                   :31, :32, :33, :34, 2, sysdate,:35)";

                objCommand = new OracleCommand();
                objCommand.Connection = objConn;
                objCommand.Transaction = oraTran; 
                clsHospRecordCS_Vo objRecord = null;
                //objCommand.CommandText = strSQL;

                #region 如果存在，update
                strSQL1 = @"update hosp_hospitalizationrecord
                           set name       = :1,
                               sex            = :2,
                               kind             = :3,
                               ethnicgroup            = :4,
                               address     = :5,
                               jobtitle         = :6,
                               phonenumberhome        = :7,
                               contactperson = :8,
                               nationality   = :9,
                               maritalstatus     = :10,
                               birthday   = :11,
                               idnumbers        = :12,
                               ssid       = :13,
                               inhospno            = :14,
                               clinicid  = :15,
                               patientbed        = :16,
                               indeptcode        = :17,
                               indeptname   = :18,
                               maincuredocname   = :19,
                               maincuredoccode             = :20,
                               indate             = :21,
                               diagnosisname1             = :22,
                               diagnosiscode1  = :23,
                               inhosptime  = :24,
                               diagnosiscode2  = :25,
                               status  = :26,
                               outdeptcode  = :27,
                               outdeptname  = :28,
                               leftdate     = :29,
                               inhospdays     = :30,
                               organcode             = :31,
                               birthaddes    = :32,
                               indepttime      = :33,
                               hospitalizationcode      = 2,
                               hospupdate      = sysdate,
                               confirmdate      = :34
                         where inhosseqno = :35 ";


                #endregion

                for (int i = 0; i < p_glstHospRecord.Count; i++)
                {
                    I1++;

                    objRecord = p_glstHospRecord[i];

                    #region 根据inhosseqno验证记录是否存在
                    bool blnExists = false;

                    strSQLQuery = @"select 1 from hosp_hospitalizationrecord where inhosseqno = :1";
                    objCommand.CommandText = strSQLQuery;
                    System.Data.DataTable dtbTemp = new System.Data.DataTable();
                    objParmArrQuery = new OracleParameter[1];

                    objParmArrQuery[0] = new OracleParameter("1", OracleType.VarChar, 50);
                    objParmArrQuery[0].Value = objRecord.m_strRegisterID;

                    objCommand.Parameters.Clear();
                    for (int j = 0; j < objParmArrQuery.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArrQuery[j]);
                    }
                    
                    OracleDataAdapter objAdapter = new OracleDataAdapter();
                    objAdapter.SelectCommand = objCommand;
                    objAdapter.Fill(dtbTemp);

                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        blnExists = true;
                    }
                    #endregion

                    if (!blnExists)
                    {
                        objCommand.CommandText = strSQL;
                        objParmArr = new OracleParameter[35];

                        objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                        objParmArr[0].Value = objRecord.m_strName;
                        objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 1);
                        objParmArr[1].Value = objRecord.m_strSex;
                        objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 2);
                        objParmArr[2].Value = objRecord.m_strKind;
                        objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 2);
                        objParmArr[3].Value = objRecord.m_strEthnicGroup;
                        objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                        objParmArr[4].Value = objRecord.m_strAddress;

                        objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                        objParmArr[5].Value = objRecord.m_strJobTitle;
                        objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 18);
                        objParmArr[6].Value = objRecord.m_strPhoneNum;
                        objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 50);
                        objParmArr[7].Value = objRecord.m_strContactPerson; ;
                        objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 5);
                        objParmArr[8].Value = objRecord.m_strNationality; ;

                        objParmArr[9] = new OracleParameter("10", OracleType.VarChar);
                        objParmArr[9].Value = objRecord.m_strMaritalStatus;
                        objParmArr[10] = new OracleParameter("11", OracleType.DateTime);
                        objParmArr[10].Value = objRecord.m_dtmBirthDay; ;
                        objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 18);
                        objParmArr[11].Value = objRecord.m_strIDNumber;
                        objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                        objParmArr[12].Value = objRecord.m_strSSID; ;

                        objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                        objParmArr[13].Value = objRecord.m_strInHospNO;
                        objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                        objParmArr[14].Value = objRecord.m_strRegisterID;
                        objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                        objParmArr[15].Value = objRecord.m_strClinicID;
                        objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                        objParmArr[16].Value = objRecord.m_strBedNO;

                        objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                        objParmArr[17].Value = objRecord.m_strInDeptCode;
                        objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                        objParmArr[18].Value = objRecord.m_strInDeptName;
                        objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                        objParmArr[19].Value = objRecord.m_strMainDoctorName;
                        objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 50);
                        objParmArr[20].Value = objRecord.m_strMainDoctorID;

                        objParmArr[21] = new OracleParameter("22", OracleType.DateTime);
                        objParmArr[21].Value = objRecord.m_dtmInDate;
                        objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 200);
                        objParmArr[22].Value = objRecord.m_strInDiagnosName;
                        objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 50);
                        objParmArr[23].Value = objRecord.m_strInDiagnosCode;
                        objParmArr[24] = new OracleParameter("25", OracleType.Number);
                        objParmArr[24].Value = objRecord.m_intInHospCount; ;

                        objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 50);
                        objParmArr[25].Value = objRecord.m_strOutDiagnosCode; ;
                        objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 1);
                        objParmArr[26].Value = objRecord.m_strStatus;
                        objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 50);
                        objParmArr[27].Value = objRecord.m_strOutDeptCode;
                        objParmArr[28] = new OracleParameter("29", OracleType.VarChar, 50);
                        objParmArr[28].Value = objRecord.m_strOutDeptName;

                        objParmArr[29] = new OracleParameter("30", OracleType.DateTime);
                        objParmArr[29].Value = objRecord.m_dtmOutDate;
                        objParmArr[30] = new OracleParameter("31", OracleType.Number);
                        objParmArr[30].Value = objRecord.m_intHospDay;
                        objParmArr[31] = new OracleParameter("32", OracleType.VarChar, 50);
                        objParmArr[31].Value = p_strHospitalNO;
                        objParmArr[32] = new OracleParameter("33", OracleType.VarChar, 50);
                        objParmArr[32].Value = objRecord.m_strBirthPlace;

                        objParmArr[33] = new OracleParameter("34", OracleType.DateTime);
                        objParmArr[33].Value = objRecord.m_dtmInAreaTime;
                        objParmArr[34] = new OracleParameter("35", OracleType.DateTime);
                        objParmArr[34].Value = objRecord.m_dtmConfirmDate.Date;

                        objCommand.Parameters.Clear();
                    }
                    else
                    {
                        objCommand.CommandText = strSQL1;
                        objParmArr = new OracleParameter[35];

                        objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                        objParmArr[0].Value = objRecord.m_strName;
                        objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 1);
                        objParmArr[1].Value = objRecord.m_strSex;
                        objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 2);
                        objParmArr[2].Value = objRecord.m_strKind;
                        objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 2);
                        objParmArr[3].Value = objRecord.m_strEthnicGroup;
                        objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                        objParmArr[4].Value = objRecord.m_strAddress;

                        objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 50);
                        objParmArr[5].Value = objRecord.m_strJobTitle;
                        objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 18);
                        objParmArr[6].Value = objRecord.m_strPhoneNum;
                        objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 50);
                        objParmArr[7].Value = objRecord.m_strContactPerson; ;
                        objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 5);
                        objParmArr[8].Value = objRecord.m_strNationality; ;

                        objParmArr[9] = new OracleParameter("10", OracleType.VarChar);
                        objParmArr[9].Value = objRecord.m_strMaritalStatus;
                        objParmArr[10] = new OracleParameter("11", OracleType.DateTime);
                        objParmArr[10].Value = objRecord.m_dtmBirthDay; ;
                        objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 18);
                        objParmArr[11].Value = objRecord.m_strIDNumber;
                        objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                        objParmArr[12].Value = objRecord.m_strSSID; ;

                        objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                        objParmArr[13].Value = objRecord.m_strInHospNO;
                        //objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                        //objParmArr[14].Value = objRecord.m_strRegisterID;
                        objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 50);
                        objParmArr[14].Value = objRecord.m_strClinicID;
                        objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                        objParmArr[15].Value = objRecord.m_strBedNO;

                        objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                        objParmArr[16].Value = objRecord.m_strInDeptCode;
                        objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                        objParmArr[17].Value = objRecord.m_strInDeptName;
                        objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                        objParmArr[18].Value = objRecord.m_strMainDoctorName;
                        objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 50);
                        objParmArr[19].Value = objRecord.m_strMainDoctorID;

                        objParmArr[20] = new OracleParameter("21", OracleType.DateTime);
                        objParmArr[20].Value = objRecord.m_dtmInDate;
                        objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 200);
                        objParmArr[21].Value = objRecord.m_strInDiagnosName;
                        objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 50);
                        objParmArr[22].Value = objRecord.m_strInDiagnosCode;
                        objParmArr[23] = new OracleParameter("24", OracleType.Number);
                        objParmArr[23].Value = objRecord.m_intInHospCount; ;

                        objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                        objParmArr[24].Value = objRecord.m_strOutDiagnosCode; ;
                        objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 1);
                        objParmArr[25].Value = objRecord.m_strStatus;
                        objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 50);
                        objParmArr[26].Value = objRecord.m_strOutDeptCode;
                        objParmArr[27] = new OracleParameter("28", OracleType.VarChar, 50);
                        objParmArr[27].Value = objRecord.m_strOutDeptName;

                        objParmArr[28] = new OracleParameter("29", OracleType.DateTime);
                        objParmArr[28].Value = objRecord.m_dtmOutDate;
                        objParmArr[29] = new OracleParameter("30", OracleType.Number);
                        objParmArr[29].Value = objRecord.m_intHospDay;
                        objParmArr[30] = new OracleParameter("31", OracleType.VarChar, 50);
                        objParmArr[30].Value = p_strHospitalNO;
                        objParmArr[31] = new OracleParameter("32", OracleType.VarChar, 50);
                        objParmArr[31].Value = objRecord.m_strBirthPlace;

                        objParmArr[32] = new OracleParameter("33", OracleType.DateTime);
                        objParmArr[32].Value = objRecord.m_dtmInAreaTime;
                        objParmArr[33] = new OracleParameter("34", OracleType.DateTime);
                        objParmArr[33].Value = objRecord.m_dtmConfirmDate.Date;

                        objParmArr[34] = new OracleParameter("35", OracleType.VarChar, 50);
                        objParmArr[34].Value = objRecord.m_strRegisterID;

                        objCommand.Parameters.Clear();
                    }

                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }

                    lngRes = objCommand.ExecuteNonQuery();
                } 
                #endregion

                #region 医嘱信息
                strSQL = @"insert into hosp_inhosporder
                                  (doctcode, inhosseqno, doctname, depcode, depname, groupno, itemcode,
                                   itemname, itemspec, itemprice, itemamout, itemunit, inputdt, startdt,
                                   type, organcode, groupseq, kind, useamount, useunit, frequency, usage,
                                   days, indeptcode, indeptname, stopusedoctcode, stopusedoctname, stopdt,
                                   farekind, checksamname, checkmethodname, checkposition, explanation,itemid,jxbzdm)
                                values
                                  (:1, :2, :3, :4, :5, :6, :7, 
                                   :8, :9, :10, :11, :12, :13, :14, 
                                   :15, :16, :17, :18, :19, :20, :21, :22, 
                                   :23, :24, :25, :26, :27, :28,
                                   :29, :30, :31, :32, :33, :34, :35)";
                //objCommand.Dispose();
                //objCommand = null;
                //objCommand = new OracleCommand();
                //objCommand.Connection = objConn;
                objCommand.CommandText = strSQL;
                //objCommand.Transaction = oraTran;

                clsHospOrderCS_Vo objOrder = null;
                for (int i = 0; i < p_glstHospOrder.Count; i++)
                {
                    I2++;
                    objOrder = p_glstHospOrder[i];

                    objParmArr = new OracleParameter[35];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 20);
                    objParmArr[0].Value = objOrder.m_strCreatorID;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 20);
                    objParmArr[1].Value = objOrder.m_strRegisterID;
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 50);
                    objParmArr[2].Value = objOrder.m_strCreateDoctor;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                    objParmArr[3].Value = objOrder.m_strCreateDeptID;
                    objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 50);
                    objParmArr[4].Value = objOrder.m_strCreateDept;

                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 18);
                    objParmArr[5].Value = objOrder.m_intGroupNo.ToString();
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 20);
                    objParmArr[6].Value = objOrder.m_strChargeItemID;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 200);
                    objParmArr[7].Value = objOrder.m_strChargeItemName;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                    objParmArr[8].Value = objOrder.m_strSpec;

                    objParmArr[9] = new OracleParameter("10", OracleType.Number);
                    objParmArr[9].Value = Math.Round(objOrder.m_dclPrice, 2);
                    objParmArr[10] = new OracleParameter("11", OracleType.Number);
                    objParmArr[10].Value = objOrder.m_dclAmount;
                    objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 20);
                    objParmArr[11].Value = objOrder.m_strUnit;
                    objParmArr[12] = new OracleParameter("13", OracleType.DateTime);
                    objParmArr[12].Value = objOrder.m_dtmCreateDate;

                    objParmArr[13] = new OracleParameter("14", OracleType.DateTime);
                    objParmArr[13].Value = objOrder.m_dtmStartDT;
                    objParmArr[14] = new OracleParameter("15", OracleType.Char, 1);
                    objParmArr[14].Value = objOrder.m_strType;
                    objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                    objParmArr[15].Value = p_strHospitalNO;
                    objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 18);
                    objParmArr[16].Value = objOrder.m_strOrderID;

                    objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 2);
                    objParmArr[17].Value = objOrder.m_strKind;
                    objParmArr[18] = new OracleParameter("19", OracleType.Number);
                    objParmArr[18].Value = objOrder.m_dclDosageUse;
                    objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 20);
                    objParmArr[19].Value = objOrder.m_strUseUnit;
                    objParmArr[20] = new OracleParameter("21", OracleType.Char, 6);
                    objParmArr[20].Value = objOrder.m_strFrequencyName;

                    objParmArr[21] = new OracleParameter("22", OracleType.Char, 2);
                    objParmArr[21].Value = objOrder.m_strUsageType;
                    objParmArr[22] = new OracleParameter("23", OracleType.Number);
                    objParmArr[22].Value = objOrder.m_intDays;// days
                    objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 20);
                    objParmArr[23].Value = objOrder.m_strINDeptID;
                    objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                    objParmArr[24].Value = objOrder.m_strINDeptName;

                    objParmArr[25] = new OracleParameter("26", OracleType.VarChar, 10);
                    objParmArr[25].Value = objOrder.m_strStopDoctor;
                    objParmArr[26] = new OracleParameter("27", OracleType.VarChar, 10);
                    objParmArr[26].Value = objOrder.m_strStopDoctorName;
                    objParmArr[27] = new OracleParameter("28", OracleType.DateTime);
                    objParmArr[27].Value = objOrder.m_dtmStop;
                    objParmArr[28] = new OracleParameter("29", OracleType.VarChar, 4);
                    objParmArr[28].Value = objOrder.m_strFarekind;

                    objParmArr[29] = new OracleParameter("30", OracleType.VarChar, 100);
                    objParmArr[29].Value = objOrder.m_strCheckName;
                    objParmArr[30] = new OracleParameter("31", OracleType.VarChar, 100);
                    objParmArr[30].Value = objOrder.m_strCheckMethod;
                    objParmArr[31] = new OracleParameter("32", OracleType.VarChar, 256);
                    objParmArr[31].Value = objOrder.m_strCheckPark;
                    objParmArr[32] = new OracleParameter("33", OracleType.VarChar, 500);
                    objParmArr[32].Value = objOrder.m_strRemark;
                    objParmArr[33] = new OracleParameter("34", OracleType.VarChar, 20);
                    objParmArr[33].Value = objOrder.m_strITEMID; 
                    objParmArr[34] = new OracleParameter("35", OracleType.VarChar, 2);
                    objParmArr[34].Value = objOrder.m_strJXBZDM;

                    objCommand.Parameters.Clear();
                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }

                    lngRes = objCommand.ExecuteNonQuery();
                }
                #endregion

                #region 费用信息
                strSQL = @"insert into hosp_hospitalizationbill
                                  (inhosseqno, billno, faretotal, fareselfpay, accountstartdate,
                                   accountenddate, billdate, kind, farecode, farename, sum, 
                                   organcode, bill_seqno, amount, price,
                                   indeptcode,indeptname,doctcode,doctname,
                                   farekind,flag,groupseq,itemid,executedate,depcode,depname)
                                values
                                  (:1, :2, :3, :4, :5, 
                                   :6, :7, :8, :9, :10, :11,
                                   :12, :13, :14, :15,
                                   :16, :17, :18, :19,
                                   :20, 0,:21,:22,:23,:24,:25)";
                //objCommand.Dispose();
                //objCommand = null;
                //objCommand = new OracleCommand();
                //objCommand.Connection = objConn; 
                //objCommand.CommandText = strSQL;
                //objCommand.Transaction = oraTran;


                #region 如果存在，update
                strSQL1 = @"update hosp_hospitalizationbill
                           set inhosseqno       = :1,
                               billno            = :2,
                               faretotal             = :3,
                               fareselfpay            = :4,
                               accountstartdate     = :5,
                               accountenddate         = :6,
                               billdate        = :7,
                               kind = :8,
                               farecode   = :9,
                               farename     = :10,
                               sum   = :11,
                               organcode        = :12,
                               amount            = :13,
                               price  = :14,
                               indeptcode        = :15,
                               indeptname        = :16,
                               doctcode   = :17,
                               doctname   = :18,
                               farekind             = :19,
                               flag             = 0,
                               groupseq             = :20,
                               itemid  = :21,
                               executedate  = :22,
                               depcode  = :23,
                               depname  = :24
                               
                         where bill_seqno = :25 ";

                #endregion

                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                clsHospBillCS_Vo objBillVo = null;
                for (int i = 0; i < p_glstHospBill.Count; i++)
                {
                    I3++;
                    objBillVo = p_glstHospBill[i];

                    #region 根据bill_seqno验证记录是否存在
                    bool blnExists = false;

                    strSQLQuery = @"select 1 from hosp_hospitalizationbill where bill_seqno = :1";
                    objCommand.CommandText = strSQLQuery;
                    System.Data.DataTable dtbTemp = new System.Data.DataTable();
                    objParmArrQuery = new OracleParameter[1];

                    objParmArrQuery[0] = new OracleParameter("1", OracleType.VarChar, 50);
                    objParmArrQuery[0].Value = objBillVo.m_strSEQID;

                    objCommand.Parameters.Clear();
                    for (int j = 0; j < objParmArrQuery.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArrQuery[j]);
                    }

                    OracleDataAdapter objAdapter = new OracleDataAdapter();
                    objAdapter.SelectCommand = objCommand;
                    objAdapter.Fill(dtbTemp);

                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        blnExists = true;
                    }
                    #endregion

                    if (!blnExists)
                    {
                        objCommand.CommandText = strSQL;
                        objParmArr = new OracleParameter[25];

                        objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                        objParmArr[0].Value = objBillVo.m_strRegisterID;
                        objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                        objParmArr[1].Value = objBillVo.m_strInvoNo;
                        objParmArr[2] = new OracleParameter("3", OracleType.Number, 18);
                        objParmArr[2].Value = objBillVo.m_dclInvoTotolMoney;
                        objParmArr[3] = new OracleParameter("4", OracleType.Number, 18);
                        objParmArr[3].Value = objBillVo.m_dclInvoFSPMoney;
                        objParmArr[4] = new OracleParameter("5", OracleType.DateTime);
                        objParmArr[4].Value = objBillVo.m_dtmBeginDate;

                        objParmArr[5] = new OracleParameter("6", OracleType.DateTime);
                        objParmArr[5].Value = objBillVo.m_dtmEndDate;
                        objParmArr[6] = new OracleParameter("7", OracleType.DateTime);
                        objParmArr[6].Value = objBillVo.m_dtmBillDate;
                        objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 2);
                        objParmArr[7].Value = objBillVo.m_strKind;
                        objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                        objParmArr[8].Value = objBillVo.m_strFareCode;

                        objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 200);
                        objParmArr[9].Value = objBillVo.m_strFareName.Trim();
                        objParmArr[10] = new OracleParameter("11", OracleType.Number, 18);
                        objParmArr[10].Value = objBillVo.m_dclSubMoney;
                        objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 50);
                        objParmArr[11].Value = p_strHospitalNO;
                        objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                        objParmArr[12].Value = objBillVo.m_strSEQID;

                        objParmArr[13] = new OracleParameter("14", OracleType.Number);
                        objParmArr[13].Value = objBillVo.m_intAmount;
                        objParmArr[14] = new OracleParameter("15", OracleType.Number, 18);
                        objParmArr[14].Value = objBillVo.m_dclPrice;
                        objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 20);
                        objParmArr[15].Value = objBillVo.m_strInDeptID;
                        objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                        objParmArr[16].Value = objBillVo.m_strInDeptName;

                        objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 20);
                        objParmArr[17].Value = objBillVo.m_strDoctorID;
                        objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                        objParmArr[18].Value = objBillVo.m_strDoctorName;
                        objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 2);
                        objParmArr[19].Value = objBillVo.m_strFareKind;
                        objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 18);
                        objParmArr[20].Value = objBillVo.m_strOrderID;
                        objParmArr[21] = new OracleParameter("22", OracleType.VarChar, 20);
                        objParmArr[21].Value = objBillVo.m_strITEMID;
                        objParmArr[22] = new OracleParameter("23", OracleType.DateTime);
                        objParmArr[22].Value = objBillVo.m_dtEXECUTEDATE;
                        objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 20);
                        objParmArr[23].Value = objBillVo.m_strDEPCODE;
                        objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                        objParmArr[24].Value = objBillVo.m_strDEPNAME;
                    }
                    else
                    {
                        objCommand.CommandText = strSQL1;
                        objParmArr = new OracleParameter[25];

                        objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                        objParmArr[0].Value = objBillVo.m_strRegisterID;
                        objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                        objParmArr[1].Value = objBillVo.m_strInvoNo;
                        objParmArr[2] = new OracleParameter("3", OracleType.Number, 18);
                        objParmArr[2].Value = objBillVo.m_dclInvoTotolMoney;
                        objParmArr[3] = new OracleParameter("4", OracleType.Number, 18);
                        objParmArr[3].Value = objBillVo.m_dclInvoFSPMoney;
                        objParmArr[4] = new OracleParameter("5", OracleType.DateTime);
                        objParmArr[4].Value = objBillVo.m_dtmBeginDate;

                        objParmArr[5] = new OracleParameter("6", OracleType.DateTime);
                        objParmArr[5].Value = objBillVo.m_dtmEndDate;
                        objParmArr[6] = new OracleParameter("7", OracleType.DateTime);
                        objParmArr[6].Value = objBillVo.m_dtmBillDate;
                        objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 2);
                        objParmArr[7].Value = objBillVo.m_strKind;
                        objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 50);
                        objParmArr[8].Value = objBillVo.m_strFareCode;

                        objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 200);
                        objParmArr[9].Value = objBillVo.m_strFareName.Trim();
                        objParmArr[10] = new OracleParameter("11", OracleType.Number, 18);
                        objParmArr[10].Value = objBillVo.m_dclSubMoney;
                        objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 50);
                        objParmArr[11].Value = p_strHospitalNO;
                        //objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                        //objParmArr[12].Value = objBillVo.m_strSEQID;

                        objParmArr[12] = new OracleParameter("13", OracleType.Number);
                        objParmArr[12].Value = objBillVo.m_intAmount;
                        objParmArr[13] = new OracleParameter("14", OracleType.Number, 18);
                        objParmArr[13].Value = objBillVo.m_dclPrice;
                        objParmArr[14] = new OracleParameter("15", OracleType.VarChar, 20);
                        objParmArr[14].Value = objBillVo.m_strInDeptID;
                        objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 50);
                        objParmArr[15].Value = objBillVo.m_strInDeptName;

                        objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 20);
                        objParmArr[16].Value = objBillVo.m_strDoctorID;
                        objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 50);
                        objParmArr[17].Value = objBillVo.m_strDoctorName;
                        objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 2);
                        objParmArr[18].Value = objBillVo.m_strFareKind;
                        objParmArr[19] = new OracleParameter("20", OracleType.VarChar, 18);
                        objParmArr[19].Value = objBillVo.m_strOrderID;

                        objParmArr[20] = new OracleParameter("21", OracleType.VarChar, 20);
                        objParmArr[20].Value = objBillVo.m_strITEMID;
                        objParmArr[21] = new OracleParameter("22", OracleType.DateTime);
                        objParmArr[21].Value = objBillVo.m_dtEXECUTEDATE;
                        objParmArr[22] = new OracleParameter("23", OracleType.VarChar, 20);
                        objParmArr[22].Value = objBillVo.m_strDEPCODE;
                        objParmArr[23] = new OracleParameter("24", OracleType.VarChar, 50);
                        objParmArr[23].Value = objBillVo.m_strDEPNAME;
                        objParmArr[24] = new OracleParameter("25", OracleType.VarChar, 50);
                        objParmArr[24].Value = objBillVo.m_strSEQID;
                    }

                    objCommand.Parameters.Clear();
                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }

                    lngRes = objCommand.ExecuteNonQuery();
                } 
                #endregion

                oraTran.Commit();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
                ContextUtil.SetAbort();
                oraTran.Rollback();
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
                objCommand.Dispose();
                objCommand = null;
                objParmArr = null; 
                oraTran.Dispose();
                oraTran = null;
            }
            return lngRes;
        } 
        #endregion

        #region 药库库存信息上报
        /// <summary>
        /// 药库库存信息上报
        /// </summary>
        /// <param name="p_arrStorageInfo_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadStorageInfo(com.digitalwave.iCare.ValueObject.clsStorageInfo_VO p_arrStorageInfo_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;
            string strSQL = @"insert into hosp_medinf
  (organcode,
   medinf_seq,
   itemid,
   h_drugid,
   drugstoreid,
   itemkind,
   warehousing_number,
   genericname,
   tradename,
   formula,
   spec,
   unit,
   approvedno,
   batchno,
   storeamount,
   medspeccode,
   medspec,
   manufacturer,
   supply,
   input_price,
   retail_price,
   input_date,
   effective_date,
   upload_date)
values
 (:1, :2, :3, :4, :5,:6, :7, :8, :9, :10, :11,
  :12, :13, :14, :15,:16, :17, :18, :19,:20,:21,:22,:23,:24)";
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objParmArr = new OracleParameter[24];
                objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                objParmArr[0].Value = p_arrStorageInfo_VO.m_strORGANCODE;
                objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                objParmArr[1].Value = p_arrStorageInfo_VO.m_strMEDINF_SEQ + DateTime.Now.ToString("yyyyMMddHHmmssffff");//特殊处理
                objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 20);
                objParmArr[2].Value = p_arrStorageInfo_VO.m_strITEMID;
                objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 30);
                objParmArr[3].Value = p_arrStorageInfo_VO.m_strH_DRUGID;
                objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 12);
                objParmArr[4].Value = p_arrStorageInfo_VO.m_strDRUGSTOREID;
                objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 6);
                objParmArr[5].Value = p_arrStorageInfo_VO.m_strITEMKIND;
                objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 20);
                objParmArr[6].Value = p_arrStorageInfo_VO.m_strWAREHOUSING_NUMBER;
                objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 100);
                objParmArr[7].Value = p_arrStorageInfo_VO.m_strGENERICNAME;
                objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 150);
                objParmArr[8].Value = p_arrStorageInfo_VO.m_strTRADENAME;
                objParmArr[9] = new OracleParameter("10", OracleType.VarChar, 50);
                objParmArr[9].Value = p_arrStorageInfo_VO.m_strFORMULA;
                objParmArr[10] = new OracleParameter("11", OracleType.VarChar, 50);
                objParmArr[10].Value = p_arrStorageInfo_VO.m_strSPEC;
                objParmArr[11] = new OracleParameter("12", OracleType.VarChar, 20);
                objParmArr[11].Value = p_arrStorageInfo_VO.m_strUNIT;
                objParmArr[12] = new OracleParameter("13", OracleType.VarChar, 50);
                objParmArr[12].Value = p_arrStorageInfo_VO.m_strAPPROVEDNO;
                objParmArr[13] = new OracleParameter("14", OracleType.VarChar, 50);
                objParmArr[13].Value = p_arrStorageInfo_VO.m_strBATCHNO;
                objParmArr[14] = new OracleParameter("15", OracleType.Int32);
                objParmArr[14].Value = p_arrStorageInfo_VO.m_dblSTOREAMOUNT;
                objParmArr[15] = new OracleParameter("16", OracleType.VarChar, 20);
                objParmArr[15].Value = p_arrStorageInfo_VO.m_strMEDSPECCODE;
                objParmArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                objParmArr[16].Value = p_arrStorageInfo_VO.m_strMEDSPEC;
                objParmArr[17] = new OracleParameter("18", OracleType.VarChar, 70);
                objParmArr[17].Value = p_arrStorageInfo_VO.m_strMANUFACTURER;
                objParmArr[18] = new OracleParameter("19", OracleType.VarChar, 50);
                objParmArr[18].Value = p_arrStorageInfo_VO.m_strSUPPLY; ;
                objParmArr[19] = new OracleParameter("20", OracleType.Number, 15);
                objParmArr[19].Value = p_arrStorageInfo_VO.m_dblINPUT_PRICE;
                objParmArr[20] = new OracleParameter("21", OracleType.Number, 15);
                objParmArr[20].Value = p_arrStorageInfo_VO.m_dblRETAIL_PRICE;
                objParmArr[21] = new OracleParameter("22", OracleType.DateTime);
                objParmArr[21].Value = p_arrStorageInfo_VO.m_dtmINPUT_DATE;
                objParmArr[22] = new OracleParameter("23", OracleType.DateTime);
                objParmArr[22].Value = p_arrStorageInfo_VO.m_dtmEFFECTIVE_DATE;
                objParmArr[23] = new OracleParameter("24", OracleType.DateTime);
                objParmArr[23].Value = p_arrStorageInfo_VO.m_dtmUPLOAD_DATE;

                for (int j = 0; j < objParmArr.Length; j++)
                {
                    objCommand.Parameters.Add(objParmArr[j]);
                }
                lngRes = objCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 病案首页信息上报
        #region 上传医院_病案首页数据
        /// <summary>
        /// 上传医院_病案首页数据
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertFirstPageRecordInfo(List<clsFirstPageVO> p_lstRecord)
        {
            long lngRes = 0;

            OracleConnection objConn = null;
            string strSql = string.Empty;

            //try
            //{
                #region sql
                    strSql = @"insert into hosp_ba_brzyxx
      (jgdm,
    fid,
    fprn,
    ftimes,
    ficdversion,
    fzyid,
    fage,
    fname,
    fsexbh,
    fsex,
    fbirthday,
    fbirthplace,
    fidcard,
    fcountrybh,
    fcountry,
    fnationalitybh,
    fnationality,
    fjob,
    fstatusbh,
    fstatus,
    fdwname,
    fdwaddr,
    fdwtele,
    fdwpost,
    fhkaddr,
    fhkpost,
    flxname,
    frelate,
    flxaddr,
    flxtele,
    ffbbh,
    ffb,
    fascard1,
    fascard2,
    frydate,
    frytime,
    frytykh,
    frydept,
    frybs,
    fcydate,
    fcytime,
    fcytykh,
    fcydept,
    fcybs,
    fdays,
    fmzzdbh,
    fmzzd,
    fmzdoctbh,
    fmzdoct,
    fryinfobh,
    fryinfo,
    fryzdbh,
    fryzd,
    fqzdate,
    fphzd,
    fgmyw,
    fhbsagbh,
    fhbsag,
    fhcvabbh,
    fhcvab,
    fhivabbh,
    fhivab,
    fmzcyaccobh,
    fmzcyacco,
    frycyaccobh,
    frycyacco,
    flcblaccobh,
    flcblacco,
    ffsblaccobh,
    ffsblacco,
    fopaccobh,
    fopacco,
    fqjtimes,
    fqjsuctimes,
    fkzrbh,
    fkzr,
    fzrdoctbh,
    fzrdoctor,
    fzzdoctbh,
    fzzdoct,
    fzydoctbh,
    fzydoct,
    fjxdoctbh,
    fjxdoct,
    fyjssxdoctbh,
    fyjssxdoct,
    fsxdoctbh,
    fsxdoct,
    fbmybh,
    fbmy,
    fzlrbh,
    fzlr,
    fqualitybh,
    fquality,
    fzkdoctbh,
    fzkdoct,
    fzknursebh,
    fzknurse,
    fzkrq,
    fmzdeadbh,
    fmzdead,
    fsum1,
    fcwf,
    fhlf,
    fxyf,
    fzyf,
    fzchyf,
    fzcyf,
    ffsf,
    fhyf,
    fsyf,
    fsxf,
    fzlf,
    fssf,
    fjsf,
    fjcf,
    fmzf,
    fyef,
    fpcf,
    fqtf,
    fbodybh,
    fbody,
    fisopfirstbh,
    fisopfirst,
    fiszlfirstbh,
    fiszlfirst,
    fisjcfirstbh,
    fisjcfirst,
    fiszdfirstbh,
    fiszdfirst,
    fisszbh,
    fissz,
    fszqx,
    fsamplebh,
    fsample,
    fbloodbh,
    fblood,
    frhbh,
    frh,
    fsxfybh,
    fsxfy,
    fsyfybh,
    fsyfy,
    fredcell,
    fplaque,
    fserous,
    fallblood,
    fotherblood,
    fhzyj,
    fhzyc,
    fhltj,
    fhl1,
    fhl2,
    fhl3,
    fhlzz,
    fhlts,
    fbabynum,
    ftwill,
    fqjbr,
    fqjsuc,
    fthreqz,
    fback,
    fifzdss,
    fifdbz,
    fzlfzy,
    fzktykh,
    fzkdept,
    fzkdate,
    fzktime,
    fsrybh,
    fsry,
    fworkrq,
    fjbfxbh,
    fjbfx,
    ffhgdbh,
    ffhgd,
    fsourcebh,
    fsource,
    fifss,
    fiffyk,
    fbfz,
    fyngr,
    fflag,
    fdatacheck,
    fextend1,
    fextend2,
    fextend3,
    fextend4,
    fextend5,
    fextend6,
    fextend7,
    fextend8,
    fextend9,
    fextend10,
    fextend11,
    fextend12,
    fextend13,
    fextend14,
    fextend15,
    fnative,
    fcurraddr,
    fcurrtele,
    fcurrpost,
    fjobbh,
    fcstz,
    frytz,
    fryresourcebh,
    fryresource,
    fycljbh,
    fyclj,
    fphzdbh,
    fphzdnum,
    fifgmywbh,
    fifgmyw,
    fnursebh,
    fnurse,
    flyfsbh,
    flyfs,
    fyzouthostital,
    fsqouthostital,
    fisagainrybh,
    fisagainry,
    fisagainrymd,
    fryqhmdays,
    fryqhmhours,
    fryqhmmins,
    fryqhmcounts,
    fryhmdays,
    fryhmhours,
    fryhmmins,
    fryhmcounts,
    ffbbhnew,
    ffbnew,
    fzfje,
    fzhfwlylf,
    fzhfwlczf,
    fzhfwlhlf,
    fzhfwlqtf,
    fzdlblf,
    fzdlsssf,
    fzdlyxf,
    fzdllcf,
    fzllffssf,
    fzllfwlzwlf,
    fzllfssf,
    fzllfmzf,
    fzllfsszlf,
    fkflkff,
    fzylzf,
    fxylgjf,
    fxylxf,
    fxylbqbf,
    fxylqdbf,
    fxylyxyzf,
    fxylxbyzf,
    fhclcjf,
    fhclzlf,
    fhclssf,
    fzhfwlylf01,
    fzhfwlylf02,
    fzylzdf,
    fzylzlf,
    fzylzlf01,
    fzylzlf02,
    fzylzlf03,
    fzylzlf04,
    fzylzlf05,
    fzylzlf06,
    fzylqtf,
    fzylqtf01,
    fzylqtf02,
    fzcljgzjf)
    values
   (:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12, :13, :14, :15, :16, :17, :18, :19, :20, :21, :22, :23, :24, :25, :26, :27, :28, :29, :30, 
    :31, :32, :33, :34, :35, :36, :37, :38, :39, :40, :41, :42, :43, :44, :45, :46, :47, :48, :49, :50, :51, :52, :53, :54, :55, :56, :57, :58, :59, :60,
    :61, :62, :63, :64, :65, :66, :67, :68, :69, :70, :71, :72, :73, :74, :75, :76, :77, :78, :79, :80, :81, :82, :83, :84, :85, :86, :87, :88, :89, :90,
    :91, :92, :93, :94, :95, :96, :97, :98, :99, :100, :101, :102, :103, :104, :105, :106, :107, :108, :109, :110,
    :111, :112, :113, :114, :115, :116, :117, :118, :119, :120, :121, :122, :123, :124, :125, :126, :127, :128, :129, :130,
    :131, :132, :133, :134, :135, :136, :137, :138, :139, :140, :141, :142, :143, :144, :145, :146, :147, :148, :149, :150,
    :151, :152, :153, :154, :155, :156, :157, :158, :159, :160, :161, :162, :163, :164, :165, :166, :167, :168, :169, :170,
    :171, :172, :173, :174, :175, :176, :177, :178, :179, :180, :181, :182, :183, :184, :185, :186, :187, :188, :189, :190,
    :191, :192, :193, :194, :195, :196, :197, :198, :199, :200, :201, :202, :203, :204, :205, :206, :207, :208, :209, :210,
    :211, :212, :213, :214, :215, :216, :217, :218, :219, :220, :221, :222, :223, :224, :225, :226, :227, :228, :229, :230,
    :231, :232, :233, :234, :235, :236, :237, :238, :239, :240, :241, :242, :243, :244, :245, :246, :247, :248, :249, :250,
    :251, :252, :253, :254, :255, :256, :257, :258, :259, :260, :261, :262, :263, :264, :265, :266, :267, :268, :269, :270, :271, :272)";
                #endregion
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSql, objConn);

                OracleParameter[] objDPArr = new OracleParameter[272];
                #region 参数类型
                objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 9);
                objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 100);
                objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 20);
                objDPArr[3] = new OracleParameter("4", OracleType.VarChar, 50);
                objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 20);
                objDPArr[6] = new OracleParameter("7", OracleType.VarChar, 20);
                objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 30);
                objDPArr[8] = new OracleParameter("9", OracleType.VarChar, 20);
                objDPArr[9] = new OracleParameter("10", OracleType.VarChar, 20);
                objDPArr[10] = new OracleParameter("11", OracleType.DateTime);
                objDPArr[11] = new OracleParameter("12", OracleType.VarChar, 100);
                objDPArr[12] = new OracleParameter("13", OracleType.VarChar, 30);
                objDPArr[13] = new OracleParameter("14", OracleType.VarChar, 20);
                objDPArr[14] = new OracleParameter("15", OracleType.VarChar, 100);
                objDPArr[15] = new OracleParameter("16", OracleType.VarChar, 20);
                objDPArr[16] = new OracleParameter("17", OracleType.VarChar, 50);
                objDPArr[17] = new OracleParameter("18", OracleType.VarChar, 100);
                objDPArr[18] = new OracleParameter("19", OracleType.VarChar, 20);
                objDPArr[19] = new OracleParameter("20", OracleType.VarChar, 20);
                objDPArr[20] = new OracleParameter("21", OracleType.VarChar, 60);
                objDPArr[21] = new OracleParameter("22", OracleType.VarChar, 100);
                objDPArr[22] = new OracleParameter("23", OracleType.VarChar, 40);
                objDPArr[23] = new OracleParameter("24", OracleType.VarChar, 20);
                objDPArr[24] = new OracleParameter("25", OracleType.VarChar, 100);
                objDPArr[25] = new OracleParameter("26", OracleType.VarChar, 20);
                objDPArr[26] = new OracleParameter("27", OracleType.VarChar, 30);
                objDPArr[27] = new OracleParameter("28", OracleType.VarChar, 20);
                objDPArr[28] = new OracleParameter("29", OracleType.VarChar, 100);
                objDPArr[29] = new OracleParameter("30", OracleType.VarChar, 40);
                objDPArr[30] = new OracleParameter("31", OracleType.VarChar, 20);
                objDPArr[31] = new OracleParameter("32", OracleType.VarChar, 30);
                objDPArr[32] = new OracleParameter("33", OracleType.VarChar, 100);
                objDPArr[33] = new OracleParameter("34", OracleType.VarChar, 100);
                objDPArr[34] = new OracleParameter("35", OracleType.DateTime);
                objDPArr[35] = new OracleParameter("36", OracleType.VarChar, 10);
                objDPArr[36] = new OracleParameter("37", OracleType.VarChar, 30);
                objDPArr[37] = new OracleParameter("38", OracleType.VarChar, 30);
                objDPArr[38] = new OracleParameter("39", OracleType.VarChar, 30);
                objDPArr[39] = new OracleParameter("40", OracleType.DateTime);
                objDPArr[40] = new OracleParameter("41", OracleType.VarChar, 10);
                objDPArr[41] = new OracleParameter("42", OracleType.VarChar, 30);
                objDPArr[42] = new OracleParameter("43", OracleType.VarChar, 30);
                objDPArr[43] = new OracleParameter("44", OracleType.VarChar, 30);
                objDPArr[44] = new OracleParameter("45", OracleType.Int32);
                objDPArr[45] = new OracleParameter("46", OracleType.VarChar, 30);
                objDPArr[46] = new OracleParameter("47", OracleType.VarChar, 200);
                objDPArr[47] = new OracleParameter("48", OracleType.VarChar, 20);
                objDPArr[48] = new OracleParameter("49", OracleType.VarChar, 30);
                objDPArr[49] = new OracleParameter("50", OracleType.VarChar, 20);
                objDPArr[50] = new OracleParameter("51", OracleType.VarChar, 20);
                objDPArr[51] = new OracleParameter("52", OracleType.VarChar, 30);
                objDPArr[52] = new OracleParameter("53", OracleType.VarChar, 200);
                objDPArr[53] = new OracleParameter("54", OracleType.DateTime);
                objDPArr[54] = new OracleParameter("55", OracleType.VarChar, 200);
                objDPArr[55] = new OracleParameter("56", OracleType.VarChar, 200);
                objDPArr[56] = new OracleParameter("57", OracleType.VarChar, 20);
                objDPArr[57] = new OracleParameter("58", OracleType.VarChar, 20);
                objDPArr[58] = new OracleParameter("59", OracleType.VarChar, 20);
                objDPArr[59] = new OracleParameter("60", OracleType.VarChar, 20);
                objDPArr[60] = new OracleParameter("61", OracleType.VarChar, 20);
                objDPArr[61] = new OracleParameter("62", OracleType.VarChar, 20);
                objDPArr[62] = new OracleParameter("63", OracleType.VarChar, 20);
                objDPArr[63] = new OracleParameter("64", OracleType.VarChar, 20);
                objDPArr[64] = new OracleParameter("65", OracleType.VarChar, 20);
                objDPArr[65] = new OracleParameter("66", OracleType.VarChar, 20);
                objDPArr[66] = new OracleParameter("67", OracleType.VarChar, 20);
                objDPArr[67] = new OracleParameter("68", OracleType.VarChar, 20);
                objDPArr[68] = new OracleParameter("69", OracleType.VarChar, 20);
                objDPArr[69] = new OracleParameter("70", OracleType.VarChar, 20);
                objDPArr[70] = new OracleParameter("71", OracleType.VarChar, 20);
                objDPArr[71] = new OracleParameter("72", OracleType.VarChar, 20);
                objDPArr[72] = new OracleParameter("73", OracleType.Int32);
                objDPArr[73] = new OracleParameter("74", OracleType.Int32);
                objDPArr[74] = new OracleParameter("75", OracleType.VarChar, 20);
                objDPArr[75] = new OracleParameter("76", OracleType.VarChar, 30);
                objDPArr[76] = new OracleParameter("77", OracleType.VarChar, 30);
                objDPArr[77] = new OracleParameter("78", OracleType.VarChar, 30);
                objDPArr[78] = new OracleParameter("79", OracleType.VarChar, 30);
                objDPArr[79] = new OracleParameter("80", OracleType.VarChar, 30);
                objDPArr[80] = new OracleParameter("81", OracleType.VarChar, 30);
                objDPArr[81] = new OracleParameter("82", OracleType.VarChar, 30);
                objDPArr[82] = new OracleParameter("83", OracleType.VarChar, 30);
                objDPArr[83] = new OracleParameter("84", OracleType.VarChar, 30);
                objDPArr[84] = new OracleParameter("85", OracleType.VarChar, 30);
                objDPArr[85] = new OracleParameter("86", OracleType.VarChar, 30);
                objDPArr[86] = new OracleParameter("87", OracleType.VarChar, 30);
                objDPArr[87] = new OracleParameter("88", OracleType.VarChar, 30);
                objDPArr[88] = new OracleParameter("89", OracleType.VarChar, 30);
                objDPArr[89] = new OracleParameter("90", OracleType.VarChar, 30);
                objDPArr[90] = new OracleParameter("91", OracleType.VarChar, 20);
                objDPArr[91] = new OracleParameter("92", OracleType.VarChar, 20);
                objDPArr[92] = new OracleParameter("93", OracleType.VarChar, 20);
                objDPArr[93] = new OracleParameter("94", OracleType.VarChar, 20);
                objDPArr[94] = new OracleParameter("95", OracleType.VarChar, 20);
                objDPArr[95] = new OracleParameter("96", OracleType.VarChar, 30);
                objDPArr[96] = new OracleParameter("97", OracleType.VarChar, 20);
                objDPArr[97] = new OracleParameter("98", OracleType.VarChar, 30);
                objDPArr[98] = new OracleParameter("99", OracleType.DateTime);
                objDPArr[99] = new OracleParameter("100", OracleType.VarChar, 20);
                objDPArr[100] = new OracleParameter("101", OracleType.VarChar, 20);
                objDPArr[101] = new OracleParameter("102", OracleType.Double, 18);
                objDPArr[102] = new OracleParameter("103", OracleType.Double, 18);
                objDPArr[103] = new OracleParameter("104", OracleType.Double, 18);
                objDPArr[104] = new OracleParameter("105", OracleType.Double, 18);
                objDPArr[105] = new OracleParameter("106", OracleType.Double, 18);
                objDPArr[106] = new OracleParameter("107", OracleType.Double, 18);
                objDPArr[107] = new OracleParameter("108", OracleType.Double, 18);
                objDPArr[108] = new OracleParameter("109", OracleType.Double, 18);
                objDPArr[109] = new OracleParameter("110", OracleType.Double, 18);
                objDPArr[110] = new OracleParameter("111", OracleType.Double, 18);
                objDPArr[111] = new OracleParameter("112", OracleType.Double, 18);
                objDPArr[112] = new OracleParameter("113", OracleType.Double, 18);
                objDPArr[113] = new OracleParameter("114", OracleType.Double, 18);
                objDPArr[114] = new OracleParameter("115", OracleType.Double, 18);
                objDPArr[115] = new OracleParameter("116", OracleType.Double, 18);
                objDPArr[116] = new OracleParameter("117", OracleType.Double, 18);
                objDPArr[117] = new OracleParameter("118", OracleType.Double, 18);
                objDPArr[118] = new OracleParameter("119", OracleType.Double, 18);
                objDPArr[119] = new OracleParameter("120", OracleType.Double, 18);
                objDPArr[120] = new OracleParameter("121", OracleType.VarChar, 20);
                objDPArr[121] = new OracleParameter("122", OracleType.VarChar, 20);
                objDPArr[122] = new OracleParameter("123", OracleType.VarChar, 20);
                objDPArr[123] = new OracleParameter("124", OracleType.VarChar, 20);
                objDPArr[124] = new OracleParameter("125", OracleType.VarChar, 20);
                objDPArr[125] = new OracleParameter("126", OracleType.VarChar, 20);
                objDPArr[126] = new OracleParameter("127", OracleType.VarChar, 20);
                objDPArr[127] = new OracleParameter("128", OracleType.VarChar, 20);
                objDPArr[128] = new OracleParameter("129", OracleType.VarChar, 20);
                objDPArr[129] = new OracleParameter("130", OracleType.VarChar, 20);
                objDPArr[130] = new OracleParameter("131", OracleType.VarChar, 20);
                objDPArr[131] = new OracleParameter("132", OracleType.VarChar, 20);
                objDPArr[132] = new OracleParameter("133", OracleType.VarChar, 20);
                objDPArr[133] = new OracleParameter("134", OracleType.VarChar, 20);
                objDPArr[134] = new OracleParameter("135", OracleType.VarChar, 20);
                objDPArr[135] = new OracleParameter("136", OracleType.VarChar, 20);
                objDPArr[136] = new OracleParameter("137", OracleType.VarChar, 20);
                objDPArr[137] = new OracleParameter("138", OracleType.VarChar, 20);
                objDPArr[138] = new OracleParameter("139", OracleType.VarChar, 20);
                objDPArr[139] = new OracleParameter("140", OracleType.VarChar, 20);
                objDPArr[140] = new OracleParameter("141", OracleType.VarChar, 20);
                objDPArr[141] = new OracleParameter("142", OracleType.VarChar, 20);
                objDPArr[142] = new OracleParameter("143", OracleType.VarChar, 20);
                objDPArr[143] = new OracleParameter("144", OracleType.Double, 18);
                objDPArr[144] = new OracleParameter("145", OracleType.Double, 18);
                objDPArr[145] = new OracleParameter("146", OracleType.Double, 18);
                objDPArr[146] = new OracleParameter("147", OracleType.Double, 18);
                objDPArr[147] = new OracleParameter("148", OracleType.Double, 18);
                objDPArr[148] = new OracleParameter("149", OracleType.Int32);
                objDPArr[149] = new OracleParameter("150", OracleType.Int32);
                objDPArr[150] = new OracleParameter("151", OracleType.Int32);
                objDPArr[151] = new OracleParameter("152", OracleType.Int32);
                objDPArr[152] = new OracleParameter("153", OracleType.Int32);
                objDPArr[153] = new OracleParameter("154", OracleType.Int32);
                objDPArr[154] = new OracleParameter("155", OracleType.Int32);
                objDPArr[155] = new OracleParameter("156", OracleType.Int32);
                objDPArr[156] = new OracleParameter("157", OracleType.Int32);
                objDPArr[157] = new OracleParameter("158", OracleType.VarChar, 1);
                objDPArr[158] = new OracleParameter("159", OracleType.VarChar, 1);
                objDPArr[159] = new OracleParameter("160", OracleType.VarChar, 1);
                objDPArr[160] = new OracleParameter("161", OracleType.VarChar, 1);
                objDPArr[161] = new OracleParameter("162", OracleType.VarChar, 1);
                objDPArr[162] = new OracleParameter("163", OracleType.VarChar, 1);
                objDPArr[163] = new OracleParameter("164", OracleType.VarChar, 1);
                objDPArr[164] = new OracleParameter("165", OracleType.Double, 18);
                objDPArr[165] = new OracleParameter("166", OracleType.VarChar, 30);
                objDPArr[166] = new OracleParameter("167", OracleType.VarChar, 30);
                objDPArr[167] = new OracleParameter("168", OracleType.DateTime);
                objDPArr[168] = new OracleParameter("169", OracleType.VarChar, 10);
                objDPArr[169] = new OracleParameter("170", OracleType.VarChar, 20);
                objDPArr[170] = new OracleParameter("171", OracleType.VarChar, 30);
                objDPArr[171] = new OracleParameter("172", OracleType.DateTime);
                objDPArr[172] = new OracleParameter("173", OracleType.VarChar, 20);
                objDPArr[173] = new OracleParameter("174", OracleType.VarChar, 20);
                objDPArr[174] = new OracleParameter("175", OracleType.VarChar, 20);
                objDPArr[175] = new OracleParameter("176", OracleType.VarChar, 20);
                objDPArr[176] = new OracleParameter("177", OracleType.VarChar, 20);
                objDPArr[177] = new OracleParameter("178", OracleType.VarChar, 100);
                objDPArr[178] = new OracleParameter("179", OracleType.VarChar, 1);
                objDPArr[179] = new OracleParameter("180", OracleType.VarChar, 1);
                objDPArr[180] = new OracleParameter("181", OracleType.VarChar, 1);
                objDPArr[181] = new OracleParameter("182", OracleType.Int32);
                objDPArr[182] = new OracleParameter("183", OracleType.VarChar, 20);
                objDPArr[183] = new OracleParameter("184", OracleType.VarChar, 100);
                objDPArr[184] = new OracleParameter("185", OracleType.VarChar, 20);
                objDPArr[185] = new OracleParameter("186", OracleType.VarChar, 20);
                objDPArr[186] = new OracleParameter("187", OracleType.VarChar, 20);
                objDPArr[187] = new OracleParameter("188", OracleType.VarChar, 20);
                objDPArr[188] = new OracleParameter("189", OracleType.VarChar, 20);
                objDPArr[189] = new OracleParameter("190", OracleType.VarChar, 20);
                objDPArr[190] = new OracleParameter("191", OracleType.VarChar, 20);
                objDPArr[191] = new OracleParameter("192", OracleType.VarChar, 20);
                objDPArr[192] = new OracleParameter("193", OracleType.VarChar, 20);
                objDPArr[193] = new OracleParameter("194", OracleType.VarChar, 20);
                objDPArr[194] = new OracleParameter("195", OracleType.VarChar, 20);
                objDPArr[195] = new OracleParameter("196", OracleType.VarChar, 20);
                objDPArr[196] = new OracleParameter("197", OracleType.VarChar, 20);
                objDPArr[197] = new OracleParameter("198", OracleType.VarChar, 20);
                objDPArr[198] = new OracleParameter("199", OracleType.VarChar, 20);
                objDPArr[199] = new OracleParameter("200", OracleType.VarChar, 100);
                objDPArr[200] = new OracleParameter("201", OracleType.VarChar, 100);
                objDPArr[201] = new OracleParameter("202", OracleType.VarChar, 40);
                objDPArr[202] = new OracleParameter("203", OracleType.VarChar, 20);
                objDPArr[203] = new OracleParameter("204", OracleType.VarChar, 20);
                objDPArr[204] = new OracleParameter("205", OracleType.VarChar, 40);
                objDPArr[205] = new OracleParameter("206", OracleType.VarChar, 40);
                objDPArr[206] = new OracleParameter("207", OracleType.VarChar, 20);
                objDPArr[207] = new OracleParameter("208", OracleType.VarChar, 20);
                objDPArr[208] = new OracleParameter("209", OracleType.VarChar, 20);
                objDPArr[209] = new OracleParameter("210", OracleType.VarChar, 20);
                objDPArr[210] = new OracleParameter("211", OracleType.VarChar, 30);
                objDPArr[211] = new OracleParameter("212", OracleType.VarChar, 50);
                objDPArr[212] = new OracleParameter("213", OracleType.VarChar, 20);
                objDPArr[213] = new OracleParameter("214", OracleType.VarChar, 20);
                objDPArr[214] = new OracleParameter("215", OracleType.VarChar, 30);
                objDPArr[215] = new OracleParameter("216", OracleType.VarChar, 30);
                objDPArr[216] = new OracleParameter("217", OracleType.VarChar, 20);
                objDPArr[217] = new OracleParameter("218", OracleType.VarChar, 200);
                objDPArr[218] = new OracleParameter("219", OracleType.VarChar, 200);
                objDPArr[219] = new OracleParameter("220", OracleType.VarChar, 20);
                objDPArr[220] = new OracleParameter("221", OracleType.VarChar, 20);
                objDPArr[221] = new OracleParameter("222", OracleType.VarChar, 20);
                objDPArr[222] = new OracleParameter("223", OracleType.VarChar, 400);
                objDPArr[223] = new OracleParameter("224", OracleType.Int32);
                objDPArr[224] = new OracleParameter("225", OracleType.Int32);
                objDPArr[225] = new OracleParameter("226", OracleType.Int32);
                objDPArr[226] = new OracleParameter("227", OracleType.Int32);
                objDPArr[227] = new OracleParameter("228", OracleType.Int32);
                objDPArr[228] = new OracleParameter("229", OracleType.Int32);
                objDPArr[229] = new OracleParameter("230", OracleType.Int32);
                objDPArr[230] = new OracleParameter("231", OracleType.Int32);
                objDPArr[231] = new OracleParameter("232", OracleType.VarChar, 20);
                objDPArr[232] = new OracleParameter("233", OracleType.VarChar, 30);
                objDPArr[233] = new OracleParameter("234", OracleType.Double, 18);
                objDPArr[234] = new OracleParameter("235", OracleType.Double, 18);
                objDPArr[235] = new OracleParameter("236", OracleType.Double, 18);
                objDPArr[236] = new OracleParameter("237", OracleType.Double, 18);
                objDPArr[237] = new OracleParameter("238", OracleType.Double, 18);
                objDPArr[238] = new OracleParameter("239", OracleType.Double, 18);
                objDPArr[239] = new OracleParameter("240", OracleType.Double, 18);
                objDPArr[240] = new OracleParameter("241", OracleType.Double, 18);
                objDPArr[241] = new OracleParameter("242", OracleType.Double, 18);
                objDPArr[242] = new OracleParameter("243", OracleType.Double, 18);
                objDPArr[243] = new OracleParameter("244", OracleType.Double, 18);
                objDPArr[244] = new OracleParameter("245", OracleType.Double, 18);
                objDPArr[245] = new OracleParameter("246", OracleType.Double, 18);
                objDPArr[246] = new OracleParameter("247", OracleType.Double, 18);
                objDPArr[247] = new OracleParameter("248", OracleType.Double, 18);
                objDPArr[248] = new OracleParameter("249", OracleType.Double, 18);
                objDPArr[249] = new OracleParameter("250", OracleType.Double, 18);
                objDPArr[250] = new OracleParameter("251", OracleType.Double, 18);
                objDPArr[251] = new OracleParameter("252", OracleType.Double, 18);
                objDPArr[252] = new OracleParameter("253", OracleType.Double, 18);
                objDPArr[253] = new OracleParameter("254", OracleType.Double, 18);
                objDPArr[254] = new OracleParameter("255", OracleType.Double, 18);
                objDPArr[255] = new OracleParameter("256", OracleType.Double, 18);
                objDPArr[256] = new OracleParameter("257", OracleType.Double, 18);
                objDPArr[257] = new OracleParameter("258", OracleType.Double, 18);
                objDPArr[258] = new OracleParameter("259", OracleType.Double, 18);
                objDPArr[259] = new OracleParameter("260", OracleType.Double, 18);
                objDPArr[260] = new OracleParameter("261", OracleType.Double, 18);
                objDPArr[261] = new OracleParameter("262", OracleType.Double, 18);
                objDPArr[262] = new OracleParameter("263", OracleType.Double, 18);
                objDPArr[263] = new OracleParameter("264", OracleType.Double, 18);
                objDPArr[264] = new OracleParameter("265", OracleType.Double, 18);
                objDPArr[265] = new OracleParameter("266", OracleType.Double, 18);
                objDPArr[266] = new OracleParameter("267", OracleType.Double, 18);
                objDPArr[267] = new OracleParameter("268", OracleType.Double, 18);
                objDPArr[268] = new OracleParameter("269", OracleType.Double, 18);
                objDPArr[269] = new OracleParameter("270", OracleType.Double, 18);
                objDPArr[270] = new OracleParameter("271", OracleType.Double, 18);
                objDPArr[271] = new OracleParameter("272", OracleType.Double, 18);
                #endregion
                objCommand.Parameters.AddRange(objDPArr);
                foreach (clsFirstPageVO record in p_lstRecord)
                {
                    #region 参数赋值
                    objDPArr[0].Value = record.m_strjgdm;
                    objDPArr[1].Value = record.m_strfid;
                    objDPArr[2].Value = record.m_strfprn;
                    objDPArr[3].Value = record.m_strftimes;
                    objDPArr[4].Value = record.m_strficdversion;
                    objDPArr[5].Value = record.m_strfzyid;
                    objDPArr[6].Value = record.m_strfage;
                    objDPArr[7].Value = record.m_strfname;
                    objDPArr[8].Value = record.m_strfsexbh;
                    objDPArr[9].Value = record.m_strfsex;
                    objDPArr[10].Value = record.m_strfbirthday;
                    objDPArr[11].Value = record.m_strfbirthplace;
                    objDPArr[12].Value = record.m_strfidcard;
                    objDPArr[13].Value = record.m_strfcountrybh;
                    objDPArr[14].Value = record.m_strfcountry;
                    objDPArr[15].Value = record.m_strfnationalitybh;
                    objDPArr[16].Value = record.m_strfnationality;
                    objDPArr[17].Value = record.m_strfjob;
                    objDPArr[18].Value = record.m_strfstatusbh;
                    objDPArr[19].Value = record.m_strfstatus;
                    objDPArr[20].Value = record.m_strfdwname;
                    objDPArr[21].Value = record.m_strfdwaddr;
                    objDPArr[22].Value = record.m_strfdwtele;
                    objDPArr[23].Value = record.m_strfdwpost;
                    objDPArr[24].Value = record.m_strfhkaddr;
                    objDPArr[25].Value = record.m_strfhkpost;
                    objDPArr[26].Value = record.m_strflxname;
                    objDPArr[27].Value = record.m_strfrelate;
                    objDPArr[28].Value = record.m_strflxaddr;
                    objDPArr[29].Value = record.m_strflxtele;
                    objDPArr[30].Value = record.m_strffbbh;
                    objDPArr[31].Value = record.m_strffb;
                    objDPArr[32].Value = record.m_strfascard1;
                    objDPArr[33].Value = record.m_strfascard2;
                    objDPArr[34].Value = record.m_strfrydate;
                    objDPArr[35].Value = record.m_strfrytime;
                    objDPArr[36].Value = record.m_strfrytykh;
                    objDPArr[37].Value = record.m_strfrydept;
                    objDPArr[38].Value = record.m_strfrybs;
                    objDPArr[39].Value = record.m_strfcydate;
                    objDPArr[40].Value = record.m_strfcytime;
                    objDPArr[41].Value = record.m_strfcytykh;
                    objDPArr[42].Value = record.m_strfcydept;
                    objDPArr[43].Value = record.m_strfcybs;
                    objDPArr[44].Value = record.m_Intfdays;
                    objDPArr[45].Value = record.m_strfmzzdbh;
                    objDPArr[46].Value = record.m_strfmzzd0;
                    objDPArr[47].Value = record.m_strfmzdoctbh;
                    objDPArr[48].Value = record.m_strfmzdoct;
                    objDPArr[49].Value = record.m_strfryinfobh;
                    objDPArr[50].Value = record.m_strfryinfo;
                    objDPArr[51].Value = record.m_strfryzdbh;
                    objDPArr[52].Value = record.m_strfryzd0;
                    objDPArr[53].Value = record.m_strfqzdate;
                    objDPArr[54].Value = record.m_strfphzd0;
                    objDPArr[55].Value = record.m_strfgmyw0;
                    objDPArr[56].Value = record.m_strfhbsagbh;
                    objDPArr[57].Value = record.m_strfhbsag;
                    objDPArr[58].Value = record.m_strfhcvabbh;
                    objDPArr[59].Value = record.m_strfhcvab;
                    objDPArr[60].Value = record.m_strfhivabbh;
                    objDPArr[61].Value = record.m_strfhivab;
                    objDPArr[62].Value = record.m_strfmzcyaccobh;
                    objDPArr[63].Value = record.m_strfmzcyacco;
                    objDPArr[64].Value = record.m_strfrycyaccobh;
                    objDPArr[65].Value = record.m_strfrycyacco;
                    objDPArr[66].Value = record.m_strflcblaccobh;
                    objDPArr[67].Value = record.m_strflcblacco;
                    objDPArr[68].Value = record.m_strffsblaccobh;
                    objDPArr[69].Value = record.m_strffsblacco;
                    objDPArr[70].Value = record.m_strfopaccobh;
                    objDPArr[71].Value = record.m_strfopacco;
                    objDPArr[72].Value = record.m_Intfqjtimes;
                    objDPArr[73].Value = record.m_Intfqjsuctimes;
                    objDPArr[74].Value = record.m_strfkzrbh;
                    objDPArr[75].Value = record.m_strfkzr;
                    objDPArr[76].Value = record.m_strfzrdoctbh;
                    objDPArr[77].Value = record.m_strfzrdoctor;
                    objDPArr[78].Value = record.m_strfzzdoctbh;
                    objDPArr[79].Value = record.m_strfzzdoct;
                    objDPArr[80].Value = record.m_strfzydoctbh;
                    objDPArr[81].Value = record.m_strfzydoct;
                    objDPArr[82].Value = record.m_strfjxdoctbh;
                    objDPArr[83].Value = record.m_strfjxdoct;
                    objDPArr[84].Value = record.m_strfyjssxdoctbh;
                    objDPArr[85].Value = record.m_strfyjssxdoct;
                    objDPArr[86].Value = record.m_strfsxdoctbh;
                    objDPArr[87].Value = record.m_strfsxdoct;
                    objDPArr[88].Value = record.m_strfbmybh;
                    objDPArr[89].Value = record.m_strfbmy;
                    objDPArr[90].Value = record.m_strfzlrbh;
                    objDPArr[91].Value = record.m_strfzlr;
                    objDPArr[92].Value = record.m_strfqualitybh;
                    objDPArr[93].Value = record.m_strfquality;
                    objDPArr[94].Value = record.m_strfzkdoctbh;
                    objDPArr[95].Value = record.m_strfzkdoct;
                    objDPArr[96].Value = record.m_strfzknursebh;
                    objDPArr[97].Value = record.m_strfzknurse;
                    objDPArr[98].Value = record.m_strfzkrq;
                    objDPArr[99].Value = record.m_strfmzdeadbh;
                    objDPArr[100].Value = record.m_strfmzdead;
                    objDPArr[101].Value = record.m_Dblfsum1;
                    objDPArr[102].Value = record.m_Dblfcwf;
                    objDPArr[103].Value = record.m_Dblfhlf;
                    objDPArr[104].Value = record.m_Dblfxyf;
                    objDPArr[105].Value = record.m_Dblfzyf;
                    objDPArr[106].Value = record.m_Dblfzchyf;
                    objDPArr[107].Value = record.m_Dblfzcyf;
                    objDPArr[108].Value = record.m_Dblffsf;
                    objDPArr[109].Value = record.m_Dblfhyf;
                    objDPArr[110].Value = record.m_Dblfsyf;
                    objDPArr[111].Value = record.m_Dblfsxf;
                    objDPArr[112].Value = record.m_Dblfzlf;
                    objDPArr[113].Value = record.m_Dblfssf;
                    objDPArr[114].Value = record.m_Dblfjsf;
                    objDPArr[115].Value = record.m_Dblfjcf;
                    objDPArr[116].Value = record.m_Dblfmzf;
                    objDPArr[117].Value = record.m_Dblfyef;
                    objDPArr[118].Value = record.m_Dblfpcf;
                    objDPArr[119].Value = record.m_Dblfqtf;
                    objDPArr[120].Value = record.m_strfbodybh;
                    objDPArr[121].Value = record.m_strfbody;
                    objDPArr[122].Value = record.m_strfisopfirstbh;
                    objDPArr[123].Value = record.m_strfisopfirst;
                    objDPArr[124].Value = record.m_strfiszlfirstbh;
                    objDPArr[125].Value = record.m_strfiszlfirst;
                    objDPArr[126].Value = record.m_strfisjcfirstbh;
                    objDPArr[127].Value = record.m_strfisjcfirst;
                    objDPArr[128].Value = record.m_strfiszdfirstbh;
                    objDPArr[129].Value = record.m_strfiszdfirst;
                    objDPArr[130].Value = record.m_strfisszbh;
                    objDPArr[131].Value = record.m_strfissz;
                    objDPArr[132].Value = record.m_strfszqx;
                    objDPArr[133].Value = record.m_strfsamplebh;
                    objDPArr[134].Value = record.m_strfsample;
                    objDPArr[135].Value = record.m_strfbloodbh;
                    objDPArr[136].Value = record.m_strfblood;
                    objDPArr[137].Value = record.m_strfrhbh;
                    objDPArr[138].Value = record.m_strfrh;
                    objDPArr[139].Value = record.m_strfsxfybh;
                    objDPArr[140].Value = record.m_strfsxfy;
                    objDPArr[141].Value = record.m_strfsyfybh;
                    objDPArr[142].Value = record.m_strfsyfy;
                    objDPArr[143].Value = record.m_Dblfredcell;
                    objDPArr[144].Value = record.m_Dblfplaque;
                    objDPArr[145].Value = record.m_Dblfserous;
                    objDPArr[146].Value = record.m_Dblfallblood;
                    objDPArr[147].Value = record.m_Dblfotherblood;
                    objDPArr[148].Value = record.m_Intfhzyj;
                    objDPArr[149].Value = record.m_Intfhzyc;
                    objDPArr[150].Value = record.m_Intfhltj;
                    objDPArr[151].Value = record.m_Intfhl1;
                    objDPArr[152].Value = record.m_Intfhl2;
                    objDPArr[153].Value = record.m_Intfhl3;
                    objDPArr[154].Value = record.m_Intfhlzz;
                    objDPArr[155].Value = record.m_Intfhlts;
                    objDPArr[156].Value = record.m_Intfbabynum;
                    objDPArr[157].Value = record.m_strftwill;
                    objDPArr[158].Value = record.m_strfqjbr;
                    objDPArr[159].Value = record.m_strfqjsuc;
                    objDPArr[160].Value = record.m_strfthreqz;
                    objDPArr[161].Value = record.m_strfback;
                    objDPArr[162].Value = record.m_strfifzdss;
                    objDPArr[163].Value = record.m_strfifdbz;
                    objDPArr[164].Value = record.m_Dblfzlfzy;
                    objDPArr[165].Value = record.m_strfzktykh;
                    objDPArr[166].Value = record.m_strfzkdept;
                    objDPArr[167].Value = record.m_strfzkdate;
                    objDPArr[168].Value = record.m_strfzktime;
                    objDPArr[169].Value = record.m_strfsrybh;
                    objDPArr[170].Value = record.m_strfsry;
                    objDPArr[171].Value = record.m_strDateTime;
                    objDPArr[172].Value = record.m_strfjbfxbh;
                    objDPArr[173].Value = record.m_strfjbfx;
                    objDPArr[174].Value = record.m_strffhgdbh;
                    objDPArr[175].Value = record.m_strffhgd;
                    objDPArr[176].Value = record.m_strfsourcebh;
                    objDPArr[177].Value = record.m_strfsource;
                    objDPArr[178].Value = record.m_strfifss;
                    objDPArr[179].Value = record.m_strfiffyk;
                    objDPArr[180].Value = record.m_strfbfz;
                    objDPArr[181].Value = record.m_Intfyngr;
                    objDPArr[182].Value = record.m_strfflag;
                    objDPArr[183].Value = record.m_strfdatacheck;
                    objDPArr[184].Value = record.m_strfextend1;
                    objDPArr[185].Value = record.m_strfextend2;
                    objDPArr[186].Value = record.m_strfextend3;
                    objDPArr[187].Value = record.m_strfextend4;
                    objDPArr[188].Value = record.m_strfextend5;
                    objDPArr[189].Value = record.m_strfextend6;
                    objDPArr[190].Value = record.m_strfextend7;
                    objDPArr[191].Value = record.m_strfextend8;
                    objDPArr[192].Value = record.m_strfextend9;
                    objDPArr[193].Value = record.m_strfextend10;
                    objDPArr[194].Value = record.m_strfextend11;
                    objDPArr[195].Value = record.m_strfextend12;
                    objDPArr[196].Value = record.m_strfextend13;
                    objDPArr[197].Value = record.m_strfextend14;
                    objDPArr[198].Value = record.m_strfextend15;
                    objDPArr[199].Value = record.m_strfnative;
                    objDPArr[200].Value = record.m_strfcurraddr;
                    objDPArr[201].Value = record.m_strfcurrtele;
                    objDPArr[202].Value = record.m_strfcurrpost;
                    objDPArr[203].Value = record.m_strfjobbh;
                    objDPArr[204].Value = record.m_strfcstz;
                    objDPArr[205].Value = record.m_strfrytz;
                    objDPArr[206].Value = record.m_strfryresourcebh;
                    objDPArr[207].Value = record.m_strfryresource;
                    objDPArr[208].Value = record.m_strfycljbh;
                    objDPArr[209].Value = record.m_strfyclj;
                    objDPArr[210].Value = record.m_strfphzdbh;
                    objDPArr[211].Value = record.m_strfphzdnum;
                    objDPArr[212].Value = record.m_strfifgmywbh;
                    objDPArr[213].Value = record.m_strfifgmyw;
                    objDPArr[214].Value = record.m_strfnursebh;
                    objDPArr[215].Value = record.m_strfnurse;
                    objDPArr[216].Value = record.m_strflyfsbh;
                    objDPArr[217].Value = record.m_strflyfs0;
                    objDPArr[218].Value = record.m_strfyzouthostital0;
                    objDPArr[219].Value = record.m_strfsqouthostital0;
                    objDPArr[220].Value = record.m_strfisagainrybh;
                    objDPArr[221].Value = record.m_strfisagainry;
                    objDPArr[222].Value = record.m_strfisagainrymd0;
                    objDPArr[223].Value = record.m_Intfryqhmdays;
                    objDPArr[224].Value = record.m_Intfryqhmhours;
                    objDPArr[225].Value = record.m_Intfryqhmmins;
                    objDPArr[226].Value = record.m_Intfryqhmcounts;
                    objDPArr[227].Value = record.m_Intfryhmdays;
                    objDPArr[228].Value = record.m_Intfryhmhours;
                    objDPArr[229].Value = record.m_Intfryhmmins;
                    objDPArr[230].Value = record.m_Intfryhmcounts;
                    objDPArr[231].Value = record.m_strffbbhnew;
                    objDPArr[232].Value = record.m_strffbnew;
                    objDPArr[233].Value = record.m_Dblfzfje;
                    objDPArr[234].Value = record.m_Dblfzhfwlylf;
                    objDPArr[235].Value = record.m_Dblfzhfwlczf;
                    objDPArr[236].Value = record.m_Dblfzhfwlhlf;
                    objDPArr[237].Value = record.m_Dblfzhfwlqtf;
                    objDPArr[238].Value = record.m_Dblfzdlblf;
                    objDPArr[239].Value = record.m_Dblfzdlsssf;
                    objDPArr[240].Value = record.m_Dblfzdlyxf;
                    objDPArr[241].Value = record.m_Dblfzdllcf;
                    objDPArr[242].Value = record.m_Dblfzllffssf;
                    objDPArr[243].Value = record.m_Dblfzllfwlzwlf;
                    objDPArr[244].Value = record.m_Dblfzllfssf;
                    objDPArr[245].Value = record.m_Dblfzllfmzf;
                    objDPArr[246].Value = record.m_Dblfzllfsszlf;
                    objDPArr[247].Value = record.m_Dblfkflkff;
                    objDPArr[248].Value = record.m_Dblfzylzf;
                    objDPArr[249].Value = record.m_Dblfxylgjf;
                    objDPArr[250].Value = record.m_Dblfxylxf;
                    objDPArr[251].Value = record.m_Dblfxylbqbf;
                    objDPArr[252].Value = record.m_Dblfxylqdbf;
                    objDPArr[253].Value = record.m_Dblfxylyxyzf;
                    objDPArr[254].Value = record.m_Dblfxylxbyzf;
                    objDPArr[255].Value = record.m_Dblfhclcjf;
                    objDPArr[256].Value = record.m_Dblfhclzlf;
                    objDPArr[257].Value = record.m_Dblfhclssf;
                    objDPArr[258].Value = record.m_Dblfzhfwlylf01;
                    objDPArr[259].Value = record.m_Dblfzhfwlylf02;
                    objDPArr[260].Value = record.m_Dblfzylzdf;
                    objDPArr[261].Value = record.m_Dblfzylzlf;
                    objDPArr[262].Value = record.m_Dblfzylzlf01;
                    objDPArr[263].Value = record.m_Dblfzylzlf02;
                    objDPArr[264].Value = record.m_Dblfzylzlf03;
                    objDPArr[265].Value = record.m_Dblfzylzlf04;
                    objDPArr[266].Value = record.m_Dblfzylzlf05;
                    objDPArr[267].Value = record.m_Dblfzylzlf06;
                    objDPArr[268].Value = record.m_Dblfzylqtf;
                    objDPArr[269].Value = record.m_Dblfzylqtf01;
                    objDPArr[270].Value = record.m_Dblfzylqtf02;
                    objDPArr[271].Value = record.m_Dblfzcljgzjf;
                    #endregion
                    try
                    {
                        lngRes = objCommand.ExecuteNonQuery();
                    }
                    catch (Exception objEx)
                    {
                        StreamWriter sw = new StreamWriter("D://code/txtwriter1.txt", true);
                        for (int i = 0; i < objDPArr.Length; i++)
                        {
                            sw.WriteLine("'" + objDPArr[i].Value.ToString() + "',--" + i.ToString());
                        }
                        sw.WriteLine("-----------------------------------------------------------------------------------------");
                        sw.Close();//写入

                        clsLogText objLogger = new clsLogText();
                        objLogger.LogError(objEx);
                    }
                }
            //catch (Exception objEx)
            //{
            //    clsLogText objLogger = new clsLogText();
            //    objLogger.LogError(objEx);
            //}
            //finally
            //{
                objConn.Close();
                objConn.Dispose();
            //}
            return lngRes;

        }
        #endregion

        #region 上传医院_病人手术信息
        /// <summary>
        /// 上传医院_病人手术信息
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadOperationInfo(List<clsOperationVO> p_lstRecord)
        {
            long lngRes = 0;

            OracleConnection objConn = null;
            string strSql = string.Empty;
            string strSqlQuery = string.Empty;

            try
            {
                #region sql update
                string sqlUpdate = @"  update hosp_operation set 
                                                        jgdm= :1,
                                                        fzyid= :2,
                                                        opksname= :3,
                                                        optykh= :4,
                                                        fprn= :5,
                                                        ftimes= :6,
                                                        fname= :7,
                                                        foptimes= :8,
                                                        fopcode= :9,
                                                        fop= :10,
                                                        fopdate= :11,
                                                        fqiekoubh= :12,
                                                        fqiekou= :13,
                                                        fyuhebh= :14,
                                                        fyuhe= :15,
                                                        fdocbh= :16,
                                                        fdocname= :17,
                                                        fmazuibh= :18,
                                                        fmazui= :19,
                                                        fiffsop= :20,
                                                        fopdoct1bh= :21,
                                                        fopdoct1= :22,
                                                        fopdoct2bh= :23,
                                                        fopdoct2= :24,
                                                        fmzdoctbh= :25,
                                                        fmzdoct= :26,
                                                        fpx= :27,
                                                        fzqssbh= :28,
                                                        fzqss= :29,
                                                        fssjbbh= :30,
                                                        fssjb= :31 
                                                        where fid = :32 ";

                #endregion

                #region sql
                strSql = @"insert into hosp_operation
                            (jgdm,
                            fzyid,
                            opksname,
                            optykh,
                            fid,
                            fprn,
                            ftimes,
                            fname,
                            foptimes,
                            fopcode,
                            fop,
                            fopdate,
                            fqiekoubh,
                            fqiekou,
                            fyuhebh,
                            fyuhe,
                            fdocbh,
                            fdocname,
                            fmazuibh,
                            fmazui,
                            fiffsop,
                            fopdoct1bh,
                            fopdoct1,
                            fopdoct2bh,
                            fopdoct2,
                            fmzdoctbh,
                            fmzdoct,
                            fpx,
                            fzqssbh,
                            fzqss,
                            fssjbbh,
                            fssjb)
                            values
                            (:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12, :13, :14, :15, :16, :17, :18, :19, :20, :21, :22, :23, :24, :25, :26, :27, :28, :29, :30, :31, :32)
                            ";
                #endregion
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                
                foreach (clsOperationVO record in p_lstRecord)
                {
                    bool blnExists = false;

                    #region 根据处方id验证记录是否存在
                    strSqlQuery = @"select 1 from hosp_operation where fid = :1";
                    OracleCommand objCommand_Query = new OracleCommand(strSqlQuery, objConn);
                    OracleParameter objParmArr_Query = new OracleParameter("1", OracleType.VarChar, 20);
                    objParmArr_Query.Value = record.m_strfid + record.m_Intfoptimes.ToString() ;
                    objCommand_Query.Parameters.Add(objParmArr_Query);
                    OracleDataAdapter objAdapter = new OracleDataAdapter();
                    objAdapter.SelectCommand = objCommand_Query;
                    System.Data.DataTable dtbTemp = new System.Data.DataTable();
                    objAdapter.Fill(dtbTemp);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        blnExists = true;
                    }
                    #endregion

                    if (!blnExists)
                    {
                        OracleCommand objCommand = new OracleCommand(strSql, objConn);
                        OracleParameter[] objDPArr = new OracleParameter[32];
                        #region 参数类型
                        objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 9);
                        objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                        objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 30);
                        objDPArr[3] = new OracleParameter("4", OracleType.VarChar, 100);
                        objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                        objDPArr[5] = new OracleParameter("6", OracleType.VarChar, 20);
                        objDPArr[6] = new OracleParameter("7", OracleType.Int32);
                        objDPArr[7] = new OracleParameter("8", OracleType.VarChar, 30);
                        objDPArr[8] = new OracleParameter("9", OracleType.Int32);
                        objDPArr[9] = new OracleParameter("10", OracleType.VarChar, 20);
                        objDPArr[10] = new OracleParameter("11", OracleType.VarChar, 200);
                        objDPArr[11] = new OracleParameter("12", OracleType.DateTime);
                        objDPArr[12] = new OracleParameter("13", OracleType.VarChar, 20);
                        objDPArr[13] = new OracleParameter("14", OracleType.VarChar, 20);
                        objDPArr[14] = new OracleParameter("15", OracleType.VarChar, 20);
                        objDPArr[15] = new OracleParameter("16", OracleType.VarChar, 20);
                        objDPArr[16] = new OracleParameter("17", OracleType.VarChar, 30);
                        objDPArr[17] = new OracleParameter("18", OracleType.VarChar, 30);
                        objDPArr[18] = new OracleParameter("19", OracleType.VarChar, 20);
                        objDPArr[19] = new OracleParameter("20", OracleType.VarChar, 30);
                        objDPArr[20] = new OracleParameter("21", OracleType.VarChar, 10);
                        objDPArr[21] = new OracleParameter("22", OracleType.VarChar, 30);
                        objDPArr[22] = new OracleParameter("23", OracleType.VarChar, 30);
                        objDPArr[23] = new OracleParameter("24", OracleType.VarChar, 30);
                        objDPArr[24] = new OracleParameter("25", OracleType.VarChar, 30);
                        objDPArr[25] = new OracleParameter("26", OracleType.VarChar, 30);
                        objDPArr[26] = new OracleParameter("27", OracleType.VarChar, 30);
                        objDPArr[27] = new OracleParameter("28", OracleType.VarChar, 30);
                        objDPArr[28] = new OracleParameter("29", OracleType.VarChar, 20);
                        objDPArr[29] = new OracleParameter("30", OracleType.VarChar, 20);
                        objDPArr[30] = new OracleParameter("31", OracleType.VarChar, 20);
                        objDPArr[31] = new OracleParameter("32", OracleType.VarChar, 20);
                        #endregion
                        objCommand.Parameters.AddRange(objDPArr);

                        #region INSERT INTO
                        #region 参数赋值
                        objDPArr[0].Value = record.m_strjgdm;
                        objDPArr[1].Value = record.m_strfzyid;
                        objDPArr[2].Value = record.m_stropksname;
                        objDPArr[3].Value = record.m_stroptykh;
                        objDPArr[4].Value = record.m_strfid + record.m_Intfoptimes.ToString();
                        objDPArr[5].Value = record.m_strfprn;
                        objDPArr[6].Value = record.m_Intftimes;
                        objDPArr[7].Value = record.m_strfname;
                        objDPArr[8].Value = record.m_Intfoptimes;
                        objDPArr[9].Value = record.m_strfopcode;
                        objDPArr[10].Value = record.m_strfop;
                        objDPArr[11].Value = record.m_strfopdate;
                        objDPArr[12].Value = record.m_strfqiekoubh;
                        objDPArr[13].Value = record.m_strfqiekou;
                        objDPArr[14].Value = record.m_strfyuhebh;
                        objDPArr[15].Value = record.m_strfyuhe;
                        objDPArr[16].Value = record.m_strfdocbh;
                        objDPArr[17].Value = record.m_strfdocname;
                        objDPArr[18].Value = record.m_strfmazuibh;
                        objDPArr[19].Value = record.m_strfmazui;
                        objDPArr[20].Value = record.m_strfiffsop;
                        objDPArr[21].Value = record.m_strfopdoct1bh;
                        objDPArr[22].Value = record.m_strfopdoct1;
                        objDPArr[23].Value = record.m_strfopdoct2bh;
                        objDPArr[24].Value = record.m_strfopdoct2;
                        objDPArr[25].Value = record.m_strfmzdoctbh;
                        objDPArr[26].Value = record.m_strfmzdoct;
                        objDPArr[27].Value = record.m_strfpx;
                        objDPArr[28].Value = record.m_strfzqssbh;
                        objDPArr[29].Value = record.m_strfzqss;
                        objDPArr[30].Value = record.m_strfssjbbh;
                        objDPArr[31].Value = record.m_strfssjb;

                        #endregion
                        lngRes = objCommand.ExecuteNonQuery();
                        #endregion
                    }
                    else
                    {
                        OracleCommand objCommand = new OracleCommand(sqlUpdate, objConn);
                        OracleParameter[] objDPArr = new OracleParameter[32];
                        #region 参数类型
                        objDPArr[0] = new OracleParameter("1", OracleType.VarChar, 9);
                        objDPArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                        objDPArr[2] = new OracleParameter("3", OracleType.VarChar, 30);
                        objDPArr[3] = new OracleParameter("4", OracleType.VarChar, 100);
                        //objDPArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                        objDPArr[4] = new OracleParameter("6", OracleType.VarChar, 20);
                        objDPArr[5] = new OracleParameter("7", OracleType.Int32);
                        objDPArr[6] = new OracleParameter("8", OracleType.VarChar, 30);
                        objDPArr[7] = new OracleParameter("9", OracleType.Int32);
                        objDPArr[8] = new OracleParameter("10", OracleType.VarChar, 20);
                        objDPArr[9] = new OracleParameter("11", OracleType.VarChar, 200);
                        objDPArr[10] = new OracleParameter("12", OracleType.DateTime);
                        objDPArr[11] = new OracleParameter("13", OracleType.VarChar, 20);
                        objDPArr[12] = new OracleParameter("14", OracleType.VarChar, 20);
                        objDPArr[13] = new OracleParameter("15", OracleType.VarChar, 20);
                        objDPArr[14] = new OracleParameter("16", OracleType.VarChar, 20);
                        objDPArr[15] = new OracleParameter("17", OracleType.VarChar, 30);
                        objDPArr[16] = new OracleParameter("18", OracleType.VarChar, 30);
                        objDPArr[17] = new OracleParameter("19", OracleType.VarChar, 20);
                        objDPArr[18] = new OracleParameter("20", OracleType.VarChar, 30);
                        objDPArr[19] = new OracleParameter("21", OracleType.VarChar, 10);
                        objDPArr[20] = new OracleParameter("22", OracleType.VarChar, 30);
                        objDPArr[21] = new OracleParameter("23", OracleType.VarChar, 30);
                        objDPArr[22] = new OracleParameter("24", OracleType.VarChar, 30);
                        objDPArr[23] = new OracleParameter("25", OracleType.VarChar, 30);
                        objDPArr[24] = new OracleParameter("26", OracleType.VarChar, 30);
                        objDPArr[25] = new OracleParameter("27", OracleType.VarChar, 30);
                        objDPArr[26] = new OracleParameter("28", OracleType.VarChar, 30);
                        objDPArr[27] = new OracleParameter("29", OracleType.VarChar, 20);
                        objDPArr[28] = new OracleParameter("30", OracleType.VarChar, 20);
                        objDPArr[29] = new OracleParameter("31", OracleType.VarChar, 20);
                        objDPArr[30] = new OracleParameter("32", OracleType.VarChar, 20);
                        objDPArr[31] = new OracleParameter("5", OracleType.VarChar, 20);
                        #endregion
                        objCommand.Parameters.AddRange(objDPArr);

                        #region UPDATE
                        #region 参数赋值
                        objDPArr[0].Value = record.m_strjgdm;
                        objDPArr[1].Value = record.m_strfzyid;
                        objDPArr[2].Value = record.m_stropksname;
                        objDPArr[3].Value = record.m_stroptykh;
                        //objDPArr[4].Value = record.m_strfid + record.m_Intfoptimes.ToString();
                        objDPArr[4].Value = record.m_strfprn;
                        objDPArr[5].Value = record.m_Intftimes;
                        objDPArr[6].Value = record.m_strfname;
                        objDPArr[7].Value = record.m_Intfoptimes;
                        objDPArr[8].Value = record.m_strfopcode;
                        objDPArr[9].Value = record.m_strfop;
                        objDPArr[10].Value = record.m_strfopdate;
                        objDPArr[11].Value = record.m_strfqiekoubh;
                        objDPArr[12].Value = record.m_strfqiekou;
                        objDPArr[13].Value = record.m_strfyuhebh;
                        objDPArr[14].Value = record.m_strfyuhe;
                        objDPArr[15].Value = record.m_strfdocbh;
                        objDPArr[16].Value = record.m_strfdocname;
                        objDPArr[17].Value = record.m_strfmazuibh;
                        objDPArr[18].Value = record.m_strfmazui;
                        objDPArr[19].Value = record.m_strfiffsop;
                        objDPArr[20].Value = record.m_strfopdoct1bh;
                        objDPArr[21].Value = record.m_strfopdoct1;
                        objDPArr[22].Value = record.m_strfopdoct2bh;
                        objDPArr[23].Value = record.m_strfopdoct2;
                        objDPArr[24].Value = record.m_strfmzdoctbh;
                        objDPArr[25].Value = record.m_strfmzdoct;
                        objDPArr[26].Value = record.m_strfpx;
                        objDPArr[27].Value = record.m_strfzqssbh;
                        objDPArr[28].Value = record.m_strfzqss;
                        objDPArr[29].Value = record.m_strfssjbbh;
                        objDPArr[30].Value = record.m_strfssjb;
                        objDPArr[31].Value = record.m_strfid + record.m_Intfoptimes.ToString();

                        #endregion
                        lngRes = objCommand.ExecuteNonQuery();
                        #endregion
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;

        }
        #endregion

        /// <summary>
        /// 删除前置机指定日期记录 
        /// </summary>
        /// <param name="p_strStardDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelFirstPageDataByDate(string p_strStardDate, string p_strEndDate)
        {
            long lngRes = 1;
            if (string.IsNullOrEmpty(p_strStardDate) || string.IsNullOrEmpty(p_strEndDate))
                return lngRes;

            OracleConnection objConn = null;
            string strSQL = "";

            try
            {
                strSQL = @"delete hosp_operation a where a.fzyid in (select fzyid from hosp_ba_brzyxx t where t.fcydate between :1 and :2)";
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();
                OracleCommand objCommand = new OracleCommand(strSQL, objConn);

                OracleParameter[] objDPArr = new OracleParameter[2];
                objDPArr[0] = new OracleParameter("1", OracleType.DateTime);
                objDPArr[0].Value = Convert.ToDateTime(p_strStardDate);
                objDPArr[1] = new OracleParameter("2", OracleType.DateTime);
                objDPArr[1].Value = Convert.ToDateTime(p_strEndDate);

                objCommand.Parameters.AddRange(objDPArr);
                lngRes = objCommand.ExecuteNonQuery();

                strSQL = @"delete hosp_ba_brzyxx t where t.fcydate between :1 and :2";
                objCommand.CommandText = strSQL;
                lngRes = objCommand.ExecuteNonQuery();
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                }


            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 项目对照信息上传
        /// <summary>
        /// 项目对照信息上传
        /// </summary>
        /// <param name="arrItemControl_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadItemControl(clsItemControl_VO arrItemControl_VO)
        {
            long lngRes = 0;
            OracleConnection objConn = null;

            string strSQL = string.Empty;
            try
            {
                string strConnection = m_strGetDbConnection();
                objConn = new OracleConnection(strConnection);
                objConn.Open();

                bool blnExists = false;

                #region 根据流水号验证记录是否存在
                strSQL = @"select 1 from hosp_itemcenter where hosp_itemcenterid = :1";
                OracleCommand objCommand_Query = new OracleCommand(strSQL, objConn);
                OracleParameter objParmArr_Query = new OracleParameter("1", OracleType.VarChar, 12);
                objParmArr_Query.Value = arrItemControl_VO.HOSP_ITEMCENTERID;
                objCommand_Query.Parameters.Add(objParmArr_Query);
                OracleDataAdapter objAdapter = new OracleDataAdapter();
                objAdapter.SelectCommand = objCommand_Query;
                System.Data.DataTable dtbTemp = new System.Data.DataTable();
                objAdapter.Fill(dtbTemp);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    blnExists = true;
                }
                #endregion
                com.digitalwave.Utility.clsLogText objjianjun = new clsLogText();
                objjianjun.LogError("h_itemspec:" + arrItemControl_VO.H_ITEMSPEC);
                if (!blnExists)
                {
                    #region 如果不存在，则insert
                    strSQL = @"insert into hosp_itemcenter
                                      (hosp_itemcenterid,
                                       organcode,
                                       itemid,
                                       itemname,
                                       itemspec,
                                       packagspec,
                                       h_itemcode,
                                       h_itemname,
                                       h_itemspec)
                                    values
                                      (:1, :2, :3, :4, :5, :6, :7, :8, :9)";
                    OracleCommand objCommand = new OracleCommand(strSQL, objConn);
                    OracleParameter[] objParmArr = new OracleParameter[9];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 12);
                    objParmArr[0].Value = arrItemControl_VO.HOSP_ITEMCENTERID;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 50);
                    objParmArr[1].Value = arrItemControl_VO.ORGANCODE;
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 20);
                    objParmArr[2].Value = arrItemControl_VO.ITEMID;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 100);
                    objParmArr[3].Value = arrItemControl_VO.ITEMNAME;
                    objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                    objParmArr[4].Value = arrItemControl_VO.ITEMSPEC;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 20);
                    objParmArr[5].Value = arrItemControl_VO.PACKAGSPEC;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 40);
                    objParmArr[6].Value = arrItemControl_VO.H_ITEMCODE;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 40);
                    objParmArr[7].Value = arrItemControl_VO.H_ITEMNAME;
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 20);
                    objParmArr[8].Value = arrItemControl_VO.H_ITEMSPEC;                    
                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();
                    #endregion
                }
                else
                {
                    #region 如果存在，则update
                    strSQL = @"update hosp_itemcenter
                                       set organcode  = :1,
                                           itemid     = :2,
                                           itemname   = :3,
                                           itemspec   = :4,
                                           packagspec = :5,
                                           h_itemcode = :6,
                                           h_itemname = :7,
                                           h_itemspec = :8
                                     where hosp_itemcenterid = :9";
                    OracleCommand objCommand = new OracleCommand(strSQL, objConn);
                    OracleParameter[] objParmArr = new OracleParameter[9];
                    objParmArr[0] = new OracleParameter("1", OracleType.VarChar, 50);
                    objParmArr[0].Value = arrItemControl_VO.ORGANCODE;
                    objParmArr[1] = new OracleParameter("2", OracleType.VarChar, 20);
                    objParmArr[1].Value = arrItemControl_VO.ITEMID;
                    objParmArr[2] = new OracleParameter("3", OracleType.VarChar, 100);
                    objParmArr[2].Value = arrItemControl_VO.ITEMNAME;
                    objParmArr[3] = new OracleParameter("4", OracleType.VarChar, 20);
                    objParmArr[3].Value = arrItemControl_VO.ITEMSPEC;
                    objParmArr[4] = new OracleParameter("5", OracleType.VarChar, 20);
                    objParmArr[4].Value = arrItemControl_VO.PACKAGSPEC;
                    objParmArr[5] = new OracleParameter("6", OracleType.VarChar, 40);
                    objParmArr[5].Value = arrItemControl_VO.H_ITEMCODE;
                    objParmArr[6] = new OracleParameter("7", OracleType.VarChar, 40);
                    objParmArr[6].Value = arrItemControl_VO.H_ITEMNAME;
                    objParmArr[7] = new OracleParameter("8", OracleType.VarChar, 20);
                    objParmArr[7].Value = arrItemControl_VO.H_ITEMSPEC;                    
                    objParmArr[8] = new OracleParameter("9", OracleType.VarChar, 12);
                    objParmArr[8].Value = arrItemControl_VO.HOSP_ITEMCENTERID;
                    for (int j = 0; j < objParmArr.Length; j++)
                    {
                        objCommand.Parameters.Add(objParmArr[j]);
                    }
                    lngRes = objCommand.ExecuteNonQuery();
                    #endregion
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
            return lngRes;
        }
        #endregion
    }
}