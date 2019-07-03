using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药品上下限查询
    /// 2008.7.16 chongkun.wu
    /// </summary>
   [Transaction (TransactionOption .Required )]
   [ObjectPooling (true )]
   public  class clsMedicineLimitInfoSVC:com.digitalwave .iCare .middletier .clsMiddleTierBase
   {
#region
//       /// <summary>
//       /// 获取药品库存与限量设置信息
//       /// 2008.7.16 chongkun.wu
//       /// </summary>
//       /// <returns></returns>
//       [AutoComplete ]
//       public long m_lngGetMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreStyle, string p_storageid, ref DataTable p_dtMedicineInfo)
//       {
//           long lngRes = 0;
//           string strSQL = null;
//           try
//           {

//               if(p_strStoreStyle =="0")
//               {
//                   strSQL = @"select 
//t3.assistcode_chr,
//t3.productorid_chr,
//t3.unitprice_mny,
//t3.pycode_chr,
//t3.wbcode_chr,
//t2.medicinename_vchr,
//t2.currentgross_num,
//t2.medspec_vchr,
//t2.opunit_vchr,
//t1.neaplimit_int
//from t_ms_medlimit t1,t_ms_storage t2,t_bse_medicine t3
//where t1.storageid_chr=?
//and t1.medicineid_chr=t2.medicineid_chr
//and t1.medicineid_chr=t3.medicineid_chr
//and t3.ifstop_int=0
//and t1.neaplimit_int>t2.currentgross_num";

//               }
//               else if(p_strStoreStyle=="1")
//               {
//                   strSQL = @"select distinct t5.medicinename_vchr,
//                t5.medspec_vchr,
//                t5.opunit_chr,
//                t5.opcurrentgross_num,
//                t4.neaplimit_int,
//                t7.assistcode_chr,
//                t7.productorid_chr,
//                t7.unitprice_mny,
//                t7.pycode_chr,
//                t7.wbcode_chr
//  from (select t1.medstoreid_chr, t1.deptid_chr
//          from t_bse_medstore t1, t_ds_medlimit t2
//         where t1.deptid_chr = t2.drugstoreid_chr) t3,
//       t_ds_medlimit t4,
//       t_ds_storage t5,
//       t_ds_storage_detail t6,
//       t_bse_medicine t7
// where t3.medstoreid_chr = '0001'
//   and t4.medicineid_chr = t5.medicineid_chr(+)
//   and t4.medicineid_chr = t6.medicineid_chr(+)
//   and t4.medicineid_chr = t7.medicineid_chr(+)
//   and t5.ifstop_int = 0
//   and t3.deptid_chr = t5.drugstoreid_chr
//   and t4.neaplimit_int > t5.opcurrentgross_num
//   ";
//               }

//               IDataParameter [] objDPArr=null ;
//               clsHRPTableService objHRPServ = new clsHRPTableService();
//               objHRPServ.CreateDatabaseParameter(1,out objDPArr );
//               objDPArr[0].DbType = DbType.String;
//               objDPArr[0].Value = p_storageid;
//               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL ,ref p_dtMedicineInfo ,objDPArr );
//           }
//           catch (Exception objEx)
//           {
//               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//               bool blnRes = objLogger.LogError(objEx);
//           }
//           return lngRes;

//       }
      #endregion

   }
}
