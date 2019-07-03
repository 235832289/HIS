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
    /// 药品类型显示设置
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMedicineTypeVisionmSetSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        /// <summary>
        /// 跟据药品类型ID获取是否录入批号和有效期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strmedicinetypeid">类型ID</param>
        /// <param name="p_objTypeVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTypeVisionm(System.Security.Principal.IPrincipal p_objPrincipal, string p_strmedicinetypeid, out clsMS_MedicineTypeVisionmSet p_objTypeVO)
        {
            //p_objTypeVO = null;
            p_objTypeVO = new clsMS_MedicineTypeVisionmSet();
            long lngRes = 0;
            try
            {
                string strSQL = @"select medicinetypeid_vchr, lotno_int, validperiod_int
  from t_ms_medicinetypevisionmset where medicinetypeid_vchr = ?";
                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strmedicinetypeid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (dtbValue != null && dtbValue.Rows.Count >0)
                {
                    p_objTypeVO.m_intLotno = Convert.ToInt16(dtbValue.Rows[0]["lotno_int"]);
                    p_objTypeVO.m_intValidperiod = Convert.ToInt16(dtbValue.Rows[0]["validperiod_int"]);

                }
                else
                {
                    p_objTypeVO.m_intLotno = 1;
                    p_objTypeVO.m_intValidperiod = 1;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;


        }

        [AutoComplete]
        public long m_lngGetAllMedicineTypeVisionm(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_objDtb)
        {
            p_objDtb = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.medicinetypename_vchr,
       b.medicinetypeid_chr,
       a.lotno_int,
       a.validperiod_int
  from t_ms_medicinetypevisionmset a
 right join t_aid_medicinetype b on a.medicinetypeid_vchr =
                                    b.medicinetypeid_chr";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_objDtb);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }


        [AutoComplete]
        public long m_lngSaverMedicineType(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_MedicineTypeVisionmSet[] objMedicineType)
        {
            long lngRes = 0;
            string strSQL;
            try
            {
                strSQL = @"delete from t_ms_medicinetypevisionmset";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.DoExcute(strSQL);

                if (objMedicineType == null || objMedicineType.Length == 0)
                {
                    return 1;
                }
                
                strSQL = @"insert into t_ms_medicinetypevisionmset (medicinetypeid_vchr,lotno_int,validperiod_int) values (?,?,?)";
                
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iOr = 0; iOr < objMedicineType.Length; iOr++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = objMedicineType[iOr].m_strMedicineTypeid;
                        objLisAddItemRefArr[1].Value = objMedicineType[iOr].m_intLotno;
                        objLisAddItemRefArr[2].Value = objMedicineType[iOr].m_intValidperiod;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);//往表增加记录

                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.Int32, DbType.Int32 };

                    object[][] objValues = new object[3][];

                    int intItemCount = objMedicineType.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iOr = 0; iOr < intItemCount; iOr++)
                    {
                        objValues[0][iOr] = objMedicineType[iOr].m_strMedicineTypeid;
                        objValues[1][iOr] = objMedicineType[iOr].m_intLotno;
                        objValues[2][iOr] = objMedicineType[iOr].m_intValidperiod;
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

        
    }
}
