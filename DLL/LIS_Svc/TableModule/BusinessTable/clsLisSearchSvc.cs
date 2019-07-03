using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using System.Security.Principal;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// LIS查询Svc
    /// </summary>
    public class clsLisSearchSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 住院采集样本 - 组合查询查询已发送申请单及样本信息


        /// <summary>
        /// 【住院采集样本】组合查询查询已发送申请单及样本信息

        /// </summary>
        /// <remarks>住院部分不关联收费信息</remarks>
        /// <param name="sampleStatus"></param>
        /// <param name="areaId"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="patientName"></param>
        /// <param name="patientCardId"></param>
        /// <param name="hosipitalNo"></param>
        /// <param name="bedNo"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppAndSampleInfo(int sampleStatus, string areaId,
                                             string beginDate, string endDate, string patientName,
                                             string patientCardId, string hosipitalNo, string bedNo,int p_intSampleBack,out clsLisApplMainVO[] p_objAppVOArr)
        {

            long lngRes = 0;
            p_objAppVOArr = null;

            #region SQL

            lngRes = 0;

            #region sql_OLD

            string sql1 = @"  select distinct t1.application_id_chr,
                                                t1.patientid_chr,
                                                t1.application_dat,
                                                t1.sex_chr,
                                                t1.patient_name_vchr,
                                                t1.patient_subno_chr,
                                                t1.age_chr,
                                                t1.patient_type_id_chr,
                                                t1.diagnose_vchr,
                                                t1.bedno_chr,
                                                t1.icdcode_chr,
                                                t1.patientcardid_chr,
                                                t1.application_form_no_chr,
                                                t1.modify_dat,
                                                t1.operator_id_chr,
                                                t1.appl_empid_chr,
                                                t1.appl_deptid_chr,
                                                t1.summary_vchr,
                                                t1.pstatus_int,
                                                t1.emergency_int,
                                                t1.special_int,
                                                t1.form_int,
                                                t1.patient_inhospitalno_chr,
                                                t1.sample_type_id_chr,
                                                t1.check_content_vchr,
                                                t1.sample_type_vchr,
                                                t1.oringin_dat,
                                                t1.charge_info_vchr,
                                                t1.printed_num,
                                                t2.report_group_id_chr,
                                                t2.status_int as report_status_int,
                                                t2.reportor_id_chr,
                                                t2.report_dat,
                                                t2.confirmer_id_chr,
                                                t2.confirm_dat,
                                                t2.summary_vchr as report_summary_vchr,
                                                t2.xml_summary_vchr as report_xml_sumary_vchr,
                                                t3.sample_id_chr,
                                                t3.barcode_vchr,
                                                t3.collector_id_chr,
                                                t3.samplestate_vchr,
                                                t3.sampling_date_dat,
                                                t3.check_date_dat,
                                                t3.acceptor_id_chr,
                                                t3.accept_dat,
                                                t3.checker_id_chr,
                                                decode(t3.status_int, null, 1, t3.status_int) as sample_status_int,
                                                t4.hasbarcode_int
                                           from t_opr_lis_application t1,
                                                t_opr_lis_app_report  t2,
                                                t_opr_lis_sample      t3,
                                                t_aid_lis_sampletype  t4
                                          where t1.application_id_chr = t2.application_id_chr
                                            and t1.application_id_chr = t3.application_id_chr(+)
                                            and t1.sample_type_id_chr = t4.sample_type_id_chr(+)
                                            and patient_type_id_chr = 1
                                            and pstatus_int = 2
                                            and form_int = 1
                                            and t1.pstatus_int >= 0
                                            and t2.status_int >= 0  ";
            #endregion

            string sql = @"select distinct t1.application_id_chr,
                t1.patientid_chr,
                t1.application_dat,
                t1.sex_chr,
                t1.patient_name_vchr,
                t1.patient_subno_chr,
                t1.age_chr,
                t1.patient_type_id_chr,
                t1.diagnose_vchr,
                t1.bedno_chr,
                t1.icdcode_chr,
                t1.patientcardid_chr,
                t1.application_form_no_chr,
                t1.modify_dat,
                t1.operator_id_chr,
                t1.appl_empid_chr,
                t1.appl_deptid_chr,
                t1.summary_vchr,
                t1.pstatus_int,
                t1.emergency_int,
                t1.special_int,
                t1.form_int,
                t1.patient_inhospitalno_chr,
                t1.sample_type_id_chr,
                t1.check_content_vchr,
                t1.sample_type_vchr,
                t1.oringin_dat,
                t1.charge_info_vchr,
                t1.printed_num,
                t3.sample_id_chr,
                t3.barcode_vchr,
                t3.collector_id_chr,
                t3.samplestate_vchr,
                t3.sampling_date_dat,
                t3.check_date_dat,
                t3.acceptor_id_chr,
                t3.accept_dat,
                t3.checker_id_chr,
                t3.issampleback,
                t3.sample_back_reason,
                decode(t3.status_int, null, 1, t3.status_int) as sample_status_int,
                t4.hasbarcode_int
  from t_opr_lis_application t1,
       t_opr_lis_sample      t3,
       t_aid_lis_sampletype  t4
 where t1.application_id_chr = t3.application_id_chr(+)
   and t1.sample_type_id_chr = t4.sample_type_id_chr(+)
   and t1.patient_type_id_chr = 1
   and t1.pstatus_int = 2
   and t1.form_int = 1
   and t1.pstatus_int >= 0
   and exists (select 1
          from t_opr_attachrelation a
         where a.attachid_vchr = t1.application_id_chr
           and a.status_int = 1)
 ";

            string strSQL_FromDateApp = " and application_dat >=to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_ToDateApp = " and application_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_AppDept = " and trim(t1.appl_deptid_chr) = ? ";
           
            string strSQL_SampleSatus_NoSample = " and t3.status_int is null ";
            string strSQL_SampleSatus_Sampled = " and t3.status_int > 1 ";
            string strSQL_SampleSatus_Sampled_NoVerify = " and t3.status_int>1 and t3.status_int < 3  ";
            string strSQL_SampleSatus_All = " and (t3.status_int > 0 or t3.status_int is null) ";
            

            string strSQL_PatientName = " and t1.patient_name_vchr like ? ";
            string strSQL_PatientCardID = " and t1.patientcardid_chr = ? ";
            string strSQL_PatientHosipitalNO = " and trim(t1.patient_inhospitalno_chr) = ? ";
            string strSQL_PatientBedNo = " and trim(t1.bedno_chr) = ? ";
            string strSQL_Accepted = " and t3.status_int >= 3 ";
            string strSQL_SampleBack = " and t3.issampleback = 1 ";
            string strSQL_NotSampleBack = " and t3.issampleback = 0 ";

            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造


            if (sampleStatus == 1)
            {
                arlSQL.Add(strSQL_SampleSatus_NoSample);
            }
            else if (sampleStatus == 2)
            {
                arlSQL.Add(strSQL_SampleSatus_Sampled);
            }
            else if (sampleStatus==3)
            {
                arlSQL.Add(strSQL_SampleSatus_Sampled_NoVerify);
            }
            else if (sampleStatus == 4)
            {
                arlSQL.Add(strSQL_Accepted);
            }
            else if (sampleStatus == 0)
            {
                arlSQL.Add(strSQL_SampleSatus_All);
            }
            if (p_intSampleBack == 0)
            {
                arlSQL.Add(strSQL_NotSampleBack);
            }
            else if (p_intSampleBack == 1)
            {
                arlSQL.Add(strSQL_SampleBack);
            }

            if (beginDate != null && Microsoft.VisualBasic.Information.IsDate(beginDate.Trim()))
            {
                arlSQL.Add(strSQL_FromDateApp);
                DateTime dtStart = DateTime.Parse(beginDate);
                arlParm.Add(dtStart.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (endDate != null && Microsoft.VisualBasic.Information.IsDate(endDate.Trim()))
            {
                arlSQL.Add(strSQL_ToDateApp);
                DateTime dtEnd = DateTime.Parse(endDate);
                arlParm.Add(dtEnd.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (areaId != null && areaId.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDept);
                arlParm.Add(areaId.Trim());
            }

            if (patientName != null && patientName.ToString().Replace('%', ' ').Trim() != "")
            {
                arlSQL.Add(strSQL_PatientName);
                arlParm.Add(patientName.Trim());
            }

            if (patientCardId != null && patientCardId.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_PatientCardID);
                arlParm.Add(patientCardId.Trim());
            }

            if (areaId != null && areaId.ToString().Trim() != "" && hosipitalNo.Trim() != string.Empty)
            {
                arlSQL.Add(strSQL_PatientHosipitalNO);
                arlParm.Add(hosipitalNo.Trim());
            }
            if (areaId != null && areaId.ToString().Trim() != "" && bedNo.Trim() != string.Empty)
            {
                arlSQL.Add(strSQL_PatientBedNo);
                arlParm.Add(bedNo.Trim());
            }

            #endregion

            foreach (object obj in arlSQL)
            {
                sql += obj.ToString();
            }

            int intParmCount = 0;
            intParmCount = arlParm.Count;

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

            for (int i = 0; i < intParmCount; i++)
            {
                objDPArr[i].Value = arlParm[i];
            }

            try
            {
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(sql, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    ArrayList arlApp = new ArrayList();
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsLisApplMainVO objMainVO = m_objConstructAppMainVO(dtbResult.Rows[i]);
                        if (dtbResult.Rows[i]["issampleback"].ToString().Trim() == "1")
                        {
                            objMainVO.m_strSample_Back_Reason = dtbResult.Rows[i]["sample_back_reason"].ToString().Trim();
                        }
                        arlApp.Add(objMainVO);
                    }
                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
                }
                else
                {
                    p_objAppVOArr = new clsLisApplMainVO[0];
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                p_objAppVOArr = new clsLisApplMainVO[0];
            }

            return lngRes;
        }

        #endregion

        #region 构造clsLisApplMainVO

        /// <summary>
        /// 构建 clsLisApplMainVO 
        /// </summary>
        /// <param name="p_objRow"></param>
        /// <returns></returns>
        [AutoComplete]
        public clsLisApplMainVO m_objConstructAppMainVO(DataRow p_objRow)
        {
            clsLisApplMainVO objApplMainVO = new clsLisApplMainVO();
            try
            {
                if (p_objRow["APPLICATION_ID_CHR"] != System.DBNull.Value)
                { objApplMainVO.m_strAPPLICATION_ID = p_objRow["APPLICATION_ID_CHR"].ToString().Trim(); }

                if (p_objRow["MODIFY_DAT"] != System.DBNull.Value)
                { objApplMainVO.m_strMODIFY_DAT = p_objRow["MODIFY_DAT"].ToString().Trim(); }

                if (p_objRow["patientid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatientID = p_objRow["patientid_chr"].ToString().Trim(); }

                if (p_objRow["application_dat"] != System.DBNull.Value)
                { objApplMainVO.m_strAppl_Dat = Convert.ToDateTime(p_objRow["application_dat"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"); }

                if (p_objRow["sex_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strSex = p_objRow["sex_chr"].ToString().Trim(); }

                if (p_objRow["patient_name_vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatient_Name = p_objRow["patient_name_vchr"].ToString().Trim(); }

                if (p_objRow["patient_subno_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatient_SubNO = p_objRow["patient_subno_chr"].ToString().Trim(); }

                if (p_objRow["age_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strAge = p_objRow["age_chr"].ToString().Trim(); }

                if (p_objRow["patient_type_id_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatientType = p_objRow["patient_type_id_chr"].ToString().Trim(); }

                if (p_objRow["diagnose_vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strDiagnose = p_objRow["diagnose_vchr"].ToString().Trim(); }

                if (p_objRow["bedno_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strBedNO = p_objRow["bedno_chr"].ToString().Trim(); }

                if (p_objRow["icdcode_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strICD = p_objRow["icdcode_chr"].ToString().Trim(); }

                if (p_objRow["patientcardid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatientcardID = p_objRow["patientcardid_chr"].ToString().Trim(); }

                if (p_objRow["application_form_no_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strApplication_Form_NO = p_objRow["application_form_no_chr"].ToString().Trim(); }

                if (p_objRow["operator_id_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strOperator_ID = p_objRow["operator_id_chr"].ToString().Trim(); }

                if (p_objRow["appl_empid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strAppl_EmpID = p_objRow["appl_empid_chr"].ToString().Trim(); }

                if (p_objRow["appl_deptid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strAppl_DeptID = p_objRow["appl_deptid_chr"].ToString().Trim(); }

                if (p_objRow["Summary_Vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strSummary = p_objRow["Summary_Vchr"].ToString().Trim(); }

                if (p_objRow["PStatus_int"] != System.DBNull.Value)
                { objApplMainVO.m_intPStatus_int = Convert.ToInt32(p_objRow["PStatus_int"]); }

                if (p_objRow["emergency_int"] != System.DBNull.Value)
                { objApplMainVO.m_intEmergency = Convert.ToInt32(p_objRow["emergency_int"]); }

                if (p_objRow["special_int"] != System.DBNull.Value)
                { objApplMainVO.m_intSpecial = Convert.ToInt32(p_objRow["special_int"]); }

                if (p_objRow["form_int"] != System.DBNull.Value)
                { objApplMainVO.m_intForm_int = Convert.ToInt32(p_objRow["form_int"]); }

                if (p_objRow["patient_inhospitalno_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatient_inhospitalno_chr = p_objRow["patient_inhospitalno_chr"].ToString().Trim(); }

                if (p_objRow["SAMPLE_TYPE_ID_CHR"] != System.DBNull.Value)
                { objApplMainVO.m_strSampleTypeID = p_objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim(); }

                if (p_objRow["SAMPLE_TYPE_VCHR"] != System.DBNull.Value)
                { objApplMainVO.m_strSampleType = p_objRow["SAMPLE_TYPE_VCHR"].ToString().Trim(); }

                if (p_objRow["CHECK_CONTENT_VCHR"] != System.DBNull.Value)
                { objApplMainVO.m_strCheckContent = p_objRow["CHECK_CONTENT_VCHR"].ToString().Trim(); }

                if (p_objRow["oringin_dat"] != System.DBNull.Value)
                { objApplMainVO.m_strOriginDate = DateTime.Parse(p_objRow["oringin_dat"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"); }

                if (p_objRow["CHARGE_INFO_VCHR"] != System.DBNull.Value)
                { objApplMainVO.m_strChargeInfo = p_objRow["CHARGE_INFO_VCHR"].ToString().Trim(); }

                if (p_objRow["SAMPLE_ID_CHR"] != System.DBNull.Value)
                { objApplMainVO.m_strSampleID = p_objRow["SAMPLE_ID_CHR"].ToString().Trim(); }

                if (p_objRow["SAMPLE_STATUS_INT"] != System.DBNull.Value)
                { objApplMainVO.m_intSampleStatus = int.Parse(p_objRow["SAMPLE_STATUS_INT"].ToString().Trim()); }

                if (p_objRow["hasbarcode_int"] != System.DBNull.Value)
                { objApplMainVO.m_blnHasBarcode = DBAssist.ToInt32(p_objRow["hasbarcode_int"]) == 1 ? true : false; }

                if (p_objRow["barcode_vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strBarcode = p_objRow["barcode_vchr"].ToString().Trim(); }

                if (p_objRow["PRINTED_NUM"] != System.DBNull.Value)
                {
                    objApplMainVO.m_isPrinted = DBAssist.ToInt32(p_objRow["PRINTED_NUM"].ToString().Trim()) == 1 ? true : false;
                }
            }
            catch
            {
                objApplMainVO = null;
            }
            return objApplMainVO;
        }

        #endregion
    }
}
