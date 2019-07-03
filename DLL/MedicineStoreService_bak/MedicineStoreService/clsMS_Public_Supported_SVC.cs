using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药库中间件公共类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsMS_Public_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
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
        /// 获取多个序列号        /// </summary>
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

        #region 获取供应商
        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbVendor">供应商数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetVendor(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbVendor)
        {
            p_dtbVendor = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.vendorid_chr id, t.vendorname_vchr name, t.usercode_chr code,t.pycode_chr,t.wbcode_chr 
from t_bse_vendor t where vendortype_int = 1 or vendortype_int = 3 order by t.usercode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
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

        #region 获取生产厂家
        /// <summary>
        /// 获取生产厂家
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbVendor">生产厂家数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetManufacturer(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbVendor)
        {
            p_dtbVendor = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.vendorid_chr id, t.vendorname_vchr name, t.usercode_chr code,t.pycode_chr,t.wbcode_chr   
    from t_bse_vendor t where vendortype_int = 2 or vendortype_int = 3 order by t.usercode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
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

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMPVO">药品制剂类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicinePreptype(System.Security.Principal.IPrincipal p_objPrincipal, out com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] p_objMPVO)
        {
            p_objMPVO = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select medicinepreptype_chr, medicinepreptypename_vchr, flaga_int
  from t_aid_medicinepreptype";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DataTable dtbValue = null;

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);
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

        #region 获取指定仓库的药品类型
        /// <summary>
        /// 获取指定仓库的药品类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMTVO">药品类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageMedicineType(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO[] p_objMTVO)
        {
            p_objMTVO = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select a.medicinetypeid_chr, a.medicinetypename_vchr
  from t_aid_medicinetype a, t_ms_medicinestoreroomset b
 where a.medicinetypeid_chr = b.medicinetypeid_chr
   and b.medicineroomid = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DataTable dtbValue = null;
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    p_objMTVO = new com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO[intRowsCount];
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_objMTVO[iRow] = new com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO();
                        drTemp = dtbValue.Rows[iRow];
                        p_objMTVO[iRow].m_strMedicineTypeID_CHR = drTemp["medicinetypeid_chr"].ToString();
                        p_objMTVO[iRow].m_strMedicineTypeName_VCHR = drTemp["medicinetypename_vchr"].ToString();
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

        #region 获取系统设置
        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSetID">设置ID</param>
        /// <param name="p_intSet">设置代码</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysSetting(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSetID, out int p_intSet)
        {
            p_intSet = 0;
            if (p_strSetID == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select setstatus_int from t_sys_setting where setid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strSetID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_intSet = Convert.ToInt32(dtbValue.Rows[0][0]);
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

        #region 获取药房
        /// <summary>
        /// 获取药房
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedStoreArr">药房</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStore(System.Security.Principal.IPrincipal p_objPrincipal, out com.digitalwave.iCare.ValueObject.clsMS_MedStore[] p_objMedStoreArr)
        {
            p_objMedStoreArr = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.medstoreid_chr, t.medstorename_vchr from t_bse_medstore t";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount <= 0)
                    {
                        return 0;
                    }

                    DataRow drTemp = null;
                    p_objMedStoreArr = new com.digitalwave.iCare.ValueObject.clsMS_MedStore[intRowsCount];
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_objMedStoreArr[iRow] = new com.digitalwave.iCare.ValueObject.clsMS_MedStore();
                        drTemp = dtbValue.Rows[iRow];
                        p_objMedStoreArr[iRow].m_strMEDSTOREID_CHR = drTemp["medstoreid_chr"].ToString();
                        p_objMedStoreArr[iRow].m_strMEDSTORENAME_VCHR = drTemp["medstorename_vchr"].ToString();
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
                    throw new Exception("请先维护该药库对应的简码！");
                string strSQL = "select max(" + m_strColName + ") as nextid  from " + m_strTabName + " where " + m_strColName + " like ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = m_strMedStoreShortName + m_datLike.ToString("yyMMdd") + "%";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtValue != null && dtValue.Rows.Count == 1)
                {
                    if (dtValue.Rows[0]["nextid"] != System.DBNull.Value)
                    {
                        m_strID = Convert.ToString((Convert.ToInt16(dtValue.Rows[0]["nextid"].ToString().Substring(dtValue.Rows[0]["nextid"].ToString().Length - 3, 3))+1)).PadLeft(3,'0');
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

        #region 获取仓库名
        /// <summary>
        /// 获取仓库名
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreRoomName(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            p_strStoreRoomName = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct t.medicineroomid, t.medicineroomname
  from t_ms_medicinestoreroomset t
 where t.medicineroomid = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStoreRoomID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strStoreRoomName = dtbValue.Rows[0]["medicineroomname"].ToString();
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
                objHRPServ.Dispose();
                objHRPServ = null;
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

        #region 获取货架
        /// <summary>
        /// 获取货架
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intType">库房类型(1,药库 2,药房)</param>
        /// <param name="p_dtbDate">获取数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoragePack(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, int p_intType, out DataTable p_dtbDate)
        {
            p_dtbDate = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select storagerackid_chr,
       storagerackcode_vchr,
       storagerackname_vchr,
       pycode_chr,
       wbcode_chr
  from t_ms_storagerackset
 where storageid_chr = ?
   and typeid_int = ?
  order by storagerackcode_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_intType;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbDate, objDPArr);
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

        #region 获取系统参数配置
        /// <summary>
        /// 获取系统参数配置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCode">配置代码</param>
        /// <param name="p_strParm">参数配置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysParm(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCode, out string p_strParm)
        {
            p_strParm = string.Empty;
            long lngRes = 0;

            try
            {
                string strSQL = @"select parmvalue_vchr
  from t_bse_sysparm
 where parmcode_chr = ?
   and status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCode;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strParm = dtbValue.Rows[0][0].ToString();
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

        #region 获取领用部门（药库用）

        /// <summary>
        /// 获取领用部门（药库用）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetExportDept(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbVendor)
        {
            p_dtbVendor = null;

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
 where e.storageflag_int <> 1 
order by e.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
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

        #region 获取最后帐务结转的结束日期
        /// <summary>
        /// 获取最后帐务结转的结束日期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAccountperiodTime(System.Security.Principal.IPrincipal p_objPrincipal,out DateTime datAccountperiodTime)
        {
            DataTable p_dtbVendor = new DataTable();
            datAccountperiodTime = DateTime.MinValue;
            long lngRes = 0;
            try
            {
                string strSQL = @"select max(endtime_dat) endtime_dat from t_ms_accountperiod";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbVendor != null && p_dtbVendor.Rows.Count > 0)
                {
                    if (p_dtbVendor.Rows[0]["endtime_dat"].ToString() == "")
                    {
                        datAccountperiodTime = Convert.ToDateTime("0001-1-1");
                    }
                    else
                    {
                        datAccountperiodTime = Convert.ToDateTime(p_dtbVendor.Rows[0]["endtime_dat"]);
                    }
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取最后帐务结转的结束日期
        /// <summary>
        /// 获取最后帐务结转的结束日期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAccountperiodTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID,out DateTime datAccountperiodTime)
        {
            DataTable p_dtbVendor = new DataTable();
            datAccountperiodTime = DateTime.MinValue;
            long lngRes = 0;
            try
            {
                string strSQL = @"select max(endtime_dat) endtime_dat
  from t_ms_accountperiod a
 where a.storageid_chr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strStorageID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbVendor,objParamArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbVendor != null && p_dtbVendor.Rows.Count > 0)
                {
                    if (p_dtbVendor.Rows[0]["endtime_dat"].ToString() == "")
                    {
                        datAccountperiodTime = Convert.ToDateTime("0001-1-1");
                    }
                    else
                    {
                        datAccountperiodTime = Convert.ToDateTime(p_dtbVendor.Rows[0]["endtime_dat"]);
                    }
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取时间所属的帐务期
        /// <summary>
        /// 获取时间之前的帐务期
        /// </summary>
        /// <param name="p_objPrincipal">IPrincipal</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmQueryDate">时间</param>
        /// <param name="p_strQueryAccount">帐务期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmQueryDate, out string p_strQueryAccount)
        {
            p_strQueryAccount = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @"select max(accountid_chr) accountid_chr from t_ms_accountperiod 
                                  where storageid_chr = ? 
                                  and endtime_dat <= ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_dtmQueryDate;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strQueryAccount = dtbValue.Rows[0]["accountid_chr"].ToString();
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

        #region 获取药品是否已调价

        /// <summary>
        /// 获取药品是否已调价
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="medicineid_chr">药品ID</param>
        /// <param name="lotno_vchr">批号</param>
        /// <param name="instorageid_vchr">入库单号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_dblAdjustrice">是否已调价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAdjustrice(System.Security.Principal.IPrincipal p_objPrincipal, string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice,
            DateTime datNewdate, out bool p_dblAdjustrice)
        {
            p_dblAdjustrice = false;

            long lngRes = 0;
            try
            {
                string strSQL = @"select count(t.seriesid_int) seri
  from t_ms_adjustprice_detail t, t_ms_adjustprice b
 where t.seriesid2_int = b.seriesid_int
   and t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.instorageid_vchr = ?
   and b.formstate_int = 2
   and b.newdate_dat > ?
   and t.validperiod_dat = ?
   and t.callprice_int = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                objDPArr[0].Value = medicineid_chr;
                objDPArr[1].Value = lotno_vchr;
                objDPArr[2].Value = instorageid_vchr;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = datNewdate;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_dtmValiDate;
                objDPArr[5].Value = p_dblInPrice;
                DataTable dtbValue = null;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue.Rows[0]["seri"].ToString() == "0")
                {
                    p_dblAdjustrice = false;
                }
                else
                {
                    p_dblAdjustrice = true;
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

        #region 获取药品名
        /// <summary>
        /// 获取药品名
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strMedicineName">药品名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineName(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out string p_strMedicineName)
        {
            p_strMedicineName = string.Empty;

            long lngRes = 0;
            try
            {//medicinetypeid_chr
                string strSQL = @"select medicinename_vchr from t_bse_medicine where medicineid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strMedicineName = dtbValue.Rows[0]["medicinename_vchr"].ToString();
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

        #region 获取药品规格
        /// <summary>
        /// 获取药品规格
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strMedicineSpec">药品规格</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineSpec(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out string p_strMedicineSpec)
        {
            p_strMedicineSpec = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @"select medspec_vchr from t_bse_medicine where medicineid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strMedicineSpec = dtbValue.Rows[0]["medspec_vchr"].ToString();
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
        public long m_lngGetNewIdByName(System.Security.Principal.IPrincipal p_objPrincipal, string m_strTabName, string m_strColName, DateTime m_datLike, ref string m_strID)
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

        #region 获取出入库类型信息表

        /// <summary>
        /// 获取出入库类型信息表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtImpExpType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetImpExpTypeInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_dtImpExpType)
        {
            m_dtImpExpType = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select b.typecode_vchr,b.typename_vchr,b.flag_int,b.storgeflag_int from t_aid_impExptype b where b.status_int=1 order by b.orderno_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtImpExpType);
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

        #region 根据类型ID获取出入库类型名称
        /// <summary>
        /// 根据类型ID获取出入库类型名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intFlag">0-入库；1-出库</param>
        /// <param name="p_intTypeCode">类型ID</param>    
        /// <param name="p_strTypeName">类型名称</param>                    
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTypeNameByID(System.Security.Principal.IPrincipal p_objPrincipal, int p_intFlag, string p_intTypeCode, out string p_strTypeName)
        {
            p_strTypeName = string.Empty;
            long lngRes = 0;
            DataTable dtbValue = new DataTable();
            string strSQL = @"select typename_vchr
	from t_aid_impexptype
 where flag_int = ?     
	 and status_int = 1
	 and typecode_vchr = ?";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(2, out objParm);
                objParm[0].Value = p_intFlag;
                objParm[1].Value = p_intTypeCode;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strTypeName = Convert.ToString(dtbValue.Rows[0]["typename_vchr"]);
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

        #region 根据药库Id获取对应的部门ID
        /// <summary>
        /// 根据药库Id获取对应的部门ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStorageID">药库Id</param>    
        /// <param name="p_strDeptID">部门ID</param>                    
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptIDForStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_intStorageID, out string p_strDeptID)
        {
            p_strDeptID = string.Empty;
            long lngRes = 0;
            DataTable dtbValue = new DataTable();
            string strSQL = @"select a.deptid_chr
	from t_ms_medicinestoreroomset a
 where a.medicineroomid = ? ";
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

        #region 根据药房ID获取药房名称

        /// <summary>
        /// 根据药房ID获取药房名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID">药房ID</param>
        /// <param name="p_strStoreRoomName">药房名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDrugStoreRoomName(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            p_strStoreRoomName = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @" select a.medstorename_vchr
	 from t_bse_medstore a
	where a.medstoreid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStoreRoomID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strStoreRoomName = dtbValue.Rows[0]["medstorename_vchr"].ToString();
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

        #region 根据药库ID获取药房名称

        /// <summary>
        /// 根据药库ID获取药房名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID">药库ID</param>
        /// <param name="p_strStoreRoomName">药库名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageRoomName(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            p_strStoreRoomName = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @" select a.medicineroomname
	 from t_ms_medicinestoreroomset a
	where a.medicineroomid = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStoreRoomID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strStoreRoomName = dtbValue.Rows[0]["medicineroomname"].ToString();
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

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：0为药库入库单</param>
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
                case 0://药库入库单
                    strSQL = @"select a.state_int from t_ms_instorage a where a.seriesid_int = ?";
                    break;
                case 1://药库出库单
                    strSQL = @"select a.status from t_ms_outstorage a where a.seriesid_int = ?";
                    break;
                case 2://药库盘点表
                    strSQL = @"select a.status from t_ms_storagecheck a where a.seriesid_int = ?";
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

        #region 获取领用部门（药房用）
        /// <summary>
        /// 获取领用部门（药房用）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetExportDeptForDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbVendor)
        {
            p_dtbVendor = null;

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

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
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

        #region 获取服务器当前时间
        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <param name="p_dtmSysDate">返回服务器当前时间</param>
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
            catch(Exception objEx)
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

        #region 获取药品零售价
        /// <summary>
        /// 获取药品零售价
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dcmPrice">零售价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRetailPrice(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out decimal p_dcmPrice)
        {
            p_dcmPrice = 0;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.unitprice_mny from t_bse_medicine a where a.medicineid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    decimal.TryParse(dtbValue.Rows[0]["unitprice_mny"].ToString(), out p_dcmPrice);
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

        #region 检查是否住院药房使用
        /// <summary>
        /// 是否住院药房使用
        /// </summary>
        /// <param name="p_objPrincipal">
        /// <param name="p_strDrugStoreID">药房ID</param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsHospital(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            p_blnIsHospital = false;
            DataTable dtbTemp = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.medstoretype_int
	from t_bse_medstore a
 where a.medstoreid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParam = null;
                objHRPServ.CreateDatabaseParameter(1, out objParam);
                objParam[0].Value = p_strDrugStoreID;
                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParam);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    if (Convert.ToInt16(dtbTemp.Rows[0]["medstoretype_int"]) == 2)
                        p_blnIsHospital = true;
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

        #region 按药房的部门ID检查是否住院药房使用
        /// <summary>
        /// 按药房的部门ID是否住院药房使用
        /// </summary>
        /// <param name="p_objPrincipal">
        /// <param name="p_strDeptID">药房对应的部门ID</param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsHospitalByDeptId(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptID, out bool p_blnIsHospital)
        {
            p_blnIsHospital = false;
            DataTable dtbTemp = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.medstoretype_int
  from t_bse_medstore a
 where a.deptid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParam = null;
                objHRPServ.CreateDatabaseParameter(1, out objParam);
                objParam[0].Value = p_strDeptID;
                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParam);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    if (Convert.ToInt16(dtbTemp.Rows[0]["medstoretype_int"]) == 2)
                        p_blnIsHospital = true;
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
        #region 获取药品批发价
        /// <summary>
        /// 获取药品批发价
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dblWSP">批发价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWholeSalePrice(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out double p_dblWSP)
        {
            p_dblWSP = 0;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.wholesaleprice_mny from t_bse_medicine a where a.medicineid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    double.TryParse(dtbValue.Rows[0]["wholesaleprice_mny"].ToString(), out p_dblWSP);
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

        #region 杨镇伟09-10-30:添加查询内退单据状态
        /// <summary>
        /// 查询内退单据状态
        /// </summary>
        /// <param name="p_strSerId">单据号</param>
        /// <param name="p_strStatus">返回的状态</param>
        public long m_lngReturnInStroageStatus(string p_strSerId, out string p_strStatus)
        {
            long lngRes = 0;
            p_strStatus = null;
            DataTable dtResult = null;
            try
            {
                string strSQL = "select a.state_int from t_ms_instorage a where a.seriesid_int = ?";
                clsHRPTableService clsHrpSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                clsHrpSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strSerId;

                lngRes = clsHrpSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (dtResult != null && lngRes > 0)
                {
                    p_strStatus = dtResult.Rows[0]["state_int"].ToString();
                }

                clsHrpSvc.Dispose();
                clsHrpSvc = null;
            }
            catch (Exception objex)
            {
                clsLogText clsError = new clsLogText();
                bool blnRes = clsError.LogError(objex.ToString());
            }
            return lngRes;
        }
        #endregion

        #region 20090721:保存、删除、审核单据时，均判断是否新制状态
        /// <summary>
        /// 20090721:保存、删除、审核单据时，均判断是否新制状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intBillType"></param>
        /// <param name="p_strBillNo"></param>
        /// <param name="p_blnNewState"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckBillState(System.Security.Principal.IPrincipal p_objPrincipal, int p_intBillType, string p_strBillNo, out bool p_blnNewState)
        {
            p_blnNewState = false;
            long lngRes = 0;
            string strSQL = null;
            switch (p_intBillType)
            {
                case 1://药库入库单
                    strSQL = @"select a.state_int
  from t_ms_instorage a
 where a.instorageid_vchr = ?
   and a.state_int = 1";
                    break;

                case 2://药库出库单
                    strSQL = @"select a.status
  from t_ms_outstorage a
 where a.outstorageid_vchr = ?
   and a.status = 1";
                    break;

                case 3://药库盘点表
                    strSQL = @"select a.status
  from t_ms_storagecheck a
 where a.checkid_chr = ?
   and a.status = 1";
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
                objDPArr[0].Value = p_strBillNo;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtResult.Rows.Count > 0)
                {
                    p_blnNewState = Convert.ToInt16(m_dtResult.Rows[0][0]) == 1;
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
    }
}
