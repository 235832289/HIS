using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Security.Principal;
using System.Collections;


namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTmdQCDataSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase 
    {
        #region 变动的元素

        #region == Sql语句集合 ==

        private const string m_strInsertSql = @"INSERT INTO T_OPR_LIS_QCDATA (DATA_SEQ_INT, QCBATCH_SEQ_INT, RESULT_NUM,CONCENTRATION_SEQ_INT,QCDATE_DAT) VALUES(?,?,?,?,?)";
        private const string m_strUpdateSql = @"UPDATE T_OPR_LIS_QCDATA SET  QCBATCH_SEQ_INT=?, RESULT_NUM=?,CONCENTRATION_SEQ_INT=?,QCDATE_DAT=? WHERE  DATA_SEQ_INT=? ";
        private const string m_strDeleteSql = @"DELETE T_OPR_LIS_QCDATA WHERE DATA_SEQ_INT = ?";
        private const string m_strFindSql = @"SELECT * FROM T_OPR_LIS_QCDATA WHERE DATA_SEQ_INT = ?";
        private const string m_strFindAllSql = @"SELECT * FROM T_OPR_LIS_QCDATA";
        #endregion

        private const string m_strTableName = "T_OPR_LIS_QCDATA";
        private const string m_strPrimaryKey = "DATA_SEQ_INT";
        private const string m_strCurrentSvcDetailName = "com.digitalwave.iCare.middletier.LIS.clsTmdQCDataSvc";

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCDataVO p_objQCData)
        {
            //DATA_SEQ_INT, QCBATCH_SEQ_INT, RESULT_NUM,
            //    CONCENTRATION_SEQ_INT, QCDATE_DAT

            p_objQCData.m_intSeq = DBAssist.ToInt32(p_dtrSource["DATA_SEQ_INT"]);
            p_objQCData.m_intQCBatchSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCData.m_dlbResult = DBAssist.ToDouble(p_dtrSource["RESULT_NUM"]);
            p_objQCData.m_intConcentrationSeq = DBAssist.ToInt32(p_dtrSource["CONCENTRATION_SEQ_INT"]);
            p_objQCData.m_datQCDate = DBAssist.ToDateTime(p_dtrSource["QCDATE_DAT"]);
        }

        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisQCDataVO p_objQCData, int p_intSeq)
        {
            //DATA_SEQ_INT, QCBATCH_SEQ_INT, RESULT_NUM,
            //CONCENTRATION_SEQ_INT

            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                p_intSeq, //序号
                p_objQCData.m_intQCBatchSeq,
                p_objQCData.m_dlbResult,
                p_objQCData.m_intConcentrationSeq,
                p_objQCData.m_datQCDate
                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisQCDataVO p_objQCData)
        {
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                        (  
                            p_objQCData.m_intQCBatchSeq,
                            p_objQCData.m_dlbResult,
                            p_objQCData.m_intConcentrationSeq,
                            p_objQCData.m_datQCDate,
                            p_objQCData.m_intSeq
                        );
            return objODPArr;
        }
        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCDataVO p_objQCData, out int p_intSeq)
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


                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(p_objQCData, p_intSeq);

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strInsertSql, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objQCData.m_intSeq = p_intSeq;//给VO赋值ID
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

        /// <summary>
        /// 保存质控样本的结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCDataArr"></param>
        /// <param name="p_intSeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertByArr(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objQCDataArr, out int[] p_intSeqArr)
        {
            long lngRes = 0;
            p_intSeqArr = null;
            if (p_objQCDataArr == null || p_objQCDataArr.Length <= 0)
                return lngRes;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngInsertByArr");
            if (lngRes <= 0)
            {
                return -1;
            }
            clsHRPTableService objHRPServ = null;
            try
            {
                int iCount = p_objQCDataArr.Length;

                lngRes = clsPublicSvc.m_lngGetSequenceArr("seq_lis_qcdata", iCount, out p_intSeqArr);
                if (lngRes <= 0)
                    return lngRes;

                DbType[] m_dbType = new DbType[] { DbType.Int32, DbType.Int32, DbType.Double, DbType.Int32, DbType.DateTime };

                object[][] objValues = new object[m_dbType.Length][];
                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[iCount];
                }
                clsLisQCDataVO objTemp = null;
                for (int iRow = 0; iRow < iCount; iRow++)
                {
                    objTemp = p_objQCDataArr[iRow];

                    objValues[0][iRow] = p_intSeqArr[iRow];
                    objValues[1][iRow] = objTemp.m_intQCBatchSeq;
                    objValues[2][iRow] = objTemp.m_dlbResult;
                    objValues[3][iRow] = objTemp.m_intConcentrationSeq;
                    objValues[4][iRow] = objTemp.m_datQCDate;

                }
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(m_strInsertSql, objValues, m_dbType);
                objHRPServ.Dispose();

                if (lngRes <= 0)
                {
                    p_intSeqArr = null;
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogDetailError(objEx, true);
            }
            finally
            {
                p_objQCDataArr = null;
                objHRPServ = null;
            }
            return lngRes;
        }
        
        #endregion

        #region UPDATE

        [AutoComplete]
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCDataVO QCBatch)
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
        /// <summary>
        /// 更新质控样本的结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCDataArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateByArr(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objQCDataArr)
        {
            long lngRes = 0;
            if (p_objQCDataArr == null || p_objQCDataArr.Length <= 0)
                return lngRes;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngUpdateByArr");
            if (lngRes <= 0)
            {
                return -1;
            }

            try
            {
                int iCount = p_objQCDataArr.Length;

                DbType[] m_dbType = new DbType[] { DbType.Int32, DbType.Double, DbType.Int32, DbType.DateTime, DbType.Int32 };

                object[][] objValues = new object[m_dbType.Length][];
                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[iCount];
                }
                clsLisQCDataVO objTemp = null;
                for (int iRow = 0; iRow < iCount; iRow++)
                {
                    objTemp = p_objQCDataArr[iRow];

                    objValues[0][iRow] = objTemp.m_intQCBatchSeq;
                    objValues[1][iRow] = objTemp.m_dlbResult;
                    objValues[2][iRow] = objTemp.m_intConcentrationSeq;
                    objValues[3][iRow] = objTemp.m_datQCDate;
                    objValues[4][iRow] = objTemp.m_intSeq;

                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(m_strUpdateSql, objValues, m_dbType);

            }
            catch (Exception objEx)
            {
                new clsLogText().LogDetailError(objEx, true);
            }
            finally
            {
                p_objQCDataArr = null;
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
        /// <summary>
        /// 删除质控样本结果数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteByArr(System.Security.Principal.IPrincipal p_objPrincipal, int[] p_intSeqArr)
        {
            long lngRes = 0;
            if (p_intSeqArr == null || p_intSeqArr.Length <= 0)
                return lngRes;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngDeleteByArr");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                string strSQL = m_strDeleteSql;
                for (int index = 1; index < p_intSeqArr.Length; index++)
                {
                    strSQL += " or data_seq_int = ?";
                }
                System.Data.IDataParameter[] objODPArr = null;
                objHRPSvc.CreateDatabaseParameter(p_intSeqArr.Length, out objODPArr);
                for (int index = 0; index < p_intSeqArr.Length; index++)
                {
                    objODPArr[index].Value = p_intSeqArr[index];
                }

                long lngRecEff = -1;
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objODPArr);
                objHRPSvc = null;
                objODPArr = null;
            }
            catch (Exception objEx)
            {
                new clsLogText().LogDetailError(objEx, true);
            }
            finally
            {
                p_intSeqArr = null;
            }
            return lngRes;
        }
        #endregion

        #region FIND
        /// <summary>
        /// 查找质控样本结果数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisQCDataVO[] p_objResultArr, int[] p_intQCBatchSeqArr, DateTime p_datBegin, DateTime p_datEnd)
        {
            long lngRes = 0;
            p_objResultArr = null;

            if (p_intQCBatchSeqArr == null || p_intQCBatchSeqArr.Length <= 0)
                return lngRes;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;

            string strSQL = @"select t1.data_seq_int,
                                       t1.qcbatch_seq_int,
                                       t1.concentration_seq_int,
                                       t1.result_num,
                                       t1.qcdate_dat
                                  from t_opr_lis_qcdata t1
                                 where t1.qcdate_dat >= ?
                                   and t1.qcdate_dat < ? 
                                   and (t1.qcbatch_seq_int = ?";

            ArrayList arParams = new ArrayList();
            arParams.Add(p_datBegin);
            arParams.Add(p_datEnd);
            arParams.AddRange(p_intQCBatchSeqArr);

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                for (int index = 1; index < p_intQCBatchSeqArr.Length; index++)
                {
                    strSQL += " or t1.qcbatch_seq_int = ?";
                }
                strSQL += ")";

                IDataParameter[] objODPArr = null;
                objHRPSvc.CreateDatabaseParameter(arParams.Count, out objODPArr);
                for (int index = 0; index < arParams.Count; index++)
                {
                    objODPArr[index].Value = arParams[index];
                }

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objODPArr);
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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisQCDataVO p_objQCData)
        {
            long lngRes = 0;
            p_objQCData = null;
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
                    p_objQCData = new clsLisQCDataVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objQCData);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisQCDataVO[] p_objResultArr)
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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisQCDataVO[] p_objResultArr,int p_intQCBatchSeq,DateTime p_datBegin,DateTime p_datEnd)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;

            string strSQL = @"select t1.data_seq_int,
       t1.qcbatch_seq_int,
       t1.concentration_seq_int,
       t1.result_num,
       t1.qcdate_dat
  from t_opr_lis_qcdata t1
 where t1.qcdate_dat >= ?
   and t1.qcdate_dat < ?
   and t1.qcbatch_seq_int = ?";

            p_datEnd = p_datEnd.AddDays(1).AddSeconds(-1);
            IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_datBegin, p_datEnd, p_intQCBatchSeq);

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objODPArr);
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

        private clsLisQCDataVO[] ConstructVOArr(DataTable dtbResult)
        {
            clsLisQCDataVO[] p_objResultArr = new clsLisQCDataVO[dtbResult.Rows.Count];
            for (int i = 0; i < p_objResultArr.Length; i++)
            {
                p_objResultArr[i] = new clsLisQCDataVO();
                ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
            }
            return p_objResultArr;
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存数据，将所有保存数据在一个事务完成
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objInsertArr"></param>
        /// <param name="p_objUpdateArr"></param>
        /// <param name="p_intDelArr"></param>
        /// <param name="p_intISeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveAll(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objInsertArr, clsLisQCDataVO[] p_objUpdateArr, int[] p_intDelArr, out int[] p_intISeqArr)
        {
            p_intISeqArr = null;
            long lngRes = 0;

            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngSaveAll");
            objPrivilege = null;
            if (lngRes <= 0)
                return lngRes;

            if (p_objUpdateArr != null && p_objUpdateArr.Length > 0)
            {
                lngRes = m_lngUpdateByArr(p_objPrincipal, p_objUpdateArr);
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                }
            }

            if (p_objInsertArr != null && p_objInsertArr.Length > 0)
            {
                lngRes = m_lngInsertByArr(p_objPrincipal, p_objInsertArr, out p_intISeqArr);
                if (lngRes <= 0)
                {
                    p_intISeqArr = null;
                    ContextUtil.SetAbort();
                }
            }

            if (p_intDelArr != null && p_intDelArr.Length > 0)
            {
                lngRes = m_lngDeleteByArr(p_objPrincipal, p_intDelArr);
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                }
            }

            p_intDelArr = null;
            p_objInsertArr = null;
            p_objUpdateArr = null;

            return lngRes;
        }

        #endregion

        //#region 保存
        ///// <summary>
        ///// 保存数据，将所有保存数据在一个事务完成
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="p_objInsertArr"></param>
        ///// <param name="p_objUpdateArr"></param>
        ///// <param name="p_intDelArr"></param>
        ///// <param name="p_intISeqArr"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngSaveAll(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objInsertArr, clsLisQCDataVO[] p_objUpdateArr, int[] p_intDelArr, out int[] p_intISeqArr)
        //{
        //    p_intISeqArr = null;
        //    long lngRes = 0;

        //    com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngSaveAll");
        //    objPrivilege = null;
        //    if (lngRes <= 0)
        //        return lngRes;

        //    if (p_objUpdateArr != null && p_objUpdateArr.Length > 0)
        //    {
        //        lngRes = m_lngUpdateByArr(p_objPrincipal, p_objUpdateArr);
        //        if (lngRes <= 0)
        //        {
        //            ContextUtil.SetAbort();
        //        }
        //    }

        //    if (p_objInsertArr != null && p_objInsertArr.Length > 0)
        //    {
        //        lngRes = m_lngInsertByArr(p_objPrincipal, p_objInsertArr, out p_intISeqArr);
        //        if (lngRes <= 0)
        //        {
        //            p_intISeqArr = null;
        //            ContextUtil.SetAbort();
        //        }
        //    }

        //    if (p_intDelArr != null && p_intDelArr.Length > 0)
        //    {
        //        lngRes = m_lngDeleteByArr(p_objPrincipal, p_intDelArr);
        //        if (lngRes <= 0)
        //        {
        //            ContextUtil.SetAbort();
        //        }
        //    }

        //    p_intDelArr = null;
        //    p_objInsertArr = null;
        //    p_objUpdateArr = null;

        //    return lngRes;
        //}

        //#endregion

        #region frmQCReport

        #region m_lngInsertQCReport
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCReport"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertQCReport(IPrincipal p_objPrincipal, clsLisQCReportVO p_objQCReport, out int p_intSeq)
        {
            long num = 0L;
            p_intSeq = -1;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngInsertQCReport");
            long result;
            clsHRPTableService svc = new clsHRPTableService();

            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                try
                {
                    num = 0L;
                    num = svc.m_lngGenerateNewID("T_OPR_LIS_QCREPORT", "QCREPORT_SEQ_INT", out p_intSeq);
                    if (num <= 0L)
                    {
                        result = -1L;
                        return result;
                    }
                    num = 0L;

                    p_objQCReport.m_dtModify = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    IDataParameter[] insertDataParameterArr = this.GetInsertDataParameterArr(p_objQCReport, p_intSeq);

                    long num2 = -1L;
                    num = 0L;
                    string Sql = @"insert into t_opr_lis_qcreport
                                                  (qcreport_seq_int,
                                                   qcbatch_seq_int,
                                                   qcstatus_int,
                                                   unmatchedrule_vchr,
                                                   reason_vchr,
                                                   process_vchr,
                                                   summary_vchr,
                                                   report_dat,
                                                   reportor_id_chr,
                                                   status_int,
                                                   modify_dat,
                                                   report_stats_int)
                                                values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";

                    num = svc.lngExecuteParameterSQL(Sql, ref num2, insertDataParameterArr);

                    if (num > 0L)
                    {
                        p_objQCReport.m_intSeq = p_intSeq;
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
                finally
                {
                    svc.Dispose();
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region GetInsertDataParameterArr
        /// <summary>
        /// GetInsertDataParameterArr
        /// </summary>
        /// <param name="p_objQCReport"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        private IDataParameter[] GetInsertDataParameterArr(clsLisQCReportVO p_objQCReport, int p_intSeq)
        {
            return clsPublicSvc.m_objConstructIDataParameterArr(new object[]{
		                                            p_intSeq, p_objQCReport.m_intQCBatchSeq, 
		                                            (int)p_objQCReport.m_enmQCControlStatus, 
                                                    p_objQCReport.m_strUnmatchedRule, 
		                                            p_objQCReport.m_strReason, 
		                                            p_objQCReport.m_strProcess, 
		                                            p_objQCReport.m_strSummary, 
		                                            DBAssist.ToObject(p_objQCReport.m_dtReport), 
		                                            p_objQCReport.m_strReportorId, 
		                                            (int)p_objQCReport.m_enmStatus, 
		                                            p_objQCReport.m_dtModify, 
		                                            p_objQCReport.m_intReportStats
	                                            });
        }
        #endregion GetInsertDataParameterArr

        #region m_lngUpdateQCReport
        /// <summary>
        /// m_lngUpdateQCReport
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="QCBatch"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateQCReport(IPrincipal p_objPrincipal, clsLisQCReportVO QCBatch)
        {
            long num = 0L;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngUpdateQCReport");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                clsHRPTableService svc = new clsHRPTableService();
                try
                {
                    IDataParameter[] updateDataParameterArr = this.GetUpdateDataParameterArr(QCBatch);
                    long num2 = -1L;
                    num = 0L;
                    string Sql = @"update t_opr_lis_qcreport
                                           set qcbatch_seq_int    = ?,
                                               qcstatus_int       = ?,
                                               unmatchedrule_vchr = ?,
                                               reason_vchr        = ?,
                                               process_vchr       = ?,
                                               summary_vchr       = ?,
                                               report_dat         = ?,
                                               reportor_id_chr    = ?,
                                               status_int         = ?,
                                               modify_dat         = ?,
                                               report_stats_int   = ?
                                         where qcreport_seq_int = ? ";

                    num = svc.lngExecuteParameterSQL(Sql, ref num2, updateDataParameterArr);

                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                }
                finally
                {
                    svc.Dispose();
                }
                result = num;
            }
            return result;
        }

        #endregion

        #region GetUpdateDataParameterArr
        /// <summary>
        /// GetUpdateDataParameterArr
        /// </summary>
        /// <param name="p_objQCReport"></param>
        /// <returns></returns>
        private IDataParameter[] GetUpdateDataParameterArr(clsLisQCReportVO p_objQCReport)
        {
            return clsPublicSvc.m_objConstructIDataParameterArr(new object[]{p_objQCReport.m_intQCBatchSeq, 
		                                                            (int)p_objQCReport.m_enmQCControlStatus, 
		                                                            p_objQCReport.m_strUnmatchedRule, 
		                                                            p_objQCReport.m_strReason, 
		                                                            p_objQCReport.m_strProcess, 
		                                                            p_objQCReport.m_strSummary, 
		                                                            DBAssist.ToObject(p_objQCReport.m_dtReport), 
		                                                            p_objQCReport.m_strReportorId, 
		                                                            (int)p_objQCReport.m_enmStatus, 
		                                                            p_objQCReport.m_dtModify, 
		                                                            p_objQCReport.m_intReportStats, 
		                                                            p_objQCReport.m_intSeq
	                                                            });
        }
        #endregion
        #endregion
    }
}