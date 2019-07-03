using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
//using Oracle.DataAccess.Client;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using System.Runtime.InteropServices;

namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAidDictionary : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        public clsAidDictionary()
        {
        }
        #endregion

        #region 查找医生职称
        /// <summary>
        /// 查找医生职称
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorDuty(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.jxcode_chr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr,
                                 a.dictid_chr, a.dictkind_chr, a.dictseqid_chr, a.dictdefinecode_vchr
                            from t_aid_dict a
                           where dictid_chr <> '0' and dictkind_chr = '21'
                        order by to_number (dictid_chr)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 保存门诊默认加收项目表
        /// <summary>
        /// 保存门诊默认加收项目表
        /// </summary>
        /// <param name="RecordsArr"></param>
        /// <param name="Flag">-1 只删除</param>
        /// <param name="PayTypeID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveOutPatientDefaultAddItem(ArrayList RecordsArr, int Flag, string PayTypeID)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (PayTypeID != "")
                {
                    SQL = @"delete from t_aid_outpatientdefaultadditem where paytypeid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = PayTypeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    if (Flag == -1)
                    {
                        return lngRes;
                    }
                }
               

                for (int i = 0; i < RecordsArr.Count; i++)
                {
                    clsOutPatientDefaultAddItem_VO DefaultAddItem_VO = RecordsArr[i] as clsOutPatientDefaultAddItem_VO;

                    SQL = @"insert into t_aid_outpatientdefaultadditem (paytypeid_chr, itemid_chr, qty_dec, regflag_int, recflag_int, dutyname_vchr, begintime_chr, endtime_chr,deptid_chr) 
                                                                values (?, ?, ?, ?, ?, ?, ?, ?,?)";

                    objHRPSvc.CreateDatabaseParameter(9, out ParamArr);                    
                    ParamArr[0].Value = DefaultAddItem_VO.PayTypeID;
                    ParamArr[1].Value = DefaultAddItem_VO.ItemID;
                    ParamArr[2].Value = DefaultAddItem_VO.Qty;
                    ParamArr[3].Value = DefaultAddItem_VO.RegFlag;
                    ParamArr[4].Value = DefaultAddItem_VO.RecFlag;
                    ParamArr[5].Value = DefaultAddItem_VO.DutyID;
                    ParamArr[6].Value = DefaultAddItem_VO.BeginTime;
                    ParamArr[7].Value = DefaultAddItem_VO.EndTime;
                    ParamArr[8].Value = DefaultAddItem_VO.DeptID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
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

        #region 获取门诊默认加收项目表
        /// <summary>
        /// 获取门诊默认加收项目表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PayTypeID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutPatientDefaultAddItem(out DataTable dt, string PayTypeID)
        {
            long lngRes = 0;
            string SQL = @"select a.paytypeid_chr, a.itemid_chr, a.qty_dec, a.regflag_int, a.recflag_int,
                               a.dutyname_vchr, a.begintime_chr, a.endtime_chr, b.itemname_vchr,
                               b.ipchargeflg_int, b.itemprice_mny,
                               round (b.itemprice_mny / b.packqty_dec, 4) as submoney,
                               b.itemspec_vchr, b.itemunit_chr, b.itemipunit_chr,a.deptid_chr
                          from t_aid_outpatientdefaultadditem a, t_bse_chargeitem b
                         where a.itemid_chr = b.itemid_chr(+) 
                           and a.paytypeid_chr = ?
                        order by a.begintime_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = PayTypeID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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
