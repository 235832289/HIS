using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{   
   
    /// <summary>
    /// 药房请领业务类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAskForMedicineSVC:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 根据流水号删除药房请领明细
        /// <summary>
        /// 根据流水号删除药房请领明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelAskMedDetail(System.Security.Principal.IPrincipal p_objPrincipal,long m_lngSeqid)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL = @"delete from t_ds_ask_detail a where a.seriesid_int=?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected,objDataParm);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 插入药房请领主表和明细表数据
        /// <summary>
        /// 插入药房请领主表和明细表数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAskMedInfo(System.Security.Principal.IPrincipal p_objPrincipal,ref clsDS_Ask_VO m_objMainVo,ref clsDS_Ask_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL = @"insert into t_ds_ask a
            (a.seriesid_int, a.askerid_chr, a.askdept_chr, a.status_int,
             a.askdate_dat, a.comment_vchr, a.askid_vchr,a.exportdept_chr
            )
            values (?, ?, ?, ?,?, ?, ?,?)";
                                
                clsDS_Public_Supported_SVC objPubSvc = new clsDS_Public_Supported_SVC();
                string m_strTempId = string.Empty;
                string m_strMedStoreShortCode=string.Empty;
                string m_strParaValue = string.Empty;
                objPubSvc.m_lngGetSysParaByID(p_objPrincipal, "8007", out m_strParaValue);
                objPubSvc.m_lngGetSequence(p_objPrincipal, "SEQ_DS_ASK", out m_objMainVo.m_lngSERIESID_INT);
                objPubSvc.m_lngGetMedStoreShortCodeByDeptid(p_objPrincipal, m_objMainVo.m_strASKDEPT_CHR, out m_strMedStoreShortCode);
                objPubSvc.m_lngGetNewIdByName(p_objPrincipal, "t_ds_ask", "askid_vchr", m_strMedStoreShortCode, m_objMainVo.m_datASKDATE_DAT, ref m_strTempId);
                m_objMainVo.m_strASKID_VCHR = m_strMedStoreShortCode + m_objMainVo.m_datASKDATE_DAT.ToString("yyMMdd") + m_strParaValue.Split(';')[3] + m_strTempId;
                System.Data.IDataParameter[] objDataParm = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(8, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_lngSERIESID_INT;
                objDataParm[1].Value = m_objMainVo.m_strASKERID_CHR;
                objDataParm[2].Value = m_objMainVo.m_strASKDEPT_CHR;
                objDataParm[3].Value = m_objMainVo.m_intSTATUS_INT;
                objDataParm[4].Value = m_objMainVo.m_datASKDATE_DAT;
                objDataParm[5].Value = m_objMainVo.m_strComment;
                objDataParm[6].Value = m_objMainVo.m_strASKID_VCHR;
                objDataParm[7].Value = m_objMainVo.m_strEXPORTDEPT_CHR ;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
                if (m_objDetailArr == null || m_objDetailArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"insert into t_ds_ask_detail a
                            (a.seriesid_int, a.seriesid2_int, a.medicineid_chr,
                             a.medicinename_vchr, a.medspec_vchr, a.opunit_chr,
                             a.opamount_int, a.ipunit_chr, a.ipamount_int, a.packqty_dec,a.productorid_chr,
                             a.requestunit_chr,a.requestpackqty_dec,a.requestamount_int)                
                            values
                           (?, ?, ?,?, ?, ?,?, ?, ?, ?,?,?,?,?)";
                long[] lngSEQArr = null;
                lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_ASK_DETAIL", m_objDetailArr.Length, out lngSEQArr);
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.String, DbType.Double, DbType.String, DbType.String,
                DbType.String,DbType.Double,DbType.Double};
                object[][] objValues = new object[14][];
                int intItemCount = m_objDetailArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int iRow = 0; iRow < m_objDetailArr.Length; iRow++)
                {
                    m_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                    objValues[0][iRow] = m_objDetailArr[iRow].m_lngSERIESID_INT;
                    m_objDetailArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
                    objValues[1][iRow] = m_objDetailArr[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = m_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    objValues[3][iRow] = m_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = m_objDetailArr[iRow].m_strMEDSPEC_VCHR_VCHR;
                    objValues[5][iRow] = m_objDetailArr[iRow].m_strOPUNIT_CHR;
                    objValues[6][iRow] = m_objDetailArr[iRow].m_dblOPAMOUNT_INT;
                    objValues[7][iRow] = m_objDetailArr[iRow].m_strIPUNIT_CHR;
                    objValues[8][iRow] = m_objDetailArr[iRow].m_dblIPAMOUNT_INT;
                    objValues[9][iRow] = m_objDetailArr[iRow].m_dblPACKQTY_DEC;
                    objValues[10][iRow] = m_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                    objValues[11][iRow] = m_objDetailArr[iRow].m_strREQUESTUNIT_CHR;
                    objValues[12][iRow] = m_objDetailArr[iRow].m_dblREQUESTPACKQTY_DEC;
                    objValues[13][iRow] = m_objDetailArr[iRow].m_dblREQUESTAMOUNT_INT;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 更新药房请领主表和明细表数据
        /// <summary>
        /// 更新药房请领主表和明细表数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateAskMedInfo(System.Security.Principal.IPrincipal p_objPrincipal,clsDS_Ask_VO m_objMainVo, ref clsDS_Ask_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL = @"update t_ds_ask a
       set a.askdept_chr = ?,
       a.askdate_dat = ?,
       a.comment_vchr = ?,
       a.askerid_chr = ?,
       a.exportdept_chr=?
       where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPubSvc = new clsDS_Public_Supported_SVC();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(6, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_strASKDEPT_CHR;
                objDataParm[1].Value = m_objMainVo.m_datASKDATE_DAT;
                objDataParm[2].Value = m_objMainVo.m_strComment;
                objDataParm[3].Value = m_objMainVo.m_strASKERID_CHR;
                objDataParm[4].Value = m_objMainVo.m_strEXPORTDEPT_CHR;
                objDataParm[5].Value = m_objMainVo.m_lngSERIESID_INT;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
                if (m_objDetailArr == null || m_objDetailArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"delete from t_ds_ask_detail a where a.seriesid2_int=?";
                objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_lngSERIESID_INT;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);

                strSQL = @"insert into t_ds_ask_detail a
                            (a.seriesid_int, a.seriesid2_int, a.medicineid_chr,
                             a.medicinename_vchr, a.medspec_vchr, a.opunit_chr,
                             a.opamount_int, a.ipunit_chr, a.ipamount_int, a.packqty_dec,a.productorid_chr,
                             a.requestamount_int,a.requestunit_chr,a.requestpackqty_dec
                            )                
                            values (?, ?, ?,?, ?, ?,?, ?, ?, ?,?,?,?,?)";
                long[] lngSEQArr = null;
                lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_ASK_DETAIL", m_objDetailArr.Length, out lngSEQArr);
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.String, DbType.Double, DbType.String,DbType.String,
                DbType.Double,DbType.String,DbType.Double};
                object[][] objValues = new object[14][];
                int intItemCount = m_objDetailArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }

                for (int iRow = 0; iRow < m_objDetailArr.Length; iRow++)
                {
                    m_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                    objValues[0][iRow] = m_objDetailArr[iRow].m_lngSERIESID_INT;
                    m_objDetailArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
                    objValues[1][iRow] = m_objDetailArr[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = m_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    objValues[3][iRow] = m_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = m_objDetailArr[iRow].m_strMEDSPEC_VCHR_VCHR;
                    objValues[5][iRow] = m_objDetailArr[iRow].m_strOPUNIT_CHR;
                    objValues[6][iRow] = m_objDetailArr[iRow].m_dblOPAMOUNT_INT;
                    objValues[7][iRow] = m_objDetailArr[iRow].m_strIPUNIT_CHR;
                    objValues[8][iRow] = m_objDetailArr[iRow].m_dblIPAMOUNT_INT;
                    objValues[9][iRow] = m_objDetailArr[iRow].m_dblPACKQTY_DEC;
                    objValues[10][iRow] = m_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                    objValues[11][iRow] = m_objDetailArr[iRow].m_dblREQUESTAMOUNT_INT;
                    objValues[12][iRow] = m_objDetailArr[iRow].m_strREQUESTUNIT_CHR;
                    objValues[13][iRow] = m_objDetailArr[iRow].m_dblREQUESTPACKQTY_DEC;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion 
        
        #region 老代码（20080718）
        #region 获取药房请领主表信息
//        /// <summary>
//        /// 获取药房请领主表信息
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="m_datBegin"></param>
//        /// <param name="m_datEnd"></param>
//        /// <param name="m_dtAskInfo"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, string  m_strBeginDate, string m_strEndDate,string m_strAskDeptid,string m_strExportDeptid ,out DataTable m_dtAskInfo,out DataTable m_dtOutstorage)
//        {
//            m_dtAskInfo = null;
//            m_dtOutstorage = null;
//            DataView dv;
//            long lngRes = 0;
//            if (m_strAskDeptid == string.Empty)
//            {
//                try
//                {
//                    if (m_strExportDeptid == string.Empty)
//                    {
//                        string strSQL =
//               @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askdate_dat between ? and ? 
//union
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.status_int = 2 order by askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
//                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[0].DbType = DbType.DateTime;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr
//       and a.askdate_dat between ? and ? 
//union
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr and a.status_int = 3
//order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
//                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[0].DbType = DbType.DateTime;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();
//                    }
//                    else
//                    {

//                        string strSQL =
//               @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.askdate_dat between ? and ? 
//union 
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.status_int = 2 order by askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strExportDeptid;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strExportDeptid;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.askid_vchr=f.askid_vchr
//       and a.askdate_dat between ? and ? 
//union 
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.askid_vchr=f.askid_vchr and a.status_int = 3
//order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strExportDeptid;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strExportDeptid;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();

//                    }
//                }
//                catch (Exception objEx)
//                {
//                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }
//            }
//            else
//            {

//                try
//                {
//                    if (m_strExportDeptid == string.Empty)
//                    {
//                        string strSQL =
//               @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askdate_dat between ? and ? 
//union
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.status_int = 2 order by a.askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strAskDeptid.Trim();
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr
//       and a.askdate_dat between ? and ? 
//union 
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr and a.status_int = 3
//order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strAskDeptid.Trim();
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();
//                    }
//                    else
//                    {
//                        string strSQL =
//                              @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and trim(a.exportdept_chr) = ?
//	 and a.askdate_dat between ? and ?
// union
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and trim(a.exportdept_chr) = ?
//	 and a.status_int = 2
// order by askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = m_strExportDeptid;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[3].DbType = DbType.DateTime;
//                        m_objParaArr[4].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[5].Value = m_strExportDeptid;
                       
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and a.askid_vchr = f.askid_vchr
//	 and trim(a.exportdept_chr) = ?
//	 and a.askdate_dat between ? and ?
//union
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and a.askid_vchr = f.askid_vchr
//	 and trim(a.exportdept_chr) = ? and a.status_int = 3
// order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = m_strExportDeptid;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[3].DbType = DbType.DateTime;
//                        m_objParaArr[4].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[5].Value = m_strExportDeptid;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();
//                    }
//                }
//                catch (Exception objEx)
//                {
//                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }


//            }
//            return lngRes;
//        }
        #endregion 
        #endregion
    
        #region 作废请领主表单据的状态
        /// <summary>
        /// 作废请领主表单据的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, long[] lngArr)
        {
            if (lngArr.Length == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @" update t_ds_ask a set a.status_int=? where a.seriesid_int=?";
                DbType[] dbTypes = new DbType[] { DbType.Int16, DbType.Int64 };
                object[][] objValues = new object[2][];
                int intItemCount = lngArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int iRow = 0; iRow < lngArr.Length; iRow++)
                {

                    objValues[0][iRow] = 0;

                    objValues[1][iRow] = lngArr[iRow];
         
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 提交请领主表信息
        /// <summary>
        /// 提交请领主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="voArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommiteAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Ask_VO[] voArr)
        {
            if (voArr.Length == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @"  update t_ds_ask a set a.status_int=? ,a.commiter_chr=?,a.commit_dat=? where a.seriesid_int=?";
                DbType[] dbTypes = new DbType[] { DbType.Int16,DbType.String,DbType.DateTime, DbType.Int64 };
                object[][] objValues = new object[4][];
                int intItemCount = voArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int iRow = 0; iRow < voArr.Length; iRow++)
                {

                    objValues[0][iRow] = voArr[iRow].m_intSTATUS_INT;
                    objValues[1][iRow] = voArr[iRow].m_strCOMMITER_CHR;
                    objValues[2][iRow] = voArr[iRow].m_datCOMMIT_DAT;
                    objValues[3][iRow] = voArr[iRow].m_lngSERIESID_INT;

                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 审核请领主表单据的状态
        /// <summary>
        /// 审核请领主表单据的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngArr"></param>
        /// <param name="m_intType">状态值: 3、药库审核4、药房审核  </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngExamAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, long[] lngArr,int m_intType)
        {
            if (lngArr.Length == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @" update t_ds_ask a set a.status_int=? where a.seriesid_int=?";
                DbType[] dbTypes = new DbType[] { DbType.Int16, DbType.Int64 };
                object[][] objValues = new object[2][];
                int intItemCount = lngArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int iRow = 0; iRow < lngArr.Length; iRow++)
                {

                    objValues[0][iRow] = m_intType;

                    objValues[1][iRow] = lngArr[iRow];

                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 审核请领主表单据的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngArr"></param>
        /// <param name="m_intType">状态值: 3、药库审核4、药房审核  </param>
        /// <param name="p_strInstoreId">入库单号 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngExamAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, long lngSeqid, int m_intType, string p_strInstoreId)
        {
            if (lngSeqid == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @" update t_ds_ask a set a.status_int=?,a.instoreid_vchr = ? where a.seriesid_int=?";
                System.Data.IDataParameter[] objDataParams = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(3, out objDataParams);
                objDataParams[0].Value=m_intType;
                objDataParams[1].Value = p_strInstoreId;
                objDataParams[2].Value = lngSeqid;
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParams);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 入帐请领主表单据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngArr"></param>
        /// <param name="m_intType">状态值: 5-入帐  </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInAccountAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, long lngSeqid, string m_strInAccounterid,string m_strChittyid,string m_strDrugStoreid)
        {
            if (lngSeqid == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @" update t_ds_ask a set a.status_int=5,a.inaccount_dat=sysdate,a.inaccounterid_chr=?  where a.seriesid_int=?";
                System.Data.IDataParameter[] objDataParams = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDataParams);
                objDataParams[0].Value = m_strInAccounterid;
                objDataParams[1].Value = lngSeqid;
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParams);
                if (lngRes > 0)
                {
                    strSQL = @"update t_ds_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = sysdate
 where t.chittyid_vchr = ?
   and t.drugstoreid_int = ?
   and t.state_int = 2";
                    objDataParams = null;
                    objHRPServ.CreateDatabaseParameter(3, out objDataParams);
                    objDataParams[0].Value = m_strInAccounterid;
                    objDataParams[1].Value = m_strChittyid;
                    objDataParams[2].Value = m_strDrugStoreid;
                    lngAffected = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParams);
                }
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 退审请领主表单据的状态
        /// <summary>
        /// 退审请领主表单据的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnExamAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, long[] lngArr)
        {
            if (lngArr.Length == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @" update t_ds_ask a set a.status_int=? where a.seriesid_int=?";
                DbType[] dbTypes = new DbType[] { DbType.Int16, DbType.Int64 };
                object[][] objValues = new object[2][];
                int intItemCount = lngArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int iRow = 0; iRow < lngArr.Length; iRow++)
                {

                    objValues[0][iRow] = 5;

                    objValues[1][iRow] = lngArr[iRow];

                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion                      

        #region 更新请领单明细表的足量状态
        /// <summary>
        /// 更新请领单明细表的足量状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID">主表序列</param>
        /// <param name="p_hstUpdateEnough">药品号和“+=”标识</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateEnoughState(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID,Hashtable p_hstUpdateEnough)
        {
            if (p_hstUpdateEnough.Count == 0)
                return -1;
            long lngRes = 0;
            try
            {
                string strSQL = @" update t_ds_ask_detail a set a.enough_chr = ? where a.medicineid_chr = ? and a.seriesid2_int= ? ";
                DbType[] dbTypes = new DbType[] { DbType.String,DbType.String,DbType.Int64 };
                object[][] objValues = new object[3][];
                int intItemCount = p_hstUpdateEnough.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                
                IDictionaryEnumerator ie = p_hstUpdateEnough.GetEnumerator();
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    ie.MoveNext();
                    objValues[0][iRow] = ie.Value;
                    objValues[1][iRow] = ie.Key;
                    objValues[2][iRow] = p_lngSeriesID;
                    
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion   

        #region 作废请领主表单据的状态
        /// <summary>
        /// 作废请领主表单据的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBillId">单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBillId)
        {
            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;
                DataTable dtbResult = new DataTable();
                strSQL = @"select a.status_int from t_ds_ask a where a.askid_vchr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPServ.CreateDatabaseParameter(1,out objParamArr);
                objParamArr[0].Value = p_strBillId;
                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    int intStatus = 999;
                    int.TryParse(dtbResult.Rows[0][0].ToString(), out intStatus);
                    if (intStatus != 1 && intStatus != 2)//只有新制或提交状态的单据才可以作废
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        return -1;
                    }
                }
                strSQL = @" update t_ds_ask a set a.status_int= 0 where a.askid_vchr=?";
                long lngEff = -1;
                objHRPServ.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strBillId;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL,ref lngEff, objParamArr);

                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 查询请领单状态
        /// <summary>
        /// 查询请领单状态
        /// </summary>
        /// <param name="p_strSeq">请领单序列号</param>
        /// <param name="p_intQueryStyle">查询方式:0-以主表序列号查询,1-以子表序列号查询</param>
        /// <param name="p_strStatus">请领单状态</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryAskMedStatus(string p_strSeq, int p_intQueryStyle, out string p_strStatus)
        {
            long lngRes = 0;
            DataTable dtResult = null;
            p_strStatus = null;
            string strSQL = @"select a.status_int
                                  from t_ds_ask a
                                 where a.seriesid_int = (select b.seriesid2_int
                                                           from t_ds_ask_detail b
                                                          where b.seriesid_int = ?)";
            try {
                clsHRPTableService clsHrpSvc = new clsHRPTableService();
                IDataParameter[] objParams = null;
                clsHrpSvc.CreateDatabaseParameter(1, out objParams);
                objParams[0].Value = p_strSeq;

                lngRes = clsHrpSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_strStatus = dtResult.Rows[0][0].ToString();
                }

                clsHrpSvc.Dispose();
                clsHrpSvc = null;
            }
            catch (Exception objex)
            {
                com.digitalwave.Utility.clsLogText clsError = new com.digitalwave.Utility.clsLogText();
                bool blnRes = clsError.LogError(objex.ToString());
            }
            return lngRes;
        #endregion
        }
    }
}
