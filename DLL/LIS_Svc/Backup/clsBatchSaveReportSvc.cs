using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 批量保存界面修改数据库中间件
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBatchSaveReportSvc:clsMiddleTierBase
    {
        #region 批量保存检验编号
        /// <summary>
        /// 批量保存检验编号
        /// </summary>
        /// <param name="p_objMainArr">源数据</param>
        /// <param name="p_strOperator">操作者</param>
        /// <returns>大于0成功，否则失败</returns>
        [AutoComplete]
        public long m_lngUpdateCheckNUM(clsLisApplMainVO[] p_objMainArr,string p_strOperator)
        {
            long lngRes = 0;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            DbType[] dbType = new DbType[] { DbType.String, DbType.String, DbType.String };
            object[][] objValue = new object[3][];
            for (int i = 0; i < objValue.Length; i++)
            {
                objValue[i] = new object[p_objMainArr.Length];
            }
            try
            {
                strSQL = @"update t_opr_lis_application a
   set a.application_form_no_chr = ?,
       a.modify_dat              = sysdate,
       a.operator_id_chr         = ?
 where a.application_id_chr = ?
   and a.pstatus_int = 2
";
                for (int i = 0; i < p_objMainArr.Length; i++)
                {
                    objValue[0][i] = p_objMainArr[i].m_strApplication_Form_NO;
                    objValue[1][i] = p_strOperator;
                    objValue[2][i] = p_objMainArr[i].m_strAPPLICATION_ID;
                }
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValue, dbType);
            }
            catch(Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objValue = null;
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
    }

    /// <summary>
    /// 批量保存界面查询数据库中间件
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBatchSaveReportQuerySvc : clsMiddleTierBase
    {
        #region 查询申请单信息通过条码号
        /// <summary>
        /// 查询申请单信息通过条码号
        /// </summary>
        /// <param name="p_strBarcode">条码号</param>
        /// <param name="p_objMainVO">返回的病人信息</param>
        /// <returns>大于0成功，否则失败</returns>
        [AutoComplete]
        public long m_lngQuerySampleInfo(string p_strBarcode, out clsLisApplMainVO p_objMainVO)
        {
            long lngRes = 0;
            string strSQL = null;
            p_objMainVO = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select a.patient_name_vchr,
       b.application_form_no_chr,
       b.check_content_vchr,
       b.application_id_chr
  from t_opr_lis_sample a, t_opr_lis_application b
 where a.application_id_chr = b.application_id_chr
   and a.barcode_vchr = ?
   and a.status_int >=3 
   and b.pstatus_int = 2";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strBarcode;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = dtResult.Rows[0];
                    p_objMainVO = new clsLisApplMainVO();
                    p_objMainVO.m_strPatient_Name = drTemp["patient_name_vchr"].ToString().Trim();
                    p_objMainVO.m_strApplication_Form_NO = drTemp["application_form_no_chr"].ToString().Trim();
                    p_objMainVO.m_strCheckContent = drTemp["check_content_vchr"].ToString().Trim();
                    p_objMainVO.m_strAPPLICATION_ID = drTemp["application_id_chr"].ToString().Trim();
                }
            }
            catch(Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, false);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
    }
}
