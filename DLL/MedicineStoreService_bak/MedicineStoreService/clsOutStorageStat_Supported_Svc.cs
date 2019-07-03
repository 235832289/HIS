using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.security;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.Utility;
using System.Collections;


namespace com.digitalwave.iCare.middletier.MedicineStoreService
{

    #region  出库统计报表类  王勇 2007-4-16
    /// <summary>
    /// 出库统计报表（西药库）类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsOutStorageStat_Supported_Svc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 获取出库统计数据数据
        /// <summary>
        /// 表：T_MS_OUTSTORAGE（出库主表）、T_MS_OUTSTORAGE_DETAIL（出库明细表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageStatData(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_OutStorageStatQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc", "m_lngGetOutStorageStatData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//            StringBuilder strSQL = new StringBuilder(@"select 
//                                b.askdept_chr,
//                                a.deptname_vchr,
//                                sum(c.callprice_int*c.netamount_int) callsum,
//                                sum(c.wholesaleprice_int*c.netamount_int) wholesalesum,
//                                sum(c.retailprice_int*c.netamount_int) retailsum,
//                                sum(c.retailprice_int*c.netamount_int - c.callprice_int*c.netamount_int) callretaildifference,
//                                sum(c.retailprice_int*c.netamount_int - c.wholesaleprice_int*c.netamount_int) wholesaleretaildifference   
//                              from t_bse_deptdesc a
//                                right outer join t_ms_outstorage b
//                                  on a.deptid_chr=b.askdept_chr
//                                inner join t_ms_outstorage_detail c
//                                 on b.seriesid_int=c.seriesid2_int
//  inner join t_bse_medicine d on c.medicineid_chr = d.medicineid_chr
//  inner join t_ms_medicinetypeset ty on ty.medicinetypeid_chr =
//                                             d.medicinetypeid_chr
//                                where (b.status>?)
//                                  and (c.status=?)");

            StringBuilder strSQL = new StringBuilder(@"select 
                                a.deptname_vchr,
                                sum(c.callprice_int*c.netamount_int) callsum,
                                sum(c.wholesaleprice_int*c.netamount_int) wholesalesum,
                                sum(c.retailprice_int*c.netamount_int) retailsum,  
                                ex.seriesid_int
                              from t_bse_deptdesc a
                                right outer join t_ms_outstorage b
                                  on a.deptid_chr=b.askdept_chr
                                inner join t_ms_outstorage_detail c
                                 on b.seriesid_int=c.seriesid2_int
  inner join t_bse_medicine d on c.medicineid_chr = d.medicineid_chr
  inner join t_aid_medicinetype ty on ty.medicinetypeid_chr =
                                             d.medicinetypeid_chr
inner join t_ms_exportdept ex on a.deptid_chr = ex.exportdept_chr 
                                where (b.status>?)
                                  and (c.status=?)
                                  and (b.formtype=1)");

            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(10, out tmp_objDPArr);


                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = 1;

                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = 1;


                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" and (b.storageid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;
                }

