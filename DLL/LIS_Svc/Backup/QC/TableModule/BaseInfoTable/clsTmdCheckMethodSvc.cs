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
    public class clsTmdCheckMethodSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region INSERT
        /// <summary>
        /// 增加一条检测方法
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckMethod">检测方法实体</param>
        /// <param name="p_intSeq">检测方法序号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckMethodVO p_objCheckMethod, out int p_intSeq)
        {
            long lngRes = 0;
            p_intSeq = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdCheckMethodSvc", "m_lngInsert");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"INSERT INTO T_BSE_LIS_CHECKMETHOD(
        										                    METHOD_SEQ_INT,
                                                                    CHECKMETHOD_NAME_VCHR,
                                                                    PYCODE_VCHR,
                                                                    WBCODE_VCHR
                                                                )
        							                            VALUES
                                                                ( ?, ? ,? ,?)";
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_LIS_CHECKMETHOD", "METHOD_SEQ_INT", out p_intSeq);
                if (lngRes <= 0)
                    return -1;
                lngRes = 0;


                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                    p_intSeq,
                    p_objCheckMethod.m_strName,
                    p_objCheckMethod.m_strPycode,
                    p_objCheckMethod.m_strWbcode
                    );

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objCheckMethod.m_intSeq = p_intSeq;//给VO赋值ID
                }
                else
                {
                    p_intSeq = -1;
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 增加一条检测方法
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckMethod">检测方法实体</param>
        /// <param name="p_intSeq">检测方法序号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckMethodVO p_objCheckMethod)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdCheckMethodSvc", "m_lngUpdate");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"UPDATE T_BSE_LIS_CHECKMETHOD SET
                                                                CHECKMETHOD_NAME_VCHR=?,
                                                                PYCODE_VCHR=?,
                                                                WBCODE_VCHR=?
                                                            WHERE METHOD_SEQ_INT=?
        							                            ";
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                            p_objCheckMethod.m_strName,
                            p_objCheckMethod.m_strPycode,
                            p_objCheckMethod.m_strWbcode,
                            p_objCheckMethod.m_intSeq
                            );
                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
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
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdCheckMethodSvc", "m_lngDelete");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"DELETE T_BSE_LIS_CHECKMETHOD WHERE METHOD_SEQ_INT = ?";
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
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region FIND
        /// <summary>
        /// 根据检验方法序号查找
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisCheckMethodVO p_objCheckMethod)
        {
            long lngRes = 0;
            p_objCheckMethod = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdCheckMethodSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT * FROM T_BSE_LIS_CHECKMETHOD WHERE METHOD_SEQ_INT = ?";
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
                    p_objCheckMethod = new clsLisCheckMethodVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objCheckMethod);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisCheckMethodVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdCheckMethodSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            string strSQL = @"SELECT * FROM T_BSE_LIS_CHECKMETHOD ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisCheckMethodVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisCheckMethodVO();
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
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisCheckMethodVO p_objCheckMethod)
        {
            p_objCheckMethod.m_intSeq =DBAssist.ToInt32(p_dtrSource["METHOD_SEQ_INT"]);

            p_objCheckMethod.m_strName = p_dtrSource["CHECKMETHOD_NAME_VCHR"].ToString();
            p_objCheckMethod.m_strPycode = p_dtrSource["PYCODE_VCHR"].ToString();
            p_objCheckMethod.m_strWbcode = p_dtrSource["WBCODE_VCHR"].ToString();
        }
        #endregion 
    }
}