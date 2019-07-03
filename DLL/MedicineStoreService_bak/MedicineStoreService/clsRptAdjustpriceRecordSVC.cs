using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药品调价记录查询
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRptAdjustpriceRecordSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取数据 不用
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
//        [AutoComplete]
//        public long m_mthSelectAdjustData(int intDsOrMs, DateTime strBegin, DateTime strEnd, string strStorageid, out DataTable m_objTable)
//        {
//            long lngRes = -1;
//            m_objTable = new DataTable();
//            string strSql = "";
//            if (intDsOrMs == 0)
//            {
//                #region 药房
//                if (strStorageid == "0000")
//                {
//                    strSql = @"select b.medicinename_vch,
//                                      b.medspec_vchr,
//                                      b.ipunit_vchr opunit_vchr,
//                                      c.productorid_chr,
//                                      b.ipoldretailprice_int oldretailprice_int,
//                                      b.ipnewretailprice_int newretailprice_int,
//                                      a.examdate_dat,
//                                      b.reason_vchr
//                                 from t_ds_adjustprice a,
//                                      t_ds_adjustprice_detail b,
//                                      t_bse_medicine c,
//                                      t_bse_medstore d
//                                where a.seriesid_int=b.seriesid2_int(+)
//                                  and (a.status_int=2 or a.status_int=3)
//                                  and b.status_int=1
//                                  and b.medicineid_chr=c.medicineid_chr(+)
//                                  and b.drugstoreid_chr=d.deptid_chr(+)
//                                  and a.examdate_dat between ? and ?";
//                }
//                else
//                {
//                    strSql = @"select b.medicinename_vch,
//                                      b.medspec_vchr,
//                                      b.ipunit_vchr opunit_vchr,
//                                      c.productorid_chr,
//                                      b.ipoldretailprice_int oldretailprice_int,
//                                      b.ipnewretailprice_int newretailprice_int,
//                                      a.examdate_dat,
//                                      b.reason_vchr
//                                 from t_ds_adjustprice a,
//                                      t_ds_adjustprice_detail b,
//                                      t_bse_medicine c,
//                                      t_bse_medstore d
//                                where a.seriesid_int=b.seriesid2_int(+)
//                                  and (a.status_int=2 or a.status_int=3)
//                                  and b.status_int=1
//                                  and b.medicineid_chr=c.medicineid_chr(+)
//                                  and b.drugstoreid_chr=d.deptid_chr(+)
//                                  and d.medstoreid_chr=?
//                                  and a.examdate_dat between ? and ?";
//                }
//                #endregion
//            }
//            else
//            {
//                #region 药库
//                if (strStorageid == "000")
//                {
//                    strSql = @"select b.medicinename_vch,
//                                      b.medspec_vchr,
//                                      b.opunit_vchr,
//                                      c.productorid_chr,
//                                      b.oldretailprice_int,
//                                      b.newretailprice_int,
//                                      a.examdate_dat,
//                                      b.reason_vchr
//                                 from t_ms_adjustprice a,
//                                      t_ms_adjustprice_detail b,
//                                      t_bse_medicine c,
//                                      t_bse_storage d
//                                where a.seriesid_int=b.seriesid2_int(+)
//                                  and (a.formstate_int=2 or a.formstate_int=3)
//                                  and b.status_int=1
//                                  and b.medicineid_chr=c.medicineid_chr(+)
//                                  and a.storageid_chr=d.storageid_chr(+)
//                                  and a.adjustpricedate_dat between ? and ?";
//                }
//                else
//                {
//                    strSql = @"select b.medicinename_vch,
//                                      b.medspec_vchr,
//                                      b.opunit_vchr,
//                                      c.productorid_chr,
//                                      b.oldretailprice_int,
//                                      b.newretailprice_int,
//                                      a.examdate_dat,
//                                      b.reason_vchr
//                                 from t_ms_adjustprice a,
//                                      t_ms_adjustprice_detail b,
//                                      t_bse_medicine c,
//                                      t_bse_storage d
//                                where a.seriesid_int=b.seriesid2_int(+)
//                                  and (a.formstate_int=2 or a.formstate_int=3)
//                                  and b.status_int=1
//                                  and b.medicineid_chr=c.medicineid_chr(+)
//                                  and a.storageid_chr=d.storageid_chr(+)
//                                  and d.storageid_chr=?
//                                  and a.adjustpricedate_dat between ? and ?";
//                }
//                #endregion
//            }
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                IDataParameter[] objDPArr = null;