                if (objvalue_Param.m_dtmOutStorageBeginDate.Length > 0)
                {
                    strSQL.Append(@" and (b.examdate_dat>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value =  Convert.ToDateTime(objvalue_Param.m_dtmOutStorageBeginDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                }

                if (objvalue_Param.m_dtmOutStorageEndDate.Length > 0)
                {
                    strSQL.Append(@" and (b.examdate_dat<=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_dtmOutStorageEndDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }


                if (objvalue_Param.m_strReceiveDept != "all")
                {
                    strSQL.Append(@" and (b.askdept_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strReceiveDept;
                }



                ////统计是否药房外退
                //if (objvalue_Param.m_blnPharmacyMedicineCancel == false)
                //{
                //    strSQL.Append(@" and (b.formtype=?)");
                //    ++m_intParamCount;
                //    tmp_objDPArr[m_intParamCount - 1].Value = 1;
                //}
                //else
                //{
                    //strSQL.Append(@" and (b.formtype in (?,?))");
                    //strSQL.Append(@" and ((b.formtype = ?) or (b.formtype = ?))");

                    //++m_intParamCount;
                    //tmp_objDPArr[m_intParamCount - 1].Value = 1;

                    //++m_intParamCount;
                    //tmp_objDPArr[m_intParamCount - 1].Value = 2;

                //}
                if (objvalue_Param.m_intMedicineTypeSetID > 0)
                {
                    strSQL.Append(@" and ty.medicinetypeid_chr = ?");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intMedicineTypeSetID;
                }
                strSQL.Append(@" group by a.deptname_vchr,ex.seriesid_int");
                strSQL.Append(@" order by ex.seriesid_int");
                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;
                objvalue_Param = null;
            }

            return lngRes;
        }

        #endregion

        /// <summary>
        /// 获取内退统计
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_intMedicineSetID">药品设置类型ID</param>
        /// <param name="p_dtbData">返回数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWithinWithdrawal(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBeginDate, DateTime p_dtmEndDate, 
            string p_strDeptID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;

            try
            {
                string strDeptSQL = string.Empty;
                string strSetID = string.Empty;
                if (!string.IsNullOrEmpty(p_strDeptID))
                {
                    strDeptSQL = @"
   and b.returndept_chr = ? ";
                }
                if (p_intMedicineSetID > 0)
                {
                    strSetID = @"
   and ty.medicinetypeid_chr = ?";
                }

                string strSQL = @"select c.deptname_vchr,
       sum(a.callprice_int * a.amount) callsum,
       sum(a.wholesaleprice_int * a.amount) wholesalesum,
       sum(a.retailprice_int * a.amount) retailsum,
ex.seriesid_int
  from t_ms_instorage_detal a
 inner join t_ms_instorage b on a.seriesid2_int = b.seriesid_int
 left outer join t_bse_deptdesc c on c.deptid_chr = b.returndept_chr
 inner join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
 inner join t_aid_medicinetype ty on ty.medicinetypeid_chr =
                                       d.medicinetypeid_chr
 inner join t_ms_exportdept ex on c.deptid_chr = ex.exportdept_chr
 where b.instoragedate_dat between ? and ?
   and (b.state_int = 2 or b.state_int = 3)
   and b.formtype_int = 2
   and a.status = 1
   and b.storageid_chr = ? " + strDeptSQL + strSetID + @"
   group by deptname_vchr,ex.seriesid_int
 order by ex.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(p_strDeptID))
                {
                    if (string.IsNullOrEmpty(strSetID))
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_intMedicineSetID;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strSetID))
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_strDeptID;
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_strDeptID;
                        objDPArr[4].Value = p_intMedicineSetID;
                    }
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbData, objDPArr);
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

        #region 出库明细报表
        /// <summary>
        /// 出库明细报表(未指定科室及药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutStorageDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;                
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.netamount_int,
       t.opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.examdate_dat prodate
  from t_ms_outstorage_detail t,
       t_ms_outstorage        m,
       t_bse_deptdesc         d,
       t_bse_medicine         b
 where m.storageid_chr = ?
   and m.status > 1
   and m.formtype = 1
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.askdept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.examdate_dat between ? and ?
 order by d.deptname_vchr, m.examdate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
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

