using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;//Utility.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTmdWorkGroupSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region INSERT
       
        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal,clsLisWorkGroupVO p_objWorkGroup, out int p_intSeq)
        {
            long lngRes = 0;
            p_intSeq = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdWorkGroupSvc", "m_lngInsert");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"
                            INSERT INTO T_BSE_LIS_WORKGROUP      (
        										                    WORKGROUP_SEQ_INT,
                                                                    WORKGROUP_NAME_VCHR,
                                                                    SUMMARY_VCHR,
                                                                    STATUS_INT
                                                                )
        							                            VALUES
                                                                ( ?, ? ,? , ?)";


            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_LIS_WORKGROUP", "WORKGROUP_SEQ_INT", out p_intSeq);
                if (lngRes <= 0)
                    return -1;
                lngRes = 0;


                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                    p_intSeq,
                    p_objWorkGroup.m_strName,
                    p_objWorkGroup.m_strSummary,
                    (int)p_objWorkGroup.m_enmStatus
                    );

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objWorkGroup.m_intSeq = p_intSeq;//给VO赋值ID
                }
                else
                {
                    p_intSeq = -1;
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

        #region UPDATE
       
        [AutoComplete]
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisWorkGroupVO p_objWorkGroup)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdWorkGroupSvc", "m_lngUpdate");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"UPDATE T_BSE_LIS_WORKGROUP SET
                                                                    WORKGROUP_NAME_VCHR=?,
                                                                    SUMMARY_VCHR=?,
                                                                    STATUS_INT=?
                                                        WHERE  WORKGROUP_SEQ_INT=?
        							                            ";
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                            p_objWorkGroup.m_strName,
                            p_objWorkGroup.m_strSummary,
                            (int)p_objWorkGroup.m_enmStatus,
                            p_objWorkGroup.m_intSeq
                            );
                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
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

        #region DELETE
        [AutoComplete]
        public long m_lngDelete(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdWorkGroupSvc", "m_lngDelete");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"DELETE T_BSE_LIS_WORKGROUP WHERE WORKGROUP_SEQ_INT = ?";
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                    p_intSeq);

                long lngRecEff = -1;
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
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

        #region FIND
     
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisWorkGroupVO p_objWorkGroup)
        {
            long lngRes = 0;
            p_objWorkGroup = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdWorkGroupSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT * FROM T_BSE_LIS_WORKGROUP WHERE WORKGROUP_SEQ_INT = ?";
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                    p_intSeq);

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objWorkGroup = new clsLisWorkGroupVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objWorkGroup);
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
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisWorkGroupVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdWorkGroupSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            string strSQL = @"SELECT * FROM T_BSE_LIS_WORKGROUP ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisWorkGroupVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisWorkGroupVO();
                        this.ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
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

        #region ConstructVO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objWorkGroup"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisWorkGroupVO p_objWorkGroup)
        {
            p_objWorkGroup.m_intSeq = p_dtrSource["WORKGROUP_SEQ_INT"] == System.DBNull.Value ? 0 : int.Parse(p_dtrSource["WORKGROUP_SEQ_INT"].ToString().Trim());
            p_objWorkGroup.m_strName = p_dtrSource["WORKGROUP_NAME_VCHR"].ToString().Trim();
            p_objWorkGroup.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString().Trim();
            try
            {
                p_objWorkGroup.m_enmStatus =(enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch 
            {
               
            }
            
        }
        #endregion
    }
}