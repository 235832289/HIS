using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    public class clsReceiptBillSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 根据处方号获取病人信息
        /// <summary>
        /// 根据处方号获取病人信息
        /// </summary>
        /// <param name="p_recipeNO"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientInfo(string ChargeNO, ref DataTable dtResult)
        {
            long lngRes = 0;
            string strSQL = @"select   a.invoiceno_vchr, a.patientname_chr, a.recorddate_dat,
                                       b.patientcardid_chr
                                  from t_opr_outpatientrecipeinv a,
                                       t_bse_patientcard b,
                                       t_opr_chargedefinv c,
                                       t_opr_charge e
                                 where a.patientid_chr = b.patientid_chr
                                   and a.invoiceno_vchr = c.invoiceno_vchr
                                   and e.chargeno_chr = c.chargeno_chr
                                   and e.chargeno_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRP = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRP.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = ChargeNO;
                ((Oracle.DataAccess.Client.OracleParameter)objDPArr[0]).OracleDbType = Oracle.DataAccess.Client.OracleDbType.Char;
                lngRes = objHRP.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRP.Dispose();
            }
            catch (Exception objEX)
            {
                com.digitalwave.Utility.clsLogText objLog = new clsLogText();
                objLog.LogError(objEX);
            }
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 根据处方号获取处方明细
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="recipeNO">处方号</param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeDataByChargeNo(string ChargeNO, ref DataTable dtRecipeSumde)
        {
            long lngRes = 0;
            string strSQL = @"select   d.itemcode_vchr, d.itemopcode_chr, d.itemname_vchr name,
                                       d.itemspec_vchr dec, e.qty_dec count, e.price_mny price,
                                       d.pdcarea_vchr, e.unitid_chr unit
                                  from t_opr_charge a,
                                       t_opr_reciperelation b,
                                       t_opr_outpatientrecipe c,
                                       t_bse_chargeitem d,
                                       t_opr_oprecipeitemde e
                                where a.chargeno_chr = b.chargeno_chr
                                and c.outpatrecipeid_chr = b.outpatrecipeid_chr
                                and c.outpatrecipeid_chr = e.outpatrecipeid_chr
                                and d.itemid_chr = e.itemid_chr
                                and a.chargeno_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSVC = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objSVC.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = ChargeNO;
                lngRes = objSVC.lngGetDataTableWithParameters(strSQL, ref dtRecipeSumde, objDPArr);
                objSVC.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            return lngRes;
        }
    }
}
