using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 系统参数Svc
    /// </summary>
    public class clsSysParamVOSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 构造
        [AutoComplete]
        private void ConstructVO(DataRow p_dtrSource, ref clsSysParamVO objReader)
        {
            objReader.m_intStatus = DBAssist.ToInt32(p_dtrSource["status_int"]);
            objReader.m_intSysCode = DBAssist.ToInt32(p_dtrSource["syscode_chr"]);
            objReader.m_strParamCode = p_dtrSource["parmcode_chr"].ToString();
            objReader.m_strParamDesc = p_dtrSource["parmdesc_vchr"].ToString();
            objReader.m_strParamValue = p_dtrSource["parmvalue_vchr"].ToString();
            objReader.m_strNote = p_dtrSource["note_vchr"].ToString();
        }

        [AutoComplete]
        private clsSysParamVO[] ConstructVOArr(DataTable dtbResult)
        {
            clsSysParamVO[] p_objResultArr = new clsSysParamVO[dtbResult.Rows.Count];
            for (int i = 0; i < p_objResultArr.Length; i++)
            {
                p_objResultArr[i] = new clsSysParamVO();
                ConstructVO(dtbResult.Rows[i], ref p_objResultArr[i]);
            }
            return p_objResultArr;
        } 
        #endregion

        #region INSERT

        [AutoComplete]
        public long m_lngInsert(clsSysParamVO objReader)
        {
            long lngRes = 0;
            string sql = @"
                              insert into t_bse_sysparm
                                          ( syscode_chr,
                                            parmcode_chr,
                                            parmdesc_vchr,
                                            parmvalue_vchr,
                                            status_int,
                                            note_vchr
                                           )
                                   values (?, ?, ?, ?, ?,?)
                          ";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            
            IDataParameter[] paramsArr =null;
            objHRPSvc.CreateDatabaseParameter(6,out paramsArr);
            paramsArr[0].Value = objReader.m_intSysCode;
            paramsArr[1].Value = objReader.m_strParamCode;
            paramsArr[2].Value = objReader.m_strParamDesc;
            paramsArr[3].Value = objReader.m_strParamValue;
            paramsArr[4].Value = objReader.m_intStatus;
            paramsArr[5].Value = objReader.m_strNote;


            try
            {
                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngRecEff, paramsArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region UPDATE

        [AutoComplete]
        public long m_lngUpdate(clsSysParamVO objReader)
        {
            long lngRes = 0;
            string sql = @"
                              update t_bse_sysparm
                                 set syscode_chr    = ?,
                                     parmdesc_vchr  = ?,
                                     parmvalue_vchr = ?,
                                     status_int     = ?,
                                     note_vchr      = ?
                               where parmcode_chr = ?
                         ";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] paramsArr = null;
            objHRPSvc.CreateDatabaseParameter(6, out paramsArr);
            paramsArr[0].Value = objReader.m_intSysCode;
            paramsArr[1].Value = objReader.m_strParamDesc;
            paramsArr[2].Value = objReader.m_strParamValue;
            paramsArr[3].Value = objReader.m_intStatus;
            paramsArr[4].Value = objReader.m_strNote;
            paramsArr[5].Value = objReader.m_strParamCode;

            try
            {
                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngRecEff, paramsArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }


        #endregion

        #region DELETE
        [AutoComplete]
        public long m_lngDelete(string paramCode)
        {
            long lngRes = 0;
            string sql = @"delete t_bse_sysparm where parmcode_chr=?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(1,out arrParams);
            arrParams[0].Value = paramCode;

            try
            {
                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngRecEff, arrParams);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region FIND

        /// <summary>
        /// 查找全部部门
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFind(out clsSysParamVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            string sql = @"
                            select syscode_chr,
                                   parmcode_chr,
                                   parmdesc_vchr,
                                   parmvalue_vchr,
                                   status_int,
                                   note_vchr
                              from t_bse_sysparm
                          ";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                DataTable dtbResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = ConstructVOArr(dtbResult);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion
    }
}
