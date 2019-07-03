using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 质控管理数据服务类
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsTmdQCLisServ : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region  通过设备编号获取仪器的质控项目对应的检验项目
        /// <summary>
        /// 通过设备编号获取仪器的质控项目对应的检验项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceQCCheckItemByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID, out clsLISCheckItemNode[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strDeviceID))
                return lngRes;

            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCLisServ", "m_lngGetDeviceQCCheckItemByID");
            objPrivilege = null;
            if (lngRes <= 0)
                return lngRes;

            try
            {
                string strSQL = @"select a.check_item_id_chr, a.rptno_chr
  from t_bse_lis_check_item a
 inner join t_bse_lis_check_item_dev_item b on b.check_item_id_chr =
                                               a.check_item_id_chr
 inner join t_bse_lis_device_check_item c on c.device_check_item_id_chr =
                                             b.device_check_item_id_chr
                                         and c.device_model_id_chr =
                                             b.device_model_id_chr
                                         and c.is_qc_item_int = 1
 inner join t_bse_lis_device d on d.device_model_id_chr =
                                  c.device_model_id_chr
                              and d.deviceid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDeviceID;
                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ = null;
                objDPArr = null;

                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    clsLISCheckItemNode objTemp = null;
                    int iRowCount = dtResult.Rows.Count;
                    p_objResultArr = new clsLISCheckItemNode[iRowCount];

                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        objTemp = new clsLISCheckItemNode();
                        objTemp.strID = drTemp["check_item_id_chr"].ToString().Trim();
                        objTemp.strName = drTemp["rptno_chr"].ToString().Trim();

                        p_objResultArr[iRow] = objTemp;
                    }

                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
                objLogger = null;
            }
            finally
            {
                p_strDeviceID = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取质控样本结果数据，采用固定检验样本编号
        /// <summary>
        /// 获取质控样本结果数据，采用固定检验样本编号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSampleID">仪器样本编号</param>
        /// <param name="p_strStartDat">开始时间</param>
        /// <param name="p_strEndDat">结束时间</param>
        /// <param name="p_intBatchSeqArr">质控批序号</param>
        /// <param name="p_objQCDataArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceQCDataBySampleID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleID,
            string p_strStartDat, string p_strEndDat, int[] p_intBatchSeqArr, out clsLisQCDataVO[] p_objQCDataArr)
        {
            p_objQCDataArr = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strSampleID) || string.IsNullOrEmpty(p_strStartDat) || string.IsNullOrEmpty(p_strEndDat) || p_intBatchSeqArr == null || p_intBatchSeqArr.Length <= 0)
                return lngRes;

            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsTmdQCLisServ", "m_lngGetDeviceQCDataBySampleID");
            objPrivilege = null;
            if (lngRes <= 0)
                return lngRes;

            try
            {
                StringBuilder strSQLBuilder = new StringBuilder(512);
                strSQLBuilder.Append(@"select t.result_vchr, t.check_dat, d.qcbatch_seq_int
  from t_opr_lis_result t
 inner join t_bse_lis_device_check_item a on a.device_check_item_name_vchr =
                                             t.device_check_item_name_vchr
                                         and a.is_qc_item_int = 1
                                         and a.has_graph_result_int = 0
 inner join t_bse_lis_check_item_dev_item b on b.device_check_item_id_chr =
                                               a.device_check_item_id_chr
                                           and b.device_model_id_chr =
                                               a.device_model_id_chr
 inner join t_bse_lis_device c on c.device_model_id_chr =
                                  b.device_model_id_chr
 inner join t_opr_lis_qcbatch d on d.check_item_id_chr =
                                   b.check_item_id_chr
 where t.device_sampleid_chr = ?
   and t.deviceid_chr = c.deviceid_chr
   and t.check_dat between ? and ?
   and (d.qcbatch_seq_int = ?");

                for (int index = 1; index < p_intBatchSeqArr.Length; index++)
                {
                    strSQLBuilder.Append(" or d.qcbatch_seq_int = ?");
                }
                strSQLBuilder.Append(")");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(p_intBatchSeqArr.Length + 3, out objDPArr);

                objDPArr[0].Value = p_strSampleID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = Convert.ToDateTime(p_strStartDat);
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = Convert.ToDateTime(p_strEndDat);

                for (int index = 0; index < p_intBatchSeqArr.Length; index++)
                {
                    objDPArr[3 + index].Value = p_intBatchSeqArr[index];
                }

                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQLBuilder.ToString(), ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    int iRowCount = dtResult.Rows.Count;
                    List<clsLisQCDataVO> lstQCData = new List<clsLisQCDataVO>();
                    clsLisQCDataVO objTemp = null;
                    DataRow drTemp = null;
                    double dblTemp = 0d;
                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        drTemp = dtResult.Rows[iRow];
                        if (double.TryParse(drTemp["result_vchr"].ToString(), out dblTemp) && drTemp["check_dat"] != DBNull.Value)
                        {
                            objTemp = new clsLisQCDataVO();
                            objTemp.m_dlbResult = dblTemp;
                            objTemp.m_datQCDate = Convert.ToDateTime(Convert.ToDateTime(drTemp["check_dat"]).ToString("yyyy-MM-dd"));
                            objTemp.m_intSeq = -1;
                            int.TryParse(drTemp["qcbatch_seq_int"].ToString(), out objTemp.m_intQCBatchSeq);
                            objTemp.m_intConcentrationSeq = -1;

                            lstQCData.Add(objTemp);
                        }
                    }
                    if (lstQCData.Count > 0)
                        p_objQCDataArr = lstQCData.ToArray();
                }

            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
                objLogger = null;
            }
            finally
            {
                p_intBatchSeqArr = null;
                p_strEndDat = null;
                p_strSampleID = null;
                p_strStartDat = null;
            }
            return lngRes;
        }
        #endregion

    }
}
