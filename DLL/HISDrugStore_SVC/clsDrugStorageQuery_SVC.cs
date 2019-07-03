using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房库存查询类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDrugStorageQuery_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        
        #region 更新药房药品货架
        /// <summary>
        /// 更新药房药品货架
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_dicStorageRack">货架</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveStorageRack(System.Security.Principal.IPrincipal p_objPrincipal,Dictionary<string,string> p_dicStorageRack)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_storage_detail a set a.storagerackid_chr = ?
                                    where a.medicineid_chr = ? and a.lotno_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DbType[] dbTypes = new DbType[] { DbType.String, DbType.String,DbType.String };

                object[][] objValues = new object[3][];

                int intItemCount = p_dicStorageRack.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                
                int iRow = 0;
                foreach(KeyValuePair<string,string> kvp in p_dicStorageRack)
                {
                    objValues[0][iRow] = kvp.Value;
                    objValues[1][iRow] = kvp.Key.Substring(0,10);
                    objValues[2][iRow] = kvp.Key.Substring(10);
                    iRow++;
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

        #region 保存可供标志
        /// <summary>
        /// 保存可供标志
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_dtbModify">需要修改数量的数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveProvide(System.Security.Principal.IPrincipal p_objPrincipal, DataTable p_dtbModify)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_storage_detail a set canprovide_int = ? where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Int64 };

                object[][] objValues = new object[2][];

                int intItemCount = p_dtbModify.Rows.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }

                for (int i1 = 0; i1 < p_dtbModify.Rows.Count; i1++)
                {
                    objValues[0][i1] = Convert.ToDouble(p_dtbModify.Rows[i1]["canprovide_int"]);
                    objValues[1][i1] = Convert.ToInt64(p_dtbModify.Rows[i1]["seriesid_int"]);
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

        #region 保存缺药和停用,货架
        /// <summary>
        /// 保存缺药和停用
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_dtbModify">需要修改缺药和停用</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveStorageSet(System.Security.Principal.IPrincipal p_objPrincipal, DataTable p_dtbModify)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_storage a
	 set a.noqtyflag_int = ?,a.ifstop_int = ?,a.storagerackid_chr = ?
 where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DbType[] dbTypes = new DbType[] { DbType.Int16, DbType.Int16,DbType.String, DbType.Int64 };

                object[][] objValues = new object[4][];

                int intItemCount = p_dtbModify.Rows.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }

                for (int i1 = 0; i1 < p_dtbModify.Rows.Count; i1++)
                {
                    objValues[0][i1] = Convert.ToInt16(p_dtbModify.Rows[i1]["noqtyflag_int"].ToString());
                    objValues[1][i1] = Convert.ToInt16(p_dtbModify.Rows[i1]["ifstop_int"].ToString());
                    objValues[2][i1] = Convert.ToString(p_dtbModify.Rows[i1]["storagerackid_chr"]);
                    objValues[3][i1] = Convert.ToInt64(p_dtbModify.Rows[i1]["seriesid_int"]);
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

        #region 保存库存明细和修改记录
        /// <summary>
        /// 保存库存明细和修改记录
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_dtbModify">需要修改数量的数据</param>
        /// <param name="p_strMakerID">修改者ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveAmount(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageHistory_VO p_objHistory)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_storage_detail a
	 set a.opavailablegross_num = ?,a.ipavailablegross_num = ? where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_objHistory.m_dblNEWOPAVAILABLEGROSS_NUM;
                objDPArr[1].Value = p_objHistory.m_dblNEWIPAVAILABLEGROSS_NUM;
                objDPArr[2].Value = p_objHistory.m_lngSERIESID2_INT;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                //保存修改可用库存的log
                if (lngRes > 0)
                {
                    strSQL = @"insert into t_ds_storagedetail_history a
  (a.seriesid_int,
   a.seriesid2_int,
   a.drugstoreid_chr,
   a.ipavailablegross_num,
   a.newipavailablegross_num,
   a.ipunit_chr,
   a.opavailablegross_num,
   a.newopavailablegross_num,
   a.opunit_chr,
   a.modifydate_dat,
   a.modifyuserid_chr,a.medicineid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, sysdate, ?,?)";
                    clsDS_Public_Supported_SVC objPubSvc = new clsDS_Public_Supported_SVC();
                    long[] lngSEQArr = null;
                    objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_T_DS_STORAGEDETAIL_HISTORY", 1, out lngSEQArr);
                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(11, out objDPArr);
                    objDPArr[0].Value = lngSEQArr[0];
                    objDPArr[1].Value = p_objHistory.m_lngSERIESID2_INT;
                    objDPArr[2].Value = p_objHistory.m_strDRUGSTOREID_CHR;
                    objDPArr[3].Value = p_objHistory.m_dblIPAVAILABLEGROSS_NUM;
                    objDPArr[4].Value = p_objHistory.m_dblNEWIPAVAILABLEGROSS_NUM;
                    objDPArr[5].Value = p_objHistory.m_strIPUNIT_CHR;
                    objDPArr[6].Value = p_objHistory.m_dblOPAVAILABLEGROSS_NUM;
                    objDPArr[7].Value = p_objHistory.m_dblNEWOPAVAILABLEGROSS_NUM;
                    objDPArr[8].Value = p_objHistory.m_strOPUNIT_CHR;
                    objDPArr[9].Value = p_objHistory.m_strMODIFYUSERID_CHR;
                    objDPArr[10].Value = p_objHistory.m_strMEDICINEID_CHR;

                    lngEff = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

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
