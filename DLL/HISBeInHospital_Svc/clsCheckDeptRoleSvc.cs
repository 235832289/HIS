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
    /// clsCheckDeptRoleSvc
    /// 作者： He Guiqiu
    /// 创建时间： 2006-09-22
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsCheckDeptRoleSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 增加
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRoleId"></param>
        /// <param name="p_strApllyType"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long InsertNewRow(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRoleId, string p_strApllyType, string p_strOperatorId, out string p_strSeq)
        {
            long lngRes = 0;

            p_strSeq = GetNextSeq("SEQ_CHECKDEPT_ROLE");

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc", "clsCheckDeptRoleSvc");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"INSERT INTO T_OPR_CHECKDEPT_ROLE
                                        (SEQ_INT, ROLEID_CHR, APPLY_TYPE_INT, LASTOPERATORID_CHR, LASTOPERATE_DAT                                        )
                                 VALUES (?, ?, ?, ?, Sysdate)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = Convert.ToInt32(p_strSeq);
                objLisAddItemRefArr[1].Value = p_strRoleId;
                objLisAddItemRefArr[2].Value = Convert.ToInt16(p_strApllyType);
                objLisAddItemRefArr[3].Value = p_strOperatorId;
               
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

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long DeleteRow(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSeq)
        {
            long lngRes = 0;
            
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc", "DeleteRow");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
           
            string strSQL = @"DELETE FROM T_OPR_CHECKDEPT_ROLE WHERE SEQ_INT = ?";
             
            try              
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = Convert.ToInt16(p_strSeq);
                
                //
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

        #region 取所有角色信息
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllRole(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = @" SELECT ROLEID_CHR,  
                                NAME_VCHR,
                                DESC_VCHR,
                                DEPTID_CHR
                         FROM T_SYS_ROLE ORDER BY ROLEID_CHR    ";
            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

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

        #region 取所有检查类型信息
        /// <summary>
        /// 取所有检查类型信息
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllApplyType(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = @" SELECT TYPEID,  
                                TYPETEXT,
                                DELETED,
                                ORDERSEQ_INT
                         FROM AR_APPLY_TYPELIST ORDER BY ORDERSEQ_INT";
            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

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

        #region 取角色对应的检查单
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long SelectCheckDeptByRoleId(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRoleId, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = @"  SELECT    
                             a.SEQ_INT,   
                             a.ROLEID_CHR,   
                             a.APPLY_TYPE_INT,   
                             a.LASTOPERATORID_CHR,   
                             a.LASTOPERATE_DAT, 
                             b.TYPETEXT 
                         FROM T_OPR_CHECKDEPT_ROLE a,
                              AR_APPLY_TYPELIST b  
                        WHERE ( b.TYPEID = a.APPLY_TYPE_INT ) and a.ROLEID_CHR = ? ";
            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRoleId;

                //
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);
                objHRPSvc.Dispose();

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
    }
}
