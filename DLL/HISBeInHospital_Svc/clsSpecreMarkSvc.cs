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
    /// 特注处理
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsSpecreMarkSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取特别注释的基本字典信息
        /// <summary>
        /// 获取特别注释的基本字典来自“T_BSE_BIH_SPECREMARK”表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSPECREMARKMessage(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_dtResult)
        {

            long lngRes = 0;
            m_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc", "m_lngGetSPECREMARKMessage");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;

              
                string strSQL = @" 
                SELECT   rownum NO,a.* from T_BSE_BIH_SPECREMARK a order by USERCODE_VCHR
                ";
                 lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_dtResult);
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

        #region 得到病人的特处信息
        /// <summary>
        /// 得到病人的特处信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRegisterID">病人登记号</param>
        /// <param name="m_objSpecreMark_VO">特处VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientSPECREMARK(System.Security.Principal.IPrincipal p_objPrincipal, string m_strRegisterID, out clsSpecreMark_VO m_objSpecreMark_VO)
        {

            long lngRes = 0;
            DataTable m_dtResult = new DataTable();
            m_objSpecreMark_VO = new clsSpecreMark_VO();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc", "m_lngGetPatientSPECREMARK");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;

                //读取当前 普通住院号头标识
//                string strSQL = @" 
//                    SELECT a.des_vchr,b.*
//                    FROM 
//                    t_opr_bih_register a,
//                    (select * from t_opr_bih_patspecremark where STATUS_INT=1 and registerid_chr=?) b
//                    where a.registerid_chr=b.registerid_chr(+)
//                    and
//                    a.registerid_chr=?
//                ";

                string strSQL = @" 
                    SELECT a.des_vchr,
                           b.SEQ_INT,
                           b.REGISTERID_CHR,
                           b.REMARKID_CHR,
                           b.REMARKNAME_VCHR,
                           b.START_DAT,
                           b.END_DAT,
                           b.STATUS_INT,
                           b.CHARGECTL_INT,
                           b.CREATORID_CHR,
                           b.CREAT_DAT
                    FROM 
                    t_opr_bih_register a,
                    t_opr_bih_patspecremark b
                    where a.registerid_chr=b.registerid_chr(+) and
                          b.STATUS_INT = 1 and 
                          a.registerid_chr = ? ";
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strRegisterID;
            
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtResult, arrParams);
                if (lngRes > 0 && m_dtResult.Rows.Count > 0)
                {
                    m_objSpecreMark_VO.m_strSEQ_INT = m_dtResult.Rows[0]["SEQ_INT"].ToString().Trim();
                    m_objSpecreMark_VO.m_strREMARKID_CHR = m_dtResult.Rows[0]["REMARKID_CHR"].ToString().Trim();
                    m_objSpecreMark_VO.m_strREMARKNAME_VCHR = m_dtResult.Rows[0]["REMARKNAME_VCHR"].ToString().Trim();
                    m_objSpecreMark_VO.m_strDec_vchr = m_dtResult.Rows[0]["des_vchr"].ToString().Trim();

                    m_objSpecreMark_VO.m_intCHARGECTL_INT = Convert.ToInt16(m_dtResult.Rows[0]["CHARGECTL_INT"].ToString().Trim());
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


        #region 新增一病人特处信息
        /// <summary>
        /// 新增一病人特处信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objSpecreMark_VO">特处VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveNewPatientSPECREMARK(System.Security.Principal.IPrincipal p_objPrincipal,clsSpecreMark_VO m_objSpecreMark_VO)
        {

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc", "m_lngSaveNewPatientSPECREMARK");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                string strSQL = "";
                    //新增记录
                    strSQL = @"insert into T_OPR_BIH_PATSPECREMARK 
                    (SEQ_INT, REGISTERID_CHR, REMARKID_CHR, REMARKNAME_VCHR, 
                     CREATORID_CHR, CREAT_DAT, CHARGECTL_INT)
              values(seq_public.NEXTVAL, ?, ?, ?, 
                     ?, sysdate, ?)";

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(5, out arrParams);
                arrParams[0].Value = m_objSpecreMark_VO.m_strREGISTERID_CHR;
                arrParams[1].Value = m_objSpecreMark_VO.m_strREMARKID_CHR;
                arrParams[2].Value = m_objSpecreMark_VO.m_strREMARKNAME_VCHR;
                arrParams[3].Value = m_objSpecreMark_VO.m_strCREATORID_CHR;
                arrParams[4].Value = m_objSpecreMark_VO.m_intCHARGECTL_INT;
                long lngAff=0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff , arrParams);
                
                strSQL = @"
                    update t_opr_bih_register set des_vchr=?
                    where  registerid_chr =?
                    ";
                System.Data.IDataParameter[] arrParams2 = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams2);
                arrParams2[0].Value = m_objSpecreMark_VO.m_strDec_vchr;
                arrParams2[1].Value = m_objSpecreMark_VO.m_strREGISTERID_CHR;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams2);
               
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

        #region 更改病人的特处信息
        /// <summary>
        /// 更改病人的特处信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objSpecreMark_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveUpdatePatientSPECREMARK(System.Security.Principal.IPrincipal p_objPrincipal, clsSpecreMark_VO m_objSpecreMark_VO)
        {

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc", "m_lngSaveUpdatePatientSPECREMARK");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                string strSQL = "";
               
                strSQL = @"
                    update T_OPR_BIH_PATSPECREMARK set REMARKID_CHR = ?, REMARKNAME_VCHR = ?, CHARGECTL_INT = ?
                    where  SEQ_INT = ?
                    ";

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
             
                arrParams[0].Value = m_objSpecreMark_VO.m_strREMARKID_CHR;
                arrParams[1].Value = m_objSpecreMark_VO.m_strREMARKNAME_VCHR;
                arrParams[2].Value = m_objSpecreMark_VO.m_intCHARGECTL_INT;
                arrParams[3].Value = m_objSpecreMark_VO.m_strSEQ_INT;
                long lngAff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);

                strSQL = @"update t_opr_bih_register set des_vchr = ?
                    where  registerid_chr = ?";
                System.Data.IDataParameter[] arrParams2 = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams2);
                arrParams2[0].Value = m_objSpecreMark_VO.m_strDec_vchr;
                arrParams2[1].Value = m_objSpecreMark_VO.m_strREGISTERID_CHR;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams2);
             

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

        #region 删除当前的特处信息
        /// <summary>
        /// 删除当前的特处信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objSpecreMark_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveDelPatientSPECREMARK(System.Security.Principal.IPrincipal p_objPrincipal, clsSpecreMark_VO m_objSpecreMark_VO)
        {

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc", "m_lngSaveDelPatientSPECREMARK");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                string strSQL = "";
               
                strSQL = @"
                    update T_OPR_BIH_PATSPECREMARK set CANCELERID_CHR = ?, CANCEL_DAT = sysdate, STATUS_INT = 0
                    where  SEQ_INT = ? ";

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);

                arrParams[0].Value = m_objSpecreMark_VO.m_strCANCELERID_CHR;
                arrParams[1].Value = m_objSpecreMark_VO.m_strSEQ_INT;
                long lngAff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAff, arrParams);

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
