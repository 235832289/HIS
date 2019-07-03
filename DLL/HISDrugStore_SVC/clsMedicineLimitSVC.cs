using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 多单位维护使用
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMedicineLimitSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
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

                ParamArr[0].Value = p_objVO.m_strItemId;
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
        public long m_lngUpdateMultiUnit(clsMultiunit_drug_VO p_objVO, string strMedicineId, string strUnitName, int intPackAge, int intCurruseFlag, int intStatus)
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

