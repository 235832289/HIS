using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.middletier;
using com.digitalwave.Utility;
using System.EnterpriseServices;

namespace com.digitalwave.iCare.middletier.LIS
{

    /// <summary>
    /// 检验全局类

    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled=true)]
    public class clsLisMainSvc:clsMiddleTierBase
    {

     
        // <summary>
        // 获取检验使用的收费模式（true:诊疗项目 false:收费项目）

        // </summary>
        // <param name="isOrderDic">是否是诊疗项目（t_bih_bse_orderDic）</param>
        // <returns></returns>
        //public long GetChargeMode(out bool isOrderDic)
        //{
        //    long lngRes = 0;
        //    isOrderDic = false;
        //    lngRes=this.m_lngGetSystemSetting(out isOrderDic, "9000");

        //    return lngRes;
        //} 

        #region 获取系统设置

        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <param name="setResult">设置结果</param>
        /// <param name="setId">设置的Id</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSystemSetting(out int setResult, string setId)
        {
            long lngRes = 0;
            setResult = -1;

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            string sql = @"select setstatus_int from t_sys_setting where setid_chr=?";
            IDataParameter[] arrParams = clsPublicSvc.m_objConstructIDataParameterArr(setId);
            DataTable dt = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(sql, ref dt, arrParams);
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx.Message);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {

                    setResult=int.Parse(dt.Rows[0]["setstatus_int"].ToString());
                }
                catch 
                {
                    setResult = -1;
                    new clsLogText().LogError("系统设置(" + setId.ToString() + ")错误！");
                }
            }
            return lngRes;
        }

        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="p_strParmValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysParm(string p_strParmCode, out string p_strParmValue)
        {
            p_strParmValue = "";
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strParmCode))
                return lngRes;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select parmvalue_vchr
  from t_bse_sysparm
 where status_int = 1
   and parmcode_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strParmCode;
                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_strParmValue = dtResult.Rows[0]["parmvalue_vchr"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
                p_strParmCode = null;
            }
            return lngRes;
        }
        #endregion
    }
}
