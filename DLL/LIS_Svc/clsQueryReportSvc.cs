using System;
using System.Data;
using System.EnterpriseServices;
using System.Security.Principal;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQueryReportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 构造函数
        public clsQueryReportSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

        #region 根据条件组合查询报表源数据
        [AutoComplete]
        public long m_lngGetWorkloadReportByCondition(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strFromDat, string p_strToDat, string p_strCheckItemID, string p_strApplEmpID, string p_strApplDeptID,
            string p_strReprotorID, string p_strPatientTypeID, string p_strCheckCategoryID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsReportSvc", "m_lngGetWorkloadReportByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            //			string strSQL = @"SELECT b.sample_type_id_chr, b.appl_empid_chr, b.appl_deptid_chr,
            //									 b.patient_type_chr, c.reportor_id_chr, a.check_item_id_chr,
            //									 i.check_item_name_vchr, h.dictname_vchr AS patient_type_dec_vchr,
            //									 g.sample_type_desc_vchr as sampletype_vchr, f.deptname_vchr AS appl_deptid_dec_chr,
            //									 e.lastname_vchr AS appl_empid_dec_chr,
            //									 d.lastname_vchr AS reportor_id_dec_chr
            //								FROM t_opr_lis_check_result a,
            //									 t_opr_lis_sample b,
            //									 t_opr_lis_app_report c,
            //									 t_bse_employee d,
            //									 t_bse_employee e,
            //									 t_bse_deptdesc f,
            //									 t_aid_lis_sampletype g,
            //									 t_aid_dict h,
            //									 t_bse_lis_check_item i
            //							   WHERE a.sample_id_chr = b.sample_id_chr
            //								 AND b.application_id_chr = c.application_id_chr
            //								 AND a.check_item_id_chr = i.check_item_id_chr
            //								 AND b.patient_type_chr = h.dictid_chr
            //								 AND h.dictkind_chr = '61'
            //								 AND b.sample_type_id_chr = g.sample_type_id_chr
            //								 AND f.deptid_chr = b.appl_deptid_chr
            //								 AND e.empid_chr = b.appl_empid_chr
            //								 AND d.empid_chr = c.reportor_id_chr
            //								 AND a.status_int > 0
            //								 AND b.status_int = 5";
            //			if(p_strFromDat != "" && p_strToDat != "")
            //			{
            //				strSQL += " AND b.CHECK_DATE_DAT BETWEEN TO_DATE('"+p_strFromDat+"','yyyy-mm-dd hh24:mi:ss) AND TO_DATE('"+p_strToDat+"','yyyy-mm-dd hh24:mi:ss)";
            //			}
            //			if(p_strCheckItemID != "")
            //			{
            //				strSQL += " AND a.CHECK_ITEM_ID_CHR = '"+p_strCheckItemID+"'";
            //			}
            //			if(p_strApplEmpID != "")
            //			{
            //				strSQL += " AND b.APPL_EMPID_CHR = '"+p_strApplEmpID+"'";
            //			}
            //			if(p_strApplDeptID != "")
            //			{
            //				strSQL += " AND b.APPL_DEPTID_CHR = '"+p_strApplDeptID+"'";
            //			}
            //			if(p_strReprotorID != "")
            //			{
            //				strSQL += " AND c.REPORTOR_ID_CHR = '"+p_strReprotorID+"'";
            //			}
            //			if(p_strPatientTypeID != "")
            //			{
            //				strSQL += " AND b.PATIENT_TYPE_CHR = '"+p_strPatientTypeID+"'";
            //			}
            string strSQLFront = @"SELECT aa.chkcount AS item_count, f.sample_type_desc_vchr AS sampletype_vchr,
									 d.lastname_vchr AS appl_empid_dec_chr,
									 e.deptname_vchr AS appl_deptid_dec_chr,
									 g.dictname_vchr AS patient_type_dec_vchr, aa.reportor_id_chr,
									 aa.check_item_id_chr, h.check_item_name_vchr,
									 i.lastname_vchr AS reportor_id_dec_chr, aa.sample_type_id_chr,
									 aa.appl_empid_chr, aa.appl_deptid_chr, aa.patient_type_chr
								FROM (SELECT   a.check_item_id_chr, COUNT (a.check_item_id_chr) chkcount,
											   b.sample_type_id_chr, b.appl_empid_chr, b.appl_deptid_chr,
											   b.patient_type_chr, c.reportor_id_chr
										  FROM t_opr_lis_check_result a,
											   t_opr_lis_sample b,
											   t_opr_lis_app_report c
										 WHERE a.sample_id_chr = b.sample_id_chr
										   AND b.application_id_chr = c.application_id_chr
										   AND a.status_int > 0
										   AND b.status_int = 6";
            string strSQLEnd = @"     GROUP BY a.check_item_id_chr,
											   b.sample_type_id_chr,
											   b.appl_empid_chr,
											   b.appl_deptid_chr,
											   b.patient_type_chr,
											   c.reportor_id_chr) aa,
									t_bse_employee d,
									t_bse_deptdesc e,
									t_aid_lis_sampletype f,
									t_aid_dict g,
									t_bse_lis_check_item h,
									t_bse_employee i,
									t_bse_lis_check_category j
							  WHERE aa.appl_empid_chr = d.empid_chr
							    AND aa.appl_deptid_chr = e.deptid_chr
								AND aa.sample_type_id_chr = f.sample_type_id_chr
								AND aa.check_item_id_chr = h.check_item_id_chr
								AND aa.reportor_id_chr = i.empid_chr
								AND h.check_category_id_chr = j.check_category_id_chr
								AND (aa.patient_type_chr = g.dictid_chr AND g.dictkind_chr = '61')";
            string strCondition = "";
            if (p_strFromDat != "" && p_strToDat != "")
            {
                strCondition = " AND b.CHECK_DATE_DAT BETWEEN TO_DATE('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss')";
            }
            if (p_strCheckItemID != "")
            {
                strCondition = " AND a.CHECK_ITEM_ID_CHR = '" + p_strCheckItemID + "'";
            }
            if (p_strApplEmpID != "")
            {
                strCondition = " AND b.APPL_EMPID_CHR = '" + p_strApplEmpID + "'";
            }
            if (p_strApplDeptID != "")
            {
                strCondition = " AND b.APPL_DEPTID_CHR = '" + p_strApplDeptID + "'";
            }
            if (p_strReprotorID != "")
            {
                strCondition = " AND c.REPORTOR_ID_CHR = '" + p_strReprotorID + "'";
            }
            if (p_strPatientTypeID != "")
            {
                strCondition = " AND b.PATIENT_TYPE_CHR = '" + p_strPatientTypeID + "'";
            }
            string strSQL = strSQLFront + strCondition + strSQLEnd;
            if (p_strCheckCategoryID != "")
            {
                strSQL += " AND j.check_category_id_chr = '" + p_strCheckCategoryID + "'";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        #region Get
        [AutoComplete]
        public long m_lngGetReportObject(IPrincipal p_objPrincipal, string p_strApplicationID, out clsReportObject p_objReportObject)
        {
            long lngRes = 0;
            p_objReportObject = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsReportSvc", "m_lngGetReportObject");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select *
								from t_opr_lis_report_object
							   where application_id_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
            objDPArr[0].Value = p_strApplicationID;

            DataTable dtbResult = new DataTable();
            lngRes = 0;
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
            if (lngRes > 0 && dtbResult != null)
            {
                p_objReportObject = new clsReportObject();
                p_objReportObject.strApplicationID = p_strApplicationID;
                p_objReportObject.bytReportObjectArr = dtbResult.Rows[0]["REPORT_OBJECT_LOB"] as byte[];
            }
            return lngRes;
        }
        #endregion
    }
}
