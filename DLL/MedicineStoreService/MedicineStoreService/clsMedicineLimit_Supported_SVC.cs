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
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsMedicineLimit_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取全部药品（已停用的除外）
        /// <summary>
        /// 获取全部药品（已停用的除外）
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
                string strSQL = @"select t.medicineid_chr,
			 t.assistcode_chr,
			 t.medicinename_vchr,
			 t.medspec_vchr,
			 t.productorid_chr,
			 t.opunit_chr,
			 o.tiptoplimit_int,
			 o.neaplimit_int,
			 o.stockamount_int,
			 sum(s.realgross_int) realgross_int,
			 t.pycode_chr,
			 case when tiptoplimit_int is null
			 then 0 else 1 end as hasrow
	from t_bse_medicine t
	left join t_ms_storage_detail s on t.medicineid_chr = s.medicineid_chr
and s.storageid_chr = ?
	left join t_ms_medlimit o on o.medicineid_chr = t.medicineid_chr
													 and o.storageid_chr = ?
 where exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?)
	 and t.assistcode_chr is not null
	 and t.ifstop_int = 0
 group by t.medicineid_chr,
					t.assistcode_chr,
					t.medicinename_vchr,
					t.medspec_vchr,
					t.productorid_chr,
					t.opunit_chr,
					o.tiptoplimit_int,
					o.neaplimit_int,
					o.stockamount_int,
					t.pycode_chr
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strStorageID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
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
    }
}

