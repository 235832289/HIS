using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{   
   
    /// <summary>
    /// 药房请领业务类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsAskForMedicine_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取领药部门信息
        /// <summary>
        /// 获取领药部门信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplyDept(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable m_dtDept)
        {
            m_dtDept = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select e.exportdept_chr deptid_chr,
			 d.deptname_vchr,
			 d.code_vchr,
			 d.pycode_chr,
			 '' attributeid,
			 '' default_inpatient_int
	from t_ms_exportdept e
 inner join t_bse_deptdesc d on e.exportdept_chr = d.deptid_chr
 where e.storageflag_int <> 0
 order by e.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtDept);
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

        #region 获取出库部门信息
        /// <summary>
        /// 获取出库部门信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtExportDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetExportDept(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_dtExportDept)
        {
            m_dtExportDept = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct t.medicineroomid medicineroomid,
                                  t.medicineroomname medicineroomname
                                  from t_ms_medicinestoreroomset t
                                  order by t.medicineroomid";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtExportDept);
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

        #region 获取基本药品信息
        /// <summary>
        ///  获取基本药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtMedicineInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal,string m_strMedStoreid, out DataTable m_dtMedicineInfo)
        {
            m_dtMedicineInfo = null;
            long lngRes = 0;

            clsHRPTableService objHRPServ = new clsHRPTableService();
            IDataParameter[] objDPArr = null;

            if (m_strMedStoreid != string.Empty)
            {
                //20091024:判断是门诊药房还是住院药房，以显示正确的单位
                int intStoreType = 1;
                string strSQLTemp = @"select a.medstoretype_int
  from t_bse_medstore a
 where a.medstoreid_chr = ?";
                DataTable dtbTemp = new DataTable();

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strMedStoreid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQLTemp, ref dtbTemp, objDPArr);
                if(lngRes > 0 && dtbTemp.Rows.Count > 0)
                {
                    intStoreType = Convert.ToInt32(dtbTemp.Rows[0][0]);
                }

                try
                {
                    string strSQL = string.Empty;
                    if(intStoreType == 1)
                    {
                        strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.opchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
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
       decode(e.ifstop_int, null, t.ifstop_int, e.ifstop_int) ifstop_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_medstoreset c on t.medicinetypeid_chr =
                                  c.medicinetypeid_chr
                              and c.medstoreid = ?
  left join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
  left join t_ds_storage e on e.medicineid_chr = t.medicineid_chr
                          and e.drugstoreid_chr = d.deptid_chr
 where t.deleted_int = 0
 order by t.assistcode_chr, t.medicineid_chr";
                    }
                    else
                    {
                        strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.ipchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
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
       decode(e.ifstop_int, null, t.ifstop_int, e.ifstop_int) ifstop_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_medstoreset c on t.medicinetypeid_chr =
                                  c.medicinetypeid_chr
                              and c.medstoreid = ?
  left join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
  left join t_ds_storage e on e.medicineid_chr = t.medicineid_chr
                          and e.drugstoreid_chr = d.deptid_chr
 where t.deleted_int = 0
 order by t.assistcode_chr, t.medicineid_chr";
                    }

                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = m_strMedStoreid;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtMedicineInfo, objDPArr);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
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
                                  and b.flag_int = 1  where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";
                  
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtMedicineInfo);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 获取药房出库基本药品信息
        /// <summary>
        /// 获取药房出库基本药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHispital">是否住院药房</param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="m_dtMedicineInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal,bool p_blnIsHispital, string m_strMedStoreid, out DataTable m_dtMedicineInfo)
        {
            m_dtMedicineInfo = null;
            long lngRes = 0;
            if (m_strMedStoreid != string.Empty)
            {
                try
                {
                    string strSQL = "";
                    if (p_blnIsHispital)
                    {
                        strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.ipchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
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
       decode(c.ifstop_int, null, t.ifstop_int, c.ifstop_int) ifstop_int,
       decode(t.ipchargeflg_int,0,round(f.ipcurrentgross_num / t.packqty_dec, 2),f.ipcurrentgross_num) currentgross_num,
       c.noqtyflag_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_storage c on t.medicineid_chr = c.medicineid_chr                          
                          and c.drugstoreid_chr =
                              (select d.deptid_chr
                                 from t_bse_medstore d
                                where d.medstoreid_chr = ?)
 inner join (select e.medicineid_chr,
                    e.drugstoreid_chr,
                    sum(e.iprealgross_int) ipcurrentgross_num
               from t_ds_storage_detail e where e.status = 1
              group by e.medicineid_chr, e.drugstoreid_chr) f on f.medicineid_chr =
                                                                 t.medicineid_chr
                                                             and f.drugstoreid_chr =
                                                                 c.drugstoreid_chr
 inner join t_ds_medstoreset b on t.medicinetypeid_chr =
                                  b.medicinetypeid_chr
                              and b.medstoreid = ? where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";
                    }
                    else
                    {
                        strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.opchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
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
       decode(c.ifstop_int, null, t.ifstop_int, c.ifstop_int) ifstop_int,
       decode(t.opchargeflg_int,0,round(f.ipcurrentgross_num / t.packqty_dec, 2),f.ipcurrentgross_num) currentgross_num,
       c.noqtyflag_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_storage c on t.medicineid_chr = c.medicineid_chr                          
                          and c.drugstoreid_chr =
                              (select d.deptid_chr
                                 from t_bse_medstore d
                                where d.medstoreid_chr = ?)
 inner join (select e.medicineid_chr,
                    e.drugstoreid_chr,
                    sum(e.iprealgross_int) ipcurrentgross_num
               from t_ds_storage_detail e where e.status = 1
              group by e.medicineid_chr, e.drugstoreid_chr) f on f.medicineid_chr =
                                                                 t.medicineid_chr
                                                             and f.drugstoreid_chr =
                                                                 c.drugstoreid_chr
 inner join t_ds_medstoreset b on t.medicinetypeid_chr =
                                  b.medicinetypeid_chr
                              and b.medstoreid = ? where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";
                    }

                    clsHRPTableService objHRPServ = new clsHRPTableService();

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = m_strMedStoreid;
                    objDPArr[1].Value = m_strMedStoreid;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtMedicineInfo, objDPArr);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
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
       t.ifstop_int,'' currentgross_num,
       '' noqtyflag_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
 left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1 where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtMedicineInfo);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
             #endregion  
     
        #region 获取药房请领主表信息
        /// <summary>
        /// 获取药房请领主表信息
         /// </summary>
         /// <param name="p_objPrincipal"></param>
         /// <param name="m_strBeginDate"></param>
         /// <param name="m_strEndDate"></param>
         /// <param name="m_strAskDeptID"></param>
         /// <param name="m_strExpDeptID">出库部门</param>
         /// <param name="m_intStatus">-1:全部状态 状态 0、作废、1、新制   2、提交 3、药库审核4、药房审核</param>
         /// <param name="m_strMedName"></param>
         /// <param name="m_strAskid"></param>
         /// <param name="m_dtAskInfo"></param>
         /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAskInfo(System.Security.Principal.IPrincipal p_objPrincipal,string m_strBeginDate,string m_strEndDate,string m_strAskDeptID,string m_strExpDeptID,int m_intStatus,string m_strMedName,string m_strAskid,out DataTable m_dtAskInfo)
        {
            m_dtAskInfo = null;
            DataView dv;
            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;
    
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                if (m_intStatus == -1)
                {
                    if (m_strExpDeptID != string.Empty)
                    {
                        strSQL =
       @"select distinct a.seriesid_int,
								a.askid_vchr,
								b.lastname_vchr as askername,
								a.askdept_chr,
								c.deptname_vchr as askdeptname,
								decode(a.status_int,
											 0,
											 '作废',
											 1,
											 '新制',
											 2,
											 '提交',
											 3,
											 '药库审核',
											 4,
											 '药房审核',
											 5,
											 '入帐') as status_int,
								a.askdate_dat,
								a.askerid_chr,
								a.commiter_chr,
								d.lastname_vchr as commitername,
								a.commit_dat,
								a.comment_vchr,
								a.instoreid_vchr
	from t_ds_ask        a,
			 t_bse_employee  b,
			 t_bse_deptdesc  c,
			 t_bse_employee  d,
			 t_ds_ask_detail e
 where a.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.commiter_chr = d.empid_chr(+)
	 and a.seriesid_int = e.seriesid2_int(+)
	 and a.askdept_chr like ?
	 and a.exportdept_chr like ?
	 and e.medicinename_vchr like ?
	 and a.askid_vchr like ?
	 and a.askdate_dat between ? and ?
 order by a.askid_vchr desc";
                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                    }
                    else
                    {
                         strSQL =
     @"select distinct a.seriesid_int,
								a.askid_vchr,
								b.lastname_vchr as askername,
								a.askdept_chr,
								c.deptname_vchr as askdeptname,
								decode(a.status_int,
											 0,
											 '作废',
											 1,
											 '新制',
											 2,
											 '提交',
											 3,
											 '药库审核',
											 4,
											 '药房审核',
											 5,
											 '入帐') as status_int,
								a.askdate_dat,
								a.askerid_chr,
								a.commiter_chr,
								d.lastname_vchr as commitername,
								a.commit_dat,
								a.comment_vchr,
								a.instoreid_vchr
	from t_ds_ask        a,
			 t_bse_employee  b,
			 t_bse_deptdesc  c,
			 t_bse_employee  d,
			 t_ds_ask_detail e
 where a.askerid_chr = b.empid_chr(+) 
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.commiter_chr = d.empid_chr(+)
	 and a.seriesid_int = e.seriesid2_int(+)
	 and a.askdept_chr like ?
	 and e.medicinename_vchr like ?
	 and a.askid_vchr like ?
	 and a.askdate_dat between ? and ?
 order by a.askid_vchr desc";
                        objHRPServ.CreateDatabaseParameter(5, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[3].DbType = DbType.DateTime;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                    }
                }
                else
                {
                    if (m_strExpDeptID != string.Empty)
                    {
                        strSQL =
       @"select distinct a.seriesid_int,
								a.askid_vchr,
								b.lastname_vchr as askername,
								a.askdept_chr,
								c.deptname_vchr as askdeptname,
								decode(a.status_int,
											 0,
											 '作废',
											 1,
											 '新制',
											 2,
											 '提交',
											 3,
											 '药库审核',
											 4,
											 '药房审核',
											 5,
											 '入帐') as status_int,
								a.askdate_dat,
								a.askerid_chr,
								a.commiter_chr,
								d.lastname_vchr as commitername,
								a.commit_dat,
								a.comment_vchr,
								a.instoreid_vchr
	from t_ds_ask        a,
			 t_bse_employee  b,
			 t_bse_deptdesc  c,
			 t_bse_employee  d,
			 t_ds_ask_detail e
 where a.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.commiter_chr = d.empid_chr(+)
	 and a.seriesid_int = e.seriesid2_int(+)
	 and a.askdept_chr like ?
	 and a.exportdept_chr like ?
	 and e.medicinename_vchr like ?
	 and a.askid_vchr like ?
	 and a.status_int = ?
	 and a.askdate_dat between ? and ?
 order by a.askid_vchr desc";
                        objHRPServ.CreateDatabaseParameter(7, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = m_intStatus;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        m_objParaArr[6].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[6].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                    }
                    else
                    {
                        strSQL =
        @"select distinct a.seriesid_int,
								a.askid_vchr,
								b.lastname_vchr as askername,
								a.askdept_chr,
								c.deptname_vchr as askdeptname,
								decode(a.status_int,
											 0,
											 '作废',
											 1,
											 '新制',
											 2,
											 '提交',
											 3,
											 '药库审核',
											 4,
											 '药房审核',
											 5,
											 '入帐') as status_int,
								a.askdate_dat,
								a.askerid_chr,
								a.commiter_chr,
								d.lastname_vchr as commitername,
								a.commit_dat,
								a.comment_vchr,
								a.instoreid_vchr
	from t_ds_ask        a,
			 t_bse_employee  b,
			 t_bse_deptdesc  c,
			 t_bse_employee  d,
			 t_ds_ask_detail e
 where a.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.commiter_chr = d.empid_chr(+)
	 and a.seriesid_int = e.seriesid2_int(+)
	 and a.askdept_chr like ?
	 and e.medicinename_vchr like ?
	 and a.askid_vchr like ?
	 and a.status_int = ?
	 and a.askdate_dat between ? and ?
 order by a.askid_vchr desc";
                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = m_intStatus;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                    }
                }
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

        #region 老代码（20080718）
        #region 获取药房请领主表信息
//        /// <summary>
//        /// 获取药房请领主表信息
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="m_datBegin"></param>
//        /// <param name="m_datEnd"></param>
//        /// <param name="m_dtAskInfo"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, string  m_strBeginDate, string m_strEndDate,string m_strAskDeptid,string m_strExportDeptid ,out DataTable m_dtAskInfo,out DataTable m_dtOutstorage)
//        {
//            m_dtAskInfo = null;
//            m_dtOutstorage = null;
//            DataView dv;
//            long lngRes = 0;
//            if (m_strAskDeptid == string.Empty)
//            {
//                try
//                {
//                    if (m_strExportDeptid == string.Empty)
//                    {
//                        string strSQL =
//               @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askdate_dat between ? and ? 
//union
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.status_int = 2 order by askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
//                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[0].DbType = DbType.DateTime;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr
//       and a.askdate_dat between ? and ? 
//union
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr and a.status_int = 3
//order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
//                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[0].DbType = DbType.DateTime;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();
//                    }
//                    else
//                    {

//                        string strSQL =
//               @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.askdate_dat between ? and ? 
//union 
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.status_int = 2 order by askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strExportDeptid;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strExportDeptid;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.askid_vchr=f.askid_vchr
//       and a.askdate_dat between ? and ? 
//union 
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and trim(a.exportdept_chr)=?
//       and a.askid_vchr=f.askid_vchr and a.status_int = 3
//order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strExportDeptid;
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strExportDeptid;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();

//                    }
//                }
//                catch (Exception objEx)
//                {
//                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }
//            }
//            else
//            {

//                try
//                {
//                    if (m_strExportDeptid == string.Empty)
//                    {
//                        string strSQL =
//               @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askdate_dat between ? and ? 
//union
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.status_int = 2 order by a.askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strAskDeptid.Trim();
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr
//       and a.askdate_dat between ? and ? 
//union 
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//       and a.askid_vchr=f.askid_vchr and a.status_int = 3
//order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[1].DbType = DbType.DateTime;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = m_strAskDeptid.Trim();
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();
//                    }
//                    else
//                    {
//                        string strSQL =
//                              @"select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and trim(a.exportdept_chr) = ?
//	 and a.askdate_dat between ? and ?
// union
//select a.seriesid_int,
//			 a.askid_vchr,
//			 b.lastname_vchr as askername,
//			 a.askdept_chr,
//			 c.deptname_vchr as askdeptname,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as status_int,
//			 a.askdate_dat,
//			 a.askerid_chr,
//			 a.commiter_chr,
//			 d.lastname_vchr as commitername,
//			 a.commit_dat,
//			 a.comment_vchr,
//			 a.exportdept_chr,
//			 e.medicineroomname as exportdeptname,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e
// where a.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and a.commiter_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and trim(a.exportdept_chr) = ?
//	 and a.status_int = 2
// order by askid_vchr desc";

//                        clsHRPTableService objHRPServ = new clsHRPTableService();
//                        System.Data.IDataParameter[] m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = m_strExportDeptid;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[3].DbType = DbType.DateTime;
//                        m_objParaArr[4].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[5].Value = m_strExportDeptid;
                       
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
//                        dv = m_dtAskInfo.DefaultView;
//                        dv.RowFilter = "status_int <> '作废'";
//                        m_dtAskInfo = dv.ToTable();
//                        strSQL = @"select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and a.askid_vchr = f.askid_vchr
//	 and trim(a.exportdept_chr) = ?
//	 and a.askdate_dat between ? and ?
//union
//select a.seriesid_int as askseriesid_int,
//			 a.askid_vchr,
//			 a.askdept_chr,
//			 f.askerid_chr,
//			 decode(a.status_int,
//							0,
//							'作废',
//							1,
//							'新制',
//							2,
//							'提交',
//							3,
//							'药库审核',
//							4,
//							'药房审核',
//							5,
//							'入帐') as askstatusname,
//			 a.status_int as askstatus_int,
//			 a.instoreid_vchr,
//			 f.askdate_dat,
//			 a.exportdept_chr,
//			 b.lastname_vchr as askername,
//			 c.deptname_vchr as askdeptname,
//			 e.medicineroomname as storagename,
//			 f.seriesid_int,
//			 f.outstorageid_vchr,
//			 f.examdate_dat,
//			 f.examerid_chr,
//			 d.lastname_vchr as examername,
//			 f.outstoragedate_dat,
//			 f.comment_vchr,
//			 e.deptid_chr as storageid_chr,
//			 a.instoreid_vchr
//	from t_ds_ask a,
//			 t_bse_employee b,
//			 t_bse_deptdesc c,
//			 t_bse_employee d,
//			 (select distinct medicineroomid, medicineroomname, deptid_chr
//					from t_ms_medicinestoreroomset) e,
//			 t_ms_outstorage f
// where f.askerid_chr = b.empid_chr(+)
//	 and a.askdept_chr = c.deptid_chr(+)
//	 and a.askdept_chr = ?
//	 and f.examerid_chr = d.empid_chr(+)
//	 and trim(a.exportdept_chr) = e.medicineroomid(+)
//	 and a.askid_vchr = f.askid_vchr
//	 and trim(a.exportdept_chr) = ? and a.status_int = 3
// order by askid_vchr desc";
//                        m_objParaArr = null;
//                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
//                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[1].Value = m_strExportDeptid;
//                        m_objParaArr[2].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
//                        m_objParaArr[2].DbType = DbType.DateTime;
//                        m_objParaArr[3].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
//                        m_objParaArr[3].DbType = DbType.DateTime;
//                        m_objParaArr[4].Value = m_strAskDeptid.Trim();
//                        m_objParaArr[5].Value = m_strExportDeptid;
//                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
//                        dv = m_dtOutstorage.DefaultView;
//                        dv.RowFilter = "askstatus_int <>0";
//                        m_dtOutstorage = dv.ToTable();
//                    }
//                }
//                catch (Exception objEx)
//                {
//                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                    bool blnRes = objLogger.LogError(objEx);
//                }


//            }
//            return lngRes;
//        }
        #endregion 
        #endregion

        #region 获取药房请领主表信息
        /// <summary>
        /// 获取药房请领主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptid"></param>
        /// <param name="m_strExportDeptid"></param>
        /// <param name="m_dtAskInfo"></param>
        /// <param name="m_dtOutstorage"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAskInfo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strBeginDate, string m_strEndDate, string m_strAskDeptid, string m_strExportDeptid, out DataTable m_dtAskInfo, out DataTable m_dtOutstorage)
        {
            m_dtAskInfo = null;
            m_dtOutstorage = null;
            DataView dv;
            long lngRes = 0;
            if (m_strAskDeptid == string.Empty)
            {
                try
                {
                    if (m_strExportDeptid == string.Empty)
                    {
                        string strSQL =
               @"select a.seriesid_int,
       a.askid_vchr,
       b.lastname_vchr as askername,
       a.askdept_chr,
       c.deptname_vchr as askdeptname,
       decode(a.status_int,
              0,
              '作废',
              1,
              '新制',
              2,
              '提交',
              3,
              '药库审核',
              4,
              '药房审核',
              5,
              '入帐') as status_int,
       a.askdate_dat,
       a.askerid_chr,
       a.commiter_chr,
       d.lastname_vchr as commitername,
       a.commit_dat,
       a.comment_vchr,
       a.exportdept_chr,
       e.medicineroomname as exportdeptname,
       e.deptid_chr as storageid_chr,
       a.instoreid_vchr,0 summoney
  from t_ds_ask a,
       t_bse_employee b,
       t_bse_deptdesc c,
       t_bse_employee d,
       (select distinct medicineroomid, medicineroomname, deptid_chr
          from t_ms_medicinestoreroomset) e
 where a.askerid_chr = b.empid_chr(+)
   and a.askdept_chr = c.deptid_chr(+)
   and a.commiter_chr = d.empid_chr(+)
   and trim(a.exportdept_chr) = e.medicineroomid(+)
   and (a.askdate_dat between ? and ? or a.status_int = 2)
 order by askid_vchr desc";

                        clsHRPTableService objHRPServ = new clsHRPTableService();
                        System.Data.IDataParameter[] m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[0].DbType = DbType.DateTime;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                        strSQL = @"select a.seriesid_int as askseriesid_int,
			 a.askid_vchr,
			 a.askdept_chr,
			 f.askerid_chr,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as askstatusname,
			 a.status_int as askstatus_int,
			 a.instoreid_vchr,
			 f.askdate_dat,
			 a.exportdept_chr,
			 b.lastname_vchr as askername,
			 c.deptname_vchr as askdeptname,
			 e.medicineroomname as storagename,
			 f.seriesid_int,
			 f.outstorageid_vchr,
			 f.examdate_dat,
			 f.examerid_chr,
			 d.lastname_vchr as examername,
			 f.outstoragedate_dat,
			 f.comment_vchr,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e,
			 t_ms_outstorage f
 where f.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and f.examerid_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
       and a.askid_vchr=f.askid_vchr
       and (a.askdate_dat between ? and ? or a.status_int = 3)
order by askid_vchr desc";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[0].DbType = DbType.DateTime;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPServ.Dispose();
                objHRPServ = null;
                        dv = m_dtOutstorage.DefaultView;
                        dv.RowFilter = "askstatus_int <>0";
                        m_dtOutstorage = dv.ToTable();
                    }
                    else
                    {

                        string strSQL =
               @"select a.seriesid_int,
			 a.askid_vchr,
			 b.lastname_vchr as askername,
			 a.askdept_chr,
			 c.deptname_vchr as askdeptname,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as status_int,
			 a.askdate_dat,
			 a.askerid_chr,
			 a.commiter_chr,
			 d.lastname_vchr as commitername,
			 a.commit_dat,
			 a.comment_vchr,
			 a.exportdept_chr,
			 e.medicineroomname as exportdeptname,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e
 where a.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.commiter_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
       and trim(a.exportdept_chr)=?
       and (a.askdate_dat between ? and ? or a.status_int = 2)
order by askid_vchr desc";

                        clsHRPTableService objHRPServ = new clsHRPTableService();
                        System.Data.IDataParameter[] m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = m_strExportDeptid;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[2].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                        strSQL = @"select a.seriesid_int as askseriesid_int,
			 a.askid_vchr,
			 a.askdept_chr,
			 f.askerid_chr,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as askstatusname,
			 a.status_int as askstatus_int,
			 a.instoreid_vchr,
			 f.askdate_dat,
			 a.exportdept_chr,
			 b.lastname_vchr as askername,
			 c.deptname_vchr as askdeptname,
			 e.medicineroomname as storagename,
			 f.seriesid_int,
			 f.outstorageid_vchr,
			 f.examdate_dat,
			 f.examerid_chr,
			 d.lastname_vchr as examername,
			 f.outstoragedate_dat,
			 f.comment_vchr,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e,
			 t_ms_outstorage f
 where f.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and f.examerid_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
       and trim(a.exportdept_chr)=?
       and a.askid_vchr=f.askid_vchr
       and (a.askdate_dat between ? and ? or a.status_int = 3)
order by askid_vchr desc";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = m_strExportDeptid;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[2].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPServ.Dispose();
                objHRPServ = null;
                        dv = m_dtOutstorage.DefaultView;
                        dv.RowFilter = "askstatus_int <>0";
                        m_dtOutstorage = dv.ToTable();

                    }
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {

                try
                {
                    if (m_strExportDeptid == string.Empty)
                    {
                        string strSQL =
               @"select a.seriesid_int,
			 a.askid_vchr,
			 b.lastname_vchr as askername,
			 a.askdept_chr,
			 c.deptname_vchr as askdeptname,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as status_int,
			 a.askdate_dat,
			 a.askerid_chr,
			 a.commiter_chr,
			 d.lastname_vchr as commitername,
			 a.commit_dat,
			 a.comment_vchr,
			 a.exportdept_chr,
			 e.medicineroomname as exportdeptname,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e
 where a.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.askdept_chr = ?
	 and a.commiter_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
       and (a.askdate_dat between ? and ? or a.status_int = 2)
order by a.askid_vchr desc";

                        clsHRPTableService objHRPServ = new clsHRPTableService();
                        System.Data.IDataParameter[] m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[2].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                        strSQL = @"select a.seriesid_int as askseriesid_int,
			 a.askid_vchr,
			 a.askdept_chr,
			 f.askerid_chr,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as askstatusname,
			 a.status_int as askstatus_int,
			 a.instoreid_vchr,
			 f.askdate_dat,
			 a.exportdept_chr,
			 b.lastname_vchr as askername,
			 c.deptname_vchr as askdeptname,
			 e.medicineroomname as storagename,
			 f.seriesid_int,
			 f.outstorageid_vchr,
			 f.examdate_dat,
			 f.examerid_chr,
			 d.lastname_vchr as examername,
			 f.outstoragedate_dat,
			 f.comment_vchr,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e,
			 t_ms_outstorage f
 where f.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.askdept_chr = ?
	 and f.examerid_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
       and a.askid_vchr=f.askid_vchr
       and (a.askdate_dat between ? and ? or a.status_int = 3)
order by askid_vchr desc";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[2].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        dv = m_dtOutstorage.DefaultView;
                        dv.RowFilter = "askstatus_int <>0";
                        m_dtOutstorage = dv.ToTable();
                    }
                    else
                    {
                        string strSQL =
                              @"select a.seriesid_int,
			 a.askid_vchr,
			 b.lastname_vchr as askername,
			 a.askdept_chr,
			 c.deptname_vchr as askdeptname,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as status_int,
			 a.askdate_dat,
			 a.askerid_chr,
			 a.commiter_chr,
			 d.lastname_vchr as commitername,
			 a.commit_dat,
			 a.comment_vchr,
			 a.exportdept_chr,
			 e.medicineroomname as exportdeptname,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e
 where a.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.askdept_chr = ?
	 and a.commiter_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
	 and trim(a.exportdept_chr) = ?
	 and (a.askdate_dat between ? and ? or a.status_int = 2)
 order by askid_vchr desc";

                        clsHRPTableService objHRPServ = new clsHRPTableService();
                        System.Data.IDataParameter[] m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
                        m_objParaArr[1].Value = m_strExportDeptid;
                        m_objParaArr[2].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[2].DbType = DbType.DateTime;
                        m_objParaArr[3].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[3].DbType = DbType.DateTime;

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskInfo, m_objParaArr);
                        dv = m_dtAskInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        m_dtAskInfo = dv.ToTable();
                        strSQL = @"select a.seriesid_int as askseriesid_int,
			 a.askid_vchr,
			 a.askdept_chr,
			 f.askerid_chr,
			 decode(a.status_int,
							0,
							'作废',
							1,
							'新制',
							2,
							'提交',
							3,
							'药库审核',
							4,
							'药房审核',
							5,
							'入帐') as askstatusname,
			 a.status_int as askstatus_int,
			 a.instoreid_vchr,
			 f.askdate_dat,
			 a.exportdept_chr,
			 b.lastname_vchr as askername,
			 c.deptname_vchr as askdeptname,
			 e.medicineroomname as storagename,
			 f.seriesid_int,
			 f.outstorageid_vchr,
			 f.examdate_dat,
			 f.examerid_chr,
			 d.lastname_vchr as examername,
			 f.outstoragedate_dat,
			 f.comment_vchr,
			 e.deptid_chr as storageid_chr,
			 a.instoreid_vchr,0 summoney
	from t_ds_ask a,
			 t_bse_employee b,
			 t_bse_deptdesc c,
			 t_bse_employee d,
			 (select distinct medicineroomid, medicineroomname, deptid_chr
					from t_ms_medicinestoreroomset) e,
			 t_ms_outstorage f
 where f.askerid_chr = b.empid_chr(+)
	 and a.askdept_chr = c.deptid_chr(+)
	 and a.askdept_chr = ?
	 and f.examerid_chr = d.empid_chr(+)
	 and trim(a.exportdept_chr) = e.medicineroomid(+)
	 and a.askid_vchr = f.askid_vchr
	 and trim(a.exportdept_chr) = ?
	 and (a.askdate_dat between ? and ? or a.status_int = 3)
 order by askid_vchr desc";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(4, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptid.Trim();
                        m_objParaArr[1].Value = m_strExportDeptid;
                        m_objParaArr[2].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[2].DbType = DbType.DateTime;
                        m_objParaArr[3].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[3].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        dv = m_dtOutstorage.DefaultView;
                        dv.RowFilter = "askstatus_int <>0";
                        m_dtOutstorage = dv.ToTable();
                    }
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }


            }
            return lngRes;
        }
        #endregion 

        #region 根据主表流水号获取明细表信息
        /// <summary>
        /// 根据主表流水号获取明细表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="m_lngSeqid">ID</param>
        /// <param name="m_dtAskDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAskDetailInfoByid(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital, long m_lngSeqid, out DataTable m_dtAskDetail)
        {
            m_dtAskDetail = null;
            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;
                if (p_blnIsHospital)
                {
                    strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       b.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr,
       a.opamount_int,
       a.ipunit_chr,
       a.ipamount_int,
       b.opchargeflg_int,b.ipchargeflg_int,
       decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
       decode(b.ipchargeflg_int, 0, a.opamount_int, a.ipamount_int) amount_int,
       a.packqty_dec,
       case
         when a.enough_chr = '+' then
          '充足'
         when a.enough_chr = '-' then
          '不足'
         else
          '未知'
       end enough_chr,
       a.productorid_chr,
       a.requestunit_chr,
       a.requestpackqty_dec,
       a.requestamount_int,
       b.unitprice_mny,
       a.opamount_int * b.unitprice_mny as retailsum,
       b.medicinetypeid_chr
  from t_ds_ask_detail a, t_bse_medicine b
 where a.seriesid2_int = ?
   and a.medicineid_chr = b.medicineid_chr(+)";
                }
                else
                {
                    strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       b.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr,
       a.opamount_int,
       a.ipunit_chr,
       a.ipamount_int,
       b.opchargeflg_int,b.ipchargeflg_int,
       decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
       decode(b.opchargeflg_int, 0, a.opamount_int, a.ipamount_int) amount_int,
       a.packqty_dec,
       case
         when a.enough_chr = '+' then
          '充足'
         when a.enough_chr = '-' then
          '不足'
         else
          '未知'
       end enough_chr,
       a.productorid_chr,
       a.requestunit_chr,
       a.requestpackqty_dec,
       a.requestamount_int,
       b.unitprice_mny,
       a.opamount_int * b.unitprice_mny as retailsum,
       b.medicinetypeid_chr
  from t_ds_ask_detail a, t_bse_medicine b
 where a.seriesid2_int = ?
   and a.medicineid_chr = b.medicineid_chr(+)";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = m_lngSeqid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskDetail, m_objParaArr);
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
       
        #region 获取药房请领主表信息和相对应药库出库主表信息
        /// <summary>
        /// 获取药房请领主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptID"></param>
        /// <param name="m_strExpDeptID">出库部门</param>
        /// <param name="m_intStatus">-1:全部状态 状态 0、作废、1、新制   2、提交 3、药库审核4、药房审核</param>
        /// <param name="m_strMedName"></param>
        /// <param name="m_strAskid"></param>
        /// <param name="p_intBillType">单据类型：0请领单，1入库单，2出库单</param>
        /// <param name="m_dtAskMainInfo"></param>
        /// <param name="m_dtOutStorageMainInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAskInfoAndOutStorageInfo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strBeginDate, string m_strEndDate,
            string m_strAskDeptID, string m_strExpDeptID, int m_intStatus, string m_strMedName, string m_strAskid,int p_intBillType, out DataTable m_dtAskMainInfo,out DataTable  m_dtOutStorageMainInfo)
        {
            m_dtAskMainInfo =new DataTable ();
            m_dtOutStorageMainInfo =new DataTable ();
            long lngRes = 0;
            DataView dv;
            try
            {
                string strSQL = string.Empty;

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                if (m_intStatus == -1)
                {
                    if (m_strExpDeptID != string.Empty)
                    {
                        strSQL =
       @"select distinct a.seriesid_int,
                a.askid_vchr,
                b.lastname_vchr as askername,
                a.askdept_chr,
                c.deptname_vchr as askdeptname,
                decode(a.status_int,
                       0,
                       '作废',
                       1,
                       '新制',
                       2,
                       '提交',
                       3,
                       '药库审核',
                       4,
                       '药房审核',
                       5,
                       '入帐') as status_int,
                a.askdate_dat,
                a.askerid_chr,
                a.commiter_chr,
                d.lastname_vchr as commitername,
                a.commit_dat,
                a.comment_vchr,
                a.exportdept_chr,
                f.medicineroomname as exportdeptname,
                0 summoney
        from t_ds_ask a,
       t_bse_employee b,
       t_bse_deptdesc c,
       t_bse_employee d,
       t_ds_ask_detail e,
       (select distinct medicineroomid, medicineroomname
          from t_ms_medicinestoreroomset) f,
          t_ds_instorage g,
          t_ms_outstorage h
 where a.askerid_chr = b.empid_chr(+)
   and a.askdept_chr = c.deptid_chr(+)
   and a.commiter_chr = d.empid_chr(+)
   and a.seriesid_int = e.seriesid2_int(+)
   and trim(a.exportdept_chr) = f.medicineroomid(+)
   and a.askid_vchr = g.askid_vchr(+)
   and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and a.exportdept_chr like ?
       and e.medicinename_vchr like ? ";
                        if (p_intBillType == 0)
                        {
                            strSQL += @" and a.askid_vchr like ? ";
                        }
                        else if (p_intBillType == 1)
                        {
                            strSQL += @" and g.indrugstoreid_vchr like ? ";
                        }
                        else if (p_intBillType == 2)
                        {
                            strSQL += @" and h.outstorageid_vchr like ? ";
                        }
                        strSQL += @" and a.askdate_dat between ? and ?";

                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskMainInfo, m_objParaArr);
                        dv = m_dtAskMainInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        dv.Sort = "askid_vchr desc";
                        m_dtAskMainInfo = dv.ToTable();

                        strSQL = @"select distinct a.seriesid_int as askseriesid_int,
                a.askid_vchr,
                a.askdept_chr,
                f.askerid_chr,
                decode(a.status_int,
                       0,
                       '作废',
                       1,
                       '新制',
                       2,
                       '提交',
                       3,
                       '药库审核',
                       4,
                       '药房审核',
                       5,
                       '入帐') as askstatusname,
                a.status_int as askstatus_int,
                a.instoreid_vchr,
                f.askdate_dat,
                a.exportdept_chr,
                b.lastname_vchr as askername,
                c.deptname_vchr as askdeptname,
                e.medicineroomname as storagename,
                f.seriesid_int,
                f.outstorageid_vchr,
                f.examdate_dat,
                f.examerid_chr,
                d.lastname_vchr as examername,
                f.outstoragedate_dat,
                f.comment_vchr,
                e.deptid_chr as storageid_chr,
                0 summoney
  from t_ds_ask a,
       t_bse_employee b,
       t_bse_deptdesc c,
       t_bse_employee d,
       (select distinct medicineroomid, medicineroomname, deptid_chr
          from t_ms_medicinestoreroomset) e,
       t_ms_outstorage f,
       t_ds_ask_detail g,
       t_ds_instorage h
 where f.askerid_chr = b.empid_chr(+)
   and a.askdept_chr = c.deptid_chr(+)
   and a.seriesid_int = g.seriesid2_int(+)
   and f.examerid_chr = d.empid_chr(+)
   and trim(a.exportdept_chr) = e.medicineroomid(+)
   and a.askid_vchr = f.askid_vchr
   and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and a.exportdept_chr like ?
       and g.medicinename_vchr like ? ";
                        if(p_intBillType == 0)
                        {
                            strSQL += @"and a.askid_vchr like ? ";
                        }
                        else if(p_intBillType == 1)
                        {
                            strSQL += @"and h.indrugstoreid_vchr like ? ";
                        }
                        else if(p_intBillType == 2)
                        {
                            strSQL += @"and f.outstorageid_vchr like ? ";
                        }
                        strSQL += " and a.askdate_dat between ? and ?";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                        dv = m_dtOutStorageMainInfo.DefaultView;
                        dv.RowFilter = "askstatus_int <> 0";
                        dv.Sort = "outstorageid_vchr desc";
                        m_dtOutStorageMainInfo = dv.ToTable();
                    }
                    else
                    {
                        strSQL =
    @"select distinct a.seriesid_int, a.askid_vchr, b.lastname_vchr as askername,
       a.askdept_chr, c.deptname_vchr as askdeptname,
       decode (a.status_int,
               0, '作废',
               1, '新制',
               2, '提交',
               3, '药库审核',
               4, '药房审核',5,'入帐'
              ) as status_int,
       a.askdate_dat, a.askerid_chr, a.commiter_chr,
       d.lastname_vchr as commitername, a.commit_dat, a.comment_vchr,a.exportdept_chr,f.medicineroomname as exportdeptname,0 summoney
       from t_ds_ask a, t_bse_employee b, t_bse_deptdesc c, t_bse_employee d,t_ds_ask_detail e ,
(select distinct medicineroomid,medicineroomname from t_ms_medicinestoreroomset) f,
          t_ds_instorage g,
          t_ms_outstorage h
       where a.askerid_chr = b.empid_chr(+)
       and a.askdept_chr = c.deptid_chr(+)
       and a.commiter_chr = d.empid_chr(+)
       and trim(a.exportdept_chr)=f.medicineroomid(+)
       and a.seriesid_int=e.seriesid2_int(+)
        and a.askid_vchr = g.askid_vchr(+)
        and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and e.medicinename_vchr like ? ";
                        if (p_intBillType == 0)
                        {
                            strSQL += @" and a.askid_vchr like ? ";
                        }
                        else if (p_intBillType == 1)
                        {
                            strSQL += @" and g.indrugstoreid_vchr like ? ";
                        }
                        else if (p_intBillType == 2)
                        {
                            strSQL += @" and h.outstorageid_vchr like ? ";
                        }
                        strSQL += @" and a.askdate_dat between ? and ?";

                        objHRPServ.CreateDatabaseParameter(5, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[3].DbType = DbType.DateTime;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskMainInfo, m_objParaArr);
                        dv = m_dtAskMainInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        dv.Sort = "askid_vchr desc";
                        m_dtAskMainInfo = dv.ToTable();
                        strSQL = @"select distinct a.seriesid_int as askseriesid_int, a.askid_vchr,a.askdept_chr, f.askerid_chr,
       decode (a.status_int,
               0, '作废',
               1, '新制',
               2, '提交',
               3, '药库审核',
               4, '药房审核',5,'入帐'
              ) as askstatusname,a.status_int as askstatus_int,a.instoreid_vchr,
       f.askdate_dat,a.exportdept_chr,b.lastname_vchr as askername,  c.deptname_vchr as askdeptname,e.medicineroomname as storagename,
       f.seriesid_int,f.outstorageid_vchr,f.examdate_dat,f.examerid_chr,d.lastname_vchr as examername,f.outstoragedate_dat,f.comment_vchr,e.deptid_chr as storageid_chr,0 summoney
       from t_ds_ask a, t_bse_employee b, t_bse_deptdesc c, t_bse_employee d,(select distinct medicineroomid,medicineroomname,deptid_chr from t_ms_medicinestoreroomset) e,
t_ms_outstorage f,t_ds_ask_detail g,
       t_ds_instorage h
       where f.askerid_chr = b.empid_chr(+)
       and a.askdept_chr = c.deptid_chr(+)
       and a.seriesid_int=g.seriesid2_int(+)
       and f.examerid_chr = d.empid_chr(+)
       and trim(a.exportdept_chr)=e.medicineroomid(+)
       and a.askid_vchr=f.askid_vchr
 and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and g.medicinename_vchr like ? ";
                        if(p_intBillType == 0)
                        {
                            strSQL += @"and a.askid_vchr like ? ";
                        }
                        else if(p_intBillType == 1)
                        {
                            strSQL += @"and h.indrugstoreid_vchr like ? ";
                        }
                        else if(p_intBillType == 2)
                        {
                            strSQL += @"and f.outstorageid_vchr like ? ";
                        }
                        strSQL += " and a.askdate_dat between ? and ?";

                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(5, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[3].DbType = DbType.DateTime;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                        dv = m_dtOutStorageMainInfo.DefaultView;
                        dv.RowFilter = "askstatus_int <> 0";
                        dv.Sort = "outstorageid_vchr desc";
                        m_dtOutStorageMainInfo = dv.ToTable();
                    }
                }
                else
                {
                    if (m_strExpDeptID != string.Empty)
                    {
                        strSQL =
       @"select distinct a.seriesid_int, a.askid_vchr, b.lastname_vchr as askername,
       a.askdept_chr, c.deptname_vchr as askdeptname,
       decode (a.status_int,
               0, '作废',
               1, '新制',
               2, '提交',
               3, '药库审核',
               4, '药房审核',5,'入帐'
              ) as status_int,
       a.askdate_dat, a.askerid_chr, a.commiter_chr,
       d.lastname_vchr as commitername, a.commit_dat, a.comment_vchr,a.exportdept_chr,f.medicineroomname as exportdeptname,0 summoney
       from t_ds_ask a, t_bse_employee b, t_bse_deptdesc c, t_bse_employee d,t_ds_ask_detail e ,(select distinct medicineroomid,medicineroomname from t_ms_medicinestoreroomset) f,
          t_ds_instorage g,
          t_ms_outstorage h
       where a.askerid_chr = b.empid_chr(+)
       and a.askdept_chr = c.deptid_chr(+)
       and a.commiter_chr = d.empid_chr(+)
       and trim(a.exportdept_chr)=f.medicineroomid(+)
       and a.seriesid_int=e.seriesid2_int(+)
        and a.askid_vchr = g.askid_vchr(+)
        and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and a.exportdept_chr like ?
       and e.medicinename_vchr like ? ";
                        if (p_intBillType == 0)
                        {
                            strSQL += @" and a.askid_vchr like ? ";
                        }
                        else if (p_intBillType == 1)
                        {
                            strSQL += @" and g.indrugstoreid_vchr like ? ";
                        }
                        else if (p_intBillType == 2)
                        {
                            strSQL += @" and h.outstorageid_vchr like ? ";
                        }
                        strSQL += @" and a.status_int= ? and a.askdate_dat between ? and ?";

                        objHRPServ.CreateDatabaseParameter(7, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = m_intStatus;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        m_objParaArr[6].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[6].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskMainInfo, m_objParaArr);
                        dv = m_dtAskMainInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        dv.Sort = "askid_vchr desc";
                        m_dtAskMainInfo = dv.ToTable();
                        strSQL = @"select distinct a.seriesid_int as askseriesid_int, a.askid_vchr,a.askdept_chr, f.askerid_chr,
       decode (a.status_int,
               0, '作废',
               1, '新制',
               2, '提交',
               3, '药库审核',
               4, '药房审核',5,'入帐'
              ) as askstatusname,a.status_int as askstatus_int,a.instoreid_vchr,
       f.askdate_dat,a.exportdept_chr,b.lastname_vchr as askername,  c.deptname_vchr as askdeptname,e.medicineroomname as storagename,
       f.seriesid_int,f.outstorageid_vchr,f.examdate_dat,f.examerid_chr,d.lastname_vchr as examername,f.outstoragedate_dat,f.comment_vchr,e.deptid_chr as storageid_chr,0 summoney
       from t_ds_ask a, t_bse_employee b, t_bse_deptdesc c, t_bse_employee d,(select distinct medicineroomid,medicineroomname,deptid_chr from t_ms_medicinestoreroomset) e,
t_ms_outstorage f,t_ds_ask_detail g,
       t_ds_instorage h
       where f.askerid_chr = b.empid_chr(+)
       and a.askdept_chr = c.deptid_chr(+)
       and f.examerid_chr = d.empid_chr(+)
       and a.seriesid_int=g.seriesid2_int(+)
       and trim(a.exportdept_chr)=e.medicineroomid(+)
       and a.askid_vchr=f.askid_vchr
 and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and a.exportdept_chr like ?
       and g.medicinename_vchr like ? ";
                        if(p_intBillType == 0)
                        {
                            strSQL += @"and a.askid_vchr like ? ";
                        }
                        else if(p_intBillType == 1)
                        {
                            strSQL += @"and h.indrugstoreid_vchr like ? ";
                        }
                        else if(p_intBillType == 2)
                        {
                            strSQL += @"and f.outstorageid_vchr like ? ";
                        }
                        strSQL += " and a.status_int= ? and a.askdate_dat between ? and ?";

                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(7, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = m_intStatus;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        m_objParaArr[6].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[6].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                        dv = m_dtOutStorageMainInfo.DefaultView;
                        dv.RowFilter = "askstatus_int <> 0";
                        dv.Sort = "outstorageid_vchr desc";
                        m_dtOutStorageMainInfo = dv.ToTable();
                    }
                    else
                    {
                        strSQL =
        @"select distinct a.seriesid_int, a.askid_vchr, b.lastname_vchr as askername,
       a.askdept_chr, c.deptname_vchr as askdeptname,
       decode (a.status_int,
               0, '作废',
               1, '新制',
               2, '提交',
               3, '药库审核',
               4, '药房审核',5,'入帐'
              ) as status_int,
       a.askdate_dat, a.askerid_chr, a.commiter_chr,
       d.lastname_vchr as commitername, a.commit_dat, a.comment_vchr,a.exportdept_chr,f.medicineroomname as exportdeptname,0 summoney
       from t_ds_ask a, t_bse_employee b, t_bse_deptdesc c, t_bse_employee d,t_ds_ask_detail e ,(select distinct medicineroomid,medicineroomname from t_ms_medicinestoreroomset) f,
          t_ds_instorage g,
          t_ms_outstorage h
       where a.askerid_chr = b.empid_chr(+)
       and a.askdept_chr = c.deptid_chr(+)
       and a.commiter_chr = d.empid_chr(+)
       and trim(a.exportdept_chr)=f.medicineroomid(+)
       and a.seriesid_int=e.seriesid2_int(+)
and a.askid_vchr = g.askid_vchr(+)
   and a.askid_vchr = h.askid_vchr(+)
       and a.askdept_chr like ?
       and e.medicinename_vchr like ? ";
                        if (p_intBillType == 0)
                        {
                            strSQL += @" and a.askid_vchr like ? ";
                        }
                        else if (p_intBillType == 1)
                        {
                            strSQL += @" and g.indrugstoreid_vchr like ? ";
                        }
                        else if (p_intBillType == 2)
                        {
                            strSQL += @" and h.outstorageid_vchr like ? ";
                        }
                        strSQL += @" and a.status_int= ? and a.askdate_dat between ? and ?";

                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = m_intStatus;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtAskMainInfo, m_objParaArr);
                        dv = m_dtAskMainInfo.DefaultView;
                        dv.RowFilter = "status_int <> '作废'";
                        dv.Sort = "askid_vchr desc";
                        m_dtAskMainInfo = dv.ToTable();
                        strSQL = @"select distinct a.seriesid_int as askseriesid_int, a.askid_vchr,a.askdept_chr, f.askerid_chr,
       decode (a.status_int,
               0, '作废',
               1, '新制',
               2, '提交',
               3, '药库审核',
               4, '药房审核',5,'入帐'
              ) as askstatusname,a.status_int as askstatus_int,a.instoreid_vchr,
       f.askdate_dat,a.exportdept_chr,b.lastname_vchr as askername,  c.deptname_vchr as askdeptname,e.medicineroomname as storagename,
       f.seriesid_int,f.outstorageid_vchr,f.examdate_dat,f.examerid_chr,d.lastname_vchr as examername,f.outstoragedate_dat,f.comment_vchr,e.deptid_chr as storageid_chr,0 summoney
       from t_ds_ask a, t_bse_employee b, t_bse_deptdesc c, t_bse_employee d,(select distinct medicineroomid,medicineroomname,deptid_chr from t_ms_medicinestoreroomset) e,
t_ms_outstorage f,t_ds_ask_detail g,
       t_ds_instorage h
       where f.askerid_chr = b.empid_chr(+)
       and a.askdept_chr = c.deptid_chr(+)
       and f.examerid_chr = d.empid_chr(+)
       and a.seriesid_int=g.seriesid2_int(+)
       and trim(a.exportdept_chr)=e.medicineroomid(+)
       and a.askid_vchr=f.askid_vchr      
  and a.askid_vchr = h.askid_vchr(+)                                          
       and a.askdept_chr like ?
       and g.medicinename_vchr like ? ";
                         if(p_intBillType == 0)
                        {
                            strSQL += @"and a.askid_vchr like ? ";
                        }
                        else if(p_intBillType == 1)
                        {
                            strSQL += @"and h.indrugstoreid_vchr like ? ";
                        }
                        else if(p_intBillType == 2)
                        {
                            strSQL += @"and f.outstorageid_vchr like ? ";
                        }
                        strSQL += " and a.status_int= ? and a.askdate_dat between ? and ?";

                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = m_intStatus;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                        dv = m_dtOutStorageMainInfo.DefaultView;
                        dv.RowFilter = "askstatus_int <> 0";
                        dv.Sort = "outstorageid_vchr desc";
                        m_dtOutStorageMainInfo = dv.ToTable();
                    }
                }
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

        /*
        #region 获取药房出库明细数据
        /// <summary>
        /// 获取药房出库明细数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strBeginDate">出库开始日期</param>
        /// <param name="p_strEndDate">出库结束日期</param>
        /// <param name="p_dtbResult">出库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetOutStorageDetailData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strBeginDate, string p_strEndDate, ref DataTable p_dtbResult)
        {
            long lngRes = 0;            

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            StringBuilder strSQL = new StringBuilder(@"select 'F' IfCheck,
			 b.drugstoreid_chr,
			 d.medstorename_vchr,
			 c.assistcode_chr,
			 a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 sum(a.opamount_int) opamount_int,
			 a.opunit_chr,
			 sum(a.ipamount_int) ipamount_int,
			 a.ipunit_chr,
			 a.packqty_dec,
			 decode(c.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
			 sum(decode(c.opchargeflg_int, 0, a.opamount_int, a.ipamount_int)) amount_int,
			 c.opchargeflg_int,
			 c.productorid_chr,
			 c.unitprice_mny
	from t_ds_outstorage_detail a
	left join t_ds_outstorage b on b.seriesid_int = a.seriesid2_int
	left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
	left join t_bse_medstore d on d.deptid_chr = b.drugstoreid_chr
 where a.status = 1
	 and (b.status_int = 2 or b.status_int = 3)");
            try
            {
                int m_intParamCount = 1;

                StringBuilder m_strbCondition = new StringBuilder("");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(10, out tmp_objDPArr);
                strSQL.Append(@" and (d.medstoreid_chr = ?)");
                tmp_objDPArr[0].Value = p_strStorageID;
                if (p_strBeginDate.Trim().Length == 10 && p_strEndDate.Trim().Length != 10)
                {
                    strSQL.Append(@" and (b.examdate_dat>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(p_strBeginDate + " 00:00:00");
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }

                if (p_strEndDate.Trim().Length == 10 && p_strBeginDate.Trim().Length != 10)
                {
                    strSQL.Append(@" and  (b.examdate_dat<=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(p_strEndDate + " 23:59:59");
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }

                if (p_strBeginDate.Trim().Length == 10 && p_strEndDate.Trim().Length == 10)
                {
                    strSQL.Append(@" and (b.examdate_dat between ? and ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(p_strBeginDate + " 00:00:00");
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(p_strEndDate + " 23:59:59");
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }

                strSQL.Append(@" group by b.drugstoreid_chr,d.medstorename_vchr,assistcode_chr,a.medicineid_chr,a.medicinename_vchr,
                                a.medspec_vchr,a.opunit_chr,a.ipunit_chr,a.packqty_dec,c.opchargeflg_int,c.productorid_chr,c.unitprice_mny order by  c.assistcode_chr");

                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objDPArr);
                p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["medicineid_chr"] };
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_dtbResult = null;
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion
        */

        #region 获取金额信息
        /// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptID"></param>
        /// <param name="m_strExpDeptID"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_strMedName"></param>
        /// <param name="m_strAskid"></param>
        /// <param name="m_dtOutStorageMainInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMoney(string m_strBeginDate, string m_strEndDate,string m_strAskDeptID, string m_strExpDeptID, 
                                     int m_intStatus, string m_strMedName, string m_strAskid, out DataTable m_dtOutStorageMainInfo)
        {
            m_dtOutStorageMainInfo = null;
            string strSQL = string.Empty;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            IDataParameter[] m_objParaArr = null;
            long lngRes = -1;
            try
            {
                if (m_intStatus == -1)
                {
                    if (m_strExpDeptID != string.Empty)
                    {
                        strSQL = @"select    c.netamount_int * c.retailprice_int as retailmoney,
                                         c.callprice_int * c.netamount_int as inmoney,
                                         d.packqty_dec * c.netamount_int as ipamount
                                    from t_ds_ask a,
                                         t_ms_outstorage b,
                                         t_ms_outstorage_detail c,
                                         t_bse_medicine d
                                   where a.askid_vchr = b.askid_vchr
                                     and b.seriesid_int = c.seriesid2_int
                                     and c.medicineid_chr = d.medicineid_chr
                                     and a.askdept_chr like ?
                                     and a.exportdept_chr like ?
                                     and d.medicinename_vchr like ?
                                     and a.askid_vchr like ?
                                     and b.outstoragedate_dat between ? and ?
                                order by a.askid_vchr ";
                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);

                    }
                    else
                    {
                        strSQL = @"select    c.netamount_int * c.retailprice_int as retailmoney,
                                         c.callprice_int * c.netamount_int as inmoney,
                                         d.packqty_dec * c.netamount_int as ipamount
                                    from t_ds_ask a,
                                         t_ms_outstorage b,
                                         t_ms_outstorage_detail c,
                                         t_bse_medicine d
                                   where a.askid_vchr = b.askid_vchr
                                     and b.seriesid_int = c.seriesid2_int
                                     and c.medicineid_chr = d.medicineid_chr
                                     and a.askdept_chr like ?
                                     and d.medicinename_vchr like ?
                                     and a.askid_vchr like ?
                                     and b.outstoragedate_dat between ? and ?
                                order by a.askid_vchr ";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(5, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[3].DbType = DbType.DateTime;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                    }
                }
                else
                {
                    if (m_strExpDeptID != string.Empty)
                    {
                        strSQL = @"select    c.netamount_int * c.retailprice_int as retailmoney,
                                         c.callprice_int * c.netamount_int as inmoney,
                                         d.packqty_dec * c.netamount_int as ipamount
                                    from t_ds_ask a,
                                         t_ms_outstorage b,
                                         t_ms_outstorage_detail c,
                                         t_bse_medicine d
                                   where a.askid_vchr = b.askid_vchr
                                     and b.seriesid_int = c.seriesid2_int
                                     and c.medicineid_chr = d.medicineid_chr
                                     and a.askdept_chr like ?
                                     and a.exportdept_chr like ?
                                     and d.medicinename_vchr like ?
                                     and a.askid_vchr like ?
                                     and a.status_int = ?
                                     and b.outstoragedate_dat between ? and ?
                                order by a.askid_vchr  ";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(7, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strExpDeptID + "%";
                        m_objParaArr[2].Value = m_strMedName + "%";
                        m_objParaArr[3].Value = m_strAskid + "%";
                        m_objParaArr[4].Value = m_intStatus;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        m_objParaArr[6].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[6].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                    }
                    else
                    {
                        strSQL = @"select    c.netamount_int * c.retailprice_int as retailmoney,
                                         c.callprice_int * c.netamount_int as inmoney,
                                         d.packqty_dec * c.netamount_int as ipamount
                                    from t_ds_ask a,
                                         t_ms_outstorage b,
                                         t_ms_outstorage_detail c,
                                         t_bse_medicine d
                                   where a.askid_vchr = b.askid_vchr
                                     and b.seriesid_int = c.seriesid2_int
                                     and c.medicineid_chr = d.medicineid_chr
                                     and a.askdept_chr like ?
                                     and d.medicinename_vchr like ?
                                     and a.askid_vchr like ?
                                     and a.status_int = ?
                                     and b.outstoragedate_dat between ? and ?
                                order by a.askid_vchr  ";
                        m_objParaArr = null;
                        objHRPServ.CreateDatabaseParameter(6, out m_objParaArr);
                        m_objParaArr[0].Value = m_strAskDeptID + "%";
                        m_objParaArr[1].Value = m_strMedName + "%";
                        m_objParaArr[2].Value = m_strAskid + "%";
                        m_objParaArr[3].Value = m_intStatus;
                        m_objParaArr[4].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[4].DbType = DbType.DateTime;
                        m_objParaArr[5].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[5].DbType = DbType.DateTime;
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageMainInfo, m_objParaArr);
                    }
                }
                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion 

        #region 获取金额信息
        /// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strAskDeptid"></param>
        /// <param name="m_strExportDeptid"></param>
        /// <param name="m_dtOutstorage"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMoney(string m_strBeginDate, string m_strEndDate,string m_strAskDeptid, string m_strExportDeptid, out DataTable m_dtOutstorage)
        {
            m_dtOutstorage = null;
            string strSQL = string.Empty;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] m_objParaArr = null;
            long lngRes=-1;
            if (m_strAskDeptid == string.Empty)
            {
                try
                {
                    if (m_strExportDeptid == string.Empty)
                    {
                        strSQL = @"select  c.netamount_int * c.retailprice_int as retailmoney,
                                           c.callprice_int * c.netamount_int as inmoney,
                                           d.packqty_dec * c.netamount_int as ipamount
                                      from t_ds_ask a,
                                           t_ms_outstorage b,
                                           t_ms_outstorage_detail c,
                                           t_bse_medicine d
                                     where a.askid_vchr = b.askid_vchr
                                       and b.seriesid_int = c.seriesid2_int
                                       and c.medicineid_chr = d.medicineid_chr
                                       and b.status = 2
                                       and b.outstoragedate_dat between ? and ? ";
                        objHRPSvc.CreateDatabaseParameter(2, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[0].DbType = DbType.DateTime;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[1].DbType = DbType.DateTime;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage,m_objParaArr);
                        objHRPSvc.Dispose();
                    }
                    else
                    {
                        strSQL = @"select  c.netamount_int * c.retailprice_int as retailmoney,
                                           c.callprice_int * c.netamount_int as inmoney,
                                           d.packqty_dec * c.netamount_int as ipamount
                                      from t_ds_ask a,
                                           t_ms_outstorage b,
                                           t_ms_outstorage_detail c,
                                           t_bse_medicine d
                                     where a.askid_vchr = b.askid_vchr
                                       and b.seriesid_int = c.seriesid2_int
                                       and c.medicineid_chr = d.medicineid_chr
                                       and b.status = 2
                                       and b.outstoragedate_dat between ? and ?
                                       and trim (a.exportdept_chr) = ? ";
                        objHRPSvc.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[0].DbType = DbType.DateTime;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = m_strExportDeptid;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPSvc.Dispose();
                    }
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                try
                {
                    if (m_strExportDeptid == string.Empty)
                    {
                        strSQL = @"select  c.netamount_int * c.retailprice_int as retailmoney,
                                           c.callprice_int * c.netamount_int as inmoney,
                                           d.packqty_dec * c.netamount_int as ipamount
                                      from t_ds_ask a,
                                           t_ms_outstorage b,
                                           t_ms_outstorage_detail c,
                                           t_bse_medicine d
                                     where a.askid_vchr = b.askid_vchr
                                       and b.seriesid_int = c.seriesid2_int
                                       and c.medicineid_chr = d.medicineid_chr
                                       and b.status = 2
                                       and b.outstoragedate_dat between ? and ?
                                       and a.askdept_chr = ? ";
                        objHRPSvc.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[0].DbType = DbType.DateTime;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = m_strAskDeptid;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPSvc.Dispose();
                    }
                    else
                    {
                        strSQL = @"select  c.netamount_int * c.retailprice_int as retailmoney,
                                           c.callprice_int * c.netamount_int as inmoney,
                                           d.packqty_dec * c.netamount_int as ipamount
                                      from t_ds_ask a,
                                           t_ms_outstorage b,
                                           t_ms_outstorage_detail c,
                                           t_bse_medicine d
                                     where a.askid_vchr = b.askid_vchr
                                       and b.seriesid_int = c.seriesid2_int
                                       and c.medicineid_chr = d.medicineid_chr
                                       and b.status = 2
                                       and b.outstoragedate_dat between ? and ?
                                       and trim (a.exportdept_chr) = ?
                                       and a.askdept_chr = ? ";
                        objHRPSvc.CreateDatabaseParameter(4, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                        m_objParaArr[0].DbType = DbType.DateTime;
                        m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                        m_objParaArr[1].DbType = DbType.DateTime;
                        m_objParaArr[2].Value = m_strExportDeptid;
                        m_objParaArr[3].Value = m_strAskDeptid;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                        objHRPSvc.Dispose();
                    }

                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion      

        #region 获取基本药品信息(包含药库库存量)
        /// <summary>
        ///  获取基本药品信息(包含药库库存量)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strMedStoreid">药房</param>
        /// <param name="m_strStorageid">药库</param>
        /// <param name="m_dtMedicineInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInfoWithStorageID(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedStoreid, string m_strStorageid, out DataTable m_dtMedicineInfo)
        {
            m_dtMedicineInfo = null;
            long lngRes = 0;           
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
	 decode(c.currentgross_num,null,0,c.currentgross_num) currentgross_num,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
from t_bse_medicine t
 left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
inner join t_ds_medstoreset b on t.medicinetypeid_chr =
                              b.medicinetypeid_chr and b.medstoreid=?
left join t_ms_storage c on c.medicineid_chr = t.medicineid_chr
and c.storageid_chr = ? where  t.deleted_int=0
order by t.assistcode_chr,t.medicineid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = m_strMedStoreid;
                objDPArr[1].Value = m_strStorageid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtMedicineInfo, objDPArr);
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

        #region 获取出库单号
        /// <summary>
        /// 获取出库单号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutBillNo(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeqid, out string p_strOutputOrder)
        {
            p_strOutputOrder = "";
            DataTable m_dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.outstorageid_vchr
	from t_ms_outstorage a
 where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeqid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbResult != null && m_dtbResult.Rows.Count > 0)
                {
                    p_strOutputOrder = m_dtbResult.Rows[0][0].ToString();
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

        #region 获取药房出库明细数据
        /// <summary>
        /// 获取药房出库明细数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strBeginDate">出库开始日期</param>
        /// <param name="p_strEndDate">出库结束日期</param>
        /// <param name="p_intGetRequestAmount">生成请领量方法</param>
        /// <param name="p_dtbResult">出库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetOutStorageDetailData(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital,string p_strStorageID, string p_strBeginDate, string p_strEndDate,int p_intGetRequestAmount, ref DataTable p_dtbResult)
        {
            long lngRes = 0;

            DataTable dtbTemp = new DataTable();
            DataTable dtbTemp2 = new DataTable();
            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //如果请领单的状态是作废、药库审核和药房审核或入帐，就不用变红色显示
            StringBuilder strSQL = new StringBuilder();
            if (p_blnIsHospital)
            {
                strSQL.Append(@"select 'F' ifcheck,c.medicinename_vchr,
       a.drugstoreid_int drugstoreid_chr,
       d.medstorename_vchr,
       c.assistcode_chr,
       a.medicineid_chr,
       c.medspec_vchr,
       sum(decode(a.type_int, 2, -round(a.ipamount_int/c.packqty_dec,2), round(a.ipamount_int/c.packqty_dec,2))) opamount_int,
       c.opunit_chr,
       sum(decode(a.type_int, 2, -a.ipamount_int, a.ipamount_int)) ipamount_int,
       c.ipunit_chr,
       c.packqty_dec,
       decode(c.ipchargeflg_int, 0, c.opunit_chr, c.ipunit_chr) unit_chr,
       sum(decode(c.ipchargeflg_int,
                  0,
                  decode(a.type_int, 2, -round(a.ipamount_int/c.packqty_dec,2), round(a.ipamount_int/c.packqty_dec,2)),
                  decode(a.type_int, 2, -a.ipamount_int, a.ipamount_int))) amount_int,
       c.opchargeflg_int,
       c.ipchargeflg_int,
       c.productorid_chr,
       c.unitprice_mny,
       c.medicinetypeid_chr,
       c.requestunit_chr,
       c.requestpackqty_dec,
       0 requestamount_int,
       0 useamount_int,
       e.tiptoplimit_int,
       e.neaplimit_int,
       0 currentgross_num,
       (select askdate_dat
          from (select s.askdate_dat, t.medicineid_chr, s.askdept_chr
                  from t_ds_ask_detail t
                  left join t_ds_ask s on s.seriesid_int = t.seriesid2_int
                 where s.status_int = 2 
                 order by s.askdate_dat desc)
         where askdept_chr = a.drugstoreid_int
           and medicineid_chr = a.medicineid_chr
           and rownum = 1) askdate_dat
  from t_ds_putmedaccount_detail a
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore d on d.deptid_chr = a.drugstoreid_int
 left join t_ds_medlimit e on e.medicineid_chr = a.medicineid_chr
                           and e.drugstoreid_chr = a.drugstoreid_int
 where a.state_int <> 0 ");
            }
            else
            {
                strSQL.Append(@"select 'F' ifcheck,c.medicinename_vchr,
       a.drugstoreid_int drugstoreid_chr,
       d.medstorename_vchr,
       c.assistcode_chr,
       a.medicineid_chr,
       c.medspec_vchr,
       sum(decode(a.type_int, 1, -round(a.ipamount_int/c.packqty_dec,2), round(a.ipamount_int/c.packqty_dec,2))) opamount_int,
       c.opunit_chr,
       sum(decode(a.type_int, 1, -a.ipamount_int, a.ipamount_int)) ipamount_int,
       c.ipunit_chr,
       c.packqty_dec,
       decode(c.opchargeflg_int, 0, c.opunit_chr, c.ipunit_chr) unit_chr,
       sum(decode(c.opchargeflg_int,
                  0,
                  decode(a.type_int, 1, -round(a.ipamount_int/c.packqty_dec,2), round(a.ipamount_int/c.packqty_dec,2)),
                  decode(a.type_int, 1, -a.ipamount_int, a.ipamount_int))) amount_int,
       c.opchargeflg_int,
       c.ipchargeflg_int,
       c.productorid_chr,
       c.unitprice_mny,
       c.medicinetypeid_chr,
       c.requestunit_chr,
       c.requestpackqty_dec,
       0 requestamount_int,
       0 useamount_int,
       e.tiptoplimit_int,
       e.neaplimit_int,
       0 currentgross_num,
       (select askdate_dat
          from (select s.askdate_dat, t.medicineid_chr, s.askdept_chr
                  from t_ds_ask_detail t
                  left join t_ds_ask s on s.seriesid_int = t.seriesid2_int
                 where s.status_int = 2 
                 order by s.askdate_dat desc)
         where askdept_chr = a.drugstoreid_int
           and medicineid_chr = a.medicineid_chr
           and rownum = 1) askdate_dat
  from t_ds_recipeaccount_detail a
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore d on d.deptid_chr = a.drugstoreid_int
 left join t_ds_medlimit e on e.medicineid_chr = a.medicineid_chr
                           and e.drugstoreid_chr = a.drugstoreid_int
 where a.state_int <> 0 ");
            }
            
            try
            {
                int m_intParamCount = 1;

                StringBuilder m_strbCondition = new StringBuilder("");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(10, out tmp_objDPArr);
                strSQL.Append(@" and (d.medstoreid_chr = ?)");
                tmp_objDPArr[0].Value = p_strStorageID;  
                
                strSQL.Append(@" and (a.operatedate_dat between ? and ?)");
                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(p_strBeginDate);
                tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(p_strEndDate);
                tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;                

                strSQL.Append(@" group by a.drugstoreid_int,c.medicinename_vchr,
					d.medstorename_vchr,
					assistcode_chr,
					a.medicineid_chr,
					c.medspec_vchr,
					c.opunit_chr,
					c.ipunit_chr,
					c.packqty_dec,
					c.opchargeflg_int,
                    c.ipchargeflg_int,
					c.productorid_chr,
					c.unitprice_mny,
					c.medicinetypeid_chr,
                    c. requestunit_chr,
                    c .requestpackqty_dec,
					e.tiptoplimit_int,
					e.neaplimit_int");

                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objDPArr);

                if (p_blnIsHospital)
                {
                    strSQL = new StringBuilder(@"select 'F' ifcheck,
       c.medicinename_vchr,
       b.drugstoreid_chr,
       d.medstorename_vchr,
       c.assistcode_chr,
       a.medicineid_chr,
       c.medspec_vchr,
       sum(round(a.ipamount_int / c.packqty_dec, 2)) opamount_int,
       c.opunit_chr,
       sum(a.ipamount_int) ipamount_int,
       c.ipunit_chr,
       c.packqty_dec,
       decode(c.ipchargeflg_int, 0, c.opunit_chr, c.ipunit_chr) unit_chr,
       sum(decode(c.ipchargeflg_int,
                  0,
                  round(a.ipamount_int / c.packqty_dec, 2),
                  a.ipamount_int)) amount_int,
       c.opchargeflg_int,
       c.ipchargeflg_int,
       c.productorid_chr,
       c.unitprice_mny,
       c.medicinetypeid_chr,
       c.requestunit_chr,
       c.requestpackqty_dec,
       0 requestamount_int,
       0 useamount_int,
       e.tiptoplimit_int,
       e.neaplimit_int,
       0 currentgross_num,
       (select askdate_dat
          from (select s.askdate_dat, t.medicineid_chr, s.askdept_chr
                  from t_ds_ask_detail t
                  left join t_ds_ask s on s.seriesid_int = t.seriesid2_int
                 where s.status_int = 2
                 order by s.askdate_dat desc)
         where askdept_chr = b.drugstoreid_chr
           and medicineid_chr = a.medicineid_chr
           and rownum = 1) askdate_dat
  from t_ds_outstorage_detail a
  left join t_ds_outstorage b on b.seriesid_int = a.seriesid2_int
                             and b.status_int in (2, 3)
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore d on d.deptid_chr = b.drugstoreid_chr
  left join t_ds_medlimit e on e.medicineid_chr = a.medicineid_chr
                           and e.drugstoreid_chr = b.drugstoreid_chr
 where a.status = 1
   and (d.medstoreid_chr = ?)
   and (b.examdate_dat between ? and ?)
 group by b.drugstoreid_chr,
          c.medicinename_vchr,
          d.medstorename_vchr,
          assistcode_chr,
          a.medicineid_chr,
          c.medspec_vchr,
          c.opunit_chr,
          c.ipunit_chr,
          c.packqty_dec,
          c.opchargeflg_int,
          c.ipchargeflg_int,
          c.productorid_chr,
          c.unitprice_mny,
          c.medicinetypeid_chr,
          c. requestunit_chr,
          c .requestpackqty_dec,
          e.tiptoplimit_int,
          e.neaplimit_int");
                }
                else
                {
                    strSQL = new StringBuilder(@"select 'F' ifcheck,
       c.medicinename_vchr,
       b.drugstoreid_chr,
       d.medstorename_vchr,
       c.assistcode_chr,
       a.medicineid_chr,
       c.medspec_vchr,
       sum(round(a.ipamount_int / c.packqty_dec, 2)) opamount_int,
       c.opunit_chr,
       sum(a.ipamount_int) ipamount_int,
       c.ipunit_chr,
       c.packqty_dec,
       decode(c.opchargeflg_int, 0, c.opunit_chr, c.ipunit_chr) unit_chr,
       sum(decode(c.opchargeflg_int,
                  0,
                  round(a.ipamount_int / c.packqty_dec, 2),
                  a.ipamount_int)) amount_int,
       c.opchargeflg_int,
       c.ipchargeflg_int,
       c.productorid_chr,
       c.unitprice_mny,
       c.medicinetypeid_chr,
       c.requestunit_chr,
       c.requestpackqty_dec,
       0 requestamount_int,
       0 useamount_int,
       e.tiptoplimit_int,
       e.neaplimit_int,
       0 currentgross_num,
       (select askdate_dat
          from (select s.askdate_dat, t.medicineid_chr, s.askdept_chr
                  from t_ds_ask_detail t
                  left join t_ds_ask s on s.seriesid_int = t.seriesid2_int
                 where s.status_int = 2
                 order by s.askdate_dat desc)
         where askdept_chr = b.drugstoreid_chr
           and medicineid_chr = a.medicineid_chr
           and rownum = 1) askdate_dat
  from t_ds_outstorage_detail a
  left join t_ds_outstorage b on b.seriesid_int = a.seriesid2_int
                             and b.status_int in (2, 3)
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore d on d.deptid_chr = b.drugstoreid_chr
  left join t_ds_medlimit e on e.medicineid_chr = a.medicineid_chr
                           and e.drugstoreid_chr = b.drugstoreid_chr
 where a.status = 1
   and (d.medstoreid_chr = ?)
   and (b.examdate_dat between ? and ?)
 group by b.drugstoreid_chr,
          c.medicinename_vchr,
          d.medstorename_vchr,
          assistcode_chr,
          a.medicineid_chr,
          c.medspec_vchr,
          c.opunit_chr,
          c.ipunit_chr,
          c.packqty_dec,
          c.opchargeflg_int,
          c.ipchargeflg_int,
          c.productorid_chr,
          c.unitprice_mny,
          c.medicinetypeid_chr,
          c. requestunit_chr,
          c .requestpackqty_dec,
          e.tiptoplimit_int,
          e.neaplimit_int");                    
                }

                objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = Convert.ToDateTime(p_strBeginDate);
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[2].Value = Convert.ToDateTime(p_strEndDate);
                objDPArr[2].DbType = DbType.DateTime;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbTemp, objDPArr);

                DataRow drRow = null;
                DataRow drTemp = null;
                p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["medicineid_chr"] };
                dtbTemp.PrimaryKey = new DataColumn[] { dtbTemp.Columns["medicineid_chr"] };
                for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                {
                    drRow = p_dtbResult.Rows[i1];
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        drTemp = dtbTemp.Rows.Find(drRow["medicineid_chr"]);
                        if (drTemp != null)
                        {
                            drRow["opamount_int"] = Convert.ToDouble(drRow["opamount_int"]) + Convert.ToDouble(drTemp["opamount_int"]);
                            drRow["ipamount_int"] = Convert.ToDouble(drRow["ipamount_int"]) + Convert.ToDouble(drTemp["ipamount_int"]);
                            drRow["amount_int"] = Convert.ToDouble(drRow["amount_int"]) + Convert.ToDouble(drTemp["amount_int"]);
                        }
                    }
                }
                for (int i2 = 0; i2 < dtbTemp.Rows.Count; i2++)
                {
                    drRow = dtbTemp.Rows[i2];
                    drTemp = p_dtbResult.Rows.Find(drRow["medicineid_chr"]);
                    if (drTemp == null)
                    {
                        p_dtbResult.Rows.Add(drRow.ItemArray);
                    }
                }

                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    strSQL = new StringBuilder(@"select a.medicineid_chr,
       sum(decode(b.opchargeflg_int,
                  0,
                  round(a.iprealgross_int / a.packqty_dec, 2),
                  a.iprealgross_int)) currentgross_num
  from t_ds_storage_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_chr
 where c.medstoreid_chr = ?
   and a.status = 1
 group by a.medicineid_chr");
                    if (p_blnIsHospital)
                        strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");

                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    
                    objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbTemp2, objDPArr);
                    if (dtbTemp2 != null && dtbTemp2.Rows.Count > 0)
                    {
                        dtbTemp2.PrimaryKey = new DataColumn[] { dtbTemp2.Columns["medicineid_chr"] };
                    }

                    p_dtbResult.Columns.Add("diff", typeof(Double));

                    for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                    {
                        drRow = p_dtbResult.Rows[i1];
                        if (dtbTemp2 != null && dtbTemp2.Rows.Count > 0)
                        {
                            drTemp = dtbTemp2.Rows.Find(drRow["medicineid_chr"]);
                            if (drTemp != null)
                                drRow["currentgross_num"] = drTemp["currentgross_num"];
                        }
                        //20090116:请领量=“消耗量-库存量”
                        if (Convert.ToDouble(drRow["requestpackqty_dec"]) > 0)
                        {
                            if (p_blnIsHospital)
                            {
                                if (Convert.ToInt16(drRow["ipchargeflg_int"]) == 0)
                                {
                                    drRow["useamount_int"] = Convert.ToDouble(drRow["opamount_int"]);
                                    drRow["requestamount_int"] = Math.Ceiling((Convert.ToDouble(drRow["opamount_int"])-Convert.ToDouble(drRow["currentgross_num"])) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                                }
                                else
                                {
                                    drRow["useamount_int"] = Convert.ToDouble(drRow["ipamount_int"]);
                                    drRow["requestamount_int"] = Math.Ceiling((Convert.ToDouble(drRow["opamount_int"]) - Convert.ToDouble(drRow["currentgross_num"]) / Convert.ToDouble(drRow["packqty_dec"])) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(drRow["opchargeflg_int"]) == 0)
                                {
                                    drRow["useamount_int"] = Convert.ToDouble(drRow["opamount_int"]);
                                    drRow["requestamount_int"] = Math.Ceiling((Convert.ToDouble(drRow["opamount_int"]) - Convert.ToDouble(drRow["currentgross_num"])) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                                }
                                else
                                {
                                    drRow["useamount_int"] = Convert.ToDouble(drRow["ipamount_int"]);
                                    drRow["requestamount_int"] = Math.Ceiling((Convert.ToDouble(drRow["opamount_int"]) - Convert.ToDouble(drRow["currentgross_num"]) / Convert.ToDouble(drRow["packqty_dec"])) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                                }
                            }

                            if (p_intGetRequestAmount == 0)
                            {
                                drRow["requestamount_int"] = Math.Ceiling(Convert.ToDouble(drRow["opamount_int"]) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                            }
                            
                            drRow["opamount_int"] = Convert.ToDouble(drRow["requestamount_int"]) * Convert.ToDouble(drRow["requestpackqty_dec"]);
                            drRow["ipamount_int"] = Convert.ToDouble(drRow["opamount_int"]) * Convert.ToDouble(drRow["packqty_dec"]);
                            if (p_blnIsHospital)
                            {
                                if (Convert.ToInt16(drRow["ipchargeflg_int"]) == 0)
                                {
                                    drRow["amount_int"] = Convert.ToDouble(drRow["opamount_int"]);
                                }
                                else
                                {
                                    drRow["amount_int"] = Convert.ToDouble(drRow["ipamount_int"]);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(drRow["opchargeflg_int"]) == 0)
                                {
                                    drRow["amount_int"] = Convert.ToDouble(drRow["opamount_int"]);
                                }
                                else
                                {
                                    drRow["amount_int"] = Convert.ToDouble(drRow["ipamount_int"]);
                                }
                            }
                        }

                        if (p_intGetRequestAmount == 0)
                        {
                            drRow["diff"] = Convert.ToDouble(drRow["useamount_int"]) - Convert.ToDouble(drRow["currentgross_num"]);
                        }
                        else
                        {
                            //20090116:排序改为按“消耗量/库存量”的值较大者排在前面
                            drRow["diff"] = Convert.ToDouble(drRow["useamount_int"]) / Convert.ToDouble(drRow["currentgross_num"]);
                        }
                    }                    
                    
                    DataView dv = p_dtbResult.DefaultView;
                    dv.RowFilter = "useamount_int > 0";
                    dv.Sort = "diff desc,requestamount_int desc,assistcode_chr asc";
                    p_dtbResult = dv.ToTable();
                    p_dtbResult.Columns.Remove("diff");
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_dtbResult = null;
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据药房Id获取对应的部门ID
        /// <summary>
        /// 根据药房Id获取对应的部门ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStorageID">药库Id</param>    
        /// <param name="p_strDeptID">部门ID</param>                    
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptIDForStore(System.Security.Principal.IPrincipal p_objPrincipal, string p_intStorageID, out string p_strDeptID)
        {
            p_strDeptID = string.Empty;
            long lngRes = 0;
            DataTable dtbValue = new DataTable();
            string strSQL = @" select a.deptid_chr
	 from t_bse_medstore a
	where a.medstoreid_chr = ?";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = p_intStorageID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strDeptID = Convert.ToString(dtbValue.Rows[0]["deptid_chr"]);
                }
                dtbValue = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取请领单状态是否“提交”
        /// <summary>
        /// 获取请领单状态是否“提交”
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckStatus(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAskId)
        {
            long lngResult = -1;
            DataTable dtbResult = new DataTable();
            try
            {
                string strSQL = @"select a.status_int from t_ds_ask a where a.askid_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strAskId;
                objHRPServ.lngGetDataTableWithParameters(strSQL,ref dtbResult,objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbResult != null & dtbResult.Rows.Count > 0)
                {
                    if (Convert.ToInt16(dtbResult.Rows[0][0]) == 2)
                        lngResult = 1;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngResult;
        }
        #endregion

        #region 获取基本药品信息(带请领信息)不显示库存信息
        /// <summary>
        ///  获取基本药品信息(带请领信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtMedicineInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInfoForAsk(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedStoreid, out DataTable m_dtMedicineInfo)
        {
            m_dtMedicineInfo = null;
            long lngRes = 0;
            if (m_strMedStoreid != string.Empty)
            {
                //20091024:判断是门诊药房还是住院药房，以显示正确的单位
                int intStoreType = 1;
                string strSQLTemp = @"select a.medstoretype_int
  from t_bse_medstore a
 where a.medstoreid_chr = ?";
                DataTable dtbTemp = new DataTable();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strMedStoreid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQLTemp, ref dtbTemp, objDPArr);
                if(lngRes > 0 && dtbTemp.Rows.Count > 0)
                {
                    intStoreType = Convert.ToInt32(dtbTemp.Rows[0][0]);
                }

                try
                {
                    string strSQL = string.Empty;
                    if(intStoreType == 1)
                    {
                        strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.opchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
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
       t.requestunit_chr,t.requestpackqty_dec,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_medstoreset c on t.medicinetypeid_chr =
                                  c.medicinetypeid_chr
                              and c.medstoreid = ? where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";
                    }
                    else
                    {
                        strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.ipchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
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
       t.requestunit_chr,t.requestpackqty_dec,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_medstoreset c on t.medicinetypeid_chr =
                                  c.medicinetypeid_chr
                              and c.medstoreid = ? where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";
                    }
                   
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = m_strMedStoreid;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtMedicineInfo, objDPArr);
                    objHRPServ.Dispose();
                objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
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
       t.requestunit_chr,t.requestpackqty_dec,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1 where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtMedicineInfo);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 获取基本药品信息(带请领信息)--20090121:增加显示库存信息
        /// <summary>
        ///  获取基本药品信息(带请领信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHispital">是否住院药房</param>
        /// <param name="m_strMedStoreid">药房ID</param>
        /// <param name="m_dtMedicineInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInfoForAskWithStorageInfo(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHispital, string m_strMedStoreid, out DataTable m_dtMedicineInfo)
        {
            m_dtMedicineInfo = null;
            long lngRes = 0;
            if (m_strMedStoreid != string.Empty)
            {
                try
                {
                    string strSQL = "";
                    if (p_blnIsHispital)
                    {
                        strSQL = @"select t.assistcode_chr, t.medicinename_vchr, t.medspec_vchr, 
       decode(t.ipchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
       t.ipunit_chr, t.packqty_dec, t.productorid_chr, t.pycode_chr,
       t.wbcode_chr, t.medicineid_chr, t.ispoison_chr,
       t.ischlorpromazine2_chr, t.unitprice_mny, t.medicinetypeid_chr,
       t.tradeprice_mny, t.limitunitprice_mny, t.opchargeflg_int,
       t.ipchargeflg_int, t.requestunit_chr, t.requestpackqty_dec,
       decode(c.ifstop_int, null, t.ifstop_int, c.ifstop_int) ifstop_int,
       decode(t.ipchargeflg_int, 0,
               round(f.ipcurrentgross_num / t.packqty_dec, 2),
               f.ipcurrentgross_num) currentgross_num,
       decode(c.noqtyflag_int, null, 0, noqtyflag_int) noqtyflag_int,
       b.itemname_vchr as aliasname_vchr, b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_medstoreset z on z.medicinetypeid_chr =
                                  t.medicinetypeid_chr
                              and z.medstoreid = ?
  left join t_bse_medstore y on y.medstoreid_chr = z.medstoreid
  left join (select e.medicineid_chr, e.drugstoreid_chr,
                    sum(e.iprealgross_int) ipcurrentgross_num
               from t_ds_storage_detail e
              where e.status = 1
              group by e.medicineid_chr, e.drugstoreid_chr) f on f.medicineid_chr =
                                                                 t.medicineid_chr
                                                             and f.drugstoreid_chr =
                                                                 y.deptid_chr
  left join t_ds_storage c on c.medicineid_chr = f.medicineid_chr
                          and c.drugstoreid_chr = y.deptid_chr
 where t.deleted_int = 0
 order by t.assistcode_chr, t.medicineid_chr";
                    }
                    else
                    {
                        strSQL = @"select t.assistcode_chr, t.medicinename_vchr, t.medspec_vchr,
       decode(t.opchargeflg_int, 0, t.opunit_chr, t.ipunit_chr) opunit_chr,
       t.ipunit_chr, t.packqty_dec, t.productorid_chr, t.pycode_chr,
       t.wbcode_chr, t.medicineid_chr, t.ispoison_chr,
       t.ischlorpromazine2_chr, t.unitprice_mny, t.medicinetypeid_chr,
       t.tradeprice_mny, t.limitunitprice_mny, t.opchargeflg_int,
       t.ipchargeflg_int, t.requestunit_chr, t.requestpackqty_dec,
       decode(c.ifstop_int, null, t.ifstop_int, c.ifstop_int) ifstop_int,
       decode(t.opchargeflg_int, 0,
               round(f.ipcurrentgross_num / t.packqty_dec, 2),
               f.ipcurrentgross_num) currentgross_num,
       decode(c.noqtyflag_int, null, 0, noqtyflag_int) noqtyflag_int,
       b.itemname_vchr as aliasname_vchr, b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 inner join t_ds_medstoreset z on z.medicinetypeid_chr =
                                  t.medicinetypeid_chr
                              and z.medstoreid = ?
  left join t_bse_medstore y on y.medstoreid_chr = z.medstoreid
  left join (select e.medicineid_chr, e.drugstoreid_chr,
                    sum(e.iprealgross_int) ipcurrentgross_num
               from t_ds_storage_detail e
              where e.status = 1
              group by e.medicineid_chr, e.drugstoreid_chr) f on f.medicineid_chr =
                                                                 t.medicineid_chr
                                                             and f.drugstoreid_chr =
                                                                 y.deptid_chr
  left join t_ds_storage c on c.medicineid_chr = f.medicineid_chr
                          and c.drugstoreid_chr = y.deptid_chr
 where t.deleted_int = 0
 order by t.assistcode_chr, t.medicineid_chr";
                    }
                    clsHRPTableService objHRPServ = new clsHRPTableService();

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = m_strMedStoreid;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtMedicineInfo, objDPArr);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
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
       t.requestunit_chr,t.requestpackqty_dec,t.ifstop_int,0 currentgross_num,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1 where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtMedicineInfo);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 获取请领单的状态
        /// <summary>
        /// 获取请领单的状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeqid"></param>
        /// <param name="p_strStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAskStatus(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeqid, out string p_strStatus)
        {
            p_strStatus = "未知";
            DataTable m_dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select decode(a.status_int,
              0,
              '作废',
              1,
              '新制 ',
              2,
              '提交 ',
              3,
              '药库审核',
              4,
              '药房审核',
              5,
              '入账') status
  from t_ds_ask a
 where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeqid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbResult != null && m_dtbResult.Rows.Count > 0)
                {
                    p_strStatus = m_dtbResult.Rows[0][0].ToString();
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

        #region 获取请领单主表对应的零售金额
        /// <summary>
        /// 获取请领单主表对应的零售金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <param name="p_dblSummoney"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAskMoney(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID, out double p_dblSummoney)
        {
            p_dblSummoney = 0;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select sum(a.opamount_int * b.unitprice_mny) as retailsum
  from t_ds_ask_detail a, t_bse_medicine b
 where a.seriesid2_int = ?
   and a.medicineid_chr = b.medicineid_chr(+)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = p_lngSeriesID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, m_objParaArr);
                {                    
                    if (dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        double.TryParse(dtbResult.Rows[0]["retailsum"].ToString(), out p_dblSummoney);
                    }
                }
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

        #region 获取出库主表对应的零售金额
        /// <summary>
        /// 获取出库主表对应的零售金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <param name="p_dblSummoney"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutMoney(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID, out double p_dblSummoney)
        {
            p_dblSummoney = 0;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select sum(a.retailprice_int * a.netamount_int) as retailsum
  from t_ms_outstorage_detail a, t_bse_medicine b
 where a.seriesid2_int = ?
   and a.medicineid_chr = b.medicineid_chr(+)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = p_lngSeriesID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, m_objParaArr);
                {
                    if (dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        DataRow dr = null;
                        for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                        {
                            p_dblSummoney = Convert.ToDouble(dtbResult.Rows[0]["retailsum"]);
                        }
                    }
                }
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
