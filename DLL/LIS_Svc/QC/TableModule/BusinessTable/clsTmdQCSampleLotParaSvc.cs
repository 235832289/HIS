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
    public class clsTmdQCSampleLotParaSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 变动的元素
        #region Sql语句集合

        private const string m_strInsertSql = @"INSERT INTO T_OPR_LIS_QCSMPLOTPARA (CHECK_ITEM_ID_CHR, QCSMPLOT_SEQ_INT, AVG_NUM, SD_NUM,CV_NUM) VALUES(?,?,?,?,?)";
        private const string m_strUpdateSql = @"UPDATE T_OPR_LIS_QCSMPLOTPARA SET  AVG_NUM=?, SD_NUM,CV_NUM=? WHERE CHECK_ITEM_ID_CHR=? and QCSMPLOT_SEQ_INT=?";
        private const string m_strDeleteSql = @"DELETE T_OPR_LIS_QCSMPLOTPARA WHERE CHECK_ITEM_ID_CHR=? and QCSMPLOT_SEQ_INT=?";
        private const string m_strFindSql = @"SELECT * FROM T_OPR_LIS_QCSMPLOTPARA WHERE CHECK_ITEM_ID_CHR=? and QCSMPLOT_SEQ_INT=?";
        #endregion

        private const string m_strTableName = "T_OPR_LIS_QCSMPLOTPARA";
        private const string m_strPrimaryKey = "QCREPORT_SEQ_INT";
        private const string m_strCurrentSvcDetailName = "com.digitalwave.iCare.middletier.LIS.clsTmdQCSampleLotParaSvc";

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCSampleLotParaVO objQCSamplePara)
        {
            // CHECK_ITEM_ID_CHR, QCSMPLOT_SEQ_INT, AVG_NUM, SD_NUM,
            // CV_NUM

            objQCSamplePara.m_strCheckItemId = p_dtrSource["CHECK_ITEM_ID_CHR"].ToString();
            objQCSamplePara.m_intQCSmplotSeq = DBAssist.ToInt32(p_dtrSource["QCSMPLOT_SEQ_INT"]);
            objQCSamplePara.m_dblAVG = DBAssist.ToDouble(p_dtrSource["AVG_NUM"]);
            objQCSamplePara.m_dblSD = DBAssist.ToDouble(p_dtrSource["SD_NUM"]);
            objQCSamplePara.m_dblCV = DBAssist.ToDouble(p_dtrSource["CV_NUM"]);
        }

        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsLisQCSampleLotParaVO objQCSamplePara)
        {
            // CHECK_ITEM_ID_CHR, QCSMPLOT_SEQ_INT, AVG_NUM, SD_NUM,
            // CV_NUM

            IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(
                           objQCSamplePara.m_strCheckItemId,
                           objQCSamplePara.m_intQCSmplotSeq,
                           objQCSamplePara.m_dblAVG,
                           objQCSamplePara.m_dblSD,
                           objQCSamplePara.m_dblCV
                );
            return objODPArr;
        }

        private System.Data.IDataParameter[] GetUpdateDataParameterArr(clsLisQCSampleLotParaVO objQCSamplePara)
        {
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                        (
                           objQCSamplePara.m_dblAVG,
                           objQCSamplePara.m_dblSD,
                           objQCSamplePara.m_dblCV,
                            objQCSamplePara.m_strCheckItemId,
                           objQCSamplePara.m_intQCSmplotSeq
                        );
            return objODPArr;
        }
        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCSampleLotParaVO clsLisQCSamplePara)
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
                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(clsLisQCSamplePara);

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
        public long m_lngUpdate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisQCSampleLotParaVO objQCSamplePara)
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
                System.Data.IDataParameter[] objODPArr = GetUpdateDataParameterArr(objQCSamplePara);
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
        public long m_lngDelete(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckItemId, int p_intQCSmplotSeq)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngDelete");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_strCheckItemId, p_intQCSmplotSeq);

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
        public long m_lngFind(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckItemId, int p_intQCSmplotSeq, out clsLisQCSampleLotParaVO objQCSamplePara)
        {
            long lngRes = 0;
            objQCSamplePara = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, m_strCurrentSvcDetailName, "m_lngFind");
            if (lngRes <= 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_strCheckItemId, p_intQCSmplotSeq);
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strFindSql, ref dtbResult, objODPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    objQCSamplePara = new clsLisQCSampleLotParaVO();
                    this.ConstructVO(dtbResult.Rows[0], ref objQCSamplePara);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion
    }
}