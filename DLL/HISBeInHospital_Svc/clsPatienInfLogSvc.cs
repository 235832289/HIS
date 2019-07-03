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
    /// 
    /// </summary>
    /// [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsPatienInfLogSvc: com.digitalwave.iCare.middletier.clsMiddleTierBase
    {       
        #region 增加资料变动记录
        /// <summary>
        /// 增加资料变动记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long AddPatienInfLog(System.Security.Principal.IPrincipal p_objPrincipal, clsPatientInfLog p_objRecord)
        {
            long lngRes = 0;
          
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBedManageSvc", "m_lngAddNewBed");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = 0;
            
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"INSERT INTO T_OPR_BIH_PATIENTINF_LOG 
                                        (SEQ_INT, OPERATE_DATE, REGISTERID_CHR, OPERATORID_CHR,
                                         DETAIL_VCHR, DESC_VCHR)
                                 VALUES (SEQ_PATIENTINF_LOG.nextval, sysdate, ?, ?, 
                                         ?, ? )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.registerId;
                objLisAddItemRefArr[1].Value = p_objRecord.operatorId;
                objLisAddItemRefArr[2].Value = p_objRecord.detail;
                objLisAddItemRefArr[3].Value = p_objRecord.desc;
              
                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 根据日期查找资料变动日志
        /// <summary>
        /// 根据日期查找资料变动日志
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtStartDate"></param>
        /// <param name="p_dtEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetLogByDate(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtStartDate, DateTime p_dtEndDate, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetBIHPatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select   a.registerid_chr,
                                       a.inpatientid_chr,
                                       a.areaid_chr,
                                       b.lastname_vchr,
                                       c.deptname_vchr,
                                       d.lastname_vchr,
                                       d.empno_chr,
                                       e.operatorid_chr,
                                       e.operate_date,
                                       e.detail_vchr,
                                       e.desc_vchr
                                       
                                from t_opr_bih_register a,
                                     t_opr_bih_registerdetail b,
                                     t_bse_deptdesc c,
                                     t_bse_employee d,
                                     t_opr_bih_patientinf_log e
                                where a.registerid_chr = b.registerid_chr and
                                      a.areaid_chr = c.deptid_chr and 
                                      a.registerid_chr = e.registerid_chr and
                                      e.operatorid_chr = d.empid_chr and
                                      (e.operate_date between ? and ? ) 
                                order by a.areaid_chr,a.inpatientid_chr";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_dtStartDate;
                objLisAddItemRefArr[1].Value = p_dtEndDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);


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
