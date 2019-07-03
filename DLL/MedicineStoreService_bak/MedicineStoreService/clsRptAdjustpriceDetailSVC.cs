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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRptAdjustpriceDetailSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
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
        public long m_mthSelectAdjustData(int intDsOrMs, DateTime strBegin, DateTime strEnd, string strMedicineType, string strMedicineid, out DataTable m_objTable)
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
                        strSql = @"select b.medicinename_vch,
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
                                     c.medicineid_chr
                                from t_ds_adjustprice a,
                                     t_ds_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and (a.status_int=2 or a.status_int=3)
                                 and b.status_int=1
                                 and a.examdate_dat between ? and ?  order by c.medicinename_vchr, c.medicineid_chr, a.examdate_dat desc";
                    }
                    else
                    {
                        strSql = @"select b.medicinename_vch,
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
                                     c.medicineid_chr
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
                                 and a.examdate_dat between ? and ?  order by c.medicinename_vchr, c.medicineid_chr, a.examdate_dat desc";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {

                        strSql = @"select b.medicinename_vch,
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
                                     c.medicineid_chr
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
                                 and a.examdate_dat between ? and ?  order by c.medicinename_vchr, c.medicineid_chr, a.examdate_dat desc";
                    }
                    else
                    {
                        strSql = @"select b.medicinename_vch,
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
                                     c.medicineid_chr
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
                                 and d.medicinetypeid_chr=?
                                 and a.examdate_dat between ? and ?  order by c.medicinename_vchr, c.medicineid_chr, a.examdate_dat desc";
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
                        strSql = @"select b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and a.adjustpricedate_dat between ? and ?
                             order by c.medicinename_vchr, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                    else
                    {
                        strSql = @"select b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+) and b.medicineid_chr = ?
                                 and a.adjustpricedate_dat between ? and ?
                             order by c.medicinename_vchr, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedicineid))
                    {
                        strSql = @"select b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and d.medicinetypeid_chr=?
                                 and a.adjustpricedate_dat between ? and ?
                             order by c.medicinename_vchr, c.medicineid_chr, a.adjustpricedate_dat desc";
                    }
                    else
                    {
                        strSql = @"select b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_vchr,
       c.productorid_chr,
       b.newretailprice_int,
       round(b.newretailprice_int / c.packqty_dec, 4) opnewprice_int,
       a.adjustpricedate_dat,
       b.reason_vchr remark_vchr,
       c.medicineid_chr,
       b.oldretailprice_int opoldprice_int
                                from t_ms_adjustprice a,
                                     t_ms_adjustprice_detail b,
                                     t_bse_medicine c,
                                     t_aid_medicinetype d
                               where a.seriesid_int=b.seriesid2_int(+)
                                 and b.medicineid_chr=c.medicineid_chr(+)
                                 and c.medicinetypeid_chr=d.medicinetypeid_chr(+)
                                 and d.medicinetypeid_chr=? and b.medicineid_chr = ?
                                 and a.adjustpricedate_dat between ? and ? 
                             order by c.medicinename_vchr, c.medicineid_chr, a.adjustpricedate_dat desc";
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
                        objDPArr[n++].Value = strMedicineid;
                        objDPArr[n++].Value = strMedicineType;
                        objDPArr[n++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[n++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dt, objDPArr);

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

                    //int intIdRow = 1;
                    DataRow dr = null;
                    DataRow drTemp1 = null;
                    DataRow drTemp2 = null;
                    DateTime dTimeTemp = new DateTime();
                    int intIsFirst = 0;
                    int iRowCount = dt.Rows.Count;
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
                        if (blnExists)
                        {
                            m_objTable.Rows.Add(dr.ItemArray);
                        }
                        else
                        {
                            m_objTable.Rows.Add(dr.ItemArray);
                            //if (intIdRow > 1)
                            //{
                            //    dr["medicinename_vch"] = drTemp1["medicinename_vch"];
                            //    dr["medspec_vchr"] = drTemp1["medspec_vchr"];
                            //    dr["opunit_vchr"] = drTemp1["opunit_vchr"];
                            //    dr["productorid_chr"] = drTemp1["productorid_chr"];
                            //    dr["opoldprice_int"] = Convert.ToDouble(Convert.ToDouble(drTemp1["opoldprice_int"]).ToString("0.0000"));
                            //    dr["newretailprice_int"] = Convert.ToDouble(Convert.ToDouble(drTemp1["newretailprice_int"]).ToString("0.0000"));
                            //    dr["opnewprice_int"] = Convert.ToDouble(Convert.ToDouble(drTemp1["opnewprice_int"]).ToString("0.0000"));
                            //    dr["adjustpricedate_dat"] = Convert.ToDateTime(Convert.ToDateTime(drTemp1["adjustpricedate_dat"]).ToString("yyyy-MM-dd HH:mm:ss"));
                            //    dr["enddate_dat"] = Convert.ToDateTime(dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                            //    dr["remark_vchr"] = drTemp1["remark_vchr"];
                            //    m_objTable.Rows.Add(dr.ItemArray);
                            //}
                            //intIdRow = 1;
                        }
                    }
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
            //long lngRes1 = -1;
            long lngRes2=-1;
            m_objTable = new DataTable();
            //DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            //StringBuilder strSQL1 = new StringBuilder("");
            StringBuilder strSQL2 = new StringBuilder("");
            if (blnIsDrugStore)
            {
                #region 药房
//                strSQL1.Append(@"select b.diagdept_chr,
//                                      case
//                                          when c.deptname_vchr is null then
//                                          '其他'
//                                          else
//                                               c.deptname_vchr
//                                           end deptname_vchr,
//                                      case
//                                          when a.type_int=1 then
//                                               a.ipretailprice_int*(-1)
//                                          when a.type_int=2 then
//                                               a.ipretailprice_int
//                                           end ipretailprice_int,
//                                           a.ipamount_int
//                              from t_ds_recipeaccount_detail a,
//                                   t_opr_outpatientrecipe b,
//                                   t_bse_deptdesc c,
//                                   t_bse_medstore d,
//                                   t_aid_medicinetype e
//                              where a.outpatrecipeid_chr=b.outpatrecipeid_chr(+)
//                                and b.diagdept_chr=c.deptid_chr(+)
//                                and a.drugstoreid_int=d.deptid_chr(+)
//                                and a.medicinetypeid_chr=e.medicinetypeid_chr
//                                and (a.operatedate_dat between ? and ?)");

                strSQL2.Append(@"select b.instoredept_chr diagdept_chr,
                                       case
                                           when c.deptname_vchr is null then
                                           '其他'
                                           else
                                              c.deptname_vchr
                                           end deptname_vchr,
                                           a.ipretailprice_int as ipretailprice_int,
                                           a.ipamount_int
                                      from t_ds_outstorage_detail a,
                                           t_ds_outstorage b,
                                           t_bse_deptdesc c,
                                           t_bse_medstore d,
                                           t_bse_medicine e,
                                           t_aid_medicinetype f
                                     where a.seriesid2_int=b.seriesid_int(+)
                                       and a.status=1
                                       and b.instoredept_chr=c.deptid_chr
                                       and (b.status_int=2 or b.status_int=3)
                                       and b.drugstoreid_chr=d.deptid_chr
                                       and a.medicineid_chr=e.medicineid_chr(+)
                                       and e.medicinetypeid_chr=f.medicinetypeid_chr
                                       and (b.examdate_dat between ? and ?)");
                #endregion
            }
            else
            {
                #region 药库
//                strSQL1.Append(@"select b.diagdept_chr,
//                                      case
//                                          when c.deptname_vchr is null then
//                                          '其他'
//                                          else
//                                               c.deptname_vchr
//                                           end deptname_vchr,
//                                      case
//                                          when a.type_int=1 then
//                                               a.ipretailprice_int*(-1)
//                                          when a.type_int=2 then
//                                               a.ipretailprice_int
//                                           end ipretailprice_int,
//                                           a.ipamount_int
//                              from t_ds_recipeaccount_detail a,
//                                   t_opr_outpatientrecipe b,
//                                   t_bse_deptdesc c,
//                                   t_bse_medstore d,
//                                   t_aid_medicinetype e
//                              where a.outpatrecipeid_chr=b.outpatrecipeid_chr(+)
//                                and b.diagdept_chr=c.deptid_chr(+)
//                                and a.drugstoreid_int=d.deptid_chr(+)
//                                and a.medicinetypeid_chr=e.medicinetypeid_chr
//                                and (a.operatedate_dat between ? and ?)");

                strSQL2.Append(@"select b.askdept_chr,
                                       case
                                           when c.deptname_vchr is null then
                                           '其他'
                                           else
                                              c.deptname_vchr
                                           end deptname_vchr,
                                           a.retailprice_int,
                                           a.netamount_int                                
                                      from t_ms_outstorage_detail a,
                                           t_ms_outstorage b,
                                           t_bse_deptdesc c,
                                           t_bse_storage d,
                                           t_bse_medicine e,
                                           t_aid_medicinetype f
                                     where a.seriesid2_int=b.seriesid_int(+)
                                       and a.status=1
                                       and b.askdept_chr=c.deptid_chr
                                       and (b.status=2 or b.status=3)
                                       and b.storageid_chr=d.storageid_chr
                                       and a.medicineid_chr=e.medicineid_chr(+)
                                       and e.medicinetypeid_chr=f.medicinetypeid_chr
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
                        //strSQL1.Append(@" and d.medstoreid_chr=?");
                        strSQL2.Append(@" and d.medstoreid_chr=?");
                    }
                    else
                    {
                        strSQL2.Append(@" and d.storageid_chr=?");
                    }
                    intCount++;
                }

                if (!string.IsNullOrEmpty(strMedTypeid))
                {
                    //if (blnIsDrugStore)
                    //{
                    //    strSQL1.Append(@" and e.medicinetypeid_chr=?");
                    //}
                    strSQL2.Append(@" and f.medicinetypeid_chr=?");
                    intCount++;
                }

                if (!string.IsNullOrEmpty(strDeptid))
                {
                    if (blnIsDrugStore)
                    {
                        //strSQL1.Append(@" and b.diagdept_chr like ?");
                        strSQL2.Append(@" and b.instoredept_chr like ?");
                    }
                    else
                    {
                        strSQL2.Append(@" and b.askdept_chr like ?");
                    }
                    intCount++;
                }

               
                //clsHRPTableService objHRPServ1 = new clsHRPTableService();
                //IDataParameter[] objDPArr1 = null;
                //objHRPServ1.CreateDatabaseParameter(intCount, out objDPArr1);
                //objDPArr1[0].Value = Convert.ToDateTime(dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                //objDPArr1[1].Value = Convert.ToDateTime(dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                
                clsHRPTableService objHRPServ2 = new clsHRPTableService();
                IDataParameter[] objDPArr2 = null;
                objHRPServ2.CreateDatabaseParameter(intCount, out objDPArr2);
                objDPArr2[0].Value = Convert.ToDateTime(dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr2[1].Value = Convert.ToDateTime(dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (intCount == 3)
                {
                    if (strMedStorageid != "0000")
                    {
                        //if (blnIsDrugStore)
                        //{
                        //    objDPArr1[2].Value = strMedStorageid;
                        //}
                        objDPArr2[2].Value = strMedStorageid;
                    }
                    else if (!string.IsNullOrEmpty(strMedTypeid))
                    {
                        //if (blnIsDrugStore)
                        //{
                        //    objDPArr1[2].Value = strMedTypeid;
                        //}
                        objDPArr2[2].Value = strMedTypeid;
                    }
                    else
                    {
                        //if (blnIsDrugStore)
                        //{
                        //    objDPArr1[2].Value = strDeptid + "%";
                        //}
                        objDPArr2[2].Value = strDeptid + "%";
                    }
                }
                else if (intCount == 4)
                {
                    if (strMedStorageid != "0000")
                    {
                        //if (blnIsDrugStore)
                        //{
                        //    objDPArr1[2].Value = strMedStorageid;
                        //}
                        objDPArr2[2].Value = strMedStorageid;
                        if (!string.IsNullOrEmpty(strMedTypeid))
                        {
                            //if (blnIsDrugStore)
                            //{
                            //    objDPArr1[3].Value = strMedTypeid;
                            //}
                            objDPArr2[3].Value = strMedTypeid;
                        }
                        else
                        {
                            //if (blnIsDrugStore)
                            //{
                            //    objDPArr1[3].Value = strDeptid + "%";
                            //}
                            objDPArr2[3].Value = strDeptid + "%";
                        }
                    }
                    else
                    {
                        //if (blnIsDrugStore)
                        //{
                        //    objDPArr1[2].Value = strMedTypeid;
                        //    objDPArr1[3].Value = strDeptid + "%";
                        //}
                        objDPArr2[2].Value = strMedTypeid;
                        objDPArr2[3].Value = strDeptid + "%";
                    }
                }
                else if (intCount == 5)
                {
                    //if (blnIsDrugStore)
                    //{
                    //    objDPArr1[2].Value = strMedStorageid;
                    //    objDPArr1[3].Value = strMedTypeid;
                    //    objDPArr1[4].Value = strDeptid + "%";
                    //}
                    objDPArr2[2].Value = strMedStorageid;
                    objDPArr2[3].Value = strMedTypeid;
                    objDPArr2[4].Value = strDeptid + "%";
                }

                //if (blnIsDrugStore)
                //{
                //    lngRes1 = objHRPServ1.lngGetDataTableWithParameters(strSQL1.ToString(), ref dt1, objDPArr1);
                //}
                lngRes2 = objHRPServ2.lngGetDataTableWithParameters(strSQL2.ToString(), ref dt2, objDPArr2);

                lngRes = lngRes2;

                //if (blnIsDrugStore)
                //{
                //    objHRPServ1.Dispose();

                //    if (dt1.Rows.Count > 0)
                //    {
                //        lngRes = lngRes1;
                //    }
                //    else if (dt2.Rows.Count > 0)
                //    {
                //        lngRes = lngRes2;
                //    }
                //}
                //else
                //{
                //    if (dt2.Rows.Count > 0)
                //    {
                //        lngRes = lngRes2;
                //    }
                //}

                objHRPServ2.Dispose();
                if (blnIsDrugStore)
                {
                    #region 药房
                    m_objTable.Columns.Add("diagdept_chr", typeof(String));
                    m_objTable.Columns.Add("deptname_vchr", typeof(String));
                    m_objTable.Columns.Add("allprice", typeof(Double));

                    //DataRow dr = null;
                    //dt1.BeginLoadData();
                    //for (int i = 0; i < dt2.Rows.Count; i++)
                    //{
                    //    dr = dt1.NewRow();
                    //    dr = dt2.Rows[i];
                    //    dt1.Rows.Add(dr.ItemArray);
                    //}
                    //dt1.AcceptChanges();
                    //dt1.EndLoadData();

                    DataView dv = new DataView(dt2);
                    dv.Sort = "diagdept_chr asc";
                    dt2 = dv.ToTable();

                    DataRow dr1 = null;
                    DataRow dr2 = null;
                    dr1 = m_objTable.NewRow();

                    double dblamount = 0d;
                    double dblprice = 0d;
                    double dblsum = 0d;
                    double dblallsum = 0d;
                    int iRowCount = dt2.Rows.Count;
                    for (int i = 0; i < iRowCount; i++)
                    {
                        dr2 = dt2.Rows[i];
                        if (blnIsExists(blnIsDrugStore, dr2["diagdept_chr"].ToString().Trim(), ref m_objTable))
                        {
                            continue;
                        }
                        for (int j = i; j < iRowCount; j++)
                        {
                            if (dr2["diagdept_chr"].ToString().Trim() == dt2.Rows[j]["diagdept_chr"].ToString().Trim())
                            {
                                double.TryParse(Convert.ToString(dt2.Rows[j]["ipretailprice_int"]), out dblprice);
                                double.TryParse(Convert.ToString(dt2.Rows[j]["ipamount_int"]), out dblamount);
                                dblsum = dblprice * dblamount;
                                dblallsum += dblsum;
                            }
                        }
                        dr1["diagdept_chr"] = dr2["diagdept_chr"];
                        dr1["deptname_vchr"] = dr2["deptname_vchr"];
                        dr1["allprice"] = Convert.ToDouble(dblallsum.ToString("0.0000"));
                        m_objTable.Rows.Add(dr1.ItemArray);
                        dblallsum = 0d;
                    }
                    m_objTable.AcceptChanges();
                    //dr = null;
                    dr1 = null;
                    dr2 = null;
                    //dt1 = null;
                    dt2 = null;
                    #endregion
                }
                else
                {
                    #region 药库
                    m_objTable.Columns.Add("askdept_chr", typeof(String));
                    m_objTable.Columns.Add("deptname_vchr", typeof(String));
                    m_objTable.Columns.Add("outstorageprice",typeof(Double));
                    m_objTable.Columns.Add("retailprice",typeof(Double));
                    m_objTable.Columns.Add("retailoutloss", typeof(Double));

                    DataView dv2 = new DataView(dt2);
                    dv2.Sort = "askdept_chr asc";
                    dt2 = dv2.ToTable();

                    DataRow drTemp1 = null;
                    DataRow drTemp2 = null;
                    drTemp1 = m_objTable.NewRow();

                    //a.retailprice_int,
                   //a.netamount_int

                    double dblretailprice = 0d;
                    double dblamount = 0d;
                    double dblsum = 0d;
                    double dblretailsum = 0d;
                    double dblloss = 0d;
                    int iRowsCount = dt2.Rows.Count;
                    for (int i1 = 0; i1 < iRowsCount; i1++)
                    {
                        drTemp2 = dt2.Rows[i1];
                        if (blnIsExists(blnIsDrugStore, drTemp2["askdept_chr"].ToString().Trim(), ref m_objTable))
                        {
                            continue;
                        }
                        for (int j2 = 0; j2 < iRowsCount; j2++)
                        {
                            if (drTemp2["askdept_chr"].ToString().Trim() == dt2.Rows[j2]["askdept_chr"].ToString().Trim())
                            {
                                double.TryParse(Convert.ToString(dt2.Rows[j2]["retailprice_int"]), out dblretailprice);
                                double.TryParse(Convert.ToString(dt2.Rows[j2]["netamount_int"]), out dblamount);
                                dblsum = dblretailprice * dblamount;
                                dblretailsum += dblsum;
                            }
                        }
                        drTemp1["askdept_chr"] = drTemp2["askdept_chr"];
                        drTemp1["deptname_vchr"] = drTemp2["deptname_vchr"];
                        drTemp1["outstorageprice"] = dblretailsum;
                        drTemp1["retailprice"] = dblretailsum;
                        drTemp1["retailoutloss"] = dblloss;
                        m_objTable.Rows.Add(drTemp1.ItemArray);
                        dblretailsum = 0d;
                    }
                    m_objTable.AcceptChanges();
                    drTemp1 = null;
                    drTemp2 = null;
                    dt2 = null;

                    #endregion
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

        private bool blnIsExists(bool p_blnIsDrugStore, string p_diagdept_chr, ref DataTable m_objTable)
        {
            bool blnExistid = false;
            if (p_blnIsDrugStore)
            {
                for (int iOr = 0; iOr < m_objTable.Rows.Count; iOr++)
                {
                    if (m_objTable.Rows[iOr]["diagdept_chr"].ToString().Trim() == p_diagdept_chr)
                    {
                        blnExistid = true;
                        break;
                    }
                }
            }
            else
            {
                for (int iOr = 0; iOr < m_objTable.Rows.Count; iOr++)
                {
                    if (m_objTable.Rows[iOr]["askdept_chr"].ToString().Trim() == p_diagdept_chr)
                    {
                        blnExistid = true;
                        break;
                    }
                }
            }
            return blnExistid;
        }
        #endregion
    }
}
