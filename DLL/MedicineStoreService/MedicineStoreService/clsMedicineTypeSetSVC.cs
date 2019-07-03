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
    /// 药品类型设置
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMedicineTypeSetSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药品类型设置信息
        /// <summary>
        /// 获取药品类型设置信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objTypeVO">药品类型设置信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicinTypeSetInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsMS_MedicineTypeSetVO[] p_objTypeVO)
        {
            p_objTypeVO = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct medicinetypesetid, medicinetypesetname
  from t_ms_medicinetypeset
 order by medicinetypesetid";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_objTypeVO = new clsMS_MedicineTypeSetVO[intRowsCount];
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            p_objTypeVO[iRow] = new clsMS_MedicineTypeSetVO();
                            p_objTypeVO[iRow].m_intMedicineTypeSetID = Convert.ToInt32(dtbValue.Rows[iRow]["medicinetypesetid"]);
                            p_objTypeVO[iRow].m_strMedicineTypeSetName = dtbValue.Rows[iRow]["medicinetypesetname"].ToString();
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

        /// <summary>
        /// 获取药品类型设置信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSetID">设置ID</param>
        /// <param name="p_objTypeVO">药品类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicinTypeSetInfo(System.Security.Principal.IPrincipal p_objPrincipal,int p_intSetID, out clsMS_MedicineType_VO[] p_objTypeVO)
        {
            p_objTypeVO = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.medicinetypeid_chr, b.medicinetypename_vchr
  from t_ms_medicinetypeset a, t_aid_medicinetype b
 where a.medicinetypesetid = ?
   and a.medicinetypeid_chr = b.medicinetypeid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_intSetID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_objTypeVO = new clsMS_MedicineType_VO[intRowsCount];
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            p_objTypeVO[iRow] = new clsMS_MedicineType_VO();
                            p_objTypeVO[iRow].m_strMedicineTypeID_CHR = dtbValue.Rows[iRow]["medicinetypeid_chr"].ToString();
                            p_objTypeVO[iRow].m_strMedicineTypeName_VCHR = dtbValue.Rows[iRow]["medicinetypename_vchr"].ToString();
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

        #region 添加药品类型设置
        /// <summary>
        /// 添加药品类型设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objTypeVO">药品类型设置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedicneTypeSet(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_MedicineTypeSetVO p_objTypeVO)
        {
            if (p_objTypeVO == null || p_objTypeVO.m_strMedicineTypeIDArr == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_medicinetypeset
  (medicinetypesetid, medicinetypesetname, medicinetypeid_chr)
values
  (?, ?, ?)";

                string strGetMax = @"select max(medicinetypesetid)
  from t_ms_medicinetypeset";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (p_objTypeVO.m_intMedicineTypeSetID <= 0)
                {
                    DataTable dtbValue = null;
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strGetMax, ref dtbValue);
                    if (dtbValue == null || dtbValue.Rows.Count == 0)
                    {
                        p_objTypeVO.m_intMedicineTypeSetID = 1;
                    }
                    else
                    {
                        if (dtbValue.Rows[0][0] == DBNull.Value)
                        {
                            p_objTypeVO.m_intMedicineTypeSetID = 1;
                        }
                        else
                        {
                            p_objTypeVO.m_intMedicineTypeSetID = Convert.ToInt32(dtbValue.Rows[0][0]) + 1;
                        }
                    }
                }                

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;

                    for (int i = 0; i < p_objTypeVO.m_strMedicineTypeIDArr.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_objTypeVO.m_intMedicineTypeSetID;
                        objDPArr[1].Value = p_objTypeVO.m_strMedicineTypeSetName;
                        objDPArr[2].Value = p_objTypeVO.m_strMedicineTypeIDArr[i];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.String, DbType.String };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_objTypeVO.m_strMedicineTypeIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int i = 0; i < intItemCount; i++)
                    {
                        objValues[0][i] = p_objTypeVO.m_intMedicineTypeSetID;
                        objValues[1][i] = p_objTypeVO.m_strMedicineTypeSetName;
                        objValues[2][i] = p_objTypeVO.m_strMedicineTypeIDArr[i];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
                p_objTypeVO = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 修改药品类型设置
        /// <summary>
        /// 修改药品类型设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objTypeVO">药品类型设置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyMedicineTypeSet(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_MedicineTypeSetVO p_objTypeVO)
        {
            if (p_objTypeVO == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                lngRes = m_lngDeleteMedicineTypeSet(p_objPrincipal, p_objTypeVO.m_intMedicineTypeSetID);

                if (lngRes <= 0)
                {
                    return -1;
                }

                lngRes = m_lngAddNewMedicneTypeSet(p_objPrincipal, p_objTypeVO);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 删除指定药品类型设置
        /// <summary>
        /// 删除指定药品类型设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSetID">设置ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedicineTypeSet(System.Security.Principal.IPrincipal p_objPrincipal, int p_intSetID)
        {
            long lngRes = 0;
            try
            {
                string strDelSQL = @"delete from t_ms_medicinetypeset where medicinetypesetid = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_intSetID;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strDelSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 检查指定药品类型是否已设置至其它大类
        /// <summary>
        /// 检查指定药品类型是否已设置至其它大类
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strTypeID">药品基本类型ID</param>
        /// <param name="p_strSetName">若已设置，些返回已设置的大类名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasSetOtherType(System.Security.Principal.IPrincipal p_objPrincipal, string p_strTypeID, out string p_strSetName)
        {
            p_strSetName = string.Empty;
            long lngRes = 0;
            try
            {
                string strSQL = @"select medicinetypesetname
  from t_ms_medicinetypeset
 where medicinetypeid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strTypeID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null)
                {
                    if (dtbValue.Rows.Count > 0)
                    {
                        p_strSetName = dtbValue.Rows[0][0].ToString();
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
    }
}
