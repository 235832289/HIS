using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 供药单位供药明细
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsVendorSupplyDetaiSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 供药单位供药明细表
        /// <summary>
        /// 供药单位供药明细表
        /// </summary>
        /// <param name="p_objPrincipal">IPrincipal</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_intMedicineSetID">药品类型设置ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatistics(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                string strVendorSQL = string.Empty;
                string strSetID = string.Empty;
                if (!string.IsNullOrEmpty(p_strVendorID))
                {
                    strVendorSQL = @" and a.vendorid_chr = ? ";
                }
                if (p_intMedicineSetID > 0)
                {
                    strSetID = @" and d.medicinetypesetid = ?";
                }

                string strSQL = @"select c.assistcode_chr,c.medicinename_vchr,b.medspec_vchr,b.unit_vchr,
               sum(b.amount) as buyamount,sum(b.amount * b.callprice_int) as inmoney,
                sum(b.amount * b.retailprice_int) as outmoney
                from t_ms_instorage_detal b 
                left join t_ms_instorage a on a.seriesid_int = b.seriesid2_int
                left join t_bse_medicine c on c.medicineid_chr = b.medicineid_chr
                left join t_ms_medicinetypeset d on d.medicinetypeid_chr = c.medicinetypeid_chr
                where a.formtype_int = '1' 
                and (a.state_int = 2 or a.state_int = 3) 
                and b.status = 1 
                and a.instoragedate_dat between ? and ? and a.storageid_chr = ?" + strVendorSQL + strSetID + @"
                group by c.assistcode_chr,c.medicinename_vchr,b.medspec_vchr,b.unit_vchr
                order by c.assistcode_chr";

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
                    objDPArr[3].Value = p_strVendorID;
                    objDPArr[4].Value = p_intMedicineSetID;
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
        #endregion        
    }
}
