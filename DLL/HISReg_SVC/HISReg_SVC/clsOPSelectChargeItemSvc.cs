using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 查找选择收费的项目中间件
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsOPSelectChargeItemSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 根据处方查询是否已经发药完成
        /// <summary>
        /// 根据处方查询是否已经发药完成
        /// </summary>
        /// <param name="p_strRecNo">处方号</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngQuerySendMed(string p_strRecNo, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = null;

            if (string.IsNullOrEmpty(p_strRecNo))
            {
                return lngRes;
            }
            string strSql = @"select a.outpatrecipeid_chr,c.medicnetype_int,
                                   decode(c.medicnetype_int, 1, 'WM', 2, 'CM', 3, 'QTH', 4, '') as medtype,
                                   decode(b.pstatus_int, 3, 1, 0) as issendmed,e.status_int
                              from t_opr_recipesendentry a, t_opr_recipesend b, t_bse_medstore c,t_opr_returnmed e
                             where a.sid_int = b.sid_int
                               and b.medstoreid_chr = c.medstoreid_chr
                               and a.outpatrecipeid_chr = e.outpatrecipeid_chr(+)
                               and a.outpatrecipeid_chr = ? ";

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strRecNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref p_dtbResult, objParamArr);
                if (lngRes > 0 && p_dtbResult.Rows.Count > 0)
                {
                    for (int i = 0; i < p_dtbResult.Rows.Count; i++)
                    {
                         DataRow dtrTemp = p_dtbResult.Rows[i];
                         if (dtrTemp["status_int"].ToString() == "1")
                         {
                             p_dtbResult.Rows[i]["issendmed"] = 0;
                         }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }

            return lngRes;
        }
        #endregion

        #region 查询诊疗项目是否已经做好
        /// <summary>
        /// 查询诊疗项目是否已经做好,检查单开材料是否已经确定
        /// </summary>
        /// <param name="p_strRecNo">处方号</param>
        /// <param name="p_strOrderDicId">诊疗项目id</param>
        /// <param name="p_intType">1-诊疗项目（检验、检查、手术） 2-单开材料</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngQueryDiagnosisItemStatus(string p_strRecNo, string p_strOrderDicId, int p_intType, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = null;
            string strSql = string.Empty;

            if (p_intType == 1)
            {
                strSql = @"select a.outpatrecipeid_chr,
                                   a.orderdicid_chr,
                                   d.status_int isfinish
                              from t_opr_outpatient_orderdic a, t_opr_itemconfirm d
                             where a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and a.orderid_int = d.outpatrecipedeid_chr
                               and d.status_int = 1
                               and a.orderdicid_chr = ?
                               and a.outpatrecipeid_chr = ?";
            }
            else if (p_intType == 2)
            {
                strSql = @"select o.outpatrecipeid_chr,
                                   o.outpatrecipedeid_chr orderdicid_chr,
                                   i.status_int  isfinish
                              from t_tmp_outpatientothrecipede o, t_opr_itemconfirm i
                             where o.outpatrecipeid_chr = i.outpatrecipeid_chr
                               and o.outpatrecipedeid_chr = i.outpatrecipedeid_chr
                               and i.status_int = 1
                               and i.outpatrecipedeid_chr = ?
                               and i.outpatrecipeid_chr = ?";
            }



            if (string.IsNullOrEmpty(strSql))
            {
                return lngRes;
            }

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strOrderDicId;
                objParamArr[1].Value = p_strRecNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref p_dtbResult, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }

            return lngRes;
        }
        #endregion
    }
}
