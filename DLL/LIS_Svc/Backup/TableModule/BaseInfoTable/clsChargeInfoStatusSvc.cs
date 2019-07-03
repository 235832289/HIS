using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 检验申请单收费状态Svc
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsChargeInfoStatusSvc:clsMiddleTierBase
    {

        #region 查找申请单的收费状态

        /// <summary>
        /// 查找申请单的收费状态
        /// </summary>
        /// <param name="applicationId">申请单Id</param>
        /// <param name="chargeStatusVO">收费状态VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(string applicationId,out clsChargeStatusVO chargeStatusVO)
        {

            long lngRes = 0;
            DataTable dt = null;
            chargeStatusVO = null;

            string strSQL = @"select * 
                                from t_opr_attachrelation 
                               where attachid_vchr=? ";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = applicationId;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);

                if (lngRes > 0 && dt != null && dt.Rows.Count != 0)
                {
                    chargeStatusVO = ConstructVO(dt.Rows[0]);
                }

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        } 

        #endregion

        #region 构造VO

        /// <summary>
        /// 构造VO
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        public clsChargeStatusVO ConstructVO(DataRow dtRow)
        {
            clsChargeStatusVO obj = new clsChargeStatusVO();
            obj.m_strSeq = dtRow["ATTARELAID_CHR"].ToString();
            obj.m_strSourceItemId = dtRow["SOURCEITEMID_VCHR"].ToString();
            obj.m_strApplicationId = dtRow["ATTACHID_VCHR"].ToString();
            obj.m_intType = DBAssist.ToInt32(dtRow["ATTACHTYPE_INT"]);
            obj.m_intModuleId = DBAssist.ToInt32(dtRow["SYSFROM_INT"]);
            obj.m_blnUrgency = DBAssist.ToInt32(dtRow["URGENCY_INT"]) == 1 ? true : false;
            obj.m_intChargeStatus = DBAssist.ToInt32(dtRow["STATUS_INT"]);

            return obj;
        } 

        #endregion
    }
}
