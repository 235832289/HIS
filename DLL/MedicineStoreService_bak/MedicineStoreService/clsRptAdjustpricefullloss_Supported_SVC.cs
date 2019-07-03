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
    /// 
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsRptAdjustpricefullloss_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药库名称
        /// <summary>
        /// 获取药库名称
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetStorageName(out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();
            string strSql = @"select a.medstorename_vchr storagename, a.deptid_chr medstoreid
  from t_bse_medstore a
union all
select distinct y.medicineroomname storagename, y.medicineroomid medstoreid
  from t_ms_medicinestoreroomset y ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_objTable);

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

        #region 药品名称
        /// <summary>
        /// 药品名称
        /// </summary>
        /// <param name="p_strMedName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(string p_cboStorageid, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            StringBuilder strSQL = new StringBuilder("");
            try
            {
                strSQL.Append(@"select t.assistcode_chr,
	                             t.medicinename_vchr,
	                             t.medspec_vchr,
	                             t.opunit_chr,
	                             t.ipunit_chr,
	                             t.packqty_dec,
	                             t.productorid_chr,
	                             t.pycode_chr,
	                             t.wbcode_chr,
	                             t.medicineid_chr,
	                             t.ispoison_chr,
	                             t.ischlorpromazine2_chr,
	                             t.unitprice_mny,
	                             t.medicinetypeid_chr,
	                             t.tradeprice_mny,
	                             t.limitunitprice_mny,
	                             t.opchargeflg_int,
	                             t.ipchargeflg_int,
	                             t.ifstop_int, t.govpriceflag_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
	                            from t_bse_medicine t 
    left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
    left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1");

                //if (p_cboStorageid == "0000")
                //{
                strSQL.Append(@" where t.deleted_int=0  order by t.assistcode_chr");
                //}
//                else if (p_cboStorageid == "0001" || p_cboStorageid == "0002")
//                {
//                    strSQL.Append(@" left join t_ms_storage s on t.medicineid_chr = s.medicineid_chr
//                                     left join t_bse_storage d on d.storageid_chr = s.storageid_chr
//                                     where d.storageid_chr = ?
//                                    order by t.assistcode_chr");
//                }
//                else
//                {
//                    strSQL.Append(@"  left join t_ms_storage s on t.medicineid_chr = s.medicineid_chr
//                                         where exists (select r.deptid_chr
//                                                  from t_bse_medstore r
//                                                 where to_char(r.medicnetype_int) = t.medicinetypeid_chr
//                                                   and r.deptid_chr = ?)
//                                         order by t.assistcode_chr");
//                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                //IDataParameter[] objDPArr = null;
                //if (p_cboStorageid == "0000")
                //{
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL.ToString(), ref dt);
                //}
                //else
                //{
                //    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                //    objDPArr[0].Value = p_cboStorageid;
                //    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dt, objDPArr);
                //}
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }

            return lngRes;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetMedicineType(out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();

            string strSql = @"select t.medicinetypename_vchr,t.medicinetypeid_chr from t_aid_medicinetype t";
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

        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSelectAdjustprice(DateTime strBegin, DateTime strEnd, string m_strStorageid, string m_strTypeid, string strMedid, out DataTable m_dtResult)
        {
            long lngRes = -1;
            m_dtResult = new DataTable();
            string strSql = "";
            //usebyds 为1表示药房，为0表示药库
            if (m_strStorageid == "0000")
            {
                if (m_strTypeid == "0000")
                {
                    if (string.IsNullOrEmpty(strMedid))
                    {
                        strSql = @"select  1 usebyds, i.medicineid_chr, h.medstorename_vchr storagename,
                                           g.medicinename_vch, g.medspec_vchr,
                                           decode(i.opchargeflg_int, 0, g.opunit_vchr, 1, g.ipunit_vchr) as opunit_vchr,
                                           i.productorid_chr, 
                                           g.opoldretailprice_int, g.opnewretailprice_int, g.packqty_dec,
                                           g.ipcurrentgross_int, 
                                           decode(i.opchargeflg_int, 0, g.opcurrentgross_int, 1,
                                                   g.ipcurrentgross_int) as currentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opoldretailprice_int, 1,
                                                   g.ipoldretailprice_int) as oldprice,
                                           decode(i.opchargeflg_int, 0, g.opnewretailprice_int, 1,
                                                   g.ipnewretailprice_int) as newprice, 
                                           f.examdate_dat, g.reason_vchr, i.assistcode_chr
                                      from t_ds_adjustprice f, t_ds_adjustprice_detail g, t_bse_medstore h,
                                           t_bse_medicine i, t_aid_medicinetype j
                                     where f.seriesid_int = g.seriesid2_int(+)
                                       and (f.status_int = 2 or f.status_int = 3)
                                       and g.status_int = 1
                                       and g.drugstoreid_chr = h.deptid_chr(+)
                                       and g.medicineid_chr = i.medicineid_chr(+)
                                       and i.medicinetypeid_chr = j.medicinetypeid_chr(+)
                                       and f.examdate_dat between ? and ?
                                    union all
                                    select 0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ? ";
                    }
                    else
                    {
                        strSql = @"select  1 usebyds, i.medicineid_chr, h.medstorename_vchr storagename,
                                           g.medicinename_vch, g.medspec_vchr,
                                           decode(i.opchargeflg_int, 0, g.opunit_vchr, 1, g.ipunit_vchr) as opunit_vchr,
                                           i.productorid_chr, g.opoldretailprice_int, g.opnewretailprice_int,
                                           g.packqty_dec, g.ipcurrentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opcurrentgross_int, 1,
                                                   g.ipcurrentgross_int) as currentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opoldretailprice_int, 1,
                                                   g.ipoldretailprice_int) as oldprice,
                                           decode(i.opchargeflg_int, 0, g.opnewretailprice_int, 1,
                                                   g.ipnewretailprice_int) as newprice, f.examdate_dat,
                                           g.reason_vchr, i.assistcode_chr
                                      from t_ds_adjustprice f, t_ds_adjustprice_detail g, t_bse_medstore h,
                                           t_bse_medicine i, t_aid_medicinetype j
                                     where f.seriesid_int = g.seriesid2_int(+)
                                       and (f.status_int = 2 or f.status_int = 3)
                                       and g.status_int = 1
                                       and g.drugstoreid_chr = h.deptid_chr(+)
                                       and g.medicineid_chr = i.medicineid_chr(+)
                                       and i.medicinetypeid_chr = j.medicinetypeid_chr(+)
                                       and f.examdate_dat between ? and ?
                                       and i.medicineid_chr = ?
                                    union all
                                    select 0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and d.medicineid_chr = ?";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedid))
                    {
                        strSql = @"select  1 usebyds, i.medicineid_chr, h.medstorename_vchr storagename,
                                           g.medicinename_vch, g.medspec_vchr,
                                           decode(i.opchargeflg_int, 0, g.opunit_vchr, 1, g.ipunit_vchr) as opunit_vchr,
                                           i.productorid_chr, g.opoldretailprice_int, g.opnewretailprice_int,
                                           g.packqty_dec, g.ipcurrentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opcurrentgross_int, 1,
                                                   g.ipcurrentgross_int) as currentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opoldretailprice_int, 1,
                                                   g.ipoldretailprice_int) as oldprice,
                                           decode(i.opchargeflg_int, 0, g.opnewretailprice_int, 1,
                                                   g.ipnewretailprice_int) as newprice, f.examdate_dat,
                                           g.reason_vchr, i.assistcode_chr
                                      from t_ds_adjustprice f, t_ds_adjustprice_detail g, t_bse_medstore h,
                                           t_bse_medicine i, t_aid_medicinetype j
                                     where f.seriesid_int = g.seriesid2_int(+)
                                       and (f.status_int = 2 or f.status_int = 3)
                                       and g.status_int = 1
                                       and g.drugstoreid_chr = h.deptid_chr(+)
                                       and g.medicineid_chr = i.medicineid_chr(+)
                                       and i.medicinetypeid_chr = j.medicinetypeid_chr(+)
                                       and f.examdate_dat between ? and ?
                                       and j.medicinetypeid_chr = ?
                                    union all
                                    select 0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and e.medicinetypeid_chr = ? ";
                    }
                    else
                    {
                        strSql = @"select  1 usebyds, i.medicineid_chr, h.medstorename_vchr storagename,
                                           g.medicinename_vch, g.medspec_vchr,
                                           decode(i.opchargeflg_int, 0, g.opunit_vchr, 1, g.ipunit_vchr) as opunit_vchr,
                                           i.productorid_chr, g.opoldretailprice_int, g.opnewretailprice_int,
                                           g.packqty_dec, g.ipcurrentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opcurrentgross_int, 1,
                                                   g.ipcurrentgross_int) as currentgross_int,
                                           decode(i.opchargeflg_int, 0, g.opoldretailprice_int, 1,
                                                   g.ipoldretailprice_int) as oldprice,
                                           decode(i.opchargeflg_int, 0, g.opnewretailprice_int, 1,
                                                   g.ipnewretailprice_int) as newprice, f.examdate_dat,
                                           g.reason_vchr, i.assistcode_chr
                                      from t_ds_adjustprice f, t_ds_adjustprice_detail g, t_bse_medstore h,
                                           t_bse_medicine i, t_aid_medicinetype j
                                     where f.seriesid_int = g.seriesid2_int(+)
                                       and (f.status_int = 2 or f.status_int = 3)
                                       and g.status_int = 1
                                       and g.drugstoreid_chr = h.deptid_chr(+)
                                       and g.medicineid_chr = i.medicineid_chr(+)
                                       and i.medicinetypeid_chr = j.medicinetypeid_chr(+)
                                       and f.examdate_dat between ? and ?
                                       and j.medicinetypeid_chr = ?
                                       and i.medicineid_chr = ?
                                    union all
                                    select 0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and e.medicinetypeid_chr = ?
                                       and d.medicineid_chr = ? ";
                    }
                }
            }
            else if (m_strStorageid == "0001" || m_strStorageid == "0002")
            {
                if (m_strTypeid == "0000")
                {
                    if (string.IsNullOrEmpty(strMedid))
                    {
                        strSql = @"select  0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and c.storageid_chr = ? ";
                    }
                    else
                    {
                        strSql = @"select  0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and c.storageid_chr = ?
                                       and d.medicineid_chr = ? ";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedid))
                    {
                        strSql = @"select  0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and c.storageid_chr = ?
                                       and e.medicinetypeid_chr = ?";
                    }
                    else
                    {
                        strSql = @"select  0 usebyds, d.medicineid_chr, c.medicineroomname storagename,
                                           b.medicinename_vch, b.medspec_vchr, b.opunit_vchr, d.productorid_chr,
                                           0 opoldretailprice_int, 0 opnewretailprice_int, 0 packqty_dec,
                                           0 ipcurrentgross_int, b.currentgross_int,
                                           b.oldretailprice_int oldprice, b.newretailprice_int newprice,
                                           a.examdate_dat, b.reason_vchr, d.assistcode_chr
                                      from t_ms_adjustprice a, t_ms_adjustprice_detail b,
                                           (select distinct y.medicineroomid storageid_chr, y.medicineroomname
                                               from t_ms_medicinestoreroomset y) c, t_bse_medicine d,
                                           t_aid_medicinetype e
                                     where a.seriesid_int = b.seriesid2_int(+)
                                       and a.storageid_chr = c.storageid_chr(+)
                                       and (a.formstate_int = 2 or a.formstate_int = 3)
                                       and b.status_int = 1
                                       and b.medicineid_chr = d.medicineid_chr(+)
                                       and d.medicinetypeid_chr = e.medicinetypeid_chr(+)
                                       and a.examdate_dat between ? and ?
                                       and c.storageid_chr = ?
                                       and e.medicinetypeid_chr = ?
                                       and d.medicineid_chr = ?";
                    }
                }
            }
            else
            {
                if (m_strTypeid == "0000")
                {
                    if (string.IsNullOrEmpty(strMedid))
                    {
                        strSql = @"select 1 usebyds,i.medicineid_chr,h.medstorename_vchr storagename,g.medicinename_vch,
                                       g.medspec_vchr,decode(i.opchargeflg_int,0,g.opunit_vchr,
                                       1,g.ipunit_vchr) as opunit_vchr,i.productorid_chr,
                                       
                                       g.opoldretailprice_int,
                                       g.opnewretailprice_int,
                                       g.packqty_dec,
                                       g.ipcurrentgross_int,
                                       
                                       decode(i.opchargeflg_int,0,g.opcurrentgross_int,
                                       1,g.ipcurrentgross_int) as currentgross_int,
                                       decode(i.opchargeflg_int,0,g.opoldretailprice_int,
                                       1,g.ipoldretailprice_int) as oldprice,
                                       decode(i.opchargeflg_int,0,g.opnewretailprice_int,
                                       1,g.ipnewretailprice_int) as newprice,
                                       
                                       f.examdate_dat,g.reason_vchr, i.assistcode_chr
                                from t_ds_adjustprice f,t_ds_adjustprice_detail g,t_bse_medstore h,
                                     t_bse_medicine i,t_aid_medicinetype j
                                where f.seriesid_int=g.seriesid2_int(+)
                                  and (f.status_int=2 or f.status_int=3)
                                  and g.status_int=1
                                  and g.drugstoreid_chr=h.deptid_chr(+)
                                  and g.medicineid_chr=i.medicineid_chr(+)
                                  and i.medicinetypeid_chr=j.medicinetypeid_chr(+)
                                  and f.examdate_dat between ? and ?
                                  and h.deptid_chr=?";
                    }
                    else
                    {
                        strSql = @"select 1 usebyds,i.medicineid_chr,h.medstorename_vchr storagename,g.medicinename_vch,
                                       g.medspec_vchr,decode(i.opchargeflg_int,0,g.opunit_vchr,
                                       1,g.ipunit_vchr) as opunit_vchr,i.productorid_chr,
                                       
                                       g.opoldretailprice_int,
                                       g.opnewretailprice_int,
                                       g.packqty_dec,
                                       g.ipcurrentgross_int,
                                       
                                       decode(i.opchargeflg_int,0,g.opcurrentgross_int,
                                       1,g.ipcurrentgross_int) as currentgross_int,
                                       decode(i.opchargeflg_int,0,g.opoldretailprice_int,
                                       1,g.ipoldretailprice_int) as oldprice,
                                       decode(i.opchargeflg_int,0,g.opnewretailprice_int,
                                       1,g.ipnewretailprice_int) as newprice,
                                       
                                       f.examdate_dat,g.reason_vchr, i.assistcode_chr
                                from t_ds_adjustprice f,t_ds_adjustprice_detail g,t_bse_medstore h,
                                     t_bse_medicine i,t_aid_medicinetype j
                                where f.seriesid_int=g.seriesid2_int(+)
                                  and (f.status_int=2 or f.status_int=3)
                                  and g.status_int=1
                                  and g.drugstoreid_chr=h.deptid_chr(+)
                                  and g.medicineid_chr=i.medicineid_chr(+)
                                  and i.medicinetypeid_chr=j.medicinetypeid_chr(+)
                                  and f.examdate_dat between ? and ?
                                  and h.deptid_chr=?
                                  and i.medicineid_chr = ?";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strMedid))
                    {
                        strSql = @"select 1 usebyds,i.medicineid_chr,h.medstorename_vchr storagename,g.medicinename_vch,
                                       g.medspec_vchr,decode(i.opchargeflg_int,0,g.opunit_vchr,
                                       1,g.ipunit_vchr) as opunit_vchr,i.productorid_chr,
                                       
                                       g.opoldretailprice_int,
                                       g.opnewretailprice_int,
                                       g.packqty_dec,
                                       g.ipcurrentgross_int,
                                       
                                       decode(i.opchargeflg_int,0,g.opcurrentgross_int,
                                       1,g.ipcurrentgross_int) as currentgross_int,
                                       decode(i.opchargeflg_int,0,g.opoldretailprice_int,
                                       1,g.ipoldretailprice_int) as oldprice,
                                       decode(i.opchargeflg_int,0,g.opnewretailprice_int,
                                       1,g.ipnewretailprice_int) as newprice,
                                       
                                       f.examdate_dat,g.reason_vchr, i.assistcode_chr
                                from t_ds_adjustprice f,t_ds_adjustprice_detail g,t_bse_medstore h,
                                     t_bse_medicine i,t_aid_medicinetype j
                                where f.seriesid_int=g.seriesid2_int(+)
                                  and (f.status_int=2 or f.status_int=3)
                                  and g.status_int=1
                                  and g.drugstoreid_chr=h.deptid_chr(+)
                                  and g.medicineid_chr=i.medicineid_chr(+)
                                  and i.medicinetypeid_chr=j.medicinetypeid_chr(+)
                                  and f.examdate_dat between ? and ?
                                  and h.deptid_chr=?
                                  and j.medicinetypeid_chr=?";
                    }
                    else
                    {
                        strSql = @"select 1 usebyds,i.medicineid_chr,h.medstorename_vchr storagename,g.medicinename_vch,
                                       g.medspec_vchr,decode(i.opchargeflg_int,0,g.opunit_vchr,
                                       1,g.ipunit_vchr) as opunit_vchr,i.productorid_chr,
                                       
                                       g.opoldretailprice_int,
                                       g.opnewretailprice_int,
                                       g.packqty_dec,
                                       g.ipcurrentgross_int,
                                       
                                       decode(i.opchargeflg_int,0,g.opcurrentgross_int,
                                       1,g.ipcurrentgross_int) as currentgross_int,
                                       decode(i.opchargeflg_int,0,g.opoldretailprice_int,
                                       1,g.ipoldretailprice_int) as oldprice,
                                       decode(i.opchargeflg_int,0,g.opnewretailprice_int,
                                       1,g.ipnewretailprice_int) as newprice,
                                       
                                       f.examdate_dat,g.reason_vchr, i.assistcode_chr
                                from t_ds_adjustprice f,t_ds_adjustprice_detail g,t_bse_medstore h,
                                     t_bse_medicine i,t_aid_medicinetype j
                                where f.seriesid_int=g.seriesid2_int(+)
                                  and (f.status_int=2 or f.status_int=3)
                                  and g.status_int=1
                                  and g.drugstoreid_chr=h.deptid_chr(+)
                                  and g.medicineid_chr=i.medicineid_chr(+)
                                  and i.medicinetypeid_chr=j.medicinetypeid_chr(+)
                                  and f.examdate_dat between ? and ?
                                  and h.deptid_chr=?
                                  and j.medicinetypeid_chr=?
                                  and i.medicineid_chr = ?";
                    }
                }
            }
            
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                int j = 0;

                if (m_strStorageid == "0000")
                {
                    if (m_strTypeid == "0000")
                    {
                        if (string.IsNullOrEmpty(strMedid))
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(6, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = strMedid;
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = strMedid;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strMedid))
                        {
                            objHRPSvc.CreateDatabaseParameter(6, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strTypeid;
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(8, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strTypeid;
                            objDPArr[j++].Value = strMedid;
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strTypeid;
                            objDPArr[j++].Value = strMedid;
                        }
                    }
                }
                else if (m_strStorageid == "0001" || m_strStorageid == "0002")
                {
                    if (m_strTypeid == "0000")
                    {
                        if (string.IsNullOrEmpty(strMedid))
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                            objDPArr[j++].Value = strMedid;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strMedid))
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                            objDPArr[j++].Value = m_strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                            objDPArr[j++].Value = m_strTypeid;
                            objDPArr[j++].Value = strMedid;
                        }
                    }
                }
                else
                {
                    if (m_strTypeid == "0000")
                    {
                        if (string.IsNullOrEmpty(strMedid))
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                            objDPArr[j++].Value = strMedid;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strMedid))
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                            objDPArr[j++].Value = m_strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                            objDPArr[j++].Value = Convert.ToDateTime(strBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = Convert.ToDateTime(strEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                            objDPArr[j++].Value = m_strStorageid;
                            objDPArr[j++].Value = m_strTypeid;
                            objDPArr[j++].Value = strMedid;
                        }
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtResult,objDPArr);



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
