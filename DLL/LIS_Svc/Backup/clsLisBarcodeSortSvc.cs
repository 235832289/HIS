using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsLisBarcodeSortQuerySvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取病人基本信息
        /// <summary>
        /// 获取病人基本信息
        /// </summary>
        /// <param name="p_strPatientCardID">诊疗卡号</param>
        /// <param name="p_objPatientInfoVO">返回病人信息VO</param>
        /// <returns>>0成功</returns>
        [AutoComplete]
        public long m_lngQueryPatientInfo(string p_strPatientCardID, out clsPatientBaseInfo_VO p_objPatientInfoVO)
        {
            p_objPatientInfoVO = null;
            long lngRes = 0;
            clsHRPTableService objHRPSvc = null;
            string strSQL = null;
            try
            {
                strSQL = @"select a.lastname_vchr, a.sex_chr, a.birth_dat
  from t_bse_patient a, t_bse_patientcard c
 where a.patientid_chr = c.patientid_chr
   and c.patientcardid_chr = ?
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strPatientCardID;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = dtResult.Rows[0];
                    com.digitalwave.iCare.middletier.common.clsGetCurrentTime objSvc = new com.digitalwave.iCare.middletier.common.clsGetCurrentTime();
                    string strBirthDay = null;
                    DateTime dtTime = objSvc.m_mthGetCurrentDateTime();
                    p_objPatientInfoVO = new clsPatientBaseInfo_VO();
                    p_objPatientInfoVO.m_strPatientCardNO = p_strPatientCardID;
                    p_objPatientInfoVO.m_strName = drTemp["lastname_vchr"].ToString().Trim();
                    p_objPatientInfoVO.m_strSex = drTemp["sex_chr"].ToString().Trim();
                    strBirthDay = drTemp["birth_dat"].ToString().Trim();
                    p_objPatientInfoVO.m_strAge = com.digitalwave.Emr.StaticObject.clsConsts.m_strCalAge(strBirthDay, dtTime);
                }
            }
            catch(Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                p_strPatientCardID = null;
                strSQL = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取病人检验内容
        /// <summary>
        /// 获取病人检验内容
        /// </summary>
        /// <param name="p_strPatientCardID">诊疗卡号</param>
        /// <param name="p_strCheckContent">返回检验内容</param>
        /// <param name="p_objApplMainArr">返回申请单信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryPatientCheckContent(string p_strPatientCardID,string p_strFromDate,string p_strToDate, out string p_strCheckContent,out clsLisApplMainVO[] p_objApplMainArr)
        {
            long lngRes = 0;
            string strSQL = null;
            p_strCheckContent = null;
            p_objApplMainArr = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select a.application_id_chr,
                                   a.check_content_vchr,
                                   a.sample_type_id_chr,
                                   a.printed_num,
                                   c.sample_type_desc_vchr,
                                   d.barcode_vchr
                              from t_opr_lis_application a, t_aid_lis_sampletype c, t_opr_lis_sample d
                             where a.sample_type_id_chr = c.sample_type_id_chr(+)
                               and a.application_id_chr = d.application_id_chr
                               and a.patient_type_id_chr = '2'
                               and a.pstatus_int = 2
                               and a.patientcardid_chr = ?
                               and a.application_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                               and exists (select 1
                                      from t_opr_attachrelation b
                                     where a.application_id_chr = b.attachid_vchr
                                       and b.status_int = 1)
                            ";
                com.digitalwave.iCare.middletier.common.clsGetCurrentTime objSvc = new com.digitalwave.iCare.middletier.common.clsGetCurrentTime();
                DateTime dtTime = objSvc.m_mthGetCurrentDateTime();
               
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strPatientCardID;
                objDPArr[1].Value = p_strFromDate;
                objDPArr[2].Value = p_strToDate;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    List<clsLisApplMainVO> m_lstAppMain = new List<clsLisApplMainVO>();
                    clsLisApplMainVO objTemp = null;
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        drTemp = dtResult.Rows[i];
                        p_strCheckContent += "[" + drTemp["check_content_vchr"].ToString().Trim() +" "+ "样本:" + drTemp["sample_type_desc_vchr"].ToString().Trim() + "]" + ";" + "\r\n";
                        objTemp = new clsLisApplMainVO();
                        objTemp.m_strAPPLICATION_ID = drTemp["application_id_chr"].ToString().Trim();
                        objTemp.m_strSampleTypeID = drTemp["sample_type_id_chr"].ToString().Trim();
                        objTemp.m_intReportPrint = drTemp["printed_num"] != DBNull.Value ? Convert.ToInt32(drTemp["printed_num"].ToString().Trim()) : 0;
                        objTemp.m_strBarcode = drTemp["barcode_vchr"].ToString();
                        m_lstAppMain.Add(objTemp);
                    }
                    if(m_lstAppMain.Count>0)
                    {
                        p_objApplMainArr = m_lstAppMain.ToArray();
                    }
                }
                p_strFromDate = null;
                p_strToDate = null;
                dtResult.Dispose();
                dtResult = null;
            }
            catch(Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objHRPSvc = null;
                p_strPatientCardID = null;
            }
            return lngRes;
        }
        #endregion
    }
}