//                if (strStorageid == "0000")
//                {
//                    objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
//                    objDPArr[0].DbType = DbType.DateTime;
//                    objDPArr[0].Value = DateTime.Parse(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
//                    objDPArr[1].DbType = DbType.DateTime;
//                    objDPArr[1].Value = DateTime.Parse(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
//                }
//                else
//                {
//                    objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
//                    objDPArr[0].Value = strStorageid;
//                    objDPArr[1].DbType = DbType.DateTime;
//                    objDPArr[1].Value = DateTime.Parse(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
//                    objDPArr[2].DbType = DbType.DateTime;
//                    objDPArr[2].Value = DateTime.Parse(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
//                }

//                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_objTable, objDPArr);

//                objHRPSvc.Dispose();
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSelectAdjustData(int intDsOrMs, DateTime strBegin, DateTime strEnd, string p_Medid, out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();
            string strSql = "";
            if (intDsOrMs == 0)
            {
                #region 药房
                strSql = @"select b.medicinename_vch,
                                      b.medspec_vchr,
                                      b.opunit_vchr opunit_vchr,
                                      c.productorid_chr,
                                      b.opoldretailprice_int oldretailprice_int,
                                      b.opnewretailprice_int newretailprice_int,
                                      decode(c.opchargeflg_int,0,b.opoldretailprice_int,
                                      1,b.ipoldretailprice_int) as opoldprice,
                                      decode(c.opchargeflg_int,0,b.opnewretailprice_int,
                                      1,b.ipnewretailprice_int) as opnewprice,
                                      decode(to_char(a.examdate_dat),'0001-1-1','',
                                      to_char(a.examdate_dat,'yyyy-mm-dd')) as examdate_dat,
                                      b.reason_vchr
                                 from t_ds_adjustprice a,
                                      t_ds_adjustprice_detail b,
                                      t_bse_medicine c,
                                      t_bse_medstore d
                                where a.seriesid_int=b.seriesid2_int(+)
                                  and (a.status_int=2 or a.status_int=3)
                                  and b.status_int=1
                                  and b.medicineid_chr=c.medicineid_chr(+)
                                  and b.drugstoreid_chr=d.deptid_chr(+)
                                  and a.examdate_dat between ? and ?";
                #endregion
            }
            else
            {
                #region 药库
                strSql = @"select b.medicinename_vch,
                                      b.medspec_vchr,
                                      b.opunit_vchr,
                                      c.productorid_chr,
                                      b.oldretailprice_int,
                                      b.newretailprice_int,
                                      decode(to_char(a.examdate_dat),'0001-1-1','',
                                      to_char(a.examdate_dat,'yyyy-mm-dd')) as examdate_dat,
                                      b.reason_vchr
                                 from t_ms_adjustprice a,
                                      t_ms_adjustprice_detail b,
                                      t_bse_medicine c,
                                      t_bse_storage d
                                where a.seriesid_int=b.seriesid2_int(+)
                                  and (a.formstate_int=2 or a.formstate_int=3)
                                  and b.status_int=1
                                  and b.medicineid_chr=c.medicineid_chr(+)
                                  and a.storageid_chr=d.storageid_chr(+)
                                  and a.adjustpricedate_dat between ? and ?";
                #endregion
            }
            try
            {
                if (!string.IsNullOrEmpty(p_Medid))
                {
                    strSql += @" and b.medicineid_chr=?";
                }

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;

                if (!string.IsNullOrEmpty(p_Medid))
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = DateTime.Parse(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = DateTime.Parse(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[2].Value = p_Medid;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = DateTime.Parse(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = DateTime.Parse(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                //if (strStorageid == "0000")
                //{
                //    objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                //    objDPArr[0].DbType = DbType.DateTime;
                //    objDPArr[0].Value = DateTime.Parse(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                //    objDPArr[1].DbType = DbType.DateTime;
                //    objDPArr[1].Value = DateTime.Parse(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                //}
                //else
                //{
                //    objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                //    objDPArr[0].Value = strStorageid;
                //    objDPArr[1].DbType = DbType.DateTime;
                //    objDPArr[1].Value = DateTime.Parse(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                //    objDPArr[2].DbType = DbType.DateTime;
                //    objDPArr[2].Value = DateTime.Parse(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                //}

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_objTable, objDPArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
    }
}
