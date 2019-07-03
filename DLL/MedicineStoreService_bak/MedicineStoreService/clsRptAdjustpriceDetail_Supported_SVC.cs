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
    /// 药品调价情况一览表
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsRptAdjustpriceDetail_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取二级药房
        /// <summary>
        /// 获取二级药房
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAllMedStore(out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();
            string strSql = @"select t.medstoreid_chr,
       t.medstorename_vchr,
       t.deptid_chr,
       t.medstoretype_int,
       t.medicnetype_int,
       t.urgence_int
  from t_bse_medstore t";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_objTable);

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

        #region 药品类型
        /// <summary>
        /// 药品类型
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetMedicineType(out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();

            string strSql = @"select t.medicinetypeid_chr,t.medicinetypename_vchr from t_aid_medicinetype t";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_objTable);

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

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSelectAdjustData(int intDsOrMs, int p_intMakeFilm,DateTime strBegin, DateTime strEnd, string strMedicineType, string strMedicineid, out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();
            DataTable dt = new DataTable();
            string strSql = "";
            /// 000-全部
            if (intDsOrMs == 0)
            {
                #region 药房
                if (strMedicineType == "000")
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {
                        strSql = @"select distinct b.medicinename_vch,
                                     b.medspec_vchr,
                                     decode(c.opchargeflg_int,0,b.opunit_vchr,
                                     1,b.ipunit_vchr) as opunit_vchr,
                                     c.productorid_chr,
                                     b.opnewretailprice_int newretailprice_int,
                                     decode(c.opchargeflg_int,0,b.opoldretailprice_int,
                                     1,b.ipoldretailprice_int) as opoldprice_int,
                                     decode(c.opchargeflg_int,0,b.opnewretailprice_int,
                                     1,b.ipnewretailprice_int) as opnewprice_int,
                                     a.examdate_dat adjustpricedate_dat,
                                     b.reason_vchr remark_vchr,
                                     c.medicineid_chr, c.assistcode_chr
                                from t_ds_adjustprice a,
                                     t_ds_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and (a.status_int=2 or a.status_int=3)
                                 and b.status_int=1
                                 and a.examdate_dat between ? and ?  order by b.medicinename_vch, c.medicineid_chr, a.examdate_dat desc";
                    }
                    else
                    {
                        strSql = @"select distinct b.medicinename_vch,
                                     b.medspec_vchr,
                                     decode(c.opchargeflg_int,0,b.opunit_vchr,
                                     1,b.ipunit_vchr) as opunit_vchr,
                                     c.productorid_chr,
                                     b.opnewretailprice_int newretailprice_int,
                                     decode(c.opchargeflg_int,0,b.opoldretailprice_int,
                                     1,b.ipoldretailprice_int) as opoldprice_int,
                                     decode(c.opchargeflg_int,0,b.opnewretailprice_int,
                                     1,b.ipnewretailprice_int) as opnewprice_int,
                                     a.examdate_dat adjustpricedate_dat,
                                     b.reason_vchr remark_vchr,
                                     c.medicineid_chr, c.assistcode_chr
                                from t_ds_adjustprice a,
                                     t_ds_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and (a.status_int=2 or a.status_int=3)
                                 and b.status_int=1
                                 and c.medicineid_chr=?
                                 and a.examdate_dat between ? and ?  order by b.medicinename_vch, c.medicineid_chr, a.examdate_dat desc";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {

                        strSql = @"select distinct b.medicinename_vch,
                                     b.medspec_vchr,
                                     decode(c.opchargeflg_int,0,b.opunit_vchr,
                                     1,b.ipunit_vchr) as opunit_vchr,
                                     c.productorid_chr,
                                     b.opnewretailprice_int newretailprice_int,
                                     decode(c.opchargeflg_int,0,b.opoldretailprice_int,
                                     1,b.ipoldretailprice_int) as opoldprice_int,
                                     decode(c.opchargeflg_int,0,b.opnewretailprice_int,
                                     1,b.ipnewretailprice_int) as opnewprice_int,
                                     a.examdate_dat adjustpricedate_dat,
                                     b.reason_vchr remark_vchr,
                                     c.medicineid_chr, c.assistcode_chr
                                from t_ds_adjustprice a,
                                     t_ds_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and (a.status_int=2 or a.status_int=3)
                                 and b.status_int=1
                                 and d.medicinetypeid_chr=?
                                 and a.examdate_dat between ? and ?  order by b.medicinename_vch, c.medicineid_chr, a.examdate_dat desc";
                    }
                    else
                    {
                        strSql = @"select distinct b.medicinename_vch,
                                     b.medspec_vchr,
                                     decode(c.opchargeflg_int,0,b.opunit_vchr,
                                     1,b.ipunit_vchr) as opunit_vchr,
                                     c.productorid_chr,
                                     b.opnewretailprice_int newretailprice_int,
                                     decode(c.opchargeflg_int,0,b.opoldretailprice_int,
                                     1,b.ipoldretailprice_int) as opoldprice_int,
                                     decode(c.opchargeflg_int,0,b.opnewretailprice_int,
                                     1,b.ipnewretailprice_int) as opnewprice_int,
                                     a.examdate_dat adjustpricedate_dat,
                                     b.reason_vchr remark_vchr,
                                     c.medicineid_chr, c.assistcode_chr
                                from t_ds_adjustprice a,
                                     t_ds_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and (a.status_int=2 or a.status_int=3)
                                 and b.status_int=1 and d.medicinetypeid_chr=?
                                 and c.medicineid_chr=?                                 
                                 and a.examdate_dat between ? and ?  order by b.medicinename_vch, c.medicineid_chr, a.examdate_dat desc";
                    }
                }
                #endregion
            }
            else
            {
                #region 药库
                if (strMedicineType == "000")
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {
                        strSql = @"select distinct b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int, c.assistcode_chr
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and a.adjustpricedate_dat between ? and ?
                             order by b.medicinename_vch, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                    else
                    {
                        strSql = @"select distinct b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int, c.assistcode_chr
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+) and b.medicineid_chr = ?
                                 and a.adjustpricedate_dat between ? and ?
                             order by b.medicinename_vch, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {
                        strSql = @"select distinct b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int, c.assistcode_chr
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and d.medicinetypeid_chr=?
                                 and a.adjustpricedate_dat between ? and ?
                             order by b.medicinename_vch, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                    else
                    {
                        strSql = @"select distinct b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int, c.assistcode_chr
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and d.medicinetypeid_chr=? and b.medicineid_chr = ?
                                 and a.adjustpricedate_dat between ? and ? 
                             order by b.medicinename_vch, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                }
                #endregion
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;

                int n = 0;
                if (strMedicineType == "000")
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {
                        objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[n++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[n++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[n++].Value = strMedicineid;
                        objDPArr[n++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[n++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {
                        objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[n++].Value = strMedicineType;
                        objDPArr[n++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[n++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objDPArr);                        
                        objDPArr[n++].Value = strMedicineType;
                        objDPArr[n++].Value = strMedicineid;
                        objDPArr[n++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[n++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                 
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dt, objDPArr);
                if (p_intMakeFilm == 1 && dt != null && dt.Rows.Count > 0)//造影剂
                {
                    string m_strFilter = string.Empty;
                    DataTable m_dtbMakeFilm = new DataTable();
                    strSql = @"select a.medicineid_chr from t_aid_makefilmmedicine a";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_dtbMakeFilm);
                    if(m_dtbMakeFilm != null && m_dtbMakeFilm.Rows.Count > 0)
                    {
                        foreach (DataRow dr in m_dtbMakeFilm.Rows)
                        {
                            if (m_strFilter.Length == 0)
                            {
                                m_strFilter = "medicineid_chr = '" + dr["medicineid_chr"].ToString() + "'";
                            }
                            else
                            {
                                m_strFilter = m_strFilter + " or medicineid_chr = '" + dr["medicineid_chr"].ToString() + "'";
                            }
                        }
                        
                            DataView dv = dt.DefaultView;
                            dv.RowFilter = m_strFilter;
                            dt = dv.ToTable();
                    }
                    else
                    {
                        dt.Clear();
                    }
                }
                
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_objTable, objDPArr);

                objHRPSvc.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataView dv = new DataView(dt);
                    dv.Sort = "medicineid_chr desc";
                    dt = dv.ToTable();

                    m_objTable.Columns.Add("medicinename_vch", typeof(String));
                    m_objTable.Columns.Add("medspec_vchr", typeof(String));
                    m_objTable.Columns.Add("opunit_vchr", typeof(String));
                    m_objTable.Columns.Add("productorid_chr", typeof(String));
                    m_objTable.Columns.Add("opoldprice_int", typeof(Double));
                    m_objTable.Columns.Add("newretailprice_int", typeof(Double));
                    m_objTable.Columns.Add("opnewprice_int", typeof(Double));
                    m_objTable.Columns.Add("adjustpricedate_dat", typeof(DateTime));
                    m_objTable.Columns.Add("enddate_dat", typeof(String));
                    m_objTable.Columns.Add("remark_vchr", typeof(String));
                    m_objTable.Columns.Add("assistcode_chr", typeof(string));

                    //int intIdRow = 1;
                    DataRow dr = null;
                    DataRow drTemp1 = null;
                    DataRow drTemp2 = null;
                    DateTime dTimeTemp = new DateTime();
                    int intIsFirst = 0;
                    int iRowCount = dt.Rows.Count;
                    m_objTable.BeginLoadData();
                    for (int i = 0; i < iRowCount; i++)
                    {
                        bool blnExists = false;
                        drTemp1 = dt.Rows[i];
                        dr = m_objTable.NewRow();
                        double dbloldprice = 0d;
                        double dblnewretailprice = 0d;
                        double dblnewprice = 0d;

                        double.TryParse(Convert.ToString(drTemp1["opoldprice_int"]), out dbloldprice);
                        double.TryParse(Convert.ToString(drTemp1["newretailprice_int"]), out dblnewretailprice);
                        double.TryParse(Convert.ToString(drTemp1["opnewprice_int"]), out dblnewprice);

                        dr["medicinename_vch"] = drTemp1["medicinename_vch"];
                        dr["medspec_vchr"] = drTemp1["medspec_vchr"];
                        dr["opunit_vchr"] = drTemp1["opunit_vchr"];
                        dr["productorid_chr"] = drTemp1["productorid_chr"];
                        dr["opoldprice_int"] = Convert.ToDouble(dbloldprice.ToString("0.0000"));
                        dr["newretailprice_int"] = Convert.ToDouble(dblnewretailprice.ToString("0.0000"));
                        dr["opnewprice_int"] = Convert.ToDouble(dblnewprice.ToString("0.0000"));
                        dr["adjustpricedate_dat"] = Convert.ToDateTime(Convert.ToDateTime(drTemp1["adjustpricedate_dat"]).ToString("yyyy-MM-dd HH:mm:ss"));
                        dr["assistcode_chr"] = drTemp1["assistcode_chr"];
                        for (int j = i + 1; j < iRowCount; )
                        {
                            drTemp2 = dt.Rows[j];
                            if (drTemp1["medicineid_chr"].ToString().Trim() == drTemp2["medicineid_chr"].ToString().Trim())
                            {
                                blnExists = true;
                                //intIdRow++;
                            }
                            if (blnExists)
                            {
                                if (intIsFirst != 0)
                                {
                                    dr["enddate_dat"] = dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    dr["enddate_dat"] = "";
                                }
                                intIsFirst = 1;
                                dTimeTemp = Convert.ToDateTime(dr["adjustpricedate_dat"].ToString());
                                break;
                            }
                            else
                            {
                                if (intIsFirst != 0)
                                {
                                    dr["enddate_dat"] = dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    dr["enddate_dat"] = "";
                                }
                                intIsFirst = 0;
                                dTimeTemp = Convert.ToDateTime(dr["adjustpricedate_dat"].ToString());
                                break;
                            }
                        }

                        if (i == iRowCount - 1)
                        {
                            if (i == 0)
                            {
                                dr["enddate_dat"] = "";
                            }
                            else
                            {
                                dr["enddate_dat"] = dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }

                        dr["remark_vchr"] = drTemp1["remark_vchr"];
                        m_objTable.Rows.Add(dr.ItemArray);
                        //if (blnExists)
                        //{
                        //    m_objTable.Rows.Add(dr.ItemArray);
                        //}
                        //else
                        //{
                        //    m_objTable.Rows.Add(dr.ItemArray);
                        //}
                    }
                    m_objTable.EndLoadData();
                    m_objTable.AcceptChanges();
                    dr = null;
                    drTemp1 = null;
                    drTemp2 = null;
                }
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

        #region 药品去向汇总统计数据

        /// <summary>
        /// 药品去向汇总统计数据

        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSearchData(bool blnIsDrugStore, DateTime dtmBegin, DateTime dtmEnd, string strMedStorageid, string strMedTypeid, string strDeptid, out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();
            StringBuilder strSQL = new StringBuilder("");
            if (blnIsDrugStore)
            {
                #region 药房
                strSQL.Append(@"select b.instoredept_chr diagdept_chr,
       case
         when c.deptname_vchr is null then
          '其他'
         else
          c.deptname_vchr
       end deptname_vchr,
       sum(round(a.opretailprice_int * a.ipamount_int / a.packqty_dec, 4)) allprice
  from t_ds_outstorage_detail a,
       t_ds_outstorage        b,
       t_bse_deptdesc         c,
       t_bse_medstore         d,
       t_bse_medicine         e,
       t_aid_medicinetype     f
 where a.seriesid2_int = b.seriesid_int(+)
   and a.status = 1
   and b.instoredept_chr = c.deptid_chr
   and (b.status_int = 2 or b.status_int = 3)
   and b.drugstoreid_chr = d.deptid_chr
   and a.medicineid_chr = e.medicineid_chr(+)
   and e.medicinetypeid_chr = f.medicinetypeid_chr
   and (b.examdate_dat between ? and ?)");
                #endregion
            }
            else
            {
                #region 药库
                strSQL.Append(@"select b.askdept_chr,
       case
         when c.deptname_vchr is null then
          '其他'
         else
          c.deptname_vchr
       end deptname_vchr,
       sum(a.retailprice_int * a.netamount_int) outstorageprice,
       sum(a.retailprice_int * a.netamount_int) retailprice,
       0 retailoutloss
  from t_ms_outstorage_detail a,
       t_ms_outstorage        b,
       t_bse_deptdesc         c,
       t_bse_storage          d,
       t_bse_medicine         e,
       t_aid_medicinetype     f
 where a.seriesid2_int = b.seriesid_int(+)
   and a.status = 1
   and b.askdept_chr = c.deptid_chr
   and (b.status = 2 or b.status = 3)
   and b.storageid_chr = d.storageid_chr
   and a.medicineid_chr = e.medicineid_chr(+)
   and e.medicinetypeid_chr = f.medicinetypeid_chr
   and (b.examdate_dat between ? and ?)");
                #endregion
            }
            try
            {
                int intCount = 2;
                if (strMedStorageid != "0000")
                {
                    if (blnIsDrugStore)
                    {
                        strSQL.Append(@" and d.medstoreid_chr=?");
                    }
                    else
                    {
                        strSQL.Append(@" and d.storageid_chr=?");
                    }
                    intCount++;
                }

                if (!string.IsNullOrEmpty(strMedTypeid))
                {
                    strSQL.Append(@" and f.medicinetypeid_chr=?");
                    intCount++;
                }

                if (!string.IsNullOrEmpty(strDeptid))
                {
                    if (blnIsDrugStore)
                    {
                        strSQL.Append(@" and b.instoredept_chr like ?");
                    }
                    else
                    {
                        strSQL.Append(@" and b.askdept_chr like ?");
                    }
                    intCount++;
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(intCount, out objDPArr);
                objDPArr[0].Value = Convert.ToDateTime(dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[1].Value = Convert.ToDateTime(dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (intCount == 3)
                {
                    if (strMedStorageid != "0000")
                    {
                        objDPArr[2].Value = strMedStorageid;
                    }
                    else if (!string.IsNullOrEmpty(strMedTypeid))
                    {
                        objDPArr[2].Value = strMedTypeid;
                    }
                    else
                    {
                        objDPArr[2].Value = strDeptid + "%";
                    }
                }
                else if (intCount == 4)
                {
                    if (strMedStorageid != "0000")
                    {
                        objDPArr[2].Value = strMedStorageid;
                        if (!string.IsNullOrEmpty(strMedTypeid))
                        {
                            objDPArr[3].Value = strMedTypeid;
                        }
                        else
                        {
                            objDPArr[3].Value = strDeptid + "%";
                        }
                    }
                    else
                    {
                        objDPArr[2].Value = strMedTypeid;
                        objDPArr[3].Value = strDeptid + "%";
                    }
                }
                else if (intCount == 5)
                {
                    objDPArr[2].Value = strMedStorageid;
                    objDPArr[3].Value = strMedTypeid;
                    objDPArr[4].Value = strDeptid + "%";
                }

                if (blnIsDrugStore)
                {
                    strSQL.Append(@"group by b.instoredept_chr, c.deptname_vchr order by c.deptname_vchr");
                }
                else
                {
                    strSQL.Append(@"group by b.askdept_chr, c.deptname_vchr order by c.deptname_vchr");
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref m_objTable, objDPArr);

                objHRPServ.Dispose();
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
