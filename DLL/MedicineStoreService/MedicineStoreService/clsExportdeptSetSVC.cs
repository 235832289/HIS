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
    /// 领用部门设置
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
   public class clsExportdeptSetSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
   {
       #region old code
       /*
       /// <summary>
        /// 获取医院所有部门        /// </summary>
        /// <param name="p_dtbData"></param>
        /// <returns></returns>
        [AutoComplete]
       public long m_lngGetExportdeptAll(out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr
  from t_bse_deptdesc
 where status_int = 1
 order by deptname_vchr";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbData);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }


        /// <summary>
        /// 获取领用部门
        /// </summary>
        /// <param name="p_dtbData"></param>
        /// <returns></returns>
        [AutoComplete]
       public long m_lngGetExportdept(out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select e.exportdept_chr deptid_chr, d.deptname_vchr
  from t_ms_exportdept e
  left join t_bse_deptdesc d on e.exportdept_chr = d.deptid_chr
 order by e.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbData);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 保存 王小飞 2007-7-4 
        /// </summary>
        /// <param name="p_objPrincipal">安全</param>
        /// <param name="p_objExportDeptArr">数据层的映射表ExportDept</param>
        /// <returns></returns>
        [AutoComplete]
       public long m_lngSaverExportdept(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_ExportDept[] p_objExportDeptArr)
        {
     
            long lngRes = 0;
            string strSQL;
            try
            {
                strSQL = @"delete from t_ms_exportdept";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.DoExcute(strSQL);

                if (p_objExportDeptArr == null || p_objExportDeptArr.Length == 0)
                {
                    return 1;
                }

                strSQL = @"insert into t_ms_exportdept (seriesid_int,exportdept_chr) values (?,?)";

                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iOr = 0; iOr < p_objExportDeptArr.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_objExportDeptArr[iOr].m_strSeriesID;
                        objLisAddItemRefArr[1].Value = p_objExportDeptArr[iOr].m_strExportDept;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);//往表增加记录
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_objExportDeptArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = p_objExportDeptArr[iOr].m_strSeriesID;
                        objValues[1][iOr] = p_objExportDeptArr[iOr].m_strExportDept;

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
         */
       #endregion

       #region 获取医院所有部门

       /// <summary>
       /// 获取医院所有部门
       /// </summary>
       /// <param name="p_dtbData"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetExportdeptAll(out DataTable p_dtbData)
       {
           p_dtbData = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr
  from t_bse_deptdesc
 where status_int = 1
 order by deptname_vchr";
               clsHRPTableService objHRPServ = new clsHRPTableService();
               lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbData);
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

       #region 获取领用部门
       /// <summary>
       /// 获取领用部门
       /// </summary>
       /// <param name="p_dtbData"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetExportdept(out DataTable p_dtbData)
       {
           p_dtbData = null;
           long lngRes = 0;

           try
           {
               string strSQL = @"select e.exportdept_chr deptid_chr, d.deptname_vchr, e.storageflag_int
  from t_ms_exportdept e
  left join t_bse_deptdesc d on e.exportdept_chr = d.deptid_chr
 order by e.seriesid_int";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbData);
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

       #region m_mthGetOutOrInStoreDept
       /// <summary>
       /// m_mthGetOutOrInStoreDept
       /// </summary>
       /// <param name="p_dtbData"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_mthGetOutOrInStoreDept(bool p_blnIsDrugStore, out DataTable p_dtbOutOrInStore)
       {
           p_dtbOutOrInStore = null;
           long lngRes = 0;
           StringBuilder strSQL = new StringBuilder("");
           try
           {
               if (p_blnIsDrugStore)
               {
                   strSQL.Append(@"select 'F' checkbox_chr,0 numberno,b.deptid_chr,b.deptname_vchr,b.pycode_chr,b.code_vchr
                                      from t_ms_exportdept a,t_bse_deptdesc b
                                     where a.exportdept_chr=b.deptid_chr
                                       and (a.storageflag_int=1 or a.storageflag_int=2)");
               }
               else
               {
                   strSQL.Append(@"select 'F' checkbox_chr,0 numberno,b.deptid_chr,b.deptname_vchr,b.pycode_chr,b.code_vchr
                                      from t_ms_exportdept a,t_bse_deptdesc b
                                     where a.exportdept_chr=b.deptid_chr
                                       and (a.storageflag_int=0 or a.storageflag_int=2)");
               }
               clsHRPTableService objHRPServ = new clsHRPTableService();
               lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL.ToString(), ref p_dtbOutOrInStore);

               objHRPServ.Dispose();
               objHRPServ = null;

               if (p_dtbOutOrInStore.Rows.Count > 0)
               {
                   for (int iOr = 0; iOr < p_dtbOutOrInStore.Rows.Count; iOr++)
                   {
                       p_dtbOutOrInStore.Rows[iOr]["numberno"] = Convert.ToString(iOr + 1);
                   }
                   p_dtbOutOrInStore.AcceptChanges();
               }

           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       }
       #endregion m_mthGetOutOrInStoreDept

       #region 库房名称
       /// <summary>
       /// 库房名称
       /// </summary>
       /// <param name="p_blnIsDrugStore"></param>
       /// <param name="p_dtbStoreName"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_mthGetStoreName(bool p_blnIsDrugStore, out DataTable p_dtbStoreName)
       {
           p_dtbStoreName = new DataTable();
           long lngRes = 0;
           StringBuilder strSQL = new StringBuilder("");
           try
           {
               if (p_blnIsDrugStore)
               {
                   strSQL.Append(@"select t.deptid_chr,t.medstorename_vchr from t_bse_medstore t");
               }
               else
               {
                   strSQL.Append(@"select distinct t.deptid_chr,t.medicineroomname medstorename_vchr from t_ms_medicinestoreroomset t");
               }
               clsHRPTableService objHRPServ = new clsHRPTableService();
               lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL.ToString(), ref p_dtbStoreName);

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

       #region 所属库房的部门
       /// <summary>
       /// 所属库房的部门
       /// </summary>
       /// <param name="strStoreid"></param>
       /// <param name="dtDept"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_mthSearchDept(string strStoreid, out DataTable dtDept)
       {
           dtDept = new DataTable();
           long lngRes = 0;
           StringBuilder strSQL = new StringBuilder("");
           try
           {
               strSQL.Append(@"select a.instoragedept_chr deptid_chr from t_aid_outindeptrelation a where a.outstoragedept_chr=?");

               clsHRPTableService objHRPServ = new clsHRPTableService();

               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = strStoreid;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtDept, objDPArr);

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

       #region 修改库房标志的记录 不用
       /// <summary>
       /// 修改库房标志的记录

       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_dicStorageFlag"></param>
       /// <returns></returns>
       //        [AutoComplete]
       //       public long m_lngUpdateStorageFlag(System.Security.Principal.IPrincipal p_objPrincipal, Dictionary<Int32, Int16> p_dicStorageFlag)
       //        {
       //            long lngRes = 0;
       //            try
       //            {
       //                string strSQL = @"update t_ms_exportdept a set a.storageflag_int = ?
       //                                    where a.seriesid_int = ?";

       //                clsHRPTableService objHRPServ = new clsHRPTableService();
       //                DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.Int16};

       //                object[][] objValues = new object[2][];

       //                int intItemCount = p_dicStorageFlag.Count;
       //                for (int j = 0; j < objValues.Length; j++)
       //                {
       //                    objValues[j] = new object[intItemCount];//初始化


       //                }

       //                int iRow = 0;
       //                foreach (KeyValuePair<Int32, Int16> kvp in p_dicStorageFlag)
       //                {
       //                    objValues[0][iRow] = kvp.Value;
       //                    objValues[1][iRow] = kvp.Value;
       //                    iRow++;
       //                }

       //                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
       //            }
       //            catch (Exception objEx)
       //            {
       //                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
       //                bool blnRes = objLogger.LogError(objEx);
       //            }
       //            return lngRes;
       //        }
       #endregion

       #region 保存 王小飞 2007-7-4
       /// <summary>
       /// 保存 王小飞 2007-7-4 
       /// </summary>
       /// <param name="p_objPrincipal">安全</param>
       /// <param name="p_objExportDeptArr">数据层的映射表ExportDept</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngSaverExportdept(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_ExportDept[] p_objExportDeptArr)
       {

           long lngRes = 0;
           string strSQL;
           try
           {
               strSQL = @"delete from t_ms_exportdept";
               clsHRPTableService objHRPServ = new clsHRPTableService();
               objHRPServ.DoExcute(strSQL);

               if (p_objExportDeptArr == null || p_objExportDeptArr.Length == 0)
               {
                   return 1;
               }

               strSQL = @"insert into t_ms_exportdept (seriesid_int,exportdept_chr,storageflag_int) values (?,?,?)";

               long lngEff = -1;
               if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
               {
                   IDataParameter[] objLisAddItemRefArr = null;
                   for (int iOr = 0; iOr < p_objExportDeptArr.Length; iOr++)
                   {
                       objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                       objLisAddItemRefArr[0].Value = p_objExportDeptArr[iOr].m_strSeriesID;
                       objLisAddItemRefArr[1].Value = p_objExportDeptArr[iOr].m_strExportDept;
                       objLisAddItemRefArr[2].Value = p_objExportDeptArr[iOr].m_strFlag;

                       lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);//往表增加记录

                   }
               }
               else
               {
                   DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                   object[][] objValues = new object[3][];

                   int intItemCount = p_objExportDeptArr.Length;
                   for (int j = 0; j < objValues.Length; j++)
                   {
                       objValues[j] = new object[intItemCount];//初始化

                   }

                   for (int iOr = 0; iOr < intItemCount; iOr++)
                   {
                       objValues[0][iOr] = p_objExportDeptArr[iOr].m_strSeriesID;
                       objValues[1][iOr] = p_objExportDeptArr[iOr].m_strExportDept;
                       objValues[2][iOr] = p_objExportDeptArr[iOr].m_strFlag;

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

       #region m_lngSaveData
       /// <summary>
       /// m_lngSaveData
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strStoreid"></param>
       /// <param name="p_objDeptArr"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngSaveData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreid, clsOutOrInStorageDeptSet[] p_objDeptArr)
       {
           long lngRes = 0;
           string strSQL;
           try
           {
               //if (p_objDeptArr == null || p_objDeptArr.Length == 0)
               //{
               //    return lngRes;
               //}
               long lngdelEff = -1;
               strSQL = @"delete from t_aid_outindeptrelation where outstoragedept_chr=?";
               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strStoreid;
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngdelEff, objDPArr);
               if (p_objDeptArr.Length == 0)
               {
                   objHRPServ.Dispose();
                   objHRPServ = null;
                   return lngRes;
               }

               strSQL = @"insert into t_aid_outindeptrelation(outstoragedept_chr,instoragedept_chr,orderno_int) values(?,?,?)";

               long lngEff = -1;
               if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
               {
                   IDataParameter[] objLisAddItemRefArr = null;
                   for (int iOr = 0; iOr < p_objDeptArr.Length; iOr++)
                   {
                       objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                       objLisAddItemRefArr[0].Value = p_strStoreid;
                       objLisAddItemRefArr[1].Value = p_objDeptArr[iOr].strDeptid;
                       objLisAddItemRefArr[2].Value = iOr + 1;

                       lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);//往表增加记录


                   }
               }
               else
               {
                   DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                   object[][] objValues = new object[3][];

                   int intItemCount = p_objDeptArr.Length;
                   for (int j = 0; j < objValues.Length; j++)
                   {
                       objValues[j] = new object[intItemCount];//初始化


                   }

                   for (int iOr = 0; iOr < intItemCount; iOr++)
                   {
                       objValues[0][iOr] = p_strStoreid;
                       objValues[1][iOr] = p_objDeptArr[iOr].strDeptid;
                       objValues[2][iOr] = iOr + 1;

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
   }
     
}
