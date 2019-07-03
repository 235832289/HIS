using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房公用中间件
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsDS_Public_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取序列号

        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSEQName">Sequence名称</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSequence(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSEQName, out long p_lngSEQ)
        {
            p_lngSEQ = 0;
            if (string.IsNullOrEmpty(p_strSEQName))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select " + p_strSEQName + ".nextval from dual";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    DataTable dtValue = null;
                    lngRes = objHRPServ.DoGetDataTable(strSQL, ref dtValue);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    if (dtValue != null && dtValue.Rows.Count == 1)
                    {
                        p_lngSEQ = Convert.ToInt64(dtValue.Rows[0][0]);
                    }
                    else
                    {
                        p_lngSEQ = 1;
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
        /// 获取多个序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSEQName">Sequence名称</param>
        /// <param name="p_strNum">要获取的数量</param>
        /// <param name="p_lngSEQArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSequenceArr(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSEQName, int p_intNum, out long[] p_lngSEQArr)
        {
            p_lngSEQArr = null;
            if (p_intNum <= 0 || string.IsNullOrEmpty(p_strSEQName))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select getseq(?,?) seqarr from dual";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    DataTable dtValue = null;

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strSEQName;
                    objDPArr[1].Value = p_intNum;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objDPArr);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    if (lngRes > 0 && dtValue != null && dtValue.Rows.Count == 1)
                    {
                        p_lngSEQArr = new long[p_intNum];
                        long lngLastSeq = Convert.ToInt64(dtValue.Rows[0][0]);
                        for (int iRow = p_intNum - 1; iRow >= 0; iRow--)
                        {
                            p_lngSEQArr[iRow] = lngLastSeq--;
                        }
                    }
                    else
                    {
                        p_lngSEQArr = new long[1];
                        p_lngSEQArr[0] = 1;
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

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode,string m_strMedStoreid, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }
            if (m_strMedStoreid == string.Empty)
            {
                try
                {
                    string strSQL = string.Empty;

                    clsHRPTableService objHRPServ = new clsHRPTableService();

                    if (string.IsNullOrEmpty(p_strAssistCode))
                    {
                        strSQL = @"select t.assistcode_chr,
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
                                  and b.flag_int = 1 where  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";

                        lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbMedicine);
                    }
                    else
                    {
                        strSQL = @"select t.assistcode_chr,
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
 where t.assistcode_chr like ? and  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";

                        IDataParameter[] objDPArr = null;
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_strAssistCode + "%";

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                    }
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
                    string strSQL = string.Empty;

                    clsHRPTableService objHRPServ = new clsHRPTableService();

                    if (string.IsNullOrEmpty(p_strAssistCode))
                    {
                        strSQL = @"select t.assistcode_chr,
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

                        IDataParameter[] objDPArr = null;
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = m_strMedStoreid;

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                    }
                    else
                    {
                        strSQL = @"select t.assistcode_chr,
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
 where t.assistcode_chr like ? and t.deleted_int = 0
 order by t.assistcode_chr, t.medicineid_chr";

                        IDataParameter[] objDPArr = null;
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = m_strMedStoreid;
                        objDPArr[1].Value = p_strAssistCode + "%";
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                    }
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
        #region 获取门诊药房基本信息表
        /// <summary>
        /// 获取门诊药房基本信息表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtMedStore"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_dtMedStore)
        {

            long lngRes = 0;
            m_dtMedStore = null;
            string strSQL = @"select a.medstoreid_chr,
       a.medstorename_vchr,
       a.medstoretype_int,
       a.medicnetype_int,
       a.urgence_int,
       a.deptid_chr,
       b.deptname_vchr,
       a.shortname_chr
  from t_bse_medstore a, t_bse_deptdesc b
 where a.deptid_chr = b.deptid_chr(+)
 order by a.medstoreid_chr";
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.DoGetDataTable(strSQL, ref m_dtMedStore);
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
        #region 获取科室基本信息表
        /// <summary>
        /// 获取门诊药房基本信息表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtDeptDesc"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_dtDeptDesc)
        {

            long lngRes = 0;
            m_dtDeptDesc = null;
            string strSQL = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr,attributeid
  from t_bse_deptdesc
 where status_int = 1
 order by deptname_vchr";
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
     
                lngRes = objHRPServ.DoGetDataTable(strSQL, ref m_dtDeptDesc);
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
        #region 获取药房对应简码
        /// <summary>
        ///  获取药房对应简码
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDeptid_chr"></param>
        /// <param name="m_strMedStoreShortCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStoreShortCodeByDeptid(System.Security.Principal.IPrincipal p_objPrincipal,string m_strDeptid_chr, out string m_strMedStoreShortCode)
        {

            long lngRes = 0;
            DataTable dtTemp = null;
            m_strMedStoreShortCode = string.Empty;
            string strSQL = @"select a.shortname_chr from t_bse_medstore a where a.deptid_chr=?";
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = m_strDeptid_chr;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtTemp, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtTemp.Rows.Count == 1)
                {
                    m_strMedStoreShortCode = dtTemp.Rows[0][0].ToString();

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
        #region 根据表名和列名获取单据ID
        /// <summary>
        /// 根据表名和列名获取单据ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strTabName"></param>
        /// <param name="m_strColName"></param>
        /// <param name="m_datLike"></param>
        /// <param name="m_strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNewIdByName(System.Security.Principal.IPrincipal p_objPrincipal, string m_strTabName,string m_strColName, DateTime m_datLike, ref string m_strID)
        {
            m_strID = string.Empty;
            if (string.IsNullOrEmpty(m_strTabName))
            {
                return -1;
            }
            DataTable dtValue = new DataTable();
            long lngRes = 0;
            try
            {

                string strSQL = "select max(" + m_strColName + ") + 1 as nextid  from " + m_strTabName + " where " + m_strColName + " like ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = m_datLike.ToString("yyMMdd") + "%";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtValue != null && dtValue.Rows.Count == 1)
                {
                    if (dtValue.Rows[0]["nextid"] != System.DBNull.Value)
                    {
                        m_strID = dtValue.Rows[0]["nextid"].ToString().Substring(dtValue.Rows[0]["nextid"].ToString().Length - 5, 5);
                    }
                    else
                    {
                        m_strID = "00001";
                    }
                }
                else
                {
                    m_strID = "00001";
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
        #region 根据表名和列名获取单据ID
        /// <summary>
        /// 根据表名和列名获取单据ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strTabName"></param>
        /// <param name="m_strColName"></param>
        /// <param name="m_datLike"></param>
        /// <param name="m_strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNewIdByName(System.Security.Principal.IPrincipal p_objPrincipal, string m_strTabName, string m_strColName, string m_strMedStoreShortName, DateTime m_datLike, ref string m_strID)
        {
            m_strID = string.Empty;
            if (string.IsNullOrEmpty(m_strTabName))
            {
                return -1;
            }
            DataTable dtValue = new DataTable();
            long lngRes = 0;
            try
            {

                if (m_strMedStoreShortName.Trim() == string.Empty)
                    throw new Exception("请先维护该药房对应的简码！");
                string strSQL = "select max(" + m_strColName + ") as nextid  from " + m_strTabName + " where " + m_strColName + " like ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = m_strMedStoreShortName+m_datLike.ToString("yyMMdd") + "%";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtValue != null && dtValue.Rows.Count == 1)
                {
                    if (dtValue.Rows[0]["nextid"] != System.DBNull.Value)
                    {
                        m_strID = Convert.ToString((Convert.ToInt16(dtValue.Rows[0]["nextid"].ToString().Substring(dtValue.Rows[0]["nextid"].ToString().Length - 3, 3)) + 1)).PadLeft(3, '0');
                    }
                    else
                    {
                        m_strID = "001";
                    }
                }
                else
                {
                    m_strID = "001";
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
        #region 获取门诊药房对应的部门号
        /// <summary>
        /// 获取门诊药房对应的部门号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strDeptID">部门号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStorageID, out string p_strDeptID)
        {
            DataTable m_dtMedStore = new DataTable();
            long lngRes = 0;
            p_strDeptID = string.Empty;
            string strSQL = @"select deptid_chr from t_bse_medstore where medstoreid_chr = ?";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;                
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtMedStore,objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtMedStore.Rows.Count > 0)
                    p_strDeptID = m_dtMedStore.Rows[0][0].ToString();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 获取系统参数设置
         /// <summary>
        /// 获取系统参数设置
         /// </summary>
         /// <param name="p_objPrincipal"></param>
         /// <param name="p_strStorageID"></param>
         /// <param name="p_strDeptID"></param>
         /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysParaByID(System.Security.Principal.IPrincipal p_objPrincipal, string m_strParaCode, out string m_strParaValue)
        {
            DataTable m_dtTemp = new DataTable();
            long lngRes = 0;
            m_strParaValue = string.Empty;
            string strSQL = @"select a.parmvalue_vchr from t_bse_sysparm a  where a.parmcode_chr=?";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strParaCode;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtTemp, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtTemp.Rows.Count > 0)
                {
                    m_strParaValue = m_dtTemp.Rows[0][0].ToString();
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
        #region 获取出入库类型
        /// <summary>
        /// 获取出入库类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intType">0为入库，1为出库</param>
        /// <param name="m_dtStoreType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTypeCode(System.Security.Principal.IPrincipal p_objPrincipal, Int16 p_intType, out DataTable m_dtStoreType)
        {

            long lngRes = 0;
            m_dtStoreType = null;
            string strSQL = @"select typecode_vchr, typename_vchr
  from t_aid_impexptype
 where flag_int = ?
   and status_int = 1
   and (storgeflag_int = 1 or storgeflag_int = 2)
 order by orderno_int";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = p_intType;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtStoreType,objParm);
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

        #region 根据类型名称获取出入库类型ID
        /// <summary>
        /// 根据类型名称获取出入库类型ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intFlag">0-入库；1-出库</param>
        /// <param name="p_strTypeName">类型名称</param>        
        /// <param name="p_intTypeCode">类型ID</param>        
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTypeCodeByName(System.Security.Principal.IPrincipal p_objPrincipal, int p_intFlag, string p_strTypeName, out int p_intTypeCode)
        {
            p_intTypeCode = 0;
            long lngRes = 0;
            DataTable dtbValue = new DataTable();
            string strSQL = @"select typecode_vchr
	from t_aid_impexptype
 where flag_int = ?     
	 and status_int = 1
	 and typename_vchr = ?";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(2, out objParm);
                objParm[0].Value = p_intFlag;
                objParm[1].Value = p_strTypeName;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_intTypeCode = Convert.ToInt32(dtbValue.Rows[0]["typecode_vchr"]);
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

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：0为药房入库单</param>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckStatus(System.Security.Principal.IPrincipal p_objPrincipal, int p_intBill, long p_lngSeq, out int p_intStatus)
        {
            p_intStatus = -1;            
            long lngRes = 0;
            string strSQL = null;
            switch (p_intBill)
            {
                case 0://药房入库单
                    strSQL = @"select a.status from t_ds_instorage a where a.seriesid_int = ?";
                    break;
                case 1://药房出库单
                    strSQL = @"select a.status_int from t_ds_outstorage a where a.seriesid_int = ?";
                    break;
                case 2://药房盘点表
                    strSQL = @"select a.status_int from t_ds_drugstorecheck a where a.seriesid_int = ?";
                    break;
                case 3://药房请领单
                    strSQL = @"select a.status_int from t_ds_ask a where a.seriesid_int = ?";
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(strSQL))
                return lngRes;
            try
            {
                DataTable m_dtResult = new DataTable();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeq;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtResult.Rows.Count > 0)
                {
                    p_intStatus = Convert.ToInt16(m_dtResult.Rows[0][0]);
                }
                m_dtResult.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取数据库服务器当前时间
        /// <summary>
        /// 获取数据库服务器当前时间
        /// </summary>
        /// <param name="p_dtmSysDate">返回数据库服务器当前时间</param>
        /// <returns></returns>
        public long m_lngGetSystemDateTime(out DateTime p_dtmSysDate)
        {
            p_dtmSysDate = DateTime.Now;
            long lngRes = 1;
            try
            {
                DataTable dtbResult = new DataTable();
                string strSQL = "select sysdate from dual";
                clsHRPTableService objServ = new clsHRPTableService();
                lngRes = objServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_dtmSysDate = Convert.ToDateTime(dtbResult.Rows[0][0]);
                }
                objServ.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion    
    
        #region 获取中间件服务器的当前时间（界面，而非数据库）
        public long m_lngGetCurrentDateTime(out DateTime p_dtmCurrentDateTime)
        {
            p_dtmCurrentDateTime = DateTime.Now;
            long lngRes = 1;
            try
            {
                com.digitalwave.iCare.middletier.common.clsGetCurrentTime clsGetTime = new com.digitalwave.iCare.middletier.common.clsGetCurrentTime();
                p_dtmCurrentDateTime = clsGetTime.m_mthGetCurrentDateTime();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugStoreId">药房ID</param>
        /// <param name="p_objMPVO">药品制剂类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicinePreptype(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDrugStoreId, out com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] p_objMPVO)
        {
            p_objMPVO = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select medicinepreptype_chr, medicinepreptypename_vchr, flaga_int
  from t_aid_medicinepreptype a
 where a.medicinepreptype_chr in
       (select b.medicinepreptype_chr
          from t_bse_medicine b
         where b.medicinetypeid_chr in
               (select c.medicinetypeid_chr
                  from t_ds_medstoreset c
                 where c.medstoreid = ?))
 order by a.medicinepreptypename_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                DataTable dtbValue = new DataTable();
                objHRPServ.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strDrugStoreId;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objParamArr);
                
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    p_objMPVO = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[intRowsCount];
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_objMPVO[iRow] = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO();
                        drTemp = dtbValue.Rows[iRow];
                        p_objMPVO[iRow].m_strMEDICINEPREPTYPE_CHR = drTemp["MEDICINEPREPTYPE_CHR"].ToString();
                        p_objMPVO[iRow].m_strMEDICINEPREPTYPENAME_VCHR = drTemp["MEDICINEPREPTYPENAME_VCHR"].ToString();
                        p_objMPVO[iRow].m_intFLAGA_INT = Convert.ToInt32(drTemp["FLAGA_INT"]);
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

        #region 检查单据FormType
        /// <summary>
        /// 检查单据FormType
        /// </summary>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="p_intFormType">单据FormType值</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckFormType(System.Security.Principal.IPrincipal p_objPrincipal,long p_lngSeq, out int p_intFormType)
        {
            p_intFormType = -1;
            long lngRes = 0;
            string strSQL = @"select a.formtype_int from t_ds_instorage a where a.seriesid_int = ?";
                    
            if (string.IsNullOrEmpty(strSQL))
                return lngRes;
            try
            {
                DataTable m_dtResult = new DataTable();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeq;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtResult.Rows.Count > 0)
                {
                    p_intFormType = Convert.ToInt16(m_dtResult.Rows[0][0]);
                }
                m_dtResult.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 该部门是否为药房
        /// <summary>
        /// 该部门是否为药房
        /// </summary>
        /// <param name="p_strDeptID">部门ID</param>
        /// <param name="p_blnDrugStore">是否为药房</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsDrugStoreDept(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, out bool p_blnDrugStore)
        {
            p_blnDrugStore = false;
            long lngRes = 0;
            string strSQL = @"select a.medstoreid_chr from t_bse_medstore a where a.deptid_chr = ?";
          
            try
            {
                DataTable m_dtResult = new DataTable();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDeptID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtResult.Rows.Count > 0)
                {
                    p_blnDrugStore = true;
                }
                m_dtResult.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取药库对应简码
        /// <summary>
        /// 获取药库对应简码
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strStorageid"></param>
        /// <param name="m_strStorageShortCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageShortCode(System.Security.Principal.IPrincipal p_objPrincipal, string m_strStorageid, out string m_strStorageShortCode)
        {

            long lngRes = 0;
            DataTable dtTemp = null;
            m_strStorageShortCode = string.Empty;
            string strSQL = @"select distinct t.shortname_chr            
  from t_ms_medicinestoreroomset t where t.medicineroomid=?";
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = m_strStorageid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtTemp, objParm);
                if (lngRes > 0 && dtTemp.Rows.Count == 1)
                {
                    m_strStorageShortCode = dtTemp.Rows[0][0].ToString();

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

        #region 根据表名和列名获取单据ID（药库用）
        /// <summary>
        /// 根据表名和列名获取单据ID（药库用）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strTabName"></param>
        /// <param name="m_strColName"></param>
        /// <param name="m_strMedStoreShortName"></param>
        /// <param name="p_strSpecial"></param>
        /// <param name="m_datLike"></param>
        /// <param name="m_strID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNewIdByName(System.Security.Principal.IPrincipal p_objPrincipal, string m_strTabName, string m_strColName, string m_strMedStoreShortName, string p_strSpecial, DateTime m_datLike, ref string m_strID)
        {
            m_strID = string.Empty;
            if (string.IsNullOrEmpty(m_strTabName))
            {
                return -1;
            }
            DataTable dtValue = new DataTable();
            long lngRes = 0;
            try
            {

                if (m_strMedStoreShortName.Trim() == string.Empty)
                    throw new Exception("请先维护该药房对应的简码！");
                string strSQL = "select max(" + m_strColName + ") as nextid  from " + m_strTabName + " where " + m_strColName + " like ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = m_strMedStoreShortName + m_datLike.ToString("yyMMdd") + p_strSpecial + "%";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtValue != null && dtValue.Rows.Count == 1)
                {
                    if (dtValue.Rows[0]["nextid"] != System.DBNull.Value)
                    {
                        m_strID = Convert.ToString((Convert.ToInt16(dtValue.Rows[0]["nextid"].ToString().Substring(dtValue.Rows[0]["nextid"].ToString().Length - 3, 3)) + 1)).PadLeft(3, '0');
                    }
                    else
                    {
                        m_strID = "001";
                    }
                }
                else
                {
                    m_strID = "001";
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
        
    }
  

}
