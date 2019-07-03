using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using System.Collections;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药库中间件公共类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsNewPurchaseMedicineSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获得新药明细
        /// <summary>
        /// 获得新药明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_alArr">查询条件</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNewPurchaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, ArrayList p_alArr, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_alArr.Count < 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select b.medicineid_chr,
             z.storageid_chr,
			 y.storagename_vchr,
			 c.assistcode_chr,
			 b.medicinename_vch,
			 b.medspec_vchr,
			 case
				 when b.lotno_vchr = 'UNKNOWN' then
					''
				 else
					b.lotno_vchr
			 end lotno_vchr,
			 d.medicinetypename_vchr,
			 b.unit_vchr,
			 b.callprice_int,
			 b.retailprice_int,
			 b.wholesaleprice_int,
			 b.validperiod_dat,
			 e.medicinepreptypename_vchr,
			 b.productorid_chr,
			 v.vendorname_vchr
	from t_ms_instorage_detal b
 inner join t_bse_medicine c on b.medicineid_chr = c.medicineid_chr
 inner join t_aid_medicinetype d on c.medicinetypeid_chr = d.medicinetypeid_chr
	left join t_ms_instorage z on z.seriesid_int = b.seriesid2_int
    left join t_bse_storage y on y.storageid_chr = z.storageid_chr
	left outer join t_aid_medicinepreptype e on c.medicinepreptype_chr = e.medicinepreptype_chr
	left outer join t_bse_vendor v on z.vendorid_chr = v.vendorid_chr 
 where (z.storageid_chr = ?)
	and (b.status = 1) and (z.state_int = 2 or z.state_int = 3)
    and z.instoragedate_dat between ? and ? 
    and (b.medicinename_vch like ?
    or c.assistcode_chr like ?)
    and v.vendorname_vchr like ?
    and z.instorageid_vchr like ?
    and d.medicinetypeid_chr like ?  
 order by c.assistcode_chr asc,b.validperiod_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_alArr[0];
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_alArr[1];
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_alArr[2];
                objDPArr[3].Value = p_alArr[3] + "%";
                objDPArr[4].Value = p_alArr[3] + "%";
                objDPArr[5].Value = p_alArr[4] + "%";
                objDPArr[6].Value = p_alArr[5] + "%";
                if (p_alArr[6].ToString() != "0")
                {
                    objDPArr[7].Value = p_alArr[6] + "%";
                }
                else
                {
                    objDPArr[7].Value = "%";
                }


                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
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
