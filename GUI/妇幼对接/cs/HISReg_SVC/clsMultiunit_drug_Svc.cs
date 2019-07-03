using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using System.Data;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// SVC
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMultiunit_drug_Svc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsMultiunit_drug_Svc()
        {
        }
        #endregion

        #region 获取药品信息
        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="p_dtMedicineList">药品信息列表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTableMedicineList(ref DataTable p_dtMedicineList)
        {
            long lngRes = -1;

            string strSQL = @"select a.itemid_chr,
       a.itemcode_vchr,
       a.itempycode_chr,
       a.itemwbcode_chr,
       a.itemname_vchr,
       a.itemcommname_vchr,
       a.itemengname_vchr,
       b.medspec_vchr,
       b.productorid_chr
  from t_bse_chargeitem a, t_bse_medicine b
 where a.itemsrcid_vchr = b.medicineid_chr
   and b.multiunitflag_int = 1
   and a.ifstop_int = 0";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtMedicineList);
                int x = p_dtMedicineList.Rows.Count;
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药品Id获取相应的单位列表
        /// <summary>
        /// 根据药品Id获取相应的单位列表
        /// </summary>
        /// <param name="p_strMedId">药品Id</param>
        /// <param name="p_dtMultiUnit"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTableMultiUnitList(string p_strMedId, out DataTable p_dtMultiUnit)
        {
            long lngRes = -1;
            p_dtMultiUnit = null;

            string strSQL = @"select a.itemid_chr, a.unit_vchr, a.package_dec,
                                       case
                                          when a.curruseflag_int = 0
                                             then '否'
                                          else '是'
                                       end as curruseflag_int,
                                       case
                                          when a.status_int = 0
                                             then '停用'
                                          else '启用'
                                       end as status_int
                                  from t_bse_itemmultiunit_drug a
                                 where a.itemid_chr = ? ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strMedId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtMultiUnit, ParamArr);
                
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 删除单位信息

        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMultiUnit(clsMultiunit_drug_VO p_objVO)
        {
            string strSQL = @"delete from t_bse_itemmultiunit_drug a
                               where a.itemid_chr = ?
                                      and a.unit_vchr= ?
                                        and a.package_dec= ?";
                                 
            long lngRes = -1;
            long lngAffter = -1;
            //DataTable dtbValue = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);

                ParamArr[0].Value = p_objVO.m_strItemId ;
                ParamArr[1].Value = p_objVO.m_strUnit;
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_objVO.m_intPackage;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffter, ParamArr);
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbValue, ParamArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 根据索引查询单位
        /// <summary>
        /// 根据索引查询单位
        /// </summary>
        /// <param name="strSeledMedId">药品ID </param>
        /// <param name="p_strUnit">单位名称</param>
        /// <param name="p_intPackage_Dec">数量</param>
        /// <param name="p_CurruseFlag_Int">是否当前单位标记</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec, int p_CurruseFlag_Int )
        {
            bool blnIsFind = false;

            string strSQL = @"select a.itemid_chr, a.unit_vchr,a.status_int
                                  from t_bse_itemmultiunit_drug a
                                 where a.itemid_chr = ?
                                   and a.unit_vchr = ?
                                   and a.package_dec = ?
                                   and a.curruseflag_int = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strSeledMedId;
                ParamArr[1].Value = p_strUnit;
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_intPackage_Dec;
                ParamArr[3].DbType = DbType.Int16;
                ParamArr[3].Value = p_CurruseFlag_Int; 
                
                DataTable dtValue = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, ParamArr);
                if (dtValue != null && dtValue.Rows.Count > 0)
                {
                    blnIsFind = true;
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnIsFind;
        }
        #endregion

        #region 根据索引查询是否为当前使用单位
        /// <summary>
        /// 根据索引查询是否为当前使用单位
        /// </summary>
        /// <param name="strSeledMedId">药品ID </param>
        /// <param name="p_strUnit">单位名称</param>
        /// <param name="p_intPackage_Dec">数量</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec)
        {
            bool blnIsFind = false;

            string strSQL = @"select a.itemid_chr,a.unit_vchr 
                                    from  t_bse_itemmultiunit_drug a
                                    where a.itemid_chr= ?
		                            and a.unit_vchr= ?
                                    and a.package_dec=?
                                    and a.curruseflag_int=1";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = strSeledMedId;
                ParamArr[1].Value = p_strUnit;
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_intPackage_Dec;

                DataTable dtValue = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, ParamArr);
                if (dtValue != null && dtValue.Rows.Count > 0)
                {
                    blnIsFind = true;
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnIsFind;
        }
        #endregion

        #region 添加药品单位信息
        /// <summary>
        /// 添加药品单位信息
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddMultiUnit(clsMultiunit_drug_VO p_objVO)
        {
            string strSQL = @"insert into t_bse_itemmultiunit_drug a
            (a.itemid_chr, a.unit_vchr, a.package_dec, a.curruseflag_int,
             status_int )
     values (?, ?, ?, ?,
             ? ) ";
            long lngRes = -1;
            long recordAffect = 0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);

                ParamArr[0].Value = p_objVO.m_strItemId.Trim();
                ParamArr[1].Value = p_objVO.m_strUnit.Trim();
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_objVO.m_intPackage;
                ParamArr[3].DbType = DbType.Int16;
                ParamArr[3].Value = p_objVO.m_intCurruseFlag_Int;
                ParamArr[4].Value = p_objVO.m_intStauts;
                
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref recordAffect, ParamArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更新单位信息
        /// <summary>
        /// 更新单位信息
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <param name="strMedicineId"></param>
        /// <param name="strUnitName"></param>
        /// <param name="intPackAge"></param>
        /// <param name="intCurruseFlag"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateMultiUnit(clsMultiunit_drug_VO p_objVO, string strMedicineId, string strUnitName,int intPackAge, int intCurruseFlag,int intStatus)
        {
            long lngRes = -1;
            string strSQL = @"update   t_bse_itemmultiunit_drug
                                   set unit_vchr = ?,
                                       package_dec = ?,
                                       curruseflag_int = ?,
                                       status_int = ?
                                 where itemid_chr = ? and unit_vchr = ? and package_dec = ? ";
            long lngAffect = -1;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out ParamArr);
                ParamArr[0].Value = p_objVO.m_strUnit;
                ParamArr[1].DbType = DbType.Int16;
                ParamArr[1].Value = p_objVO.m_intPackage;
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_objVO.m_intCurruseFlag_Int;
                ParamArr[3].Value = intStatus;
                ParamArr[4].Value = strMedicineId;
                ParamArr[5].Value = strUnitName;
                ParamArr[6].DbType = DbType.Int16;
                ParamArr[6].Value = intPackAge;
                //ParamArr[6].DbType = DbType.Int16;
                //ParamArr[6].Value = intCurruseFlag;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffect, ParamArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 把所有单位设为非当前单位
        /// <summary>
        /// 把所有单位设为非当前单位
        /// </summary>
        /// <param name="p_strMedicineId"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAllCurruseFlag_0ByItemId(string p_strMedicineId)
        {
            long lngRes = -1;
            string strSQL = @"update t_bse_itemmultiunit_drug 
                                    set curruseflag_int=0
                                    where itemid_chr=?";
            long lngAffect = -1;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strMedicineId;
               
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffect, ParamArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion
    }
}
