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
    public class clsTmdConcentrationSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 变动的元素
        #region Sql语句集合

        private const string m_strInsertSql = @"INSERT INTO T_BSE_LIS_CONCENTRATION (CONCENTRATION_SEQ_INT, CONCENTRATION_VCHR, STATUS_INT) Values(?,?,?)";
        private const string m_strUpdateSql = @"UPDATE T_BSE_LIS_CONCENTRATION SET   CONCENTRATION_VCHR=?, STATUS_INT=? WHERE  CONCENTRATION_SEQ_INT=? ";
        private const string m_strDeleteSql = @"DELETE T_BSE_LIS_CONCENTRATION WHERE CONCENTRATION_SEQ_INT = ?";
        private const string m_strFindSql = @"SELECT * FROM T_BSE_LIS_CONCENTRATION WHERE CONCENTRATION_SEQ_INT = ?";
        #endregion

        private const string m_strTableName = "T_BSE_LIS_CONCENTRATION";
        private const string m_strPrimaryKey = "CONCENTRATION_SEQ_INT";
        private const string m_strCurrentSvcDetailName = "com.digitalwave.iCare.middletier.LIS.clsTmdConcentrationSvc";

        /// <summary>
        /// 构造vo
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objConcentration"></param>
        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisConcentrationVO p_objConcentration)
        {
            
            //  CONCENTRATION_SEQ_INT, CONCENTRATION_VCHR, STATUS_INT
            p_objConcentration.m_intSeq = DBAssist.ToInt32(p_dtrSource["CONCENTRATION_SEQ_INT"]);
            p_objConcentration.m_strConcentration = p_dtrSource["CONCENTRATION_VCHR"].ToString();
            try
            {
                p_objConcentration.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch { }

        }

        /// <summary>
        /// insert的参数组
        /// </summary>
        /// <param name="p_objConcentration"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisConcentrationVO p_objConcentration, int p_intSeq)
        {
            //  CONCENTRATION_SEQ_INT, CONCENTRATION_VCHR, STATUS_INT
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                (
                   p_intSeq,
                   p_objConcentration.m_strConcentration,
                   (int)p_objConcentration.m_enmStatus
                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisConcentrationVO p_objConcentration)
        {
            System.Data.IDataParameter[] objODPArr = null;
            objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                                                          p_objConcentration.m_strConcentration,
                                                          (int)p_objConcentration.m_enmStatus,
                                                          p_objConcentration.m_intSeq
                                                      );
            return objODPArr;
        }
        #endregion

        #region INSERT

        /// <summary>
        /// update的参数组
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objConcentration"></param>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisConcentrationVO p_objConcentration, out int p_intSeq)
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


                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(p_objConcentration, p_intSeq);

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(m_strInsertSql, ref lngRecEff, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0)
                {
                    p_objConcentration.m_intSeq = p_intSeq;//给VO赋值ID
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
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisConcentrationVO QCBatch)
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

        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSeq, out clsLisConcentrationVO p_objConcentration)
        {
            long lngRes = 0;
            p_objConcentration = null;
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
                    p_objConcentration = new clsLisConcentrationVO();
                    this.ConstructVO(dtbResult.Rows[0], ref p_objConcentration);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }
        [AutoComplete]
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, out clsLisConcentrationVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            string strSQL = @"SELECT * FROM T_BSE_LIS_CONCENTRATION ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisConcentrationVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisConcentrationVO();
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
    }
}