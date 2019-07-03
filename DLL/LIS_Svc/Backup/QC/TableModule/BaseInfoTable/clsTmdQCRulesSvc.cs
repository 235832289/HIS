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
    [ObjectPooling(Enabled = true)]
    public class clsTmdQCRulesSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
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
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCRuleVO p_objRule, out int p_intSeq)
        {
            long lngRes = 0;
            p_intSeq = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCRulesSvc", "m_lngInsert");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"
                            INSERT INTO T_BSE_LIS_QCRULES      (
        										                    RULE_SEQ_INT,
                                                                    RULE_NAME_VCHR,
                                                                    RULE_ALIAS_VCHR,
                                                                    RULE_DESC_VCHR,
                                                                    RULE_FORMULA_VCHR,
                                                                    RULE_SUMMARY_VCHR,
                                                                    RULE_DEFAULTFLAG_INT,
                                                                    RULE_TYPEFLAG_INT
                                                                )
        							                            VALUES
                                                                ( ?, ? ,? , ?, ?, ?, ?, ?)";

            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.m_lngGenerateNewID("T_BSE_LIS_QCRULES", "RULE_SEQ_INT", out p_intSeq);
                if (lngRes <= 0)
                    return -1;
                lngRes = 0;


                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                    p_intSeq,
                    p_objRule.m_strName,
                    p_objRule.m_strAlias,
                    p_objRule.m_strDesc,
                    p_objRule.m_strFormula,
                    p_objRule.m_strSummary,
                    (int)p_objRule.m_enmDefaultflag,
                    (int)p_objRule.m_enmWarnType
                    );

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objRule.m_intSeq = p_intSeq;//给VO赋值ID
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
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCRuleVO p_objRule)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCRulesSvc", "m_lngInsert");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"UPDATE T_BSE_LIS_QCRULES SET
                                                                RULE_NAME_VCHR=?,
                                                                RULE_ALIAS_VCHR=?,
                                                                RULE_DESC_VCHR=?,
                                                                RULE_FORMULA_VCHR=?,
                                                                RULE_SUMMARY_VCHR=?,
                                                                RULE_DEFAULTFLAG_INT=?,
                                                                RULE_TYPEFLAG_INT=?
                                                        WHERE  RULE_SEQ_INT=?
        							                            ";
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                            p_objRule.m_strName,
                            p_objRule.m_strAlias,
                            p_objRule.m_strDesc,
                            p_objRule.m_strFormula,
                            p_objRule.m_strSummary,
                            (int)p_objRule.m_enmDefaultflag,
                            (int)p_objRule.m_enmWarnType,
                            p_objRule.m_intSeq
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
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCRulesSvc", "m_lngDelete");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"DELETE T_BSE_LIS_QCRULES WHERE RULE_SEQ_INT = ?";
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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisQCRuleVO p_objRule)
        {
            long lngRes = 0;
            p_objRule = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCRulesSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"SELECT * FROM T_BSE_LIS_QCRULES WHERE RULE_SEQ_INT = ?";
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
                    p_objRule = new clsLisQCRuleVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objRule);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisQCRuleVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCRulesSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            string strSQL = @"SELECT * FROM T_BSE_LIS_QCRULES ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisQCRuleVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisQCRuleVO();
                        this.ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }


        #endregion

        #region ConstructVO
        /// <summary>
        /// 从数据库中构造实体
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objRule"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCRuleVO p_objRule)
        {
            p_objRule.m_intSeq = p_dtrSource["RULE_SEQ_INT"]==System.DBNull.Value?0:int.Parse(p_dtrSource["RULE_SEQ_INT"].ToString().Trim());
            p_objRule.m_strName = p_dtrSource["RULE_NAME_VCHR"].ToString().Trim();
            p_objRule.m_strAlias = p_dtrSource["RULE_ALIAS_VCHR"].ToString().Trim();
            p_objRule.m_strDesc = p_dtrSource["RULE_DESC_VCHR"].ToString().Trim();
            p_objRule.m_strFormula = p_dtrSource["RULE_FORMULA_VCHR"].ToString().Trim();
            p_objRule.m_strSummary = p_dtrSource["RULE_SUMMARY_VCHR"].ToString().Trim();
            p_objRule.m_enmDefaultflag =(enmQCRuleDefault)( p_dtrSource["RULE_DEFAULTFLAG_INT"]==DBNull.Value?0:int.Parse(p_dtrSource["RULE_DEFAULTFLAG_INT"].ToString().Trim()));
            p_objRule.m_enmWarnType =(enmQCRuleWarnLevel)(p_dtrSource["RULE_TYPEFLAG_INT"]==DBNull.Value?0:int.Parse(p_dtrSource["RULE_TYPEFLAG_INT"].ToString().Trim()));
           
        }
        #endregion
    }
}