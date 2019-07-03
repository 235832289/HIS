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
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDiscountStatistic : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获得门诊的科室名称
        /// <summary>
        /// 获得门诊的科室名称
        /// </summary>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDepartInfo(ref DataTable dtResult)
        {
            long lngRes = 0;
            string strSQL = @"select a.deptid_chr,a.deptname_vchr from t_bse_deptdesc a 
                                where a.inpatientoroutpatient_int=0";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取手术类型的项目信息
        /// <summary>
        /// 获取手术类型的项目信息
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetItemInfo(string itemName, ref DataTable dtResult)
        {
            long lngRes = 0;
            string strSQL = @"select  b.itemid_chr,b.itemcode_vchr,b.itemname_vchr
                            from  t_bse_chargeitemextype a,
                            (select a.itemid_chr,a.itemcode_vchr,a.itemname_vchr,a.itemopinvtype_chr 
                                                      from t_bse_chargeitem a
                                                     where itemcode_vchr like ?
                                                        or itemname_vchr like ?
                                                        or itempycode_chr like ?
                                                        or itemwbcode_chr like ?) b
                            where a.flag_int = 2 and a.typeid_chr = '0010'
                            and a.typeid_chr = b.itemopinvtype_chr
                            group by b.itemid_chr,b.itemcode_vchr,b.itemname_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                arrParams[0].Value = itemName + '%';
                arrParams[1].Value = '%' + itemName + '%';
                arrParams[2].Value = itemName + '%';
                arrParams[3].Value = itemName + '%';
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, arrParams);

                objHRPSvc.Dispose();
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
