using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using System.Text;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 解锁SVC
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsKillLockSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取数据库信息(V$LOCKED_OBJECT)
        /// <summary>
        /// 获取数据库信息(V$LOCKED_OBJECT)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetVLocked_Object(System.Security.Principal.IPrincipal p_objPrincipal, out  DataTable p_outDatatable)
        {
            long lngRes = 0;
            p_outDatatable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsKillLockSVC", "m_lngGetVLocked_Object");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            string strSQL = @"select * from V$LOCKED_OBJECT";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_outDatatable);
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
        #region 获取数据库信息(V$SESSION)
        /// <summary>
        ///  获取数据库信息(V$SESSION)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objArrayList">sid数据</param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetVSessionByCondition(System.Security.Principal.IPrincipal p_objPrincipal, ArrayList m_objArrayList, out  DataTable p_outDatatable)
        {
            long lngRes = 0;
            p_outDatatable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsKillLockSVC", "m_lngGetVSessionByCondition");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            StringBuilder strSQL = new StringBuilder(@"select a.sid,a.serial#,a.audsid from V$SESSION a where a.sid in([condition]) and a.username='ICARE'");
            try
            {
                string m_strTemp = string.Empty;
                for (int i = 0; i < m_objArrayList.Count; i++)
                {
                    m_strTemp += "'" + m_objArrayList[i].ToString() + "'";
                    if (i <= m_objArrayList.Count - 2)
                    {
                        m_strTemp += ",";
                    }
                }
                strSQL = strSQL.Replace("[condition]", m_strTemp);
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
               lngRes= objHRPSvc.lngGetDataTableWithoutParameters(strSQL.ToString(), ref p_outDatatable);
               if (lngRes > 0 && p_outDatatable.Rows.Count > 0)
               {
                   strSQL = new StringBuilder(@"alter system kill session '[compression]'");
                   for (int i = 0; i < p_outDatatable.Rows.Count; i++)
                   {
                       m_strTemp = string.Empty;
                       m_strTemp = p_outDatatable.Rows[i]["sid"].ToString() + "," + p_outDatatable.Rows[i]["SERIAL#"].ToString();
                       strSQL = strSQL.Replace("[compression]", m_strTemp);
                       objHRPSvc.DoExcute(strSQL.ToString());
                       strSQL = new StringBuilder(@"alter system kill session '[compression]'");
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
        #region KILL Session
        /// <summary>
        /// KILL Session
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngKillSessionByID(System.Security.Principal.IPrincipal p_objPrincipal, DataTable p_outDatatable)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsKillLockSVC", "m_lngKillSessionByID");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            StringBuilder strSQL = new StringBuilder(@"alter system kill session '[compression]'");
            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string m_strTemp;
                for (int i = 0; i < p_outDatatable.Rows.Count; i++)
                {
                    m_strTemp = string.Empty;
                    m_strTemp = p_outDatatable.Rows[i]["sid"].ToString() + "," + p_outDatatable.Rows[i]["SERIAL#"].ToString();
                    strSQL = strSQL.Replace("[compression]", m_strTemp);
                    objHRPSvc.DoExcute(strSQL.ToString());
                    strSQL = new StringBuilder(@"alter system kill session '[compression]'");
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
        #region 获取数据库信息(dba_2pc_pending)
        /// <summary>
        /// 获取数据库信息(dba_2pc_pending)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTableDba2pcpending(System.Security.Principal.IPrincipal p_objPrincipal, out  DataTable p_outDatatable)
        {
            long lngRes = 0;
            p_outDatatable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsKillLockSVC", "m_lngGetTableDba2pcpending");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            string strSQL = @"select * from dba_2pc_pending where state not in('forced rollback','forced commit')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_outDatatable);
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
        #region commit force
        /// <summary>
        /// commit force
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_outDatatable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitForce(System.Security.Principal.IPrincipal p_objPrincipal, DataTable p_outDatatable)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsKillLockSVC", "m_lngCommitForce");
            if (lngRes < 0)//权限
            {
                return -1;
            }
            StringBuilder strSQL = new StringBuilder(@"commit force ");
            try
            {
                string m_strTemp = string.Empty;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                for (int i = 0; i < p_outDatatable.Rows.Count; i++)
                {
                    m_strTemp = string.Empty;
                    m_strTemp = "'" + p_outDatatable.Rows[i]["local_tran_id"].ToString() + "'";
                    strSQL.Append(m_strTemp);
                    objHRPSvc.DoExcute(strSQL.ToString());
                    strSQL = new StringBuilder(@"commit force ");
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
    }
}
