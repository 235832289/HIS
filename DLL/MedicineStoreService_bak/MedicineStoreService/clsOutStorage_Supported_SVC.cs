using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 出库
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsOutStorage_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取出库主表
        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, int p_intFormType,out DataTable p_dtbOutStorage)
        {
            p_dtbOutStorage = null;
            string m_strAdd;
            if (p_strMedicine == "" || p_strMedicine == null)
            {
                m_strAdd = @"and (g.medicinename_vch like ? or g.assistcode_chr like ?)";
            }
            else
            {
                m_strAdd = @"and (g.medicineid_chr like ? or g.assistcode_chr like ?)";
            }
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.receiptorid_chr,
       a.outstoragedate_dat,
       z.lastname_vchr receiptorname,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       case a.outstoragetype_int
         when 1 then
          '领药出库'
         when 2 then
          '销售出库'
         when 3 then
          '即入即出'
         else
          ''
       end outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_employee z on a.receiptorid_chr = z.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
 inner join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr
               from t_ms_outstorage_detail e, t_bse_medicine f
              where e.medicineid_chr = f.medicineid_chr and e.status = 1) g on g.seriesid2_int =
                                                              a.seriesid_int
 where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?"+m_strAdd+@"
   and d.deptname_vchr like ? 
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ?
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicine + "%";
                objDPArr[4].Value = p_strMedicine + "%";
                objDPArr[5].Value = p_strAskDeptName + "%";
                objDPArr[6].Value = p_strOutID + "%";
                objDPArr[7].Value = p_intFormType;       

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutStorage, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 获取出库主表（多类型）
        /// <summary>
        /// 获取出库主表（多类型）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intOutStorageType">出库类型</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMain(System.Security.Principal.IPrincipal p_objPrincipal,bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, int p_intOutStorageType,int p_intFormType, out DataTable p_dtbOutStorage)
        {
            p_dtbOutStorage = null;
            long lngRes = 0;
            string m_strAdd;

            if (p_blnCombine)
            {                
                m_strAdd = @"and (g.medicinename_vch like ? or g.assistcode_chr like ?)";                
            }
            else
            {
                if (p_strMedicine == "" || p_strMedicine == null)
                {
                    m_strAdd = @"and (g.medicinename_vch like ? or g.assistcode_chr like ?)";
                }
                else
                {
                    m_strAdd = @"and (g.medicineid_chr like ? or g.medicinename_vch like ?)";
                }
            }

           

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.receiptorid_chr,
       a.outstoragedate_dat,
       z.lastname_vchr receiptorname,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       a.outstoragetype_int,
       g.typename_vchr outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc,
        y.buyinmoney,
        y.retailprice retailmoney
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_employee z on a.receiptorid_chr = z.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
left join t_aid_impexptype g on g.typecode_vchr = a.outstoragetype_int
 inner join (select x.seriesid2_int,
                    sum(round(x.netamount_int * x.callprice_int, 2)) buyinmoney,
                    sum(x.netamount_int * x.retailprice_int) retailprice
               from t_ms_outstorage_detail x
              where x.status = 1
              group by x.seriesid2_int) y on y.seriesid2_int =
                                             a.seriesid_int
 inner join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr
               from t_ms_outstorage_detail e, t_bse_medicine f
              where e.medicineid_chr = f.medicineid_chr and e.status = 1) g on g.seriesid2_int =
                                                              a.seriesid_int";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (p_intOutStorageType == 0)
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?"+m_strAdd+@"
   and d.deptname_vchr like ? 
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ?";
                    objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBegin;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    objDPArr[3].Value = p_strMedicine + "%";
                    objDPArr[4].Value = p_strMedicine + "%";
                    objDPArr[5].Value = p_strAskDeptName + "%";
                    objDPArr[6].Value = p_strOutID + "%";
                    objDPArr[7].Value = p_intFormType;
                }
                else
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?
   and (g.medicinename_vch like ? or g.assistcode_chr like ?)
   and d.deptname_vchr like ? 
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ? 
   and a.outstoragetype_int = ?";
                    objHRPServ.CreateDatabaseParameter(9, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBegin;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    objDPArr[3].Value = p_strMedicine + "%";
                    objDPArr[4].Value = p_strMedicine + "%";
                    objDPArr[5].Value = p_strAskDeptName + "%";
                    objDPArr[6].Value = p_strOutID + "%";
                    objDPArr[7].Value = p_intFormType;
                    objDPArr[8].Value = p_intOutStorageType;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutStorage, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                DataView dv = p_dtbOutStorage.DefaultView;
                dv.Sort = "seriesid_int desc";
                p_dtbOutStorage = dv.ToTable();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取出库子表实发数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列</param>
        /// <param name="p_dblAmount">实发数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, out double p_dblAmount)
        {
            p_dblAmount = 0d;

            long lngRes = 0;

            try
            {
                string strSQL = @"select netamount_int from t_ms_outstorage_detail where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_dblAmount = Convert.ToDouble(dtbValue.Rows[0]["netamount_int"]);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select a.seriesid_int,
			 a.seriesid2_int,
			 a.medicineid_chr,
			 a.medicinename_vch,
			 a.medspec_vchr,
			 a.opunit_chr,
			 a.netamount_int,
			 decode(a.lotno_vchr, 'UNKNOWN', '', a.lotno_vchr) lotno_vchr,
			 a.instorageid_vchr,
			 a.callprice_int,
			 a.wholesaleprice_int,
			 a.retailprice_int,
			 a.vendorid_chr,
			 a.netamount_int originality_Amount,
			 a.rejectreason,
			 a.status,
			 b.assistcode_chr,
			 b.medicinetypeid_chr,
			 c.opamount_int askamount,
			 e.vendorname_vchr,
			 b.productorid_chr,
			 j.instoragedate_dat,
			 j.validperiod_dat,
			 j.realgross_int,
			 j.availagross_int,
			 j.opunit_vchr storageunit,
			 a.oldgross_int,
			 b.ipunit_chr,
			 b.packqty_dec,
			 a.instorageid_vchr,
			 f.instoragedate_dat,
			 z.outstoragetype_int typecode_vchr
	from t_ms_outstorage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_ms_outstorage d on a.seriesid2_int = d.seriesid_int
	left outer join t_ms_ask c on d.askid_vchr = c.askid_vchr
														and a.medicineid_chr = c.medicineid_chr
	left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
	left join t_ms_instorage f on f.instorageid_vchr = a.instorageid_vchr
 left join t_ms_storage_detail j on j.storageid_chr = d.storageid_chr
																 and j.medicineid_chr = a.medicineid_chr
																 and a.lotno_vchr = j.lotno_vchr
																 and a.instorageid_vchr =
																		 j.instorageid_vchr
																 and a.validperiod_dat = j.validperiod_dat
																 and a.callprice_int = j.callprice_int
																 and j.status = 1
	left join t_ms_outstorage z on z.seriesid_int = a.seriesid2_int
 where a.seriesid2_int = ?
   and a.status = 1
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 最新的出库单据号

        /// <summary>
        /// 最新的出库单据号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strType">出库类型</param>
        /// <param name="p_strID">返回单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestOutStorageID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strType, out string p_strID)
        {
            p_strID = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = @"select max(t.outstorageid_vchr)
  from t_ms_outstorage t
 where t.outstorageid_vchr like ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                DateTime dtmNow = DateTime.Now;
                clsMS_Public_Supported_SVC clsPub = new clsMS_Public_Supported_SVC();
                clsPub.m_lngGetCurrentDateTime(out dtmNow);
                objDPArr[0].Value = dtmNow.ToString("yyyyMMdd") + p_strType + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = dtmNow.ToString("yyyyMMdd") + p_strType + "0001";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = dtmNow.ToString("yyyyMMdd") + p_strType + "0001";
                    }
                    else
                    {
                        strTemp = strTemp.Substring(9, 4);
                        p_strID = dtmNow.ToString("yyyyMMdd") + p_strType + (Convert.ToInt32(strTemp) + 1).ToString("0000");
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion      

        #region 获取指定药品出库数量
        /// <summary>
        /// 获取指定药品出库数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_hstNetAmount">针对指定药物，以批号+入库单号为键，出库数量为值的哈希表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNetAmount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, string p_strMedicineID, out Hashtable p_hstNetAmount)
        {
            p_hstNetAmount = new Hashtable();
            long lngRes = 0;

            try
            {
                string strSQL = @"select a.netamount_int,
        case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
        a.instorageid_vchr,
        a.validperiod_dat,
        a.callprice_int
  from t_ms_outstorage_detail a, t_ms_outstorage b
 where a.seriesid2_int = b.seriesid_int
   and b.seriesid_int = ?
   and a.medicineid_chr = ?
   and a.status = 1
 order by a.lotno_vchr, a.instorageid_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;
                objDPArr[1].Value = p_strMedicineID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drTemp = dtbValue.Rows[iRow];
                        p_hstNetAmount.Add(drTemp["lotno_vchr"].ToString().PadLeft(10, '0') + drTemp["instorageid_vchr"].ToString() + Convert.ToDateTime(drTemp["validperiod_dat"]).ToString("yyyy-MM-dd HH:mm:ss") + Convert.ToDouble(drTemp["callprice_int"]).ToString("0.0000"), drTemp["netamount_int"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intFormID">单据类型</param>
        /// <param name="p_dtbMoney">金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllInMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID,
            int p_intFormID, out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;

            try
            {
                string strSQL;
                if (p_intFormID == 2)
                {
                    strSQL = @"select a.outstorageid_vchr,b.netamount_int * b.callprice_int buyinmoney,
       b.netamount_int * b.wholesaleprice_int wholesalemoney,
       b.netamount_int * b.retailprice_int retailprice,
       a.seriesid_int,
       a.outstoragetype_int,
       a.status
  from t_ms_outstorage a, t_ms_outstorage_detail b
 where a.seriesid_int = b.seriesid2_int
   and a.askdate_dat between ? and ?
   and a.storageid_chr = ?
   and (a.formtype = ? or a.formtype = 5)
   and b.status = 1
   and a.status <> 0";
                }
                else
                {
                    strSQL = @"select a.outstorageid_vchr,b.netamount_int * b.callprice_int buyinmoney,
       b.netamount_int * b.wholesaleprice_int wholesalemoney,
       b.netamount_int * b.retailprice_int retailprice,
       a.seriesid_int,
       a.outstoragetype_int,
       a.status
  from t_ms_outstorage a, t_ms_outstorage_detail b
 where a.seriesid_int = b.seriesid2_int
   and a.askdate_dat between ? and ?
   and a.storageid_chr = ?
   and a.formtype = ?
   and b.status = 1
   and a.status <> 0";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;
                objDPArr[3].Value = p_intFormID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMoney, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取子表内容(报表打印)
        /*
        /// <summary>
        /// 获取子表内容 (报表打印)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <param name="p_strDBConfig">第二个数据库的参数配置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ,int intType, out DataTable p_dtbValue,string p_strDBConfig)
        {
            p_dtbValue = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select 
k.medicinetypename_vchr medicinetypesetname,
k.medicinetypeid_chr medicinetypesetid,
a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medicinename_vch,
       a.medspec_vchr,
       a.opunit_chr,
       a.netamount_int,
              case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
       a.instorageid_vchr,
       a.callprice_int,
       a.wholesaleprice_int,
       a.retailprice_int,
       a.vendorid_chr,
       a.rejectreason,
       b.assistcode_chr,
       c.opamount_int askamount,
       e.vendorname_vchr,
       b.productorid_chr,
       j.instoragedate_dat,
       j.validperiod_dat,
       j.realgross_int,
       j.availagross_int,
       j.opunit_vchr storageunit,
       a.oldgross_int,d.storageid_chr
  from t_ms_outstorage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinetype k on k.medicinetypeid_chr = b.medicinetypeid_chr
 inner join t_ms_outstorage d on a.seriesid2_int = d.seriesid_int
 left outer join t_ms_ask c on d.askid_vchr = c.askid_vchr
                       and a.medicineid_chr = c.medicineid_chr
 left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
 left join t_ms_storage_detail j on j.storageid_chr = d.storageid_chr
                                 and j.medicineid_chr = a.medicineid_chr
                                 and a.lotno_vchr = j.lotno_vchr
                                 and a.instorageid_vchr =
                                     j.instorageid_vchr
                                 and a.validperiod_dat = j.validperiod_dat
                                 and a.callprice_int = j.callprice_int  
                             where a.seriesid2_int = ?
                                and j.STATUS = 1 and a.STATUS = 1 "; 
                               
                if (intType == 0)
                {
                    strSQL += @"order by b.medicinetypeid_chr,b.assistcode_chr";
                }

                if (intType == 1)
                {
                    strSQL += @"order by b.medicinetypeid_chr,a.seriesid_int";
                }

                string strStorageID = string.Empty;
                string strAssistCode = string.Empty;
                bool blnComeOn = false;//是否继续查
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                DataRow dr = null;
                if (p_dtbValue != null && p_dtbValue.Rows.Count > 0)
                {                    
                    blnComeOn = true;
                    strStorageID = p_dtbValue.Rows[0]["storageid_chr"].ToString();

                    for (int i1 = 0; i1 < p_dtbValue.Rows.Count; i1++)
                    {
                        dr = p_dtbValue.Rows[i1];
                        if (!strAssistCode.Contains(dr["assistcode_chr"].ToString()))
                            strAssistCode += "'"+dr["assistcode_chr"].ToString() + "',";
                    }
                    if (strAssistCode.Length > 0)
                        strAssistCode = strAssistCode.Substring(0, strAssistCode.Length - 1);
                }
                p_dtbValue.Columns.Remove("storageid_chr");

                //20090421:获取第二个数据库是否已建立连接
                if (p_strDBConfig.Length > 0)
                {
                    DataTable dtbTemp = new DataTable();

                    strSQL = @"select count(*)
  from dba_db_links a
 where a.db_link = 'SECONDMSCONFIG.REGRESS.RDBMS.DEV.US.ORACLE.COM'
   and a.owner = 'PUBLIC';";
                    objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbTemp);

                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtbTemp.Rows[0][0]) > 0)
                        {
                            //删除连接
                            strSQL = @"DROP PUBLIC DATABASE LINK SECONDMSCONFIG";
                            objHRPServ.DoExcute(strSQL);
                        }
                    }

                    objHRPServ.DoExcute(p_strDBConfig);

                    strSQL = @"select b.assistcode_chr, sum(a.realgross_int) seconddbamount
  from t_ms_storage_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where a.storageid_chr = ?
and b.assistcode_chr in ( ? )
and a.status = 1
 group by b.assistcode_chr";

                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = strStorageID;
                    objDPArr[1].Value = strAssistCode;

                    objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objDPArr);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        dtbTemp.PrimaryKey = new DataColumn[] { dtbTemp.Columns["assistcode_chr"] };

                        DataRow drow2 = null;
                        foreach (DataRow drow in p_dtbValue.Rows)
                        {
                            drow2 = dtbTemp.Rows.Find(drow["assistcode_chr"].ToString());
                            if (drow2 != null)
                                drow["oldgross_int"] = Convert.ToDouble(drow["oldgross_int"]) + Convert.ToDouble(drow2["seconddbamount"]);
                        }
                    }
                }
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    //添加当前分批号的库存数


                    //if (lngRes > 0 && p_dtbValue.Rows.Count > 0)
                    //{
                    //    double douGross=0;
                    //    for (int iRows = 0; iRows < p_dtbValue.Rows.Count; iRows++)
                    //    {
                    //        m_lngGetMedicineGross(null, p_dtbValue.Rows[iRows]["medicineid_chr"].ToString(), p_dtbValue.Rows[iRows]["lotno_vchr"].ToString(), out douGross);
                    //        p_dtbValue.Rows[iRows]["oldgross_int"] = douGross;
                    //    }


                    //}
                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
         */
        #endregion

        #region 获取子表内容(广医三院报表打印)
        /// <summary>
        /// 获取子表内容 (广医三院报表打印)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailReportForGY3Y(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ,out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select rownum,
			 a.medicinename_vch,
			 a.medspec_vchr,
			 a.opunit_chr,
			 a.netamount_int,
			 case
				 when a.lotno_vchr = 'UNKNOWN' then
					''
				 else
					a.lotno_vchr
			 end lotno_vchr,
			 a.retailprice_int,
			 b.assistcode_chr,
			 b.productorid_chr,
			 a.validperiod_dat
	from t_ms_outstorage_detail a
	left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
	left join t_ms_outstorage c on c.seriesid_int = a.seriesid2_int
	left join t_ms_storage d on d.storageid_chr = c.storageid_chr
													and d.medicineid_chr = a.medicineid_chr
 where a.seriesid2_int = ?
	 and a.status = 1
 order by d.storagerackid_chr, b.assistcode_chr";
                
               
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);

                objHRPServ.Dispose();

                if (p_dtbValue.Rows.Count > 0)
                {
                    int iCount = p_dtbValue.Rows.Count;
                    for (int iR = 0; iR < iCount; iR++)
                    {
                        p_dtbValue.Rows[iR]["rownum"] = iR + 1;
                        if (Convert.ToDateTime(p_dtbValue.Rows[iR]["validperiod_dat"]).ToString("yyyy-MM-dd").Trim() == "0001-01-01")
                        {
                            p_dtbValue.Rows[iR]["validperiod_dat"] = DBNull.Value;
                        }
                    }
                    p_dtbValue.AcceptChanges();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取指定出库单各药品的总库存
        /// <summary>
        /// 获取指定出库单各药品的总库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">各药品的总库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineAllGross(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out clsMS_MedicineGross[] p_objGross)
        {
            p_objGross = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select sum(realgross_int) allrealgross,
       sum(availagross_int) allavagross,
       medicineid_chr
  from (select distinct a.realgross_int,
                        a.availagross_int,
                        a.medicineid_chr,
                        a.seriesid_int
          from t_ms_storage_detail a
         inner join t_ms_outstorage_detail b on a.medicineid_chr =
                                                b.medicineid_chr
                                            and b.status = 1
         inner join t_ms_outstorage c on c.seriesid_int = b.seriesid2_int
                                     and c.storageid_chr = a.storageid_chr
                                     and c.status <> 0
         where c.seriesid_int = ?
           and a.status = 1)
 group by medicineid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                DataTable dtbGross = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbGross, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbGross != null)
                {
                    int intRowsCount = dtbGross.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    p_objGross = new clsMS_MedicineGross[intRowsCount];
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drTemp = dtbGross.Rows[iRow];
                        p_objGross[iRow] = new clsMS_MedicineGross();
                        p_objGross[iRow].m_strMedicineID = drTemp["medicineid_chr"].ToString();
                        p_objGross[iRow].m_dblAvailaGross = Convert.ToDouble(drTemp["allavagross"]);
                        p_objGross[iRow].m_dblRealGross = Convert.ToDouble(drTemp["allrealgross"]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 获取指定药品指定批号的总库存

        /// <summary>
        /// 获取指定药品指定批号的总库存

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">总库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineid,string p_strLotno, out double p_douGross)
        {
            DataTable dtbGross = new DataTable();
            p_douGross = 0;
            long lngRes = 0;
            try
            {
                string strSQL = @" select sum(t.realgross_int) gross
   from t_ms_storage_detail t
  where t.medicineid_chr = ?
    and t.lotno_vchr = ? and t.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineid;
                objDPArr[1].Value = p_strLotno;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbGross, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbGross.Rows.Count > 0)
                {
                    if (dtbGross.Rows[0]["gross"] != DBNull.Value)
                    {
                        p_douGross = Convert.ToDouble(dtbGross.Rows[0]["gross"]);
                    }
                    else
                    {
                        p_douGross = 0;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取药品可用库存数量
        /// <summary>
        /// 获取药品可用库存数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicinID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_decMedicineAmount">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineAmount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicinID, string p_strStorageID, out double p_decMedicineAmount)
        {
            p_decMedicineAmount = 0d;
            string strSQL ;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                strSQL = @"select sum(availagross_int)
  from t_ms_storage_detail a left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where storageid_chr = ?
   and b.assistcode_chr = ?
   and status = 1";
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicinID;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        double dblGrossTemp = 0d;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            if (double.TryParse(dtbValue.Rows[iRow][0].ToString(), out dblGrossTemp))
                            {
                                p_decMedicineAmount += dblGrossTemp;
                            }
                        }
                    }
                    else
                    {
                        p_decMedicineAmount = -1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取可用库存数量大于0的药品

        /// <summary>
        /// 获取可用库存数量大于0的药品

        /// </summary>
        /// <param name="p_objPrincipal"></param>        
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_alMedicineArr">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineAmountNotZero(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out ArrayList p_alMedicineArr)
        {
            p_alMedicineArr = new ArrayList();
            string strSQL;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                strSQL = @"select b.assistcode_chr
  from t_ms_storage_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where storageid_chr = ?
   and status = 1
   having sum(a.availagross_int) > 0
   group by b.assistcode_chr
   order by b.assistcode_chr";
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {                        
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            p_alMedicineArr.Add(dtbValue.Rows[iRow][0]);
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取主表开单时间

        /// <summary>
        /// 获取主表开单时间

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderID">出库单号</param>
        /// <param name="dtAskDate">开单时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetBillDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID,out DateTime dtAskDate)
        {
            dtAskDate = DateTime.MinValue;
            string strSQL;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                strSQL = @"select a.askdate_dat from t_ms_outstorage a
  where a.outstorageid_vchr = ?";
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strOrderID;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null)
                {
                    if(dtbValue.Rows.Count> 0)
                    {
                        dtAskDate = Convert.ToDateTime(dtbValue.Rows[0][0].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取出库主表
        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID">主表序列</param>
        /// <param name="dtbMain"></param>
        [AutoComplete]
        public void m_mthGetOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID, out DataTable dtbMain)
        {
            dtbMain = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.receiptorid_chr,
       a.outstoragedate_dat,
       z.lastname_vchr receiptorname,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       case a.outstoragetype_int
         when 1 then
          '领药出库'
         when 2 then
          '销售出库'
         when 3 then
          '即入即出'
         else
          ''
       end outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_employee z on a.receiptorid_chr = z.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
 inner join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr
               from t_ms_outstorage_detail e, t_bse_medicine f
              where e.medicineid_chr = f.medicineid_chr and e.status = 1) g on g.seriesid2_int =
                                                              a.seriesid_int
 where a.seriesid_int = ?   
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeriesID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMain, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region 检查该出库单是否已开药房入库单

        /// <summary>
        /// 检查该出库单是否已开药房入库单

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID">主表序列</param>
        [AutoComplete]
        public bool m_mthHaveAddedIntoDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID)
        {
            DataTable dtbMain = null;
            try
            {
                string strSQL = @"select a.outstorageid_vchr 
                from t_ds_instorage a
                left join t_ms_outstorage b 
                on b.outstorageid_vchr = a.outstorageid_vchr
                where b.seriesid_int = ?
                and a.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeriesID;

                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMain, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbMain != null && dtbMain.Rows.Count > 0)
                    return true;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return false;
            }
            return false;
        }
        #endregion

        #region 获取单据类型
        /// <summary>
        /// 获取单据类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intBillTypeID">单据类型ID</param>
        /// <param name="p_strBillTypeName">单据类型名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBillTypeName(System.Security.Principal.IPrincipal p_objPrincipal, int p_intBillTypeID, out string p_strBillTypeName)
        {
            p_strBillTypeName = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @" select distinct t.typecode_vchr, t.typename_vchr
  from t_aid_impExptype t
 where t.typecode_vchr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_intBillTypeID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strBillTypeName = dtbValue.Rows[0]["typename_vchr"].ToString();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取出库明细（打印）药库使用
        /// <summary>
        /// 获取出库明细（打印）药库使用
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strExportDept">领用部门ID</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">出库类型ID</param>        
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_dtbReport">出库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailForReport(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strExportDept, string p_strMedicine, string p_strType, string p_strMedType,out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            if (p_strStorageID == "") return -1;

            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder(@"select distinct b.outstoragedate_dat,
                a.medicinename_vch,
                c.productorid_chr,
                a.medspec_vchr,
                a.opunit_chr,
                a.lotno_vchr,
                to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
                a.callprice_int,
                a.netamount_int,
                d.deptname_vchr,
                d.deptid_chr,
                b.outstorageid_vchr,
                b.comment_vchr,
                a.retailprice_int,
                a.instorageid_vchr,
                f.oldgross_int remain,
                e.typename_vchr,
                a.netamount_int * a.callprice_int callsum,
                a.netamount_int * a.retailprice_int retailsum
  from t_ms_outstorage_detail a
  left join t_ms_outstorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc d on d.deptid_chr = b.askdept_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.outstoragetype_int
  left join t_ms_account_detail f on f.chittyid_vchr = b.outstorageid_vchr
                                 and f.medicineid_chr = a.medicineid_chr
                                 and f.lotno_vchr = a.lotno_vchr
                                 and f.state_int <> 0
                                 and f.callprice_int = a.callprice_int
                                 and f.retailprice_int = a.retailprice_int
                                 and f.validperiod_dat = a.validperiod_dat
                                 and f.instorageid_vchr=a.instorageid_vchr
 where (b.status = 2 or b.status = 3)
   and a.status = 1
   and b.storageid_chr = ?
   and b.outstoragedate_dat between ? and ?");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(10, out tmp_objDPArr);
                tmp_objDPArr[0].Value = p_strStorageID;
                tmp_objDPArr[1].DbType = DbType.DateTime;
                tmp_objDPArr[1].Value = p_dtmBegin;
                tmp_objDPArr[2].DbType = DbType.DateTime;
                tmp_objDPArr[2].Value = p_dtmEnd;
                int intArg = 3;
                if (p_strExportDept != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.askdept_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value =p_strExportDept;
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and c.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and a.medicineid_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value =p_strMedicine;
                }
                if (p_strType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.outstoragetype_int = ? ");
                    tmp_objDPArr[intArg - 1].Value =p_strType;
                }
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and c.medicinetypeid_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strMedType;
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                for (int i1 = 0; i1 < intArg; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }            

                strSQL.Append(" order by b.outstoragedate_dat desc ");

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);  
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 药房入库单是否已审核
        /// <summary>
        /// 药房入库单是否已审核
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSE">序列</param>
        /// <param name="m_strBillID">出库单单号</param>
        /// <param name="m_blnDSCommint">药房入库单是否已审核</param>
        [AutoComplete]
        public long m_lngGetDSCommint(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSE, out string m_strBillID, out bool m_blnDSCommint)
        {
            long lngRes = 0L;
            m_strBillID = string.Empty;
            m_blnDSCommint = false;
            DataTable dtbMain = null;
            try
            {
                string strSQL = @"select a.outstorageid_vchr, a.status
	from t_ds_instorage a
	left join t_ms_outstorage b on b.outstorageid_vchr = a.outstorageid_vchr
 where b.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSE;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMain, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbMain != null && dtbMain.Rows.Count > 0)
                {
                    if (Convert.ToInt16(dtbMain.Rows[0]["status"]) == 2 || Convert.ToInt16(dtbMain.Rows[0]["status"]) == 3)
                    {
                        m_strBillID = Convert.ToString(dtbMain.Rows[0]["outstorageid_vchr"]);
                        m_blnDSCommint = true;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return lngRes;
            }
            return lngRes;
        }
        #endregion

        #region 获取出库明细（打印）药房使用
        /// <summary>
        /// 获取出库明细（打印）药房使用
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strExportDept">领用部门ID</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">出库类型ID</param>     
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_dtbReport">出库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailReportForDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine,string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strExportDept, string p_strMedicine, string p_strType,string p_strMedType,bool p_blnIsHospital, out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            if (p_strStorageID == "") return -1;

            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder();
                if (p_blnIsHospital)
                {
                    strSQL.Append(@"select b.examdate_dat outstoragedate_dat,
       a.medicinename_vchr medicinename_vch,
       c.productorid_chr,
       a.medspec_vchr,
       decode(c.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) as opunit_chr,
       a.lotno_vchr,
       to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
       decode(c.ipchargeflg_int,
              0,
              a.opwholesaleprice_int,
              a.ipwholesaleprice_int) as callprice_int,
       decode(c.ipchargeflg_int, 0, a.opamount_int, a.ipamount_int) as netamount_int,
       d.deptname_vchr,
       d.deptid_chr,
       b.outdrugstoreid_vchr outstorageid_vchr,
       b.comment_vchr,
       decode(c.ipchargeflg_int,
              0,
              a.opretailprice_int,
              a.ipretailprice_int) as retailprice_int,
       g.dsinstoreid_vchr instorageid_vchr,
       nvl(decode(c.ipchargeflg_int, 0, a.opoldgross_int, a.ipoldgross_int),
           0) remain,
       e.typename_vchr,
       a.opamount_int * a.opwholesaleprice_int callsum,
       round(a.opretailprice_int * a.ipamount_int / a.packqty_dec, 4) retailsum
  from t_ds_outstorage_detail a
  left join t_ds_outstorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc d on d.deptid_chr = b.instoredept_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.typecode_vchr
  left join t_ds_storage_detail g on g.seriesid_int = a.storageseriesid_chr
                                 and g.status = 1
 where b.status_int in (2, 3)
   and b.formtype_int in (1, 2, 3)
   and a.status = 1
   and b.drugstoreid_chr = ?
   and b.examdate_dat between ? and ? ");
                }
                else
                {
                    strSQL.Append(@"select b.examdate_dat outstoragedate_dat,
       a.medicinename_vchr medicinename_vch,
       c.productorid_chr,
       a.medspec_vchr,
       decode(c.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) as opunit_chr,
       a.lotno_vchr,
       to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
       decode(c.opchargeflg_int,
              0,
              a.opwholesaleprice_int,
              a.ipwholesaleprice_int) as callprice_int,
       decode(c.opchargeflg_int, 0, a.opamount_int, a.ipamount_int) as netamount_int,
       d.deptname_vchr,
       d.deptid_chr,
       b.outdrugstoreid_vchr outstorageid_vchr,
       b.comment_vchr,
       decode(c.opchargeflg_int,
              0,
              a.opretailprice_int,
              a.ipretailprice_int) as retailprice_int,
       g.dsinstoreid_vchr instorageid_vchr,
       nvl(decode(c.opchargeflg_int, 0, a.opoldgross_int, a.ipoldgross_int),
           0) remain,
       e.typename_vchr,
       a.opamount_int * a.opwholesaleprice_int callsum,
       round(a.opretailprice_int * a.ipamount_int / a.packqty_dec, 4) retailsum
  from t_ds_outstorage_detail a
  left join t_ds_outstorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc d on d.deptid_chr = b.instoredept_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.typecode_vchr
  left join t_ds_storage_detail g on g.seriesid_int = a.storageseriesid_chr
                                 and g.status = 1
 where b.status_int in (2, 3)
   and b.formtype_int in (1, 2, 3)
   and a.status = 1
   and b.drugstoreid_chr = ?
   and b.examdate_dat between ? and ? ");
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(10, out tmp_objDPArr);
                tmp_objDPArr[0].Value = p_strStorageID;
                tmp_objDPArr[1].DbType = DbType.DateTime;
                tmp_objDPArr[1].Value = p_dtmBegin;
                tmp_objDPArr[2].DbType = DbType.DateTime;
                tmp_objDPArr[2].Value = p_dtmEnd;
                int intArg = 3;
                if (p_strExportDept != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.instoredept_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strExportDept;
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and c.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and a.medicineid_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strMedicine;
                }
                if (p_strType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.typecode_vchr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strType;
                }
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and c.medicinetypeid_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strMedType;
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                for (int i1 = 0; i1 < intArg; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }                 

                strSQL.Append(" order by b.examdate_dat desc ");

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 通过入库单号获取出库单的序列号和出库单号（即入即出打印）
        /// <summary>
        /// 通过入库单号获取出库单的序列号（即入即出打印）

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageId">入库单单号</param>
        /// <param name="m_lngOutSeriesId">出库单的序列号</param>
        /// <param name="m_strOutId">出库单号</param>
        [AutoComplete]
        public long m_lngGetOutStorageSeriesIdByInstorageNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInStorageId, out long m_lngOutSeriesId,out string m_strOutId)
        {
            long lngRes = 0L;
            m_lngOutSeriesId = 0;
            m_strOutId = string.Empty;
            DataTable m_dtbResult = null;
            try
            {
                string strSQL = @"select a.seriesid_int,a.outstorageid_vchr
	from t_ms_outstorage a, t_ms_outstorage_detail b
 where a.seriesid_int = b.seriesid2_int
	 and b.instorageid_vchr = ?
	 and b.status = 1
	 and a.status <> 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strInStorageId;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbResult != null && m_dtbResult.Rows.Count > 0)
                {
                    Int64.TryParse(m_dtbResult.Rows[0]["seriesid_int"].ToString(), out m_lngOutSeriesId);
                    m_strOutId = m_dtbResult.Rows[0]["outstorageid_vchr"].ToString();
                }
                m_dtbResult.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return lngRes;
            }
            return lngRes;
        }
        #endregion

        #region 库房id
        public long m_lngGetRoomid(out DataTable dtTemp)
        {
            long lngRes = 0L;
            dtTemp = new DataTable();
            try
            {
                string strSQL = @"select t.medstoreid_chr,t.deptid_chr from t_bse_medstore t";

                clsHRPTableService objHRPServ = new clsHRPTableService();


                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtTemp);
                objHRPServ.Dispose();
                objHRPServ = null;

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return lngRes;
            }
            return lngRes;
        }
        #endregion

        #region 获取货架号

        /// <summary>
        /// 获取货架号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库号</param>
        /// <param name="p_strMedicineID">药品号</param>
        /// <param name="p_strRackID">货架号</param>
        [AutoComplete]
        public long m_lngGetStorageRackID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID,out string p_strRackID)
        {
            long lngRes = 0L;
            p_strRackID = string.Empty;
            DataTable dtbResult = null;
            try
            {
                string strSQL = @"select a.storagerackid_chr
	from t_ms_storage a
 where a.storageid_chr = ?
	 and a.medicineid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_strRackID = dtbResult.Rows[0][0].ToString();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return lngRes;
            }
            return lngRes;
        }
        #endregion

        #region 检查该出库单是否已开药房入库单 20081103
        /// <summary>
        /// 检查该出库单是否已开药房入库单，20081208增加返回单据状态、单据序列
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOutID">出库单号</param>
        /// <param name="p_blnSendToDrugstore">是否开了药房入库单</param>
        /// <param name="p_intStatus">入库单状态</param>
        /// <param name="p_lngSeriesID">主表序列</param>
        [AutoComplete]
        public long m_lngCheckHasSendToDrugstore(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOutID, out bool p_blnSendToDrugstore,out int p_intStatus,out long p_lngSeriesID)
        {
            long lngRes = 0;
            p_blnSendToDrugstore = false;
            p_intStatus = -2;
            p_lngSeriesID = 0;
            DataTable dtbResult = new DataTable();
            try
            {
                string strSQL = @"select a.indrugstoreid_vchr,a.status,a.seriesid_int
  from t_ds_instorage a
 where a.outstorageid_vchr = ?
   and a.status <> 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strOutID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_blnSendToDrugstore = true;
                    p_intStatus = Convert.ToInt16(dtbResult.Rows[0]["status"]);
                    p_lngSeriesID = Convert.ToInt64(dtbResult.Rows[0]["seriesid_int"]);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取出库明细河源出库排行榜
        /// <summary>
        /// 获取出库明细河源出库排行榜
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strExportDept">领用部门ID</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">出库类型ID</param>        
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_dtbReport">出库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailForReportForHYSort(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strExportDept, string p_strMedicine, string p_strType, string p_strMedType, out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder(@"select  distinct a.medicinename_vch,
                a.medspec_vchr,
                a.opunit_chr,
                a.callprice_int,
                a.wholesaleprice_int,
                a.retailprice_int,
                sum(a.netamount_int) netamount_int,
                sum(a.netamount_int * a.wholesaleprice_int) wholesalesum,
                sum(a.netamount_int * a.callprice_int) callsum,
                sum(a.netamount_int * a.retailprice_int) retailsum
  from t_ms_outstorage_detail a
  left join t_ms_outstorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc d on d.deptid_chr = b.askdept_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.outstoragetype_int
  left join t_ms_account_detail f on f.chittyid_vchr = b.outstorageid_vchr
                                 and f.medicineid_chr = a.medicineid_chr
                                 and f.lotno_vchr = a.lotno_vchr
                                 and f.state_int <> 0
                                 and f.callprice_int = a.callprice_int
                                 and f.retailprice_int = a.retailprice_int
                                 and f.validperiod_dat = a.validperiod_dat
                                 and f.instorageid_vchr=a.instorageid_vchr
 where (b.status = 2 or b.status = 3)
   and a.status = 1
   and b.outstoragedate_dat between ? and ?");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(10, out tmp_objDPArr);
                tmp_objDPArr[0].DbType = DbType.DateTime;
                tmp_objDPArr[0].Value = p_dtmBegin;
                tmp_objDPArr[1].DbType = DbType.DateTime;
                tmp_objDPArr[1].Value = p_dtmEnd;
                int intArg = 2;
                if (!string.IsNullOrEmpty(p_strStorageID) && p_strStorageID != "0000")
                {
                    intArg += 1;
                    strSQL.Append(" and b.storageid_chr = ?");
                    tmp_objDPArr[2].Value = p_strStorageID;
                }
                if (p_strExportDept != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.askdept_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strExportDept;
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and c.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and a.medicineid_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strMedicine;
                }
                if (p_strType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.outstoragetype_int = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strType;
                }
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and c.medicinetypeid_chr = ? ");
                    tmp_objDPArr[intArg - 1].Value = p_strMedType;
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                for (int i1 = 0; i1 < intArg; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                strSQL.Append(@"group by a.medicinename_vch,
          a.medspec_vchr,
          a.opunit_chr,
          a.callprice_int,
          a.retailprice_int,
          a.wholesaleprice_int
order by netamount_int desc ");

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
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