        /// <summary>
        /// 出库明细报表查询内退(未指定科室及药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">内退明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutReportGetWithinWithdrawal(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.amount netamount_int,
       t.unit_vchr opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.instoragedate_dat prodate
  from t_ms_instorage_detal t,
       t_ms_instorage       m,
       t_bse_deptdesc       d,
       t_bse_medicine       b
 where m.storageid_chr = ?
   and m.state_int > 1
   and m.formtype_int = 2
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.returndept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.instoragedate_dat between ? and ?
 order by d.deptname_vchr, m.instoragedate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbOutDetail != null && p_dtbOutDetail.Rows.Count > 0)
                {
                    int intRowsCount = p_dtbOutDetail.Rows.Count;
                    DataRow drCurrent = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_dtbOutDetail.Rows[iRow];
                        drCurrent["deptname_vchr"] = "(内退)" + drCurrent["deptname_vchr"].ToString();
                        drCurrent["netamount_int"] = 0 - Convert.ToDouble(drCurrent["netamount_int"]);
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

        /// <summary>
        /// 出库明细报表(只指定科室)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutStorageDetailReport_Dept(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAskDeptID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strAskDeptID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.netamount_int,
       t.opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.examdate_dat prodate
  from t_ms_outstorage_detail t,
       t_ms_outstorage        m,
       t_bse_deptdesc         d,
       t_bse_medicine         b
 where m.storageid_chr = ?
   and m.status > 1
   and m.formtype = 1
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.askdept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.examdate_dat between ? and ?
   and m.askdept_chr = ?
 order by d.deptname_vchr, m.examdate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strAskDeptID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
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

        /// <summary>
        /// 出库明细报表查询内退(只指定科室)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutReportGetWithinWithdrawal_Dept(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAskDeptID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strAskDeptID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.amount netamount_int,
       t.unit_vchr opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.instoragedate_dat prodate
  from t_ms_instorage_detal t,
       t_ms_instorage       m,
       t_bse_deptdesc       d,
       t_bse_medicine       b
 where m.storageid_chr = ?
   and m.state_int > 1
   and m.formtype_int = 2
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.returndept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.instoragedate_dat between ? and ?
   and m.returndept_chr = ?
 order by d.deptname_vchr, m.instoragedate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strAskDeptID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbOutDetail != null && p_dtbOutDetail.Rows.Count > 0)
                {
                    int intRowsCount = p_dtbOutDetail.Rows.Count;
                    DataRow drCurrent = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_dtbOutDetail.Rows[iRow];
                        drCurrent["deptname_vchr"] = "(内退)" + drCurrent["deptname_vchr"].ToString();
                        drCurrent["netamount_int"] = 0 - Convert.ToDouble(drCurrent["netamount_int"]);
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

        /// <summary>
        /// 出库明细报表(只指定药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutStorageDetailReport_Med(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.netamount_int,
       t.opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.examdate_dat prodate
  from t_ms_outstorage_detail t,
       t_ms_outstorage        m,
       t_bse_deptdesc         d,
       t_bse_medicine         b
 where m.storageid_chr = ?
   and m.status > 1
   and m.formtype = 1
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.askdept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.examdate_dat between ? and ?
   and t.medicineid_chr = ?
 order by d.deptname_vchr, m.examdate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
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

        /// <summary>
        /// 出库明细报表查询内退(只指定药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutReportGetWithinWithdrawal_Med(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.amount netamount_int,
       t.unit_vchr opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.instoragedate_dat prodate
  from t_ms_instorage_detal t,
       t_ms_instorage       m,
       t_bse_deptdesc       d,
       t_bse_medicine       b
 where m.storageid_chr = ?
   and m.state_int > 1
   and m.formtype_int = 2
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.returndept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.instoragedate_dat between ? and ?
   and t.medicineid_chr = ?
 order by d.deptname_vchr, m.instoragedate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbOutDetail != null && p_dtbOutDetail.Rows.Count > 0)
                {
                    int intRowsCount = p_dtbOutDetail.Rows.Count;
                    DataRow drCurrent = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_dtbOutDetail.Rows[iRow];
                        drCurrent["deptname_vchr"] = "(内退)" + drCurrent["deptname_vchr"].ToString();
                        drCurrent["netamount_int"] = 0 - Convert.ToDouble(drCurrent["netamount_int"]);
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

        /// <summary>
        /// 出库明细报表(指定科室及药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutStorageDetailReport_Dept_Med(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAskDeptID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID) || string.IsNullOrEmpty(p_strAskDeptID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.netamount_int,
       t.opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.examdate_dat prodate
  from t_ms_outstorage_detail t,
       t_ms_outstorage        m,
       t_bse_deptdesc         d,
       t_bse_medicine         b
 where m.storageid_chr = ?
   and m.status > 1
   and m.formtype = 1
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.askdept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.examdate_dat between ? and ?
   and t.medicineid_chr = ?
   and m.askdept_chr = ?
 order by d.deptname_vchr, m.examdate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicineID;
                objDPArr[4].Value = p_strAskDeptID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
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

        /// <summary>
        /// 出库明细报表查询内退(指定科室及药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutReportGetWithinWithdrawal_Dept_Med(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAskDeptID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            p_dtbOutDetail = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID) || string.IsNullOrEmpty(p_strAskDeptID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.retailprice_int,
       t.amount netamount_int,
       t.unit_vchr opunit_chr,
       t.medspec_vchr,
       d.deptid_chr,
       d.deptname_vchr,
       b.medicinename_vchr,
       b.assistcode_chr,
       m.instoragedate_dat prodate
  from t_ms_instorage_detal t,
       t_ms_instorage       m,
       t_bse_deptdesc       d,
       t_bse_medicine       b
 where m.storageid_chr = ?
   and m.state_int > 1
   and m.formtype_int = 2
   and m.seriesid_int = t.seriesid2_int
   and t.status = 1
   and m.returndept_chr = d.deptid_chr
   and t.medicineid_chr = b.medicineid_chr
   and m.instoragedate_dat between ? and ?
   and t.medicineid_chr = ?
   and m.returndept_chr = ?
 order by d.deptname_vchr, m.instoragedate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicineID;
                objDPArr[4].Value = p_strAskDeptID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutDetail, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbOutDetail != null && p_dtbOutDetail.Rows.Count > 0)
                {
                    int intRowsCount = p_dtbOutDetail.Rows.Count;
                    DataRow drCurrent = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_dtbOutDetail.Rows[iRow];
                        drCurrent["deptname_vchr"] = "(内退)" + drCurrent["deptname_vchr"].ToString();
                        drCurrent["netamount_int"] = 0 - Convert.ToDouble(drCurrent["netamount_int"]);
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

        [AutoComplete]
        public long m_lngGetBseMed(out DataTable dtBseMed)
        {
            long lngRes = -1;
            dtBseMed = null;
            string strSQL = @"select t.assistcode_chr, t.medicinename_vchr, t.medspec_vchr, t.opunit_chr,
                                     t.ipunit_chr, t.packqty_dec, t.productorid_chr, t.pycode_chr,
                                     t.wbcode_chr, t.medicineid_chr, t.ispoison_chr,
                                     t.ischlorpromazine2_chr, t.unitprice_mny, t.medicinetypeid_chr,
                                     t.tradeprice_mny, t.limitunitprice_mny, t.opchargeflg_int,
                                     t.ipchargeflg_int, t.ifstop_int,
                                     decode (sum (s.realgross_int),
                                             null, 0,
                                             sum (s.realgross_int)
                                            ) currentgross_num
                                from t_bse_medicine t left join t_ms_storage_detail s on t.medicineid_chr =
                                                                                           s.medicineid_chr
                                                                                    and exists (
                                                                                           select r.medicineroomid
                                                                                             from t_ms_medicinestoreroomset r
                                                                                            where r.medicinetypeid_chr =
                                                                                                     t.medicinetypeid_chr)
                            group by t.assistcode_chr,
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
                                     t.ifstop_int
                            order by t.assistcode_chr";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtBseMed);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 药品出库统计 （按各类别）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="Medid"></param>
        /// <param name="Typecode"></param>
        /// <param name="Medicinetype"></param>
        /// <param name="Storageid"></param>
        /// <param name="p_strDept"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngOutstorageStat(bool p_blnCombine,string Medid, string Typecode, string Medicinetype, string Storageid, string p_strDept,
                                        DateTime BeginDate, DateTime EndDate, out DataTable dtResult)
        {
            long lngRes = -1;
            dtResult = null;
            string strSQL = @"select b.medicineid_chr,
       b.medicinename_vch,
       b.medspec_vchr,
       b.opunit_chr,
       b.netamount_int,
       b.callprice_int,
       (b.netamount_int*b.callprice_int) as callsum,
       b.retailprice_int,
       (b.netamount_int * b.retailprice_int) as retailsum,
       (b.retailprice_int-b.callprice_int)*b.netamount_int as diffsum,
       a.outstorageid_vchr,
       a.outstoragedate_dat,
       c.typename_vchr,
       e.productorid_chr
  from t_ms_outstorage        a,
   t_ms_outstorage_detail b,
   t_aid_impexptype c,
   t_bse_medicine e
where a.seriesid_int = b.seriesid2_int
and b.medicineid_chr = e.medicineid_chr
and a.outstoragetype_int = c.typecode_vchr
and (a.outstoragedate_dat between ? and ?)
and a.storageid_chr = ? and b.status = 1 and a.status in (2,3)";
            ArrayList arr = new ArrayList();
            try
            {
                if (!string.IsNullOrEmpty(Typecode))
                {
                    strSQL += " and a.outstoragetype_int = ? ";
                    arr.Add(Typecode);
                }
                if (!string.IsNullOrEmpty(Medid))
                {
                    if (p_blnCombine)
                    {
                        strSQL += " and e.assistcode_chr = ? ";
                    }
                    else
                    {
                        strSQL += " and b.medicineid_chr = ? ";
                    }
                    
                    arr.Add(Medid);
                }
                if (!string.IsNullOrEmpty(p_strDept))
                {
                    strSQL += " and a.askdept_chr = ? ";
                    arr.Add(p_strDept);
                }
                if (!string.IsNullOrEmpty(Medicinetype))
                {
                    strSQL += " and e.medicinetypeid_chr = ? ";
                    arr.Add(Medicinetype);
                }
                
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(3 + arr.Count, out param);
                param[0].DbType = DbType.DateTime;
                param[0].Value = BeginDate;
                param[1].DbType = DbType.DateTime;
                param[1].Value = EndDate;
                param[2].Value = Storageid;

                if (arr.Count > 0)
                {
                    for (int i1 = 0; i1 < arr.Count; i1++)
                    {
                        param[3 + i1].Value = arr[i1].ToString();
                    }
                }
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataView dvResult = dtResult.DefaultView;
                    dvResult.Sort = "medicinename_vch";
                    dtResult = dvResult.ToTable();
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngOutStorageSumMoney(DateTime BeginDate, DateTime EndDate, string MedStorgeID, string DeptID, string MedTypeID,out DataTable dtResult)
        {
            long lngRes = -1;
            string strSQL = @"select (b.callprice_int * b.netamount_int) as outmoney,
                                      (b.retailprice_int * b.netamount_int) as retailmoney, c.deptid_chr,c.deptname_vchr
                                    from t_ms_outstorage a, t_ms_outstorage_detail b, t_bse_deptdesc c,t_bse_medicine d
                                    where a.seriesid_int = b.seriesid2_int
                                    and b.medicineid_chr=d.medicineid_chr
                                    and a.askdept_chr = c.deptid_chr
                                    and (a.inaccountdate_dat between ? and ?)
                                    and a.storageid_chr = ? ";
            dtResult = new DataTable();
            try
            {
                if (DeptID.Trim().Length > 0)
                {
                    strSQL += " and a.askdept_chr = '" + DeptID + "'";
                }
                if (MedTypeID.Trim().Length > 0)
                {
                    strSQL += " and d.medicinetypeid_chr = '" + MedTypeID + "'";
                }
                strSQL += " order by c.deptid_chr";

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(3, out param);
                param[0].DbType = DbType.DateTime;
                param[0].Value = BeginDate;
                param[1].DbType = DbType.DateTime;
                param[1].Value = EndDate;
                param[2].Value = MedStorgeID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngGetMedStroge(bool p_blnIsStore,out DataTable dtExp)
        {
            long lngRes = -1;
            string strSQL = "";
            if (p_blnIsStore)
            {
                strSQL = @"select t.deptid_chr medicineroomid,t.medstorename_vchr medicineroomname from t_bse_medstore t
                            order by t.medstoreid_chr";
            }
            else
            {
                strSQL = @"select distinct t.medicineroomid medicineroomid,
                                t.medicineroomname medicineroomname
                           from t_ms_medicinestoreroomset t
                       order by t.medicineroomid ";
            }
            dtExp = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtExp);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngGetMedType(bool p_blnIsStore,out DataTable dtMedType)
        {
            long lngRes = -1;
            string strSQL = "";
            if (p_blnIsStore)
            {
                strSQL = @"select a.medicinetypeid_chr,
			 b.medicinetypename_vchr,
			 c.deptid_chr medicineroomid
	from t_ds_medstoreset a
	left join t_aid_medicinetype b on b.medicinetypeid_chr =
																		a.medicinetypeid_chr
 inner join t_bse_medstore c on c.medstoreid_chr = a.medstoreid";
            }
            else
            {
                strSQL = @"select b.medicinetypeid_chr, b.medicinetypename_vchr, a.medicineroomid
                              from t_ms_medicinestoreroomset a, t_aid_medicinetype b
                             where a.medicinetypeid_chr = b.medicinetypeid_chr  ";
            }
            
           
            dtMedType = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtMedType);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        
        /// <summary>
        /// 厂家和类型
        /// </summary>
        /// <param name="p_blnForDrugStore">是否药房使用，0否，1是</param>
        /// <param name="dtExp"></param>
        /// <param name="dtVendor"></param>
        /// <param name="dtMedType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetExptypeAndVendor(bool p_blnForDrugStore, out DataTable dtExp, out DataTable dtVendor, out DataTable dtMedType)
        {
            long lngRes = -1;
            dtExp = null;
            dtVendor = null;
            dtMedType = null;
            string strSQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
//                strSQL = @"select distinct t.medicineroomid medicineroomid,
//                                t.medicineroomname medicineroomname
//                           from t_ms_medicinestoreroomset t
//                       order by t.medicineroomid ";
//                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtExp);
                lngRes = this.m_lngGetMedStroge(p_blnForDrugStore,out dtExp);

                strSQL = @"select t.vendorid_chr id, t.vendorname_vchr name, t.usercode_chr code,t.pycode_chr,t.wbcode_chr   
    from t_bse_vendor t where vendortype_int = 2 or vendortype_int = 3 order by t.usercode_chr ";
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtVendor);

//                strSQL = @"select b.medicinetypeid_chr, b.medicinetypename_vchr, a.medicineroomid
//                              from t_ms_medicinestoreroomset a, t_aid_medicinetype b
//                             where a.medicinetypeid_chr = b.medicinetypeid_chr ";
//                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtMedType);
                lngRes = this.m_lngGetMedType(p_blnForDrugStore,out dtMedType);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #region 药房药品出库统计 （按各类别）
       
        /// <summary>
        /// 药房药品出库统计 （按各类别）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="Medid"></param>
        /// <param name="Typecode"></param>
        /// <param name="Medicinetype"></param>
        /// <param name="Storageid"></param>
        /// <param name="p_txtDept"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDrugStoreOutstorageStat(bool p_blnCombine,string Medid, string Typecode, string Medicinetype, string Storageid, string p_txtDept,
                                        DateTime BeginDate, DateTime EndDate, bool p_blnIsHospital,out DataTable dtResult)
        {
            long lngRes = -1;
            dtResult = null;

            string strSQL = string.Empty;
            if (p_blnIsHospital)
            {
                strSQL = @"select b.medicineid_chr,
			 b.medicinename_vchr medicinename_vch,
			 b.medspec_vchr,
			 decode(d.ipchargeflg_int,0,b.opunit_chr,b.ipunit_chr) as opunit_chr,
			 decode(d.ipchargeflg_int,0,b.opamount_int,b.ipamount_int) as netamount_int,
       decode(d.ipchargeflg_int,0,b.opretailprice_int,round(b.opretailprice_int/b.packqty_dec,4)) retailprice_int,
             round(b.opretailprice_int*b.ipamount_int/b.packqty_dec,4) retailsum,
			 a.outdrugstoreid_vchr outstorageid_vchr,
			 a.examdate_dat outstoragedate_dat,
			 c.typename_vchr,
			 b.productorid_chr
	from t_ds_outstorage        a,
			 t_ds_outstorage_detail b,
			 t_aid_impexptype       c,
			 t_bse_medicine         d
 where a.seriesid_int = b.seriesid2_int
	 and b.medicineid_chr = d.medicineid_chr
	 and c.typecode_vchr = a.typecode_vchr
     and a.status_int in (2,3) and b.status = 1 and a.formtype_int in (1, 2, 3)
	 and (a.examdate_dat between ? and ?)
	 and a.drugstoreid_chr = ?";
            }
            else
            {
                strSQL = @"select b.medicineid_chr,
			 b.medicinename_vchr medicinename_vch,
			 b.medspec_vchr,
			 decode(d.opchargeflg_int,0,b.opunit_chr,b.ipunit_chr) as opunit_chr,
			 decode(d.opchargeflg_int,0,b.opamount_int,b.ipamount_int) as netamount_int,
       decode(d.opchargeflg_int,0,b.opretailprice_int,round(b.opretailprice_int/b.packqty_dec,4)) retailprice_int,
             round(b.opretailprice_int*b.ipamount_int/b.packqty_dec,4) retailsum,
			 a.outdrugstoreid_vchr outstorageid_vchr,
			 a.examdate_dat outstoragedate_dat,
			 c.typename_vchr,
			 b.productorid_chr
	from t_ds_outstorage        a,
			 t_ds_outstorage_detail b,
			 t_aid_impexptype       c,
			 t_bse_medicine         d
 where a.seriesid_int = b.seriesid2_int
	 and b.medicineid_chr = d.medicineid_chr
	 and c.typecode_vchr = a.typecode_vchr
     and a.status_int in (2,3) and b.status = 1 and a.formtype_int in (1, 2, 3)
	 and (a.examdate_dat between ? and ?)
	 and a.drugstoreid_chr = ?";
            }
            ArrayList arr = new ArrayList();
            try
            {
                if (!string.IsNullOrEmpty(Typecode))
                {
                    strSQL += " and a.typecode_vchr = ? ";
                    arr.Add(Typecode);
                }
                if (!string.IsNullOrEmpty(Medid))
                {
                    if (p_blnCombine)
                    {
                        strSQL += " and d.assistcode_chr = ? ";
                    }
                    else
                    {
                        strSQL += " and b.medicineid_chr = ? ";
                    }
                    arr.Add(Medid);
                }
                if (!string.IsNullOrEmpty(p_txtDept))
                {
                    strSQL += " and a.instoredept_chr = ? ";
                    arr.Add(p_txtDept);
                }
                if (!string.IsNullOrEmpty(Medicinetype))
                {
                    strSQL += " and d.medicinetypeid_chr = ? ";
                    arr.Add(Medicinetype);
                }

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(3+arr.Count, out param);
                param[0].DbType = DbType.DateTime;
                param[0].Value = BeginDate;
                param[1].DbType = DbType.DateTime;
                param[1].Value = EndDate;
                param[2].Value = Storageid;
                
                for (int i1 = 0; i1 < arr.Count; i1++)
                {
                    param[3 + i1].Value = arr[i1];
                }
                
                

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataView dvResult = dtResult.DefaultView;
                    dvResult.Sort = "medicinename_vch";
                    dtResult = dvResult.ToTable();
                }
                objHRPSvc.Dispose();

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

    #endregion
}
