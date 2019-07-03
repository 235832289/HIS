using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{    /// <summary>
    /// 药库验收单
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
   public  class clsMedIcineCheckSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
    
        [AutoComplete]

       public long m_lngGetMedIcineCheck(string strVendor, int intMedicinetype, string strDateStar, string strDateEnd, string STORAGEID, out DataTable dtbResult)
        {
            

            long lngRes = 0;
            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string sqlTj;
            if (intMedicinetype <= 0)
            {
               sqlTj =string.Empty;
            }
            else
            {
                sqlTj = "and c.medicinetypesetid = ? ";
            }
            string strSQL = @"select b.vendorname_vchr,c.medicinetypesetname medicinetypename_vchr,       
                                    sum(a.callprice_int*a.amount) as sum_callprice_int,
                                    sum(a.retailprice_int*a.amount) as sum_retailprice_int,
                                    sum(a.wholesaleprice_int*a.amount) as sum_wholesaleprice_int
                            from
                                t_ms_instorage_detal a,
                                t_bse_vendor b,
                                t_ms_medicinetypeset c,
                                t_bse_medicine d,
                                t_ms_instorage e
                            where 
                                a.seriesid2_int=e.seriesid_int
                                and e.vendorid_chr=b.vendorid_chr
                                and a.medicineid_chr=d.medicineid_chr
                                and d.medicinetypeid_chr=c.medicinetypeid_chr
                                and (e.state_int = 2 or e.state_int = 3)
                                and e.formtype_int = 1
                                and b.vendorid_chr = ? 
                                and e.instoragedate_dat >= ?
                                and e.instoragedate_dat <= ?
                                and e.storageid_chr = ? " + sqlTj + @" and a.status = 1
                            group by
                                b.vendorname_vchr,
                                c.medicinetypesetname";


            
            clsHRPTableService objHRPServ = new clsHRPTableService();
            IDataParameter[] objDPArr = null;
            if (string.IsNullOrEmpty(sqlTj))
            {
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);

                objDPArr[0].Value = strVendor;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = DateTime.Parse(strDateStar);
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = DateTime.Parse(strDateEnd);
                objDPArr[3].Value = STORAGEID;
            }
            else
            {
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);

                objDPArr[0].Value = strVendor;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = DateTime.Parse(strDateStar);
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = DateTime.Parse(strDateEnd);
                objDPArr[3].Value = STORAGEID;
                objDPArr[4].Value = intMedicinetype;
            }
            

            dtbResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 入库统计(外退)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_intMedicineSetID">药品类型设置ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        [AutoComplete]
       public long m_lngStatisticsForeignRetreat(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                string strSetID = string.Empty;
                if (p_intMedicineSetID > 0)
                {
                    strSetID = @"
   and ty.medicinetypesetid = ?";
                }

                string strSQL = @"select c.vendorname_vchr,
        ty.medicinetypesetname medicinetypename_vchr,
        sum(b.callprice_int * b.netamount_int) sum_callprice_int,
        sum(b.wholesaleprice_int * b.netamount_int) sum_wholesaleprice_int,
        sum(b.retailprice_int * b.netamount_int) sum_retailprice_int
  from t_ms_outstorage_detail b
 inner join t_ms_outstorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
  inner join t_ms_medicinetypeset ty on ty.medicinetypeid_chr =
                                             d.medicinetypeid_chr
  left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
 where (a.formtype = 2 or a.formtype = 5) and b.status = 1
   and (a.status = 2 or a.status = 3)
   and a.examdate_dat between ? and ?
   and a.storageid_chr = ? " + strSetID + @"
   and b.vendorid_chr = ? 
 group by ty.medicinetypesetname, c.vendorname_vchr
 order by ty.medicinetypesetname, c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                if (string.IsNullOrEmpty(strSetID))
                {
                    objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[2].Value = p_strStorageID;
                    objDPArr[3].Value = p_strVendorID;
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[2].Value = p_strStorageID;
                    objDPArr[3].Value = p_intMedicineSetID;
                    objDPArr[4].Value = p_strVendorID;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbData, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
    }

}
