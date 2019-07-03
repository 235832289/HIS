using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 标本反馈查询中间件
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQuerySampleBackSvc : clsMiddleTierBase
    {
        #region 获取样本反馈信息
        /// <summary>
        /// 获取样本反馈信息
        /// </summary>
        /// <param name="p_strFromDate">开始日期</param>
        /// <param name="p_strToDate">结束日期</param>
        /// <param name="p_strPatientName">病人姓名</param>
        /// <param name="p_strInHospitalNO">住院号</param>
        /// <param name="p_strAppDeptID">申请科室ID</param>
        /// <param name="p_dtResult">返回结果表</param>
        /// <returns>大于0成功，小于或等于0失败</returns>
        [AutoComplete]
        public long m_lngQuerySampleBack(string p_strFromDate, string p_strToDate, string p_strPatientName, string p_strInHospitalNO, string p_strAppDeptID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            string Sql = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                Sql = @"select a.samplebackid_chr,
                               a.feedback_date_date,
                               a.patient_name_vchr,
                               a.patient_inhospitalno_vchr,
                               a.bedno_chr,
                               a.sample_back_reason_vchr,
                               b.deptname_vchr,
                               a.sample_id_chr,
                               c.barcode_vchr              as barCode,
                               d.check_content_vchr        as checkContent
                          from t_opr_lis_sample_feedback a
                         inner join t_opr_lis_sample c
                            on a.sample_id_chr = c.sample_id_chr
                         inner join t_opr_lis_application d
                            on c.application_id_chr = d.application_id_chr
                          left outer join t_bse_deptdesc b
                            on a.appl_empid_chr = b.deptid_chr
                         where a.feedback_date_date between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                        order by a.sample_id_chr, a.feedback_date_date";

                ArrayList arrlParm = new ArrayList();
                arrlParm.Add(p_strFromDate);
                arrlParm.Add(p_strToDate);
                if (!string.IsNullOrEmpty(p_strPatientName))
                {
                    Sql += "and a.patient_name_vchr = ?";
                    arrlParm.Add(p_strPatientName);
                }
                if (!string.IsNullOrEmpty(p_strInHospitalNO))
                {
                    Sql += "and a.patient_inhospitalno_vchr = ?";
                    arrlParm.Add(p_strInHospitalNO);
                }
                if (!string.IsNullOrEmpty(p_strAppDeptID))
                {
                    Sql += "and a.appl_empid_chr = ?";
                    arrlParm.Add(p_strAppDeptID);
                }
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(arrlParm.Count, out objDPArr);
                for (int i = 0; i < arrlParm.Count; i++)
                {
                    objDPArr[i].Value = arrlParm[i];
                }
                lngRes = objHRPSvc.lngGetDataTableWithParameters(Sql, ref p_dtResult, objDPArr);

                if (p_dtResult != null)
                {
                    if (p_dtResult.Rows.Count > 0)
                    {
                        List<int> lstDelRowNo = new List<int>();
                        for (int i = 0; i < p_dtResult.Rows.Count - 1; i++)
                        {
                            for (int j = i + 1; j < p_dtResult.Rows.Count - 1; j++)
                            {
                                if (p_dtResult.Rows[j]["sample_id_chr"].ToString() == p_dtResult.Rows[i]["sample_id_chr"].ToString() && p_dtResult.Rows[j]["sample_back_reason_vchr"].ToString() == p_dtResult.Rows[i]["sample_back_reason_vchr"].ToString())
                                {
                                    if (lstDelRowNo.IndexOf(j) < 0) lstDelRowNo.Add(j);
                                }
                            }
                        }
                        if (lstDelRowNo.Count > 0)
                        {
                            for (int i = lstDelRowNo.Count - 1; i >= 0; i--)
                            {
                                p_dtResult.Rows.RemoveAt(lstDelRowNo[i]);
                            }
                        }

                    }
                    p_dtResult.Columns.Remove("sample_id_chr");
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                p_strAppDeptID = null;
                p_strFromDate = null;
                p_strInHospitalNO = null;
                p_strPatientName = null;
                p_strToDate = null;
                Sql = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
    }
}
