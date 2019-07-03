using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 仪器项目设置中间件
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled=true)]
    public class clsItemSetSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        const string strClassName = "com.digitalwave.iCare.middletier.LIS.clsItemSetSvc";

        private const string c_strAddResultImportReq = @"insert into t_opr_lis_result_import_req
  (deviceid_chr,
   import_req_int,
   device_sampleid_chr,
   check_dat,
   status_int,
   is_autobind_endpointer_int,
   recheck_flag_chr)
values
  (?, ?, ?, ?, ?, ?, ?)";

        private const string c_strAddLabResult = @"insert into t_opr_lis_result
  (idx_int,
   deviceid_chr,
   device_sampleid_chr,
   check_dat,
   device_check_item_name_vchr,
   result_vchr,
   unit_vchr,
   refrange_vchr,
   min_val_dec,
   max_val_dec,
   abnormal_flag_vchr,
   graph_img,
   graph_format_name_vchr,
   is_graph_result_num)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        private const string c_strAddLabResultLog = @"insert into t_opr_lis_result_log
  (deviceid_chr,
   device_sampleid_chr,
   check_dat,
   begin_idx_int,
   end_idx_int,
   use_flag_chr,
   import_req_int)
values
  (?, ?, ?, ?, ?, ?, ?)";

        #region 获取所有的检验项目
        /// <summary>
        /// 获取所有的检验项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDeviceModelID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngGetAllCheckItem");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.device_check_item_name_vchr, t.device_check_item_id_chr
  from t_bse_lis_device_check_item t
 where t.device_model_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDeviceModelID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objHRPSvc = null;
                objPrivilege = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取所有自定义项目的信息
        /// <summary>
        /// 获取所有自定义项目的信息
        /// </summary>
        /// <param name="p_objPrinciapl"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllCheckItemCustomInfo(System.Security.Principal.IPrincipal p_objPrinciapl, out clsLisCheckItemCustom[] p_objCheckItemCustomVO,out DataTable p_dtResult)
        {
            p_objCheckItemCustomVO = null;
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrinciapl, strClassName, "m_lngGetAllCheckItemCustomInfo");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.check_item_id_chr,
       t.check_item_name_vchr,
       t.pos_maxvalue_vchr,
       t.pos_minvalue_vchr,
       t.neg_maxvalue_vchr,
       t.neg_minvalue_vchr,
       t.check_item_color_vchr,
       t.check_item_formula_vchr,
       t.seq_chr,
       t.qcfromula_vchr,
       t.qc_neg_maxvalue_vchr,
       t.qc_neg_minvalue_vchr,
       t.qc_pos_maxvalue_vchr,
       t.qc_pos_minvalue_vchr,
       t.qc_result_vchr,
       t.more_neg_formula_vchr,
       t.more_pos_formula_vchr,
       t.qc_neg_formula_vchr,
       t.qc_pos_formula_vchr
  from t_bse_lis_check_item_custom t
 order by t.seq_chr asc
