using System;
using System.Collections;
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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsQueryMedicinePriceSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 药品名称
        /// <summary>
        /// 药品名称
        /// </summary>
        /// <param name="p_strMedName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthShowMedName(string p_strMedName, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            if (p_strMedName == null)
            {
                p_strMedName = string.Empty;
            }
            try
            {
                string strSQL = @"select t.assistcode_chr,
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
			                             t.ifstop_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
	                            from t_bse_medicine t 
    left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
    left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
                             where t.medicinename_vchr like ? and t.deleted_int=0
                             order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedName + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }

            return lngRes;
        }
        #endregion

        #region 此方法太啰嗦，已舍弃
        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="p_m_dtTableBegin"></param>
        /// <param name="p_m_dtTableEnd"></param>
        /// <param name="strMedicineid"></param>
        /// <param name="m_m_dtTableTable"></param>
        /// <returns></returns>
        [AutoComplete]
        [Obsolete("此方法太啰嗦，已舍弃  -- 20080703 by shaowei.zheng", true)]
        public long m_mthGetMedicine_Old(DateTime p_dtBegin, DateTime p_dtEnd, string strMedicineid, out DataTable m_dtTable)
        {
            long lngRes = 0;

            long lngRes1 = 0;
            long lngRes2 = 0;
            m_dtTable = new DataTable();
            DataTable m_dtTable2 = new DataTable();
            DataTable dtTemp1 = new DataTable();
            DataTable dtTemp2 = new DataTable();

            StringBuilder strSQL1 = new StringBuilder("");
            StringBuilder strSQL2 = new StringBuilder("");
            try
            {
                strSQL1.Append(@"select b.medicinename_vch,
                                        b.medspec_vchr,
                                        b.opunit_vchr,
                                        c.productorid_chr,
                                        b.oldretailprice_int,
                                        b.newretailprice_int,
                                        c.packqty_dec,
                                        a.examdate_dat,
                                        b.reason_vchr,
                                        c.medicineid_chr
                                   from t_ms_adjustprice a,
                                        t_ms_adjustprice_detail b,
                                        t_bse_medicine c
                                  where a.seriesid_int=b.seriesid2_int(+)
                                    and a.formstate_int=2
                                    and b.status_int=1
                                    and b.medicineid_chr=c.medicineid_chr(+)
                                    and a.examdate_dat between ? and ?");

                strSQL2.Append(@"select b.medicinename_vch,
                                        b.medspec_vchr,
                                        b.opunit_vchr,
                                        c.productorid_chr,
                                        b.oldretailprice_int,
                                        b.newretailprice_int,
                                        c.packqty_dec,
                                        a.examdate_dat,
                                        b.reason_vchr,
                                        c.medicineid_chr
                                   from t_ms_adjustprice a,
                                        t_ms_adjustprice_detail b,
                                        t_bse_medicine c
                                  where a.seriesid_int=b.seriesid2_int(+)
                                    and a.formstate_int=3
                                    and b.status_int=1
                                    and b.medicineid_chr=c.medicineid_chr(+)
                                    and a.examdate_dat between ? and ?");

                if (strMedicineid != "")
                {
                    strSQL1.Append(" and c.medicineid_chr=?");
                    strSQL2.Append(" and c.medicineid_chr=?");
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (strMedicineid == "")
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                }
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value=DateTime.Parse(p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[1].DbType=DbType.DateTime;
                objDPArr[1].Value = DateTime.Parse(p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (strMedicineid != "")
                {
                    objDPArr[2].Value = strMedicineid;
                }

                IDataParameter[] objDPArr2 = null;
                if (strMedicineid == "")
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr2);
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr2);
                }
                objDPArr2[0].DbType = DbType.DateTime;
                objDPArr2[0].Value = DateTime.Parse(p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr2[1].DbType = DbType.DateTime;
                objDPArr2[1].Value = DateTime.Parse(p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (strMedicineid != "")
                {
                    objDPArr2[2].Value = strMedicineid;
                }

                lngRes1 = objHRPServ.lngGetDataTableWithParameters(strSQL1.ToString(), ref dtTemp1, objDPArr);
                lngRes2 = objHRPServ.lngGetDataTableWithParameters(strSQL2.ToString(), ref dtTemp2, objDPArr2);

                if (dtTemp1.Rows.Count == 0 && dtTemp2.Rows.Count == 0)
                {
                    return lngRes;
                }

                if (dtTemp1.Rows.Count > 0 && dtTemp1 != null)
                {
                    m_dtTable = dtTemp1.Clone();
                    m_dtTable2 = dtTemp1.Clone();
                }
                else if (dtTemp2.Rows.Count > 0 && dtTemp2 != null)
                {
                    m_dtTable = dtTemp2.Clone();
                    m_dtTable2 = dtTemp2.Clone();
                }

                m_dtTable2.BeginLoadData();
                if (dtTemp1.Rows.Count > 0 && dtTemp1 != null)
                {
                    m_dtTable2.Merge(dtTemp1, true);
                }
                if (dtTemp2.Rows.Count > 0 && dtTemp2 != null)
                {
                    m_dtTable2.Merge(dtTemp2, true);
                }
                m_dtTable2.EndLoadData();
                m_dtTable2.AcceptChanges();

                DataRow[] drTemp = m_dtTable2.Select("", "medicineid_chr,examdate_dat desc");
                int intLength=drTemp.Length;
                m_dtTable.BeginLoadData();
                for (int i = 0; i < intLength; i++)
                {
                    m_dtTable.LoadDataRow(drTemp[i].ItemArray, true);
                }
                m_dtTable.EndLoadData();
                
                m_dtTable.AcceptChanges();

                if (m_dtTable.Rows.Count > 0)
                {
                    lngRes = 1;
                }
                m_dtTable2 = null;
                drTemp = null;
                dtTemp1 = null;
                dtTemp2 = null;
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }

            return lngRes;
        }
        #endregion
        #endregion 

        #region 获取数据
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="p_m_dtTableBegin"></param>
        /// <param name="p_m_dtTableEnd"></param>
        /// <param name="strMedicineid"></param>
        /// <param name="m_m_dtTableTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetMedicine(DateTime p_dtBegin, DateTime p_dtEnd, string strMedicineid, out DataTable m_dtTable)
        {
            long lngRes = 0;
            m_dtTable = new DataTable();

            StringBuilder strSQL = new StringBuilder();
           
            try
            {
                strSQL.Append(@"select distinct b.medicinename_vch,
                                        b.medspec_vchr,
                                        b.opunit_vchr,
                                        c.productorid_chr,
                                        b.newretailprice_int,
                                        c.packqty_dec,
                                        a.examdate_dat,
                                        b.reason_vchr,'' endexamdate_dat
                                   from t_ms_adjustprice a,
                                        t_ms_adjustprice_detail b,
                                        t_bse_medicine c
                                  where a.seriesid_int=b.seriesid2_int(+)
                                    and a.formstate_int in (2,3)
                                    and b.status_int=1
                                    and b.medicineid_chr=c.medicineid_chr(+)
                                    and a.examdate_dat between ? and ?");

                if (strMedicineid != "")
                {
                    strSQL.Append(" and c.medicineid_chr=?");
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (strMedicineid == "")
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                }
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = DateTime.Parse(p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = DateTime.Parse(p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (strMedicineid != "")
                {
                    objDPArr[2].Value = strMedicineid;
                }
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref m_dtTable, objDPArr);
                if (m_dtTable != null && m_dtTable.Rows.Count > 0)
                {
                    DataView dvResult = m_dtTable.DefaultView;
                    dvResult.Sort = "medicinename_vch,examdate_dat desc";
                    m_dtTable = dvResult.ToTable();
                    for (int i1 = 1; i1 < m_dtTable.Rows.Count; i1++)
                    {
                        m_dtTable.Rows[i1]["endexamdate_dat"] = Convert.ToDateTime(m_dtTable.Rows[i1 - 1]["examdate_dat"]).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }

            return lngRes;
        }
        #endregion
    }
}
