using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;
//Utility.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTmdQCBatchConcentrationSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 变动的元素

        #region Sql语句集合

        private const string m_strInsertSql =
            @"INSERT INTO T_OPR_LIS_QCBATCHCONCENTRATION (QCBATCH_SEQ_INT, CONCENTRATION_SEQ_INT,DEVICESAMPLE_ID_VCHR, STATUS_INT,AVG_NUM, SD_NUM, CV_NUM) VALUES (?,?,?,?, ?,?,?)";

        private const string m_strUpdateSql =
            @"UPDATE T_OPR_LIS_QCBATCHCONCENTRATION SET   DEVICESAMPLE_ID_VCHR=?, STATUS_INT=?, AVG_NUM=?, SD_NUM=?, CV_NUM=?  WHERE  QCBATCH_SEQ_INT=? AND CONCENTRATION_SEQ_INT=?  ";

        private const string m_strDeleteSql =
            @"DELETE T_OPR_LIS_QCBATCHCONCENTRATION WHERE QCBATCH_SEQ_INT=? AND CONCENTRATION_SEQ_INT=?";


        private const string m_strFindSql =
            @"SELECT * FROM T_OPR_LIS_QCBATCHCONCENTRATION WHERE QCBATCH_SEQ_INT=? AND CONCENTRATION_SEQ_INT=?";
       
        private const string m_strFindDeteledSql =
            "SELECT t1.*,t2.concentration_vchr FROM T_OPR_LIS_QCBATCHCONCENTRATION t1,t_bse_lis_Concentration t2 WHERE t1.Concentration_seq_int=t2.Concentration_seq_int AND t1.QCBATCH_SEQ_INT=? AND t1.status_int = 0";

        private const string m_strFindAllSql = @"SELECT * FROM T_OPR_LIS_QCBATCHCONCENTRATION ";

        private const string m_strFindSqlByBatchSeq =
            "SELECT t1.*,t2.concentration_vchr FROM T_OPR_LIS_QCBATCHCONCENTRATION t1,t_bse_lis_Concentration t2 WHERE t1.Concentration_seq_int=t2.Concentration_seq_int AND t1.status_int = 1 AND t1.QCBATCH_SEQ_INT=? ";

        #endregion

        private const string m_strCurrentSvcDetailName =
            "com.digitalwave.iCare.middletier.LIS.clsTmdQCBatchConcentrationSvc";

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCConcentrationVO p_objQCConcentration)
        {
            //    QCBATCH_SEQ_INT, CONCENTRATION_SEQ_INT,
            //    DEVICESAMPLE_ID_VCHR, STATUS_INT, AVG_NUM, SD_NUM, CV_NUM
            p_objQCConcentration.m_intConcentrationSeq = DBAssist.ToInt32(p_dtrSource["CONCENTRATION_SEQ_INT"]);
            p_objQCConcentration.m_intQCBatchSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCConcentration.m_strDeviceSampleId = p_dtrSource["DEVICESAMPLE_ID_VCHR"].ToString();
            try
            {
                p_objQCConcentration.m_enmStatus = (enmQCStatus) DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
            p_objQCConcentration.m_dblAVG = DBAssist.ToDouble(p_dtrSource["AVG_NUM"]);
            p_objQCConcentration.m_dblSD = DBAssist.ToDouble(p_dtrSource["SD_NUM"]);
            p_objQCConcentration.m_dblCV = DBAssist.ToDouble(p_dtrSource["CV_NUM"]);

        }

        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisQCConcentrationVO p_objQCConcentration)
        {
            //    QCBATCH_SEQ_INT, CONCENTRATION_SEQ_INT,
            //    DEVICESAMPLE_ID_VCHR, STATUS_INT, AVG_NUM, SD_NUM, CV_NUM

            System.Data.IDataParameter[] objODPArr = null;
            objODPArr =clsPublicSvc.m_objConstructIDataParameterArr(
                p_objQCConcentration.m_intQCBatchSeq,
                p_objQCConcentration.m_intConcentrationSeq,
                p_objQCConcentration.m_strDeviceSampleId,
                (int) p_objQCConcentration.m_enmStatus,
                DBAssist.ToObject(p_objQCConcentration.m_dblAVG),
                DBAssist.ToObject(p_objQCConcentration.m_dblSD),
                DBAssist.ToObject(p_objQCConcentration.m_dblCV)

                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisQCConcentrationVO p_objQCConcentration)
        {
            System.Data.IDataParameter[] objODPArr = null;
            objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                p_objQCConcentration.m_strDeviceSampleId,
                (int) p_objQCConcentration.m_enmStatus,
                DBAssist.ToObject(p_objQCConcentration.m_dblAVG),
                DBAssist.ToObject(p_objQCConcentration.m_dblSD),
                DBAssist.ToObject(p_objQCConcentration.m_dblCV),
                p_objQCConcentration.m_intQCBatchSeq,
                p_objQCConcentration.m_intConcentrationSeq
                );
            return objODPArr;
        }

        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal,
                                clsLisQCConcentrationVO p_objQCConcentration)
        {
            long lngRes = 0;

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


                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(p_objQCConcentration);

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strInsertSql, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
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
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal,
                                clsLisQCConcentrationVO p_objQCConcentration)
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
                System.Data.IDataParameter[] objODPArr = GetUpdateDataParameterArr(p_objQCConcentration);
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
        public long m_lngDelete(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQCBatchSeq,
                                int p_intConcentrationSeq)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngDelete");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr =
                    clsPublicSvc.m_objConstructIDataParameterArr(p_intQCBatchSeq, p_intConcentrationSeq);

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

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQCBatchSeq,
                              int p_intConcentrationSeq, out clsLisQCConcentrationVO p_objQCConcentration)
        {
            long lngRes = 0;
            p_objQCConcentration = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr =
                    clsPublicSvc.m_objConstructIDataParameterArr(p_intQCBatchSeq, p_intConcentrationSeq);

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strFindSql, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objQCConcentration = new clsLisQCConcentrationVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objQCConcentration);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQCBatchSeq,
                              out clsLisQCConcentrationVO[] p_objResultArr)
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
                System.Data.IDataParameter[] objODPArr =
                   clsPublicSvc.m_objConstructIDataParameterArr(p_intQCBatchSeq);

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strFindSqlByBatchSeq, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisQCConcentrationVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisQCConcentrationVO();
                        ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
                        p_objResultArr[i].m_strConcentration = dtbResult.Rows[i]["concentration_vchr"].ToString();
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
        public long m_lngFindDeleted(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQCBatchSeq,
                              out clsLisQCConcentrationVO[] p_objResultArr)
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
                System.Data.IDataParameter[] objODPArr =
                   clsPublicSvc.m_objConstructIDataParameterArr(p_intQCBatchSeq);

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strFindDeteledSql, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisQCConcentrationVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisQCConcentrationVO();
                        ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
                        p_objResultArr[i].m_strConcentration = dtbResult.Rows[i]["concentration_vchr"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 查找指定的质控浓度
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int[] p_intQCBatchSeqArr,
                              out clsLisQCConcentrationVO[] p_objResultArr)
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
                string strSQL = m_strFindSqlByBatchSeq;

                for (int index = 1; index < p_intQCBatchSeqArr.Length; index++)
                {
                    strSQL += "    or t1.qcbatch_seq_int = ?";
                }

                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(p_intQCBatchSeqArr.Length, out objDPArr);
                for (int index = 0; index < p_intQCBatchSeqArr.Length; index++)
                {
                    objDPArr[index].Value = p_intQCBatchSeqArr[index];
                }

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisQCConcentrationVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisQCConcentrationVO();
                        ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
                        p_objResultArr[i].m_strConcentration = dtbResult.Rows[i]["concentration_vchr"].ToString();
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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal,
                              out clsLisQCConcentrationVO[] p_objResultArr)
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

        private clsLisQCConcentrationVO[] ConstructVOArr(DataTable dtbResult)
        {
            clsLisQCConcentrationVO[] p_objResultArr = new clsLisQCConcentrationVO[dtbResult.Rows.Count];
            for (int i = 0; i < p_objResultArr.Length; i++)
            {
                p_objResultArr[i] = new clsLisQCConcentrationVO();
                ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
            }
            return p_objResultArr;
        }

        #endregion
    }
}