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
    /// 库房设置
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMedicineStoreroomSetSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 添加库房记录.

        /// <summary>
        /// 添加库房记录.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineStoreroom">新增库房记录.</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedicineStoreInfo(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_MedicineStoreroom_VO p_objMedicineStoreroom)
        {
            if (p_objMedicineStoreroom == null)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strGetMax = @"select max(medicineroomid) maxid from t_ms_medicinestoreroomset";
                //2008.5.14 wuchongkun+shortname_chr
                string strSQL = @"insert into t_ms_medicinestoreroomset
  (medicineroomid, medicineroomname, medicinetypeid_chr,deptid_chr,shortname_chr)
values
  (?, ?, ?,?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                if (string.IsNullOrEmpty(p_objMedicineStoreroom.m_strMedicineRoomID_VCHR))
                {
                    DataTable dtbValue = null;
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strGetMax, ref dtbValue);
                    if (dtbValue == null || dtbValue.Rows.Count == 0)
                    {
                        p_objMedicineStoreroom.m_strMedicineRoomID_VCHR = "0001";
                    }
                    else
                    {
                        if (dtbValue.Rows[0][0] == DBNull.Value)
                        {
                            p_objMedicineStoreroom.m_strMedicineRoomID_VCHR = "0001";
                        }
                        else
                        {
                            p_objMedicineStoreroom.m_strMedicineRoomID_VCHR = (Convert.ToInt32(dtbValue.Rows[0][0]) + 1).ToString("0000");
                        }
                    }
                }

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;

                    for (int i = 0; i < p_objMedicineStoreroom.m_strMedicineTypeID_CHR.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].Value = p_objMedicineStoreroom.m_strMedicineRoomID_VCHR;
                        objDPArr[1].Value = p_objMedicineStoreroom.m_strMedicineRoomName_VCHR;
                        objDPArr[2].Value = p_objMedicineStoreroom.m_strMedicineTypeID_CHR[i];
                        objDPArr[3].Value = p_objMedicineStoreroom.m_strDEPTID_CHR;
                        //+m_strMidicineRommShortName_chr 2008.5.14 wuchongkun
                        objDPArr[4].Value = p_objMedicineStoreroom.m_strMidicineRommShortName_CHR;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String,DbType.String,DbType .String };

                    object[][] objValues = new object[5][];

                    int intItemCount = p_objMedicineStoreroom.m_strMedicineTypeID_CHR.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int i = 0; i < intItemCount; i++)
                    {
                        objValues[0][i] = p_objMedicineStoreroom.m_strMedicineRoomID_VCHR;
                        objValues[1][i] = p_objMedicineStoreroom.m_strMedicineRoomName_VCHR;
                        objValues[2][i] = p_objMedicineStoreroom.m_strMedicineTypeID_CHR[i];
                        objValues[3][i] = p_objMedicineStoreroom.m_strDEPTID_CHR;
                        //+ wuchongkun.2008.5.14
                        objValues[4][i] = p_objMedicineStoreroom.m_strMidicineRommShortName_CHR;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 添加库房记录.

        /// <summary>
        /// 添加库房记录.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineStoreroom">新增库房记录.</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewMedStoreSetInfo(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_MedicineStoreroom_VO p_objMedicineStoreroom)
        {
            if (p_objMedicineStoreroom == null)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"   insert into t_ds_medstoreset
  (medstoreid, medstorename, medicinetypeid_chr)
values
  (?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                object[][] objValues = new object[3][];

                int intItemCount = p_objMedicineStoreroom.m_strMedicineTypeID_CHR.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int i = 0; i < intItemCount; i++)
                {
                    objValues[0][i] = p_objMedicineStoreroom.m_strMedicineRoomID_VCHR;
                    objValues[1][i] = p_objMedicineStoreroom.m_strMedicineRoomName_VCHR;
                    objValues[2][i] = p_objMedicineStoreroom.m_strMedicineTypeID_CHR[i];
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 删除库房记录.

        /// <summary>
        /// 删除库房记录.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strStoreID">指定要删除的库房记录.</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedicineStoreInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strStoreID)
        {
            if (strStoreID == null)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"delete from t_ms_medicinestoreroomset where medicineroomid = ?";


                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = strStoreID;
                long lngEff = -1;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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

        #region 删除库房记录.

        /// <summary>
        /// 删除库房记录.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strStoreID">指定要删除的库房记录.</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMedStoreSetInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strStoreID)
        {
            if (strStoreID == null)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"   delete from t_ds_medstoreset where medstoreid = ?";


                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = strStoreID;
                long lngEff = -1;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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