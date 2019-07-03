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
    public class clsTmdQCReportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 变动的元素

        #region == Sql语句集合 ==

        private const string m_strInsertSql = @"INSERT INTO T_OPR_LIS_QCREPORT (QCREPORT_SEQ_INT, QCBATCH_SEQ_INT, QCSTATUS_INT,UNMATCHEDRULE_VCHR, REASON_VCHR, PROCESS_VCHR,SUMMARY_VCHR, REPORT_DAT, REPORTOR_ID_CHR, STATUS_INT,MODIFY_DAT) VALUES(?,?,?,?,?,?,?,?,?,?,? )";
        private const string m_strUpdateSql = @"UPDATE T_OPR_LIS_QCREPORT SET  QCBATCH_SEQ_INT=?, QCSTATUS_INT=?,UNMATCHEDRULE_VCHR=?, REASON_VCHR=?, PROCESS_VCHR=?,SUMMARY_VCHR=?, REPORT_DAT=?, REPORTOR_ID_CHR=?, STATUS_INT=?,MODIFY_DAT=? WHERE  QCREPORT_SEQ_INT=? ";
        private const string m_strDeleteSql = @"DELETE T_OPR_LIS_QCREPORT WHERE QCREPORT_SEQ_INT = ?";
        private const string m_strFindSql = @"SELECT * FROM T_OPR_LIS_QCREPORT WHERE QCREPORT_SEQ_INT = ?";
        private const string m_strFindAllSql = @"SELECT * FROM T_OPR_LIS_QCREPORT";
        private const string m_strFindExtSql = @"SELECT t1.*, t2.lastname_vchr AS reportor_name
                                                          FROM t_opr_lis_qcreport t1, t_bse_employee t2
                                                         WHERE t1.reportor_id_chr = t2.empid_chr(+)
                                                           AND t1.status_int = ?
                                                           AND t1.qcbatch_seq_int = ?
                                                           AND t1.report_dat >= ?
                                                           AND t1.report_dat <= ?";
        #endregion

        private const string m_strTableName = "T_OPR_LIS_QCREPORT";
        private const string m_strPrimaryKey = "QCREPORT_SEQ_INT";
        private const string m_strCurrentSvcDetailName = "com.digitalwave.iCare.middletier.LIS.clsTmdQCReportSvc";

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCReportVO p_objQCReport)
        {
            p_objQCReport.m_intSeq = DBAssist.ToInt32(p_dtrSource["QCREPORT_SEQ_INT"]);
            p_objQCReport.m_intQCBatchSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            try
            {
                p_objQCReport.m_enmQCControlStatus = (enmQCControlStatus)DBAssist.ToInt32(p_dtrSource["QCSTATUS_INT"]);
            }
            catch { }
            try
            {
                p_objQCReport.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"].ToString());
            }
            catch { }
            p_objQCReport.m_strUnmatchedRule = p_dtrSource["UNMATCHEDRULE_VCHR"].ToString();
            p_objQCReport.m_strReason = p_dtrSource["REASON_VCHR"].ToString();
            p_objQCReport.m_strProcess = p_dtrSource["PROCESS_VCHR"].ToString();
            p_objQCReport.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString();
            p_objQCReport.m_dtReport = DBAssist.ToDateTime(p_dtrSource["REPORT_DAT"].ToString());
            p_objQCReport.m_strReportorId = p_dtrSource["REPORTOR_ID_CHR"].ToString();
            p_objQCReport.m_dtModify = DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
        }

        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisQCReportVO p_objQCReport, int p_intSeq)
        {
            // QCREPORT_SEQ_INT, QCBATCH_SEQ_INT, QCSTATUS_INT,
            // UNMATCHEDRULE_VCHR, REASON_VCHR, PROCESS_VCHR,
            // SUMMARY_VCHR, REPORT_DAT, REPORTOR_ID_CHR, STATUS_INT,
            // MODIFY_DAT

            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
               p_intSeq,
               p_objQCReport.m_intQCBatchSeq,
               (int)p_objQCReport.m_enmQCControlStatus,
               p_objQCReport.m_strUnmatchedRule,
               p_objQCReport.m_strReason,
               p_objQCReport.m_strProcess,
               p_objQCReport.m_strSummary,
               DBAssist.ToObject(p_objQCReport.m_dtReport),
               p_objQCReport.m_strReportorId,
               (int)p_objQCReport.m_enmStatus,
               p_objQCReport.m_dtModify
                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisQCReportVO p_objQCReport)
        {
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                        (
                           p_objQCReport.m_intQCBatchSeq,
                           (int)p_objQCReport.m_enmQCControlStatus,
                           p_objQCReport.m_strUnmatchedRule,
                           p_objQCReport.m_strReason,
                           p_objQCReport.m_strProcess,
                           p_objQCReport.m_strSummary,
                           DBAssist.ToObject(p_objQCReport.m_dtReport),
                           p_objQCReport.m_strReportorId,
                           (int)p_objQCReport.m_enmStatus,
                           p_objQCReport.m_dtModify,
                           p_objQCReport.m_intSeq
                        );
            return objODPArr;
        }
        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCReportVO p_objQCReport, out int p_intSeq)
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

                p_objQCReport.m_dtModify = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(p_objQCReport, p_intSeq);

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strInsertSql, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objQCReport.m_intSeq = p_intSeq;//给VO赋值ID
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

        [AutoComplete]
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCReportVO QCBatch)
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
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region FIND
        /// <summary>
        /// 查找质控报告
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <param name="p_status"></param>
        /// <param name="p_objQCReportArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int[] p_intQCBatchSeqArr, DateTime p_datBegin, DateTime p_datEnd, enmQCStatus p_status, out clsLisQCReportVO[] p_objQCReportArr)
        {
            long lngRes = 0;
            p_objQCReportArr = null;
            if (p_intQCBatchSeqArr == null || p_intQCBatchSeqArr.Length <= 0)
                return lngRes;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCBatchConcentrationSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            try
            {
                string strSQL = @"select t1.qcreport_seq_int,
       t1.qcbatch_seq_int,
       t1.qcstatus_int,
       t1.unmatchedrule_vchr,
       t1.reason_vchr,
       t1.process_vchr,
       t1.summary_vchr,
       t1.report_dat,
       t1.reportor_id_chr,
       t1.status_int,
       t1.modify_dat,
       t2.lastname_vchr as reportor_name
  from t_opr_lis_qcreport t1, t_bse_employee t2
 where t1.reportor_id_chr = t2.empid_chr(+)
   and t1.status_int = ?
   and t1.report_dat >= ?
   and t1.report_dat <= ?
   and (t1.qcbatch_seq_int = ?";

                ArrayList arParams = new ArrayList();
                if (p_status == enmQCStatus.Delete || p_status == enmQCStatus.Natrural)
                {
                    arParams.Add((int)p_status);
                }
                else
                {
                    strSQL = strSQL.Replace("and t1.status_int = ?", "and 3 = ?");
                    arParams.Add(3);
                }
                arParams.Add(p_datBegin);
                arParams.Add(p_datEnd);
                arParams.AddRange(p_intQCBatchSeqArr);

                for (int index = 1; index < p_intQCBatchSeqArr.Length; index++)
                {
                    strSQL += " or t1.qcreport_seq_int = ?";
                }
                strSQL += ")";

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objODPArr = null;

                objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(arParams.ToArray());
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objQCReportArr = new clsLisQCReportVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objQCReportArr.Length; i++)
                    {
                        p_objQCReportArr[i] = new clsLisQCReportVO();
                        this.ConstructVO(dtbResult.Rows[i], ref p_objQCReportArr[i]);
                        p_objQCReportArr[i].m_strReportorName = dtbResult.Rows[i]["reportor_name"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisQCReportVO p_objQCReport)
        {
            long lngRes = 0;
            p_objQCReport = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCBatchConcentrationSvc", "m_lngFind");
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
                    p_objQCReport = new clsLisQCReportVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objQCReport);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisQCReportVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(m_strFindAllSql, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = ConstructVOArr(dtbResult);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQCBatchSeq,DateTime p_datBegin,DateTime p_datEnd,enmQCStatus p_status, out clsLisQCReportVO[] p_objQCReportArr)
        {
            long lngRes = 0;
            p_objQCReportArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCBatchConcentrationSvc", "m_lngFind");
            if (lngRes <= 0)
                return -1;
            try
            {
                string strSQL = m_strFindExtSql;

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objODPArr = null;

                if (p_status == enmQCStatus.Delete || p_status == enmQCStatus.Natrural)
                {

                    objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                        (int)p_status, p_intQCBatchSeq, p_datBegin, p_datEnd);
                }
                else
                {
                    strSQL = strSQL.Replace("AND t1.status_int = ?", "AND 3 = ?");
                    objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                        3, p_intQCBatchSeq, p_datBegin, p_datEnd);
                }

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objQCReportArr = new clsLisQCReportVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objQCReportArr.Length; i++)
                    {
                        p_objQCReportArr[i] = new clsLisQCReportVO();
                        this.ConstructVO(dtbResult.Rows[i], ref p_objQCReportArr[i]);
                        p_objQCReportArr[i].m_strReportorName = dtbResult.Rows[i]["reportor_name"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }


        private clsLisQCReportVO[] ConstructVOArr(DataTable dtbResult)
        {
            clsLisQCReportVO[] p_objResultArr = new clsLisQCReportVO[dtbResult.Rows.Count];
            for (int i = 0; i < p_objResultArr.Length; i++)
            {
                p_objResultArr[i] = new clsLisQCReportVO();
                ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
            }
            return p_objResultArr;
        }
        #endregion
    }
}