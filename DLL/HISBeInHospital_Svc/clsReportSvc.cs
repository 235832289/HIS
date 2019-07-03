using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 住院进出转报表 -- 中间层
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsReportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 病人入院单统计报表
        /// <summary>
        /// 病人入院单统计报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtFromTime">开始时间</param>
        /// <param name="p_dtToTime">结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPatientInHospitalReport(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtFromTime, DateTime p_dtToTime,out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngPatientInHospitalReport");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT t2.areaid_chr, t4.empno_chr, t4.lastname_vchr, t3.deptname_vchr,
       t2.patientcount, t2.inpatientnotype_int
  FROM (SELECT   COUNT (t1.registerid_chr) AS patientcount, t1.areaid_chr,
                 t1.casedoctor_chr, t1.inpatientnotype_int
            FROM t_opr_bih_register t1
           WHERE t1.inpatient_dat BETWEEN ?
                                      AND ?
             AND t1.status_int = 1
        GROUP BY t1.areaid_chr, t1.casedoctor_chr, t1.inpatientnotype_int) t2,
       t_bse_deptdesc t3,
       t_bse_employee t4
 WHERE t2.areaid_chr = t3.deptid_chr AND t2.casedoctor_chr = t4.empid_chr(+)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_dtFromTime;
                objLisAddItemRefArr[1].Value = p_dtToTime;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
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

        #region 新生婴儿登记统计报表
        /// <summary>
        /// 新生婴儿登记统计报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtFromTime">开始时间</param>
        /// <param name="p_dtToTime">结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBabyRegisterReport(System.Security.Principal.IPrincipal p_objPrincipal,string p_strAreaID ,DateTime p_dtFromTime, DateTime p_dtToTime, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngBabyRegisterReport");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT t1.inpatientid_chr AS strcolumn0, t2.lastname_vchr AS strcolumn1,
       t3.deptname_vchr AS strcolumn2, t4.code_chr AS strcolumn3,
       t2.sex_chr AS strcolumn4, t2.birth_dat AS datcolumn0,
       t5.inpatientid_chr AS strcolumn5, t6.lastname_vchr AS strcolumn6,
       t1.pstatus_int AS deccolumn0
  FROM t_opr_bih_register t1,
       t_opr_bih_registerdetail t2,
       t_bse_deptdesc t3,
       t_bse_bed t4,
       t_opr_bih_register t5,
       t_opr_bih_registerdetail t6
 WHERE t1.status_int = 1
   AND t1.relateregisterid_chr IS NOT NULL";
            if (p_strAreaID != "0")
            {
                strSQL = strSQL + @"
   AND t1.areaid_chr = '" + p_strAreaID +"'";
            }
            strSQL = strSQL + @"
   AND t2.birth_dat BETWEEN ?
                            AND ?
   AND t1.registerid_chr = t2.registerid_chr
   AND t1.areaid_chr = t3.deptid_chr
   AND t1.relateregisterid_chr = t5.registerid_chr
   AND t5.registerid_chr = t6.registerid_chr
   AND t1.bedid_chr = t4.bedid_chr(+)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_dtFromTime;
                objLisAddItemRefArr[1].Value = p_dtToTime;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
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
