using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药库报废统计
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRejectStorageReportSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 药库报废统计
        /// <summary>
        /// 药库报废统计
        /// </summary>
        /// <param name="p_objPrincipal">IPrincipal</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_intMedicineSetID">药品类型设置ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatistics(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,int p_intMedicineSetID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                string strSetID = string.Empty;
                if (p_intMedicineSetID > 0)
                {
                    strSetID = @" and y.medicinetypesetid = ?";
                }

                string strSQL = @"select sum(c.callprice_int * c.netamount_int) callsum,
                    sum(c.wholesaleprice_int * c.netamount_int) wholesalesum,
                    sum(c.retailprice_int * c.netamount_int) retailsum       
                     from t_ms_outstorage_detail c
                     left join t_ms_outstorage b on b.seriesid_int = c.seriesid2_int
                     left join t_bse_medicine d on c.medicineid_chr = d.medicineid_chr
                     left join t_ms_medicinetypeset y on 
                     y.medicinetypeid_chr = d.medicinetypeid_chr 
                     where (b.status > 1)
                     and (c.status = 1)
                     and (b.formtype = 4)
                     and (b.examdate_dat >= ?)
                     and (b.examdate_dat <= ?)
                     and (b.storageid_chr = ?) "+strSetID;

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                
                if (string.IsNullOrEmpty(strSetID))
                {                    
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[2].Value = p_strStorageID;
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[2].Value = p_strStorageID;                        
                    objDPArr[3].Value = p_intMedicineSetID;
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
