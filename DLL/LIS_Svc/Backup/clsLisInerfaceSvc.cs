using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.middletier;
using com.digitalwave.Utility;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled=true)]
    /// <summary>
    /// 检验服务接口类
    /// </summary>
    public class clsLisInerfaceSvc :clsMiddleTierBase
    {

        #region 根据申请单Id获取费用名称

        /// <summary>
        /// 根据检验申请单Id获取收费项目名称
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="chargeItemName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemName(string applicationId, out string chargeItemName)
        {
            chargeItemName = "";
            long lngRes = 0;

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select a.itemname_vchr
                                from t_bse_chargeitem a,
                                     t_opr_lis_app_apply_unit b
                               where b.apply_unit_id_chr = a.itemsrcid_vchr
                                 and b.application_id_chr = ? ";
            IDataParameter[] arrParams = clsPublicSvc.m_objConstructIDataParameterArr(applicationId);
            try
            {
                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, arrParams);

                if (lngRes < 0)
                {
                    return -1;
                }

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        if (i == dtResult.Rows.Count - 1)
                        {
                            chargeItemName += dtResult.Rows[i][0].ToString();
                        }
                        else
                        {
                            chargeItemName += dtResult.Rows[i][0].ToString() + ";";
                        }
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
        /// 根据检验申请单Id获取诊疗项目名称
        /// </summary>
        /// <param name="applicationId">检验申请单Id</param>
        ///<param name="orderDicItemName">诊疗项目名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderDicItemName(string applicationId, out string orderDicItemName)
        {
            orderDicItemName = "";
            long lngRes = 0;

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select a.name_chr
                                from t_bse_bih_orderdic a, 
                                     t_opr_lis_app_apply_unit b
                               where b.apply_unit_id_chr = a.applytypeid_chr 
                                 and b.application_id_chr = ?";

            IDataParameter[] arrParams = clsPublicSvc.m_objConstructIDataParameterArr(applicationId);
            try
            {
                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, arrParams);

                if (lngRes < 0)
                {
                    return -1;
                }

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        if (i == dtResult.Rows.Count - 1)
                        {
                            orderDicItemName += dtResult.Rows[i][0].ToString();
                        }
                        else
                        {
                            orderDicItemName += dtResult.Rows[i][0].ToString() + ";";
                        }
                    }
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