";
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                if (lngRes > 0 && p_dtResult != null && p_dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    p_objCheckItemCustomVO = new clsLisCheckItemCustom[p_dtResult.Rows.Count];
                    for (int i = 0; i < p_dtResult.Rows.Count; i++)
                    {
                        drTemp = p_dtResult.Rows[i];
                        p_objCheckItemCustomVO[i] = new clsLisCheckItemCustom();
                        p_objCheckItemCustomVO[i].m_strCheckItemID = drTemp["check_item_id_chr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strCheckItemName = drTemp["check_item_name_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strPosMaxValue = drTemp["pos_maxvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strPosMinValue = drTemp["pos_minvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strNegMaxValue = drTemp["neg_maxvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strNegMinValue = drTemp["neg_minvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strColor = drTemp["check_item_color_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strformula = drTemp["check_item_formula_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strSeq_chr = drTemp["seq_chr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQCFormula_vchr = drTemp["qcfromula_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Neg_Maxvalue_vchr = drTemp["qc_neg_maxvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Neg_Minvalue_vchr = drTemp["qc_neg_minvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Pos_Maxvalue_vchr = drTemp["qc_pos_maxvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Pos_Minvalue_vchr = drTemp["qc_pos_minvalue_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Result_vchr = drTemp["qc_result_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strMore_Neg_Formula_vchr = drTemp["more_neg_formula_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strMore_Pos_Formula_vchr = drTemp["more_pos_formula_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Neg_Formula_vchr = drTemp["qc_neg_formula_vchr"].ToString().Trim();
                        p_objCheckItemCustomVO[i].m_strQc_Pos_Formula_vchr = drTemp["qc_pos_formula_vchr"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objPrivilege = null;
                strSQL = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 修改自定义项目
        /// <summary>
        /// 修改自定义项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckItemCustomVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateCheckItemCustom(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckItemCustom p_objCheckItemCustomVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngUpdateCheckItemCustom");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"update t_bse_lis_check_item_custom t
   set t.check_item_name_vchr    = ?,
       t.pos_maxvalue_vchr       = ?,
       t.pos_minvalue_vchr       = ?,
       t.neg_maxvalue_vchr       = ?,
       t.neg_minvalue_vchr       = ?,
       t.check_item_color_vchr   = ?,
       t.check_item_formula_vchr = ?,
       t.seq_chr                 = ?,
       t.qcfromula_vchr          = ?,
       t.qc_neg_maxvalue_vchr    = ?,
       t.qc_neg_minvalue_vchr    = ?,
       t.qc_pos_maxvalue_vchr    = ?,
       t.qc_pos_minvalue_vchr    = ?,
       t.qc_result_vchr          = ?,
       t.more_neg_formula_vchr   = ?,
       t.more_pos_formula_vchr   = ?,
       t.qc_neg_formula_vchr     = ?,
       t.qc_pos_formula_vchr     = ?
 where t.check_item_id_chr = ?
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(19, out objDPArr);
                objDPArr[0].Value = p_objCheckItemCustomVO.m_strCheckItemName;
                objDPArr[1].Value = p_objCheckItemCustomVO.m_strPosMaxValue;
                objDPArr[2].Value = p_objCheckItemCustomVO.m_strPosMinValue;
                objDPArr[3].Value = p_objCheckItemCustomVO.m_strNegMaxValue;
                objDPArr[4].Value = p_objCheckItemCustomVO.m_strNegMinValue;
                objDPArr[5].Value = p_objCheckItemCustomVO.m_strColor;
                objDPArr[6].Value = p_objCheckItemCustomVO.m_strformula;
                objDPArr[7].Value = p_objCheckItemCustomVO.m_strSeq_chr;
                objDPArr[8].Value = p_objCheckItemCustomVO.m_strQCFormula_vchr;
                objDPArr[9].Value = p_objCheckItemCustomVO.m_strQc_Neg_Maxvalue_vchr;
                objDPArr[10].Value = p_objCheckItemCustomVO.m_strQc_Neg_Minvalue_vchr;
                objDPArr[11].Value = p_objCheckItemCustomVO.m_strQc_Pos_Maxvalue_vchr;
                objDPArr[12].Value = p_objCheckItemCustomVO.m_strQc_Pos_Minvalue_vchr;
                objDPArr[13].Value = p_objCheckItemCustomVO.m_strQc_Result_vchr;
                objDPArr[14].Value = p_objCheckItemCustomVO.m_strMore_Neg_Formula_vchr;
                objDPArr[15].Value = p_objCheckItemCustomVO.m_strMore_Pos_Formula_vchr;
                objDPArr[16].Value = p_objCheckItemCustomVO.m_strQc_Neg_Formula_vchr;
                objDPArr[17].Value = p_objCheckItemCustomVO.m_strQc_Pos_Formula_vchr;
                objDPArr[18].Value = p_objCheckItemCustomVO.m_strCheckItemID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally 
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 删除自定义项目
        /// <summary>
        /// 删除自定义项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckItemID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelteCheckItemCustom(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckItemID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngDelteCheckItemCustom");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"delete from t_bse_lis_check_item_custom t where t.check_item_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckItemID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 添加自定义项目
        /// <summary>
        /// 添加自定义项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckItemCustomVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertCheckItemCustom(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckItemCustom p_objCheckItemCustomVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngInsertCheckItemCustom");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"insert into t_bse_lis_check_item_custom
  (check_item_id_chr,
   check_item_name_vchr,
   pos_maxvalue_vchr,
   pos_minvalue_vchr,
   neg_maxvalue_vchr,
   neg_minvalue_vchr,
   check_item_color_vchr,
   check_item_formula_vchr,
   seq_chr,
   qcfromula_vchr,
   qc_neg_maxvalue_vchr,
   qc_neg_minvalue_vchr,
   qc_pos_maxvalue_vchr,
   qc_pos_minvalue_vchr,
   qc_result_vchr,
   more_neg_formula_vchr,
   more_pos_formula_vchr,
   qc_neg_formula_vchr,
   qc_pos_formula_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(19, out objDPArr);
                objDPArr[0].Value = p_objCheckItemCustomVO.m_strCheckItemID;
                objDPArr[1].Value = p_objCheckItemCustomVO.m_strCheckItemName;
                objDPArr[2].Value = p_objCheckItemCustomVO.m_strPosMaxValue;
                objDPArr[3].Value = p_objCheckItemCustomVO.m_strPosMinValue;
                objDPArr[4].Value = p_objCheckItemCustomVO.m_strNegMaxValue;
                objDPArr[5].Value = p_objCheckItemCustomVO.m_strNegMinValue;
                objDPArr[6].Value = p_objCheckItemCustomVO.m_strColor;
                objDPArr[7].Value = p_objCheckItemCustomVO.m_strformula;
                objDPArr[8].Value = p_objCheckItemCustomVO.m_strSeq_chr;
                objDPArr[9].Value = p_objCheckItemCustomVO.m_strQCFormula_vchr;
                objDPArr[10].Value = p_objCheckItemCustomVO.m_strQc_Neg_Maxvalue_vchr;
                objDPArr[11].Value = p_objCheckItemCustomVO.m_strQc_Neg_Minvalue_vchr;
                objDPArr[12].Value = p_objCheckItemCustomVO.m_strQc_Pos_Maxvalue_vchr;
                objDPArr[13].Value = p_objCheckItemCustomVO.m_strQc_Pos_Minvalue_vchr;
                objDPArr[14].Value = p_objCheckItemCustomVO.m_strQc_Result_vchr;
                objDPArr[15].Value = p_objCheckItemCustomVO.m_strMore_Neg_Formula_vchr;
                objDPArr[16].Value = p_objCheckItemCustomVO.m_strMore_Pos_Formula_vchr;
                objDPArr[17].Value = p_objCheckItemCustomVO.m_strQc_Neg_Formula_vchr;
                objDPArr[18].Value = p_objCheckItemCustomVO.m_strQc_Pos_Formula_vchr;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        

        #region 获取自定义项目的结果判断
        /// <summary>
        /// 获取自定义项目的结果判断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objCheckItemCustomRes"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryCheckItemCustomRes(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckItemID, out clsLisCheckItemCustomRes[] p_objCheckItemCustomRes)
        {
            long lngRes = 0;
            p_objCheckItemCustomRes = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngQueryCheckItemCustomRes");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.seq_int, t.conditions_vchr, t.result_vchr
  from t_bse_lis_check_item_customres t
 where t.check_item_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckItemID;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    p_objCheckItemCustomRes = new clsLisCheckItemCustomRes[dtResult.Rows.Count];
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        drTemp = dtResult.Rows[i];
                        p_objCheckItemCustomRes[i] = new clsLisCheckItemCustomRes();
                        p_objCheckItemCustomRes[i].m_strSeq = drTemp["seq_int"].ToString().Trim();
                        p_objCheckItemCustomRes[i].m_strConditions = drTemp["conditions_vchr"].ToString().Trim();
                        p_objCheckItemCustomRes[i].m_strResult = drTemp["result_vchr"].ToString().Trim();
                        p_objCheckItemCustomRes[i].m_strCheckItemID = p_strCheckItemID;
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 添加自定义结果判断
        /// <summary>
        /// 添加自定义结果判断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckItemCustomResVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertCheckItemCustomRes(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckItemCustomRes p_objCheckItemCustomResVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngInsertCheckItemCustomRes");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"insert into t_bse_lis_check_item_customres
  (check_item_id_chr, seq_int, conditions_vchr, result_vchr)
values
  (?, ?, ?, ?)";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_objCheckItemCustomResVO.m_strCheckItemID;
                objDPArr[1].Value = Convert.ToInt32(p_objCheckItemCustomResVO.m_strSeq);
                objDPArr[2].Value = p_objCheckItemCustomResVO.m_strConditions;
                objDPArr[3].Value = p_objCheckItemCustomResVO.m_strResult;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 修改自定义结果判断
        /// <summary>
        /// 修改自定义结果判断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckItemCustomResVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateCheckItemCustomRes(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckItemCustomRes p_objCheckItemCustomResVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngUpdateCheckItemCustomRes");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"update t_bse_lis_check_item_customres t
   set t.conditions_vchr = ?, t.result_vchr = ?
 where t.check_item_id_chr = ?
   and t.seq_int = ?
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_objCheckItemCustomResVO.m_strConditions;
                objDPArr[1].Value = p_objCheckItemCustomResVO.m_strResult;
                objDPArr[2].Value = p_objCheckItemCustomResVO.m_strCheckItemID;
                objDPArr[3].Value = Convert.ToInt32(p_objCheckItemCustomResVO.m_strSeq);
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 删除自定义结果判断
        /// <summary>
        /// 删除自定义结果判断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckItemCustomResVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteCheckItemCustomRes(System.Security.Principal.IPrincipal p_objPrincipal, clsLisCheckItemCustomRes p_objCheckItemCustomResVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngDeleteCheckItemCustomRes");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"delete from t_bse_lis_check_item_customres t
 where t.check_item_id_chr = ?
   and t.seq_int = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_objCheckItemCustomResVO.m_strCheckItemID;
                objDPArr[1].Value = Convert.ToInt32(p_objCheckItemCustomResVO.m_strSeq);
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 增加检验仪器结果, 多样本
        /// <summary>
        /// 增加检验仪器结果, 多样本
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_blnMuiltySample"> TRUE = 多样本</param>
        /// <param name="p_objOutResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngAddLabResult(clsLIS_Device_Test_ResultVO[] p_objResultArr, bool p_blnMuiltySample, out clsLIS_Device_Test_ResultVO[] p_objOutResultArr)
        {
            p_objOutResultArr = null;
            long lngRes = 0;
            if (p_objResultArr == null || p_objResultArr.Length <= 0)
            {
                return lngRes;
            }

            if (p_blnMuiltySample)
            {
                List<string> lstSampleID = new List<string>();
                List<clsLIS_Device_Test_ResultVO> lstResult = new List<clsLIS_Device_Test_ResultVO>();
                List<clsLIS_Device_Test_ResultVO> lstOutResult = new List<clsLIS_Device_Test_ResultVO>();

                string strSampleID = "";
                string strSampleIDTemp = null;
                int idx = 0;
                for (idx = 0; idx < p_objResultArr.Length; idx++)
                {
                    strSampleID = p_objResultArr[idx].strDevice_Sample_ID;
                    if (strSampleID != strSampleIDTemp)
                    {
                        if (!lstSampleID.Contains(strSampleID))
                        {
                            lstSampleID.Add(strSampleID);
                        }
                        strSampleIDTemp = strSampleID;
                    }
                }

                clsLIS_Device_Test_ResultVO[] objResultTempArr = null;
                foreach (string str in lstSampleID)
                {
                    lstResult.Clear();
                    for (idx = 0; idx < p_objResultArr.Length; idx++)
                    {
                        if (str == p_objResultArr[idx].strDevice_Sample_ID)
                        {
                            lstResult.Add(p_objResultArr[idx]);

                        }
                    }
                    if (lstResult.Count > 0)
                    {
                        lngRes = lngAddLabResult(lstResult.ToArray(), out objResultTempArr);
                        if (lngRes > 0 && objResultTempArr != null && objResultTempArr.Length > 0)
                        {
                            lstOutResult.AddRange(objResultTempArr);
                        }
                    }
                }
                p_objOutResultArr = lstOutResult.ToArray();
            }
            else
            {
                lngRes = lngAddLabResult(p_objResultArr, out p_objOutResultArr);
            }

            return lngRes;
        }
        #endregion

        #region 增加检验仪器结果
        [AutoComplete]
        public long lngAddLabResult(clsLIS_Device_Test_ResultVO[] p_objResultArr, out clsLIS_Device_Test_ResultVO[] p_objOutResultArr)
        {
            p_objOutResultArr = null;
            System.Collections.Hashtable has = new System.Collections.Hashtable();
            if (p_objResultArr == null || p_objResultArr.Length <= 0)
            {
                return -1;
            }
            //<-------------------------------------------------------- 
            else
            {
                foreach (clsLIS_Device_Test_ResultVO objRes in p_objResultArr)
                {
                    has.Add(objRes.strDevice_Check_Item_Name, objRes.strResult);
                }
            }
            //--------------------------------------------------------------------------------------->

            long lngRes = 1;
            long lngRecEff = -1;
            string strSQL = null;

            #region 判断是追加结果还是新增一次结果 用于Stago、CentaurCP等仪器
            /* 原理：获取上次取得该样本结果的最大序列
               根据序列，仪器和标本号查找log表得起始值
               找到结果进行结果校对哈希比较，如果不一致立即跳过进行原操作
               否则追加插入结果，修改req日期.log起始值和日期 */
            //<--------------------------------------------------------  
            string[] strConditionList = null; //当blnFlag为false时有值
            bool blnFlag = this.m_blnIsAppendResult(ref has, p_objResultArr, out strConditionList);
            //--------------------------------------------------------------------------------------->
            #endregion

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                clsLIS_Device_Test_ResultVO[] objResultList = p_objResultArr;


                DateTime dtmNow = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime dtmCheck = dtmNow;
                string strCheckDateTime = null;
                #region 检验时间
                if (objResultList[0].strCheck_Date != null)
                    objResultList[0].strCheck_Date = objResultList[0].strCheck_Date.Trim();

                if (Microsoft.VisualBasic.Information.IsDate(objResultList[0].strCheck_Date))
                {
                    dtmCheck = System.DateTime.Parse(objResultList[0].strCheck_Date);
                }
                strCheckDateTime = dtmCheck.ToString("yyyy-MM-dd HH:mm:ss");
                dtmCheck = Convert.ToDateTime(strCheckDateTime);
                #endregion
                string strDid = objResultList[0].strDevice_ID.Trim();
                string strSid = objResultList[0].strDevice_Sample_ID.Trim();
                clsLogText objLogger = new clsLogText();

                int intImportReq = -1;
                if (blnFlag)
                {
                    objLogger.Log2File("D:\\logData.txt", "结果新增");
                    if (lngRes == 1)
                    {
                        #region 得到仪器样本的采集序号
                        DataTable dtbReq = null;
                        strSQL = @"select max(import_req_int) + 1 as import_req_int
  from t_opr_lis_result_import_req
 where deviceid_chr = ?
 group by deviceid_chr";

                        System.Data.IDataParameter[] objDPArr4 = null;
                        objHRPSvc.CreateDatabaseParameter(1, out objDPArr4);
                        objDPArr4[0].Value = objResultList[0].strDevice_ID;

                        lngRes = 0;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbReq, objDPArr4);
                        if (lngRes == 1 && dtbReq != null && dtbReq.Rows.Count != 0)
                        {
                            intImportReq = int.Parse(dtbReq.Rows[0]["import_req_int"].ToString());
                        }
                        else if (lngRes == 1)
                        {
                            intImportReq = 0;
                        }
                        else
                        {
                            lngRes = 0;
                        }
                        #endregion
                    }
                    if (lngRes == 1)
                    {
                        #region 写 t_opr_lis_result_import_req 表
                        System.Data.IDataParameter[] objDPArr5 = null;
                        objHRPSvc.CreateDatabaseParameter(7, out objDPArr5);
                        objDPArr5[0].Value = strDid;
                        objDPArr5[1].Value = intImportReq;
                        objDPArr5[2].Value = strSid;
                        objDPArr5[3].DbType = DbType.DateTime;
                        objDPArr5[3].Value = Convert.ToDateTime(strCheckDateTime);
                        objDPArr5[4].Value = 1;
                        objDPArr5[5].Value = 0;
                        objDPArr5[6].Value = "0";
                        lngRes = 0;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(c_strAddResultImportReq, ref lngRecEff, objDPArr5);
                        #endregion
                    }
                    if (lngRes == 1)
                    {
                        int intIdx = m_mthGetNewResultIndex(objResultList.Length, false) + 1;
                        int intBEGIN_IDX_INT = intIdx;
                        int intEND_IDX_INT = intBEGIN_IDX_INT + objResultList.Length - 1;

                        #region 写 t_opr_lis_result 表
                        DbType[] m_dbType = new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.DateTime,
                            DbType.String, DbType.String, DbType.String, DbType.String,
                            DbType.Double, DbType.Double, DbType.String, DbType.Byte,
                            DbType.String, DbType.Int32 };

                        object[][] objValues = new object[14][];
                        for (int i = 0; i < objValues.Length; i++)
                        {
                            objValues[i] = new object[objResultList.Length];
                        }
                        clsLIS_Device_Test_ResultVO objResultTemp = null;
                        for (int iRow = 0; iRow < objResultList.Length; iRow++)
                        {
                            objResultTemp = objResultList[iRow];
                            objResultTemp.intIndex = intIdx++;

                            objValues[0][iRow] = objResultTemp.intIndex;
                            objValues[1][iRow] = strDid;
                            objValues[2][iRow] = strSid;

                            objResultTemp.strCheck_Date = strCheckDateTime;
                            objValues[3][iRow] = Convert.ToDateTime(strCheckDateTime);
                            objValues[4][iRow] = objResultTemp.strDevice_Check_Item_Name;

                            objValues[5][iRow] = objResultTemp.strResult;
                            objValues[6][iRow] = objResultTemp.strUnit;
                            objValues[7][iRow] = objResultTemp.strRefRange;

                            if (objResultTemp.strMinVal != null)
                            {
                                if (Microsoft.VisualBasic.Information.IsNumeric(objResultTemp.strMinVal.Trim()))
                                {
                                    objValues[8][iRow] = double.Parse(objResultTemp.strMinVal.Trim());
                                }
                            }
                            if (objResultTemp.strMaxVal != null)
                            {
                                if (Microsoft.VisualBasic.Information.IsNumeric(objResultTemp.strMaxVal.Trim()))
                                {
                                    objValues[9][iRow] = double.Parse(objResultTemp.strMaxVal.Trim());
                                }
                            }

                            objValues[10][iRow] = objResultTemp.strAbnormal_Flag;
                            objValues[11][iRow] = objResultTemp.bytGraph;
                            objValues[12][iRow] = objResultTemp.strGraphFormatName;
                            objValues[13][iRow] = objResultTemp.intIsGraphResult;
                        }
                        lngRes = 0;
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(c_strAddLabResult, objValues, m_dbType);

                        #endregion

                        if (lngRes == 1)
                        {
                            #region 写 t_opr_lis_result_log 表

                            System.Data.IDataParameter[] objDPArr1 = null;
                            objHRPSvc.CreateDatabaseParameter(7, out objDPArr1);
                            objDPArr1[0].Value = strDid;
                            objDPArr1[1].Value = strSid;
                            objDPArr1[2].DbType = DbType.DateTime;
                            objDPArr1[2].Value = Convert.ToDateTime(strCheckDateTime);
                            objDPArr1[3].Value = intBEGIN_IDX_INT;
                            objDPArr1[4].Value = intEND_IDX_INT;
                            objDPArr1[5].Value = "1";
                            objDPArr1[6].Value = intImportReq;

                            lngRes = 0;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(c_strAddLabResultLog, ref lngRecEff, objDPArr1);

                            #endregion
                        }
                    }
                }
                else //追加结果AppendResult
                {
                    objLogger.Log2File("D:\\logData.txt", "结果追加");

                    #region 写 t_opr_lis_result 表
                    strCheckDateTime = strConditionList[3].Trim();
                    dtmCheck = Convert.ToDateTime(strCheckDateTime);
                    intImportReq = Convert.ToInt32(strConditionList[2]);
                    int intIdx = m_mthGetNewResultIndex(objResultList.Length, false) + 1;
                    int intBEGIN_IDX_INT = intIdx;
                    int intEND_IDX_INT = intBEGIN_IDX_INT + objResultList.Length - 1;


                    DbType[] m_dbType1 = new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.DateTime,
                            DbType.String, DbType.String, DbType.String, DbType.String,
                            DbType.Double, DbType.Double, DbType.String, DbType.Byte,
                            DbType.String, DbType.Int32 };

                    object[][] objValues1 = new object[14][];
                    for (int i = 0; i < objValues1.Length; i++)
                    {
                        objValues1[i] = new object[objResultList.Length];
                    }
                    clsLIS_Device_Test_ResultVO objResultTemp = null;
                    for (int iRow = 0; iRow < objResultList.Length; iRow++)
                    {
                        objResultTemp = objResultList[iRow];
                        objResultTemp.intIndex = intIdx++;

                        objValues1[0][iRow] = objResultTemp.intIndex;
                        objValues1[1][iRow] = strDid;
                        objValues1[2][iRow] = strSid;

                        objResultTemp.strCheck_Date = strCheckDateTime;
                        objValues1[3][iRow] = Convert.ToDateTime(strCheckDateTime);
                        objValues1[4][iRow] = objResultTemp.strDevice_Check_Item_Name;

                        objValues1[5][iRow] = objResultTemp.strResult;
                        objValues1[6][iRow] = objResultTemp.strUnit;
                        objValues1[7][iRow] = objResultTemp.strRefRange;

                        if (objResultTemp.strMinVal != null)
                        {
                            if (Microsoft.VisualBasic.Information.IsNumeric(objResultTemp.strMinVal.Trim()))
                            {
                                objValues1[8][iRow] = double.Parse(objResultTemp.strMinVal.Trim());
                            }
                        }
                        if (objResultTemp.strMaxVal != null)
                        {
                            if (Microsoft.VisualBasic.Information.IsNumeric(objResultTemp.strMaxVal.Trim()))
                            {
                                objValues1[9][iRow] = double.Parse(objResultTemp.strMaxVal.Trim());
                            }
                        }

                        objValues1[10][iRow] = objResultTemp.strAbnormal_Flag;
                        objValues1[11][iRow] = objResultTemp.bytGraph;
                        objValues1[12][iRow] = objResultTemp.strGraphFormatName;
                        objValues1[13][iRow] = objResultTemp.intIsGraphResult;
                    }
                    lngRes = 0;
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(c_strAddLabResult, objValues1, m_dbType1);

                    #endregion

                    if (lngRes == 1)
                    {
                        #region 更新 t_opr_lis_result_log 表
                        strSQL = @"update t_opr_lis_result_log
   set end_idx_int = ?
 where deviceid_chr = ?
   and trim(device_sampleid_chr) = ?
   and check_dat = ?
   and import_req_int = ?";

                        System.Data.IDataParameter[] objDPArr1 = null;
                        objHRPSvc.CreateDatabaseParameter(5, out objDPArr1);
                        objDPArr1[0].Value = intEND_IDX_INT;
                        objDPArr1[1].Value = strConditionList[1]; //仪器ID
                        objDPArr1[2].Value = strConditionList[0]; //仪器样本ID
                        objDPArr1[3].DbType = DbType.DateTime;
                        objDPArr1[3].Value = Convert.ToDateTime(strConditionList[3]); //检验日期
                        objDPArr1[4].Value = Convert.ToInt32(strConditionList[2]); //系统内部结果序列

                        lngRes = 0;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objDPArr1);
                        if (lngRecEff < 1)
                        {
                            System.EnterpriseServices.ContextUtil.SetAbort();
                        }
                        #endregion
                    }
                }
                System.Data.DataTable dtbRelation = null;
                if (lngRes == 1)//无论此步骤成功与否都不应影响原始数据的进入.
                {
                    #region  查找核收表（t_opr_lis_device_relation）表中要做关联的记录

                    strSQL = @"select deviceid_chr, seq_id_device_chr, sample_id_chr
  from t_opr_lis_device_relation
 where status_int = 1
   and deviceid_chr = ?
   and trim(device_sampleid_chr) = ?
   and check_dat between ? and ?";

                    System.Data.IDataParameter[] objDPArrs3 = null;
                    objHRPSvc.CreateDatabaseParameter(4, out objDPArrs3);
                    objDPArrs3[0].Value = strDid;
                    objDPArrs3[1].Value = strSid;
                    objDPArrs3[2].DbType = DbType.DateTime;
                    objDPArrs3[2].Value = (Convert.ToDateTime(strCheckDateTime)).Date;
                    objDPArrs3[3].DbType = DbType.DateTime;
                    objDPArrs3[3].Value = (Convert.ToDateTime(strCheckDateTime)).Date.AddHours(24);

                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbRelation, objDPArrs3);

                    #endregion
                    if (lngRes == 1)
                    {
                        #region 更新 t_opr_lis_device_relation 表

                        if (dtbRelation != null && dtbRelation.Rows.Count != 0)
                        {
                            string strSeq = dtbRelation.Rows[0]["seq_id_device_chr"].ToString().Trim();

                            strSQL = @"update t_opr_lis_device_relation
   set device_sampleid_chr = ?,
       check_dat           = ?,
       import_req_int      = ?,
       status_int          = 2
 where trim(seq_id_device_chr) = ?
   and trim(deviceid_chr) = ?";

                            System.Data.IDataParameter[] objDPArrs2 = null;
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArrs2);
                            objDPArrs2[0].Value = strSid;
                            objDPArrs2[1].DbType = DbType.DateTime;
                            objDPArrs2[1].Value = Convert.ToDateTime(strCheckDateTime);
                            objDPArrs2[2].Value = intImportReq;
                            objDPArrs2[3].Value = strSeq.Trim();
                            objDPArrs2[4].Value = strDid.Trim();

                            lngRecEff = 0;
                            lngRes = 0;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objDPArrs2);

                        }
                        #endregion
                    }
                }
            }
            catch (System.Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            if (lngRes <= 0)
            {
                ContextUtil.SetAbort();
            }
            p_objOutResultArr = p_objResultArr;
            return lngRes;
        }
        #endregion

        [AutoComplete]
        public int m_mthGetNewResultIndex(int p_intRowNum, bool p_blnNext)
        {
            string strSQL_Update = @"update t_aid_table_sequence_id
   set max_sequence_id_chr = to_number(max_sequence_id_chr) + " + p_intRowNum + @"
 where table_name_vchr = 't_opr_lis_result'
   and col_name_vchr = 'idx_int'";

            string strSQL_Get = @"select max_sequence_id_chr
  from t_aid_table_sequence_id
 where lower(trim(table_name_vchr)) = 't_opr_lis_result'
   and lower(trim(col_name_vchr)) = 'idx_int'";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = null;
            long lngRes = 0;
            try
            {
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL_Update);
                if (lngRes == 1)
                {
                    DataTable dtbResult = null;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL_Get, ref dtbResult);
                    objHRPSvc.Dispose();
                    if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        string strMaxID = dtbResult.Rows[0]["max_sequence_id_chr"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsNumeric(strMaxID))
                        {
                            if (p_blnNext)
                            {
                                return (int.Parse(strMaxID) - p_intRowNum + 1);
                            }
                            else
                            {
                                return (int.Parse(strMaxID) - p_intRowNum);
                            }
                        }
                    }
                }
            }
            finally
            {
                objHRPSvc = null;
            }
            throw new Exception("Can not generate new MaxID.");
            //			return -1;
        }

        [AutoComplete]
        public bool m_blnIsAppendResult(ref System.Collections.Hashtable has, clsLIS_Device_Test_ResultVO[] p_objResultArr, out string[] strConditionList)
        {
            long lngRes = 1;
            string strSQL = null;
            strConditionList = null;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            #region 判断是追加结果还是新增一次结果 用于Stago、CentaurCP等仪器
            /* 原理：获取上次取得该样本结果的最大序列
               根据序列，仪器和标本号查找log表得起始值
               找到结果进行结果校对哈希比较，如果不一致立即跳过进行原操作
               否则追加插入结果，修改req日期.log起始值和日期 */

            bool blnFlag = true;  //true-新增  false-追加
            try
            {
                DataTable dtbTmp = new DataTable();
                clsLIS_Device_Test_ResultVO objTmp = p_objResultArr[0];
                string m_strSID = objTmp.strDevice_Sample_ID;
                string m_strDevID = objTmp.strDevice_ID;
                string m_strDateBegin = DateTime.Now.ToShortDateString() + " 00:00:00";
                string m_strDateEnd = DateTime.Now.ToShortDateString() + " 23:59:59";

                strSQL = @"select a.check_dat, a.device_sampleid_chr, a.deviceid_chr, a.import_req_int
  from t_opr_lis_result_import_req a
 where a.check_dat between ? and ?
   and a.deviceid_chr = ?
   and trim(a.device_sampleid_chr) = ?
 order by a.import_req_int desc";

                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].DbType = DbType.DateTime;
                objParamArr[0].Value = Convert.ToDateTime(m_strDateBegin);
                objParamArr[1].DbType = DbType.DateTime;
                objParamArr[1].Value = Convert.ToDateTime(m_strDateEnd);
                objParamArr[2].Value = m_strDevID;
                objParamArr[3].Value = m_strSID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTmp, objParamArr);
                if (lngRes > 0 && dtbTmp.Rows.Count > 0)
                {
                    Int32 m_intImport_Req = 0;
                    string m_strCheckDate_req = "";
                    m_strCheckDate_req = Convert.ToDateTime(dtbTmp.Rows[0]["check_dat"]).ToString("yyyy-MM-dd HH:mm:ss");
                    m_intImport_Req = Convert.ToInt32(dtbTmp.Rows[0]["import_req_int"]);

                    strSQL = @"select a.begin_idx_int,
       a.check_dat,
       a.device_sampleid_chr,
       a.import_req_int,
       a.end_idx_int,
       a.deviceid_chr,
       a.use_flag_chr
  from t_opr_lis_result_log a
 where a.check_dat = ?
   and a.import_req_int = ?
   and a.deviceid_chr = ?";

                    objParamArr = null;
                    dtbTmp = null;
                    objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                    objParamArr[0].DbType = DbType.DateTime;
                    objParamArr[0].Value = Convert.ToDateTime(m_strCheckDate_req);
                    objParamArr[1].Value = m_intImport_Req;
                    objParamArr[2].Value = m_strDevID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTmp, objParamArr);
                    if (lngRes > 0 && dtbTmp.Rows.Count > 0)
                    {
                        Int64 intIdxBegin = Convert.ToInt64(dtbTmp.Rows[0]["begin_idx_int"]);
                        Int64 intIdxEnd = Convert.ToInt64(dtbTmp.Rows[0]["end_idx_int"]);
                        strSQL = @"select idx_int, result_vchr, device_check_item_name_vchr
  from t_opr_lis_result
 where deviceid_chr = ?
   and trim(device_sampleid_chr) = ?
   and check_dat = ?
   and idx_int >= ?
   and idx_int <= ?";
                        objParamArr = null;
                        objTmp = null;
                        objHRPSvc.CreateDatabaseParameter(5, out objParamArr);
                        objParamArr[0].Value = m_strDevID;
                        objParamArr[1].Value = m_strSID;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = Convert.ToDateTime(m_strCheckDate_req);
                        objParamArr[3].Value = intIdxBegin;
                        objParamArr[4].Value = intIdxEnd;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTmp, objParamArr);
                        objHRPSvc.Dispose();
                        if (lngRes > 0 && dtbTmp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtbTmp.Rows)
                            {
                                if (has.ContainsKey(dr["device_check_item_name_vchr"]))
                                {
                                }
                                else
                                {
                                    strConditionList = new string[4];
                                    strConditionList[0] = m_strSID; //仪器样本ID
                                    strConditionList[1] = m_strDevID; //仪器ID
                                    strConditionList[2] = m_intImport_Req.ToString(); //系统内部结果序列
                                    strConditionList[3] = m_strCheckDate_req; //检验日期
                                    blnFlag = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return blnFlag;

            #endregion
        }

        #region 获取仪器项目名称
        /// <summary>
        /// 获取仪器项目名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDevicModelID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryDevceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDevicModelID,out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngQueryDevceCheckItem");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.device_check_item_name_vchr, t1.check_item_id_chr
  from t_bse_lis_device_check_item t, t_bse_lis_check_item_dev_item t1
 where t.device_model_id_chr = t1.device_model_id_chr
   and t.device_check_item_id_chr = t1.device_check_item_id_chr
   and t.device_model_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDevicModelID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取布局名称和布局信息
        /// <summary>
        /// 获取布局名称和布局信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllItemLayout(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult,out DataTable p_dtLayoutInfo)
        {
            p_dtLayoutInfo = null;
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngGetAllItemLayout");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.layoutname_vchr from t_opr_lis_item_layout t group by t.layoutname_vchr";
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                if (lngRes > 0 && p_dtResult != null && p_dtResult.Rows.Count > 0)
                {
                    strSQL = @"select t.layoutname_vchr,
       t.controlidx_chr,
       t.checkitemname_vchr,
       t.sampleid_vchr,
       t.sampletype_chr,
       t.check_item_id_chr
      
  from t_opr_lis_item_layout t
";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtLayoutInfo);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 插入新的布局
        /// <summary>
        /// 插入新的布局
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisItemLayoutVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddItemLayout(System.Security.Principal.IPrincipal p_objPrincipal, clslisItemLayout[] p_objLisItemLayoutVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngAddItemLayout");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            DbType[] m_dbType = new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            object[][] objValues = new object[7][];
            for (int i = 0; i < objValues.Length; i++)
            {
                objValues[i] = new object[p_objLisItemLayoutVO.Length];
            }
            string strSEQ = null;
            try
            {
                strSQL = @"insert into t_opr_lis_item_layout
  (seq_int,
   layoutname_vchr,
   controlidx_chr,
   checkitemname_vchr,
   sampleid_vchr,
   sampletype_chr,
   check_item_id_chr)
values
  (?, ?, ?, ?, ?, ?, ?)";
                strSEQ = @"seq_lis_Layout";
                objHRPSvc = new clsHRPTableService();
                int intSeq;
                for (int i = 0; i < p_objLisItemLayoutVO.Length; i++)
                {
                    lngRes = objHRPSvc.m_lngGetSequences(strSEQ, out intSeq);
                    objValues[0][i] = intSeq;
                    objValues[1][i] = p_objLisItemLayoutVO[i].m_strLayoutname_vchr;
                    objValues[2][i] = p_objLisItemLayoutVO[i].m_strControlidx_chr;
                    objValues[3][i] = p_objLisItemLayoutVO[i].m_strCheckitemname_vchr;
                    objValues[4][i] = p_objLisItemLayoutVO[i].m_strSampleid_vchr;
                    objValues[5][i] = p_objLisItemLayoutVO[i].m_strSampleType_chr;
                    objValues[6][i] = p_objLisItemLayoutVO[i].m_strCheckItemID;
                }
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, m_dbType);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSEQ = null;
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 删除布局
        /// <summary>
        /// 删除布局
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strLayoutName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteItemLayout(System.Security.Principal.IPrincipal p_objPrincipal, string p_strLayoutName)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngDeleteItemLayout");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"delete t_opr_lis_item_layout t where t.layoutname_vchr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strLayoutName;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion


        #region 根据板子结果名称查询相关板子结果名称
        /// <summary>
        /// 根据板子结果名称查询相关板子结果名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPlateName"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryPlateName(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPlateName,string p_strStartDate,string p_strEndDate, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngQueryPlateResult");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.plate_name_id_chr, t.plate_name_vchr, t.plate_date,t.plate_chaname_vchr
  from t_opr_lis_plate_name t
 where t.plate_date between ? and ?
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                if (string.IsNullOrEmpty(p_strPlateName))
                {
                    objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = DateTime.Parse(p_strStartDate);
                    objDPArr[1].Value = DateTime.Parse(p_strEndDate);
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = DateTime.Parse(p_strStartDate);
                    objDPArr[1].Value = DateTime.Parse(p_strEndDate);
                    objDPArr[2].Value = p_strPlateName;
                    strSQL = strSQL + "and t.plate_name_vchr = ?";
                }
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 根据板子名称ID查询板子结果
        /// <summary>
        /// 根据板子名称ID查询板子结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPlateNameID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryPlateResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPlateNameID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngQueryPlateResult");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.plate_result_id_vchr,
       t.plate_name_id_chr,
       t.check_item_id,
       t.controlidx_chr,
       t.checkitemname_vchr,
       t.sampleid_vchr,
       t.sampletype_chr,
       t.sample_result_vchr,
       t.sample_result_2_vchr,
       t.sample_result_sc_vchr,
       t.sample_result_cutoff_vchr,
       t.sample_result_contrastnc_vchr,
       t.sample_result_contrastpc_vchr
  from t_opr_lis_plate_result t
 where t.plate_name_id_chr = ?";   //  修改查询语句
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strPlateNameID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 插入板子布局结果
        /// <summary>
        /// 插入板子布局结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPlateName"></param>
        /// <param name="p_objPlateResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertPlateResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPlateName,string p_strPlateChName,
            clslisPlateResult[] p_objPlateResultArr,out string p_strPlateResultID)
        {
            p_strPlateResultID = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngInsertPlateResult");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            DbType[] m_dbType = new DbType[] {DbType.String,DbType.String,DbType.String,DbType.String,
                DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                DbType.String,DbType.String};
            object[][] objValues = new object[13][];  //修改查询语句参数个数
            for (int i = 0; i < objValues.Length; i++)
            {
                objValues[i] = new object[p_objPlateResultArr.Length];
            }
            int idxSeq;
            string strResultSeq = null;
            try
            {
                strSQL = @"insert into t_opr_lis_plate_name
  (plate_name_id_chr, plate_name_vchr, plate_date,plate_chaname_vchr)
values
  (?, ?, ?,?) 
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngGetSequences("seq_lis_plate_name", out idxSeq);
                p_strPlateResultID = idxSeq.ToString();
                p_strPlateResultID = p_strPlateResultID.PadLeft(6, '0');
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strPlateResultID;
                objDPArr[1].Value = p_strPlateName;
                objDPArr[2].Value = DateTime.Now;
                objDPArr[3].Value = p_strPlateChName;   
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngRes > 0)
                {
                    strSQL = @"insert into t_opr_lis_plate_result
  (plate_result_id_vchr,
   plate_name_id_chr,
   check_item_id,
   controlidx_chr,
   checkitemname_vchr,
   sampleid_vchr,
   sampletype_chr,
   sample_result_vchr,
   sample_result_2_vchr,
   sample_result_sc_vchr,
   sample_result_cutoff_vchr,
   sample_result_contrastnc_vchr,
   sample_result_contrastpc_vchr)
values 
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?)
";                                  //修改查询语句
                    int[] intSeq = null;
                    lngRes = m_lngGetSequenceArr("seq_plate_result", p_objPlateResultArr.Length, out intSeq);

                    for (int i = 0; i < p_objPlateResultArr.Length; i++)
                    {
                        strResultSeq = intSeq[i].ToString();
                        strResultSeq = strResultSeq.PadLeft(10, '0');
                        objValues[0][i] = strResultSeq;
                        objValues[1][i] = p_strPlateResultID;
                        objValues[2][i] = p_objPlateResultArr[i].m_strCheck_Item_Id;
                        objValues[3][i] = p_objPlateResultArr[i].m_strControlidx_chr;
                        objValues[4][i] = p_objPlateResultArr[i].m_strCheckitemname_vchr;
                        objValues[5][i] = p_objPlateResultArr[i].m_strSampleid_vchr;
                        objValues[6][i] = p_objPlateResultArr[i].m_strSampletype_chr;
                        objValues[7][i] = p_objPlateResultArr[i].m_strSample_Result_vchr;
                        objValues[8][i] = p_objPlateResultArr[i].m_strSample_Result_2_vchr;
                        objValues[9][i] = p_objPlateResultArr[i].m_strSameple_Result_sc_vchr;  
                        objValues[10][i] = p_objPlateResultArr[i].m_strSameple_Result_strCutoff_vchr;   
                        objValues[11][i] = p_objPlateResultArr[i].m_strSameple_Result_ContrastNC_vchr;  
                        objValues[12][i] = p_objPlateResultArr[i].m_strSameple_Result_ContrastPC_vchr;  
                    }
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, m_dbType);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strResultSeq = null;
                m_dbType = null;
                objValues = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取多个序列号
        /// <summary>
        /// 获取多个序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeqName">序列名</param>
        /// <param name="p_intNumber">数量</param>
        /// <param name="p_lngSeqIdArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSequenceArr(string p_strSeqName, int p_intNumber, out int[] p_intSeqIdArr)
        {
            p_intSeqIdArr = null;
            long lngRes = 0;
            if (p_intNumber <= 0 || string.IsNullOrEmpty(p_strSeqName))
            {
                return lngRes;
            }

            try
            {
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select getseq(?,?) from dual";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    DataTable dtValue = null;

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);

                    objDPArr[0].Value = p_strSeqName;
                    objDPArr[1].Value = p_intNumber;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objDPArr);
                    if (lngRes > 0 && dtValue != null && dtValue.Rows.Count == 1)
                    {
                        p_intSeqIdArr = new int[p_intNumber];
                        int m_intSeqId = Convert.ToInt32(dtValue.Rows[0][0]);
                        for (int index = p_intNumber - 1; index >= 0; index--)
                        {
                            p_intSeqIdArr[index] = m_intSeqId--;
                        }
                    }
                    else
                    {
                        p_intSeqIdArr = new int[1];
                        p_intSeqIdArr[0] = 1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }

        #endregion

        #region 删除板子结果
        /// <summary>
        /// 删除板子结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPlateNameID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeletePlateResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPlateNameID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngDeletePlateResult");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"delete t_opr_lis_plate_name t where t.plate_name_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strPlateNameID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngRes > 0)
                {
                    strSQL = @"delete from t_opr_lis_plate_result t where t.plate_name_id_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strPlateNameID;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取所有板子结果
        /// <summary>
        /// 获取所有板子结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllPlateResult(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngGetAllPlateResult");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.plate_name_id_chr, t.plate_name_vchr, t.plate_date,plate_chaname_vchr
  from t_opr_lis_plate_name t
";
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
            }
            catch(Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 插入检验结果
        /// <summary>
        /// 插入检验结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertDeviceResult(System.Security.Principal.IPrincipal p_objPrincipal, clsLIS_Device_Test_ResultVO[] p_objResultArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngInsertDeviceResult");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            DbType[] m_dbType = new DbType[] {DbType.Int32,DbType.String,DbType.String,DbType.String,DbType.String,
                DbType.String,DbType.Double,DbType.Double,DbType.String,DbType.String,DbType.DateTime,DbType.Int32,DbType.Byte,DbType.String,DbType.Int32};
            object[][] objValue = new object[15][];
            for (int i = 0; i < objValue.Length; i++)
            {
                objValue[i] = new object[p_objResultArr.Length];
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"insert into t_opr_lis_result
  (idx_int,
   result_vchr,
   device_check_item_name_vchr,
   unit_vchr,
   device_sampleid_chr,
   refrange_vchr,
   min_val_dec,
   max_val_dec,
   abnormal_flag_vchr,
   deviceid_chr,
   check_dat,
   pstatus_int,
   graph_img,
   graph_format_name_vchr,
   is_graph_result_num)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
";
                int intLength = p_objResultArr.Length;
                int[] intIdxArr = null;
                string strDeviceID = p_objResultArr[0].strDevice_ID;
                lngRes = m_lngGetSequenceArr("seq_lis_result", intLength, out intIdxArr);
                if (lngRes <= 0)
                {
                    return lngRes;
                }
                for (int i = 0; i < intLength; i++)
                {
                    objValue[0][i] = intIdxArr[i];
                    objValue[1][i] = p_objResultArr[i].strResult;
                    objValue[2][i] = p_objResultArr[i].strDevice_Check_Item_Name;
                    objValue[3][i] = p_objResultArr[i].strUnit;
                    objValue[4][i] = p_objResultArr[i].strDevice_Sample_ID;
                    objValue[5][i] = p_objResultArr[i].strRefRange;
                    if (!string.IsNullOrEmpty(p_objResultArr[i].strMinVal))
                    {
                        objValue[6][i] = double.Parse(p_objResultArr[i].strMinVal);
                    }
                    if (!string.IsNullOrEmpty(p_objResultArr[i].strMaxVal))
                    {
                        objValue[7][i] = double.Parse(p_objResultArr[i].strMaxVal);
                    }
                    
                    objValue[8][i] = p_objResultArr[i].strAbnormal_Flag;
                    objValue[9][i] = strDeviceID;
                    objValue[10][i] = DateTime.Parse(p_objResultArr[i].strCheck_Date);
                    objValue[11][i] = 1;
                    objValue[12][i] = p_objResultArr[i].bytGraph;
                    objValue[13][i] = p_objResultArr[i].strGraphFormatName;
                    objValue[14][i] = 0;
                }
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValue, m_dbType);
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                    return lngRes;
                }
                strSQL = @"select t.import_req_int, t.begin_idx_int, t.end_idx_int
  from t_opr_lis_result_log t
 where t.deviceid_chr = ?
   and trim(t.device_sampleid_chr) = ?
   and t.check_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
";
                DataTable dtResult = null;
                DateTime dtCheckDate = DateTime.Now;
                
                IDataParameter[] objDPArr = null;
                string strSQL_ImportSeq = @"select max(t.import_req_int) + 1 as import_req_int
  from t_opr_lis_result_import_req t
 where t.deviceid_chr = ?
";
                string strSQL_InertImportSeq = @"insert into t_opr_lis_result_import_req
  (check_dat, device_sampleid_chr, deviceid_chr, import_req_int)
values
  (?, ?, ?, ?)";
                string strSQL_InsertLog = @"insert into t_opr_lis_result_log
  (begin_idx_int,
   check_dat,
   device_sampleid_chr,
   import_req_int,
   end_idx_int,
   deviceid_chr)
values
  (?, ?, ?, ?, ?, ?)
";
                string strSQL_UpdateLog = @"update t_opr_lis_result_log t
   set t.end_idx_int = ?, t.check_dat = ?
 where t.deviceid_chr = ?
   and trim(t.device_sampleid_chr) = ?
   and t.import_req_int = ?
";
                string strSQL_DeviceRelation = @"select deviceid_chr, seq_id_device_chr, sample_id_chr
  from t_opr_lis_device_relation
 where status_int = 1
   and deviceid_chr = ?
   and trim(device_sampleid_chr) = ?
   and check_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')";
                string strSQL_UpdateDeviceRelation = @"update t_opr_lis_device_relation
   set device_sampleid_chr = ?,
       check_dat           = ?,
       import_req_int      = ?,
       status_int          = 2
 where trim(seq_id_device_chr) = ?
   and trim(deviceid_chr) = ?";
                DataTable dtImportSeq = null;
                int intImportSeq = 0;
                long lngEff = 0;
                #region 修改插入t_opr_lis_result_log，t_opr_lis_result_import_req表
                for (int i = 0; i < p_objResultArr.Length; i++)
                {
                    try
                    {
                        dtCheckDate = Convert.ToDateTime(p_objResultArr[i].strCheck_Date);
                    }
                    catch
                    {
                        dtCheckDate = DateTime.Now;
                    }
                    objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                    objDPArr[0].Value = strDeviceID;
                    objDPArr[1].Value = p_objResultArr[i].strDevice_Sample_ID;
                    objDPArr[2].Value = dtCheckDate.ToString("yyyy-MM-dd 00:00:00");
                    objDPArr[3].Value = dtCheckDate.ToString("yyyy-MM-dd 23:59:59");
                    dtResult = null;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                    if (lngRes <= 0)
                    {
                        ContextUtil.SetAbort();
                        return lngRes;
                    }
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                       
                        int.TryParse(dtResult.Rows[0]["import_req_int"].ToString().Trim(), out intImportSeq);
                        int intBegin = Convert.ToInt32(dtResult.Rows[0]["begin_idx_int"].ToString().Trim());
                        int intEnd = Convert.ToInt32(dtResult.Rows[0]["end_idx_int"].ToString().Trim());
                        objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].Value = intIdxArr[i];
                        objDPArr[1].Value = dtCheckDate;
                        objDPArr[2].Value = strDeviceID;
                        objDPArr[3].Value = p_objResultArr[i].strDevice_Sample_ID;
                        objDPArr[4].Value = intImportSeq;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL_UpdateLog, ref lngEff, objDPArr);
                        if (lngRes <= 0)
                        {
                            ContextUtil.SetAbort();
                            return lngRes;
                        }
                        string strSQL_UpdateResult = @"update t_opr_lis_result t
   set t.check_dat = ?
 where t.idx_int >= ?
   and t.idx_int <= ?
   and t.check_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
   and t.deviceid_chr = ?
   and t.device_sampleid_chr = ?
";
                        string strBeginDate = dtCheckDate.ToString("yyyy-MM-dd 00:00:00");
                        string strEndDate = dtCheckDate.ToString("yyyy-MM-dd 23:59:59");
                        objHRPSvc.CreateDatabaseParameter(7, out objDPArr);
                        objDPArr[0].Value = dtCheckDate;
                        objDPArr[1].Value = intBegin;
                        objDPArr[2].Value = intEnd;
                        objDPArr[3].Value = strBeginDate;
                        objDPArr[4].Value = strEndDate;
                        objDPArr[5].Value = strDeviceID;
                        objDPArr[6].Value = p_objResultArr[i].strDevice_Sample_ID;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL_UpdateResult, ref lngEff, objDPArr);
                        if (lngRes <= 0)
                        {
                            ContextUtil.SetAbort();
                            return lngRes;
                        }
                    }
                    else
                    {
                        
                        objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = strDeviceID;
                        dtImportSeq = null;
                        lngRes = 0;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL_ImportSeq, ref dtImportSeq, objDPArr);
                        if (lngRes > 0 && dtImportSeq != null && dtImportSeq.Rows.Count > 0)
                        {
                            int.TryParse(dtImportSeq.Rows[0]["import_req_int"].ToString().Trim(), out intImportSeq);
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[0].Value = dtCheckDate;
                            objDPArr[1].Value = p_objResultArr[i].strDevice_Sample_ID;
                            objDPArr[2].Value = strDeviceID;
                            objDPArr[3].Value = intImportSeq;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL_InertImportSeq, ref lngEff, objDPArr);
                            if (lngRes <= 0)
                            {
                                ContextUtil.SetAbort();
                                return lngRes;
                            }
                            lngRes = 0;
                            objHRPSvc.CreateDatabaseParameter(6, out objDPArr);
                            objDPArr[0].Value = intIdxArr[i];
                            objDPArr[1].Value = dtCheckDate;
                            objDPArr[2].Value = p_objResultArr[i].strDevice_Sample_ID;
                            objDPArr[3].Value = intImportSeq;
                            objDPArr[4].Value = intIdxArr[i];
                            objDPArr[5].Value = strDeviceID;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL_InsertLog, ref lngEff, objDPArr);
                            if (lngRes <= 0)
                            {
                                ContextUtil.SetAbort();
                                return lngRes;
                            }
                        }
                        else
                        {
                            ContextUtil.SetAbort();
                            return lngRes;
                        }
                    }
                    objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                    objDPArr[0].Value = strDeviceID;
                    objDPArr[1].Value = p_objResultArr[i].strDevice_Sample_ID;
                    objDPArr[2].Value = dtCheckDate.ToString("yyyy-MM-dd 00:00:00");
                    objDPArr[3].Value = dtCheckDate.ToString("yyyy-MM-dd 23:59:59");
                    dtResult = null;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL_DeviceRelation, ref dtResult, objDPArr);
                    if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].Value = p_objResultArr[i].strDevice_Sample_ID;
                        objDPArr[1].Value = dtCheckDate;
                        objDPArr[2].Value = intImportSeq;
                        objDPArr[3].Value = dtResult.Rows[0]["seq_id_device_chr"].ToString().Trim();
                        objDPArr[4].Value = strDeviceID;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL_UpdateDeviceRelation, ref lngEff, objDPArr);
                    }
                }
                #endregion
            }
            catch(Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objPrivilege = null;
                objHRPSvc = null;
                objValue = null;
                m_dbType = null;
            }
            return lngRes;
        }
        #endregion


        #region 获取自定义项目的结果判断公式  
        /// <summary>
        /// 获取自定义项目的结果判断公式
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objCheckItemCustomRes"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryCheckItemCustomRes(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckItemID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngQueryCheckItemCustomRes");
            if (lngRes <= 0)
                return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.seq_int, t.conditions_vchr, t.result_vchr
  from t_bse_lis_check_item_customres t
 where t.check_item_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckItemID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objPrivilege = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
    }
}
