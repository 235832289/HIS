using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.HIS
{

    #region 住院-医保身份对应表Svc
		
    /// <summary>
    /// 住院-医保身份对应表Svc
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled=true)]
    public class clsYBDefPayTypeSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 构  造

        private clsYBDefPayTypeVO ConstructVO(DataRow dtRow)
        {
            clsYBDefPayTypeVO ybDefPayTypeVO = new clsYBDefPayTypeVO();
            ybDefPayTypeVO.m_strPayTypeId = dtRow["paytypeid_chr"].ToString();
            ybDefPayTypeVO.m_strPayTypeId = dtRow["jslx"].ToString();
            ybDefPayTypeVO.m_strPayTypeId = dtRow["rylb"].ToString();

            return ybDefPayTypeVO;
        }

        private clsYBDefPayTypeVO[] ConstructArrayVO(DataTable table)
        {
            if (IsTableNull(table))
            {
                return new clsYBDefPayTypeVO[0];
            }

            int rowCount = table.Rows.Count;
            clsYBDefPayTypeVO[] arrYBDefPayType = new clsYBDefPayTypeVO[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                arrYBDefPayType[i] = ConstructVO(table.Rows[i]);
            }

            return arrYBDefPayType;
        }

        #endregion

        #region FindAll
      
        /// <summary>
        /// 返回所有的关系
        /// </summary>
        /// <param name="arrYBDefPayType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindAll(out clsYBDefPayTypeVO[] arrYBDefPayType)
        {
            long lngRes = 0;
            DataTable table = null;
            arrYBDefPayType = null;

            string sql = @"
                                select paytypeid_chr,jslx,rylb from t_opr_bih_ybdefpaytype
                          ";
            try
            {
                clsHRPTableService hrpService = new clsHRPTableService();
                lngRes = hrpService.lngGetDataTableWithoutParameters(sql, ref table);
                arrYBDefPayType = ConstructArrayVO(table);

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        [AutoComplete]
        public long m_lngFind(string payTypeId,out clsYBDefPayTypeVO ybDefPayType)
        {
            long lngRes = 0;
            DataTable table = null;
            ybDefPayType = null;

            string sql = @"
                               select paytypeid_chr, jslx, rylb
                                 from t_opr_bih_ybdefpaytype
                                where paytypeid_chr = ?
                          ";
            try
            {
                clsHRPTableService hrpService = new clsHRPTableService();
                IDataParameter[] objParams = null;
                hrpService.CreateDatabaseParameter(1, out objParams);
                objParams[0].Value = payTypeId;

                lngRes=hrpService.lngGetDataTableWithParameters(sql, ref table, objParams);

                if (IsTableNull(table))
                {
                    ybDefPayType = null;
                }
                else 
                {
                    ybDefPayType = ConstructVO(table.Rows[0]);
                }
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngDelete(clsYBDefPayTypeVO objVo)
        {
            long lngRes = 0;
            long lngAffter = 0;
            string strSQL = @"delete from t_opr_bih_ybdefpaytype where paytypeid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = objVo.m_strPayTypeId;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffter, param);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngUpdate(clsYBDefPayTypeVO objVo)
        {
            long lngRes = 0;
            string SQL = @"update t_opr_bih_ybdefpaytype
                               set jslx = ?,
                                   rylb = ?
                             where paytypeid_chr = ? ";
            long lngAffter=0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(3, out param);
                param[0].Value = objVo.m_strYBJslx;
                param[1].Value = objVo.m_strYBRylb;
                param[2].Value = objVo.m_strPayTypeId;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffter, param);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 插入新记录
        /// </summary>
        /// <param name="ybDefPayTypeVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsert(clsYBDefPayTypeVO ybDefPayTypeVO) 
        {
            long lngRes = 0;
            DataTable table = null;

            string sql = @"
                               insert into t_opr_bih_ybdefpaytype(paytypeid_chr, jslx, rylb) values (?, ?, ?)
                          ";
            try
            {
                clsHRPTableService hrpService = new clsHRPTableService();
                IDataParameter[] objParams = null;
                hrpService.CreateDatabaseParameter(3, out objParams);
                objParams[0].Value = ybDefPayTypeVO.m_strPayTypeId;
                objParams[1].Value = ybDefPayTypeVO.m_strYBJslx;
                objParams[2].Value = ybDefPayTypeVO.m_strYBRylb;

                lngRes = hrpService.lngGetDataTableWithParameters(sql, ref table, objParams);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        private bool IsTableNull(DataTable table)
        {
            return table == null || table.Rows.Count == 0;
        }

    } 
	#endregion

    #region  患者身份表Svc

    /// <summary>
    /// 患者身份表Svc
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsPatientPayTypeSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        /// <summary>
        /// 获取所有医保对应的患者类型
        /// </summary>
        /// <param name="arrPatientType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetYBPatientPayType(out clsPatientType_VO[] arrPatientType)
        {
            long lngRes = 0;
            DataTable table = null;
            arrPatientType = null;

            string sql = @"
                               select paytypeid_chr, 
                                      paytypename_vchr
                                 from t_bse_patientpaytype
                                where (internalflag_int = 1 or internalflag_int = 2)
                          ";
            try
            {
                clsHRPTableService hrpService = new clsHRPTableService();
                lngRes = hrpService.lngGetDataTableWithoutParameters(sql, ref table);

                if (IsTableNull(table))
                {
                    arrPatientType = null;
                }
                else
                {
                    //arrPatientType = ConstructArrayVO(table);
                    int intRow = table.Rows.Count;
                    arrPatientType = new clsPatientType_VO[intRow];

                    DataRow dtRow = null;
                    for (int i1 = 0; i1 < intRow; i1++)
                    {
                        dtRow = table.Rows[i1];
                        arrPatientType[i1] = new clsPatientType_VO();
                        arrPatientType[i1].m_strPayTypeID = dtRow["paytypeid_chr"].ToString();
                        arrPatientType[i1].m_strPayTypeName = dtRow["paytypename_vchr"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取患者类型
        /// </summary>
        /// <param name="patientPayTypeId"></param>
        /// <param name="patientType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientPayType(string patientPayTypeId, out clsPatientType_VO patientType)
        {
            long lngRes = 0;
            DataTable table = null;
            patientType = null;

            string sql = @" select paytypeid_chr, paytypename_vchr
                              from t_bse_patientpaytype
                             where (internalflag_int = 1 or internalflag_int = 2)
                               and paytypeid_chr = ?
                          ";
            try
            {
                clsHRPTableService hrpService = new clsHRPTableService();
                IDataParameter[] objParams = null;
                hrpService.CreateDatabaseParameter(1, out objParams);
                objParams[0].Value = patientPayTypeId;

                lngRes = hrpService.lngGetDataTableWithParameters(sql, ref table, objParams);

                if (IsTableNull(table))
                {
                    patientType = null;
                }
                else
                {
                    patientType = ConstructVO(table.Rows[0]);
                }
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #region 构  造

        private clsPatientType_VO ConstructVO(DataRow dtRow)
        {
            clsPatientType_VO patientType = new clsPatientType_VO();
            patientType.m_strPayTypeID = dtRow["paytypeid_chr"].ToString();
            patientType.m_strPayTypeName = dtRow["paytypename_vchr"].ToString();

            return patientType;
        }

        private clsPatientType_VO[] ConstructArrayVO(DataTable table)
        {
            if (IsTableNull(table))
            {
                return new clsPatientType_VO[0];
            }

            int rowCount = table.Rows.Count;
            clsPatientType_VO[] arrPatientType = new clsPatientType_VO[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                arrPatientType[i] = ConstructVO(table.Rows[i]);
            }

            return arrPatientType;
        }

        #endregion

        private bool IsTableNull(DataTable table)
        {
            return table == null || table.Rows.Count == 0;
        }

    } 

    #endregion
}
