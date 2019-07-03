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
    /// 药品毛利率设置
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMedicineGrossProfitRateSetSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药品毛利率设置
        /// <summary>
        /// 获取药品毛利率设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGrossProfitRateSet(System.Security.Principal.IPrincipal p_objPrincipal, out  clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            p_objRateArr = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select b.medicinetypeid_chr, b.medicinetypename_vchr, a.grossprofitrate
  from t_aid_medicinetype b
  left outer join t_ms_grossprofitrateset a on a.medicinetypeid_chr =
                                               b.medicinetypeid_chr
 order by b.medicinetypeid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);

                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount <= 0)
                    {
                        return -1;
                    }

                    p_objRateArr = new clsMS_GrossProfitRateSet_VO[intRowsCount];
                    DataRow drCurrent = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_objRateArr[iRow] = new clsMS_GrossProfitRateSet_VO();
                        drCurrent = dtbValue.Rows[iRow];
                        p_objRateArr[iRow].m_strMEDICINETYPEID_CHR = drCurrent["medicinetypeid_chr"].ToString();
                        p_objRateArr[iRow].m_strMEDICINETYPENAME = drCurrent["medicinetypename_vchr"].ToString();
                        if (drCurrent["grossprofitrate"] != DBNull.Value)
                        {
                            p_objRateArr[iRow].m_dblGROSSPROFITRATE = Convert.ToDouble(drCurrent["grossprofitrate"]);
                            p_objRateArr[iRow].m_blnIsInGrossProfitRateSet = true;
                        }
                        else
                        {
                            p_objRateArr[iRow].m_dblGROSSPROFITRATE = 15.00d;
                            p_objRateArr[iRow].m_blnIsInGrossProfitRateSet = false;
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

        #region 修改药品毛利率设置
        /// <summary>
        /// 修改药品毛利率设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyGrossProfitRateSet(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            if (p_objRateArr == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_grossprofitrateset
   set grossprofitrate = ?
 where medicinetypeid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objRateArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_objRateArr[iRow].m_dblGROSSPROFITRATE;
                        objDPArr[1].Value = p_objRateArr[iRow].m_strMEDICINETYPEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] {DbType.Double,DbType.String };
                    object[][] objValues = new object[2][];

                    int intItemCount = p_objRateArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objRateArr[iRow].m_dblGROSSPROFITRATE;
                        objValues[1][iRow] = p_objRateArr[iRow].m_strMEDICINETYPEID_CHR;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 添加药品毛利率设置
        /// <summary>
        /// 添加药品毛利率设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddGrossProfitRateSet(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            if (p_objRateArr == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_grossprofitrateset
  (grossprofitrate,medicinetypeid_chr)
values
  (?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objRateArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_objRateArr[iRow].m_dblGROSSPROFITRATE;
                        objDPArr[1].Value = p_objRateArr[iRow].m_strMEDICINETYPEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String };
                    object[][] objValues = new object[2][];

                    int intItemCount = p_objRateArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objRateArr[iRow].m_dblGROSSPROFITRATE;
                        objValues[1][iRow] = p_objRateArr[iRow].m_strMEDICINETYPEID_CHR;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
