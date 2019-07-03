using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 盘点药品顺序设置
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsCheckMedicineOrderSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取盘点药品顺序
        /// <summary>
        /// 获取盘点药品顺序
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strStoragePackID">货架ID</param>
        /// <param name="p_dtbData">数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckMedicineOrder(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strStoragePackID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select t.checkmedicineorder_chr,
       t.medicineid_chr,
       t.storagerackid_chr,
       t.storageid_chr,
       a.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr
  from t_ms_checkmedicineorder t
 inner join t_bse_medicine a on t.medicineid_chr = a.medicineid_chr
 where t.storageid_chr = ?
   and t.storagerackid_chr = ?
  order by checkmedicineorder_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStoragePackID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbData, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取盘点药品顺序(无货架)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbData">数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckMedicineOrderWithoutPack(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select t.checkmedicineorder_chr,
       t.medicineid_chr,
       t.storagerackid_chr,
       t.storageid_chr,
       a.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr
  from t_ms_checkmedicineorder t
 inner join t_bse_medicine a on t.medicineid_chr = a.medicineid_chr
 where t.storageid_chr = ?
  order by checkmedicineorder_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbData, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 新添盘点药品顺序设置
        /// <summary>
        /// 新添盘点药品顺序
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewCheckMedicineOrder(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            if (p_objOrderArr == null || p_objOrderArr.Length == 0)
            {
                return -1;
            }
            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_checkmedicineorder
  (checkmedicineorder_chr,
   medicineid_chr,
   storagerackid_chr,
   storageid_chr)
values
  (?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iOr = 0; iOr < p_objOrderArr.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_objOrderArr[iOr].m_strCHECKMEDICINEORDER_CHR;
                        objDPArr[1].Value = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objDPArr[2].Value = p_objOrderArr[iOr].m_strSTORAGERACKID_CHR;
                        objDPArr[3].Value = p_objOrderArr[iOr].m_strSTORAGEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };

                    object[][] objValues = new object[4][];

                    int intItemCount = p_objOrderArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = p_objOrderArr[iOr].m_strCHECKMEDICINEORDER_CHR;
                        objValues[1][iOr] = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objValues[2][iOr] = p_objOrderArr[iOr].m_strSTORAGERACKID_CHR;
                        objValues[3][iOr] = p_objOrderArr[iOr].m_strSTORAGEID_CHR;
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

        #region 修改盘点药品顺序
        /// <summary>
        /// 修改盘点药品顺序
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        [AutoComplete]
       
        public long m_lngModifyCheckOrder(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            if (p_objOrderArr == null || p_objOrderArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {

                string strSQL = @"update t_ms_checkmedicineorder
   set checkmedicineorder_chr = ?
 where medicineid_chr = ?
   and storagerackid_chr = ?
   and storageid_chr = ?";


                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iOr = 0; iOr < p_objOrderArr.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_objOrderArr[iOr].m_strCHECKMEDICINEORDER_CHR;
                        objDPArr[1].Value = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objDPArr[2].Value = p_objOrderArr[iOr].m_strSTORAGERACKID_CHR;
                        objDPArr[3].Value = p_objOrderArr[iOr].m_strSTORAGEID_CHR;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {

                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };


                    object[][] objValues = new object[4][];

                    int intItemCount = p_objOrderArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = p_objOrderArr[iOr].m_strCHECKMEDICINEORDER_CHR;
                        objValues[1][iOr] = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objValues[2][iOr] = p_objOrderArr[iOr].m_strSTORAGERACKID_CHR;
                        objValues[3][iOr] = p_objOrderArr[iOr].m_strSTORAGEID_CHR;
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

        /// <summary>
        /// 修改盘点药品顺序(无货架)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyCheckOrderWithoutPack(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            if (p_objOrderArr == null || p_objOrderArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_checkmedicineorder
   set checkmedicineorder_chr = ?
 where medicineid_chr = ?
   and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iOr = 0; iOr < p_objOrderArr.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_objOrderArr[iOr].m_strCHECKMEDICINEORDER_CHR;
                        objDPArr[1].Value = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objDPArr[2].Value = p_objOrderArr[iOr].m_strSTORAGEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_objOrderArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = p_objOrderArr[iOr].m_strCHECKMEDICINEORDER_CHR;
                        objValues[1][iOr] = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objValues[2][iOr] = p_objOrderArr[iOr].m_strSTORAGEID_CHR;
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

        #region 删除选定的盘点药品顺序        /// <summary>
        /// 删除选定的盘点药品顺序        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOrderArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedicineOrder(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            if (p_objOrderArr == null || p_objOrderArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"delete from t_ms_checkmedicineorder
 where medicineid_chr = ?
   and storagerackid_chr = ? 
   and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iOr = 0; iOr < p_objOrderArr.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        if (p_objOrderArr[iOr].m_strSTORAGERACKID_CHR.Length == 0)
                        { 
                            objDPArr[1].Value = " is null ";
                        }
                        else
                        {
                        objDPArr[1].Value = " = " + p_objOrderArr[iOr].m_strSTORAGERACKID_CHR;
                        }
                        objDPArr[2].Value = p_objOrderArr[iOr].m_strSTORAGEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_objOrderArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objValues[1][iOr] = p_objOrderArr[iOr].m_strSTORAGERACKID_CHR;
                        objValues[2][iOr] = p_objOrderArr[iOr].m_strSTORAGEID_CHR;
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

        /// <summary>
        /// 删除选定的盘点药品顺序(无货架)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOrderArr"></param>
        /// <returns></returns>
        public long m_lngDeleteMedicineOrderWithoutPack(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            if (p_objOrderArr == null || p_objOrderArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"delete from t_ms_checkmedicineorder
 where medicineid_chr = ?
   and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iOr = 0; iOr < p_objOrderArr.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objDPArr[1].Value = p_objOrderArr[iOr].m_strSTORAGEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_objOrderArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = p_objOrderArr[iOr].m_strMEDICINEID_CHR;
                        objValues[1][iOr] = p_objOrderArr[iOr].m_strSTORAGEID_CHR;
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
