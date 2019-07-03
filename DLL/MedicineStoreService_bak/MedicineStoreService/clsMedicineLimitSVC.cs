using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    public class clsMedicineLimitSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取全部药品
        /// <summary>
        /// 获取全部药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = -1;
            try
            {
                string strSQL = @"select t.medicineid_chr,t.assistcode_chr,
t.medicinename_vchr,
t.medspec_vchr,
t.opunit_chr,
t.tiptoplimit_int,
t.neaplimit_int,
sum(s.realgross_int) realgross_int,
t.pycode_chr
from t_bse_medicine t left join t_ms_storage_detail s
 on t.medicineid_chr = s.medicineid_chr
 where exists (select r.medicineroomid
          from t_ms_medicinestoreroomset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medicineroomid = ?) and t.assistcode_chr is not null
 group by  t.medicineid_chr,t.assistcode_chr,
t.medicinename_vchr,
t.medspec_vchr,
t.opunit_chr,
t.tiptoplimit_int,
t.neaplimit_int,
t.pycode_chr
order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 保存修改后的限量
        /// </summary>
        /// <param name="p_objLimit"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaverMedicine(clsMedicineLimit_VO[] p_objLimit)
        {
            long lngRes = -1;
            string strSQL = @"update t_bse_medicine set tiptoplimit_int = ?,neaplimit_int = ? where medicineid_chr = ?";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            
           
            IDataParameter[] objDPArr = null;
            for (int iOr = 0; iOr < p_objLimit.Length; iOr++)
            {
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_objLimit[iOr].m_douTiptopLimit;
                objDPArr[1].Value = p_objLimit[iOr].m_douNeapLimit;
                objDPArr[2].Value = p_objLimit[iOr].m_strMedicineid;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRes, objDPArr);
            }
            return lngRes;
        }
    }
}
