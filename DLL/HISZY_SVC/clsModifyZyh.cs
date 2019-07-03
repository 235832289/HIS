using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
//using Oracle.DataAccess.Client;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsModifyZyh : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        public clsModifyZyh()
        {
        }
        #endregion

        #region 获取住院(留观)号首位标志符
        /// <summary>
        /// 获取住院(留观)号首位标志符
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetpresign(int type)
        {
            string presign = "";
            string SQL = @"select firstflag_vchr from t_opr_bih_inpatientnomax where flag_int = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();                
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);                
                ParamArr[0].Value = type;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    presign = dt.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return presign;
        }
        #endregion

        #region 判断新号是否已存在
        /// <summary>
        /// 判断新号是否已存在
        /// </summary>
        /// <param name="newno"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckNewNO(string newno)
        {
            bool ret = false;
            string SQL = @"select count(inpatientid_chr) as nums from t_opr_bih_register where inpatientid_chr = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = newno;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    ret = true;
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

        #region 根据病人ID和当前入院性质(普通住院、留观住院)获取对应得(留观、住院)历史记录
        /// <summary>
        /// 根据病人ID和当前入院性质(普通住院、留观住院)获取对应得(留观、住院)历史记录
        /// </summary>
        /// <param name="pid">病人ID</param>
        /// <param name="type">入院类型 1 普通住院 2 留观住院</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetHistoryinfoByPID(string pid, int type, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select * from t_opr_bih_register 
                            where patientid_chr = ? and inpatientnotype_int = ? order by inpatient_dat desc";
                          
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = pid;
                ParamArr[1].Value = type;

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

        #region 将当前住院(留观)号改为一新号
        /// <summary>
        /// 将当前住院(留观)号改为一新号
        /// </summary>
        /// <param name="patientid">病人编号</param>
        /// <param name="regid">入院登记号</param>
        /// <param name="currno">当前号</param>
        /// <param name="newno">flag=1 新号 2 自动生成号 3 旧号</param>
        /// <param name="zycs">flag=3时旧号次数+1</param>
        /// <param name="miflag">多次住院标志</param>
        /// <param name="sameflag">同一病人标志</param>
        /// <param name="type">0 住院号->住院号 1 住院号->留观号 2 留观号->留观号 3 留观号->住院号</param>
        /// <param name="flag">1 新建 2 自动 3 合并</param>
        /// <param name="operid">修改操作员ID</param>
        /// <returns>true 成功 false 失败</returns>
        [AutoComplete]
        public bool m_blnModifyNewNO(string patientid, string regid, string currno, ref string newno, int zycs, bool miflag, bool sameflag, int type, int flag, string operid)
        {
            long l = 0, lngAffects = 0;
            bool ret = false;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
               
                int tmpType = type;

                string oldpreflag = "";                
                string preflag = "";                
                switch (tmpType)
                {
                    case 0:
                        type = 1;                                    
                        break;
                    case 1:
                        type = 2;
                        oldpreflag = this.m_strGetpresign(1);                      
                        break;
                    case 2:
                        type = 2;
                        break;
                    case 3:
                        type = 1;
                        oldpreflag = this.m_strGetpresign(2);                       
                        break;                    
                }
                preflag = this.m_strGetpresign(type);
                
                if (flag == 2)
                {
                    string s1 = "";
                    if (preflag == "")
                    {
                        s1 = "(firstflag_vchr is null or firstflag_vchr = '')";
                    }
                    else
                    {
                        s1 = "firstflag_vchr = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = preflag;
                    }

                    SQL = @"select maxinpatientno_vchr from t_opr_bih_inpatientnohis where " + s1 + " order by to_number(maxinpatientno_vchr)";

                    DataTable dt = new DataTable();
                    if (ParamArr == null)
                    {
                        l = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                    }
                    else
                    {
                        l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    }

                    if (l > 0 && dt.Rows.Count > 0)
                    {
                        newno = preflag + dt.Rows[0][0].ToString();

                        //取得历史废号后删除废号记录
                        SQL = @"delete from t_opr_bih_inpatientnohis where maxinpatientno_vchr = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = dt.Rows[0][0].ToString();

                        l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                    else
                    {
                        SQL = @"select maxinpatientno_vchr from t_opr_bih_inpatientnomax where flag_int = ? and " + s1;

                        if (ParamArr == null)
                        {
                            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = type;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = type;
                            ParamArr[1].Value = preflag;                            
                        }

                        dt = new DataTable();
                        l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                        if (l > 0 && dt.Rows.Count == 1)
                        {
                            int len1 = currno.Length - 1;
                            newno = Convert.ToString((int.Parse(dt.Rows[0][0].ToString()) + 1));                                                        
                            if (newno.Length < len1)
                            {
                                newno = newno.PadLeft(len1 - newno.Length, '0');
                            }

                            //更新最大号记录
                            SQL = @"update t_opr_bih_inpatientnomax set maxinpatientno_vchr = ? where flag_int = ? and " + s1;

                            if (preflag == "")
                            {
                                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                                ParamArr[0].Value = newno;
                                ParamArr[1].Value = type;
                            }
                            else
                            {
                                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                                ParamArr[0].Value = newno;
                                ParamArr[1].Value = type;
                                ParamArr[2].Value = preflag;
                            }

                            l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                            newno = preflag + newno;
                        }
                    }
                }

                if (flag == 3)
                {
                    //更新入院登记表
                    SQL = @"update t_opr_bih_register
                            set patientid_chr = ?, 
                                inpatientnotype_int = ?, 
                                inpatientid_chr = ?,
                                inpatientcount_int = ? 
                          where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[4]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = patientid;
                    ParamArr[1].Value = type;
                    ParamArr[2].Value = newno;
                    ParamArr[3].Value = zycs;
                    ParamArr[4].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                                       
                    //更新医嘱表
                    SQL = @"update t_opr_bih_order
                            set patientid_chr = ?   
                          where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                    
                    ParamArr[0].Value = patientid;                   
                    ParamArr[1].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //更新预缴金表
                    SQL = @"update t_opr_bih_prepay
                            set patientid_chr = ?  
                          where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = patientid;
                    ParamArr[1].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //更新期帐表
                    SQL = @"update t_opr_bih_dayaccount
                            set patientid_chr = ?  
                          where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = patientid;
                    ParamArr[1].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //更新费用明细表
                    SQL = @"update t_opr_bih_patientcharge
                            set patientid_chr = ?  
                          where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = patientid;
                    ParamArr[1].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //更新缴费记录表
                    SQL = @"update t_opr_bih_paymoney
                            set patientid_chr = ?  
                          where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = patientid;
                    ParamArr[1].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else
                {
                    //更新入院登记表
                    if (miflag)
                    {
                        SQL = @"update t_opr_bih_register
                            set inpatientid_chr = ?,
                                inpatientcount_int = 1,  
                                inpatientnotype_int = ?   
                          where registerid_chr = ?";
                    }
                    else
                    {
                        SQL = @"update t_opr_bih_register
                            set inpatientid_chr = ?, 
                                inpatientnotype_int = ?   
                          where registerid_chr = ?";
                    }

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    //((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = newno;
                    ParamArr[1].Value = type;
                    ParamArr[2].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);                                                                    
                }

                string strPatId = string.Empty;
                if ((flag != 3 && !miflag) || (flag == 3 && sameflag && !miflag))
                {
                    string strSQL_PatId = @"
                                        select patientid_chr
                                          from t_opr_bih_register
                                         where registerid_chr = ?";
                    IDataParameter[] objParamArr_PatId = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr_PatId);
                    objParamArr_PatId[0].Value = regid;
                    DataTable dtbPatId = null;
                    objHRPSvc.lngGetDataTableWithParameters(strSQL_PatId, ref dtbPatId, objParamArr_PatId);
                    if (dtbPatId != null && dtbPatId.Rows.Count > 0)
                    {
                        strPatId = dtbPatId.Rows[0]["patientid_chr"].ToString().Trim();
                    }

                    //更新病人资料表
                    SQL = @"update t_bse_patient 
                            set [currtype] = '[newno]', 
                                [oldtype] = ''  
                        where patientid_chr = (
                                        select patientid_chr
                                          from t_opr_bih_register
                                         where registerid_chr = ?)";

                    if (type == 1)
                    {
                        SQL = SQL.Replace("[currtype]", "inpatientid_chr");
                        SQL = SQL.Replace("[oldtype]", "inpatienttempid_vchr");
                    }
                    else if (type == 2)
                    {
                        SQL = SQL.Replace("[currtype]", "inpatienttempid_vchr");
                        SQL = SQL.Replace("[oldtype]", "inpatientid_chr");
                    }

                    //合并时清空住院(留观)号
                    if (flag == 3)
                    {
                        SQL = SQL.Replace("[newno]", "");
                    }
                    else
                    {
                        SQL = SQL.Replace("[newno]", newno);
                    }

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ParamArr[0].Value = regid;
                    
                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else if (flag != 3 && miflag)
                {
                    string strSQL_PatId = @"
                                        select patientid_chr
                                          from t_opr_bih_register
                                         where registerid_chr = ?";
                    IDataParameter[] objParamArr_PatId = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr_PatId);
                    objParamArr_PatId[0].Value = regid;
                    DataTable dtbPatId = null;
                    objHRPSvc.lngGetDataTableWithParameters(strSQL_PatId, ref dtbPatId, objParamArr_PatId);
                    if (dtbPatId != null && dtbPatId.Rows.Count > 0)
                    {
                        strPatId = dtbPatId.Rows[0]["patientid_chr"].ToString().Trim();
                    }

                    //更新病人资料表
                    SQL = @"update t_bse_patient 
                            set [currtype] = ?  
                        where patientid_chr = (
                                        select patientid_chr
                                          from t_opr_bih_register
                                         where registerid_chr = ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);                                       

                    if (type == 1)
                    {
                        SQL = SQL.Replace("[currtype]", "inpatientid_chr");
                        //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    }
                    else if (type == 2)
                    {
                        SQL = SQL.Replace("[currtype]", "inpatienttempid_vchr");
                        //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Varchar2;
                    }

                    //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = newno;
                    ParamArr[1].Value = regid;

                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else if (flag == 3 && sameflag == false && !miflag)
                {
                    string strSQL_PatId = @"
                                        select patientid_chr
                                          from t_bse_patient
                                         where inpatientid_chr = ?";
                    IDataParameter[] objParamArr_PatId = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr_PatId);
                    objParamArr_PatId[0].Value = currno;
                    DataTable dtbPatId = null;
                    objHRPSvc.lngGetDataTableWithParameters(strSQL_PatId, ref dtbPatId, objParamArr_PatId);
                    if (dtbPatId != null && dtbPatId.Rows.Count > 0)
                    {
                        strPatId = dtbPatId.Rows[0]["patientid_chr"].ToString().Trim();
                    }

                    SQL = @"update t_bse_patient set inpatientid_chr = '' where inpatientid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = currno;
                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                if (strPatId != string.Empty)
                {
                    //消息处理
                    com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update objMsgUpdate = new com.digitalwave.iCare.middletier.SynchroTransmitter.clsSvc_MessageOperator_Update();
                    try
                    {
                        l = objMsgUpdate.AddMsg("10001", 2, strPatId);
                    }
                    catch (Exception objEx)
                    {
                        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                        l = -1;
                    }
                    finally
                    {
                        objMsgUpdate.Dispose();
                        objMsgUpdate = null;
                    }
                    if (l < 0)
                    {
                        ContextUtil.SetAbort();
                    }
                }

                //更新HIS与EMR住院信息关联表
                SQL = @"update t_bse_hisemr_relation 
                                set hisinpatientid_chr = ?, 
                                    operatorid_chr = ?, 
                                    operat_dat = sysdate  
                            where registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                //((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                //((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = newno;
                ParamArr[1].Value = operid;
                ParamArr[2].Value = regid;

                l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr); 

                if (flag == 1)
                {
                    SQL = @"delete from t_opr_bih_inpatientnohis where (nvl(firstflag_vchr, '') || nvl(maxinpatientno_vchr, '')) = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);                    
                    ParamArr[0].Value = newno;
                    
                    l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                if (!miflag)
                {    
                    //需满足住院(留观)号规则  
                    if (tmpType == 1 || tmpType == 3)
                    {
                        preflag = oldpreflag;
                    }
                    
                    bool b = false;
                    string val = "";

                    if (preflag.Trim() == "")
                    {
                        val = currno;
                        if (Microsoft.VisualBasic.Information.IsNumeric(val))
                        {
                            b = true;
                        }
                    }
                    else
                    {
                        val = currno.Substring(1);
                        if (preflag == currno.Substring(0, 1) && Microsoft.VisualBasic.Information.IsNumeric(val))
                        {
                            b = true;
                        }
                    }                                                                                               
                    
                    if (b)
                    {
                        //放旧号到费号表(历史表)
                        SQL = @"insert into t_opr_bih_inpatientnohis (seqid_int, firstflag_vchr, maxinpatientno_vchr) 
                                                    values (seq_public.nextval, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = preflag;
                        ParamArr[1].Value = val;

                        l = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                }
                
                #region 增加资料变动记录
                clsPatientInfLog piLog = new clsPatientInfLog();
                piLog.registerId = regid;
                piLog.operatorId = operid;
                piLog.desc = "";
               
                //0 住院号->住院号 1 住院号->留观号 2 留观号->留观号 3 留观号->住院号
                string detailTemp = "";
                switch (tmpType)
                {
                    case 0:
                        detailTemp = "住院号" + currno +  "->住院号" + newno;
                        break;
                    case 1:
                        detailTemp = "住院号" + currno + "->留观号" + newno;
                        break;
                    case 2:
                        detailTemp = "留观号" + currno + "->留观号" + newno;
                        break;
                    case 3:
                        detailTemp = "留观号" + currno + "->住院号" + newno;
                        break;
                }

                if (flag == 3)
                {
                    detailTemp += " (合并)";
                }

                piLog.detail = detailTemp;
                l = AddPatienInfLog(piLog);
                #endregion

                ret = true;
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

        #region 增加资料变动记录
        /// <summary>
        /// 增加资料变动记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        private long AddPatienInfLog(clsPatientInfLog p_objRecord)
        {
            long lngRes = 0;

            //clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngAddNewBed");
            //if (lngRes < 0)
            //{
            //    return -1;
            //}
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;

            if (lngRes < 0)
                return lngRes;
            string strSQL = @"INSERT INTO T_OPR_BIH_PATIENTINF_LOG 
                                        (SEQ_INT, OPERATE_DATE, REGISTERID_CHR, OPERATORID_CHR,
                                         DETAIL_VCHR, DESC_VCHR)
                                 VALUES (SEQ_PATIENTINF_LOG.nextval, sysdate, ?, ?, 
                                         ?, ? )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.registerId;
                objLisAddItemRefArr[1].Value = p_objRecord.operatorId;
                objLisAddItemRefArr[2].Value = p_objRecord.detail;
                objLisAddItemRefArr[3].Value = p_objRecord.desc;

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
    }
}
