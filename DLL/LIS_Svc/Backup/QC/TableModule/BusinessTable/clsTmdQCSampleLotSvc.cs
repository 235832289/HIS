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
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTmdQCSampleLotSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 变动的元素
        #region Sql语句集合

        private const string m_strInsertSql = @"INSERT INTO T_OPR_LIS_QCSAMPLELOT (QCSMPLOT_SEQ_INT, NAME_VCHR, ASSICODE_VCHR, SOURCE_VCHR,SOURCELOTNO_CHR, VENDOR_CHR, VENDERLOTNO_CHR,PRODUCE_DAT, EXPIRE_DAT, SUMMARY_VCHR, OPERATOR_ID_CHR,MODIFY_DAT, STATUS_INT) (?,?,?,?,?,?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'),to_date(?,'yyyy-mm-dd hh24:mi:ss'),?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'),? )";
        private const string m_strUpdateSql = @"UPDATE T_OPR_LIS_QCSAMPLELOT SET   NAME_VCHR=?, ASSICODE_VCHR=?, SOURCE_VCHR=?,SOURCELOTNO_CHR=?, VENDOR_CHR=?, VENDERLOTNO_CHR=?,PRODUCE_DAT=?, EXPIRE_DAT=to_date(?,'yyyy-mm-dd hh24:mi:ss'), SUMMARY_VCHR=to_date(?,'yyyy-mm-dd hh24:mi:ss'), OPERATOR_ID_CHR=?,MODIFY_DAT=to_date(?,'yyyy-mm-dd hh24:mi:ss'), STATUS_INT=? WHERE  QCSMPLOT_SEQ_INT=? ";
        private const string m_strDeleteSql = @"DELETE T_OPR_LIS_QCSAMPLELOT WHERE QCSMPLOT_SEQ_INT = ?";
        private const string m_strFindSql = @"SELECT * FROM T_OPR_LIS_QCSAMPLELOT WHERE QCSMPLOT_SEQ_INT = ?";
        #endregion

        private const string m_strTableName = "T_OPR_LIS_QCSAMPLELOT";
        private const string m_strPrimaryKey = "QCSMPLOT_SEQ_INT";
        private const string m_strCurrentSvcDetailName = "com.digitalwave.iCare.middletier.LIS.clsTmdQCSampleLotSvc";

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCSamplelotVO p_objQCSamplelot)
        {
            
            //   QCSMPLOT_SEQ_INT, NAME_VCHR, ASSICODE_VCHR, SOURCE_VCHR,
            //   SOURCELOTNO_CHR, VENDOR_CHR, VENDERLOTNO_CHR,
            //   PRODUCE_DAT, EXPIRE_DAT, SUMMARY_VCHR, OPERATOR_ID_CHR,
            //   MODIFY_DAT, STATUS_INT
            p_objQCSamplelot.m_intSeq = DBAssist.ToInt32(p_dtrSource["QCSMPLOT_SEQ_INT"]);
            p_objQCSamplelot.m_strName =p_dtrSource["NAME_VCHR"].ToString();
            p_objQCSamplelot.m_strAssicode = p_dtrSource["ASSICODE_VCHR"].ToString();
            p_objQCSamplelot.m_strSource =  p_dtrSource["SOURCE_VCHR"].ToString();
            p_objQCSamplelot.m_strSourcelotNo = p_dtrSource["SOURCELOTNO_CHR"].ToString();
            p_objQCSamplelot.m_strVendor = p_dtrSource["VENDOR_CHR"].ToString();
            p_objQCSamplelot.m_strVenderlotNo = p_dtrSource["VENDERLOTNO_CHR"].ToString();
            p_objQCSamplelot.m_dtProduce = DBAssist.ToDateTime(p_dtrSource["PRODUCE_DAT"]);
            p_objQCSamplelot.m_dtExpire = DBAssist.ToDateTime(p_dtrSource["EXPIRE_DAT"]);
            p_objQCSamplelot.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString();
            p_objQCSamplelot.m_strOperatorId = p_dtrSource["OPERATOR_ID_CHR"].ToString();
            p_objQCSamplelot.m_dtModify = DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
            try
            {
                p_objQCSamplelot.m_enmStatus =(enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            
            }
            catch { }
          
        }

        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisQCSamplelotVO p_objQCSamplelot, int p_intSeq)
        {
            //   QCSMPLOT_SEQ_INT, NAME_VCHR, ASSICODE_VCHR, SOURCE_VCHR,
            //   SOURCELOTNO_CHR, VENDOR_CHR, VENDERLOTNO_CHR,
            //   PRODUCE_DAT, EXPIRE_DAT, SUMMARY_VCHR, OPERATOR_ID_CHR,
            //   MODIFY_DAT, STATUS_INT

            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
               p_intSeq,
               p_objQCSamplelot.m_strName,
               p_objQCSamplelot.m_strAssicode,
               p_objQCSamplelot.m_strSource,
               p_objQCSamplelot.m_strSourcelotNo,
               p_objQCSamplelot.m_strVendor,
               p_objQCSamplelot.m_strVenderlotNo,
               p_objQCSamplelot.m_dtProduce,
               p_objQCSamplelot.m_dtExpire,
               p_objQCSamplelot.m_strSummary,
               p_objQCSamplelot.m_strOperatorId,
               p_objQCSamplelot.m_dtModify,
               (int)p_objQCSamplelot.m_enmStatus
                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisQCSamplelotVO p_objQCSamplelot)
        {
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                        (
                           p_objQCSamplelot.m_strName,
                           p_objQCSamplelot.m_strAssicode,
                           p_objQCSamplelot.m_strSource,
                           p_objQCSamplelot.m_strSourcelotNo,
                           p_objQCSamplelot.m_strVendor,
                           p_objQCSamplelot.m_strVenderlotNo,
                           p_objQCSamplelot.m_dtProduce,
                           p_objQCSamplelot.m_dtExpire,
                           p_objQCSamplelot.m_strSummary,
                           p_objQCSamplelot.m_strOperatorId,
                           p_objQCSamplelot.m_dtModify,
                           (int)p_objQCSamplelot.m_enmStatus,
                           p_objQCSamplelot.m_intSeq
                        );
            return objODPArr;
        }
        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCSamplelotVO p_objQCSamplelot, out int p_intSeq)
        {
            long lngRes = 0;
            p_intSeq = -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngInsert");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.m_lngGenerateNewID(m_strTableName, m_strPrimaryKey, out p_intSeq);
                if (lngRes <= 0)
                    return -1;
                lngRes = 0;


                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(p_objQCSamplelot, p_intSeq);

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strInsertSql, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objQCSamplelot.m_intSeq = p_intSeq;//给VO赋值ID
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
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCSamplelotVO QCBatch)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngUpdate");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();


            try
            {
                System.Data.IDataParameter[] objODPArr = GetUpdateDataParameterArr(QCBatch);
                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strUpdateSql, ref lngRecEff, objODPArr);
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
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngDelete");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_intSeq);

                long lngRecEff = -1;
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strDeleteSql, ref lngRecEff, objODPArr);
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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisQCSamplelotVO p_objQCSamplelot)
        {
            long lngRes = 0;
            p_objQCSamplelot = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_intSeq);

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strFindSql, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objQCSamplelot = new clsLisQCSamplelotVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objQCSamplelot);
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
}