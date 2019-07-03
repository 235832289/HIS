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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDS_PublicSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
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
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

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
       t.ifstop_int
  from t_bse_medicine t
 order by t.assistcode_chr";

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
       t.ifstop_int
  from t_bse_medicine t
 where t.assistcode_chr like ?
 order by t.assistcode_chr";

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strAssistCode + "%";

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
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
            string strSQL = @"select   a.medstoreid_chr, a.medstorename_vchr, a.medstoretype_int,
                              a.medicnetype_int, a.urgence_int,a.deptid_chr,b.deptname_vchr 
                              from t_bse_medstore a ,t_bse_deptdesc b where a.deptid_chr=b.deptid_chr(+)
                              order by a.medstorename_vchr";
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.DoGetDataTable(strSQL, ref m_dtMedStore);


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
                DataTable dtValue = null;
                lngRes = objHRPServ.DoGetDataTable(strSQL, ref m_dtDeptDesc);


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

                string strSQL = "select max(" + m_strColName + ") + 1 as nextid  from " + m_strTabName + " where "+m_strColName+" like ?";
                 
                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    System.Data.IDataParameter[] objParm = null;
                    objHRPServ.CreateDatabaseParameter(1, out objParm);
                    objParm[0].Value = m_datLike.ToString("yyMMdd")+"%";
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objParm);
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
    }
  

}
