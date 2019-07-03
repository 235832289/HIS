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
    /// 住院号管理
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBeINpatientNOSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        //生成住院号

        #region 普通入院：先判断“历史撤销住院号记录表”表中是否存在住院号，若有，取最小的一个号码，否则，取“全数字段”最大号码+1，生成6位住院号
        /// <summary>
        /// 普通入院生成最大住院号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strHead">头字符</param>
        /// <param name="m_strMaxNo">返回最大值</param>
        /// <param name="m_intSour">返回1,最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBigPatientIDNor(System.Security.Principal.IPrincipal p_objPrincipal,out string m_strHead,out string m_strMaxNo,out int m_intSour)
        {
            m_strHead = "";
            m_strMaxNo="";
            m_intSour = 0;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngGetBigPatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                DataTable dtbResult = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                
                //读取当前 普通住院号头标识
                string strSQL = @" select a.firstflag_vchr from t_opr_bih_inpatientnomax a where a.flag_int=? ";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = 1;
                bool m_blNull =false;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    if (dtbResult.Rows[0]["firstflag_vchr"] == System.DBNull.Value)
                        m_blNull = true;
                }

                //读取当前 “历史撤销住院号记录表” 查 是否有 普通住院号 并取最小一个号码。生成6位住院号
                if (m_blNull)
                {
                    strSQL = @"select a.firstflag_vchr,a.maxinpatientno_vchr maxno from t_opr_bih_inpatientnohis a where a.firstflag_vchr is null order by to_number(a.maxinpatientno_vchr) asc ";
                }
                else
                {
                    strSQL = @"select a.firstflag_vchr,a.maxinpatientno_vchr maxno from t_opr_bih_inpatientnohis a where trim(a.firstflag_vchr)=? order by to_number(a.maxinpatientno_vchr) asc ";
             
                }
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strHead.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    m_strMaxNo = m_strHead.Trim()+dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_intSour = 1;
                    /**********/
                    /***********/
                    return lngRes;
                }
               
                //否则，取“全数字段”最大号码+1，生成6位住院号
               // strSQL = @"select  a.firstflag_vchr,lpad(a.maxinpatientno_vchr+1,length(a.maxinpatientno_vchr),'0') maxno,length(a.maxinpatientno_vchr) maxLen FROM t_opr_bih_inpatientnomax a where a.flag_int=1 ";
                strSQL = @"select  a.firstflag_vchr,
                (case when
                length(to_char(a.maxinpatientno_vchr+1))>length(to_char(a.maxinpatientno_vchr))
                then
                lpad(a.maxinpatientno_vchr+1, length(a.maxinpatientno_vchr)+1,'0')
                else
                lpad(a.maxinpatientno_vchr+1, length(a.maxinpatientno_vchr),'0')
                end) maxno
                FROM t_opr_bih_inpatientnomax a where a.flag_int=1 ";
                
                lngRes = 0;
                dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    string m_strMaxtemp = "";
                    
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    m_strMaxNo = m_strHead + dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_strMaxtemp = dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_intSour = 2;

                  
                    /*对值进行递增操作*/
                    bool m_blHave = false;
                    m_lngCheckInputNoHave(m_strMaxNo, out m_blHave);
                    while (m_blHave)
                    {
                        int m_IntLeng = m_strMaxtemp.Length;
                        m_strMaxtemp =Convert.ToString( int.Parse(m_strMaxtemp) + 1);
                        if (m_strMaxtemp.Length > m_IntLeng)
                        {
                            m_strMaxtemp = m_strMaxtemp.PadLeft(m_strMaxtemp.Length, "0".ToCharArray()[0]);
                        }
                        else
                        {
                            m_strMaxtemp = m_strMaxtemp.PadLeft(m_IntLeng, "0".ToCharArray()[0]);
                        }
                        m_lngCheckInputNoHave(m_strHead+m_strMaxtemp, out m_blHave);
                       // m_strMaxNo = Convert.ToString(int.Parse(dtbResult.Rows[0]["maxno"].ToString().Trim()) + 1);
                        m_strMaxNo =m_strHead+ m_strMaxtemp;
                       // m_lngGetBigPatientIDNor(p_objPrincipal, ref m_strHead, ref m_strMaxNo, out m_intSour);
                    }
                    /*<--------------------*/

                    return lngRes;
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

        #region 非普通入院(留观)：先判断“历史撤销住院号记录表”表中是否存在住院号，若有，取“字母后”最小的一个号码，否则，取“数字段”最大号码+1，生成6位住院号
        /// <summary>
        /// 非普通入院生成最大住院号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strHead">头字母</param>
        /// <param name="m_strMaxNo">返回最大值</param>
        /// <param name="m_intSour">返回1,最大值来源于历史记录，2来源于最大值,0其它</param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBigPatientIDOth(System.Security.Principal.IPrincipal p_objPrincipal,out string m_strHead, out string m_strMaxNo, out int m_intSour)
        {
            
            m_strMaxNo = "";
            m_intSour = 0;
            m_strHead = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngGetBigPatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {


                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                DataTable dtbResult = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                bool m_blNull = false;
                //读取当前 普通住院号头标识
                string strSQL = @" select a.firstflag_vchr from t_opr_bih_inpatientnomax a where a.flag_int=? ";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = 2;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    if (dtbResult.Rows[0]["firstflag_vchr"] == System.DBNull.Value)
                        m_blNull = true;
                }

                //读取当前 “历史撤销住院号记录表” 查 是否有 普通住院号 并取最小一个号码。生成6位住院号
                if (m_blNull)
                {
                   strSQL = @"select a.firstflag_vchr,a.maxinpatientno_vchr maxno from t_opr_bih_inpatientnohis a where  a.firstflag_vchr is null order by to_number(a.maxinpatientno_vchr) asc ";
                }
                else
                {
                    strSQL = @"select a.firstflag_vchr,a.maxinpatientno_vchr maxno from t_opr_bih_inpatientnohis a where trim(a.firstflag_vchr)=?  order by to_number(a.maxinpatientno_vchr) asc ";
                }
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strHead.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    m_strMaxNo = m_strHead.Trim() + dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_intSour = 1;
                    /**********/
                    /***********/
                    return lngRes;
                }

                //否则，取“全数字段”最大号码+1，生成6位住院号
                //strSQL = @" select a.firstflag_vchr,lpad(a.maxinpatientno_vchr+1,length(a.maxinpatientno_vchr),'0')  maxno FROM t_opr_bih_inpatientnomax a where a.flag_int=2 ";
                strSQL = @"select  a.firstflag_vchr,
                (case when
                length(to_char(a.maxinpatientno_vchr+1))>length(to_char(a.maxinpatientno_vchr))
                then
                lpad(a.maxinpatientno_vchr+1, length(a.maxinpatientno_vchr)+1,'0')
                else
                lpad(a.maxinpatientno_vchr+1, length(a.maxinpatientno_vchr),'0')
                end) maxno
                FROM t_opr_bih_inpatientnomax a where a.flag_int=2 ";
              
                lngRes = 0;
                dtbResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    
                    string m_strMaxtemp = "";
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    m_strMaxNo = m_strHead + dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_strMaxtemp = dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_intSour = 2;


                    /*对值进行递增操作*/
                    bool m_blHave = false;
                    m_lngCheckInputNoHave(m_strMaxNo, out m_blHave);
                    while (m_blHave)
                    {
                        int m_IntLeng = m_strMaxtemp.Length;
                        m_strMaxtemp = Convert.ToString(int.Parse(m_strMaxtemp) + 1);
                        //m_strMaxtemp = m_strMaxtemp.PadLeft(m_IntLeng, "0".ToCharArray()[0]);
                        if (m_strMaxtemp.Length > m_IntLeng)
                        {
                            m_strMaxtemp = m_strMaxtemp.PadLeft(m_strMaxtemp.Length, "0".ToCharArray()[0]);
                        }
                        else
                        {
                            m_strMaxtemp = m_strMaxtemp.PadLeft(m_IntLeng, "0".ToCharArray()[0]);
                        }
                        m_lngCheckInputNoHave(m_strHead + m_strMaxtemp, out m_blHave);
                        // m_strMaxNo = Convert.ToString(int.Parse(dtbResult.Rows[0]["maxno"].ToString().Trim()) + 1);
                        m_strMaxNo = m_strHead + m_strMaxtemp;
                        // m_lngGetBigPatientIDNor(p_objPrincipal, ref m_strHead, ref m_strMaxNo, out m_intSour);
                    }
                    /*<--------------------*/

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

        //生成住院号

        #region 如果人工输入的住院号存在于历史表，即取其为住院号
        /// <summary>
        ///如果人工输入的住院号存在于历史表，即取其为住院号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strHead">头字符</param>
        /// <param name="m_strMaxNo">返回最大值</param>
        /// <param name="m_intSour">返回1,最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <param name="inpatientno_vchr">人工输入的住院号</param>
        /// <param name="flag_int">1正常，2留观</param>
        /// <param name="count">标识(0-没有找到,1-历史表中找到记录)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBigPatientIDFree(System.Security.Principal.IPrincipal p_objPrincipal, out string m_strHead, out string m_strMaxNo, out int m_intSour, string inpatientno_vchr,int flag_int,out int count)
        {
            m_strHead = "";
            m_strMaxNo = "";
            m_intSour = 0;
            count = 0;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngGetBigPatientID");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                DataTable dtbResult = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                //读取当前 普通住院号头标识
                string strSQL = @" select a.firstflag_vchr from t_opr_bih_inpatientnomax a where a.flag_int=? ";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = flag_int;
                bool m_blNull = false;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {

                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    if (dtbResult.Rows[0]["firstflag_vchr"] == System.DBNull.Value)
                        m_blNull = true;
                }
                if (inpatientno_vchr.Length > m_strHead.Length)
                {
                    m_strMaxNo = inpatientno_vchr.Substring(m_strHead.Length);
                }
                //读取当前 “历史撤销住院号记录表” 查 是否有 与输入的入院号是否相同。

                strSQL = @"select a.firstflag_vchr,a.maxinpatientno_vchr maxno from t_opr_bih_inpatientnohis a where (trim(a.firstflag_vchr)=? or a.firstflag_vchr is null) and a.maxinpatientno_vchr=? ";

                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strHead.Trim();
                objLisAddItemRefArr[1].Value=m_strMaxNo.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    m_strMaxNo = m_strHead.Trim() + dtbResult.Rows[0]["maxno"].ToString().Trim();
                    m_intSour = 1;
                    count = 1;
                    /**********/
                    /***********/
                    return lngRes;
                }
                else if (lngRes>0&&dtbResult.Rows.Count == 0)
                {
                    m_intSour = 0;
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


        #region 增加/更新住院号到最大值表
        /// <summary>
        /// 增加/更新住院号到最大值表(已作废)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="inpatientnotype_int">1-正常，2-留观</param>
        /// <param name="m_strMain">主体数字</param>
        /// <returns></returns>  
        [AutoComplete]
        public long m_lngAddBigIDTableMax(System.Security.Principal.IPrincipal p_objPrincipal, int inpatientnotype_int, string m_strMain)
        {
        
        long lngRes = 0;


        clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngAddBigIDTableMax");
        if (lngRes < 0)
        {
        return -1;
        }

        try
        {
        clsHRPTableService objHRPSvc = new clsHRPTableService();
        lngRes = 0;
        System.Data.IDataParameter[] objLisAddItemRefArr = null;
        DataTable dtbResult = new DataTable();
        string strSQL = "";

        //更新最大值
        // strSQL = @"insert into  t_opr_bih_inpatientnohis (seqid_int,firstflag_vchr,maxinpatientno_vchr) values(seq_public.nextval,'1','000012') ";
        if (inpatientnotype_int == 1)
        {
        strSQL = @"update  t_opr_bih_inpatientnomax  set  maxinpatientno_vchr=? where flag_int=1 ";
        }
        else if (inpatientnotype_int == 2)
        {
        strSQL = @"update  t_opr_bih_inpatientnomax set  maxinpatientno_vchr=? where flag_int=2 ";
        }
        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
        //objLisAddItemRefArr[0].Value = m_strHead.Trim();
        objLisAddItemRefArr[0].Value = m_strMain.Trim();

        //objLisAddItemRefArr[1].Value = seqid_int;
        dtbResult = new DataTable();
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

        /// <summary>
        /// 增加/更新住院号到最大值表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="inpatientnotype_int">登记类型(1-正常,2-留观)</param>
        /// <param name="m_strHead">住院号头标识</param>
        /// <param name="m_strMain">住院号数字部份</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddBigIDTableMax(System.Security.Principal.IPrincipal p_objPrincipal, int inpatientnotype_int,string m_strHead, string m_strMain)
        {

        long lngRes = 0;

        clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngAddBigIDTableMax");
        if (lngRes < 0)
        {
        return -1;
        }

        try
        {
        clsHRPTableService objHRPSvc = new clsHRPTableService();
        lngRes = 0;
        System.Data.IDataParameter[] objLisAddItemRefArr = null;
        DataTable dtbResult = new DataTable();
        string strSQL = "";

        //更新最大值
        // strSQL = @"insert into  t_opr_bih_inpatientnohis (seqid_int,firstflag_vchr,maxinpatientno_vchr) values(seq_public.nextval,'1','000012') ";
        if (inpatientnotype_int == 1)
        {
        strSQL = @"update  t_opr_bih_inpatientnomax  set  maxinpatientno_vchr=? where flag_int=1 ";
        }
        else if (inpatientnotype_int == 2)
        {
        strSQL = @"update  t_opr_bih_inpatientnomax set  maxinpatientno_vchr=? where flag_int=2 ";
        }
        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
        //objLisAddItemRefArr[0].Value = m_strHead.Trim();
        if (m_strHead.Trim().Equals(""))
        {
        objLisAddItemRefArr[0].Value = m_strMain.Trim();
        }
        else
        {
        objLisAddItemRefArr[0].Value = m_strMain.Trim().Replace(m_strHead.Trim(), "");
        }

        //objLisAddItemRefArr[1].Value = seqid_int;
        dtbResult = new DataTable();
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

        /// <summary>
        /// 增加/更新住院号到最大值表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="inpatientnotype_int">登记类型(1-正常,2-留观)</param>
        /// <param name="m_strHead">住院号头标识</param>
        /// <param name="m_strMain">住院号数字部份</param>
        /// <param name="m_intSour">1,最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddBigIDTableMax(System.Security.Principal.IPrincipal p_objPrincipal, int inpatientnotype_int, string m_strHead, string m_strMain,int m_intSour)
        {

            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngAddBigIDTableMax");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                DataTable dtbResult = new DataTable();
                string strSQL = "";


                if (m_intSour == 2) //更新最大值
                {
                    if (inpatientnotype_int == 1)
                    {
                        strSQL = @"update  t_opr_bih_inpatientnomax  set  maxinpatientno_vchr=? where flag_int=1 ";
                    }
                    else if (inpatientnotype_int == 2)
                    {
                        strSQL = @"update  t_opr_bih_inpatientnomax set  maxinpatientno_vchr=? where flag_int=2 ";
                    }

                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    /*
                    if (m_strHead.Trim().Equals(""))
                    {
                        objLisAddItemRefArr[0].Value = m_strMain.Trim();
                    }
                    else
                    {
                        objLisAddItemRefArr[0].Value = m_strMain.Trim().Replace(m_strHead.Trim(), "");
                    }
                     */
                    objLisAddItemRefArr[0].Value = m_strMain.Trim().Substring(m_strHead.Trim().Length);
                 

                    //objLisAddItemRefArr[1].Value = seqid_int;

                    lngRes=objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                }
                else if (m_intSour == 1)//更新历史表
                {
                    lngRes = m_lngDelInpatientNohis(p_objPrincipal, m_strHead, m_strMain);
                }
                else
                {
                    lngRes = 1;
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

        #region 删除"来源于历史记录"再次重用的住院号
        /// <summary>
        /// 删除"来源于历史记录"再次重用的住院号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strHead">头字母</param>
        /// <param name="m_strMain">主体数字</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelInpatientNohis(System.Security.Principal.IPrincipal p_objPrincipal, string m_strHead, string m_strMain)
        {
            long lngRes = 0;
            //t_opr_bih_inpatientnohis
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngDelInpatientNohis");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                string strSQL = "";
                //当前是否存在当前字母打头的最大住院号，有则进行更新，无则新建
                strSQL = @" delete  FROM t_opr_bih_inpatientnohis a where (a.firstflag_vchr=? or a.firstflag_vchr is null) and  a.maxinpatientno_vchr=? ";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strHead.Trim();
                if (!m_strHead.Trim().Equals(""))
                {
                    objLisAddItemRefArr[1].Value = m_strMain.Replace(m_strHead, "").Trim();
                }
                else
                {
                    objLisAddItemRefArr[1].Value = m_strMain.Trim();
                }

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

        //撤消住院号
        #region 撤销入院：将“住院号”放入“历史撤销住院号记录表”，以便以后复用
        /// <summary>
        /// 撤消住院号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="inpatientnotype_int">1-正常，2-留观</param>
        /// <param name="m_strInpatientid_chr">住院号</param>
        /// <returns></returns>
        public long m_lngAddBigIDTableHis(System.Security.Principal.IPrincipal p_objPrincipal, int inpatientnotype_int,string  m_strInpatientid_chr)
        {
            
            long lngRes = 0;
            
            string m_strHead="";
           
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngAddBigIDTableHis");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                DataTable dtbResult = new DataTable();
                //从最大表中拿最大标志
                string strSQL = @" select a.firstflag_vchr from t_opr_bih_inpatientnomax a where a.flag_int=?";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = inpatientnotype_int;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strHead = dtbResult.Rows[0]["firstflag_vchr"].ToString().Trim();
                    string m_strMain = m_strInpatientid_chr.Trim();
                    if (!m_strHead.Trim().Equals(""))
                    {
                        m_strMain = m_strMain.Replace(m_strHead.Trim(), "");
                    }
                    try
                    {
                        //((char[])m_strMain.ToCharArray()).is
                        int k=int.Parse(m_strMain);
                    }
                    catch
                    {
                        return lngRes;
                    }
                    //更新住院登记表 将住院号加上*
                    //strSQL = @" update t_opr_bih_register a set a.inpatientid_chr='*'||a.inpatientid_chr where a.inpatientid_chr=?  ";
                   // objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    //objLisAddItemRefArr[0].Value = m_strInpatientid_chr.Trim();
                    //lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                    //if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    //{
                        
                        strSQL = @"insert into  t_opr_bih_inpatientnohis  (SEQID_INT,firstflag_vchr,maxinpatientno_vchr) values(seq_public.nextval,?,?)";
                        objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = m_strHead;
                        objLisAddItemRefArr[1].Value = m_strMain;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);

                    

                    //}
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

        #region 留观号转住院号 / 留观号-->转留观号
        /// <summary>
        /// 留观号--〉住院号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRegisterid_chr">原登记流水号</param>
        /// <param name="oldinpatientnotype_int">旧登记类型(1-正常,2-留观)</param>
        /// <param name="newinpatientnotype_int">新登记类型(1-正常,2-留观)</param>
        /// <param name="m_strHead">新住院号头标识</param>
        /// <param name="m_strMain">新住院号数字部份</param>
        /// <param name="m_intSour">1,新最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangePatientIDNor(System.Security.Principal.IPrincipal p_objPrincipal, string m_strRegisterid_chr, string oldInpatientid_chr,int oldinpatientnotype_int, int newinpatientnotype_int, string m_strHead, string m_strMain, int m_intSour)
        {

            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngAddBigIDTableMax");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                DataTable dtbResult = new DataTable();
                //更新当前的留观号变成住院号，并修改INPATIENTNOTYPE_INT标识
                string strSQL = "";
                strSQL = @"update t_opr_bih_register set  inpatientid_chr=?, INPATIENTNOTYPE_INT=? where registerid_chr=? ";
              
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strHead.Trim() + m_strMain.Trim();
                objLisAddItemRefArr[1].Value = newinpatientnotype_int;
                objLisAddItemRefArr[2].Value = m_strRegisterid_chr.Trim();


                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    if (m_intSour == 2) //更新最大值
                    {
                        if (newinpatientnotype_int == 1)
                        {
                            strSQL = @"update  t_opr_bih_inpatientnomax  set  maxinpatientno_vchr=? where flag_int=1 ";
                        }
                        else if (newinpatientnotype_int == 2)
                        {
                            strSQL = @"update  t_opr_bih_inpatientnomax set  maxinpatientno_vchr=? where flag_int=2 ";
                        }

                        objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        //objLisAddItemRefArr[0].Value = m_strHead.Trim();
                        if (m_strHead.Trim().Equals(""))
                        {
                            objLisAddItemRefArr[0].Value = m_strMain.Trim();
                        }
                        else
                        {
                            objLisAddItemRefArr[0].Value = m_strMain.Trim().Replace(m_strHead.Trim(), "");
                        }
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                        
                        //select  a.inpatientid_chr from t_bse_patient a 
                    }
                    else if (m_intSour == 1)//更新历史表
                    {
                        lngRes = m_lngDelInpatientNohis(p_objPrincipal, m_strHead, m_strMain);
                    }
                    else
                    {
                        lngRes = 1;
                    }

                    if (lngRes > 0)
                    {
                        //同步病人基础信息表
                        strSQL = @"update t_bse_patient a set a.inpatientid_chr=? where a.patientid_chr=(select  patientid_chr from  t_opr_bih_register where  registerid_chr=?)  ";
                        objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        if (m_strHead.Trim().Equals(""))
                        {
                            objLisAddItemRefArr[0].Value = m_strMain.Trim();
                            objLisAddItemRefArr[1].Value = m_strRegisterid_chr.Trim();
                        }
                        else
                        {
                            objLisAddItemRefArr[0].Value = m_strMain.Trim().Replace(m_strHead.Trim(), "");
                            objLisAddItemRefArr[1].Value = m_strRegisterid_chr.Trim();
                        }
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                        /*<---------------------------------------------------------------*/

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

        #region 住院号转留观号 / 住院号-->转住院号
        /// <summary>
        /// 住院号-->转留观号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRegisterid_chr">原登记流水号</param>
        /// <param name="oldInpatientid_chr">原住院号</param>
        /// <param name="oldinpatientnotype_int">旧登记类型(1-正常,2-留观)</param>
        /// <param name="newinpatientnotype_int">新登记类型(1-正常,2-留观)</param>
        /// <param name="m_strHead">新住院号头标识</param>
        /// <param name="m_strMain">新住院号数字部份</param>
        /// <param name="m_intSour">1,新最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngChangePatientIDOth(System.Security.Principal.IPrincipal p_objPrincipal, string m_strRegisterid_chr, string oldInpatientid_chr, int oldinpatientnotype_int, int newinpatientnotype_int, string m_strHead, string m_strMain, int m_intSour)
        {

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngAddBigIDTableMax");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                DataTable dtbResult = new DataTable();
                //撤销入院：将“住院号”放入“历史撤销住院号记录表”，以便以后复用
                lngRes = m_lngAddBigIDTableHis(p_objPrincipal, oldinpatientnotype_int, oldInpatientid_chr);
                /*<---------------------------------------------------------------*/
                if (lngRes > 0)
                {
                    //更新当前的住院号变成留观号，并修改INPATIENTNOTYPE_INT标识
                    string strSQL = "";
                    
                    strSQL = @"update t_opr_bih_register set  inpatientid_chr=?, INPATIENTNOTYPE_INT=? where registerid_chr=? ";
                    objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_strHead.Trim() + m_strMain.Trim();
                    objLisAddItemRefArr[1].Value = newinpatientnotype_int;
                    objLisAddItemRefArr[2].Value = m_strRegisterid_chr.Trim();
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        if (m_intSour == 2) //更新最大值
                        {
                            if (newinpatientnotype_int == 1)
                            {
                                strSQL = @"update  t_opr_bih_inpatientnomax  set  maxinpatientno_vchr=? where flag_int=1 ";
                            }
                            else if (newinpatientnotype_int == 2)
                            {
                                strSQL = @"update  t_opr_bih_inpatientnomax set  maxinpatientno_vchr=? where flag_int=2 ";
                            }

                            objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                            //objLisAddItemRefArr[0].Value = m_strHead.Trim();
                            if (m_strHead.Trim().Equals(""))
                            {
                                objLisAddItemRefArr[0].Value = m_strMain.Trim();
                            }
                            else
                            {
                                objLisAddItemRefArr[0].Value = m_strMain.Trim().Replace(m_strHead.Trim(), "");
                            }

                            //objLisAddItemRefArr[1].Value = seqid_int;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                        }
                        else if (m_intSour == 1)//更新历史表
                        {
                            lngRes = m_lngDelInpatientNohis(p_objPrincipal, m_strHead, m_strMain);
                        }
                        else
                        {
                            lngRes = 1;
                        }
                        if (lngRes > 0)
                        {
                            //同步病人基础信息表
                            strSQL = @"update t_bse_patient a set a.inpatientid_chr=? where a.patientid_chr=(select  patientid_chr from  t_opr_bih_register where  registerid_chr=?)  ";
                            objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                            if (m_strHead.Trim().Equals(""))
                            {
                                objLisAddItemRefArr[0].Value = m_strMain.Trim();
                                objLisAddItemRefArr[1].Value = m_strRegisterid_chr.Trim();
                            }
                            else
                            {
                                objLisAddItemRefArr[0].Value = m_strMain.Trim().Replace(m_strHead.Trim(), "");
                                objLisAddItemRefArr[1].Value = m_strRegisterid_chr.Trim();
                            }
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
                            /*<---------------------------------------------------------------*/

                        }
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

        #region 判断开启住院号不判断录入开关
        /// <summary>
        /// 医嘱录入权限费用上限开关,返回0-关，1-开。(已作废)
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckInputNoOpen(out bool m_blnOpen)
        {
            m_blnOpen = false;
            long lngRes = -1;
            string strSQL = "select a.setstatus_int from t_sys_setting a where a.setid_chr='1004'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0 && dtbResult.Rows[0][0] != System.DBNull.Value)
                {
                    m_blnOpen = (Int32.Parse(dtbResult.Rows[0][0].ToString()) == 1) ? true : false;
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

        #region 返回住院正规表达式
       /// <summary>
        /// 返回住院正规表达式   ^[A-Za-z]{1}[0-9]{5}$
       /// </summary>
       /// <param name="m_strRegex"></param>
       /// <returns></returns>
        [AutoComplete]
        public long m_strInputNoRegex(out string m_strRegexNor, out string m_strRegexOth)
        {
           
            long lngRes = -1;
            m_strRegexNor = @"^[A-Z]{1}[0-9]{5}$";
            m_strRegexOth = @"^[0-9]{6}$";
            //string strSQL = "select a.setstatus_int from t_sys_setting a where a.setid_chr='1004'";
            //try
            //{
            //    DataTable dtbResult = new DataTable();
            //    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            //    objHRPSvc.Dispose();
            //    if (lngRes > 0 && dtbResult.Rows.Count > 0 && dtbResult.Rows[0][0] != System.DBNull.Value)
            //    {
            //        m_blnOpen = (Int32.Parse(dtbResult.Rows[0][0].ToString()) == 1) ? true : false;
            //    }
            //}
            //catch (Exception objEx)
            //{
            //    string strTmp = objEx.Message;
            //    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
            //    bool blnRes = objLogger.LogError(objEx);
            //}
            return lngRes;
        }
        #endregion

        #region 判断当前登记表是否已存在相同的住院号
       /// <summary>
        ///  判断当前登记表是否已存在相同的住院号
       /// </summary>
       /// <param name="inpatientid_chr"></param>
       /// <param name="m_blnHave">true-存在，false-不存在</param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckInputNoHave(string inpatientid_chr,out bool m_blnHave)
        {
            m_blnHave =true;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            long lngRes = 0;
            try
            {
               
                
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                DataTable dtbResult = new DataTable();
                string strSQL = @"select  a.inpatientid_chr from t_opr_bih_register a where a.inpatientid_chr=? ";
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = inpatientid_chr.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_blnHave = true;
                }
                else
                {
                    m_blnHave = false;
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

        #region 判断当前是否可以合并当前的两个住院号码
        /// <summary>
        /// 判断当前是否可以合并当前的两个住院号码
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="oldInpatientid_chr">旧住院号</param>
        /// <param name="newInpatientid_chr">新住院号</param>
        /// <param name="m_blnHave">是否可以合并</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckInputNoCombo(System.Security.Principal.IPrincipal p_objPrincipal,string oldInpatientid_chr,string newInpatientid_chr, out bool m_blnHave)
        {
            m_blnHave = false;
            long lngRes = 0;
            string name1 = "", name2 = "", sex1 = "", sex2 = "", modify_dat1 = "", modify_dat2 = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngCheckInputNoCombo");
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
               
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                DataTable dtbResult = new DataTable();
                string strSQL = @"select b.lastname_vchr,
                b.sex_chr,
                (select max(c.MODIFY_DAT)
                from t_opr_bih_transfer c, t_opr_bih_register a
                where c.registerid_chr = a.registerid_chr
                and c.type_int = 6
                and c.registerid_chr=?
                ) MODIFY_DAT
                from t_opr_bih_register a, t_bse_patient b
                where a.patientid_chr = b.patientid_chr
                and a.registerid_chr=? ";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = oldInpatientid_chr.Trim();
                objLisAddItemRefArr[1].Value = oldInpatientid_chr.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    name1 = dtbResult.Rows[0]["lastname_vchr"].ToString().Trim();
                    sex1 = dtbResult.Rows[0]["sex_chr"].ToString().Trim();
                    modify_dat1 = dtbResult.Rows[0]["MODIFY_DAT"].ToString().Trim();
                }

                strSQL = @"select b.lastname_vchr,
                b.sex_chr,
                a.INPATIENT_DAT 
                from t_opr_bih_register a, t_bse_patient b
                where a.patientid_chr = b.patientid_chr
                and a.registerid_chr=? ";
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = newInpatientid_chr.Trim();
                objLisAddItemRefArr[1].Value = newInpatientid_chr.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objLisAddItemRefArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    name2 = dtbResult.Rows[0]["lastname_vchr"].ToString().Trim();
                    sex2 = dtbResult.Rows[0]["sex_chr"].ToString().Trim();
                    modify_dat2 = dtbResult.Rows[0]["INPATIENT_DAT"].ToString().Trim();
                }


                if (sex1.Equals(sex2) && name1.Equals(name2))
                {
                    try
                    {

                        if (Convert.ToDateTime(modify_dat1).CompareTo(Convert.ToDateTime(modify_dat2)) > 0)
                        {

                            m_blnHave = true;
                        }
                    }
                    catch
                    {
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

        #region 
      
        [AutoComplete]
        public long m_lngGetNativeplace(System.Security.Principal.IPrincipal p_objPrincipal, string m_strFindCode, out DataTable m_dtResult)
        {
           
            long lngRes = 0;
            m_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc", "m_lngGetNativeplace");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
              
                //读取当前 普通住院号头标识
                string strSQL = @" 
                SELECT   a.dictname_vchr, a.pycode_chr, a.wbcode_chr
                FROM t_aid_dict a
                WHERE dictid_chr != '0' AND dictkind_chr = '3'
                and (a.dictname_vchr like ? or a.pycode_chr like ? or wbcode_chr like ?)
                ORDER BY TO_NUMBER (dictid_chr)
                ";
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(3, out arrParams);
                arrParams[0].Value = m_strFindCode.Trim()+"%";
                arrParams[1].Value = m_strFindCode.Trim() + "%";
                arrParams[2].Value = m_strFindCode.Trim() + "%";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtResult, arrParams);
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
