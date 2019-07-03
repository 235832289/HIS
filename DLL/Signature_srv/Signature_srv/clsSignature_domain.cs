using System;
using iCareData;
using System.Data;

namespace com.digitalwave.Emr.Signature_srv
{
    /// <summary>
    /// Signature_domain 的摘要说明。
    /// 签名常用值Domain层
    /// create by tfzhang at 2005-12-26 18:00
    /// </summary>
    public class clsSignature_domain
    {
        #region 根据key盘返回指定员工基本信息
        /// <summary>
        /// 根据key盘返回指定员工信息
        /// 前提条件：员工已与key关联
        /// </summary>
        /// <param name="strEmpKey">key</param>
        /// <param name="p_objEmployeeBase">返回最小信息集</param>
        /// <returns></returns>
        public long m_lngGetMinEmpByKey(string strEmpKey, out clsEmrEmployeeBase_VO p_objEmployeeBase)
        {
            p_objEmployeeBase = null;
            long lngRes = 0;
            clsSignature_srv objSvc = new clsSignature_srv();
            try
            {
                //key为空返回
                if (strEmpKey == null || strEmpKey.Trim().Length == 0)
                    return lngRes;
                DataTable dtbResult = new DataTable();
                lngRes = objSvc.m_lngGetEmpByKey(null, strEmpKey, out dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objEmployeeBase = new clsEmrEmployeeBase_VO();
                    //员工基本信息（最小集合）
                    p_objEmployeeBase.m_strEMPID_CHR = dtbResult.Rows[0]["empid_chr"].ToString();
                    p_objEmployeeBase.m_strLASTNAME_VCHR = dtbResult.Rows[0]["lastname_vchr"].ToString();
                    p_objEmployeeBase.m_strTECHNICALRANK_CHR = dtbResult.Rows[0]["technicalrank_chr"].ToString();
                    p_objEmployeeBase.m_strEMPNO_CHR = dtbResult.Rows[0]["empno_chr"].ToString();
                    p_objEmployeeBase.m_strPYCODE_VCHR = dtbResult.Rows[0]["pycode_chr"].ToString();
                    p_objEmployeeBase.m_strEMPKEY_VCHR = dtbResult.Rows[0]["digitalsign_dta"].ToString();
                    p_objEmployeeBase.m_strEMPPWD_VCHR = dtbResult.Rows[0]["psw_chr"].ToString();
                    p_objEmployeeBase.m_strLEVEL_CHR = dtbResult.Rows[0]["technicallevel_chr"].ToString();
                    p_objEmployeeBase.m_intSTATUS_INT = 1;
                }
            }

            catch (Exception exp)
            {
                p_objEmployeeBase = new clsEmrEmployeeBase_VO();
                string strErrMessage = exp.Message;
            }
            finally
            {
                //objSvc.Dispose();
            }
            //返回
            return lngRes;
        }
        #endregion

        #region 根据流水号获取签名集合
        /// <summary>
        /// 根据流水号获取签名集合
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSequence">流水号</param>
        /// <param name="p_dtbValue">返回列表</param>
        /// <returns></returns>
        public long m_lngGetSignBySequence(long p_lngSequence, out clsEmrSigns_VO[] p_objSignsArr)
        {
            //初始化
            long lngRes = 0;
            p_objSignsArr = null;
            clsSignature_srv objSvc = new clsSignature_srv();
            try
            {
                DataTable dtbValue = new DataTable();
                lngRes = objSvc.m_lngGetSignBySequence(null, p_lngSequence, out dtbValue);
                int intSignCount = dtbValue.Rows.Count;
                //从DataTable.Rows中获取结果
                if (lngRes > 0)
                {
                    p_objSignsArr = new clsEmrSigns_VO[intSignCount];
                    for (int i = 0; i < intSignCount; i++)
                    {
                        p_objSignsArr[i] = new clsEmrSigns_VO();
                        p_objSignsArr[i].objEmployee = new clsEmrEmployeeBase_VO();
                        p_objSignsArr[i].objEmployee.m_strEMPID_CHR = dtbValue.Rows[i]["empid_vchr"].ToString();
                        p_objSignsArr[i].objEmployee.m_strLASTNAME_VCHR = dtbValue.Rows[i]["lastname_vchr"].ToString();
                        p_objSignsArr[i].objEmployee.m_strEMPNO_CHR = dtbValue.Rows[i]["empno_chr"].ToString();
                        p_objSignsArr[i].objEmployee.m_strTECHNICALRANK_CHR = dtbValue.Rows[i]["technicalrank_chr"].ToString();
                        p_objSignsArr[i].objEmployee.m_strLEVEL_CHR = dtbValue.Rows[i]["technicallevel_chr"].ToString();
                        p_objSignsArr[i].objEmployee.m_strEMPPWD_VCHR = dtbValue.Rows[i]["psw_chr"].ToString();
                        p_objSignsArr[i].objEmployee.m_strEMPKEY_VCHR = dtbValue.Rows[i]["digitalsign_dta"].ToString();
                        p_objSignsArr[i].objEmployee.m_strPYCODE_VCHR = dtbValue.Rows[i]["pycode_chr"].ToString();
                        p_objSignsArr[i].objEmployee.m_intSTATUS_INT = dtbValue.Rows[i]["status_int"] == DBNull.Value ? 1 : int.Parse(dtbValue.Rows[i]["status_int"].ToString());
                        p_objSignsArr[i].controlName = dtbValue.Rows[i]["CAGETORY_VCHR"].ToString();
                        p_objSignsArr[i].m_strFORMID_VCHR = dtbValue.Rows[i]["FORMNAME_VCHR"].ToString();
                        p_objSignsArr[i].m_strREGISTERID_CHR = dtbValue.Rows[i]["REGISTERID_VCHR"].ToString();
                    }
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                //objSvc.Dispose();
            }
            //返回
            return lngRes;
        }
        #endregion
    }
}
