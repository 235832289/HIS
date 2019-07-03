using System;
using System.Data;
using System.Text;
using System.EnterpriseServices;
using System.Collections;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;
using System.Security.Principal;//Utility.dll
using com.digitalwave.iCare.ValueObject;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.middletier.common;

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTmdQCBatchSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase 
    {
        #region 变动的元素
        
        #region Sql语句集合
        private const string m_strInsertSql = @"INSERT INTO T_OPR_LIS_QCBatch (
                                                    QCBATCH_SEQ_INT, WORKGROUP_SEQ_INT, DEVICEID_CHR,
                                                    CHECK_ITEM_ID_CHR, QCSAMPLE_LOTNO_VCHR,
                                                    QCSAMPLE_SOURCE_VCHR, QCSAMPLE_VENDOR_VCHR, REAGENT_VCHR,
                                                    REAGENT_BATCH_VCHR, CHECKMETHOD_NAME_VCHR, WAVELENGTH_NUM,
                                                    QCRULES_VCHR, RESULTUNIT_VCHR,
                                                    BEGIN_DAT, END_DAT, SUMMARY_VCHR, OPERATOR_ID_CHR,
                                                    MODIFY_DAT, STATUS_INT
                                                                               ) 
                                               VALUES( ?, ? ,? , ?,?,?,?,?, ? ,? , ? ,? , ?,?,?, ? ,? , ?,?)";
        private const string m_strUpdateSql = @"UPDATE T_OPR_LIS_QCBatch SET    
                                                    WORKGROUP_SEQ_INT=?, DEVICEID_CHR=?,
                                                    CHECK_ITEM_ID_CHR=?, 
                                                    QCSAMPLE_LOTNO_VCHR=?,QCSAMPLE_SOURCE_VCHR=?, QCSAMPLE_VENDOR_VCHR=?
                                                    , REAGENT_VCHR=?,
                                                    REAGENT_BATCH_VCHR=?, CHECKMETHOD_NAME_VCHR=?, WAVELENGTH_NUM=?,
                                                    QCRULES_VCHR=?, RESULTUNIT_VCHR=?,
                                                    BEGIN_DAT=?, END_DAT=?, SUMMARY_VCHR=?, OPERATOR_ID_CHR=?,
                                                    MODIFY_DAT=?, STATUS_INT=?  WHERE  QCBATCH_SEQ_INT=? ";
        private const string m_strDeleteSql = @"DELETE T_OPR_LIS_QCBatch WHERE QCBATCH_SEQ_INT = ?";
        private const string m_strFindSql = @"SELECT * FROM T_OPR_LIS_QCBatch WHERE QCBATCH_SEQ_INT = ?";
        private const string m_strFindExtSql = @"SELECT t1.*, t2.workgroup_name_vchr, t3.devicename_vchr, t3.device_check_item_name_vchr, 
                                                       t3.device_model_desc_vchr, t4.check_item_name_vchr,t6.lastname_vchr as operator_name
                                                  FROM t_opr_lis_qcbatch t1,
                                                       t_bse_lis_workgroup t2,
                                                       (SELECT distinct t31.deviceid_chr, t31.devicename_vchr, t32.device_model_desc_vchr, t33.device_check_item_name_vchr
                                                          FROM t_bse_lis_device t31, t_bse_lis_device_model t32, t_bse_lis_device_check_item t33
                                                         WHERE t31.device_model_id_chr = t32.device_model_id_chr and t31.device_model_id_chr = t33.device_model_id_chr) t3,
                                                       t_bse_lis_check_item t4,
                                                       t_bse_employee t6
                                                 WHERE t1.workgroup_seq_int = t2.workgroup_seq_int(+)
                                                   AND t1.deviceid_chr = t3.deviceid_chr(+)
                                                   AND t1.check_item_id_chr = t4.check_item_id_chr(+)
                                                   AND t1.operator_id_chr = t6.empid_chr(+)
                                                   AND t1.qcbatch_seq_int = ?"; 
        private const string m_strFindAllSql = @"SELECT * FROM T_OPR_LIS_QCBatch";
        #endregion

        private const string m_strTableName = "T_OPR_LIS_QCBatch";
        private const string m_strPrimaryKey = "QCBATCH_SEQ_INT";
        private const string m_strCurrentSvcDetailName = "com.digitalwave.iCare.middletier.LIS.clsTmdQCBatchSvc";

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCBatchVO p_objQCBatch)
        {
            // QCBATCH_SEQ_INT, WORKGROUP_SEQ_INT, DEVICEID_CHR,
            //CHECK_ITEM_ID_CHR, QCSAMPLE_LOTNO_VCHR,
            //QCSAMPLE_SOURCE_VCHR, QCSAMPLE_VENDOR_VCHR, REAGENT_VCHR,
            //REAGENT_BATCH_VCHR, CHECKMETHOD_NAME_VCHR, WAVELENGTH_NUM,
            //QCRULES_VCHR, RESULTUNIT_VCHR,
            //BEGIN_DAT, END_DAT, SUMMARY_VCHR, OPERATOR_ID_CHR,
            //MODIFY_DAT, STATUS_INT


            p_objQCBatch.m_intSeq =DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCBatch.m_intWorkGroupSeq = DBAssist.ToInt32(p_dtrSource["WORKGROUP_SEQ_INT"]);
            p_objQCBatch.m_strDeviceId = p_dtrSource["DEVICEID_CHR"].ToString();
            p_objQCBatch.m_strCheckItemId =p_dtrSource["CHECK_ITEM_ID_CHR"].ToString();
            p_objQCBatch.m_strSampleLotNo = p_dtrSource["QCSAMPLE_LOTNO_VCHR"].ToString();
            p_objQCBatch.m_strSampleSource = p_dtrSource["QCSAMPLE_SOURCE_VCHR"].ToString();
            p_objQCBatch.m_strSampleVendor = p_dtrSource["QCSAMPLE_VENDOR_VCHR"].ToString();
            p_objQCBatch.m_strReagent = p_dtrSource["REAGENT_VCHR"].ToString();
            p_objQCBatch.m_strReagentBatch = p_dtrSource["REAGENT_BATCH_VCHR"].ToString();
            p_objQCBatch.m_strCheckmethodName = p_dtrSource["CHECKMETHOD_NAME_VCHR"].ToString();
            p_objQCBatch.m_dblWaveLength = DBAssist.ToDouble(p_dtrSource["WAVELENGTH_NUM"]);
            p_objQCBatch.m_strQCRules = p_dtrSource["QCRULES_VCHR"].ToString();
            p_objQCBatch.m_strResultUnit = p_dtrSource["RESULTUNIT_VCHR"].ToString();
            p_objQCBatch.m_dtBegin = DBAssist.ToDateTime(p_dtrSource["BEGIN_DAT"]);
            p_objQCBatch.m_dtEnd =DBAssist.ToDateTime(p_dtrSource["END_DAT"]);
            p_objQCBatch.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString();
            p_objQCBatch.m_strOperatorId = p_dtrSource["OPERATOR_ID_CHR"].ToString();
            p_objQCBatch.m_dtModify =  DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
            try
            {
                p_objQCBatch.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
        }

        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisQCBatchVO p_objQCBatch, int p_intSeq)
        {
            // QCBATCH_SEQ_INT, WORKGROUP_SEQ_INT, DEVICEID_CHR,
            // CHECK_ITEM_ID_CHR, QCSMPLOT_SEQ_INT, REAGENT_VCHR,
            // REAGENT_BATCH_VCHR, CHECKMETHOD_NAME_VCHR, WAVELENGTH_NUM,
            // QCRULES_VCHR, RESULTUNIT_VCHR,
            // BEGIN_DAT, END_DAT, SUMMARY_VCHR, OPERATOR_ID_CHR,
            // MODIFY_DAT, STATUS_INT
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                p_intSeq, //序号
                DBAssist.ToObject(p_objQCBatch.m_intWorkGroupSeq),
                p_objQCBatch.m_strDeviceId,
                p_objQCBatch.m_strCheckItemId,
                p_objQCBatch.m_strSampleLotNo,
                p_objQCBatch.m_strSampleSource,
                p_objQCBatch.m_strSampleVendor,
                p_objQCBatch.m_strReagent,
                p_objQCBatch.m_strReagentBatch,
                p_objQCBatch.m_strCheckmethodName,
                DBAssist.ToObject(p_objQCBatch.m_dblWaveLength),
                p_objQCBatch.m_strQCRules,
                p_objQCBatch.m_strResultUnit,
                DBAssist.ToObject(p_objQCBatch.m_dtBegin),
                DBAssist.ToObject(p_objQCBatch.m_dtEnd),
                p_objQCBatch.m_strSummary,
                p_objQCBatch.m_strOperatorId,
                p_objQCBatch.m_dtModify,
                (int)p_objQCBatch.m_enmStatus
                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisQCBatchVO p_objQCBatch)
        {
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                        (
                                DBAssist.ToObject(p_objQCBatch.m_intWorkGroupSeq),
                                p_objQCBatch.m_strDeviceId,
                                p_objQCBatch.m_strCheckItemId,
                                p_objQCBatch.m_strSampleLotNo,
                                p_objQCBatch.m_strSampleSource,
                                p_objQCBatch.m_strSampleVendor,
                                p_objQCBatch.m_strReagent,
                                p_objQCBatch.m_strReagentBatch,
                                p_objQCBatch.m_strCheckmethodName,
                                DBAssist.ToObject(p_objQCBatch.m_dblWaveLength),
                                p_objQCBatch.m_strQCRules,
                                p_objQCBatch.m_strResultUnit,
                                DBAssist.ToObject(p_objQCBatch.m_dtBegin),
                                DBAssist.ToObject(p_objQCBatch.m_dtEnd),
                                p_objQCBatch.m_strSummary,
                                p_objQCBatch.m_strOperatorId,
                                p_objQCBatch.m_dtModify,
                                (int)p_objQCBatch.m_enmStatus,
                                p_objQCBatch.m_intSeq  //序号
                        );
            return objODPArr;
        } 
        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCBatchVO p_objQCBatch, out int p_intSeq)
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

                p_objQCBatch.m_dtModify = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(p_objQCBatch, p_intSeq);

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strInsertSql, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objQCBatch.m_intSeq = p_intSeq;//给VO赋值ID
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
        /// 保存质控批类
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCBatchArr"></param>
        /// <param name="p_intSeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertByArr(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCBatchVO[] p_objQCBatchArr, out int[] p_intSeqArr)
        {
            p_intSeqArr = null;
            long lngRes = 0;

            if (p_objQCBatchArr == null || p_objQCBatchArr.Length <= 0)
                return lngRes;

            int iSeq = -1;
            int iCount = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngInsertByArr");
            if (lngRes <= 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                lngRes = 0;
                iCount = p_objQCBatchArr.Length;
                lngRes = clsPublicSvc.m_lngGetSequenceArr("seq_lis_qcbatch", iCount, out p_intSeqArr);
                if (lngRes <= 0)
                    return -1;

                DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.String,
                    DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, 
                    DbType.Double, DbType.String, DbType.String, DbType.DateTime, DbType.DateTime, 
                    DbType.String, DbType.String, DbType.DateTime, DbType.Int32 };

                object[][] objValues = new object[19][];

                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[iCount];
                }

                clsLisQCBatchVO objTemp = null;
                DateTime dtTime = DateTime.Now;
                for (int i = 0; i < iCount; i++)
                {
                    int n = 0;
                    objTemp = p_objQCBatchArr[i];

                    objValues[n++][i] = p_intSeqArr[i];
                    objValues[n++][i] = DBAssist.ToObject(objTemp.m_intWorkGroupSeq);
                    objValues[n++][i] = objTemp.m_strDeviceId;
                    objValues[n++][i] = objTemp.m_strCheckItemId;
                    objValues[n++][i] = objTemp.m_strSampleLotNo;

                    objValues[n++][i] = objTemp.m_strSampleSource;
                    objValues[n++][i] = objTemp.m_strSampleVendor;
                    objValues[n++][i] = objTemp.m_strReagent;
                    objValues[n++][i] = objTemp.m_strReagentBatch;
                    objValues[n++][i] = objTemp.m_strCheckmethodName;

                    objValues[n++][i] = DBAssist.ToObject(objTemp.m_dblWaveLength);
                    objValues[n++][i] = objTemp.m_strQCRules;
                    objValues[n++][i] = objTemp.m_strResultUnit;
                    objValues[n++][i] = DBAssist.ToObject(objTemp.m_dtBegin);
                    objValues[n++][i] = DBAssist.ToObject(objTemp.m_dtEnd);

                    objValues[n++][i] = objTemp.m_strSummary;
                    objValues[n++][i] = objTemp.m_strOperatorId;
                    objValues[n++][i] = dtTime;
                    objValues[n++][i] = (int)objTemp.m_enmStatus;
                }

                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(m_strInsertSql, objValues, dbTypes);

                objHRPSvc = null;
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
                p_objQCBatchArr = null;
            }
            return lngRes;
        }

        
        #endregion

        #region UPDATE

        [AutoComplete]
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCBatchVO QCBatch)
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

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq,bool p_blnExtFind, out clsLisQCBatchVO p_objQCBatch)
        {
            long lngRes = 0;
            p_objQCBatch = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_intSeq);

                DataTable dtbResult = null;
                if (p_blnExtFind)
                {
                    lngRes = 0;
                    lngRes = svc.lngGetDataTableWithParameters(m_strFindExtSql, ref dtbResult, objODPArr);
                    if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        p_objQCBatch = new clsLisQCBatchVO();
                        this.ConstructVO(dtbResult.Rows[0], ref p_objQCBatch);
                        //p_objQCBatch.m_strCheckItemName = dtbResult.Rows[0]["check_item_name_vchr"].ToString();
                        p_objQCBatch.m_strCheckItemName = dtbResult.Rows[0]["device_check_item_name_vchr"].ToString();
                        p_objQCBatch.m_strWorkGroupName = dtbResult.Rows[0]["workgroup_name_vchr"].ToString();
                        p_objQCBatch.m_strDeviceName = dtbResult.Rows[0]["devicename_vchr"].ToString();
                        p_objQCBatch.m_strOperatorName = dtbResult.Rows[0]["operator_name"].ToString();
                        p_objQCBatch.m_strDeviceModel = dtbResult.Rows[0]["device_model_desc_vchr"].ToString();
                        //p_objQCBatch.m_strSortNum = dtbResult.Rows[0]["sort_num_int"].ToString();
                    }
                }
                else
                {
                    lngRes = 0;
                    lngRes = svc.lngGetDataTableWithParameters(m_strFindSql, ref dtbResult, objODPArr);
                    if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        p_objQCBatch = new clsLisQCBatchVO();
                        this.ConstructVO(dtbResult.Rows[0], ref p_objQCBatch);
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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisQCBatchVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            clsHRPTableService svc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = svc.lngGetDataTableWithoutParameters(m_strFindAllSql, ref dtbResult);
                
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = ConstructVOArr(dtbResult);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                svc.Dispose();
            }
            return lngRes;
        }
        /// <summary>
        /// 查找定质控批序号的质控设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeqArr"></param>
        /// <param name="p_blnExtFind"></param>
        /// <param name="p_objQCBatchArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int[] p_intSeqArr, bool p_blnExtFind, out clsLisQCBatchVO[] p_objQCBatchArr)
        {
            long lngRes = 0;
            p_objQCBatchArr = null;

            if (p_intSeqArr == null || p_intSeqArr.Length <= 0)
                return -1;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;

            clsHRPTableService svc = new clsHRPTableService();

            try
            {
                DataTable dtbResult = null;

                int iCount = 0;
                clsLisQCBatchVO objTemp = null;
                DataRow drRow = null;
                string strSql = string.Empty;

                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(p_intSeqArr.Length, out parm);
                for (int index = 0; index < p_intSeqArr.Length; index++)
                {
                    parm[index].Value = p_intSeqArr[index];
                }

                if (p_blnExtFind)
                {
                    strSql = @"select t1.qcbatch_seq_int,
                                               t1.workgroup_seq_int,
                                               t1.deviceid_chr,
                                               t1.check_item_id_chr,
                                               t1.qcsample_lotno_vchr,
                                               t1.qcsample_source_vchr,
                                               t1.qcsample_vendor_vchr,
                                               t1.reagent_vchr,
                                               t1.reagent_batch_vchr,
                                               t1.checkmethod_name_vchr,
                                               t1.wavelength_num,
                                               t1.qcrules_vchr,
                                               t1.resultunit_vchr,
                                               t1.begin_dat,
                                               t1.end_dat,
                                               t1.summary_vchr,
                                               t1.operator_id_chr,
                                               t1.modify_dat,
                                               t1.status_int,
                                               t2.workgroup_name_vchr,
                                               t3.devicename_vchr,
                                               t3.device_model_desc_vchr,
                                               t3.device_check_item_name_vchr,
                                               t4.check_item_name_vchr,
                                               t6.lastname_vchr as operator_name
                                          from t_opr_lis_qcbatch t1,
                                               t_bse_lis_workgroup t2,
                                               (select distinct t31.deviceid_chr, t31.devicename_vchr, t32.device_model_desc_vchr, t33.device_check_item_name_vchr 
                                                  from t_bse_lis_device t31, t_bse_lis_device_model t32, t_bse_lis_device_check_item t33
                                                 where t31.device_model_id_chr = t32.device_model_id_chr and t31.device_model_id_chr = t33.device_model_id_chr) t3,
                                               t_bse_lis_check_item t4,
                                               t_bse_employee t6
                                         where t1.workgroup_seq_int = t2.workgroup_seq_int(+)
                                           and t1.deviceid_chr = t3.deviceid_chr(+)
                                           and t1.check_item_id_chr = t4.check_item_id_chr(+)
                                           and t1.operator_id_chr = t6.empid_chr(+)
                                           and (t1.qcbatch_seq_int = ? " ;

                    for (int index = 1; index < p_intSeqArr.Length; index++)
                    {
                        strSql += " or t1.qcbatch_seq_int = ?";
                    }
                    strSql += ")";

                    lngRes = 0;
                    lngRes = svc.lngGetDataTableWithParameters(strSql, ref dtbResult, parm);

                    if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        iCount = dtbResult.Rows.Count;
                        p_objQCBatchArr = new clsLisQCBatchVO[iCount];
                        objTemp = null;
                        drRow = null;

                        for (int iRow = 0; iRow < iCount; iRow++)
                        {
                            objTemp = new clsLisQCBatchVO();
                            drRow = dtbResult.Rows[iRow];
                            this.ConstructVO(drRow, ref objTemp);
                            //objTemp.m_strCheckItemName = drRow["check_item_name_vchr"].ToString();
                            objTemp.m_strCheckItemName = drRow["device_check_item_name_vchr"].ToString();
                            objTemp.m_strWorkGroupName = drRow["workgroup_name_vchr"].ToString();
                            objTemp.m_strDeviceName = drRow["devicename_vchr"].ToString();
                            objTemp.m_strOperatorName = drRow["operator_name"].ToString();
                            objTemp.m_strDeviceModel = drRow["device_model_desc_vchr"].ToString();
                            //objTemp.m_strSortNum = drRow["sort_num_int"].ToString();
                            p_objQCBatchArr[iRow] = objTemp;
                        }
                    }
                }
                else
                {
                    for (int index = 1; index < p_objQCBatchArr.Length; index++)
                    {
                        strSql += " or qcbatch_seq_int = ?";
                    }
                    strSql += ")" ;

                    lngRes = 0;
                    lngRes = svc.lngGetDataTableWithParameters(strSql, ref dtbResult, parm);

                    if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        iCount = dtbResult.Rows.Count;
                        p_objQCBatchArr = new clsLisQCBatchVO[iCount];
                        objTemp = null;
                        drRow = null;

                        for (int iRow = 0; iRow < iCount; iRow++)
                        {
                            objTemp = new clsLisQCBatchVO();
                            drRow = dtbResult.Rows[iRow];
                            this.ConstructVO(drRow, ref objTemp);

                            p_objQCBatchArr[iRow] = objTemp;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogDetailError(objEx, true);
            }
            return lngRes;
        }

        private clsLisQCBatchVO[] ConstructVOArr(DataTable dtbResult)
        {
            clsLisQCBatchVO[] p_objResultArr = new clsLisQCBatchVO[dtbResult.Rows.Count];
            for (int i = 0; i < p_objResultArr.Length; i++)
            {
                p_objResultArr[i] = new clsLisQCBatchVO();
                ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
            }
            return p_objResultArr;
        }
        #endregion

        #region frmQCBatchMangerNew

        #region  m_lngQueryDeviceSampleID
        /// <summary>
        /// m_lngQueryDeviceSampleID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intBatchSeq"></param>
        /// <param name="p_strSampleId"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryDeviceSampleID(IPrincipal p_objPrincipal, int p_intBatchSeq, out string p_strSampleId)
        {
            p_strSampleId = null;
            long num = 0L;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngQueryDeviceSampleID");
            long result;
            if (num < 0L)
            {
                result = num;
            }
            else
            {
                try
                {
                    string strSql = "select t.devicesample_id_vchr  from t_opr_lis_qcbatchconcentration t where t.qcbatch_seq_int = ? ";
                    IDataParameter[] parm = null;
                    clsHRPTableService clsHRPTableService = new clsHRPTableService();
                    clsHRPTableService.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = p_intBatchSeq;
                    DataTable dataTable = null;
                    num = clsHRPTableService.lngGetDataTableWithParameters(strSql, ref dataTable, parm);
                    if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_strSampleId = dataTable.Rows[0]["devicesample_id_vchr"].ToString().Trim();
                    }
                }
                catch (Exception objEx)
                {
                    clsLogText clsLogText = new clsLogText();
                    clsLogText.LogDetailError(objEx, true);
                }
                finally
                {
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngReceiveDeviceQCDataBySampleID
        /// <summary>
        /// m_lngReceiveDeviceQCDataBySampleID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSampleID"></param>
        /// <param name="p_strStartDat"></param>
        /// <param name="p_strEndDat"></param>
        /// <param name="p_intBatchSeqArr"></param>
        /// <param name="p_objQCDataArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReceiveDeviceQCDataBySampleID(IPrincipal p_objPrincipal, string p_strSampleID, string p_strStartDat, string p_strEndDat, int[] p_intBatchSeqArr, out clsLisQCDataVO[] p_objQCDataArr)
        {
            p_objQCDataArr = null;
            long num = 0L;
            long result;
            if (string.IsNullOrEmpty(p_strSampleID) || string.IsNullOrEmpty(p_strStartDat) || string.IsNullOrEmpty(p_strEndDat) || p_intBatchSeqArr == null || p_intBatchSeqArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
                num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngReceiveDeviceQCDataBySampleID");
                if (num <= 0L)
                {
                    result = num;
                }
                else
                {
                    try
                    {
                        string strSql = string.Empty;
                        strSql = @"select t.idx_int,
                                           t.device_check_item_name_vchr,
                                           t.device_sampleid_chr,
                                           t.result_vchr,
                                           t.check_dat,
                                           trunc(t.check_dat) checkdateorder,
                                           d.qcbatch_seq_int
                                      from t_opr_lis_result t
                                     inner join t_bse_lis_device_check_item a
                                        on a.device_check_item_name_vchr = t.device_check_item_name_vchr
                                       and a.is_qc_item_int = 1
                                       and a.has_graph_result_int = 0
                                     inner join t_bse_lis_device c
                                        on c.device_model_id_chr = a.device_model_id_chr
                                     inner join t_opr_lis_qcbatch d
                                        on d.check_item_id_chr = a.device_check_item_id_chr
                                     where t.deviceid_chr = d.deviceid_chr
                                       and c.deviceid_chr = d.deviceid_chr
                                       and t.check_dat between ? and ?
                                       and t.device_sampleid_chr = ? and (d.qcbatch_seq_int = ? ";

                        for (int i = 1; i < p_intBatchSeqArr.Length; i++)
                        {
                            strSql += " or d.qcbatch_seq_int = ?" ;
                        }
                        strSql += ")";
                        strSql += @"order by  checkdateorder,          
                                                d.qcbatch_seq_int,          
                                                t.device_sampleid_chr,          
                                                t.device_check_item_name_vchr,          
                                                t.idx_int desc ";
                        clsHRPTableService svc = new clsHRPTableService();
                        IDataParameter[] parm = null;
                        svc.CreateDatabaseParameter(p_intBatchSeqArr.Length + 3, out parm);
                        parm[0].DbType = DbType.DateTime;
                        parm[0].Value = Convert.ToDateTime(p_strStartDat);
                        parm[1].DbType = DbType.DateTime;
                        parm[1].Value = Convert.ToDateTime(p_strEndDat);
                        parm[2].Value = p_strSampleID;
                        for (int i = 0; i < p_intBatchSeqArr.Length; i++)
                        {
                            parm[3 + i].Value = p_intBatchSeqArr[i];
                        }
                        DataTable dataTable = null;
                        num = svc.lngGetDataTableWithParameters(strSql, ref dataTable, parm);
                        if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                        {
                            int count = dataTable.Rows.Count;
                            List<clsLisQCDataVO> list = new List<clsLisQCDataVO>();
                            double dlbResult = 0.0;
                            string b = "";
                            string b2 = "";
                            string b3 = "";
                            string b4 = "";
                            for (int j = 0; j < count; j++)
                            {
                                DataRow dataRow = dataTable.Rows[j];
                                if (dataRow["qcbatch_seq_int"].ToString().Trim() != b || dataRow["checkdateorder"].ToString().Trim() != b2 || dataRow["device_sampleid_chr"].ToString().Trim() != b3 || dataRow["device_check_item_name_vchr"].ToString().Trim() != b4)
                                {
                                    b = dataRow["qcbatch_seq_int"].ToString().Trim();
                                    b2 = dataRow["checkdateorder"].ToString().Trim();
                                    b3 = dataRow["device_sampleid_chr"].ToString().Trim();
                                    b4 = dataRow["device_check_item_name_vchr"].ToString().Trim();
                                    if (double.TryParse(dataRow["result_vchr"].ToString(), out dlbResult) && dataRow["check_dat"] != DBNull.Value)
                                    {
                                        clsLisQCDataVO clsLisQCDataVO = new clsLisQCDataVO();
                                        clsLisQCDataVO.m_dlbResult = dlbResult;
                                        clsLisQCDataVO.m_datQCDate = Convert.ToDateTime(Convert.ToDateTime(dataRow["check_dat"]).ToString("yyyy-MM-dd"));
                                        clsLisQCDataVO.m_intSeq = -1;
                                        int.TryParse(dataRow["qcbatch_seq_int"].ToString(), out clsLisQCDataVO.m_intQCBatchSeq);
                                        clsLisQCDataVO.m_intConcentrationSeq = -1;
                                        list.Add(clsLisQCDataVO);
                                    }
                                }
                            }
                            if (list.Count > 0)
                            {
                                p_objQCDataArr = list.ToArray();
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        clsLogText clsLogText = new clsLogText();
                        clsLogText.LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_intBatchSeqArr = null;
                        p_strEndDat = null;
                        p_strStartDat = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region  m_lngFindQCBatch
        /// <summary>
        /// m_lngFindQCBatch
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeqArr"></param>
        /// <param name="p_blnExtFind"></param>
        /// <param name="p_objQCBatchArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCBatch(IPrincipal p_objPrincipal, int[] p_intSeqArr, bool p_blnExtFind, out clsLisQCBatchVO[] p_objQCBatchArr)
        {
            long num = 0L;
            p_objQCBatchArr = null;
            long result;
            if (p_intSeqArr == null || p_intSeqArr.Length <= 0)
            {
                result = -1L;
            }
            else
            {
                clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
                num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCBatch");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    clsHRPTableService svc = new clsHRPTableService();
                    try
                    {
                        DataTable dataTable = null;
                        clsLisQCBatchVO clsLisQCBatchVO = null;
                        string strSql = string.Empty;
                        IDataParameter[] parm = null;
                        svc.CreateDatabaseParameter(p_intSeqArr.Length, out parm);
                        for (int i = 0; i < p_intSeqArr.Length; i++)
                        {
                            parm[i].Value = p_intSeqArr[i];
                        }
                        if (p_blnExtFind)
                        {
                            strSql = @"select t1.qcbatch_seq_int,
                                               t1.workgroup_seq_int,
                                               t1.sort_num_int,  
                                               t1.deviceid_chr,
                                               t1.check_item_id_chr,
                                               t1.qcsample_lotno_vchr,
                                               t1.qcsample_source_vchr,
                                               t1.qcsample_vendor_vchr,
                                               t1.reagent_vchr,
                                               t1.reagent_batch_vchr,
                                               t1.checkmethod_name_vchr,
                                               t1.wavelength_num,
                                               t1.qcrules_vchr,
                                               t1.resultunit_vchr,
                                               t1.begin_dat,
                                               t1.end_dat,
                                               t1.summary_vchr,
                                               t1.operator_id_chr,
                                               t1.modify_dat,
                                               t1.status_int,
                                               t1.sort_num_int,
                                               t2.workgroup_name_vchr,
                                               t3.devicename_vchr,
                                               t3.device_model_desc_vchr,
                                               t4.device_check_item_name_vchr,
                                               t6.lastname_vchr as operator_name
                                          from t_opr_lis_qcbatch t1,
                                               t_bse_lis_workgroup t2,
                                               (select t31.deviceid_chr,
                                                       t31.devicename_vchr,
                                                       t32.device_model_desc_vchr,
                                                       t31.device_model_id_chr
                                                  from t_bse_lis_device t31, t_bse_lis_device_model t32
                                                 where t31.device_model_id_chr = t32.device_model_id_chr) t3,
                                               t_bse_lis_device_check_item t4,
                                               t_bse_employee t6
                                         where t1.workgroup_seq_int = t2.workgroup_seq_int(+)
                                           and t1.deviceid_chr = t3.deviceid_chr(+)
                                           and t3.device_model_id_chr = t4.device_model_id_chr
                                           and t1.check_item_id_chr = t4.device_check_item_id_chr(+)
                                           and t1.operator_id_chr = t6.empid_chr(+) and (t1.qcbatch_seq_int = ? ";

                            for (int i = 1; i < p_intSeqArr.Length; i++)
                            {
                                strSql += " or t1.qcbatch_seq_int = ?" ;
                            }
                            strSql += ")";
                            num = 0L;
                            num = svc.lngGetDataTableWithParameters(strSql, ref dataTable, parm);
                            if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                            {
                                int count = dataTable.Rows.Count;
                                p_objQCBatchArr = new clsLisQCBatchVO[count];
                                clsLisQCBatchVO = null;
                                for (int j = 0; j < count; j++)
                                {
                                    clsLisQCBatchVO = new clsLisQCBatchVO();
                                    DataRow dataRow = dataTable.Rows[j];
                                    this.ConstructVO(dataRow, ref clsLisQCBatchVO);
                                    clsLisQCBatchVO.m_strCheckItemName = dataRow["device_check_item_name_vchr"].ToString();
                                    clsLisQCBatchVO.m_strWorkGroupName = dataRow["workgroup_name_vchr"].ToString();
                                    clsLisQCBatchVO.m_strDeviceName = dataRow["devicename_vchr"].ToString();
                                    clsLisQCBatchVO.m_strOperatorName = dataRow["operator_name"].ToString();
                                    clsLisQCBatchVO.m_strDeviceModel = dataRow["device_model_desc_vchr"].ToString();
                                    clsLisQCBatchVO.m_strSortNum = dataRow["sort_num_int"].ToString().Trim();
                                    p_objQCBatchArr[j] = clsLisQCBatchVO;
                                }
                            }
                        }
                        else
                        {
                            strSql = @" select qcbatch_seq_int,
                                                            workgroup_seq_int,
                                                            deviceid_chr,
                                                            check_item_id_chr,
                                                            qcsample_lotno_vchr,
                                                            qcsample_source_vchr,
                                                            qcsample_vendor_vchr,
                                                            reagent_vchr,
                                                            reagent_batch_vchr,
                                                            checkmethod_name_vchr,
                                                            wavelength_num,
                                                            qcrules_vchr,
                                                            resultunit_vchr,
                                                            begin_dat,
                                                            end_dat,
                                                            summary_vchr,
                                                            operator_id_chr,
                                                            modify_dat,
                                                            status_int,
                                                            sort_num_int
                                                            from t_opr_lis_qcbatch
                                                            where qcbatch_seq_int = ? " ;
                            for (int i = 1; i < p_objQCBatchArr.Length; i++)
                            {
                                strSql += " or qcbatch_seq_int = ?";
                            }
                            strSql += ")" ;
                            num = 0L;
                            num = svc.lngGetDataTableWithParameters(strSql, ref dataTable, parm);
                            if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                            {
                                int count = dataTable.Rows.Count;
                                p_objQCBatchArr = new clsLisQCBatchVO[count];
                                clsLisQCBatchVO = null;
                                for (int j = 0; j < count; j++)
                                {
                                    clsLisQCBatchVO = new clsLisQCBatchVO();
                                    DataRow dataRow = dataTable.Rows[j];
                                    this.ConstructVO(dataRow, ref clsLisQCBatchVO);
                                    clsLisQCBatchVO.m_strSortNum = dataRow["sort_num_int"].ToString().Trim();
                                    p_objQCBatchArr[j] = clsLisQCBatchVO;
                                }
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        new clsLogText().LogDetailError(objEx, true);
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngFindQCConcentration
        /// <summary>
        /// m_lngFindQCConcentration
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCConcentration(IPrincipal p_objPrincipal, int[] p_intQCBatchSeqArr, out clsLisQCConcentrationVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCConcentration");
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
                    string text = @"select t1.*, t2.concentration_vchr
                                            from t_opr_lis_qcbatchconcentration t1, t_bse_lis_concentration t2
                                            where t1.concentration_seq_int = t2.concentration_seq_int
                                            and t1.status_int = 1
                                            and (t1.qcbatch_seq_int = ? ";
                    for (int i = 1; i < p_intQCBatchSeqArr.Length; i++)
                    {
                        text += "    or t1.qcbatch_seq_int = ?";
                    }
                    text += ")";
                    IDataParameter[] parm = null;
                    svc.CreateDatabaseParameter(p_intQCBatchSeqArr.Length, out parm);
                    for (int i = 0; i < p_intQCBatchSeqArr.Length; i++)
                    {
                        parm[i].Value = p_intQCBatchSeqArr[i];
                    }
                    DataTable dataTable = null;
                    num = 0L;
                    num = svc.lngGetDataTableWithParameters(text, ref dataTable, parm);
                    
                    if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisQCConcentrationVO[dataTable.Rows.Count];
                        for (int j = 0; j < p_objResultArr.Length; j++)
                        {
                            p_objResultArr[j] = new clsLisQCConcentrationVO();
                            this.ConstructVO(dataTable.Rows[j], ref p_objResultArr[j]);
                            p_objResultArr[j].m_strConcentration = dataTable.Rows[j]["concentration_vchr"].ToString();
                        }
                    }
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                    svc.Dispose();
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindQCData
        /// <summary>
        /// m_lngFindQCData
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCData(IPrincipal p_objPrincipal, out clsLisQCDataVO[] p_objResultArr, int[] p_intQCBatchSeqArr, DateTime p_datBegin, DateTime p_datEnd)
        {
            long num = 0L;
            p_objResultArr = null;
            long result;
            if (p_intQCBatchSeqArr == null || p_intQCBatchSeqArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService svc = new clsPrivilegeHandleService();
                num = svc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCData");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    string strSql = @"select t1.data_seq_int,
                                           t1.qcbatch_seq_int,
                                           t1.concentration_seq_int,
                                           t1.result_num,
                                           t1.qcdate_dat
                                      from t_opr_lis_qcdata t1
                                     where t1.qcdate_dat >= ?
                                       and t1.qcdate_dat < ? and (t1.qcbatch_seq_int = ? ";

                    ArrayList arrayList = new ArrayList();
                    arrayList.Add(p_datBegin);
                    arrayList.Add(p_datEnd);
                    arrayList.AddRange(p_intQCBatchSeqArr);
                    clsHRPTableService svc2 = new clsHRPTableService();
                    try
                    {
                        for (int i = 1; i < p_intQCBatchSeqArr.Length; i++)
                        {
                            strSql += " or t1.qcbatch_seq_int = ?";
                        }
                        strSql += ")";
                        IDataParameter[] parm = null;
                        svc2.CreateDatabaseParameter(arrayList.Count, out parm);
                        for (int i = 0; i < arrayList.Count; i++)
                        {
                            parm[i].Value = arrayList[i];
                        }
                        DataTable dataTable = null;
                        num = 0L;
                        num = svc2.lngGetDataTableWithParameters(strSql, ref dataTable, parm);
                        
                        if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                        {
                            p_objResultArr = this.ConstructQCDataVOArr(dataTable);
                        }
                    }
                    catch (Exception objEx)
                    {
                        new clsLogText().LogError(objEx);
                        svc2.Dispose();
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region ConstructQCDataVOArr
        /// <summary>
        /// ConstructQCDataVOArr
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        private clsLisQCDataVO[] ConstructQCDataVOArr(DataTable dtbResult)
        {
            clsLisQCDataVO[] vo = new clsLisQCDataVO[dtbResult.Rows.Count];
            for (int i = 0; i < vo.Length; i++)
            {
                vo[i] = new clsLisQCDataVO();
                this.ConstructVO(dtbResult.Rows[i], ref vo[i]);
            }
            return vo;
        }
        #endregion

        #region ConstructVO 
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objQCData"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCDataVO p_objQCData)
        {
            p_objQCData.m_intSeq = DBAssist.ToInt32(p_dtrSource["DATA_SEQ_INT"]);
            p_objQCData.m_intQCBatchSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCData.m_dlbResult = DBAssist.ToDouble(p_dtrSource["RESULT_NUM"]);
            p_objQCData.m_intConcentrationSeq = DBAssist.ToInt32(p_dtrSource["CONCENTRATION_SEQ_INT"]);
            p_objQCData.m_datQCDate = DBAssist.ToDateTime(p_dtrSource["QCDATE_DAT"]);
        }
        #endregion

        #region m_lngFindQCReport
        /// <summary>
        /// m_lngFindQCReport
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <param name="p_status"></param>
        /// <param name="p_objQCReportArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCReport(IPrincipal p_objPrincipal, int[] p_intQCBatchSeqArr, DateTime p_datBegin, DateTime p_datEnd, enmQCStatus p_status, out clsLisQCReportVO[] p_objQCReportArr)
        {
            long num = 0L;
            p_objQCReportArr = null;
            long result;
            if (p_intQCBatchSeqArr == null || p_intQCBatchSeqArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
                num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCReport");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    try
                    {
                        string strSql = @"select t1.qcreport_seq_int,
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
                                               t1.report_stats_int,
                                               t2.lastname_vchr as reportor_name
                                          from t_opr_lis_qcreport t1, t_bse_employee t2
                                         where t1.reportor_id_chr = t2.empid_chr(+)
                                           and t1.status_int = ?
                                           and t1.report_dat >= ?
                                           and t1.report_dat <= ? and (t1.qcbatch_seq_int = ? ";
                        ArrayList arrayList = new ArrayList();
                        if (p_status == enmQCStatus.Delete || p_status == enmQCStatus.Natrural)
                        {
                            arrayList.Add((int)p_status);
                        }
                        else
                        {
                            strSql = strSql.Replace("and t1.status_int = ?", "and 3 = ?");
                            arrayList.Add(3);
                        }
                        arrayList.Add(p_datBegin);
                        arrayList.Add(p_datEnd);
                        arrayList.AddRange(p_intQCBatchSeqArr);
                        for (int i = 1; i < p_intQCBatchSeqArr.Length; i++)
                        {
                            strSql += " or t1.qcreport_seq_int = ?";
                        }
                        strSql += ")";
                        clsHRPTableService clsHRPTableService = new clsHRPTableService();
                        IDataParameter[] @params = clsPublicSvc.m_objConstructIDataParameterArr(arrayList.ToArray());
                        DataTable dataTable = null;
                        num = 0L;
                        num = clsHRPTableService.lngGetDataTableWithParameters(strSql, ref dataTable, @params);
                        clsHRPTableService.Dispose();
                        if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                        {
                            p_objQCReportArr = new clsLisQCReportVO[dataTable.Rows.Count];
                            for (int j = 0; j < p_objQCReportArr.Length; j++)
                            {
                                p_objQCReportArr[j] = new clsLisQCReportVO();
                                this.ConstructVO(dataTable.Rows[j], ref p_objQCReportArr[j]);
                                p_objQCReportArr[j].m_strReportorName = dataTable.Rows[j]["reportor_name"].ToString().Trim();
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        new clsLogText().LogError(objEx);
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region ConstructVO
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objQCConcentration"></param>
        internal void ConstructVO(DataRow p_dtrSource, ref clsLisQCConcentrationVO p_objQCConcentration)
        {
            p_objQCConcentration.m_intConcentrationSeq = DBAssist.ToInt32(p_dtrSource["CONCENTRATION_SEQ_INT"]);
            p_objQCConcentration.m_intQCBatchSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCConcentration.m_strDeviceSampleId = p_dtrSource["DEVICESAMPLE_ID_VCHR"].ToString();
            try
            {
                p_objQCConcentration.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
            p_objQCConcentration.m_dblAVG = DBAssist.ToDouble(p_dtrSource["AVG_NUM"]);
            p_objQCConcentration.m_dblSD = DBAssist.ToDouble(p_dtrSource["SD_NUM"]);
            p_objQCConcentration.m_dblCV = DBAssist.ToDouble(p_dtrSource["CV_NUM"]);
        }
        #endregion

        #region ConstructVO
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objQCReport"></param>
        private void ConstructVO(DataRow p_dtrSource, ref clsLisQCReportVO p_objQCReport)
        {
            p_objQCReport.m_intSeq = DBAssist.ToInt32(p_dtrSource["QCREPORT_SEQ_INT"]);
            p_objQCReport.m_intQCBatchSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            try
            {
                p_objQCReport.m_enmQCControlStatus = (enmQCControlStatus)DBAssist.ToInt32(p_dtrSource["QCSTATUS_INT"]);
            }
            catch
            {
            }
            try
            {
                p_objQCReport.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"].ToString());
            }
            catch
            {
            }
            p_objQCReport.m_strUnmatchedRule = p_dtrSource["UNMATCHEDRULE_VCHR"].ToString();
            p_objQCReport.m_strReason = p_dtrSource["REASON_VCHR"].ToString();
            p_objQCReport.m_strProcess = p_dtrSource["PROCESS_VCHR"].ToString();
            p_objQCReport.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString();
            p_objQCReport.m_dtReport = DBAssist.ToDateTime(p_dtrSource["REPORT_DAT"].ToString());
            p_objQCReport.m_strReportorId = p_dtrSource["REPORTOR_ID_CHR"].ToString();
            p_objQCReport.m_dtModify = DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
            p_objQCReport.m_intReportStats = int.Parse(p_dtrSource["report_stats_int"].ToString());
        }
        #endregion

        #region m_lngFindQCBatch
        /// <summary>
        /// m_lngFindQCBatch
        /// </summary>
        /// <param name="Principal"></param>
        /// <param name="intSeq"></param>
        /// <param name="blnExtFind"></param>
        /// <param name="qcBatchVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCBatch(IPrincipal Principal, int intSeq, bool blnExtFind, out clsLisQCBatchVO qcBatchVo)
        {
            long num = 0L;
            qcBatchVo = null;
            string strSql = string.Empty;
            IDataParameter[] parm = null;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(Principal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "QCBatch");

            long result;
            if (num <= 0L)
                result = -1L;
            else
            {
                clsHRPTableService svc = new clsHRPTableService();
                try
                {
                    DataTable dtResult = null;
                    if (blnExtFind)
                    {
                        strSql = @"select t1.qcbatch_seq_int,
                                           t1.sort_num_int,   --
                                           t1.workgroup_seq_int,
                                           t1.deviceid_chr,
                                           t1.check_item_id_chr,
                                           t1.qcsample_lotno_vchr,
                                           t1.qcsample_source_vchr,
                                           t1.qcsample_vendor_vchr,
                                           t1.reagent_vchr,
                                           t1.reagent_batch_vchr,
                                           t1.checkmethod_name_vchr,
                                           t1.wavelength_num,
                                           t1.qcrules_vchr,
                                           t1.resultunit_vchr,
                                           t1.begin_dat,
                                           t1.end_dat,
                                           t1.summary_vchr,
                                           t1.operator_id_chr,
                                           t1.modify_dat,
                                           t1.status_int,
                                           t2.workgroup_name_vchr,
                                           t3.devicename_vchr,
                                           t3.device_model_desc_vchr,
                                           t4.device_check_item_name_vchr,
                                           t6.lastname_vchr as operator_name
                                      from t_opr_lis_qcbatch t1,
                                           t_bse_lis_workgroup t2,
                                           (select t31.deviceid_chr,
                                                   t31.devicename_vchr,
                                                   t32.device_model_desc_vchr,
                                                   t31.device_model_id_chr
                                              from t_bse_lis_device t31, t_bse_lis_device_model t32
                                             where t31.device_model_id_chr = t32.device_model_id_chr) t3,
                                           t_bse_lis_device_check_item t4,
                                           t_bse_employee t6
                                     where t1.workgroup_seq_int = t2.workgroup_seq_int(+)
                                       and t1.deviceid_chr = t3.deviceid_chr(+)
                                       and t4.device_model_id_chr = t3.device_model_id_chr
                                       and t1.check_item_id_chr = t4.device_check_item_id_chr(+)
                                       and t1.operator_id_chr = t6.empid_chr(+)
                                       and t1.qcbatch_seq_int = ? ";

                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = intSeq;
                        num = svc.lngGetDataTableWithParameters(strSql, ref dtResult, parm);
                        
                        if (num == 1L && dtResult != null && dtResult.Rows.Count > 0)
                        {
                            qcBatchVo = new clsLisQCBatchVO();
                            this.ConstructVO(dtResult.Rows[0], ref qcBatchVo);
                            qcBatchVo.m_strCheckItemName = dtResult.Rows[0]["device_check_item_name_vchr"].ToString();
                            qcBatchVo.m_strWorkGroupName = dtResult.Rows[0]["workgroup_name_vchr"].ToString();
                            qcBatchVo.m_strDeviceName = dtResult.Rows[0]["devicename_vchr"].ToString();
                            qcBatchVo.m_strOperatorName = dtResult.Rows[0]["operator_name"].ToString();
                            qcBatchVo.m_strDeviceModel = dtResult.Rows[0]["device_model_desc_vchr"].ToString();
                            qcBatchVo.m_strSortNum = dtResult.Rows[0]["sort_num_int"].ToString();
                        }
                    }
                    else
                    {
                        strSql = @" select qcbatch_seq_int,
                                            workgroup_seq_int,
                                            deviceid_chr,
                                            check_item_id_chr,
                                            qcsample_lotno_vchr,
                                            qcsample_source_vchr,
                                            qcsample_vendor_vchr,
                                            reagent_vchr,
                                            reagent_batch_vchr,
                                            checkmethod_name_vchr,
                                            wavelength_num,
                                            qcrules_vchr,
                                            resultunit_vchr,
                                            begin_dat,
                                            end_dat,
                                            summary_vchr,
                                            operator_id_chr,
                                            modify_dat,
                                            status_int,
                                            sort_num_int
                                       from t_opr_lis_qcbatch
                                      where qcbatch_seq_int = ? ";

                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = intSeq;
                        num = svc.lngGetDataTableWithParameters(strSql, ref dtResult, parm);

                        if (num == 1L && dtResult != null && dtResult.Rows.Count > 0)
                        {
                            qcBatchVo = new clsLisQCBatchVO();
                            this.ConstructVO(dtResult.Rows[0], ref qcBatchVo);
                            qcBatchVo.m_strSortNum = dtResult.Rows[0]["sort_num_int"].ToString().Trim();
                        }
                    }
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindQCConcentration
        /// <summary>
        /// m_lngFindQCConcentration
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQCBatchSeq"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCConcentration(IPrincipal p_objPrincipal, int p_intQCBatchSeq, out clsLisQCConcentrationVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            string strSql = string.Empty;
            IDataParameter[] parm = null;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCConcentration");
            long result;
            if (num <= 0L)
                result = -1L;
            else
            {
                clsHRPTableService svc = new clsHRPTableService();
                try
                {
                    DataTable dtResult = null;
                    strSql = @"select t1.*, t2.concentration_vchr
                                      from t_opr_lis_qcbatchconcentration t1, t_bse_lis_concentration t2
                                     where t1.concentration_seq_int = t2.concentration_seq_int
                                       and t1.status_int = 1
                                       and t1.qcbatch_seq_int = ? ";

                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = p_intQCBatchSeq;

                    num = svc.lngGetDataTableWithParameters(strSql, ref dtResult, parm);

                    if (num == 1L && dtResult != null && dtResult.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisQCConcentrationVO[dtResult.Rows.Count];
                        for (int i = 0; i < p_objResultArr.Length; i++)
                        {
                            p_objResultArr[i] = new clsLisQCConcentrationVO();
                            this.ConstructVO(dtResult.Rows[i], ref p_objResultArr[i]);
                            p_objResultArr[i].m_strConcentration = dtResult.Rows[i]["concentration_vchr"].ToString();
                        }
                    }
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                    svc.Dispose();
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindQCData
        /// <summary>
        /// m_lngFindQCData
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_intQCBatchSeq"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCData(IPrincipal p_objPrincipal, out clsLisQCDataVO[] p_objResultArr, int p_intQCBatchSeq, DateTime p_datBegin, DateTime p_datEnd)
        {
            long num = 0L;
            p_objResultArr = null;
            string strSql = string.Empty;
            IDataParameter[] parm = null;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCData");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                clsHRPTableService svc = new clsHRPTableService();

                strSql = @"select t1.data_seq_int,
                                   t1.qcbatch_seq_int,
                                   t1.concentration_seq_int,
                                   t1.result_num,
                                   t1.qcdate_dat
                              from t_opr_lis_qcdata t1
                             where t1.qcdate_dat >= ?
                               and t1.qcdate_dat < ?
                               and t1.qcbatch_seq_int in (?,?,?) ";
                try
                {
                    DataTable dtResult = null;

                    svc.CreateDatabaseParameter(5, out parm);
                    parm[0].Value = p_datBegin;
                    parm[1].Value = p_datEnd;
                    parm[2].Value = p_intQCBatchSeq;
                    parm[3].Value = Convert.ToInt16(p_intQCBatchSeq.ToString()+"1") ;
                    parm[4].Value = Convert.ToInt16(p_intQCBatchSeq.ToString()+"2");
                    num = svc.lngGetDataTableWithParameters(strSql, ref dtResult, parm);

                    if (num == 1L && dtResult != null && dtResult.Rows.Count > 0)
                    {
                        p_objResultArr = this.ConstructQCDataVOArr(dtResult);
                    }
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                    svc.Dispose();
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindQCReport
        /// <summary>
        /// m_lngFindQCReport
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQCBatchSeq"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <param name="p_status"></param>
        /// <param name="p_objQCReportArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCReport(IPrincipal p_objPrincipal, int p_intQCBatchSeq, DateTime p_datBegin, DateTime p_datEnd, enmQCStatus p_status, out clsLisQCReportVO[] p_objQCReportArr)
        {
            long num = 0L;
            string strSql = string.Empty;
            p_objQCReportArr = null;
            IDataParameter[] parm = null;
            clsHRPTableService svc = null;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCReport");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                try
                {
                    strSql = @"select t1.qcreport_seq_int,
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
                                       t1.report_stats_int,
                                       t2.lastname_vchr as reportor_name
                                  from t_opr_lis_qcreport t1, t_bse_employee t2
                                 where t1.reportor_id_chr = t2.empid_chr(+)
                                   and t1.status_int = ?
                                   and t1.qcbatch_seq_int = ?
                                   and t1.report_dat >= ?
                                   and t1.report_dat <= ? ";

                    svc = new clsHRPTableService();

                    if (p_status == enmQCStatus.Delete || p_status == enmQCStatus.Natrural)
                    {
                        svc.CreateDatabaseParameter(4,out parm);
                        parm[0].Value = Convert.ToInt16(p_status);
                        parm[1].Value = p_intQCBatchSeq;
                        parm[2].Value = p_datBegin;
                        parm[3].Value = p_datEnd;
                    }
                    else
                    {
                        strSql = strSql.Replace("AND t1.status_int = ?", "AND 3 = ?");
                        svc.CreateDatabaseParameter(4, out parm);
                        parm[0].Value = 3;
                        parm[1].Value = p_intQCBatchSeq;
                        parm[2].Value = p_datBegin;
                        parm[3].Value = p_datEnd;
                    }
                    DataTable dtResult = null;
                    num = svc.lngGetDataTableWithParameters(strSql, ref dtResult, parm);

                    if (num == 1L && dtResult != null && dtResult.Rows.Count > 0)
                    {
                        p_objQCReportArr = new clsLisQCReportVO[dtResult.Rows.Count];
                        for (int i = 0; i < p_objQCReportArr.Length; i++)
                        {
                            p_objQCReportArr[i] = new clsLisQCReportVO();
                            this.ConstructVO(dtResult.Rows[i], ref p_objQCReportArr[i]);
                            p_objQCReportArr[i].m_strReportorName = dtResult.Rows[i]["reportor_name"].ToString().Trim();
                        }
                    }
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                    svc.Dispose();
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngUpdateQCData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="QCBatch"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateQCData(IPrincipal p_objPrincipal, clsLisQCDataVO QCBatch)
        {
            long num = 0L;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngUpdateQCData");
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
                    IDataParameter[] parm = null;

                    long num2 = -1L;
                    num = 0L;

                    string strSql = @"update t_opr_lis_qcdata
                                               set qcbatch_seq_int       = ?,
                                                   result_num            = ?,
                                                   concentration_seq_int = ?,
                                                   qcdate_dat            = ?
                                             where data_seq_int = ? ";

                    svc.CreateDatabaseParameter(5, out parm);
                    parm[0].Value = QCBatch.m_intQCBatchSeq;
                    parm[1].Value = QCBatch.m_dlbResult;
		            parm[2].Value = QCBatch.m_intConcentrationSeq;
                    parm[3].Value = QCBatch.m_datQCDate;
                    parm[4].Value = QCBatch.m_intSeq;

                    num = svc.lngExecuteParameterSQL(strSql, ref num2, parm);
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                }

                result = num;
            }
            return result;
        }

        #endregion

        #region m_lngInsertQCData
        /// <summary>
        /// m_lngInsertQCData
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCData"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertQCData(IPrincipal p_objPrincipal, clsLisQCDataVO p_objQCData, out int p_intSeq)
        {
            long num = 0L;
            p_intSeq = -1;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngInsert");
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
                    num = 0L;
                    long num2 = -1L;
                    num = clsPublicSvc.m_lngGetSequence("seq_lis_qcdata", out p_intSeq);
                    if (num <= 0L)
                    {
                        result = -1L;
                        return result;
                    }
                    
                    string strSql = @"insert into t_opr_lis_qcdata
                                              (data_seq_int,
                                               qcbatch_seq_int,
                                               result_num,
                                               concentration_seq_int,
                                               qcdate_dat)
                                            values
                                              (?, ?, ?, ?, ?) ";
                    IDataParameter[] parm = null ;
                    svc.CreateDatabaseParameter(5,out parm);
                    parm[0].Value = p_intSeq;
                    parm[0].Value = p_objQCData.m_intQCBatchSeq;
                    parm[0].Value = p_objQCData.m_dlbResult;
                    parm[0].Value = p_objQCData.m_intConcentrationSeq;
                    parm[0].Value = p_objQCData.m_datQCDate;
                    num = svc.lngExecuteParameterSQL(strSql, ref num2, parm);
                    if (num > 0L)
                    {
                        p_objQCData.m_intSeq = p_intSeq;
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
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngDeleteQCData
        /// <summary>
        /// m_lngDeleteQCData
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteQCData(IPrincipal p_objPrincipal, int p_intSeq)
        {
            long num = 0L;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngDeleteQCData");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                long num2 = -1L;
                num = 0L;
                clsHRPTableService svc = new clsHRPTableService();
                try
                {
                    IDataParameter[] parm = null;
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = p_intSeq;
                    string strSql = @"delete t_opr_lis_qcdata where data_seq_int = ?";

                    num = svc.lngExecuteParameterSQL(strSql, ref num2, parm);
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngSaveAllQCData
        /// <summary>
        /// m_lngSaveAllQCData
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objInsertArr"></param>
        /// <param name="p_objUpdateArr"></param>
        /// <param name="p_intDelArr"></param>
        /// <param name="p_intISeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveAllQCData(IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objInsertArr, clsLisQCDataVO[] p_objUpdateArr, int[] p_intDelArr, out int[] p_intISeqArr)
        {
            p_intISeqArr = null;
            long num = 0L;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngSaveAll");
            long result;
            if (num <= 0L)
            {
                result = num;
            }
            else
            {
                if (p_objUpdateArr != null && p_objUpdateArr.Length > 0)
                {
                    num = this.m_lngUpdateQCDataByArr(p_objPrincipal, p_objUpdateArr);
                    if (num <= 0L)
                    {
                        ContextUtil.SetAbort();
                    }
                }
                if (p_objInsertArr != null && p_objInsertArr.Length > 0)
                {
                    num = this.m_lngInsertQCDataByArr(p_objPrincipal, p_objInsertArr, out p_intISeqArr);
                    if (num <= 0L)
                    {
                        p_intISeqArr = null;
                        ContextUtil.SetAbort();
                    }
                }
                if (p_intDelArr != null && p_intDelArr.Length > 0)
                {
                    num = this.m_lngDeleteQCDataByArr(p_objPrincipal, p_intDelArr);
                    if (num <= 0L)
                    {
                        ContextUtil.SetAbort();
                    }
                }
                p_intDelArr = null;
                p_objInsertArr = null;
                p_objUpdateArr = null;
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngUpdateQCDataByArr
        /// <summary>
        /// m_lngUpdateQCDataByArr
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCDataArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateQCDataByArr(IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objQCDataArr)
        {
            long num = 0L;
            long result;
            if (p_objQCDataArr == null || p_objQCDataArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngUpdateQCDataByArr");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    try
                    {
                        int num2 = p_objQCDataArr.Length;
                        DbType[] dbTypeArr = new DbType[]{ DbType.Int32, DbType.Double, DbType.Int32, DbType.DateTime, DbType.Int32 };
                        object[][] objArr = new object[dbTypeArr.Length][];

                        for (int i = 0; i < objArr.Length; i++)
                        {
                            objArr[i] = new object[num2];
                        }
                        for (int j = 0; j < num2; j++)
                        {
                            clsLisQCDataVO clsLisQCDataVO = p_objQCDataArr[j];
                            objArr[0][j] = clsLisQCDataVO.m_intQCBatchSeq;
                            objArr[1][j] = clsLisQCDataVO.m_dlbResult;
                            objArr[2][j] = clsLisQCDataVO.m_intConcentrationSeq;
                            objArr[3][j] = clsLisQCDataVO.m_datQCDate;
                            objArr[4][j] = clsLisQCDataVO.m_intSeq;
                        }
                        clsHRPTableService svc = new clsHRPTableService();

                        string strSql = @"update t_opr_lis_qcdata
                                                   set qcbatch_seq_int       = ?,
                                                       result_num            = ?,
                                                       concentration_seq_int = ?,
                                                       qcdate_dat            = ?
                                                 where data_seq_int = ? ";

                        num = svc.m_lngSaveArrayWithParameters(strSql, objArr, dbTypeArr);
                    }
                    catch (Exception objEx)
                    {
                        new clsLogText().LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_objQCDataArr = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngInsertQCDataByArr
        /// <summary>
        /// m_lngInsertQCDataByArr
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCDataArr"></param>
        /// <param name="p_intSeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertQCDataByArr(IPrincipal p_objPrincipal, clsLisQCDataVO[] p_objQCDataArr, out int[] p_intSeqArr)
        {
            long num = 0L;
            p_intSeqArr = null;
            long result;
            if (p_objQCDataArr == null || p_objQCDataArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngInsertByArr");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    try
                    {
                        int num2 = p_objQCDataArr.Length;
                        num = clsPublicSvc.m_lngGetSequenceArr("seq_lis_qcdata", num2, out p_intSeqArr);
                        if (num <= 0L)
                        {
                            result = num;
                            return result;
                        }
                        DbType[] dbTypeArr = new DbType[]{DbType.Int32, DbType.Int32, DbType.Double, DbType.Int32, DbType.DateTime};
                        object[][] objArr = new object[dbTypeArr.Length][];
                        for (int i = 0; i < objArr.Length; i++)
                        {
                            objArr[i] = new object[num2];
                        }
                        for (int j = 0; j < num2; j++)
                        {
                            clsLisQCDataVO clsLisQCDataVO = p_objQCDataArr[j];
                            objArr[0][j] = p_intSeqArr[j];
                            objArr[1][j] = clsLisQCDataVO.m_intQCBatchSeq;
                            objArr[2][j] = clsLisQCDataVO.m_dlbResult;
                            objArr[3][j] = clsLisQCDataVO.m_intConcentrationSeq;
                            objArr[4][j] = clsLisQCDataVO.m_datQCDate;
                        }
                        clsHRPTableService clsHRPTableService = new clsHRPTableService();
                        string strSql = @"insert into t_opr_lis_qcdata
                                                          (data_seq_int,
                                                           qcbatch_seq_int,
                                                           result_num,
                                                           concentration_seq_int,
                                                           qcdate_dat)
                                                        values
                                                          (?, ?, ?, ?, ?) ";
                        num = clsHRPTableService.m_lngSaveArrayWithParameters(strSql, objArr, dbTypeArr);
                        if (num <= 0L)
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
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngDeleteQCDataByArr
        /// <summary>
        /// m_lngDeleteQCDataByArr
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteQCDataByArr(IPrincipal p_objPrincipal, int[] p_intSeqArr)
        {
            long num = 0L;
            long result;
            if (p_intSeqArr == null || p_intSeqArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngDeleteQCDataByArr");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    clsHRPTableService svc = new clsHRPTableService();
                    try
                    {
                        string strSql  = "delete t_opr_lis_qcdata where data_seq_int = ?";
                        for (int i = 1; i < p_intSeqArr.Length; i++)
                        {
                            strSql += " or data_seq_int = ?";
                        }
                        IDataParameter[] parm = null;
                        svc.CreateDatabaseParameter(p_intSeqArr.Length, out parm);

                        for (int i = 0; i < p_intSeqArr.Length; i++)
                        {
                            parm[i].Value = p_intSeqArr[i];
                        }
                        long num2 = -1L;
                        num = 0L;
                        num = svc.lngExecuteParameterSQL(strSql, ref num2, parm);
                        parm = null;
                    }
                    catch (Exception objEx)
                    {
                        new clsLogText().LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_intSeqArr = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngReceiveDeviceQCData
        /// <summary>
        /// m_lngReceiveDeviceQCData
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStartDat"></param>
        /// <param name="p_strEndDat"></param>
        /// <param name="p_intBatchSeqArr"></param>
        /// <param name="p_objQCDataArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReceiveDeviceQCData(IPrincipal p_objPrincipal, string p_strStartDat, string p_strEndDat, int[] p_intBatchSeqArr, out clsLisQCDataVO[] p_objQCDataArr)
        {
            p_objQCDataArr = null;
            long num = 0L;
            long result;
            if (string.IsNullOrEmpty(p_strStartDat) || string.IsNullOrEmpty(p_strEndDat) || p_intBatchSeqArr == null || p_intBatchSeqArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
                num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngReceiveDeviceQCData");
                if (num <= 0L)
                {
                    result = num;
                }
                else
                {
                    try
                    {
                        string strSql = string.Empty;
                        strSql = @"select t.idx_int,
                                           t.device_check_item_name_vchr,
                                           t.device_sampleid_chr,
                                           t.result_vchr,
                                           t.check_dat,
                                           trunc(t.check_dat) checkdateorder,
                                           d.qcbatch_seq_int
                                      from t_opr_lis_result t
                                     inner join t_bse_lis_device_check_item a
                                        on a.device_check_item_name_vchr = t.device_check_item_name_vchr
                                       and a.is_qc_item_int = 1
                                       and a.has_graph_result_int = 0
                                     inner join t_bse_lis_device c
                                        on c.device_model_id_chr = a.device_model_id_chr
                                     inner join t_opr_lis_qcbatch d
                                        on d.check_item_id_chr = a.device_check_item_id_chr
                                     inner join t_opr_lis_qcbatchconcentration e
                                        on e.devicesample_id_vchr = t.device_sampleid_chr
                                       and d.qcbatch_seq_int = e.qcbatch_seq_int
                                     where t.deviceid_chr = c.deviceid_chr
                                       and t.check_dat between ? and ? and (d.qcbatch_seq_int = ? ";
                        for (int i = 1; i < p_intBatchSeqArr.Length; i++)
                        {
                            strSql += " or d.qcbatch_seq_int = ?";
                        }
                        strSql += ")";
                        strSql += @" order by  checkdateorder,          
                                                 d.qcbatch_seq_int,         
                                                 t.device_sampleid_chr,          
                                                 t.device_check_item_name_vchr,         
                                                 t.idx_int desc";

                        clsHRPTableService svc = new clsHRPTableService();
                        IDataParameter[] parm = null;
                        svc.CreateDatabaseParameter(p_intBatchSeqArr.Length + 2, out parm);

                        parm[0].DbType = DbType.DateTime;
                        parm[0].Value = Convert.ToDateTime(p_strStartDat);
                        parm[1].DbType = DbType.DateTime;
                        parm[1].Value = Convert.ToDateTime(p_strEndDat);
                        for (int i = 0; i < p_intBatchSeqArr.Length; i++)
                        {
                            parm[2 + i].Value = p_intBatchSeqArr[i];
                        }
                        DataTable dataTable = null;
                        num = svc.lngGetDataTableWithParameters(strSql, ref dataTable, parm);

                        if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                        {
                            int count = dataTable.Rows.Count;
                            List<clsLisQCDataVO> list = new List<clsLisQCDataVO>();
                            double dlbResult = 0.0;
                            string b = "";
                            string b2 = "";
                            string b3 = "";
                            string b4 = "";
                            for (int j = 0; j < count; j++)
                            {
                                DataRow dataRow = dataTable.Rows[j];
                                if (dataRow["qcbatch_seq_int"].ToString().Trim() != b || dataRow["checkdateorder"].ToString().Trim() != b2 || dataRow["device_sampleid_chr"].ToString().Trim() != b3 || dataRow["device_check_item_name_vchr"].ToString().Trim() != b4)
                                {
                                    b = dataRow["qcbatch_seq_int"].ToString().Trim();
                                    b2 = dataRow["checkdateorder"].ToString().Trim();
                                    b3 = dataRow["device_sampleid_chr"].ToString().Trim();
                                    b4 = dataRow["device_check_item_name_vchr"].ToString().Trim();
                                    if (double.TryParse(dataRow["result_vchr"].ToString(), out dlbResult) && dataRow["check_dat"] != DBNull.Value)
                                    {
                                        clsLisQCDataVO clsLisQCDataVO = new clsLisQCDataVO();
                                        clsLisQCDataVO.m_dlbResult = dlbResult;
                                        clsLisQCDataVO.m_datQCDate = Convert.ToDateTime(Convert.ToDateTime(dataRow["check_dat"]).ToString("yyyy-MM-dd"));
                                        clsLisQCDataVO.m_intSeq = -1;
                                        int.TryParse(dataRow["qcbatch_seq_int"].ToString(), out clsLisQCDataVO.m_intQCBatchSeq);
                                        clsLisQCDataVO.m_intConcentrationSeq = -1;
                                        list.Add(clsLisQCDataVO);
                                    }
                                }
                            }
                            if (list.Count > 0)
                            {
                                p_objQCDataArr = list.ToArray();
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        clsLogText clsLogText = new clsLogText();
                        clsLogText.LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_intBatchSeqArr = null;
                        p_strEndDat = null;
                        p_strStartDat = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion 

        #region m_lngUpdateSDXCV
        /// <summary>
        /// m_lngUpdateSDXCV
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCConcentration"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateSDXCV(IPrincipal p_objPrincipal, clsLisQCConcentrationVO p_objQCConcentration)
        {
            long num = 0L;
            long result;
            if (p_objQCConcentration == null)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngUpdateSDXCV");
                clsHRPTableService svc = new clsHRPTableService();

                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    try
                    {
                        long num2 = -1L;
                        num = 0L;

                        
                        string strSql = @"update t_opr_lis_qcbatchconcentration
                                                set status_int = ?, 
                                                avg_num = ?, 
                                                sd_num = ?, cv_num = ?
                                                where qcbatch_seq_int = ?";
                        IDataParameter[] parm = null;
                        svc.CreateDatabaseParameter(5, out parm);
                        parm[0].Value = 1;
                        parm[1].Value = p_objQCConcentration.m_dblAVG;
                        parm[2].Value = p_objQCConcentration.m_dblSD;
                        parm[3].Value = p_objQCConcentration.m_dblCV;
                        parm[4].Value = p_objQCConcentration.m_intQCBatchSeq;

                        num = svc.lngExecuteParameterSQL(strSql, ref num2, parm);
                        
                        if (num > 0L)
                        {
                            if (num2 <= 0L)
                            {
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        new clsLogText().LogDetailError(objEx, true);
                        svc.Dispose();
                    }
                    finally
                    {
                        p_objQCConcentration = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngGetSysParam
        /// <summary>
        /// m_lngGetSysParam
        /// </summary>
        /// <param name="p_strParam"></param>
        /// <param name="p_strParamValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysParam(string p_strParam, out string p_strParamValue)
        {
            p_strParamValue = "";
            long num = 0L;
            long result;
            clsHRPTableService svc = null;
            IDataParameter[] parm = null;

            if (string.IsNullOrEmpty(p_strParam))
            {
                result = num;
            }
            else
            {
                try
                {
                    string strSql = "select parmvalue_vchr  from t_bse_sysparm where status_int = 1   and parmcode_chr = ?";
                    svc = new clsHRPTableService();
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = p_strParam;
                    DataTable dataTable = null;
                    num = svc.lngGetDataTableWithParameters(strSql, ref dataTable, parm);

                    if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_strParamValue = dataTable.Rows[0][0].ToString().Trim();
                    }
                }
                catch (Exception objEx)
                {
                    clsLogText clsLogText = new clsLogText();
                    clsLogText.LogDetailError(objEx, true);
                    svc.Dispose();
                }
                finally
                {
                    p_strParam = null;
                }
                result = num;
            }
            return result;
        }
        #endregion

        #endregion

        #region frmACSetup 

        #region m_lngFindQCRule
        /// <summary>
        /// m_lngFindQCRule
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeq"></param>
        /// <param name="p_objRule"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCRule(IPrincipal p_objPrincipal, int p_intSeq, out clsLisQCRuleVO p_objRule)
        {
            long num = 0L;
            p_objRule = null;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCRule");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                DataTable dt = null;
                num = 0L;
                string Sql = "select * from t_bse_lis_qcrules where rule_seq_int = ?";
                try
                {
                    svc.CreateDatabaseParameter(1, out parm);
                    parm[0].Value = p_intSeq;
                    num = svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                    if (num == 1L && dt != null && dt.Rows.Count > 0)
                    {
                        p_objRule = new clsLisQCRuleVO();
                        this.ConstructVO(dt.Rows[0], ref p_objRule);
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

        #region m_lngFindQCRule
        /// <summary>
        /// m_lngFindQCRule
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCRule(IPrincipal p_objPrincipal, out clsLisQCRuleVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngFindQCRule");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                DataTable dt = null;
                num = 0L;
                string Sql = "select * from t_bse_lis_qcrules ";
                clsHRPTableService svc = new clsHRPTableService();

                try
                {

                    num = svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                    if (num == 1L && dt != null && dt.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisQCRuleVO[dt.Rows.Count];
                        for (int i = 0; i < p_objResultArr.Length; i++)
                        {
                            p_objResultArr[i] = new clsLisQCRuleVO();
                            this.ConstructVO(dt.Rows[i], ref p_objResultArr[i]);
                        }
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

        #region m_lngGetDeviceQCCheckItemByID
        /// <summary>
        /// m_lngGetDeviceQCCheckItemByID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceQCCheckItemByID(IPrincipal p_objPrincipal, string p_strDeviceID, out clsLISCheckItemNode[] p_objResultArr)
        {
            p_objResultArr = null;
            long num = 0L;
            long result;
            if (string.IsNullOrEmpty(p_strDeviceID))
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusinessQuery_Serv", "m_lngGetDeviceQCCheckItemByID");
                if (num <= 0L)
                {
                    result = num;
                }
                else
                {
                    IDataParameter[] param = null;

                    try
                    {
                        string Sql = @"select t.device_check_item_id_chr, 
                                              t.device_check_item_name_vchr
                                              from t_bse_lis_device_check_item 
                                              inner join t_bse_lis_device a 
                                              on t.device_model_id_chr = a.device_model_id_chr
                                              where t.is_qc_item_int = 1
                                              and a.deviceid_chr = ? ";
                        clsHRPTableService svc = new clsHRPTableService();
                        svc.CreateDatabaseParameter(1, out param);
                        param[0].Value = p_strDeviceID;
                        DataTable dataTable = null;
                        num = svc.lngGetDataTableWithParameters(Sql, ref dataTable, param);

                        if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                        {
                            int count = dataTable.Rows.Count;
                            p_objResultArr = new clsLISCheckItemNode[count];
                            for (int i = 0; i < count; i++)
                            {
                                DataRow dr = dataTable.Rows[i];
                                clsLISCheckItemNode vo = new clsLISCheckItemNode();
                                vo.strID = dr["device_check_item_id_chr"].ToString().Trim();
                                vo.strName = dr["device_check_item_name_vchr"].ToString().Trim();
                                p_objResultArr[i] = vo;
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        clsLogText clsLogText = new clsLogText();
                        clsLogText.LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_strDeviceID = null;
                        param = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngInsertQCBatch
        /// <summary>
        /// m_lngInsertQCBatch
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCBatch"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertQCBatch(IPrincipal p_objPrincipal, clsLisQCBatchVO p_objQCBatch, out int p_intSeq)
        {
            long num = 0L;
            p_intSeq = -1;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngInsertQCBatch");
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
                    num = clsPublicSvc.m_lngGetSequence("seq_lis_qcbatch", out p_intSeq);
                    if (num <= 0L)
                    {
                        result = -1L;
                        return result;
                    }
                    num = 0L;
                    p_objQCBatch.m_dtModify = DateTime.Parse(new System.DateTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    IDataParameter[] param = this.GetInsertDataParameterArr(p_objQCBatch, p_intSeq);
                    long num2 = -1L;

                    string Sql = @"insert into t_opr_lis_qcbatch
                                                (qcbatch_seq_int,
                                                workgroup_seq_int,
                                                deviceid_chr,
                                                check_item_id_chr,
                                                qcsample_lotno_vchr,
                                                qcsample_source_vchr,
                                                qcsample_vendor_vchr,
                                                reagent_vchr,
                                                reagent_batch_vchr,
                                                checkmethod_name_vchr,
                                                wavelength_num,
                                                qcrules_vchr,
                                                resultunit_vchr,
                                                begin_dat,
                                                end_dat,
                                                summary_vchr,
                                                operator_id_chr,
                                                modify_dat,
                                                status_int,
                                                sort_num_int)
                                                nvalues
                                                (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";

                    num = svc.lngExecuteParameterSQL(Sql, ref num2, param);
                    if (num > 0L)
                    {
                        p_objQCBatch.m_intSeq = p_intSeq;
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

        #region m_lngInsertQCBatchByArr
        /// <summary>
        /// m_lngInsertQCBatchByArr
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objQCBatchArr"></param>
        /// <param name="p_intSeqArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertQCBatchByArr(IPrincipal p_objPrincipal, clsLisQCBatchVO[] p_objQCBatchArr, out int[] p_intSeqArr)
        {
            p_intSeqArr = null;
            long num = 0L;
            long result;
            if (p_objQCBatchArr == null || p_objQCBatchArr.Length <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngInsertQCBatchByArr");
                if (num <= 0L)
                {
                    result = -1L;
                }
                else
                {
                    clsHRPTableService svc = new clsHRPTableService();
                    try
                    {
                        num = 0L;
                        int num2 = p_objQCBatchArr.Length;
                        num = clsPublicSvc.m_lngGetSequenceArr("seq_lis_qcbatch", num2, out p_intSeqArr);
                        if (num <= 0L)
                        {
                            result = -1L;
                            return result;
                        }
                        DbType[] dbTypes = new DbType[]{DbType.Int32, DbType.Int32, DbType.String, 
					                                    DbType.String, DbType.String, DbType.String, 
					                                    DbType.String, DbType.String, DbType.String, 
					                                    DbType.String, DbType.Double, DbType.String, 
					                                    DbType.String, DbType.DateTime, DbType.DateTime, 
					                                    DbType.String, DbType.String, DbType.DateTime, 
					                                    DbType.Int32, DbType.Int32};
                        object[][] array = new object[20][];

                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = new object[num2];
                        }
                        DateTime dateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        for (int i = 0; i < num2; i++)
                        {
                            int num3 = 0;
                            clsLisQCBatchVO clsLisQCBatchVO = p_objQCBatchArr[i];
                            array[num3++][i] = p_intSeqArr[i];
                            array[num3++][i] = DBAssist.ToObject(clsLisQCBatchVO.m_intWorkGroupSeq);
                            array[num3++][i] = clsLisQCBatchVO.m_strDeviceId;
                            array[num3++][i] = clsLisQCBatchVO.m_strCheckItemId;
                            array[num3++][i] = clsLisQCBatchVO.m_strSampleLotNo;
                            array[num3++][i] = clsLisQCBatchVO.m_strSampleSource;
                            array[num3++][i] = clsLisQCBatchVO.m_strSampleVendor;
                            array[num3++][i] = clsLisQCBatchVO.m_strReagent;
                            array[num3++][i] = clsLisQCBatchVO.m_strReagentBatch;
                            array[num3++][i] = clsLisQCBatchVO.m_strCheckmethodName;
                            array[num3++][i] = DBAssist.ToObject(clsLisQCBatchVO.m_dblWaveLength);
                            array[num3++][i] = clsLisQCBatchVO.m_strQCRules;
                            array[num3++][i] = clsLisQCBatchVO.m_strResultUnit;
                            array[num3++][i] = DBAssist.ToObject(clsLisQCBatchVO.m_dtBegin);
                            array[num3++][i] = DBAssist.ToObject(clsLisQCBatchVO.m_dtEnd);
                            array[num3++][i] = clsLisQCBatchVO.m_strSummary;
                            array[num3++][i] = clsLisQCBatchVO.m_strOperatorId;
                            array[num3++][i] = dateTime;
                            array[num3++][i] = (int)clsLisQCBatchVO.m_enmStatus;
                            array[num3++][i] = DBAssist.ToInt32(clsLisQCBatchVO.m_strSortNum);
                        }
                        num = 0L;

                        string Sql = @"insert into t_opr_lis_qcbatch
                                                  (qcbatch_seq_int,
                                                   workgroup_seq_int,
                                                   deviceid_chr,
                                                   check_item_id_chr,
                                                   qcsample_lotno_vchr,
                                                   qcsample_source_vchr,
                                                   qcsample_vendor_vchr,
                                                   reagent_vchr,
                                                   reagent_batch_vchr,
                                                   checkmethod_name_vchr,
                                                   wavelength_num,
                                                   qcrules_vchr,
                                                   resultunit_vchr,
                                                   begin_dat,
                                                   end_dat,
                                                   summary_vchr,
                                                   operator_id_chr,
                                                   modify_dat,
                                                   status_int,
                                                   sort_num_int)
                                                values
                                                  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";

                        num = svc.m_lngSaveArrayWithParameters(Sql, array, dbTypes);

                        if (num <= 0L)
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
                        p_objQCBatchArr = null;
                    }

                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngUpdateQCBatch
        /// <summary>
        /// m_lngUpdateQCBatch
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="QCBatch"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateQCBatch(IPrincipal p_objPrincipal, clsLisQCBatchVO QCBatch)
        {
            long num = 0L;
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngUpdateQCBatch");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                clsHRPTableService clsHRPTableService = new clsHRPTableService();
                try
                {
                    IDataParameter[] updateDataParameterArr = this.GetUpdateDataParameterArr(QCBatch);
                    long num2 = -1L;
                    num = 0L;

                    string Sql = @"update t_opr_lis_qcbatch
                                           set workgroup_seq_int     = ?,
                                               deviceid_chr          = ?,
                                               check_item_id_chr     = ?,
                                               qcsample_lotno_vchr   = ?,
                                               qcsample_source_vchr  = ?,
                                               qcsample_vendor_vchr  = ?,
                                               reagent_vchr          = ?,
                                               reagent_batch_vchr    = ?,
                                               checkmethod_name_vchr = ?,
                                               wavelength_num        = ?,
                                               qcrules_vchr          = ?,
                                               resultunit_vchr       = ?,
                                               begin_dat             = ?,
                                               end_dat               = ?,
                                               summary_vchr          = ?,
                                               operator_id_chr       = ?,
                                               modify_dat            = ?,
                                               status_int            = ?,
                                               sort_num_int          = ?
                                         where qcbatch_seq_int = ? ";

                    num = clsHRPTableService.lngExecuteParameterSQL(Sql, ref num2, updateDataParameterArr);
                    clsHRPTableService.Dispose();
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngDeleteQCBatch
        /// <summary>
        /// m_lngDeleteQCBatch
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteQCBatch(IPrincipal p_objPrincipal, int p_intSeq)
        {
            long num = 0L;
            clsHRPTableService svc = new clsHRPTableService();
            clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
            num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQCBusiness_Serv", "m_lngDeleteQCBatch");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                try
                {
                    IDataParameter[] param = null;
                    svc.CreateDatabaseParameter(1, out param);
                    param[0].Value = p_intSeq;
                    long num2 = -1L;
                    num = svc.lngExecuteParameterSQL("delete t_opr_lis_qcbatch where qcbatch_seq_int = ?", ref num2, param);
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

        #region m_lngInsertBatchSet
        /// <summary>
        /// m_lngInsertBatchSet
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertBatchSet(DataTable p_dtbResult)
        {
            clsHRPTableService svc = null;
            for (int i = 0; i < p_dtbResult.Rows.Count; i++)
            {
                double num = 0.0;
                DataRow dataRow = p_dtbResult.Rows[i];
                clsLisQCBatchVO QCBatchVO = new clsLisQCBatchVO();
                clsLisQCConcentrationVO QCConcentrationVO = new clsLisQCConcentrationVO();
                double.TryParse(dataRow["wavelength"].ToString(), out num);
                QCBatchVO.m_dblWaveLength = num;
                QCBatchVO.m_dtBegin = DateTime.Parse(dataRow["begindate"].ToString());
                QCBatchVO.m_dtEnd = DateTime.Parse(dataRow["enddate"].ToString());
                QCBatchVO.m_intSeq = int.Parse(dataRow["intSeq"].ToString());
                QCBatchVO.m_strCheckItemId = dataRow["checkitemsid"].ToString();
                QCBatchVO.m_strCheckmethodName = dataRow["method"].ToString();
                QCBatchVO.m_strDeviceId = dataRow["m_strDeviceId"].ToString();
                QCBatchVO.m_strResultUnit = dataRow["unit"].ToString();
                QCBatchVO.m_strSampleLotNo = dataRow["groupnum"].ToString();
                QCBatchVO.m_strSampleSource = dataRow["source"].ToString();
                QCBatchVO.m_strSortNum = dataRow["sortnum"].ToString();
                double.TryParse(dataRow["BValue"].ToString(), out num);
                QCConcentrationVO.m_dblAVG = num;
                double.TryParse(dataRow["sd"].ToString(), out num);
                QCConcentrationVO.m_dblSD = num;
                double.TryParse(dataRow["cv"].ToString(), out num);
                QCConcentrationVO.m_dblCV = num;
                if (dataRow["Concentration"].ToString().Contains("高浓度"))
                {
                    QCConcentrationVO.m_intConcentrationSeq = 2;
                }
                if (dataRow["Concentration"].ToString().Contains("中间值"))
                {
                    QCConcentrationVO.m_intConcentrationSeq = 3;
                }
                if (dataRow["Concentration"].ToString().Contains("临界值"))
                {
                    QCConcentrationVO.m_intConcentrationSeq = 4;
                }
                if (dataRow["Concentration"].ToString().Contains("低浓度"))
                {
                    QCConcentrationVO.m_intConcentrationSeq = 1;
                }
                QCConcentrationVO.m_intQCBatchSeq = int.Parse(dataRow["intSeq"].ToString());
                QCConcentrationVO.m_strDeviceSampleId = dataRow["code"].ToString();

                try
                {
                    string Sql1 = @"update t_opr_lis_qcbatch
                                           set check_item_id_chr     = ?,
                                               qcsample_lotno_vchr   = ?,
                                               deviceid_chr          = ?,
                                               qcsample_source_vchr  = ?,
                                               checkmethod_name_vchr = ?,
                                               wavelength_num        = ?,
                                               resultunit_vchr       = ?,
                                               begin_dat             = ?,
                                               end_dat               = ?,
                                               sort_num_int          = ?
                                         where qcbatch_seq_int = ? ";

                    string Sql2 = @"update t_opr_lis_qcbatchconcentration
                                           set avg_num               = ?,
                                               sd_num                = ?,
                                               cv_num                = ?,
                                               concentration_seq_int = ?,
                                               devicesample_id_vchr  = ?
                                         where qcbatch_seq_int = ? ";
                    svc = new clsHRPTableService();

                    IDataParameter[] array = null;
                    IDataParameter[] array2 = null;
                    svc.CreateDatabaseParameter(11, out array);
                    array[0].Value = QCBatchVO.m_strCheckItemId;
                    array[1].Value = QCBatchVO.m_strSampleLotNo;
                    array[2].Value = QCBatchVO.m_strDeviceId;
                    array[3].Value = QCBatchVO.m_strSampleSource;
                    array[4].Value = QCBatchVO.m_strCheckmethodName;
                    array[5].Value = QCBatchVO.m_dblWaveLength;
                    array[6].Value = QCBatchVO.m_strResultUnit;
                    array[7].DbType = DbType.DateTime;
                    array[7].Value = QCBatchVO.m_dtBegin;
                    array[8].DbType = DbType.DateTime;
                    array[8].Value = QCBatchVO.m_dtEnd;
                    array[9].DbType = DbType.Int32;
                    array[9].Value = int.Parse(QCBatchVO.m_strSortNum);
                    array[10].DbType = DbType.Int32;
                    array[10].Value = QCBatchVO.m_intSeq;

                    long num2 = 0L;
                    long num3 = svc.lngExecuteParameterSQL(Sql1, ref num2, array);
                    svc.CreateDatabaseParameter(6, out array2);

                    array2[0].DbType = DbType.Double;
                    array2[0].Value = QCConcentrationVO.m_dblAVG;
                    array2[1].DbType = DbType.Double;
                    array2[1].Value = QCConcentrationVO.m_dblSD;
                    array2[2].DbType = DbType.Double;
                    array2[2].Value = QCConcentrationVO.m_dblCV;
                    array2[3].DbType = DbType.Double;
                    array2[3].Value = QCConcentrationVO.m_intConcentrationSeq;
                    array2[4].Value = QCConcentrationVO.m_strDeviceSampleId;
                    array2[5].DbType = DbType.Double;
                    array2[5].Value = QCConcentrationVO.m_intQCBatchSeq;
                    long num4 = 0L;
                    long num5 = svc.lngExecuteParameterSQL(Sql2, ref num4, array2);

                    if (num4 == 0L)
                    {
                        Sql2 = @"insert into t_opr_lis_qcbatchconcentration
                                              (qcbatch_seq_int,
                                               concentration_seq_int,
                                               devicesample_id_vchr,
                                               avg_num,
                                               sd_num,
                                               cv_num)
                                            values
                                              (?, ?, ?, ?, ?, ?) ";

                        IDataParameter[] array3 = null;
                        svc.CreateDatabaseParameter(6, out array3);
                        array3[0].DbType = DbType.Double;
                        array3[0].Value = QCConcentrationVO.m_intQCBatchSeq;
                        array3[1].DbType = DbType.Double;
                        array3[1].Value = QCConcentrationVO.m_intConcentrationSeq;
                        array3[2].Value = QCConcentrationVO.m_strDeviceSampleId;
                        array3[3].DbType = DbType.Double;
                        array3[3].Value = QCConcentrationVO.m_dblAVG;
                        array3[4].DbType = DbType.Double;
                        array3[4].Value = QCConcentrationVO.m_dblSD;
                        array3[5].DbType = DbType.Double;
                        array3[5].Value = QCConcentrationVO.m_dblCV;
                        long num6 = 0L;
                        num5 = svc.lngExecuteParameterSQL(Sql2, ref num6, array3);
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    clsLogText clsLogText = new clsLogText();
                    bool flag = clsLogText.LogDetailError(ex, true);
                }
                finally
                {
                    svc.Dispose();
                }
            }
            
            return 1L;
        }
        #endregion

        #region m_lngInsertBatchSet
        /// <summary>
        /// m_lngInsertBatchSet
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lstResult"></param>
        /// <param name="p_lstContion"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertBatchSet(IPrincipal p_objPrincipal, List<clsLisQCBatchVO> p_lstResult, List<clsLisQCConcentrationVO> p_lstContion)
        {
            long num = 0L;
            long result;
            if (p_lstResult == null || p_lstResult.Count <= 0)
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService handSvc = new clsPrivilegeHandleService();
                num = handSvc.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.clsSchQCBatchSvc", "lngInsertBatchSet");
                if (num <= 0L)
                {
                    result = num;
                }
                else
                {
                    try
                    {
                        string strSQL = @"update t_opr_lis_qcbatch
                                                   set check_item_id_chr     = ?,
                                                       qcsample_lotno_vchr   = ?,
                                                       deviceid_chr          = ?,
                                                       qcsample_source_vchr  = ?,
                                                       checkmethod_name_vchr = ?,
                                                       wavelength_num        = ?,
                                                       resultunit_vchr       = ?,
                                                       begin_dat             = ?,
                                                       end_dat               = ?,
                                                       sort_num_int          = ?
                                                 where qcbatch_seq_int = ? ";

                        DbType[] dbTypes = new DbType[]{DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, 
					                                    DbType.String, DbType.DateTime, DbType.DateTime, DbType.Int32, DbType.Int32};
                        object[][] array = new object[11][];
                        int count = p_lstResult.Count;
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = new object[count];
                        }
                        for (int i = 0; i < count; i++)
                        {
                            int num2 = 0;
                            clsLisQCBatchVO clsLisQCBatchVO = p_lstResult[i];
                            array[num2++][i] = clsLisQCBatchVO.m_strCheckItemId;
                            array[num2++][i] = clsLisQCBatchVO.m_strSampleLotNo;
                            array[num2++][i] = clsLisQCBatchVO.m_strDeviceId;
                            array[num2++][i] = clsLisQCBatchVO.m_strSampleSource;
                            array[num2++][i] = clsLisQCBatchVO.m_strCheckmethodName;
                            array[num2++][i] = clsLisQCBatchVO.m_dblWaveLength;
                            array[num2++][i] = clsLisQCBatchVO.m_strResultUnit;
                            array[num2][i] = DbType.DateTime;
                            array[num2++][i] = clsLisQCBatchVO.m_dtBegin;
                            array[num2][i] = DbType.DateTime;
                            array[num2++][i] = clsLisQCBatchVO.m_dtEnd;
                            array[num2][i] = DbType.Int32;
                            array[num2++][i] = int.Parse(clsLisQCBatchVO.m_strSortNum);
                            array[num2][i] = DbType.Int32;
                            array[num2++][i] = clsLisQCBatchVO.m_intSeq;
                        }
                        clsHRPTableService svc = new clsHRPTableService();
                        num = 0L;
                        num = svc.m_lngSaveArrayWithParameters(strSQL, array, dbTypes);
                        if (num <= 0L)
                        {
                            ContextUtil.SetAbort();
                            result = num;
                            return result;
                        }
                        string strSQLCommand = @"update t_opr_lis_qcbatchconcentration
                                                           set avg_num               = ?,
                                                               sd_num                = ?,
                                                               cv_num                = ?,
                                                               concentration_seq_int = ?,
                                                               devicesample_id_vchr  = ?
                                                         where qcbatch_seq_int = ? ";
                        string strSQLCommand2 = @"insert into t_opr_lis_qcbatchconcentration
                                                                  (qcbatch_seq_int,
                                                                   concentration_seq_int,
                                                                   devicesample_id_vchr,
                                                                   avg_num,
                                                                   sd_num,
                                                                   cv_num)
                                                                values (?, ?, ?, ?, ?, ?) ";
                        for (int j = 0; j < p_lstContion.Count; j++)
                        {
                            clsLisQCConcentrationVO clsLisQCConcentrationVO = p_lstContion[j];
                            IDataParameter[] array2 = null;
                            svc.CreateDatabaseParameter(6, out array2);
                            array2[0].DbType = DbType.Double;
                            array2[0].Value = clsLisQCConcentrationVO.m_dblAVG;
                            array2[1].DbType = DbType.Double;
                            array2[1].Value = clsLisQCConcentrationVO.m_dblSD;
                            array2[2].DbType = DbType.Double;
                            array2[2].Value = clsLisQCConcentrationVO.m_dblCV;
                            array2[3].DbType = DbType.Double;
                            array2[3].Value = clsLisQCConcentrationVO.m_intConcentrationSeq;
                            array2[4].Value = clsLisQCConcentrationVO.m_strDeviceSampleId;
                            array2[5].DbType = DbType.Double;
                            array2[5].Value = clsLisQCConcentrationVO.m_intQCBatchSeq;
                            long num3 = 0L;
                            num = svc.lngExecuteParameterSQL(strSQLCommand, ref num3, array2);
                            if (num3 == 0L)
                            {
                                IDataParameter[] array3 = null;
                                svc.CreateDatabaseParameter(6, out array3);
                                array3[0].DbType = DbType.Double;
                                array3[0].Value = clsLisQCConcentrationVO.m_intQCBatchSeq;
                                array3[1].DbType = DbType.Double;
                                array3[1].Value = clsLisQCConcentrationVO.m_intConcentrationSeq;
                                array3[2].Value = clsLisQCConcentrationVO.m_strDeviceSampleId;
                                array3[3].DbType = DbType.Double;
                                array3[3].Value = clsLisQCConcentrationVO.m_dblAVG;
                                array3[4].DbType = DbType.Double;
                                array3[4].Value = clsLisQCConcentrationVO.m_dblSD;
                                array3[5].DbType = DbType.Double;
                                array3[5].Value = clsLisQCConcentrationVO.m_dblCV;
                                long num4 = 0L;
                                num = svc.lngExecuteParameterSQL(strSQLCommand2, ref num4, array3);
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        clsLogText clsLogText = new clsLogText();
                        clsLogText.LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_lstContion = null;
                        p_lstResult = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region ConstructVO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objRule"></param>
        private void ConstructVO(DataRow p_dtrSource, ref clsLisQCRuleVO p_objRule)
        {
            p_objRule.m_intSeq = ((p_dtrSource["RULE_SEQ_INT"] == DBNull.Value) ? 0 : int.Parse(p_dtrSource["RULE_SEQ_INT"].ToString().Trim()));
            p_objRule.m_strName = p_dtrSource["RULE_NAME_VCHR"].ToString().Trim();
            p_objRule.m_strAlias = p_dtrSource["RULE_ALIAS_VCHR"].ToString().Trim();
            p_objRule.m_strDesc = p_dtrSource["RULE_DESC_VCHR"].ToString().Trim();
            p_objRule.m_strFormula = p_dtrSource["RULE_FORMULA_VCHR"].ToString().Trim();
            p_objRule.m_strSummary = p_dtrSource["RULE_SUMMARY_VCHR"].ToString().Trim();
            p_objRule.m_enmDefaultflag = ((p_dtrSource["RULE_DEFAULTFLAG_INT"] == DBNull.Value) ? enmQCRuleDefault.NO : ((enmQCRuleDefault)int.Parse(p_dtrSource["RULE_DEFAULTFLAG_INT"].ToString().Trim())));
            p_objRule.m_enmWarnType = ((p_dtrSource["RULE_TYPEFLAG_INT"] == DBNull.Value) ? enmQCRuleWarnLevel.Warning : ((enmQCRuleWarnLevel)int.Parse(p_dtrSource["RULE_TYPEFLAG_INT"].ToString().Trim())));
        }
        #endregion

        #endregion

        #region frmCheckItemSelector

        #region m_lngGetCheckItemTree
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckItemTree(IPrincipal p_objPrincipal, out clsLISUserGroupNode root)
        {
            long num = 0L;
            root = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LisControl.clsQueryQC_Serv", "m_lngGetCheckItemTree");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                clsHRPTableService svc = new clsHRPTableService();
                string strSQL = "select t1.check_item_id_chr, t1.check_item_name_vchr from t_bse_lis_check_item t1";
                string strSQL2 = "select t1.apply_unit_id_chr, t1.apply_unit_name_vchr from t_aid_lis_apply_unit t1";
                string strSQL3 = "select t1.user_group_id_chr, t1.user_group_name_vchr from t_aid_lis_appuser_group t1";
                string strSQL4 = "select check_item_id_chr, apply_unit_id_chr, print_seq_int  from t_aid_lis_apply_unit_detail";
                string strSQL5 = "select user_group_id_chr, apply_unit_id_chr from t_aid_lis_appuser_group_detail";
                string strSQL6 = "select user_group_id_chr, child_user_group_id_chr from t_aid_lis_appuser_group_relate";
                DataTable dt = null;
                DataTable dt2 = null;
                DataTable dt3 = null;
                DataTable dt4 = null;
                DataTable dt5 = null;
                DataTable dt6 = null;
                try
                {
                    num = svc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                    num = svc.lngGetDataTableWithoutParameters(strSQL2, ref dt2);
                    num = svc.lngGetDataTableWithoutParameters(strSQL3, ref dt4);
                    num = svc.lngGetDataTableWithoutParameters(strSQL4, ref dt3);
                    num = svc.lngGetDataTableWithoutParameters(strSQL5, ref dt5);
                    num = svc.lngGetDataTableWithoutParameters(strSQL6, ref dt6);
                    Hashtable hashtable = new Hashtable();
                    Hashtable hashtable2 = new Hashtable();
                    Hashtable hashtable3 = new Hashtable();
                    Hashtable hashtable4 = new Hashtable();
                    IEnumerator enumerator;
                    if (dt != null)
                    {
                        enumerator = dt.Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow dataRow = (DataRow)enumerator.Current;
                                clsLISCheckItemNode clsLISCheckItemNode = new clsLISCheckItemNode();
                                clsLISCheckItemNode.strID = dataRow["check_item_id_chr"].ToString();
                                clsLISCheckItemNode.strName = dataRow["check_item_name_vchr"].ToString();
                                hashtable.Add(clsLISCheckItemNode.strID, clsLISCheckItemNode);
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    if (dt2 != null)
                    {
                        enumerator = dt2.Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow dr2 = (DataRow)enumerator.Current;
                                clsLISApplyUnitNode clsLISApplyUnitNode = new clsLISApplyUnitNode();
                                clsLISApplyUnitNode.strID = dr2["APPLY_UNIT_ID_CHR"].ToString();
                                clsLISApplyUnitNode.Name = dr2["APPLY_UNIT_NAME_VCHR"].ToString();
                                hashtable2.Add(clsLISApplyUnitNode.strID, clsLISApplyUnitNode);
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    if (dt4 != null)
                    {
                        enumerator = dt4.Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow dr3 = (DataRow)enumerator.Current;
                                clsLISUserGroupNode clsLISUserGroupNode = new clsLISUserGroupNode();
                                clsLISUserGroupNode.strID = dr3["USER_GROUP_ID_CHR"].ToString();
                                clsLISUserGroupNode.strName = dr3["USER_GROUP_NAME_VCHR"].ToString();
                                hashtable3.Add(clsLISUserGroupNode.strID, clsLISUserGroupNode);
                                hashtable4.Add(clsLISUserGroupNode.strID, clsLISUserGroupNode);
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    if (dt3 != null)
                    {
                        enumerator = dt3.Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow dr4 = (DataRow)enumerator.Current;
                                string key = dr4["APPLY_UNIT_ID_CHR"].ToString();
                                string key2 = dr4["CHECK_ITEM_ID_CHR"].ToString();
                                if (hashtable2.ContainsKey(key) && hashtable.ContainsKey(key2))
                                {
                                    if (((clsLISApplyUnitNode)hashtable2[key]).objItems == null)
                                    {
                                        ((clsLISApplyUnitNode)hashtable2[key]).objItems = new List<clsLISCheckItemNode>();
                                    }
                                    ((clsLISApplyUnitNode)hashtable2[key]).objItems.Add((clsLISCheckItemNode)hashtable[key2]);
                                }
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    hashtable = null;
                    if (dt5 != null)
                    {
                        enumerator = dt5.Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow dr5 = (DataRow)enumerator.Current;
                                string key3 = dr5["USER_GROUP_ID_CHR"].ToString();
                                string key = dr5["APPLY_UNIT_ID_CHR"].ToString();
                                if (hashtable3.ContainsKey(key3) && hashtable2.ContainsKey(key))
                                {
                                    if (((clsLISUserGroupNode)hashtable3[key3]).objUnitNodes == null)
                                    {
                                        ((clsLISUserGroupNode)hashtable3[key3]).objUnitNodes = new List<clsLISApplyUnitNode>();
                                    }
                                    ((clsLISUserGroupNode)hashtable3[key3]).objUnitNodes.Add((clsLISApplyUnitNode)hashtable2[key]);
                                }
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    hashtable2 = null;
                    if (dt6 != null)
                    {
                        enumerator = dt6.Rows.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                DataRow dr6 = (DataRow)enumerator.Current;
                                string key4 = dr6["USER_GROUP_ID_CHR"].ToString();
                                string key5 = dr6["CHILD_USER_GROUP_ID_CHR"].ToString();
                                if (hashtable3.ContainsKey(key4) && hashtable3.ContainsKey(key5))
                                {
                                    if (((clsLISUserGroupNode)hashtable3[key4]).objChildNodes == null)
                                    {
                                        ((clsLISUserGroupNode)hashtable3[key4]).objChildNodes = new List<clsLISUserGroupNode>();
                                    }
                                    ((clsLISUserGroupNode)hashtable3[key4]).objChildNodes.Add((clsLISUserGroupNode)hashtable3[key5]);
                                    hashtable4.Remove(key5);
                                }
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    hashtable3 = null;
                    root = new clsLISUserGroupNode();
                    root.objChildNodes = new List<clsLISUserGroupNode>();
                    enumerator = hashtable4.Values.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            clsLISUserGroupNode item = (clsLISUserGroupNode)enumerator.Current;
                            root.objChildNodes.Add(item);
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                    hashtable4 = null;
                }
                catch (Exception objEx)
                {
                    clsLogText clsLogText = new clsLogText();
                    clsLogText.LogError(objEx);
                    num = 0L;
                    root = null;
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngGetDeviceQCCheckItemByID2
        /// <summary>
        /// m_lngGetDeviceQCCheckItemByID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceQCCheckItemByID2(IPrincipal p_objPrincipal, string p_strDeviceID, out clsLISCheckItemNode[] p_objResultArr)
        {
            p_objResultArr = null;
            long num = 0L;
            long result;
            if (string.IsNullOrEmpty(p_strDeviceID))
            {
                result = num;
            }
            else
            {
                clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
                num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LisControl.clsQueryQC_Serv", "m_lngGetDeviceQCCheckItemByID");
                if (num <= 0L)
                {
                    result = num;
                }
                else
                {
                    try
                    {
                        string strSQL = @"select t.device_check_item_id_chr, t.device_check_item_name_vchr
                                                  from t_bse_lis_device_check_item t
                                                 inner join t_bse_lis_device a
                                                    on t.device_model_id_chr = a.device_model_id_chr
                                                 where t.is_qc_item_int = 1
                                                   and a.deviceid_chr = ? ";

                        clsHRPTableService svc = new clsHRPTableService();
                        IDataParameter[] parm = null;
                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = p_strDeviceID;
                        DataTable dataTable = null;
                        num = svc.lngGetDataTableWithParameters(strSQL, ref dataTable, parm);
                        parm = null;

                        if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                        {
                            int count = dataTable.Rows.Count;
                            p_objResultArr = new clsLISCheckItemNode[count];
                            for (int i = 0; i < count; i++)
                            {
                                DataRow dr = dataTable.Rows[i];
                                clsLISCheckItemNode lisCheckItemNode = new clsLISCheckItemNode();
                                lisCheckItemNode.strID = dr["device_check_item_id_chr"].ToString().Trim();
                                lisCheckItemNode.strName = dr["device_check_item_name_vchr"].ToString().Trim();
                                p_objResultArr[i] = lisCheckItemNode;
                            }
                        }
                    }
                    catch (Exception objEx)
                    {
                        clsLogText clsLogText = new clsLogText();
                        clsLogText.LogDetailError(objEx, true);
                    }
                    finally
                    {
                        p_strDeviceID = null;
                    }
                    result = num;
                }
            }
            return result;
        }
        #endregion

        #region m_lngFindWorkGroup
        /// <summary>
        /// m_lngFindWorkGroup
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindWorkGroup(IPrincipal p_objPrincipal, out clsLisWorkGroupVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdWorkGroupSvc", "m_lngFind");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                string strSQLCommand = "select * from t_bse_lis_workgroup";
                clsHRPTableService clsHRPTableService = new clsHRPTableService();
                try
                {
                    DataTable dataTable = null;
                    num = 0L;
                    num = clsHRPTableService.lngGetDataTableWithoutParameters(strSQLCommand, ref dataTable);
                    clsHRPTableService.Dispose();
                    if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisWorkGroupVO[dataTable.Rows.Count];
                        for (int i = 0; i < p_objResultArr.Length; i++)
                        {
                            p_objResultArr[i] = new clsLisWorkGroupVO();
                            this.ConstructVO(dataTable.Rows[i], ref p_objResultArr[i]);
                        }
                    }
                }
                catch (Exception objEx)
                {
                    clsLogText clsLogText = new clsLogText();
                    bool flag = clsLogText.LogError(objEx);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindVendor
        /// <summary>
        /// m_lngFindVendor
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindVendor(IPrincipal p_objPrincipal, out clsLisVendorVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdVendorSvc", "m_lngFind");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                string strSQLCommand = "SELECT * FROM T_BSE_LIS_VENDOR ";
                clsHRPTableService clsHRPTableService = new clsHRPTableService();
                try
                {
                    DataTable dataTable = null;
                    num = 0L;
                    num = clsHRPTableService.lngGetDataTableWithoutParameters(strSQLCommand, ref dataTable);
                    clsHRPTableService.Dispose();
                    if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisVendorVO[dataTable.Rows.Count];
                        for (int i = 0; i < p_objResultArr.Length; i++)
                        {
                            p_objResultArr[i] = new clsLisVendorVO();
                            this.ConstructVO(dataTable.Rows[i], ref p_objResultArr[i]);
                        }
                    }
                }
                catch (Exception objEx)
                {
                    clsLogText clsLogText = new clsLogText();
                    bool flag = clsLogText.LogError(objEx);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindQCBatchCombinatorial
        /// <summary>
        /// m_lngFindQCBatchCombinatorial
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCondition"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCBatchCombinatorial(IPrincipal p_objPrincipal, clsLisQCBatchSchVO p_objCondition, out clsLisQCBatchVO[] p_objRecordArr)
        {
            long num = 0L;
            p_objRecordArr = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LisControl.clsQueryQC_Serv", "m_lngFindQCBatchCombinatorial");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                string Sql = @"select t1.qcbatch_seq_int,
                                           t1.sort_num_int,
                                           t1.workgroup_seq_int,
                                           t1.deviceid_chr,
                                           t1.check_item_id_chr,
                                           t1.qcsample_lotno_vchr,
                                           t1.qcsample_source_vchr,
                                           t1.qcsample_vendor_vchr,
                                           t1.reagent_vchr,
                                           t1.reagent_batch_vchr,
                                           t1.checkmethod_name_vchr,
                                           t1.wavelength_num,
                                           t1.qcrules_vchr,
                                           t1.resultunit_vchr,
                                           t1.begin_dat,
                                           t1.end_dat,
                                           t1.summary_vchr,
                                           t1.operator_id_chr,
                                           t1.modify_dat,
                                           t1.status_int,
                                           t1.sort_num_int,
                                           t2.workgroup_name_vchr,
                                           t3.devicename_vchr,
                                           t3.device_model_desc_vchr,
                                           t4.device_check_item_name_vchr,
                                           t6.lastname_vchr as operator_name
                                      from t_opr_lis_qcbatch t1,
                                           t_bse_lis_workgroup t2,
                                           (select t31.deviceid_chr,
                                                   t31.devicename_vchr,
                                                   t32.device_model_desc_vchr,
                                                   t31.device_model_id_chr
                                              from t_bse_lis_device t31, t_bse_lis_device_model t32
                                             where t31.device_model_id_chr = t32.device_model_id_chr) t3,
                                           t_bse_lis_device_check_item t4,
                                           t_bse_employee t6
                                     where t1.status_int = 1
                                       and t1.workgroup_seq_int = t2.workgroup_seq_int(+)
                                       and t1.deviceid_chr = t3.deviceid_chr(+)
                                       and t3.device_model_id_chr = t4.device_model_id_chr
                                       and t1.check_item_id_chr = t4.device_check_item_id_chr(+)
                                       and t1.operator_id_chr = t6.empid_chr(+) ";

                string value2 = " and t1.qcbatch_seq_int = ?";
                string value3 = " and t1.workgroup_seq_int = ?";
                string value4 = " and t1.deviceid_chr = ?";
                string value5 = " and t1.check_item_id_chr = ?";
                string value6 = " and t1.qcsample_lotno_vchr = ?";
                string value7 = " and t1.begin_dat <= ?";
                string value8 = " and t1.end_dat >= ?";
                clsHRPTableService svc = new clsHRPTableService();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(Sql);
                ArrayList arrayList = new ArrayList();
                if (p_objCondition.m_datQueryBegin != DateTime.MinValue && p_objCondition.m_datQueryEnd != DateTime.MinValue)
                {
                    stringBuilder.Append(value7);
                    arrayList.Add(p_objCondition.m_datQueryEnd);
                    stringBuilder.Append(value8);
                    arrayList.Add(p_objCondition.m_datQueryBegin);
                }
                if (p_objCondition.m_intQCBatchSeq > 0)
                {
                    stringBuilder.Append(value2);
                    arrayList.Add(p_objCondition.m_intQCBatchSeq);
                }
                if (p_objCondition.m_intWorkGroupSeq > 0)
                {
                    stringBuilder.Append(value3);
                    arrayList.Add(p_objCondition.m_intWorkGroupSeq);
                }
                if (p_objCondition.m_strQCDevice != null && p_objCondition.m_strQCDevice.Trim() != "")
                {
                    stringBuilder.Append(value4);
                    arrayList.Add(p_objCondition.m_strQCDevice);
                }
                if (p_objCondition.m_strQCCheckItem != null && p_objCondition.m_strQCCheckItem.Trim() != "")
                {
                    stringBuilder.Append(value5);
                    arrayList.Add(p_objCondition.m_strQCCheckItem);
                }
                if (p_objCondition.m_strQCSampleLotNO != null && p_objCondition.m_strQCSampleLotNO.Trim() != "")
                {
                    stringBuilder.Append(value6);
                    arrayList.Add(p_objCondition.m_strQCSampleLotNO);
                }
                IDataParameter[] array = null;
                svc.CreateDatabaseParameter(arrayList.Count, out array);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    array[i].Value = arrayList[i];
                }
                try
                {
                    DataTable dataTable = null;
                    num = svc.lngGetDataTableWithParameters(stringBuilder.ToString(), ref dataTable, array);
                    if (num > 0L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_objRecordArr = new clsLisQCBatchVO[dataTable.Rows.Count];
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            p_objRecordArr[i] = new clsLisQCBatchVO();
                            this.ConstrucQuerytVO(dataTable.Rows[i], ref p_objRecordArr[i]);
                            p_objRecordArr[i].m_strWorkGroupName = dataTable.Rows[i]["workgroup_name_vchr"].ToString();
                            p_objRecordArr[i].m_strDeviceName = dataTable.Rows[i]["devicename_vchr"].ToString();
                            p_objRecordArr[i].m_strCheckItemName = dataTable.Rows[i]["device_check_item_name_vchr"].ToString();
                            p_objRecordArr[i].m_strOperatorName = dataTable.Rows[i]["operator_name"].ToString();
                            p_objRecordArr[i].m_strSortNum = dataTable.Rows[i]["sort_num_int"].ToString();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    svc.Dispose();
                    string message = ex.Message;
                    clsLogText clsLogText = new clsLogText();
                    bool flag = clsLogText.LogError(ex);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region  m_lngFindConcentration
        /// <summary>
        /// m_lngFindConcentration
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindConcentration(IPrincipal p_objPrincipal, out clsLisConcentrationVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LisControl.clsQueryQC_Serv", "m_lngFindConcentration");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                string strSQLCommand = "select * from t_bse_lis_concentration ";
                clsHRPTableService clsHRPTableService = new clsHRPTableService();
                try
                {
                    DataTable dataTable = null;
                    num = 0L;
                    num = clsHRPTableService.lngGetDataTableWithoutParameters(strSQLCommand, ref dataTable);
                    clsHRPTableService.Dispose();
                    if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisConcentrationVO[dataTable.Rows.Count];
                        for (int i = 0; i < p_objResultArr.Length; i++)
                        {
                            p_objResultArr[i] = new clsLisConcentrationVO();
                            this.ConstructVO(dataTable.Rows[i], ref p_objResultArr[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    clsLogText clsLogText = new clsLogText();
                    bool flag = clsLogText.LogError(ex);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngFindCheckMethod
        /// <summary>
        /// m_lngFindCheckMethod
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindCheckMethod(IPrincipal p_objPrincipal, out clsLisCheckMethodVO[] p_objResultArr)
        {
            long num = 0L;
            p_objResultArr = null;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LisControl.clsQueryQC_Serv", "m_lngFindCheckMethod");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                string strSQLCommand = "select * from t_bse_lis_checkmethod ";
                clsHRPTableService clsHRPTableService = new clsHRPTableService();
                try
                {
                    DataTable dataTable = null;
                    num = 0L;
                    num = clsHRPTableService.lngGetDataTableWithoutParameters(strSQLCommand, ref dataTable);
                    clsHRPTableService.Dispose();
                    if (num == 1L && dataTable != null && dataTable.Rows.Count > 0)
                    {
                        p_objResultArr = new clsLisCheckMethodVO[dataTable.Rows.Count];
                        for (int i = 0; i < p_objResultArr.Length; i++)
                        {
                            p_objResultArr[i] = new clsLisCheckMethodVO();
                            this.ConstructVO(dataTable.Rows[i], ref p_objResultArr[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    clsLogText clsLogText = new clsLogText();
                    bool flag = clsLogText.LogError(ex);
                }
                result = num;
            }
            return result;
        }
        #endregion

        #region m_lngUpdateQCReport
        /// <summary>
        ///  m_lngUpdateQCReport
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="QCBatch"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateQCReport(IPrincipal p_objPrincipal, clsLisQCReportVO QCBatch)
        {
            long num = 0L;
            clsPrivilegeHandleService clsPrivilegeHandleService = new clsPrivilegeHandleService();
            num = clsPrivilegeHandleService.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LisControl.clsTransactonQC_Serv", "m_lngUpdateQCReport");
            long result;
            if (num <= 0L)
            {
                result = -1L;
            }
            else
            {
                clsHRPTableService clsHRPTableService = new clsHRPTableService();
                try
                {
                    string strSQLCommand = @"update t_opr_lis_qcreport
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
                    IDataParameter[] updateDataParameterArr = this.GetUpdateDataParameterArr(QCBatch);
                    long num2 = -1L;
                    num = 0L;
                    num = clsHRPTableService.lngExecuteParameterSQL(strSQLCommand, ref num2, updateDataParameterArr);
                    clsHRPTableService.Dispose();
                }
                catch (Exception objEx)
                {
                    new clsLogText().LogError(objEx);
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

        #region ConstructVO
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objCheckMethod"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisCheckMethodVO p_objCheckMethod)
        {
            p_objCheckMethod.m_intSeq = DBAssist.ToInt32(p_dtrSource["METHOD_SEQ_INT"]);
            p_objCheckMethod.m_strName = p_dtrSource["CHECKMETHOD_NAME_VCHR"].ToString();
            p_objCheckMethod.m_strPycode = p_dtrSource["PYCODE_VCHR"].ToString();
            p_objCheckMethod.m_strWbcode = p_dtrSource["WBCODE_VCHR"].ToString();
        }
        #endregion

        #region ConstructVO
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objConcentration"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisConcentrationVO p_objConcentration)
        {
            p_objConcentration.m_intSeq = DBAssist.ToInt32(p_dtrSource["CONCENTRATION_SEQ_INT"]);
            p_objConcentration.m_strConcentration = p_dtrSource["CONCENTRATION_VCHR"].ToString();
            try
            {
                p_objConcentration.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
        }
        #endregion

        #region ConstrucQuerytVO
        /// <summary>
        /// ConstrucQuerytVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objQCBatch"></param>
        [AutoComplete]
        public void ConstrucQuerytVO(DataRow p_dtrSource, ref clsLisQCBatchVO p_objQCBatch)
        {
            p_objQCBatch.m_strSortNum = p_dtrSource["sort_num_int"].ToString().Trim();
            p_objQCBatch.m_intSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCBatch.m_intWorkGroupSeq = DBAssist.ToInt32(p_dtrSource["WORKGROUP_SEQ_INT"]);
            p_objQCBatch.m_strDeviceId = p_dtrSource["DEVICEID_CHR"].ToString().Trim();
            p_objQCBatch.m_strCheckItemId = p_dtrSource["CHECK_ITEM_ID_CHR"].ToString().Trim();
            p_objQCBatch.m_strSampleLotNo = p_dtrSource["QCSAMPLE_LOTNO_VCHR"].ToString().Trim();
            p_objQCBatch.m_strSampleSource = p_dtrSource["QCSAMPLE_SOURCE_VCHR"].ToString().Trim();
            p_objQCBatch.m_strSampleVendor = p_dtrSource["QCSAMPLE_VENDOR_VCHR"].ToString().Trim();
            p_objQCBatch.m_strReagent = p_dtrSource["REAGENT_VCHR"].ToString().Trim();
            p_objQCBatch.m_strReagentBatch = p_dtrSource["REAGENT_BATCH_VCHR"].ToString().Trim();
            p_objQCBatch.m_strCheckmethodName = p_dtrSource["CHECKMETHOD_NAME_VCHR"].ToString().Trim();
            p_objQCBatch.m_dblWaveLength = DBAssist.ToDouble(p_dtrSource["WAVELENGTH_NUM"]);
            p_objQCBatch.m_strQCRules = p_dtrSource["QCRULES_VCHR"].ToString().Trim();
            p_objQCBatch.m_strResultUnit = p_dtrSource["RESULTUNIT_VCHR"].ToString().Trim();
            p_objQCBatch.m_dtBegin = DBAssist.ToDateTime(p_dtrSource["BEGIN_DAT"]);
            p_objQCBatch.m_dtEnd = DBAssist.ToDateTime(p_dtrSource["END_DAT"]);
            p_objQCBatch.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString().Trim();
            p_objQCBatch.m_strOperatorId = p_dtrSource["OPERATOR_ID_CHR"].ToString().Trim();
            p_objQCBatch.m_dtModify = DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
            try
            {
                p_objQCBatch.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
        }

        #endregion

        #region ConstructVO
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objVendor"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisVendorVO p_objVendor)
        {
            p_objVendor.m_intSeq = ((p_dtrSource["VENDOR_SEQ_INT"] == DBNull.Value) ? 0 : int.Parse(p_dtrSource["VENDOR_SEQ_INT"].ToString().Trim()));
            p_objVendor.m_strVendor = p_dtrSource["VENDOR_VCHR"].ToString().Trim();
            p_objVendor.m_strId = p_dtrSource["VENDOR_ID_VCHR"].ToString().Trim();
            p_objVendor.m_strPycode = p_dtrSource["PYCODE_VCHR"].ToString().Trim();
            p_objVendor.m_strWbcode = p_dtrSource["WBCODE_VCHR"].ToString().Trim();
        }
        #endregion

        #region ConstructVO
        /// <summary>
        /// ConstructVO
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objWorkGroup"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisWorkGroupVO p_objWorkGroup)
        {
            p_objWorkGroup.m_intSeq = ((p_dtrSource["WORKGROUP_SEQ_INT"] == DBNull.Value) ? 0 : int.Parse(p_dtrSource["WORKGROUP_SEQ_INT"].ToString().Trim()));
            p_objWorkGroup.m_strName = p_dtrSource["WORKGROUP_NAME_VCHR"].ToString().Trim();
            p_objWorkGroup.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString().Trim();
            try
            {
                p_objWorkGroup.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
        }
        #endregion

        #endregion
    }
}